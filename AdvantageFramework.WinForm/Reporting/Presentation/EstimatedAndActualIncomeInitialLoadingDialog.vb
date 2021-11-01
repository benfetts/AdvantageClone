Namespace Reporting.Presentation

    Public Class EstimatedAndActualIncomeInitialLoadingDialog

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
            Dim EstimatedAndActualIncomeInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.EstimatedAndActualIncomeInitialLoadingDialog = Nothing

            EstimatedAndActualIncomeInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.EstimatedAndActualIncomeInitialLoadingDialog(0)

            ShowFormDialog = EstimatedAndActualIncomeInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = EstimatedAndActualIncomeInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EstimateAndActualIncomeInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.EstimatedAndActualIncomeInitialCriteria), False)

            If _ParameterDictionary IsNot Nothing Then

                Try

                    DateTimePickerForm_From.Value = _ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.StartDate.ToString)

                Catch ex As Exception

                End Try

                Try

                    DateTimePickerForm_To.Value = _ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.EndDate.ToString)

                Catch ex As Exception

                End Try

                RadioButtonForm_Standard.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString) = 1, True, False)
                RadioButtonForm_AlternateDirectCost.Checked = Not RadioButtonForm_Standard.Checked

            Else

                RadioButtonForm_Standard.Checked = True
                RadioButtonForm_AlternateDirectCost.Checked = False

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

                    _ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.StartDate.ToString) = DateTimePickerForm_From.Value
                    _ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.EndDate.ToString) = DateTimePickerForm_To.Value
                    _ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.DateType.ToString) = ComboBoxForm_Criteria.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.Standard.ToString) = If(RadioButtonForm_Standard.Checked, 1, 0)


                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a start date that is before the end date.")

                End If

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

    End Class

End Namespace