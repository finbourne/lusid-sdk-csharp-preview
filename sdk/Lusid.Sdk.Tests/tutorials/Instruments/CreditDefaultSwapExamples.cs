using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class CreditDefaultSwapExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            // POPULATE with required market data for valuation of the instruments
            CreditDefaultSwap cds = (CreditDefaultSwap) instrument;
            var upsertFxRateRequestReq = TestDataUtilities.BuildFxRateRequest(scope, TestDataUtilities.EffectiveAt);
            var upsertFxQuoteResponse = _quotesApi.UpsertQuotes(scope, upsertFxRateRequestReq);
            ValidateQuoteUpsert(upsertFxQuoteResponse, upsertFxRateRequestReq.Count);

            var upsertQuoteRequests = TestDataUtilities.BuildResetQuotesRequest(scope, TestDataUtilities.EffectiveAt.AddDays(-4));
            var upsertQuoteResponse = _quotesApi.UpsertQuotes(scope, upsertQuoteRequests);
            Assert.That(upsertQuoteResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertQuoteResponse.Values.Count, Is.EqualTo(upsertQuoteRequests.Count));
            
            // CREATE a dictionary of complex market data to be upserted for the CDS. We always need a CDS spread curve.
            var cdsSpreadCurveUpsertRequest = TestDataUtilities.BuildCdsSpreadCurvesRequest(
                TestDataUtilities.EffectiveAt,
                cds.Ticker,
                cds.FlowConventions.Currency,
                cds.ProtectionDetailSpecification.Seniority,
                cds.ProtectionDetailSpecification.RestructuringType);

            Dictionary<string, UpsertComplexMarketDataRequest> upsertComplexMarketDataRequest = new Dictionary<string, UpsertComplexMarketDataRequest>()
            {
                {"CdsSpread", cdsSpreadCurveUpsertRequest}
            };

            // For models that is not ConstantTimeValueOfMoney, we require discount curves. We add them to the market data upsert.
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
            {
                foreach (var kv in TestDataUtilities.BuildRateCurvesRequests(TestDataUtilities.EffectiveAt))
                {
                    upsertComplexMarketDataRequest.Add(kv.Key, kv.Value);
                }
            }

            var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
            ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID)
        {
            CreditDefaultSwap cds = (CreditDefaultSwap) instrument;
            var maturity = cds.MaturityDate;
            ResourceListOfInstrumentCashFlow cashFlowsAtMaturity = _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope,
                portfolioCode,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1),
                null,
                null,
                scope,
                recipeCode);
            
            var cashFlows = cashFlowsAtMaturity.Values.Select(cf => cf)
                .Select(cf => (cf.PaymentDate, cf.Amount, cf.Currency))
                .ToList();
            var allCashFlowsPositive = cashFlows.All(cf => cf.Amount > 0);

            Assert.That(allCashFlowsPositive, Is.True);

            // CHECK correct number of CDS premium leg cash flows at maturity: If CDS reaches maturity (that would be if no default event is triggered) there is 1 expected cash flow,
            // which is the last coupon payment of the premium leg.
            var expectedNumber = 1;
            var couponCashFlows = cashFlowsAtMaturity.Values.Where(cf => cf.Diagnostics["CashFlowType"] == "Premium")
                .ToList();

            Assert.That(couponCashFlows.Count, Is.EqualTo(expectedNumber));
             
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode); 
        }
        
        [LusidFeature("F22-6")]
        [Test]
        public void CreditDefaultSwapCreationAndUpsertionExample()
        {
            // CREATE the cds flow conventions for credit default swap
            var cdsFlowConventions = new CdsFlowConventions(
                scope: null,
                code: null,
                currency: "GBP",
                paymentFrequency: "6M",
                rollConvention: "MF",
                dayCountConvention: "Act365",
                paymentCalendars: new List<string>(),
                resetCalendars: new List<string>(),
                rollFrequency: "6M",
                settleDays: 2,
                resetDays: 2
            );
            
            var cdsProtectionDetailSpecification = new CdsProtectionDetailSpecification(
                seniority: CdsProtectionDetailSpecification.SeniorityEnum.SNR,
                restructuringType: CdsProtectionDetailSpecification.RestructuringTypeEnum.CR,
                protectStartDay: true,
                payAccruedInterestOnDefault: false);

            var cds = new CreditDefaultSwap(
                ticker: "ACME",
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                maturityDate: new DateTimeOffset(2020, 9, 18, 0, 0, 0, TimeSpan.Zero),
                flowConventions: cdsFlowConventions,
                couponRate: 0.5m,
                protectionDetailSpecification: cdsProtectionDetailSpecification,
                instrumentType: LusidInstrument.InstrumentTypeEnum.CreditDefaultSwap
            );
            // ASSERT that it was created
            Assert.That(cds, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            var uniqueId = cds.InstrumentType+Guid.NewGuid().ToString(); 
            var instrumentsIds = new List<(LusidInstrument, string)>{(cds, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            UpsertInstrumentsResponse upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            GetInstrumentsResponse getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse, uniqueId);
            
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.CreditDefaultSwap);
            var roundTripCds = retrieved as CreditDefaultSwap;
            Assert.That(roundTripCds, Is.Not.Null);
            Assert.That(roundTripCds.CouponRate, Is.EqualTo(cds.CouponRate));
            Assert.That(roundTripCds.Ticker, Is.EqualTo(cds.Ticker));
            Assert.That(roundTripCds.MaturityDate, Is.EqualTo(cds.MaturityDate));
            Assert.That(roundTripCds.StartDate, Is.EqualTo(cds.StartDate));
            Assert.That(roundTripCds.FlowConventions.Currency, Is.EqualTo(cds.FlowConventions.Currency));
            Assert.That(roundTripCds.FlowConventions.PaymentFrequency, Is.EqualTo(cds.FlowConventions.PaymentFrequency));
            Assert.That(roundTripCds.FlowConventions.ResetDays, Is.EqualTo(cds.FlowConventions.ResetDays));
            Assert.That(roundTripCds.FlowConventions.SettleDays, Is.EqualTo(cds.FlowConventions.SettleDays));
            Assert.That(roundTripCds.FlowConventions.PaymentCalendars.Count, Is.EqualTo(cds.FlowConventions.PaymentCalendars.Count));
            Assert.That(roundTripCds.FlowConventions.PaymentCalendars, Is.EquivalentTo(cds.FlowConventions.PaymentCalendars));
            
            // DELETE Instrument 
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId); 
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void CreditDefaultSwapValuationExample(ModelSelection.ModelEnum model)
        {
            var cds = InstrumentExamples.CreateExampleCreditDefaultSwap();
            CallLusidGetValuationEndpoint(cds, model);
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void CreditDefaultSwapInlineValuationExample(ModelSelection.ModelEnum model)
        {
            var cds = InstrumentExamples.CreateExampleCreditDefaultSwap();
            CallLusidInlineValuationEndpoint(cds, model);
        }

        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void CreditDefaultSwapGetPortfolioCashFlowsExample(ModelSelection.ModelEnum model)
        {
            var cds = InstrumentExamples.CreateExampleCreditDefaultSwap();
            CallLusidGetPortfolioCashFlowsEndpoint(cds, model);
        }

        [TestCase("2020-01-01T00:00:00.0000000+00:00")] // calculate upfront charge for cds contract
        [TestCase("2021-01-01T00:00:00.0000000+00:00")] // calculate pv of cds
        public void CreditDefaultSwapIsdaCdsValuationExample(string sTestNow)
        {
            // Purpose: Demo the valuation of a credit default swap using the IsdaCds vendor library via Lusid
            var testScope = Guid.NewGuid().ToString();
            var testNow = DateTimeOffset.Parse(sTestNow);
            var cds = InstrumentExamples.CreateExampleCreditDefaultSwap() as CreditDefaultSwap;

            // CREATE the configuration Recipe
            var pricingOptions = new PricingOptions();
            // tell Lusid that CDS instruments should be valued with the default model in IsdaCds
            var modelRules = new List<VendorModelRule>
                {new VendorModelRule(VendorModelRule.SupplierEnum.IsdaCds, "VendorDefault", "CreditDefaultSwap")};
            var pricingContext = new PricingContext(options: pricingOptions, modelRules: modelRules);
            // tell Lusid where to find data for IsdaCreditCurves; the IsdaYieldCurve is found according to a default rule
            var mktRules = new List<MarketDataKeyRule> {new MarketDataKeyRule("Credit.IsdaCreditCurve.*.*", "Lusid", testScope, MarketDataKeyRule.QuoteTypeEnum.Rate, "mid")};
            var mktOptions = new MarketOptions("Lusid", null, testScope);
            var mktContext = new MarketContext(mktRules, options: mktOptions);
            var recipeName = "IsdaCdsRecipe";
            var recipe = new ConfigurationRecipe(
                testScope,
                recipeName,
                mktContext,
                pricingContext,
                description: "Isda cds valuation demo"
            );

            // UPSERT the configuration recipe
            var upsertRecipeRequest = new UpsertRecipeRequest(recipe, null);
            var upsertRecipeResponse = _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            Assert.That(upsertRecipeResponse.Value, Is.Not.Null);

            // CREATE the required market data, in this case a credit curve and a yield curve
            string ycXml = File.ReadAllText("../../../tutorials/Ibor/ExampleMarketData/IsdaYieldCurve_USD_20181218.xml");
            var ycOpaque = new OpaqueMarketData(ycXml, "xml", "Example isda yield curve", ComplexMarketData.MarketDataTypeEnum.OpaqueMarketData);
            var upsertYcId = new ComplexMarketDataId("Lusid", effectiveAt: testNow, marketAsset: "IsdaYieldCurve/USD");
            var ccData = new CreditSpreadCurveData(
                baseDate: new DateTimeOffset(2020, 06, 05, 0, 0, 0, TimeSpan.Zero),
                domCcy: "USD",
                tenors: new List<string> {"6M", "1Y", "5Y"},
                spreads: new List<decimal> {0.002m, 0.0018m, 0.001m},
                recoveryRate: 0.4m,
                marketDataType: ComplexMarketData.MarketDataTypeEnum.CreditSpreadCurveData);
            var upsertCcId = new ComplexMarketDataId("Lusid", effectiveAt: testNow, marketAsset: "IsdaCreditCurve/XYZCorp/USD");

            // UPSERT market data
            var upsertYcRequest = new UpsertComplexMarketDataRequest(upsertYcId, ycOpaque);
            var upsertCcRequest = new UpsertComplexMarketDataRequest(upsertCcId, ccData);
            var upsertCmdResponse = _complexMarketDataApi.UpsertComplexMarketData(testScope,
                new Dictionary<string, UpsertComplexMarketDataRequest>
                {
                    {"yc", upsertYcRequest},
                    {"cc", upsertCcRequest}
                });
            Assert.That(upsertCmdResponse.Failed, Is.Empty);

            // CREATE a inline valuation request with an example CDS instrument
            var pvKey = "Holding/default/PV";
            var valRequest = new InlineValuationRequest(
                recipeId: new ResourceId(testScope, recipeName),
                metrics: new List<AggregateSpec>
                {
                    new AggregateSpec("Analytic/default/InstrumentTag", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("Analytic/default/ValuationDate", AggregateSpec.OpEnum.Value),
                    new AggregateSpec(pvKey, AggregateSpec.OpEnum.Value),
                },
                reportCurrency: "USD",
                valuationSchedule: new ValuationSchedule(effectiveAt: new DateTimeOrCutLabel(testNow)),
                instruments: new List<WeightedInstrument>
                {
                    new WeightedInstrument(1, $"{cds.Ticker}-{cds.FlowConventions.Currency}-TestCds", cds)
                });

            // GET the result
            var result = _aggregationApi.GetValuationOfWeightedInstruments(valRequest);

            // CHECK that the valuation was performed
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.AggregationFailures, Is.Empty);
            foreach (var val in result.Data)
            {
                Console.WriteLine(val.GetValueOrDefault(pvKey));
            }
        }
    }
}
