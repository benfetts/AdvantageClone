Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class OtherCashReceiptBatchReport
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
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PaymentTypeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OfficeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Office = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DescriptionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CashAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Bank = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostPeriodCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTransaction = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DepositDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AdjAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_BankLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DepositDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_StatusLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostingPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTransLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CashAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_Line = New DevExpress.XtraReports.UI.XRLine()
            Me.LineReportFooter_LineThin = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_BatchTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LabelReportFooter_BatchTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceOtherCashReceiptDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailReportOtherCashReceiptDetails = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailOtherCashReceiptDetail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailOtherCashReceiptDetail_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailOtherCashReceiptDetail_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterDetailReportOtherCashReceiptDetails = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupFooter_CheckTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupFooterSeparatorLine_Line = New DevExpress.XtraReports.UI.XRLine()
            Me.Invoice = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupFooterGLTransactionSeparatorLine = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.GroupHeaderGLTransaction = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSourceOtherCashReceiptDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.LabelDetail_PaymentTypeLabel, Me.LabelDetail_OfficeLabel, Me.LabelDetail_Office, Me.LabelDetail_Description, Me.LabelDetail_DescriptionLabel, Me.LabelDetail_Status, Me.LabelDetail_CashAccount, Me.LabelDetail_Bank, Me.LabelDetail_PostPeriodCode, Me.LabelDetail_GLTransaction, Me.LabelDetail_DepositDate, Me.LabelDetail_CheckAmount, Me.LabelDetail_CheckDate, Me.LabelDetail_CheckNumber, Me.LabelDetail_AdjAmountLabel, Me.LabelDetail_GLAccountLabel, Me.LabelDetail_BankLabel, Me.LabelDetail_DepositDateLabel, Me.LabelDetail_CheckAmountLabel, Me.LabelDetail_CheckNumberLabel, Me.LabelDetail_StatusLabel, Me.LabelDetail_CheckDateLabel, Me.LabelDetail_PostingPeriodLabel, Me.LabelDetail_GLTransLabel, Me.LabelDetail_CashAccountLabel})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 140.3338!
            Me.Detail.KeepTogetherWithDetailReports = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PaymentTypeDescription")})
            Me.XrLabel1.Dpi = 100.0!
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(100.0003!, 94.99998!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(306.2496!, 18.99987!)
            Me.XrLabel1.Text = "XrLabel1"
            '
            'LabelDetail_PaymentTypeLabel
            '
            Me.LabelDetail_PaymentTypeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_PaymentTypeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_PaymentTypeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_PaymentTypeLabel.BorderWidth = 1.0!
            Me.LabelDetail_PaymentTypeLabel.CanGrow = False
            Me.LabelDetail_PaymentTypeLabel.Dpi = 100.0!
            Me.LabelDetail_PaymentTypeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_PaymentTypeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_PaymentTypeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 94.99998!)
            Me.LabelDetail_PaymentTypeLabel.Name = "LabelDetail_PaymentTypeLabel"
            Me.LabelDetail_PaymentTypeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PaymentTypeLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_PaymentTypeLabel.SizeF = New System.Drawing.SizeF(99.99998!, 19.0!)
            Me.LabelDetail_PaymentTypeLabel.StylePriority.UseFont = False
            Me.LabelDetail_PaymentTypeLabel.Text = "Payment Type:"
            Me.LabelDetail_PaymentTypeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_OfficeLabel
            '
            Me.LabelDetail_OfficeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_OfficeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_OfficeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_OfficeLabel.BorderWidth = 1.0!
            Me.LabelDetail_OfficeLabel.CanGrow = False
            Me.LabelDetail_OfficeLabel.Dpi = 100.0!
            Me.LabelDetail_OfficeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_OfficeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_OfficeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 75.99996!)
            Me.LabelDetail_OfficeLabel.Name = "LabelDetail_OfficeLabel"
            Me.LabelDetail_OfficeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OfficeLabel.SizeF = New System.Drawing.SizeF(99.99976!, 19.0!)
            Me.LabelDetail_OfficeLabel.StylePriority.UseFont = False
            Me.LabelDetail_OfficeLabel.Text = "Office:"
            Me.LabelDetail_OfficeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Office
            '
            Me.LabelDetail_Office.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Office")})
            Me.LabelDetail_Office.Dpi = 100.0!
            Me.LabelDetail_Office.LocationFloat = New DevExpress.Utils.PointFloat(99.99997!, 76.00008!)
            Me.LabelDetail_Office.Name = "LabelDetail_Office"
            Me.LabelDetail_Office.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Office.SizeF = New System.Drawing.SizeF(306.25!, 18.99991!)
            Me.LabelDetail_Office.Text = "LabelDetail_Office"
            '
            'LabelDetail_Description
            '
            Me.LabelDetail_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.LabelDetail_Description.Dpi = 100.0!
            Me.LabelDetail_Description.LocationFloat = New DevExpress.Utils.PointFloat(525.9112!, 18.99999!)
            Me.LabelDetail_Description.Name = "LabelDetail_Description"
            Me.LabelDetail_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Description.SizeF = New System.Drawing.SizeF(224.0891!, 18.99999!)
            Me.LabelDetail_Description.Text = "LabelDetail_Description"
            '
            'LabelDetail_DescriptionLabel
            '
            Me.LabelDetail_DescriptionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DescriptionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DescriptionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DescriptionLabel.BorderWidth = 1.0!
            Me.LabelDetail_DescriptionLabel.CanGrow = False
            Me.LabelDetail_DescriptionLabel.Dpi = 100.0!
            Me.LabelDetail_DescriptionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DescriptionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DescriptionLabel.LocationFloat = New DevExpress.Utils.PointFloat(421.9113!, 18.99999!)
            Me.LabelDetail_DescriptionLabel.Name = "LabelDetail_DescriptionLabel"
            Me.LabelDetail_DescriptionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DescriptionLabel.SizeF = New System.Drawing.SizeF(103.9998!, 19.0!)
            Me.LabelDetail_DescriptionLabel.StylePriority.UseFont = False
            Me.LabelDetail_DescriptionLabel.Text = "Description:"
            Me.LabelDetail_DescriptionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Status
            '
            Me.LabelDetail_Status.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Status")})
            Me.LabelDetail_Status.Dpi = 100.0!
            Me.LabelDetail_Status.LocationFloat = New DevExpress.Utils.PointFloat(321.9112!, 37.99998!)
            Me.LabelDetail_Status.Name = "LabelDetail_Status"
            Me.LabelDetail_Status.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Status.SizeF = New System.Drawing.SizeF(100.0!, 18.99999!)
            Me.LabelDetail_Status.Text = "LabelDetail_Status"
            '
            'LabelDetail_CashAccount
            '
            Me.LabelDetail_CashAccount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CashAccount")})
            Me.LabelDetail_CashAccount.Dpi = 100.0!
            Me.LabelDetail_CashAccount.LocationFloat = New DevExpress.Utils.PointFloat(525.9112!, 37.99998!)
            Me.LabelDetail_CashAccount.Name = "LabelDetail_CashAccount"
            Me.LabelDetail_CashAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CashAccount.SizeF = New System.Drawing.SizeF(224.0888!, 18.99999!)
            Me.LabelDetail_CashAccount.Text = "LabelDetail_CashAccount"
            '
            'LabelDetail_Bank
            '
            Me.LabelDetail_Bank.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Bank")})
            Me.LabelDetail_Bank.Dpi = 100.0!
            Me.LabelDetail_Bank.LocationFloat = New DevExpress.Utils.PointFloat(100.0002!, 57.0!)
            Me.LabelDetail_Bank.Name = "LabelDetail_Bank"
            Me.LabelDetail_Bank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Bank.SizeF = New System.Drawing.SizeF(306.2497!, 19.0!)
            Me.LabelDetail_Bank.Text = "LabelDetail_Bank"
            '
            'LabelDetail_PostPeriodCode
            '
            Me.LabelDetail_PostPeriodCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.LabelDetail_PostPeriodCode.Dpi = 100.0!
            Me.LabelDetail_PostPeriodCode.LocationFloat = New DevExpress.Utils.PointFloat(525.9112!, 57.0!)
            Me.LabelDetail_PostPeriodCode.Name = "LabelDetail_PostPeriodCode"
            Me.LabelDetail_PostPeriodCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_PostPeriodCode.SizeF = New System.Drawing.SizeF(143.6198!, 18.99998!)
            Me.LabelDetail_PostPeriodCode.Text = "LabelDetail_PostPeriodCode"
            '
            'LabelDetail_GLTransaction
            '
            Me.LabelDetail_GLTransaction.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.LabelDetail_GLTransaction.Dpi = 100.0!
            Me.LabelDetail_GLTransaction.LocationFloat = New DevExpress.Utils.PointFloat(525.911!, 75.99999!)
            Me.LabelDetail_GLTransaction.Name = "LabelDetail_GLTransaction"
            Me.LabelDetail_GLTransaction.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLTransaction.SizeF = New System.Drawing.SizeF(143.6199!, 19.00001!)
            Me.LabelDetail_GLTransaction.Text = "LabelDetail_GLTransaction"
            '
            'LabelDetail_DepositDate
            '
            Me.LabelDetail_DepositDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepositDate", "{0:d}")})
            Me.LabelDetail_DepositDate.Dpi = 100.0!
            Me.LabelDetail_DepositDate.LocationFloat = New DevExpress.Utils.PointFloat(525.9112!, 0!)
            Me.LabelDetail_DepositDate.Name = "LabelDetail_DepositDate"
            Me.LabelDetail_DepositDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DepositDate.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            '
            'LabelDetail_CheckAmount
            '
            Me.LabelDetail_CheckAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount", "{0:n2}")})
            Me.LabelDetail_CheckAmount.Dpi = 100.0!
            Me.LabelDetail_CheckAmount.LocationFloat = New DevExpress.Utils.PointFloat(99.99997!, 37.99998!)
            Me.LabelDetail_CheckAmount.Name = "LabelDetail_CheckAmount"
            Me.LabelDetail_CheckAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckAmount.SizeF = New System.Drawing.SizeF(162.5!, 19.00001!)
            '
            'LabelDetail_CheckDate
            '
            Me.LabelDetail_CheckDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckDate", "{0:d}")})
            Me.LabelDetail_CheckDate.Dpi = 100.0!
            Me.LabelDetail_CheckDate.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 18.99996!)
            Me.LabelDetail_CheckDate.Name = "LabelDetail_CheckDate"
            Me.LabelDetail_CheckDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckDate.SizeF = New System.Drawing.SizeF(71.9948!, 19.0!)
            '
            'LabelDetail_CheckNumber
            '
            Me.LabelDetail_CheckNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckNumber")})
            Me.LabelDetail_CheckNumber.Dpi = 100.0!
            Me.LabelDetail_CheckNumber.LocationFloat = New DevExpress.Utils.PointFloat(99.99997!, 0!)
            Me.LabelDetail_CheckNumber.Name = "LabelDetail_CheckNumber"
            Me.LabelDetail_CheckNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckNumber.SizeF = New System.Drawing.SizeF(306.25!, 18.99999!)
            Me.LabelDetail_CheckNumber.Text = "LabelDetail_CheckNumber"
            '
            'LabelDetail_AdjAmountLabel
            '
            Me.LabelDetail_AdjAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AdjAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AdjAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_AdjAmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_AdjAmountLabel.CanGrow = False
            Me.LabelDetail_AdjAmountLabel.Dpi = 100.0!
            Me.LabelDetail_AdjAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AdjAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AdjAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(425.9115!, 121.3338!)
            Me.LabelDetail_AdjAmountLabel.Name = "LabelDetail_AdjAmountLabel"
            Me.LabelDetail_AdjAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AdjAmountLabel.SizeF = New System.Drawing.SizeF(99.99989!, 19.0!)
            Me.LabelDetail_AdjAmountLabel.StylePriority.UseBorders = False
            Me.LabelDetail_AdjAmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AdjAmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_AdjAmountLabel.Text = "Amount"
            Me.LabelDetail_AdjAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLAccountLabel
            '
            Me.LabelDetail_GLAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_GLAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_GLAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_GLAccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_GLAccountLabel.CanGrow = False
            Me.LabelDetail_GLAccountLabel.Dpi = 100.0!
            Me.LabelDetail_GLAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_GLAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GLAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0005086263!, 121.3337!)
            Me.LabelDetail_GLAccountLabel.Name = "LabelDetail_GLAccountLabel"
            Me.LabelDetail_GLAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GLAccountLabel.SizeF = New System.Drawing.SizeF(79.16656!, 19.0!)
            Me.LabelDetail_GLAccountLabel.StylePriority.UseBorders = False
            Me.LabelDetail_GLAccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_GLAccountLabel.Text = "GL Account"
            Me.LabelDetail_GLAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_BankLabel
            '
            Me.LabelDetail_BankLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_BankLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_BankLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_BankLabel.BorderWidth = 1.0!
            Me.LabelDetail_BankLabel.CanGrow = False
            Me.LabelDetail_BankLabel.Dpi = 100.0!
            Me.LabelDetail_BankLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_BankLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_BankLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0002145767!, 56.99997!)
            Me.LabelDetail_BankLabel.Name = "LabelDetail_BankLabel"
            Me.LabelDetail_BankLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_BankLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_BankLabel.StylePriority.UseFont = False
            Me.LabelDetail_BankLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_BankLabel.Text = "Bank:"
            Me.LabelDetail_BankLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DepositDateLabel
            '
            Me.LabelDetail_DepositDateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DepositDateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DepositDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DepositDateLabel.BorderWidth = 1.0!
            Me.LabelDetail_DepositDateLabel.CanGrow = False
            Me.LabelDetail_DepositDateLabel.Dpi = 100.0!
            Me.LabelDetail_DepositDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DepositDateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DepositDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(422.7867!, 0!)
            Me.LabelDetail_DepositDateLabel.Name = "LabelDetail_DepositDateLabel"
            Me.LabelDetail_DepositDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DepositDateLabel.SizeF = New System.Drawing.SizeF(103.1245!, 19.0!)
            Me.LabelDetail_DepositDateLabel.StylePriority.UseFont = False
            Me.LabelDetail_DepositDateLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_DepositDateLabel.Text = "Deposit Date:"
            Me.LabelDetail_DepositDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CheckAmountLabel
            '
            Me.LabelDetail_CheckAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CheckAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CheckAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CheckAmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_CheckAmountLabel.CanGrow = False
            Me.LabelDetail_CheckAmountLabel.Dpi = 100.0!
            Me.LabelDetail_CheckAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CheckAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CheckAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 37.99998!)
            Me.LabelDetail_CheckAmountLabel.Name = "LabelDetail_CheckAmountLabel"
            Me.LabelDetail_CheckAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CheckAmountLabel.SizeF = New System.Drawing.SizeF(100.0002!, 19.0!)
            Me.LabelDetail_CheckAmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_CheckAmountLabel.Text = "Amount:"
            Me.LabelDetail_CheckAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CheckNumberLabel
            '
            Me.LabelDetail_CheckNumberLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CheckNumberLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CheckNumberLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CheckNumberLabel.BorderWidth = 1.0!
            Me.LabelDetail_CheckNumberLabel.CanGrow = False
            Me.LabelDetail_CheckNumberLabel.Dpi = 100.0!
            Me.LabelDetail_CheckNumberLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CheckNumberLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CheckNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0002145767!, 0!)
            Me.LabelDetail_CheckNumberLabel.Name = "LabelDetail_CheckNumberLabel"
            Me.LabelDetail_CheckNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CheckNumberLabel.SizeF = New System.Drawing.SizeF(99.99991!, 19.0!)
            Me.LabelDetail_CheckNumberLabel.StylePriority.UseFont = False
            Me.LabelDetail_CheckNumberLabel.Text = "Check Number:"
            Me.LabelDetail_CheckNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_StatusLabel
            '
            Me.LabelDetail_StatusLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_StatusLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_StatusLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_StatusLabel.BorderWidth = 1.0!
            Me.LabelDetail_StatusLabel.CanGrow = False
            Me.LabelDetail_StatusLabel.Dpi = 100.0!
            Me.LabelDetail_StatusLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_StatusLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_StatusLabel.LocationFloat = New DevExpress.Utils.PointFloat(277.0!, 37.99998!)
            Me.LabelDetail_StatusLabel.Name = "LabelDetail_StatusLabel"
            Me.LabelDetail_StatusLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_StatusLabel.SizeF = New System.Drawing.SizeF(44.91119!, 19.0!)
            Me.LabelDetail_StatusLabel.StylePriority.UseFont = False
            Me.LabelDetail_StatusLabel.Text = "Status:"
            Me.LabelDetail_StatusLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CheckDateLabel
            '
            Me.LabelDetail_CheckDateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CheckDateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CheckDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CheckDateLabel.BorderWidth = 1.0!
            Me.LabelDetail_CheckDateLabel.CanGrow = False
            Me.LabelDetail_CheckDateLabel.Dpi = 100.0!
            Me.LabelDetail_CheckDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CheckDateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CheckDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 18.99999!)
            Me.LabelDetail_CheckDateLabel.Name = "LabelDetail_CheckDateLabel"
            Me.LabelDetail_CheckDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CheckDateLabel.SizeF = New System.Drawing.SizeF(99.99997!, 19.0!)
            Me.LabelDetail_CheckDateLabel.StylePriority.UseFont = False
            Me.LabelDetail_CheckDateLabel.Text = "Date:"
            Me.LabelDetail_CheckDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_PostingPeriodLabel
            '
            Me.LabelDetail_PostingPeriodLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_PostingPeriodLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_PostingPeriodLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_PostingPeriodLabel.BorderWidth = 1.0!
            Me.LabelDetail_PostingPeriodLabel.CanGrow = False
            Me.LabelDetail_PostingPeriodLabel.Dpi = 100.0!
            Me.LabelDetail_PostingPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_PostingPeriodLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_PostingPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(422.7865!, 56.99999!)
            Me.LabelDetail_PostingPeriodLabel.Name = "LabelDetail_PostingPeriodLabel"
            Me.LabelDetail_PostingPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PostingPeriodLabel.SizeF = New System.Drawing.SizeF(103.1245!, 19.0!)
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
            Me.LabelDetail_GLTransLabel.Dpi = 100.0!
            Me.LabelDetail_GLTransLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_GLTransLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GLTransLabel.LocationFloat = New DevExpress.Utils.PointFloat(422.7863!, 75.99999!)
            Me.LabelDetail_GLTransLabel.Name = "LabelDetail_GLTransLabel"
            Me.LabelDetail_GLTransLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GLTransLabel.SizeF = New System.Drawing.SizeF(103.1247!, 19.0!)
            Me.LabelDetail_GLTransLabel.StylePriority.UseFont = False
            Me.LabelDetail_GLTransLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLTransLabel.Text = "GL Transaction:"
            Me.LabelDetail_GLTransLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_CashAccountLabel
            '
            Me.LabelDetail_CashAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CashAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CashAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CashAccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_CashAccountLabel.CanGrow = False
            Me.LabelDetail_CashAccountLabel.Dpi = 100.0!
            Me.LabelDetail_CashAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CashAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CashAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(422.7867!, 37.99999!)
            Me.LabelDetail_CashAccountLabel.Name = "LabelDetail_CashAccountLabel"
            Me.LabelDetail_CashAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CashAccountLabel.SizeF = New System.Drawing.SizeF(103.1245!, 19.0!)
            Me.LabelDetail_CashAccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_CashAccountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_CashAccountLabel.Text = "Cash Account:"
            Me.LabelDetail_CashAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineReportFooter_Line
            '
            Me.LineReportFooter_Line.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_Line.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_Line.BorderWidth = 0!
            Me.LineReportFooter_Line.Dpi = 100.0!
            Me.LineReportFooter_Line.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_Line.LocationFloat = New DevExpress.Utils.PointFloat(0!, 2.0!)
            Me.LineReportFooter_Line.Name = "LineReportFooter_Line"
            Me.LineReportFooter_Line.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            Me.LineReportFooter_Line.StylePriority.UseBorderColor = False
            Me.LineReportFooter_Line.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_Line.StylePriority.UseForeColor = False
            '
            'LineReportFooter_LineThin
            '
            Me.LineReportFooter_LineThin.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_LineThin.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_LineThin.BorderWidth = 0!
            Me.LineReportFooter_LineThin.Dpi = 100.0!
            Me.LineReportFooter_LineThin.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_LineThin.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0!)
            Me.LineReportFooter_LineThin.Name = "LineReportFooter_LineThin"
            Me.LineReportFooter_LineThin.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            Me.LineReportFooter_LineThin.StylePriority.UseBorderColor = False
            Me.LineReportFooter_LineThin.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_LineThin.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_BatchTotalLabel
            '
            Me.LabelReportFooter_BatchTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_BatchTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_BatchTotalLabel.BorderWidth = 1.0!
            Me.LabelReportFooter_BatchTotalLabel.CanGrow = False
            Me.LabelReportFooter_BatchTotalLabel.Dpi = 100.0!
            Me.LabelReportFooter_BatchTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_BatchTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(321.9112!, 4.000028!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(84.33871!, 19.0!)
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotalLabel.Text = "Batch Total:"
            Me.LabelReportFooter_BatchTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle, Me.LinePageHeader_Bottom})
            Me.PageHeader.Dpi = 100.0!
            Me.PageHeader.HeightF = 54.1667!
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
            Me.LabelPageHeader_Agency.Dpi = 100.0!
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(512.4999!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(237.5001!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.Text = "OtherCash Receipts Batch Report"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4.0!
            Me.LinePageHeader_Top.Dpi = 100.0!
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageHeader_Top.Name = "LinePageHeader_Top"
            Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'LabelPageHeader_ReportCriteria
            '
            Me.LabelPageHeader_ReportCriteria.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportCriteria.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportCriteria.BorderWidth = 1.0!
            Me.LabelPageHeader_ReportCriteria.CanGrow = False
            Me.LabelPageHeader_ReportCriteria.Dpi = 100.0!
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
            Me.LabelPageHeader_ReportTitle.Dpi = 100.0!
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
            Me.LabelPageHeader_ReportTitle.Text = "Other Cash Receipts Batch Report"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4.0!
            Me.LinePageHeader_Bottom.Dpi = 100.0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 50.08335!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_BatchTotal, Me.LineReportFooter_LineThin, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_Line})
            Me.ReportFooter.Dpi = 100.0!
            Me.ReportFooter.HeightF = 39.62504!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_BatchTotal
            '
            Me.LabelReportFooter_BatchTotal.Dpi = 100.0!
            Me.LabelReportFooter_BatchTotal.LocationFloat = New DevExpress.Utils.PointFloat(406.25!, 4.000028!)
            Me.LabelReportFooter_BatchTotal.Name = "LabelReportFooter_BatchTotal"
            Me.LabelReportFooter_BatchTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotal.SizeF = New System.Drawing.SizeF(119.6613!, 19.0!)
            Me.LabelReportFooter_BatchTotal.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceOtherCashReceiptDetails
            '
            Me.BindingSourceOtherCashReceiptDetails.DataSource = GetType(AdvantageFramework.Database.Entities.OtherCashReceiptDetail)
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Dpi = 100.0!
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(614.5417!, 4.083315!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LinePageFooter, Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date, Me.PageInfo_Pages})
            Me.PageFooter.Dpi = 100.0!
            Me.PageFooter.HeightF = 25.08332!
            Me.PageFooter.Name = "PageFooter"
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4.0!
            Me.LinePageFooter.Dpi = 100.0!
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'LabelPageFooter_UserCode
            '
            Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_UserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_UserCode.CanGrow = False
            Me.LabelPageFooter_UserCode.Dpi = 100.0!
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
            Me.LabelPageFooter_Date.Dpi = 100.0!
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
            'DetailReportOtherCashReceiptDetails
            '
            Me.DetailReportOtherCashReceiptDetails.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailOtherCashReceiptDetail, Me.GroupFooterDetailReportOtherCashReceiptDetails})
            Me.DetailReportOtherCashReceiptDetails.DataSource = Me.BindingSourceOtherCashReceiptDetails
            Me.DetailReportOtherCashReceiptDetails.Dpi = 100.0!
            Me.DetailReportOtherCashReceiptDetails.Level = 0
            Me.DetailReportOtherCashReceiptDetails.Name = "DetailReportOtherCashReceiptDetails"
            '
            'DetailOtherCashReceiptDetail
            '
            Me.DetailOtherCashReceiptDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailOtherCashReceiptDetail_Amount, Me.LabelDetailOtherCashReceiptDetail_GLACode})
            Me.DetailOtherCashReceiptDetail.Dpi = 100.0!
            Me.DetailOtherCashReceiptDetail.HeightF = 19.0!
            Me.DetailOtherCashReceiptDetail.Name = "DetailOtherCashReceiptDetail"
            '
            'LabelDetailOtherCashReceiptDetail_Amount
            '
            Me.LabelDetailOtherCashReceiptDetail_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.LabelDetailOtherCashReceiptDetail_Amount.Dpi = 100.0!
            Me.LabelDetailOtherCashReceiptDetail_Amount.LocationFloat = New DevExpress.Utils.PointFloat(425.9111!, 0!)
            Me.LabelDetailOtherCashReceiptDetail_Amount.Name = "LabelDetailOtherCashReceiptDetail_Amount"
            Me.LabelDetailOtherCashReceiptDetail_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOtherCashReceiptDetail_Amount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetailOtherCashReceiptDetail_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetailOtherCashReceiptDetail_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailOtherCashReceiptDetail_GLACode
            '
            Me.LabelDetailOtherCashReceiptDetail_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetailOtherCashReceiptDetail_GLACode.Dpi = 100.0!
            Me.LabelDetailOtherCashReceiptDetail_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(0.0002145767!, 0!)
            Me.LabelDetailOtherCashReceiptDetail_GLACode.Name = "LabelDetailOtherCashReceiptDetail_GLACode"
            Me.LabelDetailOtherCashReceiptDetail_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOtherCashReceiptDetail_GLACode.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetailOtherCashReceiptDetail_GLACode.Text = "LabelDetailOtherCashReceiptDetail_GLACode"
            '
            'GroupFooterDetailReportOtherCashReceiptDetails
            '
            Me.GroupFooterDetailReportOtherCashReceiptDetails.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.XrLine1, Me.LabelGroupFooter_CheckTotal, Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal})
            Me.GroupFooterDetailReportOtherCashReceiptDetails.Dpi = 100.0!
            Me.GroupFooterDetailReportOtherCashReceiptDetails.HeightF = 29.0!
            Me.GroupFooterDetailReportOtherCashReceiptDetails.Name = "GroupFooterDetailReportOtherCashReceiptDetails"
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Black
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 0!
            Me.XrLine2.Dpi = 100.0!
            Me.XrLine2.ForeColor = System.Drawing.Color.Gray
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 27.0!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            Me.XrLine2.StylePriority.UseBorderColor = False
            Me.XrLine2.StylePriority.UseBorderWidth = False
            Me.XrLine2.StylePriority.UseForeColor = False
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 0!
            Me.XrLine1.Dpi = 100.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Gray
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.0!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            Me.XrLine1.StylePriority.UseBorderColor = False
            Me.XrLine1.StylePriority.UseBorderWidth = False
            Me.XrLine1.StylePriority.UseForeColor = False
            '
            'LabelGroupFooter_CheckTotal
            '
            Me.LabelGroupFooter_CheckTotal.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooter_CheckTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.LabelGroupFooter_CheckTotal.Dpi = 100.0!
            Me.LabelGroupFooter_CheckTotal.LocationFloat = New DevExpress.Utils.PointFloat(406.25!, 0!)
            Me.LabelGroupFooter_CheckTotal.Name = "LabelGroupFooter_CheckTotal"
            Me.LabelGroupFooter_CheckTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_CheckTotal.SizeF = New System.Drawing.SizeF(119.6612!, 19.0!)
            Me.LabelGroupFooter_CheckTotal.StylePriority.UseBorders = False
            Me.LabelGroupFooter_CheckTotal.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooter_CheckTotal.Summary = XrSummary1
            Me.LabelGroupFooter_CheckTotal.Text = "LabelDetailOtherCashReceiptDetail_Amount"
            Me.LabelGroupFooter_CheckTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterClientCashReceiptDetail_CheckTotal
            '
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.BorderWidth = 1.0!
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.CanGrow = False
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Dpi = 100.0!
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.LocationFloat = New DevExpress.Utils.PointFloat(321.9112!, 0!)
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Name = "LabelGroupFooterClientCashReceiptDetail_CheckTotal"
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.SizeF = New System.Drawing.SizeF(84.33881!, 19.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.StylePriority.UseBorders = False
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.StylePriority.UseFont = False
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Text = "Check Total:"
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineGroupFooterSeparatorLine_Line
            '
            Me.LineGroupFooterSeparatorLine_Line.BorderColor = System.Drawing.Color.Silver
            Me.LineGroupFooterSeparatorLine_Line.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooterSeparatorLine_Line.BorderWidth = 4.0!
            Me.LineGroupFooterSeparatorLine_Line.Dpi = 100.0!
            Me.LineGroupFooterSeparatorLine_Line.ForeColor = System.Drawing.Color.Silver
            Me.LineGroupFooterSeparatorLine_Line.LineWidth = 4
            Me.LineGroupFooterSeparatorLine_Line.LocationFloat = New DevExpress.Utils.PointFloat(0.0002145767!, 0!)
            Me.LineGroupFooterSeparatorLine_Line.Name = "LineGroupFooterSeparatorLine_Line"
            Me.LineGroupFooterSeparatorLine_Line.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'Invoice
            '
            Me.Invoice.Expression = "PadLeft([ARInvoiceNumber], 6, '0') + '-' + PadLeft([ARInvoiceSequenceNumber], 3, " &
    "'0')"
            Me.Invoice.Name = "Invoice"
            '
            'GroupFooterGLTransactionSeparatorLine
            '
            Me.GroupFooterGLTransactionSeparatorLine.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineGroupFooterSeparatorLine_Line})
            Me.GroupFooterGLTransactionSeparatorLine.Dpi = 100.0!
            Me.GroupFooterGLTransactionSeparatorLine.HeightF = 19.70838!
            Me.GroupFooterGLTransactionSeparatorLine.Name = "GroupFooterGLTransactionSeparatorLine"
            '
            'GroupHeaderGLTransaction
            '
            Me.GroupHeaderGLTransaction.Dpi = 100.0!
            Me.GroupHeaderGLTransaction.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLTransaction", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderGLTransaction.HeightF = 0!
            Me.GroupHeaderGLTransaction.Name = "GroupHeaderGLTransaction"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.CashReceipts.Classes.OtherCashReceiptBatchReport)
            '
            'OtherCashReceiptBatchReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.DetailReportOtherCashReceiptDetails, Me.GroupFooterGLTransactionSeparatorLine, Me.GroupHeaderGLTransaction})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Invoice})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.BindingSourceOtherCashReceiptDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_CheckNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CheckDateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GLTransLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_PostingPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_StatusLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CashAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelDetail_CheckAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_BankLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DepositDateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_BatchTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_LineThin As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineReportFooter_Line As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AdjAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GLAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportOtherCashReceiptDetails As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailOtherCashReceiptDetail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents Invoice As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents LabelGroupFooterClientCashReceiptDetail_CheckTotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupFooterSeparatorLine_Line As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents BindingSourceOtherCashReceiptDetails As System.Windows.Forms.BindingSource
        Friend WithEvents LabelDetail_CheckAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CheckDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CheckNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DepositDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterGLTransactionSeparatorLine As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelDetail_CashAccount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Bank As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PostPeriodCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLTransaction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderGLTransaction As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterDetailReportOtherCashReceiptDetails As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelDetail_Status As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DescriptionLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailOtherCashReceiptDetail_Amount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailOtherCashReceiptDetail_GLACode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_OfficeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Office As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_CheckTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_BatchTotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelDetail_PaymentTypeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
