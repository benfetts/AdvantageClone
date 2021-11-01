Namespace Invoices.CurrentTTD

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class Invoice
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Designer
        'It can be modified using the Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Invoice))
            Dim XrGroupSortingSummary1 As DevExpress.XtraReports.UI.XRGroupSortingSummary = New DevExpress.XtraReports.UI.XRGroupSortingSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary13 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary14 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary15 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary16 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary17 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary18 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary19 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary20 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary21 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.FormattingRuleQuantityAndHours = New DevExpress.XtraReports.UI.FormattingRule()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrTableReportHeader = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowClientReference = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellClientReferenceLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellClientReference = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleInvoiceClientReference = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowClientPO = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellClientPOLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellClientPO = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleInvoiceClientPO = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowAccountExecutive = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellAccountExecutiveLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellAccountExecutive = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleAccountExecutive = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowSalesClass = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellSalesClassLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellSalesClass = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleInvoiceSalesClass = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowCampaign = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellCampaignLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellCampaign = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleInvoiceCampaign = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabelLocationHeaderInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineHeaderLine = New DevExpress.XtraReports.UI.XRLine()
            Me.XrPictureBoxHeaderLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.XrLabelInvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDateData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDueDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleInvoiceDueDate = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabelInvoiceNumberData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPage = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDueDateData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrPageInfo = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.GroupHeaderInvoice = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelRate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTotalToDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineInvoiceHeaderLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelHoursQuantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineInvoiceHeaderLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelCurrent = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelBillingComment = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderJobComponent = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrTableJobInfo = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowJobCampaign = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobCampaignLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellJobCampaign = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJobCampaign = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowJob = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellJob = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJobInfo = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowJobComponent = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobComponentLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellJobComponent = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJC = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowJobClientPO = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobClientPOLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellJobClientPO = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJobClientPO = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowJobClientReference = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobClientReferenceLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellJobClientReference = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJobClientReference = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowJobSalesClass = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobSalesClassLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellJobSalesClass = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJobSalesClass = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupHeaderJobComponentComment = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrRichText2 = New DevExpress.XtraReports.UI.XRRichText()
            Me.XrRichText3 = New DevExpress.XtraReports.UI.XRRichText()
            Me.XrRichText1 = New DevExpress.XtraReports.UI.XRRichText()
            Me.XrRichText4 = New DevExpress.XtraReports.UI.XRRichText()
            Me.XrTableComment = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowBillingApprovalClientComment = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellBillingApprovalClientComment = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleBillingApprovalClientComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowBillingJobComment = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellBillingJobComment = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleShowInvoiceComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowJobComment = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobComment = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJobComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowJobComponentComment = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobComponentComment = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJobComponentComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrTableRowJobCampaignComment = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobCampaignComment = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleCampaignComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleEstimateComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleEstimateComponentComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleEstimateQuoteComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleEstimateRevisionComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupHeaderFunction = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrSubreportData = New DevExpress.XtraReports.UI.XRSubreport()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrLabelLocationFooterInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterJobComponent = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrTableJobTax = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowJobTax = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellJobSubTotal = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableJobSubTotalData = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellSpacer1 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.FormattingRuleJobTax = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLineJobTotal = New DevExpress.XtraReports.UI.XRLine()
            Me.XrSubreportJobTaxInformation = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabelTTDTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineTTDJC2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrSubreportBillingHistory = New DevExpress.XtraReports.UI.XRSubreport()
            Me.FormattingRuleShowBillingHistory = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabelTotalForJob = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineJC1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineJC2 = New DevExpress.XtraReports.UI.XRLine()
            Me.Line206 = New DevExpress.XtraReports.UI.XRLine()
            Me.FormattingRuleInvoiceTax = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupFooterJobComponentComment = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabelTTDCommissionAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCommission = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCommissionAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleCommission = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupFooterFunction = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.GroupFooterInvoice = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrTableTotals = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowStandardTotals = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellTotalLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellTotalAmount = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellSpacer = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowAmountDue = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellAmountDue = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowDates = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellPaidBy = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellPaidByBlank = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowTotals = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellDiscountTotalAmount = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellDiscountInvoiceTotalAmount = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrLabelInvoiceSubTotalData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelExchangeRateNote = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTaxable = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleTaxable = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrSubreportInvoiceTaxInformation = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabelInvoiceSubTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceTTDSubTotalData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelStandardComment = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleQuantity = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleHours = New DevExpress.XtraReports.UI.FormattingRule()
            Me.TotalPhrase = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ShowQuantity = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowEmployeeHours = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeClientReference = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeClientPO = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeAccountExecutive = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeSalesClass = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeInvoiceDueDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.HideComponentNumberAndDescription = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowBillingHistory = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowTaxSeparately = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowCommissionSeparately = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IndicateTaxableFunctions = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobComponentAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TTDJobComponentAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.HideJobInfo = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BillingApprovalClientComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobComponentComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.EstimateComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.EstimateComponentComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.EstimateQuoteComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.EstimateRevisionComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.TaxTotalLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowCampaign = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowCampaignComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ClientPOLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ClientRefLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.SalesClassLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.CampaignLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.GroupHeaderHeaderGroupBy = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelGroupByHeader1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupByHeader1Label = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleHeaderGroupBy = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupFooterHeaderGroupBy = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLineHGBTotal = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelHGBTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTotalForHGB = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineHGB2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineHGB1 = New DevExpress.XtraReports.UI.XRLine()
            Me.HeaderGroupBy = New DevExpress.XtraReports.Parameters.Parameter()
            Me.HeaderGroupByLabel1 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.HeaderGroupByData1 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.InvoiceComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.TotalHGBPhrase = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobComponentSubTotalAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.TTDJobComponentSubTotalAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TTDTotal = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobTotal = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.XrTableReportHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrTableJobInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrRichText2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrRichText3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrRichText4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrTableComment, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrTableJobTax, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrTableTotals, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.HeightF = 0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'FormattingRuleQuantityAndHours
            '
            Me.FormattingRuleQuantityAndHours.Condition = "[Parameters.ShowQuantity]=False And [Parameters.ShowEmployeeHours]=False"
            Me.FormattingRuleQuantityAndHours.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleQuantityAndHours.Name = "FormattingRuleQuantityAndHours"
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableReportHeader, Me.XrLabelLocationHeaderInfo, Me.XrLineHeaderLine, Me.XrPictureBoxHeaderLogo, Me.XrLabelInvoiceNumber, Me.XrLabelAddress, Me.XrLabelInvoiceDateData, Me.XrLabelInvoiceDueDate, Me.XrLabelInvoiceNumberData, Me.XrLabelPage, Me.XrLabelInvoiceDueDateData, Me.XrLabelInvoiceDate, Me.XrPageInfo, Me.XrLabelInvoiceTitle})
            Me.PageHeader.HeightF = 333.9685!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrTableReportHeader
            '
            Me.XrTableReportHeader.LocationFloat = New DevExpress.Utils.PointFloat(387.9269!, 248.9685!)
            Me.XrTableReportHeader.Name = "XrTableReportHeader"
            Me.XrTableReportHeader.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowClientReference, Me.XrTableRowClientPO, Me.XrTableRowAccountExecutive, Me.XrTableRowSalesClass, Me.XrTableRowCampaign})
            Me.XrTableReportHeader.SizeF = New System.Drawing.SizeF(356.2883!, 85.0!)
            '
            'XrTableRowClientReference
            '
            Me.XrTableRowClientReference.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellClientReferenceLabel, Me.XrTableCellClientReference})
            Me.XrTableRowClientReference.FormattingRules.Add(Me.FormattingRuleInvoiceClientReference)
            Me.XrTableRowClientReference.Name = "XrTableRowClientReference"
            Me.XrTableRowClientReference.Visible = False
            Me.XrTableRowClientReference.Weight = 0.249999887803072R
            '
            'XrTableCellClientReferenceLabel
            '
            Me.XrTableCellClientReferenceLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellClientReferenceLabel.Name = "XrTableCellClientReferenceLabel"
            Me.XrTableCellClientReferenceLabel.StylePriority.UseFont = False
            Me.XrTableCellClientReferenceLabel.StylePriority.UsePadding = False
            Me.XrTableCellClientReferenceLabel.StylePriority.UseTextAlignment = False
            Me.XrTableCellClientReferenceLabel.Text = "Reference:"
            Me.XrTableCellClientReferenceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableCellClientReferenceLabel.Weight = 1.19566103353412R
            '
            'XrTableCellClientReference
            '
            Me.XrTableCellClientReference.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientReference")})
            Me.XrTableCellClientReference.Name = "XrTableCellClientReference"
            Me.XrTableCellClientReference.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellClientReference.StylePriority.UsePadding = False
            Me.XrTableCellClientReference.Weight = 1.80433896646588R
            '
            'FormattingRuleInvoiceClientReference
            '
            Me.FormattingRuleInvoiceClientReference.Condition = "[Parameters.IncludeClientReference] == True And [Parameters.ClientRefLocation] ==" &
    "1"
            Me.FormattingRuleInvoiceClientReference.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceClientReference.Name = "FormattingRuleInvoiceClientReference"
            '
            'XrTableRowClientPO
            '
            Me.XrTableRowClientPO.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellClientPOLabel, Me.XrTableCellClientPO})
            Me.XrTableRowClientPO.FormattingRules.Add(Me.FormattingRuleInvoiceClientPO)
            Me.XrTableRowClientPO.Name = "XrTableRowClientPO"
            Me.XrTableRowClientPO.Visible = False
            Me.XrTableRowClientPO.Weight = 0.249999887803072R
            '
            'XrTableCellClientPOLabel
            '
            Me.XrTableCellClientPOLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellClientPOLabel.Name = "XrTableCellClientPOLabel"
            Me.XrTableCellClientPOLabel.StylePriority.UseFont = False
            Me.XrTableCellClientPOLabel.StylePriority.UsePadding = False
            Me.XrTableCellClientPOLabel.StylePriority.UseTextAlignment = False
            Me.XrTableCellClientPOLabel.Text = "Client PO:"
            Me.XrTableCellClientPOLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableCellClientPOLabel.Weight = 1.19566103353412R
            '
            'XrTableCellClientPO
            '
            Me.XrTableCellClientPO.Name = "XrTableCellClientPO"
            Me.XrTableCellClientPO.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellClientPO.StylePriority.UsePadding = False
            Me.XrTableCellClientPO.Weight = 1.80433896646588R
            '
            'FormattingRuleInvoiceClientPO
            '
            Me.FormattingRuleInvoiceClientPO.Condition = "[Parameters.IncludeClientPO] == True And [Parameters.ClientPOLocation] ==1"
            Me.FormattingRuleInvoiceClientPO.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceClientPO.Name = "FormattingRuleInvoiceClientPO"
            '
            'XrTableRowAccountExecutive
            '
            Me.XrTableRowAccountExecutive.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellAccountExecutiveLabel, Me.XrTableCellAccountExecutive})
            Me.XrTableRowAccountExecutive.FormattingRules.Add(Me.FormattingRuleAccountExecutive)
            Me.XrTableRowAccountExecutive.Name = "XrTableRowAccountExecutive"
            Me.XrTableRowAccountExecutive.Weight = 0.249999887803072R
            '
            'XrTableCellAccountExecutiveLabel
            '
            Me.XrTableCellAccountExecutiveLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellAccountExecutiveLabel.Name = "XrTableCellAccountExecutiveLabel"
            Me.XrTableCellAccountExecutiveLabel.StylePriority.UseFont = False
            Me.XrTableCellAccountExecutiveLabel.StylePriority.UsePadding = False
            Me.XrTableCellAccountExecutiveLabel.StylePriority.UseTextAlignment = False
            Me.XrTableCellAccountExecutiveLabel.Text = "AE:"
            Me.XrTableCellAccountExecutiveLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableCellAccountExecutiveLabel.Weight = 1.19566103353412R
            '
            'XrTableCellAccountExecutive
            '
            Me.XrTableCellAccountExecutive.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountExecutive")})
            Me.XrTableCellAccountExecutive.Name = "XrTableCellAccountExecutive"
            Me.XrTableCellAccountExecutive.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellAccountExecutive.StylePriority.UsePadding = False
            Me.XrTableCellAccountExecutive.Weight = 1.80433896646588R
            '
            'FormattingRuleAccountExecutive
            '
            Me.FormattingRuleAccountExecutive.Condition = "[Parameters.IncludeAccountExecutive]=False"
            Me.FormattingRuleAccountExecutive.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleAccountExecutive.Name = "FormattingRuleAccountExecutive"
            '
            'XrTableRowSalesClass
            '
            Me.XrTableRowSalesClass.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellSalesClassLabel, Me.XrTableCellSalesClass})
            Me.XrTableRowSalesClass.FormattingRules.Add(Me.FormattingRuleInvoiceSalesClass)
            Me.XrTableRowSalesClass.Name = "XrTableRowSalesClass"
            Me.XrTableRowSalesClass.Visible = False
            Me.XrTableRowSalesClass.Weight = 0.249999887803072R
            '
            'XrTableCellSalesClassLabel
            '
            Me.XrTableCellSalesClassLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellSalesClassLabel.Name = "XrTableCellSalesClassLabel"
            Me.XrTableCellSalesClassLabel.StylePriority.UseFont = False
            Me.XrTableCellSalesClassLabel.StylePriority.UsePadding = False
            Me.XrTableCellSalesClassLabel.StylePriority.UseTextAlignment = False
            Me.XrTableCellSalesClassLabel.Text = "Sales Class:"
            Me.XrTableCellSalesClassLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableCellSalesClassLabel.Weight = 1.19566103353412R
            '
            'XrTableCellSalesClass
            '
            Me.XrTableCellSalesClass.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.XrTableCellSalesClass.Name = "XrTableCellSalesClass"
            Me.XrTableCellSalesClass.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellSalesClass.StylePriority.UsePadding = False
            Me.XrTableCellSalesClass.Weight = 1.80433896646588R
            '
            'FormattingRuleInvoiceSalesClass
            '
            Me.FormattingRuleInvoiceSalesClass.Condition = "[Parameters.IncludeSalesClass] == True And [Parameters.SalesClassLocation] ==1"
            Me.FormattingRuleInvoiceSalesClass.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceSalesClass.Name = "FormattingRuleInvoiceSalesClass"
            '
            'XrTableRowCampaign
            '
            Me.XrTableRowCampaign.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellCampaignLabel, Me.XrTableCellCampaign})
            Me.XrTableRowCampaign.FormattingRules.Add(Me.FormattingRuleInvoiceCampaign)
            Me.XrTableRowCampaign.Name = "XrTableRowCampaign"
            Me.XrTableRowCampaign.Visible = False
            Me.XrTableRowCampaign.Weight = 0.249999887803072R
            '
            'XrTableCellCampaignLabel
            '
            Me.XrTableCellCampaignLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellCampaignLabel.Name = "XrTableCellCampaignLabel"
            Me.XrTableCellCampaignLabel.StylePriority.UseFont = False
            Me.XrTableCellCampaignLabel.StylePriority.UseTextAlignment = False
            Me.XrTableCellCampaignLabel.Text = "Campaign:"
            Me.XrTableCellCampaignLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableCellCampaignLabel.Weight = 1.19566103353412R
            '
            'XrTableCellCampaign
            '
            Me.XrTableCellCampaign.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Campaign")})
            Me.XrTableCellCampaign.Name = "XrTableCellCampaign"
            Me.XrTableCellCampaign.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellCampaign.StylePriority.UsePadding = False
            Me.XrTableCellCampaign.Weight = 1.80433896646588R
            '
            'FormattingRuleInvoiceCampaign
            '
            Me.FormattingRuleInvoiceCampaign.Condition = "[Parameters.ShowCampaign] == True And [Parameters.CampaignLocation] ==1"
            Me.FormattingRuleInvoiceCampaign.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceCampaign.Name = "FormattingRuleInvoiceCampaign"
            '
            'XrLabelLocationHeaderInfo
            '
            Me.XrLabelLocationHeaderInfo.BorderColor = System.Drawing.Color.Black
            Me.XrLabelLocationHeaderInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelLocationHeaderInfo.BorderWidth = 1.0!
            Me.XrLabelLocationHeaderInfo.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelLocationHeaderInfo.LocationFloat = New DevExpress.Utils.PointFloat(2.031517!, 150.0!)
            Me.XrLabelLocationHeaderInfo.Name = "XrLabelLocationHeaderInfo"
            Me.XrLabelLocationHeaderInfo.SizeF = New System.Drawing.SizeF(746.0!, 17.0!)
            Me.XrLabelLocationHeaderInfo.StylePriority.UseBackColor = False
            Me.XrLabelLocationHeaderInfo.StylePriority.UsePadding = False
            Me.XrLabelLocationHeaderInfo.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0}"
            Me.XrLabelLocationHeaderInfo.Summary = XrSummary1
            Me.XrLabelLocationHeaderInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLineHeaderLine
            '
            Me.XrLineHeaderLine.BorderColor = System.Drawing.Color.Black
            Me.XrLineHeaderLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineHeaderLine.BorderWidth = 1.0!
            Me.XrLineHeaderLine.ForeColor = System.Drawing.Color.Black
            Me.XrLineHeaderLine.LocationFloat = New DevExpress.Utils.PointFloat(2.031496!, 168.9685!)
            Me.XrLineHeaderLine.Name = "XrLineHeaderLine"
            Me.XrLineHeaderLine.SizeF = New System.Drawing.SizeF(746.0!, 3.0!)
            Me.XrLineHeaderLine.StylePriority.UseBorderWidth = False
            '
            'XrPictureBoxHeaderLogo
            '
            Me.XrPictureBoxHeaderLogo.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Image", Nothing, "PageHeaderLogoPath")})
            Me.XrPictureBoxHeaderLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
            Me.XrPictureBoxHeaderLogo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrPictureBoxHeaderLogo.Name = "XrPictureBoxHeaderLogo"
            Me.XrPictureBoxHeaderLogo.SizeF = New System.Drawing.SizeF(750.0!, 150.0!)
            '
            'XrLabelInvoiceNumber
            '
            Me.XrLabelInvoiceNumber.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceNumber.BorderWidth = 1.0!
            Me.XrLabelInvoiceNumber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceNumber.ForeColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(387.9269!, 197.9685!)
            Me.XrLabelInvoiceNumber.Name = "XrLabelInvoiceNumber"
            Me.XrLabelInvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelInvoiceNumber.SizeF = New System.Drawing.SizeF(142.0!, 16.99998!)
            Me.XrLabelInvoiceNumber.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceNumber.Text = "Invoice Number :"
            Me.XrLabelInvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelAddress
            '
            Me.XrLabelAddress.BorderColor = System.Drawing.Color.Black
            Me.XrLabelAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelAddress.BorderWidth = 1.0!
            Me.XrLabelAddress.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Address")})
            Me.XrLabelAddress.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelAddress.LocationFloat = New DevExpress.Utils.PointFloat(43.75!, 196.9685!)
            Me.XrLabelAddress.Multiline = True
            Me.XrLabelAddress.Name = "XrLabelAddress"
            Me.XrLabelAddress.SizeF = New System.Drawing.SizeF(319.8673!, 137.0!)
            Me.XrLabelAddress.StylePriority.UseBackColor = False
            Me.XrLabelAddress.StylePriority.UsePadding = False
            XrSummary2.FormatString = "{0}"
            Me.XrLabelAddress.Summary = XrSummary2
            Me.XrLabelAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceDateData
            '
            Me.XrLabelInvoiceDateData.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDateData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceDateData.BorderWidth = 1.0!
            Me.XrLabelInvoiceDateData.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelInvoiceDateData.LocationFloat = New DevExpress.Utils.PointFloat(529.9269!, 214.9685!)
            Me.XrLabelInvoiceDateData.Name = "XrLabelInvoiceDateData"
            Me.XrLabelInvoiceDateData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrLabelInvoiceDateData.SizeF = New System.Drawing.SizeF(90.18115!, 17.0!)
            Me.XrLabelInvoiceDateData.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceDateData.StylePriority.UsePadding = False
            XrSummary3.FormatString = "{0:d}"
            Me.XrLabelInvoiceDateData.Summary = XrSummary3
            Me.XrLabelInvoiceDateData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceDueDate
            '
            Me.XrLabelInvoiceDueDate.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceDueDate.BorderWidth = 1.0!
            Me.XrLabelInvoiceDueDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceDueDate.ForeColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDueDate.FormattingRules.Add(Me.FormattingRuleInvoiceDueDate)
            Me.XrLabelInvoiceDueDate.LocationFloat = New DevExpress.Utils.PointFloat(620.1083!, 214.9685!)
            Me.XrLabelInvoiceDueDate.Name = "XrLabelInvoiceDueDate"
            Me.XrLabelInvoiceDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelInvoiceDueDate.SizeF = New System.Drawing.SizeF(35.0!, 17.00002!)
            Me.XrLabelInvoiceDueDate.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceDueDate.Text = "Due : "
            Me.XrLabelInvoiceDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FormattingRuleInvoiceDueDate
            '
            Me.FormattingRuleInvoiceDueDate.Condition = "[Parameters.IncludeInvoiceDueDate]=False"
            Me.FormattingRuleInvoiceDueDate.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleInvoiceDueDate.Name = "FormattingRuleInvoiceDueDate"
            '
            'XrLabelInvoiceNumberData
            '
            Me.XrLabelInvoiceNumberData.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceNumberData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceNumberData.BorderWidth = 1.0!
            Me.XrLabelInvoiceNumberData.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelInvoiceNumberData.LocationFloat = New DevExpress.Utils.PointFloat(529.9269!, 197.9685!)
            Me.XrLabelInvoiceNumberData.Name = "XrLabelInvoiceNumberData"
            Me.XrLabelInvoiceNumberData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrLabelInvoiceNumberData.SizeF = New System.Drawing.SizeF(214.2881!, 17.0!)
            Me.XrLabelInvoiceNumberData.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceNumberData.StylePriority.UsePadding = False
            XrSummary4.FormatString = "{0:000000}"
            Me.XrLabelInvoiceNumberData.Summary = XrSummary4
            Me.XrLabelInvoiceNumberData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPage
            '
            Me.XrLabelPage.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPage.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPage.BorderWidth = 1.0!
            Me.XrLabelPage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPage.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPage.LocationFloat = New DevExpress.Utils.PointFloat(387.9269!, 231.9685!)
            Me.XrLabelPage.Name = "XrLabelPage"
            Me.XrLabelPage.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPage.SizeF = New System.Drawing.SizeF(142.0!, 17.0!)
            Me.XrLabelPage.StylePriority.UseBackColor = False
            Me.XrLabelPage.Text = "Page : "
            Me.XrLabelPage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelInvoiceDueDateData
            '
            Me.XrLabelInvoiceDueDateData.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDueDateData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceDueDateData.BorderWidth = 1.0!
            Me.XrLabelInvoiceDueDateData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDueDate", "{0:d}")})
            Me.XrLabelInvoiceDueDateData.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelInvoiceDueDateData.FormattingRules.Add(Me.FormattingRuleInvoiceDueDate)
            Me.XrLabelInvoiceDueDateData.LocationFloat = New DevExpress.Utils.PointFloat(655.1083!, 214.9685!)
            Me.XrLabelInvoiceDueDateData.Name = "XrLabelInvoiceDueDateData"
            Me.XrLabelInvoiceDueDateData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrLabelInvoiceDueDateData.SizeF = New System.Drawing.SizeF(89.10687!, 17.0!)
            Me.XrLabelInvoiceDueDateData.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceDueDateData.StylePriority.UsePadding = False
            XrSummary5.FormatString = "{0:d}"
            Me.XrLabelInvoiceDueDateData.Summary = XrSummary5
            Me.XrLabelInvoiceDueDateData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceDate
            '
            Me.XrLabelInvoiceDate.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceDate.BorderWidth = 1.0!
            Me.XrLabelInvoiceDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(387.9269!, 214.9684!)
            Me.XrLabelInvoiceDate.Name = "XrLabelInvoiceDate"
            Me.XrLabelInvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelInvoiceDate.SizeF = New System.Drawing.SizeF(142.0!, 17.0!)
            Me.XrLabelInvoiceDate.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceDate.Text = "Date : "
            Me.XrLabelInvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrPageInfo
            '
            Me.XrPageInfo.LocationFloat = New DevExpress.Utils.PointFloat(530.4685!, 231.9685!)
            Me.XrPageInfo.Name = "XrPageInfo"
            Me.XrPageInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrPageInfo.PageInfo = DevExpress.XtraPrinting.PageInfo.Number
            Me.XrPageInfo.RunningBand = Me.GroupHeaderInvoice
            Me.XrPageInfo.SizeF = New System.Drawing.SizeF(213.7465!, 17.0!)
            Me.XrPageInfo.StylePriority.UsePadding = False
            '
            'GroupHeaderInvoice
            '
            Me.GroupHeaderInvoice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelRate, Me.XrLabelTotalToDate, Me.XrLineInvoiceHeaderLine1, Me.XrLabelHoursQuantity, Me.XrLineInvoiceHeaderLine2, Me.XrLabelCurrent, Me.XrLabelBillingComment})
            Me.GroupHeaderInvoice.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("FullInvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderInvoice.HeightF = 56.0!
            Me.GroupHeaderInvoice.KeepTogether = True
            Me.GroupHeaderInvoice.Level = 4
            Me.GroupHeaderInvoice.Name = "GroupHeaderInvoice"
            Me.GroupHeaderInvoice.RepeatEveryPage = True
            '
            'XrLabelRate
            '
            Me.XrLabelRate.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelRate.BorderColor = System.Drawing.Color.Black
            Me.XrLabelRate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelRate.BorderWidth = 1.0!
            Me.XrLabelRate.CanGrow = False
            Me.XrLabelRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelRate.ForeColor = System.Drawing.Color.Black
            Me.XrLabelRate.LocationFloat = New DevExpress.Utils.PointFloat(374.43!, 19.99995!)
            Me.XrLabelRate.Name = "XrLabelRate"
            Me.XrLabelRate.SizeF = New System.Drawing.SizeF(70.99994!, 33.0!)
            Me.XrLabelRate.StylePriority.UsePadding = False
            Me.XrLabelRate.StylePriority.UseTextAlignment = False
            Me.XrLabelRate.Text = "Rate"
            Me.XrLabelRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabelTotalToDate
            '
            Me.XrLabelTotalToDate.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelTotalToDate.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTotalToDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTotalToDate.BorderWidth = 1.0!
            Me.XrLabelTotalToDate.CanGrow = False
            Me.XrLabelTotalToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalToDate.ForeColor = System.Drawing.Color.Black
            Me.XrLabelTotalToDate.LocationFloat = New DevExpress.Utils.PointFloat(652.9994!, 20.00001!)
            Me.XrLabelTotalToDate.Name = "XrLabelTotalToDate"
            Me.XrLabelTotalToDate.SizeF = New System.Drawing.SizeF(91.1394!, 33.0!)
            Me.XrLabelTotalToDate.StylePriority.UsePadding = False
            Me.XrLabelTotalToDate.StylePriority.UseTextAlignment = False
            Me.XrLabelTotalToDate.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to Date"
            Me.XrLabelTotalToDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLineInvoiceHeaderLine1
            '
            Me.XrLineInvoiceHeaderLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineInvoiceHeaderLine1.BorderWidth = 1.0!
            Me.XrLineInvoiceHeaderLine1.ForeColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 16.99994!)
            Me.XrLineInvoiceHeaderLine1.Name = "XrLineInvoiceHeaderLine1"
            Me.XrLineInvoiceHeaderLine1.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            '
            'XrLabelHoursQuantity
            '
            Me.XrLabelHoursQuantity.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelHoursQuantity.BorderColor = System.Drawing.Color.Black
            Me.XrLabelHoursQuantity.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelHoursQuantity.BorderWidth = 1.0!
            Me.XrLabelHoursQuantity.CanGrow = False
            Me.XrLabelHoursQuantity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelHoursQuantity.ForeColor = System.Drawing.Color.Black
            Me.XrLabelHoursQuantity.FormattingRules.Add(Me.FormattingRuleQuantityAndHours)
            Me.XrLabelHoursQuantity.LocationFloat = New DevExpress.Utils.PointFloat(458.927!, 19.99995!)
            Me.XrLabelHoursQuantity.Name = "XrLabelHoursQuantity"
            Me.XrLabelHoursQuantity.SizeF = New System.Drawing.SizeF(70.99994!, 33.0!)
            Me.XrLabelHoursQuantity.StylePriority.UsePadding = False
            Me.XrLabelHoursQuantity.StylePriority.UseTextAlignment = False
            Me.XrLabelHoursQuantity.Text = "Hours/ " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Quantity"
            Me.XrLabelHoursQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLineInvoiceHeaderLine2
            '
            Me.XrLineInvoiceHeaderLine2.BorderColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineInvoiceHeaderLine2.BorderWidth = 1.0!
            Me.XrLineInvoiceHeaderLine2.ForeColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 53.0!)
            Me.XrLineInvoiceHeaderLine2.Name = "XrLineInvoiceHeaderLine2"
            Me.XrLineInvoiceHeaderLine2.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            '
            'XrLabelCurrent
            '
            Me.XrLabelCurrent.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelCurrent.BorderColor = System.Drawing.Color.Black
            Me.XrLabelCurrent.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelCurrent.BorderWidth = 1.0!
            Me.XrLabelCurrent.CanGrow = False
            Me.XrLabelCurrent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelCurrent.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCurrent.LocationFloat = New DevExpress.Utils.PointFloat(543.4274!, 19.99995!)
            Me.XrLabelCurrent.Name = "XrLabelCurrent"
            Me.XrLabelCurrent.SizeF = New System.Drawing.SizeF(91.1394!, 33.0!)
            Me.XrLabelCurrent.StylePriority.UsePadding = False
            Me.XrLabelCurrent.StylePriority.UseTextAlignment = False
            Me.XrLabelCurrent.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Current"
            Me.XrLabelCurrent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabelBillingComment
            '
            Me.XrLabelBillingComment.CanShrink = True
            Me.XrLabelBillingComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingComment")})
            Me.XrLabelBillingComment.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabelBillingComment.Multiline = True
            Me.XrLabelBillingComment.Name = "XrLabelBillingComment"
            Me.XrLabelBillingComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrLabelBillingComment.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            Me.XrLabelBillingComment.StylePriority.UsePadding = False
            '
            'XrLabelInvoiceTitle
            '
            Me.XrLabelInvoiceTitle.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceTitle.BorderWidth = 1.0!
            Me.XrLabelInvoiceTitle.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceCategory")})
            Me.XrLabelInvoiceTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceTitle.LocationFloat = New DevExpress.Utils.PointFloat(363.6173!, 172.9685!)
            Me.XrLabelInvoiceTitle.Name = "XrLabelInvoiceTitle"
            Me.XrLabelInvoiceTitle.SizeF = New System.Drawing.SizeF(380.5977!, 25.0!)
            Me.XrLabelInvoiceTitle.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceTitle.StylePriority.UsePadding = False
            XrSummary6.FormatString = "{0}"
            Me.XrLabelInvoiceTitle.Summary = XrSummary6
            Me.XrLabelInvoiceTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupHeaderJobComponent
            '
            Me.GroupHeaderJobComponent.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableJobInfo})
            Me.GroupHeaderJobComponent.HeightF = 122.0!
            Me.GroupHeaderJobComponent.Level = 2
            Me.GroupHeaderJobComponent.Name = "GroupHeaderJobComponent"
            '
            'XrTableJobInfo
            '
            Me.XrTableJobInfo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.0!)
            Me.XrTableJobInfo.Name = "XrTableJobInfo"
            Me.XrTableJobInfo.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowJobCampaign, Me.XrTableRowJob, Me.XrTableRowJobComponent, Me.XrTableRowJobClientPO, Me.XrTableRowJobClientReference, Me.XrTableRowJobSalesClass})
            Me.XrTableJobInfo.SizeF = New System.Drawing.SizeF(749.9999!, 102.0!)
            '
            'XrTableRowJobCampaign
            '
            Me.XrTableRowJobCampaign.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobCampaignLabel, Me.XrTableCellJobCampaign})
            Me.XrTableRowJobCampaign.FormattingRules.Add(Me.FormattingRuleJobCampaign)
            Me.XrTableRowJobCampaign.Name = "XrTableRowJobCampaign"
            Me.XrTableRowJobCampaign.Visible = False
            Me.XrTableRowJobCampaign.Weight = 1.0R
            '
            'XrTableCellJobCampaignLabel
            '
            Me.XrTableCellJobCampaignLabel.CanShrink = True
            Me.XrTableCellJobCampaignLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobCampaignLabel.Name = "XrTableCellJobCampaignLabel"
            Me.XrTableCellJobCampaignLabel.StylePriority.UseFont = False
            Me.XrTableCellJobCampaignLabel.Text = "Campaign:"
            Me.XrTableCellJobCampaignLabel.Weight = 0.316319993704432R
            '
            'XrTableCellJobCampaign
            '
            Me.XrTableCellJobCampaign.CanShrink = True
            Me.XrTableCellJobCampaign.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CampaignName")})
            Me.XrTableCellJobCampaign.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobCampaign.Name = "XrTableCellJobCampaign"
            Me.XrTableCellJobCampaign.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellJobCampaign.StylePriority.UseFont = False
            Me.XrTableCellJobCampaign.StylePriority.UsePadding = False
            Me.XrTableCellJobCampaign.Weight = 2.68368000629557R
            '
            'FormattingRuleJobCampaign
            '
            Me.FormattingRuleJobCampaign.Condition = "[Parameters.ShowCampaign] == True And [Parameters.CampaignLocation] ==2 And ([Par" &
    "ameters.HeaderGroupBy] == 0 Or [Parameters.HeaderGroupBy] == 2)"
            Me.FormattingRuleJobCampaign.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleJobCampaign.Name = "FormattingRuleJobCampaign"
            '
            'XrTableRowJob
            '
            Me.XrTableRowJob.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobLabel, Me.XrTableCellJob})
            Me.XrTableRowJob.FormattingRules.Add(Me.FormattingRuleJobInfo)
            Me.XrTableRowJob.Name = "XrTableRowJob"
            Me.XrTableRowJob.Weight = 1.0R
            '
            'XrTableCellJobLabel
            '
            Me.XrTableCellJobLabel.CanShrink = True
            Me.XrTableCellJobLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobLabel.Name = "XrTableCellJobLabel"
            Me.XrTableCellJobLabel.StylePriority.UseFont = False
            Me.XrTableCellJobLabel.StylePriority.UsePadding = False
            Me.XrTableCellJobLabel.StylePriority.UseTextAlignment = False
            Me.XrTableCellJobLabel.Text = "Job:"
            Me.XrTableCellJobLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrTableCellJobLabel.Weight = 0.316319963186848R
            '
            'XrTableCellJob
            '
            Me.XrTableCellJob.CanShrink = True
            Me.XrTableCellJob.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobDescription")})
            Me.XrTableCellJob.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJob.Name = "XrTableCellJob"
            Me.XrTableCellJob.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellJob.StylePriority.UseFont = False
            Me.XrTableCellJob.StylePriority.UsePadding = False
            Me.XrTableCellJob.Weight = 2.68368003681315R
            '
            'FormattingRuleJobInfo
            '
            Me.FormattingRuleJobInfo.Condition = "[Parameters.HideJobInfo] == True"
            Me.FormattingRuleJobInfo.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleJobInfo.Name = "FormattingRuleJobInfo"
            '
            'XrTableRowJobComponent
            '
            Me.XrTableRowJobComponent.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobComponentLabel, Me.XrTableCellJobComponent})
            Me.XrTableRowJobComponent.FormattingRules.Add(Me.FormattingRuleJC)
            Me.XrTableRowJobComponent.Name = "XrTableRowJobComponent"
            Me.XrTableRowJobComponent.Weight = 1.0R
            '
            'XrTableCellJobComponentLabel
            '
            Me.XrTableCellJobComponentLabel.CanShrink = True
            Me.XrTableCellJobComponentLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobComponentLabel.Name = "XrTableCellJobComponentLabel"
            Me.XrTableCellJobComponentLabel.StylePriority.UseFont = False
            Me.XrTableCellJobComponentLabel.StylePriority.UsePadding = False
            Me.XrTableCellJobComponentLabel.StylePriority.UseTextAlignment = False
            Me.XrTableCellJobComponentLabel.Text = "Component:"
            Me.XrTableCellJobComponentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrTableCellJobComponentLabel.Weight = 0.316320071693813R
            '
            'XrTableCellJobComponent
            '
            Me.XrTableCellJobComponent.CanShrink = True
            Me.XrTableCellJobComponent.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ComponentDescription")})
            Me.XrTableCellJobComponent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobComponent.Name = "XrTableCellJobComponent"
            Me.XrTableCellJobComponent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellJobComponent.StylePriority.UseFont = False
            Me.XrTableCellJobComponent.StylePriority.UsePadding = False
            Me.XrTableCellJobComponent.Weight = 2.68367992830619R
            '
            'FormattingRuleJC
            '
            Me.FormattingRuleJC.Condition = "[Parameters.HideComponentNumberAndDescription]=True"
            Me.FormattingRuleJC.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleJC.Name = "FormattingRuleJC"
            '
            'XrTableRowJobClientPO
            '
            Me.XrTableRowJobClientPO.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobClientPOLabel, Me.XrTableCellJobClientPO})
            Me.XrTableRowJobClientPO.FormattingRules.Add(Me.FormattingRuleJobClientPO)
            Me.XrTableRowJobClientPO.Name = "XrTableRowJobClientPO"
            Me.XrTableRowJobClientPO.Visible = False
            Me.XrTableRowJobClientPO.Weight = 1.0R
            '
            'XrTableCellJobClientPOLabel
            '
            Me.XrTableCellJobClientPOLabel.CanShrink = True
            Me.XrTableCellJobClientPOLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobClientPOLabel.Name = "XrTableCellJobClientPOLabel"
            Me.XrTableCellJobClientPOLabel.StylePriority.UseFont = False
            Me.XrTableCellJobClientPOLabel.Text = "Client PO:"
            Me.XrTableCellJobClientPOLabel.Weight = 0.316320071693813R
            '
            'XrTableCellJobClientPO
            '
            Me.XrTableCellJobClientPO.CanShrink = True
            Me.XrTableCellJobClientPO.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientPO")})
            Me.XrTableCellJobClientPO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobClientPO.Name = "XrTableCellJobClientPO"
            Me.XrTableCellJobClientPO.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellJobClientPO.StylePriority.UseFont = False
            Me.XrTableCellJobClientPO.StylePriority.UsePadding = False
            Me.XrTableCellJobClientPO.Weight = 2.68367992830619R
            '
            'FormattingRuleJobClientPO
            '
            Me.FormattingRuleJobClientPO.Condition = "[Parameters.IncludeClientPO] == True And [Parameters.ClientPOLocation] ==2"
            Me.FormattingRuleJobClientPO.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleJobClientPO.Name = "FormattingRuleJobClientPO"
            '
            'XrTableRowJobClientReference
            '
            Me.XrTableRowJobClientReference.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobClientReferenceLabel, Me.XrTableCellJobClientReference})
            Me.XrTableRowJobClientReference.FormattingRules.Add(Me.FormattingRuleJobClientReference)
            Me.XrTableRowJobClientReference.Name = "XrTableRowJobClientReference"
            Me.XrTableRowJobClientReference.Visible = False
            Me.XrTableRowJobClientReference.Weight = 1.0R
            '
            'XrTableCellJobClientReferenceLabel
            '
            Me.XrTableCellJobClientReferenceLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobClientReferenceLabel.Name = "XrTableCellJobClientReferenceLabel"
            Me.XrTableCellJobClientReferenceLabel.StylePriority.UseFont = False
            Me.XrTableCellJobClientReferenceLabel.Text = "Reference:"
            Me.XrTableCellJobClientReferenceLabel.Weight = 0.316320071693813R
            '
            'XrTableCellJobClientReference
            '
            Me.XrTableCellJobClientReference.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientReference")})
            Me.XrTableCellJobClientReference.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobClientReference.Name = "XrTableCellJobClientReference"
            Me.XrTableCellJobClientReference.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellJobClientReference.StylePriority.UseFont = False
            Me.XrTableCellJobClientReference.StylePriority.UsePadding = False
            Me.XrTableCellJobClientReference.Weight = 2.68367992830619R
            '
            'FormattingRuleJobClientReference
            '
            Me.FormattingRuleJobClientReference.Condition = "[Parameters.IncludeClientReference] == True And [Parameters.ClientRefLocation] ==" &
    "2"
            Me.FormattingRuleJobClientReference.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleJobClientReference.Name = "FormattingRuleJobClientReference"
            '
            'XrTableRowJobSalesClass
            '
            Me.XrTableRowJobSalesClass.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobSalesClassLabel, Me.XrTableCellJobSalesClass})
            Me.XrTableRowJobSalesClass.FormattingRules.Add(Me.FormattingRuleJobSalesClass)
            Me.XrTableRowJobSalesClass.Name = "XrTableRowJobSalesClass"
            Me.XrTableRowJobSalesClass.Visible = False
            Me.XrTableRowJobSalesClass.Weight = 1.0R
            '
            'XrTableCellJobSalesClassLabel
            '
            Me.XrTableCellJobSalesClassLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobSalesClassLabel.Name = "XrTableCellJobSalesClassLabel"
            Me.XrTableCellJobSalesClassLabel.StylePriority.UseFont = False
            Me.XrTableCellJobSalesClassLabel.Text = "Sales Class:"
            Me.XrTableCellJobSalesClassLabel.Weight = 0.316320071693813R
            '
            'XrTableCellJobSalesClass
            '
            Me.XrTableCellJobSalesClass.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.XrTableCellJobSalesClass.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobSalesClass.Name = "XrTableCellJobSalesClass"
            Me.XrTableCellJobSalesClass.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellJobSalesClass.StylePriority.UseFont = False
            Me.XrTableCellJobSalesClass.StylePriority.UsePadding = False
            Me.XrTableCellJobSalesClass.Weight = 2.68367992830619R
            '
            'FormattingRuleJobSalesClass
            '
            Me.FormattingRuleJobSalesClass.Condition = "[Parameters.IncludeSalesClass] == True And [Parameters.SalesClassLocation] ==2 An" &
    "d ([Parameters.HeaderGroupBy] == 0 Or [Parameters.HeaderGroupBy] == 1)"
            Me.FormattingRuleJobSalesClass.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleJobSalesClass.Name = "FormattingRuleJobSalesClass"
            '
            'GroupHeaderJobComponentComment
            '
            Me.GroupHeaderJobComponentComment.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrRichText2, Me.XrRichText3, Me.XrRichText1, Me.XrRichText4, Me.XrTableComment})
            Me.GroupHeaderJobComponentComment.HeightF = 161.0!
            Me.GroupHeaderJobComponentComment.Level = 1
            Me.GroupHeaderJobComponentComment.Name = "GroupHeaderJobComponentComment"
            '
            'XrRichText2
            '
            Me.XrRichText2.CanShrink = True
            Me.XrRichText2.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrRichText2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 102.0!)
            Me.XrRichText2.Name = "XrRichText2"
            Me.XrRichText2.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrRichText2.SerializableRtfString = resources.GetString("XrRichText2.SerializableRtfString")
            Me.XrRichText2.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            '
            'XrRichText3
            '
            Me.XrRichText3.CanShrink = True
            Me.XrRichText3.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrRichText3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 119.0!)
            Me.XrRichText3.Name = "XrRichText3"
            Me.XrRichText3.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrRichText3.SerializableRtfString = resources.GetString("XrRichText3.SerializableRtfString")
            Me.XrRichText3.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            '
            'XrRichText1
            '
            Me.XrRichText1.CanShrink = True
            Me.XrRichText1.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrRichText1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 85.0!)
            Me.XrRichText1.Name = "XrRichText1"
            Me.XrRichText1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrRichText1.SerializableRtfString = resources.GetString("XrRichText1.SerializableRtfString")
            Me.XrRichText1.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            '
            'XrRichText4
            '
            Me.XrRichText4.CanShrink = True
            Me.XrRichText4.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrRichText4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 136.0!)
            Me.XrRichText4.Name = "XrRichText4"
            Me.XrRichText4.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrRichText4.SerializableRtfString = resources.GetString("XrRichText4.SerializableRtfString")
            Me.XrRichText4.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            '
            'XrTableComment
            '
            Me.XrTableComment.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrTableComment.Name = "XrTableComment"
            Me.XrTableComment.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowBillingApprovalClientComment, Me.XrTableRowBillingJobComment, Me.XrTableRowJobComment, Me.XrTableRowJobComponentComment, Me.XrTableRowJobCampaignComment})
            Me.XrTableComment.SizeF = New System.Drawing.SizeF(750.0!, 85.0!)
            '
            'XrTableRowBillingApprovalClientComment
            '
            Me.XrTableRowBillingApprovalClientComment.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellBillingApprovalClientComment})
            Me.XrTableRowBillingApprovalClientComment.FormattingRules.Add(Me.FormattingRuleBillingApprovalClientComment)
            Me.XrTableRowBillingApprovalClientComment.KeepTogether = False
            Me.XrTableRowBillingApprovalClientComment.Name = "XrTableRowBillingApprovalClientComment"
            Me.XrTableRowBillingApprovalClientComment.Weight = 0.68R
            '
            'XrTableCellBillingApprovalClientComment
            '
            Me.XrTableCellBillingApprovalClientComment.CanShrink = True
            Me.XrTableCellBillingApprovalClientComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalClientComment")})
            Me.XrTableCellBillingApprovalClientComment.Multiline = True
            Me.XrTableCellBillingApprovalClientComment.Name = "XrTableCellBillingApprovalClientComment"
            Me.XrTableCellBillingApprovalClientComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCellBillingApprovalClientComment.Weight = 1.0R
            '
            'FormattingRuleBillingApprovalClientComment
            '
            Me.FormattingRuleBillingApprovalClientComment.Condition = "[Parameters.BillingApprovalClientComment] == False"
            Me.FormattingRuleBillingApprovalClientComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleBillingApprovalClientComment.Name = "FormattingRuleBillingApprovalClientComment"
            '
            'XrTableRowBillingJobComment
            '
            Me.XrTableRowBillingJobComment.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellBillingJobComment})
            Me.XrTableRowBillingJobComment.FormattingRules.Add(Me.FormattingRuleShowInvoiceComment)
            Me.XrTableRowBillingJobComment.KeepTogether = False
            Me.XrTableRowBillingJobComment.Name = "XrTableRowBillingJobComment"
            Me.XrTableRowBillingJobComment.Weight = 0.68R
            '
            'XrTableCellBillingJobComment
            '
            Me.XrTableCellBillingJobComment.CanShrink = True
            Me.XrTableCellBillingJobComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingJobComment")})
            Me.XrTableCellBillingJobComment.Multiline = True
            Me.XrTableCellBillingJobComment.Name = "XrTableCellBillingJobComment"
            Me.XrTableCellBillingJobComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCellBillingJobComment.Weight = 1.0R
            '
            'FormattingRuleShowInvoiceComment
            '
            Me.FormattingRuleShowInvoiceComment.Condition = "[Parameters.InvoiceComment] == False"
            Me.FormattingRuleShowInvoiceComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleShowInvoiceComment.Name = "FormattingRuleShowInvoiceComment"
            '
            'XrTableRowJobComment
            '
            Me.XrTableRowJobComment.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobComment})
            Me.XrTableRowJobComment.FormattingRules.Add(Me.FormattingRuleJobComment)
            Me.XrTableRowJobComment.KeepTogether = False
            Me.XrTableRowJobComment.Name = "XrTableRowJobComment"
            Me.XrTableRowJobComment.Weight = 0.68R
            '
            'XrTableCellJobComment
            '
            Me.XrTableCellJobComment.CanShrink = True
            Me.XrTableCellJobComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComment")})
            Me.XrTableCellJobComment.Multiline = True
            Me.XrTableCellJobComment.Name = "XrTableCellJobComment"
            Me.XrTableCellJobComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCellJobComment.Weight = 1.0R
            '
            'FormattingRuleJobComment
            '
            Me.FormattingRuleJobComment.Condition = "[Parameters.JobComment] == False"
            Me.FormattingRuleJobComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleJobComment.Name = "FormattingRuleJobComment"
            '
            'XrTableRowJobComponentComment
            '
            Me.XrTableRowJobComponentComment.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobComponentComment})
            Me.XrTableRowJobComponentComment.FormattingRules.Add(Me.FormattingRuleJobComponentComment)
            Me.XrTableRowJobComponentComment.KeepTogether = False
            Me.XrTableRowJobComponentComment.Name = "XrTableRowJobComponentComment"
            Me.XrTableRowJobComponentComment.Weight = 0.68R
            '
            'XrTableCellJobComponentComment
            '
            Me.XrTableCellJobComponentComment.CanShrink = True
            Me.XrTableCellJobComponentComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentComment")})
            Me.XrTableCellJobComponentComment.Multiline = True
            Me.XrTableCellJobComponentComment.Name = "XrTableCellJobComponentComment"
            Me.XrTableCellJobComponentComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCellJobComponentComment.Weight = 1.0R
            '
            'FormattingRuleJobComponentComment
            '
            Me.FormattingRuleJobComponentComment.Condition = "[Parameters.JobComponentComment] == False"
            Me.FormattingRuleJobComponentComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleJobComponentComment.Name = "FormattingRuleJobComponentComment"
            '
            'XrTableRowJobCampaignComment
            '
            Me.XrTableRowJobCampaignComment.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobCampaignComment})
            Me.XrTableRowJobCampaignComment.FormattingRules.Add(Me.FormattingRuleCampaignComment)
            Me.XrTableRowJobCampaignComment.KeepTogether = False
            Me.XrTableRowJobCampaignComment.Name = "XrTableRowJobCampaignComment"
            Me.XrTableRowJobCampaignComment.Weight = 0.680000000000001R
            '
            'XrTableCellJobCampaignComment
            '
            Me.XrTableCellJobCampaignComment.CanShrink = True
            Me.XrTableCellJobCampaignComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CampaignComment")})
            Me.XrTableCellJobCampaignComment.Multiline = True
            Me.XrTableCellJobCampaignComment.Name = "XrTableCellJobCampaignComment"
            Me.XrTableCellJobCampaignComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCellJobCampaignComment.Weight = 1.0R
            '
            'FormattingRuleCampaignComment
            '
            Me.FormattingRuleCampaignComment.Condition = "[Parameters.ShowCampaignComment] == False"
            Me.FormattingRuleCampaignComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleCampaignComment.Name = "FormattingRuleCampaignComment"
            '
            'FormattingRuleEstimateComment
            '
            Me.FormattingRuleEstimateComment.Condition = "[Parameters.EstimateComment] == False"
            Me.FormattingRuleEstimateComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleEstimateComment.Name = "FormattingRuleEstimateComment"
            '
            'FormattingRuleEstimateComponentComment
            '
            Me.FormattingRuleEstimateComponentComment.Condition = "[Parameters.EstimateComponentComment] == False"
            Me.FormattingRuleEstimateComponentComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleEstimateComponentComment.Name = "FormattingRuleEstimateComponentComment"
            '
            'FormattingRuleEstimateQuoteComment
            '
            Me.FormattingRuleEstimateQuoteComment.Condition = "[Parameters.EstimateQuoteComment] == False"
            Me.FormattingRuleEstimateQuoteComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleEstimateQuoteComment.Name = "FormattingRuleEstimateQuoteComment"
            '
            'FormattingRuleEstimateRevisionComment
            '
            Me.FormattingRuleEstimateRevisionComment.Condition = "[Parameters.EstimateRevisionComment] == False"
            Me.FormattingRuleEstimateRevisionComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleEstimateRevisionComment.Name = "FormattingRuleEstimateRevisionComment"
            '
            'GroupHeaderFunction
            '
            Me.GroupHeaderFunction.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreportData})
            Me.GroupHeaderFunction.HeightF = 17.0!
            Me.GroupHeaderFunction.Name = "GroupHeaderFunction"
            XrGroupSortingSummary1.FieldName = "FunctionCode"
            XrGroupSortingSummary1.Function = DevExpress.XtraReports.UI.SortingSummaryFunction.Custom
            Me.GroupHeaderFunction.SortingSummary = XrGroupSortingSummary1
            '
            'XrSubreportData
            '
            Me.XrSubreportData.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrSubreportData.Name = "XrSubreportData"
            Me.XrSubreportData.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelLocationFooterInfo})
            Me.PageFooter.HeightF = 17.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'XrLabelLocationFooterInfo
            '
            Me.XrLabelLocationFooterInfo.BorderColor = System.Drawing.Color.Black
            Me.XrLabelLocationFooterInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelLocationFooterInfo.BorderWidth = 1.0!
            Me.XrLabelLocationFooterInfo.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelLocationFooterInfo.LocationFloat = New DevExpress.Utils.PointFloat(2.031517!, 0!)
            Me.XrLabelLocationFooterInfo.Name = "XrLabelLocationFooterInfo"
            Me.XrLabelLocationFooterInfo.SizeF = New System.Drawing.SizeF(746.0!, 17.0!)
            Me.XrLabelLocationFooterInfo.StylePriority.UseBackColor = False
            Me.XrLabelLocationFooterInfo.StylePriority.UsePadding = False
            Me.XrLabelLocationFooterInfo.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0}"
            Me.XrLabelLocationFooterInfo.Summary = XrSummary7
            Me.XrLabelLocationFooterInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupFooterJobComponent
            '
            Me.GroupFooterJobComponent.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableJobTax, Me.XrLineJobTotal, Me.XrSubreportJobTaxInformation, Me.XrLabelTTDTotalAmount, Me.XrLine1, Me.XrLineTTDJC2, Me.XrSubreportBillingHistory, Me.XrLabelTotalForJob, Me.XrLabelTotalAmount, Me.XrLineJC1, Me.XrLineJC2})
            Me.GroupFooterJobComponent.HeightF = 134.2434!
            Me.GroupFooterJobComponent.Level = 2
            Me.GroupFooterJobComponent.Name = "GroupFooterJobComponent"
            '
            'XrTableJobTax
            '
            Me.XrTableJobTax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableJobTax.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 2.41998!)
            Me.XrTableJobTax.Name = "XrTableJobTax"
            Me.XrTableJobTax.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowJobTax})
            Me.XrTableJobTax.SizeF = New System.Drawing.SizeF(444.1388!, 17.0!)
            Me.XrTableJobTax.StylePriority.UseFont = False
            '
            'XrTableRowJobTax
            '
            Me.XrTableRowJobTax.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellJobSubTotal, Me.XrTableJobSubTotalData, Me.XrTableCellSpacer1, Me.XrTableCell1})
            Me.XrTableRowJobTax.FormattingRules.Add(Me.FormattingRuleJobTax)
            Me.XrTableRowJobTax.Name = "XrTableRowJobTax"
            Me.XrTableRowJobTax.Weight = 1.0R
            '
            'XrTableCellJobSubTotal
            '
            Me.XrTableCellJobSubTotal.CanShrink = True
            Me.XrTableCellJobSubTotal.Name = "XrTableCellJobSubTotal"
            Me.XrTableCellJobSubTotal.Text = "Sub-Total"
            Me.XrTableCellJobSubTotal.Weight = 1.1008665695705953R
            '
            'XrTableJobSubTotalData
            '
            Me.XrTableJobSubTotalData.CanShrink = True
            Me.XrTableJobSubTotalData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentSubTotalAmount")})
            Me.XrTableJobSubTotalData.Name = "XrTableJobSubTotalData"
            Me.XrTableJobSubTotalData.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableJobSubTotalData.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableJobSubTotalData.Summary = XrSummary8
            Me.XrTableJobSubTotalData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableJobSubTotalData.Weight = 0.41216773944869639R
            '
            'XrTableCellSpacer1
            '
            Me.XrTableCellSpacer1.Name = "XrTableCellSpacer1"
            Me.XrTableCellSpacer1.Weight = 0.083352408300907219R
            '
            'XrTableCell1
            '
            Me.XrTableCell1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TTDJobComponentSubTotalAmount")})
            Me.XrTableCell1.Name = "XrTableCell1"
            Me.XrTableCell1.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCell1.Summary = XrSummary9
            Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrTableCell1.Weight = 0.41216807899644287R
            '
            'FormattingRuleJobTax
            '
            Me.FormattingRuleJobTax.Condition = "[Parameters.ShowTaxSeparately] == False Or [Parameters.TaxTotalLocation] == 2"
            Me.FormattingRuleJobTax.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleJobTax.Name = "FormattingRuleJobTax"
            '
            'XrLineJobTotal
            '
            Me.XrLineJobTotal.BorderColor = System.Drawing.Color.Black
            Me.XrLineJobTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineJobTotal.BorderWidth = 1.0!
            Me.XrLineJobTotal.ForeColor = System.Drawing.Color.Black
            Me.XrLineJobTotal.LocationFloat = New DevExpress.Utils.PointFloat(0!, 132.2434!)
            Me.XrLineJobTotal.Name = "XrLineJobTotal"
            Me.XrLineJobTotal.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            '
            'XrSubreportJobTaxInformation
            '
            Me.XrSubreportJobTaxInformation.CanShrink = True
            Me.XrSubreportJobTaxInformation.FormattingRules.Add(Me.FormattingRuleJobTax)
            Me.XrSubreportJobTaxInformation.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 19.41999!)
            Me.XrSubreportJobTaxInformation.Name = "XrSubreportJobTaxInformation"
            Me.XrSubreportJobTaxInformation.ReportSource = New AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.TaxInformationSubReport()
            Me.XrSubreportJobTaxInformation.SizeF = New System.Drawing.SizeF(444.1389!, 55.00002!)
            '
            'XrLabelTTDTotalAmount
            '
            Me.XrLabelTTDTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TTDJobComponentAmount")})
            Me.XrLabelTTDTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTTDTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 86.42001!)
            Me.XrLabelTTDTotalAmount.Name = "XrLabelTTDTotalAmount"
            Me.XrLabelTTDTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTTDTotalAmount.StylePriority.UseFont = False
            Me.XrLabelTTDTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelTTDTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTTDTotalAmount.Summary = XrSummary10
            Me.XrLabelTTDTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 1.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Black
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(653.08!, 80.42!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLineTTDJC2
            '
            Me.XrLineTTDJC2.BorderColor = System.Drawing.Color.Black
            Me.XrLineTTDJC2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineTTDJC2.BorderWidth = 1.0!
            Me.XrLineTTDJC2.ForeColor = System.Drawing.Color.Black
            Me.XrLineTTDJC2.LocationFloat = New DevExpress.Utils.PointFloat(652.9988!, 78.42001!)
            Me.XrLineTTDJC2.Name = "XrLineTTDJC2"
            Me.XrLineTTDJC2.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrSubreportBillingHistory
            '
            Me.XrSubreportBillingHistory.CanShrink = True
            Me.XrSubreportBillingHistory.FormattingRules.Add(Me.FormattingRuleShowBillingHistory)
            Me.XrSubreportBillingHistory.LocationFloat = New DevExpress.Utils.PointFloat(0!, 111.5867!)
            Me.XrSubreportBillingHistory.Name = "XrSubreportBillingHistory"
            Me.XrSubreportBillingHistory.ReportSource = New AdvantageFramework.Reporting.Reports.Invoices.BillingHistorySubReport()
            Me.XrSubreportBillingHistory.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            Me.XrSubreportBillingHistory.Visible = False
            '
            'FormattingRuleShowBillingHistory
            '
            Me.FormattingRuleShowBillingHistory.Condition = "[Parameters.ShowBillingHistory] == True"
            Me.FormattingRuleShowBillingHistory.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleShowBillingHistory.Name = "FormattingRuleShowBillingHistory"
            '
            'XrLabelTotalForJob
            '
            Me.XrLabelTotalForJob.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelTotalForJob.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTotalForJob.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTotalForJob.BorderWidth = 1.0!
            Me.XrLabelTotalForJob.CanGrow = False
            Me.XrLabelTotalForJob.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalPhrase")})
            Me.XrLabelTotalForJob.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalForJob.ForeColor = System.Drawing.Color.Black
            Me.XrLabelTotalForJob.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 86.42001!)
            Me.XrLabelTotalForJob.Name = "XrLabelTotalForJob"
            Me.XrLabelTotalForJob.SizeF = New System.Drawing.SizeF(240.9584!, 17.0!)
            Me.XrLabelTotalForJob.StylePriority.UsePadding = False
            Me.XrLabelTotalForJob.Text = "Total for Job"
            Me.XrLabelTotalForJob.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelTotalAmount
            '
            Me.XrLabelTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentAmount")})
            Me.XrLabelTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.4275!, 86.42001!)
            Me.XrLabelTotalAmount.Name = "XrLabelTotalAmount"
            Me.XrLabelTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTotalAmount.StylePriority.UseFont = False
            Me.XrLabelTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary11.FormatString = "{0:n2}"
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTotalAmount.Summary = XrSummary11
            Me.XrLabelTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineJC1
            '
            Me.XrLineJC1.BorderColor = System.Drawing.Color.Black
            Me.XrLineJC1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineJC1.BorderWidth = 1.0!
            Me.XrLineJC1.ForeColor = System.Drawing.Color.Black
            Me.XrLineJC1.LocationFloat = New DevExpress.Utils.PointFloat(543.3512!, 80.42!)
            Me.XrLineJC1.Name = "XrLineJC1"
            Me.XrLineJC1.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLineJC2
            '
            Me.XrLineJC2.BorderColor = System.Drawing.Color.Black
            Me.XrLineJC2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineJC2.BorderWidth = 1.0!
            Me.XrLineJC2.ForeColor = System.Drawing.Color.Black
            Me.XrLineJC2.LocationFloat = New DevExpress.Utils.PointFloat(543.3512!, 78.42001!)
            Me.XrLineJC2.Name = "XrLineJC2"
            Me.XrLineJC2.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'Line206
            '
            Me.Line206.BorderColor = System.Drawing.Color.Black
            Me.Line206.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line206.BorderWidth = 1.0!
            Me.Line206.ForeColor = System.Drawing.Color.Black
            Me.Line206.FormattingRules.Add(Me.FormattingRuleInvoiceTax)
            Me.Line206.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Line206.Name = "Line206"
            Me.Line206.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            '
            'FormattingRuleInvoiceTax
            '
            Me.FormattingRuleInvoiceTax.Condition = "[Parameters.ShowTaxSeparately] == False Or [Parameters.TaxTotalLocation] == 3"
            Me.FormattingRuleInvoiceTax.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleInvoiceTax.Name = "FormattingRuleInvoiceTax"
            '
            'GroupFooterJobComponentComment
            '
            Me.GroupFooterJobComponentComment.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTTDCommissionAmount, Me.XrLabelCommission, Me.XrLabelCommissionAmount})
            Me.GroupFooterJobComponentComment.FormattingRules.Add(Me.FormattingRuleCommission)
            Me.GroupFooterJobComponentComment.HeightF = 17.0!
            Me.GroupFooterJobComponentComment.Level = 1
            Me.GroupFooterJobComponentComment.Name = "GroupFooterJobComponentComment"
            '
            'XrLabelTTDCommissionAmount
            '
            Me.XrLabelTTDCommissionAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TTDCommissionAmount")})
            Me.XrLabelTTDCommissionAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 0!)
            Me.XrLabelTTDCommissionAmount.Name = "XrLabelTTDCommissionAmount"
            Me.XrLabelTTDCommissionAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTTDCommissionAmount.StylePriority.UsePadding = False
            Me.XrLabelTTDCommissionAmount.StylePriority.UseTextAlignment = False
            XrSummary12.FormatString = "{0:n2}"
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTTDCommissionAmount.Summary = XrSummary12
            Me.XrLabelTTDCommissionAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelCommission
            '
            Me.XrLabelCommission.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelCommission.BorderColor = System.Drawing.Color.Black
            Me.XrLabelCommission.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelCommission.BorderWidth = 1.0!
            Me.XrLabelCommission.CanGrow = False
            Me.XrLabelCommission.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelCommission.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCommission.LocationFloat = New DevExpress.Utils.PointFloat(37.99998!, 0!)
            Me.XrLabelCommission.Name = "XrLabelCommission"
            Me.XrLabelCommission.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelCommission.SizeF = New System.Drawing.SizeF(83.0!, 17.0!)
            Me.XrLabelCommission.StylePriority.UseFont = False
            Me.XrLabelCommission.StylePriority.UseTextAlignment = False
            Me.XrLabelCommission.Text = "Commission"
            Me.XrLabelCommission.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelCommissionAmount
            '
            Me.XrLabelCommissionAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CommissionAmount")})
            Me.XrLabelCommissionAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.4275!, 0!)
            Me.XrLabelCommissionAmount.Name = "XrLabelCommissionAmount"
            Me.XrLabelCommissionAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelCommissionAmount.StylePriority.UsePadding = False
            Me.XrLabelCommissionAmount.StylePriority.UseTextAlignment = False
            XrSummary13.FormatString = "{0:n2}"
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelCommissionAmount.Summary = XrSummary13
            Me.XrLabelCommissionAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FormattingRuleCommission
            '
            Me.FormattingRuleCommission.Condition = "[Parameters.ShowCommissionSeparately]=False"
            Me.FormattingRuleCommission.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleCommission.Name = "FormattingRuleCommission"
            '
            'GroupFooterFunction
            '
            Me.GroupFooterFunction.HeightF = 0!
            Me.GroupFooterFunction.Name = "GroupFooterFunction"
            '
            'GroupFooterInvoice
            '
            Me.GroupFooterInvoice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableTotals, Me.XrLabelInvoiceSubTotalData, Me.XrLabelExchangeRateNote, Me.XrLabelTaxable, Me.XrSubreportInvoiceTaxInformation, Me.XrLabelInvoiceSubTotal, Me.XrLabelInvoiceTTDSubTotalData, Me.XrLabelStandardComment, Me.Line206})
            Me.GroupFooterInvoice.HeightF = 225.8!
            Me.GroupFooterInvoice.Level = 4
            Me.GroupFooterInvoice.Name = "GroupFooterInvoice"
            Me.GroupFooterInvoice.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'XrTableTotals
            '
            Me.XrTableTotals.LocationFloat = New DevExpress.Utils.PointFloat(405.28!, 87.58!)
            Me.XrTableTotals.Name = "XrTableTotals"
            Me.XrTableTotals.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowStandardTotals, Me.XrTableRowAmountDue, Me.XrTableRowDates, Me.XrTableRowTotals})
            Me.XrTableTotals.SizeF = New System.Drawing.SizeF(300.0!, 95.0!)
            Me.XrTableTotals.StylePriority.UseBorders = False
            '
            'XrTableRowStandardTotals
            '
            Me.XrTableRowStandardTotals.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellTotalLabel, Me.XrTableCellTotalAmount, Me.XrTableCellSpacer})
            Me.XrTableRowStandardTotals.Name = "XrTableRowStandardTotals"
            Me.XrTableRowStandardTotals.Weight = 0.8R
            '
            'XrTableCellTotalLabel
            '
            Me.XrTableCellTotalLabel.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.XrTableCellTotalLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.XrTableCellTotalLabel.Name = "XrTableCellTotalLabel"
            Me.XrTableCellTotalLabel.StylePriority.UseBorders = False
            Me.XrTableCellTotalLabel.StylePriority.UseFont = False
            Me.XrTableCellTotalLabel.StylePriority.UseForeColor = False
            Me.XrTableCellTotalLabel.StylePriority.UseTextAlignment = False
            Me.XrTableCellTotalLabel.Text = "Total"
            Me.XrTableCellTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.XrTableCellTotalLabel.Weight = 0.92811187744140622R
            '
            'XrTableCellTotalAmount
            '
            Me.XrTableCellTotalAmount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.XrTableCellTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrTableCellTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellTotalAmount.ForeColor = System.Drawing.Color.Black
            Me.XrTableCellTotalAmount.Name = "XrTableCellTotalAmount"
            Me.XrTableCellTotalAmount.StylePriority.UseBorders = False
            Me.XrTableCellTotalAmount.StylePriority.UseFont = False
            Me.XrTableCellTotalAmount.StylePriority.UseForeColor = False
            Me.XrTableCellTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary14.FormatString = "{0:c2}"
            XrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCellTotalAmount.Summary = XrSummary14
            Me.XrTableCellTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.XrTableCellTotalAmount.Weight = 2.01R
            '
            'XrTableCellSpacer
            '
            Me.XrTableCellSpacer.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.XrTableCellSpacer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellSpacer.ForeColor = System.Drawing.Color.Black
            Me.XrTableCellSpacer.Name = "XrTableCellSpacer"
            Me.XrTableCellSpacer.StylePriority.UseBorders = False
            Me.XrTableCellSpacer.StylePriority.UseFont = False
            Me.XrTableCellSpacer.StylePriority.UseForeColor = False
            Me.XrTableCellSpacer.StylePriority.UseTextAlignment = False
            Me.XrTableCellSpacer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            Me.XrTableCellSpacer.Weight = 0.061888122558593779R
            '
            'XrTableRowAmountDue
            '
            Me.XrTableRowAmountDue.BackColor = System.Drawing.Color.Transparent
            Me.XrTableRowAmountDue.BorderColor = System.Drawing.Color.Black
            Me.XrTableRowAmountDue.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrTableRowAmountDue.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellAmountDue})
            Me.XrTableRowAmountDue.ForeColor = System.Drawing.Color.Gray
            Me.XrTableRowAmountDue.Name = "XrTableRowAmountDue"
            Me.XrTableRowAmountDue.StylePriority.UseBackColor = False
            Me.XrTableRowAmountDue.StylePriority.UseBorderColor = False
            Me.XrTableRowAmountDue.StylePriority.UseBorders = False
            Me.XrTableRowAmountDue.StylePriority.UseForeColor = False
            Me.XrTableRowAmountDue.Visible = False
            Me.XrTableRowAmountDue.Weight = 0.8R
            '
            'XrTableCellAmountDue
            '
            Me.XrTableCellAmountDue.BorderColor = System.Drawing.Color.Black
            Me.XrTableCellAmountDue.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.XrTableCellAmountDue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellAmountDue.ForeColor = System.Drawing.Color.Black
            Me.XrTableCellAmountDue.Name = "XrTableCellAmountDue"
            Me.XrTableCellAmountDue.StylePriority.UseBorderColor = False
            Me.XrTableCellAmountDue.StylePriority.UseBorders = False
            Me.XrTableCellAmountDue.StylePriority.UseFont = False
            Me.XrTableCellAmountDue.StylePriority.UseForeColor = False
            Me.XrTableCellAmountDue.StylePriority.UseTextAlignment = False
            Me.XrTableCellAmountDue.Text = "AMOUNT DUE"
            Me.XrTableCellAmountDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            Me.XrTableCellAmountDue.Weight = 3.0R
            '
            'XrTableRowDates
            '
            Me.XrTableRowDates.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellPaidBy, Me.XrTableCellPaidByBlank})
            Me.XrTableRowDates.Name = "XrTableRowDates"
            Me.XrTableRowDates.Visible = False
            Me.XrTableRowDates.Weight = 0.74166618347167956R
            '
            'XrTableCellPaidBy
            '
            Me.XrTableCellPaidBy.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
            Me.XrTableCellPaidBy.Name = "XrTableCellPaidBy"
            Me.XrTableCellPaidBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 3, 0, 100.0!)
            Me.XrTableCellPaidBy.StylePriority.UseBorders = False
            Me.XrTableCellPaidBy.StylePriority.UsePadding = False
            Me.XrTableCellPaidBy.Text = "If Paid By: {0}"
            Me.XrTableCellPaidBy.Weight = 1.5R
            '
            'XrTableCellPaidByBlank
            '
            Me.XrTableCellPaidByBlank.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
            Me.XrTableCellPaidByBlank.Name = "XrTableCellPaidByBlank"
            Me.XrTableCellPaidByBlank.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 3, 0, 100.0!)
            Me.XrTableCellPaidByBlank.StylePriority.UseBorders = False
            Me.XrTableCellPaidByBlank.StylePriority.UsePadding = False
            Me.XrTableCellPaidByBlank.Text = "If Paid After: {0}"
            Me.XrTableCellPaidByBlank.Weight = 1.5R
            '
            'XrTableRowTotals
            '
            Me.XrTableRowTotals.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellDiscountTotalAmount, Me.XrTableCellDiscountInvoiceTotalAmount})
            Me.XrTableRowTotals.Name = "XrTableRowTotals"
            Me.XrTableRowTotals.Visible = False
            Me.XrTableRowTotals.Weight = 1.4583338165283204R
            '
            'XrTableCellDiscountTotalAmount
            '
            Me.XrTableCellDiscountTotalAmount.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.XrTableCellDiscountTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DiscountAmount")})
            Me.XrTableCellDiscountTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellDiscountTotalAmount.Name = "XrTableCellDiscountTotalAmount"
            Me.XrTableCellDiscountTotalAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100.0!)
            Me.XrTableCellDiscountTotalAmount.StylePriority.UseBorders = False
            Me.XrTableCellDiscountTotalAmount.StylePriority.UseFont = False
            Me.XrTableCellDiscountTotalAmount.StylePriority.UsePadding = False
            Me.XrTableCellDiscountTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary15.FormatString = "{0:c2}"
            XrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCellDiscountTotalAmount.Summary = XrSummary15
            Me.XrTableCellDiscountTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.XrTableCellDiscountTotalAmount.Weight = 1.5R
            '
            'XrTableCellDiscountInvoiceTotalAmount
            '
            Me.XrTableCellDiscountInvoiceTotalAmount.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.XrTableCellDiscountInvoiceTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrTableCellDiscountInvoiceTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellDiscountInvoiceTotalAmount.Name = "XrTableCellDiscountInvoiceTotalAmount"
            Me.XrTableCellDiscountInvoiceTotalAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100.0!)
            Me.XrTableCellDiscountInvoiceTotalAmount.StylePriority.UseBorders = False
            Me.XrTableCellDiscountInvoiceTotalAmount.StylePriority.UseFont = False
            Me.XrTableCellDiscountInvoiceTotalAmount.StylePriority.UsePadding = False
            Me.XrTableCellDiscountInvoiceTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary16.FormatString = "{0:c2}"
            XrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCellDiscountInvoiceTotalAmount.Summary = XrSummary16
            Me.XrTableCellDiscountInvoiceTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.XrTableCellDiscountInvoiceTotalAmount.Weight = 1.5R
            '
            'XrLabelInvoiceSubTotalData
            '
            Me.XrLabelInvoiceSubTotalData.CanShrink = True
            Me.XrLabelInvoiceSubTotalData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobTotal")})
            Me.XrLabelInvoiceSubTotalData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceSubTotalData.FormattingRules.Add(Me.FormattingRuleInvoiceTax)
            Me.XrLabelInvoiceSubTotalData.LocationFloat = New DevExpress.Utils.PointFloat(543.4275!, 5.937449!)
            Me.XrLabelInvoiceSubTotalData.Name = "XrLabelInvoiceSubTotalData"
            Me.XrLabelInvoiceSubTotalData.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelInvoiceSubTotalData.StylePriority.UseFont = False
            Me.XrLabelInvoiceSubTotalData.StylePriority.UsePadding = False
            Me.XrLabelInvoiceSubTotalData.StylePriority.UseTextAlignment = False
            XrSummary17.FormatString = "{0:n2}"
            XrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelInvoiceSubTotalData.Summary = XrSummary17
            Me.XrLabelInvoiceSubTotalData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelExchangeRateNote
            '
            Me.XrLabelExchangeRateNote.BorderColor = System.Drawing.Color.Black
            Me.XrLabelExchangeRateNote.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelExchangeRateNote.BorderWidth = 1.0!
            Me.XrLabelExchangeRateNote.CanGrow = False
            Me.XrLabelExchangeRateNote.CanShrink = True
            Me.XrLabelExchangeRateNote.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelExchangeRateNote.LocationFloat = New DevExpress.Utils.PointFloat(2.031485!, 191.8!)
            Me.XrLabelExchangeRateNote.Name = "XrLabelExchangeRateNote"
            Me.XrLabelExchangeRateNote.Scripts.OnBeforePrint = "XrLabelStandardComment_BeforePrint"
            Me.XrLabelExchangeRateNote.SizeF = New System.Drawing.SizeF(746.0!, 17.0!)
            Me.XrLabelExchangeRateNote.StylePriority.UseBackColor = False
            Me.XrLabelExchangeRateNote.StylePriority.UsePadding = False
            Me.XrLabelExchangeRateNote.StylePriority.UseTextAlignment = False
            XrSummary18.FormatString = "{0}"
            Me.XrLabelExchangeRateNote.Summary = XrSummary18
            Me.XrLabelExchangeRateNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.XrLabelExchangeRateNote.Visible = False
            '
            'XrLabelTaxable
            '
            Me.XrLabelTaxable.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
            Me.XrLabelTaxable.FormattingRules.Add(Me.FormattingRuleTaxable)
            Me.XrLabelTaxable.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 39.45832!)
            Me.XrLabelTaxable.Name = "XrLabelTaxable"
            Me.XrLabelTaxable.SizeF = New System.Drawing.SizeF(167.0!, 17.0!)
            Me.XrLabelTaxable.StylePriority.UseFont = False
            Me.XrLabelTaxable.StylePriority.UsePadding = False
            Me.XrLabelTaxable.Text = "*Taxable"
            Me.XrLabelTaxable.Visible = False
            '
            'FormattingRuleTaxable
            '
            Me.FormattingRuleTaxable.Condition = "[Parameters.IndicateTaxableFunctions] == True"
            Me.FormattingRuleTaxable.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleTaxable.Name = "FormattingRuleTaxable"
            '
            'XrSubreportInvoiceTaxInformation
            '
            Me.XrSubreportInvoiceTaxInformation.CanShrink = True
            Me.XrSubreportInvoiceTaxInformation.FormattingRules.Add(Me.FormattingRuleInvoiceTax)
            Me.XrSubreportInvoiceTaxInformation.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 22.93746!)
            Me.XrSubreportInvoiceTaxInformation.Name = "XrSubreportInvoiceTaxInformation"
            Me.XrSubreportInvoiceTaxInformation.ReportSource = New AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.TaxInformationSubReport()
            Me.XrSubreportInvoiceTaxInformation.SizeF = New System.Drawing.SizeF(444.215!, 55.00001!)
            '
            'XrLabelInvoiceSubTotal
            '
            Me.XrLabelInvoiceSubTotal.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelInvoiceSubTotal.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceSubTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceSubTotal.BorderWidth = 1.0!
            Me.XrLabelInvoiceSubTotal.CanShrink = True
            Me.XrLabelInvoiceSubTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceSubTotal.ForeColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceSubTotal.FormattingRules.Add(Me.FormattingRuleInvoiceTax)
            Me.XrLabelInvoiceSubTotal.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 5.937449!)
            Me.XrLabelInvoiceSubTotal.Name = "XrLabelInvoiceSubTotal"
            Me.XrLabelInvoiceSubTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelInvoiceSubTotal.SizeF = New System.Drawing.SizeF(240.9268!, 17.0!)
            Me.XrLabelInvoiceSubTotal.Text = "Sub-Total"
            Me.XrLabelInvoiceSubTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceTTDSubTotalData
            '
            Me.XrLabelInvoiceTTDSubTotalData.CanShrink = True
            Me.XrLabelInvoiceTTDSubTotalData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TTDTotal")})
            Me.XrLabelInvoiceTTDSubTotalData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceTTDSubTotalData.FormattingRules.Add(Me.FormattingRuleInvoiceTax)
            Me.XrLabelInvoiceTTDSubTotalData.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 5.937467!)
            Me.XrLabelInvoiceTTDSubTotalData.Name = "XrLabelInvoiceTTDSubTotalData"
            Me.XrLabelInvoiceTTDSubTotalData.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelInvoiceTTDSubTotalData.StylePriority.UseFont = False
            Me.XrLabelInvoiceTTDSubTotalData.StylePriority.UsePadding = False
            Me.XrLabelInvoiceTTDSubTotalData.StylePriority.UseTextAlignment = False
            XrSummary19.FormatString = "{0:n2}"
            XrSummary19.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelInvoiceTTDSubTotalData.Summary = XrSummary19
            Me.XrLabelInvoiceTTDSubTotalData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelStandardComment
            '
            Me.XrLabelStandardComment.BorderColor = System.Drawing.Color.Black
            Me.XrLabelStandardComment.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelStandardComment.BorderWidth = 1.0!
            Me.XrLabelStandardComment.CanShrink = True
            Me.XrLabelStandardComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceFooterComment")})
            Me.XrLabelStandardComment.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelStandardComment.LocationFloat = New DevExpress.Utils.PointFloat(2.031485!, 208.8!)
            Me.XrLabelStandardComment.Multiline = True
            Me.XrLabelStandardComment.Name = "XrLabelStandardComment"
            Me.XrLabelStandardComment.Scripts.OnBeforePrint = "XrLabelStandardComment_BeforePrint"
            Me.XrLabelStandardComment.SizeF = New System.Drawing.SizeF(746.0!, 17.0!)
            Me.XrLabelStandardComment.StylePriority.UseBackColor = False
            Me.XrLabelStandardComment.StylePriority.UsePadding = False
            Me.XrLabelStandardComment.StylePriority.UseTextAlignment = False
            XrSummary20.FormatString = "{0}"
            Me.XrLabelStandardComment.Summary = XrSummary20
            Me.XrLabelStandardComment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'FormattingRuleQuantity
            '
            Me.FormattingRuleQuantity.Condition = "[Parameters.ShowQuantity]=False Or [FunctionType] = 'E'"
            Me.FormattingRuleQuantity.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleQuantity.Name = "FormattingRuleQuantity"
            '
            'FormattingRuleHours
            '
            Me.FormattingRuleHours.Condition = "[Parameters.ShowEmployeeHours]=False Or [FunctionType] <> 'E'"
            Me.FormattingRuleHours.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleHours.Name = "FormattingRuleHours"
            '
            'TotalPhrase
            '
            Me.TotalPhrase.Expression = "Iif([Parameters.HideComponentNumberAndDescription], 'Total for Job:', 'Total for " &
    "Job/Component:')"
            Me.TotalPhrase.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.TotalPhrase.Name = "TotalPhrase"
            '
            'ShowQuantity
            '
            Me.ShowQuantity.Name = "ShowQuantity"
            Me.ShowQuantity.Type = GetType(Boolean)
            Me.ShowQuantity.ValueInfo = "False"
            Me.ShowQuantity.Visible = False
            '
            'ShowEmployeeHours
            '
            Me.ShowEmployeeHours.Name = "ShowEmployeeHours"
            Me.ShowEmployeeHours.Type = GetType(Boolean)
            Me.ShowEmployeeHours.ValueInfo = "False"
            Me.ShowEmployeeHours.Visible = False
            '
            'IncludeClientReference
            '
            Me.IncludeClientReference.Name = "IncludeClientReference"
            Me.IncludeClientReference.Type = GetType(Boolean)
            Me.IncludeClientReference.ValueInfo = "False"
            Me.IncludeClientReference.Visible = False
            '
            'IncludeClientPO
            '
            Me.IncludeClientPO.Name = "IncludeClientPO"
            Me.IncludeClientPO.Type = GetType(Boolean)
            Me.IncludeClientPO.ValueInfo = "False"
            Me.IncludeClientPO.Visible = False
            '
            'IncludeAccountExecutive
            '
            Me.IncludeAccountExecutive.Name = "IncludeAccountExecutive"
            Me.IncludeAccountExecutive.Type = GetType(Boolean)
            Me.IncludeAccountExecutive.ValueInfo = "False"
            Me.IncludeAccountExecutive.Visible = False
            '
            'IncludeSalesClass
            '
            Me.IncludeSalesClass.Name = "IncludeSalesClass"
            Me.IncludeSalesClass.Type = GetType(Boolean)
            Me.IncludeSalesClass.ValueInfo = "False"
            Me.IncludeSalesClass.Visible = False
            '
            'IncludeInvoiceDueDate
            '
            Me.IncludeInvoiceDueDate.Name = "IncludeInvoiceDueDate"
            Me.IncludeInvoiceDueDate.Type = GetType(Boolean)
            Me.IncludeInvoiceDueDate.ValueInfo = "False"
            Me.IncludeInvoiceDueDate.Visible = False
            '
            'HideComponentNumberAndDescription
            '
            Me.HideComponentNumberAndDescription.Name = "HideComponentNumberAndDescription"
            Me.HideComponentNumberAndDescription.Type = GetType(Boolean)
            Me.HideComponentNumberAndDescription.ValueInfo = "False"
            Me.HideComponentNumberAndDescription.Visible = False
            '
            'ShowBillingHistory
            '
            Me.ShowBillingHistory.Name = "ShowBillingHistory"
            Me.ShowBillingHistory.Type = GetType(Boolean)
            Me.ShowBillingHistory.ValueInfo = "False"
            Me.ShowBillingHistory.Visible = False
            '
            'ShowTaxSeparately
            '
            Me.ShowTaxSeparately.Name = "ShowTaxSeparately"
            Me.ShowTaxSeparately.Type = GetType(Boolean)
            Me.ShowTaxSeparately.ValueInfo = "False"
            Me.ShowTaxSeparately.Visible = False
            '
            'ShowCommissionSeparately
            '
            Me.ShowCommissionSeparately.Name = "ShowCommissionSeparately"
            Me.ShowCommissionSeparately.Type = GetType(Boolean)
            Me.ShowCommissionSeparately.ValueInfo = "False"
            Me.ShowCommissionSeparately.Visible = False
            '
            'IndicateTaxableFunctions
            '
            Me.IndicateTaxableFunctions.Name = "IndicateTaxableFunctions"
            Me.IndicateTaxableFunctions.Type = GetType(Boolean)
            Me.IndicateTaxableFunctions.ValueInfo = "False"
            Me.IndicateTaxableFunctions.Visible = False
            '
            'JobComponentAmount
            '
            Me.JobComponentAmount.Expression = "[NetAmount] +[CommissionAmount]+Iif([Parameters.ShowTaxSeparately]==True And ([Pa" &
    "rameters.TaxTotalLocation] == 1 Or [Parameters.TaxTotalLocation] == 3), [TotalTa" &
    "x] ,0)"
            Me.JobComponentAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.JobComponentAmount.Name = "JobComponentAmount"
            '
            'TTDJobComponentAmount
            '
            Me.TTDJobComponentAmount.Expression = "[TTDNetAmount] +[TTDCommissionAmount]+Iif([Parameters.ShowTaxSeparately]==True An" &
    "d ([Parameters.TaxTotalLocation] == 1 Or [Parameters.TaxTotalLocation] == 3), [T" &
    "TDTotalTax] ,0)"
            Me.TTDJobComponentAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.TTDJobComponentAmount.Name = "TTDJobComponentAmount"
            '
            'HideJobInfo
            '
            Me.HideJobInfo.Name = "HideJobInfo"
            Me.HideJobInfo.Type = GetType(Boolean)
            Me.HideJobInfo.ValueInfo = "False"
            Me.HideJobInfo.Visible = False
            '
            'BillingApprovalClientComment
            '
            Me.BillingApprovalClientComment.Name = "BillingApprovalClientComment"
            Me.BillingApprovalClientComment.Type = GetType(Boolean)
            Me.BillingApprovalClientComment.ValueInfo = "False"
            Me.BillingApprovalClientComment.Visible = False
            '
            'JobComment
            '
            Me.JobComment.Name = "JobComment"
            Me.JobComment.Type = GetType(Boolean)
            Me.JobComment.ValueInfo = "False"
            Me.JobComment.Visible = False
            '
            'JobComponentComment
            '
            Me.JobComponentComment.Name = "JobComponentComment"
            Me.JobComponentComment.Type = GetType(Boolean)
            Me.JobComponentComment.ValueInfo = "False"
            Me.JobComponentComment.Visible = False
            '
            'EstimateComment
            '
            Me.EstimateComment.Name = "EstimateComment"
            Me.EstimateComment.Type = GetType(Boolean)
            Me.EstimateComment.ValueInfo = "False"
            Me.EstimateComment.Visible = False
            '
            'EstimateComponentComment
            '
            Me.EstimateComponentComment.Name = "EstimateComponentComment"
            Me.EstimateComponentComment.Type = GetType(Boolean)
            Me.EstimateComponentComment.ValueInfo = "False"
            Me.EstimateComponentComment.Visible = False
            '
            'EstimateQuoteComment
            '
            Me.EstimateQuoteComment.Name = "EstimateQuoteComment"
            Me.EstimateQuoteComment.Type = GetType(Boolean)
            Me.EstimateQuoteComment.ValueInfo = "False"
            Me.EstimateQuoteComment.Visible = False
            '
            'EstimateRevisionComment
            '
            Me.EstimateRevisionComment.Name = "EstimateRevisionComment"
            Me.EstimateRevisionComment.Type = GetType(Boolean)
            Me.EstimateRevisionComment.ValueInfo = "False"
            Me.EstimateRevisionComment.Visible = False
            '
            'TaxTotalLocation
            '
            Me.TaxTotalLocation.Name = "TaxTotalLocation"
            Me.TaxTotalLocation.Type = GetType(Integer)
            Me.TaxTotalLocation.ValueInfo = "2"
            Me.TaxTotalLocation.Visible = False
            '
            'ShowCampaign
            '
            Me.ShowCampaign.Name = "ShowCampaign"
            Me.ShowCampaign.Type = GetType(Boolean)
            Me.ShowCampaign.ValueInfo = "False"
            Me.ShowCampaign.Visible = False
            '
            'ShowCampaignComment
            '
            Me.ShowCampaignComment.Name = "ShowCampaignComment"
            Me.ShowCampaignComment.Type = GetType(Boolean)
            Me.ShowCampaignComment.ValueInfo = "False"
            Me.ShowCampaignComment.Visible = False
            '
            'ClientPOLocation
            '
            Me.ClientPOLocation.Name = "ClientPOLocation"
            Me.ClientPOLocation.Type = GetType(Integer)
            Me.ClientPOLocation.ValueInfo = "1"
            Me.ClientPOLocation.Visible = False
            '
            'ClientRefLocation
            '
            Me.ClientRefLocation.Name = "ClientRefLocation"
            Me.ClientRefLocation.Type = GetType(Integer)
            Me.ClientRefLocation.ValueInfo = "1"
            Me.ClientRefLocation.Visible = False
            '
            'SalesClassLocation
            '
            Me.SalesClassLocation.Name = "SalesClassLocation"
            Me.SalesClassLocation.Type = GetType(Integer)
            Me.SalesClassLocation.ValueInfo = "1"
            Me.SalesClassLocation.Visible = False
            '
            'CampaignLocation
            '
            Me.CampaignLocation.Name = "CampaignLocation"
            Me.CampaignLocation.Type = GetType(Integer)
            Me.CampaignLocation.ValueInfo = "1"
            Me.CampaignLocation.Visible = False
            '
            'GroupHeaderHeaderGroupBy
            '
            Me.GroupHeaderHeaderGroupBy.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelGroupByHeader1, Me.XrLabelGroupByHeader1Label})
            Me.GroupHeaderHeaderGroupBy.FormattingRules.Add(Me.FormattingRuleHeaderGroupBy)
            Me.GroupHeaderHeaderGroupBy.HeightF = 17.70833!
            Me.GroupHeaderHeaderGroupBy.Level = 3
            Me.GroupHeaderHeaderGroupBy.Name = "GroupHeaderHeaderGroupBy"
            Me.GroupHeaderHeaderGroupBy.Visible = False
            '
            'XrLabelGroupByHeader1
            '
            Me.XrLabelGroupByHeader1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HeaderGroupByData1")})
            Me.XrLabelGroupByHeader1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGroupByHeader1.LocationFloat = New DevExpress.Utils.PointFloat(141.5834!, 0!)
            Me.XrLabelGroupByHeader1.Name = "XrLabelGroupByHeader1"
            Me.XrLabelGroupByHeader1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupByHeader1.SizeF = New System.Drawing.SizeF(608.4166!, 17.0!)
            Me.XrLabelGroupByHeader1.StylePriority.UseFont = False
            '
            'XrLabelGroupByHeader1Label
            '
            Me.XrLabelGroupByHeader1Label.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HeaderGroupByLabel1")})
            Me.XrLabelGroupByHeader1Label.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGroupByHeader1Label.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabelGroupByHeader1Label.Name = "XrLabelGroupByHeader1Label"
            Me.XrLabelGroupByHeader1Label.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGroupByHeader1Label.SizeF = New System.Drawing.SizeF(141.5834!, 17.0!)
            Me.XrLabelGroupByHeader1Label.StylePriority.UseFont = False
            '
            'FormattingRuleHeaderGroupBy
            '
            Me.FormattingRuleHeaderGroupBy.Condition = "[Parameters.HeaderGroupBy]  != 0"
            Me.FormattingRuleHeaderGroupBy.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleHeaderGroupBy.Name = "FormattingRuleHeaderGroupBy"
            '
            'GroupFooterHeaderGroupBy
            '
            Me.GroupFooterHeaderGroupBy.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLineHGBTotal, Me.XrLabelHGBTotalAmount, Me.XrLabelTotalForHGB, Me.XrLineHGB2, Me.XrLineHGB1})
            Me.GroupFooterHeaderGroupBy.FormattingRules.Add(Me.FormattingRuleHeaderGroupBy)
            Me.GroupFooterHeaderGroupBy.HeightF = 31.00002!
            Me.GroupFooterHeaderGroupBy.Level = 3
            Me.GroupFooterHeaderGroupBy.Name = "GroupFooterHeaderGroupBy"
            Me.GroupFooterHeaderGroupBy.Visible = False
            '
            'XrLineHGBTotal
            '
            Me.XrLineHGBTotal.BorderColor = System.Drawing.Color.Black
            Me.XrLineHGBTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineHGBTotal.BorderWidth = 1.0!
            Me.XrLineHGBTotal.ForeColor = System.Drawing.Color.Black
            Me.XrLineHGBTotal.LocationFloat = New DevExpress.Utils.PointFloat(0!, 29.00002!)
            Me.XrLineHGBTotal.Name = "XrLineHGBTotal"
            Me.XrLineHGBTotal.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            '
            'XrLabelHGBTotalAmount
            '
            Me.XrLabelHGBTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentAmount")})
            Me.XrLabelHGBTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelHGBTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(651.1072!, 9.000023!)
            Me.XrLabelHGBTotalAmount.Name = "XrLabelHGBTotalAmount"
            Me.XrLabelHGBTotalAmount.SizeF = New System.Drawing.SizeF(91.1394!, 17.0!)
            Me.XrLabelHGBTotalAmount.StylePriority.UseFont = False
            Me.XrLabelHGBTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelHGBTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary21.FormatString = "{0:n2}"
            XrSummary21.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelHGBTotalAmount.Summary = XrSummary21
            Me.XrLabelHGBTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelTotalForHGB
            '
            Me.XrLabelTotalForHGB.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalHGBPhrase")})
            Me.XrLabelTotalForHGB.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalForHGB.LocationFloat = New DevExpress.Utils.PointFloat(373.9583!, 9.000023!)
            Me.XrLabelTotalForHGB.Name = "XrLabelTotalForHGB"
            Me.XrLabelTotalForHGB.SizeF = New System.Drawing.SizeF(164.96!, 17.0!)
            Me.XrLabelTotalForHGB.StylePriority.UseFont = False
            Me.XrLabelTotalForHGB.StylePriority.UsePadding = False
            '
            'XrLineHGB2
            '
            Me.XrLineHGB2.BorderColor = System.Drawing.Color.Black
            Me.XrLineHGB2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineHGB2.BorderWidth = 1.0!
            Me.XrLineHGB2.ForeColor = System.Drawing.Color.Black
            Me.XrLineHGB2.LocationFloat = New DevExpress.Utils.PointFloat(651.1072!, 3.000008!)
            Me.XrLineHGB2.Name = "XrLineHGB2"
            Me.XrLineHGB2.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            Me.XrLineHGB2.Visible = False
            '
            'XrLineHGB1
            '
            Me.XrLineHGB1.BorderColor = System.Drawing.Color.Black
            Me.XrLineHGB1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineHGB1.BorderWidth = 1.0!
            Me.XrLineHGB1.ForeColor = System.Drawing.Color.Black
            Me.XrLineHGB1.LocationFloat = New DevExpress.Utils.PointFloat(651.1072!, 0!)
            Me.XrLineHGB1.Name = "XrLineHGB1"
            Me.XrLineHGB1.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            Me.XrLineHGB1.Visible = False
            '
            'HeaderGroupBy
            '
            Me.HeaderGroupBy.Name = "HeaderGroupBy"
            Me.HeaderGroupBy.Type = GetType(Integer)
            Me.HeaderGroupBy.ValueInfo = "0"
            Me.HeaderGroupBy.Visible = False
            '
            'HeaderGroupByLabel1
            '
            Me.HeaderGroupByLabel1.Expression = resources.GetString("HeaderGroupByLabel1.Expression")
            Me.HeaderGroupByLabel1.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.HeaderGroupByLabel1.Name = "HeaderGroupByLabel1"
            '
            'HeaderGroupByData1
            '
            Me.HeaderGroupByData1.Expression = resources.GetString("HeaderGroupByData1.Expression")
            Me.HeaderGroupByData1.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.HeaderGroupByData1.Name = "HeaderGroupByData1"
            '
            'InvoiceComment
            '
            Me.InvoiceComment.Name = "InvoiceComment"
            Me.InvoiceComment.Type = GetType(Boolean)
            Me.InvoiceComment.ValueInfo = "False"
            Me.InvoiceComment.Visible = False
            '
            'TotalHGBPhrase
            '
            Me.TotalHGBPhrase.Expression = resources.GetString("TotalHGBPhrase.Expression")
            Me.TotalHGBPhrase.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.TotalHGBPhrase.Name = "TotalHGBPhrase"
            '
            'JobComponentSubTotalAmount
            '
            Me.JobComponentSubTotalAmount.Expression = "[NetAmount] +[CommissionAmount]"
            Me.JobComponentSubTotalAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.JobComponentSubTotalAmount.Name = "JobComponentSubTotalAmount"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)
            '
            'TTDJobComponentSubTotalAmount
            '
            Me.TTDJobComponentSubTotalAmount.Expression = "[TTDNetAmount] +[TTDCommissionAmount]"
            Me.TTDJobComponentSubTotalAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.TTDJobComponentSubTotalAmount.Name = "TTDJobComponentSubTotalAmount"
            '
            'TTDTotal
            '
            Me.TTDTotal.Expression = "[TTDNetAmount] +[TTDCommissionAmount]+Iif([Parameters.ShowTaxSeparately]==True, 0" &
    ",[TTDTotalTax])"
            Me.TTDTotal.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.TTDTotal.Name = "TTDTotal"
            '
            'JobTotal
            '
            Me.JobTotal.Expression = "[NetAmount] +[CommissionAmount]+Iif([Parameters.ShowTaxSeparately]==True,0,[Total" &
    "Tax])"
            Me.JobTotal.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.JobTotal.Name = "JobTotal"
            '
            'Invoice
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeaderInvoice, Me.GroupHeaderJobComponent, Me.GroupHeaderJobComponentComment, Me.GroupHeaderFunction, Me.PageFooter, Me.GroupFooterJobComponent, Me.GroupFooterJobComponentComment, Me.GroupFooterFunction, Me.GroupFooterInvoice, Me.GroupHeaderHeaderGroupBy, Me.GroupFooterHeaderGroupBy})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.JobTotal, Me.TTDTotal, Me.JobComponentSubTotalAmount, Me.TTDJobComponentSubTotalAmount, Me.TotalHGBPhrase, Me.HeaderGroupByLabel1, Me.HeaderGroupByData1, Me.TotalPhrase, Me.JobComponentAmount, Me.TTDJobComponentAmount})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleShowInvoiceComment, Me.FormattingRuleHeaderGroupBy, Me.FormattingRuleInvoiceCampaign, Me.FormattingRuleInvoiceClientReference, Me.FormattingRuleJobClientReference, Me.FormattingRuleInvoiceSalesClass, Me.FormattingRuleJobSalesClass, Me.FormattingRuleInvoiceClientPO, Me.FormattingRuleAccountExecutive, Me.FormattingRuleInvoiceDueDate, Me.FormattingRuleQuantityAndHours, Me.FormattingRuleCommission, Me.FormattingRuleInvoiceTax, Me.FormattingRuleQuantity, Me.FormattingRuleHours, Me.FormattingRuleJC, Me.FormattingRuleTaxable, Me.FormattingRuleShowBillingHistory, Me.FormattingRuleJobInfo, Me.FormattingRuleBillingApprovalClientComment, Me.FormattingRuleJobComponentComment, Me.FormattingRuleEstimateComment, Me.FormattingRuleEstimateComponentComment, Me.FormattingRuleEstimateRevisionComment, Me.FormattingRuleJobComment, Me.FormattingRuleEstimateQuoteComment, Me.FormattingRuleJobTax, Me.FormattingRuleJobCampaign, Me.FormattingRuleCampaignComment, Me.FormattingRuleJobClientPO})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.InvoiceComment, Me.HeaderGroupBy, Me.ClientRefLocation, Me.SalesClassLocation, Me.CampaignLocation, Me.ShowQuantity, Me.ShowEmployeeHours, Me.IncludeClientReference, Me.IncludeClientPO, Me.IncludeAccountExecutive, Me.IncludeSalesClass, Me.IncludeInvoiceDueDate, Me.HideComponentNumberAndDescription, Me.ShowBillingHistory, Me.ShowTaxSeparately, Me.ShowCommissionSeparately, Me.IndicateTaxableFunctions, Me.HideJobInfo, Me.BillingApprovalClientComment, Me.JobComment, Me.JobComponentComment, Me.EstimateComment, Me.EstimateComponentComment, Me.EstimateQuoteComment, Me.EstimateRevisionComment, Me.TaxTotalLocation, Me.ShowCampaign, Me.ShowCampaignComment, Me.ClientPOLocation})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.XrTableReportHeader, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrTableJobInfo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrRichText2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrRichText3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrRichText4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrTableComment, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrTableJobTax, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrTableTotals, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents XrPictureBoxHeaderLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents XrLineHeaderLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelLocationHeaderInfo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceTitle As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDueDateData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelPage As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceNumberData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDueDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDateData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelAddress As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderInvoice As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelBillingComment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineInvoiceHeaderLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelHoursQuantity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineInvoiceHeaderLine2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelCurrent As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderJobComponent As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupHeaderJobComponentComment As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupHeaderFunction As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrPageInfo As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents XrLabelLocationFooterInfo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterJobComponent As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupFooterJobComponentComment As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupFooterFunction As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupFooterInvoice As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabelInvoiceSubTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceTTDSubTotalData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelStandardComment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalForJob As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineJC1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLineJC2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents Line206 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelCommission As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCommissionAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FormattingRuleInvoiceDueDate As DevExpress.XtraReports.UI.FormattingRule
        'Friend WithEvents FormattingRuleClientReference As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleInvoiceClientPO As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleAccountExecutive As DevExpress.XtraReports.UI.FormattingRule
        'Friend WithEvents FormattingRuleSalesClass As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleQuantityAndHours As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleCommission As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleInvoiceTax As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleQuantity As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleHours As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents XrSubreportInvoiceTaxInformation As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrTableReportHeader As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowClientReference As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellClientReferenceLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellClientReference As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowClientPO As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellClientPOLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellClientPO As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowAccountExecutive As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellAccountExecutiveLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellAccountExecutive As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowSalesClass As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellSalesClassLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellSalesClass As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableJobInfo As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowJob As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellJob As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowJobComponent As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobComponentLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellJobComponent As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents FormattingRuleJC As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents TotalPhrase As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrSubreportData As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrLabelTaxable As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FormattingRuleTaxable As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents XrSubreportBillingHistory As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents FormattingRuleShowBillingHistory As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents ShowQuantity As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowEmployeeHours As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeClientReference As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeClientPO As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeAccountExecutive As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeSalesClass As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeInvoiceDueDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents HideComponentNumberAndDescription As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowBillingHistory As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowTaxSeparately As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowCommissionSeparately As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IndicateTaxableFunctions As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLabelExchangeRateNote As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobComponentAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabelTotalToDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTTDTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLineTTDJC2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelInvoiceSubTotalData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTTDCommissionAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TTDJobComponentAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabelRate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BillingApprovalClientComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents JobComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents JobComponentComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents EstimateComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents EstimateComponentComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents EstimateQuoteComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents EstimateRevisionComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents FormattingRuleBillingApprovalClientComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleJobComponentComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleEstimateComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleEstimateComponentComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleEstimateRevisionComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleJobComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleEstimateQuoteComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleJobTax As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents TaxTotalLocation As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents HideJobInfo As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents FormattingRuleJobInfo As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents XrTableComment As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowBillingApprovalClientComment As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellBillingApprovalClientComment As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowBillingJobComment As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellBillingJobComment As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowJobComment As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobComment As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowJobComponentComment As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobComponentComment As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowJobCampaignComment As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobCampaignComment As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrSubreportJobTaxInformation As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrTableRowJobCampaign As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobCampaignLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellJobCampaign As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents FormattingRuleJobCampaign As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents ShowCampaign As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowCampaignComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrTableRowJobClientPO As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobClientPOLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellJobClientPO As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents FormattingRuleCampaignComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleJobClientPO As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents ClientPOLocation As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ClientRefLocation As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents SalesClassLocation As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents CampaignLocation As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrTableRowCampaign As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellCampaignLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellCampaign As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowJobClientReference As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobClientReferenceLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellJobClientReference As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowJobSalesClass As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobSalesClassLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellJobSalesClass As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents FormattingRuleInvoiceCampaign As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleInvoiceClientReference As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleInvoiceSalesClass As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleJobClientReference As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleJobSalesClass As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents XrLabelGroupByHeader1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupByHeader1Label As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents HeaderGroupBy As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLineHGB2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLineHGB1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents HeaderGroupByLabel1 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents HeaderGroupByData1 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents FormattingRuleHeaderGroupBy As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents TotalHGBPhrase As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabelHGBTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalForHGB As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderHeaderGroupBy As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterHeaderGroupBy As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents FormattingRuleShowInvoiceComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents InvoiceComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLineJobTotal As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLineHGBTotal As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrRichText2 As DevExpress.XtraReports.UI.XRRichText
        Friend WithEvents XrRichText3 As DevExpress.XtraReports.UI.XRRichText
        Friend WithEvents XrRichText1 As DevExpress.XtraReports.UI.XRRichText
        Friend WithEvents XrRichText4 As DevExpress.XtraReports.UI.XRRichText
        Friend WithEvents XrTableJobTax As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowJobTax As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellJobSubTotal As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableJobSubTotalData As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellSpacer1 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents JobComponentSubTotalAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TTDJobComponentSubTotalAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TTDTotal As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents JobTotal As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrTableTotals As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowStandardTotals As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellTotalLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellTotalAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellSpacer As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowAmountDue As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellAmountDue As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowDates As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellPaidBy As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellPaidByBlank As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowTotals As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellDiscountTotalAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellDiscountInvoiceTotalAmount As DevExpress.XtraReports.UI.XRTableCell
    End Class

End Namespace
