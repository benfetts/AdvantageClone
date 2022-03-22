Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _ColumnEditAdded As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Setup_Load()

            Me.ButtonItemReports_PuertoRicoExport.Visible = _ViewModel.IsNielsenPuertoRicoSetup

        End Sub
        Private Sub LoadGrid()

            _Controller.Setup_LoadWorksheets(_ViewModel)

            DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.BeginUpdate()

            DataGridViewLeftSection_MediaBroadcastWorksheets.DataSource = _ViewModel.Worksheets

            DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.EndUpdate()

            For Each GridColumn In DataGridViewLeftSection_MediaBroadcastWorksheets.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.IsInactive.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True

                    If _ColumnEditAdded = False Then

                        If TypeOf GridColumn.ColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                            AddHandler CType(GridColumn.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).EditValueChanging, AddressOf RepositoryItemIsInactive_EditValueChanging
                            _ColumnEditAdded = True

                        End If

                    End If

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

            Next

            If DataGridViewLeftSection_MediaBroadcastWorksheets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.Name.ToString) IsNot Nothing Then

                DataGridViewLeftSection_MediaBroadcastWorksheets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.Name.ToString).OptionsColumn.AllowShowHide = False

            End If

        End Sub
        Private Sub FormatGrid_WorksheetsOneTimeOnly()

            'objects
            Dim LayoutLoaded As Boolean = False

            DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.BeginUpdate()

            DataGridViewLeftSection_MediaBroadcastWorksheets.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet)

            DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.EndUpdate()

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(DataGridViewLeftSection_MediaBroadcastWorksheets, _ViewModel.WorksheetGridLayout, RemoveOldColumns:=True)

            If DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.RestoredLayoutNonVisibleGridColumnList IsNot Nothing AndAlso
                    DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.RestoredLayoutNonVisibleGridColumnList.Count > 0 AndAlso
                    DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.Columns("ID") IsNot Nothing Then

                If DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.RestoredLayoutNonVisibleGridColumnList.Contains(DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.Columns("ID")) Then

                    DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.RestoredLayoutNonVisibleGridColumnList.Remove(DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.Columns("ID"))

                End If

            End If

        End Sub
        Private Sub LoadDashboard()

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            'DashboardViewerDashboard_Dashboard.Dashboard.BeginUpdate()

            If _ViewModel.Dashboard IsNot Nothing AndAlso _ViewModel.Dashboard.Layout IsNot Nothing AndAlso _ViewModel.Dashboard.Layout.Length > 0 Then

                MemoryStream = New System.IO.MemoryStream(_ViewModel.Dashboard.Layout)

                DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

            Else

                If AdvantageFramework.My.Resources.MediaBroadcastWorksheetSetupDashboard IsNot Nothing AndAlso AdvantageFramework.My.Resources.MediaBroadcastWorksheetSetupDashboard.Length > 0 Then

                    MemoryStream = New System.IO.MemoryStream(AdvantageFramework.My.Resources.MediaBroadcastWorksheetSetupDashboard)

                    DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

                End If

            End If

            'DashboardViewerDashboard_Dashboard.Dashboard.EndUpdate()

        End Sub
        Private Sub LoadDashboardDataSource()

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Add(_ViewModel.DashboardDataSource)

                Else

                    DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0).Data = _ViewModel.DashboardDataSource

                End If

                DashboardViewerDashboard_Dashboard.Refresh()

            End If

        End Sub
        Private Sub LoadWorksheetMarketsGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            _Controller.Setup_LoadSelectedWorksheetMarkets(_ViewModel)

            DataGridViewRightSection_Markets.CurrentView.BeginUpdate()

            DataGridViewRightSection_Markets.DataSource = _ViewModel.SelectedWorksheetMarkets

            If DataGridViewRightSection_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = DirectCast(DataGridViewRightSection_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString).ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)

                If _ViewModel.HasASelectedWorksheet AndAlso _ViewModel.SelectedWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                    SubItemGridLookUpEditControl.DataSource = _ViewModel.NielsenTVBooks

                ElseIf _ViewModel.HasASelectedWorksheet AndAlso _ViewModel.SelectedWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                    SubItemGridLookUpEditControl.DataSource = _ViewModel.ComscoreTVBooks

                Else

                    SubItemGridLookUpEditControl.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

                End If

            End If

            If DataGridViewRightSection_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = DirectCast(DataGridViewRightSection_Markets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString).ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)

                If _ViewModel.HasASelectedWorksheet AndAlso _ViewModel.SelectedWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                    SubItemGridLookUpEditControl.DataSource = _ViewModel.NielsenTVBooks

                ElseIf _ViewModel.HasASelectedWorksheet AndAlso _ViewModel.SelectedWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                    SubItemGridLookUpEditControl.DataSource = _ViewModel.ComscoreTVBooks

                Else

                    SubItemGridLookUpEditControl.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

                End If

            End If

            FormatGrid_WorksheetMarkets()

            DataGridViewRightSection_Markets.CurrentView.EndUpdate()

            DataGridViewRightSection_Markets.CurrentView.BestFitColumns()

        End Sub
        Private Sub RefreshViewModel(RefreshWorksheets As Boolean, RefreshWorksheetDetails As Boolean)

            If RefreshWorksheets Then

                DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.RefreshData()

            End If

            If RefreshWorksheetDetails Then

                DataGridViewRightSection_Markets.CurrentView.RefreshData()

            End If

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Update.Enabled = _ViewModel.UpdateEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Copy.Enabled = _ViewModel.CopyEnabled
            ButtonItemActions_Refresh.Enabled = _ViewModel.RefreshEnabled

            ButtonItemMarkets_Manage.Enabled = _ViewModel.ManageMarketsEnabled
            ButtonItemMarkets_Goals.Enabled = _ViewModel.ViewMarketGoalsEnabled
            ButtonItemMarkets_Schedules.Enabled = _ViewModel.ViewMarketDetailsEnabled
            ButtonItemMarkets_ViewOrderDetails.Enabled = (_ViewModel.HasASelectedWorksheet AndAlso _ViewModel.HasASelectedWorksheetMarket)

            ButtonItemDashboard_Edit.Enabled = _ViewModel.DashboardEditEnabled

            ButtonItemPrint_Print.Enabled = (_ViewModel.HasASelectedWorksheet AndAlso _ViewModel.HasASelectedWorksheetMarket)

            ButtonItemReports_PreBuy.Enabled = (_ViewModel.HasASelectedWorksheet AndAlso _ViewModel.IsCanadianWorksheet = False)
            ButtonItemReports_PostBuy.Enabled = (_ViewModel.HasASelectedWorksheet AndAlso _ViewModel.IsCanadianWorksheet = False)

            ButtonItemReports_BroadcastSchedule.Enabled = (_ViewModel.HasASelectedWorksheet)
            ButtonItemReports_Other.Enabled = _ViewModel.HasASelectedWorksheet 'AndAlso _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV

            ButtonItemReports_PuertoRicoExport.Enabled = (_ViewModel.HasASelectedWorksheet AndAlso _ViewModel.SelectedWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico)

        End Sub
        Private Sub FormatGrid_WorksheetMarkets()

            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.OrderStatus.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedByUserCode.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedDate.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.Length.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodStart.ToString)
            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodEnd.ToString)

            If _ViewModel.SelectedWorksheet IsNot Nothing Then

                If _ViewModel.ShowPendingMakegoods Then

                    DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PendingMakegood.ToString)

                Else

                    DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PendingMakegood.ToString)

                End If

                If _ViewModel.SelectedWorksheet.IsCanadianWorksheet Then

                    DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                    AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                    RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)

                Else

                    If _ViewModel.SelectedWorksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)

                        If _ViewModel.SelectedWorksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                            If DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString) IsNot Nothing Then

                                DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString).Caption = "SIU"

                            End If

                        Else

                            If DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString) IsNot Nothing Then

                                DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString).Caption = "H/PUT Book"

                            End If

                        End If

                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                        If _ViewModel.SelectedWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                            DataGridViewRightSection_Markets.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                            DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodStart.ToString)
                            DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.PeriodEnd.ToString)

                        End If

                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)

                    ElseIf _ViewModel.SelectedWorksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                        If Me.Session.IsNielsenSetup Then

                            DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)
                            AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)

                        Else

                            RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString)

                        End If

                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)
                        DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)
                        AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString)

                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                        RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)

                        'ElseIf _ViewModel.SelectedWorksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.NetworkTV Then

                        '	DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.OrderStatus.ToString)

                        '	AddColumnToGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.OrderStatus.ToString)

                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.SharebookNielsenTVBookID.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.HUTPUTNielsenTVBookID.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString)
                        '	RemoveColumnFromGridFunctions(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString)

                    End If

                End If

                DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedByUserCode.ToString)
                DataGridViewRightSection_Markets.MakeColumnVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedDate.ToString)

            End If

        End Sub
        Private Sub RemoveColumnFromGridFunctions(ColumnFieldName As String)

            If DataGridViewRightSection_Markets.Columns(ColumnFieldName) IsNot Nothing Then

                DataGridViewRightSection_Markets.Columns(ColumnFieldName).OptionsColumn.ShowInCustomizationForm = False
                DataGridViewRightSection_Markets.Columns(ColumnFieldName).OptionsColumn.ShowInExpressionEditor = False
                DataGridViewRightSection_Markets.Columns(ColumnFieldName).OptionsColumn.AllowShowHide = False

            End If

        End Sub
        Private Sub AddColumnToGridFunctions(ColumnFieldName As String)

            If DataGridViewRightSection_Markets.Columns(ColumnFieldName) IsNot Nothing Then

                DataGridViewRightSection_Markets.Columns(ColumnFieldName).OptionsColumn.ShowInCustomizationForm = True
                DataGridViewRightSection_Markets.Columns(ColumnFieldName).OptionsColumn.ShowInExpressionEditor = True
                DataGridViewRightSection_Markets.Columns(ColumnFieldName).OptionsColumn.AllowShowHide = True

            End If

        End Sub
        Private Sub FormatGrid_WorksheetMarketsOneTimeOnly()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
            DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketDescription.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

            If DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.Setup_GetRepositoryMarketTVGeography(_ViewModel)

                DataGridViewRightSection_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketTVGeographyID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.Setup_GetRepositoryExternalRadioSource(_ViewModel)

                DataGridViewRightSection_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ExternalRadioSource.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.Setup_GetRepositoryMarketRadioGeography(_ViewModel)

                DataGridViewRightSection_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioGeographyID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.Setup_GetRepositoryMarketRadioEthnicity(_ViewModel)

                DataGridViewRightSection_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedByUserCode.ToString) IsNot Nothing Then

                DataGridViewRightSection_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.ModifiedByUserCode.ToString).Caption = "Modified By"

            End If

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsBehavior.Editable = True
            DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsSelection.MultiSelect = False
            DataGridViewLeftSection_MediaBroadcastWorksheets.ByPassUserEntryChanged = True
            DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.ModifyColumnSettingsOnEachDataSource = False

            DataGridViewRightSection_Markets.ItemDescription = "Market Schedule(s)"
            DataGridViewRightSection_Markets.OptionsBehavior.Editable = False
            DataGridViewRightSection_Markets.OptionsSelection.MultiSelect = False
            DataGridViewRightSection_Markets.ModifyColumnSettingsOnEachDataSource = False
            DataGridViewRightSection_Markets.GridControl.ToolTipController = Me.ToolTipController

        End Sub
        Private Sub ViewWorksheet(SelectedWorksheetID As Integer, SelectedWorksheetMarketID As Integer)

            'objects
            Dim LockedByUserEmployeeName As String = Nothing

            If CheckForOpenWorksheet(Me.MdiParent, SelectedWorksheetID, SelectedWorksheetMarketID) = False Then

                If _Controller.IsWorksheetMarketLocked(SelectedWorksheetMarketID, LockedByUserEmployeeName) Then

                    AdvantageFramework.WinForm.MessageBox.Show(LockedByUserEmployeeName)

                Else

                    MediaBroadcastWorksheetMarketDetailForm.ShowForm(SelectedWorksheetID, SelectedWorksheetMarketID)

                End If

            End If

        End Sub
        Private Sub CreateReport(XtraReport As Type)

            'objects
            Dim BuyType As Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.BuyType = Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.BuyType.Post
            Dim MediaType As Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.MediaType = Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.MediaType.TV
            Dim ParameterDictionary As Dictionary(Of String, Object) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaBroadcastWorksheetPrintOptions As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrintOptions = Nothing
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
            Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing
            Dim AgencyImportPath As String = String.Empty
            Dim IsPuertoRico As Boolean = False

            If InStr(XtraReport.ToString, "PreBuy") > 1 Then

                BuyType = Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.BuyType.Pre

            End If

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                MediaType = Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.MediaType.Radio

            End If

            If _ViewModel.SelectedWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                IsPuertoRico = True

            End If

            If AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ShowFormDialog(ParameterDictionary, BuyType, MediaType, _ViewModel.SelectedWorksheet.ID, IsPuertoRico) = Windows.Forms.DialogResult.OK Then

                Me.ShowWaitForm("Loading...")

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    MediaBroadcastWorksheetPrintOptions = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetPrintOptions.LoadByUserCode(DbContext, Me.Session.UserCode)

                    If MediaBroadcastWorksheetPrintOptions IsNot Nothing Then

                        Using DataContext As New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, MediaBroadcastWorksheetPrintOptions.LocationCode)

                        End Using

                    End If

                End Using

                Select Case XtraReport

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyDaypartSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetPreBuyDaypartSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetPreBuyReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationDaypartSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetPreBuyStationDaypartSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetPreBuyStationSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyDaypartSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetPostBuyDaypartSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetPostBuyReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationDaypartSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetPostBuyStationDaypartSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetPostBuyStationSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetRadioPreBuyReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetRadioPreBuyStationSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetRadioPostBuyReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport(Me.Session, ParameterDictionary, Location)

                    Case GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationSummaryReport)

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetRadioPostBuyStationSummaryReport(Me.Session, ParameterDictionary, Location)

                End Select

                If Report IsNot Nothing Then

                    ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                            If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedWorksheet.Name)
                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                            ReportPrintTool.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedWorksheet.Name), False))

                            ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        Else

                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedWorksheet.Name)

                        End If

                    End Using

                    Report.CreateDocument()

                    Me.CloseWaitForm()

                    If (Report.RowCount = 0) Then
                        AdvantageFramework.WinForm.MessageBox.Show("No records found.")
                        Report = Nothing
                    Else
                        ReportPrintTool.ShowRibbonPreviewDialog()
                    End If

                End If

            End If

        End Sub
        Private Sub CreateBroadcastScheduleCriteria(MediaBroadcastWorksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet,
                                                    MediaBroadcastWorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket))

            Dim ParameterDictionary As Dictionary(Of String, Object) = Nothing

            ' ** Braxton **

            If AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog.ShowFormDialog(ParameterDictionary, _ViewModel.SelectedWorksheet.ID,
                    If(_ViewModel.SelectedWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico, True, False)) = Windows.Forms.DialogResult.OK Then

                Me.ShowWaitForm("Loading...")

            End If

        End Sub
        Private Sub UpdateWorksheetDetailFormsWorksheetPrintOptions()

            Try

                For Each MdiChild In Me.ParentForm.MdiChildren

                    If TypeOf MdiChild Is AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketDetailForm Then

                        DirectCast(MdiChild, AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketDetailForm).UpdateWorksheetPrintOptions(_ViewModel.WorksheetPrintOptions)

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SaveGridLayout()

            Dim AFActiveFilterString As String = String.Empty

            AFActiveFilterString = DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.AFActiveFilterString

            AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Me.Session, DataGridViewLeftSection_MediaBroadcastWorksheets, AdvantageFramework.Database.Entities.GridAdvantageType.MediaBroadcastWorksheet)

            DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.AFActiveFilterString = AFActiveFilterString

        End Sub
        Public Sub RefreshForm()

            'Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            'LoadGrid()

            'Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

            'LoadWorksheetMarketsGrid()

            'LoadDashboardDataSource()

            RefreshViewModel(False, True)

        End Sub
        Public Sub UpdateWorksheetPrintOptions(WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions)

            _ViewModel.WorksheetPrintOptions = WorksheetPrintOptions

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaBroadcastWorksheetSetupForm As MediaBroadcastWorksheetSetupForm = Nothing

            MediaBroadcastWorksheetSetupForm = New MediaBroadcastWorksheetSetupForm

            MediaBroadcastWorksheetSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetSetupForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                SaveGridLayout()

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_SearchByOrderNumber.Image = AdvantageFramework.My.Resources.ViewImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_ShowMissingTrafficInstructions.Image = AdvantageFramework.My.Resources.MovieReelFilledImage
            ButtonItemActions_FilterPendingMakegoods.Image = AdvantageFramework.My.Resources.FilterImage
            ButtonItemActions_ReplaceBuyer.Image = AdvantageFramework.My.Resources.ViewImage

            ButtonItemMarkets_Manage.Image = AdvantageFramework.My.Resources.QuickManageImage
            ButtonItemMarkets_Goals.Image = AdvantageFramework.My.Resources.FinishImage
            ButtonItemMarkets_Schedules.Image = AdvantageFramework.My.Resources.TotalFieldsImage
            ButtonItemMarkets_ViewOrderDetails.Image = AdvantageFramework.My.Resources.ViewImage

            ButtonItemPrint_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemPrint_Settings.Image = AdvantageFramework.My.Resources.ReportEditImage

            ButtonItemReports_PreBuy.Image = AdvantageFramework.My.Resources.ReportImage
            ButtonItemReports_PostBuy.Image = AdvantageFramework.My.Resources.ReportImage
            ButtonItemReports_BroadcastSchedule.Image = AdvantageFramework.My.Resources.ReportImage
            ButtonItemReports_Other.Image = AdvantageFramework.My.Resources.ReportImage
            ButtonItemReports_PuertoRicoExport.Image = AdvantageFramework.My.Resources.ReportImage

            ButtonItemDashboard_Edit.Image = AdvantageFramework.My.Resources.EditImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

        End Sub
        Private Sub MediaBroadcastWorksheetSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If AdvantageFramework.Security.IsMediaToolUser(Me.Session, Me.Session.User.ID) Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                LoadViewModel()

                FormatGrid_WorksheetsOneTimeOnly()

                LoadGrid()

                If DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.PendingMakegood.ToString) IsNot Nothing Then

                    DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.PendingMakegood.ToString).Visible = False

                End If

                LoadDashboard()

                LoadWorksheetMarketsGrid()

                FormatGrid_WorksheetMarketsOneTimeOnly()

                RefreshViewModel(True, True)

                DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                ButtonItemActions_ShowMissingTrafficInstructions.SecurityEnabled = _ViewModel.UserHasAccessToMediaTraffic

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.BestFitColumns()
                DataGridViewRightSection_Markets.CurrentView.BestFitColumns()

                DataGridViewLeftSection_MediaBroadcastWorksheets.FocusToFindPanel(False)

                DataGridViewLeftSection_MediaBroadcastWorksheets.HideRowSelection()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("You must be a Media Tools User to access this module.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemMarkets_Schedules_Click(sender As Object, e As System.EventArgs) Handles ButtonItemMarkets_Schedules.Click

            If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                ViewWorksheet(_ViewModel.SelectedWorksheet.ID, _ViewModel.SelectedWorksheetMarket.ID)

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim MediaBroadcastWorksheetID As Integer = 0

            If MediaBroadcastWorksheetEditDialog.ShowFormDialog(MediaBroadcastWorksheetID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                LoadGrid()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If MediaBroadcastWorksheetID <> 0 Then

                    DataGridViewLeftSection_MediaBroadcastWorksheets.SelectRow(0, MediaBroadcastWorksheetID)

                End If

                DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

                LoadWorksheetMarketsGrid()

                RefreshViewModel(False, True)

            End If

        End Sub
        Private Sub ButtonItemActions_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim Message As String = Nothing

            If _Controller.IsAnyMarketLockedByWorksheet(_ViewModel.SelectedWorksheet.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                If MediaBroadcastWorksheetEditDialog.ShowFormDialog(_ViewModel.SelectedWorksheet.ID) = Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading, "Loading...")

                    LoadGrid()

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

                    LoadWorksheetMarketsGrid()

                    RefreshViewModel(True, True)

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If _Controller.IsAnyMarketLockedByWorksheet(_ViewModel.SelectedWorksheet.ID, ErrorMessage) Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage.Replace("Cannot update Worksheet settings", "Cannot delete Worksheet"))

            Else

                If IsAnyWorksheetMarketOpen(Me.MdiParent, _ViewModel.SelectedWorksheet.ID) = False Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this broadcast worksheet?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                        _Controller.Edit_Delete(_ViewModel.SelectedWorksheet, ErrorMessage)

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                            LoadGrid()

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                            DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

                            LoadWorksheetMarketsGrid()

                            RefreshViewModel(True, True)

                            Me.CloseWaitForm()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)
                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please close Worksheet schedule(s) before deleting.")

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            If MediaBroadcastWorksheetCopyDialog.ShowFormDialog(_ViewModel.SelectedWorksheet.ID, False) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                LoadGrid()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

                LoadWorksheetMarketsGrid()

                RefreshViewModel(True, True)

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemCopy_WithNewCDP_Click(sender As Object, e As EventArgs) Handles ButtonItemCopy_WithNewCDP.Click

            If MediaBroadcastWorksheetCopyDialog.ShowFormDialog(_ViewModel.SelectedWorksheet.ID, True) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                LoadGrid()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

                LoadWorksheetMarketsGrid()

                RefreshViewModel(True, True)

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_SearchByOrderNumber_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_SearchByOrderNumber.Click

            'objects
            Dim OrderNumber As Integer = 0
            Dim OrderNumberSearchResult As AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.OrderNumberSearchResult = Nothing
            Dim Message As String = String.Empty

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Order Number Search", "Enter Order Number", Nothing, OrderNumber, Nothing, AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Integer, True) = Windows.Forms.DialogResult.OK Then

                OrderNumberSearchResult = _Controller.SearchByOrderNumber(OrderNumber, Message)

                If OrderNumberSearchResult Is Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show(Me, Message)

                Else

                    DataGridViewLeftSection_MediaBroadcastWorksheets.SelectRow(0, OrderNumberSearchResult.WorksheetID)

                    If DataGridViewLeftSection_MediaBroadcastWorksheets.HasASelectedRow Then

                        DataGridViewRightSection_Markets.SelectRow(1, OrderNumberSearchResult.WorksheetMarketID)

                    End If

                    If AdvantageFramework.WinForm.MessageBox.Show(Me, "Do you want to open this worksheet?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        ViewWorksheet(OrderNumberSearchResult.WorksheetID, OrderNumberSearchResult.WorksheetMarketID)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading, "Loading...")

            LoadGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

            LoadWorksheetMarketsGrid()

            RefreshViewModel(True, True)

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_ShowMissingTrafficInstructions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowMissingTrafficInstructions.CheckedChanged

            Dim WorksheetIDs As IEnumerable(Of Integer) = Nothing

            Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Refreshing)

            If ButtonItemActions_ShowMissingTrafficInstructions.Checked Then

                WorksheetIDs = DataGridViewLeftSection_MediaBroadcastWorksheets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet).Select(Function(WS) WS.ID).ToArray

                _Controller.Setup_SetWorksheetIDsWithMissingTrafficInstructions(WorksheetIDs, _ViewModel)

            Else

                _Controller.Setup_ClearWorksheetIDsWithMissingTrafficInstructions(_ViewModel)

            End If

            DataGridViewLeftSection_MediaBroadcastWorksheets.Refresh()

            DataGridViewRightSection_Markets.Refresh()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        End Sub
        Private Sub ButtonItemActions_FilterPendingMakegoods_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_FilterPendingMakegoods.CheckedChanged

            Dim MediaBroadcastWorksheetID As Integer = 0

            If _ViewModel.SelectedWorksheet IsNot Nothing Then

                MediaBroadcastWorksheetID = _ViewModel.SelectedWorksheet.ID

            End If

            _Controller.Setup_SetPendingMakegoodsFlag(_ViewModel, ButtonItemActions_FilterPendingMakegoods.Checked, DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.AFActiveFilterString)

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadGrid()

            If DataGridViewLeftSection_MediaBroadcastWorksheets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.PendingMakegood.ToString) IsNot Nothing Then

                DataGridViewLeftSection_MediaBroadcastWorksheets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.PendingMakegood.ToString).OptionsColumn.AllowShowHide = False
                DataGridViewLeftSection_MediaBroadcastWorksheets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.PendingMakegood.ToString).Visible = _ViewModel.ShowPendingMakegoods

                If _ViewModel.ShowPendingMakegoods Then

                    DataGridViewLeftSection_MediaBroadcastWorksheets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.PendingMakegood.ToString).VisibleIndex = 0
                    DataGridViewLeftSection_MediaBroadcastWorksheets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.PendingMakegood.ToString).BestFit()

                End If

            End If

            If _ViewModel.ShowPendingMakegoods Then

                DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.AFActiveFilterString = "[PendingMakegood] = True"
                DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsCustomization.AllowFilter = False
                DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsFilter.AllowFilterEditor = False
                DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsFilter.AllowMRUFilterList = False
                DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never

            Else

                DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.AFActiveFilterString = _ViewModel.FilterBeforeShowingPendingMakegoods
                DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsCustomization.AllowFilter = True
                DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsFilter.AllowFilterEditor = True
                DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsFilter.AllowMRUFilterList = True
                DataGridViewLeftSection_MediaBroadcastWorksheets.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default

            End If

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            If MediaBroadcastWorksheetID <> 0 Then

                DataGridViewLeftSection_MediaBroadcastWorksheets.SelectRow(0, MediaBroadcastWorksheetID)

            End If

            DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

            LoadWorksheetMarketsGrid()

            RefreshViewModel(False, True)

        End Sub
        Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

            'objects
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                DashboardViewerDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                DashboardLayout = MemoryStream.ToArray
                MemoryStream.Flush()
                MemoryStream.Close()

                If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, _ViewModel.DashboardDataSource, DashboardLayout, False) = Windows.Forms.DialogResult.OK Then

                    _Controller.Setup_SaveDashboard(_ViewModel, DashboardLayout)

                    LoadDashboard()

                End If

                LoadDashboardDataSource()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_MediaBroadcastWorksheets_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewLeftSection_MediaBroadcastWorksheets.PopupMenuShowingEvent

            If e.Menu IsNot Nothing AndAlso e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAutoFilterRowShow

                            MenuItem.Visible = False

                            Exit For

                    End Select

                Next

            End If

        End Sub
        Private Sub DataGridViewLeftSection_MediaBroadcastWorksheets_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewLeftSection_MediaBroadcastWorksheets.CustomDrawCellEvent

            Dim Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.Name.ToString Then

                Worksheet = DirectCast(DataGridViewLeftSection_MediaBroadcastWorksheets.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet)

                If _ViewModel.WorksheetIDsWithMissingTrafficInstructions IsNot Nothing AndAlso _ViewModel.WorksheetIDsWithMissingTrafficInstructions.Contains(Worksheet.ID) Then

                    e.Appearance.ForeColor = System.Drawing.Color.Red

                Else

                    e.Appearance.ForeColor = System.Drawing.Color.Black

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_MediaBroadcastWorksheets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_MediaBroadcastWorksheets.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
                    DataGridViewLeftSection_MediaBroadcastWorksheets.CurrentView.OptionsView.ShowIndicator Then

                _Controller.Setup_SelectedWorksheetChanged(_ViewModel, DataGridViewLeftSection_MediaBroadcastWorksheets.GetFirstSelectedRowDataBoundItem())

                LoadWorksheetMarketsGrid()

                DataGridViewRightSection_Markets.GridViewSelectionChanged()

                LoadDashboardDataSource()

                RefreshViewModel(False, True)

            End If

        End Sub
        Private Sub RepositoryItemIsInactive_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            'objects
            Dim Message As String = String.Empty

            If e.NewValue = True Then

                If _Controller.IsAnyMarketLockedByWorksheet(_ViewModel.SelectedWorksheet.ID, Message) Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                    e.Cancel = True

                Else

                    Try

                        If _Controller.Setup_SelectedWorksheetIsInactiveChanged(_ViewModel, _ViewModel.SelectedWorksheet, e.NewValue) Then

                            RefreshViewModel(True, True)

                            DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

                        Else

                            e.Cancel = True

                        End If

                    Catch ex As Exception
                        e.Cancel = True
                    End Try

                End If

            Else

                Try

                    If _Controller.Setup_SelectedWorksheetIsInactiveChanged(_ViewModel, _ViewModel.SelectedWorksheet, e.NewValue) Then

                        RefreshViewModel(True, True)

                        DataGridViewLeftSection_MediaBroadcastWorksheets.GridViewSelectionChanged()

                    Else

                        e.Cancel = True

                    End If

                Catch ex As Exception
                    e.Cancel = True
                End Try

            End If

        End Sub
        Private Sub ButtonItemMarkets_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_Manage.Click

            'objects
            Dim Message As String = Nothing
            'Dim MediaBroadcastWorksheetMarketDetailForm As MediaBroadcastWorksheetMarketDetailForm = Nothing

            If _Controller.IsAnyMarketLockedByWorksheet(_ViewModel.SelectedWorksheet.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                'If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                '    MediaBroadcastWorksheetMarketDetailForm = GetOpenWorksheetForm(Me.MdiParent, _ViewModel.SelectedWorksheet.ID, _ViewModel.SelectedWorksheetMarket.ID)

                'End If

                'If MediaBroadcastWorksheetMarketDetailForm Is Nothing Then

                If MediaBroadcastWorksheetMarketEditDialog.ShowFormDialog(_ViewModel.SelectedWorksheet.ID) = Windows.Forms.DialogResult.OK Then

                    LoadWorksheetMarketsGrid()

                    RefreshViewModel(False, True)

                End If

                'Else

                '    MediaBroadcastWorksheetMarketDetailForm.Activate()

                '    MediaBroadcastWorksheetMarketDetailForm.OpenManageMarkets()

                'End If

            End If

        End Sub
        Private Sub ButtonItemMarkets_Goals_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_Goals.Click

            'objects
            'Dim Message As String = Nothing
            'Dim MediaBroadcastWorksheetMarketDetailForm As MediaBroadcastWorksheetMarketDetailForm = Nothing

            'If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

            '    MediaBroadcastWorksheetMarketDetailForm = GetOpenWorksheetForm(Me.MdiParent, _ViewModel.SelectedWorksheet.ID, _ViewModel.SelectedWorksheetMarket.ID)

            'End If

            'If MediaBroadcastWorksheetMarketDetailForm Is Nothing Then

            If MediaBroadcastWorksheetMarketGoalDialog.ShowFormDialog(_ViewModel.SelectedWorksheet.ID, _ViewModel.SelectedWorksheetMarket.ID) = System.Windows.Forms.DialogResult.OK Then

                _Controller.Setup_SelectedWorksheetChanged(_ViewModel, DataGridViewLeftSection_MediaBroadcastWorksheets.GetFirstSelectedRowDataBoundItem())

                LoadWorksheetMarketsGrid()

                LoadDashboardDataSource()

                RefreshViewModel(False, True)

            End If

            'Else

            '    MediaBroadcastWorksheetMarketDetailForm.Activate()

            '    MediaBroadcastWorksheetMarketDetailForm.OpenGoals()

            'End If

        End Sub
        Private Sub ButtonItemMarkets_ViewOrderDetails_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_ViewOrderDetails.Click

            Media.Presentation.MediaBroadcastWorksheetOrderDataDialog.ShowFormDialog(_ViewModel.SelectedWorksheet.ID, _ViewModel.SelectedWorksheetMarket.ID, -1)

        End Sub
        Private Sub DataGridViewRightSection_Markets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewRightSection_Markets.FocusedRowChangedEvent

            _Controller.Setup_SelectedWorksheetMarketChanged(_ViewModel, DataGridViewRightSection_Markets.GetFirstSelectedRowDataBoundItem())

            RefreshViewModel(False, False)

        End Sub
        Private Sub DataGridViewRightSection_Markets_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewRightSection_Markets.RowDoubleClickEvent

            If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                ViewWorksheet(_ViewModel.SelectedWorksheet.ID, _ViewModel.SelectedWorksheetMarket.ID)

            End If

        End Sub
        Private Sub DataGridViewLeftSection_MediaBroadcastWorksheets_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewLeftSection_MediaBroadcastWorksheets.RowDoubleClickEvent

            If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                ViewWorksheet(_ViewModel.SelectedWorksheet.ID, _ViewModel.SelectedWorksheetMarket.ID)

            End If

        End Sub
        Private Sub DataGridViewRightSection_Markets_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewRightSection_Markets.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID1.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID2.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID3.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID4.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.NeilsenRadioPeriodID5.ToString Then

                Datasource = _ViewModel.NielsenRadioPeriods

            End If

        End Sub
        Private Sub DataGridViewRightSection_Markets_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewRightSection_Markets.CustomDrawCellEvent

            Dim WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketDescription.ToString Then

                WorksheetMarket = DirectCast(DataGridViewRightSection_Markets.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)

                If _ViewModel.WorksheetMarketIDsWithMissingTrafficInstructions IsNot Nothing AndAlso _ViewModel.WorksheetMarketIDsWithMissingTrafficInstructions.Contains(WorksheetMarket.ID) Then

                    e.Appearance.ForeColor = System.Drawing.Color.Red

                Else

                    e.Appearance.ForeColor = System.Drawing.Color.Black

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_Markets_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewRightSection_Markets.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing
            Dim ImageCollection As DevExpress.Utils.ImageCollection = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString Then

                RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

                ImageCollection = New DevExpress.Utils.ImageCollection

                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallRedCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueSemiCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallPinkCircleImage)

                RepositoryItemImageComboBox.SmallImages = ImageCollection

                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered, 0))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial, 1))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered, 2))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified.ToString, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified, 3))

                RepositoryItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

                e.RepositoryItem = RepositoryItemImageComboBox

            End If

        End Sub
        Private Sub ButtonItemPrint_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_Print.Click

            'objects
            Dim SaveFileDialog As System.Windows.Forms.SaveFileDialog
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DefaultFileName As String = ""
            Dim KeepLoading As Boolean = True
            Dim IsAsp As Boolean = False

            If _ViewModel IsNot Nothing AndAlso _ViewModel.SelectedWorksheet IsNot Nothing AndAlso
                    _ViewModel.SelectedWorksheetMarkets IsNot Nothing AndAlso _ViewModel.SelectedWorksheetMarkets.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedWorksheet.Name) & ".xls"
                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.IsASP = 1 Then

                            IsAsp = True

                            If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

                            DefaultFileName = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") & DefaultFileName

                        Else

                            SaveFileDialog = New Windows.Forms.SaveFileDialog
                            SaveFileDialog.Filter = "XLS files (.xls)|*.xls"
                            SaveFileDialog.FileName = DefaultFileName

                            If SaveFileDialog.ShowDialog() <> Windows.Forms.DialogResult.OK Then

                                KeepLoading = False

                            End If

                            DefaultFileName = SaveFileDialog.FileName

                        End If

                    End If

                    If KeepLoading Then

                        Me.ShowWaitForm("Please Wait...")

                        Try

                            If _Controller.Report_Generate(Me.Session, DefaultFileName, _ViewModel.SelectedWorksheet, _ViewModel.SelectedWorksheetMarkets, _ViewModel.WorksheetPrintOptions) Then

                                If IsAsp Then

                                    If AdvantageFramework.WinForm.Presentation.SendASPReportDownloadEmail(Me.Session, DefaultFileName) Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Broadcast Worksheet Report has been exported and also email link has been sent to your email.")

                                    Else

                                        AdvantageFramework.Navigation.ShowMessageBox("The Broadcast Worksheet Report has been placed on the FTP in the Reports folder.")

                                    End If

                                ElseIf AdvantageFramework.Navigation.ShowMessageBox("Broadcast Worksheet Report saved! Would you like to open?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                    Try

                                        Process.Start(DefaultFileName)

                                    Catch ex As Exception

                                    End Try

                                End If

                            Else

                                AdvantageFramework.Navigation.ShowMessageBox("There was a problem creating the report. Please contact software support.")

                            End If


                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemPrint_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_Settings.Click

            'objects
            Dim WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions = Nothing

            WorksheetPrintOptions = _ViewModel.WorksheetPrintOptions

            If AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetPrintingOptionsDialog.ShowFormDialog(WorksheetPrintOptions) = System.Windows.Forms.DialogResult.OK Then

                _ViewModel.WorksheetPrintOptions = WorksheetPrintOptions

                _Controller.SaveWorksheetPrintOptions(_ViewModel.WorksheetPrintOptions)

                UpdateWorksheetDetailFormsWorksheetPrintOptions()

            End If

        End Sub

        Private Sub ButtonItemPostBuy_DaypartSummary_Click(sender As Object, e As EventArgs) Handles ButtonItemPostBuy_DaypartSummary.Click

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyDaypartSummaryReport))

            ElseIf _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport))

            End If

        End Sub
        Private Sub ButtonItemPostBuy_Detail_Click(sender As Object, e As EventArgs) Handles ButtonItemPostBuy_Detail.Click

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport))

            ElseIf _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyReport))

            End If

        End Sub
        Private Sub ButtonItemPostBuy_StationDaypartSummary_Click(sender As Object, e As EventArgs) Handles ButtonItemPostBuy_StationDaypartSummary.Click

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationDaypartSummaryReport))

            ElseIf _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport))

            End If

        End Sub
        Private Sub ButtonItemPostBuy_StationSummary_Click(sender As Object, e As EventArgs) Handles ButtonItemPostBuy_StationSummary.Click

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationSummaryReport))

            ElseIf _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationSummaryReport))

            End If

        End Sub
        Private Sub ButtonItemPreBuy_DaypartSummary_Click(sender As Object, e As EventArgs) Handles ButtonItemPreBuy_DaypartSummary.Click

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyDaypartSummaryReport))

            ElseIf _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport))

            End If

        End Sub
        Private Sub ButtonItemPreBuy_Detail_Click(sender As Object, e As EventArgs) Handles ButtonItemPreBuy_Detail.Click

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyReport))

            ElseIf _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyReport))

            End If

        End Sub
        Private Sub ButtonItemPreBuy_StationDaypartSummary_Click(sender As Object, e As EventArgs) Handles ButtonItemPreBuy_StationDaypartSummary.Click

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationDaypartSummaryReport))

            ElseIf _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport))

            End If

        End Sub
        Private Sub ButtonItemPreBuy_StationSummary_Click(sender As Object, e As EventArgs) Handles ButtonItemPreBuy_StationSummary.Click

            If _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationSummaryReport))

            ElseIf _ViewModel.SelectedWorksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio Then

                CreateReport(GetType(AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationSummaryReport))

            End If

        End Sub
        Private Sub ToolTipController_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim CellText As String = String.Empty

            If e.Info Is Nothing AndAlso e.SelectedControl Is DataGridViewRightSection_Markets.GridControl Then

                GridHitInfo = DataGridViewRightSection_Markets.CurrentView.CalcHitInfo(e.ControlMousePosition)

                If GridHitInfo IsNot Nothing AndAlso GridHitInfo.InRowCell Then

                    If GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MaxRevisionOrderStatus.ToString Then

                        CellText = DataGridViewRightSection_Markets.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column)

                        If String.IsNullOrWhiteSpace(CellText) = False Then

                            If CInt(CellText) = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial Then

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), "Partially Ordered")

                            Else

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses), CInt(CellText)))

                            End If

                            e.Info = ToolTipControlInfo

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemReports_BroadcastSchedule_Click(sender As Object, e As EventArgs) Handles ButtonItemReports_BroadcastSchedule.Click

            CreateBroadcastScheduleCriteria(_ViewModel.SelectedWorksheet, _ViewModel.SelectedWorksheetMarkets)

        End Sub
        Private Sub ButtonItemReports_Other_Click(sender As Object, e As EventArgs) Handles ButtonItemReports_Other.Click

            AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetOtherInitialLoadingDialog.ShowFormDialog(_ViewModel.SelectedWorksheet.ID)

        End Sub
        Private Sub ButtonItemActions_ReplaceBuyer_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ReplaceBuyer.Click

            Dim FindBuyerEmployeeCode As String = Nothing

            If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                FindBuyerEmployeeCode = _ViewModel.SelectedWorksheetMarket.BuyerEmployeeCode

            End If

            If AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketReplaceBuyerDialog.ShowFormDialog(FindBuyerEmployeeCode) = Windows.Forms.DialogResult.OK Then

                ButtonItemActions_Refresh.RaiseClick()

            End If

        End Sub
        Private Sub ButtonItemPuertoRicoExport_eTamActualRF_Click(sender As Object, e As EventArgs) Handles ButtonItemPuertoRicoExport_eTamActualRF.Click

            AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetETAMExportDialog.ShowFormDialog(_ViewModel.SelectedWorksheet.ID)

        End Sub
        Private Sub ButtonItemPuertoRicoExport_AriannaEstimateRF_Click(sender As Object, e As EventArgs) Handles ButtonItemPuertoRicoExport_AriannaEstimateRF.Click

            Dim FolderName As String = Nothing
            Dim OutputFilename As String = Nothing

            FolderName = _Controller.AriannaExport_GexExportFolder()

            If AdvantageFramework.WinForm.Presentation.BrowseForFolder(FolderName, FolderName) Then

                If _Controller.AriannaExport_Export(_ViewModel.SelectedWorksheetMarket.ID, FolderName, OutputFilename) Then

                    AdvantageFramework.WinForm.MessageBox.Show("File exported to: " & OutputFilename)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("File failed to export.")

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
