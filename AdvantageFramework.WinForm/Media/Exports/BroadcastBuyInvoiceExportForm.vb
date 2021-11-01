Namespace Media.Exports

    Public Class BroadcastBuyInvoiceExportForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.Exports.BroadcastBuyInvoiceExportController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub EnableOrDisableActions()

            ComboBoxOptions_BroadcastMonth.Enabled = RadioButtonControlOptions_BroadcastMonth.Checked
            ComboBoxOptions_BroadcastMonth.SetRequired(RadioButtonControlOptions_BroadcastMonth.Checked)

            ComboBoxOptions_Quarter.Enabled = RadioButtonControlOptions_Quarter.Checked
            ComboBoxOptions_Quarter.SetRequired(RadioButtonControlOptions_Quarter.Checked)

            DataGridViewSelectClients_Clients.Enabled = RadioButtonSelectClients_ChooseClients.Checked

        End Sub
        Private Sub LoadViewModel()

            NumericInputOptions_Year.EditValue = Now.Year

            If _ViewModel.IsAgencyASP Then

                TextBoxOptions_OutputFolder.Enabled = False
                TextBoxOptions_OutputFolder.Text = _ViewModel.AgencyImportPath

            Else

                TextBoxOptions_OutputFolder.Text = _ViewModel.OutputFolder

            End If

            ComboBoxOptions_BroadcastMonth.DataSource = _ViewModel.BroadcastMonthList
            ComboBoxOptions_Quarter.DataSource = _ViewModel.BroadcastQuarterList

            DataGridViewSelectClients_Clients.DataSource = _ViewModel.ClientList
            DataGridViewSelectClients_Clients.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.Year = NumericInputOptions_Year.GetValue

            If RadioButtonControlOptions_BroadcastMonth.Checked Then

                _Controller.SetBroadcastStartEndDates(ComboBoxOptions_BroadcastMonth.GetSelectedValue, Me.NumericInputOptions_Year.GetValue, _ViewModel)
                _ViewModel.FilePrefix = MonthName(_ViewModel.Months.First) & "_" & _ViewModel.Year.ToString

            ElseIf RadioButtonControlOptions_Quarter.Checked Then

                _Controller.SetQuarterStartEndDates(ComboBoxOptions_Quarter.GetSelectedValue, Me.NumericInputOptions_Year.GetValue, _ViewModel)
                _ViewModel.FilePrefix = _ViewModel.Quarter & "_" & _ViewModel.Year.ToString

            End If

            If RadioButtonSelectClients_ChooseClients.Checked Then

                _ViewModel.SelectedClientCodes = DataGridViewSelectClients_Clients.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.DTO.Client).Select(Function(F) F.ClientCode).ToArray

            Else

                _ViewModel.SelectedClientCodes = Nothing

            End If

            _ViewModel.OutputFolder = TextBoxOptions_OutputFolder.GetText

        End Sub
        Private Sub SetControlPropertySettings()

            NumericInputOptions_Year.SetRequired(True)

            TextBoxOptions_OutputFolder.SetRequired(True)
            TextBoxOptions_OutputFolder.DisplayName = "Output Folder"

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim BroadcastBuyInvoiceExportForm As Media.Exports.BroadcastBuyInvoiceExportForm = Nothing

            BroadcastBuyInvoiceExportForm = New Media.Exports.BroadcastBuyInvoiceExportForm

            BroadcastBuyInvoiceExportForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastBuyInvoiceExportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            SetControlPropertySettings()

        End Sub
        Private Sub BroadcastBuyInvoiceExportForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            _Controller = New AdvantageFramework.Controller.Media.Exports.BroadcastBuyInvoiceExportController(Me.Session)

            _ViewModel = _Controller.Load()

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            Dim ErrorMessage As String = ""

            If Me.Validator Then

                SaveViewModel()

                If _Controller.ExportBuyAndInvoiceFiles(_ViewModel, ErrorMessage) Then

                    If _ViewModel.IsAgencyASP Then

                        AdvantageFramework.Navigation.ShowMessageBox("Files exported successfully and also email link has been sent to your email.")

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Files exported successfully.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub RadioButtonControlOptions_BroadcastMonth_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlOptions_BroadcastMonth.CheckedChangedEx

            If e.NewChecked.Checked Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonControlOptions_Quarter_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlOptions_Quarter.CheckedChangedEx

            If e.NewChecked.Checked Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonSelectClients_AllClients_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonSelectClients_AllClients.CheckedChangedEx

            If e.NewChecked.Checked Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonSelectClients_ChooseClients_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonSelectClients_ChooseClients.CheckedChangedEx

            If e.NewChecked.Checked Then

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
