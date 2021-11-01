Namespace Maintenance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class TaskTemplateWithRolesReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LineDetailSection = New DevExpress.XtraReports.UI.XRLine()
            Me.SubReport_TaskTemplateWithRoles = New DevExpress.XtraReports.UI.XRSubreport()
            Me.Label_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_TemplateCodeLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.Line_HeaderBottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line_HeaderTop = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineDetailSection, Me.SubReport_TaskTemplateWithRoles, Me.Label_Description, Me.Label_TemplateCodeLbl})
            Me.Detail.HeightF = 85.66666!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineDetailSection
            '
            Me.LineDetailSection.BorderColor = System.Drawing.Color.Silver
            Me.LineDetailSection.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineDetailSection.BorderWidth = 4
            Me.LineDetailSection.ForeColor = System.Drawing.Color.Silver
            Me.LineDetailSection.LineWidth = 4
            Me.LineDetailSection.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 73.74998!)
            Me.LineDetailSection.Name = "LineDetailSection"
            Me.LineDetailSection.SizeF = New System.Drawing.SizeF(676.0!, 4.000004!)
            '
            'SubReport_TaskTemplateWithRoles
            '
            Me.SubReport_TaskTemplateWithRoles.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 40.45836!)
            Me.SubReport_TaskTemplateWithRoles.Name = "SubReport_TaskTemplateWithRoles"
            Me.SubReport_TaskTemplateWithRoles.ReportSource = New AdvantageFramework.Reporting.Reports.Maintenance.TaskTemplateWithRolesSubReport()
            Me.SubReport_TaskTemplateWithRoles.SizeF = New System.Drawing.SizeF(675.9999!, 23.0!)
            '
            'Label_Description
            '
            Me.Label_Description.BackColor = System.Drawing.Color.Transparent
            Me.Label_Description.BorderColor = System.Drawing.Color.Black
            Me.Label_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Description.BorderWidth = 1
            Me.Label_Description.CanGrow = False
            Me.Label_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.Label_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Description.LocationFloat = New DevExpress.Utils.PointFloat(71.25015!, 10.00001!)
            Me.Label_Description.Name = "Label_Description"
            Me.Label_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Description.SizeF = New System.Drawing.SizeF(315.6245!, 19.0!)
            Me.Label_Description.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0}"
            Me.Label_Description.Summary = XrSummary1
            Me.Label_Description.Text = "Label_Description"
            Me.Label_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_TemplateCodeLbl
            '
            Me.Label_TemplateCodeLbl.BackColor = System.Drawing.Color.Transparent
            Me.Label_TemplateCodeLbl.BorderColor = System.Drawing.Color.Black
            Me.Label_TemplateCodeLbl.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_TemplateCodeLbl.BorderWidth = 1
            Me.Label_TemplateCodeLbl.CanGrow = False
            Me.Label_TemplateCodeLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_TemplateCodeLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_TemplateCodeLbl.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 10.00001!)
            Me.Label_TemplateCodeLbl.Name = "Label_TemplateCodeLbl"
            Me.Label_TemplateCodeLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_TemplateCodeLbl.SizeF = New System.Drawing.SizeF(61.24999!, 19.0!)
            Me.Label_TemplateCodeLbl.StylePriority.UseFont = False
            Me.Label_TemplateCodeLbl.Text = "Template:"
            Me.Label_TemplateCodeLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Line_HeaderBottom, Me.LabelPageHeader_Agency, Me.Line_HeaderTop, Me.LabelPageHeader_Title})
            Me.PageHeader.HeightF = 68.12496!
            Me.PageHeader.Name = "PageHeader"
            '
            'Line_HeaderBottom
            '
            Me.Line_HeaderBottom.BorderColor = System.Drawing.Color.Silver
            Me.Line_HeaderBottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line_HeaderBottom.BorderWidth = 4
            Me.Line_HeaderBottom.ForeColor = System.Drawing.Color.Silver
            Me.Line_HeaderBottom.LineWidth = 4
            Me.Line_HeaderBottom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 57.5833!)
            Me.Line_HeaderBottom.Name = "Line_HeaderBottom"
            Me.Line_HeaderBottom.SizeF = New System.Drawing.SizeF(676.0!, 4.000004!)
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(331.1668!, 27.00001!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(308.833!, 19.0!)
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Line_HeaderTop
            '
            Me.Line_HeaderTop.BorderColor = System.Drawing.Color.Silver
            Me.Line_HeaderTop.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line_HeaderTop.BorderWidth = 4
            Me.Line_HeaderTop.ForeColor = System.Drawing.Color.Silver
            Me.Line_HeaderTop.LineWidth = 4
            Me.Line_HeaderTop.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
            Me.Line_HeaderTop.Name = "Line_HeaderTop"
            Me.Line_HeaderTop.SizeF = New System.Drawing.SizeF(675.9999!, 4.00002!)
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
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(321.1667!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Task Templates with Roles Report"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.TaskTemplate)
            '
            'TaskTemplateWithRolesReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader})
            Me.DataSource = Me.BindingSource
            Me.Margins = New System.Drawing.Printing.Margins(86, 88, 39, 100)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents Line_HeaderTop As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Line_HeaderBottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents Label_TemplateCodeLbl As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents SubReport_TaskTemplateWithRoles As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Private WithEvents LineDetailSection As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
