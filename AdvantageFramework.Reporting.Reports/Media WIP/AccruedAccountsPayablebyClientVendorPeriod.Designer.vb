Namespace MediaWIP

    Partial Public Class AccruedAccountsPayablebyClientVendorPeriod
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
            Dim XrSummary18 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.OfficeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OfficeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label45 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label46 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label47 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label48 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLAccountHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLAccountFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line6 = New DevExpress.XtraReports.UI.XRLine()
            Me.label41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label42 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label43 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label44 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivPrdHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivPrdFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line8 = New DevExpress.XtraReports.UI.XRLine()
            Me.line5 = New DevExpress.XtraReports.UI.XRLine()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.VendorHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.VendorFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OrderNumberHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
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
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label53 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label54 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label55 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label56 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label57 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label50 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label51 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label49 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label52 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line7 = New DevExpress.XtraReports.UI.XRLine()
            Me.PeriodHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
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
            'OfficeHeader
            '
            Me.OfficeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label25, Me.label8, Me.line2, Me.label13, Me.label12, Me.label11, Me.label7, Me.label5, Me.label15, Me.label14})
            Me.OfficeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OfficeHeader.HeightF = 70.66663!
            Me.OfficeHeader.KeepTogether = True
            Me.OfficeHeader.Level = 5
            Me.OfficeHeader.Name = "OfficeHeader"
            Me.OfficeHeader.RepeatEveryPage = True
            '
            'label25
            '
            Me.label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(208.9583!, 25.37502!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(62.5!, 33.62501!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.StylePriority.UseTextAlignment = False
            Me.label25.Text = "Billing" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Month/Yr"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label8
            '
            Me.label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(336.88!, 25.37502!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(113.12!, 33.62501!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order Description"
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 64.00003!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'label13
            '
            Me.label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 25.37502!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 33.625!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            Me.label13.Text = "Accrued" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AP Balance"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label12
            '
            Me.label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 25.37502!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 33.625!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            Me.label12.Text = "Accounts" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Payable"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label11
            '
            Me.label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 25.37502!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(100.0!, 33.625!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            Me.label11.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Billing"
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label7
            '
            Me.label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(271.4583!, 25.37502!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(65.00003!, 33.625!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.StylePriority.UseTextAlignment = False
            Me.label7.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order #"
            Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.37502!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(206.0!, 33.625!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vendor"
            '
            'label15
            '
            Me.label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(45.83333!, 18.0!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.Text = "Office: "
            Me.label15.WordWrap = False
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeDescription")})
            Me.label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(45.83333!, 0!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(391.0417!, 18.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.Text = "label14"
            Me.label14.WordWrap = False
            '
            'OfficeFooter
            '
            Me.OfficeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label45, Me.label46, Me.label47, Me.label48})
            Me.OfficeFooter.HeightF = 18.75!
            Me.OfficeFooter.KeepTogether = True
            Me.OfficeFooter.Level = 5
            Me.OfficeFooter.Name = "OfficeFooter"
            Me.OfficeFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            '
            'label45
            '
            Me.label45.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label45.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 0!)
            Me.label45.Multiline = True
            Me.label45.Name = "label45"
            Me.label45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label45.SizeF = New System.Drawing.SizeF(226.4584!, 18.0!)
            Me.label45.StylePriority.UseFont = False
            Me.label45.Text = "Total for Office:"
            '
            'label46
            '
            Me.label46.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label46.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label46.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label46.Multiline = True
            Me.label46.Name = "label46"
            Me.label46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label46.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label46.StylePriority.UseFont = False
            Me.label46.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label46.Summary = XrSummary1
            Me.label46.Text = "label31"
            Me.label46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label46.TextFormatString = "{0:n2}"
            Me.label46.WordWrap = False
            '
            'label47
            '
            Me.label47.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountsPayableAmount")})
            Me.label47.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label47.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0!)
            Me.label47.Multiline = True
            Me.label47.Name = "label47"
            Me.label47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label47.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label47.StylePriority.UseFont = False
            Me.label47.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label47.Summary = XrSummary2
            Me.label47.Text = "label30"
            Me.label47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label47.TextFormatString = "{0:n2}"
            Me.label47.WordWrap = False
            '
            'label48
            '
            Me.label48.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledAmount")})
            Me.label48.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label48.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 0!)
            Me.label48.Multiline = True
            Me.label48.Name = "label48"
            Me.label48.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label48.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label48.StylePriority.UseFont = False
            Me.label48.StylePriority.UseTextAlignment = False
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label48.Summary = XrSummary3
            Me.label48.Text = "label29"
            Me.label48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label48.TextFormatString = "{0:n2}"
            Me.label48.WordWrap = False
            '
            'GLAccountHeader
            '
            Me.GLAccountHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label32, Me.label16})
            Me.GLAccountHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLAccountCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GLAccountHeader.HeightF = 25.0!
            Me.GLAccountHeader.KeepTogether = True
            Me.GLAccountHeader.Level = 4
            Me.GLAccountHeader.Name = "GLAccountHeader"
            Me.GLAccountHeader.RepeatEveryPage = True
            '
            'label32
            '
            Me.label32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAccountCodeDesc")})
            Me.label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(81.99997!, 0!)
            Me.label32.Multiline = True
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(354.88!, 18.0!)
            Me.label32.StylePriority.UseFont = False
            Me.label32.WordWrap = False
            '
            'label16
            '
            Me.label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(82.0!, 18.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.Text = "GL Account:"
            Me.label16.WordWrap = False
            '
            'GLAccountFooter
            '
            Me.GLAccountFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line6, Me.label41, Me.label42, Me.label43, Me.label44})
            Me.GLAccountFooter.HeightF = 34.375!
            Me.GLAccountFooter.KeepTogether = True
            Me.GLAccountFooter.Level = 4
            Me.GLAccountFooter.Name = "GLAccountFooter"
            '
            'line6
            '
            Me.line6.BackColor = System.Drawing.Color.Transparent
            Me.line6.BorderColor = System.Drawing.Color.LightGray
            Me.line6.ForeColor = System.Drawing.Color.LightGray
            Me.line6.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 22.46!)
            Me.line6.Name = "line6"
            Me.line6.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line6.StylePriority.UseBackColor = False
            Me.line6.StylePriority.UseBorderColor = False
            Me.line6.StylePriority.UseForeColor = False
            '
            'label41
            '
            Me.label41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label41.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 0!)
            Me.label41.Multiline = True
            Me.label41.Name = "label41"
            Me.label41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label41.SizeF = New System.Drawing.SizeF(226.4584!, 18.0!)
            Me.label41.StylePriority.UseFont = False
            Me.label41.Text = "Total for GL Account:"
            '
            'label42
            '
            Me.label42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledAmount")})
            Me.label42.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label42.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 0!)
            Me.label42.Multiline = True
            Me.label42.Name = "label42"
            Me.label42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label42.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label42.StylePriority.UseFont = False
            Me.label42.StylePriority.UseTextAlignment = False
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label42.Summary = XrSummary4
            Me.label42.Text = "label29"
            Me.label42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label42.TextFormatString = "{0:n2}"
            Me.label42.WordWrap = False
            '
            'label43
            '
            Me.label43.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountsPayableAmount")})
            Me.label43.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label43.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0!)
            Me.label43.Multiline = True
            Me.label43.Name = "label43"
            Me.label43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label43.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label43.StylePriority.UseFont = False
            Me.label43.StylePriority.UseTextAlignment = False
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label43.Summary = XrSummary5
            Me.label43.Text = "label30"
            Me.label43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label43.TextFormatString = "{0:n2}"
            Me.label43.WordWrap = False
            '
            'label44
            '
            Me.label44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label44.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label44.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label44.Multiline = True
            Me.label44.Name = "label44"
            Me.label44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label44.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label44.StylePriority.UseFont = False
            Me.label44.StylePriority.UseTextAlignment = False
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label44.Summary = XrSummary6
            Me.label44.Text = "label31"
            Me.label44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label44.TextFormatString = "{0:n2}"
            Me.label44.WordWrap = False
            '
            'ClientDivPrdHeader
            '
            Me.ClientDivPrdHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label23, Me.label22, Me.label21, Me.label20, Me.label18, Me.label17})
            Me.ClientDivPrdHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CDPSortCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientDivPrdHeader.HeightF = 43.75!
            Me.ClientDivPrdHeader.KeepTogether = True
            Me.ClientDivPrdHeader.Level = 3
            Me.ClientDivPrdHeader.Name = "ClientDivPrdHeader"
            Me.ClientDivPrdHeader.RepeatEveryPage = True
            '
            'label23
            '
            Me.label23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductDescription")})
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 18.00003!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(300.0!, 18.0!)
            Me.label23.Text = "label23"
            Me.label23.WordWrap = False
            '
            'label22
            '
            Me.label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 18.00003!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.Text = "Product:"
            Me.label22.WordWrap = False
            '
            'label21
            '
            Me.label21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionName")})
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(65.00002!, 18.00003!)
            Me.label21.Multiline = True
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(300.0!, 18.0!)
            Me.label21.Text = "label21"
            Me.label21.WordWrap = False
            '
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientName")})
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(65.00002!, 0!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(300.0!, 18.0!)
            Me.label20.Text = "label20"
            Me.label20.WordWrap = False
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
            Me.label18.Text = "Division:"
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
            Me.label17.Text = "Client:"
            Me.label17.WordWrap = False
            '
            'ClientDivPrdFooter
            '
            Me.ClientDivPrdFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line8, Me.line5, Me.label37, Me.label38, Me.label39, Me.label40})
            Me.ClientDivPrdFooter.HeightF = 43.75!
            Me.ClientDivPrdFooter.KeepTogether = True
            Me.ClientDivPrdFooter.Level = 3
            Me.ClientDivPrdFooter.Name = "ClientDivPrdFooter"
            '
            'line8
            '
            Me.line8.BackColor = System.Drawing.Color.Transparent
            Me.line8.BorderColor = System.Drawing.Color.LightGray
            Me.line8.ForeColor = System.Drawing.Color.LightGray
            Me.line8.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line8.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line8.Name = "line8"
            Me.line8.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line8.StylePriority.UseBackColor = False
            Me.line8.StylePriority.UseBorderColor = False
            Me.line8.StylePriority.UseForeColor = False
            '
            'line5
            '
            Me.line5.BackColor = System.Drawing.Color.Transparent
            Me.line5.BorderColor = System.Drawing.Color.LightGray
            Me.line5.ForeColor = System.Drawing.Color.LightGray
            Me.line5.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.45834!)
            Me.line5.Name = "line5"
            Me.line5.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line5.StylePriority.UseBackColor = False
            Me.line5.StylePriority.UseBorderColor = False
            Me.line5.StylePriority.UseForeColor = False
            '
            'label37
            '
            Me.label37.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(210.4166!, 10.00001!)
            Me.label37.Multiline = True
            Me.label37.Name = "label37"
            Me.label37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label37.SizeF = New System.Drawing.SizeF(226.4584!, 18.0!)
            Me.label37.StylePriority.UseFont = False
            Me.label37.Text = "Total for Client/Division/Product:"
            '
            'label38
            '
            Me.label38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label38.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 10.00001!)
            Me.label38.Multiline = True
            Me.label38.Name = "label38"
            Me.label38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label38.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label38.StylePriority.UseFont = False
            Me.label38.StylePriority.UseTextAlignment = False
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label38.Summary = XrSummary7
            Me.label38.Text = "label31"
            Me.label38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label38.TextFormatString = "{0:n2}"
            Me.label38.WordWrap = False
            '
            'label39
            '
            Me.label39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountsPayableAmount")})
            Me.label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label39.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 10.00001!)
            Me.label39.Multiline = True
            Me.label39.Name = "label39"
            Me.label39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label39.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label39.StylePriority.UseFont = False
            Me.label39.StylePriority.UseTextAlignment = False
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label39.Summary = XrSummary8
            Me.label39.Text = "label30"
            Me.label39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label39.TextFormatString = "{0:n2}"
            Me.label39.WordWrap = False
            '
            'label40
            '
            Me.label40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledAmount")})
            Me.label40.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label40.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 10.00001!)
            Me.label40.Multiline = True
            Me.label40.Name = "label40"
            Me.label40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label40.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label40.StylePriority.UseFont = False
            Me.label40.StylePriority.UseTextAlignment = False
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label40.Summary = XrSummary9
            Me.label40.Text = "label29"
            Me.label40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label40.TextFormatString = "{0:n2}"
            Me.label40.WordWrap = False
            '
            'VendorHeader
            '
            Me.VendorHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.VendorHeader.HeightF = 0!
            Me.VendorHeader.Level = 2
            Me.VendorHeader.Name = "VendorHeader"
            '
            'VendorFooter
            '
            Me.VendorFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label36, Me.label33, Me.label34, Me.label35})
            Me.VendorFooter.HeightF = 33.33!
            Me.VendorFooter.KeepTogether = True
            Me.VendorFooter.Level = 2
            Me.VendorFooter.Name = "VendorFooter"
            '
            'label36
            '
            Me.label36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 6.0!)
            Me.label36.Multiline = True
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(226.4584!, 18.0!)
            Me.label36.StylePriority.UseFont = False
            Me.label36.Text = "Total for Vendor:"
            '
            'label33
            '
            Me.label33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledAmount")})
            Me.label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 6.0!)
            Me.label33.Multiline = True
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label33.StylePriority.UseFont = False
            Me.label33.StylePriority.UseTextAlignment = False
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label33.Summary = XrSummary10
            Me.label33.Text = "label29"
            Me.label33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label33.TextFormatString = "{0:n2}"
            Me.label33.WordWrap = False
            '
            'label34
            '
            Me.label34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountsPayableAmount")})
            Me.label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label34.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 6.0!)
            Me.label34.Multiline = True
            Me.label34.Name = "label34"
            Me.label34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label34.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label34.StylePriority.UseFont = False
            Me.label34.StylePriority.UseTextAlignment = False
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label34.Summary = XrSummary11
            Me.label34.Text = "label30"
            Me.label34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label34.TextFormatString = "{0:n2}"
            Me.label34.WordWrap = False
            '
            'label35
            '
            Me.label35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 6.0!)
            Me.label35.Multiline = True
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.StylePriority.UseTextAlignment = False
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label35.Summary = XrSummary12
            Me.label35.Text = "label31"
            Me.label35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label35.TextFormatString = "{0:n2}"
            Me.label35.WordWrap = False
            '
            'OrderNumberHeader
            '
            Me.OrderNumberHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OrderNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OrderNumberHeader.HeightF = 0!
            Me.OrderNumberHeader.Level = 1
            Me.OrderNumberHeader.Name = "OrderNumberHeader"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label62, Me.label4, Me.label3, Me.label19, Me.line3, Me.label2, Me.label1, Me.line1})
            Me.PageHeader.HeightF = 65.625!
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
            Me.label2.Text = "Accrued Accounts Payable by Client/Vendor"
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
            Me.label1.Text = "Work in Process - Media - Billing, A/P, Balance"
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
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label27, Me.label28, Me.label53, Me.label54, Me.label55, Me.label56, Me.label57, Me.label50, Me.label51, Me.label49, Me.label52, Me.line7})
            Me.ReportFooter.HeightF = 105.4583!
            Me.ReportFooter.KeepTogether = True
            Me.ReportFooter.Name = "ReportFooter"
            '
            'label27
            '
            Me.label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.38001!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(206.0!, 33.625!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vendor"
            '
            'label28
            '
            Me.label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(271.4583!, 25.38!)
            Me.label28.Multiline = True
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(65.00003!, 33.625!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.StylePriority.UseTextAlignment = False
            Me.label28.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order #"
            Me.label28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label53
            '
            Me.label53.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label53.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 25.38!)
            Me.label53.Multiline = True
            Me.label53.Name = "label53"
            Me.label53.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label53.SizeF = New System.Drawing.SizeF(100.0!, 33.625!)
            Me.label53.StylePriority.UseFont = False
            Me.label53.StylePriority.UseTextAlignment = False
            Me.label53.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Billing"
            Me.label53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label54
            '
            Me.label54.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label54.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 25.38!)
            Me.label54.Multiline = True
            Me.label54.Name = "label54"
            Me.label54.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label54.SizeF = New System.Drawing.SizeF(100.0!, 33.625!)
            Me.label54.StylePriority.UseFont = False
            Me.label54.StylePriority.UseTextAlignment = False
            Me.label54.Text = "Accounts" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Payable"
            Me.label54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label55
            '
            Me.label55.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label55.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 25.38!)
            Me.label55.Multiline = True
            Me.label55.Name = "label55"
            Me.label55.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label55.SizeF = New System.Drawing.SizeF(100.0!, 33.625!)
            Me.label55.StylePriority.UseFont = False
            Me.label55.StylePriority.UseTextAlignment = False
            Me.label55.Text = "Accrued" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AP Balance"
            Me.label55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label56
            '
            Me.label56.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label56.LocationFloat = New DevExpress.Utils.PointFloat(336.88!, 25.38!)
            Me.label56.Multiline = True
            Me.label56.Name = "label56"
            Me.label56.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label56.SizeF = New System.Drawing.SizeF(113.12!, 33.62501!)
            Me.label56.StylePriority.UseFont = False
            Me.label56.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order Description"
            '
            'label57
            '
            Me.label57.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label57.LocationFloat = New DevExpress.Utils.PointFloat(208.9583!, 25.38!)
            Me.label57.Multiline = True
            Me.label57.Name = "label57"
            Me.label57.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label57.SizeF = New System.Drawing.SizeF(62.5!, 33.62501!)
            Me.label57.StylePriority.UseFont = False
            Me.label57.StylePriority.UseTextAlignment = False
            Me.label57.Text = "Billing" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Month/Yr"
            Me.label57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label50
            '
            Me.label50.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledAmount")})
            Me.label50.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label50.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 87.45829!)
            Me.label50.Multiline = True
            Me.label50.Name = "label50"
            Me.label50.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label50.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label50.StylePriority.UseFont = False
            Me.label50.StylePriority.UseTextAlignment = False
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label50.Summary = XrSummary13
            Me.label50.Text = "label29"
            Me.label50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label50.TextFormatString = "{0:n2}"
            Me.label50.WordWrap = False
            '
            'label51
            '
            Me.label51.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountsPayableAmount")})
            Me.label51.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label51.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 87.45829!)
            Me.label51.Multiline = True
            Me.label51.Name = "label51"
            Me.label51.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label51.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label51.StylePriority.UseFont = False
            Me.label51.StylePriority.UseTextAlignment = False
            XrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label51.Summary = XrSummary14
            Me.label51.Text = "label30"
            Me.label51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label51.TextFormatString = "{0:n2}"
            Me.label51.WordWrap = False
            '
            'label49
            '
            Me.label49.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label49.LocationFloat = New DevExpress.Utils.PointFloat(210.4167!, 87.45829!)
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
            Me.label52.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 87.45829!)
            Me.label52.Multiline = True
            Me.label52.Name = "label52"
            Me.label52.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label52.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label52.StylePriority.UseFont = False
            Me.label52.StylePriority.UseTextAlignment = False
            XrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label52.Summary = XrSummary15
            Me.label52.Text = "label31"
            Me.label52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label52.TextFormatString = "{0:n2}"
            Me.label52.WordWrap = False
            '
            'line7
            '
            Me.line7.BackColor = System.Drawing.Color.LightGray
            Me.line7.BorderColor = System.Drawing.Color.LightGray
            Me.line7.ForeColor = System.Drawing.Color.LightGray
            Me.line7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 64.0!)
            Me.line7.Name = "line7"
            Me.line7.SizeF = New System.Drawing.SizeF(750.0!, 4.0!)
            Me.line7.StylePriority.UseBackColor = False
            Me.line7.StylePriority.UseBorderColor = False
            Me.line7.StylePriority.UseForeColor = False
            '
            'PeriodHeader
            '
            Me.PeriodHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label10, Me.label6, Me.label30, Me.label29, Me.label26, Me.label31, Me.label9, Me.label24})
            Me.PeriodHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("PostingPeriod", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.PeriodHeader.HeightF = 18.0!
            Me.PeriodHeader.Name = "PeriodHeader"
            '
            'label10
            '
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostingPeriodEndDate")})
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(208.9583!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(62.5!, 18.0!)
            Me.label10.WordWrap = False
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderDescription")})
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(336.88!, 0!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label6.Text = "label6"
            Me.label6.WordWrap = False
            '
            'label30
            '
            Me.label30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountsPayableAmount")})
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0!)
            Me.label30.Multiline = True
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label30.StylePriority.UseTextAlignment = False
            XrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label30.Summary = XrSummary16
            Me.label30.Text = "label30"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label30.TextFormatString = "{0:n2}"
            Me.label30.WordWrap = False
            '
            'label29
            '
            Me.label29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledAmount")})
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 0!)
            Me.label29.Multiline = True
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label29.StylePriority.UseTextAlignment = False
            XrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label29.Summary = XrSummary17
            Me.label29.Text = "label29"
            Me.label29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label29.TextFormatString = "{0:n2}"
            Me.label29.WordWrap = False
            '
            'label26
            '
            Me.label26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderNumber")})
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(271.4583!, 0!)
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
            'label31
            '
            Me.label31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0!)
            Me.label31.Multiline = True
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label31.StylePriority.UseTextAlignment = False
            XrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label31.Summary = XrSummary18
            Me.label31.Text = "label31"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label31.TextFormatString = "{0:n2}"
            Me.label31.WordWrap = False
            '
            'label9
            '
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode")})
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(65.0!, 18.0!)
            Me.label9.Text = "label9"
            Me.label9.WordWrap = False
            '
            'label24
            '
            Me.label24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorName")})
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(65.00002!, 0!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(141.0!, 18.0!)
            Me.label24.Text = "label24"
            Me.label24.WordWrap = False
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
            'AccruedAccountsPayablebyClientVendorPeriod
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.OfficeHeader, Me.OfficeFooter, Me.GLAccountHeader, Me.GLAccountFooter, Me.ClientDivPrdHeader, Me.ClientDivPrdFooter, Me.VendorHeader, Me.VendorFooter, Me.OrderNumberHeader, Me.PageHeader, Me.PageFooter, Me.ReportFooter, Me.PeriodHeader})
            Me.BorderColor = System.Drawing.Color.Transparent
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.GLAccountCodeDesc, Me.OrderOptionDescription})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "Accrued Accounts Payable by ClientVendorPeriod"
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
        Friend WithEvents OfficeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OfficeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label45 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label46 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label47 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label48 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLAccountHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLAccountFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line6 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label41 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label42 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label43 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label44 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivPrdHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivPrdFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line8 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line5 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label38 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label40 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents VendorHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents VendorFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label34 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OrderNumberHeader As DevExpress.XtraReports.UI.GroupHeaderBand
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
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label53 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label54 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label55 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label56 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label57 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label50 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label51 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label49 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label52 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line7 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PeriodHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLAccountCodeDesc As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents OrderOptionDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents order_option As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






