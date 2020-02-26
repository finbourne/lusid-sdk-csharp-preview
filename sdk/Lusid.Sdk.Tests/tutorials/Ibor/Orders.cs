using System;
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
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        }
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count == 1);
            Assert.That(upsertResult.Values.All(rl => rl.Id.Code.Equals(orderId)));
            Assert.That(upsertResult.Values.All(rl => rl.LusidInstrumentId.Equals(_instrumentIds.First())));
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
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        }
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: initialRequest);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count == 1);
            Assert.That(upsertResult.Values.All(rl => rl.Id.Code.Equals(orderId)));
            Assert.That(upsertResult.Values.All(rl => rl.LusidInstrumentId.Equals("LUID_ZZZZZZZZ")));
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
                        properties: new Dictionary<string, PerpetualProperty>()
                    )
                });

            var upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count == 1);
            Assert.That(upsertResult.Values.All(rl => rl.Id.Code.Equals(orderId)));
            Assert.That(upsertResult.Values.All(rl => rl.LusidInstrumentId.Equals(_instrumentIds.First())));
            Assert.That(upsertResult.Values.All(rl => rl.Quantity == 100));
            Assert.That(upsertResult.Values.All(rl => !rl.Properties.Any()));
            
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
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        }
                        )
                });
            
            upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: updateRequest);
            
            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed. We can see that the quantity has been udpated, and properties added
            Assert.That(upsertResult.Values.Count == 1);
            Assert.That(upsertResult.Values.All(rl => rl.Id.Code.Equals(orderId)));
            Assert.That(upsertResult.Values.All(rl => rl.LusidInstrumentId.Equals(_instrumentIds.First())));
            Assert.That(upsertResult.Values.All(rl => rl.Quantity == 500));
            Assert.That(upsertResult.Values.All(rl => rl.Properties.Count() == 5));
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
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("ZB123")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        }
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
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("UK Growth")) },
                        }
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
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders 2")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        }
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: testScope, request: request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count == 3);
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Code.Equals(orderId1)).LusidInstrumentId, Is.EqualTo(_instrumentIds.First()));
            
            var quantityFilter = _ordersApi.ListOrders(scope: testScope, asAt: DateTimeOffset.UtcNow, filter: "Quantity gt 100");

            Assert.That(quantityFilter.Values.Count == 2);
            Assert.That(quantityFilter.Values.All(rl => rl.Quantity > 100));

            var orderBookFilter = _ordersApi.ListOrders(scope: testScope, asAt: DateTimeOffset.UtcNow, filter: $"Properties[{testScope}/OrderBook] eq 'UK Test Orders 2'");

            Assert.That(orderBookFilter.Values.Count == 1);
            Assert.That(orderBookFilter.Values.Single(rl => rl.Id.Code.Equals(orderId3)).Properties[$"Order/{testScope}/OrderBook"].Value.LabelValue, Is.EqualTo("UK Test Orders 2"));
            
            var instrumentFilter = _ordersApi.ListOrders(scope: testScope, asAt: DateTimeOffset.UtcNow, filter: $"LusidInstrumentId eq '{_instrumentIds.First()}'");
            
            Assert.That(instrumentFilter.Values.Count == 2);
            Assert.That(instrumentFilter.Values.All(rl => rl.LusidInstrumentId.Equals(_instrumentIds[0])));

        }
    }
}