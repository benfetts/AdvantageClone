Imports Telerik.Web.UI

Public Class Reporting_UserDefinedReports
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub ChangeTabs()

        Select Case RadTabStripReports.SelectedIndex

            Case 0

                RadGridARW.Rebind()

            Case 1

                RadGridDynamic.Rebind()

        End Select

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_UserDefinedReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Session("UserDefinedReportID") = Nothing
            Session("UDR_FilterReport_FilterString") = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).OrderBy(Function(c) c.Description).ToList
                RadComboBoxReportCategory.DataBind()
                RadComboBoxReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", ""))

            End Using

            ChangeTabs()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadComboBoxReportCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxReportCategory.SelectedIndexChanged

        ChangeTabs()

    End Sub
    Private Sub RadTabStripReports_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripReports.TabClick

        ChangeTabs()

    End Sub
    Private Sub RadGridARW_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridARW.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
        Dim UserDefinedReportID As Integer = 0
        Dim LoadReport As Boolean = True
        Dim DynamicReport As AdvantageFramework.Reporting.DynamicReports = AdvantageFramework.Reporting.DynamicReports.Alerts

        Try

            If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

                CurrentGridDataItem = RadGridARW.Items(e.Item.ItemIndex)

            End If

        Catch ex As Exception
            CurrentGridDataItem = Nothing
        End Try

        If CurrentGridDataItem IsNot Nothing Then

            Select Case e.CommandName

                Case "ViewReport"

                    Session("UDR_FilterReport_FilterString") = Nothing

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        UserDefinedReportID = CurrentGridDataItem.GetDataKeyValue("ID")

                        UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, UserDefinedReportID)

                        If UserDefinedReport IsNot Nothing Then

                            If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary OrElse
                               UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

                                Me.OpenWindow("Job Detail Analysis", String.Format("Reporting_JobDetailAnalysis.aspx?UserDefinedReportID={0}&AdvancedReportWriterReport={1}", UserDefinedReportID, UserDefinedReport.AdvancedReportWriterType))

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateForm Then

                                Me.OpenWindow("Estimate", String.Format("Reporting_Estimate.aspx?UserDefinedReportID={0}&AdvancedReportWriterReport={1}", UserDefinedReportID, UserDefinedReport.AdvancedReportWriterType), 525, 575)

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecifications Then

                                Me.OpenWindow("Media Specifications", String.Format("Reporting_InitialLoadingMediaSpecifications.aspx?UserDefinedReportID={0}&AdvancedReportWriterReport={1}", UserDefinedReportID, UserDefinedReport.AdvancedReportWriterType), 525, 575)

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecificationsByDestination Then

                                Me.OpenWindow("Media Specifications by Destination", String.Format("Reporting_InitialLoadingMediaSpecifications.aspx?UserDefinedReportID={0}&AdvancedReportWriterReport={1}", UserDefinedReportID, UserDefinedReport.AdvancedReportWriterType), 525, 575)

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeUtilizationBreakoutNonDirect Then

                                Me.OpenWindow("Employee Utilization", String.Format("Reporting_InitialLoadingEmployeeUtilization.aspx?UserDefinedReportID={0}&AdvancedReportWriterReport={1}", UserDefinedReportID, UserDefinedReport.AdvancedReportWriterType), 525, 575)

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeTimeForecast Then

                                Me.OpenWindow("Employee Time Forecast", String.Format("Reporting_InitialLoadingEmployeeTimeForecast.aspx?UserDefinedReportID={0}&AdvancedReportWriterReport={1}", UserDefinedReportID, UserDefinedReport.AdvancedReportWriterType), 525, 575)

                            ElseIf UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission AndAlso
                                    UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary AndAlso
                                    UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom Then

                                Try

                                    DynamicReport = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), CType(UserDefinedReport.AdvancedReportWriterType, AdvantageFramework.Reporting.AdvancedReportWriterReports).ToString)

                                Catch ex As Exception
                                    LoadReport = False
                                End Try

                                If LoadReport Then

                                    If DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.VendorContracts OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

                                        Session("DRPT_Type") = DynamicReport

                                        Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoading.aspx?UserDefinedReportID={0}", UserDefinedReportID))

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

                                        Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingMediaResults.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaPlan Then

                                        Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingMediaPlan.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSummary OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask Then

                                        Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 700, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule Then

                                        Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 700, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.ClientPL Then

                                        Me.OpenWindow("Client PL Inital Criteria", String.Format("Reporting_InitialLoadingPostPeriod.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 700, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.EstimatedAndActualIncome Then

                                        Me.OpenWindow("Estimated and Actual Income Inital Criteria", String.Format("Reporting_InitialLoadingEstimatedAndActualIncome.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus Then

                                        Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.DigitalResultsComparison Then

                                        Me.OpenWindow("Digital Results Comparison Criteria", String.Format("Reporting_InitialLoadingDigitalResultsComparison.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary Then

                                        Me.OpenWindow("Media Current Status Summary Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusSummary.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonSummary Then

                                        Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

                                        Me.OpenWindow("AR Open Aged Criteria", String.Format("Reporting_InitialLoadingAROpenAged.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.ServiceFee Then

                                        Me.OpenWindow("Service Fee Criteria", String.Format("Reporting_InitialLoadingServiceFee.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.Campaign Then

                                        Me.OpenWindow("Campaign Criteria", String.Format("Reporting_InitialLoadingCampaign.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.CashAnalysis Then

                                        Me.OpenWindow("Cash Analysis Criteria", String.Format("Reporting_InitialLoadingCashAnalysis.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.SalesJournal OrElse
                                           DynamicReport = AdvantageFramework.Reporting.DynamicReports.SalesJournalWithComments Then

                                        Me.OpenWindow("Sales Journal Criteria", String.Format("Reporting_InitialLoadingSalesJournal.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail Then

                                        Me.OpenWindow("General Ledger Detail Criteria", String.Format("Reporting_InitialLoadingGeneralLedgerDetail.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMedia OrElse DynamicReport = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMediaSummary Then

                                        Me.OpenWindow("Campaign with Production and Media Criteria", String.Format("Reporting_InitialLoadingCampaignProductionMedia.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.EstimateDetailApproved Then

                                        Me.OpenWindow("Estimate Detail Approved Criteria", String.Format("Reporting_InitialLoadingEstimateDetailApproved.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.Transfer Then

                                        Me.OpenWindow("Transfer Criteria", String.Format("Reporting_InitialLoadingTransfer.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 700, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobWriteOff Then

                                        Me.OpenWindow("Job WriteOff Criteria", String.Format("Reporting_InitialLoadingJobWriteOff.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetail Then

                                        Me.OpenWindow("Accounts Payable Invoice Detail Criteria Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

                                        'Me.OpenWindow("Accounts Payable Invoice Detail Paymets Criteria Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)
                                        Me.OpenWindow("Accounts Payable Invoice Detail Paymets Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPaidByClient Then

                                        Me.OpenWindow("Accounts Payable Invoice Detail Criteria Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceWithBalanceAging Then

                                        Me.OpenWindow("Accounts Payable Invoice With Balance Aging Criteria Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceWithBalanceAging.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.EstimateForm Then

                                        Me.OpenWindow("Estimate Criteria", String.Format("Reporting_InitialLoadingEstimate.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryAnalysis Then

                                        Me.OpenWindow("Project Summary Analysis Criteria", String.Format("Reporting_InitialLoadingProjectSummaryAnalysis.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.ClientPLDetail Then

                                        Me.OpenWindow("Client PL Detail Criteria", String.Format("Reporting_InitialLoadingClientPLDetail.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 700, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetProduction Then

                                        Me.OpenWindow("Billing Worksheet Production Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetProduction.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetMedia Then

                                        Me.OpenWindow("Billing Worksheet Media Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetMedia.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 700, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobForecast Then

                                        Me.OpenWindow("Job Forecast Criteria", String.Format("Reporting_InitialLoadingJobForecast.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.OpenPurchaseOrderDetail Then

                                        Me.OpenWindow("Open Purchase Order Detail", String.Format("Reporting_InitialLoadingOpenPurchaseOrderDetail.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMProspects Then

                                        Me.OpenWindow("CRM Prospects Criteria", String.Format("Reporting_InitialLoadingCRMProspects.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.ARPaymentHistory Then

                                        Me.OpenWindow("AR Payment History Criteria", String.Format("Reporting_InitialLoadingARPaymentHistory.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerReport Then

                                        Me.OpenWindow("General Ledger Report Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/0/{1}", UserDefinedReportID, 95), 525, 900, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.TrialBalance Then

                                        Me.OpenWindow("Trial Balance Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/0/{1}", UserDefinedReportID, 95), 525, 900, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaResultsComparisonByClientAndType Then

                                        Me.OpenWindow("Media Results Comparison by Client and Type Criteria", String.Format("Reporting_InitialLoadingMediaResultsComparisonByClientAndType.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.AccountsPayableBalanceByVendor Then

                                        Me.OpenWindow("Accounts Payable Balance by Vendor Criteria", String.Format("Reporting/AccountsPayableBalanceByVendorReportCriteria/0/{0}", UserDefinedReportID), 400, 725, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.AccountsReceivableBalanceByClient Then

                                        Me.OpenWindow("Accounts Receivable Balance by Client Criteria", String.Format("Reporting/AccountsReceivableBalanceByClientReportCriteria/0/{0}", UserDefinedReportID), 400, 725, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.SalesAndCostOfSalesByClient Then

                                        Me.OpenWindow("Sales and COS by Client Criteria", String.Format("Reporting/SalesAndCostOfSalesByClientReportCriteria/0/{0}", UserDefinedReportID), 400, 725, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.RevenueBreakdownByClient Then

                                        Me.OpenWindow("Revenue Breakdown by Client Criteria", String.Format("Reporting/RevenueBreakdownByClientReportCriteria/0/{0}", UserDefinedReportID), 400, 725, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                                        Me.OpenWindow("Job Detail", String.Format("Reporting_InitialLoadingJobDetail.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeUtilization Then

                                        Me.OpenWindow("Employee Utilization", String.Format("Reporting_InitialLoadingEmployeeUtilization.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeForecast Then

                                        Me.OpenWindow("Employee Time Forecast", String.Format("Reporting_InitialLoadingEmployeeTimeForecast.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.CheckRegister Then

                                        Me.OpenWindow("Check Register Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.CheckRegisterWithInvoiceDetails Then

                                        Me.OpenWindow("Check Register with Invoice Detail Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeInOutBoard Then

                                        Me.OpenWindow("Employee In-Out Board Criteria", String.Format("Reporting_InitialLoadingEmployeeInOutBoard.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonByVendor OrElse DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonDetailByVendor Then

                                        Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.Alerts OrElse
                                           DynamicReport = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments OrElse
                                           DynamicReport = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Then

                                        Me.OpenWindow("Alerts Inital Criteria", String.Format("Reporting_InitialLoadingAlert.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek Then

                                        Me.OpenWindow("Resources Allocation by Week Inital Criteria", String.Format("Reporting_InitialLoadingResourceAllocationByWeek.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.CashTransactions Then

                                        Me.OpenWindow("Cash Transactions Criteria", String.Format("Reporting_InitialLoadingCashTransaction.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectTime OrElse
                                           DynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost Then

                                        Me.OpenWindow("Direct Time Inital Criteria", String.Format("Reporting_InitialLoadingDirectTime.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime OrElse
                                           DynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost Then

                                        Me.OpenWindow("Direct Indirect Time Inital Criteria", String.Format("Reporting_InitialLoadingDirectIndirectTime.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusCoopBreakout Then

                                        Me.OpenWindow("Media Current Status Coop Breakout Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunction OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJobComponent OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByCampaign OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunctionMinimized OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob1Minimized OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob2Minimized Then

                                        Me.OpenWindow("Job Detail Fees OOP Criteria", String.Format("Reporting_InitialLoadingJobDetailFeesOOP.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.SecurityGroupModuleAccess OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.SecurityGroupSettings OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.SecurityGroupUserSettings OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.SecurityUserModuleAccess OrElse
                                            DynamicReport = AdvantageFramework.Reporting.DynamicReports.SecurityUserSettings Then

                                        Me.OpenWindow("Security Criteria", String.Format("Reporting_InitialLoadingSecurity.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.SecurityUserLoginAudit Then

                                        Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingSecurityUserLoginAudit.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 575, False, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                                        Me.OpenWindow("Project Schedule Tasks By Employee Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 700, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MonthEndMediaWIP OrElse
                                           DynamicReport = AdvantageFramework.Reporting.DynamicReports.MonthEndAccruedLiability OrElse
                                           DynamicReport = AdvantageFramework.Reporting.DynamicReports.MonthEndAccountsPayable Then

                                        Me.OpenWindow("Month End Report Criteria", String.Format("Reporting_InitialLoadingMonthEndMediaWIP.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MonthEndProductionWIP Then

                                        Me.OpenWindow("Month End Report Criteria", String.Format("Reporting_InitialLoadingMonthEndProductionWIP.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeHoursAllocation Then

                                        Me.OpenWindow("Employee Hours Allocation Criteria", String.Format("Reporting_InitialLoadingEmployeeHoursAllocation.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.InvoiceBilledBackup Then

                                        Me.OpenWindow("Invoice Billed Backup Criteria", String.Format("Reporting_InitialLoadingInvoiceBilledBackup.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.CashManagementProduction Then

                                        Me.OpenWindow("Cash Management Production Criteria", String.Format("Reporting_InitialLoadingCashManagementProduction.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaTrafficInstructions OrElse
                                           DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaTrafficMissingInstructions Then

                                        Me.OpenWindow("Media Traffic Instructions Criteria", String.Format("Reporting_InitialLoadingMediaTrafficInstructions.aspx?DynamicReportTemplateID={0}", UserDefinedReportID), 525, 1400, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusSummary Then

                                        Me.OpenWindow("Vendor Spend With EEOC and Minority Status Summary Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusDetail Then

                                        Me.OpenWindow("Vendor Spend With EEOC and Minority Status Detail Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.BillingApproval Then

                                        Me.OpenWindow("Billing Approval Initial Criteria", String.Format("Reporting_InitialLoadingBillingApproval.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeAnalysis Then

                                        Me.OpenWindow("Employee Time Analysis Criteria", String.Format("Reporting_InitialLoadingEmployeeTimeAnalysis.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.DeferredSalesVsOpenAR Then

                                        Me.OpenWindow("Deferred Sales Vs Open AR Criteria", String.Format("Reporting_InitialLoadingDeferredSalesVsOpenAR.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    ElseIf DynamicReport = AdvantageFramework.Reporting.DynamicReports.GLCrossOffice Then

                                        Me.OpenWindow("GL Cross Office Criteria", String.Format("Reporting_InitialLoadingGLCrossOffice.aspx?UserDefinedReportID={0}", UserDefinedReportID), 525, 875, True, True)

                                    Else

                                        Session("UserDefinedReportID") = UserDefinedReportID

                                        Me.OpenWindow("", "Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

                                    End If

                                End If

                            Else

                                Session("UserDefinedReportID") = CurrentGridDataItem.GetDataKeyValue("ID")

                                MiscFN.ResponseRedirect("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

                            End If

                        End If

                    End Using

            End Select

        Else

            If e.CommandName = Telerik.Web.UI.RadGrid.PageCommandName Then

                ChangeTabs()

            End If

        End If

    End Sub
    Private Sub RadGridDynamic_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDynamic.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim DynamicReportTemplateID As Integer = 0
        Dim DynamicReportType As Integer = 0
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

        Try

            If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

                CurrentGridDataItem = RadGridDynamic.Items(e.Item.ItemIndex)

            End If

        Catch ex As Exception
            CurrentGridDataItem = Nothing
        End Try

        If CurrentGridDataItem IsNot Nothing Then

            Try

                DynamicReportTemplateID = CurrentGridDataItem.GetDataKeyValue("ID")

            Catch ex As Exception
                DynamicReportTemplateID = 0
            End Try

            Try

                DynamicReportType = CurrentGridDataItem.GetDataKeyValue("DatasetTypeID")

            Catch ex As Exception
                DynamicReportType = 0
            End Try

            If DynamicReportTemplateID > 0 AndAlso DynamicReportType > 0 Then

                Session("DRPT_UseBlankData") = True
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_Data") = Nothing

                Session("DRPT_Criteria") = Nothing
                Session("DRPT_FilterString") = Nothing
                Session("DRPT_From") = Nothing
                Session("DRPT_To") = Nothing
                Session("DRPT_ShowJobsWithNoDetails") = Nothing
                Session("DRPT_ParameterDictionary") = Nothing
                Session("DRPT_Type") = Nothing
                Session("DRPT_ShowGroupByBox") = Nothing
                Session("DRPT_ShowViewCaption") = Nothing
                Session("DRPT_ShowAutoFilterRow") = Nothing
                Session("DRPT_ActiveFilter") = Nothing
                Session("DRPT_ColumnsList") = Nothing
                Session("DRPT_Layout") = Nothing
                Session("DRPT_UDRCategory") = Nothing
                Session("DRPT_Description") = Nothing
                Session("DRPT_ViewOnly") = Nothing

                Session("DRPT_Type") = DynamicReportType
                Session("DRPT_ViewOnly") = True

                Try

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, DynamicReportTemplateID)

                        If DynamicReport IsNot Nothing Then

                            Session("DRPT_UDRCategory") = DynamicReport.UserDefinedReportCategoryID
                            Session("DRPT_Description") = DynamicReport.Description

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Select Case e.CommandName

                    Case "EditReport"

                        Me.OpenWindow("", [String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", CurrentGridDataItem.GetDataKeyValue("ID")))

                    Case "ViewReport"

                        If DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.VendorContracts OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

                            Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoading.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

                            Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingMediaResults.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlan Then

                            Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingMediaPlan.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSummary OrElse
                                DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask Then

                            Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule Then

                            Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ClientPL Then

                            Me.OpenWindow("Client PL Inital Criteria", String.Format("Reporting_InitialLoadingPostPeriod.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EstimatedAndActualIncome Then

                            Me.OpenWindow("Estimated and Actual Income Inital Criteria", String.Format("Reporting_InitialLoadingEstimatedAndActualIncome.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus Then

                            Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DigitalResultsComparison Then

                            Me.OpenWindow("Digital Results Comparison Criteria", String.Format("Reporting_InitialLoadingDigitalResultsComparison.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary Then

                            Me.OpenWindow("Media Current Status Summary Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonSummary Then

                            Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

                            Me.OpenWindow("AR Open Aged Criteria", String.Format("Reporting_InitialLoadingAROpenAged.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ServiceFee Then

                            Me.OpenWindow("Service Fee Criteria", String.Format("Reporting_InitialLoadingServiceFee.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.Campaign Then

                            Me.OpenWindow("Campaign Criteria", String.Format("Reporting_InitialLoadingCampaign.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CashAnalysis Then

                            Me.OpenWindow("Cash Analysis Criteria", String.Format("Reporting_InitialLoadingCashAnalysis.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SalesJournal OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SalesJournalWithComments Then

                            Me.OpenWindow("Sales Journal Criteria", String.Format("Reporting_InitialLoadingSalesJournal.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail Then

                            Me.OpenWindow("General Ledger Detail Criteria", String.Format("Reporting_InitialLoadingGeneralLedgerDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMedia OrElse DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMediaSummary Then

                            Me.OpenWindow("Campaign with Production and Media Criteria", String.Format("Reporting_InitialLoadingCampaignProductionMedia.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EstimateDetailApproved Then

                            Me.OpenWindow("Estimate Detail Approved Criteria", String.Format("Reporting_InitialLoadingEstimateDetailApproved.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.Transfer Then

                            Me.OpenWindow("Transfer Criteria", String.Format("Reporting_InitialLoadingTransfer.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobWriteOff Then

                            Me.OpenWindow("Job WriteOff Criteria", String.Format("Reporting_InitialLoadingTransfer.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetail Then

                            Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

                            'Me.OpenWindow("Accounts Payable Invoice Detail Payments Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)
                            Me.OpenWindow("Accounts Payable Invoice Detail Payments Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPaidByClient Then

                            Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceWithBalanceAging Then

                            Me.OpenWindow("Accounts Payable Invoice With Balance Aging Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceWithBalanceAging.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EstimateForm Then

                            Me.OpenWindow("Estimate Criteria", String.Format("Reporting_InitialLoadingEstimate.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryAnalysis Then

                            Me.OpenWindow("Project Summary Analysis Criteria", String.Format("Reporting_InitialLoadingProjectSummaryAnalysis.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ClientPLDetail Then

                            Me.OpenWindow("Client PL Detail Criteria", String.Format("Reporting_InitialLoadingClientPLDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetProduction Then

                            Me.OpenWindow("Billing Worksheet Production Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetProduction.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetMedia Then

                            Me.OpenWindow("Billing Worksheet Media Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetMedia.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobForecast Then

                            Me.OpenWindow("Job Forecast Criteria", String.Format("Reporting_InitialLoadingJobForecast.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.OpenPurchaseOrderDetail Then

                            Me.OpenWindow("Open Purchase Order Detail", String.Format("Reporting_InitialLoadingOpenPurchaseOrderDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMProspects Then

                            Me.OpenWindow("CRM Prospects Criteria", String.Format("Reporting_InitialLoadingCRMProspects.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ARPaymentHistory Then

                            Me.OpenWindow("AR Payment History Criteria", String.Format("Reporting_InitialLoadingARPaymentHistory.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerReport Then

                            Me.OpenWindow("General Ledger Report Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", DynamicReportTemplateID, DynamicReportType), 525, 900, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.TrialBalance Then

                            Me.OpenWindow("Trial Balance Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", DynamicReportTemplateID, DynamicReportType), 525, 900, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaResultsComparisonByClientAndType Then

                            Me.OpenWindow("Media Results Comparison by Client and Type Criteria", String.Format("Reporting_InitialLoadingMediaResultsComparisonByClientAndType.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsPayableBalanceByVendor Then

                            Me.OpenWindow("Accounts Payable Balance by Vendor Criteria", String.Format("Reporting/AccountsPayableBalanceByVendorReportCriteria/{0}/0", DynamicReportTemplateID), 400, 725, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsReceivableBalanceByClient Then

                            Me.OpenWindow("Accounts Receivable Balance by Client Criteria", String.Format("Reporting/AccountsReceivableBalanceByClientReportCriteria/{0}/0", DynamicReportTemplateID), 400, 725, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SalesAndCostOfSalesByClient Then

                            Me.OpenWindow("Sales and COS by Client Criteria", String.Format("Reporting/SalesAndCostOfSalesByClientReportCriteria/{0}/0", DynamicReportTemplateID), 400, 725, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.RevenueBreakdownByClient Then

                            Me.OpenWindow("Revenue Breakdown by Client Criteria", String.Format("Reporting/RevenueBreakdownByClientReportCriteria/{0}/0", DynamicReportTemplateID), 400, 725, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                            Me.OpenWindow("Job Detail", String.Format("Reporting_InitialLoadingJobDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeUtilization Then

                            Me.OpenWindow("Employee Utilization", String.Format("Reporting_InitialLoadingEmployeeUtilization.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeForecast Then

                            Me.OpenWindow("Employee Time Forecast", String.Format("Reporting_InitialLoadingEmployeeTimeForecast.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CheckRegister Then

                            Me.OpenWindow("Check Register Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CheckRegisterWithInvoiceDetails Then

                            Me.OpenWindow("Check Register with Invoice Detail Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeInOutBoard Then

                            Me.OpenWindow("Employee In-Out Board Criteria", String.Format("Reporting_InitialLoadingEmployeeInOutBoard.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonByVendor OrElse DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonDetailByVendor Then

                            Me.OpenWindow("Media Plan Comparison Summary Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, True, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.Alerts OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Then

                            Me.OpenWindow("Alerts Inital Criteria", String.Format("Reporting_InitialLoadingAlert.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek Then

                            Me.OpenWindow("Resources Allocation by Week Inital Criteria", String.Format("Reporting_InitialLoadingResourceAllocationByWeek.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CashTransactions Then

                            Me.OpenWindow("Cash Transactions Inital Criteria", String.Format("Reporting_InitialLoadingCashTransaction.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectTime OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost Then

                            Me.OpenWindow("Direct Time Inital Criteria", String.Format("Reporting_InitialLoadingDirectTime.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost Then

                            Me.OpenWindow("Direct Indirect Time Inital Criteria", String.Format("Reporting_InitialLoadingDirectIndirectTime.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusCoopBreakout Then

                            Me.OpenWindow("Media Current Status Coop Breakout Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunction OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJobComponent OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByCampaign OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunctionMinimized OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob1Minimized OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob2Minimized Then

                            Me.OpenWindow("Job Detail Fees OOP Criteria", String.Format("Reporting_InitialLoadingJobDetailFeesOOP.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityGroupModuleAccess OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityGroupSettings OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityGroupUserSettings OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityUserModuleAccess OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityUserSettings Then

                            Me.OpenWindow("Security Criteria", String.Format("Reporting_InitialLoadingSecurity.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityUserLoginAudit Then

                            Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingSecurityUserLoginAudit.aspx?UserDefinedReportID={0}", DynamicReportTemplateID), 525, 575, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                            Me.OpenWindow("Job Project Schedule Tasks by Employee Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MonthEndMediaWIP OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MonthEndAccruedLiability OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MonthEndAccountsPayable Then

                            Me.OpenWindow("Month End Report Criteria", String.Format("Reporting_InitialLoadingMonthEndMediaWIP.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MonthEndProductionWIP Then

                            Me.OpenWindow("Month End Report Criteria", String.Format("Reporting_InitialLoadingMonthEndProductionWIP.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeHoursAllocation Then

                            Me.OpenWindow("Employee Hours Allocation Criteria", String.Format("Reporting_InitialLoadingEmployeeHoursAllocation.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.InvoiceBilledBackup Then

                            Me.OpenWindow("Invoice Billed Backup Criteria", String.Format("Reporting_InitialLoadingInvoiceBilledBackup.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CashManagementProduction Then

                            Me.OpenWindow("Cash Management Production Criteria", String.Format("Reporting_InitialLoadingCashManagementProduction.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaTrafficInstructions OrElse
                               DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaTrafficMissingInstructions Then

                            Me.OpenWindow("Media Traffic Instructions Criteria", String.Format("Reporting_InitialLoadingMediaTrafficInstructions.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 1400, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusSummary Then

                            Me.OpenWindow("Vendor Spend With EEOC and Minority Status Summary Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusDetail Then

                            Me.OpenWindow("Vendor Spend With EEOC and Minority Status Detail Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.BillingApproval Then

                            Me.OpenWindow("Billing Approval Initial Criteria", String.Format("Reporting_InitialLoadingBillingApproval.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeAnalysis Then

                            Me.OpenWindow("Employee Time Analysis Criteria", String.Format("Reporting_InitialLoadingEmployeeTimeAnalysis.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DeferredSalesVsOpenAR Then

                            Me.OpenWindow("Deferred Sales Vs Open AR Criteria", String.Format("Reporting_InitialLoadingDeferredSalesVsOpenAR.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.GLCrossOffice Then

                            Me.OpenWindow("GL Cross Office Criteria", String.Format("Reporting_InitialLoadingGLCrossOffice.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                        Else

                            Session("DRPT_UseBlankData") = False
                            Session("DRPT_DashboardLoaded") = False

                            Me.OpenWindow("", [String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID))

                        End If

                End Select

            End If

        Else

            If e.CommandName = Telerik.Web.UI.RadGrid.PageCommandName Then

                ChangeTabs()

            End If

        End If

    End Sub
    Private Sub RadGridARW_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridARW.NeedDataSource

        'objects
        Dim UserDefinedReportCategoryID As Integer = 0

        Try

            UserDefinedReportCategoryID = RadComboBoxReportCategory.SelectedValue

        Catch ex As Exception
            UserDefinedReportCategoryID = 0
        End Try

        If UserDefinedReportCategoryID > 0 Then

            RadGridARW.DataSource = AdvantageFramework.Reporting.LoadAvailableUserDefinedReports(_Session).Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

        Else

            RadGridARW.DataSource = AdvantageFramework.Reporting.LoadAvailableUserDefinedReports(_Session).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

        End If

    End Sub
    Private Sub RadGridDynamic_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDynamic.NeedDataSource

        'objects
        Dim UserDefinedReportCategoryID As Integer = 0

        Try

            UserDefinedReportCategoryID = RadComboBoxReportCategory.SelectedValue

        Catch ex As Exception
            UserDefinedReportCategoryID = 0
        End Try

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If UserDefinedReportCategoryID > 0 Then

                    RadGridDynamic.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, _Session.Application, _Session.User.ID).Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                Else

                    RadGridDynamic.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, _Session.Application, _Session.User.ID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                End If

            End Using

        End Using

    End Sub

    Private Sub RadGridARW_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridARW.ItemCreated
        Try
            If e.Item.ItemType = GridItemType.FilteringItem Then
                Dim gridfilteritem As GridFilteringItem = e.Item
                gridfilteritem("GridBoundColumnDescription").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnDatasetType").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnCreatedDate").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnCreatedByUserCode").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnUpdatedByUserCode").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnUpdatedDate").HorizontalAlign = HorizontalAlign.Center
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridDynamic_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridDynamic.ItemCreated
        Try
            If e.Item.ItemType = GridItemType.FilteringItem Then
                Dim gridfilteritem As GridFilteringItem = e.Item
                gridfilteritem("GridBoundColumnDescription").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnDatasetType").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnCreatedDate").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnCreatedByUserCode").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnUpdatedByUserCode").HorizontalAlign = HorizontalAlign.Center
                gridfilteritem("GridBoundColumnUpdatedDate").HorizontalAlign = HorizontalAlign.Center
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolBarUserDefinedReports_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarUserDefinedReports.ButtonClick
        Select Case e.Item.Value

            Case "Bookmark"

                Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
                Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
                Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
                Dim ErrorMessage As String = ""

                Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(_Session.ConnectionString, _Session.UserCode)
                QueryString = New AdvantageFramework.Web.QueryString()

                QueryString.Page = "Reporting_UserDefinedReports.aspx"

                Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_UserDefinedReports

                Bookmark.UserCode = _Session.UserCode

                Bookmark.Name = "User Defined Reports"
                Bookmark.Description = "User Defined Reports"

                Bookmark.PageURL = QueryString.ToString(True)

                Dim s As String = ""

                If BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage) = False Then

                    Me.ShowMessage(ErrorMessage)

                Else

                    'Me.RefreshBookmarksDesktopObject()

                End If

        End Select
    End Sub

#End Region

#End Region

End Class
