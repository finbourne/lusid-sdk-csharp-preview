# Lusid.Sdk.Api.ConventionsApi

All URIs are relative to *http://localhost:47515*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteConventions**](ConventionsApi.md#deleteconventions) | **DELETE** /api/conventions/{scope}/{code} | [EXPERIMENTAL] Delete the conventions of given scope and code, assuming that it is present.
[**GetFlowConventions**](ConventionsApi.md#getflowconventions) | **GET** /api/conventions/{scope}/{code} | [EXPERIMENTAL] Get Flow Conventions
[**ListConventions**](ConventionsApi.md#listconventions) | **GET** /api/conventions | [EXPERIMENTAL] List the set of conventions



## DeleteConventions

> AnnulSingleStructuredDataResponse DeleteConventions (string scope, string code)

[EXPERIMENTAL] Delete the conventions of given scope and code, assuming that it is present.

Delete the specified conventions from a single scope.  The response will return either detail of the deleted item, or an explanation (failure) as to why this did not succeed.  It is important to always check for any unsuccessful response.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteConventionsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost:47515";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConventionsApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the conventions to delete.
            var code = code_example;  // string | The conventions to delete.

            try
            {
                // [EXPERIMENTAL] Delete the conventions of given scope and code, assuming that it is present.
                AnnulSingleStructuredDataResponse result = apiInstance.DeleteConventions(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ConventionsApi.DeleteConventions: " + e.Message );
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
 **scope** | **string**| The scope of the conventions to delete. | 
 **code** | **string**| The conventions to delete. | 

### Return type

[**AnnulSingleStructuredDataResponse**](AnnulSingleStructuredDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The AsAt of deletion or failure |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetFlowConventions

> GetConventionsResponse GetFlowConventions (string scope, string code, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get Flow Conventions

Get a Flow Conventions from a single scope.  The response will return either the conventions that has been stored, or a failure explaining why the request was unsuccessful.  It is important to always check for any unsuccessful requests (failures).

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetFlowConventionsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost:47515";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConventionsApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the Flow Conventions to retrieve.
            var code = code_example;  // string | The name of the Flow Conventions to retrieve the data for.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the Flow Conventions. Defaults to return the latest version if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] Get Flow Conventions
                GetConventionsResponse result = apiInstance.GetFlowConventions(scope, code, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ConventionsApi.GetFlowConventions: " + e.Message );
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
 **scope** | **string**| The scope of the Flow Conventions to retrieve. | 
 **code** | **string**| The name of the Flow Conventions to retrieve the data for. | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the Flow Conventions. Defaults to return the latest version if not specified. | [optional] 

### Return type

[**GetConventionsResponse**](GetConventionsResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully retrieved Flow Conventions or any failure |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListConventions

> ResourceListOfGetConventionsResponse ListConventions (DateTimeOffset? asAt = null)

[EXPERIMENTAL] List the set of conventions

List the set of conventions at the specified date/time

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListConventionsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost:47515";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConventionsApi(Configuration.Default);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to list the conventions. Defaults to latest if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] List the set of conventions
                ResourceListOfGetConventionsResponse result = apiInstance.ListConventions(asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ConventionsApi.ListConventions: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to list the conventions. Defaults to latest if not specified. | [optional] 

### Return type

[**ResourceListOfGetConventionsResponse**](ResourceListOfGetConventionsResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested conventions |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

