Namespace Maintenance.Media.Presentation

    Public Class RateCardContractSetupForm

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

            'objects
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_RateCardContracts.DataSource = AdvantageFramework.Database.Procedures.RateCard.Load(DbContext).Include("Vendor").ToList

            End Using

            DataGridViewLeftSection_RateCardContracts.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            RateCardContractControlRightSection_RateCardContract.ClearControl()

            RateCardContractControlRightSection_RateCardContract.Enabled = DataGridViewLeftSection_RateCardContracts.HasOnlyOneSelectedRow

            If RateCardContractControlRightSection_RateCardContract.Enabled Then

                RateCardContractControlRightSection_RateCardContract.Enabled = RateCardContractControlRightSection_RateCardContract.LoadControl(DataGridViewLeftSection_RateCardContracts.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            RateCardContractControlRightSection_RateCardContract.Enabled = (DataGridViewLeftSection_RateCardContracts.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_RateCardContracts.HasOnlyOneSelectedRow AndAlso RateCardContractControlRightSection_RateCardContract.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemRateDetails_Cancel.Enabled = (RateCardContractControlRightSection_RateCardContract.Enabled AndAlso RateCardContractControlRightSection_RateCardContract.RateCardDetailsIsNewItemRow)
            ButtonItemRateDetails_Delete.Enabled = RateCardContractControlRightSection_RateCardContract.DataGridViewRateDetailsHasOnlyOneSelectedRow

            RibbonBarMergeContainerForm_RateDetails.Visible = If(RateCardContractControlRightSection_RateCardContract.SelectedTab Is RateCardContractControlRightSection_RateCardContract.TabItemRateCardDetails_RateDetailTab, True, False)
            RibbonBarMergeContainerForm_ColorCharges.Visible = If(RateCardContractControlRightSection_RateCardContract.SelectedTab Is RateCardContractControlRightSection_RateCardContract.TabItemRateCardDetails_ColorChargesTab, True, False)

            ButtonItemColorCharges_Cancel.Enabled = RateCardContractControlRightSection_RateCardContract.DataGridViewRateCardColorChargesIsNewItemRow
            ButtonItemColorCharges_Delete.Enabled = RateCardContractControlRightSection_RateCardContract.DataGridViewRateCardColorChargesHasOnlyOneSelectedRow

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = (RateCardContractControlRightSection_RateCardContract.Save())

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If Not IsOkay AndAlso AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                            IsOkay = False

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim RateCardContractSetupForm As AdvantageFramework.Maintenance.Media.Presentation.RateCardContractSetupForm = Nothing

            RateCardContractSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.RateCardContractSetupForm()

            RateCardContractSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RateCardContractSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemRateDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemRateDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemColorCharges_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemColorCharges_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            DataGridViewLeftSection_RateCardContracts.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_RateCardContracts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub RateCardContractSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub RateCardContractSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub RateCardContractSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_RateCardContracts.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_RateCardContracts_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_RateCardContracts.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_RateCardContracts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_RateCardContracts.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_RateCardContracts.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If RateCardContractControlRightSection_RateCardContract.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_RateCardContracts.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a rate card to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim RateCardID As Integer = Nothing
            Dim CanAdd As Boolean = True

            If DataGridViewLeftSection_RateCardContracts.HasOnlyOneSelectedRow Then

                CanAdd = CheckForUnsavedChanges()

            End If

            If CanAdd Then

                If AdvantageFramework.Maintenance.Media.Presentation.RateCardContractEditDialog.ShowFormDialog(RateCardID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_RateCardContracts.SelectRow(RateCardID)

                Else

                    LoadSelectedItemDetails()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_RateCardContracts.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If RateCardContractControlRightSection_RateCardContract.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a rate card to delete.")

            End If

        End Sub
        Private Sub RateCardContractControlRightSection_RateCardContract_RateCardColorChargesInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RateCardContractControlRightSection_RateCardContract.RateCardColorChargesInitNewRowEvent

            ButtonItemColorCharges_Cancel.Enabled = RateCardContractControlRightSection_RateCardContract.DataGridViewRateCardColorChargesIsNewItemRow
            ButtonItemColorCharges_Delete.Enabled = Not RateCardContractControlRightSection_RateCardContract.DataGridViewRateCardColorChargesIsNewItemRow

        End Sub
        Private Sub RateCardContractControlRightSection_RateCardContract_RateCardColorChargesSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles RateCardContractControlRightSection_RateCardContract.RateCardColorChargesSelectionChangedEvent

            ButtonItemColorCharges_Cancel.Enabled = RateCardContractControlRightSection_RateCardContract.DataGridViewRateCardColorChargesIsNewItemRow
            ButtonItemColorCharges_Delete.Enabled = Not RateCardContractControlRightSection_RateCardContract.DataGridViewRateCardColorChargesIsNewItemRow

        End Sub
        Private Sub RateCardContractControlRightSection_RateCardContract_RateCardDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RateCardContractControlRightSection_RateCardContract.RateCardDetailsInitNewRowEvent

            ButtonItemRateDetails_Cancel.Enabled = RateCardContractControlRightSection_RateCardContract.RateCardDetailsIsNewItemRow
            ButtonItemRateDetails_Delete.Enabled = Not RateCardContractControlRightSection_RateCardContract.RateCardDetailsIsNewItemRow

        End Sub
        Private Sub RateCardContractControlRightSection_RateCardContract_RateCardDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles RateCardContractControlRightSection_RateCardContract.RateCardDetailsSelectionChangedEvent

            ButtonItemRateDetails_Cancel.Enabled = RateCardContractControlRightSection_RateCardContract.RateCardDetailsIsNewItemRow
            ButtonItemRateDetails_Delete.Enabled = Not RateCardContractControlRightSection_RateCardContract.RateCardDetailsIsNewItemRow

        End Sub
        Private Sub ButtonItemRateDetails_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRateDetails_Cancel.Click

            RateCardContractControlRightSection_RateCardContract.CancelAddNewRateCardDetail()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemRateDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRateDetails_Delete.Click

            RateCardContractControlRightSection_RateCardContract.DeleteSelectedRateCardDetail()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemColorCharges_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemColorCharges_Cancel.Click

            RateCardContractControlRightSection_RateCardContract.CancelAddNewColorCharge()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemColorCharges_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemColorCharges_Delete.Click

            RateCardContractControlRightSection_RateCardContract.DeleteSelectedColorChargeDetail()
            EnableOrDisableActions()

        End Sub
        Private Sub RateCardContractControlRightSection_RateCardContract_RateCardInActiveChanged() Handles RateCardContractControlRightSection_RateCardContract.RateCardInActiveChanged

            LoadGrid()

            LoadSelectedItemDetails()

        End Sub
        Private Sub RateCardContractControlRightSection_RateCardContract_SelectedTabChanged() Handles RateCardContractControlRightSection_RateCardContract.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RateCardContractControlRightSection_RateCardContract_CommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles RateCardContractControlRightSection_RateCardContract.CommentGotFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub RateCardContractControlRightSection_RateCardContract_CommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles RateCardContractControlRightSection_RateCardContract.CommentLostFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf RateCardContractControlRightSection_RateCardContract.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(RateCardContractControlRightSection_RateCardContract.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.CheckForUnsavedChanges() Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    RateCardContractControlRightSection_RateCardContract.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_RateCardContracts.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace