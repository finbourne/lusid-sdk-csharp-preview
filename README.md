# LUSID<sup>®</sup> C# Preview SDK

This is the C# Preview SDK for [LUSID by FINBOURNE](https://www.finbourne.com/lusid-technology), a bi-temporal investment management data platform with portfolio accounting capabilities. To use it you'll need a LUSID account. [Sign up for free at lusid.com](https://www.lusid.com/app/signup)

![LUSID_by_Finbourne](https://content.finbourne.com/LUSID_repo.png)

## Installation

The NuGet package for the LUSID Preview SDK can installed from https://www.nuget.org/packages/Lusid.Sdk using the following:

```
$ dotnet add package Lusid.Sdk.Preview
```

We publish two versions of the C# SDK:

* [lusid-sdk-csharp](https://github.com/finbourne/lusid-sdk-csharp-preview) - supports `Production` and `Early Access` API endpoints
* **lusid-sdk-csharp-preview (this one) - supports `Production`, `Early Access`, `Beta` and `Experimental` API endpoints.**

For more details on API endpoint categories, see [What is the LUSID feature release lifecycle?](https://support.lusid.com/knowledgebase/article/KA-01786/en-us)
To find out which category an API endpoint falls into, see [LUSID API Documentation](https://www.lusid.com/api/swagger/index.html).

## Documentation

For further documentation on building the SDK, running the tutorials and using the SDK please see the [wiki](https://github.com/finbourne/lusid-sdk-csharp-preview/wiki) and the [standalone examples repository](https://github.com/finbourne/lusid-sdk-examples-csharp).

Documentation for namespaces, interfaces, classes, functions and other members of the
SDK is [available to view online](https://lusid-sdk-csharp-preview.readthedocs.io/en/latest/).

## Build Status 

| branch | status |
| --- | --- |
| `master` |  ![Nuget](https://img.shields.io/nuget/v/Lusid.Sdk.Preview?color=blue) ![Build and test](https://github.com/finbourne/lusid-sdk-csharp-preview/workflows/Build%20and%20test/badge.svg) |
| `develop` | ![Build and test](https://github.com/finbourne/lusid-sdk-csharp-preview/workflows/Build%20and%20test/badge.svg?branch=develop) |
