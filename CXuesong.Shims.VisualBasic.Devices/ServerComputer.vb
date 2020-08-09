
Imports System.Threading

Public Class ServerComputer

    Private ReadOnly m_Clock As Clock
    Private ReadOnly m_FileSystem As FileSystemProxy

    Public ReadOnly Property Clock As Clock
        Get
            Return LazyInitializer.EnsureInitialized(m_Clock)
        End Get
    End Property

    Public ReadOnly Property FileSystem As FileSystemProxy
        Get
            Return LazyInitializer.EnsureInitialized(m_FileSystem)
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return Environment.MachineName
        End Get
    End Property

    ' Public ReadOnly Property Network As Network

    ' Public ReadOnly Property Registry As RegistryProxy

End Class