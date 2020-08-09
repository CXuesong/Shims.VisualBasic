Imports System.Collections.ObjectModel
Imports System.Reflection

Public Class ConsoleApplicationBase
    Inherits ApplicationBase

    Private ReadOnly m_CommandLineArgs As New Lazy(Of IReadOnlyList(Of String))(Function() Environment.GetCommandLineArgs().Skip(1).ToArray)

    Public Sub New(owningAssembly As Assembly)
        MyBase.New(owningAssembly)
    End Sub

    ' Public ReadOnly Property Deployment As ApplicationDeployment

    ''' <summary>Gets a collection containing the command-line arguments as strings for the current application.</summary>
    Public ReadOnly Property CommandLineArgs As IReadOnlyList(Of String)
        Get
            Return If(InternalCommandLine, m_CommandLineArgs.Value)
        End Get
    End Property

    ''' <summary>Sets the values to use as the current application's command-line arguments.</summary>
    Public Property InternalCommandLine As ReadOnlyCollection(Of String)

    ' Public ReadOnly Property IsNetworkDeployed As Boolean

End Class
