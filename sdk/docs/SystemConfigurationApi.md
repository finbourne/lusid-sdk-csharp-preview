# Lusid.Sdk.Api.SystemConfigurationApi

All URIs are relative to *http://local-unit-test-server.lusid.com:51445*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateConfigurationTransactionType**](SystemConfigurationApi.md#createconfigurationtransactiontype) | **POST** /api/systemconfiguration/transactions/type | [EARLY ACCESS] Create transaction type
[**CreateSideDefinition**](SystemConfigurationApi.md#createsidedefinition) | **POST** /api/systemconfiguration/transactions/side | [EXPERIMENTAL] Create side definition
[**ListConfigurationTransactionTypes**](SystemConfigurationApi.md#listconfigurationtransactiontypes) | **GET** /api/systemconfiguration/transactions | [EARLY ACCESS] List transaction types
[**SetConfigurationTransactionTypes**](SystemConfigurationApi.md#setconfigurationtransactiontypes) | **PUT** /api/systemconfiguration/transactions | [EXPERIMENTAL] Set transaction types



## CreateConfigurationTransactionType

> TransactionSetConfigurationData CreateConfigurationTransactionType (TransactionConfigurationDataRequest transactionConfigurationDataRequest = null)

[EARLY ACCESS] Create transaction type

Create a new transaction type by specifying a definition and mappings to movements.

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
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:51445";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemConfigurationApi(Configuration.Default);
            var transactionConfigurationDataRequest = new TransactionConfigurationDataRequest(); // TransactionConfigurationDataRequest | A transaction type definition. (optional) 

            try
            {
                // [EARLY ACCESS] Create transaction type
                TransactionSetConfigurationData result = apiInstance.CreateConfigurationTransactionType(transactionConfigurationDataRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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
 **transactionConfigurationDataRequest** | [**TransactionConfigurationDataRequest**](TransactionConfigurationDataRequest.md)| A transaction type definition. | [optional] 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## CreateSideDefinition

> TransactionSetConfigurationData CreateSideDefinition (SideConfigurationDataRequest sideConfigurationDataRequest = null)

[EXPERIMENTAL] Create side definition

Create a new side definition for use in a transaction type. For more information, see https://support.lusid.com/knowledgebase/article/KA-01875.

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
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:51445";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemConfigurationApi(Configuration.Default);
            var sideConfigurationDataRequest = new SideConfigurationDataRequest(); // SideConfigurationDataRequest | The definition of the side. (optional) 

            try
            {
                // [EXPERIMENTAL] Create side definition
                TransactionSetConfigurationData result = apiInstance.CreateSideDefinition(sideConfigurationDataRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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
 **sideConfigurationDataRequest** | [**SideConfigurationDataRequest**](SideConfigurationDataRequest.md)| The definition of the side. | [optional] 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListConfigurationTransactionTypes

> TransactionSetConfigurationData ListConfigurationTransactionTypes (DateTimeOffset? asAt = null)

[EARLY ACCESS] List transaction types

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
    public class ListConfigurationTransactionTypesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:51445";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemConfigurationApi(Configuration.Default);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the transaction types. Defaults              to returning the latest versions if not specified. (optional) 

            try
            {
                // [EARLY ACCESS] List transaction types
                TransactionSetConfigurationData result = apiInstance.ListConfigurationTransactionTypes(asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the transaction types. Defaults              to returning the latest versions if not specified. | [optional] 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## SetConfigurationTransactionTypes

> TransactionSetConfigurationData SetConfigurationTransactionTypes (TransactionSetConfigurationDataRequest transactionSetConfigurationDataRequest = null)

[EXPERIMENTAL] Set transaction types

Configure all existing transaction types. Note it is not possible to configure a single existing transaction type on its own.                WARNING! Changing existing transaction types has a material impact on how data, new and old, is processed and aggregated by LUSID, and will affect your whole organisation. Only call this API if you are fully aware of the implications of the change.

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
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:51445";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemConfigurationApi(Configuration.Default);
            var transactionSetConfigurationDataRequest = new TransactionSetConfigurationDataRequest(); // TransactionSetConfigurationDataRequest | The complete set of transaction type definitions. (optional) 

            try
            {
                // [EXPERIMENTAL] Set transaction types
                TransactionSetConfigurationData result = apiInstance.SetConfigurationTransactionTypes(transactionSetConfigurationDataRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
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
 **transactionSetConfigurationDataRequest** | [**TransactionSetConfigurationDataRequest**](TransactionSetConfigurationDataRequest.md)| The complete set of transaction type definitions. | [optional] 

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

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

