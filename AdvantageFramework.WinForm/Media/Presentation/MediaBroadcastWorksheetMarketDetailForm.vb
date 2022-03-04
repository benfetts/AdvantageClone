Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailForm

        Public Delegate Sub CacheBooksAsyncCaller(MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum GridBandNames
            GridBandData
            GridBandOtherData
            GridBandPrimaryDemo
            GridBandPrimarySubmarketDemo
            GridBandSecondaryDemo
            GridBandSecondarySubmarketDemo
        End Enum

        Public Enum UnboundColumnNames
            UnboundColumnPrimaryRating
            UnboundColumnPrimaryShare
            UnboundColumnPrimaryHPUT
            UnboundColumnPrimaryCPP
            UnboundColumnPrimaryGRP
            UnboundColumnPrimaryReach
            UnboundColumnPrimaryFrequency
            UnboundColumnPrimaryImpressions
            UnboundColumnPrimaryGrossImpressions
            UnboundColumnPrimaryUniverse
            UnboundColumnPrimaryCumeImpressions
            UnboundColumnPrimaryAQHRating
            UnboundColumnPrimaryAQH
            UnboundColumnPrimaryCumeRating
            UnboundColumnPrimaryCume
            UnboundColumnPrimaryCPM
            UnboundColumnPrimaryVendorSubmittedRating
            UnboundColumnPrimaryVendorSubmittedShare
            UnboundColumnPrimaryVendorSubmittedImpressions
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _TotalsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailTotalsDialog = Nothing
        Protected _MeasurementTrendsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog = Nothing
        Protected _SubmarketsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog = Nothing
        Protected _MediaBroadcastWorksheetID As Integer = 0
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0
        Protected _ColumnFilterStrings As Hashtable = Nothing
        Protected _ParsingImpressionsValue As Boolean = False
        Protected _HasShownSubmarketForm As Boolean = False
        'Private Delegate Sub SafeCallDelegate(enable As Boolean)
        Protected _PuertoRicoPeriodWarningShown As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property MediaBroadcastWorksheetID As Integer
            Get
                MediaBroadcastWorksheetID = _MediaBroadcastWorksheetID
            End Get
        End Property
        Public ReadOnly Property MediaBroadcastWorksheetMarketID As Integer
            Get
                MediaBroadcastWorksheetMarketID = _MediaBroadcastWorksheetMarketID
            End Get
        End Property
        Public ReadOnly Property TabText As String
            Get
                If _ViewModel IsNot Nothing AndAlso _ViewModel.SelectedWorksheetMarket IsNot Nothing Then
                    TabText = Replace("WS " & _MediaBroadcastWorksheetID & " - Mkt " & _MediaBroadcastWorksheetMarketID & " - " & _ViewModel.SelectedWorksheetMarket.MarketDescription, "&", "&&")
                Else
                    TabText = ""
                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

        End Sub
        'Private Sub EnableCacheControls(Enable As Boolean)

        '    If ComboBoxItemSharebook_Sharebook.InvokeRequired Then

        '        ComboBoxItemSharebook_Sharebook.Invoke(Sub() ComboBoxItemSharebook_Sharebook.Enabled = Enable)

        '    Else

        '        ComboBoxItemSharebook_Sharebook.Enabled = Enable

        '    End If

        'End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.MarketDetails_Load(_MediaBroadcastWorksheetID, _MediaBroadcastWorksheetMarketID)

            If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                LabelItemHUTPUT_HUTPUT.Text = "SIU:"

            Else

                LabelItemHUTPUT_HUTPUT.Text = "H/PUT:"

            End If

            If _MediaBroadcastWorksheetMarketID = 0 AndAlso _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                _MediaBroadcastWorksheetMarketID = _ViewModel.SelectedWorksheetMarket.ID

            End If

        End Sub
        Private Sub LoadGrid()

            BandedDataGridViewForm_MarketDetails.DataSource = _ViewModel.DataTable

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.ReloadGrid()

            End If

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
            Dim StreamWriter As System.IO.StreamWriter = Nothing
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing
            Dim RefreshGoals As Boolean = False

            If _ViewModel.GridAdvantage IsNot Nothing AndAlso String.IsNullOrWhiteSpace(_ViewModel.GridAdvantage.XmlLayout) = False Then

                OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid

                OptionsLayoutGrid.Assign(DevExpress.Utils.OptionsLayoutBase.FullLayout)

                OptionsLayoutGrid.StoreAllOptions = True
                OptionsLayoutGrid.Columns.StoreAllOptions = True
                OptionsLayoutGrid.Columns.StoreLayout = True
                OptionsLayoutGrid.Columns.StoreAppearance = True
                OptionsLayoutGrid.Columns.AddNewColumns = True
                OptionsLayoutGrid.Columns.RemoveOldColumns = False
                OptionsLayoutGrid.StoreVisualOptions = True
                OptionsLayoutGrid.StoreAppearance = True

                MemoryStreamLayout = New System.IO.MemoryStream()
                StreamWriter = New System.IO.StreamWriter(MemoryStreamLayout)

                StreamWriter.AutoFlush = True
                StreamWriter.Write(_ViewModel.GridAdvantage.XmlLayout)

                MemoryStreamLayout.Position = 0

                BandedDataGridViewForm_MarketDetails.CurrentView.RestoreLayoutFromStream(MemoryStreamLayout, OptionsLayoutGrid)

            Else

                FormatGridOriginalState()

            End If

            FormatGridPermanentOptions()

            FormatGridSubmarketBands()

            BandedDataGridViewForm_MarketDetails.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default
            BandedDataGridViewForm_MarketDetails.OptionsFilter.AllowFilterEditor = False
            BandedDataGridViewForm_MarketDetails.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).FilterInfo.FilterString <> "" Then

                BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).ClearFilter()

            End If

            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString).FilterInfo.FilterString <> "" Then

                RefreshGoals = True

            End If

            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString).FilterInfo.FilterString <> "" Then

                RefreshGoals = True

            End If

            _Controller.MarketDetails_FilterStringChanged(_ViewModel, If(BandedDataGridViewForm_MarketDetails.CurrentView.ActiveFilterCriteria IsNot Nothing, BandedDataGridViewForm_MarketDetails.CurrentView.ActiveFilterCriteria.ToString, String.Empty),
                                                          DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(BandedDataGridViewForm_MarketDetails.CurrentView.ActiveFilterCriteria), RefreshGoals)

            _ColumnFilterStrings = New Hashtable

            _ColumnFilterStrings(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString)) = BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString).FilterInfo.FilterString
            _ColumnFilterStrings(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString)) = BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString).FilterInfo.FilterString

            BandedDataGridViewForm_MarketDetails.RefreshViewCaption()

        End Sub
        Private Sub FormatGridSubmarketBands()

            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing
            Dim WorksheetMarketSubmarketDemo As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarketDemo = Nothing

            ClearSubmarketBandsAndColumns()

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.FormatSubmarketBands()

            End If

            'If _ViewModel.DoesWorksheetAllowSubmarkets Then

            '    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString)

            '    If GridBand Is Nothing Then

            '        GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Insert(GridBandNames.GridBandPrimarySubmarketDemo)

            '        GridBand.Name = GridBandNames.GridBandPrimarySubmarketDemo.ToString

            '    End If

            '    GridBand.Caption = _ViewModel.Worksheet.PrimaryMediaDemographicDescription
            '    GridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            '    GridBand.OptionsBand.ShowInCustomizationForm = False
            '    GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            '    GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
            '    GridBand.Visible = True

            '    If _ViewModel.WorksheetMarketSubmarkets IsNot Nothing AndAlso
            '            _ViewModel.WorksheetMarketSubmarkets.Count > 0 Then

            '        For Each WorksheetMarketSubmarket In _ViewModel.WorksheetMarketSubmarkets

            '            WorksheetMarketSubmarketDemo = Nothing

            '            Try

            '                WorksheetMarketSubmarketDemo = _ViewModel.WorksheetMarketSubmarketDemos.SingleOrDefault(Function(Entity) Entity.IsPrimaryDemo = True AndAlso
            '                                                                                                                         Entity.MediaBroadcastWorksheetMarketSubmarketID = WorksheetMarketSubmarket.ID)

            '            Catch ex As Exception
            '                WorksheetMarketSubmarketDemo = Nothing
            '            End Try

            '            If WorksheetMarketSubmarketDemo IsNot Nothing Then

            '                AddGridBandUnboundColumn(GridBand, WorksheetMarketSubmarketDemo.ColumnName, WorksheetMarketSubmarketDemo.Market,
            '                                         DevExpress.Data.UnboundColumnType.Decimal, DevExpress.Utils.FormatType.Numeric, "f2", True)

            '            End If

            '        Next

            '    End If

            '    ''''
            '    'Secondary
            '    ''''
            '    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

            '    If GridBand Is Nothing Then

            '        GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Add()

            '        GridBand.Name = GridBandNames.GridBandSecondarySubmarketDemo.ToString

            '    End If

            '    If _ViewModel.SelectedWorksheetMarketSecondaryDemo IsNot Nothing Then

            '        GridBand.Caption = _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicDescription

            '    Else

            '        GridBand.Caption = String.Empty

            '    End If

            '    GridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            '    GridBand.OptionsBand.ShowInCustomizationForm = False
            '    GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            '    GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
            '    GridBand.Visible = True

            '    If _ViewModel.WorksheetSecondaryDemos IsNot Nothing AndAlso
            '            _ViewModel.WorksheetSecondaryDemos.Count > 0 AndAlso
            '            _ViewModel.WorksheetMarketSubmarkets IsNot Nothing AndAlso
            '            _ViewModel.WorksheetMarketSubmarkets.Count > 0 Then

            '        For Each WorksheetSecondaryDemo In _ViewModel.WorksheetSecondaryDemos

            '            For Each WorksheetMarketSubmarket In _ViewModel.WorksheetMarketSubmarkets

            '                WorksheetMarketSubmarketDemo = Nothing

            '                Try

            '                    WorksheetMarketSubmarketDemo = _ViewModel.WorksheetMarketSubmarketDemos.SingleOrDefault(Function(Entity) Entity.IsPrimaryDemo = False AndAlso
            '                                                                                                                             Entity.MediaBroadcastWorksheetMarketSubmarketID = WorksheetMarketSubmarket.ID AndAlso
            '                                                                                                                             Entity.MediaDemographicID = WorksheetSecondaryDemo.MediaDemographicID)

            '                Catch ex As Exception
            '                    WorksheetMarketSubmarketDemo = Nothing
            '                End Try

            '                If WorksheetMarketSubmarketDemo IsNot Nothing Then

            '                    AddGridBandUnboundColumn(GridBand, WorksheetMarketSubmarketDemo.ColumnName, WorksheetMarketSubmarketDemo.Market,
            '                                             DevExpress.Data.UnboundColumnType.Decimal, DevExpress.Utils.FormatType.Numeric, "f2", True)

            '                End If

            '            Next

            '        Next

            '    End If

            'End If

        End Sub
        Private Sub FormatGridOriginalState()

            'objects
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

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
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString))

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Add()

            GridBand.Name = GridBandNames.GridBandOtherData.ToString
            GridBand.Caption = ""
            GridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            'GridBand.OptionsBand.AllowMove = False
            'GridBand.OptionsBand.AllowPress = False
            GridBand.OptionsBand.ShowInCustomizationForm = False

            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString))

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString))

            End If

            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString))

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString))

            End If

            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString))


            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString))

            End If

            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString))

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                GridBand.Columns.Add(GridColumn)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString)

                GridBand.Columns.Add(GridColumn)

            Next

            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString))

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).Group()
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.AllowEdit = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowShowHide = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowEdit = False

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).DisplayFormat.FormatString = "0000"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.AllowEdit = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).DisplayFormat.FormatString = "000"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.AllowEdit = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).OptionsColumn.AllowShowHide = False

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.AllowShowHide = False

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

            'BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString)

            'BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString)

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString).DisplayFormat.FormatString = "f0"

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString)

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString).DisplayFormat.FormatString = "t"

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString).DisplayFormat.FormatString = "t"

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString).OptionsColumn.AllowShowHide = False

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString).OptionsColumn.AllowShowHide = False

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString)

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString).DisplayFormat.FormatString = "c2"

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                GridGroupSummaryItem.FieldName = GridColumn.FieldName
                GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn
                GridGroupSummaryItem.DisplayFormat = "{0:f0}"

                BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.Add(GridGroupSummaryItem)
                AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridColumn.DisplayFormat.FormatString = "f0"
                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False
                GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName)
                GridColumn.Visible = True

            Next

            For Each RateDate In _ViewModel.RateDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(RateDate).ToString)

                GridColumn.Caption = "Rate"

                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridColumn.DisplayFormat.FormatString = "c2"
                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False
                GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName.Replace("Rate", "Date"))
                GridColumn.Visible = False

            Next

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).DisplayFormat.FormatString = "f0"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).OptionsColumn.AllowShowHide = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString), "{0:f0}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString), "{0:f0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).DisplayFormat.FormatString = "c2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.AllowShowHide = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).DisplayFormat.FormatString = "c2"
            'BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.AllowMove = False
            'BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.ShowInCustomizationForm = False
            'BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.AllowShowHide = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Add()

            GridBand.Name = GridBandNames.GridBandPrimaryDemo.ToString
            GridBand.Caption = "Primary Demo"
            GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString))

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString))

            End If

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Add()

            GridBand.Name = GridBandNames.GridBandSecondaryDemo.ToString
            GridBand.Caption = "Secondary Demo"
            GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString))

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString))
                GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString))

            End If

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).DisplayFormat.FormatString = "f2"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.AllowEdit = True

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).DisplayFormat.FormatString = "f2"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.AllowEdit = True

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).DisplayFormat.FormatString = "f2"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.AllowEdit = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.AllowShowHide = False

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).DisplayFormat.FormatString = "f1"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.AllowEdit = True

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString).DisplayFormat.FormatString = "c2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString).DisplayFormat.FormatString = "f2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.AllowShowHide = False

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.AllowEdit = True

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).DisplayFormat.FormatString = "f1"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.AllowEdit = False

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.AllowEdit = False

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).DisplayFormat.FormatString = "p1"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).DisplayFormat.FormatString = "f1"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.AllowEdit = False

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.AllowEdit = True

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.AllowEdit = True

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString).DisplayFormat.FormatString = "n0"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).DisplayFormat.FormatString = "c2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).DisplayFormat.FormatString = "f2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).OptionsColumn.AllowEdit = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatString = "n0"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).OptionsColumn.AllowEdit = False

            '=========================================
            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).DisplayFormat.FormatString = "f2"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.AllowEdit = True

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).DisplayFormat.FormatString = "f2"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.AllowEdit = True

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).DisplayFormat.FormatString = "f2"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.AllowEdit = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.AllowShowHide = False

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).DisplayFormat.FormatString = "f1"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.AllowEdit = True

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).DisplayFormat.FormatString = "c2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).DisplayFormat.FormatString = "f2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.AllowShowHide = False

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.AllowEdit = True

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).DisplayFormat.FormatString = "f1"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.AllowEdit = False

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.AllowEdit = False

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).DisplayFormat.FormatString = "p1"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).DisplayFormat.FormatString = "f1"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.AllowEdit = False

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.AllowEdit = True

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.AllowEdit = True

            End If

            BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).DisplayFormat.FormatString = "n0"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).DisplayFormat.FormatString = "c2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).OptionsColumn.AllowEdit = False
            AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).DisplayFormat.FormatString = "f2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).OptionsColumn.AllowEdit = False

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatString = "n0"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).OptionsColumn.AllowEdit = False

        End Sub
        Private Sub FormatGridPermanentOptions()

            'objects
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing
            Dim ImageCollection As DevExpress.Utils.ImageCollection = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim BandedGridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            'If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString) IsNot Nothing Then

            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).Visible = False

            'End If

            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowChangeColumnParent = False
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.ShowBandsInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowBandMoving = True
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowChangeBandParent = False

            For Each GridBand In BandedDataGridViewForm_MarketDetails.CurrentView.Bands

                GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
                'GridBand.OptionsBand.AllowMove = False
                'GridBand.OptionsBand.AllowPress = False
                GridBand.OptionsBand.ShowInCustomizationForm = False

            Next

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimaryDemo.ToString)

            If GridBand IsNot Nothing Then

                GridBand.Caption = _ViewModel.Worksheet.PrimaryMediaDemographicDescription

                _Controller.MarketDetails_ShowPrimaryDemosChanged(_ViewModel, GridBand.Visible AndAlso _ViewModel.Worksheet.PrimaryMediaDemographicID.GetValueOrDefault(0) > 0)

            Else

                _Controller.MarketDetails_ShowPrimaryDemosChanged(_ViewModel, False)

            End If

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondaryDemo.ToString)

            If GridBand IsNot Nothing Then

                GridBand.Visible = (_ViewModel.HasASelectedWorksheetSecondaryDemo AndAlso _ViewModel.Demos_ShowSecondaryDemos)

                If _ViewModel.HasASelectedWorksheetSecondaryDemo Then

                    GridBand.Caption = _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicDescription

                End If

                _Controller.MarketDetails_ShowSecondaryDemosChanged(_ViewModel, GridBand.Visible)

            Else

                _Controller.MarketDetails_ShowSecondaryDemosChanged(_ViewModel, False)

            End If

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

            If GridBand IsNot Nothing Then

                If _ViewModel.HasASelectedWorksheetSecondaryDemo Then

                    GridBand.Caption = _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicDescription

                End If

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.AllowMove = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.ShowInCustomizationForm = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.AllowShowHide = True

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.AllowMove = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.ShowInCustomizationForm = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.AllowShowHide = True

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowMove = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.ShowInCustomizationForm = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowShowHide = True

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.AllowMove = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.ShowInCustomizationForm = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.AllowShowHide = True

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodDate.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodDate.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodDate.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodDate.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodDate.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodDate.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodSpots.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodSpots.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodSpots.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodSpots.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodSpots.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodSpots.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RowSource.ToString).Visible = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryRating.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryRating.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryRating.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryShare.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryShare.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryShare.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryShare.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryImpressions.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryImpressions.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryUniverse.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryUniverse.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryUniverse.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryUniverse.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            'If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString) IsNot Nothing Then

            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.AllowShowHide = False
            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False

            'End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQHRating.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQHRating.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQHRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQHRating.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQH.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQH.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQH.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryRating.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryRating.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryRating.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryShare.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryShare.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryShare.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryShare.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryImpressions.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryImpressions.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryUniverse.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryUniverse.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryUniverse.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryUniverse.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            'If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString) IsNot Nothing Then

            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.AllowShowHide = False
            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False

            'End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQHRating.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQHRating.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQHRating.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQHRating.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQH.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQH.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQH.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            'If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString) IsNot Nothing Then

            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowShowHide = False
            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.ShowInCustomizationForm = False
            '	BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.ShowInExpressionEditor = False

            'End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookProgram.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookProgram.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookProgram.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookProgram.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).DisplayFormat.FormatString = "f1"

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).DisplayFormat.FormatString = "f1"

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).DisplayFormat.FormatString = "f1"

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).DisplayFormat.FormatString = "f1"

            End If

            BandedDataGridViewForm_MarketDetails.OptionsFilter.ShowAllTableValuesInFilterPopup = True
            BandedDataGridViewForm_MarketDetails.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = True

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).DisplayFormat.FormatString = "c2"
                'BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.AllowMove = False
                'BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.ShowInCustomizationForm = True
                'BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.AllowShowHide = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).OptionsColumn.AllowEdit = False

                If CType(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString), DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).OwnerBand Is Nothing Then

                    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString)

                    If GridBand IsNot Nothing Then

                        GridBand.Columns.Add(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString))

                    End If

                End If

            End If

            'BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).DisplayFormat.FormatString = "c2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).OptionsColumn.AllowEdit = False

            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).DisplayFormat.FormatString = "f2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).OptionsColumn.AllowEdit = False

            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatString = "n0"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).OptionsColumn.AllowEdit = False

            'BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString)
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).DisplayFormat.FormatString = "c2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).OptionsColumn.AllowEdit = False

            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).DisplayFormat.FormatString = "f2"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).OptionsColumn.AllowEdit = False

            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatString = "n0"
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).OptionsColumn.AllowEdit = False

            'If _ViewModel.SelectedWorksheetMarketShowVendorDemo Then

            '    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)
            '    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)
            '    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString)
            '    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString)

            'Else

            '    BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)
            '    BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)
            '    BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString)
            '    BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString)

            'End If

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.AllowEdit = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.AllowEdit = True

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.AllowShowHide = False

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.AllowEdit = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.AllowEdit = True

            End If

            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedShare.ToString).OptionsColumn.ShowInCustomizationForm = False

            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedShare.ToString).OptionsColumn.ShowInCustomizationForm = False

            'REMOVE PRODUCT AND PIGGYBACK FOR NOW
            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString).OptionsColumn.AllowShowHide = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString).OptionsColumn.ShowInExpressionEditor = False

            End If

            BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.Clear()

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                AddGroupSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom)

                For Each GridSummaryItem In GridColumn.Summary.ToList

                    GridColumn.Summary.Remove(GridSummaryItem)

                Next

                AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, Nothing)
                AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings)
                AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions)
                AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars)
                AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings)
                AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars)
                AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings)
                AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars)
                AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent)
                AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent)

            Next

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString) IsNot Nothing Then

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString)

                AddGroupSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom)

                For Each GridSummaryItem In GridColumn.Summary.ToList

                    GridColumn.Summary.Remove(GridSummaryItem)

                Next

                AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, Nothing)
                AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings)
                AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions)
                AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars)
                AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings)
                AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars)
                AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings)
                AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars)
                AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent)
                AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent)

            End If

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString)

            If GridBand IsNot Nothing Then

                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryRating.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryRating.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryRating.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryRating.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryShare.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryShare.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryShare.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryShare.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryHPUT.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryHPUT.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryHPUT.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryHPUT.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPP.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPP.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPP.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPP.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGRP.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGRP.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGRP.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGRP.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryReach.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryReach.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryReach.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryReach.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryFrequency.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryFrequency.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryFrequency.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryFrequency.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCumeImpressions.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCumeImpressions.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCumeImpressions.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCumeImpressions.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryImpressions.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryImpressions.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryImpressions.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryImpressions.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGrossImpressions.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGrossImpressions.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGrossImpressions.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGrossImpressions.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPM.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPM.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPM.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPM.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryVendorSubmittedRating.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryVendorSubmittedRating.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryVendorSubmittedRating.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryVendorSubmittedRating.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryVendorSubmittedImpressions.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryVendorSubmittedImpressions.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryVendorSubmittedImpressions.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryVendorSubmittedImpressions.ToString))

                    End If

                ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryAQHRating.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryAQHRating.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryAQHRating.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryAQHRating.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPP.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPP.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPP.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPP.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGRP.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGRP.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGRP.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGRP.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryAQH.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryAQH.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryAQH.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryAQH.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCumeRating.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCumeRating.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCumeRating.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCumeRating.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCume.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCume.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCume.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCume.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryReach.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryReach.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryReach.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryReach.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryFrequency.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryFrequency.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryFrequency.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryFrequency.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryImpressions.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryImpressions.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryImpressions.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryImpressions.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGrossImpressions.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGrossImpressions.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGrossImpressions.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryGrossImpressions.ToString))

                    End If

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPM.ToString) IsNot Nothing Then

                        If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPM.ToString)) Then

                            GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPM.ToString))

                        End If

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(UnboundColumnNames.UnboundColumnPrimaryCPM.ToString))

                    End If

                End If

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).Caption = "Total Cost"

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).Caption = "Total Net"

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).Summary.Remove(GridSummaryItem)

                Next

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).DisplayFormat.FormatString = "p1"

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).Summary.Remove(GridSummaryItem)

                Next

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).DisplayFormat.FormatString = "f1"

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).OptionsColumn.AllowMove = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).OptionsColumn.ShowInCustomizationForm = True
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).OptionsColumn.AllowShowHide = True

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).Summary.Remove(GridSummaryItem)

                Next

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).DisplayFormat.FormatString = "p1"

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).Summary.Remove(GridSummaryItem)

                Next

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).DisplayFormat.FormatString = "f1"

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString) IsNot Nothing Then

                For Each GridSummaryItem In BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).Summary.ToList

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).Summary.Remove(GridSummaryItem)

                Next

                AddGroupSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            End If

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimaryDemo.ToString)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString))

                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString))

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString))

                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString))

            End If

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondaryDemo.ToString)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString))

                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString))

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString))
                AddColumnToGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString))

                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString))
                RemoveColumnFromGridBand(GridBand, BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString))

            End If

            For Each AllowSpotsToBeEnteredDate In _ViewModel.AllowSpotsToBeEnteredDates.Keys.OfType(Of Date).OrderBy(Function(ASTBED) ASTBED)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.AllowSpotsToBeEnteredDates(AllowSpotsToBeEnteredDate).ToString)

                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False
                GridColumn.Visible = False

            Next

            For Each OrderStatusDate In _ViewModel.OrderStatusDates.Keys.OfType(Of Date).OrderBy(Function(OSD) OSD)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.OrderStatusDates(OrderStatusDate).ToString)

                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False
                GridColumn.Visible = False

            Next

            If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                'If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString) IsNot Nothing Then

                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).OptionsColumn.AllowShowHide = False
                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).OptionsColumn.ShowInCustomizationForm = False
                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).Visible = False

                'End If

                'If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString) IsNot Nothing Then

                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).OptionsColumn.AllowShowHide = False
                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).OptionsColumn.ShowInCustomizationForm = False
                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).Visible = False

                'End If

                'If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString) IsNot Nothing Then

                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).OptionsColumn.AllowShowHide = False
                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).OptionsColumn.ShowInCustomizationForm = False
                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).Visible = False

                'End If

                'If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString) IsNot Nothing Then

                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).OptionsColumn.AllowShowHide = False
                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).OptionsColumn.ShowInCustomizationForm = False
                '    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).Visible = False

                'End If

            Else

                If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString) IsNot Nothing Then

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).OptionsColumn.AllowShowHide = True
                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).OptionsColumn.ShowInCustomizationForm = True

                End If

                If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString) IsNot Nothing Then

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).OptionsColumn.AllowShowHide = True
                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).OptionsColumn.ShowInCustomizationForm = True

                End If

                If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString) IsNot Nothing Then

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).OptionsColumn.AllowShowHide = True
                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).OptionsColumn.ShowInCustomizationForm = False

                End If

                If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString) IsNot Nothing Then

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).OptionsColumn.AllowShowHide = True
                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).OptionsColumn.ShowInCustomizationForm = False

                End If

            End If

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                If _ViewModel.SelectedWorksheetMarket IsNot Nothing AndAlso _ViewModel.SelectedWorksheetMarket.IsCable Then

                    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString)

                End If
                'Add subitem grid look up here
                If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString) IsNot Nothing Then

                    SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                    SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                    SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.CableNetworkStation
                    'SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                    BindingSource = New System.Windows.Forms.BindingSource

                    BindingSource.DataSource = _ViewModel.CableNetworkStations.OrderBy(Function(Entity) Entity.Description).Select(Function(Entity) New With {.Code = Entity.Code, .Description = Entity.Description}).ToList

                    SubItemGridLookUpEditControl.DataSource = BindingSource

                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "Code", "[None]", String.Empty, True, False, Nothing)

                    AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControl_QueryPopup

                    BandedDataGridViewForm_MarketDetails.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                    BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).ColumnEdit = SubItemGridLookUpEditControl

                End If

            End If

            'FormatGridPermanentOptions_OnMarketChanged()

            If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString) IsNot Nothing Then

                RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

                ImageCollection = New DevExpress.Utils.ImageCollection

                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallRedCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueSemiCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueCircleImage)
                ImageCollection.AddImage(AdvantageFramework.My.Resources.SmallPinkCircleImage)

                RepositoryItemImageComboBox.SmallImages = ImageCollection

                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered.ToString, CInt(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered), 0))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial.ToString, CInt(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial), 1))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered.ToString, CInt(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered), 2))
                RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified.ToString, CInt(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified), 3))

                RepositoryItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

                BandedDataGridViewForm_MarketDetails.GridControl.RepositoryItems.Add(RepositoryItemImageComboBox)

                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).ColumnEdit = RepositoryItemImageComboBox

            End If

            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowGroup = True

            For Each GridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                If GridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString Then

                    GridColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True

                Else

                    GridColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False

                End If

            Next


            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Classic

        End Sub
        Private Sub AddColumnToGridBand(GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand, BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)

            Dim ColVIndex As Integer = -1

            If GridBand IsNot Nothing AndAlso BandedGridColumn IsNot Nothing Then

                If GridBand.Columns.Contains(BandedGridColumn) = False Then

                    ColVIndex = BandedGridColumn.ColVIndex

                    GridBand.Columns.Add(BandedGridColumn)

                    BandedGridColumn.ColVIndex = ColVIndex

                End If

            End If

        End Sub
        Private Sub RemoveColumnFromGridBand(GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand, BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)

            If GridBand IsNot Nothing AndAlso BandedGridColumn IsNot Nothing Then

                If GridBand.Columns.Contains(BandedGridColumn) Then

                    GridBand.Columns.Remove(BandedGridColumn)

                End If

                BandedGridColumn.OptionsColumn.AllowMove = False
                BandedGridColumn.OptionsColumn.ShowInCustomizationForm = False
                BandedGridColumn.OptionsColumn.ShowInExpressionEditor = False
                BandedGridColumn.OptionsColumn.AllowShowHide = False

            End If

        End Sub
        Private Sub AddGridBandUnboundColumn(GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand, UnboundColumnName As String,
                                             Caption As String, UnboundColumnType As DevExpress.Data.UnboundColumnType,
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

                AddGroupSummaryItemToColumn(BandedGridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom)
                AddSummaryItemToColumn(BandedGridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                'BandedDataGridViewForm_MarketDetails.Columns.Add(BandedGridColumn)

                'If BandedGridColumn.Visible Then

                '    BandedGridColumn.VisibleIndex = GridBand.Columns.Count - 1

                'End If

            End If

        End Sub
        Private Sub ClearSubmarketBandsAndColumns()

            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing
            Dim WorksheetMarketDetailSubmarketDemoColumnName As String = Nothing
            Dim WorksheetMarketDetailSubmarketDemoColumnCaption As String = Nothing

            If _ViewModel.DoesWorksheetAllowSubmarkets Then

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString)
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.AllowShowHide = False

                GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimaryDemo.ToString)

                If GridBand IsNot Nothing Then

                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString, GridBand)

                End If

                GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondaryDemo.ToString)

                If GridBand IsNot Nothing Then

                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString, GridBand)
                    RemoveColumn(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString, GridBand)

                End If

            End If

            'GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString)

            'If GridBand IsNot Nothing Then

            '    For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

            '        GridBand.Columns.Remove(GridColumn)

            '        If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Contains(GridColumn) Then

            '            BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

            '        End If

            '    Next

            '    If _ViewModel.WorksheetMarketSubmarketDemos IsNot Nothing AndAlso
            '            _ViewModel.WorksheetMarketSubmarketDemos.Count > 0 Then

            '        For Each WorksheetMarketSubmarketDemo In _ViewModel.WorksheetMarketSubmarketDemos.Where(Function(Entity) Entity.IsPrimaryDemo = True).ToList

            '            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(WorksheetMarketSubmarketDemo.ColumnName) IsNot Nothing Then

            '                BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(WorksheetMarketSubmarketDemo.ColumnName))

            '            End If

            '        Next

            '    End If

            '    BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Remove(GridBand)

            'End If

            'GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

            'If GridBand IsNot Nothing Then

            '    For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

            '        GridBand.Columns.Remove(GridColumn)

            '        If BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Contains(GridColumn) Then

            '            BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

            '        End If

            '    Next

            '    If _ViewModel.WorksheetMarketSubmarketDemos IsNot Nothing AndAlso
            '            _ViewModel.WorksheetMarketSubmarketDemos.Count > 0 Then

            '        For Each WorksheetMarketSubmarketDemo In _ViewModel.WorksheetMarketSubmarketDemos.Where(Function(Entity) Entity.IsPrimaryDemo = False).ToList

            '            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(WorksheetMarketSubmarketDemo.ColumnName) IsNot Nothing Then

            '                BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(WorksheetMarketSubmarketDemo.ColumnName))

            '            End If

            '        Next

            '    End If

            '    BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Remove(GridBand)

            'End If

            'For Each GridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

            '    If GridColumn.FieldName.StartsWith("Submarket") OrElse GridColumn.FieldName.StartsWith("SM") OrElse
            '            GridColumn.Name.StartsWith("Submarket") OrElse GridColumn.Name.StartsWith("SM") Then

            '        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

            '    End If

            'Next

        End Sub
        Private Sub FormatGrid_ShowSummary(ShowSummary As Boolean)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If ButtonItemDisplay_ShowTotals.Checked Then

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                    AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings)
                    AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions)
                    AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars)
                    AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings)
                    AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars)
                    AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings)
                    AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars)
                    AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent)
                    AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent)

                Next

                If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString) IsNot Nothing Then

                    GridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString)

                    AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings)
                    AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions)
                    AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars)
                    AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings)
                    AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars)
                    AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings)
                    AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars)
                    AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent)
                    AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent)

                End If

            Else

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                    For Each GridSummaryItem In GridColumn.Summary.ToList

                        If GridSummaryItem.Tag <> Nothing AndAlso GridSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom Then

                            GridColumn.Summary.Remove(GridSummaryItem)

                        End If

                    Next

                Next

                If BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString) IsNot Nothing Then

                    GridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString)

                    For Each GridSummaryItem In GridColumn.Summary.ToList

                        If GridSummaryItem.Tag <> Nothing AndAlso GridSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom Then

                            GridColumn.Summary.Remove(GridSummaryItem)

                        End If

                    Next

                End If

            End If

        End Sub
        Private Sub RefreshViewModel(ReloadMarkets As Boolean)

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.SaveEnabled
            ButtonItemRevisions_Create.Enabled = _ViewModel.CreateRevisionEnabled AndAlso Not _ViewModel.WorksheetMarketDetailVendorMakegoodStatuses.Where(Function(VMS) VMS.Status = Database.Entities.Methods.OrderStatusType.MakegoodOfferSubmitted).Any
            ButtonItemActions_DeleteRevision.Enabled = _ViewModel.DeleteRevisionEnabled
            ComboBoxItemRevisions_Revisions.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemActions_CopyHiatusDates.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemRevisions_View.Enabled = _ViewModel.HasASelectedWorksheetMarket

            ButtonItemVendors_Edit.Enabled = _ViewModel.EditVendorEnabled
            ButtonItemMakegood_Offers.Enabled = _ViewModel.VendorMakegoodAvailable

            ButtonItemOrders_Refresh.Enabled = Not _ViewModel.SaveEnabled

            'ButtonItemMarkets_Manage.Enabled = _ViewModel.Markets_ManageEnabled

            'ButtonItemActions_Goals.Enabled = _ViewModel.Schedule_GoalsEnabled
            ButtonItemVendors_Manage.Enabled = _ViewModel.Schedule_SelectVendorsEnabled
            ButtonItemSchedule_OrderComments.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemVendors_RFP.Enabled = _ViewModel.Schedule_RFPEnabled AndAlso _ViewModel.DataTable IsNot Nothing AndAlso _ViewModel.DataTable.Rows.Count > 0 AndAlso _ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber
            ButtonItemSchedule_Books.Enabled = _ViewModel.MeasurementTrendBookSelectionEnabled
            ButtonItemSchedule_Books2.Enabled = _ViewModel.MeasurementTrendBookSelectionEnabled
            ButtonItemResearch_Trends.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemResearch_Trends2.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemDisplay_Summaries.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemDisplay_ShowTotals.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemDisplay_HideZeroSpotLines.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemSchedule_ShowVendorDemos.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemSchedule_ViewOrderDetails.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemSchedule_RefreshDemos.Enabled = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber)

            ComboBoxItemSharebook_Sharebook.Enabled = _ViewModel.BookSelectionEnabled
            ComboBoxItemHUTPUT_HUTPUT.Enabled = _ViewModel.BookSelectionEnabled
            ComboBoxItemBook1_Book1.Enabled = _ViewModel.BookSelectionEnabled
            ComboBoxItemBook2_Book2.Enabled = _ViewModel.BookSelectionEnabled
            ComboBoxItemBook3_Book3.Enabled = _ViewModel.BookSelectionEnabled
            ComboBoxItemBook4_Book4.Enabled = _ViewModel.BookSelectionEnabled
            ComboBoxItemBook5_Book5.Enabled = _ViewModel.BookSelectionEnabled

            'ComboBoxItemSharebook_Sharebook.Tooltip = _ViewModel.BookTooltip
            'ComboBoxItemHUTPUT_HUTPUT.Tooltip = _ViewModel.BookTooltip
            'ComboBoxItemBook1_Book1.Tooltip = _ViewModel.BookTooltip
            'ComboBoxItemBook2_Book2.Tooltip = _ViewModel.BookTooltip
            'ComboBoxItemBook3_Book3.Tooltip = _ViewModel.BookTooltip
            'ComboBoxItemBook4_Book4.Tooltip = _ViewModel.BookTooltip
            'ComboBoxItemBook5_Book5.Tooltip = _ViewModel.BookTooltip

            ButtonItemActions_AddRow.Enabled = _ViewModel.ScheduleDetails_AddEnabled
            ButtonItemActions_DeleteRow.Enabled = _ViewModel.ScheduleDetails_DeleteEnabled
            ButtonItemActions_CopyRow.Enabled = _ViewModel.ScheduleDetails_CopyEnabled
            ButtonItemActions_AutoFill.Enabled = _ViewModel.ScheduleDetails_AutoFillEnabled

            ButtonItemMakegood_Add.Enabled = _ViewModel.ScheduleDetails_AddEnabled AndAlso BandedDataGridViewForm_MarketDetails.HasOnlyOneSelectedRow AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) = False
            ButtonItemMakegood_AddReplacement.Enabled = _ViewModel.ScheduleDetails_AddEnabled AndAlso BandedDataGridViewForm_MarketDetails.HasOnlyOneSelectedRow AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) = False
            ButtonItemMakegood_Details.Enabled = _ViewModel.MakegoodViewDetailsEnabled

            ButtonItemDates_Show.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemDates_ShowAll.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemDates_HideHiatusDates.Enabled = _ViewModel.HasASelectedWorksheetMarket

            ButtonItemDemos_ShowPrimary.Checked = _ViewModel.Demos_ShowPrimaryDemos
            ButtonItemDemos_ShowSecondary.Checked = _ViewModel.Demos_ShowSecondaryDemos

            ButtonItemDemos_ShowPrimary.Enabled = _ViewModel.HasASelectedWorksheetMarket
            ButtonItemDemos_ShowSecondary.Enabled = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.HasASelectedWorksheetSecondaryDemo)

            ComboBoxItemSecondaryDemo_SecondaryDemo.Enabled = _ViewModel.HasASelectedWorksheetMarket

            ButtonItemGridOptions_ChooseColumns.Enabled = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber)
            ButtonItemGridOptions_RestoreDefaults.Enabled = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber)

            ButtonItemOrders_Create.Enabled = _ViewModel.CreateOrdersEnabled
            ButtonItemOrders_CreateForSelected.Enabled = _ViewModel.CreateOrders_SelectedLinesOnlyEnabled

            ButtonItemOrders_Generate.Enabled = _ViewModel.GenerateOrdersEnabled

            BandedDataGridViewForm_MarketDetails.OptionsBehavior.Editable = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber)
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowColumnMoving = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber)
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowGroup = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber)
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowQuickHideColumns = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber)
            BandedDataGridViewForm_MarketDetails.OptionsMenu.EnableColumnMenu = (_ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.IsMaxRevisionNumber)

            ButtonItemSchedule_ShowVendorDemos.Checked = _ViewModel.SelectedWorksheetMarketShowVendorDemo

            ButtonItemExport_Proposal.Enabled = (_ViewModel.DataTable.Rows.Count > 0 AndAlso _ViewModel.IsMaxRevisionNumber AndAlso _ViewModel.Worksheet.MediaTypeCode = "R")
            ButtonItemExport_ProposalRatesSuppressed.Enabled = (_ViewModel.DataTable.Rows.Count > 0 AndAlso _ViewModel.IsMaxRevisionNumber AndAlso _ViewModel.Worksheet.MediaTypeCode = "R")

            If _ViewModel.HasASelectedWorksheetMarket Then

                ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarketRevisionNumber

            Else

                ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue = 0

            End If

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                If _ViewModel.HasASelectedWorksheetMarket Then

                    ComboBoxItemSharebook_Sharebook.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.SharebookNielsenTVBookID.GetValueOrDefault(0)
                    ComboBoxItemHUTPUT_HUTPUT.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.HUTPUTNielsenTVBookID.GetValueOrDefault(0)

                Else

                    ComboBoxItemSharebook_Sharebook.ComboBoxEx.SelectedValue = 0
                    ComboBoxItemHUTPUT_HUTPUT.ComboBoxEx.SelectedValue = 0

                End If

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                If _ViewModel.HasASelectedWorksheetMarket Then

                    ComboBoxItemBook1_Book1.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID1.GetValueOrDefault(0)
                    ComboBoxItemBook2_Book2.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID2.GetValueOrDefault(0)
                    ComboBoxItemBook3_Book3.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID3.GetValueOrDefault(0)
                    ComboBoxItemBook4_Book4.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID4.GetValueOrDefault(0)
                    ComboBoxItemBook5_Book5.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID5.GetValueOrDefault(0)

                Else

                    ComboBoxItemBook1_Book1.ComboBoxEx.SelectedValue = 0
                    ComboBoxItemBook2_Book2.ComboBoxEx.SelectedValue = 0
                    ComboBoxItemBook3_Book3.ComboBoxEx.SelectedValue = 0
                    ComboBoxItemBook4_Book4.ComboBoxEx.SelectedValue = 0
                    ComboBoxItemBook5_Book5.ComboBoxEx.SelectedValue = 0

                End If

            End If

            If _ViewModel.HasASelectedWorksheetMarket AndAlso _ViewModel.SelectedWorksheetMarketSecondaryDemo IsNot Nothing Then

                ComboBoxItemSecondaryDemo_SecondaryDemo.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicID

            Else

                ComboBoxItemSecondaryDemo_SecondaryDemo.ComboBoxEx.SelectedValue = 0

            End If

            ButtonItemGridOptions_ChooseColumns.Checked = _ViewModel.GridOptions_ChooseColumns

            BandedDataGridViewForm_MarketDetails.Enabled = _ViewModel.HasASelectedWorksheetMarket

            If ReloadMarkets Then

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _Controller.MarketDetails_LoadMarketSelection(_ViewModel)

                ComboBoxItemMarkets_Markets.ComboBoxEx.DataSource = BindingSource

                'AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "MarketDescription", "ID", "[Please select]", 0, True, False, Nothing)

            End If

            If _ViewModel.HasASelectedWorksheetMarket Then

                ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.ID

                DateEditPeriodStart_Date.EditValue = _ViewModel.SelectedWorksheetMarket.PeriodStart
                DateEditPeriodEnd_Date.EditValue = _ViewModel.SelectedWorksheetMarket.PeriodEnd

                DateEditPeriodStart_Date.SetRequired(_ViewModel.SelectedWorksheetMarket.PeriodStart.HasValue OrElse _ViewModel.SelectedWorksheetMarket.PeriodEnd.HasValue)
                DateEditPeriodEnd_Date.SetRequired(_ViewModel.SelectedWorksheetMarket.PeriodStart.HasValue OrElse _ViewModel.SelectedWorksheetMarket.PeriodEnd.HasValue)

            Else

                ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue = 0

            End If

        End Sub
        Private Sub LoadRevisionNumbers()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From RevisionNumber In _ViewModel.SelectedWorksheetMarketRevisionNumbers
                                        Select RevisionNumberText = Format(RevisionNumber, "000"),
                                               RevisionNumber = RevisionNumber).ToList

            ComboBoxItemRevisions_Revisions.ComboBoxEx.DataSource = BindingSource

        End Sub
        Private Sub LoadDateSelections()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = _ViewModel.DateSelections.ToList

            ComboBoxItemDates_StartDate.ComboBoxEx.DataSource = BindingSource

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = _ViewModel.DateSelections.ToList

            ComboBoxItemDates_EndDate.ComboBoxEx.DataSource = BindingSource

        End Sub
        Private Sub LoadWorksheetSecondaryDemos()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From WorksheetSecondaryDemo In _ViewModel.WorksheetSecondaryDemos
                                        Select MediaDemographicDescription = WorksheetSecondaryDemo.MediaDemographicDescription,
                                               MediaDemographicID = WorksheetSecondaryDemo.MediaDemographicID).ToList

            ComboBoxItemSecondaryDemo_SecondaryDemo.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "MediaDemographicDescription", "MediaDemographicID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub LoadSharebooks()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From NielsenTVBook In _ViewModel.WorksheetMarketShareBooks
                                        Select Description = NielsenTVBook.Description,
                                               ID = NielsenTVBook.ID).ToList

            ComboBoxItemSharebook_Sharebook.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "ID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub LoadHUTPUTBooks()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From NielsenTVBook In _ViewModel.WorksheetMarketHUTPUTBooks
                                        Select Description = NielsenTVBook.Description,
                                               ID = NielsenTVBook.ID).ToList

            ComboBoxItemHUTPUT_HUTPUT.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "ID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub LoadRadioPeriodsBook1()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From NielsenRadioPeriod In _Controller.MarketDetails_LoadNielsenRadioPeriodsBook1(_ViewModel)
                                        Select Description = NielsenRadioPeriod.Description,
                                               ID = NielsenRadioPeriod.ID).ToList

            ComboBoxItemBook1_Book1.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "ID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub LoadRadioPeriodsBook2()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From NielsenRadioPeriod In _Controller.MarketDetails_LoadNielsenRadioPeriodsBook2(_ViewModel)
                                        Select Description = NielsenRadioPeriod.Description,
                                               ID = NielsenRadioPeriod.ID).ToList

            ComboBoxItemBook2_Book2.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "ID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub LoadRadioPeriodsBook3()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From NielsenRadioPeriod In _Controller.MarketDetails_LoadNielsenRadioPeriodsBook3(_ViewModel)
                                        Select Description = NielsenRadioPeriod.Description,
                                               ID = NielsenRadioPeriod.ID).ToList

            ComboBoxItemBook3_Book3.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "ID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub LoadRadioPeriodsBook4()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From NielsenRadioPeriod In _Controller.MarketDetails_LoadNielsenRadioPeriodsBook4(_ViewModel)
                                        Select Description = NielsenRadioPeriod.Description,
                                               ID = NielsenRadioPeriod.ID).ToList

            ComboBoxItemBook4_Book4.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "ID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub LoadRadioPeriodsBook5()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From NielsenRadioPeriod In _Controller.MarketDetails_LoadNielsenRadioPeriodsBook5(_ViewModel)
                                        Select Description = NielsenRadioPeriod.Description,
                                               ID = NielsenRadioPeriod.ID).ToList

            ComboBoxItemBook5_Book5.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "ID", "[Please select]", 0, True, False, Nothing)

        End Sub
        Private Sub SetControlPropertySettings()

            BandedDataGridViewForm_MarketDetails.CurrentView.ModifyGridRowHeight = True

            BandedDataGridViewForm_MarketDetails.SetupForEditableGrid()

            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowQuickHideColumns = True
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowGroup = True
            BandedDataGridViewForm_MarketDetails.OptionsCustomization.AllowColumnMoving = True

            BandedDataGridViewForm_MarketDetails.CurrentView.GroupRowHeight = 20
            BandedDataGridViewForm_MarketDetails.CurrentView.FooterPanelHeight = 20
            BandedDataGridViewForm_MarketDetails.CurrentView.ColumnPanelRowHeight = 20

            BandedDataGridViewForm_MarketDetails.OptionsBehavior.AutoSelectAllInEditor = True
            BandedDataGridViewForm_MarketDetails.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
            BandedDataGridViewForm_MarketDetails.OptionsNavigation.AutoMoveRowFocus = True
            BandedDataGridViewForm_MarketDetails.OptionsNavigation.EnterMoveNextColumn = True
            BandedDataGridViewForm_MarketDetails.OptionsNavigation.UseOfficePageNavigation = True
            BandedDataGridViewForm_MarketDetails.OptionsNavigation.UseTabKey = True

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

            ComboBoxItemMarkets_Markets.ComboBoxEx.DisplayMember = "MarketDescription"
            ComboBoxItemMarkets_Markets.ComboBoxEx.ValueMember = "ID"

            ComboBoxItemRevisions_Revisions.ComboBoxEx.DisplayMember = "RevisionNumberText"
            ComboBoxItemRevisions_Revisions.ComboBoxEx.ValueMember = "RevisionNumber"

            ComboBoxItemSecondaryDemo_SecondaryDemo.ComboBoxEx.DisplayMember = "MediaDemographicDescription"
            ComboBoxItemSecondaryDemo_SecondaryDemo.ComboBoxEx.ValueMember = "MediaDemographicID"

            ComboBoxItemSharebook_Sharebook.ComboBoxEx.DisplayMember = "Description"
            ComboBoxItemSharebook_Sharebook.ComboBoxEx.ValueMember = "ID"
            ComboBoxItemSharebook_Sharebook.ComboWidth = 150

            ComboBoxItemHUTPUT_HUTPUT.ComboBoxEx.DisplayMember = "Description"
            ComboBoxItemHUTPUT_HUTPUT.ComboBoxEx.ValueMember = "ID"
            ComboBoxItemHUTPUT_HUTPUT.ComboWidth = 150

            ComboBoxItemBook1_Book1.ComboBoxEx.DisplayMember = "Description"
            ComboBoxItemBook1_Book1.ComboBoxEx.ValueMember = "ID"

            ComboBoxItemBook2_Book2.ComboBoxEx.DisplayMember = "Description"
            ComboBoxItemBook2_Book2.ComboBoxEx.ValueMember = "ID"

            ComboBoxItemBook3_Book3.ComboBoxEx.DisplayMember = "Description"
            ComboBoxItemBook3_Book3.ComboBoxEx.ValueMember = "ID"

            ComboBoxItemBook4_Book4.ComboBoxEx.DisplayMember = "Description"
            ComboBoxItemBook4_Book4.ComboBoxEx.ValueMember = "ID"

            ComboBoxItemBook5_Book5.ComboBoxEx.DisplayMember = "Description"
            ComboBoxItemBook5_Book5.ComboBoxEx.ValueMember = "ID"

            ComboBoxItemDates_StartDate.ComboBoxEx.DisplayMember = "Display"
            ComboBoxItemDates_StartDate.ComboBoxEx.ValueMember = "Value"
            ComboBoxItemDates_EndDate.ComboBoxEx.DisplayMember = "Display"
            ComboBoxItemDates_EndDate.ComboBoxEx.ValueMember = "Value"

            ButtonItemDisplay_ShowTotals.Checked = True

        End Sub
        Private Function HasNoErrors() As Boolean

            'objects
            Dim HasErrors As Boolean = False

            HasErrors = _ViewModel.DataTable.HasErrors

            If HasErrors Then

                AdvantageFramework.WinForm.MessageBox.Show("Please fix data entry errors before continuing.")

            End If

            HasNoErrors = Not HasErrors

        End Function
        Private Sub SaveGridLayout()

            'objects
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing
            Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing

            OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid

            OptionsLayoutGrid.Assign(DevExpress.Utils.OptionsLayoutBase.FullLayout)

            OptionsLayoutGrid.StoreAllOptions = True
            OptionsLayoutGrid.Columns.StoreAllOptions = True
            OptionsLayoutGrid.Columns.StoreLayout = True
            OptionsLayoutGrid.Columns.StoreAppearance = True
            OptionsLayoutGrid.Columns.AddNewColumns = True
            OptionsLayoutGrid.Columns.RemoveOldColumns = False
            OptionsLayoutGrid.StoreVisualOptions = True
            OptionsLayoutGrid.StoreAppearance = True

            'BandedDataGridViewForm_MarketDetails.CurrentView.AFActiveFilterString = Nothing
            'BandedDataGridViewForm_MarketDetails.CurrentView.FindFilterText = Nothing

            MemoryStreamLayout = New System.IO.MemoryStream

            BandedDataGridViewForm_MarketDetails.CurrentView.SaveLayoutToStream(MemoryStreamLayout, OptionsLayoutGrid)

            MemoryStreamLayout.Position = 0

            StreamReader = New System.IO.StreamReader(MemoryStreamLayout)

            _ViewModel.GridAdvantage.XmlLayout = StreamReader.ReadToEnd

        End Sub
        Private Function CreateCheckItem(Caption As String, GridColumn As DevExpress.XtraGrid.Columns.GridColumn, FixedStyle As DevExpress.XtraGrid.Columns.FixedStyle, Optional Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuCheckItem

            'objects
            Dim DXMenuCheckItem As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing

            If FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle.Left Then

                DXMenuCheckItem = New DevExpress.Utils.Menu.DXMenuCheckItem(Caption, BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Item(GridBandNames.GridBandData.ToString).Columns.Contains(GridColumn), Image, New EventHandler(AddressOf OnFixedClick))

            Else

                DXMenuCheckItem = New DevExpress.Utils.Menu.DXMenuCheckItem(Caption, BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Item(GridBandNames.GridBandOtherData.ToString).Columns.Contains(GridColumn), Image, New EventHandler(AddressOf OnFixedClick))

            End If

            DXMenuCheckItem.Tag = New AdvantageFramework.WinForm.Presentation.Controls.Classes.MenuInfo(GridColumn, FixedStyle)

            CreateCheckItem = DXMenuCheckItem

        End Function
        Protected Sub OnFixedClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim MenuInfo As AdvantageFramework.WinForm.Presentation.Controls.Classes.MenuInfo = Nothing
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            MenuInfo = DXMenuItem.Tag

            If MenuInfo IsNot Nothing Then

                If MenuInfo.FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle.Left Then

                    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Item(GridBandNames.GridBandData.ToString)

                    GridBand.Columns.Add(MenuInfo.GridColumn)

                Else

                    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands.Item(GridBandNames.GridBandOtherData.ToString)

                    GridBand.Columns.Insert(0, MenuInfo.GridColumn)

                End If

                MenuInfo.GridColumn.Fixed = MenuInfo.FixedStyle

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Protected Sub OnBestFitColumnClick(sender As Object, e As EventArgs)

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Protected Sub OnGroupBoxClick(sender As Object, e As EventArgs)

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.ShowHideGroupBox(BandedDataGridViewForm_MarketDetails.OptionsView.ShowGroupPanel)

            End If

        End Sub
        Private Function CreateCheckedButtonItem(Caption As String, RowIndex As Integer, EventHanlder As EventHandler, BeingGroup As Boolean, Checked As Boolean, Optional Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuItem

            'objects
            Dim DXMenuCheckItem As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing

            DXMenuCheckItem = New DevExpress.Utils.Menu.DXMenuCheckItem(Caption, Checked, Image, EventHanlder)

            DXMenuCheckItem.BeginGroup = BeingGroup

            DXMenuCheckItem.Tag = RowIndex

            CreateCheckedButtonItem = DXMenuCheckItem

        End Function
        Private Function CreateButtonItem(Caption As String, RowIndex As Integer, EventHanlder As EventHandler, BeingGroup As Boolean, Optional Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuItem

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(Caption, EventHanlder, Image)

            DXMenuItem.BeginGroup = BeingGroup

            DXMenuItem.Tag = RowIndex

            CreateButtonItem = DXMenuItem

        End Function
        Private Function CreateButtonItem(Caption As String, RowIndexes As Generic.List(Of Integer), EventHanlder As EventHandler, BeingGroup As Boolean, Optional Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuItem

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(Caption, EventHanlder, Image)

            DXMenuItem.BeginGroup = BeingGroup

            DXMenuItem.Tag = RowIndexes

            CreateButtonItem = DXMenuItem

        End Function
        Private Function CreateButtonItem(Caption As String, Tag As Object, EventHanlder As EventHandler, BeingGroup As Boolean, Optional Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuItem

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(Caption, EventHanlder, Image)

            DXMenuItem.BeginGroup = BeingGroup

            DXMenuItem.Tag = Tag

            CreateButtonItem = DXMenuItem

        End Function
        Protected Sub OnOverridePostCheckedChanged(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuCheckItem As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing
            Dim RowIndex As Integer = 0

            DXMenuCheckItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuCheckItem)

            RowIndex = DXMenuCheckItem.Tag

            _ViewModel.DataTable.Rows(RowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString) = DXMenuCheckItem.Checked

            BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Protected Sub OnOverridePostImpressionsCheckedChanged(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuCheckItem As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing
            Dim RowIndex As Integer = 0

            DXMenuCheckItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuCheckItem)

            RowIndex = DXMenuCheckItem.Tag

            _ViewModel.DataTable.Rows(RowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString) = DXMenuCheckItem.Checked

            BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Protected Sub OnOverridePostAQHCheckedChanged(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuCheckItem As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing
            Dim RowIndex As Integer = 0

            DXMenuCheckItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuCheckItem)

            RowIndex = DXMenuCheckItem.Tag

            _ViewModel.DataTable.Rows(RowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString) = DXMenuCheckItem.Checked

            BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Protected Sub OnAllocateClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndex As Integer = 0
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim MediaBroadcastWorksheetMarketDetailsAllocateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsAllocateViewModel = Nothing

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndex = DXMenuItem.Tag

            MediaBroadcastWorksheetMarketDetailsAllocateViewModel = _Controller.MarketDetailsAllocate_Load(_ViewModel)

            If MediaBroadcastWorksheetMarketDetailAllocateDialog.ShowFormDialog(MediaBroadcastWorksheetMarketDetailsAllocateViewModel, _ViewModel, RowIndex) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                BeginDataUpdate()

                _Controller.MarketDetailsAllocate_Allocate(MediaBroadcastWorksheetMarketDetailsAllocateViewModel, _ViewModel, RowIndex)

                EndDataUpdate()

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.RefreshData()

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Protected Sub OnMakegoodClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndex As Integer = 0

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndex = DXMenuItem.Tag

            Makegood(RowIndex)

        End Sub
        Protected Sub OnUndoRatingShareOverrideClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            UndoRatingShareOverride(RowIndexes)

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Protected Sub OnUndoProgramOverrideClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            UndoProgramOverride(RowIndexes)

            If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                DataRow = _ViewModel.DataTable.Rows(RowIndexes(0))

                If DataRow IsNot Nothing Then

                    _MeasurementTrendsForm.RefreshFormData(RowIndexes(0), DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                           DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                           DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), True)

                Else

                    _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, True)

                End If

            End If

        End Sub
        Protected Sub UndoRatingShareOverride(RowIndexes As Generic.List(Of Integer))

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            BeginDataUpdate()

            For Each RowIndex In RowIndexes

                _Controller.MarketDetails_UndoRaitingAndShareOverride(_ViewModel, RowIndex)

            Next

            'BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

            EndDataUpdate()

            If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                DataRow = _ViewModel.DataTable.Rows(RowIndexes(0))

                If DataRow IsNot Nothing Then

                    _MeasurementTrendsForm.RefreshFormData(RowIndexes(0), DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                           DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                           DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), True)

                Else

                    _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, True)

                End If

            End If

        End Sub
        Protected Sub UndoProgramOverride(RowIndexes As Generic.List(Of Integer))

            For Each RowIndex In RowIndexes

                _Controller.MarketDetails_UndoProgramOverride(_ViewModel, RowIndex)

            Next

            'BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Protected Sub OnBestFitAllDateColumns(sender As Object, e As EventArgs)

            If _ViewModel.DataTable.Rows.Count = 0 Then

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).Width = 75

                Next

            Else

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).BestFit()

                Next

            End If

        End Sub
        Protected Sub OnCopyToAnotherVendorClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim CopyFromVendorCode As String = String.Empty
            Dim MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherVendorViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherVendorViewModel = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            CopyFromVendorCode = _ViewModel.DataTable.Rows(RowIndexes(0))(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherVendorViewModel = _Controller.MarketVendorScheduleCopyToAnotherVendor_Load(_ViewModel, CopyFromVendorCode, RowIndexes)

            If MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherVendorDialog.ShowFormDialog(MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherVendorViewModel, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                BeginDataUpdate()

                _Controller.MarketVendorScheduleCopyToAnotherVendor_CopyTo(MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherVendorViewModel, _ViewModel)

                EndDataUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Protected Sub OnCopyToAnotherMarketClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim CopyFromVendorCode As String = String.Empty
            Dim MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherMarketViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherMarketViewModel = Nothing
            Dim LockedMarketsMessage As String = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            CopyFromVendorCode = _ViewModel.DataTable.Rows(RowIndexes(0))(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherMarketViewModel = _Controller.MarketVendorScheduleCopyToAnotherMarket_Load(_ViewModel, CopyFromVendorCode, RowIndexes)

            If MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherMarketDialog.ShowFormDialog(MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherMarketViewModel, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                If Not _Controller.MarketVendorScheduleCopyToAnotherMarket_CopyTo(MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherMarketViewModel, _ViewModel, LockedMarketsMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Could not copy to the following markets:" & vbCrLf & LockedMarketsMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Protected Sub OnCopyToAnotherWorksheetMarketScheduleClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim CopyFromVendorCode As String = String.Empty
            Dim MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel = Nothing
            Dim LockedMarketsMessage As String = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            CopyFromVendorCode = _ViewModel.DataTable.Rows(RowIndexes(0))(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel = _Controller.MarketVendorScheduleCopyToAnotherWorksheetMarketSchedule_Load(_ViewModel, RowIndexes)

            If MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog.ShowFormDialog(MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                If Not _Controller.MarketVendorScheduleCopyToAnotherWorksheetMarketSchedule_CopyTo(MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel, _ViewModel, LockedMarketsMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Could not copy to the following markets:" & vbCrLf & LockedMarketsMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Protected Sub OnCopyDateClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim CopyFromDateColumnName As String = String.Empty
            Dim MediaBroadcastWorksheetMarketDetailsCopyDateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsCopyDateViewModel = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            GridColumn = DXMenuItem.Tag

            CopyFromDateColumnName = GridColumn.FieldName

            MediaBroadcastWorksheetMarketDetailsCopyDateViewModel = _Controller.MarketDetailsCopyDate_Load(_ViewModel, CopyFromDateColumnName)

            If MediaBroadcastWorksheetMarketDetailCopyDateDialog.ShowFormDialog(MediaBroadcastWorksheetMarketDetailsCopyDateViewModel, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                BeginDataUpdate()

                _Controller.MarketDetailsCopyDate_CopyTo(MediaBroadcastWorksheetMarketDetailsCopyDateViewModel, _ViewModel)

                EndDataUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Protected Sub OnDateAccessClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndex As Integer = 0
            Dim DataTableID As Integer = 0
            Dim RowHasBeenModified As Boolean = False

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndex = DXMenuItem.Tag

            DataTableID = _ViewModel.DataTable.Rows(RowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)

            If MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog.ShowFormDialog(DataTableID, _ViewModel, RowHasBeenModified) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                If RowHasBeenModified Then

                    _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                End If

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                _Controller.MarketDetails_RefreshColumnTotalsDataTable(_ViewModel, RowIndex)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Protected Sub OnDateAccessAllowAllDatesClick(sender As Object, e As EventArgs)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim ContinueProcess As Boolean = True
            Dim AreAllAccessibleDatesHaveTheSameRates As Boolean = True
            Dim Rate As Decimal = -1
            Dim DefaultRate As Decimal = 0
            Dim AtLeastOneRowWithDifferentRates As Boolean = False

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            If RowIndexes.Count > 1 Then

                If AdvantageFramework.WinForm.MessageBox.Show(String.Format("WARNING: {0} lines will be unblocked.  Do you want to continue?", RowIndexes.Count), WinForm.MessageBox.MessageBoxButtons.OKCancel) = WinForm.MessageBox.DialogResults.OK Then

                    ContinueProcess = True

                Else

                    ContinueProcess = False

                End If

            End If

            If ContinueProcess Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                For Each RowIndex In RowIndexes

                    DataRow = _ViewModel.DataTable.Rows(RowIndex)

                    'AreAllAccessibleDatesHaveTheSameRates = True
                    'Rate = -1
                    'DefaultRate = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString)

                    'For Each RateDate In _ViewModel.RateDates.Keys.OfType(Of Date)

                    '    If DataRow(_ViewModel.AllowSpotsToBeEnteredDates.Item(RateDate)) = True Then

                    '        If Rate = -1 Then

                    '            Rate = DataRow(_ViewModel.RateDates.Item(RateDate))

                    '        Else

                    '            If Rate <> DataRow(_ViewModel.RateDates.Item(RateDate)) Then

                    '                AreAllAccessibleDatesHaveTheSameRates = False
                    '                Exit For

                    '            End If

                    '        End If

                    '    End If

                    'Next

                    'If AreAllAccessibleDatesHaveTheSameRates = False Then

                    '    AtLeastOneRowWithDifferentRates = True

                    'End If

                    For Each AllowSpotsToBeEnteredDate In _ViewModel.AllowSpotsToBeEnteredDates.Keys.OfType(Of Date)

                        'If DataRow(_ViewModel.AllowSpotsToBeEnteredDates.Item(AllowSpotsToBeEnteredDate)) = False Then

                        '    If AreAllAccessibleDatesHaveTheSameRates Then

                        '        DataRow(_ViewModel.RateDates.Item(AllowSpotsToBeEnteredDate)) = Rate

                        '    Else

                        '        DataRow(_ViewModel.RateDates.Item(AllowSpotsToBeEnteredDate)) = DefaultRate

                        '    End If

                        'End If

                        DataRow(_ViewModel.AllowSpotsToBeEnteredDates.Item(AllowSpotsToBeEnteredDate)) = True

                    Next

                    '_Controller.MarketDetails_DefaultRateChanged(_ViewModel, RowIndex)
                    '_Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                Next

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                'If AtLeastOneRowWithDifferentRates Then

                '    If RowIndexes.Count = 1 Then

                '        AdvantageFramework.WinForm.MessageBox.Show(“There are a variety of rates on this row; the default rate has been assigned to newly opened dates.  Press OK to acknowledge.”)

                '    Else

                '        AdvantageFramework.WinForm.MessageBox.Show(“There are a variety of rates on one or more rows; the default rate has been assigned to newly opened dates.  Press OK to acknowledge.”)

                '    End If

                'End If

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Protected Sub OnAdjustRatesClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndex As Integer = 0
            Dim DataTableID As Integer = 0

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndex = DXMenuItem.Tag

            DataTableID = _ViewModel.DataTable.Rows(RowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)

            If MediaBroadcastWorksheetMarketDetailRateDialog.ShowFormDialog(DataTableID, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                _Controller.MarketDetails_DefaultRateChanged(_ViewModel, RowIndex)

                '_Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Protected Sub OnAdjustRateClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndex As Integer = 0
            Dim Title As String = String.Empty
            Dim CurrentRate As Decimal = 0
            Dim Rate As Decimal = 0

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndex = DXMenuItem.Tag

            Title = BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.ToString
            CurrentRate = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, BandedDataGridViewForm_MarketDetails.Columns(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName.Replace("Date", "Rate")))
            Rate = CurrentRate

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog(Title, "Rate:", CurrentRate, Rate,
                                                                                         Nothing, AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency,
                                                                                         True, 0, 999999.99, "$###,##0.00", 9) = System.Windows.Forms.DialogResult.OK Then

                BandedDataGridViewForm_MarketDetails.CurrentView.SetFocusedRowCellValue(BandedDataGridViewForm_MarketDetails.Columns(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName.Replace("Date", "Rate")), Rate)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Protected Sub OnCheckOnHoldClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            SetOnHold(RowIndexes, True)

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Protected Sub OnUncheckOnHoldClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            SetOnHold(RowIndexes, False)

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Protected Sub OnGenerateOrdersClick(sender As Object, e As EventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing

            DXMenuItem = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem)

            RowIndexes = DXMenuItem.Tag

            ShowMediaManagerReviewDialog(RowIndexes)

        End Sub
        Protected Sub SetOnHold(RowIndexes As Generic.List(Of Integer), Checked As Boolean)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            BeginDataUpdate()

            For Each RowIndex In RowIndexes

                If _ViewModel.DataTable.Rows(RowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString) = CInt(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered) Then

                    _ViewModel.DataTable.Rows(RowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString) = Checked

                End If

            Next

            BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            EndDataUpdate()

            _Controller.MarketDetails_OnHoldValueChanged(_ViewModel)

            _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

            If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                DataRow = _ViewModel.DataTable.Rows(RowIndexes(0))

                If DataRow IsNot Nothing Then

                    _MeasurementTrendsForm.RefreshFormData(RowIndexes(0), DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                           DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                           DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), True)

                Else

                    _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, True)

                End If

            End If

        End Sub
        Protected Sub SubItemGridLookUpEditControl_QueryPopup(sender As Object, e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim CableNetworkStations As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation) = Nothing
            Dim CableNetworkStation As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation = Nothing

            If TypeOf BandedDataGridViewForm_MarketDetails.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = BandedDataGridViewForm_MarketDetails.CurrentView.ActiveEditor

                CableNetworkStations = _ViewModel.CableNetworkStations.Where(Function(Entity) Entity.IsInactive = False).ToList

                If CableNetworkStations.Any(Function(Entity) Entity.Code = GridLookUpEdit.EditValue) = False Then

                    CableNetworkStation = _ViewModel.CableNetworkStations.SingleOrDefault(Function(Entity) Entity.Code = GridLookUpEdit.EditValue)

                    If CableNetworkStation IsNot Nothing Then

                        CableNetworkStations.Add(CableNetworkStation)

                    End If

                End If

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = CableNetworkStations.OrderBy(Function(Entity) Entity.Description).Select(Function(Entity) New With {.Code = Entity.Code, .Description = Entity.Description}).ToList

                GridLookUpEdit.Properties.DataSource = BindingSource

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Description", "Code", "[None]", String.Empty, True, False, Nothing)

            End If

        End Sub
        Private Sub GridBandVisibleChanged(GridBandName As GridBandNames, IsVisible As Boolean, Optional VisibleIndex As Integer = -1)

            'objects
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandName.ToString)

            If GridBand IsNot Nothing Then

                GridBand.Visible = IsVisible

                If VisibleIndex > -1 Then

                    GridBand.VisibleIndex = VisibleIndex

                End If

            End If

            BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

        End Sub
        Private Sub UpdateDateColumns()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString)

            'BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

            For Each GridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ToList

                'Console.WriteLine(GridColumn.FieldName & " - " & If(GridColumn.CustomizationSearchCaption <> String.Empty, GridColumn.CustomizationSearchCaption, GridColumn.Caption))

                If _ViewModel.DetailDates.ContainsValue(GridColumn.FieldName) Then

                    If GridColumn.Visible = False AndAlso _ViewModel.DataTable.Columns.Contains(GridColumn.FieldName) Then

                        GridBand.Columns.Add(GridColumn)

                        GridColumn.Visible = True

                        If GridColumn.ColVIndex < 0 Then

                            GridColumn.ColVIndex = GridBand.Columns.VisibleColumnCount - 2

                        End If

                        If BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.Any(Function(GS) GS.FieldName = GridColumn.FieldName) = False Then

                            GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                            GridGroupSummaryItem.FieldName = GridColumn.FieldName
                            GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                            GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn
                            GridGroupSummaryItem.DisplayFormat = "{0:f0}"

                            BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

                        Else

                            GridGroupSummaryItem = BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.FirstOrDefault(Function(GS) GS.FieldName = GridColumn.FieldName)

                            GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                            GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn
                            GridGroupSummaryItem.DisplayFormat = "{0:f0}"

                        End If

                        GridColumn.Summary.Clear()

                        AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                        AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings)
                        AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions)
                        AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars)
                        AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings)
                        AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars)
                        AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings)
                        AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars)
                        AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent)
                        AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent)

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "f0"
                        GridColumn.OptionsColumn.AllowMove = False
                        GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False
                        GridColumn.OptionsColumn.ShowInExpressionEditor = False
                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsFilter.AllowFilter = False

                        If _ViewModel.HiatusDataTable.Rows.Count > 0 Then

                            GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName)

                        End If

                    ElseIf GridColumn.Visible AndAlso _ViewModel.DataTable.Columns.Contains(GridColumn.FieldName) Then

                        If BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.Any(Function(GS) GS.FieldName = GridColumn.FieldName) = False Then

                            GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                            GridGroupSummaryItem.FieldName = GridColumn.FieldName
                            GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                            GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn
                            GridGroupSummaryItem.DisplayFormat = "{0:f0}"

                            BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

                        Else

                            GridGroupSummaryItem = BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.FirstOrDefault(Function(GS) GS.FieldName = GridColumn.FieldName)

                            GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                            GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn
                            GridGroupSummaryItem.DisplayFormat = "{0:f0}"

                        End If

                        GridColumn.Summary.Clear()

                        AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

                        AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings)
                        AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions)
                        AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars)
                        AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings)
                        AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars)
                        AddSummaryItemToColumn(GridColumn, "{0:f2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings)
                        AddSummaryItemToColumn(GridColumn, "{0:c2}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars)
                        AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent)
                        AddSummaryItemToColumn(GridColumn, "{0:p0}", DevExpress.Data.SummaryItemType.Custom, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent)

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "f0"
                        GridColumn.OptionsColumn.AllowMove = False
                        GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False
                        GridColumn.OptionsColumn.ShowInExpressionEditor = False
                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsFilter.AllowFilter = False

                        If _ViewModel.HiatusDataTable.Rows.Count > 0 Then

                            GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName)

                        End If

                    ElseIf _ViewModel.DataTable.Columns.Contains(GridColumn.FieldName) = False Then

                        GridBand.Columns.Remove(GridColumn)

                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

                    End If

                ElseIf GridColumn.FieldName.StartsWith("Rate") AndAlso
                        _ViewModel.RateDates.ContainsValue(GridColumn.FieldName) = False Then

                    GridBand.Columns.Remove(GridColumn)

                    BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

                ElseIf GridColumn.FieldName.StartsWith("Date") Then

                    GridBand.Columns.Remove(GridColumn)

                    BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

                ElseIf GridColumn.FieldName.StartsWith("Entered") AndAlso
                        _ViewModel.AllowSpotsToBeEnteredDates.ContainsValue(GridColumn.FieldName) = False Then

                    GridBand.Columns.Remove(GridColumn)

                    BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

                ElseIf GridColumn.FieldName <> "OrderStatus" AndAlso GridColumn.FieldName.StartsWith("OrderStatus") AndAlso
                        _ViewModel.OrderStatusDates.ContainsValue(GridColumn.FieldName) = False Then

                    GridBand.Columns.Remove(GridColumn)

                    BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(GridColumn)

                End If

            Next

            For Each RateDate In _ViewModel.RateDates.Keys.OfType(Of Date).OrderBy(Function(RD) RD)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(RateDate).ToString)

                GridColumn.Caption = "Rate"

                If GridBand.Columns.Contains(GridColumn) = False Then

                    'GridBand.Columns.Insert(GridBand.Columns.IndexOf(BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(RateDate).ToString)) + 1, GridColumn)
                    GridBand.Columns.Add(GridColumn)

                End If

                GridBand.Columns.MoveTo(GridBand.Columns.IndexOf(BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(RateDate).ToString)) + 1, GridColumn)

                GridColumn.ColVIndex = CType(BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(RateDate).ToString), DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ColVIndex + 1

                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridColumn.DisplayFormat.FormatString = "c2"
                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False
                GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName.Replace("Rate", "Date"))
                GridColumn.Visible = False

            Next

            For Each AllowSpotsToBeEnteredDate In _ViewModel.AllowSpotsToBeEnteredDates.Keys.OfType(Of Date).OrderBy(Function(ASTBED) ASTBED)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.AllowSpotsToBeEnteredDates(AllowSpotsToBeEnteredDate).ToString)

                'Console.WriteLine(GridColumn.FieldName & " - " & If(GridColumn.CustomizationSearchCaption <> String.Empty, GridColumn.CustomizationSearchCaption, GridColumn.Caption))

                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False

            Next

            For Each OrderStatusDate In _ViewModel.OrderStatusDates.Keys.OfType(Of Date).OrderBy(Function(OSD) OSD)

                GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.OrderStatusDates(OrderStatusDate).ToString)

                'Console.WriteLine(GridColumn.FieldName & " - " & If(GridColumn.CustomizationSearchCaption <> String.Empty, GridColumn.CustomizationSearchCaption, GridColumn.Caption))

                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False

            Next

            BandedDataGridViewForm_MarketDetails.CurrentView.Columns("TotalSpots").ColVIndex = GridBand.Columns.VisibleColumnCount
            BandedDataGridViewForm_MarketDetails.CurrentView.Columns("TotalDollars").ColVIndex = GridBand.Columns.VisibleColumnCount

            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns("TotalNet").Visible Then

                BandedDataGridViewForm_MarketDetails.CurrentView.Columns("TotalNet").ColVIndex = GridBand.Columns.VisibleColumnCount

            Else

                BandedDataGridViewForm_MarketDetails.CurrentView.Columns("TotalNet").ColVIndex = GridBand.Columns.VisibleColumnCount

                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible("TotalNet")

            End If

            'BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

        End Sub
        Private Sub RefreshDateAndRateColumns()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString)

            If _ViewModel.HiatusDataTable.Rows.Count > 0 Then

                For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ToList

                    If _ViewModel.DetailDates.ContainsValue(GridColumn.FieldName) Then

                        GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName)

                    ElseIf _ViewModel.RateDates.ContainsValue(GridColumn.FieldName) Then

                        GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName.Replace("Rate", "Date"))

                    End If

                Next

            End If

        End Sub
        Private Sub BestFitColumnsInitalLoad()

            BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandData.ToString).Width = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandData.ToString).MinWidth
            BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString).Width = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString).MinWidth
            BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimaryDemo.ToString).Width = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimaryDemo.ToString).MinWidth
            BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondaryDemo.ToString).Width = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondaryDemo.ToString).MinWidth

            If BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString).Width = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString).MinWidth

            End If

            If BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString) IsNot Nothing Then

                BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString).Width = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString).MinWidth

            End If

            BandedDataGridViewForm_MarketDetails.OptionsView.BestFitMaxRowCount = -1
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowChangeColumnParent = False
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.ShowBandsInCustomizationForm = False
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowBandMoving = True
            BandedDataGridViewForm_MarketDetails.CurrentView.OptionsCustomization.AllowChangeBandParent = False

            'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

        End Sub
        Private Sub RefreshMediaBroadcastWorksheetSetupForm()

            Try

                For Each MdiChild In Me.ParentForm.MdiChildren

                    If TypeOf MdiChild Is Media.Presentation.MediaBroadcastWorksheetSetupForm Then

                        DirectCast(MdiChild, Media.Presentation.MediaBroadcastWorksheetSetupForm).RefreshForm()
                        Exit For

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub
        Private Sub AddGroupSummaryItemToColumn(GridColumn As DevExpress.XtraGrid.Columns.GridColumn, DisplayFormat As String, SummaryType As DevExpress.Data.SummaryItemType)

            'objects
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

            GridGroupSummaryItem.FieldName = GridColumn.FieldName
            GridGroupSummaryItem.SummaryType = SummaryType
            GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn
            GridGroupSummaryItem.DisplayFormat = DisplayFormat

            BandedDataGridViewForm_MarketDetails.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

        End Sub
        Private Sub AddSummaryItemToColumn(GridColumn As DevExpress.XtraGrid.Columns.GridColumn, DisplayFormat As String, SummaryType As DevExpress.Data.SummaryItemType, Tag As Object)

            'objects
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(SummaryType)

            GridColumnSummaryItem.FieldName = GridColumn.FieldName
            GridColumnSummaryItem.DisplayFormat = DisplayFormat
            GridColumnSummaryItem.Tag = Tag

            GridColumn.Summary.Add(GridColumnSummaryItem)

        End Sub
        Private Function GetRectangleForRow(DateColumn As String, TotalIndex As Integer, Bounds As System.Drawing.Rectangle, FontHeight As Integer) As System.Drawing.Rectangle

            'objects
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim GridColumnRectangle As System.Drawing.Rectangle = Nothing
            Dim HorizontalIndent As Integer = 0
            Dim VerticalIndent As Integer = Bounds.Height / 10
            Dim GridViewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = Nothing

            GridViewInfo = BandedDataGridViewForm_MarketDetails.CurrentView.GetViewInfo()

            If GridViewInfo.ColumnsInfo(BandedDataGridViewForm_MarketDetails.Columns(DateColumn)) IsNot Nothing Then

                GridColumnRectangle = GridViewInfo.ColumnsInfo(BandedDataGridViewForm_MarketDetails.Columns(DateColumn)).Bounds

                HorizontalIndent = GridColumnRectangle.Left - 125

                Rectangle = New System.Drawing.Rectangle(Bounds.Left + HorizontalIndent, Bounds.Top + VerticalIndent * TotalIndex + (VerticalIndent - FontHeight) / 2, HorizontalIndent, GridColumnRectangle.Height)

            End If

            GetRectangleForRow = Rectangle

        End Function
        Private Sub RepositoryItemDefaultRate_EditValueChanged(sender As Object, e As EventArgs)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

            RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

            _Controller.MarketDetails_DefaultRateChanging(_ViewModel, RowIndex, CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue, CType(sender, DevExpress.XtraEditors.SpinEdit).OldEditValue)

        End Sub
        Private Sub RepositoryItemDateValue_EditValueChanged(sender As Object, e As EventArgs)

            'objects
            Dim WarnUser As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

            RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

            _Controller.MarketDetails_MarketDetailDateValueChanging(_ViewModel, RowIndex, BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName,
                                                                    BandedDataGridViewForm_MarketDetails.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString),
                                                                    CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue, WarnUser)

            If WarnUser Then

                AdvantageFramework.WinForm.MessageBox.Show("WARNING: Bookends must be an even number of spots.")

                CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue = CType(sender, DevExpress.XtraEditors.SpinEdit).OldEditValue

            End If

        End Sub
        Private Sub RepositoryItemBookend_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            'objects
            Dim WarnUser As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

            RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

            _Controller.MarketDetails_BookendValueChanging(_ViewModel, RowIndex, e.NewValue, WarnUser)

            If WarnUser Then

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Bookends must be an even number of spots. Some or all spots allocated are an odd number and will be cleared." & vbNewLine & vbNewLine & "Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    _Controller.MarketDetails_ClearMarketDetailDateValues(_ViewModel, RowIndex)

                    BandedDataGridViewForm_MarketDetails.CurrentView.SetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString, e.NewValue)

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()

                Else

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub RepositoryItemCheckEdit_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)

            'objects
            Dim CheckEdit As DevExpress.XtraEditors.CheckEdit = Nothing
            Dim CheckEditViewInfo As DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo = Nothing
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim EditorRectangle As System.Drawing.Rectangle = Nothing

            CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
            CheckEditViewInfo = CType(CheckEdit.GetViewInfo(), DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)
            Rectangle = CheckEditViewInfo.CheckInfo.GlyphRect

            EditorRectangle = New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), CheckEdit.Size)

            If (Not Rectangle.Contains(e.Location)) AndAlso EditorRectangle.Contains(e.Location) Then

                CType(e, DevExpress.Utils.DXMouseEventArgs).Handled = True

            End If

        End Sub
        Private Sub RepositoryItemRating_EditValueChanged(sender As Object, e As EventArgs)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1
            Dim IsPrimary As Boolean = False

            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

            RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

            IsPrimary = BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName.Contains("Primary")

            If _Controller.MarketDetails_CheckShareValueAfterRatingChange(_ViewModel, CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue, RowIndex, IsPrimary) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("A rating override that recalculates Share over 100 cannot be allowed.")

                CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue = CType(sender, DevExpress.XtraEditors.SpinEdit).OldEditValue

            End If

        End Sub
        Private Sub RepositoryItemImpressions_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs)

            If _ParsingImpressionsValue = False Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.ActiveEditor Is sender Then

                    e.Value = CInt(Math.Round(e.Value * 1000, 0))

                    _ParsingImpressionsValue = True

                Else

                    e.Value = Math.Round(e.Value / 1000, 1)

                End If

                e.Handled = True

            Else

                _ParsingImpressionsValue = False

            End If

            'If _ViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    If CInt(e.Value) = e.Value Then

            '        e.Value = Math.Round(e.Value / 1000, 1)

            '    Else

            '        e.Value = CInt(Math.Round(e.Value * 1000, 0))

            '    End If

            '    e.Handled = True

            'ElseIf _ViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then



            'End If

        End Sub
        Private Function CreateOrders(MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel,
                                      RowIndexes As Generic.List(Of Integer), BypassDialog As Boolean, IsMakegood As Boolean) As Boolean

            'objects
            Dim OrdersCreated As Boolean = False
            Dim ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim CancelledImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim OrderLines As Generic.List(Of AdvantageFramework.Controller.Media.MakegoodDeliveryController.OrderLine) = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim OrderNumber As Integer = 0
            Dim OrderLineNumbers As IEnumerable(Of Integer) = Nothing

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            ImportOrders = _Controller.MarketDetails_CreateImportOrderList(_ViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel, _ViewModel.SelectedWorksheetMarketRevisionNumber, RowIndexes)

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            If ImportOrders.Count > 0 Then

                If BypassDialog Then

                    CancelledImportOrders = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

                    If AdvantageFramework.Importing.SaveOrders(Session, ImportOrders, False, False, False, "", False, IsMakegood, CancelledImportOrders, Nothing, Nothing, ErrorMessage) Then

                        _Controller.MarketDetails_UpdateDetailDatesOrderStatus(_ViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel, _ViewModel.SelectedWorksheetMarketRevisionNumber, RowIndexes)
                        _Controller.MarketDetails_SaveCreateOrderOptionsAfterCreatingOrders(_ViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel.CreateOrdersByWeek)

                        OrdersCreated = True

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Problem creating orders: " & ErrorMessage)

                    End If

                ElseIf AdvantageFramework.Importing.Presentation.ImportCreateOrderDialog.ShowFormDialog(ImportOrders, AdvantageFramework.MediaPlanning.CreateOrderOptions.Default, False) = Windows.Forms.DialogResult.OK Then

                    _Controller.MarketDetails_UpdateDetailDatesOrderStatus(_ViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel, _ViewModel.SelectedWorksheetMarketRevisionNumber, RowIndexes)
                    _Controller.MarketDetails_SaveCreateOrderOptionsAfterCreatingOrders(_ViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel.CreateOrdersByWeek)

                    OrdersCreated = True

                End If

            ElseIf Not BypassDialog Then

                AdvantageFramework.WinForm.MessageBox.Show("No Orders to create.")

            End If

            If IsMakegood AndAlso OrdersCreated Then

                OrderNumber = ImportOrders.Where(Function(IO) IO.OrderNumber.HasValue).Select(Function(IO) IO.OrderNumber.Value).First

                OrderLineNumbers = _Controller.MarketDetails_GetOrderLineNumbersByOrderNumber(OrderNumber, _ViewModel.WorksheetLineNumbersAccepted)

                AdvantageFramework.MediaManager.AddUpdateOrderStatus(_ViewModel.MakegoodMediaType, _ViewModel.MakegoodOrderNumber, Me.Session.ConnectionString, Me.Session.UserCode, Me.Session.EmployeeName,
                                                                     Database.Entities.OrderStatusType.MakegoodOfferAccepted, OrderLineNumbers)

                _Controller.MarketDetails_MakegoodOfferAccepted(_ViewModel, OrderLineNumbers)

                OrderLines = (From OrderLineNumber In OrderLineNumbers
                              Select New AdvantageFramework.Controller.Media.MakegoodDeliveryController.OrderLine(OrderNumber, OrderLineNumber, _ViewModel.MakegoodMediaType)).Distinct.ToList

                If OrderLines IsNot Nothing AndAlso OrderLines.Count > 0 Then

                    MakegoodDeliveryController = New Controller.Media.MakegoodDeliveryController(Me.Session)

                    MakegoodDeliveryController.AcceptOrderForVendorRep(OrderLines, Session.User.EmployeeCode)

                End If

            ElseIf OrdersCreated Then

                OrderLines = _Controller.MarketDetails_GetOrderLineNumbers(_ViewModel)

                If OrderLines IsNot Nothing AndAlso OrderLines.Count > 0 Then

                    MakegoodDeliveryController = New Controller.Media.MakegoodDeliveryController(Me.Session)

                    MakegoodDeliveryController.AcceptOrderForVendorRep(OrderLines, Session.User.EmployeeCode)

                End If

            End If

            CreateOrders = OrdersCreated

        End Function
        Private Sub CloseGridEditorAndSaveValueToDataSource()

            If BandedDataGridViewForm_MarketDetails.CurrentView.PostEditor() Then

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateCurrentRow()

            End If

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.CloseGridEditorAndSaveValueToDataSource()

            End If

        End Sub
        Private Sub UpdateWorksheetSetupFormWorksheetPrintOptions()

            Try

                For Each MdiChild In Me.ParentForm.MdiChildren

                    If TypeOf MdiChild Is AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetSetupForm Then

                        DirectCast(MdiChild, AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetSetupForm).UpdateWorksheetPrintOptions(_ViewModel.WorksheetPrintOptions)
                        Exit For

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub
        Public Sub TotalsFormHiding()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            ButtonItemDisplay_Summaries.Checked = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Public Sub SubmarketsFormHiding()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            ButtonItemSubmarkets_Show.Checked = False

            'ButtonItemSubmarkets_Ratings.Enabled = ButtonItemSubmarkets_Show.Checked
            'ButtonItemSubmarkets_GRP.Enabled = ButtonItemSubmarkets_Show.Checked
            'ButtonItemSubmarkets_IMP.Enabled = ButtonItemSubmarkets_Show.Checked
            'ButtonItemSubmarkets_GIMP.Enabled = ButtonItemSubmarkets_Show.Checked
            'ButtonItemSubmarkets_Allocation.Enabled = ButtonItemSubmarkets_Show.Checked
            'ButtonItemSubmarkets_Percentage.Enabled = ButtonItemSubmarkets_Show.Checked

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Public Sub SelectedRowChanged(SelectedRows() As Integer)

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

        End Sub
        Public Sub MeasurementTrendsMoveToNextLine(MoveUp As Boolean)

            If MoveUp Then

                BandedDataGridViewForm_MarketDetails.CurrentView.ForceMovePrev()

            Else

                BandedDataGridViewForm_MarketDetails.CurrentView.ForceMoveNext()

            End If

        End Sub
        Public Sub MeasurementTrendsFormHiding()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            ButtonItemResearch_Trends.Checked = False
            ButtonItemResearch_Trends2.Checked = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Public Sub MeasurementTrendsUndoRatingShareOverride(RowIndex As Integer)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            UndoRatingShareOverride(New Generic.List(Of Integer)({RowIndex}))

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            _MeasurementTrendsForm.RefreshGrid(True)

        End Sub
        Public Sub MeasurementTrendsUndoProgramOverride(RowIndex As Integer)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            UndoProgramOverride(New Generic.List(Of Integer)({RowIndex}))

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            _MeasurementTrendsForm.RefreshGrid(True)

        End Sub
        Public Sub MeasurementTrendsRatingChanged(Rating As Decimal)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MarketDetails.CurrentView.SetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString, Rating)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MarketDetails.CurrentView.SetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString, Rating)

            End If

            _MeasurementTrendsForm.RefreshGrid(True)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Public Sub MeasurementTrendsShareChanged(Share As Decimal)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            BandedDataGridViewForm_MarketDetails.CurrentView.SetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString, Share)

            _MeasurementTrendsForm.RefreshGrid(True)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Public Sub MeasurementTrendsAQHChanged(AQH As Long)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            BandedDataGridViewForm_MarketDetails.CurrentView.SetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString, AQH)

            _MeasurementTrendsForm.RefreshGrid(True)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Public Sub MeasurementTrendsImpressionsChanged(Impressions As Long)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            BandedDataGridViewForm_MarketDetails.CurrentView.SetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString, Impressions)

            _MeasurementTrendsForm.RefreshGrid(True)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        'Public Sub OpenGoals()

        '    ButtonItemActions_Goals.RaiseClick(DevComponents.DotNetBar.eEventSource.Code)

        'End Sub
        'Public Sub OpenManageMarkets()

        '    ButtonItemMarkets_Manage.RaiseClick(DevComponents.DotNetBar.eEventSource.Code)

        'End Sub
        Public Sub UpdateWorksheetPrintOptions(WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions)

            _ViewModel.WorksheetPrintOptions = WorksheetPrintOptions

        End Sub
        Public Sub SubmarketDemosChanged()

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

        End Sub
        Private Sub RefreshVendorStatus()

            _Controller.MarketDetails_RefreshMakegoodStatus(_ViewModel)

            BandedDataGridViewForm_MarketDetails.CurrentView.GridViewSelectionChanged()

            BandedDataGridViewForm_MarketDetails.Refresh()

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
        Private Sub ContinueToCreateOrders(MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel,
                                           BypassDialog As Boolean, IsMakegood As Boolean, VendorCode As String, WorksheetLineNumbers As IEnumerable(Of Integer))

            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            'Dim WorksheetLineNumbers As IEnumerable(Of Integer) = Nothing

            '===================
            RowIndexes = New Generic.List(Of Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                'If IsMakegood Then

                '    WorksheetLineNumbers = _Controller.MarketDetails_GetWorksheetLineNumbersByOrderNumber(MediaBroadcastWorksheetMarketCreateOrdersViewModel.MediaBroadcastWorksheetMarketID, VendorCode, MediaBroadcastWorksheetMarketCreateOrdersViewModel.Worksheet.MediaType)

                'End If

                For Each DataRow In _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).ToList

                    If VendorCode IsNot Nothing AndAlso DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = VendorCode Then

                        If IsMakegood Then

                            If WorksheetLineNumbers.Contains(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString)) Then

                                RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            End If

                        Else

                            RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                        End If

                    ElseIf VendorCode Is Nothing Then

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    End If

                Next

            End Using

            CreateOrders(MediaBroadcastWorksheetMarketCreateOrdersViewModel, RowIndexes, BypassDialog, IsMakegood)

            '===================
            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

            RefreshMediaBroadcastWorksheetSetupForm()

            BeginDataUpdate()

            _Controller.MarketDetails_RefreshWorksheetMarkets(_ViewModel)

            _Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

            LoadGrid()

            Me.ClearChanged()

            RefreshViewModel(False)

            ExpandAllGroups()

            EndDataUpdate()

            BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

            RefreshVendorStatus()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Me.RaiseClearChanged()

            BandedDataGridViewForm_MarketDetails.GridViewSelectionChanged()

        End Sub
        Private Sub ValidateRow(DataRow As System.Data.DataRow)

            'objects
            Dim RowIndex As Integer = -1

            RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

            _Controller.MarketDetails_SetDays(_ViewModel, RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString), True, False)

            If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString) IsNot DBNull.Value AndAlso
                        String.IsNullOrWhiteSpace(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString)) = False Then

                _Controller.MarketDetails_SetStartTime(_ViewModel, RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString), True, False)

            End If

            If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString) IsNot DBNull.Value AndAlso
                        String.IsNullOrWhiteSpace(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString)) = False Then

                _Controller.MarketDetails_SetEndTime(_ViewModel, RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString), True, False)

            End If

        End Sub
        Private Sub CacheComscoreData()

            'Dim CacheBooksAsyncCaller As CacheBooksAsyncCaller = Nothing
            'Dim AsyncResult As System.IAsyncResult = Nothing
            'Dim AsyncTask As System.Threading.Tasks.Task(Of Boolean) = Nothing
            Dim Task As System.Threading.Tasks.Task = Nothing

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading, "Retrieving Comscore books...")

            Task = System.Threading.Tasks.Task.Factory.StartNew(Sub()

                                                                    _Controller.MarketDetails_CacheBooks(_ViewModel)

                                                                End Sub)


            Do While Task.IsCompleted = False

                System.Threading.Thread.Sleep(1000)
                System.Windows.Forms.Application.DoEvents()

            Loop

            'CacheBooksAsyncCaller = New CacheBooksAsyncCaller(AddressOf _Controller.MarketDetails_CacheBooksAsync)

            'AsyncResult = CacheBooksAsyncCaller.BeginInvoke(_ViewModel, New AsyncCallback(AddressOf CallbackMethod), "")

            'While AsyncResult.IsCompleted = False

            '    System.Threading.Thread.Sleep(1000)

            'End While

            'If (_Task IsNot Nothing AndAlso _Task.Status <> Threading.Tasks.TaskStatus.Running) OrElse _Task Is Nothing Then

            '    'ComboBoxItemSharebook_Sharebook.Enabled = False

            '    _Task = _Controller.MarketDetails_CacheBooksAsync(_ViewModel)

            '    _Task.Wait()

            '    '_Task.ContinueWith(Sub()
            '    '                       EnableCacheControls(True)
            '    '                   End Sub)

            'End If

        End Sub
        Private Sub ShowHideDates()

            'objects
            Dim Counter As Integer = 0
            Dim DateNumber As Integer = 0
            Dim StartDateNumber As Integer = 0
            Dim EndDateNumber As Integer = 0
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            StartDateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ComboBoxItemDates_StartDate.ComboBoxEx.SelectedValue, "0")
            EndDateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ComboBoxItemDates_EndDate.ComboBoxEx.SelectedValue, "0")

            Counter = StartDateNumber

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString)

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                DateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_ViewModel.DetailDates(DetailDate), "0")

                If DateNumber >= StartDateNumber AndAlso DateNumber <= EndDateNumber Then

                    If _ViewModel.HiatusDataTable.Rows(0)(_ViewModel.DetailDates(DetailDate).ToString) Then

                        If ButtonItemDates_HideHiatusDates.Checked Then

                            BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).Visible = False

                        Else

                            BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).Visible = True

                        End If

                    Else

                        BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).Visible = True

                    End If

                    If ButtonItemDisplay_WeeklyRates.Checked Then

                        If _ViewModel.HiatusDataTable.Rows(0)(_ViewModel.DetailDates(DetailDate)) = False Then

                            BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString).Visible = True

                            CType(BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString), DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).RowIndex = 0

                            GridBand.Columns.MoveTo(GridBand.Columns.IndexOf(BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)) + 1, BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString))

                            CType(BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString), DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ColVIndex = CType(BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString), DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ColVIndex + 1

                        Else

                            BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString).Visible = False

                        End If

                    Else

                        BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString).Visible = False

                    End If

                Else

                    BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).Visible = False
                    BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(DetailDate).ToString).Visible = False

                End If

            Next

        End Sub
        Private Function GetFirstVisibleDateColumnIndex() As Integer

            'objects
            Dim DateColumnIndex As Integer = 0
            Dim Counter As Integer = 0
            Dim DateNumber As Integer = 0
            Dim StartDateNumber As Integer = 0
            Dim EndDateNumber As Integer = 0

            If _ViewModel IsNot Nothing Then

                StartDateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ComboBoxItemDates_StartDate.ComboBoxEx.SelectedValue, "0")
                EndDateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ComboBoxItemDates_EndDate.ComboBoxEx.SelectedValue, "0")

                Counter = StartDateNumber

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    DateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_ViewModel.DetailDates(DetailDate), "0")

                    If DateNumber >= StartDateNumber AndAlso DateNumber <= EndDateNumber Then

                        If _ViewModel.HiatusDataTable.Rows(0)(_ViewModel.DetailDates(DetailDate).ToString) = False Then

                            DateColumnIndex = DateNumber
                            Exit For

                        Else

                            If ButtonItemDates_HideHiatusDates.Checked = False Then

                                DateColumnIndex = DateNumber
                                Exit For

                            End If

                        End If

                    End If

                Next

            End If

            GetFirstVisibleDateColumnIndex = DateColumnIndex

        End Function
        Private Sub Makegood(RowIndex As Integer)

            'objects
            Dim MediaBroadcastWorksheetMarketDetailsMakegoodViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsMakegoodViewModel = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim NewDataRow As System.Data.DataRow = Nothing

            MediaBroadcastWorksheetMarketDetailsMakegoodViewModel = _Controller.MarketDetailsMakegood_Load(_ViewModel, RowIndex)

            If MediaBroadcastWorksheetMarketDetailMakegoodDialog.ShowFormDialog(MediaBroadcastWorksheetMarketDetailsMakegoodViewModel) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                BeginDataUpdate()

                NewDataRow = _Controller.MarketDetailsMakegood_Makegood(MediaBroadcastWorksheetMarketDetailsMakegoodViewModel, _ViewModel, ByBuyer:=True)

                BandedDataGridViewForm_MarketDetails.CurrentView.ClearSorting()
                BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    _Controller.MarketDetails_MarketDetailDateValueChanged(_ViewModel, RowIndex, BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).FieldName)

                Next

                EndDataUpdate()

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.RefreshData()

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginSelection()

                BandedDataGridViewForm_MarketDetails.CurrentView.ClearSelection()

                RowIndex = _ViewModel.DataTable.Rows.IndexOf(NewDataRow)

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    _Controller.MarketDetails_MarketDetailDateValueChanged(_ViewModel, RowIndex, BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).FieldName)

                Next

                BandedDataGridViewForm_MarketDetails.CurrentView.SelectRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetRowHandle(RowIndex))
                BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowHandle(RowIndex)

                GridColumn = Me.BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(_ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD).First).ToString)

                If GridColumn IsNot Nothing Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn = GridColumn
                    BandedDataGridViewForm_MarketDetails.CurrentView.SelectCell(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, GridColumn)

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.EndSelection()

                BandedDataGridViewForm_MarketDetails.CurrentView.Focus()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Private Sub CallbackMethod(AsyncResult As System.IAsyncResult)

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        End Sub
        Private Sub SetupWorksheet()

            FormatGrid()

            ItemContainerTVPuertoRico_PeriodEnd.Visible = False

            If _ViewModel.DoesWorksheetAllowSubmarkets Then

                SetupWorksheetWithSubmarkets()

            ElseIf _ViewModel.IsCanadianWorksheet AndAlso _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                SetupWorksheet_CanadianRadio()

            ElseIf _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                SetupWorksheet_PuertoRicoTV()

            Else

                SetupWorksheetNormal()

            End If

        End Sub
        Private Sub SetupWorksheetNormal()

            ButtonItemVendors_Traffic.Visible = True
            RibbonBarOptions_Market.Visible = True
            RibbonBarOptions_Research.Visible = True

        End Sub
        Private Sub SetupWorksheet_CanadianRadio()

            ButtonItemVendors_Traffic.Visible = False
            RibbonBarOptions_Market.Visible = False
            RibbonBarOptions_Research.Visible = False

        End Sub
        Private Sub SetupWorksheet_PuertoRicoTV()

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString, True)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString, True)
            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString, True)
            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString, True)
            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString, True)
            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString, True)

            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString, True)
            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString, True)
            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString, True)
            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString, True)
            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString, True)

        End Sub
        Private Sub SetupWorksheetWithSubmarkets()

            'objects
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            ButtonItemVendors_Traffic.Visible = False
            RibbonBarOptions_Market.Visible = False
            RibbonBarOptions_Research.Visible = False

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimarySubmarketDemo.ToString)

            If GridBand IsNot Nothing Then

                If GridBand.Columns IsNot Nothing AndAlso GridBand.Columns.Count > 0 Then

                    For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.BestFit()

                    Next

                End If

            End If

            GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

            If GridBand IsNot Nothing Then

                If GridBand.Columns IsNot Nothing AndAlso GridBand.Columns.Count > 0 Then

                    For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.BestFit()

                    Next

                End If

            End If

        End Sub
        Private Sub RemoveColumn(FieldName As String, GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(FieldName) IsNot Nothing Then

                If GridBand IsNot Nothing Then

                    If GridBand.Columns.Contains(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(FieldName)) Then

                        GridBand.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(FieldName))

                    End If

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.Columns.Remove(BandedDataGridViewForm_MarketDetails.CurrentView.Columns.ColumnByName(FieldName))

            End If

        End Sub
        Private Sub Submarkets_Setup()

            Submarkets_SetupPrimary()

            Submarkets_SetupSecondary()

        End Sub
        Private Sub Submarkets_SetupPrimary()

            If ButtonItemDemos_ShowPrimary.Checked Then

                'GridBandVisibleChanged(GridBandNames.GridBandPrimarySubmarketDemo, True, GridBandNames.GridBandPrimarySubmarketDemo)

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.ShowHidePrimaryDemo(True)

                End If

            Else

                'GridBandVisibleChanged(GridBandNames.GridBandPrimarySubmarketDemo, False)

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.ShowHidePrimaryDemo(False)

                End If

            End If

        End Sub
        Private Sub Submarkets_SetupSecondary()

            If ButtonItemDemos_ShowSecondary.Checked AndAlso _ViewModel.HasASelectedWorksheetSecondaryDemo Then

                Submarkets_SetupSecondaryColumns(_ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicID)

                If _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicID > 0 Then

                    'GridBandVisibleChanged(GridBandNames.GridBandSecondarySubmarketDemo, True)

                    If _SubmarketsForm IsNot Nothing Then

                        _SubmarketsForm.ShowHideSecondaryDemo(True)

                    End If

                Else

                    'GridBandVisibleChanged(GridBandNames.GridBandSecondarySubmarketDemo, False)

                    If _SubmarketsForm IsNot Nothing Then

                        _SubmarketsForm.ShowHideSecondaryDemo(False)

                    End If

                End If

            Else

                'GridBandVisibleChanged(GridBandNames.GridBandSecondarySubmarketDemo, False)

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.ShowHideSecondaryDemo(False)

                End If

            End If

        End Sub
        Private Sub Submarkets_SetupSecondaryColumns(MediaDemographicID As Integer)

            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.SetupSecondaryColumns(MediaDemographicID)

            End If

            'GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

            'If MediaDemographicID > 0 Then

            '    For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).OrderBy(Function(Entity) Entity.FieldName).ToList

            '        If GridColumn.FieldName.EndsWith("_" & MediaDemographicID) Then

            '            GridColumn.Visible = True

            '        Else

            '            GridColumn.Visible = False

            '        End If

            '    Next

            'Else

            '    For Each GridColumn In GridBand.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

            '        GridColumn.Visible = False

            '    Next

            'End If

        End Sub
        Private Sub SendASPDownloadEmail(FileName As String)

            If Not AdvantageFramework.Email.SendASPReportDownloadEmail(Session, FileName) Then

                AdvantageFramework.WinForm.MessageBox.Show("File exported successfully but email link could not be sent to your email.")

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Export file created successfully and also email link has been sent to you email.")

            End If

        End Sub
        Private Sub ExportProposal(SuppressRates As Boolean)

            'objects
            Dim IsAgencyASP As Boolean = False
            Dim Folder As String = Nothing
            Dim Process As Boolean = True
            Dim [Continue] As Boolean = False
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileName As String = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim VendorCodesNotSetup As Generic.List(Of String) = Nothing
            Dim ErrorMessage As String = Nothing

            If _ViewModel IsNot Nothing AndAlso _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                CloseGridEditorAndSaveValueToDataSource()

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                        If IsAgencyASP Then

                            Folder = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                            Folder = System.IO.Path.Combine(Folder, "Reports", "Media") & "\"

                            If System.IO.Directory.Exists(Folder) = False Then

                                System.IO.Directory.CreateDirectory(Folder)

                            End If

                        Else

                            If AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder) = False Then

                                Process = False

                            Else

                                Folder = Folder & "\"

                            End If

                        End If

                        If Process Then

                            Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Printing, "Processing...")

                            MemoryStream = _Controller.MarketDetails_CreateProposalXML(_ViewModel, SuppressRates, VendorCodesNotSetup, ErrorMessage)

                            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                If VendorCodesNotSetup IsNot Nothing AndAlso VendorCodesNotSetup.Count > 0 Then

                                    AdvantageFramework.WinForm.MessageBox.Show("The following vendors are not associated with a valid Nielsen/Eastlan radio station: " & String.Join(", ", VendorCodesNotSetup.ToArray))

                                End If

                                FileName = Replace(Replace("Proposal_" & _ViewModel.Worksheet.Name & "_" & _ViewModel.SelectedWorksheetMarket.MarketCode & "_" & _ViewModel.SelectedWorksheetMarket.ID & "_" & Now.ToString("yyyyMMddHHmmss") & ".xml", "\", ""), "/", "")

                                FileStream = New System.IO.FileStream(Folder & FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                MemoryStream.WriteTo(FileStream)
                                FileStream.Close()

                                If IsAgencyASP Then

                                    SendASPDownloadEmail(Folder & FileName)

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("File saved to: " & Folder & FileName)

                                End If

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                            End If

                            Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.None)

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub BeginDataUpdate()

            BandedDataGridViewForm_MarketDetails.CurrentView.BeginDataUpdate()

            If _TotalsForm IsNot Nothing Then

                _TotalsForm.BeginDataUpdate()

            End If

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.BeginDataUpdate()

            End If

        End Sub
        Private Sub EndDataUpdate()

            BandedDataGridViewForm_MarketDetails.CurrentView.EndDataUpdate()

            If _TotalsForm IsNot Nothing Then

                _TotalsForm.EndDataUpdate()

            End If

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.EndDataUpdate()

            End If

        End Sub
        Private Sub ExpandAllGroups()

            BandedDataGridViewForm_MarketDetails.CurrentView.ExpandAllGroups()

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.ExpandGroupRow(Integer.MinValue)

            End If

        End Sub
        Private Function ShowMediaManagerReviewDialog(RowIndexes As Generic.List(Of Integer)) As Boolean

            'objects
            Dim MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim OrderSubmittedList As Generic.List(Of AdvantageFramework.Classes.Media.OrderSubmitted) = Nothing
            Dim Shown As Boolean = False
            Dim Message As String = String.Empty
            Dim [Continue] As Boolean = True

            MediaManagerReviewDetails = _Controller.MarketDetails_LoadMediaManagerReviewDetails(_ViewModel, RowIndexes, OrderSubmittedList)

            If MediaManagerReviewDetails IsNot Nothing AndAlso MediaManagerReviewDetails.Count > 0 Then

                If OrderSubmittedList.Count > 0 And OrderSubmittedList.Where(Function(OS) OS.IsSubmitted = True).Any Then

                    For Each OrderSubmitted In OrderSubmittedList.Where(Function(OS) OS.IsSubmitted = True).ToList

                        Message += OrderSubmitted.VendorCode & " / " & OrderSubmitted.OrderNumber.ToString & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show("Orders cannot be generated.  There are pending makegoods submitted for the following vendor(s)/order(s): " & vbCrLf & Message)

                    [Continue] = False

                ElseIf OrderSubmittedList.Count > 0 Then

                    For Each OrderSubmitted In OrderSubmittedList.Where(Function(OS) OS.IsSubmitted = False).ToList

                        Message += OrderSubmitted.VendorCode & " / " & OrderSubmitted.OrderNumber.ToString & vbCrLf

                    Next

                    Message += vbCrLf & "Would you like to proceed and delete that activity?"

                    If AdvantageFramework.WinForm.MessageBox.Show("There are pending makegoods for the following vendor(s)/order(s): " & vbCrLf & Message, WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                        [Continue] = False

                    End If

                End If

                If [Continue] Then

                    AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersDialog.ShowFormDialog(MediaManagerReviewDetails, True)

                    Shown = True

                End If

            End If

            ShowMediaManagerReviewDialog = Shown

        End Function
        Private Sub ToggleSelectionMode(CellSelect As Boolean)

            If CellSelect Then

                BandedDataGridViewForm_MarketDetails.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
                BandedDataGridViewForm_MarketDetails.CurrentView.ClearSelection()

            Else

                BandedDataGridViewForm_MarketDetails.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect
                BandedDataGridViewForm_MarketDetails.CurrentView.ClearSelection()

            End If

            Me.RibbonBarOptions_Actions.Enabled = Not CellSelect
            Me.RibbonBarOptions_Dates.Enabled = Not CellSelect
            Me.RibbonBarOptions_Display.Enabled = Not CellSelect
            Me.RibbonBarOptions_Makegood.Enabled = Not CellSelect
            Me.RibbonBarOptions_Market.Enabled = Not CellSelect
            Me.RibbonBarOptions_Research.Enabled = Not CellSelect
            Me.RibbonBarOptions_Revisions.Enabled = Not CellSelect
            Me.RibbonBarOptions_Submarkets.Enabled = Not CellSelect
            Me.RibbonBarOptions_Vendors.Enabled = Not CellSelect
            Me.RibbonBarPrinting_Print.Enabled = Not CellSelect
            Me.RibbonBarProcess_Data.Enabled = Not CellSelect

        End Sub
        Protected Sub UpdateSelectedCellsWithSpots(sender As Object, e As EventArgs)

            'objects
            Dim Spots As Integer = 0
            Dim GridCells As DevExpress.XtraGrid.Views.Base.GridCell() = Nothing
            Dim CellCount As Integer = 0
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = 0
            Dim UpdateSummary As Boolean = False
            Dim SpotsChanged As Boolean = False

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Update Spots for selected cells", "Spots:", Spots, Spots, Nothing, WinForm.Presentation.Controls.NumericInput.Type.Integer, True, 0, 999, "n0") = Windows.Forms.DialogResult.OK Then

                GridCells = BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedCells()
                CellCount = GridCells.Length

                For i As Integer = 0 To CellCount - 1

                    If (TryCast(GridCells(i).Column, DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)).FieldName.StartsWith("Date") Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(GridCells(i).RowHandle), System.Data.DataRowView).Row

                        RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                        If _ViewModel.DetailDates.ContainsValue((TryCast(GridCells(i).Column, DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)).FieldName) AndAlso
                                _ViewModel.DataTable.Rows(RowIndex)(GridCells(i).Column.FieldName.Replace("Date", "Entered")) = True Then

                            DataRow((TryCast(GridCells(i).Column, DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)).FieldName) = Spots

                            _Controller.MarketDetails_MarketDetailDateValueChanged(_ViewModel, RowIndex, (TryCast(GridCells(i).Column, DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)).FieldName)

                            UpdateSummary = True
                            SpotsChanged = True

                        End If

                    End If

                Next

                If UpdateSummary Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                End If

                If SpotsChanged Then

                    If _SubmarketsForm IsNot Nothing Then

                        _SubmarketsForm.RefreshData()

                    End If

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                RefreshViewModel(False)

                ToggleSelectionMode(False)

            End If

        End Sub
        Protected Sub CancelSelectedCells(sender As Object, e As EventArgs)

            ToggleSelectionMode(False)

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer)

            'objects
            Dim MediaBroadcastWorksheetMarketDetailForm As MediaBroadcastWorksheetMarketDetailForm = Nothing

            MediaBroadcastWorksheetMarketDetailForm = New MediaBroadcastWorksheetMarketDetailForm(MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketID)

            MediaBroadcastWorksheetMarketDetailForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailForm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

            If _TotalsForm IsNot Nothing Then

                _TotalsForm.Hide()

            End If

            If _MeasurementTrendsForm IsNot Nothing Then

                _MeasurementTrendsForm.Hide()

            End If

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.Hide()

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated

            If Me.FormShown Then

                If _TotalsForm IsNot Nothing Then

                    _TotalsForm.Visible = ButtonItemDisplay_Summaries.Checked

                End If

                If _MeasurementTrendsForm IsNot Nothing Then

                    _MeasurementTrendsForm.Visible = ButtonItemResearch_Trends.Checked
                    _MeasurementTrendsForm.Visible = ButtonItemResearch_Trends2.Checked

                End If

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.Visible = ButtonItemSubmarkets_Show.Checked

                End If

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            If _ViewModel IsNot Nothing AndAlso _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                _Controller.ClearWorksheetMarketLock(_ViewModel.SelectedWorksheetMarket.ID)

            End If

            If _TotalsForm IsNot Nothing Then

                _TotalsForm.Close()

                _TotalsForm.Dispose()

                _TotalsForm = Nothing

            End If

            If _MeasurementTrendsForm IsNot Nothing Then

                _MeasurementTrendsForm.Close()

                _MeasurementTrendsForm.Dispose()

                _MeasurementTrendsForm = Nothing

            End If

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.Close()

                _SubmarketsForm.Dispose()

                _SubmarketsForm = Nothing

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemRevisions_Create.Image = AdvantageFramework.My.Resources.RevisionImage
            ButtonItemActions_CopyHiatusDates.Image = AdvantageFramework.My.Resources.SetHiatusImage
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage

            ButtonItemActions_DeleteRevision.Image = AdvantageFramework.My.Resources.RevisionDeleteImage
            ButtonItemRevisions_View.Image = AdvantageFramework.My.Resources.RevisionViewImage

            ButtonItemVendors_Edit.Image = AdvantageFramework.My.Resources.VendorEditImage

            'ButtonItemMarkets_Manage.Image = AdvantageFramework.My.Resources.QuickManageImage

            'ButtonItemActions_Goals.Image = AdvantageFramework.My.Resources.FinishImage
            ButtonItemVendors_Manage.Image = AdvantageFramework.My.Resources.VendorManageImage
            ButtonItemSchedule_OrderComments.Image = AdvantageFramework.My.Resources.AddCommentImage
            ButtonItemVendors_RFP.Image = AdvantageFramework.My.Resources.RFPImage
            ButtonItemVendors_Traffic.Image = AdvantageFramework.My.Resources.MovieReelFilledImage
            ButtonItemSchedule_Books.Image = AdvantageFramework.My.Resources.NielsenBookImage
            ButtonItemSchedule_Books2.Image = AdvantageFramework.My.Resources.NielsenBookImage
            ButtonItemResearch_Trends.Image = AdvantageFramework.My.Resources.TrendingImage
            ButtonItemResearch_Trends2.Image = AdvantageFramework.My.Resources.TrendingImage
            ButtonItemDisplay_Summaries.Image = AdvantageFramework.My.Resources.TotalFieldsImage
            ButtonItemDisplay_ShowTotals.Image = AdvantageFramework.My.Resources.SumImage
            ButtonItemDisplay_HideZeroSpotLines.Image = AdvantageFramework.My.Resources.ShowInactiveImage
            ButtonItemSchedule_RefreshDemos.Image = AdvantageFramework.My.Resources.CalculatorCheckImage
            ButtonItemDisplay_WeeklyRates.Image = AdvantageFramework.My.Resources.SmallCurrencyDollarImage
            ButtonItemSchedule_ShowVendorDemos.Image = AdvantageFramework.My.Resources.SmallVendorImage
            ButtonItemSchedule_ViewOrderDetails.Image = AdvantageFramework.My.Resources.ViewImage

            ButtonItemActions_AddRow.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_DeleteRow.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_CopyRow.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemMakegood_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemMakegood_AddReplacement.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemMakegood_Details.Image = AdvantageFramework.My.Resources.ViewImage
            ButtonItemMakegood_Offers.Image = AdvantageFramework.My.Resources.ViewImage

            ButtonItemDemos_ShowPrimary.Image = AdvantageFramework.My.Resources.ShowFieldListImage
            ButtonItemDemos_ShowSecondary.Image = AdvantageFramework.My.Resources.ShowFieldListImage

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemOrders_Create.Image = AdvantageFramework.My.Resources.CreateForAllRowsImage
            ButtonItemOrders_CreateForSelected.Image = AdvantageFramework.My.Resources.CreateForSelectedRowsImage
            ButtonItemOrders_Generate.Image = AdvantageFramework.My.Resources.MediaAddImage
            ButtonItemOrders_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemPrint_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemPrint_Settings.Image = AdvantageFramework.My.Resources.ReportEditImage

            ButtonItemOrders_Generate.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_GenerateOrders)

            ButtonItemVendors_Edit.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

            ButtonItemOrders_OrderStatus.Image = AdvantageFramework.My.Resources.IndirectCategoryImage

            ButtonItemDates_Show.Image = AdvantageFramework.My.Resources.DateTimeImage
            ButtonItemDates_ShowAll.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage
            ButtonItemDates_HideHiatusDates.Image = AdvantageFramework.My.Resources.HideImage

            ButtonItemSubmarkets_Show.Image = AdvantageFramework.My.Resources.ColumnAddImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            'ButtonItemActions_CopyHiatusDates.Text = String.Format(ButtonItemActions_CopyHiatusDates.Text, If(_ViewModel.Worksheet.MediaBroadcastWorksheetDateTypeID = DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly, "Weeks", "Days"))

            BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()
            BandedDataGridViewForm_MarketDetails.CurrentView.BeginDataUpdate()

            LoadGrid()

            SetupWorksheet()

            BandedDataGridViewForm_MarketDetails.CurrentView.ExpandAllGroups()

            LoadWorksheetSecondaryDemos()

            LoadRevisionNumbers()

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen OrElse
                        _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                    LoadSharebooks()

                    LoadHUTPUTBooks()

                    ItemContainerResearch_TVBooks.Visible = True
                    ItemContainerSchedule_RadioPeriods1.Visible = False
                    ItemContainerSchedule_RadioPeriods2.Visible = False

                    ItemContainerResearch_TVPuertoRico.Visible = False

                ElseIf _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                    ItemContainerResearch_TVBooks.Visible = False
                    ItemContainerSchedule_RadioPeriods1.Visible = False
                    ItemContainerSchedule_RadioPeriods2.Visible = False

                    ItemContainerTVPuertoRico_PeriodEnd.Visible = True

                End If

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                LoadRadioPeriodsBook1()
                LoadRadioPeriodsBook2()
                LoadRadioPeriodsBook3()
                LoadRadioPeriodsBook4()
                LoadRadioPeriodsBook5()

                ItemContainerResearch_TVBooks.Visible = False
                ItemContainerSchedule_RadioPeriods1.Visible = True
                ItemContainerSchedule_RadioPeriods2.Visible = True

                ItemContainerResearch_TVPuertoRico.Visible = False

            End If

            RefreshViewModel(True)

            UpdateDateColumns()

            BestFitColumnsInitalLoad()

            Me.Text = "Market Schedule - " & _Controller.MarketDetails_LoadWorksheetFullName(_ViewModel)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                LabelForm_Disclaimer.Visible = False

                If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                    If _ViewModel.SelectedWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                        RibbonBarOptions_Research.Text = "Research - Source: " & AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen.ToString

                    ElseIf _ViewModel.SelectedWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                        RibbonBarOptions_Research.Text = "Research - Source: " & AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan.ToString

                    Else

                        RibbonBarOptions_Research.Text = "Research"

                    End If

                Else

                    RibbonBarOptions_Research.Text = "Research"

                End If

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                If _ViewModel.Worksheet IsNot Nothing Then

                    If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                        RibbonBarOptions_Research.Text = "Research - Source: " & AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen.ToString
                        LabelForm_Disclaimer.Visible = False

                    ElseIf _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        RibbonBarOptions_Research.Text = "Research - Source: " & AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore.ToString
                        ButtonItemResearch_Trends.SecurityEnabled = True
                        'ButtonItemResearch_Trends.Tooltip = "Comscore data not available - " & ButtonItemResearch_Trends.Tooltip
                        ButtonItemResearch_Trends2.SecurityEnabled = True
                        'ButtonItemResearch_Trends2.Tooltip = "Comscore data not available - " & ButtonItemResearch_Trends2.Tooltip

                        If (BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString) IsNot Nothing AndAlso
                                BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).Visible = True) OrElse
                                (BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString) IsNot Nothing AndAlso
                                 BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).Visible = True) OrElse
                                (BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString) IsNot Nothing AndAlso
                                 BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).Visible = True) OrElse
                                (BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString) IsNot Nothing AndAlso
                                 BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).Visible = True) Then

                            LabelForm_Disclaimer.Visible = True

                        Else

                            LabelForm_Disclaimer.Visible = False

                        End If

                    Else

                        RibbonBarOptions_Research.Text = "Research"
                        LabelForm_Disclaimer.Visible = False

                    End If

                Else

                    RibbonBarOptions_Research.Text = "Research"
                    LabelForm_Disclaimer.Visible = False

                End If

            Else

                RibbonBarOptions_Research.Text = "Research"
                LabelForm_Disclaimer.Visible = False

            End If

            _TotalsForm = New Media.Presentation.MediaBroadcastWorksheetMarketDetailTotalsDialog(Me, _Controller, _ViewModel)
            _TotalsForm.RefreshLabels()

            _MeasurementTrendsForm = New Media.Presentation.MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog(Me, _Controller, _ViewModel)

            RibbonBarMergeContainerForm_Process.RibbonTabItem.RaiseClick(DevComponents.DotNetBar.eEventSource.Mouse)
            RibbonBarMergeContainerForm_Options.RibbonTabItem.RaiseClick(DevComponents.DotNetBar.eEventSource.Mouse)

            If IsNothing(BandedDataGridViewForm_MarketDetails.CurrentView.Tag) = False Then

                ButtonItemDisplay_ShowTotals.Checked = BandedDataGridViewForm_MarketDetails.CurrentView.Tag

                If ButtonItemDisplay_ShowTotals.Checked = False Then

                    FormatGrid_ShowSummary(ButtonItemDisplay_ShowTotals.Checked)

                End If

            End If

            LoadDateSelections()

            ComboBoxItemDates_StartDate.ComboBoxEx.SelectedValue = _ViewModel.StartDateSelection
            ComboBoxItemDates_EndDate.ComboBoxEx.SelectedValue = _ViewModel.EndDateSelection

            ButtonItemDates_HideHiatusDates.Checked = _ViewModel.HideHiatusDates

            ShowHideDates()

            OnBestFitAllDateColumns(sender, e)

            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString) IsNot Nothing AndAlso
                    BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).Visible AndAlso
                    _ViewModel.DataTable.Rows.Count = 0 Then

                BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).BestFit()

            End If

            ' BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

            If _ViewModel.DoesWorksheetAllowSubmarkets Then

                RibbonBarOptions_Submarkets.Visible = True

                Submarkets_Setup()

                _SubmarketsForm = New Media.Presentation.MediaBroadcastWorksheetMarketDetailSubmarketDemoDialog(Me, _Controller, _ViewModel)

                'ButtonItemSubmarkets_Ratings.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_GRP.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_IMP.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_GIMP.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_Allocation.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_Percentage.Enabled = ButtonItemSubmarkets_Show.Checked

            Else

                RibbonBarOptions_Submarkets.Visible = False

            End If

            BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            BandedDataGridViewForm_MarketDetails.CurrentView.EndDataUpdate()
            BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

            BandedDataGridViewForm_MarketDetails.CurrentView.ExpandAllGroups()

            ButtonItemVendors_Traffic.SecurityEnabled = _ViewModel.UserHasAccessToMediaTraffic

            Me.ClearChanged()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            RibbonBarOptions_Research.ResetCachedContentSize()
            RibbonBarOptions_Research.Refresh()
            RibbonBarOptions_Research.Width = RibbonBarOptions_Research.GetAutoSizeWidth
            RibbonBarOptions_Research.Refresh()

            RibbonBarOptions_Actions.ResetCachedContentSize()
            RibbonBarOptions_Actions.Refresh()
            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth
            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_Vendors.ResetCachedContentSize()
            RibbonBarOptions_Vendors.Refresh()
            RibbonBarOptions_Vendors.Width = RibbonBarOptions_Vendors.GetAutoSizeWidth
            RibbonBarOptions_Vendors.Refresh()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.LoadingSelectedItem)

            BandedDataGridViewForm_MarketDetails.DeselectAll()

            BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle = 0

            ButtonItemDisplay_WeeklyRates.Text = "Show " & _ViewModel.Worksheet.MediaBroadcastWorksheetDateType & " Rates"

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            BandedDataGridViewForm_MarketDetails.CurrentView.SelectRow(0)

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.MarketDetails_UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.MarketDetails_ClearChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim VendorNames As IEnumerable(Of String) = Nothing
            Dim MediaBroadcastWorksheetMarketDetailID As Integer = 0
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            If HasNoErrors() Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                _Controller.MarketDetails_RefreshMakegoodStatus(_ViewModel)

                VendorNames = _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(F) F.RowState <> DataRowState.Unchanged).Select(Function(F) F.Item(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).ToString).Distinct.ToArray

                For Each VendorName In VendorNames

                    If _ViewModel.WorksheetMarketDetailVendorMakegoodStatuses.Where(Function(Entity) Entity.VendorName = VendorName AndAlso
                                                                                                      Entity.Status = Database.Entities.OrderStatusType.MakegoodOfferSubmitted).Any Then

                        If AdvantageFramework.WinForm.MessageBox.Show("Vendor " & VendorName & " has a pending makegood offer from the vendor which conflicts with your pending changes.  Click ‘Yes’ to discard the pending makegood offer or ‘No’ to discard your changes.", WinForm.MessageBox.MessageBoxButtons.YesNo, "Discard vendor changes?", Windows.Forms.MessageBoxIcon.Exclamation) = WinForm.MessageBox.DialogResults.No Then

                            For Each DataRow In _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow)

                                If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) = VendorName Then

                                    DataRow.RejectChanges()

                                End If

                            Next

                        Else

                            MediaBroadcastWorksheetMarketDetailID = CInt((From Entity In _ViewModel.DataTable.AsEnumerable
                                                                          Where Entity.Item(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) = VendorName
                                                                          Select Entity.Item(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString)).First)

                            MakegoodDeliveryController = New Controller.Media.MakegoodDeliveryController(Session)
                            MakegoodDeliveryViewModel = MakegoodDeliveryController.Load(MediaBroadcastWorksheetMarketDetailID)
                            MakegoodDeliveryController.RejectMakegoodOffer(MakegoodDeliveryViewModel, MakegoodDeliveryController.Session.ConnectionString, MakegoodDeliveryController.Session.UserCode, MakegoodDeliveryController.Session.EmployeeName, "Rejected by buyer due to pending buyer changes.")

                        End If

                    End If

                Next

                SaveGridLayout()

                _Controller.MarketDetails_Save(_ViewModel)

                If _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    CacheComscoreData()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Recalculating)

                    _Controller.MarketDetails_Recalculate(_ViewModel)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    _Controller.MarketDetails_Save(_ViewModel)

                End If

                RefreshMediaBroadcastWorksheetSetupForm()

                Me.ClearChanged()

                RefreshViewModel(False)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                RefreshVendorStatus()

                ' BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                Me.RaiseClearChanged()

                BandedDataGridViewForm_MarketDetails.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            'objects
            Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
            Dim StreamWriter As System.IO.StreamWriter = Nothing
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to cancel all your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                If _ViewModel.IsInAcceptMakegoodMode Then

                    _ViewModel.IsInAcceptMakegoodMode = False

                End If

                BeginDataUpdate()

                _Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                LoadGrid()

                LoadRevisionNumbers()

                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                    If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                        LoadSharebooks()

                        LoadHUTPUTBooks()

                        ComboBoxItemSharebook_Sharebook.SelectedIndex = -1
                        ComboBoxItemHUTPUT_HUTPUT.SelectedIndex = -1

                    End If

                ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                    LoadRadioPeriodsBook1()
                    LoadRadioPeriodsBook2()
                    LoadRadioPeriodsBook3()
                    LoadRadioPeriodsBook4()
                    LoadRadioPeriodsBook5()

                    ComboBoxItemBook1_Book1.ComboBoxEx.SelectedValue = -1
                    ComboBoxItemBook2_Book2.ComboBoxEx.SelectedValue = -1
                    ComboBoxItemBook3_Book3.ComboBoxEx.SelectedValue = -1
                    ComboBoxItemBook4_Book4.ComboBoxEx.SelectedValue = -1
                    ComboBoxItemBook5_Book5.ComboBoxEx.SelectedValue = -1

                End If

                EndDataUpdate()

                ExpandAllGroups()

                Me.ClearChanged()

                RefreshViewModel(False)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.RaiseClearChanged()

                BandedDataGridViewForm_MarketDetails.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemRevisions_Create_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_Create.Click

            'objects
            Dim RevisionComment As String = String.Empty
            Dim VendorNames As IEnumerable(Of String) = Nothing
            Dim MediaBroadcastWorksheetMarketDetailID As Integer = 0
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim CreateRevision As Boolean = True

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                _Controller.MarketDetails_RefreshMakegoodStatus(_ViewModel)

                If _ViewModel.WorksheetMarketDetailVendorMakegoodStatuses.Where(Function(Entity) Entity.Status = Database.Entities.Methods.OrderStatusType.MakegoodOfferSubmitted).Any Then

                    If AdvantageFramework.WinForm.MessageBox.Show("One or more vendors has a pending makegood offer.  Click ‘Yes’ to discard the pending makegood offer(s) or ‘No’ to cancel creating revision.", WinForm.MessageBox.MessageBoxButtons.YesNo, "Discard vendor changes?", Windows.Forms.MessageBoxIcon.Exclamation) = WinForm.MessageBox.DialogResults.Yes Then

                        VendorNames = _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(F) F.Item(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).ToString).Distinct.ToArray

                        For Each VendorName In VendorNames

                            If _ViewModel.WorksheetMarketDetailVendorMakegoodStatuses.Where(Function(Entity) Entity.VendorName = VendorName AndAlso
                                                                                                              Entity.Status = Database.Entities.Methods.OrderStatusType.MakegoodOfferSubmitted).Any Then

                                MediaBroadcastWorksheetMarketDetailID = CInt((From Entity In _ViewModel.DataTable.AsEnumerable
                                                                              Where Entity.Item(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) = VendorName
                                                                              Select Entity.Item(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString)).First)

                                MakegoodDeliveryController = New Controller.Media.MakegoodDeliveryController(Session)
                                MakegoodDeliveryViewModel = MakegoodDeliveryController.Load(MediaBroadcastWorksheetMarketDetailID)
                                MakegoodDeliveryController.RejectMakegoodOffer(MakegoodDeliveryViewModel, MakegoodDeliveryController.Session.ConnectionString, MakegoodDeliveryController.Session.UserCode, MakegoodDeliveryController.Session.EmployeeName, "Rejected by buyer due to worksheet revision creation.")

                            End If

                        Next

                    Else

                        CreateRevision = False

                    End If

                End If

                If CreateRevision AndAlso AdvantageFramework.WinForm.Presentation.TextBoxInputDialog.ShowFormDialog("Create New Revision", "Enter a revision comment", String.Empty, RevisionComment) = System.Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    BeginDataUpdate()

                    _Controller.MarketDetails_CreateRevisions(_ViewModel, RevisionComment)

                    LoadRevisionNumbers()

                    RefreshViewModel(False)

                    EndDataUpdate()

                    ExpandAllGroups()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.RaiseClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_DeleteRevision_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_DeleteRevision.Click

            'objects
            Dim RevisionComment As String = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this revision?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    BeginDataUpdate()

                    _Controller.MarketDetails_DeleteRevision(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

                    LoadRevisionNumbers()

                    RefreshViewModel(False)

                    EndDataUpdate()

                    ExpandAllGroups()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.RaiseClearChanged()

                    BandedDataGridViewForm_MarketDetails.GridViewSelectionChanged()

                    If _TotalsForm IsNot Nothing Then

                        _TotalsForm.RefreshLabels()

                    End If

                    If _SubmarketsForm IsNot Nothing Then

                        _SubmarketsForm.RefreshData()

                    End If

                End If

            End If

        End Sub
        Private Sub ComboBoxItemRevisions_Revisions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemRevisions_Revisions.SelectedIndexChanged

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before switching.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                BeginDataUpdate()

                _Controller.MarketDetails_ChangeRevisionNumber(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

                LoadGrid()

                RefreshDateAndRateColumns()

                ComboBoxItemSecondaryDemo_SecondaryDemo.SelectedIndex = -1

                ExpandAllGroups()

                EndDataUpdate()

                Me.ClearChanged()

                RefreshViewModel(False)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.RaiseClearChanged()

                BandedDataGridViewForm_MarketDetails.GridViewSelectionChanged()

                If _TotalsForm IsNot Nothing Then

                    _TotalsForm.RefreshLabels()

                End If

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.RefreshData()

                End If

                'If _MeasurementTrendsForm IsNot Nothing Then

                '	_MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, False)

                'End If

            Else

                If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                    ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarketRevisionNumber

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_ViewRevisions_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_View.Click

            Media.Presentation.MediaBroadcastWorksheetMarketRevisionsDialog.ShowFormDialog(_ViewModel.Worksheet.ID, _ViewModel.SelectedWorksheetMarket.ID)

        End Sub
        Private Sub ButtonItemActions_CopyHiatusDates_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CopyHiatusDates.Click

            'objects
            Dim MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel = Nothing
            Dim LockedMarketsMessage As String = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel = _Controller.MarketHiatusSettingsCopyFromAnotherMarket_Load(_ViewModel)

            If MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketDialog.ShowFormDialog(MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                _Controller.MarketHiatusSettingsCopyFromAnotherMarket_CopyTo(MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel, _ViewModel)

                RefreshViewModel(False)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ButtonItemAutoFill_AutoFill_Click(sender As Object, e As EventArgs) Handles ButtonItemAutoFill_AutoFill.Click

            'objects
            Dim NonGroupRowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim WorksheetMarketDetailAutoFill As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailAutoFill = Nothing
            Dim MarketDetailChanged As Boolean = False

            NonGroupRowIndexes = New Generic.List(Of Integer)

            For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(RowHandle) = False Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                    NonGroupRowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                End If

            Next

            If NonGroupRowIndexes.Count > 0 Then

                If MediaBroadcastWorksheetMarketDetailAutoFillDialog.ShowFormDialog(_ViewModel, WorksheetMarketDetailAutoFill, NonGroupRowIndexes) = Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    BeginDataUpdate()

                    For Each RowIndex In NonGroupRowIndexes

                        MarketDetailChanged = False

                        DataRow = _ViewModel.DataTable.Rows(RowIndex)

                        If String.IsNullOrWhiteSpace(WorksheetMarketDetailAutoFill.DaypartCode) = False OrElse WorksheetMarketDetailAutoFill.DaypartClear Then

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString) = WorksheetMarketDetailAutoFill.DaypartCode

                            _Controller.MarketDetails_DaypartChanged(_ViewModel, RowIndex)

                            MarketDetailChanged = True

                        End If

                        If (WorksheetMarketDetailAutoFill.Length.HasValue AndAlso WorksheetMarketDetailAutoFill.Length.Value > 0) OrElse WorksheetMarketDetailAutoFill.LengthClear Then

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString) = WorksheetMarketDetailAutoFill.Length.Value

                            _Controller.MarketDetails_LengthChanged(_ViewModel, RowIndex)

                            MarketDetailChanged = True

                        End If

                        If String.IsNullOrWhiteSpace(WorksheetMarketDetailAutoFill.Days) = False OrElse WorksheetMarketDetailAutoFill.DaysClear Then

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString) = WorksheetMarketDetailAutoFill.Days

                            _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                            MarketDetailChanged = True

                        End If

                        If String.IsNullOrWhiteSpace(WorksheetMarketDetailAutoFill.StartTime) = False OrElse WorksheetMarketDetailAutoFill.StartTimeClear Then

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString) = WorksheetMarketDetailAutoFill.StartTime

                            _Controller.MarketDetails_StartTimeChanged(_ViewModel, RowIndex)

                            MarketDetailChanged = True

                        End If

                        If String.IsNullOrWhiteSpace(WorksheetMarketDetailAutoFill.EndTime) = False OrElse WorksheetMarketDetailAutoFill.EndTimeClear Then

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString) = WorksheetMarketDetailAutoFill.EndTime

                            _Controller.MarketDetails_EndTimeChanged(_ViewModel, RowIndex)

                            MarketDetailChanged = True

                        End If

                        If String.IsNullOrWhiteSpace(WorksheetMarketDetailAutoFill.Comments) = False OrElse WorksheetMarketDetailAutoFill.CommentsClear Then

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString) = WorksheetMarketDetailAutoFill.Comments

                            _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                        End If

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString) <> WorksheetMarketDetailAutoFill.ValueAdded Then

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString) = WorksheetMarketDetailAutoFill.ValueAdded

                            _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                            MarketDetailChanged = True

                        End If

                        'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString) = WorksheetMarketDetailAutoFill.Bookend

                        If MarketDetailChanged Then

                            _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                            ValidateRow(DataRow)

                        End If

                    Next

                    EndDataUpdate()

                    BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    'BandedDataGridViewForm_MarketDetails.CurrentView.ValidateAllRows()

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                End If

            End If

        End Sub

        Private Sub ComboBoxItemMarkets_Markets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemMarkets_Markets.SelectedIndexChanged

            'objects
            Dim LockedByUserEmployeeName As String = Nothing
            Dim SelectedWorksheetMarketID As Nullable(Of Integer) = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then 'AndAlso HasNoErrors() Then

                'If _ViewModel.SaveEnabled Then

                '    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before switching.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                '        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                '        _Controller.MarketDetails_Save(_ViewModel)

                '        RefreshMediaBroadcastWorksheetSetupForm()

                '        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                '    End If

                'End If

                SelectedWorksheetMarketID = _ViewModel.SelectedWorksheetMarket.ID

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                If _Controller.IsWorksheetMarketLocked(ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue, LockedByUserEmployeeName) Then

                    AdvantageFramework.WinForm.MessageBox.Show(LockedByUserEmployeeName)

                    ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue = SelectedWorksheetMarketID

                Else

                    If Not CheckForOpenWorksheet(Me.MdiParent, _ViewModel.MediaBroadcastWorksheetID, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue) Then

                        MediaBroadcastWorksheetMarketDetailForm.ShowForm(_ViewModel.MediaBroadcastWorksheetID, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                    End If

                    ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.ID

                    'BeginDataUpdate()

                    '_Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                    'LoadGrid()

                    'RefreshDateAndRateColumns()

                    'LoadRevisionNumbers()

                    'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                    '    LoadSharebooks()

                    '    LoadHUTPUTBooks()

                    '    ComboBoxItemSharebook_Sharebook.SelectedIndex = -1
                    '    ComboBoxItemHUTPUT_HUTPUT.SelectedIndex = -1

                    'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                    '    LoadRadioPeriodsBook1()
                    '    LoadRadioPeriodsBook2()
                    '    LoadRadioPeriodsBook3()
                    '    LoadRadioPeriodsBook4()
                    '    LoadRadioPeriodsBook5()

                    '    ComboBoxItemBook1_Book1.ComboBoxEx.SelectedValue = -1
                    '    ComboBoxItemBook2_Book2.ComboBoxEx.SelectedValue = -1
                    '    ComboBoxItemBook3_Book3.ComboBoxEx.SelectedValue = -1
                    '    ComboBoxItemBook4_Book4.ComboBoxEx.SelectedValue = -1
                    '    ComboBoxItemBook5_Book5.ComboBoxEx.SelectedValue = -1

                    'End If

                    'ComboBoxItemSecondaryDemo_SecondaryDemo.SelectedIndex = -1

                    'Me.Text = "Market Schedule - " & _Controller.MarketDetails_LoadWorksheetFullName(_ViewModel)

                    'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                    '    If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                    '        If _ViewModel.SelectedWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                    '            RibbonBarOptions_Display.Text = "Display - Source: " & AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen.ToString

                    '        ElseIf _ViewModel.SelectedWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                    '            RibbonBarOptions_Display.Text = "Display - Source: " & AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan.ToString

                    '        Else

                    '            RibbonBarOptions_Display.Text = "Display"

                    '        End If

                    '    Else

                    '        RibbonBarOptions_Display.Text = "Display"

                    '    End If

                    'Else

                    '    RibbonBarOptions_Display.Text = "Display"

                    'End If

                    'EndDataUpdate()

                    'ExpandAllGroups()

                End If

                'Me.ClearChanged()

                'RefreshViewModel(False)

                'If _ViewModel.SelectedWorksheetMarketShowVendorDemo Then

                '    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)
                '    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)

                'Else

                '    BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)
                '    BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)

                'End If

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                ''BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                'Me.RaiseClearChanged()

                'If _TotalsForm IsNot Nothing Then

                '    _TotalsForm.RefreshLabels()

                'End If

                'If _MeasurementTrendsForm IsNot Nothing Then

                '    _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, False)

                'End If

                'Else

                '    If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                '        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                '        ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.ID

                '        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                '    End If

            End If

        End Sub
        'Private Sub ButtonItemMarkets_Manage_Click(sender As Object, e As EventArgs)

        '    'objects
        '    Dim [Continue] As Boolean = False

        '    CloseGridEditorAndSaveValueToDataSource()

        '    If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

        '        If _ViewModel.SaveEnabled Then

        '            If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

        '                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

        '                _Controller.MarketDetails_Save(_ViewModel)

        '                RefreshMediaBroadcastWorksheetSetupForm()

        '                [Continue] = True

        '                Me.ClearChanged()

        '                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        '                Me.RaiseClearChanged()

        '            End If

        '        Else

        '            [Continue] = True

        '        End If

        '        If [Continue] Then

        '            If MediaBroadcastWorksheetMarketEditDialog.ShowFormDialog(_ViewModel.Worksheet.ID) = Windows.Forms.DialogResult.OK Then

        '                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

        '                BeginDataUpdate()

        '                _Controller.MarketDetails_RefreshWorksheetMarkets(_ViewModel)

        '                _Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

        '                LoadGrid()

        '                'FormatGridPermanentOptions_OnMarketChanged()

        '                LoadRevisionNumbers()

        '                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

        '                    LoadSharebooks()

        '                    LoadHUTPUTBooks()

        '                    ComboBoxItemSharebook_Sharebook.SelectedIndex = -1
        '                    ComboBoxItemHUTPUT_HUTPUT.SelectedIndex = -1

        '                ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

        '                    LoadRadioPeriodsBook1()
        '                    LoadRadioPeriodsBook2()
        '                    LoadRadioPeriodsBook3()
        '                    LoadRadioPeriodsBook4()
        '                    LoadRadioPeriodsBook5()

        '                    ComboBoxItemBook1_Book1.ComboBoxEx.SelectedValue = -1
        '                    ComboBoxItemBook2_Book2.ComboBoxEx.SelectedValue = -1
        '                    ComboBoxItemBook3_Book3.ComboBoxEx.SelectedValue = -1
        '                    ComboBoxItemBook4_Book4.ComboBoxEx.SelectedValue = -1
        '                    ComboBoxItemBook5_Book5.ComboBoxEx.SelectedValue = -1

        '                End If

        '                ComboBoxItemSecondaryDemo_SecondaryDemo.SelectedIndex = -1

        '                Me.Text = "Market Schedule - " & _Controller.MarketDetails_LoadWorksheetFullName(_ViewModel)

        '                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

        '                    If _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

        '                        If _ViewModel.SelectedWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

        '                            RibbonBarOptions_Research.Text = "Research - Source: " & AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen.ToString

        '                        ElseIf _ViewModel.SelectedWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

        '                            RibbonBarOptions_Research.Text = "Research - Source: " & AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan.ToString

        '                        Else

        '                            RibbonBarOptions_Research.Text = "Research"

        '                        End If

        '                    Else

        '                        RibbonBarOptions_Research.Text = "Research"

        '                    End If

        '                Else

        '                    RibbonBarOptions_Research.Text = "Research"

        '                End If

        '                EndDataUpdate()

        '                ExpandAllGroups()

        '                Me.ClearChanged()

        '                RefreshViewModel(True)

        '                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

        '                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

        '                RefreshMediaBroadcastWorksheetSetupForm()

        '                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        '                Me.RaiseClearChanged()

        '                If _TotalsForm IsNot Nothing Then

        '                    _TotalsForm.RefreshLabels()

        '                End If

        '                If _MeasurementTrendsForm IsNot Nothing Then

        '                    _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, False)

        '                End If

        '            End If

        '        End If

        '    End If

        'End Sub
        'Private Sub ButtonItemActions_Goals_Click(sender As Object, e As EventArgs)

        '    'objects
        '    Dim [Continue] As Boolean = False

        '    CloseGridEditorAndSaveValueToDataSource()

        '    If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

        '        If _ViewModel.SaveEnabled Then

        '            If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

        '                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

        '                _Controller.MarketDetails_Save(_ViewModel)

        '                RefreshMediaBroadcastWorksheetSetupForm()

        '                [Continue] = True

        '                Me.ClearChanged()

        '                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        '                Me.RaiseClearChanged()

        '            End If

        '        Else

        '            [Continue] = True

        '        End If

        '        If [Continue] Then

        '            If MediaBroadcastWorksheetMarketGoalDialog.ShowFormDialog(_ViewModel.Worksheet.ID, _ViewModel.SelectedWorksheetMarket.ID) = System.Windows.Forms.DialogResult.OK Then

        '                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

        '                BeginDataUpdate()

        '                _Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

        '                LoadGrid()

        '                EndDataUpdate()

        '                ExpandAllGroups()

        '                Me.ClearChanged()

        '                RefreshViewModel(False)

        '                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

        '                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

        '                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        '                Me.RaiseClearChanged()

        '            End If

        '        End If

        '    End If

        'End Sub
        Private Sub ButtonItemSchedule_SelectVendors_Click(sender As Object, e As EventArgs) Handles ButtonItemVendors_Manage.Click

            'objects
            Dim [Continue] As Boolean = False

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If MediaBroadcastWorksheetMarketManageVendorsDialog.ShowFormDialog(_ViewModel.Worksheet.ID, _ViewModel.SelectedWorksheetMarket.ID, _ViewModel.SelectedWorksheetMarketRevisionNumber) = System.Windows.Forms.DialogResult.OK Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        If _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                            CacheComscoreData()

                        End If

                        BeginDataUpdate()

                        _Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                        LoadGrid()

                        If _ViewModel.DoesWorksheetAllowSubmarkets Then

                            FormatGridSubmarketBands()

                            Submarkets_Setup()

                        End If

                        EndDataUpdate()

                        ExpandAllGroups()

                        Me.ClearChanged()

                        RefreshViewModel(False)

                        BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                        'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSchedule_OrderComments_Click(sender As Object, e As EventArgs) Handles ButtonItemSchedule_OrderComments.Click

            'objects
            Dim MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel = _Controller.MarketVendorOrderComments_Load(_ViewModel)

            If MediaBroadcastWorksheetMarketVendorOrderCommentsDialog.ShowFormDialog(MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel, _ViewModel) = System.Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                BeginDataUpdate()

                _Controller.MarketVendorOrderComments_Update(MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel, _ViewModel)

                EndDataUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonItemSchedule_Books_Click(sender As Object, e As EventArgs) Handles ButtonItemSchedule_Books.Click, ButtonItemSchedule_Books2.Click

            'objects
            Dim [Continue] As Boolean = False

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                        Media.Presentation.MediaBroadcastWorksheetMarketNielsenTVBooksDialog.ShowFormDialog(_ViewModel.MediaBroadcastWorksheetID, _ViewModel.SelectedWorksheetMarket.ID)

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        If _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                            CacheComscoreData()

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                        Media.Presentation.MediaBroadcastWorksheetMarketNielsenRadioPeriodsDialog.ShowFormDialog(_ViewModel.MediaBroadcastWorksheetID, _ViewModel.SelectedWorksheetMarket.ID)

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    BeginDataUpdate()

                    _Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                    LoadGrid()

                    ExpandAllGroups()

                    EndDataUpdate()

                    Me.ClearChanged()

                    RefreshViewModel(False)

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.CurrentView.GridViewSelectionChanged()

                    Me.RaiseClearChanged()

                End If

            End If

        End Sub
        Private Sub ComboBoxItemSharebook_Sharebook_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemSharebook_Sharebook.SelectedIndexChanged

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                If AdvantageFramework.WinForm.MessageBox.Show(Me,
                                                              "WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." & vbNewLine & vbNewLine & "Are you sure you want to continue?",
                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)), System.Data.DataRowView).Row

                        RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    End If

                    BeginDataUpdate()

                    If _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        _Controller.MarketDetails_ShareBookSelectionChanged(_ViewModel, ComboBoxItemSharebook_Sharebook.ComboBoxEx.SelectedValue)

                        CacheComscoreData()

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading, "Loading...")

                    _Controller.MarketDetails_ShareBookSelectionChanged(_ViewModel, ComboBoxItemSharebook_Sharebook.ComboBoxEx.SelectedValue, RowIndex)

                    EndDataUpdate()

                    LoadHUTPUTBooks()

                    ComboBoxItemSharebook_Sharebook.SelectedIndex = -1
                    ComboBoxItemHUTPUT_HUTPUT.SelectedIndex = -1

                    RefreshViewModel(False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Recalculating)

                    BandedDataGridViewForm_MarketDetails.ValidateAllRows()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                        If DataRow IsNot Nothing Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxItemSharebook_Sharebook.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.SharebookNielsenTVBookID.GetValueOrDefault(0)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ComboBoxItemHUTPUT_HUTPUT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemHUTPUT_HUTPUT.SelectedIndexChanged

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." & vbNewLine & vbNewLine & "Are you sure you want to continue?",
                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)), System.Data.DataRowView).Row

                        RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    End If

                    BeginDataUpdate()

                    If _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        _Controller.MarketDetails_HUTPUTBookSelectionChanged(_ViewModel, ComboBoxItemHUTPUT_HUTPUT.ComboBoxEx.SelectedValue)

                        CacheComscoreData()

                    End If

                    _Controller.MarketDetails_HUTPUTBookSelectionChanged(_ViewModel, ComboBoxItemHUTPUT_HUTPUT.ComboBoxEx.SelectedValue, RowIndex)

                    EndDataUpdate()

                    'ComboBoxItemSharebook_Sharebook.SelectedIndex = -1
                    ComboBoxItemHUTPUT_HUTPUT.SelectedIndex = -1

                    RefreshViewModel(False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                        If DataRow IsNot Nothing Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxItemHUTPUT_HUTPUT.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.HUTPUTNielsenTVBookID.GetValueOrDefault(0)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ComboBoxItemBook1_Book1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemBook1_Book1.SelectedIndexChanged

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." & vbNewLine & vbNewLine & "Are you sure you want to continue?",
                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)), System.Data.DataRowView).Row

                        RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    End If

                    BeginDataUpdate()

                    _Controller.MarketDetails_NielsenRadioBook1Changed(_ViewModel, ComboBoxItemBook1_Book1.ComboBoxEx.SelectedValue, RowIndex)

                    EndDataUpdate()

                    LoadRadioPeriodsBook1()
                    LoadRadioPeriodsBook2()
                    LoadRadioPeriodsBook3()
                    LoadRadioPeriodsBook4()
                    LoadRadioPeriodsBook5()

                    ComboBoxItemBook1_Book1.SelectedIndex = -1
                    ComboBoxItemBook2_Book2.SelectedIndex = -1
                    ComboBoxItemBook3_Book3.SelectedIndex = -1
                    ComboBoxItemBook4_Book4.SelectedIndex = -1
                    ComboBoxItemBook5_Book5.SelectedIndex = -1

                    RefreshViewModel(False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Recalculating)

                    BandedDataGridViewForm_MarketDetails.ValidateAllRows()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                        If DataRow IsNot Nothing Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxItemBook1_Book1.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID1.GetValueOrDefault(0)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ComboBoxItemBook2_Book2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemBook2_Book2.SelectedIndexChanged

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." & vbNewLine & vbNewLine & "Are you sure you want to continue?",
                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)), System.Data.DataRowView).Row

                        RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    End If

                    BeginDataUpdate()

                    _Controller.MarketDetails_NielsenRadioBook2Changed(_ViewModel, ComboBoxItemBook2_Book2.ComboBoxEx.SelectedValue, RowIndex)

                    EndDataUpdate()

                    LoadRadioPeriodsBook1()
                    LoadRadioPeriodsBook2()
                    LoadRadioPeriodsBook3()
                    LoadRadioPeriodsBook4()
                    LoadRadioPeriodsBook5()

                    ComboBoxItemBook1_Book1.SelectedIndex = -1
                    ComboBoxItemBook2_Book2.SelectedIndex = -1
                    ComboBoxItemBook3_Book3.SelectedIndex = -1
                    ComboBoxItemBook4_Book4.SelectedIndex = -1
                    ComboBoxItemBook5_Book5.SelectedIndex = -1

                    RefreshViewModel(False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                        If DataRow IsNot Nothing Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxItemBook2_Book2.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID2.GetValueOrDefault(0)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ComboBoxItemBook3_Book3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemBook3_Book3.SelectedIndexChanged

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." & vbNewLine & vbNewLine & "Are you sure you want to continue?",
                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)), System.Data.DataRowView).Row

                        RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    End If

                    BeginDataUpdate()

                    _Controller.MarketDetails_NielsenRadioBook3Changed(_ViewModel, ComboBoxItemBook3_Book3.ComboBoxEx.SelectedValue, RowIndex)

                    EndDataUpdate()

                    LoadRadioPeriodsBook1()
                    LoadRadioPeriodsBook2()
                    LoadRadioPeriodsBook3()
                    LoadRadioPeriodsBook4()
                    LoadRadioPeriodsBook5()

                    ComboBoxItemBook1_Book1.SelectedIndex = -1
                    ComboBoxItemBook2_Book2.SelectedIndex = -1
                    ComboBoxItemBook3_Book3.SelectedIndex = -1
                    ComboBoxItemBook4_Book4.SelectedIndex = -1
                    ComboBoxItemBook5_Book5.SelectedIndex = -1

                    RefreshViewModel(False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                        If DataRow IsNot Nothing Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxItemBook3_Book3.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID3.GetValueOrDefault(0)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ComboBoxItemBook4_Book4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemBook4_Book4.SelectedIndexChanged

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." & vbNewLine & vbNewLine & "Are you sure you want to continue?",
                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)), System.Data.DataRowView).Row

                        RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    End If

                    BeginDataUpdate()

                    _Controller.MarketDetails_NielsenRadioBook4Changed(_ViewModel, ComboBoxItemBook4_Book4.ComboBoxEx.SelectedValue, RowIndex)

                    EndDataUpdate()

                    LoadRadioPeriodsBook1()
                    LoadRadioPeriodsBook2()
                    LoadRadioPeriodsBook3()
                    LoadRadioPeriodsBook4()
                    LoadRadioPeriodsBook5()

                    ComboBoxItemBook1_Book1.SelectedIndex = -1
                    ComboBoxItemBook2_Book2.SelectedIndex = -1
                    ComboBoxItemBook3_Book3.SelectedIndex = -1
                    ComboBoxItemBook4_Book4.SelectedIndex = -1
                    ComboBoxItemBook5_Book5.SelectedIndex = -1

                    RefreshViewModel(False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                        If DataRow IsNot Nothing Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxItemBook4_Book4.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID4.GetValueOrDefault(0)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ComboBoxItemBook5_Book5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemBook5_Book5.SelectedIndexChanged

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." & vbNewLine & vbNewLine & "Are you sure you want to continue?",
                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)), System.Data.DataRowView).Row

                        RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    End If

                    BeginDataUpdate()

                    _Controller.MarketDetails_NielsenRadioBook5Changed(_ViewModel, ComboBoxItemBook5_Book5.ComboBoxEx.SelectedValue, RowIndex)

                    EndDataUpdate()

                    LoadRadioPeriodsBook1()
                    LoadRadioPeriodsBook2()
                    LoadRadioPeriodsBook3()
                    LoadRadioPeriodsBook4()
                    LoadRadioPeriodsBook5()

                    ComboBoxItemBook1_Book1.SelectedIndex = -1
                    ComboBoxItemBook2_Book2.SelectedIndex = -1
                    ComboBoxItemBook3_Book3.SelectedIndex = -1
                    ComboBoxItemBook4_Book4.SelectedIndex = -1
                    ComboBoxItemBook5_Book5.SelectedIndex = -1

                    RefreshViewModel(False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible Then

                        If DataRow IsNot Nothing Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxItemBook5_Book5.ComboBoxEx.SelectedValue = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID5.GetValueOrDefault(0)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonItemResearch_Trends_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemResearch_Trends.CheckedChanged, ButtonItemResearch_Trends2.CheckedChanged

            'objects
            Dim RowIndex As Integer = -1
            Dim DataRow As System.Data.DataRow = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If CType(sender, DevComponents.DotNetBar.ButtonItem).Checked Then

                    If _MeasurementTrendsForm.FormShown = False OrElse _MeasurementTrendsForm.Visible = False Then

                        If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)) Then

                            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows(0)), System.Data.DataRowView).Row

                            RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                        End If

                        If DataRow IsNot Nothing Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                                   DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                    _MeasurementTrendsForm.Show(False)

                Else

                    _MeasurementTrendsForm.Hide()

                End If

            End If

        End Sub
        Private Sub ButtonItemDisplay_Summaries_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDisplay_Summaries.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ButtonItemDisplay_Summaries.Checked Then

                    _TotalsForm.Show(False)

                Else

                    _TotalsForm.Hide()

                End If

            End If

        End Sub
        Private Sub ButtonItemDisplay_ShowTotals_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDisplay_ShowTotals.CheckedChanged

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                FormatGrid_ShowSummary(ButtonItemDisplay_ShowTotals.Checked)

                BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                BandedDataGridViewForm_MarketDetails.CurrentView.Tag = ButtonItemDisplay_ShowTotals.Checked

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                OnBestFitAllDateColumns(sender, e)

                BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

            End If

        End Sub
        Private Sub ButtonItemDisplay_HideZeroSpotLines_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDisplay_HideZeroSpotLines.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                _Controller.MarketDetails_HideZeroSpotLinesChanged(_ViewModel, ButtonItemDisplay_HideZeroSpotLines.Checked)

                BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.ShowHideZeroSpotLines()

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ButtonItemDisplay_WeeklyRates_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDisplay_WeeklyRates.CheckedChanged

            'objects
            'Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()
                BeginDataUpdate()

                ShowHideDates()

                EndDataUpdate()
                BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

            'BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

            'For Each RateDate In _ViewModel.RateDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

            '    GridColumn = BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.RateDates(RateDate).ToString)

            '    If ButtonItemDisplay_WeeklyRates.Checked Then

            '        If _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName.Replace("Rate", "Date")) = False Then

            '            GridColumn.Visible = True

            '        Else

            '            GridColumn.Visible = False

            '        End If

            '    Else

            '        GridColumn.Visible = False

            '    End If

            '    If GridColumn.Visible Then

            '        GridColumn.BestFit()

            '    End If

            'Next

            'BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

        End Sub
        Private Sub ButtonItemSchedule_ShowVendorDemos_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSchedule_ShowVendorDemos.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.MarketDetails_SelectedWorksheetMarketShowVendorDemoChanged(_ViewModel, ButtonItemSchedule_ShowVendorDemos.Checked)

                If _ViewModel.SelectedWorksheetMarketShowVendorDemo Then

                    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)
                    BandedDataGridViewForm_MarketDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)

                Else

                    BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)
                    BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If _ViewModel.IsMaxRevisionNumber Then

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemSchedule_ViewOrderDetails_Click(sender As Object, e As EventArgs) Handles ButtonItemSchedule_ViewOrderDetails.Click

            Media.Presentation.MediaBroadcastWorksheetOrderDataDialog.ShowFormDialog(_ViewModel.Worksheet.ID, _ViewModel.SelectedWorksheetMarket.ID, _ViewModel.SelectedWorksheetMarketRevisionNumber)

        End Sub
        Private Sub ButtonItemVendors_RFP_Click(sender As Object, e As EventArgs) Handles ButtonItemVendors_RFP.Click

            'objects
            Dim [Continue] As Boolean = False

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If AdvantageFramework.Media.Presentation.MediaRequestForProposalDialog.ShowFormDialog(_ViewModel.SelectedWorksheetMarket.ID) = Windows.Forms.DialogResult.OK Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        BeginDataUpdate()

                        _Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                        LoadGrid()

                        EndDataUpdate()

                        ExpandAllGroups()

                        Me.ClearChanged()

                        RefreshViewModel(False)

                        BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                        'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSchedule_RefreshDemos_Click(sender As Object, e As EventArgs) Handles ButtonItemSchedule_RefreshDemos.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                If _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    CacheComscoreData()

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Recalculating)

                _Controller.MarketDetails_Recalculate(_ViewModel)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                If _ViewModel.IsMaxRevisionNumber Then

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                End If

            End If

        End Sub

        Private Sub ButtonItemDates_Show_Click(sender As Object, e As EventArgs) Handles ButtonItemDates_Show.Click

            'objects
            Dim Counter As Integer = 0
            Dim DateNumber As Integer = 0
            Dim StartDateNumber As Integer = 0
            Dim EndDateNumber As Integer = 0

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                StartDateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ComboBoxItemDates_StartDate.ComboBoxEx.SelectedValue, "0")
                EndDateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ComboBoxItemDates_EndDate.ComboBoxEx.SelectedValue, "0")

                If EndDateNumber < StartDateNumber Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a valid start and end date.")

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                    _Controller.MarketDetails_SaveDateSelections(_ViewModel, ComboBoxItemDates_StartDate.ComboBoxEx.SelectedValue, ComboBoxItemDates_EndDate.ComboBoxEx.SelectedValue)

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()
                    BeginDataUpdate()

                    ShowHideDates()

                    EndDataUpdate()
                    BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonItemDates_ShowAll_Click(sender As Object, e As EventArgs) Handles ButtonItemDates_ShowAll.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                ComboBoxItemDates_StartDate.ComboBoxEx.SelectedValue = _ViewModel.DateSelections(0).Value
                ComboBoxItemDates_EndDate.ComboBoxEx.SelectedValue = _ViewModel.DateSelections(_ViewModel.DateSelections.Count - 1).Value

                _Controller.MarketDetails_SaveDateSelections(_ViewModel, ComboBoxItemDates_StartDate.ComboBoxEx.SelectedValue, ComboBoxItemDates_EndDate.ComboBoxEx.SelectedValue)

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()
                BeginDataUpdate()

                ShowHideDates()

                EndDataUpdate()
                BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ButtonItemDates_HideHiatusDates_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDates_HideHiatusDates.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                _Controller.MarketDetails_SaveHideHiatusDatesSetting(_ViewModel, ButtonItemDates_HideHiatusDates.Checked)

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()
                BeginDataUpdate()

                ShowHideDates()

                EndDataUpdate()
                BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub

        Private Sub ButtonItemActions_AddRow_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AddRow.Click

            'objects
            Dim VendorCode As String = String.Empty
            Dim GroupRowHandle As Integer = -1
            Dim RowHandle As Integer = -1

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

            If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                VendorCode = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, 0), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            Else

                VendorCode = BandedDataGridViewForm_MarketDetails.GetFirstSelectedRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            End If

            BeginDataUpdate()

            _Controller.MarketDetails_AddNewDataEntryRow(_ViewModel, VendorCode)

            RefreshViewModel(False)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

            EndDataUpdate()

            If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                RowHandle = BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) - 1)

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginSelection()

                BandedDataGridViewForm_MarketDetails.SelectOnlyThisRow(RowHandle)

                BandedDataGridViewForm_MarketDetails.CurrentView.EndSelection()

                For Each BandedGridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString).Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ToList

                    If BandedGridColumn.Visible Then

                        BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn = BandedGridColumn
                        Exit For

                    End If

                Next

            Else

                GroupRowHandle = BandedDataGridViewForm_MarketDetails.CurrentView.GetParentRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle)

                If GroupRowHandle <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then

                    RowHandle = BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(GroupRowHandle, BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(GroupRowHandle) - 1)

                    If RowHandle > 0 Then

                        BandedDataGridViewForm_MarketDetails.CurrentView.BeginSelection()

                        BandedDataGridViewForm_MarketDetails.SelectOnlyThisRow(RowHandle)

                        BandedDataGridViewForm_MarketDetails.CurrentView.EndSelection()

                        For Each BandedGridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString).Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ToList

                            If BandedGridColumn.Visible Then

                                BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn = BandedGridColumn
                                Exit For

                            End If

                        Next

                    End If

                End If

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_DeleteRow_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_DeleteRow.Click

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Message As String = String.Empty
            Dim HasSelectedMakegoodLine As Boolean = False
            Dim ID As Integer = 0
            Dim LineNumber As Integer = 0
            Dim MakegoodNumber As Integer = 0
            Dim CanDeleteRows As Boolean = True
            Dim VendorCode As String = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            RowIndexes = New Generic.List(Of Integer)

            If BandedDataGridViewForm_MarketDetails.HasOnlyDataRowsSelected Then

                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) > 0 OrElse
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) > 0 Then

                        HasSelectedMakegoodLine = True

                    End If

                Next

            ElseIf BandedDataGridViewForm_MarketDetails.HasOnlyGroupRowsSelected Then

                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                    For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(RowHandle) - 1

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(RowHandle, RowIndex)), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) > 0 OrElse
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) > 0 Then

                            HasSelectedMakegoodLine = True

                        End If

                    Next

                Next

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                    For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) - 1

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, RowIndex)), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) > 0 OrElse
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) > 0 Then

                            HasSelectedMakegoodLine = True

                        End If

                    Next

                Else

                    For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) > 0 OrElse
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) > 0 Then

                            HasSelectedMakegoodLine = True

                        End If

                    Next

                End If

            Else

                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                    If BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(RowHandle) Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) > 0 OrElse
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) > 0 Then

                            HasSelectedMakegoodLine = True

                        End If

                    End If

                Next

            End If

            For Each RowIndex In RowIndexes

                DataRow = _ViewModel.DataTable.Rows(RowIndex)

                ID = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)
                VendorCode = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)
                LineNumber = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString)
                MakegoodNumber = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString)

                If MakegoodNumber = 0 Then

                    If _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString) <> ID AndAlso
                                                                                                 DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = VendorCode AndAlso
                                                                                                 DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString) = LineNumber) Then

                        CanDeleteRows = False

                    End If

                Else

                    If _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString) <> ID AndAlso
                                                                                                 DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = VendorCode AndAlso
                                                                                                 DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString) = LineNumber AndAlso
                                                                                                 DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) = MakegoodNumber) Then

                        CanDeleteRows = False

                    End If

                End If

                If CanDeleteRows = False Then

                    Exit For

                End If

            Next

            If CanDeleteRows Then

                Message = "Are you sure you want to delete selected row(s)?"

                If HasSelectedMakegoodLine Then

                    Message = "The selected makegood line will be removed and its spots added back to the original line/date." & System.Environment.NewLine & System.Environment.NewLine & Message

                End If

                If AdvantageFramework.WinForm.MessageBox.Show(Message, AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    BeginDataUpdate()

                    _Controller.MarketDetails_DeleteDataEntryRow(_ViewModel, RowIndexes.ToArray)

                    EndDataUpdate()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                    BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                    'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                    BandedDataGridViewForm_MarketDetails.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("This line contains makegoods.  Please delete lines individually starting with the latest makegood in order to properly delete and restore the original spots.")

            End If

        End Sub
        Private Sub ButtonItemActions_CopyRow_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CopyRow.Click

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim GroupRowHandle As Integer = -1
            Dim RowHandle As Integer = -1

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Copying)

            RowIndexes = New Generic.List(Of Integer)

            If BandedDataGridViewForm_MarketDetails.HasOnlyDataRowsSelected Then

                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                Next

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                    For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) - 1

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, RowIndex)), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    Next

                Else

                    For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    Next

                End If

            Else

                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                    If BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(RowHandle) Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    End If

                Next

            End If

            BeginDataUpdate()

            _Controller.MarketDetails_CopyDataEntryRows(_ViewModel, RowIndexes.ToArray)

            RefreshViewModel(False)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Recalculating

            BandedDataGridViewForm_MarketDetails.CurrentView.ValidateAllRows()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

            EndDataUpdate()

            If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                    RowHandle = BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) - 1)

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginSelection()

                    BandedDataGridViewForm_MarketDetails.SelectOnlyThisRow(RowHandle)

                    BandedDataGridViewForm_MarketDetails.CurrentView.EndSelection()

                    For Each BandedGridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString).Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ToList

                        If BandedGridColumn.Visible Then

                            BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn = BandedGridColumn
                            Exit For

                        End If

                    Next

                Else

                    BandedDataGridViewForm_MarketDetails.CurrentView.BeginSelection()

                    BandedDataGridViewForm_MarketDetails.SelectOnlyThisRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle + 1)

                    BandedDataGridViewForm_MarketDetails.CurrentView.EndSelection()

                    For Each BandedGridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString).Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ToList

                        If BandedGridColumn.Visible Then

                            BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn = BandedGridColumn
                            Exit For

                        End If

                    Next

                End If

            End If

            Me.CloseWaitForm()

        End Sub

        Private Sub ButtonItemDemos_ShowPrimary_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDemos_ShowPrimary.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.MarketDetails_ShowPrimaryDemosChanged(_ViewModel, ButtonItemDemos_ShowPrimary.Checked)

                RefreshViewModel(False)

                GridBandVisibleChanged(GridBandNames.GridBandPrimaryDemo, ButtonItemDemos_ShowPrimary.Checked)

                Submarkets_SetupPrimary()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If _ViewModel.IsMaxRevisionNumber Then

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            End If

        End Sub
        Private Sub ButtonItemDemos_ShowSecondary_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDemos_ShowSecondary.CheckedChanged

            'objects
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.MarketDetails_ShowSecondaryDemosChanged(_ViewModel, ButtonItemDemos_ShowSecondary.Checked)

                RefreshViewModel(False)

                GridBandVisibleChanged(GridBandNames.GridBandSecondaryDemo, ButtonItemDemos_ShowSecondary.Checked)

                Submarkets_SetupSecondary()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If _ViewModel.IsMaxRevisionNumber Then

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            End If

        End Sub
        Private Sub ComboBoxItemSecondaryDemo_SecondaryDemo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemSecondaryDemo_SecondaryDemo.SelectedIndexChanged

            'objects
            Dim ShowSecondary As Boolean = False
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                If _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    _Controller.MarketDetails_SetSelectedWorksheetMarketSecondaryDemo(_ViewModel, ComboBoxItemSecondaryDemo_SecondaryDemo.ComboBoxEx.SelectedValue)

                    CacheComscoreData()

                    'Else

                    '    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                End If

                BeginDataUpdate()

                _Controller.MarketDetails_SelectedWorksheetMarketSecondaryDemoChanged(_ViewModel, ComboBoxItemSecondaryDemo_SecondaryDemo.ComboBoxEx.SelectedValue)

                EndDataUpdate()

                ShowSecondary = ButtonItemDemos_ShowSecondary.Checked

                ComboBoxItemSecondaryDemo_SecondaryDemo.SelectedIndex = -1

                RefreshViewModel(False)

                GridBandVisibleChanged(GridBandNames.GridBandSecondaryDemo, ButtonItemDemos_ShowSecondary.Checked)

                Submarkets_SetupSecondary()

                If _ViewModel.HasASelectedWorksheetSecondaryDemo Then

                    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondaryDemo.ToString)

                    If GridBand IsNot Nothing Then

                        GridBand.Caption = _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicDescription

                    End If

                    GridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondarySubmarketDemo.ToString)

                    If GridBand IsNot Nothing Then

                        GridBand.Caption = _ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicDescription

                    End If

                    If _SubmarketsForm IsNot Nothing Then

                        _SubmarketsForm.SetSecondaryDemoCaption(_ViewModel.SelectedWorksheetMarketSecondaryDemo.MediaDemographicDescription)

                    End If

                End If

                If _ViewModel.IsMaxRevisionNumber AndAlso ShowSecondary <> ButtonItemDemos_ShowSecondary.Checked Then

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub ButtonItemSubmarkets_Show_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSubmarkets_Show.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                CloseGridEditorAndSaveValueToDataSource()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                'ButtonItemSubmarkets_Ratings.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_GRP.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_IMP.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_GIMP.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_Allocation.Enabled = ButtonItemSubmarkets_Show.Checked
                'ButtonItemSubmarkets_Percentage.Enabled = ButtonItemSubmarkets_Show.Checked

                If ButtonItemSubmarkets_Show.Checked Then

                    _SubmarketsForm.Show(False)

                    If _HasShownSubmarketForm = False Then

                        _SubmarketsForm.ShowHidePrimaryDemo(ButtonItemDemos_ShowPrimary.Checked)
                        _SubmarketsForm.ShowHideSecondaryDemo(ButtonItemDemos_ShowSecondary.Checked)
                        _SubmarketsForm.FilterChanged()
                        _SubmarketsForm.UpdateSorting(BandedDataGridViewForm_MarketDetails.CurrentView.SortInfo)
                        _SubmarketsForm.EnableDisableGrouping(BandedDataGridViewForm_MarketDetails.CurrentView.GroupedColumns.Any)

                    End If

                Else

                    _SubmarketsForm.Hide()

                End If

                'Submarkets_Setup()

                'BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                _HasShownSubmarketForm = True

            End If

        End Sub

        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            _Controller.MarketDetails_ChooseColumnsChanged(_ViewModel, ButtonItemGridOptions_ChooseColumns.Checked)

            RefreshViewModel(False)

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.CustomizationForm Is Nothing Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.ShowCustomization()

                End If

            Else

                If BandedDataGridViewForm_MarketDetails.CurrentView.CustomizationForm IsNot Nothing Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.DestroyCustomization()

                End If

            End If

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

            BandedDataGridViewForm_MarketDetails.ClearGridCustomization()

            LoadGrid()

            FormatGridOriginalState()
            FormatGridPermanentOptions()

            If _ViewModel.DoesWorksheetAllowSubmarkets Then

                FormatGridSubmarketBands()

                Submarkets_Setup()

            End If

            ShowHideDates()

            _Controller.MarketDetails_ShowPrimaryDemosChanged(_ViewModel, ButtonItemDemos_ShowPrimary.Checked)
            _Controller.MarketDetails_ShowSecondaryDemosChanged(_ViewModel, ButtonItemDemos_ShowSecondary.Checked)

            RefreshViewModel(False)

            GridBandVisibleChanged(GridBandNames.GridBandPrimaryDemo, ButtonItemDemos_ShowPrimary.Checked)
            GridBandVisibleChanged(GridBandNames.GridBandSecondaryDemo, ButtonItemDemos_ShowSecondary.Checked)

            ExpandAllGroups()

            _ViewModel.FilterString = BandedDataGridViewForm_MarketDetails.CurrentView.ActiveFilterString

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.ShowHidePrimaryDemo(ButtonItemDemos_ShowPrimary.Checked)
                _SubmarketsForm.ShowHideSecondaryDemo(ButtonItemDemos_ShowSecondary.Checked)
                _SubmarketsForm.FilterChanged()
                _SubmarketsForm.UpdateSorting(BandedDataGridViewForm_MarketDetails.CurrentView.SortInfo)
                _SubmarketsForm.SelectedRowChanged(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows)

            End If

            BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            If ButtonItemDisplay_ShowTotals.Checked = False Then

                FormatGrid_ShowSummary(ButtonItemDisplay_ShowTotals.Checked)

            End If

            'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

        End Sub

        Private Sub ButtonItemOrders_Create_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_Create.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel = Nothing
            'Dim VendorNames As IEnumerable(Of String) = Nothing
            'Dim VendorNamesWithPendingMakegoodOffers As Generic.List(Of String) = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    'VendorNames = _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(F) F.RowState <> DataRowState.Unchanged).Select(Function(F) F.Item(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).ToString).Distinct.ToArray

                    'VendorNamesWithPendingMakegoodOffers = New Generic.List(Of String)

                    'For Each VendorName In VendorNames

                    '    If _ViewModel.WorksheetMarketDetailVendorMakegoodStatuses.Where(Function(Entity) Entity.VendorName = VendorName AndAlso
                    '                                                                                     Entity.Status = Database.Entities.OrderStatusType.MakegoodOfferSubmitted).Any Then

                    '        VendorNamesWithPendingMakegoodOffers.Add(VendorName)

                    '    End If

                    'Next

                    'If VendorNamesWithPendingMakegoodOffers.Count > 0 Then

                    '    AdvantageFramework.WinForm.MessageBox.Show("The following vendors have makegood offers pending and will be omitted: " & String.Join(", ", VendorNamesWithPendingMakegoodOffers.ToArray))

                    'End If

                    If MediaBroadcastWorksheetMarketDetailCreateOrdersDialog.ShowFormDialog(_ViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel) = System.Windows.Forms.DialogResult.OK Then

                        ContinueToCreateOrders(MediaBroadcastWorksheetMarketCreateOrdersViewModel, False, False, Nothing, Nothing)

                    End If

                End If

            End If

        End Sub
        'Private Sub ButtonItemOrder_Status_Click(sender As Object, e As EventArgs) Handles ButtonItemOrder_Status.Click

        '    AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetOrderStatusDialog.ShowFormDialog(_ViewModel.Worksheet.MediaType, _ViewModel.SelectedWorksheetMarket.ID, _ViewModel.SelectedWorksheetMarketRevisionNumber)

        'End Sub
        Private Sub ButtonItemOrders_CreateForSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_CreateForSelected.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If MediaBroadcastWorksheetMarketDetailCreateOrdersDialog.ShowFormDialog(_ViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel) = System.Windows.Forms.DialogResult.OK Then
                        '===================
                        RowIndexes = New Generic.List(Of Integer)

                        If BandedDataGridViewForm_MarketDetails.HasOnlyDataRowsSelected Then

                            For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                                RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            Next

                        ElseIf BandedDataGridViewForm_MarketDetails.HasOnlyGroupRowsSelected Then

                            For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                                For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(RowHandle) - 1

                                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(RowHandle, RowIndex)), System.Data.DataRowView).Row

                                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                                Next

                            Next

                        ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                            If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                                For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) - 1

                                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, RowIndex)), System.Data.DataRowView).Row

                                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                                Next

                            Else

                                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                                Next

                            End If

                        Else

                            For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                                If BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(RowHandle) Then

                                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                                End If

                            Next

                        End If

                        If CreateOrders(MediaBroadcastWorksheetMarketCreateOrdersViewModel, RowIndexes, False, False) Then

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                            RefreshMediaBroadcastWorksheetSetupForm()

                            BeginDataUpdate()

                            _Controller.MarketDetails_RefreshWorksheetMarkets(_ViewModel)

                            _Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                            LoadGrid()

                            Me.ClearChanged()

                            RefreshViewModel(False)

                            ExpandAllGroups()

                            EndDataUpdate()

                            BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                            'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                            RefreshVendorStatus()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                            BandedDataGridViewForm_MarketDetails.GridViewSelectionChanged()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemOrders_Generate_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_Generate.Click

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim HasGroupRowSelected As Boolean = False
            Dim MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing

            RowIndexes = New Generic.List(Of Integer)

            If BandedDataGridViewForm_MarketDetails.HasOnlyDataRowsSelected Then

                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                Next

            ElseIf BandedDataGridViewForm_MarketDetails.HasOnlyGroupRowsSelected Then

                HasGroupRowSelected = True

                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                    For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(RowHandle) - 1

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(RowHandle, RowIndex)), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    Next

                Next

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                    HasGroupRowSelected = True

                    For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) - 1

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, RowIndex)), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    Next

                Else

                    For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    Next

                End If

            Else

                For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                    If BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(RowHandle) Then

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                    ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(RowHandle) Then

                        HasGroupRowSelected = True

                    End If

                Next

            End If

            If RowIndexes IsNot Nothing AndAlso RowIndexes.Count > 0 Then

                If ShowMediaManagerReviewDialog(RowIndexes) Then

                    RefreshVendorStatus()

                End If

            End If

        End Sub
        Private Sub ButtonItemExport_Proposal_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_Proposal.Click

            ExportProposal(False)

        End Sub
        Private Sub ButtonItemExport_ProposalRatesSuppressed_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_ProposalRatesSuppressed.Click

            ExportProposal(True)

        End Sub
        Private Sub ButtonItemExport_Schedule_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_Schedule.Click

            'objects
            Dim SaveFileDialog As System.Windows.Forms.SaveFileDialog
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DefaultFileName As String = ""
            Dim KeepLoading As Boolean = True
            Dim IsAsp As Boolean = False
            Dim [Continue] As Boolean = False

            If _ViewModel IsNot Nothing AndAlso _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.SelectedWorksheetMarket IsNot Nothing Then

                CloseGridEditorAndSaveValueToDataSource()

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.Worksheet.Name) & ".xls"

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

                            Me.ShowWaitForm("Please wait...")

                            Try

                                If _Controller.Report_Generate(Me.Session, DefaultFileName, _ViewModel.Worksheet,
                                                               New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)({_ViewModel.SelectedWorksheetMarket}), _ViewModel.WorksheetPrintOptions) Then

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

            End If

        End Sub
        Private Sub ButtonItemPrint_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_Settings.Click

            'objects
            Dim WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions = Nothing

            WorksheetPrintOptions = _ViewModel.WorksheetPrintOptions

            If AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetPrintingOptionsDialog.ShowFormDialog(WorksheetPrintOptions) = System.Windows.Forms.DialogResult.OK Then

                _ViewModel.WorksheetPrintOptions = WorksheetPrintOptions

                _Controller.SaveWorksheetPrintOptions(_ViewModel.WorksheetPrintOptions)

                UpdateWorksheetSetupFormWorksheetPrintOptions()

            End If

        End Sub

        Private Sub BandedDataGridViewForm_MarketDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.SelectionChangedEvent

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim HasGroupRowSelected As Boolean = False
            Dim GridCells As DevExpress.XtraGrid.Views.Base.GridCell() = Nothing
            Dim CellCount As Integer = 0

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect Then

                    GridCells = BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedCells()
                    CellCount = GridCells.Length

                    For i As Integer = 0 To CellCount - 1

                        If GridCells(i).Column.FieldName.StartsWith("Date") = False Then

                            BandedDataGridViewForm_MarketDetails.CurrentView.UnselectCell(GridCells(i))

                        Else

                            If _ViewModel.HiatusDataTable.Rows.Count > 0 AndAlso _ViewModel.HiatusDataTable.Rows(0)(GridCells(i).Column.FieldName) Then

                                BandedDataGridViewForm_MarketDetails.CurrentView.UnselectCell(GridCells(i))

                            End If

                        End If

                    Next

                Else

                    RowIndexes = New Generic.List(Of Integer)

                    If BandedDataGridViewForm_MarketDetails.HasOnlyDataRowsSelected Then

                        For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                            RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                        Next

                    ElseIf BandedDataGridViewForm_MarketDetails.HasOnlyGroupRowsSelected Then

                        HasGroupRowSelected = True

                        For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                            For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(RowHandle) - 1

                                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(RowHandle, RowIndex)), System.Data.DataRowView).Row

                                RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            Next

                        Next

                    ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                            HasGroupRowSelected = True

                            For RowIndex As Integer = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) - 1

                                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, RowIndex)), System.Data.DataRowView).Row

                                RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            Next

                        Else

                            For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                                RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            Next

                        End If

                    Else

                        For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                            If BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(RowHandle) Then

                                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                                RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(RowHandle) Then

                                HasGroupRowSelected = True

                            End If

                        Next

                    End If

                    _Controller.MarketDetails_SelectedRowChanged(_ViewModel, BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count, RowIndexes.ToArray)

                    If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible AndAlso _ViewModel.HasASelectedWorksheetMarket Then

                        If RowIndexes IsNot Nothing AndAlso RowIndexes.Count > 0 AndAlso HasGroupRowSelected = False Then

                            _MeasurementTrendsForm.RefreshFormData(RowIndexes(0), DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                               DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                               DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), False)

                        Else

                            _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, False)

                        End If

                    End If

                    If _SubmarketsForm IsNot Nothing Then

                        _SubmarketsForm.SelectedRowChanged(BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows)

                    End If

                    RefreshViewModel(False)

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedDataGridViewForm_MarketDetails.PopupMenuShowingEvent

            'objects
            Dim GridViewColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = Nothing
            Dim DXMenuCheckItemFixedNone As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing
            Dim DXMenuCheckItemFixedLeft As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim VendorCode As String = String.Empty
            Dim HasMoreThanOneVendor As Boolean = False
            Dim CopyRowIndexes As Generic.List(Of Integer) = Nothing
            Dim Bitmap As System.Drawing.Bitmap = Nothing
            Dim NonGroupRowIndexes As Generic.List(Of Integer) = Nothing
            Dim NonGroupNonMakegoodRowIndexes As Generic.List(Of Integer) = Nothing
            Dim EnteredFieldName As String = String.Empty

            If BandedDataGridViewForm_MarketDetails.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect Then

                Bitmap = New System.Drawing.Bitmap(AdvantageFramework.My.Resources.UpdateImage, New System.Drawing.Size(16, 16))

                e.Menu.Items.Add(CreateButtonItem("Update Spots", RowIndex, New EventHandler(AddressOf UpdateSelectedCellsWithSpots), False, Bitmap))

                Bitmap = New System.Drawing.Bitmap(AdvantageFramework.My.Resources.CancelImage, New System.Drawing.Size(16, 16))

                e.Menu.Items.Add(CreateButtonItem("Cancel", RowIndex, New EventHandler(AddressOf CancelSelectedCells), False, Bitmap))

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAutoFilterRowHide,
                                DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAutoFilterRowShow,
                                DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAverageSummaryTypeDescription,
                                DevExpress.XtraGrid.Localization.GridStringId.MenuColumnSortGroupBySummaryMenu,
                                DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFindFilterHide,
                                DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFindFilterShow

                            MenuItem.Visible = False

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup,
                                DevExpress.XtraGrid.Localization.GridStringId.MenuColumnUnGroup

                            If CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu).Column IsNot Nothing AndAlso CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu).Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString Then

                                MenuItem.Visible = True

                            Else

                                MenuItem.Visible = False

                            End If

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBandCustomization

                            MenuItem.Visible = True

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns

                            MenuItem.Visible = True

                            AddHandler MenuItem.Click, AddressOf OnBestFitColumnClick

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox

                            MenuItem.Visible = True

                            AddHandler MenuItem.Click, AddressOf OnGroupBoxClick

                    End Select

                Next

                e.Menu.Items.Add(CreateButtonItem("Best Fit (date columns)", RowIndex, New EventHandler(AddressOf OnBestFitAllDateColumns), False, AdvantageFramework.My.Resources.SmallColumnEditImage))

                If _ViewModel.IsMaxRevisionNumber AndAlso e.HitInfo.Column IsNot Nothing AndAlso e.HitInfo.Column.FieldName.StartsWith("Date") Then

                    Bitmap = New System.Drawing.Bitmap(AdvantageFramework.My.Resources.RowImage, New System.Drawing.Size(16, 16))

                    e.Menu.Items.Add(CreateButtonItem(_ViewModel.CopyDateCaption, e.HitInfo.Column, New EventHandler(AddressOf OnCopyDateClick), True, Bitmap))

                End If

                If e.HitInfo.Column IsNot Nothing AndAlso (e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString) Then

                    GridViewColumnMenu = DirectCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

                    If GridViewColumnMenu.Column IsNot Nothing Then

                        DXMenuCheckItemFixedNone = CreateCheckItem("Fixed None", GridViewColumnMenu.Column, DevExpress.XtraGrid.Columns.FixedStyle.None)
                        DXMenuCheckItemFixedLeft = CreateCheckItem("Fixed Left", GridViewColumnMenu.Column, DevExpress.XtraGrid.Columns.FixedStyle.Left)

                        DXMenuCheckItemFixedNone.BeginGroup = True

                        GridViewColumnMenu.Items.Add(DXMenuCheckItemFixedNone)
                        GridViewColumnMenu.Items.Add(DXMenuCheckItemFixedLeft)

                    End If

                End If

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Group Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelHide,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelClearGrouping,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelShow,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox

                            MenuItem.Visible = False

                    End Select

                Next

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Summary Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    MenuItem.Visible = False

                Next

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(e.HitInfo.RowHandle) Then

                    RowIndexes = New Generic.List(Of Integer)
                    CopyRowIndexes = New Generic.List(Of Integer)
                    NonGroupRowIndexes = New Generic.List(Of Integer)
                    NonGroupNonMakegoodRowIndexes = New Generic.List(Of Integer)

                    For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                        If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(RowHandle) = False Then

                            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                            NonGroupRowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) = 0 AndAlso
                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) = 0 Then

                                NonGroupNonMakegoodRowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            End If

                        End If

                    Next

                    For Each RowHandle In BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows

                        If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(RowHandle) = False Then

                            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                            RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            If String.IsNullOrWhiteSpace(VendorCode) Then

                                VendorCode = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

                            Else

                                If VendorCode <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) Then

                                    HasMoreThanOneVendor = True

                                End If

                            End If

                            If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) = 0 AndAlso
                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) = 0 Then

                                CopyRowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                            End If

                        Else

                            RowIndexes.Clear()
                            CopyRowIndexes.Clear()
                            Exit For

                        End If

                    Next

                    If HasMoreThanOneVendor Then

                        CopyRowIndexes.Clear()

                    End If

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.HitInfo.RowHandle), System.Data.DataRowView).Row

                    RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    If _ViewModel.IsMaxRevisionNumber AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                        Bitmap = New System.Drawing.Bitmap(AdvantageFramework.My.Resources.RowInfoImage, New System.Drawing.Size(16, 16))

                        e.Menu.Items.Add(CreateButtonItem("Allocate", RowIndex, New EventHandler(AddressOf OnAllocateClick), False, Bitmap))

                        'If e.HitInfo.InRowCell AndAlso e.HitInfo.Column IsNot Nothing AndAlso
                        '        e.HitInfo.Column.FieldName.StartsWith("Date") AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.HitInfo.RowHandle, e.HitInfo.Column) > 0 Then

                        Bitmap = New System.Drawing.Bitmap(AdvantageFramework.My.Resources.MakegoodImage, New System.Drawing.Size(16, 16))

                        e.Menu.Items.Add(CreateButtonItem("Makegood", RowIndex, New EventHandler(AddressOf OnMakegoodClick), True, Bitmap))

                        'End If

                        If e.HitInfo.InRowCell AndAlso e.HitInfo.Column IsNot Nothing AndAlso
                                (e.HitInfo.Column.FieldName.StartsWith("Date") OrElse e.HitInfo.Column.FieldName.StartsWith("Rate")) Then

                            If e.HitInfo.Column.FieldName.StartsWith("Date") Then

                                EnteredFieldName = e.HitInfo.Column.FieldName.Replace("Date", "Entered")

                            ElseIf e.HitInfo.Column.FieldName.StartsWith("Rate") Then

                                EnteredFieldName = e.HitInfo.Column.FieldName.Replace("Rate", "Entered")

                            End If

                            If String.IsNullOrWhiteSpace(EnteredFieldName) = False AndAlso _ViewModel.DataTable.Columns.IndexOf(EnteredFieldName) > -1 Then

                                If DataRow(EnteredFieldName) = True Then

                                    e.Menu.Items.Add(CreateButtonItem(_ViewModel.DateRateCaption, RowIndex, New EventHandler(AddressOf OnAdjustRateClick), True, AdvantageFramework.My.Resources.SmallCurrencyDollarImage))

                                End If

                            End If

                        Else

                            e.Menu.Items.Add(CreateButtonItem(_ViewModel.DateRateCaption, RowIndex, New EventHandler(AddressOf OnAdjustRatesClick), True, AdvantageFramework.My.Resources.SmallCurrencyDollarImage))

                        End If

                        e.Menu.Items.Add(CreateButtonItem("Date Access - Single buyline", RowIndex, New EventHandler(AddressOf OnDateAccessClick), True, AdvantageFramework.My.Resources.SmallDataViewImage))

                    End If

                    If _ViewModel.IsMaxRevisionNumber AndAlso NonGroupRowIndexes.Count > 0 Then

                        If BandedDataGridViewForm_MarketDetails.CurrentView.GetSelectedRows.Count = 1 Then

                            e.Menu.Items.Add(CreateButtonItem("Date Access - Allow all dates", NonGroupRowIndexes, New EventHandler(AddressOf OnDateAccessAllowAllDatesClick), False, AdvantageFramework.My.Resources.SmallDataViewImage))

                        Else

                            e.Menu.Items.Add(CreateButtonItem("Date Access - Allow all dates", NonGroupRowIndexes, New EventHandler(AddressOf OnDateAccessAllowAllDatesClick), True, AdvantageFramework.My.Resources.SmallDataViewImage))

                        End If

                    End If

                    If _ViewModel.IsMaxRevisionNumber Then

                        If e.HitInfo.InRowCell AndAlso e.HitInfo.Column IsNot Nothing AndAlso
                            (e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString OrElse
                             e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString) Then

                            e.Menu.Items.Add(CreateCheckedButtonItem("Override Post Ratings", RowIndex, New EventHandler(AddressOf OnOverridePostCheckedChanged), True,
                                                                 BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.HitInfo.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString)))

                        End If

                        If e.HitInfo.InRowCell AndAlso e.HitInfo.Column IsNot Nothing AndAlso
                            (e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString OrElse
                             e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString) Then

                            e.Menu.Items.Add(CreateCheckedButtonItem("Override Post Impressions", RowIndex, New EventHandler(AddressOf OnOverridePostImpressionsCheckedChanged), True,
                                                                 BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.HitInfo.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString)))

                        End If

                        If e.HitInfo.InRowCell AndAlso e.HitInfo.Column IsNot Nothing AndAlso
                            (e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString OrElse
                             e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString) Then

                            e.Menu.Items.Add(CreateCheckedButtonItem("Override Post AQH", RowIndex, New EventHandler(AddressOf OnOverridePostAQHCheckedChanged), True,
                                                                 BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.HitInfo.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString)))

                        End If

                        If NonGroupRowIndexes.Count > 0 Then

                            e.Menu.Items.Add(CreateButtonItem("Check On Hold", NonGroupRowIndexes, New EventHandler(AddressOf OnCheckOnHoldClick), True))
                            e.Menu.Items.Add(CreateButtonItem("Uncheck On Hold", NonGroupRowIndexes, New EventHandler(AddressOf OnUncheckOnHoldClick), False))

                            If _Controller.MarketDetails_AnyRowsHaveOrders(_ViewModel, NonGroupRowIndexes) AndAlso _ViewModel.IsMaxRevisionNumber Then

                                Bitmap = New System.Drawing.Bitmap(AdvantageFramework.My.Resources.MediaAddImage, New System.Drawing.Size(16, 16))

                                e.Menu.Items.Add(CreateButtonItem("Generate Orders", NonGroupRowIndexes, New EventHandler(AddressOf OnGenerateOrdersClick), True, Bitmap))

                            End If

                        End If

                        If RowIndexes.Count > 0 Then

                            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV AndAlso
                                    (_ViewModel.SelectedWorksheetMarket.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0 OrElse _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.NielsenPuertoRico) Then

                                'If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString) OrElse
                                '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryShare.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString) OrElse
                                '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString) OrElse
                                '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryShare.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString) Then

                                e.Menu.Items.Add(CreateButtonItem("Undo Rating\Share\Impressions Override", RowIndexes, New EventHandler(AddressOf OnUndoRatingShareOverrideClick), True))

                                'End If

                                'If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookProgram.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString) Then

                                e.Menu.Items.Add(CreateButtonItem("Undo Program Override", RowIndexes, New EventHandler(AddressOf OnUndoProgramOverrideClick), False))

                                'End If

                            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio AndAlso
                                    _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID1.GetValueOrDefault(0) > 0 Then

                                'If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQHRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString) Then

                                e.Menu.Items.Add(CreateButtonItem("Undo Rating\AQH Override", RowIndexes, New EventHandler(AddressOf OnUndoRatingShareOverrideClick), False))

                                'End If

                            End If

                            If CopyRowIndexes.Count > 0 Then

                                e.Menu.Items.Add(CreateButtonItem("Copy To Another Vendor", CopyRowIndexes, New EventHandler(AddressOf OnCopyToAnotherVendorClick), True, AdvantageFramework.My.Resources.SmallVendorImage))

                                If _ViewModel.IsCanadianWorksheet = False Then

                                    e.Menu.Items.Add(CreateButtonItem("Copy To Another Market", CopyRowIndexes, New EventHandler(AddressOf OnCopyToAnotherMarketClick), False, AdvantageFramework.My.Resources.SmallQuickManageImage))

                                End If

                            End If

                        End If

                        If NonGroupNonMakegoodRowIndexes.Count > 0 Then

                            If RowIndexes.Count > 0 AndAlso CopyRowIndexes.Count > 0 Then

                                e.Menu.Items.Add(CreateButtonItem("Copy To Another Worksheet\Market Schedule", NonGroupNonMakegoodRowIndexes, New EventHandler(AddressOf OnCopyToAnotherWorksheetMarketScheduleClick), False, AdvantageFramework.My.Resources.SmallQuickManageImage))

                            Else

                                e.Menu.Items.Add(CreateButtonItem("Copy To Another Worksheet\Market Schedule", NonGroupNonMakegoodRowIndexes, New EventHandler(AddressOf OnCopyToAnotherWorksheetMarketScheduleClick), True, AdvantageFramework.My.Resources.SmallQuickManageImage))

                            End If

                        End If

                    End If

                ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(e.HitInfo.RowHandle) Then

                    RowIndexes = New Generic.List(Of Integer)
                    NonGroupNonMakegoodRowIndexes = New Generic.List(Of Integer)

                    For RowIndex = 0 To BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowCount(e.HitInfo.RowHandle) - 1

                        DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(e.HitInfo.RowHandle, RowIndex)), System.Data.DataRowView).Row

                        RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) = 0 AndAlso
                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MadegoodNumber.ToString) = 0 Then

                            NonGroupNonMakegoodRowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                        End If

                    Next

                    If _ViewModel.IsMaxRevisionNumber Then

                        e.Menu.Items.Add(CreateButtonItem("Check On Hold", RowIndexes, New EventHandler(AddressOf OnCheckOnHoldClick), True))
                        e.Menu.Items.Add(CreateButtonItem("Uncheck On Hold", RowIndexes, New EventHandler(AddressOf OnUncheckOnHoldClick), False))

                        If NonGroupNonMakegoodRowIndexes.Count > 0 Then

                            e.Menu.Items.Add(CreateButtonItem("Copy To Another Vendor", NonGroupNonMakegoodRowIndexes, New EventHandler(AddressOf OnCopyToAnotherVendorClick), True, AdvantageFramework.My.Resources.SmallVendorImage))

                            If _ViewModel.IsCanadianWorksheet = False Then

                                e.Menu.Items.Add(CreateButtonItem("Copy To Another Market", NonGroupNonMakegoodRowIndexes, New EventHandler(AddressOf OnCopyToAnotherMarketClick), False, AdvantageFramework.My.Resources.SmallQuickManageImage))

                            End If

                            e.Menu.Items.Add(CreateButtonItem("Copy To Another Worksheet\Market Schedule", NonGroupNonMakegoodRowIndexes, New EventHandler(AddressOf OnCopyToAnotherWorksheetMarketScheduleClick), False, AdvantageFramework.My.Resources.SmallQuickManageImage))

                        End If


                        If _Controller.MarketDetails_AnyRowsHaveOrders(_ViewModel, RowIndexes) AndAlso _ViewModel.IsMaxRevisionNumber Then

                            Bitmap = New System.Drawing.Bitmap(AdvantageFramework.My.Resources.MediaAddImage, New System.Drawing.Size(16, 16))

                            e.Menu.Items.Add(CreateButtonItem("Generate Orders", RowIndexes, New EventHandler(AddressOf OnGenerateOrdersClick), True, Bitmap))

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles BandedDataGridViewForm_MarketDetails.ValidateRowEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                DataRow = CType(e.Row, System.Data.DataRowView).Row

                ValidateRow(DataRow)

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles BandedDataGridViewForm_MarketDetails.ValidatingEditorEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            If BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString Then

                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

                RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                _Controller.MarketDetails_SetDays(_ViewModel, RowIndex, e.Value, e.Valid, True)

                e.Valid = True

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString Then

                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

                RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                _Controller.MarketDetails_SetStartTime(_ViewModel, RowIndex, e.Value, e.Valid, True)

                e.Valid = True

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString Then

                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

                RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                _Controller.MarketDetails_SetEndTime(_ViewModel, RowIndex, e.Value, e.Valid, True)

                e.Valid = True

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString Then

                If String.IsNullOrWhiteSpace(e.Value) Then

                    e.Value = String.Empty

                End If

                e.Valid = True

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
            Dim RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit = Nothing
            Dim RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = Nothing
            Dim RepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = Nothing
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing

            If _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f0"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f0"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f0"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f0"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = False
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999
                RepositoryItemSpinEdit.MaxLength = 3
                RepositoryItemSpinEdit.Buttons.Clear()

                AddHandler RepositoryItemSpinEdit.EditValueChanged, AddressOf RepositoryItemDateValue_EditValueChanged

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf _ViewModel.RateDates.ContainsValue(e.Column.FieldName) Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "c2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "c2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "c2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "c2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 9999999.99
                RepositoryItemSpinEdit.MaxLength = 10
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f0"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f0"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f0"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f0"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = False
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999
                RepositoryItemSpinEdit.MaxLength = 3
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "c2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "c2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "c2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "c2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 9999999.99
                RepositoryItemSpinEdit.MaxLength = 10
                RepositoryItemSpinEdit.EditValueChangedDelay = 10000
                RepositoryItemSpinEdit.Buttons.Clear()

                AddHandler RepositoryItemSpinEdit.EditValueChanged, AddressOf RepositoryItemDefaultRate_EditValueChanged

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 99.99
                RepositoryItemSpinEdit.MaxLength = 5
                RepositoryItemSpinEdit.EditValueChangedDelay = 10000
                RepositoryItemSpinEdit.Buttons.Clear()

                AddHandler RepositoryItemSpinEdit.EditValueChanged, AddressOf RepositoryItemRating_EditValueChanged

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 99.99
                RepositoryItemSpinEdit.MaxLength = 5
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f1"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f1"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f1"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f1"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 99.9
                RepositoryItemSpinEdit.MaxLength = 4
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "n0"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "n0"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "n0"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "n0"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = False
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999999999
                RepositoryItemSpinEdit.MaxLength = 9
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "n1"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "n1"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "n1"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "n1"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999999999
                RepositoryItemSpinEdit.MaxLength = 9
                RepositoryItemSpinEdit.Buttons.Clear()

                'AddHandler RepositoryItemSpinEdit.ParseEditValue, AddressOf RepositoryItemImpressions_ParseEditValue

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf RepositoryItemBookend_EditValueChanging
                AddHandler RepositoryItemCheckEdit.MouseDown, AddressOf RepositoryItemCheckEdit_MouseDown

                e.RepositoryItem = RepositoryItemCheckEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.MouseDown, AddressOf RepositoryItemCheckEdit_MouseDown

                e.RepositoryItem = RepositoryItemCheckEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString Then

                RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

                RepositoryItemLookUpEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code"))
                RepositoryItemLookUpEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description"))
                RepositoryItemLookUpEdit.DisplayMember = "Code"
                RepositoryItemLookUpEdit.ValueMember = "Code"

                RepositoryItemLookUpEdit.DataSource = _ViewModel.Dayparts.OrderBy(Function(Entity) Entity.Code).ToList

                e.RepositoryItem = RepositoryItemLookUpEdit

                'Else

                '    If _ViewModel IsNot Nothing AndAlso _ViewModel.DoesWorksheetAllowSubmarkets AndAlso
                '            e.Column.FieldName.StartsWith("SM") AndAlso ButtonItemSubmarkets_Percentage.Checked = False Then

                '        RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                '        RepositoryItemSpinEdit.AllowMouseWheel = False
                '        RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                '        RepositoryItemSpinEdit.EditMask = "f2"
                '        RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                '        RepositoryItemSpinEdit.DisplayFormat.FormatString = "f2"
                '        RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                '        RepositoryItemSpinEdit.EditFormat.FormatString = "f2"
                '        RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                '        RepositoryItemSpinEdit.Mask.EditMask = "f2"
                '        RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                '        RepositoryItemSpinEdit.IsFloatValue = True
                '        RepositoryItemSpinEdit.MinValue = 0
                '        RepositoryItemSpinEdit.MaxValue = 99.99
                '        RepositoryItemSpinEdit.MaxLength = 5
                '        RepositoryItemSpinEdit.Buttons.Clear()

                '        e.RepositoryItem = RepositoryItemSpinEdit

                '    End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomColumnDisplayTextEvent

            'objects
            Dim RowHandle As Integer = 0

            If e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString) Then

                e.DisplayText = FormatNumber((e.Value / 100), 0, TriState.True, TriState.False, TriState.True)

            ElseIf e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString) Then

                e.DisplayText = FormatNumber((e.Value / 1000), 1, TriState.True, TriState.False, TriState.True)

            ElseIf e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString Then

                RowHandle = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowHandle(e.ListSourceRowIndex)

                If BandedDataGridViewForm_MarketDetails.CurrentView.IsValidRowHandle(RowHandle) AndAlso
                        _ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) > 0 Then

                    e.DisplayText = Format(_ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString), "0000") & "-" & Format(_ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString), "00")

                End If

            ElseIf e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString Then

                If e.DisplayText = "[None]" Then

                    e.DisplayText = ""

                End If

                'Else

                '    If _ViewModel IsNot Nothing AndAlso _ViewModel.DoesWorksheetAllowSubmarkets AndAlso
                '            e.Column.FieldName.StartsWith("SM") AndAlso ButtonItemSubmarkets_Percentage.Checked Then

                '        If IsNumeric(e.Value) AndAlso e.Value <> 0 Then

                '            e.DisplayText = e.Value & "%"

                '        Else

                '            e.DisplayText = ""

                '        End If

                '    End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawFooterCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawFooterCellEvent

            'objects
            Dim Bounds As System.Drawing.Rectangle = Nothing

            If e.Column IsNot Nothing AndAlso e.Info.SummaryItem IsNot Nothing AndAlso e.Info.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom Then

                If _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) OrElse
                        e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString Then

                    If e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings Then

                        e.Info.DisplayText = FormatNumber(e.Info.Value, 2, Microsoft.VisualBasic.TriState.UseDefault, Microsoft.VisualBasic.TriState.True)

                        'e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)

                        'e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars Then

                        e.Info.DisplayText = FormatCurrency(e.Info.Value, 2)

                        'e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)

                        'e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent Then

                        e.Info.DisplayText = FormatPercent(e.Info.Value, 0)

                        'e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)

                        'e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent Then

                        e.Info.DisplayText = FormatPercent(e.Info.Value, 0)

                        'e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)

                        'e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars Then

                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 230, 230, 230)

                        e.Info.DisplayText = FormatCurrency(e.Info.Value, 2)

                        Bounds = New System.Drawing.Rectangle(e.Bounds.Location, e.Bounds.Size)

                        System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, e.Bounds, System.Drawing.Color.FromArgb(255, 150, 150, 150), System.Windows.Forms.ButtonBorderStyle.Solid)

                        Bounds.Inflate(-1, -1)

                        e.Appearance.DrawBackground(e.Cache, Bounds)

                        Bounds.Inflate(-2, 0)

                        e.Appearance.DrawString(e.Cache, e.Info.DisplayText, Bounds)

                        e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings Then

                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 230, 230, 230)

                        e.Info.DisplayText = FormatNumber(e.Info.Value, 2)

                        Bounds = New System.Drawing.Rectangle(e.Bounds.Location, e.Bounds.Size)

                        System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, e.Bounds, System.Drawing.Color.FromArgb(255, 150, 150, 150), System.Windows.Forms.ButtonBorderStyle.Solid)

                        Bounds.Inflate(-1, -1)

                        e.Appearance.DrawBackground(e.Cache, Bounds)

                        Bounds.Inflate(-2, 0)

                        e.Appearance.DrawString(e.Cache, e.Info.DisplayText, Bounds)

                        e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings Then

                        e.Info.DisplayText = FormatNumber(e.Info.Value, 2)

                        'e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)

                        'e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions Then

                        e.Info.DisplayText = FormatNumber(e.Info.Value, 0)

                        'e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)

                        'e.Handled = True

                    ElseIf e.Info.SummaryItem.Tag = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars Then

                        e.Info.DisplayText = FormatCurrency(e.Info.Value, 2)

                        'e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)

                        'e.Handled = True

                    End If

                    'ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString Then

                    '	e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)
                    '	e.Appearance.BackColor2 = System.Drawing.Color.White
                    '	e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical

                    '	e.Appearance.DrawBackground(e.Cache, e.Bounds)
                    '	e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)

                    '	e.Handled = True

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

            If e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString OrElse
                                               e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString OrElse
                                               e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString OrElse
                                               e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString) Then

                e.Appearance.DrawString(e.Cache, FormatCurrency(e.Info.Value, 2, TriState.True, TriState.False, TriState.True), e.Bounds, System.Drawing.Brushes.Black)

            ElseIf e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString) Then

                e.Appearance.DrawString(e.Cache, FormatNumber(e.Info.Value, 2, TriState.True, TriState.False, TriState.False), e.Bounds, System.Drawing.Brushes.Black)

            ElseIf e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString) Then

                e.Appearance.DrawString(e.Cache, FormatPercent(e.Info.Value, 1, TriState.True, TriState.False, TriState.False), e.Bounds, System.Drawing.Brushes.Black)

            ElseIf e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString) Then

                e.Appearance.DrawString(e.Cache, FormatNumber(e.Info.Value, 1, TriState.True, TriState.False, TriState.False), e.Bounds, System.Drawing.Brushes.Black)

            ElseIf e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString) Then

                e.Appearance.DrawString(e.Cache, FormatNumber(e.Info.Value, 0, TriState.True, TriState.False, TriState.True), e.Bounds, System.Drawing.Brushes.Black)

            ElseIf e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString) Then

                e.Appearance.DrawString(e.Cache, FormatNumber((e.Info.Value / 1000), 1, TriState.True, TriState.False, TriState.True), e.Bounds, System.Drawing.Brushes.Black)

            ElseIf e.Column IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString OrElse
                                                   e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString) Then

                e.Appearance.DrawString(e.Cache, FormatCurrency(e.Info.Value, 2, TriState.True, TriState.False, TriState.True), e.Bounds, System.Drawing.Brushes.Black)

            ElseIf e.Column IsNot Nothing AndAlso e.Column.FieldName.StartsWith("SM") Then

                e.Appearance.DrawString(e.Cache, FormatNumber(e.Info.Value, 2, TriState.True, TriState.False, TriState.True), e.Bounds, System.Drawing.Brushes.Black)

            Else

                e.Appearance.DrawString(e.Cache, FormatNumber(e.Info.Value, 0, TriState.True, TriState.False, TriState.False), e.Bounds, System.Drawing.Brushes.Black)

            End If

            e.Handled = True

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawFooterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawFooterEvent

            'objects
            Dim GridViewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = Nothing
            Dim DateColumn As String = String.Empty

            e.Painter.DrawObject(e.Info)

            GridViewInfo = BandedDataGridViewForm_MarketDetails.CurrentView.GetViewInfo()

            DateColumn = "Date" & GetFirstVisibleDateColumnIndex().ToString

            If BandedDataGridViewForm_MarketDetails.Columns(DateColumn) IsNot Nothing AndAlso ButtonItemDisplay_ShowTotals.Checked AndAlso
                    GridViewInfo.ColumnsInfo(BandedDataGridViewForm_MarketDetails.Columns(DateColumn)) IsNot Nothing Then

                'e.Appearance.FontSizeDelta = -1

                e.Graphics.DrawString("Worksheet Spots",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalSpots, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})
                e.Graphics.DrawString("Worksheet GRP",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalRatings, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})
                e.Graphics.DrawString("Worksheet GIMP",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalImpressions, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})
                e.Graphics.DrawString("Worksheet Cost",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.TotalDollars, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

                e.Graphics.DrawString("Goal GRP",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalRatings - 2, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})
                e.Graphics.DrawString("Goal Cost",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.GoalDollars - 2, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

                e.Graphics.DrawString("Variance GRP",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatings - 2, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})
                e.Graphics.DrawString("Variance Cost",
                                      e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollars - 2, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})
                e.Graphics.DrawString("Variance GRP %", e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceRatingsPercent - 2, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})
                e.Graphics.DrawString("Variance Cost %", e.Appearance.Font, System.Drawing.Brushes.Black, GetRectangleForRow(DateColumn, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_RowTotalRows.VarianceDollarsPercent - 2, e.Bounds, e.Appearance.Font.Height),
                                      New System.Drawing.StringFormat() With {.LineAlignment = System.Drawing.StringAlignment.Near, .Alignment = System.Drawing.StringAlignment.Near})

            End If

            e.Handled = True

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_MouseDownEvent(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles BandedDataGridViewForm_MarketDetails.MouseDownEvent

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim ContinueSettingHiatus As Boolean = False

            If e.Clicks = 2 AndAlso System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow AndAlso _ViewModel.IsMaxRevisionNumber AndAlso Not _ViewModel.VendorMakegoodAvailable Then

                GridHitInfo = BandedDataGridViewForm_MarketDetails.CurrentView.CalcHitInfo(e.Location)

                If GridHitInfo IsNot Nothing AndAlso GridHitInfo.InColumnPanel AndAlso
                        GridHitInfo.Column IsNot Nothing AndAlso _ViewModel.DetailDates.ContainsValue(GridHitInfo.Column.FieldName) Then

                    If _ViewModel.HiatusDataTable.Rows(0)(GridHitInfo.Column.FieldName) = False Then

                        If _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(GridHitInfo.Column.FieldName) <> 0) Then

                            If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Setting Hiatus will clear all data in this range." & vbNewLine & vbNewLine & "Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                ContinueSettingHiatus = True

                            End If

                        Else

                            ContinueSettingHiatus = True

                        End If

                    Else

                        ContinueSettingHiatus = True

                    End If

                    If ContinueSettingHiatus Then

                        BeginDataUpdate()

                        _Controller.MarketDetails_HiatusValueChanged(_ViewModel, GridHitInfo.Column.FieldName)

                        For Each DataRow In _ViewModel.DataTable.Rows.OfType(Of System.Data.DataRow)

                            _Controller.MarketDetails_MarketDetailChanged(_ViewModel, _ViewModel.DataTable.Rows.IndexOf(DataRow))

                        Next

                        If _ViewModel.HiatusDataTable.Rows(0)(GridHitInfo.Column.FieldName) = True Then

                            BandedDataGridViewForm_MarketDetails.Columns(GridHitInfo.Column.FieldName).OptionsColumn.AllowFocus = False
                            BandedDataGridViewForm_MarketDetails.Columns(GridHitInfo.Column.FieldName.Replace("Date", "Rate")).OptionsColumn.AllowFocus = False
                            BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(GridHitInfo.Column.FieldName.Replace("Date", "Rate"))

                            If ButtonItemDates_HideHiatusDates.Checked Then

                                BandedDataGridViewForm_MarketDetails.MakeColumnNotVisible(GridHitInfo.Column.FieldName)

                            End If

                        Else

                            BandedDataGridViewForm_MarketDetails.Columns(GridHitInfo.Column.FieldName).OptionsColumn.AllowFocus = True
                            BandedDataGridViewForm_MarketDetails.Columns(GridHitInfo.Column.FieldName.Replace("Date", "Rate")).OptionsColumn.AllowFocus = True

                            If ButtonItemDisplay_WeeklyRates.Checked Then

                                BandedDataGridViewForm_MarketDetails.MakeColumnVisible(GridHitInfo.Column.FieldName.Replace("Date", "Rate"))

                            End If

                        End If

                        EndDataUpdate()

                        BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                        RefreshViewModel(False)

                        'BandedDataGridViewForm_MarketDetails.CurrentView.RefreshData()

                        If _TotalsForm IsNot Nothing Then

                            _TotalsForm.RefreshData()

                        End If

                        If _SubmarketsForm IsNot Nothing Then

                            _SubmarketsForm.RefreshData()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedDataGridViewForm_MarketDetails.CellValueChangedEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1
            Dim RefreshTrendWindow As Boolean = False
            Dim SimpleRefresh As Boolean = False
            Dim UpdateSummary As Boolean = False
            Dim SpotsChanged As Boolean = False

            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

            RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

            'BeginDataUpdate()

            If _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) Then

                _Controller.MarketDetails_MarketDetailDateValueChanged(_ViewModel, RowIndex, e.Column.FieldName)

                '_Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)
                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True
                SpotsChanged = True

            ElseIf _ViewModel.RateDates.ContainsValue(e.Column.FieldName) Then

                _Controller.MarketDetails_RateChanged(_ViewModel, RowIndex, e.Column.FieldName, True)

                '_Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)
                UpdateSummary = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString Then

                _Controller.MarketDetails_DefaultRateChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                UpdateSummary = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString Then

                _Controller.MarketDetails_CableNetworkStationChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

                RefreshTrendWindow = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString Then

                _Controller.MarketDetails_ProgramChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                RefreshTrendWindow = True
                SimpleRefresh = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString Then

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                RefreshTrendWindow = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString Then

                _Controller.MarketDetails_StartTimeChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

                RefreshTrendWindow = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString Then

                _Controller.MarketDetails_EndTimeChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

                RefreshTrendWindow = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString Then

                _Controller.MarketDetails_PrimaryAQHRatingChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

                RefreshTrendWindow = True
                SimpleRefresh = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString Then

                _Controller.MarketDetails_PrimaryRatingChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

                RefreshTrendWindow = True
                SimpleRefresh = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString Then

                _Controller.MarketDetails_PrimaryShareChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

                RefreshTrendWindow = True
                SimpleRefresh = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString Then

                _Controller.MarketDetails_SecondaryAQHRatingChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

                RefreshTrendWindow = True
                SimpleRefresh = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString Then

                _Controller.MarketDetails_SecondaryRatingChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString Then

                _Controller.MarketDetails_SecondaryShareChanged(_ViewModel, RowIndex)

                'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateGroupSummary()
                UpdateSummary = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString Then

                _Controller.MarketDetails_MarketDetailChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString Then

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString Then

                _Controller.MarketDetails_OnHoldValueChanged(_ViewModel)

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString Then

                _Controller.MarketDetails_PrimaryImpressionsChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                UpdateSummary = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString Then

                _Controller.MarketDetails_SecondaryImpressionsChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                UpdateSummary = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString Then

                _Controller.MarketDetails_PrimaryAQHChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                UpdateSummary = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString Then

                _Controller.MarketDetails_SecondaryAQHChanged(_ViewModel, RowIndex)

                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

                UpdateSummary = True

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString Then

                _Controller.MarketDetails_AQHChanged(_ViewModel, RowIndex, e.Value, If(e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString, True, False))

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString Then

                _Controller.MarketDetails_DaypartChanged(_ViewModel, RowIndex)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString Then

                _Controller.MarketDetails_LengthChanged(_ViewModel, RowIndex)

            Else


                _Controller.MarketDetails_MarketDetailValueChanged(_ViewModel)

            End If

            ' EndDataUpdate()

            If UpdateSummary Then

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

            End If

            If RefreshTrendWindow AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.HasColumnErrors = False AndAlso
                    Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Refreshing Then

                If _MeasurementTrendsForm IsNot Nothing AndAlso _MeasurementTrendsForm.Visible AndAlso _ViewModel.HasASelectedWorksheetMarket Then

                    If DataRow IsNot Nothing Then

                        _MeasurementTrendsForm.RefreshFormData(RowIndex, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString),
                                                               DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString),
                                                               DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString), SimpleRefresh)

                    Else

                        _MeasurementTrendsForm.RefreshFormData(-1, String.Empty, Nothing, String.Empty, SimpleRefresh)

                    End If

                End If

            End If

            If _TotalsForm IsNot Nothing AndAlso _ViewModel.HasASelectedWorksheetMarket Then

                _TotalsForm.RefreshData()

            End If

            If SpotsChanged Then

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.RefreshData()

                End If

            End If

            RefreshViewModel(False)

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawBandHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawBandHeaderEvent

            If _ViewModel IsNot Nothing AndAlso _ViewModel.Worksheet IsNot Nothing AndAlso _ViewModel.Worksheet.IsGross = False AndAlso _ViewModel.HasASelectedWorksheetMarket AndAlso
                    e.Band IsNot Nothing AndAlso e.Band.Name = GridBandNames.GridBandOtherData.ToString Then

                e.DefaultDraw()

                e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                e.Appearance.ForeColor = System.Drawing.Color.Red

                e.Appearance.DrawString(e.Cache, "Rates are Net", e.Bounds)

                e.Handled = True

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawCellEvent

            'objects
            Dim TrianglePoint() As System.Drawing.Point = Nothing

            If _ViewModel IsNot Nothing AndAlso _ViewModel.HasASelectedWorksheetMarket Then

                If _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) Then

                    If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName) = True Then

                        e.Appearance.BackColor = System.Drawing.Color.WhiteSmoke

                        e.Appearance.DrawBackground(e.Cache, e.Bounds)

                        e.Handled = True

                    ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, e.Column.FieldName.Replace("Date", "Entered")) = False Then

                        e.Appearance.BackColor = System.Drawing.Color.White

                        e.Appearance.DrawBackground(e.Cache, e.Bounds)

                        e.Handled = True

                        'Else

                        '    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString) > BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, e.Column.FieldName.Replace("Date", "Rate")) Then

                        '        TrianglePoint = {New System.Drawing.Point(e.Bounds.Right, e.Bounds.Top), New System.Drawing.Point(e.Bounds.Right, e.Bounds.Top + 5), New System.Drawing.Point(e.Bounds.Right - 5, e.Bounds.Top)}

                        '        e.Cache.DrawPolygon(TrianglePoint, System.Drawing.Color.Red, 1)
                        '        e.Cache.FillPolygon(TrianglePoint, System.Drawing.Color.Red)

                        '    ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString) < BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, e.Column.FieldName.Replace("Date", "Rate")) Then

                        '        TrianglePoint = {New System.Drawing.Point(e.Bounds.Right, e.Bounds.Top), New System.Drawing.Point(e.Bounds.Right, e.Bounds.Top + 5), New System.Drawing.Point(e.Bounds.Right - 5, e.Bounds.Top)}

                        '        e.Cache.DrawPolygon(TrianglePoint, System.Drawing.Color.Green, 1)
                        '        e.Cache.FillPolygon(TrianglePoint, System.Drawing.Color.Green)

                        '    End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString Then

                    For i As Integer = 1 To _ViewModel.DetailDates.Count

                        If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, "Rate" & i) <> e.CellValue AndAlso
                                BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, "Entered" & i) = True Then

                            TrianglePoint = {New System.Drawing.Point(e.Bounds.Right, e.Bounds.Top), New System.Drawing.Point(e.Bounds.Right, e.Bounds.Top + 5), New System.Drawing.Point(e.Bounds.Right - 5, e.Bounds.Top)}

                            e.Cache.DrawPolygon(TrianglePoint, System.Drawing.Color.Red, 1)
                            e.Cache.FillPolygon(TrianglePoint, System.Drawing.Color.Red)

                            Exit For

                        End If

                    Next

                ElseIf _ViewModel.RateDates.ContainsValue(e.Column.FieldName) Then

                    If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName.Replace("Rate", "Date")) = True Then

                        e.Appearance.BackColor = System.Drawing.Color.WhiteSmoke

                        e.Appearance.DrawBackground(e.Cache, e.Bounds)

                        e.Handled = True

                    ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, e.Column.FieldName.Replace("Rate", "Entered")) = False Then

                        e.Appearance.BackColor = System.Drawing.Color.White

                        e.Appearance.DrawBackground(e.Cache, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQHRating.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQH.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryImpressions.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryRating.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryShare.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQHRating.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQH.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryImpressions.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryRating.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryShare.ToString) <> e.CellValue Then

                        e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                        e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)

                        e.Handled = True

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles BandedDataGridViewForm_MarketDetails.ShowingEditorEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing

            If Me.BandedDataGridViewForm_MarketDetails.CurrentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect Then

                e.Cancel = True

            ElseIf _ViewModel.VendorMakegoodAvailable Then

                e.Cancel = True

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString Then

                If CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString) <> CInt(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered) Then

                    e.Cancel = True

                End If

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString Then

                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

                RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                If _ViewModel.DataTable.Rows(RowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString) = False Then

                    e.Cancel = True

                End If

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString OrElse
                    BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString Then

                'If _ViewModel.SelectedWorksheetMarket.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0 Then

                '    e.Cancel = True

                'End If

            ElseIf BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString OrElse
                    BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString Then

                'If _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID1.GetValueOrDefault(0) > 0 Then

                '    e.Cancel = True

                'End If

            ElseIf _ViewModel.DetailDates.ContainsValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName) Then

                If _ViewModel.HiatusDataTable.Rows(0)(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName) = True Then

                    e.Cancel = True

                Else

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

                    RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    If _ViewModel.DataTable.Rows(RowIndex)(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName.Replace("Date", "Entered")) = False Then

                        e.Cancel = True

                    End If

                End If

            ElseIf _ViewModel.RateDates.ContainsValue(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName) Then

                If _ViewModel.HiatusDataTable.Rows(0)(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName.Replace("Rate", "Date")) = True Then

                    e.Cancel = True

                Else

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

                    RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                    If _ViewModel.DataTable.Rows(RowIndex)(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName.Replace("Rate", "Entered")) = False Then

                        e.Cancel = True

                    End If

                End If

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
        Private Sub BandedDataGridViewForm_MarketDetails_ShownEditorEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.ShownEditorEvent

            If BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.ActiveEditor IsNot Nothing AndAlso TypeOf BandedDataGridViewForm_MarketDetails.CurrentView.ActiveEditor Is DevExpress.XtraEditors.TextEdit Then

                    CType(BandedDataGridViewForm_MarketDetails.CurrentView.ActiveEditor, DevExpress.XtraEditors.TextEdit).Properties.MaxLength = 100

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_DragObjectOverEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs) Handles BandedDataGridViewForm_MarketDetails.DragObjectOverEvent

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo = Nothing
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing

            If TypeOf e.DragObject Is DevExpress.XtraGrid.Views.BandedGrid.GridBand Then

                GridHitInfo = BandedDataGridViewForm_MarketDetails.CurrentView.CalcHitInfo(BandedDataGridViewForm_MarketDetails.CurrentView.GridControl.PointToClient(System.Windows.Forms.Form.MousePosition))

                If GridHitInfo.InBandPanel Then

                    e.DropInfo.Valid = False

                End If

            ElseIf TypeOf e.DragObject Is DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Then

                BandedGridColumn = e.DragObject

                If BandedGridColumn.FieldName = "TotalNet" Then

                    e.DropInfo.Valid = False

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.ColumnFilterChangedEvent

            'objects
            Dim RefreshGoals As Boolean = False

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ColumnFilterStrings(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString)) <>
                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString).FilterInfo.FilterString Then

                    RefreshGoals = True

                End If

                If _ColumnFilterStrings(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString)) <>
                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString).FilterInfo.FilterString Then

                    RefreshGoals = True

                End If

                _ColumnFilterStrings(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString)) = BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString).FilterInfo.FilterString
                _ColumnFilterStrings(BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString)) = BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString).FilterInfo.FilterString

                _Controller.MarketDetails_FilterStringChanged(_ViewModel, If(BandedDataGridViewForm_MarketDetails.CurrentView.ActiveFilterCriteria IsNot Nothing, BandedDataGridViewForm_MarketDetails.CurrentView.ActiveFilterCriteria.ToString, String.Empty), DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(BandedDataGridViewForm_MarketDetails.CurrentView.ActiveFilterCriteria), RefreshGoals)

                ExpandAllGroups()

                If _ViewModel.IsMaxRevisionNumber Then

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                'BandedDataGridViewForm_MarketDetails.CurrentView.BestFitColumns()

                If _TotalsForm IsNot Nothing Then

                    _TotalsForm.RefreshLabels()

                End If

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.FilterChanged()

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ColumnPositionChangedEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.ColumnPositionChangedEvent

            'objects
            Dim BandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing
            Dim ModifyingBandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing
            Dim OtherBandedGridColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = Nothing
            Dim ModifyingGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginUpdate()

                If sender IsNot Nothing AndAlso TypeOf sender Is DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Then

                    BandedGridColumn = sender

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Modifying

                    If BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)

                    ElseIf BandedGridColumn.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString Then

                        ModifyingBandedGridColumn = BandedDataGridViewForm_MarketDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)

                    End If

                    If ModifyingBandedGridColumn IsNot Nothing Then

                        'If ModifyingBandedGridColumn.OwnerBand Is Nothing Then

                        If ModifyingBandedGridColumn.FieldName.StartsWith("Primary") Then

                            ModifyingGridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandPrimaryDemo.ToString)

                        Else

                            ModifyingGridBand = BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandSecondaryDemo.ToString)

                        End If

                        'Else

                        '    ModifyingGridBand = ModifyingBandedGridColumn.OwnerBand

                        'End If

                        If ModifyingBandedGridColumn.VisibleIndex = -1 OrElse BandedGridColumn.VisibleIndex = -1 Then

                            ModifyingBandedGridColumn.VisibleIndex = BandedGridColumn.VisibleIndex

                        End If

                        If ModifyingGridBand IsNot Nothing AndAlso BandedGridColumn.OwnerBand IsNot Nothing Then

                            For Each GridColumn In BandedGridColumn.OwnerBand.Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).ToList

                                OtherBandedGridColumn = ModifyingGridBand.Columns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn).SingleOrDefault(Function(BGC) BGC.CustomizationSearchCaption = GridColumn.CustomizationSearchCaption)

                                If OtherBandedGridColumn IsNot Nothing AndAlso OtherBandedGridColumn.OwnerBand IsNot Nothing Then

                                    OtherBandedGridColumn.OwnerBand.Columns.MoveTo(GridColumn.ColVIndex, OtherBandedGridColumn)

                                End If

                            Next

                        End If

                    End If

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.EndUpdate()

                If _ViewModel.Worksheet IsNot Nothing AndAlso
                        _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).Visible = True OrElse
                            BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).Visible = True OrElse
                            BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).Visible = True OrElse
                            BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).Visible = True Then

                        LabelForm_Disclaimer.Visible = True

                    Else

                        LabelForm_Disclaimer.Visible = False

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ColumnWidthChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles BandedDataGridViewForm_MarketDetails.ColumnWidthChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.IsMaxRevisionNumber Then

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

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
        Private Sub BandedDataGridViewForm_MarketDetails_BandWidthChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandEventArgs) Handles BandedDataGridViewForm_MarketDetails.BandWidthChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.HideCustomizationFormEvent

            _Controller.MarketDetails_ChooseColumnsChanged(_ViewModel, False)

            RefreshViewModel(False)

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.ShowCustomizationFormEvent

            _Controller.MarketDetails_ChooseColumnsChanged(_ViewModel, True)

            RefreshViewModel(False)

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawColumnHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawColumnHeaderEvent

            'objects
            Dim SuperscriptFont As System.Drawing.Font = Nothing
            Dim StartX As Integer = 0

            If e.Column IsNot Nothing AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) AndAlso _ViewModel.HiatusDataTable.Rows.Count > 0 Then

                If _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) AndAlso _ViewModel.HiatusDataTable.Rows.Count > 0 Then

                    If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                        e.DefaultDraw()

                        e.Handled = True

                    End If

                ElseIf _ViewModel.RateDates.ContainsValue(e.Column.FieldName) AndAlso _ViewModel.HiatusDataTable.Rows.Count > 0 Then

                    If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName.Replace("Rate", "Date")) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                        e.DefaultDraw()

                        e.Handled = True

                    End If

                End If

            ElseIf e.Column IsNot Nothing AndAlso e.Column.Name.StartsWith("UnboundColumn") Then

                e.Column.AppearanceHeader.FontStyleDelta = Drawing.FontStyle.Bold

                e.DefaultDraw()

                e.Handled = True

            ElseIf e.Column IsNot Nothing AndAlso _ViewModel.Worksheet IsNot Nothing Then

                If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString OrElse
                            e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString OrElse
                            e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString OrElse
                            e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString Then

                        e.DefaultDraw()

                        ' e.Graphics.DrawString(e.Column.Caption, e.Column.AppearanceHeader.Font, System.Drawing.Brushes.Black, e.Bounds.X, e.Bounds.Y)

                        StartX = e.Graphics.MeasureString(e.Column.GetCaption, e.Column.AppearanceHeader.Font).Width

                        SuperscriptFont = New System.Drawing.Font(e.Column.AppearanceHeader.Font.Name, e.Column.AppearanceHeader.Font.Size - 2)

                        e.Graphics.DrawString("+", SuperscriptFont, System.Drawing.Brushes.Black, e.Bounds.X + StartX, e.Bounds.Y)

                        e.Handled = True

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_ProcessGridKeyEvent(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles BandedDataGridViewForm_MarketDetails.ProcessGridKeyEvent

            If BandedDataGridViewForm_MarketDetails.HasASelectedRow Then

                If e.KeyCode = System.Windows.Forms.Keys.Insert Then

                    If e.Control Then

                        ButtonItemActions_CopyRow.RaiseClick()

                    Else

                        ButtonItemActions_AddRow.RaiseClick()

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_FocusedColumnChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles BandedDataGridViewForm_MarketDetails.FocusedColumnChangedEvent

            If _ViewModel IsNot Nothing AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.RowCount > 0 AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.SelectedRowsCount > 0 Then

                If _ViewModel.HiatusDataTable.Columns.Contains(e.FocusedColumn.FieldName) Then

                    If _ViewModel.HiatusDataTable.Rows(0)(e.FocusedColumn.FieldName) = True Then

                        If e.FocusedColumn.VisibleIndex = BandedDataGridViewForm_MarketDetails.CurrentView.VisibleColumns.Count - 1 Then

                            If BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle <> BandedDataGridViewForm_MarketDetails.CurrentView.RowCount - 1 Then

                                BandedDataGridViewForm_MarketDetails.CurrentView.MoveNext()

                            Else

                                BandedDataGridViewForm_MarketDetails.CurrentView.MoveFirst()

                            End If

                        Else

                            BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn = BandedDataGridViewForm_MarketDetails.CurrentView.VisibleColumns(e.FocusedColumn.VisibleIndex + 1)

                        End If

                    End If

                End If

            End If

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

                        If GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateCPPGroupTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                            True)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateCPPGroupTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                            False)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateGrossImpressionsTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                                    True)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateGrossImpressionsTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                                    False)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateReachTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                         True, String.Empty)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateReachTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                         False, String.Empty)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateFrequencyTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                             True, String.Empty)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateFrequencyTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                             False, String.Empty)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateCPMTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                       True)

                        ElseIf GridGroupSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateCPMTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                       False)

                        ElseIf GridGroupSummaryItem.FieldName.StartsWith("SM") Then

                            e.TotalValue = _Controller.MarketDetails_SubmarketCalculateTotal(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                             GridGroupSummaryItem.FieldName)

                        Else

                            e.TotalValue = _Controller.MarketDetails_CalculateVendorTotalsForColumn(_ViewModel, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString),
                                                                                                    GridGroupSummaryItem.FieldName)

                        End If

                    ElseIf e.IsTotalSummary Then

                        GridColumnSummaryItem = CType(e.Item, DevExpress.XtraGrid.GridColumnSummaryItem)

                        If GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateCPPGroupTotal(_ViewModel, String.Empty, True)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateCPPGroupTotal(_ViewModel, String.Empty, False)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateGrossImpressionsTotal(_ViewModel, String.Empty, True)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateGrossImpressionsTotal(_ViewModel, String.Empty, False)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateReachTotal(_ViewModel, String.Empty, True, String.Empty)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateReachTotal(_ViewModel, String.Empty, False, String.Empty)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateFrequencyTotal(_ViewModel, String.Empty, True, String.Empty)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateFrequencyTotal(_ViewModel, String.Empty, False, String.Empty)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateCPMTotal(_ViewModel, String.Empty, True)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateCPMTotal(_ViewModel, String.Empty, False)

                        ElseIf GridColumnSummaryItem.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString Then

                            e.TotalValue = _Controller.MarketDetails_CalculateRowTotalsTotalColumn(_ViewModel, GridColumnSummaryItem.Tag)

                        ElseIf GridColumnSummaryItem.FieldName.StartsWith("SM") Then

                            e.TotalValue = _Controller.MarketDetails_SubmarketCalculateTotal(_ViewModel, String.Empty, GridColumnSummaryItem.FieldName)

                        ElseIf _ViewModel.DetailDates.ContainsValue(GridColumnSummaryItem.FieldName) Then

                            If GridColumnSummaryItem.Tag Is Nothing Then

                                e.TotalValue = _Controller.MarketDetails_CalculateTotalsForColumn(_ViewModel, GridColumnSummaryItem.FieldName)

                            Else

                                e.TotalValue = _ViewModel.RowTotalsDataTable.Rows(GridColumnSummaryItem.Tag)(GridColumnSummaryItem.FieldName)

                            End If

                        Else

                            e.TotalValue = _Controller.MarketDetails_CalculateTotalsForColumn(_ViewModel, GridColumnSummaryItem.FieldName)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedDataGridViewForm_MarketDetails.RowCellStyleEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If BandedDataGridViewForm_MarketDetails.CurrentView.IsDataRow(e.RowHandle) Then

                If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookProgram.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQHRating.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                    ElseIf DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryAQH.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                    ElseIf DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryImpressions.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                    ElseIf DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryRating.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryShare.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQHRating.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                    ElseIf DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryAQH.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                    ElseIf DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryImpressions.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString) = True Then

                        e.Appearance.ForeColor = System.Drawing.Color.Red

                    ElseIf DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryRating.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString Then

                    DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryShare.ToString) Then

                        e.Appearance.ForeColor = System.Drawing.Color.Blue

                    End If

                    'Else

                    '    If _ViewModel.DoesWorksheetAllowSubmarkets AndAlso ButtonItemSubmarkets_Ratings.Checked AndAlso e.Column.FieldName.StartsWith("SM") Then

                    '        If _ViewModel.WorksheetMarketSubmarketDemos.Any(Function(Entity) Entity.ColumnName = e.Column.FieldName) Then

                    '            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(e.RowHandle), System.Data.DataRowView).Row

                    '            If _Controller.MarketDetails_IsWorksheetMarketDetailSubmarketDemoDataOverridden(_ViewModel, e.Column.FieldName, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString), e.CellValue) Then

                    '                e.Appearance.ForeColor = System.Drawing.Color.Blue
                    '                e.Appearance.FontStyleDelta = Drawing.FontStyle.Bold

                    '            End If

                    '        End If

                    '    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomDrawFilterPanelEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomDrawObjectEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomDrawFilterPanelEvent

            'objects
            Dim GridFilterPanelInfoArgs As DevExpress.XtraGrid.Drawing.GridFilterPanelInfoArgs = Nothing

            GridFilterPanelInfoArgs = e.Info

            GridFilterPanelInfoArgs.ActiveButtonInfo.Bounds = System.Drawing.Rectangle.Empty

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_EndGroupingEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.EndGroupingEvent

            For Each BandedGridColumn In BandedDataGridViewForm_MarketDetails.CurrentView.GroupedColumns.OfType(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)

                BandedGridColumn.OwnerBand = Nothing

            Next

            If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) IsNot Nothing Then

                If BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).GroupIndex = -1 AndAlso
                        BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OwnerBand Is Nothing Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.Bands(GridBandNames.GridBandOtherData.ToString).Columns.Insert(0, BandedDataGridViewForm_MarketDetails.CurrentView.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString))

                End If

            End If

            If _SubmarketsForm IsNot Nothing Then

                _SubmarketsForm.EnableDisableGrouping(BandedDataGridViewForm_MarketDetails.CurrentView.GroupedColumns.Any)

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_EndSortingEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewForm_MarketDetails.EndSortingEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.IsMaxRevisionNumber Then

                    BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                End If

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.UpdateSorting(BandedDataGridViewForm_MarketDetails.CurrentView.SortInfo)

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

                    If e.Value = 0 Then

                        e.Value = Nothing

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

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_CustomRowFilterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles BandedDataGridViewForm_MarketDetails.CustomRowFilterEvent

            Dim TotalSpots As Integer = 0

            If ButtonItemDisplay_HideZeroSpotLines.Checked Then

                TotalSpots = BandedDataGridViewForm_MarketDetails.CurrentView.GetListSourceRowCellValue(e.ListSourceRow, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString)

                If TotalSpots = 0 Then

                    e.Visible = False
                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_GroupRowCollapsingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedDataGridViewForm_MarketDetails.GroupRowCollapsingEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.CollapseGroupRow(e.RowHandle)

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MarketDetails_GroupRowExpandingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles BandedDataGridViewForm_MarketDetails.GroupRowExpandingEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _SubmarketsForm IsNot Nothing Then

                    _SubmarketsForm.ExpandGroupRow(e.RowHandle)

                End If

            End If

        End Sub
        Private Sub ToolTipController_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim CellText As String = String.Empty
            Dim DataRow As System.Data.DataRow = Nothing
            Dim OrderStatus As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered
            Dim HasGeneratePending As Boolean = False

            If e.Info Is Nothing AndAlso e.SelectedControl Is BandedDataGridViewForm_MarketDetails.GridControl Then

                GridHitInfo = BandedDataGridViewForm_MarketDetails.CurrentView.CalcHitInfo(e.ControlMousePosition)

                If GridHitInfo IsNot Nothing Then

                    If GridHitInfo.InRowCell Then

                        If GridHitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString Then

                            CellText = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellDisplayText(GridHitInfo.RowHandle, GridHitInfo.Column)

                            If String.IsNullOrWhiteSpace(CellText) = False Then

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), CellText)

                                e.Info = ToolTipControlInfo

                            End If

                        ElseIf GridHitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString Then

                            CellText = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column)

                            If String.IsNullOrWhiteSpace(CellText) = False Then

                                If CInt(CellText) = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial Then

                                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), "Partially Ordered")

                                Else

                                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses), CInt(CellText)))

                                End If

                                e.Info = ToolTipControlInfo

                            End If

                        ElseIf _ViewModel.DetailDates.ContainsValue(GridHitInfo.Column.FieldName) AndAlso _ViewModel.HiatusDataTable.Rows(0)(GridHitInfo.Column.FieldName) = False Then

                            DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(GridHitInfo.RowHandle), System.Data.DataRowView).Row

                            CellText = FormatCurrency(DataRow(GridHitInfo.Column.FieldName.Replace("Date", "Rate")), 2)

                            If String.IsNullOrWhiteSpace(CellText) = False Then

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), CellText)

                                e.Info = ToolTipControlInfo

                            End If

                        ElseIf GridHitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString Then

                            CellText = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column)

                            For i As Integer = 1 To _ViewModel.DetailDates.Count

                                If BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, "Rate" & i) <> CDbl(CellText) Then

                                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), "Rates Vary by Day/Week")

                                    e.Info = ToolTipControlInfo

                                    Exit For

                                End If

                            Next

                        End If

                    ElseIf GridHitInfo.InGroupRow Then

                        If TypeOf GridHitInfo.RowInfo Is DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo Then

                            OrderStatus = _Controller.MarketDetails_CheckOrderStatus(_ViewModel, CType(GridHitInfo.RowInfo, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).GroupValueText)

                            If OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial Then

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowInfo.RowKey, "Partially Ordered")

                            Else

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowInfo.RowKey, AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses), CInt(OrderStatus)))

                            End If

                            _Controller.MarketDetails_LoadVendorInfo(_ViewModel, CType(GridHitInfo.RowInfo, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).GroupValueText, Nothing, HasGeneratePending)

                            If HasGeneratePending Then

                                ToolTipControlInfo.Text += " / Pending Generate"

                            End If

                            e.Info = ToolTipControlInfo

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemVendors_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemVendors_Edit.Click

            'objects
            Dim VendorCode As String = Nothing

            If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                VendorCode = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, 0), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            Else

                VendorCode = BandedDataGridViewForm_MarketDetails.GetFirstSelectedRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            End If

            If VendorCode IsNot Nothing Then

                AdvantageFramework.Maintenance.Accounting.Presentation.VendorEditDialog.ShowFormDialog(VendorCode, True)

                _Controller.MarketOrderData_SetVendorRepsOnOrder(VendorCode, _ViewModel.SelectedWorksheetMarket.ID, _ViewModel.Worksheet.MediaTypeCode)

            End If

        End Sub
        Private Sub ButtonItemMakegood_Offers_Click(sender As Object, e As EventArgs) Handles ButtonItemMakegood_Offers.Click

            Dim WorksheetMarketDetailID As Integer = 0
            Dim MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel = Nothing
            Dim SelectedVendorCode As String = Nothing

            If BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) Then

                WorksheetMarketDetailID = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, 0), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString)
                SelectedVendorCode = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowCellValue(BandedDataGridViewForm_MarketDetails.CurrentView.GetChildRowHandle(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, 0), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            Else

                WorksheetMarketDetailID = BandedDataGridViewForm_MarketDetails.GetFirstSelectedRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString)
                SelectedVendorCode = BandedDataGridViewForm_MarketDetails.GetFirstSelectedRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

            End If

            If AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMakegoodDialog.ShowFormDialog(WorksheetMarketDetailID, _ViewModel) = Windows.Forms.DialogResult.OK Then

                Me.ShowWaitForm("Saving...")

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                _Controller.MarketDetails_Save(_ViewModel)

                MediaBroadcastWorksheetMarketCreateOrdersViewModel = _Controller.MarketCreateOrders_Load(_ViewModel)

                _Controller.MarketCreateOrders_SetDatesForMakegood(MediaBroadcastWorksheetMarketCreateOrdersViewModel, SelectedVendorCode)

                ContinueToCreateOrders(MediaBroadcastWorksheetMarketCreateOrdersViewModel, True, True, SelectedVendorCode, _ViewModel.WorksheetLineNumbersAccepted.ToArray)

                RefreshVendorStatus()

                Me.CloseWaitForm()

            Else

                Me.ShowWaitForm("Refreshing...")

                RefreshVendorStatus()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemOrders_OrderStatus_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_OrderStatus.Click

            AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetOrderStatusDialog.ShowFormDialog(_MediaBroadcastWorksheetMarketID)

        End Sub
        Private Sub ButtonItemOrders_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemOrders_Refresh.Click

            RefreshVendorStatus()

        End Sub
        Private Sub ButtonItemVendors_Traffic_Click(sender As Object, e As EventArgs) Handles ButtonItemVendors_Traffic.Click

            'objects
            Dim [Continue] As Boolean = False

            CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso HasNoErrors() Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.MarketDetails_Save(_ViewModel)

                        RefreshMediaBroadcastWorksheetSetupForm()

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If AdvantageFramework.Media.Presentation.MediaTrafficDialog.ShowFormDialog(_ViewModel.SelectedWorksheetMarket.ID) = Windows.Forms.DialogResult.OK Then

                        'Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        'BeginDataUpdate()

                        '_Controller.MarketDetails_SelectedWorksheetMarketChanged(_ViewModel, ComboBoxItemMarkets_Markets.ComboBoxEx.SelectedValue)

                        'LoadGrid()

                        'EndDataUpdate()

                        'ExpandAllGroups()

                        'Me.ClearChanged()

                        'RefreshViewModel(False)

                        'BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                        'Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        'Me.RaiseClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemMakegood_AddReplacement_Click(sender As Object, e As EventArgs) Handles ButtonItemMakegood_AddReplacement.Click

            'objects
            Dim VendorCode As String = String.Empty
            Dim GroupRowHandle As Integer = -1
            Dim RowHandle As Integer = -1
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = 0
            Dim InsertedDataRow As System.Data.DataRow = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

            If BandedDataGridViewForm_MarketDetails.HasOnlyOneSelectedRow AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) = False Then

                VendorCode = BandedDataGridViewForm_MarketDetails.GetFirstSelectedRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)

                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

                RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                BeginDataUpdate()

                InsertedDataRow = _Controller.MarketDetails_AddReplacementRow(_ViewModel, VendorCode, RowIndex)

                RefreshViewModel(False)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                BandedDataGridViewForm_MarketDetails.SetUserEntryChanged()

                BandedDataGridViewForm_MarketDetails.CurrentView.UpdateSummary()

                EndDataUpdate()

                BandedDataGridViewForm_MarketDetails.CurrentView.BeginSelection()

                BandedDataGridViewForm_MarketDetails.CurrentView.ClearSelection()

                RowIndex = _ViewModel.DataTable.Rows.IndexOf(InsertedDataRow)

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                    _Controller.MarketDetails_MarketDetailDateValueChanged(_ViewModel, RowIndex, BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString).FieldName)

                Next

                BandedDataGridViewForm_MarketDetails.CurrentView.SelectRow(BandedDataGridViewForm_MarketDetails.CurrentView.GetRowHandle(RowIndex))
                BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle = BandedDataGridViewForm_MarketDetails.CurrentView.GetRowHandle(RowIndex)

                GridColumn = Me.BandedDataGridViewForm_MarketDetails.Columns(_ViewModel.DetailDates(_ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD).First).ToString)

                If GridColumn IsNot Nothing Then

                    BandedDataGridViewForm_MarketDetails.CurrentView.FocusedColumn = GridColumn
                    BandedDataGridViewForm_MarketDetails.CurrentView.SelectCell(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle, GridColumn)

                End If

                BandedDataGridViewForm_MarketDetails.CurrentView.EndSelection()

                BandedDataGridViewForm_MarketDetails.CurrentView.Focus()

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemMakegood_Details_Click(sender As Object, e As EventArgs) Handles ButtonItemMakegood_Details.Click

            'objects
            Dim VendorCode As String = String.Empty
            Dim LineNumber As Integer = 0

            CloseGridEditorAndSaveValueToDataSource()

            If BandedDataGridViewForm_MarketDetails.HasOnlyOneSelectedRow AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) = False Then

                VendorCode = BandedDataGridViewForm_MarketDetails.GetFirstSelectedRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)
                LineNumber = BandedDataGridViewForm_MarketDetails.GetFirstSelectedRowCellValue(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString)

                MediaBroadcastWorksheetMarketDetailMakegoodDetailsDialog.ShowFormDialog(_ViewModel, VendorCode, LineNumber)

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemMakegood_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemMakegood_Add.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            CloseGridEditorAndSaveValueToDataSource()

            If BandedDataGridViewForm_MarketDetails.HasOnlyOneSelectedRow AndAlso BandedDataGridViewForm_MarketDetails.CurrentView.IsGroupRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle) = False Then

                DataRow = CType(BandedDataGridViewForm_MarketDetails.CurrentView.GetRow(BandedDataGridViewForm_MarketDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

                RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

                Makegood(RowIndex)

            End If

        End Sub
        Private Sub ButtonItemAutoFill_SelectSpots_Click(sender As Object, e As EventArgs) Handles ButtonItemAutoFill_SelectSpots.Click

            ToggleSelectionMode(True)

        End Sub
        Private Sub DateEditPeriodDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditPeriodStart_Date.EditValueChanged, DateEditPeriodEnd_Date.EditValueChanged

            Dim PeriodStartErrorText As String = String.Empty
            Dim PeriodEndErrorText As String = String.Empty
            Dim RowIndexes As Generic.List(Of Integer) = Nothing

            If Me.FormShown AndAlso _ViewModel IsNot Nothing AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If _PuertoRicoPeriodWarningShown = False AndAlso AdvantageFramework.WinForm.MessageBox.Show(Me,
                                                              "WARNING: By changing survey criteria for a market, all market schedule data will be recalculated." & vbNewLine & vbNewLine & "Are you sure you want to continue?",
                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    _PuertoRicoPeriodWarningShown = True

                End If

                _Controller.MarketDetails_SetSelectedMarketPeriodDates(DateEditPeriodStart_Date.GetValue, DateEditPeriodEnd_Date.GetValue, _ViewModel, PeriodStartErrorText, PeriodEndErrorText)

                DateEditPeriodStart_Date.ErrorText = PeriodStartErrorText
                DateEditPeriodEnd_Date.ErrorText = PeriodEndErrorText

                DateEditPeriodStart_Date.SetRequired(_ViewModel.SelectedWorksheetMarket.PeriodStart.HasValue OrElse _ViewModel.SelectedWorksheetMarket.PeriodEnd.HasValue)
                DateEditPeriodEnd_Date.SetRequired(_ViewModel.SelectedWorksheetMarket.PeriodStart.HasValue OrElse _ViewModel.SelectedWorksheetMarket.PeriodEnd.HasValue)

                DateEditPeriodStart_Date.Refresh()
                DateEditPeriodEnd_Date.Refresh()

                _Controller.MarketDetails_UserEntryChanged(_ViewModel)

                If _ViewModel.SelectedWorksheetMarket.PeriodStart.HasValue AndAlso _ViewModel.SelectedWorksheetMarket.PeriodEnd.HasValue AndAlso
                        String.IsNullOrWhiteSpace(PeriodStartErrorText) AndAlso String.IsNullOrWhiteSpace(PeriodEndErrorText) Then

                    Me.ShowWaitForm("Refreshing Ratings...")

                    'recalculate
                    RowIndexes = New Generic.List(Of Integer)

                    For DataTableRowIndex As Integer = 0 To _ViewModel.DataTable.Rows.Count - 1

                        RowIndexes.Add(DataTableRowIndex)

                    Next

                    _Controller.MarketDetails_LoadPrimaryRatingAndShareData(_ViewModel, RowIndexes)

                    _PuertoRicoPeriodWarningShown = False

                    Me.CloseWaitForm()

                End If

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub DateEditPeriodStart_Date_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles DateEditPeriodStart_Date.FinalizeValidationEvent, DateEditPeriodEnd_Date.FinalizeValidationEvent

            Dim PeriodStartErrorText As String = String.Empty
            Dim PeriodEndErrorText As String = String.Empty

            If Me.FormShown AndAlso _ViewModel IsNot Nothing AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.MarketDetails_SetSelectedMarketPeriodDates(DateEditPeriodStart_Date.GetValue, DateEditPeriodEnd_Date.GetValue, _ViewModel, PeriodStartErrorText, PeriodEndErrorText)

                DateEditPeriodStart_Date.ErrorText = PeriodStartErrorText
                DateEditPeriodEnd_Date.ErrorText = PeriodEndErrorText

                DateEditPeriodStart_Date.Refresh()
                DateEditPeriodEnd_Date.Refresh()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
