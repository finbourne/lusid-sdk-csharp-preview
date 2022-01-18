using System;
using System.Net;
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
        /// Get the Polly retry condition on which to retry.
        /// </summary>
        /// <param name="restResponse">Response object that comes from the API Client</param>
        /// <returns>The boolean of whether the Polly retry condition is satisfied</returns>
        public static bool GetPollyRetryCondition(IRestResponse restResponse)
        {
            // Retry on concurrency conflict failures
            bool concurrencyConflictCondition = restResponse.StatusCode == (HttpStatusCode) 409;
            
            return concurrencyConflictCondition;
        }

        private static void HandleRetryAction(DelegateResult<IRestResponse> result, int retryCount, Context context)
        {
            Console.WriteLine("A failure occurred and a retry condition has been satisfied. " +
                              $"Status code: {result.Result.StatusCode}, " +
                              $"Retry number: {retryCount}, " +
                              $"max retries: {MaxRetryAttempts}");
        }

        #region Synchronous Retry Policies

        /// <summary>
        /// Retry policy with an action to return the failed response after retries have exceeded.
        /// Use .Wrap() method to combine this policy with your other custom policies
        /// </summary>
        public static readonly PolicyWrap<IRestResponse> DefaultRetryPolicyWithFallback =
            // Order of wraps matters. We must wrap the retry policy ON the fallback policy, not the other way around.
            DefaultFallbackPolicy.Wrap(DefaultRetryPolicy);

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
        /// Define Polly retry policy for synchronous API calls.
        /// </summary>
        public static Policy<IRestResponse> DefaultRetryPolicy =>
            Policy
                .HandleResult<IRestResponse>(GetPollyRetryCondition)
                .Retry(retryCount: MaxRetryAttempts, onRetry: HandleRetryAction);

        #endregion

        #region Async Retry Policies

        /// <summary>
        /// Retry policy with an action to return the failed response after retries have exceeded.
        /// Use .WrapAsync() method to combine this policy with your other custom policies
        /// </summary>
        public static readonly AsyncPolicyWrap<IRestResponse> DefaultRetryPolicyWithFallbackAsync =
            // Order of wraps matters. We must wrap the retry policy ON the fallback policy, not the other way around.
            DefaultFallbackPolicyAsync.WrapAsync(DefaultRetryPolicyAsync);

        /// <summary>
        /// Define Polly retry policy for asynchronous API calls.
        /// </summary>
        public static AsyncPolicy<IRestResponse> DefaultRetryPolicyAsync =>
            Policy
                .HandleResult<IRestResponse>(GetPollyRetryCondition)
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