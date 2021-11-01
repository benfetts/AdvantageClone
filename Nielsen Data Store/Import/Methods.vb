Namespace Import

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "

        Private Const BLANK_QUALITATIVE_CODE As String = "All"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        <System.Runtime.CompilerServices.Extension>
        Private Function ToDataTable(Of T)(EntityList As IList(Of T)) As System.Data.DataTable

            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(T))

            For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                DataTable.Columns.Add(Prop.Name, If(Nullable.GetUnderlyingType(Prop.PropertyType), Prop.PropertyType))

            Next

            For Each Entity As T In EntityList

                DataRow = DataTable.NewRow()

                For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                    DataRow(Prop.Name) = If(Prop.GetValue(Entity), DBNull.Value)

                Next

                DataTable.Rows.Add(DataRow)

            Next

            Return DataTable

        End Function
        Private Sub BulkInsertNielsenTVAudienceList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                    NielsenTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVAudiences.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenTVBookID", "NIELSEN_TV_BOOK_ID")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("AudienceDatetime", "AUDIENCE_DATETIME")
                    .ColumnMappings.Add("IsExcluded", "IS_EXCLUDED")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD_AUD")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD_AUD")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_AUD")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_AUD")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_AUD")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_AUD")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_AUD")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_AUD")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_AUD")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_AUD")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_AUD")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_AUD")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_AUD")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_AUD")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_AUD")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_AUD")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_AUD")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_AUD")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_AUD")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_AUD")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_AUD")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_AUD")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_AUD")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN_AUD")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_AUDIENCE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        'Private Sub BulkInsertNielsenTVBookList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
        '                                        NielsenTVBooks As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook))

        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NielsenTVBooks.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("ID", "NIELSEN_TV_BOOK_ID")
        '            .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
        '            .ColumnMappings.Add("Year", "YEAR")
        '            .ColumnMappings.Add("Month", "MONTH")
        '            .ColumnMappings.Add("Stream", "STREAM")
        '            .ColumnMappings.Add("StartDateTime", "START_DATETIME")
        '            .ColumnMappings.Add("EndDateTime", "END_DATETIME")
        '            .ColumnMappings.Add("MarketTimeZone", "MARKET_TIME_ZONE")
        '            .ColumnMappings.Add("MarketClassCode", "MARKET_CLASS_CODE")
        '            .ColumnMappings.Add("IsDaylightSavingsMarket", "IS_DST_MARKET")
        '            .ColumnMappings.Add("CreateDate", "CREATE_DATE")

        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NIELSEN_TV_BOOK"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        Private Sub BulkInsertNielsenTVHutputList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                  NielsenTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVHutputs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenTVBookID", "NIELSEN_TV_BOOK_ID")
                    .ColumnMappings.Add("HutputDatetime", "HUTPUT_DATETIME")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD_HUT")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD_HUT")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_HUT")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_PUT")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_PUT")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_PUT")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_PUT")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUT")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUT")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_PUT")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_PUT")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUT")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUT")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUT")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_PUT")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_PUT")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUT")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUT")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_PUT")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_PUT")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUT")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUT")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUT")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN_PUT")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_HUTPUT"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVIntabList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                 NielsenTVIntabs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVIntabs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenTVBookID", "NIELSEN_TV_BOOK_ID")
                    .ColumnMappings.Add("IntabDate", "INTAB_DATE")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD_INTAB")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD_INTAB")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_INTAB")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_INTAB")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_INTAB")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_INTAB")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_INTAB")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_INTAB")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_INTAB")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_INTAB")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_INTAB")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_INTAB")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_INTAB")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_INTAB")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_INTAB")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_INTAB")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_INTAB")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_INTAB")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_INTAB")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_INTAB")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_INTAB")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_INTAB")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_INTAB")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN_INTAB")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_INTAB"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVProgramList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                   NielsenTVPrograms As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVPrograms.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("QtrHourStartTime", "QTR_HOUR_START_DATETIME")
                    .ColumnMappings.Add("QtrHourEndTime", "QTR_HOUR_END_DATETIME")
                    .ColumnMappings.Add("ProgramName", "PROGRAM_NAME")
                    .ColumnMappings.Add("Subtitle", "SUBTITLE")
                    .ColumnMappings.Add("TrackageName", "TRACKAGE_NAME")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("Month", "MONTH")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_PROGRAM"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVUniverseList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                    NielsenTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("Month", "MONTH")
                    .ColumnMappings.Add("IsMeteredMarket", "IS_METERED_MARKET")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD_UE")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD_UE")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_UE")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_UE")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_UE")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_UE")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_UE")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_UE")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_UE")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_UE")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_UE")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_UE")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_UE")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_UE")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_UE")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_UE")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_UE")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_UE")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_UE")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_UE")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_UE")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_UE")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_UE")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN_UE")
                    .ColumnMappings.Add("SurveyStartDate", "SURVEY_START_DATE")
                    .ColumnMappings.Add("SurveyEndDate", "SURVEY_END_DATE")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVStationList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                 NielsenTVStations As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVStations.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("CallLetters", "CALL_LETTERS")
                    .ColumnMappings.Add("SourceType", "SOURCE_TYPE")
                    .ColumnMappings.Add("ParentPlusIndicator", "PARENT_PLUS_INDICATOR")
                    .ColumnMappings.Add("IsParent", "IS_PARENT")
                    .ColumnMappings.Add("IsSatellite", "IS_SATELLITE")
                    .ColumnMappings.Add("Affiliation", "AFFILIATION")
                    .ColumnMappings.Add("CableName", "CABLE_NAME")
                    .ColumnMappings.Add("ChannelNum", "CHANNEL_NUM")
                    .ColumnMappings.Add("DistributorGroup", "DISTRIBUTOR_GROUP")
                    .ColumnMappings.Add("StationType", "STATION_TYPE")
                    .ColumnMappings.Add("ReportabilityStatus", "REPORTABILITY_STATUS")
                    .ColumnMappings.Add("HomeMarketNumber", "HOME_MARKET_NUM")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_STATION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub AddNielsenUniverse(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String, Year As Short, Month As Short, IsMeteredMarket As Boolean,
                                       SurveyStart As Date, SurveyEnd As Date, ByRef NielsenTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse))

            'objects
            Dim NielsenTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse = Nothing
            Dim NielsenMarketNumber As Integer = 0

            NielsenMarketNumber = CInt(TextLineFields(1))

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse)
                    Where Entity.NielsenMarketNumber = NielsenMarketNumber AndAlso
                          Entity.Year = Year AndAlso
                          Entity.Month = Month
                    Select Entity).Any Then

                NielsenTVUniverse = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse

                NielsenTVUniverse.IsMeteredMarket = IsMeteredMarket
                NielsenTVUniverse.Year = Year
                NielsenTVUniverse.Month = Month
                NielsenTVUniverse.NielsenMarketNumber = TextLineFields(1)

                NielsenTVUniverse.MetroAHousehold = TextLineFields(5)
                NielsenTVUniverse.MetroBHousehold = TextLineFields(6)
                NielsenTVUniverse.Household = TextLineFields(7)
                NielsenTVUniverse.Children2to5 = TextLineFields(8)
                NielsenTVUniverse.Children6to11 = TextLineFields(9)
                NielsenTVUniverse.Males12to14 = TextLineFields(10)
                NielsenTVUniverse.Males15to17 = TextLineFields(11)
                NielsenTVUniverse.Males18to20 = TextLineFields(12)
                NielsenTVUniverse.Males21to24 = TextLineFields(13)
                NielsenTVUniverse.Males25to34 = TextLineFields(14)
                NielsenTVUniverse.Males35to49 = TextLineFields(15)
                NielsenTVUniverse.Males50to54 = TextLineFields(16)
                NielsenTVUniverse.Males55to64 = TextLineFields(17)
                NielsenTVUniverse.Males65Plus = TextLineFields(18)
                NielsenTVUniverse.Females12to14 = TextLineFields(19)
                NielsenTVUniverse.Females15to17 = TextLineFields(20)
                NielsenTVUniverse.Females18to20 = TextLineFields(21)
                NielsenTVUniverse.Females21to24 = TextLineFields(22)
                NielsenTVUniverse.Females25to34 = TextLineFields(23)
                NielsenTVUniverse.Females35to49 = TextLineFields(24)
                NielsenTVUniverse.Females50to54 = TextLineFields(25)
                NielsenTVUniverse.Females55to64 = TextLineFields(26)
                NielsenTVUniverse.Females65Plus = TextLineFields(27)
                NielsenTVUniverse.WorkingWomen = TextLineFields(28)

                NielsenTVUniverse.SurveyStartDate = SurveyStart
                NielsenTVUniverse.SurveyEndDate = SurveyEnd

                NielsenTVUniverses.Add(NielsenTVUniverse)

            End If

        End Sub
        Private Sub AddNielsenIntab(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String, NielsenTVBookID As Integer,
                                    ByRef NielsenTVIntabs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab))

            Dim NielsenTVIntab As AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab = Nothing
            Dim NielsenMarketNumber As Integer = 0
            Dim IntabDate As Date = Nothing

            NielsenMarketNumber = CInt(TextLineFields(1))
            IntabDate = CDate(TextLineFields(5))

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab)
                    Where Entity.NielsenTVBookID = NielsenTVBookID AndAlso
                          Entity.IntabDate = IntabDate
                    Select Entity).Any Then

                NielsenTVIntab = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab

                NielsenTVIntab.NielsenTVBookID = NielsenTVBookID
                NielsenTVIntab.IntabDate = TextLineFields(5)

                NielsenTVIntab.MetroAHousehold = TextLineFields(6)
                NielsenTVIntab.MetroBHousehold = TextLineFields(7)
                NielsenTVIntab.Household = TextLineFields(8)
                NielsenTVIntab.Children2to5 = TextLineFields(9)
                NielsenTVIntab.Children6to11 = TextLineFields(10)
                NielsenTVIntab.Males12to14 = TextLineFields(11)
                NielsenTVIntab.Males15to17 = TextLineFields(12)
                NielsenTVIntab.Males18to20 = TextLineFields(13)
                NielsenTVIntab.Males21to24 = TextLineFields(14)
                NielsenTVIntab.Males25to34 = TextLineFields(15)
                NielsenTVIntab.Males35to49 = TextLineFields(16)
                NielsenTVIntab.Males50to54 = TextLineFields(17)
                NielsenTVIntab.Males55to64 = TextLineFields(18)
                NielsenTVIntab.Males65Plus = TextLineFields(19)
                NielsenTVIntab.Females12to14 = TextLineFields(20)
                NielsenTVIntab.Females15to17 = TextLineFields(21)
                NielsenTVIntab.Females18to20 = TextLineFields(22)
                NielsenTVIntab.Females21to24 = TextLineFields(23)
                NielsenTVIntab.Females25to34 = TextLineFields(24)
                NielsenTVIntab.Females35to49 = TextLineFields(25)
                NielsenTVIntab.Females50to54 = TextLineFields(26)
                NielsenTVIntab.Females55to64 = TextLineFields(27)
                NielsenTVIntab.Females65Plus = TextLineFields(28)
                NielsenTVIntab.WorkingWomen = TextLineFields(29)

                NielsenTVIntabs.Add(NielsenTVIntab)

            End If

        End Sub
        Private Function AddNielsenHutput(TextLineFields() As String, NielsenTVBookID As Integer) As AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput

            Dim NielsenTVHutput As AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput = Nothing

            NielsenTVHutput = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput

            NielsenTVHutput.NielsenTVBookID = NielsenTVBookID
            NielsenTVHutput.HutputDatetime = TextLineFields(6)

            NielsenTVHutput.MetroAHousehold = TextLineFields(8)
            NielsenTVHutput.MetroBHousehold = TextLineFields(9)
            NielsenTVHutput.Household = TextLineFields(10)
            NielsenTVHutput.Children2to5 = TextLineFields(11)
            NielsenTVHutput.Children6to11 = TextLineFields(12)
            NielsenTVHutput.Males12to14 = TextLineFields(13)
            NielsenTVHutput.Males15to17 = TextLineFields(14)
            NielsenTVHutput.Males18to20 = TextLineFields(15)
            NielsenTVHutput.Males21to24 = TextLineFields(16)
            NielsenTVHutput.Males25to34 = TextLineFields(17)
            NielsenTVHutput.Males35to49 = TextLineFields(18)
            NielsenTVHutput.Males50to54 = TextLineFields(19)
            NielsenTVHutput.Males55to64 = TextLineFields(20)
            NielsenTVHutput.Males65Plus = TextLineFields(21)
            NielsenTVHutput.Females12to14 = TextLineFields(22)
            NielsenTVHutput.Females15to17 = TextLineFields(23)
            NielsenTVHutput.Females18to20 = TextLineFields(24)
            NielsenTVHutput.Females21to24 = TextLineFields(25)
            NielsenTVHutput.Females25to34 = TextLineFields(26)
            NielsenTVHutput.Females35to49 = TextLineFields(27)
            NielsenTVHutput.Females50to54 = TextLineFields(28)
            NielsenTVHutput.Females55to64 = TextLineFields(29)
            NielsenTVHutput.Females65Plus = TextLineFields(30)
            NielsenTVHutput.WorkingWomen = TextLineFields(31)

            AddNielsenHutput = NielsenTVHutput

        End Function
        Private Function AddNielsenAudience(TextLineFields() As String, NielsenTVBookID As Integer) As AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience

            Dim NielsenTVAudience As AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience = Nothing

            NielsenTVAudience = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience

            NielsenTVAudience.NielsenTVBookID = NielsenTVBookID
            NielsenTVAudience.AudienceDatetime = TextLineFields(6)

            If TextLineFields(7) = "Y" Then

                NielsenTVAudience.IsExcluded = True

            Else

                NielsenTVAudience.IsExcluded = False

            End If

            NielsenTVAudience.StationCode = TextLineFields(1)

            NielsenTVAudience.MetroAHousehold = TextLineFields(8)
            NielsenTVAudience.MetroBHousehold = TextLineFields(9)
            NielsenTVAudience.Household = TextLineFields(10)
            NielsenTVAudience.Children2to5 = TextLineFields(11)
            NielsenTVAudience.Children6to11 = TextLineFields(12)
            NielsenTVAudience.Males12to14 = TextLineFields(13)
            NielsenTVAudience.Males15to17 = TextLineFields(14)
            NielsenTVAudience.Males18to20 = TextLineFields(15)
            NielsenTVAudience.Males21to24 = TextLineFields(16)
            NielsenTVAudience.Males25to34 = TextLineFields(17)
            NielsenTVAudience.Males35to49 = TextLineFields(18)
            NielsenTVAudience.Males50to54 = TextLineFields(19)
            NielsenTVAudience.Males55to64 = TextLineFields(20)
            NielsenTVAudience.Males65Plus = TextLineFields(21)
            NielsenTVAudience.Females12to14 = TextLineFields(22)
            NielsenTVAudience.Females15to17 = TextLineFields(23)
            NielsenTVAudience.Females18to20 = TextLineFields(24)
            NielsenTVAudience.Females21to24 = TextLineFields(25)
            NielsenTVAudience.Females25to34 = TextLineFields(26)
            NielsenTVAudience.Females35to49 = TextLineFields(27)
            NielsenTVAudience.Females50to54 = TextLineFields(28)
            NielsenTVAudience.Females55to64 = TextLineFields(29)
            NielsenTVAudience.Females65Plus = TextLineFields(30)
            NielsenTVAudience.WorkingWomen = TextLineFields(31)

            AddNielsenAudience = NielsenTVAudience

        End Function
        Private Function AddNielsenProgramName(TextLineFields() As String, Year As Short, Month As Short) As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram

            Dim NielsenTVProgram As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram = Nothing

            NielsenTVProgram = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram

            NielsenTVProgram.NielsenMarketNumber = TextLineFields(1)
            NielsenTVProgram.StationCode = TextLineFields(2)

            NielsenTVProgram.QtrHourStartTime = TextLineFields(6)
            NielsenTVProgram.QtrHourEndTime = TextLineFields(7)
            NielsenTVProgram.ProgramName = TextLineFields(9)
            NielsenTVProgram.Subtitle = TextLineFields(10)
            NielsenTVProgram.Year = Year
            NielsenTVProgram.Month = Month
            AddNielsenProgramName = NielsenTVProgram

        End Function
        Private Sub AddNielsenTVStation(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String,
                                      ByRef NielsenTVStations As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation))

            Dim NielsenMarketNumber As Integer = 0
            Dim StationCode As Integer = 0
            Dim ExistingNielsenTVStation As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation = Nothing
            Dim NielsenTVStation As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation = Nothing
            Dim NielsenTVStationHistory As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStationHistory = Nothing

            NielsenMarketNumber = TextLineFields(1)
            StationCode = TextLineFields(6)

            ExistingNielsenTVStation = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)
                                        Where Entity.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                              Entity.StationCode = StationCode
                                        Select Entity).FirstOrDefault

            If ExistingNielsenTVStation Is Nothing Then

                NielsenTVStation = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation

                NielsenTVStation.NielsenMarketNumber = NielsenMarketNumber
                NielsenTVStation.StationCode = StationCode
                NielsenTVStation.CallLetters = TextLineFields(7)
                NielsenTVStation.SourceType = TextLineFields(12)
                NielsenTVStation.ParentPlusIndicator = TextLineFields(9)

                If TextLineFields(17) = "Y" Then

                    NielsenTVStation.IsParent = True

                Else

                    NielsenTVStation.IsParent = False

                End If

                If TextLineFields(18) = "Y" Then

                    NielsenTVStation.IsSatellite = True

                Else

                    NielsenTVStation.IsSatellite = False

                End If

                NielsenTVStation.Affiliation = TextLineFields(13)
                NielsenTVStation.CableName = TextLineFields(10)
                NielsenTVStation.ChannelNum = TextLineFields(11)

                If IsNumeric(TextLineFields(16)) Then

                    NielsenTVStation.DistributorGroup = TextLineFields(16)

                End If

                NielsenTVStation.StationType = TextLineFields(20)
                NielsenTVStation.ReportabilityStatus = TextLineFields(22)

                If IsNumeric(TextLineFields(5)) Then

                    NielsenTVStation.HomeMarketNumber = CInt(TextLineFields(5))

                End If

                NielsenTVStations.Add(NielsenTVStation)

            Else

                If ExistingNielsenTVStation.CallLetters <> TextLineFields(7) Then

                    ExistingNielsenTVStation.CallLetters = TextLineFields(7)
                    DbContext.Entry(ExistingNielsenTVStation).State = Entity.EntityState.Modified

                    NielsenTVStationHistory = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVStationHistory
                    NielsenTVStationHistory.DbContext = DbContext

                    NielsenTVStationHistory.NielsenMarketNumber = ExistingNielsenTVStation.NielsenMarketNumber
                    NielsenTVStationHistory.StationCode = ExistingNielsenTVStation.StationCode
                    NielsenTVStationHistory.CallLetters = ExistingNielsenTVStation.CallLetters
                    NielsenTVStationHistory.ChangedOn = Now

                    DbContext.NielsenTVStationHistorys.Add(NielsenTVStationHistory)
                    DbContext.SaveChanges()

                End If

            End If

        End Sub
        Private Sub AddNielsenTVBook(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLineFields() As String,
                                     ByRef NielsenTVBookID As Integer)

            Dim NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing

            NielsenTVBook = New AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook
            NielsenTVBook.DbContext = DbContext

            NielsenTVBook.NielsenMarketNumber = TextLineFields(2)
            NielsenTVBook.Year = TextLineFields(23)
            NielsenTVBook.Month = TextLineFields(22)

            Select Case TextLineFields(18).Trim

                Case "O"

                    NielsenTVBook.Stream = "LO"

                Case "S"

                    NielsenTVBook.Stream = "LS"

                Case "1"

                    NielsenTVBook.Stream = "L1"

                Case "3"

                    NielsenTVBook.Stream = "L3"

                Case "7"

                    NielsenTVBook.Stream = "L7"

            End Select

            NielsenTVBook.StartDateTime = TextLineFields(7)
            NielsenTVBook.EndDateTime = TextLineFields(8)
            NielsenTVBook.MarketTimeZone = TextLineFields(24)
            NielsenTVBook.MarketClassCode = TextLineFields(25)
            NielsenTVBook.IsDaylightSavingsMarket = If(TextLineFields(27) = "Y", True, False)
            NielsenTVBook.CreateDate = Now

            DbContext.NielsenTVBooks.Add(NielsenTVBook)
            DbContext.SaveChanges()

            NielsenTVBookID = NielsenTVBook.ID

        End Sub
        Public Function ProcessFile(ConnectionString As String, ByVal Filename As String) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim SqlTransaction As SqlClient.SqlTransaction = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FilenameFields() As String = Nothing
            Dim Year As Short = 0
            Dim Month As Short = 0
            Dim TextLine As String = Nothing
            Dim TextLineFields() As String = Nothing
            Dim HasRecord99 As Boolean = False
            Dim IsMeteredMarket As Boolean = False
            Dim SurveyStart As Date = Nothing
            Dim SurveyEnd As Date = Nothing
            Dim NielsenTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience) = Nothing
            Dim NielsenTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput) = Nothing
            Dim NielsenTVIntabs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab) = Nothing
            Dim NielsenTVPrograms As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram) = Nothing
            Dim NielsenTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse) = Nothing
            Dim NielsenTVStations As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation) = Nothing
            Dim NielsenTVBookID As Integer = -1

            If System.IO.File.Exists(Filename) Then

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    Using SqlConnection As New SqlClient.SqlConnection(ConnectionString)

                        Try

                            SqlConnection.Open()

                            SqlTransaction = SqlConnection.BeginTransaction

                            StreamReader = New System.IO.StreamReader(Filename)

                            FilenameFields = Mid(Filename.ToUpper, 1, InStr(Filename, ".") - 1).Split("_")

                            Year = FilenameFields(3)
                            Month = FilenameFields(4)

                            NielsenTVAudiences = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience)
                            NielsenTVHutputs = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVHutput)
                            NielsenTVIntabs = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVIntab)
                            NielsenTVPrograms = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram)
                            NielsenTVUniverses = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse)
                            NielsenTVStations = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)

                            Do While StreamReader.Peek() <> -1

                                TextLine = StreamReader.ReadLine()

                                Select Case Mid(TextLine, 1, 2)

                                    Case "01"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        AddNielsenTVBook(DbContext, TextLineFields, NielsenTVBookID)

                                        SurveyStart = TextLineFields(7)
                                        SurveyEnd = TextLineFields(8)

                                        If TextLineFields(20) = "1" OrElse TextLineFields(20) = "2" OrElse TextLineFields(20) = "3" OrElse TextLineFields(20) = "5" Then

                                            IsMeteredMarket = True

                                        End If

                                    Case "02"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        AddNielsenTVStation(DbContext, TextLineFields, NielsenTVStations)

                                    Case "04"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        If CStr(TextLineFields(4)) = "1" Then

                                            AddNielsenUniverse(DbContext, TextLineFields, Year, Month, IsMeteredMarket, SurveyStart, SurveyEnd, NielsenTVUniverses)

                                        End If

                                    Case "05"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        If CStr(TextLineFields(4)) = "1" Then

                                            AddNielsenIntab(DbContext, TextLineFields, NielsenTVBookID, NielsenTVIntabs)

                                        End If

                                    Case "07"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        If CStr(TextLineFields(4)) = "1" Then

                                            NielsenTVHutputs.Add(AddNielsenHutput(TextLineFields, NielsenTVBookID))

                                        End If

                                    Case "08"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        If CStr(TextLineFields(4)) = "1" Then

                                            NielsenTVAudiences.Add(AddNielsenAudience(TextLineFields, NielsenTVBookID))

                                        End If

                                    Case "11"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                    Case "12"

                                        TextLineFields = TextLine.Split(ControlChars.Tab)

                                        NielsenTVPrograms.Add(AddNielsenProgramName(TextLineFields, Year, Month))

                                    Case "31"

                                        Exit Do

                                    Case "99"

                                        HasRecord99 = True

                                End Select

                            Loop

                            If HasRecord99 Then

                                'BulkInsertNielsenTVBookList(SqlConnection, SqlTransaction, NielsenTVBooks)

                                BulkInsertNielsenTVAudienceList(SqlConnection, SqlTransaction, NielsenTVAudiences)

                                BulkInsertNielsenTVHutputList(SqlConnection, SqlTransaction, NielsenTVHutputs)

                                BulkInsertNielsenTVIntabList(SqlConnection, SqlTransaction, NielsenTVIntabs)

                                BulkInsertNielsenTVProgramList(SqlConnection, SqlTransaction, NielsenTVPrograms)

                                BulkInsertNielsenTVUniverseList(SqlConnection, SqlTransaction, NielsenTVUniverses)

                                BulkInsertNielsenTVStationList(SqlConnection, SqlTransaction, NielsenTVStations)

                                SqlTransaction.Commit()

                                Processed = True

                            ElseIf Mid(TextLine, 1, 2) <> "31" Then

                                Throw New Exception("Missing EOF 99 record in file: " & Filename)

                            End If

                        Catch ex As Exception

                            SqlTransaction.Rollback()

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NIELSEN_TV_BOOK WHERE NIELSEN_TV_BOOK_ID = {0}", NielsenTVBookID))

                            Throw New Exception(ex.Message)

                        Finally

                            If SqlConnection.State = ConnectionState.Open Then

                                SqlConnection.Close()

                            End If

                            StreamReader.Close()

                        End Try

                    End Using

                End Using

            End If

            ProcessFile = Processed

        End Function
        Public Sub WriteToEventLog(ByVal Message As String)

            If _EventLog IsNot Nothing Then

                _EventLog.WriteEntry(Message)

            End If

        End Sub

