Namespace Employee

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class EmployeeTimesheetDetailReport
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
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.Line_Detail = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_Comments = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Hours = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Department = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Function = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Component = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ProductCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Comments = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelSignatureDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.PictureBoxApproverSignature = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.PictureBoxEmployeeSignature = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.LabelApproverSignature = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelEmployeeSignature = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelApprove = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelCertify = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            Me.GroupHeader_Date = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Hours = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Department = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_FunctionCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Component = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Job = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_ProductCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroup_Date = New DevExpress.XtraReports.UI.XRLabel()
            Me.JobFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ComponentFull = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.GroupFooter_Date = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooter_TotalFor = New DevExpress.XtraReports.UI.XRLabel()
            Me.DayTotalHours = New DevExpress.XtraReports.UI.CalculatedField()
            Me.LabelDetail_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Line_Detail, Me.Label_Comments, Me.Label_Hours, Me.Label_Department, Me.Label_Function, Me.Label_Component, Me.Label_Job, Me.Label_ProductCategory, Me.Label_Product, Me.Label_Division, Me.Label_Client, Me.LabelGroup_Comments})
            Me.Detail.HeightF = 49.20832!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Line_Detail
            '
            Me.Line_Detail.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.Line_Detail.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 43.0!)
            Me.Line_Detail.Name = "Line_Detail"
            Me.Line_Detail.SizeF = New System.Drawing.SizeF(750.0!, 5.291667!)
            '
            'Label_Comments
            '
            Me.Label_Comments.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Comments")})
            Me.Label_Comments.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Comments.LocationFloat = New DevExpress.Utils.PointFloat(80.62515!, 23.66654!)
            Me.Label_Comments.Multiline = True
            Me.Label_Comments.Name = "Label_Comments"
            Me.Label_Comments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Comments.SizeF = New System.Drawing.SizeF(528.1248!, 18.0!)
            Me.Label_Comments.StylePriority.UseFont = False
            Me.Label_Comments.Text = "Label_Comments"
            '
            'Label_Hours
            '
            Me.Label_Hours.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeHours", "{0:n2}")})
            Me.Label_Hours.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Hours.LocationFloat = New DevExpress.Utils.PointFloat(679.3752!, 3.000005!)
            Me.Label_Hours.Name = "Label_Hours"
            Me.Label_Hours.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Hours.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
            Me.Label_Hours.StylePriority.UseFont = False
            Me.Label_Hours.Text = "Label_Hours"
            '
            'Label_Department
            '
            Me.Label_Department.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DepartmentTeamCode")})
            Me.Label_Department.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Department.LocationFloat = New DevExpress.Utils.PointFloat(608.7499!, 3.000005!)
            Me.Label_Department.Name = "Label_Department"
            Me.Label_Department.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Department.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
            Me.Label_Department.StylePriority.UseFont = False
            Me.Label_Department.Text = "Label_Department"
            '
            'Label_Function
            '
            Me.Label_Function.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionCategory")})
            Me.Label_Function.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Function.LocationFloat = New DevExpress.Utils.PointFloat(538.1249!, 3.000005!)
            Me.Label_Function.Name = "Label_Function"
            Me.Label_Function.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Function.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
            Me.Label_Function.StylePriority.UseFont = False
            Me.Label_Function.Text = "Label_Function"
            '
            'Label_Component
            '
            Me.Label_Component.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ComponentFull")})
            Me.Label_Component.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Component.LocationFloat = New DevExpress.Utils.PointFloat(415.3104!, 3.000005!)
            Me.Label_Component.Name = "Label_Component"
            Me.Label_Component.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Component.SizeF = New System.Drawing.SizeF(122.8101!, 18.0!)
            Me.Label_Component.StylePriority.UseFont = False
            Me.Label_Component.Text = "Label_Component"
            '
            'Label_Job
            '
            Me.Label_Job.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobFull")})
            Me.Label_Job.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Job.LocationFloat = New DevExpress.Utils.PointFloat(292.5003!, 3.000005!)
            Me.Label_Job.Name = "Label_Job"
            Me.Label_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Job.SizeF = New System.Drawing.SizeF(122.81!, 18.0!)
            Me.Label_Job.StylePriority.UseFont = False
            Me.Label_Job.Text = "Label_Job"
            '
            'Label_ProductCategory
            '
            Me.Label_ProductCategory.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCategoryCode")})
            Me.Label_ProductCategory.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_ProductCategory.LocationFloat = New DevExpress.Utils.PointFloat(221.8753!, 3.000005!)
            Me.Label_ProductCategory.Name = "Label_ProductCategory"
            Me.Label_ProductCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_ProductCategory.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
            Me.Label_ProductCategory.StylePriority.UseFont = False
            Me.Label_ProductCategory.Text = "Label_ProductCategory"
            '
            'Label_Product
            '
            Me.Label_Product.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.Label_Product.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Product.LocationFloat = New DevExpress.Utils.PointFloat(151.2502!, 3.000005!)
            Me.Label_Product.Name = "Label_Product"
            Me.Label_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Product.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
            Me.Label_Product.StylePriority.UseFont = False
            Me.Label_Product.Text = "Label_Product"
            '
            'Label_Division
            '
            Me.Label_Division.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.Label_Division.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Division.LocationFloat = New DevExpress.Utils.PointFloat(80.62515!, 3.000005!)
            Me.Label_Division.Name = "Label_Division"
            Me.Label_Division.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Division.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
            Me.Label_Division.StylePriority.UseFont = False
            Me.Label_Division.Text = "Label_Division"
            '
            'Label_Client
            '
            Me.Label_Client.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.Label_Client.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Client.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 3.000005!)
            Me.Label_Client.Name = "Label_Client"
            Me.Label_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Client.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
            Me.Label_Client.StylePriority.UseFont = False
            Me.Label_Client.Text = "Label_Client"
            '
            'LabelGroup_Comments
            '
            Me.LabelGroup_Comments.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroup_Comments.BorderColor = System.Drawing.Color.Black
            Me.LabelGroup_Comments.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroup_Comments.BorderWidth = 1
            Me.LabelGroup_Comments.CanGrow = False
            Me.LabelGroup_Comments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroup_Comments.ForeColor = System.Drawing.Color.Black
            Me.LabelGroup_Comments.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 23.66654!)
            Me.LabelGroup_Comments.Name = "LabelGroup_Comments"
            Me.LabelGroup_Comments.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroup_Comments.SizeF = New System.Drawing.SizeF(80.6251!, 19.0!)
            Me.LabelGroup_Comments.StylePriority.UseFont = False
            Me.LabelGroup_Comments.Text = "Comments:"
            Me.LabelGroup_Comments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelSignatureDate
            '
            Me.LabelSignatureDate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelSignatureDate.LocationFloat = New DevExpress.Utils.PointFloat(240.5001!, 136.6666!)
            Me.LabelSignatureDate.Name = "LabelSignatureDate"
            Me.LabelSignatureDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelSignatureDate.SizeF = New System.Drawing.SizeF(72.95834!, 18.0!)
            Me.LabelSignatureDate.StylePriority.UseFont = False
            Me.LabelSignatureDate.Text = "LabelSignatureDate"
            '
            'PictureBoxApproverSignature
            '
            Me.PictureBoxApproverSignature.LocationFloat = New DevExpress.Utils.PointFloat(436.5417!, 73.16666!)
            Me.PictureBoxApproverSignature.Name = "PictureBoxApproverSignature"
            Me.PictureBoxApproverSignature.SizeF = New System.Drawing.SizeF(303.4584!, 81.49988!)
            '
            'PictureBoxEmployeeSignature
            '
            Me.PictureBoxEmployeeSignature.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 73.16666!)
            Me.PictureBoxEmployeeSignature.Name = "PictureBoxEmployeeSignature"
            Me.PictureBoxEmployeeSignature.SizeF = New System.Drawing.SizeF(230.5!, 81.49988!)
            '
            'LabelApproverSignature
            '
            Me.LabelApproverSignature.BackColor = System.Drawing.Color.Transparent
            Me.LabelApproverSignature.BorderColor = System.Drawing.Color.Black
            Me.LabelApproverSignature.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelApproverSignature.BorderWidth = 1
            Me.LabelApproverSignature.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelApproverSignature.LocationFloat = New DevExpress.Utils.PointFloat(436.5417!, 177.6666!)
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
            Me.LabelEmployeeSignature.BorderWidth = 1
            Me.LabelEmployeeSignature.CanGrow = False
            Me.LabelEmployeeSignature.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelEmployeeSignature.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 177.6666!)
            Me.LabelEmployeeSignature.Name = "LabelEmployeeSignature"
            Me.LabelEmployeeSignature.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelEmployeeSignature.SizeF = New System.Drawing.SizeF(303.4584!, 19.0!)
            Me.LabelEmployeeSignature.StylePriority.UseFont = False
            Me.LabelEmployeeSignature.Text = "Employee Signature / Date"
            Me.LabelEmployeeSignature.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelApprove
            '
            Me.LabelApprove.BackColor = System.Drawing.Color.Transparent
            Me.LabelApprove.BorderColor = System.Drawing.Color.Black
            Me.LabelApprove.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelApprove.BorderWidth = 1
            Me.LabelApprove.CanGrow = False
            Me.LabelApprove.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelApprove.ForeColor = System.Drawing.Color.Black
            Me.LabelApprove.LocationFloat = New DevExpress.Utils.PointFloat(436.5417!, 30.20833!)
            Me.LabelApprove.Name = "LabelApprove"
            Me.LabelApprove.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelApprove.SizeF = New System.Drawing.SizeF(303.4584!, 30.45834!)
            Me.LabelApprove.StylePriority.UseFont = False
            Me.LabelApprove.Text = "I have reviewed and approved this timesheet for accuracy and reasonableness."
            Me.LabelApprove.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelCertify
            '
            Me.LabelCertify.BackColor = System.Drawing.Color.Transparent
            Me.LabelCertify.BorderColor = System.Drawing.Color.Black
            Me.LabelCertify.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCertify.BorderWidth = 1
            Me.LabelCertify.CanGrow = False
            Me.LabelCertify.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCertify.ForeColor = System.Drawing.Color.Black
            Me.LabelCertify.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 30.20833!)
            Me.LabelCertify.Name = "LabelCertify"
            Me.LabelCertify.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelCertify.SizeF = New System.Drawing.SizeF(303.4584!, 30.45834!)
            Me.LabelCertify.StylePriority.UseFont = False
            Me.LabelCertify.Text = "I certify that the time posted on the date(s) listed is accurate and complete."
            Me.LabelCertify.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineEmployeeSignatureLine
            '
            Me.LineEmployeeSignatureLine.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 154.6665!)
            Me.LineEmployeeSignatureLine.Name = "LineEmployeeSignatureLine"
            Me.LineEmployeeSignatureLine.SizeF = New System.Drawing.SizeF(303.4584!, 23.0!)
            '
            'LineApproverSignatureLine
            '
            Me.LineApproverSignatureLine.LocationFloat = New DevExpress.Utils.PointFloat(436.5417!, 154.6665!)
            Me.LineApproverSignatureLine.Name = "LineApproverSignatureLine"
            Me.LineApproverSignatureLine.SizeF = New System.Drawing.SizeF(303.4585!, 23.0!)
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
            Me.LabelPageFooter_Date.BorderWidth = 1
            Me.LabelPageFooter_Date.CanGrow = False
            Me.LabelPageFooter_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_Date.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
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
            Me.LabelPageFooter_UserCode.BorderWidth = 1
            Me.LabelPageFooter_UserCode.CanGrow = False
            Me.LabelPageFooter_UserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_UserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_UserCode.LocationFloat = New DevExpress.Utils.PointFloat(216.6664!, 0.0!)
            Me.LabelPageFooter_UserCode.Name = "LabelPageFooter_UserCode"
            Me.LabelPageFooter_UserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_UserCode.SizeF = New System.Drawing.SizeF(202.0832!, 19.0!)
            Me.LabelPageFooter_UserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_UserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_UserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(614.5416!, 0.0!)
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
            Me.PageHeader.HeightF = 68.12496!
            Me.PageHeader.Name = "PageHeader"
            '
            'LineHeaderBottomLine
            '
            Me.LineHeaderBottomLine.BorderColor = System.Drawing.Color.Silver
            Me.LineHeaderBottomLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineHeaderBottomLine.BorderWidth = 4
            Me.LineHeaderBottomLine.ForeColor = System.Drawing.Color.Silver
            Me.LineHeaderBottomLine.LineWidth = 4
            Me.LineHeaderBottomLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 57.5833!)
            Me.LineHeaderBottomLine.Name = "LineHeaderBottomLine"
            Me.LineHeaderBottomLine.SizeF = New System.Drawing.SizeF(749.9999!, 4.0!)
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(441.1669!, 27.00001!)
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
            Me.LineTopLine.BorderWidth = 4
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(749.9999!, 4.0!)
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 20.00001!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(431.1668!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Timesheet for {0} ({1})"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.PageInfo_Pages, Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date})
            Me.PageFooter.HeightF = 23.95833!
            Me.PageFooter.Name = "PageFooter"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.EmployeeTimeComplex)
            '
            'GroupHeader_Date
            '
            Me.GroupHeader_Date.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2, Me.LabelGroup_Hours, Me.LabelGroup_Department, Me.LabelGroup_FunctionCategory, Me.LabelGroup_Component, Me.LabelGroup_Job, Me.LabelGroup_ProductCategory, Me.LabelGroup_Product, Me.LabelGroup_Division, Me.LabelGroup_Client, Me.LabelGroup_Date})
            Me.GroupHeader_Date.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("EmployeeDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader_Date.HeightF = 37.99999!
            Me.GroupHeader_Date.Name = "GroupHeader_Date"
			'
			'XrLabel2
			'
			Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeDate", "{0:d}")})
			Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(40.41672!, 0.0!)
			Me.XrLabel2.Name = "XrLabel2"
			Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel2.SizeF = New System.Drawing.SizeF(110.8334!, 18.0!)
			Me.XrLabel2.StylePriority.UseFont = False
			Me.XrLabel2.Text = "XrLabel2"
			'
			'LabelGroup_Hours
			'
			Me.LabelGroup_Hours.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_Hours.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_Hours.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_Hours.BorderWidth = 1
			Me.LabelGroup_Hours.CanGrow = False
			Me.LabelGroup_Hours.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_Hours.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_Hours.LocationFloat = New DevExpress.Utils.PointFloat(679.3749!, 18.99999!)
			Me.LabelGroup_Hours.Name = "LabelGroup_Hours"
			Me.LabelGroup_Hours.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_Hours.SizeF = New System.Drawing.SizeF(70.62499!, 19.0!)
			Me.LabelGroup_Hours.StylePriority.UseFont = False
			Me.LabelGroup_Hours.Text = "Hours"
			Me.LabelGroup_Hours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_Department
			'
			Me.LabelGroup_Department.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_Department.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_Department.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_Department.BorderWidth = 1
			Me.LabelGroup_Department.CanGrow = False
			Me.LabelGroup_Department.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_Department.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_Department.LocationFloat = New DevExpress.Utils.PointFloat(608.7499!, 18.99999!)
			Me.LabelGroup_Department.Name = "LabelGroup_Department"
			Me.LabelGroup_Department.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_Department.SizeF = New System.Drawing.SizeF(70.62499!, 19.0!)
			Me.LabelGroup_Department.StylePriority.UseFont = False
			Me.LabelGroup_Department.Text = "Dept"
			Me.LabelGroup_Department.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_FunctionCategory
			'
			Me.LabelGroup_FunctionCategory.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_FunctionCategory.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_FunctionCategory.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_FunctionCategory.BorderWidth = 1
			Me.LabelGroup_FunctionCategory.CanGrow = False
			Me.LabelGroup_FunctionCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_FunctionCategory.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_FunctionCategory.LocationFloat = New DevExpress.Utils.PointFloat(538.1249!, 18.99999!)
			Me.LabelGroup_FunctionCategory.Name = "LabelGroup_FunctionCategory"
			Me.LabelGroup_FunctionCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_FunctionCategory.SizeF = New System.Drawing.SizeF(70.62499!, 19.0!)
			Me.LabelGroup_FunctionCategory.StylePriority.UseFont = False
			Me.LabelGroup_FunctionCategory.Text = "Func/Cat"
			Me.LabelGroup_FunctionCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_Component
			'
			Me.LabelGroup_Component.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_Component.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_Component.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_Component.BorderWidth = 1
			Me.LabelGroup_Component.CanGrow = False
			Me.LabelGroup_Component.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_Component.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_Component.LocationFloat = New DevExpress.Utils.PointFloat(415.3104!, 18.99999!)
			Me.LabelGroup_Component.Name = "LabelGroup_Component"
			Me.LabelGroup_Component.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_Component.SizeF = New System.Drawing.SizeF(122.81!, 19.0!)
			Me.LabelGroup_Component.StylePriority.UseFont = False
			Me.LabelGroup_Component.Text = "Component"
			Me.LabelGroup_Component.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_Job
			'
			Me.LabelGroup_Job.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_Job.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_Job.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_Job.BorderWidth = 1
			Me.LabelGroup_Job.CanGrow = False
			Me.LabelGroup_Job.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_Job.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_Job.LocationFloat = New DevExpress.Utils.PointFloat(292.5003!, 18.99999!)
			Me.LabelGroup_Job.Name = "LabelGroup_Job"
			Me.LabelGroup_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_Job.SizeF = New System.Drawing.SizeF(122.81!, 19.0!)
			Me.LabelGroup_Job.StylePriority.UseFont = False
			Me.LabelGroup_Job.Text = "Job"
			Me.LabelGroup_Job.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_ProductCategory
			'
			Me.LabelGroup_ProductCategory.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_ProductCategory.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_ProductCategory.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_ProductCategory.BorderWidth = 1
			Me.LabelGroup_ProductCategory.CanGrow = False
			Me.LabelGroup_ProductCategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_ProductCategory.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_ProductCategory.LocationFloat = New DevExpress.Utils.PointFloat(221.8753!, 18.99999!)
			Me.LabelGroup_ProductCategory.Name = "LabelGroup_ProductCategory"
			Me.LabelGroup_ProductCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_ProductCategory.SizeF = New System.Drawing.SizeF(70.62499!, 19.0!)
			Me.LabelGroup_ProductCategory.StylePriority.UseFont = False
			Me.LabelGroup_ProductCategory.Text = "Prod Cat"
			Me.LabelGroup_ProductCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_Product
			'
			Me.LabelGroup_Product.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_Product.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_Product.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_Product.BorderWidth = 1
			Me.LabelGroup_Product.CanGrow = False
			Me.LabelGroup_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_Product.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_Product.LocationFloat = New DevExpress.Utils.PointFloat(151.2502!, 18.99999!)
			Me.LabelGroup_Product.Name = "LabelGroup_Product"
			Me.LabelGroup_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_Product.SizeF = New System.Drawing.SizeF(70.62499!, 19.0!)
			Me.LabelGroup_Product.StylePriority.UseFont = False
			Me.LabelGroup_Product.Text = "Product"
			Me.LabelGroup_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_Division
			'
			Me.LabelGroup_Division.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_Division.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_Division.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_Division.BorderWidth = 1
			Me.LabelGroup_Division.CanGrow = False
			Me.LabelGroup_Division.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_Division.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_Division.LocationFloat = New DevExpress.Utils.PointFloat(80.62515!, 18.99999!)
			Me.LabelGroup_Division.Name = "LabelGroup_Division"
			Me.LabelGroup_Division.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_Division.SizeF = New System.Drawing.SizeF(70.62499!, 19.0!)
			Me.LabelGroup_Division.StylePriority.UseFont = False
			Me.LabelGroup_Division.Text = "Division"
			Me.LabelGroup_Division.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_Client
			'
			Me.LabelGroup_Client.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_Client.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_Client.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_Client.BorderWidth = 1
			Me.LabelGroup_Client.CanGrow = False
			Me.LabelGroup_Client.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_Client.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_Client.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 18.99999!)
			Me.LabelGroup_Client.Name = "LabelGroup_Client"
			Me.LabelGroup_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_Client.SizeF = New System.Drawing.SizeF(70.62499!, 19.0!)
			Me.LabelGroup_Client.StylePriority.UseFont = False
			Me.LabelGroup_Client.Text = "Client"
			Me.LabelGroup_Client.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelGroup_Date
			'
			Me.LabelGroup_Date.BackColor = System.Drawing.Color.Transparent
			Me.LabelGroup_Date.BorderColor = System.Drawing.Color.Black
			Me.LabelGroup_Date.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelGroup_Date.BorderWidth = 1
			Me.LabelGroup_Date.CanGrow = False
			Me.LabelGroup_Date.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelGroup_Date.ForeColor = System.Drawing.Color.Black
			Me.LabelGroup_Date.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
			Me.LabelGroup_Date.Name = "LabelGroup_Date"
			Me.LabelGroup_Date.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelGroup_Date.SizeF = New System.Drawing.SizeF(40.41665!, 19.0!)
			Me.LabelGroup_Date.StylePriority.UseFont = False
			Me.LabelGroup_Date.Text = "Date:"
			Me.LabelGroup_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'JobFull
            '
            Me.JobFull.Expression = "Concat(ToStr(IsNull([JobNumber], '')), ' - ', [JobDescription])"
            Me.JobFull.Name = "JobFull"
			'
			'ComponentFull
			'
			Me.ComponentFull.Expression = "Concat(ToStr(IsNull([JobComponentNumber], '')), ' - ', [JobComponentDescription])" &
		""
			Me.ComponentFull.Name = "ComponentFull"
			'
			'ReportFooter
			'
			Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_Total, Me.XrLabel4, Me.LabelCertify, Me.LineEmployeeSignatureLine, Me.LineApproverSignatureLine, Me.LabelApprove, Me.LabelEmployeeSignature, Me.LabelApproverSignature, Me.PictureBoxEmployeeSignature, Me.PictureBoxApproverSignature, Me.LabelSignatureDate})
			Me.ReportFooter.HeightF = 206.0416!
			Me.ReportFooter.Name = "ReportFooter"
			'
			'GroupFooter_Date
			'
			Me.GroupFooter_Date.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XrLabel1, Me.LabelGroupFooter_TotalFor})
			Me.GroupFooter_Date.HeightF = 31.25!
			Me.GroupFooter_Date.Name = "GroupFooter_Date"
			'
			'XrLine1
			'
			Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 22.70835!)
			Me.XrLine1.Name = "XrLine1"
			Me.XrLine1.SizeF = New System.Drawing.SizeF(750.0!, 5.291667!)
			'
			'XrLabel1
			'
			Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeHours")})
			Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(679.3749!, 2.000007!)
			Me.XrLabel1.Name = "XrLabel1"
			Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.XrLabel1.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
			Me.XrLabel1.StylePriority.UseFont = False
			XrSummary2.FormatString = "{0:n2}"
			XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabel1.Summary = XrSummary2
			Me.XrLabel1.Text = "XrLabel1"
			'
			'LabelGroupFooter_TotalFor
			'
			Me.LabelGroupFooter_TotalFor.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeDate", "Total for {0:d}:")})
			Me.LabelGroupFooter_TotalFor.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelGroupFooter_TotalFor.LocationFloat = New DevExpress.Utils.PointFloat(538.1249!, 2.000007!)
            Me.LabelGroupFooter_TotalFor.Name = "LabelGroupFooter_TotalFor"
            Me.LabelGroupFooter_TotalFor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooter_TotalFor.SizeF = New System.Drawing.SizeF(141.25!, 18.0!)
            Me.LabelGroupFooter_TotalFor.StylePriority.UseFont = False
            Me.LabelGroupFooter_TotalFor.Text = "LabelGroupFooter_TotalFor"
            '
            'DayTotalHours
            '
            Me.DayTotalHours.Name = "DayTotalHours"
            '
            'LabelDetail_Total
            '
            Me.LabelDetail_Total.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelDetail_Total.LocationFloat = New DevExpress.Utils.PointFloat(538.1249!, 4.0!)
            Me.LabelDetail_Total.Name = "LabelDetail_Total"
            Me.LabelDetail_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Total.SizeF = New System.Drawing.SizeF(141.25!, 18.0!)
            Me.LabelDetail_Total.StylePriority.UseFont = False
            Me.LabelDetail_Total.Text = "Total for {0}:"
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EmployeeHours")})
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(679.3747!, 4.0!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(70.62499!, 18.0!)
            Me.XrLabel4.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabel4.Summary = XrSummary1
            Me.XrLabel4.Text = "XrLabel4"
            '
            'EmployeeTimesheetDetailReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.GroupHeader_Date, Me.ReportFooter, Me.GroupFooter_Date})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.JobFull, Me.ComponentFull, Me.DayTotalHours})
            Me.DataSource = Me.BindingSource
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 39, 70)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.Version = "14.2"
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
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelCertify As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Friend WithEvents LabelApprove As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LineEmployeeSignatureLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LineApproverSignatureLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PictureBoxApproverSignature As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents PictureBoxEmployeeSignature As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents LabelApproverSignature As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelEmployeeSignature As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelSignatureDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_Date As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageFooter_UserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents GroupHeader_Date As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents Label_Comments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Hours As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Department As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Function As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Component As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Job As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_ProductCategory As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Product As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Division As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Client As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Comments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Hours As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Department As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_FunctionCategory As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Component As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Job As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_ProductCategory As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Product As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Division As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Client As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroup_Date As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ComponentFull As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents GroupFooter_Date As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooter_TotalFor As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DayTotalHours As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Line_Detail As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel

    End Class

End Namespace
