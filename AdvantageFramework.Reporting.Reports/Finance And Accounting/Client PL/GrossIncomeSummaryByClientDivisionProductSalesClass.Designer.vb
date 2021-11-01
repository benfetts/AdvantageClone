Namespace FinanceAndAccounting.ClientPL

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class GrossIncomeSummaryByClientDivisionProductSalesClass
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
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.EndPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ProductHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ProductFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line8 = New DevExpress.XtraReports.UI.XRLine()
            Me.line5 = New DevExpress.XtraReports.UI.XRLine()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.TotalGrossIncomeCurrentProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalGrossIncomeProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.StartPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.SalesClassFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.SalesClassHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OfficeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.OfficeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.OfficeFilter = New DevExpress.XtraReports.Parameters.Parameter()
            Me.OfficeLabel = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'pageInfo1
            '
            Me.pageInfo1.Dpi = 100.0!
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
            Me.pageInfo1.Format = "Page {0} of {1}"
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(649.9996!, 9.999974!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            Me.pageInfo1.StylePriority.UseTextAlignment = False
            Me.pageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'EndPeriod
            '
            Me.EndPeriod.Description = "Ending Post Period"
            Me.EndPeriod.Name = "EndPeriod"
            Me.EndPeriod.Visible = False
            '
            'label16
            '
            Me.label16.Dpi = 100.0!
            Me.label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(549.9996!, 34.62499!)
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(100.0!, 22.99998!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.StylePriority.UseTextAlignment = False
            Me.label16.Text = "Current"
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label21
            '
            Me.label21.Dpi = 100.0!
            Me.label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(51.04167!, 23.0!)
            Me.label21.StylePriority.UseFont = False
            Me.label21.Text = "Office: "
            '
            'label18
            '
            Me.label18.CanGrow = False
            Me.label18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label18.Dpi = 100.0!
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(649.9999!, 95.12501!)
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label18.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label18.Summary = XrSummary1
            Me.label18.Text = "label18"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ProductHeader
            '
            Me.ProductHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label3, Me.label4, Me.label5})
            Me.ProductHeader.Dpi = 100.0!
            Me.ProductHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ProductHeader.HeightF = 73.95834!
            Me.ProductHeader.Level = 1
            Me.ProductHeader.Name = "ProductHeader"
            Me.ProductHeader.RepeatEveryPage = True
            '
            'label3
            '
            Me.label3.CanGrow = False
            Me.label3.CanShrink = True
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDescription")})
            Me.label3.Dpi = 100.0!
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(179.1667!, 24.37499!)
            Me.label3.Text = "label3"
            Me.label3.WordWrap = False
            '
            'label4
            '
            Me.label4.CanGrow = False
            Me.label4.CanShrink = True
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionDescription")})
            Me.label4.Dpi = 100.0!
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 24.37499!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(179.1667!, 24.37499!)
            Me.label4.Text = "label4"
            Me.label4.WordWrap = False
            '
            'label5
            '
            Me.label5.CanGrow = False
            Me.label5.CanShrink = True
            Me.label5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductDescription")})
            Me.label5.Dpi = 100.0!
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 48.74999!)
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(179.1667!, 24.375!)
            Me.label5.Text = "label5"
            Me.label5.WordWrap = False
            '
            'label24
            '
            Me.label24.Dpi = 100.0!
            Me.label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 11.91673!)
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(200.0!, 21.95833!)
            Me.label24.StylePriority.UseFont = False
            Me.label24.StylePriority.UseTextAlignment = False
            Me.label24.Text = "G r o s s   I n c o m e"
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ProductFooter
            '
            Me.ProductFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label7, Me.line8, Me.line5, Me.line4, Me.TotalGrossIncomeCurrentProduct, Me.TotalGrossIncomeProduct})
            Me.ProductFooter.Dpi = 100.0!
            Me.ProductFooter.HeightF = 43.54172!
            Me.ProductFooter.Level = 1
            Me.ProductFooter.Name = "ProductFooter"
            '
            'label7
            '
            Me.label7.Dpi = 100.0!
            Me.label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(298.9583!, 8.041699!)
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(215.625!, 23.0!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.StylePriority.UseTextAlignment = False
            Me.label7.Text = "Client-Division-Product Totals:"
            Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line8
            '
            Me.line8.Dpi = 100.0!
            Me.line8.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line8.LocationFloat = New DevExpress.Utils.PointFloat(0!, 31.04172!)
            Me.line8.Name = "line8"
            Me.line8.SizeF = New System.Drawing.SizeF(750.0!, 12.5!)
            '
            'line5
            '
            Me.line5.Dpi = 100.0!
            Me.line5.LocationFloat = New DevExpress.Utils.PointFloat(649.9996!, 0!)
            Me.line5.Name = "line5"
            Me.line5.SizeF = New System.Drawing.SizeF(100.0!, 6.333335!)
            '
            'line4
            '
            Me.line4.Dpi = 100.0!
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(549.9996!, 0!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(100.0!, 6.333335!)
            '
            'TotalGrossIncomeCurrentProduct
            '
            Me.TotalGrossIncomeCurrentProduct.CanGrow = False
            Me.TotalGrossIncomeCurrentProduct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent")})
            Me.TotalGrossIncomeCurrentProduct.Dpi = 100.0!
            Me.TotalGrossIncomeCurrentProduct.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 8.041699!)
            Me.TotalGrossIncomeCurrentProduct.Name = "TotalGrossIncomeCurrentProduct"
            Me.TotalGrossIncomeCurrentProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.TotalGrossIncomeCurrentProduct.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.TotalGrossIncomeCurrentProduct.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.TotalGrossIncomeCurrentProduct.Summary = XrSummary2
            Me.TotalGrossIncomeCurrentProduct.Text = "TotalGrossIncomeCurrentProduct"
            Me.TotalGrossIncomeCurrentProduct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.TotalGrossIncomeCurrentProduct.WordWrap = False
            '
            'TotalGrossIncomeProduct
            '
            Me.TotalGrossIncomeProduct.CanGrow = False
            Me.TotalGrossIncomeProduct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.TotalGrossIncomeProduct.Dpi = 100.0!
            Me.TotalGrossIncomeProduct.LocationFloat = New DevExpress.Utils.PointFloat(649.9996!, 8.041699!)
            Me.TotalGrossIncomeProduct.Name = "TotalGrossIncomeProduct"
            Me.TotalGrossIncomeProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.TotalGrossIncomeProduct.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.TotalGrossIncomeProduct.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.TotalGrossIncomeProduct.Summary = XrSummary3
            Me.TotalGrossIncomeProduct.Text = "TotalGrossIncomeProduct"
            Me.TotalGrossIncomeProduct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Detail
            '
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label11
            '
            Me.label11.Dpi = 100.0!
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(549.9996!, 12.66667!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(200.0!, 21.95833!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            Me.label11.Text = "G r o s s   I n c o m e"
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label19
            '
            Me.label19.Dpi = 100.0!
            Me.label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(298.9583!, 95.12501!)
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(215.625!, 23.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.StylePriority.UseTextAlignment = False
            Me.label19.Text = "Report Totals:"
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.LineTopLine, Me.label30, Me.label29, Me.label28, Me.label27, Me.label26, Me.label25, Me.label1, Me.label2})
            Me.PageHeader.Dpi = 100.0!
            Me.PageHeader.HeightF = 72.91666!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4.0!
            Me.XrLine1.Dpi = 100.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.0!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4.0!
            Me.LineTopLine.Dpi = 100.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 67.71!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            '
            'label30
            '
            Me.label30.Dpi = 100.0!
            Me.label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(676.0418!, 32.99999!)
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(23.95612!, 23.0!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.StylePriority.UseTextAlignment = False
            Me.label30.Text = "to"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label29
            '
            Me.label29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.EndPeriod, "Text", "")})
            Me.label29.Dpi = 100.0!
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(699.9979!, 33.00002!)
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(50.00165!, 23.0!)
            Me.label29.StylePriority.UseTextAlignment = False
            Me.label29.Text = "label29"
            Me.label29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label28
            '
            Me.label28.CanGrow = False
            Me.label28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.StartPeriod, "Text", "")})
            Me.label28.Dpi = 100.0!
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(626.0418!, 32.99999!)
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(50.0!, 23.0!)
            Me.label28.StylePriority.UseTextAlignment = False
            Me.label28.Text = "label28"
            Me.label28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label28.WordWrap = False
            '
            'StartPeriod
            '
            Me.StartPeriod.Description = "Starting Post Period"
            Me.StartPeriod.Name = "StartPeriod"
            Me.StartPeriod.Visible = False
            '
            'label27
            '
            Me.label27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.EndPeriod, "Text", "")})
            Me.label27.Dpi = 100.0!
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(699.998!, 10.00001!)
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(50.00165!, 23.0!)
            Me.label27.StylePriority.UseTextAlignment = False
            Me.label27.Text = "label27"
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label26
            '
            Me.label26.Dpi = 100.0!
            Me.label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(561.4584!, 32.99999!)
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(64.5834!, 23.0!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.StylePriority.UseTextAlignment = False
            Me.label26.Text = "YTD: "
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label25
            '
            Me.label25.Dpi = 100.0!
            Me.label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(561.4584!, 10.00001!)
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(64.5834!, 23.0!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.StylePriority.UseTextAlignment = False
            Me.label25.Text = "Current:"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label1
            '
            Me.label1.Dpi = 100.0!
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(352.0834!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Gross Income Summary"
            '
            'label2
            '
            Me.label2.Dpi = 100.0!
            Me.label2.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 33.00002!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(352.0834!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Office/Client/Division/Product - Sales Class"
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.label6.Dpi = 100.0!
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(52.0834!, 0!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(247.9166!, 23.0!)
            Me.label6.Text = "label6"
            '
            'SalesClassFooter
            '
            Me.SalesClassFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label6, Me.label14, Me.label32})
            Me.SalesClassFooter.Dpi = 100.0!
            Me.SalesClassFooter.HeightF = 23.0!
            Me.SalesClassFooter.Name = "SalesClassFooter"
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent")})
            Me.label14.Dpi = 100.0!
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 0!)
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label14.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label14.Summary = XrSummary4
            Me.label14.Text = "label14"
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label32
            '
            Me.label32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label32.Dpi = 100.0!
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(649.9996!, 0!)
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label32.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label32.Summary = XrSummary5
            Me.label32.Text = "label32"
            Me.label32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label13
            '
            Me.label13.Dpi = 100.0!
            Me.label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(298.9583!, 9.999974!)
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(215.625!, 23.0!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            Me.label13.Text = "Office Totals:"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TotalGrossIncomeCurrent
            '
            Me.TotalGrossIncomeCurrent.Expression = "Iif([PostingPeriod] =[Parameters.EndPeriod],[TotalGrossIncome]  ,0 )"
            Me.TotalGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.Float
            Me.TotalGrossIncomeCurrent.Name = "TotalGrossIncomeCurrent"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine3, Me.pageInfo2, Me.pageInfo1})
            Me.PageFooter.Dpi = 100.0!
            Me.PageFooter.HeightF = 50.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'XrLine3
            '
            Me.XrLine3.BorderColor = System.Drawing.Color.Silver
            Me.XrLine3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine3.BorderWidth = 4.0!
            Me.XrLine3.Dpi = 100.0!
            Me.XrLine3.ForeColor = System.Drawing.Color.Silver
            Me.XrLine3.LineWidth = 4
            Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLine3.Name = "XrLine3"
            Me.XrLine3.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            '
            'pageInfo2
            '
            Me.pageInfo2.Dpi = 100.0!
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.0!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(201.0417!, 23.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            '
            'SalesClassHeader
            '
            Me.SalesClassHeader.Dpi = 100.0!
            Me.SalesClassHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SalesClassDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.SalesClassHeader.HeightF = 0!
            Me.SalesClassHeader.Name = "SalesClassHeader"
            '
            'label12
            '
            Me.label12.CanGrow = False
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label12.Dpi = 100.0!
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(649.9996!, 8.666675!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary6
            Me.label12.Text = "label12"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeLabel")})
            Me.label20.Dpi = 100.0!
            Me.label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(52.0834!, 0!)
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(300.0!, 23.0!)
            Me.label20.StylePriority.UseFont = False
            '
            'label22
            '
            Me.label22.Dpi = 100.0!
            Me.label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(549.9996!, 33.87502!)
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(100.0!, 22.99998!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.StylePriority.UseTextAlignment = False
            Me.label22.Text = "Current"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label15
            '
            Me.label15.CanGrow = False
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent")})
            Me.label15.Dpi = 100.0!
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 10.00001!)
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label15.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label15.Summary = XrSummary7
            Me.label15.Text = "label15"
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label15.WordWrap = False
            '
            'OfficeHeader
            '
            Me.OfficeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.label21, Me.label20, Me.label16, Me.label11, Me.label10})
            Me.OfficeHeader.Dpi = 100.0!
            Me.OfficeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OfficeHeader.HeightF = 68.83335!
            Me.OfficeHeader.Level = 2
            Me.OfficeHeader.Name = "OfficeHeader"
            Me.OfficeHeader.RepeatEveryPage = True
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Silver
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 4.0!
            Me.XrLine2.Dpi = 100.0!
            Me.XrLine2.ForeColor = System.Drawing.Color.Silver
            Me.XrLine2.LineWidth = 4
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(549.9996!, 57.62498!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(200.0004!, 9.375008!)
            '
            'label10
            '
            Me.label10.Dpi = 100.0!
            Me.label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(649.9996!, 34.62499!)
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(100.0!, 22.99998!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.StylePriority.UseTextAlignment = False
            Me.label10.Text = "Year-To-Date"
            Me.label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label23
            '
            Me.label23.Dpi = 100.0!
            Me.label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(649.9999!, 33.87508!)
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(100.0!, 22.99998!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseTextAlignment = False
            Me.label23.Text = "Year-To-Date"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine4, Me.label17, Me.label24, Me.label22, Me.label23, Me.label19, Me.label18})
            Me.ReportFooter.Dpi = 100.0!
            Me.ReportFooter.HeightF = 118.125!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'XrLine4
            '
            Me.XrLine4.BorderColor = System.Drawing.Color.Silver
            Me.XrLine4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine4.BorderWidth = 4.0!
            Me.XrLine4.Dpi = 100.0!
            Me.XrLine4.ForeColor = System.Drawing.Color.Silver
            Me.XrLine4.LineWidth = 4
            Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(549.9996!, 60.08339!)
            Me.XrLine4.Name = "XrLine4"
            Me.XrLine4.SizeF = New System.Drawing.SizeF(200.0004!, 6.416611!)
            '
            'label17
            '
            Me.label17.CanGrow = False
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent")})
            Me.label17.Dpi = 100.0!
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 95.12501!)
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label17.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label17.Summary = XrSummary8
            Me.label17.Text = "label17"
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label17.WordWrap = False
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'OfficeFooter
            '
            Me.OfficeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label15, Me.label13, Me.label12})
            Me.OfficeFooter.Dpi = 100.0!
            Me.OfficeFooter.HeightF = 36.45833!
            Me.OfficeFooter.Level = 2
            Me.OfficeFooter.Name = "OfficeFooter"
            Me.OfficeFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.ClientPL)
            '
            'OfficeFilter
            '
            Me.OfficeFilter.Name = "OfficeFilter"
            Me.OfficeFilter.Visible = False
            '
            'OfficeLabel
            '
            Me.OfficeLabel.Expression = "Iif([Parameters.OfficeFilter] = '',Iif([OfficeDescription] = '', 'All Offices'  ," &
    "[OfficeDescription] )  ,[Parameters.OfficeFilter] )"
            Me.OfficeLabel.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.OfficeLabel.Name = "OfficeLabel"
            '
            'GrossIncomeSummaryByClientDivisionProductSalesClass
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.OfficeHeader, Me.OfficeFooter, Me.ReportFooter, Me.PageHeader, Me.PageFooter, Me.ProductHeader, Me.ProductFooter, Me.SalesClassHeader, Me.SalesClassFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.TotalGrossIncomeCurrent, Me.OfficeLabel})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "04-Gross Income Summary by Client-Div-Prod-Sls Cls"
            Me.FilterString = "[TotalGrossIncome] <> 0.00m Or [TotalGrossIncomeCurrent] <> 0.00m"
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.StartPeriod, Me.EndPeriod, Me.OfficeFilter})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents EndPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ProductHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ProductFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line8 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line5 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents TotalGrossIncomeCurrentProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TotalGrossIncomeProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents StartPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SalesClassFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TotalGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents SalesClassHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OfficeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents OfficeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents OfficeFilter As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents OfficeLabel As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace
