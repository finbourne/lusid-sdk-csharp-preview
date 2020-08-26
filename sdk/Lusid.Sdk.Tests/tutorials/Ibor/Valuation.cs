using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Features;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

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
        
        [LusidFeature("F36")]
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

            var newTransactions = transactionSpecs.Select(id => _testDataUtilities.BuildTransactionRequest(id.Id, 100.0M, id.Price, "GBP", id.TradeDate, "Buy"));

            //    Add transactions to the portfolio
            _apiFactory.Api<ITransactionPortfoliosApi>().UpsertTransactions(TutorialScope, portfolioId, newTransactions.ToList());

            var scope = Guid.NewGuid().ToString();
            
            var quotes = new List<(string InstrumentId, decimal Price)>
                {
                    (_instrumentIds[0], 100),
                    (_instrumentIds[1], 200),
                    (_instrumentIds[2], 300)
                }
                .Select(x => new UpsertQuoteRequest(
                    new QuoteId(
                        new QuoteSeriesId(
                            provider: "DataScope", 
                            instrumentId: x.InstrumentId, 
                            instrumentIdType: QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId, 
                            quoteType: QuoteSeriesId.QuoteTypeEnum.Price, field: "mid"
                        ),
                        effectiveAt: effectiveDate
                    ),
                    metricValue: new MetricValue(
                        value: x.Price,
                        unit: "GBP"
                    )
                ))
                .ToDictionary(k => Guid.NewGuid().ToString());

            //    Create the quotes
            var recipe = new ConfigurationRecipe
            (
				scope: "User",
                code: "DataScope_Recipe",
                market: new MarketContext
                {
                    Suppliers = new MarketContextSuppliers
                    {
                        Equity = ResourceSupplier.DataScope
                    },
                    Options = new MarketOptions
                    {
                        DefaultSupplier = MarketOptions.DefaultSupplierEnum.DataScope,
                        DefaultInstrumentCodeType = MarketOptions.DefaultInstrumentCodeTypeEnum.LusidInstrumentId,
                        DefaultScope = scope
                    }
                }
            );
            
            //    Upload the quote
            _apiFactory.Api<IQuotesApi>().UpsertQuotes(scope, quotes);
                       
            //    Create the aggregation request, this example calculates the percentage of total portfolio value and value by instrument 
            var aggregationRequest = new AggregationRequest(
                inlineRecipe: recipe,
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
            var results = _apiFactory.Api<IAggregationApi>().GetAggregation(TutorialScope, portfolioId, aggregationRequest: aggregationRequest);

            Assert.That(results.Data, Has.Count.EqualTo(4));
            Assert.That(results.Data[0]["Sum(Holding/default/PV)"], Is.EqualTo(10000));
            Assert.That(results.Data[2]["Sum(Holding/default/PV)"], Is.EqualTo(20000));
            Assert.That(results.Data[3]["Sum(Holding/default/PV)"], Is.EqualTo(30000));            
        }
    }
}