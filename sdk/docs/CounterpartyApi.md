# Lusid.Sdk.Api.CounterpartyApi

All URIs are relative to *http://local-unit-test-server.lusid.com:61741*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteCounterparty**](CounterpartyApi.md#deletecounterparty) | **DELETE** /api/counterparties/counterparties/counterparty/{scope}/{code} | [EXPERIMENTAL] Delete the Counterparty of given scope and code, assuming that it is present.
[**DeleteCreditSupportAnnex**](CounterpartyApi.md#deletecreditsupportannex) | **DELETE** /api/counterparties/counterparties/csa/{scope}/{code} | [EXPERIMENTAL] Delete the CSA of given scope and code, assuming that it is present.
[**GetCounterparty**](CounterpartyApi.md#getcounterparty) | **GET** /api/counterparties/counterparties/counterparty/{scope}/{code} | [EXPERIMENTAL] Get Counterparty
[**GetCreditSupportAnnex**](CounterpartyApi.md#getcreditsupportannex) | **GET** /api/counterparties/counterparties/csa/{scope}/{code} | [EXPERIMENTAL] Get CSA
[**ListCounterparties**](CounterpartyApi.md#listcounterparties) | **GET** /api/counterparties/counterparties/counterparty | [EXPERIMENTAL] List the set of Counterparties
[**ListCreditSupportAnnexes**](CounterpartyApi.md#listcreditsupportannexes) | **GET** /api/counterparties/counterparties/csa | [EXPERIMENTAL] List the set of CSAs
[**UpsertCounterparty**](CounterpartyApi.md#upsertcounterparty) | **POST** /api/counterparties/counterparties/counterparty | [EXPERIMENTAL] Upsert Counterparty. This creates or updates the data in Lusid.
[**UpsertCreditSupportAnnex**](CounterpartyApi.md#upsertcreditsupportannex) | **POST** /api/counterparties/counterparties/csa | [EXPERIMENTAL] Upsert CSA. This creates or updates the data in Lusid.



## DeleteCounterparty

> AnnulSingleStructuredDataResponse DeleteCounterparty (string scope, string code)

[EXPERIMENTAL] Delete the Counterparty of given scope and code, assuming that it is present.

Delete the specified Counterparty from a single scope.  The response will return either detail of the deleted item, or an explanation (failure) as to why this did not succeed.                It is important to always check for any unsuccessful response.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteCounterpartyExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:61741";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CounterpartyApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the Counterparty to delete.
            var code = code_example;  // string | The Counterparty to delete.

            try
            {
                // [EXPERIMENTAL] Delete the Counterparty of given scope and code, assuming that it is present.
                AnnulSingleStructuredDataResponse result = apiInstance.DeleteCounterparty(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CounterpartyApi.DeleteCounterparty: " + e.Message );
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
 **scope** | **string**| The scope of the Counterparty to delete. | 
 **code** | **string**| The Counterparty to delete. | 

### Return type

[**AnnulSingleStructuredDataResponse**](AnnulSingleStructuredDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The AsAt of deletion or failure |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteCreditSupportAnnex

> AnnulSingleStructuredDataResponse DeleteCreditSupportAnnex (string scope, string code)

[EXPERIMENTAL] Delete the CSA of given scope and code, assuming that it is present.

Delete the specified CSA from a single scope.  The response will return either detail of the deleted item, or an explanation (failure) as to why this did not succeed.                It is important to always check for any unsuccessful response.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteCreditSupportAnnexExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:61741";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CounterpartyApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the CSA to delete.
            var code = code_example;  // string | The CSA to delete.

            try
            {
                // [EXPERIMENTAL] Delete the CSA of given scope and code, assuming that it is present.
                AnnulSingleStructuredDataResponse result = apiInstance.DeleteCreditSupportAnnex(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CounterpartyApi.DeleteCreditSupportAnnex: " + e.Message );
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
 **scope** | **string**| The scope of the CSA to delete. | 
 **code** | **string**| The CSA to delete. | 

### Return type

[**AnnulSingleStructuredDataResponse**](AnnulSingleStructuredDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The AsAt of deletion or failure |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetCounterparty

> GetCounterpartyResponse GetCounterparty (string scope, string code, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get Counterparty

Get a Counterparty from a single scope.  The response will return either the counterparty that has been stored, or a failure explaining why the request was unsuccessful.  It is important to always check for any unsuccessful requests (failures).

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetCounterpartyExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:61741";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CounterpartyApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the Counterparty to retrieve.
            var code = code_example;  // string | The name of the Counterparty to retrieve the data for.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the counterparty. Defaults to return the latest version if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] Get Counterparty
                GetCounterpartyResponse result = apiInstance.GetCounterparty(scope, code, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CounterpartyApi.GetCounterparty: " + e.Message );
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
 **scope** | **string**| The scope of the Counterparty to retrieve. | 
 **code** | **string**| The name of the Counterparty to retrieve the data for. | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the counterparty. Defaults to return the latest version if not specified. | [optional] 

### Return type

[**GetCounterpartyResponse**](GetCounterpartyResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully retrieved counterparty or any failure |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetCreditSupportAnnex

> GetCreditSupportAnnexResponse GetCreditSupportAnnex (string scope, string code, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get CSA

Get a CSA from a single scope.  The response will return either the CSA that has been stored, or a failure explaining why the request was unsuccessful.  It is important to always check for any unsuccessful requests (failures).

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetCreditSupportAnnexExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:61741";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CounterpartyApi(Configuration.Default);
            var scope = scope_example;  // string | The scope of the CSA to retrieve.
            var code = code_example;  // string | The name of the CSA to retrieve the data for.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the CSA. Defaults to return the latest version if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] Get CSA
                GetCreditSupportAnnexResponse result = apiInstance.GetCreditSupportAnnex(scope, code, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CounterpartyApi.GetCreditSupportAnnex: " + e.Message );
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
 **scope** | **string**| The scope of the CSA to retrieve. | 
 **code** | **string**| The name of the CSA to retrieve the data for. | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the CSA. Defaults to return the latest version if not specified. | [optional] 

### Return type

[**GetCreditSupportAnnexResponse**](GetCreditSupportAnnexResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully retrieved credit support annexes or any failure |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListCounterparties

> ResourceListOfGetCounterpartyResponse ListCounterparties (DateTimeOffset? asAt = null)

[EXPERIMENTAL] List the set of Counterparties

List the set of Counterparties at the specified AsAt date/time

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListCounterpartiesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:61741";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CounterpartyApi(Configuration.Default);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to list the counterparty. Defaults to latest if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] List the set of Counterparties
                ResourceListOfGetCounterpartyResponse result = apiInstance.ListCounterparties(asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CounterpartyApi.ListCounterparties: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to list the counterparty. Defaults to latest if not specified. | [optional] 

### Return type

[**ResourceListOfGetCounterpartyResponse**](ResourceListOfGetCounterpartyResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested counterparties |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListCreditSupportAnnexes

> ResourceListOfGetCreditSupportAnnexResponse ListCreditSupportAnnexes (DateTimeOffset? asAt = null)

[EXPERIMENTAL] List the set of CSAs

List the set of CSAs at the specified AsAt date/time

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListCreditSupportAnnexesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:61741";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CounterpartyApi(Configuration.Default);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to list the CSAs. Defaults to latest if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] List the set of CSAs
                ResourceListOfGetCreditSupportAnnexResponse result = apiInstance.ListCreditSupportAnnexes(asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CounterpartyApi.ListCreditSupportAnnexes: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to list the CSAs. Defaults to latest if not specified. | [optional] 

### Return type

[**ResourceListOfGetCreditSupportAnnexResponse**](ResourceListOfGetCreditSupportAnnexResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested CSAs |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertCounterparty

> UpsertSingleStructuredDataResponse UpsertCounterparty (UpsertCounterpartyRequest upsertCounterpartyRequest)

[EXPERIMENTAL] Upsert Counterparty. This creates or updates the data in Lusid.

Update or insert Counterparty in a single scope. An item will be updated if it already exists and inserted if it does not.                The response will return the successfully updated or inserted Counterparty or failure message if unsuccessful                It is important to always check to verify success (or failure).

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertCounterpartyExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:61741";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CounterpartyApi(Configuration.Default);
            var upsertCounterpartyRequest = new UpsertCounterpartyRequest(); // UpsertCounterpartyRequest | The Counterparty to update or insert

            try
            {
                // [EXPERIMENTAL] Upsert Counterparty. This creates or updates the data in Lusid.
                UpsertSingleStructuredDataResponse result = apiInstance.UpsertCounterparty(upsertCounterpartyRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CounterpartyApi.UpsertCounterparty: " + e.Message );
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
 **upsertCounterpartyRequest** | [**UpsertCounterpartyRequest**](UpsertCounterpartyRequest.md)| The Counterparty to update or insert | 

### Return type

[**UpsertSingleStructuredDataResponse**](UpsertSingleStructuredDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully updated or inserted item or any failure |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertCreditSupportAnnex

> UpsertSingleStructuredDataResponse UpsertCreditSupportAnnex (UpsertCreditSupportAnnexRequest upsertCreditSupportAnnexRequest)

[EXPERIMENTAL] Upsert CSA. This creates or updates the data in Lusid.

Update or insert CSA in a single scope. An item will be updated if it already exists and inserted if it does not.                The response will return the successfully updated or inserted CSA or failure message if unsuccessful                It is important to always check to verify success (or failure).

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertCreditSupportAnnexExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://local-unit-test-server.lusid.com:61741";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CounterpartyApi(Configuration.Default);
            var upsertCreditSupportAnnexRequest = new UpsertCreditSupportAnnexRequest(); // UpsertCreditSupportAnnexRequest | The CSA to update or insert

            try
            {
                // [EXPERIMENTAL] Upsert CSA. This creates or updates the data in Lusid.
                UpsertSingleStructuredDataResponse result = apiInstance.UpsertCreditSupportAnnex(upsertCreditSupportAnnexRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CounterpartyApi.UpsertCreditSupportAnnex: " + e.Message );
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
 **upsertCreditSupportAnnexRequest** | [**UpsertCreditSupportAnnexRequest**](UpsertCreditSupportAnnexRequest.md)| The CSA to update or insert | 

### Return type

[**UpsertSingleStructuredDataResponse**](UpsertSingleStructuredDataResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully updated or inserted item or any failure |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

