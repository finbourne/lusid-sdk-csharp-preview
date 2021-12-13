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
    public class InterestRateSwaptionExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            var upsertComplexMarketDataRequest = new Dictionary<string, UpsertComplexMarketDataRequest>();
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
            {
                upsertComplexMarketDataRequest.Add("discount_curve", TestDataUtilities.BuildOisCurveRequest(TestDataUtilities.EffectiveAt, "USD"));
                upsertComplexMarketDataRequest.Add("6M_rate_Curve", TestDataUtilities.Build6MRateCurveRequest(TestDataUtilities.EffectiveAt, "USD"));
            }
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode,
            string recipeCode, string instrumentID)
        {
        }

        [LusidFeature("F22-9")]
        [Test]
        public void InterestRateSwaptionCreationAndUpsertionExample()
        {
            // CREATE an interest rate swaption (that can then be upserted into LUSID)
            var swaption = InstrumentExamples.CreateExampleInterestRateSwaption();
            
            // ASSERT that it was created
            Assert.That(swaption, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            var uniqueId = swaption.InstrumentType+Guid.NewGuid().ToString(); 
            var instrumentsIds = new List<(LusidInstrument, string)>{(swaption, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            var upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            var getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse, uniqueId);
            
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.InterestRateSwaption);
            var roundTripSwaption = retrieved as InterestRateSwaption;
            Assert.That(roundTripSwaption, Is.Not.Null);
            Assert.That(roundTripSwaption.DeliveryMethod, Is.EqualTo(swaption.DeliveryMethod));
            Assert.That(roundTripSwaption.StartDate, Is.EqualTo(swaption.StartDate));
            Assert.That(roundTripSwaption.PayOrReceiveFixed, Is.EqualTo(swaption.PayOrReceiveFixed));
            Assert.That(roundTripSwaption.Swap, Is.Not.Null);
            Assert.That(roundTripSwaption.Swap.InstrumentType, Is.EqualTo(LusidInstrument.InstrumentTypeEnum.InterestRateSwap));            
            // Delete Instrument
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId); 
        }
        
        [TestCase(ModelSelection.ModelEnum.SimpleStatic)]
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void InterestRateSwaptionValuationExample(ModelSelection.ModelEnum model)
        {
            var swaption = InstrumentExamples.CreateExampleInterestRateSwaption();
            CallLusidGetValuationEndpoint(swaption, model);
        }
    }
}
