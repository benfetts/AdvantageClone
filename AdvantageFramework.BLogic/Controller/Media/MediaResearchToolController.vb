Namespace Controller.Media

    Public Class MediaResearchToolController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "


#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function LoadAudienceMetricsCriteria() As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel

            Dim MediaResearchToolViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel = Nothing

            MediaResearchToolViewModel = New AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel

            MediaResearchToolViewModel.MediaDemographicTVList = New Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)
            MediaResearchToolViewModel.NationalMediaDemographicTVList = New Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)
            MediaResearchToolViewModel.RadioMediaDemographicList = New Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    MediaResearchToolViewModel.MediaDemographicTVList.AddRange(From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaDemographic).ToList
                                                                               Where Entity.Type = "T"
                                                                               Select New AdvantageFramework.Database.Classes.MediaDemographic(Entity))

                    MediaResearchToolViewModel.TVMarketList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Market)
                                                               Where Entity.NielsenTVCode IsNot Nothing AndAlso
                                                                 Entity.NielsenTVCode <> ""
                                                               Select Entity).ToList

                    MediaResearchToolViewModel.NationalBroadcastTypeList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.BroadcastType)
                                                                            Where Entity.ID = AdvantageFramework.Nielsen.Database.Entities.BroadcastTypeID.NetworkTV
                                                                            Select Entity).ToList

                    MediaResearchToolViewModel.NationalRatingsServiceList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RatingsService)
                                                                             Where Entity.ID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen
                                                                             Select Entity).ToList

                    MediaResearchToolViewModel.NationalMediaMarketBreakList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.MediaMarketBreak.Load(NielsenDbContext)
                                                                               Where Entity.BroadcastTypeID = AdvantageFramework.Nielsen.Database.Entities.BroadcastTypeID.NetworkTV AndAlso
                                                                                     Entity.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen
                                                                               Select Entity).ToList

                    MediaResearchToolViewModel.NationalMediaDemographicTVList.AddRange(From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaDemographic).ToList
                                                                                       Where Entity.Type = "N"
                                                                                       Select New AdvantageFramework.Database.Classes.MediaDemographic(Entity))

                    MediaResearchToolViewModel.NielsenDataStreamDataTable = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.NielsenDataStream)).ToList
                                                                             Select New AdvantageFramework.DTO.ComboBoxItem(EnumObject)).ToList

                    MediaResearchToolViewModel.NielsenServiceDataTable = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.NielsenService)).ToList
                                                                          Select New AdvantageFramework.DTO.ComboBoxItem(EnumObject)).ToList

                    MediaResearchToolViewModel.NielsenSampleTypeDataTable = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.NielsenSampleType)).ToList
                                                                             Select New AdvantageFramework.DTO.ComboBoxItem(EnumObject)).ToList

                    MediaResearchToolViewModel.MonthList = (From AbbreviatedMonth In [Enum].GetValues(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))
                                                            Select New AdvantageFramework.DTO.ComboBoxItem(CType(AbbreviatedMonth, AdvantageFramework.DateUtilities.AbbreviatedMonths))).ToList

                    MediaResearchToolViewModel.NationalNielsenTimeTypeDataTable = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.NielsenTimeType)).ToList
                                                                                   Select New AdvantageFramework.DTO.ComboBoxItem(EnumObject)).ToList

                    MediaResearchToolViewModel.NielsenNationalDataStreamDataTable = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.NielsenNationalDataStream)).ToList
                                                                                     Select New AdvantageFramework.DTO.ComboBoxItem(EnumObject)).ToList

                    'radio
                    MediaResearchToolViewModel.NielsenRadioMarketList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioMarket.Load(NielsenDbContext).ToList

                    MediaResearchToolViewModel.NielsenRadioPeriodList = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod)

                    MediaResearchToolViewModel.NielsenRadioGeoIndicatorDataTable = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.NielsenRadioGeoIndicator))
                                                                                    Select Entity.Code,
                                                                                           [Description] = Entity.Description).ToList

                    MediaResearchToolViewModel.NielsenRadioStationList = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)

                    MediaResearchToolViewModel.RadioMediaDemographicList.AddRange(From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaDemographic).ToList
                                                                                  Where Entity.Type = "R"
                                                                                  Select New AdvantageFramework.Database.Classes.MediaDemographic(Entity))

                End Using

            End Using

            LoadAudienceMetricsCriteria = MediaResearchToolViewModel

        End Function
        Public Sub RefreshAudienceMetricsResults(MediaResearchToolViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel,
                                                 MarketCode As String, Station As Integer, Stream As String, Service As String, SampleType As String,
                                                 BookMonth As Short, BookYear As Short, StartDate As Date, EndDate As Date, StartTime As Short, EndTime As Short,
                                                 Sun As Boolean, Mon As Boolean, Tue As Boolean, Wed As Boolean, Thu As Boolean, Fri As Boolean, Sat As Boolean,
                                                 AdjustMinutes As Short,
                                                 SelectedMediaDemographics As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic))

            Dim SqlParameterNielsenMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStationCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStream As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBookMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBookYear As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSun As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMon As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTue As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterWed As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterThu As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFri As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSat As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAdjustMinutes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectedMediaDemographicIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoDetailType As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaDemographicIDs As IEnumerable(Of Integer) = Nothing

            MediaDemographicIDs = (From MD In SelectedMediaDemographics
                                   Select MD.MediaDemographicID).ToArray

            SqlParameterStationCode = New System.Data.SqlClient.SqlParameter("@STATION_CODE", SqlDbType.Int)
            SqlParameterStream = New System.Data.SqlClient.SqlParameter("@STREAM", SqlDbType.Char)
            SqlParameterBookMonth = New System.Data.SqlClient.SqlParameter("@BOOK_MONTH", SqlDbType.SmallInt)
            SqlParameterBookYear = New System.Data.SqlClient.SqlParameter("@BOOK_YEAR", SqlDbType.SmallInt)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            SqlParameterStartTime = New System.Data.SqlClient.SqlParameter("@START_TIME", SqlDbType.SmallInt)
            SqlParameterEndTime = New System.Data.SqlClient.SqlParameter("@END_TIME", SqlDbType.SmallInt)
            SqlParameterSun = New System.Data.SqlClient.SqlParameter("@SUN", SqlDbType.Bit)
            SqlParameterMon = New System.Data.SqlClient.SqlParameter("@MON", SqlDbType.Bit)
            SqlParameterTue = New System.Data.SqlClient.SqlParameter("@TUE", SqlDbType.Bit)
            SqlParameterWed = New System.Data.SqlClient.SqlParameter("@WED", SqlDbType.Bit)
            SqlParameterThu = New System.Data.SqlClient.SqlParameter("@THU", SqlDbType.Bit)
            SqlParameterFri = New System.Data.SqlClient.SqlParameter("@FRI", SqlDbType.Bit)
            SqlParameterSat = New System.Data.SqlClient.SqlParameter("@SAT", SqlDbType.Bit)
            SqlParameterAdjustMinutes = New System.Data.SqlClient.SqlParameter("@ADJUST_MINUTES", SqlDbType.SmallInt)
            SqlParameterSelectedMediaDemographicIDs = New System.Data.SqlClient.SqlParameter("@SelectedMediaDemographicIDs", SqlDbType.VarChar)
            SqlParameterNielsenMarketNumber = New System.Data.SqlClient.SqlParameter("@NIELSEN_MARKET_NUM", SqlDbType.Int)

            SqlParameterStationCode.Value = Station
            SqlParameterStream.Value = Stream
            SqlParameterBookMonth.Value = BookMonth
            SqlParameterBookYear.Value = BookYear
            SqlParameterStartDate.Value = StartDate
            SqlParameterEndDate.Value = EndDate
            SqlParameterStartTime.Value = StartTime
            SqlParameterEndTime.Value = EndTime
            SqlParameterSun.Value = Sun
            SqlParameterMon.Value = Mon
            SqlParameterTue.Value = Tue
            SqlParameterWed.Value = Wed
            SqlParameterThu.Value = Thu
            SqlParameterFri.Value = Fri
            SqlParameterSat.Value = Sat
            SqlParameterAdjustMinutes.Value = AdjustMinutes
            SqlParameterSelectedMediaDemographicIDs.Value = String.Join(",", MediaDemographicIDs.ToArray)

            SqlParameterMediaDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_TYPE", SqlDbType.Structured)
            SqlParameterMediaDemoType.TypeName = "MEDIA_DEMO_TYPE"

            SqlParameterMediaDemoDetailType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_DETAIL_TYPE", SqlDbType.Structured)
            SqlParameterMediaDemoDetailType.TypeName = "MEDIA_DEMO_DETAIL_TYPE"

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SqlParameterMediaDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.Load(DbContext)
                                                                                           Where MediaDemographicIDs.Contains(Entity.ID)
                                                                                           Select Entity.ID,
                                                                                                  Entity.Description).ToList)

                SqlParameterMediaDemoDetailType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographicDetail.Load(DbContext)
                                                                                                 Where MediaDemographicIDs.Contains(Entity.MediaDemographicID)
                                                                                                 Select Entity.MediaDemographicID,
                                                                                                        Entity.NielsenDemographicID).ToList)

                SqlParameterNielsenMarketNumber.Value = CInt(AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode).NielsenTVCode)

            End Using

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                MediaResearchToolViewModel.AudienceMetricList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AudienceMetric)("EXEC advsp_nielsen_audience_metrics @NIELSEN_MARKET_NUM, @STATION_CODE, @STREAM, @BOOK_MONTH, @BOOK_YEAR, @START_DATE, @END_DATE, @START_TIME, @END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @ADJUST_MINUTES, @SelectedMediaDemographicIDs, @MEDIA_DEMO_TYPE, @MEDIA_DEMO_DETAIL_TYPE",
                                            SqlParameterNielsenMarketNumber, SqlParameterStationCode, SqlParameterStream,
                                            SqlParameterBookMonth, SqlParameterBookYear, SqlParameterStartDate, SqlParameterEndDate,
                                            SqlParameterStartTime, SqlParameterEndTime, SqlParameterSun, SqlParameterMon, SqlParameterTue, SqlParameterWed, SqlParameterThu,
                                            SqlParameterFri, SqlParameterSat, SqlParameterAdjustMinutes, SqlParameterSelectedMediaDemographicIDs, SqlParameterMediaDemoType, SqlParameterMediaDemoDetailType).ToList()

            End Using

        End Sub
        Public Sub LoadStations(MediaResearchToolViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel, MarketCode As String)

            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NielsenMarketNumber As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                If Market IsNot Nothing Then

                    NielsenMarketNumber = CInt(Market.NielsenTVCode)

                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        MediaResearchToolViewModel.NielsenStationList = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.LoadByNielsenMarketNumber(NielsenDbContext, NielsenMarketNumber).ToList

                    End Using

                End If

            End Using

        End Sub
        Public Sub RefreshNationalAudienceMetricsResults(MediaResearchToolViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel,
                                                         MediaMarketBreakID As Integer, TimeType As String, Stream As String,
                                                         StartDate As Date, EndDate As Date, StartTime As Short, EndTime As Short,
                                                         Sun As Boolean, Mon As Boolean, Tue As Boolean, Wed As Boolean, Thu As Boolean, Fri As Boolean, Sat As Boolean, GroupBy As Integer,
                                                         SelectedMediaDemographics As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic))

            Dim SqlParameterMediaMarketBreakID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTimeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStream As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSun As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMon As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTue As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterWed As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterThu As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFri As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSat As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGroupBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectedMediaDemographicIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaDemographicIDs As IEnumerable(Of Integer) = Nothing

            MediaDemographicIDs = (From MD In SelectedMediaDemographics
                                   Select MD.MediaDemographicID).ToArray

            SqlParameterMediaMarketBreakID = New System.Data.SqlClient.SqlParameter("@MEDIA_MARKET_BREAK_ID", SqlDbType.Int)
            SqlParameterTimeType = New System.Data.SqlClient.SqlParameter("@TIME_TYPE", SqlDbType.Char)
            SqlParameterStream = New System.Data.SqlClient.SqlParameter("@STREAM", SqlDbType.Char)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            SqlParameterStartTime = New System.Data.SqlClient.SqlParameter("@START_TIME", SqlDbType.SmallInt)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            SqlParameterEndTime = New System.Data.SqlClient.SqlParameter("@END_TIME", SqlDbType.SmallInt)
            SqlParameterSun = New System.Data.SqlClient.SqlParameter("@SUN", SqlDbType.Bit)
            SqlParameterMon = New System.Data.SqlClient.SqlParameter("@MON", SqlDbType.Bit)
            SqlParameterTue = New System.Data.SqlClient.SqlParameter("@TUE", SqlDbType.Bit)
            SqlParameterWed = New System.Data.SqlClient.SqlParameter("@WED", SqlDbType.Bit)
            SqlParameterThu = New System.Data.SqlClient.SqlParameter("@THU", SqlDbType.Bit)
            SqlParameterFri = New System.Data.SqlClient.SqlParameter("@FRI", SqlDbType.Bit)
            SqlParameterSat = New System.Data.SqlClient.SqlParameter("@SAT", SqlDbType.Bit)
            SqlParameterGroupBy = New System.Data.SqlClient.SqlParameter("@GROUP_BY", SqlDbType.Int)
            SqlParameterSelectedMediaDemographicIDs = New System.Data.SqlClient.SqlParameter("@SelectedMediaDemographicIDs", SqlDbType.VarChar)

            SqlParameterMediaMarketBreakID.Value = MediaMarketBreakID
            SqlParameterTimeType.Value = TimeType
            SqlParameterStream.Value = Stream

            SqlParameterStartDate.Value = StartDate
            SqlParameterStartTime.Value = StartTime
            SqlParameterEndDate.Value = EndDate
            SqlParameterEndTime.Value = EndTime

            SqlParameterSun.Value = Sun
            SqlParameterMon.Value = Mon
            SqlParameterTue.Value = Tue
            SqlParameterWed.Value = Wed
            SqlParameterThu.Value = Thu
            SqlParameterFri.Value = Fri
            SqlParameterSat.Value = Sat
            SqlParameterGroupBy.Value = GroupBy
            SqlParameterSelectedMediaDemographicIDs.Value = String.Join(",", MediaDemographicIDs.ToArray)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaResearchToolViewModel.NationalAudienceMetricList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.NationalAudienceMetric)("EXEC advsp_nielsen_national_audience_metrics @MEDIA_MARKET_BREAK_ID, @TIME_TYPE, @STREAM, @START_DATE, @START_TIME, @END_DATE, @END_TIME, @SUN, @MON, @TUE, @WED, @THU, @FRI, @SAT, @GROUP_BY, @SelectedMediaDemographicIDs",
                                                                SqlParameterMediaMarketBreakID, SqlParameterTimeType, SqlParameterStream, SqlParameterStartDate, SqlParameterStartTime,
                                                                SqlParameterEndDate, SqlParameterEndTime, SqlParameterSun, SqlParameterMon, SqlParameterTue, SqlParameterWed, SqlParameterThu,
                                                                SqlParameterFri, SqlParameterSat, SqlParameterGroupBy, SqlParameterSelectedMediaDemographicIDs).ToList()

            End Using

        End Sub
        Public Sub RefreshRadioAudienceMetricsResults(MediaResearchToolViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel,
                                                      MarketNumber As Integer, PeriodID As Integer, GeoIndicator As Short, StationComboID As Integer,
                                                      SelectedMediaDemographics As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic),
                                                      Sunday As Boolean, Monday As Boolean, Tuesday As Boolean, Wednesday As Boolean, Thursday As Boolean, Friday As Boolean, Saturday As Boolean)

            'objects
            Dim SqlParameterMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPeriodID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGeoIndicator As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStationComboID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectedMediaDemographicIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotTVResearchDaytimeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoDetailType As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaDemographicIDs As IEnumerable(Of Integer) = Nothing

            MediaDemographicIDs = (From MD In SelectedMediaDemographics
                                   Select MD.MediaDemographicID).ToArray

            SqlParameterMarketNumber = New System.Data.SqlClient.SqlParameter("@NIELSEN_RADIO_MARKET_NUMBER", SqlDbType.Int)
            SqlParameterPeriodID = New System.Data.SqlClient.SqlParameter("@NIELSEN_RADIO_PERIOD_ID", SqlDbType.Int)
            SqlParameterGeoIndicator = New System.Data.SqlClient.SqlParameter("@GEO_INDICATOR", SqlDbType.SmallInt)
            SqlParameterStationComboID = New System.Data.SqlClient.SqlParameter("@STATION_COMBO_ID", SqlDbType.Int)
            SqlParameterSelectedMediaDemographicIDs = New System.Data.SqlClient.SqlParameter("@SelectedMediaDemographicIDs", SqlDbType.VarChar)

            SqlParameterMarketNumber.Value = MarketNumber
            SqlParameterPeriodID.Value = PeriodID
            SqlParameterGeoIndicator.Value = GeoIndicator
            SqlParameterStationComboID.Value = StationComboID
            SqlParameterSelectedMediaDemographicIDs.Value = String.Join(",", MediaDemographicIDs.ToArray)

            SqlParameterMediaSpotTVResearchDaytimeType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE", SqlDbType.Structured)
            SqlParameterMediaSpotTVResearchDaytimeType.TypeName = "MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE"

            SqlParameterMediaDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_TYPE", SqlDbType.Structured)
            SqlParameterMediaDemoType.TypeName = "MEDIA_DEMO_TYPE"

            SqlParameterMediaDemoDetailType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_DETAIL_TYPE", SqlDbType.Structured)
            SqlParameterMediaDemoDetailType.TypeName = "MEDIA_DEMO_DETAIL_TYPE"

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SqlParameterMediaDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.Load(DbContext)
                                                                                           Where MediaDemographicIDs.Contains(Entity.ID)
                                                                                           Select Entity.ID,
                                                                                                  Entity.Description).ToList)

                SqlParameterMediaDemoDetailType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographicDetail.Load(DbContext)
                                                                                                 Where MediaDemographicIDs.Contains(Entity.MediaDemographicID)
                                                                                                 Select Entity.MediaDemographicID,
                                                                                                        Entity.NielsenDemographicID).ToList)

            End Using

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                MediaResearchToolViewModel.RadioWorksheetMetricList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.RadioWorksheetMetric)("EXEC advsp_nielsen_radio_audience_metrics @NIELSEN_RADIO_MARKET_NUMBER, @NIELSEN_RADIO_PERIOD_ID, @GEO_INDICATOR, @STATION_COMBO_ID, @SelectedMediaDemographicIDs, @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @MEDIA_DEMO_TYPE, @MEDIA_DEMO_DETAIL_TYPE",
                     SqlParameterMarketNumber, SqlParameterPeriodID, SqlParameterGeoIndicator, SqlParameterStationComboID,
                     SqlParameterSelectedMediaDemographicIDs, SqlParameterMediaSpotTVResearchDaytimeType, SqlParameterMediaDemoType, SqlParameterMediaDemoDetailType).ToList()

            End Using

        End Sub
        Public Sub SetNielsenBroadcastDateRange(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel, Month As Integer, Year As Integer)

            Dim NielsenTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse = Nothing

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                NielsenTVUniverse = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVUniverse.Load(NielsenDbContext)
                                     Where Entity.Month = Month AndAlso
                                           Entity.Year = Year
                                     Select Entity).FirstOrDefault

                If NielsenTVUniverse IsNot Nothing Then

                    ViewModel.NielsenBroadcastStartDate = NielsenTVUniverse.SurveyStartDate
                    ViewModel.NielsenBroadcastEndDate = NielsenTVUniverse.SurveyEndDate

                Else

                    ViewModel.NielsenBroadcastStartDate = Nothing
                    ViewModel.NielsenBroadcastEndDate = Nothing

                End If

            End Using

        End Sub
        Public Sub GetRadioDaypart(ReportType As String, ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel)

            Using DbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                ViewModel.NielsenRadioDaypartList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioDaypart.Load(DbContext).ToList

            End Using

        End Sub
        Public Sub GetRadioStationOrCombo(NielsenRadioMarketNumber As Integer, ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel)

            Using DbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                ViewModel.NielsenRadioStationList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)
                                                     Where Entity.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                                                     Select Entity).ToList

            End Using

        End Sub
        Public Sub SetSpotRadioDataByMarket(ByRef MediaResearchToolViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel, MarketNumber As Integer)

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                MediaResearchToolViewModel.NielsenRadioPeriodList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByNielsenRadioMarketNumber(NielsenDbContext, MarketNumber).ToList

                'MediaResearchToolViewModel.NielsenRadioStationList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByNielsenRadioMarketNumber(NielsenDbContext, MarketNumber).ToList

            End Using

        End Sub

