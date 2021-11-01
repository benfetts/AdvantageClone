Imports Telerik.Web.UI

Public Class DesktopCardsMyAssignments
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum LoadType

        AlertsAndAssignments = 0
        Alerts = 1
        Assignments = 2
        Reviews = 3

    End Enum
    Private Enum SortOptions

        New__Unread
        Category
        Priority
        Due_Date__Time_Due
        Version_Build
        State
        Last_Updated
        Custom_Order

    End Enum

#End Region

#Region " Variables "

    Private _Alert As AdvantageFramework.Database.Entities.Alert
    Private Property _App As cAppVars.Application
        Get
            If ViewState("_App") Is Nothing Then

                Return cAppVars.Application.ALERT_CARDS

            Else

                Return CType(CType(ViewState("_App"), Integer), cAppVars.Application)

            End If
        End Get
        Set(value As cAppVars.Application)
            ViewState("_App") = CType(value, Integer)
        End Set
    End Property
    Private _CardSettings As DesktopCardSettings

#End Region

#Region " Properties "

    Public Property IsDashboard As Boolean = False
    Public Property LoadAlertType As LoadType
    Public ReadOnly Property RefreshImageButton As System.Web.UI.WebControls.ImageButton
        Get
            Return Me.ImageButtonRefreshDesktopCardsMyAssignments
        End Get
    End Property
    Public Property ShowMoreButton As Boolean
        Get
            Return False ' Me.RadDataPagerRadListViewAlertAssignmentsDirtyTop.Visible
        End Get
        Set(value As Boolean)
            ' Me.RadDataPagerRadListViewAlertAssignmentsDirtyTop.Visible = value
        End Set
    End Property
    Public Property ShowTitle As Boolean
        Get
            Return Me.LabelTitle.Visible
        End Get
        Set(value As Boolean)
            Me.LabelTitle.Visible = value
        End Set
    End Property
    Private Property _LoadMore As Boolean
        Get
            If Session("DesktopCardsMyAssignments_LoadMore" & Me.ClientID) Is Nothing Then
                Session("DesktopCardsMyAssignments_LoadMore" & Me.ClientID) = False
            End If
            Return Session("DesktopCardsMyAssignments_LoadMore" & Me.ClientID)
        End Get
        Set(value As Boolean)
            Session("DesktopCardsMyAssignments_LoadMore" & Me.ClientID) = value
        End Set
    End Property
    Private Property _AllowCardSort As Boolean
        Get
            If Session("DesktopCardsMyAssignments_AllowCardSort" & Me.ClientID) Is Nothing Then
                Session("DesktopCardsMyAssignments_AllowCardSort" & Me.ClientID) = False
            End If
            Return Session("DesktopCardsMyAssignments_AllowCardSort" & Me.ClientID)
        End Get
        Set(value As Boolean)
            Session("DesktopCardsMyAssignments_AllowCardSort" & Me.ClientID) = value
        End Set
    End Property
    Private Property _GroupField As String
        Get
            If Session("DesktopCardsMyAssignments_GroupField" & Me.ClientID) Is Nothing Then
                Session("DesktopCardsMyAssignments_GroupField" & Me.ClientID) = "END_SELECT_CLAUSE"
            End If
            Return Session("DesktopCardsMyAssignments_GroupField" & Me.ClientID)
        End Get
        Set(value As String)
            Session("DesktopCardsMyAssignments_GroupField" & Me.ClientID) = value
        End Set
    End Property
    Private Property _LastGroupField As String
        Get
            If Session("DesktopCardsMyAssignments_LastGroupField" & Me.ClientID) Is Nothing Then
                Session("DesktopCardsMyAssignments_LastGroupField" & Me.ClientID) = "END_SELECT_CLAUSE"
            End If
            Return Session("DesktopCardsMyAssignments_LastGroupField" & Me.ClientID)
        End Get
        Set(value As String)
            Session("DesktopCardsMyAssignments_LastGroupField" & Me.ClientID) = value
        End Set
    End Property
    Private Property _SortOption As String
        Get
            If Session("DesktopCardsMyAssignments_SortOption" & Me.ClientID) Is Nothing Then
                Session("DesktopCardsMyAssignments_SortOption" & Me.ClientID) = ""
            End If
            Return Session("DesktopCardsMyAssignments_SortOption" & Me.ClientID)
        End Get
        Set(value As String)
            Session("DesktopCardsMyAssignments_SortOption" & Me.ClientID) = value
        End Set
    End Property
    Private Property CurrentGridPageIndex As Integer
        Get
            If ViewState("DesktopCardsMyAssignments_CurrentGridPageIndex") Is Nothing Then
                ViewState("DesktopCardsMyAssignments_CurrentGridPageIndex") = 0
            End If
            Return ViewState("DesktopCardsMyAssignments_CurrentGridPageIndex")
        End Get
        Set(value As Integer)
            ViewState("DesktopCardsMyAssignments_CurrentGridPageIndex") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " User Control "

    Private Sub DesktopTileMyAssignments_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Me.EventTarget = "SignOut" Then Exit Sub
        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        If Not Me.IsPostBack AndAlso Not Me.Page.IsCallback Then

            Me.LoadSortOptions()
            Me.LoadData(False)
            Me.MyUnityContextMenu.SetRadListView(Me.RadListViewAlertAssignmentsDirty)
            If Me.IsClientPortal = True Then Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.NewAssignment, UnityUC.UnityItem.SendAssignment}

        Else

            Select Case Me.EventTarget

                Case "RebindGrid",
                     "UpdatePanelDefaultWorkspaceLeftMiddle",
                     "UpdatePanelUserAssignments",
                     "UpdatePanelUserAlerts",
                     "UpdatePanelUserReviews",
                     "UpdateWorkspaceAlerts",
                     "UpdateDashboardAlerts", "UpdatePanelDO"

                    Me.LoadData(False)

            End Select

        End If

        'Me.DivSortOptions.Visible = Me.IsDashboard

    End Sub
    Private Sub DesktopCardsMyAssignments_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If Me.EventTarget = "SignOut" Then Exit Sub
        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        _AllowCardSort = False

        Try

            If Me.RadComboBoxSortOptions.SelectedItem IsNot Nothing Then

                Me._SortOption = Me.RadComboBoxSortOptions.SelectedItem.Value

                Select Case Me.RadComboBoxSortOptions.SelectedItem.Value
                    Case "CAT"

                        _GroupField = "CATEGORY"

                    Case "NEW_UNREAD"

                        _GroupField = "READ_ALERT_TEXT"

                    Case "STATE"

                        _GroupField = "ALERT_STATE_NAME"

                    Case "VER_BLD"

                        _GroupField = "VERSION_BUILD"

                    Case "PRIORITY"

                        _GroupField = "CARD_GROUPING_PRIORITY_TEXT"

                    Case "C"

                        _GroupField = "GRP_CLIENT"

                    Case "CD"

                        _GroupField = "GRP_DIVISION"

                    Case "CDP"

                        _GroupField = "GRP_PRODUCT"

                    Case "CDPJ"

                        _GroupField = "GRP_JOB"

                    Case "CDPJC"

                        _GroupField = "GRP_COMPONENT"

                        'Case "DUE_DATE"

                        '    _GroupField = "DUE_DATE"

                    Case Else

                        _GroupField = "END_SELECT_CLAUSE"
                        _AllowCardSort = True

                End Select

            End If

            'If (_GroupField <> _LastGroupField) OrElse Me.EventTarget = "UpdatePanelDefaultWorkspaceLeftMiddle" OrElse
            '    Me.EventTarget = "UpdatePanelUserAssignments" OrElse Me.EventTarget = "UpdatePanelUserAlerts" OrElse
            '    Me.EventTarget = "UpdatePanelUserReviews" OrElse
            '    Me.EventTarget = "UpdateWorkspaceAlerts" OrElse Me.EventTarget = "UpdateDashboardAlerts" Then

            For Each item In Me.RadListViewAlertAssignmentsDirty.DataGroups

                item.GroupField = _GroupField
                Exit For

            Next

            _LastGroupField = _GroupField
            Me.RadListViewAlertAssignmentsDirty.Rebind()

            'End If

        Catch ex As Exception
        End Try

    End Sub

