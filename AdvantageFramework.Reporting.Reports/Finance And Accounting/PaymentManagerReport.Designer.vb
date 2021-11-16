Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class PaymentManagerReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabelDetail_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelDetail_AmountPaid = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelDetail_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelDetail_InvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_InvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_AmountPaid = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLabelPageHeader_PostPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_PostPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_GLTransaction = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_GLTransactionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_ExportUserID = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_ExportUserIDLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_ChecksDated = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_ChecksDatedLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_CheckRunID = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_Account = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_BankCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_CheckRunIDLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_AccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelPageHeader_BankCodeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrLinePageFooter_Line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelGroupHeader_CheckNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CheckAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CheckNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_CheckAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineGroupHeader_Line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelGroupHeader_Email = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_Vendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_EmailLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupHeader_VendorLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineGroupHeader_Line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabelGroupFooter_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupFooter_TotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineGroupFooter_Line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.ObjectDataSource = New DevExpress.DataAccess.ObjectBinding.ObjectDataSource(Me.components)
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.XrLabelReportFooter_GrandTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelReportFooter_GrandTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineReportFooter_Line1 = New DevExpress.XtraReports.UI.XRLine()
            CType(Me.ObjectDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelDetail_InvoiceDate, Me.XrLabelDetail_AmountPaid, Me.XrLabelDetail_Description, Me.XrLabelDetail_InvoiceNumber})
            Me.Detail.HeightF = 24.70798!
            Me.Detail.KeepTogether = True
            Me.Detail.KeepTogetherWithDetailReports = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelDetail_InvoiceDate
            '
            Me.XrLabelDetail_InvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APInvoiceDate", "{0:d}")})
            Me.XrLabelDetail_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(501.0417!, 0!)
            Me.XrLabelDetail_InvoiceDate.Name = "XrLabelDetail_InvoiceDate"
            Me.XrLabelDetail_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDetail_InvoiceDate.SizeF = New System.Drawing.SizeF(105.4583!, 19.0!)
            Me.XrLabelDetail_InvoiceDate.StylePriority.UseTextAlignment = False
            Me.XrLabelDetail_InvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabelDetail_AmountPaid
            '
            Me.XrLabelDetail_AmountPaid.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APCheckAmount")})
            Me.XrLabelDetail_AmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(864.5416!, 0!)
            Me.XrLabelDetail_AmountPaid.Name = "XrLabelDetail_AmountPaid"
            Me.XrLabelDetail_AmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDetail_AmountPaid.SizeF = New System.Drawing.SizeF(135.459!, 19.0!)
            Me.XrLabelDetail_AmountPaid.StylePriority.UseTextAlignment = False
            Me.XrLabelDetail_AmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelDetail_AmountPaid.TextFormatString = "{0:c2}"
            '
            'XrLabelDetail_Description
            '
            Me.XrLabelDetail_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APInvoiceDescription")})
            Me.XrLabelDetail_Description.LocationFloat = New DevExpress.Utils.PointFloat(606.5!, 0!)
            Me.XrLabelDetail_Description.Name = "XrLabelDetail_Description"
            Me.XrLabelDetail_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDetail_Description.SizeF = New System.Drawing.SizeF(258.0416!, 19.0!)
            '
            'XrLabelDetail_InvoiceNumber
            '
            Me.XrLabelDetail_InvoiceNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APInvoiceNumber")})
            Me.XrLabelDetail_InvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(352.0832!, 0!)
            Me.XrLabelDetail_InvoiceNumber.Name = "XrLabelDetail_InvoiceNumber"
            Me.XrLabelDetail_InvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDetail_InvoiceNumber.SizeF = New System.Drawing.SizeF(148.9585!, 19.0!)
            '
            'XrLabelGroupHeader_InvoiceNumber
            '
            Me.XrLabelGroupHeader_InvoiceNumber.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_InvoiceNumber.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_InvoiceNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_InvoiceNumber.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_InvoiceNumber.CanGrow = False
            Me.XrLabelGroupHeader_InvoiceNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_InvoiceNumber.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_InvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(352.0832!, 84.00003!)
            Me.XrLabelGroupHeader_InvoiceNumber.Name = "XrLabelGroupHeader_InvoiceNumber"
            Me.XrLabelGroupHeader_InvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_InvoiceNumber.SizeF = New System.Drawing.SizeF(148.9582!, 19.0!)
            Me.XrLabelGroupHeader_InvoiceNumber.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_InvoiceNumber.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_InvoiceNumber.Text = "Invoice Number"
            Me.XrLabelGroupHeader_InvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabelGroupHeader_AmountPaid
            '
            Me.XrLabelGroupHeader_AmountPaid.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_AmountPaid.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_AmountPaid.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_AmountPaid.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_AmountPaid.CanGrow = False
            Me.XrLabelGroupHeader_AmountPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_AmountPaid.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_AmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(864.5414!, 84.00003!)
            Me.XrLabelGroupHeader_AmountPaid.Name = "XrLabelGroupHeader_AmountPaid"
            Me.XrLabelGroupHeader_AmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_AmountPaid.SizeF = New System.Drawing.SizeF(135.4586!, 19.0!)
            Me.XrLabelGroupHeader_AmountPaid.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_AmountPaid.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_AmountPaid.Text = "Amount Paid"
            Me.XrLabelGroupHeader_AmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelGroupHeader_InvoiceDate
            '
            Me.XrLabelGroupHeader_InvoiceDate.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_InvoiceDate.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_InvoiceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_InvoiceDate.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_InvoiceDate.CanGrow = False
            Me.XrLabelGroupHeader_InvoiceDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_InvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(501.0414!, 84.00003!)
            Me.XrLabelGroupHeader_InvoiceDate.Name = "XrLabelGroupHeader_InvoiceDate"
            Me.XrLabelGroupHeader_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_InvoiceDate.SizeF = New System.Drawing.SizeF(105.4583!, 19.0!)
            Me.XrLabelGroupHeader_InvoiceDate.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_InvoiceDate.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_InvoiceDate.Text = "Invoice Date"
            Me.XrLabelGroupHeader_InvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelPageHeader_PostPeriod, Me.XrLabelPageHeader_PostPeriodLabel, Me.XrLabelPageHeader_GLTransaction, Me.XrLabelPageHeader_GLTransactionLabel, Me.XrLabelPageHeader_ExportUserID, Me.XrLabelPageHeader_ExportUserIDLabel, Me.XrLabelPageHeader_ChecksDated, Me.XrLabelPageHeader_ChecksDatedLabel, Me.XrLabelPageHeader_CheckRunID, Me.XrLabelPageHeader_Account, Me.XrLabelPageHeader_BankCode, Me.XrLabelPageHeader_CheckRunIDLabel, Me.XrLabelPageHeader_AccountLabel, Me.XrLabelPageHeader_Agency, Me.XrLinePageHeader_Top, Me.XrLabelPageHeader_BankCodeLabel, Me.XrLabelPageHeader_ReportTitle, Me.XrLinePageHeader_Bottom})
            Me.PageHeader.HeightF = 137.6251!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelPageHeader_PostPeriod
            '
            Me.XrLabelPageHeader_PostPeriod.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_PostPeriod.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_PostPeriod.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_PostPeriod.BorderWidth = 1.0!
            Me.XrLabelPageHeader_PostPeriod.CanGrow = False
            Me.XrLabelPageHeader_PostPeriod.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelPageHeader_PostPeriod.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_PostPeriod.LocationFloat = New DevExpress.Utils.PointFloat(606.5!, 83.75002!)
            Me.XrLabelPageHeader_PostPeriod.Name = "XrLabelPageHeader_PostPeriod"
            Me.XrLabelPageHeader_PostPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_PostPeriod.SizeF = New System.Drawing.SizeF(393.5!, 17.0!)
            Me.XrLabelPageHeader_PostPeriod.StylePriority.UseFont = False
            Me.XrLabelPageHeader_PostPeriod.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_PostPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_PostPeriodLabel
            '
            Me.XrLabelPageHeader_PostPeriodLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_PostPeriodLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_PostPeriodLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_PostPeriodLabel.BorderWidth = 1.0!
            Me.XrLabelPageHeader_PostPeriodLabel.CanGrow = False
            Me.XrLabelPageHeader_PostPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPageHeader_PostPeriodLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_PostPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(501.0417!, 83.75002!)
            Me.XrLabelPageHeader_PostPeriodLabel.Name = "XrLabelPageHeader_PostPeriodLabel"
            Me.XrLabelPageHeader_PostPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_PostPeriodLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.0!)
            Me.XrLabelPageHeader_PostPeriodLabel.StylePriority.UseFont = False
            Me.XrLabelPageHeader_PostPeriodLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_PostPeriodLabel.Text = "Post Period:"
            Me.XrLabelPageHeader_PostPeriodLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_GLTransaction
            '
            Me.XrLabelPageHeader_GLTransaction.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_GLTransaction.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_GLTransaction.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_GLTransaction.BorderWidth = 1.0!
            Me.XrLabelPageHeader_GLTransaction.CanGrow = False
            Me.XrLabelPageHeader_GLTransaction.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelPageHeader_GLTransaction.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_GLTransaction.LocationFloat = New DevExpress.Utils.PointFloat(606.5!, 66.75002!)
            Me.XrLabelPageHeader_GLTransaction.Name = "XrLabelPageHeader_GLTransaction"
            Me.XrLabelPageHeader_GLTransaction.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_GLTransaction.SizeF = New System.Drawing.SizeF(393.5!, 17.0!)
            Me.XrLabelPageHeader_GLTransaction.StylePriority.UseFont = False
            Me.XrLabelPageHeader_GLTransaction.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_GLTransaction.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_GLTransactionLabel
            '
            Me.XrLabelPageHeader_GLTransactionLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_GLTransactionLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_GLTransactionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_GLTransactionLabel.BorderWidth = 1.0!
            Me.XrLabelPageHeader_GLTransactionLabel.CanGrow = False
            Me.XrLabelPageHeader_GLTransactionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPageHeader_GLTransactionLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_GLTransactionLabel.LocationFloat = New DevExpress.Utils.PointFloat(501.0417!, 66.75002!)
            Me.XrLabelPageHeader_GLTransactionLabel.Name = "XrLabelPageHeader_GLTransactionLabel"
            Me.XrLabelPageHeader_GLTransactionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_GLTransactionLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.0!)
            Me.XrLabelPageHeader_GLTransactionLabel.StylePriority.UseFont = False
            Me.XrLabelPageHeader_GLTransactionLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_GLTransactionLabel.Text = "GL Transaction:"
            Me.XrLabelPageHeader_GLTransactionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_ExportUserID
            '
            Me.XrLabelPageHeader_ExportUserID.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_ExportUserID.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ExportUserID.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_ExportUserID.BorderWidth = 1.0!
            Me.XrLabelPageHeader_ExportUserID.CanGrow = False
            Me.XrLabelPageHeader_ExportUserID.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelPageHeader_ExportUserID.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ExportUserID.LocationFloat = New DevExpress.Utils.PointFloat(105.4582!, 117.75!)
            Me.XrLabelPageHeader_ExportUserID.Name = "XrLabelPageHeader_ExportUserID"
            Me.XrLabelPageHeader_ExportUserID.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_ExportUserID.SizeF = New System.Drawing.SizeF(395.5835!, 17.00001!)
            Me.XrLabelPageHeader_ExportUserID.StylePriority.UseFont = False
            Me.XrLabelPageHeader_ExportUserID.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_ExportUserID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_ExportUserIDLabel
            '
            Me.XrLabelPageHeader_ExportUserIDLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_ExportUserIDLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ExportUserIDLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_ExportUserIDLabel.BorderWidth = 1.0!
            Me.XrLabelPageHeader_ExportUserIDLabel.CanGrow = False
            Me.XrLabelPageHeader_ExportUserIDLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPageHeader_ExportUserIDLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ExportUserIDLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 117.75!)
            Me.XrLabelPageHeader_ExportUserIDLabel.Name = "XrLabelPageHeader_ExportUserIDLabel"
            Me.XrLabelPageHeader_ExportUserIDLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_ExportUserIDLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.00001!)
            Me.XrLabelPageHeader_ExportUserIDLabel.StylePriority.UseFont = False
            Me.XrLabelPageHeader_ExportUserIDLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_ExportUserIDLabel.Text = "Export User ID:"
            Me.XrLabelPageHeader_ExportUserIDLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_ChecksDated
            '
            Me.XrLabelPageHeader_ChecksDated.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_ChecksDated.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ChecksDated.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_ChecksDated.BorderWidth = 1.0!
            Me.XrLabelPageHeader_ChecksDated.CanGrow = False
            Me.XrLabelPageHeader_ChecksDated.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelPageHeader_ChecksDated.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ChecksDated.LocationFloat = New DevExpress.Utils.PointFloat(105.4582!, 100.75!)
            Me.XrLabelPageHeader_ChecksDated.Name = "XrLabelPageHeader_ChecksDated"
            Me.XrLabelPageHeader_ChecksDated.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_ChecksDated.SizeF = New System.Drawing.SizeF(395.5835!, 17.00001!)
            Me.XrLabelPageHeader_ChecksDated.StylePriority.UseFont = False
            Me.XrLabelPageHeader_ChecksDated.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_ChecksDated.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_ChecksDatedLabel
            '
            Me.XrLabelPageHeader_ChecksDatedLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_ChecksDatedLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ChecksDatedLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_ChecksDatedLabel.BorderWidth = 1.0!
            Me.XrLabelPageHeader_ChecksDatedLabel.CanGrow = False
            Me.XrLabelPageHeader_ChecksDatedLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPageHeader_ChecksDatedLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ChecksDatedLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 100.75!)
            Me.XrLabelPageHeader_ChecksDatedLabel.Name = "XrLabelPageHeader_ChecksDatedLabel"
            Me.XrLabelPageHeader_ChecksDatedLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_ChecksDatedLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.00001!)
            Me.XrLabelPageHeader_ChecksDatedLabel.StylePriority.UseFont = False
            Me.XrLabelPageHeader_ChecksDatedLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_ChecksDatedLabel.Text = "Checks Dated:"
            Me.XrLabelPageHeader_ChecksDatedLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_CheckRunID
            '
            Me.XrLabelPageHeader_CheckRunID.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_CheckRunID.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_CheckRunID.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_CheckRunID.BorderWidth = 1.0!
            Me.XrLabelPageHeader_CheckRunID.CanGrow = False
            Me.XrLabelPageHeader_CheckRunID.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelPageHeader_CheckRunID.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_CheckRunID.LocationFloat = New DevExpress.Utils.PointFloat(105.4582!, 83.75002!)
            Me.XrLabelPageHeader_CheckRunID.Name = "XrLabelPageHeader_CheckRunID"
            Me.XrLabelPageHeader_CheckRunID.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_CheckRunID.SizeF = New System.Drawing.SizeF(395.5835!, 17.00001!)
            Me.XrLabelPageHeader_CheckRunID.StylePriority.UseFont = False
            Me.XrLabelPageHeader_CheckRunID.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_CheckRunID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_Account
            '
            Me.XrLabelPageHeader_Account.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_Account.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_Account.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_Account.BorderWidth = 1.0!
            Me.XrLabelPageHeader_Account.CanGrow = False
            Me.XrLabelPageHeader_Account.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelPageHeader_Account.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_Account.LocationFloat = New DevExpress.Utils.PointFloat(105.4583!, 66.75002!)
            Me.XrLabelPageHeader_Account.Name = "XrLabelPageHeader_Account"
            Me.XrLabelPageHeader_Account.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_Account.SizeF = New System.Drawing.SizeF(395.5833!, 17.0!)
            Me.XrLabelPageHeader_Account.StylePriority.UseFont = False
            Me.XrLabelPageHeader_Account.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_Account.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_BankCode
            '
            Me.XrLabelPageHeader_BankCode.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_BankCode.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_BankCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_BankCode.BorderWidth = 1.0!
            Me.XrLabelPageHeader_BankCode.CanGrow = False
            Me.XrLabelPageHeader_BankCode.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelPageHeader_BankCode.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_BankCode.LocationFloat = New DevExpress.Utils.PointFloat(105.4583!, 49.75001!)
            Me.XrLabelPageHeader_BankCode.Name = "XrLabelPageHeader_BankCode"
            Me.XrLabelPageHeader_BankCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_BankCode.SizeF = New System.Drawing.SizeF(395.5833!, 17.0!)
            Me.XrLabelPageHeader_BankCode.StylePriority.UseFont = False
            Me.XrLabelPageHeader_BankCode.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_BankCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_CheckRunIDLabel
            '
            Me.XrLabelPageHeader_CheckRunIDLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_CheckRunIDLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_CheckRunIDLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_CheckRunIDLabel.BorderWidth = 1.0!
            Me.XrLabelPageHeader_CheckRunIDLabel.CanGrow = False
            Me.XrLabelPageHeader_CheckRunIDLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPageHeader_CheckRunIDLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_CheckRunIDLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 83.75002!)
            Me.XrLabelPageHeader_CheckRunIDLabel.Name = "XrLabelPageHeader_CheckRunIDLabel"
            Me.XrLabelPageHeader_CheckRunIDLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_CheckRunIDLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.00001!)
            Me.XrLabelPageHeader_CheckRunIDLabel.StylePriority.UseFont = False
            Me.XrLabelPageHeader_CheckRunIDLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_CheckRunIDLabel.Text = "Check Run ID:"
            Me.XrLabelPageHeader_CheckRunIDLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_AccountLabel
            '
            Me.XrLabelPageHeader_AccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_AccountLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_AccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_AccountLabel.BorderWidth = 1.0!
            Me.XrLabelPageHeader_AccountLabel.CanGrow = False
            Me.XrLabelPageHeader_AccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPageHeader_AccountLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_AccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 66.75002!)
            Me.XrLabelPageHeader_AccountLabel.Name = "XrLabelPageHeader_AccountLabel"
            Me.XrLabelPageHeader_AccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_AccountLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.00001!)
            Me.XrLabelPageHeader_AccountLabel.StylePriority.UseFont = False
            Me.XrLabelPageHeader_AccountLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_AccountLabel.Text = "Account:"
            Me.XrLabelPageHeader_AccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_Agency
            '
            Me.XrLabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_Agency.BorderWidth = 1.0!
            Me.XrLabelPageHeader_Agency.CanGrow = False
            Me.XrLabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(501.0417!, 14.50002!)
            Me.XrLabelPageHeader_Agency.Name = "XrLabelPageHeader_Agency"
            Me.XrLabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(498.9583!, 18.58334!)
            Me.XrLabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.XrLabelPageHeader_Agency.StylePriority.UseFont = False
            Me.XrLabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.XrLabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLinePageHeader_Top
            '
            Me.XrLinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.XrLinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLinePageHeader_Top.BorderWidth = 4.0!
            Me.XrLinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.XrLinePageHeader_Top.LineWidth = 4.0!
            Me.XrLinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLinePageHeader_Top.Name = "XrLinePageHeader_Top"
            Me.XrLinePageHeader_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
            '
            'XrLabelPageHeader_BankCodeLabel
            '
            Me.XrLabelPageHeader_BankCodeLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_BankCodeLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_BankCodeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_BankCodeLabel.BorderWidth = 1.0!
            Me.XrLabelPageHeader_BankCodeLabel.CanGrow = False
            Me.XrLabelPageHeader_BankCodeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPageHeader_BankCodeLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_BankCodeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 49.75001!)
            Me.XrLabelPageHeader_BankCodeLabel.Name = "XrLabelPageHeader_BankCodeLabel"
            Me.XrLabelPageHeader_BankCodeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_BankCodeLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.0!)
            Me.XrLabelPageHeader_BankCodeLabel.StylePriority.UseFont = False
            Me.XrLabelPageHeader_BankCodeLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_BankCodeLabel.Text = "Bank Code:"
            Me.XrLabelPageHeader_BankCodeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageHeader_ReportTitle
            '
            Me.XrLabelPageHeader_ReportTitle.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageHeader_ReportTitle.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ReportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageHeader_ReportTitle.BorderWidth = 1.0!
            Me.XrLabelPageHeader_ReportTitle.CanGrow = False
            Me.XrLabelPageHeader_ReportTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPageHeader_ReportTitle.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.083347!)
            Me.XrLabelPageHeader_ReportTitle.Name = "XrLabelPageHeader_ReportTitle"
            Me.XrLabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
            Me.XrLabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.XrLabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.XrLabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.XrLabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.XrLabelPageHeader_ReportTitle.Text = "Payment Manager Report"
            Me.XrLabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLinePageHeader_Bottom
            '
            Me.XrLinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.XrLinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLinePageHeader_Bottom.BorderWidth = 4.0!
            Me.XrLinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.XrLinePageHeader_Bottom.LineWidth = 4.0!
            Me.XrLinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.000222524!, 33.08336!)
            Me.XrLinePageHeader_Bottom.Name = "XrLinePageHeader_Bottom"
            Me.XrLinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(864.5417!, 4.083379!)
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
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLinePageFooter_Line1, Me.XrLabelPageFooter_UserCode, Me.XrLabelPageFooter_Date, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 25.08335!
            Me.PageFooter.Name = "PageFooter"
            '
            'XrLinePageFooter_Line1
            '
            Me.XrLinePageFooter_Line1.BorderColor = System.Drawing.Color.Silver
            Me.XrLinePageFooter_Line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLinePageFooter_Line1.BorderWidth = 4.0!
            Me.XrLinePageFooter_Line1.ForeColor = System.Drawing.Color.Silver
            Me.XrLinePageFooter_Line1.LineWidth = 4.0!
            Me.XrLinePageFooter_Line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLinePageFooter_Line1.Name = "XrLinePageFooter_Line1"
            Me.XrLinePageFooter_Line1.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
            '
            'XrLabelPageFooter_UserCode
            '
            Me.XrLabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageFooter_UserCode.BorderWidth = 1.0!
            Me.XrLabelPageFooter_UserCode.CanGrow = False
            Me.XrLabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabelPageFooter_UserCode.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 4.083347!)
            Me.XrLabelPageFooter_UserCode.Name = "XrLabelPageFooter_UserCode"
            Me.XrLabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.XrLabelPageFooter_UserCode.StylePriority.UseFont = False
            Me.XrLabelPageFooter_UserCode.StylePriority.UseTextAlignment = False
            Me.XrLabelPageFooter_UserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelPageFooter_Date
            '
            Me.XrLabelPageFooter_Date.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelPageFooter_Date.BorderColor = System.Drawing.Color.Black
            Me.XrLabelPageFooter_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelPageFooter_Date.BorderWidth = 1.0!
            Me.XrLabelPageFooter_Date.CanGrow = False
            Me.XrLabelPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabelPageFooter_Date.ForeColor = System.Drawing.Color.Black
            Me.XrLabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 4.083379!)
            Me.XrLabelPageFooter_Date.Name = "XrLabelPageFooter_Date"
            Me.XrLabelPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelPageFooter_Date.SizeF = New System.Drawing.SizeF(234.9999!, 19.0!)
            Me.XrLabelPageFooter_Date.StylePriority.UseFont = False
            Me.XrLabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.XrLabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelGroupHeader_Description
            '
            Me.XrLabelGroupHeader_Description.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_Description.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_Description.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_Description.CanGrow = False
            Me.XrLabelGroupHeader_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroupHeader_Description.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_Description.LocationFloat = New DevExpress.Utils.PointFloat(606.4998!, 84.00003!)
            Me.XrLabelGroupHeader_Description.Name = "XrLabelGroupHeader_Description"
            Me.XrLabelGroupHeader_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Description.SizeF = New System.Drawing.SizeF(258.0416!, 19.0!)
            Me.XrLabelGroupHeader_Description.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_Description.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_Description.Text = "Description"
            Me.XrLabelGroupHeader_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelGroupHeader_CheckNumberLabel, Me.XrLabelGroupHeader_CheckAmountLabel, Me.XrLabelGroupHeader_CheckNumber, Me.XrLabelGroupHeader_CheckAmount, Me.XrLineGroupHeader_Line2, Me.XrLabelGroupHeader_AmountPaid, Me.XrLabelGroupHeader_Description, Me.XrLabelGroupHeader_InvoiceDate, Me.XrLabelGroupHeader_InvoiceNumber, Me.XrLabelGroupHeader_Email, Me.XrLabelGroupHeader_Vendor, Me.XrLabelGroupHeader_EmailLabel, Me.XrLabelGroupHeader_VendorLabel, Me.XrLineGroupHeader_Line1})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("CheckNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 105.0001!
            Me.GroupHeader.KeepTogether = True
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrLabelGroupHeader_CheckNumberLabel
            '
            Me.XrLabelGroupHeader_CheckNumberLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_CheckNumberLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_CheckNumberLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_CheckNumberLabel.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_CheckNumberLabel.CanGrow = False
            Me.XrLabelGroupHeader_CheckNumberLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGroupHeader_CheckNumberLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_CheckNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(105.4582!, 41.00002!)
            Me.XrLabelGroupHeader_CheckNumberLabel.Name = "XrLabelGroupHeader_CheckNumberLabel"
            Me.XrLabelGroupHeader_CheckNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CheckNumberLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.0!)
            Me.XrLabelGroupHeader_CheckNumberLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CheckNumberLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_CheckNumberLabel.Text = "Check Number:"
            Me.XrLabelGroupHeader_CheckNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelGroupHeader_CheckAmountLabel
            '
            Me.XrLabelGroupHeader_CheckAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_CheckAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_CheckAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_CheckAmountLabel.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_CheckAmountLabel.CanGrow = False
            Me.XrLabelGroupHeader_CheckAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGroupHeader_CheckAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_CheckAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(105.4582!, 58.00002!)
            Me.XrLabelGroupHeader_CheckAmountLabel.Name = "XrLabelGroupHeader_CheckAmountLabel"
            Me.XrLabelGroupHeader_CheckAmountLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.00001!)
            Me.XrLabelGroupHeader_CheckAmountLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CheckAmountLabel.StylePriority.UsePadding = False
            Me.XrLabelGroupHeader_CheckAmountLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_CheckAmountLabel.Text = "Check Amount:"
            Me.XrLabelGroupHeader_CheckAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelGroupHeader_CheckNumber
            '
            Me.XrLabelGroupHeader_CheckNumber.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_CheckNumber.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_CheckNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_CheckNumber.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_CheckNumber.CanGrow = False
            Me.XrLabelGroupHeader_CheckNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckNumber")})
            Me.XrLabelGroupHeader_CheckNumber.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelGroupHeader_CheckNumber.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_CheckNumber.LocationFloat = New DevExpress.Utils.PointFloat(210.9165!, 41.00002!)
            Me.XrLabelGroupHeader_CheckNumber.Name = "XrLabelGroupHeader_CheckNumber"
            Me.XrLabelGroupHeader_CheckNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CheckNumber.SizeF = New System.Drawing.SizeF(789.084!, 17.0!)
            Me.XrLabelGroupHeader_CheckNumber.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CheckNumber.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_CheckNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelGroupHeader_CheckAmount
            '
            Me.XrLabelGroupHeader_CheckAmount.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_CheckAmount.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_CheckAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_CheckAmount.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_CheckAmount.CanGrow = False
            Me.XrLabelGroupHeader_CheckAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount")})
            Me.XrLabelGroupHeader_CheckAmount.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelGroupHeader_CheckAmount.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_CheckAmount.LocationFloat = New DevExpress.Utils.PointFloat(210.9166!, 58.00002!)
            Me.XrLabelGroupHeader_CheckAmount.Name = "XrLabelGroupHeader_CheckAmount"
            Me.XrLabelGroupHeader_CheckAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_CheckAmount.SizeF = New System.Drawing.SizeF(789.084!, 17.0!)
            Me.XrLabelGroupHeader_CheckAmount.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_CheckAmount.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_CheckAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrLabelGroupHeader_CheckAmount.TextFormatString = "{0:c2}"
            '
            'XrLineGroupHeader_Line2
            '
            Me.XrLineGroupHeader_Line2.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupHeader_Line2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupHeader_Line2.BorderWidth = 0!
            Me.XrLineGroupHeader_Line2.ForeColor = System.Drawing.Color.Gray
            Me.XrLineGroupHeader_Line2.LineWidth = 2.0!
            Me.XrLineGroupHeader_Line2.LocationFloat = New DevExpress.Utils.PointFloat(352.0832!, 103.0001!)
            Me.XrLineGroupHeader_Line2.Name = "XrLineGroupHeader_Line2"
            Me.XrLineGroupHeader_Line2.SizeF = New System.Drawing.SizeF(647.9164!, 2.0!)
            Me.XrLineGroupHeader_Line2.StylePriority.UseBorderColor = False
            Me.XrLineGroupHeader_Line2.StylePriority.UseBorderWidth = False
            Me.XrLineGroupHeader_Line2.StylePriority.UseForeColor = False
            '
            'XrLabelGroupHeader_Email
            '
            Me.XrLabelGroupHeader_Email.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_Email.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_Email.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_Email.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_Email.CanGrow = False
            Me.XrLabelGroupHeader_Email.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorEmail")})
            Me.XrLabelGroupHeader_Email.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelGroupHeader_Email.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_Email.LocationFloat = New DevExpress.Utils.PointFloat(105.4587!, 24.00001!)
            Me.XrLabelGroupHeader_Email.Name = "XrLabelGroupHeader_Email"
            Me.XrLabelGroupHeader_Email.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Email.SizeF = New System.Drawing.SizeF(894.5408!, 17.0!)
            Me.XrLabelGroupHeader_Email.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_Email.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_Email.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelGroupHeader_Vendor
            '
            Me.XrLabelGroupHeader_Vendor.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_Vendor.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_Vendor.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_Vendor.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_Vendor.CanGrow = False
            Me.XrLabelGroupHeader_Vendor.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorName")})
            Me.XrLabelGroupHeader_Vendor.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelGroupHeader_Vendor.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_Vendor.LocationFloat = New DevExpress.Utils.PointFloat(105.4587!, 7.000001!)
            Me.XrLabelGroupHeader_Vendor.Name = "XrLabelGroupHeader_Vendor"
            Me.XrLabelGroupHeader_Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_Vendor.SizeF = New System.Drawing.SizeF(894.5408!, 17.0!)
            Me.XrLabelGroupHeader_Vendor.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_Vendor.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_Vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelGroupHeader_EmailLabel
            '
            Me.XrLabelGroupHeader_EmailLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_EmailLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_EmailLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_EmailLabel.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_EmailLabel.CanGrow = False
            Me.XrLabelGroupHeader_EmailLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGroupHeader_EmailLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_EmailLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 24.00001!)
            Me.XrLabelGroupHeader_EmailLabel.Name = "XrLabelGroupHeader_EmailLabel"
            Me.XrLabelGroupHeader_EmailLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_EmailLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.00001!)
            Me.XrLabelGroupHeader_EmailLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_EmailLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_EmailLabel.Text = "Email:"
            Me.XrLabelGroupHeader_EmailLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelGroupHeader_VendorLabel
            '
            Me.XrLabelGroupHeader_VendorLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupHeader_VendorLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_VendorLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupHeader_VendorLabel.BorderWidth = 1.0!
            Me.XrLabelGroupHeader_VendorLabel.CanGrow = False
            Me.XrLabelGroupHeader_VendorLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGroupHeader_VendorLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupHeader_VendorLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 7.0!)
            Me.XrLabelGroupHeader_VendorLabel.Name = "XrLabelGroupHeader_VendorLabel"
            Me.XrLabelGroupHeader_VendorLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupHeader_VendorLabel.SizeF = New System.Drawing.SizeF(105.4583!, 17.0!)
            Me.XrLabelGroupHeader_VendorLabel.StylePriority.UseFont = False
            Me.XrLabelGroupHeader_VendorLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupHeader_VendorLabel.Text = "Vendor:"
            Me.XrLabelGroupHeader_VendorLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLineGroupHeader_Line1
            '
            Me.XrLineGroupHeader_Line1.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupHeader_Line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupHeader_Line1.BorderWidth = 0!
            Me.XrLineGroupHeader_Line1.ForeColor = System.Drawing.Color.Gray
            Me.XrLineGroupHeader_Line1.LineWidth = 2.0!
            Me.XrLineGroupHeader_Line1.LocationFloat = New DevExpress.Utils.PointFloat(0.0003662109!, 0!)
            Me.XrLineGroupHeader_Line1.Name = "XrLineGroupHeader_Line1"
            Me.XrLineGroupHeader_Line1.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.XrLineGroupHeader_Line1.StylePriority.UseBorderColor = False
            Me.XrLineGroupHeader_Line1.StylePriority.UseBorderWidth = False
            Me.XrLineGroupHeader_Line1.StylePriority.UseForeColor = False
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelGroupFooter_Total, Me.XrLabelGroupFooter_TotalLabel, Me.XrLineGroupFooter_Line1})
            Me.GroupFooter.HeightF = 25.37511!
            Me.GroupFooter.Name = "GroupFooter"
            '
            'XrLabelGroupFooter_Total
            '
            Me.XrLabelGroupFooter_Total.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupFooter_Total.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupFooter_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupFooter_Total.BorderWidth = 1.0!
            Me.XrLabelGroupFooter_Total.CanGrow = False
            Me.XrLabelGroupFooter_Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APCheckAmount")})
            Me.XrLabelGroupFooter_Total.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelGroupFooter_Total.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupFooter_Total.LocationFloat = New DevExpress.Utils.PointFloat(864.5416!, 5.083333!)
            Me.XrLabelGroupFooter_Total.Name = "XrLabelGroupFooter_Total"
            Me.XrLabelGroupFooter_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelGroupFooter_Total.SizeF = New System.Drawing.SizeF(135.459!, 17.0!)
            Me.XrLabelGroupFooter_Total.StylePriority.UseFont = False
            Me.XrLabelGroupFooter_Total.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelGroupFooter_Total.Summary = XrSummary1
            Me.XrLabelGroupFooter_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelGroupFooter_Total.TextFormatString = "{0:c2}"
            '
            'XrLabelGroupFooter_TotalLabel
            '
            Me.XrLabelGroupFooter_TotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelGroupFooter_TotalLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelGroupFooter_TotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelGroupFooter_TotalLabel.BorderWidth = 1.0!
            Me.XrLabelGroupFooter_TotalLabel.CanGrow = False
            Me.XrLabelGroupFooter_TotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGroupFooter_TotalLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroupFooter_TotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(828.875!, 5.083338!)
            Me.XrLabelGroupFooter_TotalLabel.Name = "XrLabelGroupFooter_TotalLabel"
            Me.XrLabelGroupFooter_TotalLabel.SizeF = New System.Drawing.SizeF(35.66663!, 17.00001!)
            Me.XrLabelGroupFooter_TotalLabel.StylePriority.UseFont = False
            Me.XrLabelGroupFooter_TotalLabel.StylePriority.UsePadding = False
            Me.XrLabelGroupFooter_TotalLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupFooter_TotalLabel.Text = "Total:"
            Me.XrLabelGroupFooter_TotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLineGroupFooter_Line1
            '
            Me.XrLineGroupFooter_Line1.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupFooter_Line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupFooter_Line1.BorderWidth = 0!
            Me.XrLineGroupFooter_Line1.ForeColor = System.Drawing.Color.Gray
            Me.XrLineGroupFooter_Line1.LineWidth = 2.0!
            Me.XrLineGroupFooter_Line1.LocationFloat = New DevExpress.Utils.PointFloat(864.5414!, 0!)
            Me.XrLineGroupFooter_Line1.Name = "XrLineGroupFooter_Line1"
            Me.XrLineGroupFooter_Line1.SizeF = New System.Drawing.SizeF(135.4592!, 2.083333!)
            Me.XrLineGroupFooter_Line1.StylePriority.UseBorderColor = False
            Me.XrLineGroupFooter_Line1.StylePriority.UseBorderWidth = False
            Me.XrLineGroupFooter_Line1.StylePriority.UseForeColor = False
            '
            'ObjectDataSource
            '
            Me.ObjectDataSource.DataSource = GetType(AdvantageFramework.DTO.FinanceAndAccounting.PaymentManagerReport)
            Me.ObjectDataSource.Name = "ObjectDataSource"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelReportFooter_GrandTotal, Me.XrLabelReportFooter_GrandTotalLabel, Me.XrLineReportFooter_Line1})
            Me.ReportFooter.HeightF = 23.95833!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'XrLabelReportFooter_GrandTotal
            '
            Me.XrLabelReportFooter_GrandTotal.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelReportFooter_GrandTotal.BorderColor = System.Drawing.Color.Black
            Me.XrLabelReportFooter_GrandTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelReportFooter_GrandTotal.BorderWidth = 1.0!
            Me.XrLabelReportFooter_GrandTotal.CanGrow = False
            Me.XrLabelReportFooter_GrandTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APCheckAmount")})
            Me.XrLabelReportFooter_GrandTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelReportFooter_GrandTotal.ForeColor = System.Drawing.Color.Black
            Me.XrLabelReportFooter_GrandTotal.LocationFloat = New DevExpress.Utils.PointFloat(864.5405!, 4.999982!)
            Me.XrLabelReportFooter_GrandTotal.Name = "XrLabelReportFooter_GrandTotal"
            Me.XrLabelReportFooter_GrandTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelReportFooter_GrandTotal.SizeF = New System.Drawing.SizeF(135.459!, 17.0!)
            Me.XrLabelReportFooter_GrandTotal.StylePriority.UseFont = False
            Me.XrLabelReportFooter_GrandTotal.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabelReportFooter_GrandTotal.Summary = XrSummary2
            Me.XrLabelReportFooter_GrandTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelReportFooter_GrandTotal.TextFormatString = "{0:c2}"
            '
            'XrLabelReportFooter_GrandTotalLabel
            '
            Me.XrLabelReportFooter_GrandTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelReportFooter_GrandTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelReportFooter_GrandTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelReportFooter_GrandTotalLabel.BorderWidth = 1.0!
            Me.XrLabelReportFooter_GrandTotalLabel.CanGrow = False
            Me.XrLabelReportFooter_GrandTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabelReportFooter_GrandTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelReportFooter_GrandTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(793.4572!, 4.999924!)
            Me.XrLabelReportFooter_GrandTotalLabel.Name = "XrLabelReportFooter_GrandTotalLabel"
            Me.XrLabelReportFooter_GrandTotalLabel.SizeF = New System.Drawing.SizeF(71.08331!, 17.00001!)
            Me.XrLabelReportFooter_GrandTotalLabel.StylePriority.UseFont = False
            Me.XrLabelReportFooter_GrandTotalLabel.StylePriority.UsePadding = False
            Me.XrLabelReportFooter_GrandTotalLabel.StylePriority.UseTextAlignment = False
            Me.XrLabelReportFooter_GrandTotalLabel.Text = "Grand Total:"
            Me.XrLabelReportFooter_GrandTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLineReportFooter_Line1
            '
            Me.XrLineReportFooter_Line1.BorderColor = System.Drawing.Color.Black
            Me.XrLineReportFooter_Line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineReportFooter_Line1.BorderWidth = 0!
            Me.XrLineReportFooter_Line1.ForeColor = System.Drawing.Color.Gray
            Me.XrLineReportFooter_Line1.LineWidth = 2.0!
            Me.XrLineReportFooter_Line1.LocationFloat = New DevExpress.Utils.PointFloat(0.0006993611!, 0!)
            Me.XrLineReportFooter_Line1.Name = "XrLineReportFooter_Line1"
            Me.XrLineReportFooter_Line1.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.XrLineReportFooter_Line1.StylePriority.UseBorderColor = False
            Me.XrLineReportFooter_Line1.StylePriority.UseBorderWidth = False
            Me.XrLineReportFooter_Line1.StylePriority.UseForeColor = False
            '
            'PaymentManagerReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.GroupHeader, Me.GroupFooter, Me.ReportFooter})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.ObjectDataSource})
            Me.DataSource = Me.ObjectDataSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.ObjectDataSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents XrLabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_BankCodeLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_AmountPaid As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_InvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents XrLabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLinePageFooter_Line1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_CheckRunIDLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_AccountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelDetail_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelDetail_AmountPaid As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelDetail_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelDetail_InvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_BankCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_CheckRunID As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_Account As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_PostPeriod As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_PostPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_GLTransaction As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_GLTransactionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_ExportUserID As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_ExportUserIDLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_ChecksDated As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelPageHeader_ChecksDatedLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents XrLabelGroupHeader_CheckNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_CheckAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_CheckNumber As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_CheckAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLineGroupHeader_Line2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLabelGroupHeader_Email As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_Vendor As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_EmailLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupHeader_VendorLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLineGroupHeader_Line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents XrLabelGroupFooter_Total As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelGroupFooter_TotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLineGroupFooter_Line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents ObjectDataSource As DevExpress.DataAccess.ObjectBinding.ObjectDataSource
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents XrLabelReportFooter_GrandTotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabelReportFooter_GrandTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLineReportFooter_Line1 As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
