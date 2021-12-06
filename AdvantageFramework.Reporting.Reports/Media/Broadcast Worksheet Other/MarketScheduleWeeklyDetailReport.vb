Namespace Media.BroadcastWorksheetOther

    Public Class MarketScheduleWeeklyDetailReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ParameterDictionary As Dictionary(Of String, Object) = Nothing
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
        Private _Sharebook As String = Nothing
        Private _HPUTbook As String = Nothing
        Private _Date As String = String.Empty
        Private _TotalGIMP As Decimal = 0
        Private _GrandTotalGIMP As Decimal = 0
        Private _Reach As Decimal = 0
        Private _Frequency As Decimal = 0
        Private _Books As String = Nothing
        Private _IsRadio As Boolean = False
        Private _UsePrimaryDemo As Boolean = True
        Private _FromDate As Date = Date.MinValue
        Private _ToDate As Date = Date.MinValue
        Private _MarketScheduleWeeklyDetailReports As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport) = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ParameterDictionary As Dictionary(Of String, Object)
            Set(ByVal value As Dictionary(Of String, Object))
                _ParameterDictionary = value
            End Set
        End Property
        Public WriteOnly Property LocationEntity As AdvantageFramework.Database.Entities.Location
            Set(ByVal value As AdvantageFramework.Database.Entities.Location)
                _LocationEntity = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleMarketSummary As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport),
                                          ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail),
                                          UsePrimaryDemo As Boolean)

            'objects
            Dim ReachTotal As Double = 0
            Dim MediaBroadcastWorksheetBroadcastScheduleMarketSummaries As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport) = Nothing
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

            ' For Each MBWMID In MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Select(Function(Entity) Entity.MediaBroadcastWorksheetMarketID).Distinct.ToList

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

            DemoInfos = ReachFreqDetailLines.Where(Function(Entity) Entity.OnHold = False).ToList

            MediaBroadcastWorksheetBroadcastScheduleMarketSummaries = MediaBroadcastWorksheetBroadcastScheduleMarketSummary.ToList  '.Where(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = MBWMID).ToList

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

            ElseIf MediaBroadcastWorksheetBroadcastScheduleMarketSummaries IsNot Nothing AndAlso MediaBroadcastWorksheetBroadcastScheduleMarketSummaries.Count > 0 Then

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

            'For Each MDODOD In MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Where(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = MBWMID).ToList

            'If (UsePrimaryDemo) Then

            _Reach = ReachTotal * 100

            _Frequency = CalcFreq(ReachTotal, If(UsePrimaryDemo, ReachFreqDetailLines.Sum(Function(DL) DL.PrimaryGRP), ReachFreqDetailLines.Sum(Function(DL) DL.SecondaryGRP)))

            'Else

            'MDODOD.Group2ReachPCT = ReachTotal

            'MDODOD.Group2Frequency = CalcFreq(MDODOD.Group2ReachPCT, If(UsePrimaryDemo, MDODOD.Group1PrimaryGRP, MDODOD.Group2PrimaryGRP))

            'End If

            ' Next

            'Next

        End Sub
        Private Function CalcFreq(ByRef Reach As Double, GRP As Double) As Decimal

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
        Private Sub CalculateRadioReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleMarketSummary As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport),
                                               ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail),
                                               UsePrimaryDemo As Boolean)

            'objects
            Dim ReachTotal As Double = 0
            Dim MediaBroadcastWorksheetBroadcastScheduleMarketSummaries As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport) = Nothing
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

            DemoInfos = ReachFreqDetailLines.Where(Function(Entity) Entity.OnHold = False).ToList

            MediaBroadcastWorksheetBroadcastScheduleMarketSummaries = MediaBroadcastWorksheetBroadcastScheduleMarketSummary.ToList

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
                        Impressions = If(UsePrimaryDemo, DemoInfo.PrimaryAQH.GetValueOrDefault(0), DemoInfo.SecondaryAQH.GetValueOrDefault(0))

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

                            AllReachValuesList.Add(CalculateRadioReach(Impressions, CumeInpression, RowSpots, Universe, CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), BookRating))

                        End If

                    Next

                Next

            ElseIf MediaBroadcastWorksheetBroadcastScheduleMarketSummaries IsNot Nothing AndAlso MediaBroadcastWorksheetBroadcastScheduleMarketSummaries.Count > 0 Then

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

            _Reach = ReachTotal * 100

            _Frequency = CalcFreq(ReachTotal, If(UsePrimaryDemo, ReachFreqDetailLines.Sum(Function(DL) DL.PrimaryGRP), ReachFreqDetailLines.Sum(Function(DL) DL.SecondaryGRP)))

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub MarketScheduleWeeklyDetailReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub MarketScheduleWeeklyDetail_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            Dim MediaBroadcastWorksheetID As Integer = 0
            Dim MediaBroadcastWorksheetMarketIDVendorCodes As String = Nothing
            Dim ShowSecondaryDemo As Boolean = False

            If _Session IsNot Nothing AndAlso _ParameterDictionary IsNot Nothing Then

                MediaBroadcastWorksheetID = _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.MediaBroadcastWorksheetID.ToString)
                MediaBroadcastWorksheetMarketIDVendorCodes = _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.MediaBroadcastWorksheetMarketIDVendorCodes.ToString)
                _FromDate = _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.FromDate.ToString)
                _ToDate = _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ToDate.ToString)
                ShowSecondaryDemo = _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowSecondardDemo.ToString)

                If ShowSecondaryDemo Then

                    _UsePrimaryDemo = False

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _MarketScheduleWeeklyDetailReports = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport)(String.Format("exec advsp_media_broadcast_worksheet_other_market_schedule_weekly_detail_report {0}, '{1}', '{2}', '{3}', {4}",
                                                                                                                                                                         MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketIDVendorCodes, _FromDate, _ToDate, ShowSecondaryDemo)).ToList

                    _MarketScheduleWeeklyDetailReports = _MarketScheduleWeeklyDetailReports.Where(Function(R) R.Spots.GetValueOrDefault(0) > 0).ToList

                    If _MarketScheduleWeeklyDetailReports.Count > 0 Then

                        If _MarketScheduleWeeklyDetailReports.First.MediaType = "R" Then

                            _IsRadio = True

                        End If

                    End If

                    Me.DataSource = _MarketScheduleWeeklyDetailReports

                End Using

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub GroupHeaderMarketName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderMarketName.BeforePrint

            Dim MarketScheduleWeeklyDetailReport As AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport = Nothing
            Dim ComscoreTVBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing
            Dim NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod = Nothing
            Dim DTONielsenRadioPeriod As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing

            _Sharebook = Nothing
            _HPUTbook = Nothing

            Try

                MarketScheduleWeeklyDetailReport = Me.GetCurrentRow()

                If MarketScheduleWeeklyDetailReport IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If MarketScheduleWeeklyDetailReport.MediaType = "T" AndAlso MarketScheduleWeeklyDetailReport.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                            If MarketScheduleWeeklyDetailReport.SharebookID.GetValueOrDefault(0) <> 0 Then

                                ComscoreTVBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, MarketScheduleWeeklyDetailReport.SharebookID.Value)

                                If ComscoreTVBook IsNot Nothing Then

                                    _Sharebook = MonthName(ComscoreTVBook.Month, True) & ComscoreTVBook.Year & "-" & AdvantageFramework.Reporting.Reports.GetStreamName(ComscoreTVBook)

                                End If

                            End If

                            If MarketScheduleWeeklyDetailReport.HPUTbookID.GetValueOrDefault(0) <> 0 Then

                                ComscoreTVBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, MarketScheduleWeeklyDetailReport.HPUTbookID.Value)

                                If ComscoreTVBook IsNot Nothing Then

                                    _HPUTbook = MonthName(ComscoreTVBook.Month, True) & ComscoreTVBook.Year & "-" & AdvantageFramework.Reporting.Reports.GetStreamName(ComscoreTVBook)

                                End If

                            End If

                        ElseIf MarketScheduleWeeklyDetailReport.MediaType = "T" AndAlso MarketScheduleWeeklyDetailReport.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                            If _Session.IsNielsenSetup Then

                                If MarketScheduleWeeklyDetailReport.SharebookID.GetValueOrDefault(0) <> 0 Then

                                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                                        NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, MarketScheduleWeeklyDetailReport.SharebookID.Value)

                                        If NielsenTVBook IsNot Nothing Then

                                            _Sharebook = MonthName(NielsenTVBook.Month, True) & NielsenTVBook.Year.ToString.Substring(2) & "-" & AdvantageFramework.Reporting.Reports.GetStreamName(NielsenTVBook)

                                        End If

                                        If MarketScheduleWeeklyDetailReport.HPUTbookID.GetValueOrDefault(0) <> 0 Then

                                            NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, MarketScheduleWeeklyDetailReport.HPUTbookID.Value)

                                            If NielsenTVBook IsNot Nothing Then

                                                _HPUTbook = MonthName(NielsenTVBook.Month, True) & NielsenTVBook.Year.ToString.Substring(2) & "-" & AdvantageFramework.Reporting.Reports.GetStreamName(NielsenTVBook)

                                            End If

                                        End If

                                    End Using

                                End If

                            End If

                        ElseIf MarketScheduleWeeklyDetailReport.MediaType = "R" AndAlso _Session.IsNielsenSetup Then

                            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                                If MarketScheduleWeeklyDetailReport.RadioPeriod1.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, MarketScheduleWeeklyDetailReport.RadioPeriod1.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books = DTONielsenRadioPeriod.Description

                                    End If

                                End If

                                If MarketScheduleWeeklyDetailReport.RadioPeriod2.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, MarketScheduleWeeklyDetailReport.RadioPeriod2.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books += ", " & DTONielsenRadioPeriod.Description

                                    End If

                                End If

                                If MarketScheduleWeeklyDetailReport.RadioPeriod3.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, MarketScheduleWeeklyDetailReport.RadioPeriod3.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books += ", " & DTONielsenRadioPeriod.Description

                                    End If

                                End If

                                If MarketScheduleWeeklyDetailReport.RadioPeriod4.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, MarketScheduleWeeklyDetailReport.RadioPeriod4.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books += ", " & DTONielsenRadioPeriod.Description

                                    End If

                                End If

                                If MarketScheduleWeeklyDetailReport.RadioPeriod5.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, MarketScheduleWeeklyDetailReport.RadioPeriod5.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books += ", " & DTONielsenRadioPeriod.Description

                                    End If

                                End If

                            End Using

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LabelGroupHeaderStation_Date_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Date.BeforePrint

            LabelGroupHeaderStation_Date.Text = Now.ToShortDateString

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _LocationEntity IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_LocationEntity.LogoLandscapePath) AndAlso My.Computer.FileSystem.FileExists(_LocationEntity.LogoLandscapePath) Then

                XrPictureBoxHeaderLogo.ImageUrl = _LocationEntity.LogoLandscapePath

                Cancel = False

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub LabelGroupHeader_Rate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_Rate.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRates.ToString)

        End Sub
        Private Sub LabelGroupHeader_Rating_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_Rating.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRatings.ToString)

        End Sub
        Private Sub LabelGroupHeader_GRP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_GRP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRatings.ToString)

        End Sub
        Private Sub LabelGroupHeader_CPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_CPP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPP.ToString)

        End Sub
        Private Sub LabelGroupHeader_Impressions_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_Impressions.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowImpressions.ToString)

            If Not e.Cancel Then

                If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                    LabelGroupHeader_Impressions.Text = "AQH (00)"

                End If

            End If

        End Sub
        Private Sub LabelGroupHeader_GIMP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_GIMP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowImpressions.ToString)

            If Not e.Cancel Then

                If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                    LabelGroupHeader_GIMP.Text = "GIMP (00)"

                End If

            End If

        End Sub
        Private Sub LabelGroupHeader_CPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_CPM.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPM.ToString)

        End Sub
        Private Sub LabelGroupHeader_TotalCost_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_TotalCost.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowTotalCost.ToString)

        End Sub
        Private Sub LabelDetail_Rate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Rate.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRates.ToString)

        End Sub
        Private Sub LabelDetail_Rating_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Rating.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRatings.ToString)

        End Sub
        Private Sub LabelDetail_GRP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_GRP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRatings.ToString)

        End Sub
        Private Sub LabelDetail_CPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_CPP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPP.ToString)

        End Sub
        Private Sub LabelDetail_Impressions_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Impressions.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowImpressions.ToString)

        End Sub
        Private Sub LabelDetail_GIMP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_GIMP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowImpressions.ToString)

        End Sub
        Private Sub LabelDetail_CPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_CPM.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPM.ToString)

        End Sub
        Private Sub LabelDetail_TotalCost_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_TotalCost.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowTotalCost.ToString)

        End Sub
        Private Sub ReportFooter_TotalCost_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_TotalCost.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowTotalCost.ToString)

        End Sub
        Private Sub ReportFooter_GRP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_GRP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRatings.ToString)

        End Sub
        Private Sub ReportFooter_GIMP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_GIMP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowImpressions.ToString)

        End Sub
        Private Sub ReportFooter_CPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_CPP.BeforePrint

            If Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPP.ToString) Then

                e.Cancel = True

            Else

                If ReportFooter_GRP.Summary.GetResult() = 0 Then

                    ReportFooter_CPP.Text = "0.00"

                Else

                    ReportFooter_CPP.Text = FormatNumber(Me.ReportFooter_TotalCost.Summary.GetResult() / ReportFooter_GRP.Summary.GetResult(), 2)

                End If

            End If

        End Sub
        Private Sub ReportFooter_CPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_CPM.BeforePrint

            If Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPM.ToString) Then

                e.Cancel = True

            Else

                If _GrandTotalGIMP = 0 Then

                    ReportFooter_CPM.Text = "0.00"

                Else

                    If _IsRadio Then

                        ReportFooter_CPM.Text = FormatNumber(Me.ReportFooter_TotalCost.Summary.GetResult() / _GrandTotalGIMP * 1000, 2)

                    Else

                        ReportFooter_CPM.Text = FormatNumber(Me.ReportFooter_TotalCost.Summary.GetResult() / _GrandTotalGIMP * 1000, 2)

                    End If

                End If

            End If

        End Sub
        Private Sub MarketFooter_CPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles MarketFooter_CPM.BeforePrint

            If Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPM.ToString) Then

                e.Cancel = True

            Else

                If _TotalGIMP = 0 Then

                    MarketFooter_CPM.Text = "0.00"

                Else

                    If _IsRadio Then

                        MarketFooter_CPM.Text = FormatNumber(Me.MarketFooter_TotalCost.Summary.GetResult() / _TotalGIMP * 1000, 2)

                    Else

                        MarketFooter_CPM.Text = FormatNumber(Me.MarketFooter_TotalCost.Summary.GetResult() / _TotalGIMP * 1000, 2)

                    End If

                End If

            End If

        End Sub
        Private Sub MarketFooter_CPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles MarketFooter_CPP.BeforePrint

            If Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPP.ToString) Then

                e.Cancel = True

            Else

                If MarketFooter_GRP.Summary.GetResult() = 0 Then

                    MarketFooter_CPP.Text = "0.00"

                Else

                    MarketFooter_CPP.Text = FormatNumber(Me.MarketFooter_TotalCost.Summary.GetResult() / MarketFooter_GRP.Summary.GetResult(), 2)

                End If

            End If

        End Sub
        Private Sub MarketFooter_GIMP_SummaryReset(sender As Object, e As EventArgs) Handles MarketFooter_GIMP.SummaryReset

            _TotalGIMP = 0

        End Sub
        Private Sub MarketFooter_GIMP_SummaryRowChanged(sender As Object, e As EventArgs) Handles MarketFooter_GIMP.SummaryRowChanged

            _TotalGIMP += Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.GIMPRaw.ToString)

        End Sub
        Private Sub MarketFooter_GIMP_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles MarketFooter_GIMP.SummaryGetResult

            If _IsRadio Then

                e.Result = FormatNumber(_TotalGIMP / 100, 1)

            Else

                e.Result = FormatNumber(_TotalGIMP / 1000, 1)

            End If

            e.Handled = True

        End Sub
        Private Sub MarketFooter_GIMP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles MarketFooter_GIMP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowImpressions.ToString)

        End Sub
        Private Sub ReportFooter_GIMP_SummaryReset(sender As Object, e As EventArgs) Handles ReportFooter_GIMP.SummaryReset

            _GrandTotalGIMP = 0

        End Sub
        Private Sub ReportFooter_GIMP_SummaryRowChanged(sender As Object, e As EventArgs) Handles ReportFooter_GIMP.SummaryRowChanged

            _GrandTotalGIMP += Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.GIMPRaw.ToString)

        End Sub
        Private Sub ReportFooter_GIMP_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles ReportFooter_GIMP.SummaryGetResult

            If _IsRadio Then

                e.Result = FormatNumber(_GrandTotalGIMP / 100, 1)

            Else

                e.Result = FormatNumber(_GrandTotalGIMP / 1000, 1)

            End If

            e.Handled = True

        End Sub
        Private Sub MarketFooter_GRP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles MarketFooter_GRP.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRatings.ToString)

        End Sub
        Private Sub MarketFooter_TotalCost_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles MarketFooter_TotalCost.BeforePrint

            e.Cancel = Not _ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowTotalCost.ToString)

        End Sub
        Private Sub LabelGroupHeader_ShareBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_ShareBookLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                LabelGroupHeader_ShareBookLabel.Text = "Book(s):"

            ElseIf String.IsNullOrWhiteSpace(_Sharebook) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeader_ShareBook_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_ShareBook.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                LabelGroupHeader_ShareBook.Text = _Books

            Else

                LabelGroupHeader_ShareBook.Text = _Sharebook

            End If

        End Sub
        Private Sub LabelGroupHeader_HPUTBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_HPUTBookLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_HPUTbook) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeader_HPUTBook_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeader_HPUTBook.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                e.Cancel = True

            Else

                LabelGroupHeader_HPUTBook.Text = _HPUTbook

            End If

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub GroupFooterMarketName_ReachFrequency_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarketName_ReachFrequency.BeforePrint

            Dim ReachFreqDetailLines As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ReachFreqDetail) = Nothing
            Dim MarketScheduleWeeklyDetailReports As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport) = Nothing
            Dim MarketWorksheetMarketIdList As Generic.List(Of Integer) = Nothing
            Dim UsePrimaryDemoList As Generic.List(Of Boolean) = Nothing
            Dim VendorCodeList As String = Nothing
            Dim MediaBroadcastWorksheetMarketID As Integer = 0
            Dim MarketScheduleWeeklyDetailReport As AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport = Nothing

            MarketScheduleWeeklyDetailReport = Me.GetCurrentRow()

            If MarketScheduleWeeklyDetailReport.MediaType = "T" AndAlso MarketScheduleWeeklyDetailReport.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                e.Cancel = True

            Else

                MediaBroadcastWorksheetMarketID = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaBroadcastWorksheetMarketID.ToString)

                MarketScheduleWeeklyDetailReports = _MarketScheduleWeeklyDetailReports.Where(Function(R) R.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID AndAlso R.Spots.GetValueOrDefault(0) > 0).ToList

                MarketWorksheetMarketIdList = New Generic.List(Of Integer)
                MarketWorksheetMarketIdList.Add(MediaBroadcastWorksheetMarketID) ' = MarketScheduleWeeklyDetailReports.Select(Function(DR) DR.MediaBroadcastWorksheetMarketID).Distinct.ToList

                VendorCodeList = String.Join(",", MarketScheduleWeeklyDetailReports.Select(Function(DR) DR.VendorCode).Distinct.ToArray)

                UsePrimaryDemoList = New Generic.List(Of Boolean)
                UsePrimaryDemoList.Add(_UsePrimaryDemo)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ReachFreqDetailLines = Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.LoadReachFreqDetailsWithExactDates(DbContext, MarketWorksheetMarketIdList, _FromDate, _ToDate, UsePrimaryDemoList, VendorCodeList).ToList()

                End Using

                If _IsRadio Then

                    CalculateRadioReachAndFreq(MarketScheduleWeeklyDetailReports, ReachFreqDetailLines, _UsePrimaryDemo)

                Else

                    CalculateReachAndFreq(MarketScheduleWeeklyDetailReports, ReachFreqDetailLines, _UsePrimaryDemo)

                End If

                GroupFooterMarketName_ReachFrequency.Text = FormatNumber(_Reach, 1).ToString & " / " & FormatNumber(_Frequency, 1).ToString

            End If

        End Sub
        Private Sub LabelGroupMarketName_MediaType_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupMarketName_MediaType.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                LabelGroupMarketName_MediaType.Text = "Spot Radio"

            End If

        End Sub
        Private Sub LabelGroupMarketName_NetworkProgram_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupMarketName_NetworkProgram.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_StationName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_StationName.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                LabelDetail_StationName.WidthF = 245.38

            End If

        End Sub
        Private Sub LabelDetail_Program_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Program.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterMarketName_ReachFrequencyLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarketName_ReachFrequencyLabel.BeforePrint

            Dim MarketScheduleWeeklyDetailReport As AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport = Nothing

            MarketScheduleWeeklyDetailReport = Me.GetCurrentRow()

            If MarketScheduleWeeklyDetailReport.MediaType = "T" AndAlso MarketScheduleWeeklyDetailReport.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
