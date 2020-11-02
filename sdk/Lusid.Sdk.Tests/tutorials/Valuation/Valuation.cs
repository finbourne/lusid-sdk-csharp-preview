using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
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
            _apiFactory = LusidApiFactoryBuilder.Build("secrets.json");

            _instrumentLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = _instrumentLoader.LoadInstruments();
            _recipeApi = _apiFactory.Api<IConfigurationRecipeApi>();
            _testDataUtilities = new TestDataUtilities(
                _apiFactory.Api<ITransactionPortfoliosApi>(),
                _apiFactory.Api<IInstrumentsApi>(),
                _apiFactory.Api<IQuotesApi>(),
                _apiFactory.Api<IStructuredMarketDataApi>());
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

            //    Upload the quote
            _apiFactory.Api<IQuotesApi>().UpsertQuotes(scope, quotes);

            //    Create the aggregation request, this example calculates the percentage of total portfolio value and value by instrument 
            var aggregationRequest = new AggregationRequest(
                inlineRecipe: recipe,
                metrics: new List<AggregateSpec>
                {
                    new AggregateSpec(InstrumentName, AggregateSpec.OpEnum.Value),
                    new AggregateSpec(HoldingPvKey, AggregateSpec.OpEnum.Proportion),
                    new AggregateSpec(HoldingPvKey, AggregateSpec.OpEnum.Sum)
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
            Assert.That(valuation.Data.Count, Is.EqualTo(8));

            // GET the present values of the bond
            var presentValues = valuation.Data
                .Select(data => (double) data[HoldingPvKey])
                .ToList();

            // CHECK pvs are positive (true for bonds)
            var allPositivePvs = presentValues.All(pv => pv >= 0);
            Assert.That(allPositivePvs, Is.EqualTo(true));

            // CHECK pvs are unique as they are valued everyday
            var uniquePvs = presentValues.Distinct().Count();
            Assert.That(uniquePvs, Is.EqualTo(8));
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

            // CREATE inline valuation request asking for the inline instruments' PV
            var valuationSchedule = new ValuationSchedule(effectiveAt: TestEffectiveAt);
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, "default"),
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
            // CREATE two recipe to price Fx-Forward - one by Simple Static and one by Discounting 
            var scope = Guid.NewGuid().ToString();

            var discountingRecipeCode = "DiscountingRecipe";
            var discountingPricingOptions = new PricingOptions(
                new ModelSelection(ModelSelection.LibraryEnum.Lusid, ModelSelection.ModelEnum.Discounting));
            var discountingRecipe = new ConfigurationRecipe(
                scope,
                discountingRecipeCode,
                market: new MarketContext(options: new MarketOptions(defaultScope: scope)),
                pricing: new PricingContext(options: discountingPricingOptions),
                description: "Recipe for Discount pricing");

            var simpleStaticRecipeCode = "SimpleStaticRecipe";
            var pricingOptions = new PricingOptions(
                new ModelSelection(ModelSelection.LibraryEnum.Lusid, ModelSelection.ModelEnum.SimpleStatic));
            var simpleStaticRecipe = new ConfigurationRecipe(
                scope,
                simpleStaticRecipeCode,
                market: new MarketContext(options: new MarketOptions(defaultScope: scope)),
                pricing: new PricingContext(options: pricingOptions),
                description: "Recipe for Simple Static pricing");

            // UPSERT both recipes
            UpsertRecipe(discountingRecipe);
            UpsertRecipe(simpleStaticRecipe);

            // POPULATE stores with required market data to value Fx-Forward using discounting model
            // Fx rates are upserted for both models
            // Rate curves are upserted for the discounting pricing model
            _testDataUtilities.UpsertFxRate(scope, TestEffectiveAt);
            _testDataUtilities.UpsertRateCurves(scope, TestEffectiveAt);

            // CREATE a Fx-Forward inline instrument 
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

            var simpleStaticInlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, simpleStaticRecipeCode),
                metrics: ValuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);

            // CALL valuation for Fx-Forward with each recipe
            var discountingValuation = _apiFactory.Api<IAggregationApi>()
                .GetValuationOfWeightedInstruments(discountingInlineValuationRequest);
            var simpleStaticValuation = _apiFactory.Api<IAggregationApi>()
                .GetValuationOfWeightedInstruments(simpleStaticInlineValuationRequest);

            // ASSERT that the PV differs between the models and are not null
            Assert.That(discountingValuation, Is.Not.Null);
            Assert.That(simpleStaticValuation, Is.Not.Null);
            var diff = (double) discountingValuation.Data.First()[HoldingPvKey]
                       - (double) simpleStaticValuation.Data.First()[HoldingPvKey];
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

            // CREATE recipe specifying discount pricing model
            var discountingRecipeCode = "DiscountingRecipe";
            var discountingPricingOptions = new PricingOptions(
                new ModelSelection(ModelSelection.LibraryEnum.Lusid, ModelSelection.ModelEnum.Discounting));
            var discountingRecipe = new ConfigurationRecipe(
                scope,
                discountingRecipeCode,
                market: new MarketContext(options: new MarketOptions(defaultScope: scope)),
                pricing: new PricingContext(options: discountingPricingOptions),
                description: "Recipe for Discount pricing");
            
            // UPSERT the recipe for valuation request/call below
            UpsertRecipe(discountingRecipe);

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

            // CREATE recipe specifying discount pricing model
            var discountingRecipeCode = "DiscountingRecipe";
            var discountingPricingOptions = new PricingOptions(
                new ModelSelection(ModelSelection.LibraryEnum.Lusid, ModelSelection.ModelEnum.Discounting));
            var discountingRecipe = new ConfigurationRecipe(
                scope,
                discountingRecipeCode,
                market: new MarketContext(options: new MarketOptions(defaultScope: scope)),
                pricing: new PricingContext(options: discountingPricingOptions),
                description: "Recipe for Discount pricing");
            
            // UPSERT the recipe for valuation request/call below
            UpsertRecipe(discountingRecipe);

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

            // CREATE valuation schedule and request
            var valuationSchedule = new ValuationSchedule(effectiveFrom: TestEffectiveFrom, effectiveAt: TestEffectiveAt);
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(scope, "default"),
                metrics: ValuationSpec,
                valuationSchedule: valuationSchedule,
                sort: new List<OrderBySpec> {new OrderBySpec(ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, portfolioId)},
                reportCurrency: "USD");

            // CALL valuation
            var valuation = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);
            Assert.That(valuation, Is.Not.Null);
            Assert.That(valuation.Data.Count, Is.EqualTo(24)); // 8 valuation days of 3 instruments: bond, fx option, equity

            // CHECK PV makes sense
            foreach (var result in valuation.Data)
            {
                Assert.That(result[HoldingPvKey], Is.GreaterThanOrEqualTo(0));
            }
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
