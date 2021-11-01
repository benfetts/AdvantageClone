Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetOrderStatusDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetManageOrderViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetManageOrderController = Nothing
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0
        Protected _ReloadGrid As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetMarketID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_MediaBroadcastWorksheetMarketID)

            DataGridViewVendors_Vendors.DataSource = _ViewModel.VendorOrderStatuses
            DataGridViewVendors_Vendors.CurrentView.BestFitColumns()

        End Sub
        Private Sub ShowHideColumns(Show As Boolean)

            Dim VisibleIndex As Integer = 0

            For Each GridColumn In DataGridViewStatus_Statuses.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus), GridColumn.FieldName) Then

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus.Properties.Month.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus.Properties.Year.ToString Then

                        If Show Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    Else

                        GridColumn.Visible = True
                        VisibleIndex += 1

                    End If

                End If

            Next

        End Sub
        Private Sub RefreshViewModel()

            Dim VendorCode As String = Nothing

            If DataGridViewVendors_Vendors.HasASelectedRow Then

                If ButtonItemDisplay_HighestRevisionOnly.Checked Then

                    DataGridViewStatus_Statuses.DataSource = _Controller.GetHighestRevisionStatuses(_ViewModel, DirectCast(DataGridViewVendors_Vendors.GetFirstSelectedRowDataBoundItem(), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.VendorOrderStatus).VendorCode)
                    ShowHideColumns(True)

                ElseIf ButtonItemDisplay_MostRecentStatus.Checked Then

                    DataGridViewStatus_Statuses.DataSource = _Controller.GetMostRecentStatuses(_ViewModel, DirectCast(DataGridViewVendors_Vendors.GetFirstSelectedRowDataBoundItem(), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.VendorOrderStatus).VendorCode)
                    ShowHideColumns(True)

                ElseIf ButtonItemDisplay_MostRecentStatusByWorksheetLine.Checked Then

                    DataGridViewStatus_Statuses.DataSource = _Controller.GetMostRecentStatusesByLine(_ViewModel, DirectCast(DataGridViewVendors_Vendors.GetFirstSelectedRowDataBoundItem(), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.VendorOrderStatus).VendorCode)
                    ShowHideColumns(False)

                Else

                    DataGridViewStatus_Statuses.DataSource = _ViewModel.WorksheetVendorOrderStatuses
                    ShowHideColumns(True)

                End If

            End If

            DataGridViewStatus_Statuses.CurrentView.BestFitColumns()

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewVendors_Vendors.MultiSelect = False
            DataGridViewVendors_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewVendors_Vendors.OptionsBehavior.Editable = False

            DataGridViewStatus_Statuses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewStatus_Statuses.OptionsBehavior.Editable = False
            DataGridViewStatus_Statuses.MultiSelect = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetMarketID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetOrderStatusDialog As MediaBroadcastWorksheetOrderStatusDialog = Nothing

            MediaBroadcastWorksheetOrderStatusDialog = New MediaBroadcastWorksheetOrderStatusDialog(MediaBroadcastWorksheetMarketID)

            ShowFormDialog = MediaBroadcastWorksheetOrderStatusDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetOrderStatusDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemView_Responses.Image = AdvantageFramework.My.Resources.MailOpenImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetManageOrderController(Me.Session)

            ButtonItemDisplay_MostRecentStatusByWorksheetLine.Checked = True

            RibbonBarFilePanel_Display.Visible = False

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetOrderStatusDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

            Me.ClearChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub DataGridViewStatus_Statuses_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewStatus_Statuses.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus.Properties.Month.ToString AndAlso IsNumeric(e.CellValue) Then

                e.DisplayText = MonthName(e.CellValue, True).ToUpper

            End If

        End Sub
        Private Sub ButtonItemView_Responses_Click(sender As Object, e As EventArgs) Handles ButtonItemView_Responses.Click

            If DataGridViewVendors_Vendors.HasASelectedRow Then

                AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMakegoodResponseDialog.ShowFormDialog(_ViewModel.MediaBroadcastWorksheetMarketDetailIDs)

            End If

        End Sub
        Private Sub TabControlPanel_Tabs_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlPanel_Tabs.SelectedTabChanging

            If Me.FormShown Then

                If e.NewTab.Equals(TabItemTabs_Status) Then

                    RibbonBarFilePanel_Display.Visible = True
                    RefreshViewModel()

                Else

                    RibbonBarFilePanel_Display.Visible = False

                End If

            End If

        End Sub
        Private Sub ButtonItemDisplay_HighestRevisionOnly_Click(sender As Object, e As EventArgs) Handles ButtonItemDisplay_HighestRevisionOnly.Click

            If Me.FormShown Then

                ButtonItemDisplay_HighestRevisionOnly.Checked = Not ButtonItemDisplay_HighestRevisionOnly.Checked
                ButtonItemDisplay_MostRecentStatus.Checked = False
                ButtonItemDisplay_MostRecentStatusByWorksheetLine.Checked = False

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemDisplay_MostRecentStatus_Click(sender As Object, e As EventArgs) Handles ButtonItemDisplay_MostRecentStatus.Click

            If Me.FormShown Then

                ButtonItemDisplay_HighestRevisionOnly.Checked = False
                ButtonItemDisplay_MostRecentStatus.Checked = Not ButtonItemDisplay_MostRecentStatus.Checked
                ButtonItemDisplay_MostRecentStatusByWorksheetLine.Checked = False

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemDisplay_MostRecentStatusByWorksheetLine_Click(sender As Object, e As EventArgs) Handles ButtonItemDisplay_MostRecentStatusByWorksheetLine.Click

            If Me.FormShown Then

                ButtonItemDisplay_HighestRevisionOnly.Checked = False
                ButtonItemDisplay_MostRecentStatus.Checked = False
                ButtonItemDisplay_MostRecentStatusByWorksheetLine.Checked = Not ButtonItemDisplay_MostRecentStatusByWorksheetLine.Checked

                RefreshViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
