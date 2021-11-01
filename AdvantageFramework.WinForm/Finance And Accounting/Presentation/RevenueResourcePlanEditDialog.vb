Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.EditViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property RevenueResourcePlanID As Integer
            Get
                RevenueResourcePlanID = _RevenueResourcePlanID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RevenueResourcePlanID = RevenueResourcePlanID

        End Sub
        Private Sub LoadViewModel()

            ComboBoxForm_Office.SelectedValue = _ViewModel.Plan.OfficeCode
            ComboBoxForm_Owner.SelectedValue = _ViewModel.Plan.OwnerCode

            ComboBoxForm_StartMonth.SelectedValue = _ViewModel.Plan.StartDate.Month.ToString
            ComboBoxForm_EndMonth.SelectedValue = _ViewModel.Plan.EndDate.Month.ToString
            NumericInputForm_StartYear.EditValue = _ViewModel.Plan.StartDate.Year
            NumericInputForm_EndYear.EditValue = _ViewModel.Plan.EndDate.Year

            TextBoxForm_Description.Text = _ViewModel.Plan.Description
            CheckBoxForm_Inactive.Checked = _ViewModel.Plan.IsInactive
            TextBoxForm_Notes.Text = _ViewModel.Plan.Notes

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.Plan.OfficeCode = ComboBoxForm_Office.GetSelectedValue
            _ViewModel.Plan.OwnerCode = ComboBoxForm_Owner.GetSelectedValue

            _ViewModel.Plan.StartDate = New Date(NumericInputForm_StartYear.EditValue, ComboBoxForm_StartMonth.GetSelectedValue, 1)
            _ViewModel.Plan.EndDate = New Date(NumericInputForm_EndYear.EditValue, ComboBoxForm_EndMonth.GetSelectedValue, Date.DaysInMonth(NumericInputForm_EndYear.EditValue, ComboBoxForm_EndMonth.GetSelectedValue))

            _ViewModel.Plan.Description = TextBoxForm_Description.Text
            _ViewModel.Plan.IsInactive = CheckBoxForm_Inactive.Checked
            _ViewModel.Plan.Notes = TextBoxForm_Notes.Text

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Visible = _ViewModel.AddVisible
            ButtonItemActions_Update.Visible = _ViewModel.UpdateVisible
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            'ComboBoxForm_Office.Enabled = _ViewModel.AddVisible
            'ComboBoxForm_Owner.Enabled = _ViewModel.AddVisible
            ComboBoxForm_StartMonth.Enabled = _ViewModel.AddVisible
            NumericInputForm_StartYear.Enabled = _ViewModel.AddVisible
            ComboBoxForm_EndMonth.Enabled = _ViewModel.AddVisible
            NumericInputForm_EndYear.Enabled = _ViewModel.AddVisible

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxForm_Office.DataSource = _ViewModel.Offices.ToList
            ComboBoxForm_Owner.DataSource = _ViewModel.Employees.ToList
            ComboBoxForm_StartMonth.DataSource = _ViewModel.Months.ToList
            ComboBoxForm_EndMonth.DataSource = _ViewModel.Months.ToList

        End Sub
        Private Sub SetControlPropertySettings()

            ComboBoxForm_Office.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.OfficeCode)
            ComboBoxForm_Owner.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.OwnerCode)

            'ComboBoxForm_StartMonth.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.StartDate)
            ComboBoxForm_StartMonth.SetPropertySettings(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.StartDate.ToString), GetType(Long), True)
            'ComboBoxForm_EndMonth.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.EndDate)
            ComboBoxForm_EndMonth.SetPropertySettings(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.EndDate.ToString), GetType(Long), True)
            NumericInputForm_StartYear.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.StartDate)
            NumericInputForm_EndYear.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.EndDate)

            NumericInputForm_StartYear.Properties.DisplayFormat.FormatString = "d4"
            NumericInputForm_StartYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            NumericInputForm_StartYear.Properties.EditFormat.FormatString = "f0"
            NumericInputForm_StartYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            NumericInputForm_StartYear.Properties.IsFloatValue = False
            NumericInputForm_StartYear.Properties.Mask.EditMask = "d4"
            NumericInputForm_StartYear.Properties.Mask.UseMaskAsDisplayFormat = True
            NumericInputForm_StartYear.Properties.MaxLength = 4
            NumericInputForm_StartYear.Properties.MaxValue = 9999
            NumericInputForm_StartYear.Properties.MinValue = 1000

            NumericInputForm_EndYear.Properties.DisplayFormat.FormatString = "d4"
            NumericInputForm_EndYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            NumericInputForm_EndYear.Properties.EditFormat.FormatString = "f0"
            NumericInputForm_EndYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            NumericInputForm_EndYear.Properties.IsFloatValue = False
            NumericInputForm_EndYear.Properties.Mask.EditMask = "d4"
            NumericInputForm_EndYear.Properties.Mask.UseMaskAsDisplayFormat = True
            NumericInputForm_EndYear.Properties.MaxLength = 4
            NumericInputForm_EndYear.Properties.MaxValue = 9999
            NumericInputForm_EndYear.Properties.MinValue = 1000

            TextBoxForm_Description.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.Description)
            TextBoxForm_Notes.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.Notes)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef RevenueResourcePlanID As Integer = 0) As System.Windows.Forms.DialogResult

            'objects
            Dim RevenueResourcePlanEditDialog As RevenueResourcePlanEditDialog = Nothing

            RevenueResourcePlanEditDialog = New RevenueResourcePlanEditDialog(RevenueResourcePlanID)

            ShowFormDialog = RevenueResourcePlanEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                RevenueResourcePlanID = RevenueResourcePlanEditDialog.RevenueResourcePlanID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.Edit_Load(_RevenueResourcePlanID)

            SetControlDataSources()

            LoadViewModel()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RevenueResourcePlanEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                SaveViewModel()

                If _Controller.Edit_ValidateDates(_ViewModel, ErrorMessage) Then

                    _Controller.Edit_Add(_ViewModel, ErrorMessage)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        _RevenueResourcePlanID = _ViewModel.Plan.ID

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

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
        Private Sub ButtonItemActions_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                SaveViewModel()

                _Controller.Edit_Save(_ViewModel, ErrorMessage)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
