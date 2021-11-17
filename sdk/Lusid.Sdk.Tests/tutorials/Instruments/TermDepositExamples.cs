using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class TermDepositExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            if (model == ModelSelection.ModelEnum.Discounting)
            {
                var upsertComplexMarketDataRequest = new Dictionary<string, UpsertComplexMarketDataRequest>
                {
                    {"discountCurve", TestDataUtilities.BuildOisCurveRequest(TestDataUtilities.EffectiveAt, "GBP")}
                };
                var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
                ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
            }
        }

        internal override LusidInstrument CreateExampleInstrument() => InstrumentExamples.CreateExampleTermDeposit(TestDataUtilities.EffectiveAt);

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode,
            string recipeCode, string instrumentID)
        {
            var termDeposit = (TermDeposit) instrument;
            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: termDeposit.StartDate.AddDays(-3),
                windowEnd: termDeposit.MaturityDate.AddDays(3),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.EqualTo(1));
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);
        }

        [LusidFeature("F22-12")]
        [Test]
        public void TermDepositCreationAndUpsertionExample()
        {
            // CREATE an example Term Deposit (that can then be upserted into LUSID)
            var termDeposit = (TermDeposit) InstrumentExamples.CreateExampleTermDeposit(TestDataUtilities.EffectiveAt);
            
            // ASSERT that it was created
            Assert.That(termDeposit, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            var uniqueId = termDeposit.InstrumentType+Guid.NewGuid().ToString(); 
            var instrumentsIds = new List<(LusidInstrument, string)>{(termDeposit, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            var upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            var getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse, uniqueId);
            
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
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
            
            // Delete Instrument 
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId); 
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney, true)]
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney, false)]
        [TestCase(ModelSelection.ModelEnum.Discounting, true)]
        [TestCase(ModelSelection.ModelEnum.Discounting, false)]
        public void TermDepositValuationExample(ModelSelection.ModelEnum model, bool inLineValuation)
        {
            CallLusidValuationEndpoint(model, inLineValuation);
        }

        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void TermDepositPortfolioCashFlowsExample(ModelSelection.ModelEnum model)
        {
            CallLusidGetPortfolioCashFlowsEndpoint(model);
        }
    }
}
