Namespace WinForm.Presentation.Maintenance

    Public Class ClientSetupDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As NielsenFramework.ViewModels.Maintenance.ClientSetupViewModel = Nothing
        Protected _Controller As NielsenFramework.Controller.Maintenance.ClientSetupController = Nothing
        Protected _ConnectionString As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ConnectionString As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ConnectionString = ConnectionString

        End Sub
        Private Sub AddNewRow(RowObject As Object)

            Dim ErrorMessage As String = Nothing

            If TypeOf RowObject Is NielsenFramework.DTO.Client Then

                Me.ShowWaitForm("Processing...")

                If Not _Controller.Add(RowObject, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewForm_Client.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewForm_Client.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_Client.CurrentView.RefreshData()
                DataGridViewForm_Client.CurrentView.RefreshRow(DataGridViewForm_Client.CurrentView.FocusedRowHandle)

            End If

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Export.Enabled = _ViewModel.ExportEnabled

            ButtonItemView_Orders.Enabled = _ViewModel.ViewOrdersEnabled

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ConnectionString As String) As Windows.Forms.DialogResult

            'objects
            Dim ClientSetupDialog As WinForm.Presentation.Maintenance.ClientSetupDialog = Nothing

            ClientSetupDialog = New WinForm.Presentation.Maintenance.ClientSetupDialog(ConnectionString)

            ShowFormDialog = ClientSetupDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientSetupDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemView_Orders.Image = AdvantageFramework.My.Resources.BroadcastImage

            _Controller = New NielsenFramework.Controller.Maintenance.ClientSetupController(_ConnectionString)

            _ViewModel = _Controller.Load()

            DataGridViewForm_Client.DataSource = _ViewModel.Clients

            RefreshViewModel(False)

            DataGridViewForm_Client.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            DataGridViewForm_Client.CurrentView.BestFitColumns()

        End Sub
        Private Sub ClientSetupDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub ClientSetupDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Client.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewForm_Client.HasASelectedRow Then

                DataGridViewForm_Client.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    If Not _Controller.Delete(_ViewModel, ErrorMessage) Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Client.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                    _Controller.ClientSelectionChanged(_ViewModel, DataGridViewForm_Client.IsNewItemRow, DataGridViewForm_Client.GetFirstSelectedRowDataBoundItem)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Client.Print(DefaultLookAndFeel.LookAndFeel, Me.Name, Nothing, Me.Session)

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If DataGridViewForm_Client.HasASelectedRow Then

                DataGridViewForm_Client.CurrentView.CloseEditorForUpdating()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                _Controller.Save(_ViewModel)

                DataGridViewForm_Client.ValidateAllRowsAndClearChanged(True)

                RefreshViewModel(True)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                _Controller.ClientSelectionChanged(_ViewModel, DataGridViewForm_Client.IsNewItemRow, DataGridViewForm_Client.GetFirstSelectedRowDataBoundItem)

            End If

        End Sub
        Private Sub ButtonItemView_Orders_Click(sender As Object, e As EventArgs) Handles ButtonItemView_Orders.Click

            WinForm.Presentation.Maintenance.ClientOrderDialog.ShowFormDialog(_ConnectionString, _ViewModel.SelectedClient.ID)

        End Sub
        Private Sub DataGridViewForm_Client_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Client.CellValueChangingEvent

            'objects
            Dim Client As NielsenFramework.DTO.Client = Nothing
            Dim ErrorMessage As String = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

                If e.Column.FieldName = NielsenFramework.DTO.Client.Properties.IsNCCSubscribed.ToString OrElse
                        e.Column.FieldName = NielsenFramework.DTO.Client.Properties.FusionDiaryMarkets.ToString OrElse
                        e.Column.FieldName = NielsenFramework.DTO.Client.Properties.FusionMeteredMarkets.ToString OrElse
                        e.Column.FieldName = NielsenFramework.DTO.Client.Properties.IsInactive.ToString Then

                    Client = DataGridViewForm_Client.GetFirstSelectedRowDataBoundItem

                    If e.Column.FieldName = NielsenFramework.DTO.Client.Properties.IsNCCSubscribed.ToString Then

                        Client.IsNCCSubscribed = CBool(e.Value)

                        If Not Client.IsNCCSubscribed Then

                            Client.FusionDiaryMarkets = False
                            Client.FusionMeteredMarkets = False

                        End If

                    ElseIf e.Column.FieldName = NielsenFramework.DTO.Client.Properties.FusionDiaryMarkets.ToString Then

                        Client.FusionDiaryMarkets = CBool(e.Value)

                    ElseIf e.Column.FieldName = NielsenFramework.DTO.Client.Properties.FusionMeteredMarkets.ToString Then

                        Client.FusionMeteredMarkets = CBool(e.Value)

                    ElseIf e.Column.FieldName = NielsenFramework.DTO.Client.Properties.IsInactive.ToString Then

                        Client.IsInactive = CBool(e.Value)

                    End If

                    If Client IsNot Nothing Then

                        Saved = _Controller.UpdateFlags(Client, ErrorMessage)

                        If Not Saved Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                        RefreshViewModel(Saved)

                    End If

                Else

                End If

            ElseIf e.Column.FieldName = NielsenFramework.DTO.Client.Properties.IsNCCSubscribed.ToString AndAlso e.Value = False Then

                DataGridViewForm_Client.CurrentView.SetRowCellValue(e.RowHandle, "FusionDiaryMarkets", False)
                DataGridViewForm_Client.CurrentView.SetRowCellValue(e.RowHandle, "FusionMeteredMarkets", False)

            End If

        End Sub
        Private Sub DataGridViewForm_Client_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Client.FocusedRowChangedEvent

            _Controller.ClientSelectionChanged(_ViewModel, DataGridViewForm_Client.IsNewItemRow, DataGridViewForm_Client.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_Client_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Client.InitNewRowEvent

            _Controller.InitNewRowEvent(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_Client_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Client.ShowingEditorEvent

            If DataGridViewForm_Client.CurrentView.FocusedColumn.FieldName = NielsenFramework.DTO.Client.Properties.Code.ToString AndAlso
                    DataGridViewForm_Client.CurrentView.FocusedRowHandle >= 0 Then

                e.Cancel = True

            ElseIf DirectCast(DataGridViewForm_Client.CurrentView.GetRow(DataGridViewForm_Client.CurrentView.FocusedRowHandle), NielsenFramework.DTO.Client) IsNot Nothing Then

                If (DataGridViewForm_Client.CurrentView.FocusedColumn.FieldName = NielsenFramework.DTO.Client.Properties.FusionMeteredMarkets.ToString OrElse
                    DataGridViewForm_Client.CurrentView.FocusedColumn.FieldName = NielsenFramework.DTO.Client.Properties.FusionDiaryMarkets.ToString) AndAlso
                    DirectCast(DataGridViewForm_Client.CurrentView.GetRow(DataGridViewForm_Client.CurrentView.FocusedRowHandle), NielsenFramework.DTO.Client).IsNCCSubscribed = False Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Client_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_Client.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewForm_Client.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_Client.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    Else

                        DataGridViewForm_Client.CurrentView.NewItemRowText = e.ErrorText
                        DataGridViewForm_Client.CurrentView.RefreshRow(e.RowHandle)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Client_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_Client.ValidatingEditorEvent

            'objects
            Dim FocusedRow As Object = Nothing
            Dim ErrorText As String = Nothing

            FocusedRow = DataGridViewForm_Client.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing AndAlso TypeOf FocusedRow Is NielsenFramework.DTO.Client Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewForm_Client.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewForm_Client.CurrentView.SetColumnError(DataGridViewForm_Client.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace