Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailMakegoodDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum GridBandNames
            GridBandData
            GridBandOtherData
            'GridBandPrimaryDemo
            'GridBandSecondaryDemo
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsMakegoodViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        'Protected _MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByRef MediaBroadcastWorksheetMarketDetailsMakegoodViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsMakegoodViewModel) ', ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketDetailsMakegoodViewModel
            '_MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMarketDetailsViewModel

        End Sub
        Private Sub RefreshViewModel()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            LabelForm_DaypartValue.Text = _ViewModel.OriginalDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString)
            LabelForm_LengthValue.Text = _ViewModel.OriginalDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString)
            LabelForm_DaysValue.Text = _ViewModel.OriginalDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString)
            LabelForm_CableNetworkValue.Text = _ViewModel.OriginalDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString)
            LabelForm_StartTimeValue.Text = _ViewModel.OriginalDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString) & ""
            LabelForm_EndTimeValue.Text = _ViewModel.OriginalDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString) & ""
            LabelForm_DefaultRateValue.Text = _ViewModel.OriginalDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString)
            LabelForm_ProgramValue.Text = _ViewModel.OriginalDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString)

            BandedDataGridViewForm_MakegoodDetails.DataSource = _ViewModel.DataTable

            FormatGridOriginalState()

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = BandedDataGridViewForm_MakegoodDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)
                Exit For

            Next

            BandedDataGridViewForm_MakegoodDetails.CurrentView.BestFitColumns()

            BandedDataGridViewForm_MakegoodDetails.CurrentView.BeginSelection()

            BandedDataGridViewForm_MakegoodDetails.CurrentView.ClearSelection()

            BandedDataGridViewForm_MakegoodDetails.CurrentView.SelectRow(1)
            BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedRowHandle = 1

            If GridColumn IsNot Nothing Then

                BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedColumn = GridColumn
                BandedDataGridViewForm_MakegoodDetails.CurrentView.SelectCell(1, GridColumn)

            End If

            BandedDataGridViewForm_MakegoodDetails.CurrentView.EndSelection()

            BandedDataGridViewForm_MakegoodDetails.CurrentView.Focus()

        End Sub
        Private Sub SetControlPropertySettings()

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub FormatGridOriginalState()

            'objects
            'Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            'GridBand = BandedDataGridViewForm_MakegoodDetails.CurrentView.Bands.Add()

            'GridBand.Name = GridBandNames.GridBandData.ToString
            'GridBand.Caption = ""
            'GridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            'GridBand.OptionsBand.ShowInCustomizationForm = False

            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString))

            GridBand = BandedDataGridViewForm_MakegoodDetails.CurrentView.Bands.Add()

            GridBand.Name = GridBandNames.GridBandOtherData.ToString
            GridBand.Caption = "Enter number of preempted spots for each date"
            GridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            'GridBand.OptionsBand.AllowMove = False
            'GridBand.OptionsBand.AllowPress = False
            GridBand.OptionsBand.ShowInCustomizationForm = False

            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns("RowType"))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString))

            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString))

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString))

            End If

            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString))
            'GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString))

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString))

            End If

            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString))


            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString))

            End If

            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString))

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = BandedDataGridViewForm_MakegoodDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                GridBand.Columns.Add(GridColumn)

                GridColumn = BandedDataGridViewForm_MakegoodDetails.Columns(_ViewModel.RateDates(DetailDate).ToString)

                GridBand.Columns.Add(GridColumn)

            Next

            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString))
            GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString))

            BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible("RowType")
            BandedDataGridViewForm_MakegoodDetails.Columns("RowType").Caption = ""

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString).OptionsColumn.AllowShowHide = False

            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).Group()
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.AllowMove = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.AllowEdit = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.ShowInCustomizationForm = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.AllowMove = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.ShowInCustomizationForm = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OnHold.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowMove = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.ShowInCustomizationForm = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowShowHide = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString).OptionsColumn.AllowEdit = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).DisplayFormat.FormatString = "0000"
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.AllowEdit = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).DisplayFormat.FormatString = "000"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.AllowEdit = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.AllowMove = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.ShowInCustomizationForm = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.RevisionNumber.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePost.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostImpressions.ToString).OptionsColumn.AllowShowHide = False

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.AllowMove = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.ShowInExpressionEditor = False
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OverridePostAQH.ToString).OptionsColumn.AllowShowHide = False

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString)
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString).OptionsColumn.AllowShowHide = False

            End If

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString)

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString).DisplayFormat.FormatString = "f0"

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString)

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString).DisplayFormat.FormatString = "t"

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString).DisplayFormat.FormatString = "t"

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString)
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString).OptionsColumn.AllowShowHide = False

            End If

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString)

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString)
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString).OptionsColumn.AllowMove = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString).OptionsColumn.ShowInExpressionEditor = False
                BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString).OptionsColumn.AllowShowHide = False

            End If

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString)

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString)
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString).DisplayFormat.FormatString = "c2"

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(GD) GD)

                GridColumn = BandedDataGridViewForm_MakegoodDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                'GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                'GridGroupSummaryItem.FieldName = GridColumn.FieldName
                'GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                'GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn
                'GridGroupSummaryItem.DisplayFormat = "{0:f0}"

                'BandedDataGridViewForm_MakegoodDetails.CurrentView.GroupSummary.Add(GridGroupSummaryItem)
                'AddSummaryItemToColumn(GridColumn, "{0:f0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

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

                GridColumn = BandedDataGridViewForm_MakegoodDetails.Columns(_ViewModel.RateDates(RateDate).ToString)

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

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).DisplayFormat.FormatString = "f0"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).OptionsColumn.AllowMove = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).OptionsColumn.ShowInCustomizationForm = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).OptionsColumn.AllowShowHide = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString), "{0:f0}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString), "{0:f0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).DisplayFormat.FormatString = "c2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.AllowMove = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.ShowInCustomizationForm = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.AllowShowHide = False
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalDollars.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalNet.ToString)
            'GridBand = BandedDataGridViewForm_MakegoodDetails.CurrentView.Bands.Add()

            'GridBand.Name = GridBandNames.GridBandPrimaryDemo.ToString
            'GridBand.Caption = "Primary Demo"
            'GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold

            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString))

            'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString))

            'End If

            'GridBand = BandedDataGridViewForm_MakegoodDetails.CurrentView.Bands.Add()

            'GridBand.Name = GridBandNames.GridBandSecondaryDemo.ToString
            'GridBand.Caption = "Secondary Demo"
            'GridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold

            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString))

            'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString))
            '    GridBand.Columns.Add(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString))

            'End If

            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).DisplayFormat.FormatString = "f2"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.AllowEdit = True

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).DisplayFormat.FormatString = "f2"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.AllowEdit = True

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).DisplayFormat.FormatString = "f2"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.AllowEdit = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.AllowShowHide = False

            'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryShare.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryHPUT.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).DisplayFormat.FormatString = "f1"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString).OptionsColumn.AllowEdit = True

            'End If

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString).DisplayFormat.FormatString = "c2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString).DisplayFormat.FormatString = "f2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.AllowShowHide = False

            'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString).OptionsColumn.AllowEdit = True

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).DisplayFormat.FormatString = "f1"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeRating.ToString).OptionsColumn.AllowEdit = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCume.ToString).OptionsColumn.AllowEdit = False

            'End If

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).DisplayFormat.FormatString = "p1"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).DisplayFormat.FormatString = "f1"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.AllowEdit = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.AllowEdit = True

            'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCumeImpressions.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString).OptionsColumn.AllowEdit = True

            'End If

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString).DisplayFormat.FormatString = "n0"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).DisplayFormat.FormatString = "c2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).DisplayFormat.FormatString = "f2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString).OptionsColumn.AllowEdit = False

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatString = "n0"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString).OptionsColumn.AllowEdit = False

            '=========================================
            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).DisplayFormat.FormatString = "f2"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.AllowEdit = True

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).DisplayFormat.FormatString = "f2"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.AllowEdit = True

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).DisplayFormat.FormatString = "f2"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.AllowEdit = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.AllowShowHide = False

            'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryShare.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryHPUT.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).DisplayFormat.FormatString = "f1"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString).OptionsColumn.AllowEdit = True

            'End If

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).DisplayFormat.FormatString = "c2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPP.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).DisplayFormat.FormatString = "f2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGRP.ToString), "{0:f2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.AllowShowHide = False

            'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString).OptionsColumn.AllowEdit = True

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).DisplayFormat.FormatString = "f1"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeRating.ToString).OptionsColumn.AllowEdit = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCume.ToString).OptionsColumn.AllowEdit = False

            'End If

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).DisplayFormat.FormatString = "p1"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryReach.ToString), "{0:p1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).DisplayFormat.FormatString = "f1"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryFrequency.ToString), "{0:f1}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.AllowEdit = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.AllowEdit = True

            'ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.AllowMove = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.ShowInCustomizationForm = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.ShowInExpressionEditor = False
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCumeImpressions.ToString).OptionsColumn.AllowShowHide = False

            '    BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString)
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).DisplayFormat.FormatString = "n0"
            '    BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString).OptionsColumn.AllowEdit = True

            'End If

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).DisplayFormat.FormatString = "n0"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryGrossImpressions.ToString), "{0:n0}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).DisplayFormat.FormatString = "c2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString).OptionsColumn.AllowEdit = False
            'AddGroupSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom)
            'AddSummaryItemToColumn(BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryCPM.ToString), "{0:c2}", DevExpress.Data.SummaryItemType.Custom, Nothing)

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).DisplayFormat.FormatString = "f2"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString).OptionsColumn.AllowEdit = False

            'BandedDataGridViewForm_MakegoodDetails.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString)
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).DisplayFormat.FormatString = "n0"
            'BandedDataGridViewForm_MakegoodDetails.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString).OptionsColumn.AllowEdit = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketDetailsMakegoodViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsMakegoodViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketDetailMakegoodDialog As MediaBroadcastWorksheetMarketDetailMakegoodDialog = Nothing

            MediaBroadcastWorksheetMarketDetailMakegoodDialog = New MediaBroadcastWorksheetMarketDetailMakegoodDialog(MediaBroadcastWorksheetMarketDetailsMakegoodViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketDetailMakegoodDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailMakegoodDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable

            Me.StartPosition = Windows.Forms.FormStartPosition.WindowsDefaultLocation

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailMakegoodDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            RefreshViewModel()

            Me.ClearChanged()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

            BandedDataGridViewForm_MakegoodDetails.CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub BandedDataGridViewForm_MakegoodDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles BandedDataGridViewForm_MakegoodDetails.ShowingEditorEvent

            If BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedRowHandle = 0 Then

                e.Cancel = True

            ElseIf BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedRowHandle = 1 AndAlso BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedColumn.FieldName.StartsWith("Date") = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MakegoodDetails_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles BandedDataGridViewForm_MakegoodDetails.ValidatingEditorEvent

            If BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedRowHandle = 1 Then 'non-airing spots

                If IsNumeric(e.Value) = False OrElse e.Value < 0 Then

                    e.Value = 0

                End If

                If DirectCast(BandedDataGridViewForm_MakegoodDetails.CurrentView.GetRow(0), System.Data.DataRowView).Item(BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedColumn.FieldName) < e.Value Then

                    e.Valid = True

                    AdvantageFramework.WinForm.MessageBox.Show("Spots cannot exceed " & DirectCast(BandedDataGridViewForm_MakegoodDetails.CurrentView.GetRow(0), System.Data.DataRowView).Item(BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedColumn.FieldName))

                    e.Value = DirectCast(BandedDataGridViewForm_MakegoodDetails.CurrentView.GetRow(0), System.Data.DataRowView).Item(BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedColumn.FieldName)

                ElseIf DirectCast(BandedDataGridViewForm_MakegoodDetails.CurrentView.GetRow(BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedRowHandle), System.Data.DataRowView).Item(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString) = True Then

                    If (DirectCast(BandedDataGridViewForm_MakegoodDetails.CurrentView.GetRow(0), System.Data.DataRowView).Item(BandedDataGridViewForm_MakegoodDetails.CurrentView.FocusedColumn.FieldName) - e.Value) Mod 2 <> 0 Then

                        e.Valid = True

                        AdvantageFramework.WinForm.MessageBox.Show("WARNING: Bookends must be an even number of spots.")

                        e.Value = 0

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MakegoodDetails_CustomRowFilterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles BandedDataGridViewForm_MakegoodDetails.CustomRowFilterEvent

            If e.ListSourceRow = 2 Then

                e.Visible = False
                e.Handled = True

            End If

        End Sub
        Private Sub BandedDataGridViewForm_MakegoodDetails_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedDataGridViewForm_MakegoodDetails.CustomColumnDisplayTextEvent

            'objects
            Dim RowHandle As Integer = 0

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString Then

                RowHandle = BandedDataGridViewForm_MakegoodDetails.CurrentView.GetRowHandle(e.ListSourceRowIndex)

                If BandedDataGridViewForm_MakegoodDetails.CurrentView.IsValidRowHandle(RowHandle) AndAlso
                        _ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString) > 0 Then

                    e.DisplayText = Format(_ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.LineNumber.ToString), "0000") & "-" & Format(_ViewModel.DataTable.Rows(e.ListSourceRowIndex)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.MakegoodNumber.ToString), "00")

                End If

            End If

        End Sub

        'Private Sub DateEditForm_DateFrom_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs)

        '    If _MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.ContainsKey(e.Date) = False OrElse
        '            _MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows(_ViewModel.RowIndex)(_MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates(e.Date)) < 1 OrElse
        '            _MediaBroadcastWorksheetMarketDetailsViewModel.HiatusDataTable.Rows(0)(_MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates(e.Date)) = True Then

        '        e.IsDisabled = True

        '    Else

        '        e.IsDisabled = False

        '    End If

        'End Sub
        'Private Sub DateEditForm_DateFrom_DrawItem(sender As Object, e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs)

        '    'objects
        '    Dim Brush As System.Drawing.Brush = Nothing
        '    Dim StringFormat As System.Drawing.StringFormat = Nothing

        '    If e.Disabled Then

        '        Brush = Drawing.Brushes.Gray

        '        StringFormat = New System.Drawing.StringFormat
        '        StringFormat.Alignment = System.Drawing.StringAlignment.Center
        '        StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

        '        e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

        '        e.State = DevExpress.Utils.Drawing.ObjectState.Disabled

        '        e.Handled = True

        '    Else

        '        Brush = Drawing.Brushes.Black

        '        StringFormat = New System.Drawing.StringFormat
        '        StringFormat.Alignment = System.Drawing.StringAlignment.Center
        '        StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

        '        e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

        '        e.Handled = True

        '    End If

        'End Sub
        'Private Sub DateEditForm_DateFrom_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

        '    If _ViewModel IsNot Nothing AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

        '        _Controller.MarketDetailsMakegood_DateChanging(_ViewModel, _MediaBroadcastWorksheetMarketDetailsViewModel, e.NewValue)

        '        FormatControls()

        '    End If

        'End Sub

        'Private Sub NumericInputForm_RemoveSpots_EditValueChanged(sender As Object, e As EventArgs)

        '    'objects
        '    Dim WarnUser As Boolean = False
        '    Dim CheckBookend As Boolean = True

        '    If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
        '            _ViewModel IsNot Nothing Then

        '        If NumericInputForm_RemoveSpots.EditValue > _ViewModel.MaximunTotalSpots Then

        '            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Modifying

        '            NumericInputForm_RemoveSpots.EditValue = NumericInputForm_RemoveSpots.OldEditValue

        '            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        '            CheckBookend = False

        '            AdvantageFramework.WinForm.MessageBox.Show("You cannot remove more spots than entered, please correct.")

        '        End If

        '        If _ViewModel.IsRowBookend AndAlso CheckBookend Then

        '            _Controller.MarketDetailsMakegood_SpotsChanging(_ViewModel, NumericInputForm_RemoveSpots.EditValue, WarnUser)

        '            If WarnUser Then

        '                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Modifying

        '                NumericInputForm_RemoveSpots.EditValue = NumericInputForm_RemoveSpots.OldEditValue

        '                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        '                AdvantageFramework.WinForm.MessageBox.Show("WARNING: Bookends must be an even number of spots.")

        '            End If

        '        End If

        '    End If

        'End Sub

#End Region

#End Region

    End Class

End Namespace
