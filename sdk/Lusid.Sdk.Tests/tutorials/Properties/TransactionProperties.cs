using System;
using System.Collections.Generic;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Properties
{
    [TestFixture]
    public class TransactionProperties : TutorialBase
    {
        private IList<string> _instrumentIds;
        
        [OneTimeSetUp]
        public void OnetimeSetUp()
        {
            var instrumentLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = instrumentLoader.LoadInstruments();
        }

        internal string _portfolioCode;
        [SetUp]
        public void SetUp()
        {
            var portfolioRequest = TestDataUtilities.BuildTransactionPortfolioRequest();
            var portfolio = _transactionPortfoliosApi.CreatePortfolio(TestDataUtilities.TutorialScope, portfolioRequest);
            _portfolioCode = portfolioRequest.Code;
            Assert.That(portfolio?.Id.Code, Is.EqualTo(_portfolioCode));
        }

        [LusidFeature("F13-4")]
        [Test]
        public void Test_Transaction_Property()
        {
            var effectiveDate = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);

            //create the transaction request
            string code = "TransactionTestDetail";
            string perpetualPropertyKey = $"Transaction/{TestDataUtilities.TutorialScope}/{code}";
            string perpetualPropertyPropVal = "TestPropertyLabelValue";

            EnsurePropertyDefinition(code);

            var transaction = new TransactionRequest(
                // unique transaction id
                transactionId: Guid.NewGuid().ToString(),

                // instruments must already exist in LUSID and have a valid LUSID instrument id
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [TestDataUtilities.LusidInstrumentIdentifier] = _instrumentIds[0]
                },

                type: "Buy",
                totalConsideration: new CurrencyAndAmount(1230, "GBP"),
                transactionDate: effectiveDate,
                settlementDate: effectiveDate,
                units: 100,
                transactionPrice: new TransactionPrice(12.3M),
                source: "Custodian",

                //Specification of the transaction property we are testing
                properties: new Dictionary<string, PerpetualProperty>
                            {
                                { 
                                    perpetualPropertyKey,
                                    new PerpetualProperty(perpetualPropertyKey, new PropertyValue(labelValue: perpetualPropertyPropVal))
                                }
                            }
            );

            // add the transaction
            UpsertPortfolioTransactionsResponse upsertResp =  _transactionPortfoliosApi.UpsertTransactions(TestDataUtilities.TutorialScope, _portfolioCode, new List<TransactionRequest> { transaction });

            // get the transaction and verify the reponse
            var transactions = _transactionPortfoliosApi.GetTransactions(TestDataUtilities.TutorialScope, _portfolioCode);

            Assert.That(transactions.Values, Has.Count.EqualTo(1));
            Assert.That(transactions.Values[0].TransactionId, Is.EqualTo(transaction.TransactionId));

            // assert that the custom properties was upserted with the transaction and is returned
            Assert.IsTrue(transactions.Values[0].Properties.ContainsKey(perpetualPropertyKey));
            Assert.That(transactions.Values[0].Properties[perpetualPropertyKey].Value.LabelValue == perpetualPropertyPropVal);
        }

        private void EnsurePropertyDefinition(string code)
        {
            var propertyApi = _apiFactory.Api<IPropertyDefinitionsApi>();

            try
            {
                propertyApi.GetPropertyDefinition("Transaction", TestDataUtilities.TutorialScope, code);
            }
            catch (ApiException)
            {
                //    Property definition doesn't exist (returns 404), so create one
                //    Details of the property to be created
                var propertyDefinition = new CreatePropertyDefinitionRequest(
                    domain: CreatePropertyDefinitionRequest.DomainEnum.Transaction,
                    scope: TestDataUtilities.TutorialScope,
                    lifeTime: CreatePropertyDefinitionRequest.LifeTimeEnum.Perpetual,
                    code: code,
                    valueRequired: false,
                    displayName: code,
                    dataTypeId: new ResourceId("system", "string")
                );

                //    Create the property
                propertyApi.CreatePropertyDefinition(propertyDefinition);
            }
        }
    }
}