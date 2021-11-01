Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ClientInvoiceBatchSummaryReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetail_AR = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTransaction = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostPeriodCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OfficeCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ProductCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DivisionCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ARLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OfficeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DivisionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ProductLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostingPeriodLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLTransLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DescriptionLabel = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.LabelReportFooter_NumberOfInvoices = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_NumberOfInvoicesLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SumInvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.Invoice = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_AR, Me.LabelDetail_InvoiceAmount, Me.LabelDetail_InvoiceDate, Me.LabelDetail_InvoiceDescription, Me.LabelDetail_InvoiceNumber, Me.LabelDetail_GLTransaction, Me.LabelDetail_PostPeriodCode, Me.LabelDetail_OfficeCode, Me.LabelDetail_ProductCode, Me.LabelDetail_DivisionCode, Me.LabelDetail_ClientCode})
            Me.Detail.HeightF = 19.00006!
            Me.Detail.KeepTogetherWithDetailReports = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_AR
            '
            Me.LabelDetail_AR.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACodeAR")})
            Me.LabelDetail_AR.LocationFloat = New DevExpress.Utils.PointFloat(806.25!, 0.0!)
            Me.LabelDetail_AR.Name = "LabelDetail_AR"
            Me.LabelDetail_AR.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_AR.SizeF = New System.Drawing.SizeF(183.75!, 19.0!)
            Me.LabelDetail_AR.Text = "LabelDetail_AR"
            '
            'LabelDetail_InvoiceAmount
            '
            Me.LabelDetail_InvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount", "{0:n2}")})
            Me.LabelDetail_InvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(503.042!, 0.0!)
            Me.LabelDetail_InvoiceAmount.Name = "LabelDetail_InvoiceAmount"
            Me.LabelDetail_InvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceAmount.SizeF = New System.Drawing.SizeF(99.99982!, 19.00003!)
            Me.LabelDetail_InvoiceAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_InvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_InvoiceDate
            '
            Me.LabelDetail_InvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelDetail_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(428.1709!, 0.0!)
            Me.LabelDetail_InvoiceDate.Name = "LabelDetail_InvoiceDate"
            Me.LabelDetail_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceDate.SizeF = New System.Drawing.SizeF(72.87079!, 18.99998!)
            Me.LabelDetail_InvoiceDate.StylePriority.UseTextAlignment = False
            Me.LabelDetail_InvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceDescription
            '
            Me.LabelDetail_InvoiceDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.LabelDetail_InvoiceDescription.LocationFloat = New DevExpress.Utils.PointFloat(212.4989!, 0.0!)
            Me.LabelDetail_InvoiceDescription.Name = "LabelDetail_InvoiceDescription"
            Me.LabelDetail_InvoiceDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceDescription.SizeF = New System.Drawing.SizeF(136.5054!, 19.0!)
            Me.LabelDetail_InvoiceDescription.Text = "LabelDetail_InvoiceDescription"
            '
            'LabelDetail_InvoiceNumber
            '
            Me.LabelDetail_InvoiceNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
            Me.LabelDetail_InvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(349.0043!, 0.00003178914!)
            Me.LabelDetail_InvoiceNumber.Name = "LabelDetail_InvoiceNumber"
            Me.LabelDetail_InvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceNumber.SizeF = New System.Drawing.SizeF(79.1666!, 19.0!)
            Me.LabelDetail_InvoiceNumber.Text = "LabelDetail_InvoiceNumber"
            '
            'LabelDetail_GLTransaction
            '
            Me.LabelDetail_GLTransaction.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.LabelDetail_GLTransaction.LocationFloat = New DevExpress.Utils.PointFloat(688.5406!, 0.00006357829!)
            Me.LabelDetail_GLTransaction.Name = "LabelDetail_GLTransaction"
            Me.LabelDetail_GLTransaction.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLTransaction.SizeF = New System.Drawing.SizeF(100.0!, 18.99999!)
            Me.LabelDetail_GLTransaction.Text = "LabelDetail_GLTransaction"
            '
            'LabelDetail_PostPeriodCode
            '
            Me.LabelDetail_PostPeriodCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.LabelDetail_PostPeriodCode.LocationFloat = New DevExpress.Utils.PointFloat(608.5417!, 0.0!)
            Me.LabelDetail_PostPeriodCode.Name = "LabelDetail_PostPeriodCode"
            Me.LabelDetail_PostPeriodCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_PostPeriodCode.SizeF = New System.Drawing.SizeF(73.99896!, 18.99999!)
            Me.LabelDetail_PostPeriodCode.Text = "LabelDetail_PostPeriodCode"
            '
            'LabelDetail_OfficeCode
            '
            Me.LabelDetail_OfficeCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeCode")})
            Me.LabelDetail_OfficeCode.LocationFloat = New DevExpress.Utils.PointFloat(159.3742!, 0.00006357829!)
            Me.LabelDetail_OfficeCode.Name = "LabelDetail_OfficeCode"
            Me.LabelDetail_OfficeCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_OfficeCode.SizeF = New System.Drawing.SizeF(53.12462!, 18.99999!)
            Me.LabelDetail_OfficeCode.Text = "LabelDetail_OfficeCode"
            '
            'LabelDetail_ProductCode
            '
            Me.LabelDetail_ProductCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.LabelDetail_ProductCode.LocationFloat = New DevExpress.Utils.PointFloat(106.2496!, 0.00006357829!)
            Me.LabelDetail_ProductCode.Name = "LabelDetail_ProductCode"
            Me.LabelDetail_ProductCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ProductCode.SizeF = New System.Drawing.SizeF(53.12463!, 18.99998!)
            Me.LabelDetail_ProductCode.Text = "LabelDetail_ProductCode"
            '
            'LabelDetail_DivisionCode
            '
            Me.LabelDetail_DivisionCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.LabelDetail_DivisionCode.LocationFloat = New DevExpress.Utils.PointFloat(53.12498!, 0.00003178914!)
            Me.LabelDetail_DivisionCode.Name = "LabelDetail_DivisionCode"
            Me.LabelDetail_DivisionCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DivisionCode.SizeF = New System.Drawing.SizeF(53.12463!, 19.00001!)
            Me.LabelDetail_DivisionCode.Text = "LabelDetail_DivisionCode"
            '
            'LabelDetail_ClientCode
            '
            Me.LabelDetail_ClientCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.LabelDetail_ClientCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelDetail_ClientCode.Name = "LabelDetail_ClientCode"
            Me.LabelDetail_ClientCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ClientCode.SizeF = New System.Drawing.SizeF(53.12499!, 18.99999!)
            Me.LabelDetail_ClientCode.Text = "LabelDetail_ClientCode"
            '
            'LabelDetail_ARLabel
            '
            Me.LabelDetail_ARLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ARLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ARLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ARLabel.BorderWidth = 1.0!
            Me.LabelDetail_ARLabel.CanGrow = False
            Me.LabelDetail_ARLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ARLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ARLabel.LocationFloat = New DevExpress.Utils.PointFloat(806.25!, 72.25002!)
            Me.LabelDetail_ARLabel.Name = "LabelDetail_ARLabel"
            Me.LabelDetail_ARLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ARLabel.SizeF = New System.Drawing.SizeF(121.8752!, 19.0!)
            Me.LabelDetail_ARLabel.StylePriority.UseFont = False
            Me.LabelDetail_ARLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ARLabel.Text = "Accounts Receivable:"
            Me.LabelDetail_ARLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceDateLabel
            '
            Me.LabelDetail_InvoiceDateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InvoiceDateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InvoiceDateLabel.BorderWidth = 1.0!
            Me.LabelDetail_InvoiceDateLabel.CanGrow = False
            Me.LabelDetail_InvoiceDateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_InvoiceDateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(428.1709!, 72.25002!)
            Me.LabelDetail_InvoiceDateLabel.Name = "LabelDetail_InvoiceDateLabel"
            Me.LabelDetail_InvoiceDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceDateLabel.SizeF = New System.Drawing.SizeF(74.87106!, 19.0!)
            Me.LabelDetail_InvoiceDateLabel.StylePriority.UseFont = False
            Me.LabelDetail_InvoiceDateLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_InvoiceDateLabel.Text = "Date"
            Me.LabelDetail_InvoiceDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceNumberLabel
            '
            Me.LabelDetail_InvoiceNumberLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InvoiceNumberLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceNumberLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InvoiceNumberLabel.BorderWidth = 1.0!
            Me.LabelDetail_InvoiceNumberLabel.CanGrow = False
            Me.LabelDetail_InvoiceNumberLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_InvoiceNumberLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(349.0043!, 72.25002!)
            Me.LabelDetail_InvoiceNumberLabel.Name = "LabelDetail_InvoiceNumberLabel"
            Me.LabelDetail_InvoiceNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceNumberLabel.SizeF = New System.Drawing.SizeF(79.1666!, 19.0!)
            Me.LabelDetail_InvoiceNumberLabel.StylePriority.UseFont = False
            Me.LabelDetail_InvoiceNumberLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_InvoiceNumberLabel.Text = "Number"
            Me.LabelDetail_InvoiceNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceAmountLabel
            '
            Me.LabelDetail_InvoiceAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InvoiceAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InvoiceAmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_InvoiceAmountLabel.CanGrow = False
            Me.LabelDetail_InvoiceAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_InvoiceAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(503.042!, 72.25002!)
            Me.LabelDetail_InvoiceAmountLabel.Name = "LabelDetail_InvoiceAmountLabel"
            Me.LabelDetail_InvoiceAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceAmountLabel.SizeF = New System.Drawing.SizeF(99.99977!, 19.0!)
            Me.LabelDetail_InvoiceAmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_InvoiceAmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_InvoiceAmountLabel.Text = "Amount"
            Me.LabelDetail_InvoiceAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.LabelDetail_OfficeLabel.LocationFloat = New DevExpress.Utils.PointFloat(159.3743!, 72.25002!)
            Me.LabelDetail_OfficeLabel.Name = "LabelDetail_OfficeLabel"
            Me.LabelDetail_OfficeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OfficeLabel.SizeF = New System.Drawing.SizeF(53.1246!, 19.0!)
            Me.LabelDetail_OfficeLabel.StylePriority.UseFont = False
            Me.LabelDetail_OfficeLabel.Text = "Office"
            Me.LabelDetail_OfficeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ClientLabel
            '
            Me.LabelDetail_ClientLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ClientLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ClientLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ClientLabel.BorderWidth = 1.0!
            Me.LabelDetail_ClientLabel.CanGrow = False
            Me.LabelDetail_ClientLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ClientLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0003576279!, 72.25002!)
            Me.LabelDetail_ClientLabel.Name = "LabelDetail_ClientLabel"
            Me.LabelDetail_ClientLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ClientLabel.SizeF = New System.Drawing.SizeF(53.12463!, 19.0!)
            Me.LabelDetail_ClientLabel.StylePriority.UseFont = False
            Me.LabelDetail_ClientLabel.Text = "Client"
            Me.LabelDetail_ClientLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DivisionLabel
            '
            Me.LabelDetail_DivisionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DivisionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DivisionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DivisionLabel.BorderWidth = 1.0!
            Me.LabelDetail_DivisionLabel.CanGrow = False
            Me.LabelDetail_DivisionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DivisionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DivisionLabel.LocationFloat = New DevExpress.Utils.PointFloat(53.12498!, 72.25002!)
            Me.LabelDetail_DivisionLabel.Name = "LabelDetail_DivisionLabel"
            Me.LabelDetail_DivisionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DivisionLabel.SizeF = New System.Drawing.SizeF(53.12463!, 19.0!)
            Me.LabelDetail_DivisionLabel.StylePriority.UseFont = False
            Me.LabelDetail_DivisionLabel.Text = "Division"
            Me.LabelDetail_DivisionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ProductLabel
            '
            Me.LabelDetail_ProductLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ProductLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ProductLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ProductLabel.BorderWidth = 1.0!
            Me.LabelDetail_ProductLabel.CanGrow = False
            Me.LabelDetail_ProductLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ProductLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ProductLabel.LocationFloat = New DevExpress.Utils.PointFloat(106.2496!, 72.25002!)
            Me.LabelDetail_ProductLabel.Name = "LabelDetail_ProductLabel"
            Me.LabelDetail_ProductLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ProductLabel.SizeF = New System.Drawing.SizeF(53.12465!, 19.0!)
            Me.LabelDetail_ProductLabel.StylePriority.UseFont = False
            Me.LabelDetail_ProductLabel.Text = "Product"
            Me.LabelDetail_ProductLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.LabelDetail_PostingPeriodLabel.LocationFloat = New DevExpress.Utils.PointFloat(608.5417!, 72.25002!)
            Me.LabelDetail_PostingPeriodLabel.Name = "LabelDetail_PostingPeriodLabel"
            Me.LabelDetail_PostingPeriodLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_PostingPeriodLabel.SizeF = New System.Drawing.SizeF(73.9989!, 19.0!)
            Me.LabelDetail_PostingPeriodLabel.StylePriority.UseFont = False
            Me.LabelDetail_PostingPeriodLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_PostingPeriodLabel.Text = "Post Period"
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
            Me.LabelDetail_GLTransLabel.LocationFloat = New DevExpress.Utils.PointFloat(688.5406!, 72.25002!)
            Me.LabelDetail_GLTransLabel.Name = "LabelDetail_GLTransLabel"
            Me.LabelDetail_GLTransLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GLTransLabel.SizeF = New System.Drawing.SizeF(103.1247!, 19.0!)
            Me.LabelDetail_GLTransLabel.StylePriority.UseFont = False
            Me.LabelDetail_GLTransLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLTransLabel.Text = "GL Transaction"
            Me.LabelDetail_GLTransLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DescriptionLabel
            '
            Me.LabelDetail_DescriptionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DescriptionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DescriptionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DescriptionLabel.BorderWidth = 1.0!
            Me.LabelDetail_DescriptionLabel.CanGrow = False
            Me.LabelDetail_DescriptionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DescriptionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DescriptionLabel.LocationFloat = New DevExpress.Utils.PointFloat(212.4989!, 72.25002!)
            Me.LabelDetail_DescriptionLabel.Name = "LabelDetail_DescriptionLabel"
            Me.LabelDetail_DescriptionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DescriptionLabel.SizeF = New System.Drawing.SizeF(81.2495!, 19.0!)
            Me.LabelDetail_DescriptionLabel.StylePriority.UseFont = False
            Me.LabelDetail_DescriptionLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_DescriptionLabel.Text = "Description"
            Me.LabelDetail_DescriptionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineReportFooter_Line
            '
            Me.LineReportFooter_Line.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_Line.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_Line.BorderWidth = 0.0!
            Me.LineReportFooter_Line.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_Line.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 2.0!)
            Me.LineReportFooter_Line.Name = "LineReportFooter_Line"
            Me.LineReportFooter_Line.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            Me.LineReportFooter_Line.StylePriority.UseBorderColor = False
            Me.LineReportFooter_Line.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_Line.StylePriority.UseForeColor = False
            '
            'LineReportFooter_LineThin
            '
            Me.LineReportFooter_LineThin.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_LineThin.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_LineThin.BorderWidth = 0.0!
            Me.LineReportFooter_LineThin.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_LineThin.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0.0!)
            Me.LineReportFooter_LineThin.Name = "LineReportFooter_LineThin"
            Me.LineReportFooter_LineThin.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
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
            Me.LabelReportFooter_BatchTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_BatchTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(400.9585!, 4.000028!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(79.16653!, 19.0!)
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotalLabel.Text = "Batch Total:"
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle, Me.LinePageHeader_Bottom, Me.LabelDetail_ClientLabel, Me.LabelDetail_DivisionLabel, Me.LabelDetail_ProductLabel, Me.LabelDetail_OfficeLabel, Me.LabelDetail_InvoiceNumberLabel, Me.LabelDetail_InvoiceDateLabel, Me.LabelDetail_InvoiceAmountLabel, Me.LabelDetail_PostingPeriodLabel, Me.LabelDetail_GLTransLabel, Me.LabelDetail_DescriptionLabel, Me.LabelDetail_ARLabel})
            Me.PageHeader.HeightF = 91.25002!
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
            Me.LabelPageHeader_Agency.Text = "Manual Client Invoice Batch Detail Report"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4.0!
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
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
            Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 4.083347!)
            Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
            Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "Manual Client Invoice Batch Summary Report"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4.0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.000222524!, 53.83333!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_NumberOfInvoices, Me.LabelReportFooter_NumberOfInvoicesLabel, Me.LabelReportFooter_SumInvoiceAmount, Me.LineReportFooter_LineThin, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_Line})
            Me.ReportFooter.HeightF = 26.37502!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_NumberOfInvoices
            '
            Me.LabelReportFooter_NumberOfInvoices.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLTransaction")})
            Me.LabelReportFooter_NumberOfInvoices.LocationFloat = New DevExpress.Utils.PointFloat(806.25!, 3.999996!)
            Me.LabelReportFooter_NumberOfInvoices.Name = "LabelReportFooter_NumberOfInvoices"
            Me.LabelReportFooter_NumberOfInvoices.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_NumberOfInvoices.SizeF = New System.Drawing.SizeF(100.0!, 18.99999!)
            XrSummary1.FormatString = "{0:#,#}"
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_NumberOfInvoices.Summary = XrSummary1
            Me.LabelReportFooter_NumberOfInvoices.Text = "LabelDetail_GLTransaction"
            '
            'LabelReportFooter_NumberOfInvoicesLabel
            '
            Me.LabelReportFooter_NumberOfInvoicesLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_NumberOfInvoicesLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_NumberOfInvoicesLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_NumberOfInvoicesLabel.BorderWidth = 1.0!
            Me.LabelReportFooter_NumberOfInvoicesLabel.CanGrow = False
            Me.LabelReportFooter_NumberOfInvoicesLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_NumberOfInvoicesLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_NumberOfInvoicesLabel.LocationFloat = New DevExpress.Utils.PointFloat(685.4165!, 4.000028!)
            Me.LabelReportFooter_NumberOfInvoicesLabel.Name = "LabelReportFooter_NumberOfInvoicesLabel"
            Me.LabelReportFooter_NumberOfInvoicesLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_NumberOfInvoicesLabel.SizeF = New System.Drawing.SizeF(120.8335!, 19.0!)
            Me.LabelReportFooter_NumberOfInvoicesLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_NumberOfInvoicesLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_NumberOfInvoicesLabel.Text = "Number of Invoices:"
            Me.LabelReportFooter_NumberOfInvoicesLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelReportFooter_SumInvoiceAmount
            '
            Me.LabelReportFooter_SumInvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount", "{0:n2}")})
            Me.LabelReportFooter_SumInvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(480.1251!, 3.999996!)
            Me.LabelReportFooter_SumInvoiceAmount.Name = "LabelReportFooter_SumInvoiceAmount"
            Me.LabelReportFooter_SumInvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumInvoiceAmount.SizeF = New System.Drawing.SizeF(122.9167!, 19.00003!)
            Me.LabelReportFooter_SumInvoiceAmount.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumInvoiceAmount.Summary = XrSummary2
            Me.LabelReportFooter_SumInvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(864.5417!, 4.083347!)
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
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
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
            'Invoice
            '
            Me.Invoice.Name = "Invoice"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport)
            '
            'ClientInvoiceBatchSummaryReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Invoice})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
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
        Private WithEvents LabelDetail_ClientLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_DivisionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ProductLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GLTransLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_PostingPeriodLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DescriptionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelDetail_OfficeLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_InvoiceNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_InvoiceAmountLabel As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents Invoice As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetail_OfficeCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ProductCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DivisionCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ClientCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLTransaction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PostPeriodCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_InvoiceDateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SumInvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_AR As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ARLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_NumberOfInvoices As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_NumberOfInvoicesLabel As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
