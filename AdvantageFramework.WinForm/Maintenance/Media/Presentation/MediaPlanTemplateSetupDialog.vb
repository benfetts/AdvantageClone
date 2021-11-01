Namespace Maintenance.Media.Presentation

    Public Class MediaPlanTemplateSetupDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaPlanTemplateSetupController = Nothing
        Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateSetupViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load()

        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_PlanTemplates.CurrentView.BeginUpdate()

            DataGridViewLeftSection_PlanTemplates.DataSource = _ViewModel.PlanTemplates

            DataGridViewLeftSection_PlanTemplates.CurrentView.EndUpdate()

        End Sub
        Private Sub LoadControl()

            MediaPlanTemplateControlRightSection_MediaPlanTemplate.ClearControl()

            If _ViewModel.HasASelectedPlanTemplate Then

                MediaPlanTemplateControlRightSection_MediaPlanTemplate.Enabled = True

                MediaPlanTemplateControlRightSection_MediaPlanTemplate.LoadControl(_ViewModel.SelectedPlanTemplate.ID)

            Else

                MediaPlanTemplateControlRightSection_MediaPlanTemplate.Enabled = False

            End If

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled

            ButtonItemDetails_Delete.Enabled = MediaPlanTemplateControlRightSection_MediaPlanTemplate.ViewModel.PlanEstimateTemplates_DeleteEnabled
            ButtonItemDetails_Cancel.Enabled = MediaPlanTemplateControlRightSection_MediaPlanTemplate.ViewModel.PlanEstimateTemplates_CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewLeftSection_PlanTemplates.OptionsBehavior.Editable = False
            DataGridViewLeftSection_PlanTemplates.OptionsSelection.MultiSelect = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanTemplateSetupDialog As Maintenance.Media.Presentation.MediaPlanTemplateSetupDialog = Nothing

            MediaPlanTemplateSetupDialog = New Maintenance.Media.Presentation.MediaPlanTemplateSetupDialog()

            ShowFormDialog = MediaPlanTemplateSetupDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanTemplateSetupDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.MediaPlanTemplateSetupController(Me.Session)

        End Sub
        Private Sub MediaPlanTemplateSetupDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            LoadControl()

            RefreshViewModel()

            DataGridViewLeftSection_PlanTemplates.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Me.ClearChanged()

            DataGridViewLeftSection_PlanTemplates.CurrentView.BestFitColumns()

            DataGridViewLeftSection_PlanTemplates.FocusToFindPanel(False)

            DataGridViewLeftSection_PlanTemplates.HideRowSelection()

        End Sub
        Private Sub MediaPlanTemplateSetupDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub MediaPlanTemplateSetupDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim MediaPlanTemplateHeaderID As Nullable(Of Integer) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        If MediaPlanTemplateControlRightSection_MediaPlanTemplate.Save() Then

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        End If

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If MediaPlanTemplateEditDialog.ShowFormDialog(MediaPlanTemplateHeaderID) = Windows.Forms.DialogResult.OK Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        _Controller.LoadMediaPlanTemplates(_ViewModel)

                        LoadGrid()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewLeftSection_PlanTemplates.SelectRow(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate.Properties.ID.ToString, MediaPlanTemplateHeaderID, True)

                        DataGridViewLeftSection_PlanTemplates.GridViewSelectionChanged()

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

                    If MediaPlanTemplateControlRightSection_MediaPlanTemplate.Save() Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _ViewModel.SelectedPlanTemplate.ID = MediaPlanTemplateControlRightSection_MediaPlanTemplate.ViewModel.PlanTemplate.ID
                        _ViewModel.SelectedPlanTemplate.Description = MediaPlanTemplateControlRightSection_MediaPlanTemplate.ViewModel.PlanTemplate.Description
                        _ViewModel.SelectedPlanTemplate.IsInactive = MediaPlanTemplateControlRightSection_MediaPlanTemplate.ViewModel.PlanTemplate.IsInactive

                        DataGridViewLeftSection_PlanTemplates.CurrentView.RefreshData()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        If DataGridViewLeftSection_PlanTemplates.CurrentView.GetFocusedRow Is Nothing Then

                            DataGridViewLeftSection_PlanTemplates.GridViewSelectionChanged()

                        End If

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

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this media type template?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If MediaPlanTemplateControlRightSection_MediaPlanTemplate.Delete(ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        _Controller.LoadMediaPlanTemplates(_ViewModel)

                        LoadGrid()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewLeftSection_PlanTemplates.GridViewSelectionChanged()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                MediaPlanTemplateControlRightSection_MediaPlanTemplate.PlanEstimateTemplates_CancelNewItemRow()

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                MediaPlanTemplateControlRightSection_MediaPlanTemplate.PlanEstimateTemplates_Delete()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_PlanTemplates_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_PlanTemplates.FocusedRowChangedEvent

            'objects
            Dim [Continue] As Boolean = False

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        If MediaPlanTemplateControlRightSection_MediaPlanTemplate.Save() Then

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        End If

                    Else

                        'Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        'DataGridViewLeftSection_PlanTemplates.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                        'Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    _Controller.SelectedDiscountChanged(_ViewModel, DataGridViewLeftSection_PlanTemplates.GetFirstSelectedRowDataBoundItem())

                    LoadControl()

                    RefreshViewModel()

                    Me.ClearChanged()

                End If

            End If

        End Sub
        Private Sub MediaPlanTemplateControlRightSection_MediaPlanTemplate_TemplateDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MediaPlanTemplateControlRightSection_MediaPlanTemplate.TemplateDetails_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub MediaPlanTemplateControlRightSection_MediaPlanTemplate_TemplateDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles MediaPlanTemplateControlRightSection_MediaPlanTemplate.TemplateDetails_SelectionChangedEvent

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace
