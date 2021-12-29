Imports Telerik.Web.UI

Public Class Reporting_DynamicReports
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _UserDefinedReportCategoriesList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) = Nothing
    Private _LoadingDatasource As Boolean = False

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

    Private Function UpdateDynamicReport(ByRef GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportUpdated As Boolean = False

        Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, GridDataItem.GetDataKeyValue("ID"))

                If DynamicReport IsNot Nothing Then

                    DynamicReport.Description = CType(GridDataItem.FindControl("TextBoxDescription"), TextBox).Text.Trim

                    If IsNumeric(CType(GridDataItem.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox).SelectedValue) Then

                        DynamicReport.UserDefinedReportCategoryID = CType(GridDataItem.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Else

                        DynamicReport.UserDefinedReportCategoryID = Nothing

                    End If

                    DynamicReport.UpdatedDate = Now
                    DynamicReport.UpdatedByUserCode = _Session.UserCode

                    DynamicReportUpdated = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                End If

            End Using

        Catch ex As Exception
            DynamicReportUpdated = False
        Finally
            UpdateDynamicReport = DynamicReportUpdated
        End Try

    End Function

#Region "  Form Event Handlers "

    Private Sub Reporting_DynamicReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).OrderBy(Function(c) c.Description).ToList
                RadComboBoxReportCategory.DataBind()
                RadComboBoxReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", ""))

                If Request.QueryString("category") <> "" Then
                    RadComboBoxReportCategory.SelectedValue = Request.QueryString("category")
                End If

                If Session("DRPT_ReportCategory") IsNot Nothing Then
                    RadComboBoxReportCategory.SelectedValue = Session("DRPT_ReportCategory")
                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportTemplates_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportTemplates.ButtonClick

        'objects
        Dim FunctionName As String = ""
        Dim DynamicReportTemplateID As Integer = 0
        Dim DynamicReportType As Integer = 0
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonAdd.Value

                Me.OpenWindow("", [String].Format("Reporting_UserDefinedReportEdit.aspx"), 0, 0, False, True)

            Case "Bookmark"

                Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
                Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
                Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
                Dim ErrorMessage As String = ""

                Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(_Session.ConnectionString, _Session.UserCode)
                QueryString = New AdvantageFramework.Web.QueryString()

                QueryString.Page = "Reporting_DynamicReports.aspx"

                QueryString.Add("category", RadComboBoxReportCategory.SelectedValue)

                QueryString.Add("bm", "1")

                Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_DynamicReports

                Bookmark.UserCode = _Session.UserCode

                Bookmark.Name = "Report Templates"

                If RadComboBoxReportCategory.SelectedValue <> "" Then
                    Bookmark.Description = "Report Templates - " & RadComboBoxReportCategory.SelectedItem.Text
                Else
                    Bookmark.Description = "Report Templates"
                End If

                Bookmark.PageURL = QueryString.ToString(True)

                Dim s As String = ""

                If BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage) = False Then

                    Me.ShowMessage(ErrorMessage)

                Else

                    'Me.RefreshBookmarksDesktopObject()

                End If

        End Select

    End Sub
    Private Sub RadGridDynamicReportTemplates_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDynamicReportTemplates.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportTemplateID As Integer = 0
        Dim DynamicReportType As Integer = 0
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridDynamicReportTemplates.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAllReports"

                For Each GridDataItem In RadGridDynamicReportTemplates.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If UpdateDynamicReport(GridDataItem) = False Then

                        Reload = False
                        Exit For

                    End If

                Next

            Case "SaveReport"

                If CurrentGridDataItem IsNot Nothing Then

                    Reload = UpdateDynamicReport(CurrentGridDataItem)

                End If

            Case "DeleteReport"

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If DynamicReport IsNot Nothing Then

                            Reload = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Delete(ReportingDbContext, DataContext, DynamicReport)

                        Else

                            Reload = False

                        End If

                    End Using

                End Using

            Case "EditReport"

                Reload = False

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
                    Session("DRPT_ViewOnly") = False
                    Session("DRPT_ReportCategory") = RadComboBoxReportCategory.SelectedValue
                    Session("DRPT_Data") = Nothing

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

                    Me.OpenWindow("", [String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", CurrentGridDataItem.GetDataKeyValue("ID")))

                End If

            Case "ViewReport"

                Reload = False

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
                    Session("DRPT_ViewOnly") = False
                    Session("DRPT_ReportCategory") = RadComboBoxReportCategory.SelectedValue
                    Session("DRPT_Data") = Nothing

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

                    If DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ServiceFeeContract OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.IncomeOnly OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.VendorContracts OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

                        Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoading.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

                        Me.OpenWindow("Media Results Criteria", String.Format("Reporting_InitialLoadingMediaResults.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlan Then

                        Me.OpenWindow("Media Plan Criteria", String.Format("Reporting_InitialLoadingMediaPlan.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 675, False, True)

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

                        Me.OpenWindow("Estimated and Actual Income Inital Criteria", String.Format("Reporting_InitialLoadingEstimatedAndActualIncome.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus Then

                        Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DigitalResultsComparison Then

                        Me.OpenWindow("Digital Results Comparison Criteria", String.Format("Reporting_InitialLoadingDigitalResultsComparison.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary Then

                        Me.OpenWindow("Media Current Status Summary Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonSummary Then

                        Me.OpenWindow("Media Plan Comparison Summary Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

                        Me.OpenWindow("AR Open Aged Criteria", String.Format("Reporting_InitialLoadingAROpenAged.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ServiceFee Then

                        Me.OpenWindow("Service Fee Criteria", String.Format("Reporting_InitialLoadingServiceFee.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.Campaign Then

                        Me.OpenWindow("Campaign Criteria", String.Format("Reporting_InitialLoadingCampaign.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CashAnalysis Then

                        Me.OpenWindow("Cash Transactions", String.Format("Reporting_InitialLoadingCashAnalysis.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CashTransactions Then

                        Me.OpenWindow("Cash Transactions", String.Format("Reporting_InitialLoadingCashTransaction.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SalesJournal OrElse
                           DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SalesJournalWithComments Then

                        Me.OpenWindow("Sales Journal Criteria", String.Format("Reporting_InitialLoadingSalesJournal.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail Then

                        Me.OpenWindow("General Ledger Detail Criteria", String.Format("Reporting_InitialLoadingGeneralLedgerDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMedia OrElse DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMediaSummary Then

                        Me.OpenWindow("Campaign with Production and Media Criteria", String.Format("Reporting_InitialLoadingCampaignProductionMedia.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EstimateDetailApproved Then

                        Me.OpenWindow("Estimate Detail Approved", String.Format("Reporting_InitialLoadingEstimateDetailApproved.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.Transfer Then

                        Me.OpenWindow("Transfer Criteria", String.Format("Reporting_InitialLoadingTransfer.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobWriteOff Then

                        Me.OpenWindow("Job WtriteOff Criteria", String.Format("Reporting_InitialLoadingJobWriteOff.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetail Then

                        Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

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

                        'Me.OpenWindow("Refresh?", String.Format("Reporting_InitialLoadingRefreshData.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 200, 500, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeUtilization Then

                        Me.OpenWindow("Employee Utilization", String.Format("Reporting_InitialLoadingEmployeeUtilization.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeForecast Then

                        Me.OpenWindow("Employee Time Forecast", String.Format("Reporting_InitialLoadingEmployeeTimeForecast.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CheckRegister _
                            Or DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CheckRegisterWithInvoiceDetails Then

                        Me.OpenWindow("Check Register Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeInOutBoard Then

                        Me.OpenWindow("Employee In-Out Board Criteria", String.Format("Reporting_InitialLoadingEmployeeInOutBoard.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonByVendor OrElse DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonDetailByVendor Then

                        Me.OpenWindow("Media Plan Comparison Summary By Vendor Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Alerts OrElse
                           Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments OrElse
                            Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Then

                        Me.OpenWindow("Alerts Inital Criteria", String.Format("Reporting_InitialLoadingAlert.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek Then

                        Me.OpenWindow("Resources Allocation by Week Inital Criteria", String.Format("Reporting_InitialLoadingResourceAllocationByWeek.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectTime Then

                        Me.OpenWindow("Direct Time Inital Criteria", String.Format("Reporting_InitialLoadingDirectTime.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime Then

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

                        Me.OpenWindow("Security Criteria", String.Format("Reporting_InitialLoadingSecurity.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityUserLoginAudit Then

                        Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingSecurityUserLoginAudit.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                        Me.OpenWindow("Task By Employee Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MonthEndMediaWIP OrElse
                           DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MonthEndAccruedLiability OrElse
                           DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MonthEndAccountsPayable Then

                        Me.OpenWindow("Month End Report Criteria", String.Format("Reporting_InitialLoadingMonthEndMediaWIP.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

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


                    Else

                        Session("DRPT_UseBlankData") = False
                        Session("DRPT_DashboardLoaded") = False

                        Me.OpenWindow("", [String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID))

                    End If

                End If

        End Select

        If Reload Then

            RadGridDynamicReportTemplates.Rebind()

        End If

    End Sub
    Private Sub RadGridDynamicReportTemplates_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDynamicReportTemplates.ItemDataBound

        'objects
        Dim DropDownListReportCategory As Telerik.Web.UI.RadComboBox = Nothing
        Dim FilterDropDownListReportCategory As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonView As System.Web.UI.WebControls.ImageButton = Nothing

        If _UserDefinedReportCategoriesList Is Nothing Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _UserDefinedReportCategoriesList = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).ToList

            End Using

        End If

        Try

            DropDownListReportCategory = DirectCast(e.Item.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox)

            If DropDownListReportCategory IsNot Nothing Then

                DropDownListReportCategory.DataSource = (From UserDefinedReportCategory In _UserDefinedReportCategoriesList
                                                         Select UserDefinedReportCategory.ID,
                                                                UserDefinedReportCategory.Description).OrderBy(Function(c) c.Description).ToList

                DropDownListReportCategory.DataBind()

                DropDownListReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    DropDownListReportCategory.SelectedValue = e.Item.DataItem.ReportCategoryID

                End If

            End If

        Catch ex As Exception
            DropDownListReportCategory = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

                    End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

        'Try
        '    If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

        '        Dim dataitem As GridDataItem = e.Item

        '        ImageButtonView = DirectCast(e.Item.FindControl("ImageButtonView"), ImageButton)

        '        If ImageButtonView IsNot Nothing And dataitem.GetDataKeyValue("DatasetTypeID") = 6 Then

        '            ImageButtonView.Attributes.Add("OnClientClick", "RefreshClick();")

        '        End If

        '    End If

        'Catch ex As Exception
        '    ImageButtonView = Nothing
        'End Try

    End Sub
    Private Sub RadGridDynamicReportTemplates_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDynamicReportTemplates.NeedDataSource

        'objects
        Dim UserDefinedReportCategoryID As Integer = 0

        _LoadingDatasource = True

        RadGridDynamicReportTemplates.PageSize = MiscFN.LoadPageSize(RadGridDynamicReportTemplates.ID)

        Try

            If String.IsNullOrWhiteSpace(RadComboBoxReportCategory.SelectedValue) = False Then

                UserDefinedReportCategoryID = RadComboBoxReportCategory.SelectedValue

            End If

        Catch ex As Exception
            UserDefinedReportCategoryID = 0
        End Try

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If UserDefinedReportCategoryID > 0 Then

                    RadGridDynamicReportTemplates.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, _Session.Application, _Session.User.ID).Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                Else

                    RadGridDynamicReportTemplates.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, _Session.Application, _Session.User.ID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                End If

            End Using

        End Using

        _LoadingDatasource = False

    End Sub
    Private Sub RadGridDynamicReportTemplates_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridDynamicReportTemplates.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(RadGridDynamicReportTemplates.ID, e.NewPageSize)

        End If

    End Sub
    Private Sub RadComboBoxReportCategory_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxReportCategory.SelectedIndexChanged

        RadGridDynamicReportTemplates.Rebind()

    End Sub

#End Region

#End Region

End Class
