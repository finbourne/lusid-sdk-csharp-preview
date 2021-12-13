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
    public class InterestRateSwapWithNamedConventions: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            var upsertComplexMarketDataRequest = new Dictionary<string, UpsertComplexMarketDataRequest>();
            if (model == ModelSelection.ModelEnum.Discounting)
            {
                upsertComplexMarketDataRequest.Add("discount_curve", TestDataUtilities.BuildOisCurveRequest(TestDataUtilities.EffectiveAt, "USD"));
                upsertComplexMarketDataRequest.Add("6M_rate_Curve", TestDataUtilities.Build6MRateCurveRequest(TestDataUtilities.EffectiveAt, "USD"));
            }
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID)
        {
        }
        
        [LusidFeature("F22-8")]
        [Test]
        public void InterestRateSwapWithNamedConventionsCreationAndUpsertionExample()
        {
            // CREATE an Interest Rate Swap (IRS) (that can then be upserted into LUSID)
            var startDate = new DateTimeOffset(2020, 2, 7, 0, 0, 0, TimeSpan.Zero);
            var maturityDate = new DateTimeOffset(2030, 2, 7, 0, 0, 0, TimeSpan.Zero);

            // CREATE the flow conventions, index convention
            FlowConventionName flowConventionName = new FlowConventionName(currency: "GBP", tenor: "3M");
            FlowConventionName indexConventionName = new FlowConventionName(currency: "GBP", tenor: "3M", indexName:"LIBOR");

            // CREATE the swap
            var swap = InstrumentExamples.CreateSwapByNamedConventions(startDate, maturityDate, 0.02m, flowConventionName, indexConventionName);

            // ASSERT that it was created
            Assert.That(swap, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            var uniqueId = swap.InstrumentType+Guid.NewGuid().ToString(); 
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
    }
}
