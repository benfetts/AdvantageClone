Namespace Maintenance.Accounting.Presentation

    Public Class VendorStationsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorStationsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Accounting.VendorStationsController = Nothing

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

                DataGridViewForm_Vendors.CurrentView.RefreshData()

            End If

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim VendorStationsDialog As Maintenance.Accounting.Presentation.VendorStationsDialog = Nothing

            VendorStationsDialog = New Maintenance.Accounting.Presentation.VendorStationsDialog()

            ShowFormDialog = VendorStationsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorStationsDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.VendorStationsController(Me.Session)

        End Sub
        Private Sub VendorStationsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            _ViewModel = _Controller.Load()

            DataGridViewForm_Vendors.DataSource = _ViewModel.VendorStations

            If DataGridViewForm_Vendors.Columns(AdvantageFramework.DTO.VendorStation.Properties.Code.ToString) IsNot Nothing Then

                DataGridViewForm_Vendors.Columns(AdvantageFramework.DTO.VendorStation.Properties.Code.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewForm_Vendors.Columns(AdvantageFramework.DTO.VendorStation.Properties.Name.ToString) IsNot Nothing Then

                DataGridViewForm_Vendors.Columns(AdvantageFramework.DTO.VendorStation.Properties.Name.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewForm_Vendors.Columns(AdvantageFramework.DTO.VendorStation.Properties.VendorCategory.ToString) IsNot Nothing Then

                DataGridViewForm_Vendors.Columns(AdvantageFramework.DTO.VendorStation.Properties.VendorCategory.ToString).OptionsColumn.AllowFocus = False

            End If

            RefreshViewModel(False)

            DataGridViewForm_Vendors.CurrentView.BestFitColumns()

            Me.CloseWaitForm()

        End Sub
        Private Sub VendorStationsDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            _Controller.UserEntryChanged(_ViewModel)

            RefreshViewModel(False)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = Nothing

            Me.ShowWaitForm("Saving...")

            DataGridViewForm_Vendors.CurrentView.CloseEditorForUpdating()

            _ViewModel.VendorStations = DataGridViewForm_Vendors.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.VendorStation).ToList

            If _Controller.Save(_ViewModel, ErrorMessage) Then

                Me.ClearChanged()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub DataGridViewForm_Vendors_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            If e.Column.FieldName = AdvantageFramework.DTO.VendorStation.Properties.IsCableSystem.ToString AndAlso e.Value = True Then

                DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.VendorStation).NielsenTVStationCode = Nothing

            End If

        End Sub
        Private Sub DataGridViewForm_Vendors_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_Vendors.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.DTO.VendorStation.Properties.NielsenRadioStationComboID.ToString Then

                Datasource = _Controller.GetNielsenRadioStations(DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).MarketCode)

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.VendorStation.Properties.NielsenTVStationCode.ToString Then

                Datasource = _Controller.GetNielsenTVStations(DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).MarketCode)

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.VendorStation.Properties.NCCTVSyscodeID.ToString Then

                Datasource = _Controller.GetNCCTVSyscodes(DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).MarketCode)

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewForm_Vendors_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_Vendors.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.VendorStation.Properties.MarketCode.ToString Then

                Datasource = _ViewModel.RepositoryMarkets

            ElseIf FieldName = AdvantageFramework.DTO.VendorStation.Properties.NCCTVSyscodeID.ToString Then

                Datasource = _ViewModel.RepositoryNCCTVSyscodes

            ElseIf FieldName = AdvantageFramework.DTO.VendorStation.Properties.NielsenTVStationCode.ToString Then

                Datasource = _ViewModel.RepositoryNielsenTVStations

            ElseIf FieldName = AdvantageFramework.DTO.VendorStation.Properties.NielsenRadioStationComboID.ToString Then

                Datasource = _ViewModel.RepositoryNielsenRadioStations

            End If

        End Sub
        Private Sub DataGridViewForm_Vendors_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Vendors.ShowingEditorEvent

            If DataGridViewForm_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.VendorStation.Properties.NielsenTVStationCode.ToString AndAlso
                    (DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).VendorCategory = "R" OrElse
                     String.IsNullOrWhiteSpace(DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).MarketCode) OrElse
                     DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).IsCableSystem) Then

                e.Cancel = True

            ElseIf DataGridViewForm_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.VendorStation.Properties.NielsenRadioStationComboID.ToString AndAlso
                    (DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).VendorCategory = "T" OrElse
                     String.IsNullOrWhiteSpace(DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).MarketCode)) Then

                e.Cancel = True

            ElseIf DataGridViewForm_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.VendorStation.Properties.IsCableSystem.ToString AndAlso
                    DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).VendorCategory = "R" Then

                e.Cancel = True

            ElseIf DataGridViewForm_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.VendorStation.Properties.NCCTVSyscodeID.ToString AndAlso
                    (DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).VendorCategory = "R" OrElse
                     String.IsNullOrWhiteSpace(DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).MarketCode) OrElse
                     DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.VendorStation).IsCableSystem = False) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace