Imports ASB
Imports Webvantage.cGlobals
Imports Webvantage.SqlHelper
Imports Ionic.Zip
Imports System.Data.SqlClient
Imports System.Drawing
Imports Telerik.Web.UI
Imports System.Collections.Generic

Partial Public Class Documents_JobComponent
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private ConnectionString As String
    Private _AccessPrivate As Boolean = False

    Protected WithEvents RadComboBoxDocLevel As Telerik.Web.UI.RadComboBox

    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private Campaign As String = ""
    Private PageMode As String = "AD" 'original layout

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private _IsJobDashboard As Boolean = False
    Private _DocumentIDs() As Long
    Private _AllLabelsNeeded As New Generic.List(Of AdvantageFramework.Database.Entities.Label)
    Private _DocumentLabels As New Generic.List(Of AdvantageFramework.Database.Entities.LabelDocument)
    Private _HasDeletable As Boolean = True
    Private _ShowThumbnailsRadToolBarButton As RadToolBarButton

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadGridJobComponentDocuments_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobComponentDocuments.ItemCommand

        'objects
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = Nothing

        If e.Item Is Nothing Then Exit Sub

        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

            CurrentGridRow = e.Item

            Select Case e.CommandName
                Case "Download"

                    Dim DocumentId As Integer = CInt(e.CommandArgument)
                    Me.DeliverFile(DocumentId)

                Case "ShowHistory"

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs.Page = "Documents_History.aspx"
                    qs.DocumentID = CurrentGridRow.GetDataKeyValue("DOCUMENT_ID")

                    If CurrentGridRow("GridBoundColumnLevel").Text.Contains("AR Invoice") = True Then


                        qs.DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                    Else

                        Dim StrURL As String = "Documents_History.aspx?Level=" & Session("DocFilterLevel") & "&FK=" & Session("HistoryFK") & "&filename=" & e.CommandArgument

                    End If

                    Me.OpenWindow("Document History", qs.ToString(True))

                Case "AddComments"

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, e.CommandArgument)

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

                    End Using

                Case "ProofHQLink"

                    Me.AddJavascriptToPage(String.Format("window.open('{0}', '_blank');", e.CommandArgument))

                Case "Delete", "DeleteRow"

                    Dim DocumentLegacy As New Document(Me.ConnectionString)
                    Dim DocumentID As Integer = CType(e.Item, Telerik.Web.UI.GridDataItem).GetDataKeyValue("DOCUMENT_ID")
                    Dim DocPath As String = String.Empty
                    Dim DocRepositoryID As String = String.Empty
                    Dim JobRelatedDocuments As Integer = 0
                    Dim JobCompRelatedDocuments As Integer = 0

                    DocumentLegacy.Where.DOCUMENT_ID.Value = DocumentID

                    If DocumentLegacy.Query.Load() Then

                        Select Case Me.RadComboBoxDocLevel.SelectedValue

                            Case "JO"

                                Dim job As New JobDocument(Session("ConnString"))

                                job.Where.DOCUMENT_ID.Value = DocumentID

                                If job.Query.Load() Then

                                    job.MarkAsDeleted()
                                    job.Save()

                                End If

                                Dim alert As New AlertAttachment(Session("ConnString"))
                                alert.Where.DOCUMENT_ID.Value = DocumentID
                                If alert.Query.Load() Then
                                    alert.MarkAsDeleted()
                                    alert.Save()
                                End If

                            Case "JC"

                                If CurrentGridRow("GridBoundColumnLevel").Text = "Task" OrElse
                                        CurrentGridRow("GridBoundColumnLevel").Text = "Job Component" Then

                                    Dim jobcomp As New JobComponentDocuments(Session("ConnString"))
                                    jobcomp.Where.DOCUMENT_ID.Value = DocumentID
                                    If jobcomp.Query.Load() Then
                                        jobcomp.MarkAsDeleted()
                                        jobcomp.Save()
                                    End If
                                    Dim alert As New AlertAttachment(Session("ConnString"))
                                    alert.Where.DOCUMENT_ID.Value = DocumentID
                                    If alert.Query.Load() Then
                                        alert.MarkAsDeleted()
                                        alert.Save()
                                    End If
                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        Try

                                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[JOB_TRAFFIC_DET_DOCS] WHERE [DOCUMENT_ID] = {0}", DocumentID))

                                        Catch ex As Exception

                                        End Try

                                    End Using

                                End If

                        End Select

                        Dim DocumentName As String = DocumentLegacy.s_FILENAME
                        DocRepositoryID = DocumentLegacy.REPOSITORY_FILENAME

                        If DocumentLegacy.MIME_TYPE = "URL" Then

                            DocumentLegacy.MarkAsDeleted()
                            DocumentLegacy.Save()

                        Else
                            'Check for multiple references to same document for job and job comp levels.
                            If Me.RadComboBoxDocLevel.SelectedValue = "JO" Then
                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                    JobRelatedDocuments = AdvantageFramework.Database.Procedures.JobDocument.LoadRelatedbyRepositoryFilename(DataContext, DocumentLegacy.REPOSITORY_FILENAME)
                                End Using
                            ElseIf Me.RadComboBoxDocLevel.SelectedValue = "JC" Then
                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                    JobCompRelatedDocuments = AdvantageFramework.Database.Procedures.JobComponentDocument.LoadRelatedbyRepositoryFilename(DataContext, DocumentLegacy.REPOSITORY_FILENAME)
                                End Using
                            End If

                            DocumentLegacy.MarkAsDeleted()
                            DocumentLegacy.Save()

                        End If

                        Dim documentRepositiory As New DocumentRepository(Me.ConnectionString)

                        If Me.RadComboBoxDocLevel.SelectedValue = "JO" Then
                            If JobRelatedDocuments = 0 Then
                                If documentRepositiory.DeleteDocument(0, DocRepositoryID) Then
                                    'Document.Save()
                                End If
                            End If
                        ElseIf Me.RadComboBoxDocLevel.SelectedValue = "JC" Then
                            If JobCompRelatedDocuments = 0 Then
                                If documentRepositiory.DeleteDocument(0, DocRepositoryID) Then
                                    'Document.Save()
                                End If
                            End If
                        Else
                            If documentRepositiory.DeleteDocument(0, DocRepositoryID) Then
                                'Document.Save()
                            End If
                        End If

                        Me.RadGridJobComponentDocuments.Rebind()

                    End If

            End Select

        End If
    End Sub
    Private _HasImage As Boolean = False
    Private _DocumentRepository As DocumentRepository
    Private _DbContext As AdvantageFramework.Database.DbContext
    Private _Agency As AdvantageFramework.Database.Entities.Agency
    Private Sub RadGridJobComponentDocuments_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobComponentDocuments.ItemDataBound

        Dim access As Integer = 0
        Dim DeleteImageButton As ImageButton = Nothing
        Dim DeleteDiv As HtmlControls.HtmlControl = Nothing

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Header

                _DocumentRepository = New DocumentRepository(Me._Session.ConnectionString)
                _DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                If _DbContext IsNot Nothing Then

                    _Agency = AdvantageFramework.Database.Procedures.Agency.Load(_DbContext)

                End If

            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                Dim CurrentRow As GridDataItem = e.Item

                If CurrentRow IsNot Nothing Then

                    Dim ProofHQURL As String = String.Empty
                    Dim MimeType As String = String.Empty
                    Dim Filename As String = String.Empty
                    Dim Description As String = String.Empty
                    Dim RepositoryFileName As String = String.Empty

                    Try

                        If IsDBNull(e.Item.DataItem("PROOFHQ_URL")) = False AndAlso String.IsNullOrWhiteSpace(e.Item.DataItem("PROOFHQ_URL")) = False Then

                            ProofHQURL = e.Item.DataItem("PROOFHQ_URL")

                        End If

                    Catch ex As Exception
                        ProofHQURL = String.Empty
                    End Try
                    Try

                        If IsDBNull(e.Item.DataItem("FILENAME")) = False AndAlso String.IsNullOrWhiteSpace(e.Item.DataItem("FILENAME")) = False Then

                            Filename = e.Item.DataItem("FILENAME")

                        End If

                    Catch ex As Exception
                        Filename = String.Empty
                    End Try
                    Try

                        If IsDBNull(e.Item.DataItem("DESCRIPTION")) = False AndAlso String.IsNullOrWhiteSpace(e.Item.DataItem("DESCRIPTION")) = False Then

                            Description = e.Item.DataItem("DESCRIPTION")

                        End If

                    Catch ex As Exception
                        Description = String.Empty
                    End Try
                    Try

                        If IsDBNull(e.Item.DataItem("MIME_TYPE")) = False AndAlso String.IsNullOrWhiteSpace(e.Item.DataItem("MIME_TYPE")) = False Then

                            MimeType = e.Item.DataItem("MIME_TYPE")

                        End If

                    Catch ex As Exception
                        MimeType = String.Empty
                    End Try
                    Try

                        If IsDBNull(e.Item.DataItem("REPOSITORY_FILENAME")) = False AndAlso String.IsNullOrWhiteSpace(e.Item.DataItem("REPOSITORY_FILENAME")) = False Then

                            RepositoryFileName = e.Item.DataItem("REPOSITORY_FILENAME")

                        End If

                    Catch ex As Exception
                        RepositoryFileName = String.Empty
                    End Try
                    Try

                        access = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload)

                        If RadComboBoxDocLevel.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation Then

                            If e.Item.DataItem("LEVEL") = "Task" OrElse
                                    e.Item.DataItem("LEVEL") = "Job Component" Then

                                If (access <> 0) Then

                                    DeleteImageButton = e.Item.FindControl("ImageButtonDelete")

                                    If DeleteImageButton IsNot Nothing Then

                                        DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

                                    End If

                                Else

                                    DeleteImageButton = e.Item.FindControl("ImageButtonDelete")

                                    If DeleteImageButton IsNot Nothing Then

                                        DeleteImageButton.Visible = False

                                    End If

                                    DeleteDiv = e.Item.FindControl("DivDelete")

                                    If DeleteDiv IsNot Nothing Then

                                        AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDiv)

                                    End If

                                End If

                            Else

                                DeleteImageButton = e.Item.FindControl("ImageButtonDelete")

                                If DeleteImageButton IsNot Nothing Then

                                    DeleteImageButton.Visible = False

                                End If

                                DeleteDiv = e.Item.FindControl("DivDelete")

                                If DeleteDiv IsNot Nothing Then

                                    AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDiv)

                                End If

                            End If

                        Else

                            If (access <> 0) Then

                                DeleteImageButton = e.Item.FindControl("ImageButtonDelete")

                                If DeleteImageButton IsNot Nothing Then

                                    DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

                                End If

                            Else

                                DeleteImageButton = e.Item.FindControl("ImageButtonDelete")

                                If DeleteImageButton IsNot Nothing Then

                                    DeleteImageButton.Visible = False

                                End If

                                DeleteDiv = e.Item.FindControl("DivDelete")

                                If DeleteDiv IsNot Nothing Then

                                    AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDiv)

                                End If

                            End If

                        End If

                        'If (IsDBNull(e.Item.DataItem("USER_CODE")) = False AndAlso e.Item.DataItem("USER_CODE").ToString() = HttpContext.Current.Session("UserCode").ToString()) OrElse
                        'Session("Admin") = True Then

                        '    If _HasDeletable = False Then _HasDeletable = True

                        '    Dim DeleteImageButton As ImageButton = e.Item.FindControl("ImageButtonDelete")
                        '    If DeleteImageButton IsNot Nothing Then DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

                        'Else

                        '    Dim DeleteDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDelete")

                        '    If DeleteDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDiv)

                        'End If

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(Nothing,
                                                                                  DirectCast(e.Item.FindControl("LinkButtonDownload"), LinkButton),
                                                                                  DirectCast(e.Item.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                  Nothing, Nothing,
                                                                                  DirectCast(e.Item.FindControl("DivDocumentHistory"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentHistory"), LinkButton),
                                                                                  DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                  DirectCast(e.Item.FindControl("DivProofHQ"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonProofHQ"), LinkButton), ProofHQURL,
                                                                                  CurrentRow("SizeColumn").Text,
                                                                                  e.Item.DataItem("DOCUMENT_ID"), e.Item.DataItem("MIME_TYPE"), Filename, e.Item.DataItem("REPOSITORY_FILENAME"), Description, e.Item.DataItem("FILE_SIZE"),
                                                                                  "", "", 0)


                    e.Item.Attributes.Add("DocumentId", e.Item.DataItem("DOCUMENT_ID"))

                    'Set label pop up window:
                    AdvantageFramework.Web.Presentation.Controls.SetDocumentEditPopUp(CurrentRow.FindControl("ImageButtonEditDetails"), e.Item.DataItem("DOCUMENT_ID"), "Documents_JobComponent.aspx")

                    'Set labels
                    Dim LabelsDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivLabels")
                    Dim Labels = Me._DocumentLabels.Where(Function(x) x.DocumentID = CType(e.Item.DataItem("DOCUMENT_ID"), Long)).ToList()

                    If Labels IsNot Nothing AndAlso Labels.Count > 0 Then

                        Dim Label As AdvantageFramework.Database.Entities.Label

                        For Each dl As AdvantageFramework.Database.Entities.LabelDocument In Labels

                            Label = Me._AllLabelsNeeded.Where(Function(x) x.ID = dl.LabelID).SingleOrDefault

                            If Label IsNot Nothing Then

                                Dim dluc As New Webvantage.Document_Label
                                dluc = CType(LoadControl("Document_Label.ascx"), Webvantage.Document_Label)

                                dluc.DocumentID = CurrentRow.GetDataKeyValue("DOCUMENT_ID")
                                dluc.LabelID = Label.ID
                                dluc.SetPostBack()
                                dluc.Text = Label.Name
                                If Label.HexColor IsNot Nothing Then dluc.Style = "background-color: " & Label.HexColor & ";"

                                LabelsDiv.Controls.Add(dluc)

                            End If

                            Label = Nothing

                        Next

                    Else

                        AdvantageFramework.Web.Presentation.Controls.DivHide(LabelsDiv)

                    End If

                    If IsDBNull(e.Item.DataItem("DESCRIPTION")) OrElse e.Item.DataItem("DESCRIPTION").ToString() = "" Then

                        Dim DescriptionDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivDescription")
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DescriptionDiv)

                    End If

                    If IsDBNull(e.Item.DataItem("KEYWORDS")) OrElse e.Item.DataItem("KEYWORDS").ToString() = "" Then

                        Dim KeywordsDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivKeywords")
                        AdvantageFramework.Web.Presentation.Controls.DivHide(KeywordsDiv)

                    End If

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

                                                AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(_DbContext, _Agency, CurrentRow.GetDataKeyValue("DOCUMENT_ID"), FileBytes)

                                            End If

                                        Catch ex As Exception
                                            FileBytes = Nothing
                                        End Try

                                    End If

                                    If FileBytes IsNot Nothing AndAlso FileBytes.Length > 0 Then

                                        ThumbnailImageButton.ImageUrl = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(FileBytes))
                                        ThumbnailImageButton.Visible = True
                                        ThumbnailImageButton.ToolTip = Filename
                                        ThumbnailImageButton.CommandName = "Download"
                                        ThumbnailImageButton.CommandArgument = CurrentRow.GetDataKeyValue("DOCUMENT_ID")

                                        _HasImage = True

                                    End If

                                End If

                            End If

                        End If

                    Catch ex As Exception
                    End Try

                End If

            Case Telerik.Web.UI.GridItemType.Footer

                Try

                    Me.RadGridJobComponentDocuments.MasterTableView.GetColumn("GridTemplateColumnDelete").Display = Me._HasDeletable

                Catch ex As Exception
                End Try
                Try

                    Me.RadGridJobComponentDocuments.MasterTableView.GetColumn("GridTemplateColumnThumbnail").Visible = _HasImage

                Catch ex As Exception
                End Try

        End Select

    End Sub
    Private Sub RadGridJobComponentDocuments_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobComponentDocuments.NeedDataSource
        Try

            Dim strCaption As String = String.Empty
            Dim myReq As cRequired = New cRequired(Session("ConnString"))

            Session("DocFilterLevel") = Me.RadComboBoxDocLevel.SelectedValue

            If _IsJobDashboard = False Then Me.RadGridJobComponentDocuments.MasterTableView.Caption = strCaption

            Select Case Me.RadComboBoxDocLevel.SelectedValue
                Case "JO"

                    Session("DocFilterValue") = Me.JobNumber
                    strCaption &= "Job Number: " & myReq.GetDescription(Me.RadComboBoxDocLevel.SelectedValue, Me.JobNumber)

                    If Session("DocFilterLevel") <> "" Or CInt(Session("DocFilterValue")) > 0 Then

                        Me.RadGridJobComponentDocuments.DataSource = FillFileListFromFilter(Session("DocFilterLevel"), Session("DocFilterValue"))

                    End If

                Case "JC"

                    Session("DocFilterValue") = Me.JobNumber & "," & Me.JobComponentNbr
                    strCaption &= "Job/Comp Number: " & myReq.GetDescription(Me.RadComboBoxDocLevel.SelectedValue, Me.JobNumber & "," & Me.JobComponentNbr)

                    If Session("DocFilterLevel") <> "" Or Session("DocFilterValue") <> "" Then

                        Me.RadGridJobComponentDocuments.DataSource = FillFileListFromFilter(Session("DocFilterLevel"), Session("DocFilterValue"))

                    End If

            End Select


            Me.RadGridJobComponentDocuments.MasterTableView.GroupByExpressions.Clear()
            Me.RadGridJobComponentDocuments.MasterTableView.GroupByExpressions.Add("LEVEL Level Group By LEVEL")

        Catch ex As Exception

            Me.RadGridJobComponentDocuments.DataSource = Nothing

        End Try
    End Sub

    Private Sub FilesRadToolbar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles FilesRadToolbar.ButtonClick

        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = Nothing
        Dim URL As String = ""
        Dim dl As Telerik.Web.UI.RadComboBox

        Select Case e.Item.Value
            Case "LabelView"

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Documents_LabelView.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNbr

                MiscFN.ResponseRedirect(qs.ToString(True), True)

            Case "Upload"

                If Me.RadComboBoxDocLevel.SelectedValue = "JC" Then

                    Session("DocFilterValue") = Me.JobNumber & "," & Me.JobComponentNbr
                    Session("HistoryFK") = Me.JobNumber & "," & Me.JobComponentNbr

                Else

                    Session("DocFilterValue") = Me.JobNumber
                    Session("HistoryFK") = Me.JobNumber

                End If

                If Session("DocFilterLevel") Is Nothing Or Session("DocFilterValue") Is Nothing Then

                    Me.ShowMessage("Please select a level to attach the document.")
                    Exit Sub

                Else

                    If Me.RadComboBoxDocLevel.SelectedValue = "JO" Then
                        If Session("DocFilterLevel") = "" Or CInt(Session("DocFilterValue")) <= 0 Then

                            Me.ShowMessage("Please select a level to attach the document.")
                            Exit Sub

                        Else

                            URL = "Documents_Upload.aspx?caller=" & Me.PageFilename & "&Level=" & Session("DocFilterLevel") & "&FK=" &
                                Session("HistoryFK") & "&Value=" & Session("DocFilterValue") &
                                "&j=" & Me.JobNumber & "&jc=" & Me.JobComponentNbr

                        End If
                    Else
                        If Session("DocFilterLevel") = "" Or Session("DocFilterValue") = "" Then

                            Me.ShowMessage("Please select a level to attach the document.")
                            Exit Sub

                        Else

                            URL = "Documents_Upload.aspx?caller=" & Me.PageFilename & "&Level=" & Session("DocFilterLevel") & "&FK=" &
                                Session("HistoryFK") & "&Value=" & Session("DocFilterValue") &
                                "&j=" & Me.JobNumber & "&jc=" & Me.JobComponentNbr

                        End If
                    End If


                End If

                Me.OpenWindow("Upload a new document", URL, 550, 575, False, False, "RefreshFileGrid")

            Case "Refresh"

                Me.RadGridJobComponentDocuments.Rebind()

            Case "Download"

                Select Case Me.RadGridJobComponentDocuments.SelectedItems.Count
                    Case 0

                        Me.ShowMessage("No file(s) selected.")

                    Case 1

                        Dim DocumentId As Integer = Me.RadGridJobComponentDocuments.SelectedItems(0).Attributes("DocumentId")
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

                        For Each GridItem In Me.RadGridJobComponentDocuments.SelectedItems

                            Dim DocumentId As Integer = GridItem.Attributes("DocumentId")
                            Dim Document As New Document(Me.ConnectionString)

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

                                Dim rep As New DocumentRepository(Me.ConnectionString)
                                rep.GetDocuments(DtRecs, zip)

                            End If

                        End If

                        zip.Save(Response.OutputStream)

                        Response.AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files_Job_" & Me.JobNumber.ToString().PadLeft(6, "0") & "_Comp_" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                        Response.ContentType = "application/zip"
                        Response.End()

                End Select

            Case "Search"

                Me.RadGridJobComponentDocuments.Rebind()

            Case "AdvancedSearch"

                Me.OpenWindow("", "Documents_AdvancedSearch.aspx")

            Case "Delete"

                Select Case Me.RadGridJobComponentDocuments.SelectedItems.Count

                    Case 0

                        Me.ShowMessage("No file selected.")

                    Case Is > 0

                        Dim i As Integer
                        Dim ResultsText As String
                        Dim files As String
                        Dim filenames() As String

                        For i = Me.RadGridJobComponentDocuments.SelectedItems.Count - 1 To 0 Step -1

                            Dim Document As New Document(Me.ConnectionString)
                            Dim DocumentID As Integer = Me.RadGridJobComponentDocuments.SelectedItems(i).Attributes("DocumentId")
                            Dim DocPath As String = String.Empty
                            Dim DocRepositoryID As String = String.Empty

                            CurrentGridRow = CType(Me.RadGridJobComponentDocuments.SelectedItems(i), Telerik.Web.UI.GridDataItem)

                            Document.Where.DOCUMENT_ID.Value = DocumentID

                            If Document.Query.Load() Then

                                'If Document.USER_CODE <> Session("UserCode") And Session("Admin") = False Then

                                '    ResultsText += "Only Webvantage user " & Document.USER_CODE & " may delete " & Document.FILENAME & "\n"

                                'Else

                                Select Case Me.RadComboBoxDocLevel.SelectedValue

                                    Case "JO"

                                        Dim job As New JobDocument(Session("ConnString"))

                                        job.Where.DOCUMENT_ID.Value = DocumentID

                                        If job.Query.Load() Then

                                            job.MarkAsDeleted()
                                            job.Save()

                                        End If

                                        Dim alert As New AlertAttachment(Session("ConnString"))
                                        alert.Where.DOCUMENT_ID.Value = DocumentID
                                        If alert.Query.Load() Then
                                            alert.MarkAsDeleted()
                                            alert.Save()
                                        End If

                                    Case "JC"

                                        If CurrentGridRow("GridBoundColumnLevel").Text = "Task" OrElse
                                                CurrentGridRow("GridBoundColumnLevel").Text = "Job Component" Then

                                            Dim jobcomp As New JobComponentDocuments(Session("ConnString"))
                                            jobcomp.Where.DOCUMENT_ID.Value = DocumentID
                                            If jobcomp.Query.Load() Then
                                                jobcomp.MarkAsDeleted()
                                                jobcomp.Save()
                                            End If
                                            Dim alert As New AlertAttachment(Session("ConnString"))
                                            alert.Where.DOCUMENT_ID.Value = DocumentID
                                            If alert.Query.Load() Then
                                                alert.MarkAsDeleted()
                                                alert.Save()
                                            End If
                                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                                Try

                                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[JOB_TRAFFIC_DET_DOCS] WHERE [DOCUMENT_ID] = {0}", DocumentID))

                                                Catch ex As Exception

                                                End Try

                                            End Using

                                        Else

                                            Continue For

                                        End If

                                End Select

                                Dim DocumentName As String = Document.FILENAME
                                DocRepositoryID = Document.REPOSITORY_FILENAME

                                'Check for multiple references to same document for job and job comp levels.
                                Dim JobRelatedDocuments As Integer = 0
                                Dim JobCompRelatedDocuments As Integer = 0

                                If Document.MIME_TYPE = "URL" Then

                                    Document.MarkAsDeleted()
                                    Document.Save()
                                    ResultsText += "Deleted:  " & DocumentName & "\n"

                                Else
                                    If Me.RadComboBoxDocLevel.SelectedValue = "JO" Then
                                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                            JobRelatedDocuments = AdvantageFramework.Database.Procedures.JobDocument.LoadRelatedbyRepositoryFilename(DataContext, Document.REPOSITORY_FILENAME)
                                        End Using
                                        If JobRelatedDocuments = 0 Then
                                            files &= DocRepositoryID & ","
                                        End If
                                    ElseIf Me.RadComboBoxDocLevel.SelectedValue = "JC" Then
                                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                            JobCompRelatedDocuments = AdvantageFramework.Database.Procedures.JobComponentDocument.LoadRelatedbyRepositoryFilename(DataContext, Document.REPOSITORY_FILENAME)
                                        End Using
                                        If JobCompRelatedDocuments = 0 Then
                                            files &= DocRepositoryID & ","
                                        End If
                                    Else
                                        files &= DocRepositoryID & ","
                                    End If
                                    Document.MarkAsDeleted()
                                    Document.Save()

                                    Dim documentRepository As New DocumentRepository(Me.ConnectionString)
                                    DocPath = documentRepository.Path

                                    ResultsText += "Deleted:  " & DocumentName & "\n"

                                End If

                            End If

                            'End If

                        Next

                        Dim documentRepositiory As New DocumentRepository(Me.ConnectionString)

                        If files <> "" Then
                            files = MiscFN.RemoveTrailingDelimiter(files, ",")
                            filenames = files.Split(",")

                            For i = 0 To filenames.Length - 1
                                If documentRepositiory.DeleteDocument(0, filenames(i)) Then
                                    'Document.Save()
                                End If
                            Next
                        End If

                        Me.RadGridJobComponentDocuments.Rebind()

                        If ResultsText.Trim() <> "" Then Me.ShowMessage(ResultsText)

                End Select

            Case "ClearSearch"

                Dim SearchCriteriaTextBox As System.Web.UI.WebControls.TextBox = Me.SearchArea.FindControl("SearchCriteriaTextBox")

                SearchCriteriaTextBox.Text = ""
                SearchCriteriaTextBox.Focus()

                Me.RadGridJobComponentDocuments.Rebind()

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                qs.Add("bm", "1")

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Documents
                    .UserCode = Session("UserCode")
                    .Name = "Docs for Job: " & Me.JobNumber.ToString() & "/" & Me.JobComponentNbr.ToString()
                    .PageURL = "Documents_JobComponent.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()
                End If

            Case "ProofHQDownload"

                If Session("DocFilterLevel") Is Nothing Or Session("DocFilterValue") Is Nothing Then

                    Me.ShowMessage("Please select a level to attach the document.")
                    Exit Sub

                Else

                    If Me.RadComboBoxDocLevel.SelectedValue = "JO" Then
                        If Session("DocFilterLevel") = "" Or CInt(Session("DocFilterValue")) <= 0 Then

                            Me.ShowMessage("Please select a level to attach the document.")
                            Exit Sub

                        Else

                            URL = "Documents_ProofHQDownload.aspx?Caller=" & Me.PageFilename & "&DocumentLevelCode=" & Session("DocFilterLevel") &
                                    "&DocumentLevelValue=" & Session("DocFilterValue") &
                                    "&JobNumber=" & Me.JobNumber & "&JobComponentNumber=" & Me.JobComponentNbr

                        End If
                    Else
                        If Session("DocFilterLevel") = "" Or Session("DocFilterValue") = "" Then

                            Me.ShowMessage("Please select a level to attach the document.")
                            Exit Sub

                        Else

                            URL = "Documents_ProofHQDownload.aspx?Caller=" & Me.PageFilename & "&DocumentLevelCode=" & Session("DocFilterLevel") &
                                    "&DocumentLevelValue=" & Session("DocFilterValue") &
                                    "&JobNumber=" & Me.JobNumber & "&JobComponentNumber=" & Me.JobComponentNbr

                        End If
                    End If

                End If

                Me.OpenWindow("", URL)

            Case "ProofHQUpload"

                If RadGridJobComponentDocuments.SelectedItems.Count = 0 Then

                    Me.ShowMessage("Please select a document to upload.")

                ElseIf RadGridJobComponentDocuments.SelectedItems.Count > 1 Then

                    Me.ShowMessage("Please only select one document to upload.")

                ElseIf RadGridJobComponentDocuments.SelectedItems.Count = 1 Then

                    If Session("DocFilterLevel") Is Nothing Or Session("DocFilterValue") Is Nothing Then

                        Me.ShowMessage("Please select a level to attach the document.")
                        Exit Sub

                    Else

                        If Me.RadComboBoxDocLevel.SelectedValue = "JO" Then
                            If Session("DocFilterLevel") = "" Or CInt(Session("DocFilterValue")) <= 0 Then

                                Me.ShowMessage("Please select a level to attach the document.")
                                Exit Sub

                            Else

                                URL = "Documents_ProofHQUpload.aspx?Caller=" & Me.PageFilename & "&DocumentID=" & RadGridJobComponentDocuments.SelectedItems(0).Attributes("DocumentId") &
                                        "&DocumentLevelCode=" & Session("DocFilterLevel") & "&DocumentLevelValue=" & Session("DocFilterValue") &
                                        "&JobNumber=" & Me.JobNumber & "&JobComponentNumber=" & Me.JobComponentNbr

                            End If
                        Else
                            If Session("DocFilterLevel") = "" Or Session("DocFilterValue") = "" Then

                                Me.ShowMessage("Please select a level to attach the document.")
                                Exit Sub

                            Else

                                URL = "Documents_ProofHQUpload.aspx?Caller=" & Me.PageFilename & "&DocumentID=" & RadGridJobComponentDocuments.SelectedItems(0).Attributes("DocumentId") &
                                        "&DocumentLevelCode=" & Session("DocFilterLevel") & "&DocumentLevelValue=" & Session("DocFilterValue") &
                                        "&JobNumber=" & Me.JobNumber & "&JobComponentNumber=" & Me.JobComponentNbr

                            End If
                        End If


                    End If

                    Me.OpenWindow("", URL)

                End If

            Case "ShowThumbnails"

                Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.FilesRadToolbar.FindButtonByCommandName("ShowThumbnails")
                Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
                av.getAllAppVars()
                If ThumbnailsRadToolBarButton IsNot Nothing Then av.setAppVar("DocumentsJobComponentAspx", ThumbnailsRadToolBarButton.Checked, "Boolean")

                Me.RadGridJobComponentDocuments.Rebind()

        End Select
    End Sub

    Private Sub RadComboBoxDocLevel_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDocLevel.SelectedIndexChanged

        Me.SetPageVariables()

    End Sub

#End Region
#Region " Page "

    Private Sub Documents_JobComponent_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.ConnectionString = Session("ConnString")

        Me._AccessPrivate = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments) = 1

        Try
            PageMode = Request.QueryString("m").ToString()
        Catch ex As Exception
            PageMode = "AD"
        End Try

        If Not Request.QueryString("bm") Is Nothing Then

            Session("DocFilterLevel") = "JC"

        End If

        Me.JobNumber = CType(Request.QueryString("JobNum"), Integer)
        Me.JobComponentNbr = CType(Request.QueryString("JobCompNum"), Integer)

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNumber = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobComponentNbr = qs.JobComponentNumber

        Me.FilesRadToolbar.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        If qs.IsJobDashboard = True Then

            _IsJobDashboard = True
            'Me.TdFilter.Visible = False
            'Me.FilesRadToolbar.FindItemByValue("Bookmark").Visible = False

        End If

        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

            Dim v As New cValidations(Session("ConnString"))
            If v.ValidateJobCompIsViewable(Session("UserCode"), Me.JobNumber, Me.JobComponentNbr) = False Then

                'Server.Transfer("NoAccess.aspx")
                Me.ShowMessage("Access to this job/comp is denied")
                Me.CloseThisWindow()
                Exit Sub

            End If

        End If

        Me.RadComboBoxDocLevel = Me.FilesRadToolbar.FindItemByValue("RadToolBarButtonLevel").FindControl("RadComboBoxDocLevel")

    End Sub
    Protected Sub Documents_JobComponent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim IsProofHQEnabled As Boolean = False
        Dim RadToolBarItem As Telerik.Web.UI.RadToolBarItem = Nothing
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
        Dim Job As AdvantageFramework.Database.Views.JobView = Nothing
        Dim JobComponent As AdvantageFramework.Database.Views.JobComponentView = Nothing

        _DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

        If _DbContext IsNot Nothing Then

            _Agency = AdvantageFramework.Database.Procedures.Agency.Load(_DbContext)

        End If

        If Not Me.IsPostBack And Not Me.IsCallback Then
            If PageMode = "A" Then
                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts)
            End If
            If PageMode = "D" Then
                If Me.IsClientPortal = True Then
                    Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Documents)
                Else
                    Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager)
                End If
            End If

            Me.JobNumber = Me.JobNumber
            Me.JobComponentNbr = Me.JobComponentNbr

            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDocLevel, Session("DocFilterLevel"), False)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If Session("DocFilterLevel") = "JC" Then

                    Session("DocFilterValue") = Me.JobNumber & "," & Me.JobComponentNbr
                    Session("HistoryFK") = Me.JobNumber & "," & Me.JobComponentNbr

                    Try

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNbr)

                    Catch ex As Exception
                        JobComponent = Nothing
                    End Try

                    If JobComponent IsNot Nothing Then

                        Session("DocClientValue") = JobComponent.ClientCode
                        Session("DocDivisionValue") = JobComponent.DivisionCode
                        Session("DocProductValue") = JobComponent.ProductCode

                    End If

                Else

                    Session("DocFilterValue") = Me.JobNumber
                    Session("HistoryFK") = Me.JobNumber

                    Try

                        Job = AdvantageFramework.Database.Procedures.JobView.LoadByJobNumber(DbContext, Me.JobNumber)

                    Catch ex As Exception
                        Job = Nothing
                    End Try

                    If Job IsNot Nothing Then

                        Session("DocClientValue") = Job.ClientCode
                        Session("DocDivisionValue") = Job.DivisionCode
                        Session("DocProductValue") = Job.ProductCode

                    End If

                End If

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                IsProofHQEnabled = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

                If IsProofHQEnabled AndAlso Me.IsClientPortal = False And Me._Agency.AllowProofHQ = True Then

                    RadToolBarItem = Me.FilesRadToolbar.FindItemByValue("ProofHQUpload")

                    If RadToolBarItem IsNot Nothing Then

                        RadToolBarItem.Visible = True

                    End If

                    RadToolBarItem = Me.FilesRadToolbar.FindItemByValue("ProofHQDownload")

                    If RadToolBarItem IsNot Nothing Then

                        RadToolBarItem.Visible = True

                    End If

                    RadToolBarItem = Me.FilesRadToolbar.FindItemByValue("ProofHQDownloadSeparator")

                    If RadToolBarItem IsNot Nothing Then

                        RadToolBarItem.Visible = True

                    End If

                    GridColumn = RadGridJobComponentDocuments.MasterTableView.GetColumn("GridTemplateColumnProofHQ")

                    If GridColumn IsNot Nothing Then

                        GridColumn.Visible = True

                    End If

                End If

            End Using

            'If cAgency.IsUsingLabels = False Then

            '    Me.FilesRadToolbar.FindItemByValue("LabelView").Visible = False
            '    Me.FilesRadToolbar.FindItemByValue("LabelViewSeparator").Visible = False

            'End If

            Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.FilesRadToolbar.FindButtonByCommandName("ShowThumbnails")
            Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
            av.getAllAppVars()
            If ThumbnailsRadToolBarButton IsNot Nothing Then ThumbnailsRadToolBarButton.Checked = av.getAppVar("DocumentsJobComponentAspx", "Boolean", "true").ToString.ToLower = "true"

        Else 'it's a postback
            Select Case Me.EventArgument
                Case "Refresh", "HidePopUpRefresh"
                    Me.RadWindowManager.Windows(0).VisibleOnPageLoad = False
                    Me.RadWindowManager.Windows(1).VisibleOnPageLoad = False
                    Me.RadComboBoxDocLevel.SelectedValue = "JC"
                    Me.RadGridJobComponentDocuments.Rebind()
                Case "HidePopups"
                    Me.RadWindowManager.Windows(0).VisibleOnPageLoad = False
                    Me.RadWindowManager.Windows(1).VisibleOnPageLoad = False
            End Select
            Select Case Me.EventTarget
                Case "RemoveLabel"

                    If Me.EventArgument.Contains("|") = True Then

                        Dim ar() As String
                        ar = Me.EventArgument.Split("|")

                        If ar IsNot Nothing AndAlso ar.Length = 2 Then

                            Using dc As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                Dim ld As AdvantageFramework.Database.Entities.LabelDocument

                                ld = AdvantageFramework.Database.Procedures.LabelDocument.LoadByLabelIDAndDocumentID(dc, ar(1), ar(0))

                                If ld IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.LabelDocument.Delete(dc, ld)

                                End If

                            End Using

                        End If

                    End If

                    Me.RadGridJobComponentDocuments.Rebind()

                Case Else

            End Select
        End If

        If Me.IsClientPortal = True Then

            Me.RadComboBoxDocLevel.Items.FindItemByValue("JO").Visible = False
            Me.FilesRadToolbar.FindItemByValue("Bookmark").Visible = False

        End If

        If Me._ShowThumbnailsRadToolBarButton Is Nothing Then

            Me._ShowThumbnailsRadToolBarButton = Me.FilesRadToolbar.FindButtonByCommandName("ShowThumbnails")

        End If

    End Sub
    Private Sub Documents_JobComponent_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try
                If Me.PageMode = "A" Then
                    Me.Title = "Alerts"
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

    Private Function GetFileList(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.Document)

        Dim DocumentIDs As New Generic.List(Of Integer)
        Dim DocList As New Generic.List(Of AdvantageFramework.Database.Entities.Document)
        Dim Doc As AdvantageFramework.Database.Entities.Document = Nothing
        Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

        Dim Criteria As String = ""
        Dim SearchCriteriaTextBox As System.Web.UI.WebControls.TextBox = Me.SearchArea.FindControl("SearchCriteriaTextBox")
        Criteria = SearchCriteriaTextBox.Text.Trim.ToLower

        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                DocumentIDs = DataContext.JobDocuments.Where(Function(Entity) Entity.JobNumber = JobNumber).Select(Function(Entity) CInt(Entity.DocumentID)).ToList

            End Using

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

            If Not Job Is Nothing Then

                For Each Doc In (From Document In DbContext.Documents
                                 Where DocumentIDs.Contains(Document.ID)
                                 Select Document)

                    DocList.Add(Doc)

                Next

            End If

            If JobComponentNbr > 0 Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    DocumentIDs = DataContext.JobComponentDocuments.Where(Function(Entity) Entity.JobNumber = JobNumber AndAlso Entity.JobComponentNumber = JobComponentNbr).Select(Function(Entity) CInt(Entity.DocumentID)).ToList

                End Using

                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNbr)

                If Not JobComponent Is Nothing Then

                    For Each Doc In (From Document In DbContext.Documents
                                     Where DocumentIDs.Contains(Document.ID)
                                     Select Document)

                        DocList.Add(Doc)

                    Next

                End If

            End If

            For Each ar In Job.AccountReceivables

                For Each ard In ar.AccountReceivableDocuments

                    DocList.Add(ard.Document)

                Next

            Next

        End Using

        Return DocList

    End Function
    Private Function FillFileListFromFilter(ByVal TheLevel As String, ByVal TheValue As String) As System.Data.DataView

        Dim retDataView As System.Data.DataView
        Dim Criteria As String = ""
        Dim SearchCriteriaTextBox As System.Web.UI.WebControls.TextBox = Me.SearchArea.FindControl("SearchCriteriaTextBox")
        Criteria = SearchCriteriaTextBox.Text.Trim.ToLower

        Dim CanAccessARInvoice As Boolean = False
        Dim CanAccessAPInvoice As Boolean = False

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ARInvoice, False)) Then

            CanAccessARInvoice = True

        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_APInvoice, False)) Then

            CanAccessAPInvoice = True

        End If

        Dim DocList As New List(Of Long)

        Select Case TheLevel
            Case "JO"

                Try
                    Dim Documents As New vCurrentJobDocuments(Me.ConnectionString)

                    Documents.Where.JOB_NUMBER.Value = TheValue
                    Documents.Query.CaseSensitive = False

                    If _AccessPrivate = False Then

                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual

                    End If
                    If CanAccessARInvoice = False And CanAccessAPInvoice = False Then

                        Documents.Where.LEVEL.Value = "'AR Invoice', 'AP Invoice'"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotIn

                    ElseIf CanAccessARInvoice = False Then

                        Documents.Where.LEVEL.Value = "AR Invoice"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual

                    ElseIf CanAccessAPInvoice = False Then

                        Documents.Where.LEVEL.Value = "AP Invoice"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual

                    End If
                    If Criteria <> "" Then

                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()

                        Documents.Query.Load("")

                    Else

                        Documents.Query.Load()

                    End If

                    For Each DataRow As DataRowView In Documents.DefaultView

                        DocList.Add(DataRow.Row("DOCUMENT_ID"))

                    Next

                    If DocList IsNot Nothing Then

                        Me._DocumentIDs = DocList.ToArray()

                    End If
                    If Me._DocumentIDs IsNot Nothing Then

                        Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Me._AllLabelsNeeded = AdvantageFramework.Database.Procedures.Label.LoadDistinctByDocumentIDs(dc, Me._DocumentIDs).ToList()
                            Me._DocumentLabels = AdvantageFramework.Database.Procedures.LabelDocument.LoadByDocumentIDs(dc, Me._DocumentIDs).ToList()

                        End Using

                    End If

                    Return Documents.DefaultView

                Catch ex As Exception
                    Me.ShowMessage("JO filter error: " & ex.Message.ToString())
                End Try

            Case "JC"
                Try
                    Dim Documents As New vCurrentJobComponentDocuments(Me.ConnectionString)
                    Dim FKs() As String = TheValue.Split(",")
                    Documents.Where.JOB_NUMBER.Value = FKs(0)
                    Documents.Where.JOB_COMPONENT_NUMBER.Value = FKs(1)
                    If IsClientPortal = True Or Me._AccessPrivate = False Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If CanAccessARInvoice = False And CanAccessAPInvoice = False Then
                        Documents.Where.LEVEL.Value = "'AR Invoice', 'AP Invoice'"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotIn
                    ElseIf CanAccessARInvoice = False Then
                        Documents.Where.LEVEL.Value = "AR Invoice"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    ElseIf CanAccessAPInvoice = False Then
                        Documents.Where.LEVEL.Value = "AP Invoice"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    Documents.Query.CaseSensitive = False
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load()
                    Else
                        Documents.Query.Load()
                    End If

                    For Each DataRow As DataRowView In Documents.DefaultView

                        DocList.Add(DataRow.Row("DOCUMENT_ID"))

                    Next
                    If DocList IsNot Nothing Then

                        Me._DocumentIDs = DocList.ToArray()

                    End If
                    If Me._DocumentIDs IsNot Nothing Then

                        Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Me._AllLabelsNeeded = AdvantageFramework.Database.Procedures.Label.LoadDistinctByDocumentIDs(dc, Me._DocumentIDs).ToList()
                            Me._DocumentLabels = AdvantageFramework.Database.Procedures.LabelDocument.LoadByDocumentIDs(dc, Me._DocumentIDs).ToList()

                        End Using

                    End If

                    Return Documents.DefaultView

                Catch ex As Exception
                    Me.ShowMessage("JC Filter error:" & ex.Message.ToString())
                End Try
        End Select
    End Function
    Protected Sub ToggleRowSelection(ByVal sender As Object, ByVal e As EventArgs)
        ''
        'CType(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridItem).Selected = CType(sender, CheckBox).Checked
        Dim access As Integer = 0
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = Nothing

        CurrentGridRow = CType(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)

        CurrentGridRow.Selected = CType(sender, CheckBox).Checked
        'Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = Me.RadGridDocuments.SelectedItems.Count > 0
        access = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload)

        If RadComboBoxDocLevel.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation Then

            For Counter = Me.RadGridJobComponentDocuments.SelectedItems.Count - 1 To 0 Step -1

                CurrentGridRow = CType(Me.RadGridJobComponentDocuments.SelectedItems(Counter), Telerik.Web.UI.GridDataItem)

                If CurrentGridRow("GridBoundColumnLevel").Text = "Task" OrElse
                        CurrentGridRow("GridBoundColumnLevel").Text = "Job Component" Then

                    Me.FilesRadToolbar.FindItemByValue("Delete").Enabled = ((access <> 0) AndAlso Me.RadGridJobComponentDocuments.SelectedItems.Count > 0)

                    If Me.FilesRadToolbar.FindItemByValue("Delete").Enabled = False Then

                        Exit For

                    End If

                Else

                    Me.FilesRadToolbar.FindItemByValue("Delete").Enabled = False
                    Exit For

                End If

            Next

        Else

            Me.FilesRadToolbar.FindItemByValue("Delete").Enabled = ((access <> 0) AndAlso Me.RadGridJobComponentDocuments.SelectedItems.Count > 0)

        End If

        If RadGridJobComponentDocuments.SelectedItems.Count = 0 Then

            Me.FilesRadToolbar.FindItemByValue("ProofHQUpload").Enabled = False

        ElseIf RadGridJobComponentDocuments.SelectedItems.Count > 1 Then

            Me.FilesRadToolbar.FindItemByValue("ProofHQUpload").Enabled = False

        ElseIf RadGridJobComponentDocuments.SelectedItems.Count = 1 And Me._Agency.AllowProofHQ = True Then

            Me.FilesRadToolbar.FindItemByValue("ProofHQUpload").Enabled = True

        End If

    End Sub
    Private Sub SetPageVariables()

        'objects
        Dim Job As AdvantageFramework.Database.Views.JobView = Nothing
        Dim JobComponent As AdvantageFramework.Database.Views.JobComponentView = Nothing

        Session("DocFilterLevel") = ""
        Session("DocFilterValue") = ""

        If Me.RadComboBoxDocLevel.SelectedIndex = 0 Then

            Me.ShowMessage("Please select filter level.")
            Exit Sub

        Else

            Dim SearchCriteriaTextBox As System.Web.UI.WebControls.TextBox = Me.SearchArea.FindControl("SearchCriteriaTextBox")
            SearchCriteriaTextBox.Text = ""

            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Session("DocFilterLevel") = Me.RadComboBoxDocLevel.SelectedValue

            Select Case Me.RadComboBoxDocLevel.SelectedValue

                Case "JO"

                    Session("DocFilterValue") = Me.JobNumber
                    Session("HistoryFK") = Me.JobNumber

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            Job = AdvantageFramework.Database.Procedures.JobView.LoadByJobNumber(DbContext, Me.JobNumber)

                        Catch ex As Exception
                            Job = Nothing
                        End Try

                        If Job IsNot Nothing Then

                            Session("DocClientValue") = Job.ClientCode
                            Session("DocDivisionValue") = Job.DivisionCode
                            Session("DocProductValue") = Job.ProductCode

                        End If

                    End Using

                Case "JC"

                    Session("DocFilterValue") = Me.JobNumber & "," & Me.JobComponentNbr
                    Session("HistoryFK") = Me.JobNumber & "," & Me.JobComponentNbr

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNbr)

                        Catch ex As Exception
                            JobComponent = Nothing
                        End Try

                        If JobComponent IsNot Nothing Then

                            Session("DocClientValue") = JobComponent.ClientCode
                            Session("DocDivisionValue") = JobComponent.DivisionCode
                            Session("DocProductValue") = JobComponent.ProductCode

                        End If

                    End Using

            End Select

            Me.RadGridJobComponentDocuments.Rebind()

        End If

    End Sub
    Private Sub SetPage()

        If Me.PageMode = "D" Then

            Me.DocCheck()

        End If

    End Sub
    Private Sub DocCheck()

        Dim access As Integer = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload)

        If access = 0 Then

            Me.FilesRadToolbar.FindItemByValue("Upload").Visible = False

        Else

            Me.FilesRadToolbar.FindItemByValue("Upload").Visible = True

        End If

    End Sub
    Private Sub ClearFilter()

    End Sub
    Private Sub ClearFilterDoc()

        Session("DocFilterLevel") = ""
        Session("DocFilterValue") = ""

        Me.RadComboBoxDocLevel.SelectedIndex = 0

    End Sub
    Public Function SetCheckBox(ByVal Value As Integer) As Boolean
        Try
            If Value = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function
    Public Function GetDoc(ByVal DocumentID As String) As DataTable
        Dim dt As DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterDocumentID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
        parameterDocumentID.Value = DocumentID
        arParams(0) = parameterDocumentID

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "proc_DOCUMENTSLoadByPrimaryKey", "tblcmp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:Doc.aspx Routine:GetDoc", Err.Description)
        End Try

        Return dt
    End Function

    ''#Region " Label Tooltip "

    ''    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As Telerik.Web.UI.ToolTipUpdateEventArgs)

    ''        Me.UpdateToolTip(args.Value, args.UpdatePanel)

    ''    End Sub
    ''    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)

    ''        Dim ctrl As System.Web.UI.Control = Page.LoadControl("Document_Label_Tree.ascx")
    ''        ctrl.ID = "DocumentLabelTreeUserControl1"
    ''        panel.ContentTemplateContainer.Controls.Add(ctrl)

    ''        Dim t As New Document_Label_Tree

    ''        t = DirectCast(ctrl, Document_Label_Tree)
    ''        t.DocumentID = ArguementValue
    ''        t.Tree.Nodes.Clear()
    ''        t.LoadLabels()
    ''        t.LoadExistingLabelsForDocument()

    ''    End Sub

    ''#End Region

#End Region

End Class
