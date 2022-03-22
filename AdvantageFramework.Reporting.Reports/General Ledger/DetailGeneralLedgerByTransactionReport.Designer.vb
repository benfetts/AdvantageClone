Namespace GeneralLedger

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class DetailGeneralLedgerByTransactionReport
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Designer
        'It can be modified using the Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label28 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.label26 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.Line26 = New DevExpress.XtraReports.UI.XRLine()
            Me.ReversingYN = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label13, Me.label14, Me.label15, Me.label23, Me.label22})
            Me.Detail.HeightF = 23.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label13
            '
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CDP")})
            Me.label13.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(612.5032!, 0!)
            Me.label13.Multiline = True
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(137.4968!, 23.0!)
            Me.label13.StylePriority.UseFont = False
            Me.label13.Text = "label13"
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreditAmount")})
            Me.label14.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(501.0417!, 0!)
            Me.label14.Multiline = True
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label14.StylePriority.UseFont = False
            Me.label14.Text = "label14"
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label14.TextFormatString = "{0:N2}"
            '
            'label15
            '
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DebitAmount")})
            Me.label15.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(401.0417!, 0!)
            Me.label15.Multiline = True
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label15.StylePriority.UseFont = False
            Me.label15.Text = "label15"
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label15.TextFormatString = "{0:N2}"
            '
            'label23
            '
            Me.label23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountDescription")})
            Me.label23.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0!)
            Me.label23.Multiline = True
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(301.0417!, 23.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.Text = "label23"
            '
            'label22
            '
            Me.label22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountCode")})
            Me.label22.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label22.Multiline = True
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.Text = "label22"
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 39.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 59.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(612.5032!, 3.999996!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(135.46!, 21.0!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.StylePriority.UseTextAlignment = False
            Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.pageInfo2.TextFormatString = "Page {0} of {1}"
            '
            'pageInfo1
            '
            Me.pageInfo1.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 3.999996!)
            Me.pageInfo1.Name = "pageInfo1"
            Me.pageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo1.SizeF = New System.Drawing.SizeF(490.0!, 19.0!)
            Me.pageInfo1.StylePriority.UseFont = False
            Me.pageInfo1.TextFormatString = "{0:dddd, MMMM d, yyyy h:mm tt}"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.LineTopLine, Me.label2, Me.label1})
            Me.ReportHeader.HeightF = 77.08334!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'XrLine1
            '
            Me.XrLine1.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4.0!
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(1.0!, 68.54!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(749.0!, 4.08!)
            '
            'LineTopLine
            '
            Me.LineTopLine.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4.0!
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.916656!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(749.0!, 4.08!)
            '
            'label2
            '
            Me.label2.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(9.999974!, 46.0!)
            Me.label2.Multiline = True
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(162.5!, 18.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.Text = "Sorted by Transaction"
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 20.0!)
            Me.label1.Multiline = True
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(480.0!, 26.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "Detail General Ledger Transaction Report"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.label8, Me.label5, Me.label4, Me.label3})
            Me.PageHeader.HeightF = 27.29168!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrLine2
            '
            Me.XrLine2.ForeColor = System.Drawing.Color.Silver
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(2.083333!, 22.99999!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(746.9167!, 2.708403!)
            Me.XrLine2.StylePriority.UseForeColor = False
            '
            'label8
            '
            Me.label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(612.5032!, 0!)
            Me.label8.Multiline = True
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(137.4968!, 23.0!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.StylePriority.UseTextAlignment = False
            Me.label8.Text = "Client-Division-Product"
            Me.label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(493.7532!, 0!)
            Me.label5.Multiline = True
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.StylePriority.UseTextAlignment = False
            Me.label5.Text = "Credit"
            Me.label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'label4
            '
            Me.label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(393.7532!, 0!)
            Me.label4.Multiline = True
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.StylePriority.UseTextAlignment = False
            Me.label4.Text = "Debit"
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'label3
            '
            Me.label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label3.Multiline = True
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.StylePriority.UseTextAlignment = False
            Me.label3.Text = "G/L Account"
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label28, Me.label21, Me.label20, Me.label19, Me.label18, Me.label17, Me.label16, Me.label12, Me.label11, Me.label10, Me.label9})
            Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("TransactionID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader1.HeightF = 45.99999!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'label28
            '
            Me.label28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Remark")})
            Me.label28.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label28.LocationFloat = New DevExpress.Utils.PointFloat(162.5!, 0!)
            Me.label28.Multiline = True
            Me.label28.Name = "label28"
            Me.label28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label28.SizeF = New System.Drawing.SizeF(389.5865!, 23.0!)
            Me.label28.StylePriority.UseFont = False
            Me.label28.Text = "label28"
            '
            'label21
            '
            Me.label21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Source")})
            Me.label21.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(612.5032!, 0!)
            Me.label21.Multiline = True
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(28.125!, 23.0!)
            Me.label21.StylePriority.UseFont = False
            Me.label21.Text = "label21"
            '
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TransactionID")})
            Me.label20.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0!)
            Me.label20.Multiline = True
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(62.5!, 23.0!)
            Me.label20.StylePriority.UseFont = False
            Me.label20.Text = "label20"
            '
            'label19
            '
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "UserCode")})
            Me.label19.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(375.0!, 22.99999!)
            Me.label19.Multiline = True
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.Text = "label19"
            '
            'label18
            '
            Me.label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(640.6282!, 0!)
            Me.label18.Multiline = True
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(68.74683!, 23.0!)
            Me.label18.StylePriority.UseFont = False
            Me.label18.Text = "Reversing:"
            '
            'label17
            '
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ReversingYN")})
            Me.label17.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(709.375!, 0!)
            Me.label17.Multiline = True
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(40.625!, 23.0!)
            Me.label17.StylePriority.UseFont = False
            '
            'label16
            '
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.label16.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 22.99999!)
            Me.label16.Multiline = True
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label16.StylePriority.UseFont = False
            Me.label16.Text = "label16"
            '
            'label12
            '
            Me.label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(301.0417!, 22.99999!)
            Me.label12.Multiline = True
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(73.95834!, 23.0!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.Text = "Created by:"
            '
            'label11
            '
            Me.label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(552.0865!, 0!)
            Me.label11.Multiline = True
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(60.41669!, 23.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.Text = "Source:"
            '
            'label10
            '
            Me.label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(0!, 22.99999!)
            Me.label10.Multiline = True
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.Text = "Posting Period:"
            '
            'label9
            '
            Me.label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label9.Multiline = True
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.Text = "Transaction:"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line2, Me.label26, Me.label24, Me.label25})
            Me.GroupFooter1.HeightF = 28.5834!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'line2
            '
            Me.line2.ForeColor = System.Drawing.Color.Silver
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(2.083333!, 23.62506!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(743.75!, 2.083334!)
            Me.line2.StylePriority.UseForeColor = False
            '
            'label26
            '
            Me.label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label26.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label26.Multiline = True
            Me.label26.Name = "label26"
            Me.label26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label26.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label26.StylePriority.UseFont = False
            Me.label26.Text = "Total:"
            '
            'label24
            '
            Me.label24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DebitAmount")})
            Me.label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label24.LocationFloat = New DevExpress.Utils.PointFloat(401.0417!, 0!)
            Me.label24.Multiline = True
            Me.label24.Name = "label24"
            Me.label24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label24.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label24.StylePriority.UseFont = False
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label24.Summary = XrSummary1
            Me.label24.Text = "label15"
            Me.label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label24.TextFormatString = "{0:N2}"
            '
            'label25
            '
            Me.label25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreditAmount")})
            Me.label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.label25.LocationFloat = New DevExpress.Utils.PointFloat(501.0417!, 0!)
            Me.label25.Multiline = True
            Me.label25.Name = "label25"
            Me.label25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label25.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label25.StylePriority.UseFont = False
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label25.Summary = XrSummary2
            Me.label25.Text = "label14"
            Me.label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label25.TextFormatString = "{0:N2}"
            '
            'BindingSource1
            '
            Me.BindingSource1.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport)
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pageInfo2, Me.pageInfo1, Me.Line26})
            Me.PageFooter.HeightF = 27.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Line26
            '
            Me.Line26.BorderColor = System.Drawing.Color.Silver
            Me.Line26.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line26.BorderWidth = 4.0!
            Me.Line26.ForeColor = System.Drawing.Color.Silver
            Me.Line26.LineWidth = 4.0!
            Me.Line26.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Line26.Name = "Line26"
            Me.Line26.SizeF = New System.Drawing.SizeF(749.0!, 4.0!)
            '
            'ReversingYN
            '
            Me.ReversingYN.Expression = "Iif([Reversing] = 1, 'Yes','No' )"
            Me.ReversingYN.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ReversingYN.Name = "ReversingYN"
            '
            'GroupFooter2
            '
            Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel1, Me.XrLabel2})
            Me.GroupFooter2.HeightF = 40.04157!
            Me.GroupFooter2.Level = 1
            Me.GroupFooter2.Name = "GroupFooter2"
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreditAmount")})
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(501.0417!, 7.041582!)
            Me.XrLabel1.Multiline = True
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel1.Summary = XrSummary3
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel1.TextFormatString = "{0:N2}"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DebitAmount")})
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(401.0417!, 7.041582!)
            Me.XrLabel2.Multiline = True
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel2.StylePriority.UseFont = False
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel2.Summary = XrSummary4
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel2.TextFormatString = "{0:N2}"
            '
            'XrLabel3
            '
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 7.041582!)
            Me.XrLabel3.Multiline = True
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.Text = "Report Total:"
            '
            'DetailGeneralLedgerByTransactionReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageHeader, Me.GroupHeader1, Me.GroupFooter1, Me.PageFooter, Me.GroupFooter2})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ReversingYN})
            Me.DataSource = Me.BindingSource1
            Me.DisplayName = "Detail GL Transaction Report"
            Me.FilterString = "[TransactionID] Is Not Null"
            Me.Font = New System.Drawing.Font("Calibri", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 39, 59)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label28 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label26 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents Line26 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents ReversingYN As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
