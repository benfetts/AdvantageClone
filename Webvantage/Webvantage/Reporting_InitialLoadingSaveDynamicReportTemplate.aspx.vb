Public Class Reporting_InitialLoadingSaveDynamicReportTemplate
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected _DynamicReportTemplateID As Integer = 0
    Protected _DynamicReportType As Integer = 0
    Protected _DynamicReportShowGroupByBox As Boolean = False
    Protected _DynamicReportShowViewCaption As Boolean = False
    Protected _DynamicReportShowAutoFilterRow As Boolean = False
    Protected _DynamicReportActiveFilter As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadDynamicReport()

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            _DynamicReportType = Session("DRPT_Type")

        Catch ex As Exception
            _DynamicReportType = 0
        End Try

        Try

            _DynamicReportShowGroupByBox = Session("DRPT_ShowGroupByBox")

        Catch ex As Exception
            _DynamicReportShowGroupByBox = False
        End Try

        Try

            _DynamicReportShowViewCaption = Session("DRPT_ShowViewCaption")

        Catch ex As Exception
            _DynamicReportShowViewCaption = False
        End Try

        Try

            _DynamicReportShowAutoFilterRow = Session("DRPT_ShowAutoFilterRow")

        Catch ex As Exception
            _DynamicReportShowAutoFilterRow = False
        End Try

        Try

            _DynamicReportActiveFilter = Session("DRPT_ActiveFilter")

        Catch ex As Exception
            _DynamicReportActiveFilter = ""
        End Try

    End Sub