#End Region
#Region " Controls "

    Private Sub ImageButtonRefreshDesktopCardsMyAssignments_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefreshDesktopCardsMyAssignments.Click

        Me.LoadData(False)

        Me.RefreshAlertWindows(False, False, False, False, False)
        Me.RefreshTasks()

    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = Me.RadListViewAlertAssignmentsDirty.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = Me.RadListViewAlertAssignmentsDirty.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")
        Me.MyUnityContextMenu.AlertID = Me.RadListViewAlertAssignmentsDirty.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("ALERT_ID")

    End Sub

    Private Sub RadComboBoxSortOptions_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSortOptions.SelectedIndexChanged

        SetSettingsType()

        Me._SortOption = Me.RadComboBoxSortOptions.SelectedItem.Value

        Dim av As New cAppVars(_App)

        av.getAllAppVars()
        av.setAppVar("dflt_wkspc_sort", Me.RadComboBoxSortOptions.SelectedItem.Value.ToString(), "String")
        av.SaveAllAppVars()

        Me.CurrentGridPageIndex = 0
        Me.RadListViewAlertAssignmentsDirty.Rebind()

    End Sub
    Private Sub RadListViewAlertAssignmentsDirty_ItemCommand(sender As Object, e As RadListViewCommandEventArgs) Handles RadListViewAlertAssignmentsDirty.ItemCommand

        Dim ThisItem As RadListViewDataItem = e.ListViewItem
        Dim a As AdvantageFramework.Database.Entities.Alert
        Dim JobNumber As Integer = 0
        Dim JobComponentNumber As Integer = 0
        Dim TaskSequenceNumber As Integer = -1
        Dim SprintID As Integer = 0

        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

            a = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, ThisItem.GetDataKeyValue("ALERT_ID"))

            If a IsNot Nothing Then

                Try

                    SprintID = ThisItem.GetDataKeyValue("SPRINT_ID")

                Catch ex As Exception
                    SprintID = 0
                End Try

                Select Case e.CommandName

                    Case "Complete"

                        If a.ID > 0 Then

                            Dim PromptForFullCompleteTask As Boolean = False
                            Dim PromptForTempCompleteTask As Boolean = False
                            Dim s As String = String.Empty

                            If AdvantageFramework.AlertSystem.DismissAlert(DbContext, a.ID, Session("EmpCode"), Session("UserCode"), Session("UserID"), True,
                                                                       PromptForFullCompleteTask, PromptForTempCompleteTask, s) = True Then

                                If PromptForFullCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = a.ID
                                        .Add("complete", 1)
                                        .Add("IsTempComplete", 0)

                                    End With

                                    Me.OpenWindow("", QueryString.ToString(True), 250, 500, False, True)

                                ElseIf PromptForTempCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = a.ID
                                        .Add("complete", 1)
                                        .Add("IsTempComplete", 1)

                                    End With

                                    Me.OpenWindow("", QueryString.ToString(True), 250, 500, False, True)

                                Else

                                    Me.RefreshAlertWindows(False, True, False, False, False)
                                    Me.RadListViewAlertAssignmentsDirty.Rebind()

                                End If

                                ''Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, a.ID, SprintID, Me._Session.UserCode, "", True)

                            Else

                                If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                            End If

                        End If

                    Case "Dismiss"

                        If a.ID > 0 Then

                            Dim PromptForFullCompleteTask As Boolean = False
                            Dim PromptForTempCompleteTask As Boolean = False
                            Dim s As String = String.Empty
                            Dim ForceAssignmentComplete As Boolean = False
                            Dim IsConceptShareReview As Boolean = False

                            Try

                                If a.IsConceptShareReview IsNot Nothing AndAlso a.IsConceptShareReview = True Then

                                    IsConceptShareReview = True
                                    Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

                                    Recipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, a.ID, Session("EmpCode"))

                                    If Recipient IsNot Nothing AndAlso Recipient.IsCurrentNotify IsNot Nothing AndAlso Recipient.IsCurrentNotify = 1 Then

                                        Recipient.IsCurrentNotify = Nothing
                                        AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, Recipient)
                                        ForceAssignmentComplete = False

                                    End If

                                End If

                            Catch ex As Exception
                                ForceAssignmentComplete = False
                            End Try

                            If AdvantageFramework.AlertSystem.DismissAlert(DbContext, a.ID, Session("EmpCode"), Session("UserCode"), Session("UserID"), ForceAssignmentComplete,
                                                                       PromptForFullCompleteTask, PromptForTempCompleteTask, s) = True Then

                                If IsConceptShareReview = False Then

                                    If PromptForFullCompleteTask = True Then

                                        Dim QueryString As New AdvantageFramework.Web.QueryString
                                        With QueryString

                                            .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                            .AlertID = a.ID
                                            .Add("complete", 0)
                                            .Add("IsTempComplete", 0)

                                        End With

                                        Me.OpenWindow("", QueryString.ToString(True), 250, 500, False, True)

                                    ElseIf PromptForTempCompleteTask = True Then

                                        Dim QueryString As New AdvantageFramework.Web.QueryString
                                        With QueryString

                                            .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                            .AlertID = a.ID
                                            .Add("complete", 0)
                                            .Add("IsTempComplete", 1)

                                        End With

                                        Me.OpenWindow("", QueryString.ToString(True), 250, 500, False, True)

                                    Else

                                        Me.RefreshAlertWindows(False, True, False, False, False)
                                        Me.RadListViewAlertAssignmentsDirty.Rebind()

                                    End If

                                Else

                                    Me.RefreshAlertWindows(False, True, False, False, False)
                                    Me.RadListViewAlertAssignmentsDirty.Rebind()

                                End If

                                ''Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, a.ID, SprintID, Me._Session.UserCode, "", True)

                            Else

                                If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                            End If

                        End If

                    Case "Bookmark"

                        Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                        Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                        Dim qs As New AdvantageFramework.Web.QueryString()

                        Dim Subject As String = a.Subject.Trim()

                        qs.Page = "Desktop_AlertView"
                        qs.AlertID = e.CommandArgument
                        qs.Add("AlertID", e.CommandArgument)
                        qs.Add("SprintID", "0")

                        With b

                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Alerts
                            .UserCode = Session("UserCode")
                            .Name = String.Format("{0}: {1} {2}", If(a.IsWorkItem.GetValueOrDefault(False), "Assignment", "Alert"), e.CommandArgument, Subject)
                            .Description = Subject
                            .PageURL = qs.ToString(True)

                        End With

                        Dim s As String = ""
                        If BmMethods.SaveBookmark(b, s) = False Then

                            Me.ShowMessage(s)

                        Else

                            Me.RefreshBookmarksDesktopObject()

                        End If

                    Case "AddTime"

                        Dim empnontask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing

                        If a.JobNumber IsNot Nothing AndAlso IsNumeric(a.JobNumber) = True Then JobNumber = a.JobNumber
                        If a.JobComponentNumber IsNot Nothing AndAlso IsNumeric(a.JobComponentNumber) = True Then JobComponentNumber = a.JobComponentNumber
                        If a.TaskSequenceNumber IsNot Nothing AndAlso IsNumeric(a.TaskSequenceNumber) = True Then TaskSequenceNumber = a.TaskSequenceNumber

                        If JobNumber > 0 And JobComponentNumber > 0 Then

                            Dim Controller As New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)
                            Dim Message As String = String.Empty

                            If Controller.CanAddTimeToJob(JobNumber, JobComponentNumber, Message) = True Then

                                Me.OpenWindow("Add Time", String.Format("Employee/Timesheet/Entry?a={0}&j={1}&jc={2}&s={3}", a.ID, JobNumber, JobComponentNumber, TaskSequenceNumber), 600, 600)

                            Else

                                If String.IsNullOrWhiteSpace(Message) = False Then

                                    Me.ShowMessage(Message)

                                Else

                                    Me.ShowMessage("Job/Component Process Control does not allow access.")

                                End If

                            End If

                        End If

                    Case "StartStopwatch"

                        If a.JobNumber IsNot Nothing AndAlso IsNumeric(a.JobNumber) = True Then JobNumber = a.JobNumber
                        If a.JobComponentNumber IsNot Nothing AndAlso IsNumeric(a.JobComponentNumber) = True Then JobComponentNumber = a.JobComponentNumber
                        If a.TaskSequenceNumber IsNot Nothing AndAlso IsNumeric(a.TaskSequenceNumber) = True Then TaskSequenceNumber = a.TaskSequenceNumber

                        If JobNumber > 0 And JobComponentNumber > 0 Then

                            Dim Controller As New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)
                            Dim Message As String = String.Empty

                            If Controller.CanAddTimeToJob(JobNumber, JobComponentNumber, Message) = True Then

                                Dim s As String = ""

                                If AdvantageFramework.Timesheet.Methods.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), JobNumber, JobComponentNumber, TaskSequenceNumber, a.ID, s) = True Then

                                    Me.OpenTimesheetStopwatchNotificationWindow()

                                Else

                                    Me.ShowMessage(s)

                                End If

                            Else

                                If String.IsNullOrWhiteSpace(Message) = False Then

                                    Me.ShowMessage(Message)

                                Else

                                    Me.ShowMessage("Job/Component Process Control does not allow access.")

                                End If

                            End If

                        End If

                    Case "FeedbackSummary"

                        Try
                            If IsNumeric(ThisItem.GetDataKeyValue("CS_PROJECT_ID")) AndAlso IsNumeric(ThisItem.GetDataKeyValue("CS_REVIEW_ID")) Then

                                Me.ShowMessage("This might take a few seconds.")
                                Me.ReviewGenerateFeedbackSummary(ThisItem.GetDataKeyValue("CS_PROJECT_ID"), ThisItem.GetDataKeyValue("CS_REVIEW_ID"))

                            End If
                        Catch ex As Exception
                            Me.ShowMessage("Something went wrong!")
                        End Try

                    Case "ProofingTool"

                        If Me.SecuritySession IsNot Nothing Then

                            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                            ConceptShareConnection = Nothing
                            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                            If ConceptShareConnection IsNot Nothing Then

                                Dim URL As String = String.Empty

                                URL = AdvantageFramework.ConceptShare.GetReviewProofingURL(ConceptShareConnection, a.ConceptShareProjectID, a.ConceptShareReviewID)

                                If String.IsNullOrEmpty(URL) = False Then

                                    Me.OpenWindow("Proofing Tool", URL, , , , True)

                                Else

                                    Me.ShowMessage("Could not get proofing URL")

                                End If

                            End If

                        End If

                End Select

            End If

        End Using

    End Sub

    Private _ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

    Private Sub RadListViewAlertAssignmentsDirty_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewAlertAssignmentsDirty.ItemDataBound

        Select Case e.Item.ItemType

            Case RadListViewItemType.DataGroupItem

                Try 'Hack for stupid Radlist grouping by alpha only

                    If Me.RadComboBoxSortOptions.SelectedItem.Value = "PRIORITY" Then

                        Dim GroupItem As RadListViewDataGroupItem = DirectCast(e.Item, RadListViewDataGroupItem)

                        If GroupItem IsNot Nothing Then

                            Dim GroupingPanel As Panel = DirectCast(GroupItem.Controls(1), Panel)
                            If GroupingPanel IsNot Nothing AndAlso GroupingPanel.GroupingText.Contains(",") Then

                                Dim ar As String()
                                ar = GroupingPanel.GroupingText.Split(",")
                                GroupingPanel.GroupingText = ar(1)

                            End If

                        End If

                    End If

                Catch ex As Exception
                End Try

            Case RadListViewItemType.AlternatingItem, RadListViewItemType.DataItem

                If _CardSettings Is Nothing Then

                    Me.SetSettingsType()
                    Dim av As New cAppVars(_App)
                    av.getAllAppVars()

                    Try

                        _CardSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

                    Catch ex As Exception
                        _CardSettings = Nothing
                    End Try

                    If _CardSettings Is Nothing Then _CardSettings = New DesktopCardSettings

                End If

                Try

                    Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)
                    Dim DataItem = ListItem.DataItem
                    Dim SubjectHeader As HtmlControls.HtmlGenericControl = e.Item.FindControl("HeaderSubject")
                    Dim SubjectLabel As Label = e.Item.FindControl("LabelSubject")
                    Dim DetailsDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivDetails")
                    Dim CardDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivAlertAssignmentCard")

                    Dim QsViewDetails As New AdvantageFramework.Web.QueryString
                    Dim IsCSReview As Boolean = False
                    Dim ReviewersCompletedDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivReviewersCompleted")

                    QsViewDetails.AlertID = CType(DataItem("ALERT_ID"), Integer)

                    SubjectLabel.Text = AdvantageFramework.StringUtilities.Truncate(DataItem("SUBJECT").ToString(), 80)

                    Try
                        IsCSReview = DataItem("IS_CS_REVIEW")
                    Catch ex As Exception
                        IsCSReview = False
                    End Try

                    Dim CommentsImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonComments")

                    CommentsImageButton.Attributes.Remove("onclick")

                    If IsCSReview = False Then

                        If DataItem("IS_WORK_ITEM") = True And IsClientPortal = False Then

                            QsViewDetails.Page = "Desktop_AlertView"
                            QsViewDetails.Add("AlertID", DataItem("ALERT_ID").ToString)
                            QsViewDetails.Add("SprintID", DataItem("SPRINT_ID").ToString)

                        Else

                            QsViewDetails.Page = "Alert_View.aspx"

                            Try
                                If CBool(DataItem("IS_ASSIGNMENT")) = True Then

                                    QsViewDetails.Add("openasassign", "true")

                                Else

                                    QsViewDetails.Add("openasassign", "false")

                                End If
                            Catch ex As Exception
                            End Try

                        End If

                        ReviewersCompletedDiv.Visible = False

                        Dim CommentsQS As New AdvantageFramework.Web.QueryString()

                        CommentsQS.Page = "Alert_Comments.aspx"
                        CommentsQS.AlertID = DataItem("ALERT_ID")

                        CommentsImageButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", CommentsQS.ToString(True)))

                    Else

                        CommentsImageButton.CommandName = "ProofingTool"
                        CommentsImageButton.ToolTip = "Proofing Tool"

                        QsViewDetails.Page = "Alert_DigitalAssetReview.aspx"
                        QsViewDetails.JobNumber = DataItem("JOB_NUMBER")
                        QsViewDetails.JobComponentNumber = DataItem("JOB_COMPONENT_NBR")
                        QsViewDetails.ConceptShareProjectID = DataItem("CS_PROJECT_ID")
                        QsViewDetails.ConceptShareReviewID = DataItem("CS_REVIEW_ID")
                        QsViewDetails.AlertID = DataItem("ALERT_ID")

                        Dim ThumbnailImageButton As ImageButton = e.Item.FindControl("ImageButtonThumbnail")
                        Dim ThumbnailDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivThumbnail")
                        Dim CardTextDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivCardText")

                        Dim TotalReviewers As Integer = 0
                        Dim CompletedReviewers As Integer = 0
                        Dim ApprovedReviewers As Integer = 0
                        Dim RejectedReviewers As Integer = 0
                        Dim DeferredReviewers As Integer = 0

                        Try

                            If IsDBNull(DataItem("CS_NUM_REVIEWER")) = False Then

                                TotalReviewers = DataItem("CS_NUM_REVIEWER")

                            End If

                        Catch ex As Exception
                            TotalReviewers = 0
                        End Try
                        Try

                            If IsDBNull(DataItem("CS_NUM_CMPLT")) = False Then

                                CompletedReviewers = DataItem("CS_NUM_CMPLT")

                            End If

                        Catch ex As Exception
                            CompletedReviewers = 0
                        End Try
                        Try

                            If IsDBNull(DataItem("CS_NUM_REJECT")) = False Then

                                RejectedReviewers = DataItem("CS_NUM_REJECT")

                            End If

                        Catch ex As Exception
                            RejectedReviewers = 0
                        End Try
                        Try

                            If IsDBNull(DataItem("CS_NUM_DEFER")) = False Then

                                DeferredReviewers = DataItem("CS_NUM_DEFER")

                            End If

                        Catch ex As Exception
                            DeferredReviewers = 0
                        End Try
                        Try

                            If IsDBNull(DataItem("CS_NUM_APPR")) = False Then

                                ApprovedReviewers = DataItem("CS_NUM_APPR")

                            End If

                        Catch ex As Exception
                            ApprovedReviewers = 0
                        End Try

                        Dim ReviewersCompletedLabel As Label = e.Item.FindControl("LabelReviewersCompleted")

                        If ReviewersCompletedLabel IsNot Nothing Then

                            Try

                                If CompletedReviewers = 0 Then

                                    CompletedReviewers = ApprovedReviewers + DeferredReviewers + RejectedReviewers

                                End If

                            Catch ex As Exception
                            End Try

                            ReviewersCompletedLabel.Text = String.Format("{0}/{1}", CompletedReviewers, TotalReviewers)
                            ReviewersCompletedLabel.ToolTip = String.Format("{0} Approved, {1} Rejected, {2} Deferred",
                                                                            ApprovedReviewers,
                                                                            RejectedReviewers,
                                                                            DeferredReviewers)

                        End If

                        Dim ReviewerActiveLabel As Label = e.Item.FindControl("LabelReviewerActive")
                        If ReviewerActiveLabel IsNot Nothing Then

                            If Me.IsClientPortal = False Then

                                Try

                                    ReviewerActiveLabel.Visible = DataItem("CURRENT_NOTIFY").ToString = "1"

                                Catch ex As Exception
                                    ReviewerActiveLabel.Visible = False
                                End Try

                            Else

                                Try

                                    ReviewerActiveLabel.Visible = DataItem("IS_DELETED").ToString = "0"

                                Catch ex As Exception
                                    ReviewerActiveLabel.Visible = False
                                End Try

                            End If

                        End If

                        Try

                            Dim ImageString As String = String.Empty
                            If IsDBNull(DataItem("CS_ASSET_IMG")) = True Then 'Check review

                                'If Me._ConceptShareConnection Is Nothing Then

                                '    Dim SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Me._Session.ConnectionString, Me._Session.UserCode, 0)
                                '    Dim ConceptShareSession As New ConceptShareSession(SecuritySession)
                                '    Me._ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                                'End If
                                'If Me._ConceptShareConnection IsNot Nothing Then

                                '    Dim ReviewID As Integer = 0

                                '    Try
                                '        ReviewID = ListItem.GetDataKeyValue("CS_REVIEW_ID")
                                '    Catch ex As Exception
                                '        ReviewID = 0
                                '    End Try

                                '    If ReviewID > 0 Then

                                '        Dim ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary

                                '        ReviewSummary = AdvantageFramework.ConceptShare.LoadReviewSummary(_ConceptShareConnection, ReviewID)

                                '        If ReviewSummary IsNot Nothing Then

                                '            ImageString = AdvantageFramework.ConceptShare.ByteArrayImageToImageURL(ReviewSummary.BaseImage)

                                '        End If

                                '    End If

                                'End If

                            Else

                                ImageString = AdvantageFramework.ConceptShare.ByteArrayImageToImageURL(DataItem("CS_ASSET_IMG"))

                            End If
                            If String.IsNullOrWhiteSpace(ImageString) = False Then

                                ThumbnailDiv.Attributes.Remove("class")
                                ThumbnailDiv.Attributes.Add("class", "thumbnail-column")
                                CardTextDiv.Attributes.Remove("class")
                                CardTextDiv.Attributes.Add("class", "card-text-with-thumbnail")

                                ThumbnailImageButton.ImageUrl = ImageString
                                ThumbnailImageButton.OnClientClick = Me.HookUpOpenWindow("", QsViewDetails.ToString(True))

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                    Dim ClientNameLabel As Label = e.Item.FindControl("LabelClientName")
                    If ClientNameLabel IsNot Nothing Then

                        ClientNameLabel.Visible = False

                        If Me._CardSettings.ShowClientName = True Then

                            Dim ClientName As String = String.Empty

                            Try

                                If DataItem("CL_NAME") IsNot System.DBNull.Value Then ClientName = DataItem("CL_NAME")

                            Catch ex As Exception
                                ClientName = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(ClientName) = False Then

                                ClientNameLabel.Visible = True
                                ClientNameLabel.Text = ClientName & "<br />"

                            End If

                        End If

                    End If

                    SubjectHeader.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))
                    DetailsDiv.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))

                    Select Case CType(DataItem("PRIORITY"), Integer)
                        Case 5

                            CardDiv.Attributes.Add("class", "card alert-card rlvI card-edge-alert-priority-lowest")

                        Case 4

                            CardDiv.Attributes.Add("class", "card alert-card rlvI card-edge-alert-priority-low")

                        Case 2

                            CardDiv.Attributes.Add("class", "card alert-card rlvI card-edge-alert-priority-high")

                        Case 1

                            CardDiv.Attributes.Add("class", "card alert-card rlvI card-edge-alert-priority-highest")

                        Case Else

                            CardDiv.Attributes.Add("class", "card alert-card rlvI card-edge-alert-priority-normal")

                    End Select

                    Dim HasDueDate As Boolean = False
                    If DataItem("DUE_DATE") IsNot System.DBNull.Value AndAlso IsDate(DataItem("DUE_DATE")) Then

                        Dim DueDateLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelDueDate")

                        DueDateLabel.Text = LoGlo.FormatDate(String.Format("{0:d}", DataItem("DUE_DATE")))

                        If CDate(DataItem("DUE_DATE")) < Now.Date Then

                            DueDateLabel.CssClass = "task-due-overdue"

                        End If

                        HasDueDate = True

                    Else

                        Dim DueDateDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivDueDate")

                        DueDateDiv.Visible = False

                    End If

                    If IsDBNull(DataItem("TIME_DUE")) = False AndAlso String.IsNullOrWhiteSpace(DataItem("TIME_DUE").ToString) = False Then

                        Dim DueTimeLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelDueTime")

                        If HasDueDate = True Then

                            DueTimeLabel.Text = ", " & AdvantageFramework.AlertSystem.MilitaryTimeStringToStandardTimeString(DataItem("TIME_DUE"))

                        Else

                            DueTimeLabel.Text = "Due: " & AdvantageFramework.AlertSystem.MilitaryTimeStringToStandardTimeString(DataItem("TIME_DUE"))

                        End If

                    Else

                        Dim TimeDueDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivDueTime")

                        TimeDueDiv.Visible = False

                    End If

                    Dim AddTimeImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonAddTime")
                    Dim StartStopwatchImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonStartStopwatch")
                    Dim JobInformationDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivJobInformation")
                    Dim JobNumber As Integer = 0
                    Dim JobComponentNumber As Short = 0
                    Dim JobDescription As String = String.Empty
                    Dim JobComponentDescription As String = String.Empty

                    If DataItem("JOB_NUMBER") IsNot System.DBNull.Value Then JobNumber = DataItem("JOB_NUMBER")
                    If DataItem("JOB_COMPONENT_NBR") IsNot System.DBNull.Value Then JobComponentNumber = DataItem("JOB_COMPONENT_NBR")
                    If DataItem("JOB_DESC") IsNot System.DBNull.Value Then JobDescription = DataItem("JOB_DESC")
                    If DataItem("JOB_COMP_DESC") IsNot System.DBNull.Value Then JobComponentDescription = DataItem("JOB_COMP_DESC")

                    If JobNumber > 0 Then

                        Dim AlertAssignmentCardDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivAlertAssignmentCard")

                        If AlertAssignmentCardDiv IsNot Nothing Then AlertAssignmentCardDiv.Attributes.Add("oncontextmenu",
                                                                                                           String.Format("UnityRowContextMenuRadListViewAlertAssignmentsDirty('{0}',event);",
                                                                                                                         ListItem.DisplayIndex))

                        Dim JobInformationLabel As Label = e.Item.FindControl("LabelJobInformation")
                        If JobInformationLabel IsNot Nothing Then

                            AdvantageFramework.Web.Presentation.Controls.SetJobInfoForControl(JobInformationLabel.Text, JobInformationLabel.ToolTip,
                                                                                              JobNumber, JobComponentNumber,
                                                                                              JobDescription, JobComponentDescription,
                                                                                              Me._CardSettings.ShowJobNumber, Me._CardSettings.ShowJobComponentNumber,
                                                                                              Me._CardSettings.ShowJobDescription, Me._CardSettings.ShowJobComponentDescription, False)

                        End If

                        AddTimeImageButton.CommandName = "AddTime"
                        AddTimeImageButton.CommandArgument = DataItem("ALERT_ID")

                        StartStopwatchImageButton.CommandName = "StartStopwatch"
                        StartStopwatchImageButton.CommandArgument = DataItem("ALERT_ID")

                    Else

                        JobInformationDiv.Visible = False

                        AddTimeImageButton.Visible = False
                        StartStopwatchImageButton.Visible = False

                    End If

                    Dim BookmarkImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonBookmark")
                    BookmarkImageButton.CommandName = "Bookmark"
                    BookmarkImageButton.CommandArgument = DataItem("ALERT_ID")

                    Dim ReAssignImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonReAssign")
                    Dim StateHeader As HtmlControls.HtmlControl = e.Item.FindControl("HeaderState")

                    If IsDBNull(DataItem("IS_ASSIGNMENT")) = False AndAlso CBool(DataItem("IS_ASSIGNMENT")) = True Then

                        Dim AssignmentQS As New AdvantageFramework.Web.QueryString()

                        AssignmentQS.Page = "Alert_Assignment.aspx"
                        AssignmentQS.AlertID = DataItem("ALERT_ID")

                        ReAssignImageButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", AssignmentQS.ToString(True)))

                        If StateHeader IsNot Nothing Then

                            Dim StateLabel As Label = e.Item.FindControl("LabelState")

                            If StateLabel IsNot Nothing AndAlso IsDBNull(DataItem("ALERT_STATE_NAME")) = False Then

                                StateLabel.Text = DataItem("ALERT_STATE_NAME").ToString() '.ToUpper()

                            End If

                            StateHeader.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))

                        End If

                    Else

                        ReAssignImageButton.Visible = False

                        If StateHeader IsNot Nothing Then

                            StateHeader.Visible = False

                        End If

                    End If

                    Dim CompleteDismissImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonCompleteDismiss")
                    Dim FeedbackSummaryImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonFeedbackSummary")

                    Select Case Me.LoadAlertType
                        Case LoadType.Alerts

                            CompleteDismissImageButton.ToolTip = "Dismiss Alert"
                            CompleteDismissImageButton.ImageUrl = "~/Images/Icons/Grey/256/garbage.png"
                            CompleteDismissImageButton.CommandName = "Dismiss"
                            CompleteDismissImageButton.CommandArgument = DataItem("ALERT_ID")

                        Case LoadType.Assignments

                            CompleteDismissImageButton.ToolTip = "Complete Assignment"
                            CompleteDismissImageButton.ImageUrl = "~/Images/Icons/Grey/256/checkbox.png"
                            CompleteDismissImageButton.CommandName = "Complete"
                            CompleteDismissImageButton.CommandArgument = DataItem("ALERT_ID")

                        Case LoadType.Reviews

                            CompleteDismissImageButton.ToolTip = "Dismiss Review"
                            CompleteDismissImageButton.ImageUrl = "~/Images/Icons/Grey/256/garbage.png"
                            CompleteDismissImageButton.CommandName = "Dismiss"
                            CompleteDismissImageButton.CommandArgument = DataItem("ALERT_ID")

                            FeedbackSummaryImageButton.Visible = True
                            FeedbackSummaryImageButton.CommandName = "FeedbackSummary"

                    End Select

                    If Me.RadComboBoxSortOptions.SelectedItem IsNot Nothing AndAlso Me.RadComboBoxSortOptions.SelectedItem.Value <> "" Then

                        Dim AlertAssignmentCardRadListViewItemDragHandle As RadListViewItemDragHandle = e.Item.FindControl("RadListViewItemDragHandleAlertAssignmentCard")
                        If AlertAssignmentCardRadListViewItemDragHandle IsNot Nothing Then

                            AlertAssignmentCardRadListViewItemDragHandle.Visible = False

                        Else


                        End If

                    End If

                    If Me.IsClientPortal = True Then

                        BookmarkImageButton.Visible = False
                        AddTimeImageButton.Visible = False
                        StartStopwatchImageButton.Visible = False
                        ReAssignImageButton.Visible = False

                    End If

                Catch ex As Exception
                End Try

        End Select

    End Sub
    Private Sub RadListViewAlertAssignmentsDirty_ItemDrop(sender As Object, e As RadListViewItemDragDropEventArgs) Handles RadListViewAlertAssignmentsDirty.ItemDrop

        Dim DestinationHtmlElement As String = e.DestinationHtmlElement

        If DestinationHtmlElement.Contains("RadListViewAlertAssignmentsDirty") = True Then

            Dim ar() As String = DestinationHtmlElement.Split("_")

            If ar IsNot Nothing AndAlso ar.Length > 3 Then

                If IsNumeric(ar(ar.Length - 2).Replace("ctrl", "")) = True Then

                    Dim s As String = ""
                    Dim NewIndex As Integer = ar(ar.Length - 2).Replace("ctrl", "")

                    If NewIndex > 0 Then NewIndex = NewIndex - 1
                    s = SortAlertAssignmentCard(e.DraggedItem.GetDataKeyValue("ALERT_ID"), NewIndex)

                    If s.Trim() = "" Then

                        RadListViewAlertAssignmentsDirty.Rebind()

                    Else

                        Me.ShowMessage(s)

                    End If

                End If

            End If

        Else

            Me.ShowMessage("Please drop the card you are moving directly ONTO an icon or text of a different card to change priority")

        End If

    End Sub
    Private _JustBound As Boolean = False
    Private Sub RadListViewAlertAssignmentsDirty_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewAlertAssignmentsDirty.NeedDataSource

        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        Try

            Me.RadListViewAlertAssignmentsDirty.Items.Clear()
            Dim IncludeBoardLevelItems As Boolean = False

            Dim a As New cAlerts()
            Dim CardDataTable As New DataTable
            Dim LoadType As String = "myalertsandassignments"
            Dim s As String = String.Empty

            Select Case LoadAlertType
                Case DesktopCardsMyAssignments.LoadType.Alerts

                    LoadType = "myalerts"
                    Me.LabelTitle.Text = "Alerts"
                    IncludeBoardLevelItems = True

                Case DesktopCardsMyAssignments.LoadType.Assignments

                    LoadType = "myalertassignments"
                    Me.LabelTitle.Text = "Assignments"

                Case DesktopCardsMyAssignments.LoadType.Reviews

                    LoadType = "myreviews"
                    Me.LabelTitle.Text = "Reviews"

                Case Else

                    LoadType = "myalertsandassignments"
                    Me.LabelTitle.Text = "Alerts and Assignments"

            End Select


            If Me.IsClientPortal = True Then

                CardDataTable = a.LoadAlertsCP(Session("UserID"), "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", LoadType,
                                    0, "", False, False, 0, "", "", 0, False, Nothing, False, s)

            Else

                Try

                    If Me.RadComboBoxSortOptions IsNot Nothing Then

                        If Me.RadComboBoxSortOptions.SelectedItem IsNot Nothing Then

                            Me._SortOption = Me.RadComboBoxSortOptions.SelectedItem.Value

                        Else

                            Try

                                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxSortOptions, Me._SortOption, False)

                            Catch ex As Exception
                            End Try

                        End If

                    End If

                Catch ex As Exception
                    Me._SortOption = ""
                End Try

                'CardDataTable = a.LoadAlerts(Session("EmpCode"), "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", 0, LoadType,
                '                  0, "", False, False, 0, Me._SortOption, "", "", "", 0, 0, False, Nothing, False, IncludeBoardLevelItems, s)

            End If

            If CardDataTable IsNot Nothing Then

                Dim RecordCount As Integer = CardDataTable.Rows.Count

                Me.RadListViewAlertAssignmentsDirty.DataSource = CardDataTable
                Me.RadListViewAlertAssignmentsDirty.PageSize = MiscFN.LoadPageSize(Me.RadListViewAlertAssignmentsDirty.ID & "_" & Me.LoadAlertType.ToString)

                Try

                    If Me.CurrentGridPageIndex > Me.RadListViewAlertAssignmentsDirty.PageCount - 1 Then Me.CurrentGridPageIndex = Me.RadListViewAlertAssignmentsDirty.PageCount - 1

                Catch ex As Exception
                End Try
                Try

                    If Me.CurrentGridPageIndex < 0 Then Me.CurrentGridPageIndex = 0

                Catch ex As Exception
                End Try
                Me.RadListViewAlertAssignmentsDirty.CurrentPageIndex = Me.CurrentGridPageIndex

                Me.RadDataPagerAlertAssignments.Visible = CardDataTable.Rows.Count > 0
                _JustBound = True

            Else

                If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)
                Me.RadListViewAlertAssignmentsDirty.DataSource = Nothing
                Me.RadDataPagerAlertAssignments.Visible = False

            End If

            _LastGroupField = ""

        Catch ex As Exception
            Me.RadListViewAlertAssignmentsDirty.DataSource = Nothing
        End Try

    End Sub

