Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Namespace Database

    Public Class DbContext
        Inherits Database.Base.DbContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            AccountSetupForm
            CashReceiptPaymentTypes
            ChatMessages
            ChatRooms
            ChatUsers
            ConceptShareExternalReviewers
            CollectedCostInformations
            DigitalResultsViews
            ImportClearedCheckMediaVCCStagings
            ImportClientContactStagings
            IRS1099FederalStateCodes
            MediaManagerGeneratedReports
            MediaManagerGeneratedReportDetails
            MediaManagerGeneratedReportSentInfos
            MediaManagerSearchSettings
            NewspaperOtherCharges
            OrderProcessLogs
            States
            VCCCards
            VCCCardDetails
            VCCCardNotes
            VCCCardPOs
            VCCCardPODetails
            VCCCardPONotes
            VendorContracts
            VendorContractContacts

            BillingApprovalDetails
            BillingApprovalHeaders
            BillingApprovalItems
            ClientCashReceiptDetailPayments
            AdvanceBillings
            IncomeRecognizes

            AccountExecutives
            AccountGroupDetails
            AccountGroups
            AccountPayableGLDistributions
            AccountPayableInternets
            AccountPayableMagazines
            AccountPayableMediaApprovals
            AccountPayableNewspapers
            AccountPayableOutOfHomes
            AccountPayablePayments
            AccountPayableProductionComments
            AccountPayableProductions
            AccountPayableRadioBroadcastDetails
            AccountPayableRadios
            AccountPayableRecurGeneralLedgers
            AccountPayableRecurLogs
            AccountPayableRecurs
            AccountPayables
            AccountPayableTVBroadcastDetails
            AccountPayableTVs
            AccountPayableViews
            AccountReceivableCollectionNotes
            AccountReceivableDocuments
            AccountReceivableImportStagings
            AccountReceivables
            AccountReceivableSummaries
            AccountReceivableViews
            Accounts
            Activities
            ActivityCompetitions
            Ads
            AdServerPlacementFields
            AdServers
            AdSizeLabels
            AdSizes
            AdvantageServiceExports
            AdvantageServiceImports
            AdvantageServiceReportSchedules
            Affiliations
            Agencies
            AgencyClients
            AgencyComments
            AgencyDesktopDocuments
            AlertAssignmentTemplateDepartmentTeams
            AlertAssignmentTemplateEmailGroups
            AlertAssignmentTemplateEmployees
            AlertAssignmentTemplateRoles
            AlertAssignmentTemplates
            AlertAssignmentTemplateStates
            AlertAttachments
            AlertAttachmentViews
            AlertCategories
            AlertComments
            AlertDocumentKeywords
            AlertDocuments
            AlertGroupCategories
            AlertGroups
            AlertRecipientDismisseds
            AlertRecipients
            Alerts
            AlertsReports
            AlertStates
            AlertsWithCommentsReports
            AlertsWithRecipientsReports
            AlertTypes
            AlertViews
            AppVars
            AssignNumbers
            Associates
            BankExportSpecs
            Banks
            BillingCoops
            BillingRateDetails
            BillingRateDetailViews
            BillingRateLevels
            Blackplates
            Boards
            BoardJobs
            BoardHeaders
            BoardColumns
            BoardDetails
            BoardSwimLanes
            BroadcastImportCrossReferences
            BroadcastOrderDetailViews
            BudgetDetails
            Budgets
            CampaignDetails
            CampaignReports
            Campaigns
            CampaignViews
            ChecklistHeaders
            ChecklistDetails
            CheckRegisters
            CheckWritingSelections
            ClientAccountsReceivableStatements
            ClientCashReceiptDetails
            ClientCashReceiptOnAccounts
            ClientCashReceipts
            ClientContact
            ClientContactDetails
            ClientContactReports
            ClientCrossReferences
            ClientLateFees
            ClientPortalAlertRecipientDismisseds
            ClientPortalAlertRecipients
            ClientPortalAlertViews
            ClientReports
            Clients
            ClientSortKeys
            ClientWebsites
            CompanyProfileAffiliations
            CompanyProfiles
            Competitions
            Complexities
            ComscoreCacheDetails
            ComscoreCacheHeaders
            ComscoreGroupOwners
            ComscoreNetworks
            ComscoreTVBooks
            ComscoreTVStations
            ContactTypes
            ContractContacts
            ContractDocuments
            ContractFees
            ContractReports
            Contracts
            ContractValueAddeds
            CoreMediaCheckExports
            CreativeBriefDetails
            CreativeBriefTemplateLevel1s
            CreativeBriefTemplateLevel2s
            CreativeBriefTemplateLevel3s
            CreativeBriefTemplates
            CRMClientContractsReports
            CRMOpportunityDetailReports
            CRMOpportunityToInvestmentReports
            CRMProspectsReports
            Currencies
            CurrencyCodes
            CurrencyDetails
            CurrentJobProcessLogs
            CustomNavigationTabItems
            CustomNavigationTabs
            CustomReports
            Cycles
            Dashboards
            DataGridViewColumns
            DataGridViewColumnUserSettings
            DataGridViews
            Dayparts
            DaypartTypes
            DepartmentTeams
            DestinationContacts
            Destinations
            DigitalResults
            DirectIndirectTimeReports
            DirectIndirectTimeCostReports
            DirectTimeReports
            DirectTimeCostReports
            DivisionReports
            Divisions
            DivisionSortKeys
            DivisionViews
            DocumentComments
            Documents
            DocumentTypes
            DynamicReportColumns
            DynamicReports
            DynamicReportSummaryItems
            DynamicReportUnboundColumns
            EmployeeAdditionalEmails
            EmployeeCategories
            EmployeeDepartments
            EmployeeNonTasks
            EmployeeOffices
            EmployeePictures
            EmployeeRateHistories
            EmployeeReports
            EmployeeRoles
            Employees
            EmployeeStandardHours
            EmployeeStandardHoursDetails
            EmployeeTimeComments
            EmployeeTimeDetails
            EmployeeTimeForecastOfficeDetailAlternateEmployees
            EmployeeTimeForecastOfficeDetailEmployees
            EmployeeTimeForecastOfficeDetailIndirectCategories
            EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees
            EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees
            EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees
            EmployeeTimeForecastOfficeDetailJobComponentEmployees
            EmployeeTimeForecastOfficeDetailJobComponents
            EmployeeTimeForecastOfficeDetails
            EmployeeTimeForecasts
            EmployeeTimeIndirects
            EmployeeTimes
            EmployeeTimesheetFunctions
            EmployeeTimeStagings
            EmployeeTimeStagingsIDs
            EmployeeTimeTemplates
            EmployeeTimeTotalsByOfficeClients
            EmployeeTitles
            Epics
            EstimateApprovals
            EstimateComments
            EstimateFunctionComments
            EstimateProcessingOptions
            EstimateRevisionDetails
            EstimateRevisions
            EstimateTemplates
            ETFOfficeDetailIndirectCategories
            ETFOfficeDetailIndirectCategoryAlternateEmployees
            ETFOfficeDetailIndirectCategoryEmployees
            ETFOfficeDetailJobComponentAlternateEmployees
            ETFOfficeDetailJobComponentEmployees
            ETFOfficeDetailJobComponents
            ExecutiveDesktopDocuments
            ExpenseDetailDocuments
            ExpenseReportDetails
            ExpenseReportDocuments
            ExpenseReportDocumentUnassigneds
            ExpenseReports
            ExpenseSummarys
            ExportSystems
            ExportTemplateDetails
            ExportTemplates
            FiscalPeriods
            FunctionHeadings
            Functions
            FunctionViews
            GeneralDescriptions
            GeneralLedgerAccounts
            GeneralLedgerConfigs
            GeneralLedgerCrossReferences
            GeneralLedgerDepartmentTeamCrossReferences
            GeneralLedgerDetails
            GeneralLedgerOfficeCrossReferences
            GeneralLedgers
            GLAllocations
            GLASummaryDatas
            GLATrailers
            GLReportTemplateColumns
            GLReportTemplateDepartmentTeamPresets
            GLReportTemplateOfficePresets
            GLReportTemplatePctOfRowColumnRelations
            GLReportTemplateRowRelations
            GLReportTemplateRows
            GLReportTemplates
            GLReportUserDefReports
            GLTemplates
            IDs
            Images
            ImportAccountPayableBroadcastDetails
            ImportAccountPayableErrors
            ImportAccountPayableGLs
            ImportAccountPayableJobs
            ImportAccountPayableMedias
            ImportAccountPayables
            ImportClearedChecksStagings
            ImportClientStagings
            ImportCreditCardStagings
            ImportDigitalResultsStagings
            ImportDivisionStagings
            ImportEmployeeHoursStaging
            ImportEmployeeStagings
            ImportFunctionStagings
            ImportGeneralLedgerAccountStagings
            ImportJournalEntrys
            ImportJournalDetailEntrys
            ImportProductStagings
            ImportTemplateDetails
            ImportTemplates
            ImportVendorStagings
            IncomeOnlys
            IndirectCategories
            Industries
            InternetOrderDetails
            InternetOrders
            InternetTypes
            InvoiceCategories
            InvoiceJobComments
            InvoiceJobFunctionComments
            InvoiceMatchingSetting
            JobComponents
            JobComponentTaskClientContacts
            JobComponentTaskEmployees
            JobComponentTaskPredecessor
            JobComponentTasks
            JobComponentUserDefinedValue1
            JobComponentUserDefinedValue2
            JobComponentUserDefinedValue3
            JobComponentUserDefinedValue4
            JobComponentUserDefinedValue5
            JobComponentViews
            JobDetailItemABs
            JobDetailItemCs
            JobDetailItemEIs
            JobDetailItemEs
            JobDetailItemES1
            JobDetailItemIs
            JobDetailItemNDs
            JobDetailItemPOes
            JobDetailItemVs
            JobProcessLogs
            JobProjectScheduleSummaryReports
            JobPurchaseOrderReports
            Jobs
            JobServiceFees
            JobSpecificationCategories
            JobSpecificationFields
            JobSpecificationTypes
            JobSpecificationVendorTabs
            JobSummaryReports
            JobTemplateDetails
            JobTemplateItems
            JobTemplates
            JobTraffic
            JobTrafficPredecessor
            JobTrafficSetupDetails
            JobTrafficSetupItems
            JobTrafficTemplates
            JobTrafficVersions
            JobTypes
            JobUserDefinedValue1
            JobUserDefinedValue2
            JobUserDefinedValue3
            JobUserDefinedValue4
            JobUserDefinedValue5
            JobVersionDatabaseTypes
            JobVersionTemplateDetails
            JobVersionTemplates
            JobViews
            Logos
            LogoTypes
            MagazineDetails
            MagazineOrderDetails
            MagazineOrders
            Magazines
            ManagementLevels
            MarketBreaks
            Markets
            MediaATBRevisionDetails
            MediaATBRevisions
            MediaATBs
            MediaChannels
            MediaDemographicDetails
            MediaDemographics
            MediaInvoiceDefaults
            MediaManagerGeneratedPOReports
            MediaMetrics
            MediaOrders
            MediaPlanDatas
            MediaPlanDetailChangeLogs
            MediaPlanDetailFields
            MediaPlanDetailLevelLineDatas
            MediaPlanDetailLevelLines
            MediaPlanDetailLevelLineTags
            MediaPlanDetailLevels
            MediaPlanDetails
            MediaPlanDetailSettings
            MediaPlanMasterPlanDetails
            MediaPlanMasterPlans
            MediaPlanReports
            MediaPlans
            MediaRFPAvailLines
            MediaRFPAvailLineSpots
            MediaRFPDemos
            MediaRFPHeaders
            MediaRFPHeaderStatuses
            MediaRFPPrintSettings
            MediaRFPStatuses
            MediaRFPVendorDaypartCrossReferences
            MediaRFPVendorMarketCrossReferences
            MediaRFPVendorStationCrossReferences
            MediaSpecsDetails
            MediaSpecsHeaders
            MediaSpotRadioCountyResearchs
            MediaSpotRadioCountyResearchMetrics
            MediaSpotRadioCountyResearchStations
            MediaSpotRadioCountyResearchYears
            MediaSpotRadioResearchs
            MediaSpotRadioResearchBooks
            MediaSpotRadioResearchDayparts
            MediaSpotRadioResearchMetrics
            MediaSpotRadioResearchStations
            MediaSpotTVResearchs
            MediaSpotTVResearchBooks
            MediaSpotTVResearchDayTimes
            MediaSpotTVResearchDemos
            MediaSpotTVResearchMetrics
            MediaSpotTVResearchStations
            MediaTactics
            MediaTrafficCreativeGroups
            MediaTrafficDetailDocuments
            MediaTrafficDetails
            MediaTrafficPrintSettings
            MediaTrafficRevisions
            MediaTraffics
            MediaTrafficStatuses
            MediaTrafficVendorCreativeGroups
            MediaTrafficVendors
            MediaTrafficVendorStatuses
            MyObjectDefinitionAvailableOptions
            MyObjectDefinitionObjects
            MyObjectDefinitionSettings
            MyObjectDefinitionStaticOptions
            NationalUniverses
            NewspaperDetails
            NewspaperHeaders
            NewspaperOrderDetailReports
            NewspaperOrderDetails
            NewspaperOrders
            NielsenDemographics
            NielsenMarkets
            OfficeDocuments
            OfficeFunctionAccounts
            OfficeInterCompanies
            Offices
            OfficeSalesClassAccounts
            OfficeSalesClassFunctionAccounts
            OfficeSalesTaxAccounts
            OtherCashReceiptDetails
            OtherCashReceipts
            OutOfHomeOrderDetails
            OutOfHomeOrders
            OutOfHomeTypes
            OverheadAccounts
            PartnerAllocationDetails
            PartnerAllocations
            Partners
            Phases
            POApprovals
            PostPeriods
            PrintSpecRegions
            PrintSpecStatuses
            ProductAccountsReceivableStatements
            ProductCategories
            ProductionInvoiceDefaults
            ProductReports
            Products
            ProductSortKeys
            ProductViews
            ProjectHoursUsedReports
            ProjectScheduleReports
            PromotionTypes
            PTORuleDetails
            PTORules
            PurchaseOrderApprovalRuleDetails
            PurchaseOrderApprovalRuleEmployees
            PurchaseOrderApprovalRules
            PurchaseOrderDetails
            PurchaseOrderDocuments
            PurchaseOrderPrintDefaults
            PurchaseOrderStatuses
            PurchaseOrders
            RadioOrderDetailLegacies
            RadioOrderDetails
            RadioOrderLegacies
            RadioOrders
            RateCardColorCharges
            RateCardDetails
            RateCards
            Ratings
            RecordSources
            Resources
            ResourceTasks
            ResourceTypes
            Roles
            SalesClasses
            SalesClassFormats
            SalesTaxes
            ServiceFeeReconcileDetails
            ServiceFeeTypes
            SoftwareBuilds
            SoftwareLevels
            SoftwareVersions
            Sources
            Specialties
            SprintDetails
            SprintEmployees
            SprintHeaders
            StandardComments
            Status
            Tasks
            TaskTemplates
            TimeCategoryTypes
            TimeRuleLogs
            TimeSeparationSetting
            TVOrderDetailLegacies
            TVOrderDetails
            TVOrderLegacies
            TVOrders
            UserDefinedLabel
            UserDefinedReportCategories
            UserDefinedReports
            UserDefinedTypes
            UserDefinedTypeValues
            VendorComments
            VendorContacts
            VendorCrossReferences
            VendorDCMMappings
            VendorHistorys
            VendorInvoiceAlerts
            VendorInvoiceDetails
            VendorInvoices
            VendorPricings
            VendorReports
            Vendors
            VendorSortKeys
            VendorTerms
            WebsiteTypes
            WorkflowAlertStates
            Workflows1

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Overridable Property AdvantageSESs() As System.Data.Entity.DbSet(Of Database.Entities.AdvantageSES)

#End Region

#Region " Methods "

        Public Sub New()

            MyBase.New("name=DefaultConnection")

        End Sub
        Public Sub New(ConnectionString As String)

            MyBase.New(AdvantageSES.Database.Base.DbContext.CreateEntityConnectionString(ConnectionString))

            MyBase.Database.CommandTimeout = 0
            MyBase.Configuration.LazyLoadingEnabled = True
            MyBase.Configuration.ValidateOnSaveEnabled = False

            _ConnectionString = ConnectionString

            System.Data.Entity.Database.SetInitializer(Of Database.DbContext)(Nothing)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

        End Sub

#End Region

    End Class

End Namespace
