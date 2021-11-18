using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class ComplexInstruments: TutorialBase
    {
        [LusidFeature("F22-5")]
        [Test]
        public void DemonstrateCreationOfZeroCouponBond()
        {
            // CREATE the flow conventions for bond
            // To be recognised as a zero coupon bond, the paymentFrequency must be "0Invalid"
            // and the coupon rate must be 0.
            var flowConventions = new FlowConventions(
                scope: null,
                code: null,
                currency: "GBP",
                paymentFrequency: "0Invalid",
                rollConvention: "None",
                dayCountConvention: "Invalid",
                paymentCalendars:new List<string>(),
                resetCalendars:new List<string>(),
                settleDays: 2,
                resetDays: 2
            );

            var bond = new Bond(
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                maturityDate: new DateTimeOffset(2020, 9, 18, 0, 0, 0, TimeSpan.Zero),
                domCcy: "GBP",
                principal: 100m,
                couponRate: 0m,
                flowConventions: flowConventions,
                identifiers: new Dictionary<string, string>(),
                instrumentType: LusidInstrument.InstrumentTypeEnum.Bond
            );

            // ASSERT that it was created
            Assert.That(bond, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-zcb-1";
            UpsertOtcToLusid(bond, "some-name-for-this-bond", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.Bond);
            var roundTripBond = retrieved as Bond;
            Assert.That(roundTripBond, Is.Not.Null);
            Assert.That(roundTripBond.Principal, Is.EqualTo(bond.Principal));
            Assert.That(roundTripBond.CouponRate, Is.EqualTo(bond.CouponRate));
            Assert.That(roundTripBond.DomCcy, Is.EqualTo(bond.DomCcy));
            Assert.That(roundTripBond.MaturityDate, Is.EqualTo(bond.MaturityDate));
            Assert.That(roundTripBond.StartDate, Is.EqualTo(bond.StartDate));
            Assert.That(roundTripBond.FlowConventions.Currency, Is.EqualTo(bond.FlowConventions.Currency));
            Assert.That(roundTripBond.FlowConventions.PaymentFrequency, Is.EqualTo(bond.FlowConventions.PaymentFrequency));
            Assert.That(roundTripBond.FlowConventions.ResetDays, Is.EqualTo(bond.FlowConventions.ResetDays));
            Assert.That(roundTripBond.FlowConventions.SettleDays, Is.EqualTo(bond.FlowConventions.SettleDays));
            Assert.That(roundTripBond.FlowConventions.PaymentCalendars.Count, Is.EqualTo(bond.FlowConventions.PaymentCalendars.Count));
            Assert.That(roundTripBond.FlowConventions.PaymentCalendars, Is.EquivalentTo(bond.FlowConventions.PaymentCalendars));
        }

        [LusidFeature("F22-8")]
        [Test]
        public void DemonstrateCreationOfSwapWithNamedConventions()
        {
            // CREATE an Interest Rate Swap (IRS) (that can then be upserted into LUSID)
            var startDate = new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero);
            var maturityDate = new DateTimeOffset(2030, 2, 7, 0, 0, 0, TimeSpan.Zero);

            // CREATE the flow conventions, index convention
            FlowConventionName flowConventionName = new FlowConventionName(currency: "GBP", tenor: "3M");
            FlowConventionName indexConventionName = new FlowConventionName(currency: "GBP", tenor: "3M", indexName:"LIBOR");

            // CREATE the swap
            var irs = CreateSwap(startDate, maturityDate, 0.02m, flowConventionName, indexConventionName);

            // ASSERT that it was created
            Assert.That(irs, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-swap-1";
            UpsertOtcToLusid(irs, "some-name-for-this-swap", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.InterestRateSwap);
            var retrSwap = retrieved as InterestRateSwap;
            Assert.That(retrSwap, Is.Not.Null);
            Assert.That(retrSwap.MaturityDate, Is.EqualTo(irs.MaturityDate));
            Assert.That(retrSwap.StartDate, Is.EqualTo(irs.StartDate));
            Assert.That(retrSwap.Legs.Count, Is.EqualTo(irs.Legs.Count));
        }
        
        private void UpsertOtcToLusid(LusidInstrument instrument, string name, string idUniqueToInstrument)
        {
            // PACKAGE instrument for upsert
            var instrumentDefinition = new InstrumentDefinition(
                name: name,
                identifiers: new Dictionary<string, InstrumentIdValue>
                {
                    ["ClientInternal"] = new InstrumentIdValue(value: idUniqueToInstrument)
                },
                definition: instrument
                );

            // put instrument into Lusid
            var response = _instrumentsApi.UpsertInstruments(new Dictionary<string, InstrumentDefinition>
            {
                ["someId1"] = instrumentDefinition
            });

            // Check the response succeeded and has no errors.
            Assert.That(response.Failed.Count, Is.EqualTo(0));
            Assert.That(response.Values.Count, Is.EqualTo(1));
        }

        private LusidInstrument QueryOtcFromLusid(string idUniqueToInstrument)
        {
            var response = _instrumentsApi.GetInstruments("ClientInternal",
                new List<string>
                {
                    idUniqueToInstrument
                });

            // Check the response succeeded and has no errors.
            Assert.That(response.Failed.Count, Is.EqualTo(0));
            Assert.That(response.Values.Count, Is.EqualTo(1));

            Assert.That(response.Values.First().Key, Is.EqualTo(idUniqueToInstrument));
            return response.Values.First().Value.InstrumentDefinition;
        }

        private InterestRateSwap CreateSwap(DateTimeOffset startDate, DateTimeOffset maturityDate, decimal fixedRate, FlowConventionName flowConventionName, FlowConventionName indexConventionName, string fixedLegDirection = "Pay", decimal notional=100m)
        {
            string floatingLegDirection = fixedLegDirection == "Pay" ? "Receive" : "Pay";

            // CREATE the leg definitions
            var fixedLegDef = new LegDefinition(
                rateOrSpread: fixedRate, // fixed leg rate (swap rate)
                stubType: "Front",
                payReceive: fixedLegDirection,
                notionalExchangeType: "None",
                conventionName: flowConventionName
            );

            var floatLegDef = new LegDefinition(
                rateOrSpread: 0,
                stubType: "Front",
                payReceive: floatingLegDirection,
                notionalExchangeType: "None",
                conventionName: flowConventionName,
                indexConventionName: indexConventionName
            );

            // CREATE the fixed leg
            var fixedLeg = new FixedLeg(
                notional: notional,
                startDate: startDate,
                maturityDate: maturityDate,
                legDefinition: fixedLegDef,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FixedLeg
                );

            // CREATE the floating leg
            var floatLeg = new FloatingLeg(
                notional: notional,
                startDate: startDate,
                maturityDate: maturityDate,
                legDefinition: floatLegDef,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FloatingLeg
            );

            var irs = new InterestRateSwap(
                startDate: startDate,
                maturityDate: maturityDate,
                legs: new List<InstrumentLeg>
                {
                    floatLeg,
                    fixedLeg
                },
                instrumentType: LusidInstrument.InstrumentTypeEnum.InterestRateSwap
            );
            return irs;
        }
    }
}
