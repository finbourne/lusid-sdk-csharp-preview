# Lusid.Sdk.Api.AggregationApi

All URIs are relative to *https://fbn-prd.lusid.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GenerateConfigurationRecipe**](AggregationApi.md#generateconfigurationrecipe) | **POST** /api/aggregation/{scope}/{code}/$generateconfigurationrecipe | [EXPERIMENTAL] Generates a recipe sufficient to perform valuations for the given portfolio.
[**GetAggregation**](AggregationApi.md#getaggregation) | **POST** /api/aggregation/{scope}/{code}/$aggregate | [EXPERIMENTAL] Aggregate data in a portfolio or portfolio group
[**GetAggregationByResultSet**](AggregationApi.md#getaggregationbyresultset) | **POST** /api/results/{scope}/{resultsKey}/$aggregate | [EXPERIMENTAL] Aggregate using result data
[**GetAggregationOfWeightedInstruments**](AggregationApi.md#getaggregationofweightedinstruments) | **POST** /api/portfolios/{scope}/$aggregateinlined | [EXPERIMENTAL] Aggregate data in an inlined portfolio
[**GetNestedAggregation**](AggregationApi.md#getnestedaggregation) | **POST** /api/aggregation/{scope}/{code}/$aggregatenested | [EXPERIMENTAL] Aggregate data in a portfolio or portfolio group, as nested
[**GetQueryableKeys**](AggregationApi.md#getqueryablekeys) | **GET** /api/results/queryable/keys | [EXPERIMENTAL] Query the set of supported \&quot;addresses\&quot; that can be queried from the aggregation endpoint.



## GenerateConfigurationRecipe

> ConfigurationRecipe GenerateConfigurationRecipe (string scope, string code, CreateRecipeRequest createRecipeRequest = null)

[EXPERIMENTAL] Generates a recipe sufficient to perform valuations for the given portfolio.

Given a set of scopes, a portfolio Id and a basic recipe, this endpoint generates a configuration recipe with relevant rules that can value the instruments in the portfolio.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GenerateConfigurationRecipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the portfolio
            var code = code_example;  // string | The code of the portfolio
            var createRecipeRequest = new CreateRecipeRequest(); // CreateRecipeRequest | The request specifying the parameters to generating the recipe (optional) 

            try
            {
                // [EXPERIMENTAL] Generates a recipe sufficient to perform valuations for the given portfolio.
                ConfigurationRecipe result = apiInstance.GenerateConfigurationRecipe(scope, code, createRecipeRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AggregationApi.GenerateConfigurationRecipe: " + e.Message );
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
 **scope** | **string**| The scope of the portfolio | 
 **code** | **string**| The code of the portfolio | 
 **createRecipeRequest** | [**CreateRecipeRequest**](CreateRecipeRequest.md)| The request specifying the parameters to generating the recipe | [optional] 

### Return type

[**ConfigurationRecipe**](ConfigurationRecipe.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetAggregation

> ListAggregationResponse GetAggregation (string scope, string code, List<string> sortBy = null, int? start = null, int? limit = null, AggregationRequest aggregationRequest = null)

[EXPERIMENTAL] Aggregate data in a portfolio or portfolio group

Aggregate data sourced from the specified portfolio or portfolio group

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetAggregationExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the portfolio or portfolio group
            var code = code_example;  // string | The code of the portfolio or portfolio group
            var sortBy = new List<string>(); // List<string> | Optional. Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName (optional) 
            var start = 56;  // int? | Optional. When paginating, skip this number of results (optional) 
            var limit = 56;  // int? | Optional. When paginating, limit the number of returned results to this many. (optional) 
            var aggregationRequest = new AggregationRequest(); // AggregationRequest | The request specifying the parameters of the aggregation (optional) 

            try
            {
                // [EXPERIMENTAL] Aggregate data in a portfolio or portfolio group
                ListAggregationResponse result = apiInstance.GetAggregation(scope, code, sortBy, start, limit, aggregationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AggregationApi.GetAggregation: " + e.Message );
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
 **scope** | **string**| The scope of the portfolio or portfolio group | 
 **code** | **string**| The code of the portfolio or portfolio group | 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName | [optional] 
 **start** | **int?**| Optional. When paginating, skip this number of results | [optional] 
 **limit** | **int?**| Optional. When paginating, limit the number of returned results to this many. | [optional] 
 **aggregationRequest** | [**AggregationRequest**](AggregationRequest.md)| The request specifying the parameters of the aggregation | [optional] 

### Return type

[**ListAggregationResponse**](ListAggregationResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetAggregationByResultSet

> ListAggregationResponse GetAggregationByResultSet (string scope, string resultsKey, List<string> sortBy = null, int? start = null, int? limit = null, AggregationRequest aggregationRequest = null)

[EXPERIMENTAL] Aggregate using result data

Aggregate data from a previously-run Result data set into a flat row of results

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetAggregationByResultSetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the Result data set
            var resultsKey = resultsKey_example;  // string | The key of the Result data set
            var sortBy = new List<string>(); // List<string> | Optional. Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName (optional) 
            var start = 56;  // int? | Optional. When paginating, skip this number of results (optional) 
            var limit = 56;  // int? | Optional. When paginating, limit the number of returned results to this many. (optional) 
            var aggregationRequest = new AggregationRequest(); // AggregationRequest | The request specifying the parameters of the aggregation (optional) 

            try
            {
                // [EXPERIMENTAL] Aggregate using result data
                ListAggregationResponse result = apiInstance.GetAggregationByResultSet(scope, resultsKey, sortBy, start, limit, aggregationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AggregationApi.GetAggregationByResultSet: " + e.Message );
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
 **scope** | **string**| The scope of the Result data set | 
 **resultsKey** | **string**| The key of the Result data set | 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName | [optional] 
 **start** | **int?**| Optional. When paginating, skip this number of results | [optional] 
 **limit** | **int?**| Optional. When paginating, limit the number of returned results to this many. | [optional] 
 **aggregationRequest** | [**AggregationRequest**](AggregationRequest.md)| The request specifying the parameters of the aggregation | [optional] 

### Return type

[**ListAggregationResponse**](ListAggregationResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetAggregationOfWeightedInstruments

> ListAggregationResponse GetAggregationOfWeightedInstruments (string scope, List<string> sortBy = null, int? start = null, int? limit = null, InlineAggregationRequest inlineAggregationRequest = null)

[EXPERIMENTAL] Aggregate data in an inlined portfolio

Aggregate data sourced from the portfolio that is defined by the weighted set of instruments passed to the request.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetAggregationOfWeightedInstrumentsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the instruments should that be required
            var sortBy = new List<string>(); // List<string> | Optional. Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName (optional) 
            var start = 56;  // int? | Optional. When paginating, skip this number of results (optional) 
            var limit = 56;  // int? | Optional. When paginating, limit the number of returned results to this many. (optional) 
            var inlineAggregationRequest = new InlineAggregationRequest(); // InlineAggregationRequest | The request specifying the parameters of the aggregation and the inlined set of instruments to aggregate over. (optional) 

            try
            {
                // [EXPERIMENTAL] Aggregate data in an inlined portfolio
                ListAggregationResponse result = apiInstance.GetAggregationOfWeightedInstruments(scope, sortBy, start, limit, inlineAggregationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AggregationApi.GetAggregationOfWeightedInstruments: " + e.Message );
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
 **scope** | **string**| The scope of the instruments should that be required | 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Optional. Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName | [optional] 
 **start** | **int?**| Optional. When paginating, skip this number of results | [optional] 
 **limit** | **int?**| Optional. When paginating, limit the number of returned results to this many. | [optional] 
 **inlineAggregationRequest** | [**InlineAggregationRequest**](InlineAggregationRequest.md)| The request specifying the parameters of the aggregation and the inlined set of instruments to aggregate over. | [optional] 

### Return type

[**ListAggregationResponse**](ListAggregationResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetNestedAggregation

> NestedAggregationResponse GetNestedAggregation (string scope, string code, AggregationRequest aggregationRequest = null)

[EXPERIMENTAL] Aggregate data in a portfolio or portfolio group, as nested

Aggregate data sourced from the specified portfolio or portfolio group into a nested structure. Data is nested following the group-by specifications.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetNestedAggregationExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the portfolio or portfolio group
            var code = code_example;  // string | The code of the portfolio or portfolio group
            var aggregationRequest = new AggregationRequest(); // AggregationRequest | The request specifying the parameters of the aggregation (optional) 

            try
            {
                // [EXPERIMENTAL] Aggregate data in a portfolio or portfolio group, as nested
                NestedAggregationResponse result = apiInstance.GetNestedAggregation(scope, code, aggregationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AggregationApi.GetNestedAggregation: " + e.Message );
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
 **scope** | **string**| The scope of the portfolio or portfolio group | 
 **code** | **string**| The code of the portfolio or portfolio group | 
 **aggregationRequest** | [**AggregationRequest**](AggregationRequest.md)| The request specifying the parameters of the aggregation | [optional] 

### Return type

[**NestedAggregationResponse**](NestedAggregationResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetQueryableKeys

> ResourceListOfAggregationQuery GetQueryableKeys (string page = null, int? start = null, int? limit = null, string filter = null)

[EXPERIMENTAL] Query the set of supported \"addresses\" that can be queried from the aggregation endpoint.

When a request is made for aggregation, the user needs to know what keys can be passed to it for queryable data. This endpoint allows to queries to provide the set of keys,  what they are and what they return.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetQueryableKeysExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var page = page_example;  // string | The pagination token to use to continue listing queryable keys from a previous call to list queryable keys.              This value is returned from the previous call. (optional) 
            var start = 56;  // int? | When paginating, skip this number of results. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set.              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] Query the set of supported \"addresses\" that can be queried from the aggregation endpoint.
                ResourceListOfAggregationQuery result = apiInstance.GetQueryableKeys(page, start, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AggregationApi.GetQueryableKeys: " + e.Message );
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
 **page** | **string**| The pagination token to use to continue listing queryable keys from a previous call to list queryable keys.              This value is returned from the previous call. | [optional] 
 **start** | **int?**| When paginating, skip this number of results. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 
 **filter** | **string**| Expression to filter the result set.              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**ResourceListOfAggregationQuery**](ResourceListOfAggregationQuery.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

