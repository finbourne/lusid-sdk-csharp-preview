# Lusid.Sdk.Api.RelationshipDefinitionsApi

All URIs are relative to *http://local-unit-test-server.lusid.com:37050*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRelationshipDefinition**](RelationshipDefinitionsApi.md#createrelationshipdefinition) | **POST** /api/relationshipdefinitions | [EXPERIMENTAL] Create Relationship Definition
[**GetRelationshipDefinition**](RelationshipDefinitionsApi.md#getrelationshipdefinition) | **GET** /api/relationshipdefinitions/{scope}/{code} | [EXPERIMENTAL] Get relationship definition
[**UpdateRelationshipDefinition**](RelationshipDefinitionsApi.md#updaterelationshipdefinition) | **PUT** /api/relationshipdefinitions/{scope}/{code} | [EXPERIMENTAL] Update Relationship Definition



## CreateRelationshipDefinition

> RelationshipDefinition CreateRelationshipDefinition (CreateRelationshipDefinitionRequest createRelationshipDefinitionRequest)

[EXPERIMENTAL] Create Relationship Definition

Create a new relationship definition to be used for creating relationships between entities.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateRelationshipDefinitionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:37050";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RelationshipDefinitionsApi(Configuration.Default);
            var createRelationshipDefinitionRequest = new CreateRelationshipDefinitionRequest(); // CreateRelationshipDefinitionRequest | The definition of the new relationship.

            try
            {
                // [EXPERIMENTAL] Create Relationship Definition
                RelationshipDefinition result = apiInstance.CreateRelationshipDefinition(createRelationshipDefinitionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RelationshipDefinitionsApi.CreateRelationshipDefinition: " + e.Message );
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
 **createRelationshipDefinitionRequest** | [**CreateRelationshipDefinitionRequest**](CreateRelationshipDefinitionRequest.md)| The definition of the new relationship. | 

### Return type

[**RelationshipDefinition**](RelationshipDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The newly created relationship definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetRelationshipDefinition

> RelationshipDefinition GetRelationshipDefinition (string scope, string code, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get relationship definition

Retrieve the specified relationship definition

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetRelationshipDefinitionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:37050";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RelationshipDefinitionsApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the specified relationship definition.
            var code = code_example;  // string | The code of the specified relationship definition. Together with the domain and scope this uniquely              identifies the relationship definition.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the relationship definition. Defaults to return              the latest version of the definition if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] Get relationship definition
                RelationshipDefinition result = apiInstance.GetRelationshipDefinition(scope, code, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RelationshipDefinitionsApi.GetRelationshipDefinition: " + e.Message );
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
 **scope** | **string**| The scope of the specified relationship definition. | 
 **code** | **string**| The code of the specified relationship definition. Together with the domain and scope this uniquely              identifies the relationship definition. | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the relationship definition. Defaults to return              the latest version of the definition if not specified. | [optional] 

### Return type

[**RelationshipDefinition**](RelationshipDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested relationship definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpdateRelationshipDefinition

> RelationshipDefinition UpdateRelationshipDefinition (string scope, string code, UpdateRelationshipDefinitionRequest updateRelationshipDefinitionRequest)

[EXPERIMENTAL] Update Relationship Definition

Update the definition of a specified existing relationship. Not all elements within a relationship definition  are modifiable due to the potential implications for values already stored against the relationship.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpdateRelationshipDefinitionExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:37050";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RelationshipDefinitionsApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the relationship definition being updated.
            var code = code_example;  // string | The code of the relationship definition being updated. Together with the scope this uniquely              identifies the relationship definition.
            var updateRelationshipDefinitionRequest = new UpdateRelationshipDefinitionRequest(); // UpdateRelationshipDefinitionRequest | The details of relationship definition to update.

            try
            {
                // [EXPERIMENTAL] Update Relationship Definition
                RelationshipDefinition result = apiInstance.UpdateRelationshipDefinition(scope, code, updateRelationshipDefinitionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RelationshipDefinitionsApi.UpdateRelationshipDefinition: " + e.Message );
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
 **scope** | **string**| The scope of the relationship definition being updated. | 
 **code** | **string**| The code of the relationship definition being updated. Together with the scope this uniquely              identifies the relationship definition. | 
 **updateRelationshipDefinitionRequest** | [**UpdateRelationshipDefinitionRequest**](UpdateRelationshipDefinitionRequest.md)| The details of relationship definition to update. | 

### Return type

[**RelationshipDefinition**](RelationshipDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The updated relationship definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

