Namespace FinanceAndAccounting.ClientPL

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class GrossIncomeSummaryByClientDivisionProduct
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
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalGrossIncomeProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.ProductFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalGrossIncomeCurrentProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.OfficeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LineBottomLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EndPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.StartPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.ProductHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.OfficeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.OfficeFilter = New DevExpress.XtraReports.Parameters.Parameter()
            Me.OfficeLabel = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'label5
            '
            Me.label5.CanGrow = False
            Me.label5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductDescription")})
            Me.label5.Dpi = 100.0!
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(362.4999!, 0!)
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(176.0416!, 24.37499!)
            Me.label5.Text = "label5"
            Me.label5.WordWrap = False
            '
            'label7
            '
            Me.label7.Dpi = 100.0!
            Me.label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 35.66669!)
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(165.625!, 21.95832!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.Text = "Client"
            '
            'TotalGrossIncomeProduct
            '
            Me.TotalGrossIncomeProduct.CanGrow = False
            Me.TotalGrossIncomeProduct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.TotalGrossIncomeProduct.Dpi = 100.0!
            Me.TotalGrossIncomeProduct.LocationFloat = New DevExpress.Utils.PointFloat(649.9995!, 0!)
            Me.TotalGrossIncomeProduct.Name = "TotalGrossIncomeProduct"
            Me.TotalGrossIncomeProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.TotalGrossIncomeProduct.SizeF = New System.Drawing.SizeF(100.0!, 24.37499!)
            Me.TotalGrossIncomeProduct.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.TotalGrossIncomeProduct.Summary = XrSummary1
            Me.TotalGrossIncomeProduct.Text = "TotalGrossIncomeProduct"
            Me.TotalGrossIncomeProduct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ProductFooter
            '
            Me.ProductFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label5, Me.label3, Me.label4, Me.TotalGrossIncomeCurrentProduct, Me.TotalGrossIncomeProduct})
            Me.ProductFooter.Dpi = 100.0!
            Me.ProductFooter.HeightF = 24.37499!
            Me.ProductFooter.Name = "ProductFooter"
            '
            'label3
            '
            Me.label3.CanGrow = False
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDescription")})
            Me.label3.Dpi = 100.0!
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(165.625!, 24.37499!)
            Me.label3.Text = "label3"
            Me.label3.WordWrap = False
            '
            'label4
            '
            Me.label4.CanGrow = False
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionDescription")})
            Me.label4.Dpi = 100.0!
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(172.9166!, 0!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(179.1667!, 24.37499!)
            Me.label4.Text = "label4"
            Me.label4.WordWrap = False
            '
            'TotalGrossIncomeCurrentProduct
            '
            Me.TotalGrossIncomeCurrentProduct.CanGrow = False
            Me.TotalGrossIncomeCurrentProduct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent")})
            Me.TotalGrossIncomeCurrentProduct.Dpi = 100.0!
            Me.TotalGrossIncomeCurrentProduct.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 0!)
            Me.TotalGrossIncomeCurrentProduct.Name = "TotalGrossIncomeCurrentProduct"
            Me.TotalGrossIncomeCurrentProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.TotalGrossIncomeCurrentProduct.SizeF = New System.Drawing.SizeF(100.0!, 24.37499!)
            Me.TotalGrossIncomeCurrentProduct.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.TotalGrossIncomeCurrentProduct.Summary = XrSummary2
            Me.TotalGrossIncomeCurrentProduct.Text = "TotalGrossIncomeCurrentProduct"
            Me.TotalGrossIncomeCurrentProduct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.TotalGrossIncomeCurrentProduct.WordWrap = False
            '
            'OfficeHeader
            '
            Me.OfficeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.label21, Me.label20, Me.label16, Me.label11, Me.label10, Me.label9, Me.label8, Me.label7})
            Me.OfficeHeader.Dpi = 100.0!
            Me.OfficeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OfficeHeader.HeightF = 68.83335!
            Me.OfficeHeader.Level = 1
            Me.OfficeHeader.Name = "OfficeHeader"
            Me.OfficeHeader.RepeatEveryPage = True
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4.0!
            Me.XrLine1.Dpi = 100.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(549.9999!, 63.95829!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(200.0001!, 4.0!)
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
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeLabel")})
            Me.label20.Dpi = 100.0!
            Me.label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(52.08333!, 0!)
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(300.0!, 23.0!)
            Me.label20.StylePriority.UseFont = False
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
            'label9
            '
            Me.label9.Dpi = 100.0!
            Me.label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(362.5!, 35.66669!)
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(176.0415!, 21.95832!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.Text = "Product"
            '
            'label8
            '
            Me.label8.Dpi = 100.0!
            Me.label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(172.9166!, 35.66669!)
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(179.1667!, 21.95832!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.Text = "Division"
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
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(201.0417!, 23.0!)
            Me.pageInfo2.StylePriority.UseFont = False
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
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineBottomLine, Me.LineTopLine, Me.label30, Me.label29, Me.label28, Me.label27, Me.label26, Me.label25, Me.label1, Me.label2})
            Me.PageHeader.Dpi = 100.0!
            Me.PageHeader.HeightF = 72.91666!
            Me.PageHeader.Name = "PageHeader"
            '
            'LineBottomLine
            '
            Me.LineBottomLine.BorderColor = System.Drawing.Color.Silver
            Me.LineBottomLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineBottomLine.BorderWidth = 4.0!
            Me.LineBottomLine.Dpi = 100.0!
            Me.LineBottomLine.ForeColor = System.Drawing.Color.Silver
            Me.LineBottomLine.LineWidth = 4
            Me.LineBottomLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 67.70834!)
            Me.LineBottomLine.Name = "LineBottomLine"
            Me.LineBottomLine.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4.0!
            Me.LineTopLine.Dpi = 100.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.0!)
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
            'EndPeriod
            '
            Me.EndPeriod.Description = "Ending Post Period"
            Me.EndPeriod.Name = "EndPeriod"
            Me.EndPeriod.Visible = False
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
            Me.label1.SizeF = New System.Drawing.SizeF(300.0!, 23.0!)
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
            Me.label2.SizeF = New System.Drawing.SizeF(300.0!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Office/Client/Division/Product"
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            'label19
            '
            Me.label19.Dpi = 100.0!
            Me.label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(414.5833!, 95.12501!)
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.StylePriority.UseTextAlignment = False
            Me.label19.Text = "Report Totals:"
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label17.Summary = XrSummary3
            Me.label17.Text = "label17"
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label17.WordWrap = False
            '
            'line1
            '
            Me.line1.Dpi = 100.0!
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(649.9996!, 2.333355!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(100.0!, 6.333335!)
            '
            'ProductHeader
            '
            Me.ProductHeader.Dpi = 100.0!
            Me.ProductHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ProductHeader.HeightF = 0!
            Me.ProductHeader.Name = "ProductHeader"
            Me.ProductHeader.Visible = False
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
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.label17, Me.label24, Me.label22, Me.label23, Me.label19, Me.label18})
            Me.ReportFooter.Dpi = 100.0!
            Me.ReportFooter.HeightF = 118.125!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Silver
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 4.0!
            Me.XrLine2.Dpi = 100.0!
            Me.XrLine2.ForeColor = System.Drawing.Color.Silver
            Me.XrLine2.LineWidth = 4
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(549.9996!, 59.04172!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(200.0004!, 7.458271!)
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
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label18.Summary = XrSummary4
            Me.label18.Text = "label18"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TotalGrossIncomeCurrent
            '
            Me.TotalGrossIncomeCurrent.Expression = "Iif([PostingPeriod] =[Parameters.EndPeriod],[TotalGrossIncome]  ,0 )"
            Me.TotalGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.TotalGrossIncomeCurrent.Name = "TotalGrossIncomeCurrent"
            '
            'Detail
            '
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 50.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'OfficeFooter
            '
            Me.OfficeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label15, Me.line1, Me.label13, Me.label12, Me.line3})
            Me.OfficeFooter.Dpi = 100.0!
            Me.OfficeFooter.HeightF = 36.45833!
            Me.OfficeFooter.Level = 1
            Me.OfficeFooter.Name = "OfficeFooter"
            Me.OfficeFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
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
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label15.Summary = XrSummary5
            Me.label15.Text = "label15"
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label15.WordWrap = False
            '
            'label13
            '
            Me.label13.Dpi = 100.0!
            Me.label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(414.5833!, 10.00001!)
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            Me.label13.Text = "Office Totals:"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label12
            '
            Me.label12.CanGrow = False
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label12.Dpi = 100.0!
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(649.9995!, 8.666675!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 24.33334!)
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary6
            Me.label12.Text = "label12"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line3
            '
            Me.line3.Dpi = 100.0!
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(549.9996!, 2.333355!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(100.0!, 6.333335!)
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
            'GrossIncomeSummaryByClientDivisionProduct
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.OfficeHeader, Me.OfficeFooter, Me.ReportFooter, Me.PageHeader, Me.PageFooter, Me.ProductHeader, Me.ProductFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.TotalGrossIncomeCurrent, Me.OfficeLabel})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "03-Gross Income Summary by Client-Div-Prod"
            Me.FilterString = "[TotalGrossIncome] <> 0.00m Or [TotalGrossIncomeCurrent] <> 0.00m"
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.StartPeriod, Me.EndPeriod, Me.OfficeFilter})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TotalGrossIncomeProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ProductFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TotalGrossIncomeCurrentProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OfficeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents EndPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents StartPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents ProductHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TotalGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents OfficeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineBottomLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents OfficeFilter As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents OfficeLabel As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace
