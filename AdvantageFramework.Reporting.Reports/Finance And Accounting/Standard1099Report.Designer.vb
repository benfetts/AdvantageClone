Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class Standard1099Report
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Standard1099Report))
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupFooter_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_VendorInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_TotalAmountPaid = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Middle = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_VendorNameAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_VendorCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_FederalTaxID = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrPageInfo = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.LinePageFooter_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LabelReportFooter_VendorCountData = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_VendorCount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_Disclaimer = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_ReportTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel12, Me.XrLabel11, Me.XrLabel3, Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel2, Me.XrLabel1, Me.LineGroupFooter_Top})
            Me.Detail.HeightF = 120.9999!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel9
            '
            Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmountPaid", "{0:n2}")})
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(640.0!, 0.0!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel9.StylePriority.UseTextAlignment = False
            Me.XrLabel9.Text = "XrLabel9"
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel8
            '
            Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomeType")})
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(404.1667!, 22.99999!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(200.0417!, 23.0!)
            Me.XrLabel8.Text = "XrLabel8"
            '
            'XrLabel7
            '
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FederalTaxID")})
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(404.1247!, 0.0!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(155.2083!, 23.0!)
            Me.XrLabel7.Text = "XrLabel7"
            '
            'XrLabel6
            '
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToZipCode")})
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(318.7501!, 91.99991!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(70.83334!, 23.0!)
            Me.XrLabel6.Text = "XrLabel6"
            '
            'XrLabel5
            '
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToState")})
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(281.25!, 91.99991!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(37.5!, 23.0!)
            Me.XrLabel5.Text = "XrLabel5"
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToCity")})
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(91.66666!, 91.99991!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(187.5!, 23.0!)
            Me.XrLabel4.Text = "XrLabel4"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress")})
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(91.66673!, 22.99995!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(297.9166!, 23.0!)
            Me.XrLabel2.Text = "XrLabel2"
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(1.000055!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(78.1666!, 23.0!)
            Me.XrLabel1.Text = "XrLabel1"
            '
            'LineGroupFooter_Top
            '
            Me.LineGroupFooter_Top.BorderColor = System.Drawing.Color.Black
            Me.LineGroupFooter_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooter_Top.BorderWidth = 0
            Me.LineGroupFooter_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineGroupFooter_Top.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 116.9999!)
            Me.LineGroupFooter_Top.Name = "LineGroupFooter_Top"
            Me.LineGroupFooter_Top.SizeF = New System.Drawing.SizeF(750.0!, 4.000004!)
            Me.LineGroupFooter_Top.StylePriority.UseBorderColor = False
            Me.LineGroupFooter_Top.StylePriority.UseBorderWidth = False
            Me.LineGroupFooter_Top.StylePriority.UseForeColor = False
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 48.95833!
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_VendorInfo, Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_TotalAmountPaid, Me.LinePageHeader_Middle, Me.LabelPageHeader_VendorNameAddress, Me.LinePageHeader_Bottom, Me.LabelPageHeader_VendorCode, Me.LabelPageHeader_ReportTitle, Me.LabelPageHeader_FederalTaxID})
            Me.PageHeader.HeightF = 87.5834!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_ReportCriteria
            '
            Me.LabelPageHeader_ReportCriteria.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportCriteria.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportCriteria.BorderWidth = 1
            Me.LabelPageHeader_ReportCriteria.CanGrow = False
            Me.LabelPageHeader_ReportCriteria.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageHeader_ReportCriteria.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 36.08332!)
            Me.LabelPageHeader_ReportCriteria.Name = "LabelPageHeader_ReportCriteria"
            Me.LabelPageHeader_ReportCriteria.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportCriteria.SizeF = New System.Drawing.SizeF(369.7917!, 18.58334!)
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportCriteria.Text = "For"
            Me.LabelPageHeader_ReportCriteria.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_VendorInfo
            '
            Me.LabelPageHeader_VendorInfo.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_VendorInfo.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_VendorInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_VendorInfo.BorderWidth = 1
            Me.LabelPageHeader_VendorInfo.CanGrow = False
            Me.LabelPageHeader_VendorInfo.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageHeader_VendorInfo.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_VendorInfo.LocationFloat = New DevExpress.Utils.PointFloat(389.5834!, 22.66668!)
            Me.LabelPageHeader_VendorInfo.Name = "LabelPageHeader_VendorInfo"
            Me.LabelPageHeader_VendorInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_VendorInfo.SizeF = New System.Drawing.SizeF(360.4166!, 18.58334!)
            Me.LabelPageHeader_VendorInfo.StylePriority.UseBackColor = False
            Me.LabelPageHeader_VendorInfo.StylePriority.UseFont = False
            Me.LabelPageHeader_VendorInfo.StylePriority.UseForeColor = False
            Me.LabelPageHeader_VendorInfo.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_VendorInfo.Text = "Includes 1099 Vendors Paid Qualifying Amounts Only"
            Me.LabelPageHeader_VendorInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(389.5835!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(360.4165!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(749.9999!, 4.083315!)
            '
            'LabelPageHeader_TotalAmountPaid
            '
            Me.LabelPageHeader_TotalAmountPaid.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_TotalAmountPaid.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_TotalAmountPaid.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_TotalAmountPaid.BorderWidth = 1
            Me.LabelPageHeader_TotalAmountPaid.CanGrow = False
            Me.LabelPageHeader_TotalAmountPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_TotalAmountPaid.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_TotalAmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(611.4583!, 64.5834!)
            Me.LabelPageHeader_TotalAmountPaid.Name = "LabelPageHeader_TotalAmountPaid"
            Me.LabelPageHeader_TotalAmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_TotalAmountPaid.SizeF = New System.Drawing.SizeF(128.5417!, 19.0!)
            Me.LabelPageHeader_TotalAmountPaid.StylePriority.UseFont = False
            Me.LabelPageHeader_TotalAmountPaid.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_TotalAmountPaid.Text = "Total Amount Paid"
            Me.LabelPageHeader_TotalAmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Middle
            '
            Me.LinePageHeader_Middle.BorderColor = System.Drawing.Color.Black
            Me.LinePageHeader_Middle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Middle.BorderWidth = 0
            Me.LinePageHeader_Middle.ForeColor = System.Drawing.Color.Gray
            Me.LinePageHeader_Middle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 60.58337!)
            Me.LinePageHeader_Middle.Name = "LinePageHeader_Middle"
            Me.LinePageHeader_Middle.SizeF = New System.Drawing.SizeF(750.0!, 4.000004!)
            Me.LinePageHeader_Middle.StylePriority.UseBorderColor = False
            Me.LinePageHeader_Middle.StylePriority.UseBorderWidth = False
            Me.LinePageHeader_Middle.StylePriority.UseForeColor = False
            '
            'LabelPageHeader_VendorNameAddress
            '
            Me.LabelPageHeader_VendorNameAddress.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_VendorNameAddress.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_VendorNameAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_VendorNameAddress.BorderWidth = 1
            Me.LabelPageHeader_VendorNameAddress.CanGrow = False
            Me.LabelPageHeader_VendorNameAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_VendorNameAddress.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_VendorNameAddress.LocationFloat = New DevExpress.Utils.PointFloat(91.66673!, 64.58334!)
            Me.LabelPageHeader_VendorNameAddress.Name = "LabelPageHeader_VendorNameAddress"
            Me.LabelPageHeader_VendorNameAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_VendorNameAddress.SizeF = New System.Drawing.SizeF(215.5831!, 19.0!)
            Me.LabelPageHeader_VendorNameAddress.StylePriority.UseFont = False
            Me.LabelPageHeader_VendorNameAddress.Text = "Vendor Name and Pay To Address"
            Me.LabelPageHeader_VendorNameAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 0
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Gray
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 83.5834!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(750.0!, 4.000004!)
            Me.LinePageHeader_Bottom.StylePriority.UseBorderColor = False
            Me.LinePageHeader_Bottom.StylePriority.UseBorderWidth = False
            Me.LinePageHeader_Bottom.StylePriority.UseForeColor = False
            '
            'LabelPageHeader_VendorCode
            '
            Me.LabelPageHeader_VendorCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_VendorCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_VendorCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_VendorCode.BorderWidth = 1
            Me.LabelPageHeader_VendorCode.CanGrow = False
            Me.LabelPageHeader_VendorCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_VendorCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_VendorCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 64.58334!)
            Me.LabelPageHeader_VendorCode.Name = "LabelPageHeader_VendorCode"
            Me.LabelPageHeader_VendorCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_VendorCode.SizeF = New System.Drawing.SizeF(79.16666!, 19.0!)
            Me.LabelPageHeader_VendorCode.StylePriority.UseFont = False
            Me.LabelPageHeader_VendorCode.Text = "Vendor Code"
            Me.LabelPageHeader_VendorCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_ReportTitle
            '
            Me.LabelPageHeader_ReportTitle.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportTitle.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportTitle.BorderWidth = 1
            Me.LabelPageHeader_ReportTitle.CanGrow = False
            Me.LabelPageHeader_ReportTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportTitle.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 4.083315!)
            Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
            Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(182.2917!, 29.00001!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "1099 Report"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_FederalTaxID
            '
            Me.LabelPageHeader_FederalTaxID.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_FederalTaxID.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_FederalTaxID.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_FederalTaxID.BorderWidth = 1
            Me.LabelPageHeader_FederalTaxID.CanGrow = False
            Me.LabelPageHeader_FederalTaxID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_FederalTaxID.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_FederalTaxID.LocationFloat = New DevExpress.Utils.PointFloat(404.1247!, 64.58334!)
            Me.LabelPageHeader_FederalTaxID.Name = "LabelPageHeader_FederalTaxID"
            Me.LabelPageHeader_FederalTaxID.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_FederalTaxID.SizeF = New System.Drawing.SizeF(200.0837!, 19.0!)
            Me.LabelPageHeader_FederalTaxID.StylePriority.UseFont = False
            Me.LabelPageHeader_FederalTaxID.Text = "Federal Tax ID / Income Type"
            Me.LabelPageHeader_FederalTaxID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date, Me.XrPageInfo, Me.LinePageFooter_Top})
            Me.PageFooter.HeightF = 25.08328!
            Me.PageFooter.Name = "PageFooter"
            '
            'LabelPageFooter_UserCode
            '
            Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_UserCode.BorderWidth = 1
            Me.LabelPageFooter_UserCode.CanGrow = False
            Me.LabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_UserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 4.083315!)
            Me.LabelPageFooter_UserCode.Name = "LabelPageFooter_UserCode"
            Me.LabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_UserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_UserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_UserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageFooter_Date
            '
            Me.LabelPageFooter_Date.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_Date.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_Date.BorderWidth = 1
            Me.LabelPageFooter_Date.CanGrow = False
            Me.LabelPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 4.083315!)
            Me.LabelPageFooter_Date.Name = "LabelPageFooter_Date"
            Me.LabelPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_Date.SizeF = New System.Drawing.SizeF(236.4582!, 19.0!)
            Me.LabelPageFooter_Date.StylePriority.UseFont = False
            Me.LabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrPageInfo
            '
            Me.XrPageInfo.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrPageInfo.Format = "Page {0} of {1}"
            Me.XrPageInfo.LocationFloat = New DevExpress.Utils.PointFloat(614.5417!, 4.083315!)
            Me.XrPageInfo.Name = "XrPageInfo"
            Me.XrPageInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfo.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.XrPageInfo.StylePriority.UseFont = False
            Me.XrPageInfo.StylePriority.UseTextAlignment = False
            Me.XrPageInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageFooter_Top
            '
            Me.LinePageFooter_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter_Top.BorderWidth = 4
            Me.LinePageFooter_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter_Top.LineWidth = 4
            Me.LinePageFooter_Top.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LinePageFooter_Top.Name = "LinePageFooter_Top"
            Me.LinePageFooter_Top.SizeF = New System.Drawing.SizeF(750.0!, 4.083347!)
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_VendorCountData, Me.LabelReportFooter_VendorCount, Me.XrLabel10, Me.LabelReportFooter_Disclaimer, Me.LineReportFooter_Top, Me.LabelReportFooter_ReportTotal})
            Me.ReportFooter.HeightF = 89.66662!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_VendorCountData
            '
            Me.LabelReportFooter_VendorCountData.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.[Double]
            Me.LabelReportFooter_VendorCountData.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelReportFooter_VendorCountData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode")})
            Me.LabelReportFooter_VendorCountData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_VendorCountData.LocationFloat = New DevExpress.Utils.PointFloat(593.7916!, 34.375!)
            Me.LabelReportFooter_VendorCountData.Name = "LabelReportFooter_VendorCountData"
            Me.LabelReportFooter_VendorCountData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_VendorCountData.SizeF = New System.Drawing.SizeF(146.2084!, 23.0!)
            Me.LabelReportFooter_VendorCountData.StylePriority.UseBorderDashStyle = False
            Me.LabelReportFooter_VendorCountData.StylePriority.UseBorders = False
            Me.LabelReportFooter_VendorCountData.StylePriority.UseFont = False
            Me.LabelReportFooter_VendorCountData.StylePriority.UseTextAlignment = False
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_VendorCountData.Summary = XrSummary1
            Me.LabelReportFooter_VendorCountData.Text = "XrLabel1"
            Me.LabelReportFooter_VendorCountData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_VendorCount
            '
            Me.LabelReportFooter_VendorCount.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_VendorCount.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_VendorCount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_VendorCount.BorderWidth = 1
            Me.LabelReportFooter_VendorCount.CanGrow = False
            Me.LabelReportFooter_VendorCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_VendorCount.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_VendorCount.LocationFloat = New DevExpress.Utils.PointFloat(504.2084!, 34.375!)
            Me.LabelReportFooter_VendorCount.Name = "LabelReportFooter_VendorCount"
            Me.LabelReportFooter_VendorCount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_VendorCount.SizeF = New System.Drawing.SizeF(89.58325!, 19.0!)
            Me.LabelReportFooter_VendorCount.StylePriority.UseBorders = False
            Me.LabelReportFooter_VendorCount.StylePriority.UseFont = False
            Me.LabelReportFooter_VendorCount.Text = "Vendor Count:"
            Me.LabelReportFooter_VendorCount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel10
            '
            Me.XrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmountPaid")})
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(593.7916!, 3.999996!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(146.2084!, 23.0!)
            Me.XrLabel10.StylePriority.UseFont = False
            Me.XrLabel10.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel10.Summary = XrSummary2
            Me.XrLabel10.Text = "XrLabel10"
            Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelReportFooter_Disclaimer
            '
            Me.LabelReportFooter_Disclaimer.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_Disclaimer.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_Disclaimer.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_Disclaimer.BorderWidth = 1
            Me.LabelReportFooter_Disclaimer.CanGrow = False
            Me.LabelReportFooter_Disclaimer.Font = New System.Drawing.Font("Arial", 6.75!)
            Me.LabelReportFooter_Disclaimer.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_Disclaimer.LocationFloat = New DevExpress.Utils.PointFloat(1.000055!, 66.25!)
            Me.LabelReportFooter_Disclaimer.Multiline = True
            Me.LabelReportFooter_Disclaimer.Name = "LabelReportFooter_Disclaimer"
            Me.LabelReportFooter_Disclaimer.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_Disclaimer.SizeF = New System.Drawing.SizeF(748.9998!, 23.41661!)
            Me.LabelReportFooter_Disclaimer.StylePriority.UseBackColor = False
            Me.LabelReportFooter_Disclaimer.StylePriority.UseFont = False
            Me.LabelReportFooter_Disclaimer.StylePriority.UseForeColor = False
            Me.LabelReportFooter_Disclaimer.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_Disclaimer.Text = resources.GetString("LabelReportFooter_Disclaimer.Text")
            Me.LabelReportFooter_Disclaimer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineReportFooter_Top
            '
            Me.LineReportFooter_Top.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_Top.BorderWidth = 0
            Me.LineReportFooter_Top.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_Top.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LineReportFooter_Top.Name = "LineReportFooter_Top"
            Me.LineReportFooter_Top.SizeF = New System.Drawing.SizeF(750.0!, 4.000004!)
            Me.LineReportFooter_Top.StylePriority.UseBorderColor = False
            Me.LineReportFooter_Top.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_Top.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_ReportTotal
            '
            Me.LabelReportFooter_ReportTotal.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_ReportTotal.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_ReportTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_ReportTotal.BorderWidth = 1
            Me.LabelReportFooter_ReportTotal.CanGrow = False
            Me.LabelReportFooter_ReportTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_ReportTotal.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_ReportTotal.LocationFloat = New DevExpress.Utils.PointFloat(504.2084!, 3.999996!)
            Me.LabelReportFooter_ReportTotal.Name = "LabelReportFooter_ReportTotal"
            Me.LabelReportFooter_ReportTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_ReportTotal.SizeF = New System.Drawing.SizeF(89.58325!, 19.0!)
            Me.LabelReportFooter_ReportTotal.StylePriority.UseBorders = False
            Me.LabelReportFooter_ReportTotal.StylePriority.UseFont = False
            Me.LabelReportFooter_ReportTotal.Text = "Report Total:"
            Me.LabelReportFooter_ReportTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.IRS1099Processing)
            '
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToName")})
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(91.66673!, 0.0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(297.9167!, 23.0!)
            Me.XrLabel3.Text = "XrLabel3"
            '
            'XrLabel11
            '
            Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress2")})
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(91.66673!, 45.99994!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(297.9166!, 23.0!)
            Me.XrLabel11.Text = "XrLabel11"
            '
            'XrLabel12
            '
            Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress3")})
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(91.66673!, 68.99992!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(297.9166!, 23.0!)
            Me.XrLabel12.Text = "XrLabel12"
            '
            'Standard1099Report
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.ReportFooter})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(49, 51, 49, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_VendorCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LinePageHeader_Middle As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_VendorNameAddress As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_FederalTaxID As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_TotalAmountPaid As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelReportFooter_ReportTotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineGroupFooter_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageFooter_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrPageInfo As DevExpress.XtraReports.UI.XRPageInfo
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_VendorInfo As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_Disclaimer As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportFooter_VendorCountData As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_VendorCount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
