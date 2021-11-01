Namespace Invoices

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class CoverSheetAlternate
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
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CoverSheetAlternate))
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabelInvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelJobNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelJobDescription = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrLabelReferenceHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrPictureBoxFooterLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.XrLabelLocationFooterInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalJobPhrase = New DevExpress.XtraReports.UI.CalculatedField()
            Me.HoursAndQuantity = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.GroupHeaderClient = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelTotalsHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelClientPO = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelClientPOLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceNumberData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelInvoiceNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterClient = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabelTotalAmountDue = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTotalAmountDueData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrRichTextFooterComment = New DevExpress.XtraReports.UI.XRRichText()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            CType(Me.XrRichTextFooterComment, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelInvoiceAmount, Me.XrLabelJobNumber, Me.XrLabelJobDescription, Me.XrLabelInvoiceNumber, Me.XrLabelInvoiceDate})
            Me.Detail.HeightF = 19.0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceAmount
            '
            Me.XrLabelInvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount")})
            Me.XrLabelInvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(646.8336!, 0!)
            Me.XrLabelInvoiceAmount.Multiline = True
            Me.XrLabelInvoiceAmount.Name = "XrLabelInvoiceAmount"
            Me.XrLabelInvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceAmount.SizeF = New System.Drawing.SizeF(103.1666!, 17.00001!)
            Me.XrLabelInvoiceAmount.StylePriority.UseTextAlignment = False
            Me.XrLabelInvoiceAmount.Text = "XrLabelInvoiceAmount"
            Me.XrLabelInvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelInvoiceAmount.TextFormatString = "{0:c2}"
            '
            'XrLabelJobNumber
            '
            Me.XrLabelJobNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber")})
            Me.XrLabelJobNumber.LocationFloat = New DevExpress.Utils.PointFloat(174.9584!, 0!)
            Me.XrLabelJobNumber.Multiline = True
            Me.XrLabelJobNumber.Name = "XrLabelJobNumber"
            Me.XrLabelJobNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelJobNumber.SizeF = New System.Drawing.SizeF(125.0!, 17.00001!)
            Me.XrLabelJobNumber.Text = "XrLabelJobNumber"
            '
            'XrLabelJobDescription
            '
            Me.XrLabelJobDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobDescription")})
            Me.XrLabelJobDescription.LocationFloat = New DevExpress.Utils.PointFloat(299.9584!, 0!)
            Me.XrLabelJobDescription.Name = "XrLabelJobDescription"
            Me.XrLabelJobDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelJobDescription.SizeF = New System.Drawing.SizeF(346.875!, 17.0!)
            '
            'XrLabelInvoiceNumber
            '
            Me.XrLabelInvoiceNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FullInvoiceNumber")})
            Me.XrLabelInvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(1.000086!, 0!)
            Me.XrLabelInvoiceNumber.Name = "XrLabelInvoiceNumber"
            Me.XrLabelInvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceNumber.SizeF = New System.Drawing.SizeF(100.0!, 17.0!)
            '
            'XrLabelInvoiceDate
            '
            Me.XrLabelInvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.XrLabelInvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(101.0001!, 0!)
            Me.XrLabelInvoiceDate.Name = "XrLabelInvoiceDate"
            Me.XrLabelInvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceDate.SizeF = New System.Drawing.SizeF(73.95834!, 17.0!)
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
            Me.XrLabelTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0004272461!, 176.9685!)
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
            Me.XrLabelDescriptionHeader.LocationFloat = New DevExpress.Utils.PointFloat(300.9588!, 155.0833!)
            Me.XrLabelDescriptionHeader.Name = "XrLabelDescriptionHeader"
            Me.XrLabelDescriptionHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDescriptionHeader.SizeF = New System.Drawing.SizeF(345.8747!, 33.0!)
            Me.XrLabelDescriptionHeader.StylePriority.UseFont = False
            Me.XrLabelDescriptionHeader.StylePriority.UseTextAlignment = False
            Me.XrLabelDescriptionHeader.Text = "Description"
            Me.XrLabelDescriptionHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelInvoiceHeader
            '
            Me.XrLabelInvoiceHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceHeader.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 155.0833!)
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
            Me.XrLabelAddress.SizeF = New System.Drawing.SizeF(509.0126!, 152.0833!)
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
            Me.XrLabelInvoiceDateData.LocationFloat = New DevExpress.Utils.PointFloat(612.5002!, 16.99998!)
            Me.XrLabelInvoiceDateData.Name = "XrLabelInvoiceDateData"
            Me.XrLabelInvoiceDateData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceDateData.SizeF = New System.Drawing.SizeF(137.4995!, 16.99998!)
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
            Me.XrLabelInvoiceDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(509.0127!, 17.00001!)
            Me.XrLabelInvoiceDateLabel.Name = "XrLabelInvoiceDateLabel"
            Me.XrLabelInvoiceDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceDateLabel.SizeF = New System.Drawing.SizeF(103.4875!, 17.0!)
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
            Me.XrLabelDateHeader.LocationFloat = New DevExpress.Utils.PointFloat(101.0001!, 155.0833!)
            Me.XrLabelDateHeader.Name = "XrLabelDateHeader"
            Me.XrLabelDateHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelDateHeader.SizeF = New System.Drawing.SizeF(73.95834!, 33.0!)
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
            'XrLabelReferenceHeader
            '
            Me.XrLabelReferenceHeader.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelReferenceHeader.BorderColor = System.Drawing.Color.Black
            Me.XrLabelReferenceHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelReferenceHeader.BorderWidth = 1.0!
            Me.XrLabelReferenceHeader.CanGrow = False
            Me.XrLabelReferenceHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelReferenceHeader.ForeColor = System.Drawing.Color.Black
            Me.XrLabelReferenceHeader.LocationFloat = New DevExpress.Utils.PointFloat(174.9584!, 155.0833!)
            Me.XrLabelReferenceHeader.Name = "XrLabelReferenceHeader"
            Me.XrLabelReferenceHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelReferenceHeader.SizeF = New System.Drawing.SizeF(125.0!, 33.0!)
            Me.XrLabelReferenceHeader.StylePriority.UsePadding = False
            Me.XrLabelReferenceHeader.StylePriority.UseTextAlignment = False
            Me.XrLabelReferenceHeader.Text = "Reference"
            Me.XrLabelReferenceHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
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
            Me.GroupHeaderClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTotalsHeader, Me.XrLabelClientPO, Me.XrLabelClientPOLabel, Me.XrLabelInvoiceNumberData, Me.XrLabelInvoiceNumberLabel, Me.XrLabelAddress, Me.XrLineInvoiceHeaderLine1, Me.XrLineInvoiceHeaderLine2, Me.XrLabelDateHeader, Me.XrLabelInvoiceDateLabel, Me.XrLabelInvoiceDateData, Me.XrLabelReferenceHeader, Me.XrLabelInvoiceHeader, Me.XrLabelDescriptionHeader})
            Me.GroupHeaderClient.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderClient.HeightF = 192.375!
            Me.GroupHeaderClient.Name = "GroupHeaderClient"
            Me.GroupHeaderClient.RepeatEveryPage = True
            '
            'XrLabelTotalsHeader
            '
            Me.XrLabelTotalsHeader.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelTotalsHeader.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTotalsHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTotalsHeader.BorderWidth = 1.0!
            Me.XrLabelTotalsHeader.CanGrow = False
            Me.XrLabelTotalsHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalsHeader.ForeColor = System.Drawing.Color.Black
            Me.XrLabelTotalsHeader.LocationFloat = New DevExpress.Utils.PointFloat(646.8336!, 155.0833!)
            Me.XrLabelTotalsHeader.Name = "XrLabelTotalsHeader"
            Me.XrLabelTotalsHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelTotalsHeader.SizeF = New System.Drawing.SizeF(103.1662!, 33.0!)
            Me.XrLabelTotalsHeader.StylePriority.UsePadding = False
            Me.XrLabelTotalsHeader.StylePriority.UseTextAlignment = False
            Me.XrLabelTotalsHeader.Text = "Totals"
            Me.XrLabelTotalsHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'XrLabelClientPO
            '
            Me.XrLabelClientPO.BorderColor = System.Drawing.Color.Black
            Me.XrLabelClientPO.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelClientPO.BorderWidth = 1.0!
            Me.XrLabelClientPO.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelClientPO.LocationFloat = New DevExpress.Utils.PointFloat(612.5002!, 34.00002!)
            Me.XrLabelClientPO.Name = "XrLabelClientPO"
            Me.XrLabelClientPO.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelClientPO.SizeF = New System.Drawing.SizeF(137.4999!, 16.99998!)
            Me.XrLabelClientPO.StylePriority.UseBackColor = False
            Me.XrLabelClientPO.StylePriority.UsePadding = False
            XrSummary6.FormatString = "{0:d}"
            Me.XrLabelClientPO.Summary = XrSummary6
            Me.XrLabelClientPO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelClientPOLabel
            '
            Me.XrLabelClientPOLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelClientPOLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelClientPOLabel.BorderWidth = 1.0!
            Me.XrLabelClientPOLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelClientPOLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelClientPOLabel.LocationFloat = New DevExpress.Utils.PointFloat(509.0127!, 34.00002!)
            Me.XrLabelClientPOLabel.Name = "XrLabelClientPOLabel"
            Me.XrLabelClientPOLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelClientPOLabel.SizeF = New System.Drawing.SizeF(103.4875!, 17.0!)
            Me.XrLabelClientPOLabel.StylePriority.UseBackColor = False
            Me.XrLabelClientPOLabel.StylePriority.UsePadding = False
            Me.XrLabelClientPOLabel.Text = "Client PO:"
            Me.XrLabelClientPOLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelInvoiceNumberData
            '
            Me.XrLabelInvoiceNumberData.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceNumberData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceNumberData.BorderWidth = 1.0!
            Me.XrLabelInvoiceNumberData.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrLabelInvoiceNumberData.LocationFloat = New DevExpress.Utils.PointFloat(612.5002!, 0!)
            Me.XrLabelInvoiceNumberData.Name = "XrLabelInvoiceNumberData"
            Me.XrLabelInvoiceNumberData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceNumberData.SizeF = New System.Drawing.SizeF(137.4995!, 16.99998!)
            Me.XrLabelInvoiceNumberData.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceNumberData.StylePriority.UsePadding = False
            XrSummary7.FormatString = "{0:d}"
            Me.XrLabelInvoiceNumberData.Summary = XrSummary7
            Me.XrLabelInvoiceNumberData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelInvoiceNumberLabel
            '
            Me.XrLabelInvoiceNumberLabel.BorderColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceNumberLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelInvoiceNumberLabel.BorderWidth = 1.0!
            Me.XrLabelInvoiceNumberLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelInvoiceNumberLabel.ForeColor = System.Drawing.Color.Black
            Me.XrLabelInvoiceNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(509.0126!, 0!)
            Me.XrLabelInvoiceNumberLabel.Name = "XrLabelInvoiceNumberLabel"
            Me.XrLabelInvoiceNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelInvoiceNumberLabel.SizeF = New System.Drawing.SizeF(103.4876!, 17.0!)
            Me.XrLabelInvoiceNumberLabel.StylePriority.UseBackColor = False
            Me.XrLabelInvoiceNumberLabel.StylePriority.UsePadding = False
            Me.XrLabelInvoiceNumberLabel.Text = "Invoice Number: "
            Me.XrLabelInvoiceNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupFooterClient
            '
            Me.GroupFooterClient.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTotalAmountDue, Me.XrLabelTotalAmountDueData, Me.XrRichTextFooterComment})
            Me.GroupFooterClient.HeightF = 86.87502!
            Me.GroupFooterClient.Name = "GroupFooterClient"
            Me.GroupFooterClient.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
            '
            'XrLabelTotalAmountDue
            '
            Me.XrLabelTotalAmountDue.BorderColor = System.Drawing.Color.Black
            Me.XrLabelTotalAmountDue.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelTotalAmountDue.BorderWidth = 1.0!
            Me.XrLabelTotalAmountDue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalAmountDue.ForeColor = System.Drawing.Color.Black
            Me.XrLabelTotalAmountDue.LocationFloat = New DevExpress.Utils.PointFloat(300.9588!, 9.999974!)
            Me.XrLabelTotalAmountDue.Name = "XrLabelTotalAmountDue"
            Me.XrLabelTotalAmountDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelTotalAmountDue.SizeF = New System.Drawing.SizeF(345.8747!, 17.0!)
            Me.XrLabelTotalAmountDue.StylePriority.UseBackColor = False
            Me.XrLabelTotalAmountDue.StylePriority.UsePadding = False
            Me.XrLabelTotalAmountDue.StylePriority.UseTextAlignment = False
            Me.XrLabelTotalAmountDue.Text = "Total Amount Due"
            Me.XrLabelTotalAmountDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'XrLabelTotalAmountDueData
            '
            Me.XrLabelTotalAmountDueData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount")})
            Me.XrLabelTotalAmountDueData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalAmountDueData.LocationFloat = New DevExpress.Utils.PointFloat(646.8336!, 9.999974!)
            Me.XrLabelTotalAmountDueData.Multiline = True
            Me.XrLabelTotalAmountDueData.Name = "XrLabelTotalAmountDueData"
            Me.XrLabelTotalAmountDueData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelTotalAmountDueData.SizeF = New System.Drawing.SizeF(103.1667!, 17.0!)
            Me.XrLabelTotalAmountDueData.StylePriority.UseFont = False
            Me.XrLabelTotalAmountDueData.StylePriority.UseTextAlignment = False
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTotalAmountDueData.Summary = XrSummary8
            Me.XrLabelTotalAmountDueData.Text = "XrLabelTotalAmountDueData"
            Me.XrLabelTotalAmountDueData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelTotalAmountDueData.TextFormatString = "{0:c2}"
            '
            'XrRichTextFooterComment
            '
            Me.XrRichTextFooterComment.CanShrink = True
            Me.XrRichTextFooterComment.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrRichTextFooterComment.LocationFloat = New DevExpress.Utils.PointFloat(0.0004272461!, 38.54167!)
            Me.XrRichTextFooterComment.Name = "XrRichTextFooterComment"
            Me.XrRichTextFooterComment.SerializableRtfString = resources.GetString("XrRichTextFooterComment.SerializableRtfString")
            Me.XrRichTextFooterComment.SizeF = New System.Drawing.SizeF(749.9998!, 48.33333!)
            Me.XrRichTextFooterComment.StylePriority.UsePadding = False
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.CoverSheet)
            '
            'CoverSheetAlternate
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.ReportFooter, Me.ReportHeader, Me.GroupHeaderClient, Me.GroupFooterClient})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.TotalJobPhrase, Me.HoursAndQuantity})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.XrRichTextFooterComment, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents XrLabelReferenceHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents TotalJobPhrase As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrLabelDateHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents HoursAndQuantity As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabelInvoiceHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelDescriptionHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents XrLabelJobDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderClient As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterClient As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrPictureBoxHeaderLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelLocationHeaderInfo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrPictureBoxFooterLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents XrLabelLocationFooterInfo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceNumberData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelInvoiceNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelJobNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelClientPO As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelClientPOLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrRichTextFooterComment As DevExpress.XtraReports.UI.XRRichText
        Friend WithEvents XrLabelInvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalsHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalAmountDueData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalAmountDue As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