#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingSaveDynamicReportTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each KeyValuePair In AdvantageFramework.Reporting.LoadAvailableDynamicReportDataSets(_Session)

                    RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(KeyValuePair.Value, KeyValuePair.Key))

                Next

                RadComboBoxReportType.SelectedIndex = 0

                PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Reporting.Database.Entities.DynamicReport.Properties.Description)

                If PropertyDescriptor IsNot Nothing Then

                    TextBoxDescription.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                End If

                RadComboBoxReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).OrderBy(Function(c) c.Description).ToList
                RadComboBoxReportCategory.DataBind()
                RadComboBoxReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                If _DynamicReportTemplateID > 0 Then

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                End If

                LabelQuestion.Text = "Do you want to save your changes?"

                RadComboBoxReportType.Visible = False
                TextBoxDescription.Visible = False
                RadComboBoxReportCategory.Visible = False
                LabelReportType.Visible = False
                LabelDescription.Visible = False
                LabelReportCategory.Visible = False

                If DynamicReport IsNot Nothing Then

                    'LabelQuestion.Text = "Do you want to save changes to your existing template?"
                    'RadComboBoxReportType.Visible = False
                    'TextBoxDescription.Visible = False
                    'RadComboBoxReportCategory.Visible = False
                    RadComboBoxReportType.SelectedValue = DynamicReport.Type
                    TextBoxDescription.Text = DynamicReport.Description
                    RadComboBoxReportCategory.SelectedValue = If(DynamicReport.UserDefinedReportCategoryID.HasValue, DynamicReport.UserDefinedReportCategoryID, "")
                    'LabelReportType.Visible = False
                    'LabelDescription.Visible = False
                    'LabelReportCategory.Visible = False

                Else

                    'LabelQuestion.Text = "Do you want to create a new template?"
                    'RadComboBoxReportType.Visible = True
                    'TextBoxDescription.Visible = True
                    'RadComboBoxReportCategory.Visible = True
                    RadComboBoxReportType.SelectedValue = Session("DRPT_Type")
                    TextBoxDescription.Text = Session("DRPT_Description")
                    RadComboBoxReportCategory.SelectedValue = Session("DRPT_UDRCategory")
                    'LabelReportType.Visible = True
                    'LabelDescription.Visible = True
                    'LabelReportCategory.Visible = True

                End If

                RadComboBoxReportType.Enabled = False

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportTemplates_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportTemplates.ButtonClick

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport
        Dim DynamicReportColList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumnList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn) = Nothing
        Dim DynamicReportCol As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
        Dim ContinueSaving As Boolean = False
        Dim IsAddingTemplate As Boolean = False
        Dim UserDefinedReportCategoryID As Nullable(Of Integer) = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonYes.Value

                If TextBoxDescription.Text <> "" Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            UserDefinedReportCategoryID = RadComboBoxReportCategory.SelectedValue

                        Catch ex As Exception
                            UserDefinedReportCategoryID = Nothing
                        End Try

                        If _DynamicReportTemplateID > 0 Then

                            DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                        End If

                        If DynamicReport Is Nothing Then

                            DynamicReport = New AdvantageFramework.Reporting.Database.Entities.DynamicReport
                            IsAddingTemplate = True

                        End If

                        DynamicReport.Type = _DynamicReportType
                        DynamicReport.ShowGroupByBox = _DynamicReportShowGroupByBox
                        DynamicReport.ShowViewCaption = _DynamicReportShowViewCaption
                        DynamicReport.ShowAutoFilterRow = _DynamicReportShowAutoFilterRow
                        DynamicReport.ShowAutoFilterRow = _DynamicReportShowAutoFilterRow
                        DynamicReport.ActiveFilter = _DynamicReportActiveFilter

                        DynamicReport.DbContext = ReportingDbContext
                        DynamicReport.Description = TextBoxDescription.Text
                        DynamicReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID
                        DynamicReport.AllowCellMerge = False
                        DynamicReport.AutoSizeColumnsWhenPrinting = False
                        DynamicReport.PrintHeader = False
                        DynamicReport.PrintFooter = False
                        DynamicReport.PrintGroupFooter = False
                        DynamicReport.PrintSelectedRowsOnly = False
                        DynamicReport.PrintFilterInformation = False

                        If IsAddingTemplate Then

                            DynamicReport.CreatedByUserCode = ReportingDbContext.UserCode
                            DynamicReport.CreatedDate = Now

                        End If

                        DynamicReport.UpdatedByUserCode = ReportingDbContext.UserCode
                        DynamicReport.UpdatedDate = Now

                        If IsAddingTemplate Then

                            ContinueSaving = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, DynamicReport)

                        Else

                            ContinueSaving = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                        End If

                        If ContinueSaving Then

                            _DynamicReportTemplateID = DynamicReport.ID

                            DynamicReportColList = Session("DRPT_ColumnsList")

                            If IsAddingTemplate Then

                                For Each DynamicReportCol In DynamicReportColList

                                    AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, DynamicReportCol.FieldName,
                                                                                                      DynamicReportCol.HeaderText, DynamicReportCol.IsVisible, DynamicReportCol.SortIndex,
                                                                                                      DynamicReportCol.SortOrder, DynamicReportCol.GroupIndex, DynamicReportCol.Width,
                                                                                                      DynamicReportCol.VisibleIndex, Nothing, Nothing)

                                Next

                            Else

                                DynamicReportColumnList = AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).ToList

                                For Each DynamicReportCol In DynamicReportColList

                                    Try

                                        DynamicReportColumn = DynamicReportColumnList.Single(Function(Entity) Entity.FieldName = DynamicReportCol.FieldName)

                                    Catch ex As Exception
                                        DynamicReportColumn = Nothing
                                    End Try

                                    If DynamicReportColumn Is Nothing Then

                                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, DynamicReportCol.FieldName,
                                                                                                          DynamicReportCol.HeaderText, DynamicReportCol.IsVisible, DynamicReportCol.SortIndex,
                                                                                                          DynamicReportCol.SortOrder, DynamicReportCol.GroupIndex, DynamicReportCol.Width,
                                                                                                          DynamicReportCol.VisibleIndex, Nothing, Nothing)
                                    Else

                                        DynamicReportColumn.DbContext = ReportingDbContext
                                        DynamicReportColumn.HeaderText = DynamicReportCol.HeaderText
                                        DynamicReportColumn.IsVisible = DynamicReportCol.IsVisible
                                        DynamicReportColumn.SortIndex = DynamicReportCol.SortIndex
                                        DynamicReportColumn.SortOrder = DynamicReportCol.SortOrder
                                        DynamicReportColumn.GroupIndex = DynamicReportCol.GroupIndex
                                        DynamicReportColumn.Width = DynamicReportCol.Width
                                        DynamicReportColumn.VisibleIndex = DynamicReportCol.VisibleIndex

                                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Update(ReportingDbContext, DynamicReportColumn)

                                    End If

                                Next

                            End If

                            If Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ServiceFeeContract OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.IncomeOnly OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorContracts OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

                                Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoading.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

                                Me.OpenWindow("Media Results Criteria", String.Format("Reporting_InitialLoadingMediaResults.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlan Then

                                Me.OpenWindow("Media Plan Criteria", String.Format("Reporting_InitialLoadingMediaPlan.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummary OrElse
                               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask Then

                                Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule Then

                                Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ClientPL Then

                                Me.OpenWindow("Client PL Inital Criteria", String.Format("Reporting_InitialLoadingPostPeriod.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimatedAndActualIncome Then

                                Me.OpenWindow("Estimated and Actual Income Inital Criteria", String.Format("Reporting_InitialLoadingEstimatedAndActualIncome.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus Then

                                Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DigitalResultsComparison Then

                                Me.OpenWindow("Digital Results Comparison Criteria", String.Format("Reporting_InitialLoadingDigitalResultsComparison.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary Then

                                Me.OpenWindow("Media Current Status Summary Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonSummary Then

                                Me.OpenWindow("Media Plan Comparison Summary Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

                                Me.OpenWindow("AR Open Aged Criteria", String.Format("Reporting_InitialLoadingAROpenAged.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ServiceFee Then

                                Me.OpenWindow("Service Fee Criteria", String.Format("Reporting_InitialLoadingServiceFee.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Campaign Then

                                Me.OpenWindow("Campaign Criteria", String.Format("Reporting_InitialLoadingCampaign.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashAnalysis Then

                                Me.OpenWindow("Cash Analysis Criteria", String.Format("Reporting_InitialLoadingCashAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashTransactions Then

                                Me.OpenWindow("Cash Analysis Criteria", String.Format("Reporting_InitialLoadingCashTransaction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesJournal OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesJournalWithComments Then

                                Me.OpenWindow("Sales Journal Criteria", String.Format("Reporting_InitialLoadingSalesJournal.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail Then

                                Me.OpenWindow("General Ledger Detail Criteria", String.Format("Reporting_InitialLoadingGeneralLedgerDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMedia OrElse Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMediaSummary Then

                                Me.OpenWindow("Campaign with Production and Media Criteria", String.Format("Reporting_InitialLoadingCampaignProductionMedia.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimateDetailApproved Then

                                Me.OpenWindow("Estimate Detail Approved Criteria", String.Format("Reporting_InitialLoadingEstimateDetailApproved.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Transfer Then

                                Me.OpenWindow("Transfer Criteria", String.Format("Reporting_InitialLoadingTransfer.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobWriteOff Then

                                Me.OpenWindow("Job WriteOff Criteria", String.Format("Reporting_InitialLoadingJobWriteOff.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetail Then

                                Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

                                'Me.OpenWindow("Accounts Payable Invoice Detail Payments Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)
                                Me.OpenWindow("Accounts Payable Invoice Detail Payments Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPaidByClient Then

                                Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceWithBalanceAging Then

                                Me.OpenWindow("Accounts Payable Invoice With Balance Aging Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceWithBalanceAging.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimateForm Then

                                Me.OpenWindow("Estimate Criteria", String.Format("Reporting_InitialLoadingEstimate.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryAnalysis Then

                                Me.OpenWindow("Project Summary Analysis Criteria", String.Format("Reporting_InitialLoadingProjectSummaryAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ClientPLDetail Then

                                Me.OpenWindow("Client PL Detail Criteria", String.Format("Reporting_InitialLoadingClientPLDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetProduction Then

                                Me.OpenWindow("Billing Worksheet Production Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetProduction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetMedia Then

                                Me.OpenWindow("Billing Worksheet Media Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetMedia.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobForecast Then

                                Me.OpenWindow("Job Forecast Criteria", String.Format("Reporting_InitialLoadingJobForecast.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.OpenPurchaseOrderDetail Then

                                Me.OpenWindow("Open Purchase Order Detail", String.Format("Reporting_InitialLoadingOpenPurchaseOrderDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMProspects Then

                                Me.OpenWindow("CRM Prospects Criteria", String.Format("Reporting_InitialLoadingCRMProspects.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ARPaymentHistory Then

                                Me.OpenWindow("AR Payment History Criteria", String.Format("Reporting_InitialLoadingARPaymentHistory.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerReport Then

                                Me.OpenWindow("General Ledger Report Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", _DynamicReportTemplateID, Session("DRPT_Type")), 525, 900, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.TrialBalance Then

                                Me.OpenWindow("Trial Balance Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", _DynamicReportTemplateID, Session("DRPT_Type")), 525, 900, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaResultsComparisonByClientAndType Then

                                Me.OpenWindow("Media Results Comparison by Client and Type Criteria", String.Format("Reporting_InitialLoadingMediaResultsComparisonByClientAndType.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableBalanceByVendor Then

                                Me.OpenWindow("Accounts Payable Balance by Vendor Criteria", String.Format("Reporting/AccountsPayableBalanceByVendorReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsReceivableBalanceByClient Then

                                Me.OpenWindow("Accounts Receivable Balance by Client Criteria", String.Format("Reporting/AccountsReceivableBalanceByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesAndCostOfSalesByClient Then

                                Me.OpenWindow("Sales and COS by Client Criteria", String.Format("Reporting/SalesAndCostOfSalesByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.RevenueBreakdownByClient Then

                                Me.OpenWindow("Revenue Breakdown by Client Criteria", String.Format("Reporting/RevenueBreakdownByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                                Me.OpenWindow("Job Detail", String.Format("Reporting_InitialLoadingJobDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeUtilization Then

                                Me.OpenWindow("Employee Utilization", String.Format("Reporting_InitialLoadingEmployeeUtilization.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CheckRegister _
                                Or Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CheckRegisterWithInvoiceDetails Then

                                Me.OpenWindow("Check Register Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeInOutBoard Then

                                Me.OpenWindow("Employee In-Out Board Criteria", String.Format("Reporting_InitialLoadingEmployeeInOutBoard.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonByVendor OrElse Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonDetailByVendor Then

                                Me.OpenWindow("Media Plan Comparison Summary By Vendor Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Alerts OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Then

                                Me.OpenWindow("Alerts Inital Criteria", String.Format("Reporting_InitialLoadingAlert.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek Then

                                Me.OpenWindow("Resources Allocation by Week Inital Criteria", String.Format("Reporting_InitialLoadingResourceAllocationByWeek.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectTime Then

                                Me.OpenWindow("Direct Time Inital Criteria", String.Format("Reporting_InitialLoadingDirectTime.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusCoopBreakout Then

                                Me.OpenWindow("Media Current Status Coop Breakout Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunction OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJobComponent OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByCampaign OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunctionMinimized OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob1Minimized OrElse
                                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob2Minimized Then

                                Me.OpenWindow("Job Detail Fees OOP Criteria", String.Format("Reporting_InitialLoadingJobDetailFeesOOP.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupModuleAccess OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupSettings OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupUserSettings OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserModuleAccess OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserSettings Then

                                Me.OpenWindow("Security Criteria", String.Format("Reporting_InitialLoadingSecurity.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserLoginAudit Then

                                Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingSecurityUserLoginAudit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndMediaWIP OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndAccruedLiability OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndAccountsPayable Then

                                Me.OpenWindow("Month End Report Criteria", String.Format("Reporting_InitialLoadingMonthEndMediaWIP.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                                Me.OpenWindow("Job Project Schedule Tasks by Employee Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeHoursAllocation Then

                                Me.OpenWindow("Employee Hours Allocation Inital Criteria", String.Format("Reporting_InitialLoadingEmployeeHoursAllocation.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.InvoiceBilledBackup Then

                                Me.OpenWindow("Invoice Billed Backup Inital Criteria", String.Format("Reporting_InitialLoadingInvoiceBilledBackup.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashManagementProduction Then

                                Me.OpenWindow("Cash Management Production Inital Criteria", String.Format("Reporting_InitialLoadingCashManagementProduction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficInstructions OrElse
                                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficMissingInstructions Then

                                Me.OpenWindow("Media Traffic Instructions Criteria", String.Format("Reporting_InitialLoadingMediaTrafficInstructions.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 1400, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusSummary Then

                                Me.OpenWindow("Vendor Spend With EEOC and Minority Status Summary Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusDetail Then

                                Me.OpenWindow("Vendor Spend With EEOC and Minority Status Detail Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingApproval Then

                                Me.OpenWindow("Billing Approval Initial Criteria", String.Format("Reporting_InitialLoadingBillingApproval.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                            ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeAnalysis Then

                                Me.OpenWindow("Employee Time Analysis Inital Criteria", String.Format("Reporting_InitialLoadingEmployeeTimeAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                            Else

                                Session("DRPT_UseBlankData") = False
                                Session("DRPT_DashboardLoaded") = False

                                If _DynamicReportTemplateID <> 0 Then

                                    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                                Else

                                    Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                                End If

                            End If

                        End If

                    End Using

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please enter a description")

                End If

            Case RadToolBarButtonNo.Value

                If Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorContracts OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

                    Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoading.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

                    Me.OpenWindow("Media Results Criteria", String.Format("Reporting_InitialLoadingMediaResults.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlan Then

                    Me.OpenWindow("Media Plan Criteria", String.Format("Reporting_InitialLoadingMediaPlan.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummary OrElse
                        Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask Then

                    Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule Then

                    Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ClientPL Then

                    Me.OpenWindow("Client PL Inital Criteria", String.Format("Reporting_InitialLoadingPostPeriod.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimatedAndActualIncome Then

                    Me.OpenWindow("Estimated and Actual Income Inital Criteria", String.Format("Reporting_InitialLoadingEstimatedAndActualIncome.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus Then

                    Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DigitalResultsComparison Then

                    Me.OpenWindow("Digital Results Comparison Criteria", String.Format("Reporting_InitialLoadingDigitalResultsComparison.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary Then

                    Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonSummary Then

                    Me.OpenWindow("Media Plan Comparison Summary Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

                    Me.OpenWindow("AR Open Aged Criteria", String.Format("Reporting_InitialLoadingAROpenAged.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ServiceFee Then

                    Me.OpenWindow("Service Fee Criteria", String.Format("Reporting_InitialLoadingServiceFee.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Campaign Then

                    Me.OpenWindow("Campaign Criteria", String.Format("Reporting_InitialLoadingCampaign.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashAnalysis Then

                    Me.OpenWindow("Cash Analysis Criteria", String.Format("Reporting_InitialLoadingCashAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashTransactions Then

                    Me.OpenWindow("Cash Analysis Criteria", String.Format("Reporting_InitialLoadingCashTransaction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesJournal OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesJournalWithComments Then

                    Me.OpenWindow("Sales Journal Criteria", String.Format("Reporting_InitialLoadingSalesJournal.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMedia OrElse Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMediaSummary Then

                    Me.OpenWindow("Campaign with Production and Media Criteria", String.Format("Reporting_InitialLoadingCampaignProductionMedia.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimateDetailApproved Then

                    Me.OpenWindow("Estimate Detail Approved Criteria", String.Format("Reporting_InitialLoadingEstimateDetailApproved.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Transfer Then

                    Me.OpenWindow("Transfer Criteria", String.Format("Reporting_InitialLoadingTransfer.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail Then

                    Me.OpenWindow("General Ledger Detail Criteria", String.Format("Reporting_InitialLoadingGeneralLedgerDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobWriteOff Then

                    Me.OpenWindow("Job WriteOff Criteria", String.Format("Reporting_InitialLoadingJobWriteOff.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetail Then

                    Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

                    Me.OpenWindow("Accounts Payable Invoice Detail Payments Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPaidByClient Then

                    Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceWithBalanceAging Then

                    Me.OpenWindow("Accounts Payable Invoice With Balance Aging Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceWithBalanceAging.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimateForm Then

                    Me.OpenWindow("Estimate Criteria", String.Format("Reporting_InitialLoadingEstimate.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryAnalysis Then

                    Me.OpenWindow("Project Summary Analysis Criteria", String.Format("Reporting_InitialLoadingProjectSummaryAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ClientPLDetail Then

                    Me.OpenWindow("Client PL Detail Criteria", String.Format("Reporting_InitialLoadingClientPLDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetProduction Then

                    Me.OpenWindow("Billing Worksheet Production Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetProduction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetMedia Then

                    Me.OpenWindow("Billing Worksheet Media Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetMedia.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobForecast Then

                    Me.OpenWindow("Job Forecast Criteria", String.Format("Reporting_InitialLoadingJobForecast.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.OpenPurchaseOrderDetail Then

                    Me.OpenWindow("Open Purchase Order Detail", String.Format("Reporting_InitialLoadingOpenPurchaseOrderDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMProspects Then

                    Me.OpenWindow("CRM Prospects Criteria", String.Format("Reporting_InitialLoadingCRMProspects.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ARPaymentHistory Then

                    Me.OpenWindow("AR Payment History Criteria", String.Format("Reporting_InitialLoadingARPaymentHistory.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerReport Then

                    Me.OpenWindow("General Ledger Report Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", _DynamicReportTemplateID, Session("DRPT_Type")), 525, 900, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.TrialBalance Then

                    Me.OpenWindow("Trial Balance Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", _DynamicReportTemplateID, Session("DRPT_Type")), 525, 900, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaResultsComparisonByClientAndType Then

                    Me.OpenWindow("Media Results Comparison by Client and Type Criteria", String.Format("Reporting_InitialLoadingMediaResultsComparisonByClientAndType.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableBalanceByVendor Then

                    Me.OpenWindow("Accounts Payable Balance by Vendor Criteria", String.Format("Reporting/AccountsPayableBalanceByVendorReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsReceivableBalanceByClient Then

                    Me.OpenWindow("Accounts Receivable Balance by Client Criteria", String.Format("Reporting/AccountsReceivableBalanceByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesAndCostOfSalesByClient Then

                    Me.OpenWindow("Sales and COS by Client Criteria", String.Format("Reporting/SalesAndCostOfSalesByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.RevenueBreakdownByClient Then

                    Me.OpenWindow("Revenue Breakdown by Client Criteria", String.Format("Reporting/RevenueBreakdownByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                    Me.OpenWindow("Job Detail", String.Format("Reporting_InitialLoadingJobDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeUtilization Then

                    Me.OpenWindow("Employee Utilization", String.Format("Reporting_InitialLoadingEmployeeUtilization.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CheckRegister _
                    Or Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CheckRegisterWithInvoiceDetails Then

                    Me.OpenWindow("Check Register Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeInOutBoard Then

                    Me.OpenWindow("Employee In-Out Board Criteria", String.Format("Reporting_InitialLoadingEmployeeInOutBoard.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonByVendor OrElse Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonDetailByVendor Then

                    Me.OpenWindow("Media Plan Comparison Summary By Vendor Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Alerts OrElse
                           Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments OrElse
                            Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Then

                    Me.OpenWindow("Alerts Inital Criteria", String.Format("Reporting_InitialLoadingAlert.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek Then

                    Me.OpenWindow("Resources Allocation by Week Inital Criteria", String.Format("Reporting_InitialLoadingResourceAllocationByWeek.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectTime Then

                    Me.OpenWindow("Direct Time Inital Criteria", String.Format("Reporting_InitialLoadingDirectTime.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusCoopBreakout Then

                    Me.OpenWindow("Media Current Status Coop Breakout Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunction OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJobComponent OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByCampaign OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunctionMinimized OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob1Minimized OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob2Minimized Then

                    Me.OpenWindow("Job Detail Fees OOP Criteria", String.Format("Reporting_InitialLoadingJobDetailFeesOOP.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupModuleAccess OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupSettings OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupUserSettings OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserModuleAccess OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserSettings Then

                    Me.OpenWindow("Security Criteria", String.Format("Reporting_InitialLoadingSecurity.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserLoginAudit Then

                    Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingSecurityUserLoginAudit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                    Me.OpenWindow("Project Schedule Tasks By Employee Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndMediaWIP OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndAccruedLiability OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndAccountsPayable Then

                    Me.OpenWindow("Month End Report Criteria", String.Format("Reporting_InitialLoadingMonthEndMediaWIP.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeHoursAllocation Then

                    Me.OpenWindow("Employee Hours Allocation Criteria", String.Format("Reporting_InitialLoadingEmployeeHoursAllocation.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.InvoiceBilledBackup Then

                    Me.OpenWindow("Invoice Billed Backup Criteria", String.Format("Reporting_InitialLoadingInvoiceBilledBackup.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashManagementProduction Then

                    Me.OpenWindow("Cash Management Production Criteria", String.Format("Reporting_InitialLoadingCashManagementProduction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficInstructions OrElse
                       Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficMissingInstructions Then

                    Me.OpenWindow("Media Traffic Instructions Criteria", String.Format("Reporting_InitialLoadingMediaTrafficInstructions.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 1400, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusSummary Then

                    Me.OpenWindow("Vendor Spend With EEOC and Minority Status Summary Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusDetail Then

                    Me.OpenWindow("Vendor Spend With EEOC and Minority Status Detail Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingApproval Then

                    Me.OpenWindow("Billing Approval Initial Criteria", String.Format("Reporting_InitialLoadingBillingApproval.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeAnalysis Then

                    Me.OpenWindow("Employee Time Analysis Criteria", String.Format("Reporting_InitialLoadingEmployeeTimeAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, True, True)

                Else

                    Session("DRPT_UseBlankData") = False
                    Session("DRPT_DashboardLoaded") = False

                    If _DynamicReportTemplateID <> 0 Then

                        Me.CloseThisWindowAndRefreshCaller(String.Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    Else

                        Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                    End If

                End If

        End Select

    End Sub

#End Region

#End Region

End Class
