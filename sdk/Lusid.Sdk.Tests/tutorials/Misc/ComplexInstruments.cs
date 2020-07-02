using System;
using System.Collections.Generic;
using Lusid.Sdk.Model;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Misc
{
    [TestFixture]
    public class ComplexInstruments
    {
        [Test]
        public void DemonstrateCreationOfFxForward()
        {
            // CREATE an Fx-Forward (that can then be upserted into LUSID)
            var usdJpyFxRate = 109m; // Assume 1 USD is worth 109m as contract is struck. USD is domestic, JPY is foreign.
            var fxForward = new FxForwardInstrument(
                domAmount: 1m,
                fgnAmount: usdJpyFxRate,
                domCcy: "USD",
                fgnCcy: "JPY",
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                maturityDate: new DateTimeOffset(2020, 9, 18, 0, 0, 0, TimeSpan.Zero)
                );

            // ASSERT that it was created
            Assert.That(fxForward, Is.Not.Null);
            // CAN NOW UPSERT TO LUSID
        }

        [Test]
        public void DemonstrateCreationOfSwap()
        {
            // CREATE an Interest Rate Swap (IRS) (that can then be upserted into LUSID)
            var startDate = new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero);
            var maturityDate = new DateTimeOffset(2030, 2, 7, 0, 0, 0, TimeSpan.Zero);

            // CREATE the flow conventions, index convention
            var flowConventions = new FlowConventions(
                currency: "GBP",
                paymentFrequency: new Tenor(6, Tenor.UnitEnum.Month),
                rollConvention: FlowConventions.RollConventionEnum.MF,
                dayCountConvention: FlowConventions.DayCountConventionEnum.Act365,
                holidayCalendars:new List<string>()
                );

            var idxConvention = new IndexConvention(
                name: "GbpLibor6m",
                publicationDayLag: 0,
                currency: "GBP",
                paymentTenor: new Tenor(6, Tenor.UnitEnum.Month),
                dayCountConvention: IndexConvention.DayCountConventionEnum.Act365,
                fixingReference: "BP00"
            );

            // CREATE the leg definitions
            var fixedLegDef = new LegDefinition(
                rateOrSpread: 0.05m, // fixed leg rate (swap rate)
                stubType: LegDefinition.StubTypeEnum.Front,
                payReceive: LegDefinition.PayReceiveEnum.Pay,
                notionalExchangeType: LegDefinition.NotionalExchangeTypeEnum.None,
                conventions: flowConventions
            );

            var floatLegDef = new LegDefinition(
                rateOrSpread: 0.002m, // float leg spread over curve rate, often zero
                stubType: LegDefinition.StubTypeEnum.Front,
                payReceive: LegDefinition.PayReceiveEnum.Pay,
                notionalExchangeType: LegDefinition.NotionalExchangeTypeEnum.None,
                conventions: flowConventions,
                indexConvention: idxConvention
            );

            // CREATE the fixed leg
            var fixedLeg = new FixedLeg(
                notional: 100m,
                startDate: startDate,
                maturityDate: maturityDate,
                legDefinition: fixedLegDef
                );

            // CREATE the floating leg
            var floatLeg = new FloatingLeg(
                notional: 100m,
                startDate: startDate,
                maturityDate: maturityDate,
                legDefinition: floatLegDef
            );

            var irs = new SwapInstrument(
                startDate: startDate,
                maturityDate: maturityDate,
                legs: new List<InstrumentLeg>
                {
                    floatLeg,
                    fixedLeg
                }
            );

            // ASSERT that it was created
            Assert.That(irs, Is.Not.Null);
            // CAN NOW UPSERT TO LUSID
        }
    }
}

