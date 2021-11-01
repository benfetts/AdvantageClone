Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class IncomeOnlyBatchReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Tax = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TaxLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Commission = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_CommissionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_QuantityLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Quantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_RateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_StatusLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TaxCodeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_FunctionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ComponentLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_JobLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Component = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Function = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Reference = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ProductCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DivisionCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineDetail_Break = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelDetail_ReferenceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DivisionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ProductLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_BatchTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_LineThin = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_InvoiceAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SalesTaxLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_TotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_InvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SalesTax = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_CommissionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_Commission = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LineReportFooter_Line = New DevExpress.XtraReports.UI.XRLine()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.LabelDetail_Tax, Me.LabelDetail_Total, Me.LabelDetail_TaxLabel, Me.LabelDetail_TotalLabel, Me.LabelDetail_Commission, Me.LabelDetail_CommissionLabel, Me.LabelDetail_Amount, Me.LabelDetail_AmountLabel, Me.LabelDetail_QuantityLabel, Me.LabelDetail_Quantity, Me.LabelDetail_RateLabel, Me.LabelDetail_Rate, Me.LabelDetail_Status, Me.LabelDetail_TaxCode, Me.LabelDetail_Date, Me.LabelDetail_StatusLabel, Me.LabelDetail_TaxCodeLabel, Me.LabelDetail_DateLabel, Me.LabelDetail_FunctionLabel, Me.LabelDetail_ComponentLabel, Me.LabelDetail_JobLabel, Me.LabelDetail_Job, Me.LabelDetail_Component, Me.LabelDetail_Function, Me.LabelDetail_Reference, Me.LabelDetail_ProductCode, Me.LabelDetail_DivisionCode, Me.LabelDetail_ClientCode, Me.LineDetail_Break, Me.LabelDetail_ReferenceLabel, Me.LabelDetail_ClientLabel, Me.LabelDetail_DivisionLabel, Me.LabelDetail_ProductLabel})
            Me.Detail.HeightF = 155.0002!
            Me.Detail.KeepTogetherWithDetailReports = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CommissionPercent", "{0:f3}%")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(666.6669!, 90.00002!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(82.33313!, 18.99998!)
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            Me.XrLabel1.Text = "XrLabel1"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Tax
            '
            Me.LabelDetail_Tax.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelDetail_Tax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Taxes", "{0:c2}")})
            Me.LabelDetail_Tax.LocationFloat = New DevExpress.Utils.PointFloat(530.6248!, 109.0!)
            Me.LabelDetail_Tax.Name = "LabelDetail_Tax"
            Me.LabelDetail_Tax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Tax.SizeF = New System.Drawing.SizeF(125.6253!, 18.99998!)
            Me.LabelDetail_Tax.StylePriority.UseBorders = False
            Me.LabelDetail_Tax.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Tax.Text = "LabelDetail_Tax"
            Me.LabelDetail_Tax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Total
            '
            Me.LabelDetail_Total.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            Me.LabelDetail_Total.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelDetail_Total.BorderWidth = 1
            Me.LabelDetail_Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount", "{0:c2}")})
            Me.LabelDetail_Total.LocationFloat = New DevExpress.Utils.PointFloat(530.6248!, 128.0!)
            Me.LabelDetail_Total.Name = "LabelDetail_Total"
            Me.LabelDetail_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Total.SizeF = New System.Drawing.SizeF(125.6253!, 18.99998!)
            Me.LabelDetail_Total.StylePriority.UseBorderDashStyle = False
            Me.LabelDetail_Total.StylePriority.UseBorders = False
            Me.LabelDetail_Total.StylePriority.UseBorderWidth = False
            Me.LabelDetail_Total.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Total.Text = "LabelDetail_Total"
            Me.LabelDetail_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_TaxLabel
            '
            Me.LabelDetail_TaxLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TaxLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TaxLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TaxLabel.BorderWidth = 1
            Me.LabelDetail_TaxLabel.CanGrow = False
            Me.LabelDetail_TaxLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TaxLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TaxLabel.LocationFloat = New DevExpress.Utils.PointFloat(449.3751!, 109.0!)
            Me.LabelDetail_TaxLabel.Name = "LabelDetail_TaxLabel"
            Me.LabelDetail_TaxLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TaxLabel.SizeF = New System.Drawing.SizeF(81.24973!, 19.0!)
            Me.LabelDetail_TaxLabel.StylePriority.UseFont = False
            Me.LabelDetail_TaxLabel.Text = "Tax:"
            Me.LabelDetail_TaxLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TotalLabel
            '
            Me.LabelDetail_TotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TotalLabel.BorderWidth = 1
            Me.LabelDetail_TotalLabel.CanGrow = False
            Me.LabelDetail_TotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(449.3748!, 128.0!)
            Me.LabelDetail_TotalLabel.Name = "LabelDetail_TotalLabel"
            Me.LabelDetail_TotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TotalLabel.SizeF = New System.Drawing.SizeF(81.24966!, 19.0!)
            Me.LabelDetail_TotalLabel.StylePriority.UseFont = False
            Me.LabelDetail_TotalLabel.Text = "Total:"
            Me.LabelDetail_TotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Commission
            '
            Me.LabelDetail_Commission.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupAmount", "{0:c2}")})
            Me.LabelDetail_Commission.LocationFloat = New DevExpress.Utils.PointFloat(530.6248!, 90.00002!)
            Me.LabelDetail_Commission.Name = "LabelDetail_Commission"
            Me.LabelDetail_Commission.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Commission.SizeF = New System.Drawing.SizeF(125.6253!, 18.99998!)
            Me.LabelDetail_Commission.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Commission.Text = "LabelDetail_Commission"
            Me.LabelDetail_Commission.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_CommissionLabel
            '
            Me.LabelDetail_CommissionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_CommissionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_CommissionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_CommissionLabel.BorderWidth = 1
            Me.LabelDetail_CommissionLabel.CanGrow = False
            Me.LabelDetail_CommissionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_CommissionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_CommissionLabel.LocationFloat = New DevExpress.Utils.PointFloat(449.3748!, 89.99998!)
            Me.LabelDetail_CommissionLabel.Name = "LabelDetail_CommissionLabel"
            Me.LabelDetail_CommissionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_CommissionLabel.SizeF = New System.Drawing.SizeF(81.24966!, 19.0!)
            Me.LabelDetail_CommissionLabel.StylePriority.UseFont = False
            Me.LabelDetail_CommissionLabel.Text = "Commission:"
            Me.LabelDetail_CommissionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Amount
            '
            Me.LabelDetail_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:c2}")})
            Me.LabelDetail_Amount.LocationFloat = New DevExpress.Utils.PointFloat(530.6248!, 71.00003!)
            Me.LabelDetail_Amount.Name = "LabelDetail_Amount"
            Me.LabelDetail_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Amount.SizeF = New System.Drawing.SizeF(125.6253!, 18.99998!)
            Me.LabelDetail_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Amount.Text = "LabelDetail_Amount"
            Me.LabelDetail_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_AmountLabel
            '
            Me.LabelDetail_AmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AmountLabel.BorderWidth = 1
            Me.LabelDetail_AmountLabel.CanGrow = False
            Me.LabelDetail_AmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(449.3751!, 71.0!)
            Me.LabelDetail_AmountLabel.Name = "LabelDetail_AmountLabel"
            Me.LabelDetail_AmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AmountLabel.SizeF = New System.Drawing.SizeF(81.24973!, 19.0!)
            Me.LabelDetail_AmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AmountLabel.Text = "Amount:"
            Me.LabelDetail_AmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_QuantityLabel
            '
            Me.LabelDetail_QuantityLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_QuantityLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_QuantityLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_QuantityLabel.BorderWidth = 1
            Me.LabelDetail_QuantityLabel.CanGrow = False
            Me.LabelDetail_QuantityLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_QuantityLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_QuantityLabel.LocationFloat = New DevExpress.Utils.PointFloat(279.9167!, 71.0!)
            Me.LabelDetail_QuantityLabel.Name = "LabelDetail_QuantityLabel"
            Me.LabelDetail_QuantityLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_QuantityLabel.SizeF = New System.Drawing.SizeF(57.29138!, 19.0!)
            Me.LabelDetail_QuantityLabel.StylePriority.UseFont = False
            Me.LabelDetail_QuantityLabel.Text = "Quantity:"
            Me.LabelDetail_QuantityLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Quantity
            '
            Me.LabelDetail_Quantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Quantity", "{0:f2}")})
            Me.LabelDetail_Quantity.LocationFloat = New DevExpress.Utils.PointFloat(337.2081!, 71.0!)
            Me.LabelDetail_Quantity.Name = "LabelDetail_Quantity"
            Me.LabelDetail_Quantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Quantity.SizeF = New System.Drawing.SizeF(79.79205!, 18.99998!)
            Me.LabelDetail_Quantity.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Quantity.Text = "LabelDetail_Quantity"
            Me.LabelDetail_Quantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_RateLabel
            '
            Me.LabelDetail_RateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_RateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_RateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_RateLabel.BorderWidth = 1
            Me.LabelDetail_RateLabel.CanGrow = False
            Me.LabelDetail_RateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_RateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_RateLabel.LocationFloat = New DevExpress.Utils.PointFloat(279.9165!, 89.99998!)
            Me.LabelDetail_RateLabel.Name = "LabelDetail_RateLabel"
            Me.LabelDetail_RateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_RateLabel.SizeF = New System.Drawing.SizeF(57.29138!, 19.0!)
            Me.LabelDetail_RateLabel.StylePriority.UseFont = False
            Me.LabelDetail_RateLabel.Text = "Rate:"
            Me.LabelDetail_RateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Rate
            '
            Me.LabelDetail_Rate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Rate", "{0:f4}")})
            Me.LabelDetail_Rate.LocationFloat = New DevExpress.Utils.PointFloat(337.2081!, 89.99998!)
            Me.LabelDetail_Rate.Name = "LabelDetail_Rate"
            Me.LabelDetail_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Rate.SizeF = New System.Drawing.SizeF(79.79205!, 18.99998!)
            Me.LabelDetail_Rate.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Rate.Text = "LabelDetail_Rate"
            Me.LabelDetail_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Status
            '
            Me.LabelDetail_Status.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Status")})
            Me.LabelDetail_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Status.LocationFloat = New DevExpress.Utils.PointFloat(73.95847!, 128.0!)
            Me.LabelDetail_Status.Name = "LabelDetail_Status"
            Me.LabelDetail_Status.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Status.SizeF = New System.Drawing.SizeF(176.042!, 18.99998!)
            Me.LabelDetail_Status.StylePriority.UseFont = False
            Me.LabelDetail_Status.Text = "LabelDetail_Status"
            '
            'LabelDetail_TaxCode
            '
            Me.LabelDetail_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxCode")})
            Me.LabelDetail_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(73.95846!, 109.0!)
            Me.LabelDetail_TaxCode.Name = "LabelDetail_TaxCode"
            Me.LabelDetail_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_TaxCode.SizeF = New System.Drawing.SizeF(176.0419!, 18.99998!)
            Me.LabelDetail_TaxCode.Text = "LabelDetail_TaxCode"
            '
            'LabelDetail_Date
            '
            Me.LabelDetail_Date.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelDetail_Date.LocationFloat = New DevExpress.Utils.PointFloat(73.95847!, 89.99998!)
            Me.LabelDetail_Date.Name = "LabelDetail_Date"
            Me.LabelDetail_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Date.SizeF = New System.Drawing.SizeF(176.042!, 18.99998!)
            Me.LabelDetail_Date.Text = "LabelDetail_Date"
            '
            'LabelDetail_StatusLabel
            '
            Me.LabelDetail_StatusLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_StatusLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_StatusLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_StatusLabel.BorderWidth = 1
            Me.LabelDetail_StatusLabel.CanGrow = False
            Me.LabelDetail_StatusLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_StatusLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_StatusLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 128.0!)
            Me.LabelDetail_StatusLabel.Name = "LabelDetail_StatusLabel"
            Me.LabelDetail_StatusLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_StatusLabel.SizeF = New System.Drawing.SizeF(73.95803!, 19.0!)
            Me.LabelDetail_StatusLabel.StylePriority.UseFont = False
            Me.LabelDetail_StatusLabel.Text = "Status:"
            Me.LabelDetail_StatusLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TaxCodeLabel
            '
            Me.LabelDetail_TaxCodeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TaxCodeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TaxCodeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TaxCodeLabel.BorderWidth = 1
            Me.LabelDetail_TaxCodeLabel.CanGrow = False
            Me.LabelDetail_TaxCodeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TaxCodeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TaxCodeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 109.0!)
            Me.LabelDetail_TaxCodeLabel.Name = "LabelDetail_TaxCodeLabel"
            Me.LabelDetail_TaxCodeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TaxCodeLabel.SizeF = New System.Drawing.SizeF(73.95803!, 19.0!)
            Me.LabelDetail_TaxCodeLabel.StylePriority.UseFont = False
            Me.LabelDetail_TaxCodeLabel.Text = "Tax Code:"
            Me.LabelDetail_TaxCodeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DateLabel
            '
            Me.LabelDetail_DateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateLabel.BorderWidth = 1
            Me.LabelDetail_DateLabel.CanGrow = False
            Me.LabelDetail_DateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 89.99998!)
            Me.LabelDetail_DateLabel.Name = "LabelDetail_DateLabel"
            Me.LabelDetail_DateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateLabel.SizeF = New System.Drawing.SizeF(73.95803!, 19.0!)
            Me.LabelDetail_DateLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateLabel.Text = "Date:"
            Me.LabelDetail_DateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_FunctionLabel
            '
            Me.LabelDetail_FunctionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_FunctionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_FunctionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_FunctionLabel.BorderWidth = 1
            Me.LabelDetail_FunctionLabel.CanGrow = False
            Me.LabelDetail_FunctionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_FunctionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_FunctionLabel.LocationFloat = New DevExpress.Utils.PointFloat(382.2918!, 40.99998!)
            Me.LabelDetail_FunctionLabel.Name = "LabelDetail_FunctionLabel"
            Me.LabelDetail_FunctionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_FunctionLabel.SizeF = New System.Drawing.SizeF(73.95825!, 19.0!)
            Me.LabelDetail_FunctionLabel.StylePriority.UseFont = False
            Me.LabelDetail_FunctionLabel.Text = "Function:"
            Me.LabelDetail_FunctionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ComponentLabel
            '
            Me.LabelDetail_ComponentLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ComponentLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ComponentLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ComponentLabel.BorderWidth = 1
            Me.LabelDetail_ComponentLabel.CanGrow = False
            Me.LabelDetail_ComponentLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ComponentLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ComponentLabel.LocationFloat = New DevExpress.Utils.PointFloat(382.292!, 21.99999!)
            Me.LabelDetail_ComponentLabel.Name = "LabelDetail_ComponentLabel"
            Me.LabelDetail_ComponentLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ComponentLabel.SizeF = New System.Drawing.SizeF(73.95825!, 19.0!)
            Me.LabelDetail_ComponentLabel.StylePriority.UseFont = False
            Me.LabelDetail_ComponentLabel.Text = "Component:"
            Me.LabelDetail_ComponentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_JobLabel
            '
            Me.LabelDetail_JobLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_JobLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_JobLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_JobLabel.BorderWidth = 1
            Me.LabelDetail_JobLabel.CanGrow = False
            Me.LabelDetail_JobLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_JobLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_JobLabel.LocationFloat = New DevExpress.Utils.PointFloat(382.2918!, 3.0!)
            Me.LabelDetail_JobLabel.Name = "LabelDetail_JobLabel"
            Me.LabelDetail_JobLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_JobLabel.SizeF = New System.Drawing.SizeF(73.95825!, 19.0!)
            Me.LabelDetail_JobLabel.StylePriority.UseFont = False
            Me.LabelDetail_JobLabel.Text = "Job:"
            Me.LabelDetail_JobLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Job
            '
            Me.LabelDetail_Job.LocationFloat = New DevExpress.Utils.PointFloat(456.2501!, 3.0!)
            Me.LabelDetail_Job.Name = "LabelDetail_Job"
            Me.LabelDetail_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Job.SizeF = New System.Drawing.SizeF(293.7499!, 18.99999!)
            Me.LabelDetail_Job.Text = "[JobNumber] - [JobDescription]"
            '
            'LabelDetail_Component
            '
            Me.LabelDetail_Component.LocationFloat = New DevExpress.Utils.PointFloat(456.2501!, 21.99999!)
            Me.LabelDetail_Component.Name = "LabelDetail_Component"
            Me.LabelDetail_Component.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Component.SizeF = New System.Drawing.SizeF(293.7499!, 19.00001!)
            Me.LabelDetail_Component.Text = "[JobComponentNumber] - [JobComponentDescription]"
            '
            'LabelDetail_Function
            '
            Me.LabelDetail_Function.LocationFloat = New DevExpress.Utils.PointFloat(456.2501!, 41.00004!)
            Me.LabelDetail_Function.Name = "LabelDetail_Function"
            Me.LabelDetail_Function.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Function.SizeF = New System.Drawing.SizeF(293.7499!, 18.99998!)
            Me.LabelDetail_Function.Text = "[FunctionCode] - [FunctionDescription]"
            '
            'LabelDetail_Reference
            '
            Me.LabelDetail_Reference.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ReferenceNumber")})
            Me.LabelDetail_Reference.LocationFloat = New DevExpress.Utils.PointFloat(73.95847!, 71.0!)
            Me.LabelDetail_Reference.Name = "LabelDetail_Reference"
            Me.LabelDetail_Reference.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Reference.SizeF = New System.Drawing.SizeF(176.042!, 18.99998!)
            Me.LabelDetail_Reference.Text = "LabelDetail_Reference"
            '
            'LabelDetail_ProductCode
            '
            Me.LabelDetail_ProductCode.LocationFloat = New DevExpress.Utils.PointFloat(73.95847!, 41.00001!)
            Me.LabelDetail_ProductCode.Name = "LabelDetail_ProductCode"
            Me.LabelDetail_ProductCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ProductCode.SizeF = New System.Drawing.SizeF(293.7499!, 18.99998!)
            Me.LabelDetail_ProductCode.Text = "[ProductCode] - [ProductName]"
            '
            'LabelDetail_DivisionCode
            '
            Me.LabelDetail_DivisionCode.LocationFloat = New DevExpress.Utils.PointFloat(73.95847!, 21.99999!)
            Me.LabelDetail_DivisionCode.Name = "LabelDetail_DivisionCode"
            Me.LabelDetail_DivisionCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_DivisionCode.SizeF = New System.Drawing.SizeF(293.7499!, 19.00001!)
            Me.LabelDetail_DivisionCode.Text = "[DivisionCode] - [DivisionName]"
            '
            'LabelDetail_ClientCode
            '
            Me.LabelDetail_ClientCode.LocationFloat = New DevExpress.Utils.PointFloat(73.95847!, 3.0!)
            Me.LabelDetail_ClientCode.Name = "LabelDetail_ClientCode"
            Me.LabelDetail_ClientCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_ClientCode.SizeF = New System.Drawing.SizeF(293.7499!, 18.99999!)
            Me.LabelDetail_ClientCode.Text = "[ClientCode] - [ClientName]"
            '
            'LineDetail_Break
            '
            Me.LineDetail_Break.BorderColor = System.Drawing.Color.Silver
            Me.LineDetail_Break.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineDetail_Break.BorderWidth = 1
            Me.LineDetail_Break.ForeColor = System.Drawing.Color.Silver
            Me.LineDetail_Break.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 153.0002!)
            Me.LineDetail_Break.Name = "LineDetail_Break"
            Me.LineDetail_Break.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            Me.LineDetail_Break.StylePriority.UseBorderWidth = False
            '
            'LabelDetail_ReferenceLabel
            '
            Me.LabelDetail_ReferenceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ReferenceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ReferenceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ReferenceLabel.BorderWidth = 1
            Me.LabelDetail_ReferenceLabel.CanGrow = False
            Me.LabelDetail_ReferenceLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ReferenceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ReferenceLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.000222524!, 71.0!)
            Me.LabelDetail_ReferenceLabel.Name = "LabelDetail_ReferenceLabel"
            Me.LabelDetail_ReferenceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ReferenceLabel.SizeF = New System.Drawing.SizeF(73.95803!, 19.0!)
            Me.LabelDetail_ReferenceLabel.StylePriority.UseFont = False
            Me.LabelDetail_ReferenceLabel.Text = "Reference:"
            Me.LabelDetail_ReferenceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ClientLabel
            '
            Me.LabelDetail_ClientLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ClientLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ClientLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ClientLabel.BorderWidth = 1
            Me.LabelDetail_ClientLabel.CanGrow = False
            Me.LabelDetail_ClientLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ClientLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 3.0!)
            Me.LabelDetail_ClientLabel.Name = "LabelDetail_ClientLabel"
            Me.LabelDetail_ClientLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ClientLabel.SizeF = New System.Drawing.SizeF(73.95825!, 19.0!)
            Me.LabelDetail_ClientLabel.StylePriority.UseFont = False
            Me.LabelDetail_ClientLabel.Text = "Client:"
            Me.LabelDetail_ClientLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DivisionLabel
            '
            Me.LabelDetail_DivisionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DivisionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DivisionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DivisionLabel.BorderWidth = 1
            Me.LabelDetail_DivisionLabel.CanGrow = False
            Me.LabelDetail_DivisionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DivisionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DivisionLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.000222524!, 21.99999!)
            Me.LabelDetail_DivisionLabel.Name = "LabelDetail_DivisionLabel"
            Me.LabelDetail_DivisionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DivisionLabel.SizeF = New System.Drawing.SizeF(73.95825!, 19.0!)
            Me.LabelDetail_DivisionLabel.StylePriority.UseFont = False
            Me.LabelDetail_DivisionLabel.Text = "Division:"
            Me.LabelDetail_DivisionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ProductLabel
            '
            Me.LabelDetail_ProductLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ProductLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ProductLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ProductLabel.BorderWidth = 1
            Me.LabelDetail_ProductLabel.CanGrow = False
            Me.LabelDetail_ProductLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ProductLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ProductLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 40.99998!)
            Me.LabelDetail_ProductLabel.Name = "LabelDetail_ProductLabel"
            Me.LabelDetail_ProductLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ProductLabel.SizeF = New System.Drawing.SizeF(73.95825!, 19.0!)
            Me.LabelDetail_ProductLabel.StylePriority.UseFont = False
            Me.LabelDetail_ProductLabel.Text = "Product:"
            Me.LabelDetail_ProductLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.PageHeader.HeightF = 57.91668!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(511.4999!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(237.5001!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.Text = "Income Only Batch List"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LinePageHeader_Top.Name = "LinePageHeader_Top"
            Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'LabelPageHeader_ReportCriteria
            '
            Me.LabelPageHeader_ReportCriteria.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportCriteria.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportCriteria.BorderWidth = 1
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
            Me.LabelPageHeader_ReportTitle.BorderWidth = 1
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
            Me.LabelPageHeader_ReportTitle.Text = "Income Only Batch List"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 53.83333!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'PageInfo_Pages
            '
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
            Me.PageFooter.HeightF = 25.08332!
            Me.PageFooter.Name = "PageFooter"
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'LabelPageFooter_UserCode
            '
            Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_UserCode.BorderWidth = 1
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
            Me.LabelPageFooter_Date.BorderWidth = 1
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
            'LabelReportFooter_BatchTotalLabel
            '
            Me.LabelReportFooter_BatchTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_BatchTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_BatchTotalLabel.BorderWidth = 1
            Me.LabelReportFooter_BatchTotalLabel.CanGrow = False
            Me.LabelReportFooter_BatchTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_BatchTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 4.0!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(79.16654!, 19.0!)
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotalLabel.Text = "Batch Total:"
            Me.LabelReportFooter_BatchTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineReportFooter_LineThin
            '
            Me.LineReportFooter_LineThin.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_LineThin.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_LineThin.BorderWidth = 0
            Me.LineReportFooter_LineThin.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_LineThin.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 2.0!)
            Me.LineReportFooter_LineThin.Name = "LineReportFooter_LineThin"
            Me.LineReportFooter_LineThin.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            Me.LineReportFooter_LineThin.StylePriority.UseBorderColor = False
            Me.LineReportFooter_LineThin.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_LineThin.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_InvoiceAmountLabel
            '
            Me.LabelReportFooter_InvoiceAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_InvoiceAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_InvoiceAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_InvoiceAmountLabel.BorderWidth = 1
            Me.LabelReportFooter_InvoiceAmountLabel.CanGrow = False
            Me.LabelReportFooter_InvoiceAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_InvoiceAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_InvoiceAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(99.99997!, 4.0!)
            Me.LabelReportFooter_InvoiceAmountLabel.Name = "LabelReportFooter_InvoiceAmountLabel"
            Me.LabelReportFooter_InvoiceAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_InvoiceAmountLabel.SizeF = New System.Drawing.SizeF(150.0002!, 19.0!)
            Me.LabelReportFooter_InvoiceAmountLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_InvoiceAmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_InvoiceAmountLabel.Text = "Invoice:"
            Me.LabelReportFooter_InvoiceAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelReportFooter_SalesTaxLabel
            '
            Me.LabelReportFooter_SalesTaxLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_SalesTaxLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_SalesTaxLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_SalesTaxLabel.BorderWidth = 1
            Me.LabelReportFooter_SalesTaxLabel.CanGrow = False
            Me.LabelReportFooter_SalesTaxLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_SalesTaxLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_SalesTaxLabel.LocationFloat = New DevExpress.Utils.PointFloat(99.99994!, 42.00001!)
            Me.LabelReportFooter_SalesTaxLabel.Name = "LabelReportFooter_SalesTaxLabel"
            Me.LabelReportFooter_SalesTaxLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_SalesTaxLabel.SizeF = New System.Drawing.SizeF(150.0002!, 19.0!)
            Me.LabelReportFooter_SalesTaxLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_SalesTaxLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_SalesTaxLabel.Text = "Sales Tax:"
            Me.LabelReportFooter_SalesTaxLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelReportFooter_TotalLabel
            '
            Me.LabelReportFooter_TotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_TotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_TotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_TotalLabel.BorderWidth = 1
            Me.LabelReportFooter_TotalLabel.CanGrow = False
            Me.LabelReportFooter_TotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_TotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_TotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(99.99994!, 61.0!)
            Me.LabelReportFooter_TotalLabel.Name = "LabelReportFooter_TotalLabel"
            Me.LabelReportFooter_TotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_TotalLabel.SizeF = New System.Drawing.SizeF(150.0002!, 19.0!)
            Me.LabelReportFooter_TotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_TotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_TotalLabel.Text = "Total:"
            Me.LabelReportFooter_TotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelReportFooter_InvoiceAmount
            '
            Me.LabelReportFooter_InvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.LabelReportFooter_InvoiceAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportFooter_InvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(250.0001!, 4.0!)
            Me.LabelReportFooter_InvoiceAmount.Name = "LabelReportFooter_InvoiceAmount"
            Me.LabelReportFooter_InvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_InvoiceAmount.SizeF = New System.Drawing.SizeF(150.0!, 19.00003!)
            Me.LabelReportFooter_InvoiceAmount.StylePriority.UseFont = False
            Me.LabelReportFooter_InvoiceAmount.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:c2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_InvoiceAmount.Summary = XrSummary1
            Me.LabelReportFooter_InvoiceAmount.Text = "LabelReportFooter_InvoiceAmount"
            Me.LabelReportFooter_InvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_Total
            '
            Me.LabelReportFooter_Total.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelReportFooter_Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.LabelReportFooter_Total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportFooter_Total.LocationFloat = New DevExpress.Utils.PointFloat(250.0002!, 61.0!)
            Me.LabelReportFooter_Total.Name = "LabelReportFooter_Total"
            Me.LabelReportFooter_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_Total.SizeF = New System.Drawing.SizeF(150.0!, 19.0!)
            Me.LabelReportFooter_Total.StylePriority.UseBorders = False
            Me.LabelReportFooter_Total.StylePriority.UseFont = False
            Me.LabelReportFooter_Total.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:c2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_Total.Summary = XrSummary2
            Me.LabelReportFooter_Total.Text = "LabelReportFooter_Total"
            Me.LabelReportFooter_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_SalesTax
            '
            Me.LabelReportFooter_SalesTax.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelReportFooter_SalesTax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Taxes")})
            Me.LabelReportFooter_SalesTax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportFooter_SalesTax.LocationFloat = New DevExpress.Utils.PointFloat(250.0002!, 42.00001!)
            Me.LabelReportFooter_SalesTax.Name = "LabelReportFooter_SalesTax"
            Me.LabelReportFooter_SalesTax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SalesTax.SizeF = New System.Drawing.SizeF(150.0!, 19.0!)
            Me.LabelReportFooter_SalesTax.StylePriority.UseBorders = False
            Me.LabelReportFooter_SalesTax.StylePriority.UseFont = False
            Me.LabelReportFooter_SalesTax.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:c2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SalesTax.Summary = XrSummary3
            Me.LabelReportFooter_SalesTax.Text = "LabelReportFooter_SalesTax"
            Me.LabelReportFooter_SalesTax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_CommissionLabel
            '
            Me.LabelReportFooter_CommissionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_CommissionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_CommissionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_CommissionLabel.BorderWidth = 1
            Me.LabelReportFooter_CommissionLabel.CanGrow = False
            Me.LabelReportFooter_CommissionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_CommissionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_CommissionLabel.LocationFloat = New DevExpress.Utils.PointFloat(100.0002!, 23.00002!)
            Me.LabelReportFooter_CommissionLabel.Name = "LabelReportFooter_CommissionLabel"
            Me.LabelReportFooter_CommissionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_CommissionLabel.SizeF = New System.Drawing.SizeF(150.0002!, 19.0!)
            Me.LabelReportFooter_CommissionLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_CommissionLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_CommissionLabel.Text = "Commission:"
            Me.LabelReportFooter_CommissionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelReportFooter_Commission
            '
            Me.LabelReportFooter_Commission.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupAmount")})
            Me.LabelReportFooter_Commission.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportFooter_Commission.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 23.00021!)
            Me.LabelReportFooter_Commission.Name = "LabelReportFooter_Commission"
            Me.LabelReportFooter_Commission.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_Commission.SizeF = New System.Drawing.SizeF(150.0002!, 18.9998!)
            Me.LabelReportFooter_Commission.StylePriority.UseFont = False
            Me.LabelReportFooter_Commission.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:c2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_Commission.Summary = XrSummary4
            Me.LabelReportFooter_Commission.Text = "LabelReportFooter_Commission"
            Me.LabelReportFooter_Commission.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_Commission, Me.LabelReportFooter_CommissionLabel, Me.LabelReportFooter_SalesTax, Me.LabelReportFooter_Total, Me.LabelReportFooter_InvoiceAmount, Me.LabelReportFooter_TotalLabel, Me.LabelReportFooter_SalesTaxLabel, Me.LabelReportFooter_InvoiceAmountLabel, Me.LineReportFooter_LineThin, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_Line})
            Me.ReportFooter.HeightF = 80.0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LineReportFooter_Line
            '
            Me.LineReportFooter_Line.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_Line.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_Line.BorderWidth = 0
            Me.LineReportFooter_Line.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_Line.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LineReportFooter_Line.Name = "LineReportFooter_Line"
            Me.LineReportFooter_Line.SizeF = New System.Drawing.SizeF(750.0!, 2.0!)
            Me.LineReportFooter_Line.StylePriority.UseBorderColor = False
            Me.LineReportFooter_Line.StylePriority.UseBorders = False
            Me.LineReportFooter_Line.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_Line.StylePriority.UseForeColor = False
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.IncomeOnly.Classes.IncomeOnlyBatchReport)
            '
            'IncomeOnlyBatchReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
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
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ReferenceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineDetail_Break As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetail_Reference As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ProductCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_DivisionCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_ClientCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Tax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Total As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_TaxLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_TotalLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Commission As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_CommissionLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_AmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_QuantityLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Quantity As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_RateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Status As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_StatusLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_TaxCodeLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_FunctionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ComponentLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_JobLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Job As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Component As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Function As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_BatchTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_LineThin As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelReportFooter_InvoiceAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_SalesTaxLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_TotalLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_InvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SalesTax As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_CommissionLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_Commission As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_Line As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
