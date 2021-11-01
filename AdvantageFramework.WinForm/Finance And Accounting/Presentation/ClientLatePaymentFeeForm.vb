Namespace FinanceAndAccounting.Presentation

    Public Class ClientLatePaymentFeeForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.ClientLatePaymentFeeViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.ClientLatePaymentFeeController = Nothing
        Protected _BatchDate As Date = Now

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub CalculateLateFees()

            Me.ShowWaitForm("Refreshing...")

            _Controller.CalculateLateFees(_ViewModel)

            DataGridViewForm_LateFees.DataSource = _ViewModel.ClientLateFeeInvoices

            ToggleVisibleColumns()

            Me.CloseWaitForm()

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load()

            Me.SearchableComboBoxForm_PostPeriodCutoff.DataSource = _ViewModel.OpenARPostPeriods
            Me.SearchableComboBoxForm_FeePostPeriod.DataSource = _ViewModel.OpenARPostPeriods

            If _ViewModel.CurrentARPostPeriod IsNot Nothing Then

                Me.SearchableComboBoxForm_PostPeriodCutoff.EditValue = _ViewModel.CurrentARPostPeriod.Code
                Me.SearchableComboBoxForm_FeePostPeriod.EditValue = _ViewModel.CurrentARPostPeriod.Code

            End If

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.AgingDate = DateTimePickerForm_AgingDate.GetValue
            _ViewModel.PostPeriodCode = SearchableComboBoxForm_PostPeriodCutoff.GetSelectedValue
            _ViewModel.FeeInvoiceDate = DateTimePickerForm_FeeInvoiceDate.GetValue
            _ViewModel.FeePostPeriodCode = SearchableComboBoxForm_FeePostPeriod.GetSelectedValue

        End Sub
        Private Sub ToggleVisibleColumns()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim IsVisible As Boolean = False

            IsVisible = ButtonItemView_ShowDescriptions.Checked

            For Each GridColumn In DataGridViewForm_LateFees.Columns

                If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice), GridColumn.FieldName) Then

                    If (GridColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.OfficeName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.ProductName.ToString) AndAlso Not IsVisible Then

                        GridColumn.VisibleIndex = -1
                        GridColumn.Visible = False

                    Else

                        GridColumn.VisibleIndex = VisibleIndex
                        VisibleIndex += 1
                        GridColumn.Visible = True

                    End If

                End If

            Next

            DataGridViewForm_LateFees.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientLatePaymentFeeForm As FinanceAndAccounting.Presentation.ClientLatePaymentFeeForm = Nothing

            ClientLatePaymentFeeForm = New FinanceAndAccounting.Presentation.ClientLatePaymentFeeForm

            ClientLatePaymentFeeForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientLatePaymentFeeForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DateTimePickerForm_AgingDate.SetRequired(True)
            DateTimePickerForm_FeeInvoiceDate.SetRequired(True)
            SearchableComboBoxForm_PostPeriodCutoff.SetRequired(True)
            SearchableComboBoxForm_FeePostPeriod.SetRequired(True)

            ButtonItemActions_Post.Image = AdvantageFramework.My.Resources.AccountsPayablePostRecurringImage

            ButtonItemView_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage

            DateTimePickerForm_FeeInvoiceDate.Value = Now.ToShortDateString

            DateTimePickerForm_AgingDate.Value = Now.ToShortDateString

            DataGridViewForm_LateFees.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        End Sub
        Private Sub ClientLatePaymentFeeForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.ClientLatePaymentFeeController(Me.Session)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Post_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Post.Click

            Dim ContinueInsert As Boolean = True
            Dim ClientLateFeeInvoices As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice) = Nothing
            Dim ErrorMessage As String = Nothing

            SaveViewModel()

            If Me.Validator Then

                ClientLateFeeInvoices = DataGridViewForm_LateFees.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice).Where(Function(Entity) Entity.CreateInvoice = True).ToList

                If ClientLateFeeInvoices IsNot Nothing AndAlso ClientLateFeeInvoices.Count > 0 Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You are about to post invoices with an invoice date of " & _ViewModel.FeeInvoiceDate.ToShortDateString & " and post period of " & _ViewModel.FeePostPeriodCode & ".  Continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                        If _Controller.IsDateOutsidePostPeriod(_ViewModel) Then

                            If AdvantageFramework.WinForm.MessageBox.Show("The invoice date is outside of normal range based on the posting period selected, are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.No Then

                                ContinueInsert = False
                                DateTimePickerForm_FeeInvoiceDate.Focus()

                            End If

                        End If

                        If ContinueInsert Then

                            If ClientLateFeeInvoices IsNot Nothing AndAlso ClientLateFeeInvoices.Count > 0 Then

                                If Not _Controller.Post(ClientLateFeeInvoices, _ViewModel, _BatchDate) Then

                                    AdvantageFramework.WinForm.MessageBox.Show("One or more invoices failed to save.")

                                End If

                                CalculateLateFees()

                            End If

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Nothing selected.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemCreateInvoice_CheckAll_Click(sender As Object, e As EventArgs) Handles ButtonItemCreateInvoice_CheckAll.Click

            For Each ClientLateFeeInvoice In DataGridViewForm_LateFees.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice)

                If ClientLateFeeInvoice.InvoiceCreatedForPostPeriod = False AndAlso Not ClientLateFeeInvoice.HasError Then

                    ClientLateFeeInvoice.CreateInvoice = True

                End If

            Next

            DataGridViewForm_LateFees.CurrentView.RefreshEditor(True)
            DataGridViewForm_LateFees.CurrentView.RefreshData()

        End Sub
        Private Sub ButtonItemCreateInvoice_UncheckAll_Click(sender As Object, e As EventArgs) Handles ButtonItemCreateInvoice_UncheckAll.Click

            For Each ClientLateFeeInvoice In DataGridViewForm_LateFees.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice)

                If ClientLateFeeInvoice.InvoiceCreatedForPostPeriod = False AndAlso Not ClientLateFeeInvoice.HasError Then

                    ClientLateFeeInvoice.CreateInvoice = False

                End If

            Next

            DataGridViewForm_LateFees.CurrentView.RefreshEditor(True)
            DataGridViewForm_LateFees.CurrentView.RefreshData()

        End Sub
        Private Sub ButtonItemView_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ShowDescriptions.CheckedChanged

            ToggleVisibleColumns()

        End Sub
        Private Sub DataGridViewForm_LateFees_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_LateFees.ShowingEditorEvent

            If DataGridViewForm_LateFees.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice.Properties.CreateInvoice.ToString Then

                If DirectCast(DataGridViewForm_LateFees.GetRowDataBoundItem(DataGridViewForm_LateFees.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice).HasError Then

                    e.Cancel = True

                ElseIf DirectCast(DataGridViewForm_LateFees.GetRowDataBoundItem(DataGridViewForm_LateFees.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice).InvoiceCreatedForPostPeriod Then

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub DateTimePickerForm_AgingDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerForm_AgingDate.ValueChanged

            If Me.FormShown AndAlso IsDate(DateTimePickerForm_AgingDate.GetValue) Then

                SaveViewModel()

                CalculateLateFees()

            End If

        End Sub
        Private Sub SearchableComboBoxForm_FeePostPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_FeePostPeriod.EditValueChanged

            If Me.FormShown AndAlso SearchableComboBoxForm_FeePostPeriod.HasASelectedValue AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                SaveViewModel()

                CalculateLateFees()

            End If

        End Sub
        Private Sub SearchableComboBoxForm_PostPeriodFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_PostPeriodCutoff.EditValueChanged

            If Me.FormShown AndAlso SearchableComboBoxForm_PostPeriodCutoff.HasASelectedValue Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Recalculating

                SearchableComboBoxForm_FeePostPeriod.SelectedValue = SearchableComboBoxForm_PostPeriodCutoff.GetSelectedValue

                SaveViewModel()

                CalculateLateFees()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
