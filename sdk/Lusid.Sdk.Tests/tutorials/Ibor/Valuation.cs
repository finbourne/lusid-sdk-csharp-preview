using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;
using Version = System.Version;

namespace Lusid.Sdk.Tests.Tutorials.Ibor
{
    [TestFixture]
    public class Valuations
    {
        private ILusidApiFactory _apiFactory;
        private InstrumentLoader _instrumentLoader;
        private TestDataUtilities _testDataUtilities;
        private IList<string> _instrumentIds;

        //    This defines the scope that entities will be created in
        private const string TutorialScope = "Testdemo";
        
        
        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = LusidApiFactoryBuilder.Build("secrets.json");
            
            _instrumentLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = _instrumentLoader.LoadInstruments();
            _testDataUtilities = new TestDataUtilities(_apiFactory.Api<ITransactionPortfoliosApi>());
        }

        [Test]
        public void Run_Valuation()
        {
            var effectiveDate = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);
            
            //    Create the transaction portfolio
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(TutorialScope);

            var transactionSpecs = new[]
                {
                    (Id: _instrumentIds[0], Price: 101, TradeDate: effectiveDate),
                    (Id: _instrumentIds[1], Price: 102, TradeDate: effectiveDate),
                    (Id: _instrumentIds[2], Price: 103, TradeDate: effectiveDate)
                }
                .OrderBy(i => i.Id);

            var newTransactions = transactionSpecs.Select(id =>
                _testDataUtilities.BuildTransactionRequest(id.Id, 100.0, id.Price, "GBP", id.TradeDate, "StockIn"));

            //    Add transactions to the portfolio
            _apiFactory.Api<ITransactionPortfoliosApi>()
                .UpsertTransactions(TutorialScope, portfolioId, newTransactions.ToList());


            //    Set up analytic store used to store prices for the valuation
            var analyticsAPI = _apiFactory.Api<IAnalyticsStoresApi>();
            var _quotesApi = _apiFactory.Api<IQuotesApi>();
            var analyticStores = _apiFactory.Api<IAnalyticsStoresApi>().ListAnalyticStores();
            var store = analyticStores.Values.Where(s => s.Date == effectiveDate && s.Scope == TutorialScope);

            if (!store.Any())
            {
                //    Create the analytic store if one doesn't already exist
                var analyticStoreRequest = new CreateAnalyticStoreRequest(TutorialScope, effectiveDate);
                _apiFactory.Api<IAnalyticsStoresApi>().CreateAnalyticStore(analyticStoreRequest);
            }

            var prices = new List<InstrumentAnalytic>
            {
                new InstrumentAnalytic(_instrumentIds[0], 100),
                new InstrumentAnalytic(_instrumentIds[1], 200),
                new InstrumentAnalytic(_instrumentIds[2], 300)
            };

            // create quotes request

            var quotesAPI = _apiFactory.Api<IQuotesApi>();

            Dictionary<string, UpsertQuoteRequest> quotes_dict = new Dictionary<string, UpsertQuoteRequest>();

            for (int i = 0; i < 3; i++)
            {
                var request = new UpsertQuoteRequest(
                    quoteId: new QuoteId(
                        new QuoteSeriesId(
                            provider: "DataScope",
                            priceSource: "",
                            instrumentId: _instrumentIds[i],
                            instrumentIdType: QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId,
                            quoteType: QuoteSeriesId.QuoteTypeEnum.Price,
                            field: "mid"),
                        effectiveAt: effectiveDate),
                    metricValue: new MetricValue(
                        value: prices[i].Value,
                        unit: "GBP"),
                    lineage: "");

                quotes_dict.Add("quote" + i.ToString(), request);
            }

            _quotesApi.UpsertQuotes(TutorialScope, quotes_dict);


            //    Create the aggregation request, this example calculates the percentage of total portfolio value and value by instrument 
            
            var inline_recipe = new ConfigurationRecipe(
                code:"quotes_recipe",
                market:new MarketContext(
                    marketRules:null,
                    suppliers:new MarketContextSuppliers(
                        equity: MarketContextSuppliers.EquityEnum.DataScope),
                    options:new MarketOptions(
                        defaultSupplier: MarketOptions.DefaultSupplierEnum.DataScope,
                        defaultInstrumentCodeType:MarketOptions.DefaultInstrumentCodeTypeEnum.LusidInstrumentId,
                        defaultScope:TutorialScope)));

            var aggregationRequest = new AggregationRequest(
                inlineRecipe: inline_recipe,
                metrics: new List<AggregateSpec>
                {
                    new AggregateSpec("Instrument/default/Name", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("Holding/default/PV", AggregateSpec.OpEnum.Proportion),
                    new AggregateSpec("Holding/default/PV", AggregateSpec.OpEnum.Sum)
                },
                groupBy: new List<string> {"Instrument/default/Name"},
                effectiveAt: effectiveDate
            );

            //    Do the aggregation
            var aggregation = _apiFactory.Api<IAggregationApi>()
                .GetAggregationByPortfolio(TutorialScope, portfolioId, request: aggregationRequest);

            //    Assert values changes correctly

            //    ADD ASSERTIONS
            Assert.That(aggregation.Data.Count, Is.EqualTo(3)); // length = 3
            Assert.That(aggregation.Data[0]["Sum(Holding/default/PV)"], Is.EqualTo(10000)); // value = 10000
            Assert.That(aggregation.Data[1]["Sum(Holding/default/PV)"], Is.EqualTo(20000)); // value = 20000
            Assert.That(aggregation.Data[2]["Sum(Holding/default/PV)"], Is.EqualTo(30000)); // value = 30000

        }
    }
}
