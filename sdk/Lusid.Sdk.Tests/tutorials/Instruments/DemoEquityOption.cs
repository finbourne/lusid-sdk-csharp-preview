using System;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class DemoEquityOption: DemoInstrument
    {
        
        [Test]
        public void DemoEquityOptionCreation()
        {
            // CREATE an equity option (that can then be upserted into Lusid)
            var equityOption = (EquityOption) InstrumentExamples.CreateExampleEquityOption();
            Assert.That(equityOption, Is.Not.Null);

            // Can now UPSERT to Lusid
            string uniqueId = Guid.NewGuid().ToString();
            UpsertOtcInstrumentToLusid(equityOption, uniqueId);

            // Can now QUERY from Lusid
            var retrieved = QueryOtcInstrumentFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption);
            var roundTripEquityOption = retrieved as EquityOption;
            Assert.That(roundTripEquityOption, Is.Not.Null);
            Assert.That(roundTripEquityOption.Code, Is.EqualTo(equityOption.Code));
            Assert.That(roundTripEquityOption.Strike, Is.EqualTo(equityOption.Strike));
            Assert.That(roundTripEquityOption.DeliveryType, Is.EqualTo(equityOption.DeliveryType));
            Assert.That(roundTripEquityOption.DomCcy, Is.EqualTo(equityOption.DomCcy));
            Assert.That(roundTripEquityOption.OptionType, Is.EqualTo(equityOption.OptionType));
            Assert.That(roundTripEquityOption.StartDate, Is.EqualTo(equityOption.StartDate));
            Assert.That(roundTripEquityOption.OptionMaturityDate, Is.EqualTo(equityOption.OptionMaturityDate));
            Assert.That(roundTripEquityOption.OptionSettlementDate, Is.EqualTo(equityOption.OptionSettlementDate));
            Assert.That(roundTripEquityOption.UnderlyingIdentifier, Is.EqualTo(equityOption.UnderlyingIdentifier));
            
            DeleteItems(null,null,null,uniqueId);
            
        }

        [TestCase("ConstantTimeValueOfMoney", true)]
        [TestCase("Discounting", true)]
        [TestCase("BlackScholes", true)]
        [TestCase("Bachelier", true)]
        [TestCase("ConstantTimeValueOfMoney", false)]
        [TestCase("Discounting", false)]
        [TestCase("BlackScholes", false)]
        [TestCase("Bachelier", false)]
        public void DemoEquityOptionValuation(string modelName, bool inlineValuationRequest)
        {
            // Set model and scope
            var scope = Guid.NewGuid().ToString(); 
            var model = Enum.Parse<ModelSelection.ModelEnum>(modelName);
            
            // Create instrument
            var option = (EquityOption) InstrumentExamples.CreateExampleEquityOption();
           
            // for pricing, we need the following market data (depending on the model)
            CreateAndUpsertSimpleQuote(scope, "ACME", QuoteSeriesId.InstrumentIdTypeEnum.RIC, 135m, "USD", TestDataUtilities.EffectiveAt);
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
                CreateAndUpsertOisCurve(scope, TestDataUtilities.EffectiveAt, "USD");
            if (model == ModelSelection.ModelEnum.BlackScholes)
                CreateAndUpsertConstantVolSurface(scope, TestDataUtilities.EffectiveAt, option, model, 0.2m);
            if (model == ModelSelection.ModelEnum.Bachelier)
                CreateAndUpsertConstantVolSurface(scope, TestDataUtilities.EffectiveAt, option, model, 10m);

            // CREATE Black-Scholes recipe specifying where to look for market data and which metrics to return
            // if in a larger portfolio, we would make a specific VendorModelRule specifying that equity options are to be valued using Black-Scholes
            var valuation = Valuation(option, scope, model, EffectiveAt, inlineValuationRequest);
            
            Assert.That(valuation, Is.Not.Null);
            Assert.That(valuation.Data.Count, Is.EqualTo(1));

            var pv = valuation.Data[0][HoldingPvKey];
            Assert.That(pv, Is.Positive); // since our option is in the money, all models should return a positive pv
            Console.WriteLine($"Computed pv of {pv} at time {EffectiveAt:O} using model {modelName}");
        }

        [TestCase("ConstantTimeValueOfMoney")]
        [TestCase("Discounting")]
        [TestCase("BlackScholes")]
        [TestCase("Bachelier")]
        public void DemoEquityOptionCashFlows(string modelName)
        {
            var scope = Guid.NewGuid().ToString();
            var model = Enum.Parse<ModelSelection.ModelEnum>(modelName);

            // CREATE and UPSERT option
            var option = (EquityOption) InstrumentExamples.CreateExampleEquityOption(isCashSettled: false);
            string uniqueId = Guid.NewGuid().ToString();

            // for equity option cashflows, we need the following market data to determine intrinsic value for cashflow calculation
            CreateAndUpsertSimpleQuote(scope, "ACME", QuoteSeriesId.InstrumentIdTypeEnum.RIC, 135m, "USD", EffectiveAt);
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
                CreateAndUpsertOisCurve(scope, TestDataUtilities.EffectiveAt, "USD");
            if (model == ModelSelection.ModelEnum.BlackScholes)
                CreateAndUpsertConstantVolSurface(scope, TestDataUtilities.EffectiveAt, option, model, 0.2m);
            if (model == ModelSelection.ModelEnum.Bachelier)
                CreateAndUpsertConstantVolSurface(scope, TestDataUtilities.EffectiveAt, option, model, 10m);
            // CREATE a new portfolio and add the option to it via a transaction
            var portfolioCode = CreatePortfolioAndTransaction(scope, option, uniqueId, EffectiveAt); 
            

            // CREATE a recipe to tell lusid where to find the requisite market data
            // we require a model to estimate/determine future cashflows (for physically settled options, we currently assume exercise in all models)
            // we choose ConstantTimeValueOfMoney since it has the fewest dependencies
            var recipeCode = Guid.NewGuid().ToString(); 
            UpsertRecipe(recipeCode, scope, model);

            // QUERY cashflows and check that there is exactly one, as expected
            var cashflows = GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: option.StartDate.AddDays(-3),
                windowEnd: option.OptionMaturityDate.AddDays(3),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.EqualTo(1));

            var cashflow = cashflows[0];
            Assert.That(cashflow.Amount, Is.Negative);
            Console.WriteLine($"Computed cash flow of {cashflow.Amount} {cashflow.Currency} at time {cashflow.PaymentDate}");
            DeleteItems(scope, recipeCode, portfolioCode, uniqueId);
        }
    }
}
