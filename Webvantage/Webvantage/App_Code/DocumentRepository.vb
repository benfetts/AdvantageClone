Imports System.IO
'Imports ICSharpCode.SharpZipLib.Zip
'Imports ICSharpCode.SharpZipLib.Core
Imports Ionic.Zip
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.SqlHelper
Public Class DocumentRepository

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _path As String
    Private _userDomain As String
    Private _userName As String
    Private _userPassword As String
    Private _connString As String
    Private _OriginalWindowsIdentity As System.Security.Principal.WindowsIdentity
    Private oSQL As SqlHelper


#End Region

#Region " Properties "

    Public Property ConnectionString() As String
        Get
            Return _connString
        End Get
        Set(ByVal value As String)
            _connString = value
        End Set
    End Property
    Public Property Path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property
    Public Property UserDomain() As String
        Get
            Return _userDomain
        End Get
        Set(ByVal value As String)
            _userDomain = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property
    Public Property UserPassword() As String
        Get
            Return _userPassword
        End Get
        Set(ByVal value As String)
            _userPassword = value
        End Set
    End Property
    Public Property OriginalWindowsIdentity() As System.Security.Principal.WindowsIdentity
        Get
            Return _OriginalWindowsIdentity
        End Get
        Set(ByVal value As System.Security.Principal.WindowsIdentity)
            _OriginalWindowsIdentity = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Function GetImageThumbnails(ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef Agency As AdvantageFramework.Database.Entities.Agency,
                                       ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Generic.List(Of AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail)

        Dim Thumbnails As Generic.List(Of AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail)

        Thumbnails = Nothing

        Try


            Thumbnails = DbContext.Database.SqlQuery(Of AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail)(String.Format("EXEC [dbo].[advsp_cs_get_repository_thumbnails] {0}, {1};", JobNumber, JobComponentNumber)).ToList

            If Thumbnails IsNot Nothing AndAlso Thumbnails.Count > 0 Then

                For Each Thumbnail As AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail In Thumbnails

                    If Thumbnail.IsImage = True Then

                        If Thumbnail.HasThumbnail = True Then

                            Thumbnail.FileBytes = Thumbnail.Thumbnail

                        Else

                            AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, Thumbnail.DocumentID, Thumbnail.FileBytes)

                        End If

                    End If

                Next

            End If

        Catch ex As Exception
            Thumbnails = Nothing
        End Try

        If Thumbnails Is Nothing Then Thumbnails = New Generic.List(Of AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail)

        Return Thumbnails

    End Function

    Public Shared Function BytesToFriendlyDisplay(ByVal FileSizeInBytes As String) As String

        If IsNumeric(FileSizeInBytes) = True Then

            Dim FileSize As Double = CType(FileSizeInBytes, Double) / 1000

            Select Case FileSize
                Case Is < 1
                    Return "< 1K"
                Case 0 To 999
                    Return FileSize.ToString("#,###") & " KB"
                Case Is >= 1000
                    Return (FileSize / 1000).ToString("#,###.##") & " MB"
                Case Else
                    Return FileSize.ToString() & "B"
            End Select

        Else

            Return FileSizeInBytes

        End If

    End Function

    Public Function GetDocDT(ByVal DocumentID As String) As DataTable
        Dim dt As DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterDocumentID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
        parameterDocumentID.Value = DocumentID
        arParams(0) = parameterDocumentID

        Try
            dt = oSQL.ExecuteDataTable(HttpContext.Current.Session("ConnString"), CommandType.StoredProcedure, "proc_DOCUMENTSLoadByPrimaryKey", "tblcmp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:Doc.aspx Routine:GetDoc", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetNonURL(ByVal StrDocId As String) As String
    End Function
    ''' Adds a document to the repository folder then returns the new filename (GUID)
    Public Function AddDocument(ByVal filename As String, ByVal bytes() As Byte, ByVal description As String, ByVal keywords As String, ByVal authorName As String, Optional ByVal FinalLevelID As String = "",
    Optional ByVal FinalLevelDescript As String = "", Optional ByVal FilePrefix As String = "", Optional ByVal Repository_FileName As String = "") As String
        Try
            Dim impersonateUser As Boolean
            Dim AliasAccount As AliasAccount
            Dim IndexDocument As New System.Xml.XmlDocument
            Dim TemplateXML As New System.Text.StringBuilder
            Dim RepositoryFilename As String = "" ' FilePrefix & Guid.NewGuid.ToString
            Dim IndexDocumentText As String = ""
            If Repository_FileName = "" Then
                RepositoryFilename = FilePrefix & Guid.NewGuid.ToString()
            Else
                RepositoryFilename = Repository_FileName
            End If
            TemplateXML.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
            TemplateXML.AppendLine("<documents>")
            TemplateXML.AppendLine("<document filename="""" realfilename=""""  description="""" keywords="""" author="""" finallevel="""" finalleveldetail="""" ></document>")
            TemplateXML.AppendLine("</documents>")
            IndexDocument.LoadXml(TemplateXML.ToString())
            IndexDocument.SelectSingleNode("//documents/document").Attributes("filename").Value = RepositoryFilename
            IndexDocument.SelectSingleNode("//documents/document").Attributes("realfilename").Value = filename
            IndexDocument.SelectSingleNode("//documents/document").Attributes("description").Value = description
            IndexDocument.SelectSingleNode("//documents/document").Attributes("author").Value = authorName
            IndexDocument.SelectSingleNode("//documents/document").Attributes("keywords").Value = keywords
            IndexDocument.SelectSingleNode("//documents/document").Attributes("finallevel").Value = FinalLevelID
            IndexDocument.SelectSingleNode("//documents/document").Attributes("finalleveldetail").Value = FinalLevelDescript
            IndexDocumentText = IndexDocument.OuterXml
            Dim encoding As New System.Text.ASCIIEncoding()
            Dim IndexBytes() As Byte = encoding.GetBytes(IndexDocumentText)
            impersonateUser = Me.UserName <> ""
            If impersonateUser = True Then
                AliasAccount.BeginImpersonation(Me.UserName, Me.UserDomain, Me.UserPassword)
            End If
            Dim newFileStream As New FileStream(Me.Path & "\" & RepositoryFilename, FileMode.OpenOrCreate, FileAccess.Write)
            newFileStream.Write(bytes, 0, bytes.Length)
            newFileStream.Close()
            newFileStream.Dispose()
            Dim newIndexFileStream As New FileStream(Me.Path & "\" & RepositoryFilename & ".index.xml", FileMode.OpenOrCreate, FileAccess.Write)
            newIndexFileStream.Write(IndexBytes, 0, IndexBytes.Length)
            newIndexFileStream.Close()
            newIndexFileStream.Dispose()
            If impersonateUser = True Then
                AliasAccount.EndImpersonation()
            End If
            Return RepositoryFilename
        Catch ex As Exception
            Throw New Exception("There was a problem saving to the Repository; please make sure the Repository Settings are correct." & ex.Message.ToString(), ex)
        End Try
    End Function
    Public Function GetDocumentName(ByVal documentId As Integer) As String
        Try
            Dim Documents As New Document(Me.ConnectionString)
            Documents.LoadByPrimaryKey(documentId)
            Return Documents.FILENAME
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDocumentRepositoryFileName(ByVal documentId As Integer) As String
        Try
            Dim Documents As New Document(Me.ConnectionString)
            Documents.LoadByPrimaryKey(documentId)
            Return Documents.REPOSITORY_FILENAME
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Overloads Function GetDocument(ByVal documentId As Integer, Optional ByVal OrigIdent As System.Security.Principal.WindowsIdentity = Nothing) As Byte()
        Dim impersonateUser As Boolean
        Dim AliasAccount As AliasAccount
        Dim DocumentName As String = Me.GetDocumentRepositoryFileName(documentId)
        Try
            impersonateUser = Me.UserName <> ""
            If impersonateUser = True Then
                AliasAccount.BeginImpersonation(Me.UserName, Me.UserDomain, Me.UserPassword)
            End If
            Dim newFileStream As New FileStream(Me.Path & "\" & DocumentName, FileMode.OpenOrCreate, FileAccess.Read)
            Dim FileBytes(newFileStream.Length - 1) As Byte
            newFileStream.Read(FileBytes, 0, newFileStream.Length)
            newFileStream.Close()
            If impersonateUser = True Then
                AliasAccount.EndImpersonation()
            End If
            Return FileBytes
        Catch ex As Exception
            Throw New Exception("An error occured while trying to retrieve this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
        End Try
    End Function
    Public Overloads Function GetDocument(ByVal documentId As Integer, ByVal AsFileStream As Boolean) As FileStream
        Dim impersonateUser As Boolean
        Dim AliasAccount As AliasAccount
        Dim DocumentName As String = Me.GetDocumentRepositoryFileName(documentId)
        Try
            impersonateUser = Me.UserName <> ""
            If impersonateUser Then
                AliasAccount.BeginImpersonation(Me.UserName, Me.UserDomain, Me.UserPassword)
            End If
            Dim newFileStream As New FileStream(Me.Path & "\" & DocumentName, FileMode.OpenOrCreate, FileAccess.Read)
            If impersonateUser Then
                AliasAccount.EndImpersonation()
            End If
            Return newFileStream
        Catch ex As Exception
            Throw New Exception("An error occured while trying to retrieve this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
        End Try
    End Function
    Public Function GetDocumentByteArray(ByVal FilePath As String, ByVal FileName As String, ByVal DisableImpersonation As Boolean) As Byte()
        Dim impersonateUser As Boolean
        Dim AliasAccount As AliasAccount
        Try
            impersonateUser = Me.UserName <> ""
            If impersonateUser Then
                AliasAccount.BeginImpersonation(Me.UserName, Me.UserDomain, Me.UserPassword)
            End If
            Dim newFileStream As New FileStream(FilePath & "\" & FileName, FileMode.OpenOrCreate, FileAccess.Read)
            Dim FileBytes(newFileStream.Length - 1) As Byte
            newFileStream.Read(FileBytes, 0, newFileStream.Length)
            newFileStream.Close()
            If impersonateUser Then
                AliasAccount.EndImpersonation()
            End If
            Return FileBytes
        Catch ex As Exception
            Throw New Exception("An error occured while trying to retrieve this document to the Webvantage document repository using function:  GetDocumentByteArray. Ensure that the document repository settings are correct.", ex)
        End Try
    End Function
    Public Function GetDocument_NoImpersonation(ByVal documentId As Integer) As Byte()
        Dim DocumentName As String = Me.GetDocumentRepositoryFileName(documentId)
        Try
            Dim newFileStream As New FileStream(Me.Path & "\" & DocumentName, FileMode.OpenOrCreate, FileAccess.Read)
            Dim FileBytes(newFileStream.Length - 1) As Byte
            ' Load the file into our byte array
            newFileStream.Read(FileBytes, 0, newFileStream.Length)
            newFileStream.Close()
            Return FileBytes
        Catch ex As Exception
            Throw New Exception("An error occured while trying to retrieve this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
        End Try
    End Function
    Public Sub GetDocuments(ByRef TheDT As System.Data.DataTable, ByRef ZOS As ZipFile)
        Dim impersonateUser As Boolean
        Dim AliasAccount As AliasAccount
        Dim Repository_Filename As String = ""
        Dim Real_Filename As String = ""
        Try
            impersonateUser = Me.UserName <> ""
            If impersonateUser Then
                AliasAccount.BeginImpersonation(Me.UserName, Me.UserDomain, Me.UserPassword)
            End If
            For x As Integer = 0 To TheDT.Rows.Count - 1
                Real_Filename = TheDT.Rows(x)("Filename").ToString()
                Repository_Filename = TheDT.Rows(x)("RepositoryFilename").ToString()
                Dim newFileStream As New FileStream(Me.Path & "\" & Repository_Filename, FileMode.OpenOrCreate, FileAccess.Read)
                Dim FileBytes(newFileStream.Length - 1) As Byte
                ' Load the file into our byte array
                newFileStream.Read(FileBytes, 0, newFileStream.Length)
                newFileStream.Close()
                'ZOS.AddFile(Me.Path & "\" & Repository_Filename, "")
                'Dim ZipEntry As New ZipEntry(TheDT.Rows(x)("Filename").ToString())
                'ZipEntry.DateTime = TheDT.Rows(x)("UploadedDate")
                ZOS.AddEntry(Real_Filename, FileBytes)
                'newFileStream.Close()
                'ZOS.Write(FileBytes, 0, FileBytes.Length)
                'ZOS.CloseEntry()
                'ZOS.Flush()
            Next
            ''Return FileBytes
            If impersonateUser Then
                AliasAccount.EndImpersonation()
            End If
        Catch ex As Exception
            Throw New Exception("An error occured while trying to retrieve this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
        End Try
    End Sub
    Public Function GetDocumentFileStream(ByVal documentId As Integer) As FileStream
        Dim impersonateUser As Boolean
        Dim AliasAccount As AliasAccount
        Dim DocumentName As String = Me.GetDocumentRepositoryFileName(documentId)
        Try
            impersonateUser = Me.UserName <> ""
            If impersonateUser Then
                AliasAccount.BeginImpersonation(Me.UserName, Me.UserDomain, Me.UserPassword)
            End If
            Dim newFileStream As New FileStream(Me.Path & "\" & DocumentName, FileMode.OpenOrCreate, FileAccess.Read)
            Dim FileBytes(newFileStream.Length) As Byte
            ' Load the file into our byte array
            newFileStream.Read(FileBytes, 0, newFileStream.Length)
            newFileStream.Close()
            If impersonateUser Then
                AliasAccount.EndImpersonation()
            End If
        Catch ex As Exception
            Throw New Exception("An error occured while trying to retrieve this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
        End Try
    End Function
    Public Overloads Function GetDocument(ByVal repositoryFilename As String) As Byte()
        Dim impersonateUser As Boolean
        Dim AliasAccount As AliasAccount
        Try
            impersonateUser = Me.UserName <> ""
            If impersonateUser Then
                AliasAccount.BeginImpersonation(Me.UserName, Me.UserDomain, Me.UserPassword)
            End If
            Dim newFileStream As New FileStream(Me.Path & "\" & repositoryFilename, FileMode.OpenOrCreate, FileAccess.Read)
            Dim FileBytes(newFileStream.Length) As Byte
            ' Load the file into our byte array
            newFileStream.Read(FileBytes, 0, newFileStream.Length)
            newFileStream.Close()
            If impersonateUser Then
                AliasAccount.EndImpersonation()
            End If
            Return FileBytes
        Catch ex As Exception
            Throw New Exception("An error occured while trying to retrieve this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
        End Try
    End Function
    Public Function DeleteDocument(ByVal documentId As Integer, ByVal repositoryfilename As String) As Boolean
        Dim impersonateUser As Boolean
        Dim AliasAccount As AliasAccount
        'Dim DocumentName As String = Me.GetDocumentRepositoryFileName(documentId)
        Try
            impersonateUser = Me.UserName <> ""
            If impersonateUser Then
                AliasAccount.BeginImpersonation(Me.UserName, Me.UserDomain, Me.UserPassword)
            End If
            If File.Exists(Me.Path & "\" & repositoryfilename) Then
                File.Delete(Me.Path & "\" & repositoryfilename)
            End If
            Dim XMLFile As String = repositoryfilename & ".index.xml"
            If File.Exists(Me.Path & "\" & XMLFile) Then
                File.Delete(Me.Path & "\" & XMLFile)
            End If
            If impersonateUser Then
                AliasAccount.EndImpersonation()
            End If
            Return True
        Catch ex As Exception
            Throw New Exception("An error occured while trying to delete this document to the Webvantage document repository. Ensure that the document repository settings are correct.", ex)
        End Try
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#Region " Repository Limit "

    'For setting sizes, a NULL or minus 1 indicates no limits
    '1 kilobyte = 1024 bytes
    '1 megabytes = 1 048 576 bytes
    '1 gigabytes = 1 073 741 824 bytes
    Public Const KB As Long = 1024
    Public Const MB As Long = 1048576
    Public Const GB As Long = 1073741824
    Public Enum ByteDisplay
        Auto = 0
        Bytes = 1
        Kilobytes = 2
        Megabytes = 3
        Gigabytes = 4
    End Enum
    Private _isRepositoryLimitFeatureEnabled As Boolean = False
    Private _isOverRepositoryLimitSet As Boolean = False
    Private _fileSizeMax As Long = -1
    Private _repositoryMax As Long = -1
    Private _repositoryUsed As Long = -1
    Private _repositoryLeft As Long = -1
    Public Property IsOverRepositoryLimitSet() As Boolean
        Get
            Return _isOverRepositoryLimitSet
        End Get
        Set(ByVal value As Boolean)
            _isOverRepositoryLimitSet = value
        End Set
    End Property
    Public Property IsRepositoryLimitFeatureEnabled() As Boolean
        Get
            Return _isRepositoryLimitFeatureEnabled
        End Get
        Set(ByVal value As Boolean)
            _isRepositoryLimitFeatureEnabled = value
        End Set
    End Property
    Public Property FileSizeMax() As Long
        Get
            Return _fileSizeMax
        End Get
        Set(ByVal value As Long)
            _fileSizeMax = value
        End Set
    End Property
    Public Property RepositoryMax() As Long
        Get
            Return _repositoryMax
        End Get
        Set(ByVal value As Long)
            _repositoryMax = value
        End Set
    End Property
    Public Property RepositoryUsed() As Long
        Get
            Return _repositoryUsed
        End Get
        Set(ByVal value As Long)
            _repositoryUsed = value
        End Set
    End Property
    Public Property RepositoryLeft() As Long
        Get
            Return _repositoryLeft
        End Get
        Set(ByVal value As Long)
            _repositoryLeft = value
        End Set
    End Property
    Public Function GetRepositorySize() As Long
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Dim SessionKey As String = "RepositorySize"
            Dim RepositorySize As Long = -1
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    RepositorySize = CType(oSQL.ExecuteScalar(Me.ConnectionString, CommandType.Text, "SELECT ISNULL(SUM(CAST(FILE_SIZE AS BIGINT)),0) FROM DOCUMENTS WITH(NOLOCK) WHERE NOT FILE_SIZE IS NULL;"), Long)
                Catch ex As Exception
                    RepositorySize = -1
                End Try
                HttpContext.Current.Session(SessionKey) = RepositorySize
            Else
                RepositorySize = CType(HttpContext.Current.Session(SessionKey), Long)
            End If
            Return RepositorySize
        Else
            Return 0
        End If
    End Function
    'Get actual usage
    Public Function GetRepositoryUsage(ByVal DisplayIn As ByteDisplay, Optional ByRef Abbreviation As String = "") As Long
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Try
                Dim l As Long = Me.GetRepositorySize()
                Select Case DisplayIn
                    Case ByteDisplay.Auto
                        Dim j As Long = l
                        Abbreviation = "Bytes"
                        If l >= KB Then
                            j = l / KB
                            Abbreviation = "KB"
                        End If
                        If l >= MB Then
                            j = l / MB
                            Abbreviation = "MB"
                        End If
                        If l >= GB Then
                            j = l / GB
                            Abbreviation = "GB"
                        End If
                        l = j
                    Case ByteDisplay.Bytes
                        l = l
                        Abbreviation = "Bytes"
                    Case ByteDisplay.Kilobytes
                        l = l / KB
                        Abbreviation = "KB"
                    Case ByteDisplay.Megabytes
                        l = l / MB
                        Abbreviation = "MB"
                    Case ByteDisplay.Gigabytes
                        l = l / GB
                        Abbreviation = "GB"
                End Select
                l = CType(Math.Round(CType(l, Double), 2), Long)
                Return l
            Catch ex As Exception
                Return -2 'error
            End Try
        Else
            Return -1
        End If
    End Function
    'Public Function IsOverRepositoryLimit(Optional ByRef BytesLeftInRepository As Long = 0) As Boolean
    '    If Me.IsRepositoryLimitFeatureEnabled = False Then
    '        Return False
    '        Exit Function
    '    End If
    '    Dim RepositoryMax As Long = Me.GetRepositoryLimit(DocumentRepository.ByteDisplay.Bytes)
    '    If RepositoryMax < 0 Then 'no limits
    '        Return False
    '        Exit Function
    '    End If
    '    Dim RepositoryUsed As Long = Me.GetRepositorySize(DocumentRepository.ByteDisplay.Bytes)
    '    BytesLeftInRepository = RepositoryMax - RepositoryUsed
    '    If RepositoryUsed >= RepositoryMax Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Public Shared Function RadAsyncUploadFileTypeIsValid(ByVal File As Telerik.Web.UI.UploadedFile) As Boolean

        Dim IsValid As Boolean = True

        If AdvantageFramework.DocumentManager.BlackListedFileTypes().Contains(File.GetExtension) = True Then

            IsValid = False

        End If

        Return IsValid

    End Function
    Public Function SetRadAsyncUpload(ByRef AsyncUploadControl As Telerik.Web.UI.RadAsyncUpload, ByVal IsUsingRepository As Boolean, Optional ByRef LimitText As String = "") As Boolean

        Dim CanUpload As Boolean = True
        Dim TempPath As String = String.Empty

        Try

            TempPath = HttpContext.Current.Server.MapPath("~\") & System.Configuration.ConfigurationManager.AppSettings("RadAsyncUploadTemporaryFolder")

            If TempPath.IndexOf(":\") = -1 AndAlso TempPath.IndexOf("\\") = -1 Then 'not a full path or UNC path, stick it under WV

                TempPath = HttpContext.Current.Server.MapPath("~\") & TempPath

            End If

        Catch ex As Exception
            TempPath = String.Empty
        End Try

        With AsyncUploadControl

            .Enabled = True
            .AutoAddFileInputs = True
            .EnableAjaxSkinRendering = True
            .EnableEmbeddedScripts = True
            .EnableViewState = True
            .HideFileInput = False
            If String.IsNullOrWhiteSpace(TempPath) = False Then .TemporaryFolder = TempPath

        End With

        If IsUsingRepository = True Then

            If Me.GetFileSizeLimit > 0 Then

                AsyncUploadControl.MaxFileSize = Me.GetFileSizeLimit(ByteDisplay.Bytes)
                LimitText = Me.FileSizeLimitText
                AsyncUploadControl.OnClientValidationFailed = "RadAsyncUploadOnClientValidationFailed"

            End If
            If Me._isRepositoryLimitFeatureEnabled = True Then

                If Me._repositoryLeft <= 0 Then

                    LimitText = "Cannot upload files.  Repository is at capacity."
                    AsyncUploadControl.Enabled = False
                    CanUpload = False

                End If

            End If

        End If

        Return CanUpload

    End Function

    Private Function GetRepositoryLimit(Optional ByVal DisplayAs As ByteDisplay = ByteDisplay.Gigabytes) As Long
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Dim SessionKey As String = "RepositoryLimit"
            Dim RepositoryLimit As Long = -1
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim arP(1) As SqlParameter
                    Dim p0 As New SqlParameter("@TYPE", SqlDbType.SmallInt)
                    p0.Value = 0
                    arP(0) = p0
                    Dim divisor As Long
                    Select Case DisplayAs
                        Case ByteDisplay.Bytes, ByteDisplay.Auto
                            'in db as bytes
                            divisor = 1
                        Case ByteDisplay.Kilobytes
                            divisor = KB
                        Case ByteDisplay.Megabytes
                            divisor = MB
                        Case ByteDisplay.Gigabytes
                            divisor = GB
                    End Select
                    RepositoryLimit = CType(oSQL.ExecuteScalar(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_Limit_Get", arP), Long) / divisor
                Catch ex As Exception
                    RepositoryLimit = -1
                End Try
                HttpContext.Current.Session(SessionKey) = RepositoryLimit
            Else
                RepositoryLimit = CType(HttpContext.Current.Session(SessionKey), Long)
            End If
            Return RepositoryLimit
        Else
            Return 0
        End If
    End Function
    Public Function SaveRepositoryLimit(ByVal TheLimit As Long) As String
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Try
                Dim SessionKey As String = "RepositoryLimit"
                TheLimit = TheLimit * GB
                Dim arP(2) As SqlParameter
                Dim p0 As New SqlParameter("@TYPE", SqlDbType.SmallInt)
                p0.Value = 0
                arP(0) = p0
                Dim p1 As New SqlParameter("@LIMIT", SqlDbType.VarChar, 8000)
                p1.Value = TheLimit.ToString()
                arP(1) = p1
                oSQL.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_Limit_Set", arP)
                HttpContext.Current.Session(SessionKey) = Nothing
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        Else
            Return ""
        End If
    End Function
    Public Function SaveFileSizeLimit(ByVal TheLimit As Long) As String
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Try
                TheLimit = TheLimit * MB
                Dim arP(2) As SqlParameter
                Dim p0 As New SqlParameter("@TYPE", SqlDbType.SmallInt)
                p0.Value = 1
                arP(0) = p0
                Dim p1 As New SqlParameter("@LIMIT", SqlDbType.VarChar, 8000)
                p1.Value = TheLimit.ToString()
                arP(1) = p1
                oSQL.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_Limit_Set", arP)
                Dim SessionKey As String = "FileSizeLimit"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitAuto"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitBytes"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitKilobytes"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitMegabytes"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitGigabytes"
                HttpContext.Current.Session(SessionKey) = Nothing
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        Else
            Return ""
        End If
    End Function
    Public Function GetFileSizeLimit(Optional ByVal DisplayAs As ByteDisplay = ByteDisplay.Megabytes) As Long
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Dim FileSizeLimit As Long = -1
            Dim SessionKey As String = "FileSizeLimit" & DisplayAs.ToString()
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim arP(1) As SqlParameter
                    Dim p0 As New SqlParameter("@TYPE", SqlDbType.SmallInt)
                    p0.Value = 1
                    arP(0) = p0
                    Dim divisor As Long
                    Select Case DisplayAs
                        Case ByteDisplay.Bytes, ByteDisplay.Auto
                            'in db as bytes
                            divisor = 1
                        Case ByteDisplay.Kilobytes
                            divisor = KB
                        Case ByteDisplay.Megabytes
                            divisor = MB
                        Case ByteDisplay.Gigabytes
                            divisor = GB
                    End Select
                    FileSizeLimit = CType(oSQL.ExecuteScalar(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_Limit_Get", arP), Long) / divisor
                Catch ex As Exception
                    FileSizeLimit = -1
                End Try
                HttpContext.Current.Session(SessionKey) = FileSizeLimit
            Else
                FileSizeLimit = CType(HttpContext.Current.Session(SessionKey), Long)
            End If
            Return FileSizeLimit
        Else
            Return 0
        End If
    End Function
    Public Function FileSizeLimitText() As String
        If Me.IsOverRepositoryLimitSet = True Then
            Return "*The repository is full.  Files will not be uploaded!  Please contact an administrator."
        End If
        Dim l As Long = Me.FileSizeMax
        If l > 0 And l > Me.RepositoryLeft And Me.RepositoryLeft > 0 Then
            Return "*The file size limit exceeds the space left in the repository.  Files will not be uploaded!  Please contact an administrator."
        End If
        If l < 0 Then
            Return ""
        ElseIf l = 0 Then
            Return "*Upload file size is set to 0 MB.  Files will not be uploaded!  Please contact an administrator."
        ElseIf l > 0 Then
            Dim d As Long = Me.FileSizeMax / Me.MB
            Return "*Files larger than " & d.ToString() & "MB will automatically be excluded."
        End If
    End Function
    Public Structure FileCompare
        Public FileByteLength As Long
        Public FileSizeLimit As Long
        Public NormalizedFileSize As Long
        Public Difference As Long
        Public ReturnMessageHTML As String
        Public ReturnMessageJS As String
        Public IsOverRepositoryLimit As Boolean
        Public FileLimitExceedRemainingRepositorySpace As Boolean
    End Structure
    Public Function IsOverFileSizeLimit(ByRef fc As FileCompare,
    Optional ByVal DisplayAs As ByteDisplay = ByteDisplay.Megabytes) As Boolean
        If Me.IsRepositoryLimitFeatureEnabled = False Then
            With fc
                .FileSizeLimit = -1
                .NormalizedFileSize = -1
                .Difference = -1
                .ReturnMessageHTML = ""
                .ReturnMessageJS = ""
                .IsOverRepositoryLimit = False
                .FileLimitExceedRemainingRepositorySpace = False
            End With
            Return False
        End If
        'Comparison is done in bytes but give user option to return some data
        Dim limit As Long = Me.FileSizeMax
        Dim divisor As Long = 1
        Dim abrev As String = ""
        Select Case DisplayAs
            Case ByteDisplay.Bytes, ByteDisplay.Auto
                'in db as bytes
                divisor = 1
                abrev = "Bytes"
            Case ByteDisplay.Kilobytes
                divisor = KB
                abrev = "KB"
            Case ByteDisplay.Megabytes
                divisor = MB
                abrev = "MB"
            Case ByteDisplay.Gigabytes
                divisor = GB
                abrev = "GB"
        End Select
        'set the struct
        With fc
            If Me.FileSizeMax >= Me.RepositoryLeft Then
                .FileLimitExceedRemainingRepositorySpace = True
            Else
                .FileLimitExceedRemainingRepositorySpace = False
            End If
            .FileSizeLimit = limit / divisor
            .NormalizedFileSize = .FileByteLength / divisor
            .Difference = (.FileByteLength - limit) / divisor
            .IsOverRepositoryLimit = Me.IsOverRepositoryLimitSet
            If .IsOverRepositoryLimit = True Then
                .ReturnMessageHTML = "Repository limit has been reached."
                .ReturnMessageJS = "Repository limit has been reached."
            ElseIf limit > 0 And limit > Me.RepositoryLeft And .IsOverRepositoryLimit = False Then
                .ReturnMessageHTML = "The file size limit exceeds the space left in the repository."
                .ReturnMessageJS = "The file size limit exceeds the space left in the repository."
                .FileLimitExceedRemainingRepositorySpace = True
            ElseIf .FileByteLength > Me.FileSizeMax Then
                .ReturnMessageHTML = "File is too large.  Uploads are limited to " & .FileSizeLimit.ToString() & abrev & "."
                .ReturnMessageJS = "File is too large.  Uploads are limited to " & .FileSizeLimit.ToString() & abrev & "."
            End If
        End With
        'boolean return here
        If limit < 0 Or fc.FileByteLength = 0 Then 'no limits
            Return False
            Exit Function
        End If
        If fc.FileByteLength > limit Or fc.IsOverRepositoryLimit = True Or fc.FileLimitExceedRemainingRepositorySpace = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function RepositoryLimitFeatureIsEnabled() As Boolean
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 0 Then
            Return False
            Exit Function
        End If
        If Me.GetRepositoryLimit(ByteDisplay.Bytes) < 0 Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region
    Public Sub New(Optional ByVal connectionString As String = "", Optional ByVal InitRepositoryLimits As Boolean = False)
        If connectionString.Trim() <> "" Then
            Me.ConnectionString = connectionString
        Else
            Me.ConnectionString = HttpContext.Current.Session("ConnString")
        End If
        Try
            Dim RepositorySecuritySettings As New vDocumentRepositorySettings(Me.ConnectionString)
            RepositorySecuritySettings.LoadAll()
            Me.UserDomain = RepositorySecuritySettings.DOC_REPOSITORY_USER_DOMAIN
            Me.UserName = RepositorySecuritySettings.DOC_REPOSITORY_USER_NAME
            Me.UserPassword = AdvantageFramework.Security.Encryption.Decrypt(RepositorySecuritySettings.DOC_REPOSITORY_USER_PASSWORD)
            Me.Path = RepositorySecuritySettings.DOC_REPOSITORY_PATH
        Catch ex As Exception
            Throw ex
        End Try
        Try
            Me.IsRepositoryLimitFeatureEnabled = Me.RepositoryLimitFeatureIsEnabled
        Catch ex As Exception
            Me.IsRepositoryLimitFeatureEnabled = False
        End Try

        If InitRepositoryLimits = True Or Me.IsRepositoryLimitFeatureEnabled = True Then
            Try
                Me.FileSizeMax = Me.GetFileSizeLimit(ByteDisplay.Bytes)
                Me.RepositoryMax = Me.GetRepositoryLimit(ByteDisplay.Bytes)
                Me.RepositoryUsed = Me.GetRepositoryUsage(ByteDisplay.Bytes)
                Me.RepositoryLeft = Me.RepositoryMax - Me.RepositoryUsed
                If Me.RepositoryMax > 0 And Me.FileSizeMax > 0 Then
                    If (Me.RepositoryUsed >= Me.RepositoryMax) Then ' Or (Me.FileSizeMax > Me.RepositoryLeft) Then
                        Me.IsOverRepositoryLimitSet = True
                    Else
                        Me.IsOverRepositoryLimitSet = False
                    End If
                Else
                    Me.IsOverRepositoryLimitSet = False
                End If
            Catch ex As Exception
                Me.IsRepositoryLimitFeatureEnabled = False
                Me.FileSizeMax = -1
                Me.RepositoryMax = -1
                Me.RepositoryUsed = -1
                Me.IsOverRepositoryLimitSet = False
            End Try
        Else
            Me.IsRepositoryLimitFeatureEnabled = False
            Me.FileSizeMax = -1
            Me.RepositoryMax = -1
            Me.RepositoryUsed = -1
            Me.IsOverRepositoryLimitSet = False
        End If
    End Sub

#End Region

End Class
