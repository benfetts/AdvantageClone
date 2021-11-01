Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketDetailsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property EditVendorEnabled As Boolean
        Public Property VendorMakegoodAvailable As Boolean

        Public Property ScheduleDetails_AddEnabled As Boolean
        Public Property ScheduleDetails_DeleteEnabled As Boolean
        Public Property ScheduleDetails_CopyEnabled As Boolean
        Public Property ScheduleDetails_AutoFillEnabled As Boolean
        Public Property CreateRevisionEnabled As Boolean
        Public Property DeleteRevisionEnabled As Boolean
        Public Property ScheduleDetails_AddReplacementEnabled As Boolean

        Public ReadOnly Property Schedule_SelectVendorsEnabled As Boolean
            Get
                Schedule_SelectVendorsEnabled = Me.HasASelectedWorksheetMarket AndAlso Me.IsMaxRevisionNumber
            End Get
        End Property
        Public ReadOnly Property Schedule_GoalsEnabled As Boolean
            Get
                Schedule_GoalsEnabled = Me.HasASelectedWorksheetMarket
            End Get
        End Property
        Public Property Markets_ManageEnabled As Boolean
        Public Property Schedule_RFPEnabled As Boolean

        Public Property MediaBroadcastWorksheetID As Integer
        Public ReadOnly Property HasPrimaryDemographic As Boolean
            Get
                HasPrimaryDemographic = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.PrimaryMediaDemographicID.GetValueOrDefault(0) > 0)
            End Get
        End Property
        Public ReadOnly Property IsUSWorksheet As Boolean
            Get
                IsUSWorksheet = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.IsUSWorksheet)
            End Get
        End Property
        Public ReadOnly Property IsCanadianWorksheet As Boolean
            Get
                IsCanadianWorksheet = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.IsCanadianWorksheet)
            End Get
        End Property
        Public ReadOnly Property DoesWorksheetAllowSubmarkets As Boolean
            Get
                DoesWorksheetAllowSubmarkets = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.DoesWorksheetAllowSubmarkets)
            End Get
        End Property
        Public ReadOnly Property AllMediaDemographicIDs As Generic.List(Of Integer)
            Get

                Dim MediaDemographicIDs As Generic.List(Of Integer) = Nothing

                MediaDemographicIDs = New Generic.List(Of Integer)

                If Me.Worksheet IsNot Nothing Then

                    If Me.HasPrimaryDemographic Then

                        MediaDemographicIDs.Add(Me.Worksheet.PrimaryMediaDemographicID.GetValueOrDefault(0))

                    End If

                    If Me.WorksheetSecondaryDemos IsNot Nothing AndAlso Me.WorksheetSecondaryDemos.Count > 0 Then

                        For Each WorksheetSecondaryDemo In Me.WorksheetSecondaryDemos

                            MediaDemographicIDs.Add(WorksheetSecondaryDemo.MediaDemographicID)

                        Next

                    End If

                End If

                AllMediaDemographicIDs = MediaDemographicIDs

            End Get
        End Property
        Public ReadOnly Property MeasurementTrendBookSelectionEnabled As Boolean
            Get
                MeasurementTrendBookSelectionEnabled = (Me.HasASelectedWorksheetMarket AndAlso Me.HasNielsenData AndAlso Me.HasPrimaryDemographic)
            End Get
        End Property
        Public ReadOnly Property BookSelectionEnabled As Boolean
            Get
                BookSelectionEnabled = (Me.HasASelectedWorksheetMarket AndAlso Me.IsMaxRevisionNumber AndAlso Me.HasPrimaryDemographic) 'AndAlso Me.SelectedWorksheetMarket.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered)
            End Get
        End Property
        'Public ReadOnly Property BookTooltip As String
        '    Get

        '        If Me.HasPrimaryDemographic Then

        '            BookTooltip = String.Empty

        '        Else

        '            BookTooltip = "Primary Demographic must be assigned to worksheet in order to pull Nielsen ratings."

        '        End If

        '    End Get
        'End Property

        Public Property CableNetworkStations As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)
        Public Property Dayparts As Generic.List(Of AdvantageFramework.DTO.Daypart)
        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
        Public Property WorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
        Public Property SelectedWorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket
        Public Property SelectedWorksheetMarketRevisionNumber As Integer
        Public Property WorksheetMarketNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
        Public Property WorksheetMarketShareBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
        Public Property WorksheetMarketHUTPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
        Public Property WorksheetMarketNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)
        Public Property GridAdvantage As AdvantageFramework.DTO.GridAdvantage
        Public Property WorksheetSecondaryDemos As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo)
        Public Property SelectedWorksheetMarketSecondaryDemo As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo
        Public Property SelectedWorksheetMarketNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenTVBook)
        Public Property SelectedWorksheetMarketNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenRadioPeriod)
        Public Property WorksheetMarketNielsenTVStations As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station)
        Public Property WorksheetMarketNielsenRadioStations As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)
        Public Property SelectedWorksheetMarketRevisionNumbers As Generic.List(Of Integer)
        Public Property SelectedWorksheetMarketVendorOrderedLines As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorOrderedLine)
        Public Property WorksheetMarketNielsenNCCTVSyscodes As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode)
        Public Property WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions
        Public Property SelectedWorksheetMarketShowVendorDemo As Boolean
        Public Property AnySelectedLinesHaveOrders As Boolean
        Public Property WorksheetMarketDetailVendorMakegoodStatuses As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendorMakegoodStatus)
        Public Property WorksheetMarketTrendNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
        Public Property WorksheetMarketSubmarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket)
        Public Property WorksheetMarketSubmarketDemos As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarketDemo)
        Public Property WorksheetMarketDetailSubmarketDemos As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailSubmarketDemo)
        Public Property WorksheetMarketDetailSubmarketDemoCache As Hashtable
        Public Property SelectedSubmarketDemoDataType As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType
        Public Property CanadaUniverses As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverse)
        Public Property CanadaUniverseCache As Hashtable

        Public Property DataTable As System.Data.DataTable
        Public Property DataView As System.Data.DataView
        Public Property HiatusDataTable As System.Data.DataTable
        Public Property RowTotalsDataTable As System.Data.DataTable
        Public Property MeasurementTrendsDataTable As System.Data.DataTable
        Public Property DaypartSummaryDataTable As System.Data.DataTable
        Public Property DaypartWeeklyDailySummaryDataTable As System.Data.DataTable
        Public Property DaypartGRPWeeklyDailySummaryDataTable As System.Data.DataTable
        Public Property StationSummaryDataTable As System.Data.DataTable
        Public Property LengthSummaryDataTable As System.Data.DataTable
        Public Property DaypartLengthSummaryDataTable As System.Data.DataTable
        Public Property MarketMonthlySummaryDataTable As System.Data.DataTable
        Public Property StationMonthlySummaryDataTable As System.Data.DataTable
        Public Property DetailSubmarketDemoDataTable As System.Data.DataTable

        Public Property DetailDates As Hashtable
        Public Property RateDates As Hashtable
        Public Property AllowSpotsToBeEnteredDates As Hashtable
        Public Property OrderStatusDates As Hashtable

        Public Property MakegoodDataTable As System.Data.DataTable

        Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
            Get
                HasASelectedWorksheetMarket = (Me.SelectedWorksheetMarket IsNot Nothing AndAlso Me.WorksheetMarkets.Count > 0)
            End Get
        End Property
        Public ReadOnly Property HasASelectedWorksheetSecondaryDemo As Boolean
            Get
                HasASelectedWorksheetSecondaryDemo = (Me.SelectedWorksheetMarketSecondaryDemo IsNot Nothing)
            End Get
        End Property
        Public ReadOnly Property HasNielsenData As Boolean
            Get

                If Me.HasASelectedWorksheetMarket Then

                    If Me.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                        HasNielsenData = (Me.WorksheetMarketNielsenTVBooks IsNot Nothing AndAlso Me.WorksheetMarketNielsenTVBooks.Count > 0)

                    ElseIf Me.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                        HasNielsenData = (Me.WorksheetMarketNielsenRadioPeriods IsNot Nothing AndAlso Me.WorksheetMarketNielsenRadioPeriods.Count > 0)

                    Else

                        HasNielsenData = False

                    End If

                Else

                    HasNielsenData = False

                End If

            End Get
        End Property
        Public ReadOnly Property IsMaxRevisionNumber As Boolean
            Get
                IsMaxRevisionNumber = (Me.SelectedWorksheetMarketRevisionNumbers IsNot Nothing AndAlso
                                        Me.SelectedWorksheetMarketRevisionNumbers.Count > 0 AndAlso
                                        Me.SelectedWorksheetMarketRevisionNumber = Me.SelectedWorksheetMarketRevisionNumbers.Max)
            End Get
        End Property

        Public Property Demos_ShowPrimaryDemos As Boolean
        Public Property Demos_ShowSecondaryDemos As Boolean
        Public Property GridOptions_ChooseColumns As Boolean
        Public Property HideZeroSpotLines As Boolean

        Public Property FilterString As String

        Public Property ExportEnabled As Boolean
        Public Property CreateOrdersEnabled As Boolean
        Public Property CreateOrders_SelectedLinesOnlyEnabled As Boolean
        Public ReadOnly Property GenerateOrdersEnabled As Boolean
            Get
                GenerateOrdersEnabled = Me.HasASelectedWorksheetMarket AndAlso Me.AnySelectedLinesHaveOrders AndAlso Me.IsMaxRevisionNumber
            End Get
        End Property

        Public Property IsNielsenSetup As Boolean

        Public ReadOnly Property CopyDateCaption As String
            Get

                If Me.Worksheet IsNot Nothing Then

                    If Me.Worksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly Then

                        CopyDateCaption = "Copy Week"

                    Else

                        CopyDateCaption = "Copy Date"

                    End If

                Else

                    CopyDateCaption = String.Empty

                End If

            End Get
        End Property

        Public ReadOnly Property DateRateCaption As String
            Get

                If Me.Worksheet IsNot Nothing Then

                    If Me.Worksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly Then

                        DateRateCaption = "Weekly Rates"

                    Else

                        DateRateCaption = "Daily Rates"

                    End If

                Else

                    DateRateCaption = String.Empty

                End If

            End Get
        End Property

        Public Property SelectedScheduleSummary As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries

        Public Property IsInAcceptMakegoodMode As Boolean
        Public ReadOnly Property MakegoodOrderNumber As Integer
        Public ReadOnly Property MakegoodMediaType As String

        Public Property UserHasAccessToMediaTraffic As Boolean

        Public Property DateSelections As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property StartDateSelection As String
        Public Property EndDateSelection As String
        Public Property HideHiatusDates As Boolean

        Public Property AcceptMakegoodComment As String
        Public Property MakegoodViewDetailsEnabled As Boolean
        Public Property WorksheetLineNumbersAccepted As Generic.List(Of Integer)

        Public Property GenerateApproveMediaBroadcastWorsheetMarketDetailIDs As Generic.List(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()

            Me.SaveEnabled = False

            Me.ScheduleDetails_AddEnabled = False
            Me.ScheduleDetails_DeleteEnabled = False
            Me.ScheduleDetails_CopyEnabled = False
            Me.ScheduleDetails_AutoFillEnabled = False
            Me.CreateRevisionEnabled = False
            Me.DeleteRevisionEnabled = False
            Me.ScheduleDetails_AddReplacementEnabled = False

            Me.Markets_ManageEnabled = True
            Me.Schedule_RFPEnabled = True

            Me.MediaBroadcastWorksheetID = 0

            Me.CableNetworkStations = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)
            Me.Dayparts = New Generic.List(Of AdvantageFramework.DTO.Daypart)
            Me.Worksheet = Nothing
            Me.WorksheetMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
            Me.SelectedWorksheetMarket = Nothing
            Me.SelectedWorksheetMarketRevisionNumber = 0
            Me.WorksheetMarketNielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
            Me.WorksheetMarketShareBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
            Me.WorksheetMarketHUTPUTBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
            Me.WorksheetMarketNielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)
            Me.WorksheetSecondaryDemos = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo)
            Me.SelectedWorksheetMarketSecondaryDemo = Nothing
            Me.SelectedWorksheetMarketNielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenTVBook)
            Me.SelectedWorksheetMarketNielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenRadioPeriod)
            Me.WorksheetMarketNielsenTVStations = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station)
            Me.WorksheetMarketNielsenRadioStations = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)
            Me.SelectedWorksheetMarketRevisionNumbers = New Generic.List(Of Integer)
            Me.SelectedWorksheetMarketVendorOrderedLines = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorOrderedLine)
            Me.WorksheetMarketNielsenNCCTVSyscodes = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode)
            Me.WorksheetPrintOptions = Nothing
            Me.SelectedWorksheetMarketShowVendorDemo = False
            Me.AnySelectedLinesHaveOrders = False
            Me.WorksheetMarketDetailVendorMakegoodStatuses = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendorMakegoodStatus)
            Me.WorksheetMarketSubmarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket)
            Me.WorksheetMarketSubmarketDemos = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarketDemo)
            Me.WorksheetMarketDetailSubmarketDemos = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailSubmarketDemo)
            Me.WorksheetMarketDetailSubmarketDemoCache = New Hashtable
            Me.SelectedSubmarketDemoDataType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SubmarketDemoDataType.Rating
            Me.CanadaUniverses = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverse)
            Me.CanadaUniverseCache = New Hashtable

            Me.DataTable = New System.Data.DataTable
            Me.DataView = New System.Data.DataView(Me.DataTable)
            Me.HiatusDataTable = New System.Data.DataTable
            Me.RowTotalsDataTable = New System.Data.DataTable
            Me.MeasurementTrendsDataTable = New System.Data.DataTable
            Me.DaypartSummaryDataTable = New System.Data.DataTable
            Me.DaypartWeeklyDailySummaryDataTable = New System.Data.DataTable
            Me.DaypartGRPWeeklyDailySummaryDataTable = New System.Data.DataTable
            Me.StationSummaryDataTable = New System.Data.DataTable
            Me.LengthSummaryDataTable = New System.Data.DataTable
            Me.DaypartLengthSummaryDataTable = New System.Data.DataTable
            Me.MarketMonthlySummaryDataTable = New System.Data.DataTable
            Me.StationMonthlySummaryDataTable = New System.Data.DataTable
            Me.DetailSubmarketDemoDataTable = New System.Data.DataTable

            Me.DetailDates = New Hashtable
            Me.RateDates = New Hashtable
            Me.AllowSpotsToBeEnteredDates = New Hashtable
            Me.OrderStatusDates = New Hashtable

            Me.GridAdvantage = Nothing

            Me.Demos_ShowPrimaryDemos = True
            Me.Demos_ShowSecondaryDemos = False

            Me.GridOptions_ChooseColumns = False
            Me.HideZeroSpotLines = False

            Me.FilterString = String.Empty

            Me.ExportEnabled = False
            Me.CreateOrdersEnabled = True
            Me.CreateOrders_SelectedLinesOnlyEnabled = False

            Me.IsNielsenSetup = False

            Me.SelectedScheduleSummary = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.ScheduleSummaries.Default
            Me.IsInAcceptMakegoodMode = False
            Me.VendorMakegoodAvailable = False

            Me.WorksheetMarketTrendNielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            Me.UserHasAccessToMediaTraffic = False

            Me.DateSelections = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.StartDateSelection = String.Empty
            Me.EndDateSelection = String.Empty
            Me.HideHiatusDates = False

            Me.AcceptMakegoodComment = String.Empty
            Me.MakegoodViewDetailsEnabled = False
            Me.WorksheetLineNumbersAccepted = Nothing

            Me.GenerateApproveMediaBroadcastWorsheetMarketDetailIDs = Nothing

        End Sub
        Public Sub SetAcceptMakegoodMode(OrderNumber As Integer, MediaType As String)

            Me.IsInAcceptMakegoodMode = True

            _MakegoodOrderNumber = OrderNumber
            _MakegoodMediaType = MediaType

        End Sub

#End Region

    End Class

End Namespace
