Namespace MediaWIP.AccruedLiabilities

    Partial Public Class AccruedLiabilitySummarybyJobAPLimited
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
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GLAccountHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLAccountFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobCompHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.JobCompFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.end_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobComp = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GLAccount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.APInvoiceAmountLimited = New DevExpress.XtraReports.UI.CalculatedField()
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
            Me.GLAccountHeader.Level = 1
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
            Me.GLAccountFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label17, Me.label13, Me.label14})
            Me.GLAccountFooter.HeightF = 36.0!
            Me.GLAccountFooter.Level = 1
            Me.GLAccountFooter.Name = "GLAccountFooter"
            '
            'label17
            '
            Me.label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(354.6668!, 7.999992!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(144.5833!, 18.00001!)
            Me.label17.StylePriority.UseFont = False
            Me.label17.StylePriority.UseTextAlignment = False
            Me.label17.Text = "Total for GL Account:"
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label13
            '
            Me.label13.CanGrow = False
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APInvoiceAmountLimited")})
            Me.label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 7.999992!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label13.Summary = XrSummary1
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label13.TextFormatString = "{0:n2}"
            Me.label13.WordWrap = False
            '
            'label14
            '
            Me.label14.CanGrow = False
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccruedLiabilityAmount")})
            Me.label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(548.9583!, 7.999992!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label14.Summary = XrSummary2
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label14.TextFormatString = "{0:n2}"
            Me.label14.WordWrap = False
            '
            'JobCompHeader
            '
            Me.JobCompHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("JobComp", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.JobCompHeader.HeightF = 0!
            Me.JobCompHeader.Name = "JobCompHeader"
            '
            'JobCompFooter
            '
            Me.JobCompFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label12, Me.label11, Me.label10, Me.label9, Me.label8, Me.label7, Me.label6})
            Me.JobCompFooter.HeightF = 18.0!
            Me.JobCompFooter.Name = "JobCompFooter"
            '
            'label12
            '
            Me.label12.CanGrow = False
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APInvoiceAmountLimited")})
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary3
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label12.TextFormatString = "{0:n2}"
            Me.label12.WordWrap = False
            '
            'label11
            '
            Me.label11.CanGrow = False
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccruedLiabilityAmount")})
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(548.9583!, 0!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label11.Summary = XrSummary4
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label11.TextFormatString = "{0:n2}"
            Me.label11.WordWrap = False
            '
            'label10
            '
            Me.label10.CanGrow = False
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentNumber")})
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(476.6668!, 0!)
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
            'label9
            '
            Me.label9.CanGrow = False
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber")})
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(401.2501!, 0!)
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
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(273.7501!, 0!)
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
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(183.75!, 0!)
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
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(101.0!, 0!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label6.Text = "label6"
            Me.label6.WordWrap = False
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label27, Me.label26, Me.line2, Me.line1, Me.label25, Me.label24, Me.label23, Me.label22, Me.label21, Me.label20, Me.label19, Me.label5, Me.label4, Me.label3})
            Me.PageHeader.HeightF = 127.0833!
            Me.PageHeader.Name = "PageHeader"
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
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 115.875!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseBorderWidth = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'label25
            '
            Me.label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(648.9583!, 84.33333!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(100.0!, 31.54166!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.StylePriority.UseTextAlignment = False
            Me.label25.Text = "Voucher" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label24
            '
            Me.label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(548.9583!, 84.33333!)
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
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(466.2501!, 97.87499!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(61.45834!, 18.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.Text = "Comp #"
            '
            'label22
            '
            Me.label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(399.25!, 97.87499!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(67.00006!, 18.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.StylePriority.UseTextAlignment = False
            Me.label22.Text = "Job #"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label21
            '
            Me.label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(273.7501!, 97.87499!)
            Me.label21.Multiline = True
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label21.StylePriority.UseFont = False
            Me.label21.Text = "Product"
            '
            'label20
            '
            Me.label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(183.75!, 97.87499!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(65.00002!, 18.0!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.Text = "Division"
            '
            'label19
            '
            Me.label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(101.0!, 97.87499!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(65.00002!, 18.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.Text = "Client"
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 54.33331!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(351.0417!, 23.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.Text = "Sorted by GL Account, Client and Job"
            '
            'label4
            '
            Me.label4.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 31.33332!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(351.0417!, 23.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.Text = "A/P Limited to Billed Amount"
            '
            'label3
            '
            Me.label3.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 8.333333!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(351.0417!, 23.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Accrued Liability Summary by Job"
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
            Me.label28.Text = "Report ID: 700"
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
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label18, Me.label15, Me.label16})
            Me.ReportFooter.HeightF = 18.00001!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'label18
            '
            Me.label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(354.6668!, 0!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(144.5833!, 18.00001!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.StylePriority.UseTextAlignment = False
            Me.label18.Text = "Report Total:"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label15
            '
            Me.label15.CanGrow = False
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APInvoiceAmountLimited")})
            Me.label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label15.Summary = XrSummary5
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label15.TextFormatString = "{0:n2}"
            Me.label15.WordWrap = False
            '
            'label16
            '
            Me.label16.CanGrow = False
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccruedLiabilityAmount")})
            Me.label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(548.9583!, 0!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label16.Summary = XrSummary6
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label16.TextFormatString = "{0:n2}"
            Me.label16.WordWrap = False
            '
            'JobComp
            '
            Me.JobComp.Expression = "Concat(PadLeft([JobNumber],6,0),'-',PadLeft([JobComponentNumber],3,0))"
            Me.JobComp.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobComp.Name = "JobComp"
            '
            'GLAccount
            '
            Me.GLAccount.Expression = "Concat([GLAccoountCode],' - ',[GLAccountDesc])"
            Me.GLAccount.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.GLAccount.Name = "GLAccount"
            '
            'APInvoiceAmountLimited
            '
            Me.APInvoiceAmountLimited.Expression = "IIf([APLimitedJobFlag]=1,[AccruedLiabilityAmount],[APInvoiceAmount])"
            Me.APInvoiceAmountLimited.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.APInvoiceAmountLimited.Name = "APInvoiceAmountLimited"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.MonthEndAccruedLiability)
            '
            'AccruedLiabilitySummarybyJobAPLimited
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GLAccountHeader, Me.GLAccountFooter, Me.JobCompHeader, Me.JobCompFooter, Me.PageHeader, Me.PageFooter, Me.ReportFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.JobComp, Me.GLAccount, Me.APInvoiceAmountLimited})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "700 Accrued Liability Summary by Job-AP Limited"
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
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
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobCompHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents JobCompFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents end_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobComp As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents GLAccount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents APInvoiceAmountLimited As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






