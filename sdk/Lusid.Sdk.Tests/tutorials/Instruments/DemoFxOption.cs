using System;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class DemoFxOption: DemoInstrument
    {

        [Test]
        public void DemonstrateCreationOfFxOption()
        {
            // CREATE an Fx-Option (that can then be upserted into LUSID)
            var fxOption = (FxOption) InstrumentExamples.CreateExampleFxOption();
            
            // ASSERT that it was created
            Assert.That(fxOption, Is.Not.Null);

            // CAN NOW UPSERT TO LUSID
            string uniqueId = Guid.NewGuid().ToString(); 
            UpsertOtcInstrumentToLusid(fxOption, uniqueId);

            // CAN NOW QUERY FROM LUSID
            var retrieved = QueryOtcInstrumentFromLusid(uniqueId);
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxOption);
            var roundTripFxOption = retrieved as FxOption;
            Assert.That(roundTripFxOption, Is.Not.Null);
            Assert.That(roundTripFxOption.DomCcy, Is.EqualTo(fxOption.DomCcy));
            Assert.That(roundTripFxOption.FgnCcy, Is.EqualTo(fxOption.FgnCcy));
            Assert.That(roundTripFxOption.Strike, Is.EqualTo(fxOption.Strike));
            Assert.That(roundTripFxOption.StartDate, Is.EqualTo(fxOption.StartDate));
            Assert.That(roundTripFxOption.OptionMaturityDate, Is.EqualTo(fxOption.OptionMaturityDate));
            Assert.That(roundTripFxOption.OptionSettlementDate, Is.EqualTo(fxOption.OptionSettlementDate));
            Assert.That(roundTripFxOption.IsCallNotPut, Is.EqualTo(fxOption.IsCallNotPut));
            Assert.That(roundTripFxOption.IsDeliveryNotCash, Is.EqualTo(fxOption.IsDeliveryNotCash));
            
            // Delete Instrument 
            DeleteItems(null,null,null,uniqueId);
        }
        
        [TestCase("ConstantTimeValueOfMoney")]
        [TestCase("Discounting")]
        [TestCase("BlackScholes")]
        [TestCase("Bachelier")]
        public void DemoFxOptionValuation(string modelName)
        {
            
            var scope = $"DemoFxOptionValuation-{modelName}";
            var model = Enum.Parse<ModelSelection.ModelEnum>(modelName);
            
            var fxOption = InstrumentExamples.CreateExampleFxOption();

            // POPULATE with required market data for valuation of the instruments
            UpsertFxRate(scope, EffectiveAt);
            //_testDataUtilities.UpsertFxVol(scope, TestDataUtilities.EffectiveAt, fxOption);
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
                UpsertRateCurves(scope, EffectiveAt);
            if (model == ModelSelection.ModelEnum.BlackScholes)
                CreateAndUpsertConstantVolSurface(scope, EffectiveAt, fxOption, model, 0.2m);
            if (model == ModelSelection.ModelEnum.Bachelier)
                CreateAndUpsertConstantVolSurface(scope, EffectiveAt, fxOption, model, 10m);
            
           
            // CALL valuation and check the PVs makes sense.
            var valuation = Valuation(fxOption, scope, model, EffectiveAt);

            Assert.That(valuation, Is.Not.Null);

            foreach (var result in valuation.Data)
            {
                var pv = (double) result[HoldingPvKey];
                Assert.That(pv, Is.Not.EqualTo(0).Within(1e-5));
                Assert.That(pv, Is.GreaterThanOrEqualTo(0));
            }
        }

        
        [TestCase("ConstantTimeValueOfMoney")]
        [TestCase("Discounting")]
        [TestCase("BlackScholes")]
        [TestCase("Bachelier")]
        public void DemoFxOptionCashFlows(string modelName)
        {
            var scope = Guid.NewGuid().ToString();
            var model = Enum.Parse<ModelSelection.ModelEnum>(modelName);
            var option = InstrumentExamples.CreateExampleFxOption();
            var fxoption = (FxOption) option;
            string uniqueId = Guid.NewGuid().ToString();

            UpsertFxRate(scope, EffectiveAt);
            if (model != ModelSelection.ModelEnum.ConstantTimeValueOfMoney)
                UpsertRateCurves(scope, EffectiveAt);
            if (model == ModelSelection.ModelEnum.BlackScholes)
                CreateAndUpsertConstantVolSurface(scope, EffectiveAt, fxoption, model, 0.2m);
            if (model == ModelSelection.ModelEnum.Bachelier)
                CreateAndUpsertConstantVolSurface(scope, EffectiveAt, fxoption, model, 10m);
            // CREATE a new portfolio and add the option to it via a transaction
            var portfolioCode = CreatePortfolioAndTransaction(scope, option, uniqueId, fxoption.StartDate); 
            

            var recipeCode = Guid.NewGuid().ToString(); 
            UpsertRecipe(recipeCode, scope, model);

            var cashflows = GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: fxoption.StartDate.AddDays(-3),
                windowEnd: fxoption.OptionMaturityDate.AddDays(3),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.EqualTo(2));
            Assert.That(cashflows[1].Amount, Is.EqualTo(fxoption.Strike));
            Assert.That(cashflows[0].Amount, Is.EqualTo(1.0m));
            DeleteItems(scope, recipeCode, portfolioCode, uniqueId);
        }
        
    }
}
