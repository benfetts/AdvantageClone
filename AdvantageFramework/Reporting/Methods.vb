Namespace Reporting

    <HideModuleName()>
    Public Module Methods

#Region " Constants "


#End Region

#Region " Enum "

        Public Enum AdvancedReportWriterReports
            Alerts = 10
            AlertsWithComments = 11
            AlertsWithRecipients = 12
            ClientContact = 3
            DirectIndirectTime = 13
            DirectTime = 4
            EmployeeSummary = 21
            JobDetail = 9
            JobDetailAnalysisV10Detail = 14
            JobDetailAnalysisV10Summary = 15
            JobDetailAnalysisV1Detail = 16
            JobDetailAnalysisV1Summary = 17
            JobDetailBillMonth = 6
            JobDetailFunction = 7
            JobDetailItem = 8
            JobProjectScheduleSummary = 5
            JobSummary = 1
            ProjectHoursUsed = 19
            ProjectSchedule = 2
            ProjectSummary = 23
            ProjectSummaryTask = 24
            SecurityPermission = 18
            ServiceFeeReconciliation = 20
            Custom = 22
            GroupSummary = 25
            GroupSecurityPermission = 26
            NewspaperOrderDetail = 27
            MediaCurrentStatus = 28
            JobPurchaseOrder = 29
            EstimatedAndActualIncome = 30
            CRMOpportunityDetail = 31
            CRMOpportunityToInvestment = 32
            CRMProspects = 33
            CRMClientContracts = 34
            ClientPL = 35
            AROpenAged = 36
            MediaPlan = 37
            MediaCurrentStatusSummary = 38
            MediaPlanComparisonSummary = 39
            ServiceFee = 40
            Clients = 41
            Divisions = 42
            Products = 43
            Employees = 44
            Vendors = 45
            Campaign = 46
            PurchaseOrder = 47
            CashAnalysis = 48
            JobDetailAnalysisV11Summary = 49
            JobDetailAnalysisV11Detail = 50
            JobDetailAnalysisV11JobComp = 51
            JobDetailAnalysisV2Summary = 52
            JobDetailAnalysisV2Detail = 53
            JobDetailAnalysisV3Summary = 54
            JobDetailAnalysisV3JobComp = 55
            JobDetailAnalysisV4Summary = 56
            JobDetailAnalysisV4Detail = 57
            JobDetailAnalysisV5Summary = 58
            JobDetailAnalysisV5CliDivPrd = 59
            JobDetailAnalysisV6 = 60
            JobDetailAnalysisV7 = 61
            JobDetailAnalysisV8 = 62
            DirectIndirectTimeWithEmployeeCost = 63
            DirectTimeWithEmployeeCost = 64
            SalesJournal = 65
            JobDetailAnalysisV29 = 66
            AuthorizationToBuy = 67
            EmployeeTimeApproval = 68
            GeneralLedgerDetail = 69
            CampaignWithProductionAndMedia = 70
            EstimateDetailApproved = 71
            JobDetailAnalysisV30Detail = 72
            JobWriteOff = 73
            Transfer = 74
            AccountsPayableInvoiceWithBalanceAging = 75
            AccountsPayableInvoiceDetail = 76
            MediaResults = 77
            OneQuotePerPage = 78
            EstimateForm = 79
            BillingWorksheetProduction = 80
            ServiceFeeContract = 81
            IncomeOnly = 82
            ProjectSummaryAnalysis = 84
            ARPaymentHistory = 85
            ClientPLDetail = 86
            'ClientPLDetail = 86
            BillingWorksheetMedia = 87
            JobDetailItemAccountSplit = 88
            ExpenseReportAndApproval = 89
            VendorContract = 90
            VirtualCreditCardTransactionEFS = 91
            JobForecast = 92
            OpenPurchaseOrderDetail = 93
            DigitalResultsComparison = 94
            MediaSpecifications = 95
            GeneralLedgerReport = 96
            JobDetailAnalysisV9Summary = 97
            JobDetailAnalysisV9Detail = 98
            JobDetailAnalysisV9JobComp = 99
            MediaResultsComparisonByClientAndType = 100
            JobDetailAnalysisV31 = 101
            PurchaseOrderDetail = 102
            AccountsPayableInvoiceDetailPaidByClient = 103
            JobDetailAnalysisV30Summary = 104
            JobDetailAnalysisV30JobComp = 105
            TrialBalance = 106
            AccountsPayableBalanceByVendor = 107
            AccountsReceivableBalanceByClient = 108
            SalesAndCostOfSalesByClient = 109
            TimeReport = 110
            RevenueBreakdownByClient = 111
            EmployeeUtilization = 112
            EmployeeUtilizationBreakoutNonDirect = 113
            BroadcastWorksheetTVPreBuy = 114
            BroadcastWorksheetTVPostBuy = 115
            Sprint = 116
            CheckRegister = 117
            EmployeeInOutBoard = 118
            MediaPlanComparisonByVendor = 119
            MediaSpecificationsByDestination = 120
            ResourcesAllocationByWeek = 121
            GLChartOfAccounts = 122
            GLReportRow = 123
            CashTransactions = 124
            MediaBroadcastWorksheetBroadCastSchedule = 125
            MediaBroadcastWorksheetBroadcastScheduleWeeklySummary = 126
            MediaBroadcastWorksheetBroadcastScheduleMarketSummary = 127
            MediaBroadcastWorksheetBroadcastScheduleStationSummary = 128
            MediaBroadcastWorksheetBroadcastScheduleDetail = 129
            MediaCurrentStatusCoopBreakout = 130
            JobDetailFeesAndOOPByFunction = 131
            JobDetailFeesAndOOPByJobComponent = 132
            JobDetailFeesAndOOPByJob = 133
            JobDetailFeesAndOOPByCampaign = 134
            MediaPlanComparisonDetailByVendor = 135
            SecurityGroupSettings = 136
            SecurityGroupModuleAccess = 137
            SecurityGroupUserSettings = 138
            SecurityUserSettings = 139
            SecurityUserModuleAccess = 140
            ProjectScheduleTasksByEmployee = 141
            MonthEndMediaWIP = 142
            EmployeeHoursAllocation = 143
            SalesJournalWithComments = 144
            InvoiceBilledBackup = 145
            CashManagementProduction = 146
            BroadcastWorksheetRadioPreBuy = 147
            BroadcastWorksheetRadioPostBuy = 148
            AccountsPayableInvoiceDetailPayments = 149
            MediaTrafficMissingInstructions = 150
            MediaTrafficInstructions = 151
            MonthEndProductionWIP = 152
            EmployeeTimeForecast = 153
            MonthEndAccruedLiability = 154
            MonthEndAccountsPayable = 155
            JobDetailFeesAndOOPByFunctionMinimized = 156
            JobDetailFeesAndOOPByJob1Minimized = 157
            JobDetailFeesAndOOPByJob2Minimized = 158
            CampaignWithProductionAndMediaSummary = 159
            SecurityUserLoginAudit = 160
            SecurityUserTimesheetFunction = 161
            BillingApproval = 162
            BroadcastInvoiceSummary = 163
            EmployeeTimeAnalysis = 164
            CheckRegisterWithInvoiceDetails = 165
        End Enum

        Public Enum DynamicReports
            Alerts = 10
            AlertsWithComments = 11
            AlertsWithRecipients = 12
            ClientContact = 3
            DirectIndirectTime = 13
            DirectTime = 4
            JobDetail = 9
            JobDetailBillMonth = 6
            JobDetailFunction = 7
            JobDetailItem = 8
            JobProjectScheduleSummary = 5
            JobSummary = 1
            ProjectHoursUsed = 19
            ProjectSchedule = 2
            ProjectSummary = 23
            ProjectSummaryTask = 24
            NewspaperOrderDetail = 27
            MediaCurrentStatus = 28
            JobPurchaseOrder = 29
            EstimatedAndActualIncome = 30
            CRMOpportunityDetail = 31
            CRMOpportunityToInvestment = 32
            CRMProspects = 33
            CRMClientContracts = 34
            ClientPL = 35
            AROpenAged = 36
            MediaPlan = 37
            MediaCurrentStatusSummary = 38
            MediaPlanComparisonSummary = 39
            ServiceFee = 40
            Clients = 41
            Divisions = 42
            Products = 43
            Employees = 44
            Vendors = 45
            Campaign = 46
            JobVersion = 47
            CashAnalysis = 48
            DirectIndirectTimeWithEmployeeCost = 63
            DirectTimeWithEmployeeCost = 64
            SalesJournal = 65
            AuthorizationToBuy = 67
            EmployeeTimeApproval = 68
            GeneralLedgerDetail = 69
            CampaignWithProductionAndMedia = 70
            EstimateDetailApproved = 71
            JobWriteOff = 73
            Transfer = 74
            AccountsPayableInvoiceWithBalanceAging = 75
            AccountsPayableInvoiceDetail = 76
            MediaSpecifications = 77
            JobStatus = 78
            MediaResults = 79
            EstimateForm = 80
            BillingWorksheetProduction = 81
            ServiceFeeContract = 82
            IncomeOnly = 83
            ProjectSummaryAnalysis = 84
            ARPaymentHistory = 85
            ClientPLDetail = 86
            'ClientPLDetail = 86
            BillingWorksheetMedia = 87
            JobDetailItemAccountSplit = 88
            ExpenseReportAndApproval = 89
            VendorContracts = 90
            VirtualCreditCardTransactionEFS = 91
            JobForecast = 92
            OpenPurchaseOrderDetail = 93
            DigitalResultsComparison = 94
            GeneralLedgerReport = 95
            MediaResultsComparisonByClientAndType = 96
            AccountsPayableInvoiceDetailPaidByClient = 97
            TrialBalance = 98
            AccountsPayableBalanceByVendor = 99
            AccountsReceivableBalanceByClient = 100
            SalesAndCostOfSalesByClient = 101
            TimeReport = 102
            RevenueBreakdownByClient = 103
            EmployeeUtilization = 104
            EmployeeUtilizationReport = 105
            EmployeeUtilizationReportCategoryType = 106
            BroadcastWorksheetTVPreBuy = 107
            BroadcastWorksheetTVPostBuy = 108
            ResourceAllocationByWeek = 109
            CheckRegister = 110
            EmployeeInOutBoard = 111
            MediaPlanComparisonByVendor = 112
            MediaSpecificationsByDestination = 113
            GLChartOfAccounts = 114
            GLReportRow = 115
            CashTransactions = 116
            MediaCurrentStatusCoopBreakout = 117
            JobDetailFeesAndOOPByFunction = 118
            JobDetailFeesAndOOPByJobComponent = 119
            JobDetailFeesAndOOPByJob = 120
            JobDetailFeesAndOOPByCampaign = 121
            MediaPlanComparisonDetailByVendor = 122
            SecurityGroupSettings = 123
            SecurityGroupModuleAccess = 124
            SecurityGroupUserSettings = 125
            SecurityUserSettings = 126
            SecurityUserModuleAccess = 127
            ProjectScheduleTasksByEmployee = 128
            MonthEndMediaWIP = 129
            EmployeeHoursAllocation = 130
            SalesJournalWithComments = 131
            EmployeeUtilizationReportWithIndirectTime = 132
            InvoiceBilledBackup = 133
            CashManagementProduction = 134
            BroadcastWorksheetRadioPreBuy = 135
            BroadcastWorksheetRadioPostBuy = 136
            AccountsPayableInvoiceDetailPayments = 137
            MediaTrafficMissingInstructions = 138
            MediaTrafficInstructions = 139
            MonthEndProductionWIP = 140
            EmployeeTimeForecast = 141
            MonthEndAccruedLiability = 142
            MonthEndAccountsPayable = 143
            JobDetailFeesAndOOPByFunctionMinimized = 144
            JobDetailFeesAndOOPByJob1Minimized = 145
            JobDetailFeesAndOOPByJob2Minimized = 146
            CampaignWithProductionAndMediaSummary = 147
            VendorSpendWithEEOCAndMinorityStatusSummary = 148
            VendorSpendWithEEOCAndMinorityStatusDetail = 149
            SecurityUserLoginAudit = 150
            SecurityUserTimesheetFunction = 151
            BillingApproval = 152
            BroadcastInvoiceSummary = 153
            EmployeeTimeAnalysis = 154
            CheckRegisterWithInvoiceDetails = 155
        End Enum

        Public Enum ReportTypes
            JobDetailAnalysisV1Summary = 1
            JobDetailAnalysisV1Detail = 2
            JobDetailAnalysisV10Summary = 3
            JobDetailAnalysisV10Detail = 4
            SecurityPermission = 5
            UserDefined = 6
            AccountExecutiveUpdate = 7
            EmployeeAddressListing = 8
            EmployeeDetailListing = 9
            EmployeeDetailListingWithHR = 10
            ServiceFeeReconciliationReport = 11
            ServiceFeeReconciliationDetailReport = 12
            BankReport = 13
            ClientReport = 14
            EmployeeSummary = 15
            GroupSecurityPermission = 16
            GroupSummary = 17
            AccountPayableBatchSummary = 18
            EmployeeExpenseReport = 19
            TaskTemplates = 20
            TaskTemplatesWithRoles = 21
            AccountPayableBatchDetail = 22
            VendorDetail = 23
            VendorDetailVendorContacts = 24
            VendorDetailMedia = 25
            VendorSummaryVendorList = 26
            VendorSummaryVendorListWithPayToEEOC = 27
            VendorHistoryReport = 28
            PurchaseOrderApprovalRuleReport = 29
            AccountPayableRecurBatch = 30
            OfficeAndDepartmentCrossReference = 31
            GLAccountGroup = 32
            GLAccountAllocation = 33
            ClientDetail = 34
            DivisionDetail = 35
            ProductDetail = 36
            ClientContractAndOpportunityDetail = 37
            CRMDetailedInformation = 38
            PurchaseOrderReport = 39
            VendorDetailProduction = 40
            Standard1099 = 41
            Standard1099Form = 42
            JobDetailAnalysisV11Summary = 43
            JobDetailAnalysisV11Detail = 44
            JobDetailAnalysisV11JobComp = 45
            JobDetailAnalysisV2Summary = 46
            JobDetailAnalysisV2Detail = 47
            JobDetailAnalysisV3Summary = 48
            JobDetailAnalysisV3JobComp = 49
            JobDetailAnalysisV4Summary = 50
            JobDetailAnalysisV4Detail = 51
            JobDetailAnalysisV5Summary = 52
            JobDetailAnalysisV5CliDivPrd = 53
            JobDetailAnalysisV6 = 54
            JobDetailAnalysisV7 = 55
            JobDetailAnalysisV8 = 56
            Summary1099AllVendors = 57
            Detail1099WithDisbursement = 58
            ClientCashReceiptBatchReport = 59
            EmployeeTimesheetReport = 60
            EmployeeTimesheetDetailReport = 61
            JobDetailAnalysisV29 = 62
            AccountReceivableImportBatch = 63
            ClientCashReceiptBatchSummaryReport = 64
            ClientInvoiceBatchDetailReport = 65
            ClientInvoiceBatchSummaryReport = 66
            AccountPayableImportExpenseReport = 67
            AuthorizationToBuyDigitalMedia = 68
            EmployeeRateHistory = 69
            AuthorizationToBuyDigitalMediaForm = 70
            IncomeOnlyBatchReport = 71
            JobDetailAnalysisV30Detail = 72
            ClientInvoiceReport = 73
            OneQuotePerPage = 74
            EstimateReport = 75
            OtherCashReceiptBatchReport = 76
            IncomeOnlyBatchSummaryReport = 77
            ClientPLGrossIncomeSummaryByClientDivisionProduct = 78
            ClientPLGrossIncomeSummaryByClientDivisionProductSalesClass = 79
            ClientPLGrossIncomeSummaryBySalesClassClient = 80
            ClientPLGrossIncomeSummaryByClientDivisionProductPostPeriod = 81
            ClientSummaryGPofBilling = 82
            ClientSummaryExtendedGPofGI = 83
            SummaryByPeriodMediaSeparate = 84
            GrossIncomeSummarybyCDPSCYTDMargin = 85
            BillingWorksheetProductionSummary = 86
            BillingWorksheetMediaSummary = 87
            JobProfitabilitySummary = 88
            JobProfitabilityDetail = 89
            GrossIncomeSummarybyClientSCYTDBudget = 90
            ClientSummaryGPofTimeIncAndHourlyRate = 91
            GrossIncomeSummarybyClientYTDBudget = 92
            GrossIncomebyClient12PeriodWtihBudget = 93
            GrossIncomeSummarybyClientSCCurrentYTDBudget = 94
            SummaryByClientwithBudgetIncomeCostsHours = 95
            SummaryByClientSalesClassCurrentYTDBillingIncome = 96
            GrossBillingByClient12PeriodWithBudget = 97
            MediaSpecifications = 98
            JobProfitabilitySummaryWithOverhead = 99
            BillingWorksheetProductionUnbilledDetail = 100
            VendorContract = 101
            ClientProfitAndLossDetail = 102
            GeneralLedgerReport = 103
            MediaCurrentStatusDetailbyTypeClient = 104
            MediaReconciliation = 105
            MediaBillingandPaymentSummary = 106
            MediaBillingandPaymentDetail = 107
            SalesJournal = 108
            SalesJournalExpanded = 109
            JobDetailAnalysisV9Summary = 110
            JobDetailAnalysisV9Detail = 111
            JobDetailAnalysisV9JobComp = 112
            AccountPayableBatchSummaryDataEntryOrder = 113
            ClientProfitAndLossDetailSalesClass = 114
            JobDetailAnalysisV31 = 115
            PurchaseOrderDetail = 116
            DirectTime = 117
            JobDetailAnalysisV30Summary = 118
            JobDetailAnalysisV30JobComp = 119
            ClientProfitAndLossDetailDirectSummary = 120
            EmployeeUtilizationReport = 121
            BillingWorksheetMediaByOrderDescription = 122
            MediaReconciliationReportWithBilled = 123
            MediaOrdersUnbilledWithoutAPByMonth = 124
            MediaOrdersUnbilledWithoutAPByOrder = 125
            DirectTimebyClientSummary = 126
            DirectTimebyClientSummaryEmployeeDetail = 127
            DirectTimebyClientSummaryJobDetail = 128
            MediaActivitySummaryByType = 129
            MediaActivityDetailByType = 130
            MediaActivityDetailByCampaign = 131
            BillingApprovalBatch = 132
            CashTransaction = 133
            SalesJournalSummaryByInvoice = 134
            BillingWorksheetProductionUnbilledDetailWithComments = 135
            BillingWorksheetProductionUnbilledDetailV2 = 136
            HoursWorkedSummaryByDate = 137
            HoursWorkedSummaryByEmployee = 138
            HoursWorkedDetailByDate = 139
            HoursWorkedDetailByEmployee = 140
            SalesJournal12PeriodByTypeJob = 141
            SalesJournal12PeriodByTypeJobNoTax = 142
            SalesJournalTaxableSalesDetailByClient = 143
            MarketScheduleWeeklyDetail = 144
            BillingWorksheetProductionSummaryV2 = 145
            MediaReconciliationReportWithBilledByClientAndType = 146
            CashManagementProductionSummaryARPaidGross = 147
            CashManagementProductionSummaryARPaidGrossIncludeNonbillableCost = 148
            CashManagementProductionSummaryARPaidNet = 149
            CashManagementProductionSummaryARPaidNetIncludeNonbillableCost = 150
            CashManagementProductionDetailARPaidGross = 151
            CashManagementProductionDetailARPaidGrossIncludeNonbillableCost = 152
            CashManagementProductionDetailARPaidNet = 153
            CashManagementProductionDetailARPaidNetIncludeNonbillableCost = 154
            MediaWIPSummaryByClientBillingAPBalance = 155
            MediaWIPDetailByGLAccount = 156
            MediaWIPSummaryByVendorBalanceOnly = 157
            MediaWIPSummaryByClientBalanceOnly = 158
            MediaOrdersWithZeroBalance = 159
            MediaWIPSummaryByClientPOBalanceOnly = 160
            MediaWIPAgedSummaryByVendor = 161
            MediaWIPAgedSummaryByClient = 162
            MediaWIPAgedSummaryByMediaType = 163
            AccruedAccountsPayableByClientVendorPeriod = 164
            MediaOrdersBilledWithoutAPByTypeClient = 165
            AccountsReceivableAgedSummarybyClient = 166
            AccountsReceivableAgedSummarybyProduct = 167
            AccountsReceivableAgedDetailbyClient = 168
            AccountsReceivableAgedDetailbyProduct = 169
            AccountsReceivableAgedwithDisbursementDetail = 170
            UpdatedRateRequestReport = 171
            ProductionWIPAgedSummaryByClient = 172
            EmployeeTimeForecast = 173
            ProductionWIPDetailbyJobVendorOnly = 174
            ProductionWIPSummaryByJobWithEstimate = 175
            ProductionWIPSummaryByJobWithRecIncome = 176
            ProductionWIPSummaryByJobWithPayments = 177
            ProductionWIPSummaryByVendorWithPayments = 178
            ProductionWIPAgedSummaryByJob = 179
            ProductionWIPAgedSummaryByJobWithEstimate = 180
            ProductionWIPAgedSummaryByJobVendorOnly = 181
            AccruedLiabilitySummaryByJobAPLimited = 182
            AccruedLiabilitySummaryByJobAPPosted = 183
            AccruedLiabilitySummaryByJobSalesClass = 184
            AccruedLiabilitySummaryByJobSalesClassFunction = 185
            AccountsPayableDetailwithDaysAged = 186
            AccountsPayableDisbDetailByInvoiceNumber = 187
            AccountsPayableDisbDetailByInvoiceDate = 188
            AccountsPayableAgedSummary = 189
            AccountsPayableAgedDetail = 190
            Standard1099NECForm = 191
            TrafficFlightSummaryReport = 192
            ProofingFeedbackSummary = 193
            PaymentManagerReport = 194
        End Enum

        Public Enum ClientPLReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("102", "01 - Client Profit and Loss Detail")>
            ClientProfitAndLossDetail = 102
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("114", "01 - Client Profit and Loss Detail by Sales Class")>
            ClientProfitAndLossDetailSalesClass = 114
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("120", "01 - Client Profit and Loss Detail Summarized Direct Cost")>
            ClientProfitAndLossDetailDirectSummary = 120
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("78", "03 - Gross Income Summary by Client-Division-Product")>
            ClientPLGrossIncomeSummaryByClientDivisionProduct = 78
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("79", "04 - Gross Income Summary by Client-Division-Product-Sales Class")>
            ClientPLGrossIncomeSummaryByClientDivisionProductSalesClass = 79
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("82", "05 - Client Summary (GP% of Billing)")>
            ClientSummaryGPofBilling = 82
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("80", "08 - Gross Income Summary by Sales Class-Client")>
            ClientPLGrossIncomeSummaryBySalesClassClient = 80
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("83", "11 - Client Summary - Extended (GP % of GI)")>
            ClientSummaryExtendedGPofGI = 83
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("84", "14 - Summary by Period (Media Separate)")>
            SummaryByPeriodMediaSeparate = 84
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("81", "15 - Summary by Client-Division-Product-Period")>
            ClientPLGrossIncomeSummaryByClientDivisionProductPostPeriod = 81
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("85", "16 - Gross Income Summary by CDP-SC (YTD-Margin%)")>
            GrossIncomeSummarybyCDPSCYTDMargin = 85
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("90", "17 - Gross Income Summary by Client-SC (YTD-Budget)")>
            GrossIncomeSummarybyClientSCYTDBudget = 90
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("91", "19 - Client Summary (GP% of Time Inc and Hourly Rate)")>
            ClientSummaryGPofTimeIncAndHourlyRate = 91
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("92", "23 - Gross Income Summary by Client (YTD-Budget)")>
            GrossIncomeSummarybyClientYTDBudget = 92
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("93", "25 - Gross Income by Client (12 Month with Budget)")>
            GrossIncomebyClient12PeriodWtihBudget = 93
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("94", "26 - Gross Income by Client-SC (Current YTD Budget)")>
            GrossIncomeSummarybyClientSCCurrentYTDBudget = 94
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("95", "28 - Summary by Client with Budget-Income-Costs-Hours")>
            SummaryByClientwithBudgetIncomeCostsHours = 95
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("96", "29 - Summary by Client-SC (Current YTD Billing Income)")>
            SummaryByClientSalesClassCurrentYTDBillingIncome = 96
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("97", "30 - Gross Billing by Client (12 Month with Budget)")>
            GrossBillingByClient12PeriodWithBudget = 97
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("89", "50 - Job Profitability Detail")>
            JobProfitabilityDetail = 89
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("88", "51 - Job Profitability Summary")>
            JobProfitabilitySummary = 88
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("99", "52 - Job Profitability Summary with Overhead")>
            JobProfitabilitySummaryWithOverhead = 99
        End Enum

        Public Enum ProductReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("36", "Detail")>
            Detail = 36
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("37", "Client Contract and Opportunity Detail")>
            ClientContractAndOpportunityDetail = 37
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("38", "CRM Detailed Information")>
            CRMDetailedInformation = 38
        End Enum

        Public Enum SecurityReportTypes
            SecurityPermission = 5
            GroupSecurityPermission = 16
            EmployeeSummary = 15
            GroupSummary = 17
        End Enum

        Public Enum JobDetailAnalysisReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v001", "Act / Advance Bill History - Act Hrs/Net/MU/Re-Tax/Total")>
            v001 = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v002", "Non Billable, Billed Amts")>
            v002 = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v003", "Balance on Estimate, Billed Amts")>
            v003 = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v004", "Balance on Estimate, Billed, GI")>
            v004 = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v005", "Employee Time Analysis")>
            v005 = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v006", "Current Month/Prior Totals")>
            v006 = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v007", "CurrMo/Prior Totals, Est vs. Billed")>
            v007 = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v008", "Advance Billing Invoice History")>
            v008 = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v009", "Est/Act Cost, Billing, Gross Profit, Variances, Open POs")>
            v009 = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v010", "Act / Advance Bill History - Actual Total Only")>
            v010 = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v011", "Est/Act Cost, Billing, GP, Open POs, Bill/Rec History")>
            v011 = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v029", "Job Completion Report")>
            v029 = 12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v030", "Production Job - Quote vs. Actual")>
            v030 = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("v031", "Production Job Summary with Employee Time Percentages")>
            v031 = 14
        End Enum

        Public Enum EstimateReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("001", "001 - One Quote per Page")>
            OneQuotePerPage = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("002", "002 - Side by Side Quote")>
            SideBySideQuote = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("003", "003 - Revision Comparison")>
            RevisionComparison = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("004", "004 - Revision Comparison w/Variance")>
            RevisionComparisonWithVariance = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("005", "005 - Revision Comparison w/Var, No Actual")>
            RevisionComparisonWithVarianceNoActual = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("006", "006 - Revision Comparison, No Actual")>
            RevisionComparisonNoActual = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("007", "007 - Revision Comparison, Prev/Last Revisions")>
            RevisionComparisonPrevLastRevisions = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("008", "008 - Campaign Estimate Totals by Estimate Component")>
            CampaignEstimateTotalsByEstimateComponent = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("009", "009 - Campaign Estimate by Function Heading")>
            CampaignEstimateByFunctionHeading = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("300", "300 - SSX - Campaign Estimate")>
            SSXCampaignEstimate = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("301", "301 - SSX - Estimate")>
            SSXEstimate = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("302", "302 - Quarry - Campaign Estimate")>
            QuarryCampaignEstimate = 12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("303", "303 - All Components, Subtotal Components")>
            AllComponentsSubtotalComponents = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("304", "304 - Original/Final Comparison w/Var, No Actual")>
            OriginalFinalComparisonWithVarianceNoActual = 14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("305", "305 - Original/Final Comparison, No Actual")>
            OriginalFinalComparisonNoActual = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("306", "306 - Infinity Estimate")>
            InfinityEstimate = 16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("307", "307 - BWD Estimate Form")>
            BWDEstimateForm = 17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("308", "308 - BWD Client Estimate Form")>
            BWDClientEstimateForm = 18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("309", "309 - TPN Custom Estimate Form")>
            TPNCustomEstimateForm = 19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("310", "310 - TPN Custom Estimate Form 2")>
            TPNCustomEstimateForm2 = 20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("311", "311 - Tap Campaign Estimate")>
            TapCampaignEstimate = 21
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("312", "312 - Tap Campaign Estimate (Job)")>
            TapCampaignEstimateJob = 22
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("313", "313 - Revision Comparison w/Var, Prev/Last Revisions")>
            RevisionComparisonWithVariancePrevLastRevisions = 23
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("314", "314 - Side by Side Quote with Function Comments")>
            SideBySideQuoteWithFunctionComments = 24
        End Enum

        Public Enum MediaCurrentStatusReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("104", "01 - Media Current Status - Detail by Type, Client")>
            MediaCurrentStatusDetailbyTypeClient = 104
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("105", "02 - Media Reconciliation")>
            MediaReconciliation = 105
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("106", "03 - Media Billing and Payment Summary")>
            MediaBillingandPaymentSummary = 106
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("107", "04 - Media Billing and Payment Detail")>
            MediaBillingandPaymentDetail = 107
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("123", "05 - Media Reconciliation Report with Billed")>
            MediaReconciliationReportWithBilled = 123
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("146", "05 - Media Reconciliation Report with Billed By Client and Type")>
            MediaReconciliationReportWithBilledByClientAndType = 146
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("124", "06 - Media Orders Unbilled Without AP By Month")>
            MediaOrdersUnbilledWithoutAPByMonth = 124
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("125", "07 - Media Orders Unbilled Without AP By Order")>
            MediaOrdersUnbilledWithoutAPByOrder = 125
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("129", "08 - Media Activity Summary by Type")>
            MediaActivitySummaryByType = 129
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("130", "09 - Media Activity Detail by Type")>
            MediaActivityDetailByType = 130
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("131", "10 - Media Activity Detail by Campaign")>
            MediaActivityDetailByCampaign = 131
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("165", "11 - Media Orders Billed Without AP by Type, Client")>
            MediaOrdersBilledWithoutAPByTypeClient = 165
        End Enum

        Public Enum EmployeeUtilizationReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("105", "Employee Utilization")>
            EmployeeUtilization = 105
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("106", "Employee Utilization - Category Type")>
            EmployeeUtilizationCategoryType = 106
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("132", "Employee Utilization - Indirect Time Detail")>
            EmployeeUtilizationReportWithIndirectTime = 132
        End Enum

        Public Enum BillingWorksheetProductionReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("86", "01 - Billing Report Summary")>
            BillingWorksheetProductionSummary = 86
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("100", "02 - Billing Report Unbilled Detail")>
            BillingWorksheetProductionUnbilledDetail = 100
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("135", "03 - Billing Report Unbilled Detail with Comments")>
            BillingWorksheetProductionUnbilledDetailWithComments = 135
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("136", "04 - Billing Report Unbilled Detail v2")>
            BillingWorksheetProductionUnbilledDetailV2 = 136
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("132", "05 - Billing Approval Batch Report")>
            BillingApprovalBatch = 132
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("145", "06 - Billing Report Summary v2")>
            BillingWorksheetProductionSummaryV2 = 145
        End Enum

        Public Enum BillingWorksheetMediaReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("87", "01 - Media Billing Report Summary")>
            BillingWorksheetMediaSummary = 87
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("122", "02 - Media Billing Report - By Order Description")>
            BillingWorksheetMediaByOrderDescription = 122
        End Enum

        Public Enum PurchaseOrderReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("116", "01 - Detail Listing of Purchase Orders")>
            PurchaseOrderDetail = 116
        End Enum
        Public Enum SalesJournalReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("108", "01 - Sales Journal")>
            SalesJournal = 108
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("109", "02 - Sales Journal Expanded")>
            SalesJournalExpanded = 109
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("134", "03 - Sales Journal Summary By Invoice")>
            SalesJournalSummaryByInvoice = 134
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("141", "04 - Sales Journal 12 Period by Client/Division/Product, Media by Type/Production by Job")>
            SalesJournal12PeriodByTypeJob = 141
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("142", "04 - Sales Journal 12 Period by Client/Division/Product, Media by Type/Production by Job (No Tax)")>
            SalesJournal12PeriodByTypeJobNoTax = 142
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("143", "05 - Sales Journal Taxable Sales Detail by Client")>
            SalesJournalTaxableSalesDetailByClient = 143
        End Enum
        Public Enum MediaSpecificationsReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("77", "Media Specifications")>
            MediaSpecifications = 77
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("113", "Media Specifications by Destination")>
            MediaSpecificationsByDestination = 113
        End Enum

        Public Enum MediaBroadcastWorksheetOtherReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("144", "01 - Market Schedule Weekly Detail")>
            MarketScheduleWeeklyDetail = 144
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("171", "02 - Updated Rate Request Report")>
            UpdatedRateRequestReport = 171
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("192", "03 - Traffic Flight Summary Report")>
            TrafficFlightSummaryReport = 192
        End Enum

        Public Enum DirectIndirectTimeInitialCriteria
            [Date]
            [DateEntered]
            [ApprovalDate]
        End Enum

        Public Enum DirectTimeInitialCriteria
            [Date]
            [DateEntered]
            [ApprovalDate]
        End Enum
        Public Enum DirectTimeReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("126", "01 - Direct Time by Client Summary")>
            DirectTimebyClientSUmmary = 126
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("127", "02 - Direct Time by Client Summary - Employee Detail")>
            DirectTimebyClientSUmmaryEmployeeDetail = 127
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("128", "03 - Direct Time by Client Summary - Job Detail")>
            DirectTimebyClientSUmmaryJobDetail = 128
        End Enum
        Public Enum EmployeeTimeReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("137", "01 - Hours Worked Summary by Date")>
            HoursWorkedSummaryByDate = 137
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("138", "02 - Hours Worked Summary by Employee")>
            HoursWorkedSummaryByEmployee = 138
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("139", "03 - Hours Worked Detail by Date")>
            HoursWorkedDetailByDate = 139
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("140", "04 - Hours Worked Detail by Employee")>
            HoursWorkedDetailByEmployee = 140
        End Enum

        Public Enum DirectTimeParameters
            DateType
            FromDate
            ToDate
            IncludeMarkup
            SelectedClients
            SelectedDivisions
            SelectedProducts
            SelectedCampaigns
            SelectedJobs
            SelectedDepartments
            SelectedEmployees
            SelectedFunctions
            OnlyActiveEmployees
        End Enum

        Public Enum JobDetailInitialCriteria
            JobCreateDate
            ComponentDateOpened
            DueDate
            StartDate
        End Enum

        Public Enum JobDetailBillMonthInitialCriteria
            JobCreateDate
            ComponentDateOpened
            DueDate
            StartDate
        End Enum

        Public Enum JobDetailFunctionInitialCriteria
            JobCreateDate
            ComponentDateOpened
            DueDate
            StartDate
        End Enum

        Public Enum JobDetailItemInitialCriteria
            None
            JobCreateDate
            ComponentDateOpened
            DueDate
            StartDate
            ItemDate
        End Enum
        Public Enum JobDetailItemAccountSplitInitialCriteria
            JobCreateDate = 1
            ComponentDateOpened = 2
            DueDate = 3
            StartDate = 4
            ItemDate = 5
        End Enum

        Public Enum JobProjectScheduleSummaryInitialCriteria
            JobCreateDate
            ComponentDateOpened
            DueDate
            StartDate
            CompletedDate
            'DateDelivered
            'DateShipped
            TaskStartDate
            'TaskOriginalDueDate
            TaskRevisedDueDate
            'TaskCompletedDate
            'TempCompleteDate
        End Enum

        Public Enum JobSummaryInitialCriteria
            JobCreateDate = 1
            ComponentDateOpened = 2
            DueDate = 3
            StartDate = 4
        End Enum

        Public Enum JobPurchaseOrderInitialCriteria
            JobCreateDate = 1
            ComponentDateOpened = 2
            DueDate = 3
            StartDate = 4
            POCreateDate = 5
        End Enum

        Public Enum ProjectHoursUsedInitialCriteria
            JobCreateDate
            ComponentDateOpened
            DueDate
            StartDate
            CompletedDate
            ' DateDelivered
            'DateShipped
        End Enum

        Public Enum ProjectScheduleInitialCriteria
            JobCreateDate
            ComponentDateOpened
            DueDate
            StartDate
            CompletedDate
            'DateDelivered
            'DateShipped
            TaskStartDate
            'TaskOriginalDueDate
            TaskRevisedDueDate
            'TaskCompletedDate
            'TempCompleteDate
        End Enum

        Public Enum ProjectSummaryInitialCriteria
            StartDate
            DueDate
            NextTaskDueDate
            EstimateDate
            EstimateApprovedDate
            JobCreateDate
        End Enum

        Public Enum ProjectSummaryTaskInitialCriteria
            StartDate
            DueDate
            NextTaskDueDate
            EstimateDate
            EstimateApprovedDate
            TaskStartDate
            TaskDueDate
            JobCreateDate
        End Enum

        Public Enum UDRTypes
            Advanced = 1
            Dynamic = 2
            Estimate = 3
            Invoice = 4
        End Enum

        Public Enum EstimatedAndActualIncomeInitialCriteria
            JobCreateDate = 1
            ComponentDateOpened = 2
            DueDate = 3
            StartDate = 4
        End Enum

        Public Enum CRMOpportunityDetailInitialCriteria
            OpportunityEndDate
        End Enum

        Public Enum CRMOpportunityToInvestmentInitialCriteria
            OpportunityEndDate
        End Enum

        Public Enum CRMClientContractsInitialCriteria
            ContractEndDate
        End Enum

        Public Enum EstimatedAndActualIncomeParameters
            StartDate
            EndDate
            DateType
            Standard
        End Enum

        Public Enum EstimateDetailApprovalParameters
            FromDate
            ToDate
        End Enum

        Public Enum ClientPLParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            Type
            IncludeOffice
            IncludeClient
            IncludeDivision
            IncludeProduct
            IncludeType
            IncludeSalesClass
            IncludePostPeriod
            IncludeYear
            IncludeCampaign
            IncludeAE
            IncludeProductUDF
            IncludeManualInvoices
            IncludeGLEntries
            IncludeBilledIncomeRecognized
            IncludeCREntries
            FTEAllocation
            HoursCost
            CoopOption
            OverheadSet
            Summary
            UserId
            ExcludeNewBusiness
            DirectExpenseFromExpenseOperatingOnly
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            BroadcastDates
            StartingPostPeriod1Code
            EndingPostPeriod1Code
            StartingPostPeriod2Code
            EndingPostPeriod2Code
        End Enum

        Public Enum AROpenAgedParameters
            UsedID
            PeriodCutoff
            AgingDate
            AgingOption
            IncludeDetails
            RecordSource
        End Enum

        Public Enum MediaCurrentStatusParameters
            OrderStatus
            StartDate
            StartMonth
            StartYear
            EndDate
            EndMonth
            EndYear
            IncludeInternet
            IncludeMagazine
            IncludeNewspaper
            IncludeOutOfHome
            IncludeRadio
            IncludeTelevision
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            BroadcastDates
            Standard
            SelectedVendors
            SelectedMarkets
        End Enum

        Public Enum MediaCurrentStatusSummaryParameters
            OrderStatus
            StartDate
            StartMonth
            StartYear
            EndDate
            EndMonth
            EndYear
            IncludeInternet
            IncludeMagazine
            IncludeNewspaper
            IncludeOutOfHome
            IncludeRadio
            IncludeTelevision
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            BroadcastDates
            SelectedVendors
            SelectedMarkets
        End Enum

        Public Enum ServiceFeeParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            UsedID
            IncludeClient
            IncludeDivision
            IncludeProduct
            IncludeCampaign
            IncludeSalesClass
            IncludeJobNumber
            IncludeFeeType
            IncludeFunctionCode
            IncludeFunctionHeading
            IncludeConsolidation
            IncludeEmployee
            IncludeDate
            DesktopObject
            ServiceFeeType
            IncludePostPeriod
        End Enum

        Public Enum ServiceFeeReconParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            StartDate
            EndDate
        End Enum

        Public Enum PurchaseOrderReports
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("d_job_order_form_multi_std", "001 - STD FMT")>
            StandardFormat = 39
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("d_job_order_form_multi", "002 - STD - W Footer Above Signature")>
            FooterAboveSignature = 40
        End Enum

        Public Enum CampaignParameters
            IncludeClosed
        End Enum

        Public Enum CampaignProductionMediaParameters
            ClientCode
            CampaignIDFrom
            CampaignIDTo
            IncludeClosed
            UseCampaignMasterJobEstimate
        End Enum

        Public Enum CashAnaylsisParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            Query
        End Enum

        Public Enum BillingPaymentsParameters
            JobNumber
            JobComponentNumber
        End Enum

        Public Enum SalesJournalParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            BreakoutCoOpBilling
            PeriodType
            StartingInvoiceDate
            EndingInvoiceDate
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
        End Enum

        Public Enum TransferParameters
            FromDate
            ToDate
            IncludeAP
            IncludeEmployeeTime
            IncludeIncomeOnly
        End Enum

        Public Enum AuthorizationToBuyInitialCriteria
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Create Date")>
            CreateDate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Date of Request")>
            DateOfRequest
        End Enum

        Public Enum EmployeeTimeApprovalCriteria
            [Date]
        End Enum

        Public Enum JobWriteOffParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            IncludeEmployeeTime
            IncludeVendor
            IncludeIncomeOnly
            GroupByComponent
        End Enum

        Public Enum GeneralLedgerDetailParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            RecordSourceID
            IncludeInactiveAccounts
        End Enum

        Public Enum GeneralLedgerReportParameters
            Report
            RecordSourceID
            StartingPostPeriodCode
            EndingPostPeriodCode
            Offices
            Departments
            BaseCodes
            OtherCodes
            IncludeCurrentAssets
            IncludeNonCurrentAssets
            IncludeFixedAssets
            IncludeCurrentLiabilities
            IncludeNonCurrentLiabilities
            IncludeEquity
            IncludeIncome
            IncludeIncomeOther
            IncludeExpenseCOS
            IncludeExpenseOperating
            IncludeExpenseOther
            IncludeExpenseTaxes
        End Enum

        Public Enum MediaSpecificationInitialCriteria
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Material Close Date")>
            MaterialCloseDate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Insertion/Broadcast Start Date")>
            InsertionBroadcastStartDate = 2
        End Enum

        Public Enum MediaSpecificationStatusCriteria
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Open Only")>
            OpenOnly = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Open and Closed")>
            OpenAndClosed = 2
        End Enum

        Public Enum MediaSpecificationParameters
            DateType
            FromDate
            ToDate
            Status
            AcceptedOnly
        End Enum

        Public Enum APBalanceByVendorInitialCriteria
            EndingPostPeriodCode
            RecordSourceID
        End Enum

        Public Enum ARBalanceByClientInitialCriteria
            EndingPostPeriodCode
            RecordSourceID
        End Enum

        Public Enum AccountsPayableInvoiceWithBalanceAgingInitialCriteria
            StartingPostPeriodCode
            EndingPostPeriodCode
            AgingDate
            AgingOptionIsInvoiceDate
            IncludeOpenAccountsPayableOnly
            RecordSource
        End Enum

        Public Enum AccountsPayableInvoiceDetailInitialCriteria
            StartingPostPeriodCode
            EndingPostPeriodCode
            IncludeOpenAccountsPayableOnly
            IncludeBroadcastOrderLineMonth
            AgingDate
            AgingOptionIsInvoiceDate
        End Enum

        Public Enum DigitalResultsCriteria
            StartDate
            EndDate
        End Enum
        Public Enum MediaResultsParameters
            Criteria
            StartDate
            EndDate
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            BroadcastDates
        End Enum

        Public Enum BillingWorksheetInitialCriteria
            EmployeeDateCutoff
            IncomeOnlyDateCutoff
            AccountsPayablePostingPeriodCutoff
            JobType
            JobOption
            IncludeNonBillableTimeDetail
            IncludeNonBillableAPIODetail
            PrintItemDetail
            IncludeContingency
            SelectedClients
            SelectedDivisions
            SelectedProducts
            SelectedAccountExecutives
            BillingCommandCenterID
            UserCode
            SelectedJobs
            NonBillableTimeStartDate
            NonBillableTimeEndDate
            PopulateTimeComments
            PopulateAPComments
            PopulateIOComments
        End Enum

        Public Enum EstimateParameters
            FromDate
            ToDate
        End Enum

        Public Enum IncomeOnlyCriteria
            InvoiceDate
            CreateDate
        End Enum

        Public Enum JobServiceFeeCriteria
            FeeStartDate
            CreateDate
        End Enum

        Public Enum ARPaymentHistoryParameters
            UserID
            StartingPeriodCode
            EndingPeriodCode
            AgingOption
            IncludeOnAccount
        End Enum

        Public Enum ProjectSummaryAnalysisParameters
            DateType
            FromDate
            ToDate
            IncludeDetail
            IncludeEmployeeDetail
            QuotedPlanned
            ForecastHoursAllowed
            ClientCodes
            AECodes
            SalesClassCodes
            JobTypeCodes
        End Enum

        Public Enum BillingWorksheetMediaInitialCriteria
            DateToUse
            Newspaper
            Magazine
            OutOfHome
            Internet
            RadioDaily
            TVDaily
            MediaStartDate
            MediaEndDate
            RadioMonthly
            TVMonthly
            BroadcastStartDate
            BroadcastEndDate
            IncludeUnbilledOrdersOnly
            IncludeSpotsWithZeroBillingAmounts
            JobMediaDateFrom
            JobMediaDateTo
            SelectedClients
            SelectedDivisions
            SelectedProducts
            SelectedJobs
            SelectedAccountExecutives
            BillingCommandCenterID
            UserCode
            OmitZeroUnbilledAmounts
        End Enum
        Public Enum OpenPurchaseOrderDetailInitialCriteria
            POStartDate
            POEndDate
            IncludeClosedPOs
            IncludeVoidedPOs
            IncludeClientPOs
            IncludeNonClientPOs
        End Enum

        Public Enum ExpenseCriteria
            ExpenseDate
            CreateDate
        End Enum

        Public Enum VendorContractsInitialCriteria
            ContractEndDate
        End Enum

        Public Enum VirtualCreditCardTransactionsEFSInitialCriteria
            DateRangeType
            StartDate
            EndDate
            IncludeTransactionDetail
            VirtualCreditCardTransactionEFSDetails
        End Enum

        Public Enum JobForecastParameters
            SearchDate
            BreakoutPostPeriods
        End Enum

        Public Enum DigitalResultsComparisonParameters
            OrderStatus
            StartDate
            EndDate
        End Enum

        Public Enum MediaSpecificationsInitialParameters
            FromDate
            ToDate
            DateType
            Status
            AcceptedOnly
        End Enum

        Public Enum CRMProspectsParameters
            IncludeInactiveCDPs
        End Enum

        Public Enum MediaResultsComparisonParameters
            StartDate
            EndDate
            IncludeVendor
            IncludeSalesClass
            IncludePeriod
        End Enum
        Public Enum MediaResultsComparisonByClientTypeParameters
            StartDate
            EndDate
            IncludeVendor
            IncludeSalesClass
            IncludePeriod
            IncludeAdNumber
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
        End Enum

        Public Enum SalesAndCOSbyClientInitialParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            RecordSourceID
        End Enum

        Public Enum RevenueBreakdownByClientInitialParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
        End Enum

        Public Enum TimeReportInitialParameters
            StarteDate
            EndDate
        End Enum

        Public Enum TimeReportInitialCriteria
            [Date]
        End Enum
        Public Enum JobDetailInitialParameters
            JobDateCriteria
            JobStartDate
            JobEndDate
            ShowJobsWithNoDetails
            IncludeClosed
            EmployeeDateCutoff
            IncomeOnlyDateCutoff
            AccountsPayablePostingPeriodCutoff
            IncludeBilledRange
            StartingPostPeriodCode
            EndingPostPeriodCode
            SelectedClients
            SelectedDivisions
            SelectedProducts
            SelectedAccountExecutives
            SelectedCampaigns
            'DateOption
            CurrentStartDate
            CurrentEndDate
            CurrentPeriod
            SelectedJobTypes
            SelectedOOPFunctions
        End Enum
        Public Enum RevenueForecastInitialParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
            SelectedOffices
            SelectedSalesClass
            CurrentPeriod
            DisplayOption
            ActualizeDate
        End Enum
        Public Enum EmployeeUtilizationInitialParameters
            StartDate
            EndDate
            UserID
            Groupby
            LimitWIP
            SelectedOffices
            SelectedDepartments
        End Enum
        Public Enum EmployeeTimeForecastInitialParameters
            PostPeriod
            OfficeCode
            UserID
            EmployeeCode
        End Enum
        Public Enum MediaBroadcastWorksheetInitialCriteria
            WorksheetMarketVendors
            MediaBroadcastWorksheetMarketBooks
            Session
        End Enum

        Public Enum CashTransactionParameters
            SelectedBanks
            StartPeriod
            EndPeriod
            IncludeReceipts
            IncludeDisbursements
            IncludeGLEntries
            ClearedOption
            StatementCutoff
        End Enum

        Public Enum CheckRegisterParameters
            StartingDate
            EndingDate
            SelectedBanks
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            IncludeComputerChecks
            IncludeManualChecks
            IncludeComments
            LimitVoidedChecks
            LimitOutstandingChecks
            LimitClearedChecks
            PostPeriodStart
            PostPeriodEnd
            UsePayToVendorCode
            SelectedVendors
            IncludeInvoiceDetails
        End Enum
        Public Enum EmployeeInOutParameters
            LimitEntries
            UserCode
            Offset
            StartingDate
        End Enum
        Public Enum AlertParameters
            StartDate
            EndDate
            DateType
            IncludeDismissed
        End Enum
        Public Enum ResourceAllocationByWeekParameters
            StartingWeek
            NumberOfWeeks
            View
        End Enum
        Public Enum MediaPlanParameters

            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            BroadcastDates
        End Enum

        Public Enum SecurityParameters
            ShowOnlyAccessibleModules
            IncludeTerminatedEmployees
            SelectedGroups
            SelectedUsers
        End Enum

        Public Enum SecurityUserLoginAuditParameters
            StartDate
            EndDate
            OnlyFailures
        End Enum

        Public Enum MonthEndMediaWIPParameters
            EndPeriod
            OrderOption
            WIPOption
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            AgingDate
            AgingOption
            IncludeDetails
        End Enum

        Public Enum MonthEndProductionWIPParameters
            EndPeriod
            OrderOption
            WIPOption
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            AgingDate
            AgingOption
            IncludeDetails
        End Enum

        Public Enum MonthEndAccruedLiabilityParameters
            EndPeriod
            OrderOption
            WIPOption
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            AgingDate
            AgingOption
            IncludeDetails
        End Enum

        Public Enum MonthEndAccountsPayableParameters
            EndPeriod
            OrderOption
            WIPOption
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            AgingDate
            AgingOption
            IncludeDetails
        End Enum
        Public Enum EmployeeHoursAllocationParameters
            ReportType
            StartDate
            EndDate
            OmitBeginning
            ReportBy
            SelectedOffices
            SelectedDepartments
            SelectedRoles
            SelectedEmployees
            IncludeActuals
        End Enum

        Public Enum ProjectScheduleTasksByEmployeeInitialCriteria
            JobCreateDate
            ComponentDateOpened
            DueDate
            StartDate
            CompletedDate
            TaskStartDate
            TaskRevisedDueDate
        End Enum

        Public Enum MarketScheduleWeeklyDetailParameters
            MediaBroadcastWorksheetID
            MediaBroadcastWorksheetMarketIDVendorCodes
            FromDate
            ToDate
            ShowRatings
            ShowCPP
            ShowImpressions
            ShowCPM
            ShowRates
            ShowTotalCost
            ShowSecondardDemo
        End Enum

        Public Enum InvoiceBilledBackupInitialParameters
            StartDate
            EndDate
            SelectedClients
        End Enum

        Public Enum JobDetailItemAccountSplitInitialParameters
            JobDateCriteria
            JobStartDate
            JobEndDate
            ShowJobsWithNoDetails
            SelectedClients
            SelectedDivisions
            SelectedProducts
            SelectedAccountExecutives
        End Enum

        Public Enum CashManagementProductionInitialParameters
            JobDateCriteria
            JobStartDate
            JobEndDate
            ShowJobsWithNoDetails
            IncludeClosed
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
            SelectedAccountExecutives
            IncludeNonBillable

        End Enum

        Public Enum MonthEndReportSeries
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Media WIP (300 Series)")>
            MediaWIP = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Production WIP (400 Series)")>
            ProductionWIP = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Accounts Payable (500 Series)")>
            AccountsPayable = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Accounts Receivable (600 Series)")>
            AccountsReceivable = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Accrued Liability (700 Series)")>
            AccruedLiability = 5
        End Enum

        Public Enum MonthEndReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("155", "300 - Media WIP Summary by Client - Billing AP Balance")>
            MediaWIPSummaryByClientBillingAPBalance = 155
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("156", "301 - Media WIP Detail by GL Account")>
            MediaWIPDetailByGLAccount = 156
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("157", "302 - Media WIP Summary by Vendor - Balance Only")>
            MediaWIPSummaryByVendorBalanceOnly = 157
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("158", "303 - Media WIP Summary by Client - Balance Only")>
            MediaWIPSummaryByClientBalanceOnly = 158
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("159", "305 - Media Orders with Zero Balance")>
            MediaOrdersWithZeroBalance = 159
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("160", "306 - Media WIP Summary by Client PO Balance Only")>
            MediaWIPSummaryByClientPOBalanceOnly = 160
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("161", "307 - Media WIP Aged Summary by Vendor")>
            MediaWIPAgedSummaryByVendor = 161
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("162", "307 - Media WIP Aged Summary by Client")>
            MediaWIPAgedSummaryByClient = 162
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("163", "308 - Media WIP Aged Summary by Media Type")>
            MediaWIPAgedSummaryByMediaType = 163
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("164", "309 - Accrued Accounts Payable by Client/Vendor/Period")>
            AccruedAccountsPayableByClientVendorPeriod = 164
        End Enum

        Public Enum MediaTrafficMissingInstructionsInitialCriteria
            MediaBroadcastWorksheetMarketIDs
        End Enum

        Public Enum MediaTrafficInstructionsInitialCriteria
            MediaBroadcastWorksheetMarketIDs
            IncludeAllMediaTrafficRevisions
        End Enum

        Public Enum JobVersionInitialCriteria
            JobCreateDate = 1
            ComponentDateOpened = 2
            DueDate = 3
            StartDate = 4
            CreateDate = 5
        End Enum

        Public Enum MonthEndReportTypesAccountsReceivable
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("166", "600 - Accounts Receivable Aged Summary by Client")>
            AccountsReceivableAgedSummarybyClient = 166
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("167", "601 - Accounts Receivable Aged Summary by Product")>
            AccountsReceivableAgedSummarybyProduct = 167
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("168", "602 - Accounts Receivable Aged Detail by Client")>
            AccountsReceivableAgedDetailbyClient = 168
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("169", "603 - Accounts Receivable Aged Detail by Product")>
            AccountsReceivableAgedDetailbyProduct = 169
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("170", "604 - Accounts Receivable Aged with Disbursement Detail by Product")>
            AccountsReceivableAgedwithDisbursementDetail = 170
        End Enum

        Public Enum UpdatedRateRequestReportParameters
            MediaBroadcastWorksheetID
            MediaBroadcastWorksheetMarketIDVendorCodes
            ShowRatingsCPP
            ShowImpressionsCPM
            ShowSecondardDemo
        End Enum

        Public Enum MonthEndProductionWIPReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("174", "400 - Production WIP Detail by Job - Vendor Only")>
            ProductionWIPDetailbyJobVendorOnly = 174
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("175", "401 - Production WIP Summary by Job with Estimate")>
            ProductionWIPSummaryByJobWithEstimate = 175
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("176", "402 - Production WIP Summary by Job with Recognized Income")>
            ProductionWIPSummaryByJobWithRecIncome = 176
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("177", "403 - Production WIP Summary by Job with Payments")>
            ProductionWIPSummaryByJobWithPayments = 177
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("178", "404 - Production WIP Summary by Vendor with Payments")>
            ProductionWIPSummaryByVendorWithPayments = 178
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("179", "405 - Production WIP Aged Summary by Job")>
            ProductionWIPAgedSummaryByJob = 179
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("180", "406 - Production WIP Aged Summary by Job with Estimate")>
            ProductionWIPAgedSummaryByJobWithEstimate = 180
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("181", "407 - Production WIP Aged Summary by Job - Vendor Only")>
            ProductionWIPAgedSummaryByJobVendorOnly = 181
        End Enum

        Public Enum MonthEndAccruedLiabilityReportTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("182", "700 - Accrued Liability Summary by Job - AP Limited")>
            AccruedLiabilitySummaryByJobAPLimited = 182
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("183", "701 - Accrued Liability Summary by Job - AP Posted")>
            AccruedLiabilitySummaryByJobAPPosted = 183
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("184", "702 - Accrued Liability Summary by Job and Sales Class")>
            AccruedLiabilitySummaryByJobSalesClass = 184
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("185", "703 - Accrued Liability Summary by Job, Sales Class, and Function")>
            AccruedLiabilitySummaryByJobSalesClassFunction = 185
        End Enum

        Public Enum MonthEndReportTypesAccountsPayable
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("186", "500 - Accounts Payable Detail with Days Aged")>
            AccountsPayableDetailwithDaysAged = 186
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("187", "501 - Accounts Payable Disbursement Detail by Invoice Number")>
            AccountsPayableDisbDetailByInvoiceNumber = 187
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("188", "502 - Accounts Payable Disbursement Detail by Invoice Date")>
            AccountsPayableDisbDetailByInvoiceDate = 188
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("189", "503 - Accounts Payable Aged Summary")>
            AccountsPayableAgedSummary = 189
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("190", "505 - Accounts Payable Aged Detail")>
            AccountsPayableAgedDetail = 190
        End Enum

        Public Enum VendorSpendWithEEOCAndMinorityStatusSummaryParameters
            StartingPostPeriodCode
            EndingPostPeriodCode
        End Enum

        Public Enum BillingApprovalInitialParameters
            IncludeOptions
            FromInvDate
            ToInvDate
            IncludeJobs
            SelectedAccountExecutives
            SelectedClients
            SelectedDivisions
            SelectedProducts
            SelectedJobs
        End Enum

        Public Enum BroadcastInvoiceSummaryParameters
            StartPeriod
            EndPeriod
            IncludeRadio
            IncludeTV
            OrderStatus
            SelectedOffices
            SelectedClients
            SelectedDivisions
            SelectedProducts
        End Enum
        Public Enum EmployeeTimeAnalysisInitialParameters
            StartDate
            EndDate
            UserID
            SelectedOffices
            SelectedDepartments
            SelectedEmployees
            IncludeInactiveEmployees
            FeeTimeOption
        End Enum

        Public Enum TrafficFlightSummaryReportParameters
            MediaBroadcastWorksheetID
            MediaBroadcastWorksheetMarketIDVendorCodes
            FromDate
            ToDate
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

