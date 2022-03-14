# Lusid.Sdk.Api.TransactionConfigurationApi

All URIs are relative to *http://local-unit-test-server.lusid.com:48860*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetTransactionType**](TransactionConfigurationApi.md#gettransactiontype) | **GET** /api/transactionconfiguration/types/{source}/{type} | [EXPERIMENTAL] GetTransactionType: Get a single transaction configuration type


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
            config.BasePath = "http://local-unit-test-server.lusid.com:48860";
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

