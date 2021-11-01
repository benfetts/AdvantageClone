Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class AccountPayableRecurBatchReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetail_ForeignTotalInvoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ForeignInvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TotalInvoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTrans = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostingPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DiscountPercent = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Terms = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Office = New DevExpress.XtraReports.UI.XRLabel()
            Me.CheckBoxDetail_1099Invoice = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.LabelDetail_TermsLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OfficeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SalesTaxLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SalesTax = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateToPay = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Invoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Vendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_VendorLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_StatusLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateToPayLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TotalInvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostingPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTransLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DiscountPercentLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LineReportFooter_2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_BatchTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LabelReportFooter_BatchTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalInvoice = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DetailReportNonClient = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailNonClient = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailNonClient_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNonClient_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailNonClient_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderNonClient = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeaderNonClient_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNonClient_GLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderNonClient_GLDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderNonClient_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LineGroupHeaderNonClient_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupFooterNonClient = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterNonClient_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterNonClient_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceNonClient = New System.Windows.Forms.BindingSource(Me.components)
            Me.PrintComment = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSourceNonClient, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_ForeignTotalInvoice, Me.LabelDetail_ForeignInvoiceLabel, Me.LabelDetail_TotalInvoice, Me.LabelDetail_GLTrans, Me.LabelDetail_GLAccount, Me.LabelDetail_PostingPeriod, Me.LabelDetail_DiscountPercent, Me.LabelDetail_Terms, Me.LabelDetail_GLAccountLabel, Me.LabelDetail_Office, Me.CheckBoxDetail_1099Invoice, Me.LabelDetail_TermsLabel, Me.LabelDetail_OfficeLabel, Me.LabelDetail_Status, Me.LabelDetail_SalesTaxLabel, Me.LabelDetail_AmountLabel, Me.LabelDetail_SalesTax, Me.LabelDetail_Amount, Me.LabelDetail_DateToPay, Me.LabelDetail_Date, Me.LabelDetail_Invoice, Me.LabelDetail_Vendor, Me.LabelDetail_VendorLabel, Me.LabelDetail_InvoiceLabel, Me.LabelDetail_DateLabel, Me.LabelDetail_StatusLabel, Me.LabelDetail_DateToPayLabel, Me.LabelDetail_TotalInvoiceLabel, Me.LabelDetail_PostingPeriodLabel, Me.LabelDetail_GLTransLabel, Me.LabelDetail_DiscountPercentLabel})
            Me.Detail.HeightF = 161.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ForeignTotalInvoice
            '
            Me.LabelDetail_ForeignTotalInvoice.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ForeignTotalInvoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalInvoice", "{0:c2}")})
            Me.LabelDetail_ForeignTotalInvoice.LocationFloat = New DevExpress.Utils.PointFloat(295.875!, 138.0!)
            Me.LabelDetail_ForeignTotalInvoice.Name = "LabelDetail_ForeignTotalInvoice"
            Me.LabelDetail_ForeignTotalInvoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ForeignTotalInvoice.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_ForeignTotalInvoice.StylePriority.UseBorders = False
            Me.LabelDetail_ForeignTotalInvoice.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ForeignTotalInvoice.Text = "LabelDetail_TotalInvoice"
            Me.LabelDetail_ForeignTotalInvoice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_ForeignInvoiceLabel
            '
            Me.LabelDetail_ForeignInvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ForeignInvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ForeignInvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ForeignInvoiceLabel.BorderWidth = 1.0!
            Me.LabelDetail_ForeignInvoiceLabel.CanGrow = False
            Me.LabelDetail_ForeignInvoiceLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ForeignInvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ForeignInvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(214.6667!, 138.0!)
            Me.LabelDetail_ForeignInvoiceLabel.Name = "LabelDetail_ForeignInvoiceLabel"
            Me.LabelDetail_ForeignInvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ForeignInvoiceLabel.SizeF = New System.Drawing.SizeF(80.20831!, 19.0!)
            Me.LabelDetail_ForeignInvoiceLabel.StylePriority.UseFont = False
            Me.LabelDetail_ForeignInvoiceLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ForeignInvoiceLabel.Text = "Total Invoice:"
            Me.LabelDetail_ForeignInvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TotalInvoice
            '
            Me.LabelDetail_TotalInvoice.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelDetail_TotalInvoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalInvoice", "{0:c2}")})
            Me.LabelDetail_TotalInvoice.LocationFloat = New DevExpress.Utils.PointFloat(102.0832!, 138.0!)
            Me.LabelDetail_TotalInvoice.Name = "LabelDetail_TotalInvoice"
            Me.LabelDetail_TotalInvoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_TotalInvoice.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_TotalInvoice.StylePriority.UseBorders = False
            Me.LabelDetail_TotalInvoice.StylePriority.UseTextAlignment = False
            Me.LabelDetail_TotalInvoice.Text = "LabelDetail_TotalInvoice"
            Me.LabelDetail_TotalInvoice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLTrans
            '
            Me.LabelDetail_GLTrans.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.LabelDetail_GLTrans.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 138.0!)
            Me.LabelDetail_GLTrans.Name = "LabelDetail_GLTrans"
            Me.LabelDetail_GLTrans.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLTrans.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_GLTrans.Text = "LabelDetail_GLTrans"
            '
            'LabelDetail_GLAccount
            '
            Me.LabelDetail_GLAccount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAccount")})
            Me.LabelDetail_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(694.7916!, 92.00001!)
            Me.LabelDetail_GLAccount.Name = "LabelDetail_GLAccount"
            Me.LabelDetail_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLAccount.SizeF = New System.Drawing.SizeF(295.2083!, 22.99999!)
            Me.LabelDetail_GLAccount.Text = "LabelDetail_GLAccount"
            '
            'LabelDetail_PostingPeriod
            '
            Me.LabelDetail_PostingPeriod.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.LabelDetail_PostingPeriod.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 115.0!)
            Me.LabelDetail_PostingPeriod.Name = "LabelDetail_PostingPeriod"
            Me.LabelDetail_PostingPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_PostingPeriod.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_PostingPeriod.Text = "LabelDetail_PostingPeriod"
            '
            'LabelDetail_DiscountPercent
            '
            Me.LabelDetail_DiscountPercent.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DiscountPercent")})
            Me.LabelDetail_DiscountPercent.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 68.99999!)
            Me.LabelDetail_DiscountPercent.Name = "LabelDetail_DiscountPercent"
            Me.LabelDetail_DiscountPercent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DiscountPercent.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_DiscountPercent.Text = "LabelDetail_DiscountPercent"
            '
            'LabelDetail_Terms
            '
            Me.LabelDetail_Terms.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Terms")})
            Me.LabelDetail_Terms.LocationFloat = New DevExpress.Utils.PointFloat(694.7916!, 46.0!)
            Me.LabelDetail_Terms.Name = "LabelDetail_Terms"
            Me.LabelDetail_Terms.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Terms.SizeF = New System.Drawing.SizeF(295.2083!, 23.0!)
            Me.LabelDetail_Terms.Text = "LabelDetail_Terms"
            '
            'LabelDetail_GLAccountLabel
            '
            Me.LabelDetail_GLAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_GLAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_GLAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_GLAccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_GLAccountLabel.CanGrow = False
            Me.LabelDetail_GLAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_GLAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GLAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7917!, 91.99995!)
            Me.LabelDetail_GLAccountLabel.Name = "LabelDetail_GLAccountLabel"
            Me.LabelDetail_GLAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GLAccountLabel.SizeF = New System.Drawing.SizeF(88.54163!, 19.0!)
            Me.LabelDetail_GLAccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_GLAccountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLAccountLabel.Text = "GL Account:"
            Me.LabelDetail_GLAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Office
            '
            Me.LabelDetail_Office.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Office")})
            Me.LabelDetail_Office.LocationFloat = New DevExpress.Utils.PointFloat(694.7917!, 0!)
            Me.LabelDetail_Office.Name = "LabelDetail_Office"
            Me.LabelDetail_Office.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Office.SizeF = New System.Drawing.SizeF(295.2083!, 23.0!)
            Me.LabelDetail_Office.Text = "LabelDetail_Office"
            '
            'CheckBoxDetail_1099Invoice
            '
            Me.CheckBoxDetail_1099Invoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckBoxState", Nothing, "Is1099Flag")})
            Me.CheckBoxDetail_1099Invoice.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.CheckBoxDetail_1099Invoice.LocationFloat = New DevExpress.Utils.PointFloat(594.7919!, 22.99999!)
            Me.CheckBoxDetail_1099Invoice.Name = "CheckBoxDetail_1099Invoice"
            Me.CheckBoxDetail_1099Invoice.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.CheckBoxDetail_1099Invoice.StylePriority.UseFont = False
            Me.CheckBoxDetail_1099Invoice.StylePriority.UseTextAlignment = False
            Me.CheckBoxDetail_1099Invoice.Text = "1099 Invoice"
            '
            'LabelDetail_TermsLabel
            '
            Me.LabelDetail_TermsLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TermsLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TermsLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TermsLabel.BorderWidth = 1.0!
            Me.LabelDetail_TermsLabel.CanGrow = False
            Me.LabelDetail_TermsLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TermsLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TermsLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7917!, 45.99997!)
            Me.LabelDetail_TermsLabel.Name = "LabelDetail_TermsLabel"
            Me.LabelDetail_TermsLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TermsLabel.SizeF = New System.Drawing.SizeF(88.54156!, 19.0!)
            Me.LabelDetail_TermsLabel.StylePriority.UseFont = False
            Me.LabelDetail_TermsLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_TermsLabel.Text = "Terms:"
            Me.LabelDetail_TermsLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_OfficeLabel
            '
            Me.LabelDetail_OfficeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_OfficeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_OfficeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_OfficeLabel.BorderWidth = 1.0!
            Me.LabelDetail_OfficeLabel.CanGrow = False
            Me.LabelDetail_OfficeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_OfficeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_OfficeLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7918!, 0!)
            Me.LabelDetail_OfficeLabel.Name = "LabelDetail_OfficeLabel"
            Me.LabelDetail_OfficeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OfficeLabel.SizeF = New System.Drawing.SizeF(88.54156!, 19.0!)
            Me.LabelDetail_OfficeLabel.StylePriority.UseFont = False
            Me.LabelDetail_OfficeLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_OfficeLabel.Text = "Office:"
            Me.LabelDetail_OfficeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Status
            '
            Me.LabelDetail_Status.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Status")})
            Me.LabelDetail_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_Status.LocationFloat = New DevExpress.Utils.PointFloat(416.6667!, 22.99999!)
            Me.LabelDetail_Status.Name = "LabelDetail_Status"
            Me.LabelDetail_Status.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Status.SizeF = New System.Drawing.SizeF(173.7514!, 23.0!)
            Me.LabelDetail_Status.StylePriority.UseFont = False
            Me.LabelDetail_Status.Text = "LabelDetail_Status"
            '
            'LabelDetail_SalesTaxLabel
            '
            Me.LabelDetail_SalesTaxLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_SalesTaxLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_SalesTaxLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_SalesTaxLabel.BorderWidth = 1.0!
            Me.LabelDetail_SalesTaxLabel.CanGrow = False
            Me.LabelDetail_SalesTaxLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_SalesTaxLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_SalesTaxLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 115.0!)
            Me.LabelDetail_SalesTaxLabel.Name = "LabelDetail_SalesTaxLabel"
            Me.LabelDetail_SalesTaxLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_SalesTaxLabel.SizeF = New System.Drawing.SizeF(67.70999!, 19.0!)
            Me.LabelDetail_SalesTaxLabel.StylePriority.UseFont = False
            Me.LabelDetail_SalesTaxLabel.Text = "Sales Tax:"
            Me.LabelDetail_SalesTaxLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_AmountLabel
            '
            Me.LabelDetail_AmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_AmountLabel.CanGrow = False
            Me.LabelDetail_AmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 91.99995!)
            Me.LabelDetail_AmountLabel.Name = "LabelDetail_AmountLabel"
            Me.LabelDetail_AmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AmountLabel.SizeF = New System.Drawing.SizeF(67.70999!, 19.0!)
            Me.LabelDetail_AmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AmountLabel.Text = "Amount:"
            Me.LabelDetail_AmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_SalesTax
            '
            Me.LabelDetail_SalesTax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumSalesTax", "{0:c2}")})
            Me.LabelDetail_SalesTax.LocationFloat = New DevExpress.Utils.PointFloat(102.0832!, 115.0!)
            Me.LabelDetail_SalesTax.Name = "LabelDetail_SalesTax"
            Me.LabelDetail_SalesTax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_SalesTax.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_SalesTax.StylePriority.UseTextAlignment = False
            Me.LabelDetail_SalesTax.Text = "LabelDetail_SalesTax"
            Me.LabelDetail_SalesTax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Amount
            '
            Me.LabelDetail_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SumAmount", "{0:c2}")})
            Me.LabelDetail_Amount.LocationFloat = New DevExpress.Utils.PointFloat(102.0833!, 91.99995!)
            Me.LabelDetail_Amount.Name = "LabelDetail_Amount"
            Me.LabelDetail_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Amount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Amount.Text = "LabelDetail_Amount"
            Me.LabelDetail_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_DateToPay
            '
            Me.LabelDetail_DateToPay.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateToPay", "{0:d}")})
            Me.LabelDetail_DateToPay.LocationFloat = New DevExpress.Utils.PointFloat(102.0833!, 68.99995!)
            Me.LabelDetail_DateToPay.Name = "LabelDetail_DateToPay"
            Me.LabelDetail_DateToPay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DateToPay.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            '
            'LabelDetail_Date
            '
            Me.LabelDetail_Date.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelDetail_Date.LocationFloat = New DevExpress.Utils.PointFloat(102.0833!, 45.99997!)
            Me.LabelDetail_Date.Name = "LabelDetail_Date"
            Me.LabelDetail_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Date.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            '
            'LabelDetail_Invoice
            '
            Me.LabelDetail_Invoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Invoice")})
            Me.LabelDetail_Invoice.LocationFloat = New DevExpress.Utils.PointFloat(102.0833!, 22.99999!)
            Me.LabelDetail_Invoice.Name = "LabelDetail_Invoice"
            Me.LabelDetail_Invoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Invoice.SizeF = New System.Drawing.SizeF(261.4583!, 23.0!)
            Me.LabelDetail_Invoice.Text = "LabelDetail_Invoice"
            '
            'LabelDetail_Vendor
            '
            Me.LabelDetail_Vendor.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Vendor")})
            Me.LabelDetail_Vendor.LocationFloat = New DevExpress.Utils.PointFloat(102.0832!, 0!)
            Me.LabelDetail_Vendor.Name = "LabelDetail_Vendor"
            Me.LabelDetail_Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Vendor.SizeF = New System.Drawing.SizeF(388.5417!, 23.0!)
            Me.LabelDetail_Vendor.Text = "LabelDetail_Vendor"
            '
            'LabelDetail_VendorLabel
            '
            Me.LabelDetail_VendorLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_VendorLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_VendorLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_VendorLabel.BorderWidth = 1.0!
            Me.LabelDetail_VendorLabel.CanGrow = False
            Me.LabelDetail_VendorLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_VendorLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_VendorLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_VendorLabel.Name = "LabelDetail_VendorLabel"
            Me.LabelDetail_VendorLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_VendorLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_VendorLabel.StylePriority.UseFont = False
            Me.LabelDetail_VendorLabel.Text = "Vendor:"
            Me.LabelDetail_VendorLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceLabel
            '
            Me.LabelDetail_InvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InvoiceLabel.BorderWidth = 1.0!
            Me.LabelDetail_InvoiceLabel.CanGrow = False
            Me.LabelDetail_InvoiceLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_InvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 22.99999!)
            Me.LabelDetail_InvoiceLabel.Name = "LabelDetail_InvoiceLabel"
            Me.LabelDetail_InvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_InvoiceLabel.StylePriority.UseFont = False
            Me.LabelDetail_InvoiceLabel.Text = "Invoice:"
            Me.LabelDetail_InvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DateLabel
            '
            Me.LabelDetail_DateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateLabel.BorderWidth = 1.0!
            Me.LabelDetail_DateLabel.CanGrow = False
            Me.LabelDetail_DateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 45.99997!)
            Me.LabelDetail_DateLabel.Name = "LabelDetail_DateLabel"
            Me.LabelDetail_DateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateLabel.SizeF = New System.Drawing.SizeF(61.45837!, 19.0!)
            Me.LabelDetail_DateLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateLabel.Text = "Date:"
            Me.LabelDetail_DateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_StatusLabel
            '
            Me.LabelDetail_StatusLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_StatusLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_StatusLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_StatusLabel.BorderWidth = 1.0!
            Me.LabelDetail_StatusLabel.CanGrow = False
            Me.LabelDetail_StatusLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_StatusLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_StatusLabel.LocationFloat = New DevExpress.Utils.PointFloat(363.5417!, 22.99999!)
            Me.LabelDetail_StatusLabel.Name = "LabelDetail_StatusLabel"
            Me.LabelDetail_StatusLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_StatusLabel.SizeF = New System.Drawing.SizeF(53.12503!, 19.0!)
            Me.LabelDetail_StatusLabel.StylePriority.UseFont = False
            Me.LabelDetail_StatusLabel.Text = "Status:"
            Me.LabelDetail_StatusLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DateToPayLabel
            '
            Me.LabelDetail_DateToPayLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateToPayLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateToPayLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateToPayLabel.BorderWidth = 1.0!
            Me.LabelDetail_DateToPayLabel.CanGrow = False
            Me.LabelDetail_DateToPayLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DateToPayLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateToPayLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 68.99995!)
            Me.LabelDetail_DateToPayLabel.Name = "LabelDetail_DateToPayLabel"
            Me.LabelDetail_DateToPayLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateToPayLabel.SizeF = New System.Drawing.SizeF(67.70999!, 19.0!)
            Me.LabelDetail_DateToPayLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateToPayLabel.Text = "Date to Pay:"
            Me.LabelDetail_DateToPayLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TotalInvoiceLabel
            '
            Me.LabelDetail_TotalInvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TotalInvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TotalInvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TotalInvoiceLabel.BorderWidth = 1.0!
            Me.LabelDetail_TotalInvoiceLabel.CanGrow = False
            Me.LabelDetail_TotalInvoiceLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TotalInvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TotalInvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 138.0!)
            Me.LabelDetail_TotalInvoiceLabel.Name = "LabelDetail_TotalInvoiceLabel"
            Me.LabelDetail_TotalInvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TotalInvoiceLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_TotalInvoiceLabel.StylePriority.UseFont = False
            Me.LabelDetail_TotalInvoiceLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_TotalInvoiceLabel.Text = "Total Invoice:"
            Me.LabelDetail_TotalInvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_PostingPeriodLabel
            '
            Me.LabelDetail_PostingPeriodLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_PostingPeriodLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_PostingPeriodLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_PostingPeriodLabel.BorderWidth = 1.0!
            Me.LabelDetail_PostingPeriodLabel.CanGrow = False
            Me.LabelDetail_PostingPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_PostingPeriodLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_PostingPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7917!, 115.0!)
            Me.LabelDetail_PostingPeriodLabel.Name = "LabelDetail_PostingPeriodLabel"
            Me.LabelDetail_PostingPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PostingPeriodLabel.SizeF = New System.Drawing.SizeF(88.54163!, 19.0!)
            Me.LabelDetail_PostingPeriodLabel.StylePriority.UseFont = False
            Me.LabelDetail_PostingPeriodLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_PostingPeriodLabel.Text = "Posting Period:"
            Me.LabelDetail_PostingPeriodLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_GLTransLabel
            '
            Me.LabelDetail_GLTransLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_GLTransLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_GLTransLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_GLTransLabel.BorderWidth = 1.0!
            Me.LabelDetail_GLTransLabel.CanGrow = False
            Me.LabelDetail_GLTransLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_GLTransLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GLTransLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7919!, 138.0!)
            Me.LabelDetail_GLTransLabel.Name = "LabelDetail_GLTransLabel"
            Me.LabelDetail_GLTransLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GLTransLabel.SizeF = New System.Drawing.SizeF(88.54138!, 19.0!)
            Me.LabelDetail_GLTransLabel.StylePriority.UseFont = False
            Me.LabelDetail_GLTransLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLTransLabel.Text = "GL Trans:"
            Me.LabelDetail_GLTransLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DiscountPercentLabel
            '
            Me.LabelDetail_DiscountPercentLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DiscountPercentLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DiscountPercentLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DiscountPercentLabel.BorderWidth = 1.0!
            Me.LabelDetail_DiscountPercentLabel.CanGrow = False
            Me.LabelDetail_DiscountPercentLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DiscountPercentLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DiscountPercentLabel.LocationFloat = New DevExpress.Utils.PointFloat(594.7917!, 68.99995!)
            Me.LabelDetail_DiscountPercentLabel.Name = "LabelDetail_DiscountPercentLabel"
            Me.LabelDetail_DiscountPercentLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DiscountPercentLabel.SizeF = New System.Drawing.SizeF(88.54156!, 19.0!)
            Me.LabelDetail_DiscountPercentLabel.StylePriority.UseFont = False
            Me.LabelDetail_DiscountPercentLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_DiscountPercentLabel.Text = "Discount %:"
            Me.LabelDetail_DiscountPercentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineReportFooter_1
            '
            Me.LineReportFooter_1.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_1.BorderWidth = 0!
            Me.LineReportFooter_1.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 2.0!)
            Me.LineReportFooter_1.Name = "LineReportFooter_1"
            Me.LineReportFooter_1.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineReportFooter_1.StylePriority.UseBorderColor = False
            Me.LineReportFooter_1.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_1.StylePriority.UseForeColor = False
            '
            'LineReportFooter_2
            '
            Me.LineReportFooter_2.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_2.BorderWidth = 0!
            Me.LineReportFooter_2.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineReportFooter_2.Name = "LineReportFooter_2"
            Me.LineReportFooter_2.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineReportFooter_2.StylePriority.UseBorderColor = False
            Me.LineReportFooter_2.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_2.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_BatchTotalLabel
            '
            Me.LabelReportFooter_BatchTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_BatchTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_BatchTotalLabel.BorderWidth = 1.0!
            Me.LabelReportFooter_BatchTotalLabel.CanGrow = False
            Me.LabelReportFooter_BatchTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelReportFooter_BatchTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(523.8331!, 9.999974!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(115.62!, 19.0!)
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotalLabel.Text = "Batch Total:"
            Me.LabelReportFooter_BatchTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 48.95833!
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LinePageHeader_Bottom, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle})
            Me.PageHeader.HeightF = 54.16672!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1.0!
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(512.4999!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(486.5002!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.Text = "Accounts Payable Batch Report - Detail"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4.0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4.0!
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 50.08337!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4.0!
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4.0!
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageHeader_Top.Name = "LinePageHeader_Top"
            Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageHeader_ReportCriteria
            '
            Me.LabelPageHeader_ReportCriteria.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportCriteria.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportCriteria.BorderWidth = 1.0!
            Me.LabelPageHeader_ReportCriteria.CanGrow = False
            Me.LabelPageHeader_ReportCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportCriteria.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 33.08335!)
            Me.LabelPageHeader_ReportCriteria.Name = "LabelPageHeader_ReportCriteria"
            Me.LabelPageHeader_ReportCriteria.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportCriteria.SizeF = New System.Drawing.SizeF(501.0417!, 17.00001!)
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportCriteria.Text = "For:"
            Me.LabelPageHeader_ReportCriteria.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_ReportTitle
            '
            Me.LabelPageHeader_ReportTitle.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportTitle.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportTitle.BorderWidth = 1.0!
            Me.LabelPageHeader_ReportTitle.CanGrow = False
            Me.LabelPageHeader_ReportTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportTitle.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.083347!)
            Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
            Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "Accounts Payable Recur Batch Report"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_BatchTotal, Me.LineReportFooter_2, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_1})
            Me.ReportFooter.HeightF = 36.37498!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_BatchTotal
            '
            Me.LabelReportFooter_BatchTotal.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_BatchTotal.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_BatchTotal.BorderWidth = 1.0!
            Me.LabelReportFooter_BatchTotal.CanGrow = False
            Me.LabelReportFooter_BatchTotal.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelReportFooter_BatchTotal.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotal.LocationFloat = New DevExpress.Utils.PointFloat(643.5416!, 9.999974!)
            Me.LabelReportFooter_BatchTotal.Name = "LabelReportFooter_BatchTotal"
            Me.LabelReportFooter_BatchTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotal.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelReportFooter_BatchTotal.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotal.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TotalInvoice
            '
            Me.TotalInvoice.Expression = "[SumAmount] + [SumSalesTax] + [SumShipping]"
            Me.TotalInvoice.Name = "TotalInvoice"
            '
            'DetailReportNonClient
            '
            Me.DetailReportNonClient.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailNonClient, Me.GroupHeaderNonClient, Me.GroupFooterNonClient})
            Me.DetailReportNonClient.DataSource = Me.BindingSourceNonClient
            Me.DetailReportNonClient.Level = 0
            Me.DetailReportNonClient.Name = "DetailReportNonClient"
            '
            'DetailNonClient
            '
            Me.DetailNonClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailNonClient_Amount, Me.LabelDetailNonClient_GLDescription, Me.LabelDetailNonClient_GLACode})
            Me.DetailNonClient.HeightF = 23.0!
            Me.DetailNonClient.Name = "DetailNonClient"
            '
            'LabelDetailNonClient_Amount
            '
            Me.LabelDetailNonClient_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:#,#.00}")})
            Me.LabelDetailNonClient_Amount.LocationFloat = New DevExpress.Utils.PointFloat(643.5416!, 0!)
            Me.LabelDetailNonClient_Amount.Name = "LabelDetailNonClient_Amount"
            Me.LabelDetailNonClient_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNonClient_Amount.SizeF = New System.Drawing.SizeF(99.99997!, 23.0!)
            Me.LabelDetailNonClient_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetailNonClient_Amount.Text = "LabelDetailNonClient_Amount"
            Me.LabelDetailNonClient_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailNonClient_GLDescription
            '
            Me.LabelDetailNonClient_GLDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerAccount.Description")})
            Me.LabelDetailNonClient_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(316.6667!, 0!)
            Me.LabelDetailNonClient_GLDescription.Name = "LabelDetailNonClient_GLDescription"
            Me.LabelDetailNonClient_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNonClient_GLDescription.SizeF = New System.Drawing.SizeF(232.5!, 23.0!)
            Me.LabelDetailNonClient_GLDescription.Text = "LabelDetailNonClient_GLDescription"
            '
            'LabelDetailNonClient_GLACode
            '
            Me.LabelDetailNonClient_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailNonClient_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(206.6667!, 0!)
            Me.LabelDetailNonClient_GLACode.Name = "LabelDetailNonClient_GLACode"
            Me.LabelDetailNonClient_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailNonClient_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetailNonClient_GLACode.Text = "XrLabel4"
            '
            'GroupHeaderNonClient
            '
            Me.GroupHeaderNonClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderNonClient_Amount, Me.LabelGroupHeaderNonClient_GLAccount, Me.LabelGroupHeaderNonClient_GLDescription, Me.LineGroupHeaderNonClient_Top, Me.LineGroupHeaderNonClient_Bottom})
            Me.GroupHeaderNonClient.HeightF = 44.0!
            Me.GroupHeaderNonClient.Name = "GroupHeaderNonClient"
            '
            'LabelGroupHeaderNonClient_Amount
            '
            Me.LabelGroupHeaderNonClient_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_Amount.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_Amount.CanGrow = False
            Me.LabelGroupHeaderNonClient_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNonClient_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_Amount.LocationFloat = New DevExpress.Utils.PointFloat(666.4567!, 4.000028!)
            Me.LabelGroupHeaderNonClient_Amount.Name = "LabelGroupHeaderNonClient_Amount"
            Me.LabelGroupHeaderNonClient_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_Amount.SizeF = New System.Drawing.SizeF(77.08499!, 19.0!)
            Me.LabelGroupHeaderNonClient_Amount.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_Amount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderNonClient_Amount.Text = "Amount"
            Me.LabelGroupHeaderNonClient_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderNonClient_GLAccount
            '
            Me.LabelGroupHeaderNonClient_GLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_GLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_GLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_GLAccount.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_GLAccount.CanGrow = False
            Me.LabelGroupHeaderNonClient_GLAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNonClient_GLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_GLAccount.LocationFloat = New DevExpress.Utils.PointFloat(206.6667!, 3.999996!)
            Me.LabelGroupHeaderNonClient_GLAccount.Name = "LabelGroupHeaderNonClient_GLAccount"
            Me.LabelGroupHeaderNonClient_GLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_GLAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderNonClient_GLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_GLAccount.Text = "GL Account"
            Me.LabelGroupHeaderNonClient_GLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderNonClient_GLDescription
            '
            Me.LabelGroupHeaderNonClient_GLDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderNonClient_GLDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_GLDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderNonClient_GLDescription.BorderWidth = 1.0!
            Me.LabelGroupHeaderNonClient_GLDescription.CanGrow = False
            Me.LabelGroupHeaderNonClient_GLDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderNonClient_GLDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderNonClient_GLDescription.LocationFloat = New DevExpress.Utils.PointFloat(316.6667!, 3.999996!)
            Me.LabelGroupHeaderNonClient_GLDescription.Name = "LabelGroupHeaderNonClient_GLDescription"
            Me.LabelGroupHeaderNonClient_GLDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderNonClient_GLDescription.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderNonClient_GLDescription.StylePriority.UseFont = False
            Me.LabelGroupHeaderNonClient_GLDescription.Text = "Description"
            Me.LabelGroupHeaderNonClient_GLDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupHeaderNonClient_Top
            '
            Me.LineGroupHeaderNonClient_Top.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderNonClient_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderNonClient_Top.BorderWidth = 0!
            Me.LineGroupHeaderNonClient_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderNonClient_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineGroupHeaderNonClient_Top.Name = "LineGroupHeaderNonClient_Top"
            Me.LineGroupHeaderNonClient_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineGroupHeaderNonClient_Top.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderNonClient_Top.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderNonClient_Top.StylePriority.UseForeColor = False
            '
            'LineGroupHeaderNonClient_Bottom
            '
            Me.LineGroupHeaderNonClient_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderNonClient_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderNonClient_Bottom.BorderWidth = 0!
            Me.LineGroupHeaderNonClient_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupHeaderNonClient_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 23.0!)
            Me.LineGroupHeaderNonClient_Bottom.Name = "LineGroupHeaderNonClient_Bottom"
            Me.LineGroupHeaderNonClient_Bottom.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineGroupHeaderNonClient_Bottom.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderNonClient_Bottom.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderNonClient_Bottom.StylePriority.UseForeColor = False
            '
            'GroupFooterNonClient
            '
            Me.GroupFooterNonClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterNonClient_DisbursedAmount, Me.LabelGroupFooterNonClient_Total})
            Me.GroupFooterNonClient.HeightF = 23.0!
            Me.GroupFooterNonClient.Name = "GroupFooterNonClient"
            '
            'LabelGroupFooterNonClient_DisbursedAmount
            '
            Me.LabelGroupFooterNonClient_DisbursedAmount.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooterNonClient_DisbursedAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:c2}")})
            Me.LabelGroupFooterNonClient_DisbursedAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic)
            Me.LabelGroupFooterNonClient_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(643.5416!, 0!)
            Me.LabelGroupFooterNonClient_DisbursedAmount.Name = "LabelGroupFooterNonClient_DisbursedAmount"
            Me.LabelGroupFooterNonClient_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterNonClient_DisbursedAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelGroupFooterNonClient_DisbursedAmount.StylePriority.UseBorders = False
            Me.LabelGroupFooterNonClient_DisbursedAmount.StylePriority.UseFont = False
            Me.LabelGroupFooterNonClient_DisbursedAmount.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:$0.00}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterNonClient_DisbursedAmount.Summary = XrSummary1
            Me.LabelGroupFooterNonClient_DisbursedAmount.Text = "LabelGroupFooterNonClient_DisbursedAmount"
            Me.LabelGroupFooterNonClient_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterNonClient_Total
            '
            Me.LabelGroupFooterNonClient_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterNonClient_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterNonClient_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterNonClient_Total.BorderWidth = 1.0!
            Me.LabelGroupFooterNonClient_Total.CanGrow = False
            Me.LabelGroupFooterNonClient_Total.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelGroupFooterNonClient_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterNonClient_Total.LocationFloat = New DevExpress.Utils.PointFloat(523.8332!, 0!)
            Me.LabelGroupFooterNonClient_Total.Name = "LabelGroupFooterNonClient_Total"
            Me.LabelGroupFooterNonClient_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterNonClient_Total.SizeF = New System.Drawing.SizeF(115.6199!, 19.0!)
            Me.LabelGroupFooterNonClient_Total.StylePriority.UseFont = False
            Me.LabelGroupFooterNonClient_Total.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterNonClient_Total.Text = "Invoice Total:"
            Me.LabelGroupFooterNonClient_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceNonClient
            '
            Me.BindingSourceNonClient.DataSource = GetType(AdvantageFramework.Database.Entities.AccountPayableGLDistribution)
            '
            'PrintComment
            '
            Me.PrintComment.DataSource = Me.BindingSourceNonClient
            Me.PrintComment.Expression = "Iif(IsNullOrEmpty([Comment]), '', 'Comment: ' + [Comment])"
            Me.PrintComment.Name = "PrintComment"
            '
            'GroupHeader
            '
            Me.GroupHeader.Expanded = False
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLTransaction", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 0!
            Me.GroupHeader.Name = "GroupHeader"
            Me.GroupHeader.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport)
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 4.083347!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.PageInfo_Pages.TextFormatString = "Page {0} of {1}"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LinePageFooter, Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 25.08332!
            Me.PageFooter.Name = "PageFooter"
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4.0!
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4.0!
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageFooter_UserCode
            '
            Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_UserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_UserCode.CanGrow = False
            Me.LabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_UserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 4.083347!)
            Me.LabelPageFooter_UserCode.Name = "LabelPageFooter_UserCode"
            Me.LabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_UserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_UserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_UserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageFooter_Date
            '
            Me.LabelPageFooter_Date.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_Date.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_Date.BorderWidth = 1.0!
            Me.LabelPageFooter_Date.CanGrow = False
            Me.LabelPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 4.083379!)
            Me.LabelPageFooter_Date.Name = "LabelPageFooter_Date"
            Me.LabelPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_Date.SizeF = New System.Drawing.SizeF(234.9999!, 19.0!)
            Me.LabelPageFooter_Date.StylePriority.UseFont = False
            Me.LabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'AccountPayableRecurBatchReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.DetailReportNonClient, Me.GroupHeader, Me.PageFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.TotalInvoice, Me.PrintComment})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(49, 51, 49, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSourceNonClient, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_VendorLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_DateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_InvoiceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DateToPayLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GLTransLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_PostingPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_TotalInvoiceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_StatusLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DiscountPercentLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents LabelDetail_DateToPay As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Date As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Invoice As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Vendor As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Status As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_SalesTaxLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AmountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_SalesTax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Amount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLTrans As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PostingPeriod As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DiscountPercent As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Terms As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GLAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Office As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CheckBoxDetail_1099Invoice As DevExpress.XtraReports.UI.XRCheckBox
        Private WithEvents LabelDetail_TermsLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_OfficeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_TotalInvoice As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TotalInvoice As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents LabelReportFooter_BatchTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineReportFooter_1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents DetailReportNonClient As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailNonClient As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents BindingSourceNonClient As System.Windows.Forms.BindingSource
        Friend WithEvents GroupHeaderNonClient As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeaderNonClient_GLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNonClient_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderNonClient_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineGroupHeaderNonClient_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetailNonClient_GLDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNonClient_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailNonClient_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderNonClient_Amount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PrintComment As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents GroupFooterNonClient As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelGroupFooterNonClient_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterNonClient_Total As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_BatchTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ForeignTotalInvoice As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ForeignInvoiceLabel As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
