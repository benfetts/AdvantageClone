Namespace Maintenance.Media.Presentation

    Public Class MediaBuyerSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaBuyerSetupController = Nothing

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

            If TypeOf RowObject Is AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel Then

                Me.ShowWaitForm("Processing...")

                If Not _Controller.Add(RowObject, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewForm_MediaBuyer.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewForm_MediaBuyer.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_MediaBuyer.CurrentView.RefreshData()

            End If

            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaBuyerSetupForm As Maintenance.Media.Presentation.MediaBuyerSetupForm = Nothing

            MediaBuyerSetupForm = New Maintenance.Media.Presentation.MediaBuyerSetupForm()

            MediaBuyerSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBuyerSetupForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.MediaBuyerSetupController(Me.Session)

            _ViewModel = _Controller.Load()

        End Sub
        Private Sub MediaBuyerSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewForm_MediaBuyer.DataSource = _ViewModel.MediaBuyers

            If DataGridViewForm_MediaBuyer.Columns(AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeName) IsNot Nothing Then

                DataGridViewForm_MediaBuyer.Columns(AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeName).OptionsColumn.AllowFocus = False

            End If

            RefreshViewModel(False)

            DataGridViewForm_MediaBuyer.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            DataGridViewForm_MediaBuyer.CurrentView.BestFitColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_MediaBuyer.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""), _Controller.GetAgency(), _Controller.Session)

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_MediaBuyer.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewForm_MediaBuyer.HasASelectedRow Then

                DataGridViewForm_MediaBuyer.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    If Not _Controller.Delete(_ViewModel, ErrorMessage) Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_MediaBuyer.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                    _Controller.MediaBuyerSelectionChanged(_ViewModel, DataGridViewForm_MediaBuyer.IsNewItemRow,
                                                   DataGridViewForm_MediaBuyer.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel).ToList)

                End If

            End If

        End Sub
		Private Sub DataGridViewForm_MediaBuyer_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_MediaBuyer.CellValueChangedEvent

			If e.Column.FieldName = AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeCode.ToString Then

				DirectCast(DataGridViewForm_MediaBuyer.CurrentView.GetRow(e.RowHandle), AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel).EmployeeName = _Controller.GetRepositoryEmployeeName(_ViewModel, e.Value)

			End If

		End Sub
		Private Sub DataGridViewForm_MediaBuyer_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_MediaBuyer.CellValueChangingEvent

			'objects
			Dim MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel = Nothing
			Dim ErrorMessage As String = Nothing

			If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso
					e.Column.FieldName = AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.IsInactive.ToString Then

				MediaBuyerSetupDetailViewModel = DataGridViewForm_MediaBuyer.GetFirstSelectedRowDataBoundItem

				If MediaBuyerSetupDetailViewModel IsNot Nothing Then

					Saved = _Controller.UpdateInactiveFlag(MediaBuyerSetupDetailViewModel, e.Value, ErrorMessage)

					If Not Saved Then

						AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

					End If

					RefreshViewModel(Saved)

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_MediaBuyer_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_MediaBuyer.InitNewRowEvent

            _Controller.InitNewRowEvent(_ViewModel)

            RefreshViewModel(False)

        End Sub
		Private Sub DataGridViewForm_MediaBuyer_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_MediaBuyer.RepositoryDataSourceLoadingEvent

			Datasource = _ViewModel.RepositoryEmployeeList

		End Sub
		Private Sub DataGridViewForm_MediaBuyer_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_MediaBuyer.SelectionChangedEvent

            _Controller.MediaBuyerSelectionChanged(_ViewModel, DataGridViewForm_MediaBuyer.IsNewItemRow,
                                                   DataGridViewForm_MediaBuyer.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel).ToList)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_MediaBuyer_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_MediaBuyer.ShowingEditorEvent

            If Not DataGridViewForm_MediaBuyer.CurrentView.IsNewItemRow(DataGridViewForm_MediaBuyer.CurrentView.FocusedRowHandle) AndAlso
                    DataGridViewForm_MediaBuyer.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeCode.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_MediaBuyer_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_MediaBuyer.ValidatingEditorEvent

            Dim FocusedRow As Object = Nothing
            Dim ErrorText As String = Nothing

            FocusedRow = DataGridViewForm_MediaBuyer.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing AndAlso TypeOf FocusedRow Is AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewForm_MediaBuyer.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewForm_MediaBuyer.CurrentView.SetColumnError(DataGridViewForm_MediaBuyer.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewForm_MediaBuyer_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_MediaBuyer.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewForm_MediaBuyer.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_MediaBuyer.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        'RaiseEvent BeforeAddNewRowEvent(e.Row, CancelNewRow)

                        'If CancelNewRow = False Then

                        AddNewRow(e.Row)

                        '    SetCustomRowCellEdit(e.RowHandle)

                        'Else

                        '    e.Valid = False

                        'End If

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace