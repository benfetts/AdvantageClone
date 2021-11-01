Namespace Employee

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class EmployeeTimesheetReport
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
            Me.LabelSignatureDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.PictureBoxApproverSignature = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.PictureBoxEmployeeSignature = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.LabelApproverSignature = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelEmployeeSignature = New DevExpress.XtraReports.UI.XRLabel()
            Me.Subreport_TimesheetDetails = New DevExpress.XtraReports.UI.XRSubreport()
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
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelSignatureDate, Me.PictureBoxApproverSignature, Me.PictureBoxEmployeeSignature, Me.LabelApproverSignature, Me.LabelEmployeeSignature, Me.Subreport_TimesheetDetails, Me.LabelApprove, Me.LabelCertify, Me.LineEmployeeSignatureLine, Me.LineApproverSignatureLine})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 209.625!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelSignatureDate
            '
            Me.LabelSignatureDate.Dpi = 100.0!
            Me.LabelSignatureDate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelSignatureDate.LocationFloat = New DevExpress.Utils.PointFloat(240.5001!, 142.1248!)
            Me.LabelSignatureDate.Name = "LabelSignatureDate"
            Me.LabelSignatureDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelSignatureDate.SizeF = New System.Drawing.SizeF(72.95834!, 18.0!)
            Me.LabelSignatureDate.StylePriority.UseFont = False
            Me.LabelSignatureDate.Text = "LabelSignatureDate"
            '
            'PictureBoxApproverSignature
            '
            Me.PictureBoxApproverSignature.Dpi = 100.0!
            Me.PictureBoxApproverSignature.LocationFloat = New DevExpress.Utils.PointFloat(556.2505!, 78.62489!)
            Me.PictureBoxApproverSignature.Name = "PictureBoxApproverSignature"
            Me.PictureBoxApproverSignature.SizeF = New System.Drawing.SizeF(303.4584!, 81.49988!)
            '
            'PictureBoxEmployeeSignature
            '
            Me.PictureBoxEmployeeSignature.Dpi = 100.0!
            Me.PictureBoxEmployeeSignature.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 78.62486!)
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
            Me.LabelApproverSignature.LocationFloat = New DevExpress.Utils.PointFloat(556.2505!, 183.1248!)
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
            Me.LabelEmployeeSignature.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 183.1248!)
            Me.LabelEmployeeSignature.Name = "LabelEmployeeSignature"
            Me.LabelEmployeeSignature.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelEmployeeSignature.SizeF = New System.Drawing.SizeF(303.4584!, 19.0!)
            Me.LabelEmployeeSignature.StylePriority.UseFont = False
            Me.LabelEmployeeSignature.Text = "Employee Signature / Date"
            Me.LabelEmployeeSignature.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Subreport_TimesheetDetails
            '
            Me.Subreport_TimesheetDetails.Dpi = 100.0!
            Me.Subreport_TimesheetDetails.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Subreport_TimesheetDetails.Name = "Subreport_TimesheetDetails"
            Me.Subreport_TimesheetDetails.ReportSource = New AdvantageFramework.Reporting.Reports.Employee.TimesheetDetailsSubReport()
            Me.Subreport_TimesheetDetails.SizeF = New System.Drawing.SizeF(1000.0!, 23.0!)
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
            Me.LabelApprove.LocationFloat = New DevExpress.Utils.PointFloat(556.2505!, 35.66653!)
            Me.LabelApprove.Name = "LabelApprove"
            Me.LabelApprove.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelApprove.SizeF = New System.Drawing.SizeF(433.7496!, 30.45834!)
            Me.LabelApprove.StylePriority.UseFont = False
            Me.LabelApprove.Text = "I have reviewed and approved this timesheet for accuracy and reasonableness."
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
            Me.LabelCertify.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 35.66653!)
            Me.LabelCertify.Name = "LabelCertify"
            Me.LabelCertify.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelCertify.SizeF = New System.Drawing.SizeF(424.3745!, 30.45834!)
            Me.LabelCertify.StylePriority.UseFont = False
            Me.LabelCertify.Text = "I certify that the time posted on the date(s) listed is accurate and complete."
            Me.LabelCertify.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineEmployeeSignatureLine
            '
            Me.LineEmployeeSignatureLine.Dpi = 100.0!
            Me.LineEmployeeSignatureLine.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 160.1247!)
            Me.LineEmployeeSignatureLine.Name = "LineEmployeeSignatureLine"
            Me.LineEmployeeSignatureLine.SizeF = New System.Drawing.SizeF(303.4584!, 23.0!)
            '
            'LineApproverSignatureLine
            '
            Me.LineApproverSignatureLine.Dpi = 100.0!
            Me.LineApproverSignatureLine.LocationFloat = New DevExpress.Utils.PointFloat(556.25!, 160.1248!)
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
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(864.5416!, 0!)
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
            Me.LineHeaderBottomLine.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(681.1671!, 27.00001!)
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
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(1000.0!, 4.0!)
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
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(671.167!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Timesheet for {0} ({1})"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.PageInfo_Pages, Me.LabelPageFooter_UserCode, Me.LabelPageFooter_Date})
            Me.PageFooter.Dpi = 100.0!
            Me.PageFooter.HeightF = 23.95833!
            Me.PageFooter.Name = "PageFooter"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Views.Employee)
            '
            'EmployeeTimesheetReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter})
            Me.DataSource = Me.BindingSource
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 39, 70)
            Me.PageHeight = 850
            Me.PageWidth = 1100
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
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelCertify As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Subreport_TimesheetDetails As DevExpress.XtraReports.UI.XRSubreport
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

    End Class

End Namespace
