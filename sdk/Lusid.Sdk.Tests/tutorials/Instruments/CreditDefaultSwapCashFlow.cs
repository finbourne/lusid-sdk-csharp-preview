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
    public class CreditDefaultSwapCashFlow
    {
        private ILusidApiFactory _apiFactory;
        private TestDataUtilities _testDataUtilities;
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private IPortfoliosApi _portfoliosApi;
        private static IConfigurationRecipeApi _recipeApi;
        private IAggregationApi _aggregationApi;
        
        private static readonly string ValuationDateKey = "Analytic/default/ValuationDate";
        private static readonly string ValuationPv = "Valuation/PV/Amount";
        private static readonly string ValuationCcy = "Valuation/PV/Ccy";
        private static readonly string Luid = "Instrument/default/LusidInstrumentId";
        private static readonly string InstrumentName = "Instrument/default/Name";
        private static readonly string InstrumentTag = "Analytic/default/InstrumentTag";
        
        private static readonly List<AggregateSpec> ValuationSpec = new List<AggregateSpec>
        {
            new AggregateSpec(ValuationDateKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(ValuationPv, AggregateSpec.OpEnum.Value),
            new AggregateSpec(ValuationCcy, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentName, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentTag, AggregateSpec.OpEnum.Value),
            new AggregateSpec(Luid, AggregateSpec.OpEnum.Value)
        };

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");
            _transactionPortfoliosApi = _apiFactory.Api<ITransactionPortfoliosApi>();
            _portfoliosApi = _apiFactory.Api<IPortfoliosApi>();
            _recipeApi = _apiFactory.Api<IConfigurationRecipeApi>();
            _aggregationApi = _apiFactory.Api<IAggregationApi>();
            _testDataUtilities = new TestDataUtilities(
                _apiFactory.Api<ITransactionPortfoliosApi>(),
                _apiFactory.Api<IInstrumentsApi>(),
                _apiFactory.Api<IQuotesApi>(),
                _apiFactory.Api<IComplexMarketDataApi>());
        }
        
        [Test]
        public void ExamplePortfolioCashFlowsForCreditDefaultSwaps()
        {
            // CREATE portfolio
            var portfolioScope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE CDS
            var cds = InstrumentExamples.CreateExampleCreditDefaultSwap() as CreditDefaultSwap;
        
            // UPSERT CDS to portfolio and populating stores with required market data
            var effectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                portfolioScope, 
                portfolioId,
                effectiveAt,
                effectiveAt,
                cds);
            
            // UPSERT CDS spread curve before upserting recipe
            _testDataUtilities.UpsertCdsSpreadCurves(portfolioScope, effectiveAt, cds.Ticker, cds.FlowConventions.Currency, cds.ProtectionDetailSpecification.Seniority, 
                cds.ProtectionDetailSpecification.RestructuringType);
            
            // CREATE and upsert recipe specifying discount pricing model
            var discountingRecipeCode = "DiscountingRecipe";
            CreateAndUpsertRecipe(discountingRecipeCode, portfolioScope, ModelSelection.ModelEnum.Discounting);
            
            // CALL api to get cashflows at maturity
            var maturity = cds.MaturityDate;
            var cashFlowsAtMaturity = _transactionPortfoliosApi.GetPortfolioCashFlows(
                portfolioScope,
                portfolioId,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1),
                null,
                null,
                portfolioScope,
                discountingRecipeCode);
            
            // CHECK correct number of cashflow at CDS maturity: There is 1 cash flows corresponding to the last coupon amount.
            var expectedNumber = 1;
            Assert.That(cashFlowsAtMaturity.Values.Count, Is.EqualTo(expectedNumber));
            
            var cashFlows = cashFlowsAtMaturity.Values.Select(cf => cf)
                .Select(cf => (cf.PaymentDate, cf.Amount, cf.Currency))
                .ToList();
            
            // CHECK that expected cash flows at maturity are not 0.
            var allCashFlowsPositive = cashFlows.All(cf => cf.Amount > 0);
            Assert.That(allCashFlowsPositive, Is.True);
            
            _portfoliosApi.DeletePortfolio(portfolioScope, portfolioId);
        }

        internal static void CreateAndUpsertRecipe(string code, string scope, ModelSelection.ModelEnum model)
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

        internal static void UpsertRecipe(ConfigurationRecipe recipe)
        {
            // UPSERT recipe and check upsert was successful
            var upsertRecipeRequest = new UpsertRecipeRequest(recipe);
            var response = _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            Assert.That(response.Value, Is.Not.Null);
        }
    }
}