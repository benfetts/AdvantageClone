Imports Ionic.Zip
Imports Telerik.Web.UI

Public Class Documents_List2
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _InvoiceNumber As Integer = 0
    Private _InvoiceSeqNbr As Integer = -1
    Private _APID As Integer = 0
    Private _APInvoice As String = ""
    Private _VendorCode As String = ""
    Private _AccessPrivate As Boolean = False
    Private _ContractID As Integer = 0
    Private _ClientCode As String = ""
    Private _DivisionCode As String = ""
    Private _ProductCode As String = ""
    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0
    Private _SequenceNumber As Short = -1
    Private _ContractReportID As Integer = 0
    Private _CanAccessARInvoice As Boolean = False
    Private _CanAccessAPInvoice As Boolean = False
    Private _ShowThumbnailsRadToolBarButton As RadToolBarButton

#End Region

#Region " Properties "

    Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing

#End Region

#Region " Page Events "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager)

        Me._AccessPrivate = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments) = 1

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ARInvoice, False)) Then
            _CanAccessARInvoice = True
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_APInvoice, False)) Then
            _CanAccessAPInvoice = True
        End If

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Try

            Me.OpenerRadWindowName = qs("opener")

        Catch ex As Exception
            Me.OpenerRadWindowName = ""
        End Try

        Me._DocumentLevel = qs.DocumentLevel

        Select Case Me._DocumentLevel

            Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                Me._InvoiceNumber = qs.InvoiceNumber
                Me._InvoiceSeqNbr = qs.InvoiceSequenceNumber

                If Me._InvoiceNumber = 0 Or Me._InvoiceSeqNbr = -1 Then

                    Me.CloseThisWindow()

                Else

                    Me.PageTitle = "Documents for Invoice: " & Me._InvoiceNumber.ToString().PadLeft(6, "0") & "/" & Me._InvoiceSeqNbr.ToString()

                End If

                RadgridInvoiceDocuments.MasterTableView.NoMasterRecordsText = "There are no files for this AR Invoice."

            Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                Me._APID = qs.APID
                Me._APInvoice = qs.APInvoice
                Me._VendorCode = qs.VendorCode

                If Me._APID = 0 Then

                    Me.CloseThisWindow()

                Else

                    Me.PageTitle = "Documents for Vendor/Invoice: " & Me._VendorCode & "/" & Me._APInvoice

                End If

                RadgridInvoiceDocuments.MasterTableView.NoMasterRecordsText = "There are no files for this AP invoice."

            Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

                _ContractID = qs.ContractID

                If _ContractID = 0 Then

                    Me.CloseThisWindow()

                Else

                    Me.PageTitle = "Documents for Contract: " & qs.GetValue("contract_desc").Replace("+", " ")

                End If

                RadgridInvoiceDocuments.MasterTableView.NoMasterRecordsText = "There are no files for this contract."

            Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

                _ContractReportID = qs.ContractReportID

                If _ContractReportID = 0 Then

                    Me.CloseThisWindow()

                Else

                    Me.PageTitle = "Documents for Contract Report: " & qs.GetValue("contract_report").Replace("+", " ")

                End If

                RadgridInvoiceDocuments.MasterTableView.NoMasterRecordsText = "There are no files for this contract report."

            Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                _ClientCode = qs.ClientCode

                If _ClientCode = "" Then

                    Me.CloseThisWindow()

                Else

                    Me.PageTitle = "Documents for Client: " & qs.GetValue("client_desc").Replace("+", " ")

                End If

                RadgridInvoiceDocuments.MasterTableView.NoMasterRecordsText = "There are no files for this client."

            Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                _ClientCode = qs.ClientCode
                _DivisionCode = qs.DivisionCode

                If _ClientCode = "" OrElse _DivisionCode = "" Then

                    Me.CloseThisWindow()

                Else

                    Me.PageTitle = "Documents for Division: " & qs.GetValue("division_desc").Replace("+", " ")

                End If

                RadgridInvoiceDocuments.MasterTableView.NoMasterRecordsText = "There are no files for this division."

            Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                _ClientCode = qs.ClientCode
                _DivisionCode = qs.DivisionCode
                _ProductCode = qs.ProductCode

                If _ClientCode = "" OrElse _DivisionCode = "" OrElse _ProductCode = "" Then

                    Me.CloseThisWindow()

                Else

                    Me.PageTitle = "Documents for Product: " & qs.GetValue("product_desc").Replace("+", " ")

                End If

                RadgridInvoiceDocuments.MasterTableView.NoMasterRecordsText = "There are no files for this product."

            Case AdvantageFramework.Database.Entities.DocumentLevel.Task

                RadToolBarButtonUpload.Visible = True
                RadToolBarButtonDelete.Visible = True
                RadToolBarButtonDeleteSeparator.Visible = True

                _JobNumber = qs.JobNumber
                _JobComponentNumber = qs.JobComponentNumber
                _SequenceNumber = qs.TaskSequenceNumber

                If _JobNumber = 0 OrElse _JobComponentNumber = 0 OrElse _SequenceNumber < 0 Then

                    Me.CloseThisWindow()

                Else

                    Me.PageTitle = "Documents for Task: " & qs.GetValue("task_desc").Replace("+", " ")

                End If

                RadgridInvoiceDocuments.MasterTableView.NoMasterRecordsText = "There are no files for this task."

        End Select

        If RadToolBarButtonUpload.Visible Then

            RadToolBarButtonUpload.Visible = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.Methods.GroupSettings.DocumentManager_CanUpload).Any(Function(item) item = True)

        End If

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.RadToolbarInvoiceDocuments.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks
            Me.RadToolbarInvoiceDocuments.FindItemByValue("BookmarkSeparator").Visible = Me.EnableBookmarks

        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadgridInvoiceDocuments_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadgridInvoiceDocuments.ItemCommand

        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

        If Not CurrentGridRow Is Nothing Then

            Select Case e.CommandName

                Case "Download"

                    Me.DeliverFile(CurrentGridRow.GetDataKeyValue("ID"))

                Case "ShowHistory"

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs.Page = "Documents_History.aspx"
                    qs.Add("filename", CType(CurrentGridRow.FindControl("LinkButtonDownload"), LinkButton).Text)

                    If Me._DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice Then

                        With qs

                            .DocumentLevel = Me._DocumentLevel
                            .DocumentID = CurrentGridRow.GetDataKeyValue("ID")
                            .InvoiceNumber = Me._InvoiceNumber
                            .InvoiceSequenceNumber = Me._InvoiceSeqNbr

                        End With

                    ElseIf Me._DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice Then

                        With qs

                            .Add("Level", "VN")
                            .Add("FK", Me._APID)

                        End With

                    ElseIf _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Contract Then

                        With qs

                            .DocumentLevel = _DocumentLevel
                            .DocumentID = CurrentGridRow.GetDataKeyValue("ID")
                            .Add("contract_id", _ContractID)

                        End With

                    ElseIf _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.ContractReport Then

                        With qs

                            .DocumentLevel = _DocumentLevel
                            .DocumentID = CurrentGridRow.GetDataKeyValue("ID")
                            .Add("contract_report_id", _ContractReportID)

                        End With

                    ElseIf _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Client Then

                        With qs

                            .DocumentLevel = _DocumentLevel
                            .DocumentID = CurrentGridRow.GetDataKeyValue("ID")
                            .ClientCode = _ClientCode

                        End With

                    ElseIf _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Division Then

                        With qs

                            .DocumentLevel = _DocumentLevel
                            .DocumentID = CurrentGridRow.GetDataKeyValue("ID")
                            .ClientCode = _ClientCode
                            .DivisionCode = _DivisionCode

                        End With

                    ElseIf _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Product Then

                        With qs

                            .DocumentLevel = _DocumentLevel
                            .DocumentID = CurrentGridRow.GetDataKeyValue("ID")
                            .ClientCode = _ClientCode
                            .DivisionCode = _DivisionCode
                            .ProductCode = _ProductCode

                        End With

                    ElseIf _DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Task Then

                        With qs

                            .DocumentLevel = _DocumentLevel
                            .DocumentID = CurrentGridRow.GetDataKeyValue("ID")
                            .JobNumber = _JobNumber
                            .JobComponentNumber = _JobComponentNumber
                            .TaskSequenceNumber = _SequenceNumber

                        End With

                    End If

                    Me.OpenWindow(qs)

                Case "AddComments"

                    Dim DocumentFilename As String = CType(CurrentGridRow.FindControl("LinkButtonDownload"), LinkButton).Text

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    With qs

                        .DocumentID = CurrentGridRow.GetDataKeyValue("ID")

                        .Add("PageNumber", "1")
                        .Add("DocumentID", CurrentGridRow.GetDataKeyValue("ID"))

                        If DocumentFilename.ToUpper.EndsWith(".PDF") Then

                            .Page = "Documents_PDFViewer.aspx"

                        ElseIf DocumentFilename.ToUpper.EndsWith(".DOC") OrElse DocumentFilename.ToUpper.EndsWith(".DOCX") Then

                            .Page = "Documents_WordViewer.aspx"

                        ElseIf DocumentFilename.ToUpper.EndsWith(".GIF") OrElse DocumentFilename.ToUpper.EndsWith(".JPEG") OrElse
                                DocumentFilename.ToUpper.EndsWith(".PJPEG") OrElse DocumentFilename.ToUpper.EndsWith(".PNG") OrElse
                                DocumentFilename.ToUpper.EndsWith(".JPG") OrElse DocumentFilename.ToUpper.EndsWith(".TIFF") OrElse
                                DocumentFilename.ToUpper.EndsWith(".BMP") Then

                            .Page = "Documents_ImageViewer.aspx"

                        ElseIf DocumentFilename.ToUpper.EndsWith(".MSG") Then

                            .Page = "Documents_MSGViewer.aspx"

                        ElseIf DocumentFilename.ToUpper.Contains(".XLS") OrElse DocumentFilename.ToUpper.Contains(".XLSX") Then

                            .Page = "Documents_ExcelViewer.aspx"

                        End If

                    End With

                    Me.OpenWindow(DocumentFilename, qs.ToString(True), 800, 1200)

            End Select

        End If

    End Sub
    Private _HasImage As Boolean = False
    Private _DocumentRepository As DocumentRepository
    Private _DbContext As AdvantageFramework.Database.DbContext
    Private _Agency As AdvantageFramework.Database.Entities.Agency
    Private Sub RadgridInvoiceDocuments_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadgridInvoiceDocuments.ItemDataBound

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Header

                _DocumentRepository = New DocumentRepository(Me._Session.ConnectionString)
                _DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                If _DbContext IsNot Nothing Then

                    _Agency = AdvantageFramework.Database.Procedures.Agency.Load(_DbContext)

                End If

            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem

                Dim SizeCell As Integer = 8
                Dim CurrentRow As Telerik.Web.UI.GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

                If Not CurrentRow Is Nothing Then

                    If Me._AccessPrivate = False AndAlso CurrentRow.DataItem.IsPrivate IsNot Nothing AndAlso CurrentRow.DataItem.IsPrivate = True Then

                        CurrentRow.Visible = False

                    Else

                        Dim FileName As String = String.Empty
                        Dim RepositoryFileName As String = String.Empty
                        Dim Description As String = Nothing
                        Dim MimeType As String = String.Empty

                        Try
                            FileName = CurrentRow.DataItem.FileName
                        Catch ex As Exception
                            FileName = String.Empty
                        End Try
                        Try
                            Description = CurrentRow.DataItem.Description
                        Catch ex As Exception
                            Description = String.Empty
                        End Try
                        Try
                            MimeType = CurrentRow.DataItem.MIMEType
                        Catch ex As Exception
                            MimeType = String.Empty
                        End Try
                        Try
                            RepositoryFileName = CurrentRow.DataItem.FileSystemFileName
                        Catch ex As Exception
                            RepositoryFileName = String.Empty
                        End Try

                        AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(Nothing,
                                                                                           DirectCast(e.Item.FindControl("LinkButtonDownload"), LinkButton),
                                                                                           DirectCast(e.Item.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                           Nothing, Nothing,
                                                                                           DirectCast(e.Item.FindControl("DivDocumentHistory"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentHistory"), LinkButton),
                                                                                           DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                           Nothing, Nothing, "",
                                                                                           e.Item.Cells(SizeCell).Text,
                                                                                           CurrentRow.DataItem.ID, CurrentRow.DataItem.MIMEType, FileName, CurrentRow.DataItem.FileSystemFileName, Description, CurrentRow.DataItem.FileSize,
                                                                                           "", "", 0)

                        Try

                            If Me._ShowThumbnailsRadToolBarButton IsNot Nothing AndAlso Me._ShowThumbnailsRadToolBarButton.Checked = True Then

                                Dim ThumbnailImageButton As ImageButton = CurrentRow.FindControl("ImageButtonThumbnail")

                                If ThumbnailImageButton IsNot Nothing Then

                                    ThumbnailImageButton.Visible = False

                                    If MimeType.ToLower.Contains("image") = True Then

                                        Dim FileBytes As Byte()

                                        If IsDBNull(CurrentRow.DataItem.Thumbnail) = False Then

                                            Try

                                                FileBytes = CurrentRow.DataItem.Thumbnail

                                            Catch ex As Exception
                                                FileBytes = Nothing
                                            End Try

                                        Else

                                            Try

                                                If _DbContext IsNot Nothing AndAlso _Agency IsNot Nothing Then

                                                    AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(_DbContext, _Agency, CurrentRow.DataItem.ID, FileBytes)

                                                End If

                                            Catch ex As Exception
                                                FileBytes = Nothing
                                            End Try

                                        End If

                                        If FileBytes IsNot Nothing AndAlso FileBytes.Length > 0 Then

                                            ThumbnailImageButton.ImageUrl = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(FileBytes))
                                            ThumbnailImageButton.Visible = True
                                            ThumbnailImageButton.ToolTip = FileName
                                            ThumbnailImageButton.CommandName = "Download"
                                            ThumbnailImageButton.CommandArgument = CurrentRow.DataItem.ID

                                            _HasImage = True

                                        End If

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                    AdvantageFramework.Web.Presentation.Controls.SetDocumentEditPopUp(CurrentRow.FindControl("ImageButtonEditDetails"), CurrentRow.DataItem.ID, "Documents_List2.aspx")

                End If

            Case Telerik.Web.UI.GridItemType.Footer

                Try

                    Me.RadgridInvoiceDocuments.MasterTableView.GetColumn("GridTemplateColumnThumbnail").Visible = _HasImage

                Catch ex As Exception
                End Try

        End Select

    End Sub
    Private Sub RadgridInvoiceDocuments_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadgridInvoiceDocuments.NeedDataSource

        Try

            Select Case Me._DocumentLevel

                Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                    If _CanAccessARInvoice = True Then
                        Me.LoadAccountReceivableInvoiceDocuments()
                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                    If _CanAccessAPInvoice = True Then
                        Me.LoadAccountPayableInvoiceDocuments()
                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

                    Me.LoadContractDocuments()

                Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

                    Me.LoadContractReportDocuments()

                Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                    Me.LoadClientDocuments()

                Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                    Me.LoadDivisionDocuments()

                Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                    Me.LoadProductDocuments()

                Case AdvantageFramework.Database.Entities.DocumentLevel.Task

                    Me.LoadTaskDocuments()

            End Select

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try

    End Sub
    Private Sub RadgridInvoiceDocuments_PreRender(sender As Object, e As EventArgs) Handles RadgridInvoiceDocuments.PreRender

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim HasDocuments As Boolean = False

        Select Case _DocumentLevel

            Case AdvantageFramework.Database.Entities.DocumentLevel.Task

                QueryString = New AdvantageFramework.Web.QueryString()

                QueryString = QueryString.FromCurrent()

                StringBuilder = New System.Text.StringBuilder

                With StringBuilder

                    HasDocuments = RadgridInvoiceDocuments.Items.Count > 0

                    .Append("try { CallingWindowContent.SetTaskDocumentIcon('#" & QueryString("doc_img") & "', " & HasDocuments.ToString.ToLower & ");  } catch (err) { }") 'used in Desktop objects
                    .Append("try { CallingWindowContent.SetHasDocuments(" & HasDocuments.ToString.ToLower & ");  } catch (err) { }") 'used in task detail window

                End With

                Me.ControlsToSet = StringBuilder.ToString()
                Me.HiddenFieldControlsToSet.Value = Me.ControlsToSet

                Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("returnValue();")

        End Select

    End Sub
    Private Sub RadToolbarInvoiceDocuments_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarInvoiceDocuments.ButtonClick
        Select Case e.Item.Value
            Case "Refresh"

                Me.RadgridInvoiceDocuments.Rebind()

            Case "Download"

                Select Case Me.RadgridInvoiceDocuments.SelectedItems.Count
                    Case 0

                        Me.ShowMessage("No file(s) selected.")

                    Case 1

                        Try

                            Dim DocumentId As Integer = CType(Me.RadgridInvoiceDocuments.SelectedItems(0), Telerik.Web.UI.GridDataItem).GetDataKeyValue("ID")
                            Me.DeliverFile(DocumentId)

                        Catch ex As Exception

                            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

                        End Try

                    Case Is > 1

                        Dim outputStream As New System.IO.MemoryStream
                        Dim zip As New ZipFile
                        Dim DtRecs As New DataTable

                        Dim COL_DOC_ID As DataColumn = New DataColumn("DocId")
                        COL_DOC_ID.DataType = GetType(Int32)

                        Dim COL_MIME_TYPE As DataColumn = New DataColumn("MimeType")
                        COL_MIME_TYPE.DataType = GetType(String)

                        Dim COL_FILENAME As DataColumn = New DataColumn("Filename")
                        COL_FILENAME.DataType = GetType(String)

                        Dim COL_REPOSITORY_FILENAME As DataColumn = New DataColumn("RepositoryFilename")
                        COL_REPOSITORY_FILENAME.DataType = GetType(String)

                        Dim COL_UPLOADED_DATE As DataColumn = New DataColumn("UploadedDate")
                        COL_UPLOADED_DATE.DataType = GetType(DateTime)

                        With DtRecs.Columns

                            .Add(COL_DOC_ID)
                            .Add(COL_FILENAME)
                            .Add(COL_REPOSITORY_FILENAME)
                            .Add(COL_UPLOADED_DATE)

                        End With

                        For Each GridItem As Telerik.Web.UI.GridDataItem In Me.RadgridInvoiceDocuments.SelectedItems

                            Dim DocumentId As Integer = GridItem.GetDataKeyValue("ID")
                            Dim Document As New AdvantageFramework.Database.Entities.Document

                            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, Me._Session.UserCode)

                                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                If Not Document Is Nothing Then

                                    If Document.MIMEType <> "URL" Then

                                        Dim r As DataRow
                                        r = DtRecs.NewRow()
                                        r("DocId") = DocumentId
                                        r("Filename") = Document.FileName
                                        r("RepositoryFilename") = Document.FileSystemFileName
                                        r("UploadedDate") = Document.UploadedDate

                                        DtRecs.Rows.Add(r)

                                    End If

                                End If

                            End Using

                        Next

                        If Not DtRecs Is Nothing Then

                            If DtRecs.Rows.Count > 0 Then

                                Dim rep As New DocumentRepository(Session("ConnString"))
                                rep.GetDocuments(DtRecs, zip)

                                zip.Save(Response.OutputStream)

                                With Response

                                    .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                    .ContentType = "application/zip"
                                    .End()

                                End With

                            End If

                        End If

                End Select

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Documents_Invoice
                    .PageURL = "Documents_List2.aspx" & qs.ToString()
                    .UserCode = Session("UserCode")

                    If Me._DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice Then

                        .Name = "Documents for Vendor/Invoice: " & Me._VendorCode & "/" & Me._APInvoice

                    ElseIf Me._DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice Then

                        .Name = "Documents for Invoice: " & Me._InvoiceNumber.ToString().PadLeft(6, "0") & "/" & Me._InvoiceSeqNbr.ToString()

                    End If

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

            Case RadToolBarButtonUpload.Value

                Select Case _DocumentLevel

                    Case AdvantageFramework.Database.Entities.DocumentLevel.Task

                        Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename.ToLower & "&Level=TK&FK=&Value=" & _JobNumber.ToString & "|" & _JobComponentNumber.ToString & "|" & _SequenceNumber.ToString, 500, 550, False, False, "refreshGrid")

                End Select

            Case RadToolBarButtonDelete.Value

                Dim ResultsText As String = ""
                Dim Files As String = ""
                Dim DocumentRepository As Webvantage.DocumentRepository = Nothing
                Dim Document As Webvantage.Document = Nothing
                Dim DocumentName As String = Nothing
                Dim DocumentID As Integer = Nothing
                Dim DocPath As String = String.Empty
                Dim DocRepositoryID As String = String.Empty
                Dim AlertAttachment As Generic.List(Of AdvantageFramework.Database.Entities.AlertAttachment) = Nothing
                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing


                If Me.RadgridInvoiceDocuments.SelectedItems.Count > 0 Then

                    For Each GridDataItem In RadgridInvoiceDocuments.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem)()

                        Document = New Webvantage.Document(_Session.ConnectionString)
                        DocumentID = GridDataItem.GetDataKeyValue("ID")
                        DocPath = String.Empty
                        DocRepositoryID = String.Empty

                        Document.Where.DOCUMENT_ID.Value = DocumentID

                        If Document.Query.Load() Then

                            If Document.USER_CODE <> _Session.UserCode Then

                                ResultsText += "Only Webvantage user " & Document.USER_CODE & " may delete " & Document.FILENAME

                            Else

                                Select Case _DocumentLevel

                                    Case AdvantageFramework.Database.Entities.DocumentLevel.Task

                                        Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                                AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, DocumentID).ToList

                                                If AlertAttachment IsNot Nothing And AlertAttachment.Count > 0 Then

                                                    Try

                                                        For Each DocumentAlertAttachment In AlertAttachment

                                                            AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                                                        Next

                                                        'AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, (From Item In AdvantageFramework.Database.Procedures.JobComponentTaskDocument.LoadByJobComponentTask(DataContext, _JobNumber, _JobComponentNumber, _SequenceNumber)
                                                        '                                                                          Where Item.DocumentID = DocumentID
                                                        '                                                                          Select Item).SingleOrDefault)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try

                                                        AdvantageFramework.Database.Procedures.JobComponentTaskDocument.Delete(DataContext, (From Item In AdvantageFramework.Database.Procedures.JobComponentTaskDocument.LoadByJobComponentTask(DataContext, _JobNumber, _JobComponentNumber, _SequenceNumber)
                                                                                                                                             Where Item.DocumentID = DocumentID
                                                                                                                                             Select Item).SingleOrDefault)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End Using

                                        End Using

                                    Case Else

                                End Select

                                DocumentName = Document.FILENAME
                                DocRepositoryID = Document.REPOSITORY_FILENAME

                                If Document.MIME_TYPE = "URL" Then

                                    Document.MarkAsDeleted()
                                    Document.Save()
                                    ResultsText += "Deleted - " & DocumentName

                                Else

                                    Document.MarkAsDeleted()
                                    Document.Save()

                                    Files &= DocRepositoryID & ","

                                    ResultsText += "Deleted - " & DocumentName

                                End If

                            End If

                        End If

                    Next

                    DocumentRepository = New Webvantage.DocumentRepository(_Session.ConnectionString)

                    For Each FileName In Files.Split(",")

                        DocumentRepository.DeleteDocument(0, FileName)

                    Next

                    RadgridInvoiceDocuments.Rebind()

                Else

                    Me.ShowMessage("No file selected.")

                End If

            Case "ShowThumbnails"

                Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.RadToolbarInvoiceDocuments.FindButtonByCommandName("ShowThumbnails")
                Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
                av.getAllAppVars()
                If ThumbnailsRadToolBarButton IsNot Nothing Then av.setAppVar("DocumentsList2Aspx", ThumbnailsRadToolBarButton.Checked, "Boolean")

                Me.RadgridInvoiceDocuments.Rebind()

        End Select

    End Sub

