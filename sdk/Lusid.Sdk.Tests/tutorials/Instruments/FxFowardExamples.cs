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
    public class FxFowardExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            // POPULATE with required market data for valuation of the instruments
            var upsertFxRateRequestReq = TestDataUtilities.BuildFxRateRequest(scope, TestDataUtilities.EffectiveAt);
            var upsertQuoteResponse = _quotesApi.UpsertQuotes(scope, upsertFxRateRequestReq);
            ValidateQuoteUpsert(upsertQuoteResponse, upsertFxRateRequestReq.Count);

            if (model == ModelSelection.ModelEnum.Discounting)
            {
                var upsertComplexMarketDataRequest =  TestDataUtilities.BuildRateCurvesRequests(TestDataUtilities.EffectiveAt);
                var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
                ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
            }
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID)
        {
            var fxForward = (FxForward) instrument;
            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: new DateTimeOrCutLabel(new DateTimeOffset(2000, 01, 01, 01, 0, 0, 0, TimeSpan.Zero)),
                windowEnd: new DateTimeOrCutLabel(new DateTimeOffset(2050, 01, 01, 01, 0, 0, 0, TimeSpan.Zero)),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.EqualTo(fxForward.IsNdf ? 1 : 2)); // deliverable FxForward has 2 cashflows while non-delivered has 1.
            
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);
        }

        [LusidFeature("F22-1")]
        [Test]
        public void FxForwardCreationAndUpsertionExample()
        {
            // CREATE an FxForward instrument (that can then be upserted into LUSID)
            var fxForward = (FxForward) InstrumentExamples.CreateExampleFxForward();

            // ASSERT that it was created
            Assert.That(fxForward, Is.Not.Null);
            
            // CAN NOW UPSERT TO LUSID
            var uniqueId = fxForward.InstrumentType+Guid.NewGuid().ToString(); 
            var instrumentsIds = new List<(LusidInstrument, string)>{(fxForward, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            UpsertInstrumentsResponse upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            GetInstrumentsResponse getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse ,uniqueId);
            
            // CHECK contents
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxForward);
            var retrFxFwd = retrieved as FxForward;
            Assert.That(retrFxFwd, Is.Not.Null);
            Assert.That(retrFxFwd.DomAmount, Is.EqualTo(fxForward.DomAmount));
            Assert.That(retrFxFwd.FgnAmount, Is.EqualTo(fxForward.FgnAmount));
            Assert.That(retrFxFwd.DomCcy, Is.EqualTo(fxForward.DomCcy));
            Assert.That(retrFxFwd.FgnCcy, Is.EqualTo(fxForward.FgnCcy));
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void FxForwardValuationExample(ModelSelection.ModelEnum model)
        {
            var fxForward = InstrumentExamples.CreateExampleFxForward();
            CallLusidGetValuationEndpoint(fxForward, model);
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void FxForwardInlineValuationExample(ModelSelection.ModelEnum model)
        {
            var fxForward = InstrumentExamples.CreateExampleFxForward();
            CallLusidInlineValuationEndpoint(fxForward, model);
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void FxForwardPortfolioCashFlowsExample(ModelSelection.ModelEnum model)
        {
            var fxForward = InstrumentExamples.CreateExampleFxForward();
            CallLusidGetPortfolioCashFlowsEndpoint(fxForward, model);
        }
    }
}
