using System;
using Lusid.Sdk.Api;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.MarketData
{
    [TestFixture]
    public class CorporateActions: TutorialBase
    {

        [LusidFeature("F12-6")]
        [Test]
        public void List_Corporate_Action_Sources()
        {
            var sources = _corporateActionSourcesApi.ListCorporateActionSources();

            foreach (var source in sources.Values)
            {
                Console.WriteLine($"{source.Id.Scope}\t:\t{source.Id.Code}");
            }
        }

        [Test, Ignore("Not implemented")]
        public void List_Corporate_Actions_For_One_Day()
        {
            var result = _corporateActionSourcesApi.GetCorporateActions(
                scope: "UK_High_Growth_Equities_Fund_a4fb",
                code: "UK_High_Growth_Equities_Fund_base_fund_corporate_action_source"
            );

        }

    }
}