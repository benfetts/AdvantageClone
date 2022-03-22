Namespace NielsenWebService

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Timeout As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function CreateRestClient() As RestSharp.RestClient

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12

            CreateRestClient = New RestSharp.RestClient(AdvantageFramework.Security.Session.CONST_NIELSENWEBSERVICE_URL & "/api/")

        End Function
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
        Private Sub BulkInsertNielsenTVAudienceList(SqlConnection As SqlClient.SqlConnection,
                                                    NielsenTVAudiences As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVAudience))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVAudiences.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_AUDIENCE_ID")
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
        Private Sub BulkInsertNielsenTVBookList(SqlConnection As SqlClient.SqlConnection,
                                                NielsenTVBooks As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVBook))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVBooks.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_BOOK_ID")
                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("Month", "MONTH")
                    .ColumnMappings.Add("Stream", "STREAM")
                    .ColumnMappings.Add("StartDateTime", "START_DATETIME")
                    .ColumnMappings.Add("EndDateTime", "END_DATETIME")
                    .ColumnMappings.Add("MarketTimeZone", "MARKET_TIME_ZONE")
                    .ColumnMappings.Add("MarketClassCode", "MARKET_CLASS_CODE")
                    .ColumnMappings.Add("IsDaylightSavingsMarket", "IS_DST_MARKET")
                    .ColumnMappings.Add("CreateDate", "CREATE_DATE")
                    .ColumnMappings.Add("Validated", "VALIDATED")
                    .ColumnMappings.Add("CollectionMethod", "COLLECTION_METHOD")
                    .ColumnMappings.Add("ReportingService", "REPORTING_SERVICE")
                    .ColumnMappings.Add("Exclusion", "EXCLUSION")
                    .ColumnMappings.Add("Ethnicity", "ETHNICITY")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_BOOK"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVHutputList(SqlConnection As SqlClient.SqlConnection,
                                                  NielsenTVHutputs As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVHutput))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVHutputs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_HUTPUT_ID")
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

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_HUTPUT"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVIntabList(SqlConnection As SqlClient.SqlConnection,
                                                 NielsenTVIntabs As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVIntab))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVIntabs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_INTAB_ID")
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

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_INTAB"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVProgramList(SqlConnection As SqlClient.SqlConnection,
                                                   NielsenTVPrograms As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgram))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVPrograms.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_PROGRAM_ID")
                    .ColumnMappings.Add("NielsenTVProgramBookID", "NIELSEN_TV_PROGRAM_BOOK_ID")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("QtrHourStartTime", "QTR_HOUR_START_DATETIME")
                    .ColumnMappings.Add("QtrHourEndTime", "QTR_HOUR_END_DATETIME")
                    .ColumnMappings.Add("ProgramName", "PROGRAM_NAME")
                    .ColumnMappings.Add("Subtitle", "SUBTITLE")
                    .ColumnMappings.Add("TrackageName", "TRACKAGE_NAME")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_PROGRAM"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVProgramBookList(SqlConnection As SqlClient.SqlConnection,
                                                       NielsenTVProgramBooks As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgramBook))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVProgramBooks.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_PROGRAM_BOOK_ID")
                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("Month", "MONTH")
                    .ColumnMappings.Add("Validated", "VALIDATED")
                    .ColumnMappings.Add("ReportingService", "REPORTING_SERVICE")
                    .ColumnMappings.Add("Exclusion", "EXCLUSION")
                    .ColumnMappings.Add("Ethnicity", "ETHNICITY")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_PROGRAM_BOOK"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVStationList(SqlConnection As SqlClient.SqlConnection,
                                                   NielsenTVStations As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVStation))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVStations.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_STATION_ID")
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

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_STATION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVStationHistoryList(SqlConnection As SqlClient.SqlConnection,
                                                          NielsenTVStationHistorys As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVStationHistory))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVStationHistorys.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_STATION_HISTORY_ID")
                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("CallLetters", "OLD_CALL_LETTERS")
                    .ColumnMappings.Add("ChangedOn", "CHANGED_ON")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_STATION_HISTORY"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVUniverseList(SqlConnection As SqlClient.SqlConnection,
                                                    NielsenTVUniverses As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVUniverse))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_UNIVERSE_ID")
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
                    .ColumnMappings.Add("ReportingService", "REPORTING_SERVICE")
                    .ColumnMappings.Add("Exclusion", "EXCLUSION")
                    .ColumnMappings.Add("Ethnicity", "ETHNICITY")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub GetNielsenTVAudience(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                         NielsenTVBookID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVAudiences As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVAudience) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVAudience.GetMaxIDByNielsenTVBookID(NielsenDBContext, NielsenTVBookID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVAudience/Get")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("BookID", NielsenTVBookID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVAudiences = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVAudience))(RestResponse.Content)

                        BulkInsertNielsenTVAudienceList(SqlConnection, NielsenTVAudiences)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVAudience")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function GetNielsenTVBooksByClientCode(ClientCode As String) As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim ClientNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVBook/GetByClientCodev2")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("ClientCode", ClientCode)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    ClientNielsenTVBooks = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook))(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from GetNielsenTVBooksByClientCode")

                End If

            Catch ex As Exception
                Throw ex
            Finally
                GetNielsenTVBooksByClientCode = ClientNielsenTVBooks
            End Try

        End Function
        Private Function GetNielsenTVBookRowCount(NielsenTVBookID As Integer) As Int64

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim BookRowCount As Int64 = 0

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVBook/GetBookRowCount")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("BookID", NielsenTVBookID)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    BookRowCount = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Int64)(RestResponse.Content)

                    GetNielsenTVBookRowCount = BookRowCount

                Else

                    Throw New Exception("INFO: No reply from GetNielsenTVBookRowCount")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Private Sub DeleteNielsenTVBooks(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext, DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVBookRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVBookRevision) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVBookRevision/Get")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenTVBookRevisions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVBookRevision))(RestResponse.Content)

                    For Each NielsenTVBookRevision In NielsenTVBookRevisions

                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_neilsen_tv_book_delete {0}", NielsenTVBookRevision.OldNielsenTVBookID))

                        DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_nielsen_tv_book_replace {0}, {1}", NielsenTVBookRevision.OldNielsenTVBookID, NielsenTVBookRevision.NewNielsenTVBookID))

                    Next

                Else

                    Throw New Exception("INFO: No reply from DeleteNielsenTVBooks")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenTVBook(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                     NielsenTVBookID As Integer)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVBook As AdvantageFramework.DTO.Nielsen.NielsenTVBook = Nothing
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVBook) = Nothing

            Try

                If AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDBContext, NielsenTVBookID) Is Nothing Then

                    RestClient = CreateRestClient()

                    RestRequest = New RestSharp.RestRequest("NielsenTVBook/GetByBookID")

                    RestRequest.Timeout = _Timeout
                    RestRequest.Method = RestSharp.Method.GET
                    RestRequest.RequestFormat = RestSharp.DataFormat.Json
                    RestRequest.AddParameter("BookID", NielsenTVBookID)

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVBook = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Nielsen.NielsenTVBook)(RestResponse.Content)

                        NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVBook)
                        NielsenTVBooks.Add(NielsenTVBook)

                        BulkInsertNielsenTVBookList(SqlConnection, NielsenTVBooks)

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVBook")

                    End If

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenTVHutput(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                       NielsenTVBookID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVHutputs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVHutput) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVHutput.GetMaxIDByNielsenTVBookID(NielsenDBContext, NielsenTVBookID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVHutput")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("BookID", NielsenTVBookID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVHutputs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVHutput))(RestResponse.Content)

                        BulkInsertNielsenTVHutputList(SqlConnection, NielsenTVHutputs)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVHutput")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenTVIntab(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                      NielsenTVBookID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVIntabs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVIntab) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVIntab.GetMaxIDByNielsenTVBookID(NielsenDBContext, NielsenTVBookID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVIntab")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("BookID", NielsenTVBookID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVIntabs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVIntab))(RestResponse.Content)

                        BulkInsertNielsenTVIntabList(SqlConnection, NielsenTVIntabs)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVIntab")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenTVProgram(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                        NielsenTVProgramBookID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVPrograms As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgram) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVProgram.GetMaxIDByNielsenTVProgramBookID(NielsenDBContext, NielsenTVProgramBookID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVProgram")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NielsenTVProgramBookID", NielsenTVProgramBookID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVPrograms = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgram))(RestResponse.Content)

                        BulkInsertNielsenTVProgramList(SqlConnection, NielsenTVPrograms)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVProgram")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenTVStation(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                        NielsenMarketNumber As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVStations As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVStation) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.GetMaxIDByNielsenMarketNumber(NielsenDBContext, NielsenMarketNumber)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVStation")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("MarketNumber", NielsenMarketNumber)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVStations = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVStation))(RestResponse.Content)

                        BulkInsertNielsenTVStationList(SqlConnection, NielsenTVStations)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVStation")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenTVStationHistory(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                               NielsenMarketNumber As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVStationHistorys As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVStationHistory) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStationHistory.GetMaxIDByNielsenMarketNumber(NielsenDBContext, NielsenMarketNumber)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVStationHistory")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("MarketNumber", NielsenMarketNumber)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVStationHistorys = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVStationHistory))(RestResponse.Content)

                        BulkInsertNielsenTVStationHistoryList(SqlConnection, NielsenTVStationHistorys)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVStationHistory")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenTVUniverse(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                         NielsenMarketNumber As Integer, Year As Short, Month As Short, ReportingService As String, Exclusion As String, Ethnicity As String)

            'objects
            Dim NielsenTVUniverse As AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse = Nothing
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVUniverses As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVUniverse) = Nothing
            'Dim Parameter As RestSharp.Parameter = Nothing
            'Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing
            Dim NielsenTVUniverseDTO As AdvantageFramework.DTO.Nielsen.NielsenTVUniverse = Nothing

            Try

                NielsenTVUniverse = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVUniverse.GetUniverse(NielsenDBContext, NielsenMarketNumber, Year, Month, ReportingService, Exclusion, Ethnicity)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVUniverse/GetUniverse")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("MarketNumber", NielsenMarketNumber)
                RestRequest.AddParameter("Year", Year)
                RestRequest.AddParameter("Month", Month)
                RestRequest.AddParameter("ReportingService", ReportingService)
                RestRequest.AddParameter("Exclusion", Exclusion)
                RestRequest.AddParameter("Ethnicity", Ethnicity)

                'Do

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenTVUniverses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVUniverse))(RestResponse.Content)

                    If NielsenTVUniverse Is Nothing Then

                        BulkInsertNielsenTVUniverseList(SqlConnection, NielsenTVUniverses)

                    ElseIf NielsenTVUniverses IsNot Nothing AndAlso NielsenTVUniverses.Count = 1 Then

                        NielsenTVUniverseDTO = NielsenTVUniverses.First

                        NielsenTVUniverseDTO.SaveToEntity(NielsenTVUniverse)

                        NielsenDBContext.Entry(NielsenTVUniverse).State = Entity.EntityState.Modified
                        NielsenDBContext.SaveChanges()

                    End If

                Else

                    Throw New Exception("INFO: No reply from GetNielsenTVUniverse")

                End If

                'Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub DeleteNielsenTVCumeBooks(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVCumeBookRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeBookRevision) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVCumeBookRevision/Get")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenTVCumeBookRevisions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeBookRevision))(RestResponse.Content)

                    For Each NielsenTVCumeBookRevision In NielsenTVCumeBookRevisions

                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_neilsen_tv_cume_book_delete {0}", NielsenTVCumeBookRevision.OldNielsenTVCumeBookID))

                    Next

                Else

                    Throw New Exception("INFO: No reply from DeleteNielsenTVCumeBooks")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function GetNielsenTVCumeBooksByClientCode(ClientCode As String) As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVCumeBook)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim ClientNielsenTVCumeBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVCumeBook) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVCumeBook/GetByClientCode")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("ClientCode", ClientCode)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    ClientNielsenTVCumeBooks = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVCumeBook))(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from GetNielsenTVCumeBooksByClientCode")

                End If

            Catch ex As Exception
                Throw ex
            Finally
                GetNielsenTVCumeBooksByClientCode = ClientNielsenTVCumeBooks
            End Try

        End Function
        Private Sub GetNielsenTVCumeDaypartImpression(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                      NielsenTVCumeBookID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVCumeDaypartImpressions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeDaypartImpression) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVCumeDaypartImpression.GetMaxIDByNielsenTVCumeBookID(NielsenDBContext, NielsenTVCumeBookID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVCumeDaypartImpression")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NielsenTVCumeBookID", NielsenTVCumeBookID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVCumeDaypartImpressions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeDaypartImpression))(RestResponse.Content)

                        BulkInsertNielsenTVCumeDaypartImpressionList(SqlConnection, NielsenTVCumeDaypartImpressions)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVCumeDaypartImpression")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenTVDaypart(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVDayparts As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVDaypart) = Nothing
            Dim NielsenTVDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenTVDaypart = Nothing
            Dim BulkInsertNielsenTVDayparts As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVDaypart) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVDaypart")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                BulkInsertNielsenTVDayparts = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVDaypart)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenTVDayparts = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVDaypart))(RestResponse.Content)

                    For Each NielsenTVDaypartDTO In NielsenTVDayparts

                        NielsenTVDaypart = NielsenDBContext.NielsenTVDayparts.Find(NielsenTVDaypartDTO.ID)

                        If NielsenTVDaypart IsNot Nothing Then

                            NielsenTVDaypart.NielsenDaypartID = NielsenTVDaypartDTO.NielsenDaypartID
                            NielsenTVDaypart.IsHispanic = NielsenTVDaypartDTO.IsHispanic
                            NielsenTVDaypart.TimeZone = NielsenTVDaypartDTO.TimeZone
                            NielsenTVDaypart.Name = NielsenTVDaypartDTO.Name
                            NielsenTVDaypart.NumberOfQuarterhours = NielsenTVDaypartDTO.NumberOfQuarterhours
                            NielsenTVDaypart.MilitaryStartTime = NielsenTVDaypartDTO.MilitaryStartTime
                            NielsenTVDaypart.MilitaryEndTime = NielsenTVDaypartDTO.MilitaryEndTime
                            NielsenTVDaypart.StartMinute = NielsenTVDaypartDTO.StartMinute
                            NielsenTVDaypart.EndMinute = NielsenTVDaypartDTO.EndMinute
                            NielsenTVDaypart.UseSegment = NielsenTVDaypartDTO.UseSegment
                            NielsenTVDaypart.Sunday = NielsenTVDaypartDTO.Sunday
                            NielsenTVDaypart.Monday = NielsenTVDaypartDTO.Monday
                            NielsenTVDaypart.Tuesday = NielsenTVDaypartDTO.Tuesday
                            NielsenTVDaypart.Wednesday = NielsenTVDaypartDTO.Wednesday
                            NielsenTVDaypart.Thursday = NielsenTVDaypartDTO.Thursday
                            NielsenTVDaypart.Friday = NielsenTVDaypartDTO.Friday
                            NielsenTVDaypart.Saturday = NielsenTVDaypartDTO.Saturday
                            NielsenTVDaypart.IsInactive = NielsenTVDaypartDTO.IsInactive

                            NielsenDBContext.Entry(NielsenTVDaypart).State = Entity.EntityState.Modified
                            NielsenDBContext.SaveChanges()

                        Else

                            BulkInsertNielsenTVDayparts.Add(NielsenTVDaypartDTO)

                        End If

                    Next

                    BulkInsertNielsenTVDaypartList(SqlConnection, BulkInsertNielsenTVDayparts)

                Else

                    Throw New Exception("INFO: No reply from GetNielsenTVDaypart")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub BulkInsertNielsenTVDaypartList(SqlConnection As SqlClient.SqlConnection,
                                                   NielsenTVDayparts As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVDaypart))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVDayparts.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_DAYPART_ID")
                    .ColumnMappings.Add("NielsenDaypartID", "NIELSEN_DAYPART_ID")
                    .ColumnMappings.Add("IsHispanic", "IS_HISPANIC")
                    .ColumnMappings.Add("TimeZone", "TIME_ZONE")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("NumberOfQuarterhours", "NUMBER_QUARTER_HOURS")
                    .ColumnMappings.Add("MilitaryStartTime", "MIL_START_TIME")
                    .ColumnMappings.Add("MilitaryEndTime", "MIL_END_TIME")
                    .ColumnMappings.Add("StartMinute", "START_MINUTE")
                    .ColumnMappings.Add("EndMinute", "END_MINUTE")
                    .ColumnMappings.Add("UseSegment", "USE_SEGMENT")
                    .ColumnMappings.Add("Sunday", "SUNDAY")
                    .ColumnMappings.Add("Monday", "MONDAY")
                    .ColumnMappings.Add("Tuesday", "TUESDAY")
                    .ColumnMappings.Add("Wednesday", "WEDNESDAY")
                    .ColumnMappings.Add("Thursday", "THURSDAY")
                    .ColumnMappings.Add("Friday", "FRIDAY")
                    .ColumnMappings.Add("Saturday", "SATURDAY")
                    .ColumnMappings.Add("IsInactive", "IS_INACTIVE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_DAYPART"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenTVCumeDaypartImpressionList(SqlConnection As SqlClient.SqlConnection,
                                                                 NielsenTVCumeDaypartImpressions As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeDaypartImpression))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVCumeDaypartImpressions.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_CUME_DAYPART_IMPRESSION_ID")
                    .ColumnMappings.Add("Ethnicity", "ETHNICITY")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("NielsenTVCumeBookID", "NIELSEN_TV_CUME_BOOK_ID")
                    .ColumnMappings.Add("NielsenTVDaypartID", "NIELSEN_TV_DAYPART_ID")
                    .ColumnMappings.Add("MetroAHousehold", "METROA_HOUSEHOLD")
                    .ColumnMappings.Add("MetroBHousehold", "METROB_HOUSEHOLD")
                    .ColumnMappings.Add("Household", "HOUSEHOLD")
                    .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5")
                    .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11")
                    .ColumnMappings.Add("Males12to14", "MALES_12TO14")
                    .ColumnMappings.Add("Males15to17", "MALES_15TO17")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS")
                    .ColumnMappings.Add("Females12to14", "FEMALES_12TO14")
                    .ColumnMappings.Add("Females15to17", "FEMALES_15TO17")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS")
                    .ColumnMappings.Add("WorkingWomen", "WORKING_WOMEN")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_CUME_DAYPART_IMPRESSION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub GetNielsenTVCumeBook(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                         NielsenTVCumeBookID As Integer)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVCumeBook As AdvantageFramework.DTO.Nielsen.NielsenTVCumeBook = Nothing
            Dim NielsenTVCumeBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeBook) = Nothing

            Try

                If AdvantageFramework.Nielsen.Database.Procedures.NielsenTVCumeBook.LoadByID(NielsenDBContext, NielsenTVCumeBookID) Is Nothing Then

                    RestClient = CreateRestClient()

                    RestRequest = New RestSharp.RestRequest("NielsenTVCumeBook/GetByBookID")

                    RestRequest.Timeout = _Timeout
                    RestRequest.Method = RestSharp.Method.GET
                    RestRequest.RequestFormat = RestSharp.DataFormat.Json
                    RestRequest.AddParameter("BookID", NielsenTVCumeBookID)

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVCumeBook = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeBook)(RestResponse.Content)

                        NielsenTVCumeBooks = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeBook)
                        NielsenTVCumeBooks.Add(NielsenTVCumeBook)

                        BulkInsertNielsenTVCumeBookList(SqlConnection, NielsenTVCumeBooks)

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVCumeBook")

                    End If

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub BulkInsertNielsenTVCumeBookList(SqlConnection As SqlClient.SqlConnection,
                                                    NielsenTVCumeBooks As List(Of AdvantageFramework.DTO.Nielsen.NielsenTVCumeBook))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenTVCumeBooks.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_TV_CUME_BOOK_ID")
                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("Month", "MONTH")
                    .ColumnMappings.Add("Stream", "STREAM")
                    .ColumnMappings.Add("StartDateTime", "START_DATETIME")
                    .ColumnMappings.Add("EndDateTime", "END_DATETIME")
                    .ColumnMappings.Add("MarketTimeZone", "MARKET_TIME_ZONE")
                    .ColumnMappings.Add("MarketClassCode", "MARKET_CLASS_CODE")
                    .ColumnMappings.Add("IsDaylightSavingsMarket", "IS_DST_MARKET")
                    .ColumnMappings.Add("CreateDate", "CREATE_DATE")
                    .ColumnMappings.Add("Validated", "VALIDATED")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_TV_CUME_BOOK"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Function GetNielsenTVCumeBookRowCount(NielsenTVCumeBookID As Integer) As Int64

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim BookRowCount As Int64 = 0

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVCumeBook/GetBookRowCount")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("BookID", NielsenTVCumeBookID)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    BookRowCount = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Int64)(RestResponse.Content)

                    GetNielsenTVCumeBookRowCount = BookRowCount

                Else

                    Throw New Exception("INFO: No reply from GetNielsenTVCumeBookRowCount")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Private Function GetNielsenTVProgramBooksByClientCode(ClientCode As String) As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim ClientNielsenTVProgramBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVProgramBook/GetByClientCodev2")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("ClientCode", ClientCode)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    ClientNielsenTVProgramBooks = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook))(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from GetNielsenTVProgramBooksByClientCode")

                End If

            Catch ex As Exception
                Throw ex
            Finally
                GetNielsenTVProgramBooksByClientCode = ClientNielsenTVProgramBooks
            End Try

        End Function
        Private Sub GetNielsenTVProgramBook(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                            NielsenTVProgramBookID As Integer)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVProgramBook As AdvantageFramework.DTO.Nielsen.NielsenTVProgramBook = Nothing
            Dim NielsenTVProgramBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgramBook) = Nothing

            Try

                If AdvantageFramework.Nielsen.Database.Procedures.NielsenTVProgramBook.LoadByID(NielsenDBContext, NielsenTVProgramBookID) Is Nothing Then

                    RestClient = CreateRestClient()

                    RestRequest = New RestSharp.RestRequest("NielsenTVProgramBook/GetByBookID")

                    RestRequest.Timeout = _Timeout
                    RestRequest.Method = RestSharp.Method.GET
                    RestRequest.RequestFormat = RestSharp.DataFormat.Json
                    RestRequest.AddParameter("BookID", NielsenTVProgramBookID)

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenTVProgramBook = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgramBook)(RestResponse.Content)

                        NielsenTVProgramBooks = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgramBook)
                        NielsenTVProgramBooks.Add(NielsenTVProgramBook)

                        BulkInsertNielsenTVProgramBookList(SqlConnection, NielsenTVProgramBooks)

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenTVProgramBook")

                    End If

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub DeleteNielsenTVProgramBooks(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVProgramBookRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgramBookRevision) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVProgramBookRevision/Get")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenTVProgramBookRevisions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVProgramBookRevision))(RestResponse.Content)

                    For Each NielsenTVProgramBookRevision In NielsenTVProgramBookRevisions

                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NIELSEN_TV_PROGRAM WHERE NIELSEN_TV_PROGRAM_BOOK_ID = {0}", NielsenTVProgramBookRevision.OldNielsenTVProgramBookID))
                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NIELSEN_TV_PROGRAM_BOOK WHERE NIELSEN_TV_PROGRAM_BOOK_ID = {0}", NielsenTVProgramBookRevision.OldNielsenTVProgramBookID))

                    Next

                Else

                    Throw New Exception("INFO: No reply from DeleteNielsenTVProgramBooks")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function GetNielsenTVProgramBookRowCount(NielsenTVProgramBookID As Integer) As Int64

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim BookRowCount As Int64 = 0

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVProgramBook/GetBookRowCount")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("BookID", NielsenTVProgramBookID)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    BookRowCount = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Int64)(RestResponse.Content)

                    GetNielsenTVProgramBookRowCount = BookRowCount

                Else

                    Throw New Exception("INFO: No reply from GetNielsenTVProgramBookRowCount")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Private Sub GetTVProgramData(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                     ClientCode As String)

            'objects
            Dim ClientNielsenTVProgramBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook) = Nothing
            Dim BookValidateCount As Int64 = 0

            ClientNielsenTVProgramBooks = GetNielsenTVProgramBooksByClientCode(ClientCode)

            For Each NielsenTVProgramBook In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVProgramBook.Load(NielsenDBContext)
                                              Where Entity.Validated = True
                                              Select Entity).ToList

                For Each ClientNielsenTVProgramBook In ClientNielsenTVProgramBooks

                    If ClientNielsenTVProgramBook.NielsenTVProgramBookID = NielsenTVProgramBook.ID Then

                        ClientNielsenTVProgramBooks.Remove(ClientNielsenTVProgramBook)
                        Exit For

                    End If

                Next

            Next

            For Each ClientNielsenTVProgramBook In ClientNielsenTVProgramBooks

                GetNielsenTVProgramBook(SqlConnection, NielsenDBContext, ClientNielsenTVProgramBook.NielsenTVProgramBookID)

                GetNielsenTVProgram(SqlConnection, NielsenDBContext, ClientNielsenTVProgramBook.NielsenTVProgramBookID)

            Next

            For Each ClientNielsenTVProgramBook In ClientNielsenTVProgramBooks

                BookValidateCount = GetNielsenTVProgramBookRowCount(ClientNielsenTVProgramBook.NielsenTVProgramBookID)

                If BookValidateCount <> 0 AndAlso BookValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT CAST(COALESCE(COUNT(1), 0) as bigint) FROM dbo.NIELSEN_TV_PROGRAM WHERE NIELSEN_TV_PROGRAM_BOOK_ID = {0}", ClientNielsenTVProgramBook.NielsenTVProgramBookID)).First Then

                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_TV_PROGRAM_BOOK SET VALIDATED = 1 WHERE NIELSEN_TV_PROGRAM_BOOK_ID = {0}", ClientNielsenTVProgramBook.NielsenTVProgramBookID))

                End If

            Next

        End Sub
        Private Sub UpdateNielsenTVBook(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext, UpdateNielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenTVBook As AdvantageFramework.DTO.Nielsen.NielsenTVBook = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenTVBook/GetByBookID")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("BookID", UpdateNielsenTVBook.ID)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenTVBook = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Nielsen.NielsenTVBook)(RestResponse.Content)

                    If NielsenTVBook IsNot Nothing Then

                        UpdateNielsenTVBook.CollectionMethod = NielsenTVBook.CollectionMethod

                        NielsenDBContext.Entry(UpdateNielsenTVBook).State = Entity.EntityState.Modified

                        NielsenDBContext.SaveChanges()

                    End If

                Else

                    Throw New Exception("INFO: No reply from UpdateNielsenTVBook")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

#Region " Radio "

        Private Sub BulkInsertNielsenRadioAudienceList(SqlConnection As SqlClient.SqlConnection,
                                                       NielsenRadioAudiences As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioAudience))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioAudiences.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_AUDIENCE_ID")
                    .ColumnMappings.Add("SegmentParentID", "NIELSEN_RADIO_SEGMENT_PARENT_ID")
                    .ColumnMappings.Add("SegmentChildID", "NIELSEN_RADIO_SEGMENT_CHILD_ID")
                    .ColumnMappings.Add("Males6to11AQH", "MALES_6TO11_AQH")
                    .ColumnMappings.Add("Males12to17AQH", "MALES_12TO17_AQH")
                    .ColumnMappings.Add("Males18to20AQH", "MALES_18TO20_AQH")
                    .ColumnMappings.Add("Males18to24AQH", "MALES_18TO24_AQH")
                    .ColumnMappings.Add("Males21to24AQH", "MALES_21TO24_AQH")
                    .ColumnMappings.Add("Males25to34AQH", "MALES_25TO34_AQH")
                    .ColumnMappings.Add("Males35to44AQH", "MALES_35TO44_AQH")
                    .ColumnMappings.Add("Males35to49AQH", "MALES_35TO49_AQH")
                    .ColumnMappings.Add("Males45to49AQH", "MALES_45TO49_AQH")
                    .ColumnMappings.Add("Males50to54AQH", "MALES_50TO54_AQH")
                    .ColumnMappings.Add("Males55to64AQH", "MALES_55TO64_AQH")
                    .ColumnMappings.Add("Males65PlusAQH", "MALES_65PLUS_AQH")
                    .ColumnMappings.Add("Females6to11AQH", "FEMALES_6TO11_AQH")
                    .ColumnMappings.Add("Females12to17AQH", "FEMALES_12TO17_AQH")
                    .ColumnMappings.Add("Females18to20AQH", "FEMALES_18TO20_AQH")
                    .ColumnMappings.Add("Females18to24AQH", "FEMALES_18TO24_AQH")
                    .ColumnMappings.Add("Females21to24AQH", "FEMALES_21TO24_AQH")
                    .ColumnMappings.Add("Females25to34AQH", "FEMALES_25TO34_AQH")
                    .ColumnMappings.Add("Females35to44AQH", "FEMALES_35TO44_AQH")
                    .ColumnMappings.Add("Females35to49AQH", "FEMALES_35TO49_AQH")
                    .ColumnMappings.Add("Females45to49AQH", "FEMALES_45TO49_AQH")
                    .ColumnMappings.Add("Females50to54AQH", "FEMALES_50TO54_AQH")
                    .ColumnMappings.Add("Females55to64AQH", "FEMALES_55TO64_AQH")
                    .ColumnMappings.Add("Females65PlusAQH", "FEMALES_65PLUS_AQH")
                    .ColumnMappings.Add("Males6to11CUME", "MALES_6TO11_CUME")
                    .ColumnMappings.Add("Males12to17CUME", "MALES_12TO17_CUME")
                    .ColumnMappings.Add("Males18to20CUME", "MALES_18TO20_CUME")
                    .ColumnMappings.Add("Males18to24CUME", "MALES_18TO24_CUME")
                    .ColumnMappings.Add("Males21to24CUME", "MALES_21TO24_CUME")
                    .ColumnMappings.Add("Males25to34CUME", "MALES_25TO34_CUME")
                    .ColumnMappings.Add("Males35to44CUME", "MALES_35TO44_CUME")
                    .ColumnMappings.Add("Males35to49CUME", "MALES_35TO49_CUME")
                    .ColumnMappings.Add("Males45to49CUME", "MALES_45TO49_CUME")
                    .ColumnMappings.Add("Males50to54CUME", "MALES_50TO54_CUME")
                    .ColumnMappings.Add("Males55to64CUME", "MALES_55TO64_CUME")
                    .ColumnMappings.Add("Males65PlusCUME", "MALES_65PLUS_CUME")
                    .ColumnMappings.Add("Females6to11CUME", "FEMALES_6TO11_CUME")
                    .ColumnMappings.Add("Females12to17CUME", "FEMALES_12TO17_CUME")
                    .ColumnMappings.Add("Females18to20CUME", "FEMALES_18TO20_CUME")
                    .ColumnMappings.Add("Females18to24CUME", "FEMALES_18TO24_CUME")
                    .ColumnMappings.Add("Females21to24CUME", "FEMALES_21TO24_CUME")
                    .ColumnMappings.Add("Females25to34CUME", "FEMALES_25TO34_CUME")
                    .ColumnMappings.Add("Females35to44CUME", "FEMALES_35TO44_CUME")
                    .ColumnMappings.Add("Females35to49CUME", "FEMALES_35TO49_CUME")
                    .ColumnMappings.Add("Females45to49CUME", "FEMALES_45TO49_CUME")
                    .ColumnMappings.Add("Females50to54CUME", "FEMALES_50TO54_CUME")
                    .ColumnMappings.Add("Females55to64CUME", "FEMALES_55TO64_CUME")
                    .ColumnMappings.Add("Females65PlusCUME", "FEMALES_65PLUS_CUME")
                    .ColumnMappings.Add("Males6to11ECUME", "MALES_6TO11_ECUME")
                    .ColumnMappings.Add("Males12to17ECUME", "MALES_12TO17_ECUME")
                    .ColumnMappings.Add("Males18to20ECUME", "MALES_18TO20_ECUME")
                    .ColumnMappings.Add("Males18to24ECUME", "MALES_18TO24_ECUME")
                    .ColumnMappings.Add("Males21to24ECUME", "MALES_21TO24_ECUME")
                    .ColumnMappings.Add("Males25to34ECUME", "MALES_25TO34_ECUME")
                    .ColumnMappings.Add("Males35to44ECUME", "MALES_35TO44_ECUME")
                    .ColumnMappings.Add("Males35to49ECUME", "MALES_35TO49_ECUME")
                    .ColumnMappings.Add("Males45to49ECUME", "MALES_45TO49_ECUME")
                    .ColumnMappings.Add("Males50to54ECUME", "MALES_50TO54_ECUME")
                    .ColumnMappings.Add("Males55to64ECUME", "MALES_55TO64_ECUME")
                    .ColumnMappings.Add("Males65PlusECUME", "MALES_65PLUS_ECUME")
                    .ColumnMappings.Add("Females6to11ECUME", "FEMALES_6TO11_ECUME")
                    .ColumnMappings.Add("Females12to17ECUME", "FEMALES_12TO17_ECUME")
                    .ColumnMappings.Add("Females18to20ECUME", "FEMALES_18TO20_ECUME")
                    .ColumnMappings.Add("Females18to24ECUME", "FEMALES_18TO24_ECUME")
                    .ColumnMappings.Add("Females21to24ECUME", "FEMALES_21TO24_ECUME")
                    .ColumnMappings.Add("Females25to34ECUME", "FEMALES_25TO34_ECUME")
                    .ColumnMappings.Add("Females35to44ECUME", "FEMALES_35TO44_ECUME")
                    .ColumnMappings.Add("Females35to49ECUME", "FEMALES_35TO49_ECUME")
                    .ColumnMappings.Add("Females45to49ECUME", "FEMALES_45TO49_ECUME")
                    .ColumnMappings.Add("Females50to54ECUME", "FEMALES_50TO54_ECUME")
                    .ColumnMappings.Add("Females55to64ECUME", "FEMALES_55TO64_ECUME")
                    .ColumnMappings.Add("Females65PlusECUME", "FEMALES_65PLUS_ECUME")
                    .ColumnMappings.Add("Males6to11TLH", "MALES_6TO11_TLH")
                    .ColumnMappings.Add("Males12to17TLH", "MALES_12TO17_TLH")
                    .ColumnMappings.Add("Males18to20TLH", "MALES_18TO20_TLH")
                    .ColumnMappings.Add("Males18to24TLH", "MALES_18TO24_TLH")
                    .ColumnMappings.Add("Males21to24TLH", "MALES_21TO24_TLH")
                    .ColumnMappings.Add("Males25to34TLH", "MALES_25TO34_TLH")
                    .ColumnMappings.Add("Males35to44TLH", "MALES_35TO44_TLH")
                    .ColumnMappings.Add("Males35to49TLH", "MALES_35TO49_TLH")
                    .ColumnMappings.Add("Males45to49TLH", "MALES_45TO49_TLH")
                    .ColumnMappings.Add("Males50to54TLH", "MALES_50TO54_TLH")
                    .ColumnMappings.Add("Males55to64TLH", "MALES_55TO64_TLH")
                    .ColumnMappings.Add("Males65PlusTLH", "MALES_65PLUS_TLH")
                    .ColumnMappings.Add("Females6to11TLH", "FEMALES_6TO11_TLH")
                    .ColumnMappings.Add("Females12to17TLH", "FEMALES_12TO17_TLH")
                    .ColumnMappings.Add("Females18to20TLH", "FEMALES_18TO20_TLH")
                    .ColumnMappings.Add("Females18to24TLH", "FEMALES_18TO24_TLH")
                    .ColumnMappings.Add("Females21to24TLH", "FEMALES_21TO24_TLH")
                    .ColumnMappings.Add("Females25to34TLH", "FEMALES_25TO34_TLH")
                    .ColumnMappings.Add("Females35to44TLH", "FEMALES_35TO44_TLH")
                    .ColumnMappings.Add("Females35to49TLH", "FEMALES_35TO49_TLH")
                    .ColumnMappings.Add("Females45to49TLH", "FEMALES_45TO49_TLH")
                    .ColumnMappings.Add("Females50to54TLH", "FEMALES_50TO54_TLH")
                    .ColumnMappings.Add("Females55to64TLH", "FEMALES_55TO64_TLH")
                    .ColumnMappings.Add("Females65PlusTLH", "FEMALES_65PLUS_TLH")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_AUDIENCE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioDaypartList(SqlConnection As SqlClient.SqlConnection,
                                                      NielsenRadioDayparts As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioDaypart))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioDayparts.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_DAYPART_ID")
                    .ColumnMappings.Add("NielsenRadioReportTypeCode", "NIELSEN_RADIO_REPORT_TYPE_CODE")
                    .ColumnMappings.Add("NielsenDaypartID", "NIELSEN_DAYPART_ID")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("NumberOfQuarterhours", "NUMBER_QUARTER_HOURS")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_DAYPART"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioDemographicList(SqlConnection As SqlClient.SqlConnection,
                                                          NielsenRadioDemographics As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioDemographic))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioDemographics.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_DEMOGRAPHIC_ID")
                    .ColumnMappings.Add("Number", "NUMBER")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("AgeSexCode", "AGESEX_CODE")
                    .ColumnMappings.Add("QualitativeCode", "QUALITATIVE_CODE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_DEMOGRAPHIC"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioIntabList(SqlConnection As SqlClient.SqlConnection,
                                                    NielsenRadioIntabs As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioIntab))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioIntabs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_INTAB_ID")
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

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_INTAB"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioPeriodList(SqlConnection As SqlClient.SqlConnection,
                                                     NielsenRadioPeriods As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriod))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioPeriods.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_PERIOD_ID")
                    .ColumnMappings.Add("NielsenRadioReportTypeCode", "NIELSEN_RADIO_REPORT_TYPE_CODE")
                    .ColumnMappings.Add("NielsenPeriodID", "NIELSEN_PERIOD_ID")
                    .ColumnMappings.Add("NielsenRadioMarketNumber", "NIELSEN_RADIO_MARKET_NUMBER")
                    .ColumnMappings.Add("ShortName", "SHORT_NAME")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("StartDate", "START_DATE")
                    .ColumnMappings.Add("EndDate", "END_DATE")
                    .ColumnMappings.Add("StandardCondensedIndicator", "STANDARD_CONDENSED_INDICATOR")
                    .ColumnMappings.Add("Validated", "VALIDATED")
                    .ColumnMappings.Add("Copyright", "COPYRIGHT")
                    .ColumnMappings.Add("Source", "SOURCE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_PERIOD"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioPURList(SqlConnection As SqlClient.SqlConnection,
                                                  NielsenRadioPurs As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPur))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioPurs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_PUR_ID")
                    .ColumnMappings.Add("SegmentParentID", "NIELSEN_RADIO_SEGMENT_PARENT_ID")
                    .ColumnMappings.Add("SegmentChildID", "NIELSEN_RADIO_SEGMENT_CHILD_ID")
                    .ColumnMappings.Add("Females6to11", "FEMALES_6TO11_PUR")
                    .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_PUR")
                    .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUR")
                    .ColumnMappings.Add("Females18to24", "FEMALES_18TO24_PUR")
                    .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUR")
                    .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_PUR")
                    .ColumnMappings.Add("Females35to44", "FEMALES_35TO44_PUR")
                    .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_PUR")
                    .ColumnMappings.Add("Females45to49", "FEMALES_45TO49_PUR")
                    .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUR")
                    .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUR")
                    .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUR")
                    .ColumnMappings.Add("Males6to11", "MALES_6TO11_PUR")
                    .ColumnMappings.Add("Males12to17", "MALES_12TO17_PUR")
                    .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUR")
                    .ColumnMappings.Add("Males18to24", "MALES_18TO24_PUR")
                    .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUR")
                    .ColumnMappings.Add("Males25to34", "MALES_25TO34_PUR")
                    .ColumnMappings.Add("Males35to44", "MALES_35TO44_PUR")
                    .ColumnMappings.Add("Males35to49", "MALES_35TO49_PUR")
                    .ColumnMappings.Add("Males45to49", "MALES_45TO49_PUR")
                    .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUR")
                    .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUR")
                    .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUR")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_PUR"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioQualitativeList(SqlConnection As SqlClient.SqlConnection,
                                                          NielsenRadioQualitatives As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioQualitative))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioQualitatives.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_QUALITATIVE_ID")
                    .ColumnMappings.Add("Code", "CODE")
                    .ColumnMappings.Add("Name", "NAME")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_QUALITATIVE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioReportTypeList(SqlConnection As SqlClient.SqlConnection,
                                                         NielsenRadioReportTypes As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioReportType))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioReportTypes.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("Code", "CODE")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_REPORT_TYPE_ID")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_REPORT_TYPE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioSegmentChildList(SqlConnection As SqlClient.SqlConnection,
                                                           NielsenRadioSegmentChilds As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioSegmentChild))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioSegmentChilds.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_SEGMENT_CHILD_ID")
                    .ColumnMappings.Add("NielsenRadioDaypartID", "NIELSEN_RADIO_DAYPART_ID")
                    .ColumnMappings.Add("ListeningLocation", "LISTENING_LOCATION")
                    .ColumnMappings.Add("StationComboType", "STATION_COMBO_TYPE")
                    .ColumnMappings.Add("NielsenRadioStationComboID", "NIELSEN_RADIO_STATION_COMBO_ID")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_SEGMENT_CHILD"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioSegmentParentList(SqlConnection As SqlClient.SqlConnection,
                                                            NielsenRadioSegmentParents As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioSegmentParent))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioSegmentParents.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_SEGMENT_PARENT_ID")
                    .ColumnMappings.Add("NielsenRadioPeriodID", "NIELSEN_RADIO_PERIOD_ID")
                    .ColumnMappings.Add("GeoIndicator", "GEO_INDICATOR")
                    .ColumnMappings.Add("NielsenRadioQualitativeID", "NIELSEN_RADIO_QUALITATIVE_ID")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_SEGMENT_PARENT"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioStationList(SqlConnection As SqlClient.SqlConnection,
                                                      NielsenRadioStations As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStation))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioStations.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_STATION_ID")
                    .ColumnMappings.Add("NielsenRadioMarketNumber", "NIELSEN_RADIO_MARKET_NUMBER")
                    .ColumnMappings.Add("ComboID", "COMBO_ID")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("CallLetters", "CALL_LETTERS")
                    .ColumnMappings.Add("Band", "BAND")
                    .ColumnMappings.Add("Frequency", "FREQUENCY")
                    .ColumnMappings.Add("ComboType", "COMBO_TYPE")
                    .ColumnMappings.Add("NielsenRadioFormatCode", "NIELSEN_RADIO_FORMAT_CODE")
                    .ColumnMappings.Add("IsSpillin", "IS_SPILLIN")
                    .ColumnMappings.Add("Source", "SOURCE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_STATION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioStationHistoryList(SqlConnection As SqlClient.SqlConnection,
                                                             NielsenRadioStationHistorys As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioStationHistorys.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_STATION_HISTORY_ID")
                    .ColumnMappings.Add("NielsenRadioMarketNumber", "NIELSEN_RADIO_MARKET_NUMBER")
                    .ColumnMappings.Add("ComboID", "COMBO_ID")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("CallLetters", "CALL_LETTERS")
                    .ColumnMappings.Add("Band", "BAND")
                    .ColumnMappings.Add("Frequency", "FREQUENCY")
                    .ColumnMappings.Add("ComboType", "COMBO_TYPE")
                    .ColumnMappings.Add("NielsenRadioFormatCode", "NIELSEN_RADIO_FORMAT_CODE")
                    .ColumnMappings.Add("IsSpillin", "IS_SPILLIN")
                    .ColumnMappings.Add("Source", "SOURCE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_STATION_HISTORY"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioUniverseList(SqlConnection As SqlClient.SqlConnection,
                                                       NielsenRadioUniverses As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioUniverse))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_UNIVERSE_ID")
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

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub GetNielsenRadioAudience(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                            SegmentParentIDs As Generic.List(Of Integer))

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioAudiences As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioAudience) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioAudience.GetMaxIDBySegmentParentIDs(NielsenDBContext, SegmentParentIDs)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioAudience")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)

                For Each SegmentParentID In SegmentParentIDs

                    RestRequest.AddParameter("SegmentParentIDs", SegmentParentID, RestSharp.ParameterType.GetOrPost)

                Next

                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioAudiences = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioAudience))(RestResponse.Content)

                        BulkInsertNielsenRadioAudienceList(SqlConnection, NielsenRadioAudiences)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioAudience")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        'Private Sub GetNielsenRadioDaypart(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

        '    'objects
        '    Dim MaxID As Integer = 0
        '    Dim RestClient As RestSharp.RestClient = Nothing
        '    Dim RestRequest As RestSharp.RestRequest = Nothing
        '    Dim RestResponse As RestSharp.IRestResponse = Nothing
        '    Dim NielsenRadioDayparts As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioDaypart) = Nothing
        '    Dim Parameter As RestSharp.Parameter = Nothing
        '    Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

        '    Try

        '        MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioDaypart.GetMaxID(NielsenDBContext)

        '        RestClient = CreateRestClient()

        '        RestRequest = New RestSharp.RestRequest("NielsenRadioDaypart")

        '        RestRequest.Method = RestSharp.Method.GET
        '        RestRequest.RequestFormat = RestSharp.DataFormat.Json
        '        RestRequest.AddParameter("IDGreaterThan", MaxID)
        '        RestRequest.AddParameter("Page", 0)

        '        Do

        '            RestResponse = RestClient.Execute(RestRequest)

        '            If RestResponse.StatusDescription = "OK" Then

        '                NielsenRadioDayparts = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioDaypart))(RestResponse.Content)

        '                BulkInsertNielsenRadioDaypartList(SqlConnection, NielsenRadioDayparts)

        '                Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

        '                If Parameter IsNot Nothing Then

        '                    PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

        '                    RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

        '                End If

        '            Else

        '               Throw New Exception("INFO: No reply from GetNielsenRadioDaypart")

        '            End If

        '        Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Sub
        Private Sub GetNielsenRadioDemographic(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim MaxID As Integer = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioDemographics As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioDemographic) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioDemographic.GetMaxID(NielsenDBContext)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioDemographic")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioDemographics = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioDemographic))(RestResponse.Content)

                        BulkInsertNielsenRadioDemographicList(SqlConnection, NielsenRadioDemographics)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioDemographic")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioFormat(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioFormats As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioFormat) = Nothing
            Dim NielsenRadioFormat As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioFormat = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioFormat")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenRadioFormats = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioFormat))(RestResponse.Content)

                    For Each DTONielsenRadioFormat In NielsenRadioFormats

                        NielsenRadioFormat = NielsenDBContext.NielsenRadioFormats.Find(DTONielsenRadioFormat.Code)

                        If NielsenRadioFormat IsNot Nothing Then

                            NielsenRadioFormat.Name = DTONielsenRadioFormat.Name
                            NielsenDBContext.Entry(NielsenRadioFormat).State = Entity.EntityState.Modified
                            NielsenDBContext.SaveChanges()

                        Else

                            NielsenRadioFormat = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioFormat
                            NielsenRadioFormat.Code = DTONielsenRadioFormat.Code
                            NielsenRadioFormat.Name = DTONielsenRadioFormat.Name

                            NielsenDBContext.NielsenRadioFormats.Add(NielsenRadioFormat)
                            NielsenDBContext.SaveChanges()

                        End If

                    Next

                Else

                    Throw New Exception("INFO: No reply from GetNielsenRadioFormat")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioIntab(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                         SegmentParentIDs As Generic.List(Of Integer))

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioIntabs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioIntab) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioIntab.GetMaxIDBySegmentParentIDs(NielsenDBContext, SegmentParentIDs)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioIntab")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)

                For Each SegmentParentID In SegmentParentIDs

                    RestRequest.AddParameter("SegmentParentIDs", SegmentParentID, RestSharp.ParameterType.GetOrPost)

                Next

                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioIntabs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioIntab))(RestResponse.Content)

                        BulkInsertNielsenRadioIntabList(SqlConnection, NielsenRadioIntabs)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioIntab")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioPUR(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                       SegmentParentIDs As Generic.List(Of Integer))

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioPurs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPur) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPUR.GetMaxIDBySegmentParentIDs(NielsenDBContext, SegmentParentIDs)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioPUR")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)

                For Each SegmentParentID In SegmentParentIDs

                    RestRequest.AddParameter("SegmentParentIDs", SegmentParentID, RestSharp.ParameterType.GetOrPost)

                Next

                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioPurs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPur))(RestResponse.Content)

                        BulkInsertNielsenRadioPURList(SqlConnection, NielsenRadioPurs)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioPUR")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioQualitative(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim MaxID As Integer = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioQualitatives As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioQualitative) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioQualitative.GetMaxID(NielsenDBContext)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioQualitative")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioQualitatives = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioQualitative))(RestResponse.Content)

                        BulkInsertNielsenRadioQualitativeList(SqlConnection, NielsenRadioQualitatives)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioQualitative")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        'Private Sub GetNielsenRadioReportType(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

        '    'objects
        '    Dim MaxID As Integer = 0
        '    Dim RestClient As RestSharp.RestClient = Nothing
        '    Dim RestRequest As RestSharp.RestRequest = Nothing
        '    Dim RestResponse As RestSharp.IRestResponse = Nothing
        '    Dim NielsenRadioReportTypes As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioReportType) = Nothing
        '    Dim Parameter As RestSharp.Parameter = Nothing
        '    Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

        '    Try

        '        MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioReportType.GetMaxID(NielsenDBContext)

        '        RestClient = CreateRestClient()

        '        RestRequest = New RestSharp.RestRequest("NielsenRadioQualitative")

        '        RestRequest.Method = RestSharp.Method.GET
        '        RestRequest.RequestFormat = RestSharp.DataFormat.Json
        '        RestRequest.AddParameter("IDGreaterThan", MaxID)
        '        RestRequest.AddParameter("Page", 0)

        '        Do

        '            RestResponse = RestClient.Execute(RestRequest)

        '            If RestResponse.StatusDescription = "OK" Then

        '                NielsenRadioReportTypes = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioReportType))(RestResponse.Content)

        '                BulkInsertNielsenRadioReportTypeList(SqlConnection, NielsenRadioReportTypes)

        '                Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

        '                If Parameter IsNot Nothing Then

        '                    PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

        '                    RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

        '                End If

        '            Else

        '                Throw New Exception("INFO: No reply from GetNielsenRadioReportType")

        '            End If

        '        Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Sub
        Private Sub GetNielsenRadioSegmentChild(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim MaxID As Int64 = Nothing
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioSegmentChilds As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioSegmentChild) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioSegmentChild.GetMaxID(NielsenDBContext)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioSegmentChild")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioSegmentChilds = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioSegmentChild))(RestResponse.Content)

                        BulkInsertNielsenRadioSegmentChildList(SqlConnection, NielsenRadioSegmentChilds)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioSegmentChild")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioSegmentParent(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                 NielsenRadioPeriodID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioSegmentParents As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioSegmentParent) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioSegmentParent.GetMaxIDByNielsenRadioPeriodID(NielsenDBContext, NielsenRadioPeriodID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioSegmentParent")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NielsenRadioPeriodID", NielsenRadioPeriodID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioSegmentParents = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioSegmentParent))(RestResponse.Content)

                        BulkInsertNielsenRadioSegmentParentList(SqlConnection, NielsenRadioSegmentParents)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioSegmentParent")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioStation(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                           MarketNumber As Integer, Source As AdvantageFramework.Nielsen.Database.Entities.RadioSource)

            'objects
            Dim MaxID As Integer = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioStations As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStation) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.GetMaxIDByMarketNumber(NielsenDBContext, MarketNumber, Source)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioStation/GetByMarketNumberSource")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("MarketNumber", MarketNumber)
                RestRequest.AddParameter("Source", Source)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioStations = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStation))(RestResponse.Content)

                        BulkInsertNielsenRadioStationList(SqlConnection, NielsenRadioStations)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioStation")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioStationHistory(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                  MarketNumber As Integer, Source As AdvantageFramework.Nielsen.Database.Entities.RadioSource)

            'objects
            Dim MaxID As Integer = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioStationHistorys As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStationHistory.GetMaxIDByMarketNumber(NielsenDBContext, MarketNumber, Source)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioStationHistory/GetByMarketNumberSource")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("MarketNumber", MarketNumber)
                RestRequest.AddParameter("Source", Source)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioStationHistorys = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory))(RestResponse.Content)

                        BulkInsertNielsenRadioStationHistoryList(SqlConnection, NielsenRadioStationHistorys)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioStationHistory")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioUniverse(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                            SegmentParentIDs As Generic.List(Of Integer))

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioUniverses As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioUniverse) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioUniverse.GetMaxIDBySegmentParentIDs(NielsenDBContext, SegmentParentIDs)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioUniverse")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)

                For Each SegmentParentID In SegmentParentIDs

                    RestRequest.AddParameter("SegmentParentIDs", SegmentParentID, RestSharp.ParameterType.GetOrPost)

                Next

                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioUniverses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioUniverse))(RestResponse.Content)

                        BulkInsertNielsenRadioUniverseList(SqlConnection, NielsenRadioUniverses)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioUniverse")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function GetNielsenRadioPeriodRowCount(NielsenRadioPeriodID As Integer) As Int64

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim PeriodRowCount As Int64 = 0

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioPeriod/GetPeriodRowCount")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("PeriodID", NielsenRadioPeriodID)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    PeriodRowCount = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Int64)(RestResponse.Content)

                    GetNielsenRadioPeriodRowCount = PeriodRowCount

                Else

                    Throw New Exception("INFO: No reply from GetNielsenRadioPeriodRowCount")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Private Sub DeleteNielsenRadioPeriods(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext, DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioPeriodRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriodRevision) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioPeriodRevision/Get")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenRadioPeriodRevisions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriodRevision))(RestResponse.Content)

                    For Each NielsenRadioPeriodRevision In NielsenRadioPeriodRevisions

                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_neilsen_radio_period_delete {0}", NielsenRadioPeriodRevision.OldNielsenRadioPeriodID))

                        DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_nielsen_radio_period_replace {0}, {1}", NielsenRadioPeriodRevision.OldNielsenRadioPeriodID, NielsenRadioPeriodRevision.NewNielsenRadioPeriodID))

                    Next

                Else

                    Throw New Exception("INFO: No reply from DeleteNielsenRadioPeriods")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioPeriod(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                          NielsenRadioPeriodID As Integer)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioPeriod As AdvantageFramework.DTO.Nielsen.NielsenRadioPeriod = Nothing
            Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriod) = Nothing

            Try

                If AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDBContext, NielsenRadioPeriodID) Is Nothing Then

                    RestClient = CreateRestClient()

                    RestRequest = New RestSharp.RestRequest("NielsenRadioPeriod/GetByPeriodID")

                    RestRequest.Timeout = _Timeout
                    RestRequest.Method = RestSharp.Method.GET
                    RestRequest.RequestFormat = RestSharp.DataFormat.Json
                    RestRequest.AddParameter("PeriodID", NielsenRadioPeriodID)

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioPeriod = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriod)(RestResponse.Content)

                        NielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriod)
                        NielsenRadioPeriods.Add(NielsenRadioPeriod)

                        BulkInsertNielsenRadioPeriodList(SqlConnection, NielsenRadioPeriods)

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioPeriod")

                    End If

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioMarket(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                          MarketNumber As Integer, Source As AdvantageFramework.Nielsen.Database.Entities.RadioSource)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioMarketDTO As AdvantageFramework.DTO.Nielsen.NielsenRadioMarket = Nothing
            Dim NielsenRadioMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioMarket/GetByMarketNumberSource")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("MarketNumber", MarketNumber)
                RestRequest.AddParameter("Source", Source)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NielsenRadioMarketDTO = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Nielsen.NielsenRadioMarket)(RestResponse.Content)

                    If NielsenRadioMarketDTO IsNot Nothing Then

                        NielsenRadioMarket = (From Entity In NielsenDBContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket)
                                              Where Entity.Number = NielsenRadioMarketDTO.Number AndAlso
                                                    Entity.Source = Source
                                              Select Entity).SingleOrDefault

                        If NielsenRadioMarket Is Nothing Then

                            NielsenRadioMarket = New AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket
                            NielsenRadioMarket.DbContext = NielsenDBContext

                            NielsenRadioMarket.Number = NielsenRadioMarketDTO.Number
                            NielsenRadioMarket.Name = NielsenRadioMarketDTO.Name
                            NielsenRadioMarket.Source = NielsenRadioMarketDTO.Source

                            NielsenDBContext.NielsenRadioMarkets.Add(NielsenRadioMarket)

                        Else

                            NielsenRadioMarket.Number = NielsenRadioMarketDTO.Number
                            NielsenRadioMarket.Name = NielsenRadioMarketDTO.Name
                            NielsenRadioMarket.Source = NielsenRadioMarketDTO.Source

                        End If

                        NielsenDBContext.SaveChanges()

                    End If

                Else

                    Throw New Exception("INFO: No reply from GetNielsenRadioMarket")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function GetNielsenRadioPeriodsByClientCode(ClientCode As String) As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim ClientNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioPeriod/GetByClientCode")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("ClientCode", ClientCode)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    ClientNielsenRadioPeriods = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod))(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from GetNielsenRadioPeriodsByClientCode")

                End If

            Catch ex As Exception
                Throw ex
            Finally
                GetNielsenRadioPeriodsByClientCode = ClientNielsenRadioPeriods
            End Try

        End Function
        Private Function GetEastlanRadioPeriods() As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim ClientNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioPeriod/GetEastlanRadioPeriods")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    ClientNielsenRadioPeriods = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod))(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from GetEastlanRadioPeriods")

                End If

            Catch ex As Exception
                Throw ex
            Finally
                GetEastlanRadioPeriods = ClientNielsenRadioPeriods
            End Try

        End Function

