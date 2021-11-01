using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Security
{
    public static class Methods
    {
        //    public static string _MyMenuStateDetails = "Dock={0};AutoHide={1};X={2};Y={3};Width={4};Height={5}";
        //    public static string AdvantageConnectionConfigurationFileName = "AdvantageConnectionConfiguration.xml";

        //    public enum AccessType
        //    {
        //        Full = 1,
        //        ReadOnly = 2,
        //        Blocked = 3
        //    }

        //    public enum Application
        //    {
        //        Advantage = 1,
        //        Webvantage = 2,
        //        Advantage_Update = 3,
        //        Outlook_Addin = 4,
        //        Advantage_Database_Update = 5,
        //        Client_Portal = 6,
        //        Adassist = 7,
        //        Advantage_Nielsen_Database_Update = 8,
        //        Webvantage_Password_Admin = 9 // Needed for validation of connectionstring!
        //,
        //        Mobile_DataService = 10,
        //        ProofingAPI = 11
        //    }

        //    public enum UserSettings
        //    {
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "My Menu")]
        //        MyMenuDefaultTabName,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        MyMenuDefaultTabSmallIcons,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MyMenuState,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "1")]
        //        QuickAccessToolbarVisible,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "1")]
        //        NavigationWindowVisible,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "1")]
        //        BubbleBarVisible,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        PR_PO_DO_OWN,
        //        // <AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")> _
        //        // SI_MARKUP_TAX
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        SI_DO_OWN_TS,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        EMP_TS_FNC,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        TS_ADMIN_LVL,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        TIME_ENTRY_ONLY,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Numeric_Boolean_10, "0")]
        //        NewAdvantageApplicationsAlert,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        AllowProfileUpdate,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "Y")]
        //        RemindUserOfLicenseKeyRenewal,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        ETFSelectedOffice,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        ETFSelectedEmployee,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        ETFSelectedPostPeriod,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        IsCRMUser,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        IsMediaToolsUser,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        ShowDescriptionsInRateFlagEntry,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        ShowDescriptionsInAdjustTime,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Default, "3")]
        //        GridColumnOptionsInCRMCentral,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        IsAPIUser,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        ShowDescriptionsInIncomeOnly,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        LastGenericAPImportTemplateID,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        LastAPImportType,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "1")]
        //        ShowSequenceNumberInInvoicePrinting,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "0")]
        //        ShowDivisionProductJobCompInInvoicePrinting,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        LastVCCReminderLocation,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        BCCLastMediaDateToUse,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        APShowHomeChecked,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        BCCExcludeNonBillableFunctionsAdvanceBilling,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        BCCHideNonBillableFunctionsEmployeeTime,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        BCCHideNonBillableFunctionsIncomeOnly,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        BCCHideNonBillableFunctionsVendor,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaManagerApproveInvoiceView,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "3")]
        //        MediaManagerSearchFilterBy,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        RFPCCSender,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        RFPEmailSubject,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        RFPEmailBody,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        MediaManagerCCSender,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaManagerEmailSubject,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaManagerEmailBody,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        MediaManagerSendToDocumentManager,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        MediaManagerUploadAndSignDocumentWhenSubmitted,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        MediaManagerEmailExecutedCopyToVendor,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaManagerDocumentTypes,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaManagerContactTypes,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaManagerRepresentativeTypes,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        PurchaseOrderCCSender,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        PurchaseOrderEmailSubject,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        PurchaseOrderEmailBody,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        PurchaseOrderUploadAndSignDocumentWhenSubmitted,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        PurchaseOrderUploadDocumentManager,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        PurchaseOrderEmailExecutedCopyToVendor,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        RFPContactTypes,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaTrafficContactTypes,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        MediaTrafficCCSender,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaTrafficEmailSubject,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.Default, "")]
        //        MediaTrafficEmailBody,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.NumericValue, SettingsParseValueType.Numeric_Boolean_10, "0")]
        //        MediaBroadcastWorksheet_HideHiatusDates,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        CRMAddEditViewNewBusinessClientsOnly
        //    }

        //    public enum SettingsValueType
        //    {
        //        StringValue,
        //        NumericValue,
        //        DateValue
        //    }

        //    public enum SettingsParseValueType
        //    {
        //        Default,
        //        String_Boolean_YN,
        //        Numeric_Boolean_10
        //    }

        //    public enum GroupSettings
        //    {
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        Calendar_AllowGroupToViewOtherEmployees,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        Calendar_AllowGroupToAddHolidays,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        AlertInbox_ShowAllAssignments,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        AlertInbox_ShowUnassignedAssignments,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        Schedule_AllowTaskEdit,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        DocumentManager_CanUpload,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        DocumentManager_ViewPrivateDocuments,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        Workspace_Template_Create,
        //        [AdvantageFramework.Core.Security.Attributes.SecuritySetting(SettingsValueType.StringValue, SettingsParseValueType.String_Boolean_YN, "N")]
        //        Schedule_AllowMediaPageEdit
        //    }

        //    public enum Modules
        //    {
        //        Billing,
        //        Billing_AdjustTime,
        //        Billing_AvalaraRepost,
        //        Billing_BillingApproval,
        //        Billing_BillingApprovalBatch,
        //        Billing_BillingCommandCenter,
        //        Billing_Reports,
        //        Billing_Reports_BillingReportsRTP,
        //        Billing_Reports_InvoicePrintingRTP,
        //        Billing_Reports_InvoicePrintingEnhancedRTP,
        //        Desktop,
        //        Desktop_Alerts,
        //        Desktop_AlertsManager,
        //        Desktop_Calendar,
        //        Desktop_Chat,
        //        Desktop_CRMCentral,
        //        Desktop_DocumentManager,
        //        Desktop_DocumentManagerLevels,
        //        Desktop_DocumentManagerLevels_AdNumber,
        //        Desktop_DocumentManagerLevels_AgencyDesktop,
        //        Desktop_DocumentManagerLevels_AlertAttachment,
        //        Desktop_DocumentManagerLevels_APInvoice,
        //        Desktop_DocumentManagerLevels_ARInvoice,
        //        Desktop_DocumentManagerLevels_Campaign,
        //        Desktop_DocumentManagerLevels_Client,
        //        Desktop_DocumentManagerLevels_Contract,
        //        Desktop_DocumentManagerLevels_ContractReport,
        //        Desktop_DocumentManagerLevels_ContractValueAdded,
        //        Desktop_DocumentManagerLevels_Division,
        //        Desktop_DocumentManagerLevels_Employee,
        //        Desktop_DocumentManagerLevels_ExecutiveDesktop,
        //        Desktop_DocumentManagerLevels_ExpenseReceipts,
        //        Desktop_DocumentManagerLevels_Job,
        //        Desktop_DocumentManagerLevels_JobComponent,
        //        Desktop_DocumentManagerLevels_MediaOrder,
        //        Desktop_DocumentManagerLevels_Office,
        //        Desktop_DocumentManagerLevels_Product,
        //        Desktop_DocumentManagerLevels_Task,
        //        Desktop_DocumentManagerLevels_Vendor,
        //        Desktop_DocumentManagerLevels_VendorContract,
        //        Desktop_ReportWriter,
        //        Desktop_ReportWriter_AdvancedReportWriter,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AccountsPayableInvoiceDetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AccountsPayableInvoiceDetailPaymentsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AccountsPayableInvoiceDetailPaidByClientARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AccountsPayableInvoiceWithBalanceAgingARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AlertsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AlertsWithCommentsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AlertsWithRecipientsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AROpenAgedARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_AuthorizationToBuyARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_BillingApprovalARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_BillingWorksheetMediaARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_BillingWorksheetProductionARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_CampaignARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_CampaignWithProductionAndMediaARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_CashAnalysisARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_CashTransactionsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ClientContactARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ClientPLARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ClientPLDetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ClientsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_CRMClientContractsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_CRMOpportunityDetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_CRMOpportunityToInvestmentARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_CRMProspectsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_DirectIndirectTimeARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_DirectIndirectTimeWithEmployeeCostARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_DirectTimeARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_DirectTimeWithEmployeeCostARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_DivisionsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_EmployeesARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_EmployeesInOutBoardARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_EmployeeTimeApprovalARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_EstimateFormARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_EstimatedAndActualIncomeARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_EstimateDetailApprovedARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_GeneralLedgerDetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_IncomeOnlyARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV10DetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV10SummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV11DetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV11JobCompARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV11SummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV1DetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV1SummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV29ARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV30SummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV30DetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV30JobCompARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailAnalysisV31ARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailBillMonthARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFunctionARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailItemARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailItemAccountSplitARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFeesAndOOPByCampaignARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFeesAndOOPByFunctionARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFeesAndOOPByJobARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobDetailFeesAndOOPByJobComponentARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobProjectScheduleSummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobPurchaseOrderARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobSummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_JobWriteOffARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaCurrentStatusARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaCurrentStatusCoopBreakoutARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaCurrentStatusSummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaPlanARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaPlanComparisonSummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_MediaResultsComparisonByClientAndTypeARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_NewspaperOrderDetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_OpenPurchaseOrderDetailARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ProductsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectHoursUsedARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectScheduleARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectSummaryARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectSummaryAnalysisARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ProjectSummaryTaskARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_PurchaseOrderARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_SalesJournalARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ServiceFeeARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ServiceFeeContractARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_ServiceFeeReconciliationARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_TransferARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_SecurityUserTimesheetFunctionARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_VendorsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_VendorContractsARWRPT,
        //        Desktop_ReportWriter_AdvancedReportWriterDataSets_VirtualCreditCardTransactionEFSARWRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets,
        //        Desktop_ReportWriter_DynamicReportDataSets_AccountsPayableInvoiceDetailDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_AccountsPayableInvoiceDetailPaymentsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_AccountsPayableInvoiceDetailPaidByClientDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_AccountsPayableInvoiceWithBalanceAgingDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_AlertsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_AlertsWithCommentsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_AlertsWithRecipientsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_AROpenAgedDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_AuthorizationToBuyDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_BillingApprovalDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_BillingWorksheetMediaDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_BillingWorksheetProductionDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_CampaignDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_CampaignWithProductionAndMediaDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_CashAnalysisDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_CashTransactionsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ClientContactDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ClientPLDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ClientPLDetailDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ClientsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_CRMClientContractsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_CRMOpportunityDetailDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_CRMOpportunityToInvestmentDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_CRMProspectsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_DirectIndirectTimeDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_DirectIndirectTimeWithEmployeeCostDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_DirectTimeDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_DirectTimeWithEmployeeCostDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_DivisionsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_EmployeesDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_EmployeesInOutBoardDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_EmployeeTimeApprovalDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_EstimateFormDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_EstimatedAndActualIncomeDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_EstimateDetailApprovedDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_GeneralLedgerDetailDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_IncomeOnlyDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailBillMonthDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailFunctionDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailItemDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailItemAccountSplitDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailFeesAndOOPByCampaignDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailFeesAndOOPByFunctionDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailFeesAndOOPByJobDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobDetailFeesAndOOPByJobComponentDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobProjectScheduleSummaryDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobPurchaseOrderDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobSummaryDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_JobWriteOffDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_MediaCurrentStatusDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_MediaCurrentStatusCoopBreakoutDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_MediaCurrentStatusSummaryDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_MediaPlanComparisonSummaryDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_MediaPlanDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_MediaResultsComparisonByClientAndTypeDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_NewspaperOrderDetailDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_OpenPurchaseOrderDetailDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ProductsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ProjectHoursUsedDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ProjectScheduleDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ProjectSummaryDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ProjectSummaryAnalysisDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ProjectSummaryTaskDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_SalesJournalDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ServiceFeeDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_ServiceFeeContractDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_TransferDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_SecurityUserTimesheetFunctionDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_VendorsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_VendorContractsDRPT,
        //        Desktop_ReportWriter_DynamicReportDataSets_VirtualCreditCardTransactionEFSDRPT,
        //        Desktop_ReportWriter_DynamicReports,
        //        Desktop_ReportWriter_UserDefinedReports,
        //        Employee,
        //        Employee_DashboardQueries,
        //        Employee_DashboardQueries_VacSickTimeDQ,
        //        Employee_DesktopObjects,
        //        Employee_DesktopObjects_AlertsDO,
        //        Employee_DesktopObjects_BillableHoursGoalDO,
        //        Employee_DesktopObjects_BookmarksDO,
        //        Employee_DesktopObjects_EmployeeIndirectTimeAllDO,
        //        Employee_DesktopObjects_EmployeeIndirectTimeDO,
        //        Employee_DesktopObjects_EmployeeTimeForecastDO,
        //        Employee_DesktopObjects_InOutBoardAllDO,
        //        Employee_DesktopObjects_InOutBoardDO,
        //        Employee_DesktopObjects_MyDirectTimeDO,
        //        Employee_DesktopObjects_MyEmployeeTimeForecastDO,
        //        Employee_DesktopObjects_TimesheetDO,
        //        Employee_DesktopObjects_WeeklyTimeGraphDO,
        //        Employee_ExpenseApproval,
        //        Employee_ExpenseReports,
        //        Employee_Reports,
        //        Employee_Reports_DirectTimeRTP,
        //        Employee_Reports_DirectTimeActivityRTP,
        //        Employee_Reports_HoursWorkedRTP,
        //        Employee_Reports_EmpHrsWorkedRTP,
        //        Employee_Reports_IndrectTimeRTP,
        //        Employee_Reports_TimesheetRTP,
        //        Employee_Timesheet,
        //        Employee_TimesheetEnhanced,
        //        Employee_TimesheetApproval,
        //        FinanceAccounting,
        //        FinanceAccounting_1099Processing,
        //        FinanceAccounting_AccountsPayable,
        //        FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import,
        //        FinanceAccounting_BankReconciliation,
        //        FinanceAccounting_BatchTimePost,
        //        FinanceAccounting_CheckWritingReports,
        //        FinanceAccounting_ClientBudgets,
        //        FinanceAccounting_ClientCashReceipts,
        //        FinanceAccounting_ClientCashReceiptsImport,
        //        FinanceAccounting_ClientInvoicesImport,
        //        FinanceAccounting_ClientInvoicesManual,
        //        FinanceAccounting_ClientInvoices,
        //        FinanceAccounting_ClientLatePaymentFees,
        //        FinanceAccounting_ClientOOP,
        //        FinanceAccounting_CreateRecurringAP,
        //        FinanceAccounting_DashboardQueries,
        //        FinanceAccounting_DashboardQueries_ClientTimeAnalysisDQ,
        //        FinanceAccounting_DashboardQueries_EmployeeTimeADQ,
        //        FinanceAccounting_DashboardQueries_EmployeeUtilizationDQ,
        //        FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ,
        //        FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ,
        //        FinanceAccounting_DashboardQueries_VacSickAdminDQ,
        //        FinanceAccounting_DashboardQueries_VendorAPQueryDQ,
        //        FinanceAccounting_DesktopObjects,
        //        FinanceAccounting_DesktopObjects_AgencyGoalsDO,
        //        FinanceAccounting_DesktopObjects_AgencyGoalsGraphDO,
        //        FinanceAccounting_DesktopObjects_ARCashForecastDO,
        //        FinanceAccounting_DesktopObjects_ARCashForecastProductDO,
        //        FinanceAccounting_DesktopObjects_BillingTrendsDO,
        //        FinanceAccounting_DesktopObjects_CashBalanceDO,
        //        FinanceAccounting_DesktopObjects_ClientAgingDO,
        //        FinanceAccounting_DesktopObjects_CurrentRatioDO,
        //        FinanceAccounting_DesktopObjects_CurrentRatioGraphDO,
        //        FinanceAccounting_DesktopObjects_DirectExpenseAlertDO,
        //        FinanceAccounting_DesktopObjects_GrossIncomeDO,
        //        FinanceAccounting_DesktopObjects_MyARCashForecastDO,
        //        FinanceAccounting_DesktopObjects_MyClientAgingDO,
        //        FinanceAccounting_DesktopObjects_MyDirectExpenseAlertDO,
        //        FinanceAccounting_DesktopObjects_MyGrossIncomeDO,
        //        FinanceAccounting_DesktopObjects_MyServiceFeesDO,
        //        FinanceAccounting_DesktopObjects_ServiceFeesDO,
        //        FinanceAccounting_EmployeeTimeForecast,
        //        FinanceAccounting_EmployeeTimeForecastComparisonDashboard,
        //        FinanceAccounting_EmployeeTimeForecastSettings,
        //        FinanceAccounting_Exports,
        //        FinanceAccounting_Exports_CheckRegisterExport,
        //        FinanceAccounting_Exports_EmployeeHoursExport,
        //        FinanceAccounting_Exports_VATTaxExport,
        //        FinanceAccounting_Housekeeping,
        //        FinanceAccounting_Housekeeping_BankReconciliationUtility,
        //        FinanceAccounting_Housekeeping_BillableMaintenance,
        //        FinanceAccounting_Housekeeping_BrdcastAutoClose,
        //        FinanceAccounting_Housekeeping_POMaintenance,
        //        FinanceAccounting_Housekeeping_VendorMerge,
        //        FinanceAccounting_Imports,
        //        FinanceAccounting_Imports_ChecksClearedImport,
        //        FinanceAccounting_Imports_IncomeOnlyImport,
        //        FinanceAccounting_Imports_PTOImport,
        //        FinanceAccounting_Imports_TimeImport,
        //        FinanceAccounting_IncomeOnly,
        //        FinanceAccounting_JobForecast,
        //        FinanceAccounting_JobProcessCtrl,
        //        FinanceAccounting_MediaDatetoBill,
        //        FinanceAccounting_PaymentManager,
        //        FinanceAccounting_PostRecurringAP,
        //        FinanceAccounting_Reports,
        //        FinanceAccounting_Reports_AccountsPayableRTP,
        //        FinanceAccounting_Reports_AccountsReceivableRTP,
        //        FinanceAccounting_Reports_ARStatementsRTP,
        //        FinanceAccounting_Reports_CashManagementProductionRTP,
        //        FinanceAccounting_Reports_CashReceiptsRTP,
        //        FinanceAccounting_Reports_CheckRegisterRTP,
        //        FinanceAccounting_Reports_ClientPLRTP,
        //        FinanceAccounting_Reports_EmployeeHoursWorkedRTP,
        //        FinanceAccounting_Reports_EmployeeTimeManagementRTP,
        //        FinanceAccounting_Reports_EmployeeUtilizationRTP,
        //        FinanceAccounting_Reports_GeneralLedgerRTP,
        //        FinanceAccounting_Reports_MonthEndReportsRTP,
        //        FinanceAccounting_Reports_MonthEndReportsEnhancedRTP,
        //        FinanceAccounting_Reports_PurchaseOrdersRTP,
        //        FinanceAccounting_Reports_PurchaseOrderReportRTP,
        //        FinanceAccounting_Reports_SalesJournalRTP,
        //        FinanceAccounting_RevenueResourcePlan,
        //        FinanceAccounting_ServiceFeeReconciliation,
        //        FinanceAccounting_ServiceFees,
        //        FinanceAccounting_VoidChecks,
        //        FinanceAccounting_VoidInvoices,
        //        FinanceAccounting_VoidInvoicesEnhanced,
        //        General,
        //        General_DesktopObjects,
        //        General_DesktopObjects_AgencyLinksDO,
        //        General_DesktopObjects_ExecutiveLinksDO,
        //        GeneralLedger,
        //        GeneralLedger_DashboardQueries,
        //        GeneralLedger_DashboardQueries_BudgetvsActualQryDQ,
        //        GeneralLedger_DashboardQueries_JournalEntryQueryDQ,
        //        GeneralLedger_DashboardQueries_TrialBalanceQueryDQ,
        //        GeneralLedger_Exports,
        //        GeneralLedger_Exports_GLDetailQueryExportRTP,
        //        GeneralLedger_Imports,
        //        GeneralLedger_Imports_ImportBudgets,
        //        GeneralLedger_Imports_ImportJournalEntries,
        //        GeneralLedger_JournalEntriesBudgets,
        //        GeneralLedger_JournalEntriesBudgets_BudgetApproval,
        //        GeneralLedger_JournalEntriesBudgets_Budgets,
        //        GeneralLedger_JournalEntriesBudgets_JournalEntries,
        //        GeneralLedger_Maintenance,
        //        GeneralLedger_Maintenance_AccountAllocation,
        //        GeneralLedger_Maintenance_ChartofAccounts,
        //        GeneralLedger_Maintenance_Configuration,
        //        GeneralLedger_Maintenance_CrossReference,
        //        GeneralLedger_Maintenance_GeneralLedgerMapping,
        //        GeneralLedger_Maintenance_GeneralLedgerMappingExport,
        //        GeneralLedger_Maintenance_PostingPeriods,
        //        GeneralLedger_Processing,
        //        GeneralLedger_Processing_ConsolidateGL,
        //        GeneralLedger_Processing_PostAllocations,
        //        GeneralLedger_Processing_PostRecurring,
        //        GeneralLedger_Processing_UpdateToSummary,
        //        GeneralLedger_Processing_UpdateToSummary_Actions,
        //        GeneralLedger_Processing_UpdateToSummary_Actions_OptionToClearAndRepost,
        //        GeneralLedger_Processing_YearEndClosing,
        //        GeneralLedger_Reports,
        //        GeneralLedger_Reports_GeneralLedgerReports,
        //        GeneralLedger_Reports_DetailbyAcctCodeRptRTP,
        //        GeneralLedger_Reports_DetailbyTransRptRTP,
        //        GeneralLedger_Reports_FY12PeriodSpreadRTP,
        //        GeneralLedger_ReportWriter,
        //        GeneralLedger_ReportWriter_GLReportWriter,
        //        GeneralLedger_ReportWriter_ReportingAcctGroup,
        //        GeneralLedger_ReportWriter_ReportingColFmt,
        //        GeneralLedger_ReportWriter_ReportingRowFmt,
        //        GeneralLedger_ReportWriter_ReportList,
        //        HelpCustomerService,
        //        HelpCustomerService_Aboutadvantage,
        //        HelpCustomerService_ContactCustomerService,
        //        HelpCustomerService_Help,
        //        Maintenance,
        //        Maintenance_Accounting,
        //        Maintenance_Accounting_AccountNumber,
        //        Maintenance_Accounting_ARStatement,
        //        Maintenance_Accounting_AvalaraProductMapping,
        //        Maintenance_Accounting_AvalaraTaxCodeMaintenance,
        //        Maintenance_Accounting_Bank,
        //        Maintenance_Accounting_BillingCoop,
        //        Maintenance_Accounting_CashReceiptPaymentType,
        //        Maintenance_Accounting_ClientDiscount,
        //        Maintenance_Accounting_CurrencyCodes,
        //        Maintenance_Accounting_DeptTeam,
        //        Maintenance_Accounting_Employee,
        //        Maintenance_Accounting_EmployeeCategory,
        //        Maintenance_Accounting_EmployeeImport,
        //        Maintenance_Accounting_EmployeeTitle,
        //        Maintenance_Accounting_EmployeeUpdate,
        //        Maintenance_Accounting_FiscalPeriod,
        //        Maintenance_Accounting_Function,
        //        Maintenance_Accounting_FunctionHeading,
        //        Maintenance_Accounting_GeneralDescriptions,
        //        Maintenance_Accounting_Office,
        //        Maintenance_Accounting_PaidTimeOff,
        //        Maintenance_Accounting_SalesClass,
        //        Maintenance_Accounting_SalesTax,
        //        Maintenance_Accounting_ServiceFeeType,
        //        Maintenance_Accounting_TimeCategory,
        //        Maintenance_Accounting_TimeCategoryType,
        //        Maintenance_Accounting_Vendor,
        //        Maintenance_Accounting_VendorContact,
        //        Maintenance_Accounting_VendorImport,
        //        Maintenance_Accounting_VendorInvoiceCategory,
        //        Maintenance_Accounting_VendorMapping,
        //        Maintenance_Accounting_VendorServiceTax,
        //        Maintenance_Accounting_VendorTerms,
        //        Maintenance_Billing,
        //        Maintenance_Billing_BillingSettings,
        //        Maintenance_Billing_InvoiceCategory,
        //        Maintenance_Billing_RateFlagEntry,
        //        Maintenance_Billing_RateFlagStructure,
        //        Maintenance_Billing_RateFlagStructureEntry,
        //        Maintenance_Client,
        //        Maintenance_Client_AccountExecutive,
        //        Maintenance_Client_Affiliation,
        //        Maintenance_Client_Client,
        //        Maintenance_Client_ClientContact,
        //        Maintenance_Client_ClientContactImport,
        //        Maintenance_Client_ClientImport,
        //        Maintenance_Client_ClientMapping,
        //        Maintenance_Client_ClientPO,
        //        Maintenance_Client_Competition,
        //        Maintenance_Client_Division,
        //        Maintenance_Client_DivisionImport,
        //        Maintenance_Client_Industry,
        //        Maintenance_Client_ManagementLevel,
        //        Maintenance_Client_Media_Percentages,
        //        Maintenance_Client_Product,
        //        Maintenance_Client_ProductImport,
        //        Maintenance_Client_ProductCategory,
        //        Maintenance_Client_Rating,
        //        Maintenance_Client_Source,
        //        Maintenance_Client_Specialty,
        //        Maintenance_Client_Types,
        //        Maintenance_General,
        //        Maintenance_General_AdvantageServicesSettings,
        //        Maintenance_General_Agency,
        //        Maintenance_General_AgencySettings,
        //        Maintenance_General_ContactTypes,
        //        Maintenance_General_CSIPreferredPartnerSettings,
        //        Maintenance_General_CycleFrequency,
        //        Maintenance_General_Documents,
        //        Maintenance_General_IntegrationSettings,
        //        Maintenance_General_Locations,
        //        Maintenance_General_MyObjectDefinition,
        //        Maintenance_General_PasswordSettings,
        //        Maintenance_General_ProfileAdministration,
        //        Maintenance_General_Region,
        //        Maintenance_General_SoftwareVersion,
        //        Maintenance_General_StandardComments,
        //        Maintenance_General_UserDefinedReportCategory,
        //        Maintenance_General_VCCSettings,
        //        Maintenance_General_WebsiteTypes,
        //        Maintenance_General_WorkstationComponents,
        //        Maintenance_Management,
        //        Maintenance_Management_AgencyBuilder,
        //        Maintenance_Management_AgencyClients,
        //        Maintenance_Management_OHAccounts,
        //        Maintenance_Media,
        //        Maintenance_Media_AdSize,
        //        Maintenance_Media_Associate,
        //        Maintenance_Media_InvoiceMatchingSettings,
        //        Maintenance_Media_Buyer,
        //        Maintenance_Media_CableNetwork,
        //        Maintenance_Media_CanadaUniverse,
        //        Maintenance_Media_Channel,
        //        Maintenance_Media_Daypart,
        //        Maintenance_Media_Demographic,
        //        Maintenance_Media_InternetType,
        //        Maintenance_Media_MarketGroups,
        //        Maintenance_Media_MediaMarket,
        //        Maintenance_Media_MediaSpecs,
        //        Maintenance_Media_NationalUniverse,
        //        Maintenance_Media_OutofHomeType,
        //        Maintenance_Media_Partner,
        //        Maintenance_Media_PartnerAllocation,
        //        Maintenance_Media_RateCardContract,
        //        Maintenance_Media_Tactic,
        //        Maintenance_Media_VendorRep,
        //        Maintenance_ProjectManagement,
        //        Maintenance_ProjectManagement_AdNumber,
        //        Maintenance_ProjectManagement_AlertAssignments,
        //        Maintenance_ProjectManagement_AlertEventSettings,
        //        Maintenance_ProjectManagement_AlertGroups,
        //        Maintenance_ProjectManagement_Blackplate,
        //        Maintenance_ProjectManagement_ComplexityType,
        //        Maintenance_ProjectManagement_CreativeBriefTemplate,
        //        Maintenance_ProjectManagement_Destination,
        //        Maintenance_ProjectManagement_DestinationContact,
        //        Maintenance_ProjectManagement_EstimateTemplates,
        //        Maintenance_ProjectManagement_JobComponentCustom1,
        //        Maintenance_ProjectManagement_JobComponentCustom2,
        //        Maintenance_ProjectManagement_JobComponentCustom3,
        //        Maintenance_ProjectManagement_JobComponentCustom4,
        //        Maintenance_ProjectManagement_JobComponentCustom5,
        //        Maintenance_ProjectManagement_JobCustom1,
        //        Maintenance_ProjectManagement_JobCustom2,
        //        Maintenance_ProjectManagement_JobCustom3,
        //        Maintenance_ProjectManagement_JobCustom4,
        //        Maintenance_ProjectManagement_JobCustom5,
        //        Maintenance_ProjectManagement_JobCustomTabNames,
        //        Maintenance_ProjectManagement_JobSpecification,
        //        Maintenance_ProjectManagement_JobTemplate,
        //        Maintenance_ProjectManagement_JobType,
        //        Maintenance_ProjectManagement_JobVersionTemplate,
        //        Maintenance_ProjectManagement_PrintSpecStatus,
        //        Maintenance_ProjectManagement_ProductionSettings,
        //        Maintenance_ProjectManagement_PromotionType,
        //        Maintenance_ProjectManagement_PurchaseOrderApproval,
        //        Maintenance_ProjectManagement_Resource,
        //        Maintenance_ProjectManagement_ResourceType,
        //        Maintenance_ProjectManagement_SalesClassFormat,
        //        Maintenance_ProjectManagement_Timesheet,
        //        Maintenance_ProjectManagement_VendorPricing,
        //        Maintenance_ProjectSchedule,
        //        Maintenance_ProjectSchedule_Phase,
        //        Maintenance_ProjectSchedule_Role,
        //        Maintenance_ProjectSchedule_Settings,
        //        Maintenance_ProjectSchedule_Status,
        //        Maintenance_ProjectSchedule_Task,
        //        Maintenance_ProjectSchedule_TaskTemplate,
        //        Media,
        //        Media_AuthorizationToBuy,
        //        Media_BroadcastOrders,
        //        Media_BroadcastOrdersRadio,
        //        Media_BroadcastOrdersTV,
        //        Media_BroadcastRec,
        //        Media_BroadcastRecDelete,
        //        Media_BroadcastResearchTool,
        //        Media_ComscoreTester,
        //        Media_COREConnect,
        //        Media_DigitalCampaignManager,
        //        Media_DigitalResults,
        //        Media_Imports,
        //        Media_Imports_BroadcastImport,
        //        Media_Imports_MediaImport,
        //        Media_InternetOrders,
        //        Media_MagazineOrders,
        //        Media_MediaApprovalReconciliation,
        //        Media_MediaBroadcastWorksheet,
        //        Media_MediaBroadcastWorksheet_Actions,
        //        Media_MediaBroadcastWorksheet_Actions_MediaTraffic,
        //        Media_MediaBroadcastWorksheet_Actions_SpotMatching,
        //        Media_MediaCalendar,
        //        Media_MediaEstimating,
        //        Media_MediaManager,
        //        Media_MediaManager_Actions,
        //        Media_MediaManager_Actions_AdServing,
        //        Media_MediaManager_Actions_ApproveInvoices,
        //        Media_MediaManager_Actions_BillingApproval,
        //        Media_MediaManager_Actions_CreateAP,
        //        Media_MediaManager_Actions_CreateVCC,
        //        Media_MediaManager_Actions_GenerateOrders,
        //        Media_MediaManager_Actions_Include_PurchaseOrders,
        //        Media_MediaManager_Actions_UpdateCost,
        //        Media_MediaManager_Actions_VirtualCC,
        //        Media_MediaManager_Actions_WriteUpDown,
        //        Media_MediaPlanning,
        //        Media_MediaPlanning_Actions,
        //        Media_MediaPlanning_Actions_AllowActualizationToVaryFromLastPlan,
        //        Media_MediaPlanning_Actions_Approval,
        //        Media_MediaPlanning_Actions_EditTemplate,
        //        Media_MediaResearchTester,
        //        Media_NewspaperOrders,
        //        Media_nFusionMRP,
        //        Media_OrderProcessCtrl,
        //        Media_OrdersGlobalEdit,
        //        Media_OutofHomeOrders,
        //        Media_Reports,
        //        Media_Reports_MediaCurrentStatusRTP,
        //        Media_Reports_MediaSpecificationRPT,
        //        Media_Reports_MediaOrderFormsRTP,
        //        Media_Reports_MediaOrderReportsRTP,
        //        Media_STRATAConnect,
        //        Miscellaneous,
        //        Miscellaneous_DesktopObjects,
        //        Miscellaneous_DesktopObjects_CurrentConditionsDO,
        //        Miscellaneous_DesktopObjects_CurrentTimeDO,
        //        Miscellaneous_DesktopObjects_NewsReaderDO,
        //        Miscellaneous_DesktopObjects_QuoteoftheDayDO,
        //        Miscellaneous_DesktopObjects_WordoftheDayDO,
        //        ProjectManagement,
        //        ProjectManagement_AccountSetupForm,
        //        ProjectManagement_Boards,
        //        ProjectManagement_Campaigns,
        //        ProjectManagement_CreativeBrief,
        //        ProjectManagement_DashboardQueries,
        //        ProjectManagement_DashboardQueries_EmployeeTimePDQ,
        //        ProjectManagement_DashboardQueries_OpenJobsDQ,
        //        ProjectManagement_DashboardQueries_ProjectStatisticsDQ,
        //        ProjectManagement_DashboardQueries_PurchaseOrdersDQ,
        //        ProjectManagement_DashboardQueries_QuotevsActualsDQ,
        //        ProjectManagement_DesktopObjects,
        //        ProjectManagement_DesktopObjects_AllProjectsDO,
        //        ProjectManagement_DesktopObjects_BudgetViewpointDO,
        //        ProjectManagement_DesktopObjects_HoursViewpointDO,
        //        ProjectManagement_DesktopObjects_MyProjectsDO,
        //        ProjectManagement_DesktopObjects_MyQvADO,
        //        ProjectManagement_DesktopObjects_MyTasksDO,
        //        ProjectManagement_DesktopObjects_ProjectStatisticsbyOfficeHDO,
        //        ProjectManagement_DesktopObjects_ProjectStatisticsbyOfficeVDO,
        //        ProjectManagement_DesktopObjects_ProjectStatisticsDO,
        //        ProjectManagement_DesktopObjects_ProjectStatisticsGraphDO,
        //        ProjectManagement_DesktopObjects_ProjectViewpointDO,
        //        ProjectManagement_DesktopObjects_ProjectViewpointSnapshot,
        //        ProjectManagement_DesktopObjects_QvADO,
        //        ProjectManagement_DesktopObjects_TaskListDO,
        //        ProjectManagement_Documents,
        //        ProjectManagement_EmployeeCalendar,
        //        ProjectManagement_Estimating,
        //        ProjectManagement_Events,
        //        ProjectManagement_Events_EventsScheduler,
        //        ProjectManagement_Events_EventTasksScheduler,
        //        ProjectManagement_Imports,
        //        ProjectManagement_Imports_EstimateImport,
        //        ProjectManagement_JobJacket,
        //        ProjectManagement_JobVersions,
        //        ProjectManagement_ProjectEvents,
        //        ProjectManagement_ProjectSchedule,
        //        ProjectManagement_ProjectScheduleEdit,
        //        ProjectManagement_PurchaseOrders,
        //        ProjectManagement_QuoteApproval,
        //        ProjectManagement_Reports,
        //        ProjectManagement_Reports_CampaignsRTP,
        //        ProjectManagement_Reports_EmployeeHoursWorkedRTP,
        //        ProjectManagement_Reports_EstimateFormsRTP,
        //        ProjectManagement_Reports_EstimatePrintingRTP,
        //        ProjectManagement_Reports_EstimateReportsRTP,
        //        ProjectManagement_Reports_EventScheduleRTP,
        //        ProjectManagement_Reports_JobAnalysisRTP,
        //        ProjectManagement_Reports_JobDetailAnalysisRTP,
        //        ProjectManagement_Reports_JobDetailAnalysisOldRTP,
        //        ProjectManagement_Reports_JobOrderFormsRTP,
        //        ProjectManagement_Reports_JobsRTP,
        //        ProjectManagement_Reports_JobStatusRPT,
        //        ProjectManagement_Reports_JobVersionRPT,
        //        ProjectManagement_Reports_MyTaskListRTP,
        //        ProjectManagement_Reports_OpenJobsRTP,
        //        ProjectManagement_Reports_ProjectHoursRTP,
        //        ProjectManagement_Reports_ProjectSummaryRTP,
        //        ProjectManagement_Reports_PurchaseOrderFormsRTP,
        //        ProjectManagement_Reports_PurchaseOrderReportsRTP,
        //        ProjectManagement_Reports_PurchaseOrderReportRTP,
        //        ProjectManagement_Reports_ResourcesRTP,
        //        ProjectManagement_Reports_SprintRTP,
        //        ProjectManagement_Reports_TaskListRTP,
        //        ProjectManagement_Reports_TrafficByDayRTP,
        //        ProjectManagement_Reports_TrafficByTaskRTP,
        //        ProjectManagement_Reports_TrafficRTP,
        //        ProjectManagement_Specifications,
        //        ProjectManagement_TrafficTimeline,
        //        Security,
        //        Security_ChangePassword,
        //        Security_ClientPortalSettings,
        //        Security_Reports,
        //        Security_Reports_SecurityReportRTP,
        //        Security_RepositorySettings,
        //        Security_PasswordPolicy,
        //        Security_SelectReports,
        //        Security_Setup,
        //        Security_Setup_CDPSecurityGroup,
        //        Security_Setup_ClientPortalUser,
        //        Security_Setup_Group,
        //        Security_Setup_ModuleAccess,
        //        Security_Setup_User,
        //        Security_Setup_UserDefinedReportAccess
        //    }







        //    public static bool WriteToWebvantageEventLog { get; set; } = true;


        //    public static string RandomAlphaStringKey(int KeyLength)
        //    {
        //        Random Rand = new Random();
        //        System.Text.StringBuilder Key = new System.Text.StringBuilder();
        //        string s = string.Empty;

        //        for (Int32 i = 0; i <= KeyLength - 1; i++)

        //            Key.Append(String.Chr(Rand.Next(65, 90)));

        //        s = Key.ToString().ToUpper();

        //        if (s.Length > KeyLength)
        //            s = s.Substring(0, KeyLength);

        //        // Make sure random string does not randomly generate naughty words or words that appear naughty or possibly offensive
        //        if (s.Contains("SHIT") || s.Contains("SHT") || s.Contains("FUCK") || s.Contains("FCK") || s.Contains("FUK") || s.Contains("PUS") || s.Contains("PSSY") || s.Contains("DICK") || s.Contains("COCK") || s.Contains("CCK") || s.Contains("PIS") || s.Contains("BOOB") || s.Contains("FML") || s.Contains("BUTT"))
        //            RandomAlphaStringKey(KeyLength);

        //        return Key.ToString().ToUpper();
        //    }
        //    public static bool UserHasAccessToEmployee(AdvantageFramework.Core.Security.Session SecuritySession, string UserCode, string EmployeeCode)
        //    {
        //        bool HasAccess = false;
        //        System.Security.Database.Entities.UserEmployeeAccess UserEmployeeAccess = null/* TODO Change to default(_) if this is not a reference type */;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //        {
        //            UserEmployeeAccess = AdvantageFramework.Core.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCodeAndEmployeeCode(SecurityDbContext, UserCode, EmployeeCode);

        //            HasAccess = (UserEmployeeAccess != null);

        //            if (HasAccess == false)
        //                HasAccess = UserIsEmployeeManager(SecuritySession, UserCode, EmployeeCode);
        //        }

        //        UserHasAccessToEmployee = HasAccess;
        //    }
        //    public static bool UserIsEmployeeManager(AdvantageFramework.Core.Security.Session SecuritySession, string UserCode, string EmployeeCode)
        //    {
        //        bool IsEmployeeManager = false;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //        {
        //            using (var DbContext = new AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //            {
        //                IsEmployeeManager = (from Entity in AdvantageFramework.Database.Procedures.EmployeeView.LoadAllEmployeesByUser(DbContext, SecurityDbContext, UserCode)
        //                                     where Entity.Code == EmployeeCode
        //                                     select Entity).Count > 0;
        //            }
        //        }

        //        UserIsEmployeeManager = IsEmployeeManager;
        //    }
        //    public static bool IsMediaToolUser(AdvantageFramework.Core.Security.Session SecuritySession, int UserID)
        //    {

        //        // objects
        //        bool IsAMediaToolUser = false;
        //        AdvantageFramework.Core.Security.Database.Entities.UserSetting UserSetting = null/* TODO Change to default(_) if this is not a reference type */;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //        {
        //            try
        //            {
        //                UserSetting = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Core.Security.UserSettings.IsMediaToolsUser.ToString);
        //            }
        //            catch (Exception ex)
        //            {
        //                UserSetting = null/* TODO Change to default(_) if this is not a reference type */;
        //            }

        //            if (UserSetting != null)
        //                IsAMediaToolUser = IsMediaToolUser(UserSetting.User.UserCode, UserSetting.StringValue);
        //        }

        //        IsMediaToolUser = IsAMediaToolUser;
        //    }
        //    public static bool IsMediaToolUser(string UserCode, string StringValue)
        //    {

        //        // objects
        //        bool IsAMediaToolUser = false;

        //        if (string.IsNullOrEmpty(StringValue) == false && AdvantageFramework.Core.Security.Encryption.Decrypt(StringValue) == UserCode)
        //            IsAMediaToolUser = true;

        //        IsMediaToolUser = IsAMediaToolUser;
        //    }
        //    public static bool IsAPIUser(string EmployeeCode, string StringValue)
        //    {

        //        // objects
        //        bool IsAAPIUser = false;

        //        if (string.IsNullOrEmpty(StringValue) == false && AdvantageFramework.Core.Security.Encryption.Decrypt(StringValue) == EmployeeCode)
        //            IsAAPIUser = true;

        //        IsAPIUser = IsAAPIUser;
        //    }
        public static void AddToProofingEventLog(string Message, System.Diagnostics.EventLogEntryType EntryType = System.Diagnostics.EventLogEntryType.Information)
        {
            // objects
            string EventLogName = "Adv Proofing";
            string EventSource = "";
            System.Diagnostics.EventLog EventLog = null;

            // Create an EventLog **instance** and assign its source.
            // Actual EventLog must be created outside of code running through IIS.  Using the Configurator.

            EventLog = new System.Diagnostics.EventLog(EventLogName);

            EventSource = "Adv Proofing Event";

            EventLog.Source = EventSource;
            // Write the error entry to the event log.    
            EventLog.WriteEntry(Message, EntryType);
        }

        //    // Public Function LoadSQLLogins(ByVal Session As AdvantageFramework.Core.Security.Session) As Generic.List(Of AdvantageFramework.Core.Security.Database.Classes.SQLLogin)

        //    // 'objects
        //    // Dim SQLLoginList As Generic.List(Of AdvantageFramework.Core.Security.Database.Classes.SQLLogin) = Nothing
        //    // Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        //    // Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

        //    // Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

        //    // End Using

        //    // Using SecurityDbContext = New AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

        //    // SecurityDbContext.Database.Connection.Open()

        //    // SQLLoginList = New Generic.List(Of AdvantageFramework.Core.Security.Database.Classes.SQLLogin)

        //    // If (Session.IsSysAdmin OrElse Session.IsSecurityAdmin) AndAlso Agency.IsASP.GetValueOrDefault(0) = 0 Then

        //    // For Each ServerSQLUser In AdvantageFramework.Core.Security.Database.Procedures.ServerSQLUserView.LoadAvailableSQLUsers(SecurityDbContext).ToList

        //    // If AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserName(SecurityDbContext, ServerSQLUser.Name) Is Nothing Then

        //    // SQLLoginList.Add(New AdvantageFramework.Core.Security.Database.Classes.SQLLogin(ServerSQLUser))

        //    // End If

        //    // Next

        //    // For Each DatabaseSQLUser In AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.Load(SecurityDbContext).Where(Function(DBSQLUser) (DBSQLUser.Type = "S" OrElse DBSQLUser.Type = "U") AndAlso
        //    // DBSQLUser.Name <> "dbo" AndAlso
        //    // DBSQLUser.DefaultSchemaName = "dbo").ToList

        //    // If AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserName(SecurityDbContext, DatabaseSQLUser.Name) Is Nothing Then

        //    // If AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBDataReader(SecurityDbContext, DatabaseSQLUser.ID) Then

        //    // If AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBDataWriter(SecurityDbContext, DatabaseSQLUser.ID) Then

        //    // SQLLoginList.Add(New AdvantageFramework.Core.Security.Database.Classes.SQLLogin(DatabaseSQLUser))

        //    // End If

        //    // End If

        //    // End If

        //    // Next

        //    // ElseIf Session.IsDBOwner OrElse Session.IsDBSecurityAdmin OrElse Session.IsDBAccessAdmin Then

        //    // For Each DatabaseSQLUser In AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.Load(SecurityDbContext).Where(Function(DBSQLUser) (DBSQLUser.Type = "S" OrElse DBSQLUser.Type = "U") AndAlso
        //    // DBSQLUser.Name <> "dbo" AndAlso
        //    // DBSQLUser.DefaultSchemaName = "dbo").ToList

        //    // If AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserName(SecurityDbContext, DatabaseSQLUser.Name) Is Nothing Then

        //    // If AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBDataReader(SecurityDbContext, DatabaseSQLUser.ID) Then

        //    // If AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserDBDataWriter(SecurityDbContext, DatabaseSQLUser.ID) Then

        //    // SQLLoginList.Add(New AdvantageFramework.Core.Security.Database.Classes.SQLLogin(DatabaseSQLUser))

        //    // End If

        //    // End If

        //    // End If

        //    // Next

        //    // End If

        //    // End Using

        //    // LoadSQLLogins = SQLLoginList

        //    // End Function
        //    public static string LoadReportTypeName(Int16 ReportType)
        //    {

        //        // objects
        //        string ReportTypeName = "";

        //        if (ReportType == 21 || ReportType == 33 || ReportType == 53 || ReportType == 54 || ReportType == 55 || ReportType == 59 || ReportType == 60 || ReportType == 61 || ReportType == 93 || ReportType == 94 || ReportType == 115)
        //            ReportTypeName = "Accounting/Finance";
        //        else if (ReportType == 105)
        //            ReportTypeName = "Client Budgets";
        //        else if (ReportType == 101)
        //            ReportTypeName = "Estimate Forms";
        //        else if (ReportType == 100)
        //            ReportTypeName = "Job Analysis";
        //        else if (ReportType == 102)
        //            ReportTypeName = "Job Order Forms";
        //        else if (ReportType == 109)
        //            ReportTypeName = "Maintenance : Employee";
        //        else if (ReportType == 1)
        //            ReportTypeName = "Maintenance : Reports";
        //        else if (ReportType == 114)
        //            ReportTypeName = "Maintenance : Task Templates";
        //        else if (ReportType == 103)
        //            ReportTypeName = "Maintenance : Vendor";
        //        else if (ReportType == 110)
        //            ReportTypeName = "Management Reports";
        //        else if (ReportType == 62)
        //            ReportTypeName = "Media";
        //        else if (ReportType == 106)
        //            ReportTypeName = "Month End Reports - 300 Series";
        //        else if (ReportType == 108)
        //            ReportTypeName = "Month End Reports - 400 Series";
        //        else if (ReportType == 112)
        //            ReportTypeName = "Month End Reports - 500 Series";
        //        else if (ReportType == 111)
        //            ReportTypeName = "Month End Reports - 600 Series";
        //        else if (ReportType == 113)
        //            ReportTypeName = "Month End Reports - 700 Series";
        //        else if (ReportType == 3 || ReportType == 5 || ReportType == 7 || ReportType == 8)
        //            ReportTypeName = "Project Management";
        //        else
        //            ReportTypeName = "";

        //        LoadReportTypeName = ReportTypeName;
        //    }
        //    public static void ClearNewAdvantageApplicationsAlertSetting(AdvantageFramework.Core.Security.Session SecuritySession)
        //    {

        //        // objects
        //        AdvantageFramework.Core.Security.Database.Entities.UserSetting UserSetting = null/* TODO Change to default(_) if this is not a reference type */;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //        {
        //            try
        //            {
        //                UserSetting = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, SecuritySession.User.ID, AdvantageFramework.Core.Security.UserSettings.NewAdvantageApplicationsAlert.ToString);
        //            }
        //            catch (Exception ex)
        //            {
        //                UserSetting = null/* TODO Change to default(_) if this is not a reference type */;
        //            }

        //            if (UserSetting != null)
        //            {
        //                UserSetting.NumericValue = 0;

        //                if (AdvantageFramework.Core.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting))
        //                    AdvantageFramework.Navigation.ClearNotificationAlert();
        //            }
        //        }
        //    }
        //    public static bool LoadNewAdvantageApplicationsAlertSetting(AdvantageFramework.Core.Security.Session SecuritySession, ref string AlertMessage)
        //    {

        //        // objects
        //        bool HasNewAdvantageApplicationsAlert = false;
        //        AdvantageFramework.Core.Security.Database.Entities.UserSetting UserSetting = null/* TODO Change to default(_) if this is not a reference type */;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //        {
        //            try
        //            {
        //                UserSetting = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, SecuritySession.User.ID, AdvantageFramework.Core.Security.UserSettings.NewAdvantageApplicationsAlert.ToString);
        //            }
        //            catch (Exception ex)
        //            {
        //                UserSetting = null/* TODO Change to default(_) if this is not a reference type */;
        //            }

        //            if (UserSetting != null)
        //            {
        //                if (UserSetting.NumericValue.GetValueOrDefault(0) == 1)
        //                {
        //                    HasNewAdvantageApplicationsAlert = true;
        //                    AlertMessage = UserSetting.StringValue;
        //                }
        //            }
        //        }

        //        LoadNewAdvantageApplicationsAlertSetting = HasNewAdvantageApplicationsAlert;
        //    }
        //    public static bool SaveUserSetting(AdvantageFramework.Core.Security.Session SecuritySession, int UserID, AdvantageFramework.Core.Security.UserSettings UserSetting, object SettingValue)
        //    {
        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //        {
        //            SaveUserSetting = SaveSetting(SecurityDbContext, UserID, typeof(AdvantageFramework.Core.Security.UserSettings), UserSetting.ToString, SettingValue);
        //        }
        //    }
        //    public static bool SaveGroupSetting(AdvantageFramework.Core.Security.Session SecuritySession, int GroupID, AdvantageFramework.Core.Security.GroupSettings GroupSetting, object SettingValue)
        //    {
        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //        {
        //            SaveGroupSetting = SaveSetting(SecurityDbContext, GroupID, typeof(AdvantageFramework.Core.Security.GroupSettings), GroupSetting.ToString, SettingValue);
        //        }
        //    }
        //    private static bool SaveSetting(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, int ID, System.Type SettingType, string Setting, object SettingValue)
        //    {

        //        // objects
        //        bool Saved = false;
        //        AdvantageFramework.Core.Security.Database.Entities.UserSetting UserSetting = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.GroupSetting GroupSetting = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Attributes.SecuritySettingAttribute SecuritySettingAttribute = null/* TODO Change to default(_) if this is not a reference type */;
        //        object ParsedSettingValue = null;

        //        try
        //        {
        //            try
        //            {
        //                SecuritySettingAttribute = System.Attribute.GetCustomAttribute(SettingType.GetField(Setting.ToString()), typeof(AdvantageFramework.Core.Security.Attributes.SecuritySettingAttribute));
        //            }
        //            catch (Exception ex)
        //            {
        //            }

        //            if (SecuritySettingAttribute != null)
        //            {
        //                if (SecuritySettingAttribute.ValueType == SettingsValueType.StringValue)
        //                {
        //                    if (SecuritySettingAttribute.ParseValueType == SettingsParseValueType.String_Boolean_YN)
        //                    {
        //                        try
        //                        {
        //                            if (SettingValue is bool)
        //                            {
        //                                if (SettingValue)
        //                                    ParsedSettingValue = "Y";
        //                                else
        //                                    ParsedSettingValue = "N";
        //                            }
        //                            else if (SettingValue is string)
        //                            {
        //                                if (SettingValue == "N")
        //                                    ParsedSettingValue = "N";
        //                                else
        //                                    ParsedSettingValue = "Y";
        //                            }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            ParsedSettingValue = null;
        //                        }

        //                        if (ParsedSettingValue == null)
        //                        {
        //                            if (SecuritySettingAttribute.DefaultValue == "N")
        //                                ParsedSettingValue = "N";
        //                            else
        //                                ParsedSettingValue = "Y";
        //                        }
        //                    }
        //                    else
        //                        try
        //                        {
        //                            ParsedSettingValue = (string)SettingValue;
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            ParsedSettingValue = null;
        //                        }
        //                }
        //                else if (SecuritySettingAttribute.ValueType == SettingsValueType.NumericValue)
        //                {
        //                    if (SecuritySettingAttribute.ParseValueType == SettingsParseValueType.Numeric_Boolean_10)
        //                    {
        //                        try
        //                        {
        //                            if (SettingValue is bool)
        //                            {
        //                                if (SettingValue)
        //                                    ParsedSettingValue = (decimal)1;
        //                                else
        //                                    ParsedSettingValue = (decimal)0;
        //                            }
        //                            else if (Information.IsNumeric(SettingValue))
        //                            {
        //                                if (System.Convert.ToDecimal(SettingValue) == 0)
        //                                    ParsedSettingValue = (decimal)0;
        //                                else
        //                                    ParsedSettingValue = (decimal)1;
        //                            }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            ParsedSettingValue = null;
        //                        }

        //                        if (ParsedSettingValue == null)
        //                        {
        //                            if (SecuritySettingAttribute.DefaultValue == "0")
        //                                ParsedSettingValue = (decimal)0;
        //                            else
        //                                ParsedSettingValue = (decimal)1;
        //                        }
        //                    }
        //                    else
        //                        try
        //                        {
        //                            ParsedSettingValue = (decimal)SettingValue;
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            ParsedSettingValue = null;
        //                        }
        //                }
        //                else if (SecuritySettingAttribute.ValueType == SettingsValueType.DateValue)
        //                {
        //                    try
        //                    {
        //                        ParsedSettingValue = (DateTime)SettingValue;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        ParsedSettingValue = null;
        //                    }
        //                }

        //                if (SettingType.Name == typeof(AdvantageFramework.Core.Security.UserSettings).Name)
        //                {
        //                    try
        //                    {
        //                        UserSetting = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, ID, Setting);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        UserSetting = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }

        //                    if (UserSetting == null)
        //                    {
        //                        if (SecuritySettingAttribute.ValueType == SettingsValueType.StringValue)
        //                            Saved = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, ID, Setting, ParsedSettingValue, null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */, UserSetting);
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.NumericValue)
        //                            Saved = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, ID, Setting, null/* TODO Change to default(_) if this is not a reference type */, ParsedSettingValue, null/* TODO Change to default(_) if this is not a reference type */, UserSetting);
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.DateValue)
        //                            Saved = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, ID, Setting, null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */, ParsedSettingValue, UserSetting);
        //                    }
        //                    else
        //                    {
        //                        if (SecuritySettingAttribute.ValueType == SettingsValueType.StringValue)
        //                            UserSetting.StringValue = ParsedSettingValue;
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.NumericValue)
        //                            UserSetting.NumericValue = ParsedSettingValue;
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.DateValue)
        //                            UserSetting.DateValue = ParsedSettingValue;

        //                        Saved = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting);
        //                    }
        //                }
        //                else
        //                {
        //                    try
        //                    {
        //                        GroupSetting = AdvantageFramework.Core.Security.Database.Procedures.GroupSetting.LoadByGroupIDAndSettingCode(SecurityDbContext, ID, Setting);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        GroupSetting = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }

        //                    if (GroupSetting == null)
        //                    {
        //                        if (SecuritySettingAttribute.ValueType == SettingsValueType.StringValue)
        //                            Saved = AdvantageFramework.Core.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, ID, Setting, ParsedSettingValue, null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */, GroupSetting);
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.NumericValue)
        //                            Saved = AdvantageFramework.Core.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, ID, Setting, null/* TODO Change to default(_) if this is not a reference type */, ParsedSettingValue, null/* TODO Change to default(_) if this is not a reference type */, GroupSetting);
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.DateValue)
        //                            Saved = AdvantageFramework.Core.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, ID, Setting, null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */, ParsedSettingValue, GroupSetting);
        //                    }
        //                    else
        //                    {
        //                        if (SecuritySettingAttribute.ValueType == SettingsValueType.StringValue)
        //                            GroupSetting.StringValue = ParsedSettingValue;
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.NumericValue)
        //                            GroupSetting.NumericValue = ParsedSettingValue;
        //                        else if (SecuritySettingAttribute.ValueType == SettingsValueType.DateValue)
        //                            GroupSetting.DateValue = ParsedSettingValue;

        //                        Saved = AdvantageFramework.Core.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Saved = false;
        //        }
        //        finally
        //        {
        //            SaveSetting = Saved;
        //        }
        //    }
        //    private static object LoadSetting(AdvantageFramework.Core.Security.Session SecuritySession, int ID, System.Type SettingType, string Setting)
        //    {

        //        // objects
        //        object SettingEntity = null;
        //        AdvantageFramework.Core.Security.Attributes.SecuritySettingAttribute SecuritySettingAttribute = null/* TODO Change to default(_) if this is not a reference type */;
        //        object SettingValue = null;
        //        AdvantageFramework.Core.Security.Database.Entities.GroupUser GroupUser = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Classes.User User = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            try
        //            {
        //                SecuritySettingAttribute = System.Attribute.GetCustomAttribute(SettingType.GetField(Setting.ToString()), typeof(AdvantageFramework.Core.Security.Attributes.SecuritySettingAttribute));
        //            }
        //            catch (Exception ex)
        //            {
        //            }

        //            if (SecuritySettingAttribute != null)
        //            {
        //                if (SettingType.Name == typeof(AdvantageFramework.Core.Security.UserSettings).Name)
        //                {
        //                    using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //                    {
        //                        try
        //                        {
        //                            SettingEntity = AdvantageFramework.Core.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, ID, Setting);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            SettingEntity = null;
        //                        }
        //                    }
        //                }
        //                else
        //                    using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //                    {
        //                        try
        //                        {
        //                            SettingEntity = AdvantageFramework.Core.Security.Database.Procedures.GroupSetting.LoadByGroupIDAndSettingCode(SecurityDbContext, ID, Setting);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            SettingEntity = null;
        //                        }
        //                    }

        //                if (SettingEntity != null)
        //                {
        //                    switch (SecuritySettingAttribute.ValueType)
        //                    {
        //                        case SettingsValueType.StringValue:
        //                            {
        //                                switch (SecuritySettingAttribute.ParseValueType)
        //                                {
        //                                    case SettingsParseValueType.String_Boolean_YN:
        //                                        {
        //                                            if (SettingEntity.StringValue == "Y")
        //                                                SettingValue = true;
        //                                            else
        //                                                SettingValue = false;
        //                                            break;
        //                                        }

        //                                    default:
        //                                        {
        //                                            SettingValue = SettingEntity.StringValue;
        //                                            break;
        //                                        }
        //                                }

        //                                break;
        //                            }

        //                        case SettingsValueType.NumericValue:
        //                            {
        //                                switch (SecuritySettingAttribute.ParseValueType)
        //                                {
        //                                    case SettingsParseValueType.Numeric_Boolean_10:
        //                                        {
        //                                            if (SettingEntity.NumericValue == 1)
        //                                                SettingValue = true;
        //                                            else
        //                                                SettingValue = false;
        //                                            break;
        //                                        }

        //                                    default:
        //                                        {
        //                                            SettingValue = SettingEntity.NumericValue;
        //                                            break;
        //                                        }
        //                                }

        //                                break;
        //                            }

        //                        case SettingsValueType.DateValue:
        //                            {
        //                                SettingValue = SettingEntity.DateValue;
        //                                break;
        //                            }
        //                    }
        //                }
        //                else
        //                    switch (SecuritySettingAttribute.ParseValueType)
        //                    {
        //                        case SettingsParseValueType.Default:
        //                            {
        //                                SettingValue = SecuritySettingAttribute.DefaultValue;
        //                                break;
        //                            }

        //                        case SettingsParseValueType.Numeric_Boolean_10:
        //                            {
        //                                if (IsNumeric(SecuritySettingAttribute.DefaultValue))
        //                                    SettingValue = (bool)SecuritySettingAttribute.DefaultValue;
        //                                else
        //                                    SettingValue = false;
        //                                break;
        //                            }

        //                        case SettingsParseValueType.String_Boolean_YN:
        //                            {
        //                                if (SecuritySettingAttribute.DefaultValue == "N")
        //                                    SettingValue = false;
        //                                else
        //                                    SettingValue = true;
        //                                break;
        //                            }
        //                    }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            SettingValue = null;
        //        }
        //        finally
        //        {
        //            LoadSetting = SettingValue;
        //        }
        //    }
        //    public static object LoadUserSetting(AdvantageFramework.Core.Security.Session SecuritySession, int UserID, AdvantageFramework.Core.Security.UserSettings UserSetting)
        //    {
        //        LoadUserSetting = LoadSetting(SecuritySession, UserID, typeof(AdvantageFramework.Core.Security.UserSettings), UserSetting.ToString);
        //    }
        //    public static object LoadGroupSetting(AdvantageFramework.Core.Security.Session SecuritySession, int GroupID, AdvantageFramework.Core.Security.GroupSettings GroupSetting)
        //    {
        //        LoadGroupSetting = LoadSetting(SecuritySession, GroupID, typeof(AdvantageFramework.Core.Security.GroupSettings), GroupSetting.ToString);
        //    }
        //    public static Generic.List<object> LoadUserGroupSetting(AdvantageFramework.Core.Security.Session SecuritySession, AdvantageFramework.Core.Security.GroupSettings GroupSetting)
        //    {

        //        // objects
        //        Generic.List<object> SettingValues = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Classes.User User = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Classes.ClientPortalUser CPUser = null/* TODO Change to default(_) if this is not a reference type */;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //        {
        //            if (SecuritySession.Application == Application.Client_Portal)
        //                CPUser = SecuritySession.ClientPortalUser;
        //            else
        //                User = SecuritySession.User;

        //            SettingValues = new Generic.List<object>();

        //            if (SecuritySession.Application != Application.Client_Portal)
        //            {
        //                foreach (var GroupUser in AdvantageFramework.Core.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).ToList)

        //                    SettingValues.Add(LoadSetting(SecuritySession, GroupUser.GroupID, typeof(AdvantageFramework.Core.Security.GroupSettings), GroupSetting.ToString));
        //            }
        //        }

        //        LoadUserGroupSetting = SettingValues;
        //    }
        //    public static Generic.List<object> LoadUserGroupSetting(string ConnectionString, string UserCode, System.Security.Application Application, AdvantageFramework.Core.Security.GroupSettings GroupSetting)
        //    {

        //        // objects
        //        Generic.List<object> SettingValues = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Classes.User User = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Session SecuritySession = null/* TODO Change to default(_) if this is not a reference type */;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(ConnectionString, UserCode))
        //        {
        //            SettingValues = new Generic.List<object>();

        //            if (Application != Application.Client_Portal)
        //            {
        //                User = new AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode));

        //                if (User != null)
        //                {
        //                    SecuritySession = new System.Security.Session(Application, ConnectionString, UserCode, 0, ConnectionString);

        //                    foreach (var GroupUser in AdvantageFramework.Core.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).ToList)

        //                        SettingValues.Add(LoadSetting(SecuritySession, GroupUser.GroupID, typeof(AdvantageFramework.Core.Security.GroupSettings), GroupSetting.ToString));
        //                }
        //            }
        //        }

        //        LoadUserGroupSetting = SettingValues;
        //    }
        //    public static string LoadDescriptionForModule(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, AdvantageFramework.Core.Security.Database.Views.ModuleView Module)
        //    {

        //        // objects
        //        string ModuleDescription = "";

        //        if (Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom1.ToString || Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom2.ToString || Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom3.ToString || Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom4.ToString || Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom5.ToString)
        //        {
        //            try
        //            {
        //                ModuleDescription = SecurityDbContext.Database.SqlQuery<string>(string.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV{0}'", Module.ModuleCode.Substring(Module.ModuleCode.Length - 1))).FirstOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                ModuleDescription = "";
        //            }
        //        }
        //        else if (Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom1.ToString || Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom2.ToString || Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom3.ToString || Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom4.ToString || Module.ModuleCode == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom5.ToString)
        //        {
        //            try
        //            {
        //                ModuleDescription = SecurityDbContext.Database.SqlQuery<string>(string.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV{0}'", Module.ModuleCode.Substring(Module.ModuleCode.Length - 1))).FirstOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                ModuleDescription = "";
        //            }
        //        }

        //        if (ModuleDescription == "")
        //            ModuleDescription = Module.ModuleDescription;

        //        LoadDescriptionForModule = ModuleDescription;
        //    }
        //    public static string LoadDescriptionForModule(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, AdvantageFramework.Core.Security.Database.Entities.Module Module)
        //    {

        //        // objects
        //        string ModuleDescription = "";

        //        if (Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom1.ToString || Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom2.ToString || Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom3.ToString || Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom4.ToString || Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobCustom5.ToString)
        //        {
        //            try
        //            {
        //                ModuleDescription = SecurityDbContext.Database.SqlQuery<string>(string.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV{0}'", Module.Code.Substring(Module.Code.Length - 1))).FirstOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                ModuleDescription = "";
        //            }
        //        }
        //        else if (Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom1.ToString || Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom2.ToString || Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom3.ToString || Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom4.ToString || Module.Code == AdvantageFramework.Core.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom5.ToString)
        //        {
        //            try
        //            {
        //                ModuleDescription = SecurityDbContext.Database.SqlQuery<string>(string.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV{0}'", Module.Code.Substring(Module.Code.Length - 1))).FirstOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                ModuleDescription = "";
        //            }
        //        }

        //        if (ModuleDescription == "")
        //            ModuleDescription = Module.Description;

        //        LoadDescriptionForModule = ModuleDescription;
        //    }
        //    public static System.Drawing.Image LoadImageForModule(AdvantageFramework.Core.Security.Database.Entities.Module Module)
        //    {

        //        // objects
        //        object ImageObject = null;
        //        System.Drawing.Graphics Graphic = null/* TODO Change to default(_) if this is not a reference type */;
        //        System.Drawing.Image FinalImage = null/* TODO Change to default(_) if this is not a reference type */;
        //        bool InsertDefaultImage = true;

        //        if (Module != null)
        //        {
        //            try
        //            {
        //                ImageObject = AdvantageFramework.Images.LoadResource(Module.ModuleInformation.ImageName);
        //            }
        //            catch (Exception ex)
        //            {
        //                ImageObject = null;
        //            }

        //            if (ImageObject != null)
        //            {
        //                InsertDefaultImage = false;

        //                try
        //                {
        //                    if ((System.Drawing.Bitmap)ImageObject.Size.Height != 32 || (System.Drawing.Bitmap)ImageObject.Size.Width != 32)
        //                    {
        //                        FinalImage = new System.Drawing.Bitmap(32, 32);

        //                        Graphic = System.Drawing.Graphics.FromImage(FinalImage);

        //                        Graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //                        Graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //                        Graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //                        Graphic.DrawImage(ImageObject, 0, 0, 32, 32);
        //                    }
        //                    else
        //                        FinalImage = ImageObject;
        //                }
        //                catch (Exception ex)
        //                {
        //                    InsertDefaultImage = true;
        //                }
        //            }

        //            if (InsertDefaultImage)
        //            {
        //                if (Module.IsApplication)
        //                    FinalImage = AdvantageFramework.My.Resources.ApplicationImage;
        //                else if (Module.IsReport)
        //                    FinalImage = AdvantageFramework.My.Resources.ReportImage;
        //                else if (Module.IsDashQuery)
        //                    FinalImage = AdvantageFramework.My.Resources.DashboardAndQueryImage;
        //                else if (Module.IsDesktopObject)
        //                    FinalImage = AdvantageFramework.My.Resources.DesktopObjectImage;
        //                else if (Module.IsCategory)
        //                    FinalImage = AdvantageFramework.My.Resources.CategoryImage;
        //            }
        //        }

        //        LoadImageForModule = FinalImage;
        //    }
        //    public static System.Drawing.Image LoadImageForModule(AdvantageFramework.Core.Security.Database.Views.ModuleView Module)
        //    {

        //        // objects
        //        object ImageObject = null;
        //        System.Drawing.Graphics Graphic = null/* TODO Change to default(_) if this is not a reference type */;
        //        System.Drawing.Image FinalImage = null/* TODO Change to default(_) if this is not a reference type */;
        //        bool InsertDefaultImage = true;

        //        if (Module != null)
        //        {
        //            try
        //            {
        //                ImageObject = AdvantageFramework.Images.LoadResource(Module.ImageName);
        //            }
        //            catch (Exception ex)
        //            {
        //                ImageObject = null;
        //            }

        //            if (ImageObject != null)
        //            {
        //                InsertDefaultImage = false;

        //                try
        //                {
        //                    if ((System.Drawing.Bitmap)ImageObject.Size.Height != 32 || (System.Drawing.Bitmap)ImageObject.Size.Width != 32)
        //                    {
        //                        FinalImage = new System.Drawing.Bitmap(32, 32);

        //                        Graphic = System.Drawing.Graphics.FromImage(FinalImage);

        //                        Graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //                        Graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //                        Graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //                        Graphic.DrawImage(ImageObject, 0, 0, 32, 32);
        //                    }
        //                    else
        //                        FinalImage = ImageObject;
        //                }
        //                catch (Exception ex)
        //                {
        //                    InsertDefaultImage = true;
        //                }
        //            }

        //            if (InsertDefaultImage)
        //            {
        //                if (Module.IsApplication)
        //                    FinalImage = AdvantageFramework.My.Resources.ApplicationImage;
        //                else if (Module.IsReport)
        //                    FinalImage = AdvantageFramework.My.Resources.ReportImage;
        //                else if (Module.IsDashQuery)
        //                    FinalImage = AdvantageFramework.My.Resources.DashboardAndQueryImage;
        //                else if (Module.IsDesktopObject)
        //                    FinalImage = AdvantageFramework.My.Resources.DesktopObjectImage;
        //                else if (Module.IsCategory)
        //                    FinalImage = AdvantageFramework.My.Resources.CategoryImage;
        //            }
        //        }

        //        LoadImageForModule = FinalImage;
        //    }
        //    public static string LoadImageNameForModule(AdvantageFramework.Core.Security.Database.Views.ModuleView Module, bool UseIconFiles)
        //    {

        //        // objects
        //        string ImageName = null;

        //        if (Module != null)
        //        {
        //            ImageName = Module.ImageName;

        //            if (ImageName == "")
        //            {
        //                if (Module.IsApplication)
        //                {
        //                    if (Module.WebvantageImagePathActive != "")
        //                        ImageName = Module.WebvantageImagePathActive;
        //                    else if (UseIconFiles)
        //                        ImageName = "ApplicationIcon.ico";
        //                    else
        //                        ImageName = "ApplicationImage.png";
        //                }
        //                else if (Module.IsReport)
        //                {
        //                    if (Module.ReportImagePathActive != "")
        //                        ImageName = Module.ReportImagePathActive;
        //                    else if (UseIconFiles)
        //                        ImageName = "ReportIcon.ico";
        //                    else
        //                        ImageName = "ReportImage.png";
        //                }
        //                else if (Module.IsDashQuery)
        //                {
        //                    if (Module.WebvantageImagePathActive != "")
        //                        ImageName = Module.WebvantageImagePathActive;
        //                    else if (UseIconFiles)
        //                        ImageName = "DashboardAndQueryIcon.ico";
        //                    else
        //                        ImageName = "DashboardAndQueryImage.png";
        //                }
        //                else if (Module.IsDesktopObject)
        //                {
        //                    if (UseIconFiles)
        //                        ImageName = "DesktopObjectIcon.ico";
        //                    else
        //                        ImageName = "DesktopObjectImage.png";
        //                }
        //                else if (Module.IsCategory)
        //                {
        //                    if (UseIconFiles)
        //                        ImageName = "CategoryIcon.ico";
        //                    else
        //                        ImageName = "CategoryImage.png";
        //                }
        //            }
        //            else if (UseIconFiles)
        //                ImageName = ImageName.Substring(0, ImageName.IndexOf(".")).Replace("Image", "Icon") + ".ico";
        //        }

        //        LoadImageNameForModule = ImageName;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom1;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom1;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom1;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom1;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, Module.ToString, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Session Session, int ModuleID)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, Module.ToString, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Session Session, int ModuleID, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, ModuleID, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom1InModule(SecurityDbContext, Session.Application, ModuleCode, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom1InModule(AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom1;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom1InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom2;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom2;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom2;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom2;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, Module.ToString, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Session Session, int ModuleID)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, Module.ToString, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Session Session, int ModuleID, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, ModuleID, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserCustom2InModule(SecurityDbContext, Session.Application, ModuleCode, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserCustom2InModule(AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            if (UserPermission != null)
        //                HasAccess = UserPermission.Custom2;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserCustom2InModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanAdd;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanAdd;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanAdd;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, int UserID, Generic.List<AdvantageFramework.Core.Security.Database.Views.UserPermission> UserPermissionList)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            try
        //            {
        //                UserPermission = (from Entity in UserPermissionList
        //                                  where Entity.ApplicationID == ApplicationID && Entity.ModuleCode == ModuleCode && Entity.UserID == UserID
        //                                  select Entity).SingleOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                UserPermission = null/* TODO Change to default(_) if this is not a reference type */;
        //            }

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanAdd;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanAdd;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, Module.ToString, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Session Session, int ModuleID)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, Module.ToString, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Session Session, int ModuleID, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, ModuleID, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserAddInModule(SecurityDbContext, Session.Application, ModuleCode, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserAddInModule(AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanAdd;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserAddInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanUpdate;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanUpdate;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanUpdate;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanUpdate;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, Module.ToString, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Session Session, int ModuleID)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, Module.ToString, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Session Session, int ModuleID, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, ModuleID, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserUpdateInModule(SecurityDbContext, Session.Application, ModuleCode, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserUpdateInModule(AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanUpdate;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserUpdateInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanPrint;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanPrint;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanPrint;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID);

        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanPrint;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, Module.ToString, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Session Session, int ModuleID)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, Module.ToString, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Session Session, int ModuleID, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, ModuleID, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = CanUserPrintInModule(SecurityDbContext, Session.Application, ModuleCode, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool CanUserPrintInModule(AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            if (UserPermission != null)
        //                HasAccess = UserPermission.CanPrint;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        CanUserPrintInModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            HasAccess = DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserCode));
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, string UserCode)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            HasAccess = DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserCode));
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            HasAccess = DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleCode, UserID));
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, string ModuleCode, int UserID, Generic.List<AdvantageFramework.Core.Security.Database.Views.UserPermission> UserPermissionList)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserPermission = (from Entity in UserPermissionList
        //                              where Entity.ApplicationID == ApplicationID && Entity.ModuleCode == ModuleCode && Entity.UserID == UserID
        //                              select Entity).SingleOrDefault;
        //        }
        //        catch (Exception ex)
        //        {
        //            UserPermission = null/* TODO Change to default(_) if this is not a reference type */;
        //        }

        //        try
        //        {
        //            HasAccess = DoesUserHaveAccessToModule(UserPermission);
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.DbContext DbContext, int ApplicationID, int ModuleID, int UserID)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            HasAccess = DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext, ApplicationID, ModuleID, UserID));
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Database.Views.UserPermission UserPermission)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            if (UserPermission != null)
        //                HasAccess = !UserPermission.IsBlocked;
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, Module.ToString, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Session Session, int ModuleID)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleID, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleCode, Session.User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Session Session, AdvantageFramework.Core.Security.Modules Module, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, Module.ToString, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Session Session, int ModuleID, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleID, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode, AdvantageFramework.Core.Security.Classes.User User)
        //    {

        //        // objects
        //        bool HasAccess = false;

        //        try
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                HasAccess = DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleCode, User.ID);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasAccess = false;
        //        }

        //        DoesUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToApplication(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, AdvantageFramework.Core.Security.Classes.User User, AdvantageFramework.Core.Security.Application Application)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Entities.UserApplicationAccess UserApplicationAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.GroupApplicationAccess GroupApplicationAccess = null/* TODO Change to default(_) if this is not a reference type */;

        //        if (User != null)
        //        {
        //            Generic.List<AdvantageFramework.Core.Security.Database.Entities.GroupUser> GroupUsers;

        //            GroupUsers = null/* TODO Change to default(_) if this is not a reference type */;
        //            GroupUsers = AdvantageFramework.Core.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).ToList;

        //            foreach (var GroupModuleAccess in GroupUsers.SelectMany(GroupUser => GroupUser.Group.GroupApplicationAccesses).Where(GrpAppAccess => GrpAppAccess.ApplicationID == Application).ToList)
        //            {
        //                if (GroupModuleAccess != null && GroupModuleAccess.IsBlocked == false)
        //                {
        //                    HasAccess = true;
        //                    break;
        //                }
        //            }

        //            if (HasAccess == false && (User.CheckForUserAccess || GroupUsers.Count == 0))
        //            {
        //                try
        //                {
        //                    UserApplicationAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //                    UserApplicationAccess = AdvantageFramework.Core.Security.Database.Procedures.UserApplicationAccess.LoadByApplicationIDAndUserID(SecurityDbContext, Application, User.ID);
        //                }
        //                catch (Exception ex)
        //                {
        //                    UserApplicationAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //                }

        //                if (UserApplicationAccess != null && UserApplicationAccess.IsBlocked == false)
        //                    HasAccess = true;
        //            }
        //        }

        //        DoesUserHaveAccessToApplication = HasAccess;
        //    }
        //    public static bool DoesClientPortalUserHaveAccessToModule(AdvantageFramework.Core.Security.Session Session, string ModuleCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Entities.Module Module = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.ClientPortalUserModuleAccess ClientPortalUserModuleAccess = null/* TODO Change to default(_) if this is not a reference type */;

        //        if (Session != null)
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                Module = AdvantageFramework.Core.Security.Database.Procedures.Module.LoadByModuleCode(SecurityDbContext, ModuleCode);

        //                if (Module != null)
        //                {
        //                    if (Session.ClientPortalUser != null)
        //                    {
        //                        try
        //                        {
        //                            ClientPortalUserModuleAccess = AdvantageFramework.Core.Security.Database.Procedures.ClientPortalUserModuleAccess.LoadByModuleIDAndClientPortalUserID(SecurityDbContext, Module.ID, Session.ClientPortalUser.ID);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            ClientPortalUserModuleAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //                        }

        //                        if (ClientPortalUserModuleAccess != null && ClientPortalUserModuleAccess.IsBlocked == false)
        //                            HasAccess = true;
        //                    }
        //                }
        //            }
        //        }

        //        DoesClientPortalUserHaveAccessToModule = HasAccess;
        //    }
        //    public static bool DoesClientPortalUserHaveAccessToApplication(AdvantageFramework.Core.Security.Database.Entities.ClientPortalUser ClientPortalUser, AdvantageFramework.Core.Security.Application Application)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Database.Entities.ClientPortalUserApplicationAccess ClientPortalUserApplicationAccess = null/* TODO Change to default(_) if this is not a reference type */;

        //        if (ClientPortalUser != null)
        //        {
        //            try
        //            {
        //                ClientPortalUserApplicationAccess = ClientPortalUser.ClientPortalUserApplicationAccesses.SingleOrDefault(CPUAppAccess => CPUAppAccess.ApplicationID == Application);
        //            }
        //            catch (Exception ex)
        //            {
        //                ClientPortalUserApplicationAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //            }

        //            if (ClientPortalUserApplicationAccess != null && ClientPortalUserApplicationAccess.IsBlocked == false)
        //                HasAccess = true;
        //        }

        //        DoesClientPortalUserHaveAccessToApplication = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToUserDefinedReport(AdvantageFramework.Core.Security.Session Session, int UserDefinedReportID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Classes.User User = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.UserUserDefinedReportAccess UserUserDefinedReportAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.GroupUserDefinedReportAccess GroupUserDefinedReportAccess = null/* TODO Change to default(_) if this is not a reference type */;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //        {
        //            User = new AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, Session.User.ID));

        //            if (User != null)
        //            {
        //                foreach (var Group in AdvantageFramework.Core.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).Select(GroupUser => GroupUser.Group))
        //                {
        //                    try
        //                    {
        //                        GroupUserDefinedReportAccess = Group.GroupUserDefinedReportAccesses.SingleOrDefault(GroupUDRAccess => GroupUDRAccess.UserDefinedReportID == UserDefinedReportID);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        GroupUserDefinedReportAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }

        //                    if (GroupUserDefinedReportAccess != null && GroupUserDefinedReportAccess.IsBlocked == false)
        //                    {
        //                        HasAccess = true;
        //                        break;
        //                    }
        //                }

        //                if (HasAccess == false && (User.CheckForUserAccess || AdvantageFramework.Core.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).Count == 0))
        //                {
        //                    try
        //                    {
        //                        UserUserDefinedReportAccess = AdvantageFramework.Core.Security.Database.Procedures.UserUserDefinedReportAccess.LoadByUserDefinedReportIDAndUserID(SecurityDbContext, UserDefinedReportID, User.ID);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        UserUserDefinedReportAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }

        //                    if (UserUserDefinedReportAccess != null && UserUserDefinedReportAccess.IsBlocked == false)
        //                        HasAccess = true;
        //                }
        //            }
        //        }

        //        DoesUserHaveAccessToUserDefinedReport = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToUserDefinedEstimateReport(AdvantageFramework.Core.Security.Session Session, int EstimateReportID)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Classes.User User = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.UserUserDefinedReportAccess UserUserDefinedReportAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.GroupUserDefinedReportAccess GroupUserDefinedReportAccess = null/* TODO Change to default(_) if this is not a reference type */;

        //        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //        {
        //            User = new AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, Session.User.ID));

        //            if (User != null)
        //            {
        //                foreach (var Group in AdvantageFramework.Core.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).Select(GroupUser => GroupUser.Group))
        //                {
        //                    try
        //                    {
        //                        GroupUserDefinedReportAccess = Group.GroupUserDefinedReportAccesses.SingleOrDefault(GroupUDRAccess => GroupUDRAccess.UserDefinedReportID == EstimateReportID);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        GroupUserDefinedReportAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }

        //                    if (GroupUserDefinedReportAccess != null && GroupUserDefinedReportAccess.IsBlocked == false)
        //                    {
        //                        HasAccess = true;
        //                        break;
        //                    }
        //                }

        //                if (HasAccess == false && (User.CheckForUserAccess || AdvantageFramework.Core.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, User.ID).Count == 0))
        //                {
        //                    try
        //                    {
        //                        UserUserDefinedReportAccess = AdvantageFramework.Core.Security.Database.Procedures.UserUserDefinedReportAccess.LoadByUserDefinedReportIDAndUserID(SecurityDbContext, EstimateReportID, User.ID);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        UserUserDefinedReportAccess = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }

        //                    if (UserUserDefinedReportAccess != null && UserUserDefinedReportAccess.IsBlocked == false)
        //                        HasAccess = true;
        //                }
        //            }
        //        }

        //        DoesUserHaveAccessToUserDefinedEstimateReport = HasAccess;
        //    }
        //    public static bool DoesUserHaveAccessToReport(AdvantageFramework.Core.Security.Session Session, string ReportCode)
        //    {

        //        // objects
        //        bool HasAccess = false;
        //        AdvantageFramework.Core.Security.Classes.User User = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.ReportAccess ReportAccess = null/* TODO Change to default(_) if this is not a reference type */;

        //        if (Session.IsTimeEntryOnly == false)
        //        {
        //            using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //            {
        //                User = new AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, Session.User.ID));

        //                if (User != null)
        //                {
        //                    ReportAccess = AdvantageFramework.Core.Security.Database.Procedures.ReportAccess.LoadByUserCodeAndReportCode(SecurityDbContext, User.UserCode, ReportCode);

        //                    if (ReportAccess != null && ReportAccess.Enabled == null)
        //                        HasAccess = true;
        //                }
        //            }
        //        }

        //        DoesUserHaveAccessToReport = HasAccess;
        //    }
        //    public static string GetIPAddress()
        //    {

        //        // objects
        //        string IPAddress = string.Empty;
        //        System.Net.IPHostEntry IPHostEntry = null;

        //        try
        //        {
        //            IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName());

        //            foreach (var IPAddressEntry in IPHostEntry.AddressList)
        //            {
        //                if (IPAddressEntry.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        //                {
        //                    IPAddress = IPAddressEntry.ToString();
        //                    break;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            IPAddress = string.Empty;
        //        }

        //        GetIPAddress = IPAddress;
        //    }
        //    public static string GetMACAddress()
        //    {

        //        // objects
        //        string MACAddress = string.Empty;
        //        System.Management.ManagementClass ManagementClass = null/* TODO Change to default(_) if this is not a reference type */;
        //        System.Management.EnumerationOptions EnumerationOptions = null/* TODO Change to default(_) if this is not a reference type */;
        //        System.Management.ManagementObject ManagementObject = null/* TODO Change to default(_) if this is not a reference type */;
        //        System.Management.ManagementObjectCollection ManagementObjectCollection = null/* TODO Change to default(_) if this is not a reference type */;
        //        System.Net.NetworkInformation.NetworkInterface[] NetworkInterfaces = null;
        //        System.Net.NetworkInformation.PhysicalAddress PhysicalAddress = null;

        //        try
        //        {
        //            ManagementClass = new System.Management.ManagementClass("Win32_NetworkAdapterConfiguration");

        //            EnumerationOptions = new System.Management.EnumerationOptions();
        //            EnumerationOptions.ReturnImmediately = true;
        //            EnumerationOptions.Rewindable = false;

        //            ManagementObjectCollection = ManagementClass.GetInstances(EnumerationOptions);

        //            foreach (var ManagementObject in ManagementObjectCollection)
        //            {
        //                if (ManagementObject.Item("IPEnabled") == true)
        //                {
        //                    MACAddress = ManagementObject.Item("MacAddress");
        //                    break;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MACAddress = string.Empty;
        //        }

        //        if (string.IsNullOrWhiteSpace(MACAddress) == false)
        //            MACAddress = MACAddress.Replace(":", "");

        //        try
        //        {
        //            if (ManagementObject != null)
        //            {
        //                try
        //                {
        //                    ManagementObject.Dispose();
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }

        //            ManagementObject = null/* TODO Change to default(_) if this is not a reference type */;

        //            if (ManagementObjectCollection != null)
        //            {
        //                try
        //                {
        //                    ManagementObjectCollection.Dispose();
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }

        //            ManagementObjectCollection = null/* TODO Change to default(_) if this is not a reference type */;

        //            if (ManagementClass != null)
        //            {
        //                try
        //                {
        //                    ManagementClass.Dispose();
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }

        //            ManagementClass = null/* TODO Change to default(_) if this is not a reference type */;
        //        }
        //        catch (Exception ex)
        //        {
        //        }

        //        if (string.IsNullOrWhiteSpace(MACAddress))
        //        {
        //            try
        //            {
        //                NetworkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

        //                foreach (var NetworkInterface in NetworkInterfaces)
        //                {
        //                    if (NetworkInterface.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
        //                    {
        //                        try
        //                        {
        //                            PhysicalAddress = NetworkInterface.GetPhysicalAddress();
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            PhysicalAddress = null;
        //                        }

        //                        if (PhysicalAddress != null)
        //                        {
        //                            MACAddress = PhysicalAddress.ToString();
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MACAddress = string.Empty;
        //            }
        //        }

        //        try
        //        {
        //            NetworkInterfaces = null;
        //            PhysicalAddress = null;
        //        }
        //        catch (Exception ex)
        //        {
        //        }

        //        GetMACAddress = MACAddress;
        //    }
        //    public static bool Login(AdvantageFramework.Core.Security.Application Application, ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, string Password, string ClientPortalUserName, string ClientPortalPassword, string SessionID, string IPAddress, string SSConnectionString, string SSUserName, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool LoginSuccessful = false;
        //        string ConnectionString = "";
        //        AdvantageFramework.Core.Security.Database.Entities.Application ApplicationEntity = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.ClientPortalUser ClientPortalUser = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext = null/* TODO Change to default(_) if this is not a reference type */;
        //        string Version = "";
        //        string DatabaseVersion = "";
        //        string[] VersionKeys = null;
        //        int IsScriptInDB = 0;
        //        string MinimumVersion = "";
        //        string MaximumVersion = "";
        //        int AdvantageUserLicenseInUseID = 0;

        //        if (Application == Methods.Application.Webvantage)
        //            LoginSuccessful = Login(Application, ref DbContext, ref Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, SessionID, IPAddress, SSConnectionString, SSUserName, ref ErrorMessage);
        //        else if (Application == Methods.Application.Client_Portal)
        //        {
        //            if (AdvantageFramework.Database.ValidateServerAndDatabase(ServerName, DatabaseName, UseWindowsAuthentication, ClientPortalUserName, ClientPortalPassword, Application.ToString, true, ErrorMessage))
        //            {
        //                ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName, DatabaseName, UseWindowsAuthentication, ClientPortalUserName, ClientPortalPassword, Application.ToString);

        //                if (AdvantageFramework.Database.TestConnectionString(ConnectionString, ErrorMessage))
        //                {
        //                    try
        //                    {
        //                        SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(ConnectionString, ClientPortalUserName);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        ErrorMessage = ex.Message;
        //                        SecurityDbContext = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }

        //                    if (SecurityDbContext != null)
        //                    {
        //                        ApplicationEntity = AdvantageFramework.Core.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application);

        //                        ClientPortalUser = AdvantageFramework.Core.Security.Database.Procedures.ClientPortalUser.LoadByUserName(SecurityDbContext, UserName);

        //                        if (ApplicationEntity != null)
        //                        {
        //                            if (ClientPortalUser != null)
        //                            {
        //                                if (DoesClientPortalUserHaveAccessToApplication(ClientPortalUser, Methods.Application.Client_Portal))
        //                                {
        //                                    DbContext = new AdvantageFramework.Database.DbContext(ConnectionString, UserName);

        //                                    if (ClientPortalUser.ClientContact.IsInactive.GetValueOrDefault(0) == 0)
        //                                    {
        //                                        Version = System.Configuration.ConfigurationManager.AppSettings("VCtrl");
        //                                        DatabaseVersion = SecurityDbContext.Database.SqlQuery<string>("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault();

        //                                        if (Version == "##DEV##")
        //                                            LoginSuccessful = true;
        //                                        else if (Version != "##DEV##")
        //                                        {
        //                                            Version = DecryptVersionKey("VersionEncryptor2007", Version);

        //                                            VersionKeys = Version.Split("|");

        //                                            MinimumVersion = VersionKeys[2].ToString().Trim();
        //                                            MaximumVersion = VersionKeys[3].ToString().Trim();

        //                                            if (DatabaseVersion >= MinimumVersion || DatabaseVersion <= MaximumVersion)
        //                                                LoginSuccessful = true;
        //                                            else
        //                                                ErrorMessage = "The Advantage database version is not compatible with the Webvantage database version!";
        //                                        }

        //                                        if (LoginSuccessful)
        //                                        {
        //                                            if (ClientPortalUser.Password == AdvantageFramework.Core.Security.Encryption.GenerateSHA256ManagedHash(Password))
        //                                            {

        //                                                // If ClientPortalUser.IsLocked Then

        //                                                // If ClientPortalUser.UnlockedDate <= Now Then

        //                                                // ClientPortalUser.LoginsAttempted = 0
        //                                                // ClientPortalUser.LastLoginDate = Now
        //                                                // ClientPortalUser.IsLocked = False

        //                                                // LoginSuccessful = True

        //                                                // Else

        //                                                // ClientPortalUser.LoginsAttempted += 1
        //                                                // ClientPortalUser.UnlockedDate = Now.AddMinutes(10)

        //                                                // ErrorMessage = "For your security, your account has been locked out due to excessive incorrect password tries. In order to unlock your account please contact System Adminstrator to recover your password."

        //                                                // LoginSuccessful = False

        //                                                // End If

        //                                                // Else

        //                                                ClientPortalUser.LoginsAttempted = 0;
        //                                                ClientPortalUser.LastLoginDate = DateTime.Now;
        //                                                ClientPortalUser.IsLocked = false;

        //                                                LoginSuccessful = true;
        //                                            }
        //                                            else
        //                                            {

        //                                                // ClientPortalUser.LoginsAttempted += 1

        //                                                // If ClientPortalUser.LoginsAttempted > 3 Then

        //                                                // ClientPortalUser.IsLocked = True
        //                                                // ClientPortalUser.UnlockedDate = Now.AddMinutes(30)

        //                                                // ErrorMessage = "For your security, your account has been locked out due to excessive incorrect password tries. In order to unlock your account please contact System Adminstrator to recover your password."

        //                                                // Else

        //                                                ErrorMessage = "Invalid Client Portal username/password combination.";

        //                                                // End If

        //                                                LoginSuccessful = false;
        //                                            }

        //                                            AdvantageFramework.Core.Security.Database.Procedures.ClientPortalUser.Update(SecurityDbContext, ClientPortalUser);

        //                                            if (LoginSuccessful)
        //                                            {
        //                                                AdvantageFramework.Core.Security.Classes.ClientPortalUser ClientPortalUserClass;

        //                                                ClientPortalUserClass = null/* TODO Change to default(_) if this is not a reference type */;
        //                                                ClientPortalUserClass = new AdvantageFramework.Core.Security.Classes.ClientPortalUser(ClientPortalUser);

        //                                                if (AdvantageFramework.Core.Security.LicenseKey.Validate(DbContext, null/* TODO Change to default(_) if this is not a reference type */, ClientPortalUserClass, ApplicationEntity.ID, "", SessionID, ErrorMessage, AdvantageUserLicenseInUseID))
        //                                                {
        //                                                    LoginSuccessful = true;
        //                                                    Session = new AdvantageFramework.Core.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, ClientPortalUserName, ClientPortalPassword, UserName, AdvantageUserLicenseInUseID, SSConnectionString);
        //                                                }
        //                                                else
        //                                                    LoginSuccessful = false;
        //                                            }
        //                                        }
        //                                    }
        //                                    else
        //                                        ErrorMessage = "Client Portal User is marked as inactive - Access denied";
        //                                }
        //                                else
        //                                    ErrorMessage = "Access denied";
        //                            }
        //                            else
        //                                ErrorMessage = "Client Portal User does not exist - Access denied";
        //                        }
        //                        else
        //                            ErrorMessage = "Application not found - Access denied";

        //                        if (SecurityDbContext != null)
        //                        {
        //                            SecurityDbContext.Dispose();
        //                            SecurityDbContext = null/* TODO Change to default(_) if this is not a reference type */;
        //                        }
        //                    }
        //                    else
        //                        ErrorMessage = "Please verify that you are connecting to the correct server and database and that your login username and password is correct.";
        //                }
        //            }
        //        }

        //        return LoginSuccessful;
        //    }
        //    public static bool Login(AdvantageFramework.Core.Security.Application Application, ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, string Password, string MACAddressOrSessionID, string IPAddress, string ConnectionString, string ConnectionUserName, ref string ErrorMessage)
        //    {

        //        // objects
        //        AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Database.Entities.Application ApplicationEntity = null/* TODO Change to default(_) if this is not a reference type */;
        //        AdvantageFramework.Core.Security.Classes.User User = null/* TODO Change to default(_) if this is not a reference type */;
        //        bool LoginSuccessful = false;
        //        AdvantageFramework.Core.Security.Database.Views.DatabaseSQLUser DatabaseSQLUser = null/* TODO Change to default(_) if this is not a reference type */;
        //        string FullUserName = "";
        //        bool IsWrongPassword = false;
        //        bool VersionCheckSucessful = false;

        //        if (string.IsNullOrWhiteSpace(UserName) == true)
        //            ErrorMessage = "Please enter User ID.";
        //        else
        //        {
        //            if (string.IsNullOrWhiteSpace(ConnectionUserName) == true)
        //                ConnectionUserName = UserName;

        //            if ((Application == AdvantageFramework.Core.Security.Application.Advantage || Application == AdvantageFramework.Core.Security.Application.Advantage_Database_Update) && string.IsNullOrWhiteSpace(ServerName) == true && string.IsNullOrWhiteSpace(DatabaseName) == false)
        //            {
        //                try
        //                {
        //                    ServerName = AdvantageFramework.Database.LoadSimpleDatabaseProfileList.SingleOrDefault(SimpleDatabaseProfile => SimpleDatabaseProfile.DatabaseName == DatabaseName).ServerName;
        //                }
        //                catch (Exception ex)
        //                {
        //                    ServerName = "";
        //                }
        //            }

        //            if (Application == Application.Advantage_Nielsen_Database_Update || Application == Application.Advantage_Database_Update || Application == System.Security.Application.Advantage_Update)
        //                ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, Application.ToString);

        //            // validate connection string
        //            if (ValidateLoginConnectionString(Application, ConnectionString, ref ErrorMessage))
        //            {
        //                FullUserName = UserName;

        //                if (UseWindowsAuthentication)
        //                {
        //                    if (UserName.Contains(@"\"))
        //                        UserName = UserName.Substring(UserName.IndexOf(@"\") + 1);
        //                }

        //                try
        //                {
        //                    SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(ConnectionString, ConnectionUserName);
        //                }
        //                catch (Exception ex)
        //                {
        //                    ErrorMessage = ex.Message;
        //                    SecurityDbContext = null/* TODO Change to default(_) if this is not a reference type */;
        //                }

        //                if (SecurityDbContext != null)
        //                {
        //                    SecurityDbContext.Database.Connection.Open();

        //                    DbContext = new AdvantageFramework.Database.DbContext(ConnectionString, ConnectionUserName);

        //                    DbContext.Database.Connection.Open();

        //                    // '''Per Steve, OK to comment out.
        //                    // 'If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(1) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SEC_USER' AND COLUMN_NAME = 'IS_INACTIVE'").FirstOrDefault = 0 Then

        //                    // '    Try

        //                    // '        DbContext.Database.ExecuteSqlCommand("ALTER TABLE [dbo].[SEC_USER] ADD [IS_INACTIVE] [bit] NOT NULL DEFAULT(0)")

        //                    // '    Catch ex As Exception
        //                    // '    End Try

        //                    // 'End If

        //                    if (Application == AdvantageFramework.Core.Security.Application.Advantage)
        //                        VersionCheckSucessful = VersionCheckAdvantage(DbContext, ref ErrorMessage);
        //                    else if (Application == AdvantageFramework.Core.Security.Application.Webvantage)
        //                        VersionCheckSucessful = VersionCheckWebvantage(DbContext, ref ErrorMessage);
        //                    else
        //                        VersionCheckSucessful = true;

        //                    if (VersionCheckSucessful)
        //                    {
        //                        if (Application == Application.Advantage_Nielsen_Database_Update || Application == Application.Advantage_Database_Update || Application == Application.Advantage_Update)
        //                        {
        //                        }
        //                        else
        //                        {
        //                            try
        //                            {
        //                                User = new AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName));
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                User = null/* TODO Change to default(_) if this is not a reference type */;
        //                            }

        //                            try
        //                            {
        //                                ApplicationEntity = AdvantageFramework.Core.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application);
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                ApplicationEntity = null/* TODO Change to default(_) if this is not a reference type */;
        //                            }
        //                        }

        //                        if (ValidateUser(Application, DbContext, SecurityDbContext, User, ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, ref IsWrongPassword, ref ErrorMessage) == true)
        //                        {
        //                            if (Application == AdvantageFramework.Core.Security.Application.Advantage_Nielsen_Database_Update)
        //                                LoginSuccessful = LoginToNielsenDatabaseUpdate(ref DbContext, ref SecurityDbContext, ref Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, FullUserName, ref ErrorMessage);
        //                            else if (Application == AdvantageFramework.Core.Security.Application.Advantage_Database_Update)
        //                                LoginSuccessful = LoginToDatabaseUpdate(ref DbContext, ref SecurityDbContext, ref Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, FullUserName, ref ErrorMessage);
        //                            else if (Application == AdvantageFramework.Core.Security.Application.Advantage_Update)
        //                                LoginSuccessful = LoginToAdvantageUpdate(ref DbContext, ref Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, ref ErrorMessage);
        //                            else

        //                                                                 // ApplicationEntity = AdvantageFramework.Core.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application)

        //                                                                 // User = New AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

        //                                                                 if (DoesUserHaveAccessToApplication(SecurityDbContext, User, Application))
        //                            {
        //                                if (Application == AdvantageFramework.Core.Security.Application.Advantage)
        //                                {
        //                                    if (AdvantageFramework.Core.Security.Database.Procedures.PasswordLockout.IsUserLockedOut(SecurityDbContext, User.UserCode, ErrorMessage) == false)
        //                                        LoginSuccessful = LoginToAdvantage(ApplicationEntity, ref DbContext, ref Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, User, MACAddressOrSessionID, ref ErrorMessage);
        //                                    else
        //                                    {
        //                                        LoginSuccessful = false;
        //                                        ErrorMessage = LoadLockoutMessage(ref SecurityDbContext, User.UserCode);
        //                                    }
        //                                }
        //                                else if (Application == AdvantageFramework.Core.Security.Application.Webvantage)
        //                                {
        //                                    if (AdvantageFramework.Core.Security.Database.Procedures.PasswordLockout.IsUserLockedOut(SecurityDbContext, User.UserCode, ErrorMessage) == false)
        //                                        LoginSuccessful = LoginToWebvantage(ApplicationEntity, ref DbContext, ref Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, User, MACAddressOrSessionID, ref ErrorMessage);
        //                                    else
        //                                    {
        //                                        LoginSuccessful = false;
        //                                        ErrorMessage = LoadLockoutMessage(ref SecurityDbContext, User.UserCode);
        //                                    }
        //                                }
        //                                else if (Application == AdvantageFramework.Core.Security.Application.Outlook_Addin)
        //                                {
        //                                    LoginSuccessful = true;

        //                                    Session = new AdvantageFramework.Core.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper(), 0, ConnectionString);
        //                                }
        //                            }
        //                            else
        //                                ErrorMessage = "Access denied";
        //                        }

        //                        if (User != null)
        //                        {
        //                            if (LoginSuccessful == true)
        //                                AdvantageFramework.Core.Security.Database.Procedures.PasswordLockout.ClearByUserCode(SecurityDbContext, User.UserCode);
        //                            else if (IsWrongPassword == true)
        //                            {
        //                                AdvantageFramework.Core.Security.Database.Procedures.PasswordLockout.LogFailureByUserCode(SecurityDbContext, User.UserCode);

        //                                ErrorMessage = LoadLockoutMessage(ref SecurityDbContext, User.UserCode);

        //                                if (string.IsNullOrWhiteSpace(ErrorMessage) == true)
        //                                    ErrorMessage = AdvantageFramework.Core.Security.Password.IncorrectPasswordMessage;
        //                            }
        //                        }
        //                    }

        //                    CreateUserLoginAuditRecord(SecurityDbContext, Session, UserName, IPAddress, Application, LoginSuccessful, ErrorMessage);
        //                }
        //                else
        //                    ErrorMessage = "Please verify that you are connecting to the correct server and database and that your login username and password is correct.";

        //                try
        //                {
        //                    if (DbContext != null)
        //                    {
        //                        DbContext.Dispose();
        //                        DbContext = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                }

        //                try
        //                {
        //                    if (SecurityDbContext != null)
        //                    {
        //                        SecurityDbContext.Dispose();
        //                        SecurityDbContext = null/* TODO Change to default(_) if this is not a reference type */;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //            else if (string.IsNullOrWhiteSpace(ErrorMessage) == true)
        //                ErrorMessage = "Cannot connect to the Advantage servers. Please contact software support.";
        //            else
        //                ErrorMessage = "Cannot connect to the Advantage servers. Please contact software support.  " + ErrorMessage;
        //        }

        //        ErrorMessage = AdvantageFramework.StringUtilities.CheckForEndingPunctuation(ErrorMessage);

        //        return LoginSuccessful;
        //    }
        //    private static void CreateUserLoginAuditRecord(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, AdvantageFramework.Core.Security.Session Session, string UserCode, string IPAddress, AdvantageFramework.Core.Security.Application Application, bool LoginSuccessful, string ErrorMessage)
        //    {
        //        AdvantageFramework.Core.Security.Database.Entities.UserLoginAudit UserLoginAudit = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            UserLoginAudit = new AdvantageFramework.Core.Security.Database.Entities.UserLoginAudit();

        //            UserLoginAudit.UserCode = UserCode;
        //            UserLoginAudit.IPAddress = IPAddress;
        //            UserLoginAudit.ApplicationID = Application;
        //            UserLoginAudit.LoginDateTime = DateTime.Now;
        //            UserLoginAudit.LogoutDateTime = DateTime.MinValue;

        //            if (LoginSuccessful)
        //            {
        //                UserLoginAudit.Successful = true;
        //                UserLoginAudit.FailureReason = "";
        //            }
        //            else
        //            {
        //                UserLoginAudit.Successful = false;
        //                UserLoginAudit.FailureReason = ErrorMessage;
        //            }

        //            SecurityDbContext.UserLoginAudits.Add(UserLoginAudit);

        //            SecurityDbContext.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //        }

        //        if (LoginSuccessful && UserLoginAudit.ID > 0 && Session != null)
        //            Session.UserLoginAuditID = UserLoginAudit.ID;
        //    }
        //    public static void SetUserLogoutAuditRecord(AdvantageFramework.Core.Security.Session Session)
        //    {
        //        AdvantageFramework.Core.Security.Database.Entities.UserLoginAudit UserLoginAudit = null/* TODO Change to default(_) if this is not a reference type */;

        //        if (Session != null && Session.UserLoginAuditID > 0)
        //        {
        //            try
        //            {
        //                using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //                {
        //                    UserLoginAudit = SecurityDbContext.UserLoginAudits.Find(Session.UserLoginAuditID);

        //                    if (UserLoginAudit != null)
        //                        UserLoginAudit.LogoutDateTime = DateTime.Now;

        //                    SecurityDbContext.SaveChanges();
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }
        //    }
        //    private static bool LoginToAdvantageUpdate(ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, string Password, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool LoginSuccessful = false;

        //        if (DbContext.Database.SqlQuery<int>("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault != 0)
        //        {
        //            if (DbContext.Database.SqlQuery<int>("SELECT COUNT(*) FROM dbo.ADVAN_UPDATE WHERE VERSION_ID IS NULL").FirstOrDefault == 0)
        //            {
        //                LoginSuccessful = true;

        //                Session = new AdvantageFramework.Core.Security.Session(Application.Advantage_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper(), 0, DbContext.ConnectionString);
        //            }
        //            else
        //                ErrorMessage = "The previous update failed and the database has not been restored. Please restore the database.";
        //        }
        //        else
        //            ErrorMessage = "You must be an server admin to have access to this application.";

        //        LoginToAdvantageUpdate = LoginSuccessful;
        //    }
        //    private static bool LoginToNielsenDatabaseUpdate(ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, ref AdvantageFramework.Core.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, string Password, string FullUserName, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool LoginSuccessful = false;
        //        AdvantageFramework.Core.Security.Database.Views.DatabaseSQLUser DatabaseSQLUser = null/* TODO Change to default(_) if this is not a reference type */;

        //        // User = New AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

        //        if (DbContext.Database.SqlQuery<int>("SELECT ISNULL(IS_SRVROLEMEMBER('serveradmin'), 0)").FirstOrDefault == 1)
        //        {
        //            if (DbContext.Database.SqlQuery<int>("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ADVAN_UPDATE' ").FirstOrDefault == 0)
        //            {
        //                LoginSuccessful = true;

        //                Session = new AdvantageFramework.Core.Security.Session(Application.Advantage_Nielsen_Database_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper(), 0, SecurityDbContext.ConnectionString);
        //            }
        //            else if (DbContext.Database.SqlQuery<int>("SELECT COUNT(*) FROM dbo.ADVAN_UPDATE WHERE VERSION_ID = ''").FirstOrDefault == 0)
        //            {
        //                LoginSuccessful = true;

        //                Session = new AdvantageFramework.Core.Security.Session(Application.Advantage_Nielsen_Database_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper(), 0, SecurityDbContext.ConnectionString);
        //            }
        //            else
        //                ErrorMessage = "The previous update failed and the database has not been restored. Please restore the database.";
        //        }
        //        else
        //            ErrorMessage = "You must be an server admin to have access to this application.";

        //        LoginToNielsenDatabaseUpdate = LoginSuccessful;
        //    }
        //    private static bool LoginToDatabaseUpdate(ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, ref AdvantageFramework.Core.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, string Password, string FullUserName, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool LoginSuccessful = false;
        //        // Dim DatabaseSQLUser As AdvantageFramework.Core.Security.Database.Views.DatabaseSQLUser = Nothing

        //        // If AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.IsDBDataReader(SecurityDbContext) = False Then

        //        // ErrorMessage = "User trying to login is not apart of the database role db_datareader"

        //        // ElseIf AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.IsDBDataReader(SecurityDbContext) = False Then

        //        // ErrorMessage = "User trying to login is not apart of the database role db_datawriter"

        //        // Else

        //        // DatabaseSQLUser = AdvantageFramework.Core.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, FullUserName)

        //        // ApplicationEntity = AdvantageFramework.Core.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application.Advantage_Database_Update)

        //        // User = New AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

        //        if (AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext))
        //        {
        //            if (DbContext.Database.SqlQuery<int>("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault != 0)
        //            {
        //                if (DbContext.Database.SqlQuery<int>("SELECT COUNT(*) FROM dbo.ADVAN_UPDATE WHERE VERSION_ID IS NULL").FirstOrDefault == 0)
        //                {
        //                    LoginSuccessful = true;

        //                    Session = new AdvantageFramework.Core.Security.Session(Application.Advantage_Database_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper(), 0, SecurityDbContext.ConnectionString);
        //                }
        //            }
        //        }
        //        else

        //            // If DoesUserHaveAccessToApplication(SecurityDbContext, User, Application.Advantage_Database_Update) Then

        //            if (DbContext.Database.SqlQuery<int>("SELECT ISNULL(IS_ROLEMEMBER('advan_admin'), 0)").FirstOrDefault == 1 || DbContext.Database.SqlQuery<int>("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault == 1)
        //        {
        //            if (DbContext.Database.SqlQuery<int>("SELECT COUNT(*) FROM dbo.ADVAN_UPDATE WHERE VERSION_ID IS NULL").FirstOrDefault == 0)
        //            {
        //                LoginSuccessful = true;

        //                Session = new AdvantageFramework.Core.Security.Session(Application.Advantage_Database_Update, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper(), 0, SecurityDbContext.ConnectionString);
        //            }
        //            else
        //                ErrorMessage = "The previous update failed and the database has not been restored. Please restore the database.";
        //        }
        //        else
        //            ErrorMessage = "You must be an sys admin or advan admin to have access to this application.";

        //        LoginToDatabaseUpdate = LoginSuccessful;
        //    }
        //    private static bool LoginToWebvantage(AdvantageFramework.Core.Security.Database.Entities.Application ApplicationEntity, ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, string Password, AdvantageFramework.Core.Security.Classes.User User, string SessionID, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool LoginSuccessful = false;
        //        string Version = "";
        //        string DatabaseVersion = "";
        //        string[] VersionKeys = null;
        //        string WebConfigVersion = "";
        //        string MinimumVersion = "";
        //        string MaximumVersion = "";
        //        AdvantageFramework.Database.Entities.Setting Setting = null/* TODO Change to default(_) if this is not a reference type */;
        //        int AdvantageUserLicenseInUseID = 0;

        //        // Version = System.Configuration.ConfigurationManager.AppSettings("VCtrl")
        //        // DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

        //        // 'test
        //        // If Version Is Nothing Then Version = "##DEV##"

        //        // If Version = "##DEV##" Then

        //        // LoginSuccessful = True

        //        // ElseIf Version <> "##DEV##" Then

        //        // Version = DecryptVersionKey("VersionEncryptor2007", Version)

        //        // VersionKeys = Version.Split("|")
        //        // WebConfigVersion = VersionKeys(1).ToString().Trim()
        //        // MinimumVersion = VersionKeys(2).ToString().Trim()
        //        // MaximumVersion = VersionKeys(3).ToString().Trim()

        //        // If DatabaseVersion >= MinimumVersion OrElse DatabaseVersion <= MaximumVersion Then

        //        // LoginSuccessful = True

        //        // End If

        //        // End If

        //        // If LoginSuccessful Then

        //        // Try

        //        // 'test
        //        // If WebConfigVersion Is Nothing Or WebConfigVersion = "" Then WebConfigVersion = "##DEV##"

        //        // If WebConfigVersion = "##DEV##" Then

        //        // LoginSuccessful = True

        //        // Else

        //        // If DbContext.Database.SqlQuery(Of String)("SELECT WEBVAN_VERSION_ID FROM ADVAN_UPDATE").FirstOrDefault = WebConfigVersion Then

        //        // LoginSuccessful = True

        //        // Else

        //        // LoginSuccessful = False

        //        // End If

        //        // End If

        //        // Catch ex As Exception
        //        // LoginSuccessful = False
        //        // End Try

        //        // If LoginSuccessful Then

        //        if (AdvantageFramework.Core.Security.LicenseKey.Validate(DbContext, User, null/* TODO Change to default(_) if this is not a reference type */, ApplicationEntity.ID, "", SessionID, ErrorMessage, AdvantageUserLicenseInUseID))
        //        {
        //            using (var DataContext = new AdvantageFramework.Database.DataContext(DbContext.Database.Connection.ConnectionString, DbContext.UserCode))
        //            {
        //                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString);

        //                if (Setting != null)
        //                {
        //                    if (Setting.Value == 1)
        //                    {
        //                        using (var SecurityDbContext = new AdvantageFramework.Core.Security.Database.DbContext(DbContext.Database.Connection.ConnectionString, DbContext.UserCode))
        //                        {
        //                            LoginSuccessful = SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.SEC_USER SET WEB_ID = '" + SessionID + "' WHERE SEC_USER_ID = " + User.ID) > 0;
        //                        }
        //                    }
        //                    else
        //                        LoginSuccessful = true;
        //                }
        //                else
        //                    LoginSuccessful = true;
        //            }

        //            if (LoginSuccessful)
        //                Session = new AdvantageFramework.Core.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, User.UserCode, AdvantageUserLicenseInUseID, DbContext.ConnectionString);
        //        }
        //        else
        //            LoginSuccessful = false;

        //        // Else

        //        // ErrorMessage = "The Webvantage software version is not compatible with the Webvantage database version!"

        //        // End If

        //        // Else

        //        // ErrorMessage = "The Advantage database version is not compatible with the Webvantage database version!"

        //        // End If

        //        LoginToWebvantage = LoginSuccessful;
        //    }
        //    public static void LoadDirectoryScripts(AdvantageFramework.Core.Security.Session Session, ref Generic.List<System.IO.FileInfo> UnappliedDatabaseChangesList, System.IO.DirectoryInfo DirectoryInfo, AdvantageFramework.Database.DbContext DbContext, string Version)
        //    {

        //        // objects
        //        string Hash = "";

        //        foreach (var SubDirectoryInfo in DirectoryInfo.GetDirectories().OrderBy(Entity => Entity.Name).ToList())

        //            LoadDirectoryScripts(Session, ref UnappliedDatabaseChangesList, SubDirectoryInfo, DbContext, Version);

        //        foreach (var FileInfo in DirectoryInfo.GetFiles().Where(FileIn => FileIn.Name == "MenuUpdate.xml" || FileIn.Extension.ToUpper() == ".SQL" || FileIn.Extension.ToUpper() == ".ADVENC").OrderBy(FileIn => FileIn.Name).ToList())
        //        {
        //            Hash = "";

        //            using (var FileStream = FileInfo.OpenRead())
        //            {
        //                using (System.Security.Cryptography.MD5CryptoServiceProvider MD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider())
        //                {
        //                    Hash = AdvantageFramework.StringUtilities.ByteArrayToString(MD5CryptoServiceProvider.ComputeHash(FileStream));
        //                }
        //            }

        //            if (DbContext.Database.SqlQuery<int>(string.Format("SELECT COUNT(*) FROM dbo.DB_UPDATE WHERE PATCH = '{0}' AND FILE_HASH = '{1}' AND VERSION_ID = '{2}'", FileInfo.Name, Hash, Version)).FirstOrDefault == 0)
        //            {
        //                if (FileInfo.Name.ToUpper() == "NIELSENSCRIPT.SQL" && Session.IsNielsenSetup && AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) == false)
        //                    UnappliedDatabaseChangesList.Add(FileInfo);
        //                else if (FileInfo.Name.ToUpper() != "NIELSENSCRIPT.SQL")
        //                    UnappliedDatabaseChangesList.Add(FileInfo);
        //            }
        //        }
        //    }
        //    private static bool LoginToAdvantage(AdvantageFramework.Core.Security.Database.Entities.Application ApplicationEntity, ref AdvantageFramework.Database.DbContext DbContext, ref AdvantageFramework.Core.Security.Session Session, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, string Password, AdvantageFramework.Core.Security.Classes.User User, string MACAddress, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool LoginSuccessful = false;
        //        string Version = "";
        //        // Dim ReleaseVersion As String = ""
        //        string DatabaseVersion = "";
        //        string DatabaseChangeVersion = "";
        //        string DatabaseChangeFunction = "";
        //        // Dim UnappliedDatabaseChangesList As Generic.List(Of System.IO.FileInfo) = Nothing
        //        int AdvantageUserLicenseInUseID = 0;

        //        // Version = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00")
        //        // DatabaseVersion = DbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

        //        // 'If Debugger.IsAttached = False Then

        //        // If DatabaseVersion = Version Then

        //        if (AdvantageFramework.Core.Security.LicenseKey.Validate(DbContext, User, null/* TODO Change to default(_) if this is not a reference type */, ApplicationEntity.ID, MACAddress, "", ErrorMessage, AdvantageUserLicenseInUseID))
        //        {

        //            // ReleaseVersion = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00")

        //            // If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Scripts") Then

        //            // UnappliedDatabaseChangesList = New Generic.List(Of System.IO.FileInfo)

        //            // For Each DirectoryInfo In My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath & "\Scripts").GetDirectories.ToList

        //            // If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectoryInfo.Name) >= AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ReleaseVersion) Then

        //            // LoadDirectoryScripts(UnappliedDatabaseChangesList, DirectoryInfo, DbContext, DirectoryInfo.Name)

        //            // End If

        //            // Next

        //            // If UnappliedDatabaseChangesList.Count > 0 Then

        //            // ErrorMessage = "There are updates missing from your database.  " & vbCrLf & _
        //            // "This may cause errors when using certain features of the system before rectifying the situation.  " & vbCrLf & _
        //            // "Please notify your system adminstrator that the following items are missing and need to be applied: " & vbCrLf & vbCrLf & _
        //            // Join(UnappliedDatabaseChangesList.Select(Function(FileInfo) FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "_" & FileInfo.LastWriteTime.ToString("yyyyMMddHHmmss")).ToArray, vbCrLf)

        //            // End If

        //            // End If

        //            LoginSuccessful = true;
        //            Session = new AdvantageFramework.Core.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper(), AdvantageUserLicenseInUseID, DbContext.ConnectionString);
        //        }

        //        // Else

        //        // ErrorMessage = "The database version is not the same as the application version"
        //        // DbContext = Nothing

        //        // End If

        //        // Else

        //        // LoginSuccessful = True
        //        // Session = New AdvantageFramework.Core.Security.Session(ApplicationEntity, ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, UserName.ToUpper, AdvantageUserLicenseInUseID)

        //        // End If

        //        LoginToAdvantage = LoginSuccessful;
        //    }
        //    private static bool VersionCheckAdvantage(AdvantageFramework.Database.DbContext DbContext, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool VersionCheckSuccessful = false;
        //        string Version = "";
        //        string DatabaseVersion = "";

        //        Version = "v" + My.Application.Info.Version.Major + "." + My.Application.Info.Version.Minor + "." + Format(My.Application.Info.Version.Build, "00") + "." + Format(My.Application.Info.Version.Revision, "00");
        //        DatabaseVersion = DbContext.Database.SqlQuery<string>("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault();

        //        if (DatabaseVersion == Version)
        //            VersionCheckSuccessful = true;
        //        else
        //        {
        //            ErrorMessage = "The database version is not the same as the application version";
        //            VersionCheckSuccessful = false;
        //        }

        //        VersionCheckAdvantage = VersionCheckSuccessful;
        //    }
        //    private static bool VersionCheckWebvantage(AdvantageFramework.Database.DbContext DbContext, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool VersionCheckSuccessful = false;
        //        string Version = "";
        //        string DatabaseVersion = "";
        //        string[] VersionKeys = null;
        //        string WebConfigVersion = "";
        //        string MinimumVersion = "";
        //        string MaximumVersion = "";

        //        Version = System.Configuration.ConfigurationManager.AppSettings("VCtrl");
        //        DatabaseVersion = DbContext.Database.SqlQuery<string>("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault();

        //        // test
        //        if (Version == null)
        //            Version = "##DEV##";

        //        if (Version == "##DEV##")
        //            VersionCheckSuccessful = true;
        //        else if (Version != "##DEV##")
        //        {
        //            Version = DecryptVersionKey("VersionEncryptor2007", Version);

        //            VersionKeys = Version.Split("|");
        //            WebConfigVersion = VersionKeys[1].ToString().Trim();
        //            MinimumVersion = VersionKeys[2].ToString().Trim();
        //            MaximumVersion = VersionKeys[3].ToString().Trim();

        //            if (DatabaseVersion >= MinimumVersion || DatabaseVersion <= MaximumVersion)
        //                VersionCheckSuccessful = true;
        //        }

        //        if (VersionCheckSuccessful)
        //        {
        //            VersionCheckSuccessful = false;

        //            try
        //            {

        //                // test
        //                if (WebConfigVersion == null | WebConfigVersion == "")
        //                    WebConfigVersion = "##DEV##";

        //                if (WebConfigVersion == "##DEV##")
        //                    VersionCheckSuccessful = true;
        //                else if (DbContext.Database.SqlQuery<string>("SELECT WEBVAN_VERSION_ID FROM ADVAN_UPDATE").FirstOrDefault == WebConfigVersion)
        //                    VersionCheckSuccessful = true;
        //                else
        //                    VersionCheckSuccessful = false;
        //            }
        //            catch (Exception ex)
        //            {
        //                VersionCheckSuccessful = false;
        //            }

        //            if (VersionCheckSuccessful == false)
        //                ErrorMessage = "The Advantage database version is not compatible with the Webvantage database version!";
        //        }
        //        else
        //        {
        //            ErrorMessage = "The Advantage database version is not compatible with the Webvantage database version!";
        //            VersionCheckSuccessful = false;
        //        }

        //        VersionCheckWebvantage = VersionCheckSuccessful;
        //    }
        public static string DecryptVersionKey(string KeyString, string Data)
        {

            // objects
            string VersionKey = "";
            byte[] KeyBytes = null;
            byte[] VectorBytes = null;
            byte[] DataBytes = null;
            System.Security.Cryptography.DESCryptoServiceProvider DESCryptoServiceProvider = null;
            System.IO.MemoryStream MemoryStream = null;
            System.Security.Cryptography.CryptoStream CryptoStream = null;
            System.Text.Encoding Encoding = null;

            if (KeyString != "")
            {
                switch (KeyString.Length)
                {
                    case object _ when KeyString.Length < 16:
                        {
                            KeyString = KeyString + "longdivisionisexciting".Substring(0, 16 - KeyString.Length);
                            break;
                        }

                    case object _ when KeyString.Length > 16:
                        {
                            KeyString = KeyString.Substring(0, 16);
                            break;
                        }
                }

                KeyBytes = System.Text.Encoding.UTF8.GetBytes(KeyString.Substring(0, 8));
                VectorBytes = System.Text.Encoding.UTF8.GetBytes(KeyString.Substring(8, 8));

                DataBytes = new byte[Data.Length + 1];

                try
                {
                    DataBytes = Convert.FromBase64String(Data);
                }
                catch (Exception ex)
                {
                    VersionKey = Data;
                }

                if (VersionKey == "")
                {
                    try
                    {
                        DESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
                        MemoryStream = new System.IO.MemoryStream();
                        CryptoStream = new System.Security.Cryptography.CryptoStream(MemoryStream, DESCryptoServiceProvider.CreateDecryptor(KeyBytes, VectorBytes), System.Security.Cryptography.CryptoStreamMode.Write);
                        CryptoStream.Write(DataBytes, 0, DataBytes.Length);
                        CryptoStream.FlushFinalBlock();

                        Encoding = System.Text.Encoding.UTF8;

                        VersionKey = Encoding.GetString(MemoryStream.ToArray());
                    }
                    catch (Exception ex)
                    {
                        VersionKey = "";
                    }
                }
            }
            else
                VersionKey = Data;

            return VersionKey;
        }

        //    public static string GetToolTip(string ModuleCode, string FieldName)
        //    {
        //        string ToolTip = null;

        //        switch (ModuleCode)
        //        {
        //            case object _ when AdvantageFramework.Core.Security.Modules.Employee_ExpenseReports.ToString:
        //                {
        //                    if (FieldName == AdvantageFramework.Core.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
        //                        ToolTip = "Check Custom1 to enable Expense Report import.";
        //                    else if (FieldName == AdvantageFramework.Core.Security.Database.Classes.UserModuleAccess.Properties.Custom2.ToString)
        //                        ToolTip = "Check Custom2 to prevent user from editing amounts on imported Expense Report line items uploaded by another user.";
        //                    break;
        //                }

        //            case object _ when AdvantageFramework.Core.Security.Modules.Maintenance_Accounting_Employee.ToString:
        //                {
        //                    if (FieldName == AdvantageFramework.Core.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
        //                        ToolTip = "Check Custom1 to prevent access to the H/R Information tab and Cost and Department Update option within Employee Maintenance.";
        //                    break;
        //                }

        //            case object _ when AdvantageFramework.Core.Security.Modules.Maintenance_Accounting_Vendor.ToString:
        //                {
        //                    if (FieldName == AdvantageFramework.Core.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
        //                        ToolTip = "Check Custom1 to prevent access to the following tabs in Vendor Maintenance (Main, Default/Notes, EEOC, 1099 Info, Documents) and Limit AP to Media Vendors.";
        //                    break;
        //                }

        //            case object _ when AdvantageFramework.Core.Security.Modules.Media_MediaManager.ToString:
        //                {
        //                    if (FieldName == AdvantageFramework.Core.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
        //                        ToolTip = "Check Custom1 to grant full rights to view and edit any media order in Media Manager regardless of it's locked status.";
        //                    break;
        //                }

        //            case object _ when AdvantageFramework.Core.Security.Modules.ProjectManagement_ProjectSchedule.ToString:
        //                {
        //                    if (FieldName == AdvantageFramework.Core.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
        //                        ToolTip = "Check Custom1 to lock project schedules marked as templates.";
        //                    break;
        //                }

        //            case object _ when AdvantageFramework.Core.Security.Modules.ProjectManagement_Boards.ToString:
        //                {
        //                    if (FieldName == AdvantageFramework.Core.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
        //                        ToolTip = "Check Custom1 to keep users out of the sprint until it is active.";
        //                    break;
        //                }
        //        }

        //        GetToolTip = ToolTip;
        //    }
        //    public static bool ValidateLoginConnectionString(AdvantageFramework.Core.Security.Application Application, string ConnectionString, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool IsValid = false;
        //        System.Data.SqlClient.SqlConnectionStringBuilder SqlConnectionStringBuilder = null;

        //        try
        //        {
        //            SqlConnectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString);
        //        }
        //        catch (Exception ex)
        //        {
        //            SqlConnectionStringBuilder = null;
        //        }

        //        if (SqlConnectionStringBuilder != null)
        //        {
        //            if (AdvantageFramework.Database.ValidateServerAndDatabase(SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.InitialCatalog, false, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password, Application.ToString, true, ErrorMessage))
        //            {
        //                if (AdvantageFramework.Database.TestConnectionString(ConnectionString, ErrorMessage))
        //                    IsValid = true;
        //            }
        //        }

        //        ValidateLoginConnectionString = IsValid;
        //    }
        //    public static bool ValidateUser(AdvantageFramework.Core.Security.Application Application, AdvantageFramework.Database.DbContext DbContext, AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, AdvantageFramework.Core.Security.Classes.User User, AdvantageFramework.Core.Security.Database.Entities.Application ApplicationEntity, string ServerName, string DatabaseName, bool UseWindowsAuthentication, string UserName, string Password, ref bool IsWrongPassword, ref string ErrorMessage)
        //    {

        //        // objects
        //        bool IsValid = false;
        //        AdvantageFramework.Controller.Account.PasswordController PasswordController = null/* TODO Change to default(_) if this is not a reference type */;
        //        string PasswordMessage = string.Empty;
        //        string DatabaseVersion = string.Empty;
        //        bool HasPassword = false;

        //        if (Application == Application.Advantage_Nielsen_Database_Update || Application == Application.Advantage_Database_Update || Application == Application.Advantage_Update)
        //            IsValid = true;
        //        else

        //            // ApplicationEntity = AdvantageFramework.Core.Security.Database.Procedures.Application.LoadByApplicationID(SecurityDbContext, Application)

        //            // User = New AdvantageFramework.Core.Security.Classes.User(AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserName))

        //            if (ApplicationEntity != null)
        //        {
        //            if (User != null && User.ID > 0)
        //            {
        //                if (UserHasGroupMembership(SecurityDbContext, User.ID, User.CheckForUserAccess) == false)
        //                    ErrorMessage = AdvantageFramework.Core.Security.Password.NoGroupMembershipMessage;
        //                else if (User.IsInactive == false)
        //                {
        //                    if (UseWindowsAuthentication == true)
        //                    {
        //                        try
        //                        {
        //                            if (User.SID == System.Security.Principal.WindowsIdentity.GetCurrent().User.Value)
        //                                IsValid = true;
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                        }
        //                    }
        //                    else if (string.IsNullOrWhiteSpace(User.Password) == true)
        //                    {
        //                        if (AdvantageFramework.Core.Security.Password.SendPasswordChangeEmail(DbContext, SecurityDbContext, ServerName, DatabaseName, UserName, HasPassword, ErrorMessage) == true)
        //                        {
        //                            if (Application.ToString == AdvantageFramework.Core.Security.Application.Advantage.ToString || Application.ToString == AdvantageFramework.Core.Security.Application.Advantage_Database_Update.ToString)
        //                                AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.Core.Security.Password.NewPasswordMessage + "Check your email for further instructions.");
        //                            else
        //                                AdvantageFramework.Navigation.ShowMessage(AdvantageFramework.Core.Security.Password.NewPasswordMessage + "Check your email for further instructions.");
        //                        }
        //                        else if (string.IsNullOrWhiteSpace(ErrorMessage) == false)
        //                        {
        //                            if (Application.ToString == AdvantageFramework.Core.Security.Application.Advantage.ToString || Application.ToString == AdvantageFramework.Core.Security.Application.Advantage_Database_Update.ToString)
        //                                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage);
        //                            else
        //                                AdvantageFramework.Navigation.ShowMessage(ErrorMessage);
        //                        }
        //                        else if (Application.ToString == AdvantageFramework.Core.Security.Application.Advantage.ToString || Application.ToString == AdvantageFramework.Core.Security.Application.Advantage_Database_Update.ToString)
        //                            AdvantageFramework.Navigation.ShowMessageBox("Something went wrong!");
        //                        else
        //                            AdvantageFramework.Navigation.ShowMessage("Something went wrong!");
        //                    }
        //                    else if (User.Password == AdvantageFramework.Core.Security.Encryption.EncryptPassword(Password))
        //                    {
        //                        PasswordController = new AdvantageFramework.Controller.Account.PasswordController();

        //                        if (PasswordController.IsPasswordExpired(SecurityDbContext, UserName, PasswordMessage) == true)
        //                        {
        //                            IsValid = false;

        //                            if (string.IsNullOrWhiteSpace(PasswordMessage))
        //                                PasswordMessage = "Password has expired.";

        //                            if (Application.ToString == AdvantageFramework.Core.Security.Application.Advantage.ToString || Application.ToString == AdvantageFramework.Core.Security.Application.Advantage_Database_Update.ToString)
        //                            {
        //                                AdvantageFramework.Navigation.ShowMessageBox(PasswordMessage);

        //                                if (AdvantageFramework.Navigation.ShowChangePassword(SecurityDbContext.ConnectionString, UserName, Password) == AdvantageFramework.WinForm.MessageBox.DialogResults.Cancel)
        //                                {
        //                                    ErrorMessage = PasswordMessage;
        //                                    IsValid = false;
        //                                }
        //                                else
        //                                    IsValid = true;
        //                            }
        //                            else
        //                                AdvantageFramework.Navigation.ShowChangePasswordWithMessage(SecurityDbContext.ConnectionString, UserName, Password, PasswordMessage);
        //                        }
        //                        else
        //                        {
        //                            IsValid = true;

        //                            if (string.IsNullOrWhiteSpace(PasswordMessage) == false)
        //                            {
        //                                if (Application.ToString == AdvantageFramework.Core.Security.Application.Advantage.ToString || Application.ToString == AdvantageFramework.Core.Security.Application.Advantage_Database_Update.ToString)
        //                                    AdvantageFramework.Navigation.ShowMessageBox(PasswordMessage);
        //                                else
        //                                    AdvantageFramework.Navigation.ShowMessage(PasswordMessage);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ErrorMessage = "Incorrect password - Access denied";
        //                        IsWrongPassword = true;
        //                    }
        //                }
        //                else
        //                    ErrorMessage = "Invalid user - Access denied";
        //            }
        //            else
        //                ErrorMessage = "User not found - Access denied";
        //        }
        //        else
        //            ErrorMessage = "Application not found - Access denied";

        //        return IsValid;
        //    }
        //    public static bool UserHasGroupMembership(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, int UserID, bool CheckForUserAccess)
        //    {
        //        bool HasGroupMembership = false;
        //        Generic.List<AdvantageFramework.Core.Security.Database.Entities.GroupUser> GroupUsers = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            GroupUsers = AdvantageFramework.Core.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, UserID).ToList;
        //        }
        //        catch (Exception ex)
        //        {
        //            GroupUsers = null/* TODO Change to default(_) if this is not a reference type */;
        //        }

        //        if (GroupUsers != null && GroupUsers.Count > 0)
        //            HasGroupMembership = true;

        //        if (HasGroupMembership == false && CheckForUserAccess == true)

        //            // The Check for User Access means that we look at the User level security instead of the group.  Therefore, no group is required.
        //            HasGroupMembership = true;

        //        return HasGroupMembership;
        //    }
        //    private static string LoadLockoutMessage(ref AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, string UserCode)
        //    {
        //        string Message = string.Empty;
        //        int FailedAttempts = 0;
        //        int AttemptsBeforeLockout = 0;
        //        int ResetMinutes = 0;
        //        string UnlockTime = string.Empty;
        //        DateTime? LockedTime = default(Date?);
        //        AdvantageFramework.Core.Security.Database.Entities.PasswordLockout PasswordLockout = null/* TODO Change to default(_) if this is not a reference type */;
        //        long ElapsedTime = 0;
        //        long MinutesLockedOut = 0;

        //        PasswordLockout = AdvantageFramework.Core.Security.Database.Procedures.PasswordLockout.LoadByUserCode(SecurityDbContext, UserCode);

        //        if (PasswordLockout != null)
        //        {
        //            if (PasswordLockout.Attempts != null)
        //                FailedAttempts = PasswordLockout.Attempts;
        //            if (FailedAttempts > 0)
        //            {
        //                try
        //                {
        //                    AttemptsBeforeLockout = AdvantageFramework.Core.Security.Database.Procedures.PasswordLockout.AttemptsBeforeLockout(SecurityDbContext);
        //                }
        //                catch (Exception ex)
        //                {
        //                    AttemptsBeforeLockout = 0;
        //                }
        //            }
        //            if (FailedAttempts > 0 && AttemptsBeforeLockout > 0)
        //            {
        //                if (FailedAttempts >= AttemptsBeforeLockout)
        //                {
        //                    ResetMinutes = AdvantageFramework.Core.Security.Database.Procedures.PasswordLockout.LoadResetMinutes(SecurityDbContext);

        //                    if (ResetMinutes > 0)
        //                    {
        //                        MinutesLockedOut = DateDiff(DateInterval.Minute, System.Convert.ToDateTime(PasswordLockout.LockDate), DateTime.Now);



        //                        Message = string.Format(AdvantageFramework.Core.Security.Password.LockoutWithAttemptsMessage, ResetMinutes - MinutesLockedOut);
        //                    }
        //                    else
        //                        Message = string.Format(AdvantageFramework.Core.Security.Password.LockoutWithAdminOnlyMessage);
        //                }
        //                else if (FailedAttempts < AttemptsBeforeLockout)
        //                    Message = string.Format(AdvantageFramework.Core.Security.Password.IncorrectPasswordWithAttemptsMessage, FailedAttempts, AttemptsBeforeLockout);
        //            }
        //        }

        //        return Message;
        //    }

        //    public static bool IsUserSqlServerServerAdmin(ref AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, string SqlServerUserCode, ref string ErrorMessage)
        //    {
        //        bool UserIsSqlServerAdvantageAdmin = false;
        //        bool IsAgencyASP = false;

        //        try
        //        {
        //            IsAgencyASP = (SecurityDbContext.Database.SqlQuery<short>("SELECT ISNULL(ASP_ACTIVE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault == 1);
        //        }
        //        catch (Exception ex)
        //        {
        //            IsAgencyASP = false;
        //        }

        //        try
        //        {
        //            if (IsAgencyASP == true)
        //            {
        //                if (SecurityDbContext.Database.SqlQuery<int>("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault != 0)
        //                    UserIsSqlServerAdvantageAdmin = true;
        //                else
        //                    ErrorMessage = "You must be a sys admin to have access to this application.";
        //            }
        //            else if (SecurityDbContext.Database.SqlQuery<int>("SELECT ISNULL(IS_ROLEMEMBER('advan_admin'), 0)").FirstOrDefault == 1 || SecurityDbContext.Database.SqlQuery<int>("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault == 1)
        //                UserIsSqlServerAdvantageAdmin = true;
        //            else
        //                ErrorMessage = "You must be a sys admin or advan admin to have access to this application.";
        //        }
        //        catch (Exception ex)
        //        {
        //            UserIsSqlServerAdvantageAdmin = false;
        //            ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        //        }

        //        return UserIsSqlServerAdvantageAdmin;
        //    }
        //    public static bool ValidatePassword(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, string UserCode, string Password, ref Generic.List<string> ErrorMessages)
        //    {

        //        // Dim Patterns As New Generic.List(Of String)
        //        bool IsValid = true;
        //        short MinimumPasswordLength = 0;
        //        bool ComplexityRequired = false;
        //        bool UppercaseRequired = false;
        //        bool LowercaseRequired = false;
        //        bool NumberRequired = false;
        //        bool SpecialCharacterRequired = false;
        //        short PasswordHistoryCount = 0;
        //        string CurrEncrypted = string.Empty;
        //        // Dim CurrentPassword As String = String.Empty
        //        bool HistoryCounterIsValid = true;
        //        string EncryptedPassword = string.Empty;

        //        if (ErrorMessages == null)
        //            ErrorMessages = new List<string>();
        //        try
        //        {
        //            if (Password.ToUpper().Contains("BEEFSTEW") == true)
        //                ErrorMessages.Add(string.Format("You cannot use '{0}' in a password.   It's not strogonoff.", Password));
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //        try
        //        {
        //            CurrEncrypted = SecurityDbContext.Database.SqlQuery<string>(string.Format("SELECT TOP 1 PASSWORD FROM SEC_USER WITH(NOLOCK) WHERE USER_CODE = '{0}' ORDER BY SEC_USER_ID DESC;", UserCode)).SingleOrDefault;
        //        }
        //        catch (Exception ex)
        //        {
        //            CurrEncrypted = string.Empty;
        //        }
        //        // If String.IsNullOrWhiteSpace(CurrEncrypted) = False Then

        //        // CurrentPassword = AdvantageFramework.Core.Security.Encryption.Decrypt(CurrEncrypted)

        //        // End If
        //        if (CurrEncrypted == AdvantageFramework.Core.Security.Encryption.EncryptPassword(Password))
        //            ErrorMessages.Add("New password is old password.");
        //        else if (Password.Contains(" ") == true)
        //            ErrorMessages.Add("Password cannot contain spaces.");
        //        else if (Password.ToUpper().Contains(UserCode.ToUpper()))
        //            ErrorMessages.Add("Password cannot contain user code.");
        //        else if (string.IsNullOrWhiteSpace(CurrEncrypted) == false && string.IsNullOrWhiteSpace(Password) == false && AdvantageFramework.Core.Security.Encryption.EncryptPassword(Password) == CurrEncrypted)

        //            // Someone clicked save on the admin form which shows encrypted password
        //            // That means they really didn't change it
        //            ErrorMessages.Add("Password did not change.");
        //        else if (AdvantageFramework.StringUtilities.ContainsIllegalCharacters(Password) == true)
        //            ErrorMessages.Add(@"Password cannot include characters:  ?, /, \, ', &, or "".");
        //        else
        //        {

        //            // Minimum Password Length
        //            try
        //            {
        //                MinimumPasswordLength = SecurityDbContext.Database.SqlQuery<short>(@"SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS SMALLINT) 
        //                                                                                       FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_MIN_LEN';").FirstOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                MinimumPasswordLength = 0;
        //            }
        //            if (MinimumPasswordLength > 0 && Password.Length < MinimumPasswordLength)
        //                ErrorMessages.Add(string.Format("Password too short.  Must have at least {0} characters.", MinimumPasswordLength.ToString()));
        //            // Password History Count
        //            try
        //            {
        //                PasswordHistoryCount = SecurityDbContext.Database.SqlQuery<short>(@"SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS SMALLINT) 
        //                                                                                      FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_HIST_CT';").FirstOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                PasswordHistoryCount = 0;
        //            }
        //            if (PasswordHistoryCount > 0)
        //            {
        //                try
        //                {
        //                    EncryptedPassword = AdvantageFramework.Core.Security.Encryption.EncryptPassword(Password);

        //                    HistoryCounterIsValid = AdvantageFramework.Core.Security.Database.Procedures.PasswordHistory.ValidatePasswordHistory(SecurityDbContext, UserCode, EncryptedPassword);
        //                }
        //                catch (Exception ex)
        //                {
        //                    HistoryCounterIsValid = true;
        //                }
        //                if (HistoryCounterIsValid == false)
        //                    ErrorMessages.Add("You have already used this password.  Please use a different one.");
        //            }
        //            // Complexity Required
        //            try
        //            {
        //                ComplexityRequired = SecurityDbContext.Database.SqlQuery<bool>(@"SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
        //                                                                                      FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_CXT_REQ';").FirstOrDefault;
        //            }
        //            catch (Exception ex)
        //            {
        //                ComplexityRequired = false;
        //            }
        //            if (ComplexityRequired == true)
        //            {

        //                // Uppercase Required
        //                try
        //                {
        //                    UppercaseRequired = SecurityDbContext.Database.SqlQuery<bool>(@"SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
        //                                                                                         FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_CXT_UC';").FirstOrDefault;
        //                }
        //                catch (Exception ex)
        //                {
        //                    UppercaseRequired = false;
        //                }
        //                if (UppercaseRequired == true)
        //                {
        //                    if (System.Text.RegularExpressions.Regex.IsMatch(Password, "[A-Z]") == false)
        //                        ErrorMessages.Add("Password must contain at least one uppercase letter.");
        //                }
        //                // Lowercase Required
        //                try
        //                {
        //                    LowercaseRequired = SecurityDbContext.Database.SqlQuery<bool>(@"SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
        //                                                                                         FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_CXT_LC';").FirstOrDefault;
        //                }

        //                catch (Exception ex)
        //                {
        //                    LowercaseRequired = false;
        //                }
        //                if (LowercaseRequired == true)
        //                {
        //                    if (System.Text.RegularExpressions.Regex.IsMatch(Password, "[a-z]") == false)
        //                        ErrorMessages.Add("Password must contain at least one lowercase letter.");
        //                }
        //                // Number Required
        //                try
        //                {
        //                    NumberRequired = SecurityDbContext.Database.SqlQuery<bool>(@"SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
        //                                                                                      FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_CXT_NUM';").FirstOrDefault;
        //                }
        //                catch (Exception ex)
        //                {
        //                    NumberRequired = false;
        //                }
        //                if (NumberRequired == true)
        //                {
        //                    if (System.Text.RegularExpressions.Regex.IsMatch(Password, "[0-9]") == false)
        //                        ErrorMessages.Add("Password must contain at least one number.");
        //                }
        //                // Special Character Required
        //                try
        //                {
        //                    SpecialCharacterRequired = SecurityDbContext.Database.SqlQuery<bool>(@"SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) 
        //                                                                                                FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_XST_SPL';").FirstOrDefault;
        //                }
        //                catch (Exception ex)
        //                {
        //                    SpecialCharacterRequired = false;
        //                }
        //                if (SpecialCharacterRequired == true)
        //                {
        //                    if (System.Text.RegularExpressions.Regex.IsMatch(Password, @"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\] ]") == false)
        //                        ErrorMessages.Add("Password must contain at least one special character.");
        //                }
        //            }
        //        }
        //        if (ErrorMessages.Count > 0)
        //            IsValid = false;

        //        return IsValid;
        //    }
        //    public static bool IsPasswordExpired(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, string UserCode, ref string ErrorMessage)
        //    {
        //        bool IsExpired = false;
        //        short PasswordExpirationDays = 0;
        //        AdvantageFramework.Core.Security.Database.Entities.PasswordHistory LatestPasswordHistory = null/* TODO Change to default(_) if this is not a reference type */;
        //        long DaysInUse = 0;
        //        AdvantageFramework.Core.Security.Database.Entities.User User = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            PasswordExpirationDays = SecurityDbContext.Database.SqlQuery<short>(@"SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS SMALLINT) 
        //                                                                                    FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PWD_EXP_DYS';").FirstOrDefault;
        //        }
        //        catch (Exception ex)
        //        {
        //            PasswordExpirationDays = 0;
        //        }

        //        if (PasswordExpirationDays > 0)
        //        {
        //            LatestPasswordHistory = AdvantageFramework.Core.Security.Database.Procedures.PasswordHistory.LoadLatestByUserCode(SecurityDbContext, UserCode);

        //            if (LatestPasswordHistory != null)
        //            {
        //                try
        //                {
        //                    DaysInUse = DateDiff(DateInterval.Day, LatestPasswordHistory.StartDate, DateTime.Today.Date);
        //                }
        //                catch (Exception ex)
        //                {
        //                    DaysInUse = 0;
        //                }

        //                if (DaysInUse > PasswordExpirationDays)
        //                {
        //                    ErrorMessage = "Password expired.";
        //                    IsExpired = true;
        //                }
        //                else if (DaysInUse == PasswordExpirationDays)
        //                    ErrorMessage = "Password expires today.";
        //            }
        //            else
        //            {
        //                User = AdvantageFramework.Core.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode);

        //                if (User != null)
        //                    AdvantageFramework.Core.Security.Password.InsertNewPasswordHistory(SecurityDbContext, User);
        //            }
        //        }

        //        return IsExpired;
        //    }
        //    public static Generic.List<System.Security.Classes.PasswordUser> LoadPasswordUsers(AdvantageFramework.Core.Security.Database.DbContext SecurityDbContext, ref string ErrorMessage)
        //    {
        //        Generic.List<System.Security.Classes.PasswordUser> PasswordUsers = null/* TODO Change to default(_) if this is not a reference type */;

        //        try
        //        {
        //            PasswordUsers = SecurityDbContext.Database.SqlQuery<System.Security.Classes.PasswordUser>("EXEC [dbo].[advsp_sec_pwd_load_users];").ToList;
        //        }
        //        catch (Exception ex)
        //        {
        //            PasswordUsers = null/* TODO Change to default(_) if this is not a reference type */;
        //            ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex);
        //            AdvantageFramework.Core.Security.AddWebvantageEventLog("LoadPasswordUsers:  " + System.Diagnostics.EventLogEntryType.Error);
        //        }

        //        if (PasswordUsers == null)
        //            PasswordUsers = new List<Classes.PasswordUser>();

        //        return PasswordUsers;
        //    }
    }
}
