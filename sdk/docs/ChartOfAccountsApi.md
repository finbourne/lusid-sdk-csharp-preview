# Lusid.Sdk.Api.ChartOfAccountsApi

All URIs are relative to *https://www.lusid.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateChartOfAccounts**](ChartOfAccountsApi.md#createchartofaccounts) | **POST** /api/chartofaccounts/{scope} | [EXPERIMENTAL] CreateChartOfAccounts: Create a Chart of Accounts
[**DeleteAccounts**](ChartOfAccountsApi.md#deleteaccounts) | **POST** /api/chartofaccounts/{scope}/{code}/accounts/$delete | [EXPERIMENTAL] DeleteAccounts: Soft or hard delete multiple accounts
[**DeleteChartOfAccounts**](ChartOfAccountsApi.md#deletechartofaccounts) | **DELETE** /api/chartofaccounts/{scope}/{code} | [EXPERIMENTAL] DeleteChartOfAccounts: Delete a Chart of Accounts
[**GetAccount**](ChartOfAccountsApi.md#getaccount) | **GET** /api/chartofaccounts/{scope}/{code}/accounts/{accountCode} | [EXPERIMENTAL] GetAccount: Get Account
[**GetChartOfAccounts**](ChartOfAccountsApi.md#getchartofaccounts) | **GET** /api/chartofaccounts/{scope}/{code} | [EXPERIMENTAL] GetChartOfAccounts: Get ChartOfAccounts
[**ListAccounts**](ChartOfAccountsApi.md#listaccounts) | **GET** /api/chartofaccounts/{scope}/{code}/accounts | [EXPERIMENTAL] ListAccounts: List Accounts
[**ListChartsOfAccounts**](ChartOfAccountsApi.md#listchartsofaccounts) | **GET** /api/chartofaccounts | [EXPERIMENTAL] ListChartsOfAccounts: List charts of accounts
[**UpsertAccounts**](ChartOfAccountsApi.md#upsertaccounts) | **POST** /api/chartofaccounts/{scope}/{code}/accounts | [EXPERIMENTAL] UpsertAccounts: Upsert Accounts
[**UpsertAccountsProperties**](ChartOfAccountsApi.md#upsertaccountsproperties) | **POST** /api/chartofaccounts/{scope}/{code}/accounts/{accountCode}/properties/$upsert | [EXPERIMENTAL] UpsertAccountsProperties: Upsert accounts properties
[**UpsertChartOfAccountsProperties**](ChartOfAccountsApi.md#upsertchartofaccountsproperties) | **POST** /api/chartofaccounts/{scope}/{code}/properties/$upsert | [EXPERIMENTAL] UpsertChartOfAccountsProperties: Upsert chart of accounts properties


<a name="createchartofaccounts"></a>
# **CreateChartOfAccounts**
> ChartOfAccounts CreateChartOfAccounts (string scope, ChartOfAccountsRequest chartOfAccountsRequest)

[EXPERIMENTAL] CreateChartOfAccounts: Create a Chart of Accounts

Create the given chart of accounts.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateChartOfAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the Chart of Accounts.
            var chartOfAccountsRequest = new ChartOfAccountsRequest(); // ChartOfAccountsRequest | The definition of the Chart of Accounts.

            try
            {
                // [EXPERIMENTAL] CreateChartOfAccounts: Create a Chart of Accounts
                ChartOfAccounts result = apiInstance.CreateChartOfAccounts(scope, chartOfAccountsRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.CreateChartOfAccounts: " + e.Message );
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
 **scope** | **string**| The scope of the Chart of Accounts. | 
 **chartOfAccountsRequest** | [**ChartOfAccountsRequest**](ChartOfAccountsRequest.md)| The definition of the Chart of Accounts. | 

### Return type

[**ChartOfAccounts**](ChartOfAccounts.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The newly created char of accounts. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteaccounts"></a>
# **DeleteAccounts**
> DeleteAccountsResponse DeleteAccounts (string scope, string code, List<string> requestBody, string deleteMode = null)

[EXPERIMENTAL] DeleteAccounts: Soft or hard delete multiple accounts

Delete one or more account from the chart of accounts. Soft deletion marks the account as inactive  While the Hard deletion is deleting the account.  The maximum number of accounts that this method can delete per request is 2,000.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the chart of accounts.
            var code = code_example;  // string | The code of the chart of accounts. Together with the scope this uniquely identifies              the Chart of Accounts.
            var requestBody = new List<string>(); // List<string> | The codes of the accounts to delete.
            var deleteMode = deleteMode_example;  // string | The delete mode to use (defaults to 'Soft'). (optional) 

            try
            {
                // [EXPERIMENTAL] DeleteAccounts: Soft or hard delete multiple accounts
                DeleteAccountsResponse result = apiInstance.DeleteAccounts(scope, code, requestBody, deleteMode);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.DeleteAccounts: " + e.Message );
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
 **scope** | **string**| The scope of the chart of accounts. | 
 **code** | **string**| The code of the chart of accounts. Together with the scope this uniquely identifies              the Chart of Accounts. | 
 **requestBody** | [**List&lt;string&gt;**](string.md)| The codes of the accounts to delete. | 
 **deleteMode** | **string**| The delete mode to use (defaults to &#39;Soft&#39;). | [optional] 

### Return type

[**DeleteAccountsResponse**](DeleteAccountsResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The datetime that the accounts were deleted. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletechartofaccounts"></a>
# **DeleteChartOfAccounts**
> DeletedEntityResponse DeleteChartOfAccounts (string scope, string code)

[EXPERIMENTAL] DeleteChartOfAccounts: Delete a Chart of Accounts

Delete the given chart of accounts.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteChartOfAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the Chart of Accounts to be deleted.
            var code = code_example;  // string | The code of the Chart of Accounts to be deleted.Together with the scope this uniquely identifies the chart of accounts.

            try
            {
                // [EXPERIMENTAL] DeleteChartOfAccounts: Delete a Chart of Accounts
                DeletedEntityResponse result = apiInstance.DeleteChartOfAccounts(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.DeleteChartOfAccounts: " + e.Message );
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
 **scope** | **string**| The scope of the Chart of Accounts to be deleted. | 
 **code** | **string**| The code of the Chart of Accounts to be deleted.Together with the scope this uniquely identifies the chart of accounts. | 

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
| **200** | The datetime that the chart of accounts was deleted |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getaccount"></a>
# **GetAccount**
> Account GetAccount (string scope, string code, string accountCode, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, List<string> propertyKeys = null)

[EXPERIMENTAL] GetAccount: Get Account

Retrieve the definition of a particular Account which is part of a Chart of Accounts.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetAccountExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the ChartOfAccounts.
            var code = code_example;  // string | The code of the ChartOfAccounts. Together with the scope this uniquely identifies the ChartOfAccounts.
            var accountCode = accountCode_example;  // string | The code of the Account.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the Account properties. Defaults to the current LUSID system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the Account definition. Defaults to returning the latest version of the Account definition if not specified. (optional) 
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the 'Account' domain to decorate onto the Account.              These must take the format {domain}/{scope}/{code}, for example 'Account/Manager/Id'. If not provided will return all the entitled properties for that Account. (optional) 

            try
            {
                // [EXPERIMENTAL] GetAccount: Get Account
                Account result = apiInstance.GetAccount(scope, code, accountCode, effectiveAt, asAt, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.GetAccount: " + e.Message );
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
 **scope** | **string**| The scope of the ChartOfAccounts. | 
 **code** | **string**| The code of the ChartOfAccounts. Together with the scope this uniquely identifies the ChartOfAccounts. | 
 **accountCode** | **string**| The code of the Account. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to retrieve the Account properties. Defaults to the current LUSID system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the Account definition. Defaults to returning the latest version of the Account definition if not specified. | [optional] 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the &#39;Account&#39; domain to decorate onto the Account.              These must take the format {domain}/{scope}/{code}, for example &#39;Account/Manager/Id&#39;. If not provided will return all the entitled properties for that Account. | [optional] 

### Return type

[**Account**](Account.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested Account definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getchartofaccounts"></a>
# **GetChartOfAccounts**
> ChartOfAccounts GetChartOfAccounts (string scope, string code, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, List<string> propertyKeys = null)

[EXPERIMENTAL] GetChartOfAccounts: Get ChartOfAccounts

Retrieve the definition of a particular ChartOfAccounts.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetChartOfAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the ChartOfAccounts.
            var code = code_example;  // string | The code of the ChartOfAccounts. Together with the scope this uniquely identifies the ChartOfAccounts.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the ChartOfAccounts properties. Defaults to the current LUSID system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the ChartOfAccounts definition. Defaults to returning the latest version of the ChartOfAccounts definition if not specified. (optional) 
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the 'ChartOfAccounts' domain to decorate onto the ChartOfAccounts.              These must take the format {domain}/{scope}/{code}, for example 'ChartOfAccounts/Manager/Id'. If not provided will return all the entitled properties for that ChartOfAccounts. (optional) 

            try
            {
                // [EXPERIMENTAL] GetChartOfAccounts: Get ChartOfAccounts
                ChartOfAccounts result = apiInstance.GetChartOfAccounts(scope, code, effectiveAt, asAt, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.GetChartOfAccounts: " + e.Message );
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
 **scope** | **string**| The scope of the ChartOfAccounts. | 
 **code** | **string**| The code of the ChartOfAccounts. Together with the scope this uniquely identifies the ChartOfAccounts. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to retrieve the ChartOfAccounts properties. Defaults to the current LUSID system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the ChartOfAccounts definition. Defaults to returning the latest version of the ChartOfAccounts definition if not specified. | [optional] 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the &#39;ChartOfAccounts&#39; domain to decorate onto the ChartOfAccounts.              These must take the format {domain}/{scope}/{code}, for example &#39;ChartOfAccounts/Manager/Id&#39;. If not provided will return all the entitled properties for that ChartOfAccounts. | [optional] 

### Return type

[**ChartOfAccounts**](ChartOfAccounts.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested ChartOfAccounts definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listaccounts"></a>
# **ListAccounts**
> PagedResourceListOfAccount ListAccounts (string scope, string code, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, string page = null, int? start = null, int? limit = null, string filter = null, List<string> propertyKeys = null)

[EXPERIMENTAL] ListAccounts: List Accounts

List the accounts in a chart of accounts

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the chart of account.
            var code = code_example;  // string | The code of the chart of account. Together with the scope this uniquely identifies              the chart of accounts.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to list the TimeVariant properties decorated on Accounts. Defaults to the current LUSID              system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the instrument. Defaults to              returning the latest version if not specified. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing charts of accounts; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var start = 56;  // int? | When paginating, skip this number of results. (optional) 
            var limit = 56;  // int? | When paginating, limit the results to this number. Defaults to 100 if not specified. (optional) 
            var filter = filter_example;  // string | Expression to filter the results.              For example, to filter on the Account type, specify \"code eq '001'\". For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional) 
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the 'Account' domain to decorate onto the Account.              These must have the format {domain}/{scope}/{code}, for example 'Account/system/Name'. (optional) 

            try
            {
                // [EXPERIMENTAL] ListAccounts: List Accounts
                PagedResourceListOfAccount result = apiInstance.ListAccounts(scope, code, effectiveAt, asAt, page, start, limit, filter, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.ListAccounts: " + e.Message );
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
 **scope** | **string**| The scope of the chart of account. | 
 **code** | **string**| The code of the chart of account. Together with the scope this uniquely identifies              the chart of accounts. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to list the TimeVariant properties decorated on Accounts. Defaults to the current LUSID              system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the instrument. Defaults to              returning the latest version if not specified. | [optional] 
 **page** | **string**| The pagination token to use to continue listing charts of accounts; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **start** | **int?**| When paginating, skip this number of results. | [optional] 
 **limit** | **int?**| When paginating, limit the results to this number. Defaults to 100 if not specified. | [optional] 
 **filter** | **string**| Expression to filter the results.              For example, to filter on the Account type, specify \&quot;code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. | [optional] 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the &#39;Account&#39; domain to decorate onto the Account.              These must have the format {domain}/{scope}/{code}, for example &#39;Account/system/Name&#39;. | [optional] 

### Return type

[**PagedResourceListOfAccount**](PagedResourceListOfAccount.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The accounts in the give chart of accounts. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listchartsofaccounts"></a>
# **ListChartsOfAccounts**
> PagedResourceListOfChartOfAccounts ListChartsOfAccounts (DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, string page = null, int? start = null, int? limit = null, string filter = null, List<string> propertyKeys = null)

[EXPERIMENTAL] ListChartsOfAccounts: List charts of accounts

List all the charts of accounts matching particular criteria.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListChartsOfAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to list the TimeVariant properties for the Chart Of Accounts. Defaults to the current LUSID              system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to list the charts of accounts. Defaults to returning the latest version              of each chart of accounts if not specified. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing charts of accounts; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var start = 56;  // int? | When paginating, skip this number of results. (optional) 
            var limit = 56;  // int? | When paginating, limit the results to this number. Defaults to 100 if not specified. (optional) 
            var filter = filter_example;  // string | Expression to filter the results.              For example, to filter on the ChartOfAccounts type, specify \"id.Code eq '001'\". For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional) 
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the 'ChartOfAccounts' domain to decorate onto each chart of accounts.              These must take the format {domain}/{scope}/{code}, for example 'ChartOfAccounts/Manager/Id'. (optional) 

            try
            {
                // [EXPERIMENTAL] ListChartsOfAccounts: List charts of accounts
                PagedResourceListOfChartOfAccounts result = apiInstance.ListChartsOfAccounts(effectiveAt, asAt, page, start, limit, filter, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.ListChartsOfAccounts: " + e.Message );
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
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to list the TimeVariant properties for the Chart Of Accounts. Defaults to the current LUSID              system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to list the charts of accounts. Defaults to returning the latest version              of each chart of accounts if not specified. | [optional] 
 **page** | **string**| The pagination token to use to continue listing charts of accounts; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **start** | **int?**| When paginating, skip this number of results. | [optional] 
 **limit** | **int?**| When paginating, limit the results to this number. Defaults to 100 if not specified. | [optional] 
 **filter** | **string**| Expression to filter the results.              For example, to filter on the ChartOfAccounts type, specify \&quot;id.Code eq &#39;001&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. | [optional] 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the &#39;ChartOfAccounts&#39; domain to decorate onto each chart of accounts.              These must take the format {domain}/{scope}/{code}, for example &#39;ChartOfAccounts/Manager/Id&#39;. | [optional] 

### Return type

[**PagedResourceListOfChartOfAccounts**](PagedResourceListOfChartOfAccounts.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested charts of accounts |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="upsertaccounts"></a>
# **UpsertAccounts**
> AccountsUpsertResponse UpsertAccounts (string scope, string code, List<Account> account)

[EXPERIMENTAL] UpsertAccounts: Upsert Accounts

Create or update accounts in the chart of accounts. An account will be updated  if it already exists and created if it does not.  The maximum number of accounts that this method can upsert per request is 2,000.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the chart of account.
            var code = code_example;  // string | The code of the chart of account. Together with the scope this uniquely identifies              the chart of accounts.
            var account = new List<Account>(); // List<Account> | A list of accounts to be created or updated.

            try
            {
                // [EXPERIMENTAL] UpsertAccounts: Upsert Accounts
                AccountsUpsertResponse result = apiInstance.UpsertAccounts(scope, code, account);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.UpsertAccounts: " + e.Message );
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
 **scope** | **string**| The scope of the chart of account. | 
 **code** | **string**| The code of the chart of account. Together with the scope this uniquely identifies              the chart of accounts. | 
 **account** | [**List&lt;Account&gt;**](Account.md)| A list of accounts to be created or updated. | 

### Return type

[**AccountsUpsertResponse**](AccountsUpsertResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The newly upserted accounts. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="upsertaccountsproperties"></a>
# **UpsertAccountsProperties**
> AccountProperties UpsertAccountsProperties (string scope, string code, string accountCode, Dictionary<string, Property> requestBody = null)

[EXPERIMENTAL] UpsertAccountsProperties: Upsert accounts properties

Update or insert one or more properties onto a single account. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain 'Account'.                Upserting a property that exists for a chart of accounts, with a null value, will delete the instance of the property for that group.                Properties have an <i>effectiveFrom</i> datetime for which the property is valid, and an <i>effectiveUntil</i>  datetime until which the property is valid. Not supplying an <i>effectiveUntil</i> datetime results in the property being  valid indefinitely, or until the next <i>effectiveFrom</i> datetime of the property.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertAccountsPropertiesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the Chart of Accounts to update or insert the properties onto.
            var code = code_example;  // string | The code of the Chart of Accounts to update or insert the properties onto. Together with the scope this uniquely identifies the chart of accounts.
            var accountCode = accountCode_example;  // string | The unique ID of the account to create or update properties for.
            var requestBody = new Dictionary<string, Property>(); // Dictionary<string, Property> | The properties to be updated or inserted onto the chart of account. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \"Account/Manager/Id\". (optional) 

            try
            {
                // [EXPERIMENTAL] UpsertAccountsProperties: Upsert accounts properties
                AccountProperties result = apiInstance.UpsertAccountsProperties(scope, code, accountCode, requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.UpsertAccountsProperties: " + e.Message );
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
 **scope** | **string**| The scope of the Chart of Accounts to update or insert the properties onto. | 
 **code** | **string**| The code of the Chart of Accounts to update or insert the properties onto. Together with the scope this uniquely identifies the chart of accounts. | 
 **accountCode** | **string**| The unique ID of the account to create or update properties for. | 
 **requestBody** | [**Dictionary&lt;string, Property&gt;**](Property.md)| The properties to be updated or inserted onto the chart of account. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Account/Manager/Id\&quot;. | [optional] 

### Return type

[**AccountProperties**](AccountProperties.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The updated or inserted properties |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="upsertchartofaccountsproperties"></a>
# **UpsertChartOfAccountsProperties**
> ChartOfAccountsProperties UpsertChartOfAccountsProperties (string scope, string code, Dictionary<string, Property> requestBody = null)

[EXPERIMENTAL] UpsertChartOfAccountsProperties: Upsert chart of accounts properties

Update or insert one or more properties onto a single chart of accounts. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain 'ChartOfAccounts'.                Upserting a property that exists for a chart of accounts, with a null value, will delete the instance of the property for that group.                Properties have an <i>effectiveFrom</i> datetime for which the property is valid, and an <i>effectiveUntil</i>  datetime until which the property is valid. Not supplying an <i>effectiveUntil</i> datetime results in the property being  valid indefinitely, or until the next <i>effectiveFrom</i> datetime of the property.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertChartOfAccountsPropertiesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChartOfAccountsApi(config);
            var scope = scope_example;  // string | The scope of the Chart of Accounts to update or insert the properties onto.
            var code = code_example;  // string | The code of the Chart of Accounts to update or insert the properties onto. Together with the scope this uniquely identifies the chart of accounts.
            var requestBody = new Dictionary<string, Property>(); // Dictionary<string, Property> | The properties to be updated or inserted onto the chart of account. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \"ChartOfAccounts/Manager/Id\". (optional) 

            try
            {
                // [EXPERIMENTAL] UpsertChartOfAccountsProperties: Upsert chart of accounts properties
                ChartOfAccountsProperties result = apiInstance.UpsertChartOfAccountsProperties(scope, code, requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartOfAccountsApi.UpsertChartOfAccountsProperties: " + e.Message );
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
 **scope** | **string**| The scope of the Chart of Accounts to update or insert the properties onto. | 
 **code** | **string**| The code of the Chart of Accounts to update or insert the properties onto. Together with the scope this uniquely identifies the chart of accounts. | 
 **requestBody** | [**Dictionary&lt;string, Property&gt;**](Property.md)| The properties to be updated or inserted onto the chart of account. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;ChartOfAccounts/Manager/Id\&quot;. | [optional] 

### Return type

[**ChartOfAccountsProperties**](ChartOfAccountsProperties.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The updated or inserted properties |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

