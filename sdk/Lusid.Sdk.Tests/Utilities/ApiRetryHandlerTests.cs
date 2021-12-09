using System.Net;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Utilities;
using NUnit.Framework;
using Polly;
using RestSharp;

namespace Lusid.Sdk.Tests.Utilities
{
    [TestFixture]
    public class ApiRetryHandlerTests
    {
        private LusidApiFactory _apiFactory;
        private readonly Policy<IRestResponse> _initialRetryPolicy = RetryConfiguration.RetryPolicy;
        private HttpListener _httpListener;
        private const string ListenerUriPrefix = "http://localhost:4444/";
        
        private static Policy<IRestResponse> GetTestRetryPolicy(
            PollyRetryTestUtil pollyRetryTestUtilReference, 
            int expectedNumberOfRetries = ApiRetryHandler.MaxRetryAttempts)
        {
            return Policy
                .HandleResult<IRestResponse>(ApiRetryHandler.GetInternalExceptionRetryCondition)
                .Retry(
                    retryCount: expectedNumberOfRetries,
                    (result, i) =>
                    {
                        pollyRetryTestUtilReference.RetryCount = i;
                    });
        }
    
        private class PollyRetryTestUtil
        {
            public int RetryCount { get; set; }
        }
        
        [SetUp]
        public void SetUp()
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(ListenerUriPrefix);
            
            var testApiConfig = TestLusidApiFactoryBuilder.CreateApiConfiguration(null);
            testApiConfig.ApiUrl = ListenerUriPrefix;
            
            _apiFactory = new LusidApiFactory(testApiConfig);
        }
        
        [Test]
        public void CallGetPortfoliosApi_WhenHttpStatusIs400AndRetryConditionIsDefault_ThrowsApiExceptionWithoutRetry()
        {
            _httpListener.Start();
            
            _httpListener.BeginGetContext(result =>
            {
                var listener = (HttpListener) result.AsyncState;
                // Call EndGetContext to complete the asynchronous operation.
                var context = listener.EndGetContext(result);

                // Obtain a response object.
                var response = context.Response;

                // Construct a response.
                const string apiResponseString = "{\"some\": \"JsonResponseHere\"}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(apiResponseString);
                
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                response.StatusCode = 400;
                
                var output = response.OutputStream;
                output.Write(buffer,0,buffer.Length);
                // You must close the output stream.
                output.Close();
                
            }, _httpListener);
            
            var counter = new PollyRetryTestUtil();
            RetryConfiguration.RetryPolicy = GetTestRetryPolicy(counter);

            // This will still fail at deserialization
            var exception = Assert.Throws<ApiException>(
                () => _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any")
                );
            
            Assert.That(exception.ErrorContent, Is.EqualTo("{\"some\": \"JsonResponseHere\"}"));
            Assert.That(exception.ErrorCode, Is.EqualTo(400));
            Assert.That(counter.RetryCount, Is.EqualTo(0));
        }

        [Test]
        public void CallGetPortfoliosApi_WhenHttpStatusIs200AndRetryConditionIsDefault_NoRetryIsTriggeredOnDefaultPolicy()
        {
            _httpListener.Start();
            _httpListener.BeginGetContext(result =>
            {
                var listener = (HttpListener) result.AsyncState;
                // Call EndGetContext to complete the asynchronous operation.
                var context = listener.EndGetContext(result);

                // Obtain a response object.
                var response = context.Response;

                // Construct a response.
                const string apiResponseString = "{\"some\": \"JsonResponseHere\"}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(apiResponseString);
                
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                response.StatusCode = 200;
                
                var output = response.OutputStream;
                output.Write(buffer,0,buffer.Length);
                // You must close the output stream.
                output.Close();
                
            }, _httpListener);
            
            var counter = new PollyRetryTestUtil();
            RetryConfiguration.RetryPolicy = GetTestRetryPolicy(counter);

            // This will still fail at deserialization
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");
            
            Assert.That(counter.RetryCount, Is.EqualTo(0));
        }

        [Test]
        public void CallGetPortfoliosApi_WhenApiResponseCrashesHttpClient_PollyIsTriggered()
        {
            const int expectedNumberOfRetries = ApiRetryHandler.MaxRetryAttempts;
            _httpListener.Start();
            for (var i = 0; i < expectedNumberOfRetries + 1; i++)
            {
                 _httpListener.BeginGetContext(result =>
                {
                    var listener = (HttpListener) result.AsyncState;
                    // Call EndGetContext to complete the asynchronous operation.
                    var context = listener.EndGetContext(result);

                    // Obtain a response object.
                    var response = context.Response;

                    // Abort the response. This returns 0 status code.
                    response.Abort();
                }, _httpListener);
            }
            
            var counter = new PollyRetryTestUtil();
            RetryConfiguration.RetryPolicy = GetTestRetryPolicy(counter, expectedNumberOfRetries);

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(counter.RetryCount, Is.EqualTo(expectedNumberOfRetries));
            // In the future 0 error codes with throw an error after retries exceeded
            Assert.That(sdkResponse, Is.Null);
        }

        [Test]
        public void UsePolicyWrap_WhenCallingGetPortfolio_BothPoliciesAreUsed()
        {
            
        }
        

        [Test]
        public void CreateLusidFactory_WhenRetryPolicyIsNull_AssignsDefaultRetryPolicy()
        {

            RetryConfiguration.RetryPolicy = null;
            
            var newFactory = new LusidApiFactory(new Configuration());

            Assert.That(RetryConfiguration.RetryPolicy, Is.Not.Null);
        }
        
        [Test]
        public void CreateLusidFactory_WhenRetryPolicyIsAlreadyAssigned_ExistingRetryPolicyIsUsed()
        {
            var testPolicy = Policy.HandleResult<IRestResponse>(response => true).Retry();
            
            RetryConfiguration.RetryPolicy = testPolicy;
            var newFactory = new LusidApiFactory(new Configuration());

            Assert.That(RetryConfiguration.RetryPolicy, Is.EqualTo(testPolicy));
        }

        [TearDown]
        public void TearDown()
        {
            // Make sure Polly is reset to what it was initially
            RetryConfiguration.RetryPolicy = _initialRetryPolicy;
            // Request is processed at this point and can be closed
            _httpListener.Close();
        }
    }
}