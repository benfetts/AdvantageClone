Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class AccountPayableImportExpenseReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetail_IsDeleted = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLACode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Function = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_JobComp = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_JobNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Office = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PostPeriod = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_FunctionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TermsLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OfficeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_AmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ExtAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_GLCodeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DiscountPercentLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineReportFooter_1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LineReportFooter_2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportFooter_BatchTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LinePageHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ReportCriteria = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_ReportTitle = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.LabelReportFooter_SumAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_Note = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageFooter = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader_VendorCode = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_VendorLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeaderVendorCode_EmployeeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader_InvoiceNumber = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LineGroupHeaderInvoiceNumber_Break = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelDetail_JobCompLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InvoiceDescLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.VendorCodeName = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupFooter_VendorCode = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterVendorCode_TotalForVendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterVendorCode_AmountSum = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter_InvoiceNumber = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterInvoiceNumber_AmountSum = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalForInvoice = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TotalForEmployee = New DevExpress.XtraReports.UI.CalculatedField()
            Me.IsDeleted = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EmployeeCodeName = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_IsDeleted, Me.LabelDetail_GLACode, Me.LabelDetail_Amount, Me.LabelDetail_Function, Me.LabelDetail_InvoiceNumber, Me.LabelDetail_JobComp, Me.LabelDetail_JobNumber, Me.LabelDetail_Office, Me.LabelDetail_PostPeriod, Me.LabelDetail_InvoiceAmount, Me.LabelDetail_InvoiceDate, Me.LabelDetail_InvoiceDescription})
            Me.Detail.HeightF = 18.99999!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_IsDeleted
            '
            Me.LabelDetail_IsDeleted.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IsDeleted")})
            Me.LabelDetail_IsDeleted.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 0.0!)
            Me.LabelDetail_IsDeleted.Name = "LabelDetail_IsDeleted"
            Me.LabelDetail_IsDeleted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_IsDeleted.SizeF = New System.Drawing.SizeF(15.0834!, 18.99999!)
            Me.LabelDetail_IsDeleted.StylePriority.UseTextAlignment = False
            Me.LabelDetail_IsDeleted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLACode
            '
            Me.LabelDetail_GLACode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GLACode")})
            Me.LabelDetail_GLACode.LocationFloat = New DevExpress.Utils.PointFloat(873.1249!, 0.0!)
            Me.LabelDetail_GLACode.Name = "LabelDetail_GLACode"
            Me.LabelDetail_GLACode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_GLACode.SizeF = New System.Drawing.SizeF(125.8751!, 18.99999!)
            Me.LabelDetail_GLACode.Text = "LabelDetail_GLACode"
            '
            'LabelDetail_Amount
            '
            Me.LabelDetail_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.LabelDetail_Amount.LocationFloat = New DevExpress.Utils.PointFloat(761.8749!, 0.0!)
            Me.LabelDetail_Amount.Name = "LabelDetail_Amount"
            Me.LabelDetail_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Amount.SizeF = New System.Drawing.SizeF(106.25!, 18.99999!)
            Me.LabelDetail_Amount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_Function
            '
            Me.LabelDetail_Function.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionCode")})
            Me.LabelDetail_Function.LocationFloat = New DevExpress.Utils.PointFloat(703.7499!, 0.0!)
            Me.LabelDetail_Function.Name = "LabelDetail_Function"
            Me.LabelDetail_Function.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Function.SizeF = New System.Drawing.SizeF(53.12506!, 18.99999!)
            Me.LabelDetail_Function.Text = "LabelDetail_Function"
            '
            'LabelDetail_InvoiceNumber
            '
            Me.LabelDetail_InvoiceNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
            Me.LabelDetail_InvoiceNumber.LocationFloat = New DevExpress.Utils.PointFloat(17.62498!, 0.0!)
            Me.LabelDetail_InvoiceNumber.Name = "LabelDetail_InvoiceNumber"
            Me.LabelDetail_InvoiceNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceNumber.SizeF = New System.Drawing.SizeF(111.4583!, 18.99999!)
            Me.LabelDetail_InvoiceNumber.Text = "LabelDetail_InvoiceNumber"
            '
            'LabelDetail_JobComp
            '
            Me.LabelDetail_JobComp.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentNumber")})
            Me.LabelDetail_JobComp.LocationFloat = New DevExpress.Utils.PointFloat(649.7914!, 0.0!)
            Me.LabelDetail_JobComp.Name = "LabelDetail_JobComp"
            Me.LabelDetail_JobComp.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_JobComp.SizeF = New System.Drawing.SizeF(48.95837!, 18.99999!)
            Me.LabelDetail_JobComp.Text = "LabelDetail_JobComp"
            '
            'LabelDetail_JobNumber
            '
            Me.LabelDetail_JobNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber")})
            Me.LabelDetail_JobNumber.LocationFloat = New DevExpress.Utils.PointFloat(585.4164!, 0.0!)
            Me.LabelDetail_JobNumber.Name = "LabelDetail_JobNumber"
            Me.LabelDetail_JobNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_JobNumber.SizeF = New System.Drawing.SizeF(59.375!, 18.99999!)
            Me.LabelDetail_JobNumber.StylePriority.UseTextAlignment = False
            Me.LabelDetail_JobNumber.Text = "LabelDetail_JobNumber"
            Me.LabelDetail_JobNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Office
            '
            Me.LabelDetail_Office.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeCode")})
            Me.LabelDetail_Office.LocationFloat = New DevExpress.Utils.PointFloat(539.7915!, 0.0!)
            Me.LabelDetail_Office.Name = "LabelDetail_Office"
            Me.LabelDetail_Office.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Office.SizeF = New System.Drawing.SizeF(40.62494!, 18.99999!)
            Me.LabelDetail_Office.Text = "LabelDetail_Office"
            '
            'LabelDetail_PostPeriod
            '
            Me.LabelDetail_PostPeriod.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PostPeriodCode")})
            Me.LabelDetail_PostPeriod.LocationFloat = New DevExpress.Utils.PointFloat(470.0833!, 0.0!)
            Me.LabelDetail_PostPeriod.Name = "LabelDetail_PostPeriod"
            Me.LabelDetail_PostPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_PostPeriod.SizeF = New System.Drawing.SizeF(64.70819!, 18.99999!)
            Me.LabelDetail_PostPeriod.Text = "LabelDetail_PostPeriod"
            '
            'LabelDetail_InvoiceAmount
            '
            Me.LabelDetail_InvoiceAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceAmount", "{0:n2}")})
            Me.LabelDetail_InvoiceAmount.LocationFloat = New DevExpress.Utils.PointFloat(365.0833!, 0.0!)
            Me.LabelDetail_InvoiceAmount.Name = "LabelDetail_InvoiceAmount"
            Me.LabelDetail_InvoiceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceAmount.SizeF = New System.Drawing.SizeF(100.0001!, 18.99999!)
            Me.LabelDetail_InvoiceAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_InvoiceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_InvoiceDate
            '
            Me.LabelDetail_InvoiceDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelDetail_InvoiceDate.LocationFloat = New DevExpress.Utils.PointFloat(289.1249!, 0.0!)
            Me.LabelDetail_InvoiceDate.Name = "LabelDetail_InvoiceDate"
            Me.LabelDetail_InvoiceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceDate.SizeF = New System.Drawing.SizeF(70.95844!, 18.99999!)
            '
            'LabelDetail_InvoiceDescription
            '
            Me.LabelDetail_InvoiceDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDescription")})
            Me.LabelDetail_InvoiceDescription.LocationFloat = New DevExpress.Utils.PointFloat(135.0834!, 0.0!)
            Me.LabelDetail_InvoiceDescription.Name = "LabelDetail_InvoiceDescription"
            Me.LabelDetail_InvoiceDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceDescription.SizeF = New System.Drawing.SizeF(151.0415!, 18.99999!)
            Me.LabelDetail_InvoiceDescription.Text = "LabelDetail_InvoiceDescription"
            '
            'LabelDetail_FunctionLabel
            '
            Me.LabelDetail_FunctionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_FunctionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_FunctionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_FunctionLabel.BorderWidth = 1.0!
            Me.LabelDetail_FunctionLabel.CanGrow = False
            Me.LabelDetail_FunctionLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_FunctionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_FunctionLabel.LocationFloat = New DevExpress.Utils.PointFloat(703.7499!, 10.00001!)
            Me.LabelDetail_FunctionLabel.Name = "LabelDetail_FunctionLabel"
            Me.LabelDetail_FunctionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_FunctionLabel.SizeF = New System.Drawing.SizeF(53.125!, 19.0!)
            Me.LabelDetail_FunctionLabel.StylePriority.UseFont = False
            Me.LabelDetail_FunctionLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_FunctionLabel.Text = "Function"
            Me.LabelDetail_FunctionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TermsLabel
            '
            Me.LabelDetail_TermsLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TermsLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TermsLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TermsLabel.BorderWidth = 1.0!
            Me.LabelDetail_TermsLabel.CanGrow = False
            Me.LabelDetail_TermsLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_TermsLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TermsLabel.LocationFloat = New DevExpress.Utils.PointFloat(470.0834!, 10.00001!)
            Me.LabelDetail_TermsLabel.Name = "LabelDetail_TermsLabel"
            Me.LabelDetail_TermsLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TermsLabel.SizeF = New System.Drawing.SizeF(64.70819!, 19.0!)
            Me.LabelDetail_TermsLabel.StylePriority.UseFont = False
            Me.LabelDetail_TermsLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_TermsLabel.Text = "Post Period"
            Me.LabelDetail_TermsLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_OfficeLabel
            '
            Me.LabelDetail_OfficeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_OfficeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_OfficeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_OfficeLabel.BorderWidth = 1.0!
            Me.LabelDetail_OfficeLabel.CanGrow = False
            Me.LabelDetail_OfficeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_OfficeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_OfficeLabel.LocationFloat = New DevExpress.Utils.PointFloat(539.7915!, 10.00001!)
            Me.LabelDetail_OfficeLabel.Name = "LabelDetail_OfficeLabel"
            Me.LabelDetail_OfficeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_OfficeLabel.SizeF = New System.Drawing.SizeF(40.62494!, 19.0!)
            Me.LabelDetail_OfficeLabel.StylePriority.UseFont = False
            Me.LabelDetail_OfficeLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_OfficeLabel.Text = "Office"
            Me.LabelDetail_OfficeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_AmountLabel
            '
            Me.LabelDetail_AmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_AmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_AmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_AmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_AmountLabel.CanGrow = False
            Me.LabelDetail_AmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_AmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_AmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(365.0834!, 10.00001!)
            Me.LabelDetail_AmountLabel.Name = "LabelDetail_AmountLabel"
            Me.LabelDetail_AmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_AmountLabel.SizeF = New System.Drawing.SizeF(99.99997!, 19.0!)
            Me.LabelDetail_AmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_AmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_AmountLabel.Text = "Invoice Amount"
            Me.LabelDetail_AmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_InvoiceLabel
            '
            Me.LabelDetail_InvoiceLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InvoiceLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InvoiceLabel.BorderWidth = 1.0!
            Me.LabelDetail_InvoiceLabel.CanGrow = False
            Me.LabelDetail_InvoiceLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_InvoiceLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceLabel.LocationFloat = New DevExpress.Utils.PointFloat(17.62505!, 10.00001!)
            Me.LabelDetail_InvoiceLabel.Name = "LabelDetail_InvoiceLabel"
            Me.LabelDetail_InvoiceLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceLabel.SizeF = New System.Drawing.SizeF(111.4583!, 19.0!)
            Me.LabelDetail_InvoiceLabel.StylePriority.UseFont = False
            Me.LabelDetail_InvoiceLabel.Text = "Invoice Number"
            Me.LabelDetail_InvoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DateLabel
            '
            Me.LabelDetail_DateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DateLabel.BorderWidth = 1.0!
            Me.LabelDetail_DateLabel.CanGrow = False
            Me.LabelDetail_DateLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DateLabel.LocationFloat = New DevExpress.Utils.PointFloat(289.125!, 10.00001!)
            Me.LabelDetail_DateLabel.Name = "LabelDetail_DateLabel"
            Me.LabelDetail_DateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DateLabel.SizeF = New System.Drawing.SizeF(70.95837!, 19.0!)
            Me.LabelDetail_DateLabel.StylePriority.UseFont = False
            Me.LabelDetail_DateLabel.Text = "Invoice Date"
            Me.LabelDetail_DateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_ExtAmountLabel
            '
            Me.LabelDetail_ExtAmountLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ExtAmountLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ExtAmountLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ExtAmountLabel.BorderWidth = 1.0!
            Me.LabelDetail_ExtAmountLabel.CanGrow = False
            Me.LabelDetail_ExtAmountLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ExtAmountLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ExtAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(761.8749!, 10.41667!)
            Me.LabelDetail_ExtAmountLabel.Name = "LabelDetail_ExtAmountLabel"
            Me.LabelDetail_ExtAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_ExtAmountLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelDetail_ExtAmountLabel.StylePriority.UseFont = False
            Me.LabelDetail_ExtAmountLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ExtAmountLabel.Text = "Extended Amount"
            Me.LabelDetail_ExtAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_GLCodeLabel
            '
            Me.LabelDetail_GLCodeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_GLCodeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_GLCodeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_GLCodeLabel.BorderWidth = 1.0!
            Me.LabelDetail_GLCodeLabel.CanGrow = False
            Me.LabelDetail_GLCodeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_GLCodeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_GLCodeLabel.LocationFloat = New DevExpress.Utils.PointFloat(873.125!, 10.00001!)
            Me.LabelDetail_GLCodeLabel.Name = "LabelDetail_GLCodeLabel"
            Me.LabelDetail_GLCodeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_GLCodeLabel.SizeF = New System.Drawing.SizeF(125.8751!, 19.0!)
            Me.LabelDetail_GLCodeLabel.StylePriority.UseFont = False
            Me.LabelDetail_GLCodeLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_GLCodeLabel.Text = "GLA Code"
            Me.LabelDetail_GLCodeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DiscountPercentLabel
            '
            Me.LabelDetail_DiscountPercentLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DiscountPercentLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DiscountPercentLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DiscountPercentLabel.BorderWidth = 1.0!
            Me.LabelDetail_DiscountPercentLabel.CanGrow = False
            Me.LabelDetail_DiscountPercentLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DiscountPercentLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DiscountPercentLabel.LocationFloat = New DevExpress.Utils.PointFloat(585.4164!, 10.00001!)
            Me.LabelDetail_DiscountPercentLabel.Name = "LabelDetail_DiscountPercentLabel"
            Me.LabelDetail_DiscountPercentLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DiscountPercentLabel.SizeF = New System.Drawing.SizeF(59.37506!, 19.0!)
            Me.LabelDetail_DiscountPercentLabel.StylePriority.UseFont = False
            Me.LabelDetail_DiscountPercentLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_DiscountPercentLabel.Text = "Job"
            Me.LabelDetail_DiscountPercentLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineReportFooter_1
            '
            Me.LineReportFooter_1.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_1.BorderWidth = 0.0!
            Me.LineReportFooter_1.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 2.0!)
            Me.LineReportFooter_1.Name = "LineReportFooter_1"
            Me.LineReportFooter_1.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineReportFooter_1.StylePriority.UseBorderColor = False
            Me.LineReportFooter_1.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_1.StylePriority.UseForeColor = False
            '
            'LineReportFooter_2
            '
            Me.LineReportFooter_2.BorderColor = System.Drawing.Color.Black
            Me.LineReportFooter_2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineReportFooter_2.BorderWidth = 0.0!
            Me.LineReportFooter_2.ForeColor = System.Drawing.Color.Gray
            Me.LineReportFooter_2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LineReportFooter_2.Name = "LineReportFooter_2"
            Me.LineReportFooter_2.SizeF = New System.Drawing.SizeF(999.9999!, 2.0!)
            Me.LineReportFooter_2.StylePriority.UseBorderColor = False
            Me.LineReportFooter_2.StylePriority.UseBorderWidth = False
            Me.LineReportFooter_2.StylePriority.UseForeColor = False
            '
            'LabelReportFooter_BatchTotalLabel
            '
            Me.LabelReportFooter_BatchTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportFooter_BatchTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportFooter_BatchTotalLabel.BorderWidth = 1.0!
            Me.LabelReportFooter_BatchTotalLabel.CanGrow = False
            Me.LabelReportFooter_BatchTotalLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_BatchTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelReportFooter_BatchTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(641.2549!, 3.999996!)
            Me.LabelReportFooter_BatchTotalLabel.Name = "LabelReportFooter_BatchTotalLabel"
            Me.LabelReportFooter_BatchTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportFooter_BatchTotalLabel.SizeF = New System.Drawing.SizeF(115.62!, 19.0!)
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseFont = False
            Me.LabelReportFooter_BatchTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelReportFooter_BatchTotalLabel.Text = "Batch Total:"
            Me.LabelReportFooter_BatchTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_Agency, Me.LinePageHeader_Bottom, Me.LinePageHeader_Top, Me.LabelPageHeader_ReportCriteria, Me.LabelPageHeader_ReportTitle})
            Me.PageHeader.HeightF = 54.16672!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StylePriority.UseTextAlignment = False
            Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1.0!
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(512.4999!, 4.083347!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(486.5002!, 18.58334!)
            Me.LabelPageHeader_Agency.StylePriority.UseBackColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.Text = "Account Payable Expense Reports Approved"
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LinePageHeader_Bottom
            '
            Me.LinePageHeader_Bottom.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Bottom.BorderWidth = 4.0!
            Me.LinePageHeader_Bottom.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Bottom.LineWidth = 4
            Me.LinePageHeader_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 50.08337!)
            Me.LinePageHeader_Bottom.Name = "LinePageHeader_Bottom"
            Me.LinePageHeader_Bottom.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LinePageHeader_Top
            '
            Me.LinePageHeader_Top.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_Top.BorderWidth = 4.0!
            Me.LinePageHeader_Top.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_Top.LineWidth = 4
            Me.LinePageHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LinePageHeader_Top.Name = "LinePageHeader_Top"
            Me.LinePageHeader_Top.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageHeader_ReportCriteria
            '
            Me.LabelPageHeader_ReportCriteria.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportCriteria.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportCriteria.BorderWidth = 1.0!
            Me.LabelPageHeader_ReportCriteria.CanGrow = False
            Me.LabelPageHeader_ReportCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportCriteria.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportCriteria.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 33.08335!)
            Me.LabelPageHeader_ReportCriteria.Name = "LabelPageHeader_ReportCriteria"
            Me.LabelPageHeader_ReportCriteria.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportCriteria.SizeF = New System.Drawing.SizeF(501.0417!, 17.00001!)
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportCriteria.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportCriteria.Text = "For:"
            Me.LabelPageHeader_ReportCriteria.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_ReportTitle
            '
            Me.LabelPageHeader_ReportTitle.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ReportTitle.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ReportTitle.BorderWidth = 1.0!
            Me.LabelPageHeader_ReportTitle.CanGrow = False
            Me.LabelPageHeader_ReportTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_ReportTitle.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 4.083347!)
            Me.LabelPageHeader_ReportTitle.Name = "LabelPageHeader_ReportTitle"
            Me.LabelPageHeader_ReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ReportTitle.SizeF = New System.Drawing.SizeF(501.0417!, 29.00001!)
            Me.LabelPageHeader_ReportTitle.StylePriority.UseBackColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseFont = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseForeColor = False
            Me.LabelPageHeader_ReportTitle.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_ReportTitle.Text = "Account Payable Expense Reports Approved"
            Me.LabelPageHeader_ReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelReportFooter_SumAmount, Me.LineReportFooter_2, Me.LabelReportFooter_BatchTotalLabel, Me.LineReportFooter_1})
            Me.ReportFooter.HeightF = 36.37498!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'LabelReportFooter_SumAmount
            '
            Me.LabelReportFooter_SumAmount.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelReportFooter_SumAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.LabelReportFooter_SumAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelReportFooter_SumAmount.LocationFloat = New DevExpress.Utils.PointFloat(761.8749!, 3.999996!)
            Me.LabelReportFooter_SumAmount.Name = "LabelReportFooter_SumAmount"
            Me.LabelReportFooter_SumAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelReportFooter_SumAmount.SizeF = New System.Drawing.SizeF(106.25!, 18.99999!)
            Me.LabelReportFooter_SumAmount.StylePriority.UseBorders = False
            Me.LabelReportFooter_SumAmount.StylePriority.UseFont = False
            Me.LabelReportFooter_SumAmount.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelReportFooter_SumAmount.Summary = XrSummary1
            Me.LabelReportFooter_SumAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(863.5417!, 4.083347!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_Note, Me.LinePageFooter, Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 25.08332!
            Me.PageFooter.Name = "PageFooter"
            '
            'LabelPageFooter_Note
            '
            Me.LabelPageFooter_Note.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_Note.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Note.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_Note.BorderWidth = 1.0!
            Me.LabelPageFooter_Note.CanGrow = False
            Me.LabelPageFooter_Note.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_Note.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Note.LocationFloat = New DevExpress.Utils.PointFloat(470.0833!, 4.083379!)
            Me.LabelPageFooter_Note.Name = "LabelPageFooter_Note"
            Me.LabelPageFooter_Note.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_Note.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_Note.StylePriority.UseFont = False
            Me.LabelPageFooter_Note.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Note.Text = "* Indicates Deleted Invoice"
            Me.LabelPageFooter_Note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LinePageFooter
            '
            Me.LinePageFooter.BorderColor = System.Drawing.Color.Silver
            Me.LinePageFooter.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageFooter.BorderWidth = 4.0!
            Me.LinePageFooter.ForeColor = System.Drawing.Color.Silver
            Me.LinePageFooter.LineWidth = 4
            Me.LinePageFooter.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LinePageFooter.Name = "LinePageFooter"
            Me.LinePageFooter.SizeF = New System.Drawing.SizeF(999.0!, 4.083347!)
            '
            'LabelPageFooter_UserCode
            '
            Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_UserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_UserCode.CanGrow = False
            Me.LabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_UserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 4.083347!)
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
            Me.LabelPageFooter_Date.BorderWidth = 1.0!
            Me.LabelPageFooter_Date.CanGrow = False
            Me.LabelPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 4.083379!)
            Me.LabelPageFooter_Date.Name = "LabelPageFooter_Date"
            Me.LabelPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_Date.SizeF = New System.Drawing.SizeF(234.9999!, 19.0!)
            Me.LabelPageFooter_Date.StylePriority.UseFont = False
            Me.LabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeader_VendorCode
            '
            Me.GroupHeader_VendorCode.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2, Me.XrLabel1, Me.XrLabel3, Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel, Me.LabelGroupHeaderVendorCode_VendorLabel, Me.LabelGroupHeaderVendorCode_EmployeeLabel})
            Me.GroupHeader_VendorCode.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("VendorCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader_VendorCode.HeightF = 19.0!
            Me.GroupHeader_VendorCode.Level = 1
            Me.GroupHeader_VendorCode.Name = "GroupHeader_VendorCode"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeDepartmentTeamCode")})
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(861.8749!, 0.0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(77.08344!, 19.0!)
            Me.XrLabel2.Text = "XrLabel2"
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCodeName")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(421.3334!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(335.5415!, 19.0!)
            Me.XrLabel1.Text = "XrLabel1"
            '
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeCodeName")})
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(69.79166!, 0.0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(277.0833!, 19.0!)
            Me.XrLabel3.Text = "XrLabel3"
            '
            'LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel
            '
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.CanGrow = False
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.LocationFloat = New DevExpress.Utils.PointFloat(761.8749!, 0.0!)
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.Name = "LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel"
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.Text = "Employee Dept:"
            Me.LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderVendorCode_VendorLabel
            '
            Me.LabelGroupHeaderVendorCode_VendorLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_VendorLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_VendorLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_VendorLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_VendorLabel.CanGrow = False
            Me.LabelGroupHeaderVendorCode_VendorLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderVendorCode_VendorLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_VendorLabel.LocationFloat = New DevExpress.Utils.PointFloat(365.0834!, 0.0!)
            Me.LabelGroupHeaderVendorCode_VendorLabel.Name = "LabelGroupHeaderVendorCode_VendorLabel"
            Me.LabelGroupHeaderVendorCode_VendorLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_VendorLabel.SizeF = New System.Drawing.SizeF(56.25!, 19.0!)
            Me.LabelGroupHeaderVendorCode_VendorLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_VendorLabel.Text = "Vendor:"
            Me.LabelGroupHeaderVendorCode_VendorLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeaderVendorCode_EmployeeLabel
            '
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.BorderWidth = 1.0!
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.CanGrow = False
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.Name = "LabelGroupHeaderVendorCode_EmployeeLabel"
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.SizeF = New System.Drawing.SizeF(69.79166!, 19.0!)
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.StylePriority.UseFont = False
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.Text = "Employee:"
            Me.LabelGroupHeaderVendorCode_EmployeeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeader_InvoiceNumber
            '
            Me.GroupHeader_InvoiceNumber.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineGroupHeaderInvoiceNumber_Break, Me.LabelDetail_JobCompLabel, Me.LabelDetail_InvoiceDescLabel, Me.LabelDetail_InvoiceLabel, Me.LabelDetail_DateLabel, Me.LabelDetail_AmountLabel, Me.LabelDetail_OfficeLabel, Me.LabelDetail_TermsLabel, Me.LabelDetail_DiscountPercentLabel, Me.LabelDetail_FunctionLabel, Me.LabelDetail_ExtAmountLabel, Me.LabelDetail_GLCodeLabel})
            Me.GroupHeader_InvoiceNumber.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader_InvoiceNumber.HeightF = 31.41667!
            Me.GroupHeader_InvoiceNumber.Name = "GroupHeader_InvoiceNumber"
            '
            'LineGroupHeaderInvoiceNumber_Break
            '
            Me.LineGroupHeaderInvoiceNumber_Break.BorderColor = System.Drawing.Color.Silver
            Me.LineGroupHeaderInvoiceNumber_Break.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderInvoiceNumber_Break.BorderWidth = 1.0!
            Me.LineGroupHeaderInvoiceNumber_Break.ForeColor = System.Drawing.Color.Silver
            Me.LineGroupHeaderInvoiceNumber_Break.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 29.41667!)
            Me.LineGroupHeaderInvoiceNumber_Break.Name = "LineGroupHeaderInvoiceNumber_Break"
            Me.LineGroupHeaderInvoiceNumber_Break.SizeF = New System.Drawing.SizeF(1000.0!, 2.0!)
            Me.LineGroupHeaderInvoiceNumber_Break.StylePriority.UseBorderWidth = False
            '
            'LabelDetail_JobCompLabel
            '
            Me.LabelDetail_JobCompLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_JobCompLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_JobCompLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_JobCompLabel.BorderWidth = 1.0!
            Me.LabelDetail_JobCompLabel.CanGrow = False
            Me.LabelDetail_JobCompLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_JobCompLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_JobCompLabel.LocationFloat = New DevExpress.Utils.PointFloat(649.7913!, 0.0!)
            Me.LabelDetail_JobCompLabel.Name = "LabelDetail_JobCompLabel"
            Me.LabelDetail_JobCompLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_JobCompLabel.SizeF = New System.Drawing.SizeF(48.9585!, 29.41667!)
            Me.LabelDetail_JobCompLabel.StylePriority.UseFont = False
            Me.LabelDetail_JobCompLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_JobCompLabel.Text = "Job Comp"
            Me.LabelDetail_JobCompLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InvoiceDescLabel
            '
            Me.LabelDetail_InvoiceDescLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InvoiceDescLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceDescLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InvoiceDescLabel.BorderWidth = 1.0!
            Me.LabelDetail_InvoiceDescLabel.CanGrow = False
            Me.LabelDetail_InvoiceDescLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_InvoiceDescLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InvoiceDescLabel.LocationFloat = New DevExpress.Utils.PointFloat(135.0834!, 10.00001!)
            Me.LabelDetail_InvoiceDescLabel.Name = "LabelDetail_InvoiceDescLabel"
            Me.LabelDetail_InvoiceDescLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InvoiceDescLabel.SizeF = New System.Drawing.SizeF(151.0416!, 19.0!)
            Me.LabelDetail_InvoiceDescLabel.StylePriority.UseFont = False
            Me.LabelDetail_InvoiceDescLabel.Text = "Invoice Description"
            Me.LabelDetail_InvoiceDescLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'VendorCodeName
            '
            Me.VendorCodeName.Expression = "[VendorCode] + ' - ' + [VendorName]"
            Me.VendorCodeName.Name = "VendorCodeName"
            '
            'GroupFooter_VendorCode
            '
            Me.GroupFooter_VendorCode.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterVendorCode_TotalForVendor, Me.LabelGroupFooterVendorCode_AmountSum})
            Me.GroupFooter_VendorCode.HeightF = 21.08332!
            Me.GroupFooter_VendorCode.Level = 1
            Me.GroupFooter_VendorCode.Name = "GroupFooter_VendorCode"
            '
            'LabelGroupFooterVendorCode_TotalForVendor
            '
            Me.LabelGroupFooterVendorCode_TotalForVendor.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalForEmployee")})
            Me.LabelGroupFooterVendorCode_TotalForVendor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterVendorCode_TotalForVendor.LocationFloat = New DevExpress.Utils.PointFloat(265.1667!, 0.0!)
            Me.LabelGroupFooterVendorCode_TotalForVendor.Name = "LabelGroupFooterVendorCode_TotalForVendor"
            Me.LabelGroupFooterVendorCode_TotalForVendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterVendorCode_TotalForVendor.SizeF = New System.Drawing.SizeF(491.7082!, 18.99999!)
            Me.LabelGroupFooterVendorCode_TotalForVendor.StylePriority.UseFont = False
            Me.LabelGroupFooterVendorCode_TotalForVendor.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterVendorCode_TotalForVendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterVendorCode_AmountSum
            '
            Me.LabelGroupFooterVendorCode_AmountSum.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooterVendorCode_AmountSum.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.LabelGroupFooterVendorCode_AmountSum.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterVendorCode_AmountSum.LocationFloat = New DevExpress.Utils.PointFloat(761.8749!, 0.0!)
            Me.LabelGroupFooterVendorCode_AmountSum.Name = "LabelGroupFooterVendorCode_AmountSum"
            Me.LabelGroupFooterVendorCode_AmountSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterVendorCode_AmountSum.SizeF = New System.Drawing.SizeF(106.25!, 18.99999!)
            Me.LabelGroupFooterVendorCode_AmountSum.StylePriority.UseBorders = False
            Me.LabelGroupFooterVendorCode_AmountSum.StylePriority.UseFont = False
            Me.LabelGroupFooterVendorCode_AmountSum.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterVendorCode_AmountSum.Summary = XrSummary2
            Me.LabelGroupFooterVendorCode_AmountSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupFooter_InvoiceNumber
            '
            Me.GroupFooter_InvoiceNumber.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterInvoiceNumber_TotalForInvoice, Me.LabelGroupFooterInvoiceNumber_AmountSum})
            Me.GroupFooter_InvoiceNumber.HeightF = 22.12499!
            Me.GroupFooter_InvoiceNumber.Name = "GroupFooter_InvoiceNumber"
            '
            'LabelGroupFooterInvoiceNumber_TotalForInvoice
            '
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalForInvoice")})
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.LocationFloat = New DevExpress.Utils.PointFloat(265.1667!, 0.0!)
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.Name = "LabelGroupFooterInvoiceNumber_TotalForInvoice"
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.SizeF = New System.Drawing.SizeF(491.7083!, 18.99999!)
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.StylePriority.UseFont = False
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.Text = "LabelGroupFooterInvoiceNumber_TotalForInvoice"
            Me.LabelGroupFooterInvoiceNumber_TotalForInvoice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterInvoiceNumber_AmountSum
            '
            Me.LabelGroupFooterInvoiceNumber_AmountSum.Borders = DevExpress.XtraPrinting.BorderSide.Top
            Me.LabelGroupFooterInvoiceNumber_AmountSum.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount", "{0:n2}")})
            Me.LabelGroupFooterInvoiceNumber_AmountSum.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterInvoiceNumber_AmountSum.LocationFloat = New DevExpress.Utils.PointFloat(761.8749!, 0.0!)
            Me.LabelGroupFooterInvoiceNumber_AmountSum.Name = "LabelGroupFooterInvoiceNumber_AmountSum"
            Me.LabelGroupFooterInvoiceNumber_AmountSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterInvoiceNumber_AmountSum.SizeF = New System.Drawing.SizeF(106.25!, 18.99999!)
            Me.LabelGroupFooterInvoiceNumber_AmountSum.StylePriority.UseBorders = False
            Me.LabelGroupFooterInvoiceNumber_AmountSum.StylePriority.UseFont = False
            Me.LabelGroupFooterInvoiceNumber_AmountSum.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelGroupFooterInvoiceNumber_AmountSum.Summary = XrSummary3
            Me.LabelGroupFooterInvoiceNumber_AmountSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TotalForInvoice
            '
            Me.TotalForInvoice.Expression = "'Total for ' + [InvoiceNumber]"
            Me.TotalForInvoice.Name = "TotalForInvoice"
            '
            'TotalForEmployee
            '
            Me.TotalForEmployee.Expression = "'Total for ' + [EmployeeName]"
            Me.TotalForEmployee.Name = "TotalForEmployee"
            '
            'IsDeleted
            '
            Me.IsDeleted.Expression = "Iif([IsDeletedInvoice],'*'  ,'' )"
            Me.IsDeleted.Name = "IsDeleted"
            '
            'EmployeeCodeName
            '
            Me.EmployeeCodeName.Expression = "[EmployeeCode] + ' - ' + [EmployeeName]"
            Me.EmployeeCodeName.Name = "EmployeeCodeName"
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseImportBatchReport)
            '
            'AccountPayableImportExpenseReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter, Me.GroupHeader_VendorCode, Me.GroupHeader_InvoiceNumber, Me.GroupFooter_VendorCode, Me.GroupFooter_InvoiceNumber})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.VendorCodeName, Me.EmployeeCodeName, Me.TotalForInvoice, Me.TotalForEmployee, Me.IsDeleted})
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
        Private WithEvents LabelPageHeader_ReportTitle As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_DateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_InvoiceLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ExtAmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_GLCodeLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DiscountPercentLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_ReportCriteria As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Private WithEvents LabelDetail_AmountLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_FunctionLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_TermsLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_OfficeLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelReportFooter_BatchTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineReportFooter_2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineReportFooter_1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Top As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageFooter As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LinePageHeader_Bottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader_VendorCode As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelGroupHeaderVendorCode_EmployeeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader_InvoiceNumber As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents LabelDetail_InvoiceDescLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents VendorCodeName As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LabelDetail_Amount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Function As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_InvoiceNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_JobComp As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_JobNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Office As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PostPeriod As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_JobCompLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_GLACode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter_VendorCode As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupFooter_InvoiceNumber As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelReportFooter_SumAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterVendorCode_AmountSum As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterInvoiceNumber_AmountSum As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterVendorCode_TotalForVendor As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterInvoiceNumber_TotalForInvoice As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TotalForInvoice As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TotalForEmployee As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents LineGroupHeaderInvoiceNumber_Break As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetail_IsDeleted As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents IsDeleted As DevExpress.XtraReports.UI.CalculatedField
        Private WithEvents LabelPageFooter_Note As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents EmployeeCodeName As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderVendorCode_EmployeeDeptTeamLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeaderVendorCode_VendorLabel As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
