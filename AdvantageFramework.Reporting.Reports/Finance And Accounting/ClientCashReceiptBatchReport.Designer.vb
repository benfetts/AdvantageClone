Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ClientCashReceiptBatchReport
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
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetail_PaymentTypeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DepositDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OnAccountAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OnAccountAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OnAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AdjustmentLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineDetail_Break = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelDetail_AdjAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AdjAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PaymentLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ARAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_BankLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DepositDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientLabel = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.LabelReportFooter_SumChecks = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_Adjustments = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumAdjustments = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceClientCashReceiptDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.LabelReportFooter_SumOnAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceClientCashReceiptOnAccount = New System.Windows.Forms.BindingSource(Me.components)
            Me.LabelReportFooter_Checks = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_OnAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumPayments = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_Payments = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailReportClientCashReceiptOnAccounts = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailOnAccount = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailOnAccount_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailReportClientCashReceiptDetails = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailClientCashReceiptDetail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailClientCashReceipt_AdjustmentAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailClientCashReceipt_AdjustmentAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailClientCashReceipt_Payment = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailClientCashReceipt_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailClientCashReceipt_Invoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailClientCashReceipt_ARAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterDetailReportClientCashReceiptDetails = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterDetailReportClientCashReceiptDetailPayments = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.Invoice = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupFooterGLTransactionIntercompanyTransactions = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.GroupHeaderGLTransaction = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupFooterGLTransaction = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.Subreport_PartialPaymentDetailSubreport = New DevExpress.XtraReports.UI.XRSubreport()
            Me.Subreport_TransactionSubreport = New DevExpress.XtraReports.UI.XRSubreport()
            CType(Me.BindingSourceClientCashReceiptDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceClientCashReceiptOnAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_PaymentTypeLabel, Me.XrLabel7, Me.LabelDetail_Status, Me.XrLabel5, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.LabelDetail_DepositDate, Me.LabelDetail_CheckAmount, Me.LabelDetail_CheckDate, Me.LabelDetail_CheckNumber, Me.LabelDetail_OnAccountAccountLabel, Me.LabelDetail_OnAccountAmountLabel, Me.LabelDetail_OnAccountLabel, Me.LabelDetail_AdjustmentLabel, Me.LineDetail_Break, Me.LabelDetail_AdjAmountLabel, Me.LabelDetail_AdjAccountLabel, Me.LabelDetail_PaymentLabel, Me.LabelDetail_DateLabel, Me.LabelDetail_InvoiceLabel, Me.LabelDetail_ARAccountLabel, Me.LabelDetail_BankLabel, Me.LabelDetail_DepositDateLabel, Me.LabelDetail_CheckAmountLabel, Me.LabelDetail_ClientLabel, Me.LabelDetail_CheckNumberLabel, Me.LabelDetail_StatusLabel, Me.LabelDetail_CheckDateLabel, Me.LabelDetail_PostingPeriodLabel, Me.LabelDetail_GLTransLabel, Me.LabelDetail_CashAccountLabel})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 169.1253!
            Me.Detail.KeepTogetherWithDetailReports = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.LabelDetail_PaymentTypeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 95.00002!)
            Me.LabelDetail_PaymentTypeLabel.Name = "LabelDetail_PaymentTypeLabel"
            Me.LabelDetail_PaymentTypeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PaymentTypeLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_PaymentTypeLabel.SizeF = New System.Drawing.SizeF(99.99998!, 19.0!)
            Me.LabelDetail_PaymentTypeLabel.StylePriority.UseFont = False
            Me.LabelDetail_PaymentTypeLabel.Text = "Payment Type:"
            Me.LabelDetail_PaymentTypeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel7
            '
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PaymentTypeDescription")})
            Me.XrLabel7.Dpi = 100.0!
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(100.0004!, 95.00014!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(313.4471!, 18.99987!)
            Me.XrLabel7.Text = "XrLabel1"
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
            'XrLabel5
            '
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CashAccount")})
            Me.XrLabel5.Dpi = 100.0!
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(525.9112!, 37.99998!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(224.0888!, 18.99999!)
            Me.XrLabel5.Text = "XrLabel5"
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Bank")})
            Me.XrLabel4.Dpi = 100.0!
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(525.9112!, 18.99999!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(224.0888!, 19.0!)
            Me.XrLabel4.Text = "XrLabel4"
            '
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.XrLabel3.Dpi = 100.0!
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(525.9112!, 57.0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(143.6198!, 18.99998!)
            Me.XrLabel3.Text = "XrLabel3"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.XrLabel2.Dpi = 100.0!
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(525.911!, 75.99999!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(143.6199!, 19.00001!)
            Me.XrLabel2.Text = "XrLabel2"
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Client")})
            Me.XrLabel1.Dpi = 100.0!
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(313.4474!, 19.0!)
            Me.XrLabel1.Text = "XrLabel1"
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
            Me.LabelDetail_CheckAmount.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 75.99999!)
            Me.LabelDetail_CheckAmount.Name = "LabelDetail_CheckAmount"
            Me.LabelDetail_CheckAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckAmount.SizeF = New System.Drawing.SizeF(162.5!, 19.00001!)
            '
            'LabelDetail_CheckDate
            '
            Me.LabelDetail_CheckDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckDate", "{0:d}")})
            Me.LabelDetail_CheckDate.Dpi = 100.0!
            Me.LabelDetail_CheckDate.LocationFloat = New DevExpress.Utils.PointFloat(99.99997!, 56.99997!)
            Me.LabelDetail_CheckDate.Name = "LabelDetail_CheckDate"
            Me.LabelDetail_CheckDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckDate.SizeF = New System.Drawing.SizeF(118.8698!, 19.00001!)
            '
            'LabelDetail_CheckNumber
            '
            Me.LabelDetail_CheckNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckNumber")})
            Me.LabelDetail_CheckNumber.Dpi = 100.0!
            Me.LabelDetail_CheckNumber.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 37.99998!)
            Me.LabelDetail_CheckNumber.Name = "LabelDetail_CheckNumber"
            Me.LabelDetail_CheckNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckNumber.SizeF = New System.Drawing.SizeF(162.5!, 18.99999!)
            Me.LabelDetail_CheckNumber.Text = "LabelDetail_CheckNumber"
            '
            'LabelDetail_OnAccountAccountLabel
            '
            Me.LabelDetail_OnAccountAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_OnAccountAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_OnAccountAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_OnAccountAccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_OnAccountAccountLabel.CanGrow = False
            Me.LabelDetail_OnAccountAccountLabel.Dpi = 100.0!
            Me.LabelDetail_OnAccountAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_OnAccountAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_OnAccountAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(539.3752!, 150.1253!)
            Me.LabelDetail_OnAccountAccountLabel.Name = "LabelDetail_OnAccountAccountLabel"
            Me.LabelDetail_OnAccountAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OnAccountAccountLabel.SizeF = New System.Drawing.SizeF(99.99989!, 19.0!)
            Me.LabelDetail_OnAccountAccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_OnAccountAccountLabel.Text = "Account"
            Me.LabelDetail_OnAccountAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_OnAccountAmountLabel
            '
            Me.LabelDetail_OnAccountAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_OnAccountAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_OnAccountAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_OnAccountAmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_OnAccountAmountLabel.CanGrow = False
            Me.LabelDetail_OnAccountAmountLabel.Dpi = 100.0!
            Me.LabelDetail_OnAccountAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_OnAccountAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_OnAccountAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(639.3752!, 150.1253!)
            Me.LabelDetail_OnAccountAmountLabel.Name = "LabelDetail_OnAccountAmountLabel"
            Me.LabelDetail_OnAccountAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OnAccountAmountLabel.SizeF = New System.Drawing.SizeF(99.99989!, 19.0!)
            Me.LabelDetail_OnAccountAmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_OnAccountAmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_OnAccountAmountLabel.Text = "Amount"
            Me.LabelDetail_OnAccountAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_OnAccountLabel
            '
            Me.LabelDetail_OnAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_OnAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_OnAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_OnAccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_OnAccountLabel.CanGrow = False
            Me.LabelDetail_OnAccountLabel.Dpi = 100.0!
            Me.LabelDetail_OnAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_OnAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_OnAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(539.3752!, 130.125!)
            Me.LabelDetail_OnAccountLabel.Name = "LabelDetail_OnAccountLabel"
            Me.LabelDetail_OnAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OnAccountLabel.SizeF = New System.Drawing.SizeF(199.9998!, 18.99999!)
            Me.LabelDetail_OnAccountLabel.StylePriority.UseBorders = False
            Me.LabelDetail_OnAccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_OnAccountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_OnAccountLabel.Text = "On Account"
            Me.LabelDetail_OnAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'LabelDetail_AdjustmentLabel
            '
            Me.LabelDetail_AdjustmentLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AdjustmentLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AdjustmentLabel.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_AdjustmentLabel.BorderWidth = 1.0!
            Me.LabelDetail_AdjustmentLabel.CanGrow = False
            Me.LabelDetail_AdjustmentLabel.Dpi = 100.0!
            Me.LabelDetail_AdjustmentLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AdjustmentLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AdjustmentLabel.LocationFloat = New DevExpress.Utils.PointFloat(325.9115!, 130.125!)
            Me.LabelDetail_AdjustmentLabel.Name = "LabelDetail_AdjustmentLabel"
            Me.LabelDetail_AdjustmentLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AdjustmentLabel.SizeF = New System.Drawing.SizeF(199.9998!, 18.99999!)
            Me.LabelDetail_AdjustmentLabel.StylePriority.UseBorders = False
            Me.LabelDetail_AdjustmentLabel.StylePriority.UseFont = False
            Me.LabelDetail_AdjustmentLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_AdjustmentLabel.Text = "Adjustment"
            Me.LabelDetail_AdjustmentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'LineDetail_Break
            '
            Me.LineDetail_Break.BorderColor = System.Drawing.Color.Silver
            Me.LineDetail_Break.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineDetail_Break.BorderWidth = 1.0!
            Me.LineDetail_Break.Dpi = 100.0!
            Me.LineDetail_Break.ForeColor = System.Drawing.Color.Silver
            Me.LineDetail_Break.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 125.6251!)
            Me.LineDetail_Break.Name = "LineDetail_Break"
            Me.LineDetail_Break.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            Me.LineDetail_Break.StylePriority.UseBorderWidth = False
            '
            'LabelDetail_AdjAmountLabel
            '
            Me.LabelDetail_AdjAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AdjAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AdjAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AdjAmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_AdjAmountLabel.CanGrow = False
            Me.LabelDetail_AdjAmountLabel.Dpi = 100.0!
            Me.LabelDetail_AdjAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AdjAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AdjAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(425.9113!, 150.1253!)
            Me.LabelDetail_AdjAmountLabel.Name = "LabelDetail_AdjAmountLabel"
            Me.LabelDetail_AdjAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AdjAmountLabel.SizeF = New System.Drawing.SizeF(99.99989!, 19.0!)
            Me.LabelDetail_AdjAmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AdjAmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_AdjAmountLabel.Text = "Amount"
            Me.LabelDetail_AdjAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_AdjAccountLabel
            '
            Me.LabelDetail_AdjAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AdjAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AdjAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AdjAccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_AdjAccountLabel.CanGrow = False
            Me.LabelDetail_AdjAccountLabel.Dpi = 100.0!
            Me.LabelDetail_AdjAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AdjAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AdjAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(325.9115!, 150.1253!)
            Me.LabelDetail_AdjAccountLabel.Name = "LabelDetail_AdjAccountLabel"
            Me.LabelDetail_AdjAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AdjAccountLabel.SizeF = New System.Drawing.SizeF(99.99989!, 19.0!)
            Me.LabelDetail_AdjAccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AdjAccountLabel.Text = "Account"
            Me.LabelDetail_AdjAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_PaymentLabel
            '
            Me.LabelDetail_PaymentLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_PaymentLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_PaymentLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_PaymentLabel.BorderWidth = 1.0!
            Me.LabelDetail_PaymentLabel.CanGrow = False
            Me.LabelDetail_PaymentLabel.Dpi = 100.0!
            Me.LabelDetail_PaymentLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_PaymentLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_PaymentLabel.LocationFloat = New DevExpress.Utils.PointFloat(218.8699!, 150.1252!)
            Me.LabelDetail_PaymentLabel.Name = "LabelDetail_PaymentLabel"
            Me.LabelDetail_PaymentLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PaymentLabel.SizeF = New System.Drawing.SizeF(101.0415!, 19.0!)
            Me.LabelDetail_PaymentLabel.StylePriority.UseFont = False
            Me.LabelDetail_PaymentLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_PaymentLabel.Text = "Payment"
            Me.LabelDetail_PaymentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_DateLabel
            '
            Me.LabelDetail_DateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateLabel.BorderWidth = 1.0!
            Me.LabelDetail_DateLabel.CanGrow = False
            Me.LabelDetail_DateLabel.Dpi = 100.0!
            Me.LabelDetail_DateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.LocationFloat = New DevExpress.Utils.PointFloat(151.1616!, 150.1253!)
            Me.LabelDetail_DateLabel.Name = "LabelDetail_DateLabel"
            Me.LabelDetail_DateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateLabel.SizeF = New System.Drawing.SizeF(67.7084!, 18.99998!)
            Me.LabelDetail_DateLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateLabel.Text = "Date"
            Me.LabelDetail_DateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceLabel
            '
            Me.LabelDetail_InvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InvoiceLabel.BorderWidth = 1.0!
            Me.LabelDetail_InvoiceLabel.CanGrow = False
            Me.LabelDetail_InvoiceLabel.Dpi = 100.0!
            Me.LabelDetail_InvoiceLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_InvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(79.16705!, 150.1252!)
            Me.LabelDetail_InvoiceLabel.Name = "LabelDetail_InvoiceLabel"
            Me.LabelDetail_InvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceLabel.SizeF = New System.Drawing.SizeF(71.99457!, 19.0!)
            Me.LabelDetail_InvoiceLabel.StylePriority.UseFont = False
            Me.LabelDetail_InvoiceLabel.Text = "Invoice"
            Me.LabelDetail_InvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ARAccountLabel
            '
            Me.LabelDetail_ARAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ARAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ARAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ARAccountLabel.BorderWidth = 1.0!
            Me.LabelDetail_ARAccountLabel.CanGrow = False
            Me.LabelDetail_ARAccountLabel.Dpi = 100.0!
            Me.LabelDetail_ARAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ARAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ARAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 150.1252!)
            Me.LabelDetail_ARAccountLabel.Name = "LabelDetail_ARAccountLabel"
            Me.LabelDetail_ARAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ARAccountLabel.SizeF = New System.Drawing.SizeF(79.16656!, 19.0!)
            Me.LabelDetail_ARAccountLabel.StylePriority.UseFont = False
            Me.LabelDetail_ARAccountLabel.Text = "A/R Account"
            Me.LabelDetail_ARAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.LabelDetail_BankLabel.LocationFloat = New DevExpress.Utils.PointFloat(422.7867!, 18.99999!)
            Me.LabelDetail_BankLabel.Name = "LabelDetail_BankLabel"
            Me.LabelDetail_BankLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_BankLabel.SizeF = New System.Drawing.SizeF(103.0!, 19.0!)
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
            Me.LabelDetail_DepositDateLabel.SizeF = New System.Drawing.SizeF(103.0!, 19.0!)
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
            Me.LabelDetail_CheckAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 75.99996!)
            Me.LabelDetail_CheckAmountLabel.Name = "LabelDetail_CheckAmountLabel"
            Me.LabelDetail_CheckAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CheckAmountLabel.SizeF = New System.Drawing.SizeF(99.99984!, 19.0!)
            Me.LabelDetail_CheckAmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_CheckAmountLabel.Text = "Amount:"
            Me.LabelDetail_CheckAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ClientLabel
            '
            Me.LabelDetail_ClientLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ClientLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ClientLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ClientLabel.BorderWidth = 1.0!
            Me.LabelDetail_ClientLabel.CanGrow = False
            Me.LabelDetail_ClientLabel.Dpi = 100.0!
            Me.LabelDetail_ClientLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ClientLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_ClientLabel.Name = "LabelDetail_ClientLabel"
            Me.LabelDetail_ClientLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ClientLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_ClientLabel.StylePriority.UseFont = False
            Me.LabelDetail_ClientLabel.Text = "Client:"
            Me.LabelDetail_ClientLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.LabelDetail_CheckNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 37.99998!)
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
            Me.LabelDetail_CheckDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 56.99997!)
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
            Me.LabelDetail_PostingPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(422.7865!, 56.99997!)
            Me.LabelDetail_PostingPeriodLabel.Name = "LabelDetail_PostingPeriodLabel"
            Me.LabelDetail_PostingPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PostingPeriodLabel.SizeF = New System.Drawing.SizeF(103.0003!, 18.99999!)
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
            Me.LabelDetail_GLTransLabel.SizeF = New System.Drawing.SizeF(103.0005!, 19.0!)
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
            Me.LabelDetail_CashAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(422.7867!, 37.99998!)
            Me.LabelDetail_CashAccountLabel.Name = "LabelDetail_CashAccountLabel"
            Me.LabelDetail_CashAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CashAccountLabel.SizeF = New System.Drawing.SizeF(103.0001!, 19.0!)
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
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 7.374954!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(79.16654!, 19.0!)
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle})
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
            Me.LabelPageHeader_Agency.Text = "Client Cash Receipts Batch Report"
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
            Me.LabelPageHeader_ReportTitle.Text = "Client Cash Receipts Batch Report"
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
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_SumChecks, Me.LabelReportFooter_Adjustments, Me.LabelReportFooter_SumAdjustments, Me.LabelReportFooter_SumOnAccount, Me.LabelReportFooter_Checks, Me.LabelReportFooter_OnAccount, Me.LabelReportFooter_SumPayments, Me.LabelReportFooter_Payments, Me.LineReportFooter_LineThin, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_Line})
            Me.ReportFooter.Dpi = 100.0!
            Me.ReportFooter.HeightF = 83.37495!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_SumChecks
            '
            Me.LabelReportFooter_SumChecks.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelReportFooter_SumChecks.Dpi = 100.0!
            Me.LabelReportFooter_SumChecks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_SumChecks.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 45.37487!)
            Me.LabelReportFooter_SumChecks.Name = "LabelReportFooter_SumChecks"
            Me.LabelReportFooter_SumChecks.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumChecks.SizeF = New System.Drawing.SizeF(119.9111!, 19.00003!)
            Me.LabelReportFooter_SumChecks.StylePriority.UseBorders = False
            Me.LabelReportFooter_SumChecks.StylePriority.UseFont = False
            Me.LabelReportFooter_SumChecks.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.IgnoreNullValues = True
            Me.LabelReportFooter_SumChecks.Summary = XrSummary1
            Me.LabelReportFooter_SumChecks.Text = "{}"
            Me.LabelReportFooter_SumChecks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_Adjustments
            '
            Me.LabelReportFooter_Adjustments.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_Adjustments.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_Adjustments.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_Adjustments.BorderWidth = 1.0!
            Me.LabelReportFooter_Adjustments.CanGrow = False
            Me.LabelReportFooter_Adjustments.Dpi = 100.0!
            Me.LabelReportFooter_Adjustments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_Adjustments.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_Adjustments.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 64.37495!)
            Me.LabelReportFooter_Adjustments.Name = "LabelReportFooter_Adjustments"
            Me.LabelReportFooter_Adjustments.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_Adjustments.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelReportFooter_Adjustments.StylePriority.UseFont = False
            Me.LabelReportFooter_Adjustments.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_Adjustments.Text = "Adjustments:"
            Me.LabelReportFooter_Adjustments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SumAdjustments
            '
            Me.LabelReportFooter_SumAdjustments.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelReportFooter_SumAdjustments.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSourceClientCashReceiptDetails, "AdjustmentAmount", "{0:n2}")})
            Me.LabelReportFooter_SumAdjustments.Dpi = 100.0!
            Me.LabelReportFooter_SumAdjustments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_SumAdjustments.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 64.37492!)
            Me.LabelReportFooter_SumAdjustments.Name = "LabelReportFooter_SumAdjustments"
            Me.LabelReportFooter_SumAdjustments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumAdjustments.SizeF = New System.Drawing.SizeF(119.9112!, 19.00001!)
            Me.LabelReportFooter_SumAdjustments.StylePriority.UseBorders = False
            Me.LabelReportFooter_SumAdjustments.StylePriority.UseFont = False
            Me.LabelReportFooter_SumAdjustments.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.IgnoreNullValues = True
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumAdjustments.Summary = XrSummary2
            Me.LabelReportFooter_SumAdjustments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceClientCashReceiptDetails
            '
            Me.BindingSourceClientCashReceiptDetails.DataSource = GetType(AdvantageFramework.Database.Entities.ClientCashReceiptDetail)
            '
            'LabelReportFooter_SumOnAccount
            '
            Me.LabelReportFooter_SumOnAccount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSourceClientCashReceiptOnAccount, "Amount", "{0:n2}")})
            Me.LabelReportFooter_SumOnAccount.Dpi = 100.0!
            Me.LabelReportFooter_SumOnAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_SumOnAccount.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 26.37494!)
            Me.LabelReportFooter_SumOnAccount.Name = "LabelReportFooter_SumOnAccount"
            Me.LabelReportFooter_SumOnAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumOnAccount.SizeF = New System.Drawing.SizeF(119.9111!, 19.0!)
            Me.LabelReportFooter_SumOnAccount.StylePriority.UseFont = False
            Me.LabelReportFooter_SumOnAccount.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.IgnoreNullValues = True
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumOnAccount.Summary = XrSummary3
            Me.LabelReportFooter_SumOnAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSourceClientCashReceiptOnAccount
            '
            Me.BindingSourceClientCashReceiptOnAccount.DataSource = GetType(AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount)
            '
            'LabelReportFooter_Checks
            '
            Me.LabelReportFooter_Checks.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_Checks.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_Checks.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_Checks.BorderWidth = 1.0!
            Me.LabelReportFooter_Checks.CanGrow = False
            Me.LabelReportFooter_Checks.Dpi = 100.0!
            Me.LabelReportFooter_Checks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_Checks.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_Checks.LocationFloat = New DevExpress.Utils.PointFloat(99.99998!, 45.37495!)
            Me.LabelReportFooter_Checks.Name = "LabelReportFooter_Checks"
            Me.LabelReportFooter_Checks.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_Checks.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelReportFooter_Checks.StylePriority.UseFont = False
            Me.LabelReportFooter_Checks.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_Checks.Text = "Checks:"
            Me.LabelReportFooter_Checks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_OnAccount
            '
            Me.LabelReportFooter_OnAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_OnAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_OnAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_OnAccount.BorderWidth = 1.0!
            Me.LabelReportFooter_OnAccount.CanGrow = False
            Me.LabelReportFooter_OnAccount.Dpi = 100.0!
            Me.LabelReportFooter_OnAccount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_OnAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_OnAccount.LocationFloat = New DevExpress.Utils.PointFloat(99.99997!, 26.37494!)
            Me.LabelReportFooter_OnAccount.Name = "LabelReportFooter_OnAccount"
            Me.LabelReportFooter_OnAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_OnAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelReportFooter_OnAccount.StylePriority.UseFont = False
            Me.LabelReportFooter_OnAccount.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_OnAccount.Text = "On Account:"
            Me.LabelReportFooter_OnAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SumPayments
            '
            Me.LabelReportFooter_SumPayments.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_SumPayments.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.BindingSourceClientCashReceiptDetails, "PaymentAmount", "{0:n2}")})
            Me.LabelReportFooter_SumPayments.Dpi = 100.0!
            Me.LabelReportFooter_SumPayments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_SumPayments.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 7.374954!)
            Me.LabelReportFooter_SumPayments.Name = "LabelReportFooter_SumPayments"
            Me.LabelReportFooter_SumPayments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumPayments.SizeF = New System.Drawing.SizeF(119.9112!, 18.99999!)
            Me.LabelReportFooter_SumPayments.StylePriority.UseBorders = False
            Me.LabelReportFooter_SumPayments.StylePriority.UseFont = False
            Me.LabelReportFooter_SumPayments.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.IgnoreNullValues = True
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumPayments.Summary = XrSummary4
            Me.LabelReportFooter_SumPayments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_Payments
            '
            Me.LabelReportFooter_Payments.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_Payments.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_Payments.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_Payments.BorderWidth = 1.0!
            Me.LabelReportFooter_Payments.CanGrow = False
            Me.LabelReportFooter_Payments.Dpi = 100.0!
            Me.LabelReportFooter_Payments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_Payments.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_Payments.LocationFloat = New DevExpress.Utils.PointFloat(99.99998!, 7.374954!)
            Me.LabelReportFooter_Payments.Name = "LabelReportFooter_Payments"
            Me.LabelReportFooter_Payments.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_Payments.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelReportFooter_Payments.StylePriority.UseFont = False
            Me.LabelReportFooter_Payments.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_Payments.Text = "Payments:"
            Me.LabelReportFooter_Payments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            'DetailReportClientCashReceiptOnAccounts
            '
            Me.DetailReportClientCashReceiptOnAccounts.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailOnAccount})
            Me.DetailReportClientCashReceiptOnAccounts.DataSource = Me.BindingSourceClientCashReceiptOnAccount
            Me.DetailReportClientCashReceiptOnAccounts.Dpi = 100.0!
            Me.DetailReportClientCashReceiptOnAccounts.Level = 0
            Me.DetailReportClientCashReceiptOnAccounts.Name = "DetailReportClientCashReceiptOnAccounts"
            '
            'DetailOnAccount
            '
            Me.DetailOnAccount.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel6, Me.LabelDetailOnAccount_Amount})
            Me.DetailOnAccount.Dpi = 100.0!
            Me.DetailOnAccount.HeightF = 19.0!
            Me.DetailOnAccount.Name = "DetailOnAccount"
            '
            'XrLabel6
            '
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeOnAccount")})
            Me.XrLabel6.Dpi = 100.0!
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(539.3748!, 0!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.XrLabel6.Text = "XrLabel6"
            '
            'LabelDetailOnAccount_Amount
            '
            Me.LabelDetailOnAccount_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.LabelDetailOnAccount_Amount.Dpi = 100.0!
            Me.LabelDetailOnAccount_Amount.LocationFloat = New DevExpress.Utils.PointFloat(639.3748!, 0!)
            Me.LabelDetailOnAccount_Amount.Name = "LabelDetailOnAccount_Amount"
            Me.LabelDetailOnAccount_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailOnAccount_Amount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetailOnAccount_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetailOnAccount_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'DetailReportClientCashReceiptDetails
            '
            Me.DetailReportClientCashReceiptDetails.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailClientCashReceiptDetail, Me.GroupFooterDetailReportClientCashReceiptDetails, Me.GroupFooterDetailReportClientCashReceiptDetailPayments})
            Me.DetailReportClientCashReceiptDetails.DataSource = Me.BindingSourceClientCashReceiptDetails
            Me.DetailReportClientCashReceiptDetails.Dpi = 100.0!
            Me.DetailReportClientCashReceiptDetails.Level = 1
            Me.DetailReportClientCashReceiptDetails.Name = "DetailReportClientCashReceiptDetails"
            '
            'DetailClientCashReceiptDetail
            '
            Me.DetailClientCashReceiptDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailClientCashReceipt_AdjustmentAmount, Me.LabelDetailClientCashReceipt_AdjustmentAccount, Me.LabelDetailClientCashReceipt_Payment, Me.LabelDetailClientCashReceipt_Date, Me.LabelDetailClientCashReceipt_Invoice, Me.LabelDetailClientCashReceipt_ARAccount})
            Me.DetailClientCashReceiptDetail.Dpi = 100.0!
            Me.DetailClientCashReceiptDetail.HeightF = 19.0!
            Me.DetailClientCashReceiptDetail.Name = "DetailClientCashReceiptDetail"
            '
            'LabelDetailClientCashReceipt_AdjustmentAmount
            '
            Me.LabelDetailClientCashReceipt_AdjustmentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdjustmentAmount", "{0:n2}")})
            Me.LabelDetailClientCashReceipt_AdjustmentAmount.Dpi = 100.0!
            Me.LabelDetailClientCashReceipt_AdjustmentAmount.LocationFloat = New DevExpress.Utils.PointFloat(425.9113!, 0!)
            Me.LabelDetailClientCashReceipt_AdjustmentAmount.Name = "LabelDetailClientCashReceipt_AdjustmentAmount"
            Me.LabelDetailClientCashReceipt_AdjustmentAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailClientCashReceipt_AdjustmentAmount.SizeF = New System.Drawing.SizeF(99.99997!, 19.0!)
            Me.LabelDetailClientCashReceipt_AdjustmentAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetailClientCashReceipt_AdjustmentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailClientCashReceipt_AdjustmentAccount
            '
            Me.LabelDetailClientCashReceipt_AdjustmentAccount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeAdjustment")})
            Me.LabelDetailClientCashReceipt_AdjustmentAccount.Dpi = 100.0!
            Me.LabelDetailClientCashReceipt_AdjustmentAccount.LocationFloat = New DevExpress.Utils.PointFloat(325.9112!, 0!)
            Me.LabelDetailClientCashReceipt_AdjustmentAccount.Name = "LabelDetailClientCashReceipt_AdjustmentAccount"
            Me.LabelDetailClientCashReceipt_AdjustmentAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailClientCashReceipt_AdjustmentAccount.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetailClientCashReceipt_AdjustmentAccount.Text = "LabelDetailClientCashReceipt_AdjustmentAccount"
            '
            'LabelDetailClientCashReceipt_Payment
            '
            Me.LabelDetailClientCashReceipt_Payment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PaymentAmount", "{0:n2}")})
            Me.LabelDetailClientCashReceipt_Payment.Dpi = 100.0!
            Me.LabelDetailClientCashReceipt_Payment.LocationFloat = New DevExpress.Utils.PointFloat(218.8697!, 0!)
            Me.LabelDetailClientCashReceipt_Payment.Name = "LabelDetailClientCashReceipt_Payment"
            Me.LabelDetailClientCashReceipt_Payment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailClientCashReceipt_Payment.SizeF = New System.Drawing.SizeF(101.0415!, 19.0!)
            Me.LabelDetailClientCashReceipt_Payment.StylePriority.UseTextAlignment = False
            Me.LabelDetailClientCashReceipt_Payment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetailClientCashReceipt_Date
            '
            Me.LabelDetailClientCashReceipt_Date.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountReceivable.InvoiceDate", "{0:d}")})
            Me.LabelDetailClientCashReceipt_Date.Dpi = 100.0!
            Me.LabelDetailClientCashReceipt_Date.LocationFloat = New DevExpress.Utils.PointFloat(152.0832!, 0!)
            Me.LabelDetailClientCashReceipt_Date.Name = "LabelDetailClientCashReceipt_Date"
            Me.LabelDetailClientCashReceipt_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailClientCashReceipt_Date.SizeF = New System.Drawing.SizeF(66.7865!, 19.0!)
            '
            'LabelDetailClientCashReceipt_Invoice
            '
            Me.LabelDetailClientCashReceipt_Invoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Invoice")})
            Me.LabelDetailClientCashReceipt_Invoice.Dpi = 100.0!
            Me.LabelDetailClientCashReceipt_Invoice.LocationFloat = New DevExpress.Utils.PointFloat(79.1667!, 0!)
            Me.LabelDetailClientCashReceipt_Invoice.Name = "LabelDetailClientCashReceipt_Invoice"
            Me.LabelDetailClientCashReceipt_Invoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailClientCashReceipt_Invoice.SizeF = New System.Drawing.SizeF(71.99455!, 19.0!)
            Me.LabelDetailClientCashReceipt_Invoice.Text = "LabelDetailClientCashReceipt_Invoice"
            '
            'LabelDetailClientCashReceipt_ARAccount
            '
            Me.LabelDetailClientCashReceipt_ARAccount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeAR")})
            Me.LabelDetailClientCashReceipt_ARAccount.Dpi = 100.0!
            Me.LabelDetailClientCashReceipt_ARAccount.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0!)
            Me.LabelDetailClientCashReceipt_ARAccount.Name = "LabelDetailClientCashReceipt_ARAccount"
            Me.LabelDetailClientCashReceipt_ARAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailClientCashReceipt_ARAccount.SizeF = New System.Drawing.SizeF(79.16655!, 19.0!)
            Me.LabelDetailClientCashReceipt_ARAccount.Text = "LabelDetailClientCashReceipt_ARAccount"
            '
            'GroupFooterDetailReportClientCashReceiptDetails
            '
            Me.GroupFooterDetailReportClientCashReceiptDetails.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal, Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal, Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal, Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal})
            Me.GroupFooterDetailReportClientCashReceiptDetails.Dpi = 100.0!
            Me.GroupFooterDetailReportClientCashReceiptDetails.HeightF = 19.00003!
            Me.GroupFooterDetailReportClientCashReceiptDetails.Name = "GroupFooterDetailReportClientCashReceiptDetails"
            '
            'LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal
            '
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdjustmentAmount", "{0:n2}")})
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.Dpi = 100.0!
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.LocationFloat = New DevExpress.Utils.PointFloat(425.9113!, 0!)
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.Name = "LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal"
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.SizeF = New System.Drawing.SizeF(99.99997!, 19.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.StylePriority.UseBorders = False
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.IgnoreNullValues = True
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.Summary = XrSummary5
            Me.LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterClientCashReceiptDetail_PaymentTotal
            '
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PaymentAmount", "{0:n2}")})
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.Dpi = 100.0!
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.LocationFloat = New DevExpress.Utils.PointFloat(218.8696!, 0!)
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.Name = "LabelGroupFooterClientCashReceiptDetail_PaymentTotal"
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.SizeF = New System.Drawing.SizeF(101.0415!, 19.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.StylePriority.UseBorders = False
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.IgnoreNullValues = True
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.Summary = XrSummary6
            Me.LabelGroupFooterClientCashReceiptDetail_PaymentTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0!)
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Name = "LabelGroupFooterClientCashReceiptDetail_CheckTotal"
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.StylePriority.UseFont = False
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.Text = "Check Total:"
            Me.LabelGroupFooterClientCashReceiptDetail_CheckTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterClientCashReceiptDetail_OnAccountTotal
            '
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.Dpi = 100.0!
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.LocationFloat = New DevExpress.Utils.PointFloat(639.3747!, 0!)
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.Name = "LabelGroupFooterClientCashReceiptDetail_OnAccountTotal"
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.SizeF = New System.Drawing.SizeF(100.0!, 19.00003!)
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.StylePriority.UseBorders = False
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.IgnoreNullValues = True
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.Summary = XrSummary7
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.Text = "{}"
            Me.LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupFooterDetailReportClientCashReceiptDetailPayments
            '
            Me.GroupFooterDetailReportClientCashReceiptDetailPayments.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Subreport_PartialPaymentDetailSubreport})
            Me.GroupFooterDetailReportClientCashReceiptDetailPayments.Dpi = 100.0!
            Me.GroupFooterDetailReportClientCashReceiptDetailPayments.HeightF = 23.0!
            Me.GroupFooterDetailReportClientCashReceiptDetailPayments.Level = 1
            Me.GroupFooterDetailReportClientCashReceiptDetailPayments.Name = "GroupFooterDetailReportClientCashReceiptDetailPayments"
            '
            'Invoice
            '
            Me.Invoice.DataSource = Me.BindingSourceClientCashReceiptDetails
            Me.Invoice.Expression = "PadLeft([ARInvoiceNumber], 6, '0') + '-' + PadLeft([ARInvoiceSequenceNumber], 3, " &
    "'0')"
            Me.Invoice.Name = "Invoice"
            '
            'GroupFooterGLTransactionIntercompanyTransactions
            '
            Me.GroupFooterGLTransactionIntercompanyTransactions.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Subreport_TransactionSubreport})
            Me.GroupFooterGLTransactionIntercompanyTransactions.Dpi = 100.0!
            Me.GroupFooterGLTransactionIntercompanyTransactions.HeightF = 23.0!
            Me.GroupFooterGLTransactionIntercompanyTransactions.Name = "GroupFooterGLTransactionIntercompanyTransactions"
            '
            'GroupHeaderGLTransaction
            '
            Me.GroupHeaderGLTransaction.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LinePageHeader_Bottom})
            Me.GroupHeaderGLTransaction.Dpi = 100.0!
            Me.GroupHeaderGLTransaction.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLTransaction", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderGLTransaction.HeightF = 4.083347!
            Me.GroupHeaderGLTransaction.Level = 1
            Me.GroupHeaderGLTransaction.Name = "GroupHeaderGLTransaction"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport)
            '
            'GroupFooterGLTransaction
            '
            Me.GroupFooterGLTransaction.Dpi = 100.0!
            Me.GroupFooterGLTransaction.HeightF = 0!
            Me.GroupFooterGLTransaction.Level = 1
            Me.GroupFooterGLTransaction.Name = "GroupFooterGLTransaction"
            '
            'Subreport_PartialPaymentDetailSubreport
            '
            Me.Subreport_PartialPaymentDetailSubreport.CanShrink = True
            Me.Subreport_PartialPaymentDetailSubreport.Dpi = 100.0!
            Me.Subreport_PartialPaymentDetailSubreport.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Subreport_PartialPaymentDetailSubreport.Name = "Subreport_PartialPaymentDetailSubreport"
            Me.Subreport_PartialPaymentDetailSubreport.ReportSource = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientCashReceiptPartialPaymentSubReport()
            Me.Subreport_PartialPaymentDetailSubreport.SizeF = New System.Drawing.SizeF(749.9999!, 23.0!)
            '
            'Subreport_TransactionSubreport
            '
            Me.Subreport_TransactionSubreport.CanShrink = True
            Me.Subreport_TransactionSubreport.Dpi = 100.0!
            Me.Subreport_TransactionSubreport.LocationFloat = New DevExpress.Utils.PointFloat(0.0002145767!, 0!)
            Me.Subreport_TransactionSubreport.Name = "Subreport_TransactionSubreport"
            Me.Subreport_TransactionSubreport.ReportSource = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientCashReceiptTransactionSubReport()
            Me.Subreport_TransactionSubreport.SizeF = New System.Drawing.SizeF(749.9999!, 23.0!)
            '
            'ClientCashReceiptBatchReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.DetailReportClientCashReceiptOnAccounts, Me.DetailReportClientCashReceiptDetails, Me.GroupFooterGLTransactionIntercompanyTransactions, Me.GroupHeaderGLTransaction, Me.GroupFooterGLTransaction})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Invoice})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.BindingSourceClientCashReceiptDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceClientCashReceiptOnAccount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ClientLabel As DevExpress.XtraReports.UI.XRLabel
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
        Private WithEvents LabelDetail_OnAccountAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_OnAccountAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_OnAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AdjustmentLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineDetail_Break As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelDetail_AdjAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AdjAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_PaymentLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_InvoiceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ARAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportClientCashReceiptOnAccounts As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailOnAccount As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents DetailReportClientCashReceiptDetails As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailClientCashReceiptDetail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents Invoice As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents LabelGroupFooterClientCashReceiptDetail_CheckTotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_Payments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumOnAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_Checks As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_OnAccount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumPayments As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_Adjustments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumAdjustments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Subreport_TransactionSubreport As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents BindingSourceClientCashReceiptDetails As System.Windows.Forms.BindingSource
        Friend WithEvents BindingSourceClientCashReceiptOnAccount As System.Windows.Forms.BindingSource
        Friend WithEvents LabelDetail_CheckAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CheckDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CheckNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DepositDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailClientCashReceipt_ARAccount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailClientCashReceipt_Date As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailClientCashReceipt_Invoice As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailClientCashReceipt_AdjustmentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailClientCashReceipt_AdjustmentAccount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailClientCashReceipt_Payment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterGLTransactionIntercompanyTransactions As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderGLTransaction As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents LabelDetailOnAccount_Amount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterClientCashReceiptDetail_AdjustmentTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterClientCashReceiptDetail_PaymentTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterClientCashReceiptDetail_OnAccountTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterDetailReportClientCashReceiptDetails As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelReportFooter_SumChecks As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Status As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterDetailReportClientCashReceiptDetailPayments As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents Subreport_PartialPaymentDetailSubreport As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents LabelDetail_PaymentTypeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterGLTransaction As DevExpress.XtraReports.UI.GroupFooterBand
    End Class

End Namespace
