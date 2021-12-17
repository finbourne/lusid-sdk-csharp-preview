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
    public class EquityExample: DemoInstrumentBase
    {

        public InstrumentDefinition CreateEquityDefinition(string name, string clientInternal, string domCcy, decimal dividendYield)
        {
            SimpleInstrument equity = new SimpleInstrument(instrumentType: LusidInstrument.InstrumentTypeEnum.SimpleInstrument, domCcy: domCcy, assetClass: SimpleInstrument.AssetClassEnum.Equities, simpleInstrumentType: "Equity");

            Property properties = new Property(key: "Instrument/ibor/dividendYield", new PropertyValue(metricValue: new MetricValue(value: dividendYield)));

            InstrumentDefinition equityDefinition = new InstrumentDefinition(name: name, identifiers: new Dictionary<string, InstrumentIdValue>{{clientInternal, new InstrumentIdValue(clientInternal)}}, definition: equity, properties: new List<Property>{properties});

            return equityDefinition;

        }
        
        [Test]
        public void EquityCreationAndUpsertionExample()
        {
            string name = "Microsoft";
            string identifier = "MSFT";
            string domCcy = "USD";
            decimal dividendYield = (Decimal)0.88;

            var equityExampleDefinition = CreateEquityDefinition(name: name, clientInternal: identifier, domCcy: domCcy, dividendYield: dividendYield);
            
            Dictionary<string, InstrumentDefinition> upsertRequest = new Dictionary<string, InstrumentDefinition> {{identifier, equityExampleDefinition}};
            
            var upsertResponse = _instrumentsApi.UpsertInstruments(upsertRequest);

            Assert.That(upsertResponse, Is.Not.Null);
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