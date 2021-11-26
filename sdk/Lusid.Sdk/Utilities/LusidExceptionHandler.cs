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
            var status = (int)response.StatusCode;
            
            // Throw if status code is >= 400
            if (status >= 400)
            {
                return new ApiException(status,
                    $"Error calling {methodName}: {response.RawContent}",
                    response.RawContent, response.Headers);
            }

            // Throw whenever an internal SDK error has been thrown. This will result in ErrorText to Existvvfbldnvccgcugjejirkbieldtdkbldbhivefrhnujgg
            
            if (response.ErrorText != null)
            {
                return new ApiException(status,
                    $"Internal SDK error occured when calling {methodName}",
                    response.ErrorText, response.Headers);

                // TODO: Since we can't log this potentially sensitive information.
                // consider sending the full response body here into a safe storage for debugging
            }

            if (response.Content == null)
            {
                
            }
            
            return null;
        }
    }
}