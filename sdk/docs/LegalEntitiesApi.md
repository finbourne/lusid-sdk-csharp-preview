# Lusid.Sdk.Api.LegalEntitiesApi

All URIs are relative to *https://fbn-prd.lusid.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteLegalEntity**](LegalEntitiesApi.md#deletelegalentity) | **DELETE** /api/legalentities/{idTypeScope}/{idTypeCode}/{code} | [EXPERIMENTAL] Delete legal entity
[**DeleteLegalEntityAccessMetadata**](LegalEntitiesApi.md#deletelegalentityaccessmetadata) | **DELETE** /api/legalentities/{idTypeScope}/{idTypeCode}/{code}/metadata/{metadataKey} | [EXPERIMENTAL] Delete a Legal Entity Access Metadata entry
[**GetAllLegalEntityAccessMetadata**](LegalEntitiesApi.md#getalllegalentityaccessmetadata) | **GET** /api/legalentities/{idTypeScope}/{idTypeCode}/{code}/metadata | [EXPERIMENTAL] Get Access Metadata rules for a Legal Entity
[**GetLegalEntity**](LegalEntitiesApi.md#getlegalentity) | **GET** /api/legalentities/{idTypeScope}/{idTypeCode}/{code} | [EXPERIMENTAL] Get Legal Entity
[**GetLegalEntityAccessMetadataByKey**](LegalEntitiesApi.md#getlegalentityaccessmetadatabykey) | **GET** /api/legalentities/{idTypeScope}/{idTypeCode}/{code}/metadata/{metadataKey} | [EXPERIMENTAL] Get an entry identified by a metadataKey in the Access Metadata of a Legal Entity
[**GetLegalEntityRelations**](LegalEntitiesApi.md#getlegalentityrelations) | **GET** /api/legalentities/{idTypeScope}/{idTypeCode}/{code}/relations | [EXPERIMENTAL] Get Relations for Legal Entity
[**ListLegalEntities**](LegalEntitiesApi.md#listlegalentities) | **GET** /api/legalentities/{idTypeScope}/{idTypeCode} | [EXPERIMENTAL] List Legal Entities
[**UpsertLegalEntity**](LegalEntitiesApi.md#upsertlegalentity) | **POST** /api/legalentities | [EXPERIMENTAL] Upsert Legal Entity
[**UpsertLegalEntityAccessMetadata**](LegalEntitiesApi.md#upsertlegalentityaccessmetadata) | **PUT** /api/legalentities/{idTypeScope}/{idTypeCode}/{code}/metadata/{metadataKey} | [EXPERIMENTAL] Upsert a Legal Entity Access Metadata entry associated with a specific metadataKey. This creates or updates the data in LUSID.



## DeleteLegalEntity

> DeletedEntityResponse DeleteLegalEntity (string idTypeScope, string idTypeCode, string code)

[EXPERIMENTAL] Delete legal entity

Delete a legal entity. Deletion will be valid from the legal entity's creation datetime.  This means that the legal entity will no longer exist at any effective datetime from the asAt datetime of deletion.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteLegalEntityExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | The scope of the legal entity identifier type.
            var idTypeCode = idTypeCode_example;  // string | The code of the legal entity identifier type.
            var code = code_example;  // string | Code of the legal entity under specified identifier type scope and code. This together with defined              identifier type uniquely identifies the legal entity to delete.

            try
            {
                // [EXPERIMENTAL] Delete legal entity
                DeletedEntityResponse result = apiInstance.DeleteLegalEntity(idTypeScope, idTypeCode, code);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.DeleteLegalEntity: " + e.Message );
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
 **idTypeScope** | **string**| The scope of the legal entity identifier type. | 
 **idTypeCode** | **string**| The code of the legal entity identifier type. | 
 **code** | **string**| Code of the legal entity under specified identifier type scope and code. This together with defined              identifier type uniquely identifies the legal entity to delete. | 

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
| **200** | The response from deleting legal entity. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteLegalEntityAccessMetadata

> DeletedEntityResponse DeleteLegalEntityAccessMetadata (string idTypeScope, string idTypeCode, string code, string metadataKey, DateTimeOrCutLabel effectiveAt = null)

[EXPERIMENTAL] Delete a Legal Entity Access Metadata entry

Deletes the Legal Entity Access Metadata entry that exactly matches the provided identifier parts.    It is important to always check to verify success (or failure).

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteLegalEntityAccessMetadataExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | Scope of the Legal Entity identifier.
            var idTypeCode = idTypeCode_example;  // string | Code of the Legal Entity identifier.
            var code = code_example;  // string | Code of the Legal Entity under specified identifier type's scope and code.
            var metadataKey = metadataKey_example;  // string | Key of the metadata entry to retrieve
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective date to delete at, if this is not supplied, it will delete all data found (optional) 

            try
            {
                // [EXPERIMENTAL] Delete a Legal Entity Access Metadata entry
                DeletedEntityResponse result = apiInstance.DeleteLegalEntityAccessMetadata(idTypeScope, idTypeCode, code, metadataKey, effectiveAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.DeleteLegalEntityAccessMetadata: " + e.Message );
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
 **idTypeScope** | **string**| Scope of the Legal Entity identifier. | 
 **idTypeCode** | **string**| Code of the Legal Entity identifier. | 
 **code** | **string**| Code of the Legal Entity under specified identifier type&#39;s scope and code. | 
 **metadataKey** | **string**| Key of the metadata entry to retrieve | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective date to delete at, if this is not supplied, it will delete all data found | [optional] 

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
| **200** | The Access Metadata with the given metadataKey has been deleted |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetAllLegalEntityAccessMetadata

> Dictionary&lt;string, List&lt;AccessMetadataValue&gt;&gt; GetAllLegalEntityAccessMetadata (string idTypeScope, string idTypeCode, string code, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get Access Metadata rules for a Legal Entity

Pass the Scope and Code of the Legal Entity identifier along with the Legal Entity code parameter to retrieve the associated Access Metadata

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetAllLegalEntityAccessMetadataExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | Scope of the Legal Entity identifier.
            var idTypeCode = idTypeCode_example;  // string | Code of the Legal Entity identifier.
            var code = code_example;  // string | Code of the Legal Entity under specified identifier type's scope and code.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effectiveAt datetime at which to retrieve the Access Metadata (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the Access Metadata (optional) 

            try
            {
                // [EXPERIMENTAL] Get Access Metadata rules for a Legal Entity
                Dictionary<string, List<AccessMetadataValue>> result = apiInstance.GetAllLegalEntityAccessMetadata(idTypeScope, idTypeCode, code, effectiveAt, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.GetAllLegalEntityAccessMetadata: " + e.Message );
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
 **idTypeScope** | **string**| Scope of the Legal Entity identifier. | 
 **idTypeCode** | **string**| Code of the Legal Entity identifier. | 
 **code** | **string**| Code of the Legal Entity under specified identifier type&#39;s scope and code. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effectiveAt datetime at which to retrieve the Access Metadata | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the Access Metadata | [optional] 

### Return type

**Dictionary<string, List<AccessMetadataValue>>**

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The access metadata for the Legal Entity or any failure. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetLegalEntity

> LegalEntity GetLegalEntity (string idTypeScope, string idTypeCode, string code, List<string> propertyKeys = null, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get Legal Entity

Retrieve the definition of a legal entity.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetLegalEntityExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | Scope of the legal entity identifier type.
            var idTypeCode = idTypeCode_example;  // string | Code of the legal entity identifier type.
            var code = code_example;  // string | Code of the legal entity under specified scope and code. This together with stated identifier type uniquely              identifies the legal entity.
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the \"LegalEntity\" domain to decorate onto each legal entity.              These take the format {domain}/{scope}/{code} e.g. \"LegalEntity/ContactDetails/Address\". Defaults to include all properties if not specified. (optional) 
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the legal entity. Defaults to the current LUSID system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the legal entity. Defaults to return the latest version of the legal entity if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] Get Legal Entity
                LegalEntity result = apiInstance.GetLegalEntity(idTypeScope, idTypeCode, code, propertyKeys, effectiveAt, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.GetLegalEntity: " + e.Message );
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
 **idTypeScope** | **string**| Scope of the legal entity identifier type. | 
 **idTypeCode** | **string**| Code of the legal entity identifier type. | 
 **code** | **string**| Code of the legal entity under specified scope and code. This together with stated identifier type uniquely              identifies the legal entity. | 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the \&quot;LegalEntity\&quot; domain to decorate onto each legal entity.              These take the format {domain}/{scope}/{code} e.g. \&quot;LegalEntity/ContactDetails/Address\&quot;. Defaults to include all properties if not specified. | [optional] 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to retrieve the legal entity. Defaults to the current LUSID system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the legal entity. Defaults to return the latest version of the legal entity if not specified. | [optional] 

### Return type

[**LegalEntity**](LegalEntity.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested legal entity definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetLegalEntityAccessMetadataByKey

> ICollection&lt;AccessMetadataValue&gt; GetLegalEntityAccessMetadataByKey (string idTypeScope, string idTypeCode, string code, string metadataKey, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Get an entry identified by a metadataKey in the Access Metadata of a Legal Entity

Get a specific Legal Entity Access Metadata by specifying the corresponding identifier parts and Legal Entity code                No matching will be performed through this endpoint. To retrieve an entry, it is necessary to specify, exactly, the identifier of the entry

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetLegalEntityAccessMetadataByKeyExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | Scope of the Legal Entity identifier.
            var idTypeCode = idTypeCode_example;  // string | Code of the Legal Entity identifier.
            var code = code_example;  // string | Code of the Legal Entity under specified identifier type's scope and code.
            var metadataKey = metadataKey_example;  // string | Key of the metadata entry to retrieve
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effectiveAt datetime at which to retrieve the Access Metadata (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the Access Metadata (optional) 

            try
            {
                // [EXPERIMENTAL] Get an entry identified by a metadataKey in the Access Metadata of a Legal Entity
                ICollection<AccessMetadataValue> result = apiInstance.GetLegalEntityAccessMetadataByKey(idTypeScope, idTypeCode, code, metadataKey, effectiveAt, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.GetLegalEntityAccessMetadataByKey: " + e.Message );
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
 **idTypeScope** | **string**| Scope of the Legal Entity identifier. | 
 **idTypeCode** | **string**| Code of the Legal Entity identifier. | 
 **code** | **string**| Code of the Legal Entity under specified identifier type&#39;s scope and code. | 
 **metadataKey** | **string**| Key of the metadata entry to retrieve | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effectiveAt datetime at which to retrieve the Access Metadata | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the Access Metadata | [optional] 

### Return type

[**ICollection&lt;AccessMetadataValue&gt;**](AccessMetadataValue.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully retrieved Legal Entity access metadata filtered by metadataKey or any failure. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetLegalEntityRelations

> ResourceListOfRelation GetLegalEntityRelations (string idTypeScope, string idTypeCode, string code, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, string filter = null, List<string> identifierTypes = null)

[EXPERIMENTAL] Get Relations for Legal Entity

Get relations for the specified Legal Entity

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetLegalEntityRelationsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | Scope of the legal entity identifier type.
            var idTypeCode = idTypeCode_example;  // string | Code of the legal entity identifier type.
            var code = code_example;  // string | Code of the legal entity under specified identifier type's scope and code. This together with stated identifier type uniquely              identifies the legal entity.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to get relations. Defaults to the current LUSID system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the legal entity's relations. Defaults to return the latest LUSID AsAt time if not specified. (optional) 
            var filter = filter_example;  // string | Expression to filter the relations. Users should provide null or empty string for this field until further notice. (optional) 
            var identifierTypes = new List<string>(); // List<string> | Identifiers types (as property keys) used for referencing LegalEntities or Legal Entities. These take the format              {domain}/{scope}/{code} e.g. \"Person/CompanyDetails/Role\". They must be from the \"Person\" or \"LegalEntity\" domain.              Only identifier types stated will be used to look up relevant entities in relations. If not applicable, provide an empty array. (optional) 

            try
            {
                // [EXPERIMENTAL] Get Relations for Legal Entity
                ResourceListOfRelation result = apiInstance.GetLegalEntityRelations(idTypeScope, idTypeCode, code, effectiveAt, asAt, filter, identifierTypes);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.GetLegalEntityRelations: " + e.Message );
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
 **idTypeScope** | **string**| Scope of the legal entity identifier type. | 
 **idTypeCode** | **string**| Code of the legal entity identifier type. | 
 **code** | **string**| Code of the legal entity under specified identifier type&#39;s scope and code. This together with stated identifier type uniquely              identifies the legal entity. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to get relations. Defaults to the current LUSID system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the legal entity&#39;s relations. Defaults to return the latest LUSID AsAt time if not specified. | [optional] 
 **filter** | **string**| Expression to filter the relations. Users should provide null or empty string for this field until further notice. | [optional] 
 **identifierTypes** | [**List&lt;string&gt;**](string.md)| Identifiers types (as property keys) used for referencing LegalEntities or Legal Entities. These take the format              {domain}/{scope}/{code} e.g. \&quot;Person/CompanyDetails/Role\&quot;. They must be from the \&quot;Person\&quot; or \&quot;LegalEntity\&quot; domain.              Only identifier types stated will be used to look up relevant entities in relations. If not applicable, provide an empty array. | [optional] 

### Return type

[**ResourceListOfRelation**](ResourceListOfRelation.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The relations for the specific legal entity. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListLegalEntities

> PagedResourceListOfLegalEntity ListLegalEntities (string idTypeScope, string idTypeCode, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, string page = null, int? start = null, int? limit = null, string filter = null, List<string> propertyKeys = null)

[EXPERIMENTAL] List Legal Entities

List legal entities which has identifier of specific identifier type's scope and code, and satisfies filter criteria.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListLegalEntitiesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | Scope of the legal entity identifier type.
            var idTypeCode = idTypeCode_example;  // string | Code of the legal entity identifier type.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to list the people. Defaults to the current LUSID              system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to list the people. Defaults to return the latest version              of each people if not specified. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing legal entities from a previous call to list legal entities. This  value is returned from the previous call. If a pagination token is provided the filter, effectiveAt  and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var start = 56;  // int? | When paginating, skip this number of results. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. Defaults to 65,535 if not specified. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set.               Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 
            var propertyKeys = new List<string>(); // List<string> | A list of property keys from the \"LegalEntity\" domain to decorate onto each legal entity.              These take the format {domain}/{scope}/{code} e.g. \"LegalEntity/ContactDetails/Address\". Defaults to include all properties if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] List Legal Entities
                PagedResourceListOfLegalEntity result = apiInstance.ListLegalEntities(idTypeScope, idTypeCode, effectiveAt, asAt, page, start, limit, filter, propertyKeys);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.ListLegalEntities: " + e.Message );
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
 **idTypeScope** | **string**| Scope of the legal entity identifier type. | 
 **idTypeCode** | **string**| Code of the legal entity identifier type. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to list the people. Defaults to the current LUSID              system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to list the people. Defaults to return the latest version              of each people if not specified. | [optional] 
 **page** | **string**| The pagination token to use to continue listing legal entities from a previous call to list legal entities. This  value is returned from the previous call. If a pagination token is provided the filter, effectiveAt  and asAt fields must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **start** | **int?**| When paginating, skip this number of results. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. Defaults to 65,535 if not specified. | [optional] 
 **filter** | **string**| Expression to filter the result set.               Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 
 **propertyKeys** | [**List&lt;string&gt;**](string.md)| A list of property keys from the \&quot;LegalEntity\&quot; domain to decorate onto each legal entity.              These take the format {domain}/{scope}/{code} e.g. \&quot;LegalEntity/ContactDetails/Address\&quot;. Defaults to include all properties if not specified. | [optional] 

### Return type

[**PagedResourceListOfLegalEntity**](PagedResourceListOfLegalEntity.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Legal Entities in specified scope |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertLegalEntity

> LegalEntity UpsertLegalEntity (UpsertLegalEntityRequest upsertLegalEntityRequest)

[EXPERIMENTAL] Upsert Legal Entity

Create or update new legal entity under specified scope

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertLegalEntityExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var upsertLegalEntityRequest = new UpsertLegalEntityRequest(); // UpsertLegalEntityRequest | Request to create or update a legal entity.

            try
            {
                // [EXPERIMENTAL] Upsert Legal Entity
                LegalEntity result = apiInstance.UpsertLegalEntity(upsertLegalEntityRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.UpsertLegalEntity: " + e.Message );
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
 **upsertLegalEntityRequest** | [**UpsertLegalEntityRequest**](UpsertLegalEntityRequest.md)| Request to create or update a legal entity. | 

### Return type

[**LegalEntity**](LegalEntity.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The newly created or updated legal entity |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpsertLegalEntityAccessMetadata

> ResourceListOfAccessMetadataValueOf UpsertLegalEntityAccessMetadata (string idTypeScope, string idTypeCode, string code, string metadataKey, UpsertLegalEntityAccessMetadataRequest upsertLegalEntityAccessMetadataRequest, DateTimeOrCutLabel effectiveAt = null)

[EXPERIMENTAL] Upsert a Legal Entity Access Metadata entry associated with a specific metadataKey. This creates or updates the data in LUSID.

Update or insert one Legal Entity Access Metadata entry in a single scope. An item will be updated if it already exists  and inserted if it does not.                The response will return the successfully updated or inserted Legal Entity Access Metadata rule or failure message if unsuccessful.                It is important to always check to verify success (or failure).                Multiple rules for a metadataKey can exist with different effective at dates, when resources are accessed the rule that is active for the current time will be fetched.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertLegalEntityAccessMetadataExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LegalEntitiesApi(Configuration.Default);
            var idTypeScope = idTypeScope_example;  // string | Scope of the Legal Entity identifier.
            var idTypeCode = idTypeCode_example;  // string | Code of the Legal Entity identifier.
            var code = code_example;  // string | Code of the Legal Entity under specified identifier type's scope and code.
            var metadataKey = metadataKey_example;  // string | Key of the metadata entry to retrieve
            var upsertLegalEntityAccessMetadataRequest = new UpsertLegalEntityAccessMetadataRequest(); // UpsertLegalEntityAccessMetadataRequest | The Legal Entity Access Metadata entry to upsert
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effectiveAt datetime at which to upsert the Access Metadata (optional) 

            try
            {
                // [EXPERIMENTAL] Upsert a Legal Entity Access Metadata entry associated with a specific metadataKey. This creates or updates the data in LUSID.
                ResourceListOfAccessMetadataValueOf result = apiInstance.UpsertLegalEntityAccessMetadata(idTypeScope, idTypeCode, code, metadataKey, upsertLegalEntityAccessMetadataRequest, effectiveAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling LegalEntitiesApi.UpsertLegalEntityAccessMetadata: " + e.Message );
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
 **idTypeScope** | **string**| Scope of the Legal Entity identifier. | 
 **idTypeCode** | **string**| Code of the Legal Entity identifier. | 
 **code** | **string**| Code of the Legal Entity under specified identifier type&#39;s scope and code. | 
 **metadataKey** | **string**| Key of the metadata entry to retrieve | 
 **upsertLegalEntityAccessMetadataRequest** | [**UpsertLegalEntityAccessMetadataRequest**](UpsertLegalEntityAccessMetadataRequest.md)| The Legal Entity Access Metadata entry to upsert | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effectiveAt datetime at which to upsert the Access Metadata | [optional] 

### Return type

[**ResourceListOfAccessMetadataValueOf**](ResourceListOfAccessMetadataValueOf.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully updated or inserted item or any failure. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

