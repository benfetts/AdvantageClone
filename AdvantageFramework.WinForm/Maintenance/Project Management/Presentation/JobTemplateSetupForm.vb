Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobTemplateSetupForm

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

                DataGridViewLeftSection_JobTemplates.DataSource = AdvantageFramework.Database.Procedures.JobTemplate.Load(DbContext).ToList

                DataGridViewLeftSection_JobTemplates.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            JobTemplateControlRightSection_JobTemplate.ClearControl()

            JobTemplateControlRightSection_JobTemplate.Enabled = DataGridViewLeftSection_JobTemplates.HasOnlyOneSelectedRow

            If DataGridViewLeftSection_JobTemplates.HasOnlyOneSelectedRow Then

                JobTemplateControlRightSection_JobTemplate.Enabled = JobTemplateControlRightSection_JobTemplate.LoadControl(DataGridViewLeftSection_JobTemplates.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            JobTemplateControlRightSection_JobTemplate.Enabled = (DataGridViewLeftSection_JobTemplates.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_JobTemplates.HasOnlyOneSelectedRow AndAlso JobTemplateControlRightSection_JobTemplate.Enabled AndAlso DataGridViewLeftSection_JobTemplates.GetFirstSelectedRowBookmarkValue <> "DFLT")
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemTemplateItems_Delete.Enabled = JobTemplateControlRightSection_JobTemplate.JobTemplateDetailsGrid.HasASelectedRow
            ButtonItemTemplateItems_MoveDown.Enabled = JobTemplateControlRightSection_JobTemplate.CanMoveItemDown
            ButtonItemTemplateItems_MoveUp.Enabled = JobTemplateControlRightSection_JobTemplate.CanMoveItemUp
            ButtonItemTemplateItems_Add.Enabled = JobTemplateControlRightSection_JobTemplate.DataGridViewLeftSection_JobTemplateItems.HasASelectedRow

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

                            IsOkay = JobTemplateControlRightSection_JobTemplate.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Would you like to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

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
            Dim JobTemplateSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTemplateSetupForm = Nothing

            JobTemplateSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTemplateSetupForm()

            JobTemplateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub JobTemplateSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemTemplateItems_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemTemplateItems_MoveDown.Image = AdvantageFramework.My.Resources.DownImage
            ButtonItemTemplateItems_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemTemplateItems_Add.Image = AdvantageFramework.My.Resources.DetailAddImage

            DataGridViewLeftSection_JobTemplates.MultiSelect = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_JobTemplates.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub JobTemplateSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JobTemplateSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JobTemplateSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_JobTemplates.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_JobTemplates_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_JobTemplates.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobTemplates_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_JobTemplates.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_JobTemplates.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        JobTemplateControlRightSection_JobTemplate.Save()

                        Me.ClearChanged()

                        LoadGrid()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_JobTemplates.FocusToFindPanel(False)

                        DataGridViewLeftSection_JobTemplates.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a job template to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim JobTemplateCode As String = ""
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_JobTemplates.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTemplateEditDialog.ShowFormDialog(JobTemplateCode, False) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_JobTemplates.SelectRow(JobTemplateCode)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_JobTemplates.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim JobTemplateCode As String = ""
            Dim ContinueCopy As Boolean = True

            If DataGridViewLeftSection_JobTemplates.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

                If ContinueCopy Then

                    JobTemplateCode = DataGridViewLeftSection_JobTemplates.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTemplateEditDialog.ShowFormDialog(JobTemplateCode, True) = System.Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        DataGridViewLeftSection_JobTemplates.SelectRow(JobTemplateCode)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_JobTemplates.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        JobTemplateControlRightSection_JobTemplate.Delete()

                        LoadGrid()

                        LoadSelectedItemDetails()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a job template to delete.")

            End If

        End Sub
        Private Sub ButtonItemTemplateItems_MoveDown_Click(sender As Object, e As System.EventArgs) Handles ButtonItemTemplateItems_MoveDown.Click

            JobTemplateControlRightSection_JobTemplate.MoveDownSelectedItem()

        End Sub
        Private Sub ButtonItemTemplateItems_MoveUp_Click(sender As Object, e As System.EventArgs) Handles ButtonItemTemplateItems_MoveUp.Click

            JobTemplateControlRightSection_JobTemplate.MoveUpSelectedItem()

        End Sub
        Private Sub JobTemplateControlRightSection_JobTemplate_SelectedJobTemplateDetailChanged() Handles JobTemplateControlRightSection_JobTemplate.SelectedJobTemplateDetailChanged

            EnableOrDisableActions()

        End Sub
        Private Sub JobTemplateControlRightSection_JobTemplate_SelectedJobTemplateItemChanged() Handles JobTemplateControlRightSection_JobTemplate.SelectedJobTemplateItemChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTemplateItems_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemTemplateItems_Add.Click

            JobTemplateControlRightSection_JobTemplate.AddSelectedTemplateItems()

        End Sub
        Private Sub ButtonItemTemplateItems_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemTemplateItems_Delete.Click

            JobTemplateControlRightSection_JobTemplate.DeleteSelectedTemplateItems()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Try

                    JobTemplateControlRightSection_JobTemplate.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_JobTemplates.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace