# Lusid.Sdk.Api.AllocationServiceApi

All URIs are relative to *https://www.lusid.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RunAllocationService**](AllocationServiceApi.md#runallocationservice) | **POST** /api/allocationservice/allocate | [EXPERIMENTAL] RunAllocationService: Runs the Allocation Service


<a name="runallocationservice"></a>
# **RunAllocationService**
> AllocationServiceRunResult RunAllocationService (List<ResourceId> resourceId, string allocationAlgorithm = null)

[EXPERIMENTAL] RunAllocationService: Runs the Allocation Service

This will allocate executions for a given list of placements back to their originating orders.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class RunAllocationServiceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AllocationServiceApi(config);
            var resourceId = new List<ResourceId>(); // List<ResourceId> | The List of Placement IDs for which you wish to allocate executions.
            var allocationAlgorithm = allocationAlgorithm_example;  // string | A string representation of the allocation algorithm you would like to use to allocate shares from executions e.g. \"PR-FIFO\".  This defaults to \"PR-FIFO\". (optional) 

            try
            {
                // [EXPERIMENTAL] RunAllocationService: Runs the Allocation Service
                AllocationServiceRunResult result = apiInstance.RunAllocationService(resourceId, allocationAlgorithm);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AllocationServiceApi.RunAllocationService: " + e.Message );
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
 **resourceId** | [**List&lt;ResourceId&gt;**](ResourceId.md)| The List of Placement IDs for which you wish to allocate executions. | 
 **allocationAlgorithm** | **string**| A string representation of the allocation algorithm you would like to use to allocate shares from executions e.g. \&quot;PR-FIFO\&quot;.  This defaults to \&quot;PR-FIFO\&quot;. | [optional] 

### Return type

[**AllocationServiceRunResult**](AllocationServiceRunResult.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The results from a run of the Allocation Service |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

