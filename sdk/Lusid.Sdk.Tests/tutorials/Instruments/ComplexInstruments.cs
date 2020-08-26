using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Features;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class ComplexInstruments
    {
        private IInstrumentsApi _instrumentsApi;

        [OneTimeSetUp]
        public void SetUp()
        {
            var apiFactory = LusidApiFactoryBuilder.Build("secrets.json");
            _instrumentsApi = apiFactory.Api<IInstrumentsApi>();
        }
        
        [LusidFeature("F37")]
        [Test]
        public void DemonstrateCreationOfFxForward()
        {
            // CREATE an Fx-Forward (that can then be upserted into LUSID)
            var usdJpyFxRate = 109m; // Assume 1 USD is worth 109m as contract is struck. USD is domestic, JPY is foreign.
            var fxForward = new FxForwardInstrument(
                domAmount: -1m,
                fgnAmount: usdJpyFxRate,
                domCcy: "USD",
                fgnCcy: "JPY",
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                maturityDate: new DateTimeOffset(2020, 9, 18, 0, 0, 0, TimeSpan.Zero),
                instrumentType: LusidInstrument.InstrumentTypeEnum.FxForward
                );

            // ASSERT that it was created
            Assert.That(fxForward, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-fxfwd-1";
            UpsertOtcToLusid(fxForward, "some-name-for-this-fxforward", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxForward);
            var retrFxFwd = retrieved as FxForwardInstrument;
            Assert.That(retrFxFwd, Is.Not.Null);
            Assert.That(retrFxFwd.DomAmount, Is.EqualTo(fxForward.DomAmount));
            Assert.That(retrFxFwd.FgnAmount, Is.EqualTo(fxForward.FgnAmount));
            Assert.That(retrFxFwd.DomCcy, Is.EqualTo(fxForward.DomCcy));
            Assert.That(retrFxFwd.FgnCcy, Is.EqualTo(fxForward.FgnCcy));
        }
        
        [LusidFeature("F38")]
        [Test]
        public void DemonstrateCreationOfSwap()
        {
            // CREATE an Interest Rate Swap (IRS) (that can then be upserted into LUSID)
            var startDate = new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero);
            var maturityDate = new DateTimeOffset(2030, 2, 7, 0, 0, 0, TimeSpan.Zero);

            // CREATE the flow conventions, index convention
            var flowConventions = new FlowConventions(
                scope: null,
                code: null,
                currency: "GBP",
                paymentFrequency: "6M",
                rollConvention: FlowConventions.RollConventionEnum.MF,
                dayCountConvention: FlowConventions.DayCountConventionEnum.Act365,
                holidayCalendars:new List<string>(),
                settleDays: 2,
                resetDays: 2
                );

            var idxConvention = new IndexConvention(
                code: "GbpLibor6m",
                publicationDayLag: 0,
                currency: "GBP",
                paymentTenor: "6M",
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
                legDefinition: fixedLegDef,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FixedRateLeg
                );

            // CREATE the floating leg
            var floatLeg = new FloatingLeg(
                notional: 100m,
                startDate: startDate,
                maturityDate: maturityDate,
                legDefinition: floatLegDef,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FloatingRateLeg
            );

            var irs = new SwapInstrument(
                startDate: startDate,
                maturityDate: maturityDate,
                legs: new List<InstrumentLeg>
                {
                    floatLeg,
                    fixedLeg
                },
                instrumentType: LusidInstrument.InstrumentTypeEnum.InterestRateSwap
            );

            // ASSERT that it was created
            Assert.That(irs, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-swap-1";
            UpsertOtcToLusid(irs, "some-name-for-this-swap", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.InterestRateSwap);
            var retrSwap = retrieved as SwapInstrument;
            Assert.That(retrSwap, Is.Not.Null);
        }
        
        private void UpsertOtcToLusid(LusidInstrument instrument, string name, string idUniqueToInstrument)
        {
            // PACKAGE instrument for upsert
            var instrumentDefinition = new LusidInstrumentDefinition(
                name: name,
                identifiers: new Dictionary<string, InstrumentIdValue>
                {
                    ["ClientInternal"] = new InstrumentIdValue(value: idUniqueToInstrument)
                },
                definition: instrument
                );

            // put instrument into Lusid
            var response = _instrumentsApi.UpsertLusidInstruments(new Dictionary<string, LusidInstrumentDefinition>
            {
                ["someId1"] = instrumentDefinition
            });

            // Check the response succeeded and has no errors.
            Assert.That(response.Failed.Count, Is.EqualTo(0));
            Assert.That(response.Values.Count, Is.EqualTo(1));
        }

        private LusidInstrument QueryOtcFromLusid(string idUniqueToInstrument)
        {
            var response = _instrumentsApi.GetLusidInstruments("ClientInternal",
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
    }
}

