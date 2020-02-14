﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Ibor
{
    /// <summary>
    /// Orders represent an instruction from an investor to buy or sell a quantity of a specific
    /// security.
    /// </summary>
    [TestFixture]
    public class Orders
    {
        private ILusidApiFactory _apiFactory;
        private InstrumentLoader _instrumentLoader;
        private IOrdersApi _ordersApi;
        private IList<string> _instrumentIds;

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = LusidApiFactoryBuilder.Build("secrets.json");
            _instrumentLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = _instrumentLoader.LoadInstruments();
            _ordersApi = _apiFactory.Api<IOrdersApi>();
        }

        [Test]
        public void Upsert_Simple_Order()
        {
            var testScope = $"TestScope-{Guid.NewGuid().ToString()}";
            var orderId = $"Order-{Guid.NewGuid().ToString()}";
            
            // We want to make a request for a single order. The internal security id will be mapped on upsert
            // from the instrument identifiers passed.
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: orderId,
                        quantity: 100,
                        // These instrument identifiers should all map to the same instrument. If the instance of
                        // LUSID has the specified instruments registered these identifiers will get resolved to
                        // an actual internal instrument on upsert; otherwise, they'll be resolved to instrument or
                        // currency unknown.
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        // [Experimental] Currently this portfolio doesn't need to exist. As the domain model evolves
                        // this reference might disappear, or might become a strict reference to an existing portfolio.
                        portfolio: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        // [EXPERIMENTAL] Currently required but not used, as the internal instrument
                        // is resolved on upsert.  To remove shortly.
                        lusidInstrument: "CCY_ZZZ" 
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count, Is.EqualTo(1));
            Assert.That(upsertResult.Values.Count(rl => rl.Id.Id.Equals(orderId)), Is.EqualTo(1));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId)).LusidInstrument, Is.EqualTo(_instrumentIds.First()));
        }
        
        [Test]
        public void Upsert_Simple_Order_With_Unknown_Instrument()
        {
            var testScope = $"TestScope-{Guid.NewGuid().ToString()}";
            var orderId = $"Order-{Guid.NewGuid().ToString()}";
            
            // We want to make a request for a single order. We'll map the internal security id to an Unknown placeholder
            // if we can't translate it.
            var initialRequest = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: orderId,
                        quantity: 100,
                        // These instrument identifiers should all map to the same instrument. If the instance of
                        // LUSID has the specified instruments registered these identifiers will get resolved to
                        // an actual internal instrument on upsert; otherwise, they'll be resolved to instrument or
                        // currency unknown.
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = "LUID_SomeNonexistentInstrument"
                        },
                        // [Experimental] Currently this portfolio doesn't need to exist. As the domain model evolves
                        // this reference might disappear, or might become a strict reference to an existing portfolio
                        portfolio: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        // [EXPERIMENTAL] Currently required but not used, as the internal instrument
                        // is resolved on upsert.  To remove shortly.
                        lusidInstrument: "" 
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: initialRequest);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count, Is.EqualTo(1));
            Assert.That(upsertResult.Values.Count(rl => rl.Id.Id.Equals(orderId)), Is.EqualTo(1));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId)).LusidInstrument, Is.EqualTo("LUID_ZZZZZZZZ"));
        }
        
        [Test]
        public void Update_Simple_Order()
        {
            var testScope = $"TestScope-{Guid.NewGuid().ToString()}";
            var orderId = $"Order-{Guid.NewGuid().ToString()}";
            
            // We want to make a request for a single order. The internal security id will be mapped on upsert
            // from the instrument identifiers passed. Properties
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: orderId,
                        quantity: 100,
                        // These instrument identifiers should all map to the same instrument. If the instance of
                        // LUSID has the specified instruments registered these identifiers will get resolved to
                        // an actual internal instrument on upsert; otherwise, they'll be resolved to instrument or
                        // currency unknown.
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        // [Experimental] Currently this portfolio doesn't need to exist. As the domain model evolves
                        // this reference might disappear, or might become a strict reference to an existing portfolio
                        portfolio: new ResourceId(testScope, "OrdersTestPortfolio"),
                        // [EXPERIMENTAL] Currently required but not used, as the internal instrument
                        // is resolved on upsert.  To remove shortly.
                        lusidInstrument: "CCY_ZZZ",
                        properties: new List<PerpetualProperty>()
                    )
                });

            var upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count, Is.EqualTo(1));
            Assert.That(upsertResult.Values.Count(rl => rl.Id.Id.Equals(orderId)), Is.EqualTo(1));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId)).LusidInstrument, Is.EqualTo(_instrumentIds.First()));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId)).Quantity, Is.EqualTo(100));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId)).Properties.Count(), Is.EqualTo(0));
            
            // We can update that Order with a new Quantity, and some extra parameters
            var updateRequest = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: orderId,
                        quantity: 500,
                        // These instrument identifiers should all map to the same instrument. If the instance of
                        // LUSID has the specified instruments registered these identifiers will get resolved to
                        // an actual internal instrument on upsert; otherwise, they'll be resolved to instrument or
                        // currency unknown.
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        // [Experimental] Currently this portfolio doesn't need to exist. As the domain model evolves
                        // this reference might disappear, or might become a strict reference to an existing portfolio
                        portfolio: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        // [EXPERIMENTAL] Currently required but not used, as the internal instrument
                        // is resolved on upsert.  To remove shortly.
                        lusidInstrument: "CCY_ZZZ"
                        )
                });
            
            upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: updateRequest);
            
            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed. We can see that the quantity has been udpated, and properties added
            Assert.That(upsertResult.Values.Count, Is.EqualTo(1));
            Assert.That(upsertResult.Values.Count(rl => rl.Id.Id.Equals(orderId)), Is.EqualTo(1));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId)).LusidInstrument, Is.EqualTo(_instrumentIds.First()));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId)).Quantity, Is.EqualTo(500));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId)).Properties.Count(), Is.EqualTo(5));
        }
        
        [Test]
        public void Upsert_And_Retrieve_Simple_Orders()
        {
            var testScope = $"TestScope-{Guid.NewGuid().ToString()}";
            var orderId1 = $"Order-{Guid.NewGuid().ToString()}";
            var orderId2 = $"Order-{Guid.NewGuid().ToString()}";
            var orderId3 = $"Order-{Guid.NewGuid().ToString()}";
            
            // We want to make a request for a single order. The internal security id will be mapped on upsert
            // from the instrument identifiers passed. We can filter on a number of parameters on query.
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: orderId1,
                        quantity: 100,
                        // These instrument identifiers should all map to the same instrument. If the instance of
                        // LUSID has the specified instruments registered these identifiers will get resolved to
                        // an actual internal instrument on upsert; otherwise, they'll be resolved to instrument or
                        // currency unknown.
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        // [Experimental] Currently this portfolio doesn't need to exist. As the domain model evolves
                        // this reference might disappear, or might become a strict reference to an existing portfolio
                        portfolio: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("ZB123")),
                            new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        // [EXPERIMENTAL] Currently required but not used, as the internal instrument
                        // is resolved on upsert.  To remove shortly.
                        lusidInstrument: "CCY_ZZZ"
                    ),
                    new OrderRequest(
                        code: orderId2,
                        quantity: 200,
                        // These instrument identifiers should all map to the same instrument. If the instance of
                        // LUSID has the specified instruments registered these identifiers will get resolved to
                        // an actual internal instrument on upsert; otherwise, they'll be resolved to instrument or
                        // currency unknown.
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        // [Experimental] Currently this portfolio doesn't need to exist. As the domain model evolves
                        // this reference might disappear, or might become a strict reference to an existing portfolio
                        portfolio: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("UK Growth")),
                        },
                        // [EXPERIMENTAL] Currently required but not used, as the internal instrument
                        // is resolved on upsert.  To remove shortly.
                        lusidInstrument: "CCY_ZZZ"
                    ),
                    new OrderRequest(
                        code: orderId3,
                        quantity: 300,
                        // These instrument identifiers should all map to the same instrument. If the instance of
                        // LUSID has the specified instruments registered these identifiers will get resolved to
                        // an actual internal instrument on upsert; otherwise, they'll be resolved to instrument or
                        // currency unknown.
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.Skip(1).Take(1).Single()
                        },
                        // [Experimental] Currently this portfolio doesn't need to exist. As the domain model evolves
                        // this reference might disappear, or might become a strict reference to an existing portfolio
                        portfolio: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders 2")),
                            new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        // [EXPERIMENTAL] Currently required but not used, as the internal instrument
                        // is resolved on upsert.  To remove shortly.
                        lusidInstrument: "CCY_ZZZ"
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count(), Is.EqualTo(3));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals(orderId1)).LusidInstrument, Is.EqualTo(_instrumentIds.First()));
            
            var quantityFilter = _ordersApi.ListOrders(scope: testScope, asAt: DateTimeOffset.UtcNow, filter: "Quantity gt 100");

            Assert.That(quantityFilter.Values.Count(), Is.EqualTo(2));
            Assert.That(quantityFilter.Values.Single(rl => rl.Id.Id.Equals(orderId2)).Quantity, Is.GreaterThan(100));
            Assert.That(quantityFilter.Values.Single(rl => rl.Id.Id.Equals(orderId3)).Quantity, Is.GreaterThan(100));
            
            var orderBookFilter = _ordersApi.ListOrders(scope: testScope, asAt: DateTimeOffset.UtcNow, filter: $"Properties[{testScope}/OrderBook] eq 'UK Test Orders 2'");

            Assert.That(orderBookFilter.Values.Count(), Is.EqualTo(1));
            Assert.That(orderBookFilter.Values.Single(rl => rl.Id.Id.Equals(orderId3)).Properties[$"Order/{testScope}/OrderBook"].Value.LabelValue, Is.EqualTo("UK Test Orders 2"));
            
            var instrumentFilter = _ordersApi.ListOrders(scope: testScope, asAt: DateTimeOffset.UtcNow, filter: $"InstrumentUid eq '{_instrumentIds.First()}'");
            
            Assert.That(instrumentFilter.Values.Count(), Is.EqualTo(2));
            Assert.That(instrumentFilter.Values.Single(rl => rl.Id.Id.Equals(orderId2)).LusidInstrument, Is.EqualTo(_instrumentIds[0]));
            Assert.That(instrumentFilter.Values.Single(rl => rl.Id.Id.Equals(orderId1)).LusidInstrument, Is.EqualTo(_instrumentIds[0]));

        }
    }
}