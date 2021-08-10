# Lusid.Sdk.Api.RelationshipsApi

All URIs are relative to *http://local-unit-test-server.lusid.com:39653*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRelationship**](RelationshipsApi.md#createrelationship) | **POST** /api/relationshipdefinitions/{scope}/{code}/relationships | [EXPERIMENTAL] Create Relationship
[**DeleteRelationship**](RelationshipsApi.md#deleterelationship) | **POST** /api/relationshipdefinitions/{scope}/{code}/relationships/$delete | [EXPERIMENTAL] Delete Relationship



## CreateRelationship

> CompleteRelationship CreateRelationship (string scope, string code, CreateRelationshipRequest createRelationshipRequest)

[EXPERIMENTAL] Create Relationship

Create a relationship between two entity objects by their identifiers

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateRelationshipExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:39653";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RelationshipsApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the relationship
            var code = code_example;  // string | The code of the relationship
            var createRelationshipRequest = new CreateRelationshipRequest(); // CreateRelationshipRequest | The details of the relationship to create.

            try
            {
                // [EXPERIMENTAL] Create Relationship
                CompleteRelationship result = apiInstance.CreateRelationship(scope, code, createRelationshipRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RelationshipsApi.CreateRelationship: " + e.Message );
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
 **scope** | **string**| The scope of the relationship | 
 **code** | **string**| The code of the relationship | 
 **createRelationshipRequest** | [**CreateRelationshipRequest**](CreateRelationshipRequest.md)| The details of the relationship to create. | 

### Return type

[**CompleteRelationship**](CompleteRelationship.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The newly created relationship. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteRelationship

> DeletedEntityResponse DeleteRelationship (string scope, string code, DeleteRelationshipRequest deleteRelationshipRequest)

[EXPERIMENTAL] Delete Relationship

Delete a relationship between two entity objects represented by their identifiers

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteRelationshipExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:39653";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RelationshipsApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the relationship
            var code = code_example;  // string | The code of the relationship
            var deleteRelationshipRequest = new DeleteRelationshipRequest(); // DeleteRelationshipRequest | The details of the relationship to delete.

            try
            {
                // [EXPERIMENTAL] Delete Relationship
                DeletedEntityResponse result = apiInstance.DeleteRelationship(scope, code, deleteRelationshipRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RelationshipsApi.DeleteRelationship: " + e.Message );
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
 **scope** | **string**| The scope of the relationship | 
 **code** | **string**| The code of the relationship | 
 **deleteRelationshipRequest** | [**DeleteRelationshipRequest**](DeleteRelationshipRequest.md)| The details of the relationship to delete. | 

### Return type

[**DeletedEntityResponse**](DeletedEntityResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The datetime that the relationship is deleted |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

