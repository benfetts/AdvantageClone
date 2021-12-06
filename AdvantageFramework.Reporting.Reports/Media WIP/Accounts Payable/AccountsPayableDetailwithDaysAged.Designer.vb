Namespace MediaWIP.AccountsPayable

    Partial Public Class AccountsPayableDetailwithDaysAged
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailVisible = New DevExpress.XtraReports.UI.FormattingRule()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.label46 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label45 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label44 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label43 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label42 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.aging_date = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.end_period = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.label47 = New DevExpress.XtraReports.UI.XRLabel()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.GLAccountHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLAccountFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label49 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.VendorHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.VendorFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label48 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.InvoiceIDHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.InvoiceIDFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line7 = New DevExpress.XtraReports.UI.XRLine()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GLAccountConcatCodeDesc = New DevExpress.XtraReports.UI.CalculatedField()
            Me.VendorConcatCodeName = New DevExpress.XtraReports.UI.CalculatedField()
            Me.InvoiceID = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DiscountPlusVSTAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GLAPID = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BalanceAmountSumGLAPID = New DevExpress.XtraReports.UI.CalculatedField()
            Me.aging_option = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label24, Me.label22, Me.label17, Me.label18})
            Me.Detail.FormattingRules.Add(Me.DetailVisible)
            Me.Detail.HeightF = 18.00001!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("APType", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("CheckDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("CheckNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.Detail.Visible = False
            '
            'label24
            '
            Me.label24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APType")})
            Me.label24.ForeColor = System.Drawing.Color.SteelBlue
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(411.6667!, 0!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(100.0!, 18.00001!)
            Me.label24.StylePriority.UseForeColor = False
            Me.label24.Text = "label24"
            Me.label24.Visible = False
            '
            'label22
            '
            Me.label22.CanGrow = False
            Me.label22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount")})
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(688.1249!, 0!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(110.8334!, 18.0!)
            Me.label22.StylePriority.UseTextAlignment = False
            Me.label22.Text = "label19"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label22.TextFormatString = "{0:n2}"
            '
            'label17
            '
            Me.label17.CanGrow = False
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckNumber")})
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(523.1249!, 0!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(80.0!, 18.0!)
            Me.label17.Text = "label17"
            '
            'label18
            '
            Me.label18.CanGrow = False
            Me.label18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckDate")})
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(603.1248!, 0!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label18.StylePriority.UseTextAlignment = False
            Me.label18.Text = "label18"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label18.TextFormatString = "{0:d}"
            '
            'DetailVisible
            '
            Me.DetailVisible.Condition = "[APType]='CK'"
            Me.DetailVisible.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.DetailVisible.Name = "DetailVisible"
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line3, Me.label46, Me.label45, Me.label44, Me.label43, Me.label42, Me.label41, Me.label40, Me.label39, Me.label38, Me.label37, Me.label36, Me.line1, Me.label6, Me.label5, Me.label4, Me.label3, Me.label2, Me.label1})
            Me.PageHeader.HeightF = 119.6667!
            Me.PageHeader.Name = "PageHeader"
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 112.375!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(1026.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'label46
            '
            Me.label46.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label46.LocationFloat = New DevExpress.Utils.PointFloat(914.1198!, 76.37501!)
            Me.label46.Multiline = True
            Me.label46.Name = "label46"
            Me.label46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label46.SizeF = New System.Drawing.SizeF(111.8802!, 36.0!)
            Me.label46.StylePriority.UseFont = False
            Me.label46.StylePriority.UseTextAlignment = False
            Me.label46.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Balance"
            Me.label46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label45
            '
            Me.label45.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label45.LocationFloat = New DevExpress.Utils.PointFloat(798.9583!, 76.37501!)
            Me.label45.Multiline = True
            Me.label45.Name = "label45"
            Me.label45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label45.SizeF = New System.Drawing.SizeF(100.62!, 36.0!)
            Me.label45.StylePriority.UseFont = False
            Me.label45.StylePriority.UseTextAlignment = False
            Me.label45.Text = "Discount" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.label45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label44
            '
            Me.label44.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label44.LocationFloat = New DevExpress.Utils.PointFloat(687.5!, 76.37501!)
            Me.label44.Multiline = True
            Me.label44.Name = "label44"
            Me.label44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label44.SizeF = New System.Drawing.SizeF(111.4583!, 36.0!)
            Me.label44.StylePriority.UseFont = False
            Me.label44.StylePriority.UseTextAlignment = False
            Me.label44.Text = "Check" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.label44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label43
            '
            Me.label43.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label43.LocationFloat = New DevExpress.Utils.PointFloat(602.5001!, 76.37501!)
            Me.label43.Multiline = True
            Me.label43.Name = "label43"
            Me.label43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label43.SizeF = New System.Drawing.SizeF(84.99994!, 36.0!)
            Me.label43.StylePriority.UseFont = False
            Me.label43.StylePriority.UseTextAlignment = False
            Me.label43.Text = "Check" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Date"
            Me.label43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label42
            '
            Me.label42.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label42.LocationFloat = New DevExpress.Utils.PointFloat(523.1249!, 76.37501!)
            Me.label42.Multiline = True
            Me.label42.Name = "label42"
            Me.label42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label42.SizeF = New System.Drawing.SizeF(79.37518!, 36.0!)
            Me.label42.StylePriority.UseFont = False
            Me.label42.StylePriority.UseTextAlignment = False
            Me.label42.Text = "Check" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Number"
            Me.label42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label41
            '
            Me.label41.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label41.LocationFloat = New DevExpress.Utils.PointFloat(411.6667!, 76.37501!)
            Me.label41.Multiline = True
            Me.label41.Name = "label41"
            Me.label41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label41.SizeF = New System.Drawing.SizeF(99.99997!, 36.0!)
            Me.label41.StylePriority.UseFont = False
            Me.label41.StylePriority.UseTextAlignment = False
            Me.label41.Text = "Invoice" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.label41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label40
            '
            Me.label40.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label40.LocationFloat = New DevExpress.Utils.PointFloat(361.6667!, 76.37501!)
            Me.label40.Multiline = True
            Me.label40.Name = "label40"
            Me.label40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label40.SizeF = New System.Drawing.SizeF(50.0!, 36.0!)
            Me.label40.StylePriority.UseFont = False
            Me.label40.StylePriority.UseTextAlignment = False
            Me.label40.Text = "Aged" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Days"
            Me.label40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label39
            '
            Me.label39.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label39.LocationFloat = New DevExpress.Utils.PointFloat(311.6667!, 76.37501!)
            Me.label39.Multiline = True
            Me.label39.Name = "label39"
            Me.label39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label39.SizeF = New System.Drawing.SizeF(50.0!, 36.0!)
            Me.label39.StylePriority.UseFont = False
            Me.label39.StylePriority.UseTextAlignment = False
            Me.label39.Text = "Days" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Over"
            Me.label39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label38
            '
            Me.label38.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label38.LocationFloat = New DevExpress.Utils.PointFloat(226.6666!, 76.37501!)
            Me.label38.Multiline = True
            Me.label38.Name = "label38"
            Me.label38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label38.SizeF = New System.Drawing.SizeF(85.00005!, 36.0!)
            Me.label38.StylePriority.UseFont = False
            Me.label38.StylePriority.UseTextAlignment = False
            Me.label38.Text = "Date" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to-Pay"
            Me.label38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label37
            '
            Me.label37.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(141.6667!, 76.37501!)
            Me.label37.Multiline = True
            Me.label37.Name = "label37"
            Me.label37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label37.SizeF = New System.Drawing.SizeF(84.99997!, 36.0!)
            Me.label37.StylePriority.UseFont = False
            Me.label37.StylePriority.UseTextAlignment = False
            Me.label37.Text = "Invoice" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Date"
            Me.label37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label36
            '
            Me.label36.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(0!, 76.37501!)
            Me.label36.Multiline = True
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(137.5!, 36.0!)
            Me.label36.StylePriority.UseFont = False
            Me.label36.Text = "Invoice" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Number"
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(1026.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseBorders = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'label6
            '
            Me.label6.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(870.9999!, 28.00001!)
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
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(870.9999!, 10.00001!)
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
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(951.0!, 28.00001!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(75.0!, 18.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.StylePriority.UseTextAlignment = False
            Me.label4.Text = "label4"
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label4.TextFormatString = "{0:d}"
            '
            'aging_date
            '
            Me.aging_date.Description = "Aging Date"
            Me.aging_date.Name = "aging_date"
            Me.aging_date.Type = GetType(Date)
            Me.aging_date.ValueInfo = "2020-08-26"
            Me.aging_date.Visible = False
            '
            'label3
            '
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.end_period, "Text", "")})
            Me.label3.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(951.0!, 10.00001!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(75.0!, 18.0!)
            Me.label3.StylePriority.UseFont = False
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
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.99999!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(401.0417!, 23.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Sorted by GL Account, Vendor and Invoice Number"
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(401.0417!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Accounts Payable Detail with Days Aged"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label47, Me.pageInfo2, Me.pageInfo1, Me.line2})
            Me.PageFooter.HeightF = 32.00003!
            Me.PageFooter.Name = "PageFooter"
            '
            'label47
            '
            Me.label47.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label47.ForeColor = System.Drawing.Color.SteelBlue
            Me.label47.LocationFloat = New DevExpress.Utils.PointFloat(408.3333!, 14.0!)
            Me.label47.Multiline = True
            Me.label47.Name = "label47"
            Me.label47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label47.SizeF = New System.Drawing.SizeF(100.0!, 18.00003!)
            Me.label47.StylePriority.UseFont = False
            Me.label47.StylePriority.UseForeColor = False
            Me.label47.Text = "Report ID: 500"
            Me.label47.Visible = False
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(826.0!, 14.0!)
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
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.999987!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(1026.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'GLAccountHeader
            '
            Me.GLAccountHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label9, Me.label7})
            Me.GLAccountHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("GLAccountCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GLAccountHeader.HeightF = 18.0!
            Me.GLAccountHeader.Level = 2
            Me.GLAccountHeader.Name = "GLAccountHeader"
            Me.GLAccountHeader.RepeatEveryPage = True
            '
            'label9
            '
            Me.label9.CanGrow = False
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAccountConcatCodeDesc")})
            Me.label9.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(83.33334!, 0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(317.7083!, 18.0!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.Text = "label9"
            '
            'label7
            '
            Me.label7.CanGrow = False
            Me.label7.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(83.33334!, 18.0!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.Text = "GL Account: "
            '
            'GLAccountFooter
            '
            Me.GLAccountFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label49, Me.line4, Me.label31, Me.label32, Me.label33, Me.label34, Me.label35})
            Me.GLAccountFooter.HeightF = 35.0!
            Me.GLAccountFooter.Level = 2
            Me.GLAccountFooter.Name = "GLAccountFooter"
            '
            'label49
            '
            Me.label49.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLAccountCode")})
            Me.label49.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label49.LocationFloat = New DevExpress.Utils.PointFloat(263.5417!, 9.999974!)
            Me.label49.Multiline = True
            Me.label49.Name = "label49"
            Me.label49.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label49.SizeF = New System.Drawing.SizeF(127.0833!, 18.00001!)
            Me.label49.StylePriority.UseFont = False
            Me.label49.Text = "label49"
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.Transparent
            Me.line4.BorderColor = System.Drawing.Color.LightGray
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'label31
            '
            Me.label31.CanGrow = False
            Me.label31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(914.1198!, 9.999974!)
            Me.label31.Multiline = True
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(111.8801!, 18.0!)
            Me.label31.StylePriority.UseFont = False
            Me.label31.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label31.Summary = XrSummary1
            Me.label31.Text = "label21"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label31.TextFormatString = "{0:n2}"
            '
            'label32
            '
            Me.label32.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(125.0!, 9.999974!)
            Me.label32.Multiline = True
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(138.5416!, 18.00001!)
            Me.label32.StylePriority.UseFont = False
            Me.label32.Text = "Total for GL Account:"
            '
            'label33
            '
            Me.label33.CanGrow = False
            Me.label33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.label33.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(401.0417!, 9.999974!)
            Me.label33.Multiline = True
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(110.625!, 18.0!)
            Me.label33.StylePriority.UseFont = False
            Me.label33.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label33.Summary = XrSummary2
            Me.label33.Text = "label16"
            Me.label33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label33.TextFormatString = "{0:n2}"
            '
            'label34
            '
            Me.label34.CanGrow = False
            Me.label34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount")})
            Me.label34.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label34.LocationFloat = New DevExpress.Utils.PointFloat(687.5!, 9.999974!)
            Me.label34.Multiline = True
            Me.label34.Name = "label34"
            Me.label34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label34.SizeF = New System.Drawing.SizeF(111.4583!, 18.0!)
            Me.label34.StylePriority.UseFont = False
            Me.label34.StylePriority.UseTextAlignment = False
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label34.Summary = XrSummary3
            Me.label34.Text = "label19"
            Me.label34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label34.TextFormatString = "{0:n2}"
            '
            'label35
            '
            Me.label35.CanGrow = False
            Me.label35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DiscountPlusVSTAmount")})
            Me.label35.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(798.9583!, 9.999974!)
            Me.label35.Multiline = True
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(100.6199!, 18.0!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.StylePriority.UseTextAlignment = False
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label35.Summary = XrSummary4
            Me.label35.Text = "label20"
            Me.label35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label35.TextFormatString = "{0:n2}"
            '
            'VendorHeader
            '
            Me.VendorHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label10, Me.label8})
            Me.VendorHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.VendorHeader.HeightF = 18.0!
            Me.VendorHeader.Level = 1
            Me.VendorHeader.Name = "VendorHeader"
            Me.VendorHeader.RepeatEveryPage = True
            '
            'label10
            '
            Me.label10.CanGrow = False
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorConcatCodeName")})
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(61.45833!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(339.5833!, 18.0!)
            Me.label10.Text = "label10"
            '
            'label8
            '
            Me.label8.CanGrow = False
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(61.45833!, 18.0!)
            Me.label8.Text = "Vendor: "
            '
            'VendorFooter
            '
            Me.VendorFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label48, Me.label26, Me.label27, Me.label28, Me.label29, Me.label30})
            Me.VendorFooter.HeightF = 35.0!
            Me.VendorFooter.Level = 1
            Me.VendorFooter.Name = "VendorFooter"
            '
            'label48
            '
            Me.label48.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode")})
            Me.label48.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label48.LocationFloat = New DevExpress.Utils.PointFloat(238.5417!, 4.000028!)
            Me.label48.Multiline = True
            Me.label48.Name = "label48"
            Me.label48.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label48.SizeF = New System.Drawing.SizeF(75.0!, 18.0!)
            Me.label48.StylePriority.UseFont = False
            Me.label48.Text = "label48"
            '
            'label26
            '
            Me.label26.CanGrow = False
            Me.label26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(914.1198!, 3.999964!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(111.8801!, 18.0!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.StylePriority.UseTextAlignment = False
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label26.Summary = XrSummary5
            Me.label26.Text = "label21"
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label26.TextFormatString = "{0:n2}"
            '
            'label27
            '
            Me.label27.CanGrow = False
            Me.label27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DiscountPlusVSTAmount")})
            Me.label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(798.9583!, 3.999964!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(100.62!, 18.0!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.StylePriority.UseTextAlignment = False
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label27.Summary = XrSummary6
            Me.label27.Text = "label20"
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label27.TextFormatString = "{0:n2}"
            '
            'label28
            '
            Me.label28.CanGrow = False
            Me.label28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount")})
            Me.label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(687.5!, 3.999964!)
            Me.label28.Multiline = True
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(111.4583!, 18.0!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.StylePriority.UseTextAlignment = False
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label28.Summary = XrSummary7
            Me.label28.Text = "label19"
            Me.label28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label28.TextFormatString = "{0:n2}"
            '
            'label29
            '
            Me.label29.CanGrow = False
            Me.label29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(400.2085!, 3.999964!)
            Me.label29.Multiline = True
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(111.4582!, 18.0!)
            Me.label29.StylePriority.UseFont = False
            Me.label29.StylePriority.UseTextAlignment = False
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label29.Summary = XrSummary8
            Me.label29.Text = "label16"
            Me.label29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label29.TextFormatString = "{0:n2}"
            '
            'label30
            '
            Me.label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(125.0!, 4.000028!)
            Me.label30.Multiline = True
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(113.5416!, 18.00001!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.Text = "Total for Vendor:"
            '
            'InvoiceIDHeader
            '
            Me.InvoiceIDHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label16, Me.label15, Me.label14, Me.label13, Me.label12, Me.label11})
            Me.InvoiceIDHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InvoiceID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.InvoiceIDHeader.HeightF = 18.0!
            Me.InvoiceIDHeader.Name = "InvoiceIDHeader"
            Me.InvoiceIDHeader.RepeatEveryPage = True
            '
            'label16
            '
            Me.label16.CanGrow = False
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.label16.ForeColor = System.Drawing.Color.SteelBlue
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(411.6667!, 0!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label16.StylePriority.UseForeColor = False
            Me.label16.StylePriority.UseTextAlignment = False
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label16.TextFormatString = "{0:n2}"
            Me.label16.Visible = False
            '
            'label15
            '
            Me.label15.CanGrow = False
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "APInvoiceAgingDays")})
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(361.6667!, 0!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(50.0!, 18.0!)
            Me.label15.StylePriority.UseTextAlignment = False
            Me.label15.Text = "label15"
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label14
            '
            Me.label14.CanGrow = False
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DaysToPayAging")})
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(311.6667!, 0!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(50.0!, 18.0!)
            Me.label14.StylePriority.UseTextAlignment = False
            Me.label14.Text = "label14"
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label13
            '
            Me.label13.CanGrow = False
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateToPay")})
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(226.6666!, 0!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label13.StylePriority.UseTextAlignment = False
            Me.label13.Text = "label13"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label13.TextFormatString = "{0:d}"
            '
            'label12
            '
            Me.label12.CanGrow = False
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate")})
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(141.6667!, 0!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(85.0!, 18.0!)
            Me.label12.StylePriority.UseTextAlignment = False
            Me.label12.Text = "label12"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label12.TextFormatString = "{0:d}"
            '
            'label11
            '
            Me.label11.CanGrow = False
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(137.5!, 18.0!)
            Me.label11.Text = "label11"
            '
            'InvoiceIDFooter
            '
            Me.InvoiceIDFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line7, Me.label25, Me.label23, Me.label19, Me.label20, Me.label21})
            Me.InvoiceIDFooter.HeightF = 33.0!
            Me.InvoiceIDFooter.Name = "InvoiceIDFooter"
            '
            'line7
            '
            Me.line7.BackColor = System.Drawing.Color.Transparent
            Me.line7.BorderColor = System.Drawing.Color.LightGray
            Me.line7.ForeColor = System.Drawing.Color.LightGray
            Me.line7.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line7.LocationFloat = New DevExpress.Utils.PointFloat(688.12!, 0!)
            Me.line7.Name = "line7"
            Me.line7.SizeF = New System.Drawing.SizeF(110.8383!, 4.000028!)
            Me.line7.StylePriority.UseBackColor = False
            Me.line7.StylePriority.UseBorderColor = False
            Me.line7.StylePriority.UseForeColor = False
            '
            'label25
            '
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(125.0!, 3.999964!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(178.5417!, 18.00001!)
            Me.label25.StylePriority.UseTextAlignment = False
            Me.label25.Text = "Total for Invoice:"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label23
            '
            Me.label23.CanGrow = False
            Me.label23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(400.2085!, 3.999996!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(111.4582!, 18.0!)
            Me.label23.StylePriority.UseTextAlignment = False
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label23.Summary = XrSummary9
            Me.label23.Text = "label16"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label23.TextFormatString = "{0:n2}"
            '
            'label19
            '
            Me.label19.CanGrow = False
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CheckAmount")})
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(687.5!, 4.000028!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(111.4583!, 18.0!)
            Me.label19.StylePriority.UseTextAlignment = False
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label19.Summary = XrSummary10
            Me.label19.Text = "label19"
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label19.TextFormatString = "{0:n2}"
            '
            'label20
            '
            Me.label20.CanGrow = False
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DiscountPlusVSTAmount")})
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(798.9583!, 3.999964!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(100.6199!, 18.0!)
            Me.label20.StylePriority.UseTextAlignment = False
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label20.Summary = XrSummary11
            Me.label20.Text = "label20"
            Me.label20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label20.TextFormatString = "{0:n2}"
            '
            'label21
            '
            Me.label21.CanGrow = False
            Me.label21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BalanceAmount")})
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(914.1198!, 3.999996!)
            Me.label21.Multiline = True
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(111.8801!, 18.0!)
            Me.label21.StylePriority.UseTextAlignment = False
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label21.Summary = XrSummary12
            Me.label21.Text = "label21"
            Me.label21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label21.TextFormatString = "{0:n2}"
            '
            'GLAccountConcatCodeDesc
            '
            Me.GLAccountConcatCodeDesc.Expression = "Concat([GLAccountCode],' - ',[GLAccountDescription])"
            Me.GLAccountConcatCodeDesc.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.GLAccountConcatCodeDesc.Name = "GLAccountConcatCodeDesc"
            '
            'VendorConcatCodeName
            '
            Me.VendorConcatCodeName.Expression = "Concat([VendorCode],' - ',[VendorName])"
            Me.VendorConcatCodeName.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.VendorConcatCodeName.Name = "VendorConcatCodeName"
            '
            'InvoiceID
            '
            Me.InvoiceID.Expression = "[InvoiceID2]"
            Me.InvoiceID.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.InvoiceID.Name = "InvoiceID"
            '
            'DiscountPlusVSTAmount
            '
            Me.DiscountPlusVSTAmount.Expression = "[DiscountAmount]+[VendorServiceTax]"
            Me.DiscountPlusVSTAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.DiscountPlusVSTAmount.Name = "DiscountPlusVSTAmount"
            '
            'GLAPID
            '
            Me.GLAPID.Expression = "[GLAPID2]"
            Me.GLAPID.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.GLAPID.Name = "GLAPID"
            '
            'BalanceAmountSumGLAPID
            '
            Me.BalanceAmountSumGLAPID.Expression = "[][[GLAPID2]=[^.GLAPID2]].Sum([BalanceAmount])"
            Me.BalanceAmountSumGLAPID.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BalanceAmountSumGLAPID.Name = "BalanceAmountSumGLAPID"
            '
            'aging_option
            '
            Me.aging_option.Description = "Aging Option"
            Me.aging_option.Name = "aging_option"
            Me.aging_option.Type = GetType(Integer)
            Me.aging_option.ValueInfo = "2"
            Me.aging_option.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.MonthEndAccountsPayable)
            '
            'AccountsPayableDetailwithDaysAged
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.GLAccountHeader, Me.GLAccountFooter, Me.VendorHeader, Me.VendorFooter, Me.InvoiceIDHeader, Me.InvoiceIDFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.GLAccountConcatCodeDesc, Me.VendorConcatCodeName, Me.InvoiceID, Me.DiscountPlusVSTAmount, Me.GLAPID, Me.BalanceAmountSumGLAPID})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "500-Accounts Payable Detail with Days Aged"
            'Me.FilterString = "[BalanceAmountSumGLAPID] <> 0.0"  'PH Comment this for speed
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.DetailVisible})
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(35, 39, 50, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.end_period, Me.aging_date, Me.aging_option})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailVisible As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label46 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label45 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label44 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label43 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label42 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label41 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label40 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label38 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents aging_date As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents end_period As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents label47 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents GLAccountHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLAccountFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label49 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label34 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents VendorHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents VendorFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label48 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents InvoiceIDHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents InvoiceIDFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line7 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GLAccountConcatCodeDesc As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents VendorConcatCodeName As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InvoiceID As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents DiscountPlusVSTAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents GLAPID As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BalanceAmountSumGLAPID As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents aging_option As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






