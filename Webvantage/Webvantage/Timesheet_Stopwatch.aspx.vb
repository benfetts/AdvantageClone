Imports Webvantage.wvTimeSheet

Public Class Timesheet_Stopwatch
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private StopwatchStartDate As Date = Nothing
    Private EtId As Integer = 0
    Private EtDtlId As Integer = 0
    Private TimeType As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Timesheet_Stopwatch_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.TrTimeOver.Visible = False
        Me.TrCounter.Visible = False
        Me.TrButtons.Visible = False

        Me.DisableButtonOnClick(Me.ButtonCancelStopwatch)
        Me.DisableButtonOnClick(Me.ButtonStop)

    End Sub
    Protected Sub Timesheet_Stopwatch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1))
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches)
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        HttpContext.Current.Response.Cache.SetNoStore()

        Me.LoadStopwatch()

    End Sub

#End Region

#Region " Controls Events "

    Private Sub ButtonCancelStopwatch_Click(sender As Object, e As System.EventArgs) Handles ButtonCancelStopwatch.Click
        ' Dim t As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))
        Dim s As String = ""

        If AdvantageFramework.Timesheet.StopwatchClear(Session("ConnString"), Session("EmpCode"), s) = False Then

            Me.ShowMessage(s)

        Else

            Me.CloseStopwatchWindow()

        End If

    End Sub
    Private Sub ButtonStop_Click(sender As Object, e As System.EventArgs) Handles ButtonStop.Click

        Me.StopStopwatch()

    End Sub
    'Private Sub ButtonViewTimesheet_Click(sender As Object, e As System.EventArgs) Handles ButtonViewTimesheet.Click

    '    Me.OpenCommentView()

    'End Sub
    Private Sub ImageButtonStop_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonStop.Click

        Me.StopStopwatch()

    End Sub
    Private Sub LinkButtonClearStopwatch_Click(sender As Object, e As System.EventArgs) Handles LinkButtonClearStopwatch.Click

        Dim s As String = ""

        If AdvantageFramework.Timesheet.StopwatchClear(Session("ConnString"), Session("EmpCode"), s) = False Then

            Me.ShowMessage(s)

        Else

            Me.CheckForStopwatch()
            Me.CloseStopwatchWindow()

        End If

    End Sub
    Private Sub LinkButtonViewInTimesheet_Click(sender As Object, e As System.EventArgs) Handles LinkButtonViewInTimesheet.Click

        Me.OpenCommentView()

    End Sub

#End Region

