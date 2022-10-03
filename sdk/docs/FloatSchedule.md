# Lusid.Sdk.Model.FloatSchedule
Schedule for fixed coupon payments

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ScheduleType** | **string** | The available values are: Fixed, Float, Optionality, Step, Exercise, FxRate, Invalid | 
**StartDate** | **DateTimeOffset** | Date to start generate from | [optional] 
**MaturityDate** | **DateTimeOffset** | Date to generate to | [optional] 
**FlowConventions** | [**FlowConventions**](FlowConventions.md) |  | [optional] 
**ConventionName** | [**FlowConventionName**](FlowConventionName.md) |  | [optional] 
**IndexConventionName** | [**FlowConventionName**](FlowConventionName.md) |  | [optional] 
**IndexConventions** | [**IndexConvention**](IndexConvention.md) |  | [optional] 
**Notional** | **decimal** | Scaling factor, the quantity outstanding on which the rate will be paid. | [optional] 
**PaymentCurrency** | **string** | Payment currency. This does not have to be the same as the nominal bond or observation/reset currency. | [optional] 
**Spread** | **decimal** | Spread over floating rate given as a fraction. | [optional] 
**StubType** | **string** | StubType required of the schedule    Supported string (enumeration) values are: [ShortFront, ShortBack, LongBack, LongFront, Both]. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

