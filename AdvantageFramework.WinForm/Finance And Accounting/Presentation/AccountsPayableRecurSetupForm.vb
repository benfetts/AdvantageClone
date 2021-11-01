Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableRecurSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_APRecur.DataSource = AdvantageFramework.Database.Procedures.AccountPayableRecur.LoadWithOfficeLimits(DbContext, Session).ToList

            End Using

            DataGridViewLeftSection_APRecur.CurrentView.Columns(AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.ID.ToString).Visible = False
            DataGridViewLeftSection_APRecur.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                AccountsPayableRecurRightSection_APRecur.ClearControl()

                AccountsPayableRecurRightSection_APRecur.Enabled = DataGridViewLeftSection_APRecur.HasOnlyOneSelectedRow

                If AccountsPayableRecurRightSection_APRecur.Enabled Then

                    AccountsPayableRecurRightSection_APRecur.Enabled = AccountsPayableRecurRightSection_APRecur.LoadControl(Nothing, DataGridViewLeftSection_APRecur.GetFirstSelectedRowBookmarkValue)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            AccountsPayableRecurRightSection_APRecur.Enabled = (DataGridViewLeftSection_APRecur.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemDistribution_Cancel.Enabled = AccountsPayableRecurRightSection_APRecur.Enabled AndAlso AccountsPayableRecurRightSection_APRecur.DataGridViewDistributionDetailsIsNewItemRow
            ButtonItemDistribution_Delete.Enabled = AccountsPayableRecurRightSection_APRecur.Enabled AndAlso AccountsPayableRecurRightSection_APRecur.DataGridViewDistributionDetailsHasOnlyOneSelectedRow

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(AccountsPayableRecurRightSection_APRecur) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = AccountsPayableRecurRightSection_APRecur.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    Else

                        For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                            ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                        Next

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Else

                    AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(AccountsPayableRecurRightSection_APRecur)

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_APRecur.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If AccountsPayableRecurRightSection_APRecur.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_APRecur.FocusToFindPanel(False)

                        DataGridViewLeftSection_APRecur.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an AP Recur to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AccountsPayableRecurSetupForm As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurSetupForm = Nothing

            AccountsPayableRecurSetupForm = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurSetupForm()

            AccountsPayableRecurSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableRecurSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = (AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(AccountsPayableRecurRightSection_APRecur) And AccountsPayableRecurRightSection_APRecur.NumericInputDistribution_Balance.EditValue = 0)

        End Sub
        Private Sub AccountsPayableRecurSetupForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.MdiFormClosing Then

                AccountsPayableRecurRightSection_APRecur.CancelAddNewRecurGL()

            End If

        End Sub
        Private Sub AccountsPayableRecurSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            ButtonItemDistribution_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDistribution_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            DataGridViewLeftSection_APRecur.MultiSelect = False

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub AccountsPayableRecurSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            LoadGrid()

            DataGridViewLeftSection_APRecur.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            DataGridViewLeftSection_APRecur.FocusToFindPanel(True)

            AccountsPayableRecurRightSection_APRecur.ClearControl()
            AccountsPayableRecurRightSection_APRecur.Enabled = False

            Me.SuperValidator.ClearFailedValidations()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub AccountsPayableRecurSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = (AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(AccountsPayableRecurRightSection_APRecur) And AccountsPayableRecurRightSection_APRecur.NumericInputDistribution_Balance.EditValue = 0)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_APRecur_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_APRecur.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_APRecur_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_APRecur.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub AccountsPayableRecurRightSection_APRecur_InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean) Handles AccountsPayableRecurRightSection_APRecur.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub AccountsPayableRecurRightSection_APRecur_RecurGLInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRecurRightSection_APRecur.RecurGLInitNewRowEvent

            ButtonItemDistribution_Cancel.Enabled = AccountsPayableRecurRightSection_APRecur.DataGridViewDistributionDetailsIsNewItemRow
            ButtonItemDistribution_Delete.Enabled = Not AccountsPayableRecurRightSection_APRecur.DataGridViewDistributionDetailsIsNewItemRow

        End Sub
        Private Sub AccountsPayableRecurRightSection_APRecur_RecurGLSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountsPayableRecurRightSection_APRecur.RecurGLSelectionChangedEvent

            ButtonItemDistribution_Cancel.Enabled = AccountsPayableRecurRightSection_APRecur.DataGridViewDistributionDetailsIsNewItemRow
            ButtonItemDistribution_Delete.Enabled = (Not AccountsPayableRecurRightSection_APRecur.DataGridViewDistributionDetailsIsNewItemRow) AndAlso AccountsPayableRecurRightSection_APRecur.DataGridViewDistributionDetailsHasRows

        End Sub
        Private Sub AccountsPayableRecurRightSection_APRecur_TotalsChanged(ByVal Balance As Decimal, ByVal DetailRecordsExist As Boolean) Handles AccountsPayableRecurRightSection_APRecur.TotalsChanged

            EnableOrDisableActions()
            ButtonItemActions_Save.Enabled = (AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(AccountsPayableRecurRightSection_APRecur) AndAlso Balance = 0 AndAlso DetailRecordsExist)

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            Dim AccountPayableRecurID As Integer = 0
            Dim VendorCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_APRecur.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If Me.AccountsPayableRecurRightSection_APRecur.Enabled AndAlso DataGridViewLeftSection_APRecur.HasOnlyOneSelectedRow Then

                    VendorCode = DataGridViewLeftSection_APRecur.CurrentView.GetRowCellValue(DataGridViewLeftSection_APRecur.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.VendorCode.ToString)

                End If

                If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurEditDialog.ShowFormDialog(VendorCode, AccountPayableRecurID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_APRecur.SelectRow(AccountPayableRecurID)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_APRecur.CurrentView.GridViewSelectionChanged()

                    DataGridViewLeftSection_APRecur.FocusToFindPanel(False)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemDistribution_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDistribution_Cancel.Click

            AccountsPayableRecurRightSection_APRecur.CancelAddNewRecurGL()

        End Sub
        Private Sub ButtonItemDistribution_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDistribution_Delete.Click

            AccountsPayableRecurRightSection_APRecur.DeleteSelectedRecurGL()

        End Sub

#End Region

#End Region

    End Class

End Namespace