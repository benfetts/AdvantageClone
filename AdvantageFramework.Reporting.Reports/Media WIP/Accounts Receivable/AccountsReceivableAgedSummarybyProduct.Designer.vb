Namespace MediaWIP.AccountsReceivable

    Partial Public Class AccountsReceivableAgedSummarybyProduct
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.ARGLAccountHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivPrdHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.ARGLAccountFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label51 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountInvoiceBalanceWithOAZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label50 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountOnAccountBalanceZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label49 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountAging120PlusDaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label48 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountAging90DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label47 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountAging60DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label46 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountAging30DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label45 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountCurrentZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivPrdFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientDivPrdCodeOnAccountBalanceZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientDivPrdCodeAging120PlusDaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientDivPrdCodeAging90DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientDivPrdCodeAging60DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientDivPrdCodeAging30DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientDivPrdCodeCurrentZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label43 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label42 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label40 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label39 = New DevExpress.XtraReports.UI.XRLabel()
            Me.AgingDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label38 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PeriodCutoff = New DevExpress.XtraReports.Parameters.Parameter()
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
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.label44 = New DevExpress.XtraReports.UI.XRLabel()
            Me.UserID = New DevExpress.XtraReports.Parameters.Parameter()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.label37 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label30 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportCurrentZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportInvoiceBalanceWithOAZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportOnAccountBalanceZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label33 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportAging120PlusDaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label34 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportAging90DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label35 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportAging60DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportAging30DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.AgingOptionDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountAging30Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountAging60Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountAging90Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountAging120PlusDays = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountOnAccountBalance = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountInvoiceBalanceWithOA = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientDivPrdCode = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientDivPrdCode = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientDivPrdCodeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientDivPrdCodeAging30Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientDivPrdCodeAging60Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientDivPrdCodeAging90Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientDivPrdCodeAging120PlusDays = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientDivPrdCodeOnAccountBalance = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA = New DevExpress.XtraReports.UI.CalculatedField()
            Me.AgingOption = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeDetails = New DevExpress.XtraReports.Parameters.Parameter()
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
            Me.BottomMargin.HeightF = 51.04167!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ARGLAccountHeader
            '
            Me.ARGLAccountHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label2, Me.label1})
            Me.ARGLAccountHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ARGLAccount", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ARGLAccountHeader.HeightF = 16.05!
            Me.ARGLAccountHeader.Level = 1
            Me.ARGLAccountHeader.Name = "ARGLAccountHeader"
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(78.99389!, 16.04817!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "GL Account:"
            '
            'label1
            '
            Me.label1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccount")})
            Me.label1.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(78.9939!, 0!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(178.125!, 16.05!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "label1"
            '
            'ClientDivPrdHeader
            '
            Me.ClientDivPrdHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientDivPrdCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientDivPrdHeader.HeightF = 0!
            Me.ClientDivPrdHeader.Name = "ClientDivPrdHeader"
            '
            'ARGLAccountFooter
            '
            Me.ARGLAccountFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label51, Me.label50, Me.label49, Me.label48, Me.label47, Me.label46, Me.label45, Me.label18, Me.label19})
            Me.ARGLAccountFooter.HeightF = 37.59168!
            Me.ARGLAccountFooter.Level = 1
            Me.ARGLAccountFooter.Name = "ARGLAccountFooter"
            '
            'label51
            '
            Me.label51.CanGrow = False
            Me.label51.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountInvoiceBalanceWithOA")})
            Me.label51.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label51.FormattingRules.Add(Me.ARGLAccountInvoiceBalanceWithOAZero)
            Me.label51.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 10.00182!)
            Me.label51.Multiline = True
            Me.label51.Name = "label51"
            Me.label51.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label51.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label51.StylePriority.UseFont = False
            Me.label51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label51.TextFormatString = "{0:n2}"
            Me.label51.WordWrap = False
            '
            'ARGLAccountInvoiceBalanceWithOAZero
            '
            Me.ARGLAccountInvoiceBalanceWithOAZero.Condition = "ARGLAccountInvoiceBalanceWithOA=0"
            Me.ARGLAccountInvoiceBalanceWithOAZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountInvoiceBalanceWithOAZero.Name = "ARGLAccountInvoiceBalanceWithOAZero"
            '
            'label50
            '
            Me.label50.CanGrow = False
            Me.label50.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountOnAccountBalance")})
            Me.label50.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label50.FormattingRules.Add(Me.ARGLAccountOnAccountBalanceZero)
            Me.label50.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 10.00182!)
            Me.label50.Multiline = True
            Me.label50.Name = "label50"
            Me.label50.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label50.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label50.StylePriority.UseFont = False
            Me.label50.Text = "label50"
            Me.label50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label50.TextFormatString = "{0:n2}"
            Me.label50.WordWrap = False
            '
            'ARGLAccountOnAccountBalanceZero
            '
            Me.ARGLAccountOnAccountBalanceZero.Condition = "[ARGLAccountOnAccountBalance]=0"
            Me.ARGLAccountOnAccountBalanceZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountOnAccountBalanceZero.Name = "ARGLAccountOnAccountBalanceZero"
            '
            'label49
            '
            Me.label49.CanGrow = False
            Me.label49.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountAging120PlusDays")})
            Me.label49.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label49.FormattingRules.Add(Me.ARGLAccountAging120PlusDaysZero)
            Me.label49.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 10.00182!)
            Me.label49.Multiline = True
            Me.label49.Name = "label49"
            Me.label49.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label49.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label49.StylePriority.UseFont = False
            Me.label49.Text = "label49"
            Me.label49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label49.TextFormatString = "{0:n2}"
            Me.label49.WordWrap = False
            '
            'ARGLAccountAging120PlusDaysZero
            '
            Me.ARGLAccountAging120PlusDaysZero.Condition = "[ARGLAccountAging120PlusDays]=0"
            Me.ARGLAccountAging120PlusDaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountAging120PlusDaysZero.Name = "ARGLAccountAging120PlusDaysZero"
            '
            'label48
            '
            Me.label48.CanGrow = False
            Me.label48.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountAging90Days")})
            Me.label48.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label48.FormattingRules.Add(Me.ARGLAccountAging90DaysZero)
            Me.label48.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 10.00182!)
            Me.label48.Multiline = True
            Me.label48.Name = "label48"
            Me.label48.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label48.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label48.StylePriority.UseFont = False
            Me.label48.Text = "label48"
            Me.label48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label48.TextFormatString = "{0:n2}"
            Me.label48.WordWrap = False
            '
            'ARGLAccountAging90DaysZero
            '
            Me.ARGLAccountAging90DaysZero.Condition = "[ARGLAccountAging90Days]=0"
            Me.ARGLAccountAging90DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountAging90DaysZero.Name = "ARGLAccountAging90DaysZero"
            '
            'label47
            '
            Me.label47.CanGrow = False
            Me.label47.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountAging60Days")})
            Me.label47.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label47.FormattingRules.Add(Me.ARGLAccountAging60DaysZero)
            Me.label47.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 10.00182!)
            Me.label47.Multiline = True
            Me.label47.Name = "label47"
            Me.label47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label47.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label47.StylePriority.UseFont = False
            Me.label47.Text = "label47"
            Me.label47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label47.TextFormatString = "{0:n2}"
            Me.label47.WordWrap = False
            '
            'ARGLAccountAging60DaysZero
            '
            Me.ARGLAccountAging60DaysZero.Condition = "[ARGLAccountAging60Days]=0"
            Me.ARGLAccountAging60DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountAging60DaysZero.Name = "ARGLAccountAging60DaysZero"
            '
            'label46
            '
            Me.label46.CanGrow = False
            Me.label46.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountAging30Days")})
            Me.label46.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label46.FormattingRules.Add(Me.ARGLAccountAging30DaysZero)
            Me.label46.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 10.00182!)
            Me.label46.Multiline = True
            Me.label46.Name = "label46"
            Me.label46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label46.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label46.StylePriority.UseFont = False
            Me.label46.Text = "label46"
            Me.label46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label46.TextFormatString = "{0:n2}"
            Me.label46.WordWrap = False
            '
            'ARGLAccountAging30DaysZero
            '
            Me.ARGLAccountAging30DaysZero.Condition = "[ARGLAccountAging30Days] = 0"
            Me.ARGLAccountAging30DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountAging30DaysZero.Name = "ARGLAccountAging30DaysZero"
            '
            'label45
            '
            Me.label45.CanGrow = False
            Me.label45.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountCurrent")})
            Me.label45.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label45.FormattingRules.Add(Me.ARGLAccountCurrentZero)
            Me.label45.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 10.00182!)
            Me.label45.Multiline = True
            Me.label45.Name = "label45"
            Me.label45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label45.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label45.StylePriority.UseFont = False
            Me.label45.Text = "label45"
            Me.label45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label45.TextFormatString = "{0:n2}"
            Me.label45.WordWrap = False
            '
            'ARGLAccountCurrentZero
            '
            Me.ARGLAccountCurrentZero.Condition = "[ARGLAccountCurrent]=0"
            Me.ARGLAccountCurrentZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountCurrentZero.Name = "ARGLAccountCurrentZero"
            '
            'label18
            '
            Me.label18.CanGrow = False
            Me.label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 10.00182!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(38.02099!, 16.04817!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.Text = "Total:"
            Me.label18.WordWrap = False
            '
            'label19
            '
            Me.label19.CanGrow = False
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccount")})
            Me.label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(63.02099!, 10.00001!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(178.125!, 16.05!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.Text = "label1"
            Me.label19.WordWrap = False
            '
            'ClientDivPrdFooter
            '
            Me.ClientDivPrdFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label17, Me.label16, Me.label15, Me.label14, Me.label13, Me.label12, Me.label11, Me.label3})
            Me.ClientDivPrdFooter.HeightF = 16.05!
            Me.ClientDivPrdFooter.Name = "ClientDivPrdFooter"
            '
            'label17
            '
            Me.label17.CanGrow = False
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA")})
            Me.label17.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 0!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label17.TextFormatString = "{0:n2}"
            Me.label17.WordWrap = False
            '
            'ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero
            '
            Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero.Condition = "[ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA]=0"
            Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero.Name = "ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero"
            '
            'label16
            '
            Me.label16.CanGrow = False
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientDivPrdCodeOnAccountBalance")})
            Me.label16.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeOnAccountBalanceZero)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 0!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label16.TextFormatString = "{0:n2}"
            Me.label16.WordWrap = False
            '
            'ARGLAccountClientDivPrdCodeOnAccountBalanceZero
            '
            Me.ARGLAccountClientDivPrdCodeOnAccountBalanceZero.Condition = "[ARGLAccountClientDivPrdCodeOnAccountBalance]=0"
            Me.ARGLAccountClientDivPrdCodeOnAccountBalanceZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientDivPrdCodeOnAccountBalanceZero.Name = "ARGLAccountClientDivPrdCodeOnAccountBalanceZero"
            '
            'label15
            '
            Me.label15.CanGrow = False
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientDivPrdCodeAging120PlusDays")})
            Me.label15.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeAging120PlusDaysZero)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 0!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label15.TextFormatString = "{0:n2}"
            Me.label15.WordWrap = False
            '
            'ARGLAccountClientDivPrdCodeAging120PlusDaysZero
            '
            Me.ARGLAccountClientDivPrdCodeAging120PlusDaysZero.Condition = "[ARGLAccountClientDivPrdCodeAging120PlusDays]=0"
            Me.ARGLAccountClientDivPrdCodeAging120PlusDaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientDivPrdCodeAging120PlusDaysZero.Name = "ARGLAccountClientDivPrdCodeAging120PlusDaysZero"
            '
            'label14
            '
            Me.label14.CanGrow = False
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientDivPrdCodeAging90Days")})
            Me.label14.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeAging90DaysZero)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 0!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label14.TextFormatString = "{0:n2}"
            Me.label14.WordWrap = False
            '
            'ARGLAccountClientDivPrdCodeAging90DaysZero
            '
            Me.ARGLAccountClientDivPrdCodeAging90DaysZero.Condition = "[ARGLAccountClientDivPrdCodeAging90Days]=0"
            Me.ARGLAccountClientDivPrdCodeAging90DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientDivPrdCodeAging90DaysZero.Name = "ARGLAccountClientDivPrdCodeAging90DaysZero"
            '
            'label13
            '
            Me.label13.CanGrow = False
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientDivPrdCodeAging60Days")})
            Me.label13.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeAging60DaysZero)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label13.TextFormatString = "{0:n2}"
            Me.label13.WordWrap = False
            '
            'ARGLAccountClientDivPrdCodeAging60DaysZero
            '
            Me.ARGLAccountClientDivPrdCodeAging60DaysZero.Condition = "[ARGLAccountClientDivPrdCodeAging60Days]=0"
            Me.ARGLAccountClientDivPrdCodeAging60DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientDivPrdCodeAging60DaysZero.Name = "ARGLAccountClientDivPrdCodeAging60DaysZero"
            '
            'label12
            '
            Me.label12.CanGrow = False
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientDivPrdCodeAging30Days")})
            Me.label12.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeAging30DaysZero)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label12.TextFormatString = "{0:n2}"
            Me.label12.WordWrap = False
            '
            'ARGLAccountClientDivPrdCodeAging30DaysZero
            '
            Me.ARGLAccountClientDivPrdCodeAging30DaysZero.Condition = "[ARGLAccountClientDivPrdCodeAging30Days]=0"
            Me.ARGLAccountClientDivPrdCodeAging30DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientDivPrdCodeAging30DaysZero.Name = "ARGLAccountClientDivPrdCodeAging30DaysZero"
            '
            'label11
            '
            Me.label11.CanGrow = False
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientDivPrdCodeCurrent")})
            Me.label11.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeCurrentZero)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 0!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label11.TextFormatString = "{0:n2}"
            Me.label11.WordWrap = False
            '
            'ARGLAccountClientDivPrdCodeCurrentZero
            '
            Me.ARGLAccountClientDivPrdCodeCurrentZero.Condition = "[ARGLAccountClientDivPrdCodeCurrent]=0"
            Me.ARGLAccountClientDivPrdCodeCurrentZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientDivPrdCodeCurrentZero.Name = "ARGLAccountClientDivPrdCodeCurrentZero"
            '
            'label3
            '
            Me.label3.CanGrow = False
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDivPrdCode")})
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(263.5417!, 16.05!)
            Me.label3.WordWrap = False
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label43, Me.label42, Me.label41, Me.label40, Me.label39, Me.label38, Me.line3, Me.label29, Me.label28, Me.label27, Me.label26, Me.label25, Me.label24, Me.label23, Me.label22, Me.line2, Me.label21, Me.label20})
            Me.PageHeader.HeightF = 98.95834!
            Me.PageHeader.Name = "PageHeader"
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
            'AgingDate
            '
            Me.AgingDate.Description = "Aging Date"
            Me.AgingDate.Name = "AgingDate"
            Me.AgingDate.Type = GetType(Date)
            Me.AgingDate.Visible = False
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
            'PeriodCutoff
            '
            Me.PeriodCutoff.Description = "Period Cutoff"
            Me.PeriodCutoff.Name = "PeriodCutoff"
            Me.PeriodCutoff.Visible = False
            '
            'line3
            '
            Me.line3.BackColor = System.Drawing.Color.LightGray
            Me.line3.BorderColor = System.Drawing.Color.LightGray
            Me.line3.ForeColor = System.Drawing.Color.LightGray
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 92.0!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'label29
            '
            Me.label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 73.91663!)
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
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 73.91663!)
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
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 73.91663!)
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
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 73.91663!)
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
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 73.91663!)
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
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 73.91663!)
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
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 73.91663!)
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
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 73.91663!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(100.0!, 16.05!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.Text = "Client"
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
            Me.label21.Text = "Sorted by GL Account and Client/Division/Product"
            '
            'label20
            '
            Me.label20.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(517.4399!, 23.80642!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.Text = "Accounts Receivable Aged Summary by Product"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label44, Me.line1, Me.pageInfo2, Me.pageInfo1})
            Me.PageFooter.HeightF = 26.04998!
            Me.PageFooter.Name = "PageFooter"
            '
            'label44
            '
            Me.label44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.UserID, "Text", "")})
            Me.label44.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label44.LocationFloat = New DevExpress.Utils.PointFloat(300.0!, 9.999974!)
            Me.label44.Multiline = True
            Me.label44.Name = "label44"
            Me.label44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label44.SizeF = New System.Drawing.SizeF(400.0!, 16.05!)
            Me.label44.StylePriority.UseFont = False
            Me.label44.StylePriority.UseTextAlignment = False
            Me.label44.Text = "label44"
            Me.label44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'UserID
            '
            Me.UserID.Description = "User ID"
            Me.UserID.Name = "UserID"
            Me.UserID.Visible = False
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
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label37, Me.label30, Me.label31, Me.label32, Me.label33, Me.label34, Me.label35, Me.label36, Me.line4})
            Me.ReportFooter.HeightF = 32.29167!
            Me.ReportFooter.Name = "ReportFooter"
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
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label30.Summary = XrSummary1
            Me.label30.Text = "label4"
            Me.label30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label30.TextFormatString = "{0:n2}"
            Me.label30.WordWrap = False
            '
            'ReportCurrentZero
            '
            Me.ReportCurrentZero.Condition = "Sum([Current])=0"
            Me.ReportCurrentZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportCurrentZero.Name = "ReportCurrentZero"
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
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label31.Summary = XrSummary2
            Me.label31.Text = "label10"
            Me.label31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label31.TextFormatString = "{0:n2}"
            Me.label31.WordWrap = False
            '
            'ReportInvoiceBalanceWithOAZero
            '
            Me.ReportInvoiceBalanceWithOAZero.Condition = "Sum([InvoiceBalanceWithOA])=0"
            Me.ReportInvoiceBalanceWithOAZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportInvoiceBalanceWithOAZero.Name = "ReportInvoiceBalanceWithOAZero"
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
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label32.Summary = XrSummary3
            Me.label32.Text = "label9"
            Me.label32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label32.TextFormatString = "{0:n2}"
            Me.label32.WordWrap = False
            '
            'ReportOnAccountBalanceZero
            '
            Me.ReportOnAccountBalanceZero.Condition = "Sum([OnAccountBalance])=0"
            Me.ReportOnAccountBalanceZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportOnAccountBalanceZero.Name = "ReportOnAccountBalanceZero"
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
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label33.Summary = XrSummary4
            Me.label33.Text = "label8"
            Me.label33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label33.TextFormatString = "{0:n2}"
            Me.label33.WordWrap = False
            '
            'ReportAging120PlusDaysZero
            '
            Me.ReportAging120PlusDaysZero.Condition = "Sum([Aging120PlusDays])=0"
            Me.ReportAging120PlusDaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportAging120PlusDaysZero.Name = "ReportAging120PlusDaysZero"
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
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label34.Summary = XrSummary5
            Me.label34.Text = "label7"
            Me.label34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label34.TextFormatString = "{0:n2}"
            Me.label34.WordWrap = False
            '
            'ReportAging90DaysZero
            '
            Me.ReportAging90DaysZero.Condition = "Sum([Aging90Days])=0"
            Me.ReportAging90DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportAging90DaysZero.Name = "ReportAging90DaysZero"
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
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label35.Summary = XrSummary6
            Me.label35.Text = "label6"
            Me.label35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label35.TextFormatString = "{0:n2}"
            Me.label35.WordWrap = False
            '
            'ReportAging60DaysZero
            '
            Me.ReportAging60DaysZero.Condition = "Sum([Aging60Days])=0"
            Me.ReportAging60DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportAging60DaysZero.Name = "ReportAging60DaysZero"
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
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label36.Summary = XrSummary7
            Me.label36.Text = "label5"
            Me.label36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label36.TextFormatString = "{0:n2}"
            Me.label36.WordWrap = False
            '
            'ReportAging30DaysZero
            '
            Me.ReportAging30DaysZero.Condition = "Sum([Aging30Days])=0"
            Me.ReportAging30DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ReportAging30DaysZero.Name = "ReportAging30DaysZero"
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.LightGray
            Me.line4.BorderColor = System.Drawing.Color.LightGray
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 2.0!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'AgingOptionDescription
            '
            Me.AgingOptionDescription.Expression = "IIF([Parameters].[AgingOption]=1,'Invoice Date','Invoice Due Date')"
            Me.AgingOptionDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.AgingOptionDescription.Name = "AgingOptionDescription"
            '
            'ARGLAccountCurrent
            '
            Me.ARGLAccountCurrent.Expression = "[][[ARGLAccount]=[^.ARGLAccount]].Sum([Current])"
            Me.ARGLAccountCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountCurrent.Name = "ARGLAccountCurrent"
            '
            'ARGLAccountAging30Days
            '
            Me.ARGLAccountAging30Days.Expression = "[][[ARGLAccount]=[^.ARGLAccount]].Sum([Aging30Days])"
            Me.ARGLAccountAging30Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountAging30Days.Name = "ARGLAccountAging30Days"
            '
            'ARGLAccountAging60Days
            '
            Me.ARGLAccountAging60Days.Expression = "[][[ARGLAccount]=[^.ARGLAccount]].Sum([Aging60Days])"
            Me.ARGLAccountAging60Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountAging60Days.Name = "ARGLAccountAging60Days"
            '
            'ARGLAccountAging90Days
            '
            Me.ARGLAccountAging90Days.Expression = "[][[ARGLAccount]=[^.ARGLAccount]].Sum([Aging90Days])"
            Me.ARGLAccountAging90Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountAging90Days.Name = "ARGLAccountAging90Days"
            '
            'ARGLAccountAging120PlusDays
            '
            Me.ARGLAccountAging120PlusDays.Expression = "[][[ARGLAccount]=[^.ARGLAccount]].Sum([Aging120PlusDays])"
            Me.ARGLAccountAging120PlusDays.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountAging120PlusDays.Name = "ARGLAccountAging120PlusDays"
            '
            'ARGLAccountOnAccountBalance
            '
            Me.ARGLAccountOnAccountBalance.Expression = "[][[ARGLAccount]=[^.ARGLAccount]].Sum([OnAccountBalance])"
            Me.ARGLAccountOnAccountBalance.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountOnAccountBalance.Name = "ARGLAccountOnAccountBalance"
            '
            'ARGLAccountInvoiceBalanceWithOA
            '
            Me.ARGLAccountInvoiceBalanceWithOA.Expression = "[][[ARGLAccount]=[^.ARGLAccount]].Sum([InvoiceBalanceWithOA])"
            Me.ARGLAccountInvoiceBalanceWithOA.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountInvoiceBalanceWithOA.Name = "ARGLAccountInvoiceBalanceWithOA"
            '
            'ClientDivPrdCode
            '
            Me.ClientDivPrdCode.Expression = "Concat([ClientCode],' / ',IIf(IsNullOrEmpty([DivisionCode]),'ZZ',[DivisionCode])," &
    "' / ',IIf(IsNullOrEmpty([ProductCode]),'ZZ',[ProductCode]))"
            Me.ClientDivPrdCode.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ClientDivPrdCode.Name = "ClientDivPrdCode"
            '
            'ARGLAccountClientDivPrdCode
            '
            Me.ARGLAccountClientDivPrdCode.Expression = "Concat([ARGLAccount],[ClientDivPrdCode])"
            Me.ARGLAccountClientDivPrdCode.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ARGLAccountClientDivPrdCode.Name = "ARGLAccountClientDivPrdCode"
            '
            'ARGLAccountClientDivPrdCodeCurrent
            '
            Me.ARGLAccountClientDivPrdCodeCurrent.Expression = "[][[ARGLAccountClientDivPrdCode]=[^.ARGLAccountClientDivPrdCode]].Sum([Current])"
            Me.ARGLAccountClientDivPrdCodeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientDivPrdCodeCurrent.Name = "ARGLAccountClientDivPrdCodeCurrent"
            '
            'ARGLAccountClientDivPrdCodeAging30Days
            '
            Me.ARGLAccountClientDivPrdCodeAging30Days.Expression = "[][[ARGLAccountClientDivPrdCode]=[^.ARGLAccountClientDivPrdCode]].Sum([Aging30Day" &
    "s])"
            Me.ARGLAccountClientDivPrdCodeAging30Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientDivPrdCodeAging30Days.Name = "ARGLAccountClientDivPrdCodeAging30Days"
            '
            'ARGLAccountClientDivPrdCodeAging60Days
            '
            Me.ARGLAccountClientDivPrdCodeAging60Days.Expression = "[][[ARGLAccountClientDivPrdCode]=[^.ARGLAccountClientDivPrdCode]].Sum([Aging60Day" &
    "s])"
            Me.ARGLAccountClientDivPrdCodeAging60Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientDivPrdCodeAging60Days.Name = "ARGLAccountClientDivPrdCodeAging60Days"
            '
            'ARGLAccountClientDivPrdCodeAging90Days
            '
            Me.ARGLAccountClientDivPrdCodeAging90Days.Expression = "[][[ARGLAccountClientDivPrdCode]=[^.ARGLAccountClientDivPrdCode]].Sum([Aging90Day" &
    "s])"
            Me.ARGLAccountClientDivPrdCodeAging90Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientDivPrdCodeAging90Days.Name = "ARGLAccountClientDivPrdCodeAging90Days"
            '
            'ARGLAccountClientDivPrdCodeAging120PlusDays
            '
            Me.ARGLAccountClientDivPrdCodeAging120PlusDays.Expression = "[][[ARGLAccountClientDivPrdCode]=[^.ARGLAccountClientDivPrdCode]].Sum([Aging120Pl" &
    "usDays])"
            Me.ARGLAccountClientDivPrdCodeAging120PlusDays.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientDivPrdCodeAging120PlusDays.Name = "ARGLAccountClientDivPrdCodeAging120PlusDays"
            '
            'ARGLAccountClientDivPrdCodeOnAccountBalance
            '
            Me.ARGLAccountClientDivPrdCodeOnAccountBalance.Expression = "[][[ARGLAccountClientDivPrdCode]=[^.ARGLAccountClientDivPrdCode]].Sum([OnAccountB" &
    "alance])"
            Me.ARGLAccountClientDivPrdCodeOnAccountBalance.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientDivPrdCodeOnAccountBalance.Name = "ARGLAccountClientDivPrdCodeOnAccountBalance"
            '
            'ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA
            '
            Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA.Expression = "[][[ARGLAccountClientDivPrdCode]=[^.ARGLAccountClientDivPrdCode]].Sum([InvoiceBal" &
    "anceWithOA])"
            Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA.Name = "ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA"
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
            'AccountsReceivableAgedSummarybyProduct
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ARGLAccountHeader, Me.ClientDivPrdHeader, Me.ARGLAccountFooter, Me.ClientDivPrdFooter, Me.PageHeader, Me.PageFooter, Me.ReportFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.AgingOptionDescription, Me.ARGLAccountCurrent, Me.ARGLAccountAging30Days, Me.ARGLAccountAging60Days, Me.ARGLAccountAging90Days, Me.ARGLAccountAging120PlusDays, Me.ARGLAccountOnAccountBalance, Me.ARGLAccountInvoiceBalanceWithOA, Me.ClientDivPrdCode, Me.ARGLAccountClientDivPrdCode, Me.ARGLAccountClientDivPrdCodeCurrent, Me.ARGLAccountClientDivPrdCodeAging30Days, Me.ARGLAccountClientDivPrdCodeAging60Days, Me.ARGLAccountClientDivPrdCodeAging90Days, Me.ARGLAccountClientDivPrdCodeAging120PlusDays, Me.ARGLAccountClientDivPrdCodeOnAccountBalance, Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "Accounts Receivable Aged Summary by Product"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.ARGLAccountCurrentZero, Me.ARGLAccountAging60DaysZero, Me.ARGLAccountAging30DaysZero, Me.ARGLAccountAging90DaysZero, Me.ARGLAccountAging120PlusDaysZero, Me.ARGLAccountOnAccountBalanceZero, Me.ARGLAccountInvoiceBalanceWithOAZero, Me.ARGLAccountClientDivPrdCodeCurrentZero, Me.ARGLAccountClientDivPrdCodeAging30DaysZero, Me.ARGLAccountClientDivPrdCodeAging60DaysZero, Me.ARGLAccountClientDivPrdCodeAging90DaysZero, Me.ARGLAccountClientDivPrdCodeAging120PlusDaysZero, Me.ARGLAccountClientDivPrdCodeOnAccountBalanceZero, Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero, Me.ReportAging60DaysZero, Me.ReportCurrentZero, Me.ReportAging30DaysZero, Me.ReportAging90DaysZero, Me.ReportAging120PlusDaysZero, Me.ReportOnAccountBalanceZero, Me.ReportInvoiceBalanceWithOAZero})
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 51)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.UserID, Me.PeriodCutoff, Me.AgingDate, Me.AgingOption, Me.IncludeDetails})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents ARGLAccountHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivPrdHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents ARGLAccountFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label51 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountInvoiceBalanceWithOAZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label50 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountOnAccountBalanceZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label49 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountAging120PlusDaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label48 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountAging90DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label47 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountAging60DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label46 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountAging30DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label45 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountCurrentZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivPrdFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientDivPrdCodeOnAccountBalanceZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientDivPrdCodeAging120PlusDaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientDivPrdCodeAging90DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientDivPrdCodeAging60DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientDivPrdCodeAging30DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientDivPrdCodeCurrentZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
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
        Friend WithEvents label44 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents UserID As DevExpress.XtraReports.Parameters.Parameter
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
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents AgingOptionDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountAging30Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountAging60Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountAging90Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountAging120PlusDays As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountOnAccountBalance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountInvoiceBalanceWithOA As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ClientDivPrdCode As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientDivPrdCode As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientDivPrdCodeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientDivPrdCodeAging30Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientDivPrdCodeAging60Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientDivPrdCodeAging90Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientDivPrdCodeAging120PlusDays As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientDivPrdCodeOnAccountBalance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents AgingOption As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace






