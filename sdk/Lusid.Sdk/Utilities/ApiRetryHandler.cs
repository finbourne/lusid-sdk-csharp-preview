using System;
using Lusid.Sdk.Client;
using Polly;
using RestSharp;

namespace Lusid.Sdk.Utilities
{
    /// <summary>
    /// Class used to define API error retry rules for all API calls. Designed to handle openAPI v5 internal SDK exceptions only.
    /// Clients wanting to implement their own retry policy will also need to handle internal SDK exceptions while they exist.
    /// </summary>
    public static class ApiRetryHandler
    {
        private const int MaxRetryAttempts = 3;

        /// <summary>
        /// Get the retry condition on which to retry.
        /// </summary>
        /// <param name="restResponse">Response object that comes from the API Client</param>
        /// <returns></returns>
        private static bool GetRetryCondition(IRestResponse restResponse)
        {
            return restResponse.ErrorException != null || restResponse.StatusCode == 0;
        }

        /// <summary>
        /// Define Polly retry policy for synchronous API calls. Handles internal SDK exceptions only.
        /// </summary>
        public static Policy<IRestResponse> GetSyncRetryPolicy()
        {
            // If there is a configuration policy already defined before the LusidFactory has been created, use it.
            if (RetryConfiguration.RetryPolicy != null) return RetryConfiguration.RetryPolicy;

            return Policy
                .Handle<SystemException>()
                .OrResult<IRestResponse>(GetRetryCondition)
                .Retry(
                    MaxRetryAttempts,
                    onRetry: (result, retryCount, context) =>
                    {
                        Console.WriteLine("An internal exception has occurred. Retrying. " +
                                          $"Retry attempt: {retryCount}. Max retry attempts: {MaxRetryAttempts}");

                        Console.WriteLine(
                            "Temporarily logging the exception stack trace for finding the underlying root cause of this exception:\n" +
                            $"{result.Result.ErrorException}");
                    });
        }
        
        /// <summary>
        /// Define Polly retry policy for asynchronous API calls. Handles internal SDK exceptions only.
        /// </summary>
        public static AsyncPolicy<IRestResponse> GetAsyncRetryPolicy()
        {
            // If there is a configuration policy already defined before the LusidFactory has been created, use it.
            if (RetryConfiguration.AsyncRetryPolicy != null) return RetryConfiguration.AsyncRetryPolicy;

            return Policy
                .Handle<SystemException>()
                .OrResult<IRestResponse>(GetRetryCondition)
                .RetryAsync(
                    MaxRetryAttempts,
                    onRetry: (result, retryCount, context) =>
                    {
                        Console.WriteLine("An internal exception has occurred. Retrying. " +
                                          $"Retry attempt: {retryCount}. Max retry attempts: {MaxRetryAttempts}");

                        Console.WriteLine(
                            "Temporarily logging the exception stack trace for finding the underlying root cause of this exception:\n" +
                            $"{result.Result.ErrorException}");
                    });
        }
    }
}