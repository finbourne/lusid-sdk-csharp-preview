using System;
using System.Net;
using Lusid.Sdk.Api;
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
    public class LusidExceptionHandlerTests
    {
        private ILusidApiFactory _apiFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");
        }


        [Test]
        public void CallCustomExceptionFactory_FailsWithInternalError_Returns500Exception()
        {
            var mockException = new Mock<Exception>();
            const string stackTraceOfError = "Test stack trace";
            mockException.Setup(e => e.StackTrace).Returns(stackTraceOfError);
            const string methodName = "someMethod";
            const string errorText = "some error text";
            var response = new ApiResponse<Portfolio>(
                HttpStatusCode.OK,
                new Multimap<string, string>(),
                null,
                "Some internal error")
            {
                ErrorText = errorText,
                ResponseStatus = ResponseStatus.Error,
                InternalException = mockException.Object
            };
            
            var returnedError = (ApiException) LusidExceptionHandler.CustomExceptionFactory(methodName, response);

            Assert.That(returnedError.Message, Is.EqualTo($"Internal SDK error occured when calling {methodName}: {errorText}"));
            Assert.That(returnedError.ErrorCode, Is.EqualTo(200));
            Assert.That(returnedError.ErrorContent, Is.EqualTo(stackTraceOfError));
        }
        
        [Test]
        public void CallCustomExceptionFactory_FailsWithApiError_ReturnsTheSameErrorCodeAsApiWithNoStackTrace()
        {
            const string rawContent = "Not found portfolio";
            const string methodName = "someMethod";
            var expectedErrorContent= $"Error calling someMethod: {rawContent}";
            var response = new ApiResponse<Portfolio>(
                HttpStatusCode.NotFound,
                new Multimap<string, string>(),
                null,
                rawContent);
            
            var returnedError = (ApiException) LusidExceptionHandler.CustomExceptionFactory(methodName, response);

            Assert.That(returnedError.Message, Is.EqualTo(expectedErrorContent));
            Assert.That(returnedError.ErrorCode, Is.EqualTo(404));
            Assert.That(returnedError.ErrorContent, Is.EqualTo(rawContent));
        }

        [Test]
        public void CallPortfoliosApiExceptionFactory_DefaultIsOverriden_ExceptionFactoryOfApiIsSameAsCustomOne()
        {
            var mockException = new Mock<Exception>();
            const string stackTraceOfError = "Test stack trace";
            mockException.Setup(e => e.StackTrace).Returns(stackTraceOfError);
            const string methodName = "someMethod";
            const string errorText = "some error text";
            var response = new ApiResponse<Portfolio>(
                default,
                new Multimap<string, string>(),
                null,
                "Some internal error")
            {
                ErrorText = errorText,
                ResponseStatus = ResponseStatus.Error,
                InternalException = mockException.Object
            };

            var customExceptionHandlerError = (ApiException) LusidExceptionHandler.CustomExceptionFactory(methodName, response);
            var errorOnTheApi = (ApiException) _apiFactory.Api<IPortfoliosApi>().ExceptionFactory.Invoke(methodName, response);

            // Assert that the error has correct values
            Assert.That(customExceptionHandlerError.Message, Is.EqualTo($"Internal SDK error occured when calling {methodName}: {errorText}"));
            Assert.That(customExceptionHandlerError.ErrorCode, Is.EqualTo(0));
            Assert.That(customExceptionHandlerError.ErrorContent, Is.EqualTo(stackTraceOfError));
            
            // Assert that the custom exception handler errors are the same as the errors on the API
            Assert.That(customExceptionHandlerError.Message, Is.EqualTo(errorOnTheApi.Message));
            Assert.That(customExceptionHandlerError.ErrorCode, Is.EqualTo(errorOnTheApi.ErrorCode));
            Assert.That(customExceptionHandlerError.ErrorContent, Is.EqualTo(errorOnTheApi.ErrorContent));
        }
        
        [Test]
        public void CallDefaultExceptionFactory_ItIsDifferentThanOnApi_DefaultExceptionFactoryResponseIsNullAndApiOneIsNot()
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
            
            var defaultExceptionFactoryError = (ApiException) Configuration.DefaultExceptionFactory.Invoke(methodName, response);
            var errorOnTheApi = (ApiException) _apiFactory.Api<IPortfoliosApi>().ExceptionFactory.Invoke(methodName, response);

            Assert.That(defaultExceptionFactoryError, Is.Null);
            Assert.That(errorOnTheApi, Is.Not.Null);
            
        }
    }
}