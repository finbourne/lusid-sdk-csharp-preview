# Lusid.Sdk.Api.CustomEntityDefinitionsApi

All URIs are relative to *http://local-unit-test-server.lusid.com:30423*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateCustomEntityDefinition**](CustomEntityDefinitionsApi.md#createcustomentitydefinition) | **POST** /api/customentitydefinitions | [EXPERIMENTAL] Create a new CustomEntityDefinition
[**GetDefinition**](CustomEntityDefinitionsApi.md#getdefinition) | **GET** /api/customentitydefinitions/{customEntityId} | [EXPERIMENTAL] Get CustomEntityDefinition



## CreateCustomEntityDefinition

> CustomEntityDefinition CreateCustomEntityDefinition (CustomEntityDefinitionRequest customEntityDefinitionRequest = null)

[EXPERIMENTAL] Create a new CustomEntityDefinition

Create a custom entity definition that does not already exist. Will return a Bad Request if the CustomEntityDefinition already exists

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateCustomEntityDefinitionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:30423";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomEntityDefinitionsApi(Configuration.Default);
            var customEntityDefinitionRequest = new CustomEntityDefinitionRequest(); // CustomEntityDefinitionRequest | The CustomEntityDefinitionRequest (optional) 

            try
            {
                // [EXPERIMENTAL] Create a new CustomEntityDefinition
                CustomEntityDefinition result = apiInstance.CreateCustomEntityDefinition(customEntityDefinitionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CustomEntityDefinitionsApi.CreateCustomEntityDefinition: " + e.Message );
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
 **customEntityDefinitionRequest** | [**CustomEntityDefinitionRequest**](CustomEntityDefinitionRequest.md)| The CustomEntityDefinitionRequest | [optional] 

### Return type

[**CustomEntityDefinition**](CustomEntityDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The created custom entity definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetDefinition

> CustomEntityDefinition GetDefinition (string customEntityId, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get CustomEntityDefinition

Retrieve a CustomEntityDefinition by a specific Id at a point in AsAt time

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetDefinitionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:30423";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomEntityDefinitionsApi(Configuration.Default);
            var customEntityId = customEntityId_example;  // string | Id of the CustomEntityDefinition
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The AsAt at which to retrieve the CustomEntityDefinition (optional) 

            try
            {
                // [EXPERIMENTAL] Get CustomEntityDefinition
                CustomEntityDefinition result = apiInstance.GetDefinition(customEntityId, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CustomEntityDefinitionsApi.GetDefinition: " + e.Message );
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
 **customEntityId** | **string**| Id of the CustomEntityDefinition | 
 **asAt** | **DateTimeOffset?**| The AsAt at which to retrieve the CustomEntityDefinition | [optional] 

### Return type

[**CustomEntityDefinition**](CustomEntityDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested custom entity definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

