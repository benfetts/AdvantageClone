Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports System.Data.SqlClient
Imports System.Drawing
Imports Telerik.Web.UI

Public Class Timesheet_SupervisorApproval
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private DaysToShow As Integer = 7
    Private TimesheetDate As Date = Now
    Private TimesheetEmpCode As String = ""
    Private ThisEmpFullName As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub BtnSubmitAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmitAll.Click

        Me.SubmitAll()

    End Sub
    Private Sub BtnUnSubmitAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUnSubmitAll.Click
        Dim s As String = ""
        'Dim m As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))

        If Me.LnkBtnMonday.Visible = True And Me.LnkBtnMonday.Text.Trim() = "Un-submit" Then
            If Me.SetApproval(cGlobals.wvCDate(Me.HfMonday.Value), False, s) = False Then
                Me.ShowMessage(s)
                Exit Sub
            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfMonday.Value))
        End If

        If Me.LnkBtnTuesday.Visible = True And Me.LnkBtnTuesday.Text.Trim() = "Un-submit" Then
            If Me.SetApproval(cGlobals.wvCDate(Me.HfTuesday.Value), False, s) = False Then
                Me.ShowMessage(s)
                Exit Sub
            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfTuesday.Value))
        End If

        If Me.LnkBtnWednesday.Visible = True And Me.LnkBtnWednesday.Text.Trim() = "Un-submit" Then
            If Me.SetApproval(cGlobals.wvCDate(Me.HfWednesday.Value), False, s) = False Then
                Me.ShowMessage(s)
                Exit Sub
            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfWednesday.Value))
        End If

        If Me.LnkBtnThursday.Visible = True And Me.LnkBtnThursday.Text.Trim() = "Un-submit" Then
            If Me.SetApproval(cGlobals.wvCDate(Me.HfThursday.Value), False, s) = False Then
                Me.ShowMessage(s)
                Exit Sub
            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfThursday.Value))
        End If

        If Me.LnkBtnFriday.Visible = True And Me.LnkBtnFriday.Text.Trim() = "Un-submit" Then
            If Me.SetApproval(cGlobals.wvCDate(Me.HfFriday.Value), False, s) = False Then
                Me.ShowMessage(s)
                Exit Sub
            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfFriday.Value))
        End If

        If Me.LnkBtnSaturday.Visible = True And Me.LnkBtnSaturday.Text.Trim() = "Un-submit" Then
            If Me.SetApproval(cGlobals.wvCDate(Me.HfSaturday.Value), False, s) = False Then
                Me.ShowMessage(s)
                Exit Sub
            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSaturday.Value))
        End If

        If Me.LnkBtnSunday.Visible = True And Me.LnkBtnSunday.Text.Trim() = "Un-submit" Then
            If Me.SetApproval(cGlobals.wvCDate(Me.HfSunday.Value), False, s) = False Then
                Me.ShowMessage(s)
                Exit Sub
            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSunday.Value))
        End If
        Me.CloseAndRefresh()
    End Sub
    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.CloseAndRefresh()
    End Sub

