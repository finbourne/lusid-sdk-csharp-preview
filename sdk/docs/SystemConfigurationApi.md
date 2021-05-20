# Lusid.Sdk.Api.SystemConfigurationApi

All URIs are relative to *https://fbn-prd.lusid.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateConfigurationTransactionType**](SystemConfigurationApi.md#createconfigurationtransactiontype) | **POST** /api/systemconfiguration/transactions/type | [EARLY ACCESS] Create transaction type
[**CreateSideDefinition**](SystemConfigurationApi.md#createsidedefinition) | **POST** /api/systemconfiguration/transactions/side | [EXPERIMENTAL] Create side definition
[**ListConfigurationTransactionTypes**](SystemConfigurationApi.md#listconfigurationtransactiontypes) | **GET** /api/systemconfiguration/transactions | [EARLY ACCESS] List transaction types
[**SetConfigurationTransactionTypes**](SystemConfigurationApi.md#setconfigurationtransactiontypes) | **PUT** /api/systemconfiguration/transactions | [EXPERIMENTAL] Set transaction types


<a name="createconfigurationtransactiontype"></a>
# **CreateConfigurationTransactionType**
> TransactionSetConfigurationData CreateConfigurationTransactionType (TransactionConfigurationDataRequest transactionConfigurationDataRequest = null)

[EARLY ACCESS] Create transaction type

Create a new transaction type by specifying a definition and the mappings to movements

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateConfigurationTransactionTypeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemConfigurationApi(config);
            var transactionConfigurationDataRequest = new TransactionConfigurationDataRequest(); // TransactionConfigurationDataRequest | A transaction type definition (optional) 

            try
            {
                // [EARLY ACCESS] Create transaction type
                TransactionSetConfigurationData result = apiInstance.CreateConfigurationTransactionType(transactionConfigurationDataRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SystemConfigurationApi.CreateConfigurationTransactionType: " + e.Message );
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
 **transactionConfigurationDataRequest** | [**TransactionConfigurationDataRequest**](TransactionConfigurationDataRequest.md)| A transaction type definition | [optional] 

### Return type

[**TransactionSetConfigurationData**](TransactionSetConfigurationData.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createsidedefinition"></a>
# **CreateSideDefinition**
> TransactionSetConfigurationData CreateSideDefinition (SideConfigurationDataRequest sideConfigurationDataRequest = null)

[EXPERIMENTAL] Create side definition

Create a new side definition for us in transaction type configuration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateSideDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemConfigurationApi(config);
            var sideConfigurationDataRequest = new SideConfigurationDataRequest(); // SideConfigurationDataRequest | The definition of the side to be created. (optional) 

            try
            {
                // [EXPERIMENTAL] Create side definition
                TransactionSetConfigurationData result = apiInstance.CreateSideDefinition(sideConfigurationDataRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SystemConfigurationApi.CreateSideDefinition: " + e.Message );
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
 **sideConfigurationDataRequest** | [**SideConfigurationDataRequest**](SideConfigurationDataRequest.md)| The definition of the side to be created. | [optional] 

### Return type

[**TransactionSetConfigurationData**](TransactionSetConfigurationData.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listconfigurationtransactiontypes"></a>
# **ListConfigurationTransactionTypes**
> TransactionSetConfigurationData ListConfigurationTransactionTypes (DateTimeOffset? asAt = null)

[EARLY ACCESS] List transaction types

Get the list of persisted transaction types

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListConfigurationTransactionTypesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemConfigurationApi(config);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the Transaction configuration types. Defaults              to return the latest version of the holdings if not specified. (optional) 

            try
            {
                // [EARLY ACCESS] List transaction types
                TransactionSetConfigurationData result = apiInstance.ListConfigurationTransactionTypes(asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SystemConfigurationApi.ListConfigurationTransactionTypes: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the Transaction configuration types. Defaults              to return the latest version of the holdings if not specified. | [optional] 

### Return type

[**TransactionSetConfigurationData**](TransactionSetConfigurationData.md)

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

<a name="setconfigurationtransactiontypes"></a>
# **SetConfigurationTransactionTypes**
> TransactionSetConfigurationData SetConfigurationTransactionTypes (TransactionSetConfigurationDataRequest transactionSetConfigurationDataRequest = null)

[EXPERIMENTAL] Set transaction types

Set all transaction types to be used by the movements engine, for the organisation                WARNING! Changing these mappings will have a material impact on how data, new and old, is processed and aggregated by LUSID. This will affect your whole organisation. Only change if you are fully aware of the implications of the change.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class SetConfigurationTransactionTypesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemConfigurationApi(config);
            var transactionSetConfigurationDataRequest = new TransactionSetConfigurationDataRequest(); // TransactionSetConfigurationDataRequest | The complete set of transaction type definitions (optional) 

            try
            {
                // [EXPERIMENTAL] Set transaction types
                TransactionSetConfigurationData result = apiInstance.SetConfigurationTransactionTypes(transactionSetConfigurationDataRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SystemConfigurationApi.SetConfigurationTransactionTypes: " + e.Message );
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
 **transactionSetConfigurationDataRequest** | [**TransactionSetConfigurationDataRequest**](TransactionSetConfigurationDataRequest.md)| The complete set of transaction type definitions | [optional] 

### Return type

[**TransactionSetConfigurationData**](TransactionSetConfigurationData.md)

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

