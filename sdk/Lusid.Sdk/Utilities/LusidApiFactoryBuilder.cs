using System.Collections.Generic;
using System.Threading;

namespace Lusid.Sdk.Utilities
{
    /// <summary>
    /// Builder class to build instances of ILusidApiFactory
    /// </summary>
    public static class LusidApiFactoryBuilder
    {
        private static readonly Dictionary<int, ILusidApiFactory> ThreadFactories = new Dictionary<int, ILusidApiFactory>();
        private static readonly object Lock = new object();

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
            lock (Lock)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;

                if (!ThreadFactories.TryGetValue(threadId, out var factory))
                {
                    // TokenProviderConfiguration.ApiClient is the client used by LusidApiFactory and is 
                    // not threadsafe, so there needs to be a separate instance for each instance of LusidApiFactory
                    var config = new TokenProviderConfiguration(tokenProvider)
                    {
                        BasePath = url
                    };

                    factory = new LusidApiFactory(config);
                    ThreadFactories[threadId] = factory;
                }

                return factory;
            }
        }
    }
}