using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.tutorials.Ibor
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

        //    This defines the scope that entities will be created in
        private const string TutorialScope = "Testdemo";

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
            // We want to make a request for a single order. The internal security id will be mapped on upsert
            // from the instrument identifiers passed.
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: "Order0001",
                        quantity: 100,
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        portfolio: new ResourceId(TutorialScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{TutorialScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{TutorialScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{TutorialScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{TutorialScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{TutorialScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        lusidInstrument: "CCY_ZZZ" 
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: TutorialScope, request: request);

            // The return gives us a list of orders upserted, and the lusidinstrument for each has been mapped from the
            // instrument identifiers passed
            Assert.That(upsertResult.Values.Count(rl => rl.Id.Id.Equals("Order0001")), Is.EqualTo(1));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0001")).LusidInstrument, Is.EqualTo(_instrumentIds.First()));
        }
        
        [Test]
        public void Upsert_Simple_Order_With_Unknown_Instrument()
        {
            // We want to make a request for a single order. We'll map the internal security id to an Unknown placeholder
            // if we can't translate it.
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: "Order0001",
                        quantity: 100,
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = "LUID_SomeNonexistentInstrument"
                        },
                        portfolio: new ResourceId(TutorialScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{TutorialScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{TutorialScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{TutorialScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{TutorialScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{TutorialScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        lusidInstrument: "" 
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: TutorialScope, request: request);

            // The return gives us a list of orders upserted, and the lusidinstrument for each has been mapped from the
            // instrument identifiers passed
            Assert.That(upsertResult.Values.Count(rl => rl.Id.Id.Equals("Order0001")), Is.EqualTo(1));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0001")).LusidInstrument, Is.EqualTo("LUID_ZZZZZZZZ"));
        }
        
        [Test]
        public void Update_Simple_Order()
        {
            // We want to make a request for a single order. The internal security id will be mapped on upsert
            // from the instrument identifiers passed. Properties
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: "Order0002",
                        quantity: 100,
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        portfolio: new ResourceId(TutorialScope, "OrdersTestPortfolio"),
                        lusidInstrument: "CCY_ZZZ",
                        properties: new List<PerpetualProperty>()
                    )
                });

            var upsertResult = _ordersApi.UpsertOrders(scope: TutorialScope, request: request);

            // The return gives us a list of orders upserted, and the lusidinstrument for each has been mapped from the
            // instrument identifiers passed
            Assert.That(upsertResult.Values.Count(rl => rl.Id.Id.Equals("Order0002")), Is.EqualTo(1));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0002")).LusidInstrument, Is.EqualTo(_instrumentIds.First()));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0002")).Quantity, Is.EqualTo(100));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0002")).Properties.Count(), Is.EqualTo(0));
            
            // We can update that Order with a new Quantity, and some extra parameters
            var updateRequest = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: "Order0002",
                        quantity: 500,
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        portfolio: new ResourceId(TutorialScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{TutorialScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{TutorialScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{TutorialScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{TutorialScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{TutorialScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        lusidInstrument: "CCY_ZZZ" 
                    )
                });
            
            upsertResult = _ordersApi.UpsertOrders(scope: TutorialScope, request: updateRequest);
            
            // The return gives us a list of orders upserted, and the lusidinstrument for each has been mapped from the
            // instrument identifiers passed. We can see that the quantity has been udpated, and properties added
            Assert.That(upsertResult.Values.Count(rl => rl.Id.Id.Equals("Order0002")), Is.EqualTo(1));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0002")).LusidInstrument, Is.EqualTo(_instrumentIds.First()));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0002")).Quantity, Is.EqualTo(500));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0002")).Properties.Count(), Is.EqualTo(5));
        }
        
        [Test]
        public void Upsert_And_Retrieve_Simple_Orders()
        {
            // We want to make a request for a single order. The internal security id will be mapped on upsert
            // from the instrument identifiers passed. We can filter on a number of parameters on query.
            var request = new OrderSetRequest(
                orderRequests: new List<OrderRequest>
                {
                    new OrderRequest(
                        code: "Order0001",
                        quantity: 100,
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        portfolio: new ResourceId(TutorialScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{TutorialScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{TutorialScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{TutorialScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{TutorialScope}/Account", new PropertyValue("ZB123")),
                            new PerpetualProperty($"Order/{TutorialScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        lusidInstrument: "CCY_ZZZ" 
                    ),
                    new OrderRequest(
                        code: "Order0002",
                        quantity: 200,
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.First()
                        },
                        portfolio: new ResourceId(TutorialScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{TutorialScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{TutorialScope}/OrderBook", new PropertyValue("UK Test Orders")),
                            new PerpetualProperty($"Order/{TutorialScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{TutorialScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{TutorialScope}/Strategy", new PropertyValue("UK Growth")),
                        },
                        lusidInstrument: "CCY_ZZZ" 
                    ),
                    new OrderRequest(
                        code: "Order0003",
                        quantity: 300,
                        instrumentIdentifiers: new Dictionary<string, string>()
                        {
                            ["Instrument/default/LusidInstrumentId"] = _instrumentIds.Skip(1).Take(1).Single()
                        },
                        portfolio: new ResourceId(TutorialScope, "OrdersTestPortfolio"),
                        properties: new List<PerpetualProperty>
                        {
                            new PerpetualProperty($"Order/{TutorialScope}/TIF", new PropertyValue("GTC")),
                            new PerpetualProperty($"Order/{TutorialScope}/OrderBook", new PropertyValue("UK Test Orders 2")),
                            new PerpetualProperty($"Order/{TutorialScope}/PortfolioManager", new PropertyValue("F Bar")),
                            new PerpetualProperty($"Order/{TutorialScope}/Account", new PropertyValue("J Wilson")),
                            new PerpetualProperty($"Order/{TutorialScope}/Strategy", new PropertyValue("RiskArb")),
                        },
                        lusidInstrument: "CCY_ZZZ" 
                    )
                });

            // We can ask the Orders API to upsert this order for us
            var upsertResult = _ordersApi.UpsertOrders(scope: TutorialScope, request: request);

            // The return gives us a list of orders upserted, and the lusidinstrument for each has been mapped from the
            // instrument identifiers passed
            Assert.That(upsertResult.Values.Count(), Is.EqualTo(3));
            Assert.That(upsertResult.Values.Single(rl => rl.Id.Id.Equals("Order0001")).LusidInstrument, Is.EqualTo(_instrumentIds.First()));
            
            var quantityFilter = _ordersApi.ListOrders(scope: TutorialScope, DateTimeOffset.UtcNow, filter: "Quantity gt 100");

            Assert.That(quantityFilter.Values.Count(), Is.EqualTo(2));
            
            var orderBookFilter = _ordersApi.ListOrders(scope: TutorialScope, DateTimeOffset.UtcNow, filter: $"Properties[{TutorialScope}/OrderBook] eq 'UK Test Orders 2'");

            Assert.That(orderBookFilter.Values.Count(), Is.EqualTo(1));
            
            var instrumentFilter = _ordersApi.ListOrders(scope: TutorialScope, DateTimeOffset.UtcNow, filter: $"InstrumentUid eq '{_instrumentIds.First()}'");
            
            Assert.That(instrumentFilter.Values.Count(), Is.EqualTo(2));
        }
    }
}