using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.tutorials.Instruments
{
    public class InstrumentDemoHelpers
    {
        private readonly ITransactionPortfoliosApi _transactionPortfoliosApi;
        private readonly IInstrumentsApi _instrumentsApi;
        private readonly IQuotesApi _quotesApi;
        private readonly IComplexMarketDataApi _complexMarketDataApi;
        private readonly IConfigurationRecipeApi _recipeApi;

        public InstrumentDemoHelpers(
            IInstrumentsApi instrumentsApi = null,
            IQuotesApi quotesApi = null,
            IComplexMarketDataApi complexMarketDataApi = null,
            IConfigurationRecipeApi recipeApi = null,
            ITransactionPortfoliosApi transactionPortfoliosApi = null)
        {
            _transactionPortfoliosApi = transactionPortfoliosApi;
            _instrumentsApi = instrumentsApi;
            _quotesApi = quotesApi;
            _complexMarketDataApi = complexMarketDataApi;
            _recipeApi = recipeApi;
        }

        public UpsertInstrumentsResponse UpsertOtcToLusid(LusidInstrument instrument, string name, string idUniqueToInstrument)
        {
            // PACKAGE instrument for upsert
            var instrumentDefinition = new InstrumentDefinition(
                name: name,
                identifiers: new Dictionary<string, InstrumentIdValue>
                {
                    ["ClientInternal"] = new InstrumentIdValue(value: idUniqueToInstrument)
                },
                definition: instrument
            );

            // put instrument into Lusid
            var response = _instrumentsApi.UpsertInstruments(new Dictionary<string, InstrumentDefinition>
            {
                ["someId1"] = instrumentDefinition
            });

            // Check the response succeeded and has no errors.
            Assert.That(response.Failed.Count, Is.EqualTo(0));
            Assert.That(response.Values.Count, Is.EqualTo(1));
            return response;
        }

        public LusidInstrument QueryOtcFromLusid(string idUniqueToInstrument)
        {
            var response = _instrumentsApi.GetInstruments("ClientInternal",
                new List<string>
                {
                    idUniqueToInstrument
                });

            // Check the response succeeded and has no errors.
            Assert.That(response.Failed.Count, Is.EqualTo(0));
            Assert.That(response.Values.Count, Is.EqualTo(1));

            Assert.That(response.Values.First().Key, Is.EqualTo(idUniqueToInstrument));
            return response.Values.First().Value.InstrumentDefinition;
        }

        public void UpsertRecipe(ConfigurationRecipe recipe)
        {
            var upsertRecipeRequest = new UpsertRecipeRequest(recipe);
            var response = _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            Assert.That(response.Value, Is.Not.Null);
        }
    }
}
