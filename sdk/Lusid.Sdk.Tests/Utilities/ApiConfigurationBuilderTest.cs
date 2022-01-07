using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Utilities
{
    public class ApiConfigurationBuilderTest
    {
        private string _secretsFile;
        
        private string _cachedTokenUrl;
        private string _cachedApiUrl;
        private string _cachedClientId;
        private string _cachedClientSecret;
        private string _cachedUsername;
        private string _cachedPassword;
        private string _cachedApplicationName;

        [OneTimeSetUp]
        public void Setup()
        {
            _secretsFile = Path.GetTempFileName();

            _cachedTokenUrl = Environment.GetEnvironmentVariable("FBN_TOKEN_URL") ??
                              Environment.GetEnvironmentVariable("fbn_token_url");
            _cachedApiUrl = Environment.GetEnvironmentVariable("FBN_LUSID_API_URL") ??
                            Environment.GetEnvironmentVariable("fbn_lusid_api_url");
            _cachedClientId = Environment.GetEnvironmentVariable("FBN_CLIENT_ID") ??
                              Environment.GetEnvironmentVariable("fbn_client_id");
            _cachedClientSecret = Environment.GetEnvironmentVariable("FBN_CLIENT_SECRET") ??
                                  Environment.GetEnvironmentVariable("fbn_client_secret");
            _cachedUsername = Environment.GetEnvironmentVariable("FBN_USERNAME") ??
                              Environment.GetEnvironmentVariable("fbn_username");
            _cachedPassword = Environment.GetEnvironmentVariable("FBN_PASSWORD") ??
                              Environment.GetEnvironmentVariable("fbn_password");
            _cachedApplicationName = Environment.GetEnvironmentVariable("FBN_APP_NAME") ??
                                     Environment.GetEnvironmentVariable("fbn_app_name");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Environment.SetEnvironmentVariable("FBN_TOKEN_URL", _cachedTokenUrl);
            Environment.SetEnvironmentVariable("FBN_LUSID_API_URL", _cachedApiUrl);
            Environment.SetEnvironmentVariable("FBN_CLIENT_ID", _cachedClientId);
            Environment.SetEnvironmentVariable("FBN_CLIENT_SECRET", _cachedClientSecret);
            Environment.SetEnvironmentVariable("FBN_USERNAME", _cachedUsername);
            Environment.SetEnvironmentVariable("FBN_PASSWORD", _cachedPassword);
            Environment.SetEnvironmentVariable("FBN_APP_NAME", _cachedApplicationName);
            File.Delete(_secretsFile);
        }
        
        [Test]
        public void Throw_Exception_For_Missing_Secrets_File()
        {
            Assert.Throws<FileNotFoundException>(() => ApiConfigurationBuilder.Build("i_do_not_exist.json"));
        }

        [Test]
        public void Use_Secrets_File_If_It_Exists()
        {
            PopulateDummySecretsFile(new Dictionary<string, string>
            {
                {"tokenUrl", "<tokenUrl>"},
                {"username", "<username>"},
                {"password", "<password>"},
                {"clientId", "<clientId>"},
                {"clientSecret", "<clientSecret>"},
                {"apiUrl", "<apiUrl>"},
            });
            
            using var console = new InMemoryConsole();
            var apiConfiguration = ApiConfigurationBuilder.Build(_secretsFile);

            Assert.That(apiConfiguration.TokenUrl, Is.EqualTo("<tokenUrl>"));
            Assert.That(apiConfiguration.Username, Is.EqualTo("<username>"));
            Assert.That(apiConfiguration.Password, Is.EqualTo("<password>"));
            Assert.That(apiConfiguration.ClientId, Is.EqualTo("<clientId>"));
            Assert.That(apiConfiguration.ClientSecret, Is.EqualTo("<clientSecret>"));
            Assert.That(apiConfiguration.ApiUrl, Is.EqualTo("<apiUrl>"));

            StringAssert.Contains($"Loaded values from {_secretsFile}", console.GetOutput());
        }

        [Test]
        public void Throw_Exception_If_Secrets_File_Incomplete()
        {
            PopulateDummySecretsFile(new Dictionary<string, string>
            {
                {"tokenUrl", "<tokenUrl>"},
                // {"username", "<username>"},
                {"password", "<password>"},
                // {"clientId", "<clientId>"},
                {"clientSecret", "<clientSecret>"},
                {"apiUrl", "<apiUrl>"},
            });

            var exception = Assert.Throws<MissingConfigException>(() => ApiConfigurationBuilder.Build(_secretsFile));
            Assert.That(exception.Message,
                Is.EqualTo(
                    "The provided secrets file is missing the following required values: ['username', 'clientId']"));
        }

        [Test]
        public void Use_Environment_Variables_If_No_Secrets_File_Provided()
        {
            Environment.SetEnvironmentVariable("FBN_TOKEN_URL", "<env.tokenUrl>");
            Environment.SetEnvironmentVariable("FBN_LUSID_API_URL", "<env.apiUrl>");
            Environment.SetEnvironmentVariable("FBN_CLIENT_ID", "<env.clientId>");
            Environment.SetEnvironmentVariable("FBN_CLIENT_SECRET", "<env.clientSecret>");
            Environment.SetEnvironmentVariable("FBN_USERNAME", "<env.username>");
            Environment.SetEnvironmentVariable("FBN_PASSWORD", "<env.password>");
            Environment.SetEnvironmentVariable("FBN_APP_NAME", "<env.app_name>");

            using var console = new InMemoryConsole();
            var apiConfiguration = ApiConfigurationBuilder.Build(null);
            Assert.That(apiConfiguration.TokenUrl, Is.EqualTo("<env.tokenUrl>"));
            Assert.That(apiConfiguration.Username, Is.EqualTo("<env.username>"));
            Assert.That(apiConfiguration.Password, Is.EqualTo("<env.password>"));
            Assert.That(apiConfiguration.ClientId, Is.EqualTo("<env.clientId>"));
            Assert.That(apiConfiguration.ClientSecret, Is.EqualTo("<env.clientSecret>"));
            Assert.That(apiConfiguration.ApiUrl, Is.EqualTo("<env.apiUrl>"));
            Console.WriteLine(console.GetOutput());
            StringAssert.Contains("Loaded values from environment", console.GetOutput());
        }

        [Test]
        public void Throw_Exception_If_Environment_Variables_Incomplete()
        {
            Environment.SetEnvironmentVariable("FBN_TOKEN_URL", "<env.tokenUrl>");
            Environment.SetEnvironmentVariable("FBN_LUSID_API_URL", "<env.apiUrl>");
            Environment.SetEnvironmentVariable("FBN_CLIENT_ID", "<env.clientId>");
            Environment.SetEnvironmentVariable("FBN_CLIENT_SECRET", "");
            Environment.SetEnvironmentVariable("FBN_USERNAME", "<env.username>");
            Environment.SetEnvironmentVariable("FBN_PASSWORD", "");
            Environment.SetEnvironmentVariable("FBN_APP_NAME", "<env.app_name>");
            Environment.SetEnvironmentVariable("FBN_ACCESS_TOKEN", "");
            
            var exception = Assert.Throws<MissingConfigException>(() => ApiConfigurationBuilder.Build(null));
            Assert.That(exception.Message,
                Is.EqualTo(
                    "The following required environment variables are not set: ['FBN_PASSWORD', 'FBN_CLIENT_SECRET']"));
        }

        private void PopulateDummySecretsFile(Dictionary<string, string> config)
        {
            var secrets = new Dictionary<string, object>
            {
                ["api"] = config
            };
            var json = JsonSerializer.Serialize(secrets);
            File.WriteAllText(_secretsFile, json);
        }

        class InMemoryConsole : IDisposable
        {
            private readonly StringWriter _stringWriter;
            private readonly TextWriter _originalOutput;

            public InMemoryConsole()
            {
                _stringWriter = new StringWriter();
                _originalOutput = Console.Out;
                Console.SetOut(_stringWriter);
            }

            public string GetOutput()
            {
                return _stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(_originalOutput);
                _stringWriter.Dispose();
            }
        }
    }
}