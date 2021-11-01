Namespace Maintenance.ProjectManagement.Presentation

    Public Class CreativeBriefTemplateSetupForm

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

                DataGridViewLeftSection_CreativeBriefTemplates.DataSource = AdvantageFramework.Database.Procedures.CreativeBriefTemplate.Load(DbContext)

            End Using

            DataGridViewLeftSection_CreativeBriefTemplates.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.ClearControl()

            CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.Enabled = DataGridViewLeftSection_CreativeBriefTemplates.HasOnlyOneSelectedRow

            If CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.Enabled Then

                CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.Enabled = CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.LoadControl(DataGridViewLeftSection_CreativeBriefTemplates.GetFirstSelectedRowBookmarkValue, False)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.Enabled = (DataGridViewLeftSection_CreativeBriefTemplates.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.Enabled Then

                RibbonBarOptions_Details.Visible = CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.DetailTabSelected
                ButtonItemActions_Delete.Enabled = True
                ButtonItemDetails_Delete.Enabled = CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.HasASelectedLevel
                ButtonItemDetails_Add.Enabled = CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.HasASelectedLevel
                ButtonItemActions_Copy.Enabled = True

            Else

                RibbonBarOptions_Details.Visible = False
                ButtonItemActions_Delete.Enabled = False
                ButtonItemDetails_Delete.Enabled = False
                ButtonItemDetails_Add.Enabled = False
                ButtonItemActions_Copy.Enabled = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.Save()

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
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_CreativeBriefTemplates.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.Save() Then

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

                        DataGridViewLeftSection_CreativeBriefTemplates.FocusToFindPanel(False)

                        DataGridViewLeftSection_CreativeBriefTemplates.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a creative brief template to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CreativeBriefTemplateSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.CreativeBriefTemplateSetupForm = Nothing

            CreativeBriefTemplateSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.CreativeBriefTemplateSetupForm

            CreativeBriefTemplateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CreativeBriefTemplateSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            DataGridViewLeftSection_CreativeBriefTemplates.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_CreativeBriefTemplates.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub CreativeBriefTemplateSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CreativeBriefTemplateSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CreativeBriefTemplateSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_CreativeBriefTemplates.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_JobVersionTemplates_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_CreativeBriefTemplates.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobVersionTemplates_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_CreativeBriefTemplates.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim CreativeBriefTemplateID As Integer = Nothing
            Dim CanAdd As Boolean = True

            If DataGridViewLeftSection_CreativeBriefTemplates.HasOnlyOneSelectedRow Then

                CanAdd = CheckForUnsavedChanges()

            End If

            If CanAdd Then

                If AdvantageFramework.Maintenance.ProjectManagement.Presentation.CreativeBriefTemplateEditDialog.ShowFormDialog(CreativeBriefTemplateID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_CreativeBriefTemplates.SelectRow(CreativeBriefTemplateID)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_CreativeBriefTemplates.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim CreativeBriefTemplateID As Integer = Nothing
            Dim CanCopy As Boolean = True

            If DataGridViewLeftSection_CreativeBriefTemplates.HasOnlyOneSelectedRow Then

                CanCopy = CheckForUnsavedChanges()

                If CanCopy Then

                    CreativeBriefTemplateID = DataGridViewLeftSection_CreativeBriefTemplates.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.Maintenance.ProjectManagement.Presentation.CreativeBriefTemplateEditDialog.ShowFormDialog(CreativeBriefTemplateID, True) = System.Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid()

                            DataGridViewLeftSection_CreativeBriefTemplates.SelectRow(CreativeBriefTemplateID)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        DataGridViewLeftSection_CreativeBriefTemplates.CurrentView.GridViewSelectionChanged()

                    Else

                        LoadSelectedItemDetails()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_CreativeBriefTemplates.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_CreativeBriefTemplates.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a creative brief template to delete.")

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.DeleteLevel()

        End Sub
        Private Sub ButtonItemDetails_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemDetails_Add.Click

            CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.AddLevel()

        End Sub
        Private Sub CreativeBriefTemplateControlRightSection_CreativeBriefTemplate_InactiveChangedEvent(Inactive As Boolean, ByRef Cancel As Boolean) Handles CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub CreativeBriefTemplateControlRightSection_CreativeBriefTemplate_SelectedTabChanged() Handles CreativeBriefTemplateControlRightSection_CreativeBriefTemplate.SelectedTabChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace