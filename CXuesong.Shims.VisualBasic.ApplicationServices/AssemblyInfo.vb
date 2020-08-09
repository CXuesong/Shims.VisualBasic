Imports System.IO
Imports System.Reflection

Public Class AssemblyInfo

    Private ReadOnly m_OwningAssembly As Assembly

    Friend Sub New(owningAssembly As Assembly)
        Debug.Assert(owningAssembly IsNot Nothing)
        m_OwningAssembly = owningAssembly
        AssemblyName = Path.GetFileNameWithoutExtension(m_OwningAssembly.Location)
        DirectoryPath = Path.GetDirectoryName(m_OwningAssembly.Location)
    End Sub

    Private Function GetAssemblyAttribute(Of T As Attribute)() As T
        Dim attr = m_OwningAssembly.GetCustomAttribute(Of T)()
        If attr Is Nothing Then Throw New InvalidOperationException(String.Format("The assembly does not have an {0} attribute.", GetType(T).Name))
        Return attr
    End Function

    Public ReadOnly Property AssemblyName As String

    Public ReadOnly Property CompanyName As String
        Get
            Return GetAssemblyAttribute(Of AssemblyCompanyAttribute).Company
        End Get
    End Property

    Public ReadOnly Property Copyright As String
        Get
            Return GetAssemblyAttribute(Of AssemblyCopyrightAttribute).Copyright
        End Get
    End Property

    Public ReadOnly Property Description As String
        Get
            Dim companyAttribute = m_OwningAssembly.GetCustomAttribute(Of AssemblyDescriptionAttribute)()
            If companyAttribute Is Nothing Then Throw New InvalidOperationException("The assembly does not have an AssemblyDescriptionAttribute attribute.")
            Return companyAttribute.Description
        End Get
    End Property

    Public ReadOnly Property DirectoryPath As String

    Public ReadOnly Property LoadedAssemblies As IReadOnlyList(Of Assembly)
        Get
            Return AppDomain.CurrentDomain.GetAssemblies()
        End Get
    End Property

    Public ReadOnly Property ProductName As String
        Get
            Return GetAssemblyAttribute(Of AssemblyProductAttribute).Product
        End Get
    End Property

    Public ReadOnly Property StackTrace As String
        Get
            Return New StackTrace(0, True).ToString
        End Get
    End Property

    Public ReadOnly Property Title As String
        Get
            Return GetAssemblyAttribute(Of AssemblyTitleAttribute).Title
        End Get
    End Property

    Public ReadOnly Property Trademark As String
        Get
            Return GetAssemblyAttribute(Of AssemblyTrademarkAttribute).Trademark
        End Get
    End Property

    Public ReadOnly Property Version As Version
        Get
            Return m_OwningAssembly.GetName().Version
        End Get
    End Property

    Public ReadOnly Property WorkingSet As Long
        Get
            Return Environment.WorkingSet
        End Get
    End Property

End Class