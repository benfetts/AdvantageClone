Namespace Invoices.ComboInvoice

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Public Class Invoice
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
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrTableReportHeader = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowClientReference = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellClientReferenceLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellClientReference = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowClientPO = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellClientPOLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellClientPO = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowAccountExecutive = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellAccountExecutiveLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellAccountExecutive = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowSalesClass = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellSalesClassLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellSalesClass = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowCampaign = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellCampaignLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellCampaign = New DevExpress.XtraReports.UI.XRTableCell()
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
            Me.XrLabelBillingComment = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleInvoiceClientPO = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleInvoiceSalesClass = New DevExpress.XtraReports.UI.FormattingRule()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrLabelLocationFooterInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterInvoice = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrPanelInvoiceTotal = New DevExpress.XtraReports.UI.XRPanel()
            Me.XrLabelGrandTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelExchangeRateNote = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelStandardComment = New DevExpress.XtraReports.UI.XRLabel()
            Me.IncludeClientPO = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeSalesClass = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeInvoiceDueDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.GroupHeaderInvoiceData = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrSubreportInvoiceBodies = New DevExpress.XtraReports.UI.XRSubreport()
            Me.GroupFooterInvoiceData = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.XrTableReportHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableReportHeader, Me.XrLabelLocationHeaderInfo, Me.XrLineHeaderLine, Me.XrPictureBoxHeaderLogo, Me.XrLabelInvoiceNumber, Me.XrLabelAddress, Me.XrLabelInvoiceDateData, Me.XrLabelInvoiceDueDate, Me.XrLabelInvoiceNumberData, Me.XrLabelPage, Me.XrLabelInvoiceDueDateData, Me.XrLabelInvoiceDate, Me.XrPageInfo, Me.XrLabelInvoiceTitle})
            Me.PageHeader.Dpi = 100.0!
            Me.PageHeader.HeightF = 333.9685!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrTableReportHeader
            '
            Me.XrTableReportHeader.Dpi = 100.0!
            Me.XrTableReportHeader.LocationFloat = New DevExpress.Utils.PointFloat(387.9269!, 248.9685!)
            Me.XrTableReportHeader.Name = "XrTableReportHeader"
            Me.XrTableReportHeader.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowClientReference, Me.XrTableRowClientPO, Me.XrTableRowAccountExecutive, Me.XrTableRowSalesClass, Me.XrTableRowCampaign})
            Me.XrTableReportHeader.SizeF = New System.Drawing.SizeF(356.2883!, 85.0!)
            '
            'XrTableRowClientReference
            '
            Me.XrTableRowClientReference.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellClientReferenceLabel, Me.XrTableCellClientReference})
            Me.XrTableRowClientReference.Dpi = 100.0!
            Me.XrTableRowClientReference.Name = "XrTableRowClientReference"
            Me.XrTableRowClientReference.Weight = 0.249999887803072R
            '
            'XrTableCellClientReferenceLabel
            '
            Me.XrTableCellClientReferenceLabel.Dpi = 100.0!
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
            Me.XrTableCellClientReference.Dpi = 100.0!
            Me.XrTableCellClientReference.Name = "XrTableCellClientReference"
            Me.XrTableCellClientReference.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellClientReference.StylePriority.UsePadding = False
            Me.XrTableCellClientReference.Weight = 1.80433896646588R
            '
            'XrTableRowClientPO
            '
            Me.XrTableRowClientPO.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellClientPOLabel, Me.XrTableCellClientPO})
            Me.XrTableRowClientPO.Dpi = 100.0!
            Me.XrTableRowClientPO.Name = "XrTableRowClientPO"
            Me.XrTableRowClientPO.Weight = 0.249999887803072R
            '
            'XrTableCellClientPOLabel
            '
            Me.XrTableCellClientPOLabel.Dpi = 100.0!
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
            Me.XrTableCellClientPO.Dpi = 100.0!
            Me.XrTableCellClientPO.Name = "XrTableCellClientPO"
            Me.XrTableCellClientPO.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellClientPO.StylePriority.UsePadding = False
            Me.XrTableCellClientPO.Weight = 1.80433896646588R
            '
            'XrTableRowAccountExecutive
            '
            Me.XrTableRowAccountExecutive.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellAccountExecutiveLabel, Me.XrTableCellAccountExecutive})
            Me.XrTableRowAccountExecutive.Dpi = 100.0!
            Me.XrTableRowAccountExecutive.Name = "XrTableRowAccountExecutive"
            Me.XrTableRowAccountExecutive.Weight = 0.249999887803072R
            '
            'XrTableCellAccountExecutiveLabel
            '
            Me.XrTableCellAccountExecutiveLabel.Dpi = 100.0!
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
            Me.XrTableCellAccountExecutive.Dpi = 100.0!
            Me.XrTableCellAccountExecutive.Name = "XrTableCellAccountExecutive"
            Me.XrTableCellAccountExecutive.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellAccountExecutive.StylePriority.UsePadding = False
            Me.XrTableCellAccountExecutive.Weight = 1.80433896646588R
            '
            'XrTableRowSalesClass
            '
            Me.XrTableRowSalesClass.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellSalesClassLabel, Me.XrTableCellSalesClass})
            Me.XrTableRowSalesClass.Dpi = 100.0!
            Me.XrTableRowSalesClass.Name = "XrTableRowSalesClass"
            Me.XrTableRowSalesClass.Weight = 0.249999887803072R
            '
            'XrTableCellSalesClassLabel
            '
            Me.XrTableCellSalesClassLabel.Dpi = 100.0!
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
            Me.XrTableCellSalesClass.Dpi = 100.0!
            Me.XrTableCellSalesClass.Name = "XrTableCellSalesClass"
            Me.XrTableCellSalesClass.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellSalesClass.StylePriority.UsePadding = False
            Me.XrTableCellSalesClass.Weight = 1.80433896646588R
            '
            'XrTableRowCampaign
            '
            Me.XrTableRowCampaign.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellCampaignLabel, Me.XrTableCellCampaign})
            Me.XrTableRowCampaign.Dpi = 100.0!
            Me.XrTableRowCampaign.Name = "XrTableRowCampaign"
            Me.XrTableRowCampaign.Weight = 0.249999887803072R
            '
            'XrTableCellCampaignLabel
            '
            Me.XrTableCellCampaignLabel.Dpi = 100.0!
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
            Me.XrTableCellCampaign.Dpi = 100.0!
            Me.XrTableCellCampaign.Name = "XrTableCellCampaign"
            Me.XrTableCellCampaign.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrTableCellCampaign.StylePriority.UsePadding = False
            Me.XrTableCellCampaign.Weight = 1.80433896646588R
            '
            'XrLabelLocationHeaderInfo
            '
            Me.XrLabelLocationHeaderInfo.BorderColor = System.Drawing.Color.Black
            Me.XrLabelLocationHeaderInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelLocationHeaderInfo.BorderWidth = 1.0!
            Me.XrLabelLocationHeaderInfo.Dpi = 100.0!
            Me.XrLabelLocationHeaderInfo.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelLocationHeaderInfo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 150.0!)
            Me.XrLabelLocationHeaderInfo.Name = "XrLabelLocationHeaderInfo"
            Me.XrLabelLocationHeaderInfo.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
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
            Me.XrLineHeaderLine.Dpi = 100.0!
            Me.XrLineHeaderLine.ForeColor = System.Drawing.Color.Black
            Me.XrLineHeaderLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 168.97!)
            Me.XrLineHeaderLine.Name = "XrLineHeaderLine"
            Me.XrLineHeaderLine.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            Me.XrLineHeaderLine.StylePriority.UseBorderWidth = False
            '
            'XrPictureBoxHeaderLogo
            '
            Me.XrPictureBoxHeaderLogo.Dpi = 100.0!
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
            Me.XrLabelInvoiceNumber.Dpi = 100.0!
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
            Me.XrLabelAddress.Dpi = 100.0!
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
            Me.XrLabelInvoiceDateData.Dpi = 100.0!
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
            Me.XrLabelInvoiceDueDate.Dpi = 100.0!
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
            '
            '
            '
            Me.FormattingRuleInvoiceDueDate.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleInvoiceDueDate.Name = "FormattingRuleInvoiceDueDate"
            '
            'XrLabelInvoiceNumberData
            '
            Me.XrLabelInvoiceNumberData.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceNumberData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceNumberData.BorderWidth = 1.0!
            Me.XrLabelInvoiceNumberData.Dpi = 100.0!
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
            Me.XrLabelPage.Dpi = 100.0!
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
            Me.XrLabelInvoiceDueDateData.Dpi = 100.0!
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
            Me.XrLabelInvoiceDate.Dpi = 100.0!
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
            Me.XrPageInfo.Dpi = 100.0!
            Me.XrPageInfo.LocationFloat = New DevExpress.Utils.PointFloat(530.4685!, 231.9685!)
            Me.XrPageInfo.Name = "XrPageInfo"
            Me.XrPageInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100.0!)
            Me.XrPageInfo.RunningBand = Me.GroupHeaderInvoice
            Me.XrPageInfo.SizeF = New System.Drawing.SizeF(213.7465!, 17.0!)
            Me.XrPageInfo.StylePriority.UsePadding = False
            '
            'GroupHeaderInvoice
            '
            Me.GroupHeaderInvoice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelBillingComment})
            Me.GroupHeaderInvoice.Dpi = 100.0!
            Me.GroupHeaderInvoice.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("FullInvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderInvoice.HeightF = 17.0!
            Me.GroupHeaderInvoice.Level = 1
            Me.GroupHeaderInvoice.Name = "GroupHeaderInvoice"
            '
            'XrLabelBillingComment
            '
            Me.XrLabelBillingComment.CanShrink = True
            Me.XrLabelBillingComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingComment")})
            Me.XrLabelBillingComment.Dpi = 100.0!
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
            Me.XrLabelInvoiceTitle.Dpi = 100.0!
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
            'FormattingRuleInvoiceClientPO
            '
            Me.FormattingRuleInvoiceClientPO.Condition = "[Parameters.IncludeClientPO] == True"
            '
            '
            '
            Me.FormattingRuleInvoiceClientPO.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceClientPO.Name = "FormattingRuleInvoiceClientPO"
            '
            'FormattingRuleInvoiceSalesClass
            '
            Me.FormattingRuleInvoiceSalesClass.Condition = "[Parameters.IncludeSalesClass] == True"
            '
            '
            '
            Me.FormattingRuleInvoiceSalesClass.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleInvoiceSalesClass.Name = "FormattingRuleInvoiceSalesClass"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelLocationFooterInfo})
            Me.PageFooter.Dpi = 100.0!
            Me.PageFooter.HeightF = 17.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'XrLabelLocationFooterInfo
            '
            Me.XrLabelLocationFooterInfo.BorderColor = System.Drawing.Color.Black
            Me.XrLabelLocationFooterInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelLocationFooterInfo.BorderWidth = 1.0!
            Me.XrLabelLocationFooterInfo.Dpi = 100.0!
            Me.XrLabelLocationFooterInfo.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelLocationFooterInfo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabelLocationFooterInfo.Name = "XrLabelLocationFooterInfo"
            Me.XrLabelLocationFooterInfo.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            Me.XrLabelLocationFooterInfo.StylePriority.UseBackColor = False
            Me.XrLabelLocationFooterInfo.StylePriority.UsePadding = False
            Me.XrLabelLocationFooterInfo.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0}"
            Me.XrLabelLocationFooterInfo.Summary = XrSummary7
            Me.XrLabelLocationFooterInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupFooterInvoice
            '
            Me.GroupFooterInvoice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanelInvoiceTotal, Me.XrLabelExchangeRateNote, Me.XrLabelStandardComment})
            Me.GroupFooterInvoice.Dpi = 100.0!
            Me.GroupFooterInvoice.HeightF = 80.33335!
            Me.GroupFooterInvoice.Level = 1
            Me.GroupFooterInvoice.Name = "GroupFooterInvoice"
            '
            'XrPanelInvoiceTotal
            '
            Me.XrPanelInvoiceTotal.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.XrPanelInvoiceTotal.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelGrandTotal, Me.XrLabelTotal})
            Me.XrPanelInvoiceTotal.Dpi = 100.0!
            Me.XrPanelInvoiceTotal.LocationFloat = New DevExpress.Utils.PointFloat(446.11!, 10.00001!)
            Me.XrPanelInvoiceTotal.Name = "XrPanelInvoiceTotal"
            Me.XrPanelInvoiceTotal.SizeF = New System.Drawing.SizeF(300.0!, 29.04167!)
            Me.XrPanelInvoiceTotal.StylePriority.UseBorders = False
            '
            'XrLabelGrandTotal
            '
            Me.XrLabelGrandTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGrandTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrLabelGrandTotal.Dpi = 100.0!
            Me.XrLabelGrandTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGrandTotal.LocationFloat = New DevExpress.Utils.PointFloat(122.4684!, 6.041656!)
            Me.XrLabelGrandTotal.Name = "XrLabelGrandTotal"
            Me.XrLabelGrandTotal.SizeF = New System.Drawing.SizeF(169.5!, 17.0!)
            Me.XrLabelGrandTotal.StylePriority.UseBorders = False
            Me.XrLabelGrandTotal.StylePriority.UseFont = False
            Me.XrLabelGrandTotal.StylePriority.UsePadding = False
            Me.XrLabelGrandTotal.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:c2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelGrandTotal.Summary = XrSummary8
            Me.XrLabelGrandTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelTotal
            '
            Me.XrLabelTotal.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelTotal.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTotal.BorderWidth = 1.0!
            Me.XrLabelTotal.CanGrow = False
            Me.XrLabelTotal.Dpi = 100.0!
            Me.XrLabelTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotal.ForeColor = System.Drawing.Color.Black
            Me.XrLabelTotal.LocationFloat = New DevExpress.Utils.PointFloat(4.926809!, 6.041654!)
            Me.XrLabelTotal.Name = "XrLabelTotal"
            Me.XrLabelTotal.SizeF = New System.Drawing.SizeF(117.5415!, 17.0!)
            Me.XrLabelTotal.StylePriority.UsePadding = False
            Me.XrLabelTotal.StylePriority.UseTextAlignment = False
            Me.XrLabelTotal.Text = "Invoice Total"
            Me.XrLabelTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelExchangeRateNote
            '
            Me.XrLabelExchangeRateNote.BorderColor = System.Drawing.Color.Black
            Me.XrLabelExchangeRateNote.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelExchangeRateNote.BorderWidth = 1.0!
            Me.XrLabelExchangeRateNote.CanShrink = True
            Me.XrLabelExchangeRateNote.Dpi = 100.0!
            Me.XrLabelExchangeRateNote.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelExchangeRateNote.LocationFloat = New DevExpress.Utils.PointFloat(0!, 46.33335!)
            Me.XrLabelExchangeRateNote.Name = "XrLabelExchangeRateNote"
            Me.XrLabelExchangeRateNote.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrLabelExchangeRateNote.Scripts.OnBeforePrint = "XrLabelStandardComment_BeforePrint"
            Me.XrLabelExchangeRateNote.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            Me.XrLabelExchangeRateNote.StylePriority.UseBackColor = False
            Me.XrLabelExchangeRateNote.StylePriority.UsePadding = False
            Me.XrLabelExchangeRateNote.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0}"
            Me.XrLabelExchangeRateNote.Summary = XrSummary9
            Me.XrLabelExchangeRateNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.XrLabelExchangeRateNote.Visible = False
            '
            'XrLabelStandardComment
            '
            Me.XrLabelStandardComment.BorderColor = System.Drawing.Color.Black
            Me.XrLabelStandardComment.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelStandardComment.BorderWidth = 1.0!
            Me.XrLabelStandardComment.CanShrink = True
            Me.XrLabelStandardComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceFooterComment")})
            Me.XrLabelStandardComment.Dpi = 100.0!
            Me.XrLabelStandardComment.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelStandardComment.LocationFloat = New DevExpress.Utils.PointFloat(0!, 63.33335!)
            Me.XrLabelStandardComment.Multiline = True
            Me.XrLabelStandardComment.Name = "XrLabelStandardComment"
            Me.XrLabelStandardComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrLabelStandardComment.Scripts.OnBeforePrint = "XrLabelStandardComment_BeforePrint"
            Me.XrLabelStandardComment.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            Me.XrLabelStandardComment.StylePriority.UseBackColor = False
            Me.XrLabelStandardComment.StylePriority.UsePadding = False
            Me.XrLabelStandardComment.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0}"
            Me.XrLabelStandardComment.Summary = XrSummary10
            Me.XrLabelStandardComment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'IncludeClientPO
            '
            Me.IncludeClientPO.Name = "IncludeClientPO"
            Me.IncludeClientPO.Type = GetType(Boolean)
            Me.IncludeClientPO.ValueInfo = "False"
            Me.IncludeClientPO.Visible = False
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
            'GroupHeaderInvoiceData
            '
            Me.GroupHeaderInvoiceData.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreportInvoiceBodies})
            Me.GroupHeaderInvoiceData.Dpi = 100.0!
            Me.GroupHeaderInvoiceData.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderInvoiceData.HeightF = 117.7083!
            Me.GroupHeaderInvoiceData.Name = "GroupHeaderInvoiceData"
            '
            'XrSubreportInvoiceBodies
            '
            Me.XrSubreportInvoiceBodies.CanShrink = True
            Me.XrSubreportInvoiceBodies.Dpi = 100.0!
            Me.XrSubreportInvoiceBodies.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrSubreportInvoiceBodies.Name = "XrSubreportInvoiceBodies"
            Me.XrSubreportInvoiceBodies.SizeF = New System.Drawing.SizeF(750.0!, 115.0!)
            '
            'GroupFooterInvoiceData
            '
            Me.GroupFooterInvoiceData.Dpi = 100.0!
            Me.GroupFooterInvoiceData.HeightF = 0!
            Me.GroupFooterInvoiceData.Name = "GroupFooterInvoiceData"
            Me.GroupFooterInvoiceData.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail)
            '
            'Invoice
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeaderInvoice, Me.PageFooter, Me.GroupFooterInvoice, Me.GroupHeaderInvoiceData, Me.GroupFooterInvoiceData})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleInvoiceSalesClass, Me.FormattingRuleInvoiceClientPO, Me.FormattingRuleInvoiceDueDate})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.IncludeClientPO, Me.IncludeSalesClass, Me.IncludeInvoiceDueDate})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.XrTableReportHeader, System.ComponentModel.ISupportInitialize).EndInit()
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
		Friend WithEvents XrPageInfo As DevExpress.XtraReports.UI.XRPageInfo
		Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents XrLabelLocationFooterInfo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterInvoice As DevExpress.XtraReports.UI.GroupFooterBand
		Friend WithEvents XrLabelStandardComment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrLabelExchangeRateNote As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FormattingRuleInvoiceSalesClass As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleInvoiceDueDate As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleInvoiceClientPO As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents IncludeClientPO As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeSalesClass As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeInvoiceDueDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents GroupHeaderInvoiceData As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterInvoiceData As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrSubreportInvoiceBodies As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrPanelInvoiceTotal As DevExpress.XtraReports.UI.XRPanel
        Friend WithEvents XrLabelGrandTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotal As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents XrTableRowCampaign As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellCampaignLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellCampaign As DevExpress.XtraReports.UI.XRTableCell
    End Class

End Namespace
