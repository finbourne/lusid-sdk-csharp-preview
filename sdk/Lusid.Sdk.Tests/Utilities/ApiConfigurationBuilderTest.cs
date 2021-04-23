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
        [Test]
        public void Throw_Exception_For_Missing_Secrets_File()
        {
            Assert.Throws<FileNotFoundException>(() => ApiConfigurationBuilder.Build("i_do_not_exist.json"));
        }

        [Test]
        public void Use_Secrets_File_If_It_Exists()
        {
            var secretsFile = Path.GetTempFileName();
            PopulateDummySecretsFile(secretsFile, new Dictionary<string, string>
            {
                {"tokenUrl", "<tokenUrl>"},
                {"username", "<username>"},
                {"password", "<password>"},
                {"clientId", "<clientId>"},
                {"clientSecret", "<clientSecret>"},
                {"apiUrl", "<apiUrl>"},
            });

            using var console = new InMemoryConsole();
            var apiConfiguration = ApiConfigurationBuilder.Build(secretsFile);

            Assert.That(apiConfiguration.TokenUrl, Is.EqualTo("<tokenUrl>"));
            Assert.That(apiConfiguration.Username, Is.EqualTo("<username>"));
            Assert.That(apiConfiguration.Password, Is.EqualTo("<password>"));
            Assert.That(apiConfiguration.ClientId, Is.EqualTo("<clientId>"));
            Assert.That(apiConfiguration.ClientSecret, Is.EqualTo("<clientSecret>"));
            Assert.That(apiConfiguration.ApiUrl, Is.EqualTo("<apiUrl>"));

            StringAssert.Contains($"Loaded values from {secretsFile}", console.GetOutput());
        }

        [Test]
        public void Throw_Exception_If_Secrets_File_Incomplete()
        {
            var secretsFile = Path.GetTempFileName();
            PopulateDummySecretsFile(secretsFile, new Dictionary<string, string>
            {
                {"tokenUrl", "<tokenUrl>"},
                // {"username", "<username>"},
                {"password", "<password>"},
                // {"clientId", "<clientId>"},
                {"clientSecret", "<clientSecret>"},
                {"apiUrl", "<apiUrl>"},
            });

            var exception = Assert.Throws<MissingConfigException>(() => ApiConfigurationBuilder.Build(secretsFile));
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
            // Environment.SetEnvironmentVariable("FBN_CLIENT_SECRET", "<env.clientSecret>");
            Environment.SetEnvironmentVariable("FBN_USERNAME", "<env.username>");
            // Environment.SetEnvironmentVariable("FBN_PASSWORD", "<env.password>");
            Environment.SetEnvironmentVariable("FBN_APP_NAME", "<env.app_name>");

            var exception = Assert.Throws<MissingConfigException>(() => ApiConfigurationBuilder.Build(null));
            Assert.That(exception.Message,
                Is.EqualTo(
                    "The following required environment variables are not set: ['FBN_PASSWORD', 'FBN_CLIENT_SECRET']"));
        }

        private static void PopulateDummySecretsFile(string secretsFile, Dictionary<string, string> config)
        {
            using var createStream = File.Create(secretsFile);
            var secrets = new Dictionary<string, object>
            {
                ["api"] = config
            };
            JsonSerializer.SerializeAsync(createStream, secrets);
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