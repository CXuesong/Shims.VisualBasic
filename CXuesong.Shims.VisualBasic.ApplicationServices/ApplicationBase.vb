Imports System.Globalization
Imports System.Reflection
Imports System.Threading

Public Class ApplicationBase

    Private ReadOnly m_OwningAssembly As Assembly
    Private ReadOnly m_Info As New Lazy(Of AssemblyInfo)(Function() New AssemblyInfo(m_OwningAssembly))

    Public Sub New(owningAssembly As Assembly)
        If owningAssembly Is Nothing Then Throw New ArgumentNullException(NameOf(owningAssembly))
        m_OwningAssembly = owningAssembly
    End Sub

    Public ReadOnly Property Culture As CultureInfo
        Get
            Return Thread.CurrentThread.CurrentCulture
        End Get
    End Property

    Public ReadOnly Property Info As AssemblyInfo
        Get
            Return m_Info.Value
        End Get
    End Property

    ' Public ReadOnly Property Log As Log

    Public ReadOnly Property UICulture As CultureInfo
        Get
            Return Thread.CurrentThread.CurrentUICulture
        End Get
    End Property

    Public Sub ChangeCulture(cultureName As String)
        Try
            Dim c = CultureInfo.GetCultureInfo(cultureName)
            Thread.CurrentThread.CurrentCulture = c
        Catch ex As CultureNotFoundException
            Throw New ArgumentException("cultureName is not a valid culture name.", NameOf(cultureName))
        End Try
    End Sub

    Public Sub ChangeUICulture(cultureName As String)
        Try
            Dim c = CultureInfo.GetCultureInfo(cultureName)
            Thread.CurrentThread.CurrentUICulture = c
        Catch ex As CultureNotFoundException
            Throw New ArgumentException("cultureName is not a valid culture name.", NameOf(cultureName))
        End Try
    End Sub

    Public Function GetEnvironmentVariable(name As String) As String
        Dim v = Environment.GetEnvironmentVariable(name)
        If v Is Nothing Then
            Throw New ArgumentException(String.Format("The environment variable ""{0}"" does not exist.", name), NameOf(name))
        End If
        Return v
    End Function

End Class