using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using LusidFeatures;
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
        private IConfigurationRecipeApi _recipeApi;

        private static readonly string ValuationDateKey = "Analytic/default/ValuationDate";
        private static readonly string HoldingPvKey = "Holding/default/PV";
        private static readonly string InstrumentName = "Instrument/default/Name";
        private static readonly string InstrumentTag = "Analytic/default/InstrumentTag";

        private static readonly List<AggregateSpec> ValuationSpec = new List<AggregateSpec>
        {
            new AggregateSpec(ValuationDateKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentName, AggregateSpec.OpEnum.Value),
            new AggregateSpec(HoldingPvKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentTag, AggregateSpec.OpEnum.Value)
        };
        
        private static readonly DateTimeOffset TestEffectiveFrom = new DateTimeOffset(2020, 2, 16, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset TestEffectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);

        //    This defines the scope that entities will be created in
        private const string TutorialScope = "Testdemo";


        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");

            _instrumentLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = _instrumentLoader.LoadInstruments();
            _recipeApi = _apiFactory.Api<IConfigurationRecipeApi>();
            _testDataUtilities = new TestDataUtilities(
                _apiFactory.Api<ITransactionPortfoliosApi>(),
                _apiFactory.Api<IInstrumentsApi>(),
                _apiFactory.Api<IQuotesApi>(),
                _apiFactory.Api<IComplexMarketDataApi>());
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
            string recipeScope = "some-recipe-scope";
            var recipe = new ConfigurationRecipe
            (
                scope: recipeScope,
                code: "DataScope_Recipe",
                market: new MarketContext
                {
                    Suppliers = new MarketContextSuppliers
                    {
                        Equity = "DataScope"
                    },
                    Options = new MarketOptions
                    {
                        DefaultSupplier = "DataScope",
                        DefaultInstrumentCodeType = "LusidInstrumentId",
                        DefaultScope = scope
                    }
                }
            );

            //    Upload recipe to Lusid (only need to do once, i.e. no need to repeat in non-demo code.)
            UpsertRecipe(recipe);

            //    Upload the quote
            _apiFactory.Api<IQuotesApi>().UpsertQuotes(scope, quotes);

            //    Create the valuation request, this example calculates the percentage of total portfolio value and value by instrument 
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(recipeScope, "DataScope_Recipe"),
                metrics: new List<AggregateSpec>
                {
                    new AggregateSpec(InstrumentName, AggregateSpec.OpEnum.Value),
                    new AggregateSpec(HoldingPvKey, AggregateSpec.OpEnum.Proportion),
                    new AggregateSpec(HoldingPvKey, AggregateSpec.OpEnum.Sum)
                },
                valuationSchedule: new ValuationSchedule(effectiveAt: effectiveDate),
                groupBy: new List<string> { "Instrument/default/Name" },
                portfolioEntityIds: new List<PortfolioEntityId> { new PortfolioEntityId(TutorialScope, portfolioId) }
                );

            //    Do the aggregation
            var results = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);

            Assert.That(results.Data, Has.Count.EqualTo(4));
            Assert.That(results.Data[0]["Sum(Holding/default/PV)"], Is.EqualTo(10000));
            Assert.That(results.Data[2]["Sum(Holding/default/PV)"], Is.EqualTo(20000));
            Assert.That(results.Data[3]["Sum(Holding/default/PV)"], Is.EqualTo(30000));
        }

        [Test]
        public void InlineMultiDateValuationOfABond()
        {
            // CREATE a bond instrument inline
            var instruments = new List<WeightedInstrument>
            {
                new WeightedInstrument(1, "bond", InstrumentExamples.CreateExampleBond())
            };

            // CREATE inline valuation request asking for instruments PV using a "default" recipe
            var scope = Guid.NewGuid().ToString();
            var valuationSchedule = new ValuationSchedule(effectiveFrom: TestEffectiveFrom, effectiveAt: TestEffectiveAt);
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, "default"),
                metrics: ValuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);

            // Values the bond for each day in between 2020-02-16 and 2020-02-23 (inclusive)
            var valuation = _apiFactory.Api<IAggregationApi>().GetValuationOfWeightedInstruments(inlineValuationRequest);
            Assert.That(valuation, Is.Not.Null);
            // 6 valuation days (Given Sun-Sun (see effectiveFrom|To), rolls forward to Monday and generates schedule, rolling to appropriate GBD) 
            Assert.That(valuation.Data.Count, Is.EqualTo(6));

            // GET the present values of the bond
            var presentValues = valuation.Data
                .Select(data => (double) data[HoldingPvKey])
                .ToList();

            // CHECK pvs are positive (true for bonds)
            var allPositivePvs = presentValues.All(pv => pv >= 0);
            Assert.That(allPositivePvs, Is.EqualTo(true));

            // CHECK pvs are unique as they are valued everyday
            var uniquePvs = presentValues.Distinct().Count();
            // 6 valuation days (Given Sun-Sun (see effectiveFrom|To), rolls forward to Monday and generates schedule, rolling to appropriate GBD) 
            Assert.That(uniquePvs, Is.EqualTo(6));
        }

        [Test]
        public void InlineSingleDateValuationOfInstrumentPortfolio()
        {
            // CREATE a portfolio of instruments inline
            var instruments = new List<WeightedInstrument>
            {
                new WeightedInstrument(1, nameof(FxForward), InstrumentExamples.CreateExampleFxForward()),
                new WeightedInstrument(2, nameof(FxOption), InstrumentExamples.CreateExampleFxOption()),
                new WeightedInstrument(3, nameof(Bond), InstrumentExamples.CreateExampleBond()),
            };

            // POPULATE with required market data for valuation of the instruments
            var scope = Guid.NewGuid().ToString();
            _testDataUtilities.UpsertFxRate(scope, TestEffectiveAt);
            
            // CREATE and upsert recipe for pricing the portfolio of instruments 
            var constantTimeValueOfMoneyRecipeCode = "ConstantTimeValueOfMoneyRecipe";
            CreateAndUpsertRecipe(constantTimeValueOfMoneyRecipeCode, scope, ModelSelection.ModelEnum.ConstantTimeValueOfMoney);

            // CREATE inline valuation request asking for the inline instruments' PV
            var valuationSchedule = new ValuationSchedule(effectiveAt: TestEffectiveAt);
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, constantTimeValueOfMoneyRecipeCode),
                metrics: ValuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);

            // CALL valuation and check the PVs makes sense.
            var valuation = _apiFactory.Api<IAggregationApi>().GetValuationOfWeightedInstruments(inlineValuationRequest);
            Assert.That(valuation, Is.Not.Null);

            foreach (var result in valuation.Data)
            {
                var pv = (double) result[HoldingPvKey];
                Assert.That(pv, Is.Not.EqualTo(0).Within(1e-5));

                var instrumentTag = (string) result[InstrumentTag];
                if (instrumentTag != nameof(FxForward))
                {
                    Assert.That(pv, Is.GreaterThanOrEqualTo(0));
                }
            }
        }

        [Test]
        public void TestDemonstratingFxForwardPricingWithDifferentPricingModels()
        {
            // CREATE and upset two recipe to price Fx-Forward - one by ConstantTimeValueOfMoney and one by Discounting 
            var scope = Guid.NewGuid().ToString();

            var discountingRecipeCode = "DiscountingRecipe";
            CreateAndUpsertRecipe(discountingRecipeCode, scope, ModelSelection.ModelEnum.Discounting);

            var constantTimeValueOfMoneyRecipeCode = "ConstantTimeValueOfMoneyRecipe";
            CreateAndUpsertRecipe(constantTimeValueOfMoneyRecipeCode, scope, ModelSelection.ModelEnum.ConstantTimeValueOfMoney);

            // POPULATE stores with required market data to value Fx-Forward using discounting model
            // Fx rates are upserted for both models
            // Rate curves are upserted for the discounting pricing model
            _testDataUtilities.UpsertFxRate(scope, TestEffectiveAt);
            _testDataUtilities.UpsertRateCurves(scope, TestEffectiveAt);

            // CREATE a Fx-Forward as an inline instrument 
            var instruments = new List<WeightedInstrument>
            {
                new WeightedInstrument(100, "fx-forward", InstrumentExamples.CreateExampleFxForward())
            };

            // CREATE valuation schedule
            var valuationSchedule = new ValuationSchedule(effectiveAt: TestEffectiveAt);

            // CREATE inline valuation request for Simple Static and Discounting pricing model 
            var discountingInlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, discountingRecipeCode),
                metrics: ValuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);

            var constantTimeValueOfMoneyValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, constantTimeValueOfMoneyRecipeCode),
                metrics: ValuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);

            // CALL valuation for Fx-Forward with each recipe
            var discountingValuation = _apiFactory.Api<IAggregationApi>()
                .GetValuationOfWeightedInstruments(discountingInlineValuationRequest);
            var constantTimeValueOfMoneyValuation = _apiFactory.Api<IAggregationApi>()
                .GetValuationOfWeightedInstruments(constantTimeValueOfMoneyValuationRequest);

            // ASSERT that the PV differs between the models and are not null
            Assert.That(discountingValuation, Is.Not.Null);
            Assert.That(constantTimeValueOfMoneyValuation, Is.Not.Null);
            var diff = (double) discountingValuation.Data.First()[HoldingPvKey]
                       - (double) constantTimeValueOfMoneyValuation.Data.First()[HoldingPvKey];
            Assert.That(diff, Is.Not.EqualTo(0).Within(1e-3));
        }

        [TestCase(nameof(Bond))]
        [TestCase(nameof(FxForward))]
        [TestCase(nameof(FxOption))]
        [TestCase(nameof(InterestRateSwap))]
        public void TestDemonstratingTheValuationOfInstruments(string instrumentName)
        {
            // CREATE a portfolio with instrument
            var scope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(scope);
            LusidInstrument instrument = InstrumentExamples.GetExampleInstrument(instrumentName);
            
            // UPSERT the above instrument to portfolio as well as populating stores with required market data
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                scope, 
                portfolioId,
                TestEffectiveAt,
                TestEffectiveAt,
                instrument);

            // CREATE and upsert recipe specifying discount pricing model
            var discountingRecipeCode = "DiscountingRecipe";
            CreateAndUpsertRecipe(discountingRecipeCode, scope, ModelSelection.ModelEnum.Discounting);

            // CREATE valuation request
            var valuationSchedule = new ValuationSchedule(effectiveAt: TestEffectiveAt);
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(scope, discountingRecipeCode),
                metrics: ValuationSpec,
                valuationSchedule: valuationSchedule,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, portfolioId)},
                reportCurrency: "USD");

            // CALL valuation
            var valuation = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);
            Assert.That(valuation, Is.Not.Null);
            Assert.That(valuation.Data.Count, Is.EqualTo(1));

            // CHECK PV - note that swaps/forwards can have negative PV
            var pv = (double) valuation.Data.First()[HoldingPvKey];
            Assert.That(pv, Is.Not.Null);
            if (instrumentName != nameof(InterestRateSwap) && instrumentName != nameof(FxForward))
            {
                Assert.That(pv, Is.GreaterThanOrEqualTo(0));
            }
        }

        [TestCase("Bus252", true)]
        [TestCase("Act365", false)]
        [TestCase("ActAct", true)]
        [TestCase("Thirty360", false)]
        [TestCase("ThirtyE360", false)]
        public void TestDemonstratingTheUseOfDifferentCalendarsAndDayCountConventions(string dayCountConvention, bool useCalendarFromCoppClark)
        {
            // GIVEN the payment calendars to use - real calendars e.g. those from Copp Clark can be used, or an
            // empty list can be provided to use the default calendar. The default calendar has no holidays but
            // Saturdays and Sundays are treated as weekends. More than one calendar code can be provided, to combine
            // their holidays. For example, when using two calendars, for a day to be a good business day it must be
            // a good business day in both.
            var paymentCalendars = useCalendarFromCoppClark ? new List<string>{"GBP"} : new List<string>();

            // CREATE the flow conventions with the desired DayCountConvention. The DayCountConvention determines
            // how the elapsed time between two datetime points is calculated.
            var flowConventions = new FlowConventions(
                scope: null,
                code: null,
                currency: "GBP",
                paymentFrequency: "6M",
                rollConvention: "MF",
                dayCountConvention: dayCountConvention,
                paymentCalendars: paymentCalendars,
                resetCalendars: new List<string>(),
                settleDays: 2,
                resetDays: 2
            );
            
            // CREATE a bond instrument inline
            const decimal principal = 1_000_000m;
            var instruments = new List<WeightedInstrument>
            {
                new WeightedInstrument(1, "bond", new Bond(
                    startDate: TestEffectiveAt,
                    maturityDate: TestEffectiveAt.AddYears(1),
                    domCcy: "GBP",
                    principal: principal,
                    couponRate: 0.05m,
                    flowConventions: flowConventions,
                    identifiers: new Dictionary<string, string>(),
                    instrumentType: LusidInstrument.InstrumentTypeEnum.Bond
                ))
            };
            
            // DEFINE the response we want
            const string valuationDateKey = "Analytic/default/ValuationDate";
            const string pvKey = "Holding/default/PV";
            var valuationSpec = new List<AggregateSpec>
            {
                new AggregateSpec(valuationDateKey, AggregateSpec.OpEnum.Value),
                new AggregateSpec(pvKey, AggregateSpec.OpEnum.Value),
            };

            // CREATE inline valuation request asking for instruments PV using a "default" recipe
            var scope = Guid.NewGuid().ToString();
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, "default"),
                metrics: valuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(valuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: new ValuationSchedule(effectiveAt: TestEffectiveAt),
                instruments: instruments);

            // CALL valuation
            var valuation = _apiFactory.Api<IAggregationApi>().GetValuationOfWeightedInstruments(inlineValuationRequest);
            var presentValue = valuation.Data[0][pvKey];

            // CHECK that the PV makes sense
            Assert.That(presentValue, Is.GreaterThanOrEqualTo(principal));
        }
        
        [Test]
        public void SingleDateValuationOfAnInstrumentPortfolio()
        {
            // CREATE a portfolio 
            var scope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(scope);
            
            // CREATE our instrument set
            var instruments = new List<LusidInstrument>
            {
                InstrumentExamples.CreateExampleFxForward(),
                InstrumentExamples.CreateExampleBond(),
                InstrumentExamples.CreateExampleFxOption(),
                InstrumentExamples.CreateExampleSwap()
            };
            
            // UPSERT the above instrument set to portfolio as well as populating stores with required market data
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                scope,
                portfolioId,
                TestEffectiveAt,
                TestEffectiveAt,
                instruments);

            // CREATE and upsert recipe specifying discount pricing model
            var discountingRecipeCode = "DiscountingRecipe";
            CreateAndUpsertRecipe(discountingRecipeCode, scope, ModelSelection.ModelEnum.Discounting);
            
            var valuationSchedule = new ValuationSchedule(effectiveAt: TestEffectiveAt);
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(scope, discountingRecipeCode),
                metrics: ValuationSpec,
                valuationSchedule: valuationSchedule,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, portfolioId)},
                reportCurrency: "USD");

            // CALL valuation
            var valuation = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);
            Assert.That(valuation, Is.Not.Null);
            Assert.That(valuation.Data.Count, Is.EqualTo(instruments.Count));

            // CHECK PV results make sense
            foreach (var result in valuation.Data)
            {
                var inst = (string) result[InstrumentName];
                var pv = (double) result[HoldingPvKey];
                Assert.That(pv, Is.Not.Null);

                if (inst != nameof(FxForward) && inst != nameof(InterestRateSwap))
                {
                    Assert.That(pv, Is.GreaterThanOrEqualTo(0));
                }
            }
        }

        [Test]
        public void MultiDateValuationOfAnInstrumentPortfolio()
        {
            // CREATE a portfolio 
            var scope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(scope);
            
            var instruments = new List<LusidInstrument>
            {
                InstrumentExamples.CreateExampleBond(),
                InstrumentExamples.CreateExampleFxOption(),
            };
            
            // Upsert instrument set to portfolio as well as populating stores with required market data
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                scope,
                portfolioId,
                TestEffectiveFrom,
                TestEffectiveAt,
                instruments,
                equityIdentifier: "ABC Corporation");
            
            // CREATE and upsert recipe for pricing the portfolio of instruments 
            var constantTimeValueOfMoneyRecipeCode = "ConstantTimeValueOfMoneyRecipe";
            CreateAndUpsertRecipe(constantTimeValueOfMoneyRecipeCode, scope, ModelSelection.ModelEnum.ConstantTimeValueOfMoney);

            // CREATE valuation schedule and request
            var valuationSchedule = new ValuationSchedule(effectiveFrom: TestEffectiveFrom, effectiveAt: TestEffectiveAt);
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(scope, constantTimeValueOfMoneyRecipeCode),
                metrics: ValuationSpec,
                valuationSchedule: valuationSchedule,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, portfolioId)},
                reportCurrency: "USD");

            // CALL valuation
            var valuation = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);
            Assert.That(valuation, Is.Not.Null);
            // 6 valuation days (Given Sun-Sun (see effectiveFrom|To), rolls forward to Monday and generates schedule, rolling to appropriate GBD) 
            // 3 instruments: bond, fx option, equity
            // So 6x3.
            Assert.That(valuation.Data.Count, Is.EqualTo(18)); 

            // CHECK PV makes sense
            foreach (var result in valuation.Data)
            {
                Assert.That(result[HoldingPvKey], Is.GreaterThanOrEqualTo(0));
            }
        }

        private void CreateAndUpsertRecipe(string code, string scope, ModelSelection.ModelEnum model)
        {
            // CREATE a rule for reset quotes
            var resetRule = new MarketDataKeyRule("Equity.RIC.*", "Lusid", scope, MarketDataKeyRule.QuoteTypeEnum.Price, "mid", quoteInterval: "1Y");
            
            // CREATE recipe for pricing
            var pricingOptions = new PricingOptions(new ModelSelection(ModelSelection.LibraryEnum.Lusid, model));
            var recipe = new ConfigurationRecipe(
                scope,
                code,
                market: new MarketContext(new List<MarketDataKeyRule>{resetRule}, options: new MarketOptions(defaultScope: scope)),
                pricing: new PricingContext(options: pricingOptions),
                description: $"Recipe for {model} pricing");
            
            UpsertRecipe(recipe);
        }

        private void UpsertRecipe(ConfigurationRecipe recipe)
        {
            // UPSERT recipe and check upsert was successful
            var upsertRecipeRequest = new UpsertRecipeRequest(recipe);
            var response = _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            Assert.That(response.Value, Is.Not.Null);
        }
    }
}