#Region " Submit/Unsubmit Linkbuttons "

    Private Sub LnkBtnMonday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnMonday.Click
        Dim s As String = ""
        If Me.SetApproval(cGlobals.wvCDate(Me.HfMonday.Value), Me.LnkBtnMonday.Text = "Submit", s) = False Then
            Me.ShowMessage(s)
        End If
        Me.LoadTimesheet()
    End Sub
    Private Sub LnkBtnTuesday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnTuesday.Click
        Dim s As String = ""
        If Me.SetApproval(cGlobals.wvCDate(Me.HfTuesday.Value), Me.LnkBtnTuesday.Text = "Submit", s) = False Then
            Me.ShowMessage(s)
        End If
        Me.LoadTimesheet()
    End Sub
    Private Sub LnkBtnWednesday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnWednesday.Click
        Dim s As String = ""
        If Me.SetApproval(cGlobals.wvCDate(Me.HfWednesday.Value), Me.LnkBtnWednesday.Text = "Submit", s) = False Then
            Me.ShowMessage(s)
        End If
        Me.LoadTimesheet()
    End Sub
    Private Sub LnkBtnThursday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnThursday.Click
        Dim s As String = ""
        If Me.SetApproval(cGlobals.wvCDate(Me.HfThursday.Value), Me.LnkBtnThursday.Text = "Submit", s) = False Then
            Me.ShowMessage(s)
        End If
        Me.LoadTimesheet()
    End Sub
    Private Sub LnkBtnFriday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnFriday.Click
        Dim s As String = ""
        If Me.SetApproval(cGlobals.wvCDate(Me.HfFriday.Value), Me.LnkBtnFriday.Text = "Submit", s) = False Then
            Me.ShowMessage(s)
        End If
        Me.LoadTimesheet()
    End Sub
    Private Sub LnkBtnSaturday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnSaturday.Click
        Dim s As String = ""
        If Me.SetApproval(cGlobals.wvCDate(Me.HfSaturday.Value), Me.LnkBtnSaturday.Text = "Submit", s) = False Then
            Me.ShowMessage(s)
        End If
        Me.LoadTimesheet()
    End Sub
    Private Sub LnkBtnSunday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnSunday.Click
        Dim s As String = ""
        If Me.SetApproval(cGlobals.wvCDate(Me.HfSunday.Value), Me.LnkBtnSunday.Text = "Submit", s) = False Then
            Me.ShowMessage(s)
        End If
        Me.LoadTimesheet()
    End Sub

#End Region

#End Region
#Region " Page "

    Private Sub Timesheet_SupervisorApproval_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.TimesheetDate = CType(Me.CurrentQuerystring.StartDate, Date)
        Me.TimesheetEmpCode = Me.CurrentQuerystring.EmployeeCode

        Me.Title = "Set Approval for Week Of " & Me.TimesheetDate.ToShortDateString()

    End Sub
    Protected Sub Timesheet_SupervisorApproval_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo()

            Me.HfSunday.Value = TimesheetDate.ToShortDateString()
            Me.LabelSundayText.Text = DateAdd(DateInterval.Day, 0, TimesheetDate).ToLongDateString() ' String.Format(c, "{0:dddd}", Me.TimesheetDate) 'TimesheetDate.DayOfWeek.ToString()

            Me.HfMonday.Value = DateAdd(DateInterval.Day, 1, TimesheetDate).ToShortDateString()
            Me.LabelMondayText.Text = DateAdd(DateInterval.Day, 1, TimesheetDate).ToLongDateString() 'String.Format(c, "{0:dddd}", DateAdd(DateInterval.Day, 1, TimesheetDate)) 'DateAdd(DateInterval.Day, 1, TimesheetDate).DayOfWeek.ToString()

            Me.HfTuesday.Value = DateAdd(DateInterval.Day, 2, TimesheetDate).ToShortDateString()
            Me.LabelTuesdayText.Text = DateAdd(DateInterval.Day, 2, TimesheetDate).ToLongDateString() 'String.Format(c, "{0:dddd}", DateAdd(DateInterval.Day, 2, TimesheetDate)) 'DateAdd(DateInterval.Day, 2, TimesheetDate).DayOfWeek.ToString()

            Me.HfWednesday.Value = DateAdd(DateInterval.Day, 3, TimesheetDate).ToShortDateString()
            Me.LabelWednesdayText.Text = DateAdd(DateInterval.Day, 3, TimesheetDate).ToLongDateString() 'String.Format(c, "{0:dddd}", DateAdd(DateInterval.Day, 3, TimesheetDate)) ' DateAdd(DateInterval.Day, 3, TimesheetDate).DayOfWeek.ToString()

            Me.HfThursday.Value = DateAdd(DateInterval.Day, 4, TimesheetDate).ToShortDateString()
            Me.LabelThursdayText.Text = DateAdd(DateInterval.Day, 4, TimesheetDate).ToLongDateString() 'String.Format(c, "{0:dddd}", DateAdd(DateInterval.Day, 4, TimesheetDate)) 'DateAdd(DateInterval.Day, 4, TimesheetDate).DayOfWeek.ToString()

            Me.HfFriday.Value = DateAdd(DateInterval.Day, 5, TimesheetDate).ToShortDateString()
            Me.LabelFridayText.Text = DateAdd(DateInterval.Day, 5, TimesheetDate).ToLongDateString() 'String.Format(c, "{0:dddd}", DateAdd(DateInterval.Day, 5, TimesheetDate)) 'DateAdd(DateInterval.Day, 5, TimesheetDate).DayOfWeek.ToString()

            Me.HfSaturday.Value = DateAdd(DateInterval.Day, 6, TimesheetDate).ToShortDateString()
            Me.LabelSaturdayText.Text = DateAdd(DateInterval.Day, 6, TimesheetDate).ToLongDateString() 'String.Format(c, "{0:dddd}", DateAdd(DateInterval.Day, 6, TimesheetDate)) 'DateAdd(DateInterval.Day, 6, TimesheetDate).DayOfWeek.ToString()

        Catch ex As Exception
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.LoadTimesheet()

            'If Me.DaysToShow <> 7 Then

            '    Me.TrSaturday.Visible = False
            '    Me.TrSunday.Visible = False
            '    Me.LnkBtnSaturday.Visible = False
            '    Me.LnkBtnSunday.Visible = False

            'End If

        End If

    End Sub

#End Region

    Private Sub CloseAndRefresh()

        Me.CloseThisWindowAndRefreshCaller("Timesheet.aspx")

    End Sub
    Private Function GetEmpFullName(ByVal emp_code As String) As String
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As String

        SQL_STR = "SELECT ISNULL(EMP_FML,'') FROM V_ACTIVE_EMPLOYEE WHERE EMP_CODE = '" & emp_code & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetString(0)

            Return value

        Catch
            Err.Raise(Err.Number, "Class:Timesheet.aspx Routine:GetSendAlertSuper", Err.Description)
        End Try
    End Function
    Private Function GetEmpSuper(ByVal emp_code As String) As String
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As String
        SQL_STR = "SELECT ISNULL(SUPERVISOR_CODE,'') FROM EMPLOYEE WHERE EMP_CODE = '" & emp_code & "'"
        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetString(0)
            Return value
        Catch
            Err.Raise(Err.Number, "Class:Timesheet.aspx Routine:GetSendAlertSuper", Err.Description)
        End Try
    End Function
    Private Function GetSendAlertSuper() As Boolean
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As Integer
        SQL_STR = "SELECT ISNULL(AUTO_ALERT_SUPER,0) FROM AGENCY"
        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetInt16(0)
            If value = 1 Then
                Return True
            Else
                Return False
            End If
        Catch
            Err.Raise(Err.Number, "Class:Timesheet.aspx Routine:GetSendAlertSuper", Err.Description)
        End Try
    End Function
    Private Sub LoadTimesheet()

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        Dim ThisTS As AdvantageFramework.Timesheet.TimeSheet = AdvantageFramework.Timesheet.GetTimeSheet(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, TimesheetDate, TimesheetDate.AddDays(6), )

        Me.SetDay(ThisTS, Me.HfSunday, Me.LnkBtnSunday, Me.LblSunday, Me.ImgBtnSundayNotes)
        Me.SetDay(ThisTS, Me.HfMonday, Me.LnkBtnMonday, Me.LblMonday, Me.ImgBtnMondayNotes)
        Me.SetDay(ThisTS, Me.HfTuesday, Me.LnkBtnTuesday, Me.LblTuesday, Me.ImgBtnTuesdayNotes)
        Me.SetDay(ThisTS, Me.HfWednesday, Me.LnkBtnWednesday, Me.LblWednesday, Me.ImgBtnWednesdayNotes)
        Me.SetDay(ThisTS, Me.HfThursday, Me.LnkBtnThursday, Me.LblThursday, Me.ImgBtnThursdayNotes)
        Me.SetDay(ThisTS, Me.HfFriday, Me.LnkBtnFriday, Me.LblFriday, Me.ImgBtnFridayNotes)
        Me.SetDay(ThisTS, Me.HfSaturday, Me.LnkBtnSaturday, Me.LblSaturday, Me.ImgBtnSaturdayNotes)

    End Sub
    Private Sub SetDay(ByRef TS As AdvantageFramework.Timesheet.TimeSheet, ByRef DateHiddenField As HiddenField,
                       ByRef ActionLinkButton As LinkButton, ByRef StatusLabel As Label, ByRef NotesImageButton As ImageButton)


        Dim Column As AdvantageFramework.Timesheet._TimesheetDay

        Column = AdvantageFramework.Timesheet.GetTimesheetDayByDate(TS, DateHiddenField.Value)

        If Column IsNot Nothing Then

            'Set link button
            If Column.IsPendingApproval = True Then

                ActionLinkButton.Text = "Un-submit"
                ActionLinkButton.Visible = True

            ElseIf Column.CanEdit = True Or Column.IsDenied = True Then

                ActionLinkButton.Text = "Submit"
                ActionLinkButton.Visible = True

            Else

                ActionLinkButton.Text = ""
                ActionLinkButton.Visible = False

            End If

            If ActionLinkButton.Visible = True Then

                ActionLinkButton.ToolTip = ActionLinkButton.Text & " " & Column.Date.ToLongDateString()

            End If

            'set current status label
            If Column.IsApproved = True Then

                StatusLabel.Text = "Approved"
                StatusLabel.ToolTip = Column.Date.ToLongDateString() & " is " & StatusLabel.Text

            ElseIf Column.IsPendingApproval = True Then

                StatusLabel.Text = "Pending"
                StatusLabel.ToolTip = Column.Date.ToLongDateString() & " is " & StatusLabel.Text

            ElseIf Column.IsDenied = True Then

                StatusLabel.Text = "Denied"
                StatusLabel.ToolTip = Column.Date.ToLongDateString() & " is " & StatusLabel.Text

            Else

                StatusLabel.Text = FormatNumber(Column.TotalHours, 2) & " Hours"
                If Column.CanEdit = True Then StatusLabel.ToolTip = StatusLabel.Text & " ready to submit"

            End If

            NotesImageButton.ToolTip = StatusLabel.ToolTip

            'set notes image button
            If Column.IsPendingApproval = True Or Column.IsApproved Or Column.IsDenied = True Then

                NotesImageButton.Visible = True
                NotesImageButton.Attributes.Add("onclick", "OpenRadWindow('','popcomments.aspx?type=timeapproval&id=" & Me.TimesheetEmpCode & "|" & DateHiddenField.Value & "',0,0,false);return false;")

            Else

                NotesImageButton.Visible = False
                NotesImageButton.Attributes.Remove("onclick")

            End If

            'some overrides
            If StatusLabel.Text = "" And ActionLinkButton.Text = "" Then

                NotesImageButton.Visible = False

            End If

            If Column.TotalHours = 0 Then

                StatusLabel.Text = "[No hours]"
                StatusLabel.ToolTip = "No hours for " & Column.Date.ToLongDateString()
                ActionLinkButton.Visible = False
                NotesImageButton.Visible = False

            End If

        Else

            StatusLabel.Text = "[No hours]"
            StatusLabel.ToolTip = "No hours for " & Column.Date.ToLongDateString()
            ActionLinkButton.Visible = False
            NotesImageButton.Visible = False

        End If

    End Sub
    Private Function SendEmailAlert(ByVal AlertID As Integer) As Boolean
        Try

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                              HttpContext.Current.Session("UserCode"),
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = AlertID
                .Subject = "[New Alert]"
                .AppName = "Timesheet"
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .Send()

            End With

            Me.CheckForAsyncMessage()

            Return True

        Catch ex As Exception

            Me.ShowMessage("Alert Email not Sent.  " & ex.Message.ToString())
            SendEmailAlert = False

        End Try
    End Function
    Private Function SetApproval(ByVal ThisDate As Date, ByVal Approval As Boolean, ByRef ErrorMessage As String)
        'Dim m As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))

        If AdvantageFramework.Timesheet.HasStopWatch(Session("ConnString"), Me.TimesheetEmpCode, ThisDate, ThisDate) = True Then

            ErrorMessage = "You have a stopwatch running.  Please stop it before proceeding."
            Return False

        End If

        If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, ThisDate) = True And Approval = True Then

            ErrorMessage = ThisDate.DayOfWeek.ToString() & " is missing comment(s) and cannot be submitted for approval."
            Return False

        End If

        If ThisEmpFullName = "" Then

            ThisEmpFullName = GetEmpFullName(Me.TimesheetEmpCode)

        End If

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        oTS.SubmitForApproval(Me.TimesheetEmpCode, ThisDate, Approval)

        If GetSendAlertSuper() = True And Approval = True Then

            'Dim Alert As New Alert(Session("ConnString"))
            Dim agy As New cAgency(HttpContext.Current.Session("ConnString"))
            Dim NowDate As Date = Now
            Dim url As String = agy.WebvantageURL()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                With FxAlert

                    .AlertTypeID = 3
                    .AlertCategoryID = 43
                    .Subject = "Timesheet Approval Request for " & ThisEmpFullName & " for " & cGlobals.wvCDate(ThisDate).ToShortDateString()
                    .Body = AdvantageFramework.EmployeeTimesheet.WriteTimesheetSuperviorApprovalLink(url, cGlobals.wvCDate(ThisDate).ToShortDateString(), Me.TimesheetEmpCode, False)
                    .EmailBody = .Body
                    .GeneratedDate = NowDate
                    .LastUpdated = NowDate
                    .PriorityLevel = 3
                    .EmployeeCode = Me.TimesheetEmpCode
                    .UserCode = Session("UserCode")

                End With

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                    Dim Alert As New Alert(Session("ConnString"))

                    Alert.LoadByPrimaryKey(FxAlert.ID)
                    Alert.AddAlertRecipient(GetEmpSuper(Me.TimesheetEmpCode))
                    SendEmailAlert(Alert.ALERT_ID)

                Else

                    Me.ShowMessage("Alert failed to save")

                End If

            End Using

        End If

        ErrorMessage = ""
        Return True

    End Function
    Private Sub SubmitAll()

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim TimeSubmitted As Boolean = False

        If AdvantageFramework.Timesheet.HasStopWatch(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSunday.Value), cGlobals.wvCDate(Me.HfSaturday.Value)) = True Then

            Me.ShowMessage("You have a stopwatch running.  Please stop it before proceeding.")
            Exit Sub

        End If
        If ThisEmpFullName = "" Then

            ThisEmpFullName = GetEmpFullName(Me.TimesheetEmpCode)

        End If

        If Me.LnkBtnMonday.Visible = True And Me.LnkBtnMonday.Text.Trim() = "Submit" Then

            If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfMonday.Value)) = True Then

                Me.ShowMessage("Monday is missing comments and cannot be submitted for approval.")
                Exit Sub

            Else

                oTS.SubmitForApproval(Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfMonday.Value), True)
                TimeSubmitted = True

            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfMonday.Value))
        End If
        If Me.LnkBtnTuesday.Visible = True And Me.LnkBtnTuesday.Text.Trim() = "Submit" Then
            If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfTuesday.Value)) = True Then

                Me.ShowMessage("Tuesday is missing comments and cannot be submitted for approval.")
                Exit Sub

            Else

                oTS.SubmitForApproval(Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfTuesday.Value), True)
                TimeSubmitted = True

            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfTuesday.Value))
        End If
        If Me.LnkBtnWednesday.Visible = True And Me.LnkBtnWednesday.Text.Trim() = "Submit" Then
            If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfWednesday.Value)) = True Then

                Me.ShowMessage("Wednesday is missing comments and cannot be submitted for approval.")
                Exit Sub

            Else

                oTS.SubmitForApproval(Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfWednesday.Value), True)
                TimeSubmitted = True

            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfWednesday.Value))
        End If
        If Me.LnkBtnThursday.Visible = True And Me.LnkBtnThursday.Text.Trim() = "Submit" Then
            If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfThursday.Value)) = True Then

                Me.ShowMessage("Thursday is missing comments and cannot be submitted for approval.")
                Exit Sub

            Else

                oTS.SubmitForApproval(Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfThursday.Value), True)
                TimeSubmitted = True

            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfThursday.Value))
        End If
        If Me.LnkBtnFriday.Visible = True And Me.LnkBtnFriday.Text.Trim() = "Submit" Then
            If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfFriday.Value)) = True Then

                Me.ShowMessage("Friday is missing comments and cannot be submitted for approval.")
                Exit Sub

            Else

                oTS.SubmitForApproval(Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfFriday.Value), True)
                TimeSubmitted = True

            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfFriday.Value))
        End If

        If Me.LnkBtnSaturday.Visible = True And Me.LnkBtnSaturday.Text.Trim() = "Submit" Then
            If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSaturday.Value)) = True Then

                Me.ShowMessage("Saturday is missing comments and cannot be submitted for approval.")
                Exit Sub

            Else

                oTS.SubmitForApproval(Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSaturday.Value), True)
                TimeSubmitted = True

            End If
        Else
            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSaturday.Value))
        End If

        If Me.LnkBtnSunday.Visible = True And Me.LnkBtnSunday.Text.Trim() = "Submit" Then
            If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSunday.Value)) = True Then

                Me.ShowMessage("Sunday is missing comments and cannot be submitted for approval.")
                Exit Sub

            Else

                oTS.SubmitForApproval(Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSunday.Value), True)
                TimeSubmitted = True

            End If
        Else

            AdvantageFramework.Timesheet.DeleteZeroHours(Session("ConnString"), Me.TimesheetEmpCode, cGlobals.wvCDate(Me.HfSunday.Value))

        End If

        If GetSendAlertSuper() = True And TimeSubmitted = True Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                Dim NowDate As Date = Now
                Dim agy As New cAgency(_Session.ConnectionString)
                Dim url As String

                url = agy.WebvantageURL

                With FxAlert

                    .AlertTypeID = 3
                    .AlertCategoryID = 43
                    .Subject = "Timesheet Approval Request for " & ThisEmpFullName & " for week of: " & cGlobals.wvCDate(Me.HfSunday.Value).ToShortDateString()
                    .Body = AdvantageFramework.EmployeeTimesheet.WriteTimesheetSuperviorApprovalLink(url, cGlobals.wvCDate(Me.HfSunday.Value).ToShortDateString(), Me.TimesheetEmpCode, True)
                    .EmailBody = .Body
                    .GeneratedDate = NowDate
                    .LastUpdated = NowDate
                    .PriorityLevel = 3
                    .EmployeeCode = Me.TimesheetEmpCode
                    .AlertLevel = ""
                    .UserCode = Session("UserCode")

                End With

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                    Dim Alert As New Alert(Session("ConnString"))
                    Alert.LoadByPrimaryKey(FxAlert.ID)
                    Alert.AddAlertRecipient(GetEmpSuper(Me.TimesheetEmpCode))

                    SendEmailAlert(Alert.ALERT_ID)

                Else

                    Me.ShowMessage("Alert failed to save")

                End If

            End Using

        End If

        Me.CloseAndRefresh()

    End Sub


#End Region

End Class