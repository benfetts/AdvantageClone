Imports System.IO
Imports Telerik.Web.UI

Public Class Alert_DigitalAssetReview
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Private Const BaseEmailSubject As String = "[Review Request]"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _AssetCount As Integer = 0
    Private _ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
    'Private Property CommentList As Generic.List(Of AdvantageFramework.Database.Entities.AlertComment)
    '    Get
    '        If HttpContext.Current.
    '    End Get
    '    Set(value As Generic.List(Of AdvantageFramework.Database.Entities.AlertComment))

    '    End Set
    'End Property
    Private _ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary
    Private _GridHasReplies As Boolean = False
    Protected WithEvents LabelApproved As Global.System.Web.UI.WebControls.Label
    Protected WithEvents LabelDismissed As Global.System.Web.UI.WebControls.Label
    Protected WithEvents LabelCompleted As Global.System.Web.UI.WebControls.Label

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
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
    Private Property BaseReviewType As AdvantageFramework.Database.Entities.ConceptShareBaseReviewType
        Get
            If ViewState("BaseReviewType") Is Nothing Then
                Return AdvantageFramework.Database.Entities.ConceptShareBaseReviewType.Collaborative
            Else
                Return CType(CType(ViewState("BaseReviewType"), Integer), AdvantageFramework.Database.Entities.ConceptShareBaseReviewType)
            End If
        End Get
        Set(value As AdvantageFramework.Database.Entities.ConceptShareBaseReviewType)
            ViewState("BaseReviewType") = CType(value, Integer)
        End Set
    End Property
    Private Property Completed As Boolean
        Get
            If ViewState("Completed") Is Nothing Then
                Return False
            Else
                Return CType(ViewState("Completed"), Boolean)
            End If
        End Get
        Set(value As Boolean)
            ViewState("Completed") = value
        End Set
    End Property
    Private Property CompletedDate As DateTime?
        Get
            If ViewState("CompletedDate") IsNot Nothing Then

                Return CType(ViewState("CompletedDate"), DateTime)

            Else

                Return Nothing

            End If
        End Get
        Set(value As DateTime?)

            ViewState("CompletedDate") = value

        End Set
    End Property
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
    Private ReadOnly Property EmployeeCode As String
        Get
            Return HttpContext.Current.Session("EmpCode")
        End Get
    End Property
    Private Property LastAssetID As Integer
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
    Private Property CommentCount As Integer
        Get
            If ViewState("CommentCount") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("CommentCount"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("CommentCount") = value
        End Set
    End Property
    Private ReadOnly Property EmployeeTimezoneOffset As Decimal
        Get
            Return cEmployee.GetTimeZoneOffset(True)
        End Get
    End Property
    Private Property SelectedAssetID As Integer
        Get
            If ViewState("SelectedAssetID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("SelectedAssetID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("SelectedAssetID") = value
        End Set
    End Property
    Private Property CurrentReviewIsReviewMember As Integer
        Get
            If ViewState("CurrentReviewIsReviewMember") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("CurrentReviewIsReviewMember"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("CurrentReviewIsReviewMember") = value
        End Set
    End Property
    Private Property AssetHasVersions As Boolean
        Get
            If ViewState("AssetHasRevisions") Is Nothing Then
                Return False
            Else
                Return CType(ViewState("AssetHasRevisions"), Boolean)
            End If
        End Get
        Set(value As Boolean)
            ViewState("AssetHasRevisions") = value
        End Set
    End Property
    Private Property IsDismissed As Boolean
        Get
            If ViewState("IsDismissed") Is Nothing Then
                Return False
            Else
                Return CType(ViewState("IsDismissed"), Boolean)
            End If
        End Get
        Set(value As Boolean)
            ViewState("IsDismissed") = value
        End Set
    End Property
    Private Property JobInformation As AdvantageFramework.ConceptShare.Classes.JobInfo
        Get
            If ViewState("JobInformation") Is Nothing Then
                Return Nothing
            Else
                Return CType(ViewState("JobInformation"), AdvantageFramework.ConceptShare.Classes.JobInfo)
            End If
        End Get
        Set(value As AdvantageFramework.ConceptShare.Classes.JobInfo)
            ViewState("JobInformation") = value
        End Set
    End Property
    Public Property ProofingToolWebvantageLink As String
        Get
            If ViewState("ProofingToolWebvantageLink") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("ProofingToolWebvantageLink")
            End If
        End Get
        Set(value As String)
            ViewState("ProofingToolWebvantageLink") = value
        End Set
    End Property
    Public Property ProofingToolClientPortalLink As String
        Get
            If ViewState("ProofingToolClientPortalLink") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("ProofingToolClientPortalLink")
            End If
        End Get
        Set(value As String)
            ViewState("ProofingToolClientPortalLink") = value
        End Set
    End Property
    'Private ReadOnly Property SyncReadStatus As Boolean
    '    Get
    '        Try
    '            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.GetValue("SyncReadStatus")) = False Then
    '                Return Me.CurrentQuerystring.GetValue("SyncReadStatus") = "1"
    '            Else
    '                Return True
    '            End If
    '        Catch ex As Exception
    '            Return True
    '        End Try
    '    End Get
    'End Property
    Private Property ExternalReviewers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ExternalReviewer)
    Private Property AlertTemplateStateEmployees As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee) = Nothing
    Private Property IsRouted As Boolean
        Get
            Dim Routed As RadToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Routed")
            If Routed IsNot Nothing Then
                Return Routed.Checked
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            Dim Routed As RadToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Routed")
            If Routed IsNot Nothing Then
                Routed.Checked = value
            End If
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ButtonSaveExternalReviewers_Click(sender As Object, e As EventArgs) Handles ButtonSaveExternalReviewers.Click

        Me.CheckForExternalUsers(False)

    End Sub

    Private Sub ButtonAddReviewer_Click(sender As Object, e As EventArgs) Handles ButtonAddReviewer.Click

        If Me.AddUpdateReview(True) = True Then

            Me.AutoCompleteAlertRecipientReviewers.Clear()
            Me.LoadReview(False)
            Me.LoadReviewers(True, False)

        End If

    End Sub
    Private Sub ButtonSelectReviewer_Click(sender As Object, e As EventArgs) Handles ButtonSelectReviewer.Click

        If Me.AlertID = 0 OrElse Me.ConceptShareReviewID = 0 Then

            If Me.AddUpdateReview(False) = True Then

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_DigitalAssetReview.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNumber
                qs.ConceptShareProjectID = Me.ConceptShareProjectID
                qs.ConceptShareReviewID = Me.ConceptShareReviewID
                qs.Add("opensel", "1")
                MiscFN.ResponseRedirect(qs.ToString(True), True)

            End If

        Else

            Me.OpenSelectWindow(False)

        End If

    End Sub
    Private Sub ButtonReorderReviewers_Click(sender As Object, e As EventArgs) Handles ButtonReorderReviewers.Click

        If Me.AlertID = 0 OrElse Me.ConceptShareReviewID = 0 Then

            If Me.AddUpdateReview(False) = True Then

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_DigitalAssetReview.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNumber
                qs.ConceptShareProjectID = Me.ConceptShareProjectID
                qs.ConceptShareReviewID = Me.ConceptShareReviewID
                qs.Add("opensel", "0")
                MiscFN.ResponseRedirect(qs.ToString(True), True)

            End If

        Else

            Me.OpenSelectWindow(True)

        End If
    End Sub
    Private Sub OpenSelectWindow(ByVal ForReorder As Boolean)

        Dim qs As New AdvantageFramework.Web.QueryString

        qs.Page = "Alert_DigitalAssetReview_AddReviewer.aspx"
        qs.AlertID = Me.AlertID
        qs.ConceptShareReviewID = Me.ConceptShareReviewID
        qs.JobNumber = Me.JobNumber
        qs.JobComponentNumber = Me.JobComponentNumber
        qs.ConceptShareProjectID = Me.ConceptShareProjectID
        If ForReorder = True Then

            qs.Add("loie", "1")

        Else

            qs.Add("loie", "0")

        End If

        Me.OpenWindow("Add Internal Reviewer", qs.ToString(True))

    End Sub
    Private Sub CheckBoxExpandAllComments_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxExpandAllComments.CheckedChanged

        Me.RadGridReviewComments.Rebind()

    End Sub
    Private Sub Refresh()

        Me.LoadReview(True)
        Me.RadListViewAssets.Rebind()
        Me.RadGridReviewComments.Rebind()
        Me.LoadReviewers(True, True)
        Me.SelectAsset()

    End Sub
    Private Sub RadToolbarAlertDigitalAssetReview_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarAlertDigitalAssetReview.ButtonClick

        Dim s As String = String.Empty

        Select Case e.Item.Value
            Case "Routed"

                Me.SetAssigneePanel(True)

            Case "ClearActiveFlag"

                Try

                    If Me.AlertID > 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT_RCPT SET CURRENT_NOTIFY = NULL WHERE ALERT_ID = {0}; UPDATE ALERT_RCPT_DISMISSED SET CURRENT_NOTIFY = NULL WHERE ALERT_ID = {0}; UPDATE CP_ALERT_RCPT SET IS_DELETED = NULL WHERE ALERT_ID = {0}; UPDATE CP_ALERT_RCPT_DISMISSED SET IS_DELETED = NULL WHERE ALERT_ID = {0}; UPDATE CS_EXT_REVIEWER SET LAST_EMAILED = NULL WHERE ALERT_ID = {0};", Me.AlertID))
                            Me.LoadReviewers(True, True)
                            Me.RefreshDashboardReviews()

                        End Using

                    End If

                Catch ex As Exception
                    Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString))
                End Try

            Case "Refresh"

                Me.Refresh()

            Case "AlertRecipients"

            Case "EmailExternalReviewers"

            Case "ProofingTool"

                Me.OpenProofingTool()

            Case "Save"

                Me.AddUpdateReview(True)

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me._Session.ConnectionString, Me._Session.UserCode)
                Dim qs As New AdvantageFramework.Web.QueryString()
                Dim Subject As String = Me.TextBoxReviewName.Text.Trim()

                If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
                If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

                qs = qs.FromCurrent()

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ConceptShare_Review
                    .UserCode = Me._Session.UserCode
                    .Name = String.Format("{0}/{1} - Review: {2}", Me.JobNumber.ToString.PadLeft(6, "0"), Me.JobComponentNumber.ToString.PadLeft(2, "0"), Subject)
                    .PageURL = "Alert_DigitalAssetReview.aspx" & qs.ToString()
                    .Description = Subject

                End With

                If BmMethods.SaveBookmark(b, s) = False Then

                    If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

            Case "AddTime"

                If Me.JobNumber > 0 And Me.JobComponentNumber > 0 Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    With qs

                        .Page = "Employee/Timesheet/Entry"
                        .EmployeeCode = Session("EmpCode")
                        .AlertID = Me.AlertID
                        .JobNumber = Me.JobNumber
                        .JobComponentNumber = Me.JobComponentNumber

                    End With

                    Me.OpenWindow("Add Time", qs.ToString(True), 600, 600)

                End If

            Case "StartStopwatch"

                If Me.JobNumber > 0 And Me.JobComponentNumber > 0 Then

                    If AdvantageFramework.Timesheet.Methods.StopwatchStart(Me._Session.ConnectionString, Me._Session.UserCode, Me.EmployeeCode, Me.JobNumber, Me.JobComponentNumber, -1, Me.AlertID, s) = True Then

                        Me.CheckForStopwatch()

                    Else

                        Me.ShowMessage(s)

                    End If

                End If

            Case "UploadAddAsset"

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_DigitalAssetReview_AddAsset.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNumber
                qs.ConceptShareProjectID = Me.ConceptShareProjectID
                qs.ConceptShareReviewID = Me.ConceptShareReviewID
                qs.AlertID = Me.AlertID

                Me.OpenWindow(qs, "Upload asset revision")

            Case "FeedbackSummary"

                Me.ShowMessage("This might take a few seconds.")
                Me.ReviewGenerateFeedbackSummary(Me.ConceptShareProjectID, Me.ConceptShareReviewID)
                'If Me.ConceptShareReviewID > 0 Then

                '    Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                '    Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                '    ConceptShareConnection = Nothing
                '    ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                '    If ConceptShareConnection IsNot Nothing Then

                '        Dim PdfBytes As Byte()

                '        PdfBytes = AdvantageFramework.ConceptShare.GenerateReviewFeedbackSummary(ConceptShareConnection, Me.ConceptShareProjectID, Me.ConceptShareReviewID)

                '        If PdfBytes IsNot Nothing Then

                '            'Dim FilePrefix As String = Request.PhysicalApplicationPath.Trim() & "TEMP\"
                '            'Dim Filename As String = String.Format("{0}FeedbackSummary{1}.pdf", FilePrefix, AdvantageFramework.StringUtilities.GUID_Date())
                '            'Dim SummaryFileStream As New FileStream(Filename, FileMode.OpenOrCreate, FileAccess.Write)

                '            'SummaryFileStream.Write(PdfBytes, 0, PdfBytes.Length)
                '            'SummaryFileStream.Close()
                '            'SummaryFileStream.Dispose()

                '            Dim Filename As String = String.Format("Feedback_Summary_{0}_{1}.pdf", MiscFN.JavascriptSafe(Me.TextBoxReviewName.Text.Replace(" ", "_")), AdvantageFramework.StringUtilities.GUID_Date())

                '            With HttpContext.Current.Response

                '                Try

                '                    .Buffer = True
                '                    .AddHeader("Content-Disposition", "attachment;filename=""" & Filename & """")
                '                    .AddHeader("Content-Length", PdfBytes.Length)
                '                    .ContentType = "application/pdf"
                '                    .BinaryWrite(PdfBytes)
                '                    .End()
                '                    .Flush()
                '                    .Clear()

                '                Catch ex As Exception
                '                    .End()
                '                    .Clear()
                '                End Try

                '            End With

                '        End If

                '    End If

                'End If
            Case "Dismiss"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.IsDismissed = False OrElse Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Dismiss").Text.ToLower() = "dismiss" Then

                        Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

                        Recipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, Me.AlertID, Me.EmployeeCode)

                        If Recipient IsNot Nothing AndAlso Recipient.IsCurrentNotify IsNot Nothing AndAlso Recipient.IsCurrentNotify = 1 Then

                            Recipient.IsCurrentNotify = Nothing
                            AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, Recipient)

                        End If

                        If AdvantageFramework.AlertSystem.DismissAlert(DbContext, Me.AlertID, Me.EmployeeCode,
                                                                       HttpContext.Current.Session("UserCode"),
                                                                       HttpContext.Current.Session("UserID"), False,
                                                                       False, False, s) = True Then

                            Me.RefreshAlertWindows()

                        Else

                            If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                        End If

                    Else

                        Dim a As New cAlerts()
                        s = a.UnDismissAlert(Me.AlertID, Me.IsClientPortal, HttpContext.Current.Session("UserID"))

                        If String.IsNullOrWhiteSpace(s) = False Then

                            Me.ShowMessage(s)

                        Else

                            Me.LoadReview(False)
                            'Me.RadListViewAssets.Rebind()
                            'Me.RadGridReviewComments.Rebind()
                            Me.LoadReviewers(True, False)
                            Me.RefreshAlertWindows(False)

                        End If

                    End If

                End Using

            Case "JobInformation"

                Dim JobInformationRadToolBarButton As RadToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("JobInformation")
                If JobInformationRadToolBarButton IsNot Nothing Then

                    If JobInformationRadToolBarButton.Checked = True Then

                        If Me.JobInformation Is Nothing Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                Me.JobInformation = AdvantageFramework.ConceptShare.LoadJobInfoByByConceptShareReviewID(DataContext, Me.ConceptShareReviewID)

                            End Using
                            If Me.JobInformation IsNot Nothing Then

                                If String.IsNullOrWhiteSpace(Me.JobInformation.OfficeDisplay) = True Then

                                    Me.DivOffice.Visible = False

                                Else

                                    Me.DivOffice.Visible = True
                                    Me.LabelOffice.Text = Me.JobInformation.OfficeDisplay

                                End If
                                Me.LabelClient.Text = Me.JobInformation.ClientDisplay
                                Me.LabelDivision.Text = Me.JobInformation.DivisionDisplay
                                Me.LabelProduct.Text = Me.JobInformation.ProductDisplay
                                Me.LabelJob.Text = Me.JobInformation.JobDisplay
                                Me.LabelJobComponent.Text = Me.JobInformation.JobComponentDisplay

                                Me.DivJobInfo.Visible = True

                            End If

                        Else

                            Me.DivJobInfo.Visible = True

                        End If

                    Else

                        Me.DivJobInfo.Visible = False

                    End If

                End If

        End Select

    End Sub

    Private Sub RadListViewAssets_ItemCommand(sender As Object, e As RadListViewCommandEventArgs) Handles RadListViewAssets.ItemCommand

        If IsNumeric(e.CommandArgument) = True Then

            Dim AssetID As Integer = CType(e.CommandArgument, Integer)

            If AssetID > 0 Then

                Select Case e.CommandName
                    Case "SelectAsset"

                        Me.SelectedAssetID = AssetID
                        Me.RadGridReviewComments.Rebind()
                        Me.SelectAsset()

                    Case "DownloadAsset"

                        'Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                        'Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                        'ConceptShareConnection = Nothing
                        'ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                        'If ConceptShareConnection IsNot Nothing Then

                        '    Dim Asset As AdvantageFramework.ConceptShareAPI.Asset

                        '    Asset = Nothing
                        '    Asset = AdvantageFramework.ConceptShare.LoadAssetByAssetID(ConceptShareConnection, AssetID)

                        '    If Asset IsNot Nothing Then

                        '        Dim FileBytes() As Byte = AdvantageFramework.ConceptShare.DownloadAsset(ConceptShareConnection, AssetID)

                        '        If FileBytes IsNot Nothing AndAlso FileBytes.Length > 0 Then

                        '            Dim RealFilename As String = Asset.FileName
                        '            Dim MimeType As String = String.Empty

                        '            Try

                        '                MimeType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(Asset.OriginalExtension)

                        '            Catch ex As Exception
                        '                MimeType = String.Empty
                        '            End Try
                        '            With HttpContext.Current.Response

                        '                Try

                        '                    .Buffer = True
                        '                    .AddHeader("Content-Disposition", "attachment;filename=""" & RealFilename & """")
                        '                    .AddHeader("Content-Length", FileBytes.Length)
                        '                    .ContentType = MimeType
                        '                    .BinaryWrite(FileBytes)
                        '                    .End()
                        '                    .Flush()
                        '                    .Clear()

                        '                Catch ex As Exception
                        '                    .End()
                        '                    .Clear()
                        '                End Try

                        '            End With

                        '        End If

                        '    Else

                        '        Me.ShowMessage("Failed to retrieve asset")

                        '    End If

                        'End If

                    Case "RemoveAsset"


                        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                        ConceptShareConnection = Nothing
                        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                        If ConceptShareConnection IsNot Nothing Then

                            If AdvantageFramework.ConceptShare.RemoveAsset(ConceptShareConnection, AssetID) IsNot Nothing Then

                                Me.RadListViewAssets.Rebind()

                            End If

                        End If


                End Select

            End If

        End If

    End Sub
    Private Sub RadListViewAssets_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewAssets.ItemDataBound
        Select Case e.Item.ItemType
            Case RadListViewItemType.AlternatingItem, RadListViewItemType.DataItem

                If Me._ConceptShareConnection Is Nothing Then

                    Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                    If Me.IsClientPortal = False Then

                        Me._ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                    Else

                        Me._ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                    End If

                End If
                If Me._ConceptShareConnection IsNot Nothing Then

                    Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)
                    Dim DataItem = ListItem.DataItem

                    If ListItem IsNot Nothing AndAlso DataItem IsNot Nothing Then

                        Dim Asset As AdvantageFramework.ConceptShareAPI.Asset
                        Asset = DirectCast(DataItem, AdvantageFramework.ConceptShareAPI.Asset)

                        If Asset IsNot Nothing Then

                            Dim AssetImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonAsset")

                            If AssetImageButton IsNot Nothing Then

                                Dim AssetImage As Byte()

                                Try

                                    AssetImage = AdvantageFramework.ConceptShare.DownloadAssetImage(Me._ConceptShareConnection, Asset.Id)

                                Catch ex As Exception
                                    AssetImage = Nothing
                                End Try

                                If AssetImage IsNot Nothing Then

                                    Try

                                        AssetImageButton.ImageUrl = String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(AssetImage))

                                    Catch ex As Exception
                                    End Try

                                Else

                                    AssetImageButton.ImageUrl = "~/Images/blank.ico"

                                End If

                                AssetImageButton.CommandArgument = Asset.Id

                            End If

                            Dim AssetFilenameLiteral As Literal = e.Item.FindControl("LiteralAssetFilename")

                            If AssetFilenameLiteral IsNot Nothing Then

                                AssetFilenameLiteral.Text = Asset.FileName

                            End If

                            Dim RemoveAssetImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonRemoveAsset")

                            If RemoveAssetImageButton IsNot Nothing Then

                                If Me.AssetHasVersions = True Then

                                    RemoveAssetImageButton.Visible = False

                                Else

                                    If Me.IsClientPortal = False Then

                                        RemoveAssetImageButton.Attributes.Add("onclick", "return confirm('Remove asset?');")

                                    Else

                                        RemoveAssetImageButton.Visible = False

                                    End If

                                End If

                            End If

                        End If

                        Dim DownloadAssetImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonDownloadAsset")

                        If DownloadAssetImageButton IsNot Nothing Then

                            If Me.IsClientPortal = True Then

                                DownloadAssetImageButton.Visible = False

                            Else

                                DownloadAssetImageButton.Attributes.Add("onclick", String.Format("dowloadAsset({0});", Asset.Id))

                            End If

                        End If

                    End If

                End If

        End Select
    End Sub
    Private Sub RadListViewAssets_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewAssets.NeedDataSource

        Try

            Dim Assets As Generic.List(Of AdvantageFramework.ConceptShareAPI.Asset)

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Assets = AdvantageFramework.ConceptShare.LoadReviewAssets(ConceptShareConnection, Me.ConceptShareReviewID)

            End If

            'Should not delete asset if it has versions
            'If we change to allow multiple assets on a review, need to change this to count versions for each asset
            'For now, since a Review will only be of one asset, just count number of records here
            If Assets IsNot Nothing AndAlso Assets.Count > 1 Then

                Me.AssetHasVersions = True

            End If

            RadListViewAssets.DataSource = Assets

            If Assets IsNot Nothing AndAlso Assets.Count > 0 Then

                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ProofingTool").Enabled = True
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ZenDeskHelp").Enabled = True

            Else

                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ProofingTool").Enabled = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ZenDeskHelp").Enabled = False

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub SelectAsset()

        Try

            For Each Item As RadListViewDataItem In Me.RadListViewAssets.Items

                Dim AssetContainerDiv As HtmlControls.HtmlControl

                AssetContainerDiv = Nothing
                AssetContainerDiv = Item.FindControl("DivAssetContainer")

                If AssetContainerDiv IsNot Nothing Then

                    AssetContainerDiv.Attributes.Remove("class")

                    If Me.SelectedAssetID > 0 AndAlso Item.GetDataKeyValue("Id") = Me.SelectedAssetID Then

                        AssetContainerDiv.Attributes.Add("class", "asset-container selected-asset-container")

                    Else

                        AssetContainerDiv.Attributes.Add("class", "asset-container")

                    End If

                End If

            Next

        Catch ex As Exception
        End Try
        Try

            If Me.IsPostBack = True OrElse Me.IsCallback = True Then

                If Me.SelectedAssetID > 0 And Me.RadListViewAssets.Items.Count = 1 Then

                    Me.SelectAssetRow()

                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadListViewReviewers_ItemCommand(sender As Object, e As RadListViewCommandEventArgs) Handles RadListViewReviewers.ItemCommand

        Select Case e.CommandName

            Case "EmailReviewer"

                Dim CurrentListViewItem As RadListViewDataItem = e.ListViewItem

                If CurrentListViewItem IsNot Nothing AndAlso Me.AlertID > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        'get employee  code from card (by cs user id)
                        Dim EmployeeCode As String = String.Empty

                        Try

                            EmployeeCode = CurrentListViewItem.GetDataKeyValue("EmployeeCode")

                        Catch ex As Exception
                            EmployeeCode = String.Empty
                        End Try

                        If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO ALERT_RCPT SELECT * FROM ALERT_RCPT_DISMISSED ARD WHERE ARD.ALERT_ID = {0} AND ARD.EMP_CODE = '{1}'; DELETE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';", Me.AlertID, EmployeeCode))
                            'update the alert
                            Dim a As New cAlerts()
                            a.UpdateAlertRecipients(Me.AlertID, EmployeeCode, "", True)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT_RCPT SET CURRENT_NOTIFY = NULL WHERE ALERT_ID = {0};UPDATE ALERT_RCPT_DISMISSED SET CURRENT_NOTIFY = NULL WHERE ALERT_ID = {0};UPDATE ALERT_RCPT SET CURRENT_NOTIFY = 1 WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';", Me.AlertID, EmployeeCode))
                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CP_ALERT_RCPT SET IS_DELETED = NULL WHERE ALERT_ID = {0};UPDATE CP_ALERT_RCPT_DISMISSED SET IS_DELETED = NULL WHERE ALERT_ID = {0};", Me.AlertID, EmployeeCode))

                            'If Me.EmployeeCode = EmployeeCode Then

                            Me.RefreshAlertWindows(False)

                            'End If

                            Try

                                Dim Names As New Generic.List(Of String)
                                Dim Employee As AdvantageFramework.Database.Views.Employee

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                                If Employee IsNot Nothing Then

                                    Names.Add(Employee.FirstName & " " & Employee.LastName)
                                    Me.AddEmailingComment(DbContext, False, Names, False)

                                End If

                            Catch ex As Exception
                            End Try

                            'send one email
                            Dim eso As New EmailSessionObject(Me._Session.ConnectionString,
                                              Me._Session.UserCode,
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

                            With eso

                                .AlertId = Me.AlertID
                                .Subject = BaseEmailSubject
                                .IsClientPortal = False
                                .IncludeOriginator = False
                                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                                .EmployeeCodesToSendEmailTo = EmployeeCode
                                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath

                                .Send()

                            End With

                            Me.CheckForAsyncMessage()

                            Me.LoadReviewers(True, False)

                            If EmployeeCode = Me.EmployeeCode Then

                                Me.CheckReadStatus(DbContext)

                            End If


                        End If

                    End Using

                End If

            Case "RemoveReviewer"

                If String.IsNullOrWhiteSpace(e.CommandArgument) = False AndAlso IsNumeric(e.CommandArgument) Then

                    Dim CurrentListViewItem As RadListViewDataItem = e.ListViewItem

                    If CurrentListViewItem IsNot Nothing Then

                        Dim ConceptShareUserID As Integer = CType(e.CommandArgument, Integer)
                        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                        ConceptShareConnection = Nothing
                        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                        If ConceptShareConnection IsNot Nothing Then

                            If AdvantageFramework.ConceptShare.RemoveReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, ConceptShareUserID) IsNot Nothing Then

                                If Me.AlertID > 0 AndAlso ConceptShareConnection.IsClientPortalUser = False Then

                                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                        Try

                                            If CurrentListViewItem.GetDataKeyValue("IsEmployee") = "1" Then

                                                DataContext.ExecuteCommand(String.Format("DELETE FROM ALERT_RCPT WITH(ROWLOCK) WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';DELETE FROM ALERT_RCPT_DISMISSED WITH(ROWLOCK) WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';",
                                                                                         AlertID, CurrentListViewItem.GetDataKeyValue("EmployeeCode")))

                                                If Me.EmployeeCode = CurrentListViewItem.GetDataKeyValue("EmployeeCode") Then

                                                    Me.RefreshAlertWindows(False)
                                                    Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Dismiss").Visible = False

                                                Else

                                                    ''Webvantage.SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(EmployeeCode, _Session.ConnectionString, _Session.UserCode)

                                                End If

                                            Else

                                                DataContext.ExecuteCommand(String.Format("DELETE FROM CP_ALERT_RCPT WITH(ROWLOCK) WHERE ALERT_ID = {0} AND CDP_CONTACT_ID = {1};DELETE FROM CP_ALERT_RCPT_DISMISSED WITH(ROWLOCK) WHERE ALERT_ID = {0} AND CDP_CONTACT_ID = {1};",
                                                                                         AlertID, CurrentListViewItem.GetDataKeyValue("EmployeeCode")))

                                            End If

                                        Catch ex As Exception
                                        End Try

                                    End Using

                                End If

                                Me.LoadReviewers(True, False)

                                If ConceptShareConnection.ConceptShareUserID = ConceptShareUserID Then

                                    Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ProofingTool").Enabled = False
                                    Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ZenDeskHelp").Enabled = False

                                End If

                            End If

                        End If

                    End If

                End If

        End Select

    End Sub
    Private Sub RadListViewReviewers_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewReviewers.ItemDataBound

        Select Case e.Item.ItemType
            Case RadListViewItemType.AlternatingItem, RadListViewItemType.DataItem

                Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)

                If ListItem IsNot Nothing Then

                    Dim DataItem = ListItem.DataItem
                    Dim EmailImageButton As ImageButton = e.Item.FindControl("ImageButtonEmail")
                    Dim RemoveReviewerImageButton As ImageButton = e.Item.FindControl("ImageButtonRemoveReviewer")
                    Dim CurrentReviewerDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivCurrentReviewer")

                    If RemoveReviewerImageButton IsNot Nothing Then

                        If Me.IsClientPortal = True Then

                            RemoveReviewerImageButton.Visible = False

                        Else

                            RemoveReviewerImageButton.OnClientClick = "return confirm('Remove reviewer?');"

                        End If

                    End If
                    If EmailImageButton IsNot Nothing AndAlso Me.IsClientPortal = True Then

                        EmailImageButton.Visible = False

                    End If
                    If CurrentReviewerDiv IsNot Nothing Then

                        Try

                            CurrentReviewerDiv.Attributes.Remove("class")

                            If CType(ListItem.GetDataKeyValue("IsCurrentReviewer"), Boolean) = True Then

                                CurrentReviewerDiv.Attributes.Add("class", "reviewer-active")

                            Else

                                CurrentReviewerDiv.Attributes.Add("class", "reviewer-inactive")

                            End If

                        Catch ex As Exception
                            CurrentReviewerDiv.Visible = False
                        End Try

                    End If
                    If ListItem.GetDataKeyValue("EmployeeCode") = Me.EmployeeCode Then

                        Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Dismiss").Visible = True

                    End If

                End If

        End Select

    End Sub
    Private Sub RadListViewReviewers_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewReviewers.NeedDataSource

        LoadReviewers(True, True)

    End Sub

    Private Sub RadListViewClientPortalReviewers_ItemCommand(sender As Object, e As RadListViewCommandEventArgs) Handles RadListViewClientPortalReviewers.ItemCommand

        Select Case e.CommandName

            Case "EmailReviewer"

                Dim CurrentListViewItem As RadListViewDataItem = e.ListViewItem

                If CurrentListViewItem IsNot Nothing AndAlso Me.AlertID > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        'get employee  code from card (by cs user id)
                        Dim EmployeeCode As String = String.Empty

                        Try

                            EmployeeCode = CurrentListViewItem.GetDataKeyValue("EmployeeCode")

                        Catch ex As Exception
                            EmployeeCode = String.Empty
                        End Try

                        If String.IsNullOrWhiteSpace(EmployeeCode) = False AndAlso IsNumeric(EmployeeCode) = True Then

                            'DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO ALERT_RCPT SELECT * FROM ALERT_RCPT_DISMISSED ARD WHERE ARD.ALERT_ID = {0} AND ARD.EMP_CODE = '{1}'; DELETE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';", Me.AlertID, EmployeeCode))
                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO CP_ALERT_RCPT SELECT * FROM CP_ALERT_RCPT_DISMISSED ARD WHERE ARD.ALERT_ID = {0} AND ARD.CDP_CONTACT_ID = {1}; DELETE FROM CP_ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0} AND CDP_CONTACT_ID = {1};", Me.AlertID, EmployeeCode))

                            'update the alert
                            Dim a As New cAlerts()
                            a.UpdateAlertRecipientsCP(Me.AlertID, EmployeeCode, "", True)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT_RCPT SET CURRENT_NOTIFY = NULL WHERE ALERT_ID = {0};UPDATE ALERT_RCPT_DISMISSED SET CURRENT_NOTIFY = NULL WHERE ALERT_ID = {0};", Me.AlertID, EmployeeCode))
                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CP_ALERT_RCPT SET IS_DELETED = NULL WHERE ALERT_ID = {0};UPDATE CP_ALERT_RCPT_DISMISSED SET IS_DELETED = NULL WHERE ALERT_ID = {0};UPDATE CP_ALERT_RCPT SET IS_DELETED = 0 WHERE ALERT_ID = {0} AND CDP_CONTACT_ID = {1};", Me.AlertID, EmployeeCode))

                            Dim ClientContactEmailAddress As String = String.Empty

                            Try

                                Dim Names As New Generic.List(Of String)
                                Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact

                                ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, EmployeeCode)

                                If ClientContact IsNot Nothing Then

                                    ClientContactEmailAddress = ClientContact.EmailAddress
                                    Names.Add(ClientContact.FirstName & " " & ClientContact.LastName)
                                    Me.AddEmailingComment(DbContext, False, Names, False)

                                End If

                            Catch ex As Exception
                            End Try

                            If String.IsNullOrWhiteSpace(ClientContactEmailAddress) = False Then

                                'send one email
                                Dim eso As New EmailSessionObject(Me._Session.ConnectionString,
                                              Me._Session.UserCode,
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

                                With eso

                                    .AlertId = Me.AlertID
                                    .Subject = BaseEmailSubject
                                    .IsClientPortal = False
                                    .IncludeOriginator = False
                                    .SessionID = HttpContext.Current.Session.SessionID.ToString()
                                    .ClientPortalEmailAddressessToSendTo = ClientContactEmailAddress
                                    .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath

                                    .Send()

                                End With

                                Me.CheckForAsyncMessage()

                            End If

                            Me.LoadReviewers(True, False)

                        End If

                    End Using

                End If

            Case "RemoveReviewer"

                If String.IsNullOrWhiteSpace(e.CommandArgument) = False AndAlso IsNumeric(e.CommandArgument) Then

                    Dim CurrentListViewItem As RadListViewDataItem = e.ListViewItem

                    If CurrentListViewItem IsNot Nothing Then

                        Dim ConceptShareUserID As Integer = CType(e.CommandArgument, Integer)
                        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                        ConceptShareConnection = Nothing
                        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                        If ConceptShareConnection IsNot Nothing Then

                            If AdvantageFramework.ConceptShare.RemoveReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, ConceptShareUserID) IsNot Nothing Then

                                If Me.AlertID > 0 AndAlso ConceptShareConnection.IsClientPortalUser = False Then

                                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                        Try

                                            If CurrentListViewItem.GetDataKeyValue("IsEmployee") = "1" Then

                                            Else

                                                If IsNumeric(CurrentListViewItem.GetDataKeyValue("EmployeeCode")) = True Then

                                                    DataContext.ExecuteCommand(String.Format("DELETE FROM CP_ALERT_RCPT WITH(ROWLOCK) WHERE ALERT_ID = {0} AND CDP_CONTACT_ID = {1};DELETE FROM CP_ALERT_RCPT_DISMISSED WITH(ROWLOCK) WHERE ALERT_ID = {0} AND CDP_CONTACT_ID = {1};",
                                                                                            AlertID, CurrentListViewItem.GetDataKeyValue("EmployeeCode")))

                                                End If

                                            End If

                                        Catch ex As Exception
                                        End Try

                                    End Using

                                End If

                                Me.LoadReviewers(True, False)

                            End If

                        End If

                    End If

                End If

        End Select

    End Sub
    Private Sub RadListViewClientPortalReviewers_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewClientPortalReviewers.ItemDataBound

        Select Case e.Item.ItemType
            Case RadListViewItemType.AlternatingItem, RadListViewItemType.DataItem

                Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)

                If ListItem IsNot Nothing Then

                    Dim DataItem = ListItem.DataItem
                    Dim RemoveReviewerImageButton As ImageButton = e.Item.FindControl("ImageButtonRemoveReviewer")
                    Dim EmailImageButton As ImageButton = e.Item.FindControl("ImageButtonEmail")
                    Dim CurrentReviewerDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivCurrentReviewer")

                    If RemoveReviewerImageButton IsNot Nothing Then

                        If Me.IsClientPortal = True Then

                            RemoveReviewerImageButton.Visible = False

                        Else

                            RemoveReviewerImageButton.OnClientClick = "return confirm('Remove reviewer?');"

                        End If

                    End If
                    If EmailImageButton IsNot Nothing AndAlso Me.IsClientPortal = True Then

                        EmailImageButton.Visible = False

                    End If
                    If CurrentReviewerDiv IsNot Nothing Then

                        Try

                            CurrentReviewerDiv.Attributes.Remove("class")

                            If CType(ListItem.GetDataKeyValue("IsCurrentReviewer"), Boolean) = True Then

                                CurrentReviewerDiv.Attributes.Add("class", "reviewer-active")

                            Else

                                CurrentReviewerDiv.Attributes.Add("class", "reviewer-inactive")

                            End If

                        Catch ex As Exception
                            CurrentReviewerDiv.Visible = False
                        End Try

                    End If
                    If ListItem.GetDataKeyValue("EmployeeCode") = HttpContext.Current.Session("UserID") Then

                        Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Dismiss").Visible = True

                    End If

                End If

        End Select

    End Sub
    Private Sub RadListViewClientPortalReviewers_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewClientPortalReviewers.NeedDataSource

        LoadReviewers(True, False)

    End Sub

    Private Sub RadListViewExternalReviewers_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewExternalReviewers.ItemDataBound

        Select Case e.Item.ItemType
            Case RadListViewItemType.AlternatingItem, RadListViewItemType.DataItem

                Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)

                If ListItem IsNot Nothing Then

                    Dim DataItem = ListItem.DataItem
                    Dim RemoveReviewerImageButton As ImageButton = e.Item.FindControl("ImageButtonRemoveReviewer")
                    Dim EmailImageButton As ImageButton = e.Item.FindControl("ImageButtonEmail")
                    Dim CurrentReviewerDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivCurrentReviewer")

                    If RemoveReviewerImageButton IsNot Nothing Then

                        If Me.IsClientPortal = True Then

                            RemoveReviewerImageButton.Visible = False

                        Else

                            RemoveReviewerImageButton.OnClientClick = "return confirm('Remove external reviewer?');"

                        End If

                    End If
                    If EmailImageButton IsNot Nothing AndAlso Me.IsClientPortal = True Then

                        EmailImageButton.Visible = False

                    End If
                    If CurrentReviewerDiv IsNot Nothing Then

                        Try

                            CurrentReviewerDiv.Attributes.Remove("class")

                            If CType(ListItem.GetDataKeyValue("IsCurrentReviewer"), Boolean) = True Then

                                CurrentReviewerDiv.Attributes.Add("class", "reviewer-active")

                            Else

                                CurrentReviewerDiv.Attributes.Add("class", "reviewer-inactive")

                            End If

                        Catch ex As Exception
                            CurrentReviewerDiv.Visible = False
                        End Try

                    End If

                End If

        End Select

    End Sub
    Private Sub RadListViewExternalReviewers_ItemCommand(sender As Object, e As RadListViewCommandEventArgs) Handles RadListViewExternalReviewers.ItemCommand

        Dim CurrentListViewItem As RadListViewDataItem = e.ListViewItem

        Select Case e.CommandName
            Case "EmailReviewer" 'Need to refactor email to email methods

                Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                ConceptShareConnection = Nothing
                If Me.IsClientPortal = False Then

                    ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                Else

                    ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                End If

                If ConceptShareConnection IsNot Nothing Then

                    Dim AllExternalReviewers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

                    AllExternalReviewers = AdvantageFramework.ConceptShare.LoadExternalReviewMembersByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

                    If AllExternalReviewers IsNot Nothing AndAlso AllExternalReviewers.Count > 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Dim Review As AdvantageFramework.ConceptShareAPI.Review
                                Dim Employee As AdvantageFramework.Database.Views.Employee
                                Dim Err As String = String.Empty

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, _Session.UserCode)
                                Review = AdvantageFramework.ConceptShare.LoadReviewByReviewID(ConceptShareConnection, Me.ConceptShareReviewID, Err)

                                If Review IsNot Nothing AndAlso Employee IsNot Nothing Then

                                    Dim ExternalReviewer As AdvantageFramework.ConceptShareAPI.ReviewMember

                                    ExternalReviewer = Nothing
                                    ExternalReviewer = (From Entity In AllExternalReviewers
                                                        Where Entity.ReferenceId = e.CommandArgument).FirstOrDefault

                                    If ExternalReviewer IsNot Nothing Then

                                        Dim AgencyName As String = String.Empty
                                        Dim URL As String = String.Empty
                                        Dim IsCompleted As Boolean = False

                                        URL = String.Empty
                                        IsCompleted = False

                                        Try

                                            URL = AdvantageFramework.ConceptShare.GetReviewProofingURLForExternalUser(ConceptShareConnection,
                                                                                                                      Me.ConceptShareProjectID,
                                                                                                                      Me.ConceptShareReviewID,
                                                                                                                      ExternalReviewer.ReferenceId)

                                        Catch ex As Exception
                                            URL = String.Empty
                                        End Try
                                        Try

                                            IsCompleted = ExternalReviewer.StatusName IsNot Nothing AndAlso ExternalReviewer.StatusName.ToLower.Contains("complete")

                                        Catch ex As Exception
                                            IsCompleted = False
                                        End Try

                                        If String.IsNullOrWhiteSpace(URL) = False AndAlso String.IsNullOrWhiteSpace(ExternalReviewer.UserName) = False AndAlso
                                                   AdvantageFramework.StringUtilities.IsValidEmailAddress(ExternalReviewer.UserName) = True AndAlso IsCompleted = False Then

                                            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus
                                            Dim ErrorMessage As String = ""
                                            Dim CC As String = ""
                                            Dim BCC As String = ""
                                            Dim EmployeeName As String = Employee.FirstName & " " & Employee.LastName
                                            Dim EmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(True)
                                            Dim JobInfo As Generic.List(Of String) = AdvantageFramework.ConceptShare.LoadJobInfoForTagList(Me._Session,
                                                                                                                                           Me.JobNumber,
                                                                                                                                           Me.JobComponentNumber)
                                            Try

                                                AgencyName = DbContext.Database.SqlQuery(Of String)("SELECT [NAME] FROM AGENCY WITH(NOLOCK);").FirstOrDefault

                                            Catch ex As Exception
                                                AgencyName = String.Empty
                                            End Try

                                            EmailBody.AddCustomRow("Hi {0},")
                                            EmailBody.AddBlankRow()

                                            EmailBody.AddCustomRow(String.Format("{0} from {1} has included you in the '{2}' review where your feedback is required.",
                                                                                 EmployeeName,
                                                                                 AgencyName,
                                                                                 Review.Title))
                                            EmailBody.AddBlankRow()

                                            If JobInfo IsNot Nothing Then

                                                For Each BitOfInfo As String In JobInfo

                                                    EmailBody.AddCustomRow(String.Format("{0}<br/>", BitOfInfo))

                                                Next

                                            End If

                                            EmailBody.AddCustomRow(String.Format("Description:  {0}<br/>", Review.Description))

                                            If Review.DueDate IsNot Nothing AndAlso IsDate(Review.DueDate) = True Then

                                                EmailBody.AddCustomRow(String.Format("Due date:  {0}<br/>", Review.DueDate))

                                            End If

                                            EmailBody.AddBlankRow()

                                            EmailBody.AddCustomRow("Please use the link below to launch the review:")
                                            EmailBody.AddCustomRow("<a href=""{1}"">{1}</a>")
                                            EmailBody.AddCustomRow("<div style=""font-size:small !important;font-style:italic;"">If you cannot click the link, try copying and pasting the link into your browser.</div>")
                                            EmailBody.AddBlankRow()

                                            EmailBody.AddCustomRow("Thank you!")
                                            EmailBody.AddBlankRow()

                                            EmailBody.Finish()

                                            AdvantageFramework.Email.Send(DbContext,
                                                                          SecurityDbContext,
                                                                          ExternalReviewer.UserName,
                                                                          String.Format(BaseEmailSubject & " {0}", Me.TextBoxReviewName.Text),
                                                                          String.Format(EmailBody.ToString, ExternalReviewer.Name, URL),
                                                                          0,
                                                                          Nothing, SendingEmailStatus,
                                                                          ErrorMessage, CC, BCC)

                                            Me.AddUpdateEmailExternalReviewer(DbContext, ExternalReviewer, True)

                                            Dim Names As New Generic.List(Of String)
                                            Names.Add(ExternalReviewer.Name)
                                            Me.AddEmailingComment(DbContext, True, Names, False)

                                            Try

                                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CS_EXT_REVIEWER SET LAST_EMAILED = NULL WHERE CS_REVIEW_ID = {0};UPDATE CS_EXT_REVIEWER SET LAST_EMAILED = GETDATE() WHERE CS_REVIEW_ID = {0} AND EMAIL_ADDRESS = '{1}';", Me.ConceptShareReviewID, ExternalReviewer.UserName))

                                                Me.LoadReviewers(False, True)

                                            Catch ex As Exception
                                            End Try

                                        End If

                                    End If

                                End If

                            End Using

                        End Using

                    End If

                End If

            Case "RemoveReviewer"

                If IsNumeric(e.CommandArgument) = True Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim ConceptShareUserID As Integer = CType(e.CommandArgument, Integer)
                        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                        ConceptShareConnection = Nothing
                        If Me.IsClientPortal = False Then

                            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                        Else

                            ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                        End If

                        If ConceptShareConnection IsNot Nothing Then

                            If AdvantageFramework.ConceptShare.RemoveReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, ConceptShareUserID) IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ConceptShareExternalReviewer.DeleteByConceptShareUserIDAndReviewID(DbContext, Me.ConceptShareReviewID, ConceptShareUserID)

                                Me.LoadReviewers(False, True)

                            End If

                        End If

                    End Using

                End If

        End Select

    End Sub
    Private Sub RadListViewExternalReviewers_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewExternalReviewers.NeedDataSource

    End Sub

    Private Sub AddUpdateEmailExternalReviewer(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                               ByRef ExternalReviewer As AdvantageFramework.ConceptShareAPI.ReviewMember,
                                               ByVal EmailSent As Boolean)


        AdvantageFramework.ConceptShare.AddUpdateEmailExternalReviewer(DbContext, Me.ConceptShareReviewID, Me.AlertID, ExternalReviewer, EmailSent)

    End Sub

    Private Sub LoadReviewers(ByVal Internal As Boolean, ByVal External As Boolean)

        If Me.ConceptShareReviewID > 0 AndAlso (Internal = True OrElse External = True) Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing

            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim ReviewMembers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

                    ReviewMembers = Nothing

                    Try

                        ReviewMembers = ConceptShareConnection.APIServiceClient.GetReviewMemberList(ConceptShareConnection.APIContext, Me.ConceptShareReviewID).ToList

                    Catch ex As Exception
                        ReviewMembers = Nothing
                    End Try

                    If ReviewMembers IsNot Nothing Then

                        Dim ReviewResponses As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewResponse)
                        Dim ConceptShareReviewers As Generic.List(Of AdvantageFramework.ConceptShare.Classes.Reviewer)
                        Dim ConceptShareEmployees As Generic.List(Of ConceptShareSession.ConceptShareEmployee)
                        Dim ExternalReviewers As Generic.List(Of AdvantageFramework.Database.Entities.ConceptShareExternalReviewer)

                        Dim WebCS As New ConceptShareSession(_Session)

                        WebCS.LoadConceptShareReviewers()
                        WebCS.LoadConceptShareEmployees()

                        ReviewResponses = Nothing
                        ConceptShareReviewers = Nothing
                        ConceptShareEmployees = Nothing

                        ConceptShareReviewers = WebCS.Reviewers
                        ConceptShareEmployees = WebCS.Employees

                        If External = True Then

                            ExternalReviewers = AdvantageFramework.Database.Procedures.ConceptShareExternalReviewer.LoadByReviewID(DbContext, Me.ConceptShareReviewID).ToList

                        End If

                        If ExternalReviewers Is Nothing Then ExternalReviewers = New Generic.List(Of AdvantageFramework.Database.Entities.ConceptShareExternalReviewer)

                        Try

                            ReviewResponses = ConceptShareConnection.APIServiceClient.GetReviewResponses(ConceptShareConnection.APIContext, Me.ConceptShareReviewID, Nothing, Nothing, Nothing).ToList

                        Catch ex As Exception
                            ReviewResponses = Nothing
                        End Try

                        Dim AlertRecipients As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient) = Nothing
                        Dim DismissedAlertRecipients As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipientDismissed) = Nothing

                        Dim ClientPortalRecipients As Generic.List(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipient) = Nothing
                        Dim DismissedClientPortalRecipients As Generic.List(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed) = Nothing

                        AlertRecipients = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Me.AlertID).ToList
                        DismissedAlertRecipients = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, Me.AlertID).ToList

                        ClientPortalRecipients = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertID(DbContext, Me.AlertID).ToList
                        DismissedClientPortalRecipients = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertID(DbContext, Me.AlertID).ToList

                        If AlertRecipients Is Nothing Then

                            AlertRecipients = New Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient)

                        End If
                        Try

                            If DismissedAlertRecipients IsNot Nothing AndAlso DismissedAlertRecipients.Count > 0 Then

                                Dim TempAlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient
                                For Each Dismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed In DismissedAlertRecipients

                                    TempAlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                                    Try

                                        TempAlertRecipient.AlertID = Dismissed.AlertID
                                        TempAlertRecipient.ID = Dismissed.ID
                                        TempAlertRecipient.EmployeeCode = Dismissed.EmployeeCode
                                        TempAlertRecipient.EmployeeEmail = Dismissed.EmployeeEmail
                                        TempAlertRecipient.ProcessedDate = Dismissed.ProcessedDate
                                        TempAlertRecipient.IsNewAlert = Dismissed.IsNewAlert
                                        TempAlertRecipient.HasBeenRead = Dismissed.HasBeenRead
                                        TempAlertRecipient.IsCurrentRecipient = Dismissed.IsCurrentRecipient
                                        TempAlertRecipient.IsCurrentNotify = Dismissed.IsCurrentNotify
                                        TempAlertRecipient.CardSequenceNumber = 0
                                        TempAlertRecipient.IsConceptShareReviewer = Dismissed.IsConceptShareReviewer
                                        TempAlertRecipient.IsDeleted = Dismissed.IsDeleted

                                    Catch ex As Exception
                                    End Try

                                    AlertRecipients.Add(TempAlertRecipient)

                                    TempAlertRecipient = Nothing

                                Next

                            End If

                        Catch ex As Exception
                        End Try
                        Try

                            If DismissedClientPortalRecipients IsNot Nothing AndAlso DismissedClientPortalRecipients.Count > 0 Then

                                Dim TempClientPortalRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

                                For Each Dismissed As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed In DismissedClientPortalRecipients

                                    TempClientPortalRecipient = New AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

                                    Try

                                        TempClientPortalRecipient.AlertID = Dismissed.AlertID
                                        TempClientPortalRecipient.ProcessedDate = Dismissed.ProcessedDate
                                        TempClientPortalRecipient.IsNewAlert = Dismissed.IsNewAlert
                                        TempClientPortalRecipient.HasBeenRead = Dismissed.HasBeenRead
                                        TempClientPortalRecipient.IsConceptShareReviewer = Dismissed.IsConceptShareReviewer
                                        TempClientPortalRecipient.IsDeleted = Dismissed.IsDeleted
                                        TempClientPortalRecipient.AlertRecipientID = Dismissed.AlertRecipientID
                                        TempClientPortalRecipient.ClientContactID = Dismissed.ClientContactID
                                        TempClientPortalRecipient.EmailAddress = Dismissed.EmailAddress

                                    Catch ex As Exception
                                    End Try

                                    ClientPortalRecipients.Add(TempClientPortalRecipient)

                                    TempClientPortalRecipient = Nothing

                                Next

                            End If

                        Catch ex As Exception
                        End Try

                        If ReviewResponses Is Nothing OrElse (ReviewResponses IsNot Nothing AndAlso ReviewResponses.Count = 0) Then

                            If Internal = True Then

                                If IsRouted = False Then

                                    Try

                                        RadListViewReviewers.DataSource = (From Entity In ReviewMembers
                                                                           Join Reviewer In ConceptShareReviewers On Entity.ReferenceId Equals Reviewer.ConceptShareUserID
                                                                           Join Employee In ConceptShareEmployees On Entity.ReferenceId Equals Employee.ConceptShareUserID
                                                                           Join AlertRecipient In AlertRecipients On Employee.EmployeeCode Equals AlertRecipient.EmployeeCode
                                                                           Where Entity.ExternalReviewer = False And
                                                                             AlertRecipient.AlertID = Me.AlertID
                                                                           Select New With {.Id = Entity.Id,
                                                                                            .ConceptShareUserID = Entity.ReferenceId,
                                                                                            .FullName = Reviewer.FullName,
                                                                                            .Picture = Reviewer.Picture,
                                                                                            .Status = Entity.StatusName,
                                                                                            .StatusID = Entity.StatusId,
                                                                                            .EmployeeCode = Reviewer.EmployeeCode,
                                                                                            .IsEmployee = Reviewer.IsEmployee,
                                                                                            .SortOrder = AlertRecipient.ID,
                                                                                            .EmailAddress = IIf(String.IsNullOrWhiteSpace(AlertRecipient.EmployeeEmail) = True, Entity.UserName, AlertRecipient.EmployeeEmail),
                                                                                            .IsCurrentReviewer = IIf(AlertRecipient.IsCurrentNotify IsNot Nothing AndAlso AlertRecipient.IsCurrentNotify = 1, True, False)}).ToList.OrderBy(Function(MyData) MyData.SortOrder)

                                    Catch ex As Exception
                                    End Try
                                    Try

                                        RadListViewClientPortalReviewers.DataSource = (From Entity In ReviewMembers
                                                                                       Join Reviewer In ConceptShareReviewers On Entity.ReferenceId Equals Reviewer.ConceptShareUserID
                                                                                       Join Employee In ConceptShareEmployees On Entity.ReferenceId Equals Employee.ConceptShareUserID
                                                                                       Join ClientPortalRecipient In ClientPortalRecipients On Employee.ClientContactID Equals ClientPortalRecipient.ClientContactID
                                                                                       Where Entity.ExternalReviewer = False And
                                                                                       ClientPortalRecipient.AlertID = Me.AlertID
                                                                                       Select New With {.Id = Entity.Id,
                                                                                                        .ConceptShareUserID = Entity.ReferenceId,
                                                                                                        .FullName = Reviewer.FullName,
                                                                                                        .Picture = Reviewer.Picture,
                                                                                                        .Status = Entity.StatusName,
                                                                                                        .StatusID = Entity.StatusId,
                                                                                                        .EmployeeCode = Reviewer.EmployeeCode,
                                                                                                        .IsEmployee = Reviewer.IsEmployee,
                                                                                                        .SortOrder = ClientPortalRecipient.AlertRecipientID,
                                                                                                        .EmailAddress = IIf(String.IsNullOrWhiteSpace(ClientPortalRecipient.EmailAddress) = True, Entity.UserName, ClientPortalRecipient.EmailAddress),
                                                                                                        .IsCurrentReviewer = IIf(ClientPortalRecipient.IsDeleted IsNot Nothing AndAlso ClientPortalRecipient.IsDeleted = 0, True, False)}).ToList.OrderBy(Function(MyData) MyData.SortOrder)

                                    Catch ex As Exception
                                    End Try

                                End If

                            End If
                            If External = True Then

                                Try

                                    Me.RadListViewExternalReviewers.DataSource = (From Entity In ReviewMembers
                                                                                  Join DbExtUsers In ExternalReviewers On Entity.ReferenceId Equals DbExtUsers.ConceptShareUserID
                                                                                  Where Entity.ExternalReviewer = True
                                                                                  Select New With {.FullName = Entity.Name,
                                                                                                   .ConceptShareUserID = Entity.ReferenceId,
                                                                                                   .EmailAddress = Entity.UserName,
                                                                                                   .IsCurrentReviewer = IIf(DbExtUsers.LastEmailed Is Nothing, False, True),
                                                                                                   .Status = IIf(String.IsNullOrWhiteSpace(Entity.StatusName) = True,
                                                                                                                 "", String.Format(" ({0})", Entity.StatusName))}).ToList

                                Catch ex As Exception
                                End Try

                            End If

                        Else

                            If Internal = True Then

                                If IsRouted = False Then

                                    Try

                                        RadListViewReviewers.DataSource = (From Entity In ReviewMembers
                                                                           Join Reviewer In ConceptShareReviewers On Entity.ReferenceId Equals Reviewer.ConceptShareUserID
                                                                           Join Employee In ConceptShareEmployees On Entity.ReferenceId Equals Employee.ConceptShareUserID
                                                                           Join AlertRecipient In AlertRecipients On Employee.EmployeeCode Equals AlertRecipient.EmployeeCode
                                                                           Where Entity.ExternalReviewer = False And
                                                                             AlertRecipient.AlertID = Me.AlertID
                                                                           Group Join Response In ReviewResponses On Entity.ReferenceId Equals Response.ReferenceId
                                                                           Into ResponseList = Group
                                                                           From Response In ResponseList.DefaultIfEmpty
                                                                           Select New With {.Id = Entity.Id,
                                                                                            .ConceptShareUserID = Entity.ReferenceId,
                                                                                            .FullName = Reviewer.FullName,
                                                                                            .Picture = Reviewer.Picture,
                                                                                            .Status = If(Response Is Nothing, Entity.StatusName, Response.StatusName),
                                                                                            .StatusID = If(Response Is Nothing, Entity.StatusId, Response.StatusId),
                                                                                            .EmployeeCode = Reviewer.EmployeeCode,
                                                                                            .IsEmployee = Reviewer.IsEmployee,
                                                                                            .SortOrder = AlertRecipient.ID,
                                                                                            .EmailAddress = IIf(String.IsNullOrWhiteSpace(AlertRecipient.EmployeeEmail) = True, Entity.UserName, AlertRecipient.EmployeeEmail),
                                                                                            .IsCurrentReviewer = IIf(AlertRecipient.IsCurrentNotify IsNot Nothing AndAlso AlertRecipient.IsCurrentNotify = 1, True, False)}).ToList.OrderBy(Function(MyData) MyData.SortOrder)

                                    Catch ex As Exception
                                    End Try
                                    Try

                                        RadListViewClientPortalReviewers.DataSource = (From Entity In ReviewMembers
                                                                                       Join Reviewer In ConceptShareReviewers On Entity.ReferenceId Equals Reviewer.ConceptShareUserID
                                                                                       Join Employee In ConceptShareEmployees On Entity.ReferenceId Equals Employee.ConceptShareUserID
                                                                                       Join ClientPortalRecipient In ClientPortalRecipients On Employee.ClientContactID Equals ClientPortalRecipient.ClientContactID
                                                                                       Where Entity.ExternalReviewer = False And
                                                                                       ClientPortalRecipient.AlertID = Me.AlertID
                                                                                       Group Join Response In ReviewResponses On Entity.ReferenceId Equals Response.ReferenceId
                                                                                       Into ResponseList = Group
                                                                                       From Response In ResponseList.DefaultIfEmpty
                                                                                       Select New With {.Id = Entity.Id,
                                                                                                        .ConceptShareUserID = Entity.ReferenceId,
                                                                                                        .FullName = Reviewer.FullName,
                                                                                                        .Picture = Reviewer.Picture,
                                                                                                        .Status = If(Response Is Nothing, Entity.StatusName, Response.StatusName),
                                                                                                        .StatusID = If(Response Is Nothing, Entity.StatusId, Response.StatusId),
                                                                                                        .EmployeeCode = Reviewer.EmployeeCode,
                                                                                                        .IsEmployee = Reviewer.IsEmployee,
                                                                                                        .SortOrder = ClientPortalRecipient.AlertRecipientID,
                                                                                                        .EmailAddress = IIf(String.IsNullOrWhiteSpace(ClientPortalRecipient.EmailAddress) = True, Entity.UserName, ClientPortalRecipient.EmailAddress),
                                                                                                        .IsCurrentReviewer = IIf(ClientPortalRecipient.IsDeleted IsNot Nothing AndAlso ClientPortalRecipient.IsDeleted = 0, True, False)}).ToList.OrderBy(Function(MyData) MyData.SortOrder)


                                    Catch ex As Exception
                                    End Try

                                End If

                            End If
                            If External = True Then

                                Try

                                    Me.RadListViewExternalReviewers.DataSource = (From Entity In ReviewMembers
                                                                                  Join DbExtUsers In ExternalReviewers On Entity.ReferenceId Equals DbExtUsers.ConceptShareUserID
                                                                                  Where Entity.ExternalReviewer = True
                                                                                  Group Join Response In ReviewResponses On Entity.ReferenceId Equals Response.ReferenceId
                                                                                  Into ResponseList = Group
                                                                                  From Response In ResponseList.DefaultIfEmpty
                                                                                  Select New With {.FullName = Entity.Name,
                                                                                                   .ConceptShareUserID = Entity.ReferenceId,
                                                                                                   .EmailAddress = Entity.UserName,
                                                                                                   .IsCurrentReviewer = IIf(DbExtUsers.LastEmailed Is Nothing, False, True),
                                                                                                   .Status = If(Response Is Nothing, Entity.StatusName, Response.StatusName)
                                                                                                  }).ToList

                                Catch ex As Exception
                                End Try

                                Try

                                    'ExternalReviewers = (From Entity In ReviewMembers
                                    '                     Where Entity.ExternalReviewer = True
                                    '                     Group Join Response In ReviewResponses On Entity.ReferenceId Equals Response.ReferenceId
                                    '                               Into ResponseList = Group
                                    '                     From Response In ResponseList.DefaultIfEmpty
                                    '                     Select Entity).ToList

                                Catch ex As Exception
                                    ExternalReviewers = Nothing
                                End Try

                            End If

                        End If

                    End If

                End Using

            End If

        End If

    End Sub

    Private Sub RadGridReviewComments_DetailTableDataBind(sender As Object, e As GridDetailTableDataBindEventArgs) Handles RadGridReviewComments.DetailTableDataBind

        Dim CurrentRow As GridDataItem = DirectCast(e.DetailTableView.ParentItem, GridDataItem)

        If CurrentRow IsNot Nothing Then

            Select Case e.DetailTableView.Name
                Case "DetailTableReplies"

                    Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                    Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                    ConceptShareConnection = Nothing
                    If Me.IsClientPortal = False Then

                        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                    Else

                        ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                    End If

                    If ConceptShareConnection IsNot Nothing Then

                        Dim AssetID As Integer = 0
                        Dim CommentID As Integer = 0

                        Try

                            AssetID = CurrentRow.GetDataKeyValue("ReferenceId")

                        Catch ex As Exception
                            AssetID = 0
                        End Try
                        Try

                            CommentID = CurrentRow.GetDataKeyValue("Id")

                        Catch ex As Exception
                            CommentID = 0
                        End Try

                        If AssetID > 0 AndAlso CommentID > 0 Then

                            e.DetailTableView.DataSource = AdvantageFramework.ConceptShare.LoadCommentReplies(ConceptShareConnection, AssetID, CommentID)

                        End If

                    End If


            End Select

        End If

    End Sub

    Private Sub RadGridReviewComments_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridReviewComments.ItemDataBound

        Select Case e.Item.ItemType
            Case GridItemType.Header
            Case GridItemType.Item, GridItemType.AlternatingItem

                Dim CurrentRow As GridDataItem = CType(e.Item, GridDataItem)

                If CurrentRow IsNot Nothing Then

                    Select Case CurrentRow.OwnerTableView.Name
                        Case "DetailTableReplies"

                            Dim CommentThread As AdvantageFramework.ConceptShareAPI.CommentThread = Nothing
                            Try

                                CommentThread = e.Item.DataItem

                            Catch ex As Exception
                                CommentThread = Nothing
                            End Try

                            If CommentThread IsNot Nothing Then

                                _GridHasReplies = True

                                Dim CreatedDateLabel As Label = CurrentRow.FindControl("LabelCreatedDate")
                                Try

                                    If CreatedDateLabel IsNot Nothing AndAlso IsDate(CommentThread.CreatedDate) = True Then

                                        CreatedDateLabel.Text = DateAdd(DateInterval.Hour, Me.EmployeeTimezoneOffset, CType(CommentThread.CreatedDate, DateTime))

                                    End If

                                Catch ex As Exception
                                End Try

                            End If

                        Case Else

                            Dim Comment As AdvantageFramework.ConceptShareAPI.Comment = Nothing
                            Try

                                Comment = e.Item.DataItem

                            Catch ex As Exception
                                Comment = Nothing
                            End Try

                            If Comment IsNot Nothing Then

                                Dim CommentDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivComment")

                                If CommentDiv IsNot Nothing Then

                                    Dim DateCreatedLabel As Label = CurrentRow.FindControl("LabelDateCreated")
                                    Try

                                        If DateCreatedLabel IsNot Nothing AndAlso IsDate(Comment.DateCreated) = True Then

                                            DateCreatedLabel.Text = DateAdd(DateInterval.Hour, Me.EmployeeTimezoneOffset, CType(Comment.DateCreated, DateTime))

                                        End If

                                    Catch ex As Exception
                                    End Try
                                    If Comment.IsDraft = True Then

                                        CommentDiv.Attributes.Add("class", "draft-style")

                                    Else

                                        CommentDiv.Attributes.Add("class", "comment-style")

                                    End If

                                End If

                                If Comment.TotalReplies = 0 Then

                                    Dim TotalRepliesDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivTotalReplies")

                                    If TotalRepliesDiv IsNot Nothing Then

                                        TotalRepliesDiv.Visible = False

                                    End If

                                Else

                                    _GridHasReplies = True

                                End If

                            End If

                    End Select

                End If

            Case GridItemType.Footer

                If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                    Me.SelectFirstComment()

                End If

                Me.CheckBoxExpandAllComments.Visible = _GridHasReplies
                Me.RadGridReviewComments.MasterTableView.GetColumnSafe("GridTemplateColumnReplies").Visible = _GridHasReplies

        End Select
    End Sub
    Private Sub RadGridReviewComments_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridReviewComments.NeedDataSource

        Me.FieldsetDrafts.Visible = False
        Me.RadGridReviewComments.MasterTableView.HierarchyDefaultExpanded = Me.CheckBoxExpandAllComments.Checked

        If Me.ConceptShareReviewID > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim Offset As Decimal

                    If IsClientPortal = False Then
                        Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, _Session.User.EmployeeCode)
                    End If

                    Dim Comments As Generic.List(Of AdvantageFramework.ConceptShareAPI.Comment)

                    Comments = Nothing

                    If Me.SelectedAssetID = 0 Then

                        'Try

                        '    Comments = AdvantageFramework.ConceptShare.LoadAllReviewComments(DataContext, Employee, Me.ConceptShareReviewID)

                        'Catch ex As Exception
                        '    Comments = Nothing
                        'End Try
                        'Try

                        '    Dim DraftThreads As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread)

                        '    DraftThreads = Nothing
                        '    DraftThreads = AdvantageFramework.ConceptShare.LoadDraftCommentsForEmployeeByReviewID(DataContext, Employee, Me.ConceptShareReviewID)

                        '    If DraftThreads IsNot Nothing AndAlso DraftThreads.Count > 0 Then

                        '        Me.FieldsetDrafts.Visible = True
                        '        Me.ListViewDraftComments.DataSource = DraftThreads
                        '        Me.ListViewDraftComments.DataBind()

                        '    End If

                        'Catch ex As Exception
                        '    Me.FieldsetDrafts.Visible = False
                        'End Try

                    Else

                        Try

                            Comments = AdvantageFramework.ConceptShare.LoadCommentsForReviewAsset(ConceptShareConnection, DbContext,
                                                                                                  Me.AlertID, Me.ConceptShareReviewID, Me.SelectedAssetID, Offset)

                        Catch ex As Exception
                            Comments = Nothing
                        End Try

                    End If

                    Try

                        Dim DraftThreads As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread)

                        DraftThreads = Nothing
                        DraftThreads = AdvantageFramework.ConceptShare.LoadDraftCommentsForEmployeeByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

                        If DraftThreads IsNot Nothing AndAlso DraftThreads.Count > 0 Then

                            Me.FieldsetDrafts.Visible = True
                            Me.ListViewDraftComments.DataSource = DraftThreads
                            Me.ListViewDraftComments.DataBind()

                        End If

                    Catch ex As Exception
                        Me.FieldsetDrafts.Visible = False
                    End Try

                    If Comments Is Nothing Then Comments = New Generic.List(Of AdvantageFramework.ConceptShareAPI.Comment)

                    Me.RadGridReviewComments.DataSource = Comments

                    Me.CommentCount = Comments.Count
                    Me.DivCommentsPanel.Visible = Me.CommentCount > 0

                End Using

            End If

        End If

    End Sub
    Private Sub RadGridReviewComments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridReviewComments.SelectedIndexChanged

        Me.SelectAssetRow()

    End Sub
    Private Sub SelectAssetRow()

        Try

            Dim SelectedRow As GridDataItem = Me.RadGridReviewComments.SelectedItems(0)

            If SelectedRow IsNot Nothing Then

                Me.SelectCommentRow(SelectedRow)

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub SelectCommentRow(ByRef RowToSelect As GridDataItem)

        If RowToSelect IsNot Nothing Then

            Dim MarkupID As Integer = RowToSelect.GetDataKeyValue("Id")
            Dim CommentID As Integer = RowToSelect.GetDataKeyValue("MarkupId")
            Dim AssetID As Integer = 0

            If RowToSelect.GetDataKeyValue("ReferenceType").ToString.Contains("Asset") = True Then

                AssetID = RowToSelect.GetDataKeyValue("ReferenceId")

            Else

                AssetID = LastAssetID

            End If

            If MarkupID > 0 AndAlso CommentID > 0 Then

                Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                ConceptShareConnection = Nothing
                If Me.IsClientPortal = False Then

                    ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                Else

                    ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                End If

                If ConceptShareConnection IsNot Nothing Then

                    Dim Base64String As String = String.Empty
                    Dim BinaryImage As Byte()
                    Dim Show As Boolean = False

                    BinaryImage = AdvantageFramework.ConceptShare.DownloadMarkupImage(ConceptShareConnection, CommentID, 250, 250)

                    Try

                        Base64String = Convert.ToBase64String(BinaryImage)

                    Catch ex As Exception
                        Base64String = String.Empty
                    End Try

                    If String.IsNullOrWhiteSpace(Base64String) = False Then

                        ImageMarkupImage.ImageUrl = String.Format("data:image/jpeg;base64,{0}", Base64String)

                        ImageMarkupImage.Attributes.Remove("onclick")
                        Dim Qs As New AdvantageFramework.Web.QueryString

                        Qs.Page = "Alert_DigitalAssetReview_Comment.aspx"
                        Qs.ConceptShareProjectID = Me.ConceptShareProjectID
                        Qs.ConceptShareReviewID = Me.ConceptShareReviewID
                        Qs.ConceptShareAssetID = AssetID
                        Qs.ConceptShareCommentID = CommentID

                        ImageMarkupImage.Attributes.Add("onclick", Me.HookUpOpenWindow("", Qs.ToString(True)))

                    Else

                        ImageMarkupImage.Visible = False

                    End If

                    Dim Asset As AdvantageFramework.ConceptShareAPI.Asset

                    Asset = Nothing
                    Asset = AdvantageFramework.ConceptShare.LoadAssetByAssetID(ConceptShareConnection, AssetID)

                    If Asset IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(Asset.FileName) = False Then

                            Show = True

                        End If

                    End If

                    If Show = True Then

                        Me.DivAssetInfo.Visible = True

                        Me.LabelAssetInfoFilename.Text = Asset.FileName
                        Me.LabelAssetInfoVersion.Text = Asset.VersionNumber
                        Me.LabelAssetInfoCreatedDate.Text = CType(Asset.DateCreated, Date).ToLongDateString
                        Me.LabelAssetInfoCreatedBy.Text = Asset.CreatedByName
                        Me.LabelAssetInfoStatus.Text = Asset.StatusName

                    Else

                        Me.DivAssetInfo.Visible = False

                    End If

                End If


            End If

        End If

    End Sub
    Private Sub SelectFirstComment()

        Try

            If Me.RadGridReviewComments.SelectedItems IsNot Nothing AndAlso Me.RadGridReviewComments.SelectedItems.Count = 0 Then

                If Me.CommentCount > 0 Then

                    For Each GridRow As GridDataItem In Me.RadGridReviewComments.MasterTableView.Items

                        If GridRow.ItemType = GridItemType.Item Then

                            GridRow.Selected = True
                            Me.SelectCommentRow(GridRow)
                            Exit For

                        End If

                    Next

                End If

            End If

        Catch ex As Exception
        End Try

    End Sub

    'Private Sub ListViewDraftComments_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles ListViewDraftComments.ItemCommand
    '    Select Case e.CommandName

    '        Case "PublishDraftComment"

    '        Case "DeleteDraftComment"

    '    End Select

    'End Sub
    Private Sub ListViewDraftComments_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles ListViewDraftComments.ItemDataBound

        Select Case e.Item.ItemType
            Case ListViewItemType.DataItem

                Dim Thread As AdvantageFramework.ConceptShareAPI.CommentThread = e.Item.DataItem

                If Thread IsNot Nothing Then

                    Dim DeleteLinkButton As LinkButton = e.Item.FindControl("LinkButtonDelete")

                    If DeleteLinkButton IsNot Nothing Then

                        DeleteLinkButton.OnClientClick = "return confirm('Delete draft comment?');"

                    End If

                End If

        End Select

    End Sub

    Private Sub RadioButtonListAutoApproveRule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListAutoApproveRule.SelectedIndexChanged

        Me.SetAutoApproveRuleReviewStatus()

    End Sub

    Private Sub RadGridReviewCommentThreads_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTest_ReviewCommentThreads.NeedDataSource

        If Me.HiddenFieldShowTestData.Value = "1" AndAlso Me.ConceptShareReviewID > 0 Then

            Dim CommentThreads As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread)

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            If ConceptShareConnection IsNot Nothing Then

                CommentThreads = AdvantageFramework.ConceptShare.LoadReviewCommentThreadListByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

            End If


            If CommentThreads Is Nothing Then CommentThreads = New Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread)

            Me.RadGridTest_ReviewCommentThreads.DataSource = CommentThreads

        End If

    End Sub
    Private Sub RadGridReviewCommentsTest_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTest_ReviewCommentsTest.NeedDataSource

        If Me.HiddenFieldShowTestData.Value = "1" AndAlso Me.ConceptShareReviewID > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Me.RadGridTest_ReviewCommentsTest.DataSource = AdvantageFramework.ConceptShare.LoadAllReviewComments(ConceptShareConnection, Me.ConceptShareReviewID)

            End If


        End If

    End Sub
    Private Sub RadGridReviewAssets_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTest_ReviewAssets.NeedDataSource

        If Me.HiddenFieldShowTestData.Value = "1" AndAlso Me.ConceptShareReviewID > 0 Then

            Dim Assets As Generic.List(Of AdvantageFramework.ConceptShareAPI.Asset)
            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Assets = AdvantageFramework.ConceptShare.LoadReviewAssets(ConceptShareConnection, Me.ConceptShareReviewID)

            End If

            Me.RadGridTest_ReviewAssets.DataSource = Assets

        End If

    End Sub
    Private Sub RadGridReviewers_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTest_Reviewers.NeedDataSource

        If Me.HiddenFieldShowTestData.Value = "1" AndAlso Me.ConceptShareReviewID > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Me.RadGridTest_Reviewers.DataSource = AdvantageFramework.ConceptShare.LoadReviewMembersByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

            End If


        End If

    End Sub
    Private Sub RadGridReviewItems_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTest_ReviewItems.NeedDataSource

        If Me.HiddenFieldShowTestData.Value = "1" AndAlso Me.ConceptShareReviewID > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Me.RadGridTest_ReviewItems.DataSource = AdvantageFramework.ConceptShare.LoadReviewItemsByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

            End If


        End If

    End Sub
    Private Sub RadGridProjectFolderItems_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTest_ProjectFolderItems.NeedDataSource

        If Me.HiddenFieldShowTestData.Value = "1" AndAlso Me.ConceptShareReviewID > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Me.RadGridTest_ProjectFolderItems.DataSource = AdvantageFramework.ConceptShare.LoadProjectFolderItems(ConceptShareConnection, Me.ConceptShareProjectID)

            End If


        End If

    End Sub
    Private Sub RadGridReviewResponses_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTest_ReviewResponses.NeedDataSource

        If Me.HiddenFieldShowTestData.Value = "1" AndAlso Me.ConceptShareReviewID > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            If Me.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Me.RadGridTest_ReviewResponses.DataSource = AdvantageFramework.ConceptShare.LoadAllReviewResponses(ConceptShareConnection, Me.ConceptShareReviewID)

            End If

        End If
    End Sub

