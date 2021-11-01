Namespace Database

    <System.Data.Linq.Mapping.DatabaseAttribute()>
    <NotMapped>
    Public Class DataContext
        Inherits AdvantageFramework.BaseClasses.DataContext

#Region " Constants "


#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

#Region "  Tables "

        Public ReadOnly Property AdvantageServiceImportSettings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AdvantageServiceImportSetting)
            Get
                AdvantageServiceImportSettings = Me.GetTable(Of AdvantageFramework.Database.Entities.AdvantageServiceImportSetting)()
            End Get
        End Property
        Public ReadOnly Property AdvantageServiceSettingLists() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AdvantageServiceSettingList)
            Get
                AdvantageServiceSettingLists = Me.GetTable(Of AdvantageFramework.Database.Entities.AdvantageServiceSettingList)()
            End Get
        End Property
        Public ReadOnly Property AdvantageServiceSettings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AdvantageServiceSetting)
            Get
                AdvantageServiceSettings = Me.GetTable(Of AdvantageFramework.Database.Entities.AdvantageServiceSetting)()
            End Get
        End Property
        Public ReadOnly Property AdvantageServices() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AdvantageService)
            Get
                AdvantageServices = Me.GetTable(Of AdvantageFramework.Database.Entities.AdvantageService)()
            End Get
        End Property
        Public ReadOnly Property PrintImportCrossReferences() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.PrintImportCrossReference)
            Get
                PrintImportCrossReferences = Me.GetTable(Of AdvantageFramework.Database.Entities.PrintImportCrossReference)()
            End Get
        End Property
        Public ReadOnly Property EstimateTemplateDetails() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail)
            Get
                EstimateTemplateDetails = Me.GetTable(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail)()
            End Get
        End Property
        Public ReadOnly Property Settings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.Setting)
            Get
                Settings = Me.GetTable(Of AdvantageFramework.Database.Entities.Setting)()
            End Get
        End Property
        Public ReadOnly Property SettingValues() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.SettingValue)
            Get
                SettingValues = Me.GetTable(Of AdvantageFramework.Database.Entities.SettingValue)()
            End Get
        End Property
        Public ReadOnly Property SettingModules() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.SettingModule)
            Get
                SettingModules = Me.GetTable(Of AdvantageFramework.Database.Entities.SettingModule)()
            End Get
        End Property
        Public ReadOnly Property SettingModuleGroups() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.SettingModuleGroup)
            Get
                SettingModuleGroups = Me.GetTable(Of AdvantageFramework.Database.Entities.SettingModuleGroup)()
            End Get
        End Property
        Public ReadOnly Property SettingModuleTabs() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.SettingModuleTab)
            Get
                SettingModuleTabs = Me.GetTable(Of AdvantageFramework.Database.Entities.SettingModuleTab)()
            End Get
        End Property
        Public ReadOnly Property SettingDatabaseTypes() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.SettingDatabaseType)
            Get
                SettingDatabaseTypes = Me.GetTable(Of AdvantageFramework.Database.Entities.SettingDatabaseType)()
            End Get
        End Property
        Public ReadOnly Property JobVersionTemplateDetailListValues() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue)
            Get
                JobVersionTemplateDetailListValues = Me.GetTable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue)()
            End Get
        End Property
        Public ReadOnly Property TaskRoles() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.TaskRole)
            Get
                TaskRoles = Me.GetTable(Of AdvantageFramework.Database.Entities.TaskRole)()
            End Get
        End Property
        Public ReadOnly Property Modules() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.Module)
            Get
                Modules = Me.GetTable(Of AdvantageFramework.Database.Entities.Module)()
            End Get
        End Property
        Public ReadOnly Property MissingTimes() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.MissingTime)
            Get
                MissingTimes = Me.GetTable(Of AdvantageFramework.Database.Entities.MissingTime)()
            End Get
        End Property
        Public ReadOnly Property MissingTimeDetails() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.MissingTimeDetail)
            Get
                MissingTimeDetails = Me.GetTable(Of AdvantageFramework.Database.Entities.MissingTimeDetail)()
            End Get
        End Property
        Public ReadOnly Property TaskTemplateDetails() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.TaskTemplateDetail)
            Get
                TaskTemplateDetails = Me.GetTable(Of AdvantageFramework.Database.Entities.TaskTemplateDetail)()
            End Get
        End Property
        Public ReadOnly Property Locations() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.Location)
            Get
                Locations = Me.GetTable(Of AdvantageFramework.Database.Entities.Location)()
            End Get
        End Property
        Public ReadOnly Property VendorRepresentativeClients() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.VendorRepresentativeClient)
            Get
                VendorRepresentativeClients = Me.GetTable(Of AdvantageFramework.Database.Entities.VendorRepresentativeClient)()
            End Get
        End Property
        Public ReadOnly Property VendorRepresentatives() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.VendorRepresentative)
            Get
                VendorRepresentatives = Me.GetTable(Of AdvantageFramework.Database.Entities.VendorRepresentative)()
            End Get
        End Property
        Public ReadOnly Property ClientDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ClientDocument)
            Get
                ClientDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.ClientDocument)()
            End Get
        End Property
        Public ReadOnly Property DivisionDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.DivisionDocument)
            Get
                DivisionDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.DivisionDocument)()
            End Get
        End Property
        Public ReadOnly Property ProductDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ProductDocument)
            Get
                ProductDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.ProductDocument)()
            End Get
        End Property
        Public ReadOnly Property AccountPayableDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AccountPayableDocument)
            Get
                AccountPayableDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.AccountPayableDocument)()
            End Get
        End Property
        Public ReadOnly Property CampaignDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.CampaignDocument)
            Get
                CampaignDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.CampaignDocument)()
            End Get
        End Property
        Public ReadOnly Property JobDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.JobDocument)
            Get
                JobDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.JobDocument)()
            End Get
        End Property
        Public ReadOnly Property JobComponentDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.JobComponentDocument)
            Get
                JobComponentDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.JobComponentDocument)()
            End Get
        End Property
        Public ReadOnly Property JobProcesses() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.JobProcess)
            Get
                JobProcesses = Me.GetTable(Of AdvantageFramework.Database.Entities.JobProcess)()
            End Get
        End Property
        Public ReadOnly Property EmployeeDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.EmployeeDocument)
            Get
                EmployeeDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.EmployeeDocument)()
            End Get
        End Property
        Public ReadOnly Property VendorDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.VendorDocument)
            Get
                VendorDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.VendorDocument)()
            End Get
        End Property
        Public ReadOnly Property EEOCStatuses() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.EEOCStatus)
            Get
                EEOCStatuses = Me.GetTable(Of AdvantageFramework.Database.Entities.EEOCStatus)()
            End Get
        End Property
        Public ReadOnly Property AccountPayableRecurLogs() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AccountPayableRecurLog)
            Get
                AccountPayableRecurLogs = Me.GetTable(Of AdvantageFramework.Database.Entities.AccountPayableRecurLog)()
            End Get
        End Property
        Public ReadOnly Property GeneralLedgerConfigs() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.GeneralLedgerConfig)
            Get
                GeneralLedgerConfigs = Me.GetTable(Of AdvantageFramework.Database.Entities.GeneralLedgerConfig)()
            End Get
        End Property
        Public ReadOnly Property TimeZones() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.TimeZone)
            Get
                TimeZones = Me.GetTable(Of AdvantageFramework.Database.Entities.TimeZone)()
            End Get
        End Property
        Public ReadOnly Property GridAdvantages() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.GridAdvantage)
            Get
                GridAdvantages = Me.GetTable(Of AdvantageFramework.Database.Entities.GridAdvantage)()
            End Get
        End Property
        Public ReadOnly Property GridAdvantageColumns() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.GridAdvantageColumn)
            Get
                GridAdvantageColumns = Me.GetTable(Of AdvantageFramework.Database.Entities.GridAdvantageColumn)()
            End Get
        End Property
        Public ReadOnly Property Billings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.Billing)
            Get
                Billings = Me.GetTable(Of AdvantageFramework.Database.Entities.Billing)()
            End Get
        End Property
        Public ReadOnly Property MediaATBRevisionDetailOrders() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder)
            Get
                MediaATBRevisionDetailOrders = Me.GetTable(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder)()
            End Get
        End Property
        Public ReadOnly Property PrintOrders() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.PrintOrder)
            Get
                PrintOrders = Me.GetTable(Of AdvantageFramework.Database.Entities.PrintOrder)()
            End Get
        End Property
        Public ReadOnly Property BroadcastImports() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.BroadcastImport)
            Get
                BroadcastImports = Me.GetTable(Of AdvantageFramework.Database.Entities.BroadcastImport)()
            End Get
        End Property
        Public ReadOnly Property ServiceFeeInvoices() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ServiceFeeInvoice)
            Get
                ServiceFeeInvoices = Me.GetTable(Of AdvantageFramework.Database.Entities.ServiceFeeInvoice)()
            End Get
        End Property
        Public ReadOnly Property DynamicReportSettings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.DynamicReportSettings)
            Get
                DynamicReportSettings = Me.GetTable(Of AdvantageFramework.Database.Entities.DynamicReportSettings)()
            End Get
        End Property
        Public ReadOnly Property EstimatePrintingSetting() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting)
            Get
                EstimatePrintingSetting = Me.GetTable(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting)()
            End Get
        End Property
        Public ReadOnly Property EstimatePrintSetting() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.EstimatePrintSetting)
            Get
                EstimatePrintSetting = Me.GetTable(Of AdvantageFramework.Database.Entities.EstimatePrintSetting)()
            End Get
        End Property
        Public ReadOnly Property ContractReportDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ContractReportDocument)
            Get
                ContractReportDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.ContractReportDocument)()
            End Get
        End Property
        Public ReadOnly Property AdvantageServiceExportSettings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AdvantageServiceExportSetting)
            Get
                AdvantageServiceExportSettings = Me.GetTable(Of AdvantageFramework.Database.Entities.AdvantageServiceExportSetting)()
            End Get
        End Property
        Public ReadOnly Property VendorServiceTaxes() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.VendorServiceTax)
            Get
                VendorServiceTaxes = Me.GetTable(Of AdvantageFramework.Database.Entities.VendorServiceTax)()
            End Get
        End Property
        Public ReadOnly Property AvalaraTaxes() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AvalaraTax)
            Get
                AvalaraTaxes = Me.GetTable(Of AdvantageFramework.Database.Entities.AvalaraTax)()
            End Get
        End Property
        Public ReadOnly Property AvalaraProductMappings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.AvalaraProductMapping)
            Get
                AvalaraProductMappings = Me.GetTable(Of AdvantageFramework.Database.Entities.AvalaraProductMapping)()
            End Get
        End Property
        Public ReadOnly Property ImportAvalaraTaxStagings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging)
            Get
                ImportAvalaraTaxStagings = Me.GetTable(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging)()
            End Get
        End Property
        Public ReadOnly Property WorkARFunctions() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.WorkARFunction)
            Get
                WorkARFunctions = Me.GetTable(Of AdvantageFramework.Database.Entities.WorkARFunction)()
            End Get
        End Property
        Public ReadOnly Property OfficeOverheadSets() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.OfficeOverheadSet)
            Get
                OfficeOverheadSets = Me.GetTable(Of AdvantageFramework.Database.Entities.OfficeOverheadSet)()
            End Get
        End Property
        Public ReadOnly Property ContentUsers() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ContentUser)
            Get
                ContentUsers = Me.GetTable(Of AdvantageFramework.Database.Entities.ContentUser)()
            End Get
        End Property
        Public ReadOnly Property JobComponentTaskDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument)
            Get
                JobComponentTaskDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.JobComponentTaskDocument)()
            End Get
        End Property
        Public ReadOnly Property ImportCashReceipts() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ImportCashReceipt)
            Get
                ImportCashReceipts = Me.GetTable(Of AdvantageFramework.Database.Entities.ImportCashReceipt)()
            End Get
        End Property
        Public ReadOnly Property ImportCashReceiptDetails() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ImportCashReceiptDetail)
            Get
                ImportCashReceiptDetails = Me.GetTable(Of AdvantageFramework.Database.Entities.ImportCashReceiptDetail)()
            End Get
        End Property
        Public ReadOnly Property DocumentVersions() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.DocumentVersion)
            Get
                DocumentVersions = Me.GetTable(Of AdvantageFramework.Database.Entities.DocumentVersion)()
            End Get
        End Property
        Public ReadOnly Property Labels() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.Label)
            Get
                Labels = Me.GetTable(Of AdvantageFramework.Database.Entities.Label)()
            End Get
        End Property
        Public ReadOnly Property LabelDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.LabelDocument)
            Get
                LabelDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.LabelDocument)()
            End Get
        End Property
        Public ReadOnly Property ClientPOs() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ClientPO)
            Get
                ClientPOs = Me.GetTable(Of AdvantageFramework.Database.Entities.ClientPO)()
            End Get
        End Property
        Public ReadOnly Property DataContextDocumentTypes() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.DataContextDocumentType)
            Get
                DataContextDocumentTypes = Me.GetTable(Of AdvantageFramework.Database.Entities.DataContextDocumentType)()
            End Get
        End Property
        Public ReadOnly Property ImportPTOStagings() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ImportPTOStaging)
            Get
                ImportPTOStagings = Me.GetTable(Of AdvantageFramework.Database.Entities.ImportPTOStaging)()
            End Get
        End Property
        Public ReadOnly Property ImportTemplateExcludes() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ImportTemplateExclude)
            Get
                ImportTemplateExcludes = Me.GetTable(Of AdvantageFramework.Database.Entities.ImportTemplateExclude)()
            End Get
        End Property
        Public ReadOnly Property ImportDocuments() As System.Data.Linq.Table(Of AdvantageFramework.Database.Entities.ImportDocument)
            Get
                ImportDocuments = Me.GetTable(Of AdvantageFramework.Database.Entities.ImportDocument)()
            End Get
        End Property

