Namespace Media

    Public Class MediaBroadcastWorksheetBroadcastScheduleStationSummaryReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _CurrentDataLine As Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary = Nothing
        Public Property _BroadcastSummaryList As List(Of Database.Classes.MediaBroadcastWorksheetBroadcastSummaryReport) = Nothing
        Private _PrintGroup2 As Boolean = False
        Private _ShowNet As Boolean = True
        Private _Date As String = String.Empty
        Private _LocationName As String = String.Empty
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

#End Region

#Region " Properties "

        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaBroadcastWorksheetBroadcastScheduleStationSummary
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public Property ParameterDictionary As Dictionary(Of String, Object)
        Public Property Session As AdvantageFramework.Security.Session
        Public Property DbContext As Database.DbContext

        Public Property MediaBroadcastWorksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
        Public Property MediaBroadcastWorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "
        Private Sub MediaBroadcastWorksheetBroadcastScheduleStationSummaryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            XrSubreport1.ReportSource = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetScheduleBroadcastSummarySubreport()

            Dim MediaBroadcastWorksheetBroadcastScheduleStationSummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary) = Nothing
            Dim ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail) = Nothing

            Dim MarketWorksheetMarketIdList As Generic.List(Of Integer) = Nothing
            Dim UsePrimaryDemoList As Generic.List(Of Boolean) = Nothing

            'Nullable Integers
            Dim BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) = Nothing
            Dim BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) = Nothing

            Dim MediaBroadcastWorksheetMarketBooks As Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) = Nothing
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim ComScoreTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim NielsenTVBook1 As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook = Nothing
            Dim NielsenTVBook2 As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook = Nothing
            Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing
            Dim NielsenRadioPeriod1 As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing
            Dim NielsenRadioPeriod2 As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing

            Try
                If ParameterDictionary.ContainsKey("LocationName") Then
                    _LocationName = ParameterDictionary("LocationName")
                End If
            Catch ex As Exception

            End Try

            Dim VendorCodeList As String = ""

            Try
                If ParameterDictionary.ContainsKey("VendorFilter") Then
                    VendorCodeList = ParameterDictionary("VendorFilter")
                End If
            Catch ex As Exception

            End Try


            Dim ShowRatings As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowRatings") Then
                    ShowRatings = ParameterDictionary("ShowRatings")
                End If
            Catch ex As Exception

            End Try

            Dim ShowComments As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowComments") Then
                    ShowComments = ParameterDictionary("ShowComments")
                End If
            Catch ex As Exception

            End Try

            Dim ShowSpotCosts As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowSpotCosts") Then
                    ShowSpotCosts = ParameterDictionary("ShowSpotCosts")
                End If
            Catch ex As Exception

            End Try

            Dim ShowImpressions As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowImpressions") Then
                    ShowImpressions = ParameterDictionary("ShowImpressions")
                End If
            Catch ex As Exception

            End Try

            Dim ShowBookends As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowBookends") Then
                    ShowBookends = ParameterDictionary("ShowBookends")
                End If
            Catch ex As Exception

            End Try

            Dim ShowTotalCosts As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowTotalCosts") Then
                    ShowTotalCosts = ParameterDictionary("ShowTotalCosts")
                End If
            Catch ex As Exception

            End Try

            Dim ShowCPPM As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowCPPM") Then
                    ShowCPPM = ParameterDictionary("ShowCPPM")
                End If
            Catch ex As Exception

            End Try

            Dim ShowAddedValue As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowAddedValue") Then
                    ShowAddedValue = ParameterDictionary("ShowAddedValue")
                End If
            Catch ex As Exception

            End Try


            Dim ShowRF As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowRF") Then
                    ShowRF = ParameterDictionary("ShowRF")
                End If
            Catch ex As Exception

            End Try



            Try
                If ParameterDictionary.ContainsKey("ShowNetCost") Then
                    _ShowNet = ParameterDictionary("ShowNetCost")
                End If
            Catch ex As Exception

            End Try

            Dim WorksheetIsGross As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("WorksheetIsGross") Then
                    WorksheetIsGross = ParameterDictionary("WorksheetIsGross")
                End If
            Catch ex As Exception

            End Try

            MarketWorksheetMarketIdList = New Generic.List(Of Integer)
            UsePrimaryDemoList = New Generic.List(Of Boolean)
            BroadcastStartYearMonthList = New Generic.List(Of Nullable(Of Integer))
            BroadcastEndYearMonthList = New Generic.List(Of Nullable(Of Integer))

            Try

                If ParameterDictionary.ContainsKey("MediaBroadcastWorksheetMarketBooks") Then
                    MediaBroadcastWorksheetMarketBooks = ParameterDictionary("MediaBroadcastWorksheetMarketBooks")
                    MarketWorksheetMarketIdList = New List(Of Integer)
                    For Each WorksheetMarket In MediaBroadcastWorksheetMarketBooks
                        MarketWorksheetMarketIdList.Add(WorksheetMarket.MediaBroadcastWorksheetMarketID)
                        UsePrimaryDemoList.Add(WorksheetMarket.UsePrimaryDemo)

                        'Handle Nullable Integers
                        BroadcastStartYearMonthList.Add(WorksheetMarket.BroadcastStartYearMonth)
                        BroadcastEndYearMonthList.Add(WorksheetMarket.BroadcastEndYearMonth)

                    Next
                End If

                Using DbContext = New Database.DbContext(Session.ConnectionString, Session.UserCode)
                    MediaBroadcastWorksheetBroadcastScheduleStationSummary =
                    Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                        LoadStationSystemSummary(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, "Broadcast Schedule Station Report", VendorCodeList, _LocationName, _ShowNet, WorksheetIsGross).ToList()

                    ReachFreqDetailLines =
                        Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                        LoadReachFreqDetails(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, VendorCodeList).ToList()

                    _BroadcastSummaryList =
                    Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                        LoadBroadcastSummaryReport(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, VendorCodeList).ToList()
                End Using

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If String.IsNullOrWhiteSpace(_LocationName) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationName, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderLandscape)

                    Else

                        _LocationLogo = Nothing

                    End If

                End Using

                CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleStationSummary, ReachFreqDetailLines, True)
                CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleStationSummary, ReachFreqDetailLines, False)

                CalculateTotalReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleStationSummary, ReachFreqDetailLines, True)
                CalculateTotalReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleStationSummary, ReachFreqDetailLines, False)

                If Session.IsNielsenSetup Then

                    Using DbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        NielsenTVBooks = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList
                        NielsenRadioPeriods = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).ToList

                    End Using

                End If

                If Session.IsComscoreSetup Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        ComScoreTVBooks = AdvantageFramework.Database.Procedures.ComscoreTVBook.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                    End Using

                End If

                For Each DataLine In MediaBroadcastWorksheetBroadcastScheduleStationSummary

                    DataLine.Survey = String.Empty
                    DataLine.SurveyLine2 = String.Empty

                    If DataLine.RatingsServiceID.GetValueOrDefault(0) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                        DataLine.RatingsSource = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen.ToString

                        If DataLine.MediaTypeCode = "T" Then

                            If DataLine.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso NielsenTVBooks IsNot Nothing AndAlso NielsenTVBooks.Count > 0 Then

                                NielsenTVBook1 = NielsenTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.SharebookNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook1 IsNot Nothing Then

                                    DataLine.Survey = NielsenTVBook1.Description.Replace("Same Day", "SD")

                                Else

                                    DataLine.Survey = String.Empty

                                End If

                            Else

                                DataLine.Survey = String.Empty

                            End If

                            If DataLine.HutputNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso NielsenTVBooks IsNot Nothing AndAlso NielsenTVBooks.Count > 0 Then

                                NielsenTVBook2 = NielsenTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.HutputNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook2 IsNot Nothing Then

                                    DataLine.SurveyLine2 = NielsenTVBook2.Description.Replace("Same Day", "SD")

                                Else

                                    DataLine.SurveyLine2 = String.Empty

                                End If

                            Else

                                DataLine.SurveyLine2 = String.Empty

                            End If

                        ElseIf DataLine.MediaTypeCode = "R" Then

                            If (NielsenRadioPeriods IsNot Nothing) Then
                                DataLine.Survey = AdvantageFramework.Reporting.Reports.
                                    RadioPeriods(NielsenRadioPeriods, DataLine.RadioBookID1.GetValueOrDefault(0), DataLine.RadioBookID2.GetValueOrDefault(0), DataLine.RadioBookID3.GetValueOrDefault(0), DataLine.RadioBookID4.GetValueOrDefault(0), DataLine.RadioBookID5.GetValueOrDefault(0))
                            Else
                                DataLine.Survey = String.Empty
                            End If

                            DataLine.SurveyLine2 = String.Empty

                        End If

                    ElseIf DataLine.RatingsServiceID.GetValueOrDefault(0) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        DataLine.RatingsSource = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore.ToString

                        If DataLine.MediaTypeCode = "T" Then

                            If DataLine.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso ComScoreTVBooks IsNot Nothing AndAlso ComScoreTVBooks.Count > 0 Then

                                NielsenTVBook1 = ComScoreTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.SharebookNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook1 IsNot Nothing Then

                                    DataLine.Survey = NielsenTVBook1.Description.Replace("Same Day", "SD")

                                End If

                            End If

                            If DataLine.HutputNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso ComScoreTVBooks IsNot Nothing AndAlso ComScoreTVBooks.Count > 0 Then

                                NielsenTVBook2 = ComScoreTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.HutputNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook2 IsNot Nothing Then

                                    DataLine.SurveyLine2 = NielsenTVBook2.Description.Replace("Same Day", "SD")

                                End If

                            End If

                        End If

                    ElseIf DataLine.RatingsServiceID.GetValueOrDefault(0) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.NielsenPuertoRico Then

                        DataLine.RatingsSource = "Nielsen Puerto Rico"

                    Else

                        DataLine.Survey = String.Empty
                        DataLine.SurveyLine2 = String.Empty

                    End If

                    If (DataLine.MediaTypeCode = "R") Then
                        DataLine.RatingsSource = DataLine.RadioSource
                    End If

                    DataLine.ShowRatings = ShowRatings
                    DataLine.ShowComments = ShowComments
                    DataLine.ShowSpotCosts = ShowSpotCosts
                    DataLine.ShowImpressions = ShowImpressions
                    DataLine.ShowBookends = ShowBookends
                    DataLine.ShowTotalCosts = ShowTotalCosts
                    DataLine.ShowCPPM = ShowCPPM
                    DataLine.ShowAddedValue = ShowAddedValue
                    DataLine.ShowRF = ShowRF

                Next

                Me.DataSource = MediaBroadcastWorksheetBroadcastScheduleStationSummary

                _PrintGroup2 = False

                If (MediaBroadcastWorksheetBroadcastScheduleStationSummary IsNot Nothing) Then
                    If (MediaBroadcastWorksheetBroadcastScheduleStationSummary.Count > 0) Then
                        _CurrentDataLine = MediaBroadcastWorksheetBroadcastScheduleStationSummary.FirstOrDefault
                        _PrintGroup2 = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Group2Name)

                        If (_CurrentDataLine.MediaTypeCode = "R") Then
                            XrLabel1.TextFormatString = "{0:#,#}"
                            XrLabel2.TextFormatString = "{0:#,#}"
                        Else
                            XrLabel1.TextFormatString = "{0:#,#.0}"
                            XrLabel2.TextFormatString = "{0:#,#.0}"
                        End If

                        SubreportTotals()
                        XrSubreport1.ReportSource.DataSource = _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID).ToList
                    Else
                        _CurrentDataLine = New Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary
                        _PrintGroup2 = False
                    End If
                Else
                    _CurrentDataLine = New Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary
                End If

            Catch ex As Exception


            End Try
        End Sub

        Private Sub SubreportTotals()
            If (_BroadcastSummaryList IsNot Nothing) Then
                For Each ListItem In _BroadcastSummaryList

                    ListItem.TotalSpots =
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week1Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week2Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week3Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week4Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week5Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week6Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week7Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week8Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week9Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week10Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week11Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week12Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week13Spots).Sum _
                        +
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week14Spots).Sum

                    ListItem.TotalEstGRP =
                         _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week1EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week2EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week3EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week4EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week5EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week6EstGRP).Sum _
                         +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week7EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week8EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week9EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week10EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week11EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week12EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week13EstGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week14EstGRP).Sum

                    ListItem.TotalGoalGRP =
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week1GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week2GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week3GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week4GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week5GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week6GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week7GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week8GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week9GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week10GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week11GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week12GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week13GoalGRP).Sum _
                        +
                        _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID) _
                        .Select(Function(x) x.Week14GoalGRP).Sum


                    ListItem.TotalBudgetIndex = 0.00

                    If (ListItem.TotalGoalGRP > 0) Then
                        ListItem.TotalBudgetIndex = (ListItem.TotalEstGRP) / ListItem.TotalGoalGRP
                    End If

                Next
            End If
        End Sub
        Private Sub MediaBroadcastWorksheetBroadcastScheduleStationSummaryReport_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles MyBase.DataSourceRowChanged
            _CurrentDataLine = TryCast(Me.GetCurrentRow(), Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary)
            _PrintGroup2 = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Group2Name)
            SubreportTotals()

            XrSubreport1.ReportSource.DataSource = _BroadcastSummaryList.Where(Function(x) x.MediaBroadcastWorksheetMarketID = _CurrentDataLine.MediaBroadcastWorksheetMarketID).ToList
        End Sub

        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If (_CurrentDataLine IsNot Nothing) Then

                If String.IsNullOrWhiteSpace(_LocationName) = False Then

                    If String.IsNullOrWhiteSpace(_CurrentDataLine.PageHeaderLogoPathLand) = False Then

                        If My.Computer.FileSystem.FileExists(_CurrentDataLine.PageHeaderLogoPathLand) Then

                            XrPictureBoxHeaderLogo.ImageUrl = _CurrentDataLine.PageHeaderLogoPathLand

                            Cancel = False

                        End If

                    ElseIf _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                        Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                            XrPictureBoxHeaderLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                            Cancel = False

                        End Using

                    End If

                End If

            End If

            e.Cancel = Cancel

        End Sub

        Private Sub XrLabelLocationHeaderInfo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelLocationHeaderInfo.BeforePrint
            If (_CurrentDataLine IsNot Nothing) Then
                If Not String.IsNullOrEmpty(_CurrentDataLine.PageHeaderComment) Then
                    XrLabelLocationHeaderInfo.Text = _CurrentDataLine.PageHeaderComment
                End If
            End If

        End Sub

        Private Sub GroupHeader1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader1.BeforePrint

            XrTableCell43.Visible = _PrintGroup2
            XrTableCell56.Visible = _PrintGroup2
            XrTableCell57.Visible = _PrintGroup2
            XrTableCell58.Visible = _PrintGroup2
            XrTableCell86.Visible = _PrintGroup2
            XrTableCell87.Visible = _PrintGroup2
            XrTableCell96.Visible = _PrintGroup2
            XrTableCell97.Visible = _PrintGroup2
            XrTableCell99.Visible = _PrintGroup2
            XrTableCell103.Visible = _PrintGroup2
            XrTableCell105.Visible = _PrintGroup2
            XrTableCell106.Visible = _PrintGroup2
            XrTableCell107.Visible = _PrintGroup2
            XrTableCell108.Visible = _PrintGroup2

            If (_CurrentDataLine IsNot Nothing) Then
                If (_CurrentDataLine.MediaTypeCode = "R") Then
                    XrTableCell71.TextFormatString = "{0:#,#}"
                    XrTableCell76.TextFormatString = "{0:#,#}"
                Else
                    XrTableCell71.TextFormatString = "{0:#,#.0}"
                    XrTableCell76.TextFormatString = "{0:#,#.0}"
                End If

                If (_CurrentDataLine.IsGross) Then
                    XrTableCell50.Text = "Gross Cost"
                    If (_ShowNet) Then
                        XrTableCell50.Text = "Net Cost"
                    End If
                Else
                    XrTableCell50.Text = "Net Cost"
                    If (_ShowNet) Then
                        XrTableCell50.Text = "Gross Cost"
                    End If
                End If

                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    XrTableCell50.Visible = False
                    XrTableCell51.Visible = False
                End If

                If Not (_CurrentDataLine.ShowCPPM) Then
                    XrTableCell52.Visible = False
                    XrTableCell93.Visible = False

                    XrTableCell107.Visible = False
                    XrTableCell97.Visible = False

                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell52.Visible = True
                        XrTableCell107.Visible = _PrintGroup2

                    Else

                        XrTableCell52.Visible = False
                        XrTableCell107.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrTableCell93.Visible = True
                        XrTableCell97.Visible = _PrintGroup2

                    Else

                        XrTableCell93.Visible = False
                        XrTableCell97.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowRatings) Then
                    XrTableCell53.Visible = False
                    XrTableCell54.Visible = False

                    XrTableCell56.Visible = False
                    XrTableCell57.Visible = False
                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrTableCell55.Visible = False
                    XrTableCell58.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRF) Then
                    XrTableCell92.Visible = False
                    XrTableCell65.Visible = False

                    XrTableCell96.Visible = False
                    XrTableCell86.Visible = False
                End If

                If _CurrentDataLine.ShowRatings = False AndAlso _CurrentDataLine.ShowImpressions = False AndAlso
                        _CurrentDataLine.ShowRF = False AndAlso _CurrentDataLine.ShowCPPM = False Then

                    XrTableCell5.Visible = False
                    XrTableCell94.Visible = False
                    XrTableCell95.Visible = False

                    XrTableCell43.Visible = False
                    XrTableCell99.Visible = False
                    XrTableCell103.Visible = False
                End If

            End If

        End Sub

        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
            XrTableCell72.Visible = _PrintGroup2
            XrTableCell73.Visible = _PrintGroup2
            XrTableCell76.Visible = _PrintGroup2
            XrTableCell82.Visible = _PrintGroup2
            XrTableCell83.Visible = _PrintGroup2
            XrTableCell84.Visible = _PrintGroup2
            XrTableCell111.Visible = _PrintGroup2
            XrTableCell112.Visible = _PrintGroup2

            If (_CurrentDataLine IsNot Nothing) Then

                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    XrTableCell67.Visible = False
                    XrTableCell68.Visible = False
                End If

                If Not (_CurrentDataLine.ShowCPPM) Then
                    XrTableCell69.Visible = False
                    XrTableCell81.Visible = False

                    XrTableCell72.Visible = False
                    XrTableCell84.Visible = False

                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell69.Visible = True
                        XrTableCell72.Visible = _PrintGroup2

                    Else

                        XrTableCell69.Visible = False
                        XrTableCell72.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrTableCell81.Visible = True
                        XrTableCell84.Visible = _PrintGroup2

                    Else

                        XrTableCell81.Visible = False
                        XrTableCell84.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowRatings) Then
                    XrTableCell70.Visible = False
                    XrTableCell109.Visible = False

                    XrTableCell73.Visible = False
                    XrTableCell111.Visible = False
                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrTableCell71.Visible = False
                    XrTableCell76.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRF) Then
                    XrTableCell80.Visible = False
                    XrTableCell110.Visible = False

                    XrTableCell83.Visible = False
                    XrTableCell112.Visible = False
                End If

            End If

        End Sub

        Private Sub GroupFooter1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter1.BeforePrint
            XrLabel1.Visible = _PrintGroup2
            XrLabel5.Visible = _PrintGroup2
            XrLabel6.Visible = _PrintGroup2
            XrLabel10.Visible = _PrintGroup2
            XrLabel3.Visible = _PrintGroup2
            XrLabel39.Visible = _PrintGroup2

            If (_CurrentDataLine IsNot Nothing) Then

                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    xrLabel37.Visible = False
                    XrLabel14.Visible = False
                    XrLabel15.Visible = False
                End If

                If Not (_CurrentDataLine.ShowCPPM) Then
                    XrLabel38.Visible = False
                    XrLabel9.Visible = False

                    XrLabel39.Visible = False
                    XrLabel10.Visible = False

                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrLabel38.Visible = True
                        XrLabel39.Visible = _PrintGroup2

                    Else

                        XrLabel38.Visible = False
                        XrLabel39.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrLabel9.Visible = True
                        XrLabel10.Visible = _PrintGroup2

                    Else

                        XrLabel9.Visible = False
                        XrLabel10.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowRatings) Then
                    XrLabel4.Visible = False
                    XrLabel3.Visible = False
                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrLabel2.Visible = False
                    XrLabel1.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRF) Then
                    XrLabel7.Visible = False
                    XrLabel8.Visible = False

                    XrLabel6.Visible = False
                    XrLabel5.Visible = False
                End If

            End If
        End Sub

        Private Sub PageHeader_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint
            If (_CurrentDataLine IsNot Nothing) Then
                XrTableCell33.Visible = Not String.IsNullOrEmpty(_CurrentDataLine.Buyer)
                XrTableCell21.Visible = Not String.IsNullOrEmpty(_CurrentDataLine.Survey)
                XrTableCell27.Visible = Not String.IsNullOrEmpty(_CurrentDataLine.SurveyLine2)

                XrTableRow6.CanShrink = True
                XrTableRow6.Visible = Not (_CurrentDataLine.DivisionName = _CurrentDataLine.ClientName)

                If Not (_CurrentDataLine.ShowRatings And _CurrentDataLine.ShowImpressions And _CurrentDataLine.ShowCPPM And _CurrentDataLine.ShowRF) Then
                    XrTableCell51.Visible = False
                    XrTableCell68.Visible = False

                    XrTableCell21.Visible = False
                    XrTableCell22.Visible = False

                    XrTableCell27.Visible = False
                    XrTableCell28.Visible = False
                End If
            End If
        End Sub

        Private Sub CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleStationSummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary),
                                          ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail),
                                          UsePrimaryDemo As Boolean)

            'objects
            Dim ReachTotal As Double = 0
            Dim MediaBroadcastWorksheetBroadcastScheduleStationSummaries As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary) = Nothing
            Dim DemoInfos As Generic.List(Of Database.Classes.ReachFreqDetail) = Nothing
            Dim CumeImpressionsValues As Generic.List(Of Long) = Nothing
            Dim CumesValues As Generic.List(Of Long) = Nothing
            Dim AllReachValuesList As Generic.List(Of Double) = Nothing
            Dim AllReachValues() As Double = Nothing
            Dim TotalSpots As Integer = 0
            Dim Impressions As Long = 0
            Dim RowSpots As Integer = 0
            Dim TotalImpressions As Long = 0
            Dim TotalSpotImpressions As Long = 0
            Dim TotalRating As Decimal = 0
            Dim Universe As Long = 0
            Dim TotalAQH As Long = 0
            Dim AQH As Long = 0
            Dim BookRating As Decimal = 0

            For Each VendorCode In MediaBroadcastWorksheetBroadcastScheduleStationSummary.Select(Function(Entity) Entity.VendorCode).Distinct.ToList

                ReachTotal = 0
                CumeImpressionsValues = Nothing
                CumesValues = Nothing
                AllReachValuesList = Nothing
                AllReachValues = Nothing
                TotalSpots = 0
                Impressions = 0
                RowSpots = 0
                TotalImpressions = 0
                TotalSpotImpressions = 0
                TotalRating = 0
                Universe = 0
                TotalAQH = 0
                AQH = 0
                BookRating = 0

                DemoInfos = ReachFreqDetailLines.Where(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.OnHold = False).ToList

                MediaBroadcastWorksheetBroadcastScheduleStationSummaries = MediaBroadcastWorksheetBroadcastScheduleStationSummary.Where(Function(Entity) Entity.VendorCode = VendorCode).ToList

                If DemoInfos.Any(Function(Entity) Entity.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0) AndAlso
                        DemoInfos.Any(Function(Entity) Entity.VendorNielsenTVStationCode.GetValueOrDefault(0) <> 0 OrElse
                                                       Entity.CableNetworkNielsenTVStationCode.GetValueOrDefault(0) <> 0) Then

                    CumeImpressionsValues = DemoInfos.Select(Function(Entity) If(UsePrimaryDemo, Entity.PrimaryCumeImpressions.GetValueOrDefault(0), Entity.SecondaryCumeImpressions.GetValueOrDefault(0))).Distinct.ToList

                Else

                    CumeImpressionsValues = New Generic.List(Of Long)

                End If

                AllReachValuesList = New Generic.List(Of Double)

                If CumeImpressionsValues.Count > 0 Then

                    For Each CumeInpression In CumeImpressionsValues

                        TotalSpots = 0
                        TotalImpressions = 0
                        TotalRating = 0
                        TotalSpotImpressions = 0
                        Universe = 0

                        For Each DemoInfo In DemoInfos.Where(Function(Entity) CumeInpression = If(UsePrimaryDemo, Entity.PrimaryCumeImpressions, Entity.SecondaryCumeImpressions))

                            RowSpots = 0
                            Impressions = If(UsePrimaryDemo, DemoInfo.PrimaryBuyImpressions.GetValueOrDefault(0), DemoInfo.SecondaryBuyImpressions.GetValueOrDefault(0))

                            TotalImpressions = Impressions
                            TotalRating += CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0)))

                            If Universe = 0 Then

                                Universe = CLng(If(UsePrimaryDemo, DemoInfo.PrimaryUniverse.GetValueOrDefault(0), DemoInfo.SecondaryUniverse.GetValueOrDefault(0)))

                            End If

                            RowSpots += DemoInfo.Spots

                            TotalSpots = RowSpots

                            TotalSpotImpressions += (Impressions * RowSpots)

                            BookRating = CDec(If(UsePrimaryDemo, DemoInfo.PrimaryBookRating.GetValueOrDefault(0), DemoInfo.SecondaryBookRating.GetValueOrDefault(0)))

                            If CumeInpression < Impressions Then

                                AllReachValuesList.Add(CalculateCumlessReach(CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), TotalSpots))

                            Else

                                AllReachValuesList.Add(CalculateTVReach(Impressions, CumeInpression, RowSpots, Universe, CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), BookRating))

                            End If

                        Next

                    Next

                ElseIf MediaBroadcastWorksheetBroadcastScheduleStationSummaries IsNot Nothing AndAlso MediaBroadcastWorksheetBroadcastScheduleStationSummaries.Count > 0 Then

                    For Each DemoInfo In DemoInfos

                        AllReachValuesList.Add(If(UsePrimaryDemo, DemoInfo.PrimaryReach.GetValueOrDefault(0), DemoInfo.SecondaryReach.GetValueOrDefault(0)))

                    Next

                End If

                AllReachValues = AllReachValuesList.ToArray

                If AllReachValues.Length > 2 Then

                    ReachTotal = (AllReachValues(0) + AllReachValues(1)) - (AllReachValues(0) * AllReachValues(1))

                    ReachTotal = Math.Round(ReachTotal, 3)

                    For ReachValueIndex As Integer = 2 To AllReachValues.Length - 1

                        ReachTotal = (ReachTotal + AllReachValues(ReachValueIndex)) - (ReachTotal * AllReachValues(ReachValueIndex))

                        ReachTotal = Math.Round(ReachTotal, 3)

                    Next

                ElseIf AllReachValues.Length = 2 Then

                    ReachTotal = (AllReachValues(0) + AllReachValues(1)) - (AllReachValues(0) * AllReachValues(1))

                    ReachTotal = Math.Round(ReachTotal, 3)

                ElseIf AllReachValues.Length = 1 Then

                    ReachTotal = AllReachValues(0)

                End If

                If Double.IsNaN(ReachTotal) Then

                    ReachTotal = 0

                End If

                For Each MDODOD In MediaBroadcastWorksheetBroadcastScheduleStationSummary.Where(Function(Entity) Entity.VendorCode = VendorCode).ToList

                    If (UsePrimaryDemo) Then
                        MDODOD.Group1ReachPCT = ReachTotal

                        MDODOD.Group1Frequency = CalcFreq(MDODOD.Group1ReachPCT, If(UsePrimaryDemo, MDODOD.Group1PrimaryGRP, MDODOD.Group2PrimaryGRP))
                    Else
                        MDODOD.Group2ReachPCT = ReachTotal

                        MDODOD.Group2Frequency = CalcFreq(MDODOD.Group2ReachPCT, If(UsePrimaryDemo, MDODOD.Group1PrimaryGRP, MDODOD.Group2PrimaryGRP))
                    End If
                Next

            Next

        End Sub

        Private Sub CalculateTotalReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleStationSummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary),
                                          ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail),
                                          UsePrimaryDemo As Boolean)

            'objects
            Dim ReachTotal As Double = 0
            Dim MediaBroadcastWorksheetBroadcastScheduleStationSummaries As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary) = Nothing
            Dim DemoInfos As Generic.List(Of Database.Classes.ReachFreqDetail) = Nothing
            Dim CumeImpressionsValues As Generic.List(Of Long) = Nothing
            Dim CumesValues As Generic.List(Of Long) = Nothing
            Dim AllReachValuesList As Generic.List(Of Double) = Nothing
            Dim AllReachValues() As Double = Nothing
            Dim TotalSpots As Integer = 0
            Dim Impressions As Long = 0
            Dim RowSpots As Integer = 0
            Dim TotalImpressions As Long = 0
            Dim TotalSpotImpressions As Long = 0
            Dim TotalRating As Decimal = 0
            Dim Universe As Long = 0
            Dim TotalAQH As Long = 0
            Dim AQH As Long = 0
            Dim BookRating As Decimal = 0

            'For Each VendorCode In MediaBroadcastWorksheetBroadcastScheduleStationSummary.Select(Function(Entity) Entity.VendorCode).Distinct.ToList
            For Each MarketDescription In MediaBroadcastWorksheetBroadcastScheduleStationSummary.Select(Function(Entity) Entity.MarketDescription).Distinct.ToList

                ReachTotal = 0
                CumeImpressionsValues = Nothing
                CumesValues = Nothing
                AllReachValuesList = Nothing
                AllReachValues = Nothing
                TotalSpots = 0
                Impressions = 0
                RowSpots = 0
                TotalImpressions = 0
                TotalSpotImpressions = 0
                TotalRating = 0
                Universe = 0
                TotalAQH = 0
                AQH = 0
                BookRating = 0

                DemoInfos = ReachFreqDetailLines.Where(Function(Entity) Entity.MarketDescription = MarketDescription AndAlso Entity.OnHold = False).ToList

                MediaBroadcastWorksheetBroadcastScheduleStationSummaries = MediaBroadcastWorksheetBroadcastScheduleStationSummary.Where(Function(Entity) Entity.MarketDescription = MarketDescription).ToList

                If DemoInfos.Any(Function(Entity) Entity.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0) AndAlso
                        DemoInfos.Any(Function(Entity) Entity.VendorNielsenTVStationCode.GetValueOrDefault(0) <> 0 OrElse
                                                       Entity.CableNetworkNielsenTVStationCode.GetValueOrDefault(0) <> 0) Then

                    CumeImpressionsValues = DemoInfos.Select(Function(Entity) If(UsePrimaryDemo, Entity.PrimaryCumeImpressions.GetValueOrDefault(0), Entity.SecondaryCumeImpressions.GetValueOrDefault(0))).Distinct.ToList

                Else

                    CumeImpressionsValues = New Generic.List(Of Long)

                End If

                AllReachValuesList = New Generic.List(Of Double)

                If CumeImpressionsValues.Count > 0 Then

                    For Each CumeInpression In CumeImpressionsValues

                        TotalSpots = 0
                        TotalImpressions = 0
                        TotalRating = 0
                        TotalSpotImpressions = 0
                        Universe = 0

                        For Each DemoInfo In DemoInfos.Where(Function(Entity) CumeInpression = If(UsePrimaryDemo, Entity.PrimaryCumeImpressions, Entity.SecondaryCumeImpressions))

                            RowSpots = 0
                            Impressions = If(UsePrimaryDemo, DemoInfo.PrimaryBuyImpressions.GetValueOrDefault(0), DemoInfo.SecondaryBuyImpressions.GetValueOrDefault(0))

                            TotalImpressions = Impressions
                            TotalRating += CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0)))

                            If Universe = 0 Then

                                Universe = CLng(If(UsePrimaryDemo, DemoInfo.PrimaryUniverse.GetValueOrDefault(0), DemoInfo.SecondaryUniverse.GetValueOrDefault(0)))

                            End If

                            RowSpots += DemoInfo.Spots

                            TotalSpots = RowSpots

                            TotalSpotImpressions += (Impressions * RowSpots)

                            BookRating = CDec(If(UsePrimaryDemo, DemoInfo.PrimaryBookRating.GetValueOrDefault(0), DemoInfo.SecondaryBookRating.GetValueOrDefault(0)))

                            If CumeInpression < Impressions Then

                                AllReachValuesList.Add(CalculateCumlessReach(CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), TotalSpots))

                            Else

                                AllReachValuesList.Add(CalculateTVReach(Impressions, CumeInpression, RowSpots, Universe, CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), BookRating))

                            End If

                        Next

                    Next

                ElseIf MediaBroadcastWorksheetBroadcastScheduleStationSummaries IsNot Nothing AndAlso MediaBroadcastWorksheetBroadcastScheduleStationSummaries.Count > 0 Then

                    For Each DemoInfo In DemoInfos

                        AllReachValuesList.Add(If(UsePrimaryDemo, DemoInfo.PrimaryReach.GetValueOrDefault(0), DemoInfo.SecondaryReach.GetValueOrDefault(0)))

                    Next

                End If

                AllReachValues = AllReachValuesList.ToArray

                If AllReachValues.Length > 2 Then

                    ReachTotal = (AllReachValues(0) + AllReachValues(1)) - (AllReachValues(0) * AllReachValues(1))

                    ReachTotal = Math.Round(ReachTotal, 3)

                    For ReachValueIndex As Integer = 2 To AllReachValues.Length - 1

                        ReachTotal = (ReachTotal + AllReachValues(ReachValueIndex)) - (ReachTotal * AllReachValues(ReachValueIndex))

                        ReachTotal = Math.Round(ReachTotal, 3)

                    Next

                ElseIf AllReachValues.Length = 2 Then

                    ReachTotal = (AllReachValues(0) + AllReachValues(1)) - (AllReachValues(0) * AllReachValues(1))

                    ReachTotal = Math.Round(ReachTotal, 3)

                ElseIf AllReachValues.Length = 1 Then

                    ReachTotal = AllReachValues(0)

                End If

                If Double.IsNaN(ReachTotal) Then

                    ReachTotal = 0

                End If

                For Each MDODOD In MediaBroadcastWorksheetBroadcastScheduleStationSummary.Where(Function(Entity) Entity.MarketDescription = MarketDescription).ToList

                    If (UsePrimaryDemo) Then
                        MDODOD.Group1TotalReachPCT = ReachTotal

                        MDODOD.Group1TotalFrequency = CalcFreq(MDODOD.Group1TotalReachPCT, If(UsePrimaryDemo, MDODOD.Group1TotalGRP, MDODOD.Group2TotalGRP))
                    Else
                        MDODOD.Group2TotalReachPCT = ReachTotal

                        MDODOD.Group2TotalFrequency = CalcFreq(MDODOD.Group2TotalReachPCT, If(UsePrimaryDemo, MDODOD.Group1TotalGRP, MDODOD.Group2TotalGRP))
                    End If
                Next

            Next

        End Sub



        Private Function CalcFreq(ByRef Reach As Double, GRP As Double) As Double

            Dim FrequencyTotal As Decimal
            If Reach = 0 Then

                FrequencyTotal = 0

            Else

                FrequencyTotal = GRP / (Reach * 100)

            End If

            If Double.IsNaN(FrequencyTotal) Then

                FrequencyTotal = 0

            End If

            CalcFreq = FrequencyTotal
        End Function
        Private Sub XrLabelDisclamier_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelDisclamier.BeforePrint

            If _CurrentDataLine IsNot Nothing Then

                If _CurrentDataLine.ShowRF = False Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub XrLabelLocationHeaderInfo_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrLabelLocationHeaderInfo.PrintOnPage

            If e.PageIndex > 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrLine3_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrLine3.PrintOnPage

            If e.PageIndex > 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub MediaBroadcastWorksheetBroadcastScheduleStationSummaryReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

#End Region

    End Class

End Namespace
