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
    public class EquityOptionExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument option)
        {
            var quoteRequest = TestDataUtilities.BuildQuoteRequest("ACME", QuoteSeriesId.InstrumentIdTypeEnum.RIC, 135m, "USD", TestDataUtilities.EffectiveAt);
            var upsertResponse = _quotesApi.UpsertQuotes(scope, quoteRequest);
            Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertResponse.Values.Count, Is.EqualTo(quoteRequest.Count));

            var upsertComplexMarketDataRequest = new Dictionary<string, UpsertComplexMarketDataRequest>();
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
            {
                upsertComplexMarketDataRequest.Add("discountCurve", TestDataUtilities.BuildOisCurveRequest(TestDataUtilities.EffectiveAt, "USD"));
            }
            if (model == ModelSelection.ModelEnum.BlackScholes)
            {
                upsertComplexMarketDataRequest.Add("BlackScholesVolSurface", TestDataUtilities.ConstantVolatilitySurfaceRequest(TestDataUtilities.EffectiveAt, option, model, 0.2m));
            }
            if (model == ModelSelection.ModelEnum.Bachelier)
            { 
                upsertComplexMarketDataRequest.Add("BachelierVolSurface", TestDataUtilities.ConstantVolatilitySurfaceRequest(TestDataUtilities.EffectiveAt, option, model, 10m));
            }

            if(upsertComplexMarketDataRequest.Any())
            {
                var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
                ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
            }
        }
        
        internal override void GetAndValidatePortfolioCashFlows(
            LusidInstrument instrument,
            string scope,
            string portfolioCode,
            string recipeCode,
            string instrumentID)
        {
            var option = (EquityOption) instrument;
            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: option.StartDate.AddDays(-3),
                windowEnd: option.OptionMaturityDate.AddDays(3),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.EqualTo(1));

            // CLEAN up - delete instrument and portfolio
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);
        }

        [LusidFeature("F22-11")]
        [Test]
        public void EquityOptionCreationAndUpsertionExample()
        {
            // CREATE an Equity-Option (that can then be upserted into LUSID)
            var equityOption = (EquityOption) InstrumentExamples.CreateExampleEquityOption();
            
            // ASSERT that it was created
            Assert.That(equityOption, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            var uniqueId = equityOption.InstrumentType+Guid.NewGuid().ToString(); 
            var instrumentsIds = new List<(LusidInstrument, string)>(){(equityOption, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            var upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            var getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse, uniqueId);
            
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption);
            var roundTripEquityOption = retrieved as EquityOption;
            Assert.That(roundTripEquityOption, Is.Not.Null);
            Assert.That(roundTripEquityOption.Code, Is.EqualTo(equityOption.Code));
            Assert.That(roundTripEquityOption.Strike, Is.EqualTo(equityOption.Strike));
            Assert.That(roundTripEquityOption.DeliveryType, Is.EqualTo(equityOption.DeliveryType));
            Assert.That(roundTripEquityOption.DomCcy, Is.EqualTo(equityOption.DomCcy));
            Assert.That(roundTripEquityOption.OptionType, Is.EqualTo(equityOption.OptionType));
            Assert.That(roundTripEquityOption.StartDate, Is.EqualTo(equityOption.StartDate));
            Assert.That(roundTripEquityOption.OptionMaturityDate, Is.EqualTo(equityOption.OptionMaturityDate));
            Assert.That(roundTripEquityOption.OptionSettlementDate, Is.EqualTo(equityOption.OptionSettlementDate));
            Assert.That(roundTripEquityOption.UnderlyingIdentifier, Is.EqualTo(equityOption.UnderlyingIdentifier));
            
            // DELETE instrument
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId);
        }
        
        [TestCase(ModelSelection.ModelEnum.SimpleStatic)]
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        [TestCase(ModelSelection.ModelEnum.Bachelier)]
        [TestCase(ModelSelection.ModelEnum.BlackScholes)]
        public void EquityOptionValuationExample(ModelSelection.ModelEnum model)
        {
            var equityOption = InstrumentExamples.CreateExampleEquityOption();
            CallLusidGetValuationEndpoint(equityOption, model);
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        [TestCase(ModelSelection.ModelEnum.Bachelier)]
        [TestCase(ModelSelection.ModelEnum.BlackScholes)]
        public void EquityOptionInlineValuationExample(ModelSelection.ModelEnum model)
        {
            var equityOption = InstrumentExamples.CreateExampleEquityOption();
            CallLusidInlineValuationEndpoint(equityOption, model);
        }

        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        [TestCase(ModelSelection.ModelEnum.Bachelier)]
        [TestCase(ModelSelection.ModelEnum.BlackScholes)]
        public void EquityOptionPortfolioCashFlowsExample(ModelSelection.ModelEnum model)
        {
            var equityOption = InstrumentExamples.CreateExampleEquityOption();
            CallLusidGetPortfolioCashFlowsEndpoint(equityOption, model);
        }
    }
}
