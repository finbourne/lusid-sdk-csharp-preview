using System;
using Lusid.Sdk.Api;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.MarketData
{
    [TestFixture]
    public class CorporateActions
    {
        private ICorporateActionsApi _corporateActionsApi;

        [OneTimeSetUp]
        public void SetUp()
        {
            var apiFactory = LusidApiFactoryBuilder.Build("secrets.json");
            _corporateActionsApi = apiFactory.Api<ICorporateActionsApi>();
        }

        [Test]
        public void List_Corporate_Action_Sources()
        {
            var sources = _corporateActionsApi.ListCorporateActionSources();

            foreach (var source in sources.Values)
            {
                Console.WriteLine($"{source.Id.Scope}\t:\t{source.Id.Code}");
            }
        }

        [Test, Ignore("Not implemented")]
        public void List_Corporate_Actions_For_One_Day()
        {
            var result = _corporateActionsApi.GetCorporateActions(
                scope: "UK_High_Growth_Equities_Fund_a4fb",
                code: "UK_High_Growth_Equities_Fund_base_fund_corporate_action_source"
            );

        }

    }
}