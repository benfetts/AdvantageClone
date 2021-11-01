Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Public Class DesktopCardsMyCalendar
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _StartDate As Date = Now.Date
    Private _EndDate As Date = Now.Date
    Private _CalendarItem As AdvantageFramework.Database.Classes.CalendarItem
    Private _CardSettings As DesktopCardSettings

#End Region

#Region " Properties "

    Public Property ShowTasks As Boolean = True
    Private Property _CalendarItems As New Generic.List(Of AdvantageFramework.Database.Classes.CalendarItem)

#End Region

#Region " Methods "

    Private Sub DesktopTileMyCalendar_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Me.EventTarget = "SignOut" OrElse Me.EventTarget = "UpdatePanelAlertsAndAssignments" Then Exit Sub

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.LoadData()
            Me.MyUnityContextMenu.SetCardRepeater(Me.RepeaterMyCalendar)

            Try

                Me.ImageButtonAdd.Visible = Me.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Desktop_Calendar)

            Catch ex As Exception
            End Try

        Else

            Select Case Me.EventTarget

                Case "RebindGrid",
                     "UpdatePanelRight",
                     "UpdatePanelUserTasks"

                    Me.LoadData()

            End Select

        End If

    End Sub

    Private Sub RepeaterMyCalendar_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RepeaterMyCalendar.ItemCommand

        Dim job As Integer = 0
        Dim jobcomp As Integer = 0
        Dim seqno As Integer = -1
        Dim EventTaskID As Integer = 0
        Try
            job = CType(e.Item.FindControl("HiddenFieldJobNumber"), HiddenField).Value
        Catch ex As Exception
            job = 0
        End Try
        Try
            jobcomp = CType(e.Item.FindControl("HiddenFieldJobComponentNumber"), HiddenField).Value
        Catch ex As Exception
            jobcomp = 0
        End Try
        Try
            seqno = CType(e.Item.FindControl("HiddenFieldTaskSequenceNumber"), HiddenField).Value
        Catch ex As Exception
            seqno = -1
        End Try
        Try
            EventTaskID = CType(e.Item.FindControl("HiddenFieldEventTaskID"), HiddenField).Value
        Catch ex As Exception
            EventTaskID = 0
        End Try

        Select Case e.CommandName
            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                'qs = qs.FromCurrent()
                qs.Add("pop", "1")
                qs.Add("form", "DTO")
                qs.Add("JobNum", job.ToString())
                qs.Add("JobComp", jobcomp.ToString())
                qs.Add("SeqNum", seqno.ToString())
                qs.Add("EmpCode", Session("EmpCode"))

                Dim c, d, p As String
                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                oTS.GetJobInfo(job, "", "", c, d, p)

                qs.Add("Client", c)
                qs.Add("Division", d)
                qs.Add("Product", p)

                Dim Desc As String = CType(e.Item.FindControl("HiddenFieldTaskNonTaskDisplay"), HiddenField).Value & " for " &
                                     CType(e.Item.FindControl("HiddenFieldTaskNonTaskDisplay"), HiddenField).Value.PadLeft(6, "0") & "/" & CType(e.Item.FindControl("HiddenFieldTaskNonTaskDisplay"), HiddenField).Value.PadLeft(2, "0") & " - " &
                                     CType(e.Item.FindControl("HiddenFieldJobComponentDescription"), HiddenField).Value

                With b
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_Task
                    .UserCode = Session("UserCode")
                    .Name = "Task: " & job.ToString() & "/" & jobcomp.ToString() & "/" & seqno.ToString()
                    .Description = Desc
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
                Try
                    If EventTaskID > 0 Then
                        IsEventTask = True
                    End If
                Catch ex As Exception
                End Try
                If IsEventTask = False Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If e.CommandArgument = "Mark" Then

                                AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, job, jobcomp, seqno, Session("EmpCode"), CType(Now, DateTime))
                                Dim AutoAlertTaskEmployees As Boolean = False
                                Dim DatatableTaskSeqNbrThatWereMadeActive As New DataTable

                                Dim asm As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)
                                AutoAlertTaskEmployees = asm.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

                                If AutoAlertTaskEmployees = True Then

                                    If Not DatatableTaskSeqNbrThatWereMadeActive Is Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                                        Dim ThisSeqNbr As Integer = 0

                                        Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
                                        Dim EmpCodeString As String = ""
                                        Dim NewAlertId As Integer = 0

                                        For j As Integer = 0 To DatatableTaskSeqNbrThatWereMadeActive.Rows.Count - 1

                                            ThisSeqNbr = CType(DatatableTaskSeqNbrThatWereMadeActive.Rows(j)("SEQ_NBR"), Integer)

                                            NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, job, jobcomp, ThisSeqNbr, HttpContext.Current.Session("EmpCode"), EmpCodeString)

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

                            Else

                                AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, job, jobcomp, seqno, Session("EmpCode"), Nothing)

                            End If

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
                            End Try
                        End Using
                    Catch ex As Exception
                    End Try
                End If

                Me.LoadData()

            Case "StartStopwatch"
                Dim s As String = ""
                If AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), job, jobcomp, seqno, 0, s) = True Then
                    Me.OpenTimesheetStopwatchNotificationWindow()
                Else
                    Me.ShowMessage(s)
                End If
                Me.LoadData()

        End Select

    End Sub
    Private Sub RepeaterMyCalendar_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RepeaterMyCalendar.ItemDataBound

        Select Case e.Item.ItemType

            Case ListItemType.Item, ListItemType.AlternatingItem

                Try

                    Me._CalendarItem = e.Item.DataItem

                    If Me._CalendarItem IsNot Nothing Then

                        Dim ActionBarTextLiteral As System.Web.UI.WebControls.Literal = e.Item.FindControl("LiteralActionBarText")

                        Dim CardDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivCard")
                        Dim CardContentDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivCardContent")
                        Dim DisplayDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivDisplay")
                        Dim TimespanHeader As HtmlControls.HtmlGenericControl = e.Item.FindControl("HeaderTimespan")
                        Dim TaskDetailsDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivTaskDetails")
                        Dim BookmarkImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonBookmark")
                        Dim MarkTempCompleteImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonMarkTempComplete")
                        Dim AddTimeImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonAddTime")
                        Dim StartStopwatchImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonStartStopwatch")
                        Dim DisplayLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelDisplay")
                        Dim TimespanLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelTimespan")
                        Dim DetailsLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelDetails")

                        Dim TimeDisplay As String = ""
                        Dim IsEventTask As Boolean = False
                        Dim IsTempComplete As Boolean = False

                        If CardDiv IsNot Nothing Then CardDiv.Attributes.Add("oncontextmenu",
                                                                                     String.Format("UnityRowContextMenuRepeaterMyCalendar('{0}',event);", e.Item.ItemIndex))

                        Try

                            If Me._CalendarItem.TASK_TEMP_COMPLETE_DATE IsNot Nothing AndAlso CType(Me._CalendarItem.TASK_TEMP_COMPLETE_DATE, Date).Year > 1900 Then

                                IsTempComplete = True

                            End If

                        Catch ex As Exception
                        End Try


                        If IsTempComplete = True Then CardContentDiv.Attributes.Add("style", "text-decoration:line-through;")
                        'AdvantageFramework.Web.Presentation.Controls.DivSetStyle(CardDiv, "border: none;")

                        If Me._CalendarItem.NON_TASK_TYPE IsNot Nothing Then

                            Dim TypeCode As String = Me._CalendarItem.NON_TASK_TYPE.ToString().Trim().ToUpper()
                            Dim qs As New AdvantageFramework.Web.QueryString()

                            Select Case TypeCode
                                Case "C", "M", "TD", "EL"

                                    If TypeCode = "C" Then

                                        CardDiv.Attributes.Add("class", "card  card-edge-calendar-activity-c")

                                    ElseIf TypeCode = "M" Then

                                        CardDiv.Attributes.Add("class", "card  card-edge-calendar-activity-m")

                                    ElseIf TypeCode = "TD" Then

                                        CardDiv.Attributes.Add("class", "card  card-edge-calendar-activity-td")

                                    ElseIf TypeCode = "EL" Then

                                        CardDiv.Attributes.Add("class", "card  card-edge-calendar-activity-td")

                                    End If

                                    qs.Page = "Calendar_NewActivity.aspx"
                                    qs.Add("TaskNo", Me._CalendarItem.NON_TASK_ID)

                                Case "E"

                                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-calendar-event")
                                    qs.Page = "Event_Detail.aspx"
                                    qs.Add("et", "0")
                                    qs.Add("j", Me._CalendarItem.JOB_NUMBER)
                                    qs.Add("jc", Me._CalendarItem.JOB_COMPONENT_NBR)
                                    qs.Add("evt", Me._CalendarItem.NON_TASK_ID)
                                    qs.Add("cli", Me._CalendarItem.CL_CODE)
                                    qs.Add("from", "1")

                                Case "ET"

                                    IsEventTask = True
                                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-calendar-event-task")
                                    qs.Page = "Event_Task_Detail.aspx"
                                    qs.Add("etid", Me._CalendarItem.NON_TASK_ID)
                                    qs.Add("f", "")
                                    qs.Add("c", "")

                                Case "H"

                                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-calendar-holiday")
                                    qs.Page = "Calendar_NewActivity.aspx"
                                    qs.Add("TaskNo", Me._CalendarItem.NON_TASK_ID)

                                Case "T"

                                    DisplayLabel.Attributes.Remove("style")
                                    DisplayLabel.Attributes.Add("style", "font-weight: bold !important;")

                                    'DetailsLabel.Attributes.Remove("style")
                                    'DetailsLabel.Attributes.Add("style", "font-size: small !important;")

                                    Select Case Me._CalendarItem.TASK_STATUS
                                        Case "A"

                                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-task-priority-active")

                                        Case "P", "N"

                                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-task-priority-pending")

                                        Case "H"

                                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-alert-priority-high")

                                        Case "L"

                                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-alert-priority-low")

                                        Case Else

                                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-alert-priority-normal")

                                    End Select

                                    Dim TaskDataKey As String = ""
                                    TaskDataKey = "DTO|0|2|3|4|" & Me._CalendarItem.JOB_NUMBER & "|" &
                                                                     Me._CalendarItem.JOB_COMPONENT_NBR & "|" &
                                                                     Me._CalendarItem.TASK_SEQ_NBR & "|8|" &
                                                                     Me._CalendarItem.EMP_CODE & "|" &
                                                                     Me._CalendarItem.CL_CODE & "|" &
                                                                     Me._CalendarItem.DIV_CODE & "|" &
                                                                     Me._CalendarItem.PRD_CODE

                                    If Me._CalendarItem.ALERT_ID IsNot Nothing AndAlso Me._CalendarItem.ALERT_ID > 0 Then

                                        Try

                                            Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                                            QsViewDetails.Page = "Desktop_AlertView"
                                            QsViewDetails.Add("AlertID", Me._CalendarItem.ALERT_ID.ToString)
                                            QsViewDetails.Add("SprintID", Me._CalendarItem.SPRINT_ID.ToString)

                                            DisplayDiv.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))
                                            TimespanHeader.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))
                                            TaskDetailsDiv.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))

                                        Catch ex As Exception
                                        End Try

                                    Else

                                        DisplayDiv.Attributes.Add("onclick", Me.HookUpOpenDetailWindow(TaskDataKey))
                                        TimespanHeader.Attributes.Add("onclick", Me.HookUpOpenDetailWindow(TaskDataKey))
                                        TaskDetailsDiv.Attributes.Add("onclick", Me.HookUpOpenDetailWindow(TaskDataKey))

                                    End If

                                Case Else

                                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(CardDiv, "card-edge-calendar-activity")

                                    If Me._CalendarItem.NON_TASK_ID IsNot Nothing AndAlso Me._CalendarItem.NON_TASK_ID > 0 Then

                                        qs.Page = "Calendar_NewActivity.aspx"
                                        qs.Add("TaskNo", Me._CalendarItem.NON_TASK_ID)

                                    End If

                            End Select

                            If TypeCode <> "T" AndAlso qs.Page <> "" Then

                                DisplayDiv.Attributes.Add("onclick", Me.HookUpOpenWindow("", qs.ToString(True)))
                                TimespanHeader.Attributes.Add("onclick", Me.HookUpOpenWindow("", qs.ToString(True)))
                                TaskDetailsDiv.Attributes.Add("onclick", Me.HookUpOpenWindow("", qs.ToString(True)))

                            End If

                            Dim StartDate As String = ""
                            Dim EndDate As String = ""

                            Dim ActionImageButton As System.Web.UI.WebControls.ImageButton
                            If TypeCode <> "T" Then

                                BookmarkImageButton.Visible = False
                                MarkTempCompleteImageButton.Visible = False
                                AddTimeImageButton.Visible = False
                                StartStopwatchImageButton.Visible = False

                                If Me._CalendarItem.START_DATE IsNot Nothing AndAlso IsDate(Me._CalendarItem.START_DATE) Then

                                    StartDate = CType(Me._CalendarItem.START_DATE, Date).ToShortDateString()

                                End If
                                If Me._CalendarItem.END_DATE IsNot Nothing AndAlso IsDate(Me._CalendarItem.END_DATE) Then

                                    EndDate = CType(Me._CalendarItem.END_DATE, Date).ToShortDateString()

                                End If

                                If Me._CalendarItem.NUM_DAYS > 2 Then

                                    'TimeDisplay = "Multiple Days (" & Me._CalendarItem.NUM_DAYS.ToString() & ")"

                                    If StartDate <> "" AndAlso EndDate <> "" Then

                                        TimeDisplay = StartDate & " to " & EndDate

                                    ElseIf StartDate <> "" AndAlso EndDate = "" Then

                                        TimeDisplay = "Starts: " & StartDate

                                    ElseIf StartDate = "" AndAlso EndDate <> "" Then

                                        TimeDisplay = "Due: " & EndDate

                                    End If

                                ElseIf Me._CalendarItem.ALL_DAY = 1 Then

                                    'TimeDisplay = "All Day"
                                    ActionBarTextLiteral.Text = "All Day"

                                Else

                                    TimeDisplay = CType(Me._CalendarItem.START_TIME, Date).ToShortTimeString().Replace(":00", "").Replace(":", ".").Replace(" AM", "a").Replace(" PM", "p") &
                                                  " to " &
                                                  CType(Me._CalendarItem.END_TIME, Date).ToShortTimeString().Replace(":00", "").Replace(":", ".").Replace(" AM", "a").Replace(" PM", "p")

                                    Dim s As Date = CType(Me._CalendarItem.START_TIME, Date)
                                    Dim ed As Date = CType(Me._CalendarItem.END_TIME, Date)
                                    Dim Diff As Long = 0

                                    Diff = DateDiff(DateInterval.Hour, s, ed)

                                    If Diff > 0 Then

                                        If Diff = 1 Then

                                            ActionBarTextLiteral.Text = Diff.ToString() & " hour"

                                        Else

                                            ActionBarTextLiteral.Text = Diff.ToString() & " hours"

                                        End If

                                    Else

                                        Diff = DateDiff(DateInterval.Minute, s, ed)
                                        If Diff = 1 Then

                                            ActionBarTextLiteral.Text = Diff.ToString() & " minute"

                                        Else

                                            ActionBarTextLiteral.Text = Diff.ToString() & " minutes"

                                        End If

                                    End If

                                End If

                            Else

                                If StartDate <> "" AndAlso EndDate <> "" Then

                                    If StartDate = Today.ToShortDateString() Then StartDate = "Today"
                                    If EndDate = Today.ToShortDateString() Then EndDate = "Today"

                                    If StartDate = EndDate Then

                                        TimeDisplay = StartDate

                                    Else

                                        TimeDisplay = StartDate & " to " & EndDate

                                    End If

                                ElseIf StartDate <> "" And EndDate = "" Then

                                    TimeDisplay = "Starts: " & StartDate

                                ElseIf StartDate = "" And EndDate <> "" Then

                                    TimeDisplay = "Due: " & EndDate

                                End If

                                'If Me._CalendarItem.END_DATE IsNot Nothing AndAlso IsDate(Me._CalendarItem.END_DATE) AndAlso CDate(Me._CalendarItem.END_DATE).ToShortDateString() = Now.Date.ToShortDateString() Then

                                '    TimeDisplay = "Due Today!"

                                'End If

                                If Me._CalendarItem.JOB_NUMBER IsNot Nothing AndAlso Me._CalendarItem.JOB_COMPONENT_NBR IsNot Nothing AndAlso Me._CalendarItem.TASK_SEQ_NBR IsNot Nothing Then

                                    Dim CommandArgString As String = Me._CalendarItem.JOB_NUMBER & "," &
                                                                     Me._CalendarItem.JOB_COMPONENT_NBR & "," &
                                                                     Me._CalendarItem.TASK_SEQ_NBR & "," &
                                                                     IIf(IsEventTask = True, Me._CalendarItem.NON_TASK_ID, 0)

                                    Dim ThisRow_DataKey As String = "DTO|0|2|3|4|" & Me._CalendarItem.JOB_NUMBER & "|" &
                                                                     Me._CalendarItem.JOB_COMPONENT_NBR & "|" &
                                                                     Me._CalendarItem.TASK_SEQ_NBR & "|8|" &
                                                                     Session("EmpCode") & "|" &
                                                                     Me._CalendarItem.CL_CODE & "|" &
                                                                     Me._CalendarItem.DIV_CODE & "|" &
                                                                     Me._CalendarItem.PRD_CODE

                                    'Me._CalendarItem.NON_TASK_ID = event id
                                    ActionImageButton = e.Item.FindControl("ImageButtonBookmark")
                                    If ActionImageButton IsNot Nothing Then

                                        ActionImageButton.CommandName = "Bookmark"
                                        ActionImageButton.CommandArgument = CommandArgString

                                    End If

                                    ActionImageButton = e.Item.FindControl("ImageButtonAddTime")
                                    If ActionImageButton IsNot Nothing Then

                                        Try

                                            If IsEventTask = False Then

                                                ActionImageButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", "Timesheet_QuickAdd.aspx?tasklistDO=1&JobNum=" & Me._CalendarItem.JOB_NUMBER & "&JobComp=" &
                                                                                 Me._CalendarItem.JOB_COMPONENT_NBR & "&Seq=" & Me._CalendarItem.TASK_SEQ_NBR & "&TaskEmp=" & Session("EmpCode")))

                                            Else

                                                If IsNumeric(Me._CalendarItem.NON_TASK_ID) = True Then

                                                    Dim qsET As New AdvantageFramework.Web.QueryString()
                                                    With qsET

                                                        .Page = "Timesheet_CommentsView.aspx"
                                                        .Add("Type", "New")
                                                        .Add("caller", "AlertView")
                                                        .Add("single", "1")
                                                        .JobNumber = Me._CalendarItem.JOB_NUMBER
                                                        .JobComponentNumber = Me._CalendarItem.JOB_COMPONENT_NBR

                                                    End With

                                                    ActionImageButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", qs.ToString(True)))

                                                End If

                                            End If

                                        Catch ex As Exception
                                        End Try

                                    End If

                                    ActionImageButton = e.Item.FindControl("ImageButtonStartStopwatch")
                                    If ActionImageButton IsNot Nothing Then

                                        ActionImageButton.CommandName = "StartStopwatch"
                                        ActionImageButton.CommandArgument = CommandArgString

                                    End If

                                End If

                            End If

                            If TypeCode = "T" OrElse TypeCode = "ET" Then

                                ActionImageButton = e.Item.FindControl("ImageButtonMarkTempComplete")

                                If ActionImageButton IsNot Nothing Then

                                    ActionImageButton.CommandName = "MarkTempComplete"
                                    ActionImageButton.CommandArgument = "Mark"

                                    If IsTempComplete = True Then

                                        ActionImageButton.ImageUrl = "~/Images/Icons/Color/256/undo.png"
                                        ActionImageButton.ToolTip = "Mark not completed"
                                        ActionImageButton.CommandArgument = "Mark Not"

                                    End If

                                End If

                            End If

                        End If

                        DisplayLabel.Text = Me._CalendarItem.TASK_NON_TASK_DISPLAY

                        If IsEventTask = True Then

                            DisplayLabel.Text &= ", " & Me._CalendarItem.TRF_CODE & " - " & Me._CalendarItem.TRF_DESCRIPTION

                        End If

                        TimespanLabel.Text = TimeDisplay

                        If String.IsNullOrWhiteSpace(Me._CalendarItem.NON_TASK_TYPE) = False AndAlso Me._CalendarItem.NON_TASK_TYPE = "T" Then

                            If ShowTasks = False Then

                                If CardDiv IsNot Nothing Then

                                    CardDiv.Visible = False

                                End If

                            Else

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

                                Try

                                    AdvantageFramework.Web.Presentation.Controls.SetJobInfoForControl(DetailsLabel.Text, DetailsLabel.ToolTip,
                                                                                                      Me._CalendarItem.JOB_NUMBER, Me._CalendarItem.JOB_COMPONENT_NBR,
                                                                                                      Me._CalendarItem.JOB_DESC, Me._CalendarItem.JOB_COMP_DESC,
                                                                                                      Me._CardSettings.ShowJobNumber, Me._CardSettings.ShowJobComponentNumber,
                                                                                                      Me._CardSettings.ShowJobDescription, Me._CardSettings.ShowJobComponentDescription, False)

                                Catch ex As Exception
                                    DetailsLabel.Text = Webvantage.Calendar_MonthView.RenderEventsRS(Me._CalendarItem, False, Me._CalendarItem.IS_NON_TASK, If(Me._CalendarItem.ALL_DAY Is Nothing, 0, Me._CalendarItem.ALL_DAY), False).Replace("|", " | ")
                                End Try
                                Try

                                    If Me._CardSettings.ShowClientName = True Then

                                        DetailsLabel.Text = Me._CalendarItem.CL_NAME & "<br />" & DetailsLabel.Text

                                    End If

                                Catch ex As Exception
                                End Try
                                Try
                                    Dim HasStartDate As Boolean = False
                                    Dim StartDateString As String = ""

                                    If Me._CalendarItem.START_DATE IsNot Nothing Then

                                        HasStartDate = True
                                        StartDateString = "Start: " & String.Format("{0:d}", Me._CalendarItem.START_DATE)

                                    End If

                                    Dim HasDueDate As Boolean = False
                                    Dim DueDateString As String = ""

                                    If Me._CalendarItem.END_DATE IsNot Nothing Then

                                        HasDueDate = True
                                        DueDateString = "Due: " & String.Format("{0:d}", Me._CalendarItem.END_DATE)

                                    End If

                                    Dim DateString As String = String.Empty

                                    If HasStartDate = True AndAlso HasDueDate = True Then

                                        DateString = StartDateString & "," & DueDateString

                                    ElseIf HasStartDate = True AndAlso HasDueDate = False Then

                                        DateString = StartDateString

                                    ElseIf HasStartDate = False AndAlso HasDueDate = True Then

                                        DateString = DueDateString

                                    End If

                                    If String.IsNullOrWhiteSpace(DateString) = False Then

                                        DetailsLabel.Text = DetailsLabel.Text & "<br />" & DateString

                                    End If

                                Catch ex As Exception
                                End Try

                            End If

                        Else

                            DetailsLabel.Text = Webvantage.Calendar_MonthView.RenderEventsRS(Me._CalendarItem, False, Me._CalendarItem.IS_NON_TASK, If(Me._CalendarItem.ALL_DAY Is Nothing, 0, Me._CalendarItem.ALL_DAY), False).Replace("|", " | ")
                            DetailsLabel.Text = DetailsLabel.Text.Replace("|", " ")

                        End If

                    End If

                Catch ex As Exception
                End Try

            Case ListItemType.Footer

                'Dim NoDataDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivNoData")
                'NoDataDiv.Visible = Me.RepeaterMyCalendar.Items.Count = 0

        End Select

    End Sub
    Public Sub LoadData()

        Try

            Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                _CalendarItems = AdvantageFramework.Database.Procedures.CalendarItemComplexType.Load(DbContext, HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"),
                                                                                                     "", "", "", "", "", "", "", Me.DayNavigator.Date, Me.DayNavigator.Date, "", "N", "N", "", "D", "",
                                                                                                     1, IIf(ShowTasks = True, 1, 0), 1, 1, "", "", 0, MiscFN.IsClientPortal, HttpContext.Current.Session("UserID"), "").OrderBy(Function(CalendarItem) CalendarItem.TASK_SEQ_NBR).ThenBy(Function(CalendarItem) CalendarItem.START_DATE).ThenBy(Function(CalendarItem) CalendarItem.START_TIME).ToList()

                Me.RepeaterMyCalendar.DataSource = Me._CalendarItems
                Me.RepeaterMyCalendar.DataBind()

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DayNavigator_DateClicked() Handles DayNavigator.DateClicked

        Me.LoadData()

    End Sub
    Private Sub DayNavigator_GoPrevious() Handles DayNavigator.GoPrevious

        Me.LoadData()

    End Sub
    Private Sub DayNavigator_GoToday() Handles DayNavigator.GoToday

        Me.LoadData()

    End Sub
    Private Sub DayNavigator_GoNext() Handles DayNavigator.GoNext

        Me.LoadData()

    End Sub

    Private Sub ImageButtonAdd_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAdd.Click

        Dim qs As New AdvantageFramework.Web.QueryString

        qs.Page = "Calendar_NewActivity.aspx"
        qs.Add("thisdate", CType(Me.DayNavigator.Date, Date).ToShortDateString())

        Me.OpenWindow("", qs.ToString(True))

    End Sub
    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = CType(Me.RepeaterMyCalendar.Items(Me.MyUnityContextMenu.GridIndex).FindControl("HiddenFieldJobNumber"), HiddenField).Value
        Me.MyUnityContextMenu.JobComponentNumber = CType(Me.RepeaterMyCalendar.Items(Me.MyUnityContextMenu.GridIndex).FindControl("HiddenFieldJobComponentNumber"), HiddenField).Value

    End Sub

    Private Sub ImageButtonRefreshDesktopCardsMyCalendar_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefreshDesktopCardsMyCalendar.Click

        Me.LoadData()

    End Sub

    Private Function UserHasAccessToAddNew(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        ''bypass
        'Return True
        Dim UserDoesHaveAccess As Boolean = False
        Dim SessionKey As String = "UserHasAccessToAddNew" & SecurityModule.ToString()
        If Session(SessionKey) Is Nothing Then
            If Me.CheckModuleAccess(SecurityModule.ToString(), False) = 1 _
               And Me.UserCanAddInModule(SecurityModule) = True Then
                UserDoesHaveAccess = True
            Else
                UserDoesHaveAccess = False
            End If
            Session(SessionKey) = UserDoesHaveAccess
        Else
            UserDoesHaveAccess = CType(Session(SessionKey), Boolean)
        End If
        Return UserDoesHaveAccess
    End Function

#End Region

End Class
