﻿using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Utilities;
using NUnit.Framework;
using Polly;
using RestSharp;

namespace Lusid.Sdk.Tests.Utilities
{
    [TestFixture]
    // For further Polly functionality reference, check out this page: https://github.com/App-vNext/Polly
    public class PollyApiRetryHandlerTests
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
            
            _httpListener.Start();
        }

        [Test]
        public void CallGetPortfoliosApi_WhenHttpStatusIs400AndRetryConditionIsNotSatisfied_ThrowsApiExceptionWithoutRetry()
        {
            // It should not retry on codes >400 by default, unless specified
            const int expectedStatusCode = 400;
            // Add the next response returned by api
            AddMockHttpResponseToQueue(_httpListener, statusCode: expectedStatusCode, responseContent: "{\"some\": \"JsonResponseHere\"}");
            var retryCount = 0;
            RetryConfiguration.RetryPolicy = Policy
                .HandleResult<IRestResponse>(PollyApiRetryHandler.GetInternalExceptionRetryCondition)
                .Retry(retryCount: 3, onRetry: (result, i) => retryCount++);
            
            var exception = Assert.Throws<ApiException>(
                () => _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any")
            );

            Assert.That(exception.ErrorContent, Is.EqualTo("{\"some\": \"JsonResponseHere\"}"));
            Assert.That(exception.ErrorCode, Is.EqualTo(expectedStatusCode));
            Assert.That(retryCount, Is.EqualTo(0));
        }

        [Test]
        public void CallGetPortfoliosApi_WhenHttpStatusIs200AndRetryConditionIsNotSatisfied_NoPollyRetryIsTriggered()
        {
            // It should do nothing when response code is 200
            const int expectedStatusCode = 200;
            // Add the next response returned by api
            AddMockHttpResponseToQueue(_httpListener, statusCode: expectedStatusCode, responseContent: "{\"some\": \"JsonResponseHere\"}");
            var retryCount = 0;
            RetryConfiguration.RetryPolicy = Policy
                .HandleResult<IRestResponse>(PollyApiRetryHandler.GetInternalExceptionRetryCondition)
                .Retry(retryCount: 3,
                    onRetry: (result, i) => retryCount++);

            // TODO: This will still fail at deserialization, which currently is not handled and returns null.
            // Will be done under a different PR. Response string will also be changed.
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(retryCount, Is.EqualTo(0));
        }

        [Test]
        public void CallGetPortfoliosApi_WhenApiResponseStatusCodeSatisfiesRetryCriteria_PollyRetryIsTriggered()
        {
            const int returnedStatusCode = 499;
            const int expectedNumberOfRetries = 2;
            for (var i = 0; i < expectedNumberOfRetries + 1; i++)
                AddMockHttpResponseToQueue(_httpListener, statusCode: returnedStatusCode, responseContent: "");
            var retryCount = 0;
            RetryConfiguration.RetryPolicy = Policy
                .HandleResult<IRestResponse>(response => response.StatusCode == (HttpStatusCode) returnedStatusCode)
                .Retry(expectedNumberOfRetries, onRetry: (result, i) => retryCount++);

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            // Todo: In the future 0 error codes with throw an error after retries exceeded
            Assert.That(sdkResponse, Is.Null);
        }

        [Test]
        public void CallGetPortfoliosApi_WhenApiResponseStatusCodeSatisfiesRetryCriteria_PollyRetryWithBackoffIsTriggered()
        {
            const int returnedStatusCode = 499;
            const int expectedNumberOfRetries = 2;
            for (var i = 0; i < expectedNumberOfRetries + 1; i++)
                AddMockHttpResponseToQueue(_httpListener, statusCode: returnedStatusCode, responseContent: "");
            var retryCount = 0;
            // Polly retry policy with a backoff example
            RetryConfiguration.RetryPolicy = Policy
                .HandleResult<IRestResponse>(apiResponse =>
                    apiResponse.StatusCode == (HttpStatusCode) returnedStatusCode)
                .WaitAndRetry(expectedNumberOfRetries,
                    sleepDurationProvider: retryAttempt => 0.1 * TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (restResponseResult, timeSpan, context) =>
                    {
                        // Add logic to be executed before each retry, such as logging
                        retryCount++;
                    });

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            // Todo: In the future 0 error codes with throw an error after retries exceeded
            Assert.That(sdkResponse, Is.Null);
        }

        [Test]
        public async Task CallGetPortfoliosApiAsync_WhenApiResponseStatusCodeSatisfiesRetryCriteria_AsyncPollyIsTriggered()
        {
            const int returnedStatusCode = 499;
            const int expectedNumberOfRetries = 2;
            for (var i = 0; i < expectedNumberOfRetries + 1; i++)
                AddMockHttpResponseToQueue(_httpListener, statusCode: returnedStatusCode, responseContent: "");
            var retryCount = 0;
            RetryConfiguration.AsyncRetryPolicy = Policy
                .HandleResult<IRestResponse>(apiResponse => apiResponse.StatusCode == (HttpStatusCode) returnedStatusCode)
                .RetryAsync(retryCount: expectedNumberOfRetries, onRetry: (result, i) => retryCount++);

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = await _apiFactory.Api<IPortfoliosApi>().GetPortfolioAsync("any", "any");

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            // Todo: In the future 0 error codes with throw an error after retries exceeded
            Assert.That(sdkResponse, Is.Null);
        }

        [Test]
        [Explicit("This test only works on Windows as when running on a Linux Docker image. " +
                  "Linux seems to handle aborted connections differently, resulting always in a 200 status rather than 0.")]
        public void CallGetPortfoliosApi_WhenApiResponseStatusCodeSatisfiesRetryCriteria_PollyIsTriggered_Returns100Code()
        {
            const int expectedNumberOfRetries = 2;
            for (var i = 0; i < expectedNumberOfRetries + 1; i++)
            {
                _httpListener.BeginGetContext(result =>
                {
                    var listener = (HttpListener) result.AsyncState;
                    // Call EndGetContext to complete the asynchronous operation.
                    var context = listener.EndGetContext(result);

                    // Obtain a response object.
                    var response = context.Response;

                    // Abort the response. This returns 0 status code when running on windows.
                    response.Abort();
                }, _httpListener);
            }
            var retryCount = 0;
            RetryConfiguration.RetryPolicy = Policy
                .HandleResult<IRestResponse>(PollyApiRetryHandler.GetInternalExceptionRetryCondition)
                .Retry(retryCount: 2, onRetry: (result, i) => retryCount++);

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            // In the future 0 error codes with throw an error after retries exceeded. This will come in a separate PR.
            Assert.That(sdkResponse, Is.Null);
        }

        [Test]
        public void UsePolicyWrap_WhenCallingGetPortfolio_BothPoliciesAreUsed()
        {
            const int statusCodeResponse1 = 498;
            const int statusCodeResponse2 = 499;
            // First Response
            AddMockHttpResponseToQueue(_httpListener, statusCode: statusCodeResponse1, responseContent: "");
            // Second Response - same, triggers another retry
            AddMockHttpResponseToQueue(_httpListener, statusCode: statusCodeResponse1, responseContent: "");
            // Third response - First policy retries stop, second policy retries kick in
            AddMockHttpResponseToQueue(_httpListener, statusCode: statusCodeResponse2, responseContent: "");
            // Fourth response - No more retries as response is a success
            AddMockHttpResponseToQueue(_httpListener, statusCode: 200, responseContent: "");
            var policy1TriggerCount = 0;
            var policy2TriggerCount = 0;
            var policy1 = Policy
                .HandleResult<IRestResponse>(apiResponse => apiResponse.StatusCode == (HttpStatusCode) statusCodeResponse1)
                .Retry(retryCount: 3, onRetry: (result, i) => policy1TriggerCount++);
            var policy2 = Policy
                .HandleResult<IRestResponse>(apiResponse => apiResponse.StatusCode == (HttpStatusCode) statusCodeResponse2)
                .Retry(retryCount: 3, onRetry: (result, i) => policy2TriggerCount++);
            RetryConfiguration.RetryPolicy = policy1.Wrap(policy2);
            
            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(policy1TriggerCount, Is.EqualTo(2));
            Assert.That(policy2TriggerCount, Is.EqualTo(1));
        }
        
        // Show that polly retries are triggered on regular API timeouts as well.
        // Default timeout config is 100000 seconds (1min40s)
        [Test]
        public void CallGetPortfoliosApi_WhenRequestTimeExceedsTimeoutConfigured_PollyRetryIsStillTriggered()
        {
            var timeoutAfter = GlobalConfiguration.Instance.Timeout;
            const int returnedStatusCode = 200; // Doesn't matter what code is on timeout, will always return 0
            const int expectedNumberOfRetries = 1;
            // First call will cause a timeout
            AddMockHttpResponseToQueue(_httpListener, statusCode: returnedStatusCode, responseContent: "", timeToRespond: timeoutAfter + 10);
            // No timeout on the second call
            AddMockHttpResponseToQueue(_httpListener, statusCode: returnedStatusCode, responseContent: "");
            var retryCount = 0;
            RetryConfiguration.RetryPolicy = Policy
                .HandleResult<IRestResponse>(apiResponse => apiResponse.StatusCode == 0)
                .Retry(retryCount: expectedNumberOfRetries, 
                    onRetry: (result, i) => retryCount++);

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            // Todo: In the future 0 error codes with throw an error after retries exceeded
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

        private static void AddMockHttpResponseToQueue(HttpListener httpListener, int statusCode, string responseContent, int timeToRespond=0)
        {
            httpListener.BeginGetContext(
                result => GetHttpResponseHandler(result, statusCode, responseContent, timeToRespond),
                httpListener);
        }

        private static void GetHttpResponseHandler(IAsyncResult result, int statusCode, string responseContent, int timeToRespond=0)
        {
            var listener = (HttpListener) result.AsyncState;
            // Call EndGetContext to complete the asynchronous operation.
            var context = listener.EndGetContext(result);

            // Obtain a response object.
            var response = context.Response;

            // Construct a response.
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseContent);

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            response.StatusCode = statusCode;

            var output = response.OutputStream;
            
            // Simulate time taken for the response. Potentially simulate a timeout.
            Thread.Sleep(timeToRespond);
            
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }
    }
}