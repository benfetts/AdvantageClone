﻿Imports Telerik.Web.UI

Public Class Reporting_InitialLoadingEmployeeUtilization
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DynamicReportType As Integer = -1
    Protected _DynamicReportTemplateID As Integer = 0
    Private _UserDefinedReportID As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

#End Region

#Region " Methods "

    Private Sub LoadDynamicReport()

        _DynamicReportType = Session("DRPT_Type")

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

    End Sub
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
            RadGridOffice.DataBind()

        End Using

    End Sub
    Private Sub LoadDepartments()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridDepartmentTeams.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                                 Select [Code] = Entity.Code,
                                                                               [Name] = Entity.Description).ToList

            RadGridDepartmentTeams.DataBind()

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

            Me.CheckBoxLimitWIP.Checked = True

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadDatePickerFrom.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.EstimateParameters.FromDate.ToString)

                Catch ex As Exception

                End Try

                Try

                    RadDatePickerTo.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.EstimateParameters.ToDate.ToString)

                Catch ex As Exception

                End Try

            End If

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeUtilization Then

                'RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ClientPLParameters), False)

            Else

                'Me.CloseThisWindow()

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Session("DRPT_ParameterDictionary") = Nothing

                If RadDatePickerFrom.SelectedDate <= RadDatePickerTo.SelectedDate Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.StartDate.ToString) = RadDatePickerFrom.SelectedDate
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.EndDate.ToString) = RadDatePickerTo.SelectedDate
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.UserID.ToString) = Session("UserCode")
                    If RadioButtonEmployee.Checked Then
                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.Groupby.ToString) = "emp"
                    ElseIf RadioButtonEmployeDate.Checked Then
                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.Groupby.ToString) = "empdate"
                    ElseIf RadioButtonEmployeePeriod.Checked Then
                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.Groupby.ToString) = "empperiod"
                    End If
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.LimitWIP.ToString) = CheckBoxLimitWIP.Checked

                    Dim OfficeCodesList As Generic.List(Of String) = Nothing
                    Dim DepartmentTeamList As Generic.List(Of String) = Nothing

                    If RadioButtonAllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString) = Nothing

                    Else

                        If RadGridOffice.Items.Count > 0 Then
                            OfficeCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString) = OfficeCodesList

                    End If

                    If RadioButtonAllDepartmentTeams.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString) = Nothing

                    Else

                        If RadGridDepartmentTeams.Items.Count > 0 Then
                            DepartmentTeamList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDepartmentTeams.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    DepartmentTeamList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString) = DepartmentTeamList

                    End If

                    Session("DRPT_Criteria") = Nothing
                    Session("DRPT_FilterString") = Nothing
                    Session("DRPT_UseBlankData") = False
                    Session("DRPT_DashboardLoaded") = False
                    Session("DRPT_From") = Nothing
                    Session("DRPT_To") = Nothing
                    Session("DRPT_ShowJobsWithNoDetails") = Nothing
                    Session("DRPT_ParameterDictionary") = _ParameterDictionary
                Else

                    Me.ShowMessage("Please select a starting post period that is before the ending post period.")

                End If

                If _UserDefinedReportID = 0 Then

                    If _DynamicReportTemplateID <> 0 Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    Else

                        Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                    End If

                Else

                    Session("UserDefinedReportID") = _UserDefinedReportID

                    Me.CloseThisWindowAndOpenNewWindow("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

                End If

            Case RadToolBarButtonCancel.Value

                'Session("DRPT_Criteria") = Nothing
                'Session("DRPT_FilterString") = Nothing
                'Session("DRPT_UseBlankData") = True
                'Session("DRPT_DashboardLoaded") = False
                'Session("DRPT_From") = Nothing
                'Session("DRPT_To") = Nothing
                'Session("DRPT_ShowJobsWithNoDetails") = Nothing
                'Session("DRPT_ParameterDictionary") = Nothing

                'If _DynamicReportTemplateID <> 0 Then

                '    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                'Else

                Me.CloseThisWindow()

                'End If

        End Select

    End Sub
    Private Sub RadButton1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1Year.Click

        RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-1)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButton2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2Years.Click

        RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-2)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click

        RadDatePickerFrom.SelectedDate = CDate(cEmployee.TimeZoneToday.Month & "/1/" & cEmployee.TimeZoneToday.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click

        RadDatePickerFrom.SelectedDate = CDate("1/1/" & cEmployee.TimeZoneToday.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadDatePickerFrom_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFrom.SelectedDateChanged

        RadDatePickerTo.MinDate = RadDatePickerFrom.SelectedDate

    End Sub
    Private Sub RadDatePickerTo_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerTo.SelectedDateChanged

        RadDatePickerFrom.MaxDate = RadDatePickerTo.SelectedDate

    End Sub

    Private Sub RadioButtonAllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllOffices.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonAllOffices.Checked Then

            RadGridOffice.Enabled = False
            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)
            RadGridOffice.DataBind()

        End If

        'End If

    End Sub
    Private Sub RadioButtonChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseOffices.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChooseOffices.Checked Then

            If RadGridOffice.Items.Count = 0 Then

                LoadOffices()

            End If

            RadGridOffice.Enabled = True

        End If

        'End If

    End Sub

    Private Sub RadioButtonAllDepartmentTeams_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllDepartmentTeams.CheckedChanged

        Me.RadGridDepartmentTeams.Rebind()

    End Sub

    Private Sub RadioButtonChooseDepartmentTeams_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonChooseDepartmentTeams.CheckedChanged
        If RadioButtonChooseDepartmentTeams.Checked Then

            If RadGridDepartmentTeams.Items.Count = 0 Then

                Me.RadGridDepartmentTeams.Rebind()

            End If

            RadGridDepartmentTeams.Enabled = True

        End If
    End Sub

    Private Sub RadGridDepartmentTeams_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridDepartmentTeams.NeedDataSource
        If RadioButtonAllDepartmentTeams.Checked Then

            RadGridDepartmentTeams.Enabled = False
            RadGridDepartmentTeams.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)

        Else


            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridDepartmentTeams.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                                     Select [Code] = Entity.Code,
                                                                                   [Name] = Entity.Description).ToList

            End Using

        End If
    End Sub

#End Region

#End Region

End Class
