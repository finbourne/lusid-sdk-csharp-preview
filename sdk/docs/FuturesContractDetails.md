# Lusid.Sdk.Model.FuturesContractDetails
Most, if not all, information about contracts is standardized. See, e.g. https://www.cmegroup.com/ for  common codes and similar data. This appears to be in common use by well known market information providers, e.g. Bloomberg and Refinitiv.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DomCcy** | **string** | Currency in which the contract is paid. | 
**ContractCode** | **string** | The contract code used by the exchange, e.g. “CL” for Crude Oil, “ES” for E-mini SP 500, “FGBL” for Bund Futures, etc. | 
**ContractMonth** | **string** | Which month does the contract trade for.  Supported string (enumeration) values are: [F, G, H, J, K, M, N, Q, U, V, X, Z]. | 
**ContractSize** | **decimal** | Size of a single contract. By default this should be set to 1000 if otherwise unknown and is defaulted to such. | 
**Convention** | **string** | If appropriate, the day count convention method used in pricing (rates futures). | 
**Country** | **string** | Country (code) for the exchange. | 
**Description** | **string** | Description of contract. | 
**ExchangeCode** | **string** | Exchange code for contract  Supported string (enumeration) values are: [ASX, CBOT, CBF, CME, CMX, EOP, HKG, KFE, MFM, OSE, SGX, NYBOT, KCBT, MGE, MATIF, SFE, NYFE, NYM, LIFFE, EUREX, ICE, MSE]. | 
**ExchangeName** | **string** | Exchange name (for when code is not automatically recognized). | 
**TickerStep** | **decimal** | Minimal step size change in ticker. | 
**UnitValue** | **decimal** | The value in the currency of a 1 unit change in the contract price. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