#Region " Methods "

    Private Sub LoadStopwatch()

        'Dim t As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))

        Dim Comment As String = ""
        Dim Description As String = ""
        Dim StopwatchServerTime As Date

        If AdvantageFramework.Timesheet.HasStopWatch(Session("ConnString"), Session("UserCode"), Session("EmpCode"), EtId, EtDtlId, StopwatchStartDate, Comment, Description, TimeType, StopwatchServerTime) = True Then

            Me.TrNoStopwatch.Visible = False

            Dim RunningTime As New TimeSpan
            RunningTime = cEmployee.TimeZoneToday.Subtract(StopwatchStartDate)

            Me.TrTimeOver.Visible = RunningTime.TotalHours > 24
            Me.TrCounter.Visible = True
            Me.TrButtons.Visible = Not Me.TrTimeOver.Visible

            Dim JsDateString = StopwatchStartDate.ToString("MMMM dd, yyyy H:mm:ss")
            Me.LiteralStartTimer.Text = "<script type=""text/javascript"">window.onload = function() { new CountUp('" & JsDateString & "','" & StopwatchServerTime.ToString("MMMM dd, yyyy H:mm:ss") & "','counter'); }</script>"

            If Not Me.IsPostBack And Not Me.IsCallback Then
                Me.TextBoxComment.Text = Comment
                Me.LabelJobDescription.Text = Description
                Dim ts As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))
                If ts.TimeEntryCommentRequired(Me.EtId, Me.EtDtlId) = True And TimeType = "D" Then
                    Me.TextBoxComment.CssClass = "RequiredInput"
                End If
            End If

            Me.LabelJobDescription.Visible = Me.LabelJobDescription.Text <> ""

        Else

            Me.CloseStopwatchWindow()

        End If

    End Sub
    Private Sub OpenCommentView()

        Dim s As String = ""

        If Me.CommentViewToSession(s) = False Then

            Me.ShowMessage(s)

        Else

            Dim qs As New AdvantageFramework.Web.QueryString()
            With qs

                .Page = "Timesheet_CommentsView.aspx"
                .EmployeeCode = Session("EmpCode")
                .StartDate = StopwatchStartDate.ToShortDateString()
                .Add("Type", "Update")
                .Add("caller", "Stopwatch")
                .Add("single", "1")

                .Build()

            End With

            Me.OpenWindow(qs)

        End If

    End Sub
    Private Sub StopStopwatch()

        If Me.EtId > 0 And Me.EtDtlId > 0 Then

            Dim ts As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))

            If ts.CommentsRequired = True And Me.TextBoxComment.Text.Trim() = "" And Me.TimeType = "D" And ts.TimeEntryCommentRequired(Me.EtId, Me.EtDtlId) = True Then

                Me.ShowMessage("Comment is required.")
                Exit Sub

            End If

            'Dim t As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))
            Dim Hours As Decimal = 0.0
            Dim s As String = ""
            Dim Stopped As Boolean = False

            Stopped = AdvantageFramework.Timesheet.StopwatchStop(Session("ConnString"), Session("UserCode"), Session("EmpCode"), Me.EtId, Me.EtDtlId, Hours, Me.TextBoxComment.Text, s)

            If Stopped = False Then

                Me.CheckForStopwatch()
                If s <> "" Then

                    Me.ShowMessage(s & " Stopwatch cleared.")

                Else

                    Me.ShowMessage("Status change does not allow update.  Stopwatch cleared.")
                    Me.CloseStopwatchWindow()

                End If

            Else

                Webvantage.TimesheetPage.ProcessMissingTime(Session("EmpCode"), Me.StopwatchStartDate)
                't.DeleteZeroHours(Session("EmpCode"), Now.Date)

                If s.Trim() <> "" Then

                    Me.ShowMessage(s)

                End If

                Me.CheckForStopwatch()

            End If

            s = ""
            If Me.CommentViewToSession(s) = False Then

                Me.ShowMessage(s)

            End If

            Me.CloseStopwatchWindow()

        End If

    End Sub
    Private Sub CloseStopwatchWindow()

        Me.TrCounter.Visible = False
        Me.TrTimeOver.Visible = False
        Me.TrButtons.Visible = False
        Me.TrNoStopwatch.Visible = True

        Me.CloseThisWindow()

    End Sub
    Private Function CommentViewToSession(ByVal ErrorMessage As String) As Boolean

        Session("TimesheetEmpCode") = Session("EmpCode")
        Session("TimesheetStartDate") = StopwatchStartDate.ToShortDateString()
        Session("TimesheetCommentView_SingleViewDayOfWeek") = CType(StopwatchStartDate.DayOfWeek, Integer)

        Dim t As New cTimeSheet(Session("ConnString"))
        Dim cv As New TimesheetCommentView

        ErrorMessage = ""
        cv = t.GetCommentViewFromDetailId(Me.EtId, Me.EtDtlId, ErrorMessage)

        If cv Is Nothing Then

            Return False

        Else

            cv.ToSession()
            Return True

        End If

    End Function

    Private Sub ButtonViewEntry_Click(sender As Object, e As EventArgs) Handles ButtonViewEntry.Click

        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            Dim qs As New AdvantageFramework.Web.QueryString

            qs.Page = "Employee/Timesheet/Entry"
            qs.EmployeeCode = Session("EmpCode")
            qs.TimeType = Me.TimeType
            qs.EmployeeTimeID = Me.EtId
            qs.EmployeeTimeDetailID = Me.EtDtlId

            If TimeType = "D" Then

                Dim Entry As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
                Entry = AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeIDAndEmployeeTimeDetailID(DbContext, Me.EtId, Me.EtDtlId)

                If Entry IsNot Nothing Then

                    qs.FunctionCode = Entry.FunctionCode
                    qs.DepartmentTeamCode = Entry.DepartmentTeamCode
                    If Entry.AlertID IsNot Nothing Then qs.AlertID = Entry.AlertID
                    qs.JobNumber = Entry.JobNumber
                    qs.JobComponentNumber = Entry.JobComponentNumber
                    qs.StartDate = Entry.EmployeeTime.Date.ToShortDateString

                End If

            Else

                Dim Entry As AdvantageFramework.Database.Entities.EmployeeTimeIndirect = Nothing
                Entry = AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.LoadByEmployeeTimeIDAndEmployeeTimeIndirectID(DbContext, Me.EtId, Me.EtDtlId)

                If Entry IsNot Nothing Then

                    qs.FunctionCode = Entry.Category
                    qs.DepartmentTeamCode = Entry.DepartmentTeamCode
                    qs.StartDate = Entry.EmployeeTime.Date.ToShortDateString

                End If

            End If

            Me.OpenWindow(qs, "Edit Time", 600, 600)

        End Using

    End Sub

#End Region

End Class
