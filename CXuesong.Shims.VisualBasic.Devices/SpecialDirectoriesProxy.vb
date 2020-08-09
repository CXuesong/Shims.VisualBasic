Imports System.ComponentModel
Imports System.IO

<EditorBrowsable(EditorBrowsableState.Never)>
Public Class SpecialDirectoriesProxy

    Public ReadOnly Property MyDocuments As String
        Get
            Return GetDirectory(Environment.SpecialFolder.MyDocuments)
        End Get
    End Property

    Public ReadOnly Property MyMusic As String
        Get
            Return GetDirectory(Environment.SpecialFolder.MyMusic)
        End Get
    End Property

    Public ReadOnly Property MyPictures As String
        Get
            Return GetDirectory(Environment.SpecialFolder.MyMusic)
        End Get
    End Property

    Public ReadOnly Property Desktop As String
        Get
            Return GetDirectory(Environment.SpecialFolder.Desktop)
        End Get
    End Property

    Public ReadOnly Property Programs As String
        Get
            Return GetDirectory(Environment.SpecialFolder.Programs)
        End Get
    End Property

    Public ReadOnly Property ProgramFiles As String
        Get
            Return GetDirectory(Environment.SpecialFolder.ProgramFiles)
        End Get
    End Property

    Public ReadOnly Property Temp As String
        Get
            Dim p = Path.GetTempPath
            If String.IsNullOrEmpty(p) Then
                Throw New DirectoryNotFoundException("Temp path is empty, usually because the operating system does not support the directory.")
            End If
            Return p
        End Get
    End Property

    Public ReadOnly Property CurrentUserApplicationData As String
        Get
            Return GetDirectory(Environment.SpecialFolder.ApplicationData)
        End Get
    End Property

    Public ReadOnly Property AllUsersApplicationData As String
        Get
            Return GetDirectory(Environment.SpecialFolder.CommonApplicationData)
        End Get
    End Property

    Private Function GetDirectory(folder As Environment.SpecialFolder) As String
        Dim path = Environment.GetFolderPath(folder)
        If String.IsNullOrEmpty(path) Then
            Throw New DirectoryNotFoundException(String.Format("The {0} path is empty, usually because the operating system does not support the directory.", folder))
        End If
        Return path
    End Function

End Class
