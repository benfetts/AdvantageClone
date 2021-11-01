Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports Webvantage.wvTimeSheet

Public Class DesktopCardsMyTasks
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _CardSettings As DesktopCardSettings

#End Region

#Region " Properties "

    Public Javascript As String = "alert('init');"

    Public Sub New()

    End Sub

    Private ReadOnly Property FullyCompleteTask As AdvantageFramework.ProjectSchedule.LookupSettingsOptions
        Get
            If ViewState("FullyCompleteTask") Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ViewState("FullyCompleteTask") = CType(AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempCompleteSetting(DbContext), Integer)

                End Using

            End If

            Return CType(CType(ViewState("FullyCompleteTask"), Integer), AdvantageFramework.ProjectSchedule.LookupSettingsOptions)

        End Get
    End Property
    Private Property _Date As Nullable(Of Date)
        Get
            If ViewState("_Date") Is Nothing Then
                Return Today
            Else
                Return CDate(ViewState("_Date"))
            End If
        End Get
        Set(value As Nullable(Of Date))
            ViewState("_Date") = CDate(value).ToShortDateString()
        End Set
    End Property
    Private Property _RecordCount As Integer
        Get
            If IsNumeric(Me.HiddenFieldRecordCount.Value) = True Then
                Return CType(Me.HiddenFieldRecordCount.Value, Integer)
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            Me.HiddenFieldRecordCount.Value = value
        End Set
    End Property
    Private Property _GroupField As String
        Get
            If Session("DesktopCardsMyTasks_GroupField") Is Nothing Then
                Session("DesktopCardsMyTasks_GroupField") = "END_SELECT_CLAUSE"
            End If
            Return Session("DesktopCardsMyTasks_GroupField")
        End Get
        Set(value As String)
            Session("DesktopCardsMyTasks_GroupField") = value
        End Set
    End Property
    Private Property _LastGroupField As String
        Get
            If Session("DesktopCardsMyTasks_LastGroupField") Is Nothing Then
                Session("DesktopCardsMyTasks_LastGroupField") = "END_SELECT_CLAUSE"
            End If
            Return Session("DesktopCardsMyTasks_LastGroupField")
        End Get
        Set(value As String)
            Session("DesktopCardsMyTasks_LastGroupField") = value
        End Set
    End Property
    Private Property _SortOption As String
        Get
            If Session("DesktopCardsMyTasks_SortOption") Is Nothing Then
                Session("DesktopCardsMyTasks_SortOption") = ""
            End If
            Return Session("DesktopCardsMyTasks_SortOption")
        End Get
        Set(value As String)
            Session("DesktopCardsMyTasks_SortOption") = value
        End Set
    End Property
    Private Property _AllowCardSort As Boolean
        Get
            If ViewState("_AllowCardSort") Is Nothing Then
                ViewState("_AllowCardSort") = False
            End If
            Return ViewState("_AllowCardSort")
        End Get
        Set(value As Boolean)
            ViewState("_AllowCardSort") = value
        End Set
    End Property
    Public Property PageSize As Integer = 20
    Public Property MoreButtonVisible As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)
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
    Private Property CurrentGridPageIndex As Integer
        Get
            If ViewState("CurrentGridPageIndex") Is Nothing Then
                ViewState("CurrentGridPageIndex") = 0
            End If
            Return ViewState("CurrentGridPageIndex")
        End Get
        Set(value As Integer)
            ViewState("CurrentGridPageIndex") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " User Control "

    Private Sub DesktopTileMyTasks_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Me.EventTarget = "SignOut" OrElse Me.EventTarget = "UpdatePanelAlertsAndAssignments" Then Exit Sub
        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        If Not Me.IsPostBack And Not Me.Page.IsCallback Then

            _Date = Today()
            Me.LoadSortOptions()
            Me.LoadData(False)
            Me.MyUnityContextMenu.SetRadListView(Me.RadListViewTasksDirty)

        Else

            Select Case Me.EventTarget

                Case "RebindGrid",
                     "UpdatePanelDefaultWorkspaceLeftMiddle",
                     "UpdatePanelUserTasks", "UpdatePanelDO"

                    Me.LoadData(False)

            End Select

        End If

    End Sub
    Private Sub DesktopCardsMyTasks_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If Me.EventTarget = "SignOut" OrElse Me.EventTarget = "UpdatePanelAlertsAndAssignments" Then Exit Sub
        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        _AllowCardSort = False

        Try
            If Me.RadComboBoxSortOptions.SelectedItem IsNot Nothing Then

                Me._SortOption = Me.RadComboBoxSortOptions.SelectedItem.Value

                Select Case Me.RadComboBoxSortOptions.SelectedItem.Value
                    Case "TASK_STATUS"

                        _GroupField = "ACTIVE_PENDING_TEXT"

                    Case "PRIORITY"

                        _GroupField = "CARD_GROUPING_PRIORITY_TEXT"

                    Case "STARTED"

                        _GroupField = "STARTED"

                    Case "CLIENT"

                        _GroupField = "CL_NAME"

                    Case "CDPJ"

                        _GroupField = "JustJobData"

                    Case "CDPJC"

                        _GroupField = "JobData"

                    Case Else

                        _GroupField = "END_SELECT_CLAUSE"
                        _AllowCardSort = True

                End Select

            End If

            'If _GroupField <> _LastGroupField Then

            For Each item In Me.RadListViewTasksDirty.DataGroups

                item.GroupField = _GroupField
                Exit For

            Next

            _LastGroupField = _GroupField
            Me.RadListViewTasksDirty.Rebind()

            'End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub DesktopCardsMyTasks_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Me.EventTarget = "SignOut" OrElse Me.EventTarget = "UpdatePanelAlertsAndAssignments" Then Exit Sub
        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        If Not Me.Page.IsPostBack AndAlso Not Me.Page.IsCallback Then

            Try

                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Me.TextBoxSearch.Text = otask.getAppVars(Session("UserCode"), "MyTasks", "sSearch")

            Catch ex As Exception
            End Try

        End If

    End Sub

