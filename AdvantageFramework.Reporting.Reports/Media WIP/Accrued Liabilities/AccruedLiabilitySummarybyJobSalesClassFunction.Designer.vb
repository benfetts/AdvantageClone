Namespace MediaWIP.AccruedLiabilities

    Partial Public Class AccruedLiabilitySummarybyJobSalesClassFunction
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
            Me.GLAccountHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLAccountFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobCompHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.HideZeroRows = New DevExpress.XtraReports.UI.FormattingRule()
            Me.SalesClassFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.end_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.SalesClassHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FunctionFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FunctionHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLAccount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobComp = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobCompFunction = New DevExpress.XtraReports.UI.CalculatedField()
            Me.FunctionTotalLabel = New DevExpress.XtraReports.UI.CalculatedField()
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
            'GLAccountHeader
            '
            Me.GLAccountHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label2, Me.label1})
            Me.GLAccountHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLAccoountCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GLAccountHeader.HeightF = 23.0!
            Me.GLAccountHeader.Level = 3
            Me.GLAccountHeader.Name = "GLAccountHeader"
            Me.GLAccountHeader.RepeatEveryPage = True
            '
            'label2
            '
            Me.label2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAccount")})
            Me.label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(79.16666!, 0!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(356.25!, 18.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "label2"
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(79.16667!, 18.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "GL Account: "
            '
            'GLAccountFooter
            '
            Me.GLAccountFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label17, Me.label14})
            Me.GLAccountFooter.HeightF = 36.0!
            Me.GLAccountFooter.Level = 3
            Me.GLAccountFooter.Name = "GLAccountFooter"
            '
            'label17
            '
            Me.label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(469.375!, 9.999974!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(144.5833!, 18.00001!)
            Me.label17.StylePriority.UseFont = False
            Me.label17.StylePriority.UseTextAlignment = False
            Me.label17.Text = "Total for GL Account:"
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label14
            '
            Me.label14.CanGrow = False
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccruedLiabilityAmount")})
            Me.label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(648.9582!, 9.999974!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label14.Summary = XrSummary1
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label14.TextFormatString = "{0:n2}"
            Me.label14.WordWrap = False
            '
            'JobCompHeader
            '
            Me.JobCompHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label29, Me.label9, Me.label8, Me.label7, Me.label6, Me.label10, Me.label31})
            Me.JobCompHeader.FormattingRules.Add(Me.HideZeroRows)
            Me.JobCompHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobComp", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.JobCompHeader.HeightF = 18.0!
            Me.JobCompHeader.Name = "JobCompHeader"
            Me.JobCompHeader.Visible = False
            '
            'label29
            '
            Me.label29.CanGrow = False
            Me.label29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobDescription")})
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(448.1249!, 0!)
            Me.label29.Multiline = True
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(138.5417!, 18.0!)
            Me.label29.Text = "label29"
            Me.label29.WordWrap = False
            '
            'label9
            '
            Me.label9.CanGrow = False
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber")})
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(378.125!, 0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label9.StylePriority.UseTextAlignment = False
            Me.label9.Text = "label9"
            Me.label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label9.TextFormatString = "{0:000000}"
            Me.label9.WordWrap = False
            '
            'label8
            '
            Me.label8.CanGrow = False
            Me.label8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(306.0417!, 0!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label8.Text = "label8"
            Me.label8.WordWrap = False
            '
            'label7
            '
            Me.label7.CanGrow = False
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(230.6252!, 0!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label7.Text = "label7"
            Me.label7.WordWrap = False
            '
            'label6
            '
            Me.label6.CanGrow = False
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(153.1251!, 0!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label6.Text = "label6"
            Me.label6.WordWrap = False
            '
            'label10
            '
            Me.label10.CanGrow = False
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentNumber")})
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(597.2084!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(33.0!, 18.0!)
            Me.label10.StylePriority.UseTextAlignment = False
            Me.label10.Text = "label10"
            Me.label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label10.TextFormatString = "{0:000}"
            Me.label10.WordWrap = False
            '
            'label31
            '
            Me.label31.CanGrow = False
            Me.label31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccruedLiabilityAmount")})
            Me.label31.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(648.9582!, 0!)
            Me.label31.Multiline = True
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label31.StylePriority.UseFont = False
            Me.label31.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label31.Summary = XrSummary2
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label31.TextFormatString = "{0:n2}"
            Me.label31.WordWrap = False
            '
            'HideZeroRows
            '
            Me.HideZeroRows.Condition = "Abs([AccruedLiabilityAmountFunction])>=.01"
            Me.HideZeroRows.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.HideZeroRows.Name = "HideZeroRows"
            '
            'SalesClassFooter
            '
            Me.SalesClassFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line4, Me.label33, Me.label11})
            Me.SalesClassFooter.HeightF = 43.0!
            Me.SalesClassFooter.Level = 2
            Me.SalesClassFooter.Name = "SalesClassFooter"
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.Transparent
            Me.line4.BorderColor = System.Drawing.Color.LightGray
            Me.line4.BorderWidth = 1.0!
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.0!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseBorderWidth = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'label33
            '
            Me.label33.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(469.375!, 7.999992!)
            Me.label33.Multiline = True
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(144.5833!, 18.00001!)
            Me.label33.StylePriority.UseFont = False
            Me.label33.StylePriority.UseTextAlignment = False
            Me.label33.Text = "Total for Sales Class:"
            Me.label33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label11
            '
            Me.label11.CanGrow = False
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccruedLiabilityAmount")})
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(648.9582!, 7.999992!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label11.Summary = XrSummary3
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label11.TextFormatString = "{0:n2}"
            Me.label11.WordWrap = False
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label20, Me.label19, Me.label30, Me.label27, Me.label26, Me.line2, Me.line1, Me.label24, Me.label23, Me.label22, Me.label5, Me.label3})
            Me.PageHeader.HeightF = 102.0833!
            Me.PageHeader.Name = "PageHeader"
            '
            'label20
            '
            Me.label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(108.3333!, 74.07999!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(100.0!, 18.00003!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.Text = "Function"
            '
            'label19
            '
            Me.label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 74.07999!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(83.33334!, 17.99998!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.Text = "Sales Class"
            '
            'label30
            '
            Me.label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(452.1252!, 74.87501!)
            Me.label30.Multiline = True
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(124.2917!, 18.0!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.StylePriority.UseTextAlignment = False
            Me.label30.Text = "Description"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label27
            '
            Me.label27.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(583.9582!, 8.333333!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(100.0!, 18.00001!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.StylePriority.UseTextAlignment = False
            Me.label27.Text = "Period Ending:"
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label26
            '
            Me.label26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.end_period, "Text", "")})
            Me.label26.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(683.9582!, 8.333333!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.Text = "label26"
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'end_period
            '
            Me.end_period.Description = "End Period"
            Me.end_period.Name = "end_period"
            Me.end_period.Visible = False
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.BorderWidth = 1.0!
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseBorderWidth = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.BorderWidth = 1.0!
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 92.87504!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseBorderWidth = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'label24
            '
            Me.label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(648.9582!, 60.54166!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(100.0!, 31.54166!)
            Me.label24.StylePriority.UseFont = False
            Me.label24.StylePriority.UseTextAlignment = False
            Me.label24.Text = "Accrued" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Liability"
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label23
            '
            Me.label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(587.7084!, 74.08333!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(61.24976!, 18.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseTextAlignment = False
            Me.label23.Text = "Comp #"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label22
            '
            Me.label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(378.125!, 74.08333!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(67.00006!, 18.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.StylePriority.UseTextAlignment = False
            Me.label22.Text = "Job #"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 31.33332!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(563.5417!, 23.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.Text = "Sorted by GL Account, Sales Class, and Function"
            '
            'label3
            '
            Me.label3.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 8.333333!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(563.5417!, 23.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Accrued Liability Summary by Job, SC and Fnc"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label28, Me.line3, Me.pageInfo2, Me.pageInfo1})
            Me.PageFooter.HeightF = 33.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'label28
            '
            Me.label28.CanGrow = False
            Me.label28.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label28.ForeColor = System.Drawing.Color.SteelBlue
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(354.6668!, 9.999974!)
            Me.label28.Multiline = True
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.StylePriority.UseForeColor = False
            Me.label28.Text = "Report ID: 703"
            Me.label28.Visible = False
            Me.label28.WordWrap = False
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.BorderWidth = 1.0!
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.999947!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseBorderWidth = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(548.9583!, 9.999974!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.0!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(252.0833!, 23.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            Me.pageInfo1.TextFormatString = "{0:dddd, MMMM dd, yyyy h:mm tt}"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label18, Me.label16})
            Me.ReportFooter.HeightF = 18.00001!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'label18
            '
            Me.label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(469.375!, 0!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(144.5833!, 18.00001!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.StylePriority.UseTextAlignment = False
            Me.label18.Text = "Report Total:"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label16
            '
            Me.label16.CanGrow = False
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccruedLiabilityAmount")})
            Me.label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(648.9582!, 0!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label16.Summary = XrSummary4
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label16.TextFormatString = "{0:n2}"
            Me.label16.WordWrap = False
            '
            'SalesClassHeader
            '
            Me.SalesClassHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label12})
            Me.SalesClassHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SalesClassCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.SalesClassHeader.HeightF = 18.0!
            Me.SalesClassHeader.Level = 2
            Me.SalesClassHeader.Name = "SalesClassHeader"
            Me.SalesClassHeader.RepeatEveryPage = True
            '
            'label12
            '
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.label12.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(346.0418!, 18.0!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.Text = "label12"
            '
            'FunctionFooter
            '
            Me.FunctionFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label4, Me.label25})
            Me.FunctionFooter.HeightF = 25.0!
            Me.FunctionFooter.Level = 1
            Me.FunctionFooter.Name = "FunctionFooter"
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionTotalLabel")})
            Me.label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(430.4167!, 0!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(183.5416!, 18.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.StylePriority.UseTextAlignment = False
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label25
            '
            Me.label25.CanGrow = False
            Me.label25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccruedLiabilityAmount")})
            Me.label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(648.9581!, 0!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label25.Summary = XrSummary5
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label25.TextFormatString = "{0:n2}"
            Me.label25.WordWrap = False
            '
            'FunctionHeader
            '
            Me.FunctionHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label15})
            Me.FunctionHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.FunctionHeader.HeightF = 18.0!
            Me.FunctionHeader.Level = 1
            Me.FunctionHeader.Name = "FunctionHeader"
            '
            'label15
            '
            Me.label15.CanGrow = False
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionDescription")})
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(108.3333!, 0!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(262.7084!, 18.0!)
            Me.label15.Text = "label15"
            Me.label15.WordWrap = False
            '
            'GLAccount
            '
            Me.GLAccount.Expression = "Concat([GLAccoountCode],' - ',[GLAccountDesc])"
            Me.GLAccount.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.GLAccount.Name = "GLAccount"
            '
            'JobComp
            '
            Me.JobComp.Expression = "Concat(PadLeft([JobNumber],6,0),'-',PadLeft([JobComponentNumber],3,0))"
            Me.JobComp.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobComp.Name = "JobComp"
            '
            'JobCompFunction
            '
            Me.JobCompFunction.Expression = "Concat([JobComp],'-',[FunctionCode])"
            Me.JobCompFunction.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobCompFunction.Name = "JobCompFunction"
            '
            'FunctionTotalLabel
            '
            Me.FunctionTotalLabel.Expression = "concat('Total for Function ',[FunctionCode],':')"
            Me.FunctionTotalLabel.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.FunctionTotalLabel.Name = "FunctionTotalLabel"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.MonthEndAccruedLiability)
            '
            'AccruedLiabilitySummarybyJobSalesClassFunction
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GLAccountHeader, Me.GLAccountFooter, Me.JobCompHeader, Me.SalesClassFooter, Me.PageHeader, Me.PageFooter, Me.ReportFooter, Me.SalesClassHeader, Me.FunctionFooter, Me.FunctionHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.GLAccount, Me.JobComp, Me.JobCompFunction, Me.FunctionTotalLabel})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "703 Accrued Liability Summary by Job, SC and Fnc"
            Me.FilterString = "[RecordType] = 'BL'"
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.HideZeroRows})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.end_period})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents GLAccountHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLAccountFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobCompHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents HideZeroRows As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents SalesClassFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents end_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SalesClassHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FunctionFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FunctionHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLAccount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents JobComp As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents JobCompFunction As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents FunctionTotalLabel As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






