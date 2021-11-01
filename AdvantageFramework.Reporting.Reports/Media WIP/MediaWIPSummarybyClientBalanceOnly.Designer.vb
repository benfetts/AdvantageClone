Namespace MediaWIP

    Partial Public Class MediaWIPSummarybyClientBalanceOnly
        Private components As System.ComponentModel.IContainer
        Private _resources As System.Resources.ResourceManager

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
        Public Sub New()
            Me.InitializeComponent()
        End Sub
        Private ReadOnly Property resources() As System.Resources.ResourceManager
            Get
                If _resources Is Nothing Then
                    Dim resourceString As String = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" + "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" + "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAAAAAAAAAAAFBBRFBBRFC0AAAA"
                    Me._resources = New DevExpress.XtraReports.Serialization.XRResourceManager(resourceString)
                End If
                Return Me._resources
            End Get
        End Property
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.VendorHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.VendorFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OrderNumberHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label62 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.end_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line8 = New DevExpress.XtraReports.UI.XRLine()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label49 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label52 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OfficeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OfficeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivPrdHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivPrdFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line6 = New DevExpress.XtraReports.UI.XRLine()
            Me.line5 = New DevExpress.XtraReports.UI.XRLine()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLAccountCodeDesc = New DevExpress.XtraReports.UI.CalculatedField()
            Me.OrderOptionDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.order_option = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            'VendorHeader
            '
            Me.VendorHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.VendorHeader.HeightF = 0!
            Me.VendorHeader.Level = 1
            Me.VendorHeader.Name = "VendorHeader"
            '
            'VendorFooter
            '
            Me.VendorFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label36, Me.label35})
            Me.VendorFooter.HeightF = 35.0!
            Me.VendorFooter.KeepTogether = True
            Me.VendorFooter.Level = 1
            Me.VendorFooter.Name = "VendorFooter"
            '
            'label36
            '
            Me.label36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 7.0!)
            Me.label36.Multiline = True
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(226.4584!, 18.0!)
            Me.label36.StylePriority.UseFont = False
            Me.label36.Text = "Total for Vendor:"
            '
            'label35
            '
            Me.label35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 7.0!)
            Me.label35.Multiline = True
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label35.Summary = XrSummary1
            Me.label35.Text = "label31"
            Me.label35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label35.TextFormatString = "{0:n2}"
            Me.label35.WordWrap = False
            '
            'OrderNumberHeader
            '
            Me.OrderNumberHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label8, Me.label10, Me.label24, Me.label6, Me.label31, Me.label26})
            Me.OrderNumberHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OrderNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OrderNumberHeader.HeightF = 18.0!
            Me.OrderNumberHeader.Name = "OrderNumberHeader"
            '
            'label8
            '
            Me.label8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientPO")})
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(232.1634!, 0!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(160.42!, 18.0!)
            Me.label8.Text = "label8"
            '
            'label10
            '
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderDescription")})
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(467.0835!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(171.4581!, 18.0!)
            Me.label10.Text = "label10"
            Me.label10.WordWrap = False
            '
            'label24
            '
            Me.label24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorName")})
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(62.99998!, 0!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(156.6666!, 18.0!)
            Me.label24.Text = "label24"
            Me.label24.WordWrap = False
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode")})
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(63.0!, 18.0!)
            Me.label6.Text = "label6"
            Me.label6.WordWrap = False
            '
            'label31
            '
            Me.label31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label31.Multiline = True
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label31.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label31.Summary = XrSummary2
            Me.label31.Text = "label31"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label31.TextFormatString = "{0:n2}"
            Me.label31.WordWrap = False
            '
            'label26
            '
            Me.label26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderNumber")})
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(402.0835!, 0!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(65.00005!, 18.0!)
            Me.label26.StylePriority.UseTextAlignment = False
            Me.label26.Text = "label26"
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label26.TextFormatString = "{0:000000}"
            Me.label26.WordWrap = False
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label62, Me.label4, Me.label3, Me.label19, Me.line3, Me.label2, Me.label1, Me.line1})
            Me.PageHeader.HeightF = 67.7083!
            Me.PageHeader.Name = "PageHeader"
            '
            'label62
            '
            Me.label62.LocationFloat = New DevExpress.Utils.PointFloat(570.2083!, 10.00001!)
            Me.label62.Multiline = True
            Me.label62.Name = "label62"
            Me.label62.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label62.SizeF = New System.Drawing.SizeF(79.79169!, 23.0!)
            Me.label62.Text = "Order Option:"
            '
            'label4
            '
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(570.2083!, 33.00002!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(90.20837!, 23.0!)
            Me.label4.Text = "Period Ending:"
            '
            'label3
            '
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.end_period, "Text", "")})
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 33.00002!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label3.StylePriority.UseTextAlignment = False
            Me.label3.Text = "label3"
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'end_period
            '
            Me.end_period.Description = "End Period"
            Me.end_period.Name = "end_period"
            Me.end_period.Visible = False
            '
            'label19
            '
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderOptionDescription")})
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 10.00001!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label19.StylePriority.UseTextAlignment = False
            Me.label19.Text = "label19"
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 58.5!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99999!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(420.8333!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "By Office, Client/Division/Product, Vendor"
            '
            'label1
            '
            Me.label1.BackColor = System.Drawing.Color.Transparent
            Me.label1.BorderColor = System.Drawing.Color.Transparent
            Me.label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
            Me.label1.ForeColor = System.Drawing.Color.Black
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(420.8333!, 23.0!)
            Me.label1.StylePriority.UseBackColor = False
            Me.label1.StylePriority.UseBorderColor = False
            Me.label1.StylePriority.UseFont = False
            Me.label1.StylePriority.UseForeColor = False
            Me.label1.Text = "Media WIP Summary by Client - Balance Only"
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pageInfo2, Me.pageInfo1, Me.line4})
            Me.PageFooter.HeightF = 27.99997!
            Me.PageFooter.Name = "PageFooter"
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 9.999974!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(300.0!, 18.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(298.9583!, 18.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.LightGray
            Me.line4.BorderColor = System.Drawing.Color.LightGray
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.0!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label29, Me.label30, Me.label32, Me.line8, Me.label33, Me.label37, Me.label49, Me.label52})
            Me.ReportFooter.HeightF = 92.08333!
            Me.ReportFooter.KeepTogether = True
            Me.ReportFooter.Name = "ReportFooter"
            '
            'label29
            '
            Me.label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(1.999982!, 18.33331!)
            Me.label29.Multiline = True
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(63.0!, 33.62499!)
            Me.label29.StylePriority.UseFont = False
            Me.label29.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vendor"
            '
            'label30
            '
            Me.label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(404.0834!, 18.33331!)
            Me.label30.Multiline = True
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(65.00002!, 33.625!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.StylePriority.UseTextAlignment = False
            Me.label30.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order #"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label32
            '
            Me.label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(649.9998!, 18.33331!)
            Me.label32.Multiline = True
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(100.0!, 33.625!)
            Me.label32.StylePriority.UseFont = False
            Me.label32.StylePriority.UseTextAlignment = False
            Me.label32.Text = "Accrued" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AP Balance"
            Me.label32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'line8
            '
            Me.line8.BackColor = System.Drawing.Color.LightGray
            Me.line8.BorderColor = System.Drawing.Color.LightGray
            Me.line8.ForeColor = System.Drawing.Color.LightGray
            Me.line8.LocationFloat = New DevExpress.Utils.PointFloat(0!, 56.96!)
            Me.line8.Name = "line8"
            Me.line8.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line8.StylePriority.UseBackColor = False
            Me.line8.StylePriority.UseBorderColor = False
            Me.line8.StylePriority.UseForeColor = False
            '
            'label33
            '
            Me.label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(469.0835!, 18.33324!)
            Me.label33.Multiline = True
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(169.458!, 33.62502!)
            Me.label33.StylePriority.UseFont = False
            Me.label33.StylePriority.UseTextAlignment = False
            Me.label33.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
            Me.label33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label37
            '
            Me.label37.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(234.1633!, 18.33331!)
            Me.label37.Multiline = True
            Me.label37.Name = "label37"
            Me.label37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label37.SizeF = New System.Drawing.SizeF(160.42!, 33.625!)
            Me.label37.StylePriority.UseFont = False
            Me.label37.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Client PO/Est."
            '
            'label49
            '
            Me.label49.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label49.LocationFloat = New DevExpress.Utils.PointFloat(210.4165!, 74.08333!)
            Me.label49.Multiline = True
            Me.label49.Name = "label49"
            Me.label49.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label49.SizeF = New System.Drawing.SizeF(226.4584!, 18.0!)
            Me.label49.StylePriority.UseFont = False
            Me.label49.Text = "Total for Report:"
            '
            'label52
            '
            Me.label52.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label52.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label52.LocationFloat = New DevExpress.Utils.PointFloat(649.9998!, 74.08333!)
            Me.label52.Multiline = True
            Me.label52.Name = "label52"
            Me.label52.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label52.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label52.StylePriority.UseFont = False
            Me.label52.StylePriority.UseTextAlignment = False
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label52.Summary = XrSummary3
            Me.label52.Text = "label31"
            Me.label52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label52.TextFormatString = "{0:n2}"
            Me.label52.WordWrap = False
            '
            'OfficeHeader
            '
            Me.OfficeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label9, Me.label21, Me.label16, Me.label12, Me.line2, Me.label13, Me.label7, Me.label5})
            Me.OfficeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OfficeHeader.HeightF = 64.58334!
            Me.OfficeHeader.Level = 3
            Me.OfficeHeader.Name = "OfficeHeader"
            Me.OfficeHeader.RepeatEveryPage = True
            '
            'label9
            '
            Me.label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(232.1633!, 18.0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(160.42!, 33.625!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Client PO/Est."
            '
            'label21
            '
            Me.label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label21.Multiline = True
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(64.99999!, 18.0!)
            Me.label21.StylePriority.UseFont = False
            Me.label21.Text = "Office:"
            '
            'label16
            '
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeDescription")})
            Me.label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(64.99999!, 0!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(327.5833!, 18.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.Text = "label16"
            '
            'label12
            '
            Me.label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(467.0835!, 17.99997!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(169.458!, 33.62502!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            Me.label12.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 56.62498!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'label13
            '
            Me.label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(647.9999!, 18.0!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 33.625!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            Me.label13.Text = "Accrued" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AP Balance"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label7
            '
            Me.label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(402.0835!, 18.0!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(65.00002!, 33.625!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.StylePriority.UseTextAlignment = False
            Me.label7.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order #"
            Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 18.0!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(63.0!, 33.62499!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vendor"
            '
            'OfficeFooter
            '
            Me.OfficeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label25, Me.label27})
            Me.OfficeFooter.HeightF = 18.0!
            Me.OfficeFooter.Level = 3
            Me.OfficeFooter.Name = "OfficeFooter"
            Me.OfficeFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'label25
            '
            Me.label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 0!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(226.4584!, 18.0!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.Text = "Total for Office:"
            '
            'label27
            '
            Me.label27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.StylePriority.UseTextAlignment = False
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label27.Summary = XrSummary4
            Me.label27.Text = "label31"
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label27.TextFormatString = "{0:n2}"
            Me.label27.WordWrap = False
            '
            'ClientDivPrdHeader
            '
            Me.ClientDivPrdHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label22, Me.label20, Me.label15, Me.label14, Me.label18, Me.label17})
            Me.ClientDivPrdHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CDPSortCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientDivPrdHeader.HeightF = 41.66667!
            Me.ClientDivPrdHeader.Level = 2
            Me.ClientDivPrdHeader.Name = "ClientDivPrdHeader"
            Me.ClientDivPrdHeader.RepeatEveryPage = True
            '
            'label22
            '
            Me.label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(371.8751!, 18.00003!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.StylePriority.UseTextAlignment = False
            Me.label22.Text = "Product:"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.label22.WordWrap = False
            '
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductDescription")})
            Me.label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(436.8752!, 18.00003!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(294.7917!, 18.0!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.Text = "label20"
            '
            'label15
            '
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionName")})
            Me.label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(64.99999!, 18.00003!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(294.7917!, 18.0!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.Text = "label15"
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientName")})
            Me.label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(64.99999!, 0!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(294.7917!, 18.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.Text = "label14"
            '
            'label18
            '
            Me.label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(0!, 18.00003!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.StylePriority.UseTextAlignment = False
            Me.label18.Text = "Division:"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.label18.WordWrap = False
            '
            'label17
            '
            Me.label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label17.StylePriority.UseFont = False
            Me.label17.StylePriority.UseTextAlignment = False
            Me.label17.Text = "Client:"
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.label17.WordWrap = False
            '
            'ClientDivPrdFooter
            '
            Me.ClientDivPrdFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line6, Me.line5, Me.label11, Me.label23})
            Me.ClientDivPrdFooter.HeightF = 39.58333!
            Me.ClientDivPrdFooter.Level = 2
            Me.ClientDivPrdFooter.Name = "ClientDivPrdFooter"
            '
            'line6
            '
            Me.line6.BackColor = System.Drawing.Color.Transparent
            Me.line6.BorderColor = System.Drawing.Color.LightGray
            Me.line6.ForeColor = System.Drawing.Color.LightGray
            Me.line6.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 30.0!)
            Me.line6.Name = "line6"
            Me.line6.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line6.StylePriority.UseBackColor = False
            Me.line6.StylePriority.UseBorderColor = False
            Me.line6.StylePriority.UseForeColor = False
            '
            'line5
            '
            Me.line5.BackColor = System.Drawing.Color.Transparent
            Me.line5.BorderColor = System.Drawing.Color.LightGray
            Me.line5.ForeColor = System.Drawing.Color.LightGray
            Me.line5.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line5.LocationFloat = New DevExpress.Utils.PointFloat(0.0001430511!, 0!)
            Me.line5.Name = "line5"
            Me.line5.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line5.StylePriority.UseBackColor = False
            Me.line5.StylePriority.UseBorderColor = False
            Me.line5.StylePriority.UseForeColor = False
            '
            'label11
            '
            Me.label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 8.0!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(226.4584!, 18.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.Text = "Total for Client/Division/Product:"
            '
            'label23
            '
            Me.label23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(650.0001!, 8.0!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseTextAlignment = False
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label23.Summary = XrSummary5
            Me.label23.Text = "label31"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label23.TextFormatString = "{0:n2}"
            Me.label23.WordWrap = False
            '
            'GLAccountCodeDesc
            '
            Me.GLAccountCodeDesc.DisplayName = "GLAccountCodeDesc"
            Me.GLAccountCodeDesc.Expression = "concat([GLAccountCode],' - ',[GLAccountDescription])"
            Me.GLAccountCodeDesc.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.GLAccountCodeDesc.Name = "GLAccountCodeDesc"
            '
            'OrderOptionDescription
            '
            Me.OrderOptionDescription.Expression = "IIF([Parameters].[order_option]=1,'Open and Closed','Open Only')"
            Me.OrderOptionDescription.Name = "OrderOptionDescription"
            '
            'order_option
            '
            Me.order_option.Description = "Order Option"
            Me.order_option.Name = "order_option"
            Me.order_option.Type = GetType(Integer)
            Me.order_option.ValueInfo = "1"
            Me.order_option.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.MonthEndMediaWIP)
            '
            'MediaWIPSummarybyClientBalanceOnly
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.VendorHeader, Me.VendorFooter, Me.OrderNumberHeader, Me.PageHeader, Me.PageFooter, Me.ReportFooter, Me.OfficeHeader, Me.OfficeFooter, Me.ClientDivPrdHeader, Me.ClientDivPrdFooter})
            Me.BorderColor = System.Drawing.Color.Transparent
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.GLAccountCodeDesc, Me.OrderOptionDescription})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "Media WIP Summary by Client - Balance Only"
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.end_period, Me.order_option})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents VendorHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents VendorFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OrderNumberHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label62 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents end_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line8 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label49 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label52 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OfficeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OfficeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivPrdHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivPrdFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line6 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line5 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLAccountCodeDesc As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents OrderOptionDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents order_option As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






