Namespace Media

    Public Class MediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _CurrentDataLine As Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary = Nothing
        Private _PrintGroup2 As Boolean = False
        Private _ReachFreqDetails As List(Of Database.Classes.ReachFreqDetail) = Nothing
        Private _ReachFreqDetail As Database.Classes.ReachFreqDetail = Nothing
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
                ' MediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaBroadcastWorksheetBroadcastScheduleMarketSummary
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

        Private Sub MediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
            'Braxton
            Dim MediaBroadcastWorksheetBroadcastScheduleMarketSummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary) = Nothing
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

            MarketWorksheetMarketIdList = New Generic.List(Of Integer)
            UsePrimaryDemoList = New Generic.List(Of Boolean)
            BroadcastStartYearMonthList = New Generic.List(Of Nullable(Of Integer))
            BroadcastEndYearMonthList = New Generic.List(Of Nullable(Of Integer))

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
            Dim ShowComments As Boolean = True
            Dim ShowSpotCosts As Boolean = True
            Dim ShowImpressions As Boolean = True
            Dim ShowBookends As Boolean = True
            Dim ShowTotalCosts As Boolean = True
            Dim WorksheetIsGross As Boolean = True
            Dim ShowCPPM As Boolean = True
            Dim ShowAddedValue As Boolean = True
            Dim ShowRF As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowRatings") Then
                    ShowRatings = ParameterDictionary("ShowRatings")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowComments") Then
                    ShowComments = ParameterDictionary("ShowComments")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowSpotCosts") Then
                    ShowSpotCosts = ParameterDictionary("ShowSpotCosts")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowImpressions") Then
                    ShowImpressions = ParameterDictionary("ShowImpressions")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowBookends") Then
                    ShowBookends = ParameterDictionary("ShowBookends")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowTotalCosts") Then
                    ShowTotalCosts = ParameterDictionary("ShowTotalCosts")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowCPPM") Then
                    ShowCPPM = ParameterDictionary("ShowCPPM")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowAddedValue") Then
                    ShowAddedValue = ParameterDictionary("ShowAddedValue")
                End If
            Catch ex As Exception

            End Try

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

            Try
                If ParameterDictionary.ContainsKey("WorksheetIsGross") Then
                    WorksheetIsGross = ParameterDictionary("WorksheetIsGross")
                End If
            Catch ex As Exception

            End Try

            Try

                If ParameterDictionary.ContainsKey("MediaBroadcastWorksheetMarketBooks") Then
                    MediaBroadcastWorksheetMarketBooks = ParameterDictionary("MediaBroadcastWorksheetMarketBooks")
                    MarketWorksheetMarketIdList = New List(Of Integer)
                    For Each WorksheetMarket In MediaBroadcastWorksheetMarketBooks

                        MarketWorksheetMarketIdList.Add(DirectCast(WorksheetMarket, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).MediaBroadcastWorksheetMarketID)
                        UsePrimaryDemoList.Add(WorksheetMarket.UsePrimaryDemo)

                        'Handle Nullable Integers
                        BroadcastStartYearMonthList.Add(WorksheetMarket.BroadcastStartYearMonth)
                        BroadcastEndYearMonthList.Add(WorksheetMarket.BroadcastEndYearMonth)
                    Next
                End If

                Using DbContext = New Database.DbContext(Session.ConnectionString, Session.UserCode)
                    MediaBroadcastWorksheetBroadcastScheduleMarketSummary =
                    Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                        LoadMarketSummary(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, "Broadcast Schedule Market Report", VendorCodeList, _LocationName, _ShowNet, WorksheetIsGross).ToList()

                    ReachFreqDetailLines =
                    Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                    LoadReachFreqDetails(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, VendorCodeList).ToList()
                End Using

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If String.IsNullOrWhiteSpace(_LocationName) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationName, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderLandscape)

                    Else

                        _LocationLogo = Nothing

                    End If

                End Using

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

                For Each DataLine In MediaBroadcastWorksheetBroadcastScheduleMarketSummary

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

                CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleMarketSummary, ReachFreqDetailLines, True)
                CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleMarketSummary, ReachFreqDetailLines, False)

                MigrateOneSecondDemo(MediaBroadcastWorksheetBroadcastScheduleMarketSummary)

                Me.DataSource = MediaBroadcastWorksheetBroadcastScheduleMarketSummary

                _PrintGroup2 = False

                If (MediaBroadcastWorksheetBroadcastScheduleMarketSummary IsNot Nothing) Then
                    If (MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Count > 0) Then
                        _CurrentDataLine = MediaBroadcastWorksheetBroadcastScheduleMarketSummary.FirstOrDefault
                        _PrintGroup2 = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Group2Name)

                        If (_CurrentDataLine.MediaTypeCode = "R") Then
                            XrLabel1.TextFormatString = "{0:#,#}"
                            XrLabel2.TextFormatString = "{0:#,#}"
                        Else
                            XrLabel1.TextFormatString = "{0:#,#.0}"
                            XrLabel2.TextFormatString = "{0:#,#.0}"
                        End If

                    Else
                        _CurrentDataLine = New Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary
                        _PrintGroup2 = False
                    End If
                Else
                    _CurrentDataLine = New Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary
                End If


            Catch ex As Exception

            End Try
        End Sub

        Public Sub MigrateOneSecondDemo(MediaBroadcastWorksheetBroadcastScheduleMarketSummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary))

            Dim SecondaryDemoCount As Integer = MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Where(Function(x) Not String.IsNullOrEmpty(x.Group2Name)).Select(Function(x) x.Group2Name).Distinct.Count

            If (SecondaryDemoCount = 1) Then

                Dim Group2Name As String = MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Where(Function(x) Not String.IsNullOrEmpty(x.Group2Name)).Select(Function(x) x.Group2Name).Distinct.First

                For Each Line In MediaBroadcastWorksheetBroadcastScheduleMarketSummary
                    Line.Group2Name = Group2Name
                Next

            End If

        End Sub



        Private Sub CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleMarketSummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary),
                                          ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail),
                                          UsePrimaryDemo As Boolean)

            'objects
            Dim ReachTotal As Double = 0
            Dim MediaBroadcastWorksheetBroadcastScheduleMarketSummaries As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary) = Nothing
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

            For Each MBWMID In MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Select(Function(Entity) Entity.MediaBroadcastWorksheetMarketID).Distinct.ToList

                ' UsePrimaryDemo = MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Where(Function(DataLine) DataLine.MediaBroadcastWorksheetMarketID = MBWMID).Select(Function(Items) Items.UsePrimaryDemo).First

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

                DemoInfos = ReachFreqDetailLines.Where(Function(Entity) Entity.MediaBroadCastWorksheetMarketID = MBWMID AndAlso Entity.OnHold = False).ToList

                MediaBroadcastWorksheetBroadcastScheduleMarketSummaries = MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Where(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = MBWMID).ToList

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

                For Each MDODOD In MediaBroadcastWorksheetBroadcastScheduleMarketSummary.Where(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = MBWMID).ToList
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


        Private Sub MediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles MyBase.DataSourceRowChanged
            _CurrentDataLine = TryCast(Me.GetCurrentRow(), Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary)
            _PrintGroup2 = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Group2Name)
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

            XrTableCell39.Visible = _PrintGroup2
            XrTableCell55.Visible = _PrintGroup2
            XrTableCell56.Visible = _PrintGroup2
            XrTableCell57.Visible = _PrintGroup2
            XrTableCell58.Visible = _PrintGroup2
            XrTableCell83.Visible = _PrintGroup2
            XrTableCell84.Visible = _PrintGroup2
            XrTableCell85.Visible = _PrintGroup2
            XrTableCell86.Visible = _PrintGroup2
            XrTableCell102.Visible = _PrintGroup2
            XrTableCell107.Visible = _PrintGroup2
            XrTableCell108.Visible = _PrintGroup2
            XrLabel1.Visible = _PrintGroup2
            XrLabel3.Visible = _PrintGroup2

            If (_CurrentDataLine IsNot Nothing) Then
                If (_CurrentDataLine.MediaTypeCode = "R") Then
                    XrTableCell77.TextFormatString = "{0:#,#}"
                    XrTableCell75.TextFormatString = "{0:#,#}"
                    XrLabel1.TextFormatString = "{0:#,#}"
                    XrLabel2.TextFormatString = "{0:#,#}"
                Else
                    XrTableCell77.TextFormatString = "{0:#,#.0}"
                    XrTableCell75.TextFormatString = "{0:#,#.0}"
                    XrLabel1.TextFormatString = "{0:#,#.0}"
                    XrLabel2.TextFormatString = "{0:#,#.0}"
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
                    XrTableCell35.Visible = False
                    XrTableCell82.Visible = False

                    XrTableCell55.Visible = False
                    XrTableCell86.Visible = False

                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell35.Visible = True
                        XrTableCell55.Visible = _PrintGroup2

                    Else

                        XrTableCell35.Visible = False
                        XrTableCell55.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrTableCell82.Visible = True
                        XrTableCell86.Visible = _PrintGroup2

                    Else

                        XrTableCell82.Visible = False
                        XrTableCell86.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowRatings) Then
                    XrTableCell52.Visible = False
                    XrTableCell53.Visible = False

                    XrTableCell56.Visible = False
                    XrTableCell57.Visible = False
                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrTableCell54.Visible = False
                    XrTableCell58.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRF) Then
                    XrTableCell80.Visible = False
                    XrTableCell81.Visible = False

                    XrTableCell84.Visible = False
                    XrTableCell85.Visible = False
                End If

                If _CurrentDataLine.ShowRatings = False AndAlso _CurrentDataLine.ShowImpressions = False AndAlso
                        _CurrentDataLine.ShowRF = False AndAlso _CurrentDataLine.ShowCPPM = False Then

                    XrTableCell40.Visible = False
                    XrTableCell66.Visible = False
                    XrTableCell67.Visible = False
                    XrTableCell108.Visible = False

                    XrTableCell39.Visible = False
                    XrTableCell107.Visible = False
                    XrTableCell103.Visible = False
                    XrTableCell104.Visible = False
                End If
            End If

        End Sub

        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
            XrTableCell71.Visible = _PrintGroup2
            XrTableCell72.Visible = _PrintGroup2
            XrTableCell76.Visible = _PrintGroup2
            XrTableCell77.Visible = _PrintGroup2
            XrTableCell95.Visible = _PrintGroup2
            XrTableCell96.Visible = _PrintGroup2
            XrTableCell97.Visible = _PrintGroup2

            If (_CurrentDataLine IsNot Nothing) Then
                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    XrTableCell68.Visible = False
                    XrTableCell69.Visible = False
                End If

                If Not (_CurrentDataLine.ShowCPPM) Then
                    XrTableCell37.Visible = False
                    XrTableCell93.Visible = False

                    XrTableCell71.Visible = False
                    XrTableCell97.Visible = False
                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell37.Visible = True
                        XrTableCell71.Visible = _PrintGroup2

                    Else

                        XrTableCell37.Visible = False
                        XrTableCell71.Visible = False

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
                    XrTableCell70.Visible = False
                    XrTableCell74.Visible = False

                    XrTableCell72.Visible = False
                    XrTableCell76.Visible = False
                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrTableCell75.Visible = False
                    XrTableCell77.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRF) Then
                    XrTableCell91.Visible = False
                    XrTableCell92.Visible = False

                    XrTableCell95.Visible = False
                    XrTableCell96.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRatings And _CurrentDataLine.ShowImpressions And _CurrentDataLine.ShowRF And _CurrentDataLine.ShowCPPM) Then
                    XrTableCell105.Visible = False
                    XrTableCell106.Visible = False
                End If
            End If
        End Sub

        Private Sub GroupFooter1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter1.BeforePrint
            If (_CurrentDataLine IsNot Nothing) Then
                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    XrLabel31.Visible = False
                    XrLabel32.Visible = False
                End If
            End If
        End Sub

        Private Sub PageHeader_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint
            If (_CurrentDataLine IsNot Nothing) Then
                XrTableRow5.CanShrink = True
                XrTableRow5.Visible = Not (_CurrentDataLine.ClientName = _CurrentDataLine.DivisionName)

                If Not (_CurrentDataLine.ShowRatings And _CurrentDataLine.ShowImpressions And _CurrentDataLine.ShowRF And _CurrentDataLine.ShowCPPM) Then
                    XrTableCell17.Visible = False
                    XrTableCell18.Visible = False
                End If
            End If
        End Sub

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
        Private Sub MediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

#End Region

    End Class

End Namespace
