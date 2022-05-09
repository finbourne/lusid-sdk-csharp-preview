# Lusid.Sdk.Model.FixedScheduleAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset** | Date to start generate from | 
**MaturityDate** | **DateTimeOffset** | Date to generate to | 
**FlowConventions** | [**FlowConventions**](FlowConventions.md) |  | [optional] 
**CouponRate** | **decimal** | Coupon rate given as a fraction. | [optional] 
**ConventionName** | [**FlowConventionName**](FlowConventionName.md) |  | [optional] 
**Notional** | **decimal** | Scaling factor, the quantity outstanding on which the rate will be paid. | [optional] 
**PaymentCurrency** | **string** | Payment currency. This does not have to be the same as the nominal bond or observation/reset currency. | [optional] 
**ScheduleType** | **string** | The available values are: Fixed, Float, Optionality, Step, Exercise, Invalid | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

