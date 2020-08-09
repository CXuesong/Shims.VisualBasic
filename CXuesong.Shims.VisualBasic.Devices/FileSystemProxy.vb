Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading

<EditorBrowsable(EditorBrowsableState.Never)>
Public Class FileSystemProxy

    Private ReadOnly m_SpecialDirectories As SpecialDirectoriesProxy

    Public Property CurrentDirectory As String
        Get
            Return Directory.GetCurrentDirectory
        End Get
        Set(value As String)
            Directory.SetCurrentDirectory(value)
        End Set
    End Property

    Public ReadOnly Property Drives As IReadOnlyCollection(Of DriveInfo)
        Get
            Return DriveInfo.GetDrives
        End Get
    End Property

    Public ReadOnly Property SpecialDirectories As SpecialDirectoriesProxy
        Get
            Return LazyInitializer.EnsureInitialized(m_SpecialDirectories)
        End Get
    End Property

    Public Function CombinePath(baseDirectory As String, relativePath As String) As String
        Return Path.Combine(baseDirectory, relativePath)
    End Function

    ' Public Sub CopyDirectory(sourceDirectoryName As String, destinationDirectoryName As String)

    ' Public Sub CopyDirectory(sourceDirectoryName As String, destinationDirectoryName As String, overwrite As Boolean)

    Public Sub CopyFile(sourceFileName As String, destinationFileName As String)
        File.Copy(sourceFileName, destinationFileName)
    End Sub

    Public Sub CopyFile(sourceFileName As String, destinationFileName As String, overwrite As Boolean)
        File.Copy(sourceFileName, destinationFileName, overwrite)
    End Sub

    Public Sub CreateDirectory(directory As String)
        IO.Directory.CreateDirectory(directory)
    End Sub

    Public Sub DeleteFile(file As String)
        CheckFileExistence(file)
        IO.File.Delete(file)
    End Sub

    Public Function DirectoryExists(directory As String) As Boolean
        Return IO.Directory.Exists(directory)
    End Function

    Public Function FileExists(file As String) As Boolean
        Return IO.File.Exists(file)
    End Function

    Public Function GetName(path As String) As String
        Return IO.Path.GetFileName(path)
    End Function

    Public Function GetParentPath(path As String) As String
        Return IO.Path.GetDirectoryName(path)
    End Function

    Public Function GetTempFileName() As String
        Return Path.GetTempFileName
    End Function

    Public Function OpenTextFileReader(file As String) As StreamReader
        Return New StreamReader(file)
    End Function

    Public Function OpenTextFileReader(file As String, encoding As Encoding) As StreamReader
        Return New StreamReader(file, encoding)
    End Function

    Public Function OpenTextFileWriter(file As String, append As Boolean) As StreamWriter
        Return New StreamWriter(file, append)
    End Function

    Public Function OpenTextFileWriter(file As String, append As Boolean, encoding As Encoding) As StreamWriter
        Return New StreamWriter(file, append, encoding)
    End Function

    Public Function ReadAllBytes(file As String) As Byte()
        Return IO.File.ReadAllBytes(file)
    End Function

    Public Function ReadAllText(file As String) As String
        Return IO.File.ReadAllText(file)
    End Function

    Public Function ReadAllText(file As String, encoding As Encoding) As String
        Return IO.File.ReadAllText(file, encoding)
    End Function

    Public Sub RenameDirectory(directory As String, newName As String)
        If directory Is Nothing Then Throw New ArgumentNullException(NameOf(directory))
        If newName Is Nothing Then Throw New ArgumentNullException(NameOf(newName))
        If Path.GetFileName(newName) <> newName Then Throw New ArgumentException("newName contains path information.", NameOf(newName))
        directory = directory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
        CheckDirectoryExistence(directory)
        IO.Directory.Move(directory, Path.Combine(Path.GetDirectoryName(directory), newName))
    End Sub

    Public Sub RenameFile(file As String, newName As String)
        If file Is Nothing Then Throw New ArgumentNullException(NameOf(file))
        If newName Is Nothing Then Throw New ArgumentNullException(NameOf(newName))
        If Path.GetFileName(newName) <> newName Then Throw New ArgumentException("newName contains path information.", NameOf(newName))
        CheckFileExistence(file)
        IO.File.Move(file, Path.Combine(Path.GetDirectoryName(file), newName))
    End Sub

    Private Sub CheckFileExistence(path As String)
        If Not File.Exists(path) Then Throw New FileNotFoundException("Cannot find the specified file.", path)
    End Sub

    Private Sub CheckDirectoryExistence(path As String)
        If Not Directory.Exists(path) Then Throw New DirectoryNotFoundException("Cannot find the specified directory.")
    End Sub

End Class
