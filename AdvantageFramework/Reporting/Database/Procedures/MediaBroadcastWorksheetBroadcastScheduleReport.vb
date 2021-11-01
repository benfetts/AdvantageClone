Namespace Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport

    <HideModuleName()>
    Public Module Methods

#Region " Constants "
        Const NETCOST = 85
        Const GROSSCOST = 118

        Const NETCOST_DETAIL = 85000
        Const GROSSCOST_DETAIL = 117647
#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

#End Region

#Region " Methods "

#Region "       Load Detail"

        Public Function LoadReachFreqDetails(ByVal DbContext As Database.DbContext _
                                    , ByVal MarketWorksheetIdList As Generic.List(Of Integer) _
                                    , ByVal BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal UsePrimaryDemoList As Generic.List(Of Boolean) _
                                    , ByVal VendorCodeList As String) _
                                   As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ReachFreqDetail)

            Dim SqlParameterMarketWorksheetID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarketWorksheetID = IntegerListToSqlParameter("@MEDIA_BROADCAST_WORKSHEET_MARKET_ID", MarketWorksheetIdList)

            Dim SqlParameterBroadcastStartYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastStartYearMonth = NullableIntegerListToOneSqlParameter("@START_YEAR_MONTH", BroadcastStartYearMonthList)

            Dim SqlParameterBroadcastEndYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastEndYearMonth = NullableIntegerListToOneSqlParameter("@END_YEAR_MONTH", BroadcastEndYearMonthList)

            Dim SqlParameterUsePrimaryDemo As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterUsePrimaryDemo = BooleanListToOneSqlParameter("@USE_PRIMARY_DEMO", UsePrimaryDemoList)

            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@VENDOR_FILTER", SqlDbType.VarChar)
            SqlParameterVendorCodeList.Value = VendorCodeList

            LoadReachFreqDetails = DbContext.Database.SqlQuery(Of Database.Classes.ReachFreqDetail) _
                                     ("EXEC dbo.advsp_media_broadcast_loadreachfreq_details @MEDIA_BROADCAST_WORKSHEET_MARKET_ID, @START_YEAR_MONTH , @END_YEAR_MONTH, @USE_PRIMARY_DEMO, @VENDOR_FILTER" _
                                     , SqlParameterMarketWorksheetID, SqlParameterBroadcastStartYearMonth, SqlParameterBroadcastEndYearMonth _
                                     , SqlParameterUsePrimaryDemo, SqlParameterVendorCodeList)
        End Function

        Public Function LoadBroadcastSummaryReport(ByVal DbContext As Database.DbContext _
                                    , ByVal MarketWorksheetIdList As Generic.List(Of Integer) _
                                    , ByVal BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal UsePrimaryDemoList As Generic.List(Of Boolean) _
                                    , ByVal VendorCodeList As String) _
                                   As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastSummaryReport)

            Dim SqlParameterMarketWorksheetID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarketWorksheetID = IntegerListToSqlParameter("@MEDIA_BROADCAST_WORKSHEET_MARKET_ID", MarketWorksheetIdList)

            Dim SqlParameterBroadcastStartYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastStartYearMonth = NullableIntegerListToOneSqlParameter("@START_YEAR_MONTH", BroadcastStartYearMonthList)

            Dim SqlParameterBroadcastEndYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastEndYearMonth = NullableIntegerListToOneSqlParameter("@END_YEAR_MONTH", BroadcastEndYearMonthList)

            Dim SqlParameterUsePrimaryDemo As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterUsePrimaryDemo = BooleanListToOneSqlParameter("@USE_PRIMARY_DEMO", UsePrimaryDemoList)

            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@VENDOR_FILTER", SqlDbType.VarChar)
            SqlParameterVendorCodeList.Value = VendorCodeList

            LoadBroadcastSummaryReport = DbContext.Database.SqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastSummaryReport) _
                                     ("EXEC dbo.advsp_media_broadcast_budget_report @MEDIA_BROADCAST_WORKSHEET_MARKET_ID, @START_YEAR_MONTH , @END_YEAR_MONTH, @USE_PRIMARY_DEMO, @VENDOR_FILTER" _
                                     , SqlParameterMarketWorksheetID, SqlParameterBroadcastStartYearMonth, SqlParameterBroadcastEndYearMonth _
                                     , SqlParameterUsePrimaryDemo, SqlParameterVendorCodeList)
        End Function

        Public Function LoadReachFreqWeekDetails(ByVal DbContext As Database.DbContext _
                                    , ByVal MarketWorksheetIdList As Generic.List(Of Integer) _
                                    , ByVal BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal UsePrimaryDemoList As Generic.List(Of Boolean) _
                                    , ByVal VendorCodeList As String) _
                                   As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ReachFreqDetail)

            Dim SqlParameterMarketWorksheetID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarketWorksheetID = IntegerListToSqlParameter("@MEDIA_BROADCAST_WORKSHEET_MARKET_ID", MarketWorksheetIdList)

            Dim SqlParameterBroadcastStartYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastStartYearMonth = NullableIntegerListToOneSqlParameter("@START_YEAR_MONTH", BroadcastStartYearMonthList)

            Dim SqlParameterBroadcastEndYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastEndYearMonth = NullableIntegerListToOneSqlParameter("@END_YEAR_MONTH", BroadcastEndYearMonthList)

            Dim SqlParameterUsePrimaryDemo As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterUsePrimaryDemo = BooleanListToOneSqlParameter("@USE_PRIMARY_DEMO", UsePrimaryDemoList)

            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@VENDOR_FILTER", SqlDbType.VarChar)
            SqlParameterVendorCodeList.Value = VendorCodeList

            LoadReachFreqWeekDetails = DbContext.Database.SqlQuery(Of Database.Classes.ReachFreqDetail) _
                                     ("EXEC dbo.advsp_media_broadcast_loadreachfreq_weekly_details @MEDIA_BROADCAST_WORKSHEET_MARKET_ID, @START_YEAR_MONTH , @END_YEAR_MONTH, @USE_PRIMARY_DEMO, @VENDOR_FILTER" _
                                     , SqlParameterMarketWorksheetID, SqlParameterBroadcastStartYearMonth, SqlParameterBroadcastEndYearMonth _
                                     , SqlParameterUsePrimaryDemo, SqlParameterVendorCodeList)
        End Function


        Public Function LoadDetail(ByVal DbContext As Database.DbContext _
                                    , ByVal MarketWorksheetIdList As Generic.List(Of Integer) _
                                    , ByVal BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal UsePrimaryDemoList As Generic.List(Of Boolean) _
                                    , ByVal HeaderLine As String _
                                    , ByVal VendorCodeList As String _
                                    , ByVal LocationName As String _
                                    , ByVal UseNetCost As Boolean _
                                    , ByVal WorksheetIsGross As Boolean) _
                                   As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail)


            Dim SqlParameterMarketWorksheetID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarketWorksheetID = IntegerListToSqlParameter("@MEDIA_BROADCAST_WORKSHEET_MARKET_ID", MarketWorksheetIdList)

            Dim SqlParameterBroadcastStartYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastStartYearMonth = NullableIntegerListToOneSqlParameter("@START_YEAR_MONTH", BroadcastStartYearMonthList)

            Dim SqlParameterBroadcastEndYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastEndYearMonth = NullableIntegerListToOneSqlParameter("@END_YEAR_MONTH", BroadcastEndYearMonthList)

            Dim SqlParameterUsePrimaryDemo As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterUsePrimaryDemo = BooleanListToOneSqlParameter("@USE_PRIMARY_DEMO", UsePrimaryDemoList)

            Dim SqlParameterHeaderLine As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterHeaderLine = New System.Data.SqlClient.SqlParameter("@HEADER", SqlDbType.VarChar)
            SqlParameterHeaderLine.Value = HeaderLine

            Dim SqlParameterLocation As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterLocation = New System.Data.SqlClient.SqlParameter("@LOCATION_NAME", SqlDbType.VarChar)
            SqlParameterLocation.Value = LocationName

            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@VENDOR_FILTER", SqlDbType.VarChar)
            SqlParameterVendorCodeList.Value = VendorCodeList

            Dim SqlParameterNetCost As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterNetCost = New System.Data.SqlClient.SqlParameter("@NET_COST_INT", SqlDbType.Int)
            If (UseNetCost) Then
                If WorksheetIsGross Then
                    SqlParameterNetCost.Value = NETCOST_DETAIL
                Else
                    SqlParameterNetCost.Value = GROSSCOST_DETAIL
                End If
            Else
                SqlParameterNetCost.Value = 100000
            End If

            Try
                LoadDetail = DbContext.Database.SqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail) _
                            ("EXEC dbo.advsp_media_broadcast_schedule_report_detail @MEDIA_BROADCAST_WORKSHEET_MARKET_ID , @START_YEAR_MONTH , @END_YEAR_MONTH , @USE_PRIMARY_DEMO , @HEADER , @LOCATION_NAME , @VENDOR_FILTER, @NET_COST_INT" _
                                , SqlParameterMarketWorksheetID, SqlParameterBroadcastStartYearMonth, SqlParameterBroadcastEndYearMonth _
                                , SqlParameterUsePrimaryDemo, SqlParameterHeaderLine, SqlParameterLocation, SqlParameterVendorCodeList, SqlParameterNetCost)

            Catch ex As Exception
                LoadDetail = Nothing
            End Try

        End Function

        Public Function LoadReachFreqDetailsWithExactDates(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal MarketWorksheetIdList As Generic.List(Of Integer),
                                                           ByVal StartDate As Date,
                                                           ByVal EndDate As Date,
                                                           ByVal UsePrimaryDemoList As Generic.List(Of Boolean),
                                                           ByVal VendorCodeList As String) As Generic.List(Of Database.Classes.ReachFreqDetail)

            Dim SqlParameterMarketWorksheetID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastStartYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastEndYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUsePrimaryDemo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameteExactStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameteExactEndDate As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterMarketWorksheetID = IntegerListToSqlParameter("@MEDIA_BROADCAST_WORKSHEET_MARKET_ID", MarketWorksheetIdList)

            SqlParameteExactStartDate = New System.Data.SqlClient.SqlParameter("@EXACT_START_DATE", SqlDbType.SmallDateTime)
            SqlParameteExactStartDate.Value = StartDate

            SqlParameteExactEndDate = New System.Data.SqlClient.SqlParameter("@EXACT_END_DATE", SqlDbType.SmallDateTime)
            SqlParameteExactEndDate.Value = EndDate

            SqlParameterUsePrimaryDemo = BooleanListToOneSqlParameter("@USE_PRIMARY_DEMO", UsePrimaryDemoList)

            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@VENDOR_FILTER", SqlDbType.VarChar)
            SqlParameterVendorCodeList.Value = VendorCodeList


            SqlParameterBroadcastStartYearMonth = New System.Data.SqlClient.SqlParameter("@START_YEAR_MONTH", SqlDbType.VarChar)
            SqlParameterBroadcastStartYearMonth.Value = System.DBNull.Value

            SqlParameterBroadcastEndYearMonth = New System.Data.SqlClient.SqlParameter("@END_YEAR_MONTH", SqlDbType.VarChar)
            SqlParameterBroadcastEndYearMonth.Value = System.DBNull.Value

            LoadReachFreqDetailsWithExactDates = DbContext.Database.SqlQuery(Of Database.Classes.ReachFreqDetail)("EXEC dbo.advsp_media_broadcast_loadreachfreq_details @MEDIA_BROADCAST_WORKSHEET_MARKET_ID, @START_YEAR_MONTH, @END_YEAR_MONTH, @USE_PRIMARY_DEMO, @VENDOR_FILTER, @EXACT_START_DATE, @EXACT_END_DATE",
                                      SqlParameterMarketWorksheetID, SqlParameterBroadcastStartYearMonth, SqlParameterBroadcastEndYearMonth, SqlParameterUsePrimaryDemo, SqlParameterVendorCodeList, SqlParameteExactStartDate, SqlParameteExactEndDate).ToList

        End Function

