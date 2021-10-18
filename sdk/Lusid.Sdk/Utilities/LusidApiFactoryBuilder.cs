namespace Lusid.Sdk.Utilities
{
    /// <summary>
    /// Builder class to build instances of ILusidApiFactory
    /// </summary>
    public static class LusidApiFactoryBuilder
    {
        /// <summary>
        /// Create an ILusidApiFactory using the specified configuration file.  For details on the format of the configuration file see https://support.lusid.com/getting-started-with-apis-sdks
        /// </summary>
        public static ILusidApiFactory Build(string apiSecretsFilename)
        {
            var apiConfig = ApiConfigurationBuilder.Build(apiSecretsFilename);
            return new LusidApiFactory(apiConfig);
        }

        /// <summary>
        /// Create an ILusidApiFactory using the specified Url and Token Provider
        /// </summary>
        public static ILusidApiFactory Build(string url, ITokenProvider tokenProvider)
        {
            // TokenProviderConfiguration.ApiClient is the client used by LusidApiFactory and is 
            // NOT thread-safe, so there needs to be a separate instance for each instance of LusidApiFactory.
            // Do NOT cache the LusidApiFactory instances (DEV-6922)

            // We need to set the token provider before accessing TokenProviderConfiguration
            TokenProviderConfiguration.TokenProvider = tokenProvider;
            
            var config = TokenProviderConfiguration.Instance;
            config.BasePath = url;

            return new LusidApiFactory(config);
        }
    }
}