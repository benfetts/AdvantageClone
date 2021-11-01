Imports System.Data
Imports System.Data.SqlClient

Partial Public Class DesktopOfficeStatisticsV
    Inherits Webvantage.BaseDesktopObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.butExport.Attributes.Add("onclick", "window.open('dtp_statistics.aspx?export=1&DO=officeV', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
            If Not Me.IsPostBack Then
                Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfMonth()
                Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfMonth()
                LoadDropDowns()
                Dim s As New cSchedule()
                Me.LabelManager.Text = s.GetManagerLabel() & ":"

            End If
            If Me.DropTrafficFunctions.Items.Count <= 0 Then
                LoadTrafficStatus()
            End If
            If Not Me.IsPostBack Then
                LoadSelections()

            End If
            LoadGrid()
            'Me.JobStatsRadGrid.Skin = MiscFN.SetRadGridSkin
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadGrid()

        Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim sDate As Date = Nothing
        Dim eDate As Date = Nothing
        Dim ds As DataTable
        If Me.RadDatePickerStartDate.SelectedDate = Nothing Then
            sDate = LoGlo.FirstOfMonth()
            Me.RadDatePickerStartDate.SelectedDate = sDate
            Me.RadDatePickerStartDate.DateInput.Text = LoGlo.FormatDate(sDate)
        Else
            sDate = Me.RadDatePickerStartDate.SelectedDate
        End If
        If Me.RadDatePickerEndDate.SelectedDate = Nothing Then
            eDate = LoGlo.LastOfMonth()
            Me.RadDatePickerEndDate.SelectedDate = eDate
            Me.RadDatePickerEndDate.DateInput.Text = LoGlo.FormatDate(eDate)
        Else
            eDate = Me.RadDatePickerEndDate.SelectedDate
        End If
        If Me.IsClientPortal = True Then
            'ds = oDTO.GetJobStatisticsCP(Session("UserID"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, Me.ddEmployee.SelectedValue, Me.ddManager.SelectedValue)
        Else
            ds = oDTO.GetOfficeStatistics(Session("UserCode"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, Me.ddEmployee.SelectedValue, Me.ddManager.SelectedValue)
        End If
        Dim i As Integer
        For i = 0 To ds.Rows.Count - 1
            If i > ds.Rows.Count - 1 Then
                Exit For
            End If
            If ds.Rows(i)(2).ToString() = "0" And ds.Rows(i)(3).ToString() = "0" And ds.Rows(i)(4).ToString() = "0" And ds.Rows(i)(5).ToString() = "0" And ds.Rows(i)(6).ToString() = "0" Then
                ds.Rows.Remove(ds.Rows(i))
                i = -1
            End If
        Next
        Me.JobStatsRadGrid.DataSource = ds
        Me.JobStatsRadGrid.DataBind()

        If Me.DropTrafficFunctions.SelectedIndex > 0 And Me.ChkIsClosedStatus.Checked = False Then
            Me.JobStatsRadGrid.MasterTableView.GetColumn("colCancelled").HeaderText = "Status<br />(" & Me.DropTrafficFunctions.SelectedValue.ToString() & ")"
            'Me.RadGridJobStats.MasterTableView.GetColumn("colCancelled").HeaderText = Me.DropTrafficFunctions.SelectedItem.Text.ToString
        ElseIf Me.DropTrafficFunctions.SelectedIndex > 0 And Me.ChkIsClosedStatus.Checked = True Then
            Me.JobStatsRadGrid.MasterTableView.GetColumn("colCancelled").HeaderText = "Cancelled"
        End If

        If Me.DropTrafficFunctions.SelectedIndex = 0 Then
            Me.JobStatsRadGrid.MasterTableView.GetColumn("colCancelled").Display = False
        Else
            Me.JobStatsRadGrid.MasterTableView.GetColumn("colCancelled").Display = True
        End If
    End Sub

    Private Sub LoadTrafficStatus()
        Try
            Me.DropTrafficFunctions.Items.Add(New Telerik.Web.UI.RadComboBoxItem("[Select A Status]", "none"))
            Dim od As Webvantage.cDropDowns = New Webvantage.cDropDowns(Session("ConnString"))
            Dim dr As SqlDataReader
            dr = od.GetTrafficCodes
            If dr.HasRows Then
                Do While dr.Read
                    Me.DropTrafficFunctions.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dr(1).ToString(), dr(0).ToString()))
                Loop
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadDropDowns()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ddEmployee
            .DataSource = oDD.GetAccountExecs(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

        With Me.ddManager
            .DataSource = oDD.GetManagers(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

    End Sub

    Public Sub LoadSelections()
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sEmployee")
            If taskVar <> "" Then
                Me.ddEmployee.SelectedValue = taskVar
            Else
                Me.ddEmployee.SelectedValue = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sDropTrafficFunctions")
            If taskVar <> "" Then
                Me.DropTrafficFunctions.SelectedValue = taskVar
            Else
                Me.DropTrafficFunctions.SelectedValue = "none"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sChkClosedStatus")
            If taskVar <> "" Then
                Me.ChkIsClosedStatus.Checked = taskVar
            Else
                Me.ChkIsClosedStatus.Checked = False
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sManager")
            If taskVar <> "" Then
                Me.ddManager.SelectedValue = taskVar
            Else
                Me.ddManager.SelectedValue = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sDateStart")
            If taskVar <> "" Then
                Me.RadDatePickerStartDate.SelectedDate = LoGlo.FormatDate(taskVar)
            Else
                Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfMonth()
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "OfficeStatisticsV", "sDateEnd")
            If taskVar <> "" Then
                Me.RadDatePickerEndDate.SelectedDate = LoGlo.FormatDate(taskVar)
            Else
                Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfMonth()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub butrefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butrefresh.Click
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sDropTrafficFunctions", "", Me.DropTrafficFunctions.SelectedValue)
            otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sChkClosedStatus", "", Me.ChkIsClosedStatus.Checked)
            otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sEmployee", "", Me.ddEmployee.SelectedValue)
            otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sManager", "", Me.ddManager.SelectedValue)
            otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sDateStart", "", Me.RadDatePickerStartDate.SelectedDate)
            otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sDateEnd", "", Me.RadDatePickerEndDate.SelectedDate)
            LoadGrid()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DropTrafficFunctions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropTrafficFunctions.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sDropTrafficFunctions", "", Me.DropTrafficFunctions.SelectedValue)
        LoadGrid()
    End Sub

    Private Sub ChkIsClosedStatus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkIsClosedStatus.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sChkClosedStatus", "", Me.ChkIsClosedStatus.Checked)
        LoadGrid()
    End Sub

    Private Sub ddEmployee_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddEmployee.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sEmployee", "", Me.ddEmployee.SelectedValue)
        LoadGrid()
    End Sub

    Private Sub ddManager_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddManager.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sManager", "", Me.ddManager.SelectedValue)
    End Sub

    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sDateStart", "", Me.RadDatePickerStartDate.SelectedDate)
        LoadGrid()
    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "OfficeStatisticsV", "sDateEnd", "", Me.RadDatePickerEndDate.SelectedDate)
        LoadGrid()
    End Sub

    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

End Class
