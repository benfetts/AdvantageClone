Imports Telerik.Web.UI.Calendar

Public Class Reporting_InitialLoadingResourceAllocationByWeek
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
    Private Sub Loadweeks()
        Try
            Dim dt As DataTable
            dt = New DataTable
            dt.Columns.Add("Week")
            dt.Columns.Add("Value")

            Dim newrow As DataRow

            newrow = dt.NewRow
            newrow.Item("Week") = 1
            newrow.Item("Value") = 1
            dt.Rows.Add(newrow)

            newrow = dt.NewRow
            newrow.Item("Week") = 2
            newrow.Item("Value") = 2
            dt.Rows.Add(newrow)

            newrow = dt.NewRow
            newrow.Item("Week") = 3
            newrow.Item("Value") = 3
            dt.Rows.Add(newrow)

            newrow = dt.NewRow
            newrow.Item("Week") = 4
            newrow.Item("Value") = 4
            dt.Rows.Add(newrow)

            newrow = dt.NewRow
            newrow.Item("Week") = 5
            newrow.Item("Value") = 5
            dt.Rows.Add(newrow)

            newrow = dt.NewRow
            newrow.Item("Week") = 6
            newrow.Item("Value") = 6
            dt.Rows.Add(newrow)

            newrow = dt.NewRow
            newrow.Item("Week") = 7
            newrow.Item("Value") = 7
            dt.Rows.Add(newrow)

            newrow = dt.NewRow
            newrow.Item("Week") = 8
            newrow.Item("Value") = 8
            dt.Rows.Add(newrow)

            Me.RadComboBoxWeek.DataSource = dt
            Me.RadComboBoxWeek.DataBind()

        Catch ex As Exception

        End Try
    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Loadweeks()
            Me.RadDatePickerStartingWeek.SelectedDate = Date.Now


            Dim FirstDayOfWeekDate As Date

            For i As Integer = 0 To 6 Step 1

                FirstDayOfWeekDate = CDate(RadDatePickerStartingWeek.SelectedDate).AddDays(-i)

                If FirstDayOfWeekDate.DayOfWeek = DayOfWeek.Sunday Then

                    Exit For

                End If

            Next

            Me.RadDatePickerStartingWeek.SelectedDate = FirstDayOfWeekDate

            Me.RadDatePickerStartingWeek.MinDate = FirstDayOfWeekDate

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Session("DRPT_ParameterDictionary") = Nothing



                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.ResourceAllocationByWeekParameters.StartingWeek.ToString) = RadDatePickerStartingWeek.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.ResourceAllocationByWeekParameters.NumberOfWeeks.ToString) = Me.RadComboBoxWeek.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.ResourceAllocationByWeekParameters.View.ToString) = If(RadioButtonSummary.Checked, 1, 2)

                Session("DRPT_Criteria") = Nothing
                Session("DRPT_FilterString") = Nothing
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = Nothing
                Session("DRPT_To") = Nothing
                Session("DRPT_ShowJobsWithNoDetails") = Nothing
                Session("DRPT_ParameterDictionary") = _ParameterDictionary

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

    Private Sub RadDatePickerStartingWeek_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles RadDatePickerStartingWeek.SelectedDateChanged
        Try
            Dim FirstDayOfWeekDate As Date

            For i As Integer = 0 To 6 Step 1

                FirstDayOfWeekDate = CDate(RadDatePickerStartingWeek.SelectedDate).AddDays(-i)

                If FirstDayOfWeekDate.DayOfWeek = DayOfWeek.Sunday Then

                    Exit For

                End If

            Next

            Me.RadDatePickerStartingWeek.SelectedDate = FirstDayOfWeekDate

        Catch ex As Exception

        End Try
    End Sub


#End Region

#End Region

End Class
