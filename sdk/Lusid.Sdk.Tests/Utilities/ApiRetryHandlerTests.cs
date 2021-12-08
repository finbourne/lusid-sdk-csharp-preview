using System;
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
        
        [SetUp]
        public void SetUp()
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(ListenerUriPrefix);
            
            var testApiConfig = TestLusidApiFactoryBuilder.CreateApiConfiguration(null);
            testApiConfig.ApiUrl = ListenerUriPrefix;
            
            _apiFactory = new LusidApiFactory(testApiConfig);
        }

        private static void ListenerCallback(IAsyncResult result)
        {
            var listener = (HttpListener) result.AsyncState;
            // Call EndGetContext to complete the asynchronous operation.
            var context = listener.EndGetContext(result);
            
            // Obtain a response object.
            var response = context.Response;

            // Abort the response. This returns 0 status code.
            response.Abort();
        }

        [Test]
        public void CallGetPortfoliosApi_WhenPollyRetryPolicyConfigured_PollyIsTriggered()
        {
            _httpListener.Start();
            var result = _httpListener.BeginGetContext(ListenerCallback, _httpListener);
            // Applications can do some work here while waiting for the
            // request. If no work can be done until you have processed a request,
            // use a wait handle to prevent this thread from terminating
            // while the asynchronous operation completes.

            var pollyWorks = false;
            Policy<IRestResponse> testRetryPolicy = 
                Policy
                .HandleResult<IRestResponse>(restResponse => restResponse.StatusCode == 0)
                .Retry(
                    1,
                    onRetry: (retryResult, retryCount, context) =>
                    {
                        pollyWorks = true;
                        throw new Exception("We should see this message thrown when we implement exception factory");
                    });
            RetryConfiguration.RetryPolicy = testRetryPolicy;
            
            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var response = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(pollyWorks, Is.True);
            RetryConfiguration.RetryPolicy = _initialRetryPolicy;
            // Make sure that the new retry policy is not the same as the test retry policy
            Assert.That(RetryConfiguration.RetryPolicy, Is.Not.EqualTo(testRetryPolicy));
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