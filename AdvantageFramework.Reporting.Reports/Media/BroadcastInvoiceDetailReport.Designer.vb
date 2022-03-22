Namespace Media

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class BroadcastInvoiceDetailReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelInvoiceHeader_ClientName = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrPictureBoxHeaderLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelInvoiceHeader_ClientLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.GroupHeaderInvoice = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelInvoiceHeader_Requester = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_RequesterLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_OrderNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_Invoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_Month = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_WorksheetName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_Media = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_VendorName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_MarketName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_VendorLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_MarketLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_OrderLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_InvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_MonthLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_WorksheetLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_MediaTypeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_ProductName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_DivisionName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_ProductLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInvoiceHeader_DivisionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterInvoice = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.GroupHeaderMonthOfService = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooterMonthOfService = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrSubreport1 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.GroupHeaderOrderNumber = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooterOrderNumber = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Detail.HeightF = 0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_ClientName
            '
            Me.LabelInvoiceHeader_ClientName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ClientName]")})
            Me.LabelInvoiceHeader_ClientName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_ClientName.LocationFloat = New DevExpress.Utils.PointFloat(73.87518!, 0!)
            Me.LabelInvoiceHeader_ClientName.Multiline = True
            Me.LabelInvoiceHeader_ClientName.Name = "LabelInvoiceHeader_ClientName"
            Me.LabelInvoiceHeader_ClientName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_ClientName.SizeF = New System.Drawing.SizeF(312.0384!, 17.00001!)
            Me.LabelInvoiceHeader_ClientName.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_ClientName.Text = "LabelInvoiceHeader_ClientName"
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
            Me.LabelPageHeader_ReportTitle.Text = "Broadcast Invoice Detail"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pageInfo2, Me.XrPageInfo1})
            Me.PageFooter.HeightF = 33.33!
            Me.PageFooter.Name = "PageFooter"
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_ReportTitle})
            Me.PageHeader.HeightF = 54.5!
            Me.PageHeader.Name = "PageHeader"
            '
            'LabelInvoiceHeader_ClientLabel
            '
            Me.LabelInvoiceHeader_ClientLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_ClientLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_ClientLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_ClientLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_ClientLabel.CanGrow = False
            Me.LabelInvoiceHeader_ClientLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_ClientLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_ClientLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelInvoiceHeader_ClientLabel.Name = "LabelInvoiceHeader_ClientLabel"
            Me.LabelInvoiceHeader_ClientLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_ClientLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_ClientLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_ClientLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_ClientLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_ClientLabel.Text = "Client:"
            Me.LabelInvoiceHeader_ClientLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportFooter
            '
            Me.ReportFooter.HeightF = 17.00001!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeaderInvoice
            '
            Me.GroupHeaderInvoice.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderInvoice.HeightF = 0!
            Me.GroupHeaderInvoice.Level = 2
            Me.GroupHeaderInvoice.Name = "GroupHeaderInvoice"
            '
            'LabelInvoiceHeader_Requester
            '
            Me.LabelInvoiceHeader_Requester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_Requester.LocationFloat = New DevExpress.Utils.PointFloat(886.5837!, 0.000009536743!)
            Me.LabelInvoiceHeader_Requester.Multiline = True
            Me.LabelInvoiceHeader_Requester.Name = "LabelInvoiceHeader_Requester"
            Me.LabelInvoiceHeader_Requester.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_Requester.SizeF = New System.Drawing.SizeF(113.4163!, 17.00001!)
            Me.LabelInvoiceHeader_Requester.StylePriority.UseFont = False
            '
            'LabelInvoiceHeader_RequesterLabel
            '
            Me.LabelInvoiceHeader_RequesterLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_RequesterLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_RequesterLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_RequesterLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_RequesterLabel.CanGrow = False
            Me.LabelInvoiceHeader_RequesterLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_RequesterLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_RequesterLabel.LocationFloat = New DevExpress.Utils.PointFloat(812.7087!, 0.000009536743!)
            Me.LabelInvoiceHeader_RequesterLabel.Name = "LabelInvoiceHeader_RequesterLabel"
            Me.LabelInvoiceHeader_RequesterLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_RequesterLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_RequesterLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_RequesterLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_RequesterLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_RequesterLabel.Text = "Requester:"
            Me.LabelInvoiceHeader_RequesterLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_OrderNumber
            '
            Me.LabelInvoiceHeader_OrderNumber.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OrderNumber]")})
            Me.LabelInvoiceHeader_OrderNumber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_OrderNumber.LocationFloat = New DevExpress.Utils.PointFloat(483.875!, 67.99998!)
            Me.LabelInvoiceHeader_OrderNumber.Multiline = True
            Me.LabelInvoiceHeader_OrderNumber.Name = "LabelInvoiceHeader_OrderNumber"
            Me.LabelInvoiceHeader_OrderNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_OrderNumber.SizeF = New System.Drawing.SizeF(303.7054!, 17.00001!)
            Me.LabelInvoiceHeader_OrderNumber.StylePriority.UseFont = False
            '
            'LabelInvoiceHeader_Invoice
            '
            Me.LabelInvoiceHeader_Invoice.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InvoiceNumber]")})
            Me.LabelInvoiceHeader_Invoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_Invoice.LocationFloat = New DevExpress.Utils.PointFloat(483.875!, 50.99996!)
            Me.LabelInvoiceHeader_Invoice.Multiline = True
            Me.LabelInvoiceHeader_Invoice.Name = "LabelInvoiceHeader_Invoice"
            Me.LabelInvoiceHeader_Invoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_Invoice.SizeF = New System.Drawing.SizeF(303.7054!, 17.00001!)
            Me.LabelInvoiceHeader_Invoice.StylePriority.UseFont = False
            '
            'LabelInvoiceHeader_Month
            '
            Me.LabelInvoiceHeader_Month.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MonthOfService]")})
            Me.LabelInvoiceHeader_Month.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_Month.LocationFloat = New DevExpress.Utils.PointFloat(483.875!, 34.00004!)
            Me.LabelInvoiceHeader_Month.Multiline = True
            Me.LabelInvoiceHeader_Month.Name = "LabelInvoiceHeader_Month"
            Me.LabelInvoiceHeader_Month.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_Month.SizeF = New System.Drawing.SizeF(303.7054!, 17.00001!)
            Me.LabelInvoiceHeader_Month.StylePriority.UseFont = False
            '
            'LabelInvoiceHeader_WorksheetName
            '
            Me.LabelInvoiceHeader_WorksheetName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[WorksheetName]")})
            Me.LabelInvoiceHeader_WorksheetName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_WorksheetName.LocationFloat = New DevExpress.Utils.PointFloat(483.875!, 17.00002!)
            Me.LabelInvoiceHeader_WorksheetName.Multiline = True
            Me.LabelInvoiceHeader_WorksheetName.Name = "LabelInvoiceHeader_WorksheetName"
            Me.LabelInvoiceHeader_WorksheetName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_WorksheetName.SizeF = New System.Drawing.SizeF(303.7054!, 17.00001!)
            Me.LabelInvoiceHeader_WorksheetName.StylePriority.UseFont = False
            '
            'LabelInvoiceHeader_Media
            '
            Me.LabelInvoiceHeader_Media.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Media]")})
            Me.LabelInvoiceHeader_Media.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_Media.LocationFloat = New DevExpress.Utils.PointFloat(483.875!, 0!)
            Me.LabelInvoiceHeader_Media.Multiline = True
            Me.LabelInvoiceHeader_Media.Name = "LabelInvoiceHeader_Media"
            Me.LabelInvoiceHeader_Media.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_Media.SizeF = New System.Drawing.SizeF(303.7054!, 17.00001!)
            Me.LabelInvoiceHeader_Media.StylePriority.UseFont = False
            '
            'LabelInvoiceHeader_VendorName
            '
            Me.LabelInvoiceHeader_VendorName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VendorName]")})
            Me.LabelInvoiceHeader_VendorName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_VendorName.LocationFloat = New DevExpress.Utils.PointFloat(73.87518!, 67.99998!)
            Me.LabelInvoiceHeader_VendorName.Multiline = True
            Me.LabelInvoiceHeader_VendorName.Name = "LabelInvoiceHeader_VendorName"
            Me.LabelInvoiceHeader_VendorName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_VendorName.SizeF = New System.Drawing.SizeF(312.0384!, 17.00001!)
            Me.LabelInvoiceHeader_VendorName.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_VendorName.Text = "LabelInvoiceHeader_VendorName"
            '
            'LabelInvoiceHeader_MarketName
            '
            Me.LabelInvoiceHeader_MarketName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Market]")})
            Me.LabelInvoiceHeader_MarketName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_MarketName.LocationFloat = New DevExpress.Utils.PointFloat(73.87518!, 50.99996!)
            Me.LabelInvoiceHeader_MarketName.Multiline = True
            Me.LabelInvoiceHeader_MarketName.Name = "LabelInvoiceHeader_MarketName"
            Me.LabelInvoiceHeader_MarketName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_MarketName.SizeF = New System.Drawing.SizeF(312.0384!, 17.00001!)
            Me.LabelInvoiceHeader_MarketName.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_MarketName.Text = "LabelInvoiceHeader_MarketName"
            '
            'LabelInvoiceHeader_VendorLabel
            '
            Me.LabelInvoiceHeader_VendorLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_VendorLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_VendorLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_VendorLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_VendorLabel.CanGrow = False
            Me.LabelInvoiceHeader_VendorLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_VendorLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_VendorLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 67.99998!)
            Me.LabelInvoiceHeader_VendorLabel.Name = "LabelInvoiceHeader_VendorLabel"
            Me.LabelInvoiceHeader_VendorLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_VendorLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_VendorLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_VendorLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_VendorLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_VendorLabel.Text = "Vendor:"
            Me.LabelInvoiceHeader_VendorLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_MarketLabel
            '
            Me.LabelInvoiceHeader_MarketLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_MarketLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_MarketLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_MarketLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_MarketLabel.CanGrow = False
            Me.LabelInvoiceHeader_MarketLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_MarketLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_MarketLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 50.99996!)
            Me.LabelInvoiceHeader_MarketLabel.Name = "LabelInvoiceHeader_MarketLabel"
            Me.LabelInvoiceHeader_MarketLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_MarketLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_MarketLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_MarketLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_MarketLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_MarketLabel.Text = "Market:"
            Me.LabelInvoiceHeader_MarketLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_OrderLabel
            '
            Me.LabelInvoiceHeader_OrderLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_OrderLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_OrderLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_OrderLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_OrderLabel.CanGrow = False
            Me.LabelInvoiceHeader_OrderLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_OrderLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_OrderLabel.LocationFloat = New DevExpress.Utils.PointFloat(410.0001!, 67.99998!)
            Me.LabelInvoiceHeader_OrderLabel.Name = "LabelInvoiceHeader_OrderLabel"
            Me.LabelInvoiceHeader_OrderLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_OrderLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_OrderLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_OrderLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_OrderLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_OrderLabel.Text = "Order #:"
            Me.LabelInvoiceHeader_OrderLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_InvoiceLabel
            '
            Me.LabelInvoiceHeader_InvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_InvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_InvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_InvoiceLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_InvoiceLabel.CanGrow = False
            Me.LabelInvoiceHeader_InvoiceLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_InvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_InvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(410.0001!, 50.99996!)
            Me.LabelInvoiceHeader_InvoiceLabel.Name = "LabelInvoiceHeader_InvoiceLabel"
            Me.LabelInvoiceHeader_InvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_InvoiceLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_InvoiceLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_InvoiceLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_InvoiceLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_InvoiceLabel.Text = "Invoice #:"
            Me.LabelInvoiceHeader_InvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_MonthLabel
            '
            Me.LabelInvoiceHeader_MonthLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_MonthLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_MonthLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_MonthLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_MonthLabel.CanGrow = False
            Me.LabelInvoiceHeader_MonthLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_MonthLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_MonthLabel.LocationFloat = New DevExpress.Utils.PointFloat(410.0001!, 34.00004!)
            Me.LabelInvoiceHeader_MonthLabel.Name = "LabelInvoiceHeader_MonthLabel"
            Me.LabelInvoiceHeader_MonthLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_MonthLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_MonthLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_MonthLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_MonthLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_MonthLabel.Text = "Month:"
            Me.LabelInvoiceHeader_MonthLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_WorksheetLabel
            '
            Me.LabelInvoiceHeader_WorksheetLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_WorksheetLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_WorksheetLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_WorksheetLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_WorksheetLabel.CanGrow = False
            Me.LabelInvoiceHeader_WorksheetLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_WorksheetLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_WorksheetLabel.LocationFloat = New DevExpress.Utils.PointFloat(410.0001!, 17.00002!)
            Me.LabelInvoiceHeader_WorksheetLabel.Name = "LabelInvoiceHeader_WorksheetLabel"
            Me.LabelInvoiceHeader_WorksheetLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_WorksheetLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_WorksheetLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_WorksheetLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_WorksheetLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_WorksheetLabel.Text = "Worksheet:"
            Me.LabelInvoiceHeader_WorksheetLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_MediaTypeLabel
            '
            Me.LabelInvoiceHeader_MediaTypeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_MediaTypeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_MediaTypeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_MediaTypeLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_MediaTypeLabel.CanGrow = False
            Me.LabelInvoiceHeader_MediaTypeLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_MediaTypeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_MediaTypeLabel.LocationFloat = New DevExpress.Utils.PointFloat(410.0001!, 0!)
            Me.LabelInvoiceHeader_MediaTypeLabel.Name = "LabelInvoiceHeader_MediaTypeLabel"
            Me.LabelInvoiceHeader_MediaTypeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_MediaTypeLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_MediaTypeLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_MediaTypeLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_MediaTypeLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_MediaTypeLabel.Text = "Media Type:"
            Me.LabelInvoiceHeader_MediaTypeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_ProductName
            '
            Me.LabelInvoiceHeader_ProductName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProductName]")})
            Me.LabelInvoiceHeader_ProductName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_ProductName.LocationFloat = New DevExpress.Utils.PointFloat(73.87518!, 34.00004!)
            Me.LabelInvoiceHeader_ProductName.Multiline = True
            Me.LabelInvoiceHeader_ProductName.Name = "LabelInvoiceHeader_ProductName"
            Me.LabelInvoiceHeader_ProductName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_ProductName.SizeF = New System.Drawing.SizeF(312.0384!, 17.00001!)
            Me.LabelInvoiceHeader_ProductName.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_ProductName.Text = "LabelInvoiceHeader_ProductName"
            '
            'LabelInvoiceHeader_DivisionName
            '
            Me.LabelInvoiceHeader_DivisionName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DivisionName]")})
            Me.LabelInvoiceHeader_DivisionName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInvoiceHeader_DivisionName.LocationFloat = New DevExpress.Utils.PointFloat(73.87518!, 17.00002!)
            Me.LabelInvoiceHeader_DivisionName.Multiline = True
            Me.LabelInvoiceHeader_DivisionName.Name = "LabelInvoiceHeader_DivisionName"
            Me.LabelInvoiceHeader_DivisionName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_DivisionName.SizeF = New System.Drawing.SizeF(312.0384!, 17.00001!)
            Me.LabelInvoiceHeader_DivisionName.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_DivisionName.Text = "LabelInvoiceHeader_DivisionName"
            '
            'LabelInvoiceHeader_ProductLabel
            '
            Me.LabelInvoiceHeader_ProductLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_ProductLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_ProductLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_ProductLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_ProductLabel.CanGrow = False
            Me.LabelInvoiceHeader_ProductLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_ProductLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_ProductLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 34.00004!)
            Me.LabelInvoiceHeader_ProductLabel.Name = "LabelInvoiceHeader_ProductLabel"
            Me.LabelInvoiceHeader_ProductLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_ProductLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_ProductLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_ProductLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_ProductLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_ProductLabel.Text = "Product:"
            Me.LabelInvoiceHeader_ProductLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInvoiceHeader_DivisionLabel
            '
            Me.LabelInvoiceHeader_DivisionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelInvoiceHeader_DivisionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_DivisionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelInvoiceHeader_DivisionLabel.BorderWidth = 1.0!
            Me.LabelInvoiceHeader_DivisionLabel.CanGrow = False
            Me.LabelInvoiceHeader_DivisionLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelInvoiceHeader_DivisionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelInvoiceHeader_DivisionLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 17.00002!)
            Me.LabelInvoiceHeader_DivisionLabel.Name = "LabelInvoiceHeader_DivisionLabel"
            Me.LabelInvoiceHeader_DivisionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelInvoiceHeader_DivisionLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelInvoiceHeader_DivisionLabel.SizeF = New System.Drawing.SizeF(73.87505!, 17.0!)
            Me.LabelInvoiceHeader_DivisionLabel.StylePriority.UseFont = False
            Me.LabelInvoiceHeader_DivisionLabel.StylePriority.UsePadding = False
            Me.LabelInvoiceHeader_DivisionLabel.Text = "Division:"
            Me.LabelInvoiceHeader_DivisionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooterInvoice
            '
            Me.GroupFooterInvoice.Expanded = False
            Me.GroupFooterInvoice.HeightF = 0!
            Me.GroupFooterInvoice.Level = 2
            Me.GroupFooterInvoice.Name = "GroupFooterInvoice"
            Me.GroupFooterInvoice.Visible = False
            '
            'GroupHeaderMonthOfService
            '
            Me.GroupHeaderMonthOfService.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelInvoiceHeader_Requester, Me.LabelInvoiceHeader_RequesterLabel, Me.LabelInvoiceHeader_OrderNumber, Me.LabelInvoiceHeader_Invoice, Me.LabelInvoiceHeader_Month, Me.LabelInvoiceHeader_WorksheetName, Me.LabelInvoiceHeader_Media, Me.LabelInvoiceHeader_VendorName, Me.LabelInvoiceHeader_MarketName, Me.LabelInvoiceHeader_VendorLabel, Me.LabelInvoiceHeader_MarketLabel, Me.LabelInvoiceHeader_OrderLabel, Me.LabelInvoiceHeader_InvoiceLabel, Me.LabelInvoiceHeader_MonthLabel, Me.LabelInvoiceHeader_WorksheetLabel, Me.LabelInvoiceHeader_MediaTypeLabel, Me.LabelInvoiceHeader_ProductName, Me.LabelInvoiceHeader_DivisionName, Me.LabelInvoiceHeader_ProductLabel, Me.LabelInvoiceHeader_DivisionLabel, Me.LabelInvoiceHeader_ClientName, Me.LabelInvoiceHeader_ClientLabel})
            Me.GroupHeaderMonthOfService.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("MonthOfService", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderMonthOfService.HeightF = 91.87495!
            Me.GroupHeaderMonthOfService.Name = "GroupHeaderMonthOfService"
            Me.GroupHeaderMonthOfService.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry
            '
            'GroupFooterMonthOfService
            '
            Me.GroupFooterMonthOfService.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreport1})
            Me.GroupFooterMonthOfService.HeightF = 23.0!
            Me.GroupFooterMonthOfService.Name = "GroupFooterMonthOfService"
            '
            'XrSubreport1
            '
            Me.XrSubreport1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrSubreport1.Name = "XrSubreport1"
            Me.XrSubreport1.ReportSource = New AdvantageFramework.Reporting.Reports.Media.BroadcastInvoiceDetailSubReport()
            Me.XrSubreport1.SizeF = New System.Drawing.SizeF(1000.0!, 23.0!)
            '
            'GroupHeaderOrderNumber
            '
            Me.GroupHeaderOrderNumber.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OrderNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderOrderNumber.HeightF = 0!
            Me.GroupHeaderOrderNumber.Level = 1
            Me.GroupHeaderOrderNumber.Name = "GroupHeaderOrderNumber"
            '
            'GroupFooterOrderNumber
            '
            Me.GroupFooterOrderNumber.Expanded = False
            Me.GroupFooterOrderNumber.HeightF = 0!
            Me.GroupFooterOrderNumber.Level = 1
            Me.GroupFooterOrderNumber.Name = "GroupFooterOrderNumber"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetail)
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
            'BroadcastInvoiceDetailReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.GroupHeaderInvoice, Me.GroupFooterInvoice, Me.GroupHeaderOrderNumber, Me.GroupHeaderMonthOfService, Me.GroupFooterMonthOfService, Me.GroupFooterOrderNumber})
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
        Friend WithEvents LabelInvoiceHeader_ClientName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelInvoiceHeader_ClientLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderInvoice As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterInvoice As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelInvoiceHeader_ProductName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_DivisionName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_ProductLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_DivisionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_VendorLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_MarketLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_OrderLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_InvoiceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_MonthLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_WorksheetLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_MediaTypeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_VendorName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_MarketName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_OrderNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_Invoice As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_Month As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_WorksheetName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_Media As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInvoiceHeader_Requester As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelInvoiceHeader_RequesterLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderMonthOfService As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterMonthOfService As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupHeaderOrderNumber As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterOrderNumber As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrSubreport1 As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    End Class

End Namespace