#Region " Comscore "

        Private Function GetLocalTimeViewsRequest(StartDate As Date, EndDate As Date, StartTime As Date, EndTime As Date, MarketNumber As Integer, ComscoreDemoNumbers As IEnumerable(Of Integer),
                                                  StationCallLetters As IEnumerable(Of String), ByRef JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer), AsClientID As String) As String

            'objects
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JTokenWriter As Newtonsoft.Json.Linq.JTokenWriter = Nothing
            Dim Fields As IEnumerable(Of String) = Nothing
            Dim DemoCounter As Integer = 0

            Fields = {"market_no", "market_name", "network_name", "station_call_sign", "station_no", "station_name", "days_of_week", "qtr_hour", "num_hut"} ' "day", "universe", "share", "hut", "rating", "avg_aud"

            JTokenWriter = New Newtonsoft.Json.Linq.JTokenWriter()
            JTokenWriter.WriteStartObject()

            JTokenWriter.WritePropertyName("as_client_id")
            JTokenWriter.WriteValue(AsClientID)

            JTokenWriter.WritePropertyName("fields")

            JTokenWriter.WriteStartArray()

            For Each Field In Fields

                JTokenWriter.WriteValue(Field)

            Next

            For Each ComscoreDemoNumber In ComscoreDemoNumbers

                DemoCounter += 1

                JSONOrdinalComscoreDemoNumbers.Add(DemoCounter, ComscoreDemoNumber)

                'JTokenWriter.WriteStartObject()
                'JTokenWriter.WritePropertyName("field")
                'JTokenWriter.WriteValue("share")
                'JTokenWriter.WritePropertyName("demo_no")
                'JTokenWriter.WriteValue(ComscoreDemoNumber)
                'JTokenWriter.WritePropertyName("alias")
                'JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_share")
                'JTokenWriter.WriteEndObject()

                'JTokenWriter.WriteStartObject()
                'JTokenWriter.WritePropertyName("field")
                'JTokenWriter.WriteValue("hut")
                'JTokenWriter.WritePropertyName("demo_no")
                'JTokenWriter.WriteValue(ComscoreDemoNumber)
                'JTokenWriter.WritePropertyName("alias")
                'JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_hut")
                'JTokenWriter.WriteEndObject()

                'JTokenWriter.WriteStartObject()
                'JTokenWriter.WritePropertyName("field")
                'JTokenWriter.WriteValue("rating")
                'JTokenWriter.WritePropertyName("demo_no")
                'JTokenWriter.WriteValue(ComscoreDemoNumber)
                'JTokenWriter.WritePropertyName("alias")
                'JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_rating")
                'JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("num_hut")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_num_hut")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("universe")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_universe")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("avg_aud")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_avg_aud")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("meets_demo_threshold")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_demo_threshold")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("meets_high_quality_demo_threshold")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_high_quality_demo_threshold")
                JTokenWriter.WriteEndObject()

            Next

            JTokenWriter.WriteEndArray()

            'filters
            JTokenWriter.WritePropertyName("filters")

            JTokenWriter.WriteStartArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("range")
            JTokenWriter.WriteValue("day")
            JTokenWriter.WriteValue(StartDate.ToString("yyyy-MM-dd"))
            JTokenWriter.WriteValue(EndDate.ToString("yyyy-MM-dd"))
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("range")
            JTokenWriter.WriteValue("qtr_hour")
            JTokenWriter.WriteValue(StartTime.ToString("HH:mm"))
            JTokenWriter.WriteValue(EndTime.ToString("HH:mm"))
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("eq")
            JTokenWriter.WriteValue("market_no")
            JTokenWriter.WriteValue(MarketNumber)
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("in")
            JTokenWriter.WriteValue("station_call_sign")

            For Each StationCallLetter In StationCallLetters

                JTokenWriter.WriteValue(StationCallLetter)

            Next
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteEndArray()

            'group by
            JTokenWriter.WritePropertyName("group_by")

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("market_no")
            JTokenWriter.WriteValue("station_no")
            JTokenWriter.WriteValue("network_no")
            'JTokenWriter.WriteValue("day")
            JTokenWriter.WriteValue("qtr_hour")
            JTokenWriter.WriteEndArray()


            JTokenWriter.WriteEndObject()

            JObject = JTokenWriter.Token

            GetLocalTimeViewsRequest = JObject.ToString

        End Function
        Private Sub SetComscoreQuarterHours(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel)

            Dim Remainder As Integer = 0

            Remainder = ViewModel.ComscoreStartTime.Minute Mod 15

            If Remainder <> 0 Then

                ViewModel.ComscoreQuarterHourStart = ViewModel.ComscoreStartTime.AddMinutes(-Remainder)

            Else

                ViewModel.ComscoreQuarterHourStart = ViewModel.ComscoreStartTime

            End If

            Remainder = ViewModel.ComscoreEndTime.Minute Mod 15

            If Remainder <> 0 Then

                ViewModel.ComscoreQuarterHourEnd = ViewModel.ComscoreEndTime.AddMinutes(15 - Remainder)

            Else

                ViewModel.ComscoreQuarterHourEnd = ViewModel.ComscoreEndTime

            End If

        End Sub
        Private Sub AggregateMetricsByMinuteWeights(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel)

            For Each LocalTimeViewsResponse In ViewModel.ComscoreLocalTimeViewsResponseList

                LocalTimeViewsResponse.TotalMinutes = DateDiff(DateInterval.Minute, ViewModel.ComscoreStartTime, ViewModel.ComscoreEndTime)

                If CDate(LocalTimeViewsResponse.Quarterhour) < ViewModel.ComscoreStartTime Then

                    LocalTimeViewsResponse.QtrHrMinutes = 15 - DateDiff(DateInterval.Minute, CDate(LocalTimeViewsResponse.Quarterhour), ViewModel.ComscoreStartTime)

                ElseIf DateDiff(DateInterval.Minute, CDate(LocalTimeViewsResponse.Quarterhour), ViewModel.ComscoreEndTime) < 15 Then

                    LocalTimeViewsResponse.QtrHrMinutes = DateDiff(DateInterval.Minute, CDate(LocalTimeViewsResponse.Quarterhour), ViewModel.ComscoreEndTime)

                Else

                    LocalTimeViewsResponse.QtrHrMinutes = 15

                End If

            Next

            ViewModel.ComscoreLocalTimeViewList = (From Entity In ViewModel.ComscoreLocalTimeViewsResponseList
                                                   Group By MarketNumber = Entity.MarketNumber,
                                                            MarketName = Entity.MarketName,
                                                            NetworkName = Entity.NetworkName,
                                                            StationName = Entity.StationName,
                                                            Universe_01 = Entity.Universe_01,
                                                            Universe_02 = Entity.Universe_02,
                                                            Universe_03 = Entity.Universe_03,
                                                            Universe_04 = Entity.Universe_04,
                                                            Universe_05 = Entity.Universe_05,
                                                            Universe_06 = Entity.Universe_06,
                                                            Universe_07 = Entity.Universe_07,
                                                            Universe_08 = Entity.Universe_08,
                                                            Universe_09 = Entity.Universe_09,
                                                            Universe_10 = Entity.Universe_10,
                                                            Universe_11 = Entity.Universe_11,
                                                            Universe_12 = Entity.Universe_12,
                                                            Universe_13 = Entity.Universe_13,
                                                            Universe_14 = Entity.Universe_14,
                                                            Universe_15 = Entity.Universe_15,
                                                            Universe_16 = Entity.Universe_16,
                                                            Universe_17 = Entity.Universe_17,
                                                            Universe_18 = Entity.Universe_18,
                                                            Universe_19 = Entity.Universe_19,
                                                            Universe_20 = Entity.Universe_20
                                                   Into Group = Group
                                                   Select New DTO.Media.ComscoreLocalTimeView With {
                                                            .MarketNumber = MarketNumber,
                                                            .MarketName = MarketName,
                                                            .NetworkName = NetworkName,
                                                            .StationName = StationName,
                                                            .AvgAud_01 = Group.Sum(Function(G) G.AvgAud_01 * G.QuarterhourWeight),
                                                            .Universe_01 = Universe_01,
                                                            .AvgAud_02 = Group.Sum(Function(G) G.AvgAud_02 * G.QuarterhourWeight),
                                                            .Universe_02 = Universe_02,
                                                            .AvgAud_03 = Group.Sum(Function(G) G.AvgAud_03 * G.QuarterhourWeight),
                                                            .Universe_03 = Universe_03,
                                                            .AvgAud_04 = Group.Sum(Function(G) G.AvgAud_04 * G.QuarterhourWeight),
                                                            .Universe_04 = Universe_04,
                                                            .AvgAud_05 = Group.Sum(Function(G) G.AvgAud_05 * G.QuarterhourWeight),
                                                            .Universe_05 = Universe_05,
                                                            .AvgAud_06 = Group.Sum(Function(G) G.AvgAud_06 * G.QuarterhourWeight),
                                                            .Universe_06 = Universe_06,
                                                            .AvgAud_07 = Group.Sum(Function(G) G.AvgAud_07 * G.QuarterhourWeight),
                                                            .Universe_07 = Universe_07,
                                                            .AvgAud_08 = Group.Sum(Function(G) G.AvgAud_08 * G.QuarterhourWeight),
                                                            .Universe_08 = Universe_08,
                                                            .AvgAud_09 = Group.Sum(Function(G) G.AvgAud_09 * G.QuarterhourWeight),
                                                            .Universe_09 = Universe_09,
                                                            .AvgAud_10 = Group.Sum(Function(G) G.AvgAud_10 * G.QuarterhourWeight),
                                                            .Universe_10 = Universe_10,
                                                            .AvgAud_11 = Group.Sum(Function(G) G.AvgAud_11 * G.QuarterhourWeight),
                                                            .Universe_11 = Universe_11,
                                                            .AvgAud_12 = Group.Sum(Function(G) G.AvgAud_12 * G.QuarterhourWeight),
                                                            .Universe_12 = Universe_12,
                                                            .AvgAud_13 = Group.Sum(Function(G) G.AvgAud_13 * G.QuarterhourWeight),
                                                            .Universe_13 = Universe_13,
                                                            .AvgAud_14 = Group.Sum(Function(G) G.AvgAud_14 * G.QuarterhourWeight),
                                                            .Universe_14 = Universe_14,
                                                            .AvgAud_15 = Group.Sum(Function(G) G.AvgAud_15 * G.QuarterhourWeight),
                                                            .Universe_15 = Universe_15,
                                                            .AvgAud_16 = Group.Sum(Function(G) G.AvgAud_16 * G.QuarterhourWeight),
                                                            .Universe_16 = Universe_16,
                                                            .AvgAud_17 = Group.Sum(Function(G) G.AvgAud_17 * G.QuarterhourWeight),
                                                            .Universe_17 = Universe_17,
                                                            .AvgAud_18 = Group.Sum(Function(G) G.AvgAud_18 * G.QuarterhourWeight),
                                                            .Universe_18 = Universe_18,
                                                            .AvgAud_19 = Group.Sum(Function(G) G.AvgAud_19 * G.QuarterhourWeight),
                                                            .Universe_19 = Universe_19,
                                                            .AvgAud_20 = Group.Sum(Function(G) G.AvgAud_20 * G.QuarterhourWeight),
                                                            .Universe_20 = Universe_20,
                                                            .Share_01 = Group.Average(Function(G) G.Share_01),
                                                            .Share_02 = Group.Average(Function(G) G.Share_02),
                                                            .Share_03 = Group.Average(Function(G) G.Share_03),
                                                            .Share_04 = Group.Average(Function(G) G.Share_04),
                                                            .Share_05 = Group.Average(Function(G) G.Share_05),
                                                            .Share_06 = Group.Average(Function(G) G.Share_06),
                                                            .Share_07 = Group.Average(Function(G) G.Share_07),
                                                            .Share_08 = Group.Average(Function(G) G.Share_08),
                                                            .Share_09 = Group.Average(Function(G) G.Share_09),
                                                            .Share_10 = Group.Average(Function(G) G.Share_10),
                                                            .Share_11 = Group.Average(Function(G) G.Share_11),
                                                            .Share_12 = Group.Average(Function(G) G.Share_12),
                                                            .Share_13 = Group.Average(Function(G) G.Share_13),
                                                            .Share_14 = Group.Average(Function(G) G.Share_14),
                                                            .Share_15 = Group.Average(Function(G) G.Share_15),
                                                            .Share_16 = Group.Average(Function(G) G.Share_16),
                                                            .Share_17 = Group.Average(Function(G) G.Share_17),
                                                            .Share_18 = Group.Average(Function(G) G.Share_18),
                                                            .Share_19 = Group.Average(Function(G) G.Share_19),
                                                            .Share_20 = Group.Average(Function(G) G.Share_20),
                                                            .HUT_01 = Group.Average(Function(G) G.HUT_01),
                                                            .HUT_02 = Group.Average(Function(G) G.HUT_02),
                                                            .HUT_03 = Group.Average(Function(G) G.HUT_03),
                                                            .HUT_04 = Group.Average(Function(G) G.HUT_04),
                                                            .HUT_05 = Group.Average(Function(G) G.HUT_05),
                                                            .HUT_06 = Group.Average(Function(G) G.HUT_06),
                                                            .HUT_07 = Group.Average(Function(G) G.HUT_07),
                                                            .HUT_08 = Group.Average(Function(G) G.HUT_08),
                                                            .HUT_09 = Group.Average(Function(G) G.HUT_09),
                                                            .HUT_10 = Group.Average(Function(G) G.HUT_10),
                                                            .HUT_11 = Group.Average(Function(G) G.HUT_11),
                                                            .HUT_12 = Group.Average(Function(G) G.HUT_12),
                                                            .HUT_13 = Group.Average(Function(G) G.HUT_13),
                                                            .HUT_14 = Group.Average(Function(G) G.HUT_14),
                                                            .HUT_15 = Group.Average(Function(G) G.HUT_15),
                                                            .HUT_16 = Group.Average(Function(G) G.HUT_16),
                                                            .HUT_17 = Group.Average(Function(G) G.HUT_17),
                                                            .HUT_18 = Group.Average(Function(G) G.HUT_18),
                                                            .HUT_19 = Group.Average(Function(G) G.HUT_19),
                                                            .HUT_20 = Group.Average(Function(G) G.HUT_20)}).ToList

        End Sub
        Public Sub AddToSelectedComscoreTVStations(ByRef MediaResearchToolViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel,
                                                   AvailableComscoreTVStations As IEnumerable(Of AdvantageFramework.Database.Entities.ComscoreTVStation))

            If AvailableComscoreTVStations IsNot Nothing AndAlso AvailableComscoreTVStations.Count > 0 Then

                For Each ComscoreTVStation In AvailableComscoreTVStations

                    MediaResearchToolViewModel.ComscoreSelectedTVStationList.Add(ComscoreTVStation)
                    MediaResearchToolViewModel.ComscoreAvailableTVStationList.Remove(ComscoreTVStation)

                Next

            End If

        End Sub
        Public Sub RemoveFromSelectedComscoreStations(ByRef MediaResearchToolViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel,
                                                      SelectedComscoreTVStations As IEnumerable(Of AdvantageFramework.Database.Entities.ComscoreTVStation))

            If SelectedComscoreTVStations IsNot Nothing AndAlso SelectedComscoreTVStations.Count > 0 Then

                For Each ComscoreTVStation In SelectedComscoreTVStations

                    MediaResearchToolViewModel.ComscoreAvailableTVStationList.Add(ComscoreTVStation)
                    MediaResearchToolViewModel.ComscoreSelectedTVStationList.Remove(ComscoreTVStation)

                Next

            End If

        End Sub
        Public Sub LoadComscoreMarkets(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel)

            ViewModel.ComscoreMarketList.Clear()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ViewModel.ComscoreMarketList.AddRange(AdvantageFramework.Database.Procedures.Market.LoadAllActiveComscore(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList)

            End Using

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ViewModel.ComscoreClientID, ViewModel.ComscoreClientSecret, ViewModel.ComscoreAsClientID)

            End Using

        End Sub
        Public Sub LoadComscoreMediaDemographics(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel)

            ViewModel.ComscoreMediaDemographicList.Clear()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ViewModel.ComscoreMediaDemographicList.AddRange(From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaDemographic).ToList
                                                                Where Entity.Type = "T" AndAlso
                                                                      Entity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Comscore
                                                                Select New AdvantageFramework.Database.Classes.MediaDemographic(Entity))

            End Using

        End Sub
        Public Sub LoadComscoreTVStations(MarketNumber As Integer, ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel)

            ViewModel.ComscoreAvailableTVStationList.Clear()
            ViewModel.ComscoreSelectedTVStationList.Clear()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ViewModel.ComscoreAvailableTVStationList.AddRange(AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadByPrimaryMarketNumber(DbContext, MarketNumber).ToList)

            End Using

        End Sub
        Public Sub GetLocalTimeViews(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel)

            'objects
            Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
            Dim StationCallLetters As IEnumerable(Of String) = Nothing
            Dim ComscoreDemoNumbers As IEnumerable(Of Integer) = Nothing
            Dim JSONString As String = Nothing
            Dim Api As Services.ComScore.Classes.Api = Nothing
            Dim Request As Services.ComScore.Classes.Request = Nothing
            Dim Response As Services.ComScore.Classes.Response = Nothing
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JArrayColumns As Newtonsoft.Json.Linq.JArray = Nothing
            Dim Columns As List(Of String) = Nothing
            Dim JArray As Newtonsoft.Json.Linq.JArray = Nothing
            Dim LocalTimeViewsResponse As Services.ComScore.Classes.LocalTimeViewsResponse = Nothing
            Dim JsonPropertyAttribute As Newtonsoft.Json.JsonPropertyAttribute = Nothing
            Dim UnderlyingType As System.Type = Nothing
            Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing

            ViewModel.ComscoreLocalTimeViewsResponseList.Clear()

            StationCallLetters = ViewModel.ComscoreSelectedTVStationList.Select(Function(E) E.CallLetters).ToArray
            ComscoreDemoNumbers = ViewModel.ComscoreSelectedMediaDemographicList.Select(Function(E) E.ComscoreDemoNumber.Value).ToArray

            JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

            SetComscoreQuarterHours(ViewModel)

            LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews
            LocalTimeViews.EndpointPath = "/tv/v4/local_time_views"
            LocalTimeViews.Request = GetLocalTimeViewsRequest(ViewModel.ComscoreStartDate, ViewModel.ComscoreEndDate, ViewModel.ComscoreQuarterHourStart, ViewModel.ComscoreQuarterHourEnd, ViewModel.ComscoreSelectedMarketNumber, ComscoreDemoNumbers, StationCallLetters, JSONOrdinalComscoreDemoNumbers, ViewModel.ComscoreAsClientID)

            ViewModel.JSONOrdinalComscoreDemoNumbers = JSONOrdinalComscoreDemoNumbers

            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(LocalTimeViews)

            Api = New Services.ComScore.Classes.Api(New Uri("https://api.rentrak.com"), ViewModel.ComscoreClientID, ViewModel.ComscoreClientSecret, 0)

            Request = New Services.ComScore.Classes.Request(JSONString)

            Do While Request IsNot Nothing

                Response = Api.RetrievePage(Request)

                If Response IsNot Nothing AndAlso Response.Status = "success" Then

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Response.RawResponse)

                    ViewModel.ComscoreJSONRequestString = Request.RawRequest & vbCrLf & vbCrLf & "-----" & vbCrLf & vbCrLf & Response.RawResponse

                    JArrayColumns = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_columns").ToString)

                    Columns = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JArrayColumns.ToString)

                    JArray = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_rows").ToString)

                    For i As Integer = 0 To JArray.Count - 1

                        LocalTimeViewsResponse = New Services.ComScore.Classes.LocalTimeViewsResponse

                        For Each Column In Columns

                            For Each PropertyInfo In LocalTimeViewsResponse.GetType.GetProperties

                                JsonPropertyAttribute = (From A In PropertyInfo.GetCustomAttributes(False).OfType(Of Newtonsoft.Json.JsonPropertyAttribute)
                                                         Where A.PropertyName = Column).SingleOrDefault

                                If JsonPropertyAttribute IsNot Nothing Then

                                    UnderlyingType = AdvantageFramework.ClassUtilities.GetUnderlyingType(PropertyInfo.PropertyType)

                                    If UnderlyingType Is GetType(String) Then

                                        PropertyInfo.SetValue(LocalTimeViewsResponse, JArray(i).Item(Columns.IndexOf(Column)).ToString)
                                        Exit For

                                    ElseIf UnderlyingType Is GetType(Decimal) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewsResponse, CDec(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Integer) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewsResponse, CInt(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    End If

                                End If

                            Next

                        Next

                        ViewModel.ComscoreLocalTimeViewsResponseList.Add(LocalTimeViewsResponse)

                    Next

                    Request = Api.NextPageRequest(Response)

                Else

                    Request = Nothing

                End If

            Loop

            AggregateMetricsByMinuteWeights(ViewModel)

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
