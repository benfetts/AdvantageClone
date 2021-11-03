Namespace MediaWIP.AccountsReceivable

    Partial Public Class AccountsReceivableAgedwithDisbursementDetail
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
            Me.label66 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label63 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label62 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label60 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label56 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailOnAccountBalanceZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label55 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailInvoiceBalanceWithOAZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label54 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailCurrentZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label53 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailAging120PlusDaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label52 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailAging90DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailAging60DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailAging30DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.ARGLAccountHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label58 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
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
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.label67 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label65 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label64 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label61 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.ClientDivPrdCodeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label59 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label57 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivPrdCodeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientCodeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line5 = New DevExpress.XtraReports.UI.XRLine()
            Me.label68 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label69 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientCodeCurrentZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label70 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientCodeAging30DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label71 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientCodeAging60DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label72 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientCodeAging90DaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label73 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientCodeAging120PlusDaysZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label74 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientCodeOnAccountBalanceZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label75 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ARGLAccountClientCodeInvoiceBalanceWithOAZero = New DevExpress.XtraReports.UI.FormattingRule()
            Me.label76 = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.ARGLAccountClientCodeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientCodeAging30Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientCodeAging60Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientCodeAging90Days = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientCodeAging120PlusDays = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientCodeOnAccountBalance = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ARGLAccountClientCodeInvoiceBalanceWithOA = New DevExpress.XtraReports.UI.CalculatedField()
            Me.InvoiceNumberWithSequence = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobOrderNumber = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobOrderDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.AgingOption = New DevExpress.XtraReports.Parameters.Parameter()
            Me.IncludeDetails = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ARGLAccountClientCode = New DevExpress.XtraReports.UI.CalculatedField()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label66, Me.label63, Me.label62, Me.label60, Me.label56, Me.label55, Me.label54, Me.label53, Me.label52, Me.label10, Me.label9, Me.label5, Me.label4})
            Me.Detail.HeightF = 16.05!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InvoiceDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("InvoiceNumberWithSequence", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label66
            '
            Me.label66.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Days")})
            Me.label66.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label66.LocationFloat = New DevExpress.Utils.PointFloat(397.3272!, 0!)
            Me.label66.Multiline = True
            Me.label66.Name = "label66"
            Me.label66.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label66.SizeF = New System.Drawing.SizeF(39.58334!, 16.05!)
            Me.label66.StylePriority.UseFont = False
            Me.label66.StylePriority.UseTextAlignment = False
            Me.label66.Text = "label66"
            Me.label66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label63
            '
            Me.label63.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobOrderDescription")})
            Me.label63.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 0!)
            Me.label63.Multiline = True
            Me.label63.Name = "label63"
            Me.label63.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label63.SizeF = New System.Drawing.SizeF(137.3273!, 16.05!)
            Me.label63.Text = "label63"
            '
            'label62
            '
            Me.label62.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobOrderNumber")})
            Me.label62.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label62.LocationFloat = New DevExpress.Utils.PointFloat(185.0!, 0!)
            Me.label62.Multiline = True
            Me.label62.Name = "label62"
            Me.label62.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label62.SizeF = New System.Drawing.SizeF(75.0!, 16.05!)
            Me.label62.StylePriority.UseFont = False
            Me.label62.StylePriority.UseTextAlignment = False
            Me.label62.Text = "label62"
            Me.label62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            Me.label62.TextFormatString = "{0:000000}"
            '
            'label60
            '
            Me.label60.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceRecordType")})
            Me.label60.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label60.LocationFloat = New DevExpress.Utils.PointFloat(150.0!, 0!)
            Me.label60.Multiline = True
            Me.label60.Name = "label60"
            Me.label60.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label60.SizeF = New System.Drawing.SizeF(35.0!, 16.05!)
            Me.label60.StylePriority.UseFont = False
            Me.label60.StylePriority.UseTextAlignment = False
            Me.label60.Text = "label60"
            Me.label60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label56
            '
            Me.label56.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OnAccountBalance")})
            Me.label56.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label56.FormattingRules.Add(Me.DetailOnAccountBalanceZero)
            Me.label56.LocationFloat = New DevExpress.Utils.PointFloat(836.9108!, 0!)
            Me.label56.Multiline = True
            Me.label56.Name = "label56"
            Me.label56.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label56.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label56.StylePriority.UseFont = False
            Me.label56.StylePriority.UseTextAlignment = False
            Me.label56.Text = "label56"
            Me.label56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label56.TextFormatString = "{0:n2}"
            '
            'DetailOnAccountBalanceZero
            '
            Me.DetailOnAccountBalanceZero.Condition = "[OnAccountBalance]=0"
            Me.DetailOnAccountBalanceZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailOnAccountBalanceZero.Name = "DetailOnAccountBalanceZero"
            '
            'label55
            '
            Me.label55.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceBalanceWithOA")})
            Me.label55.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label55.FormattingRules.Add(Me.DetailInvoiceBalanceWithOAZero)
            Me.label55.LocationFloat = New DevExpress.Utils.PointFloat(916.9108!, 0!)
            Me.label55.Multiline = True
            Me.label55.Name = "label55"
            Me.label55.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label55.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label55.StylePriority.UseFont = False
            Me.label55.StylePriority.UseTextAlignment = False
            Me.label55.Text = "label55"
            Me.label55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label55.TextFormatString = "{0:n2}"
            '
            'DetailInvoiceBalanceWithOAZero
            '
            Me.DetailInvoiceBalanceWithOAZero.Condition = "[InvoiceBalanceWithOA]=0"
            Me.DetailInvoiceBalanceWithOAZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailInvoiceBalanceWithOAZero.Name = "DetailInvoiceBalanceWithOAZero"
            '
            'label54
            '
            Me.label54.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Current")})
            Me.label54.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label54.FormattingRules.Add(Me.DetailCurrentZero)
            Me.label54.LocationFloat = New DevExpress.Utils.PointFloat(436.9106!, 0!)
            Me.label54.Multiline = True
            Me.label54.Name = "label54"
            Me.label54.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label54.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label54.StylePriority.UseFont = False
            Me.label54.StylePriority.UseTextAlignment = False
            Me.label54.Text = "label54"
            Me.label54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label54.TextFormatString = "{0:n2}"
            '
            'DetailCurrentZero
            '
            Me.DetailCurrentZero.Condition = "[Current]=0"
            Me.DetailCurrentZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailCurrentZero.Name = "DetailCurrentZero"
            '
            'label53
            '
            Me.label53.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging120PlusDays")})
            Me.label53.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label53.FormattingRules.Add(Me.DetailAging120PlusDaysZero)
            Me.label53.LocationFloat = New DevExpress.Utils.PointFloat(756.9106!, 0!)
            Me.label53.Multiline = True
            Me.label53.Name = "label53"
            Me.label53.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label53.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label53.StylePriority.UseFont = False
            Me.label53.StylePriority.UseTextAlignment = False
            Me.label53.Text = "label53"
            Me.label53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label53.TextFormatString = "{0:n2}"
            '
            'DetailAging120PlusDaysZero
            '
            Me.DetailAging120PlusDaysZero.Condition = "[Aging120PlusDays]=0"
            Me.DetailAging120PlusDaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailAging120PlusDaysZero.Name = "DetailAging120PlusDaysZero"
            '
            'label52
            '
            Me.label52.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging90Days")})
            Me.label52.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label52.FormattingRules.Add(Me.DetailAging90DaysZero)
            Me.label52.LocationFloat = New DevExpress.Utils.PointFloat(676.9106!, 0!)
            Me.label52.Multiline = True
            Me.label52.Name = "label52"
            Me.label52.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label52.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label52.StylePriority.UseFont = False
            Me.label52.StylePriority.UseTextAlignment = False
            Me.label52.Text = "label52"
            Me.label52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label52.TextFormatString = "{0:n2}"
            '
            'DetailAging90DaysZero
            '
            Me.DetailAging90DaysZero.Condition = "[Aging90Days]=0"
            Me.DetailAging90DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailAging90DaysZero.Name = "DetailAging90DaysZero"
            '
            'label10
            '
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging60Days")})
            Me.label10.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label10.FormattingRules.Add(Me.DetailAging60DaysZero)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(596.9107!, 0!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.StylePriority.UseTextAlignment = False
            Me.label10.Text = "label10"
            Me.label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label10.TextFormatString = "{0:n2}"
            '
            'DetailAging60DaysZero
            '
            Me.DetailAging60DaysZero.Condition = "[Aging60Days]=0"
            Me.DetailAging60DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailAging60DaysZero.Name = "DetailAging60DaysZero"
            '
            'label9
            '
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Aging30Days")})
            Me.label9.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label9.FormattingRules.Add(Me.DetailAging30DaysZero)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(516.9107!, 0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.StylePriority.UseTextAlignment = False
            Me.label9.Text = "label9"
            Me.label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label9.TextFormatString = "{0:n2}"
            '
            'DetailAging30DaysZero
            '
            Me.DetailAging30DaysZero.Condition = "[Aging30Days]=0"
            Me.DetailAging30DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.DetailAging30DaysZero.Name = "DetailAging30DaysZero"
            '
            'label5
            '
            Me.label5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumberWithSequence")})
            Me.label5.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(75.0!, 16.05!)
            Me.label5.StylePriority.UseFont = False
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate")})
            Me.label4.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 0!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(75.0!, 16.05!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.Text = "label4"
            Me.label4.TextFormatString = "{0:MM/dd/yyyy}"
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
            Me.ARGLAccountHeader.Level = 2
            Me.ARGLAccountHeader.Name = "ARGLAccountHeader"
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(75.0!, 16.04817!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "GL Account:"
            '
            'label1
            '
            Me.label1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccount")})
            Me.label1.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(75.00003!, 0!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(182.1189!, 16.05!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "label1"
            '
            'ClientHeader
            '
            Me.ClientHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label58, Me.label3})
            Me.ClientHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientHeader.HeightF = 16.05001!
            Me.ClientHeader.Level = 1
            Me.ClientHeader.Name = "ClientHeader"
            Me.ClientHeader.RepeatEveryPage = True
            '
            'label58
            '
            Me.label58.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label58.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0.00184377!)
            Me.label58.Multiline = True
            Me.label58.Name = "label58"
            Me.label58.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label58.SizeF = New System.Drawing.SizeF(74.99997!, 16.04817!)
            Me.label58.StylePriority.UseFont = False
            Me.label58.Text = "Client:"
            '
            'label3
            '
            Me.label3.CanGrow = False
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDescription")})
            Me.label3.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(75.00003!, 0!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(267.5356!, 16.05!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.Text = "label3"
            Me.label3.WordWrap = False
            '
            'ARGLAccountFooter
            '
            Me.ARGLAccountFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line4, Me.label51, Me.label50, Me.label49, Me.label48, Me.label47, Me.label46, Me.label45, Me.label18, Me.label19})
            Me.ARGLAccountFooter.HeightF = 39.67501!
            Me.ARGLAccountFooter.KeepTogether = True
            Me.ARGLAccountFooter.Level = 2
            Me.ARGLAccountFooter.Name = "ARGLAccountFooter"
            '
            'line4
            '
            Me.line4.BackColor = System.Drawing.Color.LightGray
            Me.line4.BorderColor = System.Drawing.Color.LightGray
            Me.line4.ForeColor = System.Drawing.Color.LightGray
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 33.59165!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line4.StylePriority.UseBackColor = False
            Me.line4.StylePriority.UseBorderColor = False
            Me.line4.StylePriority.UseForeColor = False
            '
            'label51
            '
            Me.label51.CanGrow = False
            Me.label51.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountInvoiceBalanceWithOA")})
            Me.label51.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label51.FormattingRules.Add(Me.ARGLAccountInvoiceBalanceWithOAZero)
            Me.label51.LocationFloat = New DevExpress.Utils.PointFloat(916.9108!, 9.999974!)
            Me.label51.Multiline = True
            Me.label51.Name = "label51"
            Me.label51.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label51.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label50.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label50.FormattingRules.Add(Me.ARGLAccountOnAccountBalanceZero)
            Me.label50.LocationFloat = New DevExpress.Utils.PointFloat(836.9108!, 9.999974!)
            Me.label50.Multiline = True
            Me.label50.Name = "label50"
            Me.label50.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label50.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label49.FormattingRules.Add(Me.ARGLAccountAging120PlusDaysZero)
            Me.label49.LocationFloat = New DevExpress.Utils.PointFloat(756.9106!, 10.00182!)
            Me.label49.Multiline = True
            Me.label49.Name = "label49"
            Me.label49.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label49.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label48.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label48.FormattingRules.Add(Me.ARGLAccountAging90DaysZero)
            Me.label48.LocationFloat = New DevExpress.Utils.PointFloat(676.9106!, 10.00182!)
            Me.label48.Multiline = True
            Me.label48.Name = "label48"
            Me.label48.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label48.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label47.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label47.FormattingRules.Add(Me.ARGLAccountAging60DaysZero)
            Me.label47.LocationFloat = New DevExpress.Utils.PointFloat(596.9106!, 9.999974!)
            Me.label47.Multiline = True
            Me.label47.Name = "label47"
            Me.label47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label47.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label46.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label46.FormattingRules.Add(Me.ARGLAccountAging30DaysZero)
            Me.label46.LocationFloat = New DevExpress.Utils.PointFloat(516.9107!, 10.00182!)
            Me.label46.Multiline = True
            Me.label46.Name = "label46"
            Me.label46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label46.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label45.FormattingRules.Add(Me.ARGLAccountCurrentZero)
            Me.label45.LocationFloat = New DevExpress.Utils.PointFloat(436.9106!, 9.999974!)
            Me.label45.Multiline = True
            Me.label45.Name = "label45"
            Me.label45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label45.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 9.999974!)
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
            Me.label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(113.021!, 9.998131!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(225.5207!, 16.05!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.Text = "label1"
            Me.label19.WordWrap = False
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label67, Me.label65, Me.label64, Me.label61, Me.label6, Me.label43, Me.label42, Me.label41, Me.label40, Me.label39, Me.label38, Me.line3, Me.label29, Me.label28, Me.label27, Me.label26, Me.label25, Me.label24, Me.label23, Me.label22, Me.line2, Me.label21, Me.label20})
            Me.PageHeader.HeightF = 112.5!
            Me.PageHeader.Name = "PageHeader"
            '
            'label67
            '
            Me.label67.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label67.LocationFloat = New DevExpress.Utils.PointFloat(397.3272!, 73.91663!)
            Me.label67.Multiline = True
            Me.label67.Name = "label67"
            Me.label67.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label67.SizeF = New System.Drawing.SizeF(39.58337!, 32.1!)
            Me.label67.StylePriority.UseFont = False
            Me.label67.StylePriority.UseTextAlignment = False
            Me.label67.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Days"
            Me.label67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label65
            '
            Me.label65.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label65.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 73.91663!)
            Me.label65.Multiline = True
            Me.label65.Name = "label65"
            Me.label65.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label65.SizeF = New System.Drawing.SizeF(137.3272!, 32.1!)
            Me.label65.StylePriority.UseFont = False
            Me.label65.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Job / Order Description"
            '
            'label64
            '
            Me.label64.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label64.LocationFloat = New DevExpress.Utils.PointFloat(185.0!, 73.91663!)
            Me.label64.Multiline = True
            Me.label64.Name = "label64"
            Me.label64.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label64.SizeF = New System.Drawing.SizeF(75.0!, 32.1!)
            Me.label64.StylePriority.UseFont = False
            Me.label64.StylePriority.UseTextAlignment = False
            Me.label64.Text = "Job / Order" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Number"
            Me.label64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label61
            '
            Me.label61.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label61.LocationFloat = New DevExpress.Utils.PointFloat(150.0!, 73.91663!)
            Me.label61.Multiline = True
            Me.label61.Name = "label61"
            Me.label61.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label61.SizeF = New System.Drawing.SizeF(35.0!, 32.1!)
            Me.label61.StylePriority.UseFont = False
            Me.label61.StylePriority.UseTextAlignment = False
            Me.label61.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Type"
            Me.label61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'label6
            '
            Me.label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 73.91663!)
            Me.label6.Multiline = True
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(75.0!, 32.1!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Invoice #"
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
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 106.4167!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line3.StylePriority.UseBackColor = False
            Me.line3.StylePriority.UseBorderColor = False
            Me.line3.StylePriority.UseForeColor = False
            '
            'label29
            '
            Me.label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label29.LocationFloat = New DevExpress.Utils.PointFloat(916.9106!, 73.91663!)
            Me.label29.Multiline = True
            Me.label29.Name = "label29"
            Me.label29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label29.SizeF = New System.Drawing.SizeF(80.0!, 32.1!)
            Me.label29.StylePriority.UseFont = False
            Me.label29.StylePriority.UseTextAlignment = False
            Me.label29.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Balance"
            Me.label29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label28
            '
            Me.label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(836.9106!, 73.91663!)
            Me.label28.Multiline = True
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(80.0!, 32.1!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.StylePriority.UseTextAlignment = False
            Me.label28.Text = "On" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Account"
            Me.label28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label27
            '
            Me.label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(756.9106!, 73.91663!)
            Me.label27.Multiline = True
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(80.0!, 32.1!)
            Me.label27.StylePriority.UseFont = False
            Me.label27.StylePriority.UseTextAlignment = False
            Me.label27.Text = "Over" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "120 Days"
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label26
            '
            Me.label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(676.9106!, 73.91663!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(80.0!, 32.1!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.StylePriority.UseTextAlignment = False
            Me.label26.Text = "Over" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "90 Days"
            Me.label26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label25
            '
            Me.label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(596.9107!, 73.91663!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(80.0!, 32.1!)
            Me.label25.StylePriority.UseFont = False
            Me.label25.StylePriority.UseTextAlignment = False
            Me.label25.Text = "Over" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "60 Days"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label24
            '
            Me.label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(516.9107!, 73.91663!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(80.0!, 32.1!)
            Me.label24.StylePriority.UseFont = False
            Me.label24.StylePriority.UseTextAlignment = False
            Me.label24.Text = "Over" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "30 Days"
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label23
            '
            Me.label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(436.9106!, 73.91663!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(80.0!, 32.1!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseTextAlignment = False
            Me.label23.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Current"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label22
            '
            Me.label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(75.00003!, 73.91663!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(75.0!, 32.1!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Date"
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
            Me.label21.SizeF = New System.Drawing.SizeF(652.0833!, 23.0!)
            Me.label21.StylePriority.UseFont = False
            Me.label21.Text = "Sorted by GL Account, Client/Division/Product and Invoice Date"
            '
            'label20
            '
            Me.label20.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(652.0833!, 23.80642!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.Text = "Accounts Receivable Aged with Disbursement Detail by Product"
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
            Me.label44.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
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
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
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
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(250.9116!, 16.05!)
            Me.pageInfo1.StylePriority.UseFont = False
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label37, Me.label30, Me.label31, Me.label32, Me.label33, Me.label34, Me.label35, Me.label36})
            Me.ReportFooter.HeightF = 32.29167!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'label37
            '
            Me.label37.CanGrow = False
            Me.label37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label37.LocationFloat = New DevExpress.Utils.PointFloat(75.00003!, 9.999974!)
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
            Me.label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label30.FormattingRules.Add(Me.ReportCurrentZero)
            Me.label30.LocationFloat = New DevExpress.Utils.PointFloat(436.9106!, 9.998131!)
            Me.label30.Multiline = True
            Me.label30.Name = "label30"
            Me.label30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label30.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label31.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label31.FormattingRules.Add(Me.ReportInvoiceBalanceWithOAZero)
            Me.label31.LocationFloat = New DevExpress.Utils.PointFloat(916.9108!, 9.998131!)
            Me.label31.Multiline = True
            Me.label31.Name = "label31"
            Me.label31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label31.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label32.FormattingRules.Add(Me.ReportOnAccountBalanceZero)
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(836.9108!, 9.998131!)
            Me.label32.Multiline = True
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label33.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label33.FormattingRules.Add(Me.ReportAging120PlusDaysZero)
            Me.label33.LocationFloat = New DevExpress.Utils.PointFloat(756.9106!, 9.998131!)
            Me.label33.Multiline = True
            Me.label33.Name = "label33"
            Me.label33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label33.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label34.FormattingRules.Add(Me.ReportAging90DaysZero)
            Me.label34.LocationFloat = New DevExpress.Utils.PointFloat(676.9106!, 9.998131!)
            Me.label34.Multiline = True
            Me.label34.Name = "label34"
            Me.label34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label34.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label35.FormattingRules.Add(Me.ReportAging60DaysZero)
            Me.label35.LocationFloat = New DevExpress.Utils.PointFloat(596.9106!, 9.998131!)
            Me.label35.Multiline = True
            Me.label35.Name = "label35"
            Me.label35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label35.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            Me.label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label36.FormattingRules.Add(Me.ReportAging30DaysZero)
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(516.9107!, 9.998131!)
            Me.label36.Multiline = True
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
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
            'ClientDivPrdCodeHeader
            '
            Me.ClientDivPrdCodeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label59, Me.label57})
            Me.ClientDivPrdCodeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientDivPrdCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientDivPrdCodeHeader.HeightF = 17.79165!
            Me.ClientDivPrdCodeHeader.Name = "ClientDivPrdCodeHeader"
            Me.ClientDivPrdCodeHeader.RepeatEveryPage = True
            '
            'label59
            '
            Me.label59.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label59.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 0.00184377!)
            Me.label59.Multiline = True
            Me.label59.Name = "label59"
            Me.label59.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label59.SizeF = New System.Drawing.SizeF(74.99996!, 16.04817!)
            Me.label59.StylePriority.UseFont = False
            Me.label59.Text = "Product:"
            '
            'label57
            '
            Me.label57.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDivPrdCode")})
            Me.label57.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.label57.LocationFloat = New DevExpress.Utils.PointFloat(75.00003!, 0!)
            Me.label57.Multiline = True
            Me.label57.Name = "label57"
            Me.label57.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label57.SizeF = New System.Drawing.SizeF(267.5356!, 16.05!)
            Me.label57.StylePriority.UseFont = False
            Me.label57.Text = "label57"
            '
            'ClientDivPrdCodeFooter
            '
            Me.ClientDivPrdCodeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label7, Me.label17, Me.label16, Me.label15, Me.label14, Me.label13, Me.label12, Me.label11, Me.label8})
            Me.ClientDivPrdCodeFooter.HeightF = 35.84163!
            Me.ClientDivPrdCodeFooter.Name = "ClientDivPrdCodeFooter"
            '
            'label7
            '
            Me.label7.CanGrow = False
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDivPrdCode")})
            Me.label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(113.021!, 10.00182!)
            Me.label7.Multiline = True
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(225.5207!, 16.05!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.WordWrap = False
            '
            'label17
            '
            Me.label17.CanGrow = False
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA")})
            Me.label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label17.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(916.9108!, 9.791629!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label17.StylePriority.UseFont = False
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
            Me.label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label16.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeOnAccountBalanceZero)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(836.9108!, 9.791629!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label16.StylePriority.UseFont = False
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
            Me.label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label15.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeAging120PlusDaysZero)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(756.9106!, 9.791629!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label15.StylePriority.UseFont = False
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
            Me.label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label14.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeAging90DaysZero)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(676.9106!, 9.999974!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label14.StylePriority.UseFont = False
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
            Me.label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label13.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeAging60DaysZero)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(596.9106!, 9.791629!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label13.StylePriority.UseFont = False
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
            Me.label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label12.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeAging30DaysZero)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(516.9107!, 9.791629!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label12.StylePriority.UseFont = False
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
            Me.label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label11.FormattingRules.Add(Me.ARGLAccountClientDivPrdCodeCurrentZero)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(436.9106!, 9.791629!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label11.StylePriority.UseFont = False
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
            'label8
            '
            Me.label8.CanGrow = False
            Me.label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 10.00182!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(38.02099!, 16.04817!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.Text = "Total:"
            Me.label8.WordWrap = False
            '
            'ClientCodeFooter
            '
            Me.ClientCodeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line5, Me.label68, Me.label69, Me.label70, Me.label71, Me.label72, Me.label73, Me.label74, Me.label75, Me.label76})
            Me.ClientCodeFooter.HeightF = 38.96663!
            Me.ClientCodeFooter.Level = 1
            Me.ClientCodeFooter.Name = "ClientCodeFooter"
            '
            'line5
            '
            Me.line5.BackColor = System.Drawing.Color.Transparent
            Me.line5.BorderColor = System.Drawing.Color.LightGray
            Me.line5.ForeColor = System.Drawing.Color.LightGray
            Me.line5.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 31.8416!)
            Me.line5.Name = "line5"
            Me.line5.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
            Me.line5.StylePriority.UseBackColor = False
            Me.line5.StylePriority.UseBorderColor = False
            Me.line5.StylePriority.UseForeColor = False
            '
            'label68
            '
            Me.label68.CanGrow = False
            Me.label68.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label68.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 9.795316!)
            Me.label68.Multiline = True
            Me.label68.Name = "label68"
            Me.label68.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label68.SizeF = New System.Drawing.SizeF(38.02099!, 16.04817!)
            Me.label68.StylePriority.UseFont = False
            Me.label68.Text = "Total:"
            Me.label68.WordWrap = False
            '
            'label69
            '
            Me.label69.CanGrow = False
            Me.label69.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientCodeCurrent")})
            Me.label69.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label69.FormattingRules.Add(Me.ARGLAccountClientCodeCurrentZero)
            Me.label69.LocationFloat = New DevExpress.Utils.PointFloat(436.9106!, 9.793472!)
            Me.label69.Multiline = True
            Me.label69.Name = "label69"
            Me.label69.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label69.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label69.StylePriority.UseFont = False
            Me.label69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label69.TextFormatString = "{0:n2}"
            Me.label69.WordWrap = False
            '
            'ARGLAccountClientCodeCurrentZero
            '
            Me.ARGLAccountClientCodeCurrentZero.Condition = "[ARGLAccountClientCodeCurrent]=0"
            Me.ARGLAccountClientCodeCurrentZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientCodeCurrentZero.Name = "ARGLAccountClientCodeCurrentZero"
            '
            'label70
            '
            Me.label70.CanGrow = False
            Me.label70.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientCodeAging30Days")})
            Me.label70.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label70.FormattingRules.Add(Me.ARGLAccountClientCodeAging30DaysZero)
            Me.label70.LocationFloat = New DevExpress.Utils.PointFloat(516.9107!, 9.793472!)
            Me.label70.Multiline = True
            Me.label70.Name = "label70"
            Me.label70.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label70.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label70.StylePriority.UseFont = False
            Me.label70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label70.TextFormatString = "{0:n2}"
            Me.label70.WordWrap = False
            '
            'ARGLAccountClientCodeAging30DaysZero
            '
            Me.ARGLAccountClientCodeAging30DaysZero.Condition = "[ARGLAccountClientCodeAging30Days]=0"
            Me.ARGLAccountClientCodeAging30DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientCodeAging30DaysZero.Name = "ARGLAccountClientCodeAging30DaysZero"
            '
            'label71
            '
            Me.label71.CanGrow = False
            Me.label71.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientCodeAging60Days")})
            Me.label71.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label71.FormattingRules.Add(Me.ARGLAccountClientCodeAging60DaysZero)
            Me.label71.LocationFloat = New DevExpress.Utils.PointFloat(596.9106!, 9.793472!)
            Me.label71.Multiline = True
            Me.label71.Name = "label71"
            Me.label71.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label71.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label71.StylePriority.UseFont = False
            Me.label71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label71.TextFormatString = "{0:n2}"
            Me.label71.WordWrap = False
            '
            'ARGLAccountClientCodeAging60DaysZero
            '
            Me.ARGLAccountClientCodeAging60DaysZero.Condition = "[ARGLAccountClientCodeAging60Days]=0"
            Me.ARGLAccountClientCodeAging60DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientCodeAging60DaysZero.Name = "ARGLAccountClientCodeAging60DaysZero"
            '
            'label72
            '
            Me.label72.CanGrow = False
            Me.label72.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientCodeAging90Days")})
            Me.label72.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label72.FormattingRules.Add(Me.ARGLAccountClientCodeAging90DaysZero)
            Me.label72.LocationFloat = New DevExpress.Utils.PointFloat(676.9106!, 9.793472!)
            Me.label72.Multiline = True
            Me.label72.Name = "label72"
            Me.label72.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label72.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label72.StylePriority.UseFont = False
            Me.label72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label72.TextFormatString = "{0:n2}"
            Me.label72.WordWrap = False
            '
            'ARGLAccountClientCodeAging90DaysZero
            '
            Me.ARGLAccountClientCodeAging90DaysZero.Condition = "[ARGLAccountClientCodeAging90Days]=0"
            Me.ARGLAccountClientCodeAging90DaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientCodeAging90DaysZero.Name = "ARGLAccountClientCodeAging90DaysZero"
            '
            'label73
            '
            Me.label73.CanGrow = False
            Me.label73.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientCodeAging120PlusDays")})
            Me.label73.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label73.FormattingRules.Add(Me.ARGLAccountClientCodeAging120PlusDaysZero)
            Me.label73.LocationFloat = New DevExpress.Utils.PointFloat(756.9106!, 9.793472!)
            Me.label73.Multiline = True
            Me.label73.Name = "label73"
            Me.label73.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label73.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label73.StylePriority.UseFont = False
            Me.label73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label73.TextFormatString = "{0:n2}"
            Me.label73.WordWrap = False
            '
            'ARGLAccountClientCodeAging120PlusDaysZero
            '
            Me.ARGLAccountClientCodeAging120PlusDaysZero.Condition = "[ARGLAccountClientCodeAging120PlusDays]=0"
            Me.ARGLAccountClientCodeAging120PlusDaysZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientCodeAging120PlusDaysZero.Name = "ARGLAccountClientCodeAging120PlusDaysZero"
            '
            'label74
            '
            Me.label74.CanGrow = False
            Me.label74.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientCodeOnAccountBalance")})
            Me.label74.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label74.FormattingRules.Add(Me.ARGLAccountClientCodeOnAccountBalanceZero)
            Me.label74.LocationFloat = New DevExpress.Utils.PointFloat(836.9108!, 9.793472!)
            Me.label74.Multiline = True
            Me.label74.Name = "label74"
            Me.label74.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label74.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label74.StylePriority.UseFont = False
            Me.label74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label74.TextFormatString = "{0:n2}"
            Me.label74.WordWrap = False
            '
            'ARGLAccountClientCodeOnAccountBalanceZero
            '
            Me.ARGLAccountClientCodeOnAccountBalanceZero.Condition = "[ARGLAccountClientCodeOnAccountBalance]=0"
            Me.ARGLAccountClientCodeOnAccountBalanceZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientCodeOnAccountBalanceZero.Name = "ARGLAccountClientCodeOnAccountBalanceZero"
            '
            'label75
            '
            Me.label75.CanGrow = False
            Me.label75.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ARGLAccountClientCodeInvoiceBalanceWithOA")})
            Me.label75.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label75.FormattingRules.Add(Me.ARGLAccountClientCodeInvoiceBalanceWithOAZero)
            Me.label75.LocationFloat = New DevExpress.Utils.PointFloat(916.9108!, 9.793472!)
            Me.label75.Multiline = True
            Me.label75.Name = "label75"
            Me.label75.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label75.SizeF = New System.Drawing.SizeF(80.0!, 16.05!)
            Me.label75.StylePriority.UseFont = False
            Me.label75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label75.TextFormatString = "{0:n2}"
            Me.label75.WordWrap = False
            '
            'ARGLAccountClientCodeInvoiceBalanceWithOAZero
            '
            Me.ARGLAccountClientCodeInvoiceBalanceWithOAZero.Condition = "[ARGLAccountClientCodeInvoiceBalanceWithOA]=0"
            Me.ARGLAccountClientCodeInvoiceBalanceWithOAZero.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.ARGLAccountClientCodeInvoiceBalanceWithOAZero.Name = "ARGLAccountClientCodeInvoiceBalanceWithOAZero"
            '
            'label76
            '
            Me.label76.CanGrow = False
            Me.label76.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDescription")})
            Me.label76.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
            Me.label76.LocationFloat = New DevExpress.Utils.PointFloat(113.021!, 9.795316!)
            Me.label76.Multiline = True
            Me.label76.Name = "label76"
            Me.label76.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label76.SizeF = New System.Drawing.SizeF(225.5207!, 16.05!)
            Me.label76.StylePriority.UseFont = False
            Me.label76.WordWrap = False
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
            'ARGLAccountClientCodeCurrent
            '
            Me.ARGLAccountClientCodeCurrent.Expression = "[][[ARGLAccountClientCode]=[^.ARGLAccountClientCode]].Sum([Current])"
            Me.ARGLAccountClientCodeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientCodeCurrent.Name = "ARGLAccountClientCodeCurrent"
            '
            'ARGLAccountClientCodeAging30Days
            '
            Me.ARGLAccountClientCodeAging30Days.Expression = "[][[ARGLAccountClientCode]=[^.ARGLAccountClientCode]].Sum([Aging30Days])"
            Me.ARGLAccountClientCodeAging30Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientCodeAging30Days.Name = "ARGLAccountClientCodeAging30Days"
            '
            'ARGLAccountClientCodeAging60Days
            '
            Me.ARGLAccountClientCodeAging60Days.Expression = "[][[ARGLAccountClientCode]=[^.ARGLAccountClientCode]].Sum([Aging60Days])"
            Me.ARGLAccountClientCodeAging60Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientCodeAging60Days.Name = "ARGLAccountClientCodeAging60Days"
            '
            'ARGLAccountClientCodeAging90Days
            '
            Me.ARGLAccountClientCodeAging90Days.Expression = "[][[ARGLAccountClientCode]=[^.ARGLAccountClientCode]].Sum([Aging90Days])"
            Me.ARGLAccountClientCodeAging90Days.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientCodeAging90Days.Name = "ARGLAccountClientCodeAging90Days"
            '
            'ARGLAccountClientCodeAging120PlusDays
            '
            Me.ARGLAccountClientCodeAging120PlusDays.Expression = "[][[ARGLAccountClientCode]=[^.ARGLAccountClientCode]].Sum([Aging120PlusDays])"
            Me.ARGLAccountClientCodeAging120PlusDays.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientCodeAging120PlusDays.Name = "ARGLAccountClientCodeAging120PlusDays"
            '
            'ARGLAccountClientCodeOnAccountBalance
            '
            Me.ARGLAccountClientCodeOnAccountBalance.Expression = "[][[ARGLAccountClientCode]=[^.ARGLAccountClientCode]].Sum([OnAccountBalance])"
            Me.ARGLAccountClientCodeOnAccountBalance.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientCodeOnAccountBalance.Name = "ARGLAccountClientCodeOnAccountBalance"
            '
            'ARGLAccountClientCodeInvoiceBalanceWithOA
            '
            Me.ARGLAccountClientCodeInvoiceBalanceWithOA.Expression = "[][[ARGLAccountClientCode]=[^.ARGLAccountClientCode]].Sum([InvoiceBalanceWithOA])" &
    ""
            Me.ARGLAccountClientCodeInvoiceBalanceWithOA.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.ARGLAccountClientCodeInvoiceBalanceWithOA.Name = "ARGLAccountClientCodeInvoiceBalanceWithOA"
            '
            'InvoiceNumberWithSequence
            '
            Me.InvoiceNumberWithSequence.Expression = "Concat(PadLeft(Trim([InvoiceNumber]),6,'0'),IIf([InvoiceSequence]>='01',Concat('-" &
    "',[InvoiceSequence]),'  '),[PartialPaymentIndicator])"
            Me.InvoiceNumberWithSequence.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.InvoiceNumberWithSequence.Name = "InvoiceNumberWithSequence"
            '
            'JobOrderNumber
            '
            Me.JobOrderNumber.Expression = "IIf([InvoiceRecordType] In ('P','S'),PadLeft([JobNumber],6,'0'),PadLeft([OrderNum" &
    "ber],6,'0'))"
            Me.JobOrderNumber.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobOrderNumber.Name = "JobOrderNumber"
            '
            'JobOrderDescription
            '
            Me.JobOrderDescription.Expression = "IIf([InvoiceRecordType] In ('P','S'),[JobDescription],[OrderDescription])"
            Me.JobOrderDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobOrderDescription.Name = "JobOrderDescription"
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
            'ARGLAccountClientCode
            '
            Me.ARGLAccountClientCode.Expression = "Concat([ARGLAccount],[ClientCode])"
            Me.ARGLAccountClientCode.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ARGLAccountClientCode.Name = "ARGLAccountClientCode"
            '
            'AccountsReceivableAgedwithDisbursementDetail
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ARGLAccountHeader, Me.ClientHeader, Me.ARGLAccountFooter, Me.PageHeader, Me.PageFooter, Me.ReportFooter, Me.ClientDivPrdCodeHeader, Me.ClientDivPrdCodeFooter, Me.ClientCodeFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.AgingOptionDescription, Me.ARGLAccountCurrent, Me.ARGLAccountAging30Days, Me.ARGLAccountAging60Days, Me.ARGLAccountAging90Days, Me.ARGLAccountAging120PlusDays, Me.ARGLAccountOnAccountBalance, Me.ARGLAccountInvoiceBalanceWithOA, Me.ClientDivPrdCode, Me.ARGLAccountClientDivPrdCode, Me.ARGLAccountClientDivPrdCodeCurrent, Me.ARGLAccountClientDivPrdCodeAging30Days, Me.ARGLAccountClientDivPrdCodeAging60Days, Me.ARGLAccountClientDivPrdCodeAging90Days, Me.ARGLAccountClientDivPrdCodeAging120PlusDays, Me.ARGLAccountClientDivPrdCodeOnAccountBalance, Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOA, Me.ARGLAccountClientCodeCurrent, Me.ARGLAccountClientCodeAging30Days, Me.ARGLAccountClientCodeAging60Days, Me.ARGLAccountClientCodeAging90Days, Me.ARGLAccountClientCodeAging120PlusDays, Me.ARGLAccountClientCodeOnAccountBalance, Me.ARGLAccountClientCodeInvoiceBalanceWithOA, Me.InvoiceNumberWithSequence, Me.JobOrderNumber, Me.JobOrderDescription, Me.ARGLAccountClientCode})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "Accounts Receivable Aged with Disbursement Detail"
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.ARGLAccountCurrentZero, Me.ARGLAccountAging60DaysZero, Me.ARGLAccountAging30DaysZero, Me.ARGLAccountAging90DaysZero, Me.ARGLAccountAging120PlusDaysZero, Me.ARGLAccountOnAccountBalanceZero, Me.ARGLAccountInvoiceBalanceWithOAZero, Me.ARGLAccountClientDivPrdCodeCurrentZero, Me.ARGLAccountClientDivPrdCodeAging30DaysZero, Me.ARGLAccountClientDivPrdCodeAging60DaysZero, Me.ARGLAccountClientDivPrdCodeAging90DaysZero, Me.ARGLAccountClientDivPrdCodeAging120PlusDaysZero, Me.ARGLAccountClientDivPrdCodeOnAccountBalanceZero, Me.ARGLAccountClientDivPrdCodeInvoiceBalanceWithOAZero, Me.ReportAging60DaysZero, Me.ReportCurrentZero, Me.ReportAging30DaysZero, Me.ReportAging90DaysZero, Me.ReportAging120PlusDaysZero, Me.ReportOnAccountBalanceZero, Me.ReportInvoiceBalanceWithOAZero, Me.DetailCurrentZero, Me.DetailAging30DaysZero, Me.DetailAging60DaysZero, Me.DetailAging90DaysZero, Me.DetailAging120PlusDaysZero, Me.DetailOnAccountBalanceZero, Me.DetailInvoiceBalanceWithOAZero, Me.ARGLAccountClientCodeCurrentZero, Me.ARGLAccountClientCodeAging60DaysZero, Me.ARGLAccountClientCodeAging90DaysZero, Me.ARGLAccountClientCodeAging120PlusDaysZero, Me.ARGLAccountClientCodeOnAccountBalanceZero, Me.ARGLAccountClientCodeInvoiceBalanceWithOAZero, Me.ARGLAccountClientCodeAging30DaysZero})
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 51)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.UserID, Me.PeriodCutoff, Me.AgingDate, Me.AgingOption, Me.IncludeDetails})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label66 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label63 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label62 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label60 As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents ARGLAccountHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label58 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
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
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label67 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label65 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label64 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label61 As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents ClientDivPrdCodeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label59 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label57 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivPrdCodeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientCodeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line5 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label68 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label69 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientCodeCurrentZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label70 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientCodeAging30DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label71 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientCodeAging60DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label72 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientCodeAging90DaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label73 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientCodeAging120PlusDaysZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label74 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientCodeOnAccountBalanceZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label75 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ARGLAccountClientCodeInvoiceBalanceWithOAZero As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents label76 As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents ARGLAccountClientCodeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientCodeAging30Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientCodeAging60Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientCodeAging90Days As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientCodeAging120PlusDays As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientCodeOnAccountBalance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ARGLAccountClientCodeInvoiceBalanceWithOA As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InvoiceNumberWithSequence As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents JobOrderNumber As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents JobOrderDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents AgingOption As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents IncludeDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ARGLAccountClientCode As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace






