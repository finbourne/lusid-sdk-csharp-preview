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
    // This tests suite changes any unexpected behaviour with the retry mechanism in case of default template changes or SDK upgrades
    // For further Polly functionality reference, check out this page: https://github.com/App-vNext/Polly
    public class PollyApiRetryHandlerTests
    {
        private LusidApiFactory _apiFactory;
        private readonly Policy<IRestResponse> _initialRetryPolicy = RetryConfiguration.RetryPolicy;
        private HttpListener _httpListener;
        private const string ListenerUriPrefix = "http://localhost:4444/";
        private readonly Counter _apiCallCounter = new Counter();

        [SetUp]
        public void SetUp()
        {
            _apiCallCounter.ResetCount();
            
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(ListenerUriPrefix);

            var testApiConfig = TestLusidApiFactoryBuilder.CreateApiConfiguration(null);
            testApiConfig.ApiUrl = ListenerUriPrefix;

            _apiFactory = new LusidApiFactory(testApiConfig);

            _httpListener.Start();
        }
        
        #region Sync tests
        
        [Test]
        public void CallGetPortfoliosApi_WhenHttpStatusIs400AndRetryConditionIsNotSatisfied_ThrowsApiExceptionWithoutRetry()
        {
            // It should not retry on codes >400 by default, unless specified
            const int expectedStatusCode = 400;
            const int expectedNumberOfApiCalls = 1;
            // Add the next response returned by api
            AddMockHttpResponseToQueue(
                _httpListener, statusCode: 
                expectedStatusCode, 
                responseContent: "{\"some\": \"JsonResponseHere\"}");
            
            RetryConfiguration.RetryPolicy = PollyApiRetryHandler.InternalExceptionRetryPolicyWithFallback;
        
            var exception = Assert.Throws<ApiException>(
                () => _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any")
            );

            Assert.That(exception.ErrorContent, Is.EqualTo("{\"some\": \"JsonResponseHere\"}"));
            Assert.That(exception.ErrorCode, Is.EqualTo(expectedStatusCode));
            // Api was called just once, no retries
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
        }

        [Test]
        public void CallGetPortfoliosApi_WhenHttpStatusIs200AndRetryConditionIsNotSatisfied_NoPollyRetryIsTriggered()
        {
            // It should do nothing when response code is 200
            const int expectedStatusCode = 200;
            const int expectedNumberOfApiCalls = 1;
            // Add the next response returned by api
            AddMockHttpResponseToQueue(
                _httpListener, 
                expectedStatusCode, 
                responseContent: "{\"some\": \"JsonResponseHere\"}");
                
            RetryConfiguration.RetryPolicy = PollyApiRetryHandler.InternalExceptionRetryPolicyWithFallback;

            // TODO: This will still fail at deserialization, which currently is not handled and returns null.
            // Will be done under a different PR. Response string will also be changed.
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");
            
            // Api call should be just called once
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
        }

        [Test]
        public void CallGetPortfoliosApi_WhenApiResponseStatusCodeSatisfiesRetryCriteria_ExceedsPollyRetriesAndThrows()
        {
            const int returnedStatusCode = 502; // Or any other code that satisfies the policy retry criteria
            const int expectedNumberOfRetries = 2;
            const int expectedNumberOfApiCalls = expectedNumberOfRetries + 1;
            const string returnedErrorMessage = "Some error response";
            for (var i = 0; i < expectedNumberOfApiCalls; i++)
                // Every response fails
                AddMockHttpResponseToQueue(_httpListener, returnedStatusCode, returnedErrorMessage);
            var retryCount = 0;

            RetryConfiguration.RetryPolicy = Policy.Wrap(
                PollyApiRetryHandler.DefaultFallbackPolicy,
                Policy
                    .HandleResult<IRestResponse>(response => response.StatusCode == (HttpStatusCode) returnedStatusCode)
                    .Retry(expectedNumberOfRetries, onRetry: (result, i) => retryCount++));

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var exception = Assert.Throws<ApiException>(
                () => _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any")
            );

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
            // Todo: In the future 0 error codes with throw an error after retries exceeded
            Assert.That(exception.ErrorContent, Is.EqualTo(returnedErrorMessage));
        }

        [Test]
        public void CallGetPortfoliosApi_WhenExceedsPollyRetries_NoFallbackPolicyDefined_DoesNotThrow_ReturnsEmptyResponse()
        {
            const int returnedStatusCode = 502;
            const int expectedNumberOfRetries = 2;
            const int expectedNumberOfApiCalls = expectedNumberOfRetries + 1;
            for (var i = 0; i < expectedNumberOfApiCalls; i++)
                // Every response fails
                AddMockHttpResponseToQueue(_httpListener, statusCode: returnedStatusCode, responseContent: "Error that was thrown");
            var retryCount = 0;

            RetryConfiguration.RetryPolicy =
                Policy
                    .HandleResult<IRestResponse>(response => response.StatusCode == (HttpStatusCode) returnedStatusCode)
                    .Retry(expectedNumberOfRetries, onRetry: (result, i) => retryCount++);

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var response = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
            // Todo: In the future 0 error codes with throw an error after retries exceeded
            Assert.That(response, Is.Null);
        }

        [Test]
        public void CallGetPortfoliosApi_PollyRetryConditionIsSatisfied_RetriesUntilSuccess_DoesNotThrow()
        {
            const int returnedStatusCode = 499; // Or any custom defined code
            const int expectedNumberOfRetries = 2;
            const int expectedNumberOfApiCalls = 3;
            // First Response is a failing code
            AddMockHttpResponseToQueue(_httpListener, statusCode: returnedStatusCode, responseContent: "");
            // Second response is the first retry. It fails again
            AddMockHttpResponseToQueue(_httpListener, statusCode: returnedStatusCode, responseContent: "");
            // Third response is the second retry. Returns 200 before retries are exceeded, and does not throw
            AddMockHttpResponseToQueue(_httpListener, statusCode: 200, responseContent: "");
            var retryCount = 0;
            RetryConfiguration.RetryPolicy = Policy.Wrap(
                PollyApiRetryHandler.DefaultFallbackPolicy,
                Policy
                    .HandleResult<IRestResponse>(response => response.StatusCode == (HttpStatusCode) returnedStatusCode)
                    .Retry(expectedNumberOfRetries, onRetry: (result, i) => retryCount++));

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            // Todo: In the future 0 error codes with throw an error after retries exceeded
            Assert.That(sdkResponse, Is.Null);
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
        }

        // Example of how an exponential backoff can be used with Polly
        [Test]
        public void CallGetPortfoliosApi_WhenApiResponseStatusCodeSatisfiesRetryCriteria_PollyRetryWithBackoffIsTriggered()
        {
            const int returnedStatusCode = 499;
            const int expectedNumberOfRetries = 2;
            const int expectedNumberOfApiCalls = expectedNumberOfRetries + 1;
            for (var i = 0; i < expectedNumberOfApiCalls; i++)
                AddMockHttpResponseToQueue(_httpListener, returnedStatusCode, responseContent: "");
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
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
            // Todo: In the future 0 error codes with throw an error after retries exceeded
            Assert.That(sdkResponse, Is.Null);
        }
        
        [Test]
        [Explicit("This test only works on Windows as when running on a Linux Docker image. " +
                  "Linux seems to handle aborted connections differently, resulting always in a 200 status rather than 0.")]
        public void CallGetPortfoliosApi_WhenApiResponseStatusCodeSatisfiesRetryCriteria_PollyIsTriggered_Returns0Code()
        {
            const int expectedNumberOfApiCalls = 3;
            for (var i = 0; i < expectedNumberOfApiCalls; i++)
            {
                _httpListener.BeginGetContext(result =>
                {
                    _apiCallCounter.Increment();
                    var listener = (HttpListener) result.AsyncState;
                    // Call EndGetContext to complete the asynchronous operation.
                    var context = listener.EndGetContext(result);

                    // Obtain a response object.
                    var response = context.Response;

                    // Abort the response. This returns 0 status code when running on windows.
                    // Dotnet does not allow specifying a return status code 0, so this is a workaround on windows.
                    response.Abort();
                }, _httpListener);
            }

            RetryConfiguration.RetryPolicy = PollyApiRetryHandler.InternalExceptionRetryPolicyWithFallback;

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
            // In the future 0 error codes with throw an error after retries exceeded. This will come in a separate PR.
            Assert.That(sdkResponse, Is.Null);
        }

        [Test]
        public void UsePolicyWrap_WhenCallingGetPortfolio_BothPoliciesAreUsed()
        {
            const int statusCodeResponse1 = 498;
            const int statusCodeResponse2 = 499;
            const int expectedNumberOfApiCalls = 4;
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
            // Response needs to be a valid, deserializable json, otherwise we get null. To be fixed in another PR.
            Assert.That(sdkResponse, Is.Null);
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
        }

        // Show that polly retries are triggered on regular API timeouts as well.
        // Default timeout config is 100000 seconds (1min40s)
        [Test]
        public void CallGetPortfoliosApi_WhenRequestTimeExceedsTimeoutConfigured_PollyRetryIsStillTriggered()
        {
            var timeoutAfterMillis = GlobalConfiguration.Instance.Timeout;
            const int returnedStatusCode = 200; // Doesn't matter what code is on timeout, will always return 0
            const int expectedNumberOfApiCalls = 2;
            // First call will cause a timeout
            AddMockHttpResponseToQueue(_httpListener, returnedStatusCode, responseContent: "", timeoutAfterMillis + 10);
            // No timeout on the second call
            AddMockHttpResponseToQueue(_httpListener, returnedStatusCode, responseContent: "");

            RetryConfiguration.RetryPolicy = PollyApiRetryHandler.InternalExceptionRetryPolicyWithFallback;

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var sdkResponse = _apiFactory.Api<IPortfoliosApi>().GetPortfolio("any", "any");

            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
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
        #endregion
        
        #region Async tests
        [Test]
        public void CallGetPortfoliosApiAsync_AsyncPollyIsTriggered_ThrowsWithExceededCallsFallbackPolicy()
        {
            const int returnedStatusCode = 499;
            const int expectedNumberOfRetries = 2;
            const int expectedNumberOfApiCalls = expectedNumberOfRetries + 1;
            const string expectedErrorResponse = "Some error"; 
            for (var i = 0; i < expectedNumberOfApiCalls; i++)
                AddMockHttpResponseToQueue(_httpListener,  returnedStatusCode, expectedErrorResponse);
            var retryCount = 0;
            RetryConfiguration.AsyncRetryPolicy =
                Policy.WrapAsync(
                    PollyApiRetryHandler.DefaultFallbackPolicyAsync,
                    Policy
                        .HandleResult<IRestResponse>(apiResponse =>
                            apiResponse.StatusCode == (HttpStatusCode) returnedStatusCode)
                        .RetryAsync(retryCount: expectedNumberOfRetries, onRetry: (result, i) => retryCount++)
                );

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var exception = Assert.ThrowsAsync<ApiException>(
                 () => _apiFactory.Api<IPortfoliosApi>().GetPortfolioAsync("any", "any")
                );

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            Assert.That(exception.Message, Is.EqualTo($"Error calling GetPortfolio: {expectedErrorResponse}"));
            Assert.That(exception.ErrorCode, Is.EqualTo(returnedStatusCode));
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
        }
        
        [Test]
        public async Task CallGetPortfoliosApiAsync_AsyncPollyIsTriggered_NoFallbackPolicy_ReturnsNullResponseOnRetriesExceeded()
        {
            const int returnedStatusCode = 499;
            const int expectedNumberOfRetries = 2;
            const int expectedNumberOfApiCalls = expectedNumberOfRetries + 1;
            const string expectedErrorResponse = "Some error"; 
            for (var i = 0; i < expectedNumberOfApiCalls; i++)
                AddMockHttpResponseToQueue(_httpListener,  returnedStatusCode, expectedErrorResponse);
            var retryCount = 0;
            RetryConfiguration.AsyncRetryPolicy =
                Policy
                    .HandleResult<IRestResponse>(apiResponse => apiResponse.StatusCode == (HttpStatusCode) returnedStatusCode)
                    .RetryAsync(retryCount: expectedNumberOfRetries, onRetry: (result, i) => retryCount++);

            // Calling GetPortfolio or any other API triggers the flow that triggers polly
            var response = await _apiFactory.Api<IPortfoliosApi>().GetPortfolioAsync("any", "any");

            Assert.That(retryCount, Is.EqualTo(expectedNumberOfRetries));
            Assert.That(response, Is.Null);
            Assert.That(_apiCallCounter.GetCount(), Is.EqualTo(expectedNumberOfApiCalls));
        }
        #endregion

        [TearDown]
        public void TearDown()
        {
            // Make sure Polly is reset to what it was initially
            RetryConfiguration.RetryPolicy = _initialRetryPolicy;
            // Request is processed at this point and can be closed
            _httpListener.Close();
            _apiCallCounter.ResetCount();
        }

        private void AddMockHttpResponseToQueue(HttpListener httpListener, int statusCode,
            string responseContent, int timeToRespondMillis = 0)
        {
            httpListener.BeginGetContext(
                result =>
                {
                    _apiCallCounter.Increment();
                    GetHttpResponseHandler(result, statusCode, responseContent, timeToRespondMillis);
                },
                httpListener);
        }

        private static void GetHttpResponseHandler(IAsyncResult result, int statusCode, string responseContent,
            int timeToRespond = 0)
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

        private class Counter
        {
            private int _currentCount;
            public void Increment() => ++_currentCount;
            public int GetCount() => _currentCount;
            public void ResetCount() => _currentCount = 0;
        }
    }
}