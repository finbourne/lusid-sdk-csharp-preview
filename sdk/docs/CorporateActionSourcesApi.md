# Lusid.Sdk.Api.CorporateActionSourcesApi

All URIs are relative to *http://local-unit-test-server.lusid.com:31427*

Method | HTTP request | Description
------------- | ------------- | -------------
[**BatchUpsertCorporateActions**](CorporateActionSourcesApi.md#batchupsertcorporateactions) | **POST** /api/corporateactionsources/{scope}/{code}/corporateactions | [BETA] BatchUpsertCorporateActions: Upsert corporate actions
[**CreateCorporateActionSource**](CorporateActionSourcesApi.md#createcorporateactionsource) | **POST** /api/corporateactionsources | [BETA] CreateCorporateActionSource: Create corporate action source
[**DeleteCorporateActionSource**](CorporateActionSourcesApi.md#deletecorporateactionsource) | **DELETE** /api/corporateactionsources/{scope}/{code} | [BETA] DeleteCorporateActionSource: Delete a corporate action source
[**DeleteCorporateActions**](CorporateActionSourcesApi.md#deletecorporateactions) | **DELETE** /api/corporateactionsources/{scope}/{code}/corporateactions | [EXPERIMENTAL] DeleteCorporateActions: Delete corporate actions
[**GetCorporateActions**](CorporateActionSourcesApi.md#getcorporateactions) | **GET** /api/corporateactionsources/{scope}/{code}/corporateactions | [BETA] GetCorporateActions: Get corporate actions
[**ListCorporateActionSources**](CorporateActionSourcesApi.md#listcorporateactionsources) | **GET** /api/corporateactionsources | [BETA] ListCorporateActionSources: List corporate action sources


<a name="batchupsertcorporateactions"></a>
# **BatchUpsertCorporateActions**
> UpsertCorporateActionsResponse BatchUpsertCorporateActions (string scope, string code, List<UpsertCorporateActionRequest> upsertCorporateActionRequest = null)

[BETA] BatchUpsertCorporateActions: Upsert corporate actions

Create or update one or more corporate actions in a particular corporate action source. Failures are identified in the body of the response.                If a corporate action is upserted at exactly the same effective datetime as a transaction for the same instrument, the corporate action takes precedence. Depending on the nature of the corporate action, this may mean it affects the transaction.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class BatchUpsertCorporateActionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:31427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CorporateActionSourcesApi(config);
            var scope = scope_example;  // string | The scope of corporate action source
            var code = code_example;  // string | The code of the corporate action source
            var upsertCorporateActionRequest = new List<UpsertCorporateActionRequest>(); // List<UpsertCorporateActionRequest> | The corporate action definitions (optional) 

            try
            {
                // [BETA] BatchUpsertCorporateActions: Upsert corporate actions
                UpsertCorporateActionsResponse result = apiInstance.BatchUpsertCorporateActions(scope, code, upsertCorporateActionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CorporateActionSourcesApi.BatchUpsertCorporateActions: " + e.Message );
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
 **scope** | **string**| The scope of corporate action source | 
 **code** | **string**| The code of the corporate action source | 
 **upsertCorporateActionRequest** | [**List&lt;UpsertCorporateActionRequest&gt;**](UpsertCorporateActionRequest.md)| The corporate action definitions | [optional] 

### Return type

[**UpsertCorporateActionsResponse**](UpsertCorporateActionsResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The created corporate actions |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createcorporateactionsource"></a>
# **CreateCorporateActionSource**
> CorporateActionSource CreateCorporateActionSource (CreateCorporateActionSourceRequest createCorporateActionSourceRequest)

[BETA] CreateCorporateActionSource: Create corporate action source

Create a corporate action source.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateCorporateActionSourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:31427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CorporateActionSourcesApi(config);
            var createCorporateActionSourceRequest = new CreateCorporateActionSourceRequest(); // CreateCorporateActionSourceRequest | The corporate action source definition

            try
            {
                // [BETA] CreateCorporateActionSource: Create corporate action source
                CorporateActionSource result = apiInstance.CreateCorporateActionSource(createCorporateActionSourceRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CorporateActionSourcesApi.CreateCorporateActionSource: " + e.Message );
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
 **createCorporateActionSourceRequest** | [**CreateCorporateActionSourceRequest**](CreateCorporateActionSourceRequest.md)| The corporate action source definition | 

### Return type

[**CorporateActionSource**](CorporateActionSource.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The created corporate action source |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecorporateactionsource"></a>
# **DeleteCorporateActionSource**
> DeletedEntityResponse DeleteCorporateActionSource (string scope, string code)

[BETA] DeleteCorporateActionSource: Delete a corporate action source

Deletes a single corporate action source

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteCorporateActionSourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:31427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CorporateActionSourcesApi(config);
            var scope = scope_example;  // string | The scope of the corporate action source to be deleted
            var code = code_example;  // string | The code of the corporate action source to be deleted

            try
            {
                // [BETA] DeleteCorporateActionSource: Delete a corporate action source
                DeletedEntityResponse result = apiInstance.DeleteCorporateActionSource(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CorporateActionSourcesApi.DeleteCorporateActionSource: " + e.Message );
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
 **scope** | **string**| The scope of the corporate action source to be deleted | 
 **code** | **string**| The code of the corporate action source to be deleted | 

### Return type

[**DeletedEntityResponse**](DeletedEntityResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Corporate Action Source Deleted |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecorporateactions"></a>
# **DeleteCorporateActions**
> DeletedEntityResponse DeleteCorporateActions (string scope, string code, List<string> corporateActionIds)

[EXPERIMENTAL] DeleteCorporateActions: Delete corporate actions

Delete one or more corporate actions from a particular corporate action source.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteCorporateActionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:31427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CorporateActionSourcesApi(config);
            var scope = scope_example;  // string | The scope of the corporate action source
            var code = code_example;  // string | The code of the corporate action source
            var corporateActionIds = new List<string>(); // List<string> | The IDs of the corporate actions to delete

            try
            {
                // [EXPERIMENTAL] DeleteCorporateActions: Delete corporate actions
                DeletedEntityResponse result = apiInstance.DeleteCorporateActions(scope, code, corporateActionIds);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CorporateActionSourcesApi.DeleteCorporateActions: " + e.Message );
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
 **scope** | **string**| The scope of the corporate action source | 
 **code** | **string**| The code of the corporate action source | 
 **corporateActionIds** | [**List&lt;string&gt;**](string.md)| The IDs of the corporate actions to delete | 

### Return type

[**DeletedEntityResponse**](DeletedEntityResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Corporate Actions Deleted |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcorporateactions"></a>
# **GetCorporateActions**
> ResourceListOfCorporateAction GetCorporateActions (string scope, string code, DateTimeOrCutLabel fromEffectiveAt = null, DateTimeOrCutLabel toEffectiveAt = null, DateTimeOffset? asAt = null, List<string> sortBy = null, int? limit = null, string filter = null)

[BETA] GetCorporateActions: Get corporate actions

Get corporate actions from a particular corporate action source.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetCorporateActionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:31427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CorporateActionSourcesApi(config);
            var scope = scope_example;  // string | The scope of the corporate action source.
            var code = code_example;  // string | The code of the corporate action source.
            var fromEffectiveAt = fromEffectiveAt_example;  // DateTimeOrCutLabel | Optional. The start effective date of the data range. (optional) 
            var toEffectiveAt = toEffectiveAt_example;  // DateTimeOrCutLabel | Optional. The end effective date of the data range. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | Optional. The AsAt date of the data. (optional) 
            var sortBy = new List<string>(); // List<string> | Optional. Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName (optional) 
            var limit = 56;  // int? | Optional. When paginating, limit the results to this number. (optional) 
            var filter = filter_example;  // string | Optional. Expression to filter the result set.              For example, to filter on the Announcement Date, use \"announcementDate eq '2020-03-06'\"              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [BETA] GetCorporateActions: Get corporate actions
                ResourceListOfCorporateAction result = apiInstance.GetCorporateActions(scope, code, fromEffectiveAt, toEffectiveAt, asAt, sortBy, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CorporateActionSourcesApi.GetCorporateActions: " + e.Message );
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
 **scope** | **string**| The scope of the corporate action source. | 
 **code** | **string**| The code of the corporate action source. | 
 **fromEffectiveAt** | **DateTimeOrCutLabel**| Optional. The start effective date of the data range. | [optional] 
 **toEffectiveAt** | **DateTimeOrCutLabel**| Optional. The end effective date of the data range. | [optional] 
 **asAt** | **DateTimeOffset?**| Optional. The AsAt date of the data. | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName | [optional] 
 **limit** | **int?**| Optional. When paginating, limit the results to this number. | [optional] 
 **filter** | **string**| Optional. Expression to filter the result set.              For example, to filter on the Announcement Date, use \&quot;announcementDate eq &#39;2020-03-06&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**ResourceListOfCorporateAction**](ResourceListOfCorporateAction.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Corporate Actions |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listcorporateactionsources"></a>
# **ListCorporateActionSources**
> PagedResourceListOfCorporateActionSource ListCorporateActionSources (DateTimeOffset? asAt = null, List<string> sortBy = null, int? limit = null, string filter = null, string page = null)

[BETA] ListCorporateActionSources: List corporate action sources

Gets a list of all corporate action sources

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListCorporateActionSourcesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:31427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CorporateActionSourcesApi(config);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | Optional. The AsAt date of the data (optional) 
            var sortBy = new List<string>(); // List<string> | Optional. Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName (optional) 
            var limit = 56;  // int? | Optional. When paginating, limit the number of returned results to this many. If not specified, a default  of 100 is used. (optional)  (default to 100)
            var filter = filter_example;  // string | Optional. Expression to filter the result set. For example, to  filter on the Display Name, use \"displayName eq 'string'\"  Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 
            var page = page_example;  // string | Optional. The pagination token to use to continue listing items from a previous call. Page values are  return from list calls, and must be supplied exactly as returned. Additionally, when specifying this  value, the filter, asAt, and limit must not  be modified. (optional) 

            try
            {
                // [BETA] ListCorporateActionSources: List corporate action sources
                PagedResourceListOfCorporateActionSource result = apiInstance.ListCorporateActionSources(asAt, sortBy, limit, filter, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CorporateActionSourcesApi.ListCorporateActionSources: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| Optional. The AsAt date of the data | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName | [optional] 
 **limit** | **int?**| Optional. When paginating, limit the number of returned results to this many. If not specified, a default  of 100 is used. | [optional] [default to 100]
 **filter** | **string**| Optional. Expression to filter the result set. For example, to  filter on the Display Name, use \&quot;displayName eq &#39;string&#39;\&quot;  Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 
 **page** | **string**| Optional. The pagination token to use to continue listing items from a previous call. Page values are  return from list calls, and must be supplied exactly as returned. Additionally, when specifying this  value, the filter, asAt, and limit must not  be modified. | [optional] 

### Return type

[**PagedResourceListOfCorporateActionSource**](PagedResourceListOfCorporateActionSource.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | All Existing Corporate Action Sources |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

