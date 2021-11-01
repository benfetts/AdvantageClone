Namespace Invoices

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class CoverSheet
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
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabelInvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrPictureBoxHeaderLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelLocationHeaderInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineHeaderLine = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelDescriptionHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDateData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelDateHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineInvoiceHeaderLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineInvoiceHeaderLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelTotalHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrPictureBoxFooterLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.XrLabelLocationFooterInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelSubTotalDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelSubTotalStatement = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelSubTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineTotalAmount = New DevExpress.XtraReports.UI.XRLine()
            Me.TotalJobPhrase = New DevExpress.XtraReports.UI.CalculatedField()
            Me.HoursAndQuantity = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupHeaderInvoiceTypes = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelInvoiceClassification = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterInvoiceTypes = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLineFooter2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineFooter1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelGrandTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGrandTotalHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.GroupHeaderClient = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooterClient = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelInvoiceAmount, Me.XrLabelInvoiceDescription, Me.XrLabelInvoiceNumber, Me.XrLabelInvoiceDate})
            Me.Detail.HeightF = 19.0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceAmount
            '
            Me.XrLabelInvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount", "{0:n2}")})
            Me.XrLabelInvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(625.0002!, 0!)
            Me.XrLabelInvoiceAmount.Name = "XrLabelInvoiceAmount"
            Me.XrLabelInvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceAmount.SizeF = New System.Drawing.SizeF(124.9999!, 17.0!)
            Me.XrLabelInvoiceAmount.StylePriority.UseTextAlignment = False
            Me.XrLabelInvoiceAmount.Text = "XrLabelInvoiceAmount"
            Me.XrLabelInvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelInvoiceDescription
            '
            Me.XrLabelInvoiceDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDescription")})
            Me.XrLabelInvoiceDescription.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 0!)
            Me.XrLabelInvoiceDescription.Name = "XrLabelInvoiceDescription"
            Me.XrLabelInvoiceDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceDescription.SizeF = New System.Drawing.SizeF(425.0!, 17.0!)
            Me.XrLabelInvoiceDescription.Text = "XrLabelInvoiceDescription"
            '
            'XrLabelInvoiceNumber
            '
            Me.XrLabelInvoiceNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FullInvoiceNumber")})
            Me.XrLabelInvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0!)
            Me.XrLabelInvoiceNumber.Name = "XrLabelInvoiceNumber"
            Me.XrLabelInvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceNumber.SizeF = New System.Drawing.SizeF(100.0!, 17.0!)
            Me.XrLabelInvoiceNumber.Text = "XrLabelInvoiceNumber"
            '
            'XrLabelInvoiceDate
            '
            Me.XrLabelInvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.XrLabelInvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabelInvoiceDate.Name = "XrLabelInvoiceDate"
            Me.XrLabelInvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceDate.SizeF = New System.Drawing.SizeF(100.0!, 17.0!)
            Me.XrLabelInvoiceDate.Text = "XrLabelInvoiceDate"
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBoxHeaderLogo, Me.XrLine1, Me.XrLabelLocationHeaderInfo, Me.XrLabelTitle, Me.XrLineHeaderLine})
            Me.PageHeader.HeightF = 214.0!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrPictureBoxHeaderLogo
            '
            Me.XrPictureBoxHeaderLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
            Me.XrPictureBoxHeaderLogo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrPictureBoxHeaderLogo.Name = "XrPictureBoxHeaderLogo"
            Me.XrPictureBoxHeaderLogo.SizeF = New System.Drawing.SizeF(750.0!, 150.0!)
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 1.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Black
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 168.9685!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            Me.XrLine1.StylePriority.UseBorderWidth = False
            '
            'XrLabelLocationHeaderInfo
            '
            Me.XrLabelLocationHeaderInfo.BorderColor = System.Drawing.Color.Black
            Me.XrLabelLocationHeaderInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelLocationHeaderInfo.BorderWidth = 1.0!
            Me.XrLabelLocationHeaderInfo.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelLocationHeaderInfo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 150.0!)
            Me.XrLabelLocationHeaderInfo.Name = "XrLabelLocationHeaderInfo"
            Me.XrLabelLocationHeaderInfo.SizeF = New System.Drawing.SizeF(750.0001!, 17.0!)
            Me.XrLabelLocationHeaderInfo.StylePriority.UseBackColor = False
            Me.XrLabelLocationHeaderInfo.StylePriority.UsePadding = False
            Me.XrLabelLocationHeaderInfo.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0}"
            Me.XrLabelLocationHeaderInfo.Summary = XrSummary1
            Me.XrLabelLocationHeaderInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabelTitle
            '
            Me.XrLabelTitle.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTitle.BorderWidth = 1.0!
            Me.XrLabelTitle.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 176.9685!)
            Me.XrLabelTitle.Name = "XrLabelTitle"
            Me.XrLabelTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelTitle.SizeF = New System.Drawing.SizeF(750.0!, 27.0!)
            Me.XrLabelTitle.StylePriority.UseBackColor = False
            Me.XrLabelTitle.StylePriority.UseFont = False
            Me.XrLabelTitle.StylePriority.UsePadding = False
            Me.XrLabelTitle.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0}"
            Me.XrLabelTitle.Summary = XrSummary2
            Me.XrLabelTitle.Text = "Invoice Cover Sheet"
            Me.XrLabelTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLineHeaderLine
            '
            Me.XrLineHeaderLine.BorderColor = System.Drawing.Color.Black
            Me.XrLineHeaderLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineHeaderLine.BorderWidth = 1.0!
            Me.XrLineHeaderLine.ForeColor = System.Drawing.Color.Black
            Me.XrLineHeaderLine.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 207.9685!)
            Me.XrLineHeaderLine.Name = "XrLineHeaderLine"
            Me.XrLineHeaderLine.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            Me.XrLineHeaderLine.StylePriority.UseBorderWidth = False
            '
            'XrLabelDescriptionHeader
            '
            Me.XrLabelDescriptionHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelDescriptionHeader.LocationFloat = New DevExpress.Utils.PointFloat(203.0316!, 155.0834!)
            Me.XrLabelDescriptionHeader.Name = "XrLabelDescriptionHeader"
            Me.XrLabelDescriptionHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDescriptionHeader.SizeF = New System.Drawing.SizeF(421.9684!, 33.0!)
            Me.XrLabelDescriptionHeader.StylePriority.UseFont = False
            Me.XrLabelDescriptionHeader.StylePriority.UseTextAlignment = False
            Me.XrLabelDescriptionHeader.Text = "Description"
            Me.XrLabelDescriptionHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelInvoiceHeader
            '
            Me.XrLabelInvoiceHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceHeader.LocationFloat = New DevExpress.Utils.PointFloat(102.0316!, 155.0833!)
            Me.XrLabelInvoiceHeader.Name = "XrLabelInvoiceHeader"
            Me.XrLabelInvoiceHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceHeader.SizeF = New System.Drawing.SizeF(101.0!, 33.0!)
            Me.XrLabelInvoiceHeader.StylePriority.UseFont = False
            Me.XrLabelInvoiceHeader.StylePriority.UseTextAlignment = False
            Me.XrLabelInvoiceHeader.Text = "Invoice"
            Me.XrLabelInvoiceHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelAddress
            '
            Me.XrLabelAddress.BorderColor = System.Drawing.Color.Black
            Me.XrLabelAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelAddress.BorderWidth = 1.0!
            Me.XrLabelAddress.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Address")})
            Me.XrLabelAddress.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelAddress.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabelAddress.Multiline = True
            Me.XrLabelAddress.Name = "XrLabelAddress"
            Me.XrLabelAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelAddress.SizeF = New System.Drawing.SizeF(563.9051!, 152.0833!)
            Me.XrLabelAddress.StylePriority.UseBackColor = False
            Me.XrLabelAddress.StylePriority.UsePadding = False
            XrSummary3.FormatString = "{0}"
            Me.XrLabelAddress.Summary = XrSummary3
            Me.XrLabelAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceDateData
            '
            Me.XrLabelInvoiceDateData.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDateData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceDateData.BorderWidth = 1.0!
            Me.XrLabelInvoiceDateData.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelInvoiceDateData.LocationFloat = New DevExpress.Utils.PointFloat(638.8293!, 0!)
            Me.XrLabelInvoiceDateData.Name = "XrLabelInvoiceDateData"
            Me.XrLabelInvoiceDateData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceDateData.SizeF = New System.Drawing.SizeF(111.1708!, 16.99998!)
            Me.XrLabelInvoiceDateData.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceDateData.StylePriority.UsePadding = False
            XrSummary4.FormatString = "{0:d}"
            Me.XrLabelInvoiceDateData.Summary = XrSummary4
            Me.XrLabelInvoiceDateData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceDateLabel
            '
            Me.XrLabelInvoiceDateLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceDateLabel.BorderWidth = 1.0!
            Me.XrLabelInvoiceDateLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceDateLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(563.9051!, 0!)
            Me.XrLabelInvoiceDateLabel.Name = "XrLabelInvoiceDateLabel"
            Me.XrLabelInvoiceDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceDateLabel.SizeF = New System.Drawing.SizeF(74.92413!, 17.0!)
            Me.XrLabelInvoiceDateLabel.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceDateLabel.StylePriority.UsePadding = False
            Me.XrLabelInvoiceDateLabel.Text = "Date : "
            Me.XrLabelInvoiceDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelDateHeader
            '
            Me.XrLabelDateHeader.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelDateHeader.BorderColor = System.Drawing.Color.Black
            Me.XrLabelDateHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelDateHeader.BorderWidth = 1.0!
            Me.XrLabelDateHeader.CanGrow = False
            Me.XrLabelDateHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelDateHeader.ForeColor = System.Drawing.Color.Black
            Me.XrLabelDateHeader.LocationFloat = New DevExpress.Utils.PointFloat(2.031517!, 155.0833!)
            Me.XrLabelDateHeader.Name = "XrLabelDateHeader"
            Me.XrLabelDateHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDateHeader.SizeF = New System.Drawing.SizeF(100.0!, 33.0!)
            Me.XrLabelDateHeader.StylePriority.UsePadding = False
            Me.XrLabelDateHeader.StylePriority.UseTextAlignment = False
            Me.XrLabelDateHeader.Text = "Date"
            Me.XrLabelDateHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLineInvoiceHeaderLine2
            '
            Me.XrLineInvoiceHeaderLine2.BorderColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineInvoiceHeaderLine2.BorderWidth = 1.0!
            Me.XrLineInvoiceHeaderLine2.ForeColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 188.0833!)
            Me.XrLineInvoiceHeaderLine2.Name = "XrLineInvoiceHeaderLine2"
            Me.XrLineInvoiceHeaderLine2.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            '
            'XrLineInvoiceHeaderLine1
            '
            Me.XrLineInvoiceHeaderLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineInvoiceHeaderLine1.BorderWidth = 1.0!
            Me.XrLineInvoiceHeaderLine1.ForeColor = System.Drawing.Color.Black
            Me.XrLineInvoiceHeaderLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 152.0833!)
            Me.XrLineInvoiceHeaderLine1.Name = "XrLineInvoiceHeaderLine1"
            Me.XrLineInvoiceHeaderLine1.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            '
            'XrLabelTotalHeader
            '
            Me.XrLabelTotalHeader.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelTotalHeader.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTotalHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTotalHeader.BorderWidth = 1.0!
            Me.XrLabelTotalHeader.CanGrow = False
            Me.XrLabelTotalHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalHeader.ForeColor = System.Drawing.Color.Black
            Me.XrLabelTotalHeader.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 155.0834!)
            Me.XrLabelTotalHeader.Name = "XrLabelTotalHeader"
            Me.XrLabelTotalHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelTotalHeader.SizeF = New System.Drawing.SizeF(125.0!, 33.0!)
            Me.XrLabelTotalHeader.StylePriority.UsePadding = False
            Me.XrLabelTotalHeader.StylePriority.UseTextAlignment = False
            Me.XrLabelTotalHeader.Text = "Total"
            Me.XrLabelTotalHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBoxFooterLogo, Me.XrLabelLocationFooterInfo})
            Me.PageFooter.HeightF = 167.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'XrPictureBoxFooterLogo
            '
            Me.XrPictureBoxFooterLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
            Me.XrPictureBoxFooterLogo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrPictureBoxFooterLogo.Name = "XrPictureBoxFooterLogo"
            Me.XrPictureBoxFooterLogo.SizeF = New System.Drawing.SizeF(750.0!, 150.0!)
            '
            'XrLabelLocationFooterInfo
            '
            Me.XrLabelLocationFooterInfo.BorderColor = System.Drawing.Color.Black
            Me.XrLabelLocationFooterInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelLocationFooterInfo.BorderWidth = 1.0!
            Me.XrLabelLocationFooterInfo.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrLabelLocationFooterInfo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 150.0!)
            Me.XrLabelLocationFooterInfo.Name = "XrLabelLocationFooterInfo"
            Me.XrLabelLocationFooterInfo.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            Me.XrLabelLocationFooterInfo.StylePriority.UseBackColor = False
            Me.XrLabelLocationFooterInfo.StylePriority.UsePadding = False
            Me.XrLabelLocationFooterInfo.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0}"
            Me.XrLabelLocationFooterInfo.Summary = XrSummary5
            Me.XrLabelLocationFooterInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabelSubTotalDescription
            '
            Me.XrLabelSubTotalDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceClassification")})
            Me.XrLabelSubTotalDescription.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabelSubTotalDescription.LocationFloat = New DevExpress.Utils.PointFloat(530.0445!, 7.083262!)
            Me.XrLabelSubTotalDescription.Name = "XrLabelSubTotalDescription"
            Me.XrLabelSubTotalDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100.0!)
            Me.XrLabelSubTotalDescription.SizeF = New System.Drawing.SizeF(94.95551!, 16.91669!)
            Me.XrLabelSubTotalDescription.StylePriority.UseFont = False
            Me.XrLabelSubTotalDescription.StylePriority.UsePadding = False
            '
            'XrLabelSubTotalStatement
            '
            Me.XrLabelSubTotalStatement.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelSubTotalStatement.BorderColor = System.Drawing.Color.Black
            Me.XrLabelSubTotalStatement.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelSubTotalStatement.BorderWidth = 1.0!
            Me.XrLabelSubTotalStatement.CanShrink = True
            Me.XrLabelSubTotalStatement.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabelSubTotalStatement.ForeColor = System.Drawing.Color.Black
            Me.XrLabelSubTotalStatement.LocationFloat = New DevExpress.Utils.PointFloat(363.0445!, 7.083262!)
            Me.XrLabelSubTotalStatement.Name = "XrLabelSubTotalStatement"
            Me.XrLabelSubTotalStatement.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelSubTotalStatement.SizeF = New System.Drawing.SizeF(167.0!, 17.0!)
            Me.XrLabelSubTotalStatement.StylePriority.UseFont = False
            Me.XrLabelSubTotalStatement.StylePriority.UseTextAlignment = False
            Me.XrLabelSubTotalStatement.Text = "Sub Total For"
            Me.XrLabelSubTotalStatement.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelSubTotalAmount
            '
            Me.XrLabelSubTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount")})
            Me.XrLabelSubTotalAmount.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabelSubTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 6.999974!)
            Me.XrLabelSubTotalAmount.Name = "XrLabelSubTotalAmount"
            Me.XrLabelSubTotalAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelSubTotalAmount.SizeF = New System.Drawing.SizeF(124.9999!, 17.0!)
            Me.XrLabelSubTotalAmount.StylePriority.UseFont = False
            Me.XrLabelSubTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelSubTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelSubTotalAmount.Summary = XrSummary6
            Me.XrLabelSubTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineTotalAmount
            '
            Me.XrLineTotalAmount.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLineTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 0.9166768!)
            Me.XrLineTotalAmount.Name = "XrLineTotalAmount"
            Me.XrLineTotalAmount.SizeF = New System.Drawing.SizeF(125.0!, 2.083333!)
            '
            'TotalJobPhrase
            '
            Me.TotalJobPhrase.Expression = "Iif([Parameters.HideComponentNumberAndDescription], 'Total for Job:', 'Total for " &
    "Job/Component:')"
            Me.TotalJobPhrase.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.TotalJobPhrase.Name = "TotalJobPhrase"
            '
            'HoursAndQuantity
            '
            Me.HoursAndQuantity.Expression = "Iif([FunctionType]='E', [Hours],[Quantity])"
            Me.HoursAndQuantity.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.HoursAndQuantity.Name = "HoursAndQuantity"
            '
            'GroupHeaderInvoiceTypes
            '
            Me.GroupHeaderInvoiceTypes.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelInvoiceClassification})
            Me.GroupHeaderInvoiceTypes.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InvoiceClassification", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending), New DevExpress.XtraReports.UI.GroupField("SortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderInvoiceTypes.HeightF = 29.16667!
            Me.GroupHeaderInvoiceTypes.Name = "GroupHeaderInvoiceTypes"
            '
            'XrLabelInvoiceClassification
            '
            Me.XrLabelInvoiceClassification.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceClassification")})
            Me.XrLabelInvoiceClassification.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabelInvoiceClassification.LocationFloat = New DevExpress.Utils.PointFloat(0!, 12.24995!)
            Me.XrLabelInvoiceClassification.Name = "XrLabelInvoiceClassification"
            Me.XrLabelInvoiceClassification.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceClassification.SizeF = New System.Drawing.SizeF(203.0316!, 16.91669!)
            Me.XrLabelInvoiceClassification.StylePriority.UseFont = False
            Me.XrLabelInvoiceClassification.StylePriority.UsePadding = False
            '
            'GroupFooterInvoiceTypes
            '
            Me.GroupFooterInvoiceTypes.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelSubTotalAmount, Me.XrLineTotalAmount, Me.XrLabelSubTotalStatement, Me.XrLabelSubTotalDescription})
            Me.GroupFooterInvoiceTypes.HeightF = 27.0!
            Me.GroupFooterInvoiceTypes.Name = "GroupFooterInvoiceTypes"
            '
            'XrLineFooter2
            '
            Me.XrLineFooter2.BorderColor = System.Drawing.Color.Black
            Me.XrLineFooter2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineFooter2.BorderWidth = 1.0!
            Me.XrLineFooter2.ForeColor = System.Drawing.Color.Black
            Me.XrLineFooter2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 41.08332!)
            Me.XrLineFooter2.Name = "XrLineFooter2"
            Me.XrLineFooter2.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            '
            'XrLineFooter1
            '
            Me.XrLineFooter1.BorderColor = System.Drawing.Color.Black
            Me.XrLineFooter1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineFooter1.BorderWidth = 1.0!
            Me.XrLineFooter1.ForeColor = System.Drawing.Color.Black
            Me.XrLineFooter1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.999974!)
            Me.XrLineFooter1.Name = "XrLineFooter1"
            Me.XrLineFooter1.SizeF = New System.Drawing.SizeF(750.0!, 3.0!)
            '
            'XrLabelGrandTotal
            '
            Me.XrLabelGrandTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount")})
            Me.XrLabelGrandTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGrandTotal.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 8.083331!)
            Me.XrLabelGrandTotal.Name = "XrLabelGrandTotal"
            Me.XrLabelGrandTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGrandTotal.SizeF = New System.Drawing.SizeF(125.0!, 33.0!)
            Me.XrLabelGrandTotal.StylePriority.UseFont = False
            Me.XrLabelGrandTotal.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelGrandTotal.Summary = XrSummary7
            Me.XrLabelGrandTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'XrLabelGrandTotalHeader
            '
            Me.XrLabelGrandTotalHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelGrandTotalHeader.LocationFloat = New DevExpress.Utils.PointFloat(363.0445!, 8.083331!)
            Me.XrLabelGrandTotalHeader.Name = "XrLabelGrandTotalHeader"
            Me.XrLabelGrandTotalHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelGrandTotalHeader.SizeF = New System.Drawing.SizeF(261.9555!, 33.0!)
            Me.XrLabelGrandTotalHeader.StylePriority.UseFont = False
            Me.XrLabelGrandTotalHeader.StylePriority.UseTextAlignment = False
            Me.XrLabelGrandTotalHeader.Text = "Total Amount:"
            Me.XrLabelGrandTotalHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '
            'ReportFooter
            '
            Me.ReportFooter.HeightF = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'ReportHeader
            '
            Me.ReportHeader.HeightF = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'GroupHeaderClient
            '
            Me.GroupHeaderClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelAddress, Me.XrLineInvoiceHeaderLine1, Me.XrLineInvoiceHeaderLine2, Me.XrLabelDateHeader, Me.XrLabelInvoiceDateLabel, Me.XrLabelInvoiceDateData, Me.XrLabelTotalHeader, Me.XrLabelInvoiceHeader, Me.XrLabelDescriptionHeader})
            Me.GroupHeaderClient.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderClient.HeightF = 191.0833!
            Me.GroupHeaderClient.Level = 1
            Me.GroupHeaderClient.Name = "GroupHeaderClient"
            Me.GroupHeaderClient.RepeatEveryPage = True
            '
            'GroupFooterClient
            '
            Me.GroupFooterClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLineFooter1, Me.XrLineFooter2, Me.XrLabelGrandTotal, Me.XrLabelGrandTotalHeader})
            Me.GroupFooterClient.HeightF = 44.08332!
            Me.GroupFooterClient.Level = 1
            Me.GroupFooterClient.Name = "GroupFooterClient"
            Me.GroupFooterClient.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.CoverSheet)
            '
            'CoverSheet
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.GroupHeaderInvoiceTypes, Me.GroupFooterInvoiceTypes, Me.ReportFooter, Me.ReportHeader, Me.GroupHeaderClient, Me.GroupFooterClient})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.TotalJobPhrase, Me.HoursAndQuantity})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents XrLineHeaderLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelTitle As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDateData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelAddress As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineInvoiceHeaderLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLineInvoiceHeaderLine2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelTotalHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents TotalJobPhrase As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrLabelDateHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents HoursAndQuantity As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabelSubTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelSubTotalStatement As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelDescriptionHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelSubTotalDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderInvoiceTypes As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterInvoiceTypes As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLineFooter2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLineFooter1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelGrandTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGrandTotalHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents XrLabelInvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderClient As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterClient As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabelInvoiceClassification As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrPictureBoxHeaderLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelLocationHeaderInfo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrPictureBoxFooterLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents XrLabelLocationFooterInfo As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
