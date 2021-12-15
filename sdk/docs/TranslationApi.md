# Lusid.Sdk.Api.TranslationApi

All URIs are relative to *http://local-unit-test-server.lusid.com:40691*

Method | HTTP request | Description
------------- | ------------- | -------------
[**TranslateInstrumentDefinitions**](TranslationApi.md#translateinstrumentdefinitions) | **POST** /api/translation/instrumentdefinitions | [EXPERIMENTAL] TranslateInstrumentDefinitions: Translate instruments


<a name="translateinstrumentdefinitions"></a>
# **TranslateInstrumentDefinitions**
> TranslateInstrumentDefinitionsResponse TranslateInstrumentDefinitions (TranslateInstrumentDefinitionsRequest translateInstrumentDefinitionsRequest)

[EXPERIMENTAL] TranslateInstrumentDefinitions: Translate instruments

Translates one or more instruments into the given target dialect.                In the request each instrument definition should be keyed by a unique correlation id. This id is ephemeral  and is not stored by LUSID. It serves only as a way to easily identify each instrument in the response.                Any instrument that is not already in the LUSID dialect should be given as an ExoticInstrument.                The response will return both the collection of successfully translated instruments in the target dialect,  as well as those that failed.  For the failures a reason will be provided explaining why the instrument could not be updated or inserted.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class TranslateInstrumentDefinitionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://local-unit-test-server.lusid.com:40691";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TranslationApi(config);
            var translateInstrumentDefinitionsRequest = new TranslateInstrumentDefinitionsRequest(); // TranslateInstrumentDefinitionsRequest | The definitions of the instruments to translate along with the target dialect.

            try
            {
                // [EXPERIMENTAL] TranslateInstrumentDefinitions: Translate instruments
                TranslateInstrumentDefinitionsResponse result = apiInstance.TranslateInstrumentDefinitions(translateInstrumentDefinitionsRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TranslationApi.TranslateInstrumentDefinitions: " + e.Message );
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
 **translateInstrumentDefinitionsRequest** | [**TranslateInstrumentDefinitionsRequest**](TranslateInstrumentDefinitionsRequest.md)| The definitions of the instruments to translate along with the target dialect. | 

### Return type

[**TranslateInstrumentDefinitionsResponse**](TranslateInstrumentDefinitionsResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The successfully translated instruments along with any failures |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

