Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class TrafficSchedule_Replace
    Inherits Webvantage.BaseChildPage

    Private JobCompList As String = "" 'ex:   1,1|1,2|3,1
    Private IsWorksheetMulti As Boolean = False
    Private IsOneClient As Boolean = False
    Private CliCode As String = ""
    Private DivCode As String = ""
    Private PrdCode As String = ""

#Region " Variables "
    
    Private ClientCode As String = ""
    Private DivisionCode As String = ""
    Private ProductCode As String = ""
    Private JobNumber As Integer = 0
    Private JobCompNumber As Integer = 0
    Private EmpCode As String = ""
    Private ManagerCode As String = ""
    Private TaskCode As String = ""
    Private AccountExecCode As String = ""
    Private RoleCode As String = ""
    Private CutOffDate As String = ""
    Private IncludeCompletedTasks As Boolean = True
    Private IncludeOnlyPendingTasks As Boolean = False
    Private ExcludeProjectedTasks As Boolean = False
    Private IncludeCompletedSchedules As Boolean = True
    Private CampaignCode As String = ""
    Private TaskPhaseFilter As String = ""
    Private OfficeCode As String = ""
    Private SalesClass As String = ""
    Private qs As String = ""

    

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetVariables()
        Try
            If Not Request.QueryString("wm") Is Nothing Then
                If CType(Request.QueryString("wm"), Integer) = 1 Then
                    Me.IsWorksheetMulti = True
                End If
            End If
        Catch ex As Exception
            Me.IsWorksheetMulti = False
        End Try
        Try
            If Not Request.QueryString("l") Is Nothing Then
                Me.JobCompList = Request.QueryString("l").ToString()
                Me.JobCompList = MiscFN.RemoveTrailingDelimiter(Me.JobCompList, "|")
            End If
        Catch ex As Exception
            Me.JobCompList = ""
        End Try
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.GetClientCode()
            With Me.DropFindAndReplaceType.Items
                .Clear()
                .Add(New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Start Date", "start_date"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Due Date", "due_date"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Time Due", "time_due"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Completed Date", "completed_date"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Employee Assignment", "employee_assignment"))
                If Me.IsWorksheetMulti = False Or Me.IsOneClient = True Then
                    .Add(New Telerik.Web.UI.RadComboBoxItem("Client Contact Assignment", "client_contact_assignment"))
                End If
                .Add(New Telerik.Web.UI.RadComboBoxItem("Task Status", "task_status"))
                'If Me.IsWorksheetMulti = True Then
                .Add(New Telerik.Web.UI.RadComboBoxItem("Manager", "manager"))
                'End If
            End With
            Me.ShowForm()
        End If
    End Sub

    Private Sub GetClientCode()
        If Me.JobCompList <> "" Then
            Dim ar() As String
            Dim StrSQL As String = ""
            ar = Me.JobCompList.Split("|")
            'is it one job or more than one?
            If ar.Length = 1 Then
                Me.IsOneClient = True
                Dim ThisJob As Integer = 0
                Dim ar2() As String
                ar2 = ar(0).Split(",")
                Try
                    ThisJob = CType(ar2(0), Integer)
                Catch ex As Exception
                    ThisJob = 0
                End Try
                If ThisJob > 0 Then
                    StrSQL = "SELECT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE FROM JOB_LOG WITH(NOLOCK) WHERE JOB_NUMBER = " & ThisJob.ToString() & ";"
                End If
            ElseIf ar.Length > 1 Then
                'need to check if they all have the same client code...
                Dim JobList As String = ""
                For i As Integer = 0 To ar.Length - 1
                    Dim ar2() As String
                    ar2 = ar(i).Split(",")
                    If ar2.Length = 2 Then
                        JobList += ar2(0) & ","
                    End If
                Next
                JobList = MiscFN.RemoveTrailingDelimiter(JobList, ",")
                If JobList.Trim() <> "" Then
                    StrSQL = "SELECT"
                    StrSQL += " CASE "
                    StrSQL += " 	WHEN COUNT(DISTINCT CL_CODE) = 1 THEN (SELECT DISTINCT CL_CODE FROM JOB_LOG WITH(NOLOCK) WHERE JOB_NUMBER IN (" & JobList.Trim() & ")) "
                    StrSQL += " 	ELSE '' "
                    StrSQL += " END AS CL_CODE "
                    StrSQL += " FROM JOB_LOG WITH(NOLOCK) "
                    StrSQL += " WHERE JOB_NUMBER IN (" & JobList.Trim() & ");"
                End If
            End If

            If StrSQL <> "" Then
                Try
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyCmd As New SqlCommand(StrSQL, MyConn)
                        Try
                            CliCode = MyCmd.ExecuteScalar()
                            If CliCode <> "" Then
                                IsOneClient = True
                            Else
                                IsOneClient = False
                            End If
                        Catch ex As Exception
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                    Dim strs() As String = CliCode.Split("|")
                    Me.CliCode = strs(0)
                    Me.DivCode = strs(1)
                    Me.PrdCode = strs(2)

                Catch ex As Exception
                End Try
            Else
                CliCode = ""
            End If
        End If
    End Sub

    Private Sub DropFindAndReplaceType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropFindAndReplaceType.SelectedIndexChanged
        Me.ShowForm()
        ''Me.ClearForm()
        If Me.DropFindAndReplaceType.SelectedIndex > 0 Then
            Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                Case "start_date"
                Case "due_date"
                Case "time_due"
                Case "completed_date"

                Case "employee_assignment"
                    'wire up hyperlinks
                Case "client_contact_assignment"
                    'wire up hyperlinks
                Case "task_status"
                Case "manager"
            End Select
        End If
    End Sub

    Private Sub ClearForm()
        Me.LblMSG.Text = ""
        Me.TxtText_SearchFor.Text = ""
        Me.TxtText_ReplaceWith.Text = ""
        Me.RadDatePickerSearchForStart.Clear()
        Me.RadDatePickerSearchForEnd.Clear()
        Me.RadDatePickerReplaceWith.Clear()
    End Sub

    Private Sub ShowForm()
        Me.ClearForm()

        Dim JobComponentTasksList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing
        Dim ArJCs() As String

        If Me.DropFindAndReplaceType.SelectedIndex > 0 Then
            Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                Case "start_date", "due_date", "completed_date"
                    Me.TrText_SearchFor.Visible = False
                    Me.TrText_ReplaceWith.Visible = False
                    Me.TrDate_SearchFor.Visible = True
                    Me.TrDate_ReplaceWith.Visible = True
                    Me.TrTaskStatus_SearchFor.Visible = False
                    Me.TrTaskStatus_ReplaceWith.Visible = False
                    Me.TrTask.Visible = False
                Case "time_due", "employee_assignment", "client_contact_assignment", "manager"
                    Me.TrText_SearchFor.Visible = True
                    Me.TrText_ReplaceWith.Visible = True
                    Me.TrDate_SearchFor.Visible = False
                    Me.TrDate_ReplaceWith.Visible = False
                    Me.TrTaskStatus_SearchFor.Visible = False
                    Me.TrTaskStatus_ReplaceWith.Visible = False
                    If Me.DropFindAndReplaceType.SelectedValue.ToString() = "employee_assignment" Then
                        Me.TrTask.Visible = True
                    Else
                        Me.TrTask.Visible = False
                    End If
                Case "task_status"
                    Me.TrText_SearchFor.Visible = False
                    Me.TrText_ReplaceWith.Visible = False
                    Me.TrDate_SearchFor.Visible = False
                    Me.TrDate_ReplaceWith.Visible = False
                    Me.TrTaskStatus_SearchFor.Visible = True
                    Me.TrTaskStatus_ReplaceWith.Visible = True
                    Me.TrTask.Visible = False
            End Select

            If Me.DropFindAndReplaceType.SelectedValue.ToString() = "time_due" Then
                Me.LblText_SearchFor.Visible = True
                Me.LblText_ReplaceWith.Visible = True
                Me.HlText_SearchFor.Visible = False
                Me.HlText_ReplaceWith.Visible = False
            Else
                Me.LblText_SearchFor.Visible = False
                Me.LblText_ReplaceWith.Visible = False
                Me.HlText_SearchFor.Visible = True
                Me.HlText_ReplaceWith.Visible = True
            End If

            Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                Case "start_date"
                    Me.TxtText_SearchFor.MaxLength = 12
                    Me.TxtText_ReplaceWith.MaxLength = 12
                Case "due_date"
                    Me.TxtText_SearchFor.MaxLength = 12
                    Me.TxtText_ReplaceWith.MaxLength = 12
                Case "time_due"
                    Me.TxtText_SearchFor.MaxLength = 10
                    Me.TxtText_ReplaceWith.MaxLength = 10
                Case "completed_date"
                    Me.TxtText_SearchFor.MaxLength = 12
                    Me.TxtText_ReplaceWith.MaxLength = 12
                Case "employee_assignment", "manager"
                    Me.TxtText_SearchFor.MaxLength = 6
                    Me.TxtText_ReplaceWith.MaxLength = 6
                    'wire up lookups
                    Me.HlText_SearchFor.Attributes.Remove("onclick")
                    Me.HlText_ReplaceWith.Attributes.Remove("onclick")
                    Me.HlText_SearchFor.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtText_SearchFor.ClientID & "&type=empcodeall');return false;")
                    Me.HlText_ReplaceWith.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtText_ReplaceWith.ClientID & "&type=empcode');return false;")
                    Me.HlTask.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TextBoxTask.ClientID & "&type=task&jl=" & Me.JobCompList & "');return false;")
                Case "client_contact_assignment"
                    Me.TxtText_SearchFor.MaxLength = 6
                    Me.TxtText_ReplaceWith.MaxLength = 6
                    Me.HlText_SearchFor.Attributes.Remove("onclick")
                    Me.HlText_ReplaceWith.Attributes.Remove("onclick")
                    Me.GetClientCode()
                    If Me.CliCode <> "" Then
                        Me.HlText_SearchFor.Attributes.Add("onclick", "OpenRadWindowLookup('poplookup_contact.aspx?form=psfr&control=" & Me.TxtText_SearchFor.ClientID & "|" & Me.HfContactCodeID_SearchFor.ClientID & "&type=contacts&client=" & Me.CliCode & "&division=" & Me.DivCode & "&product=" & Me.PrdCode & "');return false;")
                        Me.HlText_ReplaceWith.Attributes.Add("onclick", "OpenRadWindowLookup('poplookup_contact.aspx?form=psfr&control=" & Me.TxtText_ReplaceWith.ClientID & "|" & Me.HfContactCodeID_ReplaceWith.ClientID & "&type=contacts&client=" & Me.CliCode & "&division=" & Me.DivCode & "&product=" & Me.PrdCode & "');return false;")
                    End If
            End Select
            Me.BtnFindAndReplace.Enabled = True
        Else
            Me.TrText_SearchFor.Visible = False
            Me.TrText_ReplaceWith.Visible = False
            Me.TrDate_SearchFor.Visible = False
            Me.TrDate_ReplaceWith.Visible = False
            Me.TrTaskStatus_SearchFor.Visible = False
            Me.TrTaskStatus_ReplaceWith.Visible = False
            Me.BtnFindAndReplace.Enabled = False
            Me.TrTask.Visible = False
        End If
    End Sub

    Private Sub SetVariables()
        If Not Request.QueryString("Cli") = Nothing Then
            Me.ClientCode = Request.QueryString("Cli").ToString()
        End If
        If Not Request.QueryString("Div") = Nothing Then
            Me.DivisionCode = Request.QueryString("Div").ToString()
        End If
        If Not Request.QueryString("Prod") = Nothing Then
            Me.ProductCode = Request.QueryString("Prod").ToString()
        End If
        If Not Request.QueryString("Job") = Nothing Then
            Me.JobNumber = CType(Request.QueryString("Job").ToString(), Integer)
        End If
        If Not Request.QueryString("JobComp") = Nothing Then
            Me.JobCompNumber = CType(Request.QueryString("JobComp").ToString(), Integer)
        End If
        If Not Request.QueryString("Mgr") = Nothing Then
            Me.ManagerCode = Request.QueryString("Mgr").ToString()
        End If
        If Not Request.QueryString("AE") = Nothing Then
            Me.AccountExecCode = Request.QueryString("AE").ToString()
        End If
        If Not Request.QueryString("CS") = Nothing Then
            Me.IncludeCompletedSchedules = CType(Request.QueryString("CS").ToString(), Boolean)
        End If
        If Not Request.QueryString("Emp") = Nothing Then
            Me.EmpCode = Request.QueryString("Emp").ToString()
        End If
        If Not Request.QueryString("Task") = Nothing Then
            Me.TaskCode = Request.QueryString("Task").ToString()
        End If
        If Not Request.QueryString("Role") = Nothing Then
            Me.RoleCode = Request.QueryString("Role").ToString()
        End If
        If Not Request.QueryString("Cut") = Nothing Then
            Me.CutOffDate = Request.QueryString("Cut").ToString()
        End If
        If Not Request.QueryString("Comp") = Nothing Then
            Me.IncludeCompletedTasks = CType(Request.QueryString("Comp").ToString(), Boolean)
        End If
        If Not Request.QueryString("Pend") = Nothing Then
            Me.IncludeOnlyPendingTasks = CType(Request.QueryString("Pend").ToString(), Boolean)
        End If
        If Not Request.QueryString("Proj") = Nothing Then
            Me.ExcludeProjectedTasks = CType(Request.QueryString("Proj").ToString(), Boolean)
        End If
        If Not Request.QueryString("Camp") = Nothing Then
            Me.CampaignCode = Request.QueryString("Camp").ToString()
        End If
        If Not Request.QueryString("P") = Nothing Then
            Me.TaskPhaseFilter = Request.QueryString("P").ToString()
        End If
        If Not Request.QueryString("Off") = Nothing Then
            Me.OfficeCode = Request.QueryString("Off").ToString()
        End If
        If Not Request.QueryString("SC") = Nothing Then
            Me.SalesClass = Request.QueryString("SC").ToString()
        End If
    End Sub

    Private Sub CloseAndRefresh()
        Me.CallFunctionOnParentPage("RefreshGrid")
    End Sub

    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Try
            If Not Request.QueryString("wm") Is Nothing Then
                If CType(Request.QueryString("wm"), Integer) = 1 Then
                    Me.IsWorksheetMulti = True
                End If
            End If
        Catch ex As Exception
            Me.IsWorksheetMulti = False
        End Try

        Dim sbQueryString As New System.Text.StringBuilder
        With sbQueryString
            .Append("Off=")
            .Append(OfficeCode)
            .Append("&")
            .Append("Cli=")
            .Append(ClientCode)
            .Append("&")
            .Append("Div=")
            .Append(DivisionCode)
            .Append("&")
            .Append("Prod=")
            .Append(ProductCode)
            .Append("&")
            .Append("Job=")
            .Append(JobNumber)
            .Append("&")
            .Append("JobComp=")
            .Append(JobCompNumber)
            .Append("&")
            .Append("Emp=")
            .Append(EmpCode)
            .Append("&")
            .Append("Mgr=")
            .Append(ManagerCode)
            .Append("&")
            .Append("Task=")
            .Append(TaskCode)
            .Append("&")
            .Append("AE=")
            .Append(AccountExecCode)
            .Append("&")
            .Append("Role=")
            .Append(RoleCode)
            .Append("&")
            .Append("Cut=")
            .Append(CutOffDate)
            .Append("&")
            .Append("Camp=")
            .Append(CampaignCode)
            .Append("&")
            .Append("SC=")
            .Append(SalesClass)
            .Append("&")
            .Append("Comp=")
            .Append(IncludeCompletedTasks.ToString())
            .Append("&")
            .Append("Pend=")
            .Append(IncludeOnlyPendingTasks.ToString())
            .Append("&")
            .Append("Proj=")
            .Append(ExcludeProjectedTasks.ToString())
            .Append("&")
            .Append("CS=")
            .Append(IncludeCompletedSchedules.ToString())
            .Append("&")
            .Append("P=")
            .Append(TaskPhaseFilter)
        End With
        If Me.IsWorksheetMulti = False Then
            Me.CloseThisWindowAndRefreshCaller(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index")
        Else
            Me.CloseThisWindowAndRefreshCaller("TrafficSchedule_Multiview.aspx?" & sbQueryString.ToString)
        End If

    End Sub

    Private Sub BtnFindAndReplace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFindAndReplace.Click
        Try
            Dim SbLog As New System.Text.StringBuilder
            Me.LblMSG.Text = ""
            Dim StrText_SearchFor As String = ""
            Dim StrText_ReplaceWith As String = ""

            Dim StrDate_SearchFor_StartDate As String = ""
            Dim StrDate_SearchFor_EndDate As String = ""
            Dim StrDate_ReplaceWith_Date As String = ""

            Dim IntCDPContactID_SearchFor As Integer = -1
            Dim IntCDPContactID_ReplaceWith As Integer = -1
            Dim StrLogFrom1 As String = ""
            Dim StrLogFrom2 As String = ""
            Dim StrLogTo As String = ""
            Dim StrTask As String = ""

            Dim StrManagerColumn As String = ""

            Dim jf As New cJobFunctions()
            Dim li As Integer = 0

            Dim JobComponentTasksList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing

            'setup variables and validate input
            Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                Case "start_date", "due_date", "completed_date"

                    If MiscFN.ValidDate(Me.RadDatePickerSearchForStart, True) = False Then
                        Me.LblMSG.Text = "Invalid Search for start date"
                        Exit Sub
                    Else
                        If Not Me.RadDatePickerSearchForStart.SelectedDate Is Nothing Then
                            StrDate_SearchFor_StartDate = cGlobals.wvCDate(Me.RadDatePickerSearchForStart.SelectedDate).ToShortDateString()
                        Else
                            StrDate_SearchFor_StartDate = "NULL"
                        End If
                    End If

                    If MiscFN.ValidDate(Me.RadDatePickerSearchForEnd, True) = False Then
                        Me.LblMSG.Text = "Invalid Search for end date"
                        Exit Sub
                    Else
                        If Not Me.RadDatePickerSearchForEnd.SelectedDate Is Nothing Then
                            StrDate_SearchFor_EndDate = cGlobals.wvCDate(Me.RadDatePickerSearchForEnd.SelectedDate).ToShortDateString()
                        End If
                    End If

                    If cGlobals.wvIsDate(StrDate_SearchFor_StartDate) = True And cGlobals.wvIsDate(StrDate_SearchFor_EndDate) = True Then
                        If MiscFN.StartIsBeforeEnd(StrDate_SearchFor_StartDate, StrDate_SearchFor_EndDate) = False Then
                            Me.LblMSG.Text = "Search for end date is before the Search for start date"
                            Exit Sub
                        End If
                    End If

                    If cGlobals.wvIsDate(StrDate_SearchFor_StartDate) = False And cGlobals.wvIsDate(StrDate_SearchFor_EndDate) = True Then
                        Me.LblMSG.Text = "Cannot use a Search for end date without a Search for start date"
                        Exit Sub
                    End If


                    If MiscFN.EmptyDate(Me.RadDatePickerReplaceWith) = True Then
                        StrDate_ReplaceWith_Date = "NULL"
                    Else
                        If MiscFN.ValidDate(Me.RadDatePickerReplaceWith) = False Then
                            Me.LblMSG.Text = "Invalid Replace with date"
                            Exit Sub
                        Else
                            StrDate_ReplaceWith_Date = cGlobals.wvCDate(Me.RadDatePickerReplaceWith.SelectedDate).ToShortDateString()

                        End If
                    End If

                    StrLogFrom1 = StrDate_SearchFor_StartDate
                    StrLogFrom2 = StrDate_SearchFor_EndDate
                    StrLogTo = StrDate_ReplaceWith_Date
                Case "employee_assignment"
                    Dim v As New cValidations(Session("ConnString"))
                    If Me.TxtText_SearchFor.Text.Trim() = "" Then
                        Me.LblMSG.Text = "Invalid Search for Employee"
                        Exit Sub
                    Else
                        StrText_SearchFor = Me.TxtText_SearchFor.Text.Trim()
                        'validate the employee
                        If v.ValidateEmpCode(StrText_SearchFor) = False Then 'not checking for terminated in the "Search for"
                            Me.LblMSG.Text = "Invalid Search for Employee"
                            Exit Sub
                        End If
                    End If
                    If Me.TxtText_ReplaceWith.Text.Trim() = "" Then
                        StrText_ReplaceWith = "NULL"
                    Else
                        StrText_ReplaceWith = Me.TxtText_ReplaceWith.Text.Trim()
                        'validate the employee...only allow active emp??
                        If v.ValidateEmpCodetd(StrText_ReplaceWith) = False Then
                            Me.LblMSG.Text = "Invalid Replace with Employee"
                            Exit Sub
                        End If
                    End If
                    If Me.TextBoxTask.Text <> "" Then
                        If v.ValidateTaskCode(Me.TextBoxTask.Text) = False Then
                            Me.LblMSG.Text = "Invalid Task Code."
                            Exit Sub
                        End If
                    End If
                    StrLogFrom1 = StrText_SearchFor
                    StrLogFrom2 = ""
                    StrLogTo = StrText_ReplaceWith
                    If Me.TextBoxTask.Text <> "" Then
                        StrTask = Me.TextBoxTask.Text
                    End If
                Case "manager"
                    Dim v As New cValidations(Session("ConnString"))
                    If Me.TxtText_SearchFor.Text.Trim() = "" Then
                        StrText_SearchFor = "NULL"
                    Else
                        StrText_SearchFor = Me.TxtText_SearchFor.Text.Trim()
                        'validate the employee
                        If v.ValidateEmpCode(StrText_SearchFor) = False Then 'not checking for terminated in the "Search for"
                            Me.LblMSG.Text = "Invalid Search for Employee"
                            Exit Sub
                        End If
                    End If
                    If Me.TxtText_ReplaceWith.Text.Trim() = "" Then
                        StrText_ReplaceWith = "NULL"
                    Else
                        StrText_ReplaceWith = Me.TxtText_ReplaceWith.Text.Trim()
                        'validate the employee...only allow active emp??
                        If v.ValidateEmpCodetd(StrText_ReplaceWith) = False Then
                            Me.LblMSG.Text = "Invalid Replace with Employee"
                            Exit Sub
                        End If
                    End If
                    StrLogFrom1 = StrText_SearchFor
                    StrLogFrom2 = ""
                    StrLogTo = StrText_ReplaceWith
                Case "client_contact_assignment"
                    Me.GetClientCode()
                    If Me.TxtText_SearchFor.Text.Trim() = "" Then
                        Me.LblMSG.Text = "Invalid Search for Contact Code"
                        Exit Sub
                    Else
                        StrText_SearchFor = Me.TxtText_SearchFor.Text.Trim()
                        'validate the contact
                        IntCDPContactID_SearchFor = jf.GetCDPContactID(StrText_SearchFor, Me.CliCode)
                        If IntCDPContactID_SearchFor = -1 Then
                            Me.LblMSG.Text = "Invalid Search for Contact Code"
                            Exit Sub
                        Else
                            StrText_SearchFor = IntCDPContactID_SearchFor.ToString()
                        End If
                    End If
                    If Me.TxtText_ReplaceWith.Text.Trim() = "" Then
                        StrText_ReplaceWith = "NULL"
                    Else
                        StrText_ReplaceWith = Me.TxtText_ReplaceWith.Text.Trim()
                        'validate the contact
                        IntCDPContactID_ReplaceWith = jf.GetCDPContactID(StrText_ReplaceWith, Me.CliCode)
                        If IntCDPContactID_ReplaceWith = -1 Then
                            Me.LblMSG.Text = "Invalid Replace with Contact Code"
                            Exit Sub
                        Else
                            StrText_ReplaceWith = IntCDPContactID_ReplaceWith.ToString()
                        End If
                    End If
                    StrLogFrom1 = Me.TxtText_SearchFor.Text.Trim()
                    StrLogFrom2 = ""
                    StrLogTo = Me.TxtText_ReplaceWith.Text.Trim()
                Case "time_due"
                    If Me.TxtText_SearchFor.Text.Trim() = "" Then
                        StrText_SearchFor = "NULL"
                    Else
                        StrText_SearchFor = Me.TxtText_SearchFor.Text.Trim()
                        If StrText_SearchFor.Length > 10 Then
                            Me.LblMSG.Text = "Invalid Search for Time Due"
                            Exit Sub
                        End If
                    End If
                    If Me.TxtText_ReplaceWith.Text.Trim() = "" Then
                        StrText_ReplaceWith = "NULL"
                    Else
                        StrText_ReplaceWith = Me.TxtText_ReplaceWith.Text.Trim()
                        If StrText_ReplaceWith.Length > 10 Then
                            Me.LblMSG.Text = "Invalid Replace with Time Due"
                            Exit Sub
                        End If
                    End If
                    StrLogFrom1 = StrText_SearchFor
                    StrLogFrom2 = ""
                    StrLogTo = StrText_ReplaceWith
                Case "task_status"
                    StrText_SearchFor = Me.DdlTaskStatus_SearchFor.SelectedItem.Value
                    StrText_ReplaceWith = Me.DdlTaskStatus_ReplaceWith.SelectedItem.Value
                    StrLogFrom1 = Me.DdlTaskStatus_SearchFor.SelectedItem.Text
                    StrLogFrom2 = ""
                    StrLogTo = Me.DdlTaskStatus_ReplaceWith.SelectedItem.Text
            End Select

            If Me.DropFindAndReplaceType.SelectedValue.ToString() = "manager" Then
                Try
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        Dim t As String = ""
                        MyConn.Open()
                        Dim MyCmd As New SqlCommand("SELECT CAST(AGY_SETTINGS_VALUE AS VARCHAR(20)) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL';", MyConn)
                        Try
                            t = MyCmd.ExecuteScalar().ToString()
                            Select Case t
                                Case "TR_TITLE1"
                                    StrManagerColumn = "ASSIGN_1"
                                Case "TR_TITLE2"
                                    StrManagerColumn = "ASSIGN_2"
                                Case "TR_TITLE3"
                                    StrManagerColumn = "ASSIGN_3"
                                Case "TR_TITLE4"
                                    StrManagerColumn = "ASSIGN_4"
                                Case "TR_TITLE5"
                                    StrManagerColumn = "ASSIGN_5"
                            End Select
                        Catch ex As Exception
                            StrManagerColumn = ""
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                Catch ex As Exception
                    StrManagerColumn = ""
                End Try
            End If


            'Set the table name
            Dim TableName As String = ""
            Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                Case "start_date", "due_date", "completed_date", "time_due", "task_status"
                    TableName = "JOB_TRAFFIC_DET"
                Case "employee_assignment"
                    TableName = "JOB_TRAFFIC_DET_EMPS"
                Case "client_contact_assignment"
                    TableName = "JOB_TRAFFIC_DET_CNTS"
                Case "manager"
                    TableName = "JOB_TRAFFIC"
            End Select

            'Build the SQL for the job list "where":
            Dim SbJCList As New System.Text.StringBuilder
            Dim StrSeqs As String = ""
            With SbJCList
                'Start the Where clause
                .Append(" WHERE 1 = 1 ")
                .Append(" AND (")
                'Parse the string of job/comps
                Dim ArJCs() As String
                ArJCs = Me.JobCompList.Split("|")
                For i As Integer = 0 To ArJCs.Length - 1
                    Dim ArJC() As String
                    ArJC = ArJCs(i).ToString().Split(",")
                    If ArJC.Length = 2 Then
                        If i > 0 Then
                            .Append(" OR ")
                        End If
                        .Append("(")
                        .Append(TableName)
                        .Append(".JOB_NUMBER = ")
                        .Append(ArJC(0))
                        .Append(" AND ")
                        .Append(TableName)
                        .Append(".JOB_COMPONENT_NBR = ")
                        .Append(ArJC(1))
                        If StrTask <> "" Then
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Dim JobNum As Integer = 0
                                Dim JobCompNum As Short = 0
                                Dim SeqNums As Short() = Nothing

                                JobNum = CInt(ArJC(0))
                                JobCompNum = CInt(ArJC(1))

                                SeqNums = (From Item In AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, JobNum, JobCompNum)
                                           Where Item.TaskCode = StrTask
                                           Select Item.SequenceNumber).ToArray

                                If SeqNums IsNot Nothing AndAlso SeqNums.Count > 0 Then
                                    .Append(" AND ")
                                    .Append(TableName)
                                    .Append(".SEQ_NBR IN (")
                                    .Append(String.Join(",", SeqNums))
                                    .Append(")")
                                Else
                                    .Append(" AND ")
                                    .Append(TableName)
                                    .Append(".SEQ_NBR IN (-1)")
                                End If

                            End Using
                        End If
                        .Append(")")
                    End If

                Next
                .Append(") ")
            End With

            'Build the SQL for the job list "where":
            Dim SbJCListNOT As New System.Text.StringBuilder
            With SbJCListNOT
                'Start the Where clause
                .Append(" AND (")
                'Parse the string of job/comps
                Dim ArJCs() As String
                ArJCs = Me.JobCompList.Split("|")
                For i As Integer = 0 To ArJCs.Length - 1
                    Dim ArJC() As String
                    ArJC = ArJCs(i).ToString().Split(",")
                    If ArJC.Length = 2 Then
                        If i > 0 Then
                            .Append(" OR ")
                        End If
                        .Append("(")
                        .Append(" @REPLACE_WITH NOT IN (SELECT EMP_CODE FROM ")
                        .Append(TableName & " JT WHERE JT")
                        .Append(".JOB_NUMBER = ")
                        .Append(ArJC(0))
                        .Append(" AND JT")
                        .Append(".JOB_COMPONENT_NBR = ")
                        .Append(ArJC(1))
                        .Append(" AND JT.SEQ_NBR = ")
                        .Append(TableName & ".SEQ_NBR")
                        .Append(")")
                        .Append(")")
                    End If

                Next
                .Append(") ")
            End With

            Using MyConn As New SqlConnection(Session("ConnString"))
                Dim MyTrans As SqlTransaction
                MyConn.Open()
                MyTrans = MyConn.BeginTransaction

                'Build the main SQL statement
                Dim SbSQL As New System.Text.StringBuilder
                With SbSQL
                    Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                        Case "start_date"
                            .Append("UPDATE JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_TRAFFIC_DET.TASK_START_DATE = ")
                            If StrDate_ReplaceWith_Date = "NULL" Then
                                .Append(StrDate_ReplaceWith_Date)
                            Else
                                .Append("@REPLACE_WITH")
                            End If
                        Case "due_date"
                            .Append("UPDATE JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_TRAFFIC_DET.JOB_REVISED_DATE = ")
                            If StrDate_ReplaceWith_Date = "NULL" Then
                                .Append(StrDate_ReplaceWith_Date)
                            Else
                                .Append("@REPLACE_WITH")
                            End If
                        Case "completed_date"
                            .Append("UPDATE JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_TRAFFIC_DET.JOB_COMPLETED_DATE = ")
                            If StrDate_ReplaceWith_Date = "NULL" Then
                                .Append(StrDate_ReplaceWith_Date)
                            Else
                                .Append("@REPLACE_WITH")
                            End If
                        Case "time_due"
                            .Append("UPDATE JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_TRAFFIC_DET.REVISED_DUE_TIME = ")
                            If StrText_ReplaceWith = "NULL" Then
                                .Append(StrText_ReplaceWith)
                            Else
                                .Append("@REPLACE_WITH")
                            End If
                        Case "employee_assignment"
                            If StrText_ReplaceWith = "NULL" Then
                                .Append("DELETE FROM JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) ")
                            Else
                                .Append("UPDATE JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) SET JOB_TRAFFIC_DET_EMPS.EMP_CODE = ")
                                .Append("@REPLACE_WITH")
                            End If
                        Case "client_contact_assignment"
                            If StrText_ReplaceWith = "NULL" Then
                                .Append("DELETE FROM JOB_TRAFFIC_DET_CNTS WITH(ROWLOCK) ")
                            Else
                                .Append("UPDATE JOB_TRAFFIC_DET_CNTS WITH(ROWLOCK) SET JOB_TRAFFIC_DET_CNTS.CDP_CONTACT_ID = ")
                                .Append("@REPLACE_WITH")
                            End If
                        Case "task_status"
                            .Append("UPDATE JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_TRAFFIC_DET.TASK_STATUS = ")
                            .Append("@REPLACE_WITH")
                        Case "manager"
                            .Append("UPDATE JOB_TRAFFIC WITH(ROWLOCK) SET JOB_TRAFFIC.")
                            .Append(StrManagerColumn)
                            .Append(" = ")
                            If StrText_ReplaceWith = "NULL" Then
                                .Append(StrText_ReplaceWith)
                            Else
                                .Append("@REPLACE_WITH")
                            End If
                    End Select
                End With

                'Build "search for" part
                Dim SbSQLAnd As New System.Text.StringBuilder
                With SbSQLAnd
                    .Append(" AND (")
                    Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                        Case "start_date"
                            .Append("JOB_TRAFFIC_DET.TASK_START_DATE ")
                            If StrDate_SearchFor_StartDate = "NULL" Then
                                .Append("IS NULL")
                            Else
                                If StrDate_SearchFor_EndDate = "" Then
                                    .Append(" = ")
                                    .Append("@SEARCH_FOR")
                                Else
                                    .Append("BETWEEN @SEARCH_FOR AND @SEARCH_FOR2")
                                End If
                            End If
                        Case "due_date"
                            .Append("JOB_TRAFFIC_DET.JOB_REVISED_DATE ")
                            If StrDate_SearchFor_StartDate = "NULL" Then
                                .Append("IS NULL")
                            Else
                                If StrDate_SearchFor_EndDate = "" Then
                                    .Append(" = ")
                                    .Append("@SEARCH_FOR")
                                Else
                                    .Append("BETWEEN @SEARCH_FOR AND @SEARCH_FOR2")
                                End If
                            End If
                        Case "completed_date"
                            .Append("JOB_TRAFFIC_DET.JOB_COMPLETED_DATE ")
                            If StrDate_SearchFor_StartDate = "NULL" Then
                                .Append("IS NULL")
                            Else
                                If StrDate_SearchFor_EndDate = "" Then
                                    .Append(" = ")
                                    .Append("@SEARCH_FOR")
                                Else
                                    .Append("BETWEEN @SEARCH_FOR AND @SEARCH_FOR2")
                                End If
                            End If
                        Case "time_due"
                            .Append("JOB_TRAFFIC_DET.DUE_TIME ")
                            If StrText_SearchFor = "NULL" Then
                                .Append("IS NULL")
                            Else
                                .Append(" = ")
                                .Append("@SEARCH_FOR")
                            End If
                            .Append(" OR JOB_TRAFFIC_DET.REVISED_DUE_TIME ")
                            If StrText_SearchFor = "NULL" Then
                                .Append("IS NULL")
                            Else
                                .Append(" = ")
                                .Append("@SEARCH_FOR")
                            End If
                        Case "employee_assignment"
                            .Append("JOB_TRAFFIC_DET_EMPS.EMP_CODE = ")
                            .Append("@SEARCH_FOR")
                        Case "client_contact_assignment"
                            .Append("JOB_TRAFFIC_DET_CNTS.CDP_CONTACT_ID = ")
                            .Append("@SEARCH_FOR")
                        Case "task_status"
                            .Append("JOB_TRAFFIC_DET.TASK_STATUS = ")
                            .Append("@SEARCH_FOR")
                        Case "manager"
                            .Append("JOB_TRAFFIC.")
                            .Append(StrManagerColumn)
                            .Append(" ")
                            If StrText_SearchFor = "NULL" Then
                                .Append("IS NULL")
                            Else
                                .Append(" = ")
                                .Append("@SEARCH_FOR")
                            End If
                    End Select
                    .Append(")")
                End With

                'Dim SbSQLAndTask As New System.Text.StringBuilder
                'If Me.DropFindAndReplaceType.SelectedValue.ToString = "employee_assignment" Then
                '    If StrTask <> "" Then
                '        With SbSQLAndTask
                '            .Append(" AND FNC_CODE = @TaskCode ")
                '        End With
                '    End If
                'End If

                Dim StrUpdateSQL As String = ""
                If StrText_ReplaceWith <> "NULL" And Me.DropFindAndReplaceType.SelectedValue.ToString = "employee_assignment" Then
                    StrUpdateSQL = SbSQL.ToString() & SbJCList.ToString() & SbSQLAnd.ToString() & SbJCListNOT.ToString & "; SELECT @@ROWCOUNT;"
                Else
                    StrUpdateSQL = SbSQL.ToString() & SbJCList.ToString() & SbSQLAnd.ToString() & "; SELECT @@ROWCOUNT;"
                End If


                Me.LblSQL.Text = StrUpdateSQL

                Dim MyCmd As New SqlCommand(StrUpdateSQL, MyConn, MyTrans)
                'Add parameters:
                With MyCmd.Parameters
                    'first half
                    Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                        Case "start_date", "completed_date", "due_date"
                            If StrDate_ReplaceWith_Date <> "NULL" Then
                                Dim P As New SqlParameter("@REPLACE_WITH", SqlDbType.SmallDateTime)
                                P.Value = cGlobals.wvCDate(StrDate_ReplaceWith_Date)
                                .Add(P)
                            End If

                        Case "time_due"
                            If StrText_ReplaceWith <> "NULL" Then
                                '@REPLACE_WITH
                                '.Add(New SqlParameter("@REPLACE_WITH", StrText_ReplaceWith))
                                Dim P As New SqlParameter("@REPLACE_WITH", SqlDbType.VarChar, 10)
                                P.Value = StrText_ReplaceWith
                                .Add(P)
                            End If
                        Case "employee_assignment", "manager"
                            If StrText_ReplaceWith <> "NULL" Then
                                Dim P As New SqlParameter("@REPLACE_WITH", SqlDbType.VarChar, 6)
                                P.Value = StrText_ReplaceWith
                                .Add(P)
                            End If
                        Case "client_contact_assignment"
                            If StrText_ReplaceWith <> "NULL" Then
                                Dim P As New SqlParameter("@REPLACE_WITH", SqlDbType.Int)
                                P.Value = CType(StrText_ReplaceWith, Integer)
                                .Add(P)
                            End If
                        Case "task_status"
                            Dim P As New SqlParameter("@REPLACE_WITH", SqlDbType.VarChar, 1)
                            P.Value = StrText_ReplaceWith
                            .Add(P)
                    End Select

                    'second half
                    Select Case Me.DropFindAndReplaceType.SelectedValue.ToString()
                        Case "start_date", "completed_date", "due_date"
                            If StrDate_SearchFor_StartDate <> "NULL" Then
                                Dim P As New SqlParameter("@SEARCH_FOR", SqlDbType.SmallDateTime)
                                P.Value = cGlobals.wvCDate(StrDate_SearchFor_StartDate)
                                .Add(P)
                                If StrDate_SearchFor_EndDate.Trim() <> "" Then
                                    Dim P2 As New SqlParameter("@SEARCH_FOR2", SqlDbType.SmallDateTime)
                                    P2.Value = cGlobals.wvCDate(StrDate_SearchFor_EndDate)
                                    .Add(P2)
                                End If
                            End If
                        Case "time_due"
                            If StrText_SearchFor <> "NULL" Then
                                Dim P As New SqlParameter("@SEARCH_FOR", SqlDbType.VarChar, 10)
                                P.Value = StrText_SearchFor
                                .Add(P)
                            End If
                        Case "employee_assignment"
                            If StrText_SearchFor <> "NULL" Then ' it should never be null for employee or contacts here...
                                Dim P As New SqlParameter("@SEARCH_FOR", SqlDbType.VarChar, 6)
                                P.Value = StrText_SearchFor
                                .Add(P)
                            End If
                            If StrTask <> "" Then
                                Dim T As New SqlParameter("@TaskCode", SqlDbType.VarChar, 6)
                                T.Value = StrTask
                                .Add(T)
                            End If
                        Case "client_contact_assignment"
                            If StrText_SearchFor <> "NULL" Then ' it should never be null for employee or contacts here...
                                Dim P As New SqlParameter("@SEARCH_FOR", SqlDbType.Int)
                                P.Value = CType(StrText_SearchFor, Integer)
                                .Add(P)
                            End If
                        Case "task_status"
                            Dim P As New SqlParameter("@SEARCH_FOR", SqlDbType.VarChar, 1)
                            P.Value = StrText_SearchFor
                            .Add(P)
                        Case "manager"
                            If StrText_SearchFor <> "NULL" Then
                                Dim P As New SqlParameter("@SEARCH_FOR", SqlDbType.VarChar, 6)
                                P.Value = StrText_SearchFor
                                .Add(P)
                            End If
                    End Select
                End With
                Dim RecCount As Integer = 0
                Try
                    'MyCmd.ExecuteNonQuery()
                    If Me.DropFindAndReplaceType.SelectedValue.ToString() = "manager" Then
                        If StrManagerColumn <> "" Then
                            li = CType(MyCmd.ExecuteScalar, Integer)
                        End If
                    Else
                        li = CType(MyCmd.ExecuteScalar, Integer)
                    End If
                    MyTrans.Commit()
                    RecCount = li
                Catch ex As Exception
                    MyTrans.Rollback()
                    Me.LblMSG.Text = "Error with find and replace SQL execution:<br /><br />" & ex.Message.ToString() & "<br /><br />" & StrUpdateSQL
                    li = -1
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
            'Show new message:
            With SbLog
                .Append(Me.DropFindAndReplaceType.SelectedItem.Text)
                .Append(" changed from ")
                .Append(StrLogFrom1)
                If StrLogFrom2.Trim() <> "" Then
                    .Append(" through ")
                    .Append(StrLogFrom2)
                End If
                .Append(" to ")
                .Append(StrLogTo)
                If li >= 0 Then
                    .Append(" for ")
                    .Append(li.ToString())
                    If Me.DropFindAndReplaceType.SelectedValue.ToString() = "manager" Then
                        .Append(" schedule(s).")
                    Else
                        If StrTask <> "" Then
                            .Append(" task(" & StrTask & ")")
                        Else
                            .Append(" task(s).")
                        End If
                    End If
                ElseIf li = -1 Then
                    .Append("Error")
                End If
                Me.TxtLog.Text &= SbLog.ToString() & Environment.NewLine
            End With
        Catch ex As Exception
            Me.LblMSG.Text = "Error with find and replace subroutine:<br /><br />" & ex.Message.ToString()
        End Try
    End Sub

End Class