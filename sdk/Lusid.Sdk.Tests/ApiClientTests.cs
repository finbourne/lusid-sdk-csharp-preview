using System;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;
using NUnit.Framework;
using RestSharp;

namespace Lusid.Sdk.Tests
{
    [TestFixture]
    public class ApiClientTests
    {
        private ApiClient _apiClient;
        private CustomJsonCodec _customJsonCodec;

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiClient = new ApiClient();
            _customJsonCodec = new CustomJsonCodec(_apiClient.SerializerSettings, GlobalConfiguration.Instance);
        }

        [Test]
        [TestCase(" ", "API Response Content was invalid: ' '")]
        [TestCase("", "API Response Content was invalid: ''")]
        [TestCase(null, "API Response Content was invalid: ''")]
        public void TestDeserialize_RestResponseIsNullOrEmpty_ThrowsError(string apiResponseString,
            string expectedError)
        {
            var mockRestResponse = new RestResponse
            {
                Content = apiResponseString
            };

            var exception = Assert.Throws(Is.InstanceOf<Exception>(),
                () => _customJsonCodec.Deserialize(mockRestResponse, typeof(Portfolio))
            );

            Assert.That(exception.InnerException.Message, Is.Not.EqualTo(""));
            Assert.That(exception.InnerException.Message, Is.Not.EqualTo(" "));
            Assert.That(exception.InnerException.Message, Is.EqualTo(expectedError));
        }


        [Test]
        [TestCase("some faulty response",
            "Unexpected character encountered while parsing value: s. Path '', line 0, position 0.")]
        [TestCase("{\"not-serializable\":\"object\"}",
            "Required property 'type' not found in JSON. Path '', line 1, position 29.")]
        public void TestDeserialize_RestResponseIsNotSerializable_ThrowsError(string apiResponseString,
            string expectedError)
        {
            var mockRestResponse = new RestResponse
            {
                Content = apiResponseString
            };

            var exception = Assert.Throws(Is.InstanceOf<Exception>(),
                () => _customJsonCodec.Deserialize(mockRestResponse, typeof(Portfolio))
            );

            Assert.That(exception.Message, Is.Not.EqualTo(""));
            Assert.That(exception.Message, Is.Not.EqualTo(" "));
            Assert.That(exception.Message, Is.EqualTo(expectedError));
        }
    }
}