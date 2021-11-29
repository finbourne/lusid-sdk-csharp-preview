using System;
using Lusid.Sdk.Client;
using RestSharp;

namespace Lusid.Sdk.Utilities
{
    /// <summary>
    /// Handles the generation of LUSID exceptions after receiving the ApiResponse
    /// </summary>
    public static class LusidExceptionHandler
    {
        /// <summary>
        /// Generate exceptions from the ApiResponse when ResponseStatus is an Error,
        /// and StatusCode has no content or is less than 400
        /// </summary>
        /// <param name="methodName">The name of the method</param>
        /// <param name="response">The ApiResponse</param>
        public static Exception CustomExceptionFactory(string methodName, IApiResponse response)
        {
            
            var status = (int) response.StatusCode; // Http status code
            var errorText = response.ErrorText; // Error text attached on exceptions
            var headers = response.Headers; // Http headers that come back with the api response
            var responseBodyString = response.RawContent; // The body content of the http response as a string
            
            // Use default exception, and only use subsequent checks if default exception factory is null.
            var defaultException = Configuration.DefaultExceptionFactory.Invoke(methodName, response);
            if (defaultException != null) return defaultException;
            
            // Throw whenever an internal SDK error has been thrown.
            // Internal SDK deserialization errors will result in ErrorText to be not null.
            if (response.ErrorText != null)
                return new ApiException(
                    status,
                    $"Internal SDK error occured when calling {methodName}: {errorText}",
                    errorText,
                    headers
                );
            // TODO: We can't log RawContent, because it could be potentially sensitive information. Consider sending the full response body here into a safe storage for debugging

            // RawContent is the response body string of the API response.
            // If an empty string or whitespace, we should throw because Deserialization just returns null on empty strings.
            if (string.IsNullOrWhiteSpace(responseBodyString))
                return new ApiException(
                    status,
                    $"Internal SDK error occured when calling {methodName}",
                    $"API response body was invalid: '{responseBodyString}'. " +
                    $"Please check the logs for this request and potentially raise the issue with the API team.",
                    headers
                );

            return null;
        }
    }
}