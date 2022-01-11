using System;
using System.Threading.Tasks;
using Polly;
using Polly.Wrap;
using RestSharp;

namespace Lusid.Sdk.Utilities
{
    /// <summary>
    /// Class used to define API error retry rules for all API calls.
    /// </summary>
    public static class PollyApiRetryHandler
    {
        /// <summary>
        /// Number of max retry attempts
        /// </summary>
        private const int MaxRetryAttempts = 2;

        /// <summary>
        /// Get the internal exception condition on which to retry.
        /// </summary>
        /// <param name="restResponse">Response object that comes from the API Client</param>
        /// <returns>The boolean of whether the internal exception condition is satisfied</returns>
        public static bool GetInternalExceptionRetryCondition(IRestResponse restResponse)
        {
            return restResponse.ErrorException != null || restResponse.StatusCode == 0;
        }

        private static void HandleRetryAction(DelegateResult<IRestResponse> result, int retryCount, Context context)
        {
            if (Environment.GetEnvironmentVariable("HIDE_INTERNAL_EXCEPTION_RETRY_LOGS") == "true") return;
                
            Console.WriteLine("An internal exception has occurred. Retrying. " +
                              $"Retry attempt: {retryCount}. Max retry attempts: {MaxRetryAttempts}");

            Console.WriteLine(
                "Temporarily logging the exception stack trace for finding the underlying root cause of this exception:\n" +
                $"{result.Result.ErrorException}\n");
        }

        #region Synchronous Retry Policies

        /// <summary>
        /// Retry policy with an action to return the failed response after retries have exceeded.
        /// Use .Wrap() method to combine this policy with your other custom policies
        /// </summary>
        public static PolicyWrap<IRestResponse> InternalExceptionRetryPolicyWithFallback =>
            Policy.Wrap(InternalExceptionRetryPolicy, DefaultFallbackPolicy);

        /// <summary>
        /// Causes the actual API response to be returned after retries have been exceeded.
        /// It is necessary to use with OpenAPI, as without it a null result will be returned
        /// </summary>
        /// <returns>Fallback Policy (Synchronous)</returns>
        public static Policy<IRestResponse> DefaultFallbackPolicy =>
            Policy<IRestResponse>
                .Handle<SystemException>()
                .Fallback(
                    (outcome, ctx, ct) => outcome.Result,
                    (outcome, ctx) =>
                    {
                        // Add logging or other logic here 
                    });


        /// <summary>
        /// Define Polly retry policy for synchronous API calls. Handles internal SDK exceptions only.
        /// </summary>
        public static Policy<IRestResponse> InternalExceptionRetryPolicy =>
            Policy
                .HandleResult<IRestResponse>(GetInternalExceptionRetryCondition)
                .Retry(retryCount: MaxRetryAttempts, onRetry: HandleRetryAction);

        #endregion

        #region Async Retry Policies

        /// <summary>
        /// Retry policy with an action to return the failed response after retries have exceeded.
        /// Use .WrapAsync() method to combine this policy with your other custom policies
        /// </summary>
        public static AsyncPolicyWrap<IRestResponse> InternalExceptionRetryPolicyWithFallbackAsync =>
            Policy.WrapAsync(InternalExceptionRetryPolicyAsync, DefaultFallbackPolicyAsync);

        /// <summary>
        /// Define Polly retry policy for asynchronous API calls. Handles internal SDK exceptions only.
        /// </summary>
        public static AsyncPolicy<IRestResponse> InternalExceptionRetryPolicyAsync =>
            Policy
                .HandleResult<IRestResponse>(GetInternalExceptionRetryCondition)
                .RetryAsync(retryCount: MaxRetryAttempts, onRetry: HandleRetryAction);

        /// <summary>
        /// Causes the actual API response to be returned after retries have been exceeded.
        /// It is necessary to use with OpenAPI, as without it a null result will be returned
        /// </summary>
        /// <returns>Fallback Policy (Asynchronous)</returns>
        public static AsyncPolicy<IRestResponse> DefaultFallbackPolicyAsync =>
            Policy<IRestResponse>
                .Handle<SystemException>()
                .FallbackAsync(
                    (outcome, b, c) => Task.FromResult(outcome.Result),
                    (outcome, b) => Task.CompletedTask);

        #endregion
    }
}