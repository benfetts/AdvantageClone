<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEstHeaderQuarry
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
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEstHeaderQuarry))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtJC = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalForEst = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
        Me.txtJob = New DataDynamics.ActiveReports.TextBox()
        Me.txtComp = New DataDynamics.ActiveReports.TextBox()
        Me.txtMarkupAmtGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTax = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox32 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.txtTaxTotal = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxMarkup = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxCompDesc = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtJC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalForEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxMarkup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtJC, Me.txtTotalForEst, Me.TextBox20, Me.txtJob, Me.txtComp, Me.txtMarkupAmtGrouping, Me.TextBox3, Me.txtTax, Me.TextBoxCompDesc})
        Me.Detail1.Height = 0.2078333!
        Me.Detail1.Name = "Detail1"
        '
        'txtJC
        '
        Me.txtJC.Height = 0.1875!
        Me.txtJC.Left = 1.062!
        Me.txtJC.Name = "txtJC"
        Me.txtJC.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.txtJC.Text = Nothing
        Me.txtJC.Top = 0.0!
        Me.txtJC.Width = 0.875!
        '
        'txtTotalForEst
        '
        Me.txtTotalForEst.DataField = "EST_REV_EXT_AMT"
        Me.txtTotalForEst.Height = 0.1875!
        Me.txtTotalForEst.Left = 5.75!
        Me.txtTotalForEst.Name = "txtTotalForEst"
        Me.txtTotalForEst.OutputFormat = resources.GetString("txtTotalForEst.OutputFormat")
        Me.txtTotalForEst.Style = "font-size: 9pt; font-weight: normal; text-align: right; ddo-char-set: 0"
        Me.txtTotalForEst.Text = Nothing
        Me.txtTotalForEst.Top = 0.0!
        Me.txtTotalForEst.Width = 1.249499!
        '
        'TextBox20
        '
        Me.TextBox20.CanShrink = True
        Me.TextBox20.Height = 0.1875!
        Me.TextBox20.Left = 0.0!
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox20.Text = "Job:"
        Me.TextBox20.Top = 0.0!
        Me.TextBox20.Width = 0.937!
        '
        'txtJob
        '
        Me.txtJob.CanShrink = True
        Me.txtJob.DataField = "JOB_NUMBER"
        Me.txtJob.Height = 0.1875!
        Me.txtJob.Left = 0.125!
        Me.txtJob.Name = "txtJob"
        Me.txtJob.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtJob.Text = Nothing
        Me.txtJob.Top = 0.312!
        Me.txtJob.Visible = False
        Me.txtJob.Width = 0.125!
        '
        'txtComp
        '
        Me.txtComp.CanShrink = True
        Me.txtComp.DataField = "JOB_COMPONENT_NBR"
        Me.txtComp.Height = 0.1875!
        Me.txtComp.Left = 0.312!
        Me.txtComp.Name = "txtComp"
        Me.txtComp.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtComp.Text = Nothing
        Me.txtComp.Top = 0.312!
        Me.txtComp.Visible = False
        Me.txtComp.Width = 0.125!
        '
        'txtMarkupAmtGrouping
        '
        Me.txtMarkupAmtGrouping.DataField = "EXT_MARKUP_AMT"
        Me.txtMarkupAmtGrouping.Height = 0.1875!
        Me.txtMarkupAmtGrouping.Left = 6.812!
        Me.txtMarkupAmtGrouping.Name = "txtMarkupAmtGrouping"
        Me.txtMarkupAmtGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMarkupAmtGrouping.Text = Nothing
        Me.txtMarkupAmtGrouping.Top = 0.25!
        Me.txtMarkupAmtGrouping.Visible = False
        Me.txtMarkupAmtGrouping.Width = 0.125!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "EST_REV_EXT_AMT"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 4.25!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "font-size: 9pt; font-weight: normal; text-align: right; ddo-char-set: 0"
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Visible = False
        Me.TextBox3.Width = 1.249499!
        '
        'txtTax
        '
        Me.txtTax.DataField = "TAX"
        Me.txtTax.Height = 0.1875!
        Me.txtTax.Left = 6.625!
        Me.txtTax.Name = "txtTax"
        Me.txtTax.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTax.Text = Nothing
        Me.txtTax.Top = 0.25!
        Me.txtTax.Visible = False
        Me.txtTax.Width = 0.125!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox32, Me.TextBox2, Me.TextBox11})
        Me.GroupHeader1.Height = 0.2083333!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.Visible = False
        '
        'TextBox32
        '
        Me.TextBox32.CanShrink = True
        Me.TextBox32.Height = 0.1875!
        Me.TextBox32.Left = 6.0!
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox32.Text = "Total"
        Me.TextBox32.Top = 0.0!
        Me.TextBox32.Width = 1.0!
        '
        'TextBox2
        '
        Me.TextBox2.CanShrink = True
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 4.5!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox2.Text = "Subtotal"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 1.0!
        '
        'TextBox11
        '
        Me.TextBox11.CanShrink = True
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 0.0!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox11.Text = "Campaign Summary"
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 3.688!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox4, Me.Line1, Me.txtTaxTotal, Me.TextBoxMarkup})
        Me.GroupFooter1.Height = 0.2604165!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "EST_REV_EXT_AMT"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 5.75!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "font-size: 9pt; font-weight: normal; text-align: right; ddo-char-set: 0"
        Me.TextBox1.SummaryGroup = "GroupHeader1"
        Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.062!
        Me.TextBox1.Width = 1.249499!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "EST_REV_EXT_AMT"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 4.25!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "font-size: 9pt; font-weight: normal; text-align: right; ddo-char-set: 0"
        Me.TextBox4.SummaryGroup = "GroupHeader1"
        Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.062!
        Me.TextBox4.Visible = False
        Me.TextBox4.Width = 1.249499!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 3.687!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.062!
        Me.Line1.Width = 3.313!
        Me.Line1.X1 = 3.687!
        Me.Line1.X2 = 7.0!
        Me.Line1.Y1 = 0.062!
        Me.Line1.Y2 = 0.062!
        '
        'txtTaxTotal
        '
        Me.txtTaxTotal.DataField = "TAX"
        Me.txtTaxTotal.Height = 0.1875!
        Me.txtTaxTotal.Left = 6.875!
        Me.txtTaxTotal.Name = "txtTaxTotal"
        Me.txtTaxTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTaxTotal.SummaryGroup = "GroupHeader1"
        Me.txtTaxTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTaxTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTaxTotal.Text = Nothing
        Me.txtTaxTotal.Top = 0.312!
        Me.txtTaxTotal.Visible = False
        Me.txtTaxTotal.Width = 0.125!
        '
        'TextBoxMarkup
        '
        Me.TextBoxMarkup.DataField = "EXT_MARKUP_AMT"
        Me.TextBoxMarkup.Height = 0.1875!
        Me.TextBoxMarkup.Left = 6.687!
        Me.TextBoxMarkup.Name = "TextBoxMarkup"
        Me.TextBoxMarkup.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBoxMarkup.SummaryGroup = "GroupHeader1"
        Me.TextBoxMarkup.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBoxMarkup.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBoxMarkup.Text = Nothing
        Me.TextBoxMarkup.Top = 0.312!
        Me.TextBoxMarkup.Visible = False
        Me.TextBoxMarkup.Width = 0.125!
        '
        'TextBoxCompDesc
        '
        Me.TextBoxCompDesc.DataField = "JOB_DESC"
        Me.TextBoxCompDesc.Height = 0.1875!
        Me.TextBoxCompDesc.Left = 2.0!
        Me.TextBoxCompDesc.Name = "TextBoxCompDesc"
        Me.TextBoxCompDesc.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.TextBoxCompDesc.Text = Nothing
        Me.TextBoxCompDesc.Top = 0.0!
        Me.TextBoxCompDesc.Visible = False
        Me.TextBoxCompDesc.Width = 2.25!
        '
        'arptEstHeaderQuarry
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtJC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalForEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxMarkup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents txtJC As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalForEst As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox20 As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents txtJob As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtComp As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents txtMarkupAmtGrouping As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox32 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtTax As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtTaxTotal As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxMarkup As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxCompDesc As DataDynamics.ActiveReports.TextBox
End Class
