Public Class Reporting_InitialLoadingAROpenAged
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

    Private Sub Reporting_InitialLoadingPostPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        Dim oAccounting As cAccounting = New cAccounting(CStr(Session("ConnString")))
        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.RadDatePickerAging.SelectedDate = cEmployee.TimeZoneToday

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.RadComboBoxCutoff.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                Me.RadComboBoxCutoff.DataBind()

                RadComboBoxRecordSource.DataValueField = "ID"
                RadComboBoxRecordSource.DataTextField = "Name"

                Me.RadComboBoxRecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList
                Me.RadComboBoxRecordSource.DataBind()
                RadComboBoxRecordSource.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                Try
                    Me.RadComboBoxCutoff.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Catch ex As Exception
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadComboBoxCutoff.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.PeriodCutoff.ToString)

                Catch ex As Exception

                End Try

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString)) = False Then

                    Try

                        RadComboBoxRecordSource.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString)

                    Catch ex As Exception
                        RadComboBoxRecordSource.SelectedValue = Nothing
                    End Try

                End If

                Try

                    RadDatePickerAging.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingDate.ToString)

                Catch ex As Exception

                End Try

                RadioButtonInvoice.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingOption.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingOption.ToString) = 1, True, False)
                RadioButtonInvoiceDueDate.Checked = Not Me.RadioButtonInvoice.Checked
                CheckBoxIncludeDetails.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.IncludeDetails.ToString)), True, _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.IncludeDetails.ToString))

            Else

                RadioButtonInvoice.Checked = True
                RadioButtonInvoiceDueDate.Checked = False
                CheckBoxIncludeDetails.Checked = False

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

                Dim cutoff As String
                If Me.RadComboBoxCutoff.SelectedValue <> "" Then
                    cutoff = Me.RadComboBoxCutoff.SelectedValue.Substring(0, 6)
                End If

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.UsedID.ToString) = _Session.UserCode
                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.PeriodCutoff.ToString) = cutoff
                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingOption.ToString) = If(RadioButtonInvoice.Checked, 1, 2)
                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingDate.ToString) = RadDatePickerAging.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.IncludeDetails.ToString) = CheckBoxIncludeDetails.Checked

                If Not String.IsNullOrWhiteSpace(RadComboBoxRecordSource.SelectedValue) Then

                    _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString) = CInt(RadComboBoxRecordSource.SelectedValue)

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString) = 0

                End If

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

#End Region

#End Region

End Class
