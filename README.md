# Visual Basic .NET Shims for .NET Core

a set of API shims for migrating Visual Basic .NET codebase from .NET Framework to Core. Requires .NET Core 3.0 / .NET Standard 2.0 or above.

Because certain APIs are not available in `Microsoft.VisualBasic` namespace (and `My` namespace) since .NET Core 3.0 (c.f. [dotnet/corefx#39972](https://github.com/dotnet/corefx/pull/39972), [dotnet/docs#14545](https://github.com/dotnet/docs/issues/14545)), sometimes we need some sweet little shims as an alternative to migrating all the usages into .NET Runtime to make legacy codebase work.

Due to the limitation of effort, the API shims provided by this repository is still not complete. If you have any need for the APIs not yet covered, feel free to let me know by [opening an issue in the repo](https://github.com/CXuesong/Shims.VisualBasic/issues). Thanks!

The packages `CXuesong.Shims.VisualBasic.*` are now available on NuGet. As an example, you may install the package using the following command

```powershell
#  .NET CLI
dotnet add package CXuesong.Shims.VisualBasic.ApplicationServices
```

## Packages

### CXuesong.Shims.VisualBasic.ApplicationServices

[NuGet](https://www.nuget.org/packages/CXuesong.Shims.VisualBasic.ApplicationServices) | ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/CXuesong.Shims.VisualBasic.ApplicationServices?style=flat-square) ![Nuget](https://img.shields.io/nuget/dt/CXuesong.Shims.VisualBasic.ApplicationServices?style=flat-square)

Provides shim API for `Microsoft.VisualBasic.ApplicationServices` namespace, so you can derive your own `My.Application` instance from `ApplicationBase` or `ConsoleApplicationBase` class.

### CXuesong.Shims.VisualBasic.Devices

[NuGet](https://www.nuget.org/packages/CXuesong.Shims.VisualBasic.Devices) | ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/CXuesong.Shims.VisualBasic.Devices?style=flat-square) ![Nuget](https://img.shields.io/nuget/dt/CXuesong.Shims.VisualBasic.Devices?style=flat-square)

Provides shim API for `Microsoft.VisualBasic.Devices` namespace, so you can derive your own `My.Computer` instance from `Computer` or `ServerComputer` class.

### CXuesong.Shims.VisualBasic.Devices.Ports

[NuGet](https://www.nuget.org/packages/CXuesong.Shims.VisualBasic.Devices.Ports) | ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/CXuesong.Shims.VisualBasic.Devices.Ports?style=flat-square) ![Nuget](https://img.shields.io/nuget/dt/CXuesong.Shims.VisualBasic.Devices.Ports?style=flat-square)

Provides `Ports` class and `Ports` extension method for `ServerComputer` class, which allows you to access serial ports functionality provided by `My` namespace.

## How to implement `My` namespace with shim packages

For console applications, using the following snippet should be enough

```vb.net
Imports System.ComponentModel
Imports CXuesong.Shims.VisualBasic.ApplicationServices
Imports CXuesong.Shims.VisualBasic.Devices

Namespace My

    <HideModuleName>
    Friend Module MyProject

        Public ReadOnly Property Application As New MyApplication

        Public ReadOnly Property Computer As New MyComputer

    End Module

    <EditorBrowsable(EditorBrowsableState.Never)>
    Friend Class MyApplication
        Inherits ConsoleApplicationBase

        Public Sub New()
            MyBase.New(GetType(MyApplication).Assembly)
        End Sub
    End Class

    <EditorBrowsable(EditorBrowsableState.Never)>
    Friend Class MyComputer
        Inherits Computer

    End Class

End Namespace
```

Then you can use something like the following in your project

```vb.net
My.Computer.FileSystem.WriteAllText(...)
```

