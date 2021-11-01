Partial Public Class Documents_History
    Inherits Webvantage.BaseChildPage

    Private FileName As String
    Private Level As String
    Private DOLevel As String
    Private ForiegnKey As String
    Private ConnectionString As String

    Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
    'Private _Parameters As AdvantageFramework.Web.QueryString = New AdvantageFramework.Web.QueryString()
    Private _GridLoadedFromFramework As Boolean = False
    Private _DocumentID As Integer = 0
    Private _AlertID As Integer = 0

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.ConnectionString = Session("ConnString")

        If Request.QueryString("Level") IsNot Nothing AndAlso Request.QueryString("Level").ToString().Trim() <> "" Then

            Me.Level = Request.QueryString("Level")

        Else

            If Session("DocFilterLevel") IsNot Nothing AndAlso Session("DocFilterLevel").ToString().Trim() <> "" Then

                Me.Level = Session("DocFilterLevel")

            End If

        End If

        If Request.QueryString("DOLevel") IsNot Nothing AndAlso Request.QueryString("DOLevel").ToString().Trim() <> "" Then

            Me.DOLevel = Request.QueryString("DOLevel")

        Else

            If Session("DocDOFilterLevel") IsNot Nothing AndAlso Session("DocDOFilterLevel").ToString().Trim() <> "" Then

                Me.DOLevel = Session("DocDOFilterLevel")

            End If

        End If

        If Request.QueryString("filename") IsNot Nothing AndAlso Request.QueryString("filename").ToString().Trim() <> "" Then

            Me.FileName = HttpUtility.UrlDecode(Request.QueryString("filename"))

        Else

        End If

        If Request.QueryString("FK") IsNot Nothing And Request.QueryString("FK").ToString().Trim() <> "" Then

            Me.ForiegnKey = Request.QueryString("FK")

        Else

            If Session("HistoryFK") IsNot Nothing AndAlso Session("HistoryFK").ToString().Trim() <> "" Then

                Me.ForiegnKey = Session("HistoryFK")

            End If

        End If

        If Me.CurrentQuerystring.DocumentID > 0 Then Me._DocumentID = Me.CurrentQuerystring.DocumentID

        If Me.CurrentQuerystring.AlertID > 0 Then Me._AlertID = Me.CurrentQuerystring.AlertID

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim IsProofHQEnabled As Boolean = False
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        If Not Me.IsPostBack Then

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
            End Using

            Me.DocumentHistoryRadGrid.MasterTableView.SortExpressions.AddSortExpression("UPLOADED_DATE DESC")

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                IsProofHQEnabled = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

                If IsProofHQEnabled AndAlso Me.IsClientPortal = False AndAlso Agency.AllowProofHQ = True Then

                    GridColumn = DocumentHistoryRadGrid.MasterTableView.GetColumn("GridTemplateColumnProofHQ")

                    If GridColumn IsNot Nothing Then

                        GridColumn.Visible = True

                    End If

                End If

            End Using

        End If

    End Sub

    Private Sub DocumentHistoryRadGrid_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles DocumentHistoryRadGrid.ItemCommand


        If e.Item Is Nothing Then Exit Sub

        'objects
        Dim DocumentEntity As AdvantageFramework.Database.Entities.Document = Nothing

        Select Case e.CommandName
            Case "Download"
                Dim DocumentId As Integer = CInt(e.CommandArgument)
                Dim Document As New Document(Me.ConnectionString)
                Document.LoadByPrimaryKey(DocumentId)

                Dim RealFilename As String
                Dim DocumentRepository As New DocumentRepository(Me.ConnectionString)
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    DocumentEntity = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, e.CommandArgument)
                    If DocumentEntity IsNot Nothing Then
                        RealFilename = DocumentEntity.FileName  ' Filename
                    End If
                End Using


                Dim MimeType As String
                Try
                    MimeType = Document.MIME_TYPE
                Catch ex As Exception
                    MimeType = String.Empty
                End Try

                Try
                    Dim FileBytes() As Byte = DocumentRepository.GetDocument(DocumentId)
                    HttpContext.Current.Response.Buffer = True
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" & RealFilename)
                    HttpContext.Current.Response.AddHeader("Content-Length", FileBytes.Length.ToString())
                    HttpContext.Current.Response.ContentType = MimeType
                    HttpContext.Current.Response.BinaryWrite(FileBytes)
                    HttpContext.Current.Response.Flush()
                    HttpContext.Current.Response.End()
                    HttpContext.Current.Response.Clear()
                    'Dim file() As String = RealFilename.Split(".")
                    '' Send the file to the user's browser
                    'Response.Buffer = True
                    'Response.AddHeader("Content-Disposition", "attachment;filename=" & RealFilename.Substring(0, RealFilename.Length - 4) & " " & DocumentEntity.UPLOADED_DATE.ToString.Replace("/", "-") & "." & file(1))
                    'Response.ContentType = MimeType
                    'Response.BinaryWrite(FileBytes)
                    'Response.Flush()

                Catch ex As Exception
                    HttpContext.Current.Response.End()
                    HttpContext.Current.Response.Clear()
                End Try

            Case "AddComments"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DocumentEntity = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, e.CommandArgument)

                    If DocumentEntity IsNot Nothing Then

                        If DocumentEntity.FileName.ToUpper.EndsWith(".PDF") Then

                            Me.OpenWindow(DocumentEntity.FileName, "Documents_PDFViewer.aspx?DocumentID=" & DocumentEntity.ID & "&PageNumber=1", 800, 1200)

                        ElseIf DocumentEntity.FileName.ToUpper.EndsWith(".DOC") OrElse DocumentEntity.FileName.ToUpper.EndsWith(".DOCX") Then

                            Me.OpenWindow(DocumentEntity.FileName, "Documents_WordViewer.aspx?DocumentID=" & DocumentEntity.ID & "&PageNumber=1", 800, 1200)

                        ElseIf DocumentEntity.FileName.ToUpper.EndsWith(".GIF") OrElse DocumentEntity.FileName.ToUpper.EndsWith(".JPEG") OrElse
                                DocumentEntity.FileName.ToUpper.EndsWith(".PJPEG") OrElse DocumentEntity.FileName.ToUpper.EndsWith(".PNG") OrElse
                                DocumentEntity.FileName.ToUpper.EndsWith(".JPG") OrElse DocumentEntity.FileName.ToUpper.EndsWith(".TIFF") OrElse
                                DocumentEntity.FileName.ToUpper.EndsWith(".BMP") Then

                            Me.OpenWindow(DocumentEntity.FileName, "Documents_ImageViewer.aspx?DocumentID=" & DocumentEntity.ID & "&PageNumber=1", 800, 1200)

                        ElseIf DocumentEntity.FileName.ToUpper.EndsWith(".MSG") Then

                            Me.OpenWindow(DocumentEntity.FileName, "Documents_MSGViewer.aspx?DocumentID=" & DocumentEntity.ID & "&PageNumber=1", 800, 1200)

                        ElseIf DocumentEntity.FileName.ToUpper.Contains(".XLS") OrElse DocumentEntity.FileName.ToUpper.Contains(".XLSX") Then

                            Me.OpenWindow(DocumentEntity.FileName, "Documents_ExcelViewer.aspx?DocumentID=" & DocumentEntity.ID & "&PageNumber=0", 800, 1200)

                        End If

                    End If

                End Using

            Case "ProofHQLink"

                Me.AddJavascriptToPage(String.Format("window.open('{0}', '_blank');", e.CommandArgument))

        End Select
    End Sub

    Private Sub DocumentHistoryRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles DocumentHistoryRadGrid.ItemDataBound


        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)
            Dim MimeType As String = ""
            Dim FileName As String = ""
            Dim Description As String = ""
            Dim RepositoryFilename As String = ""
            Dim FileSize As Double = 0
            Dim DocumentId As Integer = 0
            Dim ProofHQUrl As String = ""

            If e.Item.DataItem.GetType().ToString() = GetType(Webvantage.ViewModels.DocumentUploadGridItem).ToString() Then
                Dim viewModel As ViewModels.DocumentUploadGridItem = Nothing
                viewModel = DirectCast(e.Item.DataItem, ViewModels.DocumentUploadGridItem)

                Try

                    Description = viewModel.DOCUMENT_TYPE_DESC

                Catch ex As Exception
                    Description = ""
                End Try
                DocumentId = viewModel.DOCUMENT_ID
                Try

                    FileName = viewModel.FILENAME

                Catch ex As Exception
                    FileName = ""
                End Try
                FileSize = viewModel.FILE_SIZE
                MimeType = viewModel.MIME_TYPE
                ProofHQUrl = viewModel.PROOFHQ_URL
                RepositoryFilename = viewModel.REPOSITORY_FILENAME
            Else
                If Me._GridLoadedFromFramework = False Then

                    DocumentId = CurrentGridRow.DataItem("DOCUMENT_ID")
                    FileName = CurrentGridRow.DataItem("FILENAME")
                    FileSize = CurrentGridRow.DataItem("FILE_SIZE")
                    MimeType = CurrentGridRow.DataItem("MIME_TYPE")
                    RepositoryFilename = CurrentGridRow.DataItem("REPOSITORY_FILENAME")

                    If IsDBNull(CurrentGridRow.DataItem("PROOFHQ_URL")) = False Then

                        ProofHQUrl = CurrentGridRow.DataItem("PROOFHQ_URL")

                    End If
                Else

                    DocumentId = CurrentGridRow.DataItem.DOCUMENT_ID
                    FileName = CurrentGridRow.DataItem.FILENAME
                    FileSize = CurrentGridRow.DataItem.FILE_SIZE
                    MimeType = CurrentGridRow.DataItem.MIME_TYPE
                    RepositoryFilename = CurrentGridRow.DataItem.REPOSITORY_FILENAME

                    If IsDBNull(CurrentGridRow.DataItem.PROOFHQ_URL) = False Then

                        ProofHQUrl = CurrentGridRow.DataItem.PROOFHQ_URL

                    End If

                End If
            End If

            AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(Nothing,
                                                                                   DirectCast(e.Item.FindControl("LinkButtonDownload"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                   Nothing, Nothing,
                                                                                   Nothing, Nothing,
                                                                                   DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivProofHQ"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonProofHQ"), LinkButton), ProofHQUrl,
                                                                                   CurrentGridRow("GridBoundColumnFileSize").Text,
                                                                                   DocumentId, MimeType, FileName, RepositoryFilename, Description, FileSize,
                                                                                   "", "", 0)

        End If

    End Sub


    Private Sub DocumentHistoryRadGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles DocumentHistoryRadGrid.NeedDataSource

        Dim qs As New AdvantageFramework.Web.QueryString()
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim ClientDocument As AdvantageFramework.Database.Entities.ClientDocument = Nothing
        Dim ClientRelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ClientDocument) = Nothing
        Dim DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument = Nothing
        Dim DivisionRelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.DivisionDocument) = Nothing
        Dim ProductDocument As AdvantageFramework.Database.Entities.ProductDocument = Nothing
        Dim ProductRelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ProductDocument) = Nothing
        Dim ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument = Nothing
        Dim ContractReportRelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractReportDocument) = Nothing
        Dim JobComponentTaskDocument As AdvantageFramework.Database.Entities.JobComponentTaskDocument = Nothing
        Dim JobComponentTaskRelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument) = Nothing
        Dim AlertAttachments As Generic.List(Of AdvantageFramework.Database.Entities.AlertAttachment) = Nothing
        Dim DocumentIDs() As Integer = Nothing

        qs = qs.FromCurrent()

        Try

            If qs.DocumentLevel = Nothing Then

                If Me.Level <> "AT" Then

                    GetDocumentHistory() 'Old

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If Me._AlertID = 0 Then

                            If IsNumeric(Me.ForiegnKey) AndAlso CInt(Me.ForiegnKey) > 0 Then

                                Me._AlertID = CInt(Me.ForiegnKey)

                            End If

                        End If

                        If Me._AlertID > 0 Then

                            DocumentIDs = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, Me._AlertID).Select(Function(Entity) Entity.DocumentID).ToArray

                            Me.DocumentHistoryRadGrid.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                                                    Where DocumentIDs.Any(Function(DocumentID) DocumentID = Entity.ID) AndAlso
                                                                          Entity.FileName = Me.FileName
                                                                    Select [FILENAME] = Entity.FileName,
                                                                           [DESCRIPTION] = Entity.Description,
                                                                           FILE_SIZE = Entity.FileSize,
                                                                           USER_NAME = Entity.UserCode,
                                                                           UPLOADED_DATE = Entity.UploadedDate,
                                                                           MIME_TYPE = Entity.MIMEType,
                                                                           REPOSITORY_FILENAME = Entity.FileSystemFileName,
                                                                           DOCUMENT_ID = Entity.ID,
                                                                           PROOFHQ_URL = Entity.ProofHQUrl).ToList()

                            Me._GridLoadedFromFramework = True

                        Else

                            GetDocumentHistory() 'Old

                        End If

                    End Using

                End If

            Else

                If qs.DocumentID > 0 Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Select Case qs.DocumentLevel

                            Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                                Dim a As AdvantageFramework.Database.Entities.AccountReceivableDocument
                                Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AccountReceivableDocument) = Nothing

                                a = AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadByDocumentID(DbContext, qs.DocumentID)

                                If Not a Is Nothing Then

                                    Me.DocumentHistoryRadGrid.DataSource =
                                      (From d In AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadRelated(DbContext, a.InvoiceNumber, a.SequenceNumber, a.Type, a.Document.FileName).ToList()
                                       Select [FILENAME] = d.Document.FileName,
                                              [DESCRIPTION] = d.Document.Description,
                                              FILE_SIZE = d.Document.FileSize,
                                              USER_NAME = d.Document.UserCode,
                                              UPLOADED_DATE = d.Document.UploadedDate,
                                              MIME_TYPE = d.Document.MIMEType,
                                              REPOSITORY_FILENAME = d.Document.FileSystemFileName,
                                              DOCUMENT_ID = d.Document.ID,
                                              PROOFHQ_URL = d.Document.ProofHQUrl).ToList()

                                    Me._GridLoadedFromFramework = True

                                End If

                            Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

                                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, qs.DocumentID)

                                If Document IsNot Nothing Then

                                    Me.DocumentHistoryRadGrid.DataSource =
                                      (From Entity In AdvantageFramework.Database.Procedures.ContractDocument.LoadRelated(DbContext, Request.QueryString("contract_id"), Document.FileName).ToList()
                                       Select [FILENAME] = Entity.Document.FileName,
                                              [DESCRIPTION] = Entity.Document.Description,
                                              FILE_SIZE = Entity.Document.FileSize,
                                              USER_NAME = Entity.Document.UserCode,
                                              UPLOADED_DATE = Entity.Document.UploadedDate,
                                              MIME_TYPE = Entity.Document.MIMEType,
                                              REPOSITORY_FILENAME = Entity.Document.FileSystemFileName,
                                              DOCUMENT_ID = Entity.Document.ID,
                                              PROOFHQ_URL = Entity.Document.ProofHQUrl).ToList()

                                    Me._GridLoadedFromFramework = True

                                End If

                            Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, qs.DocumentID)

                                    If Document IsNot Nothing Then

                                        ContractReportRelatedDocuments = AdvantageFramework.Database.Procedures.ContractReportDocument.LoadRelated(DataContext, Request.QueryString("contract_report_id"), Document.FileName).ToList

                                        Me.DocumentHistoryRadGrid.DataSource =
                                           (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where DirectCast(ContractReportRelatedDocuments, Generic.List(Of AdvantageFramework.Database.Entities.ContractReportDocument)).Any(Function(ContractReportDoc) ContractReportDoc.DocumentID = Entity.ID)
                                            Select [FILENAME] = Entity.FileName,
                                                   [DESCRIPTION] = Entity.Description,
                                                   FILE_SIZE = Entity.FileSize,
                                                   USER_NAME = Entity.UserCode,
                                                   UPLOADED_DATE = Entity.UploadedDate,
                                                   MIME_TYPE = Entity.MIMEType,
                                                   REPOSITORY_FILENAME = Entity.FileSystemFileName,
                                                   DOCUMENT_ID = Entity.ID,
                                                   PROOFHQ_URL = Entity.ProofHQUrl).ToList()

                                        Me._GridLoadedFromFramework = True

                                    End If

                                End Using

                            Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, qs.DocumentID)

                                    ClientDocument = AdvantageFramework.Database.Procedures.ClientDocument.LoadByDocumentID(DataContext, qs.DocumentID)

                                    ClientRelatedDocuments = AdvantageFramework.Database.Procedures.ClientDocument.LoadRelated(DataContext, ClientDocument.ClientCode, Document.FileName).ToList

                                    Me.DocumentHistoryRadGrid.DataSource =
                                      (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                       Where DirectCast(ClientRelatedDocuments, Generic.List(Of AdvantageFramework.Database.Entities.ClientDocument)).Any(Function(ClientDoc) ClientDoc.DocumentID = Entity.ID)
                                       Select [FILENAME] = Entity.FileName,
                                              [DESCRIPTION] = Entity.Description,
                                              FILE_SIZE = Entity.FileSize,
                                              USER_NAME = Entity.UserCode,
                                              UPLOADED_DATE = Entity.UploadedDate,
                                              MIME_TYPE = Entity.MIMEType,
                                              REPOSITORY_FILENAME = Entity.FileSystemFileName,
                                              DOCUMENT_ID = Entity.ID,
                                              PROOFHQ_URL = Entity.ProofHQUrl).ToList()

                                    Me._GridLoadedFromFramework = True

                                End Using

                            Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, qs.DocumentID)

                                    DivisionDocument = AdvantageFramework.Database.Procedures.DivisionDocument.LoadByDocumentID(DataContext, Document.ID)

                                    DivisionRelatedDocuments = AdvantageFramework.Database.Procedures.DivisionDocument.LoadRelated(DataContext, DivisionDocument.ClientCode, DivisionDocument.DivisionCode, Document.FileName).ToList

                                    Me.DocumentHistoryRadGrid.DataSource =
                                        (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                         Where DirectCast(DivisionRelatedDocuments, Generic.List(Of AdvantageFramework.Database.Entities.DivisionDocument)).Any(Function(DivisionDoc) DivisionDoc.DocumentID = Entity.ID)
                                         Select [FILENAME] = Entity.FileName,
                                                [DESCRIPTION] = Entity.Description,
                                                FILE_SIZE = Entity.FileSize,
                                                USER_NAME = Entity.UserCode,
                                                UPLOADED_DATE = Entity.UploadedDate,
                                                MIME_TYPE = Entity.MIMEType,
                                                REPOSITORY_FILENAME = Entity.FileSystemFileName,
                                                DOCUMENT_ID = Entity.ID,
                                                PROOFHQ_URL = Entity.ProofHQUrl).ToList()

                                    Me._GridLoadedFromFramework = True

                                End Using

                            Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, qs.DocumentID)

                                    ProductDocument = AdvantageFramework.Database.Procedures.ProductDocument.LoadByDocumentID(DataContext, Document.ID)

                                    ProductRelatedDocuments = AdvantageFramework.Database.Procedures.ProductDocument.LoadRelated(DataContext, ProductDocument.ClientCode, ProductDocument.DivisionCode, ProductDocument.ProductCode, Document.FileName).ToList

                                    Me.DocumentHistoryRadGrid.DataSource =
                                        (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                         Where DirectCast(ProductRelatedDocuments, Generic.List(Of AdvantageFramework.Database.Entities.ProductDocument)).Any(Function(ProductDoc) ProductDoc.DocumentID = Entity.ID)
                                         Select [FILENAME] = Entity.FileName,
                                                [DESCRIPTION] = Entity.Description,
                                                FILE_SIZE = Entity.FileSize,
                                                USER_NAME = Entity.UserCode,
                                                UPLOADED_DATE = Entity.UploadedDate,
                                                MIME_TYPE = Entity.MIMEType,
                                                REPOSITORY_FILENAME = Entity.FileSystemFileName,
                                                DOCUMENT_ID = Entity.ID,
                                                PROOFHQ_URL = Entity.ProofHQUrl).ToList()

                                    Me._GridLoadedFromFramework = True

                                End Using

                            Case AdvantageFramework.Database.Entities.DocumentLevel.Task

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, qs.DocumentID)

                                    JobComponentTaskDocument = AdvantageFramework.Database.Procedures.JobComponentTaskDocument.LoadByDocumentID(DataContext, Document.ID)

                                    JobComponentTaskRelatedDocuments = AdvantageFramework.Database.Procedures.JobComponentTaskDocument.LoadRelated(DataContext, JobComponentTaskDocument.JobNumber, JobComponentTaskDocument.JobComponentNumber, JobComponentTaskDocument.SequenceNumber, Document.FileName).ToList

                                    Me.DocumentHistoryRadGrid.DataSource =
                                        (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                         Where DirectCast(JobComponentTaskRelatedDocuments, Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument)).Any(Function(ProductDoc) ProductDoc.DocumentID = Entity.ID)
                                         Select [FILENAME] = Entity.FileName,
                                                [DESCRIPTION] = Entity.Description,
                                                FILE_SIZE = Entity.FileSize,
                                                USER_NAME = Entity.UserCode,
                                                UPLOADED_DATE = Entity.UploadedDate,
                                                MIME_TYPE = Entity.MIMEType,
                                                REPOSITORY_FILENAME = Entity.FileSystemFileName,
                                                DOCUMENT_ID = Entity.ID,
                                                PROOFHQ_URL = Entity.ProofHQUrl).ToList()

                                    Me._GridLoadedFromFramework = True

                                End Using

                        End Select

                    End Using

                End If

            End If

        Catch ex As Exception

            Me.DocumentHistoryRadGrid.DataSource = Nothing

        End Try
    End Sub

    Private Sub GetDocumentHistory()

        Dim accessPrivate As Integer = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments)

        If Me.Level = "" OrElse Me.ForiegnKey = "" Then 'If there is no level or identifiers, load all by filename...

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.DocumentHistoryRadGrid.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                        Where Entity.FileName = Me.FileName
                                                        Select [FILENAME] = Entity.FileName,
                                                                           [DESCRIPTION] = Entity.Description,
                                                                           FILE_SIZE = Entity.FileSize,
                                                                           USER_NAME = Entity.UserCode,
                                                                           UPLOADED_DATE = Entity.UploadedDate,
                                                                           MIME_TYPE = Entity.MIMEType,
                                                                           REPOSITORY_FILENAME = Entity.FileSystemFileName,
                                                                           DOCUMENT_ID = Entity.ID,
                                                                           PROOFHQ_URL = Entity.ProofHQUrl).ToList()

                Me._GridLoadedFromFramework = True

            End Using

        Else

            Select Case Me.Level
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation()
                    Dim OfficeDocuments As New vOfficeDocuments(Me.ConnectionString)
                    OfficeDocuments.Where.FILENAME.Value = Me.FileName
                    OfficeDocuments.Where.OFFICE_CODE.Value = Me.ForiegnKey
                    OfficeDocuments.Query.Load()
                    Me.DocumentHistoryRadGrid.DataSource = OfficeDocuments.DefaultView
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation
                    Dim ClientDocuments As New vClientDocuments(Me.ConnectionString)
                    ClientDocuments.Where.FILENAME.Value = Me.FileName
                    ClientDocuments.Where.CL_CODE.Value = Me.ForiegnKey
                    ClientDocuments.Query.Load()
                    Me.DocumentHistoryRadGrid.DataSource = ClientDocuments.DefaultView

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation
                    Dim DivisionDocuments As New vDivisionDocuments(Me.ConnectionString)
                    DivisionDocuments.Where.FILENAME.Value = Me.FileName
                    Dim strDI As String = String.Empty
                    If InStr(Me.ForiegnKey, ",") > 0 Then
                        Dim FKs() As String
                        FKs = Me.ForiegnKey.Split(",")
                        strDI = FKs(1)
                    Else
                        strDI = Me.ForiegnKey
                    End If
                    DivisionDocuments.Where.DIV_CODE.Value = strDI
                    DivisionDocuments.Query.Load()
                    Me.DocumentHistoryRadGrid.DataSource = DivisionDocuments.DefaultView

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                    Dim ProductDocuments As New vProductDocuments(Me.ConnectionString)
                    ProductDocuments.Where.FILENAME.Value = Me.FileName
                    Dim strPR As String = String.Empty
                    If InStr(Me.ForiegnKey, ",") > 0 Then
                        Dim FKs() As String
                        FKs = Me.ForiegnKey.Split(",")
                        strPR = FKs(2)
                    Else
                        strPR = Me.ForiegnKey
                    End If
                    ProductDocuments.Where.PRD_CODE.Value = strPR
                    ProductDocuments.Query.Load()
                    Me.DocumentHistoryRadGrid.DataSource = ProductDocuments.DefaultView

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation
                    Dim CampaignDocuments As New vCampaignDocuments(Me.ConnectionString)
                    CampaignDocuments.Where.FILENAME.Value = Me.FileName
                    CampaignDocuments.Where.CMP_IDENTIFIER.Value = Me.ForiegnKey
                    CampaignDocuments.Query.Load()
                    Me.DocumentHistoryRadGrid.DataSource = CampaignDocuments.DefaultView

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation
                    Dim JobDocuments As New vJobDocuments(Me.ConnectionString)
                    JobDocuments.Where.FILENAME.Value = Me.FileName
                    JobDocuments.Where.JOB_NUMBER.Value = Me.ForiegnKey
                    JobDocuments.Query.Load()
                    Me.DocumentHistoryRadGrid.DataSource = JobDocuments.DefaultView

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation
                    Dim JobComponentDocuments As New vJobComponentsDocuments(Me.ConnectionString)
                    Dim FKs() As String = Me.ForiegnKey.Split(",")
                    JobComponentDocuments.Where.FILENAME.Value = Me.FileName
                    JobComponentDocuments.Where.JOB_NUMBER.Value = FKs(0)
                    JobComponentDocuments.Where.JOB_COMPONENT_NUMBER.Value = FKs(1)
                    JobComponentDocuments.Query.Load()
                    Me.DocumentHistoryRadGrid.DataSource = JobComponentDocuments.DefaultView

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation
                    Dim APDocuments As New vAPDocuments(Me.ConnectionString)
                    APDocuments.Where.FILENAME.Value = Me.FileName
                    APDocuments.Where.AP_ID.Value = Me.ForiegnKey
                    APDocuments.Query.Load()
                    Me.DocumentHistoryRadGrid.DataSource = APDocuments.DefaultView
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                    Select Case Me.DOLevel
                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                            Dim ADDocuments As New vAgencyDesktopDocuments(Me.ConnectionString)
                            Dim FKs() As String = Me.ForiegnKey.Split(",")
                            ADDocuments.Where.FILENAME.Value = Me.FileName
                            If FKs(0) <> "" Then
                                ADDocuments.Where.OFFICE_CODE.Value = FKs(0)
                            End If
                            If FKs(1) <> "" Then
                                ADDocuments.Where.DP_TM_CODE.Value = FKs(1)
                            End If
                            ADDocuments.Query.Load()
                            Me.DocumentHistoryRadGrid.DataSource = ADDocuments.DefaultView
                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                            Dim EDDocuments As New vExecutiveDesktopDocuments(Me.ConnectionString)
                            Dim FKs() As String = Me.ForiegnKey.Split(",")
                            EDDocuments.Where.FILENAME.Value = Me.FileName
                            If FKs(0) <> "" Then
                                EDDocuments.Where.OFFICE_CODE.Value = FKs(0)
                            End If
                            If FKs(1) <> "" Then
                                EDDocuments.Where.EMP_CODE.Value = FKs(1)
                            End If
                            'If Me.ForiegnKey <> "" AndAlso Me.ForiegnKey <> "," Then
                            '    EDDocuments.Where.OFFICE_CODE.Value = Me.ForiegnKey
                            'End If
                            EDDocuments.Query.Load()
                            Me.DocumentHistoryRadGrid.DataSource = EDDocuments.DefaultView
                    End Select
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation


                    Dim docs As New Document(Me.ConnectionString)
                    Dim dt As DataTable = docs.GetCurrentAdNumberDocument(Me.ForiegnKey, Session("DocClientValue"), accessPrivate)
                    Me.DocumentHistoryRadGrid.DataSource = dt.DefaultView

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation

                    Dim docs As New Document(Me.ConnectionString)
                    Dim dt As DataTable = docs.GetCurrentExpenseDocument(Me.ForiegnKey, "", Me.FileName, 0, accessPrivate)
                    Me.DocumentHistoryRadGrid.DataSource = dt.DefaultView

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation,
                        AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation,
                        AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                        Dim documentRepo As New Repositories.DocumentRepository(DataContext)
                        Dim gridResults = documentRepo.FindDocumentHistory(Me.Level, Me.ForiegnKey, Me.FileName)
                        Me.DocumentHistoryRadGrid.DataSource = gridResults
                    End Using

            End Select

        End If


    End Sub

End Class
