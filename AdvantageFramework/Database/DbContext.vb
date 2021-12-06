Namespace Database

    Public Class DbContext
        Inherits BaseClasses.DbContext

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

        Public Overridable Property MediaSpotTVPuertoRicoResearchs() As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVPuertoRicoResearch)
        Public Overridable Property MediaSpotTVPuertoRicoResearchDayTimes() As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVPuertoRicoResearchDayTime)
        Public Overridable Property MediaSpotTVPuertoRicoResearchDemos() As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVPuertoRicoResearchDemo)
        Public Overridable Property MediaSpotTVPuertoRicoResearchMetrics() As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVPuertoRicoResearchMetric)
        Public Overridable Property MediaSpotTVPuertoRicoResearchStations() As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVPuertoRicoResearchStation)

        Public Overridable Property NPRAudiences() As System.Data.Entity.DbSet(Of Database.Entities.NPRAudience)
        Public Overridable Property NPRFiles() As System.Data.Entity.DbSet(Of Database.Entities.NPRFile)
        Public Overridable Property NPRHutputs() As System.Data.Entity.DbSet(Of Database.Entities.NPRHutput)
        Public Overridable Property NPRIntabs() As System.Data.Entity.DbSet(Of Database.Entities.NPRIntab)
        Public Overridable Property NPRStations() As System.Data.Entity.DbSet(Of Database.Entities.NPRStation)
        Public Overridable Property NPRUniverses() As System.Data.Entity.DbSet(Of Database.Entities.NPRUniverse)

        Public Overridable Property MediaPlanDocuments() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDocument)
        Public Overridable Property QuickbooksSettings() As System.Data.Entity.DbSet(Of Database.Entities.QuickbooksSetting)

        Public Overridable Property MediaPlanDetailGRPBudgets() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailGRPBudget)
        Public Overridable Property AccessEmails() As System.Data.Entity.DbSet(Of Database.Entities.AccessEmail)
        Public Overridable Property MediaPlanTemplateProducts() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanTemplateProduct)
        Public Overridable Property MediaPlanTemplateDetails() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanTemplateDetail)
        Public Overridable Property MediaPlanTemplateHeaders() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanTemplateHeader)

        Public Overridable Property MediaPlanEstimateTemplates() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplate)
        Public Overridable Property MediaPlanEstimateTemplateAdSizes() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateAdSize)
        Public Overridable Property MediaPlanEstimateTemplateProducts() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateProduct)
        Public Overridable Property MediaPlanEstimateTemplateDatas() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateData)
        Public Overridable Property MediaPlanEstimateTemplateDayparts() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateDaypart)
        Public Overridable Property MediaPlanEstimateTemplateDaypartPercents() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateDaypartPercent)
        Public Overridable Property MediaPlanEstimateTemplateDemographics() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateDemographic)
        Public Overridable Property MediaPlanEstimateTemplateMarkets() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateMarket)
        Public Overridable Property MediaPlanEstimateTemplateOutdoorTypes() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateOutdoorType)
        Public Overridable Property MediaPlanEstimateTemplatePivotFields() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplatePivotField)
        Public Overridable Property MediaPlanEstimateTemplateQuarters() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateQuarter)
        Public Overridable Property MediaPlanEstimateTemplateRateTypes() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateRateType)
        Public Overridable Property MediaPlanEstimateTemplateSpotLengths() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateSpotLength)
        Public Overridable Property MediaPlanEstimateTemplateTactics() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateTactic)
        Public Overridable Property MediaPlanEstimateTemplateVendors() As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanEstimateTemplateVendor)

        Public Overridable Property AdvantageSESs() As System.Data.Entity.DbSet(Of Database.Entities.AdvantageSES)

        Public Overridable Property DigitalCampaignManagerUserSettings() As System.Data.Entity.DbSet(Of Database.Entities.DigitalCampaignManagerUserSetting)

        Public Overridable Property CDPSecurityGroups() As System.Data.Entity.DbSet(Of Database.Entities.CDPSecurityGroup)
        Public Overridable Property CDPSecurityGroupEmployees() As System.Data.Entity.DbSet(Of Database.Entities.CDPSecurityGroupEmployee)

        Public Overridable Property VendorEEOC2s As System.Data.Entity.DbSet(Of Database.Entities.VendorEEOC2)

        Public Overridable Property MediaSpotNationalResearchs As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotNationalResearch)
        Public Overridable Property MediaSpotNationalResearchMediaDemos As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotNationalResearchMediaDemo)
        Public Overridable Property MediaSpotNationalResearchMetrics As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotNationalResearchMetric)
        Public Overridable Property MediaSpotNationalResearchNetworks As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotNationalResearchNetwork)
        Public Overridable Property AlertRecipientExternals As System.Data.Entity.DbSet(Of Database.Entities.AlertRecipientExternal)
        Public Overridable Property AlertRecipientExternalDismisseds As System.Data.Entity.DbSet(Of Database.Entities.AlertRecipientExternalDismissed)
        Public Overridable Property ProofingExternalReviewers As System.Data.Entity.DbSet(Of Database.Entities.ProofingExternalReviewer)
        Public Overridable Property ProofingMarkups As System.Data.Entity.DbSet(Of Database.Entities.ProofingMarkup)
        Public Overridable Property ProofingDocuments As System.Data.Entity.DbSet(Of Database.Entities.ProofingDocument)
        Public Overridable Property ProofingAssetStatuses As System.Data.Entity.DbSet(Of Database.Entities.ProofingAssetStatus)
        Public Overridable Property Countries As System.Data.Entity.DbSet(Of Database.Entities.Country)
        Public Overridable Property CanadaUniverses As System.Data.Entity.DbSet(Of Database.Entities.CanadaUniverse)
        Public Overridable Property MarketGroups As System.Data.Entity.DbSet(Of Database.Entities.MarketGroup)
        Public Overridable Property MarketGroupMarkets As System.Data.Entity.DbSet(Of Database.Entities.MarketGroupMarket)
        Public Overridable Property VendorMarkets As System.Data.Entity.DbSet(Of Database.Entities.VendorMarket)

        Public Overridable Property GeneralLedgerRecurringEntries As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerRecurringEntry)
        Public Overridable Property GeneralLedgerRecurringEntryDetails As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerRecurringEntryDetail)
        Public Overridable Property GeneralLedgerDocuments() As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerDocument)

        Public Overridable Property RevenueResourcePlans() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlan)

        Public Overridable Property RevenueResourcePlanStaffs() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanStaff)
        Public Overridable Property RevenueResourcePlanStaffClients() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanStaffClient)

        Public Overridable Property RevenueResourcePlanResources() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanResource)
        Public Overridable Property RevenueResourcePlanResourceRevisions() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanResourceRevision)
        Public Overridable Property RevenueResourcePlanResourceDetails() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanResourceDetail)
        Public Overridable Property RevenueResourcePlanResourceDetailDates() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanResourceDetailDate)

        Public Overridable Property RevenueResourcePlanRevenues() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanRevenue)
        Public Overridable Property RevenueResourcePlanRevenueRevisions() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanRevenueRevision)
        Public Overridable Property RevenueResourcePlanRevenueDetails() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanRevenueDetail)
        Public Overridable Property RevenueResourcePlanRevenueDetailDates() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanRevenueDetailDate)

        Public Overridable Property RevenueResourcePlanRevenueStatuses() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanRevenueStatus)
        Public Overridable Property RevenueResourcePlanRevenueTypes() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanRevenueType)
        Public Overridable Property RevenueResourcePlanStaffTypes() As System.Data.Entity.DbSet(Of Database.Entities.RevenueResourcePlanStaffType)

        Public Overridable Property AlertEmployeeHours() As System.Data.Entity.DbSet(Of Database.Entities.AlertEmployeeHour)

        Public Overridable Property UserClientDivisionProductAccesses() As System.Data.Entity.DbSet(Of Database.Entities.UserClientDivisionProductAccess)

        Public Overridable Property POP3AutomatedAssignmentAccounts() As System.Data.Entity.DbSet(Of Database.Entities.POP3AutomatedAssignmentAccount)

        Public Overridable Property MediaCalendars() As System.Data.Entity.DbSet(Of Database.Entities.MediaCalendar)

        Public Overridable Property ClientDiscounts() As System.Data.Entity.DbSet(Of Database.Entities.ClientDiscount)
        Public Overridable Property ClientDiscountExclusions() As System.Data.Entity.DbSet(Of Database.Entities.ClientDiscountExclusion)

        Public Overridable Property BoardJobs() As System.Data.Entity.DbSet(Of Database.Entities.BoardJob)
        Public Overridable Property Boards() As System.Data.Entity.DbSet(Of Database.Entities.Board)
        Public Overridable Property Epics() As System.Data.Entity.DbSet(Of Database.Entities.Epic)

        Public Overridable Property SoftwareVersions() As System.Data.Entity.DbSet(Of Database.Entities.SoftwareVersion)
        Public Overridable Property SoftwareBuilds() As System.Data.Entity.DbSet(Of Database.Entities.SoftwareBuild)
        Public Overridable Property SoftwareLevels() As System.Data.Entity.DbSet(Of Database.Entities.SoftwareLevel)

        Public Overridable Property BoardHeaders() As System.Data.Entity.DbSet(Of Database.Entities.BoardHeader)
        Public Overridable Property BoardColumns() As System.Data.Entity.DbSet(Of Database.Entities.BoardColumn)
        Public Overridable Property BoardDetails() As System.Data.Entity.DbSet(Of Database.Entities.BoardDetail)
        Public Overridable Property BoardSwimLanes() As System.Data.Entity.DbSet(Of Database.Entities.BoardSwimLane)
        Public Overridable Property SprintHeaders() As System.Data.Entity.DbSet(Of Database.Entities.SprintHeader)
        Public Overridable Property SprintDetails() As System.Data.Entity.DbSet(Of Database.Entities.SprintDetail)
        Public Overridable Property SprintEmployees() As System.Data.Entity.DbSet(Of Database.Entities.SprintEmployee)

        Public Overridable Property VendorInvoiceCategories() As System.Data.Entity.DbSet(Of Database.Entities.VendorInvoiceCategory)
        Public Overridable Property Orders() As System.Data.Entity.DbSet(Of Database.Views.Order)
        Public Overridable Property OrderDocuments() As System.Data.Entity.DbSet(Of Database.Views.OrderDocument)
        Public Overridable Property InternetDocuments() As System.Data.Entity.DbSet(Of Database.Entities.InternetDocument)
        Public Overridable Property MagazineDocuments() As System.Data.Entity.DbSet(Of Database.Entities.MagazineDocument)
        Public Overridable Property NewspaperDocuments() As System.Data.Entity.DbSet(Of Database.Entities.NewspaperDocument)
        Public Overridable Property OutOfHomeDocuments() As System.Data.Entity.DbSet(Of Database.Entities.OutOfHomeDocument)
        Public Overridable Property RadioDocuments() As System.Data.Entity.DbSet(Of Database.Entities.RadioDocument)
        Public Overridable Property TVDocuments() As System.Data.Entity.DbSet(Of Database.Entities.TVDocument)

        Public Overridable Property CableNetworkStations() As System.Data.Entity.DbSet(Of Database.Entities.CableNetworkStation)
        Public Overridable Property MediaBroadcastWorksheets() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheet)
        Public Overridable Property MediaBroadcastWorksheetDateTypes() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetDateType)
        Public Overridable Property MediaBroadcastWorksheetOrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetOrderStatus)
        Public Overridable Property MediaCalendarTypes() As System.Data.Entity.DbSet(Of Database.Entities.MediaCalendarType)
        Public Overridable Property MediaBroadcastWorksheetMarketTVGeographies() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketTVGeography)
        Public Overridable Property MediaBroadcastWorksheetMarketRadioEthnicities() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketRadioEthnicity)
        Public Overridable Property MediaBroadcastWorksheetMarketRadioGeographies() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketRadioGeography)
        Public Overridable Property MediaBroadcastWorksheetMarkets() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarket)
        Public Overridable Property MediaBroadcastWorksheetMarketSubmarkets() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketSubmarket)
        Public Overridable Property MediaBroadcastWorksheetMarketRevisions() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketRevision)
        Public Overridable Property MediaBroadcastWorksheetMarketGoals() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketGoal)
        Public Overridable Property MediaBroadcastWorksheetMarketGoalDates() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketGoalDate)
        Public Overridable Property MediaBroadcastWorksheetMarketDetails() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketDetail)
        Public Overridable Property MediaBroadcastWorksheetMarketDetailDates() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate)
        Public Overridable Property MediaBroadcastWorksheetSecondaryDemos() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetSecondaryDemo)
        Public Overridable Property MediaBroadcastWorksheetMarketNielsenTVBooks() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)
        Public Overridable Property MediaBroadcastWorksheetMarketNielsenRadioPeriods() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)
        Public Overridable Property MediaBroadcastWorksheetPrePostReportCriterias() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetPrePostReportCriteria)
        Public Overridable Property MediaBroadcastWorksheetPrintOptions() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetPrintOptions)
        Public Overridable Property MediaBroadcastWorksheetMarketStagingDetails() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetail)
        Public Overridable Property MediaBroadcastWorksheetMarketStagingDetailDates() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate)
        Public Overridable Property MediaBroadcastWorksheetMarketTraffics() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketTraffic)
        Public Overridable Property MediaBroadcastWorksheetSpotMatchingSettings() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting)
        Public Overridable Property MediaBroadcastWorksheetTimeSeparationSettings() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting)
        Public Overridable Property MediaBroadcastWorksheetMarketDetailSubmarketDemos() As System.Data.Entity.DbSet(Of Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo)

        Public Overridable Property ClientCashReceiptDetailPayments() As System.Data.Entity.DbSet(Of Database.Entities.ClientCashReceiptDetailPayment)
        Public Overridable Property BillingApprovalDetails() As System.Data.Entity.DbSet(Of Database.Entities.BillingApprovalDetail)
        Public Overridable Property BillingApprovalHeaders() As System.Data.Entity.DbSet(Of Database.Entities.BillingApprovalHeader)
        Public Overridable Property BillingApprovalItems() As System.Data.Entity.DbSet(Of Database.Entities.BillingApprovalItem)
        Public Overridable Property AdvanceBillings() As System.Data.Entity.DbSet(Of Database.Entities.AdvanceBilling)
        Public Overridable Property IncomeRecognizes() As System.Data.Entity.DbSet(Of Database.Entities.IncomeRecognize)
        Public Overridable Property JobForecasts() As System.Data.Entity.DbSet(Of Database.Entities.JobForecast)
        Public Overridable Property JobForecastRevisions() As System.Data.Entity.DbSet(Of Database.Entities.JobForecastRevision)
        Public Overridable Property JobForecastJobs() As System.Data.Entity.DbSet(Of Database.Entities.JobForecastJob)
        Public Overridable Property JobForecastJobDetails() As System.Data.Entity.DbSet(Of Database.Entities.JobForecastJobDetail)
        Public Overridable Property ReportRuntimeSpecs() As System.Data.Entity.DbSet(Of Database.Entities.ReportRuntimeSpec)
        Public Overridable Property ReportRuntimeNumbers() As System.Data.Entity.DbSet(Of Database.Entities.ReportRuntimeNumber)
        Public Overridable Property POP3EmailListenerAccounts() As System.Data.Entity.DbSet(Of Database.Entities.POP3EmailListenerAccount)
        Public Overridable Property ProductMediaOverrides() As System.Data.Entity.DbSet(Of Database.Entities.ProductMediaOverrides)
        Public Overridable Property ComboInvoiceDefaults() As System.Data.Entity.DbSet(Of Database.Entities.ComboInvoiceDefault)
        Public Overridable Property InternetOrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.InternetOrderStatus)
        Public Overridable Property MagazineOrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.MagazineOrderStatus)
        Public Overridable Property NewspaperOrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.NewspaperOrderStatus)
        Public Overridable Property OutOfHomeOrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.OutOfHomeOrderStatus)
        Public Overridable Property RadioOrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.RadioOrderStatus)
        Public Overridable Property TVOrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.TVOrderStatus)
        Public Overridable Property OrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.OrderStatus)

        Public Overridable Property AccountSetupForms As System.Data.Entity.DbSet(Of Database.Entities.AccountSetupForm)
        Public Overridable Property CashReceiptPaymentTypes As System.Data.Entity.DbSet(Of Database.Entities.CashReceiptPaymentType)
        Public Overridable Property ChatMessages As System.Data.Entity.DbSet(Of Database.Entities.ChatMessage)
        Public Overridable Property ChatUsers As System.Data.Entity.DbSet(Of Database.Entities.ChatUser)
        Public Overridable Property ChatRooms As System.Data.Entity.DbSet(Of Database.Entities.ChatRoom)
        Public Overridable Property ChatActiveUsers As System.Data.Entity.DbSet(Of Database.Entities.ChatActiveUser)
        'Public Overridable Property ChatActiveRooms As System.Data.Entity.DbSet(Of Database.Entities.ChatActiveRoom)
        Public Overridable Property ConceptShareExternalReviewers As System.Data.Entity.DbSet(Of Database.Entities.ConceptShareExternalReviewer)

        Public Overridable Property CollectedCostInformations As System.Data.Entity.DbSet(Of Database.Entities.CollectedCostInformation)
        Public Overridable Property DigitalResultsViews As System.Data.Entity.DbSet(Of Database.Entities.DigitalResultsView)
        Public Overridable Property ImportClearedCheckMediaVCCStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportClearedCheckMediaVCCStaging)
        Public Overridable Property ImportClientContactStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportClientContactStaging)
        Public Overridable Property IRS1099FederalStateCodes As System.Data.Entity.DbSet(Of Database.Entities.IRS1099FederalStateCode)
        Public Overridable Property MediaManagerGeneratedReports As System.Data.Entity.DbSet(Of Database.Entities.MediaManagerGeneratedReport)
        Public Overridable Property MediaManagerGeneratedReportDetails As System.Data.Entity.DbSet(Of Database.Entities.MediaManagerGeneratedReportDetail)
        Public Overridable Property MediaManagerGeneratedReportSentInfos As System.Data.Entity.DbSet(Of Database.Entities.MediaManagerGeneratedReportSentInfo)
        Public Overridable Property MediaOrderPrintSettings As System.Data.Entity.DbSet(Of Database.Entities.MediaOrderPrintSetting)
        Public Overridable Property MediaManagerSearchSettings As System.Data.Entity.DbSet(Of Database.Entities.MediaManagerSearchSetting)
        Public Overridable Property NewspaperOtherCharges As System.Data.Entity.DbSet(Of Database.Entities.NewspaperOtherCharge)
        Public Overridable Property OrderProcessLogs As System.Data.Entity.DbSet(Of Database.Entities.OrderProcessLog)
        Public Overridable Property States As System.Data.Entity.DbSet(Of Database.Entities.State)
        Public Overridable Property VCCCards As System.Data.Entity.DbSet(Of Database.Entities.VCCCard)
        Public Overridable Property VCCCardDetails As System.Data.Entity.DbSet(Of Database.Entities.VCCCardDetail)
        Public Overridable Property VCCCardNotes As System.Data.Entity.DbSet(Of Database.Entities.VCCCardNote)
        Public Overridable Property VCCCardPOs As System.Data.Entity.DbSet(Of Database.Entities.VCCCardPO)
        Public Overridable Property VCCCardPODetails As System.Data.Entity.DbSet(Of Database.Entities.VCCCardPODetail)
        Public Overridable Property VCCCardPONotes As System.Data.Entity.DbSet(Of Database.Entities.VCCCardPONote)
        Public Overridable Property VendorContracts As System.Data.Entity.DbSet(Of Database.Entities.VendorContract)
        Public Overridable Property VendorContractContacts As System.Data.Entity.DbSet(Of Database.Entities.VendorContractContact)
        Public Overridable Property VendorContractDocuments As System.Data.Entity.DbSet(Of Database.Entities.VendorContractDocument)

        Public Overridable Property AccountExecutives As System.Data.Entity.DbSet(Of Database.Entities.AccountExecutive)
        Public Overridable Property AccountGroupDetails As System.Data.Entity.DbSet(Of Database.Entities.AccountGroupDetail)
        Public Overridable Property AccountGroups As System.Data.Entity.DbSet(Of Database.Entities.AccountGroup)
        Public Overridable Property AccountPayableGLDistributions As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableGLDistribution)
        Public Overridable Property AccountPayableInternets As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableInternet)
        Public Overridable Property AccountPayableMagazines As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableMagazine)
        Public Overridable Property AccountPayableMediaApprovals As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableMediaApproval)
        Public Overridable Property AccountPayableNewspapers As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableNewspaper)
        Public Overridable Property AccountPayableOutOfHomes As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableOutOfHome)
        Public Overridable Property AccountPayablePayments As System.Data.Entity.DbSet(Of Database.Entities.AccountPayablePayment)
        Public Overridable Property AccountPayableProductionComments As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableProductionComment)
        Public Overridable Property AccountPayableProductions As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableProduction)
        Public Overridable Property AccountPayableRadioBroadcastDetails As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableRadioBroadcastDetail)
        Public Overridable Property AccountPayableRadios As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableRadio)
        Public Overridable Property AccountPayableRecurGeneralLedgers As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableRecurGeneralLedger)
        Public Overridable Property AccountPayableRecurLogs As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableRecurLog)
        Public Overridable Property AccountPayableRecurs As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableRecur)
        Public Overridable Property AccountPayables As System.Data.Entity.DbSet(Of Database.Entities.AccountPayable)
        Public Overridable Property AccountPayableTVBroadcastDetails As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableTVBroadcastDetail)
        Public Overridable Property AccountPayableTVs As System.Data.Entity.DbSet(Of Database.Entities.AccountPayableTV)
        Public Overridable Property AccountPayableViews As System.Data.Entity.DbSet(Of Database.Views.AccountPayableView)
        Public Overridable Property AccountReceivableCollectionNotes As System.Data.Entity.DbSet(Of Database.Entities.AccountReceivableCollectionNote)
        Public Overridable Property AccountReceivableDocuments As System.Data.Entity.DbSet(Of Database.Entities.AccountReceivableDocument)
        Public Overridable Property AccountReceivableImportStagings As System.Data.Entity.DbSet(Of Database.Entities.AccountReceivableImportStaging)
        Public Overridable Property AccountReceivables As System.Data.Entity.DbSet(Of Database.Entities.AccountReceivable)
        Public Overridable Property AccountReceivableSummaries As System.Data.Entity.DbSet(Of Database.Entities.AccountReceivableSummary)
        Public Overridable Property AccountReceivableViews As System.Data.Entity.DbSet(Of Database.Views.AccountReceivableView)
        Public Overridable Property Accounts As System.Data.Entity.DbSet(Of Database.Entities.Account)
        Public Overridable Property Activities As System.Data.Entity.DbSet(Of Database.Entities.Activity)
        Public Overridable Property ActivityCompetitions As System.Data.Entity.DbSet(Of Database.Entities.ActivityCompetition)
        Public Overridable Property Ads As System.Data.Entity.DbSet(Of Database.Entities.Ad)
        Public Overridable Property AdServerPlacementFields As System.Data.Entity.DbSet(Of Database.Entities.AdServerPlacementField)
        Public Overridable Property AdServers As System.Data.Entity.DbSet(Of Database.Entities.AdServer)
        Public Overridable Property AdSizeLabels As System.Data.Entity.DbSet(Of Database.Entities.AdSizeLabel)
        Public Overridable Property AdSizes As System.Data.Entity.DbSet(Of Database.Entities.AdSize)
        Public Overridable Property AdvantageServiceExports As System.Data.Entity.DbSet(Of Database.Entities.AdvantageServiceExport)
        Public Overridable Property AdvantageServiceImports As System.Data.Entity.DbSet(Of Database.Entities.AdvantageServiceImport)
        Public Overridable Property AdvantageServiceReportSchedules As System.Data.Entity.DbSet(Of Database.Entities.AdvantageServiceReportSchedule)
        Public Overridable Property Affiliations As System.Data.Entity.DbSet(Of Database.Entities.Affiliation)
        Public Overridable Property Agencies As System.Data.Entity.DbSet(Of Database.Entities.Agency)
        Public Overridable Property AgencyClients As System.Data.Entity.DbSet(Of Database.Entities.AgencyClient)
        Public Overridable Property AgencyComments As System.Data.Entity.DbSet(Of Database.Entities.AgencyComment)
        Public Overridable Property AgencyDesktopDocuments As System.Data.Entity.DbSet(Of Database.Entities.AgencyDesktopDocument)
        Public Overridable Property AlertAssignmentTemplateDepartmentTeams As System.Data.Entity.DbSet(Of Database.Entities.AlertAssignmentTemplateDepartmentTeam)
        Public Overridable Property AlertAssignmentTemplateEmailGroups As System.Data.Entity.DbSet(Of Database.Entities.AlertAssignmentTemplateEmailGroup)
        Public Overridable Property AlertAssignmentTemplateEmployees As System.Data.Entity.DbSet(Of Database.Entities.AlertAssignmentTemplateEmployee)
        Public Overridable Property AlertAssignmentTemplateRoles As System.Data.Entity.DbSet(Of Database.Entities.AlertAssignmentTemplateRole)
        Public Overridable Property AlertAssignmentTemplates As System.Data.Entity.DbSet(Of Database.Entities.AlertAssignmentTemplate)
        Public Overridable Property AlertAssignmentTemplateStates As System.Data.Entity.DbSet(Of Database.Entities.AlertAssignmentTemplateState)
        Public Overridable Property AlertAttachments As System.Data.Entity.DbSet(Of Database.Entities.AlertAttachment)
        Public Overridable Property AlertAttachmentViews As System.Data.Entity.DbSet(Of Database.Views.AlertAttachmentView)
        Public Overridable Property AlertCategories As System.Data.Entity.DbSet(Of Database.Entities.AlertCategory)
        Public Overridable Property AlertComments As System.Data.Entity.DbSet(Of Database.Entities.AlertComment)
        Public Overridable Property AlertDocumentKeywords As System.Data.Entity.DbSet(Of Database.Entities.AlertDocumentKeyword)
        Public Overridable Property AlertDocuments As System.Data.Entity.DbSet(Of Database.Entities.AlertDocument)
        Public Overridable Property AlertGroupCategories As System.Data.Entity.DbSet(Of Database.Entities.AlertGroupCategory)
        Public Overridable Property AlertGroups As System.Data.Entity.DbSet(Of Database.Entities.AlertGroup)
        Public Overridable Property AlertRecipientDismisseds As System.Data.Entity.DbSet(Of Database.Entities.AlertRecipientDismissed)
        Public Overridable Property AlertRecipients As System.Data.Entity.DbSet(Of Database.Entities.AlertRecipient)
        Public Overridable Property Alerts As System.Data.Entity.DbSet(Of Database.Entities.Alert)
        Public Overridable Property AlertStates As System.Data.Entity.DbSet(Of Database.Entities.AlertState)
        Public Overridable Property AlertTypes As System.Data.Entity.DbSet(Of Database.Entities.AlertType)
        Public Overridable Property AlertViews As System.Data.Entity.DbSet(Of Database.Views.AlertView)
        Public Overridable Property AppVars As System.Data.Entity.DbSet(Of Database.Entities.AppVars)
        Public Overridable Property AssignNumbers As System.Data.Entity.DbSet(Of Database.Entities.AssignNumber)
        Public Overridable Property Associates As System.Data.Entity.DbSet(Of Database.Entities.Associate)
        Public Overridable Property BankExportSpecs As System.Data.Entity.DbSet(Of Database.Entities.BankExportSpec)
        Public Overridable Property Banks As System.Data.Entity.DbSet(Of Database.Entities.Bank)
        Public Overridable Property BillingCoops As System.Data.Entity.DbSet(Of Database.Entities.BillingCoop)
        Public Overridable Property BillingRateDetails As System.Data.Entity.DbSet(Of Database.Entities.BillingRateDetail)
        Public Overridable Property BillingRateDetailViews As System.Data.Entity.DbSet(Of Database.Views.BillingRateDetailView)
        Public Overridable Property BillingRateLevels As System.Data.Entity.DbSet(Of Database.Entities.BillingRateLevel)
        Public Overridable Property Blackplates As System.Data.Entity.DbSet(Of Database.Entities.Blackplate)
        Public Overridable Property BroadcastImportCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.BroadcastImportCrossReference)
        Public Overridable Property BroadcastTypes As System.Data.Entity.DbSet(Of Database.Entities.BroadcastType)
        Public Overridable Property BroadcastOrderDetailViews As System.Data.Entity.DbSet(Of Database.Views.BroadcastOrderDetailView)
        Public Overridable Property BudgetDetails As System.Data.Entity.DbSet(Of Database.Entities.BudgetDetail)
        Public Overridable Property Budgets As System.Data.Entity.DbSet(Of Database.Entities.Budget)
        Public Overridable Property CampaignDetails As System.Data.Entity.DbSet(Of Database.Entities.CampaignDetail)
        Public Overridable Property Campaigns As System.Data.Entity.DbSet(Of Database.Entities.Campaign)
        Public Overridable Property CampaignViews As System.Data.Entity.DbSet(Of Database.Views.CampaignView)
        Public Overridable Property ChecklistHeaders As System.Data.Entity.DbSet(Of Database.Entities.ChecklistHeader)
        Public Overridable Property ChecklistDetails As System.Data.Entity.DbSet(Of Database.Entities.ChecklistDetail)
        Public Overridable Property CheckRegisters As System.Data.Entity.DbSet(Of Database.Entities.CheckRegister)
        Public Overridable Property CheckWritingSelections As System.Data.Entity.DbSet(Of Database.Entities.CheckWritingSelection)
        Public Overridable Property ClientAccountsReceivableStatements As System.Data.Entity.DbSet(Of Database.Entities.ClientAccountsReceivableStatement)
        Public Overridable Property ClientCashReceiptDetails As System.Data.Entity.DbSet(Of Database.Entities.ClientCashReceiptDetail)
        Public Overridable Property ClientCashReceiptOnAccounts As System.Data.Entity.DbSet(Of Database.Entities.ClientCashReceiptOnAccount)
        Public Overridable Property ClientCashReceipts As System.Data.Entity.DbSet(Of Database.Entities.ClientCashReceipt)
        Public Overridable Property ClientContact As System.Data.Entity.DbSet(Of Database.Entities.ClientContact)
        Public Overridable Property ClientContactDetails As System.Data.Entity.DbSet(Of Database.Entities.ClientContactDetail)
        Public Overridable Property ClientCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.ClientCrossReference)
        Public Overridable Property ClientLateFees As System.Data.Entity.DbSet(Of Database.Entities.ClientLateFee)
        Public Overridable Property ClientPortalAlertRecipientDismisseds As System.Data.Entity.DbSet(Of Database.Entities.ClientPortalAlertRecipientDismissed)
        Public Overridable Property ClientPortalAlertRecipients As System.Data.Entity.DbSet(Of Database.Entities.ClientPortalAlertRecipient)
        Public Overridable Property ClientPortalAlertViews As System.Data.Entity.DbSet(Of Database.Views.ClientPortalAlertView)
        Public Overridable Property Clients As System.Data.Entity.DbSet(Of Database.Entities.Client)
        Public Overridable Property ClientSortKeys As System.Data.Entity.DbSet(Of Database.Entities.ClientSortKey)
        Public Overridable Property ClientType1s As System.Data.Entity.DbSet(Of Database.Entities.ClientType1)
        Public Overridable Property ClientType2s As System.Data.Entity.DbSet(Of Database.Entities.ClientType2)
        Public Overridable Property ClientType3s As System.Data.Entity.DbSet(Of Database.Entities.ClientType3)
        Public Overridable Property ClientWebsites As System.Data.Entity.DbSet(Of Database.Entities.ClientWebsite)
        Public Overridable Property CompanyProfileAffiliations As System.Data.Entity.DbSet(Of Database.Entities.CompanyProfileAffiliation)
        Public Overridable Property CompanyProfiles As System.Data.Entity.DbSet(Of Database.Entities.CompanyProfile)
        Public Overridable Property Competitions As System.Data.Entity.DbSet(Of Database.Entities.Competition)
        Public Overridable Property Complexities As System.Data.Entity.DbSet(Of Database.Entities.Complexity)
        Public Overridable Property ComscoreCacheDetails As System.Data.Entity.DbSet(Of Database.Entities.ComscoreCacheDetail)
        Public Overridable Property ComscoreCacheHeaders As System.Data.Entity.DbSet(Of Database.Entities.ComscoreCacheHeader)
        Public Overridable Property ComscoreGroupOwners As System.Data.Entity.DbSet(Of Database.Entities.ComscoreGroupOwner)
        Public Overridable Property ComscoreNetworks As System.Data.Entity.DbSet(Of Database.Entities.ComscoreNetwork)
        Public Overridable Property ComscoreTVBooks As System.Data.Entity.DbSet(Of Database.Entities.ComscoreTVBook)
        Public Overridable Property ComscoreTVStations As System.Data.Entity.DbSet(Of Database.Entities.ComscoreTVStation)
        Public Overridable Property ContactTypes As System.Data.Entity.DbSet(Of Database.Entities.ContactType)
        Public Overridable Property ContractContacts As System.Data.Entity.DbSet(Of Database.Entities.ContractContact)
        Public Overridable Property ContractDocuments As System.Data.Entity.DbSet(Of Database.Entities.ContractDocument)
        Public Overridable Property ContractFees As System.Data.Entity.DbSet(Of Database.Entities.ContractFee)
        Public Overridable Property ContractReports As System.Data.Entity.DbSet(Of Database.Entities.ContractReport)
        Public Overridable Property Contracts As System.Data.Entity.DbSet(Of Database.Entities.Contract)
        Public Overridable Property ContractValueAddeds As System.Data.Entity.DbSet(Of Database.Entities.ContractValueAdded)
        Public Overridable Property CoreMediaCheckExports As System.Data.Entity.DbSet(Of Database.Views.CoreMediaCheckExport)
        Public Overridable Property CreativeBriefDetails As System.Data.Entity.DbSet(Of Database.Entities.CreativeBriefDetail)
        Public Overridable Property CreativeBriefTemplates As System.Data.Entity.DbSet(Of Database.Entities.CreativeBriefTemplate)
        Public Overridable Property CreativeBriefTemplateLevel1s As System.Data.Entity.DbSet(Of Database.Entities.CreativeBriefTemplateLevel1)
        Public Overridable Property CreativeBriefTemplateLevel2s As System.Data.Entity.DbSet(Of Database.Entities.CreativeBriefTemplateLevel2)
        Public Overridable Property CreativeBriefTemplateLevel3s As System.Data.Entity.DbSet(Of Database.Entities.CreativeBriefTemplateLevel3)
        Public Overridable Property Currencies As System.Data.Entity.DbSet(Of Database.Entities.Currency)
        Public Overridable Property CurrencyCodes As System.Data.Entity.DbSet(Of Database.Entities.CurrencyCode)
        Public Overridable Property CurrencyDetails As System.Data.Entity.DbSet(Of Database.Entities.CurrencyDetail)
        Public Overridable Property CurrentJobProcessLogs As System.Data.Entity.DbSet(Of Database.Views.CurrentJobProcessLog)
        Public Overridable Property CustomNavigationTabItems As System.Data.Entity.DbSet(Of Database.Entities.CustomNavigationTabItem)
        Public Overridable Property CustomNavigationTabs As System.Data.Entity.DbSet(Of Database.Entities.CustomNavigationTab)
        Public Overridable Property CustomReports As System.Data.Entity.DbSet(Of Database.Entities.CustomReport)
        Public Overridable Property Cycles As System.Data.Entity.DbSet(Of Database.Entities.Cycle)
        Public Overridable Property Dashboards As System.Data.Entity.DbSet(Of Database.Entities.Dashboard)
        Public Overridable Property DataGridViewColumns As System.Data.Entity.DbSet(Of Database.Entities.DataGridViewColumn)
        Public Overridable Property DataGridViewColumnUserSettings As System.Data.Entity.DbSet(Of Database.Entities.DataGridViewColumnUserSetting)
        Public Overridable Property DataGridViews As System.Data.Entity.DbSet(Of Database.Entities.DataGridView)
        Public Overridable Property DaypartTypes As System.Data.Entity.DbSet(Of Database.Entities.DaypartType)
        Public Overridable Property Dayparts As System.Data.Entity.DbSet(Of Database.Entities.Daypart)
        Public Overridable Property DepartmentTeams As System.Data.Entity.DbSet(Of Database.Entities.DepartmentTeam)
        Public Overridable Property DestinationContacts As System.Data.Entity.DbSet(Of Database.Entities.DestinationContact)
        Public Overridable Property Destinations As System.Data.Entity.DbSet(Of Database.Entities.Destination)
        Public Overridable Property DigitalResults As System.Data.Entity.DbSet(Of Database.Entities.DigitalResult)
        Public Overridable Property Divisions As System.Data.Entity.DbSet(Of Database.Entities.Division)
        Public Overridable Property DivisionSortKeys As System.Data.Entity.DbSet(Of Database.Entities.DivisionSortKey)
        Public Overridable Property DivisionViews As System.Data.Entity.DbSet(Of Database.Views.DivisionView)
        Public Overridable Property DocumentComments As System.Data.Entity.DbSet(Of Database.Entities.DocumentComment)
        Public Overridable Property Documents As System.Data.Entity.DbSet(Of Database.Entities.Document)
        Public Overridable Property DocumentTypes As System.Data.Entity.DbSet(Of Database.Entities.DocumentType)
        Public Overridable Property EmployeeAdditionalEmails As System.Data.Entity.DbSet(Of Database.Entities.EmployeeAdditionalEmail)
        Public Overridable Property EmployeeCategories As System.Data.Entity.DbSet(Of Database.Entities.EmployeeCategory)
        Public Overridable Property EmployeeDepartments As System.Data.Entity.DbSet(Of Database.Entities.EmployeeDepartment)
        Public Overridable Property EmployeeNonTasks As System.Data.Entity.DbSet(Of Database.Entities.EmployeeNonTask)
        Public Overridable Property EmployeeOffices As System.Data.Entity.DbSet(Of Database.Entities.EmployeeOffice)
        Public Overridable Property EmployeePictures As System.Data.Entity.DbSet(Of Database.Entities.EmployeePicture)
        Public Overridable Property EmployeeRateHistories As System.Data.Entity.DbSet(Of Database.Entities.EmployeeRateHistory)
        Public Overridable Property EmployeeRoles As System.Data.Entity.DbSet(Of Database.Entities.EmployeeRole)
        Public Overridable Property Employees As System.Data.Entity.DbSet(Of Database.Views.Employee)
        Public Overridable Property EmployeeStandardHours As System.Data.Entity.DbSet(Of Database.Entities.EmployeeStandardHours)
        Public Overridable Property EmployeeStandardHoursDetails As System.Data.Entity.DbSet(Of Database.Entities.EmployeeStandardHoursDetail)
        Public Overridable Property EmployeeTimeComments As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeComment)
        Public Overridable Property EmployeeTimeDetails As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeDetail)
        Public Overridable Property EmployeeTimeForecastOfficeDetailAlternateEmployees As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailEmployees As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategories As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentEmployees As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property EmployeeTimeForecastOfficeDetails As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
        Public Overridable Property EmployeeTimeForecasts As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeForecast)
        Public Overridable Property EmployeeTimeIndirects As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeIndirect)
        Public Overridable Property EmployeeTimes As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTime)
        Public Overridable Property EmployeeTimesheetFunctions As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimesheetFunction)
        Public Overridable Property EmployeeTimeStagings As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeStaging)
        Public Overridable Property EmployeeTimeStagingsIDs As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeStagingIDs)
        Public Overridable Property EmployeeTimeTemplates As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTimeTemplate)
        Public Overridable Property EmployeeTimeTotalsByOfficeClients As System.Data.Entity.DbSet(Of Database.Views.EmployeeTimeTotalsByOfficeClient)
        Public Overridable Property EmployeeTitles As System.Data.Entity.DbSet(Of Database.Entities.EmployeeTitle)
        Public Overridable Property EstimateApprovals As System.Data.Entity.DbSet(Of Database.Views.EstimateApproval)
        Public Overridable Property EstimateComments As System.Data.Entity.DbSet(Of Database.Views.EstimateComment)
        Public Overridable Property EstimateFunctionComments As System.Data.Entity.DbSet(Of Database.Views.EstimateFunctionComment)
        Public Overridable Property EstimateProcessingOptions As System.Data.Entity.DbSet(Of Database.Entities.EstimateProcessingOption)
        Public Overridable Property EstimateRevisionDetails As System.Data.Entity.DbSet(Of Database.Entities.EstimateRevisionDetail)
        Public Overridable Property EstimateRevisions As System.Data.Entity.DbSet(Of Database.Entities.EstimateRevision)
        Public Overridable Property EstimateTemplates As System.Data.Entity.DbSet(Of Database.Entities.EstimateTemplate)
        Public Overridable Property ETFOfficeDetailIndirectCategories As System.Data.Entity.DbSet(Of Database.Views.ETFOfficeDetailIndirectCategory)
        Public Overridable Property ETFOfficeDetailIndirectCategoryAlternateEmployees As System.Data.Entity.DbSet(Of Database.Views.ETFOfficeDetailIndirectCategoryAlternateEmployee)
        Public Overridable Property ETFOfficeDetailIndirectCategoryEmployees As System.Data.Entity.DbSet(Of Database.Views.ETFOfficeDetailIndirectCategoryEmployee)
        Public Overridable Property ETFOfficeDetailJobComponentAlternateEmployees As System.Data.Entity.DbSet(Of Database.Views.ETFOfficeDetailJobComponentAlternateEmployee)
        Public Overridable Property ETFOfficeDetailJobComponentEmployees As System.Data.Entity.DbSet(Of Database.Views.ETFOfficeDetailJobComponentEmployee)
        Public Overridable Property ETFOfficeDetailJobComponents As System.Data.Entity.DbSet(Of Database.Views.ETFOfficeDetailJobComponent)
        Public Overridable Property ExecutiveDesktopDocuments As System.Data.Entity.DbSet(Of Database.Entities.ExecutiveDesktopDocument)
        Public Overridable Property ExpenseDetailDocuments As System.Data.Entity.DbSet(Of Database.Entities.ExpenseDetailDocument)
        Public Overridable Property ExpenseReportDetails As System.Data.Entity.DbSet(Of Database.Entities.ExpenseReportDetail)
        Public Overridable Property ExpenseReportDocuments As System.Data.Entity.DbSet(Of Database.Entities.ExpenseReportDocument)
        Public Overridable Property ExpenseReportDocumentUnassigneds As System.Data.Entity.DbSet(Of Database.Entities.ExpenseReportDocumentUnassigned)
        Public Overridable Property ExpenseReports As System.Data.Entity.DbSet(Of Database.Entities.ExpenseReport)
        Public Overridable Property ExpenseSummarys As System.Data.Entity.DbSet(Of Database.Views.ExpenseSummary)
        Public Overridable Property ExportSystems As System.Data.Entity.DbSet(Of Database.Entities.ExportSystem)
        Public Overridable Property ExportTemplateDetails As System.Data.Entity.DbSet(Of Database.Entities.ExportTemplateDetail)
        Public Overridable Property ExportTemplates As System.Data.Entity.DbSet(Of Database.Entities.ExportTemplate)
        Public Overridable Property ExternalGLIFaces As System.Data.Entity.DbSet(Of Database.Entities.ExternalGLIFace)
        Public Overridable Property FiscalPeriods As System.Data.Entity.DbSet(Of Database.Entities.FiscalPeriod)
        Public Overridable Property FunctionHeadings As System.Data.Entity.DbSet(Of Database.Entities.FunctionHeading)
        Public Overridable Property Functions As System.Data.Entity.DbSet(Of Database.Entities.[Function])
        Public Overridable Property FunctionViews As System.Data.Entity.DbSet(Of Database.Views.FunctionView)
        Public Overridable Property GeneralDescriptions As System.Data.Entity.DbSet(Of Database.Entities.GeneralDescription)
        Public Overridable Property GeneralLedgerAccounts As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerAccount)
        Public Overridable Property GeneralLedgerConfigs As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerConfig)
        Public Overridable Property GeneralLedgerCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerCrossReference)
        Public Overridable Property GeneralLedgerDepartmentTeamCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)
        Public Overridable Property GeneralLedgerDetails As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerDetail)
        Public Overridable Property GeneralLedgerExternalGLIFaceCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerExternalGLIFaceCrossReference)
        Public Overridable Property GeneralLedgerMappingExportTargetAccounts As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerMappingExportTargetAccount)
        Public Overridable Property GeneralLedgerMappingExportGLAccounts As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerMappingExportGLAccount)
        Public Overridable Property GeneralLedgerOfficeCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerOfficeCrossReference)
        Public Overridable Property GeneralLedgers As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedger)
        Public Overridable Property GeneralLedgerSources As System.Data.Entity.DbSet(Of Database.Entities.GeneralLedgerSource)
        Public Overridable Property GLAllocations As System.Data.Entity.DbSet(Of Database.Entities.GLAllocation)
        Public Overridable Property GLASummaryDatas As System.Data.Entity.DbSet(Of Database.Entities.GLASummaryData)
        Public Overridable Property GLATrailers As System.Data.Entity.DbSet(Of Database.Entities.GLATrailer)
        Public Overridable Property GLReportTemplateColumns As System.Data.Entity.DbSet(Of Database.Entities.GLReportTemplateColumn)
        Public Overridable Property GLReportTemplateDepartmentTeamPresets As System.Data.Entity.DbSet(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)
        Public Overridable Property GLReportTemplateOfficePresets As System.Data.Entity.DbSet(Of Database.Entities.GLReportTemplateOfficePreset)
        Public Overridable Property GLReportTemplatePctOfRowColumnRelations As System.Data.Entity.DbSet(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)
        Public Overridable Property GLReportTemplateRowRelations As System.Data.Entity.DbSet(Of Database.Entities.GLReportTemplateRowRelation)
        Public Overridable Property GLReportTemplateRows As System.Data.Entity.DbSet(Of Database.Entities.GLReportTemplateRow)
        Public Overridable Property GLReportTemplates As System.Data.Entity.DbSet(Of Database.Entities.GLReportTemplate)
        Public Overridable Property GLReportUserDefReports As System.Data.Entity.DbSet(Of Database.Entities.GLReportUserDefReport)
        Public Overridable Property GLTemplates As System.Data.Entity.DbSet(Of Database.Entities.GLTemplate)
        Public Overridable Property IDs As System.Data.Entity.DbSet(Of Database.Entities.ID)
        Public Overridable Property Images As System.Data.Entity.DbSet(Of Database.Entities.Image)
        Public Overridable Property ImportAccountPayableBroadcastDetails As System.Data.Entity.DbSet(Of Database.Entities.ImportAccountPayableBroadcastDetail)
        Public Overridable Property ImportAccountPayableErrors As System.Data.Entity.DbSet(Of Database.Entities.ImportAccountPayableError)
        Public Overridable Property ImportAccountPayableGLs As System.Data.Entity.DbSet(Of Database.Entities.ImportAccountPayableGL)
        Public Overridable Property ImportAccountPayableJobs As System.Data.Entity.DbSet(Of Database.Entities.ImportAccountPayableJob)
        Public Overridable Property ImportAccountPayableMedias As System.Data.Entity.DbSet(Of Database.Entities.ImportAccountPayableMedia)
        Public Overridable Property ImportAccountPayables As System.Data.Entity.DbSet(Of Database.Entities.ImportAccountPayable)
        Public Overridable Property ImportClearedChecksStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportClearedChecksStaging)
        Public Overridable Property ImportDigitalResultsStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportDigitalResultsStaging)
        Public Overridable Property ImportClientStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportClientStaging)
        Public Overridable Property ImportCreditCardStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportCreditCardStaging)
        Public Overridable Property ImportDivisionStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportDivisionStaging)
        Public Overridable Property ImportEmployeeHoursStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportEmployeeHoursStaging)
        Public Overridable Property ImportEmployeeStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportEmployeeStaging)
        Public Overridable Property ImportFunctionStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportFunctionStaging)
        Public Overridable Property ImportGeneralLedgerAccountStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportGeneralLedgerAccountStaging)
        Public Overridable Property ImportJournalEntrys As System.Data.Entity.DbSet(Of Database.Entities.ImportJournalEntry)
        Public Overridable Property ImportJournalEntryDetails As System.Data.Entity.DbSet(Of Database.Entities.ImportJournalEntryDetail)
        Public Overridable Property ImportProductStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportProductStaging)
        Public Overridable Property ImportTemplateDetails As System.Data.Entity.DbSet(Of Database.Entities.ImportTemplateDetail)
        Public Overridable Property ImportTemplates As System.Data.Entity.DbSet(Of Database.Entities.ImportTemplate)
        Public Overridable Property ImportVendorStagings As System.Data.Entity.DbSet(Of Database.Entities.ImportVendorStaging)
        Public Overridable Property IncomeOnlys As System.Data.Entity.DbSet(Of Database.Entities.IncomeOnly)
        Public Overridable Property IndirectCategories As System.Data.Entity.DbSet(Of Database.Entities.IndirectCategory)
        Public Overridable Property Industries As System.Data.Entity.DbSet(Of Database.Entities.Industry)
        Public Overridable Property InternetOrderDetails As System.Data.Entity.DbSet(Of Database.Entities.InternetOrderDetail)
        Public Overridable Property InternetOrders As System.Data.Entity.DbSet(Of Database.Entities.InternetOrder)
        Public Overridable Property InternetPackageDetails As System.Data.Entity.DbSet(Of Database.Entities.InternetPackageDetail)
        Public Overridable Property InternetTypes As System.Data.Entity.DbSet(Of Database.Entities.InternetType)
        Public Overridable Property InvoiceCategories As System.Data.Entity.DbSet(Of Database.Entities.InvoiceCategory)
        Public Overridable Property InvoiceJobComments As System.Data.Entity.DbSet(Of Database.Views.InvoiceJobComment)
        Public Overridable Property InvoiceJobFunctionComments As System.Data.Entity.DbSet(Of Database.Views.InvoiceJobFunctionComment)
        Public Overridable Property InvoiceMatchingSettings As System.Data.Entity.DbSet(Of Database.Entities.InvoiceMatchingSetting)
        Public Overridable Property JobComponents As System.Data.Entity.DbSet(Of Database.Entities.JobComponent)
        Public Overridable Property JobComponentTaskEmployees As System.Data.Entity.DbSet(Of Database.Entities.JobComponentTaskEmployee)
        Public Overridable Property JobComponentTaskPredecessors As System.Data.Entity.DbSet(Of Database.Entities.JobComponentTaskPredecessor)
        Public Overridable Property JobComponentTasks As System.Data.Entity.DbSet(Of Database.Entities.JobComponentTask)
        Public Overridable Property JobComponentTaskClientContacts As System.Data.Entity.DbSet(Of Database.Entities.JobComponentTaskClientContact)
        Public Overridable Property JobComponentUserDefinedValue1 As System.Data.Entity.DbSet(Of Database.Entities.JobComponentUserDefinedValue1)
        Public Overridable Property JobComponentUserDefinedValue2 As System.Data.Entity.DbSet(Of Database.Entities.JobComponentUserDefinedValue2)
        Public Overridable Property JobComponentUserDefinedValue3 As System.Data.Entity.DbSet(Of Database.Entities.JobComponentUserDefinedValue3)
        Public Overridable Property JobComponentUserDefinedValue4 As System.Data.Entity.DbSet(Of Database.Entities.JobComponentUserDefinedValue4)
        Public Overridable Property JobComponentUserDefinedValue5 As System.Data.Entity.DbSet(Of Database.Entities.JobComponentUserDefinedValue5)
        Public Overridable Property JobComponentViews As System.Data.Entity.DbSet(Of Database.Views.JobComponentView)
        Public Overridable Property JobProcessLogs As System.Data.Entity.DbSet(Of Database.Entities.JobProcessLog)
        Public Overridable Property Jobs As System.Data.Entity.DbSet(Of Database.Entities.Job)
        Public Overridable Property JobServiceFees As System.Data.Entity.DbSet(Of Database.Entities.JobServiceFee)
        Public Overridable Property JobSpecificationCategories As System.Data.Entity.DbSet(Of Database.Entities.JobSpecificationCategory)
        Public Overridable Property JobSpecificationFields As System.Data.Entity.DbSet(Of Database.Entities.JobSpecificationField)
        Public Overridable Property JobSpecificationTypes As System.Data.Entity.DbSet(Of Database.Entities.JobSpecificationType)
        Public Overridable Property JobSpecificationVendorTabs As System.Data.Entity.DbSet(Of Database.Entities.JobSpecificationVendorTab)
        Public Overridable Property JobTemplates As System.Data.Entity.DbSet(Of Database.Entities.JobTemplate)
        Public Overridable Property JobTemplateDetails As System.Data.Entity.DbSet(Of Database.Entities.JobTemplateDetail)
        Public Overridable Property JobTemplateItems As System.Data.Entity.DbSet(Of Database.Entities.JobTemplateItem)
        Public Overridable Property JobTraffic As System.Data.Entity.DbSet(Of Database.Entities.JobTraffic)
        Public Overridable Property JobTrafficPredecessor As System.Data.Entity.DbSet(Of Database.Entities.JobTrafficPredecessors)
        Public Overridable Property JobTrafficSetupDetails As System.Data.Entity.DbSet(Of Database.Entities.JobTrafficSetupDetail)
        Public Overridable Property JobTrafficSetupItems As System.Data.Entity.DbSet(Of Database.Entities.JobTrafficSetupItem)
        Public Overridable Property JobTrafficTemplates As System.Data.Entity.DbSet(Of Database.Entities.JobTrafficTemplate)
        Public Overridable Property JobTrafficVersions As System.Data.Entity.DbSet(Of Database.Entities.JobTrafficVersion)
        Public Overridable Property JobTypes As System.Data.Entity.DbSet(Of Database.Entities.JobType)
        Public Overridable Property JobUserDefinedValue1 As System.Data.Entity.DbSet(Of Database.Entities.JobUserDefinedValue1)
        Public Overridable Property JobUserDefinedValue2 As System.Data.Entity.DbSet(Of Database.Entities.JobUserDefinedValue2)
        Public Overridable Property JobUserDefinedValue3 As System.Data.Entity.DbSet(Of Database.Entities.JobUserDefinedValue3)
        Public Overridable Property JobUserDefinedValue4 As System.Data.Entity.DbSet(Of Database.Entities.JobUserDefinedValue4)
        Public Overridable Property JobUserDefinedValue5 As System.Data.Entity.DbSet(Of Database.Entities.JobUserDefinedValue5)
        Public Overridable Property JobVersionDatabaseTypes As System.Data.Entity.DbSet(Of Database.Entities.JobVersionDatabaseType)
        Public Overridable Property JobVersionTemplateDetails As System.Data.Entity.DbSet(Of Database.Entities.JobVersionTemplateDetail)
        Public Overridable Property JobVersionTemplates As System.Data.Entity.DbSet(Of Database.Entities.JobVersionTemplate)
        Public Overridable Property JobViews As System.Data.Entity.DbSet(Of Database.Views.JobView)
        Public Overridable Property LocationLogos As System.Data.Entity.DbSet(Of Database.Entities.LocationLogo)
        Public Overridable Property LocationLogoTypes As System.Data.Entity.DbSet(Of Database.Entities.LocationLogoType)
        Public Overridable Property MagazineDetails As System.Data.Entity.DbSet(Of Database.Views.MagazineDetail)
        Public Overridable Property MagazineOrderDetails As System.Data.Entity.DbSet(Of Database.Entities.MagazineOrderDetail)
        Public Overridable Property MagazineOrders As System.Data.Entity.DbSet(Of Database.Entities.MagazineOrder)
        Public Overridable Property Magazines As System.Data.Entity.DbSet(Of Database.Views.Magazine)
        Public Overridable Property ManagementLevels As System.Data.Entity.DbSet(Of Database.Entities.ManagementLevel)
        Public Overridable Property MarketBreaks As System.Data.Entity.DbSet(Of Database.Entities.MarketBreak)
        Public Overridable Property Markets As System.Data.Entity.DbSet(Of Database.Entities.Market)
        Public Overridable Property MediaATBRevisionDetails As System.Data.Entity.DbSet(Of Database.Entities.MediaATBRevisionDetail)
        Public Overridable Property MediaATBRevisions As System.Data.Entity.DbSet(Of Database.Entities.MediaATBRevision)
        Public Overridable Property MediaATBs As System.Data.Entity.DbSet(Of Database.Entities.MediaATB)
        Public Overridable Property MediaBuyers As System.Data.Entity.DbSet(Of Database.Entities.MediaBuyer)
        Public Overridable Property MediaChannels As System.Data.Entity.DbSet(Of Database.Entities.MediaChannel)
        Public Overridable Property MediaDemographicDetails As System.Data.Entity.DbSet(Of Database.Entities.MediaDemographicDetail)
        Public Overridable Property MediaDemographics As System.Data.Entity.DbSet(Of Database.Entities.MediaDemographic)
        Public Overridable Property MediaInvoiceDefaults As System.Data.Entity.DbSet(Of Database.Entities.MediaInvoiceDefault)
        Public Overridable Property MediaManagerGeneratedPOReports As System.Data.Entity.DbSet(Of Database.Entities.MediaManagerGeneratedPOReport)
        Public Overridable Property MediaMetrics As System.Data.Entity.DbSet(Of Database.Entities.MediaMetric)
        Public Overridable Property MediaOrders As System.Data.Entity.DbSet(Of Database.Views.MediaOrder)
        Public Overridable Property MediaPlanDatas As System.Data.Entity.DbSet(Of Database.Views.MediaPlanData)
        Public Overridable Property MediaPlanDetailChangeLogs As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailChangeLog)
        Public Overridable Property MediaPlanDetailFields As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailField)
        Public Overridable Property MediaPlanFlowChartOptions As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanFlowChartOptions)
        Public Overridable Property MediaPlanDetailLevelLineDatas As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailLevelLineData)
        Public Overridable Property MediaPlanDetailLevelLines As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailLevelLine)
        Public Overridable Property MediaPlanDetailLevelLineTags As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailLevelLineTag)
        Public Overridable Property MediaPlanDetailLevels As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailLevel)
        Public Overridable Property MediaPlanDetails As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetail)
        Public Overridable Property MediaPlanDetailSettings As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailSetting)
        Public Overridable Property MediaPlanMasterPlanDetails As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanMasterPlanDetail)
        Public Overridable Property MediaPlanMasterPlans As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanMasterPlan)
        Public Overridable Property MediaPlans As System.Data.Entity.DbSet(Of Database.Entities.MediaPlan)
        Public Overridable Property MediaPlanDetailPackageDetails As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailPackageDetail)
        Public Overridable Property MediaPlanDetailPackagePlacementNames As System.Data.Entity.DbSet(Of Database.Entities.MediaPlanDetailPackagePlacementName)
        Public Overridable Property MediaRFPAvailLines As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPAvailLine)
        Public Overridable Property MediaRFPAvailLineSpots As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPAvailLineSpot)
        Public Overridable Property MediaRFPDemos As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPDemo)
        Public Overridable Property MediaRFPHeaders As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPHeader)
        Public Overridable Property MediaRFPHeaderStatuses As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPHeaderStatus)
        Public Overridable Property MediaRFPMarketCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPMarketCrossReference)
        Public Overridable Property MediaRFPPrintSettings As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPPrintSetting)
        Public Overridable Property MediaRFPStatuses As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPStatus)
        Public Overridable Property MediaRFPVendorDaypartCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPVendorDaypartCrossReference)
        Public Overridable Property MediaRFPVendorMarketCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.MediaRFPVendorMarketCrossReference)
        Public Overridable Property MediaSpecsDetails As System.Data.Entity.DbSet(Of Database.Entities.MediaSpecsDetail)
        Public Overridable Property MediaSpecsHeaders As System.Data.Entity.DbSet(Of Database.Entities.MediaSpecsHeader)
        Public Overridable Property MediaSpotRadioCountyResearchs As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioCountyResearch)
        Public Overridable Property MediaSpotRadioCountyResearchMetrics As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioCountyResearchMetric)
        Public Overridable Property MediaSpotRadioCountyResearchStations As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioCountyResearchStation)
        Public Overridable Property MediaSpotRadioCountyResearchYears As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioCountyResearchYear)
        Public Overridable Property MediaSpotRadioResearchs As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioResearch)
        Public Overridable Property MediaSpotRadioResearchBooks As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioResearchBook)
        Public Overridable Property MediaSpotRadioResearchDayparts As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioResearchDaypart)
        Public Overridable Property MediaSpotRadioResearchMetrics As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioResearchMetric)
        Public Overridable Property MediaSpotRadioResearchStations As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotRadioResearchStation)
        Public Overridable Property MediaSpotTVResearchs As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVResearch)
        Public Overridable Property MediaSpotTVResearchBooks As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVResearchBook)
        Public Overridable Property MediaSpotTVResearchDayTimes As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVResearchDayTime)
        Public Overridable Property MediaSpotTVResearchDemos As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVResearchDemo)
        Public Overridable Property MediaSpotTVResearchMetrics As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVResearchMetric)
        Public Overridable Property MediaSpotTVResearchStations As System.Data.Entity.DbSet(Of Database.Entities.MediaSpotTVResearchStation)
        Public Overridable Property MediaTactics As System.Data.Entity.DbSet(Of Database.Entities.MediaTactic)
        Public Overridable Property MediaTrafficCreativeGroups As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficCreativeGroup)
        Public Overridable Property MediaTrafficDetailDocuments As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficDetailDocument)
        Public Overridable Property MediaTrafficDetails As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficDetail)
        Public Overridable Property MediaTrafficPrintSettings As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficPrintSetting)
        Public Overridable Property MediaTrafficRevisions As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficRevision)
        Public Overridable Property MediaTraffics As System.Data.Entity.DbSet(Of Database.Entities.MediaTraffic)
        Public Overridable Property MediaTrafficStatuses As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficStatus)
        Public Overridable Property MediaTrafficVendorCreativeGroups As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficVendorCreativeGroup)
        Public Overridable Property MediaTrafficVendors As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficVendor)
        Public Overridable Property MediaTrafficVendorStatuses As System.Data.Entity.DbSet(Of Database.Entities.MediaTrafficVendorStatus)
        Public Overridable Property MyObjectDefinitionAvailableOptions As System.Data.Entity.DbSet(Of Database.Entities.MyObjectDefinitionAvailableOption)
        Public Overridable Property MyObjectDefinitionObjects As System.Data.Entity.DbSet(Of Database.Entities.MyObjectDefinitionObject)
        Public Overridable Property MyObjectDefinitionSettings As System.Data.Entity.DbSet(Of Database.Entities.MyObjectDefinitionSetting)
        Public Overridable Property MyObjectDefinitionStaticOptions As System.Data.Entity.DbSet(Of Database.Entities.MyObjectDefinitionStaticOption)
        Public Overridable Property NationalUniverses As System.Data.Entity.DbSet(Of Database.Entities.NationalUniverse)
        Public Overridable Property NewspaperDetails As System.Data.Entity.DbSet(Of Database.Views.NewspaperDetail)
        Public Overridable Property NewspaperHeaders As System.Data.Entity.DbSet(Of Database.Views.NewspaperHeader)
        Public Overridable Property NewspaperOrderDetails As System.Data.Entity.DbSet(Of Database.Entities.NewspaperOrderDetail)
        Public Overridable Property NewspaperOrders As System.Data.Entity.DbSet(Of Database.Entities.NewspaperOrder)
        Public Overridable Property NielsenDemographics As System.Data.Entity.DbSet(Of Database.Entities.NielsenDemographic)
        Public Overridable Property NielsenMarkets As System.Data.Entity.DbSet(Of Database.Entities.NielsenMarket)
        Public Overridable Property OfficeDocuments As System.Data.Entity.DbSet(Of Database.Entities.OfficeDocument)
        Public Overridable Property OfficeFunctionAccounts As System.Data.Entity.DbSet(Of Database.Entities.OfficeFunctionAccount)
        Public Overridable Property OfficeInterCompanies As System.Data.Entity.DbSet(Of Database.Entities.OfficeInterCompany)
        Public Overridable Property Offices As System.Data.Entity.DbSet(Of Database.Entities.Office)
        Public Overridable Property OfficeSalesClassAccounts As System.Data.Entity.DbSet(Of Database.Entities.OfficeSalesClassAccount)
        Public Overridable Property OfficeSalesClassFunctionAccounts As System.Data.Entity.DbSet(Of Database.Entities.OfficeSalesClassFunctionAccount)
        Public Overridable Property OfficeSalesTaxAccounts As System.Data.Entity.DbSet(Of Database.Entities.OfficeSalesTaxAccount)
        Public Overridable Property OtherCashReceiptDetails As System.Data.Entity.DbSet(Of Database.Entities.OtherCashReceiptDetail)
        Public Overridable Property OtherCashReceipts As System.Data.Entity.DbSet(Of Database.Entities.OtherCashReceipt)
        Public Overridable Property OutOfHomeOrderDetails As System.Data.Entity.DbSet(Of Database.Entities.OutOfHomeOrderDetail)
        Public Overridable Property OutOfHomeOrders As System.Data.Entity.DbSet(Of Database.Entities.OutOfHomeOrder)
        Public Overridable Property OutOfHomeTypes As System.Data.Entity.DbSet(Of Database.Entities.OutOfHomeType)
        Public Overridable Property OverheadAccounts As System.Data.Entity.DbSet(Of Database.Entities.OverheadAccount)
        Public Overridable Property PartnerAllocationDetails As System.Data.Entity.DbSet(Of Database.Entities.PartnerAllocationDetail)
        Public Overridable Property PartnerAllocations As System.Data.Entity.DbSet(Of Database.Entities.PartnerAllocation)
        Public Overridable Property Partners As System.Data.Entity.DbSet(Of Database.Entities.Partner)
        Public Overridable Property Phases As System.Data.Entity.DbSet(Of Database.Entities.Phase)
        Public Overridable Property POApprovals As System.Data.Entity.DbSet(Of Database.Entities.POApproval)
        Public Overridable Property PostPeriods As System.Data.Entity.DbSet(Of Database.Entities.PostPeriod)
        Public Overridable Property PrintSpecRegions As System.Data.Entity.DbSet(Of Database.Entities.PrintSpecRegion)
        Public Overridable Property PrintSpecStatuses As System.Data.Entity.DbSet(Of Database.Entities.PrintSpecStatus)
        Public Overridable Property ProductAccountsReceivableStatements As System.Data.Entity.DbSet(Of Database.Entities.ProductAccountsReceivableStatement)
        Public Overridable Property ProductCategories As System.Data.Entity.DbSet(Of Database.Entities.ProductCategory)
        Public Overridable Property ProductionInvoiceDefaults As System.Data.Entity.DbSet(Of Database.Entities.ProductionInvoiceDefault)
        Public Overridable Property Products As System.Data.Entity.DbSet(Of Database.Entities.Product)
        Public Overridable Property ProductSortKeys As System.Data.Entity.DbSet(Of Database.Entities.ProductSortKey)
        Public Overridable Property ProductViews As System.Data.Entity.DbSet(Of Database.Views.ProductView)
        Public Overridable Property PromotionTypes As System.Data.Entity.DbSet(Of Database.Entities.PromotionType)
        Public Overridable Property PTORuleDetails As System.Data.Entity.DbSet(Of Database.Entities.PTORuleDetail)
        Public Overridable Property PTORules As System.Data.Entity.DbSet(Of Database.Entities.PTORule)
        Public Overridable Property PurchaseOrderApprovalRuleDetails As System.Data.Entity.DbSet(Of Database.Entities.PurchaseOrderApprovalRuleDetail)
        Public Overridable Property PurchaseOrderApprovalRuleEmployees As System.Data.Entity.DbSet(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)
        Public Overridable Property PurchaseOrderApprovalRules As System.Data.Entity.DbSet(Of Database.Entities.PurchaseOrderApprovalRule)
        Public Overridable Property PurchaseOrderDetails As System.Data.Entity.DbSet(Of Database.Entities.PurchaseOrderDetail)
        Public Overridable Property PurchaseOrderDocuments() As System.Data.Entity.DbSet(Of Database.Entities.PurchaseOrderDocument)
        Public Overridable Property PurchaseOrderPrintDefaults As System.Data.Entity.DbSet(Of Database.Entities.PurchaseOrderPrintDefault)
        Public Overridable Property PurchaseOrderStatuses() As System.Data.Entity.DbSet(Of Database.Entities.PurchaseOrderStatus)
        Public Overridable Property PurchaseOrders As System.Data.Entity.DbSet(Of Database.Entities.PurchaseOrder)
        Public Overridable Property RadioOrderDetailLegacies As System.Data.Entity.DbSet(Of Database.Entities.RadioOrderDetailLegacy)
        Public Overridable Property RadioOrderDetails As System.Data.Entity.DbSet(Of Database.Entities.RadioOrderDetail)
        Public Overridable Property RadioOrderLegacies As System.Data.Entity.DbSet(Of Database.Entities.RadioOrderLegacy)
        Public Overridable Property RadioOrders As System.Data.Entity.DbSet(Of Database.Entities.RadioOrder)
        Public Overridable Property RateCardColorCharges As System.Data.Entity.DbSet(Of Database.Entities.RateCardColorCharge)
        Public Overridable Property RateCardDetails As System.Data.Entity.DbSet(Of Database.Entities.RateCardDetail)
        Public Overridable Property RateCards As System.Data.Entity.DbSet(Of Database.Entities.RateCard)
        Public Overridable Property Ratings As System.Data.Entity.DbSet(Of Database.Entities.Rating)
        Public Overridable Property RatingsServices As System.Data.Entity.DbSet(Of Database.Entities.RatingsService)
        Public Overridable Property RecordSources As System.Data.Entity.DbSet(Of Database.Entities.RecordSource)
        Public Overridable Property Resources As System.Data.Entity.DbSet(Of Database.Entities.Resource)
        Public Overridable Property ResourceTasks As System.Data.Entity.DbSet(Of Database.Entities.ResourceTask)
        Public Overridable Property ResourceTypes As System.Data.Entity.DbSet(Of Database.Entities.ResourceType)
        Public Overridable Property Roles As System.Data.Entity.DbSet(Of Database.Entities.Role)
        Public Overridable Property SalesClasses As System.Data.Entity.DbSet(Of Database.Entities.SalesClass)
        Public Overridable Property SalesClassFormats As System.Data.Entity.DbSet(Of Database.Entities.SalesClassFormat)
        Public Overridable Property SalesTaxes As System.Data.Entity.DbSet(Of Database.Entities.SalesTax)
        Public Overridable Property ServiceFeeReconcileDetails As System.Data.Entity.DbSet(Of Database.Views.ServiceFeeReconcileDetail)
        Public Overridable Property ServiceFeeTypes As System.Data.Entity.DbSet(Of Database.Entities.ServiceFeeType)
        Public Overridable Property Sources As System.Data.Entity.DbSet(Of Database.Entities.Source)
        Public Overridable Property Specialties As System.Data.Entity.DbSet(Of Database.Entities.Specialty)
        Public Overridable Property StandardComments As System.Data.Entity.DbSet(Of Database.Entities.StandardComment)
        Public Overridable Property Status As System.Data.Entity.DbSet(Of Database.Entities.Status)
        Public Overridable Property Tasks As System.Data.Entity.DbSet(Of Database.Entities.Task)
        Public Overridable Property TaskTemplates As System.Data.Entity.DbSet(Of Database.Entities.TaskTemplate)
        Public Overridable Property TimeCategoryTypes As System.Data.Entity.DbSet(Of Database.Entities.TimeCategoryType)
        Public Overridable Property TimeRuleLogs As System.Data.Entity.DbSet(Of Database.Entities.TimeRuleLog)
        Public Overridable Property TimeSeparationSettings As System.Data.Entity.DbSet(Of Database.Entities.TimeSeparationSetting)
        Public Overridable Property TVOrderDetailLegacies As System.Data.Entity.DbSet(Of Database.Entities.TVOrderDetailLegacy)
        Public Overridable Property TVOrderDetails As System.Data.Entity.DbSet(Of Database.Entities.TVOrderDetail)
        Public Overridable Property TVOrderLegacies As System.Data.Entity.DbSet(Of Database.Entities.TVOrderLegacy)
        Public Overridable Property TVOrders As System.Data.Entity.DbSet(Of Database.Entities.TVOrder)
        Public Overridable Property UserDefinedLabel As System.Data.Entity.DbSet(Of Database.Entities.UserDefinedLabel)
        Public Overridable Property UserDefinedTypes As System.Data.Entity.DbSet(Of Database.Entities.UserDefinedType)
        Public Overridable Property UserDefinedTypeValues As System.Data.Entity.DbSet(Of Database.Entities.UserDefinedTypeValue)
        Public Overridable Property VendorComments As System.Data.Entity.DbSet(Of Database.Entities.VendorComment)
        Public Overridable Property VendorContacts As System.Data.Entity.DbSet(Of Database.Entities.VendorContact)
        Public Overridable Property VendorCrossReferences As System.Data.Entity.DbSet(Of Database.Entities.VendorCrossReference)
        Public Overridable Property VendorDCMMappings As System.Data.Entity.DbSet(Of Database.Entities.VendorDCMMapping)
        Public Overridable Property VendorHistorys As System.Data.Entity.DbSet(Of Database.Entities.VendorHistory)
        Public Overridable Property VendorInvoiceAlerts As System.Data.Entity.DbSet(Of Database.Views.VendorInvoiceAlert)
        Public Overridable Property VendorInvoices As System.Data.Entity.DbSet(Of Database.Views.VendorInvoice)
        Public Overridable Property VendorPricings As System.Data.Entity.DbSet(Of Database.Entities.VendorPricing)
        Public Overridable Property Vendors As System.Data.Entity.DbSet(Of Database.Entities.Vendor)
        Public Overridable Property VendorSortKeys As System.Data.Entity.DbSet(Of Database.Entities.VendorSortKey)
        Public Overridable Property VendorTerms As System.Data.Entity.DbSet(Of Database.Entities.VendorTerm)
        Public Overridable Property WebsiteTypes As System.Data.Entity.DbSet(Of Database.Entities.WebsiteType)
        Public Overridable Property WorkflowAlertStates As System.Data.Entity.DbSet(Of Database.Entities.WorkflowAlertState)
        Public Overridable Property Workflows1 As System.Data.Entity.DbSet(Of Database.Entities.Workflow)

