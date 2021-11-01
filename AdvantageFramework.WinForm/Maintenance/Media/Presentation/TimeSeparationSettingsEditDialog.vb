Namespace Maintenance.Media.Presentation

    Public Class TimeSeparationSettingsEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _InvoiceMatchingSettingID As Integer = Nothing
        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.TimeSeparationSettingSetupController = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _Source As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource = ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource.Default

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(InvoiceMatchingSettingID As Integer, Source As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource)

            ' This call is required by the designer.
            InitializeComponent()

            _InvoiceMatchingSettingID = InvoiceMatchingSettingID
            _Source = Source

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_TimeSeparationSettings.CurrentView.RefreshData()

            End If

            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled AndAlso Not _ViewModel.CrossLengthSeparationEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.IsDirty
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled AndAlso Not _ViewModel.CrossLengthSeparationEnabled

            NumericInputForm_CrossLengthSeparation.SetRequired(CheckBoxForm_CrossLengthSeparationEnabled.Checked)

            NumericInputForm_CrossLengthSeparation.Enabled = _ViewModel.CrossLengthSeparationEnabled

            DataGridViewForm_TimeSeparationSettings.Enabled = Not _ViewModel.CrossLengthSeparationEnabled

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(InvoiceMatchingSettingID As Integer, Source As AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource) As System.Windows.Forms.DialogResult

            'objects
            Dim TimeSeparationSettingsEditDialog As AdvantageFramework.Maintenance.Media.Presentation.TimeSeparationSettingsEditDialog = Nothing

            TimeSeparationSettingsEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.TimeSeparationSettingsEditDialog(InvoiceMatchingSettingID, Source)

            ShowFormDialog = TimeSeparationSettingsEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TimeSeparationSettingsEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.TimeSeparationSettingSetupController(Me.Session)

            _ViewModel = _Controller.Load(_InvoiceMatchingSettingID, _Source)

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_TimeSeparationSettings.GridControl.ToolTipController = _ToolTipController

        End Sub
        Private Sub TimeSeparationSettingsEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            NumericInputForm_CrossLengthSeparation.SetPropertySettings(AdvantageFramework.DTO.Media.TimeSeparationSetting.Properties.CrossLengthSeparationValue)
            NumericInputForm_CrossLengthSeparation.Properties.MaxLength = 3

            If _ViewModel.MediaTypeCode = "T" Then

                LabelForm_MediaType.Text = "Television"

            ElseIf _ViewModel.MediaTypeCode = "R" Then

                LabelForm_MediaType.Text = "Radio"

            End If

            If _ViewModel.Client IsNot Nothing Then

                LabelForm_Client.Text = _ViewModel.Client.ToString

            Else

                LabelForm_Client.Text = "All Clients"

            End If

            CheckBoxForm_CrossLengthSeparationEnabled.Checked = _ViewModel.CrossLengthSeparationEnabled
            NumericInputForm_CrossLengthSeparation.EditValue = _ViewModel.CrossLengthSeparationValue

            DataGridViewForm_TimeSeparationSettings.DataSource = _ViewModel.TimeSeparationSettings

            RefreshViewModel(True)

            DataGridViewForm_TimeSeparationSettings.CurrentView.BestFitColumns()

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowValue As String = Nothing
            Dim ToolTipText As String = Nothing

            If e.SelectedControl Is DataGridViewForm_TimeSeparationSettings.GridControl Then

                Try

                    GridView = CType(DataGridViewForm_TimeSeparationSettings.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.TimeSeparationSetting.Properties.Separation.ToString Then

                            ToolTipText = "Length-specific separation in minutes; 0 means ignore; range 0-999"

                            RowValue = DataGridViewForm_TimeSeparationSettings.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.DTO.Media.TimeSeparationSetting.Properties.Separation.ToString)

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowValue, ToolTipText)

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewForm_TimeSeparationSettings.CurrentView.CloseEditorForUpdating()

            Me.ShowWaitForm("Saving...")

            _Controller.Save(_ViewModel)

            Me.ClearChanged()

            Me.CloseWaitForm()

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewForm_TimeSeparationSettings.HasASelectedRow Then

                DataGridViewForm_TimeSeparationSettings.CurrentView.CloseEditorForUpdating()

                _ViewModel.IsDirty = True

                DataGridViewForm_TimeSeparationSettings.SetUserEntryChanged()

                _ViewModel.TimeSeparationSettings.Remove(DataGridViewForm_TimeSeparationSettings.CurrentView.GetRow(DataGridViewForm_TimeSeparationSettings.CurrentView.FocusedRowHandle))

                RefreshViewModel(True)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_TimeSeparationSettings.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub CheckBoxForm_CrossLengthSeparationEnabled_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_CrossLengthSeparationEnabled.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetCrossLengthSeparationEnabled(_ViewModel, e.NewChecked.Checked)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub DataGridViewForm_TimeSeparationSettings_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_TimeSeparationSettings.CellValueChangedEvent

            _ViewModel.IsDirty = True

            DataGridViewForm_TimeSeparationSettings.SetUserEntryChanged()

        End Sub
        Private Sub DataGridViewForm_TimeSeparationSettings_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_TimeSeparationSettings.FocusedRowChangedEvent

            _Controller.TimeSeparationSettingFocusedRowChanged(_ViewModel,
                                                               DataGridViewForm_TimeSeparationSettings.IsNewItemRow,
                                                               DataGridViewForm_TimeSeparationSettings.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.TimeSeparationSetting).ToList)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_TimeSeparationSettings_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_TimeSeparationSettings.InitNewRowEvent

            _Controller.InitNewRowEvent(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_TimeSeparationSettings_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_TimeSeparationSettings.ShowingEditorEvent

            If Not DataGridViewForm_TimeSeparationSettings.IsNewItemRow Then

                If DataGridViewForm_TimeSeparationSettings.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.TimeSeparationSetting.Properties.Length.ToString Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_TimeSeparationSettings.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.TimeSeparationSetting.Properties.Separation.ToString AndAlso
                    DirectCast(DataGridViewForm_TimeSeparationSettings.CurrentView.GetRow(DataGridViewForm_TimeSeparationSettings.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.TimeSeparationSetting) Is Nothing Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_TimeSeparationSettings_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_TimeSeparationSettings.ValidateRowEvent

            If e.Row IsNot Nothing Then

                If DataGridViewForm_TimeSeparationSettings.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    e.ErrorText = _Controller.ValidateEntity(_ViewModel, DirectCast(e.Row, AdvantageFramework.DTO.Media.TimeSeparationSetting), e.Valid)

                    DataGridViewForm_TimeSeparationSettings.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        _ViewModel.IsDirty = True

                        RefreshViewModel(False)

                    Else

                        DataGridViewForm_TimeSeparationSettings.CurrentView.SetColumnError(DataGridViewForm_TimeSeparationSettings.CurrentView.Columns(AdvantageFramework.DTO.Media.TimeSeparationSetting.Properties.Length.ToString), e.ErrorText)

                    End If

                End If

            End If

        End Sub
        Private Sub NumericInputForm_CrossLengthSeparation_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputForm_CrossLengthSeparation.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetCrossLengthSeparationValue(_ViewModel, NumericInputForm_CrossLengthSeparation.EditValue)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace