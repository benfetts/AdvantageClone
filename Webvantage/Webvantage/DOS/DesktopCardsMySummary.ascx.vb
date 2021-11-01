Imports System.Data.Objects

Public Class DesktopCardsMySummary
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Public IsUiSimple As Boolean = True
    Public Tasks As Integer = 0
    Public Assignments As Integer = 0
    Public Alerts As Integer = 0
    Public WelcomeMessage As String = "Welcome!"

    Private _HighPriorityAssignments As Integer = 0
    Private _HighPriorityAlerts As Integer = 0
    Private _HighPriorityTasks As Integer = 0

    Private _OverDueTasks As Integer = 0
    Private _OverDueAssignments As Integer = 0
    Private _OverDueAlerts As Integer = 0

    Private _TasksDueToday As Integer = 0
    Private _AssignmentsDueToday As Integer = 0
    Private _AlertsDueToday As Integer = 0



#End Region

#Region " Properties "

    Private Property _EmployeeCode As String = "" 'HttpContext.Current.Session("EmpCode").ToString()
    Private Property _ClientContactID As Integer = 0

#End Region

#Region " Methods "

    Private Sub DesktopCardsMySummary_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If IsUiSimple = True Then

            Me.DivWelcomeText.Visible = False

        End If

    End Sub
    Private Sub DesktopCardsMySummary_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Me.EventTarget = "SignOut" Then Exit Sub
        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        Me.LiteralDate.Text = cEmployee.TimeZoneToday.ToLongDateString()

        If Me.LiteralDate.Text.Length > 20 Then

            DivDate.Attributes.Add("class", "longdate-smaller")

        Else

            DivDate.Attributes.Add("class", "longdate")

        End If

        If Not Me.IsPostBack AndAlso Not Me.Page.IsCallback Then

            If Me.IsClientPortal = False Then

                If HttpContext.Current.Session("EmpCode") IsNot Nothing Then

                    _EmployeeCode = HttpContext.Current.Session("EmpCode")

                End If

                If _Session IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim ep As AdvantageFramework.Database.Entities.EmployeePicture
                        ep = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, _EmployeeCode)
                        If ep IsNot Nothing Then

                            If ep.Image IsNot Nothing Then

                                Me.ASPxBinaryImageEmp.Value = ep.Image

                            End If
                            If ep.Nickname IsNot Nothing Then

                                Me.WelcomeMessage = "Welcome " & ep.Nickname & "!"

                            Else

                                Dim emp As AdvantageFramework.Database.Views.Employee
                                emp = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                If emp IsNot Nothing Then

                                    WelcomeMessage = "Welcome " & emp.FirstName & "!"

                                End If

                                Me.LiteralEmployeeName.Text = WelcomeMessage

                            End If

                        End If

                    End Using

                End If

            Else

                If HttpContext.Current.Session("UserID") IsNot Nothing Then

                    _ClientContactID = HttpContext.Current.Session("UserID")

                End If

                If _Session IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim cc As AdvantageFramework.Database.Entities.ClientContact
                        cc = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, _ClientContactID)

                        If cc IsNot Nothing Then

                            WelcomeMessage = "Welcome " & cc.FirstName & "!"

                        End If

                        Me.LiteralEmployeeName.Text = WelcomeMessage

                    End Using

                End If

            End If

            Me.LoadData()

        Else

            Select Case Me.EventTarget

                Case "RebindGrid",
                     "UpdatePanelUserSummary",
                     "UpdatePanelUserAssignments",
                     "UpdatePanelUserAlerts",
                     "UpdatePanelUserTasks"

                    Me.LoadData()

            End Select


        End If



    End Sub

    Public Sub LoadData()

        If HttpContext.Current.Session("ConnString") Is Nothing Then Exit Sub

        Tasks = 0
        Assignments = 0
        Alerts = 0

        _HighPriorityAssignments = 0
        _HighPriorityAlerts = 0
        _HighPriorityTasks = 0

        _OverDueTasks = 0
        _OverDueAssignments = 0
        _OverDueAlerts = 0

        _TasksDueToday = 0
        _AssignmentsDueToday = 0
        _AlertsDueToday = 0

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            If Me.IsClientPortal = False Then

                'Dim MyAlertsAndAssignments As IQueryable(Of AdvantageFramework.Database.Entities.Alert)

                'MyAlertsAndAssignments = AdvantageFramework.Database.Procedures.Alert.LoadEmployeeAlertsAndAssignments(DbContext, _EmployeeCode, 0, 10000)

                'If MyAlertsAndAssignments IsNot Nothing Then

                '    'Assignments = MyAlertsAndAssignments.Where(Function(Alert) Alert.AlertRecipients.Any(Function(AlertRecipient) If(AlertRecipient.IsCurrentNotify, 0) = 1)).Count()
                '    'Alerts = MyAlertsAndAssignments.Where(Function(Alert) If(Alert.AlertAssignmentTemplateID, 0) = 0).Count()


                '    _OverDueAssignments = MyAlertsAndAssignments.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso Alert.DueDate <= Now) AndAlso _
                '                                                       Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify = 1)).Count()
                '    _OverDueAlerts = MyAlertsAndAssignments.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso Alert.DueDate <= Now) AndAlso _
                '                                                 (Alert.AlertAssignmentTemplateID Is Nothing)).Count()

                '    _AssignmentsDueToday = MyAlertsAndAssignments.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso EntityFunctions.TruncateTime(Alert.DueDate) = EntityFunctions.TruncateTime(Now)) AndAlso _
                '                                                        Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify = 1)).Count()
                '    _AlertsDueToday = MyAlertsAndAssignments.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso EntityFunctions.TruncateTime(Alert.DueDate) = EntityFunctions.TruncateTime(Now)) AndAlso _
                '                                                  (Alert.AlertAssignmentTemplateID Is Nothing)).Count()

                '    _HighPriorityAssignments = MyAlertsAndAssignments.Where(Function(Alert) (Alert.PriorityLevel IsNot Nothing AndAlso Alert.PriorityLevel = 5 OrElse Alert.PriorityLevel = 4) _
                '                                                            AndAlso Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify = 1)).Count()
                '    _HighPriorityAlerts = MyAlertsAndAssignments.Where(Function(Alert) (Alert.PriorityLevel IsNot Nothing AndAlso (Alert.PriorityLevel = 5 OrElse Alert.PriorityLevel = 4)) _
                '                                                       AndAlso Alert.AlertAssignmentTemplateID Is Nothing).Count()

                'End If

                Dim MyAlerts As IQueryable(Of AdvantageFramework.Database.Entities.Alert)
                MyAlerts = AdvantageFramework.Database.Procedures.Alert.LoadEmployeeAlerts(DbContext, _EmployeeCode, 0, 10000)

                If MyAlerts IsNot Nothing Then

                    'Alerts = MyAlerts.Count()
                    Try
                        _OverDueAlerts = MyAlerts.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso Entity.Core.Objects.EntityFunctions.TruncateTime(Alert.DueDate) < Entity.Core.Objects.EntityFunctions.TruncateTime(Now))).Count()
                    Catch ex As Exception
                    End Try
                    Try
                        _AlertsDueToday = MyAlerts.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso Entity.Core.Objects.EntityFunctions.TruncateTime(Alert.DueDate) = Entity.Core.Objects.EntityFunctions.TruncateTime(Now))).Count()
                    Catch ex As Exception
                    End Try
                    Try
                        _HighPriorityAlerts = MyAlerts.Where(Function(Alert) (Alert.PriorityLevel IsNot Nothing AndAlso (Alert.PriorityLevel = 5 OrElse Alert.PriorityLevel = 4))).Count()
                    Catch ex As Exception
                    End Try

                End If
                Dim MyAssignments As IQueryable(Of AdvantageFramework.Database.Entities.Alert)
                MyAssignments = AdvantageFramework.Database.Procedures.Alert.LoadEmployeeAssignments(DbContext, _EmployeeCode, 0, 10000)

                If MyAssignments IsNot Nothing Then

                    'Assignments = MyAssignments.Count()
                    Try
                        _OverDueAssignments = MyAssignments.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso Entity.Core.Objects.EntityFunctions.TruncateTime(Alert.DueDate) < Entity.Core.Objects.EntityFunctions.TruncateTime(Now))).Count()
                    Catch ex As Exception
                    End Try
                    Try
                        _AssignmentsDueToday = MyAssignments.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso Entity.Core.Objects.EntityFunctions.TruncateTime(Alert.DueDate) = Entity.Core.Objects.EntityFunctions.TruncateTime(Now))).Count()
                    Catch ex As Exception
                    End Try
                    Try
                        _HighPriorityAssignments = MyAssignments.Where(Function(Alert) (Alert.PriorityLevel IsNot Nothing AndAlso (Alert.PriorityLevel = 5 OrElse Alert.PriorityLevel = 4))).Count()
                    Catch ex As Exception
                    End Try

                End If

                Dim a As New cAlerts()

                Try

                    'a.LoadAlerts(Session("EmpCode"), "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", 0, "myalerts",
                    '      0, "", False, False, 0, "", "", "", "", 0, 0, True, Alerts, False, False, "")

                Catch ex As Exception
                End Try
                Try

                    'a.LoadAlerts(Session("EmpCode"), "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0, "", "", "", "", 0, 0, "", "", 0, "myalertassignments",
                    '      0, "", False, False, 0, "", "", "", "", 0, 0, True, Assignments, False, False, "")

                Catch ex As Exception
                End Try


                ''Dim a As New cAlerts()
                ''Dim dt As New DataTable
                ''dt = a.GetAlertSummary(Session("EmpCode"))
                ''If Not dt Is Nothing Then

                ''    If dt.Rows.Count > 0 Then

                ''        If Not IsDBNull(dt.Rows(0)("TOTAL_ALERTS")) = True Then
                ''            Alerts = CType(dt.Rows(0)("TOTAL_ALERTS"), Integer)
                ''        End If
                ''        If Not IsDBNull(dt.Rows(0)("ALERTS_OVERDUE")) = True Then
                ''            _OverDueAlerts = CType(dt.Rows(0)("ALERTS_OVERDUE"), Integer)
                ''        End If
                ''        If Not IsDBNull(dt.Rows(0)("ALERTS_DUE_TODAY")) = True Then
                ''            _AlertsDueToday = CType(dt.Rows(0)("ALERTS_DUE_TODAY"), Integer)
                ''        End If
                ''        If Not IsDBNull(dt.Rows(0)("HIGH_PRIORITY_ALERTS")) = True Then
                ''            _HighPriorityAlerts = CType(dt.Rows(0)("HIGH_PRIORITY_ALERTS"), Integer)
                ''        End If


                ''        If Not IsDBNull(dt.Rows(0)("TOTAL_ASSIGNMENTS")) = True Then
                ''            Assignments = CType(dt.Rows(0)("TOTAL_ASSIGNMENTS"), Integer)
                ''        End If
                ''        If Not IsDBNull(dt.Rows(0)("ASSIGNMENTS_OVERDUE")) = True Then
                ''            _OverDueAssignments = CType(dt.Rows(0)("ASSIGNMENTS_OVERDUE"), Integer)
                ''        End If
                ''        If Not IsDBNull(dt.Rows(0)("ASSIGNMENTS_DUE_TODAY")) = True Then
                ''            _AssignmentsDueToday = CType(dt.Rows(0)("ASSIGNMENTS_DUE_TODAY"), Integer)
                ''        End If
                ''        If Not IsDBNull(dt.Rows(0)("HIGH_PRIORITY_ASSIGNMENTS")) = True Then
                ''            _HighPriorityAssignments = CType(dt.Rows(0)("HIGH_PRIORITY_ASSIGNMENTS"), Integer)
                ''        End If

                ''    End If

                ''End If

            Else

                Dim MyAlerts As IQueryable(Of AdvantageFramework.Database.Entities.Alert)

                MyAlerts = AdvantageFramework.Database.Procedures.Alert.LoadClientContactAlerts(DbContext, _ClientContactID, 0, 500)
                If MyAlerts IsNot Nothing Then

                    Alerts = MyAlerts.Count()
                    _OverDueAlerts = MyAlerts.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso Entity.Core.Objects.EntityFunctions.TruncateTime(Alert.DueDate) < Entity.Core.Objects.EntityFunctions.TruncateTime(Now))).Count()
                    _AlertsDueToday = MyAlerts.Where(Function(Alert) (Alert.DueDate IsNot Nothing AndAlso Entity.Core.Objects.EntityFunctions.TruncateTime(Alert.DueDate) = Entity.Core.Objects.EntityFunctions.TruncateTime(Now))).Count()
                    _HighPriorityAlerts = MyAlerts.Where(Function(Alert) (Alert.PriorityLevel IsNot Nothing AndAlso (Alert.PriorityLevel = 5 OrElse Alert.PriorityLevel = 4))).Count()

                End If

            End If

            If Assignments > 0 Then

                Me.LabelAssignments.Text = "Assignments:  " & Assignments.ToString()
                Me.LabelHighPriorityAssignments.Text = _HighPriorityAssignments.ToString()
                Me.LabelAssignmentsDueToday.Text = _AssignmentsDueToday.ToString()
                Me.LabelOverDueAssignments.Text = _OverDueAssignments.ToString()
                Me.PanelAssignments.Attributes.Add("onclick", "CallUiAction(8);OpenRadWindow('', 'Alert_Inbox.aspx?bm=1&ai_folder=Inbox&ai_type=0&ai_cat=0&ai_show=myalertassignments&ai_gf=&ai_search=&emp=" & Session("EmpCode") & "');")

            Else

                Me.PanelAssignments.Visible = False

            End If

            If Alerts > 0 Then

                Me.LabelAlerts.Text = "Alerts:  " & Alerts.ToString()
                Me.LabelHighPriorityAlerts.Text = _HighPriorityAlerts.ToString()
                Me.LabelAlertsDueToday.Text = _AlertsDueToday.ToString()
                Me.LabelOverDueAlerts.Text = _OverDueAlerts.ToString()
                Me.PanelAlerts.Attributes.Add("onclick", "CallUiAction(8);OpenRadWindow('', 'Alert_Inbox.aspx?bm=1&ai_folder=Inbox&ai_type=0&ai_cat=0&ai_show=myalerts&ai_gf=&ai_search=&emp=" & Session("EmpCode") & "');")

            Else

                Me.PanelAlerts.Visible = False

            End If

            If Me.IsClientPortal = False Then

                Dim TaskType As String = ""
                Dim TaskShow As String = "All"
                Dim SearchValue As String = ""

                Dim otask As cTasks = New cTasks(Session("ConnString"))
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

                Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
                Dim dt As New DataTable

                dt = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today.Date, TaskType, TaskShow, SearchValue, MiscFN.IsClientPortal, Session("UserID"))

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    For Each row As DataRow In dt.Rows

                        'If row("TempCompleteDate") Is System.DBNull.Value Then

                        Tasks += 1

                        If row("DueDate") IsNot Nothing AndAlso row("DueDate") IsNot System.DBNull.Value AndAlso IsDate(row("DueDate")) = True Then

                            If CDate(row("DueDate")) = Today.Date Then

                                _TasksDueToday += 1

                            End If
                            If CDate(row("DueDate")) < Today.Date Then

                                _OverDueTasks += 1

                            End If

                        End If
                        If row("TASK_STATUS") IsNot Nothing AndAlso row("TASK_STATUS") IsNot System.DBNull.Value Then

                            If row("TASK_STATUS").ToString() = "H" Then

                                _HighPriorityTasks += 1

                            End If

                        End If

                        'End If

                    Next

                End If

            End If

            If Tasks > 0 Then

                Me.LabelTasks.Text = "Tasks:  " & Tasks.ToString()
                Me.LabelHighPriorityTasks.Text = _HighPriorityTasks.ToString()
                Me.LabelTasksDueToday.Text = _TasksDueToday.ToString()
                Me.LabelOverDueTasks.Text = _OverDueTasks.ToString()
                Me.PanelTasks.Attributes.Add("onclick", "OpenRadWindow('My Tasks', 'DesktopObjectWindow.aspx?dtoname=DesktopMyTasks.ascx');")

            Else

                Me.PanelTasks.Visible = False

            End If

            Me.LinkButtonLastUpdated.Text = "Last Updated:  " & Now.ToShortTimeString()

        End Using

    End Sub

    Private Sub LinkButtonLastUpdated_Click(sender As Object, e As EventArgs) Handles LinkButtonLastUpdated.Click

        Me.LoadData()

    End Sub

    Private Sub ImageButtonRefreshDesktopCardsMySummary_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefreshDesktopCardsMySummary.Click

        Me.LoadData()

    End Sub

#End Region

End Class
