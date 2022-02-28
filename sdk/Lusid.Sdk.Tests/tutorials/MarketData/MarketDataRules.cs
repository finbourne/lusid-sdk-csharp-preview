using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.MarketData
{
    public class MarketDataRules : TutorialBase
    {
        [Test]
        public void DemoMarketDataSpecificRules()
        {
            // set up scopes: one for recipes, one for holding quotes from a generic source, and one for holding specific quotes that will override ones from the generic scope
            var testScope = "testScope";
            var genericScope = "genericScope";
            var specificScope = "specificScope";

            // create an equity call option for TSLA to value
            var testNow = new DateTimeOffset(2019, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var instrument = new EquityOption(testNow.AddMonths(-1), testNow.AddMonths(+1), testNow.AddMonths(+1), EquityOption.DeliveryTypeEnum.Cash,
                EquityOption.OptionTypeEnum.Call, 90m, "USD", EquityOption.UnderlyingIdentifierEnum.RIC, "TSLA", LusidInstrument.InstrumentTypeEnum.EquityOption);

            // upsert two quotes with different values: one is upserted to the generic scope, one is upserted to the specific scope
            var genericQuote = TestDataUtilities.BuildQuoteRequest("TSLA", QuoteSeriesId.InstrumentIdTypeEnum.RIC, 100m, "USD", testNow);
            var genericQuoteResponse = _quotesApi.UpsertQuotes(genericScope, genericQuote);
            ValidateQuoteUpsert(genericQuoteResponse, genericQuote.Count);
            var specificQuote = TestDataUtilities.BuildQuoteRequest("TSLA", QuoteSeriesId.InstrumentIdTypeEnum.RIC, 120m, "USD", testNow);
            var specificQuoteResponse = _quotesApi.UpsertQuotes(specificScope, specificQuote);
            ValidateQuoteUpsert(specificQuoteResponse, specificQuote.Count);

            // instruct lusid to value equity options with ConstantTimeValueOfMoney (i.e. intrinsic value)
            var modelRules = new VendorModelRule(VendorModelRule.SupplierEnum.Lusid, "ConstantTimeValueOfMoney", "EquityOption", "{}");
            var pricingContext = new PricingContext(modelRules: new List<VendorModelRule> {modelRules});

            // make two market data rules:
            // the first is a generic rule that all RIC prices should be looked for in the generic scope
            // the second is a specific rule that all RIC prices requested by USD-denominated EquityOption instruments should be looked for in the specific scope
            var genericRule = new MarketDataKeyRule("Equity.RIC.*", "Lusid", genericScope, MarketDataKeyRule.QuoteTypeEnum.Price, "mid");
            var specificRule = new MarketDataSpecificRule("Equity.RIC.*", "Lusid", specificScope, MarketDataSpecificRule.QuoteTypeEnum.Price, "mid",
                dependencySourceFilter: new DependencySourceFilter(instrumentType: "EquityOption", null, "USD"));

            // Upsert a generic recipe containing out generic rule that will find the equity spot from the generic scope
            var mktContextGeneric = new MarketContext(options: new MarketOptions(defaultScope: genericScope), marketRules: new List<MarketDataKeyRule> {genericRule});
            var genericRecipe = new ConfigurationRecipe(
                testScope,
                "WithNoSpecificRules",
                mktContextGeneric,
                pricingContext,
                description: $"Should use market data contained in {genericScope}"
            ); ;
            var genericRecipeResponse = _recipeApi.UpsertConfigurationRecipe(new UpsertRecipeRequest(genericRecipe));
            Assert.That(genericRecipeResponse.Value, Is.Not.Null);

            // Upsert a recipe additionally containing our specific rule that will find the equity spot from the specific scope instead
            // The MarketDataSpecificRule takes priority over all MarketDataKeyRules;
            // if the requested quote is not found via specific rules, then quote will be resolved by the generic rules as a fallback
            var mktContextSpecific = new MarketContext(options: new MarketOptions(defaultScope: genericScope), marketRules: new List<MarketDataKeyRule> {genericRule},
                specificRules: new List<MarketDataSpecificRule> {specificRule});
            var specificRecipe = new ConfigurationRecipe(
                testScope,
                "ContainsSpecificRules",
                mktContextSpecific,
                pricingContext,
                description: $"Should override the market data contained in {genericScope} with a quote contained in {specificScope}"
            );
            var specificRecipeResponse = _recipeApi.UpsertConfigurationRecipe(new UpsertRecipeRequest(specificRecipe));
            Assert.That(specificRecipeResponse.Value, Is.Not.Null);

            // Get PVs according to our two recipes, and check that the appropriate values were computed for each recipe
            var genericPv = PerformValuation("WithNoSpecificRules");
            var specificPv = PerformValuation("ContainsSpecificRules");
            Assert.That(genericPv, Is.EqualTo(10)); // strike is 90, spot quote is 100 in the generic scope
            Assert.That(specificPv, Is.EqualTo(30)); // strike is 90, spot quote is 120 in the specific scope

            double? PerformValuation(string recipeName)
            {
                // CREATE the aggregation request
                var aggReq = new InlineValuationRequest(
                    new ResourceId(testScope, recipeName),
                    valuationSchedule: new ValuationSchedule(effectiveAt: testNow.ToString("o")),
                    metrics: TestDataUtilities.ValuationSpec,
                    instruments: new List<WeightedInstrument> {new WeightedInstrument(1m, "myOption", instrument)}
                );

                // GET aggregation results
                var aggResults = _aggregationApi.GetValuationOfWeightedInstruments(aggReq);
                Assert.That(aggResults.AggregationFailures, Is.Empty);
                var pv = aggResults.Data.First()[TestDataUtilities.ValuationPv] as double?;
                return pv;
            }
    }

    }
}
