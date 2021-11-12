Namespace Security

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public _MyMenuStateDetails As String = "Dock={0};AutoHide={1};X={2};Y={3};Width={4};Height={5}"
        Public Const AdvantageConnectionConfigurationFileName As String = "AdvantageConnectionConfiguration.xml"

#End Region

#Region " Enum "

        Public Enum AccessType
            Full = 1
            [ReadOnly] = 2
            Blocked = 3
        End Enum

        Public Enum Application
            Advantage = 1
            Webvantage = 2
            Advantage_Update = 3
            Outlook_Addin = 4
            Advantage_Database_Update = 5
            Client_Portal = 6
            Adassist = 7
            Advantage_Nielsen_Database_Update = 8
            Webvantage_Password_Admin = 9 'Needed for validation of connectionstring!
            Mobile_DataService = 10
            ProofingAPI = 11
        End Enum

        Public Enum UserSettings
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "My Menu")>
            MyMenuDefaultTabName
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            MyMenuDefaultTabSmallIcons
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MyMenuState
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "1")>
            QuickAccessToolbarVisible
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "1")>
            NavigationWindowVisible
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "1")>
            BubbleBarVisible
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            PR_PO_DO_OWN
            '<AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")> _
            'SI_MARKUP_TAX
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            SI_DO_OWN_TS
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            EMP_TS_FNC
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            TS_ADMIN_LVL
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            TIME_ENTRY_ONLY
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Numeric_Boolean_10, "0")>
            NewAdvantageApplicationsAlert
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            AllowProfileUpdate
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "Y")>
            RemindUserOfLicenseKeyRenewal
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            ETFSelectedOffice
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            ETFSelectedEmployee
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            ETFSelectedPostPeriod
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            IsCRMUser
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            IsMediaToolsUser
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            ShowDescriptionsInRateFlagEntry
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            ShowDescriptionsInAdjustTime
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Default, "3")>
            GridColumnOptionsInCRMCentral
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            IsAPIUser
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            ShowDescriptionsInIncomeOnly
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            LastGenericAPImportTemplateID
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            LastAPImportType
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "1")>
            ShowSequenceNumberInInvoicePrinting
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "0")>
            ShowDivisionProductJobCompInInvoicePrinting
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            LastVCCReminderLocation
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            BCCLastMediaDateToUse
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            APShowHomeChecked
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            BCCExcludeNonBillableFunctionsAdvanceBilling
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            BCCHideNonBillableFunctionsEmployeeTime
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            BCCHideNonBillableFunctionsIncomeOnly
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            BCCHideNonBillableFunctionsVendor
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaManagerApproveInvoiceView
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "3")>
            MediaManagerSearchFilterBy
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            RFPCCSender
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            RFPEmailSubject
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            RFPEmailBody
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            MediaManagerCCSender
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaManagerEmailSubject
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaManagerEmailBody
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            MediaManagerSendToDocumentManager
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            MediaManagerUploadAndSignDocumentWhenSubmitted
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            MediaManagerEmailExecutedCopyToVendor
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaManagerDocumentTypes
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaManagerContactTypes
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaManagerRepresentativeTypes
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            PurchaseOrderCCSender
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            PurchaseOrderEmailSubject
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            PurchaseOrderEmailBody
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            PurchaseOrderUploadAndSignDocumentWhenSubmitted
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            PurchaseOrderUploadDocumentManager
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            PurchaseOrderEmailExecutedCopyToVendor
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            RFPContactTypes
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaTrafficContactTypes
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            MediaTrafficCCSender
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaTrafficEmailSubject
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")>
            MediaTrafficEmailBody
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "0")>
            MediaBroadcastWorksheet_HideHiatusDates
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            CRMAddEditViewNewBusinessClientsOnly
        End Enum

        Public Enum SettingsValueType
            StringValue
            NumericValue
            DateValue
        End Enum

        Public Enum SettingsParseValueType
            [Default]
            String_Boolean_YN
            Numeric_Boolean_10
        End Enum

        Public Enum GroupSettings
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            Calendar_AllowGroupToViewOtherEmployees
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            Calendar_AllowGroupToAddHolidays
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            AlertInbox_ShowAllAssignments
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            AlertInbox_ShowUnassignedAssignments
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            Schedule_AllowTaskEdit
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            DocumentManager_CanUpload
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            DocumentManager_ViewPrivateDocuments
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            Workspace_Template_Create
            <AdvantageFramework.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")>
            Schedule_AllowMediaPageEdit
        End Enum

        Public Enum Modules
            Billing
            Billing_AdjustTime
            Billing_AvalaraRepost
            Billing_BillingApproval
            Billing_BillingApprovalBatch
            Billing_BillingCommandCenter
            Billing_Reports
            Billing_Reports_BillingReportsRTP
            Billing_Reports_InvoicePrintingRTP
            Billing_Reports_InvoicePrintingEnhancedRTP
            Desktop
            Desktop_Alerts
            Desktop_AlertsManager
            Desktop_Calendar
            Desktop_Chat
            Desktop_CRMCentral
            Desktop_DocumentManager
            Desktop_DocumentManagerLevels
            Desktop_DocumentManagerLevels_AdNumber
            Desktop_DocumentManagerLevels_AgencyDesktop
            Desktop_DocumentManagerLevels_AlertAttachment
            Desktop_DocumentManagerLevels_APInvoice
            Desktop_DocumentManagerLevels_ARInvoice
            Desktop_DocumentManagerLevels_Campaign
            Desktop_DocumentManagerLevels_Client
            Desktop_DocumentManagerLevels_Contract
            Desktop_DocumentManagerLevels_ContractReport
            Desktop_DocumentManagerLevels_ContractValueAdded
            Desktop_DocumentManagerLevels_Division
            Desktop_DocumentManagerLevels_Employee
            Desktop_DocumentManagerLevels_ExecutiveDesktop
            Desktop_DocumentManagerLevels_ExpenseReceipts
            Desktop_DocumentManagerLevels_Job
            Desktop_DocumentManagerLevels_JobComponent
            Desktop_DocumentManagerLevels_MediaOrder
            Desktop_DocumentManagerLevels_Office
            Desktop_DocumentManagerLevels_Product
            Desktop_DocumentManagerLevels_Task
            Desktop_DocumentManagerLevels_Vendor
            Desktop_DocumentManagerLevels_VendorContract
            Desktop_ReportWriter
            Desktop_ReportWriter_AdvancedReportWriter
            Desktop_ReportWriter_AdvancedReportWriterDataSets
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AccountsPayableInvoiceDetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AccountsPayableInvoiceDetailPaymentsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AccountsPayableInvoiceDetailPaidByClientARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AccountsPayableInvoiceWithBalanceAgingARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AlertsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AlertsWithCommentsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AlertsWithRecipientsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AROpenAgedARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_AuthorizationToBuyARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_BillingApprovalARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_BillingWorksheetMediaARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_BillingWorksheetProductionARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_BroadcastInvoiceSummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_CampaignARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_CampaignWithProductionAndMediaARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_CashAnalysisARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_CashTransactionsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ClientContactARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ClientPLARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ClientPLDetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ClientsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_CRMClientContractsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_CRMOpportunityDetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_CRMOpportunityToInvestmentARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_CRMProspectsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_DirectIndirectTimeARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_DirectIndirectTimeWithEmployeeCostARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_DirectTimeARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_DirectTimeWithEmployeeCostARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_DivisionsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_EmployeesARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_EmployeesInOutBoardARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_EmployeeTimeApprovalARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_EstimateFormARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_EstimatedAndActualIncomeARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_EstimateDetailApprovedARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_GeneralLedgerDetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_IncomeOnlyARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV10DetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV10SummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV11DetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV11JobCompARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV11SummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV1DetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV1SummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV29ARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV30SummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV30DetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV30JobCompARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV31ARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailBillMonthARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFunctionARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailItemARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailItemAccountSplitARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFeesAndOOPByCampaignARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFeesAndOOPByFunctionARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFeesAndOOPByJobARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFeesAndOOPByJobComponentARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobProjectScheduleSummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobPurchaseOrderARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobSummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_JobWriteOffARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaCurrentStatusARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaCurrentStatusCoopBreakoutARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaCurrentStatusSummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaPlanARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaPlanComparisonSummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaResultsComparisonByClientAndTypeARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_NewspaperOrderDetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_OpenPurchaseOrderDetailARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ProductsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectHoursUsedARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectScheduleARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectSummaryARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectSummaryAnalysisARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectSummaryTaskARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_PurchaseOrderARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_SalesJournalARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ServiceFeeARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ServiceFeeContractARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_ServiceFeeReconciliationARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_TransferARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_SecurityUserTimesheetFunctionARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_VendorsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_VendorContractsARWRPT
            Desktop_ReportWriter_AdvancedReportWriterDataSets_VirtualCreditCardTransactionEFSARWRPT
            Desktop_ReportWriter_DynamicReportDataSets
            Desktop_ReportWriter_DynamicReportDataSets_AccountsPayableInvoiceDetailDRPT
            Desktop_ReportWriter_DynamicReportDataSets_AccountsPayableInvoiceDetailPaymentsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_AccountsPayableInvoiceDetailPaidByClientDRPT
            Desktop_ReportWriter_DynamicReportDataSets_AccountsPayableInvoiceWithBalanceAgingDRPT
            Desktop_ReportWriter_DynamicReportDataSets_AlertsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_AlertsWithCommentsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_AlertsWithRecipientsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_AROpenAgedDRPT
            Desktop_ReportWriter_DynamicReportDataSets_AuthorizationToBuyDRPT
            Desktop_ReportWriter_DynamicReportDataSets_BillingApprovalDRPT
            Desktop_ReportWriter_DynamicReportDataSets_BillingWorksheetMediaDRPT
            Desktop_ReportWriter_DynamicReportDataSets_BillingWorksheetProductionDRPT
            Desktop_ReportWriter_DynamicReportDataSets_BroadcastInvoiceSummaryDRPT
            Desktop_ReportWriter_DynamicReportDataSets_CampaignDRPT
            Desktop_ReportWriter_DynamicReportDataSets_CampaignWithProductionAndMediaDRPT
            Desktop_ReportWriter_DynamicReportDataSets_CashAnalysisDRPT
            Desktop_ReportWriter_DynamicReportDataSets_CashTransactionsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ClientContactDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ClientPLDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ClientPLDetailDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ClientsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_CRMClientContractsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_CRMOpportunityDetailDRPT
            Desktop_ReportWriter_DynamicReportDataSets_CRMOpportunityToInvestmentDRPT
            Desktop_ReportWriter_DynamicReportDataSets_CRMProspectsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_DirectIndirectTimeDRPT
            Desktop_ReportWriter_DynamicReportDataSets_DirectIndirectTimeWithEmployeeCostDRPT
            Desktop_ReportWriter_DynamicReportDataSets_DirectTimeDRPT
            Desktop_ReportWriter_DynamicReportDataSets_DirectTimeWithEmployeeCostDRPT
            Desktop_ReportWriter_DynamicReportDataSets_DivisionsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_EmployeesDRPT
            Desktop_ReportWriter_DynamicReportDataSets_EmployeesInOutBoardDRPT
            Desktop_ReportWriter_DynamicReportDataSets_EmployeeTimeApprovalDRPT
            Desktop_ReportWriter_DynamicReportDataSets_EstimateFormDRPT
            Desktop_ReportWriter_DynamicReportDataSets_EstimatedAndActualIncomeDRPT
            Desktop_ReportWriter_DynamicReportDataSets_EstimateDetailApprovedDRPT
            Desktop_ReportWriter_DynamicReportDataSets_GeneralLedgerDetailDRPT
            Desktop_ReportWriter_DynamicReportDataSets_IncomeOnlyDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailBillMonthDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailFunctionDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailItemDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailItemAccountSplitDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailFeesAndOOPByCampaignDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailFeesAndOOPByFunctionDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailFeesAndOOPByJobDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobDetailFeesAndOOPByJobComponentDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobProjectScheduleSummaryDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobPurchaseOrderDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobSummaryDRPT
            Desktop_ReportWriter_DynamicReportDataSets_JobWriteOffDRPT
            Desktop_ReportWriter_DynamicReportDataSets_MediaCurrentStatusDRPT
            Desktop_ReportWriter_DynamicReportDataSets_MediaCurrentStatusCoopBreakoutDRPT
            Desktop_ReportWriter_DynamicReportDataSets_MediaCurrentStatusSummaryDRPT
            Desktop_ReportWriter_DynamicReportDataSets_MediaPlanComparisonSummaryDRPT
            Desktop_ReportWriter_DynamicReportDataSets_MediaPlanDRPT
            Desktop_ReportWriter_DynamicReportDataSets_MediaResultsComparisonByClientAndTypeDRPT
            Desktop_ReportWriter_DynamicReportDataSets_NewspaperOrderDetailDRPT
            Desktop_ReportWriter_DynamicReportDataSets_OpenPurchaseOrderDetailDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ProductsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ProjectHoursUsedDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ProjectScheduleDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ProjectSummaryDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ProjectSummaryAnalysisDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ProjectSummaryTaskDRPT
            Desktop_ReportWriter_DynamicReportDataSets_SalesJournalDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ServiceFeeDRPT
            Desktop_ReportWriter_DynamicReportDataSets_ServiceFeeContractDRPT
            Desktop_ReportWriter_DynamicReportDataSets_TransferDRPT
            Desktop_ReportWriter_DynamicReportDataSets_SecurityUserTimesheetFunctionDRPT
            Desktop_ReportWriter_DynamicReportDataSets_VendorsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_VendorContractsDRPT
            Desktop_ReportWriter_DynamicReportDataSets_VirtualCreditCardTransactionEFSDRPT
            Desktop_ReportWriter_DynamicReports
            Desktop_ReportWriter_UserDefinedReports
            Employee
            Employee_DashboardQueries
            Employee_DashboardQueries_VacSickTimeDQ
            Employee_DesktopObjects
            Employee_DesktopObjects_AlertsDO
            Employee_DesktopObjects_BillableHoursGoalDO
            Employee_DesktopObjects_BookmarksDO
            Employee_DesktopObjects_EmployeeIndirectTimeAllDO
            Employee_DesktopObjects_EmployeeIndirectTimeDO
            Employee_DesktopObjects_EmployeeTimeForecastDO
            Employee_DesktopObjects_InOutBoardAllDO
            Employee_DesktopObjects_InOutBoardDO
            Employee_DesktopObjects_MyDirectTimeDO
            Employee_DesktopObjects_MyEmployeeTimeForecastDO
            Employee_DesktopObjects_TimesheetDO
            Employee_DesktopObjects_WeeklyTimeGraphDO
            Employee_ExpenseApproval
            Employee_ExpenseReports
            Employee_Reports
            Employee_Reports_DirectTimeRTP
            Employee_Reports_DirectTimeActivityRTP
            Employee_Reports_HoursWorkedRTP
            Employee_Reports_EmpHrsWorkedRTP
            Employee_Reports_IndrectTimeRTP
            Employee_Reports_TimesheetRTP
            Employee_Timesheet
            Employee_TimesheetEnhanced
            Employee_TimesheetApproval
            FinanceAccounting
            FinanceAccounting_1099Processing
            FinanceAccounting_AccountsPayable
            FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import
            FinanceAccounting_AdvantagePay
            FinanceAccounting_BankReconciliation
            FinanceAccounting_BatchTimePost
            FinanceAccounting_CheckWritingReports
            FinanceAccounting_ClientBudgets
            FinanceAccounting_ClientCashReceipts
            FinanceAccounting_ClientCashReceiptsImport
            FinanceAccounting_ClientInvoicesImport
            FinanceAccounting_ClientInvoicesManual
            FinanceAccounting_ClientInvoices
            FinanceAccounting_ClientLatePaymentFees
            FinanceAccounting_ClientOOP
            FinanceAccounting_CreateRecurringAP
            FinanceAccounting_DashboardQueries
            FinanceAccounting_DashboardQueries_ClientTimeAnalysisDQ
            FinanceAccounting_DashboardQueries_EmployeeTimeADQ
            FinanceAccounting_DashboardQueries_EmployeeUtilizationDQ
            FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ
            FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ
            FinanceAccounting_DashboardQueries_VacSickAdminDQ
            FinanceAccounting_DashboardQueries_VendorAPQueryDQ
            FinanceAccounting_DesktopObjects
            FinanceAccounting_DesktopObjects_AgencyGoalsDO
            FinanceAccounting_DesktopObjects_AgencyGoalsGraphDO
            FinanceAccounting_DesktopObjects_ARCashForecastDO
            FinanceAccounting_DesktopObjects_ARCashForecastProductDO
            FinanceAccounting_DesktopObjects_BillingTrendsDO
            FinanceAccounting_DesktopObjects_CashBalanceDO
            FinanceAccounting_DesktopObjects_ClientAgingDO
            FinanceAccounting_DesktopObjects_CurrentRatioDO
            FinanceAccounting_DesktopObjects_CurrentRatioGraphDO
            FinanceAccounting_DesktopObjects_DirectExpenseAlertDO
            FinanceAccounting_DesktopObjects_GrossIncomeDO
            FinanceAccounting_DesktopObjects_MyARCashForecastDO
            FinanceAccounting_DesktopObjects_MyClientAgingDO
            FinanceAccounting_DesktopObjects_MyDirectExpenseAlertDO
            FinanceAccounting_DesktopObjects_MyGrossIncomeDO
            FinanceAccounting_DesktopObjects_MyServiceFeesDO
            FinanceAccounting_DesktopObjects_ServiceFeesDO
            FinanceAccounting_EmployeeTimeForecast
            FinanceAccounting_EmployeeTimeForecastComparisonDashboard
            FinanceAccounting_EmployeeTimeForecastSettings
            FinanceAccounting_Exports
            FinanceAccounting_Exports_CheckRegisterExport
            FinanceAccounting_Exports_EmployeeHoursExport
            FinanceAccounting_Exports_VATTaxExport
            FinanceAccounting_Housekeeping
            FinanceAccounting_Housekeeping_BankReconciliationUtility
            FinanceAccounting_Housekeeping_BillableMaintenance
            FinanceAccounting_Housekeeping_BrdcastAutoClose
            FinanceAccounting_Housekeeping_POMaintenance
            FinanceAccounting_Housekeeping_VendorMerge
            FinanceAccounting_Imports
            FinanceAccounting_Imports_ChecksClearedImport
            FinanceAccounting_Imports_IncomeOnlyImport
            FinanceAccounting_Imports_PTOImport
            FinanceAccounting_Imports_TimeImport
            FinanceAccounting_IncomeOnly
            FinanceAccounting_JobForecast
            FinanceAccounting_JobProcessCtrl
            FinanceAccounting_MediaDatetoBill
            FinanceAccounting_PaymentManager
            FinanceAccounting_PaymentManagerEnhanced
            FinanceAccounting_PostRecurringAP
            FinanceAccounting_Reports
            FinanceAccounting_Reports_AccountsPayableRTP
            FinanceAccounting_Reports_AccountsReceivableRTP
            FinanceAccounting_Reports_ARStatementsRTP
            FinanceAccounting_Reports_CashManagementProductionRTP
            FinanceAccounting_Reports_CashReceiptsRTP
            FinanceAccounting_Reports_CheckRegisterRTP
            FinanceAccounting_Reports_ClientPLRTP
            FinanceAccounting_Reports_EmployeeHoursWorkedRTP
            FinanceAccounting_Reports_EmployeeTimeManagementRTP
            FinanceAccounting_Reports_EmployeeUtilizationRTP
            FinanceAccounting_Reports_GeneralLedgerRTP
            FinanceAccounting_Reports_MonthEndReportsRTP
            FinanceAccounting_Reports_MonthEndReportsEnhancedRTP
            FinanceAccounting_Reports_PurchaseOrdersRTP
            FinanceAccounting_Reports_PurchaseOrderReportRTP
            FinanceAccounting_Reports_SalesJournalRTP
            FinanceAccounting_RevenueResourcePlan
            FinanceAccounting_ServiceFeeReconciliation
            FinanceAccounting_ServiceFees
            FinanceAccounting_VoidChecks
            FinanceAccounting_VoidInvoices
            FinanceAccounting_VoidInvoicesEnhanced
            General
            General_DesktopObjects
            General_DesktopObjects_AgencyLinksDO
            General_DesktopObjects_ExecutiveLinksDO
            GeneralLedger
            GeneralLedger_DashboardQueries
            GeneralLedger_DashboardQueries_BudgetvsActualQryDQ
            GeneralLedger_DashboardQueries_JournalEntryQueryDQ
            GeneralLedger_DashboardQueries_TrialBalanceQueryDQ
            GeneralLedger_Exports
            GeneralLedger_Exports_GLDetailQueryExportRTP
            GeneralLedger_Imports
            GeneralLedger_Imports_ImportBudgets
            GeneralLedger_Imports_ImportJournalEntries
            GeneralLedger_JournalEntriesBudgets
            GeneralLedger_JournalEntriesBudgets_BudgetApproval
            GeneralLedger_JournalEntriesBudgets_Budgets
            GeneralLedger_JournalEntriesBudgets_JournalEntries
            GeneralLedger_Maintenance
            GeneralLedger_Maintenance_AccountAllocation
            GeneralLedger_Maintenance_ChartofAccounts
            GeneralLedger_Maintenance_Configuration
            GeneralLedger_Maintenance_CrossReference
            GeneralLedger_Maintenance_GeneralLedgerMapping
            GeneralLedger_Maintenance_GeneralLedgerMappingExport
            GeneralLedger_Maintenance_PostingPeriods
            GeneralLedger_Processing
            GeneralLedger_Processing_ConsolidateGL
            GeneralLedger_Processing_PostAllocations
            GeneralLedger_Processing_PostRecurring
            GeneralLedger_Processing_UpdateToSummary
            GeneralLedger_Processing_UpdateToSummary_Actions
            GeneralLedger_Processing_UpdateToSummary_Actions_OptionToClearAndRepost
            GeneralLedger_Processing_YearEndClosing
            GeneralLedger_Reports
            GeneralLedger_Reports_GeneralLedgerReports
            GeneralLedger_Reports_DetailbyAcctCodeRptRTP
            GeneralLedger_Reports_DetailbyTransRptRTP
            GeneralLedger_Reports_FY12PeriodSpreadRTP
            GeneralLedger_ReportWriter
            GeneralLedger_ReportWriter_GLReportWriter
            GeneralLedger_ReportWriter_ReportingAcctGroup
            GeneralLedger_ReportWriter_ReportingColFmt
            GeneralLedger_ReportWriter_ReportingRowFmt
            GeneralLedger_ReportWriter_ReportList
            HelpCustomerService
            HelpCustomerService_Aboutadvantage
            HelpCustomerService_ContactCustomerService
            HelpCustomerService_Help
            Maintenance
            Maintenance_Accounting
            Maintenance_Accounting_AccountNumber
            Maintenance_Accounting_ARStatement
            Maintenance_Accounting_AvalaraProductMapping
            Maintenance_Accounting_AvalaraTaxCodeMaintenance
            Maintenance_Accounting_Bank
            Maintenance_Accounting_BillingCoop
            Maintenance_Accounting_CashReceiptPaymentType
            Maintenance_Accounting_ClientDiscount
            Maintenance_Accounting_CurrencyCodes
            Maintenance_Accounting_DeptTeam
            Maintenance_Accounting_Employee
            Maintenance_Accounting_EmployeeCategory
            Maintenance_Accounting_EmployeeImport
            Maintenance_Accounting_EmployeeTitle
            Maintenance_Accounting_EmployeeUpdate
            Maintenance_Accounting_FiscalPeriod
            Maintenance_Accounting_Function
            Maintenance_Accounting_FunctionHeading
            Maintenance_Accounting_GeneralDescriptions
            Maintenance_Accounting_Office
            Maintenance_Accounting_PaidTimeOff
            Maintenance_Accounting_QuickBooksSettings
            Maintenance_Accounting_SalesClass
            Maintenance_Accounting_SalesTax
            Maintenance_Accounting_ServiceFeeType
            Maintenance_Accounting_TimeCategory
            Maintenance_Accounting_TimeCategoryType
            Maintenance_Accounting_Vendor
            Maintenance_Accounting_VendorContact
            Maintenance_Accounting_VendorImport
            Maintenance_Accounting_VendorInvoiceCategory
            Maintenance_Accounting_VendorMapping
            Maintenance_Accounting_VendorServiceTax
            Maintenance_Accounting_VendorTerms
            Maintenance_Billing
            Maintenance_Billing_BillingSettings
            Maintenance_Billing_InvoiceCategory
            Maintenance_Billing_RateFlagEntry
            Maintenance_Billing_RateFlagStructure
            Maintenance_Billing_RateFlagStructureEntry
            Maintenance_Client
            Maintenance_Client_AccountExecutive
            Maintenance_Client_Affiliation
            Maintenance_Client_Client
            Maintenance_Client_ClientContact
            Maintenance_Client_ClientContactImport
            Maintenance_Client_ClientImport
            Maintenance_Client_ClientMapping
            Maintenance_Client_ClientPO
            Maintenance_Client_Competition
            Maintenance_Client_Division
            Maintenance_Client_DivisionImport
            Maintenance_Client_Industry
            Maintenance_Client_ManagementLevel
            Maintenance_Client_Media_Percentages
            Maintenance_Client_Product
            Maintenance_Client_ProductImport
            Maintenance_Client_ProductCategory
            Maintenance_Client_Rating
            Maintenance_Client_Source
            Maintenance_Client_Specialty
            Maintenance_Client_Types
            Maintenance_General
            Maintenance_General_AdvantageServicesSettings
            Maintenance_General_Agency
            Maintenance_General_AgencySettings
            Maintenance_General_ContactTypes
            Maintenance_General_CSIPreferredPartnerSettings
            Maintenance_General_CycleFrequency
            Maintenance_General_Documents
            Maintenance_General_IntegrationSettings
            Maintenance_General_Locations
            Maintenance_General_MyObjectDefinition
            Maintenance_General_PasswordSettings
            Maintenance_General_ProfileAdministration
            Maintenance_General_Region
            Maintenance_General_SoftwareVersion
            Maintenance_General_StandardComments
            Maintenance_General_UserDefinedReportCategory
            Maintenance_General_VCCSettings
            Maintenance_General_WebsiteTypes
            Maintenance_General_WorkstationComponents
            Maintenance_Management
            Maintenance_Management_AgencyBuilder
            Maintenance_Management_AgencyClients
            Maintenance_Management_OHAccounts
            Maintenance_Media
            Maintenance_Media_AdSize
            Maintenance_Media_Associate
            Maintenance_Media_InvoiceMatchingSettings
            Maintenance_Media_Buyer
            Maintenance_Media_CableNetwork
            Maintenance_Media_CanadaUniverse
            Maintenance_Media_Channel
            Maintenance_Media_Daypart
            Maintenance_Media_Demographic
            Maintenance_Media_InternetType
            Maintenance_Media_MarketGroups
            Maintenance_Media_MediaMarket
            Maintenance_Media_MediaSpecs
            Maintenance_Media_MixRateTemplate
            Maintenance_Media_NationalUniverse
            Maintenance_Media_OutofHomeType
            Maintenance_Media_Partner
            Maintenance_Media_PartnerAllocation
            Maintenance_Media_RateCardContract
            Maintenance_Media_Tactic
            Maintenance_Media_VendorRep
            Maintenance_ProjectManagement
            Maintenance_ProjectManagement_AdNumber
            Maintenance_ProjectManagement_AlertAssignments
            Maintenance_ProjectManagement_AlertEventSettings
            Maintenance_ProjectManagement_AlertGroups
            Maintenance_ProjectManagement_Blackplate
            Maintenance_ProjectManagement_ComplexityType
            Maintenance_ProjectManagement_CreativeBriefTemplate
            Maintenance_ProjectManagement_Destination
            Maintenance_ProjectManagement_DestinationContact
            Maintenance_ProjectManagement_EstimateTemplates
            Maintenance_ProjectManagement_JobComponentCustom1
            Maintenance_ProjectManagement_JobComponentCustom2
            Maintenance_ProjectManagement_JobComponentCustom3
            Maintenance_ProjectManagement_JobComponentCustom4
            Maintenance_ProjectManagement_JobComponentCustom5
            Maintenance_ProjectManagement_JobCustom1
            Maintenance_ProjectManagement_JobCustom2
            Maintenance_ProjectManagement_JobCustom3
            Maintenance_ProjectManagement_JobCustom4
            Maintenance_ProjectManagement_JobCustom5
            Maintenance_ProjectManagement_JobCustomTabNames
            Maintenance_ProjectManagement_JobSpecification
            Maintenance_ProjectManagement_JobTemplate
            Maintenance_ProjectManagement_JobType
            Maintenance_ProjectManagement_JobVersionTemplate
            Maintenance_ProjectManagement_PrintSpecStatus
            Maintenance_ProjectManagement_ProductionSettings
            Maintenance_ProjectManagement_PromotionType
            Maintenance_ProjectManagement_PurchaseOrderApproval
            Maintenance_ProjectManagement_Resource
            Maintenance_ProjectManagement_ResourceType
            Maintenance_ProjectManagement_SalesClassFormat
            Maintenance_ProjectManagement_Timesheet
            Maintenance_ProjectManagement_VendorPricing
            Maintenance_ProjectSchedule
            Maintenance_ProjectSchedule_Phase
            Maintenance_ProjectSchedule_Role
            Maintenance_ProjectSchedule_Settings
            Maintenance_ProjectSchedule_Status
            Maintenance_ProjectSchedule_Task
            Maintenance_ProjectSchedule_TaskTemplate
            Media
            Media_AuthorizationToBuy
            Media_BroadcastOrders
            Media_BroadcastOrdersRadio
            Media_BroadcastOrdersTV
            Media_BroadcastRec
            Media_BroadcastRecDelete
            Media_BroadcastResearchTool
            Media_ComscoreTester
            Media_COREConnect
            Media_DigitalCampaignManager
            Media_DigitalResults
            Media_Exports
            Media_Exports_BroadcastBuyInvoice
            Media_Imports
            Media_Imports_BroadcastImport
            Media_Imports_MediaImport
            Media_InternetOrders
            Media_MagazineOrders
            Media_MediaApprovalReconciliation
            Media_MediaBroadcastWorksheet
            Media_MediaBroadcastWorksheet_Actions
            Media_MediaBroadcastWorksheet_Actions_MediaTraffic
            Media_MediaBroadcastWorksheet_Actions_SpotMatching
            Media_MediaCalendar
            Media_MediaEstimating
            Media_MediaManager
            Media_MediaManager_Actions
            Media_MediaManager_Actions_AdServing
            Media_MediaManager_Actions_ApproveInvoices
            Media_MediaManager_Actions_BillingApproval
            Media_MediaManager_Actions_CreateAP
            Media_MediaManager_Actions_CreateVCC
            Media_MediaManager_Actions_GenerateOrders
            Media_MediaManager_Actions_Include_PurchaseOrders
            Media_MediaManager_Actions_UpdateCost
            Media_MediaManager_Actions_VirtualCC
            Media_MediaManager_Actions_WriteUpDown
            Media_MediaPlanning
            Media_MediaPlanning_Actions
            Media_MediaPlanning_Actions_AllowActualizationToVaryFromLastPlan
            Media_MediaPlanning_Actions_Approval
            Media_MediaPlanning_Actions_EditTemplate
            Media_MediaResearchTester
            Media_NewspaperOrders
            Media_nFusionMRP
            Media_OrderProcessCtrl
            Media_OrdersGlobalEdit
            Media_OutofHomeOrders
            Media_Reports
            Media_Reports_MediaCurrentStatusRTP
            Media_Reports_MediaSpecificationRPT
            Media_Reports_MediaOrderFormsRTP
            Media_Reports_MediaOrderReportsRTP
            Media_STRATAConnect
            Miscellaneous
            Miscellaneous_DesktopObjects
            Miscellaneous_DesktopObjects_CurrentConditionsDO
            Miscellaneous_DesktopObjects_CurrentTimeDO
            Miscellaneous_DesktopObjects_NewsReaderDO
            Miscellaneous_DesktopObjects_QuoteoftheDayDO
            Miscellaneous_DesktopObjects_WordoftheDayDO
            ProjectManagement
            ProjectManagement_AccountSetupForm
            ProjectManagement_Boards
            ProjectManagement_Campaigns
            ProjectManagement_CreativeBrief
            ProjectManagement_DashboardQueries
            ProjectManagement_DashboardQueries_EmployeeTimePDQ
            ProjectManagement_DashboardQueries_OpenJobsDQ
            ProjectManagement_DashboardQueries_ProjectStatisticsDQ
            ProjectManagement_DashboardQueries_PurchaseOrdersDQ
            ProjectManagement_DashboardQueries_QuotevsActualsDQ
            ProjectManagement_DesktopObjects
            ProjectManagement_DesktopObjects_AllProjectsDO
            ProjectManagement_DesktopObjects_BudgetViewpointDO
            ProjectManagement_DesktopObjects_HoursViewpointDO
            ProjectManagement_DesktopObjects_MyProjectsDO
            ProjectManagement_DesktopObjects_MyQvADO
            ProjectManagement_DesktopObjects_MyTasksDO
            ProjectManagement_DesktopObjects_ProjectStatisticsbyOfficeHDO
            ProjectManagement_DesktopObjects_ProjectStatisticsbyOfficeVDO
            ProjectManagement_DesktopObjects_ProjectStatisticsDO
            ProjectManagement_DesktopObjects_ProjectStatisticsGraphDO
            ProjectManagement_DesktopObjects_ProjectViewpointDO
            ProjectManagement_DesktopObjects_ProjectViewpointSnapshot
            ProjectManagement_DesktopObjects_QvADO
            ProjectManagement_DesktopObjects_TaskListDO
            ProjectManagement_Documents
            ProjectManagement_EmployeeCalendar
            ProjectManagement_Estimating
            ProjectManagement_Events
            ProjectManagement_Events_EventsScheduler
            ProjectManagement_Events_EventTasksScheduler
            ProjectManagement_Imports
            ProjectManagement_Imports_EstimateImport
            ProjectManagement_JobJacket
            ProjectManagement_JobVersions
            ProjectManagement_ProjectEvents
            ProjectManagement_ProjectSchedule
            ProjectManagement_ProjectScheduleEdit
            ProjectManagement_PurchaseOrders
            ProjectManagement_QuoteApproval
            ProjectManagement_Reports
            ProjectManagement_Reports_CampaignsRTP
            ProjectManagement_Reports_EmployeeHoursWorkedRTP
            ProjectManagement_Reports_EstimateFormsRTP
            ProjectManagement_Reports_EstimatePrintingRTP
            ProjectManagement_Reports_EstimateReportsRTP
            ProjectManagement_Reports_EventScheduleRTP
            ProjectManagement_Reports_JobAnalysisRTP
            ProjectManagement_Reports_JobDetailAnalysisRTP
            ProjectManagement_Reports_JobDetailAnalysisOldRTP
            ProjectManagement_Reports_JobOrderFormsRTP
            ProjectManagement_Reports_JobsRTP
            ProjectManagement_Reports_JobStatusRPT
            ProjectManagement_Reports_JobVersionRPT
            ProjectManagement_Reports_MyTaskListRTP
            ProjectManagement_Reports_OpenJobsRTP
            ProjectManagement_Reports_ProjectHoursRTP
            ProjectManagement_Reports_ProjectSummaryRTP
            ProjectManagement_Reports_PurchaseOrderFormsRTP
            ProjectManagement_Reports_PurchaseOrderReportsRTP
            ProjectManagement_Reports_PurchaseOrderReportRTP
            ProjectManagement_Reports_ResourcesRTP
            ProjectManagement_Reports_SprintRTP
            ProjectManagement_Reports_TaskListRTP
            ProjectManagement_Reports_TrafficByDayRTP
            ProjectManagement_Reports_TrafficByTaskRTP
            ProjectManagement_Reports_TrafficRTP
            ProjectManagement_Specifications
            ProjectManagement_TrafficTimeline
            Security
            Security_ChangePassword
            Security_ClientPortalSettings
            Security_Reports
            Security_Reports_SecurityReportRTP
            Security_RepositorySettings
            Security_PasswordPolicy
            Security_SelectReports
            Security_Setup
            Security_Setup_CDPSecurityGroup
            Security_Setup_ClientPortalUser
            Security_Setup_Group
            Security_Setup_ModuleAccess
            Security_Setup_User
            Security_Setup_UserDefinedReportAccess
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property WriteToWebvantageEventLog As Boolean = True

