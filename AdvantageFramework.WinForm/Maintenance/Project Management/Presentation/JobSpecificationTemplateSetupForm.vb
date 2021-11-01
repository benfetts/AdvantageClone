Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobSpecificationTemplateSetupForm

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

                DataGridViewLeftSection_JobSpecificationTypes.DataSource = AdvantageFramework.Database.Procedures.JobSpecificationType.Load(DbContext).ToList

                DataGridViewLeftSection_JobSpecificationTypes.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            JobSpecificationTemplateControlRightSection_JobSpecification.ClearControl()

            JobSpecificationTemplateControlRightSection_JobSpecification.Enabled = DataGridViewLeftSection_JobSpecificationTypes.HasOnlyOneSelectedRow

            If JobSpecificationTemplateControlRightSection_JobSpecification.Enabled Then

                JobSpecificationTemplateControlRightSection_JobSpecification.Enabled = JobSpecificationTemplateControlRightSection_JobSpecification.LoadControl(DataGridViewLeftSection_JobSpecificationTypes.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            JobSpecificationTemplateControlRightSection_JobSpecification.Enabled = (DataGridViewLeftSection_JobSpecificationTypes.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_JobSpecificationTypes.HasOnlyOneSelectedRow AndAlso JobSpecificationTemplateControlRightSection_JobSpecification.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemCategories_Delete.Enabled = (JobSpecificationTemplateControlRightSection_JobSpecification.CanDeleteCategory AndAlso JobSpecificationTemplateControlRightSection_JobSpecification.Enabled)
            ButtonItemCategories_Add.Enabled = (DataGridViewLeftSection_JobSpecificationTypes.HasOnlyOneSelectedRow AndAlso JobSpecificationTemplateControlRightSection_JobSpecification.Enabled)
            ButtonItemCategories_Activate.Enabled = If(JobSpecificationTemplateControlRightSection_JobSpecification.SelectedJobSpecificationCategory IsNot Nothing, Convert.ToBoolean(JobSpecificationTemplateControlRightSection_JobSpecification.SelectedJobSpecificationCategory.IsInactive), False)
            ButtonItemCategories_Deactivate.Enabled = If(JobSpecificationTemplateControlRightSection_JobSpecification.SelectedJobSpecificationCategory IsNot Nothing, Not Convert.ToBoolean(JobSpecificationTemplateControlRightSection_JobSpecification.SelectedJobSpecificationCategory.IsInactive), False)
            ButtonItemCategories_Rename.Enabled = If(JobSpecificationTemplateControlRightSection_JobSpecification.SelectedJobSpecificationCategory IsNot Nothing, True, False)

            ButtonItemFields_MoveDown.Enabled = If(JobSpecificationTemplateControlRightSection_JobSpecification.SelectedJobSpecificationCategory IsNot Nothing, JobSpecificationTemplateControlRightSection_JobSpecification.CanMoveItemDown, False)
            ButtonItemFields_MoveUp.Enabled = If(JobSpecificationTemplateControlRightSection_JobSpecification.SelectedJobSpecificationCategory IsNot Nothing, JobSpecificationTemplateControlRightSection_JobSpecification.CanMoveItemUp, False)
            ButtonItemFields_Move.Enabled = If(JobSpecificationTemplateControlRightSection_JobSpecification.SelectedJobSpecificationCategory IsNot Nothing, JobSpecificationTemplateControlRightSection_JobSpecification.CanMoveToNewCategory, False)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            JobSpecificationTemplateControlRightSection_JobSpecification.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

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
            Dim JobSpecificationTemplateSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobSpecificationTemplateSetupForm = Nothing

            JobSpecificationTemplateSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobSpecificationTemplateSetupForm()

            JobSpecificationTemplateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub JobSpecificationTemplateSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemCategories_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemCategories_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemCategories_Deactivate.Image = AdvantageFramework.My.Resources.PowerCancelImage
            ButtonItemCategories_Activate.Image = AdvantageFramework.My.Resources.PowerOnImage
            ButtonItemCategories_Rename.Image = AdvantageFramework.My.Resources.MaintenanceImage

            ButtonItemFields_MoveDown.Image = AdvantageFramework.My.Resources.DownImage
            ButtonItemFields_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemFields_Move.Image = AdvantageFramework.My.Resources.RightImage

            DataGridViewLeftSection_JobSpecificationTypes.MultiSelect = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_JobSpecificationTypes.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub JobSpecificationTemplateSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JobSpecificationTemplateSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JobSpecificationTemplateSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_JobSpecificationTypes.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_JobSpecificationTypes_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_JobSpecificationTypes.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobSpecificationTypes_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_JobSpecificationTypes.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_JobSpecificationTypes.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        JobSpecificationTemplateControlRightSection_JobSpecification.Save()

                        Me.ClearChanged()

                        LoadGrid()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_JobSpecificationTypes.FocusToFindPanel(False)

                        DataGridViewLeftSection_JobSpecificationTypes.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a job specification template to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim JobSpecificationTypeCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_JobSpecificationTypes.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobSpecificationTemplateEditDialog.ShowFormDialog(JobSpecificationTypeCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_JobSpecificationTypes.SelectRow(JobSpecificationTypeCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim JobSpecificationTypeCode As String = Nothing
            Dim ContinueCopy As Boolean = True

            If DataGridViewLeftSection_JobSpecificationTypes.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

                If ContinueCopy Then

                    JobSpecificationTypeCode = DataGridViewLeftSection_JobSpecificationTypes.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobSpecificationTemplateEditDialog.ShowFormDialog(JobSpecificationTypeCode, True) = Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        DataGridViewLeftSection_JobSpecificationTypes.SelectRow(JobSpecificationTypeCode)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_JobSpecificationTypes.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        JobSpecificationTemplateControlRightSection_JobSpecification.Delete()

                        LoadGrid()

                        LoadSelectedItemDetails()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a job specification template to delete.")

            End If

        End Sub
        Private Sub ButtonItemCategories_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCategories_Add.Click

            JobSpecificationTemplateControlRightSection_JobSpecification.ButtonRightSection_AddCategory.PerformClick()

        End Sub
        Private Sub ButtonItemCategories_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCategories_Delete.Click

            JobSpecificationTemplateControlRightSection_JobSpecification.DeletedSelectedCategory()

        End Sub
        Private Sub JobSpecificationTemplateControlRightSection_JobSpecification_CategoriesChangedEvent() Handles JobSpecificationTemplateControlRightSection_JobSpecification.CategoriesChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemCategories_Rename_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCategories_Rename.Click

            JobSpecificationTemplateControlRightSection_JobSpecification.RenameCategory()

        End Sub
        Private Sub ButtonItemCategories_Activate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCategories_Activate.Click

            JobSpecificationTemplateControlRightSection_JobSpecification.ActivateOrDectivateCategory(True)

        End Sub
        Private Sub ButtonItemCategories_Deactivate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCategories_Deactivate.Click

            JobSpecificationTemplateControlRightSection_JobSpecification.ActivateOrDectivateCategory(False)

        End Sub
        Private Sub JobSpecificationTemplateControlRightSection_JobSpecification_SelectedCategoryChangedEvent() Handles JobSpecificationTemplateControlRightSection_JobSpecification.SelectedCategoryChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub JobSpecificationTemplateControlRightSection_JobSpecification_SelectedFieldChangedEvent() Handles JobSpecificationTemplateControlRightSection_JobSpecification.SelectedFieldChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemFields_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonItemFields_MoveDown.Click

            JobSpecificationTemplateControlRightSection_JobSpecification.MoveDownSelectedItem()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemFields_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonItemFields_MoveUp.Click

            JobSpecificationTemplateControlRightSection_JobSpecification.MoveUpSelectedItem()

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

        Private Sub ButtonItemFields_Move_Click(sender As Object, e As EventArgs) Handles ButtonItemFields_Move.Click

            If DataGridViewLeftSection_JobSpecificationTypes.HasASelectedRow Then

                If CheckForUnsavedChanges() Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If JobSpecificationTemplateControlRightSection_JobSpecification.MoveItemToNewCategory() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a job specification template.")

            End If

        End Sub

    End Class

End Namespace