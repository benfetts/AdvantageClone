
Imports AdvantageFramework.Database.Entities
Imports AdvantageFramework.Database.Interfaces
Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.IO

Namespace Repositories

    Public Class DocumentRepository
        Implements Interfaces.IDocumentRepository

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "
        Private _DataContext As AdvantageFramework.Database.DataContext = Nothing
#End Region

#Region " Properties "
        Public Property DataContext() As AdvantageFramework.Database.DataContext
            Get
                Return _DataContext
            End Get
            Set(ByVal value As AdvantageFramework.Database.DataContext)
                _DataContext = value
            End Set
        End Property
#End Region

#Region " Methods "
        Public Sub New()

        End Sub

        Public Sub New(DataContext As AdvantageFramework.Database.DataContext)
            Me.DataContext = DataContext
        End Sub

        Public Function Find(Id As Integer) As AdvantageFramework.Database.Entities.Document Implements Interfaces.IDocumentRepository.Find
            Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)
                Find = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).SingleOrDefault(Function(Doc) Doc.ID = Id)
            End Using
        End Function

        ''' <summary>
        ''' Legacy code - formatting not applied
        ''' </summary>
        ''' <param name="DocumentUpload"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertDocumentDatabaseRecord(ByVal DocumentUpload As ViewModels.DocumentUploadInfo) As ViewModels.DocumentUploadInfo Implements Interfaces.IDocumentRepository.InsertDocumentDatabaseRecord
            Try
                Dim parameterArray(10) As SqlParameter
                Dim mimeRepo As New MimeTypeRepository()

                Dim documentId As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
                Dim fileName As New SqlParameter("@FILENAME", SqlDbType.VarChar, 100)
                Dim repositoryName As New SqlParameter("@REPOSITORY_FILENAME", SqlDbType.VarChar, 200)
                Dim mimeType As New SqlParameter("@MIME_TYPE", SqlDbType.VarChar, 50)
                Dim description As New SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 200)
                Dim keywords As New SqlParameter("@KEYWORDS", SqlDbType.VarChar, 255)
                Dim uploadedDate As New SqlParameter("@UPLOADED_DATE", SqlDbType.DateTime)
                Dim userCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                Dim fileSize As New SqlParameter("@FILE_SIZE", SqlDbType.Int)

                Dim privateFlag As New SqlParameter("@PRIVATE_FLAG", SqlDbType.Int)
                Dim documentTypeId As New SqlParameter("@DOCUMENT_TYPE_ID", SqlDbType.Int)

                documentId.Direction = ParameterDirection.Output
                parameterArray(0) = documentId

                fileName.Value = DocumentUpload.FileName
                parameterArray(1) = fileName

                repositoryName.Value = DocumentUpload.RepositoryFilename
                parameterArray(2) = repositoryName

                If DocumentUpload.MimeType Is Nothing OrElse DocumentUpload.MimeType = String.Empty Then
                    DocumentUpload.MimeType = mimeRepo.GetContentType(DocumentUpload.FileName)
                End If
                mimeType.Value = DocumentUpload.MimeType
                parameterArray(3) = mimeType

                description.Value = DocumentUpload.Description
                parameterArray(4) = description

                keywords.Value = DocumentUpload.Keywords
                parameterArray(5) = keywords

                uploadedDate.Value = Date.Now
                parameterArray(6) = uploadedDate

                userCode.Value = DocumentUpload.UserCode
                parameterArray(7) = userCode

                fileSize.Value = DocumentUpload.FileSize
                parameterArray(8) = fileSize

                privateFlag.Value = DocumentUpload.PrivateFlag
                parameterArray(9) = privateFlag

                documentTypeId.Value = DocumentUpload.DocumentTypeId
                parameterArray(10) = documentTypeId

                Using cn As New SqlConnection(DataContext.Connection.ConnectionString)
                    Using cmd As New SqlCommand
                        With cmd
                            .Connection = cn
                            .Connection.Open()
                            .CommandText = "proc_DOCUMENTSInsert"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.AddRange(parameterArray)
                        End With

                        cmd.ExecuteScalar()
                    End Using
                End Using

                DocumentUpload.DocumentId = CType(documentId.Value, Integer)
                DocumentUpload.DatabaseInsertSuccessful = True

                InsertDocumentDatabaseRecord = DocumentUpload

            Catch ex As Exception
                DocumentUpload.DocumentId = -1
                DocumentUpload.DatabaseInsertSuccessful = False
                DocumentUpload.LastUploadException = ex

                InsertDocumentDatabaseRecord = DocumentUpload
            End Try
        End Function

        ''' <summary>
        ''' Legacy code - formatting not applied
        ''' </summary>
        ''' <param name="DocumentUpload"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertDocumentFileSystemRecord(ByVal DocumentUpload As ViewModels.DocumentUploadInfo) As ViewModels.DocumentUploadInfo Implements Interfaces.IDocumentRepository.InsertDocumentFileSystemRecord

            Try
                Dim AliasAccount As AliasAccount
                Dim IndexDocument As New System.Xml.XmlDocument
                Dim TemplateXML As New System.Text.StringBuilder
                Dim Encoding As New System.Text.ASCIIEncoding()
                Dim IndexDocumentText As String = String.Empty
                Dim IndexBytes() As Byte = Nothing


                If DocumentUpload.RepositoryFilename = String.Empty Then
                    DocumentUpload.RepositoryFilename = DocumentUpload.FilePrefix & Guid.NewGuid.ToString()
                End If

                TemplateXML.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                TemplateXML.AppendLine("<documents>")
                TemplateXML.AppendLine("<document filename="""" realfilename=""""  description="""" keywords="""" author="""" finallevel="""" finalleveldetail="""" ></document>")
                TemplateXML.AppendLine("</documents>")

                IndexDocument.LoadXml(TemplateXML.ToString())
                IndexDocument.SelectSingleNode("//documents/document").Attributes("filename").Value = DocumentUpload.RepositoryFilename
                IndexDocument.SelectSingleNode("//documents/document").Attributes("realfilename").Value = DocumentUpload.FileName
                IndexDocument.SelectSingleNode("//documents/document").Attributes("description").Value = DocumentUpload.Description
                IndexDocument.SelectSingleNode("//documents/document").Attributes("author").Value = DocumentUpload.AuthorName
                IndexDocument.SelectSingleNode("//documents/document").Attributes("keywords").Value = DocumentUpload.Keywords
                IndexDocument.SelectSingleNode("//documents/document").Attributes("finallevel").Value = DocumentUpload.FinalLevelID
                IndexDocument.SelectSingleNode("//documents/document").Attributes("finalleveldetail").Value = DocumentUpload.FinalLevelDescription
                IndexDocumentText = IndexDocument.OuterXml

                IndexBytes = Encoding.GetBytes(IndexDocumentText)

                If DocumentUpload.ImpersonatingUserName <> String.Empty Then
                    AliasAccount.BeginImpersonation(DocumentUpload.ImpersonatingUserName, DocumentUpload.ImpersonatingUserDomain, DocumentUpload.ImpersonatingUserPassword)
                End If
                Using newFileStream As New FileStream(DocumentUpload.Path & "\" & DocumentUpload.RepositoryFilename, FileMode.OpenOrCreate, FileAccess.Write)
                    newFileStream.Write(DocumentUpload.FileBytes, 0, DocumentUpload.FileBytes.Length)
                End Using

                Using newIndexFileStream As New FileStream(DocumentUpload.Path & "\" & DocumentUpload.RepositoryFilename & ".index.xml", FileMode.OpenOrCreate, FileAccess.Write)
                    newIndexFileStream.Write(IndexBytes, 0, IndexBytes.Length)
                End Using

                If DocumentUpload.ImpersonatingUserName <> String.Empty Then
                    AliasAccount.EndImpersonation()
                End If

                DocumentUpload.FileSystemCreateSuccessful = True

                InsertDocumentFileSystemRecord = DocumentUpload
            Catch ex As Exception
                DocumentUpload.LastUploadException = ex
                DocumentUpload.FileSystemCreateSuccessful = False
                InsertDocumentFileSystemRecord = DocumentUpload
            End Try
        End Function

        ''' <summary>
        ''' This method needs to be verified as to why the EF LinkDocumentToLevel code throws an error
        ''' Legacy code is being used in its place
        ''' </summary>
        ''' <param name="DocumentUpload"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LinkDocumentToLevel(ByVal DocumentUpload As ViewModels.DocumentUploadInfo) As ViewModels.DocumentUploadInfo Implements Interfaces.IDocumentRepository.LinkDocumentToLevel
            Try
                Dim EmployeeDocumentToLink As EmployeeDocument = Nothing
                Dim VendorDocumentToLink As VendorDocument = Nothing
                Dim AccountsReceivableEntity As AdvantageFramework.Database.Entities.AccountReceivable = Nothing
                Dim SQLQuery As String = Nothing

                Select Case DocumentUpload.Level
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation
                        EmployeeDocumentToLink = New EmployeeDocument() With {.DocumentID = DocumentUpload.DocumentId, .EmployeeCode = DocumentUpload.ForeignKey}

                        AdvantageFramework.Database.Procedures.EmployeeDocument.Insert(Me.DataContext, EmployeeDocumentToLink)
                        DocumentUpload.DocumentLinkSuccessful = True

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation

                        VendorDocumentToLink = New VendorDocument() With {.DocumentID = DocumentUpload.DocumentId, .VendorCode = DocumentUpload.ForeignKey}

                        AdvantageFramework.Database.Procedures.VendorDocument.Insert(Me.DataContext, VendorDocumentToLink)
                        DocumentUpload.DocumentLinkSuccessful = True

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation
                        SQLQuery = "INSERT INTO [dbo].[ARINV_DOCUMENT]" + vbCrLf _
                                                + "           ([DOCUMENT_ID]" + vbCrLf _
                                                + "           ,[AR_INV_NBR]" + vbCrLf _
                                                + "           ,[AR_INV_SEQ]" + vbCrLf _
                                                + "           ,[AR_TYPE])" + vbCrLf _
                                                + "     VALUES" + vbCrLf _
                                                + "           (@DOCUMENT_ID" + vbCrLf _
                                                + "           ,@AR_INV_NBR" + vbCrLf _
                                                + "           ,@AR_INV_SEQ" + vbCrLf _
                                                + "           ,@AR_TYPE)" + vbCrLf

                        Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)
                            AccountsReceivableEntity = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AccountReceivable).SingleOrDefault(Function(AccountsRec) AccountsRec.InvoiceNumber = DocumentUpload.ForeignKey)

                            Using SQLConnection As New SqlConnection(DataContext.Connection.ConnectionString)
                                Using SQLCommand As New SqlCommand
                                    With SQLCommand
                                        .Connection = SQLConnection
                                        .Connection.Open()
                                        .CommandText = SQLQuery
                                        .CommandType = CommandType.Text
                                        .Parameters.Add(New SqlParameter("@DOCUMENT_ID", DocumentUpload.DocumentId))
                                        .Parameters.Add(New SqlParameter("@AR_INV_NBR", AccountsReceivableEntity.InvoiceNumber))
                                        .Parameters.Add(New SqlParameter("@AR_INV_SEQ", AccountsReceivableEntity.SequenceNumber))
                                        .Parameters.Add(New SqlParameter("@AR_TYPE", "IN"))
                                    End With

                                    SQLCommand.ExecuteNonQuery()
                                End Using
                            End Using
                        End Using

                        ' The following code should work, but tries to put a null value into the ar document type
                        ' TODO: check if this is a database sync problem

                        '' BEGIN "Code that should work"

                        'Dim DocumentToLink As New AccountReceivableDocument
                        'DocumentToLink.DocumentID = DocumentUpload.DocumentId
                        'DocumentToLink.InvoiceNumber = DocumentUpload.ForeignKey

                        'Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)
                        '    Dim ar = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AccountReceivable).SingleOrDefault(Function(AccountsRec) AccountsRec.InvoiceNumber = DocumentUpload.ForeignKey)
                        '    Dim AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument = Nothing
                        '    AccountReceivableDocument = New AdvantageFramework.Database.Entities.AccountReceivableDocument

                        '    AccountReceivableDocument.DocumentID = DocumentToLink.DocumentID
                        '    AccountReceivableDocument.InvoiceNumber = Integer.Parse(DocumentUpload.ForeignKey)
                        '    AccountReceivableDocument.SequenceNumber = ar.SequenceNumber
                        '    AccountReceivableDocument.Type = "IN" ' ar.Type

                        '    AdvantageFramework.Database.Procedures.AccountReceivableDocument.Insert(DbContext, DocumentToLink)

                        'End Using

                        '' END "Code that should work"
                        DocumentUpload.DocumentLinkSuccessful = True
                End Select
            Catch RepositoryException As Exception
                DocumentUpload.DocumentLinkSuccessful = False
                DocumentUpload.LastUploadException = RepositoryException
            End Try

            LinkDocumentToLevel = DocumentUpload

        End Function

        Public Function InsertAndLinkDocumentToLevel(UploadInfo As ViewModels.DocumentUploadInfo) As ViewModels.DocumentUploadInfo Implements Interfaces.IDocumentRepository.InsertAndLinkDocumentToLevel
            UploadInfo = InsertDocumentDatabaseRecord(UploadInfo)

            If UploadInfo.DatabaseInsertSuccessful Then
                UploadInfo = LinkDocumentToLevel(UploadInfo)
            End If

            InsertAndLinkDocumentToLevel = UploadInfo
        End Function

        Public Function FindDocumentsByLevel(Level As String, LevelKeyValue As String) As List(Of AdvantageFramework.Database.Entities.Document) Implements Interfaces.IDocumentRepository.FindDocumentsByLevel
            Dim DocumentResults As System.Linq.IQueryable(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentIds As List(Of Integer) = Nothing
            Dim EmployeeIds As List(Of Long) = Nothing
            Dim VendorIds As List(Of Long) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)
                Select Case Level
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation

                        DocumentIds = (From ARDocs In DbContext.AccountReceivableDocuments
                                       Where ARDocs.InvoiceNumber = LevelKeyValue
                                       Select ARDocs.DocumentID).ToList()

                        DocumentResults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(Document) DocumentIds.Contains(Document.ID))
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation

                        EmployeeIds = (From EmployeeDocs In _DataContext.EmployeeDocuments
                                       Where EmployeeDocs.EmployeeCode = LevelKeyValue
                                       Select EmployeeDocs.DocumentID).ToList()
                        DocumentResults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(Document) EmployeeIds.Contains(Document.ID))
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation
                        VendorIds = (From VendorDocs In _DataContext.VendorDocuments
                                     Where VendorDocs.VendorCode = LevelKeyValue
                                     Select VendorDocs.DocumentID).ToList()

                        DocumentResults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(DocumentResult) VendorIds.Contains(DocumentResult.ID))
                End Select
            End Using

            FindDocumentsByLevel = DocumentResults.ToList()
        End Function

        Public Function FindDocumentHistory(Level As String, LevelKey As String, FileName As String) As List(Of ViewModels.DocumentUploadGridItem) Implements Interfaces.IDocumentRepository.FindDocumentHistory
            Dim ViewModelResults As List(Of ViewModels.DocumentUploadGridItem) = Nothing
            Dim ARInvoiceDocumentIds As List(Of Integer) = Nothing
            Dim AccountsReceivableDocuments As IQueryable(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim EmployeeDocuments As IQueryable(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim VendorDocuments As IQueryable(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim EmployeeDocumentIds As List(Of Long) = Nothing
            Dim VendorDocumentIds As List(Of Long) = Nothing

            ViewModelResults = New List(Of ViewModels.DocumentUploadGridItem)

            Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)
                Select Case Level
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation

                        ARInvoiceDocumentIds = (From ARDocs In DbContext.AccountReceivableDocuments
                                                Where ARDocs.InvoiceNumber = LevelKey
                                                Select ARDocs.DocumentID).ToList()

                        AccountsReceivableDocuments = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(ARDoc) ARInvoiceDocumentIds.Contains(ARDoc.ID) And ARDoc.FileName = FileName).OrderByDescending(Function(ARDoc) ARDoc.UploadedDate)

                        For Each DocumentResult In AccountsReceivableDocuments
                            ViewModelResults.Add(New ViewModels.DocumentUploadGridItem(DocumentResult, Level))
                        Next
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation

                        EmployeeDocumentIds = (From EmployeeDocs In _DataContext.EmployeeDocuments
                                               Where EmployeeDocs.EmployeeCode = LevelKey
                                               Select EmployeeDocs.DocumentID).ToList()

                        EmployeeDocuments = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(EmployeeDoc) EmployeeDocumentIds.Contains(EmployeeDoc.ID) And EmployeeDoc.FileName = FileName).OrderByDescending(Function(EmployeeDoc) EmployeeDoc.UploadedDate)

                        For Each DocumentResult In EmployeeDocuments
                            ViewModelResults.Add(New ViewModels.DocumentUploadGridItem(DocumentResult, Level))
                        Next
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation
                        VendorDocumentIds = (From VendorDocs In _DataContext.VendorDocuments
                                             Where VendorDocs.VendorCode = LevelKey
                                             Select VendorDocs.DocumentID).ToList()

                        VendorDocuments = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(VendorDoc) VendorDocumentIds.Contains(VendorDoc.ID) And VendorDoc.FileName = FileName).OrderByDescending(Function(VendorDoc) VendorDoc.UploadedDate)

                        For Each DocumentResult In VendorDocuments
                            ViewModelResults.Add(New ViewModels.DocumentUploadGridItem(DocumentResult, Level))
                        Next
                End Select
            End Using

            FindDocumentHistory = ViewModelResults
        End Function

        Public Function FindDocumentGridItemsByLevel(Level As String, LevelKeyValue As String) As List(Of ViewModels.DocumentUploadGridItem) Implements Interfaces.IDocumentRepository.FindDocumentGridItemsByLevel
            Dim ViewModelResults As List(Of ViewModels.DocumentUploadGridItem) = Nothing
            Dim DocumentIds As List(Of Integer) = Nothing
            Dim VendorIds As List(Of Long) = Nothing
            Dim EmployeeIds As List(Of Long) = Nothing

            ViewModelResults = New List(Of ViewModels.DocumentUploadGridItem)

            Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)
                Select Case Level
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation

                        DocumentIds = (From ARDoc In DbContext.AccountReceivableDocuments
                                       Where ARDoc.InvoiceNumber = LevelKeyValue
                                       Select ARDoc.DocumentID).ToList()

                        For Each DocumentResult In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(ARDocs) DocumentIds.Contains(ARDocs.ID)).OrderByDescending(Function(ARDocs) ARDocs.UploadedDate)
                            If ViewModelResults.Any(Function(ARDoc) ARDoc.FILENAME = DocumentResult.FileName) = False Then
                                ViewModelResults.Add(New ViewModels.DocumentUploadGridItem(DocumentResult, Level))
                            End If

                        Next
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation
                        EmployeeIds = (From EmployeeDoc In _DataContext.EmployeeDocuments
                                       Where EmployeeDoc.EmployeeCode = LevelKeyValue
                                       Select EmployeeDoc.DocumentID).ToList()

                        For Each DocumentResult In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(EmployeeDoc) EmployeeIds.Contains(EmployeeDoc.ID)).OrderByDescending(Function(EmployeeDoc) EmployeeDoc.UploadedDate)
                            If ViewModelResults.Any(Function(EmployeeDoc) EmployeeDoc.FILENAME = DocumentResult.FileName) = False Then
                                ViewModelResults.Add(New ViewModels.DocumentUploadGridItem(DocumentResult, Level))
                            End If
                        Next
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation
                        VendorIds = (From VendorDoc In _DataContext.VendorDocuments
                                     Where VendorDoc.VendorCode = LevelKeyValue
                                     Select VendorDoc.DocumentID).ToList()

                        For Each VendorDocumentResult In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Document).Where(Function(VendorDoc) VendorIds.Contains(VendorDoc.ID)).OrderByDescending(Function(VendorDoc) VendorDoc.UploadedDate)
                            If ViewModelResults.Any(Function(VendorDocResult) VendorDocResult.FILENAME = VendorDocumentResult.FileName) = False Then
                                ViewModelResults.Add(New ViewModels.DocumentUploadGridItem(VendorDocumentResult, Level))
                            End If
                        Next
                End Select
            End Using

            FindDocumentGridItemsByLevel = ViewModelResults
        End Function

        Public Function DeleteDocumentByLevel(UploadLevel As String, DocumentId As Long) As Boolean Implements Interfaces.IDocumentRepository.DeleteDocumentByLevel
            Dim DeleteSuccessful As Boolean = Nothing
            Dim VendorDocumentToDelete As VendorDocument = Nothing
            Dim EmployeeDocumentToDelete As EmployeeDocument = Nothing
            Dim ARDocumentToDelete As AccountReceivableDocument = Nothing

            DeleteSuccessful = False

            Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)
                Select Case UploadLevel
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation
                        VendorDocumentToDelete = DataContext.VendorDocuments.FirstOrDefault(Function(DeleteDoc) DeleteDoc.DocumentID = DocumentId)
                        If IsNothing(VendorDocumentToDelete) = False Then
                            DataContext.VendorDocuments.DeleteOnSubmit(VendorDocumentToDelete)
                            DataContext.SubmitChanges()
                        End If
                        DeleteSuccessful = True
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation
                        EmployeeDocumentToDelete = DataContext.EmployeeDocuments.FirstOrDefault(Function(DeleteDoc) DeleteDoc.DocumentID = DocumentId)
                        If IsNothing(EmployeeDocumentToDelete) = False Then
                            DataContext.EmployeeDocuments.DeleteOnSubmit(EmployeeDocumentToDelete)
                            DataContext.SubmitChanges()
                        End If
                        DeleteSuccessful = True
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation
                        ARDocumentToDelete = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AccountReceivableDocument).FirstOrDefault(Function(DeleteDoc) DeleteDoc.DocumentID = DocumentId)
                        If IsNothing(ARDocumentToDelete) = False Then
                            DbContext.AccountReceivableDocuments.Attach(ARDocumentToDelete)
                            DbContext.AccountReceivableDocuments.Remove(ARDocumentToDelete)
                            DbContext.SaveChanges()
                        End If
                        DeleteSuccessful = True
                    Case Else
                        Throw New Exception(String.Format("DocumentRepository - DeleteDocumentByLevel not implemented for level '{0}'", UploadLevel))
                End Select
            End Using

            DeleteDocumentByLevel = DeleteSuccessful
        End Function
#End Region


    End Class

End Namespace