#End Region
#Region " Page "

    Private Sub Alert_DigitalAssetReview_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If Me.CurrentQuerystring.AlertID > 0 Then Me.AlertID = Me.CurrentQuerystring.AlertID
            If Not Me.CurrentQuerystring.ConceptShareBaseReviewType = Nothing Then Me.BaseReviewType = Me.CurrentQuerystring.ConceptShareBaseReviewType
            If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
            If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber
            If Me.CurrentQuerystring.ConceptShareProjectID > 0 Then Me.ConceptShareProjectID = Me.CurrentQuerystring.ConceptShareProjectID
            If Me.CurrentQuerystring.ConceptShareReviewID > 0 Then Me.ConceptShareReviewID = Me.CurrentQuerystring.ConceptShareReviewID

            Try

                If Me.AlertID = 0 AndAlso Request.QueryString("alert") IsNot Nothing AndAlso IsNumeric(Request.QueryString("alert")) = True Then

                    Me.AlertID = CType(Request.QueryString("alert"), Integer)

                End If

            Catch ex As Exception
            End Try
            Try

                If Me.AlertID = 0 AndAlso Me.ConceptShareReviewID > 0 Then

                    Me.AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ALERT_ID FROM ALERT WITH(NOLOCK) WHERE CS_REVIEW_ID = {0};", Me.ConceptShareReviewID)).SingleOrDefault

                End If

            Catch ex As Exception
            End Try
            Try

                If Me.AlertID > 0 Then

                    Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertID)

                    If Alert IsNot Nothing Then

                        If Me.ConceptShareProjectID = 0 AndAlso Alert.ConceptShareProjectID IsNot Nothing AndAlso Alert.ConceptShareProjectID > 0 Then

                            Me.ConceptShareProjectID = Alert.ConceptShareProjectID

                        End If
                        If Me.ConceptShareReviewID = 0 AndAlso Alert.ConceptShareReviewID IsNot Nothing AndAlso Alert.ConceptShareReviewID > 0 Then

                            Me.ConceptShareReviewID = Alert.ConceptShareReviewID

                        End If
                        If Alert.JobNumber IsNot Nothing AndAlso Alert.JobNumber > 0 Then

                            Me.JobNumber = Alert.JobNumber

                        End If
                        If Alert.JobComponentNumber IsNot Nothing AndAlso Alert.JobComponentNumber > 0 Then

                            Me.JobComponentNumber = Alert.JobComponentNumber

                        End If
                        If Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Alert.AlertStateID IsNot Nothing Then

                            Me.IsRouted = True

                        End If

                    End If

                    SetRoutedInfo(True)

                End If

            Catch ex As Exception
            End Try

            Dim b As RadToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Routed")
            If b IsNot Nothing Then

                Me.IsRouted = ConceptShareSession.GetUserReviewRoutedSetting(DbContext)
                b.Checked = Me.IsRouted

            End If

        End Using

    End Sub
    Private Sub Alert_DigitalAssetReview_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim NewEditTitle As String = String.Empty
        Dim BaseReviewTypeTitle As String = String.Empty

        Dim itemsList As String() = {""}
        RadAutoCompleteBoxExternalReviewers.DataSource = itemsList

        Me.LabelApproved = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("RadToolBarButtonLabels").FindControl("LabelApproved")
        Me.LabelDismissed = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("RadToolBarButtonLabels").FindControl("LabelDismissed")
        Me.LabelCompleted = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("RadToolBarButtonLabels").FindControl("LabelCompleted")

        If Me.IsPostBack = False AndAlso Me.IsCallback = False Then

            Me.SetRadDatePicker(Me.RadDatePickerDueDate)


            Dim a As New cAlerts()
            a.LoadPrioritiesComboBox(Me.RadComboBoxPriority)
            'Me.LoadRadComboBoxReviewType()
            'Me.LoadRadioButtonListAutoApproveRule()
            Me.LoadRadComboBoxReviewStatus()
            'Me.LoadRadComboBoxReviewWorkflow()
            'Me.LoadRadComboBoxReviewers()


            If Me.ConceptShareReviewID > 0 Then

                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ClearActiveFlag").Visible = True
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ClearActiveFlag").ToolTip = "Clear all active flags"

                Me.LoadReview(True)

            Else

                Me.SetAssigneePanel(Me.IsRouted)

            End If


            'Select Case Me.BaseReviewType
            '    Case AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.Collaborative

            BaseReviewTypeTitle = Me.BaseReviewType.ToString()

            'Me.DivAssignment.Visible = False

            '    Case AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.WorkFlow

            '        BaseReviewTypeTitle = "Workflow"

            'End Select

            Me.RadToolTipManagerMoreInformation.TargetControls.Clear()
            Me.RadToolTipManagerMoreInformation.Enabled = False
            Me.RadToolTipManagerMoreInformation.Visible = False

            If Me.JobNumber > 0 AndAlso Me.JobComponentNumber > 0 Then

                'Me.RadToolTipManagerMoreInformation.TargetControls.Add(RadToolbarAlertDigitalAssetReview.FindItemByValue("RadToolBarButtonMoreInformation").FindControl("ImageMoreInformation").ClientID, True)
                Me.RadToolTipManagerMoreInformation.TargetControls.Add(Me.ImageMoreInformation.ClientID, True)
                Me.RadToolTipManagerMoreInformation.Enabled = True

            End If

            Me.SetAutoApproveRuleReviewStatus()

            Me.DivJobInfo.Visible = False

            Dim HelpRadToolBarButton As RadToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindButtonByCommandName("ZenDeskHelp")

            If HelpRadToolBarButton IsNot Nothing Then

                HelpRadToolBarButton.ToolTip = "Help adding feedback and using the markup/proofing tool"

            End If
            Try

                If Me.CurrentQuerystring.GetValue("opensel") = "0" Then 'reorder

                    Me.OpenSelectWindow(True)

                ElseIf Me.CurrentQuerystring.GetValue("opensel") = "1" Then 'select

                    Me.OpenSelectWindow(False)

                End If
            Catch ex As Exception
            End Try

        Else

            If Me.EventTarget = "DownloadAsset" AndAlso IsNumeric(Me.EventArgument) = True Then

                Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                Dim AssetID As Integer = CType(Me.EventArgument, Integer)

                ConceptShareConnection = Nothing
                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                If ConceptShareConnection IsNot Nothing Then

                    Dim Asset As AdvantageFramework.ConceptShareAPI.Asset

                    Asset = Nothing
                    Asset = AdvantageFramework.ConceptShare.LoadAssetByAssetID(ConceptShareConnection, AssetID)

                    If Asset IsNot Nothing Then

                        Dim FileBytes() As Byte = AdvantageFramework.ConceptShare.DownloadAsset(ConceptShareConnection, AssetID)

                        If FileBytes IsNot Nothing AndAlso FileBytes.Length > 0 Then

                            Dim RealFilename As String = Asset.FileName
                            Dim MimeType As String = String.Empty

                            Try

                                MimeType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(Asset.OriginalExtension)

                            Catch ex As Exception
                                MimeType = String.Empty
                            End Try
                            With HttpContext.Current.Response

                                Try

                                    .Buffer = True
                                    .AddHeader("Content-Disposition", "attachment;filename=""" & RealFilename & """")
                                    .AddHeader("Content-Length", FileBytes.Length)
                                    .ContentType = MimeType
                                    .BinaryWrite(FileBytes)
                                    .End()
                                    .Flush()
                                    .Clear()

                                Catch ex As Exception
                                    .End()
                                    .Clear()
                                End Try

                            End With

                        End If

                    Else

                        Me.ShowMessage("Failed to retrieve asset")

                    End If

                End If

            End If
            If Me.EventArgument.ToLower.Contains("refresh") Then

                Me.Refresh()

            End If

        End If

        Me.LoadAutoCompleteAlertRecipientReviewers()

        If Me.JobNumber > 0 And Me.JobComponentNumber > 0 Then

            Me.MyUnityContextMenu.JobNumber = Me.JobNumber
            Me.MyUnityContextMenu.JobComponentNumber = Me.JobComponentNumber

        End If

        If Me.ConceptShareReviewID > 0 Then

            NewEditTitle = "Edit"

        Else

            NewEditTitle = "New"

        End If

        Me.Page.Title = String.Format("{0} Review", NewEditTitle)

    End Sub
    Private Sub Alert_DigitalAssetReview_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Try

                Me.SelectAsset()

            Catch ex As Exception
            End Try

        End If

        'If CurrentReviewIsReviewMember = 0 Then

        '    Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ProofingTool").Enabled = False
        '    Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ZenDeskHelp").Enabled = False

        'End If

        If Me.ConceptShareReviewID = 0 Then

            'Me.DivTest.Visible = False
            Try

                Me.DivCommentsPanel.Visible = False

            Catch ex As Exception
            End Try

        End If
        If Me.ConceptShareProjectID = 0 Then

            Me.ShowMessage("No project ID")
            Me.CloseThisWindow()

        End If
        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If Me.AlertID > 0 AndAlso Me.ConceptShareReviewID > 0 AndAlso Me.IsClientPortal = False Then

                If Me.ButtonSelectReviewer IsNot Nothing Then

                    Dim qs As New AdvantageFramework.Web.QueryString

                    qs.Page = "Alert_DigitalAssetReview_AddReviewer.aspx"
                    qs.AlertID = Me.AlertID
                    qs.ConceptShareReviewID = Me.ConceptShareReviewID
                    qs.JobNumber = Me.JobNumber
                    qs.JobComponentNumber = Me.JobComponentNumber
                    qs.ConceptShareProjectID = Me.ConceptShareProjectID

                    Me.ButtonSelectReviewer.OnClientClick = Me.HookUpOpenWindow("Add Internal Reviewer", qs.ToString(True))

                End If

            End If

        End If

        Try

            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ProofingTool").Visible = Me.ConceptShareReviewID > 0
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ZenDeskHelp").Enabled = Me.ConceptShareReviewID > 0
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("FeedbackSummary").Visible = Me.ConceptShareReviewID > 0

        Catch ex As Exception
        End Try

        If Me.IsClientPortal = False Then

            Try

                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("UploadAddAsset").Visible = Me.ConceptShareReviewID > 0
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("TimeSeparator").Visible = Me.ConceptShareReviewID > 0
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("AddTime").Visible = Me.ConceptShareReviewID > 0
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("StartStopwatch").Visible = Me.ConceptShareReviewID > 0
                Me.DivExternalReviewers.Visible = Me.ConceptShareReviewID > 0

            Catch ex As Exception
            End Try

            Try

                Me.ButtonReorderReviewers.Visible = Me.RadListViewReviewers.Items.Count > 1

            Catch ex As Exception
            End Try

        Else

            Try

                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("UploadAddAsset").Visible = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Save").Visible = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Clear").Visible = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Cancel").Visible = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("TimeSeparator").Visible = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("AddTime").Visible = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("StartStopwatch").Visible = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Bookmark").Visible = False

                Me.TextBoxReviewName.Enabled = False
                Me.TextBoxInstructions.Enabled = False

                Me.RadComboBoxReviewStatus.Enabled = False
                Me.RadioButtonListAutoApproveRule.Enabled = False
                Me.RadDatePickerDueDate.Enabled = False
                Me.RadTimePickerDueTime.Enabled = False
                Me.RadComboBoxPriority.Enabled = False

                Me.ButtonAddReviewer.Visible = False
                Me.ButtonSelectReviewer.Visible = False
                Me.ButtonReorderReviewers.Visible = False

                Me.DivRadAutoCompleteBoxReviewers.Visible = False
                Me.DivExternalReviewers.Visible = False

                Me.LinkButtonAlertAndEmailAllInternalReviewers.Visible = False
                Me.LinkButtonEmailAllExternalUsers.Visible = False

            Catch ex As Exception
            End Try

        End If

        Try

            Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
            Deep.BuildJavascriptFromQueryString(Me.CurrentQuerystring, WebvantageLink, ClientPortalLink)
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("CpPermaLink").Visible = Deep.ClientPortalVisible


            Dim ProofingToolQS As New AdvantageFramework.Web.QueryString

            ProofingToolQS = CurrentQuerystring
            ProofingToolQS.Page = "DigitalAssetReview_ProofingTool.aspx"

            Deep.BuildJavascriptFromQueryString(ProofingToolQS, ProofingToolWebvantageLink, ProofingToolClientPortalLink)

        Catch ex As Exception
        End Try

        Try

            If Me.IsClientPortal = True Then

                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("WvPermaLink").Visible = False
                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("CpPermaLink").Visible = False

            End If

        Catch ex As Exception
        End Try

        Me.CheckCompleted()

        If String.IsNullOrWhiteSpace(Me.LabelAssetInfoFilename.Text) = True And Me.DivAssetInfo.Visible = True Then

            Me.DivAssetInfo.Visible = False

            If Me.IsPostBack OrElse Me.IsCallback Then

                Me.SelectAssetRow()

            End If

        End If

    End Sub

#End Region

    Private Sub LoadRadioButtonListAutoApproveRule()

        'Me.RadioButtonListAutoApproveRule.Items.Clear()

        'Dim AutoApproveMethods As Generic.Dictionary(Of Long, String)
        'AutoApproveMethods = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.ConceptShareAPI.AutoApproveMethod), True)

        'If AutoApproveMethods IsNot Nothing Then

        '    For Each AutoApproveMethod In AutoApproveMethods

        '        Me.RadioButtonListAutoApproveRule.Items.Add(New ListItem(AutoApproveMethod.Value, AutoApproveMethod.Key))

        '    Next

        '    Try

        '        If Me.RadioButtonListAutoApproveRule.Items IsNot Nothing AndAlso Me.RadioButtonListAutoApproveRule.Items.Count > 1 Then Me.RadioButtonListAutoApproveRule.Items(1).Selected = True

        '    Catch ex As Exception
        '    End Try

        'End If

    End Sub
    Private Sub LoadRadComboBoxReviewType()

        'Me.RadComboBoxReviewType.Items.Clear()

        'Dim ReviewTypes As Generic.Dictionary(Of Long, String)
        'ReviewTypes = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.ConceptShareAPI.ReviewType), True)

        'If ReviewTypes IsNot Nothing Then

        '    For Each ReviewType In ReviewTypes

        '        Me.RadComboBoxReviewType.Items.Add(New RadComboBoxItem(ReviewType.Value, ReviewType.Key))

        '    Next

        'End If

    End Sub
    Private Sub LoadRadComboBoxReviewStatus()

        'Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '    Me.RadComboBoxReviewStatus.Items.Clear()

        '    Me.RadComboBoxReviewStatus.DataSource = AdvantageFramework.ConceptShare.LoadStatus(DataContext, AdvantageFramework.ConceptShareAPI.StatusType.Review)
        '    Me.RadComboBoxReviewStatus.DataTextField = "Name"
        '    Me.RadComboBoxReviewStatus.DataValueField = "Id"
        '    Me.RadComboBoxReviewStatus.DataBind()

        'End Using

        Dim CsSession As New ConceptShareSession(Me._Session)

        Me.RadComboBoxReviewStatus.Items.Clear()

        Me.RadComboBoxReviewStatus.DataSource = CsSession.LoadReviewStatusList()
        Me.RadComboBoxReviewStatus.DataTextField = "Name"
        Me.RadComboBoxReviewStatus.DataValueField = "Id"
        Me.RadComboBoxReviewStatus.DataBind()

    End Sub

    Private Sub LoadAutoCompleteAlertRecipientReviewers()

        'Dim JobInfo As New AdvantageFramework.AlertSystem.Classes.BasicJobInfo(_Session.ConnectionString, Me.JobNumber, Me.JobComponentNumber)

        Me.AutoCompleteAlertRecipientReviewers.IsAssignment = Me.BaseReviewType = AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.WorkFlow
        Me.AutoCompleteAlertRecipientReviewers.AlertId = Me.AlertID
        Me.AutoCompleteAlertRecipientReviewers.OnlyConceptShareUsers = True

        'If JobInfo IsNot Nothing AndAlso JobInfo.HasData = True Then

        '    Me.AutoCompleteAlertRecipientReviewers.ClientCode = JobInfo.ClientCode
        '    Me.AutoCompleteAlertRecipientReviewers.DivisionCode = JobInfo.DivisionCode
        '    Me.AutoCompleteAlertRecipientReviewers.ProductCode = JobInfo.ProductCode
        '    Me.AutoCompleteAlertRecipientReviewers.JobNumber = Me.JobNumber
        '    Me.AutoCompleteAlertRecipientReviewers.JobComponentNumber = Me.JobComponentNumber

        'End If

    End Sub
    Private Sub LoadReview(ByVal Sync As Boolean)

        If Me.ConceptShareReviewID > 0 Then

            Try
                Dim s As String = String.Empty
                Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                Dim AlertSynced As Boolean = False
                Dim CommentsSynced As Boolean = False
                Dim ReviewersSynced As Boolean = False
                Dim SyncImage As Boolean = False
                Dim NewCommentsCount As Integer = 0
                Dim NewRepliesCount As Integer = 0
                Dim AlertUpdated As Boolean = False

                ConceptShareConnection = Nothing

                If Me.IsClientPortal = False Then

                    ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                Else

                    ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                End If

                If ConceptShareConnection IsNot Nothing Then

                    If _ReviewSummary Is Nothing Then _ReviewSummary = AdvantageFramework.ConceptShare.LoadReviewSummary(ConceptShareConnection, Me.ConceptShareReviewID)

                    If _ReviewSummary IsNot Nothing AndAlso _ReviewSummary.Review IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Dim Alert As AdvantageFramework.Database.Entities.Alert

                            Alert = Nothing
                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByConceptShareReviewID(DbContext, Me.ConceptShareReviewID)

                            If Alert IsNot Nothing AndAlso Sync = True Then

                                CommentsSynced = AdvantageFramework.ConceptShare.SyncReviewToAlert(ConceptShareConnection,
                                                                                                   Me.ConceptShareProjectID,
                                                                                                   Me.ConceptShareReviewID,
                                                                                                   Alert.ID,
                                                                                                   NewCommentsCount,
                                                                                                   NewRepliesCount,
                                                                                                   Me._Session, DbContext)

                            End If

                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                            If String.IsNullOrWhiteSpace(_ReviewSummary.Review.Title) = False Then Me.TextBoxReviewName.Text = _ReviewSummary.Review.Title
                            If String.IsNullOrWhiteSpace(_ReviewSummary.Review.Description) = False Then Me.TextBoxInstructions.Text = _ReviewSummary.Review.Description
                            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxReviewType, _ReviewSummary.Review.ReviewType, False)
                            If _ReviewSummary.Review.AutoApproveMethod IsNot Nothing Then Me.RadioButtonListAutoApproveRule.Items.FindByValue(_ReviewSummary.Review.AutoApproveMethod).Selected = True
                            If _ReviewSummary.Review.StatusId IsNot Nothing Then MiscFN.RadComboBoxSetIndex(Me.RadComboBoxReviewStatus, _ReviewSummary.Review.StatusId, False)

                            Try

                                If _ReviewSummary.Review.StatusCode = "COMPLETED" OrElse
                                _ReviewSummary.Review.DateCompleted IsNot Nothing Then

                                    Me.CompletedDate = _ReviewSummary.Review.DateCompleted
                                    Me.Completed = True

                                End If

                            Catch ex As Exception
                            End Try

                            Me.SetAutoApproveRuleReviewStatus()

                            If _ReviewSummary.Review.DueDate IsNot Nothing Then

                                Me.RadDatePickerDueDate.SelectedDate = _ReviewSummary.Review.DueDate

                            End If

                            Dim ReviewItems As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewItem)
                            ReviewItems = AdvantageFramework.ConceptShare.LoadReviewItemsByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

                            If ReviewItems IsNot Nothing Then

                                Dim LastReviewItem As AdvantageFramework.ConceptShareAPI.ReviewItem

                                Try

                                    LastReviewItem = (From Entity In ReviewItems
                                                      Order By Entity.Id Ascending
                                                      Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    LastReviewItem = Nothing
                                End Try
                                If LastReviewItem IsNot Nothing Then

                                    LastAssetID = LastReviewItem.AssetId
                                    Me.SelectedAssetID = LastAssetID

                                End If

                            End If

                            If Alert IsNot Nothing Then

                                Me.AlertID = Alert.ID

                                If Alert.PriorityLevel Is Nothing Then Alert.PriorityLevel = 3
                                Me.RadComboBoxPriority.FindItemByValue(Alert.PriorityLevel).Selected = True

                                If Alert.DueDate IsNot Nothing AndAlso IsDate(Alert.DueDate) Then

                                    Me.RadDatePickerDueDate.SelectedDate = Alert.DueDate

                                Else

                                    Me.RadDatePickerDueDate.SelectedDate = Nothing

                                End If
                                Try

                                    If String.IsNullOrWhiteSpace(Alert.TimeDue) = False Then

                                        If Me.RadDatePickerDueDate.SelectedDate.HasValue Then

                                            Me.RadTimePickerDueTime.SelectedDate = CDate(CDate(Me.RadDatePickerDueDate.SelectedDate).ToShortDateString & " " & Alert.TimeDue)

                                        Else

                                            Me.RadTimePickerDueTime.SelectedDate = CDate(Today.Date.ToShortDateString & " " & Alert.TimeDue)

                                        End If

                                    End If

                                Catch ex As Exception
                                End Try
                                Try

                                    If Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Alert.AlertAssignmentTemplateID > 0 AndAlso
                                        Alert.AlertStateID IsNot Nothing AndAlso Alert.AlertStateID > 0 Then

                                        Me.IsRouted = True

                                    Else

                                        Me.IsRouted = False

                                    End If

                                Catch ex As Exception
                                End Try

                                Me.AutoCompleteAlertRecipientReviewers.AlertId = Me.AlertID
                                Me.AutoCompleteAlertRecipientReviewers.OnlyConceptShareUsers = True
                                Me.AutoCompleteAlertRecipientReviewers.LoadData()

                                Dim ViewerIsNotReviewer As Boolean = False
                                If Me.IsRouted = True Then

                                    Me.BaseReviewType = AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.WorkFlow

                                    Me.LoadRadComboBoxReviewWorkflow(DbContext)

                                    If Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Me.RadComboBoxReviewWorkflow IsNot Nothing Then

                                        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxReviewWorkflow, Alert.AlertAssignmentTemplateID, False)

                                    End If

                                    Me.RadComboBoxReviewWorkflow.Enabled = False

                                    Me.LoadRadListBoxState(Alert.AlertAssignmentTemplateID)

                                    Try

                                        For Each Item As RadListBoxItem In Me.RadListBoxState.Items

                                            If Item.Value = Alert.AlertStateID Then

                                                Item.Selected = True
                                                Exit For

                                            Else

                                                Item.Enabled = False

                                            End If

                                        Next

                                    Catch ex As Exception
                                    End Try

                                    Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

                                    AlertRecipients = AdvantageFramework.AlertSystem.LoadAlertRecipients(DbContext, Alert.ID)

                                    If AlertRecipients IsNot Nothing AndAlso AlertRecipients.Count > 0 Then

                                        Dim SelectedEntry As AutoCompleteBoxEntry = Nothing

                                        Me.RadAutoCompleteBoxAssignTo.Entries.Clear()

                                        For Each Recipient As AdvantageFramework.DTO.Desktop.AlertRecipient In AlertRecipients

                                            If Recipient.IsCurrentAssignee = True Then

                                                SelectedEntry = Nothing
                                                SelectedEntry = New AutoCompleteBoxEntry

                                                SelectedEntry.Value = Recipient.EmployeeCode
                                                SelectedEntry.Text = Recipient.Name

                                                If Recipient.CompletedDismissed = True Then

                                                    'SelectedEntry.CssClass = "completed"
                                                    SelectedEntry.Text = Recipient.Name & "#COMPLETED#"

                                                Else

                                                    SelectedEntry.Text = Recipient.Name

                                                End If

                                                Me.RadAutoCompleteBoxAssignTo.Entries.Add(SelectedEntry)

                                            End If

                                        Next

                                        Me.RadAutoCompleteBoxAssignTo.Enabled = True

                                    End If

                                End If
                                'If Sync = True Then

                                '    CommentsSynced = AdvantageFramework.ConceptShare.SyncReviewToAlert(ConceptShareConnection,
                                '                                                                       Me.ConceptShareProjectID,
                                '                                                                       Me.ConceptShareReviewID,
                                '                                                                       Alert.ID,
                                '                                                                       NewCommentsCount,
                                '                                                                       NewRepliesCount,
                                '                                                                       Me._Session, DbContext)

                                'End If

                                Me.CheckReadStatus(DbContext)

                            Else

                                'Create alert...should never jump here...but just in case
                                Dim Employee As AdvantageFramework.Database.Views.Employee

                                Employee = Nothing
                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.EmployeeCode)

                                If Employee IsNot Nothing Then

                                    Dim NewAlert As AdvantageFramework.Database.Entities.Alert

                                    NewAlert = Me.AddAlert(DbContext, Employee, _ReviewSummary.Review, _ReviewSummary.ReviewerCount)

                                    If NewAlert IsNot Nothing Then

                                        Me.AlertID = NewAlert.ID

                                        If _ReviewSummary.BaseImage IsNot Nothing AndAlso _ReviewSummary.BaseImage.Length > 0 Then

                                            NewAlert.ConceptShareAssetImage = _ReviewSummary.BaseImage

                                            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, NewAlert)

                                        End If

                                    End If

                                End If

                            End If

                            SetRoutedInfo(False)

                        End Using


                    Else

                        If String.IsNullOrWhiteSpace(s) = False Then

                            Me.ShowMessage(s)

                        End If

                    End If

                    If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                        If Me.IsRouted = True Then

                            Me.LoadReviewers(False, True)

                        End If

                    End If

                End If

            Catch ex As Exception
                Me.ShowMessage("Something went wrong!")
            End Try

        End If

    End Sub
    Private Sub SetRoutedInfo(ByVal LoadSetting As Boolean)

        Dim Routed As RadToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Routed")

        If LoadSetting = True Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.IsRouted = ConceptShareSession.GetUserReviewRoutedSetting(DbContext)

            End Using

        End If

        DivAssignment.Visible = Me.IsRouted
        NonRoutedReviewersDiv.Visible = Not Me.IsRouted

        If Me.IsRouted = True Then

            Me.DivAssignment.Visible = True

            If Routed IsNot Nothing Then

                Routed.Checked = True
                Routed.Enabled = False

            End If

        Else

            Me.DivAssignment.Visible = False

            If Routed IsNot Nothing Then

                Routed.Checked = False
                Routed.Enabled = False

            End If

        End If

    End Sub
    Private Sub LoadEmailLog()

        Me.ListViewEmailLog.Items.Clear()

        If Me.CheckBoxEmailLog.Checked = False Then

            Me.ListViewEmailLog.Visible = False

        Else


            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim Comments As Generic.List(Of AdvantageFramework.Database.Entities.AlertComment)

                Comments = Nothing
                Comments = (From Entity In DbContext.AlertComments
                            Where Entity.AlertID = Me.AlertID And Entity.ConceptShareReviewID Is Nothing And Entity.Comment.StartsWith("Sent email")
                            Select Entity).ToList

                If Comments IsNot Nothing Then

                    Me.ListViewEmailLog.DataSource = Comments
                    Me.ListViewEmailLog.DataBind()
                    Me.ListViewEmailLog.Visible = True

                End If

            End Using

        End If

    End Sub
    Private Sub CheckCompleted()

        If Me.Completed = True Then

            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("UploadAddAsset").Enabled = False
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("ClearActiveFlag").Enabled = False
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Save").Enabled = False
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Clear").Enabled = False
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Cancel").Enabled = False
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Dismiss").Enabled = False
            Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Routed").Enabled = False

            Me.TextBoxReviewName.Enabled = False
            Me.TextBoxInstructions.Enabled = False
            Me.RadioButtonListAutoApproveRule.Enabled = False
            Me.RadComboBoxReviewType.Enabled = False
            Me.RadComboBoxReviewStatus.Enabled = False
            Me.RadComboBoxPriority.Enabled = False
            Me.RadDatePickerDueDate.Enabled = False
            Me.RadTimePickerDueTime.Enabled = False

            Me.RadComboBoxReviewWorkflow.Enabled = False
            Me.RadListBoxState.Enabled = False
            Me.RadAutoCompleteBoxAssignTo.Enabled = False
            Me.RadAutoCompleteBoxExternalReviewers.Enabled = False

            Me.ButtonAddReviewer.Enabled = False
            Me.ButtonReorderReviewers.Enabled = False
            Me.ButtonSaveExternalReviewers.Enabled = False
            Me.ButtonSelectExternalReviewer.Enabled = False
            Me.ButtonSelectReviewer.Enabled = False


            If Me.LabelCompleted IsNot Nothing Then Me.LabelCompleted.Visible = True

            If Me.CompletedDate IsNot Nothing AndAlso Me.LabelApproved IsNot Nothing Then

                Me.LabelApproved.Text = Me.CompletedDate
                Me.LabelApproved.Visible = True

            End If

        End If

    End Sub
    Private Sub CheckReadStatus(ByRef DbContext As AdvantageFramework.Database.DbContext)

        Dim ViewerIsNotReviewer As Boolean = False
        Dim DismissToolBarButton As RadToolBarButton

        DismissToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Dismiss")

        If Me.AlertID > 0 AndAlso DismissToolBarButton IsNot Nothing Then

            If Me.IsClientPortal = False Then

                Dim DismissedRecipient As AdvantageFramework.Database.Entities.AlertRecipientDismissed

                DismissedRecipient = Nothing
                DismissedRecipient = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertIDAndEmployeeCode(DbContext, Me.AlertID, Me.EmployeeCode)

                If DismissedRecipient IsNot Nothing Then

                    Me.IsDismissed = True

                Else

                    Me.IsDismissed = False

                    Try

                        Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient

                        Recipient = Nothing
                        Recipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, Me.AlertID, Me.EmployeeCode)

                        If Recipient IsNot Nothing Then

                            If Recipient.HasBeenRead Is Nothing OrElse Recipient.HasBeenRead = 0 Then

                                Recipient.HasBeenRead = 1

                                If AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, Recipient) = True Then

                                    Me.RefreshAlertWindows(False)

                                End If

                            End If

                        Else

                            ViewerIsNotReviewer = True

                        End If

                    Catch ex As Exception
                    End Try

                End If

            Else

                Dim DismissedRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed

                DismissedRecipient = Nothing
                DismissedRecipient = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertIDAndContactID(DbContext, Me.AlertID, HttpContext.Current.Session("UserID"))

                If DismissedRecipient IsNot Nothing Then

                    Me.IsDismissed = True

                Else

                    Me.IsDismissed = False

                    Try

                        Dim Recipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

                        Recipient = Nothing
                        Recipient = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertIDAndContactID(DbContext, Me.AlertID, HttpContext.Current.Session("UserID"))

                        If Recipient IsNot Nothing Then

                            If Recipient.HasBeenRead Is Nothing OrElse Recipient.HasBeenRead = 0 Then

                                Recipient.HasBeenRead = 1

                                If AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Update(DbContext, Recipient) = True Then

                                    Me.RefreshAlertWindows(False)

                                End If

                            End If

                        Else

                            ViewerIsNotReviewer = True

                        End If

                    Catch ex As Exception
                    End Try

                End If

            End If

            If ViewerIsNotReviewer = True Then

                DismissToolBarButton.Visible = False

            Else

                If DismissToolBarButton IsNot Nothing Then

                    If Me.IsDismissed = True Then

                        DismissToolBarButton.Text = "Un-dismiss"
                        DismissToolBarButton.ToolTip = "Un-dismiss the Review"

                    Else

                        DismissToolBarButton.Text = "Dismiss"
                        DismissToolBarButton.ToolTip = "Dismiss the Review"

                    End If

                End If

            End If

        End If

    End Sub
    Private Function CheckForExternalUsers(ByVal SendEmailToAllExternalUsers As Boolean) As Boolean

        Dim HasExternalUser As Boolean = False
        Dim NewExternalUserAdded As Boolean = False
        Dim InternalReviewerAddedAsExternalReviewer As Boolean = False

        ExternalReviewers = New Generic.List(Of AdvantageFramework.ConceptShareAPI.ExternalReviewer)

        If Me.RadAutoCompleteBoxExternalReviewers.Entries.Count > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            If ConceptShareConnection IsNot Nothing Then

                Dim EmailAddress As String = String.Empty
                Dim FirstName As String = String.Empty
                Dim LastName As String = String.Empty
                Dim ExternalReviewer As AdvantageFramework.ConceptShareAPI.ExternalReviewer
                Dim NewExternalReviewer As AdvantageFramework.ConceptShareAPI.ReviewMember
                Dim URL As String = String.Empty
                Dim Employee As AdvantageFramework.Database.Views.Employee
                Dim InternalEmployeeCodesAdded As New Generic.List(Of String)
                Dim InternalClientContactIdsAdded As New Generic.List(Of Integer)
                Dim NewlyAddedExternalReviewers As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim LegacyAlert As New Alert
                    Dim LegacyAlertLoaded As Boolean = False

                    LegacyAlertLoaded = LegacyAlert.LoadByPrimaryKey(Me.AlertID)

                    Try

                        For Each Entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.RadAutoCompleteBoxExternalReviewers.Entries

                            If Entry.Text.Contains(":") OrElse Entry.Text.Contains("@") Then

                                Dim ar As String()

                                ar = Entry.Text.Split(":")

                                If ar IsNot Nothing AndAlso ar.Length = 2 Then

                                    AdvantageFramework.ConceptShare.ParseFirstAndLastName(ar(0), FirstName, LastName)
                                    EmailAddress = ar(1)

                                End If

                            Else

                                Dim ar As String()

                                ar = Entry.Text.Split(" ")

                                FirstName = ar(0)
                                LastName = ar(ar.Length - 1)
                                EmailAddress = Entry.Value

                            End If

                            EmailAddress = EmailAddress.Trim
                            FirstName = FirstName.Trim
                            LastName = LastName.Trim

                            If AdvantageFramework.StringUtilities.IsValidEmailAddress(EmailAddress) = True Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByConceptShareEmployeeEmail(DbContext, EmailAddress)

                                If Employee Is Nothing Then

                                    Dim AddedClientPortalCSUser As Boolean = False
                                    Try

                                        Using SecurityContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

                                            ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadConceptShareUserByEmailAddress(SecurityContext, EmailAddress)

                                            If ClientPortalUser IsNot Nothing Then

                                                If AdvantageFramework.ConceptShare.AddUpdateReviewMember(ConceptShareConnection,
                                                                                                      Me.ConceptShareReviewID, ClientPortalUser.ConceptShareUserID) IsNot Nothing Then

                                                    AddedClientPortalCSUser = True

                                                    If LegacyAlert.LoadByPrimaryKey(Me.AlertID) = True Then

                                                        LegacyAlert.AddAlertRecipientCC(ClientPortalUser.ClientContactID)
                                                        InternalReviewerAddedAsExternalReviewer = True

                                                    End If

                                                End If

                                            End If

                                        End Using

                                    Catch ex As Exception
                                        AddedClientPortalCSUser = False
                                    End Try

                                    If AddedClientPortalCSUser = False Then

                                        Dim ErrorMessage As String = String.Empty

                                        If Me.ExternalReviewers Is Nothing Then Me.ExternalReviewers = New Generic.List(Of AdvantageFramework.ConceptShareAPI.ExternalReviewer)

                                        ExternalReviewer = New AdvantageFramework.ConceptShareAPI.ExternalReviewer

                                        ExternalReviewer.txtEmail = EmailAddress
                                        ExternalReviewer.txtFirstName = FirstName
                                        ExternalReviewer.txtEmail = EmailAddress

                                        Me.ExternalReviewers.Add(ExternalReviewer)

                                        NewExternalReviewer = AdvantageFramework.ConceptShare.AddUpdateExternalReviewer(ConceptShareConnection, Me.ConceptShareReviewID,
                                                                                                                        EmailAddress, FirstName, LastName,
                                                                                                                        ErrorMessage)

                                        If NewExternalReviewer IsNot Nothing Then

                                            HasExternalUser = True
                                            NewExternalUserAdded = True

                                            Dim Options As New AdvantageFramework.ConceptShareAPI.ResourceUrlOptions

                                            Options.PreAuthenticateUser = True
                                            Options.ProjectId = Me.ConceptShareProjectID
                                            Options.ReferenceType = AdvantageFramework.ConceptShareAPI.ReferenceType.Review
                                            Options.ReferenceId = Me.ConceptShareReviewID
                                            Options.UrlType = AdvantageFramework.ConceptShareAPI.ResourceUrlType.Reference
                                            Options.SecureUrl = True

                                            'URL = ConceptShareConnection.APIServiceClient.GetResourceUrlForUser(ConceptShareConnection.APIContext, NewExternalReviewer.Id, Options)
                                            URL = ConceptShareConnection.APIServiceClient.GetResourceUrlForUser(ConceptShareConnection.APIContext, NewExternalReviewer.ReferenceId, Options)

                                            NewlyAddedExternalReviewers.Add(NewExternalReviewer)

                                        Else

                                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                Me.ShowMessage(ErrorMessage)

                                            End If

                                        End If

                                    End If

                                Else

                                    If LegacyAlert.LoadByPrimaryKey(Me.AlertID) = True Then

                                        LegacyAlert.AddAlertRecipient(EmployeeCode, True)

                                    End If

                                    AdvantageFramework.ConceptShare.AddUpdateReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, Employee.ConceptShareUserID)
                                    InternalEmployeeCodesAdded.Add(Employee.Code)
                                    InternalReviewerAddedAsExternalReviewer = True

                                End If

                                EmailAddress = String.Empty
                                FirstName = String.Empty
                                LastName = String.Empty
                                URL = String.Empty
                                ExternalReviewer = Nothing
                                NewExternalReviewer = Nothing
                                Employee = Nothing

                            End If

                        Next

                        If NewlyAddedExternalReviewers IsNot Nothing AndAlso NewlyAddedExternalReviewers.Count > 0 Then

                            For Each Noob As AdvantageFramework.ConceptShareAPI.ReviewMember In NewlyAddedExternalReviewers

                                Me.AddUpdateEmailExternalReviewer(DbContext, Noob, SendEmailToAllExternalUsers)

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                End Using

            End If

            Me.RadAutoCompleteBoxExternalReviewers.Entries.Clear()

        End If

        If HasExternalUser = True Then


        End If

        Me.LoadReviewers(InternalReviewerAddedAsExternalReviewer, NewExternalUserAdded)

        Return HasExternalUser

    End Function

    Private Function AddReview() As Boolean

        'If Me.AutoCompleteAlertRecipientReviewers.HasEntries = False Then

        '    Me.ShowMessage("Please select a reviewer")
        '    Return False

        'End If

        Dim ErrorMessage As String = String.Empty
        Dim ReviewAdded As Boolean = False

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        ConceptShareConnection = Nothing
        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        If ConceptShareConnection IsNot Nothing Then

            Dim EmployeeCodesAdded As New Generic.List(Of String)
            Dim ClientContactIdsAdded As New Generic.List(Of Integer)

            'Save review to CS
            Dim Review As New AdvantageFramework.ConceptShareAPI.Review
            Dim Tags As New Generic.List(Of String)
            Dim Reviewers As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
            Dim Items As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewItem)
            Dim ReviewerCount As Integer = 0
            Dim ExternalReviewers As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ExternalReviewer)

            Review.Id = 0
            Review.ProjectId = Me.ConceptShareProjectID
            Review.ReferenceId = Me.ConceptShareProjectID
            Review.ReferenceType = AdvantageFramework.ConceptShareAPI.ReferenceType.Project
            Review.Title = Me.TextBoxReviewName.Text.Trim
            Review.Description = Me.TextBoxInstructions.Text.Trim
            Review.Code = "WV_REVIEW" & AdvantageFramework.StringUtilities.GUID_Date ' Review.Title.ToUpper.Replace(" ", "_")

            If Me.RadioButtonListAutoApproveRule.SelectedItem IsNot Nothing Then Review.AutoApproveMethod = Me.RadioButtonListAutoApproveRule.SelectedItem.Value
            If Me.RadComboBoxReviewType.SelectedItem IsNot Nothing Then Review.ReviewType = Me.RadComboBoxReviewType.SelectedItem.Value
            If Me.RadComboBoxReviewStatus.SelectedItem IsNot Nothing Then Review.StatusId = Me.RadComboBoxReviewStatus.SelectedItem.Value
            'If Me.RadioButtonListPriority.SelectedItem IsNot Nothing AndAlso Me.RadioButtonListPriority.SelectedItem.Value = "1" Then

            '    Review.IsHighPriority = True

            'Else

            Review.IsHighPriority = False

            'End If
            If Me.RadDatePickerDueDate.SelectedDate.HasValue Then Review.DueDate = Me.RadDatePickerDueDate.SelectedDate

            Review.AllowDeferralResponses = True
            Review.AllowFeedback = True
            Review.AllowMembersToView = True
            Review.AllowNotes = True
            Review.ElectronicSignatureRequired = False

            Reviewers = Me.SetReviewMembers(EmployeeCodesAdded, ClientContactIdsAdded)

            If Reviewers IsNot Nothing Then

                ReviewerCount = Reviewers.Count

            End If

            Tags = AdvantageFramework.ConceptShare.LoadJobInfoForTagList(Me._Session, Me.JobNumber, Me.JobComponentNumber)

            'save review
            Review = AdvantageFramework.ConceptShare.AddReview(ConceptShareConnection, Review, Tags, Items, Reviewers, ExternalReviewers, ErrorMessage)

            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                Me.ShowMessage(ErrorMessage)
                Exit Function

            End If
            If Review IsNot Nothing AndAlso Review.Id > 0 Then

                ReviewAdded = True

                Me.ConceptShareReviewID = Review.Id

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        Dim Employee As AdvantageFramework.Database.Views.Employee

                        Employee = Nothing
                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.EmployeeCode)

                        If Employee IsNot Nothing Then

                            Dim Alert As AdvantageFramework.Database.Entities.Alert

                            Alert = Nothing
                            Alert = Me.AddAlert(DbContext, Employee, Review, ReviewerCount)

                            If Alert IsNot Nothing Then

                                Me.AlertID = Alert.ID
                                'AdvantageFramework.ConceptShare.SyncReviewReviewersToAlertRecipients(DbContext, DataContext, ConceptShareConnection,
                                '                                                                     Me.ConceptShareProjectID, Me.ConceptShareReviewID, Alert.ID)

                                Me.AddAlertRecipients()
                                'Me.AlertRecipients(DbContext, Review, False, True, True, "", True)

                            End If

                        End If

                    End Using
                End Using

                Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("UploadAddAsset").Enabled = True

            End If

        End If

        If ReviewAdded = True Then

            Me.RefreshPMD()
            Me.RefreshDashboardReviews()

        End If

        Return ReviewAdded

    End Function
    Private Sub RefreshPMD()

        'Dim qs As New AdvantageFramework.Web.QueryString()

        'qs.Page = "Content.aspx"
        'qs.JobNumber = Me.JobNumber
        'qs.JobComponentNbr = Me.JobComponentNumber

        'qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.DigitalAssetReviews

        'Me.RefreshCaller(qs.ToString(True), False, True, False)

    End Sub
    Private Function UpdateReview() As Boolean

        Dim ErrorMessage As String = String.Empty
        Dim ReviewUpdated As Boolean = False
        Dim HasChange As Boolean = False
        Dim HasReviewerChange As Boolean = False

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        ConceptShareConnection = Nothing
        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        If ConceptShareConnection IsNot Nothing Then

            'Save review to CS
            Dim EmployeeCodesAdded As New Generic.List(Of String)
            Dim ClientContactIdsAdded As New Generic.List(Of Integer)
            Dim Review As AdvantageFramework.ConceptShareAPI.Review
            Dim Tags As New Generic.List(Of String)
            Dim Reviewers As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
            Dim Items As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewItem)

            Review = AdvantageFramework.ConceptShare.LoadReviewByReviewID(ConceptShareConnection, Me.ConceptShareReviewID, ErrorMessage)

            If Review IsNot Nothing Then

                If Review.Title <> Me.TextBoxReviewName.Text.Trim Then

                    Review.Title = Me.TextBoxReviewName.Text.Trim
                    HasChange = True

                End If
                If Review.Description <> Me.TextBoxInstructions.Text.Trim Then

                    Review.Description = Me.TextBoxInstructions.Text.Trim
                    HasChange = True

                End If
                If Me.RadioButtonListAutoApproveRule.SelectedItem IsNot Nothing AndAlso Review.AutoApproveMethod <> Me.RadioButtonListAutoApproveRule.SelectedItem.Value Then

                    Review.AutoApproveMethod = Me.RadioButtonListAutoApproveRule.SelectedItem.Value
                    HasChange = True

                End If
                If Me.RadComboBoxReviewType.SelectedItem IsNot Nothing AndAlso Review.ReviewType <> Me.RadComboBoxReviewType.SelectedItem.Value Then

                    Review.ReviewType = Me.RadComboBoxReviewType.SelectedItem.Value
                    HasChange = True

                End If
                If Me.RadComboBoxReviewStatus.SelectedItem IsNot Nothing AndAlso Review.StatusId <> Me.RadComboBoxReviewStatus.SelectedItem.Value Then

                    Review.StatusId = Me.RadComboBoxReviewStatus.SelectedItem.Value
                    HasChange = True

                End If
                If Me.RadDatePickerDueDate.SelectedDate.HasValue AndAlso Review.DueDate Is Nothing OrElse
                    (Review.DueDate IsNot Nothing AndAlso Review.DueDate <> Me.RadDatePickerDueDate.SelectedDate) Then

                    Review.DueDate = Me.RadDatePickerDueDate.SelectedDate
                    HasChange = True

                ElseIf Me.RadDatePickerDueDate.SelectedDate.HasValue = False Then

                    Review.DueDate = Nothing
                    HasChange = True

                End If

                Reviewers = Me.SetReviewMembers(EmployeeCodesAdded, ClientContactIdsAdded)

                If EmployeeCodesAdded IsNot Nothing AndAlso EmployeeCodesAdded.Count > 0 Then

                    HasChange = True
                    HasReviewerChange = True

                End If
                If ClientContactIdsAdded IsNot Nothing AndAlso ClientContactIdsAdded.Count > 0 Then

                    HasChange = True
                    HasReviewerChange = True

                End If

            End If

            If HasChange = False Then

                HasChange = Me.CheckForExternalUsers(False)

            Else

                Me.CheckForExternalUsers(False)

            End If

            If HasChange = True Then

                Tags = AdvantageFramework.ConceptShare.LoadJobInfoForTagList(Me._Session, Me.JobNumber, Me.JobComponentNumber)

                Review = AdvantageFramework.ConceptShare.UpdateReview(ConceptShareConnection, Review, Tags, Items, Reviewers, ExternalReviewers, ErrorMessage)

                If Review IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                        ReviewUpdated = True

                    Else

                        Me.ShowMessage(ErrorMessage)

                    End If

                End If

            End If

            Dim ReviewerCount As Integer = 0

            If _ReviewSummary Is Nothing Then _ReviewSummary = AdvantageFramework.ConceptShare.LoadReviewSummary(ConceptShareConnection, Review.Id)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim Employee As AdvantageFramework.Database.Views.Employee

                Employee = Nothing
                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.EmployeeCode)

                If Employee IsNot Nothing Then

                    'add/update alert
                    Dim Alert As AdvantageFramework.Database.Entities.Alert

                    Alert = Nothing
                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByConceptShareReviewID(DbContext, Me.ConceptShareReviewID)

                    If Alert IsNot Nothing Then

                        Dim AlertHasChange As Boolean = False

                        Me.AlertID = Alert.ID

                        If Alert.Subject <> Me.TextBoxReviewName.Text.Trim Then

                            Alert.Subject = Me.TextBoxReviewName.Text.Trim
                            AlertHasChange = True

                        End If
                        If Alert.Body <> Me.TextBoxInstructions.Text.Trim Then

                            Alert.Body = Me.TextBoxInstructions.Text.Trim
                            AlertHasChange = True

                        End If
                        If Alert.EmailBody.Trim <> Me.TextBoxInstructions.Text.Trim Then

                            Alert.EmailBody = Me.TextBoxInstructions.Text.Trim.Replace(Environment.NewLine, "<br />")
                            AlertHasChange = True

                        End If

                        Try


                            If (Alert.DueDate Is Nothing AndAlso Me.RadDatePickerDueDate.SelectedDate.HasValue) OrElse
                                (Alert.DueDate IsNot Nothing AndAlso Alert.DueDate <> Me.RadDatePickerDueDate.SelectedDate) OrElse
                                (Alert.DueDate IsNot Nothing AndAlso Me.RadDatePickerDueDate.SelectedDate.HasValue = False) Then

                                If Me.RadDatePickerDueDate.SelectedDate.HasValue = True AndAlso Me.RadTimePickerDueTime.SelectedDate.HasValue = True Then

                                    Alert.DueDate = CDate(CDate(Me.RadDatePickerDueDate.SelectedDate).ToShortDateString & " " & CType(Me.RadTimePickerDueTime.SelectedDate, DateTime).ToString("HH:mm"))

                                Else

                                    Alert.DueDate = Me.RadDatePickerDueDate.SelectedDate

                                End If

                                AlertHasChange = True

                            End If

                        Catch ex As Exception
                        End Try

                        Try

                            If Me.RadDatePickerDueDate.SelectedDate.HasValue = False Then

                                Me.RadTimePickerDueTime.SelectedDate = Nothing

                            End If

                            Dim TimeString As String = String.Empty

                            If Me.RadTimePickerDueTime.SelectedDate.HasValue Then

                                TimeString = CType(Me.RadTimePickerDueTime.SelectedDate, DateTime).ToString("HH:mm")

                            End If

                            If String.IsNullOrWhiteSpace(TimeString) = False AndAlso String.IsNullOrWhiteSpace(Alert.TimeDue) = True OrElse
                                (String.IsNullOrWhiteSpace(Alert.TimeDue) = False AndAlso Alert.TimeDue <> TimeString) Then

                                Alert.TimeDue = TimeString
                                AlertHasChange = True

                            ElseIf String.IsNullOrWhiteSpace(TimeString) = True AndAlso String.IsNullOrWhiteSpace(Alert.TimeDue) = False Then

                                Alert.TimeDue = String.Empty
                                AlertHasChange = True

                            End If


                        Catch ex As Exception
                        End Try

                        If Alert.PriorityLevel <> Me.RadComboBoxPriority.SelectedValue Then

                            Alert.PriorityLevel = Me.RadComboBoxPriority.SelectedValue
                            AlertHasChange = True

                        End If

                        If Me.RadioButtonListAutoApproveRule.SelectedItem IsNot Nothing Then

                            If Alert.ConceptShareAutoApproveMethodID <> Me.RadioButtonListAutoApproveRule.SelectedItem.Value Then

                                Alert.ConceptShareAutoApproveMethodID = Me.RadioButtonListAutoApproveRule.SelectedItem.Value
                                AlertHasChange = True

                            End If

                        End If
                        Try

                            If Alert.AlertAssignmentTemplateID IsNot Nothing Then

                                If Alert.AlertStateID IsNot Nothing Then

                                    If Me.RadListBoxState.SelectedItem IsNot Nothing AndAlso IsNumeric(Me.RadListBoxState.SelectedItem.Value) = True Then

                                        If Alert.AlertStateID <> CType(Me.RadListBoxState.SelectedItem.Value, Integer) Then

                                            Alert.AlertStateID = CType(Me.RadListBoxState.SelectedItem.Value, Integer)
                                            AlertHasChange = True

                                        End If

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try
                        'If ReviewSummary IsNot Nothing Then

                        '    If Alert.ConceptShareNumberOfReviewers = ReviewSummary.ReviewerCount Then

                        '        Alert.ConceptShareNumberOfReviewers = ReviewSummary.ReviewerCount
                        '        AlertHasChange = True

                        '    End If
                        '    If Alert.ConceptShareNumberOfApprovedReviewers = ReviewSummary.ApprovedReviewerCount Then

                        '        Alert.ConceptShareNumberOfApprovedReviewers = ReviewSummary.ApprovedReviewerCount
                        '        AlertHasChange = True

                        '    End If
                        '    If Alert.ConceptShareNumberOfCompletedReviewers = ReviewSummary.CompletedReviewerCount Then

                        '        Alert.ConceptShareNumberOfCompletedReviewers = ReviewSummary.CompletedReviewerCount
                        '        AlertHasChange = True

                        '    End If
                        '    If Alert.ConceptShareNumberOfDeferredReviewers = ReviewSummary.DeferredReviewerCount Then

                        '        Alert.ConceptShareNumberOfDeferredReviewers = ReviewSummary.DeferredReviewerCount
                        '        AlertHasChange = True

                        '    End If
                        '    If Alert.ConceptShareNumberOfRejectedReviewers = ReviewSummary.RejectedReviewerCount Then

                        '        Alert.ConceptShareNumberOfRejectedReviewers = ReviewSummary.RejectedReviewerCount
                        '        AlertHasChange = True

                        '    End If

                        'End If

                        If AlertHasChange = True Then

                            Alert.LastUpdated = DateTime.Now
                            Alert.AlertCategoryID = 67 'Review updated
                            Alert.LastUpdatedUserCode = _Session.UserCode
                            Alert.LastUpdatedFullName = Employee.FirstName & " " & Employee.LastName

                            If AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert) = True Then


                            End If

                        Else

                            If HasReviewerChange = True Then



                            End If

                        End If

                        Me.AddAlertRecipients()

                    Else

                        If _ReviewSummary IsNot Nothing Then

                            ReviewerCount = _ReviewSummary.ReviewerCount

                        End If

                        Alert = Me.AddAlert(DbContext, Employee, Review, ReviewerCount)

                        If Alert IsNot Nothing Then

                            Me.AlertID = Alert.ID

                            If _ReviewSummary IsNot Nothing AndAlso _ReviewSummary.BaseImage IsNot Nothing AndAlso _ReviewSummary.BaseImage.Length > 0 Then

                                Alert.ConceptShareAssetImage = _ReviewSummary.BaseImage
                                AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                            End If

                            Me.AddAlertRecipients()

                            'Me.AlertRecipients(Review, False, True, False, "")

                        End If

                    End If

                End If

            End Using


        End If

        If ReviewUpdated = True Then

            Me.RefreshPMD()
            Me.RefreshDashboardReviews()

        End If

        Return ReviewUpdated

    End Function
    Private Function AddUpdateReview(ByVal RedirectOnNew As Boolean) As Boolean

        Dim Success As Boolean = False

        If Me.ConceptShareReviewID = 0 Then

            Success = Me.AddReview()

            'If Success = True AndAlso RedirectOnNew = True Then

            '    Dim qs As New AdvantageFramework.Web.QueryString

            '    qs.Page = "Alert_DigitalAssetReview.aspx"
            '    qs.JobNumber = Me.JobNumber
            '    qs.JobComponentNbr = Me.JobComponentNumber
            '    qs.ConceptShareProjectID = Me.ConceptShareProjectID
            '    qs.ConceptShareReviewID = Me.ConceptShareReviewID

            '    'MiscFN.ResponseRedirect(qs.ToString(True), True)
            '    Me.RefreshCaller(qs.ToString(True), False, True)

            'End If

        Else

            Success = Me.UpdateReview()

        End If

        Return Success

    End Function

    Private Function AddAlert(ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef Employee As AdvantageFramework.Database.Views.Employee,
                              ByRef Review As AdvantageFramework.ConceptShareAPI.Review, ByVal ReviewerCount As Integer) As AdvantageFramework.Database.Entities.Alert

        'Save alert
        Dim NewAlert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim JobInfo As New AdvantageFramework.AlertSystem.Classes.BasicJobInfo(_Session.ConnectionString, Me.JobNumber, Me.JobComponentNumber)
        Dim Routed As RadToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Routed")
        Dim IsRouted As Boolean = False

        If Routed IsNot Nothing Then

            IsRouted = Routed.Checked

        End If

        NewAlert = New AdvantageFramework.Database.Entities.Alert

        NewAlert.Subject = Me.TextBoxReviewName.Text.Trim
        NewAlert.Body = Me.TextBoxInstructions.Text.Trim
        NewAlert.EmailBody = Me.TextBoxInstructions.Text.Trim.Replace(Environment.NewLine, "<br />")
        NewAlert.GeneratedDate = DateTime.Now
        NewAlert.LastUpdated = NewAlert.GeneratedDate

        Try
            If Me.RadDatePickerDueDate.SelectedDate.HasValue Then

                NewAlert.DueDate = Me.RadDatePickerDueDate.SelectedDate

            End If
        Catch ex As Exception
        End Try
        Try
            If Me.RadTimePickerDueTime.SelectedDate.HasValue Then

                NewAlert.TimeDue = CType(Me.RadTimePickerDueTime.SelectedDate, DateTime).ToString("HH:mm")

            End If
        Catch ex As Exception
        End Try

        NewAlert.PriorityLevel = Me.RadComboBoxPriority.SelectedValue
        NewAlert.AlertTypeID = 15 'Digital Asset
        NewAlert.AlertCategoryID = 66 'Digital Asset Review Created
        NewAlert.UserCode = _Session.UserCode
        NewAlert.LastUpdatedUserCode = _Session.UserCode
        NewAlert.LastUpdatedFullName = Employee.FirstName & " " & Employee.LastName
        NewAlert.AlertLevel = "JC"
        NewAlert.IsConceptShareReview = 1
        NewAlert.IsWorkItem = True

        If Me.RadioButtonListAutoApproveRule.SelectedItem IsNot Nothing Then

            NewAlert.ConceptShareAutoApproveMethodID = Me.RadioButtonListAutoApproveRule.SelectedItem.Value

        End If


        NewAlert.ConceptShareProjectID = Me.ConceptShareProjectID
        NewAlert.ConceptShareReviewID = Me.ConceptShareReviewID
        NewAlert.ConceptShareReviewTypeID = CType(Review.ReviewType, Integer)
        NewAlert.ConceptShareReviewStatusID = Review.StatusId
        NewAlert.ConceptShareNumberOfApprovedReviewers = 0
        NewAlert.ConceptShareNumberOfCompletedReviewers = 0
        NewAlert.ConceptShareNumberOfDeferredReviewers = 0
        NewAlert.ConceptShareNumberOfRejectedReviewers = 0
        NewAlert.ConceptShareNumberOfReviewers = ReviewerCount

        If IsRouted = True OrElse Me.BaseReviewType = AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.WorkFlow Then

            NewAlert.AlertAssignmentTemplateID = Me.RadComboBoxReviewWorkflow.SelectedItem.Value
            NewAlert.AlertStateID = Me.RadListBoxState.SelectedItem.Value

        End If
        If JobInfo IsNot Nothing AndAlso JobInfo.HasData = True Then

            NewAlert.ClientCode = JobInfo.ClientCode
            NewAlert.DivisionCode = JobInfo.DivisionCode
            NewAlert.ProductCode = JobInfo.ProductCode
            NewAlert.JobNumber = Me.JobNumber
            NewAlert.JobComponentNumber = Me.JobComponentNumber

        End If
        If IsRouted = True Then

            If String.IsNullOrWhiteSpace(Me.RadComboBoxReviewWorkflow.SelectedValue) = False AndAlso
                IsNumeric(Me.RadComboBoxReviewWorkflow.SelectedValue) = True Then

                NewAlert.AlertAssignmentTemplateID = CType(Me.RadComboBoxReviewWorkflow.SelectedValue, Integer)

                If Me.RadListBoxState.SelectedItem IsNot Nothing AndAlso IsNumeric(Me.RadListBoxState.SelectedItem.Value) = True Then

                    NewAlert.AlertStateID = CType(Me.RadListBoxState.SelectedItem.Value, Integer)

                End If

            End If

        End If
        If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, NewAlert) = True Then

            Me.AlertID = NewAlert.ID

        End If

        Return NewAlert

    End Function
    Private Function AlertRecipients(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                     ByRef Review As AdvantageFramework.ConceptShareAPI.Review, ByVal SendEmail As Boolean,
                                     ByVal IncludeOriginator As Boolean, ByVal IsNew As Boolean,
                                     ByVal CustomSubjectAddendum As String, ByVal MarkAllAsActiveReviewer As Boolean) As Boolean

        If Me.AlertID > 0 Then

            'Undismiss for all internal reviewers:
            Dim Recipients As Generic.List(Of String)
            Dim ClientPortalRecipients As Generic.List(Of Integer)

            Recipients = Nothing
            ClientPortalRecipients = Nothing

            Try

                Recipients = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM ALERT_RCPT WHERE ALERT_ID = {0} UNION SELECT EMP_CODE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};", Me.AlertID)).ToList

            Catch ex As Exception
                Recipients = Nothing
            End Try
            Try

                ClientPortalRecipients = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CDP_CONTACT_ID FROM CP_ALERT_RCPT WHERE ALERT_ID = {0} UNION SELECT CDP_CONTACT_ID FROM CP_ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};", Me.AlertID)).ToList

            Catch ex As Exception
                ClientPortalRecipients = Nothing
            End Try

            If Recipients IsNot Nothing OrElse ClientPortalRecipients IsNot Nothing Then

                Dim a As New cAlerts()
                Try

                    If Recipients IsNot Nothing Then

                        a.UpdateAlertRecipients(Me.AlertID, String.Join(",", Recipients.ToArray()), "", True)

                    End If

                Catch ex As Exception
                End Try
                Try

                    If Recipients IsNot Nothing AndAlso MarkAllAsActiveReviewer = True Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT_RCPT SET CURRENT_NOTIFY = 1 WHERE ALERT_ID = {0};UPDATE ALERT_RCPT_DISMISSED SET CURRENT_NOTIFY = 1 WHERE ALERT_ID = {0};", AlertID))

                    End If

                Catch ex As Exception
                End Try
                Try

                    If ClientPortalRecipients IsNot Nothing Then

                        a.UpdateAlertRecipientsCP(Me.AlertID, String.Join(",", ClientPortalRecipients.ToArray()), "", True)

                    End If

                Catch ex As Exception
                End Try
                Try

                    If ClientPortalRecipients IsNot Nothing AndAlso MarkAllAsActiveReviewer = True Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CP_ALERT_RCPT SET IS_DELETED = 0 WHERE ALERT_ID = {0};UPDATE CP_ALERT_RCPT_DISMISSED SET IS_DELETED = 0 WHERE ALERT_ID = {0};", AlertID))

                    End If

                Catch ex As Exception
                End Try

            End If

            If SendEmail = True Then

                Dim Names As New Generic.List(Of String)
                Me.AddEmailingComment(DbContext, False, Names, True)

                Dim eso As New EmailSessionObject(Me._Session.ConnectionString,
                                              Me._Session.UserCode,
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

                With eso

                    .AlertId = Me.AlertID
                    .Subject = BaseEmailSubject
                    .IsClientPortal = Me.IsClientPortal
                    .IncludeOriginator = IncludeOriginator
                    .SessionID = HttpContext.Current.Session.SessionID.ToString()
                    .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath

                    .Send()

                End With


                Me.CheckForAsyncMessage()

            End If

        End If

    End Function

    'Private Sub AddUpdateReviewers()

    '    If Me.ConceptShareReviewID > 0 Then

    '        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
    '        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

    '        ConceptShareConnection = Nothing
    '        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

    '        If ConceptShareConnection IsNot Nothing Then

    '            Dim ReviewerIDsInAutocomplete As New Generic.List(Of Integer)
    '            Dim ReviewerIDsToAdd As New Generic.List(Of Integer)
    '            Dim ReviewerIDsToRemove As New Generic.List(Of Integer)
    '            Dim CurrentReviewerIDs As New Generic.List(Of Integer)

    '            Dim CurrentReviewers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

    '            CurrentReviewers = Nothing
    '            CurrentReviewers = AdvantageFramework.ConceptShare.LoadReviewMembersByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

    '            CurrentReviewerIDs = (From Entity In AdvantageFramework.ConceptShare.LoadReviewMembersByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)
    '                                  Select Entity.Id).ToList

    '            ''''If Me.RadAutoCompleteBoxReviewers.Entries IsNot Nothing AndAlso Me.RadAutoCompleteBoxReviewers.Entries.Count > 0 Then

    '            ''''    For Each Entry As AutoCompleteBoxEntry In Me.RadAutoCompleteBoxReviewers.Entries

    '            ''''        If IsNumeric(Entry.Value) = True Then

    '            ''''            ReviewerIDsInAutocomplete.Add(Entry.Value)

    '            ''''            If CurrentReviewerIDs IsNot Nothing AndAlso CurrentReviewerIDs.Count > 0 AndAlso CurrentReviewerIDs.Contains(Entry.Value) = False Then

    '            ''''                ReviewerIDsToAdd.Add(Entry.Value)

    '            ''''            End If

    '            ''''        End If

    '            ''''    Next

    '            ''''End If

    '            If ReviewerIDsToAdd IsNot Nothing AndAlso ReviewerIDsToAdd.Count > 0 Then

    '                Dim ReviewMembers As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
    '                Dim ReviewMember As AdvantageFramework.ConceptShareAPI.ReviewMember
    '                For Each ReviewerID As Integer In ReviewerIDsToAdd

    '                    ReviewMember = New AdvantageFramework.ConceptShareAPI.ReviewMember

    '                    ReviewMember.ReferenceId = ReviewerID
    '                    ReviewMember.ReferenceType = CType(AdvantageFramework.ConceptShareAPI.ReferenceType.User, Integer)

    '                    ReviewMembers.Add(ReviewMember)

    '                Next

    '            End If

    '        End If

    '    End If
    'End Sub
    Private Function SetReviewMembers(ByRef NewEmployeeCodes As Generic.List(Of String), ByRef NewClientContactIds As Generic.List(Of Integer)) As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

        Dim ReviewMembers As New Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
        Dim NewConceptShareIds As New Generic.List(Of Integer)
        Dim HasReviewers As Boolean = False

        If Me.IsRouted = False Then

            HasReviewers = Me.AutoCompleteAlertRecipientReviewers.GetListsOfIDsForReview(NewEmployeeCodes, NewConceptShareIds, NewClientContactIds)

        Else

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If Me.RadAutoCompleteBoxAssignTo.Entries IsNot Nothing AndAlso Me.RadAutoCompleteBoxAssignTo.Entries.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each Entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.RadAutoCompleteBoxAssignTo.Entries

                        Employee = Nothing

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Entry.Value)

                        If Employee IsNot Nothing AndAlso Employee.ConceptShareUserID IsNot Nothing Then

                            NewConceptShareIds.Add(Employee.ConceptShareUserID)
                            HasReviewers = True

                        End If

                    Next

                End Using

            End If

        End If
        If HasReviewers AndAlso NewConceptShareIds IsNot Nothing AndAlso NewConceptShareIds.Count > 0 Then

            Dim ReviewMember As AdvantageFramework.ConceptShareAPI.ReviewMember

            For Each ConceptShareID As Integer In NewConceptShareIds

                ReviewMember = New AdvantageFramework.ConceptShareAPI.ReviewMember

                ReviewMember.ReferenceId = ConceptShareID
                ReviewMember.ReferenceType = CType(AdvantageFramework.ConceptShareAPI.ReferenceType.User, Integer)

                ReviewMembers.Add(ReviewMember)

            Next

        End If

        Return ReviewMembers

    End Function
    Private Function AddAlertRecipients() As Boolean

        If Me.AlertID > 0 Then

            Dim EmployeeCodes As New Generic.List(Of String)
            Dim CurrentEmployees As Generic.List(Of String) = Nothing
            Dim RemovedEmployeeCodes As New Generic.List(Of String)
            Dim ConceptShareIds As New Generic.List(Of Integer)
            Dim ClientContactIds As New Generic.List(Of Integer)
            Dim CurrentAlert As New Alert

            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Assignee As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Add As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertID)

                If AlertEntity IsNot Nothing AndAlso CurrentAlert.LoadByPrimaryKey(Me.AlertID) = True Then

                    If Me.IsRouted = True Then

                        For Each Entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.RadAutoCompleteBoxAssignTo.Entries

                            EmployeeCodes.Add(Entry.Value)

                        Next

                        CurrentEmployees = (From Entity In AdvantageFramework.AlertSystem.LoadAlertRecipients(DbContext, Me.AlertID)
                                            Select Entity.EmployeeCode).ToList

                        If CurrentEmployees IsNot Nothing AndAlso CurrentEmployees.Count > 0 Then

                            Dim ConceptShareUserID As Integer = 0 'CType(e.CommandArgument, Integer)
                            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                            Dim CsEmployee As AdvantageFramework.Database.Views.Employee = Nothing

                            ConceptShareConnection = Nothing
                            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                            If ConceptShareConnection IsNot Nothing Then

                                For Each EmpCode As String In CurrentEmployees

                                    If EmployeeCodes.Contains(EmpCode) = False Then

                                        CsEmployee = Nothing
                                        CsEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmpCode)

                                        If CsEmployee IsNot Nothing AndAlso CsEmployee.ConceptShareUserID IsNot Nothing AndAlso CsEmployee.ConceptShareUserID > 0 Then

                                            If AdvantageFramework.ConceptShare.RemoveReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, CsEmployee.ConceptShareUserID) IsNot Nothing Then

                                                AdvantageFramework.AlertSystem.DeleteRecipient(DbContext, Me.AlertID, EmpCode)

                                            End If

                                        End If

                                    End If


                                Next

                            End If

                        End If

                    Else

                        Me.AutoCompleteAlertRecipientReviewers.GetListsOfIDsForReview(EmployeeCodes, ConceptShareIds, ClientContactIds)

                    End If

                    For Each EmployeeCode As String In EmployeeCodes

                        Employee = Nothing
                        Add = False
                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            If Employee.ConceptShareUserID IsNot Nothing Then 'Assignee
                                'Check only for assignee record
                                If AdvantageFramework.AlertSystem.IsEmployeeAnAssignee(DbContext, Me.AlertID, Employee.Code) = False Then

                                    Add = True

                                End If

                            Else 'CC

                                If AdvantageFramework.AlertSystem.IsEmployeeACC(DbContext, Me.AlertID, Employee.Code) = False Then

                                    Add = True

                                End If

                            End If
                            If Add = True Then

                                Assignee = New AdvantageFramework.Database.Entities.AlertRecipient

                                Assignee.AlertID = Me.AlertID
                                Assignee.EmployeeCode = Employee.Code
                                Assignee.EmployeeEmail = Employee.Email
                                Assignee.AlertTemplateID = AlertEntity.AlertAssignmentTemplateID
                                Assignee.AlertStateID = AlertEntity.AlertStateID

                                If Employee.ConceptShareUserID IsNot Nothing Then

                                    Assignee.IsCurrentNotify = 1
                                    Assignee.IsConceptShareReviewer = True

                                End If
                                If EmployeeCode = Me.EmployeeCode Then

                                    Assignee.IsNewAlert = 0

                                Else

                                    Assignee.IsNewAlert = 1

                                End If
                                If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Assignee) = True Then

                                    If EmployeeCode = Me.EmployeeCode Then

                                        Dim DismissToolBarButton As RadToolBarButton

                                        DismissToolBarButton = Me.RadToolbarAlertDigitalAssetReview.FindItemByValue("Dismiss")
                                        DismissToolBarButton.Text = "Dismiss"
                                        DismissToolBarButton.ToolTip = "Dismiss the Review"

                                        Me.RefreshAlertWindows(False)

                                    Else

                                        SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(EmployeeCode, _Session.ConnectionString, _Session.UserCode)

                                    End If

                                End If

                            End If

                        End If

                    Next

                    For Each ClientContactID As Integer In ClientContactIds

                        If CurrentAlert.AlertCPCheckForDuplicates(Me.AlertID, ClientContactID) = False Then

                            CurrentAlert.AddAlertRecipientCC(ClientContactID, True)

                        End If

                    Next

                End If

            End Using

        End If

    End Function
    Private Sub OpenProofingTool()

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        ConceptShareConnection = Nothing

        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        If ConceptShareConnection IsNot Nothing Then

            Dim URL As String = String.Empty

            URL = AdvantageFramework.ConceptShare.GetReviewProofingURL(ConceptShareConnection, Me.ConceptShareProjectID, Me.ConceptShareReviewID)

            If String.IsNullOrEmpty(URL) = False Then

                Dim ReviewName As String = AdvantageFramework.StringUtilities.JavascriptSafe(Me.TextBoxReviewName.Text)
                Me.OpenWindow("Proofing Tool: " & ReviewName, URL, , , , True)

            Else

                Me.ShowMessage("Could not get proofing URL")

            End If


        End If


    End Sub

    Private Sub SetAutoApproveRuleReviewStatus()

        Me.RadComboBoxReviewStatus.Enabled = Not Me.RadioButtonListAutoApproveRule.SelectedIndex = 1

    End Sub

    Private Sub AddEmailingComment(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal IsExternal As Boolean,
                                   ByVal ListOfNames As Generic.List(Of String), ByVal IsEmailingAll As Boolean)

        If DbContext IsNot Nothing AndAlso Me.AlertID > 0 AndAlso ListOfNames IsNot Nothing Then

            Dim NewComment As New AdvantageFramework.Database.Entities.AlertComment
            Dim Message As String = "Sent email to following {0} reviewer{1}:  {2}"
            Dim InternalOrExternal As String = String.Empty
            Dim Pluralize As String = String.Empty
            Dim Names As String = String.Empty

            If IsEmailingAll = False Then

                If IsExternal = False Then

                    InternalOrExternal = "internal"

                Else

                    InternalOrExternal = "external"

                End If
                If ListOfNames.Count > 1 Then

                    Pluralize = "s"

                Else

                    Pluralize = ""

                End If

                NewComment.Comment = String.Format(Message, InternalOrExternal, Pluralize, String.Join(",", ListOfNames))

            Else

                If IsExternal = False Then

                    Message = "Sent email to all internal reviewers"

                Else

                    Message = "Sent email to all external reviewers"

                End If

                NewComment.Comment = Message

            End If

            NewComment.AlertID = Me.AlertID
            NewComment.UserCode = _Session.UserCode
            NewComment.GeneratedDate = CType(Now, DateTime)
            NewComment.HasEmailBeenSent = False
            NewComment.IsSystem = True

            'NewComment.ConceptShareProjectID = Me.ConceptShareProjectID
            'NewComment.ConceptShareReviewID = Me.ConceptShareReviewID

            AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, NewComment)

            Me.RadGridReviewComments.Rebind()
            Me.LoadEmailLog()

        End If

    End Sub

#Region " Job Info tooltip "

    Protected Sub MoreInformationOnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)

        Me.UpdateMoreInformationToolTip(args.Value, args.UpdatePanel)

    End Sub
    Private Sub UpdateMoreInformationToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)

        Dim JobInfoControl As System.Web.UI.Control = Page.LoadControl("JobInfo.ascx")
        Dim JobInfoTooltip As JobInfo_Tooltip = DirectCast(JobInfoControl, JobInfo_Tooltip)

        panel.ContentTemplateContainer.Controls.Add(JobInfoControl)

        JobInfoTooltip.JobNumber = Me.JobNumber
        JobInfoTooltip.JobComponentNumber = Me.JobComponentNumber

    End Sub

    Private Sub ButtonSelectExternalReviewer_Click(sender As Object, e As EventArgs) Handles ButtonSelectExternalReviewer.Click

        Dim qs As New AdvantageFramework.Web.QueryString

        qs.Page = "LookUp_EmailRecipients.aspx"
        qs.JobNumber = Me.JobNumber
        qs.JobComponentNumber = Me.JobComponentNumber
        qs.ConceptShareProjectID = Me.ConceptShareProjectID
        qs.ConceptShareReviewID = Me.ConceptShareReviewID
        qs.AlertID = Me.AlertID

        qs.Add("opener", "review")

        Me.OpenWindow("External Reviewers", qs.ToString(True))

    End Sub

    Private Sub RadAutoCompleteBoxExternalReviewers_EntryRemoved(sender As Object, e As AutoCompleteEntryEventArgs) Handles RadAutoCompleteBoxExternalReviewers.EntryRemoved

        If IsNumeric(e.Entry.Value) = True Then

            Dim ConceptShareUserID As Integer = CType(e.Entry.Value, Integer)
            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing
            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            If ConceptShareConnection IsNot Nothing Then

                If AdvantageFramework.ConceptShare.RemoveReviewMember(ConceptShareConnection, Me.ConceptShareReviewID, ConceptShareUserID) IsNot Nothing Then

                End If

            End If

        End If

    End Sub

    Private Sub RadListViewReviewers_ItemDrop(sender As Object, e As RadListViewItemDragDropEventArgs) Handles RadListViewReviewers.ItemDrop

        Dim DestinationHtmlElement As String = e.DestinationHtmlElement

        If DestinationHtmlElement.Contains("RadListViewReviewers") = True Then

            'Me.ShowMessage(DestinationHtmlElement)
            Dim ar() As String = DestinationHtmlElement.Split("_")
            If ar.Length > 3 Then

                If IsNumeric(ar(3).Replace("ctrl", "")) = True Then

                    Dim EmployeeCode As String = e.DraggedItem.GetDataKeyValue("EmployeeCode")
                    Dim ConceptShareUserID As Integer = e.DraggedItem.GetDataKeyValue("ConceptShareUserID")
                    Dim IsEmployee As Boolean = e.DraggedItem.GetDataKeyValue("IsEmployee")

                    Dim s As String = String.Empty
                    Dim NewIndex As Integer = -1

                    Try

                        NewIndex = CType(ar(3).Replace("ctrl", ""), Integer)

                    Catch ex As Exception
                        NewIndex = -1
                    End Try

                    If NewIndex >= 0 Then

                        Dim ReviewersRadList As RadListBox = Me.FindControlRecursive(Me.Page, "RadListViewReviewers")

                        If ReviewersRadList IsNot Nothing Then

                            Dim i As Integer = ReviewersRadList.Items.Count
                            Dim z As String = ""

                        End If

                    End If

                End If

            End If

        Else

            Me.ShowMessage("Please drop the card you are moving directly ONTO an icon or text of a different card to change priority")

        End If

    End Sub
    Private Function FindControlRecursive(Root As System.Web.UI.Control, Id As String) As System.Web.UI.Control

        If Root.ID = Id Then

            Return Root

        End If

        For Each Ctl As System.Web.UI.Control In Root.Controls

            Dim FoundCtl As System.Web.UI.Control = FindControlRecursive(Ctl, Id)

            If FoundCtl IsNot Nothing Then

                Return FoundCtl

            End If

        Next

        Return Nothing

    End Function

    Private Sub LinkButtonAlertAndEmailAllInternalReviewers_Click(sender As Object, e As EventArgs) Handles LinkButtonAlertAndEmailAllInternalReviewers.Click

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        ConceptShareConnection = Nothing

        If Me.IsClientPortal = False Then

            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        Else

            ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

        End If

        If ConceptShareConnection IsNot Nothing Then

            Dim Review As New AdvantageFramework.ConceptShareAPI.Review
            Dim s As String = String.Empty

            Review = AdvantageFramework.ConceptShare.LoadReviewByReviewID(ConceptShareConnection, Me.ConceptShareReviewID, s)

            If Review IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO ALERT_RCPT SELECT * FROM ALERT_RCPT_DISMISSED ARD WHERE ARD.ALERT_ID = {0}; DELETE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};UPDATE ALERT_RCPT SET CURRENT_NOTIFY = NULL WHERE ALERT_ID = {0};", Me.AlertID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO CP_ALERT_RCPT SELECT * FROM CP_ALERT_RCPT_DISMISSED ARD WHERE ARD.ALERT_ID = {0}; DELETE FROM CP_ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};UPDATE CP_ALERT_RCPT SET IS_DELETED = NULL WHERE ALERT_ID = {0};", Me.AlertID))

                    Me.AlertRecipients(DbContext, Review, True, False, False, "", True)

                    Me.LoadReviewers(True, False)
                    Me.RefreshAlertWindows(False)
                    Me.CheckReadStatus(DbContext)

                End Using

            End If

        End If

    End Sub

    Private Sub LinkButtonEmailAllExternalUsers_Click(sender As Object, e As EventArgs) Handles LinkButtonEmailAllExternalUsers.Click

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        ConceptShareConnection = Nothing
        If Me.IsClientPortal = False Then

            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        Else

            ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

        End If

        If ConceptShareConnection IsNot Nothing Then

            'Need to refactor email to email methods
            Dim AllExternalReviewers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
            Dim ExternalReviewers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
            Dim Names As New Generic.List(Of String)

            AllExternalReviewers = AdvantageFramework.ConceptShare.LoadExternalReviewMembersByReviewID(ConceptShareConnection, Me.ConceptShareReviewID)

            If AllExternalReviewers IsNot Nothing AndAlso AllExternalReviewers.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim Review As AdvantageFramework.ConceptShareAPI.Review
                        Dim Employee As AdvantageFramework.Database.Views.Employee
                        Dim Err As String = String.Empty

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, _Session.UserCode)
                        Review = AdvantageFramework.ConceptShare.LoadReviewByReviewID(ConceptShareConnection, Me.ConceptShareReviewID, Err)

                        If Review IsNot Nothing AndAlso Employee IsNot Nothing Then

                            Dim AgencyName As String = String.Empty
                            Dim URL As String = String.Empty
                            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus
                            Dim Subject As String = "Review request"
                            Dim ErrorMessage As String = ""
                            Dim CC As String = ""
                            Dim BCC As String = ""
                            Dim EmployeeName As String = Employee.FirstName & " " & Employee.LastName
                            Dim EmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(True)
                            Dim JobInfo As Generic.List(Of String) = AdvantageFramework.ConceptShare.LoadJobInfoForTagList(Me._Session,
                                                                                                                                           Me.JobNumber,
                                                                                                                                           Me.JobComponentNumber)

                            Try
                                AgencyName = DbContext.Database.SqlQuery(Of String)("SELECT [NAME] FROM AGENCY WITH(NOLOCK);").FirstOrDefault
                            Catch ex As Exception
                                AgencyName = String.Empty
                            End Try

                            EmailBody.AddCustomRow("Hi {0},")
                            EmailBody.AddBlankRow()

                            EmailBody.AddCustomRow(String.Format("{0} from {1} has included you in the '{2}' review where your feedback is required.",
                                                                                 EmployeeName,
                                                                                 AgencyName,
                                                                                 Review.Title))
                            EmailBody.AddBlankRow()

                            If JobInfo IsNot Nothing Then

                                For Each BitOfInfo As String In JobInfo

                                    EmailBody.AddCustomRow(String.Format("{0}<br/>", BitOfInfo))

                                Next

                            End If

                            EmailBody.AddCustomRow(String.Format("Description:  {0}<br/>", Review.Description))

                            If Review.DueDate IsNot Nothing AndAlso IsDate(Review.DueDate) = True Then

                                EmailBody.AddCustomRow(String.Format("Due date:  {0}<br/>", Review.DueDate))

                            End If

                            EmailBody.AddBlankRow()

                            EmailBody.AddCustomRow("Please use the link below to launch the review:")
                            EmailBody.AddCustomRow("<a href=""{1}"">{1}</a>")
                            EmailBody.AddCustomRow("<div style=""font-size:small !important;font-style:italic;"">If you cannot click the link, try copying and pasting the link into your browser.</div>")
                            EmailBody.AddBlankRow()

                            EmailBody.AddCustomRow("Thank you!")
                            EmailBody.AddBlankRow()

                            EmailBody.Finish()

                            Dim IsCompleted As Boolean = False
                            Dim Noob As AdvantageFramework.Database.Entities.ConceptShareExternalReviewer = Nothing

                            For Each ExternalReviewer As AdvantageFramework.ConceptShareAPI.ReviewMember In AllExternalReviewers

                                URL = String.Empty
                                IsCompleted = False
                                Noob = Nothing
                                Try

                                    URL = AdvantageFramework.ConceptShare.GetReviewProofingURLForExternalUser(ConceptShareConnection, Me.ConceptShareProjectID, Me.ConceptShareReviewID, ExternalReviewer.ReferenceId)

                                Catch ex As Exception
                                    URL = String.Empty
                                End Try
                                Try

                                    IsCompleted = ExternalReviewer.StatusName IsNot Nothing AndAlso ExternalReviewer.StatusName.ToLower.Contains("complete")

                                Catch ex As Exception
                                    IsCompleted = False
                                End Try

                                If String.IsNullOrWhiteSpace(URL) = False AndAlso String.IsNullOrWhiteSpace(ExternalReviewer.UserName) = False AndAlso
                                           AdvantageFramework.StringUtilities.IsValidEmailAddress(ExternalReviewer.UserName) = True AndAlso IsCompleted = False Then

                                    AdvantageFramework.Email.Send(DbContext,
                                                                      SecurityDbContext,
                                                                      ExternalReviewer.UserName,
                                                                      String.Format(BaseEmailSubject & " {0}", Me.TextBoxReviewName.Text),
                                                                      String.Format(EmailBody.ToString, ExternalReviewer.Name, URL),
                                                                      0,
                                                                      Nothing, SendingEmailStatus,
                                                                      ErrorMessage, CC, BCC)

                                    Me.AddUpdateEmailExternalReviewer(DbContext, ExternalReviewer, True)
                                    Names.Add(ExternalReviewer.Name)

                                End If

                            Next

                            Me.AddEmailingComment(DbContext, True, Names, True)

                            Try

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CS_EXT_REVIEWER SET LAST_EMAILED = GETDATE() WHERE CS_REVIEW_ID = {0};", Me.ConceptShareReviewID))
                                Me.LoadReviewers(False, True)

                            Catch ex As Exception
                            End Try

                        End If

                    End Using

                End Using

            End If

        End If

    End Sub

    Private Sub CheckBoxEmailLog_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEmailLog.CheckedChanged

        Me.LoadEmailLog()

    End Sub

    Private Sub ListViewEmailLog_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles ListViewEmailLog.ItemDataBound

        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim UserInfoLabel As Label = e.Item.FindControl("LabelUserInfo")

            If UserInfoLabel IsNot Nothing Then

                Dim Comment As AdvantageFramework.Database.Entities.AlertComment

                Comment = Nothing

                Try

                    Comment = CType(e.Item.DataItem, AdvantageFramework.Database.Entities.AlertComment)

                Catch ex As Exception
                    Comment = Nothing
                End Try
                Try

                    If Comment IsNot Nothing Then

                        UserInfoLabel.Text = String.Format("{0}, {1}", Comment.UserCode, DateAdd(DateInterval.Hour, Me.EmployeeTimezoneOffset, CType(Comment.GeneratedDate, DateTime)))

                    End If

                Catch ex As Exception
                    UserInfoLabel.Visible = False
                End Try

            End If

        End If

    End Sub

#End Region

    Private Sub LoadRadComboBoxReviewWorkflow(ByRef DbContext As AdvantageFramework.Database.DbContext)

        Me.RadComboBoxReviewWorkflow.Items.Clear()

        Select Case Me.BaseReviewType
            Case AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.Collaborative

                Me.RadComboBoxReviewWorkflow.Items.Add(New Telerik.Web.UI.RadComboBoxItem("None - Collaborative Review", "Collaborative"))
                Me.RadComboBoxReviewWorkflow.Enabled = False

            Case AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.WorkFlow

                Dim Templates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)

                Templates = Nothing
                Templates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActiveConceptShare(DbContext).ToList

                If Templates IsNot Nothing Then

                    Me.RadComboBoxReviewWorkflow.DataSource = Templates
                    Me.RadComboBoxReviewWorkflow.DataTextField = AdvantageFramework.Database.Entities.AlertAssignmentTemplate.Properties.Name.ToString
                    Me.RadComboBoxReviewWorkflow.DataValueField = AdvantageFramework.Database.Entities.AlertAssignmentTemplate.Properties.ID.ToString
                    Me.RadComboBoxReviewWorkflow.DataBind()

                    If Templates.Count = 1 Then

                        Dim SingleTemplateID As Integer = 0

                        Try
                            SingleTemplateID = (From Entity In Templates
                                                Select Entity.ID).SingleOrDefault

                        Catch ex As Exception
                            SingleTemplateID = 0
                        End Try
                        If SingleTemplateID > 0 Then
                            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxReviewWorkflow, SingleTemplateID, False)
                        End If
                        If Me.RadComboBoxReviewWorkflow.SelectedIndex > -1 Then

                            Me.RadComboBoxReviewWorkflow.Enabled = False
                            Me.SetWorkflowStates()

                        End If

                    ElseIf Templates.Count > 1 Then

                        Me.RadComboBoxReviewWorkflow.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    End If


                    Me.RadComboBoxReviewWorkflow.Enabled = True

                End If

        End Select

    End Sub
    Private Sub LoadRadListBoxState(ByVal AlertAssignmentTemplateID As Integer?)

        Me.RadListBoxState.Items.Clear()
        Me.RadListBoxState.Enabled = False

        If AlertAssignmentTemplateID IsNot Nothing AndAlso AlertAssignmentTemplateID > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim AlertStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertState)

                AlertStates = Nothing
                AlertStates = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, Me.RadComboBoxReviewWorkflow.SelectedItem.Value).ToList

                If AlertStates IsNot Nothing Then

                    Me.RadListBoxState.DataSource = AlertStates
                    Me.RadListBoxState.DataTextField = AdvantageFramework.Database.Entities.AlertState.Properties.Name.ToString
                    Me.RadListBoxState.DataValueField = AdvantageFramework.Database.Entities.AlertState.Properties.ID.ToString
                    Me.RadListBoxState.DataBind()
                    Me.RadListBoxState.Enabled = True

                End If

            End Using

        End If

    End Sub
    Private Sub LoadRadAutoCompleteBoxAssignTo(ByVal AlertAssignmentTemplateID As Integer?, ByVal AlertStateID As Integer?)

        Try

            Dim AlertController As New AdvantageFramework.Controller.Desktop.AlertController(Me._Session)

            AlertTemplateStateEmployees = AlertController.LoadAlertTemplateStateEmployees(Me.AlertID, AlertAssignmentTemplateID, AlertStateID, False, False, True)

            Me.RadAutoCompleteBoxAssignTo.DataTextField = "Name"
            Me.RadAutoCompleteBoxAssignTo.DataValueField = "Code"

            Me.RadAutoCompleteBoxAssignTo.DataSource = AlertTemplateStateEmployees

        Catch ex As Exception
        End Try

    End Sub
    Private Sub SetAssigneePanel(ByVal LoadCombo As Boolean)

        DivAssignment.Visible = Me.IsRouted
        NonRoutedReviewersDiv.Visible = Not Me.IsRouted

        If Me.IsRouted = True Then

            Me.BaseReviewType = AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.WorkFlow

        Else

            Me.BaseReviewType = AdvantageFramework.Database.Entities.Methods.ConceptShareBaseReviewType.Collaborative

        End If


        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If LoadCombo = True Then Me.LoadRadComboBoxReviewWorkflow(DbContext)
            ConceptShareSession.SetUserReviewRoutedSetting(DbContext, Me.IsRouted)

        End Using

    End Sub

    Private Sub RadComboBoxReviewWorkflow_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxReviewWorkflow.SelectedIndexChanged

        Me.SetWorkflowStates()

    End Sub
    Private Sub SetWorkflowStates()

        Me.RadListBoxState.Items.Clear()
        Me.RadListBoxState.Enabled = False
        Me.RadAutoCompleteBoxAssignTo.Entries.Clear()
        Me.RadAutoCompleteBoxAssignTo.Enabled = False

        If Me.RadComboBoxReviewWorkflow.SelectedItem IsNot Nothing AndAlso Me.RadComboBoxReviewWorkflow.SelectedIndex > -1 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim AlertStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertState)

                AlertStates = Nothing
                AlertStates = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, Me.RadComboBoxReviewWorkflow.SelectedItem.Value).ToList

                If AlertStates IsNot Nothing Then

                    Me.RadListBoxState.DataSource = AlertStates
                    Me.RadListBoxState.DataTextField = AdvantageFramework.Database.Entities.AlertState.Properties.Name.ToString
                    Me.RadListBoxState.DataValueField = AdvantageFramework.Database.Entities.AlertState.Properties.ID.ToString
                    Me.RadListBoxState.DataBind()
                    Me.RadListBoxState.Enabled = True

                End If

            End Using

        End If

    End Sub
    Private Sub RadListBoxState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxState.SelectedIndexChanged

        Me.RadAutoCompleteBoxAssignTo.Entries.Clear()

        Me.RadAutoCompleteBoxAssignTo.Enabled = False

        If Me.RadListBoxState.SelectedItem IsNot Nothing Then

            Dim Item As Telerik.Web.UI.AutoCompleteBoxEntry = Nothing
            Dim AlertController As New AdvantageFramework.Controller.Desktop.AlertController(Me._Session)

            AlertTemplateStateEmployees = AlertController.LoadAlertTemplateStateEmployees(Me.AlertID, Me.RadComboBoxReviewWorkflow.SelectedItem.Value, Me.RadListBoxState.SelectedItem.Value, False, False, True)

            Me.RadAutoCompleteBoxAssignTo.DataTextField = "Name"
            Me.RadAutoCompleteBoxAssignTo.DataValueField = "Code"
            Me.RadAutoCompleteBoxAssignTo.DataSource = AlertTemplateStateEmployees

            If AlertTemplateStateEmployees IsNot Nothing AndAlso AlertTemplateStateEmployees.Count > 0 Then

                For Each AlertTemplateStateEmployee As AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee In AlertTemplateStateEmployees

                    If AlertTemplateStateEmployee.Name.Contains("*") Then

                        Item = New AutoCompleteBoxEntry

                        Item.Value = AlertTemplateStateEmployee.Code
                        Item.Text = AlertTemplateStateEmployee.Name

                        Me.RadAutoCompleteBoxAssignTo.Entries.Add(Item)

                        Item = Nothing

                    End If

                Next

                Me.RadAutoCompleteBoxAssignTo.Enabled = True

            Else

                Me.RadAutoCompleteBoxAssignTo.Enabled = False

            End If

        End If

    End Sub

    Private Sub RadAutoCompleteBoxAssignTo_DataBound(sender As Object, e As EventArgs) Handles RadAutoCompleteBoxAssignTo.DataBound

    End Sub

    Private Sub RadAutoCompleteBoxAssignTo_EntryRemoved(sender As Object, e As AutoCompleteEntryEventArgs) Handles RadAutoCompleteBoxAssignTo.EntryRemoved

        Dim o As Object = sender

    End Sub

    Private Sub RadListBoxState_ItemDataBound(sender As Object, e As RadListBoxItemEventArgs) Handles RadListBoxState.ItemDataBound


    End Sub


#End Region

End Class
