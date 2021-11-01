Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Ionic.Zip
Imports Webvantage.cGlobals
Imports Webvantage.SqlHelper
Imports System.Text
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel
Imports Telerik.Web.UI

Public Class Documents_List
    Inherits Webvantage.BaseChildPage

#Region " Enum "



#End Region

#Region " Variables "

    Private _Level As String = ""
    Private _ForiegnKey As String = ""
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _ShowThumbnailsRadToolBarButton As RadToolBarButton

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Function GetDoc(ByVal DocumentID As String) As DataTable

        'objects
        Dim DataTable As System.Data.DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter
        Dim parameterDocumentID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)

        parameterDocumentID.Value = DocumentID
        arParams(0) = parameterDocumentID

        Try

            DataTable = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "proc_DOCUMENTSLoadByPrimaryKey", "tblcmp", arParams)

        Catch

            Err.Raise(Err.Number, "Class:Doc.aspx Routine:GetDoc", Err.Description)

        End Try

        Return DataTable

    End Function
    Protected Sub ToggleRowSelection(ByVal sender As Object, ByVal e As EventArgs)

        CType(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridItem).Selected = CType(sender, CheckBox).Checked

    End Sub

#Region "  Page Event Handlers "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim ItemsTemplateColumnVisible As Boolean = False
        Dim DeleteTemplateColumnVisible As Boolean = False
        Dim Description As String = Nothing
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Short = Nothing
        Dim SequenceNumber As Short = Nothing

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        If Not Request.QueryString("DocPopupType") Is Nothing Then
            Dim type As String = Request.QueryString("DocPopupType")
            Select Case type
                Case "expense"
                    Me.RadGridDocuments.MasterTableView.Caption = " Receipts for Invoice: " & Request.QueryString("invNbr")
                    _Level = "EX"
                    _ForiegnKey = Request.QueryString("invNbr")
                    ItemsTemplateColumnVisible = True

                    Try

                        If AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(_DbContext, _ForiegnKey)) = AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open Then

                            DeleteTemplateColumnVisible = True

                        End If

                    Catch ex As Exception
                        DeleteTemplateColumnVisible = False
                    End Try

                Case "campaign"
                    Dim cCmp As New cCampaign(CStr(Session("ConnString")), CType(Request.QueryString("cmp"), Integer))
                    Me.RadGridDocuments.MasterTableView.Caption = " Documents for Campaign: " & cCmp.CMP_CODE & " - " & cCmp.CMP_NAME
                    _Level = "CM"
                    _ForiegnKey = cCmp.CMP_IDENTIFIER

                Case "jobtraffictask"

                    Try

                        JobNumber = CInt(Request.QueryString("JobNbr"))
                        JobComponentNumber = CShort(Request.QueryString("CompNbr"))
                        SequenceNumber = CShort(Request.QueryString("SeqNbr"))

                        _Level = "PST"

                        _ForiegnKey = String.Format("{0}|{1}|{2}", JobNumber, JobComponentNumber, SequenceNumber)

                        Description = _DbContext.Database.SqlQuery(Of String)(" SELECT " &
                                                                                  "     CASE  " &
                                                                                  "         WHEN JOB_TRAFFIC_DET.FNC_CODE IS NOT NULL THEN JOB_TRAFFIC_DET.FNC_CODE + ' - ' " &
                                                                                  "         ELSE '' " &
                                                                                  "     END + JOB_TRAFFIC_DET.TASK_DESCRIPTION  " &
                                                                                  " FROM " &
                                                                                  "     dbo.JOB_TRAFFIC_DET " &
                                                                                  " WHERE " &
                                                                                  "     JOB_NUMBER = @JobNumber AND " &
                                                                                  "     JOB_COMPONENT_NBR = @JobComponentNumber AND " &
                                                                                  "     SEQ_NBR = @SequenceNumber",
                                                                                  {New System.Data.SqlClient.SqlParameter("JobNumber", System.Data.SqlDbType.Int) With {.Value = JobNumber},
                                                                                   New System.Data.SqlClient.SqlParameter("JobComponentNumber", System.Data.SqlDbType.SmallInt) With {.Value = JobComponentNumber},
                                                                                   New System.Data.SqlClient.SqlParameter("SequenceNumber", System.Data.SqlDbType.SmallInt) With {.Value = SequenceNumber}}).FirstOrDefault

                        Me.RadGridDocuments.MasterTableView.Caption = " Documents for Task: " & Description

                    Catch ex As Exception
                        Me.RadGridDocuments.MasterTableView.Caption = "Project Schedule Task Documents"
                    End Try

            End Select

        End If

        RadGridDocuments.MasterTableView.Columns.FindByUniqueName("ItemsTemplateColumn").Visible = ItemsTemplateColumnVisible
        RadGridDocuments.MasterTableView.Columns.FindByUniqueName("DeleteTemplateColumn").Visible = DeleteTemplateColumnVisible

        If Me._ShowThumbnailsRadToolBarButton Is Nothing Then

            Me._ShowThumbnailsRadToolBarButton = Me.RadToolBarDocumentViewer.FindButtonByCommandName("ShowThumbnails")

        End If

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.RadToolBarDocumentViewer.FindButtonByCommandName("ShowThumbnails")
            Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
            av.getAllAppVars()
            If ThumbnailsRadToolBarButton IsNot Nothing Then ThumbnailsRadToolBarButton.Checked = av.getAppVar("DocumentsListAspx", "Boolean", "true").ToString.ToLower = "true"

        End If

    End Sub
    Private Sub Page_Unload1(sender As Object, e As EventArgs) Handles Me.Unload

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGridDocuments_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDocuments.ItemCommand


        If e.Item Is Nothing Then Exit Sub

        'objects
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim Deleted As Boolean = False

        Select Case e.CommandName
            Case "Download"
                Dim DocumentId As Integer = CInt(e.CommandArgument)
                Me.DeliverFile(DocumentId)

            Case "ShowHistory"
                Dim url As String
                Dim type As String = Request.QueryString("DocPopupType")

                url = "Documents_History.aspx?Level=" & _Level & "&filename=" & e.CommandArgument & "&FK=" & _ForiegnKey
                Me.OpenWindow("Document History", url)

            Case "AddComments"

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(_DbContext, e.CommandArgument)

                If Document IsNot Nothing Then

                    If Document.FileName.ToUpper.EndsWith(".PDF") Then

                        Me.OpenWindow(Document.FileName, "Documents_PDFViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                    ElseIf Document.FileName.ToUpper.EndsWith(".DOC") OrElse Document.FileName.ToUpper.EndsWith(".DOCX") Then

                        Me.OpenWindow(Document.FileName, "Documents_WordViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                    ElseIf Document.FileName.ToUpper.EndsWith(".GIF") OrElse Document.FileName.ToUpper.EndsWith(".JPEG") OrElse
                            Document.FileName.ToUpper.EndsWith(".PJPEG") OrElse Document.FileName.ToUpper.EndsWith(".PNG") OrElse
                            Document.FileName.ToUpper.EndsWith(".JPG") OrElse Document.FileName.ToUpper.EndsWith(".TIFF") OrElse
                            Document.FileName.ToUpper.EndsWith(".BMP") Then

                        Me.OpenWindow(Document.FileName, "Documents_ImageViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                    ElseIf Document.FileName.ToUpper.EndsWith(".MSG") Then

                        Me.OpenWindow(Document.FileName, "Documents_MSGViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                    ElseIf Document.FileName.ToUpper.Contains(".XLS") OrElse Document.FileName.ToUpper.Contains(".XLSX") Then

                        Me.OpenWindow(Document.FileName, "Documents_ExcelViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=0", 800, 1200)

                    End If

                End If

            Case "ShowItems"

                Me.OpenWindow("Select Items", "Expense_SelectItems.aspx?DocID=" & e.CommandArgument.ToString & "&InvNbr=" & _ForiegnKey, IsModal:=True)

                'Me.CloseThisWindowAndOpenNewWindow("Expense_SelectItems.aspx?DocID=" & documentID & "&InvNbr=" & Me.Value, False)

            Case "DeleteRow"

                Dim DocumentID As Integer = Nothing

                Try

                    DocumentID = CInt(CType(e.Item, Telerik.Web.UI.GridDataItem).GetDataKeyValue("DOCUMENT_ID"))

                Catch ex As Exception

                End Try

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(_DbContext, DocumentID)

                If Document IsNot Nothing Then

                    Select Case _Level

                        Case "EX"

                            Deleted = AdvantageFramework.Database.Procedures.ExpenseReportDocument.Delete(_DbContext, Document.ID)

                    End Select

                    If Deleted Then

                        If AdvantageFramework.Database.Procedures.Document.Delete(_DbContext, Document) Then

                            RadGridDocuments.Rebind()

                        End If

                    End If

                End If


        End Select

    End Sub
    Private _HasImage As Boolean = False
    Private _DocumentRepository As DocumentRepository
    Private _Agency As AdvantageFramework.Database.Entities.Agency
    Private Sub RadGridDocuments_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDocuments.ItemDataBound

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Header

                _DocumentRepository = New DocumentRepository(Me._Session.ConnectionString)

                If _DbContext Is Nothing Then

                    _DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                End If
                If _DbContext IsNot Nothing Then

                    _Agency = AdvantageFramework.Database.Procedures.Agency.Load(_DbContext)

                End If

            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem

                Dim CurrentRow As GridDataItem = e.Item

                If CurrentRow IsNot Nothing Then

                    Dim ProofHQURL As String = String.Empty
                    Dim DocumentID As Integer = 0
                    Dim MimeType As String = String.Empty
                    Dim FileName As String = String.Empty
                    Dim RepositoryFileName As String = String.Empty

                    Try

                        If IsDBNull(e.Item.DataItem("PROOFHQ_URL")) = False AndAlso String.IsNullOrWhiteSpace(e.Item.DataItem("PROOFHQ_URL")) = False Then

                            ProofHQURL = e.Item.DataItem("PROOFHQ_URL")

                        End If

                    Catch ex As Exception
                        ProofHQURL = String.Empty
                    End Try
                    Try

                        DocumentID = e.Item.DataItem("DOCUMENT_ID")

                    Catch ex As Exception
                        DocumentID = 0
                    End Try
                    Try

                        MimeType = e.Item.DataItem("MIME_TYPE")

                    Catch ex As Exception
                        MimeType = String.Empty
                    End Try
                    Try

                        RepositoryFileName = e.Item.DataItem("REPOSITORY_FILENAME")

                    Catch ex As Exception
                        RepositoryFileName = String.Empty
                    End Try

                    If DocumentID > 0 Then

                        Dim Description As String = String.Empty

                        If Not IsDBNull(e.Item.DataItem("FILENAME")) Then

                            FileName = e.Item.DataItem("FILENAME")

                        End If

                        If Not IsDBNull(e.Item.DataItem("DESCRIPTION")) Then

                            Description = e.Item.DataItem("DESCRIPTION")

                        End If

                        AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton),
                                                                                       DirectCast(e.Item.FindControl("DownloadLinkButton"), LinkButton),
                                                                                       DirectCast(e.Item.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                       Nothing, Nothing,
                                                                                       DirectCast(e.Item.FindControl("DivDocumentHistory"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentHistory"), LinkButton),
                                                                                       DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                       Nothing, Nothing, ProofHQURL,
                                                                                       CurrentRow("SizeColumn").Text,
                                                                                       DocumentID, e.Item.DataItem("MIME_TYPE"), FileName, e.Item.DataItem("REPOSITORY_FILENAME"), Description, e.Item.DataItem("FILE_SIZE"),
                                                                                       "", "", 0)

                        Try

                            If Me._ShowThumbnailsRadToolBarButton IsNot Nothing AndAlso Me._ShowThumbnailsRadToolBarButton.Checked = True Then

                                Dim ThumbnailImageButton As ImageButton = CurrentRow.FindControl("ImageButtonThumbnail")

                                If ThumbnailImageButton IsNot Nothing Then

                                    ThumbnailImageButton.Visible = False

                                    If MimeType.ToLower.Contains("image") = True Then

                                        Dim FileBytes As Byte()

                                        If IsDBNull(CurrentRow.DataItem("THUMBNAIL")) = False Then

                                            Try

                                                FileBytes = CurrentRow.DataItem("THUMBNAIL")

                                            Catch ex As Exception
                                                FileBytes = Nothing
                                            End Try

                                        Else

                                            Try

                                                If _DbContext IsNot Nothing AndAlso _Agency IsNot Nothing Then

                                                    AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(_DbContext, _Agency, DocumentID, FileBytes)

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
                                            ThumbnailImageButton.CommandArgument = DocumentID

                                            _HasImage = True

                                        End If

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                    e.Item.Attributes.Add("DocumentId", DocumentID)

                    AdvantageFramework.Web.Presentation.Controls.SetDocumentEditPopUp(CurrentRow.FindControl("ImageButtonEditDetails"), DocumentID, "Documents_List.aspx")

                End If

            Case Telerik.Web.UI.GridItemType.Footer

                Try

                    Me.RadGridDocuments.MasterTableView.GetColumn("GridTemplateColumnThumbnail").Visible = _HasImage

                Catch ex As Exception
                End Try

        End Select

    End Sub
    Private Sub RadGridDocuments_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDocuments.NeedDataSource
        Dim docs As New Document(CStr(Session("ConnString")))
        Dim dt As DataTable

        If Not Request.QueryString("DocPopupType") Is Nothing Then
            Dim type As String = Request.QueryString("DocPopupType")
            Dim accessPrivate As Integer = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments)
            Select Case type
                Case "expense"
                    Dim invNbr As String = Request.QueryString("invNbr")
                    Dim ItemID As String = Request.QueryString("ItemID")
                    Dim DocumentIDs As Integer() = Nothing

                    dt = docs.GetCurrentExpenseDocument(invNbr, "", "", 1, 1)

                    If String.IsNullOrEmpty(ItemID) = False Then

                        Try

                            DocumentIDs = (From Entity In AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByExpenseDetailID(_DbContext, ItemID)
                                           Select Entity.DocumentID).ToArray

                        Catch ex As Exception
                            DocumentIDs = Nothing
                        End Try

                        Dim ColumnValue As Object = Nothing

                        If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Any Then

                            For Each DataRow In dt.Rows.OfType(Of System.Data.DataRow).ToList

                                Try

                                    If DocumentIDs.Contains(CInt(DataRow("DOCUMENT_ID"))) = False Then

                                        dt.Rows.Remove(DataRow)

                                    End If

                                Catch ex As Exception

                                End Try

                            Next

                        Else

                            'no item docs
                            dt.Rows.Clear()

                        End If

                    End If

                Case "campaign"
                    Dim cCmp As New cCampaign(CStr(Session("ConnString")), CType(Request.QueryString("cmp"), Integer))
                    dt = docs.GetCampaignDocuments(cCmp.CMP_IDENTIFIER, accessPrivate, Session("UserCode"))

                Case "jobtraffictask"

                    Dim Schedule As Webvantage.cSchedule = Nothing
                    Dim JobNumber As Integer = CInt(Request.QueryString("JobNbr"))
                    Dim JobComponentNumber As Short = CShort(Request.QueryString("CompNbr"))
                    Dim SequenceNumber As Short = CShort(Request.QueryString("SeqNbr"))

                    Schedule = New cSchedule(CStr(Session("ConnString")), CStr(Session("UserCode")))
                    dt = Schedule.GetTaskDocuments(JobNumber, JobComponentNumber, SequenceNumber, "", 0, accessPrivate, Session("UserCode"))

            End Select

        End If

        Me.RadGridDocuments.DataSource = dt

    End Sub
    Private Sub RadToolBarDocumentViewer_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDocumentViewer.ButtonClick
        Select Case e.Item.Value

            Case "Download"
                Select Case Me.RadGridDocuments.SelectedItems.Count
                    Case 0
                        Me.ShowMessage("No file(s) selected.")
                    Case 1
                        Dim DocumentId As Integer = Me.RadGridDocuments.SelectedItems(0).Attributes("DocumentId")
                        Me.DeliverFile(DocumentId)
                    Case Is > 1
                        Dim GridItem As Telerik.Web.UI.GridItem
                        Dim outputStream As New System.IO.MemoryStream
                        'Dim zipOutStream As New ZipOutputStream(outputStream)
                        Dim zip As New ZipFile
                        'zipOutStream.SetLevel(5) ' Medium compression
                        Dim dt As DataTable

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

                        For Each GridItem In Me.RadGridDocuments.SelectedItems
                            Dim DocumentId As Integer = GridItem.Attributes("DocumentId")
                            Dim Document As New Document(CStr(Session("ConnString")))
                            dt = Me.GetDoc(DocumentId)
                            If dt.Rows(0)("MIME_TYPE").ToString() <> "URL" Then
                                If dt.Rows.Count > 0 Then
                                    Dim r As DataRow
                                    r = DtRecs.NewRow()
                                    r("DocId") = DocumentId
                                    r("Filename") = dt.Rows(0)("FILENAME").ToString()
                                    r("RepositoryFilename") = dt.Rows(0)("REPOSITORY_FILENAME").ToString()
                                    r("UploadedDate") = CType(dt.Rows(0)("UPLOADED_DATE"), DateTime)
                                    DtRecs.Rows.Add(r)

                                End If
                            End If
                        Next

                        If Not DtRecs Is Nothing Then
                            If DtRecs.Rows.Count > 0 Then
                                Dim rep As New DocumentRepository(CStr(Session("ConnString")))
                                rep.GetDocuments(DtRecs, zip)
                            End If
                        End If
                        zip.Save(Response.OutputStream)
                        'zipOutStream.Finish()
                        'outputStream.Flush()

                        'Dim OutputBytes(outputStream.Length) As Byte
                        'OutputBytes = outputStream.ToArray

                        'outputStream.Close()
                        'zipOutStream.Close()

                        With Response
                            '.Buffer = True
                            .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                            .ContentType = "application/x-zip-compressed"
                            '.AddHeader("Content-Length", OutputBytes.Length.ToString())
                            '.BinaryWrite(OutputBytes)
                            '.Flush()
                            .End()
                        End With

                End Select

            Case "ShowThumbnails"

                Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.RadToolBarDocumentViewer.FindButtonByCommandName("ShowThumbnails")
                Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
                av.getAllAppVars()
                If ThumbnailsRadToolBarButton IsNot Nothing Then av.setAppVar("DocumentsListAspx", ThumbnailsRadToolBarButton.Checked, "Boolean")

                Me.RadGridDocuments.Rebind()

        End Select

    End Sub

#End Region

#End Region

End Class
