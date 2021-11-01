Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class Detail1099WithDisbursementReport
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
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Detail1099WithDisbursementReport))
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelGroupHeaderDetail_DisbursedAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderDetail_DetailGLAccount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderDetail_GLDisbursement = New DevExpress.XtraReports.UI.XRLabel()
            Me.CheckBoxDetail_1099Form = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_QualifyingAmounts = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_1099 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_TotalAmountPaid = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_FederalTaxID = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_VendorNameAndAddress = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_VendorCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrPageInfo = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrLine15 = New DevExpress.XtraReports.UI.XRLine()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_Disclaimer = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportFooter_VendorCount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_ReportTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubreportDetail_1099Disbursement = New DevExpress.XtraReports.UI.XRSubreport()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderDetail_DisbursedAmount, Me.LabelGroupHeaderDetail_DetailGLAccount, Me.LabelGroupHeaderDetail_GLDisbursement, Me.CheckBoxDetail_1099Form, Me.XrLine4, Me.XrLabel9, Me.SubreportDetail_1099Disbursement, Me.XrLabel11, Me.XrLabel10, Me.XrLabel7, Me.XrLabel5, Me.XrLabel8, Me.XrLabel6, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1})
            Me.Detail.HeightF = 137.8334!
            Me.Detail.KeepTogetherWithDetailReports = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderDetail_DisbursedAmount
            '
            Me.LabelGroupHeaderDetail_DisbursedAmount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderDetail_DisbursedAmount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderDetail_DisbursedAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderDetail_DisbursedAmount.BorderWidth = 1
            Me.LabelGroupHeaderDetail_DisbursedAmount.CanGrow = False
            Me.LabelGroupHeaderDetail_DisbursedAmount.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
            Me.LabelGroupHeaderDetail_DisbursedAmount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderDetail_DisbursedAmount.LocationFloat = New DevExpress.Utils.PointFloat(667.7503!, 92.08336!)
            Me.LabelGroupHeaderDetail_DisbursedAmount.Name = "LabelGroupHeaderDetail_DisbursedAmount"
            Me.LabelGroupHeaderDetail_DisbursedAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderDetail_DisbursedAmount.SizeF = New System.Drawing.SizeF(169.7917!, 19.0!)
            Me.LabelGroupHeaderDetail_DisbursedAmount.StylePriority.UseFont = False
            Me.LabelGroupHeaderDetail_DisbursedAmount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderDetail_DisbursedAmount.Text = "Disbursed Amount"
            Me.LabelGroupHeaderDetail_DisbursedAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupHeaderDetail_DetailGLAccount
            '
            Me.LabelGroupHeaderDetail_DetailGLAccount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderDetail_DetailGLAccount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderDetail_DetailGLAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderDetail_DetailGLAccount.BorderWidth = 1
            Me.LabelGroupHeaderDetail_DetailGLAccount.CanGrow = False
            Me.LabelGroupHeaderDetail_DetailGLAccount.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
            Me.LabelGroupHeaderDetail_DetailGLAccount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderDetail_DetailGLAccount.LocationFloat = New DevExpress.Utils.PointFloat(439.5834!, 92.08336!)
            Me.LabelGroupHeaderDetail_DetailGLAccount.Name = "LabelGroupHeaderDetail_DetailGLAccount"
            Me.LabelGroupHeaderDetail_DetailGLAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderDetail_DetailGLAccount.SizeF = New System.Drawing.SizeF(169.7917!, 19.0!)
            Me.LabelGroupHeaderDetail_DetailGLAccount.StylePriority.UseFont = False
            Me.LabelGroupHeaderDetail_DetailGLAccount.Text = "Detail GL Account"
            Me.LabelGroupHeaderDetail_DetailGLAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderDetail_GLDisbursement
            '
            Me.LabelGroupHeaderDetail_GLDisbursement.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderDetail_GLDisbursement.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderDetail_GLDisbursement.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderDetail_GLDisbursement.BorderWidth = 1
            Me.LabelGroupHeaderDetail_GLDisbursement.CanGrow = False
            Me.LabelGroupHeaderDetail_GLDisbursement.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderDetail_GLDisbursement.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderDetail_GLDisbursement.LocationFloat = New DevExpress.Utils.PointFloat(439.5834!, 73.08337!)
            Me.LabelGroupHeaderDetail_GLDisbursement.Name = "LabelGroupHeaderDetail_GLDisbursement"
            Me.LabelGroupHeaderDetail_GLDisbursement.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderDetail_GLDisbursement.SizeF = New System.Drawing.SizeF(169.7917!, 19.0!)
            Me.LabelGroupHeaderDetail_GLDisbursement.StylePriority.UseFont = False
            Me.LabelGroupHeaderDetail_GLDisbursement.Text = "GL Disbursement"
            Me.LabelGroupHeaderDetail_GLDisbursement.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'CheckBoxDetail_1099Form
            '
            Me.CheckBoxDetail_1099Form.Checked = True
            Me.CheckBoxDetail_1099Form.LocationFloat = New DevExpress.Utils.PointFloat(937.5!, 0.0!)
            Me.CheckBoxDetail_1099Form.Name = "CheckBoxDetail_1099Form"
            Me.CheckBoxDetail_1099Form.SizeF = New System.Drawing.SizeF(25.00006!, 15.0!)
            Me.CheckBoxDetail_1099Form.StylePriority.UseTextAlignment = False
            Me.CheckBoxDetail_1099Form.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine4
            '
            Me.XrLine4.BorderColor = System.Drawing.Color.Black
            Me.XrLine4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine4.BorderWidth = 0
            Me.XrLine4.ForeColor = System.Drawing.Color.Gray
            Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 133.8334!)
            Me.XrLine4.Name = "XrLine4"
            Me.XrLine4.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.XrLine4.StylePriority.UseBorderColor = False
            Me.XrLine4.StylePriority.UseBorderWidth = False
            Me.XrLine4.StylePriority.UseForeColor = False
            '
            'XrLabel9
            '
            Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmountPaid", "{0:c2}")})
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(704.2086!, 0.0!)
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(133.3334!, 23.0!)
            Me.XrLabel9.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:c2}"
            Me.XrLabel9.Summary = XrSummary1
            Me.XrLabel9.Text = "XrLabel9"
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel11
            '
            Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress3")})
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(108.375!, 68.99995!)
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(312.4584!, 23.0!)
            Me.XrLabel11.Text = "XrLabel11"
            '
            'XrLabel10
            '
            Me.XrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress2")})
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(108.375!, 45.99997!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(312.4584!, 23.0!)
            Me.XrLabel10.Text = "XrLabel10"
            '
            'XrLabel7
            '
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomeType")})
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(439.5834!, 22.99999!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(169.7917!, 23.0!)
            Me.XrLabel7.Text = "XrLabel7"
            '
            'XrLabel5
            '
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FederalTaxID")})
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(439.5834!, 0.0!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(158.3333!, 23.0!)
            Me.XrLabel5.Text = "XrLabel5"
            '
            'XrLabel8
            '
            Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToZipCode")})
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(320.8333!, 92.08336!)
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel8.Text = "XrLabel8"
            '
            'XrLabel6
            '
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToState")})
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(220.8334!, 92.08336!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel6.Text = "XrLabel6"
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToCity")})
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(108.375!, 92.08336!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel4.Text = "XrLabel4"
            '
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToAddress")})
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(108.375!, 22.99999!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(312.4584!, 23.0!)
            Me.XrLabel3.Text = "XrLabel3"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PayToName")})
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(108.375!, 0.0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(312.4584!, 23.0!)
            Me.XrLabel2.Text = "XrLabel2"
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00007152557!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(82.29159!, 23.0!)
            Me.XrLabel1.Text = "XrLabel1"
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_QualifyingAmounts, Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_1099, Me.LabelPageHeader_TotalAmountPaid, Me.LabelPageHeader_FederalTaxID, Me.XrLine3, Me.LabelPageHeader_VendorNameAndAddress, Me.XrLine2, Me.LabelPageHeader_VendorCode, Me.XrLabel20})
            Me.PageHeader.HeightF = 87.5834!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_QualifyingAmounts
            '
            Me.LabelPageHeader_QualifyingAmounts.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_QualifyingAmounts.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_QualifyingAmounts.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_QualifyingAmounts.BorderWidth = 1
            Me.LabelPageHeader_QualifyingAmounts.CanGrow = False
            Me.LabelPageHeader_QualifyingAmounts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_QualifyingAmounts.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_QualifyingAmounts.LocationFloat = New DevExpress.Utils.PointFloat(513.4998!, 33.08334!)
            Me.LabelPageHeader_QualifyingAmounts.Name = "LabelPageHeader_QualifyingAmounts"
            Me.LabelPageHeader_QualifyingAmounts.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_QualifyingAmounts.SizeF = New System.Drawing.SizeF(486.5002!, 17.00001!)
            Me.LabelPageHeader_QualifyingAmounts.StylePriority.UseFont = False
            Me.LabelPageHeader_QualifyingAmounts.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_QualifyingAmounts.Text = "Includes 1099 Vendors Paid Qualifying Amounts* Only"
            Me.LabelPageHeader_QualifyingAmounts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(513.4998!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(486.5002!, 18.58334!)
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
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageHeader_ReportCriteria
            '
            Me.LabelPageHeader_ReportCriteria.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportCriteria.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportCriteria.BorderWidth = 1
            Me.LabelPageHeader_ReportCriteria.CanGrow = False
            Me.LabelPageHeader_ReportCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportCriteria.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.LocationFloat = New DevExpress.Utils.PointFloat(0.00007152557!, 33.08334!)
            Me.LabelPageHeader_ReportCriteria.Name = "LabelPageHeader_ReportCriteria"
            Me.LabelPageHeader_ReportCriteria.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportCriteria.SizeF = New System.Drawing.SizeF(501.0417!, 17.00001!)
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportCriteria.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_1099
            '
            Me.LabelPageHeader_1099.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_1099.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_1099.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_1099.BorderWidth = 1
            Me.LabelPageHeader_1099.CanGrow = False
            Me.LabelPageHeader_1099.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_1099.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_1099.LocationFloat = New DevExpress.Utils.PointFloat(899.0001!, 64.5834!)
            Me.LabelPageHeader_1099.Name = "LabelPageHeader_1099"
            Me.LabelPageHeader_1099.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_1099.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelPageHeader_1099.StylePriority.UseFont = False
            Me.LabelPageHeader_1099.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_1099.Text = "1099"
            Me.LabelPageHeader_1099.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
            Me.LabelPageHeader_TotalAmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(661.5002!, 64.58334!)
            Me.LabelPageHeader_TotalAmountPaid.Name = "LabelPageHeader_TotalAmountPaid"
            Me.LabelPageHeader_TotalAmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_TotalAmountPaid.SizeF = New System.Drawing.SizeF(176.0418!, 19.0!)
            Me.LabelPageHeader_TotalAmountPaid.StylePriority.UseFont = False
            Me.LabelPageHeader_TotalAmountPaid.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_TotalAmountPaid.Text = "Total Amount Paid"
            Me.LabelPageHeader_TotalAmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.LabelPageHeader_FederalTaxID.LocationFloat = New DevExpress.Utils.PointFloat(439.5834!, 64.5834!)
            Me.LabelPageHeader_FederalTaxID.Name = "LabelPageHeader_FederalTaxID"
            Me.LabelPageHeader_FederalTaxID.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_FederalTaxID.SizeF = New System.Drawing.SizeF(169.7917!, 19.0!)
            Me.LabelPageHeader_FederalTaxID.StylePriority.UseFont = False
            Me.LabelPageHeader_FederalTaxID.Text = "Federal Tax ID / Income Type"
            Me.LabelPageHeader_FederalTaxID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLine3
            '
            Me.XrLine3.BorderColor = System.Drawing.Color.Black
            Me.XrLine3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine3.BorderWidth = 0
            Me.XrLine3.ForeColor = System.Drawing.Color.Gray
            Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 60.58337!)
            Me.XrLine3.Name = "XrLine3"
            Me.XrLine3.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.XrLine3.StylePriority.UseBorderColor = False
            Me.XrLine3.StylePriority.UseBorderWidth = False
            Me.XrLine3.StylePriority.UseForeColor = False
            '
            'LabelPageHeader_VendorNameAndAddress
            '
            Me.LabelPageHeader_VendorNameAndAddress.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_VendorNameAndAddress.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_VendorNameAndAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_VendorNameAndAddress.BorderWidth = 1
            Me.LabelPageHeader_VendorNameAndAddress.CanGrow = False
            Me.LabelPageHeader_VendorNameAndAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_VendorNameAndAddress.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_VendorNameAndAddress.LocationFloat = New DevExpress.Utils.PointFloat(108.375!, 64.58334!)
            Me.LabelPageHeader_VendorNameAndAddress.Name = "LabelPageHeader_VendorNameAndAddress"
            Me.LabelPageHeader_VendorNameAndAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_VendorNameAndAddress.SizeF = New System.Drawing.SizeF(228.125!, 19.0!)
            Me.LabelPageHeader_VendorNameAndAddress.StylePriority.UseFont = False
            Me.LabelPageHeader_VendorNameAndAddress.Text = "Vendor Name and Pay To Address"
            Me.LabelPageHeader_VendorNameAndAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Black
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 0
            Me.XrLine2.ForeColor = System.Drawing.Color.Gray
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 83.5834!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.XrLine2.StylePriority.UseBorderColor = False
            Me.XrLine2.StylePriority.UseBorderWidth = False
            Me.XrLine2.StylePriority.UseForeColor = False
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
            Me.LabelPageHeader_VendorCode.SizeF = New System.Drawing.SizeF(82.29166!, 19.0!)
            Me.LabelPageHeader_VendorCode.StylePriority.UseFont = False
            Me.LabelPageHeader_VendorCode.Text = "Vendor Code"
            Me.LabelPageHeader_VendorCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel20
            '
            Me.XrLabel20.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel20.BorderColor = System.Drawing.Color.Black
            Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel20.BorderWidth = 1
            Me.XrLabel20.CanGrow = False
            Me.XrLabel20.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel20.ForeColor = System.Drawing.Color.Black
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 4.083315!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
            Me.XrLabel20.StylePriority.UseBackColor = False
            Me.XrLabel20.StylePriority.UseFont = False
            Me.XrLabel20.StylePriority.UseForeColor = False
            Me.XrLabel20.StylePriority.UseTextAlignment = False
            Me.XrLabel20.Text = "1099 Report - With AP Detail Disbursement"
            Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date, Me.XrPageInfo, Me.XrLine15})
            Me.PageFooter.HeightF = 25.08329!
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
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(359.375!, 4.083315!)
            Me.LabelPageFooter_UserCode.Name = "LabelPageFooter_UserCode"
            Me.LabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(314.5414!, 19.0!)
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
            Me.LabelPageFooter_Date.SizeF = New System.Drawing.SizeF(336.4999!, 19.0!)
            Me.LabelPageFooter_Date.StylePriority.UseFont = False
            Me.LabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrPageInfo
            '
            Me.XrPageInfo.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrPageInfo.Format = "Page {0} of {1}"
            Me.XrPageInfo.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 4.083315!)
            Me.XrPageInfo.Name = "XrPageInfo"
            Me.XrPageInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrPageInfo.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.XrPageInfo.StylePriority.UseFont = False
            Me.XrPageInfo.StylePriority.UseTextAlignment = False
            Me.XrPageInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine15
            '
            Me.XrLine15.BorderColor = System.Drawing.Color.Silver
            Me.XrLine15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine15.BorderWidth = 4
            Me.XrLine15.ForeColor = System.Drawing.Color.Silver
            Me.XrLine15.LineWidth = 4
            Me.XrLine15.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLine15.Name = "XrLine15"
            Me.XrLine15.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel13, Me.XrLabel12, Me.LabelReportFooter_Disclaimer, Me.LabelReportFooter_VendorCount, Me.XrLine1, Me.LabelReportFooter_ReportTotal})
            Me.ReportFooter.HeightF = 84.87494!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'XrLabel13
            '
            Me.XrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode", "{0:#,#}")})
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(739.6254!, 26.99998!)
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(97.91656!, 23.0!)
            Me.XrLabel13.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:#,#}"
            XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel13.Summary = XrSummary2
            Me.XrLabel13.Text = "XrLabel13"
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel12
            '
            Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmountPaid", "{0:c2}")})
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(704.2086!, 3.999996!)
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(133.3334!, 23.0!)
            Me.XrLabel12.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:c2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel12.Summary = XrSummary3
            Me.XrLabel12.Text = "XrLabel12"
            Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.LabelReportFooter_Disclaimer.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 61.45833!)
            Me.LabelReportFooter_Disclaimer.Multiline = True
            Me.LabelReportFooter_Disclaimer.Name = "LabelReportFooter_Disclaimer"
            Me.LabelReportFooter_Disclaimer.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_Disclaimer.SizeF = New System.Drawing.SizeF(999.0!, 23.41661!)
            Me.LabelReportFooter_Disclaimer.StylePriority.UseBackColor = False
            Me.LabelReportFooter_Disclaimer.StylePriority.UseFont = False
            Me.LabelReportFooter_Disclaimer.StylePriority.UseForeColor = False
            Me.LabelReportFooter_Disclaimer.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_Disclaimer.Text = resources.GetString("LabelReportFooter_Disclaimer.Text")
            Me.LabelReportFooter_Disclaimer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.LabelReportFooter_VendorCount.LocationFloat = New DevExpress.Utils.PointFloat(573.9165!, 22.99999!)
            Me.LabelReportFooter_VendorCount.Name = "LabelReportFooter_VendorCount"
            Me.LabelReportFooter_VendorCount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_VendorCount.SizeF = New System.Drawing.SizeF(99.99995!, 19.0!)
            Me.LabelReportFooter_VendorCount.StylePriority.UseBorders = False
            Me.LabelReportFooter_VendorCount.StylePriority.UseFont = False
            Me.LabelReportFooter_VendorCount.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_VendorCount.Text = "Vendor Count:"
            Me.LabelReportFooter_VendorCount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Black
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 0
            Me.XrLine1.ForeColor = System.Drawing.Color.Gray
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(1000.0!, 4.000004!)
            Me.XrLine1.StylePriority.UseBorderColor = False
            Me.XrLine1.StylePriority.UseBorderWidth = False
            Me.XrLine1.StylePriority.UseForeColor = False
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
            Me.LabelReportFooter_ReportTotal.LocationFloat = New DevExpress.Utils.PointFloat(573.9164!, 3.999996!)
            Me.LabelReportFooter_ReportTotal.Name = "LabelReportFooter_ReportTotal"
            Me.LabelReportFooter_ReportTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_ReportTotal.SizeF = New System.Drawing.SizeF(99.99995!, 19.0!)
            Me.LabelReportFooter_ReportTotal.StylePriority.UseBorders = False
            Me.LabelReportFooter_ReportTotal.StylePriority.UseFont = False
            Me.LabelReportFooter_ReportTotal.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_ReportTotal.Text = "Report Total:"
            Me.LabelReportFooter_ReportTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'SubreportDetail_1099Disbursement
            '
            Me.SubreportDetail_1099Disbursement.Id = 0
            Me.SubreportDetail_1099Disbursement.LocationFloat = New DevExpress.Utils.PointFloat(437.542!, 111.0834!)
            Me.SubreportDetail_1099Disbursement.Name = "SubreportDetail_1099Disbursement"
            Me.SubreportDetail_1099Disbursement.ReportSource = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Detail1099DisbursementSubReport()
            Me.SubreportDetail_1099Disbursement.SizeF = New System.Drawing.SizeF(400.0!, 22.75!)
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.IRS1099Processing)
            '
            'Detail1099WithDisbursementReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.ReportFooter})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(49, 51, 49, 50)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_VendorCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageHeader_FederalTaxID As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_VendorNameAndAddress As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_TotalAmountPaid As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_1099 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelReportFooter_ReportTotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine15 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrPageInfo As DevExpress.XtraReports.UI.XRPageInfo
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_VendorCount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_QualifyingAmounts As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_Disclaimer As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SubreportDetail_1099Disbursement As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents CheckBoxDetail_1099Form As DevExpress.XtraReports.UI.XRCheckBox
        Private WithEvents LabelGroupHeaderDetail_DisbursedAmount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderDetail_DetailGLAccount As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderDetail_GLDisbursement As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
