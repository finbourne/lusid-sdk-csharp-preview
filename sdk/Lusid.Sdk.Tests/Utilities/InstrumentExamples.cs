using System;
using System.Collections.Generic;
using Lusid.Sdk.Model;

namespace Lusid.Sdk.Tests.Utilities
{
    public static class InstrumentExamples
    {
        private static readonly DateTimeOffset TestEffectiveAt 
            = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
        
        public static LusidInstrument GetExampleInstrument(string instrumentName)
        {
            return instrumentName switch
            {
                nameof(Bond) => CreateExampleBond(),
                nameof(FxForward) => CreateExampleFxForward(),
                nameof(FxOption) => CreateExampleFxOption(),
                nameof(InterestRateSwap) => CreateExampleSwap(),
                _ => throw new ArgumentOutOfRangeException($"Please implement case for instrument {instrumentName}")
            };
        }

        internal static LusidInstrument CreateExampleFxForward(bool isNdf = true)
            => new FxForward(
                domAmount: 1m,
                fgnAmount: -123m,
                domCcy: "USD",
                fgnCcy: "JPY",
                refSpotRate: 100m,
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                maturityDate: new DateTimeOffset(2020, 9, 18, 0, 0, 0, TimeSpan.Zero),
                fixingDate: new DateTimeOffset(2020, 8, 18, 0, 0, 0, TimeSpan.Zero),
                isNdf: isNdf,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FxForward
            );

        internal static LusidInstrument CreateExampleFxOption()
            => new FxOption(
                strike: 130,
                domCcy: "USD",
                fgnCcy: "JPY",
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                optionMaturityDate: new DateTimeOffset(2020, 12, 18, 0, 0, 0, TimeSpan.Zero),
                optionSettlementDate: new DateTimeOffset(2020, 12, 21, 0, 0, 0, TimeSpan.Zero),
                isCallNotPut: true,
                isDeliveryNotCash: true,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FxOption
            );

        private static FlowConventions CreateExampleFlowConventions()
            => new FlowConventions(
                scope: null,
                code: null,
                currency: "USD",
                paymentFrequency: "6M",
                rollConvention: "MF",
                dayCountConvention: "Act365",
                paymentCalendars: new List<string>(),
                resetCalendars: new List<string>(),
                settleDays: 2,
                resetDays: 2
            );

        internal static LusidInstrument CreateExampleBond()
            => new Bond(
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                maturityDate: new DateTimeOffset(2020, 9, 18, 0, 0, 0, TimeSpan.Zero),
                domCcy: "USD",
                principal: 100m,
                couponRate: 0.05m,
                flowConventions: CreateExampleFlowConventions(),
                identifiers: new Dictionary<string, string>(),
                instrumentType: LusidInstrument.InstrumentTypeEnum.Bond
            );

        internal static LusidInstrument CreateExampleSwap()
        {
            // CREATE an Interest Rate Swap (IRS) (that can then be upserted into LUSID)
            var startDate = TestEffectiveAt;
            var maturityDate = startDate.AddYears(3);

            // CREATE the flow conventions, index convention
            var idxConvention = new IndexConvention(
                code: "GbpLibor6m",
                publicationDayLag: 0,
                currency: "USD",
                paymentTenor: "6M",
                dayCountConvention: "Act365",
                fixingReference: "BP00"
            );

            // CREATE the leg definitions
            var fixedLegDef = new LegDefinition(
                rateOrSpread: 0.02m, // fixed leg rate (swap rate)
                stubType: "Front",
                payReceive: "Pay",
                notionalExchangeType: "None",
                conventions: CreateExampleFlowConventions()
            );

            var floatLegDef = new LegDefinition(
                rateOrSpread: 0.05m, // float leg spread over curve rate, often zero
                stubType: "Front",
                payReceive: "Pay",
                notionalExchangeType: "None",
                conventions: CreateExampleFlowConventions(),
                indexConvention: idxConvention
            );

            // CREATE the fixed leg
            var fixedLeg = new FixedLeg(
                notional: 100m,
                startDate: startDate,
                maturityDate: maturityDate,
                legDefinition: fixedLegDef,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FixedLeg
            );

            // CREATE the floating leg
            var floatLeg = new FloatingLeg(
                notional: 100m,
                startDate: startDate,
                maturityDate: maturityDate,
                legDefinition: floatLegDef,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FloatingLeg
            );

            return new InterestRateSwap(
                startDate: startDate,
                maturityDate: maturityDate,
                legs: new List<InstrumentLeg>
                {
                    floatLeg,
                    fixedLeg
                },
                instrumentType: LusidInstrument.InstrumentTypeEnum.InterestRateSwap
            );
        }
    }
}
