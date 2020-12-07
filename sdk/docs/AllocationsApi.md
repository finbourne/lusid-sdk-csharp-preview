# Lusid.Sdk.Api.AllocationsApi

All URIs are relative to *http://localhost:34709*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAllocation**](AllocationsApi.md#getallocation) | **GET** /api/allocations/{scope}/{code} | [EXPERIMENTAL] Get Allocation
[**ListAllocations**](AllocationsApi.md#listallocations) | **GET** /api/allocations | [EXPERIMENTAL] List Allocations
[**UpsertAllocations**](AllocationsApi.md#upsertallocations) | **POST** /api/allocations | [EXPERIMENTAL] Upsert Allocations



## GetAllocation

> Allocation GetAllocation (string scope, string code, DateTimeOffset? asAt = null, List<string> propertyKeys = null)

[EXPERIMENTAL] Get Allocation

Fetch an Allocation matching the provided identifier

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetAllocationExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost:34709";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AllocationsApi(Configuration.Default);
            var scope = scope_example;  // string | The scope to which the allocation belongs.
            var code = code_example;  // string | The allocation's unique identifier.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the allocation. Defaults to return the latest version of the allocation if not specified. (optional) 
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the \"Allocations\" domain to decorate onto the allocation.              These take the format {domain}/{scope}/{code} e.g. \"Allocations/system/Name\". (optional) 

            try
            {
                // [EXPERIMENTAL] Get Allocation
                Allocation result = apiInstance.GetAllocation(scope, code, asAt, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AllocationsApi.GetAllocation: " + e.Message );
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
 **scope** | **string**| The scope to which the allocation belongs. | 
 **code** | **string**| The allocation&#39;s unique identifier. | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the allocation. Defaults to return the latest version of the allocation if not specified. | [optional] 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the \&quot;Allocations\&quot; domain to decorate onto the allocation.              These take the format {domain}/{scope}/{code} e.g. \&quot;Allocations/system/Name\&quot;. | [optional] 

### Return type

[**Allocation**](Allocation.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The allocation matching the given identifier. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListAllocations

> PagedResourceListOfAllocation ListAllocations (DateTimeOffset? asAt = null, string page = null, List<string> sortBy = null, int? start = null, int? limit = null, string filter = null, List<string> propertyKeys = null)

[EXPERIMENTAL] List Allocations

Fetch the last pre-AsAt date version of each allocation in scope (does not fetch the entire history).

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListAllocationsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost:34709";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AllocationsApi(Configuration.Default);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the allocation. Defaults to return the latest version of the allocation if not specified. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing allocations from a previous call to list allocations.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, effectiveAt, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var sortBy = new List<string>(); // List<string> | Allocation the results by these fields. Use use the '-' sign to denote descending allocation e.g. -MyFieldName. (optional) 
            var start = 56;  // int? | When paginating, skip this number of results. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here:              https://support.lusid.com/filtering-results-from-lusid. (optional)  (default to "")
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the \"Allocations\" domain to decorate onto each allocation.                  These take the format {domain}/{scope}/{code} e.g. \"Allocations/system/Name\". (optional) 

            try
            {
                // [EXPERIMENTAL] List Allocations
                PagedResourceListOfAllocation result = apiInstance.ListAllocations(asAt, page, sortBy, start, limit, filter, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AllocationsApi.ListAllocations: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the allocation. Defaults to return the latest version of the allocation if not specified. | [optional] 
 **page** | **string**| The pagination token to use to continue listing allocations from a previous call to list allocations.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, effectiveAt, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Allocation the results by these fields. Use use the &#39;-&#39; sign to denote descending allocation e.g. -MyFieldName. | [optional] 
 **start** | **int?**| When paginating, skip this number of results. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here:              https://support.lusid.com/filtering-results-from-lusid. | [optional] [default to &quot;&quot;]
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the \&quot;Allocations\&quot; domain to decorate onto each allocation.                  These take the format {domain}/{scope}/{code} e.g. \&quot;Allocations/system/Name\&quot;. | [optional] 

### Return type

[**PagedResourceListOfAllocation**](PagedResourceListOfAllocation.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Allocations. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertAllocations

> ResourceListOfAllocation UpsertAllocations (AllocationSetRequest allocationSetRequest = null)

[EXPERIMENTAL] Upsert Allocations

Upsert; update existing allocations with given ids, or create new allocations otherwise.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertAllocationsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost:34709";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AllocationsApi(Configuration.Default);
            var allocationSetRequest = new AllocationSetRequest(); // AllocationSetRequest | The collection of allocation requests. (optional) 

            try
            {
                // [EXPERIMENTAL] Upsert Allocations
                ResourceListOfAllocation result = apiInstance.UpsertAllocations(allocationSetRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AllocationsApi.UpsertAllocations: " + e.Message );
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
 **allocationSetRequest** | [**AllocationSetRequest**](AllocationSetRequest.md)| The collection of allocation requests. | [optional] 

### Return type

[**ResourceListOfAllocation**](ResourceListOfAllocation.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A collection of allocations. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

