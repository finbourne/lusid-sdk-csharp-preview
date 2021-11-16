using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class FxOptionExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument fxOption)
        {
            // POPULATE with required market data for valuation of the instruments
            var upsertFxRateRequestreq = TestDataUtilities.BuildFxRateRequest(scope, TestDataUtilities.EffectiveAt);
            var upsertQuoteResponse = _quotesApi.UpsertQuotes(scope, upsertFxRateRequestreq);
            
            ValidateQuoteUpsert(upsertQuoteResponse, upsertFxRateRequestreq.Count);

            Dictionary<string, UpsertComplexMarketDataRequest> upsertComplexMarketDataRequest = new Dictionary<string, UpsertComplexMarketDataRequest>();
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
            {
                foreach (var kv in TestDataUtilities.BuildRateCurvesRequests(TestDataUtilities.EffectiveAt))
                {
                    upsertComplexMarketDataRequest.Add(kv.Key, kv.Value);
                }
            }
            if (model == ModelSelection.ModelEnum.BlackScholes)
            {
                upsertComplexMarketDataRequest.Add("VolSurface", TestDataUtilities.ConstantVolSurfaceRequest(TestDataUtilities.EffectiveAt, fxOption, model, 0.2m));
            }
            if (model == ModelSelection.ModelEnum.Bachelier)
            { 
                upsertComplexMarketDataRequest.Add("VolSurface", TestDataUtilities.ConstantVolSurfaceRequest(TestDataUtilities.EffectiveAt, fxOption, model, 10m));
            }

            var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
            ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
        }

        internal override LusidInstrument CreateExampleInstrument()
        {
            return InstrumentExamples.CreateExampleFxOption(); 
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode,
            string recipeCode, string instrumentID)
        {
            var fxOption = (FxOption) instrument;
            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: fxOption.StartDate.AddDays(-3),
                windowEnd: fxOption.OptionMaturityDate.AddDays(3),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.EqualTo(2));
            Assert.That(cashflows[1].Amount, Is.EqualTo(fxOption.Strike));
            Assert.That(cashflows[0].Amount, Is.EqualTo(1.0m));
            
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);
        }

        [Test]
        public void FxOptionCreationAndUpsertionExample()
        {
            // CREATE an Fx-Option (that can then be upserted into LUSID)
            var fxOption = (FxOption) InstrumentExamples.CreateExampleFxOption();
            
            // ASSERT that it was created
            Assert.That(fxOption, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = fxOption.InstrumentType+Guid.NewGuid().ToString(); 
            List<(LusidInstrument, string)> instrumentsIds = new List<(LusidInstrument, string)>(){(fxOption, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            UpsertInstrumentsResponse upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            GetInstrumentsResponse getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse ,uniqueId);
            
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
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
            
            // Delete Instrument 
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId); 
        }
        
        [TestCase("ConstantTimeValueOfMoney")]
        [TestCase("Discounting")]
        [TestCase("BlackScholes")]
        [TestCase("Bachelier")]
        public void FxOptionValuationExample(string modelName, bool inLineValuation = true)
        {
            ModelSelection.ModelEnum model = Enum.Parse<ModelSelection.ModelEnum>(modelName);
            CallLusidValuationEndpoint(model, inLineValuation);
        }

        [TestCase("ConstantTimeValueOfMoney")]
        [TestCase("Discounting")]
        [TestCase("BlackScholes")]
        [TestCase("Bachelier")]
        public void FxOptionPortfolioCashFlowsExample(string modelName)
        {
            var model = Enum.Parse<ModelSelection.ModelEnum>(modelName);
            CallLusidGetPortfolioCashFlowsEndpoint(model);
        }
    }
}