#End Region

#Region " Methods "

        Public Function RandomAlphaStringKey(ByVal KeyLength As Integer) As String

            Dim Rand As New Random
            Dim Key As New Text.StringBuilder
            Dim s As String = String.Empty

            For i As Int32 = 0 To KeyLength - 1

                Key.Append(Chr(Rand.Next(65, 90)))

            Next

            s = Key.ToString.ToUpper

            If s.Length > KeyLength Then

                s = s.Substring(0, KeyLength)

            End If

            'Make sure random string does not randomly generate naughty words or words that appear naughty or possibly offensive
            If s.Contains("SHT") OrElse
               s.Contains("FUCK") OrElse
               s.Contains("FCK") OrElse
               s.Contains("FUK") OrElse
               s.Contains("PUS") OrElse
               s.Contains("PSSY") OrElse
               s.Contains("DICK") OrElse
               s.Contains("COCK") OrElse
               s.Contains("CCK") OrElse
               s.Contains("PIS") OrElse
               s.Contains("BOOB") OrElse
               s.Contains("FML") OrElse
               s.Contains("POOP") OrElse
               s.Contains("IDIOT") OrElse
               s.Contains("OMG") OrElse ' oh my god
               s.Contains("OMF") OrElse ' oh my fuck  ...
               s.Contains("WTF") OrElse ' what the fuck ...
               s.Contains("STF") OrElse ' shut the fuck ...
               s.Contains("GTF") OrElse ' get the fuck ...
               s.Contains("BFD") OrElse ' big fucking deal
               s.Contains("FFS") OrElse' for fuck's sake
               s.Contains("FYFI") OrElse ' for your fucking information
               s.Contains("MAGA") OrElse ' NO NO NO NO NO NO NO NO NO NO NO NO NO NO NO
               s.Contains("TRMP") OrElse ' THE "MAN"
               s.Contains("TRUMP") OrElse ' THE I-D-I-O-T
               s.Contains("TRUM") OrElse ' THAT RUINED
               s.Contains("DJT") OrElse ' DEMOCRACY
               s.Contains("QANON") OrElse' NO NO NO NO NO NO NO NO NO NO NO NO NO NO NO
               s.Contains("WWG") Then ' "WHERE WE GO ONE" BULLSHIT

                RandomAlphaStringKey(KeyLength)

            End If

            Return Key.ToString.ToUpper

        End Function
        Public Function UserHasAccessToEmployee(ByVal SecuritySession As AdvantageFramework.Security.Session, ByVal UserCode As String, ByVal EmployeeCode As String) As Boolean

            Dim HasAccess As Boolean = False
            Dim UserEmployeeAccess As Security.Database.Entities.UserEmployeeAccess = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                UserEmployeeAccess = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCodeAndEmployeeCode(SecurityDbContext, UserCode, EmployeeCode)

                HasAccess = (UserEmployeeAccess IsNot Nothing)

                If HasAccess = False Then

                    HasAccess = UserIsEmployeeManager(SecuritySession, UserCode, EmployeeCode)

                End If

            End Using

            UserHasAccessToEmployee = HasAccess

        End Function
        Public Function UserIsEmployeeManager(ByVal SecuritySession As AdvantageFramework.Security.Session, ByVal UserCode As String, ByVal EmployeeCode As String) As Boolean

            Dim IsEmployeeManager As Boolean = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    IsEmployeeManager = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllEmployeesByUser(DbContext, SecurityDbContext, UserCode)
                                         Where Entity.Code = EmployeeCode).Count > 0

                End Using

            End Using

            UserIsEmployeeManager = IsEmployeeManager

        End Function
        Public Function IsMediaToolUser(ByVal SecuritySession As AdvantageFramework.Security.Session, ByVal UserID As Integer) As Boolean

            'objects
            Dim IsAMediaToolUser As Boolean = False
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.IsMediaToolsUser.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing Then

                    IsAMediaToolUser = IsMediaToolUser(UserSetting.User.UserCode, UserSetting.StringValue)

                End If

            End Using

            IsMediaToolUser = IsAMediaToolUser

        End Function
        Public Function IsMediaToolUser(ByVal UserCode As String, ByVal StringValue As String) As Boolean

            'objects
            Dim IsAMediaToolUser As Boolean = False

            If String.IsNullOrEmpty(StringValue) = False AndAlso AdvantageFramework.Security.Encryption.Decrypt(StringValue) = UserCode Then

                IsAMediaToolUser = True

            End If

            IsMediaToolUser = IsAMediaToolUser

        End Function
        Public Function IsAPIUser(ByVal EmployeeCode As String, ByVal StringValue As String) As Boolean

            'objects
            Dim IsAAPIUser As Boolean = False

            If String.IsNullOrEmpty(StringValue) = False AndAlso AdvantageFramework.Security.Encryption.Decrypt(StringValue) = EmployeeCode Then

                IsAAPIUser = True

            End If

            IsAPIUser = IsAAPIUser

        End Function
        Public Sub AddWebvantageEventLog(ByVal Message As String, Optional ByVal EntryType As EventLogEntryType = EventLogEntryType.Information)

            'objects
            Dim EventLogName As String = "Webvantage"
            Dim EventSource As String = ""
            Dim EventLog As EventLog = Nothing

            'If WriteToWebvantageEventLog Then

            Try

                ' Create an EventLog instance and assign its source.
                EventLog = New EventLog(EventLogName)

                EventSource = "Application_Error Event"

                EventLog.Source = EventSource
                ' Write the error entry to the event log.    
                EventLog.WriteEntry(Message, EntryType)

            Catch ex As Exception

            End Try

            'End If

        End Sub
        'Public Function LoadSQLLogins(ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Security.Database.Classes.SQLLogin)

        '    'objects
        '    Dim SQLLoginList As Generic.List(Of AdvantageFramework.Security.Database.Classes.SQLLogin) = Nothing
        '    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

        '        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

        '    End Using

        '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

        '        SecurityDbContext.Database.Connection.Open()

        '        SQLLoginList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.SQLLogin)

        '        If (Session.IsSysAdmin OrElse Session.IsSecurityAdmin) AndAlso Agency.IsASP.GetValueOrDefault(0) = 0 Then

        '            For Each ServerSQLUser In AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.LoadAvailableSQLUsers(SecurityDbContext).ToList

        '                If AdvantageFramework.Security.Database.Procedures.User.LoadByUserName(SecurityDbContext, ServerSQLUser.Name) Is Nothing Then

        '                    SQLLoginList.Add(New AdvantageFramework.Security.Database.Classes.SQLLogin(ServerSQLUser))

        '                End If

        '            Next

        '            For Each DatabaseSQLUser In AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.Load(SecurityDbContext).Where(Function(DBSQLUser) (DBSQLUser.Type = "S" OrElse DBSQLUser.Type = "U") AndAlso
        '                                                                                                                                                               DBSQLUser.Name <> "dbo" AndAlso
        '                                                                                                                                                               DBSQLUser.DefaultSchemaName = "dbo").ToList

        '                If AdvantageFramework.Security.Database.Procedures.User.LoadByUserName(SecurityDbContext, DatabaseSQLUser.Name) Is Nothing Then

        '                    If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBDataReader(SecurityDbContext, DatabaseSQLUser.ID) Then

        '                        If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBDataWriter(SecurityDbContext, DatabaseSQLUser.ID) Then

        '                            SQLLoginList.Add(New AdvantageFramework.Security.Database.Classes.SQLLogin(DatabaseSQLUser))

        '                        End If

        '                    End If

        '                End If

        '            Next

        '        ElseIf Session.IsDBOwner OrElse Session.IsDBSecurityAdmin OrElse Session.IsDBAccessAdmin Then

        '            For Each DatabaseSQLUser In AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.Load(SecurityDbContext).Where(Function(DBSQLUser) (DBSQLUser.Type = "S" OrElse DBSQLUser.Type = "U") AndAlso
        '                                                                                                                                                               DBSQLUser.Name <> "dbo" AndAlso
        '                                                                                                                                                               DBSQLUser.DefaultSchemaName = "dbo").ToList

        '                If AdvantageFramework.Security.Database.Procedures.User.LoadByUserName(SecurityDbContext, DatabaseSQLUser.Name) Is Nothing Then

        '                    If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBDataReader(SecurityDbContext, DatabaseSQLUser.ID) Then

        '                        If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBDataWriter(SecurityDbContext, DatabaseSQLUser.ID) Then

        '                            SQLLoginList.Add(New AdvantageFramework.Security.Database.Classes.SQLLogin(DatabaseSQLUser))

        '                        End If

        '                    End If

        '                End If

        '            Next

        '        End If

        '    End Using

        '    LoadSQLLogins = SQLLoginList

        'End Function
        Public Function LoadReportTypeName(ByVal ReportType As Int16) As String

            'objects
            Dim ReportTypeName As String = ""

            If ReportType = 21 OrElse ReportType = 33 OrElse ReportType = 53 OrElse ReportType = 54 OrElse ReportType = 55 OrElse
                    ReportType = 59 OrElse ReportType = 60 OrElse ReportType = 61 OrElse ReportType = 93 OrElse ReportType = 94 OrElse ReportType = 115 Then

                ReportTypeName = "Accounting/Finance"

            ElseIf ReportType = 105 Then

                ReportTypeName = "Client Budgets"

            ElseIf ReportType = 101 Then

                ReportTypeName = "Estimate Forms"

            ElseIf ReportType = 100 Then

                ReportTypeName = "Job Analysis"

            ElseIf ReportType = 102 Then

                ReportTypeName = "Job Order Forms"

            ElseIf ReportType = 109 Then

                ReportTypeName = "Maintenance : Employee"

            ElseIf ReportType = 1 Then

                ReportTypeName = "Maintenance : Reports"

            ElseIf ReportType = 114 Then

                ReportTypeName = "Maintenance : Task Templates"

            ElseIf ReportType = 103 Then

                ReportTypeName = "Maintenance : Vendor"

            ElseIf ReportType = 110 Then

                ReportTypeName = "Management Reports"

            ElseIf ReportType = 62 Then

                ReportTypeName = "Media"

            ElseIf ReportType = 106 Then

                ReportTypeName = "Month End Reports - 300 Series"

            ElseIf ReportType = 108 Then

                ReportTypeName = "Month End Reports - 400 Series"

            ElseIf ReportType = 112 Then

                ReportTypeName = "Month End Reports - 500 Series"

            ElseIf ReportType = 111 Then

                ReportTypeName = "Month End Reports - 600 Series"

            ElseIf ReportType = 113 Then

                ReportTypeName = "Month End Reports - 700 Series"

            ElseIf ReportType = 3 OrElse ReportType = 5 OrElse ReportType = 7 OrElse ReportType = 8 Then

                ReportTypeName = "Project Management"

            Else

                ReportTypeName = ""

            End If

            LoadReportTypeName = ReportTypeName

        End Function
        Public Sub ClearNewAdvantageApplicationsAlertSetting(ByVal SecuritySession As AdvantageFramework.Security.Session)

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, SecuritySession.User.ID, AdvantageFramework.Security.UserSettings.NewAdvantageApplicationsAlert.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing Then

                    UserSetting.NumericValue = 0

                    If AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting) Then

                        AdvantageFramework.Navigation.ClearNotificationAlert()

                    End If

                End If

            End Using

        End Sub
        Public Function LoadNewAdvantageApplicationsAlertSetting(ByVal SecuritySession As AdvantageFramework.Security.Session, ByRef AlertMessage As String) As Boolean

            'objects
            Dim HasNewAdvantageApplicationsAlert As Boolean = False
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, SecuritySession.User.ID, AdvantageFramework.Security.UserSettings.NewAdvantageApplicationsAlert.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing Then

                    If UserSetting.NumericValue.GetValueOrDefault(0) = 1 Then

                        HasNewAdvantageApplicationsAlert = True
                        AlertMessage = UserSetting.StringValue

                    End If

                End If

            End Using

            LoadNewAdvantageApplicationsAlertSetting = HasNewAdvantageApplicationsAlert

        End Function
        Public Function SaveUserSetting(ByVal SecuritySession As AdvantageFramework.Security.Session, UserID As Integer, UserSetting As AdvantageFramework.Security.UserSettings, ByVal SettingValue As Object) As Boolean

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                SaveUserSetting = SaveSetting(SecurityDbContext, UserID, GetType(AdvantageFramework.Security.UserSettings), UserSetting.ToString, SettingValue)

            End Using

        End Function
        Public Function SaveGroupSetting(ByVal SecuritySession As AdvantageFramework.Security.Session, GroupID As Integer, GroupSetting As AdvantageFramework.Security.GroupSettings, ByVal SettingValue As Object) As Boolean

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                SaveGroupSetting = SaveSetting(SecurityDbContext, GroupID, GetType(AdvantageFramework.Security.GroupSettings), GroupSetting.ToString, SettingValue)

            End Using

        End Function
        Private Function SaveSetting(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ID As Integer, ByVal SettingType As System.Type, ByVal Setting As String, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim GroupSetting As AdvantageFramework.Security.Database.Entities.GroupSetting = Nothing
            Dim SecuritySettingAttribute As AdvantageFramework.Security.Attributes.SecuritySettingAttribute = Nothing
            Dim ParsedSettingValue As Object = Nothing

            Try

                Try

                    SecuritySettingAttribute = System.Attribute.GetCustomAttribute(SettingType.GetField(Setting.ToString), GetType(AdvantageFramework.Security.Attributes.SecuritySettingAttribute))

                Catch ex As Exception

                End Try

                If SecuritySettingAttribute IsNot Nothing Then

                    If SecuritySettingAttribute.ValueType = SettingsValueType.StringValue Then

                        If SecuritySettingAttribute.ParseValueType = SettingsParseValueType.String_Boolean_YN Then

                            Try

                                If TypeOf SettingValue Is Boolean Then

                                    If SettingValue Then

                                        ParsedSettingValue = "Y"

                                    Else

                                        ParsedSettingValue = "N"

                                    End If

                                ElseIf TypeOf SettingValue Is String Then

                                    If SettingValue = "N" Then

                                        ParsedSettingValue = "N"

                                    Else

                                        ParsedSettingValue = "Y"

                                    End If

                                End If

                            Catch ex As Exception
                                ParsedSettingValue = Nothing
                            End Try

                            If ParsedSettingValue Is Nothing Then

                                If SecuritySettingAttribute.DefaultValue = "N" Then

                                    ParsedSettingValue = "N"

                                Else

                                    ParsedSettingValue = "Y"

                                End If

                            End If

                        Else

                            Try

                                ParsedSettingValue = CStr(SettingValue)

                            Catch ex As Exception
                                ParsedSettingValue = Nothing
                            End Try

                        End If

                    ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.NumericValue Then

                        If SecuritySettingAttribute.ParseValueType = SettingsParseValueType.Numeric_Boolean_10 Then

                            Try

                                If TypeOf SettingValue Is Boolean Then

                                    If SettingValue Then

                                        ParsedSettingValue = CDec(1)

                                    Else

                                        ParsedSettingValue = CDec(0)

                                    End If

                                ElseIf IsNumeric(SettingValue) Then

                                    If CDec(SettingValue) = 0 Then

                                        ParsedSettingValue = CDec(0)

                                    Else

                                        ParsedSettingValue = CDec(1)

                                    End If

                                End If

                            Catch ex As Exception
                                ParsedSettingValue = Nothing
                            End Try

                            If ParsedSettingValue Is Nothing Then

                                If SecuritySettingAttribute.DefaultValue = "0" Then

                                    ParsedSettingValue = CDec(0)

                                Else

                                    ParsedSettingValue = CDec(1)

                                End If

                            End If

                        Else

                            Try

                                ParsedSettingValue = CDec(SettingValue)

                            Catch ex As Exception
                                ParsedSettingValue = Nothing
                            End Try

                        End If

                    ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.DateValue Then

                        Try

                            ParsedSettingValue = CDate(SettingValue)

                        Catch ex As Exception
                            ParsedSettingValue = Nothing
                        End Try

                    End If

                    If SettingType.Name = GetType(AdvantageFramework.Security.UserSettings).Name Then

                        Try

                            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, ID, Setting)

                        Catch ex As Exception
                            UserSetting = Nothing
                        End Try

                        If UserSetting Is Nothing Then

                            If SecuritySettingAttribute.ValueType = SettingsValueType.StringValue Then

                                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, ID, Setting, ParsedSettingValue, Nothing, Nothing, UserSetting)

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.NumericValue Then

                                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, ID, Setting, Nothing, ParsedSettingValue, Nothing, UserSetting)

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.DateValue Then

                                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, ID, Setting, Nothing, Nothing, ParsedSettingValue, UserSetting)

                            End If

                        Else

                            If SecuritySettingAttribute.ValueType = SettingsValueType.StringValue Then

                                UserSetting.StringValue = ParsedSettingValue

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.NumericValue Then

                                UserSetting.NumericValue = ParsedSettingValue

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.DateValue Then

                                UserSetting.DateValue = ParsedSettingValue

                            End If

                            Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                        End If

                    Else

                        Try

                            GroupSetting = AdvantageFramework.Security.Database.Procedures.GroupSetting.LoadByGroupIDAndSettingCode(SecurityDbContext, ID, Setting)

                        Catch ex As Exception
                            GroupSetting = Nothing
                        End Try

                        If GroupSetting Is Nothing Then

                            If SecuritySettingAttribute.ValueType = SettingsValueType.StringValue Then

                                Saved = AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, ID, Setting, ParsedSettingValue, Nothing, Nothing, GroupSetting)

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.NumericValue Then

                                Saved = AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, ID, Setting, Nothing, ParsedSettingValue, Nothing, GroupSetting)

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.DateValue Then

                                Saved = AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, ID, Setting, Nothing, Nothing, ParsedSettingValue, GroupSetting)

                            End If

                        Else

                            If SecuritySettingAttribute.ValueType = SettingsValueType.StringValue Then

                                GroupSetting.StringValue = ParsedSettingValue

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.NumericValue Then

                                GroupSetting.NumericValue = ParsedSettingValue

                            ElseIf SecuritySettingAttribute.ValueType = SettingsValueType.DateValue Then

                                GroupSetting.DateValue = ParsedSettingValue

                            End If

                            Saved = AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                        End If

                    End If

                End If

            Catch ex As Exception
                Saved = False
            Finally
                SaveSetting = Saved
            End Try

        End Function
        Private Function LoadSetting(ByVal SecuritySession As AdvantageFramework.Security.Session, ByVal ID As Integer, ByVal SettingType As System.Type, ByVal Setting As String) As Object

            'objects
            Dim SettingEntity As Object = Nothing
            Dim SecuritySettingAttribute As AdvantageFramework.Security.Attributes.SecuritySettingAttribute = Nothing
            Dim SettingValue As Object = Nothing
            Dim GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser = Nothing
            Dim User As AdvantageFramework.Security.Classes.User = Nothing

            Try

                Try

                    SecuritySettingAttribute = System.Attribute.GetCustomAttribute(SettingType.GetField(Setting.ToString), GetType(AdvantageFramework.Security.Attributes.SecuritySettingAttribute))

                Catch ex As Exception

                End Try

                If SecuritySettingAttribute IsNot Nothing Then

                    If SettingType.Name = GetType(AdvantageFramework.Security.UserSettings).Name Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                            Try

                                SettingEntity = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, ID, Setting)

                            Catch ex As Exception
                                SettingEntity = Nothing
                            End Try

                        End Using

                    Else

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                            Try

                                SettingEntity = AdvantageFramework.Security.Database.Procedures.GroupSetting.LoadByGroupIDAndSettingCode(SecurityDbContext, ID, Setting)

                            Catch ex As Exception
                                SettingEntity = Nothing
                            End Try

                        End Using

                    End If

                    If SettingEntity IsNot Nothing Then

                        Select Case SecuritySettingAttribute.ValueType

                            Case SettingsValueType.StringValue

                                Select Case SecuritySettingAttribute.ParseValueType

                                    Case SettingsParseValueType.String_Boolean_YN

                                        If SettingEntity.StringValue = "Y" Then

                                            SettingValue = True

                                        Else

                                            SettingValue = False

                                        End If

                                    Case Else

                                        SettingValue = SettingEntity.StringValue

                                End Select

                            Case SettingsValueType.NumericValue

                                Select Case SecuritySettingAttribute.ParseValueType

                                    Case SettingsParseValueType.Numeric_Boolean_10

                                        If SettingEntity.NumericValue = 1 Then

                                            SettingValue = True

                                        Else

                                            SettingValue = False

                                        End If

                                    Case Else

                                        SettingValue = SettingEntity.NumericValue

                                End Select

                            Case SettingsValueType.DateValue

                                SettingValue = SettingEntity.DateValue

                        End Select

                    Else

                        Select Case SecuritySettingAttribute.ParseValueType

                            Case SettingsParseValueType.Default

                                SettingValue = SecuritySettingAttribute.DefaultValue

                            Case SettingsParseValueType.Numeric_Boolean_10

                                If IsNumeric(SecuritySettingAttribute.DefaultValue) Then

                                    SettingValue = CBool(SecuritySettingAttribute.DefaultValue)

                                Else

                                    SettingValue = False

                                End If

                            Case SettingsParseValueType.String_Boolean_YN

                                If SecuritySettingAttribute.DefaultValue = "N" Then

                                    SettingValue = False

                                Else

                                    SettingValue = True

                                End If

                        End Select

                    End If

                End If

            Catch ex As Exception
                SettingValue = Nothing
            Finally
                LoadSetting = SettingValue
            End Try

        End Function
        Public Function LoadUserSetting(ByVal SecuritySession As AdvantageFramework.Security.Session, UserID As Integer, UserSetting As AdvantageFramework.Security.UserSettings) As Object

            LoadUserSetting = LoadSetting(SecuritySession, UserID, GetType(AdvantageFramework.Security.UserSettings), UserSetting.ToString)

        End Function
        Public Function LoadGroupSetting(ByVal SecuritySession As AdvantageFramework.Security.Session, GroupID As Integer, GroupSetting As AdvantageFramework.Security.GroupSettings) As Object

            LoadGroupSetting = LoadSetting(SecuritySession, GroupID, GetType(AdvantageFramework.Security.GroupSettings), GroupSetting.ToString)

        End Function
        Public Function LoadUserGroupSetting(ByVal SecuritySession As AdvantageFramework.Security.Session, GroupSetting As AdvantageFramework.Security.GroupSettings) As Generic.List(Of Object)

            'objects
            Dim SettingValues As Generic.List(Of Object) = Nothing
            Dim User As AdvantageFramework.Security.Classes.User = Nothing
            Dim CPUser As AdvantageFramework.Security.Classes.ClientPortalUser = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                If SecuritySession.Application = Application.Client_Portal Then

                    CPUser = SecuritySession.ClientPortalUser

                Else

                    User = SecuritySession.User

                End If

                SettingValues = New Generic.List(Of Object)

                If SecuritySession.Application <> Application.Client_Portal Then

                    For Each GroupUser In AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).ToList

                        SettingValues.Add(LoadSetting(SecuritySession, GroupUser.GroupID, GetType(AdvantageFramework.Security.GroupSettings), GroupSetting.ToString))

                    Next

                End If

            End Using

            LoadUserGroupSetting = SettingValues

        End Function
        Public Function LoadUserGroupSetting(ConnectionString As String, UserCode As String, Application As Security.Application, GroupSetting As AdvantageFramework.Security.GroupSettings) As Generic.List(Of Object)

            'objects
            Dim SettingValues As Generic.List(Of Object) = Nothing
            Dim User As AdvantageFramework.Security.Classes.User = Nothing
            Dim SecuritySession As AdvantageFramework.Security.Session = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                SettingValues = New Generic.List(Of Object)

                If Application <> Application.Client_Portal Then

                    User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode))

                    If User IsNot Nothing Then

                        SecuritySession = New Security.Session(Application, ConnectionString, UserCode, 0, ConnectionString)

                        For Each GroupUser In AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).ToList

                            SettingValues.Add(LoadSetting(SecuritySession, GroupUser.GroupID, GetType(AdvantageFramework.Security.GroupSettings), GroupSetting.ToString))

                        Next

                    End If

                End If

            End Using

            LoadUserGroupSetting = SettingValues

        End Function
        Public Function LoadDescriptionForModule(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal [Module] As AdvantageFramework.Security.Database.Views.ModuleView) As String

            'objects
            Dim ModuleDescription As String = ""

            If [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom1.ToString OrElse
                    [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom2.ToString OrElse
                    [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom3.ToString OrElse
                    [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom4.ToString OrElse
                    [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom5.ToString Then

                Try

                    ModuleDescription = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV{0}'", [Module].ModuleCode.Substring([Module].ModuleCode.Length - 1))).FirstOrDefault

                Catch ex As Exception
                    ModuleDescription = ""
                End Try

            ElseIf [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom1.ToString OrElse
                    [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom2.ToString OrElse
                    [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom3.ToString OrElse
                    [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom4.ToString OrElse
                    [Module].ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom5.ToString Then

                Try

                    ModuleDescription = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV{0}'", [Module].ModuleCode.Substring([Module].ModuleCode.Length - 1))).FirstOrDefault

                Catch ex As Exception
                    ModuleDescription = ""
                End Try

            End If

            If ModuleDescription = "" Then

                ModuleDescription = [Module].ModuleDescription

            End If

            LoadDescriptionForModule = ModuleDescription

        End Function
        Public Function LoadDescriptionForModule(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal [Module] As AdvantageFramework.Security.Database.Entities.Module) As String

            'objects
            Dim ModuleDescription As String = ""

            If [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom1.ToString OrElse
                    [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom2.ToString OrElse
                    [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom3.ToString OrElse
                    [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom4.ToString OrElse
                    [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom5.ToString Then

                Try

                    ModuleDescription = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV{0}'", [Module].Code.Substring([Module].Code.Length - 1))).FirstOrDefault

                Catch ex As Exception
                    ModuleDescription = ""
                End Try

            ElseIf [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom1.ToString OrElse
                    [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom2.ToString OrElse
                    [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom3.ToString OrElse
                    [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom4.ToString OrElse
                    [Module].Code = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom5.ToString Then

                Try

                    ModuleDescription = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV{0}'", [Module].Code.Substring([Module].Code.Length - 1))).FirstOrDefault

                Catch ex As Exception
                    ModuleDescription = ""
                End Try

            End If

            If ModuleDescription = "" Then

                ModuleDescription = [Module].Description

            End If

            LoadDescriptionForModule = ModuleDescription

        End Function
        Public Function LoadImageForModule(ByVal [Module] As AdvantageFramework.Security.Database.Entities.Module) As System.Drawing.Image

            'objects
            Dim ImageObject As Object = Nothing
            Dim Graphic As System.Drawing.Graphics = Nothing
            Dim FinalImage As System.Drawing.Image = Nothing
            Dim InsertDefaultImage As Boolean = True

            If [Module] IsNot Nothing Then

                Try

                    ImageObject = AdvantageFramework.Images.LoadResource([Module].ModuleInformation.ImageName)

                Catch ex As Exception
                    ImageObject = Nothing
                End Try

                If ImageObject IsNot Nothing Then

                    InsertDefaultImage = False

                    Try

                        If DirectCast(ImageObject, System.Drawing.Bitmap).Size.Height <> 32 OrElse DirectCast(ImageObject, System.Drawing.Bitmap).Size.Width <> 32 Then

                            FinalImage = New System.Drawing.Bitmap(32, 32)

                            Graphic = System.Drawing.Graphics.FromImage(FinalImage)

                            Graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
                            Graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
                            Graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

                            Graphic.DrawImage(ImageObject, 0, 0, 32, 32)

                        Else

                            FinalImage = ImageObject

                        End If

                    Catch ex As Exception
                        InsertDefaultImage = True
                    End Try

                End If

                If InsertDefaultImage Then

                    If [Module].IsApplication Then

                        FinalImage = AdvantageFramework.My.Resources.ApplicationImage

                    ElseIf [Module].IsReport Then

                        FinalImage = AdvantageFramework.My.Resources.ReportImage

                    ElseIf [Module].IsDashQuery Then

                        FinalImage = AdvantageFramework.My.Resources.DashboardAndQueryImage

                    ElseIf [Module].IsDesktopObject Then

                        FinalImage = AdvantageFramework.My.Resources.DesktopObjectImage

                    ElseIf [Module].IsCategory Then

                        FinalImage = AdvantageFramework.My.Resources.CategoryImage

                    End If

                End If

            End If

            LoadImageForModule = FinalImage

        End Function
        Public Function LoadImageForModule(ByVal [Module] As AdvantageFramework.Security.Database.Views.ModuleView) As System.Drawing.Image

            'objects
            Dim ImageObject As Object = Nothing
            Dim Graphic As System.Drawing.Graphics = Nothing
            Dim FinalImage As System.Drawing.Image = Nothing
            Dim InsertDefaultImage As Boolean = True

            If [Module] IsNot Nothing Then

                Try

                    ImageObject = AdvantageFramework.Images.LoadResource([Module].ImageName)

                Catch ex As Exception
                    ImageObject = Nothing
                End Try

                If ImageObject IsNot Nothing Then

                    InsertDefaultImage = False

                    Try

                        If DirectCast(ImageObject, System.Drawing.Bitmap).Size.Height <> 32 OrElse DirectCast(ImageObject, System.Drawing.Bitmap).Size.Width <> 32 Then

                            FinalImage = New System.Drawing.Bitmap(32, 32)

                            Graphic = System.Drawing.Graphics.FromImage(FinalImage)

                            Graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
                            Graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
                            Graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

                            Graphic.DrawImage(ImageObject, 0, 0, 32, 32)

                        Else

                            FinalImage = ImageObject

                        End If

                    Catch ex As Exception
                        InsertDefaultImage = True
                    End Try

                End If

                If InsertDefaultImage Then

                    If [Module].IsApplication Then

                        FinalImage = AdvantageFramework.My.Resources.ApplicationImage

                    ElseIf [Module].IsReport Then

                        FinalImage = AdvantageFramework.My.Resources.ReportImage

                    ElseIf [Module].IsDashQuery Then

                        FinalImage = AdvantageFramework.My.Resources.DashboardAndQueryImage

                    ElseIf [Module].IsDesktopObject Then

                        FinalImage = AdvantageFramework.My.Resources.DesktopObjectImage

                    ElseIf [Module].IsCategory Then

                        FinalImage = AdvantageFramework.My.Resources.CategoryImage

                    End If

                End If

            End If

            LoadImageForModule = FinalImage

        End Function
        Public Function LoadImageNameForModule(ByVal [Module] As AdvantageFramework.Security.Database.Views.ModuleView, ByVal UseIconFiles As Boolean) As String

            'objects
            Dim ImageName As String = Nothing

            If [Module] IsNot Nothing Then

                ImageName = [Module].ImageName

                If ImageName = "" Then

                    If [Module].IsApplication Then

                        If [Module].WebvantageImagePathActive <> "" Then

                            ImageName = [Module].WebvantageImagePathActive

                        Else

                            If UseIconFiles Then

                                ImageName = "ApplicationIcon.ico"

                            Else

                                ImageName = "ApplicationImage.png"

                            End If

                        End If

                    ElseIf [Module].IsReport Then

                        If [Module].ReportImagePathActive <> "" Then

                            ImageName = [Module].ReportImagePathActive

                        Else

                            If UseIconFiles Then

                                ImageName = "ReportIcon.ico"

                            Else

                                ImageName = "ReportImage.png"

                            End If

                        End If

                    ElseIf [Module].IsDashQuery Then

                        If [Module].WebvantageImagePathActive <> "" Then

                            ImageName = [Module].WebvantageImagePathActive

                        Else

                            If UseIconFiles Then

                                ImageName = "DashboardAndQueryIcon.ico"

                            Else

                                ImageName = "DashboardAndQueryImage.png"

                            End If

                        End If

                    ElseIf [Module].IsDesktopObject Then

                        If UseIconFiles Then

                            ImageName = "DesktopObjectIcon.ico"

                        Else

                            ImageName = "DesktopObjectImage.png"

                        End If

                    ElseIf [Module].IsCategory Then

                        If UseIconFiles Then

                            ImageName = "CategoryIcon.ico"

                        Else

                            ImageName = "CategoryImage.png"

                        End If

                    End If

                Else

                    If UseIconFiles Then

                        ImageName = ImageName.Substring(0, ImageName.IndexOf(".")).Replace("Image", "Icon") & ".ico"

                    End If

                End If

            End If

            LoadImageNameForModule = ImageName

        End Function
        Public Function CanUserCustom1InModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom1

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom1

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom1

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom1

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, [Module].ToString, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, [Module].ToString, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, ModuleID, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, ModuleCode, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom1InModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom1

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom1InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom2

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom2

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom2

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom2

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, [Module].ToString, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, [Module].ToString, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, ModuleID, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, ModuleCode, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserCustom2InModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.Custom2

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserCustom2InModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanAdd

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanAdd

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanAdd

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer,
                                           UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                Try

                    UserPermission = (From Entity In UserPermissionList
                                      Where Entity.ApplicationID = ApplicationID AndAlso
                                            Entity.ModuleCode = ModuleCode AndAlso
                                            Entity.UserID = UserID
                                      Select Entity).SingleOrDefault

                Catch ex As Exception
                    UserPermission = Nothing
                End Try

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanAdd

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanAdd

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, [Module].ToString, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, [Module].ToString, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, ModuleID, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, ModuleCode, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserAddInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanAdd

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserAddInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanUpdate

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanUpdate

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanUpdate

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanUpdate

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, [Module].ToString, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, [Module].ToString, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, ModuleID, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, ModuleCode, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserUpdateInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanUpdate

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserUpdateInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanPrint

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanPrint

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanPrint

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID)

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanPrint

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, [Module].ToString, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, [Module].ToString, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, ModuleID, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, ModuleCode, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function CanUserPrintInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                If UserPermission IsNot Nothing Then

                    HasAccess = UserPermission.CanPrint

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            CanUserPrintInModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                HasAccess = DoesUserHaveAccessToModule(AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode))

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                HasAccess = DoesUserHaveAccessToModule(AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode))

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                HasAccess = DoesUserHaveAccessToModule(AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID))

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer,
                                                   UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

            Try

                UserPermission = (From Entity In UserPermissionList
                                  Where Entity.ApplicationID = ApplicationID AndAlso
                                        Entity.ModuleCode = ModuleCode AndAlso
                                        Entity.UserID = UserID
                                  Select Entity).SingleOrDefault

            Catch ex As Exception
                UserPermission = Nothing
            End Try

            Try

                HasAccess = DoesUserHaveAccessToModule(UserPermission)

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                HasAccess = DoesUserHaveAccessToModule(AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID))

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                If UserPermission IsNot Nothing Then

                    HasAccess = Not UserPermission.IsBlocked

                End If

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, [Module].ToString, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal Session As AdvantageFramework.Security.Session, ByVal [Module] As AdvantageFramework.Security.Modules, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, [Module].ToString, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleID As Integer, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleID, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String, ByVal User As AdvantageFramework.Security.Classes.User) As Boolean

            'objects
            Dim HasAccess As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleCode, User.ID)

                End Using

            Catch ex As Exception
                HasAccess = False
            End Try

            DoesUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesUserHaveAccessToApplication(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                        ByVal User As AdvantageFramework.Security.Classes.User,
                                                        ByVal Application As AdvantageFramework.Security.Application) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess = Nothing
            Dim GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess = Nothing

            If User IsNot Nothing Then

                Dim GroupUsers As Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupUser)

                GroupUsers = Nothing
                GroupUsers = AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).ToList

                For Each GroupModuleAccess In GroupUsers.SelectMany(Function(GroupUser) GroupUser.Group.GroupApplicationAccesses).Where(Function(GrpAppAccess) GrpAppAccess.ApplicationID = Application).ToList

                    If GroupModuleAccess IsNot Nothing AndAlso GroupModuleAccess.IsBlocked = False Then

                        HasAccess = True
                        Exit For

                    End If

                Next

                If HasAccess = False AndAlso (User.CheckForUserAccess OrElse
                                              GroupUsers.Count = 0) Then

                    Try

                        UserApplicationAccess = Nothing
                        UserApplicationAccess = AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.LoadByApplicationIDAndUserID(SecurityDbContext, Application, User.ID)

                    Catch ex As Exception
                        UserApplicationAccess = Nothing
                    End Try

                    If UserApplicationAccess IsNot Nothing AndAlso UserApplicationAccess.IsBlocked = False Then

                        HasAccess = True

                    End If

                End If

            End If

            DoesUserHaveAccessToApplication = HasAccess

        End Function
        Public Function DoesClientPortalUserHaveAccessToModule(ByVal Session As AdvantageFramework.Security.Session, ByVal ModuleCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim [Module] As AdvantageFramework.Security.Database.Entities.Module = Nothing
            Dim ClientPortalUserModuleAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess = Nothing

            If Session IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    [Module] = AdvantageFramework.Security.Database.Procedures.Module.LoadByModuleCode(SecurityDbContext, ModuleCode)

                    If [Module] IsNot Nothing Then

                        If Session.ClientPortalUser IsNot Nothing Then

                            Try

                                ClientPortalUserModuleAccess = AdvantageFramework.Security.Database.Procedures.ClientPortalUserModuleAccess.LoadByModuleIDAndClientPortalUserID(SecurityDbContext, [Module].ID, Session.ClientPortalUser.ID)

                            Catch ex As Exception
                                ClientPortalUserModuleAccess = Nothing
                            End Try

                            If ClientPortalUserModuleAccess IsNot Nothing AndAlso ClientPortalUserModuleAccess.IsBlocked = False Then

                                HasAccess = True

                            End If

                        End If

                    End If

                End Using

            End If

            DoesClientPortalUserHaveAccessToModule = HasAccess

        End Function
        Public Function DoesClientPortalUserHaveAccessToApplication(ByVal ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser, ByVal Application As AdvantageFramework.Security.Application) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim ClientPortalUserApplicationAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess = Nothing

            If ClientPortalUser IsNot Nothing Then

                Try

                    ClientPortalUserApplicationAccess = ClientPortalUser.ClientPortalUserApplicationAccesses.SingleOrDefault(Function(CPUAppAccess) CPUAppAccess.ApplicationID = Application)

                Catch ex As Exception
                    ClientPortalUserApplicationAccess = Nothing
                End Try

                If ClientPortalUserApplicationAccess IsNot Nothing AndAlso ClientPortalUserApplicationAccess.IsBlocked = False Then

                    HasAccess = True

                End If

            End If

            DoesClientPortalUserHaveAccessToApplication = HasAccess

        End Function
        Public Function DoesUserHaveAccessToUserDefinedReport(ByVal Session As AdvantageFramework.Security.Session, ByVal UserDefinedReportID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim User As AdvantageFramework.Security.Classes.User = Nothing
            Dim UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess = Nothing
            Dim GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, Session.User.ID))

                If User IsNot Nothing Then

                    For Each [Group] In AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).Select(Function(GroupUser) GroupUser.Group)

                        Try

                            GroupUserDefinedReportAccess = [Group].GroupUserDefinedReportAccesses.SingleOrDefault(Function(GroupUDRAccess) GroupUDRAccess.UserDefinedReportID = UserDefinedReportID)

                        Catch ex As Exception
                            GroupUserDefinedReportAccess = Nothing
                        End Try

                        If GroupUserDefinedReportAccess IsNot Nothing AndAlso GroupUserDefinedReportAccess.IsBlocked = False Then

                            HasAccess = True
                            Exit For

                        End If

                    Next

                    If HasAccess = False AndAlso (User.CheckForUserAccess OrElse
                                                  AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).Count = 0) Then

                        Try

                            UserUserDefinedReportAccess = AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.LoadByUserDefinedReportIDAndUserID(SecurityDbContext, UserDefinedReportID, User.ID)

                        Catch ex As Exception
                            UserUserDefinedReportAccess = Nothing
                        End Try

                        If UserUserDefinedReportAccess IsNot Nothing AndAlso UserUserDefinedReportAccess.IsBlocked = False Then

                            HasAccess = True

                        End If

                    End If

                End If

            End Using

            DoesUserHaveAccessToUserDefinedReport = HasAccess

        End Function
        Public Function DoesUserHaveAccessToUserDefinedEstimateReport(ByVal Session As AdvantageFramework.Security.Session, ByVal EstimateReportID As Integer) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim User As AdvantageFramework.Security.Classes.User = Nothing
            Dim UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess = Nothing
            Dim GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, Session.User.ID))

                If User IsNot Nothing Then

                    For Each [Group] In AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).Select(Function(GroupUser) GroupUser.Group)

                        Try

                            GroupUserDefinedReportAccess = [Group].GroupUserDefinedReportAccesses.SingleOrDefault(Function(GroupUDRAccess) GroupUDRAccess.UserDefinedReportID = EstimateReportID)

                        Catch ex As Exception
                            GroupUserDefinedReportAccess = Nothing
                        End Try

                        If GroupUserDefinedReportAccess IsNot Nothing AndAlso GroupUserDefinedReportAccess.IsBlocked = False Then

                            HasAccess = True
                            Exit For

                        End If

                    Next

                    If HasAccess = False AndAlso (User.CheckForUserAccess OrElse
                                                  AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).Count = 0) Then

                        Try

                            UserUserDefinedReportAccess = AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.LoadByUserDefinedReportIDAndUserID(SecurityDbContext, EstimateReportID, User.ID)

                        Catch ex As Exception
                            UserUserDefinedReportAccess = Nothing
                        End Try

                        If UserUserDefinedReportAccess IsNot Nothing AndAlso UserUserDefinedReportAccess.IsBlocked = False Then

                            HasAccess = True

                        End If

                    End If

                End If

            End Using

            DoesUserHaveAccessToUserDefinedEstimateReport = HasAccess

        End Function
        Public Function DoesUserHaveAccessToReport(ByVal Session As AdvantageFramework.Security.Session, ByVal ReportCode As String) As Boolean

            'objects
            Dim HasAccess As Boolean = False
            Dim User As AdvantageFramework.Security.Classes.User = Nothing
            Dim ReportAccess As AdvantageFramework.Security.Database.Entities.ReportAccess = Nothing

            If Session.IsTimeEntryOnly = False Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, Session.User.ID))

                    If User IsNot Nothing Then

                        ReportAccess = AdvantageFramework.Security.Database.Procedures.ReportAccess.LoadByUserCodeAndReportCode(SecurityDbContext, User.UserCode, ReportCode)

                        If ReportAccess IsNot Nothing AndAlso ReportAccess.Enabled Is Nothing Then

                            HasAccess = True

                        End If

                    End If

                End Using

            End If

            DoesUserHaveAccessToReport = HasAccess

        End Function
        Public Function GetIPAddress() As String

            'objects
            Dim IPAddress As String = String.Empty
            Dim IPHostEntry As System.Net.IPHostEntry = Nothing

            Try

                IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName())

                For Each IPAddressEntry In IPHostEntry.AddressList

                    If IPAddressEntry.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then

                        IPAddress = IPAddressEntry.ToString
                        Exit For

                    End If

                Next

            Catch ex As Exception
                IPAddress = String.Empty
            End Try

            GetIPAddress = IPAddress

        End Function
        Public Function GetMACAddress() As String

            'objects
            Dim MACAddress As String = String.Empty
            Dim ManagementClass As System.Management.ManagementClass = Nothing
            Dim EnumerationOptions As System.Management.EnumerationOptions = Nothing
            Dim ManagementObject As System.Management.ManagementObject = Nothing
            Dim ManagementObjectCollection As System.Management.ManagementObjectCollection = Nothing
            Dim NetworkInterfaces() As System.Net.NetworkInformation.NetworkInterface = Nothing
            Dim PhysicalAddress As System.Net.NetworkInformation.PhysicalAddress = Nothing

            Try

                ManagementClass = New System.Management.ManagementClass("Win32_NetworkAdapterConfiguration")

                EnumerationOptions = New System.Management.EnumerationOptions
                EnumerationOptions.ReturnImmediately = True
                EnumerationOptions.Rewindable = False

                ManagementObjectCollection = ManagementClass.GetInstances(EnumerationOptions)

                For Each ManagementObject In ManagementObjectCollection

                    If ManagementObject.Item("IPEnabled") = True Then

                        MACAddress = ManagementObject.Item("MacAddress")
                        Exit For

                    End If

                Next

            Catch ex As Exception
                MACAddress = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(MACAddress) = False Then

                MACAddress = MACAddress.Replace(":", "")

            End If

            Try

                If ManagementObject IsNot Nothing Then

                    Try

                        ManagementObject.Dispose()

                    Catch ex As Exception

                    End Try

                End If

                ManagementObject = Nothing

                If ManagementObjectCollection IsNot Nothing Then

                    Try

                        ManagementObjectCollection.Dispose()

                    Catch ex As Exception

                    End Try

                End If

                ManagementObjectCollection = Nothing

                If ManagementClass IsNot Nothing Then

                    Try

                        ManagementClass.Dispose()

                    Catch ex As Exception

                    End Try

                End If

                ManagementClass = Nothing

            Catch ex As Exception

            End Try

            If String.IsNullOrWhiteSpace(MACAddress) Then

                Try

                    NetworkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces

                    For Each NetworkInterface In NetworkInterfaces

                        If NetworkInterface.OperationalStatus = Net.NetworkInformation.OperationalStatus.Up Then

                            Try

                                PhysicalAddress = NetworkInterface.GetPhysicalAddress

                            Catch ex As Exception
                                PhysicalAddress = Nothing
                            End Try

                            If PhysicalAddress IsNot Nothing Then

                                MACAddress = PhysicalAddress.ToString()
                                Exit For

                            End If

                        End If

                    Next

                Catch ex As Exception
                    MACAddress = String.Empty
                End Try

            End If

            Try

                NetworkInterfaces = Nothing
                PhysicalAddress = Nothing

            Catch ex As Exception

            End Try

            GetMACAddress = MACAddress

        End Function
        Public Function Login(ByVal Application As AdvantageFramework.Security.Application,
                              ByRef DbContext As AdvantageFramework.Database.DbContext,
                              ByRef Session As AdvantageFramework.Security.Session,
                              ByVal ServerName As String,
                              ByVal DatabaseName As String,
                              ByVal UseWindowsAuthentication As Boolean,
                              ByVal UserName As String,
                              ByVal Password As String,
                              ByVal ClientPortalUserName As String,
                              ByVal ClientPortalPassword As String,
                              ByVal SessionID As String,
                              ByVal IPAddress As String,
                              ByVal SSConnectionString As String,
                              ByVal SSUserName As String,
                              ByRef ErrorMessage As String) As Boolean

            'objects
            Dim LoginSuccessful As Boolean = False
            Dim ConnectionString As String = ""
            Dim ApplicationEntity As AdvantageFramework.Security.Database.Entities.Application = Nothing
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
            Dim SecurityDbContext As AdvantageFramework.Security.Database.DbContext = Nothing
            Dim Version As String = ""
            Dim DatabaseVersion As String = ""
            Dim VersionKeys() As String = Nothing
            Dim IsScriptInDB As Integer = 0
            Dim MinimumVersion As String = ""
            Dim MaximumVersion As String = ""
            Dim AdvantageUserLicenseInUseID As Integer = 0

            If Application = Methods.Application.Webvantage Then

                LoginSuccessful = Login(Application, DbContext, Session, ServerName, DatabaseName,
                                        UseWindowsAuthentication, UserName, Password, SessionID, IPAddress, SSConnectionString, SSUserName, ErrorMessage)

            ElseIf Application = Methods.Application.Client_Portal Then

                If AdvantageFramework.Database.ValidateServerAndDatabase(ServerName, DatabaseName, UseWindowsAuthentication, ClientPortalUserName, ClientPortalPassword, Application.ToString, True, ErrorMessage) Then

                    ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName, DatabaseName, UseWindowsAuthentication, ClientPortalUserName, ClientPortalPassword, Application.ToString)

                    If AdvantageFramework.Database.TestConnectionString(ConnectionString, ErrorMessage) Then

                        Try

                            SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ClientPortalUserName)

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                            SecurityDbContext = Nothing
                        End Try

                        If SecurityDbContext IsNot Nothing Then

                            ApplicationEntity = AdvantageFramework.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application)

                            ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByUserName(SecurityDbContext, UserName)

                            If ApplicationEntity IsNot Nothing Then

                                If ClientPortalUser IsNot Nothing Then

                                    If DoesClientPortalUserHaveAccessToApplication(ClientPortalUser, Methods.Application.Client_Portal) Then

                                        DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserName)

                                        If ClientPortalUser.ClientContact.IsInactive.GetValueOrDefault(0) = 0 Then

                                            Version = System.Configuration.ConfigurationManager.AppSettings("VCtrl")
                                            DatabaseVersion = SecurityDbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

                                            If Version = "##DEV##" Then

                                                LoginSuccessful = True

                                            ElseIf Version <> "##DEV##" Then

                                                Version = DecryptVersionKey("VersionEncryptor2007", Version)

                                                VersionKeys = Version.Split("|")

                                                MinimumVersion = VersionKeys(2).ToString().Trim()
                                                MaximumVersion = VersionKeys(3).ToString().Trim()

                                                If DatabaseVersion >= MinimumVersion OrElse DatabaseVersion <= MaximumVersion Then

                                                    LoginSuccessful = True

                                                Else

                                                    ErrorMessage = "The Advantage database version is not compatible with the Webvantage database version!"

                                                End If

                                            End If

                                            If LoginSuccessful Then

                                                If ClientPortalUser.Password = AdvantageFramework.Security.Encryption.GenerateSHA256ManagedHash(Password) Then

                                                    'If ClientPortalUser.IsLocked Then

                                                    '    If ClientPortalUser.UnlockedDate <= Now Then

                                                    '        ClientPortalUser.LoginsAttempted = 0
                                                    '        ClientPortalUser.LastLoginDate = Now
                                                    '        ClientPortalUser.IsLocked = False

                                                    '        LoginSuccessful = True

                                                    '    Else

                                                    '        ClientPortalUser.LoginsAttempted += 1
                                                    '        ClientPortalUser.UnlockedDate = Now.AddMinutes(10)

                                                    '        ErrorMessage = "For your security, your account has been locked out due to excessive incorrect password tries. In order to unlock your account please contact System Adminstrator to recover your password."

                                                    '        LoginSuccessful = False

                                                    '    End If

                                                    'Else

                                                    ClientPortalUser.LoginsAttempted = 0
                                                    ClientPortalUser.LastLoginDate = Now
                                                    ClientPortalUser.IsLocked = False

                                                    LoginSuccessful = True

                                                    'End If

                                                Else

                                                    'ClientPortalUser.LoginsAttempted += 1

                                                    'If ClientPortalUser.LoginsAttempted > 3 Then

                                                    '    ClientPortalUser.IsLocked = True
                                                    '    ClientPortalUser.UnlockedDate = Now.AddMinutes(30)

                                                    '    ErrorMessage = "For your security, your account has been locked out due to excessive incorrect password tries. In order to unlock your account please contact System Adminstrator to recover your password."

                                                    'Else

                                                    ErrorMessage = "Invalid Client Portal username/password combination."

                                                    'End If

                                                    LoginSuccessful = False

                                                End If

                                                AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Update(SecurityDbContext, ClientPortalUser)

                                                If LoginSuccessful Then

                                                    Dim ClientPortalUserClass As AdvantageFramework.Security.Classes.ClientPortalUser

                                                    ClientPortalUserClass = Nothing
                                                    ClientPortalUserClass = New AdvantageFramework.Security.Classes.ClientPortalUser(ClientPortalUser)

                                                    If AdvantageFramework.Security.LicenseKey.Validate(DbContext, Nothing, ClientPortalUserClass, ApplicationEntity.ID, "", SessionID, ErrorMessage, AdvantageUserLicenseInUseID) Then

                                                        LoginSuccessful = True
                                                        Session = New AdvantageFramework.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, ClientPortalUserName, ClientPortalPassword, UserName, AdvantageUserLicenseInUseID, SSConnectionString)

                                                    Else

                                                        LoginSuccessful = False

                                                    End If

                                                End If

                                            End If

                                        Else

                                            ErrorMessage = "Client Portal User is marked as inactive - Access denied"

                                        End If

                                    Else

                                        ErrorMessage = "Access denied"

                                    End If

                                Else

                                    ErrorMessage = "Client Portal User does not exist - Access denied"

                                End If

                            Else

                                ErrorMessage = "Application not found - Access denied"

                            End If

                            If SecurityDbContext IsNot Nothing Then

                                SecurityDbContext.Dispose()
                                SecurityDbContext = Nothing

                            End If

                        Else

                            ErrorMessage = "Please verify that you are connecting to the correct server and database and that your login username and password is correct."

                        End If

                    End If

                End If

            End If

            Return LoginSuccessful

        End Function
        Public Function Login(ByVal Application As AdvantageFramework.Security.Application,
                              ByRef DbContext As AdvantageFramework.Database.DbContext,
                              ByRef Session As AdvantageFramework.Security.Session,
                              ByVal ServerName As String,
                              ByVal DatabaseName As String,
                              ByVal UseWindowsAuthentication As Boolean,
                              ByVal UserName As String,
                              ByVal Password As String,
                              ByVal MACAddressOrSessionID As String,
                              ByVal IPAddress As String,
                              ByVal ConnectionString As String,
                              ByVal ConnectionUserName As String,
                              ByRef ErrorMessage As String) As Boolean

            'objects
            Dim SecurityDbContext As AdvantageFramework.Security.Database.DbContext = Nothing
            Dim ApplicationEntity As AdvantageFramework.Security.Database.Entities.Application = Nothing
            Dim User As AdvantageFramework.Security.Classes.User = Nothing
            Dim LoginSuccessful As Boolean = False
            Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
            Dim FullUserName As String = ""
            Dim IsWrongPassword As Boolean = False
            Dim VersionCheckSucessful As Boolean = False

            If String.IsNullOrWhiteSpace(UserName) = True Then

                ErrorMessage = "Please enter User ID."

            Else

                If String.IsNullOrWhiteSpace(ConnectionUserName) = True Then

                    ConnectionUserName = UserName

                End If

                If (Application = AdvantageFramework.Security.Application.Advantage OrElse
                    Application = AdvantageFramework.Security.Application.Advantage_Database_Update) AndAlso
                      String.IsNullOrWhiteSpace(ServerName) = True AndAlso
                      String.IsNullOrWhiteSpace(DatabaseName) = False Then

                    Try

                        ServerName = AdvantageFramework.Database.LoadSimpleDatabaseProfileList.SingleOrDefault(Function(SimpleDatabaseProfile) SimpleDatabaseProfile.DatabaseName = DatabaseName).ServerName

                    Catch ex As Exception
                        ServerName = ""
                    End Try

                End If

                If Application = Application.Advantage_Nielsen_Database_Update OrElse
                        Application = Application.Advantage_Database_Update OrElse
                        Application = Security.Application.Advantage_Update Then

                    ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, Application.ToString)

                End If

                'validate connection string
                If ValidateLoginConnectionString(Application, ConnectionString, ErrorMessage) Then

                    FullUserName = UserName

                    If UseWindowsAuthentication Then

                        If UserName.Contains("\") Then

                            UserName = UserName.Substring(UserName.IndexOf("\") + 1)

                        End If

                    End If

                    Try

                        SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, ConnectionUserName)

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        SecurityDbContext = Nothing
                    End Try

                    If SecurityDbContext IsNot Nothing Then

                        SecurityDbContext.Database.Connection.Open()

                        DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, ConnectionUserName)

                        DbContext.Database.Connection.Open()

                        ''''Per Steve, OK to comment out.
                        ''If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(1) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SEC_USER' AND COLUMN_NAME = 'IS_INACTIVE'").FirstOrDefault = 0 Then

                        ''    Try

                        ''        DbContext.Database.ExecuteSqlCommand("ALTER TABLE [dbo].[SEC_USER] ADD [IS_INACTIVE] [bit] NOT NULL DEFAULT(0)")

                        ''    Catch ex As Exception
                        ''    End Try

                        ''End If

                        If Application = AdvantageFramework.Security.Application.Advantage Then

                            VersionCheckSucessful = VersionCheckAdvantage(DbContext, ErrorMessage)

                        ElseIf Application = AdvantageFramework.Security.Application.Webvantage Then

                            VersionCheckSucessful = VersionCheckWebvantage(DbContext, ErrorMessage)

                        Else

                            VersionCheckSucessful = True

                        End If

                        If VersionCheckSucessful Then

                            If Application = Application.Advantage_Nielsen_Database_Update OrElse
                                    Application = Application.Advantage_Database_Update OrElse
                                    Application = Application.Advantage_Update Then

                                'do nothing

                            Else

                                Try

                                    User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

                                Catch ex As Exception
                                    User = Nothing
                                End Try

                                Try

                                    ApplicationEntity = AdvantageFramework.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application)

                                Catch ex As Exception
                                    ApplicationEntity = Nothing
                                End Try

                            End If

                            If ValidateUser(Application, DbContext, SecurityDbContext, User, ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication,
                                            UserName, Password, IsWrongPassword, ErrorMessage) = True Then

                                If Application = AdvantageFramework.Security.Application.Advantage_Nielsen_Database_Update Then

                                    LoginSuccessful = LoginToNielsenDatabaseUpdate(DbContext, SecurityDbContext, Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, FullUserName, ErrorMessage)

                                ElseIf Application = AdvantageFramework.Security.Application.Advantage_Database_Update Then

                                    LoginSuccessful = LoginToDatabaseUpdate(DbContext, SecurityDbContext, Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, FullUserName, ErrorMessage)

                                ElseIf Application = AdvantageFramework.Security.Application.Advantage_Update Then

                                    LoginSuccessful = LoginToAdvantageUpdate(DbContext, Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, ErrorMessage)

                                Else

                                    'ApplicationEntity = AdvantageFramework.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application)

                                    'User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

                                    If DoesUserHaveAccessToApplication(SecurityDbContext, User, Application) Then

                                        If Application = AdvantageFramework.Security.Application.Advantage Then

                                            If AdvantageFramework.Security.Database.Procedures.PasswordLockout.IsUserLockedOut(SecurityDbContext, User.UserCode, ErrorMessage) = False Then

                                                LoginSuccessful = LoginToAdvantage(ApplicationEntity, DbContext, Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, User, MACAddressOrSessionID, ErrorMessage)

                                            Else

                                                LoginSuccessful = False
                                                ErrorMessage = LoadLockoutMessage(SecurityDbContext, User.UserCode)

                                            End If

                                        ElseIf Application = AdvantageFramework.Security.Application.Webvantage Then

                                            If AdvantageFramework.Security.Database.Procedures.PasswordLockout.IsUserLockedOut(SecurityDbContext, User.UserCode, ErrorMessage) = False Then

                                                LoginSuccessful = LoginToWebvantage(ApplicationEntity, DbContext, Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, User, MACAddressOrSessionID, ErrorMessage)

                                            Else

                                                LoginSuccessful = False
                                                ErrorMessage = LoadLockoutMessage(SecurityDbContext, User.UserCode)

                                            End If

                                        ElseIf Application = AdvantageFramework.Security.Application.Outlook_Addin Then

                                            LoginSuccessful = True

                                            Session = New AdvantageFramework.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, 0, ConnectionString)

                                        End If

                                    Else

                                        ErrorMessage = "Access denied"

                                    End If

                                End If

                            End If

                            If User IsNot Nothing Then

                                If LoginSuccessful = True Then

                                    AdvantageFramework.Security.Database.Procedures.PasswordLockout.ClearByUserCode(SecurityDbContext, User.UserCode)

                                Else

                                    If IsWrongPassword = True Then 'Only log failure if wrong password? (or always?)

                                        AdvantageFramework.Security.Database.Procedures.PasswordLockout.LogFailureByUserCode(SecurityDbContext, User.UserCode)

                                        ErrorMessage = LoadLockoutMessage(SecurityDbContext, User.UserCode)

                                        If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                                            ErrorMessage = AdvantageFramework.Security.Password.IncorrectPasswordMessage

                                        End If

                                    End If

                                End If

                            End If

                        End If

                        CreateUserLoginAuditRecord(SecurityDbContext, Session, UserName, IPAddress, Application, LoginSuccessful, ErrorMessage)

                    Else

                        ErrorMessage = "Please verify that you are connecting to the correct server and database and that your login username and password is correct."

                    End If

                    Try

                        If DbContext IsNot Nothing Then

                            DbContext.Dispose()
                            DbContext = Nothing

                        End If

                    Catch ex As Exception
                    End Try

                    Try

                        If SecurityDbContext IsNot Nothing Then

                            SecurityDbContext.Dispose()
                            SecurityDbContext = Nothing

                        End If

                    Catch ex As Exception
                    End Try

                Else

                    If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                        ErrorMessage = "Cannot connect to the Advantage servers. Please contact software support."

                    Else

                        ErrorMessage = "Cannot connect to the Advantage servers. Please contact software support.  " & ErrorMessage

                    End If

                End If

            End If

            ErrorMessage = AdvantageFramework.StringUtilities.CheckForEndingPunctuation(ErrorMessage)

            Return LoginSuccessful

        End Function
        Private Sub CreateUserLoginAuditRecord(SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                               Session As AdvantageFramework.Security.Session,
                                               UserCode As String,
                                               IPAddress As String,
                                               Application As AdvantageFramework.Security.Application,
                                               LoginSuccessful As Boolean,
                                               ErrorMessage As String)

            Dim UserLoginAudit As AdvantageFramework.Security.Database.Entities.UserLoginAudit = Nothing

            Try

                UserLoginAudit = New AdvantageFramework.Security.Database.Entities.UserLoginAudit

                UserLoginAudit.UserCode = UserCode
                UserLoginAudit.IPAddress = IPAddress
                UserLoginAudit.ApplicationID = Application
                UserLoginAudit.LoginDateTime = Now
                UserLoginAudit.LogoutDateTime = Date.MinValue

                If LoginSuccessful Then

                    UserLoginAudit.Successful = True
                    UserLoginAudit.FailureReason = ""

                Else

                    UserLoginAudit.Successful = False
                    UserLoginAudit.FailureReason = ErrorMessage

                End If

                SecurityDbContext.UserLoginAudits.Add(UserLoginAudit)

                SecurityDbContext.SaveChanges()

            Catch ex As Exception

            End Try

            If LoginSuccessful AndAlso UserLoginAudit.ID > 0 AndAlso Session IsNot Nothing Then

                Session.UserLoginAuditID = UserLoginAudit.ID

            End If

        End Sub
        Public Sub SetUserLogoutAuditRecord(Session As AdvantageFramework.Security.Session)

            Dim UserLoginAudit As AdvantageFramework.Security.Database.Entities.UserLoginAudit = Nothing

            If Session IsNot Nothing AndAlso Session.UserLoginAuditID > 0 Then

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        UserLoginAudit = SecurityDbContext.UserLoginAudits.Find(Session.UserLoginAuditID)

                        If UserLoginAudit IsNot Nothing Then

                            UserLoginAudit.LogoutDateTime = Now

                        End If

                        SecurityDbContext.SaveChanges()

                    End Using

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Function LoginToAdvantageUpdate(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                ByRef Session As AdvantageFramework.Security.Session, ServerName As String,
                                                DatabaseName As String, UseWindowsAuthentication As Boolean, UserName As String,
                                                Password As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim LoginSuccessful As Boolean = False

            If DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault <> 0 Then

                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.ADVAN_UPDATE WHERE VERSION_ID IS NULL").FirstOrDefault = 0 Then

                    LoginSuccessful = True

                    Session = New AdvantageFramework.Security.Session(Application.Advantage_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, 0, DbContext.ConnectionString)

                Else

                    ErrorMessage = "The previous update failed and the database has not been restored. Please restore the database."

                End If

            Else

                ErrorMessage = "You must be an server admin to have access to this application."

            End If

            LoginToAdvantageUpdate = LoginSuccessful

        End Function
        Private Function LoginToNielsenDatabaseUpdate(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                      ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                      ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String,
                                                      ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String,
                                                      ByVal Password As String, ByVal FullUserName As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim LoginSuccessful As Boolean = False
            Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing

            'User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

            If DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('serveradmin'), 0)").FirstOrDefault = 1 Then

                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ADVAN_UPDATE' ").FirstOrDefault = 0 Then

                    LoginSuccessful = True

                    Session = New AdvantageFramework.Security.Session(Application.Advantage_Nielsen_Database_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, 0, SecurityDbContext.ConnectionString)

                Else

                    If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.ADVAN_UPDATE WHERE VERSION_ID = ''").FirstOrDefault = 0 Then

                        LoginSuccessful = True

                        Session = New AdvantageFramework.Security.Session(Application.Advantage_Nielsen_Database_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, 0, SecurityDbContext.ConnectionString)

                    Else

                        ErrorMessage = "The previous update failed and the database has not been restored. Please restore the database."

                    End If

                End If

            Else

                ErrorMessage = "You must be an server admin to have access to this application."

            End If

            LoginToNielsenDatabaseUpdate = LoginSuccessful

        End Function
        Private Function LoginToDatabaseUpdate(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                               ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                               ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String,
                                               ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String,
                                               ByVal Password As String, ByVal FullUserName As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim LoginSuccessful As Boolean = False
            'Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing

            'If AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDBDataReader(SecurityDbContext) = False Then

            '    ErrorMessage = "User trying to login is not apart of the database role db_datareader"

            'ElseIf AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDBDataReader(SecurityDbContext) = False Then

            '    ErrorMessage = "User trying to login is not apart of the database role db_datawriter"

            'Else

            'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, FullUserName)

            'ApplicationEntity = AdvantageFramework.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application.Advantage_Database_Update)

            'User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                If DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault <> 0 Then

                    If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.ADVAN_UPDATE WHERE VERSION_ID IS NULL").FirstOrDefault = 0 Then

                        LoginSuccessful = True

                        Session = New AdvantageFramework.Security.Session(Application.Advantage_Database_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, 0, SecurityDbContext.ConnectionString)

                    End If

                End If

            Else

                'If DoesUserHaveAccessToApplication(SecurityDbContext, User, Application.Advantage_Database_Update) Then

                If DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_ROLEMEMBER('advan_admin'), 0)").FirstOrDefault = 1 OrElse
                        DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault = 1 Then

                    If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.ADVAN_UPDATE WHERE VERSION_ID IS NULL").FirstOrDefault = 0 Then

                        LoginSuccessful = True

                        Session = New AdvantageFramework.Security.Session(Application.Advantage_Database_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, 0, SecurityDbContext.ConnectionString)

                    Else

                        ErrorMessage = "The previous update failed and the database has not been restored. Please restore the database."

                    End If

                Else

                    ErrorMessage = "You must be an sys admin or advan admin to have access to this application."

                End If

                'Else

                '    ErrorMessage = "Access denied"

                'End If

            End If

            LoginToDatabaseUpdate = LoginSuccessful

        End Function
        Private Function LoginToWebvantage(ByVal ApplicationEntity As AdvantageFramework.Security.Database.Entities.Application, ByRef DbContext As AdvantageFramework.Database.DbContext,
                                           ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String,
                                           ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String,
                                           ByVal Password As String, ByVal User As AdvantageFramework.Security.Classes.User,
                                           ByVal SessionID As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim LoginSuccessful As Boolean = False
            Dim Version As String = ""
            Dim DatabaseVersion As String = ""
            Dim VersionKeys() As String = Nothing
            Dim WebConfigVersion As String = ""
            Dim MinimumVersion As String = ""
            Dim MaximumVersion As String = ""
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim AdvantageUserLicenseInUseID As Integer = 0

            'Version = System.Configuration.ConfigurationManager.AppSettings("VCtrl")
            'DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

            ''test
            'If Version Is Nothing Then Version = "##DEV##"

            'If Version = "##DEV##" Then

            '    LoginSuccessful = True

            'ElseIf Version <> "##DEV##" Then

            '    Version = DecryptVersionKey("VersionEncryptor2007", Version)

            '    VersionKeys = Version.Split("|")
            '    WebConfigVersion = VersionKeys(1).ToString().Trim()
            '    MinimumVersion = VersionKeys(2).ToString().Trim()
            '    MaximumVersion = VersionKeys(3).ToString().Trim()

            '    If DatabaseVersion >= MinimumVersion OrElse DatabaseVersion <= MaximumVersion Then

            '        LoginSuccessful = True

            '    End If

            'End If

            'If LoginSuccessful Then

            '    Try

            '        'test
            '        If WebConfigVersion Is Nothing Or WebConfigVersion = "" Then WebConfigVersion = "##DEV##"

            '        If WebConfigVersion = "##DEV##" Then

            '            LoginSuccessful = True

            '        Else

            '            If DbContext.Database.SqlQuery(Of String)("SELECT WEBVAN_VERSION_ID FROM ADVAN_UPDATE").FirstOrDefault = WebConfigVersion Then

            '                LoginSuccessful = True

            '            Else

            '                LoginSuccessful = False

            '            End If

            '        End If

            '    Catch ex As Exception
            '        LoginSuccessful = False
            '    End Try

            '    If LoginSuccessful Then

            If AdvantageFramework.Security.LicenseKey.Validate(DbContext, User, Nothing, ApplicationEntity.ID, "", SessionID, ErrorMessage, AdvantageUserLicenseInUseID) Then

                Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.Database.Connection.ConnectionString, DbContext.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                    If Setting IsNot Nothing Then

                        If Setting.Value = 1 Then

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DbContext.Database.Connection.ConnectionString, DbContext.UserCode)

                                LoginSuccessful = SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.SEC_USER SET WEB_ID = '" & SessionID & "' WHERE SEC_USER_ID = " & User.ID) > 0

                            End Using

                        Else

                            LoginSuccessful = True

                        End If

                    Else

                        LoginSuccessful = True

                    End If

                End Using

                If LoginSuccessful Then

                    Session = New AdvantageFramework.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, User.UserCode, AdvantageUserLicenseInUseID, DbContext.ConnectionString)

                End If

            Else

                LoginSuccessful = False

            End If

            '    Else

            '        ErrorMessage = "The Webvantage software version is not compatible with the Webvantage database version!"

            '    End If

            'Else

            '    ErrorMessage = "The Advantage database version is not compatible with the Webvantage database version!"

            'End If

            LoginToWebvantage = LoginSuccessful

        End Function
        Public Sub LoadDirectoryScripts(Session As AdvantageFramework.Security.Session, ByRef UnappliedDatabaseChangesList As Generic.List(Of System.IO.FileInfo), ByVal DirectoryInfo As System.IO.DirectoryInfo, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Version As String)

            'objects
            Dim Hash As String = ""

            For Each SubDirectoryInfo In DirectoryInfo.GetDirectories.OrderBy(Function(Entity) Entity.Name).ToList

                LoadDirectoryScripts(Session, UnappliedDatabaseChangesList, SubDirectoryInfo, DbContext, Version)

            Next

            For Each FileInfo In DirectoryInfo.GetFiles.Where(Function(FileIn) FileIn.Name = "MenuUpdate.xml" OrElse FileIn.Extension.ToUpper = ".SQL" OrElse FileIn.Extension.ToUpper = ".ADVENC").OrderBy(Function(FileIn) FileIn.Name).ToList

                Hash = ""

                Using FileStream = FileInfo.OpenRead

                    Using MD5CryptoServiceProvider As New System.Security.Cryptography.MD5CryptoServiceProvider

                        Hash = AdvantageFramework.StringUtilities.ByteArrayToString(MD5CryptoServiceProvider.ComputeHash(FileStream))

                    End Using

                End Using

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.DB_UPDATE WHERE PATCH = '{0}' AND FILE_HASH = '{1}' AND VERSION_ID = '{2}'", FileInfo.Name, Hash, Version)).FirstOrDefault = 0 Then

                    If FileInfo.Name.ToUpper = "NIELSENSCRIPT.SQL" AndAlso Session.IsNielsenSetup AndAlso AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                        UnappliedDatabaseChangesList.Add(FileInfo)

                    ElseIf FileInfo.Name.ToUpper <> "NIELSENSCRIPT.SQL" Then

                        UnappliedDatabaseChangesList.Add(FileInfo)

                    End If

                End If

            Next

        End Sub
        Private Function LoginToAdvantage(ByVal ApplicationEntity As AdvantageFramework.Security.Database.Entities.Application, ByRef DbContext As AdvantageFramework.Database.DbContext,
                                          ByRef Session As AdvantageFramework.Security.Session, ByVal ServerName As String,
                                          ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean, ByVal UserName As String,
                                          ByVal Password As String, ByVal User As AdvantageFramework.Security.Classes.User,
                                          ByVal MACAddress As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim LoginSuccessful As Boolean = False
            Dim Version As String = ""
            'Dim ReleaseVersion As String = ""
            Dim DatabaseVersion As String = ""
            Dim DatabaseChangeVersion As String = ""
            Dim DatabaseChangeFunction As String = ""
            'Dim UnappliedDatabaseChangesList As Generic.List(Of System.IO.FileInfo) = Nothing
            Dim AdvantageUserLicenseInUseID As Integer = 0

            'Version = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00")
            'DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

            ''If Debugger.IsAttached = False Then

            'If DatabaseVersion = Version Then

            If AdvantageFramework.Security.LicenseKey.Validate(DbContext, User, Nothing, ApplicationEntity.ID, MACAddress, "", ErrorMessage, AdvantageUserLicenseInUseID) Then

                'ReleaseVersion = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00")

                'If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Scripts") Then

                '    UnappliedDatabaseChangesList = New Generic.List(Of System.IO.FileInfo)

                '    For Each DirectoryInfo In My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath & "\Scripts").GetDirectories.ToList

                '        If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectoryInfo.Name) >= AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ReleaseVersion) Then

                '            LoadDirectoryScripts(UnappliedDatabaseChangesList, DirectoryInfo, DbContext, DirectoryInfo.Name)

                '        End If

                '    Next

                '    If UnappliedDatabaseChangesList.Count > 0 Then

                '        ErrorMessage = "There are updates missing from your database.  " & vbCrLf & _
                '                       "This may cause errors when using certain features of the system before rectifying the situation.  " & vbCrLf & _
                '                       "Please notify your system adminstrator that the following items are missing and need to be applied: " & vbCrLf & vbCrLf & _
                '                       Join(UnappliedDatabaseChangesList.Select(Function(FileInfo) FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "_" & FileInfo.LastWriteTime.ToString("yyyyMMddHHmmss")).ToArray, vbCrLf)

                '    End If

                'End If

                LoginSuccessful = True
                Session = New AdvantageFramework.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, AdvantageUserLicenseInUseID, DbContext.ConnectionString)

            End If

            'Else

            '    ErrorMessage = "The database version is not the same as the application version"
            '    DbContext = Nothing

            'End If

            'Else

            '    LoginSuccessful = True
            '    Session = New AdvantageFramework.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, AdvantageUserLicenseInUseID)

            'End If

            LoginToAdvantage = LoginSuccessful

        End Function
        Private Function VersionCheckAdvantage(DbContext As AdvantageFramework.Database.DbContext, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim VersionCheckSuccessful As Boolean = False
            Dim Version As String = ""
            Dim DatabaseVersion As String = ""

            Version = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00")
            DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

            If DatabaseVersion = Version Then

                VersionCheckSuccessful = True

            Else

                ErrorMessage = "The database version is not the same as the application version"
                VersionCheckSuccessful = False

            End If

            VersionCheckAdvantage = VersionCheckSuccessful

        End Function
        Private Function VersionCheckWebvantage(DbContext As AdvantageFramework.Database.DbContext, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim VersionCheckSuccessful As Boolean = False
            Dim Version As String = ""
            Dim DatabaseVersion As String = ""
            Dim VersionKeys() As String = Nothing
            Dim WebConfigVersion As String = ""
            Dim MinimumVersion As String = ""
            Dim MaximumVersion As String = ""

            Version = System.Configuration.ConfigurationManager.AppSettings("VCtrl")
            DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

            'test
            If Version Is Nothing Then Version = "##DEV##"

            If Version = "##DEV##" Then

                VersionCheckSuccessful = True

            ElseIf Version <> "##DEV##" Then

                Version = DecryptVersionKey("VersionEncryptor2007", Version)

                VersionKeys = Version.Split("|")
                WebConfigVersion = VersionKeys(1).ToString().Trim()
                MinimumVersion = VersionKeys(2).ToString().Trim()
                MaximumVersion = VersionKeys(3).ToString().Trim()

                If DatabaseVersion >= MinimumVersion OrElse DatabaseVersion <= MaximumVersion Then

                    VersionCheckSuccessful = True

                End If

            End If

            If VersionCheckSuccessful Then

                VersionCheckSuccessful = False

                Try

                    'test
                    If WebConfigVersion Is Nothing Or WebConfigVersion = "" Then WebConfigVersion = "##DEV##"

                    If WebConfigVersion = "##DEV##" Then

                        VersionCheckSuccessful = True

                    Else

                        If DbContext.Database.SqlQuery(Of String)("SELECT WEBVAN_VERSION_ID FROM ADVAN_UPDATE").FirstOrDefault = WebConfigVersion Then

                            VersionCheckSuccessful = True

                        Else

                            VersionCheckSuccessful = False

                        End If

                    End If

                Catch ex As Exception
                    VersionCheckSuccessful = False
                End Try

                If VersionCheckSuccessful = False Then

                    ErrorMessage = "The Advantage database version is not compatible with the Webvantage database version!"

                End If

            Else

                ErrorMessage = "The Advantage database version is not compatible with the Webvantage database version!"
                VersionCheckSuccessful = False

            End If

            VersionCheckWebvantage = VersionCheckSuccessful

        End Function
        Public Function DecryptVersionKey(ByVal KeyString As String, ByVal Data As String) As String

            'objects
            Dim VersionKey As String = ""
            Dim KeyBytes() As Byte = Nothing
            Dim VectorBytes() As Byte = Nothing
            Dim DataBytes() As Byte = Nothing
            Dim DESCryptoServiceProvider As System.Security.Cryptography.DESCryptoServiceProvider = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim CryptoStream As System.Security.Cryptography.CryptoStream = Nothing
            Dim Encoding As System.Text.Encoding = Nothing

            If KeyString <> "" Then

                Select Case Len(KeyString)

                    Case Is < 16

                        KeyString = KeyString & Left("longdivisionisexciting", 16 - Len(KeyString))

                    Case Is > 16

                        KeyString = Left(KeyString, 16)

                End Select

                KeyBytes = System.Text.Encoding.UTF8.GetBytes(Left(KeyString, 8))
                VectorBytes = System.Text.Encoding.UTF8.GetBytes(Right(KeyString, 8))

                ReDim DataBytes(Data.Length)

                Try

                    DataBytes = Convert.FromBase64String(Data)

                Catch ex As Exception
                    VersionKey = Data
                End Try

                If VersionKey = "" Then

                    Try

                        DESCryptoServiceProvider = New System.Security.Cryptography.DESCryptoServiceProvider
                        MemoryStream = New System.IO.MemoryStream
                        CryptoStream = New System.Security.Cryptography.CryptoStream(MemoryStream, DESCryptoServiceProvider.CreateDecryptor(KeyBytes, VectorBytes), System.Security.Cryptography.CryptoStreamMode.Write)
                        CryptoStream.Write(DataBytes, 0, DataBytes.Length)
                        CryptoStream.FlushFinalBlock()

                        Encoding = System.Text.Encoding.UTF8

                        VersionKey = Encoding.GetString(MemoryStream.ToArray())

                    Catch ex As Exception
                        VersionKey = ""
                    End Try

                End If

            Else

                VersionKey = Data

            End If

            DecryptVersionKey = VersionKey

        End Function
        Public Function GetToolTip(ModuleCode As String, FieldName As String) As String

            Dim ToolTip As String = Nothing

            Select Case ModuleCode

                Case AdvantageFramework.Security.Modules.Employee_ExpenseReports.ToString

                    If FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString Then

                        ToolTip = "Check Custom1 to enable Expense Report import."

                    ElseIf FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom2.ToString Then

                        ToolTip = "Check Custom2 to prevent user from editing amounts on imported Expense Report line items uploaded by another user."

                    End If

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee.ToString

                    If FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString Then

                        ToolTip = "Check Custom1 to prevent access to the H/R Information tab and Cost and Department Update option within Employee Maintenance."

                    End If

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor.ToString

                    If FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString Then

                        ToolTip = "Check Custom1 to prevent access to the following tabs in Vendor Maintenance (Main, Default/Notes, EEOC, 1099 Info, Documents) and Limit AP to Media Vendors."

                    End If

                Case AdvantageFramework.Security.Modules.Media_MediaManager.ToString

                    If FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString Then

                        ToolTip = "Check Custom1 to grant full rights to view and edit any media order in Media Manager regardless of it's locked status."

                    End If

                Case AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule.ToString

                    If FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString Then

                        ToolTip = "Check Custom1 to lock project schedules marked as templates."

                    End If

                Case AdvantageFramework.Security.Modules.ProjectManagement_Boards.ToString

                    If FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString Then

                        ToolTip = "Check Custom1 to keep users out of the sprint until it is active."

                    End If

            End Select

            GetToolTip = ToolTip

        End Function
        Public Function ValidateLoginConnectionString(Application As AdvantageFramework.Security.Application,
                                                      ConnectionString As String,
                                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            Try

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)

            Catch ex As Exception
                SqlConnectionStringBuilder = Nothing
            End Try

            If SqlConnectionStringBuilder IsNot Nothing Then

                If AdvantageFramework.Database.ValidateServerAndDatabase(SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.InitialCatalog, False,
                                                                         SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password, Application.ToString, True, ErrorMessage) Then

                    If AdvantageFramework.Database.TestConnectionString(ConnectionString, ErrorMessage) Then

                        IsValid = True

                    End If

                End If

            End If

            ValidateLoginConnectionString = IsValid

        End Function
        Public Function ValidateUser(ByVal Application As AdvantageFramework.Security.Application,
                                     ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                     ByVal User As AdvantageFramework.Security.Classes.User,
                                     ByVal ApplicationEntity As AdvantageFramework.Security.Database.Entities.Application,
                                     ByVal ServerName As String,
                                     ByVal DatabaseName As String,
                                     ByVal UseWindowsAuthentication As Boolean,
                                     ByVal UserName As String, Password As String,
                                     ByRef IsWrongPassword As Boolean,
                                     ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim PasswordController As AdvantageFramework.Controller.Account.PasswordController = Nothing
            Dim PasswordMessage As String = String.Empty
            Dim DatabaseVersion As String = String.Empty
            Dim HasPassword As Boolean = False

            If Application = Application.Advantage_Nielsen_Database_Update OrElse
                    Application = Application.Advantage_Database_Update OrElse
                    Application = Application.Advantage_Update Then

                IsValid = True

            Else

                'ApplicationEntity = AdvantageFramework.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application)

                'User = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

                If ApplicationEntity IsNot Nothing Then

                    If User IsNot Nothing AndAlso User.ID > 0 Then

                        If UserHasGroupMembership(SecurityDbContext, User.ID, User.CheckForUserAccess) = False Then

                            ErrorMessage = AdvantageFramework.Security.Password.NoGroupMembershipMessage

                        Else

                            If User.IsInactive = False Then

                                If UseWindowsAuthentication = True Then

                                    Try

                                        If User.SID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value Then

                                            IsValid = True

                                        End If

                                    Catch ex As Exception

                                    End Try

                                Else

                                    If String.IsNullOrWhiteSpace(User.Password) = True Then

                                        If AdvantageFramework.Security.Password.SendPasswordChangeEmail(DbContext,
                                                                                                    SecurityDbContext,
                                                                                                    ServerName,
                                                                                                    DatabaseName,
                                                                                                    UserName,
                                                                                                    HasPassword,
                                                                                                    ErrorMessage) = True Then

                                            If Application.ToString = AdvantageFramework.Security.Application.Advantage.ToString OrElse
                                                Application.ToString = AdvantageFramework.Security.Application.Advantage_Database_Update.ToString Then

                                                AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.Security.Password.NewPasswordMessage &
                                                                                         "Check your email for further instructions.")

                                            Else

                                                AdvantageFramework.Navigation.ShowMessage(AdvantageFramework.Security.Password.NewPasswordMessage &
                                                                                      "Check your email for further instructions.")

                                            End If

                                        Else

                                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                If Application.ToString = AdvantageFramework.Security.Application.Advantage.ToString OrElse
                                                    Application.ToString = AdvantageFramework.Security.Application.Advantage_Database_Update.ToString Then

                                                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                                                Else

                                                    AdvantageFramework.Navigation.ShowMessage(ErrorMessage)

                                                End If

                                            Else

                                                If Application.ToString = AdvantageFramework.Security.Application.Advantage.ToString OrElse
                                                    Application.ToString = AdvantageFramework.Security.Application.Advantage_Database_Update.ToString Then

                                                    AdvantageFramework.Navigation.ShowMessageBox("Something went wrong!")

                                                Else

                                                    AdvantageFramework.Navigation.ShowMessage("Something went wrong!")

                                                End If

                                            End If

                                        End If

                                    Else

                                        If User.Password = AdvantageFramework.Security.Encryption.EncryptPassword(Password) Then

                                            PasswordController = New AdvantageFramework.Controller.Account.PasswordController()

                                            If PasswordController.IsPasswordExpired(SecurityDbContext, UserName, PasswordMessage) = True Then

                                                IsValid = False

                                                If String.IsNullOrWhiteSpace(PasswordMessage) Then

                                                    PasswordMessage = "Password has expired."

                                                End If

                                                If Application.ToString = AdvantageFramework.Security.Application.Advantage.ToString OrElse
                                                   Application.ToString = AdvantageFramework.Security.Application.Advantage_Database_Update.ToString Then

                                                    AdvantageFramework.Navigation.ShowMessageBox(PasswordMessage)

                                                    If AdvantageFramework.Navigation.ShowChangePassword(SecurityDbContext.ConnectionString, UserName, Password) = AdvantageFramework.WinForm.MessageBox.DialogResults.Cancel Then

                                                        ErrorMessage = PasswordMessage
                                                        IsValid = False

                                                    Else

                                                        IsValid = True

                                                    End If

                                                Else

                                                    AdvantageFramework.Navigation.ShowChangePasswordWithMessage(SecurityDbContext.ConnectionString, UserName, Password, PasswordMessage)

                                                End If

                                            Else

                                                IsValid = True

                                                If String.IsNullOrWhiteSpace(PasswordMessage) = False Then

                                                    If Application.ToString = AdvantageFramework.Security.Application.Advantage.ToString OrElse
                                                    Application.ToString = AdvantageFramework.Security.Application.Advantage_Database_Update.ToString Then

                                                        AdvantageFramework.Navigation.ShowMessageBox(PasswordMessage)

                                                    Else

                                                        AdvantageFramework.Navigation.ShowMessage(PasswordMessage)

                                                    End If

                                                End If

                                            End If

                                        Else

                                            ErrorMessage = "Incorrect password - Access denied"
                                            IsWrongPassword = True

                                        End If

                                    End If

                                End If

                            Else

                                ErrorMessage = "Invalid user - Access denied"

                            End If

                        End If

                    Else

                        ErrorMessage = "User not found - Access denied"

                    End If

                Else

                    ErrorMessage = "Application not found - Access denied"

                End If

            End If

            Return IsValid

        End Function
        Public Function UserHasGroupMembership(SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                               UserID As Integer,
                                               CheckForUserAccess As Boolean) As Boolean

            Dim HasGroupMembership As Boolean = False
            Dim GroupUsers As Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupUser) = Nothing

            Try

                GroupUsers = AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, UserID).ToList

            Catch ex As Exception
                GroupUsers = Nothing
            End Try

            If GroupUsers IsNot Nothing AndAlso GroupUsers.Count > 0 Then

                HasGroupMembership = True

            End If

            If HasGroupMembership = False AndAlso CheckForUserAccess = True Then

                'The Check for User Access means that we look at the User level security instead of the group.  Therefore, no group is required.
                HasGroupMembership = True

            End If

            Return HasGroupMembership

        End Function
        Private Function LoadLockoutMessage(ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                            ByVal UserCode As String) As String

            Dim Message As String = String.Empty
            Dim FailedAttempts As Integer = 0
            Dim AttemptsBeforeLockout As Integer = 0
            Dim ResetMinutes As Integer = 0
            Dim UnlockTime As String = String.Empty
            Dim LockedTime As DateTime? = Nothing
            Dim PasswordLockout As AdvantageFramework.Security.Database.Entities.PasswordLockout = Nothing
            Dim ElapsedTime As Long = 0
            Dim MinutesLockedOut As Long = 0

            PasswordLockout = AdvantageFramework.Security.Database.Procedures.PasswordLockout.LoadByUserCode(SecurityDbContext, UserCode)

            If PasswordLockout IsNot Nothing Then

                If PasswordLockout.Attempts IsNot Nothing Then

                    FailedAttempts = PasswordLockout.Attempts

                End If
                If FailedAttempts > 0 Then

                    Try

                        AttemptsBeforeLockout = AdvantageFramework.Security.Database.Procedures.PasswordLockout.AttemptsBeforeLockout(SecurityDbContext)

                    Catch ex As Exception
                        AttemptsBeforeLockout = 0
                    End Try

                End If
                If FailedAttempts > 0 AndAlso AttemptsBeforeLockout > 0 Then

                    If FailedAttempts >= AttemptsBeforeLockout Then

                        ResetMinutes = AdvantageFramework.Security.Database.Procedures.PasswordLockout.LoadResetMinutes(SecurityDbContext)

                        If ResetMinutes > 0 Then

                            MinutesLockedOut = DateDiff(DateInterval.Minute, CType(PasswordLockout.LockDate, DateTime), DateTime.Now)



                            Message = String.Format(AdvantageFramework.Security.Password.LockoutWithAttemptsMessage,
                                                    ResetMinutes - MinutesLockedOut)

                        Else

                            Message = String.Format(AdvantageFramework.Security.Password.LockoutWithAdminOnlyMessage)

                        End If

                    ElseIf FailedAttempts < AttemptsBeforeLockout Then

                        Message = String.Format(AdvantageFramework.Security.Password.IncorrectPasswordWithAttemptsMessage, FailedAttempts, AttemptsBeforeLockout)

                    End If

                End If

            End If

            Return Message

        End Function

#Region " Password "

        Public Function IsUserSqlServerServerAdmin(ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                   ByVal SqlServerUserCode As String,
                                                   ByRef ErrorMessage As String) As Boolean

            Dim UserIsSqlServerAdvantageAdmin As Boolean = False
            Dim IsAgencyASP As Boolean = False

            Try

                IsAgencyASP = (SecurityDbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(ASP_ACTIVE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                IsAgencyASP = False
            End Try

            Try

                If IsAgencyASP = True Then

                    If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault <> 0 Then

                        UserIsSqlServerAdvantageAdmin = True

                    Else

                        ErrorMessage = "You must be a sys admin to have access to this application."

                    End If

                Else

                    If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_ROLEMEMBER('advan_admin'), 0)").FirstOrDefault = 1 OrElse
                       SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault = 1 Then

                        UserIsSqlServerAdvantageAdmin = True

                    Else

                        ErrorMessage = "You must be a sys admin or advan admin to have access to this application."

                    End If

                End If

            Catch ex As Exception
                UserIsSqlServerAdvantageAdmin = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return UserIsSqlServerAdvantageAdmin

        End Function
        Public Function ValidatePassword(SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                         UserCode As String,
                                         Password As String,
                                         ByRef ErrorMessages As Generic.List(Of String)) As Boolean

            'Dim Patterns As New Generic.List(Of String)
            Dim IsValid As Boolean = True
            Dim MinimumPasswordLength As Short = 0
            Dim ComplexityRequired As Boolean = False
            Dim UppercaseRequired As Boolean = False
            Dim LowercaseRequired As Boolean = False
            Dim NumberRequired As Boolean = False
            Dim SpecialCharacterRequired As Boolean = False
            Dim PasswordHistoryCount As Short = 0
            Dim CurrEncrypted As String = String.Empty
            'Dim CurrentPassword As String = String.Empty
            Dim HistoryCounterIsValid As Boolean = True
            Dim EncryptedPassword As String = String.Empty

            If ErrorMessages Is Nothing Then

                ErrorMessages = New List(Of String)

            End If
            Try

                If Password.ToUpper().Contains("BEEFSTEW") = True Then

                    ErrorMessages.Add(String.Format("You cannot use '{0}' in a password.   It's not strogonoff.", Password))

                End If

            Catch ex As Exception
            End Try
            Try

                CurrEncrypted = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 PASSWORD FROM SEC_USER WITH(NOLOCK) WHERE USER_CODE = '{0}' ORDER BY SEC_USER_ID DESC;", UserCode)).SingleOrDefault

            Catch ex As Exception
                CurrEncrypted = String.Empty
            End Try
            'If String.IsNullOrWhiteSpace(CurrEncrypted) = False Then

            '    CurrentPassword = AdvantageFramework.Security.Encryption.Decrypt(CurrEncrypted)

            'End If
            If CurrEncrypted = AdvantageFramework.Security.Encryption.EncryptPassword(Password) Then

                ErrorMessages.Add("New password is old password.")

            ElseIf Password.Contains(" ") = True Then

                ErrorMessages.Add("Password cannot contain spaces.")

            ElseIf Password.ToUpper.Contains(UserCode.ToUpper) Then

                ErrorMessages.Add("Password cannot contain user code.")

            ElseIf String.IsNullOrWhiteSpace(CurrEncrypted) = False AndAlso String.IsNullOrWhiteSpace(Password) = False AndAlso
                AdvantageFramework.Security.Encryption.EncryptPassword(Password) = CurrEncrypted Then

                'Someone clicked save on the admin form which shows encrypted password
                'That means they really didn't change it
                ErrorMessages.Add("Password did not change.")

            ElseIf AdvantageFramework.StringUtilities.ContainsIllegalCharacters(Password) = True Then

                ErrorMessages.Add("Password cannot include characters:  ?, /, \, ', &, or "".")

            Else

                '  Minimum Password Length
                Try

                    MinimumPasswordLength = SecurityDbContext.Database.SqlQuery(Of Short)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS SMALLINT) 
                                                                                           FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_MIN_LEN';").FirstOrDefault

                Catch ex As Exception
                    MinimumPasswordLength = 0
                End Try
                If MinimumPasswordLength > 0 AndAlso Password.Length < MinimumPasswordLength Then

                    ErrorMessages.Add(String.Format("Password too short.  Must have at least {0} characters.", MinimumPasswordLength.ToString))

                End If
                '  Password History Count
                Try

                    PasswordHistoryCount = SecurityDbContext.Database.SqlQuery(Of Short)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS SMALLINT) 
                                                                                          FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_HIST_CT';").FirstOrDefault

                Catch ex As Exception
                    PasswordHistoryCount = 0
                End Try
                If PasswordHistoryCount > 0 Then

                    Try

                        EncryptedPassword = AdvantageFramework.Security.Encryption.EncryptPassword(Password)

                        HistoryCounterIsValid = AdvantageFramework.Security.Database.Procedures.PasswordHistory.ValidatePasswordHistory(SecurityDbContext,
                                                                                                                                        UserCode,
                                                                                                                                        EncryptedPassword)

                    Catch ex As Exception
                        HistoryCounterIsValid = True
                    End Try
                    If HistoryCounterIsValid = False Then

                        ErrorMessages.Add("You have already used this password.  Please use a different one.")

                    End If

                End If
                'Complexity Required
                Try

                    ComplexityRequired = SecurityDbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
                                                                                          FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_CXT_REQ';").FirstOrDefault

                Catch ex As Exception
                    ComplexityRequired = False
                End Try
                If ComplexityRequired = True Then

                    '  Uppercase Required
                    Try

                        UppercaseRequired = SecurityDbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
                                                                                             FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_CXT_UC';").FirstOrDefault

                    Catch ex As Exception
                        UppercaseRequired = False
                    End Try
                    If UppercaseRequired = True Then

                        If System.Text.RegularExpressions.Regex.IsMatch(Password, "[A-Z]") = False Then

                            ErrorMessages.Add("Password must contain at least one uppercase letter.")

                        End If

                    End If
                    '  Lowercase Required
                    Try

                        LowercaseRequired = SecurityDbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
                                                                                             FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_CXT_LC';").FirstOrDefault


                    Catch ex As Exception
                        LowercaseRequired = False
                    End Try
                    If LowercaseRequired = True Then

                        If System.Text.RegularExpressions.Regex.IsMatch(Password, "[a-z]") = False Then

                            ErrorMessages.Add("Password must contain at least one lowercase letter.")

                        End If

                    End If
                    '  Number Required
                    Try

                        NumberRequired = SecurityDbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
                                                                                          FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_CXT_NUM';").FirstOrDefault

                    Catch ex As Exception
                        NumberRequired = False
                    End Try
                    If NumberRequired = True Then

                        If System.Text.RegularExpressions.Regex.IsMatch(Password, "[0-9]") = False Then

                            ErrorMessages.Add("Password must contain at least one number.")

                        End If

                    End If
                    '  Special Character Required
                    Try

                        SpecialCharacterRequired = SecurityDbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
                                                                                                    FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_XST_SPL';").FirstOrDefault

                    Catch ex As Exception
                        SpecialCharacterRequired = False
                    End Try
                    If SpecialCharacterRequired = True Then

                        If System.Text.RegularExpressions.Regex.IsMatch(Password, "[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\] ]") = False Then

                            ErrorMessages.Add("Password must contain at least one special character.")

                        End If

                    End If

                End If

            End If
            If ErrorMessages.Count > 0 Then

                IsValid = False

            End If

            Return IsValid

        End Function
        Public Function IsPasswordExpired(SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                          UserCode As String,
                                          ByRef ErrorMessage As String) As Boolean

            Dim IsExpired As Boolean = False
            Dim PasswordExpirationDays As Short = 0
            Dim LatestPasswordHistory As AdvantageFramework.Security.Database.Entities.PasswordHistory = Nothing
            Dim DaysInUse As Long = 0
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            Try

                PasswordExpirationDays = SecurityDbContext.Database.SqlQuery(Of Short)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS SMALLINT) 
                                                                                        FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_EXP_DYS';").FirstOrDefault

            Catch ex As Exception
                PasswordExpirationDays = 0
            End Try

            If PasswordExpirationDays > 0 Then

                LatestPasswordHistory = AdvantageFramework.Security.Database.Procedures.PasswordHistory.LoadLatestByUserCode(SecurityDbContext, UserCode)

                If LatestPasswordHistory IsNot Nothing Then

                    Try

                        DaysInUse = DateDiff(DateInterval.Day, LatestPasswordHistory.StartDate, Today.Date)

                    Catch ex As Exception
                        DaysInUse = 0
                    End Try

                    If DaysInUse > PasswordExpirationDays Then

                        ErrorMessage = "Password expired."
                        IsExpired = True

                    ElseIf DaysInUse = PasswordExpirationDays Then

                        ErrorMessage = "Password expires today."

                    End If

                Else

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode)

                    If User IsNot Nothing Then

                        AdvantageFramework.Security.Password.InsertNewPasswordHistory(SecurityDbContext, User)

                    End If

                End If

            End If

            Return IsExpired

        End Function
        Public Function LoadPasswordUsers(SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                          ByRef ErrorMessage As String) As Generic.List(Of Security.Classes.PasswordUser)

            Dim PasswordUsers As Generic.List(Of Security.Classes.PasswordUser) = Nothing

            Try

                PasswordUsers = SecurityDbContext.Database.SqlQuery(Of Security.Classes.PasswordUser)("EXEC [dbo].[advsp_sec_pwd_load_users];").ToList

            Catch ex As Exception
                PasswordUsers = Nothing
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                AdvantageFramework.Security.AddWebvantageEventLog("LoadPasswordUsers:  " & Diagnostics.EventLogEntryType.Error)
            End Try

            If PasswordUsers Is Nothing Then PasswordUsers = New List(Of Classes.PasswordUser)

            Return PasswordUsers

        End Function

#End Region

#End Region

    End Module

End Namespace

