Imports Telerik.Web.UI

Public Class Alert_DigitalAssetReview_AddAsset
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ThumbnailURL As String = String.Empty
    Private _CustomSubject As String = String.Empty
    ''''Public currentWindowsIdentity As System.Security.Principal.WindowsIdentity

#End Region

#Region " Properties "

    Private Property JobNumber As Integer
        Get
            If ViewState("JobNumber") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("JobNumber"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("JobNumber") = value
        End Set
    End Property
    Private Property JobComponentNumber As Short
        Get
            If ViewState("JobComponentNumber") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("JobComponentNumber"), Short)
            End If
        End Get
        Set(value As Short)
            ViewState("JobComponentNumber") = value
        End Set
    End Property
    Private Property ConceptShareProjectID As Integer
        Get
            If ViewState("ConceptShareProjectID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("ConceptShareProjectID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("ConceptShareProjectID") = value
        End Set
    End Property
    Private Property ConceptShareReviewID As Integer
        Get
            If ViewState("ConceptShareReviewID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("ConceptShareReviewID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("ConceptShareReviewID") = value
        End Set
    End Property
    Private Property AlertID As Integer
        Get
            If ViewState("AlertID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("AlertID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("AlertID") = value
        End Set
    End Property
    Private Property BaseFilename As String
        Get
            If ViewState("BaseFilename") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("BaseFilename")
            End If
        End Get
        Set(value As String)
            ViewState("BaseFilename") = value
        End Set
    End Property
    Private Property BaseAssetID As Integer
        Get
            If ViewState("BaseAssetID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("BaseAssetID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("BaseAssetID") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub CheckBoxProcessZip_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxProcessZip.CheckedChanged


    End Sub
    Private Sub RadioButtonListUploadType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListUploadType.SelectedIndexChanged

        Me.MultiViewUploadType.ActiveViewIndex = Me.RadioButtonListUploadType.SelectedIndex

        Select Case Me.RadioButtonListUploadType.SelectedIndex
            Case 1

                Me.RadListViewDocRepositoryThumbs.Rebind()

        End Select

    End Sub
    Private Sub RadListViewDocRepositoryThumbs_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewDocRepositoryThumbs.NeedDataSource

        Dim Thumbs As Generic.List(Of AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail)
        If Me.RadioButtonListUploadType.SelectedItem IsNot Nothing AndAlso Me.RadioButtonListUploadType.SelectedItem.Value = "DocumentRepository" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim Agency As AdvantageFramework.Database.Entities.Agency
                Dim dr As New DocumentRepository(_Session.ConnectionString)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    Thumbs = dr.GetImageThumbnails(DbContext, Agency, Me.JobNumber, Me.JobComponentNumber)

                End If

            End Using

        End If

        If Thumbs Is Nothing Then Thumbs = New Generic.List(Of AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail)

        Me.RadListViewDocRepositoryThumbs.DataSource = Thumbs

    End Sub
    Private _DocumentRepository As DocumentRepository
    Private Sub RadListViewDocRepositoryThumbs_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewDocRepositoryThumbs.ItemDataBound

        If _DocumentRepository Is Nothing Then

            _DocumentRepository = New DocumentRepository(Me._Session.ConnectionString)

        End If

        Select Case e.Item.ItemType

            Case RadListViewItemType.AlternatingItem, RadListViewItemType.DataItem

                _ThumbnailURL = String.Empty

                Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)

                If ListItem IsNot Nothing Then

                    Dim RepositoryThumbnail As AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail

                    Try

                        RepositoryThumbnail = DirectCast(ListItem.DataItem, AdvantageFramework.ConceptShare.Classes.RepositoryThumbnail)

                    Catch ex As Exception
                        RepositoryThumbnail = Nothing
                    End Try

                    If RepositoryThumbnail IsNot Nothing Then

                        Dim DocumentThumbImage As System.Web.UI.WebControls.Image = ListItem.FindControl("ImageDocumentThumb")
                        Dim DocumentTypeDiv As HtmlControls.HtmlControl = ListItem.FindControl("DivDocumentType")

                        DocumentThumbImage.Visible = False
                        DocumentTypeDiv.Visible = False

                        If RepositoryThumbnail.IsImage = True Then

                            _ThumbnailURL = RepositoryThumbnail.Base64ImageURL

                            If DocumentThumbImage IsNot Nothing AndAlso String.IsNullOrWhiteSpace(_ThumbnailURL) = False Then

                                DocumentThumbImage.Visible = True
                                DocumentThumbImage.ImageUrl = _ThumbnailURL

                            End If

                        Else

                            DocumentTypeDiv.Visible = True

                            Dim DocumentTypeLabel As Label = ListItem.FindControl("LabelDocumentType")
                            Dim DocIcon As New AdvantageFramework.DocumentManager.Classes.DocumentIcon(RepositoryThumbnail.MimeType, RepositoryThumbnail.Filename)

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DocumentTypeDiv, DocIcon.WebDivButtonCssClass)
                            DocumentTypeLabel.Text = DocIcon.Abbreviation
                            DocumentTypeLabel.ToolTip = DocIcon.Description
                            DocumentTypeLabel.CssClass = DocIcon.WebLinkButtonCssClass

                        End If

                        Dim AssetFilenameLiteral As Literal = ListItem.FindControl("LiteralAssetFilename")

                        If String.IsNullOrWhiteSpace(RepositoryThumbnail.Filename) = False Then

                            AssetFilenameLiteral.Text = RepositoryThumbnail.Filename

                        End If

                    End If

                End If

        End Select

    End Sub
    Private Sub RadToolbarReviewAddAsset_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarReviewAddAsset.ButtonClick

        Select Case e.Item.Value
            Case "Upload"

                Me.UploadAssets(True)

        End Select

    End Sub


#End Region
#Region " Page "

    Private Sub Alert_DigitalAssetReview_AddAsset_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

        'If cApplication.IsProofingToolActive(Me.SecuritySession) = False Then

        '    Me.ShowMessage("Advantage Proofing not enabled")
        '    Me.CloseThisWindow()

        'End If

        If Me.CurrentQuerystring.AlertID > 0 Then Me.AlertID = Me.CurrentQuerystring.AlertID
        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.ConceptShareProjectID > 0 Then Me.ConceptShareProjectID = Me.CurrentQuerystring.ConceptShareProjectID
        If Me.CurrentQuerystring.ConceptShareReviewID > 0 Then Me.ConceptShareReviewID = Me.CurrentQuerystring.ConceptShareReviewID

    End Sub
    Private Sub Alert_DigitalAssetReview_AddAsset_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Dim m As New DocumentRepository("", True)
            If m.SetRadAsyncUpload(Me.RadUploadAssets, False, Me.LabelFileSizeLimitMessage.Text) = False Then

                Me.ShowMessage(Me.LabelFileSizeLimitMessage.Text)
                Me.LabelFileSizeLimitMessage.CssClass = "warning"

            End If

            Dim Assets As Generic.List(Of AdvantageFramework.ConceptShareAPI.Asset)
            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            If ConceptShareConnection IsNot Nothing Then

                Assets = AdvantageFramework.ConceptShare.LoadReviewAssets(ConceptShareConnection, Me.ConceptShareReviewID)

            End If
            If Assets IsNot Nothing AndAlso Assets.Count > 0 Then

                Me.PageTitle = "Upload asset revision"

            End If

            Me.RadioButtonListUploadType.SelectedIndex = 0
            Me.MultiViewUploadType.ActiveViewIndex = 0

        End If

    End Sub

#End Region

    Private Sub SetZipOptions()

        Me.RadNumericTextBoxZipOptionsCaptureDelay.Enabled = Me.CheckBoxProcessZip.Checked
        Me.RadNumericTextBoxZipOptionsDuration.Enabled = Me.CheckBoxProcessZip.Checked
        Me.RadNumericTextBoxZipOptionsHeight.Enabled = Me.CheckBoxProcessZip.Checked
        Me.RadNumericTextBoxZipOptionsWidth.Enabled = Me.CheckBoxProcessZip.Checked

    End Sub
    Private Sub SetZipUploadParameters(ByRef UploadParameters As Generic.List(Of AdvantageFramework.ConceptShareAPI.AssetUploadParameter))

        Dim UploadParameter As AdvantageFramework.ConceptShareAPI.AssetUploadParameter

        UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
        UploadParameter.Key = "HTML5_PROCESS_AS_VIDEO"
        UploadParameter.Value = True
        UploadParameters.Add(UploadParameter)

        Dim CaptureDelay As Integer = 0
        Dim Width As Integer = 0
        Dim Height As Integer = 0
        Dim Duration As Integer = 0

        Try

            If Me.RadNumericTextBoxZipOptionsCaptureDelay.Value IsNot Nothing Then

                CaptureDelay = CType(Me.RadNumericTextBoxZipOptionsCaptureDelay.Value, Integer)

            End If

        Catch ex As Exception
            CaptureDelay = 0
        End Try
        Try

            If Me.RadNumericTextBoxZipOptionsWidth.Value IsNot Nothing Then

                Width = CType(Me.RadNumericTextBoxZipOptionsWidth.Value, Integer)

            End If

        Catch ex As Exception
            Width = 0
        End Try
        Try

            If Me.RadNumericTextBoxZipOptionsHeight.Value IsNot Nothing Then

                Height = CType(Me.RadNumericTextBoxZipOptionsHeight.Value, Integer)

            End If

        Catch ex As Exception
            Height = 0
        End Try
        Try

            If Me.RadNumericTextBoxZipOptionsDuration.Value IsNot Nothing Then

                Duration = CType(Me.RadNumericTextBoxZipOptionsDuration.Value, Integer)

            End If

        Catch ex As Exception
            Duration = 0
        End Try

        If CaptureDelay > 0 Then

            UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
            UploadParameter.Key = "HTML5_CAPTURE_DELAY"
            UploadParameter.Value = CaptureDelay
            UploadParameters.Add(UploadParameter)

        End If
        If Width > 0 Then

            UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
            UploadParameter.Key = "HTML5_WIDTH"
            UploadParameter.Value = Width
            UploadParameters.Add(UploadParameter)

        End If
        If Height > 0 Then

            UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
            UploadParameter.Key = "HTML5_HEIGHT"
            UploadParameter.Value = Height
            UploadParameters.Add(UploadParameter)

        End If
        If Duration > 0 Then

            UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
            UploadParameter.Key = "HTML5_CAPTURE_DURATION"
            UploadParameter.Value = Duration
            UploadParameters.Add(UploadParameter)

        End If

    End Sub

    Private Sub UploadAssets(ByVal ShowNoFileMessage As Boolean)

        Select Case Me.RadioButtonListUploadType.SelectedItem.Value
            Case "File"

                Me.UploadFileAssets(ShowNoFileMessage)

            Case "DocumentRepository"

                Me.UploadAssetFromRepository(ShowNoFileMessage)

            Case "CaptureWebPage"

                Me.CaptureWebPageAsAsset(ShowNoFileMessage)

        End Select

    End Sub
    Private Sub UploadFileAssets(ByVal ShowNoFileMessage As Boolean)

        If Me.RadUploadAssets.UploadedFiles.Count > 0 Then

            Dim s As String = String.Empty
            Dim RevisionUploaded As Boolean = False
            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            If ConceptShareConnection IsNot Nothing Then

                Dim Review As AdvantageFramework.ConceptShareAPI.Review

                Review = Nothing
                Review = AdvantageFramework.ConceptShare.LoadReviewByReviewID(ConceptShareConnection, Me.ConceptShareReviewID, s)

                'TODO: Clean up base asset stuff because it was refactored to: LoadReviewBaseAsset
                If Review IsNot Nothing Then

                    Dim Successes As Integer = 0
                    Dim Fails As Integer = 0

                    Dim Asset As AdvantageFramework.ConceptShareAPI.Asset

                    Dim FileLength As Integer = 0
                    Dim UploadParameters As Generic.List(Of AdvantageFramework.ConceptShareAPI.AssetUploadParameter)
                    Dim UploadParameter As AdvantageFramework.ConceptShareAPI.AssetUploadParameter

                    Dim BaseAsset As AdvantageFramework.ConceptShareAPI.Asset

                    BaseAsset = Nothing
                    BaseAsset = AdvantageFramework.ConceptShare.LoadReviewBaseAsset(ConceptShareConnection, Me.ConceptShareReviewID)

                    If BaseAsset IsNot Nothing Then

                        Me.BaseFilename = BaseAsset.FileName

                    End If

                    UploadParameters = New Generic.List(Of AdvantageFramework.ConceptShareAPI.AssetUploadParameter)

                    ''''Dim currentWindowsIdentity1 As System.Security.Principal.WindowsIdentity
                    ''''Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext

                    ''''If IsNTAuth = True Then

                    ''''    Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                    ''''    impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                    ''''End If

                    ''''Dim documentRepository As New DocumentRepository(_Session.ConnectionString, True)

                    ''''If IsNTAuth = True Then

                    ''''    impersonationContext1.Undo()

                    ''''End If

                    ''''Dim MimeType As String = String.Empty
                    ''''Dim DocumentManagerFilename As String = String.Empty
                    ''''Dim ThisFinalLevel As String = "Job,Job Component"
                    ''''Dim ThisFinalLevelDescript As String = ThisFinalLevel & String.Format(":{0}{1}", Me.JobNumber, Me.JobComponentNumber)
                    ''''Dim DocumentID As Integer = 0

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim IsZip As Boolean = False
                        Dim LastAssetID As Integer = 0

                        For Each File As UploadedFile In Me.RadUploadAssets.UploadedFiles

                            If DocumentRepository.RadAsyncUploadFileTypeIsValid(File) = False Then

                                Me.ShowMessage("Invalid file type.")
                                Exit Sub

                            End If

                            IsZip = False
                            Asset = Nothing
                            FileLength = File.InputStream.Length
                            LastAssetID = 0
                            ''''MimeType = String.Empty
                            ''''DocumentManagerFilename = String.Empty
                            ''''DocumentID = 0

                            If FileLength > 0 Then

                                If Me.CheckBoxProcessZip.Checked = True AndAlso File.FileName.ToLower.EndsWith("zip") = True Then

                                    IsZip = True

                                End If

                                Dim FileBytes(FileLength - 1) As Byte
                                File.InputStream.Read(FileBytes, 0, FileLength)

                                ''''If Not File.ContentType Is Nothing Then

                                ''''    MimeType = File.ContentType

                                ''''End If
                                If BaseAsset Is Nothing Then

                                    If IsZip = True Then

                                        Me.SetZipUploadParameters(UploadParameters)

                                    End If

                                    Asset = AdvantageFramework.ConceptShare.UploadAsset(ConceptShareConnection, File.FileName, File.FileName, Nothing,
                                                                                            Me.ConceptShareProjectID, FileBytes, False, UploadParameters.ToArray)

                                    If Asset IsNot Nothing Then

                                        Dim ReviewItem As AdvantageFramework.ConceptShareAPI.ReviewItem
                                        ReviewItem = AdvantageFramework.ConceptShare.AddReviewItem(ConceptShareConnection, Me.ConceptShareReviewID, Asset.Id)

                                        If ReviewItem IsNot Nothing Then

                                            Successes += 1
                                            Me._CustomSubject = String.Format("Asset file added:  {0} to review: ", File.FileName)

                                        End If

                                    End If

                                Else 'uploading revision

                                    LastAssetID = AdvantageFramework.ConceptShare.GetLastAssetID(ConceptShareConnection, Me.ConceptShareReviewID)

                                    If LastAssetID = 0 Then

                                        LastAssetID = BaseAsset.Id

                                    End If

                                    If LastAssetID > 0 Then

                                        Dim JustFileName As String = String.Empty
                                        Dim JustBaseName As String = String.Empty

                                        JustFileName = File.FileName.Substring(0, File.FileName.LastIndexOf(".")).ToUpper
                                        JustBaseName = BaseFilename.Substring(0, BaseFilename.LastIndexOf(".")).ToUpper

                                        If IsZip = True Then

                                            Me.SetZipUploadParameters(UploadParameters)

                                        End If

                                        Asset = AdvantageFramework.ConceptShare.UploadAssetVersion(ConceptShareConnection, LastAssetID, File.FileName, File.FileName,
                                                                                                   FileBytes, False, UploadParameters.ToArray)

                                        If Asset IsNot Nothing Then

                                            Successes += 1
                                            RevisionUploaded = True
                                            Me._CustomSubject = String.Format("Asset file version added:  {0} to review: ", File.FileName)

                                        End If

                                    End If

                                End If

                                'If Asset IsNot Nothing Then

                                '    Me.SaveAssetThumbnailToAlert(DbContext, ConceptShareConnection, Asset.Id)

                                'End If

                                ''''If Me.CheckBoxUploadToDocumentManager.Checked = True Then

                                ''''    Dim OkayToUpload As Boolean = True

                                ''''    If documentRepository.IsRepositoryLimitFeatureEnabled = True Then

                                ''''        Dim ThisFC As New DocumentRepository.FileCompare
                                ''''        ThisFC.FileByteLength = CType(FileLength, Long)

                                ''''        If documentRepository.IsOverFileSizeLimit(ThisFC) = True Then

                                ''''            OkayToUpload = False
                                ''''            Me.ShowMessage(ThisFC.ReturnMessageJS)

                                ''''        End If

                                ''''    End If

                                ''''    If OkayToUpload = True Then

                                ''''        Try
                                ''''            'This line uses impersonation:
                                ''''            DocumentManagerFilename = documentRepository.AddDocument(File.FileName, FileBytes, "Review Asset",
                                ''''                                                                     "", Session("EmployeeName"), ThisFinalLevel, ThisFinalLevelDescript, "d_")
                                ''''        Catch ex As Exception
                                ''''            OkayToUpload = False
                                ''''        End Try

                                ''''    End If
                                ''''    If IsNTAuth = True Then

                                ''''        Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                ''''        impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                                ''''    End If
                                ''''    If OkayToUpload = True Then

                                ''''        Dim newDocument As New JobComponentDocuments(_Session.ConnectionString)
                                ''''        DocumentID = newDocument.Add(Me.JobNumber, Me.JobComponentNumber, File.FileName, MimeType,
                                ''''                                     DocumentManagerFilename, FileLength, Session("UserCode"), "Review Asset", "", False, 2)

                                ''''    End If

                                ''''    If IsNTAuth = True Then

                                ''''        impersonationContext1.Undo()

                                ''''    End If

                                ''''End If

                            End If

                        Next

                        If Successes > 0 Then

                            If RevisionUploaded = True Then

                                AdvantageFramework.AlertSystem.ResetWorkflow(DbContext, Me.AlertID)

                            End If

                            SuccessfulUpload()

                        End If

                    End Using

                End If

            End If

        Else

            If ShowNoFileMessage = True Then Me.ShowMessage("No files selected")

        End If

    End Sub
    Private Sub CaptureWebPageAsAsset(ByVal ShowNoAddressMessage As Boolean)

        Dim Success As Boolean = False

        If String.IsNullOrWhiteSpace(Me.TextBoxCaptureWebPageWebAddress.Text) = False Then

            Dim s As String = String.Empty

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            If ConceptShareConnection IsNot Nothing Then

                Dim Review As AdvantageFramework.ConceptShareAPI.Review

                Review = Nothing
                Review = AdvantageFramework.ConceptShare.LoadReviewByReviewID(ConceptShareConnection, Me.ConceptShareReviewID, s)

                If Review IsNot Nothing Then

                    Dim URL As String = Me.TextBoxCaptureWebPageWebAddress.Text.Trim
                    Dim Title As String = Me.TextBoxCaptureWebPageTitle.Text.Trim
                    Dim Width As Integer = 0
                    Dim Height As Integer = 0
                    Dim CaptureDelay As Integer = 0
                    Dim MaxWaitDelay As Integer = 0

                    Dim Asset As AdvantageFramework.ConceptShareAPI.Asset
                    Dim ReviewItem As AdvantageFramework.ConceptShareAPI.ReviewItem
                    Dim ExistingAssetID As Integer = 0
                    Dim BaseAsset As AdvantageFramework.ConceptShareAPI.Asset


                    If String.IsNullOrWhiteSpace(Title) = True Then Title = URL

                    If Me.RadNumericTextBoxCaptureWebPageOptionsWidth.Value IsNot Nothing Then

                        Width = Me.RadNumericTextBoxCaptureWebPageOptionsWidth.Value

                    End If
                    If Me.RadNumericTextBoxCaptureWebPageOptionsHeight.Value IsNot Nothing Then

                        Height = Me.RadNumericTextBoxCaptureWebPageOptionsHeight.Value

                    End If
                    If Me.RadNumericTextBoxCaptureWebPageOptionsCaptureDelay.Value IsNot Nothing Then

                        CaptureDelay = Me.RadNumericTextBoxCaptureWebPageOptionsCaptureDelay.Value

                    End If

                    BaseAsset = Nothing
                    BaseAsset = AdvantageFramework.ConceptShare.LoadReviewBaseAsset(ConceptShareConnection, Me.ConceptShareReviewID)

                    If BaseAsset IsNot Nothing Then

                        ExistingAssetID = BaseAsset.Id

                    End If

                    Asset = AdvantageFramework.ConceptShare.CaptureWebPageAsAsset(ConceptShareConnection, Me.ConceptShareProjectID, ExistingAssetID, URL, Title,
                                                                                          Width, Height, CaptureDelay, MaxWaitDelay)
                    If Asset IsNot Nothing Then

                        ReviewItem = AdvantageFramework.ConceptShare.AddReviewItem(ConceptShareConnection, Me.ConceptShareReviewID, Asset.Id)

                        If ReviewItem IsNot Nothing Then

                            'Me.ShowMessage("Success")
                            Success = True
                            Me._CustomSubject = String.Format("Asset URL added:  {0} to review: ", URL)

                        End If

                    End If

                End If

            End If

        Else

            If ShowNoAddressMessage = True Then Me.ShowMessage("Please enter a web site address")

        End If

        If Success = True Then

            SuccessfulUpload()

        End If

    End Sub
    Private Sub UploadAssetFromRepository(ByVal ShowNoAddressMessage As Boolean)

        For Each Item As RadListViewDataItem In Me.RadListViewDocRepositoryThumbs.Items

            Dim DocumentID As Integer = Item.GetDataKeyValue("DocumentID")
            Dim SelectRadioButton As RadioButton

            SelectRadioButton = Item.FindControl("RadioButtonSelect")

            If DocumentID > 0 AndAlso SelectRadioButton IsNot Nothing AndAlso SelectRadioButton.Checked = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim Document As AdvantageFramework.Database.Entities.Document

                    Document = Nothing
                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                    If Document IsNot Nothing Then

                        Dim DocumentRepository As New DocumentRepository()
                        Dim ImageBytes As Byte()

                        ImageBytes = DocumentRepository.GetDocument(Document.FileSystemFileName)

                        If ImageBytes IsNot Nothing AndAlso ImageBytes.Length > 0 Then

                            Dim s As String = String.Empty
                            ''''Dim UploadedToRepository As Boolean = False

                            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                            ConceptShareConnection = Nothing
                            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                            If ConceptShareConnection IsNot Nothing Then

                                Dim Review As AdvantageFramework.ConceptShareAPI.Review

                                Review = Nothing
                                Review = AdvantageFramework.ConceptShare.LoadReviewByReviewID(ConceptShareConnection, Me.ConceptShareReviewID, s)

                                'TODO: Clean up base asset stuff because it was refactored to: LoadReviewBaseAsset
                                If Review IsNot Nothing Then

                                    Dim Successes As Integer = 0
                                    Dim Fails As Integer = 0

                                    Dim Asset As AdvantageFramework.ConceptShareAPI.Asset

                                    Dim FileLength As Integer = 0
                                    Dim UploadParameters As Generic.List(Of AdvantageFramework.ConceptShareAPI.AssetUploadParameter)
                                    Dim UploadParameter As AdvantageFramework.ConceptShareAPI.AssetUploadParameter

                                    Dim BaseAsset As AdvantageFramework.ConceptShareAPI.Asset

                                    BaseAsset = Nothing
                                    BaseAsset = AdvantageFramework.ConceptShare.LoadReviewBaseAsset(ConceptShareConnection, Me.ConceptShareReviewID)

                                    If BaseAsset IsNot Nothing Then

                                        Me.BaseFilename = BaseAsset.FileName

                                    End If

                                    UploadParameters = New Generic.List(Of AdvantageFramework.ConceptShareAPI.AssetUploadParameter)

                                    Asset = Nothing
                                    FileLength = ImageBytes.Length

                                    If FileLength > 0 Then

                                        If BaseAsset Is Nothing Then

                                            Asset = AdvantageFramework.ConceptShare.UploadAsset(ConceptShareConnection, Document.FileName, Document.FileName, Nothing,
                                                                                                Me.ConceptShareProjectID, ImageBytes, False, UploadParameters.ToArray)

                                            If Asset IsNot Nothing Then

                                                Dim ReviewItem As AdvantageFramework.ConceptShareAPI.ReviewItem
                                                ReviewItem = AdvantageFramework.ConceptShare.AddReviewItem(ConceptShareConnection, Me.ConceptShareReviewID, Asset.Id)

                                                If ReviewItem IsNot Nothing Then

                                                    Successes += 1
                                                    Me._CustomSubject = String.Format("Asset file added:  {0} to review: ", Document.FileName)

                                                End If

                                            End If

                                        Else 'uploading revision

                                            Dim JustFileName As String = String.Empty
                                            Dim JustBaseName As String = String.Empty

                                            JustFileName = Document.FileName.Substring(0, Document.FileName.LastIndexOf(".")).ToUpper
                                            JustBaseName = BaseFilename.Substring(0, BaseFilename.LastIndexOf(".")).ToUpper

                                            Asset = AdvantageFramework.ConceptShare.UploadAssetVersion(ConceptShareConnection, BaseAsset.Id, Document.FileName, Document.FileName,
                                                                                               ImageBytes, False, UploadParameters.ToArray)

                                            If Asset IsNot Nothing Then

                                                Successes += 1
                                                Me._CustomSubject = String.Format("Asset file version added:  {0} to review: ", Document.FileName)

                                            End If

                                        End If

                                    End If

                                    If Successes > 0 Then

                                        SuccessfulUpload()

                                    End If

                                End If

                            End If


                        End If

                    End If

                End Using

            End If

        Next

    End Sub
    Private Sub SuccessfulUpload()
        Dim qs As New AdvantageFramework.Web.QueryString

        qs.Page = "Alert_DigitalAssetReview.aspx"
        qs.JobNumber = Me.JobNumber
        qs.JobComponentNumber = Me.JobComponentNumber
        qs.ConceptShareProjectID = Me.ConceptShareProjectID
        qs.ConceptShareReviewID = Me.ConceptShareReviewID

        Dim a As New cAlerts()
        Dim RefreshedMe As Boolean = False
        Dim SentEmail As Boolean = False
        Dim Subject As String = String.Empty
        Dim Comment As String = String.Empty

        a.UpdateAllReviewRecipients(Me._Session, Me.AlertID, 67, True, RefreshedMe, SentEmail, Me._CustomSubject, Comment, False)

        If RefreshedMe = True Then

            Me.RefreshAlertWindows(False)

        End If
        If SentEmail = True Then

            Me.CheckForAsyncMessage()

        End If

        Me.ShowMessage("Asset successfully uploaded.  It may take a few seconds for the thumbnail to generate.  Try clicking the refresh button if you do not see your upload.")
        Me.CloseThisWindowAndRefreshCaller(qs.ToString(True), True, True)

    End Sub

    Private Function SaveAssetThumbnailToAlert(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                               ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                               ByVal AssetID As Integer) As Boolean

        Dim ThumbnailUpdated As Boolean = False

        If DbContext IsNot Nothing AndAlso ConceptShareConnection IsNot Nothing AndAlso AssetID > 0 Then

            Dim Alert As AdvantageFramework.Database.Entities.Alert
            Alert = Nothing

            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertID)

            If Alert IsNot Nothing Then

                Dim Thumbnail As Byte()
                Thumbnail = ConceptShareConnection.APIServiceClient.DownloadAssetImage(ConceptShareConnection.APIContext, AssetID,
                                                                                   AdvantageFramework.ConceptShare.ThumbnailWidth, AdvantageFramework.ConceptShare.ThumbnailHeight)

                If Thumbnail IsNot Nothing AndAlso Thumbnail.Length > 0 Then

                    Alert.ConceptShareAssetImage = Thumbnail

                    ThumbnailUpdated = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                End If

            End If

        End If

    End Function

#End Region

End Class
