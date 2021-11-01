Namespace MediaManager

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class ReminderReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelGroupHeaderVendorCode_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_CreditCard = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_ClientName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_RunDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_CardAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrPictureBoxHeaderLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderVendorCode_LetterContent = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderVendorCode = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupHeaderVendorCodeSubreportVendorAddressSubReport = New DevExpress.XtraReports.UI.XRSubreport()
            Me.LabelGroupHeaderVendorCode_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_CreditCardLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_ClientNameLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_CardAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_RunDateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineGroupHeaderVendorCodeBottom = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineGroupHeaderVendorCodeTop = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_LocationHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.CalculatedFieldJobOrMediaDateToBill = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedFieldOrderLine = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderVendorCode_OrderLine, Me.LabelGroupHeaderVendorCode_CreditCard, Me.LabelGroupHeaderVendorCode_ClientName, Me.LabelGroupHeaderVendorCode_RunDate, Me.LabelGroupHeaderVendorCode_CardAmount})
            Me.Detail.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Detail.HeightF = 19.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderVendorCode_OrderLine
            '
            Me.LabelGroupHeaderVendorCode_OrderLine.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CalculatedFieldOrderLine")})
            Me.LabelGroupHeaderVendorCode_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(0.6249745!, 0!)
            Me.LabelGroupHeaderVendorCode_OrderLine.Name = "LabelGroupHeaderVendorCode_OrderLine"
            Me.LabelGroupHeaderVendorCode_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_OrderLine.SizeF = New System.Drawing.SizeF(69.41666!, 19.0!)
            Me.LabelGroupHeaderVendorCode_OrderLine.Text = "LabelGroupHeaderVendorCode_OrderLine"
            '
            'LabelGroupHeaderVendorCode_CreditCard
            '
            Me.LabelGroupHeaderVendorCode_CreditCard.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreditCardNumberExpDateCVC")})
            Me.LabelGroupHeaderVendorCode_CreditCard.LocationFloat = New DevExpress.Utils.PointFloat(477.3785!, 0!)
            Me.LabelGroupHeaderVendorCode_CreditCard.Name = "LabelGroupHeaderVendorCode_CreditCard"
            Me.LabelGroupHeaderVendorCode_CreditCard.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_CreditCard.SizeF = New System.Drawing.SizeF(272.6216!, 19.0!)
            Me.LabelGroupHeaderVendorCode_CreditCard.Text = "LabelGroupHeaderVendorCode_CreditCard"
            '
            'LabelGroupHeaderVendorCode_ClientName
            '
            Me.LabelGroupHeaderVendorCode_ClientName.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientName")})
            Me.LabelGroupHeaderVendorCode_ClientName.LocationFloat = New DevExpress.Utils.PointFloat(223.0!, 0!)
            Me.LabelGroupHeaderVendorCode_ClientName.Multiline = True
            Me.LabelGroupHeaderVendorCode_ClientName.Name = "LabelGroupHeaderVendorCode_ClientName"
            Me.LabelGroupHeaderVendorCode_ClientName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_ClientName.SizeF = New System.Drawing.SizeF(254.3785!, 19.0!)
            Me.LabelGroupHeaderVendorCode_ClientName.Text = "LabelGroupHeaderVendorCode_ClientName"
            '
            'LabelGroupHeaderVendorCode_RunDate
            '
            Me.LabelGroupHeaderVendorCode_RunDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StartDate", "{0:MM/dd/yy}")})
            Me.LabelGroupHeaderVendorCode_RunDate.LocationFloat = New DevExpress.Utils.PointFloat(73.04171!, 0!)
            Me.LabelGroupHeaderVendorCode_RunDate.Name = "LabelGroupHeaderVendorCode_RunDate"
            Me.LabelGroupHeaderVendorCode_RunDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_RunDate.SizeF = New System.Drawing.SizeF(59.53829!, 19.0!)
            '
            'LabelGroupHeaderVendorCode_CardAmount
            '
            Me.LabelGroupHeaderVendorCode_CardAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CardAmount", "{0:n2}")})
            Me.LabelGroupHeaderVendorCode_CardAmount.LocationFloat = New DevExpress.Utils.PointFloat(134.0!, 0!)
            Me.LabelGroupHeaderVendorCode_CardAmount.Name = "LabelGroupHeaderVendorCode_CardAmount"
            Me.LabelGroupHeaderVendorCode_CardAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_CardAmount.SizeF = New System.Drawing.SizeF(85.0!, 19.0!)
            Me.LabelGroupHeaderVendorCode_CardAmount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderVendorCode_CardAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            'XrPictureBoxHeaderLogo
            '
            Me.XrPictureBoxHeaderLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
            Me.XrPictureBoxHeaderLogo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrPictureBoxHeaderLogo.Name = "XrPictureBoxHeaderLogo"
            Me.XrPictureBoxHeaderLogo.SizeF = New System.Drawing.SizeF(750.0!, 150.0!)
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.LinePageFooter})
            Me.PageFooter.HeightF = 25.08335!
            Me.PageFooter.Name = "PageFooter"
            '
            'XrPageInfo1
            '
            Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(614.5417!, 4.083379!)
            Me.XrPageInfo1.Name = "XrPageInfo1"
            Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.XrPageInfo1.StylePriority.UseFont = False
            Me.XrPageInfo1.StylePriority.UseTextAlignment = False
            Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrPageInfo1.TextFormatString = "Page {0} of {1}"
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4.0!
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4.0!
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'LabelGroupHeaderVendorCode_LetterContent
            '
            Me.LabelGroupHeaderVendorCode_LetterContent.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_LetterContent.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_LetterContent.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_LetterContent.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_LetterContent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderVendorCode_LetterContent.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_LetterContent.LocationFloat = New DevExpress.Utils.PointFloat(0!, 19.00002!)
            Me.LabelGroupHeaderVendorCode_LetterContent.Multiline = True
            Me.LabelGroupHeaderVendorCode_LetterContent.Name = "LabelGroupHeaderVendorCode_LetterContent"
            Me.LabelGroupHeaderVendorCode_LetterContent.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_LetterContent.SizeF = New System.Drawing.SizeF(750.0!, 19.0!)
            Me.LabelGroupHeaderVendorCode_LetterContent.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_LetterContent.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderVendorCode_LetterContent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeaderVendorCode
            '
            Me.GroupHeaderVendorCode.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.GroupHeaderVendorCodeSubreportVendorAddressSubReport, Me.LabelGroupHeaderVendorCode_Date, Me.LabelGroupHeaderVendorCode_LetterContent})
            Me.GroupHeaderVendorCode.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderVendorCode.HeightF = 38.00002!
            Me.GroupHeaderVendorCode.Level = 1
            Me.GroupHeaderVendorCode.Name = "GroupHeaderVendorCode"
            '
            'GroupHeaderVendorCodeSubreportVendorAddressSubReport
            '
            Me.GroupHeaderVendorCodeSubreportVendorAddressSubReport.CanShrink = True
            Me.GroupHeaderVendorCodeSubreportVendorAddressSubReport.LocationFloat = New DevExpress.Utils.PointFloat(0.6249745!, 0.00003178914!)
            Me.GroupHeaderVendorCodeSubreportVendorAddressSubReport.Name = "GroupHeaderVendorCodeSubreportVendorAddressSubReport"
            Me.GroupHeaderVendorCodeSubreportVendorAddressSubReport.ReportSource = New AdvantageFramework.Reporting.Reports.MediaManager.VendorAddressSubReport()
            Me.GroupHeaderVendorCodeSubreportVendorAddressSubReport.SizeF = New System.Drawing.SizeF(326.0!, 18.99998!)
            '
            'LabelGroupHeaderVendorCode_Date
            '
            Me.LabelGroupHeaderVendorCode_Date.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_Date.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_Date.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_Date.CanGrow = False
            Me.LabelGroupHeaderVendorCode_Date.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelGroupHeaderVendorCode_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_Date.LocationFloat = New DevExpress.Utils.PointFloat(537.9168!, 0!)
            Me.LabelGroupHeaderVendorCode_Date.Name = "LabelGroupHeaderVendorCode_Date"
            Me.LabelGroupHeaderVendorCode_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_Date.SizeF = New System.Drawing.SizeF(212.0832!, 19.0!)
            Me.LabelGroupHeaderVendorCode_Date.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_Date.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderVendorCode_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderVendorCode_CreditCardLabel
            '
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.CanGrow = False
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.LocationFloat = New DevExpress.Utils.PointFloat(477.3785!, 7.500013!)
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.Name = "LabelGroupHeaderVendorCode_CreditCardLabel"
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.SizeF = New System.Drawing.SizeF(272.6214!, 19.0!)
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.StylePriority.UsePadding = False
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.Text = "Credit Card Number Exp. Date"
            Me.LabelGroupHeaderVendorCode_CreditCardLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderVendorCode_ClientNameLabel
            '
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.CanGrow = False
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.LocationFloat = New DevExpress.Utils.PointFloat(223.0!, 7.499949!)
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.Name = "LabelGroupHeaderVendorCode_ClientNameLabel"
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.SizeF = New System.Drawing.SizeF(254.3785!, 19.0!)
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.StylePriority.UsePadding = False
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.Text = "Client Name"
            Me.LabelGroupHeaderVendorCode_ClientNameLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderVendorCode_CardAmountLabel
            '
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.CanGrow = False
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(134.0!, 7.499992!)
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.Name = "LabelGroupHeaderVendorCode_CardAmountLabel"
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.SizeF = New System.Drawing.SizeF(85.0!, 19.0!)
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.StylePriority.UsePadding = False
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.Text = "Card Amount"
            Me.LabelGroupHeaderVendorCode_CardAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderVendorCode_RunDateLabel
            '
            Me.LabelGroupHeaderVendorCode_RunDateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_RunDateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_RunDateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_RunDateLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_RunDateLabel.CanGrow = False
            Me.LabelGroupHeaderVendorCode_RunDateLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeaderVendorCode_RunDateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_RunDateLabel.LocationFloat = New DevExpress.Utils.PointFloat(73.04166!, 7.500013!)
            Me.LabelGroupHeaderVendorCode_RunDateLabel.Name = "LabelGroupHeaderVendorCode_RunDateLabel"
            Me.LabelGroupHeaderVendorCode_RunDateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_RunDateLabel.SizeF = New System.Drawing.SizeF(59.53835!, 19.0!)
            Me.LabelGroupHeaderVendorCode_RunDateLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_RunDateLabel.StylePriority.UsePadding = False
            Me.LabelGroupHeaderVendorCode_RunDateLabel.Text = "Run Date"
            Me.LabelGroupHeaderVendorCode_RunDateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLineGroupHeaderVendorCodeBottom
            '
            Me.XrLineGroupHeaderVendorCodeBottom.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupHeaderVendorCodeBottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupHeaderVendorCodeBottom.BorderWidth = 1.0!
            Me.XrLineGroupHeaderVendorCodeBottom.ForeColor = System.Drawing.Color.Black
            Me.XrLineGroupHeaderVendorCodeBottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 26.49999!)
            Me.XrLineGroupHeaderVendorCodeBottom.Name = "XrLineGroupHeaderVendorCodeBottom"
            Me.XrLineGroupHeaderVendorCodeBottom.SizeF = New System.Drawing.SizeF(750.0!, 7.499992!)
            Me.XrLineGroupHeaderVendorCodeBottom.StylePriority.UseBorderColor = False
            Me.XrLineGroupHeaderVendorCodeBottom.StylePriority.UseBorderWidth = False
            Me.XrLineGroupHeaderVendorCodeBottom.StylePriority.UseForeColor = False
            '
            'XrLineGroupHeaderVendorCodeTop
            '
            Me.XrLineGroupHeaderVendorCodeTop.BorderColor = System.Drawing.Color.Black
            Me.XrLineGroupHeaderVendorCodeTop.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLineGroupHeaderVendorCodeTop.BorderWidth = 1.0!
            Me.XrLineGroupHeaderVendorCodeTop.ForeColor = System.Drawing.Color.Black
            Me.XrLineGroupHeaderVendorCodeTop.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLineGroupHeaderVendorCodeTop.Name = "XrLineGroupHeaderVendorCodeTop"
            Me.XrLineGroupHeaderVendorCodeTop.SizeF = New System.Drawing.SizeF(750.0!, 7.499992!)
            Me.XrLineGroupHeaderVendorCodeTop.StylePriority.UseBorderColor = False
            Me.XrLineGroupHeaderVendorCodeTop.StylePriority.UseBorderWidth = False
            Me.XrLineGroupHeaderVendorCodeTop.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderVendorCode_OrderNumberLabel
            '
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.CanGrow = False
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.6249745!, 7.500013!)
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.Name = "LabelGroupHeaderVendorCode_OrderNumberLabel"
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.SizeF = New System.Drawing.SizeF(69.41666!, 19.0!)
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.Text = "Order/Line"
            Me.LabelGroupHeaderVendorCode_OrderNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_LocationHeader
            '
            Me.LabelPageHeader_LocationHeader.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_LocationHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_LocationHeader.BorderWidth = 1.0!
            Me.LabelPageHeader_LocationHeader.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.LabelPageHeader_LocationHeader.LocationFloat = New DevExpress.Utils.PointFloat(0!, 150.0!)
            Me.LabelPageHeader_LocationHeader.Name = "LabelPageHeader_LocationHeader"
            Me.LabelPageHeader_LocationHeader.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            Me.LabelPageHeader_LocationHeader.StylePriority.UseBackColor = False
            Me.LabelPageHeader_LocationHeader.StylePriority.UsePadding = False
            Me.LabelPageHeader_LocationHeader.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0}"
            Me.LabelPageHeader_LocationHeader.Summary = XrSummary1
            Me.LabelPageHeader_LocationHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'CalculatedFieldJobOrMediaDateToBill
            '
            Me.CalculatedFieldJobOrMediaDateToBill.Expression = "Iif(IsNullOrEmpty([JobMediaBillDate]), [DateToBill], [JobMediaBillDate])"
            Me.CalculatedFieldJobOrMediaDateToBill.Name = "CalculatedFieldJobOrMediaDateToBill"
            '
            'CalculatedFieldOrderLine
            '
            Me.CalculatedFieldOrderLine.Expression = "Iif(IsNull([OrderNumber]),[PONumber],[OrderNumber]  + '-' + [LineNumber])"
            Me.CalculatedFieldOrderLine.Name = "CalculatedFieldOrderLine"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderVendorCode_ClientNameLabel, Me.XrLineGroupHeaderVendorCodeBottom, Me.LabelGroupHeaderVendorCode_CardAmountLabel, Me.XrLineGroupHeaderVendorCodeTop, Me.LabelGroupHeaderVendorCode_CreditCardLabel, Me.LabelGroupHeaderVendorCode_OrderNumberLabel, Me.LabelGroupHeaderVendorCode_RunDateLabel})
            Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader1.HeightF = 33.99998!
            Me.GroupHeader1.Name = "GroupHeader1"
            Me.GroupHeader1.RepeatEveryPage = True
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBoxHeaderLogo, Me.LabelPageHeader_LocationHeader})
            Me.ReportHeader.HeightF = 267.0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.MediaManager.Classes.VCCOrder)
            '
            'ReminderReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter, Me.GroupHeaderVendorCode, Me.GroupHeader1, Me.ReportHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.CalculatedFieldJobOrMediaDateToBill, Me.CalculatedFieldOrderLine})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrPictureBoxHeaderLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelGroupHeaderVendorCode_LetterContent As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderVendorCode As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeaderVendorCode_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLineGroupHeaderVendorCodeTop As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupHeaderVendorCode_OrderNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLineGroupHeaderVendorCodeBottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents CalculatedFieldJobOrMediaDateToBill As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelGroupHeaderVendorCode_CardAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupHeaderVendorCode_RunDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderVendorCode_RunDateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupHeaderVendorCode_CreditCard As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupHeaderVendorCode_ClientName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderVendorCode_CreditCardLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderVendorCode_ClientNameLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderVendorCode_CardAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupHeaderVendorCode_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CalculatedFieldOrderLine As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents GroupHeaderVendorCodeSubreportVendorAddressSubReport As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents LabelPageHeader_LocationHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    End Class

End Namespace
