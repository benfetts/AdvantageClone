Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMakegoodDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum GridBandNames
            GridBandFixedLeft
            GridBandNonDemographic
            GridBandSpotRateTotal
            GridBandPrimaryDemo
            GridBandSecondaryDemo
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
        Protected _MediaBroadcastWorksheetMarketDetailID As Integer = 0
        Protected _MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _EmptyEditor As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel
            Get
                MediaBroadcastWorksheetMarketDetailsViewModel = _MediaBroadcastWorksheetMarketDetailsViewModel
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetMarketDetailID As Integer, ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailID

            _MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMarketDetailsViewModel

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_MediaBroadcastWorksheetMarketDetailID, True)

            TextBoxPanel_VendorName.Text = _ViewModel.VendorName

            LoadGrid()

        End Sub
        Private Sub LoadGrid()

            Dim VisibleIndex As Integer = 0
            Dim DateInt As Integer = 0

            BandedDataGridViewPanel_StagingMakegoods.DataSource = _ViewModel.MakegoodDataTable

            FormatGrid()

            VisibleIndex = BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandSpotRateTotal.ToString).Columns(0).VisibleIndex

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.BeginUpdate()

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandSpotRateTotal.ToString).Columns.Clear()

            For Each KeyValuePair In _ViewModel.SpotDates.OrderBy(Function(SD) SD.Value)

                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandSpotRateTotal.ToString).Columns.Add(BandedDataGridViewPanel_StagingMakegoods.Columns(KeyValuePair.Key))

                BandedDataGridViewPanel_StagingMakegoods.Columns(KeyValuePair.Key).Visible = True
                DateInt = _ViewModel.SpotDates.Item(KeyValuePair.Key)

                If DateInt.ToString.Length = 8 Then

                    BandedDataGridViewPanel_StagingMakegoods.Columns(KeyValuePair.Key).Caption = Format(DateSerial(DateInt.ToString.Substring(0, 4), DateInt.ToString.Substring(4, 2), DateInt.ToString.Substring(6, 2)), "MMM d")

                End If

                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandSpotRateTotal.ToString).Columns.Add(BandedDataGridViewPanel_StagingMakegoods.Columns(KeyValuePair.Key.Replace("Spot", "Rate")))
                BandedDataGridViewPanel_StagingMakegoods.Columns(KeyValuePair.Key.Replace("Spot", "Rate")).Visible = False

            Next

            If BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) IsNot Nothing Then

                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandSpotRateTotal.ToString).Columns.Add(BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString))

            End If

            If BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) IsNot Nothing Then

                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandSpotRateTotal.ToString).Columns.Add(BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString))

            End If

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.EndUpdate()

            ButtonItemActions_Accept.Enabled = BandedDataGridViewPanel_StagingMakegoods.HasRows
            ButtonItemActions_Reject.Enabled = BandedDataGridViewPanel_StagingMakegoods.HasRows

        End Sub
        Private Sub SaveViewModel()



        End Sub
        Private Sub RefreshViewModel(RefreshData As Boolean)



        End Sub
        Private Sub SetupGrid(Show As Boolean)

            'objects
            Dim FixedLeftGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim NonDemographicGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim SpotRateTotalsGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim PrimaryDemographicGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim SecondaryDemographicGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim ColumnVisibleIndex As Integer = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.BeginUpdate()

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Clear()
            BandedDataGridViewPanel_StagingMakegoods.AutoUpdateViewCaption = False

            FixedLeftGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            FixedLeftGridBand.Name = GridBandNames.GridBandFixedLeft.ToString
            FixedLeftGridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            FixedLeftGridBand.Caption = " "
            FixedLeftGridBand.OptionsBand.AllowMove = False
            FixedLeftGridBand.OptionsBand.ShowInCustomizationForm = False

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Add(FixedLeftGridBand)

            NonDemographicGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            NonDemographicGridBand.Name = GridBandNames.GridBandNonDemographic.ToString
            NonDemographicGridBand.Caption = " "
            NonDemographicGridBand.OptionsBand.AllowMove = False
            NonDemographicGridBand.OptionsBand.ShowInCustomizationForm = False

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Add(NonDemographicGridBand)

            SpotRateTotalsGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            SpotRateTotalsGridBand.Name = GridBandNames.GridBandSpotRateTotal.ToString
            SpotRateTotalsGridBand.Caption = " "
            SpotRateTotalsGridBand.OptionsBand.AllowMove = False
            SpotRateTotalsGridBand.OptionsBand.ShowInCustomizationForm = False

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Add(SpotRateTotalsGridBand)

            If Not String.IsNullOrWhiteSpace(_ViewModel.PrimaryDemographic) Then

                PrimaryDemographicGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                PrimaryDemographicGridBand.Name = GridBandNames.GridBandPrimaryDemo.ToString
                PrimaryDemographicGridBand.Caption = _ViewModel.PrimaryDemographic
                PrimaryDemographicGridBand.OptionsBand.AllowMove = False
                PrimaryDemographicGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                PrimaryDemographicGridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
                PrimaryDemographicGridBand.OptionsBand.ShowInCustomizationForm = False

                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Add(PrimaryDemographicGridBand)

            End If

            'If Not String.IsNullOrWhiteSpace(_ViewModel.SecondaryDemographic) Then

            '    SecondaryDemographicGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            '    SecondaryDemographicGridBand.Name = GridBandNames.GridBandSecondaryDemo.ToString
            '    SecondaryDemographicGridBand.Caption = _ViewModel.SecondaryDemographic
            '    SecondaryDemographicGridBand.OptionsBand.AllowMove = False
            '    SecondaryDemographicGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            '    SecondaryDemographicGridBand.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
            '    SecondaryDemographicGridBand.OptionsBand.ShowInCustomizationForm = False
            '    BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Add(SecondaryDemographicGridBand)

            'End If

            ColumnVisibleIndex = 1

            For Each GridColumn In BandedDataGridViewPanel_StagingMakegoods.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            For Each GridColumn In BandedDataGridViewPanel_StagingMakegoods.Columns

                If GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetworkCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsSubmitted.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RateDiffersFlag.ToString Then

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString Then

                    GridColumn.Visible = True
                    GridColumn.Caption = "Is Approved"

                    NonDemographicGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString Then

                    GridColumn.Visible = True
                    GridColumn.Caption = "Daypart"

                    NonDemographicGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName.StartsWith("Spot") Then

                    GridColumn.Visible = True
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridColumn.DisplayFormat.FormatString = "n0"
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                    GridColumn.OptionsColumn.AllowMove = False

                    If GridColumn.CustomizationSearchCaption.Length = 8 Then

                        GridColumn.Caption = Format(DateSerial(GridColumn.CustomizationSearchCaption.Substring(0, 4), GridColumn.CustomizationSearchCaption.Substring(4, 2), GridColumn.CustomizationSearchCaption.Substring(6, 2)), "MMM d")

                    End If

                    SpotRateTotalsGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName.StartsWith("Rate") Then

                    GridColumn.Visible = Show
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridColumn.DisplayFormat.FormatString = "n2"
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                    GridColumn.OptionsColumn.AllowMove = False

                    SpotRateTotalsGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString Then

                    GridColumn.Visible = True
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridColumn.DisplayFormat.FormatString = "n2"

                    NonDemographicGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString Then

                    GridColumn.Visible = True
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    If _ViewModel.MediaType = "T" Then

                        GridColumn.DisplayFormat.FormatString = "n2"
                        GridColumn.Caption = "Rating"

                    Else

                        GridColumn.DisplayFormat.FormatString = "n1"
                        GridColumn.Caption = "AQH Rtg"

                    End If

                    If PrimaryDemographicGridBand IsNot Nothing AndAlso GridColumn.FieldName.StartsWith("Primary") Then

                        PrimaryDemographicGridBand.Columns.Add(GridColumn)

                    ElseIf SecondaryDemographicGridBand IsNot Nothing Then

                        SecondaryDemographicGridBand.Columns.Add(GridColumn)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString Then

                    GridColumn.Visible = True
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridColumn.DisplayFormat.FormatString = "n2"

                    If PrimaryDemographicGridBand IsNot Nothing AndAlso GridColumn.FieldName.StartsWith("Primary") Then

                        PrimaryDemographicGridBand.Columns.Add(GridColumn)

                    ElseIf SecondaryDemographicGridBand IsNot Nothing Then

                        SecondaryDemographicGridBand.Columns.Add(GridColumn)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString Then

                    GridColumn.Visible = True
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridColumn.DisplayFormat.FormatString = "n2"

                    If PrimaryDemographicGridBand IsNot Nothing AndAlso GridColumn.FieldName.StartsWith("Primary") Then

                        PrimaryDemographicGridBand.Columns.Add(GridColumn)

                    ElseIf SecondaryDemographicGridBand IsNot Nothing Then

                        SecondaryDemographicGridBand.Columns.Add(GridColumn)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString Then

                    GridColumn.Visible = True
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    If _ViewModel.MediaType = "T" Then

                        GridColumn.DisplayFormat.FormatString = "n1"
                        GridColumn.Caption = "Imps (000)"

                    Else

                        GridColumn.DisplayFormat.FormatString = "n0"
                        GridColumn.Caption = "AQH (00)"

                    End If

                    If PrimaryDemographicGridBand IsNot Nothing AndAlso GridColumn.FieldName.StartsWith("Primary") Then

                        PrimaryDemographicGridBand.Columns.Add(GridColumn)

                    ElseIf SecondaryDemographicGridBand IsNot Nothing Then

                        SecondaryDemographicGridBand.Columns.Add(GridColumn)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString Then

                    GridColumn.Visible = True
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    If _ViewModel.MediaType = "T" Then

                        GridColumn.DisplayFormat.FormatString = "n1"
                        GridColumn.Caption = "GIMP (000)"

                    Else

                        GridColumn.DisplayFormat.FormatString = "n0"
                        GridColumn.Caption = "GIMP (00)"

                    End If

                    If PrimaryDemographicGridBand IsNot Nothing AndAlso GridColumn.FieldName.StartsWith("Primary") Then

                        PrimaryDemographicGridBand.Columns.Add(GridColumn)

                    ElseIf SecondaryDemographicGridBand IsNot Nothing Then

                        SecondaryDemographicGridBand.Columns.Add(GridColumn)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString Then

                    GridColumn.Visible = True
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridColumn.DisplayFormat.FormatString = "n2"

                    If PrimaryDemographicGridBand IsNot Nothing AndAlso GridColumn.FieldName.StartsWith("Primary") Then

                        PrimaryDemographicGridBand.Columns.Add(GridColumn)

                    ElseIf SecondaryDemographicGridBand IsNot Nothing Then

                        SecondaryDemographicGridBand.Columns.Add(GridColumn)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString Then

                    GridColumn.Visible = True

                    SpotRateTotalsGridBand.Columns.Add(GridColumn)

                Else

                    GridColumn.Visible = True

                    If GridColumn.FieldName.StartsWith("Impressions") Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If _ViewModel.MediaType = "T" Then

                            GridColumn.DisplayFormat.FormatString = "n1"
                            GridColumn.Caption = "Imps (000)"

                        ElseIf _ViewModel.MediaType = "R" Then

                            GridColumn.DisplayFormat.FormatString = "n0"
                            GridColumn.Caption = "AQH (00)"

                        End If

                    End If

                    If GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString Then

                        GridColumn.OptionsColumn.AllowMove = False

                        FixedLeftGridBand.Columns.Add(GridColumn)

                    Else

                        NonDemographicGridBand.Columns.Add(GridColumn)

                    End If

                End If

                If GridColumn.Visible Then

                    GridColumn.VisibleIndex = ColumnVisibleIndex
                    ColumnVisibleIndex = ColumnVisibleIndex + 1

                End If

            Next

            If BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) IsNot Nothing Then

                SpotRateTotalsGridBand.Columns.Add(BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString))

                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString).Visible = True
                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString).DisplayFormat.FormatString = "n0"
                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString).OptionsColumn.AllowMove = False

            End If

            If BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) IsNot Nothing Then

                SpotRateTotalsGridBand.Columns.Add(BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString))

                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Visible = True
                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).DisplayFormat.FormatString = "n2"
                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).OptionsColumn.ShowInCustomizationForm = False
                BandedDataGridViewPanel_StagingMakegoods.CurrentView.Columns(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).OptionsColumn.AllowMove = False

            End If

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.EndUpdate()

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.BestFitColumns()

        End Sub
        Private Function GetRectangleForRow(TotalIndex As Integer, Bounds As System.Drawing.Rectangle, FontHeight As Integer) As System.Drawing.Rectangle

            'objects
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim GridColumnRectangle As System.Drawing.Rectangle = Nothing
            Dim HorizontalIndent As Integer = 0
            Dim VerticalIndent As Integer = Bounds.Height / 9
            Dim GridViewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = Nothing

            GridViewInfo = BandedDataGridViewPanel_StagingMakegoods.CurrentView.GetViewInfo()

            If GridViewInfo.ColumnsInfo(BandedDataGridViewPanel_StagingMakegoods.Columns("Spot0")) IsNot Nothing Then

                GridColumnRectangle = GridViewInfo.ColumnsInfo(BandedDataGridViewPanel_StagingMakegoods.Columns("Spot0")).Bounds

                HorizontalIndent = GridColumnRectangle.Left - 125

                Rectangle = New System.Drawing.Rectangle(Bounds.Left + HorizontalIndent, Bounds.Top + VerticalIndent * TotalIndex + (VerticalIndent - FontHeight) / 2, HorizontalIndent, GridColumnRectangle.Height)

            End If

            GetRectangleForRow = Rectangle

        End Function
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

                BandedDataGridViewPanel_StagingMakegoods.CurrentView.RestoreLayoutFromStream(MemoryStreamLayout, OptionsLayoutGrid)

            Else

                SetupGrid(False)

            End If

        End Sub
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

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.SaveLayoutToStream(MemoryStreamLayout, OptionsLayoutGrid)

            MemoryStreamLayout.Position = 0

            StreamReader = New System.IO.StreamReader(MemoryStreamLayout)

            _ViewModel.GridAdvantage.XmlLayout = StreamReader.ReadToEnd

        End Sub
        Private Function CreateCheckItem(Caption As String, GridColumn As DevExpress.XtraGrid.Columns.GridColumn, FixedStyle As DevExpress.XtraGrid.Columns.FixedStyle, Optional Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuCheckItem

            'objects
            Dim DXMenuCheckItem As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing

            If FixedStyle = DevExpress.XtraGrid.Columns.FixedStyle.Left Then

                DXMenuCheckItem = New DevExpress.Utils.Menu.DXMenuCheckItem(Caption, BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandFixedLeft.ToString).Columns.Contains(GridColumn), Image, New EventHandler(AddressOf OnFixedClick))

            Else

                DXMenuCheckItem = New DevExpress.Utils.Menu.DXMenuCheckItem(Caption, BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandNonDemographic.ToString).Columns.Contains(GridColumn), Image, New EventHandler(AddressOf OnFixedClick))

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

                    GridBand = BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandFixedLeft.ToString)

                    GridBand.Columns.Add(MenuInfo.GridColumn)

                Else

                    GridBand = BandedDataGridViewPanel_StagingMakegoods.CurrentView.Bands.Item(GridBandNames.GridBandNonDemographic.ToString)

                    GridBand.Columns.Insert(0, MenuInfo.GridColumn)

                End If

                MenuInfo.GridColumn.Fixed = MenuInfo.FixedStyle

                BandedDataGridViewPanel_StagingMakegoods.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ShowRates(Show As Boolean)

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.BeginUpdate()

            For Each KeyValuePair In _ViewModel.SpotDates.OrderBy(Function(SD) SD.Value)

                BandedDataGridViewPanel_StagingMakegoods.Columns(KeyValuePair.Key.Replace("Spot", "Rate")).Visible = Show

            Next

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.EndUpdate()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(WorksheetMarketDetailID As Integer,
                                              ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMakegoodDialog As MediaBroadcastWorksheetMakegoodDialog = Nothing

            MediaBroadcastWorksheetMakegoodDialog = New MediaBroadcastWorksheetMakegoodDialog(WorksheetMarketDetailID, MediaBroadcastWorksheetMarketDetailsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMakegoodDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMakegoodDialog.MediaBroadcastWorksheetMarketDetailsViewModel

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMakegoodDialog_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing

            SaveGridLayout()
            _Controller.SaveGrid(_ViewModel)

        End Sub
        Private Sub MediaBroadcastWorksheetMakegoodDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            Me.ButtonItemActions_Accept.Image = AdvantageFramework.My.Resources.ApproveImage
            Me.ButtonItemActions_Reject.Image = AdvantageFramework.My.Resources.UnapproveImage

            Me.ButtonItemView_Rates.Image = AdvantageFramework.My.Resources.CurrencyDollarImage
            Me.ButtonItemView_Responses.Image = AdvantageFramework.My.Resources.MailOpenImage

            Me.ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            Me.ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            BandedDataGridViewPanel_StagingMakegoods.GridControl.ToolTipController = _ToolTipController

            _Controller = New Controller.Media.MakegoodDeliveryController(Me.Session)

            _EmptyEditor = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            _EmptyEditor.Buttons.Clear()
            _EmptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor

            BandedDataGridViewPanel_StagingMakegoods.CurrentView.GridControl.RepositoryItems.Add(_EmptyEditor)

        End Sub
        Private Sub MediaBroadcastWorksheetMakegoodDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            BandedDataGridViewPanel_StagingMakegoods.OptionsBehavior.Editable = False

            LoadViewModel()

            If _ViewModel.MakegoodDataTable.Select("ID > 0").Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("Cannot find any submitted makegoods from vendor.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            Else

                Me.WindowState = Windows.Forms.FormWindowState.Maximized

            End If

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Accept_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Accept.Click

            Dim ErrorMessage As String = Nothing
            Dim Comment As String = String.Empty
            Dim Refresh As Boolean = False

            If AdvantageFramework.WinForm.Presentation.TextBoxInputDialog.ShowFormDialog("Makegood Accepted", "Enter Comment:", Comment, Comment, AdvantageFramework.Database.Entities.AlertComment.Properties.Comment, IsRequiredOverride:=False) = Windows.Forms.DialogResult.OK Then

                _MediaBroadcastWorksheetMarketDetailsViewModel.AcceptMakegoodComment = Comment

                If _Controller.AcceptMakegoodsFromStaging(_ViewModel, ErrorMessage, _MediaBroadcastWorksheetMarketDetailsViewModel, Refresh) Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                ElseIf Refresh Then

                    AdvantageFramework.WinForm.MessageBox.Show("Vendor has since submitted additional makegoods, window will be refreshed.")

                    LoadViewModel()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Reject_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Reject.Click

            Dim Comment As String = String.Empty

            If AdvantageFramework.WinForm.Presentation.TextBoxInputDialog.ShowFormDialog("Makegood Rejected", "Enter Comment:", Comment, Comment, AdvantageFramework.Database.Entities.AlertComment.Properties.Comment, IsRequiredOverride:=True) = Windows.Forms.DialogResult.OK Then

                _Controller.RejectMakegoodOffer(_ViewModel, _Controller.Session.ConnectionString, _Controller.Session.UserCode, _Controller.Session.EmployeeName, Comment)

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemView_Rates_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_Rates.CheckedChanged

            ShowRates(ButtonItemView_Rates.Checked)

        End Sub
        Private Sub BandedDataGridViewPanel_StagingMakegoods_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles BandedDataGridViewPanel_StagingMakegoods.CustomDrawCellEvent

            'objects
            Dim TrianglePoint() As System.Drawing.Point = Nothing

            If e.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString Then

                If BandedDataGridViewPanel_StagingMakegoods.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RateDiffersFlag.ToString).Equals(System.DBNull.Value) = False AndAlso
                        BandedDataGridViewPanel_StagingMakegoods.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RateDiffersFlag.ToString) = True Then

                    TrianglePoint = {New System.Drawing.Point(e.Bounds.Right, e.Bounds.Top), New System.Drawing.Point(e.Bounds.Right, e.Bounds.Top + 5), New System.Drawing.Point(e.Bounds.Right - 5, e.Bounds.Top)}

                    e.Cache.DrawPolygon(TrianglePoint, System.Drawing.Color.Red, 1)
                    e.Cache.FillPolygon(TrianglePoint, System.Drawing.Color.Red)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString AndAlso IsNumeric(e.CellValue) Then

                If _ViewModel.MediaType = "R" Then

                    e.DisplayText = FormatNumber(e.CellValue / 100, 0)

                ElseIf _ViewModel.MediaType = "T" Then

                    e.DisplayText = FormatNumber(e.CellValue / 1000, 1)

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString AndAlso IsNumeric(e.CellValue) Then

                If _ViewModel.MediaType = "R" Then

                    e.DisplayText = FormatNumber(e.CellValue / 100, 0)

                ElseIf _ViewModel.MediaType = "T" Then

                    e.DisplayText = FormatNumber(e.CellValue / 1000, 1)

                End If

            End If

            If BandedDataGridViewPanel_StagingMakegoods.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) & "" = "Variance" Then

                e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold)

            End If

            If BandedDataGridViewPanel_StagingMakegoods.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) & "" = "Non-Airing" Then

                If e.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString Then

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                End If

                e.Appearance.BackColor = System.Drawing.Color.WhiteSmoke

            End If

            If BandedDataGridViewPanel_StagingMakegoods.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString).ToString.StartsWith("Total") Then

                e.Appearance.BackColor = System.Drawing.Color.LightBlue

            End If

        End Sub
        Private Sub _ToolTipController_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim CellText As String = String.Empty
            Dim DataRow As System.Data.DataRow = Nothing

            If e.Info Is Nothing AndAlso e.SelectedControl Is BandedDataGridViewPanel_StagingMakegoods.GridControl Then

                GridHitInfo = BandedDataGridViewPanel_StagingMakegoods.CurrentView.CalcHitInfo(e.ControlMousePosition)

                If GridHitInfo IsNot Nothing Then

                    If GridHitInfo.InRowCell Then

                        If GridHitInfo.Column.FieldName.StartsWith("Spot") Then

                            DataRow = CType(BandedDataGridViewPanel_StagingMakegoods.CurrentView.GetRow(GridHitInfo.RowHandle), System.Data.DataRowView).Row

                            Try

                                If Not DataRow(GridHitInfo.Column.FieldName.Replace("Spot", "Rate")).Equals(System.DBNull.Value) Then

                                    CellText = FormatCurrency(DataRow(GridHitInfo.Column.FieldName.Replace("Spot", "Rate")), 2)

                                End If

                                If String.IsNullOrWhiteSpace(CellText) = False Then

                                    ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), CellText)

                                    e.Info = ToolTipControlInfo

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewPanel_StagingMakegoods_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles BandedDataGridViewPanel_StagingMakegoods.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

            If e.RowHandle >= 0 AndAlso BandedDataGridViewPanel_StagingMakegoods.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString).ToString.StartsWith("Total") AndAlso
                (e.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString OrElse
                 e.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString OrElse
                 e.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) Then

                e.RepositoryItem = _EmptyEditor

            End If

        End Sub
        Private Sub BandedDataGridViewPanel_StagingMakegoods_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedDataGridViewPanel_StagingMakegoods.PopupMenuShowingEvent

            'objects
            Dim GridViewColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = Nothing
            Dim DXMenuCheckItemFixedNone As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing
            Dim DXMenuCheckItemFixedLeft As DevExpress.Utils.Menu.DXMenuCheckItem = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                If e.HitInfo.Column IsNot Nothing AndAlso (e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetwork.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Length.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Program.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Days.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.StartTime.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.EndTime.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Comments.ToString OrElse
                        e.HitInfo.Column.FieldName = AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString) Then

                    GridViewColumnMenu = DirectCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

                    If GridViewColumnMenu.Column IsNot Nothing Then

                        DXMenuCheckItemFixedNone = CreateCheckItem("Fixed None", GridViewColumnMenu.Column, DevExpress.XtraGrid.Columns.FixedStyle.None)
                        DXMenuCheckItemFixedLeft = CreateCheckItem("Fixed Left", GridViewColumnMenu.Column, DevExpress.XtraGrid.Columns.FixedStyle.Left)

                        DXMenuCheckItemFixedNone.BeginGroup = True

                        GridViewColumnMenu.Items.Add(DXMenuCheckItemFixedNone)
                        GridViewColumnMenu.Items.Add(DXMenuCheckItemFixedLeft)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemView_Responses_Click(sender As Object, e As EventArgs) Handles ButtonItemView_Responses.Click

            AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMakegoodResponseDialog.ShowFormDialog({_MediaBroadcastWorksheetMarketDetailID})

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptions_ChooseColumns.Checked Then

                    If BandedDataGridViewPanel_StagingMakegoods.CurrentView.CustomizationForm Is Nothing Then

                        BandedDataGridViewPanel_StagingMakegoods.CurrentView.ShowCustomization()

                    End If

                Else

                    If BandedDataGridViewPanel_StagingMakegoods.CurrentView.CustomizationForm IsNot Nothing Then

                        BandedDataGridViewPanel_StagingMakegoods.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            _Controller.RestoreDefaults(_ViewModel)

            BandedDataGridViewPanel_StagingMakegoods.ClearDatasource()

            LoadGrid()

            ShowRates(ButtonItemView_Rates.Checked)

        End Sub
        Private Sub BandedDataGridViewPanel_StagingMakegoods_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewPanel_StagingMakegoods.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
