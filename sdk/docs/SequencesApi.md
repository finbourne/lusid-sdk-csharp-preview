# Lusid.Sdk.Api.SequencesApi

All URIs are relative to *http://local-unit-test-server.lusid.com:54254*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateSequence**](SequencesApi.md#createsequence) | **POST** /api/sequences/{scope} | [EXPERIMENTAL] CreateSequence: Create a new sequence
[**GetSequence**](SequencesApi.md#getsequence) | **GET** /api/sequences/{scope}/{code} | [EXPERIMENTAL] GetSequence: Get a specified sequence
[**Next**](SequencesApi.md#next) | **GET** /api/sequences/{scope}/{code}/next | [EXPERIMENTAL] Next: Get next values from sequence


<a name="createsequence"></a>
# **CreateSequence**
> SequenceDefinition CreateSequence (string scope, CreateSequenceRequest createSequenceRequest)

[EXPERIMENTAL] CreateSequence: Create a new sequence

Create a new sequence

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateSequenceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:54254";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SequencesApi(config);
            var scope = scope_example;  // string | Scope of the sequence.
            var createSequenceRequest = new CreateSequenceRequest(); // CreateSequenceRequest | Request to create sequence

            try
            {
                // [EXPERIMENTAL] CreateSequence: Create a new sequence
                SequenceDefinition result = apiInstance.CreateSequence(scope, createSequenceRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SequencesApi.CreateSequence: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **scope** | **string**| Scope of the sequence. | 
 **createSequenceRequest** | [**CreateSequenceRequest**](CreateSequenceRequest.md)| Request to create sequence | 

### Return type

[**SequenceDefinition**](SequenceDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The newly created Sequence |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsequence"></a>
# **GetSequence**
> SequenceDefinition GetSequence (string scope, string code)

[EXPERIMENTAL] GetSequence: Get a specified sequence

Return the details of a specified sequence

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetSequenceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:54254";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SequencesApi(config);
            var scope = scope_example;  // string | Scope of the sequence.
            var code = code_example;  // string | Code of the sequence. This together with stated scope uniquely              identifies the sequence.

            try
            {
                // [EXPERIMENTAL] GetSequence: Get a specified sequence
                SequenceDefinition result = apiInstance.GetSequence(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SequencesApi.GetSequence: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **scope** | **string**| Scope of the sequence. | 
 **code** | **string**| Code of the sequence. This together with stated scope uniquely              identifies the sequence. | 

### Return type

[**SequenceDefinition**](SequenceDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested sequence |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="next"></a>
# **Next**
> NextValueInSequenceResponse Next (string scope, string code, int? batch = null)

[EXPERIMENTAL] Next: Get next values from sequence

Get the next set of values from a specified sequence

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class NextExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:54254";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SequencesApi(config);
            var scope = scope_example;  // string | Scope of the sequence.
            var code = code_example;  // string | Code of the sequence. This together with stated scope uniquely              identifies the sequence.
            var batch = 56;  // int? | Number of sequences items to return for the specified sequence. Default to 1 if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] Next: Get next values from sequence
                NextValueInSequenceResponse result = apiInstance.Next(scope, code, batch);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SequencesApi.Next: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **scope** | **string**| Scope of the sequence. | 
 **code** | **string**| Code of the sequence. This together with stated scope uniquely              identifies the sequence. | 
 **batch** | **int?**| Number of sequences items to return for the specified sequence. Default to 1 if not specified. | [optional] 

### Return type

[**NextValueInSequenceResponse**](NextValueInSequenceResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The response containing next available values in specified sequence. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