#End Region

#Region " NCC Data "

        Private Sub BulkInsertNCCTVMVPDList(SqlConnection As SqlClient.SqlConnection,
                                            NCCTVMVPDs As List(Of AdvantageFramework.DTO.Nielsen.NCCTVMVPD))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVMVPDs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_MVPD_ID")
                    .ColumnMappings.Add("MVPD", "MVPD")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_MVPD"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNCCTVSyscodeList(SqlConnection As SqlClient.SqlConnection,
                                               NCCTVSyscodes As List(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVSyscodes.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_SYSCODE_ID")
                    .ColumnMappings.Add("Syscode", "SYSCODE")
                    .ColumnMappings.Add("NCCTVMVPDID", "NCC_TV_MVPD_ID")
                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("SystemName", "SYSTEM_NAME")
                    .ColumnMappings.Add("SystemType", "SYSTEM_TYPE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_SYSCODE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNCCTVCablenetList(SqlConnection As SqlClient.SqlConnection,
                                                NCCTVCablenets As List(Of AdvantageFramework.DTO.Nielsen.NCCTVCablenet))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVCablenets.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_CABLENET_ID")
                    .ColumnMappings.Add("NetworkCode", "NETWORK_CODE")
                    .ColumnMappings.Add("NetworkName", "NETWORK_NAME")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("ComscoreStationCode", "COMSCORE_STATION_CODE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_CABLENET"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        'Private Sub BulkInsertNCCTVFusionUniverseList(SqlConnection As SqlClient.SqlConnection,
        '                                              NCCTVFusionUniverses As List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse))

        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NCCTVFusionUniverses.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("ID", "NCC_TV_FUSION_UE_ID")
        '            .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
        '            .ColumnMappings.Add("Year", "YEAR")
        '            .ColumnMappings.Add("Month", "MONTH")
        '            .ColumnMappings.Add("Geo", "GEO")
        '            .ColumnMappings.Add("Stream", "STREAM")
        '            .ColumnMappings.Add("Household", "HOUSEHOLD_UE")
        '            .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_UE")
        '            .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_UE")
        '            .ColumnMappings.Add("Males12to17", "MALES_12TO17_UE")
        '            .ColumnMappings.Add("Males18to20", "MALES_18TO20_UE")
        '            .ColumnMappings.Add("Males21to24", "MALES_21TO24_UE")
        '            .ColumnMappings.Add("Males25to34", "MALES_25TO34_UE")
        '            .ColumnMappings.Add("Males35to49", "MALES_35TO49_UE")
        '            .ColumnMappings.Add("Males50to54", "MALES_50TO54_UE")
        '            .ColumnMappings.Add("Males55to64", "MALES_55TO64_UE")
        '            .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_UE")
        '            .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_UE")
        '            .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_UE")
        '            .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_UE")
        '            .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_UE")
        '            .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_UE")
        '            .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_UE")
        '            .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_UE")
        '            .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_UE")
        '            .ColumnMappings.Add("Validated", "VALIDATED")

        '            .BulkCopyTimeout = 0
        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NCC_TV_FUSION_UE"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        'Private Sub BulkInsertNCCTVFusionAudienceList(SqlConnection As SqlClient.SqlConnection,
        '                                              NCCTVFusionAudiences As List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionAudience))

        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NCCTVFusionAudiences.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("ID", "NCC_TV_FUSION_AUDIENCE_ID")
        '            .ColumnMappings.Add("NCCTVFusionUniverseID", "NCC_TV_FUSION_UE_ID")
        '            .ColumnMappings.Add("StationCode", "STATION_CODE")
        '            .ColumnMappings.Add("AudienceDatetime", "AUDIENCE_DATETIME")
        '            .ColumnMappings.Add("Household", "HOUSEHOLD_AUD")
        '            .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_AUD")
        '            .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_AUD")
        '            .ColumnMappings.Add("Males12to17", "MALES_12TO17_AUD")
        '            .ColumnMappings.Add("Males18to20", "MALES_18TO20_AUD")
        '            .ColumnMappings.Add("Males21to24", "MALES_21TO24_AUD")
        '            .ColumnMappings.Add("Males25to34", "MALES_25TO34_AUD")
        '            .ColumnMappings.Add("Males35to49", "MALES_35TO49_AUD")
        '            .ColumnMappings.Add("Males50to54", "MALES_50TO54_AUD")
        '            .ColumnMappings.Add("Males55to64", "MALES_55TO64_AUD")
        '            .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_AUD")
        '            .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_AUD")
        '            .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_AUD")
        '            .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_AUD")
        '            .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_AUD")
        '            .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_AUD")
        '            .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_AUD")
        '            .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_AUD")
        '            .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_AUD")

        '            .BulkCopyTimeout = 0
        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NCC_TV_FUSION_AUDIENCE"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        'Private Sub BulkInsertNCCTVFusionHutputList(SqlConnection As SqlClient.SqlConnection,
        '                                            NCCTVFusionHutputS As List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionHutput))

        '    Dim DataTable As System.Data.DataTable = Nothing

        '    DataTable = NCCTVFusionHutputS.ToDataTable

        '    Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

        '        With SqlBulkCopy

        '            .ColumnMappings.Add("ID", "NCC_TV_FUSION_HUTPUT_ID")
        '            .ColumnMappings.Add("NCCTVFusionUniverseID", "NCC_TV_FUSION_UE_ID")
        '            .ColumnMappings.Add("HutputDatetime", "HUTPUT_DATETIME")
        '            .ColumnMappings.Add("Household", "HOUSEHOLD_HUT")
        '            .ColumnMappings.Add("Children2to5", "CHILDREN_2TO5_PUT")
        '            .ColumnMappings.Add("Children6to11", "CHILDREN_6TO11_PUT")
        '            .ColumnMappings.Add("Males12to17", "MALES_12TO17_PUT")
        '            .ColumnMappings.Add("Males18to20", "MALES_18TO20_PUT")
        '            .ColumnMappings.Add("Males21to24", "MALES_21TO24_PUT")
        '            .ColumnMappings.Add("Males25to34", "MALES_25TO34_PUT")
        '            .ColumnMappings.Add("Males35to49", "MALES_35TO49_PUT")
        '            .ColumnMappings.Add("Males50to54", "MALES_50TO54_PUT")
        '            .ColumnMappings.Add("Males55to64", "MALES_55TO64_PUT")
        '            .ColumnMappings.Add("Males65Plus", "MALES_65PLUS_PUT")
        '            .ColumnMappings.Add("Females12to17", "FEMALES_12TO17_PUT")
        '            .ColumnMappings.Add("Females18to20", "FEMALES_18TO20_PUT")
        '            .ColumnMappings.Add("Females21to24", "FEMALES_21TO24_PUT")
        '            .ColumnMappings.Add("Females25to34", "FEMALES_25TO34_PUT")
        '            .ColumnMappings.Add("Females35to49", "FEMALES_35TO49_PUT")
        '            .ColumnMappings.Add("Females50to54", "FEMALES_50TO54_PUT")
        '            .ColumnMappings.Add("Females55to64", "FEMALES_55TO64_PUT")
        '            .ColumnMappings.Add("Females65Plus", "FEMALES_65PLUS_PUT")

        '            .BulkCopyTimeout = 0
        '            .BatchSize = DataTable.Rows.Count
        '            .DestinationTableName = "NCC_TV_FUSION_HUTPUT"
        '            .WriteToServer(DataTable)

        '        End With

        '    End Using

        'End Sub
        Private Sub BulkInsertNCCTVAIUELogList(SqlConnection As SqlClient.SqlConnection,
                                               NCCTVAIUELogs As List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELog))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVAIUELogs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_AI_UE_LOG_ID")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("Month", "MONTH")
                    .ColumnMappings.Add("Validated", "VALIDATED")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_AI_UE_LOG"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNCCTVAIUEList(SqlConnection As SqlClient.SqlConnection,
                                            NCCTVAIUEs As List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUE))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVAIUEs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_AI_UE_ID")
                    .ColumnMappings.Add("Syscode", "SYSCODE")
                    .ColumnMappings.Add("NCCTVAIUELogID", "NCC_TV_AI_UE_LOG_ID")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("SampleType", "SAMPLE_TYPE")
                    .ColumnMappings.Add("HHAIUE", "HH_AIUE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_AI_UE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNCCTVCarriageUELogList(SqlConnection As SqlClient.SqlConnection,
                                                     NCCTVCarriageUELogs As List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELog))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVCarriageUELogs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_CARRIAGE_UE_LOG_ID")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("Month", "MONTH")
                    .ColumnMappings.Add("Validated", "VALIDATED")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_CARRIAGE_UE_LOG"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNCCTVCarriageUEList(SqlConnection As SqlClient.SqlConnection,
                                                  NCCTVCarriageUEs As List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUE))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NCCTVCarriageUEs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NCC_TV_CARRIAGE_UE_ID")
                    .ColumnMappings.Add("NielsenMarketNumber", "NIELSEN_MARKET_NUM")
                    .ColumnMappings.Add("NCCTVCarriageUELogID", "NCC_TV_CARRIAGE_UE_LOG_ID")
                    .ColumnMappings.Add("StationCode", "STATION_CODE")
                    .ColumnMappings.Add("HHCarriageUE", "HH_CARRIAGE_UE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NCC_TV_CARRIAGE_UE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub GetNCCTVMVPDs(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVMVPDs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVMVPD) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVMVPD.GetMaxID(NielsenDBContext)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVMVPD")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NCCTVMVPDs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVMVPD))(RestResponse.Content)

                        BulkInsertNCCTVMVPDList(SqlConnection, NCCTVMVPDs)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNCCTVMVPDs")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub UpdateNCCTVSyscodes(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVSyscodes As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode) = Nothing
            Dim NCCTVSyscode As AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetMaxID(NielsenDBContext)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVSyscode/GetExisting")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDLessThanEqualTo", MaxID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NCCTVSyscodes = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode))(RestResponse.Content)

                        For Each Syscode In NCCTVSyscodes

                            NCCTVSyscode = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.LoadByID(NielsenDBContext, Syscode.ID)

                            If NCCTVSyscode IsNot Nothing Then

                                NCCTVSyscode.Syscode = Syscode.Syscode
                                NCCTVSyscode.NCCTVMVPDID = Syscode.NCCTVMVPDID
                                NCCTVSyscode.NielsenMarketNumber = Syscode.NielsenMarketNumber
                                NCCTVSyscode.SystemName = Syscode.SystemName
                                NCCTVSyscode.SystemType = Syscode.SystemType

                                NielsenDBContext.Entry(NCCTVSyscode).State = Entity.EntityState.Modified

                            End If

                        Next

                        NielsenDBContext.SaveChanges()

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from UpdateNCCTVSyscodes")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNCCTVSyscodes(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVSyscodes As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetMaxID(NielsenDBContext)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVSyscode")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NCCTVSyscodes = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode))(RestResponse.Content)

                        BulkInsertNCCTVSyscodeList(SqlConnection, NCCTVSyscodes)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNCCTVSyscodes")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNCCTVLPMMarkets(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVLPMMarkets As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVLPMMarket) = Nothing
            Dim NCCTVLPMMarket As AdvantageFramework.Nielsen.Database.Entities.NCCTVLPMMarket = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVLPMMarket")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NCCTVLPMMarkets = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVLPMMarket))(RestResponse.Content)

                    Using tran = NielsenDBContext.Database.BeginTransaction

                        Try

                            NielsenDBContext.Database.ExecuteSqlCommand("DELETE dbo.NCC_TV_LPM_MARKET")

                            For Each Market In NCCTVLPMMarkets

                                NCCTVLPMMarket = New AdvantageFramework.Nielsen.Database.Entities.NCCTVLPMMarket
                                NCCTVLPMMarket.NielsenMarketNumber = Market.NielsenMarketNumber

                                NielsenDBContext.NCCTVLPMMarkets.Add(NCCTVLPMMarket)

                            Next

                            NielsenDBContext.SaveChanges()

                            tran.Commit()

                        Catch ex As Exception

                            tran.Rollback()

                        End Try

                    End Using

                Else

                    Throw New Exception("INFO: No reply from GetNCCTVLPMMarkets")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub UpdateNCCTVCablenets(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVCablenets As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCablenet) = Nothing
            Dim NCCTVCablenet As AdvantageFramework.Nielsen.Database.Entities.NCCTVCablenet = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.GetMaxID(NielsenDBContext)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVCablenet/GetExisting")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDLessThanEqualTo", MaxID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NCCTVCablenets = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCablenet))(RestResponse.Content)

                        For Each Cablenet In NCCTVCablenets

                            NCCTVCablenet = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.LoadByID(NielsenDBContext, Cablenet.ID)

                            If NCCTVCablenet IsNot Nothing Then

                                NCCTVCablenet.NetworkCode = Cablenet.NetworkCode
                                NCCTVCablenet.NetworkName = Cablenet.NetworkName
                                NCCTVCablenet.StationCode = Cablenet.StationCode
                                NCCTVCablenet.ComscoreStationCode = Cablenet.ComscoreStationCode

                                NielsenDBContext.Entry(NCCTVCablenet).State = Entity.EntityState.Modified
                                NielsenDBContext.SaveChanges()

                            End If

                        Next

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from UpdateNCCTVCablenets")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNCCTVCablenets(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVCablenets As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCablenet) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.GetMaxID(NielsenDBContext)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVCablenet")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NCCTVCablenets = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCablenet))(RestResponse.Content)

                        BulkInsertNCCTVCablenetList(SqlConnection, NCCTVCablenets)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNCCTVCablenets")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        'Private Function GetNCCTVFusionUniverseByClientCode(ClientCode As String) As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse)

        '    'objects
        '    Dim RestClient As RestSharp.RestClient = Nothing
        '    Dim RestRequest As RestSharp.RestRequest = Nothing
        '    Dim RestResponse As RestSharp.IRestResponse = Nothing
        '    Dim NCCTVFusionUniverses As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse) = Nothing

        '    Try

        '        RestClient = CreateRestClient()

        '        RestRequest = New RestSharp.RestRequest("NCCTVFusionUniverse/GetByClientCode")

        '        RestRequest.Timeout = _Timeout
        '        RestRequest.Method = RestSharp.Method.GET
        '        RestRequest.RequestFormat = RestSharp.DataFormat.Json
        '        RestRequest.AddParameter("ClientCode", ClientCode)

        '        RestResponse = RestClient.Execute(RestRequest)

        '        If RestResponse.StatusDescription = "OK" Then

        '            NCCTVFusionUniverses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse))(RestResponse.Content)

        '        Else

        '            Throw New Exception("INFO: No reply from GetNCCTVCablenets")

        '        End If

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        '    GetNCCTVFusionUniverseByClientCode = NCCTVFusionUniverses

        'End Function
        'Private Sub GetNCCTVFusionAudience(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
        '                                   NCCTVFusionUniverseID As Int64)

        '    'objects
        '    Dim MaxID As Int64 = 0
        '    Dim RestClient As RestSharp.RestClient = Nothing
        '    Dim RestRequest As RestSharp.RestRequest = Nothing
        '    Dim RestResponse As RestSharp.IRestResponse = Nothing
        '    Dim NCCTVFusionAudiences As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionAudience) = Nothing
        '    Dim Parameter As RestSharp.Parameter = Nothing
        '    Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

        '    Try

        '        MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVFusionAudience.GetMaxIDByNCCTVFusionUniverseID(NielsenDBContext, NCCTVFusionUniverseID)

        '        RestClient = CreateRestClient()

        '        RestRequest = New RestSharp.RestRequest("NCCTVFusionAudience")

        '        RestRequest.Timeout = _Timeout
        '        RestRequest.Method = RestSharp.Method.GET
        '        RestRequest.RequestFormat = RestSharp.DataFormat.Json
        '        RestRequest.AddParameter("IDGreaterThan", MaxID)
        '        RestRequest.AddParameter("NCCTVFusionUniverseID", NCCTVFusionUniverseID)
        '        RestRequest.AddParameter("Page", 0)

        '        Do

        '            RestResponse = RestClient.Execute(RestRequest)

        '            If RestResponse.StatusDescription = "OK" Then

        '                NCCTVFusionAudiences = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionAudience))(RestResponse.Content)

        '                BulkInsertNCCTVFusionAudienceList(SqlConnection, NCCTVFusionAudiences)

        '                Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

        '                If Parameter IsNot Nothing Then

        '                    PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

        '                    RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

        '                End If

        '            Else

        '                Throw New Exception("INFO: No reply from GetNCCTVCablenets")

        '            End If

        '        Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Sub
        'Private Sub GetNCCTVFusionHutput(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
        '                                 NCCTVFusionUniverseID As Int64)

        '    'objects
        '    Dim MaxID As Int64 = 0
        '    Dim RestClient As RestSharp.RestClient = Nothing
        '    Dim RestRequest As RestSharp.RestRequest = Nothing
        '    Dim RestResponse As RestSharp.IRestResponse = Nothing
        '    Dim NCCTVFusionHutputS As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionHutput) = Nothing
        '    Dim Parameter As RestSharp.Parameter = Nothing
        '    Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

        '    Try

        '        MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVFusionHutput.GetMaxIDByNCCTVFusionUniverseID(NielsenDBContext, NCCTVFusionUniverseID)

        '        RestClient = CreateRestClient()

        '        RestRequest = New RestSharp.RestRequest("NCCTVFusionHutput")

        '        RestRequest.Timeout = _Timeout
        '        RestRequest.Method = RestSharp.Method.GET
        '        RestRequest.RequestFormat = RestSharp.DataFormat.Json
        '        RestRequest.AddParameter("IDGreaterThan", MaxID)
        '        RestRequest.AddParameter("NCCTVFusionUniverseID", NCCTVFusionUniverseID)
        '        RestRequest.AddParameter("Page", 0)

        '        Do

        '            RestResponse = RestClient.Execute(RestRequest)

        '            If RestResponse.StatusDescription = "OK" Then

        '                NCCTVFusionHutputS = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionHutput))(RestResponse.Content)

        '                BulkInsertNCCTVFusionHutputList(SqlConnection, NCCTVFusionHutputS)

        '                Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

        '                If Parameter IsNot Nothing Then

        '                    PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

        '                    RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

        '                End If

        '            Else

        '                Throw New Exception("INFO: No reply from GetNCCTVCablenets")

        '            End If

        '        Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Sub
        'Private Function GetNCCTVFusionCountByUEID(NCCTVFusionUniverseID As Int64) As Int64

        '    'objects
        '    Dim RestClient As RestSharp.RestClient = Nothing
        '    Dim RestRequest As RestSharp.RestRequest = Nothing
        '    Dim RestResponse As RestSharp.IRestResponse = Nothing
        '    Dim BookRowCount As Int64 = 0

        '    Try

        '        RestClient = CreateRestClient()

        '        RestRequest = New RestSharp.RestRequest("NCCTVFusionUniverse/GetCountByID")

        '        RestRequest.Timeout = _Timeout
        '        RestRequest.Method = RestSharp.Method.GET
        '        RestRequest.RequestFormat = RestSharp.DataFormat.Json
        '        RestRequest.AddParameter("NCCTVFusionUniverseID", NCCTVFusionUniverseID)

        '        RestResponse = RestClient.Execute(RestRequest)

        '        If RestResponse.StatusDescription = "OK" Then

        '            BookRowCount = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Int64)(RestResponse.Content)

        '            GetNCCTVFusionCountByUEID = BookRowCount

        '        Else

        '            Throw New Exception("INFO: No reply from GetNCCTVCablenets")

        '        End If

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Function
        Private Function GetNCCTVAIUELogs() As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELog)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVAIUELogs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELog) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVAIUELog")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NCCTVAIUELogs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELog))(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from GetNCCTVAIUELogs")

                End If

            Catch ex As Exception
                Throw ex
            End Try

            GetNCCTVAIUELogs = NCCTVAIUELogs

        End Function
        Private Sub GetNCCTVAIUEs(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                  NCCTVAIUELogID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVAIUEs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUE) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVAIUE.GetMaxIDByNCCTVAIUELogID(NielsenDBContext, NCCTVAIUELogID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVAIUE")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NCCTVAIUELogID", NCCTVAIUELogID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NCCTVAIUEs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUE))(RestResponse.Content)

                        BulkInsertNCCTVAIUEList(SqlConnection, NCCTVAIUEs)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNCCTVAIUEs")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function GetNCCTVAIUECountByNCCTVAIUELogID(NCCTVAIUELogID As Int64) As Int64

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim BookRowCount As Int64 = 0

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVAIUE/GetCountByNCCTVAIUELogID")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("NCCTVAIUELogID", NCCTVAIUELogID)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    BookRowCount = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Int64)(RestResponse.Content)

                    GetNCCTVAIUECountByNCCTVAIUELogID = BookRowCount

                Else

                    Throw New Exception("INFO: No reply from GetNCCTVAIUECountByNCCTVAIUELogID")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Private Function GetNCCTVCarriageUELogs() As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELog)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVCarriageUELogs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELog) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVCarriageUELog")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NCCTVCarriageUELogs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELog))(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from GetNCCTVCarriageUELogs")

                End If

            Catch ex As Exception
                Throw ex
            End Try

            GetNCCTVCarriageUELogs = NCCTVCarriageUELogs

        End Function
        Private Sub GetNCCTVCarriageUEs(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                        NCCTVCarriageUELogID As Int64)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVCarriageUEs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUE) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCarriageUE.GetMaxIDByNCCTVCarriageUELogID(NielsenDBContext, NCCTVCarriageUELogID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVCarriageUE")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NCCTVCarriageUELogID", NCCTVCarriageUELogID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NCCTVCarriageUEs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUE))(RestResponse.Content)

                        BulkInsertNCCTVCarriageUEList(SqlConnection, NCCTVCarriageUEs)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNCCTVCarriageUEs")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function GetNCCTVCarriageUECountByNCCTVCarriageUELogID(NCCTVCarriageUELogID As Int64) As Int64

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim BookRowCount As Int64 = 0

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVCarriageUE/GetCountByNCCTVCarriageUELogID")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("NCCTVCarriageUELogID", NCCTVCarriageUELogID)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    BookRowCount = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Int64)(RestResponse.Content)

                    GetNCCTVCarriageUECountByNCCTVCarriageUELogID = BookRowCount

                Else

                    Throw New Exception("INFO: No reply from GetNCCTVCarriageUECountByNCCTVCarriageUELogID")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Private Sub DeleteNCCFusionRevised(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVFusionUniverseRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverseRevision) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVFusionUniverseRevision/Get")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NCCTVFusionUniverseRevisions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverseRevision))(RestResponse.Content)

                    For Each NCCTVFusionUniverseRevision In NCCTVFusionUniverseRevisions

                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_FUSION_AUDIENCE WHERE NCC_TV_FUSION_UE_ID = {0}", NCCTVFusionUniverseRevision.OldNCCTVFusionUniverseID))
                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_FUSION_HUTPUT WHERE NCC_TV_FUSION_UE_ID = {0}", NCCTVFusionUniverseRevision.OldNCCTVFusionUniverseID))
                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_FUSION_UE WHERE NCC_TV_FUSION_UE_ID = {0}", NCCTVFusionUniverseRevision.OldNCCTVFusionUniverseID))

                    Next

                Else

                    Throw New Exception("INFO: No reply from DeleteNCCFusionRevised")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub DeleteNCCAIUERevised(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVAIUELogRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELogRevision) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVAIUELogRevision/Get")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NCCTVAIUELogRevisions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELogRevision))(RestResponse.Content)

                    For Each NCCTVAIUELogRevision In NCCTVAIUELogRevisions

                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_AI_UE WHERE NCC_TV_AI_UE_LOG_ID = {0}", NCCTVAIUELogRevision.OldNCCTVAIUELogID))
                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_AI_UE_LOG WHERE NCC_TV_AI_UE_LOG_ID = {0}", NCCTVAIUELogRevision.OldNCCTVAIUELogID))

                    Next

                Else

                    Throw New Exception("INFO: No reply from DeleteNCCAIUERevised")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub DeleteNCCCarriageUERevised(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NCCTVCarriageUELogRevisions As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELogRevision) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVCarriageUELogRevision/Get")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    NCCTVCarriageUELogRevisions = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELogRevision))(RestResponse.Content)

                    For Each NCCTVCarriageUELogRevision In NCCTVCarriageUELogRevisions

                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_CARRIAGE_UE WHERE NCC_TV_CARRIAGE_UE_LOG_ID = {0}", NCCTVCarriageUELogRevision.OldNCCTVCarriageUELogID))
                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NCC_TV_CARRIAGE_UE_LOG WHERE NCC_TV_CARRIAGE_UE_LOG_ID = {0}", NCCTVCarriageUELogRevision.OldNCCTVCarriageUELogID))

                    Next

                Else

                    Throw New Exception("INFO: No reply from DeleteNCCCarriageUERevised")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function IsNCCSubscribed(ClientCode As String) As Boolean

            'objects
            Dim IsSubscribed As Boolean = False
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NCCTVSyscode/IsNCCSubscribed")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("ClientCode", ClientCode)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    IsSubscribed = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Boolean)(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from IsNCCSubscribed")

                End If

            Catch ex As Exception
                Throw ex
            End Try

            IsNCCSubscribed = IsSubscribed

        End Function

