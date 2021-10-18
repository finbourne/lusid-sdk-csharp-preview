using System;
using Lusid.Sdk.Client;

namespace Lusid.Sdk.Utilities
{
    /// <summary>
    /// Custom class, derived from the auto-generated Configuration, which allows the access token to be pulled from an ITokenProvider when required
    /// </summary>
    internal class TokenProviderConfiguration : Configuration
    {
        private static readonly Lazy<TokenProviderConfiguration> LazyInstance =
            new Lazy<TokenProviderConfiguration>(() => new TokenProviderConfiguration());

        public static ITokenProvider TokenProvider { private get; set; }

        /// <summary>
        /// Create a new Configuration using the supplied token provider
        /// </summary>
        private TokenProviderConfiguration()
        {
            if (TokenProvider == null)
            {
                throw new ArgumentNullException(
                    nameof(TokenProvider),
                    $"Token provider must be set before accessing the {nameof(TokenProviderConfiguration)} instance.");
            }
        }

        public static TokenProviderConfiguration Instance => LazyInstance.Value;


        /// <summary>
        /// Gets/sets the accesstoken
        /// </summary>
        public override string AccessToken
        {
            get => TokenProvider.GetAuthenticationTokenAsync().Result;
            set => throw new InvalidOperationException("AccessToken is not assignable");
        }
    }
}