#Region " National Data "

        Private Function GetLastSundayInAugust(DateToConvert As Date) As Date

            Dim LastSundayYear As Integer = 0
            Dim Found As Boolean = False
            Dim LastSundayInAugust As Date = Nothing
            Dim Day As Integer = 31

            If DateToConvert.Month <= 8 Then

                LastSundayYear = DateToConvert.Year

            Else

                LastSundayYear = DateToConvert.Year + 1

            End If

            While Not Found

                If DateSerial(LastSundayYear, 8, Day).DayOfWeek = DayOfWeek.Sunday Then

                    LastSundayInAugust = DateSerial(LastSundayYear, 8, Day)
                    Found = True

                Else

                    Day = Day - 1

                End If

            End While

            If DateToConvert > LastSundayInAugust Then

                LastSundayInAugust = GetLastSundayInAugust(LastSundayInAugust)

            End If

            GetLastSundayInAugust = LastSundayInAugust

        End Function
        Private Sub DeleteNationalTVAudience(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String)

            Dim ProgramCode As Decimal = Nothing
            Dim AudienceDate As Date = Nothing
            Dim AudienceTime As Short = Nothing

            ProgramCode = CDec(Mid(TextLine, 21, 10))

            If Mid(TextLine, 44, 1) = "1" Then

                AudienceDate = DateSerial(2000 + CInt(Mid(TextLine, 45, 2)), CInt(Mid(TextLine, 47, 2)), CInt(Mid(TextLine, 49, 2)))
                AudienceTime = Mid(TextLine, 86, 4)

            End If

            DbContext.Database.ExecuteSqlCommand("DELETE dbo.NIELSEN_NATIONAL_TV_AUDIENCE WHERE PROGRAM_CODE = @PROGRAM_CODE AND AUDIENCE_DATE = @AUDIENCE_DATE AND AUDIENCE_TIME = @AUDIENCE_TIME",
                                                     New SqlClient.SqlParameter("@PROGRAM_CODE", ProgramCode), New SqlClient.SqlParameter("@AUDIENCE_DATE", AudienceDate), New SqlClient.SqlParameter("@AUDIENCE_TIME", AudienceTime))

        End Sub
        Private Function GetDecimalValue(InputString As String) As Decimal

            Dim DecValue As Decimal = 0

            If IsNumeric(InputString) Then

                DecValue = CDec(InputString)

            End If

            GetDecimalValue = DecValue

        End Function
        Private Sub AddNielsenNationalTVAudience(DbContext As AdvantageFramework.Nielsen.Database.DbContext, MediaMarketBreakID As Integer, TextLine As String, TextLine2 As String, TextLine3 As String,
                                                 TextLine4 As String, TextLine5 As String,
                                                 TimeType As String, Stream As String, FilePrefix As String, IsOvernight As Boolean,
                                                 ByRef NielsenNationalTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience))

            Dim Network As String = Nothing
            Dim SyndicatorInfo As String = Nothing
            Dim AudienceDate As Date = Nothing
            Dim AudienceTime As Short = Nothing
            Dim SequenceNumber As Short = 0
            Dim NielsenNationalTVAudience As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience = Nothing

            If FilePrefix = "NSS" Then

                Network = Mid(TextLine, 250, 4)
                SyndicatorInfo = Mid(TextLine, 41, 1)

            ElseIf FilePrefix = "NTI" OrElse FilePrefix = "NHI" Then

                Network = Mid(TextLine, 15, 6)
                SyndicatorInfo = " "

            End If

            If Mid(TextLine, 44, 1) = "1" Then

                AudienceDate = DateSerial(2000 + CInt(Mid(TextLine, 45, 2)), CInt(Mid(TextLine, 47, 2)), CInt(Mid(TextLine, 49, 2)))
                AudienceTime = Mid(TextLine, 86, 4)

            End If

            If AudienceTime = 0 Then

                AudienceTime = 600

            End If

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience)
                    Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
                          Entity.TimeType = TimeType AndAlso
                          Entity.Stream = Stream AndAlso
                          Entity.Network = Network AndAlso
                          Entity.AudienceDate = AudienceDate AndAlso
                          Entity.AudienceTime = AudienceTime AndAlso
                          Entity.SequenceNumber = SequenceNumber
                    Select Entity).Any Then

                If (From Entity In NielsenNationalTVAudiences
                    Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
                          Entity.TimeType = TimeType AndAlso
                          Entity.Stream = Stream AndAlso
                          Entity.Network = Network AndAlso
                          Entity.AudienceDate = AudienceDate AndAlso
                          Entity.AudienceTime = AudienceTime AndAlso
                          Entity.SequenceNumber = SequenceNumber
                    Select Entity).Any Then

                    SequenceNumber = (From Entity In NielsenNationalTVAudiences
                                      Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
                                            Entity.TimeType = TimeType AndAlso
                                            Entity.Stream = Stream AndAlso
                                            Entity.Network = Network AndAlso
                                            Entity.AudienceDate = AudienceDate AndAlso
                                            Entity.AudienceTime = AudienceTime
                                      Select Entity).AsParallel.Max(Function(Entity) Entity.SequenceNumber) + 1

                End If

                NielsenNationalTVAudience = New AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience

                NielsenNationalTVAudience.MediaMarketBreakID = MediaMarketBreakID
                NielsenNationalTVAudience.TimeType = TimeType
                NielsenNationalTVAudience.Stream = Stream
                NielsenNationalTVAudience.Network = Network
                NielsenNationalTVAudience.AudienceDate = AudienceDate
                NielsenNationalTVAudience.AudienceTime = AudienceTime
                NielsenNationalTVAudience.SequenceNumber = SequenceNumber

                NielsenNationalTVAudience.ProgramDuration = CShort(Mid(TextLine, 278, 4))
                NielsenNationalTVAudience.ProgramTotalDuration = CInt(Mid(TextLine, 331, 6))
                NielsenNationalTVAudience.ProgramName = Mid(TextLine, 115, 25)
                NielsenNationalTVAudience.TrackageName = Mid(TextLine, 140, 25)
                NielsenNationalTVAudience.EpisodeName = Mid(TextLine, 180, 32)
                NielsenNationalTVAudience.ProgramCode = CDec(Mid(TextLine, 21, 10))
                NielsenNationalTVAudience.TrackageCode = If(IsNumeric(Mid(TextLine, 31, 3)), CShort(Mid(TextLine, 31, 3)), Nothing)
                NielsenNationalTVAudience.NielsenDaypart = Mid(TextLine, 276, 2)
                NielsenNationalTVAudience.ProgramType = Mid(TextLine, 216, 2)

                If Mid(TextLine, 11, 1) = "0" Then 'original

                    NielsenNationalTVAudience.IsCorrection = False

                ElseIf Mid(TextLine, 11, 1) = "1" Then 'correction

                    NielsenNationalTVAudience.IsCorrection = True

                End If

                NielsenNationalTVAudience.IsBreakout = CBool(Mid(TextLine, 35, 1))
                NielsenNationalTVAudience.IsSpecial = CBool(Mid(TextLine, 36, 1))
                NielsenNationalTVAudience.IsRepeat = CBool(If(Mid(TextLine, 230, 1) = "Y", 1, 0))
                NielsenNationalTVAudience.IsPremiere = CBool(If(Mid(TextLine, 238, 1) = "Y", 1, 0))
                NielsenNationalTVAudience.IsOvernight = IsOvernight
                NielsenNationalTVAudience.IsDNA = CBool(If(Mid(TextLine, 98, 1) = "1", 1, 0))
                NielsenNationalTVAudience.IsMulticast = CBool(If(Mid(TextLine, 229, 1) = "Y", 1, 0))
                NielsenNationalTVAudience.IsComplex = CBool(If(Mid(TextLine, 231, 1) = "Y", 1, 0))
                NielsenNationalTVAudience.IsShortDuration = CBool(If(Mid(TextLine, 232, 1) = "Y", 1, 0))
                NielsenNationalTVAudience.IsVariousMetadata = CBool(If(Mid(TextLine, 237, 1) = "Y", 1, 0))

                NielsenNationalTVAudience.IsVariousTimes = True 'CBool(Mid(TextLine, 319, 1))

                NielsenNationalTVAudience.IsGapped = CBool(If(Mid(TextLine, 42, 1) = "00", 0, 1))
                NielsenNationalTVAudience.IsWeeklyAverage = CBool(If(Mid(TextLine, 239, 1) = "Y", 1, 0))
                NielsenNationalTVAudience.SyndicatorInfo = SyndicatorInfo
                NielsenNationalTVAudience.TelecastNumber = CDec(Mid(TextLine, 58, 10))
                NielsenNationalTVAudience.CoverageSampleIdentification = CInt(Mid(TextLine, 71, 6))
                NielsenNationalTVAudience.MarketBreakIdentifier = CShort(Mid(TextLine, 78, 3))
                NielsenNationalTVAudience.TotalProgramIndicator = Mid(TextLine, 81, 2)
                NielsenNationalTVAudience.DaysOfWeekIndicator = Mid(TextLine, 282, 7)
                NielsenNationalTVAudience.StationCount = CInt(Mid(TextLine, 305, 5))
                NielsenNationalTVAudience.HeadendCount = CInt(Mid(TextLine, 310, 5))
                NielsenNationalTVAudience.CoveragePercent = CShort(Mid(TextLine, 315, 2))
                NielsenNationalTVAudience.DaysCount = CShort(Mid(TextLine, 328, 3))

                NielsenNationalTVAudience.ProgramHUT = GetDecimalValue(Mid(TextLine, 354, 9))
                NielsenNationalTVAudience.HouseholdAudience = GetDecimalValue(Mid(TextLine, 337, 9))
                NielsenNationalTVAudience.Females2to5Audience = GetDecimalValue(Mid(TextLine2, 116, 9))
                NielsenNationalTVAudience.Females6to8Audience = GetDecimalValue(Mid(TextLine2, 125, 9))
                NielsenNationalTVAudience.Females9to11Audience = GetDecimalValue(Mid(TextLine2, 134, 9))
                NielsenNationalTVAudience.Females12to14Audience = GetDecimalValue(Mid(TextLine2, 143, 9))
                NielsenNationalTVAudience.Females15to17Audience = GetDecimalValue(Mid(TextLine2, 152, 9))
                NielsenNationalTVAudience.Females18to20Audience = GetDecimalValue(Mid(TextLine2, 161, 9))
                NielsenNationalTVAudience.Females21to24Audience = GetDecimalValue(Mid(TextLine2, 170, 9))
                NielsenNationalTVAudience.Females25to29Audience = GetDecimalValue(Mid(TextLine2, 179, 9))
                NielsenNationalTVAudience.Females30to34Audience = GetDecimalValue(Mid(TextLine2, 188, 9))
                NielsenNationalTVAudience.Females35to39Audience = GetDecimalValue(Mid(TextLine2, 197, 9))
                NielsenNationalTVAudience.Females40to44Audience = GetDecimalValue(Mid(TextLine2, 206, 9))
                NielsenNationalTVAudience.Females45to49Audience = GetDecimalValue(Mid(TextLine2, 215, 9))
                NielsenNationalTVAudience.Females50to54Audience = GetDecimalValue(Mid(TextLine2, 224, 9))
                NielsenNationalTVAudience.Females55to64Audience = GetDecimalValue(Mid(TextLine2, 233, 9))
                NielsenNationalTVAudience.Females65PlusAudience = GetDecimalValue(Mid(TextLine2, 242, 9))
                NielsenNationalTVAudience.Males2to5Audience = GetDecimalValue(Mid(TextLine2, 251, 9))
                NielsenNationalTVAudience.Males6to8Audience = GetDecimalValue(Mid(TextLine2, 260, 9))
                NielsenNationalTVAudience.Males9to11Audience = GetDecimalValue(Mid(TextLine2, 269, 9))
                NielsenNationalTVAudience.Males12to14Audience = GetDecimalValue(Mid(TextLine2, 278, 9))
                NielsenNationalTVAudience.Males15to17Audience = GetDecimalValue(Mid(TextLine2, 287, 9))
                NielsenNationalTVAudience.Males18to20Audience = GetDecimalValue(Mid(TextLine3, 116, 9))
                NielsenNationalTVAudience.Males21to24Audience = GetDecimalValue(Mid(TextLine3, 125, 9))
                NielsenNationalTVAudience.Males25to29Audience = GetDecimalValue(Mid(TextLine3, 134, 9))
                NielsenNationalTVAudience.Males30to34Audience = GetDecimalValue(Mid(TextLine3, 143, 9))
                NielsenNationalTVAudience.Males35to39Audience = GetDecimalValue(Mid(TextLine3, 152, 9))
                NielsenNationalTVAudience.Males40to44Audience = GetDecimalValue(Mid(TextLine3, 161, 9))
                NielsenNationalTVAudience.Males45to49Audience = GetDecimalValue(Mid(TextLine3, 170, 9))
                NielsenNationalTVAudience.Males50to54Audience = GetDecimalValue(Mid(TextLine3, 179, 9))
                NielsenNationalTVAudience.Males55to64Audience = GetDecimalValue(Mid(TextLine3, 188, 9))
                NielsenNationalTVAudience.Males65PlusAudience = GetDecimalValue(Mid(TextLine3, 197, 9))
                NielsenNationalTVAudience.WorkingWomen18to20Audience = GetDecimalValue(Mid(TextLine3, 224, 9))
                NielsenNationalTVAudience.WorkingWomen21to24Audience = GetDecimalValue(Mid(TextLine3, 233, 9))
                NielsenNationalTVAudience.WorkingWomen25to34Audience = GetDecimalValue(Mid(TextLine3, 242, 9))
                NielsenNationalTVAudience.WorkingWomen35to44Audience = GetDecimalValue(Mid(TextLine3, 251, 9))
                NielsenNationalTVAudience.WorkingWomen45to49Audience = GetDecimalValue(Mid(TextLine3, 260, 9))
                NielsenNationalTVAudience.WorkingWomen50to54Audience = GetDecimalValue(Mid(TextLine3, 269, 9))
                NielsenNationalTVAudience.WorkingWomen55PlusAudience = GetDecimalValue(Mid(TextLine3, 278, 9))
                NielsenNationalTVAudience.HouseholdHUT = GetDecimalValue(Mid(TextLine, 354, 9))

                NielsenNationalTVAudience.Females2to5PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 116, 9)))
                NielsenNationalTVAudience.Females6to8PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 125, 9)))
                NielsenNationalTVAudience.Females9to11PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 134, 9)))
                NielsenNationalTVAudience.Females12to14PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 143, 9)))
                NielsenNationalTVAudience.Females15to17PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 152, 9)))
                NielsenNationalTVAudience.Females18to20PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 161, 9)))
                NielsenNationalTVAudience.Females21to24PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 170, 9)))
                NielsenNationalTVAudience.Females25to29PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 179, 9)))
                NielsenNationalTVAudience.Females30to34PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 188, 9)))
                NielsenNationalTVAudience.Females35to39PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 197, 9)))
                NielsenNationalTVAudience.Females40to44PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 206, 9)))
                NielsenNationalTVAudience.Females45to49PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 215, 9)))
                NielsenNationalTVAudience.Females50to54PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 224, 9)))
                NielsenNationalTVAudience.Females55to64PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 233, 9)))
                NielsenNationalTVAudience.Females65PlusPUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 242, 9)))
                NielsenNationalTVAudience.Males2to5PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 251, 9)))
                NielsenNationalTVAudience.Males6to8PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 260, 9)))
                NielsenNationalTVAudience.Males9to11PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 269, 9)))
                NielsenNationalTVAudience.Males12to14PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 278, 9)))
                NielsenNationalTVAudience.Males15to17PUT = If(TextLine4 Is Nothing, 0, GetDecimalValue(Mid(TextLine4, 287, 9)))

                NielsenNationalTVAudience.Males18to20PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 116, 9)))
                NielsenNationalTVAudience.Males21to24PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 125, 9)))
                NielsenNationalTVAudience.Males25to29PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 134, 9)))
                NielsenNationalTVAudience.Males30to34PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 143, 9)))
                NielsenNationalTVAudience.Males35to39PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 152, 9)))
                NielsenNationalTVAudience.Males40to44PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 161, 9)))
                NielsenNationalTVAudience.Males45to49PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 170, 9)))
                NielsenNationalTVAudience.Males50to54PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 179, 9)))
                NielsenNationalTVAudience.Males55to64PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 188, 9)))
                NielsenNationalTVAudience.Males65PlusPUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 197, 9)))
                NielsenNationalTVAudience.WorkingWomen18to20PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 224, 9)))
                NielsenNationalTVAudience.WorkingWomen21to24PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 233, 9)))
                NielsenNationalTVAudience.WorkingWomen25to34PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 242, 9)))
                NielsenNationalTVAudience.WorkingWomen35to44PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 251, 9)))
                NielsenNationalTVAudience.WorkingWomen45to49PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 260, 9)))
                NielsenNationalTVAudience.WorkingWomen50to54PUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 269, 9)))
                NielsenNationalTVAudience.WorkingWomen55PlusPUT = If(TextLine5 Is Nothing, 0, GetDecimalValue(Mid(TextLine5, 278, 9)))

                NielsenNationalTVAudiences.Add(NielsenNationalTVAudience)

            End If

        End Sub
        Private Sub BulkInsertNielsenNationalTVAudienceList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                            NielsenNationalTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenNationalTVAudiences.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("MediaMarketBreakID", "MEDIA_MARKET_BREAK_ID")
                    .ColumnMappings.Add("TimeType", "TIME_TYPE")
                    .ColumnMappings.Add("Stream", "STREAM")
                    .ColumnMappings.Add("Network", "NETWORK")
                    .ColumnMappings.Add("AudienceDate", "AUDIENCE_DATE")
                    .ColumnMappings.Add("AudienceTime", "AUDIENCE_TIME")
                    .ColumnMappings.Add("SequenceNumber", "SEQ_NBR")
                    .ColumnMappings.Add("ProgramDuration", "PROGRAM_DURATION")
                    .ColumnMappings.Add("ProgramTotalDuration", "PROGRAM_TOTAL_DURATION")
                    .ColumnMappings.Add("ProgramName", "PROGRAM_NAME")
                    .ColumnMappings.Add("TrackageName", "TRACKAGE_NAME")
                    .ColumnMappings.Add("EpisodeName", "EPISODE_NAME")
                    .ColumnMappings.Add("ProgramCode", "PROGRAM_CODE")
                    .ColumnMappings.Add("TrackageCode", "TRACKAGE_CODE")
                    .ColumnMappings.Add("NielsenDaypart", "NIELSEN_DAYPART")
                    .ColumnMappings.Add("ProgramType", "PROGRAM_TYPE")
                    .ColumnMappings.Add("IsCorrection", "IS_CORRECTION")
                    .ColumnMappings.Add("IsBreakout", "IS_BREAKOUT")
                    .ColumnMappings.Add("IsSpecial", "IS_SPECIAL")
                    .ColumnMappings.Add("IsRepeat", "IS_REPEAT")
                    .ColumnMappings.Add("IsPremiere", "IS_PREMIERE")
                    .ColumnMappings.Add("IsOvernight", "IS_OVERNIGHT")
                    .ColumnMappings.Add("IsDNA", "IS_DNA")
                    .ColumnMappings.Add("IsMulticast", "IS_MULTICAST")
                    .ColumnMappings.Add("IsComplex", "IS_COMPLEX")
                    .ColumnMappings.Add("IsShortDuration", "IS_SHORT_DURATION")
                    .ColumnMappings.Add("IsVariousMetadata", "IS_VARIOUS_METADATA")
                    .ColumnMappings.Add("IsVariousTimes", "IS_VARIOUS_TIMES")
                    .ColumnMappings.Add("IsGapped", "IS_GAPPED")
                    .ColumnMappings.Add("IsWeeklyAverage", "IS_WEEKLY_AVERAGE")
                    .ColumnMappings.Add("SyndicatorInfo", "SYNDICATOR_INFO")
                    .ColumnMappings.Add("TelecastNumber", "TELECAST_NUMBER")
                    .ColumnMappings.Add("CoverageSampleIdentification", "COVERAGE_SAMPLE_IDENTIFICATION")
                    .ColumnMappings.Add("MarketBreakIdentifier", "MARKET_BREAK_IDENTIFIER")
                    .ColumnMappings.Add("TotalProgramIndicator", "TOTAL_PROGRAM_INDICATOR")
                    .ColumnMappings.Add("DaysOfWeekIndicator", "DAYS_OF_WEEK_INDICATOR")
                    .ColumnMappings.Add("StationCount", "STATION_COUNT")
                    .ColumnMappings.Add("HeadendCount", "HEADEND_COUNT")
                    .ColumnMappings.Add("CoveragePercent", "COVERAGE_PERCENT")
                    .ColumnMappings.Add("DaysCount", "DAYS_COUNT")
                    .ColumnMappings.Add("ProgramHUT", "PROGRAM_HUT")
                    .ColumnMappings.Add("HouseholdAudience", "HOUSEHOLD_AUD")
                    .ColumnMappings.Add("Females2to5Audience", "FEMALES_2TO5_AUD")
                    .ColumnMappings.Add("Females6to8Audience", "FEMALES_6TO8_AUD")
                    .ColumnMappings.Add("Females9to11Audience", "FEMALES_9TO11_AUD")
                    .ColumnMappings.Add("Females12to14Audience", "FEMALES_12TO14_AUD")
                    .ColumnMappings.Add("Females15to17Audience", "FEMALES_15TO17_AUD")
                    .ColumnMappings.Add("Females18to20Audience", "FEMALES_18TO20_AUD")
                    .ColumnMappings.Add("Females21to24Audience", "FEMALES_21TO24_AUD")
                    .ColumnMappings.Add("Females25to29Audience", "FEMALES_25TO29_AUD")
                    .ColumnMappings.Add("Females30to34Audience", "FEMALES_30TO34_AUD")
                    .ColumnMappings.Add("Females35to39Audience", "FEMALES_35TO39_AUD")
                    .ColumnMappings.Add("Females40to44Audience", "FEMALES_40TO44_AUD")
                    .ColumnMappings.Add("Females45to49Audience", "FEMALES_45TO49_AUD")
                    .ColumnMappings.Add("Females50to54Audience", "FEMALES_50TO54_AUD")
                    .ColumnMappings.Add("Females55to64Audience", "FEMALES_55TO64_AUD")
                    .ColumnMappings.Add("Females65PlusAudience", "FEMALES_65PLUS_AUD")
                    .ColumnMappings.Add("Males2to5Audience", "MALES_2TO5_AUD")
                    .ColumnMappings.Add("Males6to8Audience", "MALES_6TO8_AUD")
                    .ColumnMappings.Add("Males9to11Audience", "MALES_9TO11_AUD")
                    .ColumnMappings.Add("Males12to14Audience", "MALES_12TO14_AUD")
                    .ColumnMappings.Add("Males15to17Audience", "MALES_15TO17_AUD")
                    .ColumnMappings.Add("Males18to20Audience", "MALES_18TO20_AUD")
                    .ColumnMappings.Add("Males21to24Audience", "MALES_21TO24_AUD")
                    .ColumnMappings.Add("Males25to29Audience", "MALES_25TO29_AUD")
                    .ColumnMappings.Add("Males30to34Audience", "MALES_30TO34_AUD")
                    .ColumnMappings.Add("Males35to39Audience", "MALES_35TO39_AUD")
                    .ColumnMappings.Add("Males40to44Audience", "MALES_40TO44_AUD")
                    .ColumnMappings.Add("Males45to49Audience", "MALES_45TO49_AUD")
                    .ColumnMappings.Add("Males50to54Audience", "MALES_50TO54_AUD")
                    .ColumnMappings.Add("Males55to64Audience", "MALES_55TO64_AUD")
                    .ColumnMappings.Add("Males65PlusAudience", "MALES_65PLUS_AUD")
                    .ColumnMappings.Add("WorkingWomen18to20Audience", "WORKING_WOMEN_18TO20_AUD")
                    .ColumnMappings.Add("WorkingWomen21to24Audience", "WORKING_WOMEN_21TO24_AUD")
                    .ColumnMappings.Add("WorkingWomen25to34Audience", "WORKING_WOMEN_25TO34_AUD")
                    .ColumnMappings.Add("WorkingWomen35to44Audience", "WORKING_WOMEN_35TO44_AUD")
                    .ColumnMappings.Add("WorkingWomen45to49Audience", "WORKING_WOMEN_45TO49_AUD")
                    .ColumnMappings.Add("WorkingWomen50to54Audience", "WORKING_WOMEN_50TO54_AUD")
                    .ColumnMappings.Add("WorkingWomen55PlusAudience", "WORKING_WOMEN_55PLUS_AUD")
                    .ColumnMappings.Add("HouseholdHUT", "HOUSEHOLD_HUT")
                    .ColumnMappings.Add("Females2to5PUT", "FEMALES_2TO5_PUT")
                    .ColumnMappings.Add("Females6to8PUT", "FEMALES_6TO8_PUT")
                    .ColumnMappings.Add("Females9to11PUT", "FEMALES_9TO11_PUT")
                    .ColumnMappings.Add("Females12to14PUT", "FEMALES_12TO14_PUT")
                    .ColumnMappings.Add("Females15to17PUT", "FEMALES_15TO17_PUT")
                    .ColumnMappings.Add("Females18to20PUT", "FEMALES_18TO20_PUT")
                    .ColumnMappings.Add("Females21to24PUT", "FEMALES_21TO24_PUT")
                    .ColumnMappings.Add("Females25to29PUT", "FEMALES_25TO29_PUT")
                    .ColumnMappings.Add("Females30to34PUT", "FEMALES_30TO34_PUT")
                    .ColumnMappings.Add("Females35to39PUT", "FEMALES_35TO39_PUT")
                    .ColumnMappings.Add("Females40to44PUT", "FEMALES_40TO44_PUT")
                    .ColumnMappings.Add("Females45to49PUT", "FEMALES_45TO49_PUT")
                    .ColumnMappings.Add("Females50to54PUT", "FEMALES_50TO54_PUT")
                    .ColumnMappings.Add("Females55to64PUT", "FEMALES_55TO64_PUT")
                    .ColumnMappings.Add("Females65PlusPUT", "FEMALES_65PLUS_PUT")
                    .ColumnMappings.Add("Males2to5PUT", "MALES_2TO5_PUT")
                    .ColumnMappings.Add("Males6to8PUT", "MALES_6TO8_PUT")
                    .ColumnMappings.Add("Males9to11PUT", "MALES_9TO11_PUT")
                    .ColumnMappings.Add("Males12to14PUT", "MALES_12TO14_PUT")
                    .ColumnMappings.Add("Males15to17PUT", "MALES_15TO17_PUT")
                    .ColumnMappings.Add("Males18to20PUT", "MALES_18TO20_PUT")
                    .ColumnMappings.Add("Males21to24PUT", "MALES_21TO24_PUT")
                    .ColumnMappings.Add("Males25to29PUT", "MALES_25TO29_PUT")
                    .ColumnMappings.Add("Males30to34PUT", "MALES_30TO34_PUT")
                    .ColumnMappings.Add("Males35to39PUT", "MALES_35TO39_PUT")
                    .ColumnMappings.Add("Males40to44PUT", "MALES_40TO44_PUT")
                    .ColumnMappings.Add("Males45to49PUT", "MALES_45TO49_PUT")
                    .ColumnMappings.Add("Males50to54PUT", "MALES_50TO54_PUT")
                    .ColumnMappings.Add("Males55to64PUT", "MALES_55TO64_PUT")
                    .ColumnMappings.Add("Males65PlusPUT", "MALES_65PLUS_PUT")
                    .ColumnMappings.Add("WorkingWomen18to20PUT", "WORKING_WOMEN_18TO20_PUT")
                    .ColumnMappings.Add("WorkingWomen21to24PUT", "WORKING_WOMEN_21TO24_PUT")
                    .ColumnMappings.Add("WorkingWomen25to34PUT", "WORKING_WOMEN_25TO34_PUT")
                    .ColumnMappings.Add("WorkingWomen35to44PUT", "WORKING_WOMEN_35TO44_PUT")
                    .ColumnMappings.Add("WorkingWomen45to49PUT", "WORKING_WOMEN_45TO49_PUT")
                    .ColumnMappings.Add("WorkingWomen50to54PUT", "WORKING_WOMEN_50TO54_PUT")
                    .ColumnMappings.Add("WorkingWomen55PlusPUT", "WORKING_WOMEN_55PLUS_PUT")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_NATIONAL_TV_AUDIENCE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub AddNielsenNationalTVHutput(DbContext As AdvantageFramework.Nielsen.Database.DbContext, MediaMarketBreakID As Integer, TextLine As String, TextLine2 As String, TextLine3 As String,
                                               TimeType As String, Stream As String,
                                               ByRef NielsenNationalTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput))

            Dim NielsenNationalTVHutput As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput = Nothing
            Dim HutputDate As Date = Nothing
            Dim HutputTime As Short = Nothing

            If Mid(TextLine, 44, 1) = "1" Then

                HutputDate = DateSerial(2000 + CInt(Mid(TextLine, 45, 2)), CInt(Mid(TextLine, 47, 2)), CInt(Mid(TextLine, 49, 2)))
                HutputTime = Mid(TextLine, 86, 4)

            End If

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput)
                    Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
                          Entity.TimeType = TimeType AndAlso
                          Entity.Stream = Stream AndAlso
                          Entity.HutputDate = HutputDate AndAlso
                          Entity.HutputTime = HutputTime
                    Select Entity).Any Then

                NielsenNationalTVHutput = New AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput

                NielsenNationalTVHutput.MediaMarketBreakID = MediaMarketBreakID
                NielsenNationalTVHutput.TimeType = TimeType
                NielsenNationalTVHutput.Stream = Stream
                NielsenNationalTVHutput.HutputDate = HutputDate
                NielsenNationalTVHutput.HutputTime = HutputTime
                NielsenNationalTVHutput.IsCorrection = CBool(Mid(TextLine, 11, 1))
                NielsenNationalTVHutput.Household = CInt(Mid(TextLine, 180, 9))

                NielsenNationalTVHutput.Females2to5 = CInt(Mid(TextLine2, 116, 9))
                NielsenNationalTVHutput.Females6to8 = CInt(Mid(TextLine2, 125, 9))
                NielsenNationalTVHutput.Females9to11 = CInt(Mid(TextLine2, 134, 9))
                NielsenNationalTVHutput.Females12to14 = CInt(Mid(TextLine2, 143, 9))
                NielsenNationalTVHutput.Females15to17 = CInt(Mid(TextLine2, 152, 9))
                NielsenNationalTVHutput.Females18to20 = CInt(Mid(TextLine2, 161, 9))
                NielsenNationalTVHutput.Females21to24 = CInt(Mid(TextLine2, 170, 9))
                NielsenNationalTVHutput.Females25to29 = CInt(Mid(TextLine2, 179, 9))
                NielsenNationalTVHutput.Females30to34 = CInt(Mid(TextLine2, 188, 9))
                NielsenNationalTVHutput.Females35to39 = CInt(Mid(TextLine2, 197, 9))
                NielsenNationalTVHutput.Females40to44 = CInt(Mid(TextLine2, 206, 9))
                NielsenNationalTVHutput.Females45to49 = CInt(Mid(TextLine2, 215, 9))
                NielsenNationalTVHutput.Females50to54 = CInt(Mid(TextLine2, 224, 9))
                NielsenNationalTVHutput.Females55to64 = CInt(Mid(TextLine2, 233, 9))
                NielsenNationalTVHutput.Females65Plus = CInt(Mid(TextLine2, 242, 9))
                NielsenNationalTVHutput.Males2to5 = CInt(Mid(TextLine2, 251, 9))
                NielsenNationalTVHutput.Males6to8 = CInt(Mid(TextLine2, 260, 9))
                NielsenNationalTVHutput.Males9to11 = CInt(Mid(TextLine2, 269, 9))
                NielsenNationalTVHutput.Males12to14 = CInt(Mid(TextLine2, 278, 9))
                NielsenNationalTVHutput.Males15to17 = CInt(Mid(TextLine2, 287, 9))

                NielsenNationalTVHutput.Males18to20 = CInt(Mid(TextLine3, 116, 9))
                NielsenNationalTVHutput.Males21to24 = CInt(Mid(TextLine3, 125, 9))
                NielsenNationalTVHutput.Males25to29 = CInt(Mid(TextLine3, 134, 9))
                NielsenNationalTVHutput.Males30to34 = CInt(Mid(TextLine3, 143, 9))
                NielsenNationalTVHutput.Males35to39 = CInt(Mid(TextLine3, 152, 9))
                NielsenNationalTVHutput.Males40to44 = CInt(Mid(TextLine3, 161, 9))
                NielsenNationalTVHutput.Males45to49 = CInt(Mid(TextLine3, 170, 9))
                NielsenNationalTVHutput.Males50to54 = CInt(Mid(TextLine3, 179, 9))
                NielsenNationalTVHutput.Males55to64 = CInt(Mid(TextLine3, 188, 9))
                NielsenNationalTVHutput.Males65Plus = CInt(Mid(TextLine3, 197, 9))
                NielsenNationalTVHutput.WorkingWomen18to20 = CInt(Mid(TextLine3, 224, 9))
                NielsenNationalTVHutput.WorkingWomen21to24 = CInt(Mid(TextLine3, 233, 9))
                NielsenNationalTVHutput.WorkingWomen25to34 = CInt(Mid(TextLine3, 242, 9))
                NielsenNationalTVHutput.WorkingWomen35to44 = CInt(Mid(TextLine3, 251, 9))
                NielsenNationalTVHutput.WorkingWomen45to49 = CInt(Mid(TextLine3, 260, 9))
                NielsenNationalTVHutput.WorkingWomen50to54 = CInt(Mid(TextLine3, 269, 9))
                NielsenNationalTVHutput.WorkingWomen55Plus = CInt(Mid(TextLine3, 278, 9))

                NielsenNationalTVHutputs.Add(NielsenNationalTVHutput)

            End If

        End Sub
        Private Sub BulkInsertNielsenNationalTVHutputList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                          NielsenNationalTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenNationalTVHutputs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("MediaMarketBreakID", "MEDIA_MARKET_BREAK_ID")
                    .ColumnMappings.Add("TimeType", "TIME_TYPE")
                    .ColumnMappings.Add("Stream", "STREAM")
                    .ColumnMappings.Add("HutputDate", "HUTPUT_DATE")
                    .ColumnMappings.Add("HutputTime", "HUTPUT_TIME")
                    .ColumnMappings.Add("IsCorrection", "IS_CORRECTION")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_HUT")
                    .ColumnMappings.Add("Females2to5", "FEMALES_2TO5_PUT")
                    .ColumnMappings.Add("Females6to8", "FEMALES_6TO8_PUT")
                    .ColumnMappings.Add("Females9to11", "FEMALES_9TO11_PUT")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_PUT")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_PUT")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUT")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUT")
                    .ColumnMappings.Add("Females25to29", "FEMALES_25TO29_PUT")
                    .ColumnMappings.Add("Females30to34", "FEMALES_30TO34_PUT")
                    .ColumnMappings.Add("Females35to39", "FEMALES_35TO39_PUT")
                    .ColumnMappings.Add("Females40to44", "FEMALES_40TO44_PUT")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_PUT")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUT")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUT")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUT")
                    .ColumnMappings.Add("Males2to5", "MALES_2TO5_PUT")
                    .ColumnMappings.Add("Males6to8", "MALES_6TO8_PUT")
                    .ColumnMappings.Add("Males9to11", "MALES_9TO11_PUT")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_PUT")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_PUT")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUT")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUT")
                    .ColumnMappings.Add("Males25to29", "MALES_25TO29_PUT")
                    .ColumnMappings.Add("Males30to34", "MALES_30TO34_PUT")
                    .ColumnMappings.Add("Males35to39", "MALES_35TO39_PUT")
                    .ColumnMappings.Add("Males40to44", "MALES_40TO44_PUT")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_PUT")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUT")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUT")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUT")
                    .ColumnMappings.Add("WorkingWomen18to20", "WORKING_WOMEN_18TO20_PUT")
                    .ColumnMappings.Add("WorkingWomen21to24", "WORKING_WOMEN_21TO24_PUT")
                    .ColumnMappings.Add("WorkingWomen25to34", "WORKING_WOMEN_25TO34_PUT")
                    .ColumnMappings.Add("WorkingWomen35to44", "WORKING_WOMEN_35TO44_PUT")
                    .ColumnMappings.Add("WorkingWomen45to49", "WORKING_WOMEN_45TO49_PUT")
                    .ColumnMappings.Add("WorkingWomen50to54", "WORKING_WOMEN_50TO54_PUT")
                    .ColumnMappings.Add("WorkingWomen55Plus", "WORKING_WOMEN_55PLUS_PUT")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_NATIONAL_TV_HUTPUT"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub AddNielsenNationalTVUniverse(DbContext As AdvantageFramework.Nielsen.Database.DbContext, MediaMarketBreakID As Integer,
                                                 TextLine As String, TextLine2 As String, TextLine3 As String,
                                                 ByRef NielsenNationalTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse))

            Dim NielsenNationalTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse = Nothing
            Dim EndDate As Date = Nothing
            Dim StartDate As Date = Nothing

            If Mid(TextLine, 85, 1) <> "H" Then

                Throw New Exception("Record 01 - Record Type does not equal H.")

            ElseIf Mid(TextLine, 92, 3) <> "000" Then

                Throw New Exception("Record 01 - Demo Group does not equal 000.")

            ElseIf Mid(TextLine2, 85, 1) <> "P" Then

                Throw New Exception("Record 01 - Record Type does not equal P.")

            ElseIf Mid(TextLine2, 92, 3) <> "001" Then

                Throw New Exception("Record 01 - Demo Group does not equal 001.")

            ElseIf Mid(TextLine3, 85, 1) <> "P" Then

                Throw New Exception("Record 01 - Record Type does not equal P.")

            ElseIf Mid(TextLine3, 92, 3) <> "021" Then

                Throw New Exception("Record 01 - Demo Group does not equal 021.")

            End If

            If Mid(TextLine, 51, 1) <> "1" Then

                Throw New Exception("Record 01 - Unexpectd value found for date.")

            End If

            EndDate = DateSerial(CInt(Mid(TextLine, 52, 2)), CInt(Mid(TextLine, 54, 2)), CInt(Mid(TextLine, 56, 2)))

            EndDate = GetLastSundayInAugust(EndDate)

            StartDate = GetLastSundayInAugust(EndDate.AddYears(-1)).AddDays(1)

            If Not (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse)
                    Where Entity.MediaMarketBreakID = MediaMarketBreakID AndAlso
                          Entity.EndDate = EndDate
                    Select Entity).Any Then

                NielsenNationalTVUniverse = New AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse

                NielsenNationalTVUniverse.MediaMarketBreakID = MediaMarketBreakID
                NielsenNationalTVUniverse.StartDate = StartDate
                NielsenNationalTVUniverse.EndDate = EndDate
                NielsenNationalTVUniverse.IsCorrection = CBool(Mid(TextLine, 11, 1))
                NielsenNationalTVUniverse.Household = CInt(Mid(TextLine, 180, 9))

                NielsenNationalTVUniverse.Females2to5 = CInt(Mid(TextLine2, 116, 9))
                NielsenNationalTVUniverse.Females6to8 = CInt(Mid(TextLine2, 125, 9))
                NielsenNationalTVUniverse.Females9to11 = CInt(Mid(TextLine2, 134, 9))
                NielsenNationalTVUniverse.Females12to14 = CInt(Mid(TextLine2, 143, 9))
                NielsenNationalTVUniverse.Females15to17 = CInt(Mid(TextLine2, 152, 9))
                NielsenNationalTVUniverse.Females18to20 = CInt(Mid(TextLine2, 161, 9))
                NielsenNationalTVUniverse.Females21to24 = CInt(Mid(TextLine2, 170, 9))
                NielsenNationalTVUniverse.Females25to29 = CInt(Mid(TextLine2, 179, 9))
                NielsenNationalTVUniverse.Females30to34 = CInt(Mid(TextLine2, 188, 9))
                NielsenNationalTVUniverse.Females35to39 = CInt(Mid(TextLine2, 197, 9))
                NielsenNationalTVUniverse.Females40to44 = CInt(Mid(TextLine2, 206, 9))
                NielsenNationalTVUniverse.Females45to49 = CInt(Mid(TextLine2, 215, 9))
                NielsenNationalTVUniverse.Females50to54 = CInt(Mid(TextLine2, 224, 9))
                NielsenNationalTVUniverse.Females55to64 = CInt(Mid(TextLine2, 233, 9))
                NielsenNationalTVUniverse.Females65Plus = CInt(Mid(TextLine2, 242, 9))
                NielsenNationalTVUniverse.Males2to5 = CInt(Mid(TextLine2, 251, 9))
                NielsenNationalTVUniverse.Males6to8 = CInt(Mid(TextLine2, 260, 9))
                NielsenNationalTVUniverse.Males9to11 = CInt(Mid(TextLine2, 269, 9))
                NielsenNationalTVUniverse.Males12to14 = CInt(Mid(TextLine2, 278, 9))
                NielsenNationalTVUniverse.Males15to17 = CInt(Mid(TextLine2, 287, 9))

                NielsenNationalTVUniverse.Males18to20 = CInt(Mid(TextLine3, 116, 9))
                NielsenNationalTVUniverse.Males21to24 = CInt(Mid(TextLine3, 125, 9))
                NielsenNationalTVUniverse.Males25to29 = CInt(Mid(TextLine3, 134, 9))
                NielsenNationalTVUniverse.Males30to34 = CInt(Mid(TextLine3, 143, 9))
                NielsenNationalTVUniverse.Males35to39 = CInt(Mid(TextLine3, 152, 9))
                NielsenNationalTVUniverse.Males40to44 = CInt(Mid(TextLine3, 161, 9))
                NielsenNationalTVUniverse.Males45to49 = CInt(Mid(TextLine3, 170, 9))
                NielsenNationalTVUniverse.Males50to54 = CInt(Mid(TextLine3, 179, 9))
                NielsenNationalTVUniverse.Males55to64 = CInt(Mid(TextLine3, 188, 9))
                NielsenNationalTVUniverse.Males65Plus = CInt(Mid(TextLine3, 197, 9))
                NielsenNationalTVUniverse.WorkingWomen18to20 = CInt(Mid(TextLine3, 224, 9))
                NielsenNationalTVUniverse.WorkingWomen21to24 = CInt(Mid(TextLine3, 233, 9))
                NielsenNationalTVUniverse.WorkingWomen25to34 = CInt(Mid(TextLine3, 242, 9))
                NielsenNationalTVUniverse.WorkingWomen35to44 = CInt(Mid(TextLine3, 251, 9))
                NielsenNationalTVUniverse.WorkingWomen45to49 = CInt(Mid(TextLine3, 260, 9))
                NielsenNationalTVUniverse.WorkingWomen50to54 = CInt(Mid(TextLine3, 269, 9))
                NielsenNationalTVUniverse.WorkingWomen55Plus = CInt(Mid(TextLine3, 278, 9))

                NielsenNationalTVUniverses.Add(NielsenNationalTVUniverse)

            End If

        End Sub
        Private Sub BulkInsertNielsenNationalTVUniverseList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                            NielsenNationalTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenNationalTVUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("MediaMarketBreakID", "MEDIA_MARKET_BREAK_ID")
                    .ColumnMappings.Add("IsCorrection", "IS_CORRECTION")
                    .ColumnMappings.Add("StartDate", "START_DATE")
                    .ColumnMappings.Add("EndDate", "END_DATE")
                    .ColumnMappings.Add("Household", "HOUSEHOLD_UE")
                    .ColumnMappings.Add("Females2to5", "FEMALES_2TO5_UE")
                    .ColumnMappings.Add("Females6to8", "FEMALES_6TO8_UE")
                    .ColumnMappings.Add("Females9to11", "FEMALES_9TO11_UE")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14_UE")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17_UE")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_UE")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_UE")
                    .ColumnMappings.Add("Females25to29", "FEMALES_25TO29_UE")
                    .ColumnMappings.Add("Females30to34", "FEMALES_30TO34_UE")
                    .ColumnMappings.Add("Females35to39", "FEMALES_35TO39_UE")
                    .ColumnMappings.Add("Females40to44", "FEMALES_40TO44_UE")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_UE")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_UE")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_UE")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_UE")
                    .ColumnMappings.Add("Males2to5", "MALES_2TO5_UE")
                    .ColumnMappings.Add("Males6to8", "MALES_6TO8_UE")
                    .ColumnMappings.Add("Males9to11", "MALES_9TO11_UE")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14_UE")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17_UE")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_UE")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_UE")
                    .ColumnMappings.Add("Males25to29", "MALES_25TO29_UE")
                    .ColumnMappings.Add("Males30to34", "MALES_30TO34_UE")
                    .ColumnMappings.Add("Males35to39", "MALES_35TO39_UE")
                    .ColumnMappings.Add("Males40to44", "MALES_40TO44_UE")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_UE")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_UE")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_UE")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_UE")
                    .ColumnMappings.Add("WorkingWomen18to20", "WORKING_WOMEN_18TO20_UE")
                    .ColumnMappings.Add("WorkingWomen21to24", "WORKING_WOMEN_21TO24_UE")
                    .ColumnMappings.Add("WorkingWomen25to34", "WORKING_WOMEN_25TO34_UE")
                    .ColumnMappings.Add("WorkingWomen35to44", "WORKING_WOMEN_35TO44_UE")
                    .ColumnMappings.Add("WorkingWomen45to49", "WORKING_WOMEN_45TO49_UE")
                    .ColumnMappings.Add("WorkingWomen50to54", "WORKING_WOMEN_50TO54_UE")
                    .ColumnMappings.Add("WorkingWomen55Plus", "WORKING_WOMEN_55PLUS_UE")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_NATIONAL_TV_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Public Function ProcessNationalFile(ConnectionString As String, ByVal PathFile As String) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim Path As String = Nothing
            Dim File As String = Nothing
            Dim SqlTransaction As SqlClient.SqlTransaction = Nothing
            Dim MediaMarketBreak As AdvantageFramework.Nielsen.Database.Entities.MediaMarketBreak = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim FilenameFields() As String = Nothing
            Dim FilePrefix As String = Nothing
            Dim Stream As String = Nothing
            Dim TextLine As String = Nothing
            Dim TextLine2 As String = Nothing
            Dim TextLine3 As String = Nothing
            Dim TextTemp As String = Nothing
            Dim RecordSeqCode As String = Nothing
            Dim RecordType As String = Nothing
            Dim ViewingTypes As IEnumerable(Of String) = Nothing
            Dim TimeType As String = Nothing
            Dim IsOvernight As Boolean = False
            Dim NielsenNationalTVUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse) = Nothing
            Dim NielsenNationalTVHutputs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput) = Nothing
            Dim NielsenNationalTVAudiences As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience) = Nothing
            Dim NationalAudienceLines As AdvantageFramework.Services.Nielsen.Classes.NationalAudienceLines = Nothing

            ViewingTypes = {" ", "2", "4", "6", "8", "A"}

            Path = System.IO.Path.GetDirectoryName(PathFile)
            File = System.IO.Path.GetFileName(PathFile)

            If System.IO.File.Exists(PathFile) Then

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    Using SqlConnection As New SqlClient.SqlConnection(ConnectionString)

                        Try

                            SqlConnection.Open()

                            SqlTransaction = SqlConnection.BeginTransaction

                            MediaMarketBreak = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.MediaMarketBreak).Where(Function(MMB) MMB.BroadcastTypeID = AdvantageFramework.Nielsen.Database.Entities.BroadcastTypeID.NetworkTV AndAlso
                                                                                                                                                        MMB.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen AndAlso
                                                                                                                                                        MMB.Name = "All PP").SingleOrDefault

                            If MediaMarketBreak Is Nothing Then

                                Throw New Exception("Cannot find expected media market break record.")

                            End If

                            StreamReader = New System.IO.StreamReader(PathFile)

                            FilenameFields = Mid(File.ToUpper, 1, InStr(File, ".") - 1).Split("_")

                            FilePrefix = Mid(FilenameFields(0), InStrRev(FilenameFields(0), "\") + 1)

                            Stream = Mid(File.ToUpper, InStrRev(File, ".") - 2, 2)

                            TimeType = "P"

                            For Each FilenameField In FilenameFields

                                If InStr(FilenameField, "ACM") > 0 OrElse InStr(FilenameField, "CPAGENCY") > 0 Then

                                    TimeType = "C"

                                End If

                            Next

                            NielsenNationalTVUniverses = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVUniverse)
                            NielsenNationalTVHutputs = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVHutput)
                            NielsenNationalTVAudiences = New List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience)

                            Do While StreamReader.Peek() <> -1

                                TextLine = StreamReader.ReadLine()

                                RecordSeqCode = Mid(TextLine, 1, 2)

                                Select Case RecordSeqCode

                                    Case "01"

                                        If FilePrefix = "NTI" Then

                                            TextLine2 = StreamReader.ReadLine()
                                            TextLine3 = StreamReader.ReadLine()

                                            AddNielsenNationalTVUniverse(DbContext, MediaMarketBreak.ID, TextLine, TextLine2, TextLine3, NielsenNationalTVUniverses)

                                        End If

                                    Case "03"

                                        If FilePrefix = "NTI" Then

                                            If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 92, 3) = "000" AndAlso Mid(TextLine, 85, 1) = "H" AndAlso Mid(TextLine, 42, 2) = "00" Then

                                                TextLine2 = Nothing
                                                TextLine3 = Nothing

                                                Do

                                                    TextTemp = StreamReader.ReadLine()

                                                    RecordSeqCode = Mid(TextTemp, 1, 2)

                                                    If ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 3) = "001" AndAlso RecordSeqCode = "03" AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso Mid(TextTemp, 42, 2) = "00" Then

                                                        TextLine2 = TextTemp

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextTemp, 97, 1)) AndAlso Mid(TextTemp, 92, 3) = "021" AndAlso RecordSeqCode = "03" AndAlso Mid(TextTemp, 85, 1) = "P" AndAlso Mid(TextTemp, 42, 2) = "00" Then

                                                        TextLine3 = TextTemp

                                                    End If

                                                Loop Until (TextLine2 IsNot Nothing AndAlso TextLine3 IsNot Nothing) OrElse StreamReader.Peek() = -1 OrElse RecordSeqCode <> "03"

                                                If TextLine IsNot Nothing AndAlso TextLine2 IsNot Nothing AndAlso TextLine3 IsNot Nothing Then

                                                    AddNielsenNationalTVHutput(DbContext, MediaMarketBreak.ID, TextLine, TextLine2, TextLine3, TimeType, Stream, NielsenNationalTVHutputs)

                                                Else

                                                    Throw New Exception("Could not find complete sequence of record type 03.")

                                                End If

                                            End If

                                        End If

                                    Case "04"

                                        If TimeType = "P" Then

                                            If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" Then

                                                If Mid(TextLine, 11, 1) = "2" Then 'deletion

                                                    DeleteNationalTVAudience(DbContext, TextLine)

                                                ElseIf Mid(TextLine, 85, 1) = "D" AndAlso Mid(TextLine, 92, 3) = "000" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                    If NationalAudienceLines IsNot Nothing Then

                                                        If FilenameFields.Contains("O") Then

                                                            IsOvernight = True

                                                        End If

                                                        AddNielsenNationalTVAudience(DbContext, MediaMarketBreak.ID, NationalAudienceLines.MainLine, NationalAudienceLines.P0010, NationalAudienceLines.P0210, NationalAudienceLines.P0011, NationalAudienceLines.P0211, TimeType, Stream, FilePrefix, IsOvernight, NielsenNationalTVAudiences)

                                                    End If

                                                    NationalAudienceLines = New AdvantageFramework.Services.Nielsen.Classes.NationalAudienceLines

                                                    NationalAudienceLines.MainLine = TextLine

                                                Else

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "001" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                        NationalAudienceLines.P0010 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "021" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                        NationalAudienceLines.P0210 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "001" AndAlso Mid(TextLine, 95, 1) = "1" Then

                                                        NationalAudienceLines.P0011 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "021" AndAlso Mid(TextLine, 95, 1) = "1" Then

                                                        NationalAudienceLines.P0211 = TextLine

                                                    End If

                                                End If

                                            End If

                                        End If

                                    Case "06"

                                        If TimeType <> "P" Then

                                            If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" Then

                                                If Mid(TextLine, 11, 1) = "2" Then 'deletion

                                                    DeleteNationalTVAudience(DbContext, TextLine)

                                                ElseIf Mid(TextLine, 85, 1) = "C" AndAlso Mid(TextLine, 92, 3) = "000" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                    If NationalAudienceLines IsNot Nothing Then

                                                        If FilenameFields.Contains("O") Then

                                                            IsOvernight = True

                                                        End If

                                                        AddNielsenNationalTVAudience(DbContext, MediaMarketBreak.ID, NationalAudienceLines.MainLine, NationalAudienceLines.P0010, NationalAudienceLines.P0210, NationalAudienceLines.P0011, NationalAudienceLines.P0211, TimeType, Stream, FilePrefix, IsOvernight, NielsenNationalTVAudiences)

                                                    End If

                                                    NationalAudienceLines = New AdvantageFramework.Services.Nielsen.Classes.NationalAudienceLines

                                                    NationalAudienceLines.MainLine = TextLine

                                                Else

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "001" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                        NationalAudienceLines.P0010 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "021" AndAlso Mid(TextLine, 95, 1) = "0" Then

                                                        NationalAudienceLines.P0210 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "001" AndAlso Mid(TextLine, 95, 1) = "1" Then

                                                        NationalAudienceLines.P0011 = TextLine

                                                    End If

                                                    If ViewingTypes.Contains(Mid(TextLine, 97, 1)) AndAlso Mid(TextLine, 37, 1) = "1" AndAlso Mid(TextLine, 42, 2) = "00" AndAlso Mid(TextLine, 81, 2) = "00" AndAlso Mid(TextLine, 85, 1) = "P" AndAlso
                                                            Mid(TextLine, 92, 3) = "021" AndAlso Mid(TextLine, 95, 1) = "1" Then

                                                        NationalAudienceLines.P0211 = TextLine

                                                    End If

                                                End If

                                            End If

                                        End If

                                End Select

                            Loop

                            BulkInsertNielsenNationalTVUniverseList(SqlConnection, SqlTransaction, NielsenNationalTVUniverses)
                            BulkInsertNielsenNationalTVHutputList(SqlConnection, SqlTransaction, NielsenNationalTVHutputs)
                            BulkInsertNielsenNationalTVAudienceList(SqlConnection, SqlTransaction, NielsenNationalTVAudiences)

                            SqlTransaction.Commit()

                            Processed = True

                        Catch ex As Exception

                            SqlTransaction.Rollback()

                            Throw New Exception(ex.Message & " Filename:" & PathFile)

                            'WriteToEventLog("Nielsen Import: ProcessFile: " & ex.Message)

                        Finally

                            If SqlConnection.State = ConnectionState.Open Then

                                SqlConnection.Close()

                            End If

                            StreamReader.Close()

                        End Try

                    End Using

                End Using

            End If

            ProcessNationalFile = Processed

        End Function

