Imports Webvantage.cGlobals.Globals
Imports System.Drawing

Public Class TrafficScheduleByTask_Settings
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Me.PageTitle.InnerText = System.Configuration.ConfigurationManager.AppSettings("AppTitle")
        'header.SubMenu = SubMenu.Production
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_TrafficByTaskRTP)
        Dim oReports As New cReports(Session("ConnString"))
        If Page.IsPostBack = False Then

            LoadDropDowns()
            LoadTaskDropDowns()
            LoadOfficeList()
            LoadTrafficStatus()
            LoadAEListbox()
            LoadTasks()
            'If Not Request.Cookies("rpttrafficschedulesa") Is Nothing Then
            LoadSettings()
            'End If
            Me.chkExcel.Checked = True

            Dim str As String = oReports.GetManagerLabel(Session("UserCode"))
            If str <> "" Or Not str Is Nothing Then
                Me.lblManager.Text = str & ":"
            End If
            Me.rdlEmployees.Enabled = False
            Me.lstEmployees.Enabled = False
        End If

        If Session("nodataTSBT") = "1" Then
            lblMSG.Text = "No Data Found For Selected Inputs"
            Session("nodataTSBT") = ""
        Else
            lblMSG.Text = ""
        End If

        If Me.IsClientPortal = True Then
            Me.PanelOptions.Visible = False
        End If
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
    Private Sub LoadTrafficStatus()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("Connstring"))
        Me.lbStatus.DataSource = oDropDowns.GetTrafficCodes()
        Me.lbStatus.DataTextField = "Description"
        Me.lbStatus.DataValueField = "Code"
        Me.lbStatus.DataBind()
        Me.lbStatus.SelectionMode = ListSelectionMode.Multiple
        Me.lbStatus.Enabled = False
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
    Private Sub LoadDropDowns()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        'Populate Client List Box
        Me.lstClients.DataSource = odd.GetClientList(CStr(Session("UserCode")))
        Me.lstClients.DataTextField = "description"
        Me.lstClients.DataValueField = "code"
        Me.lstClients.DataBind()
        Me.lstClients.SelectionMode = ListSelectionMode.Multiple
        Me.lstClients.Enabled = False

        With Me.ddManager
            .DataSource = odd.GetManagers(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

        With Me.ddTaskTemplate
            .DataSource = odd.GetTrafficPresets()
            .DataTextField = "CodeAndDescription"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All Tasks]", "AllT"))
            .Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem("[None]", "NoTasks"))
        End With

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
    Private Sub butView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butView.Click
        Dim strURL As String
        Dim I As Integer
        Dim Tasked As Boolean = False

        If Me.chkForJobDueDate.Checked = True Then
            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
                Me.ShowMessage("Invalid Job Due Date Range Start Date")
                Exit Sub
            End If
            If MiscFN.ValidDate(Me.RadDatePickerEndDate) = False Then
                Me.ShowMessage("Invalid Job Due Date Range End Date")
                Exit Sub
            End If
            If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                Me.ShowMessage("Invalid date range")
                Exit Sub
            End If
        End If
        If Me.chkClosedJobs.Checked = True Then
            If MiscFN.ValidDate(Me.RadDatePickerStartDateClosed) = False Then
                Me.ShowMessage("Invalid Closed Jobs Start Date")
                Exit Sub
            End If
            If MiscFN.ValidDate(Me.RadDatePickerEndDateClosed) = False Then
                Me.ShowMessage("Invalid Closed Jobs End Date")
                Exit Sub
            End If
            If MiscFN.ValidDateRange(Me.RadDatePickerStartDateClosed, Me.RadDatePickerEndDateClosed) = False Then
                Me.ShowMessage("Invalid date range")
                Exit Sub
            End If
        End If

        Dim client As String
        Dim office As String
        Dim ae As String
        Dim status As String
        Dim role As String
        Dim TaskDesc(31) As String

        strURL = "TrafficScheduleByTask_Render.aspx"
        strURL &= "?clients="

        If Me.IsClientPortal = True Then
            strURL &= Session("CL_CODE")
        Else
            If rdlClients.Items(1).Selected = True Then
                For I = 0 To Me.lstClients.Items.Count - 1
                    If Me.lstClients.Items(I).Selected = True Then
                        strURL &= Me.lstClients.Items(I).Value & ","
                        client &= Me.lstClients.Items(I).Value & ","
                    End If
                Next I
                strURL = strURL.Substring(0, strURL.Length - 1)
                client = client.Substring(0, client.Length - 1)
            End If
        End If


        strURL &= "&Offices="
        If Me.rblOffices.Items(1).Selected = True Then
            For I = 0 To Me.lbOffices.Items.Count - 1
                If Me.lbOffices.Items(I).Selected = True Then
                    strURL &= Me.lbOffices.Items(I).Value & ","
                    office &= Me.lbOffices.Items(I).Value & ","
                End If
            Next I
            strURL = strURL.Substring(0, strURL.Length - 1)
            office = office.Substring(0, office.Length - 1)
        End If

        strURL &= "&AECodes="
        If Me.rdlAE.Items(1).Selected = True Then
            For I = 0 To Me.lstAEs.Items.Count - 1
                If Me.lstAEs.Items(I).Selected = True Then
                    strURL &= Me.lstAEs.Items(I).Value & ","
                    ae &= Me.lstAEs.Items(I).Value & ","
                End If
            Next I
            strURL = strURL.Substring(0, strURL.Length - 1)
            ae = ae.Substring(0, ae.Length - 1)
        Else
            strURL &= "%"
            ae = "%"
        End If

        strURL &= "&Status="
        If Me.rdlStatus.Items(1).Selected = True Then
            For I = 0 To Me.lbStatus.Items.Count - 1
                If Me.lbStatus.Items(I).Selected = True Then
                    strURL &= Me.lbStatus.Items(I).Value & ","
                    status &= Me.lbStatus.Items(I).Value & ","
                End If
            Next I
            strURL = strURL.Substring(0, strURL.Length - 1)
            status = status.Substring(0, status.Length - 1)
        End If

        strURL &= "&Role="
        If Me.rdlEmployees.Items(1).Selected = True Then
            For I = 0 To Me.lstEmployees.Items.Count - 1
                If Me.lstEmployees.Items(I).Selected = True Then
                    strURL &= Me.lstEmployees.Items(I).Value & ","
                    role &= Me.lstEmployees.Items(I).Value & ","
                End If
            Next I
            strURL = strURL.Substring(0, strURL.Length - 1)
            role = role.Substring(0, role.Length - 1)
        End If

        If Me.rblDates.SelectedValue = "comp" Then
            strURL &= "&completeddates=" & CInt(True)
        Else
            strURL &= "&completeddates=" & CInt(False)
        End If

        If Me.rblDates.SelectedValue = "due" Then
            strURL &= "&duedate=" & CInt(True)
        Else
            strURL &= "&duedate=" & CInt(False)
        End If

        If Me.rblDates.SelectedValue = "duetime" Then
            strURL &= "&duetime=" & CInt(True)
        Else
            strURL &= "&duetime=" & CInt(False)
        End If

        If Me.rblDates.SelectedValue = "origdue" Then
            strURL &= "&origdue=" & CInt(True)
        Else
            strURL &= "&origdue=" & CInt(False)
        End If

        If Me.rblDates.SelectedValue = "origcomp" Then
            strURL &= "&origcomp=" & CInt(True)
        Else
            strURL &= "&origcomp=" & CInt(False)
        End If

        If Me.rblDates.SelectedValue = "duecomp" Then
            strURL &= "&duecomp=" & CInt(True)
        Else
            strURL &= "&duecomp=" & CInt(False)
        End If

        If Me.rblDates.SelectedValue = "dueorcomp" Then
            strURL &= "&dueorcomp=" & CInt(True)
        Else
            strURL &= "&dueorcomp=" & CInt(False)
        End If

        strURL &= "&taskdesc="

        If Not Me.chkNoTasksSummaryOnly.Checked = True Then

            If Me.ddTask1.SelectedValue <> "" Then
                strURL &= Me.ddTask1.SelectedValue.ToString() & ","
                TaskDesc(1) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask2.SelectedValue <> "" Then
                strURL &= Me.ddTask2.SelectedValue.ToString() & ","
                TaskDesc(2) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask3.SelectedValue <> "" Then
                strURL &= Me.ddTask3.SelectedValue.ToString() & ","
                TaskDesc(3) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask4.SelectedValue <> "" Then
                strURL &= Me.ddTask4.SelectedValue.ToString() & ","
                TaskDesc(4) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask5.SelectedValue <> "" Then
                strURL &= Me.ddTask5.SelectedValue.ToString() & ","
                TaskDesc(5) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask6.SelectedValue <> "" Then
                strURL &= Me.ddTask6.SelectedValue.ToString() & ","
                TaskDesc(6) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask7.SelectedValue <> "" Then
                strURL &= Me.ddTask7.SelectedValue.ToString() & ","
                TaskDesc(7) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask8.SelectedValue <> "" Then
                strURL &= Me.ddTask8.SelectedValue.ToString() & ","
                TaskDesc(8) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask9.SelectedValue <> "" Then
                strURL &= Me.ddTask9.SelectedValue.ToString() & ","
                TaskDesc(9) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask10.SelectedValue <> "" Then
                strURL &= Me.ddTask10.SelectedValue.ToString() & ","
                TaskDesc(10) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask11.SelectedValue <> "" Then
                strURL &= Me.ddTask11.SelectedValue.ToString() & ","
                TaskDesc(11) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask12.SelectedValue <> "" Then
                strURL &= Me.ddTask12.SelectedValue.ToString() & ","
                TaskDesc(12) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask13.SelectedValue <> "" Then
                strURL &= Me.ddTask13.SelectedValue.ToString() & ","
                TaskDesc(13) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask14.SelectedValue <> "" Then
                strURL &= Me.ddTask14.SelectedValue.ToString() & ","
                TaskDesc(14) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask15.SelectedValue <> "" Then
                strURL &= Me.ddTask15.SelectedValue.ToString() & ","
                TaskDesc(15) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask16.SelectedValue <> "" Then
                strURL &= Me.ddTask16.SelectedValue.ToString() & ","
                TaskDesc(16) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask17.SelectedValue <> "" Then
                strURL &= Me.ddTask17.SelectedValue.ToString() & ","
                TaskDesc(17) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask18.SelectedValue <> "" Then
                strURL &= Me.ddTask18.SelectedValue.ToString() & ","
                TaskDesc(18) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask19.SelectedValue <> "" Then
                strURL &= Me.ddTask19.SelectedValue.ToString() & ","
                TaskDesc(19) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask20.SelectedValue <> "" Then
                strURL &= Me.ddTask20.SelectedValue.ToString() & ","
                TaskDesc(20) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask21.SelectedValue <> "" Then
                strURL &= Me.ddTask21.SelectedValue.ToString() & ","
                TaskDesc(21) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask22.SelectedValue <> "" Then
                strURL &= Me.ddTask22.SelectedValue.ToString() & ","
                TaskDesc(22) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask23.SelectedValue <> "" Then
                strURL &= Me.ddTask23.SelectedValue.ToString() & ","
                TaskDesc(23) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask24.SelectedValue <> "" Then
                strURL &= Me.ddTask24.SelectedValue.ToString() & ","
                TaskDesc(24) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask25.SelectedValue <> "" Then
                strURL &= Me.ddTask25.SelectedValue.ToString() & ","
                TaskDesc(25) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask26.SelectedValue <> "" Then
                strURL &= Me.ddTask26.SelectedValue.ToString() & ","
                TaskDesc(26) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask27.SelectedValue <> "" Then
                strURL &= Me.ddTask27.SelectedValue.ToString() & ","
                TaskDesc(27) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask28.SelectedValue <> "" Then
                strURL &= Me.ddTask28.SelectedValue.ToString() & ","
                TaskDesc(28) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask29.SelectedValue <> "" Then
                strURL &= Me.ddTask29.SelectedValue.ToString() & ","
                TaskDesc(29) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If
            If Me.ddTask30.SelectedValue <> "" Then
                strURL &= Me.ddTask30.SelectedValue.ToString() & ","
                TaskDesc(30) = Me.ddTask1.SelectedValue.ToString()
                Tasked = True
            End If

            If Tasked = True Then
                strURL = strURL.Substring(0, strURL.Length - 1)
            End If

        End If

        strURL &= "&" & Me.chkManager.ID & "=" & CInt(Me.chkManager.Checked).ToString
        strURL &= "&" & Me.chkProjectDate.ID & "=" & CInt(Me.chkProjectDate.Checked).ToString
        strURL &= "&" & Me.chkJobDueDate1.ID & "=" & CInt(Me.chkJobDueDate1.Checked).ToString
        strURL &= "&" & Me.chkCompletedDate.ID & "=" & CInt(Me.chkCompletedDate.Checked).ToString
        strURL &= "&" & Me.chkClientCode.ID & "=" & CInt(Me.chkClientCode.Checked).ToString
        strURL &= "&" & Me.chkClientDesc.ID & "=" & CInt(Me.chkClientDesc.Checked).ToString
        strURL &= "&" & Me.chkDivisionCode.ID & "=" & CInt(Me.chkDivisionCode.Checked).ToString
        strURL &= "&" & Me.chkDivisionDesc.ID & "=" & CInt(Me.chkDivisionDesc.Checked).ToString
        strURL &= "&" & Me.chkProductCode.ID & "=" & CInt(Me.chkProductCode.Checked).ToString
        strURL &= "&" & Me.chkProductDesc.ID & "=" & CInt(Me.chkProductDesc.Checked).ToString
        strURL &= "&" & Me.chkJobDesc.ID & "=" & CInt(Me.chkJobDesc.Checked).ToString
        strURL &= "&" & Me.chkJobCompNum.ID & "=" & CInt(Me.chkJobCompNum.Checked).ToString
        strURL &= "&" & Me.chkJobCompDesc.ID & "=" & CInt(Me.chkJobCompDesc.Checked).ToString
        strURL &= "&" & Me.chkClientReference.ID & "=" & CInt(Me.chkClientReference.Checked).ToString
        strURL &= "&" & Me.chkAccountExecutive.ID & "=" & CInt(Me.chkAccountExecutive.Checked).ToString
        strURL &= "&" & Me.chkJobType.ID & "=" & CInt(Me.chkJobType.Checked).ToString
        strURL &= "&" & Me.chkJobTypeDesc.ID & "=" & CInt(Me.chkJobTypeDesc.Checked).ToString
        strURL &= "&" & Me.chkRush.ID & "=" & CInt(Me.chkRush.Checked).ToString
        strURL &= "&" & Me.chkJobMarkup.ID & "=" & CInt(Me.chkJobMarkup.Checked).ToString
        strURL &= "&" & Me.chkJobNonBillFlag.ID & "=" & CInt(Me.chkJobNonBillFlag.Checked).ToString
        strURL &= "&" & Me.chkJobDueDate2.ID & "=" & CInt(Me.chkJobDueDate2.Checked).ToString
        strURL &= "&" & Me.chkJobStatus.ID & "=" & CInt(Me.chkJobStatus.Checked).ToString
        strURL &= "&" & Me.chkComments.ID & "=" & CInt(Me.chkComments.Checked).ToString
        strURL &= "&" & Me.chkIncludeEmpAssign.ID & "=" & CInt(Me.chkIncludeEmpAssign.Checked).ToString
        strURL &= "&" & Me.ChkIncludeTaskDesc.ID & "=" & CInt(Me.ChkIncludeTaskDesc.Checked).ToString
        strURL &= "&" & Me.CheckBoxPhase.ID & "=" & CInt(Me.CheckBoxPhase.Checked).ToString
        strURL &= "&" & Me.CheckBoxDateFormat.ID & "=" & CInt(Me.CheckBoxDateFormat.Checked).ToString
        strURL &= "&" & Me.chkJobStatusFirst.ID & "=" & CInt(Me.chkJobStatusFirst.Checked).ToString
        'strURL &= "&" & Me.CheckBoxIncludeEmpRole.ID & "=" & CInt(Me.CheckBoxIncludeEmpRole.Checked).ToString
        strURL &= "&ddManager=" & Me.ddManager.SelectedValue

        Session("TrafficByTaskReportTitle") = Me.txtReportTitle.Text
        'strURL &= "&" & Me.txtReportTitle.ID & "=" & Me.txtReportTitle.Text

        strURL &= "&excel=" & CInt(Me.chkExcel.Checked).ToString
        strURL &= "&closed=" & CInt(Me.chkClosedJobs.Checked).ToString
        strURL &= "&closedstartdate=" & Me.RadDatePickerStartDateClosed.SelectedDate
        strURL &= "&closedenddate=" & Me.RadDatePickerEndDateClosed.SelectedDate
        strURL &= "&qualified=" & CInt(Me.chkAllQualifiedJobs.Checked).ToString
        strURL &= "&forjobduedate=" & CInt(Me.chkForJobDueDate.Checked).ToString
        strURL &= "&forjobstartdate=" & Me.RadDatePickerStartDate.SelectedDate
        strURL &= "&forjobenddate=" & Me.RadDatePickerEndDate.SelectedDate

        If Me.ddSort1.SelectedValue = Me.ddSort2.SelectedValue Then
            Me.ShowMessage("Please select two different sort options.")
            Exit Sub
        End If

        strURL &= "&sort1=" & Me.ddSort1.SelectedValue & " " & Me.ddSort1Direction.SelectedValue
        strURL &= "&sort2=" & Me.ddSort2.SelectedValue & " " & Me.ddSort2Direction.SelectedValue
        'strURL &= "&sort1dir=" & Me.ddSort1Direction.SelectedValue
        'strURL &= "&sort2dir=" & Me.ddSort2Direction.SelectedValue

        'st:
        'ctb: 2006/06/07 - removed the check box and code that referenced it
        strURL &= "&OnlyProjected=0"
        strURL &= "&Format=" & Me.ddlFormat.SelectedValue

        If Me.chkSaveSettings.Checked = True Then
            SaveSettings()
        End If

        Me.lblMSG.Text = ""
        'make open new browser
        'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'strBuilder.Append("<script language='javascript'>")
        'strBuilder.Append("window.open('" & strURL & "', '', 'scrollbars=yes,resizable=yes,menubar=no,maximazable=yes')")
        'strBuilder.Append("</")
        'strBuilder.Append("script>")
        'RegisterStartupScript("newpage", strBuilder.ToString())

        If Me.chkExcel.Checked Then
            Response.Redirect(strURL.ToString())
        Else
            Me.OpenWindow("Schedule By Task", strURL.ToString())
        End If

    End Sub
    Private Sub SaveSettings()
        Dim ThisString As String
        Dim I As Integer
        Dim oAppVars As cAppVars
        'Report Options
        If Me.ddlFormat.SelectedValue = "3" Then
            oAppVars = New cAppVars(cAppVars.Application.TASK_ROLE_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                'Report Options
                .setAppVar("closedjobs", Me.chkClosedJobs.Checked)
                'Day Column Options
                .setAppVar("chkAllQualifiedJobs", Me.chkAllQualifiedJobs.Checked)
                .setAppVar("chkForJobDueDate", Me.chkForJobDueDate.Checked)
                .setAppVar("chkNoTasksSummaryOnly", Me.chkNoTasksSummaryOnly.Checked)
                'Sort Options
                .setAppVar("ddSort1", Me.ddSort1.SelectedValue)
                .setAppVar("ddSort2", Me.ddSort2.SelectedValue)
                .setAppVar("ddSort1Direction", Me.ddSort1Direction.SelectedValue)
                .setAppVar("ddSort2Direction", Me.ddSort2Direction.SelectedValue)
                .setAppVar("ddManager", Me.ddManager.SelectedValue)
                .setAppVar("ddTaskTemplate", Me.ddTaskTemplate.SelectedValue)
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
                If MiscFN.ValidDate(Me.RadDatePickerStartDateClosed) = True Then
                    .setAppVar("StartDateClosed", Me.RadDatePickerStartDateClosed.SelectedDate)
                Else
                    .setAppVar("StartDateClosed", "")
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDateClosed) = True Then
                    .setAppVar("EndDateClosed", Me.RadDatePickerEndDateClosed.SelectedDate)
                Else
                    .setAppVar("EndDateClosed", "")
                End If

                'Task Option
                .setAppVar("ddTask1", Me.ddTask1.SelectedValue)
                .setAppVar("ddTask2", Me.ddTask2.SelectedValue)
                .setAppVar("ddTask3", Me.ddTask3.SelectedValue)
                .setAppVar("ddTask4", Me.ddTask4.SelectedValue)
                .setAppVar("ddTask5", Me.ddTask5.SelectedValue)
                .setAppVar("ddTask6", Me.ddTask6.SelectedValue)
                .setAppVar("ddTask7", Me.ddTask7.SelectedValue)
                .setAppVar("ddTask8", Me.ddTask8.SelectedValue)
                .setAppVar("ddTask9", Me.ddTask9.SelectedValue)
                .setAppVar("ddTask10", Me.ddTask10.SelectedValue)
                .setAppVar("ddTask11", Me.ddTask11.SelectedValue)
                .setAppVar("ddTask12", Me.ddTask12.SelectedValue)
                .setAppVar("ddTask13", Me.ddTask13.SelectedValue)
                .setAppVar("ddTask14", Me.ddTask14.SelectedValue)
                .setAppVar("ddTask15", Me.ddTask15.SelectedValue)
                .setAppVar("ddTask16", Me.ddTask16.SelectedValue)
                .setAppVar("ddTask17", Me.ddTask17.SelectedValue)
                .setAppVar("ddTask18", Me.ddTask18.SelectedValue)
                .setAppVar("ddTask19", Me.ddTask19.SelectedValue)
                .setAppVar("ddTask20", Me.ddTask20.SelectedValue)
                .setAppVar("ddTask21", Me.ddTask21.SelectedValue)
                .setAppVar("ddTask22", Me.ddTask22.SelectedValue)
                .setAppVar("ddTask23", Me.ddTask23.SelectedValue)
                .setAppVar("ddTask24", Me.ddTask24.SelectedValue)
                .setAppVar("ddTask25", Me.ddTask25.SelectedValue)
                .setAppVar("ddTask26", Me.ddTask26.SelectedValue)
                .setAppVar("ddTask27", Me.ddTask27.SelectedValue)
                .setAppVar("ddTask28", Me.ddTask28.SelectedValue)
                .setAppVar("ddTask29", Me.ddTask29.SelectedValue)
                .setAppVar("ddTask30", Me.ddTask30.SelectedValue)

                .setAppVar("chkManager", Me.chkManager.Checked)
                .setAppVar("chkProjectDate", Me.chkProjectDate.Checked)
                .setAppVar("chkClientDesc", Me.chkClientDesc.Checked)
                .setAppVar("chkClientCode", Me.chkClientCode.Checked)
                .setAppVar("chkDivisionDesc", Me.chkDivisionDesc.Checked)
                .setAppVar("chkDivisionCode", Me.chkDivisionCode.Checked)
                .setAppVar("chkProductCode", Me.chkProductCode.Checked)
                .setAppVar("chkProductDesc", Me.chkProductDesc.Checked)
                .setAppVar("chkJobCompNum", Me.chkJobCompNum.Checked)
                .setAppVar("chkJobCompDesc", Me.chkJobCompDesc.Checked)
                .setAppVar("chkClientReference", Me.chkClientReference.Checked)
                .setAppVar("chkAccountExecutive", Me.chkAccountExecutive.Checked)
                .setAppVar("chkJobType", Me.chkJobType.Checked)
                .setAppVar("chkJobTypeDesc", Me.chkJobTypeDesc.Checked)
                .setAppVar("chkJobDueDate1", Me.chkJobDueDate1.Checked)
                .setAppVar("chkComments", Me.chkComments.Checked)
                .setAppVar("chkCompletedDate", Me.chkCompletedDate.Checked)
                .setAppVar("chkRush", Me.chkRush.Checked)
                .setAppVar("chkJobMarkup", Me.chkJobMarkup.Checked)
                .setAppVar("chkJobNonBillFlag", Me.chkJobNonBillFlag.Checked)
                .setAppVar("chkJobDueDate2", Me.chkJobDueDate2.Checked)
                .setAppVar("chkJobStatus", Me.chkJobStatus.Checked)
                .setAppVar("chkJobStatusFirst", Me.chkJobStatusFirst.Checked)
                .setAppVar("chkIncludeEmpAssign", Me.chkIncludeEmpAssign.Checked)
                .setAppVar("chkIncludeTaskDesc", Me.ChkIncludeTaskDesc.Checked)
                .setAppVar("chkMilestone", Me.chkMilestone.Checked)
                .setAppVar("CheckBoxPhase", Me.CheckBoxPhase.Checked)
                Dim rptTitleID As String = Me.txtReportTitle.ID & Me.ddlFormat.SelectedValue
                .setAppVar(rptTitleID, Me.txtReportTitle.Text)
                .SaveAllAppVars()
            End With

        Else
            oAppVars = New cAppVars(cAppVars.Application.TASK_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                'Report Options
                .setAppVar("closedjobs", Me.chkClosedJobs.Checked)
                'Day Column Options
                .setAppVar("chkAllQualifiedJobs", Me.chkAllQualifiedJobs.Checked)
                .setAppVar("chkForJobDueDate", Me.chkForJobDueDate.Checked)
                .setAppVar("chkNoTasksSummaryOnly", Me.chkNoTasksSummaryOnly.Checked)
                'Sort Options
                .setAppVar("ddSort1", Me.ddSort1.SelectedValue)
                .setAppVar("ddSort2", Me.ddSort2.SelectedValue)
                .setAppVar("ddSort1Direction", Me.ddSort1Direction.SelectedValue)
                .setAppVar("ddSort2Direction", Me.ddSort2Direction.SelectedValue)
                .setAppVar("ddManager", Me.ddManager.SelectedValue)
                .setAppVar("ddTaskTemplate", Me.ddTaskTemplate.SelectedValue)
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
                If MiscFN.ValidDate(Me.RadDatePickerStartDateClosed) = True Then
                    .setAppVar("StartDateClosed", Me.RadDatePickerStartDateClosed.SelectedDate)
                Else
                    .setAppVar("StartDateClosed", "")
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDateClosed) = True Then
                    .setAppVar("EndDateClosed", Me.RadDatePickerEndDateClosed.SelectedDate)
                Else
                    .setAppVar("EndDateClosed", "")
                End If

                'Task Option
                .setAppVar("ddTask1", Me.ddTask1.SelectedValue)
                .setAppVar("ddTask2", Me.ddTask2.SelectedValue)
                .setAppVar("ddTask3", Me.ddTask3.SelectedValue)
                .setAppVar("ddTask4", Me.ddTask4.SelectedValue)
                .setAppVar("ddTask5", Me.ddTask5.SelectedValue)
                .setAppVar("ddTask6", Me.ddTask6.SelectedValue)
                .setAppVar("ddTask7", Me.ddTask7.SelectedValue)
                .setAppVar("ddTask8", Me.ddTask8.SelectedValue)
                .setAppVar("ddTask9", Me.ddTask9.SelectedValue)
                .setAppVar("ddTask10", Me.ddTask10.SelectedValue)
                .setAppVar("ddTask11", Me.ddTask11.SelectedValue)
                .setAppVar("ddTask12", Me.ddTask12.SelectedValue)
                .setAppVar("ddTask13", Me.ddTask13.SelectedValue)
                .setAppVar("ddTask14", Me.ddTask14.SelectedValue)
                .setAppVar("ddTask15", Me.ddTask15.SelectedValue)
                .setAppVar("ddTask16", Me.ddTask16.SelectedValue)
                .setAppVar("ddTask17", Me.ddTask17.SelectedValue)
                .setAppVar("ddTask18", Me.ddTask18.SelectedValue)
                .setAppVar("ddTask19", Me.ddTask19.SelectedValue)
                .setAppVar("ddTask20", Me.ddTask20.SelectedValue)
                .setAppVar("ddTask21", Me.ddTask21.SelectedValue)
                .setAppVar("ddTask22", Me.ddTask22.SelectedValue)
                .setAppVar("ddTask23", Me.ddTask23.SelectedValue)
                .setAppVar("ddTask24", Me.ddTask24.SelectedValue)
                .setAppVar("ddTask25", Me.ddTask25.SelectedValue)
                .setAppVar("ddTask26", Me.ddTask26.SelectedValue)
                .setAppVar("ddTask27", Me.ddTask27.SelectedValue)
                .setAppVar("ddTask28", Me.ddTask28.SelectedValue)
                .setAppVar("ddTask29", Me.ddTask29.SelectedValue)
                .setAppVar("ddTask30", Me.ddTask30.SelectedValue)

                .setAppVar("chkManager", Me.chkManager.Checked)
                .setAppVar("chkProjectDate", Me.chkProjectDate.Checked)
                .setAppVar("chkClientDesc", Me.chkClientDesc.Checked)
                .setAppVar("chkClientCode", Me.chkClientCode.Checked)
                .setAppVar("chkDivisionDesc", Me.chkDivisionDesc.Checked)
                .setAppVar("chkDivisionCode", Me.chkDivisionCode.Checked)
                .setAppVar("chkProductCode", Me.chkProductCode.Checked)
                .setAppVar("chkProductDesc", Me.chkProductDesc.Checked)
                .setAppVar("chkJobCompNum", Me.chkJobCompNum.Checked)
                .setAppVar("chkJobCompDesc", Me.chkJobCompDesc.Checked)
                .setAppVar("chkClientReference", Me.chkClientReference.Checked)
                .setAppVar("chkAccountExecutive", Me.chkAccountExecutive.Checked)
                .setAppVar("chkJobType", Me.chkJobType.Checked)
                .setAppVar("chkJobTypeDesc", Me.chkJobTypeDesc.Checked)
                .setAppVar("chkJobDueDate1", Me.chkJobDueDate1.Checked)
                .setAppVar("chkComments", Me.chkComments.Checked)
                .setAppVar("chkCompletedDate", Me.chkCompletedDate.Checked)
                .setAppVar("chkRush", Me.chkRush.Checked)
                .setAppVar("chkJobMarkup", Me.chkJobMarkup.Checked)
                .setAppVar("chkJobNonBillFlag", Me.chkJobNonBillFlag.Checked)
                .setAppVar("chkJobDueDate2", Me.chkJobDueDate2.Checked)
                .setAppVar("chkJobStatus", Me.chkJobStatus.Checked)
                .setAppVar("chkJobStatusFirst", Me.chkJobStatusFirst.Checked)
                .setAppVar("chkIncludeEmpAssign", Me.chkIncludeEmpAssign.Checked)
                .setAppVar("chkIncludeTaskDesc", Me.ChkIncludeTaskDesc.Checked)
                .setAppVar("chkMilestone", Me.chkMilestone.Checked)
                .setAppVar("CheckBoxPhase", Me.CheckBoxPhase.Checked)
                Dim rptTitleID As String = Me.txtReportTitle.ID & Me.ddlFormat.SelectedValue
                .setAppVar(rptTitleID, Me.txtReportTitle.Text)
                .SaveAllAppVars()
            End With

            'Response.Cookies("rpttrafficschedulesa").Expires = Now.AddYears(1)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkClosedJobs.ID) = Me.chkClosedJobs.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkAllQualifiedJobs.ID) = Me.chkAllQualifiedJobs.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkForJobDueDate.ID) = Me.chkForJobDueDate.Checked
            'If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
            '    Response.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerStartDate.ID) = Me.RadDatePickerStartDate.SelectedDate
            'Else
            '    Response.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerStartDate.ID) = ""
            'End If
            'If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
            '    Response.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerEndDate.ID) = Me.RadDatePickerEndDate.SelectedDate
            'Else
            '    Response.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerEndDate.ID) = ""
            'End If
            'If MiscFN.ValidDate(Me.RadDatePickerStartDateClosed) = True Then
            '    Response.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerStartDateClosed.ID) = Me.RadDatePickerStartDateClosed.SelectedDate
            'Else
            '    Response.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerStartDateClosed.ID) = ""
            'End If
            'If MiscFN.ValidDate(Me.RadDatePickerEndDateClosed) = True Then
            '    Response.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerEndDateClosed.ID) = Me.RadDatePickerEndDateClosed.SelectedDate
            'Else
            '    Response.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerEndDateClosed.ID) = ""
            'End If
            'Response.Cookies("rpttrafficschedulesa")(Me.chkNoTasksSummaryOnly.ID) = Me.chkNoTasksSummaryOnly.Checked

            ''Task Option
            'Response.Cookies("rpttrafficschedulesa")("Task1") = Me.ddTask1.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task2") = Me.ddTask2.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task3") = Me.ddTask3.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task4") = Me.ddTask4.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task5") = Me.ddTask5.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task6") = Me.ddTask6.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task7") = Me.ddTask7.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task8") = Me.ddTask8.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task9") = Me.ddTask9.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task10") = Me.ddTask10.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task11") = Me.ddTask11.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task12") = Me.ddTask12.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task13") = Me.ddTask13.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task14") = Me.ddTask14.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task15") = Me.ddTask15.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task16") = Me.ddTask16.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task17") = Me.ddTask17.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task18") = Me.ddTask18.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task19") = Me.ddTask19.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task20") = Me.ddTask20.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task21") = Me.ddTask21.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task22") = Me.ddTask22.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task23") = Me.ddTask23.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task24") = Me.ddTask24.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task25") = Me.ddTask25.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task26") = Me.ddTask26.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task27") = Me.ddTask27.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task28") = Me.ddTask28.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task29") = Me.ddTask29.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("Task30") = Me.ddTask30.SelectedValue

            ''Sort Options
            'Response.Cookies("rpttrafficschedulesa")("ddSort1") = Me.ddSort1.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("ddSort2") = Me.ddSort2.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("ddSort1Direction") = Me.ddSort1Direction.SelectedValue
            'Response.Cookies("rpttrafficschedulesa")("ddSort2Direction") = Me.ddSort2Direction.SelectedValue
        End If


        If Me.ddlFormat.SelectedValue = "1" Then
            oAppVars = New cAppVars(cAppVars.Application.TASK_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                'Report Options
                .setAppVar("closedjobs", Me.chkClosedJobs.Checked)
                'Day Column Options
                .setAppVar("chkAllQualifiedJobs", Me.chkAllQualifiedJobs.Checked)
                .setAppVar("chkForJobDueDate", Me.chkForJobDueDate.Checked)
                .setAppVar("chkNoTasksSummaryOnly", Me.chkNoTasksSummaryOnly.Checked)
                'Sort Options
                .setAppVar("ddSort1", Me.ddSort1.SelectedValue)
                .setAppVar("ddSort2", Me.ddSort2.SelectedValue)
                .setAppVar("ddSort1Direction", Me.ddSort1Direction.SelectedValue)
                .setAppVar("ddSort2Direction", Me.ddSort2Direction.SelectedValue)
                .setAppVar("ddManager", Me.ddManager.SelectedValue)
                .setAppVar("ddTaskTemplate", Me.ddTaskTemplate.SelectedValue)

                .setAppVar("chkManager", Me.chkManager.Checked)
                .setAppVar("chkProjectDate", Me.chkProjectDate.Checked)
                .setAppVar("chkClientDesc", Me.chkClientDesc.Checked)
                .setAppVar("chkClientCode", Me.chkClientCode.Checked)
                .setAppVar("chkDivisionDesc", Me.chkDivisionDesc.Checked)
                .setAppVar("chkDivisionCode", Me.chkDivisionCode.Checked)
                .setAppVar("chkProductCode", Me.chkProductCode.Checked)
                .setAppVar("chkProductDesc", Me.chkProductDesc.Checked)
                .setAppVar("chkJobCompNum", Me.chkJobCompNum.Checked)
                .setAppVar("chkJobCompDesc", Me.chkJobCompDesc.Checked)
                .setAppVar("chkClientReference", Me.chkClientReference.Checked)
                .setAppVar("chkAccountExecutive", Me.chkAccountExecutive.Checked)
                .setAppVar("chkJobType", Me.chkJobType.Checked)
                .setAppVar("chkJobTypeDesc", Me.chkJobTypeDesc.Checked)
                .setAppVar("chkJobDueDate1", Me.chkJobDueDate1.Checked)
                .setAppVar("chkComments", Me.chkComments.Checked)
                .setAppVar("chkCompletedDate", Me.chkCompletedDate.Checked)
                .setAppVar("chkRush", Me.chkRush.Checked)
                .setAppVar("chkJobMarkup", Me.chkJobMarkup.Checked)
                .setAppVar("chkJobNonBillFlag", Me.chkJobNonBillFlag.Checked)
                .setAppVar("chkJobDueDate2", Me.chkJobDueDate2.Checked)
                .setAppVar("chkJobStatus", Me.chkJobStatus.Checked)
                .setAppVar("chkJobStatusFirst", Me.chkJobStatusFirst.Checked)
                .setAppVar("chkIncludeEmpAssign", Me.chkIncludeEmpAssign.Checked)
                .setAppVar("chkIncludeTaskDesc", Me.ChkIncludeTaskDesc.Checked)
                .setAppVar("chkMilestone", Me.chkMilestone.Checked)
                .setAppVar("CheckBoxPhase", Me.CheckBoxPhase.Checked)
                .setAppVar("CheckBoxDateFormat", Me.CheckBoxDateFormat.Checked)
                Dim rptTitleID As String = Me.txtReportTitle.ID & Me.ddlFormat.SelectedValue
                .setAppVar(rptTitleID, Me.txtReportTitle.Text)
                Dim k As Integer
                For k = 0 To Me.rblDates.Items.Count - 1
                    If Me.rblDates.Items(k).Selected = True Then
                        .setAppVar("rblDates", Me.rblDates.Items(k).Text)
                        'Response.Cookies("rpttrafficschedulesa")(Me.rblDates.ID) = Me.rblDates.Items(k).Text
                    End If
                Next
                .SaveAllAppVars()
            End With

            'Show Fields
            'Response.Cookies("rpttrafficschedulesa")(Me.chkManager.ID) = Me.chkManager.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkProjectDate.ID) = Me.chkProjectDate.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobDueDate1.ID) = Me.chkJobDueDate1.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkCompletedDate.ID) = Me.chkCompletedDate.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkClientDesc.ID) = Me.chkClientDesc.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkClientCode.ID) = Me.chkClientCode.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkDivisionDesc.ID) = Me.chkDivisionDesc.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkDivisionCode.ID) = Me.chkDivisionCode.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkProductCode.ID) = Me.chkProductCode.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkProductDesc.ID) = Me.chkProductDesc.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobCompNum.ID) = Me.chkJobCompNum.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobCompDesc.ID) = Me.chkJobCompDesc.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkClientReference.ID) = Me.chkClientReference.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkAccountExecutive.ID) = Me.chkAccountExecutive.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobType.ID) = Me.chkJobType.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobTypeDesc.ID) = Me.chkJobTypeDesc.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkRush.ID) = Me.chkRush.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobMarkup.ID) = Me.chkJobMarkup.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobNonBillFlag.ID) = Me.chkJobNonBillFlag.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobDueDate2.ID) = Me.chkJobDueDate2.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobStatus.ID) = Me.chkJobStatus.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.chkComments.ID) = Me.chkComments.Checked

            'Response.Cookies("rpttrafficschedulesa")(Me.chkIncludeEmpAssign.ID) = Me.chkIncludeEmpAssign.Checked
            'Response.Cookies("rpttrafficschedulesa")(Me.ChkIncludeTaskDesc.ID) = Me.ChkIncludeTaskDesc.Checked
            'Response.Cookies("rpttrafficschedulesa")("ddManager") = Me.ddManager.SelectedValue

            'Response.Cookies("rpttrafficschedulesa")(Me.chkMilestone.ID) = Me.chkMilestone.Checked  'Milestone Tasks Only

            'Dim k As Integer
            'For k = 0 To Me.rblDates.Items.Count - 1
            '    If Me.rblDates.Items(k).Selected = True Then
            '        Response.Cookies("rpttrafficschedulesa")(Me.rblDates.ID) = Me.rblDates.Items(k).Text
            '    End If
            'Next

        ElseIf Me.ddlFormat.SelectedValue = "2" Then
            oAppVars = New cAppVars(cAppVars.Application.TASK_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                'Report Options
                .setAppVar("closedjobs", Me.chkClosedJobs.Checked)
                'Day Column Options
                .setAppVar("chkAllQualifiedJobs", Me.chkAllQualifiedJobs.Checked)
                .setAppVar("chkForJobDueDate", Me.chkForJobDueDate.Checked)
                .setAppVar("chkNoTasksSummaryOnly", Me.chkNoTasksSummaryOnly.Checked)
                'Sort Options
                .setAppVar("chkManager", Me.chkManager.Checked)
                .setAppVar("ddSort1", Me.ddSort1.SelectedValue)
                .setAppVar("ddSort2", Me.ddSort2.SelectedValue)
                .setAppVar("ddSort1Direction", Me.ddSort1Direction.SelectedValue)
                .setAppVar("ddSort2Direction", Me.ddSort2Direction.SelectedValue)
                .setAppVar("ddManager", Me.ddManager.SelectedValue)
                .setAppVar("chkProjectDate", Me.chkProjectDate.Checked)
                .setAppVar("chkClientDesc", Me.chkClientDesc.Checked)
                .setAppVar("chkClientCode", Me.chkClientCode.Checked)
                .setAppVar("chkDivisionDesc", Me.chkDivisionDesc.Checked)
                .setAppVar("chkDivisionCode", Me.chkDivisionCode.Checked)
                .setAppVar("chkProductCode", Me.chkProductCode.Checked)
                .setAppVar("chkProductDesc", Me.chkProductDesc.Checked)
                .setAppVar("chkJobCompNum", Me.chkJobCompNum.Checked)
                .setAppVar("chkJobCompDesc", Me.chkJobCompDesc.Checked)
                .setAppVar("chkClientReference", Me.chkClientReference.Checked)
                .setAppVar("chkAccountExecutive", Me.chkAccountExecutive.Checked)
                .setAppVar("chkJobType", Me.chkJobType.Checked)
                .setAppVar("chkJobTypeDesc", Me.chkJobTypeDesc.Checked)
                .setAppVar("chkJobDueDate1", Me.chkJobDueDate1.Checked)
                .setAppVar("chkComments", Me.chkComments.Checked)
                .setAppVar("chkCompletedDate", Me.chkCompletedDate.Checked)
                .setAppVar("chkRush", Me.chkRush.Checked)
                .setAppVar("chkJobMarkup", Me.chkJobMarkup.Checked)
                .setAppVar("chkJobNonBillFlag", Me.chkJobNonBillFlag.Checked)
                .setAppVar("chkJobDueDate2", Me.chkJobDueDate2.Checked)
                .setAppVar("chkJobStatus", Me.chkJobStatus.Checked)
                .setAppVar("chkJobStatusFirst", Me.chkJobStatusFirst.Checked)
                .setAppVar("chkIncludeEmpAssign", Me.chkIncludeEmpAssign.Checked)
                .setAppVar("chkIncludeTaskDesc", Me.ChkIncludeTaskDesc.Checked)
                .setAppVar("chkMilestone", Me.chkMilestone.Checked)
                .setAppVar("CheckBoxPhase", Me.CheckBoxPhase.Checked)
                Dim k As Integer
                For k = 0 To Me.rblDates.Items.Count - 1
                    If Me.rblDates.Items(k).Selected = True Then
                        .setAppVar("rblDates", Me.rblDates.Items(k).Text)
                        'Response.Cookies("rpttrafficschedulesa")(Me.rblDates.ID) = Me.rblDates.Items(k).Text
                    End If
                Next
                .SaveAllAppVars()
            End With


            'Response.Cookies("rpttrafficschedulesa")(Me.chkManager.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkManager.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkProjectDate.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkProjectDate.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobDueDate1.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobDueDate1.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkCompletedDate.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkCompletedDate.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkClientDesc.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkClientDesc.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkClientCode.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkClientCode.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkDivisionDesc.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkDivisionDesc.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkDivisionCode.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkDivisionCode.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkProductCode.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkProductCode.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkProductDesc.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkProductDesc.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobCompNum.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobCompNum.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobCompDesc.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobCompDesc.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkClientReference.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkClientReference.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkAccountExecutive.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkAccountExecutive.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobType.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobType.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobTypeDesc.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobTypeDesc.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkRush.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkRush.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobMarkup.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobMarkup.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobNonBillFlag.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobNonBillFlag.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobDueDate2.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobDueDate2.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkJobStatus.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkJobStatus.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.chkComments.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkComments.ID)

            'Response.Cookies("rpttrafficschedulesa")(Me.chkIncludeEmpAssign.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkIncludeEmpAssign.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.ChkIncludeTaskDesc.ID) = Request.Cookies("rpttrafficschedulesa")(Me.ChkIncludeTaskDesc.ID)
            'Response.Cookies("rpttrafficschedulesa")("ddManager") = Request.Cookies("rpttrafficschedulesa")("ddManager")

            'Response.Cookies("rpttrafficschedulesa")(Me.chkMilestone.ID) = Request.Cookies("rpttrafficschedulesa")(Me.chkMilestone.ID)
            'Response.Cookies("rpttrafficschedulesa")(Me.rblDates.ID) = Request.Cookies("rpttrafficschedulesa")(Me.rblDates.ID)
        End If

    End Sub
    Private Sub LoadSettings()
        Dim ThisString As String
        Dim Clients() As String
        Dim I As Integer

        Dim oAppVars As cAppVars
        Dim s As String = ""
        If Me.ddlFormat.SelectedValue = "3" Then
            If Me.IsClientPortal = True Then
                oAppVars = New cAppVars(cAppVars.Application.TASK_ROLE_RPT, Session("UserID"))
            Else
                oAppVars = New cAppVars(cAppVars.Application.TASK_ROLE_RPT, Session("UserCode"))
            End If
            oAppVars.getAllAppVars()

            Try
                s = oAppVars.getAppVar("closedjobs")
                If s <> "" Then
                    Me.chkClosedJobs.Checked = s
                End If
                s = oAppVars.getAppVar("chkAllQualifiedJobs")
                If s <> "" Then
                    Me.chkAllQualifiedJobs.Checked = s
                End If
                s = oAppVars.getAppVar("chkForJobDueDate")
                If s <> "" Then
                    Me.chkForJobDueDate.Checked = s
                End If
                'Me.chkClosedJobs.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkClosedJobs.ID)
                'Me.chkAllQualifiedJobs.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkAllQualifiedJobs.ID)
                'Me.chkForJobDueDate.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkForJobDueDate.ID)

                s = oAppVars.getAppVar("StartDate")
                If s <> "" Then
                    Me.RadDatePickerStartDate.SelectedDate = CType(s, Date)
                End If
                s = oAppVars.getAppVar("EndDate")
                If s <> "" Then
                    Me.RadDatePickerEndDate.SelectedDate = CType(s, Date)
                End If

                s = oAppVars.getAppVar("StartDateClosed")
                If s <> "" Then
                    Me.RadDatePickerStartDateClosed.SelectedDate = CType(s, Date)
                End If
                s = oAppVars.getAppVar("EndDateClosed")
                If s <> "" Then
                    Me.RadDatePickerEndDateClosed.SelectedDate = CType(s, Date)
                End If
                'Me.RadDatePickerStartDate.SelectedDate = CType(Request.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerStartDate.ID), Date)
                'Me.RadDatePickerEndDate.SelectedDate = CType(Request.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerEndDate.ID), Date)
                'Me.RadDatePickerStartDateClosed.SelectedDate = CType(Request.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerStartDateClosed.ID), Date)
                'Me.RadDatePickerEndDateClosed.SelectedDate = CType(Request.Cookies("rpttrafficschedulesarole")(Me.RadDatePickerEndDateClosed.ID), Date)

                s = oAppVars.getAppVar("chkNoTasksSummaryOnly")
                If s <> "" Then
                    Me.chkNoTasksSummaryOnly.Checked = s
                End If
                'Me.chkNoTasksSummaryOnly.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkNoTasksSummaryOnly.ID)
                If Me.chkClosedJobs.Checked = True Then
                    Me.RadDatePickerStartDateClosed.CssClass = "RequiredInput"
                    Me.RadDatePickerEndDateClosed.CssClass = "RequiredInput"
                Else
                    Me.RadDatePickerStartDateClosed.CssClass = Nothing
                    Me.RadDatePickerEndDateClosed.CssClass = Nothing
                End If
                If Me.chkForJobDueDate.Checked = True Then
                    Me.RadDatePickerStartDate.CssClass = "RequiredInput"
                    Me.RadDatePickerEndDate.CssClass = "RequiredInput"
                Else
                    Me.RadDatePickerStartDate.CssClass = Nothing
                    Me.RadDatePickerEndDate.CssClass = Nothing
                End If
            Catch
            End Try

            Try
                Dim rptTitleID As String = Me.txtReportTitle.ID & Me.ddlFormat.SelectedValue
                s = oAppVars.getAppVar(rptTitleID)
                If s <> "" Then
                    Me.txtReportTitle.Text = s
                End If
            Catch ex As Exception
            End Try
            If Me.txtReportTitle.Text = "" Then
                If Me.ddlFormat.SelectedValue = "1" Then
                    Me.txtReportTitle.Text = "Schedule by Task"
                ElseIf Me.ddlFormat.SelectedValue = "3" Then
                    Me.txtReportTitle.Text = "Schedule by Role"
                Else
                    Me.txtReportTitle.Text = "Completed Task Report"
                End If
            End If

            Try
                'Show Fields
                s = oAppVars.getAppVar("chkManager")
                If s <> "" Then
                    Me.chkManager.Checked = s
                End If
                s = oAppVars.getAppVar("chkProjectDate")
                If s <> "" Then
                    Me.chkProjectDate.Checked = s
                End If
                s = oAppVars.getAppVar("chkClientDesc")
                If s <> "" Then
                    Me.chkClientDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkClientCode")
                If s <> "" Then
                    Me.chkClientCode.Checked = s
                End If
                s = oAppVars.getAppVar("chkDivisionDesc")
                If s <> "" Then
                    Me.chkDivisionDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkDivisionCode")
                If s <> "" Then
                    Me.chkDivisionCode.Checked = s
                End If
                s = oAppVars.getAppVar("chkProductCode")
                If s <> "" Then
                    Me.chkProductCode.Checked = s
                End If
                s = oAppVars.getAppVar("chkProductDesc")
                If s <> "" Then
                    Me.chkProductDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobCompNum")
                If s <> "" Then
                    Me.chkJobCompNum.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobCompDesc")
                If s <> "" Then
                    Me.chkJobCompDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkClientReference")
                If s <> "" Then
                    Me.chkClientReference.Checked = s
                End If
                s = oAppVars.getAppVar("chkAccountExecutive")
                If s <> "" Then
                    Me.chkAccountExecutive.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobType")
                If s <> "" Then
                    Me.chkJobType.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobTypeDesc")
                If s <> "" Then
                    Me.chkJobTypeDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkRush")
                If s <> "" Then
                    Me.chkRush.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobMarkup")
                If s <> "" Then
                    Me.chkJobMarkup.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobNonBillFlag")
                If s <> "" Then
                    Me.chkJobNonBillFlag.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobDueDate1")
                If s <> "" Then
                    Me.chkJobDueDate1.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobDueDate2")
                If s <> "" Then
                    Me.chkJobDueDate2.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobStatus")
                If s <> "" Then
                    Me.chkJobStatus.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobStatusFirst")
                If s <> "" Then
                    Me.chkJobStatusFirst.Checked = s
                End If
                s = oAppVars.getAppVar("chkComments")
                If s <> "" Then
                    Me.chkComments.Checked = s
                End If
                s = oAppVars.getAppVar("chkIncludeEmpAssign")
                If s <> "" Then
                    Me.chkIncludeEmpAssign.Checked = s
                End If
                s = oAppVars.getAppVar("chkIncludeTaskDesc")
                If s <> "" Then
                    Me.ChkIncludeTaskDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkMilestone")
                If s <> "" Then
                    Me.chkMilestone.Checked = s
                End If
                s = oAppVars.getAppVar("chkCompletedDate")
                If s <> "" Then
                    Me.chkCompletedDate.Checked = s
                End If
                s = oAppVars.getAppVar("CheckBoxPhase")
                If s <> "" Then
                    Me.CheckBoxPhase.Checked = s
                End If
                'Me.chkManager.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkManager.ID)
                'Me.chkProjectDate.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkProjectDate.ID)
                'Me.chkJobDueDate1.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobDueDate1.ID)
                'Me.chkCompletedDate.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkCompletedDate.ID)
                'Me.chkClientDesc.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkClientDesc.ID)
                'Me.chkClientCode.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkClientCode.ID)
                'Me.chkDivisionDesc.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkDivisionDesc.ID)
                'Me.chkDivisionCode.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkDivisionCode.ID)
                'Me.chkProductCode.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkProductCode.ID)
                'Me.chkProductDesc.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkProductDesc.ID)
                'Me.chkJobCompNum.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobCompNum.ID)
                'Me.chkJobCompDesc.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobCompDesc.ID)
                'Me.chkClientReference.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkClientReference.ID)
                'Me.chkAccountExecutive.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkAccountExecutive.ID)
                'Me.chkJobType.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobType.ID)
                'Me.chkJobTypeDesc.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobTypeDesc.ID)
                'Me.chkRush.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkRush.ID)
                'Me.chkJobMarkup.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobMarkup.ID)
                'Me.chkJobNonBillFlag.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobNonBillFlag.ID)
                'Me.chkJobDueDate2.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobDueDate2.ID)
                'Me.chkJobStatus.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkJobStatus.ID)
                'Me.chkComments.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkComments.ID)

                'Me.chkIncludeEmpAssign.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkIncludeEmpAssign.ID)
                'Me.ChkIncludeTaskDesc.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.ChkIncludeTaskDesc.ID)

                'Me.chkMilestone.Checked = Request.Cookies("rpttrafficschedulesarole")(Me.chkMilestone.ID)   'Milestone Tasks Only

                'Sort Options
                s = oAppVars.getAppVar("ddSort1")
                If s <> "" Then
                    Me.ddSort1.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddSort2")
                If s <> "" Then
                    Me.ddSort2.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddSort1Direction")
                If s <> "" Then
                    Me.ddSort1Direction.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddSort2Direction")
                If s <> "" Then
                    Me.ddSort2Direction.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddManager")
                If s <> "" Then
                    Me.ddManager.SelectedValue = s
                End If
                'Me.ddSort1.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("ddSort1")
                'Me.ddSort2.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("ddSort2")
                'Me.ddSort1Direction.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("ddSort1Direction")
                'Me.ddSort2Direction.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("ddSort2Direction")
                'Me.ddManager.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("ddManager")

            Catch ex As Exception
            End Try



            Try
                'Task Option
                s = oAppVars.getAppVar("ddTaskTemplate")
                If s <> "" Then
                    Me.ddTaskTemplate.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask1")
                If oAppVars.HasAppVar("ddTask1") Then
                    Me.ddTask1.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask2")
                If oAppVars.HasAppVar("ddTask2") Then
                    Me.ddTask2.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask3")
                If oAppVars.HasAppVar("ddTask3") Then
                    Me.ddTask3.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask4")
                If oAppVars.HasAppVar("ddTask4") Then
                    Me.ddTask4.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask5")
                If oAppVars.HasAppVar("ddTask5") Then
                    Me.ddTask5.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask6")
                If oAppVars.HasAppVar("ddTask6") Then
                    Me.ddTask6.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask7")
                If oAppVars.HasAppVar("ddTask7") Then
                    Me.ddTask7.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask8")
                If oAppVars.HasAppVar("ddTask8") Then
                    Me.ddTask8.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask9")
                If oAppVars.HasAppVar("ddTask9") Then
                    Me.ddTask9.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask10")
                If oAppVars.HasAppVar("ddTask10") Then
                    Me.ddTask10.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask11")
                If oAppVars.HasAppVar("ddTask11") Then
                    Me.ddTask11.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask12")
                If oAppVars.HasAppVar("ddTask12") Then
                    Me.ddTask12.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask13")
                If oAppVars.HasAppVar("ddTask13") Then
                    Me.ddTask13.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask14")
                If oAppVars.HasAppVar("ddTask14") Then
                    Me.ddTask14.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask15")
                If oAppVars.HasAppVar("ddTask15") Then
                    Me.ddTask15.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask16")
                If oAppVars.HasAppVar("ddTask16") Then
                    Me.ddTask16.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask17")
                If oAppVars.HasAppVar("ddTask17") Then
                    Me.ddTask17.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask18")
                If oAppVars.HasAppVar("ddTask18") Then
                    Me.ddTask18.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask19")
                If oAppVars.HasAppVar("ddTask19") Then
                    Me.ddTask19.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask20")
                If oAppVars.HasAppVar("ddTask20") Then
                    Me.ddTask20.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask21")
                If oAppVars.HasAppVar("ddTask21") Then
                    Me.ddTask21.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask22")
                If oAppVars.HasAppVar("ddTask22") Then
                    Me.ddTask22.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask23")
                If oAppVars.HasAppVar("ddTask23") Then
                    Me.ddTask23.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask24")
                If oAppVars.HasAppVar("ddTask24") Then
                    Me.ddTask24.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask25")
                If oAppVars.HasAppVar("ddTask25") Then
                    Me.ddTask25.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask26")
                If oAppVars.HasAppVar("ddTask26") Then
                    Me.ddTask26.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask27")
                If oAppVars.HasAppVar("ddTask27") Then
                    Me.ddTask27.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask28")
                If oAppVars.HasAppVar("ddTask28") Then
                    Me.ddTask28.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask29")
                If oAppVars.HasAppVar("ddTask29") Then
                    Me.ddTask29.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask30")
                If oAppVars.HasAppVar("ddTask30") Then
                    Me.ddTask30.SelectedValue = s
                End If
                'Me.ddTask1.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task1")
                'Me.ddTask2.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task2")
                'Me.ddTask3.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task3")
                'Me.ddTask4.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task4")
                'Me.ddTask5.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task5")
                'Me.ddTask6.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task6")
                'Me.ddTask7.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task7")
                'Me.ddTask8.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task8")
                'Me.ddTask9.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task9")
                'Me.ddTask10.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task10")
                'Me.ddTask11.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task11")
                'Me.ddTask12.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task12")
                'Me.ddTask13.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task13")
                'Me.ddTask14.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task14")
                'Me.ddTask15.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task15")
                'Me.ddTask16.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task16")
                'Me.ddTask17.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task17")
                'Me.ddTask18.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task18")
                'Me.ddTask19.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task19")
                'Me.ddTask20.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task20")
                'Me.ddTask21.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task21")
                'Me.ddTask22.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task22")
                'Me.ddTask23.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task23")
                'Me.ddTask24.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task24")
                'Me.ddTask25.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task25")
                'Me.ddTask26.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task26")
                'Me.ddTask27.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task27")
                'Me.ddTask28.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task28")
                'Me.ddTask29.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task29")
                'Me.ddTask30.SelectedValue = Request.Cookies("rpttrafficschedulesarole")("Task30")
            Catch

            End Try
        Else
            Try
                If Me.IsClientPortal = True Then
                    oAppVars = New cAppVars(cAppVars.Application.TASK_RPT, Session("UserID"))
                Else
                    oAppVars = New cAppVars(cAppVars.Application.TASK_RPT, Session("UserCode"))
                End If
                oAppVars.getAllAppVars()
                s = oAppVars.getAppVar("closedjobs")
                If s <> "" Then
                    Me.chkClosedJobs.Checked = s
                End If
                s = oAppVars.getAppVar("chkAllQualifiedJobs")
                If s <> "" Then
                    Me.chkAllQualifiedJobs.Checked = s
                End If
                s = oAppVars.getAppVar("chkForJobDueDate")
                If s <> "" Then
                    Me.chkForJobDueDate.Checked = s
                End If
                'Me.chkClosedJobs.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkClosedJobs.ID)
                'Me.chkAllQualifiedJobs.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkAllQualifiedJobs.ID)
                'Me.chkForJobDueDate.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkForJobDueDate.ID)
                s = oAppVars.getAppVar("StartDate")
                If s <> "" Then
                    Me.RadDatePickerStartDate.SelectedDate = CType(s, Date)
                End If
                s = oAppVars.getAppVar("EndDate")
                If s <> "" Then
                    Me.RadDatePickerEndDate.SelectedDate = CType(s, Date)
                End If

                s = oAppVars.getAppVar("StartDateClosed")
                If s <> "" Then
                    Me.RadDatePickerStartDateClosed.SelectedDate = CType(s, Date)
                End If
                s = oAppVars.getAppVar("EndDateClosed")
                If s <> "" Then
                    Me.RadDatePickerEndDateClosed.SelectedDate = CType(s, Date)
                End If
                'Me.RadDatePickerStartDate.SelectedDate = CType(Request.Cookies("rpttrafficschedulesa")(Me.RadDatePickerStartDate.ID), Date)
                'Me.RadDatePickerEndDate.SelectedDate = CType(Request.Cookies("rpttrafficschedulesa")(Me.RadDatePickerEndDate.ID), Date)
                'Me.RadDatePickerStartDateClosed.SelectedDate = CType(Request.Cookies("rpttrafficschedulesa")(Me.RadDatePickerStartDateClosed.ID), Date)
                'Me.RadDatePickerEndDateClosed.SelectedDate = CType(Request.Cookies("rpttrafficschedulesa")(Me.RadDatePickerEndDateClosed.ID), Date)
                s = oAppVars.getAppVar("chkNoTasksSummaryOnly")
                If s <> "" Then
                    Me.chkNoTasksSummaryOnly.Checked = s
                End If
                'Me.chkNoTasksSummaryOnly.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkNoTasksSummaryOnly.ID)
                If Me.chkClosedJobs.Checked = True Then
                    Me.RadDatePickerStartDateClosed.CssClass = "RequiredInput"
                    Me.RadDatePickerEndDateClosed.CssClass = "RequiredInput"
                Else
                    Me.RadDatePickerStartDateClosed.CssClass = Nothing
                    Me.RadDatePickerEndDateClosed.CssClass = Nothing
                End If
                If Me.chkForJobDueDate.Checked = True Then
                    Me.RadDatePickerStartDate.CssClass = "RequiredInput"
                    Me.RadDatePickerEndDate.CssClass = "RequiredInput"
                Else
                    Me.RadDatePickerStartDate.CssClass = Nothing
                    Me.RadDatePickerEndDate.CssClass = Nothing
                End If
            Catch
            End Try

            Try
                Dim rptTitleID As String = Me.txtReportTitle.ID & Me.ddlFormat.SelectedValue
                s = oAppVars.getAppVar(rptTitleID)
                If s <> "" Then
                    Me.txtReportTitle.Text = s
                End If
            Catch ex As Exception
            End Try
            If Me.txtReportTitle.Text = "" Then
                If Me.ddlFormat.SelectedValue = "1" Then
                    Me.txtReportTitle.Text = "Schedule by Task"
                Else
                    Me.txtReportTitle.Text = "Completed Task Report"
                End If
            End If

            Try
                'Show Fields
                s = oAppVars.getAppVar("chkManager")
                If s <> "" Then
                    Me.chkManager.Checked = s
                End If
                s = oAppVars.getAppVar("chkProjectDate")
                If s <> "" Then
                    Me.chkProjectDate.Checked = s
                End If
                s = oAppVars.getAppVar("chkClientDesc")
                If s <> "" Then
                    Me.chkClientDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkClientCode")
                If s <> "" Then
                    Me.chkClientCode.Checked = s
                End If
                s = oAppVars.getAppVar("chkDivisionDesc")
                If s <> "" Then
                    Me.chkDivisionDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkDivisionCode")
                If s <> "" Then
                    Me.chkDivisionCode.Checked = s
                End If
                s = oAppVars.getAppVar("chkProductCode")
                If s <> "" Then
                    Me.chkProductCode.Checked = s
                End If
                s = oAppVars.getAppVar("chkProductDesc")
                If s <> "" Then
                    Me.chkProductDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobCompNum")
                If s <> "" Then
                    Me.chkJobCompNum.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobCompDesc")
                If s <> "" Then
                    Me.chkJobCompDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkClientReference")
                If s <> "" Then
                    Me.chkClientReference.Checked = s
                End If
                s = oAppVars.getAppVar("chkAccountExecutive")
                If s <> "" Then
                    Me.chkAccountExecutive.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobType")
                If s <> "" Then
                    Me.chkJobType.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobTypeDesc")
                If s <> "" Then
                    Me.chkJobTypeDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkRush")
                If s <> "" Then
                    Me.chkRush.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobMarkup")
                If s <> "" Then
                    Me.chkJobMarkup.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobNonBillFlag")
                If s <> "" Then
                    Me.chkJobNonBillFlag.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobDueDate1")
                If s <> "" Then
                    Me.chkJobDueDate1.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobDueDate2")
                If s <> "" Then
                    Me.chkJobDueDate2.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobStatus")
                If s <> "" Then
                    Me.chkJobStatus.Checked = s
                End If
                s = oAppVars.getAppVar("chkJobStatusFirst")
                If s <> "" Then
                    Me.chkJobStatusFirst.Checked = s
                End If
                s = oAppVars.getAppVar("chkComments")
                If s <> "" Then
                    Me.chkComments.Checked = s
                End If
                s = oAppVars.getAppVar("chkIncludeEmpAssign")
                If s <> "" Then
                    Me.chkIncludeEmpAssign.Checked = s
                End If
                s = oAppVars.getAppVar("chkIncludeTaskDesc")
                If s <> "" Then
                    Me.ChkIncludeTaskDesc.Checked = s
                End If
                s = oAppVars.getAppVar("chkMilestone")
                If s <> "" Then
                    Me.chkMilestone.Checked = s
                End If
                s = oAppVars.getAppVar("chkCompletedDate")
                If s <> "" Then
                    Me.chkCompletedDate.Checked = s
                End If
                s = oAppVars.getAppVar("CheckBoxPhase")
                If s <> "" Then
                    Me.CheckBoxPhase.Checked = s
                End If
                s = oAppVars.getAppVar("CheckBoxDateFormat")
                If s <> "" Then
                    Me.CheckBoxDateFormat.Checked = s
                End If
                'Me.chkManager.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkManager.ID)
                'Me.chkProjectDate.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkProjectDate.ID)
                'Me.chkJobDueDate1.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobDueDate1.ID)
                'Me.chkCompletedDate.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkCompletedDate.ID)
                'Me.chkClientDesc.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkClientDesc.ID)
                'Me.chkClientCode.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkClientCode.ID)
                'Me.chkDivisionDesc.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkDivisionDesc.ID)
                'Me.chkDivisionCode.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkDivisionCode.ID)
                'Me.chkProductCode.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkProductCode.ID)
                'Me.chkProductDesc.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkProductDesc.ID)
                'Me.chkJobCompNum.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobCompNum.ID)
                'Me.chkJobCompDesc.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobCompDesc.ID)
                'Me.chkClientReference.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkClientReference.ID)
                'Me.chkAccountExecutive.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkAccountExecutive.ID)
                'Me.chkJobType.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobType.ID)
                'Me.chkJobTypeDesc.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobTypeDesc.ID)
                'Me.chkRush.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkRush.ID)
                'Me.chkJobMarkup.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobMarkup.ID)
                'Me.chkJobNonBillFlag.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobNonBillFlag.ID)
                'Me.chkJobDueDate2.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobDueDate2.ID)
                'Me.chkJobStatus.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkJobStatus.ID)
                'Me.chkComments.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkComments.ID)

                'Me.chkIncludeEmpAssign.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkIncludeEmpAssign.ID)
                'Me.ChkIncludeTaskDesc.Checked = Request.Cookies("rpttrafficschedulesa")(Me.ChkIncludeTaskDesc.ID)

                'Me.chkMilestone.Checked = Request.Cookies("rpttrafficschedulesa")(Me.chkMilestone.ID)   'Milestone Tasks Only

                'Sort Options
                s = oAppVars.getAppVar("ddSort1")
                If s <> "" Then
                    Me.ddSort1.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddSort2")
                If s <> "" Then
                    Me.ddSort2.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddSort1Direction")
                If s <> "" Then
                    Me.ddSort1Direction.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddSort2Direction")
                If s <> "" Then
                    Me.ddSort2Direction.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddManager")
                If s <> "" Then
                    Me.ddManager.SelectedValue = s
                End If
                'Me.ddSort1.SelectedValue = Request.Cookies("rpttrafficschedulesa")("ddSort1")
                'Me.ddSort2.SelectedValue = Request.Cookies("rpttrafficschedulesa")("ddSort2")
                'Me.ddSort1Direction.SelectedValue = Request.Cookies("rpttrafficschedulesa")("ddSort1Direction")
                'Me.ddSort2Direction.SelectedValue = Request.Cookies("rpttrafficschedulesa")("ddSort2Direction")
                'Me.ddManager.SelectedValue = Request.Cookies("rpttrafficschedulesa")("ddManager")
                '.setAppVar("rblDates", Me.rblDates.Items(k).Text)
                Dim k As Integer
                s = oAppVars.getAppVar("rblDates")
                If s <> "" Then
                    For k = 0 To Me.rblDates.Items.Count - 1
                        If Me.rblDates.Items(k).Text = s Then
                            Me.rblDates.Items(k).Selected = True
                        End If
                    Next
                End If

                If rblDates.Items.FindByValue("dueorcomp").Selected = True Then
                    Me.CheckBoxDateFormat.Enabled = True
                Else
                    Me.CheckBoxDateFormat.Checked = False
                    Me.CheckBoxDateFormat.Enabled = False
                End If

                'Dim str As String = Request.Cookies("rpttrafficschedulesa")(Me.rblDates.ID)

                'For k = 0 To Me.rblDates.Items.Count - 1
                '    If Me.rblDates.Items(k).Text = str Then
                '        Me.rblDates.Items(k).Selected = True
                '    End If
                'Next
            Catch ex As Exception
            End Try



            Try
                'Task Option
                s = oAppVars.getAppVar("ddTaskTemplate")
                If s <> "" Then
                    Me.ddTaskTemplate.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask1")
                If oAppVars.HasAppVar("ddTask1") Then
                    Me.ddTask1.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask2")
                If oAppVars.HasAppVar("ddTask2") Then
                    Me.ddTask2.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask3")
                If oAppVars.HasAppVar("ddTask3") Then
                    Me.ddTask3.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask4")
                If oAppVars.HasAppVar("ddTask4") Then
                    Me.ddTask4.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask5")
                If oAppVars.HasAppVar("ddTask5") Then
                    Me.ddTask5.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask6")
                If oAppVars.HasAppVar("ddTask6") Then
                    Me.ddTask6.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask7")
                If oAppVars.HasAppVar("ddTask7") Then
                    Me.ddTask7.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask8")
                If oAppVars.HasAppVar("ddTask8") Then
                    Me.ddTask8.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask9")
                If oAppVars.HasAppVar("ddTask9") Then
                    Me.ddTask9.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask10")
                If oAppVars.HasAppVar("ddTask10") Then
                    Me.ddTask10.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask11")
                If oAppVars.HasAppVar("ddTask11") Then
                    Me.ddTask11.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask12")
                If oAppVars.HasAppVar("ddTask12") Then
                    Me.ddTask12.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask13")
                If oAppVars.HasAppVar("ddTask13") Then
                    Me.ddTask13.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask14")
                If oAppVars.HasAppVar("ddTask14") Then
                    Me.ddTask14.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask15")
                If oAppVars.HasAppVar("ddTask15") Then
                    Me.ddTask15.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask16")
                If oAppVars.HasAppVar("ddTask16") Then
                    Me.ddTask16.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask17")
                If oAppVars.HasAppVar("ddTask17") Then
                    Me.ddTask17.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask18")
                If oAppVars.HasAppVar("ddTask18") Then
                    Me.ddTask18.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask19")
                If oAppVars.HasAppVar("ddTask19") Then
                    Me.ddTask19.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask20")
                If oAppVars.HasAppVar("ddTask20") Then
                    Me.ddTask20.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask21")
                If oAppVars.HasAppVar("ddTask21") Then
                    Me.ddTask21.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask22")
                If oAppVars.HasAppVar("ddTask22") Then
                    Me.ddTask22.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask23")
                If oAppVars.HasAppVar("ddTask23") Then
                    Me.ddTask23.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask24")
                If oAppVars.HasAppVar("ddTask24") Then
                    Me.ddTask24.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask25")
                If oAppVars.HasAppVar("ddTask25") Then
                    Me.ddTask25.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask26")
                If oAppVars.HasAppVar("ddTask26") Then
                    Me.ddTask26.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask27")
                If oAppVars.HasAppVar("ddTask27") Then
                    Me.ddTask27.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask28")
                If oAppVars.HasAppVar("ddTask28") Then
                    Me.ddTask28.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask29")
                If oAppVars.HasAppVar("ddTask29") Then
                    Me.ddTask29.SelectedValue = s
                End If
                s = oAppVars.getAppVar("ddTask30")
                If oAppVars.HasAppVar("ddTask30") Then
                    Me.ddTask30.SelectedValue = s
                End If
                'Me.ddTask1.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task1")
                'Me.ddTask2.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task2")
                'Me.ddTask3.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task3")
                'Me.ddTask4.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task4")
                'Me.ddTask5.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task5")
                'Me.ddTask6.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task6")
                'Me.ddTask7.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task7")
                'Me.ddTask8.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task8")
                'Me.ddTask9.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task9")
                'Me.ddTask10.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task10")
                'Me.ddTask11.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task11")
                'Me.ddTask12.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task12")
                'Me.ddTask13.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task13")
                'Me.ddTask14.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task14")
                'Me.ddTask15.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task15")
                'Me.ddTask16.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task16")
                'Me.ddTask17.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task17")
                'Me.ddTask18.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task18")
                'Me.ddTask19.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task19")
                'Me.ddTask20.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task20")
                'Me.ddTask21.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task21")
                'Me.ddTask22.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task22")
                'Me.ddTask23.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task23")
                'Me.ddTask24.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task24")
                'Me.ddTask25.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task25")
                'Me.ddTask26.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task26")
                'Me.ddTask27.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task27")
                'Me.ddTask28.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task28")
                'Me.ddTask29.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task29")
                'Me.ddTask30.SelectedValue = Request.Cookies("rpttrafficschedulesa")("Task30")
            Catch

            End Try
        End If



    End Sub
    Private Sub LoadTaskDropDowns()
        Dim dsTasks As DataSet
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        'Get Task DataSet
        dsTasks = odd.GetTaskDescriptions

        Dim dsRow As DataRow
        dsRow = dsTasks.Tables(0).NewRow
        dsRow.Item(0) = ""
        dsRow.Item(1) = "None"
        dsTasks.Tables(0).Rows.InsertAt(dsRow, 0)

        Me.ddTask1.DataSource = dsTasks
        Me.ddTask1.DataTextField = "description"
        Me.ddTask1.DataValueField = "code"
        Me.ddTask1.DataBind()

        Me.ddTask2.DataSource = dsTasks
        Me.ddTask2.DataTextField = "description"
        Me.ddTask2.DataValueField = "code"
        Me.ddTask2.DataBind()

        Me.ddTask3.DataSource = dsTasks
        Me.ddTask3.DataTextField = "description"
        Me.ddTask3.DataValueField = "code"
        Me.ddTask3.DataBind()

        Me.ddTask4.DataSource = dsTasks
        Me.ddTask4.DataTextField = "description"
        Me.ddTask4.DataValueField = "code"
        Me.ddTask4.DataBind()

        Me.ddTask5.DataSource = dsTasks
        Me.ddTask5.DataTextField = "description"
        Me.ddTask5.DataValueField = "code"
        Me.ddTask5.DataBind()

        Me.ddTask6.DataSource = dsTasks
        Me.ddTask6.DataTextField = "description"
        Me.ddTask6.DataValueField = "code"
        Me.ddTask6.DataBind()

        Me.ddTask7.DataSource = dsTasks
        Me.ddTask7.DataTextField = "description"
        Me.ddTask7.DataValueField = "code"
        Me.ddTask7.DataBind()

        Me.ddTask8.DataSource = dsTasks
        Me.ddTask8.DataTextField = "description"
        Me.ddTask8.DataValueField = "code"
        Me.ddTask8.DataBind()

        Me.ddTask9.DataSource = dsTasks
        Me.ddTask9.DataTextField = "description"
        Me.ddTask9.DataValueField = "code"
        Me.ddTask9.DataBind()

        Me.ddTask10.DataSource = dsTasks
        Me.ddTask10.DataTextField = "description"
        Me.ddTask10.DataValueField = "code"
        Me.ddTask10.DataBind()

        Me.ddTask11.DataSource = dsTasks
        Me.ddTask11.DataTextField = "description"
        Me.ddTask11.DataValueField = "code"
        Me.ddTask11.DataBind()

        Me.ddTask12.DataSource = dsTasks
        Me.ddTask12.DataTextField = "description"
        Me.ddTask12.DataValueField = "code"
        Me.ddTask12.DataBind()

        Me.ddTask13.DataSource = dsTasks
        Me.ddTask13.DataTextField = "description"
        Me.ddTask13.DataValueField = "code"
        Me.ddTask13.DataBind()

        Me.ddTask14.DataSource = dsTasks
        Me.ddTask14.DataTextField = "description"
        Me.ddTask14.DataValueField = "code"
        Me.ddTask14.DataBind()

        Me.ddTask15.DataSource = dsTasks
        Me.ddTask15.DataTextField = "description"
        Me.ddTask15.DataValueField = "code"
        Me.ddTask15.DataBind()

        Me.ddTask16.DataSource = dsTasks
        Me.ddTask16.DataTextField = "description"
        Me.ddTask16.DataValueField = "code"
        Me.ddTask16.DataBind()

        Me.ddTask17.DataSource = dsTasks
        Me.ddTask17.DataTextField = "description"
        Me.ddTask17.DataValueField = "code"
        Me.ddTask17.DataBind()

        Me.ddTask18.DataSource = dsTasks
        Me.ddTask18.DataTextField = "description"
        Me.ddTask18.DataValueField = "code"
        Me.ddTask18.DataBind()

        Me.ddTask19.DataSource = dsTasks
        Me.ddTask19.DataTextField = "description"
        Me.ddTask19.DataValueField = "code"
        Me.ddTask19.DataBind()

        Me.ddTask20.DataSource = dsTasks
        Me.ddTask20.DataTextField = "description"
        Me.ddTask20.DataValueField = "code"
        Me.ddTask20.DataBind()

        Me.ddTask21.DataSource = dsTasks
        Me.ddTask21.DataTextField = "description"
        Me.ddTask21.DataValueField = "code"
        Me.ddTask21.DataBind()

        Me.ddTask22.DataSource = dsTasks
        Me.ddTask22.DataTextField = "description"
        Me.ddTask22.DataValueField = "code"
        Me.ddTask22.DataBind()

        Me.ddTask23.DataSource = dsTasks
        Me.ddTask23.DataTextField = "description"
        Me.ddTask23.DataValueField = "code"
        Me.ddTask23.DataBind()

        Me.ddTask24.DataSource = dsTasks
        Me.ddTask24.DataTextField = "description"
        Me.ddTask24.DataValueField = "code"
        Me.ddTask24.DataBind()

        Me.ddTask25.DataSource = dsTasks
        Me.ddTask25.DataTextField = "description"
        Me.ddTask25.DataValueField = "code"
        Me.ddTask25.DataBind()

        Me.ddTask26.DataSource = dsTasks
        Me.ddTask26.DataTextField = "description"
        Me.ddTask26.DataValueField = "code"
        Me.ddTask26.DataBind()

        Me.ddTask27.DataSource = dsTasks
        Me.ddTask27.DataTextField = "description"
        Me.ddTask27.DataValueField = "code"
        Me.ddTask27.DataBind()

        Me.ddTask28.DataSource = dsTasks
        Me.ddTask28.DataTextField = "description"
        Me.ddTask28.DataValueField = "code"
        Me.ddTask28.DataBind()

        Me.ddTask29.DataSource = dsTasks
        Me.ddTask29.DataTextField = "description"
        Me.ddTask29.DataValueField = "code"
        Me.ddTask29.DataBind()

        Me.ddTask30.DataSource = dsTasks
        Me.ddTask30.DataTextField = "description"
        Me.ddTask30.DataValueField = "code"
        Me.ddTask30.DataBind()

    End Sub
    Private Sub LoadTasks()
        Try
            Dim oReports As New cReports(Session("ConnString"))
            Dim dt As DataTable
            Dim i As Integer
            Dim dd As Telerik.Web.UI.RadComboBox
            Me.LoadTaskDropDowns()
            If Me.ddTaskTemplate.SelectedValue <> "NoTasks" Then
                dt = oReports.GetTasks(Me.ddTaskTemplate.SelectedValue, Me.chkMilestone.Checked)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        If i = 0 Then
                            Me.ddTask1.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 1 Then
                            Me.ddTask2.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 2 Then
                            Me.ddTask3.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 3 Then
                            Me.ddTask4.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 4 Then
                            Me.ddTask5.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 5 Then
                            Me.ddTask6.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 6 Then
                            Me.ddTask7.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 7 Then
                            Me.ddTask8.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 8 Then
                            Me.ddTask9.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 9 Then
                            Me.ddTask10.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 10 Then
                            Me.ddTask11.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 11 Then
                            Me.ddTask12.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 12 Then
                            Me.ddTask13.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 13 Then
                            Me.ddTask14.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 14 Then
                            Me.ddTask15.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 15 Then
                            Me.ddTask16.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 16 Then
                            Me.ddTask17.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 17 Then
                            Me.ddTask18.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 18 Then
                            Me.ddTask19.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 19 Then
                            Me.ddTask20.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 20 Then
                            Me.ddTask21.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 21 Then
                            Me.ddTask22.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 22 Then
                            Me.ddTask23.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 23 Then
                            Me.ddTask24.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 24 Then
                            Me.ddTask25.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 25 Then
                            Me.ddTask26.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 26 Then
                            Me.ddTask27.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 27 Then
                            Me.ddTask28.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 28 Then
                            Me.ddTask29.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                        If i = 29 Then
                            Me.ddTask30.SelectedValue = dt.Rows(i)("FNC_CODE")
                        End If
                    Next
                Else
                    Me.LoadTaskDropDowns()
                End If
            End If


        Catch ex As Exception
            Me.lblMSG.Text = "ERROR"
        End Try
    End Sub
    Private Sub cmdNoTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LoadDropDowns()
        Me.LoadTaskDropDowns()
    End Sub

    'Private Sub lstClients_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstClients.SelectedIndexChanged
    '    If Me.rdlClients.Items(0).Selected = True Then
    '        Me.rdlClients.Items(0).Selected = False
    '        Me.rdlClients.Items(1).Selected = True
    '    End If
    'End Sub

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
    Private Sub rdlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlStatus.SelectedIndexChanged
        Dim i As Integer
        If Me.rdlStatus.Items(0).Selected = True Then
            For i = 0 To Me.lbStatus.Items.Count - 1
                If Me.lbStatus.Items(i).Selected = True Then
                    Me.lbStatus.Items(i).Selected = False
                End If
            Next
            lbStatus.Enabled = False
        Else
            lbStatus.Enabled = True
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
            Me.lstAEs.Enabled = False
        Else
            Me.lstAEs.Enabled = True
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

    'Private Sub rdlEmpRole_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlEmpRole.SelectedIndexChanged
    '    Try
    '        If rdlEmpRole.Items(0).Selected Then
    '            Me.CheckBoxIncludeEmpRole.Enabled = False
    '            Me.ddSort1.Items.Remove(New Telerik.Web.UI.RadComboBoxItem("Employee Role", "EmpRole"))
    '            Me.ddSort2.Items.Remove(New Telerik.Web.UI.RadComboBoxItem("Employee", "EmpCode"))
    '        Else
    '            Me.CheckBoxIncludeEmpRole.Enabled = True
    '            Me.ddSort1.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Employee Role", "EmpRole"))
    '            Me.ddSort2.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Employee", "EmpCode"))
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub rdlEmployees_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlEmployees.SelectedIndexChanged
        Try
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
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub lbOffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbOffices.SelectedIndexChanged
    '    If Me.rblOffices.Items(0).Selected = True Then
    '        Me.rblOffices.Items(0).Selected = False
    '        Me.rblOffices.Items(1).Selected = True
    '    End If
    'End Sub

    Private Sub chkClosedJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkClosedJobs.CheckedChanged
        If Me.chkClosedJobs.Checked = True Then
            Me.RadDatePickerStartDateClosed.CssClass = "RequiredInput"
            Me.RadDatePickerEndDateClosed.CssClass = "RequiredInput"
        Else
            Me.RadDatePickerStartDateClosed.CssClass = Nothing
            Me.RadDatePickerEndDateClosed.CssClass = Nothing
        End If
    End Sub

    Private Sub chkForJobDueDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkForJobDueDate.CheckedChanged
        If Me.chkForJobDueDate.Checked = True Then
            Me.RadDatePickerStartDate.CssClass = "RequiredInput"
            Me.RadDatePickerEndDate.CssClass = "RequiredInput"
        Else
            Me.RadDatePickerStartDate.CssClass = Nothing
            Me.RadDatePickerEndDate.CssClass = Nothing
        End If
    End Sub

    Private Sub chkAllQualifiedJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllQualifiedJobs.CheckedChanged
        If Me.chkForJobDueDate.Checked = True Then
            Me.RadDatePickerStartDate.CssClass = "RequiredInput"
            Me.RadDatePickerEndDate.CssClass = "RequiredInput"
        Else
            Me.RadDatePickerStartDate.CssClass = Nothing
            Me.RadDatePickerEndDate.CssClass = Nothing
        End If
    End Sub

    Private Sub imgbtnTasks_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnTasks.Click
        Me.LoadTasks()
        Me.ddTask30.Focus()
    End Sub



    Private Sub ddlFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFormat.SelectedIndexChanged
        Try
            If Me.ddlFormat.SelectedValue = "2" Then
                Me.rblDates.Enabled = True
                Me.chkManager.Checked = False
                Me.chkManager.Enabled = False
                Me.chkProjectDate.Checked = False
                Me.chkProjectDate.Enabled = False
                Me.chkJobDueDate1.Checked = False
                Me.chkJobDueDate1.Enabled = False
                Me.chkCompletedDate.Checked = False
                Me.chkCompletedDate.Enabled = False
                Me.chkClientCode.Checked = False
                Me.chkClientCode.Enabled = False
                Me.chkClientDesc.Checked = False
                Me.chkClientDesc.Enabled = False
                Me.chkDivisionCode.Checked = False
                Me.chkDivisionCode.Enabled = False
                Me.chkDivisionDesc.Checked = False
                Me.chkDivisionDesc.Enabled = False
                Me.chkProductCode.Checked = False
                Me.chkProductCode.Enabled = False
                Me.chkProductDesc.Checked = False
                Me.chkProductDesc.Enabled = False
                Me.chkJobCompNum.Checked = False
                Me.chkJobCompNum.Enabled = False
                Me.chkJobCompDesc.Checked = False
                Me.chkJobCompDesc.Enabled = False
                Me.chkClientReference.Checked = False
                Me.chkClientReference.Enabled = False
                Me.chkAccountExecutive.Checked = False
                Me.chkAccountExecutive.Enabled = False
                Me.chkJobType.Checked = False
                Me.chkJobType.Enabled = False
                Me.chkJobTypeDesc.Checked = False
                Me.chkJobTypeDesc.Enabled = False
                Me.chkRush.Checked = False
                Me.chkRush.Enabled = False
                Me.chkJobMarkup.Checked = False
                Me.chkJobMarkup.Enabled = False
                Me.chkJobNonBillFlag.Checked = False
                Me.chkJobNonBillFlag.Enabled = False
                Me.chkJobDueDate2.Checked = False
                Me.chkJobDueDate2.Enabled = False
                Me.chkJobStatus.Checked = False
                Me.chkJobStatus.Enabled = False
                Me.chkComments.Checked = False
                Me.chkComments.Enabled = False
                Me.chkIncludeEmpAssign.Checked = False
                Me.chkIncludeEmpAssign.Enabled = False
                Me.ChkIncludeTaskDesc.Checked = False
                Me.ChkIncludeTaskDesc.Enabled = False
                Me.chkNoTasksSummaryOnly.Checked = False
                Me.chkNoTasksSummaryOnly.Enabled = False
                Me.CheckBoxPhase.Checked = False
                Me.CheckBoxPhase.Enabled = False
                Me.CheckBoxDateFormat.Checked = False
                Me.CheckBoxDateFormat.Enabled = False
                For i As Integer = 0 To Me.rblDates.Items.Count - 1
                    If rblDates.Items(i).Value <> "origcomp" And rblDates.Items(i).Value <> "duecomp" Then
                        Me.rblDates.Items(i).Enabled = False
                    End If
                    If rblDates.Items(i).Value = "origcomp" Then
                        Me.rblDates.Items(i).Selected = True
                    End If
                Next
                Me.pnlFormat.Visible = False

                Try
                    Dim rptTitleID As String = Me.txtReportTitle.ID & Me.ddlFormat.SelectedValue
                    Dim cApp As New cAppVars(cAppVars.Application.TASK_RPT)
                    cApp.getAllAppVars()
                    Me.txtReportTitle.Text = cApp.getAppVar(rptTitleID)

                Catch ex As Exception
                    Me.txtReportTitle.Text = "Completed Task Report"
                End Try
                If Me.txtReportTitle.Text = "" Then
                    Me.txtReportTitle.Text = "Completed Task Report"
                End If
                Me.ddSort1.Enabled = True
                Me.ddSort2.Enabled = True
                If Me.ddSort1.Items.Contains(Me.ddSort1.FindItemByText("Employee Role")) = True Then
                    Me.ddSort1.Items.Remove(Me.ddSort1.FindItemByText("Employee Role"))
                End If
                If Me.ddSort2.Items.Contains(Me.ddSort2.FindItemByText("Employee")) = True Then
                    Me.ddSort2.Items.Remove(Me.ddSort2.FindItemByText("Employee"))
                End If
                Me.rdlEmployees.Enabled = False
                Me.lstEmployees.Enabled = False
            ElseIf Me.ddlFormat.SelectedValue = "3" Then
                Me.rdlEmployees.Enabled = True
                Me.chkJobCompNum.Enabled = False
                Me.chkJobCompDesc.Enabled = False
                Me.chkManager.Enabled = True
                Me.chkProjectDate.Enabled = True
                Me.chkJobDueDate1.Enabled = True
                Me.chkCompletedDate.Enabled = True
                Me.chkClientCode.Enabled = True
                Me.chkClientDesc.Enabled = True
                Me.chkDivisionCode.Enabled = True
                Me.chkDivisionDesc.Enabled = True
                Me.chkProductCode.Enabled = True
                Me.chkProductDesc.Enabled = True
                Me.chkJobCompNum.Enabled = True
                Me.chkJobCompDesc.Enabled = True
                Me.chkClientReference.Enabled = True
                Me.chkAccountExecutive.Enabled = True
                Me.chkJobType.Enabled = True
                Me.chkJobTypeDesc.Enabled = True
                Me.chkRush.Enabled = True
                Me.chkJobMarkup.Enabled = True
                Me.chkJobNonBillFlag.Enabled = True
                Me.chkJobDueDate2.Enabled = True
                Me.chkJobStatus.Enabled = True
                Me.chkComments.Enabled = True
                Me.ddSort1.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Employee Role", "EmpRole"))
                Me.ddSort2.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Employee", "Employee"))
                'Me.ddSort1.Items.FindByValue("EmpRole").Selected = True
                'Me.ddSort2.Items.FindByValue("EmpCode").Selected = True
                ddSort1.Items.FindItemByValue("EmpRole").Selected = True
                ddSort2.Items.FindItemByValue("Employee").Selected = True
                Me.ddSort1.Enabled = False
                Me.ddSort2.Enabled = False
                For i As Integer = 0 To Me.rblDates.Items.Count - 1
                    Me.rblDates.Items(i).Enabled = True
                    Me.rblDates.Items(i).Selected = False
                    If rblDates.Items(i).Value = "origdue" Then
                        Me.rblDates.Items(i).Selected = True
                    End If
                Next
                Me.rblDates.Enabled = False
                Me.txtReportTitle.Text = "Schedule by Role"
                Me.chkIncludeEmpAssign.Enabled = False
                Me.ChkIncludeTaskDesc.Enabled = False
                Me.CheckBoxPhase.Enabled = False
                Me.pnlFormat.Visible = True
                LoadSettings()
            Else
                Me.ddSort1.Enabled = True
                Me.ddSort2.Enabled = True
                Me.rblDates.Enabled = True
                If Me.ddSort1.Items.Contains(Me.ddSort1.FindItemByText("Employee Role")) = True Then
                    Me.ddSort1.Items.Remove(Me.ddSort1.FindItemByText("Employee Role"))
                End If
                If Me.ddSort2.Items.Contains(Me.ddSort2.FindItemByText("Employee")) = True Then
                    Me.ddSort2.Items.Remove(Me.ddSort2.FindItemByText("Employee"))
                End If
                Me.rdlEmployees.Enabled = False
                Me.lstEmployees.Enabled = False
                Me.chkManager.Enabled = True
                Me.chkProjectDate.Enabled = True
                Me.chkJobDueDate1.Enabled = True
                Me.chkCompletedDate.Enabled = True
                Me.chkClientCode.Enabled = True
                Me.chkClientDesc.Enabled = True
                Me.chkDivisionCode.Enabled = True
                Me.chkDivisionDesc.Enabled = True
                Me.chkProductCode.Enabled = True
                Me.chkProductDesc.Enabled = True
                Me.chkJobCompNum.Enabled = True
                Me.chkJobCompDesc.Enabled = True
                Me.chkClientReference.Enabled = True
                Me.chkAccountExecutive.Enabled = True
                Me.chkJobType.Enabled = True
                Me.chkJobTypeDesc.Enabled = True
                Me.chkRush.Enabled = True
                Me.chkJobMarkup.Enabled = True
                Me.chkJobNonBillFlag.Enabled = True
                Me.chkJobDueDate2.Enabled = True
                Me.chkJobStatus.Enabled = True
                Me.chkComments.Enabled = True
                Me.chkIncludeEmpAssign.Enabled = True
                Me.CheckBoxPhase.Enabled = True
                Me.ChkIncludeTaskDesc.Enabled = True
                Me.chkNoTasksSummaryOnly.Checked = True
                Me.chkNoTasksSummaryOnly.Enabled = True
                For i As Integer = 0 To Me.rblDates.Items.Count - 1
                    Me.rblDates.Items(i).Enabled = True
                Next
                Me.pnlFormat.Visible = True
                LoadSettings()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rblDates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblDates.SelectedIndexChanged
        Try

            If rblDates.Items.FindByValue("dueorcomp").Selected = True Then
                'Me.CheckBoxDateFormat.Checked = False
                Me.CheckBoxDateFormat.Enabled = True
            Else
                Me.CheckBoxDateFormat.Checked = False
                Me.CheckBoxDateFormat.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
