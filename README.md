# Visual Basic .NET Shims for .NET Core

a set of API shims for migrating Visual Basic .NET codebase from .NET Framework to Core. Requires .NET Core 3.0 / .NET Standard 2.0 or above.

Since certain APIs are not available in `Microsoft.VisualBasic` namespace (and `My` namespace) since .NET Core 3.0 (c.f. [dotnet/docs#14545](https://github.com/dotnet/docs/issues/14545)), sometimes we need some sweet little shims as an alternative to migrating all the usages into .NET Runtime to make legacy codebase work.

The packages `CXuesong.Shims.VisualBasic.*` are now available on NuGet. As an example, you may install the package using the following command

```powershell
#  .NET CLI
dotnet add package CXuesong.Shims.VisualBasic.ApplicationServices
```

## Packages

### CXuesong.Shims.VisualBasic.ApplicationServices

[NuGet](https://www.nuget.org/packages/CXuesong.Shims.VisualBasic.ApplicationServices) | ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/CXuesong.Shims.VisualBasic.ApplicationServices?style=flat-square) ![Nuget](https://img.shields.io/nuget/dt/CXuesong.Shims.VisualBasic.ApplicationServices?style=flat-square)

Provides shim objects for `Microsoft.VisualBasic.ApplicationServices`, so you can derive your own `My.Application` instance from `ApplicationBase` or `ConsoleApplicationBase` class.

