Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum GridBandNames
            GridBandData
            GridBandPrimarySubmarketDemo
            GridBandSecondarySubmarketDemo
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _DetailsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailForm = Nothing
        'Private _HideZeroSpotLines As Boolean = False
        'Private _HandleGroupRowExpandCollapse As Boolean = True
        'Private _DisableHandlingSelectedRows As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByRef DetailsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailForm,
                       ByRef Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController,
                       ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _DetailsForm = DetailsForm
            _Controller = Controller
            _ViewModel = ViewModel

        End Sub
        Private Sub LoadGrid()

            BandedDataGridViewForm_MarketDetails.DataSource = _ViewModel.DataTable

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Add()

            GridBand.Name = GridBandNames.GridBandData.ToString
            GridBand.Caption = ""
            GridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            'GridBand.OptionsBand.AllowMove = False
            'GridBand.OptionsBand.AllowPress = False
            GridBand.OptionsBand.ShowInCustomizationForm = False

            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodDate.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodSpots.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsComboRadioStation.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookProgram.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString))

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                GridBand.Columns.Add(GridColumn)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString)

                GridBand.Columns.Add(GridColumn)

            Next

            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryShare.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryUniverse.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQHRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQH.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedShare.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryShare.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryUniverse.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQHRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQH.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedShare.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString))

            For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString Then

                    If _DetailsForm.BandedDataGridViewForm_MarketDetails.CurrentView.GroupCount > 0 Then

                        GridColumn.Group()

                    End If

                    ModifyColumn(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString Then

                    GridColumn.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                    GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                    ModifyColumn(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString Then

                    GridColumn.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value

                    ModifyColumn(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString Then

                    GridColumn.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                    GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                    ModifyColumn(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString Then

                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridColumn.DisplayFormat.FormatString = "0000"

                    ModifyColumn(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString Then

                    ModifyColumn(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString Then

                    GridColumn.Caption = "Total Cost"
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridColumn.DisplayFormat.FormatString = "c2"

                    ModifyColumn(GridColumn)

                Else

                    HideAndModifyColumn(GridColumn)

                End If

            Next

            For Each BandedGridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ToList

                If BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString Then

                    BandedGridColumn.ColVIndex = 0

                ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString Then

                    BandedGridColumn.ColVIndex = 1

                ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString Then

                    BandedGridColumn.ColVIndex = 2

                ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString Then

                    BandedGridColumn.ColVIndex = 3

                ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString Then

                    BandedGridColumn.ColVIndex = 4

                ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString Then

                    BandedGridColumn.ColVIndex = 5

                End If

            Next

            GridBand.Visible = True

            FormatGridSubmarketBands()

            BandedDataGridViewForm_MarketDetails.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
            BandedDataGridViewForm_MarketDetails.OptionsFilter.AllowFilterEditor = False
            BandedDataGridViewForm_MarketDetails.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        End Sub
        Private Sub FormatGridSubmarketBands()

            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing
            Dim WorksheetMarketSubmarketDemo As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarketDemo = Nothing
            Dim ColVIndex As Integer = 0

            ClearSubmarketBandsAndColumns()

            If _ViewModel.DoesWorksheetAllowSubmarkets Then

                GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString)

                If GridBand Is Nothing Then

                    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Insert(GridBandNames.GridBandPrimarySubmarketDemo)

                    GridBand.Name = GridBandNames.GridBandPrimarySubmarketDemo.ToString

                End If

                GridBand.Caption = _ViewModel.Worksheet.PrimaryMediaDemographicDescription
                GridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
                GridBand.OptionsBand.ShowInCustomizationForm = False
                GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
                GridBand.Visible = True

                If _ViewModel.WorksheetMarketSubmarkets IsNot Nothing AndAlso
                        _ViewModel.WorksheetMarketSubmarkets.Count > 0 Then

                    For Each WorksheetMarketSubmarket In _ViewModel.WorksheetMarketSubmarkets.OrderBy(Function(Entity) Entity.Order).ToList

                        WorksheetMarketSubmarketDemo = Nothing

                        Try

                            WorksheetMarketSubmarketDemo = _ViewModel.WorksheetMarketSubmarketDemos.SingleOrDefault(Function(Entity) Entity.IsPrimaryDemo = True AndAlso
                                                                                                                                     Entity.MediaBroadcastWorksheetMarketSubmarketID = WorksheetMarketSubmarket.ID)

                        Catch ex As Exception
                            WorksheetMarketSubmarketDemo = Nothing
                        End Try

                        If WorksheetMarketSubmarketDemo IsNot Nothing Then

                            AddGridBandUnboundColumn(GridBand, WorksheetMarketSubmarketDemo.ColumnName, WorksheetMarketSubmarketDemo.MarketCode, WorksheetMarketSubmarketDemo.Market,
                                                     DevExpress.Data.UnboundColumnType.Decimal, DevExpress.Utils.FormatType.Numeric, "{0:n2}", True)

                        End If

                    Next

                    For Each WorksheetMarketSubmarket In _ViewModel.WorksheetMarketSubmarkets.OrderBy(Function(Entity) Entity.Order).ToList

                        WorksheetMarketSubmarketDemo = Nothing

                        Try

                            WorksheetMarketSubmarketDemo = _ViewModel.WorksheetMarketSubmarketDemos.SingleOrDefault(Function(Entity) Entity.IsPrimaryDemo = True AndAlso
                                                                                                                                     Entity.MediaBroadcastWorksheetMarketSubmarketID = WorksheetMarketSubmarket.ID)

                        Catch ex As Exception
                            WorksheetMarketSubmarketDemo = Nothing
                        End Try

                        If WorksheetMarketSubmarketDemo IsNot Nothing Then

                            If BandedDataGridViewForm_MarketDetails.Columns(WorksheetMarketSubmarketDemo.ColumnName) IsNot Nothing Then

                                BandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(WorksheetMarketSubmarketDemo.ColumnName)

                                BandedGridColumn.ColVIndex = WorksheetMarketSubmarket.Order

                            End If


                        End If

                    Next

                End If

                ''''
                'Secondary
                ''''
                GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

                If GridBand Is Nothing Then

                    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Add()

                    GridBand.Name = GridBandNames.GridBandSecondarySubmarketDemo.ToString

                End If

                If _ViewModel.SelectedWorksheetMarketSecondaryDemo IsNot Nothing Then

                    GridBand.Caption = _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicDescription

                Else

                    GridBand.Caption = String.Empty

                End If

                GridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
                GridBand.OptionsBand.ShowInCustomizationForm = False
                GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
                GridBand.Visible = True

                If _ViewModel.WorksheetSecondaryDemos IsNot Nothing AndAlso
                        _ViewModel.WorksheetSecondaryDemos.Count > 0 AndAlso
                        _ViewModel.WorksheetMarketSubmarkets IsNot Nothing AndAlso
                        _ViewModel.WorksheetMarketSubmarkets.Count > 0 Then

                    For Each WorksheetSecondaryDemo In _ViewModel.WorksheetSecondaryDemos

                        For Each WorksheetMarketSubmarket In _ViewModel.WorksheetMarketSubmarkets.OrderBy(Function(Entity) Entity.Order).ToList

                            WorksheetMarketSubmarketDemo = Nothing

                            Try

                                WorksheetMarketSubmarketDemo = _ViewModel.WorksheetMarketSubmarketDemos.SingleOrDefault(Function(Entity) Entity.IsPrimaryDemo = False AndAlso
                                                                                                                                         Entity.MediaBroadcastWorksheetMarketSubmarketID = WorksheetMarketSubmarket.ID AndAlso
                                                                                                                                         Entity.MediaDemographicID = WorksheetSecondaryDemo.MediaDemographicID)

                            Catch ex As Exception
                                WorksheetMarketSubmarketDemo = Nothing
                            End Try

                            If WorksheetMarketSubmarketDemo IsNot Nothing Then

                                AddGridBandUnboundColumn(GridBand, WorksheetMarketSubmarketDemo.ColumnName, WorksheetMarketSubmarketDemo.MarketCode, WorksheetMarketSubmarketDemo.Market,
                                                         DevExpress.Data.UnboundColumnType.Decimal, DevExpress.Utils.FormatType.Numeric, "{0:n2}", True)

                            End If

                        Next

                        For Each WorksheetMarketSubmarket In _ViewModel.WorksheetMarketSubmarkets.OrderBy(Function(Entity) Entity.Order).ToList

                            WorksheetMarketSubmarketDemo = Nothing

                            Try

                                WorksheetMarketSubmarketDemo = _ViewModel.WorksheetMarketSubmarketDemos.SingleOrDefault(Function(Entity) Entity.IsPrimaryDemo = False AndAlso
                                                                                                                                         Entity.MediaBroadcastWorksheetMarketSubmarketID = WorksheetMarketSubmarket.ID AndAlso
                                                                                                                                         Entity.MediaDemographicID = WorksheetSecondaryDemo.MediaDemographicID)

                            Catch ex As Exception
                                WorksheetMarketSubmarketDemo = Nothing
                            End Try

                            If WorksheetMarketSubmarketDemo IsNot Nothing Then

                                If BandedDataGridViewForm_MarketDetails.Columns(WorksheetMarketSubmarketDemo.ColumnName) IsNot Nothing Then

                                    BandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(WorksheetMarketSubmarketDemo.ColumnName)

                                    BandedGridColumn.ColVIndex = ColVIndex

                                    ColVIndex += 1

                                End If

                            End If

                        Next

                    Next

                End If

            End If

        End Sub
        Private Sub ClearSubmarketBandsAndColumns()

            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString)

            If GridBand IsNot Nothing Then

                For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridBand.Columns.Remove(GridColumn)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Contains(GridColumn) Then

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

                    End If

                Next

                If _ViewModel.WorksheetMarketSubmarketDemos IsNot Nothing AndAlso
                        _ViewModel.WorksheetMarketSubmarketDemos.Count > 0 Then

                    For Each WorksheetMarketSubmarketDemo In _ViewModel.WorksheetMarketSubmarketDemos.Where(Function(Entity) Entity.IsPrimaryDemo = True).ToList

                        If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(WorksheetMarketSubmarketDemo.ColumnName) IsNot Nothing Then

                            BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(WorksheetMarketSubmarketDemo.ColumnName))

                        End If

                    Next

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Remove(GridBand)

            End If

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

            If GridBand IsNot Nothing Then

                For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridBand.Columns.Remove(GridColumn)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Contains(GridColumn) Then

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

                    End If

                Next

                If _ViewModel.WorksheetMarketSubmarketDemos IsNot Nothing AndAlso
                        _ViewModel.WorksheetMarketSubmarketDemos.Count > 0 Then

                    For Each WorksheetMarketSubmarketDemo In _ViewModel.WorksheetMarketSubmarketDemos.Where(Function(Entity) Entity.IsPrimaryDemo = False).ToList

                        If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(WorksheetMarketSubmarketDemo.ColumnName) IsNot Nothing Then

                            BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(WorksheetMarketSubmarketDemo.ColumnName))

                        End If

                    Next

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Remove(GridBand)

            End If

            For Each GridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName.StartsWith("Submarket") OrElse GridColumn.FieldName.StartsWith("SM") OrElse
                        GridColumn.Name.StartsWith("Submarket") OrElse GridColumn.Name.StartsWith("SM") Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

                End If

            Next

        End Sub
        Private Sub HideAndModifyColumn(GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(GridColumn.FieldName)
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.AllowShowHide = False
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.AllowEdit = False

        End Sub
        Private Sub ModifyColumn(GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(GridColumn.FieldName)
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.AllowShowHide = False
            BandedDataGridViewForm_MarketDetails.Columns(GridColumn.FieldName).OptionsColumn.AllowEdit = False

        End Sub
        Private Sub SetControlPropertySettings()

            BandedDataGridViewForm_MarketDetails.CurrentView.ModifyGridRowHeight = True

            BandedDataGridViewForm_MarketDetails.SetupForEditableGrid()

            BandedDataGridViewForm_MarketDetails.CurrentView.GroupRowHeight = 20
            BandedDataGridViewForm_MarketDetails.CurrentView.FooterPanelHeight = 20
            BandedDataGridViewForm_MarketDetails.CurrentView.ColumnPanelRowHeight = 20

            BandedDataGridViewForm_MarketDetails.OptionsBehavior.AutoSelectAllInEditor = True
            BandedDataGridViewForm_MarketDetails.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
            BandedDataGridViewForm_MarketDetails.OptionsNavigation.AutoMoveRowFocus = True
            BandedDataGridViewForm_MarketDetails.OptionsNavigation.EnterMoveNextColumn = True
            BandedDataGridViewForm_MarketDetails.OptionsNavigation.UseOfficePageNavigation = True
            BandedDataGridViewForm_MarketDetails.OptionsNavigation.UseTabKey = True
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowSort = False
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowRowSizing = False
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowQuickHideColumns = False
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowGroup = False
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowFilter = False
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowColumnResizing = True
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowColumnMoving = False

            BandedDataGridViewForm_MarketDetails.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
            BandedDataGridViewForm_MarketDetails.OptionsView.ShowGroupPanel = True
            BandedDataGridViewForm_MarketDetails.OptionsView.ShowFooter = True
            BandedDataGridViewForm_MarketDetails.OptionsView.BestFitMaxRowCount = -1
            BandedDataGridViewForm_MarketDetails.OptionsView.ShowGroupedColumns = False

            BandedDataGridViewForm_MarketDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            BandedDataGridViewForm_MarketDetails.OptionsSelection.MultiSelect = True
            BandedDataGridViewForm_MarketDetails.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect

            BandedDataGridViewForm_MarketDetails.ItemDescription = "Schedule Detail(s)"

            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowChangeColumnParent = False
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.ShowBandsInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowBandMoving = True
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowChangeBandParent = False

            BandedDataGridViewForm_MarketDetails.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default
            BandedDataGridViewForm_MarketDetails.OptionsFilter.AllowFilterEditor = False

            BandedDataGridViewForm_MarketDetails.GridControl.ToolTipController = Me.ToolTipController

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub AddGridBandUnboundColumn(GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand, UnboundColumnName As String,
                                             Caption As String, ToolTip As String, UnboundColumnType As DevExpress.Data.UnboundColumnType,
                                             FormatType As DevExpress.Utils.FormatType, FormatString As String, Visible As Boolean)

            'objects
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing

            If GridBand.Columns(UnboundColumnName) Is Nothing Then

                'Debug.WriteLine(UnboundColumnName)

                BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                GridBand.Columns.Add(BandedGridColumn)

                'BandedGridColumn.Name = UnboundColumnName
                BandedGridColumn.FieldName = UnboundColumnName
                BandedGridColumn.UnboundType = UnboundColumnType
                BandedGridColumn.Caption = Caption
                BandedGridColumn.Visible = Visible
                BandedGridColumn.ToolTip = ToolTip

                BandedGridColumn.OptionsColumn.AllowMove = False
                BandedGridColumn.OptionsColumn.ShowInCustomizationForm = False
                BandedGridColumn.OptionsColumn.ShowInExpressionEditor = False
                BandedGridColumn.OptionsColumn.AllowShowHide = False
                BandedGridColumn.ShowUnboundExpressionMenu = False

                BandedGridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                BandedGridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)
                BandedGridColumn.AppearanceHeader.FontStyleDelta = Drawing.FontStyle.Bold
                BandedGridColumn.AppearanceHeader.Options.UseFont = True

                BandedGridColumn.DisplayFormat.FormatType = FormatType
                BandedGridColumn.DisplayFormat.FormatString = FormatString

                AddGroupSummaryItemToColumn(BandedGridColumn, "{0:n2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedGridColumn, "{0:n2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                'BandedDataGridViewForm_MarketDetails.Columns.Add(BandedGridColumn)

                'If BandedGridColumn.Visible Then

                '    BandedGridColumn.VisibleIndex = GridBand.Columns.Count - 1
                '    BandedGridColumn.ColVIndex = GridBand.Columns.Count - 1

                'End If

            End If

        End Sub
        'Private Sub RemoveColumn(FieldName As String, GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand)

        '    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(FieldName) IsNot Nothing Then

        '        If GridBand IsNot Nothing Then

        '            If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(FieldName)) Then

        '                GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(FieldName))

        '            End If

        '        End If

        '        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(FieldName))

        '    End If

        'End Sub
        Private Sub AddGroupSummaryItemToColumn(GridColumn As DevExpress.XtraGrid.Columns.GridColumn, DisplayFormat As String,
                                                SummaryType As DevExpress.Data.SummaryItemType)

            'objects
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

            GridGroupSummaryItem.FieldName = GridColumn.FieldName
            GridGroupSummaryItem.SummaryType = SummaryType
            GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn
            GridGroupSummaryItem.DisplayFormat = DisplayFormat

            BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

        End Sub
        Private Sub AddSummaryItemToColumn(GridColumn As DevExpress.XtraGrid.Columns.GridColumn, DisplayFormat As String,
                                           SummaryType As DevExpress.Data.SummaryItemType, Tag As Object)

            'objects
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(SummaryType)

            GridColumnSummaryItem.FieldName = GridColumn.FieldName
            GridColumnSummaryItem.DisplayFormat = DisplayFormat
            GridColumnSummaryItem.Tag = Tag

            GridColumn.Summary.Add(GridColumnSummaryItem)

        End Sub
        Private Sub ChangeDisplayFormatForAllSummaryItems(DisplayFormat As String)

            For Each GridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.Summary IsNot Nothing AndAlso GridColumn.Summary.Count > 0 Then

                    For Each GridColumnSummaryItem In GridColumn.Summary.OfType(Of DevExpress.XtraGrid.GridColumnSummaryItem).ToList

                        GridColumnSummaryItem.DisplayFormat = DisplayFormat

                    Next

                End If

            Next

            For Each GridGroupSummaryItem In BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem).ToList

                GridGroupSummaryItem.DisplayFormat = DisplayFormat

            Next

        End Sub
        Private Sub Submarkets_SetupSecondaryColumns(MediaDemographicID As Integer)

            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

            If MediaDemographicID > 0 Then

                For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).OrderBy(Function(Entity) Entity.FieldName).ToList

                    If GridColumn.FieldName.EndsWith("_" & MediaDemographicID) Then

                        GridColumn.Visible = True

                    Else

                        GridColumn.Visible = False

                    End If

                Next

            Else

                For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.Visible = False

                Next

            End If

        End Sub
        Private Function CalcTextPosition(GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs, GroupText As String) As System.Drawing.Point

            Dim Point As System.Drawing.Point = Nothing
            Dim Height As Integer = Convert.ToInt32(e.Graphics.MeasureString(GroupText, e.Appearance.Font).Height)

            Point.X = GridGroupRowInfo.DataBounds.X + AdvantageFramework.My.Resources.InformationImage.Width + 5
            Point.Y = e.Bounds.Location.Y + (e.Bounds.Height - Height) / 2

            CalcTextPosition = Point

        End Function
        Private Function CalcImagePosition(e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs, Text As String, ImageX As Integer, Image As System.Drawing.Image) As System.Drawing.Point

            Dim Point As System.Drawing.Point = Nothing
            Dim Width As Integer = Convert.ToInt32(e.Graphics.MeasureString(Text, e.Appearance.Font).Width)

            Point.X = ImageX + Width + 5
            Point.Y = e.Bounds.Location.Y + (e.Bounds.Height - Image.Height) / 2

            CalcImagePosition = Point

        End Function
        Private Sub RefreshMediaBroadcastWorksheetMarketDetailForm()

            _DetailsForm.SubmarketsFormHiding()

        End Sub
        Private Sub SubmarketDemosChanged()

            _DetailsForm.SubmarketDemosChanged()

        End Sub
        Private Sub SelectRowsOnMediaBroadcastWorksheetMarketDetailForm()

            _DetailsForm.SelectedRowChanged(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows)

        End Sub
        Public Sub FormatSubmarketBands()

            Me.ShowOverlay()

            Try

                FormatGridSubmarketBands()

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub RefreshData()

            Me.ShowOverlay()

            Try

                BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub ReloadGrid()

            Me.ShowOverlay()

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub ShowHidePrimaryDemo(IsVisible As Boolean)

            Me.ShowOverlay()

            Try

                If IsVisible Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString).Visible = True
                    BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString).VisibleIndex = 0

                Else

                    BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString).Visible = False

                End If

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub ShowHideSecondaryDemo(IsVisible As Boolean)

            Me.ShowOverlay()

            Try

                If IsVisible Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString).Visible = True
                    BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString).VisibleIndex = 1

                Else

                    BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString).Visible = False

                End If

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub SetupSecondaryColumns(MediaDemographicID As Integer)

            Me.ShowOverlay()

            Try

                Submarkets_SetupSecondaryColumns(MediaDemographicID)

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub SetSecondaryDemoCaption(Caption As String)

            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            Me.ShowOverlay()

            Try

                GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

                If GridBand IsNot Nothing Then

                    GridBand.Caption = _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicDescription

                End If

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub ShowHideZeroSpotLines()

            Me.ShowOverlay()

            Try

                BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub CloseGridEditorAndSaveValueToDataSource()

            If BandedDataGridViewForm_MarketDetails.CurrentView.PostEditor() Then

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateCurrentRow()

            End If

        End Sub
        Public Sub UpdateSorting(SortInfo As DevExpress.XtraGrid.Columns.GridColumnSortInfoCollection)

            Me.ShowOverlay()

            Try

                BandedDataGridViewForm_MarketDetails.CurrentView.ClearSorting()

                For Each GridColumnSortInfo In SortInfo.OfType(Of DevExpress.XtraGrid.Columns.GridColumnSortInfo).ToList

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByFieldName(GridColumnSortInfo.Column.FieldName) IsNot Nothing Then

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns(GridColumnSortInfo.Column.FieldName).SortOrder = GridColumnSortInfo.SortOrder

                    End If

                Next

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub
        Public Sub CollapseGroupRow(RowHandle As Integer)

            Me.ShowOverlay()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            Try

                If RowHandle = Integer.MinValue Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.CollapseAllGroups()

                Else

                    BandedDataGridViewForm_MarketDetails.CurrentView.CollapseGroupRow(RowHandle)

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseOverlay()

        End Sub
        Public Sub ExpandGroupRow(RowHandle As Integer)

            Me.ShowOverlay()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            Try

                If RowHandle = Integer.MinValue Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.ExpandAllGroups()

                Else

                    BandedDataGridViewForm_MarketDetails.CurrentView.ExpandGroupRow(RowHandle)

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseOverlay()

        End Sub
        Public Sub FilterChanged()

            Me.ShowOverlay()

            Try

                BandedDataGridViewForm_MarketDetails.CurrentView.ActiveFilterString = _ViewModel.FilterString

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            Try

                BandedDataGridViewForm_MarketDetails.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseOverlay()

        End Sub
        Public Sub SelectedRowChanged(SelectedRows() As Integer)

            Me.ShowOverlay()

            CloseGridEditorAndSaveValueToDataSource()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            BandedDataGridViewForm_MarketDetails.CurrentView.BeginSelection()

            Try

                BandedDataGridViewForm_MarketDetails.CurrentView.ClearSelection()

                If SelectedRows IsNot Nothing AndAlso SelectedRows.Count > 0 Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle = SelectedRows(0)

                    For Each RowHandle In SelectedRows

                        BandedDataGridViewForm_MarketDetails.CurrentView.SelectRow(RowHandle)

                    Next

                End If

            Catch ex As Exception

            End Try

            BandedDataGridViewForm_MarketDetails.CurrentView.EndSelection()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseOverlay()

        End Sub
        Public Sub ShowHideGroupBox(IsVisible As Boolean)

            Me.ShowOverlay()

            CloseGridEditorAndSaveValueToDataSource()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            Try

                BandedDataGridViewForm_MarketDetails.CurrentView.OptionsView.ShowGroupPanel = IsVisible

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseOverlay()

        End Sub
        Public Sub EnableDisableGrouping(Enabled As Boolean)

            Me.ShowOverlay()

            CloseGridEditorAndSaveValueToDataSource()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            Try

                If Enabled Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) IsNot Nothing Then

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).Group()

                    End If

                Else

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) IsNot Nothing Then

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).UnGroup()

                    End If

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseOverlay()

        End Sub
        Public Sub BeginDataUpdate()

            BandedDataGridViewForm_MarketDetails.CurrentView.BeginDataUpdate()

        End Sub
        Public Sub EndDataUpdate()

            BandedDataGridViewForm_MarketDetails.CurrentView.EndDataUpdate()

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = System.Windows.Forms.CloseReason.UserClosing Then

                e.Cancel = True

                Me.Hide()

                RefreshMediaBroadcastWorksheetMarketDetailForm()

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.MinimizeBox = False
            Me.MaximizeBox = True
            Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.CenterToScreen()

            SetControlPropertySettings()

            LoadGrid()

            FormatGrid()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            Try

                BandedDataGridViewForm_MarketDetails.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub BandedDataGridViewForm_MarketDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                SelectRowsOnMediaBroadcastWorksheetMarketDetailForm()

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedDataGridViewForm_MarketDetails.PopupMenuShowingEvent

            If e.Menu IsNot Nothing Then

                If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                    If e.Menu.Items IsNot Nothing AndAlso e.Menu.Items.Count > 0 Then

                        For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                            Select Case MenuItem.Tag

                                Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns

                                    MenuItem.Visible = True

                                Case Else

                                    MenuItem.Visible = False

                            End Select

                        Next

                        e.Menu.Visible = True

                    End If

                Else

                    If e.Menu.Items IsNot Nothing AndAlso e.Menu.Items.Count > 0 Then

                        For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                            MenuItem.Visible = False

                        Next

                    End If

                    e.Menu.Visible = False

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedDataGridViewForm_MarketDetails.RowCellStyleEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(e.RowHandle) Then

                If _ViewModel.SelectedSubmarketDemoDataType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Rating AndAlso
                        e.Column.FieldName.StartsWith("SM") Then

                    If _ViewModel.WorksheetMarketSubmarketDemos.Any(Function(Entity) Entity.ColumnName = e.Column.FieldName) Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                        If _Controller.MarketDetails_IsWorksheetMarketDetailSubmarketDemoDataOverridden(_ViewModel, e.Column.FieldName, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString), e.CellValue) Then

                            e.Appearance.ForeColor = System.Drawing.Color.Blue
                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Bold

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawRowFooterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawRowFooterEvent

            e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)
            e.Appearance.BackColor2 = System.Drawing.Color.White
            e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical

            e.Appearance.DrawBackground(e.Cache, e.Bounds)

            e.Handled = True

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawRowFooterCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawRowFooterCellEvent

            e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            If e.Column IsNot Nothing AndAlso e.Column.FieldName.StartsWith("SM") Then

                If _ViewModel.SelectedSubmarketDemoDataType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Percentage Then

                    e.Appearance.DrawString(e.Cache, FormatPercent(e.Info.Value, 0, TriState.True, TriState.False, TriState.True), e.Bounds, System.Drawing.Brushes.Black)

                ElseIf _ViewModel.SelectedSubmarketDemoDataType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Allocation Then

                    e.Appearance.DrawString(e.Cache, FormatCurrency(e.Info.Value, 2, TriState.True, TriState.False, TriState.True), e.Bounds, System.Drawing.Brushes.Black)

                Else

                    e.Appearance.DrawString(e.Cache, FormatNumber(e.Info.Value, 2, TriState.True, TriState.False, TriState.True), e.Bounds, System.Drawing.Brushes.Black)

                End If

            End If

            e.Handled = True

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomSummaryCalculateEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Recalculating AndAlso
                    Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Saving Then

                If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then

                    e.TotalValueReady = True

                End If

                If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then

                    If e.IsGroupSummary Then

                        GridGroupSummaryItem = CType(e.Item, DevExpress.XtraGrid.GridGroupSummaryItem)

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(e.GroupRowHandle, 0)), System.Data.DataRowView).Row

                        If GridGroupSummaryItem.FieldName.StartsWith("SM") Then

                            e.TotalValue = _Controller.MarketDetails_SubmarketCalculateTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString), GridGroupSummaryItem.FieldName)

                        End If

                    ElseIf e.IsTotalSummary Then

                        GridColumnSummaryItem = CType(e.Item, DevExpress.XtraGrid.GridColumnSummaryItem)

                        If GridColumnSummaryItem.FieldName.StartsWith("SM") Then

                            e.TotalValue = _Controller.MarketDetails_SubmarketCalculateTotal(_ViewModel, String.Empty, GridColumnSummaryItem.FieldName)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = Nothing

            If _ViewModel IsNot Nothing AndAlso _ViewModel.DoesWorksheetAllowSubmarkets AndAlso
                    e.Column.FieldName.StartsWith("SM") AndAlso _ViewModel.SelectedSubmarketDemoDataType <> AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Percentage Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "n2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "n2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "n2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "n2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 99.99
                RepositoryItemSpinEdit.MaxLength = 5
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawGroupRowEvent

            'objects
            Dim Image As System.Drawing.Image = Nothing
            Dim OrderStatus As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered
            Dim VendorStationInfo As String = String.Empty
            Dim VendorMakegoodStatus As String = Nothing
            Dim HasGeneratePending As Boolean = False
            Dim InformationImage As System.Drawing.Image = Nothing
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim TextPosition As System.Drawing.Point = Nothing
            Dim ImagePosition As System.Drawing.Point = Nothing
            Dim GroupText As String = Nothing
            Dim IsRed As Boolean = False

            If CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString Then

                GridGroupRowInfo = e.Info
                e.Appearance.FillRectangle(e.Cache, e.Bounds)

                OrderStatus = _Controller.MarketDetails_CheckOrderStatus(_ViewModel, CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).GroupValueText)

                VendorStationInfo = _Controller.MarketDetails_LoadVendorInfo(_ViewModel, CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).GroupValueText, VendorMakegoodStatus, HasGeneratePending, IsRed)

                If OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Methods.OrderStatuses.Unordered Then

                    VendorMakegoodStatus = VendorMakegoodStatus.Replace("[Pending]", "")

                End If

                If String.IsNullOrWhiteSpace(VendorMakegoodStatus) = False Then

                    'CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).GroupText = Space(5) & VendorStationInfo & Space(5) & VendorMakegoodStatus
                    GroupText = VendorStationInfo & Space(5) & VendorMakegoodStatus

                Else

                    'CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).GroupText = Space(5) & CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).GroupValueText
                    GroupText = VendorStationInfo

                End If

                'e.DefaultDraw()

                If OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered Then

                    Image = AdvantageFramework.My.Resources.SmallRedCircleImage

                ElseIf OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial Then

                    Image = AdvantageFramework.My.Resources.SmallBlueSemiCircleImage

                ElseIf OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered Then

                    Image = AdvantageFramework.My.Resources.SmallBlueCircleImage

                ElseIf OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified Then

                    Image = AdvantageFramework.My.Resources.SmallPinkCircleImage

                End If

                CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).Graphics.DrawImage(Image, New System.Drawing.Rectangle(CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).ButtonBounds.Right, CType(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).ButtonBounds.Y, 16, 16))

                TextPosition = CalcTextPosition(GridGroupRowInfo, e, GroupText)
                ImagePosition = CalcImagePosition(e, GroupText, TextPosition.X, Image)

                'e.Graphics.DrawImage(Image, CSng(GridGroupRowInfo.DataBounds.X + 2), CSng(GridGroupRowInfo.DataBounds.Y + (GridGroupRowInfo.DataBounds.Height - Image.Height) / 2))
                e.Graphics.DrawRectangle(e.Cache.GetPen(BandedDataGridViewForm_MarketDetails.CurrentView.Appearance.GroupRow.BackColor), e.Bounds)

                If IsRed Then

                    e.Graphics.DrawString(GroupText, e.Appearance.Font, e.Cache.GetSolidBrush(System.Drawing.Color.Red), TextPosition)

                Else

                    e.Graphics.DrawString(GroupText, e.Appearance.Font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), TextPosition)

                End If

                If HasGeneratePending Then

                    e.Graphics.DrawImage(AdvantageFramework.My.Resources.SmallInformationImage, New System.Drawing.Rectangle(ImagePosition.X, ImagePosition.Y, 16, 16))

                End If

                e.Handled = True

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomUnboundColumnDataEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomUnboundColumnDataEvent

            Dim DataRowView As System.Data.DataRowView = Nothing
            Dim RowID As Integer = 0

            If e.IsGetData Then

                If e.Column IsNot Nothing AndAlso e.Row IsNot Nothing Then

                    Try

                        DataRowView = e.Row

                    Catch ex As Exception
                        DataRowView = Nothing
                    End Try

                    If DataRowView IsNot Nothing Then

                        RowID = DataRowView(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)

                        e.Value = _Controller.MarketDetails_GetWorksheetMarketDetailSubmarketDemoData(_ViewModel, e.Column.FieldName, RowID)

                    End If

                End If

            ElseIf e.IsSetData Then

                Try

                    DataRowView = e.Row

                Catch ex As Exception
                    DataRowView = Nothing
                End Try

                If DataRowView IsNot Nothing Then

                    RowID = DataRowView(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)

                    _Controller.MarketDetails_SetWorksheetMarketDetailSubmarketDemoData(_ViewModel, e.Column.FieldName, RowID, e.Value)

                    SubmarketDemosChanged()

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomRowFilterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomRowFilterEvent

            Dim TotalSpots As Integer = 0

            If _ViewModel.HideZeroSpotLines Then

                TotalSpots = BandedDataGridViewForm_MarketDetails.CurrentView.GetListSourceRowCellValue(e.ListSourceRow, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString)

                If TotalSpots = 0 Then

                    e.Visible = False
                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomColumnSortEvent

            'objects
            Dim DateValue1 As Date = Date.MinValue
            Dim DateValue2 As Date = Date.MinValue
            Dim MinuteDifference As Integer = 0
            Dim DaysAndTime1 As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim DaysAndTime2 As AdvantageFramework.DTO.DaysAndTime = Nothing

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString Then

                If String.IsNullOrWhiteSpace(e.Value1) AndAlso String.IsNullOrWhiteSpace(e.Value2) Then

                    e.Result = 0

                ElseIf String.IsNullOrWhiteSpace(e.Value1) = False AndAlso String.IsNullOrWhiteSpace(e.Value2) Then

                    e.Result = -1

                ElseIf String.IsNullOrWhiteSpace(e.Value1) AndAlso String.IsNullOrWhiteSpace(e.Value2) = False Then

                    e.Result = 1

                Else

                    DateValue1 = CDate(Now.ToShortDateString & " " & e.Value1)
                    DateValue2 = CDate(Now.ToShortDateString & " " & e.Value2)

                    MinuteDifference = DateDiff(DateInterval.Minute, DateValue1, DateValue2)

                    If MinuteDifference = 0 Then

                        e.Result = 0

                    ElseIf MinuteDifference > 0 Then

                        e.Result = -1

                    ElseIf MinuteDifference < 0 Then

                        e.Result = 1

                    End If

                End If

                e.Handled = True

            ElseIf e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString Then

                DaysAndTime1 = CType(e.RowObject1, System.Data.DataRowView)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString)
                DaysAndTime2 = CType(e.RowObject2, System.Data.DataRowView)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString)

                e.Result = _Controller.MarketDetails_SortDays(_ViewModel, DaysAndTime1, DaysAndTime2)

                e.Handled = True

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_GroupRowCollapsingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedDataGridViewForm_MarketDetails.GroupRowCollapsingEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = False

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_GroupRowExpandingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedDataGridViewForm_MarketDetails.GroupRowExpandingEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = False

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles BandedDataGridViewForm_MarketDetails.ShowingEditorEvent

            'objects
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing

            If _ViewModel.VendorMakegoodAvailable Then

                e.Cancel = True

            Else

                If TypeOf BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn Is DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Then

                    BandedGridColumn = BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn

                    If BandedGridColumn.OwnerBand IsNot Nothing Then

                        If BandedGridColumn.OwnerBand.Name = GridBandNames.GridBandPrimarySubmarketDemo.ToString Then

                            If _ViewModel.SelectedSubmarketDemoDataType <> AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Rating Then

                                e.Cancel = True

                            End If

                        ElseIf BandedGridColumn.OwnerBand.Name = GridBandNames.GridBandSecondarySubmarketDemo.ToString Then

                            If _ViewModel.SelectedSubmarketDemoDataType <> AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Rating Then

                                e.Cancel = True

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomColumnDisplayTextEvent

            'objects
            Dim RowHandle As Integer = 0

            If e.Column IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString Then

                    RowHandle = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowHandle(e.ListSourceRowIndex)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.IsValidRowHandle(RowHandle) AndAlso
                            _ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) > 0 Then

                        e.DisplayText = Format(_ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString), "0000") & "-" & Format(_ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString), "00")

                    End If

                Else

                    If e.Column.FieldName.StartsWith("SM") Then

                        If _ViewModel.SelectedSubmarketDemoDataType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Percentage Then

                            If IsNumeric(e.Value) AndAlso e.Value <> 0 Then

                                e.DisplayText = FormatPercent(e.Value, 0, TriState.True, TriState.False, TriState.True)

                            Else

                                e.DisplayText = FormatPercent(0, 0, TriState.True, TriState.False, TriState.True)

                            End If

                        ElseIf _ViewModel.SelectedSubmarketDemoDataType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Allocation Then

                            If IsNumeric(e.Value) AndAlso e.Value <> 0 Then

                                e.DisplayText = FormatCurrency(e.Value, 2, TriState.True, TriState.False, TriState.True)

                            Else

                                e.DisplayText = FormatCurrency(0, 2, TriState.True, TriState.False, TriState.True)

                            End If

                        Else

                            If IsNumeric(e.Value) AndAlso e.Value <> 0 Then

                                e.DisplayText = FormatNumber(e.Value, 2, TriState.True, TriState.False, TriState.True)

                            Else

                                e.DisplayText = FormatNumber(0, 2, TriState.True, TriState.False, TriState.True)

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonForm_Ratings_Click(sender As Object, e As EventArgs) Handles ButtonForm_Ratings.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonForm_Ratings.Checked = False Then

                    CloseGridEditorAndSaveValueToDataSource()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ButtonForm_Ratings.Checked = True
                    ButtonForm_GRP.Checked = False
                    ButtonForm_Imps.Checked = False
                    ButtonForm_GIMP.Checked = False
                    ButtonForm_Allocation.Checked = False
                    ButtonForm_Percentage.Checked = False

                    _Controller.MarketDetails_SelectedSubmarketDemoDataTypeChanged(_ViewModel, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Rating)

                    'Submarkets_Setup()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                    ChangeDisplayFormatForAllSummaryItems("{0:n2}")

                    BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                    BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    'If _SubmarketsForm IsNot Nothing Then

                    '    _SubmarketsForm.RefreshData()

                    'End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonForm_GRP_Click(sender As Object, e As EventArgs) Handles ButtonForm_GRP.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonForm_GRP.Checked = False Then

                    CloseGridEditorAndSaveValueToDataSource()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ButtonForm_Ratings.Checked = False
                    ButtonForm_GRP.Checked = True
                    ButtonForm_Imps.Checked = False
                    ButtonForm_GIMP.Checked = False
                    ButtonForm_Allocation.Checked = False
                    ButtonForm_Percentage.Checked = False

                    _Controller.MarketDetails_SelectedSubmarketDemoDataTypeChanged(_ViewModel, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.GRP)

                    'Submarkets_Setup()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                    ChangeDisplayFormatForAllSummaryItems("{0:n2}")

                    BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                    BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    'If _SubmarketsForm IsNot Nothing Then

                    '    _SubmarketsForm.RefreshData()

                    'End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Imps_Click(sender As Object, e As EventArgs) Handles ButtonForm_Imps.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonForm_Imps.Checked = False Then

                    CloseGridEditorAndSaveValueToDataSource()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ButtonForm_Ratings.Checked = False
                    ButtonForm_GRP.Checked = False
                    ButtonForm_Imps.Checked = True
                    ButtonForm_GIMP.Checked = False
                    ButtonForm_Allocation.Checked = False
                    ButtonForm_Percentage.Checked = False

                    _Controller.MarketDetails_SelectedSubmarketDemoDataTypeChanged(_ViewModel, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.IMP)

                    'Submarkets_Setup()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                    ChangeDisplayFormatForAllSummaryItems("{0:n2}")

                    BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                    BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    'If _SubmarketsForm IsNot Nothing Then

                    '    _SubmarketsForm.RefreshData()

                    'End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonForm_GIMP_Click(sender As Object, e As EventArgs) Handles ButtonForm_GIMP.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonForm_GIMP.Checked = False Then

                    CloseGridEditorAndSaveValueToDataSource()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ButtonForm_Ratings.Checked = False
                    ButtonForm_GRP.Checked = False
                    ButtonForm_Imps.Checked = False
                    ButtonForm_GIMP.Checked = True
                    ButtonForm_Allocation.Checked = False
                    ButtonForm_Percentage.Checked = False

                    _Controller.MarketDetails_SelectedSubmarketDemoDataTypeChanged(_ViewModel, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.GIMP)

                    'Submarkets_Setup()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                    ChangeDisplayFormatForAllSummaryItems("{0:n2}")

                    BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                    BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    'If _SubmarketsForm IsNot Nothing Then

                    '    _SubmarketsForm.RefreshData()

                    'End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Allocation_Click(sender As Object, e As EventArgs) Handles ButtonForm_Allocation.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonForm_Allocation.Checked = False Then

                    CloseGridEditorAndSaveValueToDataSource()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ButtonForm_Ratings.Checked = False
                    ButtonForm_GRP.Checked = False
                    ButtonForm_Imps.Checked = False
                    ButtonForm_GIMP.Checked = False
                    ButtonForm_Allocation.Checked = True
                    ButtonForm_Percentage.Checked = False

                    _Controller.MarketDetails_SelectedSubmarketDemoDataTypeChanged(_ViewModel, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Allocation)

                    'Submarkets_Setup()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                    ChangeDisplayFormatForAllSummaryItems("{0:c2}")

                    BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                    BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    'If _SubmarketsForm IsNot Nothing Then

                    '    _SubmarketsForm.RefreshData()

                    'End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Percentage_Click(sender As Object, e As EventArgs) Handles ButtonForm_Percentage.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonForm_Percentage.Checked = False Then

                    CloseGridEditorAndSaveValueToDataSource()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ButtonForm_Ratings.Checked = False
                    ButtonForm_GRP.Checked = False
                    ButtonForm_Imps.Checked = False
                    ButtonForm_GIMP.Checked = False
                    ButtonForm_Allocation.Checked = False
                    ButtonForm_Percentage.Checked = True

                    _Controller.MarketDetails_SelectedSubmarketDemoDataTypeChanged(_ViewModel, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Percentage)

                    'Submarkets_Setup()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                    ChangeDisplayFormatForAllSummaryItems("{0:p0}")

                    BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                    BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                    BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    'If _SubmarketsForm IsNot Nothing Then

                    '    _SubmarketsForm.RefreshData()

                    'End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Export_Click(sender As Object, e As EventArgs) Handles ButtonForm_Export.Click

            Me.TopMost = False

            BandedDataGridViewForm_MarketDetails.Print(DefaultLookAndFeel.LookAndFeel, "Submarket Demos", _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

            Me.TopMost = True

        End Sub

#End Region

#End Region

    End Class

End Namespace
