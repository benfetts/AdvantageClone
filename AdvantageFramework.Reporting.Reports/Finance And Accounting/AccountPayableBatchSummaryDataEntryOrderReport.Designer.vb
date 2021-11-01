Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class AccountPayableBatchSummaryDataEntryOrderReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetail_CurrencyCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ForeignAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Disbursed = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTransaction = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateToPay = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Invoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Vendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_GLTransaction = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_PostPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_DateToPay = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Middle = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Invoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Vendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrPageInfo = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.LabelPageFooter_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LineReportFooter_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_SumDisbursed = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_BatchTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.Disbursed = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_CurrencyCode, Me.LabelDetail_ForeignAmount, Me.LabelDetail_GLACode, Me.LabelDetail_Disbursed, Me.LabelDetail_Status, Me.LabelDetail_GLTransaction, Me.LabelDetail_PostPeriod, Me.LabelDetail_DateToPay, Me.LabelDetail_InvoiceDate, Me.LabelDetail_Invoice, Me.LabelDetail_Vendor})
            Me.Detail.HeightF = 45.99998!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("AccountPayableID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CurrencyCode
            '
            Me.LabelDetail_CurrencyCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CurrencyCode.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CurrencyCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CurrencyCode.BorderWidth = 1.0!
            Me.LabelDetail_CurrencyCode.CanGrow = False
            Me.LabelDetail_CurrencyCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelDetail_CurrencyCode.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CurrencyCode.LocationFloat = New DevExpress.Utils.PointFloat(800.0001!, 22.99999!)
            Me.LabelDetail_CurrencyCode.Name = "LabelDetail_CurrencyCode"
            Me.LabelDetail_CurrencyCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CurrencyCode.SizeF = New System.Drawing.SizeF(99.99995!, 19.0!)
            Me.LabelDetail_CurrencyCode.StylePriority.UseBorders = False
            Me.LabelDetail_CurrencyCode.StylePriority.UseFont = False
            Me.LabelDetail_CurrencyCode.StylePriority.UseTextAlignment = False
            Me.LabelDetail_CurrencyCode.Text = "Batch Total:"
            Me.LabelDetail_CurrencyCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_ForeignAmount
            '
            Me.LabelDetail_ForeignAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ForeignCurrencyTotal", "{0:$0.00}")})
            Me.LabelDetail_ForeignAmount.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 22.99999!)
            Me.LabelDetail_ForeignAmount.Name = "LabelDetail_ForeignAmount"
            Me.LabelDetail_ForeignAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ForeignAmount.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_ForeignAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ForeignAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLACode
            '
            Me.LabelDetail_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetail_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(815.6251!, 0!)
            Me.LabelDetail_GLACode.Name = "LabelDetail_GLACode"
            Me.LabelDetail_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLACode.SizeF = New System.Drawing.SizeF(82.29181!, 23.0!)
            Me.LabelDetail_GLACode.Text = "LabelDetail_GLACode"
            '
            'LabelDetail_Disbursed
            '
            Me.LabelDetail_Disbursed.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Disbursed", "{0:$0.00}")})
            Me.LabelDetail_Disbursed.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 0!)
            Me.LabelDetail_Disbursed.Name = "LabelDetail_Disbursed"
            Me.LabelDetail_Disbursed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Disbursed.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelDetail_Disbursed.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Disbursed.Text = "LabelDetail_Disbursed"
            Me.LabelDetail_Disbursed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Status
            '
            Me.LabelDetail_Status.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Status")})
            Me.LabelDetail_Status.LocationFloat = New DevExpress.Utils.PointFloat(751.0417!, 0!)
            Me.LabelDetail_Status.Name = "LabelDetail_Status"
            Me.LabelDetail_Status.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Status.SizeF = New System.Drawing.SizeF(64.58331!, 23.0!)
            Me.LabelDetail_Status.Text = "LabelDetail_Status"
            '
            'LabelDetail_GLTransaction
            '
            Me.LabelDetail_GLTransaction.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.LabelDetail_GLTransaction.LocationFloat = New DevExpress.Utils.PointFloat(672.9167!, 0!)
            Me.LabelDetail_GLTransaction.Name = "LabelDetail_GLTransaction"
            Me.LabelDetail_GLTransaction.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLTransaction.SizeF = New System.Drawing.SizeF(78.12494!, 23.0!)
            Me.LabelDetail_GLTransaction.Text = "LabelDetail_GLTransaction"
            '
            'LabelDetail_PostPeriod
            '
            Me.LabelDetail_PostPeriod.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.LabelDetail_PostPeriod.LocationFloat = New DevExpress.Utils.PointFloat(605.0015!, 0!)
            Me.LabelDetail_PostPeriod.Name = "LabelDetail_PostPeriod"
            Me.LabelDetail_PostPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_PostPeriod.SizeF = New System.Drawing.SizeF(66.6665!, 23.0!)
            Me.LabelDetail_PostPeriod.Text = "LabelDetail_PostPeriod"
            '
            'LabelDetail_DateToPay
            '
            Me.LabelDetail_DateToPay.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateToPay", "{0:d}")})
            Me.LabelDetail_DateToPay.LocationFloat = New DevExpress.Utils.PointFloat(533.2914!, 0!)
            Me.LabelDetail_DateToPay.Name = "LabelDetail_DateToPay"
            Me.LabelDetail_DateToPay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DateToPay.SizeF = New System.Drawing.SizeF(67.70996!, 23.0!)
            '
            'LabelDetail_InvoiceDate
            '
            Me.LabelDetail_InvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelDetail_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(467.458!, 0!)
            Me.LabelDetail_InvoiceDate.Name = "LabelDetail_InvoiceDate"
            Me.LabelDetail_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceDate.SizeF = New System.Drawing.SizeF(61.45834!, 23.0!)
            '
            'LabelDetail_Invoice
            '
            Me.LabelDetail_Invoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Invoice")})
            Me.LabelDetail_Invoice.LocationFloat = New DevExpress.Utils.PointFloat(237.5!, 0!)
            Me.LabelDetail_Invoice.Name = "LabelDetail_Invoice"
            Me.LabelDetail_Invoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Invoice.SizeF = New System.Drawing.SizeF(227.0833!, 23.0!)
            Me.LabelDetail_Invoice.Text = "LabelDetail_Invoice"
            '
            'LabelDetail_Vendor
            '
            Me.LabelDetail_Vendor.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Vendor")})
            Me.LabelDetail_Vendor.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_Vendor.Name = "LabelDetail_Vendor"
            Me.LabelDetail_Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Vendor.SizeF = New System.Drawing.SizeF(235.4167!, 23.0!)
            Me.LabelDetail_Vendor.Text = "LabelDetail_Vendor"
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_Total, Me.LabelPageHeader_GLACode, Me.LabelPageHeader_GLTransaction, Me.LabelPageHeader_PostPeriod, Me.LabelPageHeader_DateToPay, Me.LabelPageHeader_InvoiceDate, Me.LinePageHeader_Middle, Me.LabelPageHeader_Invoice, Me.LinePageHeader_Bottom, Me.LabelPageHeader_Vendor, Me.LabelPageHeader_Title, Me.LabelPageHeader_Status})
            Me.PageHeader.HeightF = 87.5834!
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(512.4998!, 33.1!)
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
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4.0!
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
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
            Me.LabelPageHeader_ReportCriteria.LocationFloat = New DevExpress.Utils.PointFloat(0.00007152557!, 33.08334!)
            Me.LabelPageHeader_ReportCriteria.Name = "LabelPageHeader_ReportCriteria"
            Me.LabelPageHeader_ReportCriteria.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportCriteria.SizeF = New System.Drawing.SizeF(501.0417!, 17.00001!)
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportCriteria.Text = "For:"
            Me.LabelPageHeader_ReportCriteria.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Total
            '
            Me.LabelPageHeader_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Total.BorderWidth = 1.0!
            Me.LabelPageHeader_Total.CanGrow = False
            Me.LabelPageHeader_Total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Total.LocationFloat = New DevExpress.Utils.PointFloat(899.0001!, 64.5834!)
            Me.LabelPageHeader_Total.Name = "LabelPageHeader_Total"
            Me.LabelPageHeader_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Total.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelPageHeader_Total.StylePriority.UseFont = False
            Me.LabelPageHeader_Total.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Total.Text = "Total"
            Me.LabelPageHeader_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_GLACode
            '
            Me.LabelPageHeader_GLACode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_GLACode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_GLACode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_GLACode.BorderWidth = 1.0!
            Me.LabelPageHeader_GLACode.CanGrow = False
            Me.LabelPageHeader_GLACode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_GLACode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(814.6252!, 64.58334!)
            Me.LabelPageHeader_GLACode.Name = "LabelPageHeader_GLACode"
            Me.LabelPageHeader_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_GLACode.SizeF = New System.Drawing.SizeF(82.29175!, 19.0!)
            Me.LabelPageHeader_GLACode.StylePriority.UseFont = False
            Me.LabelPageHeader_GLACode.Text = "AP Account"
            Me.LabelPageHeader_GLACode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_GLTransaction
            '
            Me.LabelPageHeader_GLTransaction.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_GLTransaction.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_GLTransaction.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_GLTransaction.BorderWidth = 1.0!
            Me.LabelPageHeader_GLTransaction.CanGrow = False
            Me.LabelPageHeader_GLTransaction.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_GLTransaction.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_GLTransaction.LocationFloat = New DevExpress.Utils.PointFloat(671.9167!, 64.58334!)
            Me.LabelPageHeader_GLTransaction.Name = "LabelPageHeader_GLTransaction"
            Me.LabelPageHeader_GLTransaction.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_GLTransaction.SizeF = New System.Drawing.SizeF(78.125!, 19.0!)
            Me.LabelPageHeader_GLTransaction.StylePriority.UseFont = False
            Me.LabelPageHeader_GLTransaction.Text = "GL XACT"
            Me.LabelPageHeader_GLTransaction.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_PostPeriod
            '
            Me.LabelPageHeader_PostPeriod.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_PostPeriod.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_PostPeriod.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_PostPeriod.BorderWidth = 1.0!
            Me.LabelPageHeader_PostPeriod.CanGrow = False
            Me.LabelPageHeader_PostPeriod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_PostPeriod.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_PostPeriod.LocationFloat = New DevExpress.Utils.PointFloat(604.0014!, 64.5834!)
            Me.LabelPageHeader_PostPeriod.Name = "LabelPageHeader_PostPeriod"
            Me.LabelPageHeader_PostPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_PostPeriod.SizeF = New System.Drawing.SizeF(66.66663!, 19.0!)
            Me.LabelPageHeader_PostPeriod.StylePriority.UseFont = False
            Me.LabelPageHeader_PostPeriod.Text = "Post Period"
            Me.LabelPageHeader_PostPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_DateToPay
            '
            Me.LabelPageHeader_DateToPay.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_DateToPay.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_DateToPay.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_DateToPay.BorderWidth = 1.0!
            Me.LabelPageHeader_DateToPay.CanGrow = False
            Me.LabelPageHeader_DateToPay.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_DateToPay.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_DateToPay.LocationFloat = New DevExpress.Utils.PointFloat(532.2914!, 64.5834!)
            Me.LabelPageHeader_DateToPay.Name = "LabelPageHeader_DateToPay"
            Me.LabelPageHeader_DateToPay.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_DateToPay.SizeF = New System.Drawing.SizeF(67.70999!, 19.0!)
            Me.LabelPageHeader_DateToPay.StylePriority.UseFont = False
            Me.LabelPageHeader_DateToPay.Text = "Date to Pay"
            Me.LabelPageHeader_DateToPay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_InvoiceDate
            '
            Me.LabelPageHeader_InvoiceDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_InvoiceDate.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_InvoiceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_InvoiceDate.BorderWidth = 1.0!
            Me.LabelPageHeader_InvoiceDate.CanGrow = False
            Me.LabelPageHeader_InvoiceDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_InvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(466.458!, 64.5834!)
            Me.LabelPageHeader_InvoiceDate.Name = "LabelPageHeader_InvoiceDate"
            Me.LabelPageHeader_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_InvoiceDate.SizeF = New System.Drawing.SizeF(61.45837!, 19.0!)
            Me.LabelPageHeader_InvoiceDate.StylePriority.UseFont = False
            Me.LabelPageHeader_InvoiceDate.Text = "Date"
            Me.LabelPageHeader_InvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Middle
            '
            Me.LinePageHeader_Middle.BorderColor = System.Drawing.Color.Black
            Me.LinePageHeader_Middle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Middle.BorderWidth = 0!
            Me.LinePageHeader_Middle.ForeColor = System.Drawing.Color.Gray
            Me.LinePageHeader_Middle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 60.58337!)
            Me.LinePageHeader_Middle.Name = "LinePageHeader_Middle"
            Me.LinePageHeader_Middle.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LinePageHeader_Middle.StylePriority.UseBorderColor = False
            Me.LinePageHeader_Middle.StylePriority.UseBorderWidth = False
            Me.LinePageHeader_Middle.StylePriority.UseForeColor = False
            '
            'LabelPageHeader_Invoice
            '
            Me.LabelPageHeader_Invoice.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Invoice.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Invoice.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Invoice.BorderWidth = 1.0!
            Me.LabelPageHeader_Invoice.CanGrow = False
            Me.LabelPageHeader_Invoice.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Invoice.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Invoice.LocationFloat = New DevExpress.Utils.PointFloat(236.5!, 64.58334!)
            Me.LabelPageHeader_Invoice.Name = "LabelPageHeader_Invoice"
            Me.LabelPageHeader_Invoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Invoice.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelPageHeader_Invoice.StylePriority.UseFont = False
            Me.LabelPageHeader_Invoice.Text = "Invoice"
            Me.LabelPageHeader_Invoice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 83.5834!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LinePageHeader_Bottom.StylePriority.UseBorderColor = False
            Me.LinePageHeader_Bottom.StylePriority.UseBorderWidth = False
            Me.LinePageHeader_Bottom.StylePriority.UseForeColor = False
            '
            'LabelPageHeader_Vendor
            '
            Me.LabelPageHeader_Vendor.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Vendor.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Vendor.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Vendor.BorderWidth = 1.0!
            Me.LabelPageHeader_Vendor.CanGrow = False
            Me.LabelPageHeader_Vendor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Vendor.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Vendor.LocationFloat = New DevExpress.Utils.PointFloat(0!, 64.58334!)
            Me.LabelPageHeader_Vendor.Name = "LabelPageHeader_Vendor"
            Me.LabelPageHeader_Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Vendor.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelPageHeader_Vendor.StylePriority.UseFont = False
            Me.LabelPageHeader_Vendor.Text = "Vendor"
            Me.LabelPageHeader_Vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1.0!
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.083315!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(670.668!, 29.00001!)
            Me.LabelPageHeader_Title.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Title.Text = "Accounts Payable Batch Report - Summary by Chronological Entry"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Status
            '
            Me.LabelPageHeader_Status.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Status.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Status.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Status.BorderWidth = 1.0!
            Me.LabelPageHeader_Status.CanGrow = False
            Me.LabelPageHeader_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Status.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Status.LocationFloat = New DevExpress.Utils.PointFloat(750.0417!, 64.58334!)
            Me.LabelPageHeader_Status.Name = "LabelPageHeader_Status"
            Me.LabelPageHeader_Status.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Status.SizeF = New System.Drawing.SizeF(64.58337!, 19.0!)
            Me.LabelPageHeader_Status.StylePriority.UseFont = False
            Me.LabelPageHeader_Status.Text = "Status"
            Me.LabelPageHeader_Status.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date, Me.XrPageInfo, Me.LabelPageFooter_Top})
            Me.PageFooter.HeightF = 25.08328!
            Me.PageFooter.Name = "PageFooter"
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
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 4.083315!)
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
            Me.LabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 4.083315!)
            Me.LabelPageFooter_Date.Name = "LabelPageFooter_Date"
            Me.LabelPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_Date.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_Date.StylePriority.UseFont = False
            Me.LabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrPageInfo
            '
            Me.XrPageInfo.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrPageInfo.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 4.083315!)
            Me.XrPageInfo.Name = "XrPageInfo"
            Me.XrPageInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfo.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.XrPageInfo.StylePriority.UseFont = False
            Me.XrPageInfo.StylePriority.UseTextAlignment = False
            Me.XrPageInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrPageInfo.TextFormatString = "Page {0} of {1}"
            '
            'LabelPageFooter_Top
            '
            Me.LabelPageFooter_Top.BorderColor = System.Drawing.Color.Silver
            Me.LabelPageFooter_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_Top.BorderWidth = 4.0!
            Me.LabelPageFooter_Top.ForeColor = System.Drawing.Color.Silver
            Me.LabelPageFooter_Top.LineWidth = 4.0!
            Me.LabelPageFooter_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelPageFooter_Top.Name = "LabelPageFooter_Top"
            Me.LabelPageFooter_Top.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineReportFooter_Top, Me.LabelReportFooter_SumDisbursed, Me.LabelReportFooter_BatchTotal})
            Me.ReportFooter.HeightF = 39.66665!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LineReportFooter_Top
            '
            Me.LineReportFooter_Top.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_Top.BorderWidth = 0!
            Me.LineReportFooter_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineReportFooter_Top.Name = "LineReportFooter_Top"
            Me.LineReportFooter_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.LineReportFooter_Top.StylePriority.UseBorderColor = False
            Me.LineReportFooter_Top.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_Top.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_SumDisbursed
            '
            Me.LabelReportFooter_SumDisbursed.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Disbursed", "{0:$0.00}")})
            Me.LabelReportFooter_SumDisbursed.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 4.000004!)
            Me.LabelReportFooter_SumDisbursed.Name = "LabelReportFooter_SumDisbursed"
            Me.LabelReportFooter_SumDisbursed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumDisbursed.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.LabelReportFooter_SumDisbursed.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumDisbursed.Summary = XrSummary1
            Me.LabelReportFooter_SumDisbursed.Text = "LabelReportFooter_SumDisbursed"
            Me.LabelReportFooter_SumDisbursed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.LabelReportFooter_BatchTotal.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 4.000004!)
            Me.LabelReportFooter_BatchTotal.Name = "LabelReportFooter_BatchTotal"
            Me.LabelReportFooter_BatchTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotal.SizeF = New System.Drawing.SizeF(99.99995!, 19.0!)
            Me.LabelReportFooter_BatchTotal.StylePriority.UseBorders = False
            Me.LabelReportFooter_BatchTotal.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotal.Text = "Batch Total:"
            Me.LabelReportFooter_BatchTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Disbursed
            '
            Me.Disbursed.Expression = "[SumAmount] + [SumSalesTax] + [SumShipping]"
            Me.Disbursed.Name = "Disbursed"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport)
            '
            'AccountPayableBatchSummaryDataEntryOrderReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.ReportFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Disbursed})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(49, 51, 49, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Vendor As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageHeader_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageHeader_Middle As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Invoice As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_DateToPay As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_GLTransaction As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_PostPeriod As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Status As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_GLACode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Total As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelReportFooter_BatchTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Disbursed As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Status As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLTransaction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PostPeriod As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DateToPay As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Invoice As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Vendor As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Disbursed As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelReportFooter_SumDisbursed As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLACode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageFooter_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrPageInfo As DevExpress.XtraReports.UI.XRPageInfo
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CurrencyCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ForeignAmount As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
