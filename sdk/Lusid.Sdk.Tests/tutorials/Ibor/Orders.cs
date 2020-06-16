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
            var testScope = $"Orders-SimpleUpsert-TestScope";
            var order = $"Order-{Guid.NewGuid().ToString()}";
            var orderId = new ResourceId(testScope, order);

            // We want to make a request for a single order. The internal security id will be mapped on upsert
            // from the instrument identifiers passed.
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        id: orderId,
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
                        portfolioId: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        },
                        side: "Buy",
                        orderBookId: new ResourceId(testScope, "OrdersTestBook")
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count == 1);
            Assert.That(upsertResult.Values.All(rl => rl.Id.Code.Equals(order)));
            Assert.That(upsertResult.Values.All(rl => rl.LusidInstrumentId.Equals(_instrumentIds.First())));
        }
        
        [Test]
        public void Upsert_Simple_Order_With_Unknown_Instrument()
        {
            var testScope = $"Orders-UnknownInstrument-TestScope";
            var order = $"Order-{Guid.NewGuid().ToString()}";
            var orderId = new ResourceId(testScope, order);

            // We want to make a request for a single order. We'll map the internal security id to an Unknown placeholder
            // if we can't translate it.
            var initialRequest = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        id: orderId,
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
                        portfolioId: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        },
                        side: "Buy",
                        orderBookId: new ResourceId(testScope, "OrdersTestBook")
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(initialRequest);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count == 1);
            Assert.That(upsertResult.Values.All(rl => rl.Id.Code.Equals(order)));
            Assert.That(upsertResult.Values.All(rl => rl.LusidInstrumentId.Equals("LUID_ZZZZZZZZ")));
        }
        
        [Test]
        public void Update_Simple_Order()
        {
            var testScope = $"Orders-Simple-TestScope";
            var order = $"Order-{Guid.NewGuid().ToString()}";
            var orderId = new ResourceId(testScope, order);

            // We want to make a request for a single order. The internal security id will be mapped on upsert
            // from the instrument identifiers passed. Properties
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        id: orderId,
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
                        portfolioId: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new Dictionary<string, PerpetualProperty>(),
                        side: "Buy",
                        orderBookId: new ResourceId(testScope, "OrdersTestBook")
                    )
                });

            var upsertResult = _ordersApi.UpsertOrders(request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count == 1);
            Assert.That(upsertResult.Values.All(rl => rl.Id.Code.Equals(order)));
            Assert.That(upsertResult.Values.All(rl => rl.LusidInstrumentId.Equals(_instrumentIds.First())));
            Assert.That(upsertResult.Values.All(rl => rl.Quantity == 100));
            Assert.That(upsertResult.Values.All(rl => !rl.Properties.Any()));
            
            // We can update that Order with a new Quantity, and some extra parameters
            var updateRequest = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        id: orderId,
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
                        portfolioId: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        },
                        side: "Buy",
                        orderBookId: new ResourceId(testScope, "OrdersTestBook")
                        )
                });
            
            upsertResult = _ordersApi.UpsertOrders(updateRequest);
            
            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed. We can see that the quantity has been udpated, and properties added
            Assert.That(upsertResult.Values.Count == 1);
            Assert.That(upsertResult.Values.All(rl => rl.Id.Code.Equals(order)));
            Assert.That(upsertResult.Values.All(rl => rl.LusidInstrumentId.Equals(_instrumentIds.First())));
            Assert.That(upsertResult.Values.All(rl => rl.Quantity == 500));
            Assert.That(upsertResult.Values.All(rl => rl.Properties.Count() == 5));
        }
        
        [Test]
        public void Upsert_And_Retrieve_Simple_Orders()
        {
            var testScope = $"Orders-Filter-TestScope";
            var order1 = $"Order-{Guid.NewGuid().ToString()}";
            var order2 = $"Order-{Guid.NewGuid().ToString()}";
            var order3 = $"Order-{Guid.NewGuid().ToString()}";
            var orderId1 = new ResourceId(testScope, order1);
            var orderId2 = new ResourceId(testScope, order2);
            var orderId3 = new ResourceId(testScope, order3);

            // We want to make a request to upsert several orders. The internal security id will be mapped on upsert
            // from the instrument identifiers passed. We can filter on a number of parameters on query.
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        id: orderId1,
                        quantity: 99,
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
                        portfolioId: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("ZB123")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        },
                        side: "Buy",
                        orderBookId: new ResourceId(testScope, "OrdersTestBook")
                    ),
                    new OrderRequest(
                        id: orderId2,
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
                        portfolioId: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("UK Growth")) },
                        },
                        side: "Sell",
                        orderBookId: new ResourceId(testScope, "AnotherOrdersTestBook")
                    ),
                    new OrderRequest(
                        id: orderId3,
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
                        portfolioId: new ResourceId(testScope, "OrdersTestPortfolio"),
                        properties: new Dictionary<string, PerpetualProperty>
                        {
                            { $"Order/{testScope}/TIF", new PerpetualProperty($"Order/{testScope}/TIF", new PropertyValue("GTC")) },
                            { $"Order/{testScope}/OrderBook", new PerpetualProperty($"Order/{testScope}/OrderBook", new PropertyValue("UK Test Orders 2")) },
                            { $"Order/{testScope}/PortfolioManager", new PerpetualProperty($"Order/{testScope}/PortfolioManager", new PropertyValue("F Bar")) },
                            { $"Order/{testScope}/Account", new PerpetualProperty($"Order/{testScope}/Account", new PropertyValue("J Wilson")) },
                            { $"Order/{testScope}/Strategy", new PerpetualProperty($"Order/{testScope}/Strategy", new PropertyValue("RiskArb")) },
                        },
                        side: "Buy",
                        orderBookId: new ResourceId(testScope, "OrdersTestBook")
                    )
                });

            // We can ask the Orders API to upsert these orders for us
            var upsertResult = _ordersApi.UpsertOrders(request);

            // The return gives us a list of orders upserted, and LusidInstrument for each has been mapped to a LUID
            // using the instrument identifiers passed
            Assert.That(upsertResult.Values.Count, Is.EqualTo(3));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Code.Equals(order1)).LusidInstrumentId, Is.EqualTo(_instrumentIds.First()));

            var t = upsertResult.Values.First().Version.AsAtDate;

            var order1Filter = $"{testScope}/{order1}";
            var order2Filter = $"{testScope}/{order2}";
            var order3Filter = $"{testScope}/{order3}";

            var quantityFilter = _ordersApi.ListOrders(asAt:
                t,
                filter: $"Quantity gt 100 and Scope eq '{testScope}' and Id in '{order1Filter}', '{order2Filter}', '{order3Filter}'");

            Assert.That(quantityFilter.Values.Count, Is.EqualTo(2));
            Assert.That(quantityFilter.Values.All(rl => rl.Quantity > 100));

            /*
             * Other filters are also possible:
             *
            var propertyFilter = _ordersApi.ListOrders(asAt: t, filter: $"Properties[{testScope}/OrderGroup] eq 'UK Test Orders 2'");

            Assert.That(propertyFilter.Values.Count, Is.EqualTo(1));
            Assert.That(propertyFilter.Values.Single(rl => rl.Id.Code.Equals(order3)).Properties[$"Order/{testScope}/OrderGroup"].Value.LabelValue, Is.EqualTo("UK Test Orders 2"));
            
            var instrumentFilter = _ordersApi.ListOrders(asAt: t, filter: $"LusidInstrumentId eq '{_instrumentIds.First()}' and Scope eq '{testScope}'");
            
            Assert.That(instrumentFilter.Values.Count, Is.EqualTo(2));
            Assert.That(instrumentFilter.Values.All(rl => rl.LusidInstrumentId.Equals(_instrumentIds[0])));

            var sideFilter = _ordersApi.ListOrders(asAt: t, filter: $"Side eq 'Sell' and Scope eq '{testScope}'");

            Assert.That(sideFilter.Values.Count, Is.EqualTo(1));
            Assert.That(sideFilter.Values.All(rl => rl.Side.Equals("Sell")));

            var orderBookFilter = _ordersApi.ListOrders(asAt: t, filter: $"OrderBook eq '{testScope}/AnotherOrdersTestBook'");

            Assert.That(orderBookFilter.Values.Count, Is.EqualTo(1));
            Assert.That(orderBookFilter.Values.All(rl => rl.OrderBookId.Code.Equals("AnotherOrdersTestBook")));
            */
        }
    }
}