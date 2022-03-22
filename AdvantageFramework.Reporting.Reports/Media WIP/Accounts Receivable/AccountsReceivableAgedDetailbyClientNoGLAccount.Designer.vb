Namespace MediaWIP.AccountsReceivable

    Partial Public Class AccountsReceivableAgedDetailbyClientNoGLAccount
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.ClientHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.ClientFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label56 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label55 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label54 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label53 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label52 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label43 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label42 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.label29 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientCodeCurrentZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ClientCodeAging30DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ClientCodeAging60DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ClientCodeAging90DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ClientCodeAging120PlusDaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ClientCodeOnAccountBalanceZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ClientCodeInvoiceBalanceWithOAZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ReportAging60DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ReportCurrentZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ReportAging30DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ReportAging90DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ReportAging120PlusDaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ReportOnAccountBalanceZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.ReportInvoiceBalanceWithOAZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.DetailCurrentZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.DetailAging30DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.DetailAging60DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.DetailAging90DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.DetailAging120PlusDaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.DetailOnAccountBalanceZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.DetailInvoiceBalanceWithOAZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.AgingOptionDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientCodeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientCodeAging30Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientCodeAging60Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientCodeAging90Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientCodeAging120PlusDays = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientCodeOnAccountBalance = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientCodeInvoiceBalanceWithOA = New DevExpress.XtraReports.UI.CalculatedField()
            Me.InvoiceNumberWithSequence = New DevExpress.XtraReports.UI.CalculatedField()
            Me.PeriodCutoff = New DevExpress.XtraReports.Parameters.Parameter()
            Me.AgingDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.AgingOption = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeDetails = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label17, Me.label56, Me.label55, Me.label54, Me.label53, Me.label52, Me.label10, Me.label9, Me.label5, Me.label4})
            Me.Detail.HeightF = 16.05!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InvoiceDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("InvoiceNumberWithSequence", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
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
            Me.BottomMargin.HeightF = 51.04167!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ClientHeader
            '
            Me.ClientHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label3})
            Me.ClientHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientHeader.HeightF = 16.05!
            Me.ClientHeader.Name = "ClientHeader"
            '
            'ClientFooter
            '
            Me.ClientFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label1, Me.label2, Me.label11, Me.label12, Me.label13, Me.label14, Me.label15, Me.label7, Me.label8})
            Me.ClientFooter.HeightF = 35.84163!
            Me.ClientFooter.Name = "ClientFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label18, Me.label16, Me.label6, Me.label43, Me.label42, Me.label41, Me.label40, Me.label39, Me.label38, Me.line3, Me.label29, Me.label28, Me.label27, Me.label26, Me.label25, Me.label24, Me.label23, Me.label22, Me.line2, Me.label21, Me.label20})
            Me.PageHeader.HeightF = 104.1667!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line1, Me.pageInfo2, Me.pageInfo1})
            Me.PageFooter.HeightF = 26.04998!
            Me.PageFooter.Name = "PageFooter"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label37, Me.label30, Me.label31, Me.label32, Me.label33, Me.label34, Me.label35, Me.label36})
            Me.ReportFooter.HeightF = 32.29167!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'label17
            '
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDueDate")})
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(203.5417!, 0!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(85.0!, 16.05!)
            Me.label17.StylePriority.UseTextAlignment = False
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label17.TextFormatString = "{0:MM/dd/yyyy}"
            '
            'label56
            '
            Me.label56.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OnAccountBalance")})
            Me.label56.FormattingRules.Add(Me.DetailOnAccountBalanceZero)
            Me.label56.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 0!)
            Me.label56.Multiline = True
            Me.label56.Name = "label56"
            Me.label56.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label56.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label56.StylePriority.UseTextAlignment = False
            Me.label56.Text = "label56"
            Me.label56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label56.TextFormatString = "{0:n2}"
            '
            'label55
            '
            Me.label55.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceBalanceWithOA")})
            Me.label55.FormattingRules.Add(Me.DetailInvoiceBalanceWithOAZero)
            Me.label55.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 0!)
            Me.label55.Multiline = True
            Me.label55.Name = "label55"
            Me.label55.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label55.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label55.StylePriority.UseTextAlignment = False
            Me.label55.Text = "label55"
            Me.label55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label55.TextFormatString = "{0:n2}"
            '
            'label54
            '
            Me.label54.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Current")})
            Me.label54.FormattingRules.Add(Me.DetailCurrentZero)
            Me.label54.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 0!)
            Me.label54.Multiline = True
            Me.label54.Name = "label54"
            Me.label54.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label54.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label54.StylePriority.UseTextAlignment = False
            Me.label54.Text = "label54"
            Me.label54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label54.TextFormatString = "{0:n2}"
            '
            'label53
            '
            Me.label53.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging120PlusDays")})
            Me.label53.FormattingRules.Add(Me.DetailAging120PlusDaysZero)
            Me.label53.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 0!)
            Me.label53.Multiline = True
            Me.label53.Name = "label53"
            Me.label53.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label53.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label53.StylePriority.UseTextAlignment = False
            Me.label53.Text = "label53"
            Me.label53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label53.TextFormatString = "{0:n2}"
            '
            'label52
            '
            Me.label52.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging90Days")})
            Me.label52.FormattingRules.Add(Me.DetailAging90DaysZero)
            Me.label52.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 0!)
            Me.label52.Multiline = True
            Me.label52.Name = "label52"
            Me.label52.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label52.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label52.StylePriority.UseTextAlignment = False
            Me.label52.Text = "label52"
            Me.label52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label52.TextFormatString = "{0:n2}"
            '
            'label10
            '
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging60Days")})
            Me.label10.FormattingRules.Add(Me.DetailAging60DaysZero)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label10.StylePriority.UseTextAlignment = False
            Me.label10.Text = "label10"
            Me.label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label10.TextFormatString = "{0:n2}"
            '
            'label9
            '
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging30Days")})
            Me.label9.FormattingRules.Add(Me.DetailAging30DaysZero)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label9.StylePriority.UseTextAlignment = False
            Me.label9.Text = "label9"
            Me.label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label9.TextFormatString = "{0:n2}"
            '
            'label5
            '
            Me.label5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumberWithSequence")})
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 0!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate")})
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(118.5417!, 0!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(85.0!, 16.05!)
            Me.label4.StylePriority.UseTextAlignment = False
            Me.label4.Text = "label4"
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label4.TextFormatString = "{0:MM/dd/yyyy}"
            '
            'label3
            '
            Me.label3.CanGrow = False
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDescription")})
            Me.label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(263.5417!, 16.05!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "label3"
            Me.label3.WordWrap = False
            '
            'label1
            '
            Me.label1.CanGrow = False
            Me.label1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Current")})
            Me.label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label1.FormattingRules.Add(Me.ClientCodeCurrentZero)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 10.00001!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.StylePriority.UseTextAlignment = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label1.Summary = XrSummary1
            Me.label1.Text = "label4"
            Me.label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label1.TextFormatString = "{0:n2}"
            Me.label1.WordWrap = False
            '
            'label2
            '
            Me.label2.CanGrow = False
            Me.label2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging30Days")})
            Me.label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label2.FormattingRules.Add(Me.ClientCodeAging30DaysZero)
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 10.00001!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.StylePriority.UseTextAlignment = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label2.Summary = XrSummary2
            Me.label2.Text = "label5"
            Me.label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label2.TextFormatString = "{0:n2}"
            Me.label2.WordWrap = False
            '
            'label11
            '
            Me.label11.CanGrow = False
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging60Days")})
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.FormattingRules.Add(Me.ClientCodeAging60DaysZero)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 10.00001!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label11.Summary = XrSummary3
            Me.label11.Text = "label6"
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label11.TextFormatString = "{0:n2}"
            Me.label11.WordWrap = False
            '
            'label12
            '
            Me.label12.CanGrow = False
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging90Days")})
            Me.label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label12.FormattingRules.Add(Me.ClientCodeAging90DaysZero)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(599.9999!, 10.00001!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary4
            Me.label12.Text = "label7"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label12.TextFormatString = "{0:n2}"
            Me.label12.WordWrap = False
            '
            'label13
            '
            Me.label13.CanGrow = False
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging120PlusDays")})
            Me.label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label13.FormattingRules.Add(Me.ClientCodeAging120PlusDaysZero)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(699.9999!, 10.00001!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.StylePriority.UseTextAlignment = False
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label13.Summary = XrSummary5
            Me.label13.Text = "label8"
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label13.TextFormatString = "{0:n2}"
            Me.label13.WordWrap = False
            '
            'label14
            '
            Me.label14.CanGrow = False
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OnAccountBalance")})
            Me.label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label14.FormattingRules.Add(Me.ClientCodeOnAccountBalanceZero)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 10.00001!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.StylePriority.UseTextAlignment = False
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label14.Summary = XrSummary6
            Me.label14.Text = "label9"
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label14.TextFormatString = "{0:n2}"
            Me.label14.WordWrap = False
            '
            'label15
            '
            Me.label15.CanGrow = False
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceBalanceWithOA")})
            Me.label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label15.FormattingRules.Add(Me.ClientCodeInvoiceBalanceWithOAZero)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 10.00001!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.StylePriority.UseTextAlignment = False
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label15.Summary = XrSummary7
            Me.label15.Text = "label10"
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label15.TextFormatString = "{0:n2}"
            Me.label15.WordWrap = False
            '
            'label7
            '
            Me.label7.CanGrow = False
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDescription")})
            Me.label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(63.02099!, 9.999974!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(225.5207!, 16.05!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.WordWrap = False
            '
            'label8
            '
            Me.label8.CanGrow = False
            Me.label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 9.999974!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(38.02099!, 16.04817!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.Text = "Total:"
            Me.label8.WordWrap = False
            '
            'label18
            '
            Me.label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(0!, 62.06668!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.Text = "Client"
            '
            'label16
            '
            Me.label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(203.5417!, 78.11667!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(85.0!, 16.05!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.StylePriority.UseTextAlignment = False
            Me.label16.Text = "Due Date"
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label6
            '
            Me.label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 78.11667!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.Text = "Invoice #"
            '
            'label43
            '
            Me.label43.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label43.LocationFloat = New DevExpress.Utils.PointFloat(822.8554!, 42.10002!)
            Me.label43.Multiline = True
            Me.label43.Name = "label43"
            Me.label43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label43.SizeF = New System.Drawing.SizeF(77.14459!, 16.05!)
            Me.label43.StylePriority.UseFont = False
            Me.label43.StylePriority.UseTextAlignment = False
            Me.label43.Text = "Aged By:"
            Me.label43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label42
            '
            Me.label42.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label42.LocationFloat = New DevExpress.Utils.PointFloat(822.8554!, 26.05!)
            Me.label42.Multiline = True
            Me.label42.Name = "label42"
            Me.label42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label42.SizeF = New System.Drawing.SizeF(77.14459!, 16.05!)
            Me.label42.StylePriority.UseFont = False
            Me.label42.StylePriority.UseTextAlignment = False
            Me.label42.Text = "Aging Date:"
            Me.label42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label41
            '
            Me.label41.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label41.LocationFloat = New DevExpress.Utils.PointFloat(822.8554!, 10.00001!)
            Me.label41.Multiline = True
            Me.label41.Name = "label41"
            Me.label41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label41.SizeF = New System.Drawing.SizeF(77.14!, 16.05!)
            Me.label41.StylePriority.UseFont = False
            Me.label41.StylePriority.UseTextAlignment = False
            Me.label41.Text = "Period Cutoff:"
            Me.label41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label40
            '
            Me.label40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingOptionDescription")})
            Me.label40.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label40.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 42.09998!)
            Me.label40.Multiline = True
            Me.label40.Name = "label40"
            Me.label40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label40.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label40.StylePriority.UseFont = False
            Me.label40.StylePriority.UseTextAlignment = False
            Me.label40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label39
            '
            Me.label39.CanGrow = False
            Me.label39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.AgingDate, "Text", "")})
            Me.label39.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label39.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 26.05!)
            Me.label39.Multiline = True
            Me.label39.Name = "label39"
            Me.label39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label39.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label39.StylePriority.UseFont = False
            Me.label39.StylePriority.UseTextAlignment = False
            Me.label39.Text = "label39"
            Me.label39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label39.TextFormatString = "{0:M/d/yyyy}"
            Me.label39.WordWrap = False
            '
            'label38
            '
            Me.label38.CanGrow = False
            Me.label38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.PeriodCutoff, "Text", "")})
            Me.label38.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label38.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 10.00001!)
            Me.label38.Multiline = True
            Me.label38.Name = "label38"
            Me.label38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label38.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label38.StylePriority.UseFont = False
            Me.label38.StylePriority.UseTextAlignment = False
            Me.label38.Text = "label38"
            Me.label38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label38.WordWrap = False
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 97.20834!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'label29
            '
            Me.label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 79.12496!)
            Me.label29.Multiline = True
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label29.StylePriority.UseFont = False
            Me.label29.StylePriority.UseTextAlignment = False
            Me.label29.Text = "Balance"
            Me.label29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label28
            '
            Me.label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 79.12496!)
            Me.label28.Multiline = True
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.StylePriority.UseTextAlignment = False
            Me.label28.Text = "On Account"
            Me.label28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label27
            '
            Me.label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 79.12496!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.StylePriority.UseTextAlignment = False
            Me.label27.Text = "Over 120 Days"
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label26
            '
            Me.label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 79.12496!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.StylePriority.UseTextAlignment = False
            Me.label26.Text = "Over 90 Days"
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label25
            '
            Me.label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 79.12496!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.StylePriority.UseTextAlignment = False
            Me.label25.Text = "Over 60 Days"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label24
            '
            Me.label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 79.12496!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label24.StylePriority.UseFont = False
            Me.label24.StylePriority.UseTextAlignment = False
            Me.label24.Text = "Over 30 Days"
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label23
            '
            Me.label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 79.12496!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseTextAlignment = False
            Me.label23.Text = "Current"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label22
            '
            Me.label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(118.5417!, 78.11667!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(85.0!, 16.05!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.StylePriority.UseTextAlignment = False
            Me.label22.Text = "Invoice Date"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'line2
            '
            Me.line2.BackColor = System.Drawing.Color.LightGray
            Me.line2.BorderColor = System.Drawing.Color.LightGray
            Me.line2.ForeColor = System.Drawing.Color.LightGray
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 2.0!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line2.StylePriority.UseBackColor = False
            Me.line2.StylePriority.UseBorderColor = False
            Me.line2.StylePriority.UseForeColor = False
            '
            'label21
            '
            Me.label21.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(0!, 33.80642!)
            Me.label21.Multiline = True
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(447.6483!, 23.0!)
            Me.label21.StylePriority.UseFont = False
            Me.label21.Text = "Sorted by Client and Invoice Date"
            '
            'label20
            '
            Me.label20.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(447.6482!, 23.80642!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.Text = "Accounts Receivable Aged Detail by Client "
            '
            'line1
            '
            Me.line1.BackColor = System.Drawing.Color.LightGray
            Me.line1.BorderColor = System.Drawing.Color.LightGray
            Me.line1.ForeColor = System.Drawing.Color.LightGray
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 2.0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line1.StylePriority.UseBackColor = False
            Me.line1.StylePriority.UseBorderColor = False
            Me.line1.StylePriority.UseForeColor = False
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 9.999974!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(200.0!, 16.05!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(250.9116!, 16.05!)
            Me.pageInfo1.StylePriority.UseFont = False
            '
            'label37
            '
            Me.label37.CanGrow = False
            Me.label37.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 9.999974!)
            Me.label37.Multiline = True
            Me.label37.Name = "label37"
            Me.label37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label37.SizeF = New System.Drawing.SizeF(81.77099!, 16.04817!)
            Me.label37.StylePriority.UseFont = False
            Me.label37.Text = "Report Total:"
            Me.label37.WordWrap = False
            '
            'label30
            '
            Me.label30.CanGrow = False
            Me.label30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Current")})
            Me.label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label30.FormattingRules.Add(Me.ReportCurrentZero)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 9.999974!)
            Me.label30.Multiline = True
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label30.StylePriority.UseFont = False
            Me.label30.StylePriority.UseTextAlignment = False
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label30.Summary = XrSummary8
            Me.label30.Text = "label4"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label30.TextFormatString = "{0:n2}"
            Me.label30.WordWrap = False
            '
            'label31
            '
            Me.label31.CanGrow = False
            Me.label31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceBalanceWithOA")})
            Me.label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label31.FormattingRules.Add(Me.ReportInvoiceBalanceWithOAZero)
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 9.999974!)
            Me.label31.Multiline = True
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label31.StylePriority.UseFont = False
            Me.label31.StylePriority.UseTextAlignment = False
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label31.Summary = XrSummary9
            Me.label31.Text = "label10"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label31.TextFormatString = "{0:n2}"
            Me.label31.WordWrap = False
            '
            'label32
            '
            Me.label32.CanGrow = False
            Me.label32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OnAccountBalance")})
            Me.label32.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label32.FormattingRules.Add(Me.ReportOnAccountBalanceZero)
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 9.999974!)
            Me.label32.Multiline = True
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label32.StylePriority.UseFont = False
            Me.label32.StylePriority.UseTextAlignment = False
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label32.Summary = XrSummary10
            Me.label32.Text = "label9"
            Me.label32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label32.TextFormatString = "{0:n2}"
            Me.label32.WordWrap = False
            '
            'label33
            '
            Me.label33.CanGrow = False
            Me.label33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging120PlusDays")})
            Me.label33.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label33.FormattingRules.Add(Me.ReportAging120PlusDaysZero)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 9.999974!)
            Me.label33.Multiline = True
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label33.StylePriority.UseFont = False
            Me.label33.StylePriority.UseTextAlignment = False
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label33.Summary = XrSummary11
            Me.label33.Text = "label8"
            Me.label33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label33.TextFormatString = "{0:n2}"
            Me.label33.WordWrap = False
            '
            'label34
            '
            Me.label34.CanGrow = False
            Me.label34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging90Days")})
            Me.label34.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label34.FormattingRules.Add(Me.ReportAging90DaysZero)
            Me.label34.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 9.999974!)
            Me.label34.Multiline = True
            Me.label34.Name = "label34"
            Me.label34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label34.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label34.StylePriority.UseFont = False
            Me.label34.StylePriority.UseTextAlignment = False
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label34.Summary = XrSummary12
            Me.label34.Text = "label7"
            Me.label34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label34.TextFormatString = "{0:n2}"
            Me.label34.WordWrap = False
            '
            'label35
            '
            Me.label35.CanGrow = False
            Me.label35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging60Days")})
            Me.label35.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label35.FormattingRules.Add(Me.ReportAging60DaysZero)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 9.999974!)
            Me.label35.Multiline = True
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label35.StylePriority.UseFont = False
            Me.label35.StylePriority.UseTextAlignment = False
            XrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label35.Summary = XrSummary13
            Me.label35.Text = "label6"
            Me.label35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label35.TextFormatString = "{0:n2}"
            Me.label35.WordWrap = False
            '
            'label36
            '
            Me.label36.CanGrow = False
            Me.label36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging30Days")})
            Me.label36.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label36.FormattingRules.Add(Me.ReportAging30DaysZero)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 9.999974!)
            Me.label36.Multiline = True
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label36.StylePriority.UseFont = False
            Me.label36.StylePriority.UseTextAlignment = False
            XrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label36.Summary = XrSummary14
            Me.label36.Text = "label5"
            Me.label36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label36.TextFormatString = "{0:n2}"
            Me.label36.WordWrap = False
            '
            'ClientCodeCurrentZero
            '
            Me.ClientCodeCurrentZero.Condition = "[ClientCodeCurrent]=0"
            Me.ClientCodeCurrentZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ClientCodeCurrentZero.Name = "ClientCodeCurrentZero"
            '
            'ClientCodeAging30DaysZero
            '
            Me.ClientCodeAging30DaysZero.Condition = "[ClientCodeAging30Days]=0"
            Me.ClientCodeAging30DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ClientCodeAging30DaysZero.Name = "ClientCodeAging30DaysZero"
            '
            'ClientCodeAging60DaysZero
            '
            Me.ClientCodeAging60DaysZero.Condition = "[ClientCodeAging60Days]=0"
            Me.ClientCodeAging60DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ClientCodeAging60DaysZero.Name = "ClientCodeAging60DaysZero"
            '
            'ClientCodeAging90DaysZero
            '
            Me.ClientCodeAging90DaysZero.Condition = "[ClientCodeAging90Days]=0"
            Me.ClientCodeAging90DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ClientCodeAging90DaysZero.Name = "ClientCodeAging90DaysZero"
            '
            'ClientCodeAging120PlusDaysZero
            '
            Me.ClientCodeAging120PlusDaysZero.Condition = "[ClientCodeAging120PlusDays]=0"
            Me.ClientCodeAging120PlusDaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ClientCodeAging120PlusDaysZero.Name = "ClientCodeAging120PlusDaysZero"
            '
            'ClientCodeOnAccountBalanceZero
            '
            Me.ClientCodeOnAccountBalanceZero.Condition = "[ClientCodeOnAccountBalance]=0"
            Me.ClientCodeOnAccountBalanceZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ClientCodeOnAccountBalanceZero.Name = "ClientCodeOnAccountBalanceZero"
            '
            'ClientCodeInvoiceBalanceWithOAZero
            '
            Me.ClientCodeInvoiceBalanceWithOAZero.Condition = "[ClientCodeInvoiceBalanceWithOA]=0"
            Me.ClientCodeInvoiceBalanceWithOAZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ClientCodeInvoiceBalanceWithOAZero.Name = "ClientCodeInvoiceBalanceWithOAZero"
            '
            'ReportAging60DaysZero
            '
            Me.ReportAging60DaysZero.Condition = "Sum([Aging60Days])=0"
            Me.ReportAging60DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportAging60DaysZero.Name = "ReportAging60DaysZero"
            '
            'ReportCurrentZero
            '
            Me.ReportCurrentZero.Condition = "Sum([Current])=0"
            Me.ReportCurrentZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportCurrentZero.Name = "ReportCurrentZero"
            '
            'ReportAging30DaysZero
            '
            Me.ReportAging30DaysZero.Condition = "Sum([Aging30Days])=0"
            Me.ReportAging30DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportAging30DaysZero.Name = "ReportAging30DaysZero"
            '
            'ReportAging90DaysZero
            '
            Me.ReportAging90DaysZero.Condition = "Sum([Aging90Days])=0"
            Me.ReportAging90DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportAging90DaysZero.Name = "ReportAging90DaysZero"
            '
            'ReportAging120PlusDaysZero
            '
            Me.ReportAging120PlusDaysZero.Condition = "Sum([Aging120PlusDays])=0"
            Me.ReportAging120PlusDaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportAging120PlusDaysZero.Name = "ReportAging120PlusDaysZero"
            '
            'ReportOnAccountBalanceZero
            '
            Me.ReportOnAccountBalanceZero.Condition = "Sum([OnAccountBalance])=0"
            Me.ReportOnAccountBalanceZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportOnAccountBalanceZero.Name = "ReportOnAccountBalanceZero"
            '
            'ReportInvoiceBalanceWithOAZero
            '
            Me.ReportInvoiceBalanceWithOAZero.Condition = "Sum([InvoiceBalanceWithOA])=0"
            Me.ReportInvoiceBalanceWithOAZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportInvoiceBalanceWithOAZero.Name = "ReportInvoiceBalanceWithOAZero"
            '
            'DetailCurrentZero
            '
            Me.DetailCurrentZero.Condition = "[Current]=0"
            Me.DetailCurrentZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailCurrentZero.Name = "DetailCurrentZero"
            '
            'DetailAging30DaysZero
            '
            Me.DetailAging30DaysZero.Condition = "[Aging30Days]=0"
            Me.DetailAging30DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailAging30DaysZero.Name = "DetailAging30DaysZero"
            '
            'DetailAging60DaysZero
            '
            Me.DetailAging60DaysZero.Condition = "[Aging60Days]=0"
            Me.DetailAging60DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailAging60DaysZero.Name = "DetailAging60DaysZero"
            '
            'DetailAging90DaysZero
            '
            Me.DetailAging90DaysZero.Condition = "[Aging90Days]=0"
            Me.DetailAging90DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailAging90DaysZero.Name = "DetailAging90DaysZero"
            '
            'DetailAging120PlusDaysZero
            '
            Me.DetailAging120PlusDaysZero.Condition = "[Aging120PlusDays]=0"
            Me.DetailAging120PlusDaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailAging120PlusDaysZero.Name = "DetailAging120PlusDaysZero"
            '
            'DetailOnAccountBalanceZero
            '
            Me.DetailOnAccountBalanceZero.Condition = "[OnAccountBalance]=0"
            Me.DetailOnAccountBalanceZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailOnAccountBalanceZero.Name = "DetailOnAccountBalanceZero"
            '
            'DetailInvoiceBalanceWithOAZero
            '
            Me.DetailInvoiceBalanceWithOAZero.Condition = "[InvoiceBalanceWithOA]=0"
            Me.DetailInvoiceBalanceWithOAZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailInvoiceBalanceWithOAZero.Name = "DetailInvoiceBalanceWithOAZero"
            '
            'AgingOptionDescription
            '
            Me.AgingOptionDescription.Expression = "IIF([Parameters].[AgingOption]=1,'Invoice Date','Invoice Due Date')"
            Me.AgingOptionDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.AgingOptionDescription.Name = "AgingOptionDescription"
            '
            'ClientCodeCurrent
            '
            Me.ClientCodeCurrent.Expression = "[][[ClientCode]=[^.ClientCode]].Sum([Current])"
            Me.ClientCodeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ClientCodeCurrent.Name = "ClientCodeCurrent"
            '
            'ClientCodeAging30Days
            '
            Me.ClientCodeAging30Days.Expression = "[][[ClientCode]=[^.ClientCode]].Sum([Aging30Days])"
            Me.ClientCodeAging30Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ClientCodeAging30Days.Name = "ClientCodeAging30Days"
            '
            'ClientCodeAging60Days
            '
            Me.ClientCodeAging60Days.Expression = "[][[ClientCode]=[^.ClientCode]].Sum([Aging60Days])"
            Me.ClientCodeAging60Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ClientCodeAging60Days.Name = "ClientCodeAging60Days"
            '
            'ClientCodeAging90Days
            '
            Me.ClientCodeAging90Days.Expression = "[][[ClientCode]=[^.ClientCode]].Sum([Aging90Days])"
            Me.ClientCodeAging90Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ClientCodeAging90Days.Name = "ClientCodeAging90Days"
            '
            'ClientCodeAging120PlusDays
            '
            Me.ClientCodeAging120PlusDays.Expression = "[][[ClientCode]=[^.ClientCode]].Sum([Aging120PlusDays])"
            Me.ClientCodeAging120PlusDays.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ClientCodeAging120PlusDays.Name = "ClientCodeAging120PlusDays"
            '
            'ClientCodeOnAccountBalance
            '
            Me.ClientCodeOnAccountBalance.Expression = "[][[ClientCode]=[^.ClientCode]].Sum([OnAccountBalance])"
            Me.ClientCodeOnAccountBalance.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ClientCodeOnAccountBalance.Name = "ClientCodeOnAccountBalance"
            '
            'ClientCodeInvoiceBalanceWithOA
            '
            Me.ClientCodeInvoiceBalanceWithOA.Expression = "[][[ClientCode]=[^.ClientCode]].Sum([InvoiceBalanceWithOA])"
            Me.ClientCodeInvoiceBalanceWithOA.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ClientCodeInvoiceBalanceWithOA.Name = "ClientCodeInvoiceBalanceWithOA"
            '
            'InvoiceNumberWithSequence
            '
            Me.InvoiceNumberWithSequence.Expression = "Concat(PadLeft(Trim([InvoiceNumber]),6,'0'),IIf([InvoiceSequence]>='01',Concat('-" &
    "',[InvoiceSequence]),'  '),[PartialPaymentIndicator])"
            Me.InvoiceNumberWithSequence.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.InvoiceNumberWithSequence.Name = "InvoiceNumberWithSequence"
            '
            'PeriodCutoff
            '
            Me.PeriodCutoff.Description = "Period Cutoff"
            Me.PeriodCutoff.Name = "PeriodCutoff"
            Me.PeriodCutoff.Visible = False
            '
            'AgingDate
            '
            Me.AgingDate.Description = "Aging Date"
            Me.AgingDate.Name = "AgingDate"
            Me.AgingDate.Type = GetType(Date)
            Me.AgingDate.Visible = False
            '
            'AgingOption
            '
            Me.AgingOption.Description = "Aging Option"
            Me.AgingOption.Name = "AgingOption"
            Me.AgingOption.Type = GetType(Integer)
            Me.AgingOption.ValueInfo = "1"
            Me.AgingOption.Visible = False
            '
            'IncludeDetails
            '
            Me.IncludeDetails.Description = "Include Details"
            Me.IncludeDetails.Name = "IncludeDetails"
            Me.IncludeDetails.Type = GetType(Integer)
            Me.IncludeDetails.ValueInfo = "0"
            Me.IncludeDetails.Visible = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.AROpenAgedMonthEnd)
            '
            'AccountsReceivableAgedDetailbyClientNoGLAccount
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ClientHeader, Me.ClientFooter, Me.PageHeader, Me.PageFooter, Me.ReportFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.AgingOptionDescription, Me.ClientCodeCurrent, Me.ClientCodeAging30Days, Me.ClientCodeAging60Days, Me.ClientCodeAging90Days, Me.ClientCodeAging120PlusDays, Me.ClientCodeOnAccountBalance, Me.ClientCodeInvoiceBalanceWithOA, Me.InvoiceNumberWithSequence})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "Accounts Receivable Aged Detail by Client (No GL)"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.ClientCodeCurrentZero, Me.ClientCodeAging30DaysZero, Me.ClientCodeAging60DaysZero, Me.ClientCodeAging90DaysZero, Me.ClientCodeAging120PlusDaysZero, Me.ClientCodeOnAccountBalanceZero, Me.ClientCodeInvoiceBalanceWithOAZero, Me.ReportAging60DaysZero, Me.ReportCurrentZero, Me.ReportAging30DaysZero, Me.ReportAging90DaysZero, Me.ReportAging120PlusDaysZero, Me.ReportOnAccountBalanceZero, Me.ReportInvoiceBalanceWithOAZero, Me.DetailCurrentZero, Me.DetailAging30DaysZero, Me.DetailAging60DaysZero, Me.DetailAging90DaysZero, Me.DetailAging120PlusDaysZero, Me.DetailOnAccountBalanceZero, Me.DetailInvoiceBalanceWithOAZero})
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 51)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.PeriodCutoff, Me.AgingDate, Me.AgingOption, Me.IncludeDetails})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label56 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailOnAccountBalanceZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label55 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailInvoiceBalanceWithOAZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label54 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailCurrentZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label53 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailAging120PlusDaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label52 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailAging90DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailAging60DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailAging30DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents ClientHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientCodeCurrentZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientCodeAging30DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientCodeAging60DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientCodeAging90DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientCodeAging120PlusDaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientCodeOnAccountBalanceZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientCodeInvoiceBalanceWithOAZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label43 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label42 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label41 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label40 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label39 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents AgingDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label38 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PeriodCutoff As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label29 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label37 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label30 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportCurrentZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportInvoiceBalanceWithOAZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportOnAccountBalanceZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label33 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportAging120PlusDaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label34 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportAging90DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label35 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportAging60DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportAging30DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents AgingOptionDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientCodeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientCodeAging30Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientCodeAging60Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientCodeAging90Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientCodeAging120PlusDays As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientCodeOnAccountBalance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientCodeInvoiceBalanceWithOA As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InvoiceNumberWithSequence As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents AgingOption As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






