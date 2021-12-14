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
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID)
        {
        }
        
        [LusidFeature("F22-8")]
        [Test]
        public void InterestRateSwapWithNamedConventionsCreationAndUpsertionExample()
        {
            // CREATE a named convention Interest Rate Swap (IRS) (that can then be upserted into LUSID)
            var swap = InstrumentExamples.CreateSwapByNamedConventions();

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

        private void UpsertNamedConventionsToLusid()
        {
            // CREATE the flow conventions and index convention for swap
            string scope = "Conventions";
            string flowConventionsCode = "GBP-3M";
            string indexConventionCode = "GBP-3M-LIBOR";

            var flowConventions = new FlowConventions(
                scope: scope,
                code: flowConventionsCode,
                currency: "GBP",
                paymentFrequency: "3M",
                rollConvention: "ModifiedFollowing",
                dayCountConvention: "Actual365",
                paymentCalendars: new List<string>(),
                resetCalendars: new List<string>(),
                settleDays: 2,
                resetDays: 2
            );

            var indexConvention = new IndexConvention(
                scope: scope,
                code: indexConventionCode,
                publicationDayLag: 0,
                currency: "GBP",
                paymentTenor: "3M",
                dayCountConvention: "Actual365",
                fixingReference: "BP00"
            );
            
            // UPSERT the conventions to Lusid
            var flowConventionsResponse =  _conventionsApi.UpsertFlowConventions(new UpsertFlowConventionsRequest(flowConventions));
            Assert.That(flowConventionsResponse, Is.Not.Null);
            Assert.That(flowConventionsResponse.Value, Is.Not.Null);

            var indexConventionsResponse = _conventionsApi.UpsertIndexConvention(new UpsertIndexConventionRequest(indexConvention));
            Assert.That(indexConventionsResponse, Is.Not.Null);
            Assert.That(indexConventionsResponse.Value, Is.Not.Null);
        }
        
        [TestCase(ModelSelection.ModelEnum.SimpleStatic)]
        public void InterestRateSwapWithNamedConventionsValuationExample(ModelSelection.ModelEnum model)
        {
            var irs = InstrumentExamples.CreateSwapByNamedConventions();
            UpsertNamedConventionsToLusid();
            CallLusidGetValuationEndpoint(irs, model);
        }
    }
}
