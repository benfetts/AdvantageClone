Namespace MediaWIP.AccountsPayable

    Partial Public Class AccountsPayableAgedDetailNoGLAccount
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
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary13 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary14 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary15 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary16 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary17 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.VendorHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.VendorFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.InvoiceIDHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label51 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label50 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.label46 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label47 = New DevExpress.XtraReports.UI.XRLabel()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label48 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label42 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label43 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label44 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label45 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailVisible = New DevExpress.XtraReports.UI.FormattingRule()
            Me.InvoiceVisible = New DevExpress.XtraReports.UI.FormattingRule()
            Me.AgingOption = New DevExpress.XtraReports.UI.CalculatedField()
            Me.VendorConcatCodeName = New DevExpress.XtraReports.UI.CalculatedField()
            Me.InvoiceID = New DevExpress.XtraReports.UI.CalculatedField()
            Me.InvoiceBalance = New DevExpress.XtraReports.UI.CalculatedField()
            Me.end_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.aging_date = New DevExpress.XtraReports.Parameters.Parameter()
            Me.aging_option = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label32, Me.label23, Me.label24, Me.label25, Me.label27, Me.label31, Me.label22, Me.label21})
            Me.Detail.FormattingRules.Add(Me.DetailVisible)
            Me.Detail.HeightF = 18.00001!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("APType", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("CheckDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.Detail.Visible = False
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label9, Me.label7, Me.label1, Me.label30, Me.label51, Me.label50, Me.label20, Me.label19, Me.label18, Me.label17, Me.label16, Me.line3, Me.label46, Me.line1, Me.label6, Me.label5, Me.label4, Me.label3, Me.label2})
            Me.PageHeader.HeightF = 107.1667!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label47, Me.pageInfo2, Me.pageInfo1, Me.line2})
            Me.PageFooter.HeightF = 32.00003!
            Me.PageFooter.Name = "PageFooter"
            '
            'VendorHeader
            '
            Me.VendorHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label38})
            Me.VendorHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.VendorHeader.HeightF = 27.9583!
            Me.VendorHeader.Level = 1
            Me.VendorHeader.Name = "VendorHeader"
            Me.VendorHeader.RepeatEveryPage = True
            '
            'VendorFooter
            '
            Me.VendorFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label26, Me.label8, Me.label48, Me.label15, Me.label14, Me.label13, Me.label12, Me.label11})
            Me.VendorFooter.HeightF = 35.0!
            Me.VendorFooter.Level = 1
            Me.VendorFooter.Name = "VendorFooter"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label29, Me.label28, Me.label33, Me.label34, Me.label35, Me.label36, Me.label37})
            Me.ReportFooter.HeightF = 23.0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'InvoiceIDHeader
            '
            Me.InvoiceIDHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label41, Me.label42, Me.label43, Me.label44, Me.label45, Me.label40, Me.label39, Me.label10})
            Me.InvoiceIDHeader.FormattingRules.Add(Me.InvoiceVisible)
            Me.InvoiceIDHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InvoiceDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("InvoiceID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.InvoiceIDHeader.HeightF = 18.0!
            Me.InvoiceIDHeader.Name = "InvoiceIDHeader"
            '
            'label32
            '
            Me.label32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APType")})
            Me.label32.ForeColor = System.Drawing.Color.SteelBlue
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(702.0833!, 0!)
            Me.label32.Multiline = True
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(46.875!, 17.99995!)
            Me.label32.StylePriority.UseForeColor = False
            Me.label32.Text = "label32"
            Me.label32.Visible = False
            '
            'label23
            '
            Me.label23.CanGrow = False
            Me.label23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OverNinetyDays")})
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(578.9583!, 0!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label23.StylePriority.UseTextAlignment = False
            Me.label23.Text = "label15"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label23.TextFormatString = "{0:n2}"
            Me.label23.WordWrap = False
            '
            'label24
            '
            Me.label24.CanGrow = False
            Me.label24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NinetyDays")})
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(493.9583!, 0!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label24.StylePriority.UseTextAlignment = False
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label24.TextFormatString = "{0:n2}"
            Me.label24.WordWrap = False
            '
            'label25
            '
            Me.label25.CanGrow = False
            Me.label25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SixtyDays")})
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(408.9584!, 0!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label25.StylePriority.UseTextAlignment = False
            Me.label25.Text = "label13"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label25.TextFormatString = "{0:n2}"
            Me.label25.WordWrap = False
            '
            'label27
            '
            Me.label27.CanGrow = False
            Me.label27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ThirtyDays")})
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(323.9583!, 0!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label27.StylePriority.UseTextAlignment = False
            Me.label27.Text = "label12"
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label27.TextFormatString = "{0:n2}"
            Me.label27.WordWrap = False
            '
            'label31
            '
            Me.label31.CanGrow = False
            Me.label31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CurrentAmount")})
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(238.9584!, 0!)
            Me.label31.Multiline = True
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label31.StylePriority.UseTextAlignment = False
            Me.label31.Text = "label11"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label31.TextFormatString = "{0:n2}"
            Me.label31.WordWrap = False
            '
            'label22
            '
            Me.label22.CanGrow = False
            Me.label22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckDate")})
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(138.9584!, 0!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label22.TextFormatString = "{0:d}"
            Me.label22.WordWrap = False
            '
            'label21
            '
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.label21.Multiline = True
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(65.00006!, 17.99998!)
            Me.label21.StylePriority.UseTextAlignment = False
            Me.label21.Text = "Payment"
            Me.label21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label9
            '
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingOption")})
            Me.label9.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(665.0!, 46.0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.StylePriority.UseTextAlignment = False
            Me.label9.Text = "label9"
            Me.label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label7
            '
            Me.label7.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(583.9583!, 46.0!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(80.0!, 18.0!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.StylePriority.UseTextAlignment = False
            Me.label7.Text = "Aged On:"
            Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 10.00001!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(376.0417!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Aged Accounts Payable"
            '
            'label30
            '
            Me.label30.CanGrow = False
            Me.label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(0!, 60.87503!)
            Me.label30.Multiline = True
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(61.45833!, 18.0!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.Text = "Vendor"
            '
            'label51
            '
            Me.label51.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label51.LocationFloat = New DevExpress.Utils.PointFloat(138.9584!, 78.87503!)
            Me.label51.Multiline = True
            Me.label51.Name = "label51"
            Me.label51.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label51.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label51.StylePriority.UseFont = False
            Me.label51.Text = "Invoice Date"
            '
            'label50
            '
            Me.label50.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label50.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 79.1667!)
            Me.label50.Multiline = True
            Me.label50.Name = "label50"
            Me.label50.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label50.SizeF = New System.Drawing.SizeF(125.4167!, 18.0!)
            Me.label50.StylePriority.UseFont = False
            Me.label50.Text = "Invoice Number"
            '
            'label20
            '
            Me.label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(578.9583!, 78.87503!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.StylePriority.UseTextAlignment = False
            Me.label20.Text = "Over 90 Days"
            Me.label20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label19
            '
            Me.label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(493.9583!, 78.87503!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.StylePriority.UseTextAlignment = False
            Me.label19.Text = "61 - 90 Days"
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label18
            '
            Me.label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(408.9583!, 78.87503!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.StylePriority.UseTextAlignment = False
            Me.label18.Text = "31 - 60 Days"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label17
            '
            Me.label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(323.9583!, 78.87503!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label17.StylePriority.UseFont = False
            Me.label17.StylePriority.UseTextAlignment = False
            Me.label17.Text = "1 - 30 Days"
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label16
            '
            Me.label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(238.9584!, 78.87503!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.StylePriority.UseTextAlignment = False
            Me.label16.Text = "Current"
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 100.0!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'label46
            '
            Me.label46.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label46.LocationFloat = New DevExpress.Utils.PointFloat(663.9583!, 79.1667!)
            Me.label46.Multiline = True
            Me.label46.Name = "label46"
            Me.label46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label46.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label46.StylePriority.UseFont = False
            Me.label46.StylePriority.UseTextAlignment = False
            Me.label46.Text = "Balance"
            Me.label46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseBorders = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'label6
            '
            Me.label6.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(583.9583!, 28.00001!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(80.0!, 18.0!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.StylePriority.UseTextAlignment = False
            Me.label6.Text = "Aging Date:"
            Me.label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(583.9583!, 10.00001!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(80.0!, 18.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.StylePriority.UseTextAlignment = False
            Me.label5.Text = "Period Ending:"
            Me.label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.aging_date, "Text", "")})
            Me.label4.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(665.0!, 28.00001!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(83.95837!, 18.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.StylePriority.UseTextAlignment = False
            Me.label4.Text = "label4"
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label4.TextFormatString = "{0:d}"
            '
            'label3
            '
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.end_period, "Text", "")})
            Me.label3.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(665.0!, 10.00001!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(83.95837!, 18.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.StylePriority.UseTextAlignment = False
            Me.label3.Text = "label3"
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99999!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(376.0417!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Sorted by Vendor and Invoice Date"
            '
            'label47
            '
            Me.label47.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label47.ForeColor = System.Drawing.Color.SteelBlue
            Me.label47.LocationFloat = New DevExpress.Utils.PointFloat(408.3333!, 14.0!)
            Me.label47.Multiline = True
            Me.label47.Name = "label47"
            Me.label47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label47.SizeF = New System.Drawing.SizeF(112.5!, 18.00003!)
            Me.label47.StylePriority.UseFont = False
            Me.label47.StylePriority.UseForeColor = False
            Me.label47.Text = "Report ID: 506"
            Me.label47.Visible = False
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(548.9584!, 14.0!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(200.0!, 18.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 14.0!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(203.125!, 18.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.0!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'label38
            '
            Me.label38.CanGrow = False
            Me.label38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorConcatCodeName")})
            Me.label38.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label38.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label38.Multiline = True
            Me.label38.Name = "label38"
            Me.label38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label38.SizeF = New System.Drawing.SizeF(339.5833!, 18.0!)
            Me.label38.StylePriority.UseFont = False
            Me.label38.Text = "label10"
            '
            'label26
            '
            Me.label26.CanGrow = False
            Me.label26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(663.9584!, 4.000028!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label26.Summary = XrSummary1
            Me.label26.Text = "label21"
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label26.TextFormatString = "{0:n2}"
            Me.label26.WordWrap = False
            '
            'label8
            '
            Me.label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(36.87496!, 4.000028!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(113.5416!, 18.00001!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.Text = "Total for Vendor:"
            '
            'label48
            '
            Me.label48.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode")})
            Me.label48.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label48.LocationFloat = New DevExpress.Utils.PointFloat(150.4167!, 4.000028!)
            Me.label48.Multiline = True
            Me.label48.Name = "label48"
            Me.label48.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label48.SizeF = New System.Drawing.SizeF(75.0!, 18.0!)
            Me.label48.StylePriority.UseFont = False
            Me.label48.Text = "label48"
            '
            'label15
            '
            Me.label15.CanGrow = False
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OverNinetyDays")})
            Me.label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(578.9583!, 4.000028!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label15.Summary = XrSummary2
            Me.label15.Text = "label15"
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label15.TextFormatString = "{0:n2}"
            Me.label15.WordWrap = False
            '
            'label14
            '
            Me.label14.CanGrow = False
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NinetyDays")})
            Me.label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(493.9583!, 4.000028!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.StylePriority.UseTextAlignment = False
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label14.Summary = XrSummary3
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label14.TextFormatString = "{0:n2}"
            Me.label14.WordWrap = False
            '
            'label13
            '
            Me.label13.CanGrow = False
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SixtyDays")})
            Me.label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(408.9583!, 4.000028!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label13.Summary = XrSummary4
            Me.label13.Text = "label13"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label13.TextFormatString = "{0:n2}"
            Me.label13.WordWrap = False
            '
            'label12
            '
            Me.label12.CanGrow = False
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ThirtyDays")})
            Me.label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(323.9583!, 4.000028!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary5
            Me.label12.Text = "label12"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label12.TextFormatString = "{0:n2}"
            Me.label12.WordWrap = False
            '
            'label11
            '
            Me.label11.CanGrow = False
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CurrentAmount")})
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(238.9584!, 4.000028!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label11.Summary = XrSummary6
            Me.label11.Text = "label11"
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label11.TextFormatString = "{0:n2}"
            Me.label11.WordWrap = False
            '
            'label29
            '
            Me.label29.CanGrow = False
            Me.label29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(663.9584!, 3.999964!)
            Me.label29.Multiline = True
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label29.StylePriority.UseFont = False
            Me.label29.StylePriority.UseTextAlignment = False
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label29.Summary = XrSummary7
            Me.label29.Text = "label21"
            Me.label29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label29.TextFormatString = "{0:n2}"
            Me.label29.WordWrap = False
            '
            'label28
            '
            Me.label28.CanGrow = False
            Me.label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(36.87496!, 4.000028!)
            Me.label28.Multiline = True
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(138.5416!, 18.00001!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.Text = "Total for Report:"
            Me.label28.WordWrap = False
            '
            'label33
            '
            Me.label33.CanGrow = False
            Me.label33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NinetyDays")})
            Me.label33.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(493.9583!, 3.999964!)
            Me.label33.Multiline = True
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label33.StylePriority.UseFont = False
            Me.label33.StylePriority.UseTextAlignment = False
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label33.Summary = XrSummary8
            Me.label33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label33.TextFormatString = "{0:n2}"
            Me.label33.WordWrap = False
            '
            'label34
            '
            Me.label34.CanGrow = False
            Me.label34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SixtyDays")})
            Me.label34.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label34.LocationFloat = New DevExpress.Utils.PointFloat(408.9583!, 3.999964!)
            Me.label34.Multiline = True
            Me.label34.Name = "label34"
            Me.label34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label34.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label34.StylePriority.UseFont = False
            Me.label34.StylePriority.UseTextAlignment = False
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label34.Summary = XrSummary9
            Me.label34.Text = "label13"
            Me.label34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label34.TextFormatString = "{0:n2}"
            Me.label34.WordWrap = False
            '
            'label35
            '
            Me.label35.CanGrow = False
            Me.label35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ThirtyDays")})
            Me.label35.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(323.9583!, 3.999964!)
            Me.label35.Multiline = True
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.StylePriority.UseTextAlignment = False
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label35.Summary = XrSummary10
            Me.label35.Text = "label12"
            Me.label35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label35.TextFormatString = "{0:n2}"
            Me.label35.WordWrap = False
            '
            'label36
            '
            Me.label36.CanGrow = False
            Me.label36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CurrentAmount")})
            Me.label36.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(238.9584!, 4.000028!)
            Me.label36.Multiline = True
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label36.StylePriority.UseFont = False
            Me.label36.StylePriority.UseTextAlignment = False
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label36.Summary = XrSummary11
            Me.label36.Text = "label11"
            Me.label36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label36.TextFormatString = "{0:n2}"
            Me.label36.WordWrap = False
            '
            'label37
            '
            Me.label37.CanGrow = False
            Me.label37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OverNinetyDays")})
            Me.label37.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(578.9583!, 3.999964!)
            Me.label37.Multiline = True
            Me.label37.Name = "label37"
            Me.label37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label37.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label37.StylePriority.UseFont = False
            Me.label37.StylePriority.UseTextAlignment = False
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label37.Summary = XrSummary12
            Me.label37.Text = "label15"
            Me.label37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label37.TextFormatString = "{0:n2}"
            Me.label37.WordWrap = False
            '
            'label41
            '
            Me.label41.CanGrow = False
            Me.label41.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceBalance")})
            Me.label41.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.label41.LocationFloat = New DevExpress.Utils.PointFloat(663.9584!, 0!)
            Me.label41.Multiline = True
            Me.label41.Name = "label41"
            Me.label41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label41.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label41.StylePriority.UseFont = False
            Me.label41.StylePriority.UseTextAlignment = False
            Me.label41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label41.TextFormatString = "{0:n2}"
            Me.label41.WordWrap = False
            '
            'label42
            '
            Me.label42.CanGrow = False
            Me.label42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CurrentAmount")})
            Me.label42.LocationFloat = New DevExpress.Utils.PointFloat(238.9584!, 0!)
            Me.label42.Multiline = True
            Me.label42.Name = "label42"
            Me.label42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label42.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label42.StylePriority.UseTextAlignment = False
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label42.Summary = XrSummary13
            Me.label42.Text = "label11"
            Me.label42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label42.TextFormatString = "{0:n2}"
            Me.label42.WordWrap = False
            '
            'label43
            '
            Me.label43.CanGrow = False
            Me.label43.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ThirtyDays")})
            Me.label43.LocationFloat = New DevExpress.Utils.PointFloat(323.9583!, 0!)
            Me.label43.Multiline = True
            Me.label43.Name = "label43"
            Me.label43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label43.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label43.StylePriority.UseTextAlignment = False
            XrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label43.Summary = XrSummary14
            Me.label43.Text = "label12"
            Me.label43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label43.TextFormatString = "{0:n2}"
            Me.label43.WordWrap = False
            '
            'label44
            '
            Me.label44.CanGrow = False
            Me.label44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SixtyDays")})
            Me.label44.LocationFloat = New DevExpress.Utils.PointFloat(408.9583!, 0!)
            Me.label44.Multiline = True
            Me.label44.Name = "label44"
            Me.label44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label44.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label44.StylePriority.UseTextAlignment = False
            XrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label44.Summary = XrSummary15
            Me.label44.Text = "label13"
            Me.label44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label44.TextFormatString = "{0:n2}"
            Me.label44.WordWrap = False
            '
            'label45
            '
            Me.label45.CanGrow = False
            Me.label45.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NinetyDays")})
            Me.label45.LocationFloat = New DevExpress.Utils.PointFloat(493.9583!, 0!)
            Me.label45.Multiline = True
            Me.label45.Name = "label45"
            Me.label45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label45.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label45.StylePriority.UseTextAlignment = False
            XrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label45.Summary = XrSummary16
            Me.label45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label45.TextFormatString = "{0:n2}"
            Me.label45.WordWrap = False
            '
            'label40
            '
            Me.label40.CanGrow = False
            Me.label40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OverNinetyDays")})
            Me.label40.LocationFloat = New DevExpress.Utils.PointFloat(578.9583!, 0!)
            Me.label40.Multiline = True
            Me.label40.Name = "label40"
            Me.label40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label40.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label40.StylePriority.UseTextAlignment = False
            XrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label40.Summary = XrSummary17
            Me.label40.Text = "label15"
            Me.label40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label40.TextFormatString = "{0:n2}"
            Me.label40.WordWrap = False
            '
            'label39
            '
            Me.label39.CanGrow = False
            Me.label39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate")})
            Me.label39.LocationFloat = New DevExpress.Utils.PointFloat(138.9584!, 0!)
            Me.label39.Multiline = True
            Me.label39.Name = "label39"
            Me.label39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label39.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label39.TextFormatString = "{0:d}"
            Me.label39.WordWrap = False
            '
            'label10
            '
            Me.label10.CanGrow = False
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(125.4167!, 18.0!)
            Me.label10.WordWrap = False
            '
            'DetailVisible
            '
            Me.DetailVisible.Condition = "[APType]='CK'"
            Me.DetailVisible.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.DetailVisible.Name = "DetailVisible"
            '
            'InvoiceVisible
            '
            Me.InvoiceVisible.Condition = "[APType]='CK'"
            Me.InvoiceVisible.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.InvoiceVisible.Name = "InvoiceVisible"
            '
            'AgingOption
            '
            Me.AgingOption.Expression = "IIf(?aging_option=1,'Invoice Date','Date To Pay')"
            Me.AgingOption.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.AgingOption.Name = "AgingOption"
            '
            'VendorConcatCodeName
            '
            Me.VendorConcatCodeName.Expression = "Concat([VendorCode],' - ',[VendorName])"
            Me.VendorConcatCodeName.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.VendorConcatCodeName.Name = "VendorConcatCodeName"
            '
            'InvoiceID
            '
            Me.InvoiceID.Expression = "Concat([InvoiceNumber],'-',ToStr([APIdentifier]),'-',[APType])"
            Me.InvoiceID.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.InvoiceID.Name = "InvoiceID"
            '
            'InvoiceBalance
            '
            Me.InvoiceBalance.Expression = "[][[APIdentifier]=[^.APIdentifier]].Sum([BalanceAmount])"
            Me.InvoiceBalance.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.InvoiceBalance.Name = "InvoiceBalance"
            '
            'end_period
            '
            Me.end_period.Description = "End Period"
            Me.end_period.Name = "end_period"
            Me.end_period.Visible = False
            '
            'aging_date
            '
            Me.aging_date.Description = "Aging Date"
            Me.aging_date.Name = "aging_date"
            Me.aging_date.Type = GetType(Date)
            Me.aging_date.ValueInfo = "2020-08-26"
            Me.aging_date.Visible = False
            '
            'aging_option
            '
            Me.aging_option.Description = "Aging Option"
            Me.aging_option.Name = "aging_option"
            Me.aging_option.Type = GetType(Integer)
            Me.aging_option.ValueInfo = "0"
            Me.aging_option.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.MonthEndAccountsPayable)
            '
            'AccountsPayableAgedDetailNoGLAccount
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.VendorHeader, Me.VendorFooter, Me.ReportFooter, Me.InvoiceIDHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.AgingOption, Me.VendorConcatCodeName, Me.InvoiceID, Me.InvoiceBalance})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "506-Accounts Payable Aged Detail (No GL Account)"
            Me.FilterString = "[TotalAmountSumGLAPID] <> 0.0"
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.DetailVisible, Me.InvoiceVisible})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.end_period, Me.aging_date, Me.aging_option})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailVisible As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label51 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label50 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label46 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents aging_date As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents end_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents label47 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents VendorHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label38 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents VendorFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label48 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label34 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents InvoiceIDHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label41 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label42 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label43 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label44 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label45 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label40 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents InvoiceVisible As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents AgingOption As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents VendorConcatCodeName As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InvoiceID As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InvoiceBalance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents aging_option As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






