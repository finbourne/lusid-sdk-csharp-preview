# Lusid.Sdk.Api.CustomEntityDefinitionsApi

All URIs are relative to *http://local-unit-test-server.lusid.com:49860*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateCustomEntityDefinition**](CustomEntityDefinitionsApi.md#createcustomentitydefinition) | **POST** /api/customentities/entitytypes | [EXPERIMENTAL] CreateCustomEntityDefinition: Define a new custom entityType.
[**GetDefinition**](CustomEntityDefinitionsApi.md#getdefinition) | **GET** /api/customentities/entitytypes/{entityType} | [EXPERIMENTAL] GetDefinition: Get a custom entityType definition.


<a name="createcustomentitydefinition"></a>
# **CreateCustomEntityDefinition**
> CustomEntityDefinition CreateCustomEntityDefinition (CustomEntityDefinitionRequest customEntityDefinitionRequest)

[EXPERIMENTAL] CreateCustomEntityDefinition: Define a new custom entityType.

The API will return a Bad Request if the custom entityType already exists.

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
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:49860";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomEntityDefinitionsApi(config);
            var customEntityDefinitionRequest = new CustomEntityDefinitionRequest(); // CustomEntityDefinitionRequest | The payload containing the description of the custom entityType.

            try
            {
                // [EXPERIMENTAL] CreateCustomEntityDefinition: Define a new custom entityType.
                CustomEntityDefinition result = apiInstance.CreateCustomEntityDefinition(customEntityDefinitionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
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
 **customEntityDefinitionRequest** | [**CustomEntityDefinitionRequest**](CustomEntityDefinitionRequest.md)| The payload containing the description of the custom entityType. | 

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
| **200** | The created custom entityType. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdefinition"></a>
# **GetDefinition**
> CustomEntityDefinition GetDefinition (string entityType, DateTimeOffset? asAt = null)

[EXPERIMENTAL] GetDefinition: Get a custom entityType definition.

Retrieve a CustomEntityDefinition by a specific EntityType at a point in AsAt time

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
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:49860";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomEntityDefinitionsApi(config);
            var entityType = entityType_example;  // string | The identifier for the custom entity type, derived from the \"entityTypeName\" provided on creation.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The AsAt datetime at which to retrieve the definition. (optional) 

            try
            {
                // [EXPERIMENTAL] GetDefinition: Get a custom entityType definition.
                CustomEntityDefinition result = apiInstance.GetDefinition(entityType, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
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
 **entityType** | **string**| The identifier for the custom entity type, derived from the \&quot;entityTypeName\&quot; provided on creation. | 
 **asAt** | **DateTimeOffset?**| The AsAt datetime at which to retrieve the definition. | [optional] 

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
| **200** | The requested custom entity definition. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

