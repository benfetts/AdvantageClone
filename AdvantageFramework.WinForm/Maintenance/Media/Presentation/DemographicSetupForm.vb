Namespace Maintenance.Media.Presentation

    Public Class DemographicSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.DemographicSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewLeftSection_MediaDemographics.DataSource = _ViewModel.MediaDemographics
                DataGridViewLeftSection_MediaDemographics.CurrentView.BestFitColumns()

            Else

                DataGridViewLeftSection_MediaDemographics.CurrentView.RefreshData()

            End If

            If _ViewModel IsNot Nothing AndAlso _ViewModel.SelectedDemoSource = Database.Entities.Methods.MediaDemoSourceID.Comscore Then

                ButtonItemActions_Add.Enabled = False

            Else

                ButtonItemActions_Add.Enabled = True

            End If

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_MediaDemographics.HasOnlyOneSelectedRow AndAlso MediaDemographicControlRightSection_DemoControl.Enabled AndAlso
                                               Not DirectCast(DataGridViewLeftSection_MediaDemographics.CurrentView.GetRow(DataGridViewLeftSection_MediaDemographics.CurrentView.FocusedRowHandle), ViewModels.Maintenance.Media.DemographicSetupDetailViewModel).IsSystem

            If _ViewModel.SelectedDemoSource = Database.Entities.Methods.MediaDemoSourceID.Numeris Then

                ButtonItemView_NationalTV.Enabled = False

                If ButtonItemView_NationalTV.Checked Then

                    ButtonItemView_SpotTV.Checked = True

                End If

                MediaDemographicControlRightSection_DemoControl.DataGridViewControl_DemoDetails.Visible = False

            Else

                ButtonItemView_NationalTV.Enabled = True

                MediaDemographicControlRightSection_DemoControl.DataGridViewControl_DemoDetails.Visible = True

            End If

        End Sub
        Private Sub LoadSelectedItemDemographic()

            MediaDemographicControlRightSection_DemoControl.ClearControl()

            If DataGridViewLeftSection_MediaDemographics.HasASelectedRow Then

                _Controller.DemographicSelectionChanged(_ViewModel, DataGridViewLeftSection_MediaDemographics.GetRowDataBoundItem(DataGridViewLeftSection_MediaDemographics.CurrentView.FocusedRowHandle))

                If MediaDemographicControlRightSection_DemoControl.LoadControl(_ViewModel.SelectedMediaDemographic.GetMediaDemographicEntity.ID, _ViewModel.SelectedMediaDemographic.GetMediaDemographicEntity.Type, _ViewModel.SelectedMediaDemographic.GetMediaDemographicEntity.MediaDemoSourceID) = False Then

                    MediaDemographicControlRightSection_DemoControl.ClearControl()
                    MediaDemographicControlRightSection_DemoControl.Enabled = False

                Else

                    ClearChanged()
                    ClearValidations()
                    MediaDemographicControlRightSection_DemoControl.Enabled = True

                End If

            Else

                _Controller.DemographicSelectionChanged(_ViewModel, Nothing)

                MediaDemographicControlRightSection_DemoControl.Enabled = False

            End If

            RefreshViewModel(False)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            CheckForUnsavedChanges = MediaDemographicControlRightSection_DemoControl.CheckForUnsavedChanges(_ViewModel)

        End Function
        Private Function Save() As Boolean

            'objects
            Dim MediaDemographicID As Integer = 0
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_MediaDemographics.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    If Not MediaDemographicControlRightSection_DemoControl.Save(ErrorMessage, MediaDemographicID) Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    Else

                        Saved = True

                        _Controller.RefreshDemos(_ViewModel)

                        RefreshViewModel(True)

                        DataGridViewLeftSection_MediaDemographics.SelectRow(MediaDemographicID)

                        Me.ClearChanged()

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a demographic to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DemographicSetupForm As AdvantageFramework.Maintenance.Media.Presentation.DemographicSetupForm = Nothing

            DemographicSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.DemographicSetupForm()

            DemographicSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DemographicSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemView_SpotTV.Image = AdvantageFramework.My.Resources.BroadcastOrdersTVImage
            ButtonItemView_NationalTV.Image = AdvantageFramework.My.Resources.NationalImage
            ButtonItemView_Radio.Image = AdvantageFramework.My.Resources.BroadcastOrdersRadioImage

            ButtonItemView_SpotTV.Checked = True

            ComboBoxItemSource_Source.ComboBoxEx.DisplayMember = "Display"
            ComboBoxItemSource_Source.ComboBoxEx.ValueMember = "Value"

            DataGridViewLeftSection_MediaDemographics.OptionsBehavior.ReadOnly = True

            DataGridViewLeftSection_MediaDemographics.SetBookmarkColumnIndex(0)

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.DemographicSetupController(Me.Session)

            _ViewModel = _Controller.Load()

            ComboBoxItemSource_Source.ComboBoxEx.DataSource = _ViewModel.DemoSources

        End Sub
        Private Sub DemographicSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DemographicSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DemographicSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_MediaDemographics.DataSource = _ViewModel.MediaDemographics

            DataGridViewLeftSection_MediaDemographics.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            DataGridViewLeftSection_MediaDemographics.CurrentView.BestFitColumns()

            DataGridViewLeftSection_MediaDemographics.FocusToFindPanel(True)

            MediaDemographicControlRightSection_DemoControl.Enabled = False

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            RefreshViewModel(False)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_MediaDemographics_BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_MediaDemographics.BeforeLeaveRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_MediaDemographics_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_MediaDemographics.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDemographic()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ContinueAdd As Boolean = True
            Dim MediaDemographicID As Integer = 0

            If DataGridViewLeftSection_MediaDemographics.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Media.Presentation.DemographicEditDialog.ShowFormDialog(MediaDemographicID, _ViewModel.Type, _ViewModel.SelectedDemoSource) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    _Controller.RefreshDemos(_ViewModel)

                    RefreshViewModel(True)

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_MediaDemographics.SelectRow(MediaDemographicID)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            Dim ErrorMessage As String = Nothing

            If DataGridViewLeftSection_MediaDemographics.HasASelectedRow Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Deleting

                If MediaDemographicControlRightSection_DemoControl.Delete() Then

                    MediaDemographicControlRightSection_DemoControl.ClearControl()

                    _Controller.RefreshDemos(_ViewModel)

                    RefreshViewModel(True)

                    Me.ClearChanged()

                    LoadSelectedItemDemographic()

                End If

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub ComboBoxItemSource_Source_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemSource_Source.SelectedIndexChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If CheckForUnsavedChanges() Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                    _Controller.MediaDemoSourceChanged(_ViewModel, ComboBoxItemSource_Source.ComboBoxEx.SelectedValue)

                    RefreshViewModel(True)

                    DataGridViewLeftSection_MediaDemographics.FocusToFindPanel(True)

                    MediaDemographicControlRightSection_DemoControl.ClearControl()
                    MediaDemographicControlRightSection_DemoControl.Enabled = False
                    ClearChanged()

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                End If

            End If

        End Sub
        Private Sub ButtonItemView_NetworkTV_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_NationalTV.CheckedChanged, ButtonItemView_NationalTV.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_NationalTV.Checked Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                _Controller.TypeChanged(_ViewModel, "N")

                RefreshViewModel(True)

                DataGridViewLeftSection_MediaDemographics.FocusToFindPanel(True)

                MediaDemographicControlRightSection_DemoControl.ClearControl()
                MediaDemographicControlRightSection_DemoControl.Enabled = False
                ClearChanged()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemView_NetworkTV_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemView_NationalTV.OptionGroupChanging, ButtonItemView_NationalTV.OptionGroupChanging

            If Me.FormShown Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ButtonItemView_Radio_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_Radio.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_Radio.Checked Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                _Controller.TypeChanged(_ViewModel, "R")

                RefreshViewModel(True)

                DataGridViewLeftSection_MediaDemographics.FocusToFindPanel(True)

                MediaDemographicControlRightSection_DemoControl.ClearControl()
                MediaDemographicControlRightSection_DemoControl.Enabled = False
                ClearChanged()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemView_Radio_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemView_Radio.OptionGroupChanging

            If Me.FormShown Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ButtonItemView_SpotTV_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_SpotTV.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_SpotTV.Checked Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                _Controller.TypeChanged(_ViewModel, "T")

                RefreshViewModel(True)

                DataGridViewLeftSection_MediaDemographics.FocusToFindPanel(True)

                MediaDemographicControlRightSection_DemoControl.ClearControl()
                MediaDemographicControlRightSection_DemoControl.Enabled = False
                ClearChanged()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemView_SpotTV_OptionGroupChanging(sender As Object, e As DevComponents.DotNetBar.OptionGroupChangingEventArgs) Handles ButtonItemView_SpotTV.OptionGroupChanging

            If Me.FormShown Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub MediaDemographicControlRightSection_DemoControl_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles MediaDemographicControlRightSection_DemoControl.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
