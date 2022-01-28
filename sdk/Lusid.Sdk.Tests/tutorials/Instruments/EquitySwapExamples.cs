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
    public class EquitySwapExamples: DemoInstrumentBase
    {
        /// <inheritdoc />
        protected override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            // UPSERT quote for pricing of the equity swap. In particular we upsert a quote for the equity underlying. 
            var equitySwap = InstrumentExamples.CreateExampleEquitySwap();
            var quoteRequest = TestDataUtilities.BuildQuoteRequest(
                equitySwap.Code,
                QuoteSeriesId.InstrumentIdTypeEnum.Figi,
                135m,
                "USD",
                TestDataUtilities.EffectiveAt);
            var upsertResponse = _quotesApi.UpsertQuotes(scope, quoteRequest);
            Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertResponse.Values.Count, Is.EqualTo(quoteRequest.Count));
            
            // Upsert discounting curves
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
            {
                var upsertComplexMarketDataRequest = TestDataUtilities.BuildRateCurvesRequests(TestDataUtilities.EffectiveAt);
                var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
                ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
            }
        }

        /// <inheritdoc />
        protected override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID)
        {
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
            
            Assert.That(cashflows.Count, Is.EqualTo(2));
        }

        [LusidFeature("F5-10")]
        [Test]
        public void EquitySwapCreationAndUpsertionExample()
        {
            // CREATE an equitySwap instrument (that can then be upserted into LUSID)
            var equitySwap = InstrumentExamples.CreateExampleEquitySwap();

            // ASSERT that it was created
            Assert.That(equitySwap, Is.Not.Null);
            
            // CAN NOW UPSERT TO LUSID
            var uniqueId = equitySwap.InstrumentType + Guid.NewGuid().ToString(); 
            var instrumentsIds = new List<(LusidInstrument, string)>{(equitySwap, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            var upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            GetInstrumentsResponse getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse ,uniqueId);
            
            // CHECK contents
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquitySwap);
            var roundTripEquitySwap = retrieved as EquitySwap;
            Assert.That(roundTripEquitySwap, Is.Not.Null);
            Assert.That(roundTripEquitySwap.StartDate, Is.EqualTo(equitySwap.StartDate));
            Assert.That(roundTripEquitySwap.MaturityDate, Is.EqualTo(equitySwap.MaturityDate));
            Assert.That(roundTripEquitySwap.Quantity, Is.EqualTo(equitySwap.Quantity));
            Assert.That(roundTripEquitySwap.Code, Is.EqualTo(equitySwap.Code));
            Assert.That(roundTripEquitySwap.IncludeDividends, Is.EqualTo(equitySwap.IncludeDividends));
            Assert.That(roundTripEquitySwap.EquityFlowConventions.Code, Is.EqualTo(equitySwap.EquityFlowConventions.Code));
            Assert.That(roundTripEquitySwap.InitialPrice, Is.EqualTo(equitySwap.InitialPrice));
            Assert.That(roundTripEquitySwap.FundingLeg.InstrumentType, Is.EqualTo(equitySwap.FundingLeg.InstrumentType));
            Assert.That(roundTripEquitySwap.NotionalReset, Is.EqualTo(equitySwap.NotionalReset));
            Assert.That(roundTripEquitySwap.UnderlyingIdentifier, Is.EqualTo(equitySwap.UnderlyingIdentifier));
            
            // DELETE instrument 
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId); 
        }
        
        [LusidFeature("F22-40")]
        [TestCase(ModelSelection.ModelEnum.SimpleStatic)]
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void EquitySwapValuationExample(ModelSelection.ModelEnum model)
        {
            var equitySwap = InstrumentExamples.CreateExampleEquitySwap();
            CallLusidGetValuationEndpoint(equitySwap, model);
        }
        
        [LusidFeature("F22-41")]
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void EquitySwapInlineValuationExample(ModelSelection.ModelEnum model)
        {
            var equitySwap = InstrumentExamples.CreateExampleEquitySwap();
            CallLusidInlineValuationEndpoint(equitySwap, model);
        }
        
        [LusidFeature("F22-42")]
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void EquitySwapPortfolioCashFlowsExample(ModelSelection.ModelEnum model)
        {
            var equitySwap = InstrumentExamples.CreateExampleEquitySwap();
            CallLusidGetPortfolioCashFlowsEndpoint(equitySwap, model);
        }
        
        [LusidFeature("F22-40")] //todo-jz
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void EquitySwapValuationExampleWithExposureAndAccruedInterest(ModelSelection.ModelEnum model)
        {
            var equitySwap = InstrumentExamples.CreateExampleEquitySwap();
            
            // CREATE portfolio and add instrument to the portfolio
            var scope = Guid.NewGuid().ToString();
            var (instrumentID, portfolioCode) = CreatePortfolioAndInstrument(scope, equitySwap);

            // UPSERT EquitySwap to portfolio and populating stores with required market data.
            CreateAndUpsertMarketDataToLusid(scope, model, equitySwap);
            
            // CREATE recipe to price the portfolio with
            var recipeCode = CreateAndUpsertRecipe(scope, model);

            // CREATE valuation request for this portfolio consisting of the instrument
            var accruedInterestKey = "Instrument/CashFlows/AccruedInterest";
            var accruedInterestKeyForSpecificInstrument = "Instrument/OTC/EquitySwap/AccruedInterest";
            var exposureKey = "Valuation/Exposure"; 
            var exposureAndAccruedKeys = new List<string>
            {
                accruedInterestKey,
                accruedInterestKeyForSpecificInstrument,
                exposureKey,
            };
            var valuationRequest = TestDataUtilities.CreateValuationRequest(
                scope,
                portfolioCode,
                recipeCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                additionalRequestsKeys: exposureAndAccruedKeys);
            
            // CALL LUSID's GetValuation endpoint
            var results = _aggregationApi.GetValuation(valuationRequest).Data;
            Assert.That(results.Count, Is.EqualTo(1));
            var data = results.First();
            
            // CHECK exposure
            var exposure = (double) data[exposureKey];
            Assert.That(exposure, Is.GreaterThanOrEqualTo(0));
            
            // CHECK accrued interest
            // TODO: Looks like accrued interest is null, not clear if this is correct.
            var accruedInterest = data[accruedInterestKey];
            
            // CLEAN up.
            _recipeApi.DeleteConfigurationRecipe(scope, recipeCode);
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);
        }
    }
}
