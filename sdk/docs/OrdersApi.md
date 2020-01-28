# Lusid.Sdk.Api.OrdersApi

All URIs are relative to *http://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetOrder**](OrdersApi.md#getorder) | **GET** /api/orders/{scope}/{id} | [EXPERIMENTAL] Fetch a given order.
[**ListOrders**](OrdersApi.md#listorders) | **GET** /api/orders/{scope} | [EXPERIMENTAL] Fetch the last pre-AsAt date version of each order in scope (does not fetch the entire history).
[**UpsertOrderProperties**](OrdersApi.md#upsertorderproperties) | **POST** /api/orders/{scope}/properties | [EXPERIMENTAL] Upsert; update properties on existing Orders with given ids.
[**UpsertOrders**](OrdersApi.md#upsertorders) | **POST** /api/orders/{scope} | [EXPERIMENTAL] Upsert; update existing orders with given ids, or create new orders otherwise.



## GetOrder

> Order GetOrder (string scope, string id, DateTimeOffset? asAt = null, List<string> propertyKeys = null)

[EXPERIMENTAL] Fetch a given order.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetOrderExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrdersApi(Configuration.Default);
            var scope = scope_example;  // string | The scope to which the order belongs.
            var id = id_example;  // string | The order's unique identifier.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asat datetime at which to retrieve the order. Defaults to              return the latest version of each order if not specified. (optional) 
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the \"Orders\" domain to decorate onto the order.              These take the format {domain}/{scope}/{code} e.g. \"Orders/system/Name\". (optional) 

            try
            {
                // [EXPERIMENTAL] Fetch a given order.
                Order result = apiInstance.GetOrder(scope, id, asAt, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrdersApi.GetOrder: " + e.Message );
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
 **scope** | **string**| The scope to which the order belongs. | 
 **id** | **string**| The order&#39;s unique identifier. | 
 **asAt** | **DateTimeOffset?**| The asat datetime at which to retrieve the order. Defaults to              return the latest version of each order if not specified. | [optional] 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the \&quot;Orders\&quot; domain to decorate onto the order.              These take the format {domain}/{scope}/{code} e.g. \&quot;Orders/system/Name\&quot;. | [optional] 

### Return type

[**Order**](Order.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The order matching the given identifier. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListOrders

> ResourceListOfOrder ListOrders (string scope, DateTimeOffset? asAt = null, List<string> propertyKeys = null)

[EXPERIMENTAL] Fetch the last pre-AsAt date version of each order in scope (does not fetch the entire history).

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListOrdersExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrdersApi(Configuration.Default);
            var scope = scope_example;  // string | The scope to which the orders belong.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asat datetime at which to retrieve the orders. Defaults to              return the latest version of each order if not specified. (optional) 
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the \"Orders\" domain to decorate onto each order.              These take the format {domain}/{scope}/{code} e.g. \"Orders/system/Name\". (optional) 

            try
            {
                // [EXPERIMENTAL] Fetch the last pre-AsAt date version of each order in scope (does not fetch the entire history).
                ResourceListOfOrder result = apiInstance.ListOrders(scope, asAt, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrdersApi.ListOrders: " + e.Message );
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
 **scope** | **string**| The scope to which the orders belong. | 
 **asAt** | **DateTimeOffset?**| The asat datetime at which to retrieve the orders. Defaults to              return the latest version of each order if not specified. | [optional] 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the \&quot;Orders\&quot; domain to decorate onto each order.              These take the format {domain}/{scope}/{code} e.g. \&quot;Orders/system/Name\&quot;. | [optional] 

### Return type

[**ResourceListOfOrder**](ResourceListOfOrder.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Orders in scope. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertOrderProperties

> UpsertOrderPropertiesResponse UpsertOrderProperties (string scope, List<UpsertOrderPropertiesRequest> request = null)

[EXPERIMENTAL] Upsert; update properties on existing Orders with given ids.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertOrderPropertiesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrdersApi(Configuration.Default);
            var scope = scope_example;  // string | The scope to which the orders belong.
            var request = new List<UpsertOrderPropertiesRequest>(); // List<UpsertOrderPropertiesRequest> | A collection of order property upsert requests. (optional) 

            try
            {
                // [EXPERIMENTAL] Upsert; update properties on existing Orders with given ids.
                UpsertOrderPropertiesResponse result = apiInstance.UpsertOrderProperties(scope, request);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrdersApi.UpsertOrderProperties: " + e.Message );
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
 **scope** | **string**| The scope to which the orders belong. | 
 **request** | [**List&lt;UpsertOrderPropertiesRequest&gt;**](UpsertOrderPropertiesRequest.md)| A collection of order property upsert requests. | [optional] 

### Return type

[**UpsertOrderPropertiesResponse**](UpsertOrderPropertiesResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | An upsert order properties response. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertOrders

> OrderSet UpsertOrders (string scope, OrderSetRequest request = null)

[EXPERIMENTAL] Upsert; update existing orders with given ids, or create new orders otherwise.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertOrdersExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrdersApi(Configuration.Default);
            var scope = scope_example;  // string | The scope to which the orders belong.
            var request = new OrderSetRequest(); // OrderSetRequest | The collection of order requests. (optional) 

            try
            {
                // [EXPERIMENTAL] Upsert; update existing orders with given ids, or create new orders otherwise.
                OrderSet result = apiInstance.UpsertOrders(scope, request);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling OrdersApi.UpsertOrders: " + e.Message );
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
 **scope** | **string**| The scope to which the orders belong. | 
 **request** | [**OrderSetRequest**](OrderSetRequest.md)| The collection of order requests. | [optional] 

### Return type

[**OrderSet**](OrderSet.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | A collection of successful and unsuccessful orders. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

