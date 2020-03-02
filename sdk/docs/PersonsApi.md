# Lusid.Sdk.Api.PersonsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeletePerson**](PersonsApi.md#deleteperson) | **DELETE** /api/persons/{idTypeScope}/{idTypeCode}/{code} | [EXPERIMENTAL] Delete person
[**GetPerson**](PersonsApi.md#getperson) | **GET** /api/persons/{idTypeScope}/{idTypeCode}/{code} | [EXPERIMENTAL] Get Person
[**UpsertPerson**](PersonsApi.md#upsertperson) | **POST** /api/persons | [EXPERIMENTAL] Upsert Person



## DeletePerson

> DeletedEntityResponse DeletePerson (string idTypeScope, string idTypeCode, string code)

[EXPERIMENTAL] Delete person

Delete a person. Deletion will be valid from the person's creation datetime.  This means that the person will no longer exist at any effective datetime from the asAt datetime of deletion.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeletePersonExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PersonsApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | The scope of the person identifier type.
            var idTypeCode = idTypeCode_example;  // string | The code of the person identifier type.
            var code = code_example;  // string | Code of the person under specified identifier type scope and code. This together with defined              identifier type uniquely identifies the person to delete.

            try
            {
                // [EXPERIMENTAL] Delete person
                DeletedEntityResponse result = apiInstance.DeletePerson(idTypeScope, idTypeCode, code);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PersonsApi.DeletePerson: " + e.Message );
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
 **idTypeScope** | **string**| The scope of the person identifier type. | 
 **idTypeCode** | **string**| The code of the person identifier type. | 
 **code** | **string**| Code of the person under specified identifier type scope and code. This together with defined              identifier type uniquely identifies the person to delete. | 

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
| **200** | The response from deleting person. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetPerson

> Person GetPerson (string idTypeScope, string idTypeCode, string code, List<string> propertyKeys = null, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get Person

Retrieve the definition of a person.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetPersonExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PersonsApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | Scope of the person identifier.
            var idTypeCode = idTypeCode_example;  // string | Code of the person identifier.
            var code = code_example;  // string | Code of the person under specified scope and code. This together with stated identifier type uniquely              identifies the person.
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the \"Person\" domain to decorate onto each person.              These take the format {domain}/{scope}/{code} e.g. \"Person/ContactDetails/Address\". Defaults to include all properties if not specified. (optional) 
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the person. Defaults to the current LUSID system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the person. Defaults to return the latest version of the person if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] Get Person
                Person result = apiInstance.GetPerson(idTypeScope, idTypeCode, code, propertyKeys, effectiveAt, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PersonsApi.GetPerson: " + e.Message );
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
 **idTypeScope** | **string**| Scope of the person identifier. | 
 **idTypeCode** | **string**| Code of the person identifier. | 
 **code** | **string**| Code of the person under specified scope and code. This together with stated identifier type uniquely              identifies the person. | 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the \&quot;Person\&quot; domain to decorate onto each person.              These take the format {domain}/{scope}/{code} e.g. \&quot;Person/ContactDetails/Address\&quot;. Defaults to include all properties if not specified. | [optional] 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to retrieve the person. Defaults to the current LUSID system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the person. Defaults to return the latest version of the person if not specified. | [optional] 

### Return type

[**Person**](Person.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested person definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertPerson

> Person UpsertPerson (UpsertPersonRequest request = null)

[EXPERIMENTAL] Upsert Person

Create or update new person under specified scope

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertPersonExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PersonsApi(Configuration.Default);
            var request = new UpsertPersonRequest(); // UpsertPersonRequest | Request to create or update a person. (optional) 

            try
            {
                // [EXPERIMENTAL] Upsert Person
                Person result = apiInstance.UpsertPerson(request);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PersonsApi.UpsertPerson: " + e.Message );
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
 **request** | [**UpsertPersonRequest**](UpsertPersonRequest.md)| Request to create or update a person. | [optional] 

### Return type

[**Person**](Person.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The newly created or updated person |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

