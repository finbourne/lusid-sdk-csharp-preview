using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.tutorials.Instruments
{
    [TestFixture]
    public class DemoEquityOption
    {
        private IPortfoliosApi _portfoliosApi;
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private IInstrumentsApi _instrumentsApi;
        private IQuotesApi _quotesApi;
        private IComplexMarketDataApi _complexMarketDataApi;
        private IConfigurationRecipeApi _recipeApi;
        private IAggregationApi _aggregationApi;

        private InstrumentDemoHelpers _instrumentDemoHelpers;
        private TestDataUtilities _testDataUtilities;
        private readonly string _scope = "DemoEquityOptionVal"; //TODO: Revert Name
        private readonly DateTimeOffset _demoEffectiveAt = new DateTimeOffset(2020, 7, 1, 0, 0, 0, TimeSpan.Zero);

        [OneTimeSetUp]
        public void SetUp()
        {
            // if we are just demoing creation, then all we need is the instruments api
            var apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");

            _portfoliosApi = apiFactory.Api<IPortfoliosApi>();
            _transactionPortfoliosApi = apiFactory.Api<ITransactionPortfoliosApi>();
            _instrumentsApi = apiFactory.Api<IInstrumentsApi>();
            _quotesApi = apiFactory.Api<IQuotesApi>();
            _complexMarketDataApi = apiFactory.Api<IComplexMarketDataApi>();
            _recipeApi = apiFactory.Api<IConfigurationRecipeApi>();
            _aggregationApi = apiFactory.Api<IAggregationApi>();

            _instrumentDemoHelpers = new InstrumentDemoHelpers(_instrumentsApi, _quotesApi, _complexMarketDataApi, _recipeApi, _transactionPortfoliosApi);
            _testDataUtilities = new TestDataUtilities(_transactionPortfoliosApi,
                _instrumentsApi,
                _quotesApi,
                _complexMarketDataApi
                );
        }

        [Test]
        public void DemoEquityOptionCreation()
        {
            // CREATE an equity option (that can then be upserted into Lusid)
            var equityOption = InstrumentExamples.CreateExampleEquityOption();
            Assert.That(equityOption, Is.Not.Null);

            // Can now UPSERT to Lusid
            string uniqueId = "id-equityOption-1";
            _instrumentDemoHelpers.UpsertOtcToLusid(equityOption, "some-name-for-this-equityOption", uniqueId);

            // Can now QUERY from Lusid
            var retrieved = _instrumentDemoHelpers.QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption);
            var roundTripEquityOption = retrieved as EquityOption;
            Assert.That(roundTripEquityOption, Is.Not.Null);
            Assert.That(roundTripEquityOption.Code, Is.EqualTo(equityOption.Code));
            Assert.That(roundTripEquityOption.Strike, Is.EqualTo(equityOption.Strike));
            Assert.That(roundTripEquityOption.DeliveryType, Is.EqualTo(equityOption.DeliveryType));
            Assert.That(roundTripEquityOption.DomCcy, Is.EqualTo(equityOption.DomCcy));
            Assert.That(roundTripEquityOption.OptionType, Is.EqualTo(equityOption.OptionType));
            Assert.That(roundTripEquityOption.StartDate, Is.EqualTo(equityOption.StartDate));
            Assert.That(roundTripEquityOption.OptionMaturityDate, Is.EqualTo(equityOption.OptionMaturityDate));
            Assert.That(roundTripEquityOption.OptionSettlementDate, Is.EqualTo(equityOption.OptionSettlementDate));
            Assert.That(roundTripEquityOption.UnderlyingIdentifier, Is.EqualTo(equityOption.UnderlyingIdentifier));
        }

        [Test]
        public void DemoEquityOptionValuation()
        {
            // upsert option
            var option = InstrumentExamples.CreateExampleEquityOption();
            string uniqueId = "id-equityOption-1";
            _instrumentDemoHelpers.UpsertOtcToLusid(option, "some-name-for-this-equityOption", uniqueId);

            // for Black-Scholes pricing, we need the following market data
            _testDataUtilities.CreateAndUpsertSimpleQuote(_scope, "ACME", QuoteSeriesId.InstrumentIdTypeEnum.Isin, 90m, "USD", _demoEffectiveAt);
            // _testDataUtilities.CreateAndUpsertSimpleQuote(_scope, "ACME", QuoteSeriesId.InstrumentIdTypeEnum.RIC, 105m, "USD", option.OptionMaturityDate);
            // _testDataUtilities.CreateAndUpsertSimpleQuote(_scope, "ACME", QuoteSeriesId.InstrumentIdTypeEnum.Isin, 200m, "USD", option.OptionMaturityDate.AddDays(-2));
            _testDataUtilities.CreateAndUpsertOisCurve(_scope, _demoEffectiveAt, "USD");
            _testDataUtilities.CreateAndUpsertVolSurface(_scope, _demoEffectiveAt, option, 0.2m);

            // create Black-Scholes recipe specifying where to look for market data and which metrics to return
            // if in a larger portfolio, we would make a specific VendorModelRule specifying that equity options are to be valued using Black-Scholes
            var pricingOptions = new PricingOptions(new ModelSelection(ModelSelection.LibraryEnum.Lusid, ModelSelection.ModelEnum.BlackScholes));
            var equityRule = new MarketDataKeyRule("Equity.RIC.*", "Lusid", _scope, MarketDataKeyRule.QuoteTypeEnum.Price, "mid", "1Y");
            var recipeCode = "EquityOption_Recipe";
            var recipe = new ConfigurationRecipe
            (
                scope: _scope,
                code: recipeCode,
                market: new MarketContext(
                    new List<MarketDataKeyRule> {},
                    options: new MarketOptions(defaultSupplier: "Lusid", defaultScope: _scope, defaultInstrumentCodeType: "Isin")
                    ),
                pricing: new PricingContext(options: pricingOptions)
            );
            _instrumentDemoHelpers.UpsertRecipe(recipe);

            // define the metrics that we wish to return
            string ValuationDateKey = "Analytic/default/ValuationDate";
            string InstrumentTag = "Analytic/default/InstrumentTag";
            string HoldingPvKey = "Holding/default/PV";
            var valuationSpec = new List<AggregateSpec>
            {
                new AggregateSpec(ValuationDateKey, AggregateSpec.OpEnum.Value),
                new AggregateSpec(InstrumentTag, AggregateSpec.OpEnum.Value),
                new AggregateSpec(HoldingPvKey, AggregateSpec.OpEnum.Value)
            };

            // choose valuation dates
            var postExpiryDate = option.OptionMaturityDate.AddDays(3);
            //var valuationSchedule = new ValuationSchedule(effectiveFrom: postExpiryDate, effectiveAt: postExpiryDate, "1Y");
            //var valuationSchedule = new ValuationSchedule(effectiveAt: _demoEffectiveAt);
            var valuationSchedule = new ValuationSchedule(effectiveAt: _demoEffectiveAt, valuationDateTimes: new List<string> {$"{postExpiryDate:O}"});

            // construct and perform valuation request
            var instruments = new List<WeightedInstrument> {new WeightedInstrument(1, "some-holding-identifier", option)};
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(_scope, recipeCode),
                metrics: valuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);
            var valuation = _aggregationApi.GetValuationOfWeightedInstruments(inlineValuationRequest);
            Assert.That(valuation, Is.Not.Null);
            Assert.That(valuation.Data.Count, Is.EqualTo(instruments.Count));

            var pv = valuation.Data[0][HoldingPvKey];
            Assert.That(pv, Is.Positive);
            Console.WriteLine($"Computed pv of {pv} at time {_demoEffectiveAt:O}");

            // Notes EqOptionImpl is where the 500 comes from, pretty straightforward that if you ask for a valuation on that day that it happens
            // RIC generation on the option maturity date comes from Equity's reset dependencies in Lusid
        }

        [Test]
        public void DemoEquityOptionCashflows()
        {
            // upsert option
            var option = InstrumentExamples.CreateExampleEquityOption();
            string uniqueId = "id-equityOption-1";
            var response = _instrumentDemoHelpers.UpsertOtcToLusid(option, "some-name-for-this-equityOption", uniqueId);
            var luid = response.Values.First().Value.LusidInstrumentId;

            //_testDataUtilities.CreateAndUpsertSimpleQuote(_scope, luid, QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId, 110m, "USD", new DateTimeOffset(2021, 10, 28, 0, 0, 0, TimeSpan.Zero));

            // create a new portfolio and add the option to it via a transaction
            var portfolioCode = _testDataUtilities.CreateTransactionPortfolio(_scope);
            var reqs = new List<TransactionRequest> {_testDataUtilities.BuildTransactionRequest(luid, 100m, 5m, "USD", option.StartDate, "Buy")};
            _transactionPortfoliosApi.UpsertTransactions(_scope, portfolioCode, reqs);
            var holdings = _transactionPortfoliosApi.GetHoldings(_scope, portfolioCode);
            Assert.That(holdings.Values.Count == 2); // one holding for the option, and an opposite holding of cash

            // get
            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(_scope, portfolioCode,
                windowStart: option.StartDate.AddDays(-3), windowEnd: option.OptionMaturityDate.AddDays(3),
                recipeIdScope: _scope, recipeIdCode: "EquityOption_Recipe").Values;

            _portfoliosApi.DeletePortfolio(_scope, portfolioCode);

            // notes: unwindowed is supposed to be minTime -> now, but shows no cashflows
            // windowed gives no cashflows either
        }
    }
}
