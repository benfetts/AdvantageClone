Namespace Database.Entities

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum LocationLogoTypes
            HeaderPortrait = 1
            HeaderLandscape = 2
            FooterPortrait = 3
            FooterLandscape = 4
        End Enum

        Public Enum SystemRecordSources
            MediaOcean = 1
        End Enum

        Public Enum DashboardTypes
            MediaPlanning = 1
            MediaPlanning_MasterPlans = 2
            MediaBroadcastWorksheetSetup = 3
            BroadcastResearchTool_TV = 4
            BroadcastResearchTool_Radio = 5
            BroadcastResearchTool_RadioCounty = 6
            RevenueResourcePlanSetup = 7
            RevenueResourcePlanRevenueSetup = 8
            RevenueResourcePlanResourceSetup = 9
            BroadcastResearchTool_National = 10
            BroadcastResearchTool_TVPuertoRico = 4
        End Enum

        Public Enum CycleTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("A", "Annually")>
            Annually
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("D", "Daily")>
            Daily
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Monthly")>
            Monthly
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Q", "Quarterly")>
            Quarterly
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("W", "Weekly")>
            Weekly
        End Enum

        Public Enum MediaPlanDetailTotalsType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Demo 1 GRP/TRP/IMP")>
            Demo1 = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Demo 2 GRP/TRP/IMP")>
            Demo2 = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Dollars")>
            Dollars = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Units")>
            Units = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Rate (STD or CPM)")>
            Rate = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Impressions")>
            Impressions = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Clicks")>
            Clicks = 7
        End Enum

        Public Enum DefaultCurrencySymbols
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("USD", "$")>
            USD
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("GBP", "£")>
            GBP
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("EUR", "€")>
            EUR
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("JPY", "¥")>
            JPY
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("BRL", "R$")>
            BRL
        End Enum

        Public Enum DefaultCurrencyText
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("USD", "Dollars")>
            USD
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("GBP", "Pounds")>
            GBP
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("EUR", "Euros")>
            EUR
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("JPY", "Yen")>
            JPY
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("BRL", "Real")>
            BRL
        End Enum

        Public Enum DefaultCurrencyCoinText
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("USD", "Cents")>
            USD
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("GBP", "Pence")>
            GBP
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("EUR", "Cents")>
            EUR
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("JPY", "Sen")>
            JPY
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("BRL", "Centavos")>
            BRL
        End Enum

        Public Enum ReportMissingTime
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "By Day")>
            ByDay = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By Week")>
            ByWeek = 1
        End Enum

        Public Enum EmployeeHRStatus As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "N/A")>
            NA = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Exempt")>
            Exempt = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Non-Exempt")>
            NonExempt = 2
        End Enum

        Public Enum ClientARAddressSelection
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client Contact")>
            ClientContact = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Client Statement")>
            ClientStatement = 2
        End Enum

        Public Enum ProductARAddressSelection
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Product Contact")>
            ProductContact = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Product Statement")>
            ProductStatement = 2
        End Enum

        Public Enum PostPeriodFormats As Long
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Option 1")>
            MMEqualToCalendarMonth = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Option 2")>
            MMNotEqualToCalendarMonth = 2
        End Enum

        Public Enum PostPeriodFiscalYearFormats As Long
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Fiscal Year Begins in the Previous Calendar Year")>
            FiscalYearBeginsInPreviousCalendarYear = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Fiscal Year Begins in the Current Calendar Year")>
            FiscalYearBeginsInCurrentCalendarYear = 3
        End Enum

        Public Enum PostPeriodStatus
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Current")>
            Current
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("X", "Closed")>
            Closed
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("", "Open")>
            Open
        End Enum

        Public Enum FunctionTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("E", "Employee")>
            E
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Income Only")>
            I
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("V", "Vendor")>
            V
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Client")>
            C
        End Enum

        Public Enum LocationPrintInformation
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Name", "Name")>
            Name
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Street", "Street")>
            Street
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("POBox", "PO Box")>
            POBox
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("City", "City")>
            City
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("State", "State")>
            State
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Zip", "Zip")>
            Zip
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Phone", "Phone")>
            Phone
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Fax", "Fax")>
            Fax
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Email", "Email")>
            Email
        End Enum

        Public Enum InvoiceFormats
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Client", "Client")>
            Client
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Default", "Agency")>
            AgencyDefault
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Custom", "Custom Legacy")>
            Custom
        End Enum

        Public Enum EstimateFormatsClient
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Client", "Client")>
            Client
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Default", "Agency")>
            AgencyDefault
        End Enum

        Public Enum EstimateFormatsProduct
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Product", "Product")>
            Product
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Default", "Agency")>
            AgencyDefault
        End Enum

        Public Enum StandardCommentTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Standard Footer", "Standard Footer")>
            StandardFooter
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Standard Guidelines", "Standard Guidelines")>
            StandardGuidelines
        End Enum

        Public Enum StandardCommentApplications
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Estimates", "Estimates")>
            Estimates
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Purchase Order", "Purchase Order")>
            PurchaseOrder
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Invoices", "Invoices")>
            Invoices
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Media Manager Orders", "Media Manager Orders")>
            MediaManagerOrders
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Media RFP", "Media RFP")>
            MediaRFP
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Invoices Coversheet", "Invoices Coversheet")>
            InvoicesCoversheet
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Media Traffic", "Media Traffic")>
            MediaTraffic
        End Enum

        Public Enum FeeTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Fee Time")>
            FeeTime = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Production Commission")>
            ProductionCommission = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Media Commission")>
            MediaCommission = 3
        End Enum

        Public Enum ExceedEstimateOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Yes")>
            Yes = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Warn")>
            Warn = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "No")>
            No = 2
        End Enum

        Public Enum CampaignTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Overall")>
            Overall = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Assigned To Jobs And Orders")>
            AssignedToJobsAndOrders = 2
        End Enum

        Public Enum CampaignDetailTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Production", "Production")>
            Production
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Media", "Media")>
            Media
        End Enum

        Public Enum MediaImportOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CM", "Core Media")>
            CoreMedia
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MM", "Smart Plus")>
            SmartPlus
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ST", "Strata")>
            Strata
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("TA", "Tapscan")>
            'Tapscan
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PQ", "PERQ")>
            PERQ
        End Enum

        Public Enum ImportFileTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FLAT", "Fixed")>
            Fixed
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("DELIMITED", "Delimited")>
            Delimited
        End Enum

        Public Enum AssignProductionInvoicesBy As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Job")>
            Job = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Job Component")>
            JobComponent = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Product / Sales Class")>
            ProductSalesClass = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Campaign")>
            Campaign = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Purchase Order")>
            PurchaseOrder = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Client")>
            Client = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Division")>
            Division = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Product")>
            Product = 8
        End Enum

        Public Enum Yes1No0 As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Yes")>
            Yes = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "No")>
            No = 0
        End Enum

        Public Enum AssignMediaInvoicesBy
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Sales Class")>
            SalesClass = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Client P.O.")>
            ClientPurchaseOrder = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Market")>
            Market = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Order #")>
            OrderNumber = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Campaign")>
            Campaign = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Order Type")>
            OrderType = 6
        End Enum

        Public Enum MediaType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            Internet
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
            Newspaper
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Outdoor")>
            Outdoor
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
            Magazine
        End Enum

        Public Enum SalesClassMediaType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
            Magazine
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
            Newspaper
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio")>
            Radio
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Television")>
            Television
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Out of Home")>
            OutOfHome
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            Internet
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("P", "Non Media")>
            NonMedia
        End Enum

        Public Enum AssociateMediaType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
            Magazine
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
            Newspaper
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio")>
            Radio
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Television")>
            Television
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Out of Home")>
            OutOfHome
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            Internet
        End Enum

        Public Enum AccountPayableImportMediaType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio")>
            Radio
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Television")>
            Television
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            Internet
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Out of Home")>
            OutOfHome
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
            Newspaper
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
            Magazine
        End Enum

        Public Enum GeneralLedgerAccountTypes
            ExpenseOther = 15
            ExpenseTaxes = 16
            Income_Other = 9
            ExpenseOperating = 14
            ExpenseCOS = 13
            Income = 8
            Equity = 20
            NonCurrentLiability = 4
            CurrentLiability = 5
            FixedAsset = 3
            CurrentAsset = 2
            NonCurrentAsset = 1
        End Enum

        Public Enum AgencyCommentTypes
            AUTO_AR_STATEMENT
        End Enum

        Public Enum UserDefinedLabelTables
            JOB_CMP_TAB
            JOB_CMP_UDV1
            JOB_CMP_UDV2
            JOB_CMP_UDV3
            JOB_CMP_UDV4
            JOB_CMP_UDV5
            JOB_LOG_TAB
            JOB_LOG_UDV1
            JOB_LOG_UDV2
            JOB_LOG_UDV3
            JOB_LOG_UDV4
            JOB_LOG_UDV5
        End Enum

        Public Enum ServiceFeeReconciliationGroupByOptions As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Job")>
            Job = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Job, Component")>
            Job_Component = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Job, Component, Function")>
            Job_Component_Function = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Job, Function")>
            Job_Function = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Campaign")>
            Campaign = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Function")>
            [Function] = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Job, Function Consolidation")>
            [Job_FunctionConsolidation] = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Job, Component, Function Consolidation")>
            [Job_Component_FunctionConsolidation] = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Function Consolidation")>
            [FunctionConsolidation] = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "Job, Function Heading")>
            [Job_FunctionHeading] = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("11", "Job, Component, Function Heading")>
            [Job_Component_FunctionHeading] = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("12", "Function Heading")>
            [FunctionHeading] = 12
        End Enum

        Public Enum ServiceFeeReconciliationSummaryStyles As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Date/Employee")>
            Date_Employee = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Employee")>
            Employee = 2
        End Enum

        Public Enum MarkupTaxFlags As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Markup Not Taxable")>
            MarkupNotTaxable = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Tax Markup")>
            TaxMarkup = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Tax Markup Only")>
            TaxMarkupOnly = 2
        End Enum

        Public Enum FeeTimes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "No")>
            No = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Time Against Fee")>
            TimeAgainstFee = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Time Against Commission (P)")>
            TimeAgainstCommissionP = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Time Against Commission (M)")>
            TimeAgainstCommissionM = 3
        End Enum

        Public Enum PTOTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Vacation")>
            Vacation = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Sick")>
            Sick = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Personal")>
            Personal = 3
        End Enum

        Public Enum PTOActions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Accrue")>
            Accrue = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Replace")>
            Replace = 2
        End Enum

        Public Enum ExpenseReportStatus As Short
            Pending = 0
            Submitted = 1
            Approved = 2
        End Enum

        Public Enum BeforeAfter As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Before")>
            Before = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "After")>
            After = 1
        End Enum

        Public Enum ResourceTaskCondition As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Always Add")>
            AlwaysAdd = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "On Ad Number Change")>
            OnAdNumberChange = 1
        End Enum

        Public Enum POApprovalRuleEmployeeOrder
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "Primary Approver")>
            PrimaryApprover
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("20", "Alternate Approver1")>
            AlternateApprover1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("30", "Alternate Approver2")>
            AlternateApprover2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("40", "Alternate Approver3")>
            AlternateApprover3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("50", "Alternate Approver4")>
            AlternateApprover4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("60", "Alternate Approver5")>
            AlternateApprover5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("70", "Alternate Approver6")>
            AlternateApprover6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("80", "Alternate Approver7")>
            AlternateApprover7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("90", "Alternate Approver8")>
            AlternateApprover8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("100", "Alternate Approver9")>
            AlternateApprover9
        End Enum

        Public Enum RateBy As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Column x Inch")>
            ColumnInch = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Lines")>
            Lines = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Flat Rate")>
            FlatRate = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "CPM")>
            CPM = 4
        End Enum

        Public Enum RateType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Net")>
            Net = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Gross")>
            Gross = 1
        End Enum

        Public Enum DocumentLevel As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Office")>
            Office = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client")>
            Client = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Division")>
            Division = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Product")>
            Product = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Campaign")>
            Campaign = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Job")>
            Job = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Job / Job Component")>
            JobComponent = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "AP Invoice")>
            AccountPayableInvoice = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Ad Number")>
            AdNumber = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Expense Receipts")>
            ExpenseReceipts = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "Employee")>
            Employee = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("11", "Vendor")>
            Vendor = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("12", "Contract")>
            Contract = 12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("13", "Contract Value Added")>
            ContractValueAdded = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("14", "Contract Report")>
            ContractReport = 14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("15", "AR Invoice")>
            AccountReceivableInvoice = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("16", "Agency Desktop")>
            AgencyDesktop = 16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("17", "Executive Desktop")>
            ExecutiveDesktop = 17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("18", "Task")>
            Task = 18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("19", "Vendor Contract")>
            VendorContract = 19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("20", "Alert Attachment")>
            AlertAttachment = 20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("21", "Media Order")>
            MediaOrder = 21
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("22", "Purchase Order")>
            PurchaseOrder = 22
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("23", "Media Traffic Detail")>
            MediaTrafficDetail = 23
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("24", "Journal Entry")>
            JournalEntry = 24
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("25", "Media Plan")>
            MediaPlan = 25
        End Enum

        Public Enum DocumentSubLevel As Short
            [Default]
            ExpenseDetailDocument
            'ExpenseDocumentOnly
        End Enum

        Public Enum DesktopObjectTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Agency Desktop")>
            AgencyDesktop = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Executive Desktop")>
            ExecutiveDesktop = 1
        End Enum

        Public Enum VendorCategory
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("P", "Production")>
            NonMedia
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
            Magazine
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
            Newspaper
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio")>
            Radio
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Television")>
            Television
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Out of Home")>
            OutOfHome
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            Internet
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Z", "Non Client")>
            NonClient
        End Enum

        ''' <remarks>Use for Vendor Import Only</remarks>
        Public Enum ImportVendorCategories
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("P", "Production & Operating")>
            P
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine Media")>
            M
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper Media")>
            N
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio Media")>
            R
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "TV Media")>
            T
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Out-of-Home")>
            O
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            I
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Z", "Non Client")>
            Z
        End Enum

        Public Enum ACHType
            CCD
            CTX
            PPD
        End Enum

        Public Enum DocumentUploadType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("D", "File / Document")>
            Document
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L", "Link")>
            Link
        End Enum

        Public Enum AlertPriority As Short
            Highest = 1
            High = 2
            Normal = 3
            Low = 4
            Lowest = 5
        End Enum

        Public Enum ExpenseItemPaymentType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Corporate Credit Card")>
            CorporateCreditCard = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Personal Credit Card")>
            PersonalCreditCard = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Cash")>
            Cash = 2
        End Enum

        Public Enum AssociateLevel As Short
            Client = 0
            Product = 1
        End Enum

        Public Enum JobTemplateItemCategory As Short
            All
            Fields
            SystemRequired
        End Enum

        Public Enum JobSpecFields
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_1", "Single (1) character text")>
            CHAR1_1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_2", "Single (1) character text")>
            CHAR1_2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_3", "Single (1) character text")>
            CHAR1_3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_4", "Single (1) character text")>
            CHAR1_4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_5", "Single (1) character text")>
            CHAR1_5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_6", "Single (1) character text")>
            CHAR1_6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_7", "Single (1) character text")>
            CHAR1_7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_8", "Single (1) character text")>
            CHAR1_8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_9", "Single (1) character text")>
            CHAR1_9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_10", "Single (1) character text")>
            CHAR1_10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_11", "Single (1) character text")>
            CHAR1_11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_12", "Single (1) character text")>
            CHAR1_12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_13", "Single (1) character text")>
            CHAR1_13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_14", "Single (1) character text")>
            CHAR1_14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_15", "Single (1) character text")>
            CHAR1_15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_16", "Single (1) character text")>
            CHAR1_16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_17", "Single (1) character text")>
            CHAR1_17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_18", "Single (1) character text")>
            CHAR1_18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_19", "Single (1) character text")>
            CHAR1_19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR1_20", "Single (1) character text")>
            CHAR1_20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_1", "Ten (10) character text")>
            CHAR10_1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_2", "Ten (10) character text")>
            CHAR10_2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_3", "Ten (10) character text")>
            CHAR10_3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_4", "Ten (10) character text")>
            CHAR10_4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_5", "Ten (10) character text")>
            CHAR10_5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_6", "Ten (10) character text")>
            CHAR10_6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_7", "Ten (10) character text")>
            CHAR10_7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_8", "Ten (10) character text")>
            CHAR10_8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_9", "Ten (10) character text")>
            CHAR10_9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_10", "Ten (10) character text")>
            CHAR10_10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_11", "Ten (10) character text")>
            CHAR10_11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_12", "Ten (10) character text")>
            CHAR10_12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_13", "Ten (10) character text")>
            CHAR10_13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_14", "Ten (10) character text")>
            CHAR10_14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_15", "Ten (10) character text")>
            CHAR10_15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_16", "Ten (10) character text")>
            CHAR10_16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_17", "Ten (10) character text")>
            CHAR10_17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_18", "Ten (10) character text")>
            CHAR10_18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_19", "Ten (10) character text")>
            CHAR10_19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR10_20", "Ten (10) character text")>
            CHAR10_20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_1", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_2", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_3", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_4", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_5", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_6", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_7", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_8", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_9", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR254_10", "Two-hundred Fifty-Four (254) character text")>
            CHAR254_10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_1", "Fifty (50) character text")>
            CHAR50_1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_2", "Fifty (50) character text")>
            CHAR50_2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_3", "Fifty (50) character text")>
            CHAR50_3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_4", "Fifty (50) character text")>
            CHAR50_4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_5", "Fifty (50) character text")>
            CHAR50_5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_6", "Fifty (50) character text")>
            CHAR50_6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_7", "Fifty (50) character text")>
            CHAR50_7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_8", "Fifty (50) character text")>
            CHAR50_8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_9", "Fifty (50) character text")>
            CHAR50_9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_10", "Fifty (50) character text")>
            CHAR50_10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_11", "Fifty (50) character text")>
            CHAR50_11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_12", "Fifty (50) character text")>
            CHAR50_12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_13", "Fifty (50) character text")>
            CHAR50_13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_14", "Fifty (50) character text")>
            CHAR50_14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_15", "Fifty (50) character text")>
            CHAR50_15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_16", "Fifty (50) character text")>
            CHAR50_16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_17", "Fifty (50) character text")>
            CHAR50_17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_18", "Fifty (50) character text")>
            CHAR50_18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_19", "Fifty (50) character text")>
            CHAR50_19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CHAR50_20", "Fifty (50) character text")>
            CHAR50_20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_1", "Numeric whole (-999999999 to 999999999)")>
            INT_1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_2", "Numeric whole (-999999999 to 999999999)")>
            INT_2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_3", "Numeric whole (-999999999 to 999999999)")>
            INT_3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_4", "Numeric whole (-999999999 to 999999999)")>
            INT_4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_5", "Numeric whole (-999999999 to 999999999)")>
            INT_5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_6", "Numeric whole (-999999999 to 999999999)")>
            INT_6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_7", "Numeric whole (-999999999 to 999999999)")>
            INT_7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_8", "Numeric whole (-999999999 to 999999999)")>
            INT_8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_9", "Numeric whole (-999999999 to 999999999)")>
            INT_9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_10", "Numeric whole (-999999999 to 999999999)")>
            INT_10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_11", "Numeric whole (-999999999 to 999999999)")>
            INT_11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_12", "Numeric whole (-999999999 to 999999999)")>
            INT_12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_13", "Numeric whole (-999999999 to 999999999)")>
            INT_13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_14", "Numeric whole (-999999999 to 999999999)")>
            INT_14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_15", "Numeric whole (-999999999 to 999999999)")>
            INT_15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_16", "Numeric whole (-999999999 to 999999999)")>
            INT_16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_17", "Numeric whole (-999999999 to 999999999)")>
            INT_17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_18", "Numeric whole (-999999999 to 999999999)")>
            INT_18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_19", "Numeric whole (-999999999 to 999999999)")>
            INT_19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("INT_20", "Numeric whole (-999999999 to 999999999)")>
            INT_20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_1", "Numeric whole (0 to 999)")>
            SMALLINT_1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_2", "Numeric whole (0 to 999)")>
            SMALLINT_2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_3", "Numeric whole (0 to 999)")>
            SMALLINT_3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_4", "Numeric whole (0 to 999)")>
            SMALLINT_4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_5", "Numeric whole (0 to 999)")>
            SMALLINT_5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_6", "Numeric whole (0 to 999)")>
            SMALLINT_6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_7", "Numeric whole (0 to 999)")>
            SMALLINT_7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_8", "Numeric whole (0 to 999)")>
            SMALLINT_8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_9", "Numeric whole (0 to 999)")>
            SMALLINT_9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_10", "Numeric whole (0 to 999)")>
            SMALLINT_10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_11", "Numeric whole (0 to 999)")>
            SMALLINT_11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_12", "Numeric whole (0 to 999)")>
            SMALLINT_12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_13", "Numeric whole (0 to 999)")>
            SMALLINT_13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_14", "Numeric whole (0 to 999)")>
            SMALLINT_14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_15", "Numeric whole (0 to 999)")>
            SMALLINT_15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_16", "Numeric whole (0 to 999)")>
            SMALLINT_16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_17", "Numeric whole (0 to 999)")>
            SMALLINT_17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_18", "Numeric whole (0 to 999)")>
            SMALLINT_18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_19", "Numeric whole (0 to 999)")>
            SMALLINT_19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SMALLINT_20", "Numeric whole (0 to 999)")>
            SMALLINT_20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_1", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_2", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_3", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_4", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_5", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_6", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_7", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_8", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_9", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_10", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_11", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_12", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_13", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_14", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_15", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_16", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_17", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_18", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_19", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TEXT_20", "Thirty-Two Thousand (32,000) character memo")>
            TEXT_20
        End Enum

        Public Enum VendorEEOCStatus 'also see table VENDOR_EEOC_STATUS
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Other than Small Business")>
            OtherThanSmallBusiness
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SB", "Small Business")>
            SmallBusinessConcern
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SDB", "Small Disadvantaged Business")>
            SmallDisadvantagedBusiness
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("WOSB", "Woman Owned Small Business")>
            WomenOwnedSmallBusiness
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("WOB", "Woman Owned Business")>
            WomenOwnedBusiness
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MO", "Minority Owned Business")>
            MinorityOwned
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("OT", "Other")>
            Other
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("VOSB", "Veteran Owned Business")>
            VeteranOwnedSmallBusiness
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("HZSB", "HUBZone Small Business")>
            HUBZoneSmallBusiness
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MISC1", "Miscellaneous Category 1")>
            MiscellaneousCategory1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MISC2", "Miscellaneous Category 2")>
            MiscellaneousCategory2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MISC3", "Miscellaneous Category 3")>
            MiscellaneousCategory3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Individual Owned")>
            IndividualOwned
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Not an EEOC vendor")>
            NotAnEEOCVendor
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LGBT", "LGBT Owned")>
            LGBT
        End Enum

        Public Enum VendorEEOC2Ethnicity As Short 'also see table VENDOR_EEOC2_ETHNICITY
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "White")>
            White = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "African American")>
            AfricanAmerican = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Hispanic")>
            Hispanic = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Asian American")>
            AsianAmerican = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Asian Subcontinent American")>
            AsianSubcontinentAmerican = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Native American")>
            NativeAmerican = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Multi-Racial")>
            MultiRacial = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Unknown")>
            Unknown = 8
        End Enum

        Public Enum Vendor1099Category
            NonEmployeeCompensation = 0
            OtherIncome = 1
            Rent = 2
            Royalties = 3
            GrossProceedsToAttorney = 4
            MedicalAndHealthCare = 5
        End Enum

        Public Enum VendorMediaDefaultUnits
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Monthly")>
            M
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("BM", "BroadcastMonth")>
            BM
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("W", "Weekly")>
            W
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CM", "CalendarMonth")>
            CM
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("D", "Daily")>
            D
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "4 Week")>
            F
        End Enum

        Public Enum MediaApprovalStatus As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Pending Approval")>
            PendingApproval = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Approved")>
            Approved = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Approved With Changes")>
            ApprovedWithChanges = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Approval Not Required")>
            ApprovalNotRequired = 0
        End Enum

        Public Enum MediaApprovalStatusPendingOnly As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Pending Approval")>
            PendingApproval = 1
        End Enum

        Public Enum PartnerAllocationType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Campaign")>
            Campaign
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Order")>
            Order
        End Enum

        Public Enum MediaOrderType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Television")>
            Television
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio")>
            Radio
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
            Internet
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
            Magazine
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
            Newspaper
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Out of Home")>
            OutOfHome
        End Enum

        Public Enum SearchAllParameters

            EmployeeCode
            UserCode
            SearchTerm

            ExactSearch

            JobsOpen
            JobsClosed
            JobsDescription
            JobsComments

            AlertsStandard
            AlertsAssignments
            AlertsSubject
            AlertsDescription
            AlertsOpen
            AlertsDismissedCompleted

            ScheduleComments
            ScheduleIncludeClosed

            ScheduleTaskIncludeClosed
            ScheduleTaskDescription
            ScheduleTaskFunctionComments
            ScheduleTaskDueDateComments
            ScheduleTaskRevisionDateComments

            EstimateDescription
            EstimateComments
            EstimateFooterComments
            EstimateComponentDescription
            EstimateComponentComments
            EstimateQuoteDetailComments
            EstimateQuoteDetailDescription

            CampaignComments

            PurchaseOrderDescription
            PurchaseOrderMainInstruction
            PurchaseOrderDeliveryInstruction
            PurchaseOrderDetailDescription
            PurchaseOrderDetailLineDescription
            PurchaseOrderDetailInstruction

            ClientPortal
            ClientPortalID

            JobRequests

        End Enum

        Public Enum AccountGroupTypes As Short
            FullAccountCode = 1
            BaseAccountCode = 2
        End Enum

        Public Enum AccountAllocationTypes As Short
            Percentage = 1
            SquareFootage = 2
            NumberOfEmployees = 3
        End Enum

        Public Enum VCCStatuses As Short
            Accepted = 1
            Declined = 2
        End Enum

        Public Enum CostType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NA", "NA")>
            NA
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPM", "CPM")>
            CPM
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPC", "CPC")>
            CPC
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPA", "CPA")>
            CPA
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPI", "CPI")>
            CPI
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPL", "CPL")>
            CPL
        End Enum

        Public Enum BroadcastDaysToBillTimeframe As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Before Broadcast Date")>
            BeforeBroadcastDate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "After Broadcast Date")>
            AfterBroadcastDate = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Before Close Date")>
            BeforeCloseDate = 3
        End Enum

        Public Enum PrintDaysToBillTimeframe As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Before Insertion Date")>
            BeforeInsertionDate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "After Insertion Date")>
            AfterInsertionDate = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Before Close Date")>
            BeforeCloseDate = 3
        End Enum

        Public Enum InternetDaysToBillTimeframe As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Before Run Date")>
            BeforeRunDate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "After Run Date")>
            AfterRunDate = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Before Close Date")>
            BeforeCloseDate = 3
        End Enum

        Public Enum OutofHomeDaysToBillTimeframe As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Before Post Date")>
            BeforePostDate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "After Post Date")>
            AfterPostDate = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Before Close Date")>
            BeforeCloseDate = 3
        End Enum

        Public Enum MediaPrebillPostbill As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Prebill")>
            Prebill = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Post Bill")>
            PostBill = 2
        End Enum

        Public Enum AccountReceivableRecordType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Media")>
            M
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("P", "Production")>
            P
        End Enum

        Public Enum TrafficScheduleBy As Short
            StartDate = 1
            DueDate = 0
        End Enum

        Public Enum BillingApprovalBatchApprovalRollupParameter

            JobNumber
            JobComponentNumber
            CampaignIdentifier
            RollupType
            BillingApprovalID
            BillingApprovalBatchID
            TempCutoffDate
            TempCutoffFunctionType

        End Enum

        Public Enum BillingApprovalBatchApprovalRollupType

            Job = 0
            Campaign = 1

        End Enum

        Public Enum DayPartTypeID As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Local TV")>
            Local_TV = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Local Radio")>
            Local_Radio = 2
        End Enum

        Public Enum MediaATBBillingMethod
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Full Flight")>
            FullFlight = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By Month (Split by Month)")>
            ByMonth = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Bill per Instructions")>
            BillPerInstructions = 2
        End Enum

        Public Enum GeneralLedgerConfigSegmentType As Short
            Base = 1
            Office = 2
            Department = 3
            Other = 4
        End Enum

        Public Enum GeneralLedgerConfigSegmentAfter As Short
            Hyphen = 1
            Period = 2
        End Enum

        Public Enum GridAdvantageType As Integer
            BillingCommandCenterProductionReview = 1
            BillingCommandCenterJobComponentFunctionDetail = 2
            BillingCommandCenterMediaReview = 3
            EmployeeTimesheet = 4
            AccountsPayableImport = 5
            BillingCommandCenterProcessControl = 6
            BillingCommandCenterBillHold = 7
            BillingCommandCenterReconcileRecognize = 8
            BillingCommandCenterJobComponentEmployeeTimeDetail = 9
            BillingCommandCenterJobComponentIncomeOnlyDetail = 10
            BillingCommandCenterJobComponentVendorDetail = 11
            BillingCommandCenterJobDetailJobComponent = 12
            MediaManagerMediaManagerReviewOrderDetail = 13
            MediaManagerMediaManagerReviewVCCOrderDetail = 14
            MediaManagerOrderProcessControl = 15
            BillingCommandCenterJobComponentOpenPODetail = 16
            MediaResults = 17
            MediaBroadcastWorksheet = 18
            MediaPlanningSetupEstimates = 19
            MediaPlanningSetup = 20
            DigitalCampaignManagerOpenPlanEstimates = 21
            DigitalCampaignManagerEstimateDetailByFlight = 22
            DigitalCampaignManagerEstimateDetailByPeriod = 23
            MediaBroadcastWorksheetMakegoodOffers = 24
        End Enum

        Public Enum MediaATBOrderOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Create orders with Ad Serving as a Net Charge")>
            AdServingAsNetCharge = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Create orders with Ad Serving as a line on each Vendor's order")>
            AdServingOnEachVendorOrder = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Create separate order for Ad Serving")>
            SeparateForAdServing = 2
        End Enum

        Public Enum AlertListLevel

            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "No Level")>
            NotSet = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Media ATB")>
            MediaATB = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Estimate")>
            Estimate = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Estimate Component")>
            EstimateComponent = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Estimate Quote")>
            EstimateQuote = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Project Schedule")>
            ProjectSchedule = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Project Schedule Task")>
            ProjectScheduleTask = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Campaign")>
            Campaign = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Job")>
            Job = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Job Component")>
            JobComponent = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "Accounts Payable")>
            AccountsPayable = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("11", "Purchase Order")>
            PurchaseOrder = 11

        End Enum
        Public Enum AlertListShowAlertType

            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "All Alerts & Assignments")>
            AllAlertsAndAssignments = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "All Alerts")>
            AllAlerts = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "My Assignments")>
            MyAssignments = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "All Assignments")>
            AllAssignments = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Unassigned")>
            Unassigned = 4

        End Enum
        Public Enum AlertListGrouping

            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Category")>
            Category = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Office")>
            Office = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Client")>
            Client = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Division")>
            Division = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Product")>
            Product = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Campaign")>
            Campaign = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Estimate")>
            Estimate = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Estimate Component")>
            EstimateComponent = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Job")>
            Job = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "Job Component")>
            JobComponent = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("11", "Task")>
            Task = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("12", "Template")>
            Template = 12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("13", "State")>
            State = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("14", "Due Date")>
            DueDate = 14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("15", "Priority")>
            Priority = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("16", "Authorization To Buy")>
            AuthorizationToBuy = 16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("17", "Level")>
            Level = 17

        End Enum

        Public Enum ServiceFeeFrequency As Short
            Weekly = 1
            Monthly = 2
            Annually = 3
        End Enum

        Public Enum VendorServiceTaxType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "PR Resident")>
            PRResident = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "US Resident")>
            USResident = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Non-US Resident")>
            NonUSResident = 3
        End Enum

        Public Enum AvaTaxAddressValidationCountries
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("US", "US")>
            US
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CA", "Canada")>
            Canada
        End Enum

        Public Enum ProductionAdvancedBillingIncome As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Upon Reconciliation")>
            UponReconciliation = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Initial Billing")>
            InitialBilling = 2
        End Enum

        Public Enum MediaAdvancedBillingIncome
            BillingDate = 1
            InsertionBroadcast = 2
            CloseDate = 3
        End Enum

        Public Enum AdvanceBillingCalculateMethod
            PercentToDate = 1
            ManualEntry = 4
        End Enum

        Public Enum PaymentManagerACHServiceClassCode As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("200", "200")>
            [Code200] = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("220", "220")>
            [Code220] = 2
        End Enum

        Public Enum PaymentManagerACHStandardEntryClassCode As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PPD", "PPD")>
            [PPD] = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CCD", "CCD")>
            [CCD] = 2
        End Enum

        Public Enum DefaultCorrespondenceMethods As Short
            [Email] = 1
            [Print] = 2
        End Enum

        Public Enum AssignComboInvoicesBy As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("21", "Client")>
            Client = 21
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("22", "ClientDivisionProduct")>
            ClientDivisionProduct = 22
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("23", "ClientCampaign")>
            ClientCampaign = 23
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("24", "ClientDivisionProductCampaign")>
            ClientDivisionProductCampaign = 24
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("25", "ClientDivision")>
            ClientDivision = 25
        End Enum

        Public Enum OrderStatusType As Short
            Pending = 0
            Printed = 1
            QuoteGenerated = 2
            QuoteAccepted = 3
            OrderGenerated = 4
            OrderAccepted = 5
            MaterialsDelivered = 6
            MaterialDeliveryVerified = 7
            CancellationGenerated = 8
            CancellationAccepted = 9
            CostCollected = 10
            ApprovedForBilling = 11
            QuoteRecieved = 12
            OrderRecieved = 13
            CancellationRecieved = 14
            OrderRejected = 15
            MakegoodOfferSubmitted = 16
            MakegoodOfferRejected = 17
            MakegoodOfferAccepted = 18
            ModifiedPendingCreate = 19
            ModifiedPendingGenerate = 20
        End Enum

        Public Enum VCCStatus
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("A", "Active")>
            Active
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("B", "Blocked")>
            Blocked
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Cancelled")>
            Cancelled
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("H", "Hold")>
            Hold
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("S", "Stolen")>
            Stolen
        End Enum

        Public Enum VCCAction
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Credit Card Request")>
            CreditCardRequest = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Credit Card Update")>
            CreditCardUpdate = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Pending Transaction")>
            PendingTransaction = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Cleared Transaction")>
            ClearedTransaction = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Rejected Transaction")>
            RejectedTransaction = 5
        End Enum

        Public Enum NewspaperCostRate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPISTD", "Column/Inch (STD)")>
            CPISTD
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPLSTD", "Lines (STD)")>
            CPLSTD
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPMSTD", "Circulation/QTY (STD)")>
            CPMSTD
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPMCPM", "Circulation/QTY (CPM)")>
            CPMCPM
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NA STD", "N/A (STD)")>
            NA_STD
        End Enum

        Public Enum InternetCostType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPM", "CPM")>
            CPM
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPC", "CPC")>
            CPC
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CPA", "CPA")>
            CPA
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NA", "N/A")>
            NA
        End Enum

        Public Enum DocumentSearchCriteria

            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "[All Criteria]")>
            AllCriteria = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "[No Criteria]")>
            NoCriteria = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Client")>
            Client = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Client/Division/Product")>
            ClientDivisionProduct = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Client Contract")>
            ClientContract = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Department")>
            Department = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Division")>
            Division = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Employee")>
            Employee = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Function Code")>
            FunctionCode = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "Job")>
            Job = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("11", "Job Component")>
            JobComponent = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("12", "Media Order/Line")>
            MediaOrderLine = 12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("13", "Office")>
            Office = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("14", "Product")>
            Product = 14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("15", "Vendor")>
            Vendor = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("16", "Alert Subject")>
            AlertSubject = 16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("17", "Campaign")>
            Campaign = 17

        End Enum

        Public Enum PTOImportStatus As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Approved")>
            Approved = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Cancelled")>
            Cancelled = 2
        End Enum

        Public Enum ConceptShareBaseReviewType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Collaborative")>
            Collaborative = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "WorkFlow")>
            WorkFlow = 2
        End Enum

        Public Enum AdjustCheckBodyLinesDn

            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("-1", "[Agency Default]")>
            AgencyDefault
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "0")>
            Zero
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "1")>
            One
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "2")>
            Two

        End Enum

        Public Enum AdjustCheckStubLinesUp

            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("-1", "[Agency Default]")>
            AgencyDefault
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "0")>
            Zero
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "1")>
            One

        End Enum

        Public Enum NielsenDataStream
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LO", "Live Only")>
            LO
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LS", "Live + Same Day")>
            LS
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L1", "Live + 1")>
            L1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L3", "Live + 3")>
            L3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L7", "Live + 7")>
            L7
        End Enum

        Public Enum NielsenService
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "NSI")>
            NSI
        End Enum

        Public Enum NielsenSampleType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "DMA")>
            DMA
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Hardwired")>
            Hardwired
        End Enum

        Public Enum AdServerID As Integer
            DoubleClick = 1
        End Enum

        Public Enum NielsenTimeType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Commercial")>
            Commercial
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("P", "Program")>
            Program
        End Enum

        Public Enum NielsenNationalDataStream
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L1", "Live + 1")>
            L1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L2", "Live + 2")>
            L2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L3", "Live + 3")>
            L3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L7", "Live + 7")>
            L7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LV", "Live")>
            LV
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LS", "Live + Same Day")>
            LS
        End Enum

        Public Enum NielsenRadioGeoIndicator As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Metro")>
            Metro = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "TSA")>
            TSA = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "DMA")>
            DMA = 3
        End Enum

        Public Enum NielsenRadioListeningLocation
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Total (Home & Away)")>
            Total = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "In Home (PPM & Nationwide PPM/Diary Combo)")>
            InHome = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Away - At Work (Diary Only)")>
            Away1 = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Away - In Car (Diary Only)")>
            Away2 = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Away - Other (Diary Only - not used at this time)")>
            Away3 = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Out of Home (PPM & Nationwide PPM/Diary Combo))")>
            OutofHome = 6
        End Enum

        Public Enum NielsenRadioStationComboType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Individual Station")>
            IndividualStation = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Simulcast Group")>
            SimulcastGroup = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Network Group")>
            NetworkGroup = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "X-Codes (Nationwide only) Or Non-commercial")>
            XCodes = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Over the Air Internet Stream from Log Files (IAS only)")>
            OTA = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "eRadio station (IAS only)")>
            eRadio = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Market Total Listening (TOTA) PPM -Specific")>
            MarketTotal = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Persons Uing Measured Media (PUMM)")>
            PUMM = 9
        End Enum

        Public Enum DoubleClickReportRelativeDateRange
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LAST_24_MONTHS", "Last 24 Months")>
            LAST_24_MONTHS
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LAST_30_DAYS", "Last 30 Days")>
            LAST_30_DAYS
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LAST_365_DAYS", "Last 365 Days")>
            LAST_365_DAYS
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LAST_7_DAYS", "Last 7 Days")>
            LAST_7_DAYS
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LAST_90_DAYS", "Last 90 Days")>
            LAST_90_DAYS
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MONTH_TO_DATE", "Month to Date")>
            MONTH_TO_DATE
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PREVIOUS_MONTH", "Previous Month")>
            PREVIOUS_MONTH
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PREVIOUS_QUARTER", "Previous Quarter")>
            PREVIOUS_QUARTER
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PREVIOUS_WEEK", "Previous Week")>
            PREVIOUS_WEEK
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PREVIOUS_YEAR", "Previous Year")>
            PREVIOUS_YEAR
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("QUARTER_TO_DATE", "Quarter to Date")>
            QUARTER_TO_DATE
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TODAY", "Today")>
            TODAY
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("WEEK_TO_DATE", "Week to Date")>
            WEEK_TO_DATE
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("YEAR_TO_DATE", "Year to Date")>
            YEAR_TO_DATE
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("YESTERDAY", "Yesterday")>
            YESTERDAY
        End Enum

        Public Enum SpotTVResearchReportType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Ranker")>
            Ranker = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Trend by Book")>
            TrendByBook = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Trend by Station")>
            TrendByStation = 3
        End Enum

        Public Enum AdServerPlacementNameFields
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MarketName", "Market Name")>
            MarketName
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("VendorName", "Vendor Name")>
            VendorName
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("RateType", "Rate Type")>
            RateType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Headline", "Headline")>
            Headline
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CreativeSizeDescription", "Creative Size Description")>
            CreativeSizeDescription
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("InternetTypeDescription", "Internet Type Description")>
            InternetTypeDescription
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Placement", "Placement")>
            Placement
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TargetAudience", "Target Audience")>
            TargetAudience
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("OrderNumber", "Order Number")>
            OrderNumber
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Campaign", "Campaign Name")>
            Campaign
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("StartDate", "Start Date")>
            StartDate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("EndDate", "End Date")>
            EndDate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("URL", "URL")>
            URL
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Instructions", "Instructions")>
            Instructions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MaterialNotes", "Material Notes")>
            MaterialNotes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MiscInfo", "Misc Info")>
            MiscInfo
        End Enum

        Public Enum SpotRadioResearchReportType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Ranker")>
            Ranker = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Trend")>
            Trend = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Audience Composition")>
            AudienceComposition = 3
        End Enum

        Public Enum SpotRadioResearchGeography As Short
            Metro = 1
            TSA = 2
            DMA = 3
        End Enum

        Public Enum SpotRadioResearchListeningType As Short
            Total = 1
            Home = 2
            Work = 3
            Car = 4
            OutOfHome = 6
        End Enum

        Public Enum SpotRadioResearchEthnicity As Short
            All = 1
            Black = 2
            Hispanic = 3
        End Enum

        Public Enum POP3EmailListenerAccountTypes As Short
            [Default] = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("APINV", "Accounts Payable Invoices")>
            AccountsPayableInvoices = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ERREC", "Expense Report Receipts")>
            ExpenseReportReceipts = 2
        End Enum

        Public Enum MediaMetricID As Integer
            Rating = 1
            Share = 2
            Impressions = 3
            HPUT = 4
            Intab = 5
            Universe = 6
            AQHRating = 7
            AQH = 8
            AQHShare = 9
            CumeRating = 10
            Cume = 11
            ExclusiveCume = 12
            PUR = 13
            PURPercent = 14
            StationShareOfCountyPercent = 15
            CountyShareOfStation = 16
            HPUT_ = 17
            HPUTPercent = 18
            Impressions_ = 19
            Rating_ = 20
            Share_ = 21
            VPVH = 22
            Universe_ = 23
        End Enum

        Public Enum AdvantageServiceReportScheduleType As Short
            DynamicReport = 1
        End Enum

        Public Enum AdvantageServiceReportScheduleExportType As Short
            CSV = 1
            XLS = 2
            XLSX = 3
        End Enum

        Public Enum AdvantageServiceReportScheduleFrequency As Short
            Daily = 1
            Weekly = 2
            Monthly = 3
        End Enum

        Public Enum MediaRFPAvailLineStatus
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("P", "Pending")>
            P
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("H", "Hold")>
            H
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("D", "Delete")>
            D
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Transferred")>
            T
        End Enum

        Public Enum MediaBroadcastWorksheetPrePostReportCriteriaBuyType As Short
            Pre = 0
            Post = 1
        End Enum

        Public Enum MediaBroadcastWorksheetBroadcastScheduleReportCriteriaBuyType As Short
            Pre = 0
            Post = 1
        End Enum

        Public Enum MediaGroupingMetric
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "GRP")>
            GRP = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "IMP")>
            IMP = 1
        End Enum

        Public Enum MediaRFPStatusID As Short
            Generated = 1
            Received = 2
            Response = 3
            Imported = 4
            WorksheetUpdated = 6
        End Enum

        Public Enum MediaManagerSearchFilterType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Order Line Date Range")>
            OrderLineDateRange = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Job or Media Date to Bill")>
            JoborMediaDatetoBill = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Media By Month")>
            MediaByMonth = 3
        End Enum

        Public Enum MediaDemoSourceID As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Nielsen")>
            Nielsen = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Comscore")>
            Comscore = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Numeris")>
            Numeris = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "OzTAM")>
            OzTAM = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Nielsen Puerto Rico")>
            NielsenPuertoRico = 4
        End Enum

        Public Enum RatingService As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Nielsen")>
            Nielsen = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Comscore")>
            Comscore = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Numeris")>
            Numeris = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "OzTAM")>
            OzTAM = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Eastlan")>
            Eastlan = 5
        End Enum

        Public Enum BillTypeFlag As Short
            CommissionOnly = 1
            Net = 2
            Gross = 3
        End Enum

        Public Enum AlertCategories As Short
            ProjectScheduleCreated = 1
            ProjectScheduleModified = 2
            JobCreated = 3
            JobModified = 4
            JobProcessControlChanged = 5
            CampaignCreated = 6
            CampaignModified = 7
            EstimateCreated = 8
            EstimateRevised = 9
            EstimateQuoteApproved = 10
            EstimateQuoteModified = 11
            PurchaseOrderCreated = 12
            PurchaseOrderModified = 13
            PurchaseOrderVoided = 14
            JobSpecsCreated = 15
            JobSpecsRevised = 16
            MediaInsertionCreated = 17
            MediaInsertionRevised = 18
            BillingSelection = 19
            CreativeBriefCreated = 20
            CreativeBriefRevised = 21
            JobSpecsModified = 22
            JobManualAlert = 23
            AlertEvent = 24
            AlertAction = 25
            AlertDiscussionTopic = 26
            Review = 27
            Document = 28
            File = 29
            AlertWorkRequest = 30
            AlertChangeRequest = 31
            ClientAlertEvent = 32
            ClientAlertAction = 33
            ClientAlertDiscussionTopic = 34
            ClientAlertWorkRequest = 35
            ClientAlertChangeRequest = 36
            POApprovalRequest = 38
            POApprovalResponse = 39
            BillingApprovalBatchCreated = 40
            BillingApprovalBatchApproved = 41
            TaskModified = 42
            TimesheetApprovalRequest = 43
            TimesheetApprovalResponse = 44
            ExpenseReportApprovalRequest = 45
            ExpenseReportApprovalResponse = 46
            MissingTimeAlert = 47
            MissingTimeReportSupervisor = 48
            Issue = 49
            HoursChangedForSupervisedEmployee = 50
            HoursOverbookedForEmployee = 51
            PastDueTask = 52
            UpcomingTask = 53
            QuoteVsActualAlert = 54
            [Call] = 55
            Meeting = 56
            ToDo = 57
            CRM = 58
            UpcomingContractRenewal = 59
            UpcomingRequiredReport = 60
            RequiredReportCompleted = 61
            MediaOceanValidationIssue = 62
            TaskTempCompleted = 63
            ImportResults = 64
            UpcomingVendorContractRenewal = 65
            ReviewCreated = 66
            ReviewUpdated = 67
            MediaInvoiceApprovalRequest = 68
            MediaInvoiceApprovalResponse = 69
            Story = 70
            Task = 71
            Email = 72
            RFPGenerated = 73
            OrderGenerated = 74
            MediaTrafficGenerated = 75
        End Enum

        Public Enum AlertTypes As Short
            ProjectSchedule = 1
            Production = 2
            Approvals = 3
            Billing = 4
            Media = 5
            Alert = 6
            ClientAlert = 7
            MissingTime = 8
            EmployeeTimeForecast = 9
            Calendar = 10
            Diary = 11
            ClientContract = 12
            ImportValidation = 13
            VendorContract = 14
            Review = 15
            Boards = 16
        End Enum

        Public Enum TVMediaMetrics As Integer
            Rating = 1
            Share = 2
            Impressions = 3
            HPUT = 4
            Intab = 5
            Universe = 6
        End Enum

        Public Enum SpotRadioCountyResearchEthnicity As Short
            All = 1
            BlackAndOthers = 2
            HispanicAndOthers = 3
            BlackAndHispanicAndOthers = 4
        End Enum

        Public Enum SpotRadioCountyResearchReportType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Ranker")>
            Ranker = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Trend")>
            Trend = 2
        End Enum

        Public Enum MediaBroadcastWorksheetPrePostReportCriteriaMediaType As Short
            TV = 0
            Radio = 1
        End Enum

        Public Enum MediaBroadcastWorksheetRadioEthnicity As Short
            All = 1
            Black = 2
            Hispanic = 3
        End Enum

        Public Enum MediaTrafficStatusID As Integer
            Generated = 1
            Received = 2
            Accepted = 3
            Response = 4
        End Enum

        Public Enum RadioBand
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AM", "AM")>
            AM = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FM", "FM")>
            FM = 2
        End Enum

        Public Enum TVBand
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("TV", "TV")>
            TV = 1
        End Enum

        Public Enum NationalResearchReportType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Program Ranker")>
            ProgramRanker = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Network Ranker")>
            NetworkRanker = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Program Flowchart")>
            ProgramFlowchart = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Network Flowchart")>
            NetworkFlowchart = 4
        End Enum

        Public Enum NationalResearchReportEthnicity
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("G", "GeneralMarket")>
            G
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("H", "Hispanic")>
            H
        End Enum

        Public Enum NationalResearchReportTimeType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("P", "Program")>
            P
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Commercial")>
            C
        End Enum

        Public Enum NationalResearchReportDateType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("D", "Dates")>
            D
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Date Code")>
            C
        End Enum

        Public Enum NationalResearchReportFlags
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Ignore")>
            I
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Only")>
            O
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("E", "Exclude")>
            E
        End Enum

        Public Enum NationalResearchStream
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LV", "LV")>
            LV
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LS", "LS")>
            LS
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L1", "L1")>
            L1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L2", "L2")>
            L2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L3", "L3")>
            L3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("L7", "L7")>
            L7
        End Enum

        Public Enum FiscalMonths
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "January")>
            January
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "February")>
            February
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "March")>
            March
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "April")>
            April
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "May")>
            May
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "June")>
            June
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "July")>
            July
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "August")>
            August
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "September")>
            September
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "October")>
            October
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("11", "November")>
            November
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("12", "December")>
            December
        End Enum

        Public Enum MediaRFPAvailLineFileSource As Short
            [Default] = 0
            PRP = 1
        End Enum

        Public Enum CanadianVendorTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Specialty")>
            Specialty
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Conventional")>
            Conventional
        End Enum

        Public Enum MediaPlanEstimateTemplateQuarterValue As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Q1")>
            Q1 = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Q2")>
            Q2 = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Q3")>
            Q3 = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Q4")>
            Q4 = 4
        End Enum

        Public Enum MediaPlanEstimateTemplateRateTypeValue As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Column/Inch")>
            ColumnInch = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Line")>
            Line = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Standard")>
            Standard = 3
        End Enum

        'Public Enum MediaTVTypes As Short
        '    None = 0
        '    SpotTV = 1
        '    LocalCable = 2
        '    NationalTV = 3
        'End Enum

        Public Enum SpotTVPuertoRicoResearchReportType As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Ranker")>
            Ranker = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Trend by Date")>
            TrendByDate = 2
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Module

End Namespace