#End Region
#Region " Controls "

    Private Sub CheckBoxOverdue_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOverdue.CheckedChanged

        Me.LoadData(False)

    End Sub

    Private Sub ImageButtonRefreshDesktopCardsMyTasks_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefreshDesktopCardsMyTasks.Click
        Me.LoadData(False)
    End Sub

    Private Sub ImageButtonSearch_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonSearch.Click

        Dim Search As String = Me.TextBoxSearch.Text.Trim()

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "sSearch", "", Search)

        Me.LoadData(False)

    End Sub

    Private Sub RadComboBoxSortOptions_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSortOptions.SelectedIndexChanged

        Me._SortOption = Me.RadComboBoxSortOptions.SelectedItem.Value

        Dim av As New cAppVars(cAppVars.Application.TASK_CARDS)

        av.getAllAppVars()
        av.setAppVar("dflt_wkspc_sort_tasks", Me.RadComboBoxSortOptions.SelectedItem.Value.ToString(), "String")
        av.SaveAllAppVars()

        Me.CurrentGridPageIndex = 0
        Me.RadListViewTasksDirty.Rebind()

    End Sub

    Private Function MarkTempComplete(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                      ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

        Dim MarkedComplete As Boolean = False
        Dim MarkedTempComplete As Boolean = False
        Dim AutoAlertTaskEmployees As Boolean = False
        Dim DatatableTaskSeqNbrThatWereMadeActive As New DataTable
        Dim asm As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)

        MarkedTempComplete = AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, SecurityDbContext, JobNumber, JobComponentNumber, SequenceNumber, Session("EmpCode"), CType(Now, DateTime), MarkedComplete)

        AutoAlertTaskEmployees = asm.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

        If AutoAlertTaskEmployees = True Then

            If Not DatatableTaskSeqNbrThatWereMadeActive Is Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                Dim ThisSeqNbr As Integer = 0

                Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
                Dim EmpCodeString As String = ""
                Dim NewAlertId As Integer = 0

                For j As Integer = 0 To DatatableTaskSeqNbrThatWereMadeActive.Rows.Count - 1

                    ThisSeqNbr = CType(DatatableTaskSeqNbrThatWereMadeActive.Rows(j)("SEQ_NBR"), Integer)

                    NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, JobNumber, JobComponentNumber, SequenceNumber, HttpContext.Current.Session("EmpCode"), EmpCodeString)

                    If NewAlertId > 0 Then

                        Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                                                                  HttpContext.Current.Session("UserCode"),
                                                                                  _Session,
                                                                                  HttpContext.Current.Session("WebvantageURL"),
                                                                                  HttpContext.Current.Session("ClientPortalURL"))
                        With eso

                            .AlertId = NewAlertId
                            .Subject = "[Alert Updated]"
                            .EmployeeCodesToSendEmailTo = EmpCodeString
                            .IsClientPortal = MiscFN.IsClientPortal
                            .IncludeOriginator = False

                        End With

                        eso.SendEmailOnSeparateThread()

                    End If

                    EmpCodeString = ""
                    NewAlertId = 0

                Next

            End If

        End If

        Return MarkedTempComplete

    End Function
    Private Sub RadListViewTasksDirty_ItemCommand(sender As Object, e As RadListViewCommandEventArgs) Handles RadListViewTasksDirty.ItemCommand

        Dim ThisItem As RadListViewDataItem = e.ListViewItem
        Dim JobNumber As Integer = 0
        Dim JobComponentNumber As Short = 0
        Dim SequenceNumber As Short = -1
        Dim EventTaskID As Integer = 0
        Dim AlertID As Integer = 0

        Try

            JobNumber = ThisItem.GetDataKeyValue("JobNo")

        Catch ex As Exception
            JobNumber = 0
        End Try
        Try

            JobComponentNumber = ThisItem.GetDataKeyValue("JobComp")

        Catch ex As Exception
            JobComponentNumber = 0
        End Try
        Try

            SequenceNumber = ThisItem.GetDataKeyValue("SeqNo")

        Catch ex As Exception
            SequenceNumber = -1
        End Try
        Try

            EventTaskID = ThisItem.GetDataKeyValue("EVENT_TASK_ID")

        Catch ex As Exception
            EventTaskID = 0
        End Try
        Try

            AlertID = ThisItem.GetDataKeyValue("ALERT_ID")

        Catch ex As Exception
            AlertID = 0
        End Try
        Select Case e.CommandName
            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                'qs = qs.FromCurrent()
                qs.Add("pop", "1")
                qs.Add("form", "DTO")
                qs.Add("JobNum", JobNumber.ToString())
                qs.Add("JobComp", JobComponentNumber.ToString())
                qs.Add("SeqNum", SequenceNumber.ToString())
                qs.Add("EmpCode", Session("EmpCode"))

                Dim c, d, p As String
                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                oTS.GetJobInfo(JobNumber, "", "", c, d, p)

                qs.Add("Client", c)
                qs.Add("Division", d)
                qs.Add("Product", p)

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_Task
                    .UserCode = Session("UserCode")
                    .Name = "Task: " & JobNumber.ToString() & "/" & JobComponentNumber.ToString() & "/" & SequenceNumber.ToString()
                    .Description = CType(e.ListViewItem.FindControl("HiddenFieldTaskDescription"), HiddenField).Value & " for " & CType(e.ListViewItem.FindControl("HiddenFieldJobData"), HiddenField).Value
                    .PageURL = "TrafficSchedule_TaskDetail.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

            Case "MarkTempComplete"

                Dim t As cTasks = New cTasks(CStr(Session("ConnString")))
                Dim IsEventTask As Boolean = False
                Dim Marked As Boolean = False

                IsEventTask = EventTaskID > 0

                If IsEventTask = False Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Select Case e.CommandArgument
                                Case "Mark"

                                    If Me.MarkTempComplete(DbContext, SecurityDbContext, JobNumber, JobComponentNumber, SequenceNumber) = True Then

                                        Me.LoadData(False)

                                    End If

                                Case "MarkNoPrompt"

                                    If Me.MarkTempComplete(DbContext, SecurityDbContext, JobNumber, JobComponentNumber, SequenceNumber) = True Then

                                        If AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, JobNumber, JobComponentNumber, SequenceNumber,
                                                                                                                HttpContext.Current.Session("EmpCode"), MiscFN.IsClientPortal) Then

                                        End If

                                        Me.LoadData(False)

                                    End If

                                Case "MarkWithPrompt"

                                    If Me.MarkTempComplete(DbContext, SecurityDbContext, JobNumber, JobComponentNumber, SequenceNumber) = True Then

                                        If AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, JobNumber, JobComponentNumber, SequenceNumber,
                                                                                                                HttpContext.Current.Session("EmpCode"), MiscFN.IsClientPortal) Then

                                            Me.ShowMessage("Task will be completed if you were the last employee to temp complete")

                                        End If

                                        Me.LoadData(False)

                                    End If

                                Case "MarkNot", "Unmark"

                                    AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, SecurityDbContext, JobNumber, JobComponentNumber, SequenceNumber, Session("EmpCode"), Nothing)
                                    Me.LoadData(False)

                            End Select

                        End Using

                    End Using

                Else

                    Dim SQL As String = "UPDATE EVENT_TASK WITH(ROWLOCK) SET TEMP_COMP_DATE = @TempCompDate WHERE EVENT_TASK_ID = @EventTaskId"

                    Try
                        Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))

                            MyConn.Open()

                            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                            Dim MyCmd As New SqlCommand(SQL, MyConn, MyTrans)

                            With MyCmd
                                If e.CommandArgument = "Mark" Then

                                    .Parameters.AddWithValue("@TempCompDate", Today.Date)

                                ElseIf e.CommandArgument = "Mark Not" Then

                                    .Parameters.AddWithValue("@TempCompDate", DBNull.Value)

                                End If

                                .Parameters.AddWithValue("@EventTaskId", EventTaskID)

                            End With

                            Try

                                MyCmd.ExecuteNonQuery()
                                MyTrans.Commit()

                            Catch ex As Exception

                                MyTrans.Rollback()

                            Finally

                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                                Me.LoadData(False)

                            End Try

                        End Using
                    Catch ex As Exception

                    End Try

                End If

            Case "StartStopwatch"

                Dim Controller As New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)
                Dim Message As String = String.Empty

                If Controller.CanAddTimeToJob(JobNumber, JobComponentNumber, Message) = True Then

                    Dim s As String = ""

                    If AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), JobNumber, JobComponentNumber, SequenceNumber, AlertID, s) = True Then

                        Me.OpenTimesheetStopwatchNotificationWindow()

                    Else

                        Me.ShowMessage(s)

                    End If

                    Me.RadListViewTasksDirty.Rebind()

                Else

                    If String.IsNullOrWhiteSpace(Message) = False Then

                        Me.ShowMessage(Message)

                    Else

                        Me.ShowMessage("Job/Component Process Control does not allow access.")

                    End If

                End If

            Case "AddTime"

                Dim Controller As New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)
                Dim Message As String = String.Empty

                If Controller.CanAddTimeToJob(JobNumber, JobComponentNumber, Message) = True Then

                    Dim URL As String = String.Empty
                    Dim QsAddTime As New AdvantageFramework.Web.QueryString

                    Me.OpenWindow("Add Time", String.Format("Employee/Timesheet/Entry?a={0}&j={1}&jc={2}&s={3}",
                                                            AlertID, JobNumber, JobComponentNumber, SequenceNumber), 600, 600)

                Else

                    If String.IsNullOrWhiteSpace(Message) = False Then

                        Me.ShowMessage(Message)

                    Else

                        Me.ShowMessage("Job/Component Process Control does not allow access.")

                    End If

                End If

        End Select

    End Sub
    Private Sub RadListViewTasksDirty_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewTasksDirty.ItemDataBound

        If _CardSettings Is Nothing Then

            Dim av As New cAppVars(cAppVars.Application.TASK_CARDS)
            av.getAllAppVars()
            Try

                _CardSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

            Catch ex As Exception
                _CardSettings = Nothing
            End Try

            If _CardSettings Is Nothing Then _CardSettings = New DesktopCardSettings

        End If

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
                Try

                    Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)
                    Dim DataItem = ListItem.DataItem
                    Dim TaskDescription As String = String.Empty
                    Dim JobDescription As String = String.Empty
                    Dim JobComponentDescription As String = String.Empty
                    Dim JobData As String = String.Empty
                    Dim JobNumber As Integer = 0
                    Dim JobComponentNumber As Short = 0

                    If DataItem("JobNo") IsNot System.DBNull.Value Then JobNumber = DataItem("JobNo")
                    If DataItem("JobComp") IsNot System.DBNull.Value Then JobComponentNumber = DataItem("JobComp")
                    If DataItem("JOB_DESC") IsNot System.DBNull.Value Then JobDescription = DataItem("JOB_DESC")
                    If DataItem("JOB_COMP_DESC") IsNot System.DBNull.Value Then JobComponentDescription = DataItem("JOB_COMP_DESC")
                    If DataItem("Task") IsNot System.DBNull.Value Then TaskDescription = DataItem("Task")
                    If DataItem("JobData") IsNot System.DBNull.Value Then JobData = DataItem("JobData")

                    'Dim DragScript As String = String.Format("$find('{0}')._itemDrag._dragHandleMouseDown(event, {1})", RadListViewTasksDirty.ClientID, ListItem.DisplayIndex)
                    Dim TaskCardDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivTaskCard")

                    If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                        If TaskCardDiv IsNot Nothing Then TaskCardDiv.Attributes.Add("oncontextmenu",
                                                                                     String.Format("UnityRowContextMenuRadListViewTasksDirty('{0}',event);", ListItem.DisplayIndex))
                    End If

                    Dim TaskDescriptionLabel As Label = e.Item.FindControl("LabelTaskDescription")
                    If TaskDescriptionLabel IsNot Nothing Then

                        TaskDescriptionLabel.Text = AdvantageFramework.StringUtilities.Truncate(TaskDescription.ToString(), 25)
                        TaskDescriptionLabel.ToolTip = TaskDescription

                    End If

                    Dim JobDataLabel As Label = e.Item.FindControl("LabelJobData")
                    If JobDataLabel IsNot Nothing Then

                        AdvantageFramework.Web.Presentation.Controls.SetJobInfoForControl(JobDataLabel.Text, JobDataLabel.ToolTip,
                                                                                          JobNumber, JobComponentNumber,
                                                                                          JobDescription, JobComponentDescription,
                                                                                          Me._CardSettings.ShowJobNumber, Me._CardSettings.ShowJobComponentNumber,
                                                                                          Me._CardSettings.ShowJobDescription, Me._CardSettings.ShowJobComponentDescription, False)

                    End If

                    Dim ClientNameLabel As Label = e.Item.FindControl("LabelClientName")
                    If ClientNameLabel IsNot Nothing Then

                        ClientNameLabel.Visible = False

                        If Me._CardSettings.ShowClientName = True Then

                            Dim ClientName As String = ""
                            If DataItem("CL_NAME") IsNot System.DBNull.Value Then ClientName = DataItem("CL_NAME")

                            If String.IsNullOrWhiteSpace(ClientName) = False Then

                                ClientNameLabel.Visible = True
                                ClientNameLabel.Text = ClientName & "<br />"

                            End If

                        End If

                    End If

                    Dim TaskCommentLabel As Label = e.Item.FindControl("LabelTaskComment")
                    If TaskCommentLabel IsNot Nothing Then

                        TaskCommentLabel.Visible = False

                        If Me._CardSettings.ShowTaskComment = True Then

                            Dim TaskComment As String = ""
                            If DataItem("FNC_COMMENTS") IsNot System.DBNull.Value Then TaskComment = DataItem("FNC_COMMENTS")

                            If String.IsNullOrWhiteSpace(TaskComment) = False Then

                                TaskCommentLabel.Visible = True
                                TaskCommentLabel.ToolTip = TaskComment
                                TaskCommentLabel.Text = TaskComment & "<br />"

                            End If

                        End If

                    End If

                    Dim IsTempComplete As Boolean = False

                    IsTempComplete = DataItem("TempCompleteDate") IsNot System.DBNull.Value

                    Dim CardContentDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivCardContent")

                    If IsTempComplete = True Then CardContentDiv.Attributes.Add("style", "text-decoration:line-through;")

                    If DataItem("TASK_STATUS") IsNot System.DBNull.Value Then

                        Select Case DataItem("TASK_STATUS").ToString().ToUpper()
                            Case "A"

                                TaskCardDiv.Attributes.Add("class", "card task-card rlvI card-edge-task-priority-active")

                            Case "P"

                                TaskCardDiv.Attributes.Add("class", "card task-card rlvI card-edge-task-priority-pending")

                            Case "H"

                                TaskCardDiv.Attributes.Add("class", "card task-card rlvI card-edge-alert-priority-high")

                            Case "L"

                                TaskCardDiv.Attributes.Add("class", "card task-card rlvI card-edge-alert-priority-low")

                            Case Else

                                TaskCardDiv.Attributes.Add("class", "card task-card rlvI card-edge-alert-priority-normal")

                        End Select

                    Else

                        TaskCardDiv.Attributes.Add("class", "card task-card rlvI card-edge-task-priority-pending")

                    End If

                    Dim DateContainerDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivDateContainer")
                    Dim StartDateLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelStartDate")
                    Dim DueDateLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelDueDate")

                    Dim HasStartDate As Boolean = False
                    Dim StartDateString As String = ""
                    If DataItem("StartDate") IsNot System.DBNull.Value Then

                        HasStartDate = True
                        StartDateString = "Start: " & String.Format("{0:d}", DataItem("StartDate"))

                    End If

                    Dim HasDueDate As Boolean = False
                    Dim DueDateString As String = ""
                    If DataItem("DueDate") IsNot System.DBNull.Value Then

                        HasDueDate = True
                        DueDateString = String.Format("{0:d}", DataItem("DueDate"))

                    End If

                    Dim HasDueTime As Boolean = False
                    Dim DueTimeString As String = ""
                    If DataItem("DueTime") IsNot System.DBNull.Value AndAlso DataItem("DueTime").ToString() <> "" Then

                        If HasDueDate = True Then

                            HasDueTime = True
                            DueTimeString = DataItem("DueTime")

                        End If

                    End If

                    If HasStartDate = False And HasDueDate = False And HasDueTime = False Then

                        DateContainerDiv.Visible = False

                    Else

                        If HasStartDate = True Then

                            StartDateLabel.Text = StartDateString

                        Else

                            StartDateLabel.Visible = False

                        End If

                        If HasDueDate = True And HasDueTime = True Then

                            StartDateLabel.Text = StartDateLabel.Text & "; "
                            DueDateLabel.Text = "Due: " & DueDateString & ", " & DueTimeString

                        ElseIf HasDueDate = True And HasDueTime = False Then

                            StartDateLabel.Text = StartDateLabel.Text & ", "
                            DueDateLabel.Text = "Due: " & DueDateString

                        ElseIf HasDueDate = False And HasDueTime = True Then

                            StartDateLabel.Text = StartDateLabel.Text & ", "
                            DueDateLabel.Text = "Due: " & DueTimeString

                        ElseIf HasDueDate = False And HasDueTime = False Then

                            DueDateLabel.Visible = False

                        End If

                        If HasDueDate = True AndAlso DataItem("DueDate") IsNot System.DBNull.Value AndAlso CDate(DataItem("DueDate")) < Now.Date Then

                            DueDateLabel.CssClass = "task-due-overdue"

                        End If

                    End If

                    If DataItem("JobNo") IsNot System.DBNull.Value AndAlso DataItem("JobComp") IsNot System.DBNull.Value AndAlso DataItem("SeqNo") IsNot System.DBNull.Value _
                            AndAlso DataItem("EVENT_TASK_ID") IsNot System.DBNull.Value Then

                        Dim CommandArgString As String = DataItem("JobNo") & "," &
                                                             DataItem("JobComp") & "," &
                                                             DataItem("SeqNo") & "," &
                                                             DataItem("EVENT_TASK_ID")

                        Dim CDP() As String
                        CDP = DataItem("CDP").ToString().Split("/")

                        Dim ThisRow_DataKey As String = "DTO|0|2|3|4|" & DataItem("JobNo") & "|" &
                                                             DataItem("JobComp") & "|" &
                                                             DataItem("SeqNo") & "|8|" &
                                                             DataItem("EmpCode") & "|" &
                                                             CDP(0).Trim & "|" &
                                                             CDP(1).Trim & "|" &
                                                             CDP(2).Trim

                        Dim IsEventTask As Boolean = False
                        Try

                            If DataItem("IS_EVENT") = 1 Then

                                IsEventTask = True

                            End If

                        Catch ex As Exception
                            IsEventTask = False
                        End Try

                        Dim ActionImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonBookmark")
                        If ActionImageButton IsNot Nothing Then

                            ActionImageButton.CommandName = "Bookmark"
                            ActionImageButton.CommandArgument = CommandArgString

                            If Me.IsClientPortal = True Then
                                ActionImageButton.Visible = False
                            End If

                        End If

                        Dim TaskDescriptionHeader As HtmlControls.HtmlGenericControl = e.Item.FindControl("HeaderTaskDescription")
                        Dim TaskDetailsDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivTaskDetails")
                        Dim DetailsOpenWindowString As String = String.Empty
                        Try

                            If IsEventTask = False Then

                                Try

                                    If CType(DataItem("ALERT_ID"), Integer) > 0 Then

                                        Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                                        QsViewDetails.Page = "Desktop_AlertView"
                                        QsViewDetails.Add("AlertID", DataItem("ALERT_ID").ToString)
                                        QsViewDetails.Add("SprintID", DataItem("SPRINT_ID").ToString)

                                        TaskDescriptionHeader.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))
                                        TaskDetailsDiv.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))

                                        DetailsOpenWindowString = String.Empty

                                    Else

                                        DetailsOpenWindowString = Me.HookUpOpenDetailWindow(ThisRow_DataKey)

                                    End If

                                Catch ex As Exception
                                    DetailsOpenWindowString = Me.HookUpOpenDetailWindow(ThisRow_DataKey)
                                End Try

                            Else

                                If IsNumeric(DataItem("EVENT_TASK_ID")) = True Then

                                    DetailsOpenWindowString = Me.HookUpOpenWindow("", "Event_Task_Detail.aspx?etid=" & DataItem("EVENT_TASK_ID").ToString())

                                End If

                                TaskCardDiv.Attributes.Add("class", "card task-card rlvI card-edge-calendar-event-task")

                            End If

                            If String.IsNullOrWhiteSpace(DetailsOpenWindowString) = False Then

                                TaskDescriptionHeader.Attributes.Add("onclick", DetailsOpenWindowString)
                                TaskDetailsDiv.Attributes.Add("onclick", DetailsOpenWindowString)

                            End If

                        Catch ex As Exception
                        End Try

                        ActionImageButton = e.Item.FindControl("ImageButtonMarkTempComplete")
                        If ActionImageButton IsNot Nothing Then

                            If Me.IsClientPortal = True Then

                                ActionImageButton.Visible = Not Me.IsClientPortal

                            Else

                                ActionImageButton.CommandName = "MarkTempComplete"

                                If IsTempComplete = True Then

                                    ActionImageButton.ImageUrl = "~/Images/Icons/Color/256/undo.png"
                                    ActionImageButton.ToolTip = "Mark not temp completed"
                                    ActionImageButton.CommandArgument = "MarkNot"

                                Else

                                    Select Case FullyCompleteTask

                                        Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Yes

                                            ActionImageButton.CommandArgument = "MarkNoPrompt"

                                        Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Prompt

                                            ActionImageButton.CommandArgument = "MarkWithPrompt"

                                        Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.No

                                            ActionImageButton.CommandArgument = "Mark"

                                    End Select

                                End If

                            End If

                        End If

                        ActionImageButton = e.Item.FindControl("ImageButtonAddTime")
                        If ActionImageButton IsNot Nothing Then

                            If Me.IsClientPortal = True Then

                                ActionImageButton.Visible = False

                            Else

                                ActionImageButton.CommandName = "AddTime"
                                ActionImageButton.CommandArgument = CommandArgString

                            End If

                        End If

                        ActionImageButton = e.Item.FindControl("ImageButtonStartStopwatch")
                        If ActionImageButton IsNot Nothing Then


                            If Me.IsClientPortal = True Then

                                ActionImageButton.Visible = False

                            Else

                                ActionImageButton.CommandName = "StartStopwatch"
                                ActionImageButton.CommandArgument = CommandArgString

                            End If

                        End If

                    End If

                    If Me.RadComboBoxSortOptions.SelectedItem IsNot Nothing AndAlso Me.RadComboBoxSortOptions.SelectedItem.Value <> "" Then

                        Dim TaskCardRadListViewItemDragHandle As RadListViewItemDragHandle = e.Item.FindControl("RadListViewItemDragHandleTaskCard")
                        If TaskCardRadListViewItemDragHandle IsNot Nothing Then TaskCardRadListViewItemDragHandle.Visible = False

                    End If

                Catch ex As Exception
                End Try

        End Select
    End Sub
    Private _JustBound As Boolean = False
    Private Sub RadListViewTasksDirty_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewTasksDirty.NeedDataSource

        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        Try

            If _Date Is Nothing Then _Date = Today

            Me.RadListViewTasksDirty.Items.Clear()

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
                Dim dt As New DataTable
                Dim TaskType As String = ""
                Dim TaskShow As String = "All"
                Dim SearchValue As String = ""

                Try

                    TaskType = otask.getAppVars(Session("UserCode"), "MyTasks", "ddType")

                Catch ex As Exception

                    TaskType = ""

                End Try

                Select Case (TaskType.ToUpper)
                    Case "PROJECTED"

                        TaskType = "P"

                    Case "ACTIVE"

                        TaskType = "A"

                    Case "H"

                        TaskType = "H"

                    Case "L"

                        TaskType = "L"

                    Case "EVENT_TASKS"

                        TaskType = "E"

                    Case "ALL"

                        TaskType = ""

                    Case Else

                        TaskType = ""

                End Select

                Try

                    TaskShow = otask.getAppVars(Session("UserCode"), "MyTasks", "ddTaskShow")

                Catch ex As Exception

                    TaskShow = ""

                End Try

                If TaskShow = "" Then TaskShow = "All"

                Try

                    SearchValue = otask.getAppVars(Session("UserCode"), "MyTasks", "sSearch")

                Catch ex As Exception

                    SearchValue = ""

                End Try

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

                dt = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), TaskType, TaskShow, SearchValue,
                                  Me.IsClientPortal, Session("UserID"), Me._SortOption)

                If dt.Rows.Count > 0 Then

                    For i As Integer = 0 To dt.Rows.Count - 1

                        If IsDBNull(dt.Rows(i)("FNC_COMMENTS")) = False Then dt.Rows(i)("FNC_COMMENTS") = dt.Rows(i)("FNC_COMMENTS").ToString().Replace(Environment.NewLine, "<br />")

                    Next

                End If

                ''Try

                ''    If dt IsNot Nothing AndAlso dt.Rows.Count Then Me.RadComboBoxSortOptions.Enabled = dt.Rows.Count > 0

                ''Catch ex As Exception
                ''    Me.RadComboBoxSortOptions.Enabled = True
                ''End Try

                Me.RadListViewTasksDirty.DataSource = dt
                Me.RadListViewTasksDirty.PageSize = MiscFN.LoadPageSize(Me.RadListViewTasksDirty.ID)

                Try

                    If Me.CurrentGridPageIndex > Me.RadListViewTasksDirty.PageCount - 1 Then Me.CurrentGridPageIndex = Me.RadListViewTasksDirty.PageCount - 1

                Catch ex As Exception
                End Try
                Try

                    If Me.CurrentGridPageIndex < 0 Then Me.CurrentGridPageIndex = 0

                Catch ex As Exception
                End Try

                Me.RadListViewTasksDirty.CurrentPageIndex = Me.CurrentGridPageIndex

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    Me.RadDataPagerTasks.Visible = True

                Else

                    Me.RadDataPagerTasks.Visible = False

                End If
                _JustBound = True

                _LastGroupField = ""

            End Using

        Catch ex As Exception
            Me.RadListViewTasksDirty.DataSource = Nothing
        End Try

    End Sub
    Private Sub RadListViewTasksDirty_ItemDrop(sender As Object, e As RadListViewItemDragDropEventArgs) Handles RadListViewTasksDirty.ItemDrop

        Dim DestinationHtmlElement As String = e.DestinationHtmlElement

        If DestinationHtmlElement.Contains("RadListViewTasksDirty") = True Then

            'Me.ShowMessage(DestinationHtmlElement)
            Dim ar() As String = DestinationHtmlElement.Split("_")

            If ar IsNot Nothing AndAlso ar.Length > 3 Then

                If IsNumeric(ar(ar.Length - 2).Replace("ctrl", "")) = True Then

                    Dim s As String = ""
                    Dim NewIndex As Integer = ar(ar.Length - 2).Replace("ctrl", "")

                    If NewIndex > 0 Then NewIndex = NewIndex - 1
                    s = SortTaskCard(e.DraggedItem.GetDataKeyValue("JobNo"), e.DraggedItem.GetDataKeyValue("JobComp"), e.DraggedItem.GetDataKeyValue("SeqNo"),
                                                    e.DraggedItem.GetDataKeyValue("EVENT_TASK_ID"), NewIndex)

                    If s.Trim() = "" Then

                        RadListViewTasksDirty.Rebind()

                    Else

                        Me.ShowMessage(s)

                    End If

                End If

            End If

        Else

            Me.ShowMessage("Please drop the card you are moving directly ONTO an icon or text of a different card to change priority")

        End If

    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = Me.RadListViewTasksDirty.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobNo")
        Me.MyUnityContextMenu.JobComponentNumber = Me.RadListViewTasksDirty.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobComp")
        Me.MyUnityContextMenu.AlertID = Me.RadListViewTasksDirty.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("ALERT_ID")

    End Sub