#End Region

    Public Sub LoadData(ByVal LoadMore As Boolean)

        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub
        Me._LoadMore = LoadMore

        Me.RadListViewAlertAssignmentsDirty.Rebind()

    End Sub
    Private Sub LoadSortOptions()

        Me.RadComboBoxSortOptions.Items.Clear()

        Select Case Me.LoadAlertType
            Case LoadType.Alerts

                Dim a As New cAlerts()
                a.LoadAlertGroupingOptions(Me.RadComboBoxSortOptions, cAlerts.AlertGroupingModule.AlertCardsDO)

            Case LoadType.Assignments

                Dim a As New cAlerts()
                a.LoadAlertGroupingOptions(Me.RadComboBoxSortOptions, cAlerts.AlertGroupingModule.AssignmentCardsDO)

            Case LoadType.Reviews

                Dim a As New cAlerts()
                a.LoadAlertGroupingOptions(Me.RadComboBoxSortOptions, cAlerts.AlertGroupingModule.ReviewCardsDO)

            Case Else

                Dim a As New cAlerts()
                a.LoadAlertGroupingOptions(Me.RadComboBoxSortOptions, cAlerts.AlertGroupingModule.AlertCardsDO)

        End Select

        If Me.RadComboBoxSortOptions.Items.Count > 0 Then

            SetSettingsType()

            Dim av As New cAppVars(_App)

            av.getAllAppVars()

            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxSortOptions, av.getAppVar("dflt_wkspc_sort", "String", ""), False)

            Me._SortOption = Me.RadComboBoxSortOptions.SelectedItem.Value

        End If

    End Sub
    Private Function CheckCompleteProjectScheduleAlert(ByVal AlertID As Integer, ByVal Complete As Boolean) As Boolean

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Return AdvantageFramework.ProjectSchedule.MarkTaskCompleteOnAlertDismissed(DbContext, Session("UserCode"), Session("EmpCode"), AlertID, Complete)

            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Shared Function SortAlertAssignmentCard(ByVal AlertId As Integer, ByVal NewPosition As Integer) As String

        Dim UserCode As String = HttpContext.Current.Session("UserCode")
        Dim EmployeeCode As String = HttpContext.Current.Session("EmpCode")
        Dim ConnectionString As String = HttpContext.Current.Session("ConnString")

        Try

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_alerts] '{0}', {1}, {2};",
                                                     EmployeeCode, AlertId, NewPosition))

            End Using

            Return ""

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try

    End Function
    Private Sub SetSettingsType()

        Select Case Me.LoadAlertType
            Case LoadType.Alerts

                _App = cAppVars.Application.ALERT_CARDS

            Case LoadType.Assignments

                _App = cAppVars.Application.ASSIGNMENT_CARDS

            Case LoadType.Reviews

                _App = cAppVars.Application.REVIEW_CARDS

            Case LoadType.AlertsAndAssignments

                _App = cAppVars.Application.ALERT_ASSIGNMENT_CARDS

        End Select

    End Sub
    Private Sub RadDataPagerAlertAssignments_PageIndexChanged(sender As Object, e As RadDataPagerPageIndexChangeEventArgs) Handles RadDataPagerAlertAssignments.PageIndexChanged

        If _JustBound = False Then

            Me.CurrentGridPageIndex = e.NewPageIndex
            Try

                Me.RadListViewAlertAssignmentsDirty.Rebind()

            Catch ex As Exception
                Exit Sub
            End Try

        End If

    End Sub

    Private Sub RadListViewAlertAssignmentsDirty_PageSizeChanged(sender As Object, e As RadListViewPageSizeChangedEventArgs) Handles RadListViewAlertAssignmentsDirty.PageSizeChanged

        If Not Me.IsPostBack AndAlso Not Me.Page.IsCallback Then

        Else

            MiscFN.SavePageSize(Me.RadListViewAlertAssignmentsDirty.ID & "_" & Me.LoadAlertType.ToString, e.NewPageSize)

        End If

    End Sub

