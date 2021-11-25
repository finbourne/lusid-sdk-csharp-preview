using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace Lusid.Sdk.Tests
{
    [TestFixture]
    public class ApiClientTests
    {
        private ILusidApiFactory _apiFactory;
        private ApiClient _apiClient;
        private CustomJsonCodec _customJsonCodec;

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");
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

        [Test]
        public void CallDefaultExceptionFactory_FailsWithInternalError_Returns500Exception()
        {
            var mockException = new Mock<Exception>();
            const string stackTraceOfError = "Test stack trace";
            mockException.Setup(e => e.StackTrace).Returns(stackTraceOfError);
            
            const string methodName = "someMethod";
            const string errorText = "some error text";
            var response = new ApiResponse<Portfolio>(
                HttpStatusCode.NoContent,
                new Multimap<string, string>(),
                null,
                "Some internal error")
            {
                ErrorText = errorText,
                ResponseStatus = ResponseStatus.Error,
                InternalException = mockException.Object
            };
            
            var returnedError = (ApiException) Configuration.DefaultExceptionFactory.Invoke(methodName, response);

            Assert.That(returnedError.Message, Is.EqualTo($"Internal SDK error occured when calling {methodName}: {errorText}"));
            Assert.That(returnedError.ErrorCode, Is.EqualTo(500));
            Assert.That(returnedError.ErrorContent, Is.EqualTo(stackTraceOfError));
        }
        
        [Test]
        public void CallDefaultExceptionFactory_FailsWithApiError_TheSameErrorCodeNoStackTrace()
        {
            const string rawContent = "Not found portfolio";
            const string methodName = "someMethod";
            var expectedErrorContent= $"Error calling someMethod: {rawContent}";
            var response = new ApiResponse<Portfolio>(
                HttpStatusCode.NotFound,
                new Multimap<string, string>(),
                null,
                rawContent);
            
            var returnedError = (ApiException) Configuration.DefaultExceptionFactory.Invoke(methodName, response);

            Assert.That(returnedError.Message, Is.EqualTo(expectedErrorContent));
            Assert.That(returnedError.ErrorCode, Is.EqualTo(404));
            Assert.That(returnedError.ErrorContent, Is.EqualTo(rawContent));
        }
    }
}