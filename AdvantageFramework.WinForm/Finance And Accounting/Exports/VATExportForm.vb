Namespace FinanceAndAccounting.Exports

    Public Class VATExportForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.Exports.VATExportViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.Exports.VATExportController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            If _ViewModel.IsAgencyASP Then

                TextBoxCriteria_OutputFolder.Enabled = False
                TextBoxCriteria_OutputFolder.Text = _ViewModel.AgencyImportPath

            Else

                TextBoxCriteria_OutputFolder.Text = _ViewModel.OutputFolder

            End If

            SearchableComboBoxCriteria_PPStart.DataSource = _ViewModel.PostPeriods
            SearchableComboBoxCriteria_PPEnd.DataSource = _ViewModel.PostPeriods
            SearchableComboBoxCriteria_CurrencyCode.DataSource = _ViewModel.CurrencyCodes

            SearchableComboBoxCriteria_PPStart.SelectedValue = _ViewModel.PostPeriodCodeStart
            SearchableComboBoxCriteria_PPEnd.SelectedValue = _ViewModel.PostPeriodCodeEnd
            TextBoxCriteria_VATNumber.Text = _ViewModel.AgencyVATNumber
            SearchableComboBoxCriteria_CurrencyCode.SelectedValue = _ViewModel.CurrencyCode

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.PostPeriodCodeStart = SearchableComboBoxCriteria_PPStart.GetSelectedValue
            _ViewModel.PostPeriodCodeEnd = SearchableComboBoxCriteria_PPEnd.GetSelectedValue
            _ViewModel.AgencyVATNumber = TextBoxCriteria_VATNumber.GetText
            _ViewModel.CurrencyCode = SearchableComboBoxCriteria_CurrencyCode.GetSelectedValue
            _ViewModel.OutputFolder = TextBoxCriteria_OutputFolder.GetText

        End Sub
        Private Sub SetControlPropertySettings()

            SearchableComboBoxCriteria_PPStart.SetRequired(True)
            SearchableComboBoxCriteria_PPStart.DisplayName = "Post Period Start"

            SearchableComboBoxCriteria_PPEnd.SetRequired(True)
            SearchableComboBoxCriteria_PPEnd.DisplayName = "Post Period End"

            TextBoxCriteria_VATNumber.SetRequired(True)
            TextBoxCriteria_VATNumber.DisplayName = "Agency VAT Number"

            SearchableComboBoxCriteria_CurrencyCode.SetRequired(True)

            TextBoxCriteria_OutputFolder.SetRequired(True)
            TextBoxCriteria_OutputFolder.DisplayName = "Output Folder"

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim VATExportForm As FinanceAndAccounting.Exports.VATExportForm = Nothing

            VATExportForm = New FinanceAndAccounting.Exports.VATExportForm

            VATExportForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VATExportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage

            SetControlPropertySettings()

            DataGridViewData_Data.CurrentView.OptionsBehavior.Editable = False

        End Sub
        Private Sub VATExportForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.Exports.VATExportController(Me.Session)

            _ViewModel = _Controller.Load()

            LoadViewModel

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemExport_ToAvalara_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_ToAvalara.Click

            Dim ErrorMessage As String = Nothing

            If DataGridViewData_Data.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow).Where(Function(VER) VER.HasError).Any Then

                AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.")

            Else

                If _Controller.Export(_ViewModel, ErrorMessage) Then

                    If _ViewModel.IsAgencyASP Then

                        AdvantageFramework.Navigation.ShowMessageBox("File exported successfully and also email link has been sent to your email.")

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("File exported successfully.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemExport_ToExcel_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_ToExcel.Click

            DataGridViewData_Data.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Form", ""), _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            Dim ErrorMessage As String = ""

            If Me.Validator Then

                SaveViewModel()

                If _Controller.Process(_ViewModel, ErrorMessage) Then

                    DataGridViewData_Data.DataSource = _ViewModel.VATExportRows

                    DataGridViewData_Data.CurrentView.BestFitColumns()

                    TabControlForm_Tabs.SelectedTab = TabItemTabs_Data

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

#End Region

#End Region

    End Class

End Namespace
