Imports System.Collections.ObjectModel
Imports System.Reflection

Public Class ConsoleApplicationBase
    Inherits ApplicationBase

    Private ReadOnly m_CommandLineArgs As New Lazy(Of IReadOnlyCollection(Of String))(Function() Environment.GetCommandLineArgs())

    Public Sub New(owningAssembly As Assembly)
        MyBase.New(owningAssembly)
    End Sub

    ' Public ReadOnly Property Deployment As ApplicationDeployment

    Public ReadOnly Property CommandLineArgs As IReadOnlyCollection(Of String)
        Get
            Return If(InternalCommandLine, m_CommandLineArgs.Value)
        End Get
    End Property

    Public Property InternalCommandLine As ReadOnlyCollection(Of String)

    ' Public ReadOnly Property IsNetworkDeployed As Boolean

End Class
