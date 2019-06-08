| branch | status |
| --- | --- |
| `master` |  [![Build Status](https://travis-ci.org/finbourne/lusid-sdk-csharp-preview.svg?branch=master)](https://travis-ci.org/finbourne/lusid-sdk-csharp-preview) |
| `develop` | [![Build Status](https://travis-ci.org/finbourne/lusid-sdk-csharp-preview.svg?branch=develop)](https://travis-ci.org/finbourne/lusid-sdk-csharp-preview) |

# LUSID<sup>®</sup> C# SDK

The NuGet package for the LUSID SDK can installed from https://www.nuget.org/packages/Lusid.Sdk using the following:

```
$ dotnet add package Lusid.Sdk 
```

A pre-generated version of the latest SDK is included in the sdk folder based on the OpenAPI specification named lusid.json in the root folder. The most up to date version of the OpenAPI specification can be downloaded from https://api.lusid.com/swagger/v0/swagger.json

In addition to the SDK, a set of examples on how to use the SDK can be found in the sdk/Lusid.Sdk.Tests folder. These exist in the form of unit tests. Further instructions on running them can be found in the [README](https://github.com/finbourne/lusid-sdk-csharp/blob/master/sdk/running_tests.md).

# Generating the SDK

If you would prefer to generate the C# SDK locally from the FINBOURNE OpenAPI specification, follow these steps:
  * download the latest swagger.json file from http://api.lusid.com/swagger/v0/swagger.json
  * save it in this directory as `lusid.json`
  * run `docker-compose up --build && docker-compose rm -f`
