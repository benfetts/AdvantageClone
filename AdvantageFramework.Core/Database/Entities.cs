using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Entities
{
    #region  Constants 



    #endregion

    #region  Enum 

    public enum LocationLogoTypes
    {
        HeaderPortrait = 1,
        HeaderLandscape = 2,
        FooterPortrait = 3,
        FooterLandscape = 4
    }

    public enum SystemRecordSources
    {
        MediaOcean = 1
    }

    public enum DashboardTypes
    {
        MediaPlanning = 1,
        MediaPlanning_MasterPlans = 2,
        MediaBroadcastWorksheetSetup = 3,
        BroadcastResearchTool_TV = 4,
        BroadcastResearchTool_Radio = 5,
        BroadcastResearchTool_RadioCounty = 6,
        RevenueResourcePlanSetup = 7,
        RevenueResourcePlanRevenueSetup = 8,
        RevenueResourcePlanResourceSetup = 9,
        BroadcastResearchTool_National = 10
    }

    public enum CycleTypes
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("A", "Annually")]
        Annually,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("D", "Daily")]
        Daily,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Monthly")]
        Monthly,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Q", "Quarterly")]
        Quarterly,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("W", "Weekly")]
        Weekly
    }

    public enum MediaPlanDetailTotalsType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Demo 1 GRP/TRP/IMP")]
        Demo1 = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Demo 2 GRP/TRP/IMP")]
        Demo2 = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Dollars")]
        Dollars = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Units")]
        Units = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Rate (STD or CPM)")]
        Rate = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Impressions")]
        Impressions = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "Clicks")]
        Clicks = 7
    }

    public enum DefaultCurrencySymbols
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("USD", "$")]
        USD,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("GBP", "£")]
        GBP,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("EUR", "€")]
        EUR,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("JPY", "¥")]
        JPY,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("BRL", "R$")]
        BRL
    }

    public enum DefaultCurrencyText
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("USD", "Dollars")]
        USD,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("GBP", "Pounds")]
        GBP,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("EUR", "Euros")]
        EUR,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("JPY", "Yen")]
        JPY,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("BRL", "Real")]
        BRL
    }

    public enum DefaultCurrencyCoinText
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("USD", "Cents")]
        USD,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("GBP", "Pence")]
        GBP,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("EUR", "Cents")]
        EUR,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("JPY", "Sen")]
        JPY,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("BRL", "Centavos")]
        BRL
    }

    public enum ReportMissingTime
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "By Day")]
        ByDay = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "By Week")]
        ByWeek = 1
    }

    public enum EmployeeHRStatus : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "N/A")]
        NA = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Exempt")]
        Exempt = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Non-Exempt")]
        NonExempt = 2
    }

    public enum ClientARAddressSelection
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Client Contact")]
        ClientContact = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Client Statement")]
        ClientStatement = 2
    }

    public enum ProductARAddressSelection
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Product Contact")]
        ProductContact = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Product Statement")]
        ProductStatement = 2
    }

    public enum PostPeriodFormats : long
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Option 1")]
        MMEqualToCalendarMonth = 1L,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Option 2")]
        MMNotEqualToCalendarMonth = 2L
    }

    public enum PostPeriodFiscalYearFormats : long
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Fiscal Year Begins in the Previous Calendar Year")]
        FiscalYearBeginsInPreviousCalendarYear = 2L,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Fiscal Year Begins in the Current Calendar Year")]
        FiscalYearBeginsInCurrentCalendarYear = 3L
    }

    public enum PostPeriodStatus
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("C", "Current")]
        Current,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("X", "Closed")]
        Closed,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("", "Open")]
        Open
    }

    public enum FunctionTypes
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("E", "Employee")]
        E,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Income Only")]
        I,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("V", "Vendor")]
        V,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("C", "Client")]
        C
    }

    public enum LocationPrintInformation
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Name", "Name")]
        Name,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Street", "Street")]
        Street,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("POBox", "PO Box")]
        POBox,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("City", "City")]
        City,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("State", "State")]
        State,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Zip", "Zip")]
        Zip,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Phone", "Phone")]
        Phone,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Fax", "Fax")]
        Fax,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Email", "Email")]
        Email
    }

    public enum InvoiceFormats
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Client", "Client")]
        Client,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Default", "Agency")]
        AgencyDefault,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Custom", "Custom Legacy")]
        Custom
    }

    public enum EstimateFormatsClient
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Client", "Client")]
        Client,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Default", "Agency")]
        AgencyDefault
    }

    public enum EstimateFormatsProduct
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Product", "Product")]
        Product,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Default", "Agency")]
        AgencyDefault
    }

    public enum StandardCommentTypes
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Standard Footer", "Standard Footer")]
        StandardFooter,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Standard Guidelines", "Standard Guidelines")]
        StandardGuidelines
    }

    public enum StandardCommentApplications
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Estimates", "Estimates")]
        Estimates,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Purchase Order", "Purchase Order")]
        PurchaseOrder,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Invoices", "Invoices")]
        Invoices,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Media Manager Orders", "Media Manager Orders")]
        MediaManagerOrders,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Media RFP", "Media RFP")]
        MediaRFP,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Invoices Coversheet", "Invoices Coversheet")]
        InvoicesCoversheet,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Media Traffic", "Media Traffic")]
        MediaTraffic
    }

    public enum FeeTypes : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Fee Time")]
        FeeTime = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Production Commission")]
        ProductionCommission = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Media Commission")]
        MediaCommission = 3
    }

    public enum ExceedEstimateOptions
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Yes")]
        Yes = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Warn")]
        Warn = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "No")]
        No = 2
    }

    public enum CampaignTypes : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Overall")]
        Overall = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Assigned To Jobs And Orders")]
        AssignedToJobsAndOrders = 2
    }

    public enum CampaignDetailTypes
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Production", "Production")]
        Production,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Media", "Media")]
        Media
    }

    public enum MediaImportOptions
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CM", "Core Media")]
        CoreMedia,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MM", "Smart Plus")]
        SmartPlus,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("ST", "Strata")]
        Strata,
        // <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TA", "Tapscan")>
        // Tapscan
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("PQ", "PERQ")]
        PERQ
    }

    public enum ImportFileTypes
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("FLAT", "Fixed")]
        Fixed,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("DELIMITED", "Delimited")]
        Delimited
    }

    public enum AssignProductionInvoicesBy : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Job")]
        Job = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Job Component")]
        JobComponent = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Product / Sales Class")]
        ProductSalesClass = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Campaign")]
        Campaign = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Purchase Order")]
        PurchaseOrder = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Client")]
        Client = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "Division")]
        Division = 7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "Product")]
        Product = 8
    }

    public enum Yes1No0 : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Yes")]
        Yes = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "No")]
        No = 0
    }

    public enum AssignMediaInvoicesBy
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Sales Class")]
        SalesClass = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Client P.O.")]
        ClientPurchaseOrder = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Market")]
        Market = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Order #")]
        OrderNumber = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Campaign")]
        Campaign = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Order Type")]
        OrderType = 6
    }

    public enum MediaType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Internet")]
        Internet,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("N", "Newspaper")]
        Newspaper,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Outdoor")]
        Outdoor,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Magazine")]
        Magazine
    }

    public enum SalesClassMediaType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Magazine")]
        Magazine,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("N", "Newspaper")]
        Newspaper,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("R", "Radio")]
        Radio,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("T", "Television")]
        Television,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Out of Home")]
        OutOfHome,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Internet")]
        Internet,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("P", "Non Media")]
        NonMedia
    }

    public enum AssociateMediaType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Magazine")]
        Magazine,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("N", "Newspaper")]
        Newspaper,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("R", "Radio")]
        Radio,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("T", "Television")]
        Television,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Out of Home")]
        OutOfHome,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Internet")]
        Internet
    }

    public enum AccountPayableImportMediaType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("R", "Radio")]
        Radio,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("T", "Television")]
        Television,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Internet")]
        Internet,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Out of Home")]
        OutOfHome,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("N", "Newspaper")]
        Newspaper,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Magazine")]
        Magazine
    }

    public enum GeneralLedgerAccountTypes
    {
        ExpenseOther = 15,
        ExpenseTaxes = 16,
        Income_Other = 9,
        ExpenseOperating = 14,
        ExpenseCOS = 13,
        Income = 8,
        Equity = 20,
        NonCurrentLiability = 4,
        CurrentLiability = 5,
        FixedAsset = 3,
        CurrentAsset = 2,
        NonCurrentAsset = 1
    }

    public enum AgencyCommentTypes
    {
        AUTO_AR_STATEMENT
    }

    public enum UserDefinedLabelTables
    {
        JOB_CMP_TAB,
        JOB_CMP_UDV1,
        JOB_CMP_UDV2,
        JOB_CMP_UDV3,
        JOB_CMP_UDV4,
        JOB_CMP_UDV5,
        JOB_LOG_TAB,
        JOB_LOG_UDV1,
        JOB_LOG_UDV2,
        JOB_LOG_UDV3,
        JOB_LOG_UDV4,
        JOB_LOG_UDV5
    }

    public enum ServiceFeeReconciliationGroupByOptions : int
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Job")]
        Job = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Job, Component")]
        Job_Component = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Job, Component, Function")]
        Job_Component_Function = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Job, Function")]
        Job_Function = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Campaign")]
        Campaign = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Function")]
        Function = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "Job, Function Consolidation")]
        Job_FunctionConsolidation = 7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "Job, Component, Function Consolidation")]
        Job_Component_FunctionConsolidation = 8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("9", "Function Consolidation")]
        FunctionConsolidation = 9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("10", "Job, Function Heading")]
        Job_FunctionHeading = 10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("11", "Job, Component, Function Heading")]
        Job_Component_FunctionHeading = 11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("12", "Function Heading")]
        FunctionHeading = 12
    }

    public enum ServiceFeeReconciliationSummaryStyles : int
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Date/Employee")]
        Date_Employee = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Employee")]
        Employee = 2
    }

    public enum MarkupTaxFlags : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Markup Not Taxable")]
        MarkupNotTaxable = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Tax Markup")]
        TaxMarkup = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Tax Markup Only")]
        TaxMarkupOnly = 2
    }

    public enum FeeTimes : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "No")]
        No = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Time Against Fee")]
        TimeAgainstFee = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Time Against Commission (P)")]
        TimeAgainstCommissionP = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Time Against Commission (M)")]
        TimeAgainstCommissionM = 3
    }

    public enum PTOTypes : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Vacation")]
        Vacation = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Sick")]
        Sick = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Personal")]
        Personal = 3
    }

    public enum PTOActions : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Accrue")]
        Accrue = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Replace")]
        Replace = 2
    }

    public enum ExpenseReportStatus : short
    {
        Pending = 0,
        Submitted = 1,
        Approved = 2
    }

    public enum BeforeAfter : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Before")]
        Before = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "After")]
        After = 1
    }

    public enum ResourceTaskCondition : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Always Add")]
        AlwaysAdd = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "On Ad Number Change")]
        OnAdNumberChange = 1
    }

    public enum POApprovalRuleEmployeeOrder
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("10", "Primary Approver")]
        PrimaryApprover,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("20", "Alternate Approver1")]
        AlternateApprover1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("30", "Alternate Approver2")]
        AlternateApprover2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("40", "Alternate Approver3")]
        AlternateApprover3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("50", "Alternate Approver4")]
        AlternateApprover4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("60", "Alternate Approver5")]
        AlternateApprover5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("70", "Alternate Approver6")]
        AlternateApprover6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("80", "Alternate Approver7")]
        AlternateApprover7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("90", "Alternate Approver8")]
        AlternateApprover8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("100", "Alternate Approver9")]
        AlternateApprover9
    }

    public enum RateBy : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Column x Inch")]
        ColumnInch = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Lines")]
        Lines = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Flat Rate")]
        FlatRate = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "CPM")]
        CPM = 4
    }

    public enum RateType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Net")]
        Net = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Gross")]
        Gross = 1
    }

    public enum DocumentLevel : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Office")]
        Office = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Client")]
        Client = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Division")]
        Division = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Product")]
        Product = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Campaign")]
        Campaign = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Job")]
        Job = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Job / Job Component")]
        JobComponent = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "AP Invoice")]
        AccountPayableInvoice = 7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "Ad Number")]
        AdNumber = 8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("9", "Expense Receipts")]
        ExpenseReceipts = 9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("10", "Employee")]
        Employee = 10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("11", "Vendor")]
        Vendor = 11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("12", "Contract")]
        Contract = 12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("13", "Contract Value Added")]
        ContractValueAdded = 13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("14", "Contract Report")]
        ContractReport = 14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("15", "AR Invoice")]
        AccountReceivableInvoice = 15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("16", "Agency Desktop")]
        AgencyDesktop = 16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("17", "Executive Desktop")]
        ExecutiveDesktop = 17,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("18", "Task")]
        Task = 18,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("19", "Vendor Contract")]
        VendorContract = 19,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("20", "Alert Attachment")]
        AlertAttachment = 20,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("21", "Media Order")]
        MediaOrder = 21,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("22", "Purchase Order")]
        PurchaseOrder = 22,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("23", "Media Traffic Detail")]
        MediaTrafficDetail = 23,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("24", "Journal Entry")]
        JournalEntry = 24
    }

    public enum DocumentSubLevel : short
    {
        Default,
        ExpenseDetailDocument
        // ExpenseDocumentOnly
    }

    public enum DesktopObjectTypes : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Agency Desktop")]
        AgencyDesktop = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Executive Desktop")]
        ExecutiveDesktop = 1
    }

    public enum VendorCategory
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("P", "Production")]
        NonMedia,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Magazine")]
        Magazine,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("N", "Newspaper")]
        Newspaper,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("R", "Radio")]
        Radio,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("T", "Television")]
        Television,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Out of Home")]
        OutOfHome,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Internet")]
        Internet,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Z", "Non Client")]
        NonClient
    }

    /// <remarks>Use for Vendor Import Only</remarks>
    public enum ImportVendorCategories
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("P", "Production & Operating")]
        P,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Magazine Media")]
        M,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("N", "Newspaper Media")]
        N,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("R", "Radio Media")]
        R,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("T", "TV Media")]
        T,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Out-of-Home")]
        O,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Internet")]
        I,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Z", "Non Client")]
        Z
    }

    public enum ACHType
    {
        CCD,
        CTX,
        PPD
    }

    public enum DocumentUploadType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("D", "File / Document")]
        Document,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L", "Link")]
        Link
    }

    public enum AlertPriority : short
    {
        Highest = 1,
        High = 2,
        Normal = 3,
        Low = 4,
        Lowest = 5
    }

    public enum ExpenseItemPaymentType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Corporate Credit Card")]
        CorporateCreditCard = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Personal Credit Card")]
        PersonalCreditCard = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Cash")]
        Cash = 2
    }

    public enum AssociateLevel : short
    {
        Client = 0,
        Product = 1
    }

    public enum JobTemplateItemCategory : short
    {
        All,
        Fields,
        SystemRequired
    }

    public enum JobSpecFields
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_1", "Single (1) character text")]
        CHAR1_1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_2", "Single (1) character text")]
        CHAR1_2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_3", "Single (1) character text")]
        CHAR1_3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_4", "Single (1) character text")]
        CHAR1_4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_5", "Single (1) character text")]
        CHAR1_5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_6", "Single (1) character text")]
        CHAR1_6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_7", "Single (1) character text")]
        CHAR1_7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_8", "Single (1) character text")]
        CHAR1_8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_9", "Single (1) character text")]
        CHAR1_9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_10", "Single (1) character text")]
        CHAR1_10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_11", "Single (1) character text")]
        CHAR1_11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_12", "Single (1) character text")]
        CHAR1_12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_13", "Single (1) character text")]
        CHAR1_13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_14", "Single (1) character text")]
        CHAR1_14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_15", "Single (1) character text")]
        CHAR1_15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_16", "Single (1) character text")]
        CHAR1_16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_17", "Single (1) character text")]
        CHAR1_17,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_18", "Single (1) character text")]
        CHAR1_18,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_19", "Single (1) character text")]
        CHAR1_19,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR1_20", "Single (1) character text")]
        CHAR1_20,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_1", "Ten (10) character text")]
        CHAR10_1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_2", "Ten (10) character text")]
        CHAR10_2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_3", "Ten (10) character text")]
        CHAR10_3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_4", "Ten (10) character text")]
        CHAR10_4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_5", "Ten (10) character text")]
        CHAR10_5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_6", "Ten (10) character text")]
        CHAR10_6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_7", "Ten (10) character text")]
        CHAR10_7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_8", "Ten (10) character text")]
        CHAR10_8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_9", "Ten (10) character text")]
        CHAR10_9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_10", "Ten (10) character text")]
        CHAR10_10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_11", "Ten (10) character text")]
        CHAR10_11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_12", "Ten (10) character text")]
        CHAR10_12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_13", "Ten (10) character text")]
        CHAR10_13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_14", "Ten (10) character text")]
        CHAR10_14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_15", "Ten (10) character text")]
        CHAR10_15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_16", "Ten (10) character text")]
        CHAR10_16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_17", "Ten (10) character text")]
        CHAR10_17,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_18", "Ten (10) character text")]
        CHAR10_18,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_19", "Ten (10) character text")]
        CHAR10_19,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR10_20", "Ten (10) character text")]
        CHAR10_20,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_1", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_2", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_3", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_4", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_5", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_6", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_7", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_8", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_9", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR254_10", "Two-hundred Fifty-Four (254) character text")]
        CHAR254_10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_1", "Fifty (50) character text")]
        CHAR50_1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_2", "Fifty (50) character text")]
        CHAR50_2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_3", "Fifty (50) character text")]
        CHAR50_3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_4", "Fifty (50) character text")]
        CHAR50_4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_5", "Fifty (50) character text")]
        CHAR50_5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_6", "Fifty (50) character text")]
        CHAR50_6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_7", "Fifty (50) character text")]
        CHAR50_7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_8", "Fifty (50) character text")]
        CHAR50_8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_9", "Fifty (50) character text")]
        CHAR50_9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_10", "Fifty (50) character text")]
        CHAR50_10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_11", "Fifty (50) character text")]
        CHAR50_11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_12", "Fifty (50) character text")]
        CHAR50_12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_13", "Fifty (50) character text")]
        CHAR50_13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_14", "Fifty (50) character text")]
        CHAR50_14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_15", "Fifty (50) character text")]
        CHAR50_15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_16", "Fifty (50) character text")]
        CHAR50_16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_17", "Fifty (50) character text")]
        CHAR50_17,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_18", "Fifty (50) character text")]
        CHAR50_18,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_19", "Fifty (50) character text")]
        CHAR50_19,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CHAR50_20", "Fifty (50) character text")]
        CHAR50_20,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_1", "Numeric whole (-999999999 to 999999999)")]
        INT_1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_2", "Numeric whole (-999999999 to 999999999)")]
        INT_2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_3", "Numeric whole (-999999999 to 999999999)")]
        INT_3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_4", "Numeric whole (-999999999 to 999999999)")]
        INT_4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_5", "Numeric whole (-999999999 to 999999999)")]
        INT_5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_6", "Numeric whole (-999999999 to 999999999)")]
        INT_6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_7", "Numeric whole (-999999999 to 999999999)")]
        INT_7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_8", "Numeric whole (-999999999 to 999999999)")]
        INT_8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_9", "Numeric whole (-999999999 to 999999999)")]
        INT_9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_10", "Numeric whole (-999999999 to 999999999)")]
        INT_10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_11", "Numeric whole (-999999999 to 999999999)")]
        INT_11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_12", "Numeric whole (-999999999 to 999999999)")]
        INT_12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_13", "Numeric whole (-999999999 to 999999999)")]
        INT_13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_14", "Numeric whole (-999999999 to 999999999)")]
        INT_14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_15", "Numeric whole (-999999999 to 999999999)")]
        INT_15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_16", "Numeric whole (-999999999 to 999999999)")]
        INT_16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_17", "Numeric whole (-999999999 to 999999999)")]
        INT_17,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_18", "Numeric whole (-999999999 to 999999999)")]
        INT_18,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_19", "Numeric whole (-999999999 to 999999999)")]
        INT_19,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("INT_20", "Numeric whole (-999999999 to 999999999)")]
        INT_20,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_1", "Numeric whole (0 to 999)")]
        SMALLINT_1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_2", "Numeric whole (0 to 999)")]
        SMALLINT_2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_3", "Numeric whole (0 to 999)")]
        SMALLINT_3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_4", "Numeric whole (0 to 999)")]
        SMALLINT_4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_5", "Numeric whole (0 to 999)")]
        SMALLINT_5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_6", "Numeric whole (0 to 999)")]
        SMALLINT_6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_7", "Numeric whole (0 to 999)")]
        SMALLINT_7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_8", "Numeric whole (0 to 999)")]
        SMALLINT_8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_9", "Numeric whole (0 to 999)")]
        SMALLINT_9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_10", "Numeric whole (0 to 999)")]
        SMALLINT_10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_11", "Numeric whole (0 to 999)")]
        SMALLINT_11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_12", "Numeric whole (0 to 999)")]
        SMALLINT_12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_13", "Numeric whole (0 to 999)")]
        SMALLINT_13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_14", "Numeric whole (0 to 999)")]
        SMALLINT_14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_15", "Numeric whole (0 to 999)")]
        SMALLINT_15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_16", "Numeric whole (0 to 999)")]
        SMALLINT_16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_17", "Numeric whole (0 to 999)")]
        SMALLINT_17,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_18", "Numeric whole (0 to 999)")]
        SMALLINT_18,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_19", "Numeric whole (0 to 999)")]
        SMALLINT_19,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SMALLINT_20", "Numeric whole (0 to 999)")]
        SMALLINT_20,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_1", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_2", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_3", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_4", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_5", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_6", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_7", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_8", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_9", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_10", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_11", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_12", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_13", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_14", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_15", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_16", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_17", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_17,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_18", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_18,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_19", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_19,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TEXT_20", "Thirty-Two Thousand (32,000) character memo")]
        TEXT_20
    }

    public enum VendorEEOCStatus // also see table VENDOR_EEOC_STATUS
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Other than Small Business")]
        OtherThanSmallBusiness,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SB", "Small Business")]
        SmallBusinessConcern,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("SDB", "Small Disadvantaged Business")]
        SmallDisadvantagedBusiness,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("WOSB", "Woman Owned Small Business")]
        WomenOwnedSmallBusiness,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("WOB", "Woman Owned Business")]
        WomenOwnedBusiness,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MO", "Minority Owned Business")]
        MinorityOwned,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("OT", "Other")]
        Other,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("VOSB", "Veteran Owned Business")]
        VeteranOwnedSmallBusiness,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("HZSB", "HUBZone Small Business")]
        HUBZoneSmallBusiness,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MISC1", "Miscellaneous Category 1")]
        MiscellaneousCategory1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MISC2", "Miscellaneous Category 2")]
        MiscellaneousCategory2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MISC3", "Miscellaneous Category 3")]
        MiscellaneousCategory3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Individual Owned")]
        IndividualOwned,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("N", "Not an EEOC vendor")]
        NotAnEEOCVendor,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LGBT", "LGBT Owned")]
        LGBT
    }

    public enum VendorEEOC2Ethnicity : short // also see table VENDOR_EEOC2_ETHNICITY
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "White")]
        White = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "African American")]
        AfricanAmerican = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Hispanic")]
        Hispanic = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Asian American")]
        AsianAmerican = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Asian Subcontinent American")]
        AsianSubcontinentAmerican = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Native American")]
        NativeAmerican = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "Multi-Racial")]
        MultiRacial = 7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "Unknown")]
        Unknown = 8
    }

    public enum Vendor1099Category
    {
        NonEmployeeCompensation = 0,
        OtherIncome = 1,
        Rent = 2,
        Royalties = 3,
        GrossProceedsToAttorney = 4,
        MedicalAndHealthCare = 5
    }

    public enum VendorMediaDefaultUnits
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Monthly")]
        M,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("BM", "BroadcastMonth")]
        BM,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("W", "Weekly")]
        W,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CM", "CalendarMonth")]
        CM,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("D", "Daily")]
        D,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "4 Week")]
        F
    }

    public enum MediaApprovalStatus : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Pending Approval")]
        PendingApproval = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Approved")]
        Approved = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Approved With Changes")]
        ApprovedWithChanges = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Approval Not Required")]
        ApprovalNotRequired = 0
    }

    public enum MediaApprovalStatusPendingOnly : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "None")]
        None = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Pending Approval")]
        PendingApproval = 1
    }

    public enum PartnerAllocationType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("C", "Campaign")]
        Campaign,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Order")]
        Order
    }

    public enum MediaOrderType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("T", "Television")]
        Television,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("R", "Radio")]
        Radio,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Internet")]
        Internet,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Magazine")]
        Magazine,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("N", "Newspaper")]
        Newspaper,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Out of Home")]
        OutOfHome
    }

    public enum SearchAllParameters
    {
        EmployeeCode,
        UserCode,
        SearchTerm,
        ExactSearch,
        JobsOpen,
        JobsClosed,
        JobsDescription,
        JobsComments,
        AlertsStandard,
        AlertsAssignments,
        AlertsSubject,
        AlertsDescription,
        AlertsOpen,
        AlertsDismissedCompleted,
        ScheduleComments,
        ScheduleIncludeClosed,
        ScheduleTaskIncludeClosed,
        ScheduleTaskDescription,
        ScheduleTaskFunctionComments,
        ScheduleTaskDueDateComments,
        ScheduleTaskRevisionDateComments,
        EstimateDescription,
        EstimateComments,
        EstimateFooterComments,
        EstimateComponentDescription,
        EstimateComponentComments,
        EstimateQuoteDetailComments,
        EstimateQuoteDetailDescription,
        CampaignComments,
        PurchaseOrderDescription,
        PurchaseOrderMainInstruction,
        PurchaseOrderDeliveryInstruction,
        PurchaseOrderDetailDescription,
        PurchaseOrderDetailLineDescription,
        PurchaseOrderDetailInstruction,
        ClientPortal,
        ClientPortalID,
        JobRequests
    }

    public enum AccountGroupTypes : short
    {
        FullAccountCode = 1,
        BaseAccountCode = 2
    }

    public enum AccountAllocationTypes : short
    {
        Percentage = 1,
        SquareFootage = 2,
        NumberOfEmployees = 3
    }

    public enum VCCStatuses : short
    {
        Accepted = 1,
        Declined = 2
    }

    public enum CostType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("NA", "NA")]
        NA,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPM", "CPM")]
        CPM,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPC", "CPC")]
        CPC,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPA", "CPA")]
        CPA,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPI", "CPI")]
        CPI,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPL", "CPL")]
        CPL
    }

    public enum BroadcastDaysToBillTimeframe : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Before Broadcast Date")]
        BeforeBroadcastDate = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "After Broadcast Date")]
        AfterBroadcastDate = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Before Close Date")]
        BeforeCloseDate = 3
    }

    public enum PrintDaysToBillTimeframe : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Before Insertion Date")]
        BeforeInsertionDate = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "After Insertion Date")]
        AfterInsertionDate = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Before Close Date")]
        BeforeCloseDate = 3
    }

    public enum InternetDaysToBillTimeframe : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Before Run Date")]
        BeforeRunDate = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "After Run Date")]
        AfterRunDate = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Before Close Date")]
        BeforeCloseDate = 3
    }

    public enum OutofHomeDaysToBillTimeframe : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Before Post Date")]
        BeforePostDate = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "After Post Date")]
        AfterPostDate = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Before Close Date")]
        BeforeCloseDate = 3
    }

    public enum MediaPrebillPostbill : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Prebill")]
        Prebill = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Post Bill")]
        PostBill = 2
    }

    public enum AccountReceivableRecordType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("M", "Media")]
        M,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("P", "Production")]
        P
    }

    public enum TrafficScheduleBy : short
    {
        StartDate = 1,
        DueDate = 0
    }

    public enum BillingApprovalBatchApprovalRollupParameter
    {
        JobNumber,
        JobComponentNumber,
        CampaignIdentifier,
        RollupType,
        BillingApprovalID,
        BillingApprovalBatchID,
        TempCutoffDate,
        TempCutoffFunctionType
    }

    public enum BillingApprovalBatchApprovalRollupType
    {
        Job = 0,
        Campaign = 1
    }

    public enum DayPartTypeID : int
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Local TV")]
        Local_TV = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Local Radio")]
        Local_Radio = 2
    }

    public enum MediaATBBillingMethod
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Full Flight")]
        FullFlight = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "By Month (Split by Month)")]
        ByMonth = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Bill per Instructions")]
        BillPerInstructions = 2
    }

    public enum GeneralLedgerConfigSegmentType : short
    {
        Base = 1,
        Office = 2,
        Department = 3,
        Other = 4
    }

    public enum GeneralLedgerConfigSegmentAfter : short
    {
        Hyphen = 1,
        Period = 2
    }

    public enum GridAdvantageType : int
    {
        BillingCommandCenterProductionReview = 1,
        BillingCommandCenterJobComponentFunctionDetail = 2,
        BillingCommandCenterMediaReview = 3,
        EmployeeTimesheet = 4,
        AccountsPayableImport = 5,
        BillingCommandCenterProcessControl = 6,
        BillingCommandCenterBillHold = 7,
        BillingCommandCenterReconcileRecognize = 8,
        BillingCommandCenterJobComponentEmployeeTimeDetail = 9,
        BillingCommandCenterJobComponentIncomeOnlyDetail = 10,
        BillingCommandCenterJobComponentVendorDetail = 11,
        BillingCommandCenterJobDetailJobComponent = 12,
        MediaManagerMediaManagerReviewOrderDetail = 13,
        MediaManagerMediaManagerReviewVCCOrderDetail = 14,
        MediaManagerOrderProcessControl = 15,
        BillingCommandCenterJobComponentOpenPODetail = 16,
        MediaResults = 17,
        MediaBroadcastWorksheet = 18,
        MediaPlanningSetupEstimates = 19,
        MediaPlanningSetup = 20,
        DigitalCampaignManagerOpenPlanEstimates = 21,
        DigitalCampaignManagerEstimateDetailByFlight = 22,
        DigitalCampaignManagerEstimateDetailByPeriod = 23
    }

    public enum MediaATBOrderOptions
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Create orders with Ad Serving as a Net Charge")]
        AdServingAsNetCharge = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Create orders with Ad Serving as a line on each Vendor's order")]
        AdServingOnEachVendorOrder = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Create separate order for Ad Serving")]
        SeparateForAdServing = 2
    }

    public enum AlertListLevel
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "No Level")]
        NotSet = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Media ATB")]
        MediaATB = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Estimate")]
        Estimate = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Estimate Component")]
        EstimateComponent = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Estimate Quote")]
        EstimateQuote = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Project Schedule")]
        ProjectSchedule = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Project Schedule Task")]
        ProjectScheduleTask = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "Campaign")]
        Campaign = 7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "Job")]
        Job = 8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("9", "Job Component")]
        JobComponent = 9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("10", "Accounts Payable")]
        AccountsPayable = 10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("11", "Purchase Order")]
        PurchaseOrder = 11
    }

    public enum AlertListShowAlertType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "All Alerts & Assignments")]
        AllAlertsAndAssignments = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "All Alerts")]
        AllAlerts = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "My Assignments")]
        MyAssignments = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "All Assignments")]
        AllAssignments = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Unassigned")]
        Unassigned = 4
    }

    public enum AlertListGrouping
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "None")]
        None = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Category")]
        Category = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Office")]
        Office = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Client")]
        Client = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Division")]
        Division = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Product")]
        Product = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Campaign")]
        Campaign = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "Estimate")]
        Estimate = 7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "Estimate Component")]
        EstimateComponent = 8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("9", "Job")]
        Job = 9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("10", "Job Component")]
        JobComponent = 10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("11", "Task")]
        Task = 11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("12", "Template")]
        Template = 12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("13", "State")]
        State = 13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("14", "Due Date")]
        DueDate = 14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("15", "Priority")]
        Priority = 15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("16", "Authorization To Buy")]
        AuthorizationToBuy = 16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("17", "Level")]
        Level = 17
    }

    public enum ServiceFeeFrequency : short
    {
        Weekly = 1,
        Monthly = 2,
        Annually = 3
    }

    public enum VendorServiceTaxType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "PR Resident")]
        PRResident = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "US Resident")]
        USResident = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Non-US Resident")]
        NonUSResident = 3
    }

    public enum AvaTaxAddressValidationCountries
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("US", "US")]
        US,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CA", "Canada")]
        Canada
    }

    public enum ProductionAdvancedBillingIncome : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Upon Reconciliation")]
        UponReconciliation = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Initial Billing")]
        InitialBilling = 2
    }

    public enum MediaAdvancedBillingIncome
    {
        BillingDate = 1,
        InsertionBroadcast = 2,
        CloseDate = 3
    }

    public enum AdvanceBillingCalculateMethod
    {
        PercentToDate = 1,
        ManualEntry = 4
    }

    public enum PaymentManagerACHServiceClassCode : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("200", "200")]
        Code200 = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("220", "220")]
        Code220 = 2
    }

    public enum PaymentManagerACHStandardEntryClassCode : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("PPD", "PPD")]
        PPD = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CCD", "CCD")]
        CCD = 2
    }

    public enum DefaultCorrespondenceMethods : short
    {
        Email = 1,
        Print = 2
    }

    public enum AssignComboInvoicesBy : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "None")]
        None = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("21", "Client")]
        Client = 21,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("22", "ClientDivisionProduct")]
        ClientDivisionProduct = 22,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("23", "ClientCampaign")]
        ClientCampaign = 23,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("24", "ClientDivisionProductCampaign")]
        ClientDivisionProductCampaign = 24,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("25", "ClientDivision")]
        ClientDivision = 25
    }

    public enum OrderStatusType : short
    {
        Pending = 0,
        Printed = 1,
        QuoteGenerated = 2,
        QuoteAccepted = 3,
        OrderGenerated = 4,
        OrderAccepted = 5,
        MaterialsDelivered = 6,
        MaterialDeliveryVerified = 7,
        CancellationGenerated = 8,
        CancellationAccepted = 9,
        CostCollected = 10,
        ApprovedForBilling = 11,
        QuoteRecieved = 12,
        OrderRecieved = 13,
        CancellationRecieved = 14,
        OrderRejected = 15,
        MakegoodOfferSubmitted = 16,
        MakegoodOfferRejected = 17,
        MakegoodOfferAccepted = 18,
        ModifiedPendingCreate = 19,
        ModifiedPendingGenerate = 20
    }

    public enum VCCStatus
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("A", "Active")]
        Active,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("B", "Blocked")]
        Blocked,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("C", "Cancelled")]
        Cancelled,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("H", "Hold")]
        Hold,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("S", "Stolen")]
        Stolen
    }

    public enum VCCAction
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Credit Card Request")]
        CreditCardRequest = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Credit Card Update")]
        CreditCardUpdate = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Pending Transaction")]
        PendingTransaction = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Cleared Transaction")]
        ClearedTransaction = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Rejected Transaction")]
        RejectedTransaction = 5
    }

    public enum NewspaperCostRate
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPISTD", "Column/Inch (STD)")]
        CPISTD,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPLSTD", "Lines (STD)")]
        CPLSTD,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPMSTD", "Circulation/QTY (STD)")]
        CPMSTD,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPMCPM", "Circulation/QTY (CPM)")]
        CPMCPM,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("NA STD", "N/A (STD)")]
        NA_STD
    }

    public enum InternetCostType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPM", "CPM")]
        CPM,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPC", "CPC")]
        CPC,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CPA", "CPA")]
        CPA,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("NA", "N/A")]
        NA
    }

    public enum DocumentSearchCriteria
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "[All Criteria]")]
        AllCriteria = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "[No Criteria]")]
        NoCriteria = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Client")]
        Client = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Client/Division/Product")]
        ClientDivisionProduct = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Client Contract")]
        ClientContract = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Department")]
        Department = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "Division")]
        Division = 7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "Employee")]
        Employee = 8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("9", "Function Code")]
        FunctionCode = 9,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("10", "Job")]
        Job = 10,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("11", "Job Component")]
        JobComponent = 11,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("12", "Media Order/Line")]
        MediaOrderLine = 12,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("13", "Office")]
        Office = 13,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("14", "Product")]
        Product = 14,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("15", "Vendor")]
        Vendor = 15,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("16", "Alert Subject")]
        AlertSubject = 16,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("17", "Campaign")]
        Campaign = 17
    }

    public enum PTOImportStatus : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Approved")]
        Approved = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Cancelled")]
        Cancelled = 2
    }

    public enum ConceptShareBaseReviewType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Collaborative")]
        Collaborative = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "WorkFlow")]
        WorkFlow = 2
    }

    public enum AdjustCheckBodyLinesDn
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("-1", "[Agency Default]")]
        AgencyDefault,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "0")]
        Zero,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "1")]
        One,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "2")]
        Two
    }

    public enum AdjustCheckStubLinesUp
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("-1", "[Agency Default]")]
        AgencyDefault,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "0")]
        Zero,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "1")]
        One
    }

    public enum NielsenDataStream
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LO", "Live Only")]
        LO,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LS", "Live + Same Day")]
        LS,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L1", "Live + 1")]
        L1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L3", "Live + 3")]
        L3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L7", "Live + 7")]
        L7
    }

    public enum NielsenService
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "NSI")]
        NSI
    }

    public enum NielsenSampleType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "DMA")]
        DMA,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Hardwired")]
        Hardwired
    }

    public enum AdServerID : int
    {
        DoubleClick = 1
    }

    public enum NielsenTimeType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("C", "Commercial")]
        Commercial,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("P", "Program")]
        Program
    }

    public enum NielsenNationalDataStream
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L1", "Live + 1")]
        L1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L2", "Live + 2")]
        L2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L3", "Live + 3")]
        L3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L7", "Live + 7")]
        L7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LV", "Live")]
        LV,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LS", "Live + Same Day")]
        LS
    }

    public enum NielsenRadioGeoIndicator : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Metro")]
        Metro = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "TSA")]
        TSA = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "DMA")]
        DMA = 3
    }

    public enum NielsenRadioListeningLocation
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Total (Home & Away)")]
        Total = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "In Home (PPM & Nationwide PPM/Diary Combo)")]
        InHome = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Away - At Work (Diary Only)")]
        Away1 = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Away - In Car (Diary Only)")]
        Away2 = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Away - Other (Diary Only - not used at this time)")]
        Away3 = 5,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Out of Home (PPM & Nationwide PPM/Diary Combo))")]
        OutofHome = 6
    }

    public enum NielsenRadioStationComboType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Individual Station")]
        IndividualStation = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Simulcast Group")]
        SimulcastGroup = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Network Group")]
        NetworkGroup = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "X-Codes (Nationwide only) Or Non-commercial")]
        XCodes = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "Over the Air Internet Stream from Log Files (IAS only)")]
        OTA = 6,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "eRadio station (IAS only)")]
        eRadio = 7,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "Market Total Listening (TOTA) PPM -Specific")]
        MarketTotal = 8,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("9", "Persons Uing Measured Media (PUMM)")]
        PUMM = 9
    }

    public enum DoubleClickReportRelativeDateRange
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LAST_24_MONTHS", "Last 24 Months")]
        LAST_24_MONTHS,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LAST_30_DAYS", "Last 30 Days")]
        LAST_30_DAYS,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LAST_365_DAYS", "Last 365 Days")]
        LAST_365_DAYS,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LAST_7_DAYS", "Last 7 Days")]
        LAST_7_DAYS,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LAST_90_DAYS", "Last 90 Days")]
        LAST_90_DAYS,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MONTH_TO_DATE", "Month to Date")]
        MONTH_TO_DATE,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("PREVIOUS_MONTH", "Previous Month")]
        PREVIOUS_MONTH,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("PREVIOUS_QUARTER", "Previous Quarter")]
        PREVIOUS_QUARTER,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("PREVIOUS_WEEK", "Previous Week")]
        PREVIOUS_WEEK,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("PREVIOUS_YEAR", "Previous Year")]
        PREVIOUS_YEAR,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("QUARTER_TO_DATE", "Quarter to Date")]
        QUARTER_TO_DATE,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TODAY", "Today")]
        TODAY,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("WEEK_TO_DATE", "Week to Date")]
        WEEK_TO_DATE,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("YEAR_TO_DATE", "Year to Date")]
        YEAR_TO_DATE,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("YESTERDAY", "Yesterday")]
        YESTERDAY
    }

    public enum SpotTVResearchReportType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Ranker")]
        Ranker = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Trend by Book")]
        TrendByBook = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Trend by Station")]
        TrendByStation = 3
    }

    public enum AdServerPlacementNameFields
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MarketName", "Market Name")]
        MarketName,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("VendorName", "Vendor Name")]
        VendorName,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("RateType", "Rate Type")]
        RateType,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Headline", "Headline")]
        Headline,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("CreativeSizeDescription", "Creative Size Description")]
        CreativeSizeDescription,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("InternetTypeDescription", "Internet Type Description")]
        InternetTypeDescription,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Placement", "Placement")]
        Placement,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TargetAudience", "Target Audience")]
        TargetAudience,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("OrderNumber", "Order Number")]
        OrderNumber,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Campaign", "Campaign Name")]
        Campaign,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("StartDate", "Start Date")]
        StartDate,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("EndDate", "End Date")]
        EndDate,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("URL", "URL")]
        URL,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("Instructions", "Instructions")]
        Instructions,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MaterialNotes", "Material Notes")]
        MaterialNotes,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("MiscInfo", "Misc Info")]
        MiscInfo
    }

    public enum SpotRadioResearchReportType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Ranker")]
        Ranker = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Trend")]
        Trend = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Audience Composition")]
        AudienceComposition = 3
    }

    public enum SpotRadioResearchGeography : short
    {
        Metro = 1,
        TSA = 2,
        DMA = 3
    }

    public enum SpotRadioResearchListeningType : short
    {
        Total = 1,
        Home = 2,
        Work = 3,
        Car = 4,
        OutOfHome = 6
    }

    public enum SpotRadioResearchEthnicity : short
    {
        All = 1,
        Black = 2,
        Hispanic = 3
    }

    public enum POP3EmailListenerAccountTypes : short
    {
        Default = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("APINV", "Accounts Payable Invoices")]
        AccountsPayableInvoices = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("ERREC", "Expense Report Receipts")]
        ExpenseReportReceipts = 2
    }

    public enum MediaMetricID : int
    {
        Rating = 1,
        Share = 2,
        Impressions = 3,
        HPUT = 4,
        Intab = 5,
        Universe = 6,
        AQHRating = 7,
        AQH = 8,
        AQHShare = 9,
        CumeRating = 10,
        Cume = 11,
        ExclusiveCume = 12,
        PUR = 13,
        PURPercent = 14,
        StationShareOfCountyPercent = 15,
        CountyShareOfStation = 16,
        HPUT_ = 17,
        HPUTPercent = 18,
        Impressions_ = 19,
        Rating_ = 20,
        Share_ = 21,
        VPVH = 22,
        Universe_ = 23
    }

    public enum AdvantageServiceReportScheduleType : short
    {
        DynamicReport = 1
    }

    public enum AdvantageServiceReportScheduleExportType : short
    {
        CSV = 1,
        XLS = 2,
        XLSX = 3
    }

    public enum AdvantageServiceReportScheduleFrequency : short
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3
    }

    public enum MediaRFPAvailLineStatus
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("P", "Pending")]
        P,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("H", "Hold")]
        H,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("D", "Delete")]
        D,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("T", "Transferred")]
        T
    }

    public enum MediaBroadcastWorksheetPrePostReportCriteriaBuyType : short
    {
        Pre = 0,
        Post = 1
    }

    public enum MediaBroadcastWorksheetBroadcastScheduleReportCriteriaBuyType : short
    {
        Pre = 0,
        Post = 1
    }

    public enum MediaGroupingMetric
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "GRP")]
        GRP = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "IMP")]
        IMP = 1
    }

    public enum MediaRFPStatusID : short
    {
        Generated = 1,
        Received = 2,
        Response = 3,
        Imported = 4,
        WorksheetUpdated = 6
    }

    public enum MediaManagerSearchFilterType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "None")]
        None = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Order Line Date Range")]
        OrderLineDateRange = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Job or Media Date to Bill")]
        JoborMediaDatetoBill = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Media By Month")]
        MediaByMonth = 3
    }

    public enum MediaDemoSourceID : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "Nielsen")]
        Nielsen = 0,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Comscore")]
        Comscore = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Numeris")]
        Numeris = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "OzTAM")]
        OzTAM = 3
    }

    public enum RatingService : int
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Nielsen")]
        Nielsen = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Comscore")]
        Comscore = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Numeris")]
        Numeris = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "OzTAM")]
        OzTAM = 4,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "Eastlan")]
        Eastlan = 5
    }

    public enum BillTypeFlag : short
    {
        CommissionOnly = 1,
        Net = 2,
        Gross = 3
    }

    public enum AlertCategories : short
    {
        ProjectScheduleCreated = 1,
        ProjectScheduleModified = 2,
        JobCreated = 3,
        JobModified = 4,
        JobProcessControlChanged = 5,
        CampaignCreated = 6,
        CampaignModified = 7,
        EstimateCreated = 8,
        EstimateRevised = 9,
        EstimateQuoteApproved = 10,
        EstimateQuoteModified = 11,
        PurchaseOrderCreated = 12,
        PurchaseOrderModified = 13,
        PurchaseOrderVoided = 14,
        JobSpecsCreated = 15,
        JobSpecsRevised = 16,
        MediaInsertionCreated = 17,
        MediaInsertionRevised = 18,
        BillingSelection = 19,
        CreativeBriefCreated = 20,
        CreativeBriefRevised = 21,
        JobSpecsModified = 22,
        JobManualAlert = 23,
        AlertEvent = 24,
        AlertAction = 25,
        AlertDiscussionTopic = 26,
        Review = 27,
        Document = 28,
        File = 29,
        AlertWorkRequest = 30,
        AlertChangeRequest = 31,
        ClientAlertEvent = 32,
        ClientAlertAction = 33,
        ClientAlertDiscussionTopic = 34,
        ClientAlertWorkRequest = 35,
        ClientAlertChangeRequest = 36,
        POApprovalRequest = 38,
        POApprovalResponse = 39,
        BillingApprovalBatchCreated = 40,
        BillingApprovalBatchApproved = 41,
        TaskModified = 42,
        TimesheetApprovalRequest = 43,
        TimesheetApprovalResponse = 44,
        ExpenseReportApprovalRequest = 45,
        ExpenseReportApprovalResponse = 46,
        MissingTimeAlert = 47,
        MissingTimeReportSupervisor = 48,
        Issue = 49,
        HoursChangedForSupervisedEmployee = 50,
        HoursOverbookedForEmployee = 51,
        PastDueTask = 52,
        UpcomingTask = 53,
        QuoteVsActualAlert = 54,
        Call = 55,
        Meeting = 56,
        ToDo = 57,
        CRM = 58,
        UpcomingContractRenewal = 59,
        UpcomingRequiredReport = 60,
        RequiredReportCompleted = 61,
        MediaOceanValidationIssue = 62,
        TaskTempCompleted = 63,
        ImportResults = 64,
        UpcomingVendorContractRenewal = 65,
        ReviewCreated = 66,
        ReviewUpdated = 67,
        MediaInvoiceApprovalRequest = 68,
        MediaInvoiceApprovalResponse = 69,
        Story = 70,
        Task = 71,
        Email = 72,
        RFPGenerated = 73,
        OrderGenerated = 74,
        MediaTrafficGenerated = 75
    }

    public enum AlertTypes : short
    {
        ProjectSchedule = 1,
        Production = 2,
        Approvals = 3,
        Billing = 4,
        Media = 5,
        Alert = 6,
        ClientAlert = 7,
        MissingTime = 8,
        EmployeeTimeForecast = 9,
        Calendar = 10,
        Diary = 11,
        ClientContract = 12,
        ImportValidation = 13,
        VendorContract = 14,
        Review = 15,
        Boards = 16
    }

    public enum TVMediaMetrics : int
    {
        Rating = 1,
        Share = 2,
        Impressions = 3,
        HPUT = 4,
        Intab = 5,
        Universe = 6
    }

    public enum SpotRadioCountyResearchEthnicity : short
    {
        All = 1,
        BlackAndOthers = 2,
        HispanicAndOthers = 3,
        BlackAndHispanicAndOthers = 4
    }

    public enum SpotRadioCountyResearchReportType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Ranker")]
        Ranker = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Trend")]
        Trend = 2
    }

    public enum MediaBroadcastWorksheetPrePostReportCriteriaMediaType : short
    {
        TV = 0,
        Radio = 1
    }

    public enum MediaBroadcastWorksheetRadioEthnicity : short
    {
        All = 1,
        Black = 2,
        Hispanic = 3
    }

    public enum MediaTrafficStatusID : int
    {
        Generated = 1,
        Received = 2,
        Accepted = 3,
        Response = 4
    }

    public enum RadioBand
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("AM", "AM")]
        AM = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("FM", "FM")]
        FM = 2
    }

    public enum TVBand
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("TV", "TV")]
        TV = 1
    }

    public enum NationalResearchReportType : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Program Ranker")]
        ProgramRanker = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Network Ranker")]
        NetworkRanker = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Program Flowchart")]
        ProgramFlowchart = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Network Flowchart")]
        NetworkFlowchart = 4
    }

    public enum NationalResearchReportEthnicity
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("G", "GeneralMarket")]
        G,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("H", "Hispanic")]
        H
    }

    public enum NationalResearchReportTimeType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("P", "Program")]
        P,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("C", "Commercial")]
        C
    }

    public enum NationalResearchReportDateType
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("D", "Dates")]
        D,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("C", "Date Code")]
        C
    }

    public enum NationalResearchReportFlags
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("I", "Ignore")]
        I,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("O", "Only")]
        O,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("E", "Exclude")]
        E
    }

    public enum NationalResearchStream
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LV", "LV")]
        LV,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("LS", "LS")]
        LS,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L1", "L1")]
        L1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L2", "L2")]
        L2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L3", "L3")]
        L3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("L7", "L7")]
        L7
    }

    public enum FiscalMonths
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "January")]
        January,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "February")]
        February,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "March")]
        March,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "April")]
        April,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("5", "May")]
        May,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("6", "June")]
        June,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("7", "July")]
        July,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("8", "August")]
        August,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("9", "September")]
        September,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1O", "October")]
        October,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("11", "November")]
        November,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("12", "December")]
        December
    }

    public enum MediaRFPAvailLineFileSource : short
    {
        Default = 0,
        PRP = 1
    }

    public enum MediaPlanEstimateTemplateQuarterValue : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Q1")]
        Q1 = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Q2")]
        Q2 = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Q3")]
        Q3 = 3,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("4", "Q4")]
        Q4 = 4
    }

    public enum CanadianVendorTypes
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("0", "None")]
        None,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Specialty")]
        Specialty,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Conventional")]
        Conventional
    }

    public enum MediaPlanEstimateTemplateRateTypeValue : short
    {
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("1", "Column/Inch")]
        ColumnInch = 1,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("2", "Line")]
        Line = 2,
        [AdvantageFramework.Core.EnumUtilities.Attributes.EnumObject("3", "Standard")]
        Standard = 3
    }

    #endregion

    #region  Variables 



    #endregion

    #region  Properties 



    #endregion

    #region  Methods 



    #endregion
}