#End Region

#Region " Radio County "

        Private Sub BulkInsertNielsenRadioCountyAudienceList(SqlConnection As SqlClient.SqlConnection,
                                                             NielsenRadioCountyAudiences As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyAudience))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioCountyAudiences.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_COUNTY_AUDIENCE_ID")
                    .ColumnMappings.Add("NielsenRadioCountyPeriodID", "NIELSEN_RADIO_COUNTY_PERIOD_ID")
                    .ColumnMappings.Add("NielsenRadioDaypartID", "NIELSEN_RADIO_DAYPART_ID")
                    .ColumnMappings.Add("NielsenRadioCountyStationID", "NIELSEN_RADIO_COUNTY_STATION_ID")
                    .ColumnMappings.Add("Persons12PlusAQH", "PERSONS_12PLUS_AQH")
                    .ColumnMappings.Add("Persons12to34AQH", "PERSONS_12TO34_AQH")
                    .ColumnMappings.Add("Persons18PlusAQH", "PERSONS_18PLUS_AQH")
                    .ColumnMappings.Add("Persons18to34AQH", "PERSONS_18TO34_AQH")
                    .ColumnMappings.Add("Persons25to54AQH", "PERSONS_25TO54_AQH")
                    .ColumnMappings.Add("Persons35PlusAQH", "PERSONS_35PLUS_AQH")
                    .ColumnMappings.Add("Persons35to64AQH", "PERSONS_35TO64_AQH")
                    .ColumnMappings.Add("Males18PlusAQH", "MALES_18PLUS_AQH")
                    .ColumnMappings.Add("Females18PlusAQH", "FEMALES_18PLUS_AQH")
                    .ColumnMappings.Add("Persons12PlusRating", "PERSONS_12PLUS_RATING")
                    .ColumnMappings.Add("Persons12to34Rating", "PERSONS_12TO34_RATING")
                    .ColumnMappings.Add("Persons18PlusRating", "PERSONS_18PLUS_RATING")
                    .ColumnMappings.Add("Persons18to34Rating", "PERSONS_18TO34_RATING")
                    .ColumnMappings.Add("Persons25to54Rating", "PERSONS_25TO54_RATING")
                    .ColumnMappings.Add("Persons35PlusRating", "PERSONS_35PLUS_RATING")
                    .ColumnMappings.Add("Persons35to64Rating", "PERSONS_35TO64_RATING")
                    .ColumnMappings.Add("Males18PlusRating", "MALES_18PLUS_RATING")
                    .ColumnMappings.Add("Females18PlusRating", "FEMALES_18PLUS_RATING")
                    .ColumnMappings.Add("Persons12PlusSSOC", "PERSONS_12PLUS_SSOC")
                    .ColumnMappings.Add("Persons12to34SSOC", "PERSONS_12TO34_SSOC")
                    .ColumnMappings.Add("Persons18PlusSSOC", "PERSONS_18PLUS_SSOC")
                    .ColumnMappings.Add("Persons18to34SSOC", "PERSONS_18TO34_SSOC")
                    .ColumnMappings.Add("Persons25to54SSOC", "PERSONS_25TO54_SSOC")
                    .ColumnMappings.Add("Persons35PlusSSOC", "PERSONS_35PLUS_SSOC")
                    .ColumnMappings.Add("Persons35to64SSOC", "PERSONS_35TO64_SSOC")
                    .ColumnMappings.Add("Males18PlusSSOC", "MALES_18PLUS_SSOC")
                    .ColumnMappings.Add("Females18PlusSSOC", "FEMALES_18PLUS_SSOC")
                    .ColumnMappings.Add("Persons12PlusCSOS", "PERSONS_12PLUS_CSOS")
                    .ColumnMappings.Add("Persons12to34CSOS", "PERSONS_12TO34_CSOS")
                    .ColumnMappings.Add("Persons18PlusCSOS", "PERSONS_18PLUS_CSOS")
                    .ColumnMappings.Add("Persons18to34CSOS", "PERSONS_18TO34_CSOS")
                    .ColumnMappings.Add("Persons25to54CSOS", "PERSONS_25TO54_CSOS")
                    .ColumnMappings.Add("Persons35PlusCSOS", "PERSONS_35PLUS_CSOS")
                    .ColumnMappings.Add("Persons35to64CSOS", "PERSONS_35TO64_CSOS")
                    .ColumnMappings.Add("Males18PlusCSOS", "MALES_18PLUS_CSOS")
                    .ColumnMappings.Add("Females18PlusCSOS", "FEMALES_18PLUS_CSOS")
                    .ColumnMappings.Add("Persons12PlusCUME", "PERSONS_12PLUS_CUME")
                    .ColumnMappings.Add("Persons12to34CUME", "PERSONS_12TO34_CUME")
                    .ColumnMappings.Add("Persons18PlusCUME", "PERSONS_18PLUS_CUME")
                    .ColumnMappings.Add("Persons18to34CUME", "PERSONS_18TO34_CUME")
                    .ColumnMappings.Add("Persons25to54CUME", "PERSONS_25TO54_CUME")
                    .ColumnMappings.Add("Persons35PlusCUME", "PERSONS_35PLUS_CUME")
                    .ColumnMappings.Add("Persons35to64CUME", "PERSONS_35TO64_CUME")
                    .ColumnMappings.Add("Males18PlusCUME", "MALES_18PLUS_CUME")
                    .ColumnMappings.Add("Females18PlusCUME", "FEMALES_18PLUS_CUME")
                    .ColumnMappings.Add("Persons12PlusCUMERating", "PERSONS_12PLUS_CUME_RATING")
                    .ColumnMappings.Add("Persons12to34CUMERating", "PERSONS_12TO34_CUME_RATING")
                    .ColumnMappings.Add("Persons18PlusCUMERating", "PERSONS_18PLUS_CUME_RATING")
                    .ColumnMappings.Add("Persons18to34CUMERating", "PERSONS_18TO34_CUME_RATING")
                    .ColumnMappings.Add("Persons25to54CUMERating", "PERSONS_25TO54_CUME_RATING")
                    .ColumnMappings.Add("Persons35PlusCUMERating", "PERSONS_35PLUS_CUME_RATING")
                    .ColumnMappings.Add("Persons35to64CUMERating", "PERSONS_35TO64_CUME_RATING")
                    .ColumnMappings.Add("Males18PlusCUMERating", "MALES_18PLUS_CUME_RATING")
                    .ColumnMappings.Add("Females18PlusCUMERating", "FEMALES_18PLUS_CUME_RATING")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_COUNTY_AUDIENCE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioCountyClusterList(SqlConnection As SqlClient.SqlConnection,
                                                            NielsenRadioCountyClusters As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyCluster))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioCountyClusters.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_COUNTY_CLUSTER_ID")
                    .ColumnMappings.Add("NielsenRadioCountyPeriodID", "NIELSEN_RADIO_COUNTY_PERIOD_ID")
                    .ColumnMappings.Add("CountyCodeWithinCluster", "COUNTY_CODE_WITHIN_CLUSTER")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("Pop12Plus", "POP_12PLUS")
                    .ColumnMappings.Add("State", "STATE")
                    .ColumnMappings.Add("ClusterMeasurementType", "CLUSTER_MEASUREMENT_TYPE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_COUNTY_CLUSTER"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioCountyIntabList(SqlConnection As SqlClient.SqlConnection,
                                                          NielsenRadioCountyIntabs As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyIntab))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioCountyIntabs.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_COUNTY_INTAB_ID")
                    .ColumnMappings.Add("NielsenRadioCountyPeriodID", "NIELSEN_RADIO_COUNTY_PERIOD_ID")
                    .ColumnMappings.Add("Persons12Plus", "PERSONS_12PLUS_INTAB")
                    .ColumnMappings.Add("Persons12to34", "PERSONS_12TO34_INTAB")
                    .ColumnMappings.Add("Persons18Plus", "PERSONS_18PLUS_INTAB")
                    .ColumnMappings.Add("Persons18to34", "PERSONS_18TO34_INTAB")
                    .ColumnMappings.Add("Persons25to54", "PERSONS_25TO54_INTAB")
                    .ColumnMappings.Add("Persons35Plus", "PERSONS_35PLUS_INTAB")
                    .ColumnMappings.Add("Persons35to64", "PERSONS_35TO64_INTAB")
                    .ColumnMappings.Add("Males18Plus", "MALES_18PLUS_INTAB")
                    .ColumnMappings.Add("Females18Plus", "FEMALES_18PLUS_INTAB")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_COUNTY_INTAB"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioCountyPeriodList(SqlConnection As SqlClient.SqlConnection,
                                                           NielsenRadioCountyPeriods As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyPeriod))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioCountyPeriods.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_COUNTY_PERIOD_ID")
                    .ColumnMappings.Add("NielsenRadioMarketNumber", "NIELSEN_RADIO_MARKET_NUMBER")
                    .ColumnMappings.Add("CountyCode", "COUNTY_CODE")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("StartDate", "START_DATE")
                    .ColumnMappings.Add("EndDate", "END_DATE")
                    .ColumnMappings.Add("IsCluster", "IS_CLUSTER")
                    .ColumnMappings.Add("Name", "NAME")
                    .ColumnMappings.Add("State", "STATE")
                    .ColumnMappings.Add("WeightingFlag", "WEIGHTING_FLAG")
                    .ColumnMappings.Add("MeasurementType", "MEASUREMENT_TYPE")
                    .ColumnMappings.Add("Copyright", "COPYRIGHT")
                    .ColumnMappings.Add("Validated", "VALIDATED")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_COUNTY_PERIOD"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioCountyStationList(SqlConnection As SqlClient.SqlConnection,
                                                            NielsenRadioCountyStations As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyStation))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioCountyStations.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_COUNTY_STATION_ID")
                    .ColumnMappings.Add("Year", "YEAR")
                    .ColumnMappings.Add("CallLetters", "CALL_LETTERS")
                    .ColumnMappings.Add("Band", "BAND")
                    .ColumnMappings.Add("CityLicense", "CITY_LICENSE")
                    .ColumnMappings.Add("CountyLicense", "COUNTY_LICENSE")
                    .ColumnMappings.Add("StateLicense", "STATE_LICENSE")
                    .ColumnMappings.Add("Affiliation", "AFFILIATION")
                    .ColumnMappings.Add("OtherAffiliations", "OTHER_AFFILIATIONS")
                    .ColumnMappings.Add("Frequency", "FREQUENCY")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_COUNTY_STATION"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertNielsenRadioCountyUniverseList(SqlConnection As SqlClient.SqlConnection,
                                                             NielsenRadioCountyUniverses As List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyUniverse))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = NielsenRadioCountyUniverses.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(SqlConnection.ConnectionString, SqlClient.SqlBulkCopyOptions.KeepIdentity)

                With SqlBulkCopy

                    .ColumnMappings.Add("ID", "NIELSEN_RADIO_COUNTY_UNIVERSE_ID")
                    .ColumnMappings.Add("NielsenRadioCountyPeriodID", "NIELSEN_RADIO_COUNTY_PERIOD_ID")
                    .ColumnMappings.Add("Persons12Plus", "PERSONS_12PLUS_UE")
                    .ColumnMappings.Add("Persons12to34", "PERSONS_12TO34_UE")
                    .ColumnMappings.Add("Persons18Plus", "PERSONS_18PLUS_UE")
                    .ColumnMappings.Add("Persons18to34", "PERSONS_18TO34_UE")
                    .ColumnMappings.Add("Persons25to54", "PERSONS_25TO54_UE")
                    .ColumnMappings.Add("Persons35Plus", "PERSONS_35PLUS_UE")
                    .ColumnMappings.Add("Persons35to64", "PERSONS_35TO64_UE")
                    .ColumnMappings.Add("Males18Plus", "MALES_18PLUS_UE")
                    .ColumnMappings.Add("Females18Plus", "FEMALES_18PLUS_UE")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "NIELSEN_RADIO_COUNTY_UNIVERSE"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub GetNielsenRadioCountyAudience(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                  NielsenRadioCountyPeriodID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioCountyAudiences As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyAudience) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyAudience.GetMaxIDByNielsenRadioCountyPeriodID(NielsenDBContext, NielsenRadioCountyPeriodID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioCountyAudience")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NielsenRadioCountyPeriodID", NielsenRadioCountyPeriodID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioCountyAudiences = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyAudience))(RestResponse.Content)

                        BulkInsertNielsenRadioCountyAudienceList(SqlConnection, NielsenRadioCountyAudiences)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioCountyAudience")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioCountyCluster(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                 NielsenRadioCountyPeriodID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioCountyClusters As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyCluster) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyCluster.GetMaxIDByNielsenRadioCountyPeriodID(NielsenDBContext, NielsenRadioCountyPeriodID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioCountyCluster")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NielsenRadioCountyPeriodID", NielsenRadioCountyPeriodID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioCountyClusters = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyCluster))(RestResponse.Content)

                        BulkInsertNielsenRadioCountyClusterList(SqlConnection, NielsenRadioCountyClusters)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioCountyCluster")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioCountyIntab(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                               NielsenRadioCountyPeriodID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioCountyIntabs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyIntab) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyIntab.GetMaxIDByNielsenRadioCountyPeriodID(NielsenDBContext, NielsenRadioCountyPeriodID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioCountyIntab")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NielsenRadioCountyPeriodID", NielsenRadioCountyPeriodID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioCountyIntabs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyIntab))(RestResponse.Content)

                        BulkInsertNielsenRadioCountyIntabList(SqlConnection, NielsenRadioCountyIntabs)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioCountyIntab")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioCountyPeriod(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                NielsenRadioCountyPeriodID As Integer)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioCountyPeriod As AdvantageFramework.DTO.Nielsen.NielsenRadioCountyPeriod = Nothing
            Dim NielsenRadioCountyPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyPeriod) = Nothing

            Try

                If AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.LoadByID(NielsenDBContext, NielsenRadioCountyPeriodID) Is Nothing Then

                    RestClient = CreateRestClient()

                    RestRequest = New RestSharp.RestRequest("NielsenRadioCountyPeriod/GetByPeriodID")

                    RestRequest.Timeout = _Timeout
                    RestRequest.Method = RestSharp.Method.GET
                    RestRequest.RequestFormat = RestSharp.DataFormat.Json
                    RestRequest.AddParameter("PeriodID", NielsenRadioCountyPeriodID)

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioCountyPeriod = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyPeriod)(RestResponse.Content)

                        NielsenRadioCountyPeriods = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyPeriod)
                        NielsenRadioCountyPeriods.Add(NielsenRadioCountyPeriod)

                        BulkInsertNielsenRadioCountyPeriodList(SqlConnection, NielsenRadioCountyPeriods)

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioCountyPeriod")

                    End If

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioCountyStation(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                 Year As Short)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioCountyStations As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyStation) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyStation.GetMaxIDByYear(NielsenDBContext, Year)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioCountyStation")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("Year", Year)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioCountyStations = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyStation))(RestResponse.Content)

                        BulkInsertNielsenRadioCountyStationList(SqlConnection, NielsenRadioCountyStations)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioCountyStation")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Sub GetNielsenRadioCountyUniverse(SqlConnection As SqlClient.SqlConnection, NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                  NielsenRadioCountyPeriodID As Integer)

            'objects
            Dim MaxID As Int64 = 0
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim NielsenRadioCountyUniverses As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyUniverse) = Nothing
            Dim Parameter As RestSharp.Parameter = Nothing
            Dim PaginationHeader As AdvantageFramework.NielsenWebService.Classes.PaginationHeader = Nothing

            Try

                MaxID = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyUniverse.GetMaxIDByNielsenRadioCountyPeriodID(NielsenDBContext, NielsenRadioCountyPeriodID)

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioCountyUniverse")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("IDGreaterThan", MaxID)
                RestRequest.AddParameter("NielsenRadioCountyPeriodID", NielsenRadioCountyPeriodID)
                RestRequest.AddParameter("Page", 0)

                Do

                    RestResponse = RestClient.Execute(RestRequest)

                    If RestResponse.StatusDescription = "OK" Then

                        NielsenRadioCountyUniverses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioCountyUniverse))(RestResponse.Content)

                        BulkInsertNielsenRadioCountyUniverseList(SqlConnection, NielsenRadioCountyUniverses)

                        Parameter = RestResponse.Headers.Where(Function(P) P.Name = "X-Pagination").FirstOrDefault

                        If Parameter IsNot Nothing Then

                            PaginationHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.NielsenWebService.Classes.PaginationHeader)(Parameter.Value.ToString)

                            RestRequest.Parameters.Where(Function(Param) Param.Name = "Page").FirstOrDefault.Value = PaginationHeader.NextPage

                        End If

                    Else

                        Throw New Exception("INFO: No reply from GetNielsenRadioCountyUniverse")

                    End If

                Loop While PaginationHeader IsNot Nothing AndAlso PaginationHeader.NextPage <> -1

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function GetNielsenRadioCountyPeriodsByClientCode(ClientCode As String) As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioCountyPeriod)

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim ClientNielsenRadioCountyPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioCountyPeriod) = Nothing

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioCountyPeriod/GetByClientCode")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("ClientCode", ClientCode)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    ClientNielsenRadioCountyPeriods = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioCountyPeriod))(RestResponse.Content)

                Else

                    Throw New Exception("INFO: No reply from GetNielsenRadioCountyPeriodsByClientCode")

                End If

            Catch ex As Exception
                Throw ex
            Finally
                GetNielsenRadioCountyPeriodsByClientCode = ClientNielsenRadioCountyPeriods
            End Try

        End Function
        Private Function GetNielsenRadioCountyPeriodRowCount(NielsenRadioCountyPeriodID As Integer) As Int64

            'objects
            Dim RestClient As RestSharp.RestClient = Nothing
            Dim RestRequest As RestSharp.RestRequest = Nothing
            Dim RestResponse As RestSharp.IRestResponse = Nothing
            Dim PeriodRowCount As Int64 = 0

            Try

                RestClient = CreateRestClient()

                RestRequest = New RestSharp.RestRequest("NielsenRadioCountyPeriod/GetPeriodRowCount")

                RestRequest.Timeout = _Timeout
                RestRequest.Method = RestSharp.Method.GET
                RestRequest.RequestFormat = RestSharp.DataFormat.Json
                RestRequest.AddParameter("PeriodID", NielsenRadioCountyPeriodID)

                RestResponse = RestClient.Execute(RestRequest)

                If RestResponse.StatusDescription = "OK" Then

                    PeriodRowCount = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Int64)(RestResponse.Content)

                    GetNielsenRadioCountyPeriodRowCount = PeriodRowCount

                Else

                    Throw New Exception("INFO: No reply from GetNielsenRadioCountyPeriodRowCount")

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Private Sub UpdateComscoreStationCode(NielsenDBContext As AdvantageFramework.Nielsen.Database.DbContext)

            NielsenDBContext.Database.ExecuteSqlCommand("UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'A+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ADDR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 372 WHERE NETWORK_CODE = 'AEN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'AFR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8779 WHERE NETWORK_CODE = 'AHC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'AIPB'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'AIPD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'AIPV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8072 WHERE NETWORK_CODE = 'AJAM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 561 WHERE NETWORK_CODE = 'ALT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 401 WHERE NETWORK_CODE = 'AMC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 1 WHERE NETWORK_CODE = 'APL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'APNC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ASPN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7726 WHERE NETWORK_CODE = 'ASPR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ATLV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2163 WHERE NETWORK_CODE = 'ATPT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2160 WHERE NETWORK_CODE = 'ATRM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 9852 WHERE NETWORK_CODE = 'ATSW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'AUD+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'AUOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 327 WHERE NETWORK_CODE = 'AWE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7667 WHERE NETWORK_CODE = 'AXS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8036 WHERE NETWORK_CODE = 'AZAN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 558 WHERE NETWORK_CODE = 'BBCA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'BCS2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7805 WHERE NETWORK_CODE = 'BCSN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8090 WHERE NETWORK_CODE = 'BEIE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7740 WHERE NETWORK_CODE = 'BEIN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 31 WHERE NETWORK_CODE = 'BET'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'BFOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 637 WHERE NETWORK_CODE = 'BHER'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'BINS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7770 WHERE NETWORK_CODE = 'BLAZ'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'BN10'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 341 WHERE NETWORK_CODE = 'BOOM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 367 WHERE NETWORK_CODE = 'BRVO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 367 WHERE NETWORK_CODE = 'BRVW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'BSNM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2072 WHERE NETWORK_CODE = 'BTN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'BTN2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'BTNO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = -38616 WHERE NETWORK_CODE = 'BTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CANL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CASA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2076 WHERE NETWORK_CODE = 'CBSS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6116 WHERE NETWORK_CODE = 'CC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CDED'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CDEV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CET5'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CH8'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CHDU'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2073 WHERE NETWORK_CODE = 'CHIL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CHNI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CHNS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 674 WHERE NETWORK_CODE = 'CI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CIPB'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CIPD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CIPV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CLA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CLTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CLV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CMC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CMCB'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CMCU'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 379 WHERE NETWORK_CODE = 'CMDY'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CMS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 278 WHERE NETWORK_CODE = 'CMT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CN2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 623 WHERE NETWORK_CODE = 'CNBC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CNET'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 28 WHERE NETWORK_CODE = 'CNN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 671 WHERE NETWORK_CODE = 'CNNE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 483 WHERE NETWORK_CODE = 'CNNI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'COTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'COX3'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8584 WHERE NETWORK_CODE = 'CRTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CRWL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5441 WHERE NETWORK_CODE = 'CST'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CTA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CTV3'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CVA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CVV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CX48'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CX74'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CXA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CXLO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'CXV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'DAI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7645 WHERE NETWORK_CODE = 'DAM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'DCTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 634 WHERE NETWORK_CODE = 'DFAM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 625 WHERE NETWORK_CODE = 'DFC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 27 WHERE NETWORK_CODE = 'DISC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 330 WHERE NETWORK_CODE = 'DIY'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 328 WHERE NETWORK_CODE = 'DLIF'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'DMAN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'DPP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 630 WHERE NETWORK_CODE = 'DSE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5095 WHERE NETWORK_CODE = 'DXD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5097 WHERE NETWORK_CODE = 'DXDE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'EDGE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'EDOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ELLA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'EMOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ENGT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 642 WHERE NETWORK_CODE = 'ENN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 381 WHERE NETWORK_CODE = 'ENT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 640 WHERE NETWORK_CODE = 'ESCL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 650 WHERE NETWORK_CODE = 'ESNU'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 639 WHERE NETWORK_CODE = 'ESP2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 641 WHERE NETWORK_CODE = 'ESPD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 33 WHERE NETWORK_CODE = 'ESPN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8096 WHERE NETWORK_CODE = 'ESQ'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ETOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 1310 WHERE NETWORK_CODE = 'FBN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 570 WHERE NETWORK_CODE = 'FCSA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2161 WHERE NETWORK_CODE = 'FCSC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2162 WHERE NETWORK_CODE = 'FCSP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'FIO1'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'FIPD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'FIPV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'FLCN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 361 WHERE NETWORK_CODE = 'FMTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 331 WHERE NETWORK_CODE = 'FOOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 568 WHERE NETWORK_CODE = 'FOXD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8155 WHERE NETWORK_CODE = 'FOXL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11539 WHERE NETWORK_CODE = 'FRFM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8068 WHERE NETWORK_CODE = 'FS1'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8070 WHERE NETWORK_CODE = 'FS2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2164 WHERE NETWORK_CODE = 'FSA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2166 WHERE NETWORK_CODE = 'FSD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6497 WHERE NETWORK_CODE = 'FSDP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2139 WHERE NETWORK_CODE = 'FSFL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 517 WHERE NETWORK_CODE = 'FSHA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 509 WHERE NETWORK_CODE = 'FSMW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11645 WHERE NETWORK_CODE = 'FSN+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 513 WHERE NETWORK_CODE = 'FSNO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8145 WHERE NETWORK_CODE = 'FSNP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 514 WHERE NETWORK_CODE = 'FSOH'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8538 WHERE NETWORK_CODE = 'FSOK'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 569 WHERE NETWORK_CODE = 'FSPT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 516 WHERE NETWORK_CODE = 'FSS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7791 WHERE NETWORK_CODE = 'FSSD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2094 WHERE NETWORK_CODE = 'FSSE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2142 WHERE NETWORK_CODE = 'FSSO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11645 WHERE NETWORK_CODE = 'FSSP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2159 WHERE NETWORK_CODE = 'FSW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2158 WHERE NETWORK_CODE = 'FSWI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 415 WHERE NETWORK_CODE = 'FUSE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8151 WHERE NETWORK_CODE = 'FUSN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 40 WHERE NETWORK_CODE = 'FX'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 566 WHERE NETWORK_CODE = 'FXMR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 565 WHERE NETWORK_CODE = 'FXNC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8082 WHERE NETWORK_CODE = 'FXX'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8913 WHERE NETWORK_CODE = 'FYI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 409 WHERE NETWORK_CODE = 'G4'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 326 WHERE NETWORK_CODE = 'GAC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 296 WHERE NETWORK_CODE = 'GALA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11297 WHERE NETWORK_CODE = 'GCI1'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'GIOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'GO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 308 WHERE NETWORK_CODE = 'GOL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 311 WHERE NETWORK_CODE = 'GOLF'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'GSGT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 371 WHERE NETWORK_CODE = 'GSN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 397 WHERE NETWORK_CODE = 'HALL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'HBC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'HGOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 332 WHERE NETWORK_CODE = 'HGTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'HGTW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 29 WHERE NETWORK_CODE = 'HIST'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'HISW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 406 WHERE NETWORK_CODE = 'HLN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 676 WHERE NETWORK_CODE = 'HMM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'HSNY'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 635 WHERE NETWORK_CODE = 'HSTE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2213 WHERE NETWORK_CODE = 'HTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'I24'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 629 WHERE NETWORK_CODE = 'ID'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 622 WHERE NETWORK_CODE = 'IFC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'IGUN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'IGUV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'IPOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ITVO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'JSU'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 3 WHERE NETWORK_CODE = 'KABC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'KJZZ'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'KN22'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5 WHERE NETWORK_CODE = 'KNBC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'L109'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'L31'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'LADR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'LCOX'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6449 WHERE NETWORK_CODE = 'LEAS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7242 WHERE NETWORK_CODE = 'LHN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 395 WHERE NETWORK_CODE = 'LIF'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 396 WHERE NETWORK_CODE = 'LMN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'LNC5'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6408 WHERE NETWORK_CODE = 'LO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 366 WHERE NETWORK_CODE = 'LOGO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 398 WHERE NETWORK_CODE = 'LRWM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'LWWL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2222 WHERE NETWORK_CODE = 'MAS2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 498 WHERE NETWORK_CODE = 'MASN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MBCN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 18 WHERE NETWORK_CODE = 'MC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MCA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MCC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MCV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MDSN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MGOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 636 WHERE NETWORK_CODE = 'MHIS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5237 WHERE NETWORK_CODE = 'MLBN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6320 WHERE NETWORK_CODE = 'MMTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 357 WHERE NETWORK_CODE = 'MNBC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2088 WHERE NETWORK_CODE = 'MSG'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11980 WHERE NETWORK_CODE = 'MSG2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2167 WHERE NETWORK_CODE = 'MSGP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MSGV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MSP2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MSS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'MSTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2 WHERE NETWORK_CODE = 'MTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 563 WHERE NETWORK_CODE = 'MTV2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'N12'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'N12+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 485 WHERE NETWORK_CODE = 'NBAT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5 WHERE NETWORK_CODE = 'NBC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7438 WHERE NETWORK_CODE = 'NBCS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NC3A'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6645 WHERE NETWORK_CODE = 'NECN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NEIN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 669 WHERE NETWORK_CODE = 'NESN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NEWS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 313 WHERE NETWORK_CODE = 'NFLN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NFOT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 400 WHERE NETWORK_CODE = 'NGC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7018 WHERE NETWORK_CODE = 'NGM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6041 WHERE NETWORK_CODE = 'NGWD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5093 WHERE NETWORK_CODE = 'NHLN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 9 WHERE NETWORK_CODE = 'NICK'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NIKT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NOT1'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 501 WHERE NETWORK_CODE = 'NSBA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2168 WHERE NETWORK_CODE = 'NSBO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2157 WHERE NETWORK_CODE = 'NSBX'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2075 WHERE NETWORK_CODE = 'NSCA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2074 WHERE NETWORK_CODE = 'NSCH'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6059 WHERE NETWORK_CODE = 'NSCX'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6565 WHERE NETWORK_CODE = 'NSNN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6567 WHERE NETWORK_CODE = 'NSPH'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7914 WHERE NETWORK_CODE = 'NSPP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 404 WHERE NETWORK_CODE = 'NSWA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6676 WHERE NETWORK_CODE = 'NSWP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5 WHERE NETWORK_CODE = 'NTVB'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NWBK'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NWBX'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NWCT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NWHV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NWI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NWNJ'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'NWWC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OC16'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OCOL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11381 WHERE NETWORK_CODE = 'OCPP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11044 WHERE NETWORK_CODE = 'OCSP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OFAM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OHOM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OIPD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OIPV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OLYM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OMEN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OMOV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OMUS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ON18'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ONAS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ONEW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ONFM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ONMN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ONMT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ONWN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OPTC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OSPR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10398 WHERE NETWORK_CODE = 'OSTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 407 WHERE NETWORK_CODE = 'OUTD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2257 WHERE NETWORK_CODE = 'OVTN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'OWMN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6524 WHERE NETWORK_CODE = 'OWN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 337 WHERE NETWORK_CODE = 'OXYG'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10967 WHERE NETWORK_CODE = 'P12A'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10963 WHERE NETWORK_CODE = 'P12B'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10961 WHERE NETWORK_CODE = 'P12L'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10965 WHERE NETWORK_CODE = 'P12M'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7756 WHERE NETWORK_CODE = 'P12N'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10955 WHERE NETWORK_CODE = 'P12O'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10959 WHERE NETWORK_CODE = 'P12W'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 378 WHERE NETWORK_CODE = 'PAR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'PCNC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'PGDI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'PGVI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'PLOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 453 WHERE NETWORK_CODE = 'POP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'PROD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'RBTO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'REDS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'REOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7479 WHERE NETWORK_CODE = 'RFD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'RFIV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'RON'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'RRR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6499 WHERE NETWORK_CODE = 'RTNW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'RTOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11001 WHERE NETWORK_CODE = 'RVLT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SCAN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 348 WHERE NETWORK_CODE = 'SCI'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SD4'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 9140 WHERE NETWORK_CODE = 'SECN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 9154 WHERE NETWORK_CODE = 'SECO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6978 WHERE NETWORK_CODE = 'SINO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SLA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SLV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SMS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5049 WHERE NETWORK_CODE = 'SMTD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SNIP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SNLA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SNLS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SNN6'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 497 WHERE NETWORK_CODE = 'SNY'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7785 WHERE NETWORK_CODE = 'SPDP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SPEN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12622 WHERE NETWORK_CODE = 'SPKC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 560 WHERE NETWORK_CODE = 'SPMN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12578 WHERE NETWORK_CODE = 'SPNA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12380 WHERE NETWORK_CODE = 'SPNB'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SPNE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12584 WHERE NETWORK_CODE = 'SPNR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SPNS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12298 WHERE NETWORK_CODE = 'SPNW'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12640 WHERE NETWORK_CODE = 'SPNX'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12612 WHERE NETWORK_CODE = 'SPSA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7781 WHERE NETWORK_CODE = 'SPSN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SPSR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SPSS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SRA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SRCH'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SRV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 499 WHERE NETWORK_CODE = 'STO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 2095 WHERE NETWORK_CODE = 'SUN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 298 WHERE NETWORK_CODE = 'SUND'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 287 WHERE NETWORK_CODE = 'SUR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'SURF'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 377 WHERE NETWORK_CODE = 'SYFY'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11 WHERE NETWORK_CODE = 'TBSC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TCCH'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TDEP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 412 WHERE NETWORK_CODE = 'TENN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 351 WHERE NETWORK_CODE = 'TLC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8034 WHERE NETWORK_CODE = 'TMND'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10 WHERE NETWORK_CODE = 'TNT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 342 WHERE NETWORK_CODE = 'TOON'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 461 WHERE NETWORK_CODE = 'TR3S'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 349 WHERE NETWORK_CODE = 'TRAV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TRIO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TROD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 555 WHERE NETWORK_CODE = 'TRU'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TU70'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 376 WHERE NETWORK_CODE = 'TV1'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TV13'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TV2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TV52'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TVAL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TVE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 467 WHERE NETWORK_CODE = 'TVG2'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 548 WHERE NETWORK_CODE = 'TVL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TW3'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TWA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 402 WHERE NETWORK_CODE = 'TWC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TWNH'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TWNK'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TWSC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'TWV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7554 WHERE NETWORK_CODE = 'UDN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 388 WHERE NETWORK_CODE = 'UHD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8032 WHERE NETWORK_CODE = 'UMAS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 8030 WHERE NETWORK_CODE = 'UNIV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5048 WHERE NETWORK_CODE = 'UP'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 383 WHERE NETWORK_CODE = 'USA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 10020 WHERE NETWORK_CODE = 'UVSO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7331 WHERE NETWORK_CODE = 'VEL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 35 WHERE NETWORK_CODE = 'VH1'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 673 WHERE NETWORK_CODE = 'VICE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'VID+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 679 WHERE NETWORK_CODE = 'VOD'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'VODT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'VZA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'VZV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5075 WHERE NETWORK_CODE = 'WAPA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WBMN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 25 WHERE NETWORK_CODE = 'WCGV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WEB'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WEBB'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WEBO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WEBV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 410 WHERE NETWORK_CODE = 'WETV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 5370 WHERE NETWORK_CODE = 'WFNT'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 368 WHERE NETWORK_CODE = 'WGNA'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 25 WHERE NETWORK_CODE = 'WMYV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WRNN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 6613 WHERE NETWORK_CODE = 'WSCN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WSDM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 20 WHERE NETWORK_CODE = 'WVTV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WWA+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'WWV+'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 3 WHERE NETWORK_CODE = 'WXLV'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'XBOX'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'XCLE'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'XMEM'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'XSTJ'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'XSTL'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'XVO1'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 468 WHERE NETWORK_CODE = 'YES'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7321 WHERE NETWORK_CODE = 'YTOO'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 11960 WHERE NETWORK_CODE = 'YVAZ'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ZBN9'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ZCFN'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ZN53'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ZNWS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ZNY1'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12236 WHERE NETWORK_CODE = 'ZSPC'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12294 WHERE NETWORK_CODE = 'ZSPG'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 12296 WHERE NETWORK_CODE = 'ZSPR'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = 7781 WHERE NETWORK_CODE = 'ZSPS'
                        UPDATE dbo.NCC_TV_CABLENET SET COMSCORE_STATION_CODE = NULL WHERE NETWORK_CODE = 'ZTWC'")

        End Sub

#End Region

#End Region

#Region " Public "

        Public Sub GetData(NielsenConnectionString As String, ClientCode As String, DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, EmployeeCode As String, Timeout As Integer)

            'objects
            Dim ClientNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook) = Nothing
            Dim ClientNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing
            Dim SegmentParentIDs As Generic.List(Of Integer) = Nothing
            Dim NielsenTVBookCountBefore As Integer = 0
            Dim NielsenTVCumeBookCountBefore As Integer = 0
            Dim BookValidateCount As Int64 = 0
            Dim NielsenRadioPeriodCountBefore As Integer = 0
            Dim PeriodValidateCount As Int64 = 0
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ClientNielsenTVCumeBooks As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVCumeBook) = Nothing
            'Dim ClientNCCTVFusionUniverses As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse) = Nothing
            'Dim NCCTVFusionUniverses As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse) = Nothing
            Dim AllNCCTVAIUELogs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELog) = Nothing
            Dim NCCTVAIUELogs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELog) = Nothing
            Dim AllNCCTVCarriageUELogs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELog) = Nothing
            Dim NCCTVCarriageUELogs As Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELog) = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim DownloadEastlanData As Boolean = False
            Dim NielsenRadioCountyPeriodCountBefore As Integer = 0
            Dim ClientNielsenRadioCountyPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioCountyPeriod) = Nothing

            _Timeout = Timeout

            Using SqlConnection As New SqlClient.SqlConnection(NielsenConnectionString)

                Try

                    SqlConnection.Open()

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.EASTLAN_ENABLED.ToString)

                        If Setting IsNot Nothing AndAlso Setting.Value = 1 Then

                            DownloadEastlanData = True

                        End If

                    End Using

                    Using NielsenDBContext = New AdvantageFramework.Nielsen.Database.DbContext(NielsenConnectionString, Nothing)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            DeleteNielsenTVBooks(NielsenDBContext, DbContext)
                            DeleteNielsenRadioPeriods(NielsenDBContext, DbContext)
                            DeleteNielsenTVCumeBooks(NielsenDBContext)
                            DeleteNCCFusionRevised(NielsenDBContext)
                            DeleteNCCAIUERevised(NielsenDBContext)
                            DeleteNCCCarriageUERevised(NielsenDBContext)

                            DeleteNielsenTVProgramBooks(NielsenDBContext)
                            GetTVProgramData(SqlConnection, NielsenDBContext, ClientCode)

                            'spot tv
                            For Each NielsenTVBook In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.Load(NielsenDBContext)
                                                       Where Entity.CollectionMethod Is Nothing OrElse
                                                             Entity.CollectionMethod = ""
                                                       Select Entity).ToList

                                UpdateNielsenTVBook(NielsenDBContext, NielsenTVBook)

                            Next

                            NielsenTVBookCountBefore = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.GetValidatedCount(NielsenDBContext)

                            ClientNielsenTVBooks = GetNielsenTVBooksByClientCode(ClientCode)

                            For Each ClientNielsenTVBook In (From Entity In ClientNielsenTVBooks
                                                             Select Entity.NielsenMarketNumber, Entity.Year, Entity.Month, Entity.ReportingService, Entity.Exclusion, Entity.Ethnicity).Distinct.ToList

                                GetNielsenTVUniverse(SqlConnection, NielsenDBContext, ClientNielsenTVBook.NielsenMarketNumber, ClientNielsenTVBook.Year, ClientNielsenTVBook.Month,
                                                     ClientNielsenTVBook.ReportingService, ClientNielsenTVBook.Exclusion, ClientNielsenTVBook.Ethnicity)

                            Next

                            For Each NielsenTVBook In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.Load(NielsenDBContext)
                                                       Where Entity.Validated = True
                                                       Select Entity).ToList

                                If Not ClientNielsenTVBooks.Where(Function(B) B.NielsenTVBookID = NielsenTVBook.ID).Any Then

                                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_TV_BOOK SET VALIDATED = 0 WHERE NIELSEN_TV_BOOK_ID = {0}", NielsenTVBook.ID))

                                Else

                                    For Each ClientNielsenTVBook In ClientNielsenTVBooks

                                        If ClientNielsenTVBook.NielsenTVBookID = NielsenTVBook.ID Then

                                            ClientNielsenTVBooks.Remove(ClientNielsenTVBook)
                                            Exit For

                                        End If

                                    Next

                                End If

                            Next

                            'validate books here to avoid looping through data that is already present
                            For Each ClientNielsenTVBook In ClientNielsenTVBooks

                                BookValidateCount = GetNielsenTVBookRowCount(ClientNielsenTVBook.NielsenTVBookID)

                                If BookValidateCount <> 0 AndAlso BookValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_spot_tv_rowcount]({0})", ClientNielsenTVBook.NielsenTVBookID)).First Then

                                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_TV_BOOK SET VALIDATED = 1 WHERE NIELSEN_TV_BOOK_ID = {0}", ClientNielsenTVBook.NielsenTVBookID))

                                End If

                            Next

                            For Each ClientNielsenTVBook In ClientNielsenTVBooks

                                GetNielsenTVBook(SqlConnection, NielsenDBContext, ClientNielsenTVBook.NielsenTVBookID)
                                GetNielsenTVAudience(SqlConnection, NielsenDBContext, ClientNielsenTVBook.NielsenTVBookID)
                                GetNielsenTVHutput(SqlConnection, NielsenDBContext, ClientNielsenTVBook.NielsenTVBookID)
                                GetNielsenTVIntab(SqlConnection, NielsenDBContext, ClientNielsenTVBook.NielsenTVBookID)

                            Next

                            For Each MarketNumber In (From Entity In ClientNielsenTVBooks
                                                      Select Entity.NielsenMarketNumber).Distinct.ToList

                                GetNielsenTVStation(SqlConnection, NielsenDBContext, MarketNumber)
                                GetNielsenTVStationHistory(SqlConnection, NielsenDBContext, MarketNumber)

                            Next

                            For Each ClientNielsenTVBook In ClientNielsenTVBooks

                                BookValidateCount = GetNielsenTVBookRowCount(ClientNielsenTVBook.NielsenTVBookID)

                                If BookValidateCount <> 0 AndAlso BookValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_spot_tv_rowcount]({0})", ClientNielsenTVBook.NielsenTVBookID)).First Then

                                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_TV_BOOK SET VALIDATED = 1 WHERE NIELSEN_TV_BOOK_ID = {0}", ClientNielsenTVBook.NielsenTVBookID))

                                End If

                            Next

                            'cume books
                            GetNielsenTVDaypart(SqlConnection, NielsenDBContext)

                            NielsenTVCumeBookCountBefore = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVCumeBook.GetValidatedCount(NielsenDBContext)

                            ClientNielsenTVCumeBooks = GetNielsenTVCumeBooksByClientCode(ClientCode)

                            For Each NielsenTVCumeBook In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVCumeBook.Load(NielsenDBContext)
                                                           Where Entity.Validated = True
                                                           Select Entity).ToList

                                For Each ClientNielsenTVCumeBook In ClientNielsenTVCumeBooks

                                    If ClientNielsenTVCumeBook.NielsenTVCumeBookID = NielsenTVCumeBook.ID Then

                                        ClientNielsenTVCumeBooks.Remove(ClientNielsenTVCumeBook)
                                        Exit For

                                    End If

                                Next

                            Next

                            For Each ClientNielsenTVCumeBook In ClientNielsenTVCumeBooks

                                GetNielsenTVCumeDaypartImpression(SqlConnection, NielsenDBContext, ClientNielsenTVCumeBook.NielsenTVCumeBookID)
                                GetNielsenTVCumeBook(SqlConnection, NielsenDBContext, ClientNielsenTVCumeBook.NielsenTVCumeBookID)

                            Next

                            For Each ClientNielsenTVCumeBook In ClientNielsenTVCumeBooks

                                BookValidateCount = GetNielsenTVCumeBookRowCount(ClientNielsenTVCumeBook.NielsenTVCumeBookID)

                                If BookValidateCount <> 0 AndAlso BookValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_spot_tv_cume_rowcount]({0})", ClientNielsenTVCumeBook.NielsenTVCumeBookID)).First Then

                                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_TV_CUME_BOOK SET VALIDATED = 1 WHERE NIELSEN_TV_CUME_BOOK_ID = {0}", ClientNielsenTVCumeBook.NielsenTVCumeBookID))

                                End If

                            Next

                            'spot radio
                            NielsenRadioPeriodCountBefore = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.GetValidatedCount(NielsenDBContext)

                            ClientNielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)

                            ClientNielsenRadioPeriods.AddRange(GetNielsenRadioPeriodsByClientCode(ClientCode))

                            If DownloadEastlanData Then

                                ClientNielsenRadioPeriods.AddRange(GetEastlanRadioPeriods)

                            End If

                            For Each NielsenRadioPeriod In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.Load(NielsenDBContext)
                                                            Where Entity.Validated = True
                                                            Select Entity).ToList

                                If Not ClientNielsenRadioPeriods.Where(Function(B) B.NielsenRadioPeriodID = NielsenRadioPeriod.ID).Any Then

                                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_RADIO_PERIOD SET VALIDATED = 0 WHERE NIELSEN_RADIO_PERIOD_ID = {0}", NielsenRadioPeriod.ID))

                                Else

                                    For Each ClientNielsenRadioPeriod In ClientNielsenRadioPeriods

                                        If ClientNielsenRadioPeriod.NielsenRadioPeriodID = NielsenRadioPeriod.ID Then

                                            ClientNielsenRadioPeriods.Remove(ClientNielsenRadioPeriod)
                                            Exit For

                                        End If

                                    Next

                                End If

                            Next

                            For Each ClientNielsenRadioPeriod In ClientNielsenRadioPeriods

                                GetNielsenRadioPeriod(SqlConnection, NielsenDBContext, ClientNielsenRadioPeriod.NielsenRadioPeriodID)

                                GetNielsenRadioSegmentParent(SqlConnection, NielsenDBContext, ClientNielsenRadioPeriod.NielsenRadioPeriodID)
                                GetNielsenRadioSegmentChild(SqlConnection, NielsenDBContext)

                                SegmentParentIDs = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioSegmentParent.Load(NielsenDBContext)
                                                    Where Entity.NielsenRadioPeriodID = ClientNielsenRadioPeriod.NielsenRadioPeriodID
                                                    Select Entity.ID).ToList

                                GetNielsenRadioAudience(SqlConnection, NielsenDBContext, SegmentParentIDs)
                                GetNielsenRadioIntab(SqlConnection, NielsenDBContext, SegmentParentIDs)
                                GetNielsenRadioPUR(SqlConnection, NielsenDBContext, SegmentParentIDs)
                                GetNielsenRadioUniverse(SqlConnection, NielsenDBContext, SegmentParentIDs)

                            Next

                            For Each ClientNielsenRadioPeriod In ClientNielsenRadioPeriods

                                GetNielsenRadioMarket(SqlConnection, NielsenDBContext, ClientNielsenRadioPeriod.NielsenRadioMarketNumber, ClientNielsenRadioPeriod.Source)
                                GetNielsenRadioStation(SqlConnection, NielsenDBContext, ClientNielsenRadioPeriod.NielsenRadioMarketNumber, ClientNielsenRadioPeriod.Source)
                                GetNielsenRadioStationHistory(SqlConnection, NielsenDBContext, ClientNielsenRadioPeriod.NielsenRadioMarketNumber, ClientNielsenRadioPeriod.Source)

                            Next

                            GetNielsenRadioDemographic(SqlConnection, NielsenDBContext)
                            GetNielsenRadioFormat(NielsenDBContext)
                            GetNielsenRadioQualitative(SqlConnection, NielsenDBContext)
                            'GetNielsenRadioReportType(SqlConnection, NielsenDBContext)

                            For Each ClientNielsenRadioPeriod In ClientNielsenRadioPeriods

                                PeriodValidateCount = GetNielsenRadioPeriodRowCount(ClientNielsenRadioPeriod.NielsenRadioPeriodID)

                                If PeriodValidateCount <> 0 AndAlso PeriodValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_spot_radio_rowcount]({0})", ClientNielsenRadioPeriod.NielsenRadioPeriodID)).First Then

                                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_RADIO_PERIOD SET VALIDATED = 1 WHERE NIELSEN_RADIO_PERIOD_ID = {0}", ClientNielsenRadioPeriod.NielsenRadioPeriodID))

                                End If

                            Next

                            'radio county
                            NielsenRadioCountyPeriodCountBefore = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.GetValidatedCount(NielsenDBContext)

                            ClientNielsenRadioCountyPeriods = GetNielsenRadioCountyPeriodsByClientCode(ClientCode)

                            For Each NielsenRadioCountyPeriod In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.Load(NielsenDBContext)
                                                                  Where Entity.Validated = True
                                                                  Select Entity).ToList

                                If Not ClientNielsenRadioCountyPeriods.Where(Function(B) B.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriod.ID).Any Then

                                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_RADIO_COUNTY_PERIOD SET VALIDATED = 0 WHERE NIELSEN_RADIO_PERIOD_ID = {0}", NielsenRadioCountyPeriod.ID))

                                Else

                                    For Each ClientNielsenRadioCountyPeriod In ClientNielsenRadioCountyPeriods

                                        If ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriod.ID Then

                                            ClientNielsenRadioCountyPeriods.Remove(ClientNielsenRadioCountyPeriod)
                                            Exit For

                                        End If

                                    Next

                                End If

                            Next

                            For Each ClientNielsenRadioCountyPeriod In ClientNielsenRadioCountyPeriods

                                GetNielsenRadioCountyPeriod(SqlConnection, NielsenDBContext, ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID)
                                GetNielsenRadioCountyAudience(SqlConnection, NielsenDBContext, ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID)
                                GetNielsenRadioCountyCluster(SqlConnection, NielsenDBContext, ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID)
                                GetNielsenRadioCountyIntab(SqlConnection, NielsenDBContext, ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID)
                                GetNielsenRadioCountyUniverse(SqlConnection, NielsenDBContext, ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID)

                            Next

                            For Each PeriodYear In ClientNielsenRadioCountyPeriods.Select(Function(Entity) Entity.Year).Distinct.ToList

                                GetNielsenRadioCountyStation(SqlConnection, NielsenDBContext, PeriodYear)

                            Next

                            For Each MarketNumber In ClientNielsenRadioCountyPeriods.Select(Function(Entity) Entity.NielsenRadioMarketNumber).Distinct.ToList

                                GetNielsenRadioMarket(SqlConnection, NielsenDBContext, MarketNumber, Nielsen.Database.Entities.Methods.RadioSource.NielsenCounty)

                            Next

                            For Each ClientNielsenRadioCountyPeriod In ClientNielsenRadioCountyPeriods

                                PeriodValidateCount = GetNielsenRadioCountyPeriodRowCount(ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID)

                                If PeriodValidateCount <> 0 AndAlso PeriodValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_radio_county_rowcount_by_period]({0})", ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID)).First Then

                                    NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NIELSEN_RADIO_COUNTY_PERIOD SET VALIDATED = 1 WHERE NIELSEN_RADIO_COUNTY_PERIOD_ID = {0}", ClientNielsenRadioCountyPeriod.NielsenRadioCountyPeriodID))

                                End If

                            Next

                            'national tv
                            'GetNielsenNationalTVAudience(SqlConnection, NielsenDBContext)

                            'ncc data
                            If IsNCCSubscribed(ClientCode) Then

                                GetNCCTVMVPDs(SqlConnection, NielsenDBContext)

                                UpdateNCCTVSyscodes(NielsenDBContext)
                                GetNCCTVSyscodes(SqlConnection, NielsenDBContext)

                                GetNCCTVLPMMarkets(NielsenDBContext)

                                UpdateNCCTVCablenets(NielsenDBContext)
                                GetNCCTVCablenets(SqlConnection, NielsenDBContext)

                                UpdateComscoreStationCode(NielsenDBContext)

                                'ClientNCCTVFusionUniverses = GetNCCTVFusionUniverseByClientCode(ClientCode)

                                'For Each NCCTVFusionUniverse In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVFusionUniverse.Load(NielsenDBContext)
                                '                                 Where Entity.Validated = True
                                '                                 Select Entity).ToList

                                '    For Each ClientNCCTVFusionUniverse In ClientNCCTVFusionUniverses

                                '        If ClientNCCTVFusionUniverse.ID = NCCTVFusionUniverse.ID Then

                                '            ClientNCCTVFusionUniverses.Remove(ClientNCCTVFusionUniverse)
                                '            Exit For

                                '        End If

                                '    Next

                                'Next

                                'For Each ClientNCCTVFusionUniverse In ClientNCCTVFusionUniverses

                                '    If NielsenDBContext.NCCTVFusionUniverses.Find(ClientNCCTVFusionUniverse.ID) Is Nothing Then

                                '        NCCTVFusionUniverses = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse)
                                '        NCCTVFusionUniverses.Add(ClientNCCTVFusionUniverse)

                                '        BulkInsertNCCTVFusionUniverseList(SqlConnection, NCCTVFusionUniverses)

                                '    End If

                                '    GetNCCTVFusionAudience(SqlConnection, NielsenDBContext, ClientNCCTVFusionUniverse.ID)
                                '    GetNCCTVFusionHutput(SqlConnection, NielsenDBContext, ClientNCCTVFusionUniverse.ID)

                                'Next

                                'For Each ClientNCCTVFusionUniverse In ClientNCCTVFusionUniverses

                                '    BookValidateCount = GetNCCTVFusionCountByUEID(ClientNCCTVFusionUniverse.ID)

                                '    If BookValidateCount <> 0 AndAlso BookValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_ncc_rowcount_by_fusion_ue_id]({0})", ClientNCCTVFusionUniverse.ID)).First Then

                                '        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NCC_TV_FUSION_UE SET VALIDATED = 1 WHERE NCC_TV_FUSION_UE_ID = {0}", ClientNCCTVFusionUniverse.ID))

                                '    End If

                                'Next

                                AllNCCTVAIUELogs = GetNCCTVAIUELogs()

                                For Each NCCTVAIUELog In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVAIUELog.Load(NielsenDBContext)
                                                          Where Entity.Validated = True
                                                          Select Entity).ToList

                                    For Each AllNCCTVAIUELog In AllNCCTVAIUELogs

                                        If AllNCCTVAIUELog.ID = NCCTVAIUELog.ID Then

                                            AllNCCTVAIUELogs.Remove(AllNCCTVAIUELog)
                                            Exit For

                                        End If

                                    Next

                                Next

                                For Each AllNCCTVAIUELog In AllNCCTVAIUELogs

                                    If NielsenDBContext.NCCTVAIUELogs.Find(AllNCCTVAIUELog.ID) Is Nothing Then

                                        NCCTVAIUELogs = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVAIUELog)
                                        NCCTVAIUELogs.Add(AllNCCTVAIUELog)

                                        BulkInsertNCCTVAIUELogList(SqlConnection, NCCTVAIUELogs)

                                    End If

                                    GetNCCTVAIUEs(SqlConnection, NielsenDBContext, AllNCCTVAIUELog.ID)

                                Next

                                For Each AllNCCTVAIUELog In AllNCCTVAIUELogs

                                    BookValidateCount = GetNCCTVAIUECountByNCCTVAIUELogID(AllNCCTVAIUELog.ID)

                                    If BookValidateCount <> 0 AndAlso BookValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT CAST(COALESCE(COUNT(1), 0) as bigint) FROM dbo.NCC_TV_AI_UE WHERE NCC_TV_AI_UE_LOG_ID = {0}", AllNCCTVAIUELog.ID)).First Then

                                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NCC_TV_AI_UE_LOG SET VALIDATED = 1 WHERE NCC_TV_AI_UE_LOG_ID = {0}", AllNCCTVAIUELog.ID))

                                    End If

                                Next

                                AllNCCTVCarriageUELogs = GetNCCTVCarriageUELogs()

                                For Each NCCTVCarriageUELog In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVCarriageUELog.Load(NielsenDBContext)
                                                                Where Entity.Validated = True
                                                                Select Entity).ToList

                                    For Each AllNCCTVCarriageUELog In AllNCCTVCarriageUELogs

                                        If AllNCCTVCarriageUELog.ID = NCCTVCarriageUELog.ID Then

                                            AllNCCTVCarriageUELogs.Remove(AllNCCTVCarriageUELog)
                                            Exit For

                                        End If

                                    Next

                                Next

                                For Each AllNCCTVCarriageUELog In AllNCCTVCarriageUELogs

                                    If NielsenDBContext.NCCTVCarriageUELogs.Find(AllNCCTVCarriageUELog.ID) Is Nothing Then

                                        NCCTVCarriageUELogs = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUELog)
                                        NCCTVCarriageUELogs.Add(AllNCCTVCarriageUELog)

                                        BulkInsertNCCTVCarriageUELogList(SqlConnection, NCCTVCarriageUELogs)

                                    End If

                                    GetNCCTVCarriageUEs(SqlConnection, NielsenDBContext, AllNCCTVCarriageUELog.ID)

                                Next

                                For Each AllNCCTVCarriageUELog In AllNCCTVCarriageUELogs

                                    BookValidateCount = GetNCCTVCarriageUECountByNCCTVCarriageUELogID(AllNCCTVCarriageUELog.ID)

                                    If BookValidateCount <> 0 AndAlso BookValidateCount = NielsenDBContext.Database.SqlQuery(Of Int64)(String.Format("SELECT CAST(COALESCE(COUNT(1), 0) as bigint) FROM dbo.NCC_TV_CARRIAGE_UE WHERE NCC_TV_CARRIAGE_UE_LOG_ID = {0}", AllNCCTVCarriageUELog.ID)).First Then

                                        NielsenDBContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NCC_TV_CARRIAGE_UE_LOG SET VALIDATED = 1 WHERE NCC_TV_CARRIAGE_UE_LOG_ID = {0}", AllNCCTVCarriageUELog.ID))

                                    End If

                                Next

                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_FUSION_UE_REVISION]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_FUSION_AUDIENCE]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_FUSION_HUTPUT]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_FUSION_UE]")

                            Else 'remove all NCC data

                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_AI_UE_LOG_REVISION]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_AI_UE]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_AI_UE_LOG]")

                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_CABLENET]")

                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_CARRIAGE_UE_LOG_REVISION]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_CARRIAGE_UE]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_CARRIAGE_UE_LOG]")

                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_FUSION_UE_REVISION]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_FUSION_AUDIENCE]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_FUSION_HUTPUT]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_FUSION_UE]")

                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_SYSCODE]")
                                NielsenDBContext.Database.ExecuteSqlCommand("DELETE [dbo].[NCC_TV_MVPD]")

                            End If

                            'send alert
                            If NielsenTVBookCountBefore < AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.GetValidatedCount(NielsenDBContext) OrElse
                                     NielsenRadioPeriodCountBefore < AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.GetValidatedCount(NielsenDBContext) OrElse
                                     NielsenTVCumeBookCountBefore < AdvantageFramework.Nielsen.Database.Procedures.NielsenTVCumeBook.GetValidatedCount(NielsenDBContext) Then

                                If Not String.IsNullOrEmpty(EmployeeCode) Then

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                                    If Employee IsNot Nothing AndAlso Employee.TerminationDate Is Nothing AndAlso Employee.Email IsNot Nothing Then

                                        AdvantageFramework.AlertSystem.CreateAlertForNewNielsenData(DatabaseProfile, EmployeeCode)

                                    End If

                                End If

                            End If

                        End Using

                    End Using

                Catch ex As Exception

                    Throw ex

                Finally

                    If SqlConnection.State = ConnectionState.Open Then

                        SqlConnection.Close()

                    End If

                End Try

            End Using

        End Sub

#End Region

    End Module

End Namespace
