Namespace MediaWIP.ProductionWIP

    Partial Public Class ProductionWIPSummarybyJobwithPayments
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.OfficeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OfficeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobCompHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.JobCompFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.end_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.label52 = New DevExpress.XtraReports.UI.XRLabel()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivProdHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivProdFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.APInvoiceHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.APInvoiceFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailFilter = New DevExpress.XtraReports.UI.FormattingRule()
            Me.JobComp = New DevExpress.XtraReports.UI.CalculatedField()
            Me.OfficeLabel = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientDivProdCode = New DevExpress.XtraReports.UI.CalculatedField()
            Me.APTotalPaid = New DevExpress.XtraReports.UI.CalculatedField()
            Me.APTotalUnpaid = New DevExpress.XtraReports.UI.CalculatedField()
            Me.APPaymentRefPrint = New DevExpress.XtraReports.UI.CalculatedField()
            Me.APInvoicePmtRefGroup = New DevExpress.XtraReports.UI.CalculatedField()
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
            'OfficeHeader
            '
            Me.OfficeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label4, Me.label3})
            Me.OfficeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OfficeHeader.HeightF = 28.0!
            Me.OfficeHeader.Level = 3
            Me.OfficeHeader.Name = "OfficeHeader"
            Me.OfficeHeader.RepeatEveryPage = True
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeLabel")})
            Me.label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(52.08333!, 0!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(369.4984!, 20.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.Text = "label4"
            '
            'label3
            '
            Me.label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(52.08333!, 20.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "Office: "
            '
            'OfficeFooter
            '
            Me.OfficeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label19, Me.label22, Me.label31})
            Me.OfficeFooter.HeightF = 20.0!
            Me.OfficeFooter.Level = 3
            Me.OfficeFooter.Name = "OfficeFooter"
            Me.OfficeFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
            '
            'label19
            '
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalUnpaid")})
            Me.label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(438.2084!, 0!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label19.Summary = XrSummary1
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label19.TextFormatString = "{0:n2}"
            Me.label19.WordWrap = False
            '
            'label22
            '
            Me.label22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalPaid")})
            Me.label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(527.2084!, 0!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label22.Summary = XrSummary2
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label22.TextFormatString = "{0:n2}"
            Me.label22.WordWrap = False
            '
            'label31
            '
            Me.label31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(168.9582!, 0!)
            Me.label31.Multiline = True
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(170.2916!, 20.0!)
            Me.label31.StylePriority.UseFont = False
            Me.label31.Text = "Total for Office"
            '
            'JobCompHeader
            '
            Me.JobCompHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobComp", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.JobCompHeader.HeightF = 0!
            Me.JobCompHeader.Level = 1
            Me.JobCompHeader.Name = "JobCompHeader"
            Me.JobCompHeader.RepeatEveryPage = True
            '
            'JobCompFooter
            '
            Me.JobCompFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label6, Me.label9, Me.label30})
            Me.JobCompFooter.HeightF = 25.0!
            Me.JobCompFooter.Level = 1
            Me.JobCompFooter.Name = "JobCompFooter"
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalPaid")})
            Me.label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(527.2084!, 0!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.StylePriority.UseTextAlignment = False
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label6.Summary = XrSummary3
            Me.label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label6.TextFormatString = "{0:n2}"
            Me.label6.WordWrap = False
            '
            'label9
            '
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalUnpaid")})
            Me.label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(438.2084!, 0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.StylePriority.UseTextAlignment = False
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label9.Summary = XrSummary4
            Me.label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label9.TextFormatString = "{0:n2}"
            Me.label9.WordWrap = False
            '
            'label30
            '
            Me.label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(168.9582!, 0!)
            Me.label30.Multiline = True
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(170.2916!, 20.0!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.Text = "Total for Job/Component"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line3, Me.label13, Me.label12, Me.label11, Me.label8, Me.label7, Me.label5, Me.label2, Me.label1, Me.label40, Me.label39, Me.line1})
            Me.PageHeader.HeightF = 115.0!
            Me.PageHeader.Name = "PageHeader"
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 105.5833!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'label13
            '
            Me.label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(623.5001!, 84.99998!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(125.4582!, 20.0!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            Me.label13.Text = "Payment Ref."
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label12
            '
            Me.label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(526.1668!, 84.99998!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            Me.label12.Text = "WIP Paid"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label11
            '
            Me.label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(437.1667!, 84.99998!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            Me.label11.Text = "WIP Unpaid"
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label8
            '
            Me.label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(271.875!, 84.99998!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.Text = "Invoice Number"
            '
            'label7
            '
            Me.label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 84.99998!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(165.0!, 20.0!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.Text = "Vendor Name"
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 84.99998!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.Text = "Job / Comp Nbr"
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99999!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(451.0417!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Sorted by Office, Client/Division/Product, Job, Vendor"
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(483.0!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Production WIP Summary by Job with Payments"
            '
            'label40
            '
            Me.label40.LocationFloat = New DevExpress.Utils.PointFloat(602.7083!, 10.00001!)
            Me.label40.Multiline = True
            Me.label40.Name = "label40"
            Me.label40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label40.SizeF = New System.Drawing.SizeF(81.25!, 23.0!)
            Me.label40.StylePriority.UseTextAlignment = False
            Me.label40.Text = "Period Ending:"
            Me.label40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label39
            '
            Me.label39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.end_period, "Text", "")})
            Me.label39.LocationFloat = New DevExpress.Utils.PointFloat(683.9583!, 10.00001!)
            Me.label39.Multiline = True
            Me.label39.Name = "label39"
            Me.label39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label39.SizeF = New System.Drawing.SizeF(65.0!, 23.0!)
            Me.label39.StylePriority.UseTextAlignment = False
            Me.label39.Text = "label39"
            Me.label39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'end_period
            '
            Me.end_period.Description = "Period Ending"
            Me.end_period.Name = "end_period"
            Me.end_period.Visible = False
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
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label52, Me.pageInfo2, Me.pageInfo1, Me.line4})
            Me.PageFooter.HeightF = 30.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'label52
            '
            Me.label52.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label52.LocationFloat = New DevExpress.Utils.PointFloat(320.54!, 9.999974!)
            Me.label52.Multiline = True
            Me.label52.Name = "label52"
            Me.label52.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label52.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.label52.StylePriority.UseFont = False
            Me.label52.Text = "Report ID: 403"
            Me.label52.Visible = False
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(648.9583!, 9.999974!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} Of {1}"
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(308.3333!, 20.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            Me.pageInfo1.TextFormatString = "{0:dddd, MMMM dd, yyyy h:mm tt}"
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.LightGray
            Me.line4.BorderColor = System.Drawing.Color.LightGray
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.000028!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label23, Me.label27, Me.label35})
            Me.ReportFooter.HeightF = 30.00001!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'label23
            '
            Me.label23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalUnpaid")})
            Me.label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(438.2084!, 10.00001!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseTextAlignment = False
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label23.Summary = XrSummary5
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label23.TextFormatString = "{0:n2}"
            Me.label23.WordWrap = False
            '
            'label27
            '
            Me.label27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalPaid")})
            Me.label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(527.2084!, 10.00001!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.StylePriority.UseTextAlignment = False
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label27.Summary = XrSummary6
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label27.TextFormatString = "{0:n2}"
            Me.label27.WordWrap = False
            '
            'label35
            '
            Me.label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(168.9582!, 10.00001!)
            Me.label35.Multiline = True
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(170.2916!, 20.0!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.Text = "Total for Report"
            '
            'ClientDivProdHeader
            '
            Me.ClientDivProdHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label16, Me.label17})
            Me.ClientDivProdHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientDivProdCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientDivProdHeader.HeightF = 28.0!
            Me.ClientDivProdHeader.Level = 2
            Me.ClientDivProdHeader.Name = "ClientDivProdHeader"
            Me.ClientDivProdHeader.RepeatEveryPage = True
            '
            'label16
            '
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDivProdCode")})
            Me.label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(92.70834!, 0!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(257.2917!, 20.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.Text = "label16"
            Me.label16.WordWrap = False
            '
            'label17
            '
            Me.label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(92.70834!, 20.0!)
            Me.label17.StylePriority.UseFont = False
            Me.label17.Text = "Client/Div/Prod:"
            Me.label17.WordWrap = False
            '
            'ClientDivProdFooter
            '
            Me.ClientDivProdFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label15, Me.label18, Me.label10})
            Me.ClientDivProdFooter.HeightF = 30.0!
            Me.ClientDivProdFooter.Level = 2
            Me.ClientDivProdFooter.Name = "ClientDivProdFooter"
            '
            'label15
            '
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalUnpaid")})
            Me.label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(438.2084!, 0!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.StylePriority.UseTextAlignment = False
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label15.Summary = XrSummary7
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label15.TextFormatString = "{0:n2}"
            Me.label15.WordWrap = False
            '
            'label18
            '
            Me.label18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalPaid")})
            Me.label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(527.2084!, 0!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.StylePriority.UseTextAlignment = False
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label18.Summary = XrSummary8
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label18.TextFormatString = "{0:n2}"
            Me.label18.WordWrap = False
            '
            'label10
            '
            Me.label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(168.9582!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(190.0!, 20.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.Text = "Total for Client/Division/Product"
            '
            'APInvoiceHeader
            '
            Me.APInvoiceHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("APInvoicePmtRefGroup", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.APInvoiceHeader.HeightF = 0!
            Me.APInvoiceHeader.Name = "APInvoiceHeader"
            '
            'APInvoiceFooter
            '
            Me.APInvoiceFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label26, Me.label25, Me.label24, Me.label21, Me.label20, Me.label14})
            Me.APInvoiceFooter.HeightF = 20.0!
            Me.APInvoiceFooter.Name = "APInvoiceFooter"
            '
            'label26
            '
            Me.label26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APPaymentRefPrint")})
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(623.4999!, 0!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(125.4583!, 20.0!)
            Me.label26.StylePriority.UseTextAlignment = False
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.label26.WordWrap = False
            '
            'label25
            '
            Me.label25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalPaid")})
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(527.2084!, 0!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label25.StylePriority.UseTextAlignment = False
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label25.Summary = XrSummary9
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label25.TextFormatString = "{0:n2}"
            Me.label25.WordWrap = False
            '
            'label24
            '
            Me.label24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APTotalUnpaid")})
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(438.2084!, 0!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(89.0!, 20.0!)
            Me.label24.StylePriority.UseTextAlignment = False
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label24.Summary = XrSummary10
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label24.TextFormatString = "{0:n2}"
            Me.label24.WordWrap = False
            '
            'label21
            '
            Me.label21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APInvoiceNumber")})
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(272.9167!, 0!)
            Me.label21.Multiline = True
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
            Me.label21.Text = "label21"
            Me.label21.WordWrap = False
            '
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorName")})
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(165.0!, 20.0!)
            Me.label20.Text = "label20"
            Me.label20.WordWrap = False
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComp")})
            Me.label14.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.Text = "label14"
            Me.label14.WordWrap = False
            '
            'DetailFilter
            '
            Me.DetailFilter.Condition = "[WIPCode] <> 'D' And [WIPCode] <> 'C'"
            Me.DetailFilter.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailFilter.Name = "DetailFilter"
            '
            'JobComp
            '
            Me.JobComp.DisplayName = "JobComp"
            Me.JobComp.Expression = "Concat(PadLeft([JobNumber],6,0),'-',PadLeft([JobComponentNumber],3,0))"
            Me.JobComp.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobComp.Name = "JobComp"
            '
            'OfficeLabel
            '
            Me.OfficeLabel.Expression = "Concat([OfficeCode],' - ',[OfficeDescription])"
            Me.OfficeLabel.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.OfficeLabel.Name = "OfficeLabel"
            '
            'ClientDivProdCode
            '
            Me.ClientDivProdCode.Expression = "Concat([ClientCode] ,'-',[DivisionCode] ,'-',[ProductCode] )"
            Me.ClientDivProdCode.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ClientDivProdCode.Name = "ClientDivProdCode"
            '
            'APTotalPaid
            '
            Me.APTotalPaid.Expression = "IIf([APPaymentFlag]='Paid',[APTotal],0)"
            Me.APTotalPaid.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.APTotalPaid.Name = "APTotalPaid"
            '
            'APTotalUnpaid
            '
            Me.APTotalUnpaid.Expression = "[APTotal]-[APTotalPaid]"
            Me.APTotalUnpaid.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.APTotalUnpaid.Name = "APTotalUnpaid"
            '
            'APPaymentRefPrint
            '
            Me.APPaymentRefPrint.Expression = "IIf([APPartialFlag]='Part',Concat([APPaymentRef],' (Partial)'),[APPaymentRef])"
            Me.APPaymentRefPrint.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.APPaymentRefPrint.Name = "APPaymentRefPrint"
            '
            'APInvoicePmtRefGroup
            '
            Me.APInvoicePmtRefGroup.Expression = "Concat([APInvoiceNumber] ,[APPaymentRefPrint] )"
            Me.APInvoicePmtRefGroup.Name = "APInvoicePmtRefGroup"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.MonthEndProductionWIP)
            '
            'ProductionWIPSummarybyJobwithPayments
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.OfficeHeader, Me.OfficeFooter, Me.JobCompHeader, Me.JobCompFooter, Me.PageHeader, Me.PageFooter, Me.ReportFooter, Me.ClientDivProdHeader, Me.ClientDivProdFooter, Me.APInvoiceHeader, Me.APInvoiceFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.JobComp, Me.OfficeLabel, Me.ClientDivProdCode, Me.APTotalPaid, Me.APTotalUnpaid, Me.APPaymentRefPrint, Me.APInvoicePmtRefGroup})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "403 Production WIP Summary by Job with Payments"
            Me.FilterString = "[APVoucherWIPBalanceFlag] = 1b"
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.DetailFilter})
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
        Friend WithEvents OfficeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OfficeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobCompHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents JobCompFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label40 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents end_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents label52 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivProdHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivProdFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents APInvoiceHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents APInvoiceFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailFilter As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents JobComp As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents OfficeLabel As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientDivProdCode As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents APTotalPaid As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents APTotalUnpaid As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents APPaymentRefPrint As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents APInvoicePmtRefGroup As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






