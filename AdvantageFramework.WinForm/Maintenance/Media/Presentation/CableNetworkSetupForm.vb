Namespace Maintenance.Media.Presentation

    Public Class CableNetworkSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.CableNetworkSetupController = Nothing


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

            DataGridViewForm_CableNetwork.DataSource = _ViewModel.CableNetworkStations

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_CableNetwork.CurrentView.RefreshData()

            End If

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_CableNetwork.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewForm_CableNetwork.SetupForEditableGrid()

            DataGridViewForm_CableNetwork.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_CableNetwork.OptionsCustomization.AllowQuickHideColumns = False

        End Sub
        Private Sub AddNewRow(CableNetworkStation As AdvantageFramework.DTO.CableNetworkStation)

            Dim ErrorMessage As String = Nothing

            If CableNetworkStation IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.Add(_ViewModel, CableNetworkStation, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewForm_CableNetwork.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewForm_CableNetwork.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CableNetworkSetupForm As CableNetworkSetupForm = Nothing

            CableNetworkSetupForm = New CableNetworkSetupForm()

            CableNetworkSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CableNetworkSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.CableNetworkSetupController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub CableNetworkSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            DataGridViewForm_CableNetwork.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            RefreshViewModel(False)

            Me.ClearChanged()

            DataGridViewForm_CableNetwork.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub CableNetworkSetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub CableNetworkSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub


#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewForm_CableNetwork.CurrentView.CloseEditorForUpdating()

            If _ViewModel.CableNetworkStations.Any(Function(Entity) Entity.HasError) = False Then

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

            If DataGridViewForm_CableNetwork.HasASelectedRow Then

                DataGridViewForm_CableNetwork.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.Delete(_ViewModel, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    _Controller.SelectionChanged(_ViewModel, DataGridViewForm_CableNetwork.IsNewItemRow, DataGridViewForm_CableNetwork.GetFirstSelectedRowDataBoundItem)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_CableNetwork.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_CableNetwork_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_CableNetwork.CellValueChangingEvent

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.DTO.Media.CableNetworkStation.Properties.IsInactive.ToString Then

                Saved = _Controller.SetInactiveFlag(DataGridViewForm_CableNetwork.GetFirstSelectedRowDataBoundItem, e.Value)

            End If

        End Sub
        Private Sub DataGridViewForm_CableNetwork_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_CableNetwork.FocusedRowChangedEvent

            _Controller.SelectionChanged(_ViewModel, DataGridViewForm_CableNetwork.IsNewItemRow, DataGridViewForm_CableNetwork.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_CableNetwork_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_CableNetwork.InitNewRowEvent

            _Controller.InitNewRowEvent(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_CableNetwork_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_CableNetwork.ShowingEditorEvent

            If DataGridViewForm_CableNetwork.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.CableNetworkStation.Properties.NielsenTVStationCode.ToString AndAlso
                    DataGridViewForm_CableNetwork.CurrentView.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_CableNetwork_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_CableNetwork.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewForm_CableNetwork.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_CableNetwork.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_CableNetwork_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_CableNetwork.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.CableNetworkStation = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewForm_CableNetwork.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewForm_CableNetwork.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace