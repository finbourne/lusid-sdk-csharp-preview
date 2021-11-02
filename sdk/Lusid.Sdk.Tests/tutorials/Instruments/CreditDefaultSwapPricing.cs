using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Tutorials.Ibor;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.tutorials.Instruments
{
    [TestFixture]
    public class CDSPricing
    {
        private ILusidApiFactory _apiFactory;
        private TestDataUtilities _testDataUtilities;
        
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
        
        private static readonly DateTimeOffset TestEffectiveAt = new DateTimeOffset(2020, 4, 01, 0, 0, 0, TimeSpan.Zero);

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");
            _testDataUtilities = new TestDataUtilities(
                _apiFactory.Api<ITransactionPortfoliosApi>(),
                _apiFactory.Api<IInstrumentsApi>(),
                _apiFactory.Api<IQuotesApi>(),
                _apiFactory.Api<IComplexMarketDataApi>());
        }
        
        public void TestDemonstratingThePricingOfCreditDefaultSwaps()
        {
            // CREATE a portfolio with instrument
            var scope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(scope);
            LusidInstrument instrument = InstrumentExamples.CreateExampleCreditDefaultSwap();
            
            // UPSERT the above instrument to portfolio as well as populating stores with required market data
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                scope, 
                portfolioId,
                TestEffectiveAt,
                TestEffectiveAt,
                instrument);
            
            // UPSERT CDS spread curve before upserting recipe
            var cds = (CreditDefaultSwap) instrument;
            _testDataUtilities.UpsertCdsSpreadCurves(scope, TestEffectiveAt, cds.Ticker, cds.FlowConventions.Currency, cds.ProtectionDetailSpecification.Seniority, 
                cds.ProtectionDetailSpecification.RestructuringType);

            // CREATE and upsert recipe specifying discount pricing model
            var discountingRecipeCode = "DiscountingRecipe";
            CreditDefaultSwapCashFlow.CreateAndUpsertRecipe(discountingRecipeCode, scope, ModelSelection.ModelEnum.Discounting);

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
            Assert.That(pv, Is.GreaterThanOrEqualTo(0));
        }
    }
}