#End Region


#Region "       MarketSummary"

        Public Function LoadMarketSummary(ByVal DbContext As Database.DbContext _
                                    , ByVal MarketWorksheetIdList As Generic.List(Of Integer) _
                                    , ByVal BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal UsePrimaryDemoList As Generic.List(Of Boolean) _
                                    , ByVal HeaderLine As String _
                                    , ByVal VendorCodeList As String _
                                    , ByVal LocationName As String _
                                    , ByVal UseNetCost As Boolean _
                                    , ByVal WorksheetIsGross As Boolean) _
                                   As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary)

            Dim SqlParameterMarketWorksheetID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarketWorksheetID = IntegerListToSqlParameter("@MEDIA_BROADCAST_WORKSHEET_MARKET_ID", MarketWorksheetIdList)

            Dim SqlParameterBroadcastStartYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastStartYearMonth = NullableIntegerListToOneSqlParameter("@START_YEAR_MONTH", BroadcastStartYearMonthList)

            Dim SqlParameterBroadcastEndYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastEndYearMonth = NullableIntegerListToOneSqlParameter("@END_YEAR_MONTH", BroadcastEndYearMonthList)

            Dim SqlParameterUsePrimaryDemo As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterUsePrimaryDemo = BooleanListToOneSqlParameter("@USE_PRIMARY_DEMO", UsePrimaryDemoList)

            Dim SqlParameterHeaderLine As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterHeaderLine = New System.Data.SqlClient.SqlParameter("@HEADER", SqlDbType.VarChar)
            SqlParameterHeaderLine.Value = HeaderLine

            Dim SqlParameterLocation As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterLocation = New System.Data.SqlClient.SqlParameter("@LOCATION_NAME", SqlDbType.VarChar)
            SqlParameterLocation.Value = LocationName

            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@VENDOR_FILTER", SqlDbType.VarChar)
            SqlParameterVendorCodeList.Value = VendorCodeList

            Dim SqlParameterNetCost As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterNetCost = New System.Data.SqlClient.SqlParameter("@NET_COST_INT", SqlDbType.Int)
            If (UseNetCost) Then
                If WorksheetIsGross Then
                    SqlParameterNetCost.Value = NETCOST
                Else
                    SqlParameterNetCost.Value = GROSSCOST
                End If
            Else
                SqlParameterNetCost.Value = 100
            End If

            LoadMarketSummary = DbContext.Database.SqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleMarketSummary) _
                                        ("EXEC dbo.advsp_media_broadcast_schedule_report_summary_market @MEDIA_BROADCAST_WORKSHEET_MARKET_ID, @START_YEAR_MONTH , @END_YEAR_MONTH, @USE_PRIMARY_DEMO, @HEADER , @LOCATION_NAME , @VENDOR_FILTER, @NET_COST_INT" _
                                        , SqlParameterMarketWorksheetID, SqlParameterBroadcastStartYearMonth, SqlParameterBroadcastEndYearMonth _
                                        , SqlParameterUsePrimaryDemo, SqlParameterHeaderLine, SqlParameterLocation, SqlParameterVendorCodeList, SqlParameterNetCost)

        End Function

