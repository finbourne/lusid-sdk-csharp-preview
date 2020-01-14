using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests
{
    [TestFixture]
    public class LusidApiFactoryTests
    {
        private ILusidApiFactory _factory;

        [OneTimeSetUp]
        public void SetUp()
        {
            _factory = LusidApiFactoryBuilder.Build("secrets.json");
        }

        [Test]
        public void Create_PortfoliosApi()
        {
            var api = _factory.Api<PortfoliosApi>();
            
            Assert.That(api, Is.Not.Null);
            Assert.That(api, Is.InstanceOf<PortfoliosApi>());
        }
        
        [Test]
        public void Create_TransactionPortfoliosApi()
        {
            var api = _factory.Api<TransactionPortfoliosApi>();
            
            Assert.That(api, Is.Not.Null);
            Assert.That(api, Is.InstanceOf<TransactionPortfoliosApi>());
        }

        class InvalidApi : IApiAccessor
        {
            public Configuration Configuration { get; set; }
            public string GetBasePath()
            {
                throw new NotImplementedException();
            }

            public ExceptionFactory ExceptionFactory { get; set; }
        }
        
        [Test]
        public void Invalid_Requested_Api_Throws()
        {
            Assert.That(() => _factory.Api<InvalidApi>(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Api_From_Interface()
        {
            var api = _factory.Api<ITransactionPortfoliosApi>();
            
            Assert.That(api, Is.Not.Null);
            Assert.That(api, Is.InstanceOf<TransactionPortfoliosApi>());
        }

        [Test]
        public void Api_From_Implementation()
        {
            var api = _factory.Api<TransactionPortfoliosApi>();
            
            Assert.That(api, Is.Not.Null);
            Assert.That(api, Is.InstanceOf<TransactionPortfoliosApi>());
        }

        [Test]
        public void InvalidTokenUrl_ThrowsException()
        {
            ApiConfiguration apiConfig = new ApiConfiguration
            {
                TokenUrl = "xyz"
            };

            Assert.That(
                () => new LusidApiFactory(apiConfig),
                Throws.InstanceOf<UriFormatException>().With.Message.EqualTo("Invalid Token Uri: xyz"));
        }

        [Test]
        public void InvalidApiUrl_ThrowsException()
        {
            ApiConfiguration apiConfig = new ApiConfiguration
            {
                TokenUrl = "http://finbourne.com",
                ApiUrl = "xyz"
            };

            Assert.That(
                () => new LusidApiFactory(apiConfig),
                Throws.InstanceOf<UriFormatException>().With.Message.EqualTo("Invalid LUSID Uri: xyz"));
        }

        [Test]
        public void ApiException_Converts_To_ProblemDetails()
        {
            try
            {
                var _ = _factory.Api<PortfoliosApi>().GetPortfolio("doesnt", "exist");
            }
            catch (ApiException e)
            {
                //    ApiException.ErrorContent contains a JSON serialized ErrorResponse
                LusidProblemDetails errorResponse = e.ProblemDetails();
                
                Assert.That(errorResponse.Detail, Does.Match("Portfolio with id exist in scope doesnt effective.*does not exist"));
                Assert.That(errorResponse.Name, Is.EqualTo("PortfolioNotFound"));
            }            
        }
        
        [Test]
        public void ApiException_Converts_To_ValidationProblemDetails()
        {
            try
            {
                var _ = _factory.Api<PortfoliosApi>().GetPortfolio("@£$@£%", "@@@@@@");
            }
            catch (ApiException e)
            {
                Assert.That(e.IsValidationProblem, Is.True, "Response should indicate that there was a validation error with the request");
                
                //    An ApiException.ErrorContent thrown because of a request validation contains a JSON serialized LusidValidationProblemDetails
                if (e.TryGetValidationProblemDetails(out var errorResponse))
                {
                    //Should identify that there was a validation error with the code
                    Assert.That(errorResponse.Errors, Contains.Key("code"));
                    Assert.That(errorResponse.Errors["code"].Single(), Is.EqualTo("Values for this field must be non-zero in length and be comprised of either alphanumeric characters, hyphens or underscores. For more information please consult the LUSID documentation."));
                    
                    //Should identify that there was a validation error with the scope
                    Assert.That(errorResponse.Errors, Contains.Key("scope"));
                    Assert.That(errorResponse.Errors["scope"].Single(), Is.EqualTo("Values for this field must be non-zero in length and be comprised of either alphanumeric characters, hyphens or underscores. For more information please consult the LUSID documentation."));
                
                    Assert.That(errorResponse.Detail, Does.Match("One or more of the bits of input data provided were not valid.*"));
                    Assert.That(errorResponse.Name, Is.EqualTo("InvalidParameterValue"));
                }
                else
                {
                    Assert.Fail("The request should have failed due to a validation error, and the validation details should be returned");
                }
            }
        }
        
        [Test]
        public void ApiException_Without_ErrorContent_Returns_Null()
        {
            var error = new ApiException();
            var errorResponse = error.ProblemDetails();
            
            Assert.That(errorResponse, Is.Null);
        }
        
        [Test]
        public void ApiException_With_Empty_ErrorContent_Returns_Null()
        {
            var error = new ApiException();
            var errorResponse = error.ProblemDetails();
            
            Assert.That(errorResponse, Is.Null);
        }

        [Test]
        public async Task Multi_Threaded_ApiFactory_Parallel()
        {
            var config = ApiConfigurationBuilder.Build("secrets.json");
            var provider = new ClientCredentialsFlowTokenProvider(config);
            var _ = await provider.GetAuthenticationTokenAsync();
            
            var date = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);

            var request = Enumerable.Range(0, 100).Select(i => new UpsertQuoteRequest(
                new QuoteId(
                    new QuoteSeriesId(
                        provider: "DataScope",
                        priceSource: "BankA",
                        instrumentId: "BBG000B9XRY4",
                        instrumentIdType: QuoteSeriesId.InstrumentIdTypeEnum.Figi,
                        quoteType: QuoteSeriesId.QuoteTypeEnum.Price,
                        field: "mid"),
                    effectiveAt: date.AddDays(i)),
                metricValue: new MetricValue(
                    value: 199.23,
                    unit: "USD"),
                lineage: "InternalSystem")).ToDictionary(k => k.QuoteId.EffectiveAt.ToString(), v => v);
            

            Parallel.For(0, 25, (i, state) =>
            {
                var configuration = new Configuration
                {
                    AccessToken = provider.GetLastToken().Token,
                    BasePath = config.ApiUrl
                };

                var factory = LusidApiFactoryBuilder.Build(configuration);
                var result = factory.Api<IQuotesApi>().UpsertQuotes("mt-scope", request);
                Assert.That(result.Failed, Is.Empty);
                
                Console.WriteLine($"{DateTimeOffset.UtcNow} {Thread.CurrentThread.ManagedThreadId} {result.Values.Count}");
            });
        }

        [Test]
        public async Task Multi_Threaded_ApiFactory_Tasks()
        {
            var config = ApiConfigurationBuilder.Build("secrets.json");
            var provider = new ClientCredentialsFlowTokenProvider(config);
            var _ = await provider.GetAuthenticationTokenAsync();
            
            var date = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);

            var request = Enumerable.Range(0, 100).Select(i => new UpsertQuoteRequest(
                new QuoteId(
                    new QuoteSeriesId(
                        provider: "DataScope",
                        priceSource: "BankA",
                        instrumentId: "BBG000B9XRY4",
                        instrumentIdType: QuoteSeriesId.InstrumentIdTypeEnum.Figi,
                        quoteType: QuoteSeriesId.QuoteTypeEnum.Price,
                        field: "mid"),
                    effectiveAt: date.AddDays(i)),
                metricValue: new MetricValue(
                    value: 199.23,
                    unit: "USD"),
                lineage: "InternalSystem")).ToDictionary(k => k.QuoteId.EffectiveAt.ToString(), v => v);

            var tasks = Enumerable.Range(0, 25).Select(x => Task.Run(() =>
            {
                var configuration = new Configuration
                {
                    AccessToken = provider.GetLastToken().Token,
                    BasePath = config.ApiUrl
                };
                
                var factory = LusidApiFactoryBuilder.Build(configuration);
                var result = factory.Api<IQuotesApi>().UpsertQuotes("mt-scope", request);
                Assert.That(result.Failed, Is.Empty);
                
                Console.WriteLine($"{DateTimeOffset.UtcNow} {Thread.CurrentThread.ManagedThreadId} {result.Values.Count}");
            }));

            Task.WaitAll(tasks.ToArray());
        }


    }
}