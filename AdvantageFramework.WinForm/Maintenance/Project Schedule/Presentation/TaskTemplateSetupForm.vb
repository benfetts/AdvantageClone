Namespace Maintenance.ProjectSchedule.Presentation

    Public Class TaskTemplateSetupForm

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

                DataGridViewLeftSection_TaskTemplates.DataSource = AdvantageFramework.Database.Procedures.TaskTemplate.Load(DbContext)

                DataGridViewLeftSection_TaskTemplates.HideOrShowColumn("IsInactive", False)

            End Using

            DataGridViewLeftSection_TaskTemplates.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            TaskTemplateControlRightSection_TaskTemplate.ClearControl()

            TaskTemplateControlRightSection_TaskTemplate.Enabled = DataGridViewLeftSection_TaskTemplates.HasOnlyOneSelectedRow

            If TaskTemplateControlRightSection_TaskTemplate.Enabled Then

                TaskTemplateControlRightSection_TaskTemplate.Enabled = TaskTemplateControlRightSection_TaskTemplate.LoadControl(DataGridViewLeftSection_TaskTemplates.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            TaskTemplateControlRightSection_TaskTemplate.Enabled = (DataGridViewLeftSection_TaskTemplates.HasOnlyOneSelectedRow AndAlso Me.FormShown AndAlso TaskTemplateControlRightSection_TaskTemplate.Loaded)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemActions_Print.Enabled = DataGridViewLeftSection_TaskTemplates.HasRows

            If TaskTemplateControlRightSection_TaskTemplate.Enabled Then

                ButtonItemActions_Delete.Enabled = True
                ButtonItemActions_CopyFrom.Enabled = True

                ButtonItemDetails_Cancel.Enabled = TaskTemplateControlRightSection_TaskTemplate.IsNewItemRowSelected
                ButtonItemDetails_Delete.Enabled = (TaskTemplateControlRightSection_TaskTemplate.HasASelectedDetail AndAlso TaskTemplateControlRightSection_TaskTemplate.IsNewItemRowSelected = False)

            Else

                ButtonItemActions_Delete.Enabled = False
                ButtonItemActions_CopyFrom.Enabled = False

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = False

            End If

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

                            IsOkay = TaskTemplateControlRightSection_TaskTemplate.Save()

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
            Dim TaskTemplateSetupForm As AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateSetupForm = Nothing

            TaskTemplateSetupForm = New AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateSetupForm()

            TaskTemplateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub TaskTemplateSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_TaskTemplates.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub TaskTemplateSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub TaskTemplateSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub TaskTemplateSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_TaskTemplates.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_TaskTemplates_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_TaskTemplates.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_TaskTemplates_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_TaskTemplates.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_TaskTemplates.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If TaskTemplateControlRightSection_TaskTemplate.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_TaskTemplates.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a task template to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim TaskTemplateCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_TaskTemplates.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateEditDialog.ShowFormDialog(TaskTemplateCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_TaskTemplates.SelectRow(TaskTemplateCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_TaskTemplates.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If TaskTemplateControlRightSection_TaskTemplate.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a task template to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_CopyFrom.Click

            TaskTemplateControlRightSection_TaskTemplate.CopyFrom()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Print.Click

            'objects
            Dim ContinuePrint As Boolean = True
            Dim SelectedTaskTemplateCode As String = Nothing

            ContinuePrint = CheckForUnsavedChanges()

            If ContinuePrint Then

                If DataGridViewLeftSection_TaskTemplates.HasOnlyOneSelectedRow AndAlso TaskTemplateControlRightSection_TaskTemplate.Loaded Then

                    SelectedTaskTemplateCode = DataGridViewLeftSection_TaskTemplates.GetFirstSelectedRowBookmarkValue

                End If

                AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateReportsDialog.ShowFormDialog(SelectedTaskTemplateCode)

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            TaskTemplateControlRightSection_TaskTemplate.DeleteSelectedDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            TaskTemplateControlRightSection_TaskTemplate.CancelNewDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub TaskTemplateControlRightSection_TaskTemplate_InitNewDetailRowEvent() Handles TaskTemplateControlRightSection_TaskTemplate.InitNewDetailRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub TaskTemplateControlRightSection_TaskTemplate_SelectedDetailChangedEvent() Handles TaskTemplateControlRightSection_TaskTemplate.SelectedDetailChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region
       
    End Class

End Namespace