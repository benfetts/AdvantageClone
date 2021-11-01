Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ClientCashReceiptBatchSummaryReport
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
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CashAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTransaction = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DepositDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CheckNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_ClientLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_StatusLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_GLTransLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderBankCode_CashAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_Line = New DevExpress.XtraReports.UI.XRLine()
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
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            Me.GroupHeaderBankCode = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooterBankCode = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupHeaderBankCode_BankLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterBankCode_BankCheckTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PaymentTypeDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupFooterBankCode = New DevExpress.XtraReports.UI.XRLine()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_PaymentTypeDescription, Me.XrLabel1, Me.LabelDetail_GLTransaction, Me.LabelDetail_Client, Me.LabelDetail_DepositDate, Me.LabelDetail_CheckAmount, Me.LabelDetail_CheckDate, Me.LabelDetail_CheckNumber, Me.LabelDetail_PostPeriod})
            Me.Detail.HeightF = 19.00004!
            Me.Detail.KeepTogetherWithDetailReports = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Status")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(515.2115!, 0.00003178914!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(86.32794!, 18.99995!)
            Me.XrLabel1.Text = "XrLabel1"
            '
            'LabelDetail_CashAccount
            '
            Me.LabelDetail_CashAccount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CashAccountCode")})
            Me.LabelDetail_CashAccount.LocationFloat = New DevExpress.Utils.PointFloat(88.86439!, 18.99999!)
            Me.LabelDetail_CashAccount.Name = "LabelDetail_CashAccount"
            Me.LabelDetail_CashAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CashAccount.SizeF = New System.Drawing.SizeF(315.9475!, 19.00004!)
            Me.LabelDetail_CashAccount.Text = "LabelDetail_CashAccount"
            '
            'LabelDetail_GLTransaction
            '
            Me.LabelDetail_GLTransaction.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.LabelDetail_GLTransaction.LocationFloat = New DevExpress.Utils.PointFloat(660.7844!, 0.00003178914!)
            Me.LabelDetail_GLTransaction.Name = "LabelDetail_GLTransaction"
            Me.LabelDetail_GLTransaction.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLTransaction.SizeF = New System.Drawing.SizeF(57.72095!, 19.00001!)
            Me.LabelDetail_GLTransaction.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLTransaction.Text = "LabelDetail_GLTransaction"
            Me.LabelDetail_GLTransaction.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Client
            '
            Me.LabelDetail_Client.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Client")})
            Me.LabelDetail_Client.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_Client.Name = "LabelDetail_Client"
            Me.LabelDetail_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Client.SizeF = New System.Drawing.SizeF(235.0!, 19.0!)
            Me.LabelDetail_Client.Text = "LabelDetail_Client"
            '
            'LabelDetail_DepositDate
            '
            Me.LabelDetail_DepositDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepositDate", "{0:d}")})
            Me.LabelDetail_DepositDate.LocationFloat = New DevExpress.Utils.PointFloat(723.5055!, 0!)
            Me.LabelDetail_DepositDate.Name = "LabelDetail_DepositDate"
            Me.LabelDetail_DepositDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DepositDate.SizeF = New System.Drawing.SizeF(78.125!, 19.0!)
            '
            'LabelDetail_CheckAmount
            '
            Me.LabelDetail_CheckAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount", "{0:n2}")})
            Me.LabelDetail_CheckAmount.LocationFloat = New DevExpress.Utils.PointFloat(417.7099!, 0!)
            Me.LabelDetail_CheckAmount.Name = "LabelDetail_CheckAmount"
            Me.LabelDetail_CheckAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckAmount.SizeF = New System.Drawing.SizeF(87.50162!, 19.00001!)
            Me.LabelDetail_CheckAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_CheckAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_CheckDate
            '
            Me.LabelDetail_CheckDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckDate", "{0:d}")})
            Me.LabelDetail_CheckDate.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 0!)
            Me.LabelDetail_CheckDate.Name = "LabelDetail_CheckDate"
            Me.LabelDetail_CheckDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckDate.SizeF = New System.Drawing.SizeF(67.70993!, 19.00001!)
            '
            'LabelDetail_CheckNumber
            '
            Me.LabelDetail_CheckNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckNumber")})
            Me.LabelDetail_CheckNumber.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 0!)
            Me.LabelDetail_CheckNumber.Name = "LabelDetail_CheckNumber"
            Me.LabelDetail_CheckNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_CheckNumber.SizeF = New System.Drawing.SizeF(100.0!, 18.99999!)
            Me.LabelDetail_CheckNumber.Text = "LabelDetail_CheckNumber"
            '
            'LabelDetail_PostPeriod
            '
            Me.LabelDetail_PostPeriod.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.LabelDetail_PostPeriod.LocationFloat = New DevExpress.Utils.PointFloat(601.5394!, 0!)
            Me.LabelDetail_PostPeriod.Name = "LabelDetail_PostPeriod"
            Me.LabelDetail_PostPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_PostPeriod.SizeF = New System.Drawing.SizeF(59.24493!, 18.99998!)
            Me.LabelDetail_PostPeriod.StylePriority.UseTextAlignment = False
            Me.LabelDetail_PostPeriod.Text = "LabelDetail_PostPeriod"
            Me.LabelDetail_PostPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageGroupHeaderBankCode_DepositDateLabel
            '
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(723.5054!, 45.75004!)
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.Name = "LabelPageGroupHeaderBankCode_DepositDateLabel"
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.SizeF = New System.Drawing.SizeF(78.12506!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.StylePriority.UseTextAlignment = False
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.Text = "Deposit Date"
            Me.LabelPageGroupHeaderBankCode_DepositDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageGroupHeaderBankCode_CheckAmountLabel
            '
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(417.7099!, 45.75004!)
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.Name = "LabelPageGroupHeaderBankCode_CheckAmountLabel"
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.SizeF = New System.Drawing.SizeF(87.50156!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.Text = "Check Amount"
            Me.LabelPageGroupHeaderBankCode_CheckAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageGroupHeaderBankCode_ClientLabel
            '
            Me.LabelPageGroupHeaderBankCode_ClientLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_ClientLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_ClientLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_ClientLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_ClientLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_ClientLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_ClientLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 45.75004!)
            Me.LabelPageGroupHeaderBankCode_ClientLabel.Name = "LabelPageGroupHeaderBankCode_ClientLabel"
            Me.LabelPageGroupHeaderBankCode_ClientLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_ClientLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_ClientLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_ClientLabel.Text = "Client"
            Me.LabelPageGroupHeaderBankCode_ClientLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageGroupHeaderBankCode_CheckNumberLabel
            '
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 45.75004!)
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.Name = "LabelPageGroupHeaderBankCode_CheckNumberLabel"
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.SizeF = New System.Drawing.SizeF(99.99991!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.Text = "Check Number"
            Me.LabelPageGroupHeaderBankCode_CheckNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageGroupHeaderBankCode_StatusLabel
            '
            Me.LabelPageGroupHeaderBankCode_StatusLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_StatusLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_StatusLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_StatusLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_StatusLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_StatusLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_StatusLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_StatusLabel.LocationFloat = New DevExpress.Utils.PointFloat(515.2115!, 45.75004!)
            Me.LabelPageGroupHeaderBankCode_StatusLabel.Name = "LabelPageGroupHeaderBankCode_StatusLabel"
            Me.LabelPageGroupHeaderBankCode_StatusLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_StatusLabel.SizeF = New System.Drawing.SizeF(72.78619!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_StatusLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_StatusLabel.Text = "Status"
            Me.LabelPageGroupHeaderBankCode_StatusLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageGroupHeaderBankCode_CheckDateLabel
            '
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(349.9999!, 45.75004!)
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.Name = "LabelPageGroupHeaderBankCode_CheckDateLabel"
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.SizeF = New System.Drawing.SizeF(67.70999!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.Text = "Check Date"
            Me.LabelPageGroupHeaderBankCode_CheckDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageGroupHeaderBankCode_PostingPeriodLabel
            '
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(587.9977!, 45.75004!)
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.Name = "LabelPageGroupHeaderBankCode_PostingPeriodLabel"
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.SizeF = New System.Drawing.SizeF(72.7865!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.StylePriority.UseTextAlignment = False
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.Text = "Post Period"
            Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageGroupHeaderBankCode_GLTransLabel
            '
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.LocationFloat = New DevExpress.Utils.PointFloat(660.7842!, 45.75004!)
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.Name = "LabelPageGroupHeaderBankCode_GLTransLabel"
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.SizeF = New System.Drawing.SizeF(57.72113!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.StylePriority.UseTextAlignment = False
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.Text = "GL XACT"
            Me.LabelPageGroupHeaderBankCode_GLTransLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderBankCode_CashAccountLabel
            '
            Me.LabelGroupHeaderBankCode_CashAccountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderBankCode_CashAccountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderBankCode_CashAccountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderBankCode_CashAccountLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderBankCode_CashAccountLabel.CanGrow = False
            Me.LabelGroupHeaderBankCode_CashAccountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderBankCode_CashAccountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderBankCode_CashAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 19.00002!)
            Me.LabelGroupHeaderBankCode_CashAccountLabel.Name = "LabelGroupHeaderBankCode_CashAccountLabel"
            Me.LabelGroupHeaderBankCode_CashAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderBankCode_CashAccountLabel.SizeF = New System.Drawing.SizeF(88.86426!, 19.0!)
            Me.LabelGroupHeaderBankCode_CashAccountLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderBankCode_CashAccountLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderBankCode_CashAccountLabel.Text = "Cash Account:"
            Me.LabelGroupHeaderBankCode_CashAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineReportFooter_Line
            '
            Me.LineReportFooter_Line.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_Line.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_Line.BorderWidth = 0!
            Me.LineReportFooter_Line.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_Line.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LineReportFooter_Line.Name = "LineReportFooter_Line"
            Me.LineReportFooter_Line.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            Me.LineReportFooter_Line.StylePriority.UseBorderColor = False
            Me.LineReportFooter_Line.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_Line.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_BatchTotalLabel
            '
            Me.LabelReportFooter_BatchTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_BatchTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_BatchTotalLabel.BorderWidth = 1.0!
            Me.LabelReportFooter_BatchTotalLabel.CanGrow = False
            Me.LabelReportFooter_BatchTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_BatchTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(213.5418!, 3.999996!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(136.4582!, 19.0!)
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotalLabel.Text = "Batch Check Total:"
            Me.LabelReportFooter_BatchTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle, Me.LinePageHeader_Bottom})
            Me.PageHeader.HeightF = 64.58337!
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
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(762.4999!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(237.5001!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.Text = "Client Cash Receipts Batch Summary Report"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4.0!
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageHeader_Top.Name = "LinePageHeader_Top"
            Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
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
            Me.LabelPageHeader_ReportTitle.Text = "Client Cash Receipts Batch Summary Report"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4.0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 50.08335!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_SumChecks, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_Line})
            Me.ReportFooter.HeightF = 23.0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_SumChecks
            '
            Me.LabelReportFooter_SumChecks.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_SumChecks.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount", "{0:n2}")})
            Me.LabelReportFooter_SumChecks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_SumChecks.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 3.999996!)
            Me.LabelReportFooter_SumChecks.Name = "LabelReportFooter_SumChecks"
            Me.LabelReportFooter_SumChecks.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumChecks.SizeF = New System.Drawing.SizeF(155.2115!, 19.0!)
            Me.LabelReportFooter_SumChecks.StylePriority.UseBorders = False
            Me.LabelReportFooter_SumChecks.StylePriority.UseFont = False
            Me.LabelReportFooter_SumChecks.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.IgnoreNullValues = True
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumChecks.Summary = XrSummary1
            Me.LabelReportFooter_SumChecks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(864.5417!, 4.083315!)
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
            Me.PageFooter.HeightF = 25.08332!
            Me.PageFooter.Name = "PageFooter"
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4.0!
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
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
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport)
            '
            'GroupHeaderBankCode
            '
            Me.GroupHeaderBankCode.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel, Me.XrLabel2, Me.LabelGroupHeaderBankCode_BankLabel, Me.LabelPageGroupHeaderBankCode_ClientLabel, Me.LabelPageGroupHeaderBankCode_DepositDateLabel, Me.LabelPageGroupHeaderBankCode_GLTransLabel, Me.LabelPageGroupHeaderBankCode_PostingPeriodLabel, Me.LabelPageGroupHeaderBankCode_StatusLabel, Me.LabelPageGroupHeaderBankCode_CheckAmountLabel, Me.LabelPageGroupHeaderBankCode_CheckDateLabel, Me.LabelPageGroupHeaderBankCode_CheckNumberLabel, Me.LabelGroupHeaderBankCode_CashAccountLabel, Me.LabelDetail_CashAccount})
            Me.GroupHeaderBankCode.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("BankCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderBankCode.HeightF = 64.75005!
            Me.GroupHeaderBankCode.Name = "GroupHeaderBankCode"
            '
            'GroupFooterBankCode
            '
            Me.GroupFooterBankCode.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineGroupFooterBankCode, Me.LabelGroupFooterBankCode_BankCheckTotalLabel, Me.LabelGroupFooterBankCode_BankCheckTotal})
            Me.GroupFooterBankCode.HeightF = 26.29166!
            Me.GroupFooterBankCode.Name = "GroupFooterBankCode"
            '
            'LabelGroupHeaderBankCode_BankLabel
            '
            Me.LabelGroupHeaderBankCode_BankLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderBankCode_BankLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderBankCode_BankLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderBankCode_BankLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderBankCode_BankLabel.CanGrow = False
            Me.LabelGroupHeaderBankCode_BankLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderBankCode_BankLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderBankCode_BankLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0!)
            Me.LabelGroupHeaderBankCode_BankLabel.Name = "LabelGroupHeaderBankCode_BankLabel"
            Me.LabelGroupHeaderBankCode_BankLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderBankCode_BankLabel.SizeF = New System.Drawing.SizeF(88.67365!, 19.0!)
            Me.LabelGroupHeaderBankCode_BankLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderBankCode_BankLabel.Text = "Bank:"
            Me.LabelGroupHeaderBankCode_BankLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Bank")})
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(88.86439!, 0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(315.9475!, 19.00001!)
            Me.XrLabel2.Text = "XrLabel2"
            '
            'LabelGroupFooterBankCode_BankCheckTotalLabel
            '
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.CanGrow = False
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(213.5418!, 0!)
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.Name = "LabelGroupFooterBankCode_BankCheckTotalLabel"
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.SizeF = New System.Drawing.SizeF(136.4582!, 19.0!)
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.Text = "Bank Check Total:"
            Me.LabelGroupFooterBankCode_BankCheckTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterBankCode_BankCheckTotal
            '
            Me.LabelGroupFooterBankCode_BankCheckTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterBankCode_BankCheckTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount", "{0:n2}")})
            Me.LabelGroupFooterBankCode_BankCheckTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterBankCode_BankCheckTotal.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 0!)
            Me.LabelGroupFooterBankCode_BankCheckTotal.Name = "LabelGroupFooterBankCode_BankCheckTotal"
            Me.LabelGroupFooterBankCode_BankCheckTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterBankCode_BankCheckTotal.SizeF = New System.Drawing.SizeF(155.2115!, 19.0!)
            Me.LabelGroupFooterBankCode_BankCheckTotal.StylePriority.UseBorders = False
            Me.LabelGroupFooterBankCode_BankCheckTotal.StylePriority.UseFont = False
            Me.LabelGroupFooterBankCode_BankCheckTotal.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.IgnoreNullValues = True
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterBankCode_BankCheckTotal.Summary = XrSummary2
            Me.LabelGroupFooterBankCode_BankCheckTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_PaymentTypeDescription
            '
            Me.LabelDetail_PaymentTypeDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PaymentTypeDescription")})
            Me.LabelDetail_PaymentTypeDescription.LocationFloat = New DevExpress.Utils.PointFloat(801.6306!, 0.00003178914!)
            Me.LabelDetail_PaymentTypeDescription.Name = "LabelDetail_PaymentTypeDescription"
            Me.LabelDetail_PaymentTypeDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
            Me.LabelDetail_PaymentTypeDescription.SizeF = New System.Drawing.SizeF(198.3694!, 18.99995!)
            Me.LabelDetail_PaymentTypeDescription.Text = "LabelDetail_PaymentTypeDescription"
            '
            'LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel
            '
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.BorderWidth = 1.0!
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.CanGrow = False
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.LocationFloat = New DevExpress.Utils.PointFloat(801.6306!, 45.75005!)
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.Name = "LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel"
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.SizeF = New System.Drawing.SizeF(198.3694!, 19.0!)
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.StylePriority.UseFont = False
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.StylePriority.UseTextAlignment = False
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.Text = "Payment Type"
            Me.LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineGroupFooterBankCode
            '
            Me.LineGroupFooterBankCode.BorderColor = System.Drawing.Color.Silver
            Me.LineGroupFooterBankCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooterBankCode.BorderWidth = 4.0!
            Me.LineGroupFooterBankCode.ForeColor = System.Drawing.Color.Silver
            Me.LineGroupFooterBankCode.LocationFloat = New DevExpress.Utils.PointFloat(0!, 22.20831!)
            Me.LineGroupFooterBankCode.Name = "LineGroupFooterBankCode"
            Me.LineGroupFooterBankCode.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
            '
            'ClientCashReceiptBatchSummaryReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.GroupHeaderBankCode, Me.GroupFooterBankCode})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageGroupHeaderBankCode_ClientLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelPageGroupHeaderBankCode_CheckNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageGroupHeaderBankCode_CheckDateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageGroupHeaderBankCode_GLTransLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageGroupHeaderBankCode_PostingPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageGroupHeaderBankCode_StatusLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderBankCode_CashAccountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelPageGroupHeaderBankCode_CheckAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageGroupHeaderBankCode_DepositDateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_BatchTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_Line As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumChecks As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CheckAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CheckDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CheckNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DepositDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Client As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PostPeriod As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLTransaction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_CashAccount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderBankCode As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterBankCode As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderBankCode_BankLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterBankCode_BankCheckTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterBankCode_BankCheckTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PaymentTypeDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageGroupHeaderBankCode_PaymentTypeDescriptionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupFooterBankCode As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
