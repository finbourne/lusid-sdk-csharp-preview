using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class EquityExample: DemoInstrumentBase
    {

        /*public InstrumentDefinition CreateEquityDefinition(string name, string clientInternal, string domCcy, decimal dividendYield)
        {
            SimpleInstrument equity = new SimpleInstrument(instrumentType: LusidInstrument.InstrumentTypeEnum.SimpleInstrument, domCcy: domCcy, assetClass: SimpleInstrument.AssetClassEnum.Equities, simpleInstrumentType: "Equity");

            Property properties = new Property(key: "Instrument/ibor/dividendYield", new PropertyValue(metricValue: new MetricValue(value: dividendYield)));

            InstrumentDefinition equityDefinition = new InstrumentDefinition(name: name, identifiers: new Dictionary<string, InstrumentIdValue>{{"ClientInternal", new InstrumentIdValue(clientInternal)}}, definition: equity, properties: new List<Property>{properties});

            return equityDefinition;

        }*/
        
        [Test]
        public void EquityCreationAndUpsertionExample()
        {
            string scope = "ibor";
            
            // CREATE an Equity (that can then be upserted into LUSID)
            var equity = (SimpleInstrument) InstrumentExamples.CreateExampleEquity();
            
            // ASSERT that it was created
            Assert.That(equity, Is.Not.Null);
            
            // CREATE property definition
            try
            {
                var propertyDefinitionRequest = new CreatePropertyDefinitionRequest(
                    domain: CreatePropertyDefinitionRequest.DomainEnum.Instrument,
                    scope: scope,
                    code: "dividendYield",
                    displayName: "Dividend Yield",
                    dataTypeId: new ResourceId(
                        scope: "system",
                        code: "number"
                    ),
                    lifeTime: CreatePropertyDefinitionRequest.LifeTimeEnum.Perpetual
                );

                _apiFactory.Api<IPropertyDefinitionsApi>()
                    .CreatePropertyDefinition(createPropertyDefinitionRequest: propertyDefinitionRequest);
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            // DEFINE properties
            decimal dividendYield = (decimal)0.88;
            Property properties = new Property(key: "Instrument/ibor/dividendYield", value: new PropertyValue(metricValue: new MetricValue(value: dividendYield)));
            
            // DEFINE equity instrument definition with property
            string name = "Microsoft";
            string identifier = "MSFT";
            var equityDefinition = new InstrumentDefinition(name: name, identifiers: new Dictionary<string, InstrumentIdValue>{{"ClientInternal", new InstrumentIdValue(identifier)}}, definition: equity, properties: new List<Property>{properties});
            
            // CAN NOW UPSERT TO LUSID
            Dictionary<string, InstrumentDefinition> upsertRequest = new Dictionary<string, InstrumentDefinition> {{identifier, equityDefinition}};
            var upsertResponse = _instrumentsApi.UpsertInstruments(upsertRequest);
            ValidateUpsertInstrumentResponse(upsertResponse);
            
            // CAN NOW QUERY FROM LUSID
            var getResponse = _instrumentsApi.GetInstruments(identifierType: "ClientInternal", requestBody: new List<String> {identifier}, propertyKeys:new List<String> { "Instrument/ibor/dividendYield"});
            ValidateInstrumentResponse(getResponse, identifier);
            

            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.SimpleInstrument);
            var roundTripEquity = retrieved as SimpleInstrument;
            Assert.That(roundTripEquity, Is.Not.Null);
            Assert.That(roundTripEquity.AssetClass, Is.EqualTo(SimpleInstrument.AssetClassEnum.Equities));
            // Assert.That(roundTripEquity., Is.EqualTo(SimpleInstrument.AssetClassEnum.Equities));



            // CAN NOW QUERY FROM LUSID
            // var getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            // ValidateInstrumentResponse(getResponse, uniqueId);

            // var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            // Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.SimpleInstrument);
            // var roundTripEquity = retrieved as SimpleInstrument;
            // Assert.That(roundTripEquity, Is.Not.Null);

            /*string name = "Microsoft";
            string identifier = "MSFT";
            string domCcy = "USD";
            decimal dividendYield = (Decimal)0.88;

            var equityExampleDefinition = CreateEquityDefinition(name: name, clientInternal: identifier, domCcy: domCcy, dividendYield: dividendYield);
            
            Dictionary<string, InstrumentDefinition> upsertRequest = new Dictionary<string, InstrumentDefinition> {{identifier, equityExampleDefinition}};
            
            var upsertResponse = _instrumentsApi.UpsertInstruments(upsertRequest);

            Assert.That(upsertResponse, Is.Not.Null);*/
        }

        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            throw new NotImplementedException();
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode,
            string instrumentID)
        {
            throw new NotImplementedException();
        }
    }
}