Namespace Desktop.Presentation

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LaunchInitialLoadingDialog(SelectedDynamicReport As AdvantageFramework.Reporting.DynamicReports,
                                                   ByRef Criteria As Integer, ByRef FilterString As String, ByRef [From] As Date, ByRef [To] As Date,
                                                   ByRef ShowJobsWithNoDetails As Boolean, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                   ByRef ParameterDictionaryDrillDown As Generic.Dictionary(Of String, Object)) As Boolean

            'objects
            Dim LoadData As Boolean = True

            If SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.ServiceFeeContract OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.IncomeOnly OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.VendorContracts OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

                If AdvantageFramework.Desktop.Presentation.DynamicReportInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, Criteria, FilterString, [From], [To], ShowJobsWithNoDetails) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

                'Me.Refresh()

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSummary OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask Then

                If AdvantageFramework.Reporting.Presentation.JobProjectScheduleSummaryInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, Criteria, FilterString, [From], [To], ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule Then

                If AdvantageFramework.Reporting.Presentation.JobProjectScheduleSummaryInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, Criteria, FilterString, [From], [To], ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.ClientPL Then

                If AdvantageFramework.Reporting.Presentation.ClientPLInitialLoadingDialog.ShowFormDialog(False, AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProduct, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.EstimatedAndActualIncome Then

                If AdvantageFramework.Reporting.Presentation.EstimatedAndActualIncomeInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaPlan Then

                If AdvantageFramework.Reporting.Presentation.MediaPlanInitialLoadingDialog.ShowFormDialog(Reporting.DynamicReports.MediaPlan, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaCurrentStatus Then

                If AdvantageFramework.Reporting.Presentation.MediaCurrentStatusNewInitialLoadingDialog.ShowFormDialog(False, AdvantageFramework.Reporting.ReportTypes.MediaCurrentStatusDetailbyTypeClient, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaCurrentStatusSummary Then

                If AdvantageFramework.Reporting.Presentation.MediaCurrentStatusSummaryInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaPlanComparisonSummary OrElse
                SelectedDynamicReport = Reporting.DynamicReports.MediaPlanComparisonByVendor OrElse
                SelectedDynamicReport = Reporting.DynamicReports.MediaPlanComparisonDetailByVendor Then

                If AdvantageFramework.Reporting.Presentation.MediaPlanComparisonSummaryInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaResults Then

                If AdvantageFramework.Reporting.Presentation.MediaResultsInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.AROpenAged Then

                If AdvantageFramework.Reporting.Presentation.AROpenAgedInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.ServiceFee Then

                If AdvantageFramework.Reporting.Presentation.ServiceFeeInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.Campaign Then

                If AdvantageFramework.Reporting.Presentation.CampaignInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.CashAnalysis Then

                If AdvantageFramework.Reporting.Presentation.CashAnalysisInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

                ParameterDictionaryDrillDown = ParameterDictionary

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.SalesJournal OrElse SelectedDynamicReport = Reporting.DynamicReports.SalesJournalWithComments Then

                If AdvantageFramework.Reporting.Presentation.SalesJournalInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, AdvantageFramework.Reporting.ReportTypes.MediaCurrentStatusDetailbyTypeClient, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.CampaignWithProductionAndMedia OrElse SelectedDynamicReport = Reporting.DynamicReports.CampaignWithProductionAndMediaSummary Then

                If AdvantageFramework.Reporting.Presentation.CampaignProductionMediaInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.EstimateDetailApproved Then

                If AdvantageFramework.Reporting.Presentation.EstimateDetailApprovalInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.GeneralLedgerDetail Then

                If AdvantageFramework.Reporting.Presentation.GeneralLedgerDetailInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.Transfer Then

                If AdvantageFramework.Reporting.Presentation.TransferInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.JobWriteOff Then

                If AdvantageFramework.Reporting.Presentation.JobWriteOffInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.AccountsPayableInvoiceWithBalanceAging Then

                If AdvantageFramework.Reporting.Presentation.AccountsPayableInvoiceWithBalanceAgingInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.AccountsPayableInvoiceDetail Then

                If AdvantageFramework.Reporting.Presentation.AccountsPayableInvoiceDetailInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

                If AdvantageFramework.Reporting.Presentation.CheckRegisterInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.AccountsPayableInvoiceDetailPaidByClient Then

                If AdvantageFramework.Reporting.Presentation.AccountsPayableInvoiceDetailInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.BillingWorksheetProduction Then

                If AdvantageFramework.Reporting.Presentation.BillingWorksheetProductionInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.EstimateForm Then

                If AdvantageFramework.Reporting.Presentation.EstimateInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.ARPaymentHistory Then

                If AdvantageFramework.Reporting.Presentation.ARPaymentHistoryInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.ProjectSummaryAnalysis Then

                If AdvantageFramework.Reporting.Presentation.ProjectSummaryAnalysisInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.ClientPLDetail Then

                If AdvantageFramework.Reporting.Presentation.ClientPLDetailInitialLoadingDialog.ShowFormDialog(False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.BillingWorksheetMedia Then

                If AdvantageFramework.Reporting.Presentation.BillingWorksheetMediaInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.OpenPurchaseOrderDetail Then

                If AdvantageFramework.Reporting.Presentation.OpenPurchaseOrderDetailLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, AdvantageFramework.Reporting.ReportTypes.PurchaseOrderDetail, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.VirtualCreditCardTransactionEFS Then

                If AdvantageFramework.Reporting.Presentation.VirtualCreditCardTransactionLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.JobForecast Then

                If AdvantageFramework.Reporting.Presentation.JobForecastInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.DigitalResultsComparison Then

                If AdvantageFramework.Reporting.Presentation.DigitalResultsComparisonInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.CRMProspects Then

                If AdvantageFramework.Reporting.Presentation.CRMProspectsInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.GeneralLedgerReport OrElse
                       SelectedDynamicReport = Reporting.DynamicReports.TrialBalance Then

                If AdvantageFramework.GeneralLedger.Reports.Presentation.GeneralLedgerReportDialog.ShowFormDialog(ParameterDictionary, True, SelectedDynamicReport) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaResultsComparisonByClientAndType Then

                If AdvantageFramework.Reporting.Presentation.MediaResultsComparisonInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.AccountsPayableBalanceByVendor Then

                If AdvantageFramework.Reporting.Presentation.AccountsPayableBalanceByVendorInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.AccountsPayableBalanceByVendor Then

                If AdvantageFramework.Reporting.Presentation.AccountsPayableBalanceByVendorInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.AccountsReceivableBalanceByClient Then

                If AdvantageFramework.Reporting.Presentation.AccountsReceivableBalanceByClientInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.SalesAndCostOfSalesByClient Then

                If AdvantageFramework.Reporting.Presentation.SalesAndCostOfSalesByClientInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.RevenueBreakdownByClient Then

                If AdvantageFramework.Reporting.Presentation.RevenueBreakdownByClientInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.JobDetailItem OrElse SelectedDynamicReport = Reporting.DynamicReports.JobDetail OrElse
                    SelectedDynamicReport = Reporting.DynamicReports.JobDetailBillMonth OrElse SelectedDynamicReport = Reporting.DynamicReports.JobDetailFunction OrElse
                    SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                If AdvantageFramework.Reporting.Presentation.JobDetailInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.EmployeeUtilization Then

                If AdvantageFramework.Reporting.Presentation.EmployeeUtilizationInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.EmployeeTimeForecast Then

                If AdvantageFramework.Reporting.Presentation.EmployeeTimeForecastInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.BroadcastWorksheetTVPreBuy Then

                If AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.BuyType.Pre,
                                                                                                                                  Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.MediaType.TV, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.BroadcastWorksheetTVPostBuy Then

                If AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.BuyType.Post,
                                                                                                                                  Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.MediaType.TV, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.CheckRegister Then

                If AdvantageFramework.Reporting.Presentation.CheckRegisterInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.CheckRegisterWithInvoiceDetails Then

                If AdvantageFramework.Reporting.Presentation.CheckRegisterInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.EmployeeInOutBoard Then

                If AdvantageFramework.Reporting.Presentation.EmployeeInOutInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.Alerts OrElse SelectedDynamicReport = Reporting.DynamicReports.AlertsWithComments OrElse
                    SelectedDynamicReport = Reporting.DynamicReports.AlertsWithRecipients Then

                If AdvantageFramework.Reporting.Presentation.AlertInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.ResourceAllocationByWeek Then

                If AdvantageFramework.Reporting.Presentation.ResourceAllocationByWeekInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.CashTransactions Then

                If AdvantageFramework.Reporting.Presentation.CashTransactionInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.DirectTime Then

                If AdvantageFramework.Reporting.Presentation.DirectTimeInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.DirectIndirectTime Then

                If AdvantageFramework.Reporting.Presentation.DirectIndirectTimeInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaCurrentStatusCoopBreakout Then

                If AdvantageFramework.Reporting.Presentation.MediaCurrentStatusSummaryInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.JobDetailFeesAndOOPByFunction OrElse SelectedDynamicReport = Reporting.DynamicReports.JobDetailFeesAndOOPByJobComponent OrElse
                    SelectedDynamicReport = Reporting.DynamicReports.JobDetailFeesAndOOPByJob OrElse SelectedDynamicReport = Reporting.DynamicReports.JobDetailFeesAndOOPByCampaign OrElse
                    SelectedDynamicReport = Reporting.DynamicReports.JobDetailFeesAndOOPByFunctionMinimized OrElse SelectedDynamicReport = Reporting.DynamicReports.JobDetailFeesAndOOPByJob1Minimized OrElse
                    SelectedDynamicReport = Reporting.DynamicReports.JobDetailFeesAndOOPByJob2Minimized Then

                If AdvantageFramework.Reporting.Presentation.JobDetailFeesOOPInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.SecurityGroupModuleAccess OrElse
                SelectedDynamicReport = Reporting.DynamicReports.SecurityGroupSettings OrElse
                SelectedDynamicReport = Reporting.DynamicReports.SecurityGroupUserSettings OrElse
                SelectedDynamicReport = Reporting.DynamicReports.SecurityUserModuleAccess OrElse
                SelectedDynamicReport = Reporting.DynamicReports.SecurityUserSettings Then

                If AdvantageFramework.Reporting.Presentation.SecurityInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.SecurityUserLoginAudit Then

                If AdvantageFramework.Reporting.Presentation.SecurityUserLoginAuditReportInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                If AdvantageFramework.Reporting.Presentation.JobProjectScheduleSummaryInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, Criteria, FilterString, [From], [To], ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.MonthEndMediaWIP Then

                If AdvantageFramework.Reporting.Presentation.MonthEndMediaWIPInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.MonthEndProductionWIP Then

                If AdvantageFramework.Reporting.Presentation.MonthEndProductionWIPInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.MonthEndAccruedLiability Then

                If AdvantageFramework.Reporting.Presentation.MonthEndMediaWIPInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.MonthEndAccountsPayable Then

                If AdvantageFramework.Reporting.Presentation.MonthEndMediaWIPInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeHoursAllocation Then

                If AdvantageFramework.Reporting.Presentation.EmployeeHoursAllocationInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.InvoiceBilledBackup Then

                If AdvantageFramework.Reporting.Presentation.InvoiceBilledBackupInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.CashManagementProduction Then

                If AdvantageFramework.Reporting.Presentation.CashManagementProductionInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.BroadcastWorksheetRadioPreBuy Then

                If AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.BuyType.Pre,
                                                                                                                                  Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.MediaType.Radio, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.BroadcastWorksheetRadioPostBuy Then

                If AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.BuyType.Post,
                                                                                                                                  Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.MediaType.Radio, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaSpecifications Then

                'If AdvantageFramework.Reporting.Presentation.MediaSpecificationReportInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then
                If AdvantageFramework.Reporting.Presentation.MediaSpecificationsInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaSpecificationsByDestination Then

                If AdvantageFramework.Reporting.Presentation.MediaSpecificationsInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaTrafficMissingInstructions Then

                If AdvantageFramework.Reporting.Presentation.MediaTrafficInstructionsInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.MediaTrafficInstructions Then

                If AdvantageFramework.Reporting.Presentation.MediaTrafficInstructionsInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusSummary Then

                If AdvantageFramework.Reporting.Presentation.VendorSpendWithEEOCAndMinorityStatusSummaryInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusDetail Then

                If AdvantageFramework.Reporting.Presentation.VendorSpendWithEEOCAndMinorityStatusSummaryInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.BillingApproval Then

                If AdvantageFramework.Reporting.Presentation.BillingApprovalInitialLoadingDialog.ShowFormDialog(SelectedDynamicReport, False, Nothing, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.BroadcastInvoiceSummary Then

                If AdvantageFramework.Reporting.Presentation.BroadcastInvoiceSummaryInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            ElseIf SelectedDynamicReport = Reporting.DynamicReports.EmployeeTimeAnalysis Then

                If AdvantageFramework.Reporting.Presentation.EmployeeTimeAnalysisInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                    LoadData = False

                End If

            End If

            LaunchInitialLoadingDialog = LoadData

        End Function

#End Region

    End Module

End Namespace

