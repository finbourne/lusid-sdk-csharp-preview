# Lusid.Sdk.Api.CalendarsApi

All URIs are relative to *https://fbn-prd.lusid.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddBusinessDaysToDate**](CalendarsApi.md#addbusinessdaystodate) | **POST** /api/calendars/businessday/{scope}/add | [EXPERIMENTAL] Adds the requested number of Business Days to the provided date.
[**AddDateToCalendar**](CalendarsApi.md#adddatetocalendar) | **PUT** /api/calendars/generic/{scope}/{code}/dates | [BETA] Add a date to a calendar
[**CreateCalendar**](CalendarsApi.md#createcalendar) | **POST** /api/calendars/generic | [BETA] Create a calendar in its generic form
[**DeleteCalendar**](CalendarsApi.md#deletecalendar) | **DELETE** /api/calendars/generic/{scope}/{code} | [BETA] Delete a calendar
[**DeleteDateFromCalendar**](CalendarsApi.md#deletedatefromcalendar) | **DELETE** /api/calendars/generic/{scope}/{code}/dates/{dateId} | [BETA] Remove a date from a calendar
[**GenerateSchedule**](CalendarsApi.md#generateschedule) | **POST** /api/calendars/schedule/{scope} | [EXPERIMENTAL] Generate an ordered schedule of dates.
[**GetCalendar**](CalendarsApi.md#getcalendar) | **GET** /api/calendars/generic/{scope}/{code} | [BETA] Get a calendar in its generic form
[**GetDates**](CalendarsApi.md#getdates) | **GET** /api/calendars/generic/{scope}/{code}/dates | [BETA] Get dates for a specific calendar
[**IsBusinessDateTime**](CalendarsApi.md#isbusinessdatetime) | **GET** /api/calendars/businessday/{scope}/{code} | [BETA] Check whether a DateTime is a \&quot;Business DateTime\&quot;
[**ListCalendars**](CalendarsApi.md#listcalendars) | **GET** /api/calendars/generic | [BETA] List Calenders
[**ListCalendarsInScope**](CalendarsApi.md#listcalendarsinscope) | **GET** /api/calendars/generic/{scope} | [BETA] List all calenders in a specified scope
[**UpdateCalendar**](CalendarsApi.md#updatecalendar) | **POST** /api/calendars/generic/{scope}/{code} | [BETA] Update a calendar



## AddBusinessDaysToDate

> AddBusinessDaysToDateResponse AddBusinessDaysToDate (string scope, AddBusinessDaysToDateRequest addBusinessDaysToDateRequest)

[EXPERIMENTAL] Adds the requested number of Business Days to the provided date.

A Business day is defined as a point in time that:      * Does not represent a day in the calendar's weekend      * Does not represent a day in the calendar's list of holidays (e.g. Christmas Day in the UK)                 All dates specified must be UTC and the upper bound of a calendar is not inclusive                 e.g. From: 2020-12-24-00-00-00:       Adding 3 business days returns 2020-12-30, assuming Saturday and Sunday are weekends, and the 25th and 28th are holidays.       Adding -2 business days returns 2020-12-22 under the same assumptions.                If the provided number of days to add is zero, returns a failure.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class AddBusinessDaysToDateExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope within which to search for the calendars
            var addBusinessDaysToDateRequest = new AddBusinessDaysToDateRequest(); // AddBusinessDaysToDateRequest | Request Details: start date, number of days to add (which can be negative, but not zero), calendar codes and optionally an AsAt date for searching the calendar store

            try
            {
                // [EXPERIMENTAL] Adds the requested number of Business Days to the provided date.
                AddBusinessDaysToDateResponse result = apiInstance.AddBusinessDaysToDate(scope, addBusinessDaysToDateRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.AddBusinessDaysToDate: " + e.Message );
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
 **scope** | **string**| Scope within which to search for the calendars | 
 **addBusinessDaysToDateRequest** | [**AddBusinessDaysToDateRequest**](AddBusinessDaysToDateRequest.md)| Request Details: start date, number of days to add (which can be negative, but not zero), calendar codes and optionally an AsAt date for searching the calendar store | 

### Return type

[**AddBusinessDaysToDateResponse**](AddBusinessDaysToDateResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The business day that is a number of business days after the given date as determined by the given calendar codes |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## AddDateToCalendar

> CalendarDate AddDateToCalendar (string scope, string code, CreateDateRequest createDateRequest)

[BETA] Add a date to a calendar

Add an event to the calendar. These Events can be a maximum of 24 hours and must be specified in UTC.  A local date will be calculated by the system and applied to the calendar before processing.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class AddDateToCalendarExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the calendar
            var code = code_example;  // string | Code of the calendar
            var createDateRequest = new CreateDateRequest(); // CreateDateRequest | Add date to calendar request

            try
            {
                // [BETA] Add a date to a calendar
                CalendarDate result = apiInstance.AddDateToCalendar(scope, code, createDateRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.AddDateToCalendar: " + e.Message );
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
 **scope** | **string**| Scope of the calendar | 
 **code** | **string**| Code of the calendar | 
 **createDateRequest** | [**CreateDateRequest**](CreateDateRequest.md)| Add date to calendar request | 

### Return type

[**CalendarDate**](CalendarDate.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The created date |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## CreateCalendar

> Calendar CreateCalendar (CreateCalendarRequest createCalendarRequest)

[BETA] Create a calendar in its generic form

Create a calendar in a generic form which can be used to store date events.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class CreateCalendarExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var createCalendarRequest = new CreateCalendarRequest(); // CreateCalendarRequest | A request to create the calendar

            try
            {
                // [BETA] Create a calendar in its generic form
                Calendar result = apiInstance.CreateCalendar(createCalendarRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.CreateCalendar: " + e.Message );
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
 **createCalendarRequest** | [**CreateCalendarRequest**](CreateCalendarRequest.md)| A request to create the calendar | 

### Return type

[**Calendar**](Calendar.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The created calendar |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteCalendar

> Calendar DeleteCalendar (string scope, string code)

[BETA] Delete a calendar

Delete a calendar and all of its respective dates

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteCalendarExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the calendar
            var code = code_example;  // string | Code of the calendar

            try
            {
                // [BETA] Delete a calendar
                Calendar result = apiInstance.DeleteCalendar(scope, code);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.DeleteCalendar: " + e.Message );
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
 **scope** | **string**| Scope of the calendar | 
 **code** | **string**| Code of the calendar | 

### Return type

[**Calendar**](Calendar.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The deleted calendar |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteDateFromCalendar

> CalendarDate DeleteDateFromCalendar (string scope, string code, string dateId)

[BETA] Remove a date from a calendar

Remove a date from a calendar.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class DeleteDateFromCalendarExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the calendar
            var code = code_example;  // string | Code of the calendar
            var dateId = dateId_example;  // string | Identifier of the date to be removed

            try
            {
                // [BETA] Remove a date from a calendar
                CalendarDate result = apiInstance.DeleteDateFromCalendar(scope, code, dateId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.DeleteDateFromCalendar: " + e.Message );
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
 **scope** | **string**| Scope of the calendar | 
 **code** | **string**| Code of the calendar | 
 **dateId** | **string**| Identifier of the date to be removed | 

### Return type

[**CalendarDate**](CalendarDate.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The deleted date |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GenerateSchedule

> ICollection&lt;DateTimeOffset?&gt; GenerateSchedule (string scope, ValuationSchedule valuationSchedule, DateTimeOffset? asAt = null)

[EXPERIMENTAL] Generate an ordered schedule of dates.

Returns an ordered array of dates. The dates will only fall on business  days as defined by the scope and calendar codes in the valuation schedule.                Valuations are made at a frequency defined by the valuation schedule's tenor, e.g. every day (\"1D\"),  every other week (\"2W\") etc. These dates will be adjusted onto business days as defined by the schedule's  rollConvention.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GenerateScheduleExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the calendars to use
            var valuationSchedule = new ValuationSchedule(); // ValuationSchedule | The ValuationSchedule to generate schedule dates from
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | Optional AsAt for searching the calendar store. Defaults to Latest. (optional) 

            try
            {
                // [EXPERIMENTAL] Generate an ordered schedule of dates.
                ICollection<DateTimeOffset?> result = apiInstance.GenerateSchedule(scope, valuationSchedule, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.GenerateSchedule: " + e.Message );
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
 **scope** | **string**| Scope of the calendars to use | 
 **valuationSchedule** | [**ValuationSchedule**](ValuationSchedule.md)| The ValuationSchedule to generate schedule dates from | 
 **asAt** | **DateTimeOffset?**| Optional AsAt for searching the calendar store. Defaults to Latest. | [optional] 

### Return type

**ICollection<DateTimeOffset?>**

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | An array of dates in chronological order. |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetCalendar

> Calendar GetCalendar (string scope, string code, DateTimeOffset? asAt = null)

[BETA] Get a calendar in its generic form

Retrieve a generic calendar by a specific ID at a point in AsAt time

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetCalendarExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the calendar identifier
            var code = code_example;  // string | Code of the calendar identifier
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The AsAt datetime at which to retrieve the calendar (optional) 

            try
            {
                // [BETA] Get a calendar in its generic form
                Calendar result = apiInstance.GetCalendar(scope, code, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.GetCalendar: " + e.Message );
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
 **scope** | **string**| Scope of the calendar identifier | 
 **code** | **string**| Code of the calendar identifier | 
 **asAt** | **DateTimeOffset?**| The AsAt datetime at which to retrieve the calendar | [optional] 

### Return type

[**Calendar**](Calendar.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested calendar |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetDates

> ResourceListOfCalendarDate GetDates (string scope, string code, DateTimeOrCutLabel fromEffectiveAt = null, DateTimeOrCutLabel toEffectiveAt = null, DateTimeOffset? asAt = null, List<string> idFilter = null)

[BETA] Get dates for a specific calendar

Get dates from a specific calendar within a specific window of effective time, at a point in AsAt time.  Providing an id filter can further refine the results.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class GetDatesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the calendar
            var code = code_example;  // string | Code of the calendar
            var fromEffectiveAt = fromEffectiveAt_example;  // DateTimeOrCutLabel | Where the effective window of dates should begin from (optional) 
            var toEffectiveAt = toEffectiveAt_example;  // DateTimeOrCutLabel | Where the effective window of dates should end (optional) 
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | AsAt the dates should be retrieved at (optional) 
            var idFilter = new List<string>(); // List<string> | An additional filter that will filter dates based on their identifer (optional) 

            try
            {
                // [BETA] Get dates for a specific calendar
                ResourceListOfCalendarDate result = apiInstance.GetDates(scope, code, fromEffectiveAt, toEffectiveAt, asAt, idFilter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.GetDates: " + e.Message );
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
 **scope** | **string**| Scope of the calendar | 
 **code** | **string**| Code of the calendar | 
 **fromEffectiveAt** | **DateTimeOrCutLabel**| Where the effective window of dates should begin from | [optional] 
 **toEffectiveAt** | **DateTimeOrCutLabel**| Where the effective window of dates should end | [optional] 
 **asAt** | **DateTimeOffset?**| AsAt the dates should be retrieved at | [optional] 
 **idFilter** | [**List&lt;string&gt;**](string.md)| An additional filter that will filter dates based on their identifer | [optional] 

### Return type

[**ResourceListOfCalendarDate**](ResourceListOfCalendarDate.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested date |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## IsBusinessDateTime

> IsBusinessDayResponse IsBusinessDateTime (DateTimeOffset? dateTime, string scope, string code, DateTimeOffset? asAt = null)

[BETA] Check whether a DateTime is a \"Business DateTime\"

A Business DateTime is defined as a point in time that:      * Does not represent a day that overlaps with the calendars WeekendMask      * If the calendar is a \"Holiday Calendar\" Does not overlap with any dates in the calendar      * If the calendar is a \"TradingHours Calendar\" Does overlap with a date in the calendar                All dates specified must be UTC and the upper bound of a calendar is not inclusive   e.g. From: 2020-12-25-00-00-00        To: 2020-12-26-00-00-00  IsBusinessDay(2020-12-26-00-00-00) == false

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class IsBusinessDateTimeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var dateTime = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | DateTime to check - This DateTime must be UTC
            var scope = scope_example;  // string | Scope of the calendar
            var code = code_example;  // string | Code of the calendar
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | AsAt for the request (optional) 

            try
            {
                // [BETA] Check whether a DateTime is a \"Business DateTime\"
                IsBusinessDayResponse result = apiInstance.IsBusinessDateTime(dateTime, scope, code, asAt);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.IsBusinessDateTime: " + e.Message );
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
 **dateTime** | **DateTimeOffset?**| DateTime to check - This DateTime must be UTC | 
 **scope** | **string**| Scope of the calendar | 
 **code** | **string**| Code of the calendar | 
 **asAt** | **DateTimeOffset?**| AsAt for the request | [optional] 

### Return type

[**IsBusinessDayResponse**](IsBusinessDayResponse.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Whether or not the requested DateTime is a BusinessDay or not |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListCalendars

> PagedResourceListOfCalendar ListCalendars (DateTimeOffset? asAt = null, string page = null, int? limit = null, string filter = null)

[BETA] List Calenders

List calendars at a point in AsAt time.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListCalendarsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The AsAt datetime at which to retrieve the calendars (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing calendars from a previous call to list calendars.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [BETA] List Calenders
                PagedResourceListOfCalendar result = apiInstance.ListCalendars(asAt, page, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.ListCalendars: " + e.Message );
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
 **asAt** | **DateTimeOffset?**| The AsAt datetime at which to retrieve the calendars | [optional] 
 **page** | **string**| The pagination token to use to continue listing calendars from a previous call to list calendars.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**PagedResourceListOfCalendar**](PagedResourceListOfCalendar.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | List Calendars |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListCalendarsInScope

> PagedResourceListOfCalendar ListCalendarsInScope (string scope, DateTimeOffset? asAt = null, string page = null, int? start = null, int? limit = null, string filter = null)

[BETA] List all calenders in a specified scope

List calendars at a point in AsAt time.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class ListCalendarsInScopeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the calendars
            var asAt = 2013-10-20T19:20:30+01:00;  // DateTimeOffset? | The AsAt datetime at which to retrieve the calendars (optional) 
            var page = page_example;  // string | The pagination token to use to continue listing calendars from a previous call to list calendars.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. (optional) 
            var start = 56;  // int? | When paginating, skip this number of results. (optional) 
            var limit = 56;  // int? | When paginating, limit the number of returned results to this many. (optional) 
            var filter = filter_example;  // string | Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional) 

            try
            {
                // [BETA] List all calenders in a specified scope
                PagedResourceListOfCalendar result = apiInstance.ListCalendarsInScope(scope, asAt, page, start, limit, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.ListCalendarsInScope: " + e.Message );
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
 **scope** | **string**| Scope of the calendars | 
 **asAt** | **DateTimeOffset?**| The AsAt datetime at which to retrieve the calendars | [optional] 
 **page** | **string**| The pagination token to use to continue listing calendars from a previous call to list calendars.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. Also, if set, a start value cannot be provided. | [optional] 
 **start** | **int?**| When paginating, skip this number of results. | [optional] 
 **limit** | **int?**| When paginating, limit the number of returned results to this many. | [optional] 
 **filter** | **string**| Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. | [optional] 

### Return type

[**PagedResourceListOfCalendar**](PagedResourceListOfCalendar.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Calendars in the requested scope |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpdateCalendar

> Calendar UpdateCalendar (string scope, string code, UpdateCalendarRequest updateCalendarRequest)

[BETA] Update a calendar

Update the calendars WeekendMask, SourceProvider or Properties

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Example
{
    public class UpdateCalendarExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://fbn-prd.lusid.com/api";
            // Configure OAuth2 access token for authorization: oauth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CalendarsApi(Configuration.Default);
            var scope = scope_example;  // string | Scope of the request
            var code = code_example;  // string | Code of the request
            var updateCalendarRequest = new UpdateCalendarRequest(); // UpdateCalendarRequest | The new state of the calendar

            try
            {
                // [BETA] Update a calendar
                Calendar result = apiInstance.UpdateCalendar(scope, code, updateCalendarRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CalendarsApi.UpdateCalendar: " + e.Message );
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
 **scope** | **string**| Scope of the request | 
 **code** | **string**| Code of the request | 
 **updateCalendarRequest** | [**UpdateCalendarRequest**](UpdateCalendarRequest.md)| The new state of the calendar | 

### Return type

[**Calendar**](Calendar.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

- **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The updated calendar |  -  |
| **400** | The details of the input related failure |  -  |
| **0** | Error response |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

