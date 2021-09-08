using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.tutorials.Instruments;
using Lusid.Sdk.Tests.Utilities;
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
            var apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory(@"secrets.json");
            _instrumentsApi = apiFactory.Api<IInstrumentsApi>();
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetFXForwards")]
        public void DemonstrateCreationOfFxForward(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            decimal domAmount,
            string domCcy,
            string fgnCcy, 
            decimal fxRate)
        {
            // CREATE an Fx-Forward (that can then be upserted into LUSID)
            var fxForward = new FxForward(
                domAmount: domAmount,
                fgnAmount: domAmount * fxRate * -1,
                domCcy: domCcy,
                fgnCcy: fgnCcy,
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                instrumentType: LusidInstrument.InstrumentTypeEnum.FxForward,
                refSpotRate: fxRate
                );

            // ASSERT that it was created
            Assert.That(fxForward, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(fxForward, instrumentName, uniqueId);

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

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetFXOptions")]
        public void DemonstrateCreationOfFxOption(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            string settlementDate,
            string domCcy,
            string fgnCcy,
            decimal strike,
            bool isCallNotPut,
            bool isDeliveryNotCash)
        {
            // CREATE an Fx-Option (that can then be upserted into LUSID)
            var fxOption = new FxOption(
                strike: strike,
                domCcy: domCcy,
                fgnCcy: fgnCcy,
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                optionMaturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                optionSettlementDate: DateTimeOffset.ParseExact(settlementDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                isCallNotPut: isCallNotPut,
                isDeliveryNotCash: isDeliveryNotCash,
                instrumentType: LusidInstrument.InstrumentTypeEnum.FxOption
            );

            // ASSERT that it was created
            Assert.That(fxOption, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(fxOption, instrumentName, uniqueId);

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

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetFutures")]
        public void DemonstrateCreationOfFuture(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            string domCcy,
            string contractCode,
            string contractMonth,
            decimal contractSize,
            string convention,
            string country,
            string description,
            string exchangeCode,
            string exchangeName,
            decimal tickerStep,
            decimal unitValue,
            decimal contracts,
            decimal refSpotPrice)
        {
            // CREATE an future (that can then be upserted into LUSID)
            var contractDetails = new FuturesContractDetails(
                domCcy: domCcy,
                contractCode: contractCode,
                contractMonth: contractMonth,
                contractSize: contractSize,
                convention: convention,
                country: country,
                description: description,
                exchangeCode: exchangeCode,
                exchangeName: exchangeName,
                tickerStep: tickerStep,
                unitValue: unitValue
            );
            
            var futureDefinition = new Future(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                identifiers : new Dictionary<string, string>(), //TODO: Make this configurable
                contractDetails: contractDetails,
                contracts: contracts,
                refSpotPrice: refSpotPrice,
                underlying: new ExoticInstrument( //TODO: Make this configurable
                    new InstrumentDefinitionFormat("custom", "custom", "0.0.0"),
                    content: "{}",
                    LusidInstrument.InstrumentTypeEnum.ExoticInstrument),
                instrumentType: LusidInstrument.InstrumentTypeEnum.Future 
                );  
            
            // ASSERT that it was created
            Assert.That(futureDefinition, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(futureDefinition, instrumentName, uniqueId);

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

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetBonds")]
        public void DemonstrateCreationOfBond(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            string domCcy,
            decimal principal,
            decimal couponRate,
            string scope,
            string code,
            string currency,
            string paymentFrequency,
            string rollConvention,
            string dayCountConvention,
            int settleDays,
            int resetDays)
        {
            // CREATE the flow conventions for bond
            var flowConventions = new FlowConventions(
                scope: scope,
                code: code,
                currency: currency,
                paymentFrequency: paymentFrequency,
                rollConvention: rollConvention,
                dayCountConvention: dayCountConvention,
                paymentCalendars:new List<string>(),//TODO: Make this configurable
                resetCalendars:new List<string>(),//TODO: Make this configurable
                settleDays: settleDays,
                resetDays: resetDays
            );

            var bond = new Bond(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                domCcy: domCcy,
                principal: principal,
                couponRate: couponRate,
                flowConventions: flowConventions,
                identifiers: new Dictionary<string, string>(),//TODO: Make this configurable
                instrumentType: LusidInstrument.InstrumentTypeEnum.Bond
            );

            // ASSERT that it was created
            Assert.That(bond, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(bond,instrumentName, uniqueId);

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

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetCDS")]
        public void DemonstrateCreationOfCreditDefaultSwap(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            string ticker,
            decimal couponRate,
            string seniority,
            string restructuringType,
            bool protectStartDay,
            bool payAccruedInterestOnDefault,
            string scope,
            string code,
            string currency,
            string paymentFrequency,
            string rollConvention,
            string dayCountConvention,
            string rollFrequency,
            int settleDays,
            int resetDays)
        {
            // CREATE the cds flow conventions for credit default swap
            var cdsFlowConventions = new CdsFlowConventions(
                scope: scope,
                code: code,
                currency: currency,
                paymentFrequency: paymentFrequency,
                rollConvention: rollConvention,
                dayCountConvention: dayCountConvention,
                paymentCalendars: new List<string>(),//TODO: Make this configurable
                resetCalendars: new List<string>(),//TODO: Make this configurable
                rollFrequency: rollFrequency,
                settleDays: settleDays,
                resetDays: resetDays
            );
            
            var cdsProtectionDetailSpecification = new CdsProtectionDetailSpecification(
                seniority: (CdsProtectionDetailSpecification.SeniorityEnum)Enum.Parse(
                    typeof(CdsProtectionDetailSpecification.SeniorityEnum), seniority),
                restructuringType: (CdsProtectionDetailSpecification.RestructuringTypeEnum)Enum.Parse(
                    typeof(CdsProtectionDetailSpecification.RestructuringTypeEnum), restructuringType),
                protectStartDay: protectStartDay,
                payAccruedInterestOnDefault: payAccruedInterestOnDefault);

            var cds = new CreditDefaultSwap(
                ticker: ticker,
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                flowConventions: cdsFlowConventions,
                couponRate: couponRate,
                protectionDetailSpecification: cdsProtectionDetailSpecification,
                instrumentType: LusidInstrument.InstrumentTypeEnum.CreditDefaultSwap
            );
            // ASSERT that it was created
            Assert.That(cds, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(cds, instrumentName, uniqueId);

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

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetSwaps")]
        public void DemonstrateCreationOfSwap(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            List<InstrumentLeg> legs)
        {
            // CREATE an Interest Rate Swap (IRS) (that can then be upserted into LUSID)
            var irs = new InterestRateSwap(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                legs: legs,
                instrumentType: LusidInstrument.InstrumentTypeEnum.InterestRateSwap
            );

            // ASSERT that it was created
            Assert.That(irs, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(irs, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.InterestRateSwap);
            var retrSwap = retrieved as InterestRateSwap;
            Assert.That(retrSwap, Is.Not.Null);
            Assert.That(retrSwap.MaturityDate, Is.EqualTo(irs.MaturityDate));
            Assert.That(retrSwap.StartDate, Is.EqualTo(irs.StartDate));
            Assert.That(retrSwap.Legs.Count, Is.EqualTo(irs.Legs.Count));
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetSwaptions")]
        [Ignore("TODO: The upserting of these swaptions cause 500 errors")]
        public void DemonstrateCreationOfSwaption(
            string instrumentId,
            string instrumentName,
            string swaptionStartDate,
            string payOrReceiveFixed,
            string deliveryMethod,
            InterestRateSwap swap)
        {
            // CREATE swaption to upsert to LUSID
            var swaption = new InterestRateSwaption(
                startDate: DateTimeOffset.ParseExact(swaptionStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                payOrReceiveFixed: (InterestRateSwaption.PayOrReceiveFixedEnum)
                    Enum.Parse(
                        typeof(InterestRateSwaption.PayOrReceiveFixedEnum),
                        payOrReceiveFixed),
                deliveryMethod: (InterestRateSwaption.DeliveryMethodEnum)
                    Enum.Parse(
                        typeof(InterestRateSwaption.DeliveryMethodEnum),
                        deliveryMethod),
                swap: swap,
                instrumentType: LusidInstrument.InstrumentTypeEnum.InterestRateSwaption);

            // ASSERT that it was created
            Assert.That(swaption, Is.Not.Null);
            Assert.That(swaption.Swap, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(swaption, instrumentName, uniqueId);

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

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetEquityOptions")]
        public void DemonstrateCreationOfEquityOption(
            string instrumentId,
            string instrumentName,
            string startDate,
            string optionMaturityDate,
            string optionSettlementDate,
            string deliveryType,
            string optionType,
            decimal strike,
            string domCcy,
            string underlyingIdentifier,
            string code)
        {
            // CREATE an exotic instrument (that can then be upserted into LUSID)
            var equityOption = new EquityOption(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                optionMaturityDate: DateTimeOffset.ParseExact(optionMaturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                optionSettlementDate: DateTimeOffset.ParseExact(optionSettlementDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                deliveryType: (EquityOption.DeliveryTypeEnum)
                    Enum.Parse(
                        typeof(EquityOption.DeliveryTypeEnum),
                        deliveryType),
                optionType: (EquityOption.OptionTypeEnum)
                    Enum.Parse(
                        typeof(EquityOption.OptionTypeEnum),
                        optionType),
                strike: strike,
                domCcy: domCcy,
                underlyingIdentifier: (EquityOption.UnderlyingIdentifierEnum)
                    Enum.Parse(
                        typeof(EquityOption.UnderlyingIdentifierEnum),
                        underlyingIdentifier),
                code: code,
                instrumentType: LusidInstrument.InstrumentTypeEnum.EquityOption
            );

            // ASSERT that it was created
            Assert.That(equityOption, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(equityOption, instrumentName, uniqueId);

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

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetTermDeposits")]
        public void DemonstrateCreationOfTermDeposit(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            decimal contractSize,
            string scope,
            string code,
            string currency,
            string paymentFrequency,
            string rollConvention,
            string dayCountConvention,
            int settleDays,
            int resetDays,
            decimal rate)
        {
            // CREATE a new TermDeposit
            var termDeposit = new TermDeposit(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                contractSize: contractSize,
                flowConvention: new FlowConventions(
                    scope: scope,
                    code: code,
                    currency: currency,
                    paymentFrequency: paymentFrequency,
                    rollConvention: rollConvention,
                    dayCountConvention: dayCountConvention,
                    paymentCalendars: new List<string>(),
                    resetCalendars: new List<string>(),
                    settleDays: settleDays,
                    resetDays: resetDays
                ),
                rate: rate,
                instrumentType: LusidInstrument.InstrumentTypeEnum.TermDeposit
            );

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(termDeposit, instrumentName, uniqueId);

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

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetContractForDifferences")]
        public void DemonstrateCreationOfContractForDifference(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            decimal contractSize,
            string code,
            string payCcy,
            decimal referenceRate,
            string type,
            string underlyingCcy,
            string underlyingIdentifyer)
        {
            // CREATE a new contract for difference
            var cfd = new ContractForDifference(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: maturityDate != null ? DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat) : DateTimeOffset.MaxValue,
                code: code,
                contractSize: contractSize,
                payCcy: payCcy,
                referenceRate: referenceRate,
                type: type,
                underlyingCcy: underlyingCcy,
                underlyingIdentifier: underlyingIdentifyer,
                instrumentType: LusidInstrument.InstrumentTypeEnum.ContractForDifference);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(cfd, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.ContractForDifference);
            var roundTripCfd = retrieved as ContractForDifference;
            Assert.That(roundTripCfd, Is.Not.Null);
            Assert.That(roundTripCfd.StartDate, Is.EqualTo(cfd.StartDate));
            Assert.That(roundTripCfd.MaturityDate, Is.EqualTo(cfd.MaturityDate));
            Assert.That(roundTripCfd.Code, Is.EqualTo(cfd.Code));
            Assert.That(roundTripCfd.ContractSize, Is.EqualTo(cfd.ContractSize));
            Assert.That(roundTripCfd.PayCcy, Is.EqualTo(cfd.PayCcy));
            Assert.That(roundTripCfd.ReferenceRate, Is.EqualTo(cfd.ReferenceRate));
            Assert.That(roundTripCfd.Type, Is.EqualTo(cfd.Type));
            Assert.That(roundTripCfd.UnderlyingCcy, Is.EqualTo(cfd.UnderlyingCcy));
            Assert.That(roundTripCfd.UnderlyingIdentifier, Is.EqualTo(cfd.UnderlyingIdentifier));
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetCash")]
        [Ignore("The CashPerpetual instrument cannot be upserted like this right now")]
        public void DemonstrateCreationOfCash(
            string instrumentId,
            string instrumentName,
            string startDate,
            string domCcy,
            decimal principal)
        {
            // CREATE a new cash instrument
            var cash = new CashPerpetual(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                domCcy: domCcy,
                principal: principal,
                LusidInstrument.InstrumentTypeEnum.CashPerpetual);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(cash, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.CashPerpetual);
            var roundTripCash = retrieved as CashPerpetual;
            Assert.That(roundTripCash, Is.Not.Null);
            Assert.That(roundTripCash.StartDate, Is.EqualTo(cash.StartDate));
            Assert.That(roundTripCash.DomCcy, Is.EqualTo(cash.DomCcy));
            Assert.That(roundTripCash.Principal, Is.EqualTo(cash.Principal));
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetCrossCurrencySwaps")]
        public void DemonstrateCreationOfCrossCurrencySwap(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            List<InstrumentLeg> swapLegs)
        {
            // CREATE a new cross currency swap
            var ccs = new CrossCurrencySwap(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: maturityDate != null ? DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat) : DateTimeOffset.MaxValue,
                legs: swapLegs,
                instrumentType: LusidInstrument.InstrumentTypeEnum.CrossCurrencySwap);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(ccs, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.CrossCurrencySwap);
            var roundTripCcs = retrieved as CrossCurrencySwap;
            Assert.That(roundTripCcs, Is.Not.Null);
            Assert.That(roundTripCcs.StartDate, Is.EqualTo(ccs.StartDate));
            Assert.That(roundTripCcs.MaturityDate, Is.EqualTo(ccs.MaturityDate));
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetRepos")]
        public void DemonstrateCreationOfRepo(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            string domCcy,
            string accrualBasis,
            decimal collateralValue,
            decimal margin,
            decimal repoRate)
        {
            // CREATE a new repo
            var repo = new Repo(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                domCcy: domCcy,
                accrualBasis: accrualBasis,
                collateralValue: collateralValue,
                margin: margin,
                repoRate: repoRate,
                instrumentType: LusidInstrument.InstrumentTypeEnum.Repo);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(repo, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.Repo);
            var roundsTripRepo = retrieved as Repo;
            Assert.That(roundsTripRepo, Is.Not.Null);
            Assert.That(roundsTripRepo.StartDate, Is.EqualTo(repo.StartDate));
            Assert.That(roundsTripRepo.MaturityDate, Is.EqualTo(repo.MaturityDate));
            Assert.That(roundsTripRepo.DomCcy, Is.EqualTo(repo.DomCcy));
            Assert.That(roundsTripRepo.AccrualBasis, Is.EqualTo(repo.AccrualBasis));
            Assert.That(roundsTripRepo.CollateralValue, Is.EqualTo(repo.CollateralValue));
            Assert.That(roundsTripRepo.Margin, Is.EqualTo(repo.Margin));
            Assert.That(roundsTripRepo.RepoRate, Is.EqualTo(repo.RepoRate));
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetSimpleInstruments")]
        public void DemonstrateCreationOfSimpleInstrument(
            string instrumentId,
            string instrumentName,
            string maturityDate,
            string domCcy,
            string assetClass,
            List<string> fgnCcys,
            string simpleInstrumentType)
        {
            // CREATE a new simple instrument
            var simpleInstrument = new SimpleInstrument(
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                domCcy: domCcy,
                assetClass: (SimpleInstrument.AssetClassEnum)Enum.Parse(typeof(SimpleInstrument.AssetClassEnum), assetClass),
                fgnCcys: fgnCcys,
                simpleInstrumentType: simpleInstrumentType,
                instrumentType: LusidInstrument.InstrumentTypeEnum.SimpleInstrument);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(simpleInstrument, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.SimpleInstrument);
            var roundsTripSimpleInstrument = retrieved as SimpleInstrument;
            Assert.That(roundsTripSimpleInstrument, Is.Not.Null);
            Assert.That(roundsTripSimpleInstrument.MaturityDate, Is.EqualTo(simpleInstrument.MaturityDate));
            Assert.That(roundsTripSimpleInstrument.DomCcy, Is.EqualTo(simpleInstrument.DomCcy));
            Assert.That(roundsTripSimpleInstrument.AssetClass, Is.EqualTo(simpleInstrument.AssetClass));
            Assert.True(roundsTripSimpleInstrument.FgnCcys.SequenceEqual(simpleInstrument.FgnCcys));
            Assert.That(roundsTripSimpleInstrument.SimpleInstrumentType, Is.EqualTo(simpleInstrument.SimpleInstrumentType));
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetFXSwaps")]
        public void DemonstrateCreationOfFXSwap(
            string instrumentId,
            string instrumentName,
            string startDate,
            string nearMaturityDate,
            string farMaturityDate,
            decimal domAmount,
            string domCcy,
            string fgnCcy,
            decimal refSpotRate,
            bool isNdf,
            string fixingDate)
        {
            var nearFXForward = new FxForward(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(nearMaturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                domAmount: domAmount,
                domCcy: domCcy,
                fgnAmount: domAmount * refSpotRate * -1,
                fgnCcy: fgnCcy,
                refSpotRate: refSpotRate,
                isNdf: isNdf,
                fixingDate: DateTimeOffset.ParseExact(fixingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                instrumentType: LusidInstrument.InstrumentTypeEnum.FxForward);

            var farFXForward = new FxForward(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(farMaturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                domAmount: domAmount,
                domCcy: domCcy,
                fgnAmount: domAmount * refSpotRate * -1,
                fgnCcy: fgnCcy,
                refSpotRate: refSpotRate,
                isNdf: isNdf,
                fixingDate: DateTimeOffset.ParseExact(fixingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                instrumentType: LusidInstrument.InstrumentTypeEnum.FxForward);

            // CREATE a new fx swap
            var fxSwap = new FxSwap(nearFXForward, farFXForward, instrumentType: LusidInstrument.InstrumentTypeEnum.FxSwap);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(fxSwap, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxSwap);
            var roundTripFXSwap = retrieved as FxSwap;
            Assert.That(roundTripFXSwap, Is.Not.Null);
            Assert.That(roundTripFXSwap.NearFxForward.DomAmount, Is.EqualTo(fxSwap.NearFxForward.DomAmount));
            Assert.That(roundTripFXSwap.NearFxForward.DomCcy, Is.EqualTo(fxSwap.NearFxForward.DomCcy));
            Assert.That(roundTripFXSwap.NearFxForward.FgnAmount, Is.EqualTo(fxSwap.NearFxForward.FgnAmount));
            Assert.That(roundTripFXSwap.NearFxForward.FgnCcy, Is.EqualTo(fxSwap.NearFxForward.FgnCcy));
            Assert.That(roundTripFXSwap.NearFxForward.RefSpotRate, Is.EqualTo(fxSwap.NearFxForward.RefSpotRate));
            Assert.That(roundTripFXSwap.NearFxForward.IsNdf, Is.EqualTo(fxSwap.NearFxForward.IsNdf));
            Assert.That(roundTripFXSwap.NearFxForward.FixingDate, Is.EqualTo(fxSwap.NearFxForward.FixingDate));
            Assert.That(roundTripFXSwap.FarFxForward.DomAmount, Is.EqualTo(fxSwap.FarFxForward.DomAmount));
            Assert.That(roundTripFXSwap.FarFxForward.DomCcy, Is.EqualTo(fxSwap.FarFxForward.DomCcy));
            Assert.That(roundTripFXSwap.FarFxForward.FgnAmount, Is.EqualTo(fxSwap.FarFxForward.FgnAmount));
            Assert.That(roundTripFXSwap.FarFxForward.FgnCcy, Is.EqualTo(fxSwap.FarFxForward.FgnCcy));
            Assert.That(roundTripFXSwap.FarFxForward.RefSpotRate, Is.EqualTo(fxSwap.FarFxForward.RefSpotRate));
            Assert.That(roundTripFXSwap.FarFxForward.IsNdf, Is.EqualTo(fxSwap.FarFxForward.IsNdf));
            Assert.That(roundTripFXSwap.FarFxForward.FixingDate, Is.EqualTo(fxSwap.FarFxForward.FixingDate));
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetForwardRateAgreements")]
        public void DemonstrateCreationOfForwardRateAgreement(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            string domCcy,
            string fixingDate,
            decimal fraRate,
            decimal notional)
        {
            // CREATE a new forward rate agreement
            var fra = new ForwardRateAgreement(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                domCcy: domCcy,
                fixingDate: DateTimeOffset.ParseExact(fixingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                fraRate: fraRate,
                notional: notional,
                instrumentType: LusidInstrument.InstrumentTypeEnum.ForwardRateAgreement);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(fra, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.ForwardRateAgreement);
            var roundTripFra = retrieved as ForwardRateAgreement;
            Assert.That(roundTripFra, Is.Not.Null);
            Assert.That(roundTripFra.DomCcy, Is.EqualTo(fra.DomCcy));
            Assert.That(roundTripFra.FixingDate, Is.EqualTo(fra.FixingDate));
            Assert.That(roundTripFra.FraRate, Is.EqualTo(fra.FraRate));
            Assert.That(roundTripFra.Notional, Is.EqualTo(fra.Notional));
        }

        [Test, TestCaseSource(typeof(TestCaseDataGenerator), "GetEquitySwaps")]
        public void DemonstrateCreationOfEquitySwap(
            string instrumentId,
            string instrumentName,
            string startDate,
            string maturityDate,
            string code,
            FlowConventions equityFlowConventions,
            InstrumentLeg fundingLeg,
            bool includeDividends,
            decimal initialPrice,
            bool notionalReset,
            decimal quantity,
            string underlyingIdentifier)
        {
            // CREATE a new equity swap
            var equitySwap = new EquitySwap(
                startDate: DateTimeOffset.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                maturityDate: DateTimeOffset.ParseExact(maturityDate, "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat),
                code: code,
                equityFlowConventions: equityFlowConventions,
                fundingLeg: fundingLeg,
                includeDividends: includeDividends,
                initialPrice: initialPrice,
                notionalReset: notionalReset,
                quantity: quantity,
                underlyingIdentifier: underlyingIdentifier,
                instrumentType: LusidInstrument.InstrumentTypeEnum.EquitySwap);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = instrumentId;
            UpsertOtcToLusid(equitySwap, instrumentName, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquitySwap);
            var roundTripEquitySwap = retrieved as EquitySwap;
            Assert.That(roundTripEquitySwap, Is.Not.Null);
            Assert.That(roundTripEquitySwap.Code, Is.EqualTo(equitySwap.Code));
            Assert.That(roundTripEquitySwap.EquityFlowConventions, Is.EqualTo(equitySwap.EquityFlowConventions));
            Assert.That(roundTripEquitySwap.FundingLeg, Is.EqualTo(equitySwap.FundingLeg));
            Assert.That(roundTripEquitySwap.IncludeDividends, Is.EqualTo(equitySwap.IncludeDividends));
            Assert.That(roundTripEquitySwap.InitialPrice, Is.EqualTo(equitySwap.InitialPrice));
            Assert.That(roundTripEquitySwap.NotionalReset, Is.EqualTo(equitySwap.NotionalReset));
            Assert.That(roundTripEquitySwap.Quantity, Is.EqualTo(equitySwap.Quantity));
            Assert.That(roundTripEquitySwap.UnderlyingIdentifier, Is.EqualTo(equitySwap.UnderlyingIdentifier));
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
    }
}
