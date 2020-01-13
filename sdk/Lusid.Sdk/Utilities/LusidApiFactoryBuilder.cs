using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Lusid.Sdk.Client;
using Microsoft.Extensions.Configuration;

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

            lock (Lock)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;

                if (ThreadFactories.TryGetValue(threadId, out var factory))
                {
                    factory = new LusidApiFactory(apiConfig);
                    ThreadFactories[threadId] = factory;
                }

                return factory;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ILusidApiFactory Build(Configuration configuration)
        {
            lock (Lock)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;

                if (!ThreadFactories.TryGetValue(threadId, out var factory))
                {
                    factory = new LusidApiFactory(configuration);
                    ThreadFactories[threadId] = factory;
                }

                return factory;
            }
        }
    }
}