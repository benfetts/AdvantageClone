<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptCreativeBrief 
    Inherits DataDynamics.ActiveReports.ActiveReport

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptCreativeBrief))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.txtAgencyInfo = New DataDynamics.ActiveReports.TextBox()
        Me.txtAgencyName = New DataDynamics.ActiveReports.TextBox()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.level = New DataDynamics.ActiveReports.Label()
        Me.fontsize = New DataDynamics.ActiveReports.Label()
        Me.fontstyle = New DataDynamics.ActiveReports.Label()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.lblBy = New DataDynamics.ActiveReports.Label()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.txtQuantityTitle = New DataDynamics.ActiveReports.TextBox()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.HtmlExport1 = New DataDynamics.ActiveReports.Export.Html.HtmlExport()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.level, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fontsize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fontstyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantityTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAgencyInfo, Me.txtAgencyName, Me.Picture1})
        Me.PageHeader1.Height = 1.979167!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'txtAgencyInfo
        '
        Me.txtAgencyInfo.CanShrink = True
        Me.txtAgencyInfo.Height = 0.1875!
        Me.txtAgencyInfo.Left = 0.0625!
        Me.txtAgencyInfo.Name = "txtAgencyInfo"
        Me.txtAgencyInfo.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtAgencyInfo.Text = "txtAgencyInfo"
        Me.txtAgencyInfo.Top = 1.75!
        Me.txtAgencyInfo.Width = 7.375!
        '
        'txtAgencyName
        '
        Me.txtAgencyName.CanShrink = True
        Me.txtAgencyName.Height = 0.1875!
        Me.txtAgencyName.Left = 0.0625!
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtAgencyName.Text = "txtAgencyName"
        Me.txtAgencyName.Top = 1.5625!
        Me.txtAgencyName.Width = 7.375!
        '
        'Picture1
        '
        Me.Picture1.Height = 1.5!
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.0625!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft
        Me.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 7.375!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.level, Me.fontsize, Me.fontstyle, Me.TextBox2, Me.TextBox3, Me.TextBox4})
        Me.Detail1.Height = 0.2916665!
        Me.Detail1.Name = "Detail1"
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.DataField = "Desc"
        Me.TextBox1.Height = 0.06200001!
        Me.TextBox1.Left = 0.05!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.Top = 0!
        Me.TextBox1.Width = 7.1875!
        '
        'level
        '
        Me.level.DataField = "Level"
        Me.level.Height = 0.1979167!
        Me.level.HyperLink = Nothing
        Me.level.Left = 2.875!
        Me.level.Name = "level"
        Me.level.Style = ""
        Me.level.Text = "level"
        Me.level.Top = 1.25!
        Me.level.Visible = False
        Me.level.Width = 1.0!
        '
        'fontsize
        '
        Me.fontsize.DataField = "fontsize"
        Me.fontsize.Height = 0.1979167!
        Me.fontsize.HyperLink = Nothing
        Me.fontsize.Left = 4.125!
        Me.fontsize.Name = "fontsize"
        Me.fontsize.Style = ""
        Me.fontsize.Text = "fontsize"
        Me.fontsize.Top = 1.1875!
        Me.fontsize.Visible = False
        Me.fontsize.Width = 1.0!
        '
        'fontstyle
        '
        Me.fontstyle.DataField = "fontstyle"
        Me.fontstyle.Height = 0.1979167!
        Me.fontstyle.HyperLink = Nothing
        Me.fontstyle.Left = 5.4375!
        Me.fontstyle.Name = "fontstyle"
        Me.fontstyle.Style = ""
        Me.fontstyle.Text = "fontstyle"
        Me.fontstyle.Top = 1.1875!
        Me.fontstyle.Visible = False
        Me.fontstyle.Width = 1.0!
        '
        'TextBox2
        '
        Me.TextBox2.CanShrink = True
        Me.TextBox2.DataField = "Desc"
        Me.TextBox2.Height = 0.06299999!
        Me.TextBox2.Left = 0.312!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Text = "TextBox2"
        Me.TextBox2.Top = 0.06200001!
        Me.TextBox2.Width = 6.9375!
        '
        'TextBox3
        '
        Me.TextBox3.CanShrink = True
        Me.TextBox3.DataField = "Desc"
        Me.TextBox3.Height = 0.06299999!
        Me.TextBox3.Left = 0.625!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Text = "TextBox3"
        Me.TextBox3.Top = 0.125!
        Me.TextBox3.Width = 6.625!
        '
        'TextBox4
        '
        Me.TextBox4.CanShrink = True
        Me.TextBox4.DataField = "Desc"
        Me.TextBox4.Height = 0.06299999!
        Me.TextBox4.Left = 0.812!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Text = "TextBox4"
        Me.TextBox4.Top = 0.187!
        Me.TextBox4.Width = 6.4375!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1, Me.lblBy, Me.ReportInfo2})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1979167!
        Me.ReportInfo1.Left = 6.375!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-size: 9pt"
        Me.ReportInfo1.Top = 0!
        Me.ReportInfo1.Width = 1.0!
        '
        'lblBy
        '
        Me.lblBy.Height = 0.1875!
        Me.lblBy.HyperLink = Nothing
        Me.lblBy.Left = 1.375!
        Me.lblBy.Name = "lblBy"
        Me.lblBy.Style = "font-size: 9pt"
        Me.lblBy.Text = "lblBy"
        Me.lblBy.Top = 0!
        Me.lblBy.Visible = False
        Me.lblBy.Width = 2.9375!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{RunDateTime:}"
        Me.ReportInfo2.Height = 0.1875!
        Me.ReportInfo2.Left = 0!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 9pt; text-align: right"
        Me.ReportInfo2.Top = 0!
        Me.ReportInfo2.Visible = False
        Me.ReportInfo2.Width = 1.375!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.Line1, Me.Line2, Me.Line3, Me.txtQuantityTitle, Me.SubReport1, Me.SubReport2})
        Me.GroupHeader1.Height = 0.7847223!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblReportTitle
        '
        Me.lblReportTitle.Height = 0.25!
        Me.lblReportTitle.HyperLink = Nothing
        Me.lblReportTitle.Left = 0.062!
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Style = "font-size: 14.25pt; font-weight: bold; vertical-align: middle; ddo-char-set: 0"
        Me.lblReportTitle.Text = "Report Title"
        Me.lblReportTitle.Top = 0!
        Me.lblReportTitle.Width = 7.25!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0!
        Me.Line1.Width = 7.4375!
        Me.Line1.X1 = 0!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0!
        Me.Line1.Y2 = 0!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.25!
        Me.Line2.Width = 7.4375!
        Me.Line2.X1 = 0!
        Me.Line2.X2 = 7.4375!
        Me.Line2.Y1 = 0.25!
        Me.Line2.Y2 = 0.25!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.75!
        Me.Line3.Width = 7.375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 7.4375!
        Me.Line3.Y1 = 0.75!
        Me.Line3.Y2 = 0.75!
        '
        'txtQuantityTitle
        '
        Me.txtQuantityTitle.Height = 0.1979167!
        Me.txtQuantityTitle.Left = 0!
        Me.txtQuantityTitle.Name = "txtQuantityTitle"
        Me.txtQuantityTitle.Style = "background-color: Gray; color: White; font-size: 9pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.txtQuantityTitle.Text = "Details"
        Me.txtQuantityTitle.Top = 0.5625!
        Me.txtQuantityTitle.Width = 1.0!
        '
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.1875!
        Me.SubReport1.Left = 0!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = "SubReport1"
        Me.SubReport1.Top = 0.3125!
        Me.SubReport1.Width = 4.437!
        '
        'SubReport2
        '
        Me.SubReport2.CloseBorder = False
        Me.SubReport2.Height = 0.1875!
        Me.SubReport2.Left = 4.5!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.ReportName = "SubReport2"
        Me.SubReport2.Top = 0.3125!
        Me.SubReport2.Width = 2.9375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.25!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'arptCreativeBrief
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.25!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.level, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fontsize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fontstyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantityTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtAgencyInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAgencyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtQuantityTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lblBy As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents HtmlExport1 As DataDynamics.ActiveReports.Export.Html.HtmlExport
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents level As DataDynamics.ActiveReports.Label
    Friend WithEvents fontsize As DataDynamics.ActiveReports.Label
    Friend WithEvents fontstyle As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents SubReport2 As DataDynamics.ActiveReports.SubReport
End Class
