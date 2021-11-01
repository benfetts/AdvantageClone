Namespace Maintenance.Media.Presentation

    Public Class InvoiceMatchingSettingsSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.InvoiceMatchingSettingSetupController = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub AddNewRow(RowObject As Object)

            Dim ErrorMessage As String = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.InvoiceMatchingSetting Then

                Me.ShowWaitForm("Processing...")

                If Not _Controller.Add(RowObject, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewForm_InvoiceMatchingSetting.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_InvoiceMatchingSetting.CurrentView.RefreshData()

            End If

            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
            ButtonItemActions_Save.Enabled = If(_ViewModel.IsNewRow, False, Me.UserEntryChanged)
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Copy.Enabled = If(_ViewModel.IsNewRow, False, Not Me.UserEntryChanged)

            ButtonItemTime_SeparationSettings.Enabled = Not _ViewModel.IsNewRow AndAlso _ViewModel.HasASelectedInvoiceMatchingSetting

        End Sub
        Private Sub Save()

            'objects
            Dim InvoiceMatchingSettings As Generic.List(Of AdvantageFramework.Database.Entities.InvoiceMatchingSetting) = Nothing

            If DataGridViewForm_InvoiceMatchingSetting.HasRows Then

                DataGridViewForm_InvoiceMatchingSetting.CurrentView.CloseEditorForUpdating()

                InvoiceMatchingSettings = DataGridViewForm_InvoiceMatchingSetting.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.InvoiceMatchingSetting)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    _Controller.Save(_ViewModel)

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_InvoiceMatchingSetting.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim InvoiceMatchingSettingsSetupForm As Maintenance.Media.Presentation.InvoiceMatchingSettingsSetupForm = Nothing

            InvoiceMatchingSettingsSetupForm = New Maintenance.Media.Presentation.InvoiceMatchingSettingsSetupForm()

            InvoiceMatchingSettingsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub InvoiceMatchingSettingsSetupForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemTime_SeparationSettings.Image = AdvantageFramework.My.Resources.EditImage

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.InvoiceMatchingSettingSetupController(Me.Session)

            _ViewModel = _Controller.Load()

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_InvoiceMatchingSetting.GridControl.ToolTipController = _ToolTipController

        End Sub
        Private Sub InvoiceMatchingSettingsSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewForm_InvoiceMatchingSetting.DataSource = _ViewModel.InvoiceMatchingSettings
            DataGridViewForm_InvoiceMatchingSetting.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            RefreshViewModel(True)

            'DataGridViewForm_InvoiceMatchingSetting.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

            DataGridViewForm_InvoiceMatchingSetting.CurrentView.BestFitColumns()

        End Sub
        Private Sub InvoiceMatchingSettingsSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Copy.Enabled = Not Me.UserEntryChanged

        End Sub
        Private Sub InvoiceMatchingSettingsSetupForm_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Copy.Enabled = Not Me.UserEntryChanged

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

            If e.SelectedControl Is DataGridViewForm_InvoiceMatchingSetting.GridControl Then

                Try

                    GridView = CType(DataGridViewForm_InvoiceMatchingSetting.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.AdjacencyBefore.ToString Then

                            ToolTipText = "Allow spots airing this many minutes before scheduled air time"

                            RowValue = DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.AdjacencyBefore.ToString)

                        ElseIf GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.AdjacencyAfter.ToString Then

                            ToolTipText = "Allow spots airing this many minutes after scheduled air time"

                            RowValue = DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.AdjacencyAfter.ToString)

                        ElseIf GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.BookendMaxSeparation.ToString Then

                            ToolTipText = "Bookend maximum separation in minutes"

                            RowValue = DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.BookendMaxSeparation.ToString)

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
        Private Sub ButtonItemActions_Export_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_InvoiceMatchingSetting.Print(Me.Session, DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim Deleted As Boolean = False

            If DataGridViewForm_InvoiceMatchingSetting.HasASelectedRow Then

                DataGridViewForm_InvoiceMatchingSetting.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        Deleted = _Controller.Delete(_ViewModel)

                    Catch ex As Exception

                    End Try

                    RefreshViewModel(True)

                    If Deleted Then

                        DataGridViewForm_InvoiceMatchingSetting.GridViewSelectionChanged()

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_InvoiceMatchingSetting.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_InvoiceMatchingSetting.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            Dim SelectedClients As IEnumerable = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            'If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

            '    If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

            '        Save()

            '    Else

            '        AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            '    End If

            'End If

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            ParameterDictionary.Add("ExcludeClientCodes", _ViewModel.InvoiceMatchingSettings.Where(Function(Entity) Entity.ClientCode IsNot Nothing AndAlso
                                                                                                            Entity.MediaTypeCode = _ViewModel.SelectedInvoiceMatchingSetting.MediaTypeCode).Select(Function(Entity) Entity.ClientCode).ToList)

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Client, True, True, SelectedClients, Title:="Select Clients to Copy To", ParameterDictionary:=ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                _Controller.CopyTo(_ViewModel, SelectedClients)

                RefreshViewModel(True)

            End If

        End Sub
        Private Sub DataGridViewForm_InvoiceMatchingSetting_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_InvoiceMatchingSetting.InitNewRowEvent

            _Controller.InitNewRowEvent(_ViewModel)

            If DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting).MediaTypeCode = "T" Then

                DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting).BookendMaxSeparation = 3

            ElseIf DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting).MediaTypeCode = "R" Then

                DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting).BookendMaxSeparation = 0

            End If

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_InvoiceMatchingSetting_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_InvoiceMatchingSetting.QueryPopupNeedDatasourceEvent

            Dim InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting = Nothing

            If FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.ClientCode.ToString Then

                InvoiceMatchingSetting = DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting)

                If InvoiceMatchingSetting IsNot Nothing AndAlso InvoiceMatchingSetting.MediaTypeCode IsNot Nothing Then

                    OverrideDefaultDatasource = True
                    Datasource = _Controller.GetAvailableClients(_ViewModel, InvoiceMatchingSetting.MediaTypeCode)

                Else

                    OverrideDefaultDatasource = True
                    Datasource = _ViewModel.Clients

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_InvoiceMatchingSetting_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_InvoiceMatchingSetting.ShowingEditorEvent

            Dim InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting = Nothing

            InvoiceMatchingSetting = DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting)

            If Not DataGridViewForm_InvoiceMatchingSetting.IsNewItemRow Then

                If DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.MediaTypeCode.ToString OrElse
                        DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.ClientCode.ToString Then

                    e.Cancel = True

                ElseIf InvoiceMatchingSetting IsNot Nothing AndAlso InvoiceMatchingSetting.MediaTypeCode IsNot Nothing AndAlso InvoiceMatchingSetting.MediaTypeCode = "R" AndAlso
                        (DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.VerifyNetwork.ToString OrElse
                         DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.BookendMaxSeparation.ToString) Then

                    e.Cancel = True

                End If

            Else

                If InvoiceMatchingSetting Is Nothing Then

                    If DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.MediaTypeCode.ToString Then

                        e.Cancel = True

                    End If

                Else

                    If InvoiceMatchingSetting.MediaTypeCode IsNot Nothing AndAlso InvoiceMatchingSetting.MediaTypeCode = "R" AndAlso
                            (DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.VerifyNetwork.ToString OrElse
                             DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.BookendMaxSeparation.ToString) Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemTime_SeparationSettings_Click(sender As Object, e As EventArgs) Handles ButtonItemTime_SeparationSettings.Click

            AdvantageFramework.Maintenance.Media.Presentation.TimeSeparationSettingsEditDialog.ShowFormDialog(_ViewModel.SelectedInvoiceMatchingSetting.ID,
                    AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource.Default)

        End Sub
        Private Sub DataGridViewForm_InvoiceMatchingSetting_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_InvoiceMatchingSetting.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(DirectCast(e.Row, AdvantageFramework.Database.Entities.InvoiceMatchingSetting), e.Valid)

                If DataGridViewForm_InvoiceMatchingSetting.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_InvoiceMatchingSetting.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        'Private Sub DataGridViewForm_InvoiceMatchingSetting_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_InvoiceMatchingSetting.ValidatingEditorEvent

        '    'objects
        '    Dim FocusedRow As Object = Nothing
        '    Dim ErrorText As String = Nothing

        '    FocusedRow = DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetFocusedRow

        '    If FocusedRow IsNot Nothing AndAlso TypeOf FocusedRow Is AdvantageFramework.Database.Entities.InvoiceMatchingSetting Then

        '        ErrorText = _Controller.ValidateProperty(DirectCast(FocusedRow, AdvantageFramework.Database.Entities.InvoiceMatchingSetting), DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

        '        DataGridViewForm_InvoiceMatchingSetting.CurrentView.SetColumnError(DataGridViewForm_InvoiceMatchingSetting.CurrentView.FocusedColumn, ErrorText)

        '        e.Valid = True

        '    End If

        'End Sub
        Private Sub DataGridViewForm_InvoiceMatchingSetting_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_InvoiceMatchingSetting.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.MediaTypeCode.ToString Then

                Datasource = (From Entity In _ViewModel.MediaTypes
                              Select [Code] = Entity.Value,
                                     [Description] = Entity.Display).ToList

            End If

        End Sub
        Private Sub DataGridViewForm_InvoiceMatchingSetting_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_InvoiceMatchingSetting.FocusedRowChangedEvent

            _Controller.InvoiceMatchingSettingSelectionChanged(_ViewModel, DataGridViewForm_InvoiceMatchingSetting.IsNewItemRow,
                                                                           DataGridViewForm_InvoiceMatchingSetting.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_InvoiceMatchingSetting_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_InvoiceMatchingSetting.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.ClientCode.ToString Then

                DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting).ClientName = _Controller.GetClientName(_ViewModel, e.Value)

            End If

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_InvoiceMatchingSetting_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_InvoiceMatchingSetting.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.Database.Entities.InvoiceMatchingSetting.Properties.BookendMaxSeparation.ToString AndAlso
                    DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting) IsNot Nothing AndAlso
                    DirectCast(DataGridViewForm_InvoiceMatchingSetting.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.InvoiceMatchingSetting).MediaTypeCode = "R" Then

                e.DisplayText = ""

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace