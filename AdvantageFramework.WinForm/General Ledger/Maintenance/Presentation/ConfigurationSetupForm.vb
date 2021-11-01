Namespace GeneralLedger.Maintenance.Presentation

    Public Class ConfigurationSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerConfigurationViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.GeneralLedger.Maintenance.GeneralLedgerConfigurationController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Cancel.Enabled = _ViewModel.EditSegment

            Me.TextBoxDefaults_DefaultFormat.Text = _ViewModel.GeneralLedgerConfiguration.DefaultFormat

            Me.TextBoxAccountCodeFormat_Segment1.Text = _ViewModel.GeneralLedgerConfiguration.Segment1Format
            Me.TextBoxAccountCodeFormat_Segment2.Text = _ViewModel.GeneralLedgerConfiguration.Segment2Format
            Me.TextBoxAccountCodeFormat_Segment3.Text = _ViewModel.GeneralLedgerConfiguration.Segment3Format
            Me.TextBoxAccountCodeFormat_Segment4.Text = _ViewModel.GeneralLedgerConfiguration.Segment4Format

            For Each RadioButtonControl In Me.Panel1AccountCodeFormat_Segment1.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.Segment1Type = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.Panel1AccountCodeFormat_Segment2.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.Segment2Type = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.Panel1AccountCodeFormat_Segment3.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.Segment3Type = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.Panel1AccountCodeFormat_Segment4.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.Segment4Type = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True
                    Exit For

                End If

            Next

            For Each CheckBoxControl In Me.Panel2AccountCodeFormat_Segment1.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox)

                If _ViewModel.GeneralLedgerConfiguration.Segment1After = Convert.ToInt64(CheckBoxControl.Tag) Then

                    CheckBoxControl.Checked = True

                Else

                    CheckBoxControl.Checked = False

                End If

            Next

            For Each CheckBoxControl In Me.Panel2AccountCodeFormat_Segment2.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox)

                If _ViewModel.GeneralLedgerConfiguration.Segment2After = Convert.ToInt64(CheckBoxControl.Tag) Then

                    CheckBoxControl.Checked = True

                Else

                    CheckBoxControl.Checked = False

                End If

            Next

            For Each CheckBoxControl In Me.Panel2AccountCodeFormat_Segment3.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox)

                If _ViewModel.GeneralLedgerConfiguration.Segment3After = Convert.ToInt64(CheckBoxControl.Tag) Then

                    CheckBoxControl.Checked = True

                Else

                    CheckBoxControl.Checked = False

                End If

            Next

            Me.ComboBoxDefaults_FiscalYearStartMonth.SelectedValue = _ViewModel.GeneralLedgerConfiguration.FiscalYearStartMonth.ToString

            For Each RadioButtonControl In Me.GroupBoxDefaults_PostingPeriodFormat.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.PostingPeriodFormat = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True

                End If

            Next

            For Each RadioButtonControl In Me.GroupBoxDefaults_FiscalYearOptions.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.PostingPeriodYear = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True

                End If

            Next

            Me.TextBoxCurrencyFormat_CurrencySymbol.Text = _ViewModel.GeneralLedgerConfiguration.CurrencySymbol

            For Each RadioButtonControl In Me.PanelLastYearsActualAmounts_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.BudgetLastYearActual = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True

                End If

            Next

            For Each RadioButtonControl In Me.PanelVarianceToLastYear_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.BudgetLastYearVariance = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True

                End If

            Next

            If _ViewModel.GeneralLedgerConfiguration.BudgetIncludeYearEnd = Convert.ToInt64(1) Then

                Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Checked = True

            Else

                Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Checked = False

            End If

            For Each RadioButtonControl In Me.PanelYTDActualAmounts_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.BudgetYTD = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True

                End If

            Next

            For Each RadioButtonControl In Me.PanelCompareUsingCurrentBudget_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.BudgetEXT = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True

                End If

            Next

            For Each RadioButtonControl In Me.PanelVarianceToCurrentBudget_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.BudgetEXTVAR = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True

                End If

            Next

            For Each RadioButtonControl In Me.PanelClientBudget_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If _ViewModel.GeneralLedgerConfiguration.BudgetClient = RadioButtonControl.Tag Then

                    RadioButtonControl.Checked = True

                End If

            Next

            'If _ViewModel.GeneralLedgerConfiguration.SuppressFinancialStatements = Convert.ToInt64(1) Then

            '    Me.CheckBoxOptions_SuppressFinancialStatements.Checked = True

            'Else

            '    Me.CheckBoxOptions_SuppressFinancialStatements.Checked = False

            'End If

            'If _ViewModel.GeneralLedgerConfiguration.UseControlAmounts = Convert.ToInt64(1) Then

            '    Me.CheckBoxOptions_UseControlAmounts.Checked = True

            'Else
            '    Me.CheckBoxOptions_UseControlAmounts.Checked = False

            'End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetAssetsCurrent = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_CurrentAssets.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_CurrentAssets.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetAssets = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_NonCurrentAssets.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_NonCurrentAssets.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetAssetsFixed = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_FixedAssets.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_FixedAssets.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetLiabilitiesCurrent = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_CurrentLiabilities.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_CurrentLiabilities.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetLiabilities = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetIncome = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_Income.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_Income.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetIncomeOther = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_IncomeOther.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_IncomeOther.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetExpenseCOS = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_ExpenseCOS.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_ExpenseCOS.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetExpenseOperating = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_ExpenseOperating.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_ExpenseOperating.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetExpenseOther = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_ExpenseOther.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_ExpenseOther.Checked = False

            End If

            If _ViewModel.GeneralLedgerConfiguration.BudgetExpenseTaxes = Convert.ToInt64(1) Then

                Me.CheckBoxAccountsToBudget_ExpenseTaxes.Checked = True

            Else

                Me.CheckBoxAccountsToBudget_ExpenseTaxes.Checked = False

            End If

            GroupBoxDefaults_AccountCodeFormat.Enabled = _ViewModel.EditSegment

            TextBoxAccountCodeFormat_Segment1.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)
            TextBoxAccountCodeFormat_Segment2.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)
            TextBoxAccountCodeFormat_Segment3.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)
            TextBoxAccountCodeFormat_Segment4.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)

            TextBoxAccountCodeFormat_Segment1Description.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)
            TextBoxAccountCodeFormat_Segment2Description.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)
            TextBoxAccountCodeFormat_Segment3Description.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)
            TextBoxAccountCodeFormat_Segment4Description.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)

            Panel2AccountCodeFormat_Segment1.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)
            Panel2AccountCodeFormat_Segment2.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)
            Panel2AccountCodeFormat_Segment3.Enabled = _ViewModel.IsNew OrElse (_ViewModel.HasGLAccounts = False)

            ButtonItemSegmentTypes_Edit.Enabled = Not _ViewModel.EditSegment

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.GeneralLedgerConfiguration.Segment1Format = Me.TextBoxAccountCodeFormat_Segment1.GetText
            _ViewModel.GeneralLedgerConfiguration.Segment2Format = Me.TextBoxAccountCodeFormat_Segment2.GetText
            _ViewModel.GeneralLedgerConfiguration.Segment3Format = Me.TextBoxAccountCodeFormat_Segment3.GetText
            _ViewModel.GeneralLedgerConfiguration.Segment4Format = Me.TextBoxAccountCodeFormat_Segment4.GetText

            For Each RadioButtonControl In Me.Panel1AccountCodeFormat_Segment1.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.Segment1Type = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.Panel1AccountCodeFormat_Segment2.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.Segment2Type = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.Panel1AccountCodeFormat_Segment3.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.Segment3Type = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.Panel1AccountCodeFormat_Segment4.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.Segment4Type = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            _ViewModel.GeneralLedgerConfiguration.Segment1Description = Me.TextBoxAccountCodeFormat_Segment1Description.GetText
            _ViewModel.GeneralLedgerConfiguration.Segment2Description = Me.TextBoxAccountCodeFormat_Segment2Description.GetText
            _ViewModel.GeneralLedgerConfiguration.Segment3Description = Me.TextBoxAccountCodeFormat_Segment3Description.GetText
            _ViewModel.GeneralLedgerConfiguration.Segment4Description = Me.TextBoxAccountCodeFormat_Segment4Description.GetText

            _ViewModel.GeneralLedgerConfiguration.Segment1After = 0
            _ViewModel.GeneralLedgerConfiguration.Segment2After = 0
            _ViewModel.GeneralLedgerConfiguration.Segment3After = 0

            For Each CheckBoxControl In Me.Panel2AccountCodeFormat_Segment1.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox)

                If CheckBoxControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.Segment1After = CShort(CheckBoxControl.Tag)
                    Exit For

                End If

            Next

            For Each CheckBoxControl In Me.Panel2AccountCodeFormat_Segment2.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox)

                If CheckBoxControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.Segment2After = CShort(CheckBoxControl.Tag)
                    Exit For

                End If

            Next

            For Each CheckBoxControl In Me.Panel2AccountCodeFormat_Segment3.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox)

                If CheckBoxControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.Segment3After = CShort(CheckBoxControl.Tag)
                    Exit For

                End If

            Next

            _ViewModel.GeneralLedgerConfiguration.FiscalYearStartMonth = Me.ComboBoxDefaults_FiscalYearStartMonth.SelectedValue

            For Each RadioButtonControl In Me.GroupBoxDefaults_PostingPeriodFormat.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.PostingPeriodFormat = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.GroupBoxDefaults_FiscalYearOptions.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.PostingPeriodYear = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            _ViewModel.GeneralLedgerConfiguration.CurrencySymbol = Me.TextBoxCurrencyFormat_CurrencySymbol.Text

            For Each RadioButtonControl In Me.PanelLastYearsActualAmounts_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.BudgetLastYearActual = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.PanelVarianceToLastYear_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.BudgetLastYearVariance = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.PanelYTDActualAmounts_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.BudgetYTD = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.PanelCompareUsingCurrentBudget_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.BudgetEXT = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.PanelVarianceToCurrentBudget_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.BudgetEXTVAR = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            For Each RadioButtonControl In Me.PanelClientBudget_Columns.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked = True Then

                    _ViewModel.GeneralLedgerConfiguration.BudgetClient = Convert.ToInt64(RadioButtonControl.Tag)
                    Exit For

                End If

            Next

            _ViewModel.GeneralLedgerConfiguration.BudgetIncludeYearEnd = If(Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Checked, 1, 0)

            '_ViewModel.GeneralLedgerConfiguration.SuppressFinancialStatements = If(Me.CheckBoxOptions_SuppressFinancialStatements.Checked, 1, 0)

            '_ViewModel.GeneralLedgerConfiguration.UseControlAmounts = If(Me.CheckBoxOptions_UseControlAmounts.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetAssetsCurrent = If(Me.CheckBoxAccountsToBudget_CurrentAssets.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetAssets = If(Me.CheckBoxAccountsToBudget_NonCurrentAssets.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetAssetsFixed = If(Me.CheckBoxAccountsToBudget_FixedAssets.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetLiabilitiesCurrent = If(Me.CheckBoxAccountsToBudget_CurrentLiabilities.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetLiabilities = If(Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Checked, 1, 0)


            _ViewModel.GeneralLedgerConfiguration.BudgetIncome = If(Me.CheckBoxAccountsToBudget_Income.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetIncomeOther = If(Me.CheckBoxAccountsToBudget_IncomeOther.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetExpenseCOS = If(Me.CheckBoxAccountsToBudget_ExpenseCOS.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetExpenseOperating = If(Me.CheckBoxAccountsToBudget_ExpenseOperating.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetExpenseOther = If(Me.CheckBoxAccountsToBudget_ExpenseOther.Checked, 1, 0)

            _ViewModel.GeneralLedgerConfiguration.BudgetExpenseTaxes = If(Me.CheckBoxAccountsToBudget_ExpenseTaxes.Checked, 1, 0)

        End Sub
        Private Sub SetDefaultDatasources()

            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            Me.ComboBoxDefaults_FiscalYearStartMonth.DataSource = _ViewModel.ComboBoxItemMonths

            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

            Me.ComboBoxDefaults_FiscalYearStartMonth.SetPropertySettings()

            Me.TextBoxCurrencyFormat_CurrencySymbol.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration.Properties.CurrencySymbol)

            Me.TextBoxAccountCodeFormat_Segment1.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration.Properties.Segment1Format)

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load()

            SetDefaultDatasources()

            If _ViewModel.IsNew Then

                AdvantageFramework.WinForm.MessageBox.Show("The configuration table must be set-up before other G/L applications are made available.")

            End If

            RefreshViewModel()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            Dim ConfigurationSetupForm As AdvantageFramework.GeneralLedger.Maintenance.Presentation.ConfigurationSetupForm = Nothing

            ConfigurationSetupForm = New AdvantageFramework.GeneralLedger.Maintenance.Presentation.ConfigurationSetupForm()

            ConfigurationSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ConfigurationSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemSegmentTypes_Edit.Image = AdvantageFramework.My.Resources.EditImage

            _Controller = New AdvantageFramework.Controller.GeneralLedger.Maintenance.GeneralLedgerConfigurationController(Me.Session)

        End Sub
        Private Sub ConfigurationSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

            Me.ClearChanged()

        End Sub
        Private Sub ConfigurationSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ConfigurationSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = ""
            Dim IsValid As Boolean = True

            If Me.Validator() Then

                _Controller.RefreshHasGLAccounts(_ViewModel)

                If TextBoxAccountCodeFormat_Segment1.Enabled AndAlso _ViewModel.HasGLAccounts Then

                    AdvantageFramework.WinForm.MessageBox.Show("GL accounts were added while segment lengths were editable.  Form will refresh.")

                    LoadViewModel()

                    Me.ClearChanged()

                    Me.CloseWaitForm()

                Else

                    Me.SaveViewModel()

                    ErrorMessage = _Controller.ValidateEntity(_ViewModel.GeneralLedgerConfiguration, IsValid)

                    If IsValid Then

                        Me.ShowWaitForm("Saving...")

                        If _Controller.Save(_ViewModel, _ViewModel.EditSegment, ErrorMessage) = False Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                        Me.ClearChanged()

                        Me.CloseWaitForm()

                        _Controller.SetEditSegmentFlag(_ViewModel, False)

                        RefreshViewModel()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadViewModel()

            Me.ClearChanged()

        End Sub
        Private Sub TextBoxAccountCodeFormat_Segment1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAccountCodeFormat_Segment1.KeyPress

            If e.KeyChar <> "0" AndAlso e.KeyChar <> ChrW(System.Windows.Forms.Keys.Back) Then

                e.Handled = True

            End If

        End Sub
        Private Sub TextBoxAccountCodeFormat_Segment1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxAccountCodeFormat_Segment1.TextChanged

            If TextBoxAccountCodeFormat_Segment1.Text.Length = 0 Then

                TextBoxAccountCodeFormat_Segment2.Enabled = False
                TextBoxAccountCodeFormat_Segment2.Clear()

                TextBoxAccountCodeFormat_Segment3.Enabled = False
                TextBoxAccountCodeFormat_Segment3.Clear()

                TextBoxAccountCodeFormat_Segment4.Enabled = False
                TextBoxAccountCodeFormat_Segment4.Clear()

            Else

                TextBoxAccountCodeFormat_Segment2.Enabled = True

            End If

        End Sub
        Private Sub TextBoxAccountCodeFormat_Segment2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAccountCodeFormat_Segment2.KeyPress

            If e.KeyChar <> "0" AndAlso e.KeyChar <> ChrW(System.Windows.Forms.Keys.Back) Then

                e.Handled = True

            End If

        End Sub
        Private Sub TextBoxAccountCodeFormat_Segment2_TextChanged(sender As Object, e As EventArgs) Handles TextBoxAccountCodeFormat_Segment2.TextChanged

            If TextBoxAccountCodeFormat_Segment2.Text.Length = 0 Then

                TextBoxAccountCodeFormat_Segment3.Enabled = False
                TextBoxAccountCodeFormat_Segment3.Clear()

                TextBoxAccountCodeFormat_Segment4.Enabled = False
                TextBoxAccountCodeFormat_Segment4.Clear()

            Else

                TextBoxAccountCodeFormat_Segment3.Enabled = True

            End If

        End Sub
        Private Sub TextBoxAccountCodeFormat_Segment3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAccountCodeFormat_Segment3.KeyPress

            If e.KeyChar <> "0" AndAlso e.KeyChar <> ChrW(System.Windows.Forms.Keys.Back) Then

                e.Handled = True

            End If

        End Sub
        Private Sub TextBoxAccountCodeFormat_Segment3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxAccountCodeFormat_Segment3.TextChanged

            If TextBoxAccountCodeFormat_Segment3.Text.Length = 0 Then

                TextBoxAccountCodeFormat_Segment4.Enabled = False
                TextBoxAccountCodeFormat_Segment4.Clear()

            Else

                TextBoxAccountCodeFormat_Segment4.Enabled = True

            End If

        End Sub
        Private Sub TextBoxAccountCodeFormat_Segment4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAccountCodeFormat_Segment4.KeyPress

            If e.KeyChar <> "0" AndAlso e.KeyChar <> ChrW(System.Windows.Forms.Keys.Back) Then

                e.Handled = True

            End If
        End Sub
        Private Sub CheckBoxAccountCodeFormat_Segment1Hyphen_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAccountCodeFormat_Segment1Hyphen.CheckedChangedEx

            If e.NewChecked.Checked Then

                CheckBoxAccountCodeFormat_Segment1Period.Checked = False

            End If

        End Sub
        Private Sub CheckBoxAccountCodeFormat_Segment1Period_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAccountCodeFormat_Segment1Period.CheckedChangedEx

            If e.NewChecked.Checked Then

                CheckBoxAccountCodeFormat_Segment1Hyphen.Checked = False

            End If

        End Sub
        Private Sub CheckBoxAccountCodeFormat_Segment2Hyphen_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAccountCodeFormat_Segment2Hyphen.CheckedChangedEx

            If e.NewChecked.Checked Then

                CheckBoxAccountCodeFormat_Segment2Period.Checked = False

            End If

        End Sub
        Private Sub CheckBoxAccountCodeFormat_Segment2Period_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAccountCodeFormat_Segment2Period.CheckedChangedEx

            If e.NewChecked.Checked Then

                CheckBoxAccountCodeFormat_Segment2Hyphen.Checked = False

            End If

        End Sub
        Private Sub CheckBoxAccountCodeFormat_Segment3Hyphen_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAccountCodeFormat_Segment3Hyphen.CheckedChangedEx

            If e.NewChecked.Checked Then

                CheckBoxAccountCodeFormat_Segment3Period.Checked = False

            End If

        End Sub
        Private Sub CheckBoxAccountCodeFormat_Segment3Period_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxAccountCodeFormat_Segment3Period.CheckedChangedEx

            If e.NewChecked.Checked Then

                CheckBoxAccountCodeFormat_Segment3Hyphen.Checked = False

            End If

        End Sub
        Private Sub RadioButtonLastYearsActualAmounts_Exclude_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonLastYearsActualAmounts_Exclude.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Exclude.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                    PanelVarianceToLastYear_Columns.Enabled = False
                    CheckBoxVarianceToLastYear_IncludeYearEndEntries.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonCompareUsingCurrentBudget_Exclude_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonCompareUsingCurrentBudget_Exclude.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                    PanelVarianceToCurrentBudget_Columns.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonLastYearsActualAmounts_Column1_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonLastYearsActualAmounts_Column1.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column1.Checked = True Then
                    PanelVarianceToLastYear_Columns.Enabled = True
                    CheckBoxVarianceToLastYear_IncludeYearEndEntries.Enabled = True
                End If

                If RadioButtonVarianceToLastYear_Column1.Checked = True Then
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column1.Checked = True Then
                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column1.Checked = True Then
                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column1.Checked = True Then
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column1.Checked = True Then
                    RadioButtonClientBudget_Exclude.Checked = True
                End If

            End If

        End Sub
        Private Sub RadioButtonLastYearsActualAmounts_Column2_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonLastYearsActualAmounts_Column2.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column2.Checked = True Then
                    PanelVarianceToLastYear_Columns.Enabled = True
                    CheckBoxVarianceToLastYear_IncludeYearEndEntries.Enabled = True
                End If

                If RadioButtonVarianceToLastYear_Column2.Checked = True Then
                    RadioButtonVarianceToLastYear_Exclude.Checked = True

                End If

                If RadioButtonYTDActualAmounts_Column2.Checked = True Then
                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column2.Checked = True Then
                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column2.Checked = True Then
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column2.Checked = True Then
                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonLastYearsActualAmounts_Column3_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonLastYearsActualAmounts_Column3.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column3.Checked = True Then
                    PanelVarianceToLastYear_Columns.Enabled = True
                    CheckBoxVarianceToLastYear_IncludeYearEndEntries.Enabled = True
                End If

                If RadioButtonVarianceToLastYear_Column3.Checked = True Then
                    RadioButtonVarianceToLastYear_Exclude.Checked = True

                End If

                If RadioButtonYTDActualAmounts_Column3.Checked = True Then
                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column3.Checked = True Then
                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column3.Checked = True Then
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column3.Checked = True Then
                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonLastYearsActualAmounts_Column4_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonLastYearsActualAmounts_Column4.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column4.Checked = True Then
                    PanelVarianceToLastYear_Columns.Enabled = True
                    CheckBoxVarianceToLastYear_IncludeYearEndEntries.Enabled = True
                End If

                If RadioButtonVarianceToLastYear_Column4.Checked = True Then
                    RadioButtonVarianceToLastYear_Exclude.Checked = True

                End If

                If RadioButtonYTDActualAmounts_Column4.Checked = True Then
                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column4.Checked = True Then
                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column4.Checked = True Then
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column4.Checked = True Then
                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonLastYearsActualAmounts_Column5_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonLastYearsActualAmounts_Column5.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column5.Checked = True Then
                    PanelVarianceToLastYear_Columns.Enabled = True
                    CheckBoxVarianceToLastYear_IncludeYearEndEntries.Enabled = True
                End If

                If RadioButtonVarianceToLastYear_Column5.Checked = True Then
                    RadioButtonVarianceToLastYear_Exclude.Checked = True

                End If

                If RadioButtonYTDActualAmounts_Column5.Checked = True Then
                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column5.Checked = True Then
                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column5.Checked = True Then
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column5.Checked = True Then
                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonLastYearsActualAmounts_Column6_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonLastYearsActualAmounts_Column6.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column6.Checked = True Then
                    PanelVarianceToLastYear_Columns.Enabled = True
                    CheckBoxVarianceToLastYear_IncludeYearEndEntries.Enabled = True
                End If

                If RadioButtonVarianceToLastYear_Column6.Checked = True Then
                    RadioButtonVarianceToLastYear_Exclude.Checked = True

                End If

                If RadioButtonYTDActualAmounts_Column6.Checked = True Then
                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column6.Checked = True Then
                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column6.Checked = True Then
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column6.Checked = True Then
                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonVarianceToLastYear_Column1_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToLastYear_Column1.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column1.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column1.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column1.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column1.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column1.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonVarianceToLastYear_Column2_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToLastYear_Column2.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column2.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column2.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column2.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column2.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column2.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonVarianceToLastYear_Column3_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToLastYear_Column3.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column3.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column3.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column3.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column3.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column3.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonVarianceToLastYear_Column4_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToLastYear_Column4.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column4.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column4.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column4.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column4.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column4.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonVarianceToLastYear_Column5_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToLastYear_Column5.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column5.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column5.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column5.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column5.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column5.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonVarianceToLastYear_Column6_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToLastYear_Column6.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column6.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column6.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column6.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column6.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column6.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonYTDActualAmounts_Column1_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonYTDActualAmounts_Column1.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column1.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column1.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column1.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column1.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column1.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonYTDActualAmounts_Column2_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonYTDActualAmounts_Column2.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column2.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column2.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column2.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column2.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column2.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonYTDActualAmounts_Column3_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonYTDActualAmounts_Column3.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column3.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column3.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column3.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column3.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column3.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonYTDActualAmounts_Column4_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonYTDActualAmounts_Column4.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column4.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column4.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column4.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column4.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column4.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonYTDActualAmounts_Column5_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonYTDActualAmounts_Column5.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column5.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column5.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column5.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column5.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column5.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonYTDActualAmounts_Column6_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonYTDActualAmounts_Column6.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column6.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column6.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column6.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column6.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column6.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If
        End Sub
        Private Sub RadioButtonCompareUsingCurrentBudget_Column1_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonCompareUsingCurrentBudget_Column1.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonCompareUsingCurrentBudget_Column1.Checked = True Then
                    PanelVarianceToCurrentBudget_Columns.Enabled = True

                End If

                If RadioButtonLastYearsActualAmounts_Column1.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column1.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column1.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column1.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column1.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If

            End If
        End Sub
        Private Sub RadioButtonCompareUsingCurrentBudget_Column2_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonCompareUsingCurrentBudget_Column2.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonCompareUsingCurrentBudget_Column2.Checked = True Then
                    PanelVarianceToCurrentBudget_Columns.Enabled = True
                End If

                If RadioButtonLastYearsActualAmounts_Column2.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column2.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column2.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column2.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column2.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If

            End If
        End Sub
        Private Sub RadioButtonCompareUsingCurrentBudget_Column3_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonCompareUsingCurrentBudget_Column3.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonCompareUsingCurrentBudget_Column3.Checked = True Then
                    PanelVarianceToCurrentBudget_Columns.Enabled = True
                End If

                If RadioButtonLastYearsActualAmounts_Column3.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column3.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column3.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column3.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column3.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If

            End If
        End Sub
        Private Sub RadioButtonCompareUsingCurrentBudget_Column4_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonCompareUsingCurrentBudget_Column4.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonCompareUsingCurrentBudget_Column4.Checked = True Then
                    PanelVarianceToCurrentBudget_Columns.Enabled = True
                End If

                If RadioButtonLastYearsActualAmounts_Column4.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column4.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column4.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column4.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column4.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If

            End If
        End Sub
        Private Sub RadioButtonCompareUsingCurrentBudget_Column5_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonCompareUsingCurrentBudget_Column5.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonCompareUsingCurrentBudget_Column5.Checked = True Then
                    PanelVarianceToCurrentBudget_Columns.Enabled = True
                End If

                If RadioButtonLastYearsActualAmounts_Column5.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column5.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column5.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column5.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column5.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If

            End If
        End Sub
        Private Sub RadioButtonCompareUsingCurrentBudget_Column6_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonCompareUsingCurrentBudget_Column6.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonCompareUsingCurrentBudget_Column6.Checked = True Then
                    PanelVarianceToCurrentBudget_Columns.Enabled = True
                End If

                If RadioButtonLastYearsActualAmounts_Column6.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column6.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column6.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column6.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column6.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If

            End If
        End Sub
        Private Sub RadioButtonVarianceToCurrentBudget_Column1_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToCurrentBudget_Column1.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column1.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column1.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column1.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column1.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column1.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If

        End Sub
        Private Sub RadioButtonVarianceToCurrentBudget_Column2_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToCurrentBudget_Column2.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column2.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column2.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column2.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column2.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column2.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If

        End Sub
        Private Sub RadioButtonVarianceToCurrentBudget_Column3_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToCurrentBudget_Column3.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column3.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column3.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column3.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column3.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column3.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If

        End Sub
        Private Sub RadioButtonVarianceToCurrentBudget_Column4_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToCurrentBudget_Column4.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column4.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column4.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column4.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column4.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column4.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If

        End Sub
        Private Sub RadioButtonVarianceToCurrentBudget_Column5_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToCurrentBudget_Column5.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column5.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column5.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column5.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column5.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column5.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If

        End Sub
        Private Sub RadioButtonVarianceToCurrentBudget_Column6_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonVarianceToCurrentBudget_Column6.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column6.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column6.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column6.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column6.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonClientBudget_Column6.Checked = True Then

                    RadioButtonClientBudget_Exclude.Checked = True
                End If
            End If

        End Sub
        Private Sub RadioButtonClientBudget_Column1_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonClientBudget_Column1.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column1.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column1.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column1.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column1.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column1.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

            End If

        End Sub
        Private Sub RadioButtonClientBudget_Column2_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonClientBudget_Column2.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column2.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column2.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column2.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column2.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column2.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

            End If

        End Sub
        Private Sub RadioButtonClientBudget_Column3_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonClientBudget_Column3.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column3.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column3.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column3.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column3.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column3.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

            End If

        End Sub
        Private Sub RadioButtonClientBudget_Column4_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonClientBudget_Column4.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column4.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column4.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column4.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column4.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column4.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

            End If

        End Sub
        Private Sub RadioButtonClientBudget_Column5_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonClientBudget_Column5.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column5.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column5.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column5.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column5.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column5.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

            End If

        End Sub
        Private Sub RadioButtonClientBudget_Column6_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonClientBudget_Column6.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonLastYearsActualAmounts_Column6.Checked = True Then

                    RadioButtonLastYearsActualAmounts_Exclude.Checked = True
                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonVarianceToLastYear_Column6.Checked = True Then

                    RadioButtonVarianceToLastYear_Exclude.Checked = True
                End If

                If RadioButtonYTDActualAmounts_Column6.Checked = True Then

                    RadioButtonYTDActualAmounts_Exclude.Checked = True
                End If

                If RadioButtonCompareUsingCurrentBudget_Column6.Checked = True Then

                    RadioButtonCompareUsingCurrentBudget_Exclude.Checked = True
                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

                If RadioButtonVarianceToCurrentBudget_Column6.Checked = True Then

                    RadioButtonVarianceToCurrentBudget_Exclude.Checked = True
                End If

            End If

        End Sub
        Private Sub ComboBoxDefaults_FiscalYearStartMonth_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxDefaults_FiscalYearStartMonth.SelectedValueChanged

            If ComboBoxDefaults_FiscalYearStartMonth.Text <> "January" Then

                RadioButtonPostingPeriodFormat_Option1.Enabled = True
                RadioButtonPostingPeriodFormat_Option2.Enabled = True

                RadioButtonFiscalYearOptions_BeginsInPrevious.Enabled = True
                RadioButtonFiscalYearOptions_BeginsInPrevious.Checked = True

                RadioButtonFiscalYearOptions_BeginsInCurrent.Enabled = True

            Else

                RadioButtonPostingPeriodFormat_Option1.Enabled = False
                RadioButtonPostingPeriodFormat_Option2.Enabled = False

                RadioButtonFiscalYearOptions_BeginsInPrevious.Checked = False
                RadioButtonFiscalYearOptions_BeginsInPrevious.Enabled = False
                RadioButtonFiscalYearOptions_BeginsInCurrent.Checked = False
                RadioButtonFiscalYearOptions_BeginsInCurrent.Enabled = False

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment1Base_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment1Base.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment1Base.Checked = True Then

                    TextBoxAccountCodeFormat_Segment1Description.Clear()
                    TextBoxAccountCodeFormat_Segment1Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment2Base_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment2Base.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment2Base.Checked = True Then

                    TextBoxAccountCodeFormat_Segment2Description.Clear()
                    TextBoxAccountCodeFormat_Segment2Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment3Base_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment3Base.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment3Base.Checked = True Then

                    TextBoxAccountCodeFormat_Segment3Description.Clear()
                    TextBoxAccountCodeFormat_Segment3Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment4Base_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment4Base.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment4Base.Checked = True Then

                    TextBoxAccountCodeFormat_Segment4Description.Clear()
                    TextBoxAccountCodeFormat_Segment4Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment1Office_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment1Office.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment1Office.Checked = True Then

                    TextBoxAccountCodeFormat_Segment1Description.Clear()
                    TextBoxAccountCodeFormat_Segment1Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment2Office_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment2Office.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment2Office.Checked = True Then

                    TextBoxAccountCodeFormat_Segment2Description.Clear()
                    TextBoxAccountCodeFormat_Segment2Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment3Office_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment3Office.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment3Office.Checked = True Then

                    TextBoxAccountCodeFormat_Segment3Description.Clear()
                    TextBoxAccountCodeFormat_Segment3Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment4Office_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment4Office.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment4Office.Checked = True Then

                    TextBoxAccountCodeFormat_Segment4Description.Clear()
                    TextBoxAccountCodeFormat_Segment4Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment1Department_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment1Department.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment1Department.Checked = True Then

                    TextBoxAccountCodeFormat_Segment1Description.Clear()
                    TextBoxAccountCodeFormat_Segment1Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment2Department_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment2Department.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment2Department.Checked = True Then

                    TextBoxAccountCodeFormat_Segment2Description.Clear()
                    TextBoxAccountCodeFormat_Segment2Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment3Department_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment3Department.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment3Department.Checked = True Then

                    TextBoxAccountCodeFormat_Segment3Description.Clear()
                    TextBoxAccountCodeFormat_Segment3Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment4Department_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment4Department.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment4Department.Checked = True Then

                    TextBoxAccountCodeFormat_Segment4Description.Clear()
                    TextBoxAccountCodeFormat_Segment4Description.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment1Other_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment1Other.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment1Other.Checked = True Then

                    TextBoxAccountCodeFormat_Segment1Description.ReadOnly = False
                    TextBoxAccountCodeFormat_Segment1Description.Enabled = True
                End If

            End If
        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment2Other_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment2Other.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment2Other.Checked = True Then

                    TextBoxAccountCodeFormat_Segment2Description.ReadOnly = False
                    TextBoxAccountCodeFormat_Segment2Description.Enabled = True
                End If

            End If
        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment3Other_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment3Other.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment3Other.Checked = True Then

                    TextBoxAccountCodeFormat_Segment3Description.ReadOnly = False
                    TextBoxAccountCodeFormat_Segment3Description.Enabled = True
                End If

            End If
        End Sub
        Private Sub RadioButtonAccountCodeFormat_Segment4Other_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonAccountCodeFormat_Segment4Other.CheckedChangedEx

            If e.NewChecked.Checked Then

                If RadioButtonAccountCodeFormat_Segment4Other.Checked = True Then

                    TextBoxAccountCodeFormat_Segment4Description.ReadOnly = False
                    TextBoxAccountCodeFormat_Segment4Description.Enabled = True
                End If

            End If
        End Sub
        Private Sub ButtonItemSegmentTypes_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemSegmentTypes_Edit.Click

            If _ViewModel.EditSegment = False Then

                _Controller.RefreshHasGLAccounts(_ViewModel)

                If _ViewModel.HasGLAccounts AndAlso AdvantageFramework.WinForm.MessageBox.Show("You have G/L codes in your Chart of Accounts, you will only be able to change the type of each segment." & vbCrLf &                                                          "Once you make your changes and update the database, the base, office, department and/or other segments will be changed in the Chart of Accounts." & vbCrLf &                                                          "Are you really sure you want to do this?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Change Format") = WinForm.MessageBox.DialogResults.Yes Then

                    _Controller.SetEditSegmentFlag(_ViewModel, True)

                    RefreshViewModel()

                Else

                    _Controller.SetEditSegmentFlag(_ViewModel, True)

                    RefreshViewModel()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace