Namespace Reporting.Presentation

    Public Class ProjectSummaryAnalysisInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim ProjectSummaryAnalysisInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.ProjectSummaryAnalysisInitialLoadingDialog = Nothing

            ProjectSummaryAnalysisInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.ProjectSummaryAnalysisInitialLoadingDialog(0)

            ShowFormDialog = ProjectSummaryAnalysisInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = ProjectSummaryAnalysisInitialLoadingDialog.ParameterDictionary

            End If

        End Function

        Private Sub ProjectSummaryAnalysisInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CDPChooserControl_Production.ForceResize()
            AEChooserControl_Production.ForceResize()
            SalesClassChooserControl1.ForceResize()
            JobTypeChooserControl1.ForceResize()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectSummaryAnalysisInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailInitialCriteria), False)
            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            CDPChooserControl_Production.LoadControl()
            AEChooserControl_Production.LoadControl()
            SalesClassChooserControl1.LoadControl()
            JobTypeChooserControl1.LoadControl()

            Me.CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisions.Visible = False
            Me.CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisionProducts.Visible = False

            If _ParameterDictionary IsNot Nothing Then

                Try

                    DateTimePickerForm_From.Value = _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.FromDate.ToString)

                Catch ex As Exception

                End Try

                Try

                    DateTimePickerForm_To.Value = _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ToDate.ToString)

                Catch ex As Exception

                End Try

                CheckBoxForm_IncludeDetail.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeDetail.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeDetail.ToString) = 1, True, False)
                CheckBox_IncludeEmployeeDetail.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeEmployeeDetail.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeEmployeeDetail.ToString) = 1, True, False)
                RadioButtonDataOption_Planned.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.QuotedPlanned.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.QuotedPlanned.ToString) = 1, True, False)
                RadioButtonDataOption_Quoted.Checked = Not RadioButtonDataOption_Planned.Checked
                RadioButtonControl_HoursAllowed.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ForecastHoursAllowed.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ForecastHoursAllowed.ToString) = 1, True, False)
                RadioButtonControl_Forecast.Checked = Not RadioButtonControl_HoursAllowed.Checked

            Else

                CheckBoxForm_IncludeDetail.Checked = False
                CheckBox_IncludeEmployeeDetail.Checked = False
                RadioButtonDataOption_Planned.Checked = True
                RadioButtonDataOption_Quoted.Checked = False
                RadioButtonControl_HoursAllowed.Checked = True
                RadioButtonControl_Forecast.Checked = False

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If DateTimePickerForm_From.Value <= DateTimePickerForm_To.Value Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.DateType.ToString) = ComboBoxForm_Criteria.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.FromDate.ToString) = DateTimePickerForm_From.Value
                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ToDate.ToString) = DateTimePickerForm_To.Value


                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a start date that is before the end date.")

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeDetail.ToString) = CheckBoxForm_IncludeDetail.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeEmployeeDetail.ToString) = CheckBox_IncludeEmployeeDetail.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.QuotedPlanned.ToString) = If(RadioButtonDataOption_Quoted.Checked, 1, 2)
                _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ForecastHoursAllowed.ToString) = If(RadioButtonControl_Forecast.Checked, 1, 2)

                _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ClientCodes.ToString) = CDPChooserControl_Production.ClientCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.AECodes.ToString) = AEChooserControl_Production.AccountExecutiveCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.SalesClassCodes.ToString) = SalesClassChooserControl1.SalesClassCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.JobTypeCodes.ToString) = JobTypeChooserControl1.JobTypeCodeList

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

			DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
			DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

			DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

        End Sub

#End Region

#End Region

        Private Sub CheckBox_IncludeEmployeeDetail_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_IncludeEmployeeDetail.CheckedChanged
            Try
                If Me.CheckBox_IncludeEmployeeDetail.Checked = True Then
                    Me.RadioButtonControl_HoursAllowed.Checked = True
                    Me.RadioButtonControl_Forecast.Checked = False
                    Me.RadioButtonDataOption_Planned.Checked = True
                    Me.RadioButtonDataOption_Quoted.Checked = False
                    Me.CheckBoxForm_IncludeDetail.Checked = False
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub CheckBoxForm_IncludeDetail_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_IncludeDetail.CheckedChanged
            Try
                If Me.CheckBoxForm_IncludeDetail.Checked = True Then
                    Me.RadioButtonControl_HoursAllowed.Checked = True
                    Me.RadioButtonControl_Forecast.Checked = False
                    Me.CheckBox_IncludeEmployeeDetail.Checked = False
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub RadioButtonDataOption_Quoted_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDataOption_Quoted.CheckedChanged
            If RadioButtonDataOption_Quoted.Checked = True Then
                CheckBox_IncludeEmployeeDetail.Checked = False
            End If
        End Sub

        Private Sub RadioButtonControl_Forecast_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_Forecast.CheckedChanged
            If RadioButtonControl_Forecast.Checked = True Then
                CheckBox_IncludeEmployeeDetail.Checked = False
            End If
        End Sub
    End Class

End Namespace