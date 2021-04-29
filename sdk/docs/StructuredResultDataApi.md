# Lusid.Sdk.Api.StructuredResultDataApi

All URIs are relative to *http://local-unit-test-server.lusid.com:63334*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateDataMap**](StructuredResultDataApi.md#createdatamap) | **POST** /api/unitresults/datamap/{scope} | [EXPERIMENTAL] Upsert a set of structured result address definition maps. This creates or updates the data in Lusid.
[**DeleteStructuredResultData**](StructuredResultDataApi.md#deletestructuredresultdata) | **POST** /api/unitresults/{scope}/$delete | [EXPERIMENTAL] Delete one or more items of structured result data, assuming they are present.
[**GetDataMap**](StructuredResultDataApi.md#getdatamap) | **POST** /api/unitresults/datamap/{scope}/$get | [EXPERIMENTAL] Get the result address definition maps from the store
[**GetStructuredResultData**](StructuredResultDataApi.md#getstructuredresultdata) | **POST** /api/unitresults/{scope}/$get | [EXPERIMENTAL] Get structured result data
[**UpsertStructuredResultData**](StructuredResultDataApi.md#upsertstructuredresultdata) | **POST** /api/unitresults/{scope} | [EXPERIMENTAL] Upsert a set of structured result data items. This creates or updates the data in Lusid.



## CreateDataMap

> UpsertStructuredDataResponse CreateDataMap (string scope, Dictionary<string, CreateDataMapRequest> requestBody)

[EXPERIMENTAL] Upsert a set of structured result address definition maps. This creates or updates the data in Lusid.

Create one or more structured result address definition map items in a single scope. These are immutable and cannot be changed once inserted                In the request each data map item must be keyed by a unique correlation id. This id is ephemeral and is not stored by LUSID.  It serves only as a way to easily identify each structured result data in the response.                The response will return both the collection of successfully updated or inserted data maps, as well as those that failed.  For the failures a reason will be provided explaining why the item could not be updated or inserted.                It is important to always check the failed set for any unsuccessful results.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateDataMapExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:63334";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new StructuredResultDataApi(Configuration.Default);
            var scope = scope_example;  // string | Scope in which to upsert the result address definition maps
            var requestBody = new Dictionary<string, CreateDataMapRequest>(); // Dictionary<string, CreateDataMapRequest> | Individual result address definition map creation requests

            try
            {
                // [EXPERIMENTAL] Upsert a set of structured result address definition maps. This creates or updates the data in Lusid.
                UpsertStructuredDataResponse result = apiInstance.CreateDataMap(scope, requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling StructuredResultDataApi.CreateDataMap: " + e.Message );
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
 **scope** | **string**| Scope in which to upsert the result address definition maps | 
 **requestBody** | [**Dictionary&lt;string, CreateDataMapRequest&gt;**](CreateDataMapRequest.md)| Individual result address definition map creation requests | 

### Return type

[**UpsertStructuredDataResponse**](UpsertStructuredDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully created data maps along with any failures |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteStructuredResultData

> AnnulStructuredDataResponse DeleteStructuredResultData (string scope, Dictionary<string, StructuredResultDataId> requestBody)

[EXPERIMENTAL] Delete one or more items of structured result data, assuming they are present.

Delete one or more specified structured result data items from a single scope. Each item is identified by a unique id which includes  information about its type as well as the exact effective datetime (to the microsecond) at which it entered the system (became valid).                In the request each market data item must be keyed by a unique correlation id. This id is ephemeral and is not stored by LUSID.  It serves only as a way to easily identify each quote in the response.                The response will return both the collection of successfully deleted market data items, as well as those that failed.  For the failures a reason will be provided explaining why the it could not be deleted.                It is important to always check the failed set for any unsuccessful results.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteStructuredResultDataExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:63334";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new StructuredResultDataApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the structured result data to delete.
            var requestBody = new Dictionary<string, StructuredResultDataId>(); // Dictionary<string, StructuredResultDataId> | The structured result data Ids to delete, each keyed by a unique correlation id.

            try
            {
                // [EXPERIMENTAL] Delete one or more items of structured result data, assuming they are present.
                AnnulStructuredDataResponse result = apiInstance.DeleteStructuredResultData(scope, requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling StructuredResultDataApi.DeleteStructuredResultData: " + e.Message );
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
 **scope** | **string**| The scope of the structured result data to delete. | 
 **requestBody** | [**Dictionary&lt;string, StructuredResultDataId&gt;**](StructuredResultDataId.md)| The structured result data Ids to delete, each keyed by a unique correlation id. | 

### Return type

[**AnnulStructuredDataResponse**](AnnulStructuredDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully deleted result data along with any failures |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetDataMap

> GetDataMapResponse GetDataMap (string scope, Dictionary<string, DataMapKey> requestBody)

[EXPERIMENTAL] Get the result address definition maps from the store

Get one or more result address definition map from a single scope.                Each item can be identified by its invariant Data Map key, which can be thought of as a permanent URL.                For each id LUSID will return the most recent matched item.                In the request each structured result data id must be keyed by a unique correlation id. This id is ephemeral and is not stored by LUSID.  It serves only as a way to easily identify each item in the response.                The response will return three collections. One, the successfully retrieved structured result data. Two, those that had a  valid identifier but could not be found. Three, those that failed because LUSID could not construct a valid identifier from the request.                For the ids that failed to resolve or could not be found a reason will be provided explaining why that is the case.                It is important to always check the failed and not found sets for any unsuccessful results.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetDataMapExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:63334";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new StructuredResultDataApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the result address definition map keys
            var requestBody = new Dictionary<string, DataMapKey>(); // Dictionary<string, DataMapKey> | The result address definition map keys to lookup

            try
            {
                // [EXPERIMENTAL] Get the result address definition maps from the store
                GetDataMapResponse result = apiInstance.GetDataMap(scope, requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling StructuredResultDataApi.GetDataMap: " + e.Message );
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
 **scope** | **string**| The scope of the result address definition map keys | 
 **requestBody** | [**Dictionary&lt;string, DataMapKey&gt;**](DataMapKey.md)| The result address definition map keys to lookup | 

### Return type

[**GetDataMapResponse**](GetDataMapResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully retrieved data maps along with any failures |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetStructuredResultData

> GetStructuredResultDataResponse GetStructuredResultData (string scope, Dictionary<string, StructuredResultDataId> requestBody, DateTimeOffset? asAt = null, string maxAge = null)

[EXPERIMENTAL] Get structured result data

Get one or more items of structured result data from a single scope.                Each item can be identified by its time invariant structured result data identifier.                For each id LUSID will return the most recent matched item with respect to the provided (or default) effective datetime.                 An optional maximum age range window can be specified which defines how far back to look back for data from the specified effective datetime.  LUSID will return the most recent item within this window.                In the request each structured result data id must be keyed by a unique correlation id. This id is ephemeral and is not stored by LUSID.  It serves only as a way to easily identify each item in the response.                The response will return three collections. One, the successfully retrieved structured result data. Two, those that had a  valid identifier but could not be found. Three, those that failed because LUSID could not construct a valid identifier from the request.    For the ids that failed to resolve or could not be found a reason will be provided explaining why that is the case.                It is important to always check the failed and not found sets for any unsuccessful results.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetStructuredResultDataExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:63334";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new StructuredResultDataApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the structured result data to retrieve.
            var requestBody = new Dictionary<string, StructuredResultDataId>(); // Dictionary<string, StructuredResultDataId> | The time invariant set of structured data identifiers to retrieve the data for. These need to be               keyed by a unique correlation id allowing the retrieved item to be identified in the response.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the structured result data. Defaults to return the latest version if not specified. (optional) 
            var maxAge = maxAge_example;  // string | The duration of the look back window in an ISO8601 time interval format e.g. P1Y2M3DT4H30M (1 year, 2 months, 3 days, 4 hours and 30 minutes).               This is subtracted from the provided effectiveAt datetime to generate a effective datetime window inside which a structured result data item must exist to be retrieved. (optional) 

            try
            {
                // [EXPERIMENTAL] Get structured result data
                GetStructuredResultDataResponse result = apiInstance.GetStructuredResultData(scope, requestBody, asAt, maxAge);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling StructuredResultDataApi.GetStructuredResultData: " + e.Message );
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
 **scope** | **string**| The scope of the structured result data to retrieve. | 
 **requestBody** | [**Dictionary&lt;string, StructuredResultDataId&gt;**](StructuredResultDataId.md)| The time invariant set of structured data identifiers to retrieve the data for. These need to be               keyed by a unique correlation id allowing the retrieved item to be identified in the response. | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the structured result data. Defaults to return the latest version if not specified. | [optional] 
 **maxAge** | **string**| The duration of the look back window in an ISO8601 time interval format e.g. P1Y2M3DT4H30M (1 year, 2 months, 3 days, 4 hours and 30 minutes).               This is subtracted from the provided effectiveAt datetime to generate a effective datetime window inside which a structured result data item must exist to be retrieved. | [optional] 

### Return type

[**GetStructuredResultDataResponse**](GetStructuredResultDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully retrieved structured result data along with any failures |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertStructuredResultData

> UpsertStructuredDataResponse UpsertStructuredResultData (string scope, Dictionary<string, UpsertStructuredResultDataRequest> requestBody)

[EXPERIMENTAL] Upsert a set of structured result data items. This creates or updates the data in Lusid.

Update or insert one or more structured result data items in a single scope. An item will be updated if it already exists  and inserted if it does not.                In the request each structured result data item must be keyed by a unique correlation id. This id is ephemeral and is not stored by LUSID.  It serves only as a way to easily identify each structured result data in the response.                The response will return both the collection of successfully updated or inserted structured result data, as well as those that failed.  For the failures a reason will be provided explaining why the item could not be updated or inserted.                It is important to always check the failed set for any unsuccessful results.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertStructuredResultDataExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:63334";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new StructuredResultDataApi(Configuration.Default);
            var scope = scope_example;  // string | The scope to use when updating or inserting the structured result data.
            var requestBody = new Dictionary<string, UpsertStructuredResultDataRequest>(); // Dictionary<string, UpsertStructuredResultDataRequest> | The set of structured result data items to update or insert keyed by a unique correlation id.

            try
            {
                // [EXPERIMENTAL] Upsert a set of structured result data items. This creates or updates the data in Lusid.
                UpsertStructuredDataResponse result = apiInstance.UpsertStructuredResultData(scope, requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling StructuredResultDataApi.UpsertStructuredResultData: " + e.Message );
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
 **scope** | **string**| The scope to use when updating or inserting the structured result data. | 
 **requestBody** | [**Dictionary&lt;string, UpsertStructuredResultDataRequest&gt;**](UpsertStructuredResultDataRequest.md)| The set of structured result data items to update or insert keyed by a unique correlation id. | 

### Return type

[**UpsertStructuredDataResponse**](UpsertStructuredDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully updated or inserted result data along with any failures |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

