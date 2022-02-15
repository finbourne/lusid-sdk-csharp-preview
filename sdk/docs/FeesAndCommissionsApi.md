# Lusid.Sdk.Api.FeesAndCommissionsApi

All URIs are relative to *http://local-unit-test-server.lusid.com:42919*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetApplicableFees**](FeesAndCommissionsApi.md#getapplicablefees) | **GET** /api/feesandcommissions | [EXPERIMENTAL] GetApplicableFees: Get the Fees and Commissions that may be applicable to a transaction.
[**GetFeeRule**](FeesAndCommissionsApi.md#getfeerule) | **GET** /api/feesandcommissions/rules-dev/{code} | [EXPERIMENTAL] GetFeeRule: Retrieve the definition of single fee rule.
[**ListAllFees**](FeesAndCommissionsApi.md#listallfees) | **GET** /api/feesandcommissions/rules | [EXPERIMENTAL] ListAllFees: List the rules available for fees and commissions.
[**ListFeeRules**](FeesAndCommissionsApi.md#listfeerules) | **GET** /api/feesandcommissions/rules-dev | [EXPERIMENTAL] ListFeeRules: List fee rules, with optional filtering.
[**UpsertFeeRules**](FeesAndCommissionsApi.md#upsertfeerules) | **POST** /api/feesandcommissions/rules-dev | [EXPERIMENTAL] UpsertFeeRules: Upsert fee rules.


<a name="getapplicablefees"></a>
# **GetApplicableFees**
> ResourceListOfFeeCalculationDetails GetApplicableFees (string instrumentIdentifierType = null, string instrumentIdentifier = null, string portfolioScope = null, string portfolioCode = null, List<string> additionalSearchKeys = null, string fileName = null)

[EXPERIMENTAL] GetApplicableFees: Get the Fees and Commissions that may be applicable to a transaction.

Additionally, matching can be based on the instrument's properties, its portfolio properties, and any additional property keys present in the data file.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetApplicableFeesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:42919";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeesAndCommissionsApi(config);
            var instrumentIdentifierType = instrumentIdentifierType_example;  // string | Optional. The unique identifier type to use, eg 'Figi' or 'LusidInstrumentId'. (optional) 
            var instrumentIdentifier = instrumentIdentifier_example;  // string | Optional. The Instrument Identifier to get properties for. (optional) 
            var portfolioScope = portfolioScope_example;  // string | Optional. The scope of the portfolio to fetch additional properties from. (optional) 
            var portfolioCode = portfolioCode_example;  // string | Optional. The code of the portfolio to fetch additional properties from. (optional) 
            var additionalSearchKeys = new List<string>(); // List<string> | Any other property keys or fields and their corresponding values that should be matched for fees. Eg. \"Instrument/default/Name=exampleValue\" or \"AdditionalKey2=Value2\".              The list of fields available is as follows : \"RuleName\", \"Country\", \"FeeType\", \"FeeRate\", \"MinFee\", \"MaxFee\", \"PropertyKey\",               \"TransactionType\", \"Counterparty\", \"SettlementCurrency\", \"TransactionCurrency\", \"ExecutionBroker\",               \"Custodian\", \"Exchange\" (optional) 
            var fileName = fileName_example;  // string | Optionally provide the filename of an alternative to the default fees file ({fees.csv})              in your {fees-and-commissions} Drive folder, to support different fee structures.              For example, you might use one to understand the effect of different fees when considering a change in broker. (optional) 

            try
            {
                // [EXPERIMENTAL] GetApplicableFees: Get the Fees and Commissions that may be applicable to a transaction.
                ResourceListOfFeeCalculationDetails result = apiInstance.GetApplicableFees(instrumentIdentifierType, instrumentIdentifier, portfolioScope, portfolioCode, additionalSearchKeys, fileName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeesAndCommissionsApi.GetApplicableFees: " + e.Message );
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
 **instrumentIdentifierType** | **string**| Optional. The unique identifier type to use, eg &#39;Figi&#39; or &#39;LusidInstrumentId&#39;. | [optional] 
 **instrumentIdentifier** | **string**| Optional. The Instrument Identifier to get properties for. | [optional] 
 **portfolioScope** | **string**| Optional. The scope of the portfolio to fetch additional properties from. | [optional] 
 **portfolioCode** | **string**| Optional. The code of the portfolio to fetch additional properties from. | [optional] 
 **additionalSearchKeys** | [**List&lt;string&gt;**](string.md)| Any other property keys or fields and their corresponding values that should be matched for fees. Eg. \&quot;Instrument/default/Name&#x3D;exampleValue\&quot; or \&quot;AdditionalKey2&#x3D;Value2\&quot;.              The list of fields available is as follows : \&quot;RuleName\&quot;, \&quot;Country\&quot;, \&quot;FeeType\&quot;, \&quot;FeeRate\&quot;, \&quot;MinFee\&quot;, \&quot;MaxFee\&quot;, \&quot;PropertyKey\&quot;,               \&quot;TransactionType\&quot;, \&quot;Counterparty\&quot;, \&quot;SettlementCurrency\&quot;, \&quot;TransactionCurrency\&quot;, \&quot;ExecutionBroker\&quot;,               \&quot;Custodian\&quot;, \&quot;Exchange\&quot; | [optional] 
 **fileName** | **string**| Optionally provide the filename of an alternative to the default fees file ({fees.csv})              in your {fees-and-commissions} Drive folder, to support different fee structures.              For example, you might use one to understand the effect of different fees when considering a change in broker. | [optional] 

### Return type

[**ResourceListOfFeeCalculationDetails**](ResourceListOfFeeCalculationDetails.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The List of applicable fee calculations details |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfeerule"></a>
# **GetFeeRule**
> FeeRule GetFeeRule (string code, DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null)

[EXPERIMENTAL] GetFeeRule: Retrieve the definition of single fee rule.

Retrieves the fee rule definition at the given effective and as at times.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetFeeRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:42919";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeesAndCommissionsApi(config);
            var code = code_example;  // string | The fee rule code.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. (optional) 

            try
            {
                // [EXPERIMENTAL] GetFeeRule: Retrieve the definition of single fee rule.
                FeeRule result = apiInstance.GetFeeRule(code, effectiveAt, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeesAndCommissionsApi.GetFeeRule: " + e.Message );
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
 **code** | **string**| The fee rule code. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label at which to retrieve the rule definition. Defaults to the current LUSID  system datetime if not specified. | [optional] 
 **asAt** | **DateTimeOffset?**| The asAt datetime at which to retrieve the rule definition. Defaults to returning the latest version if not  specified. | [optional] 

### Return type

[**FeeRule**](FeeRule.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Details of one fee rule. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listallfees"></a>
# **ListAllFees**
> ResourceListOfFeeCalculationDetails ListAllFees (List<string> additionalSearchKeys = null, string fileName = null)

[EXPERIMENTAL] ListAllFees: List the rules available for fees and commissions.

By default, will list ALL rules available. Additional keys and be specified to list a smaller subset of rules.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListAllFeesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:42919";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeesAndCommissionsApi(config);
            var additionalSearchKeys = new List<string>(); // List<string> | Any other property keys or fields and their corresponding values that should be matched to reduce the list of rules returned. Eg. \"Instrument/default/Name=exampleValue\" or \"AdditionalKey2=Value2\".              The minimum list of fields available is as follows : \"RuleName\", \"Country\", \"FeeCalculationMethod\", \"FeeMultiplier\", \"MinFeeCalculationMethod\",              \"MinFeeMultiplier\", \"MaxFeeCalculationMethod\", \"MaxFeeMultiplier\", \"PropertyKey\",              \"TransactionType\", \"Counterparty\", \"SettlementCurrency\", \"TransactionCurrency\", \"ExecutionBroker\",              \"Custodian\", \"Exchange\" (optional) 
            var fileName = fileName_example;  // string | Optionally provide the filename of an alternative to the default fees file ({fees.csv})              in your Drive {fees-and-commissions} folder, to support different fee structures.              For example, you might use one to understand the effect of different fees when considering a change in broker. (optional) 

            try
            {
                // [EXPERIMENTAL] ListAllFees: List the rules available for fees and commissions.
                ResourceListOfFeeCalculationDetails result = apiInstance.ListAllFees(additionalSearchKeys, fileName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeesAndCommissionsApi.ListAllFees: " + e.Message );
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
 **additionalSearchKeys** | [**List&lt;string&gt;**](string.md)| Any other property keys or fields and their corresponding values that should be matched to reduce the list of rules returned. Eg. \&quot;Instrument/default/Name&#x3D;exampleValue\&quot; or \&quot;AdditionalKey2&#x3D;Value2\&quot;.              The minimum list of fields available is as follows : \&quot;RuleName\&quot;, \&quot;Country\&quot;, \&quot;FeeCalculationMethod\&quot;, \&quot;FeeMultiplier\&quot;, \&quot;MinFeeCalculationMethod\&quot;,              \&quot;MinFeeMultiplier\&quot;, \&quot;MaxFeeCalculationMethod\&quot;, \&quot;MaxFeeMultiplier\&quot;, \&quot;PropertyKey\&quot;,              \&quot;TransactionType\&quot;, \&quot;Counterparty\&quot;, \&quot;SettlementCurrency\&quot;, \&quot;TransactionCurrency\&quot;, \&quot;ExecutionBroker\&quot;,              \&quot;Custodian\&quot;, \&quot;Exchange\&quot; | [optional] 
 **fileName** | **string**| Optionally provide the filename of an alternative to the default fees file ({fees.csv})              in your Drive {fees-and-commissions} folder, to support different fee structures.              For example, you might use one to understand the effect of different fees when considering a change in broker. | [optional] 

### Return type

[**ResourceListOfFeeCalculationDetails**](ResourceListOfFeeCalculationDetails.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The List of all fee and commission rules available |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listfeerules"></a>
# **ListFeeRules**
> ResourceListOfFeeRule ListFeeRules (DateTimeOrCutLabel effectiveAt = null, DateTimeOffset? asAt = null, int? limit = null, string filter = null, string page = null)

[EXPERIMENTAL] ListFeeRules: List fee rules, with optional filtering.

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
    public class ListFeeRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:42919";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeesAndCommissionsApi(config);
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label at which to retrieve the rule definitions. Defaults to the current LUSID  system datetime if not specified. (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The asAt datetime at which to retrieve the rule definitions. Defaults to returning the latest version if not  specified. (optional) 
            var limit = 56;  // int? | When paginating, limit the results to this number. Defaults to 100 if not specified. (optional) 
            var filter = filter_example;  // string | Expression to filter the results. (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing entities; this value is returned from the previous call. If  a pagination token is provided, the filter, effectiveAt and asAt fields must not have changed since the  original request. (optional) 

            try
            {
                // [EXPERIMENTAL] ListFeeRules: List fee rules, with optional filtering.
                ResourceListOfFeeRule result = apiInstance.ListFeeRules(effectiveAt, asAt, limit, filter, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeesAndCommissionsApi.ListFeeRules: " + e.Message );
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

[**ResourceListOfFeeRule**](ResourceListOfFeeRule.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A filtered list of fee rules available. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="upsertfeerules"></a>
# **UpsertFeeRules**
> FeeRuleUpsertResponse UpsertFeeRules (Dictionary<string, FeeRuleUpsertRequest> requestBody, DateTimeOrCutLabel effectiveAt = null)

[EXPERIMENTAL] UpsertFeeRules: Upsert fee rules.

To upsert a new rule, the code field must be left empty, a code will then be assigned and returned as part  of the response. To update an existing rule, include the fee code. It is possible to both create and update  fee rules in the same request.                The upsert is transactional - either all create/update operations will succeed or none of them will.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpsertFeeRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:42919";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FeesAndCommissionsApi(config);
            var requestBody = new Dictionary<string, FeeRuleUpsertRequest>(); // Dictionary<string, FeeRuleUpsertRequest> | A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted fee rule to the code of a               created fee rule.
            var effectiveAt = effectiveAt_example;  // DateTimeOrCutLabel | The effective datetime or cut label for rule to begin to be effective from. Defaults to the current LUSID  system datetime if not specified. In the case of updates, the update rule will be valid from this time until  the next upserted effective from time. For example, if a rule is due to change from the first of the next  month, values upserted effective from the current time will only be valid until the end of the month, after  which the scheduled changes will take over, as they were due to before this latest upsert. (optional) 

            try
            {
                // [EXPERIMENTAL] UpsertFeeRules: Upsert fee rules.
                FeeRuleUpsertResponse result = apiInstance.UpsertFeeRules(requestBody, effectiveAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FeesAndCommissionsApi.UpsertFeeRules: " + e.Message );
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
 **requestBody** | [**Dictionary&lt;string, FeeRuleUpsertRequest&gt;**](FeeRuleUpsertRequest.md)| A dictionary of upsert request identifiers to rule upsert requests. The request               identifiers are valid for the request only and can be used to link the upserted fee rule to the code of a               created fee rule. | 
 **effectiveAt** | **DateTimeOrCutLabel**| The effective datetime or cut label for rule to begin to be effective from. Defaults to the current LUSID  system datetime if not specified. In the case of updates, the update rule will be valid from this time until  the next upserted effective from time. For example, if a rule is due to change from the first of the next  month, values upserted effective from the current time will only be valid until the end of the month, after  which the scheduled changes will take over, as they were due to before this latest upsert. | [optional] 

### Return type

[**FeeRuleUpsertResponse**](FeeRuleUpsertResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Upsert fee rules. New fee rules must have an empty code field. Where a code is given, this rule must already exist and will be updated. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

