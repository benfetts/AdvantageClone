Imports Webvantage.cGlobals.Globals
Imports System.Data.SqlClient

Partial Public Class TaskList_Settings
    Inherits Webvantage.BaseChildPage

    Dim intClient As Int32
    Dim intDiv As Int32

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_TaskListRTP)
        'header.SubMenu = SubMenu.Production
        Dim oReports As New cReports(Session("ConnString"))
        If Me.IsPostBack = True Then

        Else
            If Not Request.QueryString("nodata") Is Nothing Then
                Me.ShowMessage("No Data Found For Selected Inputs")
            End If
            Me.RadDatePickerStartDate.SelectedDate = Date.Today
            Me.RadDatePickerEndDate.SelectedDate = Date.Today
            LoadClientList()
            LoadOfficeList()
            LoadManagers()
            LoadAEListbox()
            Dim str As String = oReports.GetManagerLabel(Session("UserCode"))
            If str <> "" Or Not str Is Nothing Then
                Me.lblManager.Text = str & ":"
            End If
            If Me.rdlEmpRole.Items(0).Selected = True Then
                LoadEmplyees()
            Else
                LoadRoles()
            End If
            Me.chkClient.Checked = True
            Me.chkProduct.Checked = True
            Me.chkDivision.Checked = True
            Me.chkJob.Checked = True
            Me.chkClient.Enabled = False
            Me.chkProduct.Enabled = False
            Me.chkDivision.Enabled = False
            Me.chkJob.Enabled = False
            Me.chkEmp.Enabled = True
            'If Not Request.Cookies("MyTaskList") Is Nothing Then
            LoadSettings()
            'End If


        End If
        'butView.Attributes.Add("onclick", "document.getElementById(""_ctl0_ContentPlaceHolderMain_lbl_msg"").innerText='';")
    End Sub

    Private Sub LoadAEListbox()
        Dim ocPV As cProjectViewpoint = New cProjectViewpoint(CStr(Session("ConnString")))

        Me.lstAEs.ClearSelection()
        With Me.lstAEs
            .DataSource = ocPV.GetAEList("", "", "", CStr(Session("UserCode")))
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
            .Enabled = False
        End With
    End Sub

    Private Sub LoadOfficeList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.lbOffices.DataSource = oDropDowns.GetOfficesEmp(Session("UserCode"))
        Me.lbOffices.DataTextField = "Description"
        Me.lbOffices.DataValueField = "Code"
        Me.lbOffices.DataBind()
        Me.lbOffices.SelectionMode = ListSelectionMode.Multiple
        Me.lbOffices.Enabled = False
        'Me.lbOffices.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Offices", "%"))

    End Sub
    Private Sub LoadClientList()
        'Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        'Populate Client List Box
        Me.lstClients.DataSource = odd.GetClientList(CStr(Session("UserCode")))
        Me.lstClients.DataTextField = "description"
        Me.lstClients.DataValueField = "code"
        Me.lstClients.DataBind()
        Me.lstClients.SelectionMode = ListSelectionMode.Multiple
        Me.lstClients.Enabled = False

    End Sub
    Private Sub LoadEmplyees()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.lstEmployees.Items.Clear()
        Me.lstEmployees.DataSource = odd.GetEmployees(CStr(Session("UserCode")))
        Me.lstEmployees.DataTextField = "Description"
        Me.lstEmployees.DataValueField = "code"
        Me.lstEmployees.DataBind()
        Me.lstEmployees.SelectionMode = ListSelectionMode.Multiple
        If rdlEmployees.Items(0).Selected Then
            Me.lstEmployees.Enabled = False
        End If

    End Sub
    Private Sub LoadRoles()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.lstEmployees.Items.Clear()
        Me.lstEmployees.DataSource = odd.GetRoles()
        Me.lstEmployees.DataTextField = "Description"
        Me.lstEmployees.DataValueField = "code"
        Me.lstEmployees.DataBind()
        Me.lstEmployees.SelectionMode = ListSelectionMode.Multiple
        If rdlEmployees.Items(0).Selected Then
            Me.lstEmployees.Enabled = False
        End If
    End Sub
    Private Sub LoadManagers()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.ddManager
            .DataSource = odd.GetManagers(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

    End Sub
    Private Sub SaveSettings()
        'Report Options
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.TASK_LIST_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                    .setAppVar("StartDate", Me.RadDatePickerStartDate.SelectedDate)
                Else
                    .setAppVar("StartDate", "")
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                    .setAppVar("EndDate", Me.RadDatePickerEndDate.SelectedDate)
                Else
                    .setAppVar("EndDate", "")
                End If

                .setAppVar("DateRange", Me.rbDateRange.Checked)
                .setAppVar("PastDue", Me.rbPastDue.Checked)
                .setAppVar("Sortcdp", Me.rbCDP.Checked)
                .setAppVar("SortDate", Me.rbDueDate.Checked)
                .setAppVar("SortTask", Me.rbTask.Checked)
                .setAppVar(Me.chkSubHeadings.ID, Me.chkSubHeadings.Checked)
                .setAppVar("SortClient", Me.rbClient.Checked)
                .setAppVar("SortJobComp", Me.rbJobComp.Checked)
                .setAppVar("SortJobCompSummary", Me.rbJobCompSummary.Checked)
                .setAppVar(Me.chkClient.ID, Me.chkClient.Checked)
                .setAppVar(Me.chkDivision.ID, Me.chkDivision.Checked)
                .setAppVar(Me.chkProduct.ID, Me.chkProduct.Checked)
                .setAppVar(Me.chkJob.ID, Me.chkJob.Checked)
                .setAppVar(Me.chkComponent.ID, Me.chkComponent.Checked)
                .setAppVar(Me.chkEmp.ID, Me.chkEmp.Checked)
                .setAppVar("Completed", Me.chkCompleted.Checked)
                .setAppVar(Me.chkTask.ID, Me.chkTask.Checked)
                .setAppVar(Me.chkHrsAllowed.ID, Me.chkHrsAllowed.Checked)
                .setAppVar(Me.chkRevDueDate.ID, Me.chkRevDueDate.Checked)
                .setAppVar(Me.chkTimeDue.ID, Me.chkTimeDue.Checked)
                .setAppVar(Me.chkComments.ID, Me.chkComments.Checked)
                .setAppVar(Me.chkClient.ID & "E", Me.chkClient.Enabled)
                .setAppVar(Me.chkDivision.ID & "E", Me.chkDivision.Enabled)
                .setAppVar(Me.chkProduct.ID & "E", Me.chkProduct.Enabled)
                .setAppVar(Me.chkJobTrafficComments.ID, Me.chkJobTrafficComments.Checked)
                .setAppVar("OnlyUnassigned", Me.CheckBoxOnlyUnassigned.Checked)
                .setAppVar("ExcludeUnassigned", Me.CheckBoxExcludeUnassigned.Checked)
                .SaveAllAppVars()
            End With
        Catch ex As Exception

        End Try
        'Response.Cookies("MyTaskList").Expires = Now.AddYears(1)
        'Response.Cookies("MyTaskList")("DateRange") = Me.rbDateRange.Checked
        'If Me.RadDatePickerStartDate.SelectedDate <> "" Then
        '    Response.Cookies("MyTaskList")("StartDate") = wvCDate(Me.RadDatePickerStartDate.SelectedDate)
        'Else
        '    Response.Cookies("MyTaskList")("StartDate") = ""
        'End If
        'If Me.RadDatePickerEndDate.SelectedDate <> "" Then
        '    Response.Cookies("MyTaskList")("EndDate") = wvCDate(Me.RadDatePickerEndDate.SelectedDate)
        'Else
        '    Response.Cookies("MyTaskList")("EndDate") = ""
        'End If

        'Response.Cookies("MyTaskList")("PastDue") = Me.rbPastDue.Checked
        ''Sort Options
        'Response.Cookies("MyTaskList")("Sortcdp") = Me.rbCDP.Checked
        'Response.Cookies("MyTaskList")("SortDate") = Me.rbDueDate.Checked
        'Response.Cookies("MyTaskList")("SortTask") = Me.rbTask.Checked
        'Response.Cookies("MyTaskList")(Me.chkSubHeadings.ID) = Me.chkSubHeadings.Checked
        'Response.Cookies("MyTaskList")("SortClient") = Me.rbClient.Checked
        'Response.Cookies("MyTaskList")("SortJobComp") = Me.rbJobComp.Checked
        'Response.Cookies("MyTaskList")("SortJobCompSummary") = Me.rbJobCompSummary.Checked

        'Show Fields
        'Response.Cookies("MyTaskList")(Me.chkClient.ID) = Me.chkClient.Checked
        'Response.Cookies("MyTaskList")(Me.chkDivision.ID) = Me.chkDivision.Checked
        'Response.Cookies("MyTaskList")(Me.chkProduct.ID) = Me.chkProduct.Checked
        'Response.Cookies("MyTaskList")(Me.chkJob.ID) = Me.chkJob.Checked
        'Response.Cookies("MyTaskList")(Me.chkComponent.ID) = Me.chkComponent.Checked
        'Response.Cookies("MyTaskList")(Me.chkEmp.ID) = Me.chkEmp.Checked
        'Response.Cookies("MyTaskList")("Completed") = Me.chkCompleted.Checked
        'Response.Cookies("MyTaskList")(Me.chkTask.ID) = Me.chkTask.Checked
        'Response.Cookies("MyTaskList")(Me.chkHrsAllowed.ID) = Me.chkHrsAllowed.Checked
        'Response.Cookies("TaskList")(Me.chkDueDate.ID) = Me.chkDueDate.Checked
        'Response.Cookies("MyTaskList")(Me.chkRevDueDate.ID) = Me.chkRevDueDate.Checked
        'Response.Cookies("MyTaskList")(Me.chkTimeDue.ID) = Me.chkTimeDue.Checked
        'Response.Cookies("MyTaskList")(Me.chkComments.ID) = Me.chkComments.Checked
        'Response.Cookies("MyTaskList")(Me.chkClient.ID & "E") = Me.chkClient.Enabled
        'Response.Cookies("MyTaskList")(Me.chkDivision.ID & "E") = Me.chkDivision.Enabled
        'Response.Cookies("MyTaskList")(Me.chkProduct.ID & "E") = Me.chkProduct.Enabled
        'Response.Cookies("MyTaskList")(Me.chkJobTrafficComments.ID) = Me.chkJobTrafficComments.Checked
        'Response.Cookies("MyTaskList")(Me.chkCDate.ID & "E") = Me.chkCDate.Checked
        'Response.Cookies("TaskList")(Me.chkDueDate.ID & "E") = Me.chkDueDate.Enabled

    End Sub

    Private Sub LoadSettings()
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.TASK_LIST_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            Dim s As String = ""
            s = oAppVars.getAppVar("StartDate")
            If s <> "" Then
                Me.RadDatePickerStartDate.SelectedDate = CType(s, Date)
            End If
            s = oAppVars.getAppVar("EndDate")
            If s <> "" Then
                Me.RadDatePickerEndDate.SelectedDate = CType(s, Date)
            End If
            s = oAppVars.getAppVar("DateRange")
            If s <> "" Then
                Me.rbDateRange.Checked = s
            End If
            s = oAppVars.getAppVar("Completed")
            If s <> "" Then
                Me.chkCompleted.Checked = s
            End If
            s = oAppVars.getAppVar("PastDue")
            If s <> "" Then
                Me.rbPastDue.Checked = s
            End If
            s = oAppVars.getAppVar("Sortcdp")
            If s <> "" Then
                Me.rbCDP.Checked = s
            End If
            s = oAppVars.getAppVar("SortDate")
            If s <> "" Then
                Me.rbDueDate.Checked = s
            End If
            s = oAppVars.getAppVar("SortTask")
            If s <> "" Then
                Me.rbTask.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkSubHeadings.ID)
            If s <> "" Then
                Me.chkSubHeadings.Checked = s
            End If
            s = oAppVars.getAppVar("SortClient")
            If s <> "" Then
                Me.rbClient.Checked = s
            End If
            s = oAppVars.getAppVar("SortJobComp")
            If s <> "" Then
                Me.rbJobComp.Checked = s
            End If
            s = oAppVars.getAppVar("SortJobCompSummary")
            If s <> "" Then
                Me.rbJobCompSummary.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkClient.ID)
            If s <> "" Then
                Me.chkClient.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkDivision.ID)
            If s <> "" Then
                Me.chkDivision.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkProduct.ID)
            If s <> "" Then
                Me.chkProduct.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkJob.ID)
            If s <> "" Then
                Me.chkJob.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkComponent.ID)
            If s <> "" Then
                Me.chkComponent.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkTask.ID)
            If s <> "" Then
                Me.chkTask.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkEmp.ID)
            If s <> "" Then
                Me.chkEmp.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkHrsAllowed.ID)
            If s <> "" Then
                Me.chkHrsAllowed.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkRevDueDate.ID)
            If s <> "" Then
                Me.chkRevDueDate.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkTimeDue.ID)
            If s <> "" Then
                Me.chkTimeDue.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkComments.ID)
            If s <> "" Then
                Me.chkComments.Checked = s
            End If
            s = oAppVars.getAppVar(Me.chkClient.ID & "E")
            If s <> "" Then
                Me.chkClient.Enabled = s
            End If
            s = oAppVars.getAppVar(Me.chkDivision.ID & "E")
            If s <> "" Then
                Me.chkDivision.Enabled = s
            End If
            s = oAppVars.getAppVar(Me.chkProduct.ID & "E")
            If s <> "" Then
                Me.chkProduct.Enabled = s
            End If
            s = oAppVars.getAppVar(Me.chkJobTrafficComments.ID)
            If s <> "" Then
                Me.chkJobTrafficComments.Checked = s
            End If
            s = oAppVars.getAppVar("OnlyUnassigned")
            If s <> "" Then
                Me.CheckBoxOnlyUnassigned.Checked = s
            End If
            s = oAppVars.getAppVar("ExcludeUnassigned")
            If s <> "" Then
                Me.CheckBoxExcludeUnassigned.Checked = s
            End If
            'Me.rbDateRange.Checked = Request.Cookies("MyTaskList")("DateRange")
            CheckChanged()
        Catch ex As Exception
        End Try
        'Try
        '    Me.chkCompleted.Checked = Request.Cookies("MyTaskList")("Completed")
        'Catch ex As Exception
        'End Try
        'Try
        '    If Request.Cookies("MyTaskList")("StartDate") <> "" Then
        '        Me.RadDatePickerStartDate.SelectedDate = Request.Cookies("MyTaskList")("StartDate")
        '    End If
        'Catch ex As Exception
        'End Try
        'Try
        '    If Request.Cookies("MyTaskList")("EndDate") <> "" Then
        '        Me.RadDatePickerEndDate.SelectedDate = Request.Cookies("MyTaskList")("EndDate")
        '    End If
        'Catch ex As Exception
        'End Try
        'Try
        '    Me.rbPastDue.Checked = Request.Cookies("MyTaskList")("PastDue")
        'Catch ex As Exception
        'End Try
        ''Sort Options

        'Try
        '    Me.rbCDP.Checked = Request.Cookies("MyTaskList")("Sortcdp")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.rbDueDate.Checked = Request.Cookies("MyTaskList")("SortDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.rbTask.Checked = Request.Cookies("MyTaskList")("SortTask")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkSubHeadings.Checked = Request.Cookies("MyTaskList")(Me.chkSubHeadings.ID)
        'Catch ex As Exception
        'End Try


        'Response.Cookies("MyTaskList")("SortClient") = Me.rbClient.Checked
        'Try
        '    Me.rbClient.Checked = Request.Cookies("MyTaskList")("SortClient")
        'Catch ex As Exception
        'End Try

        ''Response.Cookies("MyTaskList")("SortJobComp") = Me.rbJobComp.Checked
        'Try
        '    Me.rbJobComp.Checked = Request.Cookies("MyTaskList")("SortJobComp")
        'Catch ex As Exception
        'End Try

        ''Response.Cookies("MyTaskList")("SortJobCompSummary") = Me.rbJobCompSummary.Checked
        'Try
        '    Me.rbJobCompSummary.Checked = Request.Cookies("MyTaskList")("SortJobCompSummary")
        'Catch ex As Exception
        'End Try




        'Show Fields

        'Try
        '    Me.chkClient.Checked = Request.Cookies("MyTaskList")(Me.chkClient.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkDivision.Checked = Request.Cookies("MyTaskList")(Me.chkDivision.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkProduct.Checked = Request.Cookies("MyTaskList")(Me.chkProduct.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkJob.Checked = Request.Cookies("MyTaskList")(Me.chkJob.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkComponent.Checked = Request.Cookies("MyTaskList")(Me.chkComponent.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkTask.Checked = Request.Cookies("MyTaskList")(Me.chkTask.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkEmp.Checked = Request.Cookies("MyTaskList")(Me.chkEmp.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkHrsAllowed.Checked = Request.Cookies("MyTaskList")(Me.chkHrsAllowed.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkRevDueDate.Checked = Request.Cookies("MyTaskList")(Me.chkRevDueDate.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkTimeDue.Checked = Request.Cookies("MyTaskList")(Me.chkTimeDue.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkComments.Checked = Request.Cookies("MyTaskList")(Me.chkComments.ID)
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkClient.Enabled = Request.Cookies("MyTaskList")(Me.chkClient.ID & "E")
        'Catch ex As Exception
        'End Try


        'Try
        '    Me.chkDivision.Enabled = Request.Cookies("MyTaskList")(Me.chkDivision.ID & "E")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkProduct.Enabled = Request.Cookies("MyTaskList")(Me.chkProduct.ID & "E")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkJobTrafficComments.Checked = Request.Cookies("MyTaskList")(Me.chkJobTrafficComments.ID)
        'Catch ex As Exception
        'End Try


        'Me.chkDueDate.Checked = Request.Cookies("TaskList")(Me.chkDueDate.ID)
        'Me.chkCDate.Checked = Response.Cookies("MyTaskList")(Me.chkCDate.ID & "E")
        'Me.chkDueDate.Enabled = Request.Cookies("TaskList")(Me.chkDueDate.ID & "E")

    End Sub

    Private Sub rbDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDateRange.CheckedChanged
        If Me.rbDateRange.Checked = True Then
            Me.RadDatePickerStartDate.Enabled = True
            Me.RadDatePickerEndDate.Enabled = True
        End If
    End Sub

    Private Sub rbPastDue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPastDue.CheckedChanged
        If Me.rbPastDue.Checked = True Then
            Me.RadDatePickerStartDate.Enabled = False
            Me.RadDatePickerEndDate.Enabled = False
        End If
    End Sub

    Private Sub rbCDP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCDP.CheckedChanged, rbDueDate.CheckedChanged, rbTask.CheckedChanged, chkSubHeadings.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub rbClient_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbClient.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub rbJobComp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbJobComp.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub butView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butView.Click

        Dim strURL As String
        Dim I As Integer
        Dim strReportServer As String = System.Configuration.ConfigurationManager.AppSettings("ReportServerPath")

        Try
            If Me.rbPastDue.Checked = False Then
                'FIX AND RE-ENABLE
                Dim dtStart As DateTime = Convert.ToDateTime("3/31/1974 12:00:00 AM")
                Dim dtEnd As DateTime = Convert.ToDateTime("6/6/2079 11:59:59 PM")

                If MiscFN.ValidDate(Me.RadDatePickerStartDate, True) = False Then
                    Me.ShowMessage("Invalid Start date")
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate, True) = False Then
                    Me.ShowMessage("Invalid End date")
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerStartDate, False) = True And MiscFN.ValidDate(Me.RadDatePickerEndDate, False) = True Then
                    If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                        Me.ShowMessage("Invalid date range")
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Me.ShowMessage("Error validating date: " & ex.Message.ToString())

        End Try

        Try
            If Me.chkSaveSettings.Checked = True Then
                SaveSettings()
            End If

        Catch ex As Exception
            Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
        End Try

        Try
            If Me.rbCDP.Checked = True Then
                strURL = "popReportViewer.aspx?Report=mytasklist"
                strURL = strURL & "&SortOrder=1"
                strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
                strURL &= "&" & Me.chkJobTrafficComments.ID & "=" & GetChecked(Me.chkJobTrafficComments.Checked)
            ElseIf Me.rbDueDate.Checked = True Then
                strURL = "popReportViewer.aspx?Report=mytasklistduedate"
                strURL = strURL & "&SortOrder=2"
                strURL &= "&" & Me.chkClient.ID & "=" & GetChecked(Me.chkClient.Checked)
                strURL &= "&" & Me.chkDivision.ID & "=" & GetChecked(Me.chkDivision.Checked)
                strURL &= "&" & Me.chkProduct.ID & "=" & GetChecked(Me.chkProduct.Checked)
                strURL &= "&" & Me.chkJob.ID & "=" & GetChecked(Me.chkJob.Checked)
            ElseIf Me.rbClient.Checked = True Then
                strURL = "popReportViewer.aspx?Report=mytasklist"
                strURL = strURL & "&SortOrder=4"
                strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
                strURL &= "&" & Me.chkJobTrafficComments.ID & "=" & GetChecked(Me.chkJobTrafficComments.Checked)
            ElseIf Me.rbJobComp.Checked = True Then
                strURL = "popReportViewer.aspx?Report=mytasklist"
                strURL = strURL & "&SortOrder=5"
                strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
                strURL &= "&" & Me.chkJobTrafficComments.ID & "=" & GetChecked(Me.chkJobTrafficComments.Checked)
            ElseIf Me.rbJobCompSummary.Checked = True Then
                strURL = "popReportViewer.aspx?Report=mytasklistsummary"
                strURL = strURL & "&SortOrder=6"
                strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
                strURL &= "&" & Me.chkJobTrafficComments.ID & "=" & GetChecked(Me.chkJobTrafficComments.Checked)
            Else
                strURL = "popReportViewer.aspx?Report=mytasklisttask"
                strURL = strURL & "&SortOrder=3"
                strURL &= "&" & Me.chkClient.ID & "=" & GetChecked(Me.chkClient.Checked)
                strURL &= "&" & Me.chkDivision.ID & "=" & GetChecked(Me.chkDivision.Checked)
                strURL &= "&" & Me.chkProduct.ID & "=" & GetChecked(Me.chkProduct.Checked)
                strURL &= "&" & Me.chkJob.ID & "=" & GetChecked(Me.chkJob.Checked)
                strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
            End If


            strURL &= "&UserID=" & Session("UserCode")
            'strURL &= "&EmpCode=" & Session("EmpCode")
            'strURL &= "&EmpName=" & Session("EmployeeName")

            If Me.chkCompleted.Checked = True Then
                strURL &= "&Completed=" & Me.RadDatePickerStartDate.SelectedDate
                strURL &= "&chkCompleted=False"
            Else
                strURL &= "&Completed=" & Now.AddYears(1).Date
                strURL &= "&chkCompleted=True"
            End If

            strURL &= "&ClientCodes="

            If rdlClients.Items(1).Selected = True Then
                For I = 0 To Me.lstClients.Items.Count - 1
                    If Me.lstClients.Items(I).Selected = True Then
                        strURL &= Me.lstClients.Items(I).Value & ","
                    End If
                Next I
                strURL = strURL.Substring(0, strURL.Length - 1)
            Else
                strURL &= "%"
            End If

            strURL &= "&OfficeCodes="
            If Me.rblOffices.Items(1).Selected = True Then
                For I = 0 To Me.lbOffices.Items.Count - 1
                    If Me.lbOffices.Items(I).Selected = True Then
                        strURL &= Me.lbOffices.Items(I).Value & ","
                    End If
                Next I
                strURL = strURL.Substring(0, strURL.Length - 1)
            Else
                strURL &= "%"
            End If
            If rdlEmpRole.Items(0).Selected Then
                strURL &= "&EmpCodes="
            Else
                strURL &= "&RoleCodes="
            End If

            If rdlEmployees.Items(1).Selected Then
                For I = 0 To Me.lstEmployees.Items.Count - 1
                    If Me.lstEmployees.Items(I).Selected = True Then
                        strURL &= Me.lstEmployees.Items(I).Value & ","
                    End If
                Next I
                strURL = strURL.Substring(0, strURL.Length - 1)
            Else
                strURL &= "%"
            End If

            strURL &= "&AECodes="
            If Me.rdlAE.Items(1).Selected = True Then
                For I = 0 To Me.lstAEs.Items.Count - 1
                    If Me.lstAEs.Items(I).Selected = True Then
                        strURL &= Me.lstAEs.Items(I).Value & ","
                    End If
                Next I
                strURL = strURL.Substring(0, strURL.Length - 1)
            Else
                strURL &= "%"
            End If

            If Me.rbDateRange.Checked = True Then
                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                    strURL &= "&StartDate=" & wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString
                Else
                    strURL &= "&StartDate=" & "01/01/1950"
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                    strURL &= "&EndDate=" & wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString
                Else
                    strURL &= "&EndDate=" & "01/01/2050"
                End If
            Else
                strURL &= "&StartDate=" & Now.AddYears(-5).ToShortDateString
                strURL &= "&EndDate=" & Now.ToShortDateString
            End If
            strURL &= "&" & Me.chkComponent.ID & "=" & GetChecked(Me.chkComponent.Checked)
            'strURL &= "&" & Me.chkTask.ID & "=" & CInt(Me.chkTask.Checked)
            strURL &= "&" & Me.chkHrsAllowed.ID & "=" & GetChecked(Me.chkHrsAllowed.Checked)
            strURL &= "&" & Me.CheckBoxPhase.ID & "=" & GetChecked(Me.CheckBoxPhase.Checked)
            strURL &= "&" & Me.chkComments.ID & "=" & GetChecked(Me.chkComments.Checked)
            strURL &= "&" & Me.chkEmp.ID & "=" & GetChecked(Me.chkEmp.Checked)
            strURL &= "&" & Me.chkTimeDue.ID & "=" & GetChecked(Me.chkTimeDue.Checked)
            strURL &= "&ddManager=" & Me.ddManager.SelectedValue
            'strURL &= "&" & Me.chkCDate.ID & "=" & GetChecked(Me.chkCDate.Checked)
            Dim ddl As Telerik.Web.UI.RadComboBox
            ddl = reporttype.FindControl("RadComboBoxReportType")
            strURL &= "&Type=" & ddl.SelectedValue
            strURL &= "&Only=" & Me.CheckBoxOnlyUnassigned.Checked
            strURL &= "&Exclude=" & Me.CheckBoxExcludeUnassigned.Checked
            Response.Redirect(strURL)



        Catch ex As Exception
            Me.ShowMessage("Error setting strURL : " & ex.Message.ToString())
        End Try



        'make open new browser
        'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'strBuilder.Append("<script language='javascript'>")
        'strBuilder.Append("window.open('" & strURL & "', '', 'scrollbars=yes,resizable=yes,menubar=no,maximazable=yes')")
        'strBuilder.Append("</")
        'strBuilder.Append("script>")
        'RegisterStartupScript("newpage", strBuilder.ToString())

    End Sub

    Private Sub CheckChanged()
        If Me.rbCDP.Checked = True Or Me.rbClient.Checked = True Or Me.rbJobComp.Checked = True Then
            Me.chkClient.Checked = True
            Me.chkProduct.Checked = True
            Me.chkDivision.Checked = True
            Me.chkJob.Checked = True
            Me.chkClient.Enabled = False
            Me.chkProduct.Enabled = False
            Me.chkDivision.Enabled = False
            Me.chkJob.Enabled = False
            Me.chkJobTrafficComments.Enabled = True
            Me.chkEmp.Enabled = True
            Me.chkHrsAllowed.Enabled = True
            Me.chkTimeDue.Enabled = True
            Me.chkComments.Enabled = True
        ElseIf Me.rbJobCompSummary.Checked = True Then
            Me.chkClient.Checked = True
            Me.chkProduct.Checked = True
            Me.chkDivision.Checked = True
            Me.chkJob.Checked = True
            Me.chkComponent.Checked = True
            Me.chkClient.Enabled = False
            Me.chkProduct.Enabled = False
            Me.chkDivision.Enabled = False
            Me.chkJob.Enabled = False
            Me.chkComponent.Enabled = False
            Me.chkJobTrafficComments.Enabled = False
            Me.chkEmp.Enabled = False
            Me.chkHrsAllowed.Enabled = False
            Me.chkTimeDue.Enabled = False
            Me.chkComments.Enabled = False
        Else
            Me.chkClient.Checked = True
            Me.chkProduct.Checked = True
            Me.chkDivision.Checked = True
            Me.chkJob.Checked = True
            Me.chkComponent.Checked = True
            Me.chkClient.Enabled = False
            Me.chkProduct.Enabled = False
            Me.chkDivision.Enabled = False
            Me.chkJob.Enabled = False
            Me.chkComponent.Enabled = False
            Me.chkJobTrafficComments.Enabled = False
            Me.chkEmp.Enabled = True
            Me.chkHrsAllowed.Enabled = True
            Me.chkTimeDue.Enabled = True
            Me.chkComments.Enabled = True
        End If
        If Me.rbDueDate.Checked = True Then 'And Me.chkSubHeadings.Checked = True Then
            Me.chkRevDueDate.Checked = True
            Me.chkRevDueDate.Enabled = False
        Else
            Me.chkRevDueDate.Enabled = True
        End If
        If Me.rbJobCompSummary.Checked = True Then
            Me.chkRevDueDate.Enabled = False
        End If
    End Sub

    Public Function GetChecked(ByVal blnChecked As Boolean) As String
        If blnChecked = True Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub rdlEmpRole_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlEmpRole.SelectedIndexChanged
        If rdlEmpRole.Items(0).Selected Then
            rdlEmployees.Items(0).Text = "All Employees"
            rdlEmployees.Items(1).Text = "Choose Employees"
            LoadEmplyees()
        Else
            rdlEmployees.Items(0).Text = "All Roles"
            rdlEmployees.Items(1).Text = "Choose Roles"
            LoadRoles()
        End If
    End Sub
    Private Sub rdlClients_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlClients.SelectedIndexChanged
        Dim i As Integer
        If Me.rdlClients.Items(0).Selected = True Then
            For i = 0 To Me.lstClients.Items.Count - 1
                If Me.lstClients.Items(i).Selected = True Then
                    Me.lstClients.Items(i).Selected = False
                End If
            Next
            lstClients.Enabled = False
        Else
            lstClients.Enabled = True
        End If
    End Sub

    Private Sub rblOffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblOffices.SelectedIndexChanged
        Dim i As Integer
        If Me.rblOffices.Items(0).Selected = True Then
            For i = 0 To Me.lbOffices.Items.Count - 1
                If Me.lbOffices.Items(i).Selected = True Then
                    Me.lbOffices.Items(i).Selected = False
                End If
            Next
            lbOffices.Enabled = False
        Else
            lbOffices.Enabled = True
        End If
    End Sub

    Private Sub rdlEmployees_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlEmployees.SelectedIndexChanged
        Dim i As Integer
        If Me.rdlEmployees.Items(0).Selected = True Then
            For i = 0 To Me.lstEmployees.Items.Count - 1
                If Me.lstEmployees.Items(i).Selected = True Then
                    Me.lstEmployees.Items(i).Selected = False
                End If
            Next
            lstEmployees.Enabled = False
        Else
            lstEmployees.Enabled = True
        End If
    End Sub

    Private Sub rdlAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlAE.SelectedIndexChanged
        Dim i As Integer
        If Me.rdlAE.Items(0).Selected = True Then
            For i = 0 To Me.lstAEs.Items.Count - 1
                If Me.lstAEs.Items(i).Selected = True Then
                    Me.lstAEs.Items(i).Selected = False
                End If
            Next
            lstAEs.Enabled = False
        Else
            lstAEs.Enabled = True
        End If
    End Sub

    Private Sub rbJobCompSummary_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbJobCompSummary.CheckedChanged
        CheckChanged()
    End Sub
End Class