#End Region

#Region "       StationSystemSummary"

        Public Function LoadStationSystemSummary(ByVal DbContext As Database.DbContext _
                                    , ByVal MarketWorksheetIdList As Generic.List(Of Integer) _
                                    , ByVal BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal UsePrimaryDemoList As Generic.List(Of Boolean) _
                                    , ByVal HeaderLine As String _
                                    , ByVal VendorCodeList As String _
                                    , ByVal LocationName As String _
                                    , ByVal UseNetCost As Boolean _
                                    , ByVal WorksheetIsGross As Boolean) _
                                   As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary)

            Dim SqlParameterMarketWorksheetID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarketWorksheetID = IntegerListToSqlParameter("@MEDIA_BROADCAST_WORKSHEET_MARKET_ID", MarketWorksheetIdList)

            Dim SqlParameterBroadcastStartYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastStartYearMonth = NullableIntegerListToOneSqlParameter("@START_YEAR_MONTH", BroadcastStartYearMonthList)

            Dim SqlParameterBroadcastEndYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastEndYearMonth = NullableIntegerListToOneSqlParameter("@END_YEAR_MONTH", BroadcastEndYearMonthList)

            Dim SqlParameterUsePrimaryDemo As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterUsePrimaryDemo = BooleanListToOneSqlParameter("@USE_PRIMARY_DEMO", UsePrimaryDemoList)

            Dim SqlParameterHeaderLine As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterHeaderLine = New System.Data.SqlClient.SqlParameter("@HEADER", SqlDbType.VarChar)
            SqlParameterHeaderLine.Value = HeaderLine

            Dim SqlParameterLocation As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterLocation = New System.Data.SqlClient.SqlParameter("@LOCATION_NAME", SqlDbType.VarChar)
            SqlParameterLocation.Value = LocationName

            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@VENDOR_FILTER", SqlDbType.VarChar)
            SqlParameterVendorCodeList.Value = VendorCodeList

            Dim SqlParameterNetCost As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterNetCost = New System.Data.SqlClient.SqlParameter("@NET_COST_INT", SqlDbType.Int)
            If (UseNetCost) Then
                If WorksheetIsGross Then
                    SqlParameterNetCost.Value = NETCOST
                Else
                    SqlParameterNetCost.Value = GROSSCOST
                End If
            Else
                SqlParameterNetCost.Value = 100
            End If

            LoadStationSystemSummary = DbContext.Database.SqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleStationSummary) _
                                            ("EXEC dbo.advsp_media_broadcast_schedule_report_summary_station_system   @MEDIA_BROADCAST_WORKSHEET_MARKET_ID, @START_YEAR_MONTH , @END_YEAR_MONTH, @USE_PRIMARY_DEMO,@HEADER , @LOCATION_NAME , @VENDOR_FILTER, @NET_COST_INT" _
                                                , SqlParameterMarketWorksheetID, SqlParameterBroadcastStartYearMonth, SqlParameterBroadcastEndYearMonth _
                                                , SqlParameterUsePrimaryDemo, SqlParameterHeaderLine, SqlParameterLocation, SqlParameterVendorCodeList, SqlParameterNetCost)

        End Function