#End Region

#Region " Methods "

        <System.Obsolete>
        Public Sub New()

            MyBase.New("Data Source=TASC-CODE\TFS;Initial Catalog=ADV67000;Persist Security Info=True;User ID=SYSADM;Password=sysadm;MultipleActiveResultSets=True;APP=EntityFramework")

        End Sub
        <System.Obsolete>
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, AdvantageFramework.Database.Methods.DatabaseTypes.Default)

            _ConnectionString = ConnectionString

            System.Data.Entity.Database.SetInitializer(Of AdvantageFramework.Database.DbContext)(Nothing)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            modelBuilder.Configurations.Add(New Mappings.NewspaperOtherChargeMapping)
            modelBuilder.Configurations.Add(New Mappings.OrderProcessLogMapping)
            modelBuilder.Configurations.Add(New Mappings.DigitalResultsViewMapping)
            modelBuilder.Configurations.Add(New Mappings.VendorContractMapping)
            modelBuilder.Configurations.Add(New Mappings.VendorContractContactMapping)
            modelBuilder.Configurations.Add(New Mappings.VendorContractDocumentMapping)
            'modelBuilder.Configurations.Add(New Mappings.ChatMessageMapping)
            'modelBuilder.Configurations.Add(New Mappings.ChatRoomMapping)
            'modelBuilder.Configurations.Add(New Mappings.ChatUserMapping)
            modelBuilder.Configurations.Add(New Mappings.StateMapping)
            'modelBuilder.Configurations.Add(New Mappings.ChatActiveRoomMapping)
            modelBuilder.Configurations.Add(New Mappings.ChatActiveUserMapping)
            'modelBuilder.Entity(Of Entities.NewspaperOtherCharge)()
            'modelBuilder.Entity(Of Entities.MediaOrderPrintSetting)()

            'modelBuilder.Properties.Having(Function(Prop) Prop.GetCustomAttributes(False).OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).FirstOrDefault).
            '                        Configure(Function(Prop, Attribute) Prop.HasPrecision(Attribute.Precision, Attribute.Scale))

            MyBase.OnModelCreating(modelBuilder)

        End Sub

#End Region

    End Class

End Namespace
