using Lusid.Sdk.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lusid.Sdk.Tests.tutorials.Instruments
{
    public static class TestCaseDataGenerator
    {
        public static IEnumerable<TestCaseData> GetFXForwards()
        {
            yield return new TestCaseData("id-fxfwd-1" /*instrumentId*/, "ProperlyDefinedFXForward1" /*instrumentName*/, "01/01/2020" /*startDate*/, "01/02/2020" /*maturityDate*/, -1m /*domAmount*/, "USD" /*domCcy*/, "JPY" /*fgnCcy*/, 109m /*fxRate*/);
            yield return new TestCaseData("id-fxfwd-2" /*instrumentId*/, "ProperlyDefinedFXForward2" /*instrumentName*/, "01/02/2020" /*startDate*/, "01/04/2020" /*maturityDate*/, -1m /*domAmount*/, "USD" /*domCcy*/, "CAD" /*fgnCcy*/, 1.25m /*fxRate*/);
            yield return new TestCaseData("id-fxfwd-3" /*instrumentId*/, "ProperlyDefinedFXForward3" /*instrumentName*/, "01/04/2020" /*startDate*/, "01/07/2020" /*maturityDate*/, -1m /*domAmount*/, "USD" /*domCcy*/, "GBP" /*fgnCcy*/, 0.72m /*fxRate*/);
            yield return new TestCaseData("id-fxfwd-4" /*instrumentId*/, "ProperlyDefinedFXForward4" /*instrumentName*/, "01/07/2020" /*startDate*/, "01/11/2020" /*maturityDate*/, -1m /*domAmount*/, "USD" /*domCcy*/, "EUR" /*fgnCcy*/, 0.84m /*fxRate*/);
        }

        public static IEnumerable<TestCaseData> GetFXOptions()
        {
            yield return new TestCaseData("id-fxopt-1" /*instrumentId*/, "ProperlyDefinedFXOption1" /*instrumentName*/, "01/01/2020" /*startDate*/, "01/02/2020" /*maturityDate*/, "02/02/2020" /*settlementDate*/, "USD" /*domCcy*/, "JPY" /*fgnCcy*/, 100m /*strike*/, true /*isCallNotPut*/, true /*isDeliveryNotCash*/);
            yield return new TestCaseData("id-fxopt-2" /*instrumentId*/, "ProperlyDefinedFXOption2" /*instrumentName*/, "01/02/2020" /*startDate*/, "01/04/2020" /*maturityDate*/, "02/04/2020" /*settlementDate*/, "USD" /*domCcy*/, "JPY" /*fgnCcy*/, 100m /*strike*/, true /*isCallNotPut*/, true /*isDeliveryNotCash*/);
            yield return new TestCaseData("id-fxopt-3" /*instrumentId*/, "ProperlyDefinedFXOption3" /*instrumentName*/, "01/04/2020" /*startDate*/, "01/07/2020" /*maturityDate*/, "02/07/2020" /*settlementDate*/, "USD" /*domCcy*/, "JPY" /*fgnCcy*/, 100m /*strike*/, true /*isCallNotPut*/, true /*isDeliveryNotCash*/);
            yield return new TestCaseData("id-fxopt-4" /*instrumentId*/, "ProperlyDefinedFXOption4" /*instrumentName*/, "01/07/2020" /*startDate*/, "01/11/2020" /*maturityDate*/, "02/11/2020" /*settlementDate*/, "USD" /*domCcy*/, "JPY" /*fgnCcy*/, 100m /*strike*/, true /*isCallNotPut*/, true /*isDeliveryNotCash*/);
        }

        public static IEnumerable<TestCaseData> GetFutures()
        {
            yield return new TestCaseData("id-future-1" /*instrumentId*/, "ProperlyDefinedFuture1" /*instrumentName*/, "01/07/2020" /*startDate*/, "01/11/2020" /*maturityDate*/, "USD" /*domCcy*/, "CL" /*contractCode*/, "F" /*contractMonth*/, 42000m /*contractSize*/, "Actual365" /*convention*/, "US" /*country*/, "Crude Oil Nymex Future Jul20" /*description*/, "NYM" /*exchangeCode*/, "NYM" /*exchangeName*/, 0.01m /*tickerStep*/, 4.2m /*unitValue*/, 1m /*contracts*/, 100m /*refSpotPrice*/);
            yield return new TestCaseData("id-future-2" /*instrumentId*/, "ProperlyDefinedFuture2" /*instrumentName*/, "01/07/2020" /*startDate*/, "01/11/2020" /*maturityDate*/, "USD" /*domCcy*/, "CL" /*contractCode*/, "F" /*contractMonth*/, 42000m /*contractSize*/, "Actual365" /*convention*/, "US" /*country*/, "Crude Oil Nymex Future Jul20" /*description*/, "NYM" /*exchangeCode*/, "NYM" /*exchangeName*/, 0.01m /*tickerStep*/, 4.2m /*unitValue*/, 1m /*contracts*/, 100m /*refSpotPrice*/);
            yield return new TestCaseData("id-future-3" /*instrumentId*/, "ProperlyDefinedFuture3" /*instrumentName*/, "01/07/2020" /*startDate*/, "01/11/2020" /*maturityDate*/, "USD" /*domCcy*/, "CL" /*contractCode*/, "F" /*contractMonth*/, 42000m /*contractSize*/, "Actual365" /*convention*/, "US" /*country*/, "Crude Oil Nymex Future Jul20" /*description*/, "NYM" /*exchangeCode*/, "NYM" /*exchangeName*/, 0.01m /*tickerStep*/, 4.2m /*unitValue*/, 1m /*contracts*/, 100m /*refSpotPrice*/);
            yield return new TestCaseData("id-future-4" /*instrumentId*/, "ProperlyDefinedFuture4" /*instrumentName*/, "01/07/2020" /*startDate*/, "01/11/2020" /*maturityDate*/, "USD" /*domCcy*/, "CL" /*contractCode*/, "F" /*contractMonth*/, 42000m /*contractSize*/, "Actual365" /*convention*/, "US" /*country*/, "Crude Oil Nymex Future Jul20" /*description*/, "NYM" /*exchangeCode*/, "NYM" /*exchangeName*/, 0.01m /*tickerStep*/, 4.2m /*unitValue*/, 1m /*contracts*/, 100m /*refSpotPrice*/);
        }

        public static IEnumerable<TestCaseData> GetBonds()
        {
            yield return new TestCaseData("id-bond-1" /*instrumentId*/, "ProperlyDefinedBond1" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*maturityDate*/, "GBP" /*domCcy*/, 100m /*principal*/, 0.05m /*couponRate*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "6M" /*paymentFrequency*/, "MF" /*rollConvention*/, "Act365" /*dayCountConvention*/, 2 /*settleDays*/, 2 /*resetDays*/);
            yield return new TestCaseData("id-bond-2" /*instrumentId*/, "ProperlyDefinedBond2" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*maturityDate*/, "GBP" /*domCcy*/, 100m /*principal*/, 0.05m /*couponRate*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "6M" /*paymentFrequency*/, "MF" /*rollConvention*/, "Act365" /*dayCountConvention*/, 2 /*settleDays*/, 2 /*resetDays*/);
            yield return new TestCaseData("id-bond-3" /*instrumentId*/, "ProperlyDefinedBond3" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*maturityDate*/, "GBP" /*domCcy*/, 100m /*principal*/, 0.05m /*couponRate*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "6M" /*paymentFrequency*/, "MF" /*rollConvention*/, "Act365" /*dayCountConvention*/, 2 /*settleDays*/, 2 /*resetDays*/);
            yield return new TestCaseData("id-bond-4" /*instrumentId*/, "ProperlyDefinedBond4" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*maturityDate*/, "GBP" /*domCcy*/, 100m /*principal*/, 0.05m /*couponRate*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "6M" /*paymentFrequency*/, "MF" /*rollConvention*/, "Act365" /*dayCountConvention*/, 2 /*settleDays*/, 2 /*resetDays*/);

            // Zero coupon bonds
            yield return new TestCaseData("id-zcb-1" /*instrumentId*/, "ProperlyDefinedZeroCouponBond1" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*maturityDate*/, "GBP" /*domCcy*/, 100m /*principal*/, 0m /*couponRate*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "0Invalid" /*paymentFrequency*/, "None" /*rollConvention*/, "Invalid" /*dayCountConvention*/, 2 /*settleDays*/, 2 /*resetDays*/);
        }

        public static IEnumerable<TestCaseData> GetCDS()
        {
            yield return new TestCaseData("id-cds-1" /*instrumentId*/, "ProperlyDefinedCDS1" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*maturityDate*/, "ACME" /*ticker*/, 0.5m /*couponRate*/, "SNR" /*seniority*/, "CR" /*restructuringType*/, true /*protectStartDay*/, false /*payAccruedInterestOnDefault*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "6M" /*paymentFrequency*/, "MF" /*rollConvention*/, "Act365" /*dayCountConvention*/, "6M" /*rollFrequency*/, 2 /*settleDays*/, 2 /*resetDays*/);
            yield return new TestCaseData("id-cds-2" /*instrumentId*/, "ProperlyDefinedCDS2" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*maturityDate*/, "ACME" /*ticker*/, 0.5m /*couponRate*/, "SNR" /*seniority*/, "CR" /*restructuringType*/, true /*protectStartDay*/, false /*payAccruedInterestOnDefault*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "6M" /*paymentFrequency*/, "MF" /*rollConvention*/, "Act365" /*dayCountConvention*/, "6M" /*rollFrequency*/, 2 /*settleDays*/, 2 /*resetDays*/);
        }

        public static IEnumerable<TestCaseData> GetSwaps()
        {
            var idxConv1 = new IndexConvention(fixingReference: "", publicationDayLag: 0, paymentTenor: "6M", dayCountConvention: "Act365", currency: "GBP", scope: null, code: null);
            var flowConv1 = new FlowConventions(currency: "GBP", paymentFrequency: "6M", dayCountConvention: "Act365", rollConvention: "MF", paymentCalendars: new List<string>(), resetCalendars: new List<string>(), settleDays: 0, resetDays: 0, scope: null, code: null);
            var fixedLegDef = new LegDefinition(conventionName: null, conventions: flowConv1, indexConvention: null, indexConventionName: null, notionalExchangeType: "None", payReceive: "Pay", rateOrSpread: 0.015m, resetConvention: null, stubType: "Front");
            var floatLegDef = new LegDefinition(conventionName: null, conventions: flowConv1, indexConvention: idxConv1, indexConventionName: null, notionalExchangeType: "None", payReceive: "Receive", rateOrSpread: 0.003m, resetConvention: "InAdvance", stubType: "Front");
            var fixedLeg = new FixedLeg(startDate: DateTimeOffset.ParseExact("05/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), maturityDate: DateTimeOffset.ParseExact("05/01/2030", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), legDefinition: fixedLegDef, notional: 1000000m, overrides: null, instrumentType: LusidInstrument.InstrumentTypeEnum.FixedLeg);
            var floatLeg = new FloatingLeg(startDate: DateTimeOffset.ParseExact("05/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), maturityDate: DateTimeOffset.ParseExact("05/01/2030", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), legDefinition: floatLegDef, notional: 1000000m, overrides: null, instrumentType: LusidInstrument.InstrumentTypeEnum.FloatingLeg);
            yield return new TestCaseData("id-swap-1" /*instrumentId*/, "ProperlyDefinedSwap1" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/01/2030" /*maturityDate*/, new List<InstrumentLeg> { fixedLeg, floatLeg } /*swapLegs*/);
            yield return new TestCaseData("id-swap-2" /*instrumentId*/, "ProperlyDefinedSwap2" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/01/2030" /*maturityDate*/, new List<InstrumentLeg> { fixedLeg, floatLeg } /*swapLegs*/);
        }

        public static IEnumerable<TestCaseData> GetSwaptions()
        {
            var idxConv1 = new IndexConvention(fixingReference: "", publicationDayLag: 0, paymentTenor: "6M", dayCountConvention: "Act365", currency: "GBP", scope: null, code: null);
            var flowConv1 = new FlowConventions(currency: "GBP", paymentFrequency: "6M", dayCountConvention: "Act365", rollConvention: "MF", paymentCalendars: new List<string>(), resetCalendars: new List<string>(), settleDays: 0, resetDays: 0, scope: null, code: null);
            var fixedLegDef = new LegDefinition(conventionName: null, conventions: flowConv1, indexConvention: null, indexConventionName: null, notionalExchangeType: "None", payReceive: "Pay", rateOrSpread: 0.015m, resetConvention: null, stubType: "Front");
            var floatLegDef = new LegDefinition(conventionName: null, conventions: flowConv1, indexConvention: idxConv1, indexConventionName: null, notionalExchangeType: "None", payReceive: "Receive", rateOrSpread: 0.003m, resetConvention: "InAdvance", stubType: "Front");
            var fixedLeg = new FixedLeg(startDate: DateTimeOffset.ParseExact("05/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), maturityDate: DateTimeOffset.ParseExact("05/01/2030", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), legDefinition: fixedLegDef, notional: 1000000m, overrides: null, instrumentType: LusidInstrument.InstrumentTypeEnum.FixedLeg);
            var floatLeg = new FloatingLeg(startDate: DateTimeOffset.ParseExact("05/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), maturityDate: DateTimeOffset.ParseExact("05/01/2030", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), legDefinition: floatLegDef, notional: 1000000m, overrides: null, instrumentType: LusidInstrument.InstrumentTypeEnum.FloatingLeg);
            var swap = new InterestRateSwap(startDate: DateTimeOffset.ParseExact("05/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), maturityDate: DateTimeOffset.ParseExact("05/01/2030", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), legs: new List<InstrumentLeg> { fixedLeg, floatLeg }, instrumentType: LusidInstrument.InstrumentTypeEnum.InterestRateSwap);
            yield return new TestCaseData("id-swaption-1" /*instrumentId*/, "ProperlyDefinedSwaption1" /*instrumentName*/, "05/12/2019" /*startDate*/, "Pay" /*payOrReceiveFixed*/, "Cash" /*deliveryMethod*/, swap /*swap*/);
            yield return new TestCaseData("id-swaption-2" /*instrumentId*/, "ProperlyDefinedSwaption2" /*instrumentName*/, "15/12/2019" /*startDate*/, "Pay" /*payOrReceiveFixed*/, "Cash" /*deliveryMethod*/, swap /*swap*/);
        }

        public static IEnumerable<TestCaseData> GetEquityOptions()
        {
            yield return new TestCaseData("id-equity-option-1" /*instrumentId*/, "ProperlyDefinedEquityOption1" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*optionMaturityDate*/, "20/09/2020" /*optionSettlementDate*/, "Physical" /*deliveryType*/, "Call" /*optionType*/, 100m /*strike*/, "GBP" /*domCcy*/, "Isin" /*underlyingIdentifier*/, "code" /*code*/);
            yield return new TestCaseData("id-equity-option-2" /*instrumentId*/, "ProperlyDefinedEquityOption2" /*instrumentName*/, "07/02/2020" /*startDate*/, "18/09/2020" /*optionMaturityDate*/, "20/09/2020" /*optionSettlementDate*/, "Physical" /*deliveryType*/, "Call" /*optionType*/, 100m /*strike*/, "GBP" /*domCcy*/, "Isin" /*underlyingIdentifier*/, "code" /*code*/);
        }

        public static IEnumerable<TestCaseData> GetTermDeposits()
        {
            yield return new TestCaseData("id-term-deposit-1" /*instrumentId*/, "ProperlyDefinedTermDeposit1" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/08/2020" /*maturityDate*/, 1000000m /*contractSize*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "6M" /*paymentFrequency*/, "MF" /*rollConvention*/, "Act365" /*dayCountConvention*/, 1 /*settleDays*/, 0 /*resetDays*/, 0.03m /*rate*/);
            yield return new TestCaseData("id-term-deposit-2" /*instrumentId*/, "ProperlyDefinedTermDeposit2" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/08/2020" /*maturityDate*/, 1000000m /*contractSize*/, null /*scope*/, null /*code*/, "GBP" /*currency*/, "6M" /*paymentFrequency*/, "MF" /*rollConvention*/, "Act365" /*dayCountConvention*/, 1 /*settleDays*/, 0 /*resetDays*/, 0.03m /*rate*/);
        }

        public static IEnumerable<TestCaseData> GetContractForDifferences()
        {
            yield return new TestCaseData("id-cfd-1" /*instrumentId*/, "ProperlyDefinedCfd1"/*instrumentName*/, "05/01/2020"/*startDate*/, null /*maturityDate*/, 10m /*contractSize*/, "AMD" /*code*/, "USD"/*payCcy*/, 0m/*referenceRate*/, "Cash"/*type*/, "USD"/*underlyingCcy*/, "Isin"/*underlyingIdentifyer*/);
            yield return new TestCaseData("id-cfd-2" /*instrumentId*/, "ProperlyDefinedCfd2"/*instrumentName*/, "05/01/2020"/*startDate*/, null /*maturityDate*/, 10m /*contractSize*/, "WISE" /*code*/, "GBP"/*payCcy*/, 0m/*referenceRate*/, "Cash"/*type*/, "GBP"/*underlyingCcy*/, "Isin"/*underlyingIdentifyer*/);
        }

        public static IEnumerable<TestCaseData> GetCash()
        {
            yield return new TestCaseData("id-cash-perpetual-1" /*instrumentId*/, "ProperlyDefinedCashPerpetual1" /*instrumentName*/, "05/01/2020" /*startDate*/, "GBP" /*domCcy*/, 1000000m /*principal*/);
            yield return new TestCaseData("id-cash-perpetual-2" /*instrumentId*/, "ProperlyDefinedCashPerpetual2" /*instrumentName*/, "01/07/2020" /*startDate*/, "USD" /*domCcy*/, 500000m /*principal*/);
        }

        public static IEnumerable<TestCaseData> GetCrossCurrencySwaps()
        {
            // Pay 6M USD LIBOR, Receive 6M GBP LIBOR
            var idxConv1 = new IndexConvention(fixingReference: "", publicationDayLag: 0, paymentTenor: "6M", dayCountConvention: "Act365", currency: "USD", scope: null, code: null);
            var idxConv2 = new IndexConvention(fixingReference: "", publicationDayLag: 0, paymentTenor: "6M", dayCountConvention: "Act365", currency: "GBP", scope: null, code: null);
            var flowConv1 = new FlowConventions(currency: "USD", paymentFrequency: "6M", dayCountConvention: "Act365", rollConvention: "MF", paymentCalendars: new List<string>(), resetCalendars: new List<string>(), settleDays: 0, resetDays: 0, scope: null, code: null);
            var flowConv2 = new FlowConventions(currency: "GBP", paymentFrequency: "6M", dayCountConvention: "Act365", rollConvention: "MF", paymentCalendars: new List<string>(), resetCalendars: new List<string>(), settleDays: 0, resetDays: 0, scope: null, code: null);
            var floatLegDef1 = new LegDefinition(conventionName: null, conventions: flowConv1, indexConvention: idxConv1, indexConventionName: null, notionalExchangeType: "None", payReceive: "Pay", rateOrSpread: 0.015m, resetConvention: "InAdvance", stubType: "Front");
            var floatLegDef2 = new LegDefinition(conventionName: null, conventions: flowConv2, indexConvention: idxConv2, indexConventionName: null, notionalExchangeType: "None", payReceive: "Receive", rateOrSpread: 0.015m, resetConvention: "InAdvance", stubType: "Front");
            var floatLeg1 = new FloatingLeg(startDate: DateTimeOffset.ParseExact("05/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), maturityDate: DateTimeOffset.ParseExact("05/01/2030", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), legDefinition: floatLegDef1, notional: 1000000m, overrides: null, instrumentType: LusidInstrument.InstrumentTypeEnum.FloatingLeg);
            var floatLeg2 = new FloatingLeg(startDate: DateTimeOffset.ParseExact("05/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), maturityDate: DateTimeOffset.ParseExact("05/01/2030", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), legDefinition: floatLegDef2, notional: 1000000m, overrides: null, instrumentType: LusidInstrument.InstrumentTypeEnum.FloatingLeg);
            yield return new TestCaseData("id-cross-currency-swap1" /*instrumentId*/, "ProperlyDefinedCrossCurrencySwap1" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/08/2020" /*maturityDate*/, new List<InstrumentLeg> { floatLeg1, floatLeg2 } /*swapLegs*/);
        }

        public static IEnumerable<TestCaseData> GetRepos()
        {
            yield return new TestCaseData("id-repo-1" /*instrumentId*/, "ProperlyDefinedRepo1"/*instrumentName*/, "05/01/2020"/*startDate*/, "06/01/2020"/*maturityDate*/, "GBP"/*domCcy*/, "ActualActual"/*accrualBasis*/, 1000000m/*collateralValue*/, 0.25m/*margin*/, 0.015m/*repoRate*/);
            yield return new TestCaseData("id-repo-2" /*instrumentId*/, "ProperlyDefinedRepo2"/*instrumentName*/, "06/06/2020"/*startDate*/, "07/06/2020"/*maturityDate*/, "USD"/*domCcy*/, "ActualActual"/*accrualBasis*/, 1000000m/*collateralValue*/, 0.1m/*margin*/, 0.02m/*repoRate*/);

        }

        public static IEnumerable<TestCaseData> GetSimpleInstruments()
        {
            yield return new TestCaseData("id-simple-instrument-1"/*instrumentId*/, "ProperlyDefinedSimpleInstrument1"/*instrumentName*/, "06/01/2020"/*maturityDate*/, "GBP"/*domCcy*/, "Equities" /*assetClass*/, new List<string> { "USD" } /*fgnCcys*/, "Stock"/*simpleInstrumentType*/);
        }

        public static IEnumerable<TestCaseData> GetFXSwaps()
        {
            yield return new TestCaseData("id-fx-swap-1" /*instrumentId*/, "ProperlyDefinedFXSwap1" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/02/2020" /*nearMaturityDate*/, "05/03/2020" /*farMaturityDate*/, 1000000m /*domAmount*/, "GBP" /*domCcy*/, "USD" /*fgnCcy*/, 1.38m /*refSpotRate*/, false /*isNdf*/, "05/01/2020" /*fixingDate*/);
        }

        public static IEnumerable<TestCaseData> GetForwardRateAgreements()
        {
            yield return new TestCaseData("id-fra-1" /*instrumentId*/, "ProperlyDefinedForwardRateAgreement1" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/03/2020" /*maturityDate*/, "GBP" /*domCcy*/, "05/01/2020" /*fixingDate*/, 0.05m /*fraRate*/, 1000000m /*notional*/);
        }

        public static IEnumerable<TestCaseData> GetEquitySwaps()
        {
            // 1M USD LIBOR to AMD performance equity swap
            var equityFlowConventions = new FlowConventions(currency: "USD", paymentFrequency: "1M", dayCountConvention: "Actual365", rollConvention: "ModifiedFollowing", paymentCalendars: new List<string>(), resetCalendars: new List<string>(), settleDays: 0, resetDays: 0, scope: null, code: null);
            var idxConv1 = new IndexConvention(fixingReference: "", publicationDayLag: 0, paymentTenor: "1M", dayCountConvention: "Actual365", currency: "USD", scope: null, code: null);
            var flowConv1 = new FlowConventions(currency: "USD", paymentFrequency: "1M", dayCountConvention: "Actual365", rollConvention: "ModifiedFollowing", paymentCalendars: new List<string>(), resetCalendars: new List<string>(), settleDays: 0, resetDays: 0, scope: null, code: null);
            var fundingLegDef = new LegDefinition(conventionName: null, conventions: flowConv1, indexConvention: idxConv1, indexConventionName: null, notionalExchangeType: "None", payReceive: "Receive", rateOrSpread: 0.015m, resetConvention: "InAdvance", stubType: "ShortFront");
            var fundingLeg = new FundingLeg(startDate: DateTimeOffset.ParseExact("05/01/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), maturityDate: DateTimeOffset.ParseExact("05/01/2030", "dd/MM/yyyy", CultureInfo.InvariantCulture.DateTimeFormat), legDefinition: fundingLegDef, notional: 1000000m, instrumentType: LusidInstrument.InstrumentTypeEnum.FundingLeg);
            yield return new TestCaseData("id-equity-swap-1" /*instrumentId*/, "ProperlyDefinedEquitySwap1" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/03/2020" /*maturityDate*/, "AMD" /*code*/, equityFlowConventions /*equityFlowConventions*/, fundingLeg /*fundingLeg*/, true /*includeDividends*/, 50m /*initialPrice*/, true /*notionalReset*/, 100m /*quantity*/, "ClientInternal" /*underlyingIdentifier*/);
            yield return new TestCaseData("id-equity-swap-2" /*instrumentId*/, "ProperlyDefinedEquitySwap2" /*instrumentName*/, "05/01/2020" /*startDate*/, "05/03/2020" /*maturityDate*/, "MSFT" /*code*/, equityFlowConventions /*equityFlowConventions*/, fundingLeg /*fundingLeg*/, true /*includeDividends*/, 45m /*initialPrice*/, true /*notionalReset*/, 100m /*quantity*/, "ClientInternal" /*underlyingIdentifier*/);
        }
    }
}
