# Lusid.Sdk.Api.TransactionConfigurationApi

All URIs are relative to *http://local-unit-test-server.lusid.com:37404*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteTransactionType**](TransactionConfigurationApi.md#deletetransactiontype) | **DELETE** /api/transactionconfiguration/types/{source}/{type} | [EXPERIMENTAL] DeleteTransactionType: Delete a transaction type
[**GetTransactionType**](TransactionConfigurationApi.md#gettransactiontype) | **GET** /api/transactionconfiguration/types/{source}/{type} | [EXPERIMENTAL] GetTransactionType: Get a single transaction configuration type
[**SetSideDefinition**](TransactionConfigurationApi.md#setsidedefinition) | **PUT** /api/transactionconfiguration/sides/{side} | [EXPERIMENTAL] SetSideDefinition: Set a side definition
[**SetTransactionType**](TransactionConfigurationApi.md#settransactiontype) | **PUT** /api/transactionconfiguration/types/{source}/{type} | [EXPERIMENTAL] SetTransactionType: Set a specific transaction type


<a name="deletetransactiontype"></a>
# **DeleteTransactionType**
> DeletedEntityResponse DeleteTransactionType (string source, string type)

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
            config.BasePath = "http://local-unit-test-server.lusid.com:37404";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var source = source_example;  // string | The source that the type is in
            var type = type_example;  // string | One of the type's aliases

            try
            {
                // [EXPERIMENTAL] DeleteTransactionType: Delete a transaction type
                DeletedEntityResponse result = apiInstance.DeleteTransactionType(source, type);
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

<a name="gettransactiontype"></a>
# **GetTransactionType**
> TransactionType GetTransactionType (string source, string type, DateTimeOffset? asAt = null)

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
            config.BasePath = "http://local-unit-test-server.lusid.com:37404";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var source = source_example;  // string | The source that the type is in
            var type = type_example;  // string | One of the type's aliases
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the transaction configuration.              Defaults to returning the latest version of the transaction configuration type if not specified (optional) 

            try
            {
                // [EXPERIMENTAL] GetTransactionType: Get a single transaction configuration type
                TransactionType result = apiInstance.GetTransactionType(source, type, asAt);
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

<a name="setsidedefinition"></a>
# **SetSideDefinition**
> SideDefinition SetSideDefinition (string side, SideDefinitionRequest sideDefinitionRequest)

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
            config.BasePath = "http://local-unit-test-server.lusid.com:37404";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var side = side_example;  // string | The label to uniquely identify the side.
            var sideDefinitionRequest = new SideDefinitionRequest(); // SideDefinitionRequest | The side definition to create or replace.

            try
            {
                // [EXPERIMENTAL] SetSideDefinition: Set a side definition
                SideDefinition result = apiInstance.SetSideDefinition(side, sideDefinitionRequest);
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

<a name="settransactiontype"></a>
# **SetTransactionType**
> TransactionType SetTransactionType (string source, string type, TransactionTypeRequest transactionTypeRequest)

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
            config.BasePath = "http://local-unit-test-server.lusid.com:37404";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionConfigurationApi(config);
            var source = source_example;  // string | The source to set the transaction configuration for
            var type = type_example;  // string | One of the transaction configuration alias types to uniquely identify the configuration
            var transactionTypeRequest = new TransactionTypeRequest(); // TransactionTypeRequest | The transaction configuration to set

            try
            {
                // [EXPERIMENTAL] SetTransactionType: Set a specific transaction type
                TransactionType result = apiInstance.SetTransactionType(source, type, transactionTypeRequest);
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

