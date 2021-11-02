using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.tutorials.Instruments
{
    [TestFixture]
    public class DemoEquityOption
    {
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private IInstrumentsApi _instrumentsApi;
        private IQuotesApi _quotesApi;
        private IComplexMarketDataApi _complexMarketDataApi;
        private IConfigurationRecipeApi _recipeApi;
        private IAggregationApi _aggregationApi;

        private TestDataUtilities _testDataUtilities;
        private readonly DateTimeOffset _demoEffectiveAt = new DateTimeOffset(2020, 7, 1, 0, 0, 0, TimeSpan.Zero);

        [OneTimeSetUp]
        public void SetUp()
        {
            // if we are just demoing creation, then all we need is the instruments api
            var apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");

            _transactionPortfoliosApi = apiFactory.Api<ITransactionPortfoliosApi>();
            _instrumentsApi = apiFactory.Api<IInstrumentsApi>();
            _quotesApi = apiFactory.Api<IQuotesApi>();
            _complexMarketDataApi = apiFactory.Api<IComplexMarketDataApi>();
            _recipeApi = apiFactory.Api<IConfigurationRecipeApi>();
            _aggregationApi = apiFactory.Api<IAggregationApi>();

            _testDataUtilities = new TestDataUtilities(_transactionPortfoliosApi,
                _instrumentsApi,
                _quotesApi,
                _complexMarketDataApi,
                _recipeApi
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
            _testDataUtilities.UpsertOtcToLusid(equityOption, "some-name-for-this-equityOption", uniqueId);

            // Can now QUERY from Lusid
            var retrieved = _testDataUtilities.QueryOtcFromLusid(uniqueId);
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
            var scope = "DemoEquityOptionValuation";

            // upsert option
            var option = InstrumentExamples.CreateExampleEquityOption();
            string uniqueId = "id-equityOption-1";
            _testDataUtilities.UpsertOtcToLusid(option, "some-name-for-this-equityOption", uniqueId);

            // for Black-Scholes pricing, we need the following market data
            _testDataUtilities.CreateAndUpsertSimpleQuote(scope, "ACME", QuoteSeriesId.InstrumentIdTypeEnum.Isin, 90m, "USD", _demoEffectiveAt);
            _testDataUtilities.CreateAndUpsertOisCurve(scope, _demoEffectiveAt, "USD");
            _testDataUtilities.CreateAndUpsertVolSurface(scope, _demoEffectiveAt, option, 0.2m);

            // create Black-Scholes recipe specifying where to look for market data and which metrics to return
            // if in a larger portfolio, we would make a specific VendorModelRule specifying that equity options are to be valued using Black-Scholes
            var recipeCode = "EquityOption_ValuationRecipe";
            var pricingOptions = new PricingOptions(new ModelSelection(ModelSelection.LibraryEnum.Lusid, ModelSelection.ModelEnum.BlackScholes));
            var recipe = new ConfigurationRecipe
            (
                scope: scope,
                code: recipeCode,
                market: new MarketContext(
                    new List<MarketDataKeyRule> {},
                    options: new MarketOptions(defaultSupplier: "Lusid", defaultScope: scope, defaultInstrumentCodeType: "Isin")
                    ),
                pricing: new PricingContext(options: pricingOptions)
            );
            _testDataUtilities.UpsertRecipe(recipe);

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
            var valuationSchedule = new ValuationSchedule(effectiveAt: _demoEffectiveAt);

            // construct and perform valuation request
            var instruments = new List<WeightedInstrument> {new WeightedInstrument(1, "some-holding-identifier", option)};
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, recipeCode),
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
        }

        [Test]
        public void DemoEquityOptionCashFlows()
        {
            var scope = "DemoEquityOptionCashFlows";

            // upsert option
            var option = InstrumentExamples.CreateExampleEquityOption();
            string uniqueId = "id-equityOption-1";
            var response = _testDataUtilities.UpsertOtcToLusid(option, "some-name-for-this-equityOption", uniqueId);
            var luid = response.Values.First().Value.LusidInstrumentId;

            // for equity option cashflows, we need the following market data to determine intrinsic value
            _testDataUtilities.CreateAndUpsertSimpleQuote(scope, "ACME", QuoteSeriesId.InstrumentIdTypeEnum.Isin, 110m, "USD", _demoEffectiveAt);

            // create a new portfolio and add the option to it via a transaction
            var portfolioCode = _testDataUtilities.CreateTransactionPortfolio(scope);
            var reqs = new List<TransactionRequest> {_testDataUtilities.BuildTransactionRequest(luid, 100m, 5m, "USD", option.StartDate, "Buy")};
            _transactionPortfoliosApi.UpsertTransactions(scope, portfolioCode, reqs);
            var holdings = _transactionPortfoliosApi.GetHoldings(scope, portfolioCode);
            Assert.That(holdings.Values.Count == 2); // one holding for the option, and an opposite holding of cash

            // create a recipe to tell lusid where to find the requisite market data
            // we require a model to estimate/determine future cashflows (for physically settled options, we currently assume exercise in all models)
            // we choose ConstantTimeValueOfMoney since it has the fewest dependencies
            var recipeCode = "EquityOption_CashFlowsRecipe";
            var pricingOptions = new PricingOptions(new ModelSelection(ModelSelection.LibraryEnum.Lusid, ModelSelection.ModelEnum.ConstantTimeValueOfMoney));
            var recipe = new ConfigurationRecipe
            (
                scope: scope,
                code: recipeCode,
                market: new MarketContext(
                    new List<MarketDataKeyRule> { },
                    options: new MarketOptions(defaultSupplier: "Lusid", defaultScope: scope, defaultInstrumentCodeType: "Isin")
                ),
                pricing: new PricingContext(options: pricingOptions)
            );
            _testDataUtilities.UpsertRecipe(recipe);

            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(scope, portfolioCode, effectiveAt: _demoEffectiveAt,
                windowStart: option.StartDate.AddDays(-3), windowEnd: option.OptionMaturityDate.AddDays(3),
                recipeIdScope: scope, recipeIdCode: recipeCode).Values;
            Assert.That(cashflows.Count, Is.EqualTo(1));
            Assert.That(cashflows[0].Amount, Is.Negative);
        }
    }
}
