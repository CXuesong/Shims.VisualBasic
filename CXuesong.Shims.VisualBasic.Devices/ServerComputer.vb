
Imports System.Collections.Concurrent
Imports System.ComponentModel
Imports System.Threading

''' <summary>
''' Cross-platform Computer stub class.
''' You can to install respective NuGet packages to enable extension methods on this class.
''' </summary>
''' <seealso cref="Computer"/>
Public Class ServerComputer

    Private ReadOnly m_Clock As Clock
    Private ReadOnly m_FileSystem As FileSystemProxy
    Private ReadOnly m_ExtensionSlots As New ConcurrentDictionary(Of Object, Object)

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

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Sub SetExtensionSlot(key As Object, value As Object)
        m_ExtensionSlots(key) = value
    End Sub

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Function GetExtensionSlot(key As Object) As Object
        Dim result = Nothing
        Return If(m_ExtensionSlots.TryGetValue(key, result), result, Nothing)
    End Function

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Function GetExtensionSlot(Of T As Class)(key As Object) As T
        Return DirectCast(GetExtensionSlot(key), T)
    End Function

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Function RemoveExtensionSlot(key As Object) As Boolean
        Dim existing = Nothing
        Return m_ExtensionSlots.TryRemove(key, existing)
    End Function

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Function GetOrCreateExtensionSlot(key As Object, valueFactory As Func(Of Object, Object)) As Object
        Return m_ExtensionSlots.GetOrAdd(key, valueFactory)
    End Function

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Function GetOrCreateExtensionSlot(Of T As {New, Class})(key As Object) As T
        Dim result = Nothing
        If m_ExtensionSlots.TryGetValue(key, result) Then Return DirectCast(result, T)
        Return DirectCast(m_ExtensionSlots.GetOrAdd(key, Function() New T), T)
    End Function

End Class