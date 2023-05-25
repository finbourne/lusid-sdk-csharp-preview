# Lusid.Sdk.Api.TransactionConfigurationApi

All URIs are relative to *https://www.lusid.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteSideDefinition**](TransactionConfigurationApi.md#deletesidedefinition) | **DELETE** /api/transactionconfiguration/sides/{side}/$delete | [EXPERIMENTAL] DeleteSideDefinition: Delete the given side definition
[**DeleteTransactionType**](TransactionConfigurationApi.md#deletetransactiontype) | **DELETE** /api/transactionconfiguration/types/{source}/{type} | [EXPERIMENTAL] DeleteTransactionType: Delete a transaction type
[**DeleteTransactionTypeSource**](TransactionConfigurationApi.md#deletetransactiontypesource) | **DELETE** /api/transactionconfiguration/types/{source}/$delete | [EXPERIMENTAL] DeleteTransactionTypeSource: Delete all transaction types for the given source and scope
[**GetSideDefinition**](TransactionConfigurationApi.md#getsidedefinition) | **GET** /api/transactionconfiguration/sides/{side} | [EXPERIMENTAL] GetSideDefinition: Get the side definition for a given side name( or label)
[**GetTransactionType**](TransactionConfigurationApi.md#gettransactiontype) | **GET** /api/transactionconfiguration/types/{source}/{type} | [EXPERIMENTAL] GetTransactionType: Get a single transaction configuration type
[**ListSidesDefinition**](TransactionConfigurationApi.md#listsidesdefinition) | **GET** /api/transactionconfiguration/sides | [EXPERIMENTAL] ListSidesDefinition: List the side definitions
[**ListTransactionTypes**](TransactionConfigurationApi.md#listtransactiontypes) | **GET** /api/transactionconfiguration/types | [EXPERIMENTAL] ListTransactionTypes: List transaction types
[**SetSideDefinition**](TransactionConfigurationApi.md#setsidedefinition) | **PUT** /api/transactionconfiguration/sides/{side} | [EXPERIMENTAL] SetSideDefinition: Set a side definition
[**SetSideDefinitions**](TransactionConfigurationApi.md#setsidedefinitions) | **PUT** /api/transactionconfiguration/sides | [EXPERIMENTAL] SetSideDefinitions: Set the given side definitions
[**SetTransactionType**](TransactionConfigurationApi.md#settransactiontype) | **PUT** /api/transactionconfiguration/types/{source}/{type} | [EXPERIMENTAL] SetTransactionType: Set a specific transaction type
[**SetTransactionTypeSource**](TransactionConfigurationApi.md#settransactiontypesource) | **PUT** /api/transactionconfiguration/types/{source} | [EXPERIMENTAL] SetTransactionTypeSource: Set the transaction types for the given source and scope


<a name="deletesidedefinition"></a>
# **DeleteSideDefinition**
> DeletedEntityResponse DeleteSideDefinition (string side, string scope = null)

[EXPERIMENTAL] DeleteSideDefinition: Delete the given side definition

Delete the side which user specify in the request.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteSideDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var side = side_example;  // string | The label to uniquely identify the side.
            var scope = scope_example;  // string | The scope in which the side exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] DeleteSideDefinition: Delete the given side definition
                DeletedEntityResponse result = apiInstance.DeleteSideDefinition(side, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.DeleteSideDefinition: " + e.Message );
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
 **side** | **string**| The label to uniquely identify the side. | 
 **scope** | **string**| The scope in which the side exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

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
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletetransactiontype"></a>
# **DeleteTransactionType**
> DeletedEntityResponse DeleteTransactionType (string source, string type, string scope = null)

[EXPERIMENTAL] DeleteTransactionType: Delete a transaction type

/// WARNING! Changing existing transaction types has a material impact on how data, new and old,  is processed and aggregated by LUSID, and will affect your whole organisation. Only call this API if you are fully aware of the implications of the change.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteTransactionTypeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var source = source_example;  // string | The source that the type is in
            var type = type_example;  // string | One of the type's aliases
            var scope = scope_example;  // string | The scope in which the transaction types exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] DeleteTransactionType: Delete a transaction type
                DeletedEntityResponse result = apiInstance.DeleteTransactionType(source, type, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.DeleteTransactionType: " + e.Message );
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
 **source** | **string**| The source that the type is in | 
 **type** | **string**| One of the type&#39;s aliases | 
 **scope** | **string**| The scope in which the transaction types exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

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
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletetransactiontypesource"></a>
# **DeleteTransactionTypeSource**
> DeletedEntityResponse DeleteTransactionTypeSource (string source, string scope = null)

[EXPERIMENTAL] DeleteTransactionTypeSource: Delete all transaction types for the given source and scope

Delete all the types for the given source and scope.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteTransactionTypeSourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var source = source_example;  // string | The source to set the transaction types for.
            var scope = scope_example;  // string | The scope in which the transaction types exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] DeleteTransactionTypeSource: Delete all transaction types for the given source and scope
                DeletedEntityResponse result = apiInstance.DeleteTransactionTypeSource(source, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.DeleteTransactionTypeSource: " + e.Message );
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
 **source** | **string**| The source to set the transaction types for. | 
 **scope** | **string**| The scope in which the transaction types exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

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
| **200** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsidedefinition"></a>
# **GetSideDefinition**
> SideDefinition GetSideDefinition (string side, string scope = null, DateTimeOffset? asAt = null)

[EXPERIMENTAL] GetSideDefinition: Get the side definition for a given side name( or label)

Get the side definition user requested.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetSideDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var side = side_example;  // string | The label to uniquely identify the side.
            var scope = scope_example;  // string | The scope in which the side exists. When not supplied the scope is 'default'. (optional)  (default to "default")
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the transaction types. Defaults to returning the latest versions if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] GetSideDefinition: Get the side definition for a given side name( or label)
                SideDefinition result = apiInstance.GetSideDefinition(side, scope, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.GetSideDefinition: " + e.Message );
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
 **side** | **string**| The label to uniquely identify the side. | 
 **scope** | **string**| The scope in which the side exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the transaction types. Defaults to returning the latest versions if not specified. | [optional] 

### Return type

[**SideDefinition**](SideDefinition.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettransactiontype"></a>
# **GetTransactionType**
> TransactionType GetTransactionType (string source, string type, DateTimeOffset? asAt = null, string scope = null)

[EXPERIMENTAL] GetTransactionType: Get a single transaction configuration type

Get a single transaction type. Returns failure if not found

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetTransactionTypeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var source = source_example;  // string | The source that the type is in
            var type = type_example;  // string | One of the type's aliases
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the transaction configuration.              Defaults to returning the latest version of the transaction configuration type if not specified (optional) 
            var scope = scope_example;  // string | The scope in which the transaction types exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] GetTransactionType: Get a single transaction configuration type
                TransactionType result = apiInstance.GetTransactionType(source, type, asAt, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.GetTransactionType: " + e.Message );
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
 **source** | **string**| The source that the type is in | 
 **type** | **string**| One of the type&#39;s aliases | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the transaction configuration.              Defaults to returning the latest version of the transaction configuration type if not specified | [optional] 
 **scope** | **string**| The scope in which the transaction types exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

### Return type

[**TransactionType**](TransactionType.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listsidesdefinition"></a>
# **ListSidesDefinition**
> ResourceListOfSideDefinition ListSidesDefinition (DateTimeOffset? asAt = null, string scope = null)

[EXPERIMENTAL] ListSidesDefinition: List the side definitions

List all the side definitions in the given scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListSidesDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the transaction types. Defaults to returning the latest versions if not specified. (optional) 
            var scope = scope_example;  // string | The scope in which the side exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] ListSidesDefinition: List the side definitions
                ResourceListOfSideDefinition result = apiInstance.ListSidesDefinition(asAt, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.ListSidesDefinition: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the transaction types. Defaults to returning the latest versions if not specified. | [optional] 
 **scope** | **string**| The scope in which the side exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

### Return type

[**ResourceListOfSideDefinition**](ResourceListOfSideDefinition.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listtransactiontypes"></a>
# **ListTransactionTypes**
> Dictionary&lt;string, List&lt;TransactionType&gt;&gt; ListTransactionTypes (DateTimeOffset? asAt = null, string scope = null)

[EXPERIMENTAL] ListTransactionTypes: List transaction types

Get the list of current transaction types. For information on the default transaction types provided with  LUSID, see https://support.lusid.com/knowledgebase/article/KA-01873/.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListTransactionTypesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the transaction types. Defaults              to returning the latest versions if not specified. (optional) 
            var scope = scope_example;  // string | The scope in which the side exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] ListTransactionTypes: List transaction types
                Dictionary<string, List<TransactionType>> result = apiInstance.ListTransactionTypes(asAt, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.ListTransactionTypes: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the transaction types. Defaults              to returning the latest versions if not specified. | [optional] 
 **scope** | **string**| The scope in which the side exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

### Return type

**Dictionary<string, List<TransactionType>>**

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="setsidedefinition"></a>
# **SetSideDefinition**
> SideDefinition SetSideDefinition (string side, SideDefinitionRequest sideDefinitionRequest, string scope = null)

[EXPERIMENTAL] SetSideDefinition: Set a side definition

Set a new side definition for use in a transaction type. For more information, see https://support.lusid.com/knowledgebase/article/KA-01875.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class SetSideDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var side = side_example;  // string | The label to uniquely identify the side.
            var sideDefinitionRequest = new SideDefinitionRequest(); // SideDefinitionRequest | The side definition to create or replace.
            var scope = scope_example;  // string | The scope in which the side exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] SetSideDefinition: Set a side definition
                SideDefinition result = apiInstance.SetSideDefinition(side, sideDefinitionRequest, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.SetSideDefinition: " + e.Message );
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
 **side** | **string**| The label to uniquely identify the side. | 
 **sideDefinitionRequest** | [**SideDefinitionRequest**](SideDefinitionRequest.md)| The side definition to create or replace. | 
 **scope** | **string**| The scope in which the side exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

### Return type

[**SideDefinition**](SideDefinition.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="setsidedefinitions"></a>
# **SetSideDefinitions**
> ResourceListOfSideDefinition SetSideDefinitions (List<SidesDefinitionRequest> sidesDefinitionRequest, string scope = null)

[EXPERIMENTAL] SetSideDefinitions: Set the given side definitions

Set a new side definition for use in a transaction type. For more information, see https://support.lusid.com/knowledgebase/article/KA-01875.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class SetSideDefinitionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var sidesDefinitionRequest = new List<SidesDefinitionRequest>(); // List<SidesDefinitionRequest> | The list of side definitions to create, or replace.
            var scope = scope_example;  // string | The scope in which the side exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] SetSideDefinitions: Set the given side definitions
                ResourceListOfSideDefinition result = apiInstance.SetSideDefinitions(sidesDefinitionRequest, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.SetSideDefinitions: " + e.Message );
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
 **sidesDefinitionRequest** | [**List&lt;SidesDefinitionRequest&gt;**](SidesDefinitionRequest.md)| The list of side definitions to create, or replace. | 
 **scope** | **string**| The scope in which the side exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

### Return type

[**ResourceListOfSideDefinition**](ResourceListOfSideDefinition.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="settransactiontype"></a>
# **SetTransactionType**
> TransactionType SetTransactionType (string source, string type, TransactionTypeRequest transactionTypeRequest, string scope = null)

[EXPERIMENTAL] SetTransactionType: Set a specific transaction type

Set a transaction type for the given source and type. If the requested transaction type does not exist, it will be created    WARNING! Changing existing transaction types has a material impact on how data, new and old, is processed and aggregated by LUSID, and will affect your whole organisation. Only call this API if you are fully aware of the implications of the change.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class SetTransactionTypeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var source = source_example;  // string | The source to set the transaction configuration for
            var type = type_example;  // string | One of the transaction configuration alias types to uniquely identify the configuration
            var transactionTypeRequest = new TransactionTypeRequest(); // TransactionTypeRequest | The transaction configuration to set
            var scope = scope_example;  // string | The scope in which the transaction types exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] SetTransactionType: Set a specific transaction type
                TransactionType result = apiInstance.SetTransactionType(source, type, transactionTypeRequest, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.SetTransactionType: " + e.Message );
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
 **source** | **string**| The source to set the transaction configuration for | 
 **type** | **string**| One of the transaction configuration alias types to uniquely identify the configuration | 
 **transactionTypeRequest** | [**TransactionTypeRequest**](TransactionTypeRequest.md)| The transaction configuration to set | 
 **scope** | **string**| The scope in which the transaction types exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

### Return type

[**TransactionType**](TransactionType.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="settransactiontypesource"></a>
# **SetTransactionTypeSource**
> ResourceListOfTransactionType SetTransactionTypeSource (string source, List<TransactionTypeRequest> transactionTypeRequest, string scope = null)

[EXPERIMENTAL] SetTransactionTypeSource: Set the transaction types for the given source and scope

The complete set of transaction types for the source.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class SetTransactionTypeSourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var source = source_example;  // string | The source to set the transaction types for.
            var transactionTypeRequest = new List<TransactionTypeRequest>(); // List<TransactionTypeRequest> | The set of transaction types.
            var scope = scope_example;  // string | The scope in which the transaction types exists. When not supplied the scope is 'default'. (optional)  (default to "default")

            try
            {
                // [EXPERIMENTAL] SetTransactionTypeSource: Set the transaction types for the given source and scope
                ResourceListOfTransactionType result = apiInstance.SetTransactionTypeSource(source, transactionTypeRequest, scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionConfigurationApi.SetTransactionTypeSource: " + e.Message );
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
 **source** | **string**| The source to set the transaction types for. | 
 **transactionTypeRequest** | [**List&lt;TransactionTypeRequest&gt;**](TransactionTypeRequest.md)| The set of transaction types. | 
 **scope** | **string**| The scope in which the transaction types exists. When not supplied the scope is &#39;default&#39;. | [optional] [default to &quot;default&quot;]

### Return type

[**ResourceListOfTransactionType**](ResourceListOfTransactionType.md)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

