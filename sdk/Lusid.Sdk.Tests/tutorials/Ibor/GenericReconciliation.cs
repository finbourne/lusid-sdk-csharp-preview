using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Ibor
{
    [TestFixture]
    public class GenericReconciliation : TutorialBase
    {
        private InstrumentLoader _instrumentLoader;
        private IList<string> _instrumentIds;
        private readonly string _portfolioOneScope = "testPortfolio1" + new Guid();
        private readonly string _portfolioTwoScope = "testPortfolio2" + new Guid();
        private readonly string _portfolioCode = Guid.NewGuid().ToString();
        private DateTimeOffset _effectiveAt;

        [OneTimeSetUp]
        public void SetUp()
        {
            _instrumentLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = _instrumentLoader.LoadInstruments();
        }

        /// <summary>
        /// Perform a reconciliation on two identical portfolios except for the Address Key for trader name being scope dependent.
        /// I.e., "Transaction/testPortfolio1/TraderName" = "John Doe" and "Transaction/testPortfolio2/TraderName" = "John Doe"
        /// Unless a mapping rule is provided between these two address keys in the reconciliation then both keys will appear
        /// as failures in the aggregation.
        /// </summary>
        [LusidFeature("F20-2")]
        [Test]
        public void RemappingProperties()
        {
            var quotePrice = 105m;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // date of transaction
            var traderName = "John Doe";

            // Generate two identical portfolios
            var valuationRequestOne = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode, transactionDate,
                quotePrice, traderName);
            var valuationRequestTwo = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode, transactionDate,
                quotePrice, traderName);

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestOne, valuationRequestTwo);
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);

            // Get the reconciliation of our equity. 
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // The trader name properties on the two portfolios have different names and both have been compared upon. 
            Assert.That(equityComparison.ResultComparison.ContainsKey($"Transaction/{_portfolioOneScope}/TraderName"));
            Assert.That(equityComparison.ResultComparison.ContainsKey($"Transaction/{_portfolioTwoScope}/TraderName"));

            // Assert that the reconciliation failed on comparing the properties.
            Assert.That(equityComparison.ResultComparison[$"Transaction/{_portfolioOneScope}/TraderName"].ToString()
                .Contains("Failed"));
            Assert.That(equityComparison.ResultComparison[$"Transaction/{_portfolioTwoScope}/TraderName"].ToString()
                .Contains("Failed"));

            // As we have a property which has a portfolio dependant name, need to tell the portfolio that this is the case in order to map them together.
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // create the new reconciliation request with the mapping 
            reconciliation = new ReconciliationRequest(valuationRequestOne, valuationRequestTwo,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping});
            reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);

            equityComparison = reconciliationResponse.Comparisons.Single();

            // Check that all the comparisons return an exact match
            Assert.That(equityComparison.ResultComparison.All(x => x.Value.ToString().Equals("ExactMatch")));

            // Check that the property strings where correctly matched.
            // The difference and comparison dictionaries retain the name of the Right valuation result.
            Assert.That(equityComparison.Left.ContainsKey($"Transaction/{_portfolioOneScope}/TraderName"));
            Assert.That(equityComparison.Right.ContainsKey($"Transaction/{_portfolioTwoScope}/TraderName"));
            Assert.That(equityComparison.Difference.ContainsKey($"Transaction/{_portfolioTwoScope}/TraderName"));
            Assert.That(!equityComparison.Difference.ContainsKey($"Transaction/{_portfolioOneScope}/TraderName"));
        }

        /// <summary>
        /// The default behaviour for comparing numeric values is for exact tolerance. This means only exactly matching
        /// values will match. 
        /// </summary>
        [LusidFeature("F20-3")]
        [Test]
        public void Numeric_Exact()
        {
            // The two portfolios disagree about the quote price.
            var quotePriceLeft = 105m;
            var quotePriceRight = 100m;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // date of transaction
            var traderName = "John Doe";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                transactionDate, quotePriceLeft, traderName);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                transactionDate, quotePriceRight, traderName);

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // Set the matching rules to use for each of the requested aggregates. 
            var rules = new List<ReconciliationRule>();

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping}, rules,
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // Assert that the reconciliation failed for PV, and that the difference is the absolute difference in the PV calculations 
            Assert.That(equityComparison.Difference["Valuation/PV"], Is.EqualTo(50));
            Assert.That(equityComparison.ResultComparison["Valuation/PV"].ToString(), Is.EqualTo("Failed"));
        }

        /// <summary>
        /// Numeric values can be compared within absolute tolerance. In this example two portfolios provide quotes of £105 and £100
        /// for an equity. The holding of 10 units results in "Valuation/PV" values of £1050 and £1000 respectively. These can be
        /// matched within a tolerance of £50.
        /// </summary>
        [LusidFeature("F20-4")]
        [Test]
        public void Numeric_AbsoluteDifference()
        {
            // The two portfolios disagree about the quote price.
            var quotePriceLeft = 105m;
            var quotePriceRight = 100m;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // date of transaction
            var traderName = "John Doe";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                transactionDate, quotePriceLeft, traderName);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                transactionDate, quotePriceRight, traderName);

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // Instead we can set a rule which will allow a match within a provided tolerance. 

            var pvRule = new ReconcileNumericRule(ReconcileNumericRule.ComparisonTypeEnum.AbsoluteDifference, 50m,
                new AggregateSpec("Valuation/PV", AggregateSpec.OpEnum.Value),
                ReconciliationRule.RuleTypeEnum.ReconcileNumericRule);

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping}, new List<ReconciliationRule>() {pvRule},
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // Assert that the reconciliation matched within tolerance for PV, and that the difference is the PV of the right hand portfolio minus the left hand portfolio 
            Assert.That(equityComparison.Difference["Valuation/PV"], Is.EqualTo(50));
            Assert.That(equityComparison.ResultComparison["Valuation/PV"].ToString(),
                Is.EqualTo("MatchWithinTolerance"));
        }

        /// <summary>
        /// Numeric values can be compared within relative tolerance. In this example two portfolios provide quotes of £105 and £100
        /// for an equity. The holding of 10 units results in "Valuation/PV" values of £1050 and £1000 respectively.
        /// The formula used to compute the relative difference is 1.0 - minimum(lhs,rhs)/maximum(lhs, rhs).
        /// For this example 1 - 1000/1050 is approx 0.047 (4.7%). This allows us to match within a 5% tolerance.
        /// </summary>
        [LusidFeature("F20-5")]
        [Test]
        public void Numeric_RelativeDifference()
        {
            // The two portfolios disagree about the quote price.
            var quotePriceLeft = 105m;
            var quotePriceRight = 100m;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // date of transaction
            var traderName = "John Doe";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                transactionDate, quotePriceLeft, traderName);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                transactionDate, quotePriceRight, traderName);

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // Instead we can set a rule which will allow a match within a provided relative tolerance. 
            var relativeRule = new ReconcileNumericRule(ReconcileNumericRule.ComparisonTypeEnum.RelativeDifference,
                0.05m,
                new AggregateSpec("Valuation/PV", AggregateSpec.OpEnum.Value));

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping},
                new List<ReconciliationRule>() {relativeRule},
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // Assert that the reconciliation matches within tolerance for PV, and that the difference is the PV of the right hand portfolio minus the left hand portfolio 
            Assert.That(equityComparison.Difference["Valuation/PV"], Is.LessThan(0.05));
            Assert.That(equityComparison.ResultComparison["Valuation/PV"].ToString(),
                Is.EqualTo("MatchWithinTolerance"));
        }

        /// <summary>
        /// In this example a Result0D is compared against a Decimal.
        /// The PV computed internally "Valuation/PV" using an upserted quote has a value and units.
        /// The "UnitResult/ClientCustomPV" upserted to the structured results store is a Decimal without units. 
        /// In the strictest sense these are incompatible types, however they can be successfully reconciled within tolerance 
        /// with a numeric difference rule.
        /// </summary>
        [LusidFeature("F20-6")]
        [Test]
        public void Numeric_ResultsVersusDecimals()
        {
            var quotePrice = 101;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero);
            var traderName = "John Doe";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                transactionDate, quotePrice, traderName);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                transactionDate, quotePrice, traderName, true);

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");
            // Set the mapping between properties in the two portfolios. 
            var mappingNumeric = new ReconciliationLeftRightAddressKeyPair($"Valuation/PV",
                $"UnitResult/ClientCustomPV");

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping, mappingNumeric}, null,
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // Even though the values are identical we get a failed result by default. This is due to the Result0D and decimal 
            // not actually being equivalent.
            Assert.That(equityComparison.Left["Valuation/PV"],
                Is.EqualTo(equityComparison.Right["UnitResult/ClientCustomPV"]));
            Assert.That(equityComparison.Difference["UnitResult/ClientCustomPV"], Is.EqualTo(0.0));
            Assert.That(equityComparison.ResultComparison["UnitResult/ClientCustomPV"], Is.EqualTo("Failed"));

            // This can be handled by the introduction of a numeric tolerance comparison rule.
            var numericRule = new ReconcileNumericRule(ReconcileNumericRule.ComparisonTypeEnum.AbsoluteDifference, 0.1m,
                new AggregateSpec("UnitResult/ClientCustomPV", AggregateSpec.OpEnum.Value));

            // create the reconciliation request
            reconciliation = new ReconciliationRequest(
                valuationRequestLeft,
                valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping, mappingNumeric},
                new List<ReconciliationRule>() {numericRule},
                new List<string>() {TestDataUtilities.InstrumentName});
            reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            equityComparison = reconciliationResponse.Comparisons.Single();

            // Even though the values are identical we get a failed result by default. This is due to the Result0D and decimal 
            // not actually being equivilent.
            Assert.That(equityComparison.Left["Valuation/PV"],
                Is.EqualTo(equityComparison.Right["UnitResult/ClientCustomPV"]));
            Assert.That(equityComparison.Difference["UnitResult/ClientCustomPV"], Is.EqualTo(0.0));
            Assert.That(equityComparison.ResultComparison["UnitResult/ClientCustomPV"],
                Is.EqualTo("MatchWithinTolerance"));
        }

        /// <summary>
        /// DateTimes can be tested either for exact matching or for matching within an absolute tolerance.
        /// In the case of absolute tolerance the tolerance is specified in number of days.
        /// For sub-day tolerances fractional values may be input. In this example two valuation datetimes an hour apart
        /// are successfully reconciled within a tolerance of 2 hours.
        /// </summary>
        [LusidFeature("F20-7")]
        [Test]
        public void DateTime_AbsoluteDifference()
        {
            var quotePrice = 100m;
            // Two valuations an hour apart
            var valuationDateLeft =
                new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // datetime of transaction in portfolio one
            var valuationDateRight =
                new DateTimeOffset(2022, 2, 1, 1, 0, 0, TimeSpan.Zero); // datetime of transaction in portfolio two
            var traderName = "John Doe";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                valuationDateLeft, quotePrice, traderName, true);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                valuationDateRight, quotePrice, traderName, true);

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // Set a absolute difference date time rule with a tolerance of 2 hours.
            var dateTimeRule = new ReconcileDateTimeRule(ReconcileDateTimeRule.ComparisonTypeEnum.AbsoluteDifference,
                2 / 24m,
                new AggregateSpec($"Analytic/default/ValuationDate", AggregateSpec.OpEnum.Value),
                ReconciliationRule.RuleTypeEnum.ReconcileDateTimeRule);
            var rules = new List<ReconciliationRule>() {dateTimeRule};

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping}, rules,
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // The difference is the left datetime minus the right datetime
            Assert.That(equityComparison.Difference[$"Analytic/default/ValuationDate"],
                Is.EqualTo($"{valuationDateLeft - valuationDateRight}"));
            Assert.That(equityComparison.ResultComparison[$"Analytic/default/ValuationDate"].ToString(),
                Is.EqualTo("MatchWithinTolerance"));
        }

        /// <summary>
        /// Strings naturally have a distinct set of matching criteria to numeric types. This example demonstrates the possible matching patterns.
        /// The example here considers the case where the trader name is {first name} {last name} on the left-hand portfolio and {title} {first name} {last name}
        /// on the right-hand portfolio. The string contains rule allows for these to be considered a match if the right portfolio result is a sub string of the left.
        /// </summary>
        [Test]
        [LusidFeature("F20-8")]
        public void String_Contains()
        {
            var quotePrice = 100m;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // date of transaction
            // disagree about trader name
            var traderNameLeft = "Mr. John Doe";
            var traderNameRight = "John Doe";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                transactionDate, quotePrice, traderNameLeft, true);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                transactionDate, quotePrice, traderNameRight, true);

            // Set the matching rules to use for each of the requested aggregates. Initially let this be the default values.
            var rules = new List<ReconciliationRule>();

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping}, rules,
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // Assert that the reconciliation failed for the trader name property, and that the difference is formatted correctly 
            Assert.That(equityComparison.Difference[$"Transaction/{_portfolioTwoScope}/TraderName"],
                Is.EqualTo($"-({traderNameLeft}, {traderNameRight})"));
            Assert.That(equityComparison.ResultComparison[$"Transaction/{_portfolioTwoScope}/TraderName"].ToString(),
                Is.EqualTo("Failed"));


            // Reattempt the valuation expect this time apply a criteria rule for matching the strings.

            var stringComparisonRule = new ReconcileStringRule(ReconcileStringRule.ComparisonTypeEnum.Contains, null,
                new AggregateSpec($"Transaction/{_portfolioTwoScope}/TraderName", AggregateSpec.OpEnum.Value),
                ReconciliationRule.RuleTypeEnum.ReconcileStringRule);

            // create the new reconciliation request with a "Contains" criteria
            reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping},
                new List<ReconciliationRule>() {stringComparisonRule},
                new List<string>() {TestDataUtilities.InstrumentName});
            reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            equityComparison = reconciliationResponse.Comparisons.Single();

            // Assert that the reconciliation failed for the trader name property, and that the difference is formatted correctly 
            Assert.That(equityComparison.Difference[$"Transaction/{_portfolioTwoScope}/TraderName"],
                Is.EqualTo($"{traderNameLeft} contains {traderNameRight}"));
            Assert.That(equityComparison.ResultComparison[$"Transaction/{_portfolioTwoScope}/TraderName"].ToString(),
                Is.EqualTo("MatchWithinTolerance"));

            // The contain rule only works for the case where the left-hand portfolio value contains the right-hand side value
            // create the new reconciliation request with a "Contains" criteria

            var swappedMapping = new ReconciliationLeftRightAddressKeyPair(
                $"Transaction/{_portfolioTwoScope}/TraderName",
                $"Transaction/{_portfolioOneScope}/TraderName");
            reconciliation = new ReconciliationRequest(valuationRequestRight, valuationRequestLeft,
                new List<ReconciliationLeftRightAddressKeyPair>() {swappedMapping},
                new List<ReconciliationRule>() {stringComparisonRule},
                new List<string>() {TestDataUtilities.InstrumentName});
            reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            equityComparison = reconciliationResponse.Comparisons.Single();

            // When swapping the portfolios for valuation, the Contain fails as John Doe does not contain Mr. John Doe
            Assert.That(equityComparison.Difference[$"Transaction/{_portfolioOneScope}/TraderName"],
                Is.EqualTo($"-({traderNameRight}, {traderNameLeft})"));
            Assert.That(equityComparison.ResultComparison[$"Transaction/{_portfolioOneScope}/TraderName"].ToString(),
                Is.EqualTo("Failed"));
        }

        /// <summary>
        /// Another possible matching structure is when there is ambiguity in how one of the portfolios will label a property and several
        /// possible alternatives can arise. Continuing to use the example of a name, one portfolio might be consistent in using {first name}
        /// {last name} but a number of alternatives are possible. e.g. John Doe could be allowed to match any of Mr. John Doe, J. Doe, Mr. Doe.
        /// </summary>
        [Test]
        [LusidFeature("F20-9")]
        public void String_IsOneOf()
        {
            var quotePrice = 100m;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // date of transaction
            // disagree about trader name
            var traderNameLeft = "John Doe";
            var traderNameRight = "J. Doe";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                transactionDate, quotePrice, traderNameLeft, true);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                transactionDate, quotePrice, traderNameRight, true);

            // Set the matching rules to use for each of the requested aggregates. 
            // Allow "John Doe" in the lhs to successfully match "Mr. John Doe", "J. Doe" or "Mr. Doe" in the rhs.
            var options = new Dictionary<string, List<string>>()
                {{"John Doe", new List<string>() {"Mr. John Doe", "J. Doe", "Mr. Doe"}}};
            var oneOfRule = new ReconcileStringRule(ReconcileStringRule.ComparisonTypeEnum.IsOneOf, options,
                new AggregateSpec($"Transaction/{_portfolioTwoScope}/TraderName", AggregateSpec.OpEnum.Value),
                ReconciliationRule.RuleTypeEnum.ReconcileStringRule);
            var rules = new List<ReconciliationRule>() {oneOfRule};

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping}, rules,
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // Assert that the reconciliation succeeded for the trader name property, and that the difference contains the 
            // string in the rhs which matched the lhs. 
            Assert.That(equityComparison.Difference[$"Transaction/{_portfolioTwoScope}/TraderName"],
                Is.EqualTo($"{traderNameRight}"));
            Assert.That(equityComparison.ResultComparison[$"Transaction/{_portfolioTwoScope}/TraderName"].ToString(),
                Is.EqualTo("MatchWithinTolerance"));
        }

        /// <summary>
        /// Like the contains case but where the case is also of no consequence. The example here demonstrated the
        /// successful matching of Mr. John Doe on the lhs and JOHN DOE on the rhs. 
        /// </summary>
        [Test]
        [LusidFeature("F20-10")]
        public void String_ContainsAllCase()
        {
            var quotePrice = 100m;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // date of transaction
            // portfolios disagree but rhs is a substring of lhs if case is ignored.
            var traderNameLeft = "Mr. John Doe";
            var traderNameRight = "JOHN DOE";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                transactionDate, quotePrice, traderNameLeft, true);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                transactionDate, quotePrice, traderNameRight, true);

            // Set the matching rules to use for each of the requested aggregates. Initially let this be the default values.
            var containsRule = new ReconcileStringRule(ReconcileStringRule.ComparisonTypeEnum.ContainsAnyCase, null,
                new AggregateSpec($"Transaction/{_portfolioTwoScope}/TraderName", AggregateSpec.OpEnum.Value),
                ReconciliationRule.RuleTypeEnum.ReconcileStringRule);
            var rules = new List<ReconciliationRule>() {containsRule};

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping}, rules,
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // Assert that the reconciliation succeeds within tolerance for the trader name property, and that the difference is formatted correctly 
            Assert.That(equityComparison.Difference[$"Transaction/{_portfolioTwoScope}/TraderName"],
                Is.EqualTo($"{traderNameLeft} contains {traderNameRight}"));
            Assert.That(equityComparison.ResultComparison[$"Transaction/{_portfolioTwoScope}/TraderName"].ToString(),
                Is.EqualTo("MatchWithinTolerance"));
        }

        /// <summary>
        /// The case insensitive rule allows strings to reconcile when they only disagree on case. The example here demonstrates this
        /// for "John Doe" and "john doe".
        /// </summary>
        [LusidFeature("F20-11")]
        [Test]
        public void String_CaseInsensitive()
        {
            var quotePrice = 100m;
            var transactionDate = new DateTimeOffset(2022, 2, 1, 0, 0, 0, TimeSpan.Zero); // date of transaction
            // The two portfolios disagree because of the case.
            var traderNameLeft = "John Doe";
            var traderNameRight = "john doe";

            // Generate two portfolios and their valuation requests.
            var valuationRequestLeft = GeneratePortfolioTransactions(_portfolioOneScope, _portfolioCode,
                transactionDate, quotePrice, traderNameLeft, true);
            var valuationRequestRight = GeneratePortfolioTransactions(_portfolioTwoScope, _portfolioCode,
                transactionDate, quotePrice, traderNameRight, true);

            // Set the matching rules to use for each of the requested aggregates. Initially let this be the default values.
            var containsRule = new ReconcileStringRule(ReconcileStringRule.ComparisonTypeEnum.CaseInsensitive, null,
                new AggregateSpec($"Transaction/{_portfolioTwoScope}/TraderName", AggregateSpec.OpEnum.Value),
                ReconciliationRule.RuleTypeEnum.ReconcileStringRule);
            var rules = new List<ReconciliationRule>() {containsRule};

            // Set the mapping between properties in the two portfolios. 
            var mapping = new ReconciliationLeftRightAddressKeyPair($"Transaction/{_portfolioOneScope}/TraderName",
                $"Transaction/{_portfolioTwoScope}/TraderName");

            // create the reconciliation request
            var reconciliation = new ReconciliationRequest(valuationRequestLeft, valuationRequestRight,
                new List<ReconciliationLeftRightAddressKeyPair>() {mapping}, rules,
                new List<string>() {TestDataUtilities.InstrumentName});
            var reconciliationResponse = _apiFactory.Api<ReconciliationsApi>().ReconcileGeneric(reconciliation);
            var equityComparison = reconciliationResponse.Comparisons.Single();

            // Assert that the reconciliation succeeds within tolerance for the trader name property, and that the difference is formatted correctly 
            Assert.That(equityComparison.Difference[$"Transaction/{_portfolioTwoScope}/TraderName"],
                Is.EqualTo($"{traderNameLeft}=={traderNameRight}"));
            Assert.That(equityComparison.ResultComparison[$"Transaction/{_portfolioTwoScope}/TraderName"].ToString(),
                Is.EqualTo("MatchWithinTolerance"));
        }

        /// <summary>
        /// We are going to construct a simple portfolio with a single equity for demonstrating the capabilities of the reconciliation engine.
        /// This consists of a single equity whose value on a given valuation date is upserted.
        /// The quote price is a provided price for the value of the equity on the valuation date.
        /// The trader name is a subholding key for the portfolio and has a portfolio specific address key.
        /// The upsertedUnitlessPv bool controls whether the valuation request will
        /// ask for the PV to be returned as "Valuation/PV" as Result0D (x, GBP) or as a Decimal x without units.
        /// </summary>
        /// <param name="scope"> The scope of the portfolio </param>
        /// <param name="code"> the code of the portfolio </param>
        /// <param name="valuationDate"> Date on which the valuation is performed </param>
        /// <param name="quotePrice"> The price quote for the equity</param>
        /// <param name="traderName"> The name of the trader who booked the transactions.</param>
        /// <param name="upsertedUnitlessPv"> If this is true the provided PV value is upserted to the SRS as a decimal</param>
        private ValuationRequest GeneratePortfolioTransactions(string scope, string code,
            DateTimeOffset valuationDate, decimal quotePrice, string traderName,
            bool upsertedUnitlessPv = false)
        {
            // Create a new property on the transactions for who booked them. 
            var propertyCode = "TraderName";
            try
            {
                _apiFactory.Api<PropertyDefinitionsApi>()
                    .GetPropertyDefinition("Transaction", scope, propertyCode);
            }
            catch (ApiException apiEx)
            {
                if (apiEx.ErrorCode == 404)
                {
                    //    Property definition doesn't exist (returns 404), so create one
                    //    Details of the property to be created
                    var propertyDefinition = new CreatePropertyDefinitionRequest(
                        domain: CreatePropertyDefinitionRequest.DomainEnum.Transaction,
                        scope: scope,
                        lifeTime: CreatePropertyDefinitionRequest.LifeTimeEnum.Perpetual,
                        code: propertyCode,
                        valueRequired: false,
                        displayName: code,
                        dataTypeId: new ResourceId("system", "string"));
                    _apiFactory.Api<PropertyDefinitionsApi>().CreatePropertyDefinition(propertyDefinition);
                }
                else
                {
                    throw apiEx;
                }
            }

            //    CREATE our portfolio

            //    Effective date of the portfolio, this is the date the portfolio was created and became live.  
            _effectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
            var portfolioRequest = new CreateTransactionPortfolioRequest(
                code: _portfolioCode,
                displayName: $"Portfolio-{_portfolioCode}",
                baseCurrency: "GBP",
                created: _effectiveAt,
                subHoldingKeys: new List<string>() {$"Transaction/{scope}/{propertyCode}"}
            );

            var portfolio = _transactionPortfoliosApi.CreatePortfolio(scope, portfolioRequest);
            Assert.That(portfolio?.Id.Code, Is.EqualTo(_portfolioCode));

            // create transactions on an instrument
            var transactionSpecs = new[]
            {
                (Id: _instrumentIds[0], Price: 100, Units: 10,
                    TradeDate: _effectiveAt),
            };

            // add the transaction property 
            string traderNameKey = $"Transaction/{scope}/{propertyCode}";
            var properties = new Dictionary<string, PerpetualProperty>
            {
                {traderNameKey, new PerpetualProperty(traderNameKey, new PropertyValue(traderName))}
            };
            var newTransactions = transactionSpecs.Select(id =>
                BuildTransactionRequest(id.Id, id.Units, id.Price, "GBP", id.TradeDate, "Buy", properties));
            _apiFactory.Api<ITransactionPortfoliosApi>().UpsertTransactions(scope, code, newTransactions.ToList());

            // create and upsert quotes for the price of these instruments 
            var quoteScope = Guid.NewGuid().ToString();
            var quote = new UpsertQuoteRequest(
                new QuoteId(
                    new QuoteSeriesId(
                        provider: "DataScope",
                        instrumentId: _instrumentIds[0],
                        instrumentIdType: QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId,
                        quoteType: QuoteSeriesId.QuoteTypeEnum.Price, field: "mid"
                    ),
                    effectiveAt: valuationDate
                ),
                metricValue: new MetricValue(
                    value: quotePrice,
                    unit: "GBP"
                )
            );
            //    Upload the quote
            _apiFactory.Api<IQuotesApi>().UpsertQuotes(quoteScope,
                new Dictionary<string, UpsertQuoteRequest>() {{Guid.NewGuid().ToString(), quote}});


            // CREATE and UPSERT a unitless PV to the result store 

            string dataScope = "scope-" + Guid.NewGuid();
            string resultType = "UnitResult/Analytic";
            string documentCode = "document-1";
            var upsertedPvValue = quotePrice * 10.0m;

            DataMapKey dataMapKey = new DataMapKey("1.0.0", "test-code");
            DataMapping dataMapping = new DataMapping(new List<DataDefinition>
            {
                new DataDefinition("UnitResult/LusidInstrumentId", "LusidInstrumentId", "string", "Unique"),
                new DataDefinition("UnitResult/ClientCustomPV", "ClientVal", "decimal", "Leaf"),
            });
            var request = new CreateDataMapRequest(dataMapKey, dataMapping);
            _structuredResultDataApi.CreateDataMap(dataScope,
                new Dictionary<string, CreateDataMapRequest> {{"dataMapKey", request}});
            string document = $"LusidInstrumentId, ClientVal\n" +
                              $"{_instrumentIds[0]}, {upsertedPvValue}"; // Note the LusidInstrumentId the previously defined instrument.
            StructuredResultData structuredResultData =
                new StructuredResultData("csv", "1.0.0", documentCode, document, dataMapKey);
            StructuredResultDataId structResultDataId =
                new StructuredResultDataId("Client", documentCode, valuationDate, resultType);
            var upsertDataRequest = new UpsertStructuredResultDataRequest(structResultDataId, structuredResultData);
            _structuredResultDataApi.UpsertStructuredResultData(dataScope,
                new Dictionary<string, UpsertStructuredResultDataRequest> {{documentCode, upsertDataRequest}});
            string resourceKey = "UnitResult/*";
            var resultDataKeyRule = new ResultDataKeyRule(structResultDataId.Source, dataScope, structResultDataId.Code,
                resourceKey: resourceKey, documentResultType: resultType,
                resultKeyRuleType: ResultKeyRule.ResultKeyRuleTypeEnum.ResultDataKeyRule);
            var pricingContext = new PricingContext(resultDataRules: new List<ResultKeyRule>() {resultDataKeyRule});

            //    CREATE and UPSERT recipe for valuation
            string recipeScope = scope + "-recipe";
            var recipe = new ConfigurationRecipe
            (
                scope: recipeScope,
                code: "DataScope_Recipe",
                market: new MarketContext
                {
                    Suppliers = new MarketContextSuppliers
                    {
                        Equity = "DataScope"
                    },
                    Options = new MarketOptions(
                        defaultScope: quoteScope,
                        defaultSupplier: "DataScope",
                        defaultInstrumentCodeType: "LusidInstrumentId"
                    )
                },
                pricing: upsertedUnitlessPv ? pricingContext : null
            );

            //    Upload recipe to Lusid 
            var upsertRecipeRequest = new UpsertRecipeRequest(recipe);
            var response = _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);

            var metrics = new List<AggregateSpec>
            {
                new AggregateSpec(TestDataUtilities.InstrumentName, AggregateSpec.OpEnum.Value),
                new AggregateSpec("Analytic/default/ValuationDate", AggregateSpec.OpEnum.Value),
                new AggregateSpec($"Transaction/{scope}/TraderName", AggregateSpec.OpEnum.Value),
            };
            // Determine if want to retrieve a Result0D or Decimal PV
            if (upsertedUnitlessPv)
            {
                metrics.Add(new AggregateSpec("UnitResult/ClientCustomPV", AggregateSpec.OpEnum.Value));
            }
            else
            {
                metrics.Add(new AggregateSpec("Valuation/PV", AggregateSpec.OpEnum.Value));
            }

            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(recipeScope, "DataScope_Recipe"),
                metrics: metrics,
                valuationSchedule: new ValuationSchedule(effectiveAt: valuationDate),
                groupBy: new List<string> {"Instrument/default/Name"},
                filters: new List<PropertyFilter>
                {
                    new PropertyFilter(TestDataUtilities.LusidInstrumentIdentifier, PropertyFilter.OperatorEnum.Equals,
                        _instrumentIds[0], PropertyFilter.RightOperandTypeEnum.Absolute)
                },
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, code)}
            );

            return valuationRequest;
        }

        public static TransactionRequest BuildTransactionRequest(
            string instrumentId,
            decimal units,
            decimal price,
            string currency,
            DateTimeOrCutLabel tradeDate,
            string transactionType,
            Dictionary<string, PerpetualProperty> properties)
        {
            string LusidInstrumentIdentifier = "Instrument/default/LusidInstrumentId";
            return new TransactionRequest(
                transactionId: Guid.NewGuid().ToString(),
                type: transactionType,
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [LusidInstrumentIdentifier] = instrumentId
                },
                transactionDate: tradeDate,
                settlementDate: tradeDate,
                units: units,
                transactionPrice: new TransactionPrice(price, TransactionPrice.TypeEnum.Price),
                totalConsideration: new CurrencyAndAmount(price * units, currency),
                source: "Broker",
                properties: properties);
        }

        [TearDown]
        public void TearDown()
        {
            _portfoliosApi.DeletePortfolio(_portfolioOneScope, _portfolioCode);
            _portfoliosApi.DeletePortfolio(_portfolioTwoScope, _portfolioCode);
        }
    }
}