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
    public class InterestRateSwapExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            // The price of a swap is determined by the price of the fixed leg and floating leg.
            // The price of a floating leg is determined by historic resets rates and projected rates.
            // In this method, we upsert reset rates.
            // For LUSID to pick up these quotes, we have added a RIC rule to the recipe (see BuildRecipeRequest in TestDataUtilities.cs) 
            // The RIC rule has a quote interval of 2 years, this means that we can use one reset quote for all the resets.
            // For accurate pricing, one would want to upsert a quote per reset. 
            var quoteRequest = TestDataUtilities.BuildQuoteRequest("USD6M", QuoteSeriesId.InstrumentIdTypeEnum.ClientInternal, 0.05m, "USD", TestDataUtilities.EffectiveAt);
            var upsertResponse = _quotesApi.UpsertQuotes(scope, quoteRequest);
            Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertResponse.Values.Count, Is.EqualTo(quoteRequest.Count));
            
            // For models requiring discount curves, we upsert them below. ConstantTimeValueOfMoney does not require any discount curves. 
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
            {
                var upsertComplexMarketDataRequest = TestDataUtilities.BuildRateCurvesRequests(TestDataUtilities.EffectiveAt);
                var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
                ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
            }
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode,
            string recipeCode, string instrumentID)
        {
            var swap = (InterestRateSwap) instrument;
            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: swap.StartDate.AddDays(-3),
                windowEnd: swap.MaturityDate.AddDays(3),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.GreaterThanOrEqualTo(1));

            // CLEAN up - delete instrument and portfolio
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);
        }

        [LusidFeature("F22-7")]
        [Test]
        public void InterestRateSwapCreationAndUpsertionExample()
        {
            // CREATE an interest rate swap (that can then be upserted into LUSID)
            var swap = (InterestRateSwap) InstrumentExamples.CreateExampleInterestRateSwap();
            
            // ASSERT that it was created
            Assert.That(swap, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            var uniqueId = swap.InstrumentType + Guid.NewGuid().ToString(); 
            var instrumentsIds = new List<(LusidInstrument, string)>{(swap, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            var upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            var getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse, uniqueId);
            
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.InterestRateSwap);
            var roundTripSwap = retrieved as InterestRateSwap;
            Assert.That(roundTripSwap, Is.Not.Null);
            Assert.That(roundTripSwap.MaturityDate, Is.EqualTo(swap.MaturityDate));
            Assert.That(roundTripSwap.StartDate, Is.EqualTo(swap.StartDate));
            Assert.That(roundTripSwap.Legs.Count, Is.EqualTo(swap.Legs.Count));            
            
            // Delete Instrument
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId); 
        }
        
        [TestCase(ModelSelection.ModelEnum.SimpleStatic)]
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void InterestRateSwapValuationExample(ModelSelection.ModelEnum model)
        {
            var irs = InstrumentExamples.CreateExampleInterestRateSwap();
            CallLusidGetValuationEndpoint(irs, model);
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void InterestRateSwapInlineValuationExample(ModelSelection.ModelEnum model)
        {
            var irs = InstrumentExamples.CreateExampleInterestRateSwap();
            CallLusidGetValuationEndpoint(irs, model);
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void EquityOptionPortfolioCashFlowsExample(ModelSelection.ModelEnum model)
        {
            var irs = InstrumentExamples.CreateExampleInterestRateSwap();
            CallLusidGetPortfolioCashFlowsEndpoint(irs, model);
        }
    }
}
