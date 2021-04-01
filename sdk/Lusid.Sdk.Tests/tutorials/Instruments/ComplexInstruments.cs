using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
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

        [Test]
        public void DemonstrateCreationOfFxForward()
        {
            // CREATE an Fx-Forward (that can then be upserted into LUSID)
            var usdJpyFxRate = 109m; // Assume 1 USD is worth 109m as contract is struck. USD is domestic, JPY is foreign.
            var fxForward = new FxForward(
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
            var retrFxFwd = retrieved as FxForward;
            Assert.That(retrFxFwd, Is.Not.Null);
            Assert.That(retrFxFwd.DomAmount, Is.EqualTo(fxForward.DomAmount));
            Assert.That(retrFxFwd.FgnAmount, Is.EqualTo(fxForward.FgnAmount));
            Assert.That(retrFxFwd.DomCcy, Is.EqualTo(fxForward.DomCcy));
            Assert.That(retrFxFwd.FgnCcy, Is.EqualTo(fxForward.FgnCcy));
        }
        
        [Test]
        public void DemonstrateCreationOfFxOption()
        {
            // CREATE an Fx-Option (that can then be upserted into LUSID)
            var fxOption = new FxOption(
                strike: 100m,
                domCcy: "USD",
                fgnCcy: "JPY",
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                optionMaturityDate: new DateTimeOffset(2020, 12, 18, 0, 0, 0, TimeSpan.Zero),
                optionSettlementDate: new DateTimeOffset(2020, 12, 21, 0, 0, 0, TimeSpan.Zero),
                isCallNotPut: true,
                isDeliveryNotCash: true,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FxOption
            );

            // ASSERT that it was created
            Assert.That(fxOption, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-fxfwd-1";
            UpsertOtcToLusid(fxOption, "some-name-for-this-fxOption", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxOption);
            var roundTripFxOption = retrieved as FxOption;
            Assert.That(roundTripFxOption, Is.Not.Null);
            Assert.That(roundTripFxOption.DomCcy, Is.EqualTo(fxOption.DomCcy));
            Assert.That(roundTripFxOption.FgnCcy, Is.EqualTo(fxOption.FgnCcy));
            Assert.That(roundTripFxOption.Strike, Is.EqualTo(fxOption.Strike));
            Assert.That(roundTripFxOption.StartDate, Is.EqualTo(fxOption.StartDate));
            Assert.That(roundTripFxOption.OptionMaturityDate, Is.EqualTo(fxOption.OptionMaturityDate));
            Assert.That(roundTripFxOption.OptionSettlementDate, Is.EqualTo(fxOption.OptionSettlementDate));
            Assert.That(roundTripFxOption.IsCallNotPut, Is.EqualTo(fxOption.IsCallNotPut));
            Assert.That(roundTripFxOption.IsDeliveryNotCash, Is.EqualTo(fxOption.IsDeliveryNotCash));
        }
        
        [Test]
        public void DemonstrateCreationOfFuture()
        {
            // CREATE an future (that can then be upserted into LUSID)
            var contractDetails = new FuturesContractDetails(
                domCcy: "USD",
                contractCode: "CL",
                contractMonth: "F",
                contractSize: 42000,
                convention: "Actual365",
                country: "US",
                description: "Crude Oil Nymex future Jan21",
                exchangeCode: "NYM",
                exchangeName: "NYM",
                tickerStep: 0.01m,
                unitValue: 4.2m
            );
            
            var futureDefinition = new Future(
                startDate: new DateTimeOffset(2020, 09, 11, 0, 0, 0, TimeSpan.Zero),
                maturityDate: new DateTimeOffset(2020, 12, 31, 0, 0, 0, TimeSpan.Zero),
                identifiers : new Dictionary<string, string>(),
                contractDetails: contractDetails,
                contracts: 1,
                refSpotPrice: 100,
                underlying: new ExoticInstrument(
                    new InstrumentDefinitionFormat("custom", "custom", "0.0.0"),
                    content: "{}",
                    LusidInstrument.InstrumentTypeEnum.ExoticInstrument),
                instrumentType: LusidInstrument.InstrumentTypeEnum.Future 
                );  
            
            // ASSERT that it was created
            Assert.That(futureDefinition, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-future-1";
            UpsertOtcToLusid(futureDefinition, "some-name-for-this-future", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.Future);
            var roundTripFuture = retrieved as Future;
            Assert.That(roundTripFuture, Is.Not.Null);
            Assert.That(roundTripFuture.StartDate, Is.EqualTo(futureDefinition.StartDate));
            Assert.That(roundTripFuture.RefSpotPrice, Is.EqualTo(futureDefinition.RefSpotPrice));
            Assert.That(roundTripFuture.MaturityDate, Is.EqualTo(futureDefinition.MaturityDate));
            Assert.That(roundTripFuture.Contracts, Is.EqualTo(futureDefinition.Contracts));
            Assert.That(roundTripFuture.ContractDetails.Description, Is.EqualTo(futureDefinition.ContractDetails.Description));
            Assert.That(roundTripFuture.ContractDetails.ContractMonth, Is.EqualTo(futureDefinition.ContractDetails.ContractMonth));
            Assert.That(roundTripFuture.Underlying.InstrumentType, Is.EqualTo(futureDefinition.Underlying.InstrumentType));
            Assert.That(roundTripFuture.Underlying.InstrumentType, Is.EqualTo(LusidInstrument.InstrumentTypeEnum.ExoticInstrument));
        }
        
        [Test]
        public void DemonstrateCreationOfBond()
        {
            // CREATE the flow conventions for bond
            var flowConventions = new FlowConventions(
                scope: null,
                code: null,
                currency: "GBP",
                paymentFrequency: "6M",
                rollConvention: "MF",
                dayCountConvention: "Act365",
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
                couponRate: 0.05m,
                flowConventions: flowConventions,
                identifiers: new Dictionary<string, string>(),
                instrumentType: LusidInstrument.InstrumentTypeEnum.Bond
            );

            // ASSERT that it was created
            Assert.That(bond, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-bond-1";
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
        
        [Test]
        public void DemonstrateCreationOfCreditDefaultSwap()
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
            string uniqueId = "id-cds-1";
            UpsertOtcToLusid(cds, "some-name-for-this-cds", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
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
        }
        

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
                rollConvention: "MF",
                dayCountConvention: "Act365",
                paymentCalendars: new List<string>(),
                resetCalendars: new List<string>(),
                settleDays: 2,
                resetDays: 2
                );

            var idxConvention = new IndexConvention(
                code: "GbpLibor6m",
                publicationDayLag: 0,
                currency: "GBP",
                paymentTenor: "6M",
                dayCountConvention: "Act365",
                fixingReference: "BP00"
            );

            // CREATE the leg definitions
            var fixedLegDef = new LegDefinition(
                rateOrSpread: 0.05m, // fixed leg rate (swap rate)
                stubType: "Front",
                payReceive: "Pay",
                notionalExchangeType: "None",
                conventions: flowConventions
            );

            var floatLegDef = new LegDefinition(
                rateOrSpread: 0.002m, // float leg spread over curve rate, often zero
                stubType: "Front",
                payReceive: "Pay",
                notionalExchangeType: "None",
                conventions: flowConventions,
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

        [Test]
        public void DemonstrateCreationOfSwaption()
        {
            // CREATE an Interest Rate Swap (IRS)
            var startDate = new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero);
            var maturityDate = new DateTimeOffset(2030, 2, 7, 0, 0, 0, TimeSpan.Zero);

            // CREATE the flow conventions, index convention for swap
            var flowConventions = new FlowConventions(
                scope: null,
                code: null,
                currency: "GBP",
                paymentFrequency: "6M",
                rollConvention: "MF",
                dayCountConvention: "Act365",
                paymentCalendars: new List<string>(),
                resetCalendars: new List<string>(),
                settleDays: 2,
                resetDays: 2
                );

            var idxConvention = new IndexConvention(
                code: "GbpLibor6m",
                publicationDayLag: 0,
                currency: "GBP",
                paymentTenor: "6M",
                dayCountConvention: "Act365",
                fixingReference: "BP00"
            );

            // CREATE the leg definitions
            var fixedLegDef = new LegDefinition(
                rateOrSpread: 0.05m, // fixed leg rate (swap rate)
                stubType: "Front",
                payReceive: "Pay",
                notionalExchangeType: "None",
                conventions: flowConventions
            );

            var floatLegDef = new LegDefinition(
                rateOrSpread: 0.002m, // float leg spread over curve rate, often zero
                stubType: "Front",
                payReceive: "Receive",
                notionalExchangeType: "None",
                conventions: flowConventions,
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

            var swap = new InterestRateSwap(
                startDate: startDate,
                maturityDate: maturityDate,
                legs: new List<InstrumentLeg>
                {
                    floatLeg,
                    fixedLeg
                },
                instrumentType: LusidInstrument.InstrumentTypeEnum.InterestRateSwap
            );
            
            // CREATE swaption to upsert to LUSID
            var swaption = new InterestRateSwaption(
                startDate: new DateTimeOffset(2020, 1, 15, 0, 0, 0, TimeSpan.Zero),
                payOrReceiveFixed: InterestRateSwaption.PayOrReceiveFixedEnum.Pay,
                deliveryMethod: InterestRateSwaption.DeliveryMethodEnum.Cash,
                swap: swap,
                instrumentType: LusidInstrument.InstrumentTypeEnum.InterestRateSwaption);

            // ASSERT that it was created
            Assert.That(swaption, Is.Not.Null);
            Assert.That(swaption.Swap, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-swaption-1";
            UpsertOtcToLusid(swaption, "some-name-for-this-swaption", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.InterestRateSwaption);
            var roundTripSwaption = retrieved as InterestRateSwaption;
            Assert.That(roundTripSwaption, Is.Not.Null);
            Assert.That(roundTripSwaption.DeliveryMethod, Is.EqualTo(swaption.DeliveryMethod));
            Assert.That(roundTripSwaption.StartDate, Is.EqualTo(swaption.StartDate));
            Assert.That(roundTripSwaption.PayOrReceiveFixed, Is.EqualTo(swaption.PayOrReceiveFixed));
            Assert.That(roundTripSwaption.Swap, Is.Not.Null);
            Assert.That(roundTripSwaption.Swap.InstrumentType, Is.EqualTo(LusidInstrument.InstrumentTypeEnum.InterestRateSwap));
        }

        [Test]
        public void DemonstrateCreationOfExotic()
        {
            // CREATE an exotic instrument (that can then be upserted into LUSID)
            var exotic = new ExoticInstrument(
                instrumentFormat: new InstrumentDefinitionFormat("source", "someVendor", "1.1"),
                content: "{\"data\":\"exoticInstrument\"}",
                instrumentType: LusidInstrument.InstrumentTypeEnum.ExoticInstrument
            );

            // ASSERT that it was created
            Assert.That(exotic, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-exotic-1";
            UpsertOtcToLusid(exotic, "some-name-for-this-exotic", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.ExoticInstrument);
            var roundTripExotic = retrieved as ExoticInstrument;
            Assert.That(roundTripExotic, Is.Not.Null);
            Assert.That(roundTripExotic.Content, Is.EqualTo(exotic.Content));
            Assert.That(roundTripExotic.InstrumentFormat, Is.EqualTo(exotic.InstrumentFormat)); 
        }
        
        [Test]
        public void DemonstrateCreationOfEquityOption()
        {
            // CREATE an exotic instrument (that can then be upserted into LUSID)
            var equityOption = new EquityOption(
                startDate: new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero),
                optionMaturityDate: new DateTimeOffset(2020, 9, 18, 0, 0, 0, TimeSpan.Zero),
                optionSettlementDate: new DateTimeOffset(2020, 9, 20, 0, 0, 0, TimeSpan.Zero),
                deliveryType: EquityOption.DeliveryTypeEnum.Physical,
                optionType: EquityOption.OptionTypeEnum.Call,
                strike: 100m,
                domCcy: "GBP",
                underlyingIdentifier: EquityOption.UnderlyingIdentifierEnum.Isin,
                code: "code",
                instrumentType: LusidInstrument.InstrumentTypeEnum.EquityOption
            );

            // ASSERT that it was created
            Assert.That(equityOption, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-equityOption-1";
            UpsertOtcToLusid(equityOption, "some-name-for-this-equityOption", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption);
            var roundTripEquityOption = retrieved as EquityOption;
            Assert.That(roundTripEquityOption, Is.Not.Null);
            Assert.That(roundTripEquityOption.Code, Is.EqualTo(roundTripEquityOption.Code));
            Assert.That(roundTripEquityOption.Strike, Is.EqualTo(roundTripEquityOption.Strike));
            Assert.That(roundTripEquityOption.DeliveryType, Is.EqualTo(roundTripEquityOption.DeliveryType));
            Assert.That(roundTripEquityOption.DomCcy, Is.EqualTo(roundTripEquityOption.DomCcy));
            Assert.That(roundTripEquityOption.OptionType, Is.EqualTo(roundTripEquityOption.OptionType));
            Assert.That(roundTripEquityOption.StartDate, Is.EqualTo(roundTripEquityOption.StartDate));
            Assert.That(roundTripEquityOption.OptionMaturityDate, Is.EqualTo(roundTripEquityOption.OptionMaturityDate));
            Assert.That(roundTripEquityOption.OptionSettlementDate, Is.EqualTo(roundTripEquityOption.OptionSettlementDate));
            Assert.That(roundTripEquityOption.UnderlyingIdentifier, Is.EqualTo(roundTripEquityOption.UnderlyingIdentifier));
        }

        [Test]
        public void DemonstrateCreationOfTermDeposit()
        {
            // CREATE a new TermDeposit
            var termDeposit = new TermDeposit(
                startDate: new DateTimeOffset(2020, 2, 5, 0, 0, 0, TimeSpan.Zero),
                maturityDate: new DateTimeOffset(2020, 8, 5, 0, 0, 0, TimeSpan.Zero),
                contractSize: 1_000_000m,
                flowConvention: new FlowConventions(
                    scope: null,
                    code: null,
                    currency: "GBP",
                    paymentFrequency: "6M",
                    rollConvention: "MF",
                    dayCountConvention: "Act365",
                    paymentCalendars: new List<string>(),
                    resetCalendars: new List<string>(),
                    settleDays: 1,
                    resetDays: 0
                ),
                rate: 0.03m,
                instrumentType: LusidInstrument.InstrumentTypeEnum.TermDeposit
            );

            // CAN NOW UPSERT TO LUSID
            string uniqueId = "id-termDeposit-1";
            UpsertOtcToLusid(termDeposit, "some-name-for-this-termDeposit", uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.TermDeposit);
            var roundTripTermDeposit = retrieved as TermDeposit;
            Assert.That(roundTripTermDeposit, Is.Not.Null);
            Assert.That(roundTripTermDeposit.ContractSize, Is.EqualTo(termDeposit.ContractSize));
            Assert.That(roundTripTermDeposit.Rate, Is.EqualTo(termDeposit.Rate));
            Assert.That(roundTripTermDeposit.StartDate, Is.EqualTo(termDeposit.StartDate));
            Assert.That(roundTripTermDeposit.MaturityDate, Is.EqualTo(termDeposit.MaturityDate));
            Assert.That(roundTripTermDeposit.FlowConvention.Currency, Is.EqualTo(termDeposit.FlowConvention.Currency));
            Assert.That(roundTripTermDeposit.FlowConvention.PaymentFrequency, Is.EqualTo(termDeposit.FlowConvention.PaymentFrequency));
            Assert.That(roundTripTermDeposit.FlowConvention.ResetDays, Is.EqualTo(termDeposit.FlowConvention.ResetDays));
            Assert.That(roundTripTermDeposit.FlowConvention.SettleDays, Is.EqualTo(termDeposit.FlowConvention.SettleDays));
            Assert.That(roundTripTermDeposit.FlowConvention.PaymentCalendars.Count, Is.EqualTo(termDeposit.FlowConvention.PaymentCalendars.Count));
            Assert.That(roundTripTermDeposit.FlowConvention.PaymentCalendars, Is.EquivalentTo(termDeposit.FlowConvention.PaymentCalendars));
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
