Namespace Maintenance.Accounting.Presentation

    Public Class PTORuleSetupForm

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

                DataGridViewLeftSection_PTORules.DataSource = AdvantageFramework.Database.Procedures.PTORule.Load(DbContext).OrderBy(Function(Entity) Entity.Name).ToList

            End Using

            DataGridViewLeftSection_PTORules.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            PTORuleControlRightSection_PTORule.ClearControl()

            PTORuleControlRightSection_PTORule.Enabled = DataGridViewLeftSection_PTORules.HasOnlyOneSelectedRow

            If PTORuleControlRightSection_PTORule.Enabled Then

                PTORuleControlRightSection_PTORule.Enabled = PTORuleControlRightSection_PTORule.LoadControl(DataGridViewLeftSection_PTORules.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            PTORuleControlRightSection_PTORule.Enabled = (DataGridViewLeftSection_PTORules.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_PTORules.HasOnlyOneSelectedRow AndAlso PTORuleControlRightSection_PTORule.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemDetails_Cancel.Enabled = (PTORuleControlRightSection_PTORule.Enabled AndAlso PTORuleControlRightSection_PTORule.PTORuleDetailsIsNewItemRow(PTORuleControlRightSection_PTORule.PTORuleDetailsFocusedRowHandle))

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = PTORuleControlRightSection_PTORule.Save()

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

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim PTORuleSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.PTORuleSetupForm = Nothing

            PTORuleSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.PTORuleSetupForm

            PTORuleSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PTORuleSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_PTORules.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_PTORules.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub PTORuleSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PTORuleSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PTORuleSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_PTORules.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_PTORules_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_PTORules.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_PTORules_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_PTORules.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_PTORules.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If PTORuleControlRightSection_PTORule.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_PTORules.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a PTO Rule to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim PTORuleID As Integer = Nothing
            Dim CanAdd As Boolean = True

            If DataGridViewLeftSection_PTORules.HasOnlyOneSelectedRow Then

                CanAdd = CheckForUnsavedChanges()

            End If

            If CanAdd Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.PTORuleEditDialog.ShowFormDialog(PTORuleID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_PTORules.SelectRow(PTORuleID)

                Else

                    LoadSelectedItemDetails()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_PTORules.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If PTORuleControlRightSection_PTORule.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a PTO Rule to delete.")

            End If

        End Sub
        Private Sub PTORuleControlRightSection_PTORule_PTORuleDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles PTORuleControlRightSection_PTORule.PTORuleDetailsInitNewRowEvent

            ButtonItemDetails_Cancel.Enabled = True
            ButtonItemDetails_Delete.Enabled = False

        End Sub
        Private Sub PTORuleControlRightSection_PTORule_PTORuleDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles PTORuleControlRightSection_PTORule.PTORuleDetailsSelectionChangedEvent

            If PTORuleControlRightSection_PTORule.PTORuleDetailsHasOnlyOneSelectedRow(False) Then

                If PTORuleControlRightSection_PTORule.PTORuleDetailsIsNewItemRow(PTORuleControlRightSection_PTORule.PTORuleDetailsFocusedRowHandle) Then

                    ButtonItemDetails_Cancel.Enabled = True
                    ButtonItemDetails_Delete.Enabled = False

                Else

                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Delete.Enabled = True

                End If

            Else

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = PTORuleControlRightSection_PTORule.PTORuleDetailsHasRows

            End If

        End Sub
        Private Sub PTORuleControlRightSection_PTORule_PTORuleInActiveChanged() Handles PTORuleControlRightSection_PTORule.PTORuleInActiveChanged

            LoadGrid()

            LoadSelectedItemDetails()

        End Sub
        Private Sub ButtonItemPTORuleDetails_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            PTORuleControlRightSection_PTORule.PTORuleDetailsCancelNewItemRow()

            If PTORuleControlRightSection_PTORule.PTORuleDetailsHasOnlyOneSelectedRow() = True Then

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = PTORuleControlRightSection_PTORule.PTORuleDetailsHasRows

            End If

        End Sub
        Private Sub ButtonItemPTORuleDetails_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            PTORuleControlRightSection_PTORule.DeletePTORuleDetails()

        End Sub

#End Region

#End Region

    End Class

End Namespace