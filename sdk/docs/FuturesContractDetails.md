
# Lusid.Sdk.Model.FuturesContractDetails

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DomCcy** | **string** | currency in which the contract is paid. | 
**ContractCode** | **string** | The two letter contract code abbreviation. e.g. CL &#x3D;&gt; Crude Oil. | 
**ContractMonth** | **string** | which month does the contract trade for. | 
**ContractSize** | **decimal?** | Size of a single contract. By default this should be set to 1000 if otherwise unknown and is defaulted to such. | 
**Convention** | **string** | If appropriate, the day count convention method used in pricing (rates futures) | 
**Country** | **string** | Country (code) for the exchange. | 
**Description** | **string** | Description of contract | 
**ExchangeCode** | **string** | Exchange code for contract | 
**ExchangeName** | **string** | Exchange name (for when code is not automatically recognized) | 
**TickerStep** | **decimal?** | Minimal step size change in ticker | 
**UnitValue** | **decimal?** | The value in the currency of a 1 unit change in the contract price | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

