# Lusid.Sdk.Api.SequencesApi

All URIs are relative to *http://local-unit-test-server.lusid.com:39923*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateSequence**](SequencesApi.md#createsequence) | **POST** /api/sequences/{scope} | [EXPERIMENTAL] Create a new sequence
[**GetSequenceDefinition**](SequencesApi.md#getsequencedefinition) | **GET** /api/sequences/{scope}/{code} | [EXPERIMENTAL] Return the definition of a sequence
[**Next**](SequencesApi.md#next) | **GET** /api/sequences/{scope}/{code}/next | [EXPERIMENTAL] Get the next set of values from the sequence


<a name="createsequence"></a>
# **CreateSequence**
> SequenceDefinition CreateSequence (string scope, CreateSequenceRequest createSequenceRequest = null)

[EXPERIMENTAL] Create a new sequence

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
            config.BasePath = "http://local-unit-test-server.lusid.com:39923";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SequencesApi(config);
            var scope = scope_example;  // string | Scope of the sequence definition.
            var createSequenceRequest = new CreateSequenceRequest(); // CreateSequenceRequest | Request to create sequence definition. (optional) 

            try
            {
                // [EXPERIMENTAL] Create a new sequence
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
 **scope** | **string**| Scope of the sequence definition. | 
 **createSequenceRequest** | [**CreateSequenceRequest**](CreateSequenceRequest.md)| Request to create sequence definition. | [optional] 

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
| **201** | Successful creation of the sequence |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsequencedefinition"></a>
# **GetSequenceDefinition**
> SequenceDefinition GetSequenceDefinition (string scope, string code)

[EXPERIMENTAL] Return the definition of a sequence

Return the detailed definition of a sequence

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetSequenceDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:39923";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SequencesApi(config);
            var scope = scope_example;  // string | Scope of the sequence definition.
            var code = code_example;  // string | Code of the sequence definition. This together with stated scope uniquely              identifies the sequence definition.

            try
            {
                // [EXPERIMENTAL] Return the definition of a sequence
                SequenceDefinition result = apiInstance.GetSequenceDefinition(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SequencesApi.GetSequenceDefinition: " + e.Message );
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
 **scope** | **string**| Scope of the sequence definition. | 
 **code** | **string**| Code of the sequence definition. This together with stated scope uniquely              identifies the sequence definition. | 

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

[EXPERIMENTAL] Get the next set of values from the sequence

Get the next set of values from the sequence

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
            config.BasePath = "http://local-unit-test-server.lusid.com:39923";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SequencesApi(config);
            var scope = scope_example;  // string | Scope of the sequence definition.
            var code = code_example;  // string | Code of the sequence definition. This together with stated scope uniquely              identifies the sequence definition.
            var batch = 56;  // int? | Number of sequences items to return for the specified sequence definition. (optional)  (default to 1)

            try
            {
                // [EXPERIMENTAL] Get the next set of values from the sequence
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
 **scope** | **string**| Scope of the sequence definition. | 
 **code** | **string**| Code of the sequence definition. This together with stated scope uniquely              identifies the sequence definition. | 
 **batch** | **int?**| Number of sequences items to return for the specified sequence definition. | [optional] [default to 1]

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
| **200** | Gets the next set of values for the sequence |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

