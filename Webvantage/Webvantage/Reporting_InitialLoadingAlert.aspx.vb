Public Class Reporting_InitialLoadingAlert
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

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Or _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments Or _UserDefinedReportID <> 0 Then

                Dim udr As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    udr = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, _UserDefinedReportID)
                End Using

                If udr IsNot Nothing Then
                    If udr.AdvancedReportWriterType = 11 Or udr.AdvancedReportWriterType = 12 Then
                        Me.CheckBoxIncludeDismissed.Enabled = True
                    End If
                Else
                    Me.CheckBoxIncludeDismissed.Enabled = True
                End If

            Else
                Me.CheckBoxIncludeDismissed.Enabled = False
                Me.CheckBoxIncludeDismissed.Checked = False
                Me.CheckBoxIncludeDismissed.Visible = False
            End If

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadDatePickerFrom.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.StartDate.ToString)

                Catch ex As Exception

                End Try

                Try

                    RadDatePickerTo.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.EndDate.ToString)

                Catch ex As Exception

                End Try

            End If

            'If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.Alerts OrElse
            '   _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments OrElse
            '   _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Then

            '    'RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ClientPLParameters), False)

            'Else

            '    Me.CloseThisWindow()

            'End If

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

                    _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.StartDate.ToString) = RadDatePickerFrom.SelectedDate
                    _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.EndDate.ToString) = RadDatePickerTo.SelectedDate

                    'If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Or _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments Then
                    _ParameterDictionary(AdvantageFramework.Reporting.AlertParameters.IncludeDismissed.ToString) = Me.CheckBoxIncludeDismissed.Checked
                    'End If

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

#End Region

#End Region

End Class
