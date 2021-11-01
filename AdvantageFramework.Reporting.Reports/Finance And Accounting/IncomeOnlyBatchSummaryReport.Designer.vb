Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class IncomeOnlyBatchSummaryReport
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
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Commission = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Quantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Component = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Function = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_MarkupAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Quantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Function = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ComponentLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelHeader_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Taxes = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_TaxCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_CreateModifyDeleteDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_BatchTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_LineThin = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_InvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_SalesTax = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_Commission = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LineReportFooter_Line = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupHeaderClientDivisionProduct = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupFooterClientDivisionProduct = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.GroupHeaderIncomeOnlyID = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooterIncomeOnlyID = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.LabelDetail_Total, Me.LabelDetail_Commission, Me.LabelDetail_Amount, Me.LabelDetail_Quantity, Me.LabelDetail_Rate, Me.LabelDetail_TaxCode, Me.LabelDetail_Date, Me.LabelDetail_Job, Me.LabelDetail_Component, Me.LabelDetail_Function})
            Me.Detail.HeightF = 26.16669!
            Me.Detail.KeepTogetherWithDetailReports = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SequenceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ModifyDate", "{0:d}")})
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(920.7918!, 3.000037!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(79.20813!, 18.99998!)
            Me.XrLabel3.Text = "XrLabel3"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Status")})
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(837.6251!, 3.000005!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(79.16667!, 18.99998!)
            Me.XrLabel2.Text = "XrLabel2"
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Taxes", "{0:f2}")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(618.3334!, 3.000037!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(65.62494!, 18.99998!)
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            Me.XrLabel1.Text = "XrLabel1"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Total
            '
            Me.LabelDetail_Total.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            Me.LabelDetail_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Total.BorderWidth = 1
            Me.LabelDetail_Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount", "{0:c2}")})
            Me.LabelDetail_Total.LocationFloat = New DevExpress.Utils.PointFloat(687.9584!, 3.000037!)
            Me.LabelDetail_Total.Name = "LabelDetail_Total"
            Me.LabelDetail_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Total.SizeF = New System.Drawing.SizeF(79.16675!, 18.99998!)
            Me.LabelDetail_Total.StylePriority.UseBorderDashStyle = False
            Me.LabelDetail_Total.StylePriority.UseBorders = False
            Me.LabelDetail_Total.StylePriority.UseBorderWidth = False
            Me.LabelDetail_Total.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Total.Text = "LabelDetail_Total"
            Me.LabelDetail_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Commission
            '
            Me.LabelDetail_Commission.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupAmount", "{0:c2}")})
            Me.LabelDetail_Commission.LocationFloat = New DevExpress.Utils.PointFloat(535.1667!, 3.000037!)
            Me.LabelDetail_Commission.Name = "LabelDetail_Commission"
            Me.LabelDetail_Commission.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Commission.SizeF = New System.Drawing.SizeF(79.16667!, 18.99998!)
            Me.LabelDetail_Commission.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Commission.Text = "LabelDetail_Commission"
            Me.LabelDetail_Commission.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Amount
            '
            Me.LabelDetail_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:c2}")})
            Me.LabelDetail_Amount.LocationFloat = New DevExpress.Utils.PointFloat(452.0!, 3.000037!)
            Me.LabelDetail_Amount.Name = "LabelDetail_Amount"
            Me.LabelDetail_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Amount.SizeF = New System.Drawing.SizeF(79.16667!, 18.99998!)
            Me.LabelDetail_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Amount.Text = "LabelDetail_Amount"
            Me.LabelDetail_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Quantity
            '
            Me.LabelDetail_Quantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Quantity", "{0:f2}")})
            Me.LabelDetail_Quantity.LocationFloat = New DevExpress.Utils.PointFloat(285.6667!, 3.000037!)
            Me.LabelDetail_Quantity.Name = "LabelDetail_Quantity"
            Me.LabelDetail_Quantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Quantity.SizeF = New System.Drawing.SizeF(79.16667!, 18.99998!)
            Me.LabelDetail_Quantity.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Quantity.Text = "LabelDetail_Quantity"
            Me.LabelDetail_Quantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Rate
            '
            Me.LabelDetail_Rate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Rate", "{0:f4}")})
            Me.LabelDetail_Rate.LocationFloat = New DevExpress.Utils.PointFloat(368.8333!, 3.000005!)
            Me.LabelDetail_Rate.Name = "LabelDetail_Rate"
            Me.LabelDetail_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Rate.SizeF = New System.Drawing.SizeF(79.16667!, 18.99998!)
            Me.LabelDetail_Rate.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Rate.Text = "LabelDetail_Rate"
            Me.LabelDetail_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_TaxCode
            '
            Me.LabelDetail_TaxCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxCode")})
            Me.LabelDetail_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(771.1251!, 3.000005!)
            Me.LabelDetail_TaxCode.Name = "LabelDetail_TaxCode"
            Me.LabelDetail_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_TaxCode.SizeF = New System.Drawing.SizeF(62.50006!, 18.99998!)
            Me.LabelDetail_TaxCode.Text = "LabelDetail_TaxCode"
            '
            'LabelDetail_Date
            '
            Me.LabelDetail_Date.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelDetail_Date.LocationFloat = New DevExpress.Utils.PointFloat(202.5!, 3.000037!)
            Me.LabelDetail_Date.Name = "LabelDetail_Date"
            Me.LabelDetail_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Date.SizeF = New System.Drawing.SizeF(79.16667!, 18.99998!)
            Me.LabelDetail_Date.Text = "LabelDetail_Date"
            '
            'LabelDetail_Job
            '
            Me.LabelDetail_Job.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 3.000037!)
            Me.LabelDetail_Job.Name = "LabelDetail_Job"
            Me.LabelDetail_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Job.SizeF = New System.Drawing.SizeF(79.16653!, 18.99999!)
            Me.LabelDetail_Job.Text = "[JobNumber]"
            '
            'LabelDetail_Component
            '
            Me.LabelDetail_Component.LocationFloat = New DevExpress.Utils.PointFloat(83.16666!, 3.000005!)
            Me.LabelDetail_Component.Name = "LabelDetail_Component"
            Me.LabelDetail_Component.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Component.SizeF = New System.Drawing.SizeF(46.87502!, 19.00001!)
            Me.LabelDetail_Component.Text = "[JobComponentNumber]"
            '
            'LabelDetail_Function
            '
            Me.LabelDetail_Function.LocationFloat = New DevExpress.Utils.PointFloat(134.3333!, 3.000037!)
            Me.LabelDetail_Function.Name = "LabelDetail_Function"
            Me.LabelDetail_Function.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Function.SizeF = New System.Drawing.SizeF(63.54167!, 18.99998!)
            Me.LabelDetail_Function.Text = "[FunctionCode]"
            '
            'LabelHeader_MarkupAmount
            '
            Me.LabelHeader_MarkupAmount.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_MarkupAmount.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_MarkupAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_MarkupAmount.BorderWidth = 1
            Me.LabelHeader_MarkupAmount.CanGrow = False
            Me.LabelHeader_MarkupAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_MarkupAmount.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_MarkupAmount.LocationFloat = New DevExpress.Utils.PointFloat(535.1667!, 104.5417!)
            Me.LabelHeader_MarkupAmount.Name = "LabelHeader_MarkupAmount"
            Me.LabelHeader_MarkupAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_MarkupAmount.SizeF = New System.Drawing.SizeF(79.16667!, 19.0!)
            Me.LabelHeader_MarkupAmount.StylePriority.UseFont = False
            Me.LabelHeader_MarkupAmount.StylePriority.UseTextAlignment = False
            Me.LabelHeader_MarkupAmount.Text = "Markup Amt"
            Me.LabelHeader_MarkupAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Amount
            '
            Me.LabelHeader_Amount.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Amount.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Amount.BorderWidth = 1
            Me.LabelHeader_Amount.CanGrow = False
            Me.LabelHeader_Amount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Amount.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Amount.LocationFloat = New DevExpress.Utils.PointFloat(452.0!, 104.5417!)
            Me.LabelHeader_Amount.Name = "LabelHeader_Amount"
            Me.LabelHeader_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Amount.SizeF = New System.Drawing.SizeF(79.16667!, 19.0!)
            Me.LabelHeader_Amount.StylePriority.UseFont = False
            Me.LabelHeader_Amount.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Amount.Text = "Amount"
            Me.LabelHeader_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Quantity
            '
            Me.LabelHeader_Quantity.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Quantity.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Quantity.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Quantity.BorderWidth = 1
            Me.LabelHeader_Quantity.CanGrow = False
            Me.LabelHeader_Quantity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Quantity.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Quantity.LocationFloat = New DevExpress.Utils.PointFloat(285.6667!, 104.5417!)
            Me.LabelHeader_Quantity.Name = "LabelHeader_Quantity"
            Me.LabelHeader_Quantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Quantity.SizeF = New System.Drawing.SizeF(79.16667!, 19.0!)
            Me.LabelHeader_Quantity.StylePriority.UseFont = False
            Me.LabelHeader_Quantity.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Quantity.Text = "Quantity"
            Me.LabelHeader_Quantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Rate
            '
            Me.LabelHeader_Rate.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Rate.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Rate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Rate.BorderWidth = 1
            Me.LabelHeader_Rate.CanGrow = False
            Me.LabelHeader_Rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Rate.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Rate.LocationFloat = New DevExpress.Utils.PointFloat(368.8333!, 104.5417!)
            Me.LabelHeader_Rate.Name = "LabelHeader_Rate"
            Me.LabelHeader_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Rate.SizeF = New System.Drawing.SizeF(79.16667!, 19.0!)
            Me.LabelHeader_Rate.StylePriority.UseFont = False
            Me.LabelHeader_Rate.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Rate.Text = "Rate"
            Me.LabelHeader_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Function
            '
            Me.LabelHeader_Function.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Function.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Function.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Function.BorderWidth = 1
            Me.LabelHeader_Function.CanGrow = False
            Me.LabelHeader_Function.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Function.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Function.LocationFloat = New DevExpress.Utils.PointFloat(134.3333!, 104.5417!)
            Me.LabelHeader_Function.Name = "LabelHeader_Function"
            Me.LabelHeader_Function.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Function.SizeF = New System.Drawing.SizeF(63.54167!, 19.0!)
            Me.LabelHeader_Function.StylePriority.UseFont = False
            Me.LabelHeader_Function.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Function.Text = "Function"
            Me.LabelHeader_Function.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
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
            Me.LabelDetail_ComponentLabel.LocationFloat = New DevExpress.Utils.PointFloat(83.16666!, 81.62502!)
            Me.LabelDetail_ComponentLabel.Multiline = True
            Me.LabelDetail_ComponentLabel.Name = "LabelDetail_ComponentLabel"
            Me.LabelDetail_ComponentLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ComponentLabel.SizeF = New System.Drawing.SizeF(46.87502!, 41.91667!)
            Me.LabelDetail_ComponentLabel.StylePriority.UseFont = False
            Me.LabelDetail_ComponentLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ComponentLabel.Text = "Job " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Comp"
            Me.LabelDetail_ComponentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Job
            '
            Me.LabelHeader_Job.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Job.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Job.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Job.BorderWidth = 1
            Me.LabelHeader_Job.CanGrow = False
            Me.LabelHeader_Job.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Job.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Job.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 104.5417!)
            Me.LabelHeader_Job.Name = "LabelHeader_Job"
            Me.LabelHeader_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Job.SizeF = New System.Drawing.SizeF(79.16667!, 19.0!)
            Me.LabelHeader_Job.StylePriority.UseFont = False
            Me.LabelHeader_Job.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Job.Text = "Job Number"
            Me.LabelHeader_Job.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle, Me.LinePageHeader_Bottom, Me.LabelHeader_Job, Me.LabelHeader_Amount, Me.LabelHeader_Rate, Me.LabelHeader_Quantity, Me.LabelHeader_Function, Me.LabelDetail_ComponentLabel, Me.LabelHeader_MarkupAmount, Me.LabelHeader_InvoiceDate, Me.LabelHeader_Taxes, Me.LabelHeader_Total, Me.LabelHeader_Status, Me.LabelHeader_TaxCode, Me.LabelHeader_CreateModifyDeleteDate, Me.XrLine1})
            Me.PageHeader.HeightF = 128.5417!
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(762.4999!, 4.083347!)
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
            Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(1000.0!, 4.083351!)
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
            Me.LabelPageHeader_ReportCriteria.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 33.08334!)
            Me.LabelPageHeader_ReportCriteria.Name = "LabelPageHeader_ReportCriteria"
            Me.LabelPageHeader_ReportCriteria.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportCriteria.SizeF = New System.Drawing.SizeF(762.4999!, 17.00001!)
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
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(762.4999!, 29.00001!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "Income Only Batch Report - Summary"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 53.83332!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(1000.0!, 4.083351!)
            '
            'LabelHeader_InvoiceDate
            '
            Me.LabelHeader_InvoiceDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_InvoiceDate.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_InvoiceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_InvoiceDate.BorderWidth = 1
            Me.LabelHeader_InvoiceDate.CanGrow = False
            Me.LabelHeader_InvoiceDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_InvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(202.5!, 104.5417!)
            Me.LabelHeader_InvoiceDate.Name = "LabelHeader_InvoiceDate"
            Me.LabelHeader_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_InvoiceDate.SizeF = New System.Drawing.SizeF(79.16667!, 19.0!)
            Me.LabelHeader_InvoiceDate.StylePriority.UseFont = False
            Me.LabelHeader_InvoiceDate.StylePriority.UseTextAlignment = False
            Me.LabelHeader_InvoiceDate.Text = "Invoice Date"
            Me.LabelHeader_InvoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Taxes
            '
            Me.LabelHeader_Taxes.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Taxes.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Taxes.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Taxes.BorderWidth = 1
            Me.LabelHeader_Taxes.CanGrow = False
            Me.LabelHeader_Taxes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Taxes.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Taxes.LocationFloat = New DevExpress.Utils.PointFloat(618.3334!, 104.5417!)
            Me.LabelHeader_Taxes.Name = "LabelHeader_Taxes"
            Me.LabelHeader_Taxes.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Taxes.SizeF = New System.Drawing.SizeF(65.625!, 19.0!)
            Me.LabelHeader_Taxes.StylePriority.UseFont = False
            Me.LabelHeader_Taxes.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Taxes.Text = "Taxes"
            Me.LabelHeader_Taxes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Total
            '
            Me.LabelHeader_Total.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Total.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Total.BorderWidth = 1
            Me.LabelHeader_Total.CanGrow = False
            Me.LabelHeader_Total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Total.LocationFloat = New DevExpress.Utils.PointFloat(687.9584!, 104.5417!)
            Me.LabelHeader_Total.Name = "LabelHeader_Total"
            Me.LabelHeader_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Total.SizeF = New System.Drawing.SizeF(79.16667!, 19.0!)
            Me.LabelHeader_Total.StylePriority.UseFont = False
            Me.LabelHeader_Total.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Total.Text = "Total"
            Me.LabelHeader_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Status
            '
            Me.LabelHeader_Status.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Status.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Status.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Status.BorderWidth = 1
            Me.LabelHeader_Status.CanGrow = False
            Me.LabelHeader_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Status.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Status.LocationFloat = New DevExpress.Utils.PointFloat(837.6251!, 104.5417!)
            Me.LabelHeader_Status.Name = "LabelHeader_Status"
            Me.LabelHeader_Status.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Status.SizeF = New System.Drawing.SizeF(79.16667!, 19.0!)
            Me.LabelHeader_Status.StylePriority.UseFont = False
            Me.LabelHeader_Status.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Status.Text = "Status"
            Me.LabelHeader_Status.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_TaxCode
            '
            Me.LabelHeader_TaxCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_TaxCode.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_TaxCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_TaxCode.BorderWidth = 1
            Me.LabelHeader_TaxCode.CanGrow = False
            Me.LabelHeader_TaxCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_TaxCode.LocationFloat = New DevExpress.Utils.PointFloat(771.1251!, 104.5417!)
            Me.LabelHeader_TaxCode.Name = "LabelHeader_TaxCode"
            Me.LabelHeader_TaxCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_TaxCode.SizeF = New System.Drawing.SizeF(62.50006!, 19.0!)
            Me.LabelHeader_TaxCode.StylePriority.UseFont = False
            Me.LabelHeader_TaxCode.StylePriority.UseTextAlignment = False
            Me.LabelHeader_TaxCode.Text = "Tax Code"
            Me.LabelHeader_TaxCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_CreateModifyDeleteDate
            '
            Me.LabelHeader_CreateModifyDeleteDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_CreateModifyDeleteDate.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_CreateModifyDeleteDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_CreateModifyDeleteDate.BorderWidth = 1
            Me.LabelHeader_CreateModifyDeleteDate.CanGrow = False
            Me.LabelHeader_CreateModifyDeleteDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_CreateModifyDeleteDate.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_CreateModifyDeleteDate.LocationFloat = New DevExpress.Utils.PointFloat(920.7918!, 61.04167!)
            Me.LabelHeader_CreateModifyDeleteDate.Multiline = True
            Me.LabelHeader_CreateModifyDeleteDate.Name = "LabelHeader_CreateModifyDeleteDate"
            Me.LabelHeader_CreateModifyDeleteDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_CreateModifyDeleteDate.SizeF = New System.Drawing.SizeF(79.20813!, 62.5!)
            Me.LabelHeader_CreateModifyDeleteDate.StylePriority.UseFont = False
            Me.LabelHeader_CreateModifyDeleteDate.StylePriority.UseTextAlignment = False
            Me.LabelHeader_CreateModifyDeleteDate.Text = "Create /" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Modify /" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Delete " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Date"
            Me.LabelHeader_CreateModifyDeleteDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 0
            Me.XrLine1.ForeColor = System.Drawing.Color.Gray
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 126.5417!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.XrLine1.StylePriority.UseBorderColor = False
            Me.XrLine1.StylePriority.UseBorders = False
            Me.XrLine1.StylePriority.UseBorderWidth = False
            Me.XrLine1.StylePriority.UseForeColor = False
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(864.5417!, 4.083379!)
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
            Me.PageFooter.HeightF = 25.08335!
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
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(1000.0!, 4.083347!)
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
            Me.LabelPageFooter_Date.Text = "Total"
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
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(368.8333!, 10.00004!)
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
            Me.LineReportFooter_LineThin.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 2.166653!)
            Me.LineReportFooter_LineThin.Name = "LineReportFooter_LineThin"
            Me.LineReportFooter_LineThin.SizeF = New System.Drawing.SizeF(1000.0!, 2.083333!)
            Me.LineReportFooter_LineThin.StylePriority.UseBorderColor = False
            Me.LineReportFooter_LineThin.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_LineThin.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_InvoiceAmount
            '
            Me.LabelReportFooter_InvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.LabelReportFooter_InvoiceAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportFooter_InvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(452.0!, 10.00001!)
            Me.LabelReportFooter_InvoiceAmount.Name = "LabelReportFooter_InvoiceAmount"
            Me.LabelReportFooter_InvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_InvoiceAmount.SizeF = New System.Drawing.SizeF(79.16672!, 19.00003!)
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
            Me.LabelReportFooter_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.LabelReportFooter_Total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportFooter_Total.LocationFloat = New DevExpress.Utils.PointFloat(687.9584!, 10.00004!)
            Me.LabelReportFooter_Total.Name = "LabelReportFooter_Total"
            Me.LabelReportFooter_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_Total.SizeF = New System.Drawing.SizeF(79.16669!, 19.0!)
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
            Me.LabelReportFooter_SalesTax.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_SalesTax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Taxes")})
            Me.LabelReportFooter_SalesTax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportFooter_SalesTax.LocationFloat = New DevExpress.Utils.PointFloat(618.3334!, 10.00004!)
            Me.LabelReportFooter_SalesTax.Name = "LabelReportFooter_SalesTax"
            Me.LabelReportFooter_SalesTax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SalesTax.SizeF = New System.Drawing.SizeF(65.625!, 19.0!)
            Me.LabelReportFooter_SalesTax.StylePriority.UseBorders = False
            Me.LabelReportFooter_SalesTax.StylePriority.UseFont = False
            Me.LabelReportFooter_SalesTax.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:c2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SalesTax.Summary = XrSummary3
            Me.LabelReportFooter_SalesTax.Text = "LabelReportFooter_SalesTax"
            Me.LabelReportFooter_SalesTax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_Commission
            '
            Me.LabelReportFooter_Commission.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupAmount")})
            Me.LabelReportFooter_Commission.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportFooter_Commission.LocationFloat = New DevExpress.Utils.PointFloat(535.1667!, 10.00001!)
            Me.LabelReportFooter_Commission.Name = "LabelReportFooter_Commission"
            Me.LabelReportFooter_Commission.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_Commission.SizeF = New System.Drawing.SizeF(79.16669!, 18.9998!)
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
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_Commission, Me.LabelReportFooter_SalesTax, Me.LabelReportFooter_Total, Me.LabelReportFooter_InvoiceAmount, Me.LineReportFooter_LineThin, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_Line})
            Me.ReportFooter.HeightF = 34.20836!
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
            Me.LineReportFooter_Line.SizeF = New System.Drawing.SizeF(1000.0!, 2.166653!)
            Me.LineReportFooter_Line.StylePriority.UseBorderColor = False
            Me.LineReportFooter_Line.StylePriority.UseBorders = False
            Me.LineReportFooter_Line.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_Line.StylePriority.UseForeColor = False
            '
            'GroupHeaderClientDivisionProduct
            '
            Me.GroupHeaderClientDivisionProduct.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel9, Me.XrLabel4})
            Me.GroupHeaderClientDivisionProduct.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderClientDivisionProduct.HeightF = 29.16667!
            Me.GroupHeaderClientDivisionProduct.Level = 1
            Me.GroupHeaderClientDivisionProduct.Name = "GroupHeaderClientDivisionProduct"
            Me.GroupHeaderClientDivisionProduct.RepeatEveryPage = True
            '
            'XrLabel9
            '
            Me.XrLabel9.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel9.BorderColor = System.Drawing.Color.Black
            Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel9.BorderWidth = 1
            Me.XrLabel9.CanGrow = False
            Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel9.ForeColor = System.Drawing.Color.Black
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 4.999987!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(152.9583!, 19.0!)
            Me.XrLabel9.StylePriority.UseFont = False
            Me.XrLabel9.StylePriority.UseTextAlignment = False
            Me.XrLabel9.Text = "Client / Division / Product:"
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel4
            '
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(152.9584!, 4.999987!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(847.0416!, 18.99999!)
            Me.XrLabel4.Text = "[ClientCode] - [ClientName] / [DivisionCode] - [DivisionName] / [ProductCode] - [" & _
        "ProductName]"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.IncomeOnly.Classes.IncomeOnlyBatchReport)
            '
            'GroupFooterClientDivisionProduct
            '
            Me.GroupFooterClientDivisionProduct.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel10, Me.XrLine3, Me.XrLabel5, Me.XrLabel6, Me.XrLabel7, Me.XrLabel8, Me.XrLine2})
            Me.GroupFooterClientDivisionProduct.HeightF = 33.0!
            Me.GroupFooterClientDivisionProduct.Level = 1
            Me.GroupFooterClientDivisionProduct.Name = "GroupFooterClientDivisionProduct"
            '
            'XrLabel10
            '
            Me.XrLabel10.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel10.BorderColor = System.Drawing.Color.Black
            Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel10.BorderWidth = 1
            Me.XrLabel10.CanGrow = False
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel10.ForeColor = System.Drawing.Color.Black
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(230.2918!, 7.000033!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(217.7082!, 19.0!)
            Me.XrLabel10.StylePriority.UseFont = False
            Me.XrLabel10.StylePriority.UseTextAlignment = False
            Me.XrLabel10.Text = "Client / Division / Product Total:"
            Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine3
            '
            Me.XrLine3.BorderColor = System.Drawing.Color.Silver
            Me.XrLine3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine3.BorderWidth = 1
            Me.XrLine3.ForeColor = System.Drawing.Color.Silver
            Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 31.0!)
            Me.XrLine3.Name = "XrLine3"
            Me.XrLine3.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            Me.XrLine3.StylePriority.UseBorderWidth = False
            '
            'XrLabel5
            '
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(452.0!, 7.000007!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(79.16672!, 19.00003!)
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:c2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel5.Summary = XrSummary5
            Me.XrLabel5.Text = "XrLabel5"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel6
            '
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(687.9584!, 7.000038!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(79.16669!, 19.0!)
            Me.XrLabel6.StylePriority.UseBorders = False
            Me.XrLabel6.StylePriority.UseFont = False
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:c2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel6.Summary = XrSummary6
            Me.XrLabel6.Text = "XrLabel6"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel7
            '
            Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Taxes")})
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(618.3334!, 7.000038!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(65.625!, 19.0!)
            Me.XrLabel7.StylePriority.UseBorders = False
            Me.XrLabel7.StylePriority.UseFont = False
            Me.XrLabel7.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:c2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel7.Summary = XrSummary7
            Me.XrLabel7.Text = "XrLabel7"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel8
            '
            Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarkupAmount")})
            Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(535.1667!, 7.000007!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(79.16669!, 18.9998!)
            Me.XrLabel8.StylePriority.UseFont = False
            Me.XrLabel8.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:c2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel8.Summary = XrSummary8
            Me.XrLabel8.Text = "XrLabel8"
            Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Silver
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 1
            Me.XrLine2.ForeColor = System.Drawing.Color.Silver
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            Me.XrLine2.StylePriority.UseBorderWidth = False
            '
            'GroupHeaderIncomeOnlyID
            '
            Me.GroupHeaderIncomeOnlyID.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderIncomeOnlyID.HeightF = 0.0!
            Me.GroupHeaderIncomeOnlyID.Name = "GroupHeaderIncomeOnlyID"
            '
            'GroupFooterIncomeOnlyID
            '
            Me.GroupFooterIncomeOnlyID.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine4})
            Me.GroupFooterIncomeOnlyID.HeightF = 2.0!
            Me.GroupFooterIncomeOnlyID.Name = "GroupFooterIncomeOnlyID"
            '
            'XrLine4
            '
            Me.XrLine4.BorderColor = System.Drawing.Color.Silver
            Me.XrLine4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine4.BorderWidth = 1
            Me.XrLine4.ForeColor = System.Drawing.Color.Silver
            Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLine4.Name = "XrLine4"
            Me.XrLine4.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            Me.XrLine4.StylePriority.UseBorderWidth = False
            '
            'IncomeOnlyBatchSummaryReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.GroupHeaderClientDivisionProduct, Me.GroupFooterClientDivisionProduct, Me.GroupHeaderIncomeOnlyID, Me.GroupFooterIncomeOnlyID})
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
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetail_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Commission As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_MarkupAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Amount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Quantity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Quantity As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Function As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ComponentLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Job As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Job As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Component As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Function As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_BatchTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_LineThin As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelReportFooter_InvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_SalesTax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_Commission As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_Line As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents GroupHeaderClientDivisionProduct As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelHeader_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelHeader_CreateModifyDeleteDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_TaxCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Status As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Total As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Taxes As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterClientDivisionProduct As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents GroupHeaderIncomeOnlyID As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterIncomeOnlyID As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
