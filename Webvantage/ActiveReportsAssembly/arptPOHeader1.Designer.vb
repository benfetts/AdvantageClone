<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptPOHeader
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptPOHeader))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txt_IssueBy = New DataDynamics.ActiveReports.TextBox()
        Me.txt_due_date = New DataDynamics.ActiveReports.TextBox()
        Me.txt_Issue_Date = New DataDynamics.ActiveReports.TextBox()
        Me.txtPONumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAgent = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.txt_IssueBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_due_date, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Issue_Date, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPONumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txt_IssueBy, Me.txt_due_date, Me.txt_Issue_Date, Me.txtPONumber, Me.txtClientName, Me.txtAgent, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox7, Me.TextBox8, Me.TextBox9})
        Me.Detail1.Height = 0.3958333!
        Me.Detail1.Name = "Detail1"
        '
        'txt_IssueBy
        '
        Me.txt_IssueBy.CanShrink = True
        Me.txt_IssueBy.CountNullValues = True
        Me.txt_IssueBy.DataField = "ISSUE_BY"
        Me.txt_IssueBy.Height = 0.06199995!
        Me.txt_IssueBy.Left = 1.625!
        Me.txt_IssueBy.Name = "txt_IssueBy"
        Me.txt_IssueBy.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txt_IssueBy.Text = Nothing
        Me.txt_IssueBy.Top = 0.312!
        Me.txt_IssueBy.Width = 2.5!
        '
        'txt_due_date
        '
        Me.txt_due_date.CanShrink = True
        Me.txt_due_date.CountNullValues = True
        Me.txt_due_date.DataField = "PO_DUE_DATE"
        Me.txt_due_date.Height = 0.06200001!
        Me.txt_due_date.Left = 1.625!
        Me.txt_due_date.Name = "txt_due_date"
        Me.txt_due_date.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txt_due_date.Text = "//"
        Me.txt_due_date.Top = 0.2500001!
        Me.txt_due_date.Width = 2.5!
        '
        'txt_Issue_Date
        '
        Me.txt_Issue_Date.CanShrink = True
        Me.txt_Issue_Date.CountNullValues = True
        Me.txt_Issue_Date.DataField = "PO_DATE"
        Me.txt_Issue_Date.Height = 0.06199971!
        Me.txt_Issue_Date.Left = 1.625!
        Me.txt_Issue_Date.Name = "txt_Issue_Date"
        Me.txt_Issue_Date.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txt_Issue_Date.Text = "//"
        Me.txt_Issue_Date.Top = 0.187!
        Me.txt_Issue_Date.Width = 2.5!
        '
        'txtPONumber
        '
        Me.txtPONumber.CanShrink = True
        Me.txtPONumber.CountNullValues = True
        Me.txtPONumber.DataField = "PO_NUMBER"
        Me.txtPONumber.Height = 0.06199972!
        Me.txtPONumber.Left = 1.625!
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtPONumber.Text = "-1"
        Me.txtPONumber.Top = 0.1250003!
        Me.txtPONumber.Width = 2.5!
        '
        'txtClientName
        '
        Me.txtClientName.CanShrink = True
        Me.txtClientName.CountNullValues = True
        Me.txtClientName.DataField = "CL_NAME"
        Me.txtClientName.Height = 0.06150004!
        Me.txtClientName.Left = 1.625!
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtClientName.Text = Nothing
        Me.txtClientName.Top = 0.0004999638!
        Me.txtClientName.Width = 2.5!
        '
        'txtAgent
        '
        Me.txtAgent.CanShrink = True
        Me.txtAgent.CountNullValues = True
        Me.txtAgent.DataField = "AGENCY_NAME"
        Me.txtAgent.Height = 0.06199972!
        Me.txtAgent.Left = 1.625!
        Me.txtAgent.Name = "txtAgent"
        Me.txtAgent.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtAgent.Text = Nothing
        Me.txtAgent.Top = 0.06200001!
        Me.txtAgent.Width = 2.5!
        '
        'TextBox3
        '
        Me.TextBox3.CanShrink = True
        Me.TextBox3.CountNullValues = True
        Me.TextBox3.Height = 0.06200001!
        Me.TextBox3.Left = 0.0!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox3.Text = "Client Name (Principal):"
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 1.5625!
        '
        'TextBox4
        '
        Me.TextBox4.CanShrink = True
        Me.TextBox4.CountNullValues = True
        Me.TextBox4.Height = 0.06199972!
        Me.TextBox4.Left = 0.3749998!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox4.Text = "Purchase Order #:"
        Me.TextBox4.Top = 0.1250003!
        Me.TextBox4.Width = 1.1875!
        '
        'TextBox5
        '
        Me.TextBox5.CanShrink = True
        Me.TextBox5.CountNullValues = True
        Me.TextBox5.Height = 0.06199999!
        Me.TextBox5.Left = 0.375!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox5.Text = "Purchaser:"
        Me.TextBox5.Top = 0.06200001!
        Me.TextBox5.Width = 1.1875!
        '
        'TextBox7
        '
        Me.TextBox7.CanShrink = True
        Me.TextBox7.CountNullValues = True
        Me.TextBox7.Height = 0.06199971!
        Me.TextBox7.Left = 0.375!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox7.Text = "Issue Date:"
        Me.TextBox7.Top = 0.1869999!
        Me.TextBox7.Width = 1.1875!
        '
        'TextBox8
        '
        Me.TextBox8.CanShrink = True
        Me.TextBox8.CountNullValues = True
        Me.TextBox8.Height = 0.06200001!
        Me.TextBox8.Left = 0.375!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox8.Text = "Due Date:"
        Me.TextBox8.Top = 0.25!
        Me.TextBox8.Width = 1.1875!
        '
        'TextBox9
        '
        Me.TextBox9.CanShrink = True
        Me.TextBox9.CountNullValues = True
        Me.TextBox9.Height = 0.06099994!
        Me.TextBox9.Left = 0.375!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox9.Text = "Originator:"
        Me.TextBox9.Top = 0.3119999!
        Me.TextBox9.Width = 1.1875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'arptPOHeader
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 4.177083!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txt_IssueBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_due_date, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Issue_Date, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPONumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents txt_IssueBy As DataDynamics.ActiveReports.TextBox
    Private WithEvents txt_due_date As DataDynamics.ActiveReports.TextBox
    Private WithEvents txt_Issue_Date As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtPONumber As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtClientName As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtAgent As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
End Class
