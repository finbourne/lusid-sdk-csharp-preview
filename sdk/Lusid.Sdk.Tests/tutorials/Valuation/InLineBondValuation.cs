using System;
using System.Collections.Generic;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Valuation
{
    [TestFixture]
    public class InLineBondValuation
    {
        private TestDataUtilities _testDataUtilities;
        private ILusidApiFactory _apiFactory;
        private IConfigurationRecipeApi _recipeApi;
        
        // Define scope and effectiveAt for tests
        static readonly string scope = "Testdemo";
        static readonly DateTimeOffset effectiveAt = new DateTimeOffset(2020, 1, 1, 0, 0, 0,TimeSpan.Zero);
        
        [OneTimeSetUp]
        public void SetUp()
        {
            // In the setup, we initialise all the APIs and methods we'll need to value our bond
            // We also upsert a discount curve and a recipe used in the valuation
            
            _apiFactory = LusidApiFactoryBuilder.Build("secrets.json");
            _recipeApi = _apiFactory.Api<IConfigurationRecipeApi>();
            _testDataUtilities = new TestDataUtilities(
                _apiFactory.Api<ITransactionPortfoliosApi>(),
                _apiFactory.Api<IInstrumentsApi>(),
                _apiFactory.Api<IQuotesApi>(),
                _apiFactory.Api<IStructuredMarketDataApi>());
            
            
            // Rate curves are upserted for the discounting pricing model
            _testDataUtilities.UpsertRateCurves(scope, effectiveAt);
            
            // Upsert a recipe to use the discounting curve
            void UpsertRecipe(ConfigurationRecipe recipe)
            {
                // UPSERT recipe and check upsert was successful
                var upsertRecipeRequest = new UpsertRecipeRequest(recipe);
                var response = _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
                Assert.That(response.Value, Is.Not.Null);
            }
            
            var discountingRecipeCode = "DiscountingRecipe";
            var discountingPricingOptions = new PricingOptions(
                new ModelSelection(ModelSelection.LibraryEnum.Lusid, ModelSelection.ModelEnum.Discounting));
            var discountingRecipe = new ConfigurationRecipe(
                scope,
                discountingRecipeCode,
                market: new MarketContext(options: new MarketOptions(defaultScope: scope)),
                pricing: new PricingContext(options: discountingPricingOptions),
                description: "Recipe for Discount pricing");
            
            UpsertRecipe(discountingRecipe);
            
        }
        
        [Test]
        public void Run_BondInLineValuation()
        {
            // Define a flow convention for the Bond
            // In this instance, the bond will pay a GBP coupon every 6 months
            // Accrued interest will be calculated on the ACT/365 day count convention
            
            var flowConventions = new FlowConventions(
                scope: null,
                code: null,
                currency: "GBP",
                paymentFrequency: "6M",
                rollConvention: FlowConventions.RollConventionEnum.MF,
                dayCountConvention: FlowConventions.DayCountConventionEnum.Act365,
                holidayCalendars: new List<string>(),
                settleDays: 2,
                resetDays: 2
            );
            
            // Use the GetValuationOfWeightedInstruments to price our Bond
            // We price the Bond for a date between the Bond's startDate and maturityDate

            ListAggregationResponse bondValuationResult = _apiFactory.Api<IAggregationApi>().GetValuationOfWeightedInstruments(
                new InlineValuationRequest(recipeId: new ResourceId(scope: scope, code: "DiscountingRecipe"),
                    valuationSchedule: new ValuationSchedule(
                        effectiveFrom: new DateTimeOrCutLabel("2020-10-01"),
                        effectiveAt: new DateTimeOrCutLabel("2020-10-01"),
                        tenor: "1D"
                    ),
                    
                    metrics: new List<AggregateSpec>
                {
                    new AggregateSpec(key: "Instrument/default/Name", AggregateSpec.OpEnum.Value),
                    new AggregateSpec(key: "Holding/default/PV", AggregateSpec.OpEnum.Value),
                    new AggregateSpec(key: "Instrument/OTC/Bond/CashFlows", AggregateSpec.OpEnum.Value),
                    new AggregateSpec(key: "Instrument/OTC/Bond/AccruedInterest", AggregateSpec.OpEnum.Value)
                }, 
                    
                    instruments: new List<WeightedInstrument>
                {

                    new WeightedInstrument(
                        quantity: 1,
                        holdingIdentifier: "test-inline-val",
                        instrument: new Bond(
                            startDate: new DateTimeOffset(2020, 1, 1, 0, 0, 0,TimeSpan.Zero),
                            maturityDate: new DateTimeOffset(2020, 12, 31, 23, 59, 59,TimeSpan.Zero),
                            domCcy: "GBP",
                            flowConventions: flowConventions,
                            principal: 10000,
                            couponRate: new decimal(0.05),
                            identifiers: new Dictionary<string, string>(),
                            instrumentType: LusidInstrument.InstrumentTypeEnum.Bond
                        )
                        )
                }));
            
            // Test that the valuation engine returns a valid result
            Assert.That(bondValuationResult.Data, Has.Count.EqualTo(1));
            
            // Test that the PV calculation is what we expect
            double bondValuationResultPv = double.Parse(bondValuationResult.Data[0]["Holding/default/PV"].ToString()!);
            Assert.That(Math.Round(bondValuationResultPv), Is.EqualTo(10074));
            
        }
    }
}
