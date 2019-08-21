﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lusid.Sdk.Utilities;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace Lusid.Sdk.Tests
{
    public class TokenProviderTests
    {
        private static readonly Lazy<ApiConfiguration> ApiConfig =
            new Lazy<ApiConfiguration>(() => ApiConfigurationBuilder.Build("secrets.json"));

        [Test]
        public async Task CanGetToken()
        {
            // GIVEN a token provider initialised with required secrets
            var provider = new ClientCredentialsFlowTokenProvider(ApiConfig.Value);

            // WHEN the token is requested
            var token = await provider.GetAuthenticationTokenAsync();

            // THEN it is populated
            Assert.That(token, Is.Not.Empty);
        }

        [Test]
        public async Task CanRefreshWithRefreshToken()
        {
            // GIVEN a token from the TokenProvider that contains a refresh token
            var provider = new ClientCredentialsFlowTokenProvider(ApiConfig.Value);
            var _ = await provider.GetAuthenticationTokenAsync();
            var firstTokenDetails = provider.GetLastToken();
            
            Assert.That(firstTokenDetails.RefreshToken, Is.Not.Null.And.Not.Empty, "refresh_token not returned so unable to verify refresh behaviour.  This requires the userid defined in secrets.json to be set to 'allow offline access' in Okta");

            Console.WriteLine($"Token expiring at {firstTokenDetails.ExpiresOn:o}");

            // WHEN we pretend to delay until the original token has expired (for expediency update the expires_on on the token)
            provider.ExpireToken();

            Assert.That(DateTimeOffset.UtcNow, Is.GreaterThan(firstTokenDetails.ExpiresOn));
            var refreshedToken = await provider.GetAuthenticationTokenAsync();

            // THEN it should be populated, and the ExpiresOn should be in the future
            Assert.That(refreshedToken, Is.Not.Empty);
            Assert.That(provider.GetLastToken().ExpiresOn, Is.GreaterThan(DateTimeOffset.UtcNow));
        }

        [Test, Explicit("Needs to have secrets.json file containing user without offline-access enabled")]
        public async Task CanRefreshWithoutToken()
        {
            // GIVEN a token from the TokenProvider that DOES NOT contain a refresh token
            var provider = new ClientCredentialsFlowTokenProvider(ApiConfig.Value);
            var _ = await provider.GetAuthenticationTokenAsync();
            var firstTokenDetails = provider.GetLastToken();

            Assert.That(firstTokenDetails.RefreshToken, Is.Null, "refresh_token was returned so unable to verify refresh behaviour with a token.  This requires the userid defined in secrets.json to be set to NOT 'allow offline access' in Okta");

            // WHEN we pretend to delay until the original token has expired (for expediency update the expires_on on the token)
            provider.ExpireToken();

            Assert.That(DateTimeOffset.UtcNow, Is.GreaterThan(firstTokenDetails.ExpiresOn));
            var refreshedToken = await provider.GetAuthenticationTokenAsync();

            // THEN it should be populated, and the ExpiresOn should be in the future
            Assert.That(refreshedToken, Is.Not.Empty);
            Assert.That(provider.GetLastToken().ExpiresOn, Is.GreaterThan(DateTimeOffset.UtcNow));
        }

        [Test]
        public void CanUseTokenProviderConfiguration()
        {
            var mockTokenProvider = new Mock<ITokenProvider>(MockBehavior.Loose);  // Don't care about the response

            // GIVEN a TokenProviderConfiguration configured with a mock TokenProvider
            TokenProviderConfiguration config = new TokenProviderConfiguration(mockTokenProvider.Object);

            // BEFORE the token is requested
            // THEN TokenProvider should not have been called
            mockTokenProvider.Verify(x => x.GetAuthenticationTokenAsync(), Times.Never);

            // WHEN the token is requested
            // THEN TokenProvider should not have been called each time
            var _ = config.AccessToken;
            mockTokenProvider.Verify(x => x.GetAuthenticationTokenAsync(), Times.Once);

            var __ = config.AccessToken;
            mockTokenProvider.Verify(x => x.GetAuthenticationTokenAsync(), Times.Exactly(2));
        }

        [Test]
        public void Can_Retrieve_Same_Token_From_Multiple_Threads()
        {
            const int threadCount = 100;
            
            //    create threads with calls to get a token
            var providers = Enumerable.Repeat(new ClientCredentialsFlowTokenProvider(ApiConfig.Value), threadCount).ToList();
            var requests = providers.Select(p => p.GetAuthenticationTokenAsync());

            //    get the tokens
            Task.WaitAll(requests.ToArray());

            //    all requests must have the same token i.e. reuse a valid token
            Assert.That(requests.GroupBy(r => r.Result).Count(), Is.EqualTo(1), "Requests have different tokens");
        }
    }
}

