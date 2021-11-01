Namespace DoubleClick

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const _DOUBLECLICK_IMPORT_TEMPLATE_NAME As String = "Advantage DoubleClick Results"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetCompatibility() As IEnumerable(Of String)

            GetCompatibility = {"DISPLAY", "DISPLAY_INTERSTITIAL", "IN_STREAM_VIDEO", "IN_STREAM_AUDIO"}

        End Function
        Public Function GetRecordSourceName() As String

            GetRecordSourceName = "DoubleClick"

        End Function
        Public Function IsDoubleClickEnabledByAgencyOrAnyClient(DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim DoubleClickIsEnabled As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.DC_ENABLED.ToString)

            If Setting IsNot Nothing Then

                If IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                    DoubleClickIsEnabled = True

                End If

            End If

            If DoubleClickIsEnabled = False Then

                Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)

                    If (From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                        Where Entity.DoubleClickEnabled = True).Any Then

                        DoubleClickIsEnabled = True

                    End If

                End Using

            End If

            IsDoubleClickEnabledByAgencyOrAnyClient = DoubleClickIsEnabled

        End Function
        Private Function CreateOnDemandDirectory(OnDemandDirectory As String, ByRef ErrorString As String) As Boolean

            Dim DirectoryExists As Boolean = False

            If Not System.IO.Directory.Exists(OnDemandDirectory) Then

                Try

                    IO.Directory.CreateDirectory(OnDemandDirectory)

                    DirectoryExists = True

                Catch ex As Exception
                    ErrorString = ex.Message
                End Try

            Else

                DirectoryExists = True

            End If

            CreateOnDemandDirectory = DirectoryExists

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
        Private Sub BulkInsertImportDigitalResultStagingList(ConnectionString As String, ImportDigitalResultsStagings As List(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = ImportDigitalResultsStagings.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(ConnectionString)

                With SqlBulkCopy

                    .ColumnMappings.Add("BatchName", "BATCH_NAME")
                    .ColumnMappings.Add("MediaPlanID", "MEDIA_PLAN_ID")
                    .ColumnMappings.Add("ClientCode", "CL_CODE")
                    .ColumnMappings.Add("ClientName", "CL_NAME")
                    .ColumnMappings.Add("DivisionCode", "DIV_CODE")
                    .ColumnMappings.Add("ProductCode", "PRD_CODE")
                    .ColumnMappings.Add("MediaPlanDetailID", "MEDIA_PLAN_DTL_ID")
                    .ColumnMappings.Add("MediaPlanDetailLevelLineID", "MEDIA_PLAN_DTL_LEVEL_LINE_ID")
                    .ColumnMappings.Add("MediaType", "MEDIA_TYPE")
                    .ColumnMappings.Add("SalesClassCode", "SC_CODE")
                    .ColumnMappings.Add("CampaignCode", "CMP_CODE")
                    .ColumnMappings.Add("CampaignID", "CMP_IDENTIFIER")
                    .ColumnMappings.Add("CampaignName", "CMP_NAME")
                    .ColumnMappings.Add("VendorCode", "VN_CODE")
                    .ColumnMappings.Add("VendorName", "VN_NAME")
                    .ColumnMappings.Add("MarketCode", "MARKET_CODE")
                    .ColumnMappings.Add("AdSizeCode", "AD_SIZE_CODE")
                    .ColumnMappings.Add("AdNumber", "AD_NBR")
                    .ColumnMappings.Add("AdNumberDescription", "AD_NBR_DESC")
                    .ColumnMappings.Add("InternetTypeCode", "INTERNET_TYPE_CODE")
                    .ColumnMappings.Add("Placement", "PLACEMENT")
                    .ColumnMappings.Add("PlacementPixelSize", "PLACEMENT_PX_SIZE")
                    .ColumnMappings.Add("PlacementURL", "PLACEMENT_URL")
                    .ColumnMappings.Add("Creative", "CREATIVE")
                    .ColumnMappings.Add("Tactic", "TACTIC")
                    .ColumnMappings.Add("PagePositioning", "PAGE_POSITIONING")
                    .ColumnMappings.Add("ResultDate", "RESULT_DATE")
                    .ColumnMappings.Add("NetGrossRate", "NET_GROSS_RATE")
                    .ColumnMappings.Add("Units", "UNITS")
                    .ColumnMappings.Add("Impressions", "IMPRESSIONS")
                    .ColumnMappings.Add("Clicks", "CLICKS")
                    .ColumnMappings.Add("ClickRate", "CLICK_RATE")
                    .ColumnMappings.Add("TotalConversions", "TOTAL_CONVERSIONS")
                    .ColumnMappings.Add("Rate", "RATE")
                    .ColumnMappings.Add("NetDollars", "NET_DOLLARS")
                    .ColumnMappings.Add("GrossDollars", "GROSS_DOLLARS")
                    .ColumnMappings.Add("TemplateID", "TEMPLATE_ID")
                    .ColumnMappings.Add("EndDate", "END_DATE")
                    .ColumnMappings.Add("JobNumber", "JOB_NUMBER")
                    .ColumnMappings.Add("JobDescription", "JOB_DESC")
                    .ColumnMappings.Add("JobComponentNumber", "JOB_COMPONENT_NBR")
                    .ColumnMappings.Add("JobComponentDescription", "JOB_COMP_DESC")
                    .ColumnMappings.Add("MarketDescription", "MARKET_DESC")
                    .ColumnMappings.Add("InternetTypeDescription", "OD_DESC")
                    .ColumnMappings.Add("AdSizeDescription", "AD_SIZE_DESC")
                    .ColumnMappings.Add("TargetAudience", "TARGET_AUDIENCE")
                    .ColumnMappings.Add("ImpressionsViewable", "IMPRESSIONS_VIEWABLE")
                    .ColumnMappings.Add("ImpressionsMeasurable", "IMPRESSIONS_MEASUREABLE")
                    .ColumnMappings.Add("TotalConversionsB", "TOTAL_CONVERSIONS_B")
                    .ColumnMappings.Add("TotalConversionsC", "TOTAL_CONVERSIONS_C")
                    .ColumnMappings.Add("Leads1", "LEADS1")
                    .ColumnMappings.Add("Leads2", "LEADS2")
                    .ColumnMappings.Add("Calls", "CALLS")
                    .ColumnMappings.Add("LikesOrganic", "LIKES_ORGANIC")
                    .ColumnMappings.Add("LikesPaid", "LIKES_PAID")
                    .ColumnMappings.Add("Visits", "VISITS")
                    .ColumnMappings.Add("UniqueVisitors", "UNIQUE_VISITORS")
                    .ColumnMappings.Add("ReachOrganic", "REACH_ORGANIC")
                    .ColumnMappings.Add("ReachPaid", "REACH_PAID")
                    .ColumnMappings.Add("PageViews", "PAGE_VIEWS")
                    .ColumnMappings.Add("PageEngagement", "PAGE_ENGAGEMENT")
                    .ColumnMappings.Add("Note", "NOTE")
                    .ColumnMappings.Add("ClientSales", "CLIENT_SALES")
                    .ColumnMappings.Add("PlacementID", "PLACEMENT_ID")
                    .ColumnMappings.Add("AdServerSource", "AD_SERVER_SOURCE")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "IMP_DIGITAL_RESULTS_STAGING"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Private Sub BulkInsertDigitalResultList(ConnectionString As String, DigitalResults As List(Of AdvantageFramework.Database.Entities.DigitalResult))

            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = DigitalResults.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(ConnectionString)

                With SqlBulkCopy

                    .ColumnMappings.Add("MediaPlanID", "MEDIA_PLAN_ID")
                    .ColumnMappings.Add("ClientCode", "CL_CODE")
                    .ColumnMappings.Add("ClientName", "CL_NAME")
                    .ColumnMappings.Add("DivisionCode", "DIV_CODE")
                    .ColumnMappings.Add("ProductCode", "PRD_CODE")
                    .ColumnMappings.Add("MediaPlanDetailID", "MEDIA_PLAN_DTL_ID")
                    .ColumnMappings.Add("MediaPlanDetailLevelLineID", "MEDIA_PLAN_DTL_LEVEL_LINE_ID")
                    .ColumnMappings.Add("MediaType", "MEDIA_TYPE")
                    .ColumnMappings.Add("SalesClassCode", "SC_CODE")
                    .ColumnMappings.Add("CampaignID", "CMP_IDENTIFIER")
                    .ColumnMappings.Add("CampaignCode", "CMP_CODE")
                    .ColumnMappings.Add("CampaignName", "CMP_NAME")
                    .ColumnMappings.Add("VendorCode", "VN_CODE")
                    .ColumnMappings.Add("VendorName", "VN_NAME")
                    .ColumnMappings.Add("MarketCode", "MARKET_CODE")
                    .ColumnMappings.Add("AdSizeCode", "AD_SIZE_CODE")
                    .ColumnMappings.Add("AdNumber", "AD_NBR")
                    .ColumnMappings.Add("AdNumberDescription", "AD_NBR_DESC")
                    .ColumnMappings.Add("InternetTypeCode", "INTERNET_TYPE_CODE")
                    .ColumnMappings.Add("Placement", "PLACEMENT")
                    .ColumnMappings.Add("PlacementPixelSize", "PLACEMENT_PX_SIZE")
                    .ColumnMappings.Add("PlacementURL", "PLACEMENT_URL")
                    .ColumnMappings.Add("Creative", "CREATIVE")
                    .ColumnMappings.Add("Tactic", "TACTIC")
                    .ColumnMappings.Add("PagePositioning", "PAGE_POSITIONING")
                    .ColumnMappings.Add("ResultDate", "RESULT_DATE")
                    .ColumnMappings.Add("NetGrossRate", "NET_GROSS_RATE")
                    .ColumnMappings.Add("Units", "UNITS")
                    .ColumnMappings.Add("Impressions", "IMPRESSIONS")
                    .ColumnMappings.Add("Clicks", "CLICKS")
                    .ColumnMappings.Add("ClickRate", "CLICK_RATE")
                    .ColumnMappings.Add("TotalConversions", "TOTAL_CONVERSIONS")
                    .ColumnMappings.Add("Rate", "RATE")
                    .ColumnMappings.Add("NetDollars", "NET_DOLLARS")
                    .ColumnMappings.Add("GrossDollars", "GROSS_DOLLARS")
                    .ColumnMappings.Add("EndDate", "END_DATE")
                    .ColumnMappings.Add("JobNumber", "JOB_NUMBER")
                    .ColumnMappings.Add("JobDescription", "JOB_DESC")
                    .ColumnMappings.Add("JobComponentNumber", "JOB_COMPONENT_NBR")
                    .ColumnMappings.Add("JobComponentDescription", "JOB_COMP_DESC")
                    .ColumnMappings.Add("MarketDescription", "MARKET_DESC")
                    .ColumnMappings.Add("InternetTypeDescription", "OD_DESC")
                    .ColumnMappings.Add("AdSizeDescription", "AD_SIZE_DESC")
                    .ColumnMappings.Add("TargetAudience", "TARGET_AUDIENCE")
                    .ColumnMappings.Add("ImpressionsViewable", "IMPRESSIONS_VIEWABLE")
                    .ColumnMappings.Add("ImpressionsMeasurable", "IMPRESSIONS_MEASUREABLE")
                    .ColumnMappings.Add("TotalConversionsB", "TOTAL_CONVERSIONS_B")
                    .ColumnMappings.Add("TotalConversionsC", "TOTAL_CONVERSIONS_C")
                    .ColumnMappings.Add("Leads1", "LEADS1")
                    .ColumnMappings.Add("Leads2", "LEADS2")
                    .ColumnMappings.Add("Calls", "CALLS")
                    .ColumnMappings.Add("LikesOrganic", "LIKES_ORGANIC")
                    .ColumnMappings.Add("LikesPaid", "LIKES_PAID")
                    .ColumnMappings.Add("Visits", "VISITS")
                    .ColumnMappings.Add("UniqueVisitors", "UNIQUE_VISITORS")
                    .ColumnMappings.Add("ReachOrganic", "REACH_ORGANIC")
                    .ColumnMappings.Add("ReachPaid", "REACH_PAID")
                    .ColumnMappings.Add("PageViews", "PAGE_VIEWS")
                    .ColumnMappings.Add("PageEngagement", "PAGE_ENGAGEMENT")
                    .ColumnMappings.Add("Note", "NOTE")
                    .ColumnMappings.Add("ClientSales", "CLIENT_SALES")
                    .ColumnMappings.Add("PlacementID", "PLACEMENT_ID")
                    .ColumnMappings.Add("AdServerSource", "AD_SERVER_SOURCE")

                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "DIGITAL_RESULTS"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        Public Function ProcessReport(Session As AdvantageFramework.Security.Session, ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                      ByRef ErrorString As String) As Boolean

            'objects
            Dim Success As Boolean = False
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim OnDemandDirectory As String = Nothing
            Dim Filename As String = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim ReportFieldsFound As Boolean = False
            Dim BatchName As String = Nothing
            Dim ImportDigitalResultsStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) = Nothing
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing
            Dim PlacementIDs As IEnumerable(Of Long) = Nothing
            Dim MinDate As Date = Nothing
            Dim MaxDate As Date = Nothing
            Dim SqlParameterMinDate As SqlClient.SqlParameter = Nothing
            Dim SqlParameterMaxDate As SqlClient.SqlParameter = Nothing
            Dim DigitalResults As Generic.List(Of AdvantageFramework.Database.Entities.DigitalResult) = Nothing
            Dim DigitalResult As AdvantageFramework.Database.Entities.DigitalResult = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim ImportPath As String = Nothing
            Dim TextFieldParser As FileIO.TextFieldParser = Nothing
            Dim FileLineData() As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ImportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default)
                                  Where Entity.IsSystemTemplate AndAlso
                                        Entity.Name = _DOUBLECLICK_IMPORT_TEMPLATE_NAME
                                  Select Entity).SingleOrDefault

                If ImportTemplate IsNot Nothing AndAlso AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\")

                    ImportPath = AdvantageFramework.Importing.GetHostedDirectory(AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default, AgencyImportPath)

                ElseIf ImportTemplate IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ImportTemplate.DefaultDirectory) Then

                    ImportPath = ImportTemplate.DefaultDirectory

                End If

                If System.IO.Directory.Exists(ImportPath) Then

                    If AdvantageFramework.GoogleServices.Service.DoubleClickRunReport(Session, False, ViewModel.DCProfileID, ViewModel.AdServerReportID.Value, ViewModel.ReportCriteria.DoubleClickReportRelativeDateRange, MemoryStream, ErrorString) Then

                        OnDemandDirectory = IO.Path.Combine(ImportPath, "OnDemand")

                        If CreateOnDemandDirectory(OnDemandDirectory, ErrorString) Then

                            Filename = Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#") & Session.UserCode & ".CSV"

                            FileStream = New System.IO.FileStream(System.IO.Path.Combine(OnDemandDirectory, Filename), IO.FileMode.Create)

                            MemoryStream.WriteTo(FileStream)

                            FileStream.Close()
                            FileStream.Dispose()

                            BatchName = AdvantageFramework.Importing.CreateBatchName(ImportTemplate.Name)

                            ImportDigitalResultsStagings = New Generic.List(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)

                            Try

                                DbContext.Configuration.AutoDetectChangesEnabled = False

                                TextFieldParser = New FileIO.TextFieldParser(System.IO.Path.Combine(OnDemandDirectory, Filename))

                                TextFieldParser.TextFieldType = FileIO.FieldType.Delimited
                                TextFieldParser.Delimiters = {","}
                                TextFieldParser.HasFieldsEnclosedInQuotes = True

                                Do While Not TextFieldParser.EndOfData

                                    FileLineData = TextFieldParser.ReadFields

                                    If Not ReportFieldsFound AndAlso FileLineData(0) = "Report Fields" Then

                                        ReportFieldsFound = True

                                    ElseIf ReportFieldsFound AndAlso Not FileLineData(0).StartsWith("Grand Total:") AndAlso Not FileLineData(0).StartsWith("Placement") Then

                                        ImportDigitalResultsStaging = New AdvantageFramework.Database.Entities.ImportDigitalResultsStaging

                                        ImportDigitalResultsStaging.TemplateID = ImportTemplate.ID
                                        ImportDigitalResultsStaging.BatchName = BatchName
                                        ImportDigitalResultsStaging.AdServerSource = "DoubleClick"
                                        ImportDigitalResultsStaging.MediaType = "I"

                                        ImportDigitalResultsStaging.Placement = Mid(FileLineData(0), 1, 160)
                                        ImportDigitalResultsStaging.ResultDate = FileLineData(1)
                                        ImportDigitalResultsStaging.PlacementID = FileLineData(2)
                                        ImportDigitalResultsStaging.PlacementPixelSize = Mid(FileLineData(3), 1, 60)
                                        ImportDigitalResultsStaging.Creative = Mid(FileLineData(4), 1, 60)
                                        ImportDigitalResultsStaging.Tactic = FileLineData(5)
                                        ImportDigitalResultsStaging.Impressions = FileLineData(6)
                                        ImportDigitalResultsStaging.Clicks = FileLineData(7)
                                        ImportDigitalResultsStaging.ClickRate = FileLineData(8)
                                        ImportDigitalResultsStaging.ImpressionsViewable = FileLineData(9)
                                        ImportDigitalResultsStaging.ImpressionsMeasurable = FileLineData(10)
                                        ImportDigitalResultsStaging.TotalConversions = FileLineData(11)
                                        ImportDigitalResultsStaging.TotalConversionsB = FileLineData(12)
                                        ImportDigitalResultsStaging.TotalConversionsC = FileLineData(13)

                                        If FileLineData.GetUpperBound(0) > 13 Then

                                            ImportDigitalResultsStaging.NetDollars = FileLineData(14)

                                        End If

                                        ImportDigitalResultsStagings.Add(ImportDigitalResultsStaging)

                                    End If

                                Loop

                                TextFieldParser.Close()
                                TextFieldParser.Dispose()

                                IO.File.Delete(System.IO.Path.Combine(OnDemandDirectory, Filename))

                                BulkInsertImportDigitalResultStagingList(DbContext.ConnectionString, ImportDigitalResultsStagings)

                                DbContext.Database.ExecuteSqlCommand(String.Format("exec [advsp_imp_digital_results_doubleclick] '{0}'", BatchName))

                                PlacementIDs = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext)
                                                Where Entity.AdServerPlacementID.HasValue
                                                Select Entity.AdServerPlacementID.Value).ToArray

                                ImportDigitalResultsStagings = (From Entity In AdvantageFramework.Database.Procedures.ImportDigitalResultsStaging.LoadByBatchName(DbContext, BatchName)
                                                                Where PlacementIDs.Contains(Entity.PlacementID)
                                                                Select Entity).ToList

                                If ImportDigitalResultsStagings IsNot Nothing AndAlso ImportDigitalResultsStagings.Count > 0 Then

                                    MinDate = ImportDigitalResultsStagings.Where(Function(Entity) Entity.ResultDate.HasValue).Min(Function(Entity) Entity.ResultDate).Value
                                    MaxDate = ImportDigitalResultsStagings.Where(Function(Entity) Entity.ResultDate.HasValue).Max(Function(Entity) Entity.ResultDate).Value

                                    SqlParameterMinDate = New SqlClient.SqlParameter("@MINDATE", SqlDbType.Date)
                                    SqlParameterMaxDate = New SqlClient.SqlParameter("@MAXDATE", SqlDbType.Date)

                                    SqlParameterMinDate.Value = MinDate
                                    SqlParameterMaxDate.Value = MaxDate

                                    DbContext.Database.ExecuteSqlCommand("DELETE dbo.DIGITAL_RESULTS WHERE AD_SERVER_SOURCE = 'DoubleClick' AND PLACEMENT_ID IS NOT NULL AND RESULT_DATE BETWEEN @MINDATE AND @MAXDATE", SqlParameterMinDate, SqlParameterMaxDate)

                                    DigitalResults = New Generic.List(Of AdvantageFramework.Database.Entities.DigitalResult)

                                    For Each ImportDigitalResultsStaging In ImportDigitalResultsStagings

                                        DigitalResult = New AdvantageFramework.Database.Entities.DigitalResult

                                        DigitalResult.MediaPlanID = ImportDigitalResultsStaging.MediaPlanID
                                        DigitalResult.ClientCode = ImportDigitalResultsStaging.ClientCode
                                        DigitalResult.DivisionCode = ImportDigitalResultsStaging.DivisionCode
                                        DigitalResult.ProductCode = ImportDigitalResultsStaging.ProductCode
                                        DigitalResult.MediaPlanDetailID = ImportDigitalResultsStaging.MediaPlanDetailID
                                        DigitalResult.MediaPlanDetailLevelLineID = ImportDigitalResultsStaging.MediaPlanDetailLevelLineID
                                        DigitalResult.MediaType = ImportDigitalResultsStaging.MediaType
                                        DigitalResult.SalesClassCode = ImportDigitalResultsStaging.SalesClassCode
                                        DigitalResult.CampaignID = ImportDigitalResultsStaging.CampaignID
                                        DigitalResult.VendorCode = ImportDigitalResultsStaging.VendorCode
                                        DigitalResult.MarketCode = ImportDigitalResultsStaging.MarketCode
                                        DigitalResult.AdSizeCode = ImportDigitalResultsStaging.AdSizeCode
                                        DigitalResult.AdNumber = ImportDigitalResultsStaging.AdNumber
                                        DigitalResult.InternetTypeCode = ImportDigitalResultsStaging.InternetTypeCode
                                        DigitalResult.Placement = ImportDigitalResultsStaging.Placement
                                        DigitalResult.PlacementPixelSize = ImportDigitalResultsStaging.PlacementPixelSize
                                        DigitalResult.PlacementURL = ImportDigitalResultsStaging.PlacementURL
                                        DigitalResult.Creative = ImportDigitalResultsStaging.Creative
                                        DigitalResult.Tactic = ImportDigitalResultsStaging.Tactic
                                        DigitalResult.PagePositioning = ImportDigitalResultsStaging.PagePositioning
                                        DigitalResult.ResultDate = ImportDigitalResultsStaging.ResultDate
                                        DigitalResult.NetGrossRate = ImportDigitalResultsStaging.NetGrossRate
                                        DigitalResult.Units = ImportDigitalResultsStaging.Units
                                        DigitalResult.Impressions = ImportDigitalResultsStaging.Impressions
                                        DigitalResult.Clicks = ImportDigitalResultsStaging.Clicks
                                        DigitalResult.ClickRate = ImportDigitalResultsStaging.ClickRate
                                        DigitalResult.TotalConversions = ImportDigitalResultsStaging.TotalConversions
                                        DigitalResult.Rate = ImportDigitalResultsStaging.Rate
                                        DigitalResult.NetDollars = ImportDigitalResultsStaging.NetDollars
                                        DigitalResult.GrossDollars = ImportDigitalResultsStaging.GrossDollars
                                        DigitalResult.ClientName = ImportDigitalResultsStaging.ClientName
                                        DigitalResult.CampaignCode = ImportDigitalResultsStaging.CampaignCode
                                        DigitalResult.CampaignName = ImportDigitalResultsStaging.CampaignName
                                        DigitalResult.VendorName = ImportDigitalResultsStaging.VendorName
                                        DigitalResult.AdNumberDescription = ImportDigitalResultsStaging.AdNumberDescription
                                        DigitalResult.EndDate = ImportDigitalResultsStaging.EndDate
                                        DigitalResult.TargetAudience = ImportDigitalResultsStaging.TargetAudience
                                        DigitalResult.ImpressionsViewable = ImportDigitalResultsStaging.ImpressionsViewable
                                        DigitalResult.ImpressionsMeasurable = ImportDigitalResultsStaging.ImpressionsMeasurable
                                        DigitalResult.TotalConversionsB = ImportDigitalResultsStaging.TotalConversionsB
                                        DigitalResult.TotalConversionsC = ImportDigitalResultsStaging.TotalConversionsC
                                        DigitalResult.MarketDescription = ImportDigitalResultsStaging.MarketDescription
                                        DigitalResult.InternetTypeDescription = ImportDigitalResultsStaging.InternetTypeDescription
                                        DigitalResult.AdSizeDescription = ImportDigitalResultsStaging.AdSizeDescription
                                        DigitalResult.Leads1 = ImportDigitalResultsStaging.Leads1
                                        DigitalResult.Leads2 = ImportDigitalResultsStaging.Leads2
                                        DigitalResult.Calls = ImportDigitalResultsStaging.Calls
                                        DigitalResult.LikesOrganic = ImportDigitalResultsStaging.LikesOrganic
                                        DigitalResult.LikesPaid = ImportDigitalResultsStaging.LikesPaid
                                        DigitalResult.Visits = ImportDigitalResultsStaging.Visits
                                        DigitalResult.UniqueVisitors = ImportDigitalResultsStaging.UniqueVisitors
                                        DigitalResult.ReachOrganic = ImportDigitalResultsStaging.ReachOrganic
                                        DigitalResult.ReachPaid = ImportDigitalResultsStaging.ReachPaid
                                        DigitalResult.PageViews = ImportDigitalResultsStaging.PageViews
                                        DigitalResult.PageEngagement = ImportDigitalResultsStaging.PageEngagement
                                        DigitalResult.Note = ImportDigitalResultsStaging.Note
                                        DigitalResult.PlacementID = ImportDigitalResultsStaging.PlacementID
                                        DigitalResult.AdServerSource = ImportDigitalResultsStaging.AdServerSource

                                        DigitalResults.Add(DigitalResult)

                                        ImportDigitalResultsStaging.DbContext = DbContext
                                        DbContext.Entry(ImportDigitalResultsStaging).State = Entity.EntityState.Deleted

                                    Next

                                    BulkInsertDigitalResultList(DbContext.ConnectionString, DigitalResults)

                                    DbContext.SaveChanges()

                                End If

                                Success = True

                            Catch ex As Exception
                                ErrorString = ex.Message
                            Finally
                                DbContext.Configuration.AutoDetectChangesEnabled = True
                            End Try

                        End If

                    End If

                Else

                    ErrorString = "Cannot find default directory for import template '" & _DOUBLECLICK_IMPORT_TEMPLATE_NAME & "'."

                End If

            End Using

            ProcessReport = Success

        End Function

#End Region

    End Module

End Namespace
