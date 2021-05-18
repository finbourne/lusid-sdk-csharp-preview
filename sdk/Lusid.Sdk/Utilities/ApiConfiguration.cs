using System.Collections.Generic;

namespace Lusid.Sdk.Utilities
{
    /// <summary>
    /// Configuration for the ClientCredentialsFlowTokenProvider, usually sourced from a "secrets.json" file
    /// </summary>
    public class ApiConfiguration
    {
        /// <summary>
        /// Url for the token provider
        /// </summary>
        public string TokenUrl { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// OAuth2 Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// OAuth2 Client Secret
        /// </summary>
        public string ClientSecret { get;  set; }

        /// <summary>
        /// LUSID Api Url
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// Client Application name
        /// </summary>
        public string ApplicationName { get; set; }
        
        /// <summary>
        /// Checks if any of the required configuration values are missing
        /// </summary>
        /// <returns></returns>
        public bool HasMissingConfig()
        {
            return string.IsNullOrEmpty(TokenUrl) ||
                   string.IsNullOrEmpty(Username) ||
                   string.IsNullOrEmpty(Password) ||
                   string.IsNullOrEmpty(ClientId) ||
                   string.IsNullOrEmpty(ClientSecret) ||
                   string.IsNullOrEmpty(ApiUrl);
        }

        /// <summary>
        /// Returns a list of the missing required configuration values
        /// </summary>
        /// <returns></returns>
        public List<string> MissingConfig()
        {
            var missingConfig = new List<string>();
            if (string.IsNullOrEmpty(TokenUrl))
            {
                missingConfig.Add("TokenUrl");
            }
            if (string.IsNullOrEmpty(Username))
            {
                missingConfig.Add("Username");
            }
            if (string.IsNullOrEmpty(Password))
            {
                missingConfig.Add("Password");
            }
            if (string.IsNullOrEmpty(ClientId))
            {
                missingConfig.Add("ClientId");
            }
            if (string.IsNullOrEmpty(ClientSecret))
            {
                missingConfig.Add("ClientSecret");
            } 
            if (string.IsNullOrEmpty(ApiUrl))
            {
                missingConfig.Add("ApiUrl");
            }
            return missingConfig;
        }
    }
}