# Lusid.Sdk.Api.FeesAndCommissionsApi

All URIs are relative to *http://local-unit-test-server.lusid.com:42525*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetApplicableFees**](FeesAndCommissionsApi.md#getapplicablefees) | **GET** /api/feesandcommissions | [EXPERIMENTAL] GetApplicableFees: Get the Fees and Commissions that may be applicable to a transaction.
[**ListAllFees**](FeesAndCommissionsApi.md#listallfees) | **GET** /api/feesandcommissions/rules | [EXPERIMENTAL] ListAllFees: List the rules available for fees and commissions.


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
            config.BasePath = "http://local-unit-test-server.lusid.com:42525";
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
            config.BasePath = "http://local-unit-test-server.lusid.com:42525";
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