#End Region

    Public Sub LoadData(ByVal LoadMore As Boolean)

        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub
        Try

            Me.RadListViewTasksDirty.Rebind()
            'Me.RefreshTasks()

            '''    If _Date Is Nothing Then _Date = Today

            '''    If LoadMore = True Or _RecordCount = 0 Then

            '''        _RecordCount += PageSize

            '''    End If
            '''    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

            '''        '''''Dim FullList As New Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTaskComplex)
            '''        Dim TaskType As String = ""
            '''        Dim TaskShow As String = "All"
            '''        Dim SearchValue As String = ""

            '''        Dim otask As cTasks = New cTasks(Session("ConnString"))
            '''        Try
            '''            TaskType = otask.getAppVars(Session("UserCode"), "MyTasks", "ddType")
            '''        Catch ex As Exception
            '''            TaskType = ""
            '''        End Try
            '''        Select Case (TaskType.ToUpper)
            '''            Case "PROJECTED"
            '''                TaskType = "P"
            '''            Case "ACTIVE"
            '''                TaskType = "A"
            '''            Case "H"
            '''                TaskType = "H"
            '''            Case "L"
            '''                TaskType = "L"
            '''            Case "EVENT_TASKS"
            '''                TaskType = "E"
            '''            Case "ALL"
            '''                TaskType = ""
            '''            Case Else
            '''                TaskType = ""
            '''        End Select

            '''        Try
            '''            TaskShow = otask.getAppVars(Session("UserCode"), "MyTasks", "ddTaskShow")
            '''        Catch ex As Exception
            '''            TaskShow = ""
            '''        End Try
            '''        If TaskShow = "" Then TaskShow = "All"

            '''        Try
            '''            SearchValue = otask.getAppVars(Session("UserCode"), "MyTasks", "sSearch")
            '''        Catch ex As Exception
            '''            SearchValue = ""
            '''        End Try

            '''        '''''FullList = AdvantageFramework.Database.Procedures.EmployeeTaskComplex.Load(DbContext, Session("UserCode"), Session("EmpCode"),
            '''        '''''                                                                           _Date, TaskType, TaskShow, SearchValue,
            '''        '''''                                                                           MiscFN.IsClientPortal, Session("UserID")).ToList()

            '''        '''''If FullList IsNot Nothing Then

            '''        '''''    If Me.CheckBoxOverdue.Checked = True OrElse Me.TextBoxSearch.Text.Length > 0 Then

            '''        '''''        Dim FilteredList As New Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTaskComplex)

            '''        '''''        If Me.CheckBoxOverdue.Checked = True Then

            '''        '''''            FilteredList = (From EmployeeTaskComplex In FullList
            '''        '''''                            Where (EmployeeTaskComplex.DueDate IsNot Nothing AndAlso EmployeeTaskComplex.DueDate < Today.Date)
            '''        '''''                            Select EmployeeTaskComplex).ToList()

            '''        '''''        End If
            '''        '''''        If Me.TextBoxSearch.Text.Length > 0 Then

            '''        '''''            FilteredList = (From EmployeeTaskComplex In FilteredList
            '''        '''''                            Where EmployeeTaskComplex.TaskDescription.Contains(Me.TextBoxSearch.Text) _
            '''        '''''                        OrElse EmployeeTaskComplex.JobDescription.Contains(Me.TextBoxSearch.Text) _
            '''        '''''                        OrElse EmployeeTaskComplex.JobComponentDescription.Contains(Me.TextBoxSearch.Text)
            '''        '''''                            Select EmployeeTaskComplex).ToList()

            '''        '''''        End If

            '''        '''''        Me.RepeaterMyTasks.DataSource = FilteredList

            '''        '''''    Else

            '''        '''''        Me.RepeaterMyTasks.DataSource = FullList

            '''        '''''    End If

            '''        '''''    Me.RepeaterMyTasks.DataBind()

            '''        '''''End If

            '''        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            '''        Dim dt As New DataTable

            '''        dt = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), TaskType, TaskShow, SearchValue, Me.IsClientPortal, Session("UserID"))

            '''        If dt.Rows.Count > 0 Then
            '''            For i As Integer = 0 To dt.Rows.Count - 1
            '''                If IsDBNull(dt.Rows(i)("FNC_COMMENTS")) = False Then
            '''                    dt.Rows(i)("FNC_COMMENTS") = dt.Rows(i)("FNC_COMMENTS").ToString().Replace(Environment.NewLine, "<br />")
            '''                End If
            '''            Next
            '''        End If

            '''        Me.RepeaterMyTasksDirty.DataSource = dt
            '''        Me.RepeaterMyTasksDirty.DataBind()

            '''    End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadSortOptions()

        Me.RadComboBoxSortOptions.Items.Clear()
        Me.RadComboBoxSortOptions.Width = New Unit(180, UnitType.Pixel)
        Me.RadComboBoxSortOptions.TabIndex = -1

        Dim NewItem As RadComboBoxItem

        NewItem = New RadComboBoxItem
        NewItem.Text = "Custom"
        NewItem.Value = ""
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Priority"
        NewItem.Value = "PRIORITY"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Due Date (Desc)"
        NewItem.Value = "DUE_DATE"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Due Date (Asc)"
        NewItem.Value = "DUE_DATE_ASC"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Start Date"
        NewItem.Value = "START_DATE"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Task Status"
        NewItem.Value = "TASK_STATUS"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Gut % Complete"
        NewItem.Value = "PERCENT_COMPLETE"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Started"
        NewItem.Value = "STARTED"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Client"
        NewItem.Value = "CLIENT"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Job"
        NewItem.Value = "CDPJ"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        NewItem = New RadComboBoxItem
        NewItem.Text = "Job/Component"
        NewItem.Value = "CDPJC"
        Me.RadComboBoxSortOptions.Items.Add(NewItem)

        Dim av As New cAppVars(cAppVars.Application.TASK_CARDS)
        av.getAllAppVars()

        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxSortOptions, av.getAppVar("dflt_wkspc_sort_tasks", "String", ""), False)

        Me._SortOption = Me.RadComboBoxSortOptions.SelectedItem.Value

    End Sub
    Public Shared Function SortTaskCard(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                        ByVal EventTaskID As Integer, ByVal NewPosition As Integer) As String

        Dim UserCode As String = HttpContext.Current.Session("UserCode")
        Dim EmployeeCode As String = HttpContext.Current.Session("EmpCode")
        Dim ConnectionString As String = HttpContext.Current.Session("ConnString")

        Try

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_tasks] '{0}', '{1}', {2}, {3}, {4}, {5}, {6}, 0;",
                                                     UserCode, EmployeeCode, JobNumber, JobComponentNumber, TaskSequenceNumber, EventTaskID, NewPosition))

            End Using

            Return ""

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try

    End Function

    Private Sub RadDataPagerTasks_PageIndexChanged(sender As Object, e As RadDataPagerPageIndexChangeEventArgs) Handles RadDataPagerTasks.PageIndexChanged

        If _JustBound = False Then

            Me.CurrentGridPageIndex = e.NewPageIndex
            Try

                Me.RadListViewTasksDirty.Rebind()

            Catch ex As Exception
                Exit Sub
            End Try

        End If

    End Sub

    Private Sub RadListViewTasksDirty_PageSizeChanged(sender As Object, e As RadListViewPageSizeChangedEventArgs) Handles RadListViewTasksDirty.PageSizeChanged

        If Not Me.IsPostBack AndAlso Not Me.Page.IsCallback Then

        Else

            MiscFN.SavePageSize(Me.RadListViewTasksDirty.ID, e.NewPageSize)

        End If

    End Sub

#End Region

End Class
