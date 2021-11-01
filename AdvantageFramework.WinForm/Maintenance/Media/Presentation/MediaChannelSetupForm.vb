Namespace Maintenance.Media.Presentation

    Public Class MediaChannelSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaChannelSetupController = Nothing

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

            DataGridViewForm_MediaChannel.DataSource = _ViewModel.MediaChannels

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_MediaChannel.CurrentView.RefreshData()

            End If

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_MediaChannel.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewForm_MediaChannel.SetupForEditableGrid()

            DataGridViewForm_MediaChannel.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_MediaChannel.OptionsCustomization.AllowQuickHideColumns = False

        End Sub
        Private Sub AddNewRow(MediaChannel As AdvantageFramework.DTO.MediaChannel)

            Dim ErrorMessage As String = Nothing

            If MediaChannel IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.Add(_ViewModel, MediaChannel, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewForm_MediaChannel.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewForm_MediaChannel.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaChannelSetupForm As MediaChannelSetupForm = Nothing

            MediaChannelSetupForm = New MediaChannelSetupForm()

            MediaChannelSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaChannelSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.MediaChannelSetupController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaChannelSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            DataGridViewForm_MediaChannel.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            RefreshViewModel(False)

            Me.ClearChanged()

            DataGridViewForm_MediaChannel.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaChannelSetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub MediaChannelSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_MediaChannel.Print(Me.Session, DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewForm_MediaChannel.CurrentView.CloseEditorForUpdating()

            If _ViewModel.MediaChannels.Any(Function(Entity) Entity.HasError) = False Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                _Controller.Save(_ViewModel)

                RefreshViewModel(False)

                Me.ClearChanged()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please fix data entry errors before saving.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If DataGridViewForm_MediaChannel.HasASelectedRow Then

                DataGridViewForm_MediaChannel.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.Delete(_ViewModel, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    _Controller.SelectionChanged(_ViewModel, DataGridViewForm_MediaChannel.IsNewItemRow, DataGridViewForm_MediaChannel.GetFirstSelectedRowDataBoundItem)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_MediaChannel.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_MediaChannel_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_MediaChannel.CellValueChangingEvent

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.DTO.MediaChannel.Properties.IsInactive.ToString Then

                Saved = _Controller.SetInactiveFlag(DataGridViewForm_MediaChannel.GetFirstSelectedRowDataBoundItem, e.Value)

            End If

        End Sub
        Private Sub DataGridViewForm_MediaChannel_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_MediaChannel.FocusedRowChangedEvent

            _Controller.SelectionChanged(_ViewModel, DataGridViewForm_MediaChannel.IsNewItemRow, DataGridViewForm_MediaChannel.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_MediaChannel_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_MediaChannel.InitNewRowEvent

            _Controller.InitNewRowEvent(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_MediaChannel_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_MediaChannel.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewForm_MediaChannel.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_MediaChannel.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_MediaChannel_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_MediaChannel.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.MediaChannel = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewForm_MediaChannel.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewForm_MediaChannel.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace