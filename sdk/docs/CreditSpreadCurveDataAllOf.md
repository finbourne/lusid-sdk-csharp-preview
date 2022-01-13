# Lusid.Sdk.Model.CreditSpreadCurveDataAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BaseDate** | **DateTimeOffset** | EffectiveAt date of the quoted rates | 
**DomCcy** | **string** | Domestic currency of the curve | 
**Tenors** | **List&lt;string&gt;** | The tenors for which the rates apply | 
**Spreads** | **List&lt;decimal&gt;** | Par spread quotes corresponding to the tenors. | 
**RecoveryRate** | **decimal** | The recovery rate in default. | 
**ReferenceDate** | **DateTimeOffset?** | If tenors are provided, this is the date against which the tenors will be resolved.  This is of importance to CDX spread quotes, which are usually quoted in tenors relative to the CDX start date.  In this case, the ReferenceDate would be equal to the CDX start date, and the BaseDate would be the date for which the spreads are valid.  If not provided, this defaults to the BaseDate of the curve. | [optional] 
**Maturities** | **List&lt;DateTimeOffset&gt;** | The maturity dates for which the rates apply.  Either tenors or maturities should be provided, not both. | [optional] 
**MarketDataType** | **string** | The available values are: DiscountFactorCurveData, EquityVolSurfaceData, FxVolSurfaceData, IrVolCubeData, OpaqueMarketData, YieldCurveData, FxForwardCurveData, FxForwardPipsCurveData, FxForwardTenorCurveData, FxForwardTenorPipsCurveData, FxForwardCurveByQuoteReference, CreditSpreadCurveData | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

