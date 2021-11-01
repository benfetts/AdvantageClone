Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Services.Discovery
Imports System.Web.Services.WebServiceAttribute
Imports System.Web.Services.Routing
Imports System.IO
Imports System.Security.Cryptography
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Webvantage.SqlHelper

<System.Web.Services.WebService(Namespace:="http://Webvantage.net/GetRepositoryDoc")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> <System.Serializable()> _
Public Class GetRepositoryDoc
    Inherits System.Web.Services.WebService



    <WebMethod()> _
        Public Function EncryptPassword(ByVal Password As String) As String
        Dim encryptedPW As String

        encryptedPW = AdvantageFramework.Security.Encryption.Encrypt(Password)
        Return encryptedPW
    End Function


    <WebMethod()> _
    Public Function savefile(ByVal filebytes() As Byte, ByVal filename As String, ByVal UserDomain As String, ByVal UserName As String, ByVal UserPassword As String, ByVal DocRepPath As String) As Integer
        Dim impersonateUser As Boolean
        Dim AliasAccount As AliasAccount
        

        AliasAccount.BeginImpersonation(UserName, UserDomain, UserPassword)

        Dim newFileStream As New FileStream(DocRepPath & "\" & filename, FileMode.Create, FileAccess.ReadWrite)

        If filebytes.Length > 0 Then
            newFileStream.Write(filebytes, 0, filebytes.Length)
        End If

        newFileStream.Close()

        AliasAccount.EndImpersonation()

        Return 1


        '************************************************************************************
        'Dim ConnectionString As String
        'Dim DRUserName, DRUserDomain, DRUserPassword, DocRepPath As String

        'ConnectionString = "Initial Catalog=" + initcatalog + ";Data Source=" + DB + ";User ID=" + UserName + ";Password=" + UserPassword + ";"

        'Dim DocumentRepository As New DocumentRepository(ConnectionString)
        'DRUserName = DocumentRepository.UserName
        'DRUserDomain = DocumentRepository.UserDomain
        'DRUserPassword = DocumentRepository.UserPassword
        'DocRepPath = DocumentRepository.Path

    End Function

    ''' Adds a document to the repository folder then returns the new filename (GUID)
    <WebMethod()> _
    Public Function AddDocument(ByVal filename As String, ByVal bytes() As Byte, ByVal UserDomain As String, ByVal UserName As String, ByVal UserPassword As String, ByVal description As String, ByVal keywords As String, ByVal authorName As String, ByVal DocRepPath As String) As String
        Try
            Dim impersonateUser As Boolean
            Dim AliasAccount As AliasAccount
            Dim IndexDocument As New System.Xml.XmlDocument
            Dim TemplateXML As New System.Text.StringBuilder
            Dim RepositoryFilename As String = "a_" & Guid.NewGuid.ToString
            Dim IndexDocumentText As String = ""

            TemplateXML.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
            TemplateXML.AppendLine("<documents>")
            TemplateXML.AppendLine("<document filename="""" realfilename=""""  description="""" keywords="""" author="""" ></document>")
            TemplateXML.AppendLine("</documents>")

            IndexDocument.LoadXml(TemplateXML.ToString())
            IndexDocument.SelectSingleNode("//documents/document").Attributes("filename").Value = RepositoryFilename
            IndexDocument.SelectSingleNode("//documents/document").Attributes("realfilename").Value = filename
            IndexDocument.SelectSingleNode("//documents/document").Attributes("description").Value = description
            IndexDocument.SelectSingleNode("//documents/document").Attributes("author").Value = authorName
            IndexDocument.SelectSingleNode("//documents/document").Attributes("keywords").Value = keywords
            IndexDocumentText = IndexDocument.OuterXml

            Dim encoding As New System.Text.ASCIIEncoding()
            'Dim encodingUTF As New System.Text.UTF8Encoding 'TEST
            Dim IndexBytes() As Byte = encoding.GetBytes(IndexDocumentText)

            impersonateUser = UserName <> ""
            If impersonateUser Then
                AliasAccount.BeginImpersonation(UserName, UserDomain, UserPassword)
            End If

            Dim newFileStream As New FileStream(DocRepPath & "\" & RepositoryFilename, FileMode.OpenOrCreate, FileAccess.Write)
            newFileStream.Write(bytes, 0, bytes.Length)
            newFileStream.Close()

            Dim newIndexFileStream As New FileStream(DocRepPath & "\" & RepositoryFilename & ".index.xml", FileMode.OpenOrCreate, FileAccess.Write)
            newIndexFileStream.Write(IndexBytes, 0, IndexBytes.Length)
            newIndexFileStream.Close()

            If impersonateUser Then
                AliasAccount.EndImpersonation()
            End If

            Return RepositoryFilename

        Catch ex As Exception
            ' Throw New Exception("An error occured while trying to save this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
        End Try
    End Function


End Class
