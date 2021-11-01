<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEmpNPTime 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEmpNPTime))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.TBOffice = New DataDynamics.ActiveReports.TextBox()
        Me.TBEmp = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportHeader = New DataDynamics.ActiveReports.Label()
        Me.lblDate = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.LabelOfficeHDR = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.lbluser = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.LabelEmpHDR = New DataDynamics.ActiveReports.Label()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.TBEmpCode = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelOfficeHDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelEmpHDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBEmpCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8})
        Me.Detail1.Height = 0.1875!
        Me.Detail1.Name = "Detail1"
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "DESCRIPTION"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 1.1875!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "font-size: 9pt"
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 2.1875!
        '
        'TextBox5
        '
        Me.TextBox5.DataField = "DATE_STRING"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 3.5!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "font-size: 9pt"
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 1.375!
        '
        'TextBox6
        '
        Me.TextBox6.DataField = "AVAIL_HRS"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 5.1875!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "font-size: 9pt; text-align: right"
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.6875!
        '
        'TextBox7
        '
        Me.TextBox7.DataField = "HRS_USED"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 6.0!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "font-size: 9pt; text-align: right; white-space: nowrap"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.5625!
        '
        'TextBox8
        '
        Me.TextBox8.DataField = "VARIANCE"
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 6.6875!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 9pt; text-align: right; white-space: nowrap"
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.5625!
        '
        'TBOffice
        '
        Me.TBOffice.DataField = "OFFICE_NAME"
        Me.TBOffice.DistinctField = "OFFICE_NAME"
        Me.TBOffice.Height = 0.1875!
        Me.TBOffice.Left = 0.125!
        Me.TBOffice.Name = "TBOffice"
        Me.TBOffice.Style = "font-size: 9pt"
        Me.TBOffice.Text = Nothing
        Me.TBOffice.Top = 0.375!
        Me.TBOffice.Width = 0.875!
        '
        'TBEmp
        '
        Me.TBEmp.DataField = "EMPLOYEE_NAME"
        Me.TBEmp.DistinctField = "EMPLOYEE_NAME"
        Me.TBEmp.Height = 0.1875!
        Me.TBEmp.Left = 0.0!
        Me.TBEmp.Name = "TBEmp"
        Me.TBEmp.Text = Nothing
        Me.TBEmp.Top = 0.5!
        Me.TBEmp.Width = 1.4375!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportHeader, Me.lblDate})
        Me.ReportHeader1.Height = 0.375!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.25!
        Me.ReportHeader.HyperLink = Nothing
        Me.ReportHeader.Left = 0.125!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.Style = "font-size: 14pt; font-weight: bold; text-align: left"
        Me.ReportHeader.Text = "Employee Indirect Time"
        Me.ReportHeader.Top = 0.0625!
        Me.ReportHeader.Width = 4.9375!
        '
        'lblDate
        '
        Me.lblDate.Height = 0.1875!
        Me.lblDate.HyperLink = Nothing
        Me.lblDate.Left = 6.125!
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Style = "font-weight: bold; text-align: right"
        Me.lblDate.Text = ""
        Me.lblDate.Top = 0.125!
        Me.lblDate.Width = 1.375!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.3229167!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LabelOfficeHDR, Me.TBOffice, Me.Line1})
        Me.GroupHeader1.DataField = "OFFICE_NAME"
        Me.GroupHeader1.Height = 0.2395833!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'LabelOfficeHDR
        '
        Me.LabelOfficeHDR.Height = 0.1875!
        Me.LabelOfficeHDR.HyperLink = Nothing
        Me.LabelOfficeHDR.Left = 0.0625!
        Me.LabelOfficeHDR.Name = "LabelOfficeHDR"
        Me.LabelOfficeHDR.Style = "font-size: 9pt; font-weight: bold"
        Me.LabelOfficeHDR.Text = "Office:"
        Me.LabelOfficeHDR.Top = 0.0!
        Me.LabelOfficeHDR.Width = 4.375!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.1875!
        Me.Line1.Width = 7.4375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.5!
        Me.Line1.Y1 = 0.1875!
        Me.Line1.Y2 = 0.1875!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line3})
        Me.GroupFooter1.Height = 0.22!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.1875!
        Me.Line3.Width = 7.4375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 7.5!
        Me.Line3.Y1 = 0.1875!
        Me.Line3.Y2 = 0.1875!
        '
        'Label5
        '
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 3.5!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-weight: bold; text-align: left"
        Me.Label5.Text = "Dates"
        Me.Label5.Top = 0.1875!
        Me.Label5.Width = 1.5!
        '
        'Label6
        '
        Me.Label6.Height = 0.34!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 5.1875!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-weight: bold; text-align: right"
        Me.Label6.Text = "Hours Available"
        Me.Label6.Top = 0.0625!
        Me.Label6.Width = 0.6875!
        '
        'Label7
        '
        Me.Label7.Height = 0.34!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 6.0!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-weight: bold; text-align: right"
        Me.Label7.Text = "Hours Used"
        Me.Label7.Top = 0.0625!
        Me.Label7.Width = 0.5625!
        '
        'Label8
        '
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 6.6875!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-weight: bold; text-align: right"
        Me.Label8.Text = "Variance"
        Me.Label8.Top = 0.1875!
        Me.Label8.Width = 0.625!
        '
        'Label1
        '
        Me.Label1.Height = 0.1979167!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.1875!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-weight: bold"
        Me.Label1.Text = "Description"
        Me.Label1.Top = 0.1875!
        Me.Label1.Width = 2.1875!
        '
        'PageHeader1
        '
        Me.PageHeader1.BackColor = System.Drawing.Color.LightGray
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label1})
        Me.PageHeader1.Height = 0.375!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1, Me.ReportInfo2, Me.lbluser})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.FormatString = "{RunDateTime:}"
        Me.ReportInfo1.Height = 0.1979167!
        Me.ReportInfo1.Left = 0.0!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-size: 8pt"
        Me.ReportInfo1.Top = 0.0!
        Me.ReportInfo1.Width = 1.7!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo2.Height = 0.1875!
        Me.ReportInfo2.Left = 6.375!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 8.25pt"
        Me.ReportInfo2.Top = 0.0!
        Me.ReportInfo2.Width = 1.125!
        '
        'lbluser
        '
        Me.lbluser.Height = 0.1979167!
        Me.lbluser.HyperLink = Nothing
        Me.lbluser.Left = 1.75!
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Style = "font-size: 8pt"
        Me.lbluser.Text = ""
        Me.lbluser.Top = 0.0!
        Me.lbluser.Width = 1.0!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LabelEmpHDR, Me.TBEmp, Me.Line2, Me.TBEmpCode})
        Me.GroupHeader2.DataField = "EMP_CODE"
        Me.GroupHeader2.Height = 0.2916667!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'LabelEmpHDR
        '
        Me.LabelEmpHDR.Height = 0.1875!
        Me.LabelEmpHDR.HyperLink = Nothing
        Me.LabelEmpHDR.Left = 0.1875!
        Me.LabelEmpHDR.Name = "LabelEmpHDR"
        Me.LabelEmpHDR.Style = "font-size: 9pt; font-weight: bold"
        Me.LabelEmpHDR.Text = "Employee:"
        Me.LabelEmpHDR.Top = 0.0625!
        Me.LabelEmpHDR.Width = 4.3125!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.25!
        Me.Line2.Width = 7.4375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.5!
        Me.Line2.Y1 = 0.25!
        Me.Line2.Y2 = 0.25!
        '
        'TBEmpCode
        '
        Me.TBEmpCode.DataField = "EMP_CODE"
        Me.TBEmpCode.DistinctField = "EMP_CODE"
        Me.TBEmpCode.Height = 0.1979167!
        Me.TBEmpCode.Left = 1.8125!
        Me.TBEmpCode.Name = "TBEmpCode"
        Me.TBEmpCode.Text = Nothing
        Me.TBEmpCode.Top = 0.5!
        Me.TBEmpCode.Width = 1.0!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.04166667!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'arptEmpNPTime
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.604167!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ddo-char-set: 204", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelOfficeHDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelEmpHDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBEmpCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents ReportHeader As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDate As DataDynamics.ActiveReports.Label
    Friend WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Friend WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    Friend WithEvents TBOffice As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TBEmp As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lbluser As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelOfficeHDR As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents LabelEmpHDR As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents TBEmpCode As DataDynamics.ActiveReports.TextBox
End Class
