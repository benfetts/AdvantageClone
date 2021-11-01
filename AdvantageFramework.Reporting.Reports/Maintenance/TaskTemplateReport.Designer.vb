Namespace Maintenance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class TaskTemplateReport
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
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.SubReport_TaskTemplateDetails = New DevExpress.XtraReports.UI.XRSubreport()
            Me.Label_TemplateCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_RushDays = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_StandardDays = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_RushDaysLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_StandardDaysLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DescriptionPh = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_TemplateCodeLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.Line_HeaderBottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line_HeaderTop = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.LineDetailSection = New DevExpress.XtraReports.UI.XRLine()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineDetailSection, Me.SubReport_TaskTemplateDetails, Me.Label_TemplateCode, Me.Label_RushDays, Me.Label_StandardDays, Me.Label_RushDaysLbl, Me.Label_StandardDaysLbl, Me.Label_Description, Me.Label_DescriptionPh, Me.Label_TemplateCodeLbl})
            Me.Detail.HeightF = 109.625!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SubReport_TaskTemplateDetails
            '
            Me.SubReport_TaskTemplateDetails.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 58.83325!)
            Me.SubReport_TaskTemplateDetails.Name = "SubReport_TaskTemplateDetails"
            Me.SubReport_TaskTemplateDetails.ReportSource = New AdvantageFramework.Reporting.Reports.Maintenance.TaskTemplateDetailsSubReport()
            Me.SubReport_TaskTemplateDetails.SizeF = New System.Drawing.SizeF(675.9999!, 23.0!)
            '
            'Label_TemplateCode
            '
            Me.Label_TemplateCode.BackColor = System.Drawing.Color.Transparent
            Me.Label_TemplateCode.BorderColor = System.Drawing.Color.Black
            Me.Label_TemplateCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_TemplateCode.BorderWidth = 1
            Me.Label_TemplateCode.CanGrow = False
            Me.Label_TemplateCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Code")})
            Me.Label_TemplateCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_TemplateCode.LocationFloat = New DevExpress.Utils.PointFloat(109.7916!, 10.00001!)
            Me.Label_TemplateCode.Name = "Label_TemplateCode"
            Me.Label_TemplateCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_TemplateCode.SizeF = New System.Drawing.SizeF(90.62444!, 19.0!)
            Me.Label_TemplateCode.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0}"
            Me.Label_TemplateCode.Summary = XrSummary1
            Me.Label_TemplateCode.Text = "Label_TemplateCode"
            Me.Label_TemplateCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_RushDays
            '
            Me.Label_RushDays.BackColor = System.Drawing.Color.Transparent
            Me.Label_RushDays.BorderColor = System.Drawing.Color.Black
            Me.Label_RushDays.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_RushDays.BorderWidth = 1
            Me.Label_RushDays.CanGrow = False
            Me.Label_RushDays.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalRushDays")})
            Me.Label_RushDays.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_RushDays.LocationFloat = New DevExpress.Utils.PointFloat(551.1665!, 29.0!)
            Me.Label_RushDays.Name = "Label_RushDays"
            Me.Label_RushDays.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_RushDays.SizeF = New System.Drawing.SizeF(88.83331!, 19.0!)
            Me.Label_RushDays.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0}"
            Me.Label_RushDays.Summary = XrSummary2
            Me.Label_RushDays.Text = "Label_RushDays"
            Me.Label_RushDays.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_StandardDays
            '
            Me.Label_StandardDays.BackColor = System.Drawing.Color.Transparent
            Me.Label_StandardDays.BorderColor = System.Drawing.Color.Black
            Me.Label_StandardDays.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_StandardDays.BorderWidth = 1
            Me.Label_StandardDays.CanGrow = False
            Me.Label_StandardDays.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalStandardDays")})
            Me.Label_StandardDays.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_StandardDays.LocationFloat = New DevExpress.Utils.PointFloat(551.1665!, 10.00001!)
            Me.Label_StandardDays.Name = "Label_StandardDays"
            Me.Label_StandardDays.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_StandardDays.SizeF = New System.Drawing.SizeF(88.83331!, 19.0!)
            Me.Label_StandardDays.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0}"
            Me.Label_StandardDays.Summary = XrSummary3
            Me.Label_StandardDays.Text = "Label_StandardDays"
            Me.Label_StandardDays.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_RushDaysLbl
            '
            Me.Label_RushDaysLbl.BackColor = System.Drawing.Color.Transparent
            Me.Label_RushDaysLbl.BorderColor = System.Drawing.Color.Black
            Me.Label_RushDaysLbl.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_RushDaysLbl.BorderWidth = 1
            Me.Label_RushDaysLbl.CanGrow = False
            Me.Label_RushDaysLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_RushDaysLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_RushDaysLbl.LocationFloat = New DevExpress.Utils.PointFloat(454.0415!, 29.0!)
            Me.Label_RushDaysLbl.Name = "Label_RushDaysLbl"
            Me.Label_RushDaysLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_RushDaysLbl.SizeF = New System.Drawing.SizeF(97.12497!, 19.0!)
            Me.Label_RushDaysLbl.StylePriority.UseFont = False
            Me.Label_RushDaysLbl.Text = "Rush Days:"
            Me.Label_RushDaysLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_StandardDaysLbl
            '
            Me.Label_StandardDaysLbl.BackColor = System.Drawing.Color.Transparent
            Me.Label_StandardDaysLbl.BorderColor = System.Drawing.Color.Black
            Me.Label_StandardDaysLbl.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_StandardDaysLbl.BorderWidth = 1
            Me.Label_StandardDaysLbl.CanGrow = False
            Me.Label_StandardDaysLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_StandardDaysLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_StandardDaysLbl.LocationFloat = New DevExpress.Utils.PointFloat(454.0415!, 10.00001!)
            Me.Label_StandardDaysLbl.Name = "Label_StandardDaysLbl"
            Me.Label_StandardDaysLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_StandardDaysLbl.SizeF = New System.Drawing.SizeF(97.12527!, 19.0!)
            Me.Label_StandardDaysLbl.StylePriority.UseFont = False
            Me.Label_StandardDaysLbl.Text = "Standard Days:"
            Me.Label_StandardDaysLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Label_Description.LocationFloat = New DevExpress.Utils.PointFloat(109.7916!, 29.0!)
            Me.Label_Description.Name = "Label_Description"
            Me.Label_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Description.SizeF = New System.Drawing.SizeF(315.6245!, 19.0!)
            Me.Label_Description.StylePriority.UseFont = False
            XrSummary4.FormatString = "{0}"
            Me.Label_Description.Summary = XrSummary4
            Me.Label_Description.Text = "Label_Description"
            Me.Label_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DescriptionPh
            '
            Me.Label_DescriptionPh.BackColor = System.Drawing.Color.Transparent
            Me.Label_DescriptionPh.BorderColor = System.Drawing.Color.Black
            Me.Label_DescriptionPh.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DescriptionPh.BorderWidth = 1
            Me.Label_DescriptionPh.CanGrow = False
            Me.Label_DescriptionPh.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DescriptionPh.ForeColor = System.Drawing.Color.Black
            Me.Label_DescriptionPh.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 29.0!)
            Me.Label_DescriptionPh.Name = "Label_DescriptionPh"
            Me.Label_DescriptionPh.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_DescriptionPh.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.Label_DescriptionPh.StylePriority.UseFont = False
            Me.Label_DescriptionPh.Text = "Description:"
            Me.Label_DescriptionPh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.Label_TemplateCodeLbl.SizeF = New System.Drawing.SizeF(99.79166!, 19.0!)
            Me.Label_TemplateCodeLbl.StylePriority.UseFont = False
            Me.Label_TemplateCodeLbl.Text = "Template Code:"
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
            Me.LabelPageHeader_Title.Text = "Task Templates Report"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.TaskTemplate)
            '
            'LineDetailSection
            '
            Me.LineDetailSection.BorderColor = System.Drawing.Color.Silver
            Me.LineDetailSection.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineDetailSection.BorderWidth = 4
            Me.LineDetailSection.ForeColor = System.Drawing.Color.Silver
            Me.LineDetailSection.LineWidth = 4
            Me.LineDetailSection.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 95.62498!)
            Me.LineDetailSection.Name = "LineDetailSection"
            Me.LineDetailSection.SizeF = New System.Drawing.SizeF(676.0!, 4.000004!)
            '
            'TaskTemplateReport
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
        Private WithEvents Label_DescriptionPh As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents Label_RushDays As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_StandardDays As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_RushDaysLbl As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_StandardDaysLbl As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_TemplateCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SubReport_TaskTemplateDetails As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Private WithEvents LineDetailSection As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
