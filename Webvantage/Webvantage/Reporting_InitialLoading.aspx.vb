Public Class Reporting_InitialLoading
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DynamicReportType As Integer = -1
    Protected _DynamicReportTemplateID As Integer = 0
    Private _UserDefinedReportID As Integer = 0

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

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectIndirectTimeInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectTime Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectTimeInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectIndirectTimeInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectTimeInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailBillMonthInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailFunctionInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailItemInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobProjectScheduleSummaryInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobSummary Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobSummaryInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectHoursUsedInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectScheduleInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSummary Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectSummaryInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectSummaryTaskInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.CRMOpportunityDetailInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.CRMOpportunityToInvestmentInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.CRMClientContractsInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobPurchaseOrderInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.AuthorizationToBuyInitialCriteria), False, True)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.EmployeeTimeApprovalCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DigitalResultsCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ServiceFeeContract Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobServiceFeeCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.IncomeOnly Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.IncomeOnlyCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ExpenseCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.VendorContracts Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.VendorContractsInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.TimeReportInitialCriteria), False)

            ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectScheduleTasksByEmployeeInitialCriteria), False)

            Else

                Me.CloseThisWindow()

            End If

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                    _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                    _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                    _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                    _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                CheckBoxShowJobsWithNoDetails.Visible = True

            Else

                CheckBoxShowJobsWithNoDetails.Visible = False

            End If

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                            _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                            _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                            _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.VendorContracts Then

                tdFrom.InnerText = "After:"
                trTo.Visible = False
                RadButton1Year.Visible = False
                RadButton2Years.Visible = False
                RadButtonMTD.Visible = False
                RadButtonYTD.Visible = False

            End If

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval Then

                CheckBoxShowJobsWithNoDetails.Visible = False

            End If

            RadComboBoxCriteria.DataBind()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Session("DRPT_Criteria") = CInt(RadComboBoxCriteria.SelectedValue)
                Session("DRPT_FilterString") = AdvantageFramework.Reporting.CreateFilterStringForDynamicReport(_DynamicReportType, CInt(RadComboBoxCriteria.SelectedValue))
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = RadDatePickerFrom.SelectedDate
                Session("DRPT_To") = RadDatePickerTo.SelectedDate
                Session("DRPT_ShowJobsWithNoDetails") = CheckBoxShowJobsWithNoDetails.Checked
                Session("DRPT_ParameterDictionary") = Nothing

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

                'Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

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

#End Region

#End Region

End Class