#End Region

#Region "       WeeklySummary"

        Public Function LoadWeeklySummary(ByVal DbContext As Database.DbContext _
                                    , ByVal MarketWorksheetIdList As Generic.List(Of Integer) _
                                    , ByVal BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) _
                                    , ByVal UsePrimaryDemoList As Generic.List(Of Boolean) _
                                    , ByVal HeaderLine As String _
                                    , ByVal VendorCodeList As String _
                                    , ByVal LocationName As String _
                                    , ByVal UseNetCost As Boolean _
                                    , ByVal WorksheetIsGross As Boolean) _
                                   As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary)

            Dim SqlParameterMarketWorksheetID As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterMarketWorksheetID = IntegerListToSqlParameter("@MEDIA_BROADCAST_WORKSHEET_MARKET_ID", MarketWorksheetIdList)

            Dim SqlParameterBroadcastStartYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastStartYearMonth = NullableIntegerListToOneSqlParameter("@START_YEAR_MONTH", BroadcastStartYearMonthList)

            Dim SqlParameterBroadcastEndYearMonth As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterBroadcastEndYearMonth = NullableIntegerListToOneSqlParameter("@END_YEAR_MONTH", BroadcastEndYearMonthList)

            Dim SqlParameterUsePrimaryDemo As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterUsePrimaryDemo = BooleanListToOneSqlParameter("@USE_PRIMARY_DEMO", UsePrimaryDemoList)

            Dim SqlParameterHeaderLine As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterHeaderLine = New System.Data.SqlClient.SqlParameter("@HEADER", SqlDbType.VarChar)
            SqlParameterHeaderLine.Value = HeaderLine

            Dim SqlParameterLocation As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterLocation = New System.Data.SqlClient.SqlParameter("@LOCATION_NAME", SqlDbType.VarChar)
            SqlParameterLocation.Value = LocationName

            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@VENDOR_FILTER", SqlDbType.VarChar)
            SqlParameterVendorCodeList.Value = VendorCodeList

            Dim SqlParameterNetCost As System.Data.SqlClient.SqlParameter = Nothing
            SqlParameterNetCost = New System.Data.SqlClient.SqlParameter("@NET_COST_INT", SqlDbType.Int)
            If (UseNetCost) Then
                If WorksheetIsGross Then
                    SqlParameterNetCost.Value = NETCOST
                Else
                    SqlParameterNetCost.Value = GROSSCOST
                End If
            Else
                SqlParameterNetCost.Value = 100
            End If

            LoadWeeklySummary = DbContext.Database.SqlQuery(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary) _
                                    ("EXEC dbo.advsp_media_broadcast_schedule_report_summary_weekly  @MEDIA_BROADCAST_WORKSHEET_MARKET_ID, @START_YEAR_MONTH , @END_YEAR_MONTH, @USE_PRIMARY_DEMO, @HEADER , @LOCATION_NAME , @VENDOR_FILTER, @NET_COST_INT" _
                                        , SqlParameterMarketWorksheetID, SqlParameterBroadcastStartYearMonth, SqlParameterBroadcastEndYearMonth _
                                        , SqlParameterUsePrimaryDemo, SqlParameterHeaderLine, SqlParameterLocation, SqlParameterVendorCodeList, SqlParameterNetCost)

        End Function

        Private Function IntegerListToSqlParameter(ByVal ParamName As String, IntegerListElements As Generic.List(Of Integer)) As System.Data.SqlClient.SqlParameter

            Dim IntegerSqlParameter As System.Data.SqlClient.SqlParameter

            IntegerSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (IntegerListElements Is Nothing) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            ElseIf (IntegerListElements.Count = 0) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            Else
                Dim SqlParamIntegerList As Generic.List(Of String) = New List(Of String)

                For Each IntegerElement In IntegerListElements
                    SqlParamIntegerList.Add(IntegerElement)
                Next

                IntegerSqlParameter.Value = Join(SqlParamIntegerList.ToArray, ",")
            End If
            Return IntegerSqlParameter

        End Function

        Private Function NullableIntegerListToSqlParameter(ByVal ParamName As String, IntegerListElements As Generic.List(Of Nullable(Of Integer))) As System.Data.SqlClient.SqlParameter

            Dim IntegerSqlParameter As System.Data.SqlClient.SqlParameter

            IntegerSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (IntegerListElements Is Nothing) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            ElseIf (IntegerListElements.Count = 0) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            Else
                Dim SqlParamIntegerList As Generic.List(Of String) = New List(Of String)

                For Each IntegerElement In IntegerListElements
                    If (IntegerElement.HasValue) Then
                        SqlParamIntegerList.Add(IntegerElement.Value)
                    Else
                        SqlParamIntegerList.Add("")
                    End If
                Next

                IntegerSqlParameter.Value = Join(SqlParamIntegerList.ToArray, ",")
            End If
            Return IntegerSqlParameter

        End Function

        Private Function NullableIntegerListToOneSqlParameter(ByVal ParamName As String, IntegerListElements As Generic.List(Of Nullable(Of Integer))) As System.Data.SqlClient.SqlParameter

            Dim IntegerSqlParameter As System.Data.SqlClient.SqlParameter

            IntegerSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (IntegerListElements Is Nothing) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            ElseIf (IntegerListElements.Count = 0) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            Else
                IntegerSqlParameter.Value = IntegerListElements.First.ToString
            End If
            Return IntegerSqlParameter

        End Function

        Private Function BooleanListToSqlParameter(ByVal ParamName As String, BooleanListElements As Generic.List(Of Boolean)) As System.Data.SqlClient.SqlParameter

            Dim BooleanSqlParameter As System.Data.SqlClient.SqlParameter

            BooleanSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (BooleanListElements Is Nothing) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            ElseIf (BooleanListElements.Count = 0) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            Else
                Dim SqlParamBooleanList As Generic.List(Of String) = New List(Of String)

                For Each BooleanElement In BooleanListElements
                    If (BooleanElement = True) Then
                        SqlParamBooleanList.Add("1")
                    Else
                        SqlParamBooleanList.Add("0")
                    End If

                Next

                BooleanSqlParameter.Value = Join(SqlParamBooleanList.ToArray, ",")
            End If
            Return BooleanSqlParameter

        End Function

        Private Function BooleanListToOneSqlParameter(ByVal ParamName As String, BooleanListElements As Generic.List(Of Boolean)) As System.Data.SqlClient.SqlParameter

            Dim BooleanSqlParameter As System.Data.SqlClient.SqlParameter

            BooleanSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (BooleanListElements Is Nothing) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            ElseIf (BooleanListElements.Count = 0) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            Else
                BooleanSqlParameter.Value = IIf(BooleanListElements.First = True, "1", "0")
            End If
            Return BooleanSqlParameter

        End Function
#End Region

#End Region
    End Module

End Namespace