#End Region

End Class

'<Serializable()>
'Public Class DirtyInboxResult

'    Public Property ALERT_ID As Integer = 0
'    Public Property SUBJECT As String = ""
'    Public Property GENERATED As Date
'    Public Property USER_NAME As String = ""
'    Public Property PRIORITY As String = ""
'    Public Property TYPE As String = ""
'    Public Property CATEGORY As String = ""
'    Public Property ATTACHMENTCOUNT As Integer = 0
'    Public Property DUE_DATE As String = ""
'    Public Property CL_NAME As String = ""
'    Public Property VERSION As String = ""
'    Public Property BUILD As String = ""
'    Public Property ALERT_STATE_NAME As String = ""
'    Public Property READ_ALERT As Integer = 0
'    Public Property CURRENT_NOTIFY As Integer = 0
'    Public Property IS_CC As Integer = 0
'    Public Property CURRENT_NOTIFY_EMP_CODE As String = ""
'    Public Property CURRENT_NOTIFY_EMP_FML As String = ""
'    Public Property GRP_COMPONENT As String = ""
'    Public Property ID As Integer = 0
'    Public Property IS_ASSIGNMENT As Integer = 0
'    Public Property JOB_NUMBER As Integer = 0
'    Public Property JOB_COMPONENT_NBR As Integer = 0
'    Public Property ALERT_LEVEL_TEXT As String = ""
'    Public Property END_SELECT_CLAUSE As String = ""

'End Class
