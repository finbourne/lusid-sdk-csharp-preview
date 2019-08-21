using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Lusid.Sdk.Utilities
{
    /// <summary>
    /// Builder class to build instances of ILusidApiFactory
    /// </summary>
    public class LusidApiFactoryBuilder
    {
        /// <summary>
        /// Create an ILusidApiFactory using the specified configuration file.  For details on the format of the configuration file see https://support.lusid.com/getting-started-with-apis-sdks
        /// </summary>
        public static ILusidApiFactory Build(string apiSecretsFilename)
        {
            var apiConfig = ApiConfigurationBuilder.Build(apiSecretsFilename);
            return new LusidApiFactory(apiConfig);
        }
    }
}