using System;
using System.Net;
using System.Threading;
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
        [Explicit("This test passes locally but not in the pipeline for unknown reasons. Will be marked as explicit until resolved.")]
        public void CallGetPortfoliosApi_WhenPollyRetryPolicyConfigured_PollyIsTriggered()
        {
            const int numberOfRetries = ApiRetryHandler.MaxRetryAttempts;
            var currentApiCall = 0;
            const int expectedNumberOfApiCalls = numberOfRetries + 1;
            _httpListener.Start();
            for (var i = 0; i < expectedNumberOfApiCalls; i++)
            {
                 _httpListener.BeginGetContext(result =>
                {
                    currentApiCall++;
                    var listener = (HttpListener) result.AsyncState;
                    // Call EndGetContext to complete the asynchronous operation.
                    var context = listener.EndGetContext(result);

                    // Obtain a response object.
                    var response = context.Response;

                    // Abort the response. This returns 0 status code.
                    response.Abort();
                }, _httpListener);
            }

            var testRetryPolicy = Policy
                .HandleResult<IRestResponse>(restResponse => restResponse.StatusCode == 0)
                .Retry(
                    retryCount: numberOfRetries,
                    (result, i) =>
                    {
                        Console.WriteLine($"If you see this, then polly retry works. Retry number: {i}");
                    });

            RetryConfiguration.RetryPolicy = testRetryPolicy;

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");
            
            Assert.That(currentApiCall, Is.EqualTo(expectedNumberOfApiCalls));
            // In the future 0 error codes with throw an error after retries exceeded
            Assert.That(sdkResponse, Is.Null);
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