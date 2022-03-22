Namespace Media

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class BroadcastInvoiceSummaryReport
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
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailVendorCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrPictureBoxHeaderLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_DateRangeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_DateRange = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderStation_ClientLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_ScheduleGrossLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_InvoiceGrossLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_StatusLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_InvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_MediaLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_MonthLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_OrderLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_ClientNameLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_ClientCodeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_VendorNameLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_LineLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel17, Me.XrLabel16, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.XrLabel8, Me.XrLabel6, Me.XrLabel1, Me.LabelDetailVendorCode})
            Me.Detail.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Detail.HeightF = 17.00001!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel3
            '
            Me.XrLabel3.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OrderLineNumber]")})
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(437.7085!, 0!)
            Me.XrLabel3.Multiline = True
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(38.95822!, 17.00001!)
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "XrLabel3"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel17
            '
            Me.XrLabel17.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ScheduleGross]")})
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(888.3336!, 0!)
            Me.XrLabel17.Multiline = True
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel17.StylePriority.UseTextAlignment = False
            Me.XrLabel17.Text = "XrLabel17"
            Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel17.TextFormatString = "{0:N2}"
            '
            'XrLabel16
            '
            Me.XrLabel16.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InvoiceGross]")})
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(777.2919!, 0!)
            Me.XrLabel16.Multiline = True
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel16.StylePriority.UseTextAlignment = False
            Me.XrLabel16.Text = "XrLabel16"
            Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel16.TextFormatString = "{0:N2}"
            '
            'XrLabel11
            '
            Me.XrLabel11.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Status]")})
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(663.1251!, 0!)
            Me.XrLabel11.Multiline = True
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(114.1667!, 17.00001!)
            Me.XrLabel11.Text = "XrLabel11"
            '
            'XrLabel10
            '
            Me.XrLabel10.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InvoiceNumber]")})
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(575.2086!, 0!)
            Me.XrLabel10.Multiline = True
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(87.91656!, 17.00001!)
            Me.XrLabel10.Text = "XrLabel10"
            '
            'XrLabel9
            '
            Me.XrLabel9.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Media]")})
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(531.8752!, 0!)
            Me.XrLabel9.Multiline = True
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(42.70831!, 17.00001!)
            Me.XrLabel9.Text = "XrLabel9"
            '
            'XrLabel8
            '
            Me.XrLabel8.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MonthOfService]")})
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(487.5001!, 0!)
            Me.XrLabel8.Multiline = True
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(43.75!, 17.00001!)
            Me.XrLabel8.Text = "XrLabel8"
            '
            'XrLabel6
            '
            Me.XrLabel6.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OrderNumber]")})
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(371.0419!, 0!)
            Me.XrLabel6.Multiline = True
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(66.66666!, 17.00001!)
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            Me.XrLabel6.Text = "XrLabel6"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel4
            '
            Me.XrLabel4.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ClientName]")})
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(85.41666!, 17.00001!)
            Me.XrLabel4.Multiline = True
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(225.0!, 17.00001!)
            Me.XrLabel4.StylePriority.UseFont = False
            Me.XrLabel4.Text = "XrLabel4"
            '
            'XrLabel2
            '
            Me.XrLabel2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ClientCode]")})
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(85.41666!, 0!)
            Me.XrLabel2.Multiline = True
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.Text = "XrLabel2"
            '
            'XrLabel1
            '
            Me.XrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VendorName]")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(83.66318!, 0!)
            Me.XrLabel1.Multiline = True
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(264.2535!, 17.00001!)
            Me.XrLabel1.Text = "XrLabel1"
            '
            'LabelDetailVendorCode
            '
            Me.LabelDetailVendorCode.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VendorCode]")})
            Me.LabelDetailVendorCode.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetailVendorCode.Multiline = True
            Me.LabelDetailVendorCode.Name = "LabelDetailVendorCode"
            Me.LabelDetailVendorCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailVendorCode.SizeF = New System.Drawing.SizeF(78.16646!, 17.0!)
            Me.LabelDetailVendorCode.Text = "LabelDetailVendorCode"
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 25.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 25.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'XrPictureBoxHeaderLogo
            '
            Me.XrPictureBoxHeaderLogo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrPictureBoxHeaderLogo.Name = "XrPictureBoxHeaderLogo"
            Me.XrPictureBoxHeaderLogo.SizeF = New System.Drawing.SizeF(1000.0!, 150.0!)
            '
            'LabelPageHeader_ReportTitle
            '
            Me.LabelPageHeader_ReportTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.6252289!, 0!)
            Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
            Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(999.375!, 25.0!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "Broadcast Invoice Summary"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pageInfo2, Me.XrPageInfo1})
            Me.PageFooter.HeightF = 33.33!
            Me.PageFooter.Name = "PageFooter"
            '
            'pageInfo2
            '
            Me.pageInfo2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.pageInfo2.Name = "pageInfo2"
            Me.pageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.pageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.pageInfo2.SizeF = New System.Drawing.SizeF(347.9167!, 16.33002!)
            Me.pageInfo2.StylePriority.UseFont = False
            Me.pageInfo2.TextFormatString = "{0:dddd, MMMM dd, yyyy h:mm tt}"
            '
            'XrPageInfo1
            '
            Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(864.5418!, 0!)
            Me.XrPageInfo1.Name = "XrPageInfo1"
            Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(135.4583!, 16.33002!)
            Me.XrPageInfo1.StylePriority.UseFont = False
            Me.XrPageInfo1.StylePriority.UseTextAlignment = False
            Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrPageInfo1.TextFormatString = "Page {0} of {1}"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBoxHeaderLogo})
            Me.ReportHeader.HeightF = 150.0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_DateRangeLabel, Me.LabelPageHeader_DateRange, Me.LabelPageHeader_ReportTitle})
            Me.PageHeader.HeightF = 54.5!
            Me.PageHeader.Name = "PageHeader"
            '
            'LabelPageHeader_DateRangeLabel
            '
            Me.LabelPageHeader_DateRangeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_DateRangeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_DateRangeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_DateRangeLabel.BorderWidth = 1.0!
            Me.LabelPageHeader_DateRangeLabel.CanGrow = False
            Me.LabelPageHeader_DateRangeLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_DateRangeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_DateRangeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 33.5!)
            Me.LabelPageHeader_DateRangeLabel.Name = "LabelPageHeader_DateRangeLabel"
            Me.LabelPageHeader_DateRangeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_DateRangeLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelPageHeader_DateRangeLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelPageHeader_DateRangeLabel.StylePriority.UseFont = False
            Me.LabelPageHeader_DateRangeLabel.StylePriority.UsePadding = False
            Me.LabelPageHeader_DateRangeLabel.Text = "Date Range:"
            Me.LabelPageHeader_DateRangeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_DateRange
            '
            Me.LabelPageHeader_DateRange.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelPageHeader_DateRange.LocationFloat = New DevExpress.Utils.PointFloat(75.96181!, 33.5!)
            Me.LabelPageHeader_DateRange.Name = "LabelPageHeader_DateRange"
            Me.LabelPageHeader_DateRange.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_DateRange.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelPageHeader_DateRange.SizeF = New System.Drawing.SizeF(250.0!, 17.0!)
            Me.LabelPageHeader_DateRange.StylePriority.UseFont = False
            Me.LabelPageHeader_DateRange.Text = "LabelPageHeader_DateRange"
            '
            'LabelGroupHeaderStation_ClientLabel
            '
            Me.LabelGroupHeaderStation_ClientLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderStation_ClientLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderStation_ClientLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderStation_ClientLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderStation_ClientLabel.CanGrow = False
            Me.LabelGroupHeaderStation_ClientLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeaderStation_ClientLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderStation_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 15.625!)
            Me.LabelGroupHeaderStation_ClientLabel.Name = "LabelGroupHeaderStation_ClientLabel"
            Me.LabelGroupHeaderStation_ClientLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderStation_ClientLabel.SizeF = New System.Drawing.SizeF(78.16645!, 17.00001!)
            Me.LabelGroupHeaderStation_ClientLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderStation_ClientLabel.StylePriority.UsePadding = False
            Me.LabelGroupHeaderStation_ClientLabel.Text = "Vendor Code"
            Me.LabelGroupHeaderStation_ClientLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_ScheduleGrossLabel
            '
            Me.LabelGroupHeader_ScheduleGrossLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_ScheduleGrossLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_ScheduleGrossLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_ScheduleGrossLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_ScheduleGrossLabel.CanGrow = False
            Me.LabelGroupHeader_ScheduleGrossLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_ScheduleGrossLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_ScheduleGrossLabel.LocationFloat = New DevExpress.Utils.PointFloat(887.7086!, 15.625!)
            Me.LabelGroupHeader_ScheduleGrossLabel.Name = "LabelGroupHeader_ScheduleGrossLabel"
            Me.LabelGroupHeader_ScheduleGrossLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_ScheduleGrossLabel.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.LabelGroupHeader_ScheduleGrossLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_ScheduleGrossLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_ScheduleGrossLabel.Text = "Schedule Gross"
            Me.LabelGroupHeader_ScheduleGrossLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeader_InvoiceGrossLabel
            '
            Me.LabelGroupHeader_InvoiceGrossLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_InvoiceGrossLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_InvoiceGrossLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_InvoiceGrossLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_InvoiceGrossLabel.CanGrow = False
            Me.LabelGroupHeader_InvoiceGrossLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_InvoiceGrossLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_InvoiceGrossLabel.LocationFloat = New DevExpress.Utils.PointFloat(776.6667!, 15.625!)
            Me.LabelGroupHeader_InvoiceGrossLabel.Name = "LabelGroupHeader_InvoiceGrossLabel"
            Me.LabelGroupHeader_InvoiceGrossLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_InvoiceGrossLabel.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.LabelGroupHeader_InvoiceGrossLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_InvoiceGrossLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_InvoiceGrossLabel.Text = "Invoice Gross"
            Me.LabelGroupHeader_InvoiceGrossLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeader_StatusLabel
            '
            Me.LabelGroupHeader_StatusLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_StatusLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_StatusLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_StatusLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_StatusLabel.CanGrow = False
            Me.LabelGroupHeader_StatusLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_StatusLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_StatusLabel.LocationFloat = New DevExpress.Utils.PointFloat(663.1251!, 15.625!)
            Me.LabelGroupHeader_StatusLabel.Name = "LabelGroupHeader_StatusLabel"
            Me.LabelGroupHeader_StatusLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_StatusLabel.SizeF = New System.Drawing.SizeF(113.5416!, 17.00001!)
            Me.LabelGroupHeader_StatusLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_StatusLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_StatusLabel.Text = "Status"
            Me.LabelGroupHeader_StatusLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_InvoiceLabel
            '
            Me.LabelGroupHeader_InvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_InvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_InvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_InvoiceLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_InvoiceLabel.CanGrow = False
            Me.LabelGroupHeader_InvoiceLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_InvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_InvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(575.2086!, 15.625!)
            Me.LabelGroupHeader_InvoiceLabel.Name = "LabelGroupHeader_InvoiceLabel"
            Me.LabelGroupHeader_InvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_InvoiceLabel.SizeF = New System.Drawing.SizeF(87.91656!, 17.00001!)
            Me.LabelGroupHeader_InvoiceLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_InvoiceLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_InvoiceLabel.Text = "Invoice#"
            Me.LabelGroupHeader_InvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_MediaLabel
            '
            Me.LabelGroupHeader_MediaLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_MediaLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_MediaLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_MediaLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_MediaLabel.CanGrow = False
            Me.LabelGroupHeader_MediaLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_MediaLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_MediaLabel.LocationFloat = New DevExpress.Utils.PointFloat(532.5003!, 15.625!)
            Me.LabelGroupHeader_MediaLabel.Name = "LabelGroupHeader_MediaLabel"
            Me.LabelGroupHeader_MediaLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_MediaLabel.SizeF = New System.Drawing.SizeF(42.70831!, 17.00001!)
            Me.LabelGroupHeader_MediaLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_MediaLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_MediaLabel.Text = "Media"
            Me.LabelGroupHeader_MediaLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_MonthLabel
            '
            Me.LabelGroupHeader_MonthLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_MonthLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_MonthLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_MonthLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_MonthLabel.CanGrow = False
            Me.LabelGroupHeader_MonthLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_MonthLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_MonthLabel.LocationFloat = New DevExpress.Utils.PointFloat(488.1252!, 15.625!)
            Me.LabelGroupHeader_MonthLabel.Name = "LabelGroupHeader_MonthLabel"
            Me.LabelGroupHeader_MonthLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_MonthLabel.SizeF = New System.Drawing.SizeF(44.37512!, 17.00001!)
            Me.LabelGroupHeader_MonthLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_MonthLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_MonthLabel.Text = "Month"
            Me.LabelGroupHeader_MonthLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_OrderLabel
            '
            Me.LabelGroupHeader_OrderLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_OrderLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_OrderLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_OrderLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_OrderLabel.CanGrow = False
            Me.LabelGroupHeader_OrderLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_OrderLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_OrderLabel.LocationFloat = New DevExpress.Utils.PointFloat(371.0419!, 15.625!)
            Me.LabelGroupHeader_OrderLabel.Name = "LabelGroupHeader_OrderLabel"
            Me.LabelGroupHeader_OrderLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_OrderLabel.SizeF = New System.Drawing.SizeF(66.66666!, 17.00001!)
            Me.LabelGroupHeader_OrderLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_OrderLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_OrderLabel.Text = "Order#"
            Me.LabelGroupHeader_OrderLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeader_ClientNameLabel
            '
            Me.LabelGroupHeader_ClientNameLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_ClientNameLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_ClientNameLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_ClientNameLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_ClientNameLabel.CanGrow = False
            Me.LabelGroupHeader_ClientNameLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_ClientNameLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_ClientNameLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 17.00001!)
            Me.LabelGroupHeader_ClientNameLabel.Name = "LabelGroupHeader_ClientNameLabel"
            Me.LabelGroupHeader_ClientNameLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_ClientNameLabel.SizeF = New System.Drawing.SizeF(84.79156!, 17.00001!)
            Me.LabelGroupHeader_ClientNameLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_ClientNameLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_ClientNameLabel.Text = "Client Name:"
            Me.LabelGroupHeader_ClientNameLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_ClientCodeLabel
            '
            Me.LabelGroupHeader_ClientCodeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_ClientCodeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_ClientCodeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_ClientCodeLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_ClientCodeLabel.CanGrow = False
            Me.LabelGroupHeader_ClientCodeLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_ClientCodeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_ClientCodeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelGroupHeader_ClientCodeLabel.Name = "LabelGroupHeader_ClientCodeLabel"
            Me.LabelGroupHeader_ClientCodeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_ClientCodeLabel.SizeF = New System.Drawing.SizeF(85.41666!, 17.00001!)
            Me.LabelGroupHeader_ClientCodeLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_ClientCodeLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_ClientCodeLabel.Text = "Client Code:"
            Me.LabelGroupHeader_ClientCodeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_VendorNameLabel
            '
            Me.LabelGroupHeader_VendorNameLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_VendorNameLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_VendorNameLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_VendorNameLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_VendorNameLabel.CanGrow = False
            Me.LabelGroupHeader_VendorNameLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_VendorNameLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_VendorNameLabel.LocationFloat = New DevExpress.Utils.PointFloat(83.66318!, 15.625!)
            Me.LabelGroupHeader_VendorNameLabel.Name = "LabelGroupHeader_VendorNameLabel"
            Me.LabelGroupHeader_VendorNameLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_VendorNameLabel.SizeF = New System.Drawing.SizeF(264.2535!, 17.00001!)
            Me.LabelGroupHeader_VendorNameLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_VendorNameLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_VendorNameLabel.Text = "Vendor Name"
            Me.LabelGroupHeader_VendorNameLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel20, Me.XrLabel18, Me.XrLabel19})
            Me.ReportFooter.HeightF = 17.00001!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'XrLabel20
            '
            Me.XrLabel20.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel20.BorderColor = System.Drawing.Color.Black
            Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel20.BorderWidth = 1.0!
            Me.XrLabel20.CanGrow = False
            Me.XrLabel20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel20.ForeColor = System.Drawing.Color.Black
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel20.StylePriority.UseFont = False
            Me.XrLabel20.StylePriority.UseTextAlignment = False
            Me.XrLabel20.Text = "Report Totals"
            Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel18
            '
            Me.XrLabel18.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([InvoiceGross])")})
            Me.XrLabel18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(776.6667!, 0!)
            Me.XrLabel18.Multiline = True
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel18.StylePriority.UseFont = False
            Me.XrLabel18.StylePriority.UseTextAlignment = False
            XrSummary1.IgnoreNullValues = True
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            XrSummary1.TreatStringsAsNumerics = False
            Me.XrLabel18.Summary = XrSummary1
            Me.XrLabel18.Text = "XrLabel16"
            Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel18.TextFormatString = "{0:N2}"
            '
            'XrLabel19
            '
            Me.XrLabel19.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([ScheduleGross])")})
            Me.XrLabel19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(887.7086!, 0!)
            Me.XrLabel19.Multiline = True
            Me.XrLabel19.Name = "XrLabel19"
            Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel19.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel19.StylePriority.UseFont = False
            Me.XrLabel19.StylePriority.UseTextAlignment = False
            XrSummary2.IgnoreNullValues = True
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            XrSummary2.TreatStringsAsNumerics = False
            Me.XrLabel19.Summary = XrSummary2
            Me.XrLabel19.Text = "XrLabel17"
            Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel19.TextFormatString = "{0:N2}"
            '
            'LabelGroupHeader_LineLabel
            '
            Me.LabelGroupHeader_LineLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_LineLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_LineLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_LineLabel.BorderWidth = 1.0!
            Me.LabelGroupHeader_LineLabel.CanGrow = False
            Me.LabelGroupHeader_LineLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_LineLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_LineLabel.LocationFloat = New DevExpress.Utils.PointFloat(437.7085!, 15.625!)
            Me.LabelGroupHeader_LineLabel.Name = "LabelGroupHeader_LineLabel"
            Me.LabelGroupHeader_LineLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_LineLabel.SizeF = New System.Drawing.SizeF(39.58331!, 17.00001!)
            Me.LabelGroupHeader_LineLabel.StylePriority.UseFont = False
            Me.LabelGroupHeader_LineLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_LineLabel.Text = "Line#"
            Me.LabelGroupHeader_LineLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader2
            '
            Me.GroupHeader2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeader_LineLabel, Me.LabelGroupHeader_ScheduleGrossLabel, Me.LabelGroupHeader_InvoiceGrossLabel, Me.LabelGroupHeader_StatusLabel, Me.LabelGroupHeader_InvoiceLabel, Me.LabelGroupHeader_MediaLabel, Me.LabelGroupHeader_MonthLabel, Me.LabelGroupHeader_OrderLabel, Me.LabelGroupHeader_VendorNameLabel, Me.LabelGroupHeaderStation_ClientLabel})
            Me.GroupHeader2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader2.HeightF = 32.62501!
            Me.GroupHeader2.KeepTogether = True
            Me.GroupHeader2.Name = "GroupHeader2"
            '
            'GroupFooter2
            '
            Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel13, Me.XrLabel12, Me.XrLabel7, Me.XrLabel5})
            Me.GroupFooter2.HeightF = 34.00002!
            Me.GroupFooter2.Name = "GroupFooter2"
            '
            'XrLabel13
            '
            Me.XrLabel13.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel13.BorderColor = System.Drawing.Color.Black
            Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel13.BorderWidth = 1.0!
            Me.XrLabel13.CanGrow = False
            Me.XrLabel13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel13.ForeColor = System.Drawing.Color.Black
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(61.70832!, 0!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(91.00011!, 17.00001!)
            Me.XrLabel13.StylePriority.UseFont = False
            Me.XrLabel13.StylePriority.UseTextAlignment = False
            Me.XrLabel13.Text = "Totals"
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel12
            '
            Me.XrLabel12.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VendorCode]")})
            Me.XrLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabel12.Multiline = True
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(61.08322!, 17.0!)
            Me.XrLabel12.StylePriority.UseFont = False
            Me.XrLabel12.Text = "LabelDetailVendorCode"
            '
            'XrLabel7
            '
            Me.XrLabel7.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([ScheduleGross])")})
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(888.3336!, 0!)
            Me.XrLabel7.Multiline = True
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel7.StylePriority.UseFont = False
            Me.XrLabel7.StylePriority.UseTextAlignment = False
            XrSummary3.IgnoreNullValues = True
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            XrSummary3.TreatStringsAsNumerics = False
            Me.XrLabel7.Summary = XrSummary3
            Me.XrLabel7.Text = "XrLabel17"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel7.TextFormatString = "{0:N2}"
            '
            'XrLabel5
            '
            Me.XrLabel5.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([InvoiceGross])")})
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(777.2919!, 0!)
            Me.XrLabel5.Multiline = True
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.StylePriority.UseTextAlignment = False
            XrSummary4.IgnoreNullValues = True
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            XrSummary4.TreatStringsAsNumerics = False
            Me.XrLabel5.Summary = XrSummary4
            Me.XrLabel5.Text = "XrLabel16"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabel5.TextFormatString = "{0:N2}"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceSummary)
            '
            'GroupHeaderBand1
            '
            Me.GroupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel23, Me.XrLabel24, Me.XrLabel25, Me.XrLabel26, Me.XrLabel14, Me.XrLabel15, Me.XrLabel21, Me.XrLabel22, Me.XrLabel4, Me.XrLabel2, Me.LabelGroupHeader_ClientNameLabel, Me.LabelGroupHeader_ClientCodeLabel})
            Me.GroupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CDP", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderBand1.HeightF = 34.00002!
            Me.GroupHeaderBand1.KeepTogether = True
            Me.GroupHeaderBand1.Level = 1
            Me.GroupHeaderBand1.Name = "GroupHeaderBand1"
            Me.GroupHeaderBand1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry
            '
            'XrLabel14
            '
            Me.XrLabel14.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel14.BorderColor = System.Drawing.Color.Black
            Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel14.BorderWidth = 1.0!
            Me.XrLabel14.CanGrow = False
            Me.XrLabel14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel14.ForeColor = System.Drawing.Color.Black
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(330.0003!, 0!)
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(97.29156!, 17.00001!)
            Me.XrLabel14.StylePriority.UseFont = False
            Me.XrLabel14.StylePriority.UseTextAlignment = False
            Me.XrLabel14.Text = "Division Code:"
            Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel15
            '
            Me.XrLabel15.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel15.BorderColor = System.Drawing.Color.Black
            Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel15.BorderWidth = 1.0!
            Me.XrLabel15.CanGrow = False
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel15.ForeColor = System.Drawing.Color.Black
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(330.0003!, 17.00001!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(97.29156!, 17.00001!)
            Me.XrLabel15.StylePriority.UseFont = False
            Me.XrLabel15.StylePriority.UseTextAlignment = False
            Me.XrLabel15.Text = "Division Name:"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel21
            '
            Me.XrLabel21.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DivisionCode]")})
            Me.XrLabel21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(427.2919!, 0!)
            Me.XrLabel21.Multiline = True
            Me.XrLabel21.Name = "XrLabel21"
            Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel21.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel21.StylePriority.UseFont = False
            Me.XrLabel21.Text = "XrLabel2"
            '
            'XrLabel22
            '
            Me.XrLabel22.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DivisionName]")})
            Me.XrLabel22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(427.2919!, 17.00001!)
            Me.XrLabel22.Multiline = True
            Me.XrLabel22.Name = "XrLabel22"
            Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel22.SizeF = New System.Drawing.SizeF(225.0!, 17.00001!)
            Me.XrLabel22.StylePriority.UseFont = False
            Me.XrLabel22.Text = "XrLabel4"
            '
            'XrLabel23
            '
            Me.XrLabel23.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel23.BorderColor = System.Drawing.Color.Black
            Me.XrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel23.BorderWidth = 1.0!
            Me.XrLabel23.CanGrow = False
            Me.XrLabel23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel23.ForeColor = System.Drawing.Color.Black
            Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(667.7083!, 0!)
            Me.XrLabel23.Name = "XrLabel23"
            Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel23.SizeF = New System.Drawing.SizeF(97.29156!, 17.00001!)
            Me.XrLabel23.StylePriority.UseFont = False
            Me.XrLabel23.StylePriority.UseTextAlignment = False
            Me.XrLabel23.Text = "Product Code:"
            Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel24
            '
            Me.XrLabel24.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel24.BorderColor = System.Drawing.Color.Black
            Me.XrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel24.BorderWidth = 1.0!
            Me.XrLabel24.CanGrow = False
            Me.XrLabel24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel24.ForeColor = System.Drawing.Color.Black
            Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(667.7083!, 17.00001!)
            Me.XrLabel24.Name = "XrLabel24"
            Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel24.SizeF = New System.Drawing.SizeF(97.29156!, 17.00001!)
            Me.XrLabel24.StylePriority.UseFont = False
            Me.XrLabel24.StylePriority.UseTextAlignment = False
            Me.XrLabel24.Text = "Product Name:"
            Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel25
            '
            Me.XrLabel25.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProductCode]")})
            Me.XrLabel25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(764.9999!, 0!)
            Me.XrLabel25.Multiline = True
            Me.XrLabel25.Name = "XrLabel25"
            Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel25.SizeF = New System.Drawing.SizeF(100.0!, 17.00001!)
            Me.XrLabel25.StylePriority.UseFont = False
            Me.XrLabel25.Text = "XrLabel2"
            '
            'XrLabel26
            '
            Me.XrLabel26.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProductName]")})
            Me.XrLabel26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(764.9999!, 17.00001!)
            Me.XrLabel26.Multiline = True
            Me.XrLabel26.Name = "XrLabel26"
            Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel26.SizeF = New System.Drawing.SizeF(225.0!, 17.00001!)
            Me.XrLabel26.StylePriority.UseFont = False
            Me.XrLabel26.Text = "XrLabel4"
            '
            'BroadcastInvoiceSummaryReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.GroupHeader2, Me.GroupFooter2, Me.GroupHeaderBand1})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 25, 25)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrPictureBoxHeaderLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelGroupHeaderStation_ClientLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailVendorCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_ClientCodeLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_VendorNameLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_OrderLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_ClientNameLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_StatusLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_InvoiceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_MediaLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_MonthLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_ScheduleGrossLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_InvoiceGrossLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_DateRangeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelPageHeader_DateRange As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_LineLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader2 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents GroupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