#End Region

#Region "  Views "

        Public ReadOnly Property TaskTemplateDetailView() As System.Data.Linq.Table(Of AdvantageFramework.Database.Views.TaskTemplateDetail)
            Get
                TaskTemplateDetailView = Me.GetTable(Of AdvantageFramework.Database.Views.TaskTemplateDetail)()
            End Get
        End Property

#End Region

#End Region

#Region " Methods "

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode)

        End Sub

#Region "  Stored Procedures "

        <System.Data.Linq.Mapping.Function(IsComposable:=False, Name:="dbo.usp_wv_Traffic_Schedule_GetScheduleHeader"),
        System.Data.Linq.Mapping.ResultType(GetType(AdvantageFramework.Database.Entities.ScheduleHeader)),
        System.Data.Linq.Mapping.ResultType(GetType(AdvantageFramework.Database.Entities.ScheduleAssignmentLabel)),
        System.Data.Linq.Mapping.ResultType(GetType(AdvantageFramework.Database.Entities.ScheduleManagerColumn))>
        Public Function LoadScheduleHeader(<System.Data.Linq.Mapping.Parameter(name:="JOB_NUMBER", DbType:="INT")> ByVal JobNumber As Integer,
                                           <System.Data.Linq.Mapping.Parameter(name:="JOB_COMPONENT_NBR", DbType:="SMALLINT")> ByVal JobComponentNumber As Short,
                                           <System.Data.Linq.Mapping.Parameter(name:="USER_ID", DbType:="VARCHAR(100)")> ByVal UserID As String,
                                           <System.Data.Linq.Mapping.Parameter(name:="CL_CODE", DbType:="VARCHAR(6)")> Optional ByVal ClientCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="DIV_CODE", DbType:="VARCHAR(6)")> Optional ByVal DivisionCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="PRD_CODE", DbType:="VARCHAR(6)")> Optional ByVal ProductCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="EMP_CODE", DbType:="VARCHAR(6)")> Optional ByVal EmployeeCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="MGR_CODE", DbType:="VARCHAR(6)")> Optional ByVal ManagerCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="AE_CODE", DbType:="VARCHAR(6)")> Optional ByVal AccountExecutiveEmployeeCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="TASK_CODE", DbType:="VARCHAR(10)")> Optional ByVal TaskCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="ROLE_CODE", DbType:="VARCHAR(6)")> Optional ByVal RoleCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="CUT_OFF_DATE", DbType:="smalldatetime")> Optional ByVal CutOffDate As String = Nothing,
                                           <System.Data.Linq.Mapping.Parameter(name:="SHOW_ONLY_OPEN_SCHEDS", DbType:="SMALLINT")> Optional ByVal ShowOnlyOpenSchedules As Short = 1,
                                           <System.Data.Linq.Mapping.Parameter(name:="IncludeCompletedTasks", DbType:="CHAR(1)")> Optional ByVal IncludeCompletedTasks As String = "Y",
                                           <System.Data.Linq.Mapping.Parameter(name:="IncludeOnlyPendingTasks", DbType:="CHAR(1)")> Optional ByVal IncludeOnlyPendingTasks As String = "N",
                                           <System.Data.Linq.Mapping.Parameter(name:="ExcludeProjectedTasks", DbType:="CHAR(1)")> Optional ByVal ExcludedProjectedTasks As String = "N",
                                           <System.Data.Linq.Mapping.Parameter(name:="CMP_CODE", DbType:="VARCHAR(6)")> Optional ByVal CampaignCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="INCLUDE_CLOSE_JOBS", DbType:="BIT")> Optional ByVal IncludeClosedJobs As Boolean = True,
                                           <System.Data.Linq.Mapping.Parameter(name:="MILESTONES_ONLY", DbType:="BIT")> Optional ByVal MilestonesOnly As Boolean = False,
                                           <System.Data.Linq.Mapping.Parameter(name:="TRAFFIC_STATUS_CODE", DbType:="VARCHAR(10)")> Optional ByVal TrafficStatusCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="GANTT", DbType:="BIT")> Optional ByVal Gantt As Boolean = False,
                                           <System.Data.Linq.Mapping.Parameter(name:="OFFICE_CODE", DbType:="VARCHAR(6)")> Optional ByVal OfficeCode As String = "",
                                           <System.Data.Linq.Mapping.Parameter(name:="SC_CODE", DbType:="VARCHAR(6)")> Optional ByVal SalesClassCode As String = "") As System.Data.Linq.IMultipleResults

            Dim IExecuteResult As System.Data.Linq.IExecuteResult = Nothing
            Dim IMultipleResults As System.Data.Linq.IMultipleResults = Nothing

            IExecuteResult = Me.ExecuteMethodCall(Me, CType(System.Reflection.MethodInfo.GetCurrentMethod(), System.Reflection.MethodInfo), JobNumber, JobComponentNumber, UserID, ClientCode, DivisionCode, ProductCode, EmployeeCode, ManagerCode, AccountExecutiveEmployeeCode, TaskCode, RoleCode, CutOffDate, ShowOnlyOpenSchedules, IncludeCompletedTasks, IncludeOnlyPendingTasks, ExcludedProjectedTasks, CampaignCode, IncludeClosedJobs, MilestonesOnly, TrafficStatusCode, Gantt, OfficeCode, SalesClassCode)

            LoadScheduleHeader = DirectCast(IExecuteResult.ReturnValue, System.Data.Linq.IMultipleResults)

        End Function

        '<System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.advsp_populate_missing_time_table")> _
        'Public Function LoadMissingTime(<System.Data.Linq.Mapping.Parameter(Name:="start_date", DbType:="VARCHAR(12)")> _
        '                                        ByVal StartDate As String, _
        '                                <System.Data.Linq.Mapping.Parameter(Name:="end_date", DbType:="VARCHAR(12)")> _
        '                                        ByVal EndDate As String, _
        '                                <System.Data.Linq.Mapping.Parameter(Name:="exclude_hol_wkends", DbType:="smallint")> _
        '                                        ByVal ExcludeHolidaysAndWeekends As Integer, _
        '                                <System.Data.Linq.Mapping.Parameter(Name:="missing_time_only", DbType:="smallint")> _
        '                                        ByVal MissingTimeOnly As Integer) As Integer

        '    LoadMissingTime = CType(Me.ExecuteMethodCall(Me, CType(System.Reflection.MethodInfo.GetCurrentMethod, System.Reflection.MethodInfo), StartDate, EndDate, ExcludeHolidaysAndWeekends, MissingTimeOnly).ReturnValue, Integer)

        'End Function

#End Region

#End Region

    End Class

End Namespace