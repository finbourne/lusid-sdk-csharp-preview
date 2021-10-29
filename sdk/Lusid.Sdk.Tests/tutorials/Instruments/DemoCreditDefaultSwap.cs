using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class CreditDefaultSwapPricing: DemoInstrument
    {

        [Test]
        public void DemoCreditDefaultSwapCreation()
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
            string uniqueId = Guid.NewGuid().ToString();
            UpsertOtcInstrumentToLusid(cds,  uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcInstrumentFromLusid(uniqueId);
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
            
            DeleteItems(null,null,null,uniqueId);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void DemoCreditDefaultSwapValuation(bool inlineValuation)
        {
            // CREATE a portfolio with instrument
            var scope = Guid.NewGuid().ToString();
            CreditDefaultSwap cds = (CreditDefaultSwap) InstrumentExamples.CreateExampleCreditDefaultSwap();

            UpsertFxRate(scope, EffectiveAt, EffectiveAt, false);
            UpsertRateCurves(scope, EffectiveAt);
            UpsertResetQuotes(scope, EffectiveAt.AddDays(-4));
            
            // UPSERT CDS spread curve before upserting recipe
            UpsertCdsSpreadCurves(scope, TestDataUtilities.EffectiveAt, cds.Ticker, cds.FlowConventions.Currency, cds.ProtectionDetailSpecification.Seniority,
                cds.ProtectionDetailSpecification.RestructuringType); 

            // CALL valuation
            var valuation = Valuation(cds, scope, ModelSelection.ModelEnum.Discounting, EffectiveAt, inlineValuation);
            
            Assert.That(valuation, Is.Not.Null);
            Assert.That(valuation.Data.Count, Is.EqualTo(1));

            // CHECK PV - note that swaps/forwards can have negative PV
            var pv = (double) valuation.Data.First()[TestDataUtilities.HoldingPvKey];
            Assert.That(pv, Is.Not.Null);
        }
        
        [Test]
        public void DemoCreditDefaultSwapCashFlows()
        {
            // CREATE portfolio
            var scope = Guid.NewGuid().ToString();

            // CREATE CDS
            var cds = (CreditDefaultSwap) InstrumentExamples.CreateExampleCreditDefaultSwap();
            string uniqueId = Guid.NewGuid().ToString();
            // UPSERT CDS to portfolio and populating stores with required market data
            var effectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
            UpsertFxRate(scope, EffectiveAt, EffectiveAt, false);
            UpsertRateCurves(scope, EffectiveAt);
            UpsertResetQuotes(scope, EffectiveAt.AddDays(-4));
            // UPSERT CDS spread curve before upserting recipe
            UpsertCdsSpreadCurves(scope, effectiveAt, cds.Ticker, cds.FlowConventions.Currency, cds.ProtectionDetailSpecification.Seniority,
                cds.ProtectionDetailSpecification.RestructuringType);

            // CREATE a new portfolio and add the option to it via a transaction
            var portfolioCode = CreatePortfolioAndTransaction(scope, cds, uniqueId, EffectiveAt); 
            var recipeCode = Guid.NewGuid().ToString(); 
            UpsertRecipe(recipeCode, scope, ModelSelection.ModelEnum.Discounting); 
            
            // CALL api to get cashflows at maturity
            var maturity = cds.MaturityDate;
            var cashFlowsAtMaturity = GetPortfolioCashFlows(
                scope,
                portfolioCode,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1),
                null,
                null,
                scope,
                recipeCode);

            // CHECK that expected cash flows at maturity are not 0.
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

            DeleteItems(scope, recipeCode, portfolioCode, uniqueId);
        }

       
    }
}
