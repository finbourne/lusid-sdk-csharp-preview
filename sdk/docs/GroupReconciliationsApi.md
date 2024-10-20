# Lusid.Sdk.Api.GroupReconciliationsApi

All URIs are relative to *https://www.lusid.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**BatchUpdateComparisonResults**](GroupReconciliationsApi.md#batchupdatecomparisonresults) | **POST** /api/reconciliations/groupreconciliationdefinitions/{scope}/{code}/comparisonresults/$batchReview | [EXPERIMENTAL] BatchUpdateComparisonResults: Add User Review entries for a range of comparison results related to a specific GroupReconciliationDefinition.
[**CreateComparisonRuleset**](GroupReconciliationsApi.md#createcomparisonruleset) | **POST** /api/reconciliations/comparisonrulesets | [EXPERIMENTAL] CreateComparisonRuleset: Create a Group Reconciliation Comparison Ruleset
[**CreateGroupReconciliationDefinition**](GroupReconciliationsApi.md#creategroupreconciliationdefinition) | **POST** /api/reconciliations/groupreconciliationdefinitions | [EXPERIMENTAL] CreateGroupReconciliationDefinition: Create Group Reconciliation Definition
[**DeleteComparisonRuleset**](GroupReconciliationsApi.md#deletecomparisonruleset) | **DELETE** /api/reconciliations/comparisonrulesets/{scope}/{code} | [EXPERIMENTAL] DeleteComparisonRuleset: Deletes a particular Group Reconciliation Comparison Ruleset
[**DeleteGroupReconciliationDefinition**](GroupReconciliationsApi.md#deletegroupreconciliationdefinition) | **DELETE** /api/reconciliations/groupreconciliationdefinitions/{scope}/{code} | [EXPERIMENTAL] DeleteGroupReconciliationDefinition: Delete Group Reconciliation Definition
[**GetComparisonResult**](GroupReconciliationsApi.md#getcomparisonresult) | **GET** /api/reconciliations/groupreconciliationdefinitions/{scope}/{code}/{resultId} | [EXPERIMENTAL] GetComparisonResult: Get a single Group Reconciliation Comparison Result by scope and code.
[**GetComparisonRuleset**](GroupReconciliationsApi.md#getcomparisonruleset) | **GET** /api/reconciliations/comparisonrulesets/{scope}/{code} | [EXPERIMENTAL] GetComparisonRuleset: Get a single Group Reconciliation Comparison Ruleset by scope and code.
[**GetGroupReconciliationDefinition**](GroupReconciliationsApi.md#getgroupreconciliationdefinition) | **GET** /api/reconciliations/groupreconciliationdefinitions/{scope}/{code} | [EXPERIMENTAL] GetGroupReconciliationDefinition: Get group reconciliation definition
[**ListComparisonResults**](GroupReconciliationsApi.md#listcomparisonresults) | **GET** /api/reconciliations/comparisonresults | [EXPERIMENTAL] ListComparisonResults: Get a set of Group Reconciliation Comparison Results.
[**ListComparisonRulesets**](GroupReconciliationsApi.md#listcomparisonrulesets) | **GET** /api/reconciliations/comparisonrulesets | [EXPERIMENTAL] ListComparisonRulesets: Get a set of Group Reconciliation Comparison Rulesets
[**ListGroupReconciliationDefinitions**](GroupReconciliationsApi.md#listgroupreconciliationdefinitions) | **GET** /api/reconciliations/groupreconciliationdefinitions | [EXPERIMENTAL] ListGroupReconciliationDefinitions: List group reconciliation definitions
[**RunReconciliation**](GroupReconciliationsApi.md#runreconciliation) | **POST** /api/reconciliations/groupreconciliationdefinitions/{scope}/{code}/$run | [EXPERIMENTAL] RunReconciliation: Runs a Group Reconciliation
[**UpdateComparisonRuleset**](GroupReconciliationsApi.md#updatecomparisonruleset) | **PUT** /api/reconciliations/comparisonrulesets/{scope}/{code} | [EXPERIMENTAL] UpdateComparisonRuleset: Update Group Reconciliation Comparison Ruleset defined by scope and code
[**UpdateGroupReconciliationDefinition**](GroupReconciliationsApi.md#updategroupreconciliationdefinition) | **PUT** /api/reconciliations/groupreconciliationdefinitions/{scope}/{code} | [EXPERIMENTAL] UpdateGroupReconciliationDefinition: Update group reconciliation definition


<a name="batchupdatecomparisonresults"></a>
# **BatchUpdateComparisonResults**
> BatchUpdateUserReviewForComparisonResultResponse BatchUpdateComparisonResults (string scope, string code, List<BatchUpdateUserReviewForComparisonResultRequest> batchUpdateUserReviewForComparisonResultRequest, string successMode = null)

[EXPERIMENTAL] BatchUpdateComparisonResults: Add User Review entries for a range of comparison results related to a specific GroupReconciliationDefinition.

Allows to update multiple Group Reconciliation Comparison Results related to the same definition specified by the Finbourne.Identifiers.Abstractions.Scope and Finbourne.Identifiers.Abstractions.Code.  Updates User Review with new entries and sets the relevant Review Status.  Supports partial success when all the entries that haven't passed validation or are not related to the definition will be returned with respectful error details.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class BatchUpdateComparisonResultsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | Shared Scope of the GroupReconciliationDefinition and GroupReconciliationComparisonResults.
            var code = code_example;  // string | GroupReconciliationDefinitionId code.
            var batchUpdateUserReviewForComparisonResultRequest = new List<BatchUpdateUserReviewForComparisonResultRequest>(); // List<BatchUpdateUserReviewForComparisonResultRequest> | A collection of the comparison result Ids and their user review entries to be added or removed.                  Single request contains resultId, break code/match key/comment to add and break code/match key/comment to remove by added timestamp.
            var successMode = successMode_example;  // string | Defines whether the request should fail if at least one of the entries is failed to update                  or process all the entries regardless and return collections of successful and failed updates. \"Partial\" (default) | \"Atomic\". (optional)  (default to "Partial")

            try
            {
                // [EXPERIMENTAL] BatchUpdateComparisonResults: Add User Review entries for a range of comparison results related to a specific GroupReconciliationDefinition.
                BatchUpdateUserReviewForComparisonResultResponse result = apiInstance.BatchUpdateComparisonResults(scope, code, batchUpdateUserReviewForComparisonResultRequest, successMode);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.BatchUpdateComparisonResults: " + e.Message );
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
 **scope** | **string**| Shared Scope of the GroupReconciliationDefinition and GroupReconciliationComparisonResults. | 
 **code** | **string**| GroupReconciliationDefinitionId code. | 
 **batchUpdateUserReviewForComparisonResultRequest** | [**List&lt;BatchUpdateUserReviewForComparisonResultRequest&gt;**](BatchUpdateUserReviewForComparisonResultRequest.md)| A collection of the comparison result Ids and their user review entries to be added or removed.                  Single request contains resultId, break code/match key/comment to add and break code/match key/comment to remove by added timestamp. | 
 **successMode** | **string**| Defines whether the request should fail if at least one of the entries is failed to update                  or process all the entries regardless and return collections of successful and failed updates. \&quot;Partial\&quot; (default) | \&quot;Atomic\&quot;. | [optional] [default to &quot;Partial&quot;]

### Return type

[**BatchUpdateUserReviewForComparisonResultResponse**](BatchUpdateUserReviewForComparisonResultResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The collections of comparison result Ids that succeeded or failed to update along with the updated entities or error details. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createcomparisonruleset"></a>
# **CreateComparisonRuleset**
> GroupReconciliationComparisonRuleset CreateComparisonRuleset (CreateGroupReconciliationComparisonRulesetRequest createGroupReconciliationComparisonRulesetRequest = null)

[EXPERIMENTAL] CreateComparisonRuleset: Create a Group Reconciliation Comparison Ruleset

Creates a set of core and aggregate rules to be run for a group reconciliation

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateComparisonRulesetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var createGroupReconciliationComparisonRulesetRequest = new CreateGroupReconciliationComparisonRulesetRequest(); // CreateGroupReconciliationComparisonRulesetRequest | The request containing the details of the ruleset (optional) 

            try
            {
                // [EXPERIMENTAL] CreateComparisonRuleset: Create a Group Reconciliation Comparison Ruleset
                GroupReconciliationComparisonRuleset result = apiInstance.CreateComparisonRuleset(createGroupReconciliationComparisonRulesetRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.CreateComparisonRuleset: " + e.Message );
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
 **createGroupReconciliationComparisonRulesetRequest** | [**CreateGroupReconciliationComparisonRulesetRequest**](CreateGroupReconciliationComparisonRulesetRequest.md)| The request containing the details of the ruleset | [optional] 

### Return type

[**GroupReconciliationComparisonRuleset**](GroupReconciliationComparisonRuleset.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The created comparison ruleset |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="creategroupreconciliationdefinition"></a>
# **CreateGroupReconciliationDefinition**
> GroupReconciliationDefinition CreateGroupReconciliationDefinition (CreateGroupReconciliationDefinitionRequest createGroupReconciliationDefinitionRequest = null)

[EXPERIMENTAL] CreateGroupReconciliationDefinition: Create Group Reconciliation Definition

Creates a Group Reconciliation Definition

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateGroupReconciliationDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var createGroupReconciliationDefinitionRequest = new CreateGroupReconciliationDefinitionRequest(); // CreateGroupReconciliationDefinitionRequest | The definition Group Reconciliation Definition details (optional) 

            try
            {
                // [EXPERIMENTAL] CreateGroupReconciliationDefinition: Create Group Reconciliation Definition
                GroupReconciliationDefinition result = apiInstance.CreateGroupReconciliationDefinition(createGroupReconciliationDefinitionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.CreateGroupReconciliationDefinition: " + e.Message );
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
 **createGroupReconciliationDefinitionRequest** | [**CreateGroupReconciliationDefinitionRequest**](CreateGroupReconciliationDefinitionRequest.md)| The definition Group Reconciliation Definition details | [optional] 

### Return type

[**GroupReconciliationDefinition**](GroupReconciliationDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The newly created Group Reconciliation Definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecomparisonruleset"></a>
# **DeleteComparisonRuleset**
> DeletedEntityResponse DeleteComparisonRuleset (string scope, string code)

[EXPERIMENTAL] DeleteComparisonRuleset: Deletes a particular Group Reconciliation Comparison Ruleset

The deletion will take effect from the reconciliation comparison ruleset deletion datetime.  i.e. will no longer exist at any asAt datetime after the asAt datetime of deletion.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteComparisonRulesetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | The scope of the specified comparison ruleset.
            var code = code_example;  // string | The code of the specified comparison ruleset. Together with the domain and scope this uniquely              identifies the reconciliation comparison ruleset.

            try
            {
                // [EXPERIMENTAL] DeleteComparisonRuleset: Deletes a particular Group Reconciliation Comparison Ruleset
                DeletedEntityResponse result = apiInstance.DeleteComparisonRuleset(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.DeleteComparisonRuleset: " + e.Message );
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
 **scope** | **string**| The scope of the specified comparison ruleset. | 
 **code** | **string**| The code of the specified comparison ruleset. Together with the domain and scope this uniquely              identifies the reconciliation comparison ruleset. | 

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
| **200** | The deleted entity metadata |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletegroupreconciliationdefinition"></a>
# **DeleteGroupReconciliationDefinition**
> DeletedEntityResponse DeleteGroupReconciliationDefinition (string scope, string code)

[EXPERIMENTAL] DeleteGroupReconciliationDefinition: Delete Group Reconciliation Definition

Delete the group reconciliation definition.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteGroupReconciliationDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | The scope of the group reconciliation definition to delete.
            var code = code_example;  // string | The code of the group reconciliation definition to delete. Together with the scope this uniquely identifies the group reconciliation definition to delete.

            try
            {
                // [EXPERIMENTAL] DeleteGroupReconciliationDefinition: Delete Group Reconciliation Definition
                DeletedEntityResponse result = apiInstance.DeleteGroupReconciliationDefinition(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.DeleteGroupReconciliationDefinition: " + e.Message );
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
 **scope** | **string**| The scope of the group reconciliation definition to delete. | 
 **code** | **string**| The code of the group reconciliation definition to delete. Together with the scope this uniquely identifies the group reconciliation definition to delete. | 

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
| **200** | The datetime that the group reconciliation definition was deleted |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcomparisonresult"></a>
# **GetComparisonResult**
> GroupReconciliationComparisonResult GetComparisonResult (string scope, string code, string resultId, DateTimeOffset? asAt = null)

[EXPERIMENTAL] GetComparisonResult: Get a single Group Reconciliation Comparison Result by scope and code.

Retrieves one Group Reconciliation Comparison Result by scope and code  with the prior validation that its related reconciliation definition exists.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetComparisonResultExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | The scope of the specified comparison result and its related reconciliation definition.
            var code = code_example;  // string | The code of the reconciliation definition that was used to produce the reconciliation result.
            var resultId = resultId_example;  // string | The code of the specified reconciliation result. Together with the domain and scope this uniquely              identifies the reconciliation comparison result. This value is also the same as the computed result hash based on property values.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the comparison result definition. Defaults to return              the latest version if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] GetComparisonResult: Get a single Group Reconciliation Comparison Result by scope and code.
                GroupReconciliationComparisonResult result = apiInstance.GetComparisonResult(scope, code, resultId, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.GetComparisonResult: " + e.Message );
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
 **scope** | **string**| The scope of the specified comparison result and its related reconciliation definition. | 
 **code** | **string**| The code of the reconciliation definition that was used to produce the reconciliation result. | 
 **resultId** | **string**| The code of the specified reconciliation result. Together with the domain and scope this uniquely              identifies the reconciliation comparison result. This value is also the same as the computed result hash based on property values. | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the comparison result definition. Defaults to return              the latest version if not specified. | [optional] 

### Return type

[**GroupReconciliationComparisonResult**](GroupReconciliationComparisonResult.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested comparison result |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcomparisonruleset"></a>
# **GetComparisonRuleset**
> GroupReconciliationComparisonRuleset GetComparisonRuleset (string scope, string code, DateTimeOffset? asAt = null)

[EXPERIMENTAL] GetComparisonRuleset: Get a single Group Reconciliation Comparison Ruleset by scope and code.

Retrieves one Group Reconciliation Comparison Ruleset by scope and code.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetComparisonRulesetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | The scope of the specified comparison ruleset.
            var code = code_example;  // string | The code of the specified comparison ruleset. Together with the domain and scope this uniquely              identifies the reconciliation comparison ruleset.
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the comparison ruleset definition. Defaults to return              the latest version of the definition if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] GetComparisonRuleset: Get a single Group Reconciliation Comparison Ruleset by scope and code.
                GroupReconciliationComparisonRuleset result = apiInstance.GetComparisonRuleset(scope, code, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.GetComparisonRuleset: " + e.Message );
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
 **scope** | **string**| The scope of the specified comparison ruleset. | 
 **code** | **string**| The code of the specified comparison ruleset. Together with the domain and scope this uniquely              identifies the reconciliation comparison ruleset. | 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the comparison ruleset definition. Defaults to return              the latest version of the definition if not specified. | [optional] 

### Return type

[**GroupReconciliationComparisonRuleset**](GroupReconciliationComparisonRuleset.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested comparison ruleset |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgroupreconciliationdefinition"></a>
# **GetGroupReconciliationDefinition**
> GroupReconciliationDefinition GetGroupReconciliationDefinition (string scope, string code, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null)

[EXPERIMENTAL] GetGroupReconciliationDefinition: Get group reconciliation definition

Retrieves a Group Reconciliation Definition by scope and code

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetGroupReconciliationDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | The scope of the group reconciliation definition to retrieve.
            var code = code_example;  // string | The code of the group reconciliation definition to retrieve. Together with the scope              this uniquely identifies the group reconciliation definition.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the group reconciliation definition. Defaults to the current LUSID system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the group reconciliation definition. Defaults to return the latest version of the portfolio group definition if not specified. (optional) 

            try
            {
                // [EXPERIMENTAL] GetGroupReconciliationDefinition: Get group reconciliation definition
                GroupReconciliationDefinition result = apiInstance.GetGroupReconciliationDefinition(scope, code, effectiveAt, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.GetGroupReconciliationDefinition: " + e.Message );
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
 **scope** | **string**| The scope of the group reconciliation definition to retrieve. | 
 **code** | **string**| The code of the group reconciliation definition to retrieve. Together with the scope              this uniquely identifies the group reconciliation definition. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to retrieve the group reconciliation definition. Defaults to the current LUSID system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the group reconciliation definition. Defaults to return the latest version of the portfolio group definition if not specified. | [optional] 

### Return type

[**GroupReconciliationDefinition**](GroupReconciliationDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested group reconciliation definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listcomparisonresults"></a>
# **ListComparisonResults**
> PagedResourceListOfGroupReconciliationComparisonResult ListComparisonResults (DateTimeOffset? asAt = null, string page = null, List<string> sortBy = null, int? limit = null, string filter = null)

[EXPERIMENTAL] ListComparisonResults: Get a set of Group Reconciliation Comparison Results.

Retrieves all Group Reconciliation Comparison Results that fit the filter, in a specific order if sortBy is provided.  Supports pagination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListComparisonResultsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the comparison results. Defaults to return the latest              version of the comparison results if not specified. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing comparison results from a previous call to list              comparison results. This value is returned from the previous call. If a pagination token is provided the sortBy,              filter, effectiveAt, and asAt fields must not have changed since the original request. (optional) 
            var sortBy = new List<string>(); // List<string> | A list of field names to sort by, each suffixed by \" ASC\" or \" DESC\". (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many per page. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here:              https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] ListComparisonResults: Get a set of Group Reconciliation Comparison Results.
                PagedResourceListOfGroupReconciliationComparisonResult result = apiInstance.ListComparisonResults(asAt, page, sortBy, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.ListComparisonResults: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the comparison results. Defaults to return the latest              version of the comparison results if not specified. | [optional] 
 **page** | **string**| The pagination token to use to continue listing comparison results from a previous call to list              comparison results. This value is returned from the previous call. If a pagination token is provided the sortBy,              filter, effectiveAt, and asAt fields must not have changed since the original request. | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| A list of field names to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot;. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many per page. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here:              https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**PagedResourceListOfGroupReconciliationComparisonResult**](PagedResourceListOfGroupReconciliationComparisonResult.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested list of comparison results |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listcomparisonrulesets"></a>
# **ListComparisonRulesets**
> PagedResourceListOfGroupReconciliationComparisonRuleset ListComparisonRulesets (DateTimeOffset? asAt = null, string page = null, List<string> sortBy = null, int? limit = null, string filter = null)

[EXPERIMENTAL] ListComparisonRulesets: Get a set of Group Reconciliation Comparison Rulesets

Retrieves all Group Reconciliation Comparison Ruleset that fit the filter, in a specific order if sortBy is provided  Supports pagination

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListComparisonRulesetsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the comparison rulesets. Defaults to return the latest              version of the comparison rulesets if not specified. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing comparison rulesets from a previous call to list              comparison rulesets. This value is returned from the previous call. If a pagination token is provided the sortBy,              filter, effectiveAt, and asAt fields must not have changed since the original request. (optional) 
            var sortBy = new List<string>(); // List<string> | A list of field names to sort by, each suffixed by \" ASC\" or \" DESC\" (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many per page. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here:              https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] ListComparisonRulesets: Get a set of Group Reconciliation Comparison Rulesets
                PagedResourceListOfGroupReconciliationComparisonRuleset result = apiInstance.ListComparisonRulesets(asAt, page, sortBy, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.ListComparisonRulesets: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the comparison rulesets. Defaults to return the latest              version of the comparison rulesets if not specified. | [optional] 
 **page** | **string**| The pagination token to use to continue listing comparison rulesets from a previous call to list              comparison rulesets. This value is returned from the previous call. If a pagination token is provided the sortBy,              filter, effectiveAt, and asAt fields must not have changed since the original request. | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| A list of field names to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many per page. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here:              https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**PagedResourceListOfGroupReconciliationComparisonRuleset**](PagedResourceListOfGroupReconciliationComparisonRuleset.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested list of comparison rulesets |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgroupreconciliationdefinitions"></a>
# **ListGroupReconciliationDefinitions**
> PagedResourceListOfGroupReconciliationDefinition ListGroupReconciliationDefinitions (DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, string page = null, int? limit = null, string filter = null, List<string> sortBy = null)

[EXPERIMENTAL] ListGroupReconciliationDefinitions: List group reconciliation definitions

Lists Group Reconciliation Definitions matching any provided filter, limit and sorting rules

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListGroupReconciliationDefinitionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to list the group reconciliation definitions. Defaults to the current LUSID system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to list the group reconciliation definitions. Defaults to return the latest version of each group reconciliation definition if not specified. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing group reconciliation definitions from a previous call to list group reconciliation definitions. This  value is returned from the previous call. If a pagination token is provided the filter, effectiveAt, sortBy  and asAt fields must not have changed since the original request. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. Defaults to no limit if not specified. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set.              For example, to filter on the Display Name, use \"displayName eq 'string'\"              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 
            var sortBy = new List<string>(); // List<string> | A list of field names to sort by, each suffixed by \" ASC\" or \" DESC\" (optional) 

            try
            {
                // [EXPERIMENTAL] ListGroupReconciliationDefinitions: List group reconciliation definitions
                PagedResourceListOfGroupReconciliationDefinition result = apiInstance.ListGroupReconciliationDefinitions(effectiveAt, asAt, page, limit, filter, sortBy);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.ListGroupReconciliationDefinitions: " + e.Message );
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
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to list the group reconciliation definitions. Defaults to the current LUSID system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to list the group reconciliation definitions. Defaults to return the latest version of each group reconciliation definition if not specified. | [optional] 
 **page** | **string**| The pagination token to use to continue listing group reconciliation definitions from a previous call to list group reconciliation definitions. This  value is returned from the previous call. If a pagination token is provided the filter, effectiveAt, sortBy  and asAt fields must not have changed since the original request. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. Defaults to no limit if not specified. | [optional] 
 **filter** | **string**| Expression to filter the result set.              For example, to filter on the Display Name, use \&quot;displayName eq &#39;string&#39;\&quot;              Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 
 **sortBy** | [**List&lt;string&gt;**](string.md)| A list of field names to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; | [optional] 

### Return type

[**PagedResourceListOfGroupReconciliationDefinition**](PagedResourceListOfGroupReconciliationDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The group reconciliation definition in the specified scope |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="runreconciliation"></a>
# **RunReconciliation**
> GroupReconciliationRunResponse RunReconciliation (string scope, string code, GroupReconciliationRunRequest groupReconciliationRunRequest = null)

[EXPERIMENTAL] RunReconciliation: Runs a Group Reconciliation

Runs a Group Reconciliation using the definition specified by the Finbourne.Identifiers.Abstractions.Scope and Finbourne.Identifiers.Abstractions.Code  Supports pagination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class RunReconciliationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | The scope of the group reconciliation definition to use for the reconciliation.
            var code = code_example;  // string | The code of the group reconciliation definition to use for the reconciliation.
            var groupReconciliationRunRequest = new GroupReconciliationRunRequest(); // GroupReconciliationRunRequest |  (optional) 

            try
            {
                // [EXPERIMENTAL] RunReconciliation: Runs a Group Reconciliation
                GroupReconciliationRunResponse result = apiInstance.RunReconciliation(scope, code, groupReconciliationRunRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.RunReconciliation: " + e.Message );
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
 **scope** | **string**| The scope of the group reconciliation definition to use for the reconciliation. | 
 **code** | **string**| The code of the group reconciliation definition to use for the reconciliation. | 
 **groupReconciliationRunRequest** | [**GroupReconciliationRunRequest**](GroupReconciliationRunRequest.md)|  | [optional] 

### Return type

[**GroupReconciliationRunResponse**](GroupReconciliationRunResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The results of the reconciliation run |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecomparisonruleset"></a>
# **UpdateComparisonRuleset**
> GroupReconciliationComparisonRuleset UpdateComparisonRuleset (string scope, string code, UpdateGroupReconciliationComparisonRulesetRequest updateGroupReconciliationComparisonRulesetRequest = null)

[EXPERIMENTAL] UpdateComparisonRuleset: Update Group Reconciliation Comparison Ruleset defined by scope and code

Overwrites an existing Group Reconciliation Comparison Ruleset  Update request has the same required fields as Create apart from the Id

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpdateComparisonRulesetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | The scope of the specified comparison ruleset.
            var code = code_example;  // string | The code of the specified comparison ruleset. Together with the domain and scope this uniquely                  identifies the reconciliation comparison ruleset.
            var updateGroupReconciliationComparisonRulesetRequest = new UpdateGroupReconciliationComparisonRulesetRequest(); // UpdateGroupReconciliationComparisonRulesetRequest | The request containing the updated details of the ruleset (optional) 

            try
            {
                // [EXPERIMENTAL] UpdateComparisonRuleset: Update Group Reconciliation Comparison Ruleset defined by scope and code
                GroupReconciliationComparisonRuleset result = apiInstance.UpdateComparisonRuleset(scope, code, updateGroupReconciliationComparisonRulesetRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.UpdateComparisonRuleset: " + e.Message );
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
 **scope** | **string**| The scope of the specified comparison ruleset. | 
 **code** | **string**| The code of the specified comparison ruleset. Together with the domain and scope this uniquely                  identifies the reconciliation comparison ruleset. | 
 **updateGroupReconciliationComparisonRulesetRequest** | [**UpdateGroupReconciliationComparisonRulesetRequest**](UpdateGroupReconciliationComparisonRulesetRequest.md)| The request containing the updated details of the ruleset | [optional] 

### Return type

[**GroupReconciliationComparisonRuleset**](GroupReconciliationComparisonRuleset.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The updated version of the requested comparison ruleset |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updategroupreconciliationdefinition"></a>
# **UpdateGroupReconciliationDefinition**
> GroupReconciliationDefinition UpdateGroupReconciliationDefinition (string scope, string code, UpdateGroupReconciliationDefinitionRequest updateGroupReconciliationDefinitionRequest = null)

[EXPERIMENTAL] UpdateGroupReconciliationDefinition: Update group reconciliation definition

Update the group reconciliation definition.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpdateGroupReconciliationDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupReconciliationsApi(config);
            var scope = scope_example;  // string | The scope of the group reconciliation definition to update the details for.
            var code = code_example;  // string | The code of the group reconciliation definition to update the details for. Together with the scope this uniquely identifies the group reconciliation definition.
            var updateGroupReconciliationDefinitionRequest = new UpdateGroupReconciliationDefinitionRequest(); // UpdateGroupReconciliationDefinitionRequest | The updated group reconciliation definition. (optional) 

            try
            {
                // [EXPERIMENTAL] UpdateGroupReconciliationDefinition: Update group reconciliation definition
                GroupReconciliationDefinition result = apiInstance.UpdateGroupReconciliationDefinition(scope, code, updateGroupReconciliationDefinitionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupReconciliationsApi.UpdateGroupReconciliationDefinition: " + e.Message );
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
 **scope** | **string**| The scope of the group reconciliation definition to update the details for. | 
 **code** | **string**| The code of the group reconciliation definition to update the details for. Together with the scope this uniquely identifies the group reconciliation definition. | 
 **updateGroupReconciliationDefinitionRequest** | [**UpdateGroupReconciliationDefinitionRequest**](UpdateGroupReconciliationDefinitionRequest.md)| The updated group reconciliation definition. | [optional] 

### Return type

[**GroupReconciliationDefinition**](GroupReconciliationDefinition.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The updated details of the group reconciliation definition |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

