# Lusid.Sdk.Api.SearchApi

All URIs are relative to *http://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**InstrumentsSearch**](SearchApi.md#instrumentssearch) | **POST** /api/search/instruments | [EXPERIMENTAL] Instruments search
[**PortfolioGroupsSearch**](SearchApi.md#portfoliogroupssearch) | **POST** /api/search/portfoliogroups | [EXPERIMENTAL] Portfolio groups search
[**PortfoliosSearch**](SearchApi.md#portfoliossearch) | **POST** /api/search/portfolios | [EXPERIMENTAL] [DEPRECATED] Portfolios search
[**PropertiesSearch**](SearchApi.md#propertiessearch) | **POST** /api/search/propertydefinitions | [EXPERIMENTAL] [DEPRECATED] Search property definitions
[**SearchPortfolios**](SearchApi.md#searchportfolios) | **GET** /api/search/portfolios | [EXPERIMENTAL] Search Portfolios
[**SearchProperties**](SearchApi.md#searchproperties) | **GET** /api/search/propertydefinitions | [EXPERIMENTAL] Search Property Definitions



## InstrumentsSearch

> ICollection&lt;InstrumentMatch&gt; InstrumentsSearch (List<InstrumentSearchProperty> symbols, DateTimeOrCutLabel masteredEffectiveAt = null, bool? masteredOnly = null)

[EXPERIMENTAL] Instruments search

Search across all instruments that have been mastered in LUSID. Optionally augment the results with instruments from an external symbology service,  currently OpenFIGI.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class InstrumentsSearchExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(Configuration.Default);
            var symbols = new List<InstrumentSearchProperty>(); // List<InstrumentSearchProperty> | A collection of instrument properties to search for. LUSID will return instruments for any matched              properties.
            var masteredEffectiveAt = masteredEffectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label to use when searching mastered instruments. This parameter has no effect on instruments that  have not been mastered within LUSID. Defaults to the current LUSID system datetime if not specified. (optional) 
            var masteredOnly = true;  // bool? | If set to true, only search over instruments that have been mastered within LUSID. Defaults to false. (optional)  (default to false)

            try
            {
                // [EXPERIMENTAL] Instruments search
                ICollection<InstrumentMatch> result = apiInstance.InstrumentsSearch(symbols, masteredEffectiveAt, masteredOnly);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SearchApi.InstrumentsSearch: " + e.Message );
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
 **symbols** | [**List&lt;InstrumentSearchProperty&gt;**](InstrumentSearchProperty.md)| A collection of instrument properties to search for. LUSID will return instruments for any matched              properties. | 
 **masteredEffectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label to use when searching mastered instruments. This parameter has no effect on instruments that  have not been mastered within LUSID. Defaults to the current LUSID system datetime if not specified. | [optional] 
 **masteredOnly** | **bool?**| If set to true, only search over instruments that have been mastered within LUSID. Defaults to false. | [optional] [default to false]

### Return type

[**ICollection&lt;InstrumentMatch&gt;**](InstrumentMatch.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The instruments found by the search |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## PortfolioGroupsSearch

> ResourceListOfPortfolioGroup PortfolioGroupsSearch (Object request, string filter = null)

[EXPERIMENTAL] Portfolio groups search

Search across all portfolio groups across all scopes.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class PortfolioGroupsSearchExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(Configuration.Default);
            var request = ;  // Object | The search query to use. Read more about search queries in LUSID here https://support.lusid.com/constructing-a-search-request.
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] Portfolio groups search
                ResourceListOfPortfolioGroup result = apiInstance.PortfolioGroupsSearch(request, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SearchApi.PortfolioGroupsSearch: " + e.Message );
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
 **request** | **Object**| The search query to use. Read more about search queries in LUSID here https://support.lusid.com/constructing-a-search-request. | 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**ResourceListOfPortfolioGroup**](ResourceListOfPortfolioGroup.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The portfolio groups found by the search |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## PortfoliosSearch

> ResourceListOfPortfolioSearchResult PortfoliosSearch (Object request, string filter = null)

[EXPERIMENTAL] [DEPRECATED] Portfolios search

Search across all portfolios across all scopes.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class PortfoliosSearchExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(Configuration.Default);
            var request = ;  // Object | The search query to use. Read more about search queries in LUSID here https://support.lusid.com/constructing-a-search-request.
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] [DEPRECATED] Portfolios search
                ResourceListOfPortfolioSearchResult result = apiInstance.PortfoliosSearch(request, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SearchApi.PortfoliosSearch: " + e.Message );
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
 **request** | **Object**| The search query to use. Read more about search queries in LUSID here https://support.lusid.com/constructing-a-search-request. | 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**ResourceListOfPortfolioSearchResult**](ResourceListOfPortfolioSearchResult.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The portfolios found by the search |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## PropertiesSearch

> ResourceListOfPropertyDefinition PropertiesSearch (Object request, string filter = null)

[EXPERIMENTAL] [DEPRECATED] Search property definitions

Search across all user defined property definitions across all scopes.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class PropertiesSearchExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(Configuration.Default);
            var request = ;  // Object | The search query to use. Read more about search queries in LUSID here https://support.lusid.com/constructing-a-search-request.
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] [DEPRECATED] Search property definitions
                ResourceListOfPropertyDefinition result = apiInstance.PropertiesSearch(request, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SearchApi.PropertiesSearch: " + e.Message );
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
 **request** | **Object**| The search query to use. Read more about search queries in LUSID here https://support.lusid.com/constructing-a-search-request. | 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**ResourceListOfPropertyDefinition**](ResourceListOfPropertyDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The property definitions found by the search |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## SearchPortfolios

> PagedResourceListOfPortfolioSearchResult SearchPortfolios (string search = null, string filter = null, string sortBy = null, int? limit = null, string page = null)

[EXPERIMENTAL] Search Portfolios

Search through all portfolios

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class SearchPortfoliosExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(Configuration.Default);
            var search = search_example;  // string | A parameter used for searching any portfolio field. Wildcards(*) are supported at the end of words (e.g. 'Port*'). See <see href=\"https://support.lusid.com/filtering-results-from-lusid\"> filtering results from LUSID </see> for more details. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about <see href=\"https://support.lusid.com/filtering-results-from-lusid\"> filtering results from LUSID</see>. (optional) 
            var sortBy = sortBy_example;  // string | Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName. Multiple fields can be denoted by a comma e.g. -MyFieldName,AnotherFieldName,-AFurtherFieldName (optional) 
            var limit = 56;  // int? | When paginating, only return this number of records (optional) 
            var page = page_example;  // string | Encoded page string returned from a previous search result that will retrieve the next page of data. When this field is supplied, filter, sortby and search fields should not be supplied. (optional) 

            try
            {
                // [EXPERIMENTAL] Search Portfolios
                PagedResourceListOfPortfolioSearchResult result = apiInstance.SearchPortfolios(search, filter, sortBy, limit, page);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SearchApi.SearchPortfolios: " + e.Message );
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
 **search** | **string**| A parameter used for searching any portfolio field. Wildcards(*) are supported at the end of words (e.g. &#39;Port*&#39;). See &lt;see href&#x3D;\&quot;https://support.lusid.com/filtering-results-from-lusid\&quot;&gt; filtering results from LUSID &lt;/see&gt; for more details. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about &lt;see href&#x3D;\&quot;https://support.lusid.com/filtering-results-from-lusid\&quot;&gt; filtering results from LUSID&lt;/see&gt;. | [optional] 
 **sortBy** | **string**| Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName. Multiple fields can be denoted by a comma e.g. -MyFieldName,AnotherFieldName,-AFurtherFieldName | [optional] 
 **limit** | **int?**| When paginating, only return this number of records | [optional] 
 **page** | **string**| Encoded page string returned from a previous search result that will retrieve the next page of data. When this field is supplied, filter, sortby and search fields should not be supplied. | [optional] 

### Return type

[**PagedResourceListOfPortfolioSearchResult**](PagedResourceListOfPortfolioSearchResult.md)

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


## SearchProperties

> PagedResourceListOfPropertyDefinition SearchProperties (string search = null, string filter = null, string sortBy = null, int? limit = null, string page = null)

[EXPERIMENTAL] Search Property Definitions

Search through all Property Definitions

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class SearchPropertiesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(Configuration.Default);
            var search = search_example;  // string | A parameter used for searching any field. Wildcards(*) are supported at the end of words (e.g. 'Port*'). See <see href=\"https://support.lusid.com/filtering-results-from-lusid\"> filtering results from LUSID </see> for more details. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about <see href=\"https://support.lusid.com/filtering-results-from-lusid\"> filtering results from LUSID</see>. (optional) 
            var sortBy = sortBy_example;  // string | Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName. Multiple fields can be denoted by a comma e.g. -MyFieldName,AnotherFieldName,-AFurtherFieldName (optional) 
            var limit = 56;  // int? | When paginating, only return this number of records (optional) 
            var page = page_example;  // string | Encoded page string returned from a previous search result that will retrieve the next page of data. When this field is supplied, filter, sortby and search fields should not be supplied. (optional) 

            try
            {
                // [EXPERIMENTAL] Search Property Definitions
                PagedResourceListOfPropertyDefinition result = apiInstance.SearchProperties(search, filter, sortBy, limit, page);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SearchApi.SearchProperties: " + e.Message );
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
 **search** | **string**| A parameter used for searching any field. Wildcards(*) are supported at the end of words (e.g. &#39;Port*&#39;). See &lt;see href&#x3D;\&quot;https://support.lusid.com/filtering-results-from-lusid\&quot;&gt; filtering results from LUSID &lt;/see&gt; for more details. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about &lt;see href&#x3D;\&quot;https://support.lusid.com/filtering-results-from-lusid\&quot;&gt; filtering results from LUSID&lt;/see&gt;. | [optional] 
 **sortBy** | **string**| Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName. Multiple fields can be denoted by a comma e.g. -MyFieldName,AnotherFieldName,-AFurtherFieldName | [optional] 
 **limit** | **int?**| When paginating, only return this number of records | [optional] 
 **page** | **string**| Encoded page string returned from a previous search result that will retrieve the next page of data. When this field is supplied, filter, sortby and search fields should not be supplied. | [optional] 

### Return type

[**PagedResourceListOfPropertyDefinition**](PagedResourceListOfPropertyDefinition.md)

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

