Namespace Maintenance.Accounting.Presentation

    Public Class ClientDiscountSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Accounting.ClientDiscountSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load()

        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_ClientDiscounts.CurrentView.BeginUpdate()

            DataGridViewLeftSection_ClientDiscounts.DataSource = _ViewModel.ClientDiscounts

            DataGridViewLeftSection_ClientDiscounts.CurrentView.EndUpdate()

        End Sub
        Private Sub LoadControl()

            ClientDiscountControlRightSection_ClientDiscount.ClearControl()

            If _ViewModel.HasASelectedClientDiscount Then

                ClientDiscountControlRightSection_ClientDiscount.Enabled = True

                ClientDiscountControlRightSection_ClientDiscount.LoadControl(_ViewModel.SelectedClientDiscount.Code)

            Else

                ClientDiscountControlRightSection_ClientDiscount.Enabled = False

            End If

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Refresh.Enabled = _ViewModel.RefreshEnabled

            ButtonItemDetails_Delete.Enabled = ClientDiscountControlRightSection_ClientDiscount.ViewModel.ClientDiscountExclusions_DeleteEnabled
            ButtonItemDetails_Cancel.Enabled = ClientDiscountControlRightSection_ClientDiscount.ViewModel.ClientDiscountExclusions_CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewLeftSection_ClientDiscounts.OptionsBehavior.Editable = False
            DataGridViewLeftSection_ClientDiscounts.OptionsSelection.MultiSelect = False

            DataGridViewLeftSection_ClientDiscounts.ItemDescription = "Discount(s)"

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DiscountSetupForm As Maintenance.Accounting.Presentation.ClientDiscountSetupForm = Nothing

            DiscountSetupForm = New Maintenance.Accounting.Presentation.ClientDiscountSetupForm()

            DiscountSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DiscountSetupForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.ClientDiscountSetupController(Me.Session)

        End Sub
        Private Sub DiscountSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            LoadControl()

            RefreshViewModel()

            DataGridViewLeftSection_ClientDiscounts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Me.ClearChanged()

            DataGridViewLeftSection_ClientDiscounts.CurrentView.BestFitColumns()

            DataGridViewLeftSection_ClientDiscounts.FocusToFindPanel(False)

            DataGridViewLeftSection_ClientDiscounts.HideRowSelection()

        End Sub
        Private Sub DiscountSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DiscountSetupForm_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim ClientDiscountCode As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        ClientDiscountControlRightSection_ClientDiscount.Save()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If ClientDiscountEditDialog.ShowFormDialog(ClientDiscountCode) = Windows.Forms.DialogResult.OK Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        _Controller.LoadClientDiscounts(_ViewModel)

                        LoadGrid()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewLeftSection_ClientDiscounts.SelectRow(AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount.Properties.Code.ToString, ClientDiscountCode, True)

                        DataGridViewLeftSection_ClientDiscounts.GridViewSelectionChanged()

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    ClientDiscountControlRightSection_ClientDiscount.Save()

                    _ViewModel.SelectedClientDiscount.Name = ClientDiscountControlRightSection_ClientDiscount.ViewModel.ClientDiscount.Name
                    _ViewModel.SelectedClientDiscount.Percent = ClientDiscountControlRightSection_ClientDiscount.ViewModel.ClientDiscount.Percent
                    _ViewModel.SelectedClientDiscount.IsInactive = ClientDiscountControlRightSection_ClientDiscount.ViewModel.ClientDiscount.IsInactive

                    DataGridViewLeftSection_ClientDiscounts.CurrentView.RefreshData()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    If DataGridViewLeftSection_ClientDiscounts.CurrentView.GetFocusedRow Is Nothing Then

                        DataGridViewLeftSection_ClientDiscounts.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this discount?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If ClientDiscountControlRightSection_ClientDiscount.Delete(ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        _Controller.LoadClientDiscounts(_ViewModel)

                        LoadGrid()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewLeftSection_ClientDiscounts.GridViewSelectionChanged()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            'objects
            Dim [Continue] As Boolean = False

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        ClientDiscountControlRightSection_ClientDiscount.Save()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    _Controller.LoadClientDiscounts(_ViewModel)

                    LoadGrid()

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_ClientDiscounts.GridViewSelectionChanged()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                ClientDiscountControlRightSection_ClientDiscount.DiscountExclusions_CancelNewItemRow()

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                ClientDiscountControlRightSection_ClientDiscount.DiscountExclusions_Delete()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_ClientDiscounts_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_ClientDiscounts.FocusedRowChangedEvent

            'objects
            Dim [Continue] As Boolean = False

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        ClientDiscountControlRightSection_ClientDiscount.Save()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        DataGridViewLeftSection_ClientDiscounts.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    _Controller.SelectedDiscountChanged(_ViewModel, DataGridViewLeftSection_ClientDiscounts.GetFirstSelectedRowDataBoundItem())

                    LoadControl()

                    RefreshViewModel()

                    Me.ClearChanged()

                End If

            End If

        End Sub
        Private Sub ClientDiscountControlRightSection_ClientDiscount_Exclusions_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ClientDiscountControlRightSection_ClientDiscount.Exclusions_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub ClientDiscountControlRightSection_ClientDiscount_Exclusions_SelectionChangedEvent(sender As Object, e As EventArgs) Handles ClientDiscountControlRightSection_ClientDiscount.Exclusions_SelectionChangedEvent

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace