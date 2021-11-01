Imports Ionic.Zip
Imports Telerik.Web.UI

Public Class Documents_LabelView
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _AccessPrivate As Boolean = False
    Private _ShowThumbnailsRadToolBarButton As RadToolBarButton

#End Region

#Region " Properties "

    Private Property _SelectedLabelID As Integer
        Get
            If ViewState("_SelectedLabelID") Is Nothing Then

                ViewState("_SelectedLabelID") = 0

            End If

            Return CType(ViewState("_SelectedLabelID"), Integer)

        End Get
        Set(value As Integer)

            ViewState("_SelectedLabelID") = value

        End Set
    End Property
    Private Property _JobNumber As Integer
        Get
            If ViewState("_JobNumber") Is Nothing Then

                ViewState("_JobNumber") = 0

            End If

            Return CType(ViewState("_JobNumber"), Integer)

        End Get
        Set(value As Integer)

            ViewState("_JobNumber") = value

        End Set
    End Property
    Private Property _JobComponentNumber As Integer
        Get
            If ViewState("_JobComponentNumber") Is Nothing Then

                ViewState("_JobComponentNumber") = 0

            End If

            Return CType(ViewState("_JobComponentNumber"), Integer)

        End Get
        Set(value As Integer)

            ViewState("_JobComponentNumber") = value

        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub DocumentLabelTree_NodeClick(sender As Object, e As RadTreeNodeEventArgs) Handles DocumentLabelTree.NodeClick

        If Me.DocumentLabelTree.Tree.SelectedNode IsNot Nothing Then

            Me._SelectedLabelID = Me.DocumentLabelTree.Tree.SelectedNode.Value
            Me.RadGridDocuments.Rebind()

        End If

    End Sub

    Private Sub ImageButtonEditLabels_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonEditLabels.Click

        Me.OpenWindow("", "Maintenance_Documents.aspx?tabidx=1")

    End Sub

    Private Sub RadGridDocuments_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridDocuments.ItemCommand

    End Sub
    Private _HasImage As Boolean = False
    Private _DocumentRepository As DocumentRepository
    Private _DbContext As AdvantageFramework.Database.DbContext
    Private _Agency As AdvantageFramework.Database.Entities.Agency
    Private Sub RadGridDocuments_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridDocuments.ItemDataBound

        Select Case e.Item.ItemType

            Case GridItemType.Header

                _DocumentRepository = New DocumentRepository(Me._Session.ConnectionString)
                _DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                If _DbContext IsNot Nothing Then

                    _Agency = AdvantageFramework.Database.Procedures.Agency.Load(_DbContext)

                End If

            Case GridItemType.Item, GridItemType.AlternatingItem

                Dim CurrentDocument As AdvantageFramework.DocumentManager.Classes.Document
                Dim CurrentRow As GridDataItem = e.Item

                CurrentDocument = CurrentRow.DataItem

                If CurrentDocument IsNot Nothing Then

                    CurrentRow.Attributes.Add("DocumentId", CurrentDocument.ID)

                    Dim ProofHQURL As String = ""

                    Try

                        If CurrentDocument.ProofHQUrl IsNot Nothing AndAlso String.IsNullOrWhiteSpace(CurrentDocument.ProofHQUrl) = False Then

                            ProofHQURL = CurrentDocument.ProofHQUrl

                        End If

                    Catch ex As Exception

                        ProofHQURL = ""

                    End Try

                    Dim FileName As String = String.Empty
                    Dim RepositoryFileName As String = String.Empty
                    Dim Description As String = String.Empty
                    Dim MimeType As String = String.Empty

                    Try
                        FileName = CurrentDocument.FileName
                    Catch ex As Exception
                        FileName = String.Empty
                    End Try
                    Try
                        Description = CurrentDocument.Description
                    Catch ex As Exception
                        Description = String.Empty
                    End Try
                    Try
                        RepositoryFileName = CurrentDocument.FileSystemFileName
                    Catch ex As Exception
                        RepositoryFileName = String.Empty
                    End Try
                    Try
                        MimeType = CurrentDocument.MIMEType
                    Catch ex As Exception
                        MimeType = String.Empty
                    End Try

                    AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(Nothing,
                                                                                            DirectCast(e.Item.FindControl("LinkButtonDownload"), LinkButton),
                                                                                            DirectCast(e.Item.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                            Nothing, Nothing,
                                                                                            DirectCast(e.Item.FindControl("DivDocumentHistory"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentHistory"), LinkButton),
                                                                                            DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                            DirectCast(e.Item.FindControl("DivProofHQ"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonProofHQ"), LinkButton), ProofHQURL,
                                                                                            DirectCast(e.Item.FindControl("LiteralSize"), Literal).Text,
                                                                                            CurrentDocument.ID, CurrentDocument.MIMEType, FileName, CurrentDocument.FileSystemFileName, Description, CurrentDocument.FileSize,
                                                                                            "", "", 0)

                    Dim CurrentLabels As Generic.List(Of AdvantageFramework.Database.Entities.Label)
                    Dim DescriptionDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivDescription")
                    Dim KeywordsDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivKeywords")
                    Dim LabelsDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivLabels")
                    Dim CommentsDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivComments")

                    If CurrentDocument.Keywords Is Nothing OrElse CurrentDocument.Keywords.Length = 0 Then AdvantageFramework.Web.Presentation.Controls.DivHide(KeywordsDiv)
                    If CurrentDocument.Description Is Nothing OrElse CurrentDocument.Description.Length = 0 Then AdvantageFramework.Web.Presentation.Controls.DivHide(DescriptionDiv)

                    CurrentLabels = CurrentDocument.DocumentLabels

                    If CurrentLabels IsNot Nothing Then

                        If CurrentLabels.Count > 0 Then

                            For Each Label As AdvantageFramework.Database.Entities.Label In CurrentLabels

                                Dim dl As New Webvantage.Document_Label
                                dl = CType(LoadControl("Document_Label.ascx"), Webvantage.Document_Label)

                                dl.DocumentID = CurrentRow.GetDataKeyValue("ID")
                                dl.LabelID = Label.ID
                                dl.SetPostBack()
                                dl.Text = Label.Name
                                If Label.HexColor IsNot Nothing Then dl.Style = "background-color: " & Label.HexColor & ";"

                                CurrentRow("GridTemplateColumnDisplay").Controls.Add(dl)

                            Next

                        Else

                            AdvantageFramework.Web.Presentation.Controls.DivHide(LabelsDiv)

                        End If

                    Else

                        AdvantageFramework.Web.Presentation.Controls.DivHide(LabelsDiv)

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

                                                AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(_DbContext, _Agency, CurrentDocument.ID, FileBytes)

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
                                        ThumbnailImageButton.CommandArgument = CurrentDocument.ID

                                        _HasImage = True

                                    End If

                                End If

                            End If
                            'If ThumbnailImageButton IsNot Nothing Then

                            '    If _HasImage = False Then

                            '        _HasImage = _DocumentRepository.GetImageThumbnail(ThumbnailImageButton, FileName, RepositoryFileName, MimeType, "Download", CurrentDocument.ID)

                            '    Else

                            '        _DocumentRepository.GetImageThumbnail(ThumbnailImageButton, FileName, RepositoryFileName, MimeType, "Download", CurrentDocument.ID)

                            '    End If

                            'End If

                        End If

                    Catch ex As Exception
                    End Try

                End If

            Case GridItemType.Footer

                Try

                    Me.RadGridDocuments.MasterTableView.GetColumn("GridTemplateColumnThumbnail").Visible = _HasImage

                Catch ex As Exception
                End Try

        End Select

    End Sub
    Private Sub RadGridDocuments_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridDocuments.NeedDataSource

        If Me._JobNumber = 0 AndAlso Me._JobComponentNumber = 0 Then

            Me.RadGridDocuments.DataSource = AdvantageFramework.DocumentManager.LoadDocumentsByLabelID(_Session, Me._SelectedLabelID, Me._AccessPrivate)

        Else

            Me.RadGridDocuments.DataSource = AdvantageFramework.DocumentManager.LoadLabelDocumentsByJobNumberAndJobComponentNumber(_Session, Me._JobNumber,
                                                                                                                                   Me._JobComponentNumber,
                                                                                                                                   Me._AccessPrivate,
                                                                                                                                   Me._SelectedLabelID)

        End If

        Me.RadGridDocuments.MasterTableView.GetColumnSafe("GridTemplateColumnIsPrivate").Visible = Me._AccessPrivate

        'Me.RadGridDocuments.MasterTableView.GroupByExpressions.Clear()
        'Me.RadGridDocuments.MasterTableView.GroupByExpressions.Add("DocumentLevel Level Group By DocumentLevel")

    End Sub

    Private Sub RadToolbarDocumentManager_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarDocumentManager.ButtonClick
        Select Case e.Item.Value
            Case "StandardView"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.IsJobDashboard = True
                qs.JobNumber = Me._JobNumber
                qs.JobComponentNumber = Me._JobComponentNumber

                Session("FromWindow") = "ProjectView"
                Session("DocFilterLevel") = "JC"
                Session("DocFilterValue") = Me._JobNumber.ToString() & "," & Me._JobComponentNumber.ToString()

                qs.Page = "Documents_JobComponent.aspx"
                qs.Add("m", "D")

                MiscFN.ResponseRedirect(qs.ToString(True))

            Case "Refresh"

                Me.RadGridDocuments.Rebind()

            Case "Upload"

                Me.UploadFiles()

            Case "Download"

                Me.DownloadFiles()

            Case "AdvancedSearch"

                Me.OpenWindow("", "Documents_AdvancedSearch.aspx", 0, 0)

            Case "Delete"

                Me.DeleteFiles()

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                qs.Add("bm", "1")
                qs.DocumentLabelID = Me.DocumentLabelTree.Tree.SelectedNode.Value

                With b

                    .UserCode = Session("UserCode")

                    ''If Me._JobNumber > 0 AndAlso Me._JobComponentNumber > 0 Then

                    ''    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Custom
                    ''    .Name = "Docs for Job: " & Me._JobNumber.ToString() & "/" & Me._JobComponentNumber.ToString()

                    ''End If

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Custom
                    .Name = Me.DocumentLabelTree.Tree.SelectedNode.Text & " Documents "

                    .PageURL = "Documents_LabelView.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

            Case "ProofHQDownload"

                Me.ProofHqDownload()

            Case "ProofHQUpload"

                Me.ProofHqUpload()

            Case "ShowThumbnails"

                Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.RadToolbarDocumentManager.FindButtonByCommandName("ShowThumbnails")
                Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
                av.getAllAppVars()
                If ThumbnailsRadToolBarButton IsNot Nothing Then av.setAppVar("DocumentsLabelViewAspx", ThumbnailsRadToolBarButton.Checked, "Boolean")

                Me.RadGridDocuments.Rebind()

        End Select

    End Sub


#End Region
#Region " Page "

    Private Sub Documents_LabelView_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, True)

        If Me.CurrentQuerystring.JobNumber <> Nothing AndAlso Me.CurrentQuerystring.JobNumber > 0 Then Me._JobNumber = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber <> Nothing AndAlso Me.CurrentQuerystring.JobComponentNumber > 0 Then Me._JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

    End Sub
    Private Sub Documents_LabelView_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me._AccessPrivate = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments) = 1

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.ImageButtonEditLabels.Visible = Me.ImageButtonEditLabels.Visible = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_General_Documents, False) = 1

            If Me._JobNumber > 0 AndAlso Me._JobComponentNumber > 0 Then

                Me.RadToolbarDocumentManager.FindItemByValue("StandardView").Visible = True
                Me.DocumentLabelTree.ShowAllNode = True
                Me.DocumentLabelTree.SelectAllNode = True

                Me.MyUnityContextMenu.JobNumber = Me._JobNumber
                Me.MyUnityContextMenu.JobComponentNumber = Me._JobComponentNumber
                Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Documents}

            Else

                Me.MyUnityContextMenu.Visible = False

            End If

            Me.DocumentLabelTree.LoadLabels(Me._SelectedLabelID)

            Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.RadToolbarDocumentManager.FindButtonByCommandName("ShowThumbnails")
            Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
            av.getAllAppVars()
            If ThumbnailsRadToolBarButton IsNot Nothing Then ThumbnailsRadToolBarButton.Checked = av.getAppVar("DocumentsLabelViewAspx", "Boolean", "true").ToString.ToLower = "true"

        Else

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

                    Me.RadGridDocuments.Rebind()

                Case Else

            End Select

        End If

        If Me._ShowThumbnailsRadToolBarButton Is Nothing Then

            Me._ShowThumbnailsRadToolBarButton = Me.RadToolbarDocumentManager.FindButtonByCommandName("ShowThumbnails")

        End If

    End Sub

#End Region

    Private Sub DeleteFiles()

        Select Case Me.RadGridDocuments.SelectedItems.Count
            Case 0

                Me.ShowMessage("No file selected.")

            Case Is > 0

                Dim i As Integer
                Dim ResultsText As String
                Dim files As String
                Dim filenames() As String

                For i = Me.RadGridDocuments.SelectedItems.Count - 1 To 0 Step -1

                    Dim Document As New Document(Me._Session.ConnectionString)
                    Dim DocumentID As Integer = Me.RadGridDocuments.SelectedItems(i).Attributes("DocumentId")
                    Dim DocPath As String = String.Empty
                    Dim DocRepositoryID As String = String.Empty

                    Document.Where.DOCUMENT_ID.Value = DocumentID
                    If Document.Query.Load() Then
                        If Document.USER_CODE <> Session("UserCode") And Session("Admin") = False Then

                            ResultsText += "Only Webvantage user " & Document.USER_CODE & " may delete " & Document.FILENAME

                        Else

                            Dim jobcomp As New JobComponentDocuments(Session("ConnString"))

                            jobcomp.Where.DOCUMENT_ID.Value = DocumentID

                            If jobcomp.Query.Load() Then

                                jobcomp.MarkAsDeleted()
                                jobcomp.Save()

                            End If

                            Dim DocumentName As String = Document.FILENAME
                            DocRepositoryID = Document.REPOSITORY_FILENAME
                            If Document.MIME_TYPE = "URL" Then

                                Document.MarkAsDeleted()
                                Document.Save()
                                ResultsText += "Deleted - " & DocumentName

                            Else

                                Document.MarkAsDeleted()
                                Document.Save()
                                Dim documentRepository As New DocumentRepository(Me._Session.ConnectionString)
                                DocPath = documentRepository.Path
                                files &= DocRepositoryID & ","
                                ResultsText += "Deleted - " & DocumentName

                            End If

                        End If

                    End If

                Next

                Dim documentRepositiory As New DocumentRepository(Me._Session.ConnectionString)
                files = MiscFN.RemoveTrailingDelimiter(files, ",")
                filenames = files.Split(",")

                Session("DocResultsText") = ResultsText

                Me.RadGridDocuments.Rebind()
                Me.ShowMessage(ResultsText)

        End Select
    End Sub
    Private Sub DownloadFiles()

        Select Case Me.RadGridDocuments.SelectedItems.Count
            Case 0

                Me.ShowMessage("No file(s) selected.")

            Case 1

                Dim DocumentId As Integer = Me.RadGridDocuments.SelectedItems(0).Attributes("DocumentId")
                Me.DeliverFile(DocumentId)

            Case Is > 1

                Dim GridItem As Telerik.Web.UI.GridItem
                Dim outputStream As New System.IO.MemoryStream
                Dim zip As New ZipFile

                'zipOutStream.SetLevel(5) ' Medium compression
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

                Dim rep As New DocumentRepository(_Session.ConnectionString)
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim CurrDoc As AdvantageFramework.Database.Entities.Document

                    For Each GridItem In Me.RadGridDocuments.SelectedItems

                        Dim DocumentId As Integer = GridItem.Attributes("DocumentId")
                        Dim Document As New Document(_Session.ConnectionString)

                        If DocumentId > 0 Then

                            CurrDoc = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                            If CurrDoc IsNot Nothing Then

                                Dim r As DataRow
                                r = DtRecs.NewRow()
                                r("DocId") = DocumentId
                                r("Filename") = CurrDoc.FileName
                                r("RepositoryFilename") = CurrDoc.FileSystemFileName
                                r("UploadedDate") = CurrDoc.UploadedDate
                                DtRecs.Rows.Add(r)

                                CurrDoc = Nothing

                            End If

                        End If

                    Next

                End Using

                If Not DtRecs Is Nothing Then

                    If DtRecs.Rows.Count > 0 Then

                        rep.GetDocuments(DtRecs, zip)

                    End If

                End If

                zip.Save(Response.OutputStream)

                'Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False

                With Response

                    .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                    .ContentType = "application/zip"
                    .End()

                End With

        End Select

    End Sub
    Private Sub ProofHqUpload()

        Session("DocFilterLevel") = "JC"
        Session("DocFilterValue") = Me._JobNumber & "," & Me._JobComponentNumber
        Dim URL As String = ""

        If RadGridDocuments.SelectedItems.Count = 0 Then

            Me.ShowMessage("No document selected.")

        ElseIf RadGridDocuments.SelectedItems.Count > 1 Then

            Me.ShowMessage("Please only select one document to upload.")

        ElseIf RadGridDocuments.SelectedItems.Count = 1 Then

            If Session("DocFilterLevel") Is Nothing Or Session("DocFilterValue") Is Nothing Then

                Me.ShowMessage("Please select a level to attach the document.")
                Exit Sub

            Else

                If Session("DocFilterLevel") = "" Or Session("DocFilterValue") = "" Then

                    Me.ShowMessage("Please select a level to attach the document.")
                    Exit Sub

                Else

                    URL = "Documents_ProofHQUpload.aspx?Caller=" & Me.PageFilename & "&DocumentID=" & RadGridDocuments.SelectedItems(0).Attributes("DocumentId") &
                                  "&DocumentLevelCode=" & Session("DocFilterLevel") & "&DocumentLevelValue=" & Session("DocFilterValue") &
                                  "&JobNumber=" & Me._JobNumber & "&JobComponentNumber=" & Me._JobComponentNumber

                End If

            End If

            Me.OpenWindow("", URL)

        End If

    End Sub
    Private Sub ProofHqDownload()

        Session("DocFilterLevel") = "JC"
        Session("DocFilterValue") = Me._JobNumber & "," & Me._JobComponentNumber
        Dim URL As String = ""
        URL = "Documents_ProofHQDownload.aspx?Caller=" & Me.PageFilename & "&DocumentLevelCode=" & Session("DocFilterLevel") &
                                "&DocumentLevelValue=" & Session("DocFilterValue") &
                                "&JobNumber=" & Me._JobNumber & "&JobComponentNumber=" & Me._JobComponentNumber

        Me.OpenWindow("", URL)

    End Sub
    Private Sub UploadFiles()

        Session("DocFilterLevel") = "JC"
        Session("DocFilterValue") = Me._JobNumber & "," & Me._JobComponentNumber

        Dim URL As String = ""

        URL = "Documents_Upload.aspx?caller=" & Me.PageFilename & "&Level=" & Session("DocFilterLevel") & "&FK=" &
              Session("HistoryFK") & "&Value=" & Session("DocFilterValue") & "&j=" & Me._JobNumber & "&jc=" & Me._JobComponentNumber

        Me.OpenWindow("Upload a new document", URL, 550, 575)

    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = Me._JobNumber
        Me.MyUnityContextMenu.JobComponentNumber = Me._JobComponentNumber

    End Sub

#End Region

End Class
