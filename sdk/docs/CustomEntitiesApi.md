# Lusid.Sdk.Api.CustomEntitiesApi

All URIs are relative to *http://local-unit-test-server.lusid.com:60823*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetCustomEntity**](CustomEntitiesApi.md#getcustomentity) | **GET** /api/customentities/{entityType}/{identifierType}/{identifierValue} | [EXPERIMENTAL] Get CustomEntity
[**UpsertCustomEntity**](CustomEntitiesApi.md#upsertcustomentity) | **POST** /api/customentities/{entityType} | [EXPERIMENTAL] Upsert a new CustomEntity


<a name="getcustomentity"></a>
# **GetCustomEntity**
> CustomEntityResponse GetCustomEntity (string entityType, string identifierType, string identifierValue, string identifierScope, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get CustomEntity

Retrieve a CustomEntity by a specific Id at a point in AsAt time

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetCustomEntityExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:60823";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomEntitiesApi(config);
            var entityType = entityType_example;  // string | The type of entity to retrieve. This is included in the response from M:Finbourne.WebApi.Controllers.CustomEntityDefinitionController.CreateCustomEntityDefinition(Finbourne.WebApi.Interface.Dto.CustomEntityDefinitions.CustomEntityDefinitionRequest).
            var identifierType = identifierType_example;  // string | An identifier type attached to the CustomEntity
            var identifierValue = identifierValue_example;  // string | The identifier value
            var identifierScope = identifierScope_example;  // string | The identifier scope
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The AsAt at which to retrieve the CustomEntity (optional) 

            try
            {
                // [EXPERIMENTAL] Get CustomEntity
                CustomEntityResponse result = apiInstance.GetCustomEntity(entityType, identifierType, identifierValue, identifierScope, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomEntitiesApi.GetCustomEntity: " + e.Message );
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
 **entityType** | **string**| The type of entity to retrieve. This is included in the response from M:Finbourne.WebApi.Controllers.CustomEntityDefinitionController.CreateCustomEntityDefinition(Finbourne.WebApi.Interface.Dto.CustomEntityDefinitions.CustomEntityDefinitionRequest). | 
 **identifierType** | **string**| An identifier type attached to the CustomEntity | 
 **identifierValue** | **string**| The identifier value | 
 **identifierScope** | **string**| The identifier scope | 
 **asAt** | **DateTimeOffset?**| The AsAt at which to retrieve the CustomEntity | [optional] 

### Return type

[**CustomEntityResponse**](CustomEntityResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested Custom Entity |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="upsertcustomentity"></a>
# **UpsertCustomEntity**
> CustomEntityResponse UpsertCustomEntity (string entityType, CustomEntityRequest customEntityRequest)

[EXPERIMENTAL] Upsert a new CustomEntity

Insert the custom entity if it does not exist or update the custom entity with the supplied state if it does exist.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertCustomEntityExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:60823";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomEntitiesApi(config);
            var entityType = entityType_example;  // string | The type of the CustomEntity to be created. An entityType can be created using the M:Finbourne.WebApi.Controllers.CustomEntityDefinitionController.GetDefinition(System.String,System.Nullable{System.DateTimeOffset}) endpoint.
            var customEntityRequest = new CustomEntityRequest(); // CustomEntityRequest | The CustomEntity to be created

            try
            {
                // [EXPERIMENTAL] Upsert a new CustomEntity
                CustomEntityResponse result = apiInstance.UpsertCustomEntity(entityType, customEntityRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomEntitiesApi.UpsertCustomEntity: " + e.Message );
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
 **entityType** | **string**| The type of the CustomEntity to be created. An entityType can be created using the M:Finbourne.WebApi.Controllers.CustomEntityDefinitionController.GetDefinition(System.String,System.Nullable{System.DateTimeOffset}) endpoint. | 
 **customEntityRequest** | [**CustomEntityRequest**](CustomEntityRequest.md)| The CustomEntity to be created | 

### Return type

[**CustomEntityResponse**](CustomEntityResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The upserted Custom Entity |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

