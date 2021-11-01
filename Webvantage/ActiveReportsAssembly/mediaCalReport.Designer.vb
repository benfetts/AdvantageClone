<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class mediaCalReport 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(mediaCalReport))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ClientCode = New DataDynamics.ActiveReports.TextBox
        Me.DivisionCode = New DataDynamics.ActiveReports.TextBox
        Me.ProductCode = New DataDynamics.ActiveReports.TextBox
        Me.MonthYear = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Saturday = New DataDynamics.ActiveReports.TextBox
        Me.Wednesday = New DataDynamics.ActiveReports.TextBox
        Me.Tuesday = New DataDynamics.ActiveReports.TextBox
        Me.Thursday = New DataDynamics.ActiveReports.TextBox
        Me.Friday = New DataDynamics.ActiveReports.TextBox
        Me.Monday = New DataDynamics.ActiveReports.TextBox
        Me.Sunday = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.SaturdayTxt = New DataDynamics.ActiveReports.Label
        Me.FridayTxt = New DataDynamics.ActiveReports.Label
        Me.ThursdayTxt = New DataDynamics.ActiveReports.Label
        Me.WednesdayTxt = New DataDynamics.ActiveReports.Label
        Me.TuesdayTxt = New DataDynamics.ActiveReports.Label
        Me.MondayTxt = New DataDynamics.ActiveReports.Label
        Me.SundayTxt = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.Picture1 = New DataDynamics.ActiveReports.Picture
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        CType(Me.ClientCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Saturday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Wednesday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tuesday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Thursday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Friday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Monday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sunday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaturdayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FridayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThursdayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WednesdayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TuesdayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MondayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SundayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ClientCode, Me.DivisionCode, Me.ProductCode, Me.MonthYear, Me.TextBox1, Me.TextBox2, Me.Label1, Me.Label2, Me.Label3})
        Me.PageHeader1.Height = 1.072917!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'ClientCode
        '
        Me.ClientCode.Border.BottomColor = System.Drawing.Color.Black
        Me.ClientCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientCode.Border.LeftColor = System.Drawing.Color.Black
        Me.ClientCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientCode.Border.RightColor = System.Drawing.Color.Black
        Me.ClientCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientCode.Border.TopColor = System.Drawing.Color.Black
        Me.ClientCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ClientCode.Height = 0.1875!
        Me.ClientCode.Left = 0.5625!
        Me.ClientCode.Name = "ClientCode"
        Me.ClientCode.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.ClientCode.Text = Nothing
        Me.ClientCode.Top = 0.5!
        Me.ClientCode.Width = 3.5!
        '
        'DivisionCode
        '
        Me.DivisionCode.Border.BottomColor = System.Drawing.Color.Black
        Me.DivisionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DivisionCode.Border.LeftColor = System.Drawing.Color.Black
        Me.DivisionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DivisionCode.Border.RightColor = System.Drawing.Color.Black
        Me.DivisionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DivisionCode.Border.TopColor = System.Drawing.Color.Black
        Me.DivisionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DivisionCode.Height = 0.1875!
        Me.DivisionCode.Left = 0.5625!
        Me.DivisionCode.Name = "DivisionCode"
        Me.DivisionCode.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.DivisionCode.Text = Nothing
        Me.DivisionCode.Top = 0.6875!
        Me.DivisionCode.Width = 3.5!
        '
        'ProductCode
        '
        Me.ProductCode.Border.BottomColor = System.Drawing.Color.Black
        Me.ProductCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProductCode.Border.LeftColor = System.Drawing.Color.Black
        Me.ProductCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProductCode.Border.RightColor = System.Drawing.Color.Black
        Me.ProductCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProductCode.Border.TopColor = System.Drawing.Color.Black
        Me.ProductCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ProductCode.Height = 0.1875!
        Me.ProductCode.Left = 0.5625!
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.ProductCode.Text = Nothing
        Me.ProductCode.Top = 0.875!
        Me.ProductCode.Width = 3.5!
        '
        'MonthYear
        '
        Me.MonthYear.Border.BottomColor = System.Drawing.Color.Black
        Me.MonthYear.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MonthYear.Border.LeftColor = System.Drawing.Color.Black
        Me.MonthYear.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MonthYear.Border.RightColor = System.Drawing.Color.Black
        Me.MonthYear.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MonthYear.Border.TopColor = System.Drawing.Color.Black
        Me.MonthYear.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MonthYear.Height = 0.1875!
        Me.MonthYear.Left = 0.0!
        Me.MonthYear.Name = "MonthYear"
        Me.MonthYear.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 12pt; "
        Me.MonthYear.Text = "Month Year"
        Me.MonthYear.Top = 0.25!
        Me.MonthYear.Width = 7.5!
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Height = 0.25!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.TextBox1.Text = "Media Schedule"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 7.5!
        '
        'TextBox2
        '
        Me.TextBox2.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Height = 0.5625!
        Me.TextBox2.Left = 5.375!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.5!
        Me.TextBox2.Width = 2.0625!
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
        Me.Label1.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label1.Text = "Client "
        Me.Label1.Top = 0.5!
        Me.Label1.Width = 0.5625!
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
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label2.Text = "Division"
        Me.Label2.Top = 0.6875!
        Me.Label2.Width = 0.5625!
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
        Me.Label3.Left = 0.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label3.Text = "Product"
        Me.Label3.Top = 0.875!
        Me.Label3.Width = 0.5625!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Saturday, Me.Wednesday, Me.Tuesday, Me.Thursday, Me.Friday, Me.Monday, Me.Sunday})
        Me.Detail1.Height = 1.1875!
        Me.Detail1.Name = "Detail1"
        '
        'Saturday
        '
        Me.Saturday.Border.BottomColor = System.Drawing.Color.Black
        Me.Saturday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Saturday.Border.LeftColor = System.Drawing.Color.Black
        Me.Saturday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Saturday.Border.RightColor = System.Drawing.Color.Black
        Me.Saturday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Saturday.Border.TopColor = System.Drawing.Color.Black
        Me.Saturday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Saturday.DataField = "Saturday"
        Me.Saturday.Height = 1.1875!
        Me.Saturday.Left = 6.375!
        Me.Saturday.Name = "Saturday"
        Me.Saturday.Style = "ddo-char-set: 0; font-size: 6pt; "
        Me.Saturday.Text = "Saturday"
        Me.Saturday.Top = 0.0!
        Me.Saturday.Width = 1.0625!
        '
        'Wednesday
        '
        Me.Wednesday.Border.BottomColor = System.Drawing.Color.Black
        Me.Wednesday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Wednesday.Border.LeftColor = System.Drawing.Color.Black
        Me.Wednesday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Wednesday.Border.RightColor = System.Drawing.Color.Black
        Me.Wednesday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Wednesday.Border.TopColor = System.Drawing.Color.Black
        Me.Wednesday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Wednesday.DataField = "Wednesday"
        Me.Wednesday.Height = 1.1875!
        Me.Wednesday.Left = 3.1875!
        Me.Wednesday.Name = "Wednesday"
        Me.Wednesday.Style = "ddo-char-set: 0; font-size: 6pt; "
        Me.Wednesday.Text = "Wednesday"
        Me.Wednesday.Top = 0.0!
        Me.Wednesday.Width = 1.0625!
        '
        'Tuesday
        '
        Me.Tuesday.Border.BottomColor = System.Drawing.Color.Black
        Me.Tuesday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Tuesday.Border.LeftColor = System.Drawing.Color.Black
        Me.Tuesday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Tuesday.Border.RightColor = System.Drawing.Color.Black
        Me.Tuesday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Tuesday.Border.TopColor = System.Drawing.Color.Black
        Me.Tuesday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Tuesday.DataField = "Tuesday"
        Me.Tuesday.Height = 1.1875!
        Me.Tuesday.Left = 2.125!
        Me.Tuesday.Name = "Tuesday"
        Me.Tuesday.Style = "ddo-char-set: 0; font-size: 6pt; "
        Me.Tuesday.Text = "Tuesday"
        Me.Tuesday.Top = 0.0!
        Me.Tuesday.Width = 1.0625!
        '
        'Thursday
        '
        Me.Thursday.Border.BottomColor = System.Drawing.Color.Black
        Me.Thursday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Thursday.Border.LeftColor = System.Drawing.Color.Black
        Me.Thursday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Thursday.Border.RightColor = System.Drawing.Color.Black
        Me.Thursday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Thursday.Border.TopColor = System.Drawing.Color.Black
        Me.Thursday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Thursday.DataField = "Thursday"
        Me.Thursday.Height = 1.1875!
        Me.Thursday.Left = 4.25!
        Me.Thursday.Name = "Thursday"
        Me.Thursday.Style = "ddo-char-set: 0; font-size: 6pt; "
        Me.Thursday.Text = "Thursday"
        Me.Thursday.Top = 0.0!
        Me.Thursday.Width = 1.0625!
        '
        'Friday
        '
        Me.Friday.Border.BottomColor = System.Drawing.Color.Black
        Me.Friday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Friday.Border.LeftColor = System.Drawing.Color.Black
        Me.Friday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Friday.Border.RightColor = System.Drawing.Color.Black
        Me.Friday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Friday.Border.TopColor = System.Drawing.Color.Black
        Me.Friday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Friday.DataField = "Friday"
        Me.Friday.Height = 1.1875!
        Me.Friday.Left = 5.3125!
        Me.Friday.Name = "Friday"
        Me.Friday.Style = "ddo-char-set: 0; font-size: 6pt; "
        Me.Friday.Text = "Friday"
        Me.Friday.Top = 0.0!
        Me.Friday.Width = 1.0625!
        '
        'Monday
        '
        Me.Monday.Border.BottomColor = System.Drawing.Color.Black
        Me.Monday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Monday.Border.LeftColor = System.Drawing.Color.Black
        Me.Monday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Monday.Border.RightColor = System.Drawing.Color.Black
        Me.Monday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Monday.Border.TopColor = System.Drawing.Color.Black
        Me.Monday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Monday.DataField = "Monday"
        Me.Monday.Height = 1.1875!
        Me.Monday.Left = 1.0625!
        Me.Monday.Name = "Monday"
        Me.Monday.Style = "ddo-char-set: 0; font-size: 6pt; "
        Me.Monday.Text = "Monday"
        Me.Monday.Top = 0.0!
        Me.Monday.Width = 1.0625!
        '
        'Sunday
        '
        Me.Sunday.Border.BottomColor = System.Drawing.Color.Black
        Me.Sunday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Sunday.Border.LeftColor = System.Drawing.Color.Black
        Me.Sunday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Sunday.Border.RightColor = System.Drawing.Color.Black
        Me.Sunday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Sunday.Border.TopColor = System.Drawing.Color.Black
        Me.Sunday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Sunday.DataField = "Sunday"
        Me.Sunday.Height = 1.1875!
        Me.Sunday.Left = 0.0!
        Me.Sunday.Name = "Sunday"
        Me.Sunday.Style = "ddo-char-set: 0; font-size: 6pt; "
        Me.Sunday.Text = "Sunday"
        Me.Sunday.Top = 0.0!
        Me.Sunday.Width = 1.0625!
        '
        'PageFooter1
        '
        Me.PageFooter1.CanGrow = False
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1})
        Me.PageFooter1.Height = 0.1041667!
        Me.PageFooter1.Name = "PageFooter1"
        Me.PageFooter1.Visible = False
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
        Me.ReportInfo1.FormatString = "{RunDateTime:M/d/yyyy h:mm tt}"
        Me.ReportInfo1.Height = 0.125!
        Me.ReportInfo1.Left = 0.0!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "ddo-char-set: 0; font-size: 5.25pt; "
        Me.ReportInfo1.SummaryGroup = "GroupHeader1"
        Me.ReportInfo1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.ReportInfo1.Top = 0.0!
        Me.ReportInfo1.Width = 2.0!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SaturdayTxt, Me.FridayTxt, Me.ThursdayTxt, Me.WednesdayTxt, Me.TuesdayTxt, Me.MondayTxt, Me.SundayTxt})
        Me.GroupHeader1.Height = 0.2604167!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'SaturdayTxt
        '
        Me.SaturdayTxt.Border.BottomColor = System.Drawing.Color.Black
        Me.SaturdayTxt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SaturdayTxt.Border.LeftColor = System.Drawing.Color.Black
        Me.SaturdayTxt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SaturdayTxt.Border.RightColor = System.Drawing.Color.Black
        Me.SaturdayTxt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SaturdayTxt.Border.TopColor = System.Drawing.Color.Black
        Me.SaturdayTxt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SaturdayTxt.Height = 0.1875!
        Me.SaturdayTxt.HyperLink = Nothing
        Me.SaturdayTxt.Left = 6.375!
        Me.SaturdayTxt.Name = "SaturdayTxt"
        Me.SaturdayTxt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.SaturdayTxt.Text = "Saturday"
        Me.SaturdayTxt.Top = 0.0625!
        Me.SaturdayTxt.Width = 1.0625!
        '
        'FridayTxt
        '
        Me.FridayTxt.Border.BottomColor = System.Drawing.Color.Black
        Me.FridayTxt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FridayTxt.Border.LeftColor = System.Drawing.Color.Black
        Me.FridayTxt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FridayTxt.Border.RightColor = System.Drawing.Color.Black
        Me.FridayTxt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FridayTxt.Border.TopColor = System.Drawing.Color.Black
        Me.FridayTxt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FridayTxt.Height = 0.1875!
        Me.FridayTxt.HyperLink = Nothing
        Me.FridayTxt.Left = 5.3125!
        Me.FridayTxt.Name = "FridayTxt"
        Me.FridayTxt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.FridayTxt.Text = "Friday"
        Me.FridayTxt.Top = 0.0625!
        Me.FridayTxt.Width = 1.0625!
        '
        'ThursdayTxt
        '
        Me.ThursdayTxt.Border.BottomColor = System.Drawing.Color.Black
        Me.ThursdayTxt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ThursdayTxt.Border.LeftColor = System.Drawing.Color.Black
        Me.ThursdayTxt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ThursdayTxt.Border.RightColor = System.Drawing.Color.Black
        Me.ThursdayTxt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ThursdayTxt.Border.TopColor = System.Drawing.Color.Black
        Me.ThursdayTxt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ThursdayTxt.Height = 0.1875!
        Me.ThursdayTxt.HyperLink = Nothing
        Me.ThursdayTxt.Left = 4.25!
        Me.ThursdayTxt.Name = "ThursdayTxt"
        Me.ThursdayTxt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.ThursdayTxt.Text = "Thursday"
        Me.ThursdayTxt.Top = 0.0625!
        Me.ThursdayTxt.Width = 1.0625!
        '
        'WednesdayTxt
        '
        Me.WednesdayTxt.Border.BottomColor = System.Drawing.Color.Black
        Me.WednesdayTxt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.WednesdayTxt.Border.LeftColor = System.Drawing.Color.Black
        Me.WednesdayTxt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.WednesdayTxt.Border.RightColor = System.Drawing.Color.Black
        Me.WednesdayTxt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.WednesdayTxt.Border.TopColor = System.Drawing.Color.Black
        Me.WednesdayTxt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.WednesdayTxt.Height = 0.1875!
        Me.WednesdayTxt.HyperLink = Nothing
        Me.WednesdayTxt.Left = 3.1875!
        Me.WednesdayTxt.Name = "WednesdayTxt"
        Me.WednesdayTxt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.WednesdayTxt.Text = "Wednesday"
        Me.WednesdayTxt.Top = 0.0625!
        Me.WednesdayTxt.Width = 1.0625!
        '
        'TuesdayTxt
        '
        Me.TuesdayTxt.Border.BottomColor = System.Drawing.Color.Black
        Me.TuesdayTxt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TuesdayTxt.Border.LeftColor = System.Drawing.Color.Black
        Me.TuesdayTxt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TuesdayTxt.Border.RightColor = System.Drawing.Color.Black
        Me.TuesdayTxt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TuesdayTxt.Border.TopColor = System.Drawing.Color.Black
        Me.TuesdayTxt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TuesdayTxt.Height = 0.1875!
        Me.TuesdayTxt.HyperLink = Nothing
        Me.TuesdayTxt.Left = 2.125!
        Me.TuesdayTxt.Name = "TuesdayTxt"
        Me.TuesdayTxt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.TuesdayTxt.Text = "Tuesday"
        Me.TuesdayTxt.Top = 0.0625!
        Me.TuesdayTxt.Width = 1.0625!
        '
        'MondayTxt
        '
        Me.MondayTxt.Border.BottomColor = System.Drawing.Color.Black
        Me.MondayTxt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MondayTxt.Border.LeftColor = System.Drawing.Color.Black
        Me.MondayTxt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MondayTxt.Border.RightColor = System.Drawing.Color.Black
        Me.MondayTxt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MondayTxt.Border.TopColor = System.Drawing.Color.Black
        Me.MondayTxt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MondayTxt.Height = 0.1875!
        Me.MondayTxt.HyperLink = Nothing
        Me.MondayTxt.Left = 1.0625!
        Me.MondayTxt.Name = "MondayTxt"
        Me.MondayTxt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.MondayTxt.Text = "Monday"
        Me.MondayTxt.Top = 0.0625!
        Me.MondayTxt.Width = 1.0625!
        '
        'SundayTxt
        '
        Me.SundayTxt.Border.BottomColor = System.Drawing.Color.Black
        Me.SundayTxt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SundayTxt.Border.LeftColor = System.Drawing.Color.Black
        Me.SundayTxt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SundayTxt.Border.RightColor = System.Drawing.Color.Black
        Me.SundayTxt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SundayTxt.Border.TopColor = System.Drawing.Color.Black
        Me.SundayTxt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SundayTxt.Height = 0.1875!
        Me.SundayTxt.HyperLink = Nothing
        Me.SundayTxt.Left = 0.0!
        Me.SundayTxt.Name = "SundayTxt"
        Me.SundayTxt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.SundayTxt.Text = "Sunday"
        Me.SundayTxt.Top = 0.0625!
        Me.SundayTxt.Width = 1.0625!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanGrow = False
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.Visible = False
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1})
        Me.ReportHeader1.Height = 1.5!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Picture1
        '
        Me.Picture1.Border.BottomColor = System.Drawing.Color.Black
        Me.Picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.LeftColor = System.Drawing.Color.Black
        Me.Picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.RightColor = System.Drawing.Color.Black
        Me.Picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.TopColor = System.Drawing.Color.Black
        Me.Picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Height = 1.5!
        Me.Picture1.Image = Nothing
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.0!
        Me.Picture1.LineWeight = 0.0!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft
        Me.Picture1.Top = 0.0!
        Me.Picture1.Width = 7.45!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.01041667!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'mediaCalReport
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.25!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.25!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
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
        CType(Me.ClientCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Saturday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Wednesday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tuesday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Thursday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Friday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Monday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sunday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaturdayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FridayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThursdayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WednesdayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TuesdayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MondayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SundayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents SaturdayTxt As DataDynamics.ActiveReports.Label
    Friend WithEvents FridayTxt As DataDynamics.ActiveReports.Label
    Friend WithEvents ThursdayTxt As DataDynamics.ActiveReports.Label
    Friend WithEvents WednesdayTxt As DataDynamics.ActiveReports.Label
    Friend WithEvents TuesdayTxt As DataDynamics.ActiveReports.Label
    Friend WithEvents SundayTxt As DataDynamics.ActiveReports.Label
    Friend WithEvents MondayTxt As DataDynamics.ActiveReports.Label
    Friend WithEvents Sunday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Saturday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Tuesday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Thursday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Monday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Wednesday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Friday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ClientCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents DivisionCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ProductCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents MonthYear As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
End Class