#End Region

#Region " Methods "

    Public Sub LoadAccountReceivableInvoiceDocuments()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If Me._AccessPrivate = False Then

                Me.RadgridInvoiceDocuments.DataSource = (From ard In AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadByInvoiceNumberAndSequenceNumber(DbContext, Me._InvoiceNumber, Me._InvoiceSeqNbr).ToList()
                                                         Where (ard.Document.IsPrivate = Nothing Or ard.Document.IsPrivate = 0)
                                                         Select New With {ard.Document.ID,
                                                                Key ard.Document.FileName,
                                                                ard.Document.Description,
                                                                .DocumentTypeDescription = ard.Document.DocumentType.Description,
                                                                ard.Document.FileSize,
                                                                ard.Document.UserCode,
                                                                ard.Document.UploadedDate,
                                                                ard.Document.IsPrivate,
                                                                ard.Document.MIMEType,
                                                                ard.Document.FileSystemFileName,
                                                             ard.Document.Thumbnail} Distinct.ToList())
            Else

                Me.RadgridInvoiceDocuments.DataSource = (From ard In AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadByInvoiceNumberAndSequenceNumber(DbContext, Me._InvoiceNumber, Me._InvoiceSeqNbr).ToList()
                                                         Select New With {ard.Document.ID,
                                                                Key ard.Document.FileName,
                                                                ard.Document.Description,
                                                                .DocumentTypeDescription = ard.Document.DocumentType.Description,
                                                                ard.Document.FileSize,
                                                                ard.Document.UserCode,
                                                                ard.Document.UploadedDate,
                                                                ard.Document.IsPrivate,
                                                                ard.Document.MIMEType,
                                                                ard.Document.FileSystemFileName,
                                                                           ard.Document.Thumbnail} Distinct.ToList())

            End If

        End Using

    End Sub
    Public Sub LoadAccountPayableInvoiceDocuments()

        'Dim Documents As New vCurrentAPDocuments(_Session.ConnectionString)
        'Dim list As New Generic.List(Of GridDataObject)

        'Documents.Where.AP_ID.Value = Me._APID

        'If Me._AccessPrivate = False Then

        '    Documents.Where.PRIVATE_FLAG.Value = 1
        '    Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual

        'End If
        'Documents.Query.Load()

        'Do Until Documents.EOF

        '    Dim gdo As New GridDataObject()
        '    With gdo

        '        .ID = Documents.DOCUMENT_ID
        '        .FileName = Documents.FILENAME
        '        .Description = Documents.s_DESCRIPTION
        '        .DocumentTypeDescription = Documents.s_DOCUMENT_TYPE_DESC
        '        .FileSize = Documents.FILE_SIZE
        '        .UserCode = Documents.USER_CODE
        '        .UploadedDate = Documents.UPLOADED_DATE
        '        .IsPrivate = If(IsNumeric(Documents.s_PRIVATE_FLAG), Webvantage.MiscFN.IntToBool(Documents.PRIVATE_FLAG), 0)
        '        .MIMEType = Documents.s_MIME_TYPE
        '        .FileSystemFileName = Documents.REPOSITORY_FILENAME
        '        .DocumentLoaded = True

        '    End With

        '    If gdo.DocumentLoaded = True Then list.Add(gdo)

        '    gdo = Nothing
        '    Documents.MoveNext()

        'Loop

        'Me.RadgridInvoiceDocuments.DataSource = list
        Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim AccountPayableDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableDocument) = Nothing
        Dim AccountPayableDocIDs As Generic.List(Of Integer) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                AccountPayableDocuments = AdvantageFramework.Database.Procedures.AccountPayableDocument.LoadByAccountPayableID(DataContext, Me._APID).ToList

                Try

                    If Me._AccessPrivate = False Then

                        DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                        Where AccountPayableDocuments.Where(Function(AccountPayableDocument) AccountPayableDocument.DocumentID = Document.ID).Any AndAlso
                                          CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                        Select Document).ToList

                    Else

                        DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                        Where AccountPayableDocuments.Where(Function(AccountPayableDocument) AccountPayableDocument.DocumentID = Document.ID).Any
                                        Select Document).ToList

                    End If

                Catch ex As Exception
                    DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                End Try

            End Using

            RadgridInvoiceDocuments.DataSource = (From Document In DocumentList
                                                  Select New With {Document.ID,
                                                               .DOCUMENT_ID = Document.ID,
                                                               Key Document.FileName,
                                                               Document.Description,
                                                               .DocumentTypeDescription = Document.DocumentType.Description,
                                                               Document.FileSize,
                                                               Document.UserCode,
                                                               Document.UploadedDate,
                                                               Document.IsPrivate,
                                                               Document.MIMEType,
                                                               Document.FileSystemFileName,
                                                               Document.Thumbnail}).ToList

        End Using

    End Sub
    Public Sub LoadContractDocuments()

        Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim ContractDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractDocument) = Nothing
        Dim ContractIDs As Generic.List(Of Integer) = Nothing

        If _ContractID <> 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    ContractIDs = New Generic.List(Of Integer)

                    ContractIDs.Add(_ContractID)

                    ContractDocuments = (From ContractDocument In AdvantageFramework.Database.Procedures.ContractDocument.LoadCurrentByContractIDs(DbContext, ContractIDs).ToList
                                         Select ContractDocument).ToList

                    If _AccessPrivate = False Then

                        DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                        Where ContractDocuments.Where(Function(ContractDocument) ContractDocument.DocumentID = Document.ID).Any AndAlso
                                              CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                        Select Document).ToList

                    Else

                        DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                        Where ContractDocuments.Where(Function(ContractDocument) ContractDocument.DocumentID = Document.ID).Any
                                        Select Document).ToList

                    End If

                Catch ex As Exception
                    DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                End Try

                RadgridInvoiceDocuments.DataSource = (From Document In DocumentList
                                                      Select New With {Document.ID,
                                                                       .DOCUMENT_ID = Document.ID,
                                                                       Key Document.FileName,
                                                                       Document.Description,
                                                                       .DocumentTypeDescription = Document.DocumentType.Description,
                                                                       Document.FileSize,
                                                                       Document.UserCode,
                                                                       Document.UploadedDate,
                                                                       Document.IsPrivate,
                                                                       Document.MIMEType,
                                                                       Document.FileSystemFileName,
                                                                           Document.Thumbnail}).ToList

            End Using

        End If

    End Sub
    Public Sub LoadContractReportDocuments()

        Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim ContractReportDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractReportDocument) = Nothing
        Dim ContractReportIDs As Generic.List(Of Integer) = Nothing

        If _ContractReportID <> 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        ContractReportIDs = New Generic.List(Of Integer)

                        ContractReportIDs.Add(_ContractReportID)

                        ContractReportDocuments = (From ContractReportDocument In AdvantageFramework.Database.Procedures.ContractReportDocument.LoadCurrentByContractReportIDs(DataContext, ContractReportIDs).ToList
                                                   Select ContractReportDocument).ToList

                        If _AccessPrivate = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where ContractReportDocuments.Where(Function(ContractReportDocument) ContractReportDocument.DocumentID = Document.ID).Any AndAlso
                                                  CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                            Select Document).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where ContractReportDocuments.Where(Function(ContractReportDocument) ContractReportDocument.DocumentID = Document.ID).Any
                                            Select Document).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                    End Try

                    RadgridInvoiceDocuments.DataSource = (From Document In DocumentList
                                                          Select New With {Document.ID,
                                                                           Key Document.FileName,
                                                                           Document.Description,
                                                                           .DocumentTypeDescription = Document.DocumentType.Description,
                                                                           Document.FileSize,
                                                                           Document.UserCode,
                                                                           Document.UploadedDate,
                                                                           Document.IsPrivate,
                                                                           Document.MIMEType,
                                                                           Document.FileSystemFileName,
                                                                           Document.Thumbnail}).ToList

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadClientDocuments()

        Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim ClientDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ClientDocument) = Nothing
        Dim ClientCodes As Generic.List(Of String) = Nothing

        If _ClientCode <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        ClientCodes = New Generic.List(Of String)

                        ClientCodes.Add(_ClientCode)

                        ClientDocuments = (From ClientDocument In AdvantageFramework.Database.Procedures.ClientDocument.LoadCurrentByClientCodes(DataContext, ClientCodes).ToList
                                           Select ClientDocument).ToList

                        If _AccessPrivate = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where ClientDocuments.Where(Function(ClientDocument) ClientDocument.DocumentID = Document.ID).Any AndAlso
                                                  CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                            Select Document).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where ClientDocuments.Where(Function(ClientDocument) ClientDocument.DocumentID = Document.ID).Any
                                            Select Document).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                    End Try

                    RadgridInvoiceDocuments.DataSource = (From Document In DocumentList
                                                          Select New With {Document.ID,
                                                                           Key Document.FileName,
                                                                           Document.Description,
                                                                           .DocumentTypeDescription = Document.DocumentType.Description,
                                                                           Document.FileSize,
                                                                           Document.UserCode,
                                                                           Document.UploadedDate,
                                                                           Document.IsPrivate,
                                                                           Document.MIMEType,
                                                                           Document.FileSystemFileName,
                                                                           Document.Thumbnail}).ToList

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadDivisionDocuments()

        Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim DivisionDocuments As Generic.List(Of AdvantageFramework.Database.Entities.DivisionDocument) = Nothing
        Dim ClientDivisionCodes As Generic.List(Of String) = Nothing

        If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        ClientDivisionCodes = New Generic.List(Of String)

                        ClientDivisionCodes.Add(_ClientCode & "|" & _DivisionCode)

                        DivisionDocuments = (From DivisionDocument In AdvantageFramework.Database.Procedures.DivisionDocument.LoadCurrentByClientDivisionCodes(DataContext, ClientDivisionCodes).ToList
                                             Select DivisionDocument).ToList

                        If _AccessPrivate = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where DivisionDocuments.Where(Function(DivisionDocument) DivisionDocument.DocumentID = Document.ID).Any AndAlso
                                                  CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                            Select Document).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where DivisionDocuments.Where(Function(DivisionDocument) DivisionDocument.DocumentID = Document.ID).Any
                                            Select Document).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                    End Try

                    RadgridInvoiceDocuments.DataSource = (From Document In DocumentList
                                                          Select New With {Document.ID,
                                                                           Key Document.FileName,
                                                                           Document.Description,
                                                                           .DocumentTypeDescription = Document.DocumentType.Description,
                                                                           Document.FileSize,
                                                                           Document.UserCode,
                                                                           Document.UploadedDate,
                                                                           Document.IsPrivate,
                                                                           Document.MIMEType,
                                                                           Document.FileSystemFileName,
                                                                           Document.Thumbnail}).ToList

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadProductDocuments()

        Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim ProductDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ProductDocument) = Nothing
        Dim ClientDivisionProductCodes As System.Collections.Generic.List(Of String) = Nothing

        If _ClientCode <> "" AndAlso _DivisionCode <> "" And _ProductCode <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        ClientDivisionProductCodes = New System.Collections.Generic.List(Of String)

                        ClientDivisionProductCodes.Add(_ClientCode & "|" & _DivisionCode & "|" & _ProductCode)

                        ProductDocuments = (From ProductDocument In AdvantageFramework.Database.Procedures.ProductDocument.LoadCurrentByClientDivisionProductCodes(DataContext, ClientDivisionProductCodes).ToList
                                            Select ProductDocument).ToList

                        If _AccessPrivate = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where ProductDocuments.Where(Function(ProductDocument) ProductDocument.DocumentID = Document.ID).Any AndAlso
                                                  CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                            Select Document).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where ProductDocuments.Where(Function(ProductDocument) ProductDocument.DocumentID = Document.ID).Any
                                            Select Document).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                    End Try

                    RadgridInvoiceDocuments.DataSource = (From Document In DocumentList
                                                          Select New With {Document.ID,
                                                                           Key Document.FileName,
                                                                           Document.Description,
                                                                           .DocumentTypeDescription = Document.DocumentType.Description,
                                                                           Document.FileSize,
                                                                           Document.UserCode,
                                                                           Document.UploadedDate,
                                                                           Document.IsPrivate,
                                                                           Document.MIMEType,
                                                                           Document.FileSystemFileName,
                                                                           Document.Thumbnail}).ToList

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadTaskDocuments()

        Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim AttachmentDocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim JobComponentTaskDocuments As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument) = Nothing
        Dim AlertAttachments As Generic.List(Of AdvantageFramework.Database.Entities.AlertAttachment) = Nothing
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso _SequenceNumber >= 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, _JobNumber, _JobComponentNumber, _SequenceNumber)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        JobComponentTaskDocuments = AdvantageFramework.Database.Procedures.JobComponentTaskDocument.LoadCurrentByJobComponentTask(DataContext, _JobNumber, _JobComponentNumber, _SequenceNumber).ToList
                        AlertAttachments = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, Alert.ID).ToList

                        If _AccessPrivate = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where JobComponentTaskDocuments.Where(Function(JobComponentTaskDocument) JobComponentTaskDocument.DocumentID = Document.ID).Any AndAlso
                                                  CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                            Select Document).ToList.Union(From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                                                          Where AlertAttachments.Where(Function(AlertAttachment) AlertAttachment.DocumentID = Document.ID).Any AndAlso
                                                            CBool(Document.IsPrivate.GetValueOrDefault(0)) = False
                                                                          Select Document).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                            Where JobComponentTaskDocuments.Where(Function(JobComponentTaskDocument) JobComponentTaskDocument.DocumentID = Document.ID).Any
                                            Select Document).ToList.Union(From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                                                          Where AlertAttachments.Where(Function(AlertAttachment) AlertAttachment.DocumentID = Document.ID).Any
                                                                          Select Document).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                    End Try

                    RadgridInvoiceDocuments.DataSource = (From Document In DocumentList
                                                          Select New With {Document.ID,
                                                                           Key Document.FileName,
                                                                           Document.Description,
                                                                           .DocumentTypeDescription = Document.DocumentType.Description,
                                                                           Document.FileSize,
                                                                           Document.UserCode,
                                                                           Document.UploadedDate,
                                                                           Document.IsPrivate,
                                                                           Document.MIMEType,
                                                                           Document.FileSystemFileName,
                                                                           Document.Thumbnail}).Distinct.ToList

                End Using

            End Using

        End If

    End Sub

    Private Sub RadgridInvoiceDocuments_PdfExporting(sender As Object, e As GridPdfExportingArgs) Handles RadgridInvoiceDocuments.PdfExporting

    End Sub

    Private Sub Documents_List2_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Me._ShowThumbnailsRadToolBarButton Is Nothing Then

            Me._ShowThumbnailsRadToolBarButton = Me.RadToolbarInvoiceDocuments.FindButtonByCommandName("ShowThumbnails")

        End If

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.RadToolbarInvoiceDocuments.FindButtonByCommandName("ShowThumbnails")
            Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
            av.getAllAppVars()
            If ThumbnailsRadToolBarButton IsNot Nothing Then ThumbnailsRadToolBarButton.Checked = av.getAppVar("DocumentsList2Aspx", "Boolean", "true").ToString.ToLower = "true"
        Else
            Select Case Me.EventTarget

                Case "RebindGrid"

                    Me.RadgridInvoiceDocuments.Rebind()


            End Select
        End If

    End Sub

#End Region

End Class

Public Class GridDataObject 'for old code and new code to fit into same grid

    Public Property ID As Integer = 0
    Public Property FileName As String = ""
    Public Property Description As String = ""
    Public Property DocumentTypeDescription As String = ""
    Public Property FileSize As Double = 0
    Public Property UserCode As String = ""
    Public Property UploadedDate As Date = Nothing
    Public Property IsPrivate As Boolean = False
    Public Property MIMEType As String = ""
    Public Property DocumentLoaded As Boolean = False
    Public Property FileSystemFileName As String = ""
    Public Property Thumbnail As Byte()

    Sub New()

    End Sub

End Class
