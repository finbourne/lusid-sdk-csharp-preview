# Lusid.Sdk.Api.ComplianceApi

All URIs are relative to *http://local-unit-test-server.lusid.com:34427*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteComplianceRule**](ComplianceApi.md#deletecompliancerule) | **DELETE** /api/compliance/rules/{scope}/{code} | [EXPERIMENTAL] DeleteComplianceRule: Deletes a compliance rule.
[**GetComplianceRule**](ComplianceApi.md#getcompliancerule) | **GET** /api/compliance/rules/{scope}/{code} | [EXPERIMENTAL] GetComplianceRule: Retrieve the definition of single compliance rule.
[**GetComplianceRun**](ComplianceApi.md#getcompliancerun) | **GET** /api/compliance/{runId} | [EXPERIMENTAL] GetComplianceRun: Get the details of a single compliance run. - - DEPRECATING - POST TRADE ONLY
[**GetComplianceRunResults**](ComplianceApi.md#getcompliancerunresults) | **GET** /api/compliance/results/{runId} | [EXPERIMENTAL] GetComplianceRunResults: Get the details of a single compliance run.
[**ListComplianceRules**](ComplianceApi.md#listcompliancerules) | **GET** /api/compliance/rules | [EXPERIMENTAL] ListComplianceRules: List compliance rules, with optional filtering.
[**ListComplianceRuns**](ComplianceApi.md#listcomplianceruns) | **GET** /api/compliance | [EXPERIMENTAL] ListComplianceRuns: List historical compliance runs. - - DEPRECATING - POST TRADE ONLY
[**RunComplianceCheck**](ComplianceApi.md#runcompliancecheck) | **POST** /api/compliance/run | [EXPERIMENTAL] RunComplianceCheck: Kick off the compliance check process - - DEPRECATING - POST TRADE ONLY
[**UpsertComplianceRules**](ComplianceApi.md#upsertcompliancerules) | **POST** /api/compliance/rules | [EXPERIMENTAL] UpsertComplianceRules: Upsert compliance rules.


<a name="deletecompliancerule"></a>
# **DeleteComplianceRule**
> DeletedEntityResponse DeleteComplianceRule (string scope, string code)

[EXPERIMENTAL] DeleteComplianceRule: Deletes a compliance rule.

Deletes the rule for all effective time.                The rule will remain viewable at previous as at times, and as part of the results of compliance runs, but it  will no longer be considered in new compliance runs.                This cannot be undone.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteComplianceRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:34427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ComplianceApi(config);
            var scope = scope_example;  // string | The compliance rule scope.
            var code = code_example;  // string | The compliance rule code.

            try
            {
                // [EXPERIMENTAL] DeleteComplianceRule: Deletes a compliance rule.
                DeletedEntityResponse result = apiInstance.DeleteComplianceRule(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComplianceApi.DeleteComplianceRule: " + e.Message );
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
 **scope** | **string**| The compliance rule scope. | 
 **code** | **string**| The compliance rule code. | 

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

<a name="getcompliancerule"></a>
# **GetComplianceRule**
> ComplianceRule GetComplianceRule (string scope, string code, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null)

[EXPERIMENTAL] GetComplianceRule: Retrieve the definition of single compliance rule.

Retrieves the compliance rule definition at the given effective and as at times.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetComplianceRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:34427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ComplianceApi(config);
            var scope = scope_example;  // string | The compliance rule scope.
            var code = code_example;  // string | The compliance rule code.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional) 

            try
            {
                // [EXPERIMENTAL] GetComplianceRule: Retrieve the definition of single compliance rule.
                ComplianceRule result = apiInstance.GetComplianceRule(scope, code, effectiveAt, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComplianceApi.GetComplianceRule: " + e.Message );
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
 **scope** | **string**| The compliance rule scope. | 
 **code** | **string**| The compliance rule code. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. | [optional] 

### Return type

[**ComplianceRule**](ComplianceRule.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Details of one compliance rule. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcompliancerun"></a>
# **GetComplianceRun**
> ResourceListOfComplianceRuleResult GetComplianceRun (string runId, string page = null, int? limit = null, string filter = null)

[EXPERIMENTAL] GetComplianceRun: Get the details of a single compliance run. - - DEPRECATING - POST TRADE ONLY

Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetComplianceRunExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:34427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ComplianceApi(config);
            var runId = runId_example;  // string | The unique identifier of the compliance run requested.
            var page = page_example;  // string | The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] GetComplianceRun: Get the details of a single compliance run. - - DEPRECATING - POST TRADE ONLY
                ResourceListOfComplianceRuleResult result = apiInstance.GetComplianceRun(runId, page, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComplianceApi.GetComplianceRun: " + e.Message );
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
 **runId** | **string**| The unique identifier of the compliance run requested. | 
 **page** | **string**| The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**ResourceListOfComplianceRuleResult**](ResourceListOfComplianceRuleResult.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The details of a specific compliance run |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcompliancerunresults"></a>
# **GetComplianceRunResults**
> ResourceListOfComplianceRuleResult GetComplianceRunResults (string runId, string page = null, int? limit = null)

[EXPERIMENTAL] GetComplianceRunResults: Get the details of a single compliance run.

Use this endpoint to fetch the detail associated with a specific compliance run, including a breakdown  of the passing state of each rule, portfolio combination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetComplianceRunResultsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:34427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ComplianceApi(config);
            var runId = runId_example;  // string | The unique identifier of the compliance run requested.
            var page = page_example;  // string | The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 

            try
            {
                // [EXPERIMENTAL] GetComplianceRunResults: Get the details of a single compliance run.
                ResourceListOfComplianceRuleResult result = apiInstance.GetComplianceRunResults(runId, page, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComplianceApi.GetComplianceRunResults: " + e.Message );
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
 **runId** | **string**| The unique identifier of the compliance run requested. | 
 **page** | **string**| The pagination token to use to continue listing compliance rule results from a previous call to list compliance rule result.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 

### Return type

[**ResourceListOfComplianceRuleResult**](ResourceListOfComplianceRuleResult.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The rule results of a specific compliance run |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listcompliancerules"></a>
# **ListComplianceRules**
> ResourceListOfComplianceRule ListComplianceRules (DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, int? limit = null, string filter = null, string page = null)

[EXPERIMENTAL] ListComplianceRules: List compliance rules, with optional filtering.

For more information about filtering results,  see https://support.lusid.com/knowledgebase/article/KA-01914.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListComplianceRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:34427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ComplianceApi(config);
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional) 
            var limit = 56;  // int? | When paginating, limit the results to this number. Defaults to 100 if not specified. (optional) 
            var filter = filter_example;  // string | Expression to filter the results. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional) 

            try
            {
                // [EXPERIMENTAL] ListComplianceRules: List compliance rules, with optional filtering.
                ResourceListOfComplianceRule result = apiInstance.ListComplianceRules(effectiveAt, asAt, limit, filter, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComplianceApi.ListComplianceRules: " + e.Message );
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
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. | [optional] 
 **limit** | **int?**| When paginating, limit the results to this number. Defaults to 100 if not specified. | [optional] 
 **filter** | **string**| Expression to filter the results. | [optional] 
 **page** | **string**| The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. | [optional] 

### Return type

[**ResourceListOfComplianceRule**](ResourceListOfComplianceRule.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A filtered list of compliance rules available. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listcomplianceruns"></a>
# **ListComplianceRuns**
> ResourceListOfComplianceRun ListComplianceRuns (string page = null, int? limit = null, string filter = null)

[EXPERIMENTAL] ListComplianceRuns: List historical compliance runs. - - DEPRECATING - POST TRADE ONLY

Use this endpoint to fetch a list of all historical compliance runs.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListComplianceRunsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:34427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ComplianceApi(config);
            var page = page_example;  // string | The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [EXPERIMENTAL] ListComplianceRuns: List historical compliance runs. - - DEPRECATING - POST TRADE ONLY
                ResourceListOfComplianceRun result = apiInstance.ListComplianceRuns(page, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComplianceApi.ListComplianceRuns: " + e.Message );
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
 **page** | **string**| The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**ResourceListOfComplianceRun**](ResourceListOfComplianceRun.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The List of all compliance runs completed |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="runcompliancecheck"></a>
# **RunComplianceCheck**
> ComplianceRun RunComplianceCheck (string fileName)

[EXPERIMENTAL] RunComplianceCheck: Kick off the compliance check process - - DEPRECATING - POST TRADE ONLY

Use this endpoint to fetch the start a compliance run, based on a pre-set mapping file.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class RunComplianceCheckExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:34427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ComplianceApi(config);
            var fileName = fileName_example;  // string | The name of compliance mappings file to use. Has to exist in drive ComplianceRules folder

            try
            {
                // [EXPERIMENTAL] RunComplianceCheck: Kick off the compliance check process - - DEPRECATING - POST TRADE ONLY
                ComplianceRun result = apiInstance.RunComplianceCheck(fileName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComplianceApi.RunComplianceCheck: " + e.Message );
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
 **fileName** | **string**| The name of compliance mappings file to use. Has to exist in drive ComplianceRules folder | 

### Return type

[**ComplianceRun**](ComplianceRun.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The identifying information of a compliance run |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="upsertcompliancerules"></a>
# **UpsertComplianceRules**
> ComplianceRuleUpsertResponse UpsertComplianceRules (Dictionary<string, ComplianceRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = null)

[EXPERIMENTAL] UpsertComplianceRules: Upsert compliance rules.

To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the rule code. It is possible to both create and update  compliance rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertComplianceRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:34427";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ComplianceApi(config);
            var requestBody = new Dictionary<string, ComplianceRuleUpsertRequest>(); // Dictionary<string, ComplianceRuleUpsertRequest> | A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. (optional) 

            try
            {
                // [EXPERIMENTAL] UpsertComplianceRules: Upsert compliance rules.
                ComplianceRuleUpsertResponse result = apiInstance.UpsertComplianceRules(requestBody, effectiveAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComplianceApi.UpsertComplianceRules: " + e.Message );
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
 **requestBody** | [**Dictionary&lt;string, ComplianceRuleUpsertRequest&gt;**](ComplianceRuleUpsertRequest.md)| A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted compliance rule to the code               of a created compliance rule. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which the rule will take effect. Defaults to the current LUSID  system datetime if not specified. In the case of an update, the changes will take place from this effective  time until the next effective time that the rule as been upserted at. For example, consider a rule that  already exists, and has previously had an update applied so that the definition will change on the first day  of the coming month. An upsert effective from the current day will only change the definition until the  first day of the coming month. An additional upsert at the same time (first day of the month) is required  if the newly-updated definition is to supersede the future definition. | [optional] 

### Return type

[**ComplianceRuleUpsertResponse**](ComplianceRuleUpsertResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Upsert compliance rules. New compliance rules must have an empty code field. Where a codeis given, this rule must already exist and will be updated. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

