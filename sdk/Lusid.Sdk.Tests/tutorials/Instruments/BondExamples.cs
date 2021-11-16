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
    public class BondExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument fxOption)
        {
            Dictionary<string, UpsertComplexMarketDataRequest> upsertComplexMarketDataRequest = new Dictionary<string, UpsertComplexMarketDataRequest>();
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
            {
                upsertComplexMarketDataRequest.Add("discountCurve", TestDataUtilities.BuildOisCurveRequest(TestDataUtilities.EffectiveAt, "USD"));
            }

            var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
            ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
        }

        internal override LusidInstrument CreateExampleInstrument() => InstrumentExamples.CreateExampleBond();

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode,
            string recipeCode, string instrumentID)
        {
            var bond = (Bond) instrument;
            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: bond.StartDate.AddDays(-3),
                windowEnd: bond.MaturityDate.AddDays(3),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.EqualTo(2));
            
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);
        }

        [LusidFeature("F22-4")]
        [Test]
        public void BondCreationAndUpsertionExample()
        {
            // CREATE a Bond (that can then be upserted into LUSID)
            var bond = (Bond) InstrumentExamples.CreateExampleBond();
            
            // ASSERT that it was created
            Assert.That(bond, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = bond.InstrumentType+Guid.NewGuid().ToString(); 
            List<(LusidInstrument, string)> instrumentsIds = new List<(LusidInstrument, string)>{(bond, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            UpsertInstrumentsResponse upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            GetInstrumentsResponse getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse ,uniqueId);
            
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxOption);
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
            
            // Delete Instrument 
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId); 
        }
        
        [TestCase("ConstantTimeValueOfMoney")]
        [TestCase("Discounting")]
        public void BondValuationExample(string modelName, bool inLineValuation = true)
        {
            ModelSelection.ModelEnum model = Enum.Parse<ModelSelection.ModelEnum>(modelName);
            CallLusidValuationEndpoint(model, inLineValuation);
        }

        [TestCase("ConstantTimeValueOfMoney")]
        [TestCase("Discounting")]
        public void BondPortfolioCashFlowsExample(string modelName)
        {
            var model = Enum.Parse<ModelSelection.ModelEnum>(modelName);
            CallLusidGetPortfolioCashFlowsEndpoint(model);
        }
    }
}
