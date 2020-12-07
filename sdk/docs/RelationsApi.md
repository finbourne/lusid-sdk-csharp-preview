# Lusid.Sdk.Api.RelationsApi

All URIs are relative to *http://localhost:59993*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRelation**](RelationsApi.md#createrelation) | **POST** /api/relations/{scope}/{code} | [EXPERIMENTAL] Create Relation



## CreateRelation

> CompleteRelation CreateRelation (string scope, string code, CreateRelationRequest createRelationRequest, DateTimeOrCutLabel effectiveAt = null)

[EXPERIMENTAL] Create Relation

Create a relation between two entity objects by their identifiers

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateRelationExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost:59993";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RelationsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the relation to create.
            var code = code_example;  // string | Code of the relation to create.
            var createRelationRequest = new CreateRelationRequest(); // CreateRelationRequest | The details of the relation to create.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which the relation should be effective from. Defaults to the current LUSID system datetime if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] Create Relation
                CompleteRelation result = apiInstance.CreateRelation(scope, code, createRelationRequest, effectiveAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RelationsApi.CreateRelation: " + e.Message );
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
 **scope** | **string**| Scope of the relation to create. | 
 **code** | **string**| Code of the relation to create. | 
 **createRelationRequest** | [**CreateRelationRequest**](CreateRelationRequest.md)| The details of the relation to create. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which the relation should be effective from. Defaults to the current LUSID system datetime if not specified. | [optional] 

### Return type

[**CompleteRelation**](CompleteRelation.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The newly created relation. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

