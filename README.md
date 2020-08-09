# Visual Basic .NET Shims for .NET Core

Since certain APIs are not available in `Microsoft.VisualBasic` namespace (and `My` namespace) since .NET Core 3.0 (c.f. [dotnet/docs#14545](https://github.com/dotnet/docs/issues/14545)), sometimes we need some sweet little shims as an alternative to migrating all the usages into .NET Runtime to make legacy codebase work.

## Packages

### CXuesong.Shims.VisualBasic.ApplicationServices

Provides shim objects for `Microsoft.VisualBasic.ApplicationServices`, so you can derive your own `My.Application` instance from `ApplicationBase` or `ConsoleApplicationBase` class.

