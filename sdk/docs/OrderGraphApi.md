# Lusid.Sdk.Api.OrderGraphApi

All URIs are relative to *http://local-unit-test-server.lusid.com:37272*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ListOrderGraphBlocks**](OrderGraphApi.md#listordergraphblocks) | **GET** /api/ordergraph/blocks | [EXPERIMENTAL] ListOrderGraphBlocks: Lists blocks that pass the filter provided, and builds a summary picture of the state of their associated order entities.
[**ListOrderGraphPlacements**](OrderGraphApi.md#listordergraphplacements) | **GET** /api/ordergraph/placements | [EXPERIMENTAL] ListOrderGraphPlacements: Lists placements that pass the filter provided, and builds a summary picture of the state of their associated order entities.


<a name="listordergraphblocks"></a>
# **ListOrderGraphBlocks**
> PagedResourceListOfOrderGraphBlock ListOrderGraphBlocks (DateTimeOffset? asAt = null, string paginationToken = null, List<string> sortBy = null, int? limit = null, string filter = null, List<string> propertyKeys = null)

[EXPERIMENTAL] ListOrderGraphBlocks: Lists blocks that pass the filter provided, and builds a summary picture of the state of their associated order entities.

Lists all blocks of orders, subject to the filter, along with the IDs of orders, placements, allocations and  executions in the block, the total quantities of each, and a simple text field describing the overall state.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListOrderGraphBlocksExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:37272";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderGraphApi(config);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | See https://support.lusid.com/knowledgebase/article/KA-01832/ (optional) 
            var paginationToken = paginationToken_example;  // string | See https://support.lusid.com/knowledgebase/article/KA-01915/ (optional) 
            var sortBy = new List<string>(); // List<string> | Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName. (optional) 
            var limit = 56;  // int? | See https://support.lusid.com/knowledgebase/article/KA-01915/ (optional) 
            var filter = filter_example;  // string | See https://support.lusid.com/knowledgebase/article/KA-01914/ (optional)  (default to "")
            var propertyKeys = new List<string>(); // List<string> | Must be block-level properties. See https://support.lusid.com/knowledgebase/article/KA-01855/ (optional) 

            try
            {
                // [EXPERIMENTAL] ListOrderGraphBlocks: Lists blocks that pass the filter provided, and builds a summary picture of the state of their associated order entities.
                PagedResourceListOfOrderGraphBlock result = apiInstance.ListOrderGraphBlocks(asAt, paginationToken, sortBy, limit, filter, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrderGraphApi.ListOrderGraphBlocks: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| See https://support.lusid.com/knowledgebase/article/KA-01832/ | [optional] 
 **paginationToken** | **string**| See https://support.lusid.com/knowledgebase/article/KA-01915/ | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName. | [optional] 
 **limit** | **int?**| See https://support.lusid.com/knowledgebase/article/KA-01915/ | [optional] 
 **filter** | **string**| See https://support.lusid.com/knowledgebase/article/KA-01914/ | [optional] [default to &quot;&quot;]
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| Must be block-level properties. See https://support.lusid.com/knowledgebase/article/KA-01855/ | [optional] 

### Return type

[**PagedResourceListOfOrderGraphBlock**](PagedResourceListOfOrderGraphBlock.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Blocks in scope. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listordergraphplacements"></a>
# **ListOrderGraphPlacements**
> PagedResourceListOfOrderGraphPlacement ListOrderGraphPlacements (DateTimeOffset? asAt = null, string paginationToken = null, List<string> sortBy = null, int? limit = null, string filter = null, List<string> propertyKeys = null)

[EXPERIMENTAL] ListOrderGraphPlacements: Lists placements that pass the filter provided, and builds a summary picture of the state of their associated order entities.

Lists all order placements, subject to the filter, along with the IDs of the block and order that the  placement is for, each placement's quantity, the IDs of all allocations and executions in the placement  and the total quantities of those, and a simple text field describing the overall state of the placement.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListOrderGraphPlacementsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:37272";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderGraphApi(config);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | See https://support.lusid.com/knowledgebase/article/KA-01832/ (optional) 
            var paginationToken = paginationToken_example;  // string | See https://support.lusid.com/knowledgebase/article/KA-01915/ (optional) 
            var sortBy = new List<string>(); // List<string> | Order the results by these fields. Use use the '-' sign to denote descending order e.g. -MyFieldName. (optional) 
            var limit = 56;  // int? | See https://support.lusid.com/knowledgebase/article/KA-01915/ (optional) 
            var filter = filter_example;  // string | See https://support.lusid.com/knowledgebase/article/KA-01914/ (optional)  (default to "")
            var propertyKeys = new List<string>(); // List<string> | Must be placement properties. See https://support.lusid.com/knowledgebase/article/KA-01855/ (optional) 

            try
            {
                // [EXPERIMENTAL] ListOrderGraphPlacements: Lists placements that pass the filter provided, and builds a summary picture of the state of their associated order entities.
                PagedResourceListOfOrderGraphPlacement result = apiInstance.ListOrderGraphPlacements(asAt, paginationToken, sortBy, limit, filter, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrderGraphApi.ListOrderGraphPlacements: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| See https://support.lusid.com/knowledgebase/article/KA-01832/ | [optional] 
 **paginationToken** | **string**| See https://support.lusid.com/knowledgebase/article/KA-01915/ | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| Order the results by these fields. Use use the &#39;-&#39; sign to denote descending order e.g. -MyFieldName. | [optional] 
 **limit** | **int?**| See https://support.lusid.com/knowledgebase/article/KA-01915/ | [optional] 
 **filter** | **string**| See https://support.lusid.com/knowledgebase/article/KA-01914/ | [optional] [default to &quot;&quot;]
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| Must be placement properties. See https://support.lusid.com/knowledgebase/article/KA-01855/ | [optional] 

### Return type

[**PagedResourceListOfOrderGraphPlacement**](PagedResourceListOfOrderGraphPlacement.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Placements in scope. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

