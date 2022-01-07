using System;
using Polly;
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
            Console.WriteLine("An internal exception has occurred. Retrying. " +
                              $"Retry attempt: {retryCount}. Max retry attempts: {MaxRetryAttempts}");

            Console.WriteLine(
                "Temporarily logging the exception stack trace for finding the underlying root cause of this exception:\n" +
                $"{result.Result.ErrorException}\n");
        }

        /// <summary>
        /// Define Polly retry policy for synchronous API calls. Handles internal SDK exceptions only.
        /// Use .Wrap() method to combine this policy with your other custom policies
        /// </summary>
        public static Policy<IRestResponse> GetInternalExceptionRetryPolicy() =>
            Policy
                .HandleResult<IRestResponse>(GetInternalExceptionRetryCondition)
                .Retry(retryCount: MaxRetryAttempts, onRetry: HandleRetryAction);


        /// <summary>
        /// Define Polly retry policy for asynchronous API calls. Handles internal SDK exceptions only.
        /// Use .WrapAsync() method to combine this policy with your other custom policies
        /// </summary>
        public static AsyncPolicy<IRestResponse> GetInternalExceptionAsyncRetryPolicy() =>
            Policy
                .HandleResult<IRestResponse>(GetInternalExceptionRetryCondition)
                .RetryAsync(retryCount: MaxRetryAttempts, onRetry: HandleRetryAction);
    }
}