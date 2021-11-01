<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptOpenJobsSch 
    Inherits DataDynamics.ActiveReports.ActiveReport

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    'Required by the ActiveReports Designer
    Private components As System.ComponentModel.IContainer
    
    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptOpenJobsSch))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtStarted = New DataDynamics.ActiveReports.TextBox
        Me.txtJob1 = New DataDynamics.ActiveReports.TextBox
        Me.txtComponentNumber = New DataDynamics.ActiveReports.TextBox
        Me.txtComponent1 = New DataDynamics.ActiveReports.TextBox
        Me.txtAccount_Executive1 = New DataDynamics.ActiveReports.TextBox
        Me.txtOpenDate = New DataDynamics.ActiveReports.TextBox
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo
        Me.lbluser = New DataDynamics.ActiveReports.Label
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtOpenDates = New DataDynamics.ActiveReports.TextBox
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.txtClientCode = New DataDynamics.ActiveReports.TextBox
        Me.txtClient1 = New DataDynamics.ActiveReports.TextBox
        Me.txtDivision1 = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.txtProductCode = New DataDynamics.ActiveReports.TextBox
        Me.txtProduct1 = New DataDynamics.ActiveReports.TextBox
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.txtDivisionCode = New DataDynamics.ActiveReports.TextBox
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.ArptOpenJobsDS1 = New ActiveReportsAssembly.arptOpenJobsDS
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStarted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJob1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponentNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccount_Executive1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOpenDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOpenDates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClient1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivision1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivisionCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArptOpenJobsDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.BackColor = System.Drawing.Color.LightGray
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label3, Me.Label6, Me.Label5, Me.Label4, Me.Label7})
        Me.PageHeader1.Height = 0.302!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 6.8125!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label3.Text = "Started?"
        Me.Label3.Top = 0.0625!
        Me.Label3.Width = 0.8125!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 2.063!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label6.Text = "Component"
        Me.Label6.Top = 0.063!
        Me.Label6.Width = 2.6875!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 4.813!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label5.Text = "A/E"
        Me.Label5.Top = 0.063!
        Me.Label5.Width = 1.0!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 5.875!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label4.Text = "Date Opened"
        Me.Label4.Top = 0.0625!
        Me.Label4.Width = 0.875!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.063!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label7.Text = "Job"
        Me.Label7.Top = 0.063!
        Me.Label7.Width = 1.875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtStarted, Me.txtJob1, Me.txtComponentNumber, Me.txtComponent1, Me.txtAccount_Executive1, Me.txtOpenDate, Me.txtJobNumber})
        Me.Detail1.Height = 0.15625!
        Me.Detail1.Name = "Detail1"
        '
        'txtStarted
        '
        Me.txtStarted.Border.BottomColor = System.Drawing.Color.Black
        Me.txtStarted.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStarted.Border.LeftColor = System.Drawing.Color.Black
        Me.txtStarted.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStarted.Border.RightColor = System.Drawing.Color.Black
        Me.txtStarted.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStarted.Border.TopColor = System.Drawing.Color.Black
        Me.txtStarted.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStarted.DataField = "ROWID"
        Me.txtStarted.Height = 0.1875!
        Me.txtStarted.Left = 6.802083!
        Me.txtStarted.Name = "txtStarted"
        Me.txtStarted.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtStarted.Text = "txtStarted"
        Me.txtStarted.Top = 0.0!
        Me.txtStarted.Width = 0.8125!
        '
        'txtJob1
        '
        Me.txtJob1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJob1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJob1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJob1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJob1.Border.RightColor = System.Drawing.Color.Black
        Me.txtJob1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJob1.Border.TopColor = System.Drawing.Color.Black
        Me.txtJob1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJob1.DataField = "JOB_DESC"
        Me.txtJob1.Height = 0.1875!
        Me.txtJob1.Left = 0.563!
        Me.txtJob1.Name = "txtJob1"
        Me.txtJob1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtJob1.Text = "txtJob1"
        Me.txtJob1.Top = 0.0!
        Me.txtJob1.Width = 1.375!
        '
        'txtComponentNumber
        '
        Me.txtComponentNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.txtComponentNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComponentNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.txtComponentNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComponentNumber.Border.RightColor = System.Drawing.Color.Black
        Me.txtComponentNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComponentNumber.Border.TopColor = System.Drawing.Color.Black
        Me.txtComponentNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComponentNumber.DataField = "JOB_COMPONENT_NBR"
        Me.txtComponentNumber.Height = 0.1875!
        Me.txtComponentNumber.Left = 2.063!
        Me.txtComponentNumber.Name = "txtComponentNumber"
        Me.txtComponentNumber.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtComponentNumber.Text = "txtComponentNumber"
        Me.txtComponentNumber.Top = 0.0!
        Me.txtComponentNumber.Width = 0.25!
        '
        'txtComponent1
        '
        Me.txtComponent1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtComponent1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComponent1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtComponent1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComponent1.Border.RightColor = System.Drawing.Color.Black
        Me.txtComponent1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComponent1.Border.TopColor = System.Drawing.Color.Black
        Me.txtComponent1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComponent1.DataField = "JOB_COMP_DESC"
        Me.txtComponent1.Height = 0.1875!
        Me.txtComponent1.Left = 2.313!
        Me.txtComponent1.Name = "txtComponent1"
        Me.txtComponent1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtComponent1.Text = "txtComponent1"
        Me.txtComponent1.Top = 0.0!
        Me.txtComponent1.Width = 2.4375!
        '
        'txtAccount_Executive1
        '
        Me.txtAccount_Executive1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtAccount_Executive1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAccount_Executive1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtAccount_Executive1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAccount_Executive1.Border.RightColor = System.Drawing.Color.Black
        Me.txtAccount_Executive1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAccount_Executive1.Border.TopColor = System.Drawing.Color.Black
        Me.txtAccount_Executive1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAccount_Executive1.DataField = "Account Executive"
        Me.txtAccount_Executive1.Height = 0.1875!
        Me.txtAccount_Executive1.Left = 4.813!
        Me.txtAccount_Executive1.Name = "txtAccount_Executive1"
        Me.txtAccount_Executive1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtAccount_Executive1.Text = "txtAccount_Executive1"
        Me.txtAccount_Executive1.Top = 0.0!
        Me.txtAccount_Executive1.Width = 1.0!
        '
        'txtOpenDate
        '
        Me.txtOpenDate.Border.BottomColor = System.Drawing.Color.Black
        Me.txtOpenDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOpenDate.Border.LeftColor = System.Drawing.Color.Black
        Me.txtOpenDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOpenDate.Border.RightColor = System.Drawing.Color.Black
        Me.txtOpenDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOpenDate.Border.TopColor = System.Drawing.Color.Black
        Me.txtOpenDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOpenDate.DataField = "JOB_COMP_DATE"
        Me.txtOpenDate.Height = 0.1875!
        Me.txtOpenDate.Left = 5.875!
        Me.txtOpenDate.Name = "txtOpenDate"
        Me.txtOpenDate.OutputFormat = resources.GetString("txtOpenDate.OutputFormat")
        Me.txtOpenDate.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtOpenDate.Text = "txtOpenDate"
        Me.txtOpenDate.Top = 0.0!
        Me.txtOpenDate.Width = 0.75!
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobNumber.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobNumber.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobNumber.DataField = "JOB_NUMBER"
        Me.txtJobNumber.Height = 0.1875!
        Me.txtJobNumber.Left = 0.063!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtJobNumber.Text = "txtJobNumber"
        Me.txtJobNumber.Top = 0.0!
        Me.txtJobNumber.Width = 0.5!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo2, Me.lbluser, Me.ReportInfo1})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo2
        '
        Me.ReportInfo2.Border.BottomColor = System.Drawing.Color.Black
        Me.ReportInfo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo2.Border.LeftColor = System.Drawing.Color.Black
        Me.ReportInfo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo2.Border.RightColor = System.Drawing.Color.Black
        Me.ReportInfo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo2.Border.TopColor = System.Drawing.Color.Black
        Me.ReportInfo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo2.FormatString = "{RunDateTime:}"
        Me.ReportInfo2.Height = 0.1875!
        Me.ReportInfo2.Left = 0.063!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 8pt; "
        Me.ReportInfo2.Top = 0.0!
        Me.ReportInfo2.Width = 1.6875!
        '
        'lbluser
        '
        Me.lbluser.Border.BottomColor = System.Drawing.Color.Black
        Me.lbluser.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lbluser.Border.LeftColor = System.Drawing.Color.Black
        Me.lbluser.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lbluser.Border.RightColor = System.Drawing.Color.Black
        Me.lbluser.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lbluser.Border.TopColor = System.Drawing.Color.Black
        Me.lbluser.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lbluser.Height = 0.1875!
        Me.lbluser.HyperLink = Nothing
        Me.lbluser.Left = 1.75!
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Style = "font-size: 8pt; "
        Me.lbluser.Tag = " "
        Me.lbluser.Text = " "
        Me.lbluser.Top = 0.0!
        Me.lbluser.Width = 1.0625!
        '
        'ReportInfo1
        '
        Me.ReportInfo1.Border.BottomColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.LeftColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.RightColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.TopColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1875!
        Me.ReportInfo1.Left = 2.813!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "text-align: right; font-size: 8pt; "
        Me.ReportInfo1.Top = 0.063!
        Me.ReportInfo1.Width = 4.6875!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.Label1, Me.txtOpenDates})
        Me.ReportHeader1.Height = 0.5416667!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.25!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 14.25pt; "
        Me.Label2.Text = "Schedules Needed"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 3.9375!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.Black
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.LeftColor = System.Drawing.Color.Black
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.RightColor = System.Drawing.Color.Black
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.TopColor = System.Drawing.Color.Black
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label1.Text = "Job Opened Date Range:"
        Me.Label1.Top = 0.3125!
        Me.Label1.Width = 1.5!
        '
        'txtOpenDates
        '
        Me.txtOpenDates.Border.BottomColor = System.Drawing.Color.Black
        Me.txtOpenDates.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOpenDates.Border.LeftColor = System.Drawing.Color.Black
        Me.txtOpenDates.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOpenDates.Border.RightColor = System.Drawing.Color.Black
        Me.txtOpenDates.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOpenDates.Border.TopColor = System.Drawing.Color.Black
        Me.txtOpenDates.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOpenDates.DataField = " "
        Me.txtOpenDates.Height = 0.1875!
        Me.txtOpenDates.Left = 1.5!
        Me.txtOpenDates.Name = "txtOpenDates"
        Me.txtOpenDates.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtOpenDates.Text = "txtOpenDates"
        Me.txtOpenDates.Top = 0.3125!
        Me.txtOpenDates.Width = 3.5625!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.25!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label8, Me.txtClientCode, Me.txtClient1, Me.txtDivision1, Me.Label10, Me.txtProductCode, Me.txtProduct1, Me.Label9, Me.txtDivisionCode, Me.Line1})
        Me.GroupHeader1.DataField = "CDP"
        Me.GroupHeader1.Height = 0.5625!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.063!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label8.Text = "Client:"
        Me.Label8.Top = 0.063!
        Me.Label8.Width = 0.5!
        '
        'txtClientCode
        '
        Me.txtClientCode.Border.BottomColor = System.Drawing.Color.Black
        Me.txtClientCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClientCode.Border.LeftColor = System.Drawing.Color.Black
        Me.txtClientCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClientCode.Border.RightColor = System.Drawing.Color.Black
        Me.txtClientCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClientCode.Border.TopColor = System.Drawing.Color.Black
        Me.txtClientCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClientCode.DataField = "CL_CODE"
        Me.txtClientCode.Height = 0.1875!
        Me.txtClientCode.Left = 0.625!
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtClientCode.Text = "txtClientCode"
        Me.txtClientCode.Top = 0.0625!
        Me.txtClientCode.Width = 0.625!
        '
        'txtClient1
        '
        Me.txtClient1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtClient1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClient1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtClient1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClient1.Border.RightColor = System.Drawing.Color.Black
        Me.txtClient1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClient1.Border.TopColor = System.Drawing.Color.Black
        Me.txtClient1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClient1.DataField = "Client"
        Me.txtClient1.Height = 0.1875!
        Me.txtClient1.Left = 1.25!
        Me.txtClient1.Name = "txtClient1"
        Me.txtClient1.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtClient1.Text = "txtClient1"
        Me.txtClient1.Top = 0.0625!
        Me.txtClient1.Width = 2.1875!
        '
        'txtDivision1
        '
        Me.txtDivision1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDivision1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivision1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDivision1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivision1.Border.RightColor = System.Drawing.Color.Black
        Me.txtDivision1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivision1.Border.TopColor = System.Drawing.Color.Black
        Me.txtDivision1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivision1.DataField = "Division"
        Me.txtDivision1.Height = 0.1875!
        Me.txtDivision1.Left = 1.25!
        Me.txtDivision1.Name = "txtDivision1"
        Me.txtDivision1.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDivision1.Text = "txtDivision1"
        Me.txtDivision1.Top = 0.25!
        Me.txtDivision1.Width = 6.25!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 3.5!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label10.Text = "Product:"
        Me.Label10.Top = 0.063!
        Me.Label10.Width = 0.5!
        '
        'txtProductCode
        '
        Me.txtProductCode.Border.BottomColor = System.Drawing.Color.Black
        Me.txtProductCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProductCode.Border.LeftColor = System.Drawing.Color.Black
        Me.txtProductCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProductCode.Border.RightColor = System.Drawing.Color.Black
        Me.txtProductCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProductCode.Border.TopColor = System.Drawing.Color.Black
        Me.txtProductCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProductCode.DataField = "PRD_CODE"
        Me.txtProductCode.Height = 0.1875!
        Me.txtProductCode.Left = 4.0625!
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtProductCode.Text = "txtProductCode"
        Me.txtProductCode.Top = 0.0625!
        Me.txtProductCode.Width = 0.625!
        '
        'txtProduct1
        '
        Me.txtProduct1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtProduct1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProduct1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtProduct1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProduct1.Border.RightColor = System.Drawing.Color.Black
        Me.txtProduct1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProduct1.Border.TopColor = System.Drawing.Color.Black
        Me.txtProduct1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProduct1.DataField = "Product"
        Me.txtProduct1.Height = 0.1875!
        Me.txtProduct1.Left = 4.6875!
        Me.txtProduct1.Name = "txtProduct1"
        Me.txtProduct1.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtProduct1.Text = "txtProduct1"
        Me.txtProduct1.Top = 0.0625!
        Me.txtProduct1.Width = 2.8125!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.063!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label9.Text = "Division:"
        Me.Label9.Top = 0.25!
        Me.Label9.Width = 0.5625!
        '
        'txtDivisionCode
        '
        Me.txtDivisionCode.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDivisionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivisionCode.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDivisionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivisionCode.Border.RightColor = System.Drawing.Color.Black
        Me.txtDivisionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivisionCode.Border.TopColor = System.Drawing.Color.Black
        Me.txtDivisionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivisionCode.DataField = "DIV_CODE"
        Me.txtDivisionCode.Height = 0.1875!
        Me.txtDivisionCode.Left = 0.625!
        Me.txtDivisionCode.Name = "txtDivisionCode"
        Me.txtDivisionCode.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDivisionCode.Text = "txtDivisionCode"
        Me.txtDivisionCode.Top = 0.25!
        Me.txtDivisionCode.Width = 0.625!
        '
        'Line1
        '
        Me.Line1.Border.BottomColor = System.Drawing.Color.Black
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.LeftColor = System.Drawing.Color.Black
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.RightColor = System.Drawing.Color.Black
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.TopColor = System.Drawing.Color.Black
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.5!
        Me.Line1.Width = 7.4375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.5!
        Me.Line1.Y1 = 0.5!
        Me.Line1.Y2 = 0.5!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
        Me.GroupFooter1.Height = 0.125!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Line2
        '
        Me.Line2.Border.BottomColor = System.Drawing.Color.Black
        Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.LeftColor = System.Drawing.Color.Black
        Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.RightColor = System.Drawing.Color.Black
        Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.TopColor = System.Drawing.Color.Black
        Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0625!
        Me.Line2.Width = 7.4375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.5!
        Me.Line2.Y1 = 0.0625!
        Me.Line2.Y2 = 0.0625!
        '
        'ArptOpenJobsDS1
        '
        Me.ArptOpenJobsDS1.DataSetName = "arptOpenJobsDS"
        Me.ArptOpenJobsDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'arptOpenJobsSch
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.521!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStarted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJob1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponentNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponent1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccount_Executive1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOpenDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOpenDates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClient1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivision1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivisionCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArptOpenJobsDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtClientCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClient1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivision1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtProductCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDivisionCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ArptOpenJobsDS1 As ActiveReportsAssembly.arptOpenJobsDS
    Friend WithEvents txtStarted As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJob1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComponentNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComponent1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAccount_Executive1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOpenDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lbluser As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents txtOpenDates As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
End Class 
