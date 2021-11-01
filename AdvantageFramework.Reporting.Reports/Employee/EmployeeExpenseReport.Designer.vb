Namespace Employee

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class EmployeeExpenseReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelCreatedDate_CreatedDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelCreatedDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelSignatureDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.PictureBoxApproverSignature = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.PictureBoxEmployeeSignature = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.LabelApproverSignature = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelEmployeeSignature = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubreportExpenseItems = New DevExpress.XtraReports.UI.XRSubreport()
            Me.LabelApprove = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelCertify = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelExpenseItems = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineExpenseItems = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelReportNumber_ReportNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetails_Details = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportDate_ReportDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelStatus_Status = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetails = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelStatus = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDescription_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelEmployee_Employee = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelEmployee = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelReportNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineEmployeeSignatureLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LineApproverSignatureLine = New DevExpress.XtraReports.UI.XRLine()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.LabelPageFooter_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageFooter_UserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LineHeaderBottomLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelCreatedDate_CreatedDate, Me.LabelCreatedDate, Me.LabelSignatureDate, Me.PictureBoxApproverSignature, Me.PictureBoxEmployeeSignature, Me.LabelApproverSignature, Me.LabelEmployeeSignature, Me.SubreportExpenseItems, Me.LabelApprove, Me.LabelCertify, Me.LabelExpenseItems, Me.LineExpenseItems, Me.LabelReportNumber_ReportNumber, Me.LabelDetails_Details, Me.LabelReportDate_ReportDate, Me.LabelStatus_Status, Me.LabelDetails, Me.LabelReportDate, Me.LabelStatus, Me.LabelDescription_Description, Me.LabelDescription, Me.LabelEmployee_Employee, Me.LabelEmployee, Me.LabelReportNumber, Me.LineEmployeeSignatureLine, Me.LineApproverSignatureLine})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 400.25!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelCreatedDate_CreatedDate
            '
            Me.LabelCreatedDate_CreatedDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelCreatedDate_CreatedDate.BorderColor = System.Drawing.Color.Black
            Me.LabelCreatedDate_CreatedDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCreatedDate_CreatedDate.BorderWidth = 1.0!
            Me.LabelCreatedDate_CreatedDate.CanGrow = False
            Me.LabelCreatedDate_CreatedDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreatedDate", "{0:d}")})
            Me.LabelCreatedDate_CreatedDate.Dpi = 100.0!
            Me.LabelCreatedDate_CreatedDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCreatedDate_CreatedDate.LocationFloat = New DevExpress.Utils.PointFloat(109.7918!, 83.99998!)
            Me.LabelCreatedDate_CreatedDate.Name = "LabelCreatedDate_CreatedDate"
            Me.LabelCreatedDate_CreatedDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelCreatedDate_CreatedDate.SizeF = New System.Drawing.SizeF(241.6657!, 19.0!)
            Me.LabelCreatedDate_CreatedDate.StylePriority.UseFont = False
            Me.LabelCreatedDate_CreatedDate.Text = "LabelCreatedDate_CreatedDate"
            Me.LabelCreatedDate_CreatedDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelCreatedDate
            '
            Me.LabelCreatedDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelCreatedDate.BorderColor = System.Drawing.Color.Black
            Me.LabelCreatedDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCreatedDate.BorderWidth = 1.0!
            Me.LabelCreatedDate.CanGrow = False
            Me.LabelCreatedDate.Dpi = 100.0!
            Me.LabelCreatedDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCreatedDate.ForeColor = System.Drawing.Color.Black
            Me.LabelCreatedDate.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 83.99998!)
            Me.LabelCreatedDate.Name = "LabelCreatedDate"
            Me.LabelCreatedDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelCreatedDate.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.LabelCreatedDate.StylePriority.UseFont = False
            Me.LabelCreatedDate.Text = "Created Date:"
            Me.LabelCreatedDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelSignatureDate
            '
            Me.LabelSignatureDate.Dpi = 100.0!
            Me.LabelSignatureDate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelSignatureDate.LocationFloat = New DevExpress.Utils.PointFloat(240.5001!, 324.4164!)
            Me.LabelSignatureDate.Name = "LabelSignatureDate"
            Me.LabelSignatureDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelSignatureDate.SizeF = New System.Drawing.SizeF(72.95834!, 18.0!)
            Me.LabelSignatureDate.StylePriority.UseFont = False
            Me.LabelSignatureDate.Text = "LabelSignatureDate"
            '
            'PictureBoxApproverSignature
            '
            Me.PictureBoxApproverSignature.Dpi = 100.0!
            Me.PictureBoxApproverSignature.LocationFloat = New DevExpress.Utils.PointFloat(436.5417!, 260.9166!)
            Me.PictureBoxApproverSignature.Name = "PictureBoxApproverSignature"
            Me.PictureBoxApproverSignature.SizeF = New System.Drawing.SizeF(303.4584!, 81.49988!)
            '
            'PictureBoxEmployeeSignature
            '
            Me.PictureBoxEmployeeSignature.Dpi = 100.0!
            Me.PictureBoxEmployeeSignature.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 260.9165!)
            Me.PictureBoxEmployeeSignature.Name = "PictureBoxEmployeeSignature"
            Me.PictureBoxEmployeeSignature.SizeF = New System.Drawing.SizeF(230.5!, 81.49988!)
            '
            'LabelApproverSignature
            '
            Me.LabelApproverSignature.BackColor = System.Drawing.Color.Transparent
            Me.LabelApproverSignature.BorderColor = System.Drawing.Color.Black
            Me.LabelApproverSignature.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelApproverSignature.BorderWidth = 1.0!
            Me.LabelApproverSignature.Dpi = 100.0!
            Me.LabelApproverSignature.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelApproverSignature.LocationFloat = New DevExpress.Utils.PointFloat(436.5417!, 365.4165!)
            Me.LabelApproverSignature.Name = "LabelApproverSignature"
            Me.LabelApproverSignature.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelApproverSignature.SizeF = New System.Drawing.SizeF(303.4584!, 19.0!)
            Me.LabelApproverSignature.StylePriority.UseFont = False
            Me.LabelApproverSignature.Text = "Approver Signature / Date"
            Me.LabelApproverSignature.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelEmployeeSignature
            '
            Me.LabelEmployeeSignature.BackColor = System.Drawing.Color.Transparent
            Me.LabelEmployeeSignature.BorderColor = System.Drawing.Color.Black
            Me.LabelEmployeeSignature.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelEmployeeSignature.BorderWidth = 1.0!
            Me.LabelEmployeeSignature.CanGrow = False
            Me.LabelEmployeeSignature.Dpi = 100.0!
            Me.LabelEmployeeSignature.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelEmployeeSignature.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 365.4165!)
            Me.LabelEmployeeSignature.Name = "LabelEmployeeSignature"
            Me.LabelEmployeeSignature.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelEmployeeSignature.SizeF = New System.Drawing.SizeF(303.4584!, 19.0!)
            Me.LabelEmployeeSignature.StylePriority.UseFont = False
            Me.LabelEmployeeSignature.Text = "Employee Signature / Date"
            Me.LabelEmployeeSignature.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SubreportExpenseItems
            '
            Me.SubreportExpenseItems.Dpi = 100.0!
            Me.SubreportExpenseItems.LocationFloat = New DevExpress.Utils.PointFloat(0!, 171.5833!)
            Me.SubreportExpenseItems.Name = "SubreportExpenseItems"
            Me.SubreportExpenseItems.ReportSource = New AdvantageFramework.Reporting.Reports.Employee.ExpenseItemsSubReport()
            Me.SubreportExpenseItems.SizeF = New System.Drawing.SizeF(749.0004!, 23.0!)
            '
            'LabelApprove
            '
            Me.LabelApprove.BackColor = System.Drawing.Color.Transparent
            Me.LabelApprove.BorderColor = System.Drawing.Color.Black
            Me.LabelApprove.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelApprove.BorderWidth = 1.0!
            Me.LabelApprove.CanGrow = False
            Me.LabelApprove.Dpi = 100.0!
            Me.LabelApprove.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelApprove.ForeColor = System.Drawing.Color.Black
            Me.LabelApprove.LocationFloat = New DevExpress.Utils.PointFloat(436.5412!, 217.9582!)
            Me.LabelApprove.Name = "LabelApprove"
            Me.LabelApprove.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelApprove.SizeF = New System.Drawing.SizeF(303.4584!, 30.45834!)
            Me.LabelApprove.StylePriority.UseFont = False
            Me.LabelApprove.Text = "I have reviewed and approved this expense report for accuracy and reasonableness." &
    ""
            Me.LabelApprove.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelCertify
            '
            Me.LabelCertify.BackColor = System.Drawing.Color.Transparent
            Me.LabelCertify.BorderColor = System.Drawing.Color.Black
            Me.LabelCertify.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCertify.BorderWidth = 1.0!
            Me.LabelCertify.CanGrow = False
            Me.LabelCertify.Dpi = 100.0!
            Me.LabelCertify.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCertify.ForeColor = System.Drawing.Color.Black
            Me.LabelCertify.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 217.9582!)
            Me.LabelCertify.Name = "LabelCertify"
            Me.LabelCertify.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelCertify.SizeF = New System.Drawing.SizeF(303.4584!, 30.45834!)
            Me.LabelCertify.StylePriority.UseFont = False
            Me.LabelCertify.Text = "I certify that the expenses posted on the date(s) listed are accurate and complet" &
    "e."
            Me.LabelCertify.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelExpenseItems
            '
            Me.LabelExpenseItems.Dpi = 100.0!
            Me.LabelExpenseItems.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelExpenseItems.ForeColor = System.Drawing.Color.Black
            Me.LabelExpenseItems.LocationFloat = New DevExpress.Utils.PointFloat(0!, 152.5832!)
            Me.LabelExpenseItems.Name = "LabelExpenseItems"
            Me.LabelExpenseItems.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelExpenseItems.SizeF = New System.Drawing.SizeF(148.3335!, 19.0!)
            Me.LabelExpenseItems.StylePriority.UseFont = False
            Me.LabelExpenseItems.StylePriority.UseForeColor = False
            Me.LabelExpenseItems.StylePriority.UseTextAlignment = False
            Me.LabelExpenseItems.Text = "Expense Items:"
            Me.LabelExpenseItems.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LineExpenseItems
            '
            Me.LineExpenseItems.BackColor = System.Drawing.Color.Transparent
            Me.LineExpenseItems.BorderColor = System.Drawing.Color.Transparent
            Me.LineExpenseItems.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineExpenseItems.BorderWidth = 4.0!
            Me.LineExpenseItems.Dpi = 100.0!
            Me.LineExpenseItems.ForeColor = System.Drawing.Color.Silver
            Me.LineExpenseItems.KeepTogether = False
            Me.LineExpenseItems.LineWidth = 4
            Me.LineExpenseItems.LocationFloat = New DevExpress.Utils.PointFloat(148.3335!, 152.5832!)
            Me.LineExpenseItems.Name = "LineExpenseItems"
            Me.LineExpenseItems.SizeF = New System.Drawing.SizeF(601.5423!, 19.0!)
            Me.LineExpenseItems.StylePriority.UseBackColor = False
            Me.LineExpenseItems.StylePriority.UseBorderColor = False
            '
            'LabelReportNumber_ReportNumber
            '
            Me.LabelReportNumber_ReportNumber.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportNumber_ReportNumber.BorderColor = System.Drawing.Color.Black
            Me.LabelReportNumber_ReportNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportNumber_ReportNumber.BorderWidth = 1.0!
            Me.LabelReportNumber_ReportNumber.CanGrow = False
            Me.LabelReportNumber_ReportNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceNumber")})
            Me.LabelReportNumber_ReportNumber.Dpi = 100.0!
            Me.LabelReportNumber_ReportNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportNumber_ReportNumber.LocationFloat = New DevExpress.Utils.PointFloat(109.7916!, 8.0!)
            Me.LabelReportNumber_ReportNumber.Name = "LabelReportNumber_ReportNumber"
            Me.LabelReportNumber_ReportNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportNumber_ReportNumber.SizeF = New System.Drawing.SizeF(241.6661!, 19.0!)
            Me.LabelReportNumber_ReportNumber.StylePriority.UseFont = False
            Me.LabelReportNumber_ReportNumber.Text = "LabelReportNumber_ReportNumber"
            Me.LabelReportNumber_ReportNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetails_Details
            '
            Me.LabelDetails_Details.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetails_Details.BorderColor = System.Drawing.Color.Black
            Me.LabelDetails_Details.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetails_Details.BorderWidth = 1.0!
            Me.LabelDetails_Details.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Details")})
            Me.LabelDetails_Details.Dpi = 100.0!
            Me.LabelDetails_Details.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetails_Details.LocationFloat = New DevExpress.Utils.PointFloat(109.7918!, 121.9999!)
            Me.LabelDetails_Details.Name = "LabelDetails_Details"
            Me.LabelDetails_Details.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetails_Details.SizeF = New System.Drawing.SizeF(630.2082!, 18.99999!)
            Me.LabelDetails_Details.StylePriority.UseFont = False
            Me.LabelDetails_Details.Text = "LabelDetails_Details"
            Me.LabelDetails_Details.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelReportDate_ReportDate
            '
            Me.LabelReportDate_ReportDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportDate_ReportDate.BorderColor = System.Drawing.Color.Black
            Me.LabelReportDate_ReportDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportDate_ReportDate.BorderWidth = 1.0!
            Me.LabelReportDate_ReportDate.CanGrow = False
            Me.LabelReportDate_ReportDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InvoiceDate", "{0:d}")})
            Me.LabelReportDate_ReportDate.Dpi = 100.0!
            Me.LabelReportDate_ReportDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportDate_ReportDate.LocationFloat = New DevExpress.Utils.PointFloat(109.7918!, 64.99997!)
            Me.LabelReportDate_ReportDate.Name = "LabelReportDate_ReportDate"
            Me.LabelReportDate_ReportDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportDate_ReportDate.SizeF = New System.Drawing.SizeF(241.6657!, 19.0!)
            Me.LabelReportDate_ReportDate.StylePriority.UseFont = False
            Me.LabelReportDate_ReportDate.Text = "LabelReportDate_ReportDate"
            Me.LabelReportDate_ReportDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelStatus_Status
            '
            Me.LabelStatus_Status.BackColor = System.Drawing.Color.Transparent
            Me.LabelStatus_Status.BorderColor = System.Drawing.Color.Black
            Me.LabelStatus_Status.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelStatus_Status.BorderWidth = 1.0!
            Me.LabelStatus_Status.CanGrow = False
            Me.LabelStatus_Status.Dpi = 100.0!
            Me.LabelStatus_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelStatus_Status.LocationFloat = New DevExpress.Utils.PointFloat(109.7918!, 45.99998!)
            Me.LabelStatus_Status.Name = "LabelStatus_Status"
            Me.LabelStatus_Status.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelStatus_Status.SizeF = New System.Drawing.SizeF(241.6657!, 19.0!)
            Me.LabelStatus_Status.StylePriority.UseFont = False
            Me.LabelStatus_Status.Text = "LabelStatus_Status"
            Me.LabelStatus_Status.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetails
            '
            Me.LabelDetails.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetails.BorderColor = System.Drawing.Color.Black
            Me.LabelDetails.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetails.BorderWidth = 1.0!
            Me.LabelDetails.CanGrow = False
            Me.LabelDetails.Dpi = 100.0!
            Me.LabelDetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetails.ForeColor = System.Drawing.Color.Black
            Me.LabelDetails.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 121.9999!)
            Me.LabelDetails.Name = "LabelDetails"
            Me.LabelDetails.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetails.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.LabelDetails.StylePriority.UseFont = False
            Me.LabelDetails.Text = "Detail:"
            Me.LabelDetails.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelReportDate
            '
            Me.LabelReportDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportDate.BorderColor = System.Drawing.Color.Black
            Me.LabelReportDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportDate.BorderWidth = 1.0!
            Me.LabelReportDate.CanGrow = False
            Me.LabelReportDate.Dpi = 100.0!
            Me.LabelReportDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportDate.ForeColor = System.Drawing.Color.Black
            Me.LabelReportDate.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 64.99997!)
            Me.LabelReportDate.Name = "LabelReportDate"
            Me.LabelReportDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportDate.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.LabelReportDate.StylePriority.UseFont = False
            Me.LabelReportDate.Text = "Report Date:"
            Me.LabelReportDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelStatus
            '
            Me.LabelStatus.BackColor = System.Drawing.Color.Transparent
            Me.LabelStatus.BorderColor = System.Drawing.Color.Black
            Me.LabelStatus.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelStatus.BorderWidth = 1.0!
            Me.LabelStatus.CanGrow = False
            Me.LabelStatus.Dpi = 100.0!
            Me.LabelStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelStatus.ForeColor = System.Drawing.Color.Black
            Me.LabelStatus.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 45.99998!)
            Me.LabelStatus.Name = "LabelStatus"
            Me.LabelStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelStatus.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.LabelStatus.StylePriority.UseFont = False
            Me.LabelStatus.Text = "Status:"
            Me.LabelStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDescription_Description
            '
            Me.LabelDescription_Description.BackColor = System.Drawing.Color.Transparent
            Me.LabelDescription_Description.BorderColor = System.Drawing.Color.Black
            Me.LabelDescription_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDescription_Description.BorderWidth = 1.0!
            Me.LabelDescription_Description.CanGrow = False
            Me.LabelDescription_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.LabelDescription_Description.Dpi = 100.0!
            Me.LabelDescription_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDescription_Description.LocationFloat = New DevExpress.Utils.PointFloat(109.7918!, 103.0!)
            Me.LabelDescription_Description.Name = "LabelDescription_Description"
            Me.LabelDescription_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDescription_Description.SizeF = New System.Drawing.SizeF(630.2082!, 19.0!)
            Me.LabelDescription_Description.StylePriority.UseFont = False
            Me.LabelDescription_Description.Text = "LabelDescription_Description"
            Me.LabelDescription_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDescription
            '
            Me.LabelDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDescription.BorderWidth = 1.0!
            Me.LabelDescription.CanGrow = False
            Me.LabelDescription.Dpi = 100.0!
            Me.LabelDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDescription.ForeColor = System.Drawing.Color.Black
            Me.LabelDescription.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 103.0!)
            Me.LabelDescription.Name = "LabelDescription"
            Me.LabelDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDescription.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.LabelDescription.StylePriority.UseFont = False
            Me.LabelDescription.Text = "Description:"
            Me.LabelDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelEmployee_Employee
            '
            Me.LabelEmployee_Employee.BackColor = System.Drawing.Color.Transparent
            Me.LabelEmployee_Employee.BorderColor = System.Drawing.Color.Black
            Me.LabelEmployee_Employee.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelEmployee_Employee.BorderWidth = 1.0!
            Me.LabelEmployee_Employee.CanGrow = False
            Me.LabelEmployee_Employee.Dpi = 100.0!
            Me.LabelEmployee_Employee.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelEmployee_Employee.LocationFloat = New DevExpress.Utils.PointFloat(109.7916!, 26.99998!)
            Me.LabelEmployee_Employee.Name = "LabelEmployee_Employee"
            Me.LabelEmployee_Employee.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelEmployee_Employee.SizeF = New System.Drawing.SizeF(241.666!, 19.0!)
            Me.LabelEmployee_Employee.StylePriority.UseFont = False
            Me.LabelEmployee_Employee.Text = "LabelEmployee_Employee"
            Me.LabelEmployee_Employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelEmployee
            '
            Me.LabelEmployee.BackColor = System.Drawing.Color.Transparent
            Me.LabelEmployee.BorderColor = System.Drawing.Color.Black
            Me.LabelEmployee.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelEmployee.BorderWidth = 1.0!
            Me.LabelEmployee.CanGrow = False
            Me.LabelEmployee.Dpi = 100.0!
            Me.LabelEmployee.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelEmployee.ForeColor = System.Drawing.Color.Black
            Me.LabelEmployee.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 26.99998!)
            Me.LabelEmployee.Name = "LabelEmployee"
            Me.LabelEmployee.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelEmployee.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.LabelEmployee.StylePriority.UseFont = False
            Me.LabelEmployee.Text = "Employee:"
            Me.LabelEmployee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelReportNumber
            '
            Me.LabelReportNumber.BackColor = System.Drawing.Color.Transparent
            Me.LabelReportNumber.BorderColor = System.Drawing.Color.Black
            Me.LabelReportNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelReportNumber.BorderWidth = 1.0!
            Me.LabelReportNumber.CanGrow = False
            Me.LabelReportNumber.Dpi = 100.0!
            Me.LabelReportNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelReportNumber.ForeColor = System.Drawing.Color.Black
            Me.LabelReportNumber.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 8.0!)
            Me.LabelReportNumber.Name = "LabelReportNumber"
            Me.LabelReportNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelReportNumber.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.LabelReportNumber.StylePriority.UseFont = False
            Me.LabelReportNumber.Text = "Report Number:"
            Me.LabelReportNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineEmployeeSignatureLine
            '
            Me.LineEmployeeSignatureLine.Dpi = 100.0!
            Me.LineEmployeeSignatureLine.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 342.4164!)
            Me.LineEmployeeSignatureLine.Name = "LineEmployeeSignatureLine"
            Me.LineEmployeeSignatureLine.SizeF = New System.Drawing.SizeF(303.4584!, 23.0!)
            '
            'LineApproverSignatureLine
            '
            Me.LineApproverSignatureLine.Dpi = 100.0!
            Me.LineApproverSignatureLine.LocationFloat = New DevExpress.Utils.PointFloat(436.5412!, 342.4165!)
            Me.LineApproverSignatureLine.Name = "LineApproverSignatureLine"
            Me.LineApproverSignatureLine.SizeF = New System.Drawing.SizeF(303.4585!, 23.0!)
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 39.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 70.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageFooter_Date
            '
            Me.LabelPageFooter_Date.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_Date.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_Date.BorderWidth = 1.0!
            Me.LabelPageFooter_Date.CanGrow = False
            Me.LabelPageFooter_Date.Dpi = 100.0!
            Me.LabelPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelPageFooter_Date.Name = "LabelPageFooter_Date"
            Me.LabelPageFooter_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_Date.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_Date.StylePriority.UseFont = False
            Me.LabelPageFooter_Date.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageFooter_UserCode
            '
            Me.LabelPageFooter_UserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_UserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_UserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_UserCode.CanGrow = False
            Me.LabelPageFooter_UserCode.Dpi = 100.0!
            Me.LabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_UserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(216.6664!, 0!)
            Me.LabelPageFooter_UserCode.Name = "LabelPageFooter_UserCode"
            Me.LabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_UserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_UserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_UserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Dpi = 100.0!
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(613.5421!, 0!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineHeaderBottomLine, Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_Title})
            Me.PageHeader.Dpi = 100.0!
            Me.PageHeader.HeightF = 68.12496!
            Me.PageHeader.Name = "PageHeader"
            '
            'LineHeaderBottomLine
            '
            Me.LineHeaderBottomLine.BorderColor = System.Drawing.Color.Silver
            Me.LineHeaderBottomLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineHeaderBottomLine.BorderWidth = 4.0!
            Me.LineHeaderBottomLine.Dpi = 100.0!
            Me.LineHeaderBottomLine.ForeColor = System.Drawing.Color.Silver
            Me.LineHeaderBottomLine.LineWidth = 4
            Me.LineHeaderBottomLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 57.5833!)
            Me.LineHeaderBottomLine.Name = "LineHeaderBottomLine"
            Me.LineHeaderBottomLine.SizeF = New System.Drawing.SizeF(750.0!, 4.000011!)
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1.0!
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Dpi = 100.0!
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(431.167!, 27.00001!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(308.833!, 19.0!)
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4.0!
            Me.LineTopLine.Dpi = 100.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(750.0!, 4.000011!)
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1.0!
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Dpi = 100.0!
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 20.00001!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(321.1667!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Expense Report"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.ExpenseReport)
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.PageInfo_Pages, Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date})
            Me.PageFooter.Dpi = 100.0!
            Me.PageFooter.HeightF = 23.95833!
            Me.PageFooter.Name = "PageFooter"
            '
            'EmployeeExpenseReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter})
            Me.DataSource = Me.BindingSource
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 39, 70)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LineHeaderBottomLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelReportNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelEmployee_Employee As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelEmployee As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelDescription_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetails_Details As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportDate_ReportDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelStatus_Status As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetails As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelStatus As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelReportNumber_ReportNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelCertify As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelExpenseItems As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LineExpenseItems As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents SubreportExpenseItems As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Friend WithEvents LabelApprove As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LineEmployeeSignatureLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LineApproverSignatureLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PictureBoxApproverSignature As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents PictureBoxEmployeeSignature As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents LabelApproverSignature As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelEmployeeSignature As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelSignatureDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelCreatedDate_CreatedDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelCreatedDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

    End Class

End Namespace
