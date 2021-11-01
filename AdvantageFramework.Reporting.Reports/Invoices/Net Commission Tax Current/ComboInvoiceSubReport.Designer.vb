Namespace Invoices.NetCommissionTaxCurrent

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Public Class ComboInvoiceSubReport
		Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComboInvoiceSubReport))
            Dim XrGroupSortingSummary1 As DevExpress.XtraReports.UI.XRGroupSortingSummary = New DevExpress.XtraReports.UI.XRGroupSortingSummary()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.FormattingRuleQuantityAndHours = New DevExpress.XtraReports.UI.FormattingRule()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.FormattingRuleInvoiceClientReference = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleInvoiceClientPO = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleAccountExecutive = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleInvoiceSalesClass = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleInvoiceCampaign = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleInvoiceDueDate = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupHeaderInvoice = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelNet = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCurrentTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineInvoiceHeaderLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelCommission = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineInvoiceHeaderLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelTax = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.GroupFooterJobComponent = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLineJobTotal = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelNetTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine5 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelCommissionTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineCommissionJC2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelCurrentTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineCurrentTotalJC2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrSubreportBillingHistory = New DevExpress.XtraReports.UI.XRSubreport()
            Me.FormattingRuleShowBillingHistory = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabelTotalForJob = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTaxAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineJC1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineJC2 = New DevExpress.XtraReports.UI.XRLine()
            Me.Line206 = New DevExpress.XtraReports.UI.XRLine()
            Me.FormattingRuleInvoiceTax = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupFooterJobComponentComment = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.FormattingRuleCommission = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupFooterFunction = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.GroupFooterInvoice = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabelTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGrandTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTaxable = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleTaxable = New DevExpress.XtraReports.UI.FormattingRule()
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
            Me.HideJobInfo = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BillingApprovalClientComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobComponentComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.EstimateComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.EstimateComponentComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.EstimateQuoteComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.EstimateRevisionComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowCampaign = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowCampaignComment = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ClientPOLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ClientRefLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.SalesClassLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.CampaignLocation = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
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
            CType(Me.XrTableJobInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrRichText2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrRichText3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrRichText4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrTableComment, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'FormattingRuleInvoiceClientReference
            '
            Me.FormattingRuleInvoiceClientReference.Condition = "[Parameters.IncludeClientReference] == True And [Parameters.ClientRefLocation] ==" &
    "1"
            Me.FormattingRuleInvoiceClientReference.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceClientReference.Name = "FormattingRuleInvoiceClientReference"
            '
            'FormattingRuleInvoiceClientPO
            '
            Me.FormattingRuleInvoiceClientPO.Condition = "[Parameters.IncludeClientPO] == True And [Parameters.ClientPOLocation] ==1"
            Me.FormattingRuleInvoiceClientPO.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceClientPO.Name = "FormattingRuleInvoiceClientPO"
            '
            'FormattingRuleAccountExecutive
            '
            Me.FormattingRuleAccountExecutive.Condition = "[Parameters.IncludeAccountExecutive]=False"
            Me.FormattingRuleAccountExecutive.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleAccountExecutive.Name = "FormattingRuleAccountExecutive"
            '
            'FormattingRuleInvoiceSalesClass
            '
            Me.FormattingRuleInvoiceSalesClass.Condition = "[Parameters.IncludeSalesClass] == True And [Parameters.SalesClassLocation] ==1"
            Me.FormattingRuleInvoiceSalesClass.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceSalesClass.Name = "FormattingRuleInvoiceSalesClass"
            '
            'FormattingRuleInvoiceCampaign
            '
            Me.FormattingRuleInvoiceCampaign.Condition = "[Parameters.ShowCampaign] == True And [Parameters.CampaignLocation] ==1"
            Me.FormattingRuleInvoiceCampaign.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceCampaign.Name = "FormattingRuleInvoiceCampaign"
            '
            'FormattingRuleInvoiceDueDate
            '
            Me.FormattingRuleInvoiceDueDate.Condition = "[Parameters.IncludeInvoiceDueDate]=False"
            Me.FormattingRuleInvoiceDueDate.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleInvoiceDueDate.Name = "FormattingRuleInvoiceDueDate"
            '
            'GroupHeaderInvoice
            '
            Me.GroupHeaderInvoice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelNet, Me.XrLabelCurrentTotal, Me.XrLineInvoiceHeaderLine1, Me.XrLabelCommission, Me.XrLineInvoiceHeaderLine2, Me.XrLabelTax})
            Me.GroupHeaderInvoice.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("FullInvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderInvoice.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage
            Me.GroupHeaderInvoice.HeightF = 39.00006!
            Me.GroupHeaderInvoice.KeepTogether = True
            Me.GroupHeaderInvoice.Level = 4
            Me.GroupHeaderInvoice.Name = "GroupHeaderInvoice"
            Me.GroupHeaderInvoice.RepeatEveryPage = True
            '
            'XrLabelNet
            '
            Me.XrLabelNet.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelNet.BorderColor = System.Drawing.Color.Black
            Me.XrLabelNet.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelNet.BorderWidth = 1.0!
            Me.XrLabelNet.CanGrow = False
            Me.XrLabelNet.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelNet.ForeColor = System.Drawing.Color.Black
            Me.XrLabelNet.LocationFloat = New DevExpress.Utils.PointFloat(324.29!, 3.000059!)
            Me.XrLabelNet.Name = "XrLabelNet"
            Me.XrLabelNet.SizeF = New System.Drawing.SizeF(91.14!, 33.0!)
            Me.XrLabelNet.StylePriority.UsePadding = False
            Me.XrLabelNet.StylePriority.UseTextAlignment = False
            Me.XrLabelNet.Text = "Net"
            Me.XrLabelNet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabelCurrentTotal
            '
            Me.XrLabelCurrentTotal.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelCurrentTotal.BorderColor = System.Drawing.Color.Black
            Me.XrLabelCurrentTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelCurrentTotal.BorderWidth = 1.0!
            Me.XrLabelCurrentTotal.CanGrow = False
            Me.XrLabelCurrentTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelCurrentTotal.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCurrentTotal.LocationFloat = New DevExpress.Utils.PointFloat(652.9994!, 3.000059!)
            Me.XrLabelCurrentTotal.Name = "XrLabelCurrentTotal"
            Me.XrLabelCurrentTotal.SizeF = New System.Drawing.SizeF(91.1394!, 33.0!)
            Me.XrLabelCurrentTotal.StylePriority.UsePadding = False
            Me.XrLabelCurrentTotal.StylePriority.UseTextAlignment = False
            Me.XrLabelCurrentTotal.Text = "Current Total"
            Me.XrLabelCurrentTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLineInvoiceHeaderLine1
            '
            Me.XrLineInvoiceHeaderLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineInvoiceHeaderLine1.BorderWidth = 1.0!
            Me.XrLineInvoiceHeaderLine1.ForeColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLineInvoiceHeaderLine1.Name = "XrLineInvoiceHeaderLine1"
            Me.XrLineInvoiceHeaderLine1.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            '
            'XrLabelCommission
            '
            Me.XrLabelCommission.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelCommission.BorderColor = System.Drawing.Color.Black
            Me.XrLabelCommission.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelCommission.BorderWidth = 1.0!
            Me.XrLabelCommission.CanGrow = False
            Me.XrLabelCommission.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelCommission.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCommission.LocationFloat = New DevExpress.Utils.PointFloat(433.86!, 3.0!)
            Me.XrLabelCommission.Name = "XrLabelCommission"
            Me.XrLabelCommission.SizeF = New System.Drawing.SizeF(91.14!, 33.0!)
            Me.XrLabelCommission.StylePriority.UsePadding = False
            Me.XrLabelCommission.StylePriority.UseTextAlignment = False
            Me.XrLabelCommission.Text = "Commission"
            Me.XrLabelCommission.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLineInvoiceHeaderLine2
            '
            Me.XrLineInvoiceHeaderLine2.BorderColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineInvoiceHeaderLine2.BorderWidth = 1.0!
            Me.XrLineInvoiceHeaderLine2.ForeColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 36.00006!)
            Me.XrLineInvoiceHeaderLine2.Name = "XrLineInvoiceHeaderLine2"
            Me.XrLineInvoiceHeaderLine2.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            '
            'XrLabelTax
            '
            Me.XrLabelTax.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelTax.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTax.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTax.BorderWidth = 1.0!
            Me.XrLabelTax.CanGrow = False
            Me.XrLabelTax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTax.ForeColor = System.Drawing.Color.Black
            Me.XrLabelTax.LocationFloat = New DevExpress.Utils.PointFloat(543.4274!, 3.0!)
            Me.XrLabelTax.Name = "XrLabelTax"
            Me.XrLabelTax.SizeF = New System.Drawing.SizeF(91.1394!, 33.0!)
            Me.XrLabelTax.StylePriority.UsePadding = False
            Me.XrLabelTax.StylePriority.UseTextAlignment = False
            Me.XrLabelTax.Text = "Tax"
            Me.XrLabelTax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
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
            Me.XrTableJobInfo.SizeF = New System.Drawing.SizeF(750.0!, 102.0!)
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
            Me.XrTableCellJobCampaignLabel.Weight = 0.312227204401952R
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
            Me.XrTableCellJobCampaign.Weight = 2.64895911026961R
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
            Me.XrTableCellJobLabel.Weight = 0.312227446480517R
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
            Me.XrTableCellJob.Weight = 2.64895886819104R
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
            Me.XrTableCellJobComponentLabel.Weight = 0.312227554987481R
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
            Me.XrTableCellJobComponent.Weight = 2.64895875968408R
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
            Me.XrTableCellJobClientPOLabel.Weight = 0.312227554987481R
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
            Me.XrTableCellJobClientPO.Weight = 2.64895875968408R
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
            Me.XrTableCellJobClientReferenceLabel.Weight = 0.312227523373292R
            '
            'XrTableCellJobClientReference
            '
            Me.XrTableCellJobClientReference.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientReference")})
            Me.XrTableCellJobClientReference.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobClientReference.Name = "XrTableCellJobClientReference"
            Me.XrTableCellJobClientReference.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellJobClientReference.StylePriority.UseFont = False
            Me.XrTableCellJobClientReference.StylePriority.UsePadding = False
            Me.XrTableCellJobClientReference.Weight = 2.64895879129827R
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
            Me.XrTableCellJobSalesClassLabel.Weight = 0.312227493250547R
            '
            'XrTableCellJobSalesClass
            '
            Me.XrTableCellJobSalesClass.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.XrTableCellJobSalesClass.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellJobSalesClass.Name = "XrTableCellJobSalesClass"
            Me.XrTableCellJobSalesClass.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellJobSalesClass.StylePriority.UseFont = False
            Me.XrTableCellJobSalesClass.StylePriority.UsePadding = False
            Me.XrTableCellJobSalesClass.Weight = 2.64895882142101R
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
            'GroupFooterJobComponent
            '
            Me.GroupFooterJobComponent.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLineJobTotal, Me.XrLabelNetTotalAmount, Me.XrLine4, Me.XrLine5, Me.XrLabelCommissionTotalAmount, Me.XrLine2, Me.XrLineCommissionJC2, Me.XrLabelCurrentTotalAmount, Me.XrLine1, Me.XrLineCurrentTotalJC2, Me.XrSubreportBillingHistory, Me.XrLabelTotalForJob, Me.XrLabelTaxAmount, Me.XrLineJC1, Me.XrLineJC2})
            Me.GroupFooterJobComponent.HeightF = 58.58338!
            Me.GroupFooterJobComponent.Level = 2
            Me.GroupFooterJobComponent.Name = "GroupFooterJobComponent"
            '
            'XrLineJobTotal
            '
            Me.XrLineJobTotal.BorderColor = System.Drawing.Color.Black
            Me.XrLineJobTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineJobTotal.BorderWidth = 1.0!
            Me.XrLineJobTotal.ForeColor = System.Drawing.Color.Black
            Me.XrLineJobTotal.LocationFloat = New DevExpress.Utils.PointFloat(0!, 56.58338!)
            Me.XrLineJobTotal.Name = "XrLineJobTotal"
            Me.XrLineJobTotal.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            '
            'XrLabelNetTotalAmount
            '
            Me.XrLabelNetTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount")})
            Me.XrLabelNetTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelNetTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(326.4556!, 10.41667!)
            Me.XrLabelNetTotalAmount.Name = "XrLabelNetTotalAmount"
            Me.XrLabelNetTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelNetTotalAmount.StylePriority.UseFont = False
            Me.XrLabelNetTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelNetTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelNetTotalAmount.Summary = XrSummary1
            Me.XrLabelNetTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine4
            '
            Me.XrLine4.BorderColor = System.Drawing.Color.Black
            Me.XrLine4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine4.BorderWidth = 1.0!
            Me.XrLine4.ForeColor = System.Drawing.Color.Black
            Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(326.455!, 4.416656!)
            Me.XrLine4.Name = "XrLine4"
            Me.XrLine4.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLine5
            '
            Me.XrLine5.BorderColor = System.Drawing.Color.Black
            Me.XrLine5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine5.BorderWidth = 1.0!
            Me.XrLine5.ForeColor = System.Drawing.Color.Black
            Me.XrLine5.LocationFloat = New DevExpress.Utils.PointFloat(326.3738!, 2.416674!)
            Me.XrLine5.Name = "XrLine5"
            Me.XrLine5.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLabelCommissionTotalAmount
            '
            Me.XrLabelCommissionTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CommissionAmount")})
            Me.XrLabelCommissionTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelCommissionTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(433.7794!, 10.41667!)
            Me.XrLabelCommissionTotalAmount.Name = "XrLabelCommissionTotalAmount"
            Me.XrLabelCommissionTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelCommissionTotalAmount.StylePriority.UseFont = False
            Me.XrLabelCommissionTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelCommissionTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelCommissionTotalAmount.Summary = XrSummary2
            Me.XrLabelCommissionTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Black
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 1.0!
            Me.XrLine2.ForeColor = System.Drawing.Color.Black
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(433.8594!, 4.416656!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLineCommissionJC2
            '
            Me.XrLineCommissionJC2.BorderColor = System.Drawing.Color.Black
            Me.XrLineCommissionJC2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineCommissionJC2.BorderWidth = 1.0!
            Me.XrLineCommissionJC2.ForeColor = System.Drawing.Color.Black
            Me.XrLineCommissionJC2.LocationFloat = New DevExpress.Utils.PointFloat(433.7782!, 2.416674!)
            Me.XrLineCommissionJC2.Name = "XrLineCommissionJC2"
            Me.XrLineCommissionJC2.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLabelCurrentTotalAmount
            '
            Me.XrLabelCurrentTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrLabelCurrentTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelCurrentTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 10.41667!)
            Me.XrLabelCurrentTotalAmount.Name = "XrLabelCurrentTotalAmount"
            Me.XrLabelCurrentTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelCurrentTotalAmount.StylePriority.UseFont = False
            Me.XrLabelCurrentTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelCurrentTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelCurrentTotalAmount.Summary = XrSummary3
            Me.XrLabelCurrentTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 1.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Black
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(653.08!, 4.416656!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLineCurrentTotalJC2
            '
            Me.XrLineCurrentTotalJC2.BorderColor = System.Drawing.Color.Black
            Me.XrLineCurrentTotalJC2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineCurrentTotalJC2.BorderWidth = 1.0!
            Me.XrLineCurrentTotalJC2.ForeColor = System.Drawing.Color.Black
            Me.XrLineCurrentTotalJC2.LocationFloat = New DevExpress.Utils.PointFloat(652.9988!, 2.416674!)
            Me.XrLineCurrentTotalJC2.Name = "XrLineCurrentTotalJC2"
            Me.XrLineCurrentTotalJC2.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrSubreportBillingHistory
            '
            Me.XrSubreportBillingHistory.CanShrink = True
            Me.XrSubreportBillingHistory.FormattingRules.Add(Me.FormattingRuleShowBillingHistory)
            Me.XrSubreportBillingHistory.LocationFloat = New DevExpress.Utils.PointFloat(0!, 35.58338!)
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
            Me.XrLabelTotalForJob.LocationFloat = New DevExpress.Utils.PointFloat(85.4166!, 10.41667!)
            Me.XrLabelTotalForJob.Name = "XrLabelTotalForJob"
            Me.XrLabelTotalForJob.SizeF = New System.Drawing.SizeF(240.9584!, 17.0!)
            Me.XrLabelTotalForJob.StylePriority.UsePadding = False
            Me.XrLabelTotalForJob.Text = "Total for Job"
            Me.XrLabelTotalForJob.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelTaxAmount
            '
            Me.XrLabelTaxAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalTax")})
            Me.XrLabelTaxAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTaxAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.4275!, 10.41667!)
            Me.XrLabelTaxAmount.Name = "XrLabelTaxAmount"
            Me.XrLabelTaxAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTaxAmount.StylePriority.UseFont = False
            Me.XrLabelTaxAmount.StylePriority.UsePadding = False
            Me.XrLabelTaxAmount.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTaxAmount.Summary = XrSummary4
            Me.XrLabelTaxAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineJC1
            '
            Me.XrLineJC1.BorderColor = System.Drawing.Color.Black
            Me.XrLineJC1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineJC1.BorderWidth = 1.0!
            Me.XrLineJC1.ForeColor = System.Drawing.Color.Black
            Me.XrLineJC1.LocationFloat = New DevExpress.Utils.PointFloat(543.3512!, 4.416656!)
            Me.XrLineJC1.Name = "XrLineJC1"
            Me.XrLineJC1.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLineJC2
            '
            Me.XrLineJC2.BorderColor = System.Drawing.Color.Black
            Me.XrLineJC2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineJC2.BorderWidth = 1.0!
            Me.XrLineJC2.ForeColor = System.Drawing.Color.Black
            Me.XrLineJC2.LocationFloat = New DevExpress.Utils.PointFloat(543.3512!, 2.416674!)
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
            Me.FormattingRuleInvoiceTax.Condition = "[Parameters.ShowTaxSeparately]=False"
            Me.FormattingRuleInvoiceTax.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleInvoiceTax.Name = "FormattingRuleInvoiceTax"
            '
            'GroupFooterJobComponentComment
            '
            Me.GroupFooterJobComponentComment.HeightF = 0!
            Me.GroupFooterJobComponentComment.Level = 1
            Me.GroupFooterJobComponentComment.Name = "GroupFooterJobComponentComment"
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
            Me.GroupFooterInvoice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTotal, Me.XrLabelGrandTotal, Me.XrLabelTaxable, Me.Line206})
            Me.GroupFooterInvoice.HeightF = 37.25001!
            Me.GroupFooterInvoice.Level = 4
            Me.GroupFooterInvoice.Name = "GroupFooterInvoice"
            '
            'XrLabelTotal
            '
            Me.XrLabelTotal.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelTotal.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTotal.BorderWidth = 1.0!
            Me.XrLabelTotal.CanGrow = False
            Me.XrLabelTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotal.ForeColor = System.Drawing.Color.Black
            Me.XrLabelTotal.LocationFloat = New DevExpress.Utils.PointFloat(450.9185!, 16.04169!)
            Me.XrLabelTotal.Name = "XrLabelTotal"
            Me.XrLabelTotal.SizeF = New System.Drawing.SizeF(87.99994!, 17.0!)
            Me.XrLabelTotal.StylePriority.UsePadding = False
            Me.XrLabelTotal.StylePriority.UseTextAlignment = False
            Me.XrLabelTotal.Text = "Sub-Total"
            Me.XrLabelTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGrandTotal
            '
            Me.XrLabelGrandTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGrandTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrLabelGrandTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGrandTotal.LocationFloat = New DevExpress.Utils.PointFloat(543.4275!, 16.04169!)
            Me.XrLabelGrandTotal.Name = "XrLabelGrandTotal"
            Me.XrLabelGrandTotal.SizeF = New System.Drawing.SizeF(198.8197!, 17.0!)
            Me.XrLabelGrandTotal.StylePriority.UseBorders = False
            Me.XrLabelGrandTotal.StylePriority.UseFont = False
            Me.XrLabelGrandTotal.StylePriority.UsePadding = False
            Me.XrLabelGrandTotal.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:c2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelGrandTotal.Summary = XrSummary5
            Me.XrLabelGrandTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelTaxable
            '
            Me.XrLabelTaxable.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
            Me.XrLabelTaxable.FormattingRules.Add(Me.FormattingRuleTaxable)
            Me.XrLabelTaxable.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 16.04166!)
            Me.XrLabelTaxable.Name = "XrLabelTaxable"
            Me.XrLabelTaxable.SizeF = New System.Drawing.SizeF(75.41663!, 17.0!)
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
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)
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
            Me.XrLabelHGBTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrLabelHGBTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelHGBTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(651.1072!, 9.000023!)
            Me.XrLabelHGBTotalAmount.Name = "XrLabelHGBTotalAmount"
            Me.XrLabelHGBTotalAmount.SizeF = New System.Drawing.SizeF(91.1394!, 17.0!)
            Me.XrLabelHGBTotalAmount.StylePriority.UseFont = False
            Me.XrLabelHGBTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelHGBTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelHGBTotalAmount.Summary = XrSummary6
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
            'ComboInvoiceSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeaderInvoice, Me.GroupHeaderJobComponent, Me.GroupHeaderJobComponentComment, Me.GroupHeaderFunction, Me.GroupFooterJobComponent, Me.GroupFooterJobComponentComment, Me.GroupFooterFunction, Me.GroupFooterInvoice, Me.GroupHeaderHeaderGroupBy, Me.GroupFooterHeaderGroupBy})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.JobComponentSubTotalAmount, Me.TotalHGBPhrase, Me.HeaderGroupByLabel1, Me.HeaderGroupByData1, Me.TotalPhrase})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleShowInvoiceComment, Me.FormattingRuleHeaderGroupBy, Me.FormattingRuleInvoiceCampaign, Me.FormattingRuleInvoiceClientReference, Me.FormattingRuleJobClientReference, Me.FormattingRuleInvoiceSalesClass, Me.FormattingRuleJobSalesClass, Me.FormattingRuleInvoiceClientPO, Me.FormattingRuleAccountExecutive, Me.FormattingRuleInvoiceDueDate, Me.FormattingRuleQuantityAndHours, Me.FormattingRuleCommission, Me.FormattingRuleInvoiceTax, Me.FormattingRuleQuantity, Me.FormattingRuleHours, Me.FormattingRuleJC, Me.FormattingRuleTaxable, Me.FormattingRuleShowBillingHistory, Me.FormattingRuleJobInfo, Me.FormattingRuleBillingApprovalClientComment, Me.FormattingRuleJobComponentComment, Me.FormattingRuleEstimateComment, Me.FormattingRuleEstimateComponentComment, Me.FormattingRuleEstimateRevisionComment, Me.FormattingRuleJobComment, Me.FormattingRuleEstimateQuoteComment, Me.FormattingRuleJobCampaign, Me.FormattingRuleCampaignComment, Me.FormattingRuleJobClientPO})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 0)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.InvoiceComment, Me.HeaderGroupBy, Me.ClientRefLocation, Me.SalesClassLocation, Me.CampaignLocation, Me.ShowQuantity, Me.ShowEmployeeHours, Me.IncludeClientReference, Me.IncludeClientPO, Me.IncludeAccountExecutive, Me.IncludeSalesClass, Me.IncludeInvoiceDueDate, Me.HideComponentNumberAndDescription, Me.ShowBillingHistory, Me.ShowTaxSeparately, Me.ShowCommissionSeparately, Me.IndicateTaxableFunctions, Me.HideJobInfo, Me.BillingApprovalClientComment, Me.JobComment, Me.JobComponentComment, Me.EstimateComment, Me.EstimateComponentComment, Me.EstimateQuoteComment, Me.EstimateRevisionComment, Me.ShowCampaign, Me.ShowCampaignComment, Me.ClientPOLocation})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.XrTableJobInfo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrRichText2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrRichText3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrRichText1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrRichText4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrTableComment, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
		Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
		Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
		Friend WithEvents GroupHeaderInvoice As DevExpress.XtraReports.UI.GroupHeaderBand
		Friend WithEvents XrLineInvoiceHeaderLine1 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLabelCommission As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLineInvoiceHeaderLine2 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLabelTax As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents GroupHeaderJobComponent As DevExpress.XtraReports.UI.GroupHeaderBand
		Friend WithEvents GroupHeaderJobComponentComment As DevExpress.XtraReports.UI.GroupHeaderBand
		Friend WithEvents GroupHeaderFunction As DevExpress.XtraReports.UI.GroupHeaderBand
		Friend WithEvents GroupFooterJobComponent As DevExpress.XtraReports.UI.GroupFooterBand
		Friend WithEvents GroupFooterJobComponentComment As DevExpress.XtraReports.UI.GroupFooterBand
		Friend WithEvents GroupFooterFunction As DevExpress.XtraReports.UI.GroupFooterBand
		Friend WithEvents GroupFooterInvoice As DevExpress.XtraReports.UI.GroupFooterBand
		Friend WithEvents XrLabelTotalForJob As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLabelTaxAmount As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLineJC1 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLineJC2 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents Line206 As DevExpress.XtraReports.UI.XRLine
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
		Friend WithEvents XrLabelCurrentTotal As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLabelCurrentTotalAmount As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLineCurrentTotalJC2 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLabelNet As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLabelNetTotalAmount As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLine5 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLabelCommissionTotalAmount As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLineCommissionJC2 As DevExpress.XtraReports.UI.XRLine
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
		Friend WithEvents JobComponentSubTotalAmount As DevExpress.XtraReports.UI.CalculatedField
		Friend WithEvents XrLabelTotal As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLabelGrandTotal As DevExpress.XtraReports.UI.XRLabel
	End Class

End Namespace