#End Region

#Region " Radio Data "

        Private Sub BulkInsertNielsenRadioIntabList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                    NielsenRadioIntabs As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioIntabs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("SegmentParentID", "NIELSEN_RADIO_SEGMENT_PARENT_ID")
                    .ColumnMappings.Add("Females6to11", "FEMALES_6TO11_INTAB")
                    .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_INTAB")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_INTAB")
                    .ColumnMappings.Add("Females18to24", "FEMALES_18TO24_INTAB")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_INTAB")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_INTAB")
                    .ColumnMappings.Add("Females35to44", "FEMALES_35TO44_INTAB")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_INTAB")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_INTAB")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_INTAB")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_INTAB")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_INTAB")
                    .ColumnMappings.Add("Males6to11", "MALES_6TO11_INTAB")
                    .ColumnMappings.Add("Males12to17", "MALES_12TO17_INTAB")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_INTAB")
                    .ColumnMappings.Add("Males18to24", "MALES_18TO24_INTAB")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_INTAB")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_INTAB")
                    .ColumnMappings.Add("Males35to44", "MALES_35TO44_INTAB")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_INTAB")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_INTAB")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_INTAB")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_INTAB")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_INTAB")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_INTAB"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioUniverseList(SqlConnection As SqlClient.SqlConnection, SqlTransaction As SqlClient.SqlTransaction,
                                                       NielsenRadioUniverses As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection, SqlClient.SqlBulkCopyOptions.CheckConstraints, SqlTransaction)

                With SqlBulkCopy

                    .ColumnMappings.Add("SegmentParentID", "NIELSEN_RADIO_SEGMENT_PARENT_ID")
                    .ColumnMappings.Add("Females6to11", "FEMALES_6TO11_UE")
                    .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_UE")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_UE")
                    .ColumnMappings.Add("Females18to24", "FEMALES_18TO24_UE")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_UE")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_UE")
                    .ColumnMappings.Add("Females35to44", "FEMALES_35TO44_UE")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_UE")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_UE")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_UE")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_UE")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_UE")
                    .ColumnMappings.Add("Males6to11", "MALES_6TO11_UE")
                    .ColumnMappings.Add("Males12to17", "MALES_12TO17_UE")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_UE")
                    .ColumnMappings.Add("Males18to24", "MALES_18TO24_UE")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_UE")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_UE")
                    .ColumnMappings.Add("Males35to44", "MALES_35TO44_UE")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_UE")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_UE")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_UE")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_UE")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_UE")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioVStagingsList(SqlConnection As SqlClient.SqlConnection,
                                                        NielsenRadioVStagings As List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioVStagings.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.CheckConstraints)

                With SqlBulkCopy

                    .ColumnMappings.Add("GeoIndicator", "GEO_INDICATOR")
                    .ColumnMappings.Add("EstimateType", "ESTIMATE_TYPE")
                    .ColumnMappings.Add("Daypart", "DAYPART")
                    .ColumnMappings.Add("ListeningLocation", "LISTENING_LOCATION")
                    .ColumnMappings.Add("DemoID", "DEMO_ID")
                    .ColumnMappings.Add("StationComboType", "STATION_COMBO_TYPE")
                    .ColumnMappings.Add("StationComboID", "STATION_COMBO_ID")
                    .ColumnMappings.Add("PurAud", "PUR_AUD")
                    .ColumnMappings.Add("NielsenRadioSegmentChildID", "NIELSEN_RADIO_SEGMENT_CHILD_ID")
                    .ColumnMappings.Add("NielsenRadioDaypartID", "NIELSEN_RADIO_DAYPART_ID")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_V_STAGING"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub CreateRadioSegmentParentRecords(DbContext As AdvantageFramework.Nielsen.Database.DbContext, NielsenRadioPeriodID As Integer, GeoIndicator As Short)

            Dim NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative = Nothing
            Dim NielsenRadioSegmentParent As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent = Nothing

            For Each QualitativeCode In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic).Select(Function(NRD) NRD.QualitativeCode).Distinct.ToList

                If String.IsNullOrWhiteSpace(QualitativeCode) Then

                    QualitativeCode = BLANK_QUALITATIVE_CODE

                End If

                NielsenRadioQualitative = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative).Where(Function(Q) Q.Code = QualitativeCode).FirstOrDefault

                If NielsenRadioQualitative Is Nothing Then

                    Throw New Exception("Cannot find Nielsen Radio Qualitative code.")

                End If

                NielsenRadioSegmentParent = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent)
                                             Where Entity.NielsenRadioPeriodID = NielsenRadioPeriodID AndAlso
                                                   Entity.GeoIndicator = GeoIndicator AndAlso
                                                   Entity.NielsenRadioQualitativeID = NielsenRadioQualitative.ID
                                             Select Entity).FirstOrDefault

                If NielsenRadioSegmentParent Is Nothing Then

                    NielsenRadioSegmentParent = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent
                    NielsenRadioSegmentParent.DbContext = DbContext

                    NielsenRadioSegmentParent.NielsenRadioPeriodID = NielsenRadioPeriodID
                    NielsenRadioSegmentParent.GeoIndicator = GeoIndicator
                    NielsenRadioSegmentParent.NielsenRadioQualitativeID = NielsenRadioQualitative.ID

                    DbContext.NielsenRadioSegmentParents.Add(NielsenRadioSegmentParent)
                    DbContext.SaveChanges()

                End If

            Next

        End Sub
        Private Function GetIntabStagingValue(RadioIntabStagingList As Generic.List(Of AdvantageFramework.Services.Nielsen.Classes.RadioIntabStaging),
                                              GeoIndicator As Short, DemoID As Integer) As Integer

            Dim RadioIntabStaging As AdvantageFramework.Services.Nielsen.Classes.RadioIntabStaging = Nothing
            Dim Intab As Integer = 0

            RadioIntabStaging = (From AH In RadioIntabStagingList.AsParallel
                                 Where AH.GeoIndicator = GeoIndicator AndAlso
                                       AH.DemoID = DemoID
                                 Select AH).SingleOrDefault

            If RadioIntabStaging IsNot Nothing Then

                Intab = RadioIntabStaging.Intab

            End If

            GetIntabStagingValue = Intab

        End Function
        Private Function GetUniverseStagingValue(RadioUniverseStagingList As Generic.List(Of AdvantageFramework.Services.Nielsen.Classes.RadioUniverseStaging),
                                                 GeoIndicator As Short, DemoID As Integer) As Integer

            Dim RadioUniverseStaging As AdvantageFramework.Services.Nielsen.Classes.RadioUniverseStaging = Nothing
            Dim Universe As Integer = 0

            RadioUniverseStaging = (From AH In RadioUniverseStagingList.AsParallel
                                    Where AH.GeoIndicator = GeoIndicator AndAlso
                                          AH.DemoID = DemoID
                                    Select AH).SingleOrDefault

            If RadioUniverseStaging IsNot Nothing Then

                Universe = RadioUniverseStaging.Universe

            End If

            GetUniverseStagingValue = Universe

        End Function
        Private Sub ProcessARecord(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String,
                                   ByRef NielsenRadioPeriodID As Integer)

            Dim NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod = Nothing
            Dim NielsenRadioMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket = Nothing

            NielsenRadioPeriod = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod)
                                  Where Entity.NielsenRadioReportTypeCode = Mid(TextLine, 2, 2).Trim AndAlso
                                        Entity.NielsenPeriodID = CInt(Mid(TextLine, 4, 6)) AndAlso
                                        Entity.NielsenRadioMarketNumber = CInt(Mid(TextLine, 10, 3))
                                  Select Entity).SingleOrDefault

            If NielsenRadioPeriod Is Nothing Then

                NielsenRadioPeriod = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod
                NielsenRadioPeriod.DbContext = DbContext

                NielsenRadioPeriod.NielsenRadioReportTypeCode = Mid(TextLine, 2, 2).Trim
                NielsenRadioPeriod.NielsenPeriodID = Mid(TextLine, 4, 6)
                NielsenRadioPeriod.NielsenRadioMarketNumber = CInt(Mid(TextLine, 10, 3))
                NielsenRadioPeriod.ShortName = Mid(TextLine, 13, 6).Trim
                NielsenRadioPeriod.Name = Mid(TextLine, 19, 36).Trim
                NielsenRadioPeriod.StartDate = Mid(TextLine, 55, 11)
                NielsenRadioPeriod.EndDate = Mid(TextLine, 66, 11)
                NielsenRadioPeriod.StandardCondensedIndicator = Mid(TextLine, 109, 1)

                DbContext.NielsenRadioPeriods.Add(NielsenRadioPeriod)
                DbContext.SaveChanges()

            End If

            NielsenRadioPeriodID = NielsenRadioPeriod.ID

            NielsenRadioMarket = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket)
                                  Where Entity.Number = CInt(Mid(TextLine, 10, 3).Trim)
                                  Select Entity).SingleOrDefault

            If NielsenRadioMarket Is Nothing Then

                NielsenRadioMarket = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket
                NielsenRadioMarket.DbContext = DbContext

                NielsenRadioMarket.Number = CInt(Mid(TextLine, 10, 3).Trim)
                NielsenRadioMarket.Name = Mid(TextLine, 77, 32).Trim

                DbContext.NielsenRadioMarkets.Add(NielsenRadioMarket)
                DbContext.SaveChanges()

            End If

        End Sub
        Private Sub ProcessDRecord(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String)

            Dim NielsenRadioDemographic As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic = Nothing
            Dim NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative = Nothing
            Dim QualitativeCode As String = Nothing
            Dim FullName As String = Nothing

            NielsenRadioDemographic = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic).Where(Function(D) D.Number = CInt(Mid(TextLine, 4, 6))).SingleOrDefault

            If NielsenRadioDemographic Is Nothing Then

                NielsenRadioDemographic = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic
                NielsenRadioDemographic.DbContext = DbContext

                NielsenRadioDemographic.Number = Mid(TextLine, 4, 6)
                NielsenRadioDemographic.Name = Mid(TextLine, 10, 50).Trim
                NielsenRadioDemographic.AgeSexCode = Mid(TextLine, 60, 10).Trim
                NielsenRadioDemographic.QualitativeCode = If(String.IsNullOrWhiteSpace(Mid(TextLine, 70, 10).Trim), BLANK_QUALITATIVE_CODE, Mid(TextLine, 70, 10).Trim)

                DbContext.NielsenRadioDemographics.Add(NielsenRadioDemographic)
                DbContext.SaveChanges()

            End If

            QualitativeCode = Mid(TextLine, 70, 10).Trim

            If String.IsNullOrWhiteSpace(QualitativeCode) Then

                QualitativeCode = BLANK_QUALITATIVE_CODE

            End If

            NielsenRadioQualitative = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative).Where(Function(D) D.Code = QualitativeCode).SingleOrDefault

            If NielsenRadioQualitative Is Nothing Then

                NielsenRadioQualitative = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative
                NielsenRadioQualitative.DbContext = DbContext

                NielsenRadioQualitative.Code = QualitativeCode

                If QualitativeCode = BLANK_QUALITATIVE_CODE Then

                    NielsenRadioQualitative.Name = BLANK_QUALITATIVE_CODE

                Else

                    FullName = Mid(TextLine, 10, 50).Trim
                    NielsenRadioQualitative.Name = Mid(FullName, InStr(FullName, ", ") + 2)

                End If

                DbContext.NielsenRadioQualitatives.Add(NielsenRadioQualitative)
                DbContext.SaveChanges()

            End If

        End Sub
        Private Sub ProcessJRecord(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String)

            Dim NielsenRadioStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation = Nothing
            Dim NielsenRadioMarketNumber As Integer = 0
            Dim ComboID As Integer = 0
            Dim NielsenRadioStationHistory As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory = Nothing
            Dim ErrorMessage As String = Nothing

            If Mid(TextLine, 16, 6).Trim <> "999999" Then

                NielsenRadioMarketNumber = CInt(Mid(TextLine, 10, 3))
                ComboID = CInt(Mid(TextLine, 16, 6))

                NielsenRadioStation = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.Load(DbContext)
                                       Where Entity.NielsenRadioMarketNumber = NielsenRadioMarketNumber AndAlso
                                             Entity.ComboID = ComboID
                                       Select Entity).SingleOrDefault

                If NielsenRadioStation IsNot Nothing Then

                    If Mid(TextLine, 58, 1) = "+" Then

                        NielsenRadioStationHistory = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory
                        NielsenRadioStationHistory.DbContext = DbContext

                        NielsenRadioStationHistory.NielsenRadioMarketNumber = NielsenRadioStation.NielsenRadioMarketNumber
                        NielsenRadioStationHistory.ComboID = NielsenRadioStation.ComboID
                        NielsenRadioStationHistory.Name = NielsenRadioStation.Name
                        NielsenRadioStationHistory.CallLetters = NielsenRadioStation.CallLetters
                        NielsenRadioStationHistory.Band = NielsenRadioStation.Band
                        NielsenRadioStationHistory.Frequency = NielsenRadioStation.Frequency
                        NielsenRadioStationHistory.ComboType = NielsenRadioStation.ComboType
                        NielsenRadioStationHistory.IsSpillin = NielsenRadioStation.IsSpillin
                        NielsenRadioStationHistory.NielsenRadioFormatCode = NielsenRadioStation.NielsenRadioFormatCode

                        DbContext.NielsenRadioStationHistorys.Add(NielsenRadioStationHistory)
                        DbContext.SaveChanges()

                    End If

                    NielsenRadioStation.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                    NielsenRadioStation.ComboID = ComboID
                    NielsenRadioStation.Name = Mid(TextLine, 22, 30).Trim
                    NielsenRadioStation.CallLetters = Mid(TextLine, 52, 4).Trim
                    NielsenRadioStation.Band = Mid(TextLine, 56, 2).Trim
                    NielsenRadioStation.Frequency = Mid(TextLine, 59, 5).Trim
                    NielsenRadioStation.ComboType = CShort(Mid(TextLine, 14, 2))
                    NielsenRadioStation.IsSpillin = If(Mid(TextLine, 69, 1) = "1", True, False)
                    NielsenRadioStation.NielsenRadioFormatCode = Mid(TextLine, 64, 4).Trim

                    If AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.Update(DbContext, NielsenRadioStation, ErrorMessage) = False Then

                        Throw New Exception(ErrorMessage)

                    End If

                End If

                If NielsenRadioStation Is Nothing Then

                    NielsenRadioStation = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation
                    NielsenRadioStation.DbContext = DbContext

                    NielsenRadioStation.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                    NielsenRadioStation.ComboID = ComboID
                    NielsenRadioStation.Name = Mid(TextLine, 22, 30).Trim
                    NielsenRadioStation.CallLetters = Mid(TextLine, 52, 4).Trim
                    NielsenRadioStation.Band = Mid(TextLine, 56, 2).Trim
                    NielsenRadioStation.Frequency = Mid(TextLine, 59, 5).Trim
                    NielsenRadioStation.ComboType = CShort(Mid(TextLine, 14, 2))
                    NielsenRadioStation.IsSpillin = If(Mid(TextLine, 69, 1) = "1", True, False)
                    NielsenRadioStation.NielsenRadioFormatCode = Mid(TextLine, 64, 4).Trim

                    DbContext.NielsenRadioStations.Add(NielsenRadioStation)
                    DbContext.SaveChanges()

                End If

            End If

        End Sub
        'Private Sub ProcessSRecord(DbContext As AdvantageFramework.Nielsen.Database.DbContext, TextLine As String)

        '    Dim NielsenRadioDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart = Nothing
        '    Dim NielsenDaypartID As Short = 0

        '    NielsenDaypartID = CShort(Mid(TextLine, 4, 4))

        '    NielsenRadioDaypart = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart).Where(Function(D) D.NielsenDaypartID = NielsenDaypartID).SingleOrDefault

        '    If NielsenRadioDaypart Is Nothing Then

        '        NielsenRadioDaypart = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart
        '        NielsenRadioDaypart.DbContext = DbContext

        '        NielsenRadioDaypart.NielsenDaypartID = NielsenDaypartID
        '        NielsenRadioDaypart.Name = Mid(TextLine, 8, 30).Trim
        '        NielsenRadioDaypart.NumberOfQuarterhours = CShort(Mid(TextLine, 38, 3))

        '        DbContext.NielsenRadioDayparts.Add(NielsenRadioDaypart)
        '        DbContext.SaveChanges()

        '    End If

        'End Sub
        Private Sub ProcessIntabStaging(DbContext As AdvantageFramework.Nielsen.Database.DbContext, NielsenRadioPeriodID As Integer, GeoIndicator As Short,
                                        RadioIntabStagingList As Generic.List(Of AdvantageFramework.Services.Nielsen.Classes.RadioIntabStaging),
                                        ByRef NielsenRadioIntabs As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab))

            Dim NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative = Nothing
            Dim NielsenRadioSegmentParent As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent = Nothing
            Dim NielsenRadioIntab As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab = Nothing

            For Each QualitativeCode In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic).Select(Function(NRD) NRD.QualitativeCode).Distinct.ToList

                If String.IsNullOrWhiteSpace(QualitativeCode) Then

                    QualitativeCode = BLANK_QUALITATIVE_CODE

                End If

                NielsenRadioQualitative = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative).Where(Function(Q) Q.Code = QualitativeCode).FirstOrDefault

                If NielsenRadioQualitative Is Nothing Then

                    Throw New Exception("Cannot find Nielsen Radio Qualitative code.")

                End If

                NielsenRadioSegmentParent = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent)
                                             Where Entity.NielsenRadioPeriodID = NielsenRadioPeriodID AndAlso
                                                   Entity.GeoIndicator = GeoIndicator AndAlso
                                                   Entity.NielsenRadioQualitativeID = NielsenRadioQualitative.ID
                                             Select Entity).FirstOrDefault

                If NielsenRadioSegmentParent Is Nothing Then

                    Throw New Exception("Cannot find NielsenRadioSegmentParent record.")

                End If

                NielsenRadioIntab = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab
                NielsenRadioIntab.DbContext = DbContext
                NielsenRadioIntab.ZeroAllValues()

                NielsenRadioIntab.SegmentParentID = NielsenRadioSegmentParent.ID

                Select Case QualitativeCode

                    Case BLANK_QUALITATIVE_CODE

                        NielsenRadioIntab.Males12to17 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 1)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 3)
                        NielsenRadioIntab.Males35to44 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 4)
                        NielsenRadioIntab.Males45to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 5)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 6)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 7)
                        NielsenRadioIntab.Females12to17 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 8)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 10)
                        NielsenRadioIntab.Females35to44 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 11)
                        NielsenRadioIntab.Females45to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 12)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 13)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 14)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 15)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 82)
                        NielsenRadioIntab.Males6to11 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 251)
                        NielsenRadioIntab.Males18to20 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 254)
                        NielsenRadioIntab.Males21to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 255)
                        NielsenRadioIntab.Females6to11 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 264)
                        NielsenRadioIntab.Females18to20 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 267)
                        NielsenRadioIntab.Females21to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 268)

                    Case "CHILDREN"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 448)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 461)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 479)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 488)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 501)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 514)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 533)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 544)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 561)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 570)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 583)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 596)

                    Case "COLLEGE +"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 441)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 455)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 469)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 483)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 496)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 509)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 526)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 539)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 552)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 565)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 578)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 591)

                    Case "HH SIZE 1"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 449)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 463)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 473)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 490)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 503)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 516)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 534)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 546)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 556)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 572)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 585)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 598)

                    Case "HH SIZE 2"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 450)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 464)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 474)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 491)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 504)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 517)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 530)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 531)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 547)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 573)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 586)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 599)

                    Case "HH SIZE 3"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 451)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 465)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 475)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 492)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 505)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 518)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 535)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 548)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 557)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 574)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 587)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 600)

                    Case "HH SIZE 4+"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 452)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 466)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 476)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 493)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 506)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 519)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 536)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 549)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 558)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 575)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 588)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 601)

                    Case "HS GRAD"

                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 453)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 467)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 481)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 494)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 507)
                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 520)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 537)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 550)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 563)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 576)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 589)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 602)

                    Case "INC $75K+"

                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 460)
                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 472)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 478)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 487)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 500)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 513)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 541)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 555)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 560)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 569)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 582)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 595)

                    Case "INC <$25K"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 442)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 456)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 470)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 484)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 497)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 510)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 527)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 540)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 553)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 566)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 579)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 592)

                    Case "INC 25-49K"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 443)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 458)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 471)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 485)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 498)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 511)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 528)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 542)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 554)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 567)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 580)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 593)

                    Case "INC 50-74K"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 444)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 459)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 477)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 486)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 499)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 512)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 529)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 543)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 559)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 568)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 581)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 594)

                    Case "NO CHILDRN"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 447)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 462)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 480)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 489)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 502)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 515)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 532)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 545)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 562)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 571)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 584)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 597)

                    Case "SOME COLL"

                        NielsenRadioIntab.Males18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 440)
                        NielsenRadioIntab.Males25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 454)
                        NielsenRadioIntab.Males35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 468)
                        NielsenRadioIntab.Males50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 482)
                        NielsenRadioIntab.Males55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 495)
                        NielsenRadioIntab.Males65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 508)
                        NielsenRadioIntab.Females18to24 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 524)
                        NielsenRadioIntab.Females25to34 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 538)
                        NielsenRadioIntab.Females35to49 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 551)
                        NielsenRadioIntab.Females50to54 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 564)
                        NielsenRadioIntab.Females55to64 = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 577)
                        NielsenRadioIntab.Females65Plus = GetIntabStagingValue(RadioIntabStagingList, GeoIndicator, 590)

                End Select

                NielsenRadioIntabs.Add(NielsenRadioIntab)

            Next

        End Sub
        Private Sub ProcessUniverseStaging(DbContext As AdvantageFramework.Nielsen.Database.DbContext, NielsenRadioPeriodID As Integer, GeoIndicator As Short,
                                           RadioUniverseStagingList As Generic.List(Of AdvantageFramework.Services.Nielsen.Classes.RadioUniverseStaging),
                                           ByRef NielsenRadioUniverses As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse))

            Dim NielsenRadioUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse = Nothing
            Dim NielsenRadioSegmentParent As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent = Nothing
            Dim NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative = Nothing

            For Each QualitativeCode In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic).Select(Function(NRD) NRD.QualitativeCode).Distinct.ToList

                If String.IsNullOrWhiteSpace(QualitativeCode) Then

                    QualitativeCode = BLANK_QUALITATIVE_CODE

                End If

                NielsenRadioQualitative = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative).Where(Function(Q) Q.Code = QualitativeCode).FirstOrDefault

                If NielsenRadioQualitative Is Nothing Then

                    Throw New Exception("Cannot find Nielsen Radio Qualitative code.")

                End If

                NielsenRadioSegmentParent = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioSegmentParent)
                                             Where Entity.NielsenRadioPeriodID = NielsenRadioPeriodID AndAlso
                                                   Entity.GeoIndicator = GeoIndicator AndAlso
                                                   Entity.NielsenRadioQualitativeID = NielsenRadioQualitative.ID
                                             Select Entity).FirstOrDefault

                If NielsenRadioSegmentParent Is Nothing Then

                    Throw New Exception("Cannot find NielsenRadioSegmentParent record.")

                End If

                NielsenRadioUniverse = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse
                NielsenRadioUniverse.DbContext = DbContext
                NielsenRadioUniverse.ZeroAllValues()

                NielsenRadioUniverse.SegmentParentID = NielsenRadioSegmentParent.ID

                Select Case QualitativeCode

                    Case BLANK_QUALITATIVE_CODE

                        NielsenRadioUniverse.Males12to17 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 1)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 3)
                        NielsenRadioUniverse.Males35to44 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 4)
                        NielsenRadioUniverse.Males45to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 5)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 6)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 7)
                        NielsenRadioUniverse.Females12to17 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 8)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 10)
                        NielsenRadioUniverse.Females35to44 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 11)
                        NielsenRadioUniverse.Females45to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 12)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 13)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 14)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 15)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 82)
                        NielsenRadioUniverse.Males6to11 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 251)
                        NielsenRadioUniverse.Males18to20 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 254)
                        NielsenRadioUniverse.Males21to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 255)
                        NielsenRadioUniverse.Females6to11 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 264)
                        NielsenRadioUniverse.Females18to20 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 267)
                        NielsenRadioUniverse.Females21to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 268)

                    Case "CHILDREN"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 448)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 461)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 479)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 488)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 501)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 514)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 533)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 544)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 561)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 570)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 583)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 596)

                    Case "COLLEGE +"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 441)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 455)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 469)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 483)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 496)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 509)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 526)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 539)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 552)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 565)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 578)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 591)

                    Case "HH SIZE 1"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 449)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 463)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 473)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 490)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 503)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 516)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 534)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 546)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 556)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 572)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 585)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 598)

                    Case "HH SIZE 2"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 450)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 464)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 474)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 491)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 504)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 517)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 530)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 531)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 547)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 573)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 586)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 599)

                    Case "HH SIZE 3"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 451)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 465)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 475)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 492)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 505)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 518)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 535)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 548)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 557)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 574)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 587)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 600)

                    Case "HH SIZE 4+"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 452)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 466)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 476)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 493)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 506)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 519)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 536)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 549)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 558)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 575)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 588)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 601)

                    Case "HS GRAD"

                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 453)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 467)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 481)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 494)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 507)
                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 520)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 537)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 550)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 563)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 576)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 589)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 602)

                    Case "INC $75K+"

                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 460)
                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 472)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 478)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 487)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 500)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 513)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 541)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 555)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 560)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 569)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 582)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 595)

                    Case "INC <$25K"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 442)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 456)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 470)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 484)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 497)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 510)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 527)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 540)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 553)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 566)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 579)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 592)

                    Case "INC 25-49K"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 443)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 458)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 471)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 485)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 498)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 511)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 528)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 542)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 554)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 567)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 580)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 593)

                    Case "INC 50-74K"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 444)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 459)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 477)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 486)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 499)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 512)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 529)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 543)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 559)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 568)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 581)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 594)

                    Case "NO CHILDRN"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 447)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 462)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 480)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 489)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 502)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 515)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 532)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 545)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 562)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 571)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 584)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 597)

                    Case "SOME COLL"

                        NielsenRadioUniverse.Males18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 440)
                        NielsenRadioUniverse.Males25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 454)
                        NielsenRadioUniverse.Males35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 468)
                        NielsenRadioUniverse.Males50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 482)
                        NielsenRadioUniverse.Males55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 495)
                        NielsenRadioUniverse.Males65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 508)
                        NielsenRadioUniverse.Females18to24 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 524)
                        NielsenRadioUniverse.Females25to34 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 538)
                        NielsenRadioUniverse.Females35to49 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 551)
                        NielsenRadioUniverse.Females50to54 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 564)
                        NielsenRadioUniverse.Females55to64 = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 577)
                        NielsenRadioUniverse.Females65Plus = GetUniverseStagingValue(RadioUniverseStagingList, GeoIndicator, 590)

                End Select

                NielsenRadioUniverses.Add(NielsenRadioUniverse)

            Next

        End Sub
        Public Function ProcessRadioFile(ConnectionString As String, ByVal Filename As String) As Boolean

            'objects
            Dim Processed As Boolean = False
            Dim SqlTransaction As SqlClient.SqlTransaction = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim NielsenRadioIntabs As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab) = Nothing
            Dim NielsenRadioUniverses As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse) = Nothing
            Dim NielsenRadioAudiences As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioAudience) = Nothing
            Dim RadioIntabStagingList As Generic.List(Of AdvantageFramework.Services.Nielsen.Classes.RadioIntabStaging) = Nothing
            Dim RadioIntabStaging As AdvantageFramework.Services.Nielsen.Classes.RadioIntabStaging = Nothing
            Dim RadioUniverseStagingList As Generic.List(Of AdvantageFramework.Services.Nielsen.Classes.RadioUniverseStaging) = Nothing
            Dim RadioUniverseStaging As AdvantageFramework.Services.Nielsen.Classes.RadioUniverseStaging = Nothing
            Dim NielsenRadioVStagings As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging) = Nothing
            Dim NielsenRadioVStaging As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging = Nothing
            Dim TextLine As String = Nothing
            Dim NielsenRadioPeriodID As Integer = 0
            Dim GeoIndicators As IEnumerable(Of Short) = Nothing

            If System.IO.File.Exists(Filename) Then

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(ConnectionString, Nothing)

                    DbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.NIELSEN_RADIO_V_STAGING")

                    Using SqlConnection As New SqlClient.SqlConnection(ConnectionString)

                        Try

                            SqlConnection.Open()

                            SqlTransaction = SqlConnection.BeginTransaction

                            StreamReader = New System.IO.StreamReader(Filename)

                            NielsenRadioIntabs = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioIntab)

                            NielsenRadioUniverses = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioUniverse)

                            NielsenRadioAudiences = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioAudience)

                            RadioIntabStagingList = New Generic.List(Of AdvantageFramework.Services.Nielsen.Classes.RadioIntabStaging)

                            RadioUniverseStagingList = New Generic.List(Of AdvantageFramework.Services.Nielsen.Classes.RadioUniverseStaging)

                            NielsenRadioVStagings = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging)

                            Do While StreamReader.Peek() <> -1

                                TextLine = StreamReader.ReadLine()

                                Select Case Mid(TextLine, 1, 1)

                                    Case "A"

                                        ProcessARecord(DbContext, TextLine, NielsenRadioPeriodID)

                                    Case "D"

                                        ProcessDRecord(DbContext, TextLine)

                                    Case "G"

                                        RadioIntabStaging = New AdvantageFramework.Services.Nielsen.Classes.RadioIntabStaging

                                        RadioIntabStaging.Intab = CInt(Mid(TextLine, 20, 6))
                                        RadioIntabStaging.DemoID = Mid(TextLine, 14, 6)
                                        RadioIntabStaging.GeoIndicator = CShort(Mid(TextLine, 13, 1))

                                        RadioIntabStagingList.Add(RadioIntabStaging)

                                    Case "H"

                                        RadioUniverseStaging = New AdvantageFramework.Services.Nielsen.Classes.RadioUniverseStaging

                                        RadioUniverseStaging.Universe = CInt(Mid(TextLine, 20, 6)) * 100
                                        RadioUniverseStaging.DemoID = Mid(TextLine, 14, 6)
                                        RadioUniverseStaging.GeoIndicator = CShort(Mid(TextLine, 13, 1))

                                        RadioUniverseStagingList.Add(RadioUniverseStaging)

                                    Case "J"

                                        ProcessJRecord(DbContext, TextLine)

                                    'Case "S"

                                    '    ProcessSRecord(DbContext, TextLine)

                                    Case "V"

                                        If CInt(Mid(TextLine, 35, 8)) <> 0 Then

                                            NielsenRadioVStaging = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging
                                            NielsenRadioVStaging.GeoIndicator = CShort(Mid(TextLine, 13, 1))
                                            NielsenRadioVStaging.EstimateType = CShort(Mid(TextLine, 14, 1))
                                            NielsenRadioVStaging.Daypart = CShort(Mid(TextLine, 15, 4))
                                            NielsenRadioVStaging.ListeningLocation = Mid(TextLine, 19, 1)
                                            NielsenRadioVStaging.DemoID = CInt(Mid(TextLine, 20, 6))
                                            NielsenRadioVStaging.StationComboType = CShort(Mid(TextLine, 26, 2))
                                            NielsenRadioVStaging.StationComboID = Mid(TextLine, 28, 6).Trim
                                            NielsenRadioVStaging.PurAud = CInt(Mid(TextLine, 35, 8))

                                            NielsenRadioVStagings.Add(NielsenRadioVStaging)

                                        End If

                                End Select

                            Loop

                            GeoIndicators = ((From Entity In RadioIntabStagingList
                                              Select Entity.GeoIndicator).Distinct.ToArray.Union(
                                             (From Entity In RadioUniverseStagingList
                                              Select Entity.GeoIndicator).Distinct.ToArray))

                            For Each GeoIndicator In GeoIndicators

                                CreateRadioSegmentParentRecords(DbContext, NielsenRadioPeriodID, GeoIndicator)

                            Next

                            For Each GeoIndicator In RadioIntabStagingList.Select(Function(F) F.GeoIndicator).Distinct.ToList

                                ProcessIntabStaging(DbContext, NielsenRadioPeriodID, GeoIndicator, RadioIntabStagingList, NielsenRadioIntabs)

                            Next

                            For Each GeoIndicator In RadioUniverseStagingList.Select(Function(F) F.GeoIndicator).Distinct.ToList

                                ProcessUniverseStaging(DbContext, NielsenRadioPeriodID, GeoIndicator, RadioUniverseStagingList, NielsenRadioUniverses)

                            Next

                            BulkInsertNielsenRadioVStagingsList(SqlConnection, NielsenRadioVStagings)

                            DbContext.Database.ExecuteSqlCommand("exec [dbo].[advsp_nielsen_radio_segment_child_insert]")

                            For Each GeoI In (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging)
                                              Where Entity.EstimateType = 1 AndAlso
                                                    Entity.StationComboID = "999999"
                                              Select Entity.GeoIndicator).Distinct.ToList

                                DbContext.Database.ExecuteSqlCommand(String.Format("exec [dbo].[advsp_nielsen_radio_pur_insert] {0}, {1}", NielsenRadioPeriodID, GeoI))

                            Next

                            For Each GeoI In (From Entity In DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioVStaging)
                                              Where (Entity.EstimateType = 1 OrElse
                                                     Entity.EstimateType = 2 OrElse
                                                     Entity.EstimateType = 3 OrElse
                                                     Entity.EstimateType = 4) AndAlso
                                                     Entity.StationComboID <> "999999"
                                              Select Entity.GeoIndicator).Distinct.ToList

                                DbContext.Database.ExecuteSqlCommand(String.Format("exec [dbo].[advsp_nielsen_radio_audience_insert] {0}, {1}", NielsenRadioPeriodID, GeoI))

                            Next

                            BulkInsertNielsenRadioUniverseList(SqlConnection, SqlTransaction, NielsenRadioUniverses)

                            BulkInsertNielsenRadioIntabList(SqlConnection, SqlTransaction, NielsenRadioIntabs)

                            SqlTransaction.Commit()

                            Processed = True

                        Catch ex As Exception

                            SqlTransaction.Rollback()

                            Throw New Exception(ex.Message & " Filename:" & Filename)

                            'WriteToEventLog("Nielsen Import: ProcessFile: " & ex.Message)

                        Finally

                            If SqlConnection.State = ConnectionState.Open Then

                                SqlConnection.Close()

                            End If

                            StreamReader.Close()

                        End Try

                    End Using

                End Using

            End If

            ProcessRadioFile = Processed

        End Function

#End Region

#End Region

    End Module

End Namespace

