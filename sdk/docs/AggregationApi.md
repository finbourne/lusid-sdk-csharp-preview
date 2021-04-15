# Lusid.Sdk.Api.AggregationApi

All URIs are relative to *http://local-unit-test-server.lusid.com:50243*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GenerateConfigurationRecipe**](AggregationApi.md#generateconfigurationrecipe) | **POST** /api/aggregation/{scope}/{code}/$generateconfigurationrecipe | [EXPERIMENTAL] Generates a recipe sufficient to perform valuations for the given portfolio.
[**GetAggregationByResultSet**](AggregationApi.md#getaggregationbyresultset) | **POST** /api/results/{scope}/{resultsKey}/$aggregate | [EXPERIMENTAL] Aggregate using result data
[**GetQueryableKeys**](AggregationApi.md#getqueryablekeys) | **GET** /api/results/queryable/keys | [EXPERIMENTAL] Query the set of supported \&quot;addresses\&quot; that can be queried from the aggregation endpoint.
[**GetValuation**](AggregationApi.md#getvaluation) | **POST** /api/aggregation/$valuation | [EXPERIMENTAL] Perform valuation for a list of portfolios and/or portfolio groups
[**GetValuationOfWeightedInstruments**](AggregationApi.md#getvaluationofweightedinstruments) | **POST** /api/aggregation/$valuationinlined | [EXPERIMENTAL] Perform valuation for an inlined portfolio



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
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:50243";
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


## GetAggregationByResultSet

> ListAggregationResponse GetAggregationByResultSet (string scope, string resultsKey, List<string> sortBy = null, int? limit = null, AggregationRequest aggregationRequest = null)

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
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:50243";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the Result data set
            var resultsKey = resultsKey_example;  // string | The key of the Result data set
            var sortBy = new List<string>(); // List<string> | Optional. Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName (optional) 
            var limit = 56;  // int? | Optional. When paginating, limit the number of returned results to this many. (optional) 
            var aggregationRequest = new AggregationRequest(); // AggregationRequest | The request specifying the parameters of the aggregation (optional) 

            try
            {
                // [EXPERIMENTAL] Aggregate using result data
                ListAggregationResponse result = apiInstance.GetAggregationByResultSet(scope, resultsKey, sortBy, limit, aggregationRequest);
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


## GetQueryableKeys

> ResourceListOfAggregationQuery GetQueryableKeys (string page = null, int? limit = null, string filter = null)

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
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:50243";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var page = page_example;  // string | The pagination token to use to continue listing queryable keys from a previous call to list queryable keys.              This value is returned from the previous call. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set.              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] Query the set of supported \"addresses\" that can be queried from the aggregation endpoint.
                ResourceListOfAggregationQuery result = apiInstance.GetQueryableKeys(page, limit, filter);
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


## GetValuation

> ListAggregationResponse GetValuation (ValuationRequest valuationRequest = null)

[EXPERIMENTAL] Perform valuation for a list of portfolios and/or portfolio groups

Perform valuation on specified list of portfolio and/or portfolio groups for a set of dates.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetValuationExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:50243";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var valuationRequest = new ValuationRequest(); // ValuationRequest | The request specifying the set of portfolios and dates on which to calculate a set of valuation metrics (optional) 

            try
            {
                // [EXPERIMENTAL] Perform valuation for a list of portfolios and/or portfolio groups
                ListAggregationResponse result = apiInstance.GetValuation(valuationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AggregationApi.GetValuation: " + e.Message );
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
 **valuationRequest** | [**ValuationRequest**](ValuationRequest.md)| The request specifying the set of portfolios and dates on which to calculate a set of valuation metrics | [optional] 

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


## GetValuationOfWeightedInstruments

> ListAggregationResponse GetValuationOfWeightedInstruments (InlineValuationRequest inlineValuationRequest = null)

[EXPERIMENTAL] Perform valuation for an inlined portfolio

Perform valuation on the portfolio that is defined by the weighted set of instruments passed to the request.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetValuationOfWeightedInstrumentsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:50243";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AggregationApi(Configuration.Default);
            var inlineValuationRequest = new InlineValuationRequest(); // InlineValuationRequest | The request specifying the set of portfolios and dates on which to calculate a set of valuation metrics (optional) 

            try
            {
                // [EXPERIMENTAL] Perform valuation for an inlined portfolio
                ListAggregationResponse result = apiInstance.GetValuationOfWeightedInstruments(inlineValuationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AggregationApi.GetValuationOfWeightedInstruments: " + e.Message );
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
 **inlineValuationRequest** | [**InlineValuationRequest**](InlineValuationRequest.md)| The request specifying the set of portfolios and dates on which to calculate a set of valuation metrics | [optional] 

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

