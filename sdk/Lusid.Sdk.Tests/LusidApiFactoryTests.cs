using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;
using Lusid.Sdk.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Lusid.Sdk.Tests
{
    [TestFixture]
    public class LusidApiFactoryTests
    {
        private ILusidApiFactory _factory;
        private const string RequestIdRegexPattern = "[a-zA-Z0-9]{13}:[0-9a-fA-F]{8}";
        

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
        public void ApiResponse_CanExtract_RequestId()
        {
            var apiResponse = _factory.Api<ApplicationMetadataApi>().GetLusidVersionsWithHttpInfo();
            var requestId = apiResponse.GetRequestId();
            StringAssert.IsMatch(RequestIdRegexPattern, requestId);
        }
        
        [Test]
        public void ApiResponseMissingHeader_ReturnsNull_RequestId()
        {
            var apiResponse = _factory.Api<ApplicationMetadataApi>().GetLusidVersionsWithHttpInfo();
            // Remove header containing access token
            apiResponse.Headers.Remove(ApiResponseExtensions.RequestIdHeader);
            var requestId = apiResponse.GetRequestId();
            Assert.That(requestId, Is.Null);
        }
        
        [Test]
        public void ApiException_CanExtract_RequestId()
        {
            try
            {
                var _ = _factory.Api<PortfoliosApi>().GetPortfolio("doesnt", "exist");
            }
            catch (ApiException e)
            {
                var requestId = e.GetRequestId();
                StringAssert.IsMatch(RequestIdRegexPattern, requestId);
            } 
        }
        
        [Test]
        public void ApiExceptionMalformedInsightsUrl_ReturnsNull_RequestId()
        {
            try
            {
                var _ = _factory.Api<PortfoliosApi>().GetPortfolio("doesnt", "exist");
            }
            catch (ApiException e)
            {
                var problemDetails = e.ProblemDetails();
                
                // Remove the InsightsURL which contains the requestId
                problemDetails.Instance = "";
                
                var apiExceptionMalformed = new ApiException(
                    errorCode: e.ErrorCode,
                    message: e.Message,
                    errorContent: JsonConvert.SerializeObject(problemDetails));

                var requestId = apiExceptionMalformed.GetRequestId();
                Assert.That(requestId, Is.Null);
            } 
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
        public void ApiException_Converts_To_ValidationProblemDetails_AllowedRegex()
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
                    Assert.That(errorResponse.Errors["code"].Single(), Is.EqualTo("Values for the field code must be comprised of either alphanumeric characters, hyphens or underscores. For more information please consult the documentation."));
                    
                    //Should identify that there was a validation error with the scope
                    Assert.That(errorResponse.Errors, Contains.Key("scope"));
                    Assert.That(errorResponse.Errors["scope"].Single(), Is.EqualTo("Values for the field scope must be comprised of either alphanumeric characters, hyphens or underscores. For more information please consult the documentation."));
                
                    Assert.That(errorResponse.Detail, Does.Match("One or more elements of the request were invalid.*"));
                    Assert.That(errorResponse.Name, Is.EqualTo("InvalidRequestFailure"));
                }
                else
                {
                    Assert.Fail("The request should have failed due to a validation error, and the validation details should be returned");
                }
            }
        }
        
        [Test]
        public void ApiException_Converts_To_ValidationProblemDetails_MaxLength()
        {
            try
            {
                var testScope = new string('a', 100);
                var testCode = new string('b', 100);
                var _ = _factory.Api<PortfoliosApi>().GetPortfolio(testScope, testCode);
            }
            catch (ApiException e)
            {
                Assert.That(e.IsValidationProblem, Is.True, "Response should indicate that there was a validation error with the request");
                
                //    An ApiException.ErrorContent thrown because of a request validation contains a JSON serialized LusidValidationProblemDetails
                if (e.TryGetValidationProblemDetails(out var errorResponse))
                {
                    //Should identify that there was a validation error with the code
                    Assert.That(errorResponse.Errors, Contains.Key("code"));
                    Assert.That(errorResponse.Errors["code"].Single(), Is.EqualTo("Values for the field code must be non-zero in length and have no more than 64 characters. For more information please consult the documentation."));
                    
                    //Should identify that there was a validation error with the scope
                    Assert.That(errorResponse.Errors, Contains.Key("scope"));
                    Assert.That(errorResponse.Errors["scope"].Single(), Is.EqualTo("Values for the field scope must be non-zero in length and have no more than 64 characters. For more information please consult the documentation."));
                
                    Assert.That(errorResponse.Detail, Does.Match("One or more elements of the request were invalid.*"));
                    Assert.That(errorResponse.Name, Is.EqualTo("InvalidRequestFailure"));
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

        [TestCase(1, 10)]
        [TestCase(100, 25, Explicit = true)]
        public void Multi_Threaded_ApiFactory_Tasks(int quoteCount, int threadCount)
        {
            var config = ApiConfigurationBuilder.Build("secrets.json");
            var provider = new ClientCredentialsFlowTokenProvider(config);
            
            var date = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);

            var request = Enumerable.Range(0, quoteCount).Select(i => new UpsertQuoteRequest(
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
                    value: 199.23m,
                    unit: "USD"),
                lineage: "InternalSystem")).ToDictionary(k => k.QuoteId.EffectiveAt.ToString(), v => v);

            var tasks = Enumerable.Range(0, threadCount).Select(x => Task.Run(() =>
            {
                var factory = LusidApiFactoryBuilder.Build(config.ApiUrl, provider);
                var result = factory.Api<IQuotesApi>().UpsertQuotes("mt-scope", request);
                Assert.That(result.Failed, Is.Empty);
                
                Console.WriteLine($"{DateTimeOffset.UtcNow} {Thread.CurrentThread.ManagedThreadId} {result.Values.Count}");
            }));

            Task.WaitAll(tasks.ToArray());
        }

        [Test, Explicit("Only an issue on .NET Core 2.2 on Linux / MacOS")]
        public void LinuxSocketLeakTest() // See DEV-7152
        {
            ApiConfiguration config = ApiConfigurationBuilder.Build("secrets.json");
            var provider = new ClientCredentialsFlowTokenProvider(config);

            var api = BuildApi();
            api.CreatePortfolioGroup("sdktest", new CreatePortfolioGroupRequest("TestGroup", displayName: "TestGroup"));

            // This loop should eventually throw a SocketException: "Address already in use" once all the sockets have been exhausted
            for (int i = 0; i < 50_000; i++)
            {
                api = BuildApi();
                PortfolioGroup result = api.GetPortfolioGroup("sdktest", "TestGroup");
                Assert.That(result, Is.Not.Null);

                // Option 1: force dispose of ApiClient
                //api.Configuration.ApiClient.Dispose();

                // Option 2: force all finalizers to run
                if (i % 100 == 0)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            /*** Local Functions ***/
            IPortfolioGroupsApi BuildApi()
            {
                // An instance of HttpClient is created within LusidApiFactory.Configuration.ApiClient.RestClient
                // which wasn't being disposed
                ILusidApiFactory factory = LusidApiFactoryBuilder.Build(config.ApiUrl, provider);
                IPortfolioGroupsApi api = factory.Api<IPortfolioGroupsApi>();
                return api;
            }
        }
        
        [Test]
        public void ApiResponse_CanExtract_DateHeader()
        {
            var apiResponse = _factory.Api<ApplicationMetadataApi>().GetLusidVersionsWithHttpInfo();
            var date = apiResponse.GetDate();
            Assert.IsNotNull(date);
        }

        [Test]
        public void ApiResponseMissingHeader_ReturnsNull_DateHeader()
        {
            var apiResponse = _factory.Api<ApplicationMetadataApi>().GetLusidVersionsWithHttpInfo();
            // Remove header containing access token
            apiResponse.Headers.Remove(ApiResponseExtensions.DateHeader);
            var date = apiResponse.GetDate();
            Assert.IsNull(date);
        }
    }
}