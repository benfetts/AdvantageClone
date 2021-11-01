<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptTaskCalendar 
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
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptTaskCalendar))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.TBTitle = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.Sunday = New DataDynamics.ActiveReports.TextBox()
        Me.Monday = New DataDynamics.ActiveReports.TextBox()
        Me.Tuesday = New DataDynamics.ActiveReports.TextBox()
        Me.Wednesday = New DataDynamics.ActiveReports.TextBox()
        Me.Thursday = New DataDynamics.ActiveReports.TextBox()
        Me.Friday = New DataDynamics.ActiveReports.TextBox()
        Me.Saturday = New DataDynamics.ActiveReports.TextBox()
        Me.dtlmonth = New DataDynamics.ActiveReports.Label()
        Me.dtlyear = New DataDynamics.ActiveReports.Label()
        Me.dtlclient = New DataDynamics.ActiveReports.Label()
        Me.dtlclientdesc = New DataDynamics.ActiveReports.Label()
        Me.dtldiv = New DataDynamics.ActiveReports.Label()
        Me.dtldivdesc = New DataDynamics.ActiveReports.Label()
        Me.dtlprd = New DataDynamics.ActiveReports.Label()
        Me.dtlprddesc = New DataDynamics.ActiveReports.Label()
        Me.dtljob = New DataDynamics.ActiveReports.Label()
        Me.dtljobdesc = New DataDynamics.ActiveReports.Label()
        Me.dtlcomp = New DataDynamics.ActiveReports.Label()
        Me.dtlcompdesc = New DataDynamics.ActiveReports.Label()
        Me.dtltrfdesc = New DataDynamics.ActiveReports.Label()
        Me.grouping = New DataDynamics.ActiveReports.Label()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.MonthYear = New DataDynamics.ActiveReports.TextBox()
        Me.ClientCode = New DataDynamics.ActiveReports.TextBox()
        Me.DivisionCode = New DataDynamics.ActiveReports.TextBox()
        Me.ProductCode = New DataDynamics.ActiveReports.TextBox()
        Me.tbComponent = New DataDynamics.ActiveReports.TextBox()
        Me.tbJob = New DataDynamics.ActiveReports.TextBox()
        Me.status = New DataDynamics.ActiveReports.TextBox()
        Me.schComment = New DataDynamics.ActiveReports.TextBox()
        Me.SundayTxt = New DataDynamics.ActiveReports.TextBox()
        Me.MondayTxt = New DataDynamics.ActiveReports.TextBox()
        Me.TuesdayTxt = New DataDynamics.ActiveReports.TextBox()
        Me.WednesdayTxt = New DataDynamics.ActiveReports.TextBox()
        Me.ThursdayTxt = New DataDynamics.ActiveReports.TextBox()
        Me.FridayTxt = New DataDynamics.ActiveReports.TextBox()
        Me.SaturdayTxt = New DataDynamics.ActiveReports.TextBox()
        Me.lblClient = New DataDynamics.ActiveReports.TextBox()
        Me.lblProduct = New DataDynamics.ActiveReports.TextBox()
        Me.lblDivision = New DataDynamics.ActiveReports.TextBox()
        Me.lblSchComment = New DataDynamics.ActiveReports.TextBox()
        Me.lblJob = New DataDynamics.ActiveReports.TextBox()
        Me.lblComponent = New DataDynamics.ActiveReports.TextBox()
        Me.lblStatus = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter()
        CType(Me.TBTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sunday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Monday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tuesday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Wednesday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Thursday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Friday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Saturday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlmonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlyear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlclient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlclientdesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtldiv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtldivdesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlprd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlprddesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtljob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtljobdesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlcomp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtlcompdesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtltrfdesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.schComment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SundayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MondayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TuesdayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WednesdayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThursdayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FridayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaturdayTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSchComment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TBTitle, Me.TextBox2, Me.Picture1})
        Me.PageHeader1.Height = 1.489583!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'TBTitle
        '
        Me.TBTitle.Height = 0.25!
        Me.TBTitle.Left = 0.0!
        Me.TBTitle.Name = "TBTitle"
        Me.TBTitle.Style = "font-size: 14.25pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.TBTitle.Text = "Title"
        Me.TBTitle.Top = 1.1875!
        Me.TBTitle.Width = 7.4375!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.25!
        Me.TextBox2.Left = 5.5625!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 1.625!
        Me.TextBox2.Width = 2.0625!
        '
        'Picture1
        '
        Me.Picture1.Height = 1.1875!
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.0!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft
        Me.Picture1.Top = 0.0!
        Me.Picture1.Width = 7.4375!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Sunday, Me.Monday, Me.Tuesday, Me.Wednesday, Me.Thursday, Me.Friday, Me.Saturday, Me.dtlmonth, Me.dtlyear, Me.dtlclient, Me.dtlclientdesc, Me.dtldiv, Me.dtldivdesc, Me.dtlprd, Me.dtlprddesc, Me.dtljob, Me.dtljobdesc, Me.dtlcomp, Me.dtlcompdesc, Me.dtltrfdesc, Me.grouping})
        Me.Detail1.Height = 1.09!
        Me.Detail1.Name = "Detail1"
        '
        'Sunday
        '
        Me.Sunday.DataField = "Sunday"
        Me.Sunday.Height = 1.0625!
        Me.Sunday.Left = 0.0!
        Me.Sunday.Name = "Sunday"
        Me.Sunday.Style = "font-size: 7pt; ddo-char-set: 0"
        Me.Sunday.Text = "Sunday"
        Me.Sunday.Top = 0.0!
        Me.Sunday.Width = 1.1!
        '
        'Monday
        '
        Me.Monday.DataField = "Monday"
        Me.Monday.Height = 1.0625!
        Me.Monday.Left = 1.1!
        Me.Monday.Name = "Monday"
        Me.Monday.Style = "font-size: 7pt; ddo-char-set: 0"
        Me.Monday.Text = "Monday"
        Me.Monday.Top = 0.0!
        Me.Monday.Width = 1.1!
        '
        'Tuesday
        '
        Me.Tuesday.DataField = "Tuesday"
        Me.Tuesday.Height = 1.0625!
        Me.Tuesday.Left = 2.2!
        Me.Tuesday.Name = "Tuesday"
        Me.Tuesday.Style = "font-size: 7pt; ddo-char-set: 0"
        Me.Tuesday.Text = "Tuesday"
        Me.Tuesday.Top = 0.0!
        Me.Tuesday.Width = 1.1!
        '
        'Wednesday
        '
        Me.Wednesday.DataField = "Wednesday"
        Me.Wednesday.Height = 1.0625!
        Me.Wednesday.Left = 3.3!
        Me.Wednesday.Name = "Wednesday"
        Me.Wednesday.Style = "font-size: 7pt; ddo-char-set: 0"
        Me.Wednesday.Text = "Wednesday"
        Me.Wednesday.Top = 0.0!
        Me.Wednesday.Width = 1.1!
        '
        'Thursday
        '
        Me.Thursday.DataField = "Thursday"
        Me.Thursday.Height = 1.0625!
        Me.Thursday.Left = 4.4!
        Me.Thursday.Name = "Thursday"
        Me.Thursday.Style = "font-size: 7pt; ddo-char-set: 0"
        Me.Thursday.Text = "Thursday"
        Me.Thursday.Top = 0.0!
        Me.Thursday.Width = 1.1!
        '
        'Friday
        '
        Me.Friday.DataField = "Friday"
        Me.Friday.Height = 1.0625!
        Me.Friday.Left = 5.5!
        Me.Friday.Name = "Friday"
        Me.Friday.Style = "font-size: 7pt; ddo-char-set: 0"
        Me.Friday.Text = "Friday"
        Me.Friday.Top = 0.0!
        Me.Friday.Width = 1.1!
        '
        'Saturday
        '
        Me.Saturday.DataField = "Saturday"
        Me.Saturday.Height = 1.0625!
        Me.Saturday.Left = 6.6!
        Me.Saturday.Name = "Saturday"
        Me.Saturday.Style = "font-size: 7pt; ddo-char-set: 0"
        Me.Saturday.Text = "Saturday"
        Me.Saturday.Top = 0.0!
        Me.Saturday.Width = 1.1!
        '
        'dtlmonth
        '
        Me.dtlmonth.DataField = "dtlmonth"
        Me.dtlmonth.Height = 0.1875!
        Me.dtlmonth.HyperLink = Nothing
        Me.dtlmonth.Left = 0.125!
        Me.dtlmonth.Name = "dtlmonth"
        Me.dtlmonth.Style = ""
        Me.dtlmonth.Text = "dtlmonth"
        Me.dtlmonth.Top = 1.375!
        Me.dtlmonth.Visible = False
        Me.dtlmonth.Width = 0.5625!
        '
        'dtlyear
        '
        Me.dtlyear.DataField = "dtlyear"
        Me.dtlyear.Height = 0.1875!
        Me.dtlyear.HyperLink = Nothing
        Me.dtlyear.Left = 0.75!
        Me.dtlyear.Name = "dtlyear"
        Me.dtlyear.Style = ""
        Me.dtlyear.Text = "dtlyear"
        Me.dtlyear.Top = 1.375!
        Me.dtlyear.Visible = False
        Me.dtlyear.Width = 0.5625!
        '
        'dtlclient
        '
        Me.dtlclient.DataField = "dtlclient"
        Me.dtlclient.Height = 0.1875!
        Me.dtlclient.HyperLink = Nothing
        Me.dtlclient.Left = 1.375!
        Me.dtlclient.Name = "dtlclient"
        Me.dtlclient.Style = ""
        Me.dtlclient.Text = "dtlclient"
        Me.dtlclient.Top = 1.375!
        Me.dtlclient.Visible = False
        Me.dtlclient.Width = 0.625!
        '
        'dtlclientdesc
        '
        Me.dtlclientdesc.DataField = "dtlclientdesc"
        Me.dtlclientdesc.Height = 0.1875!
        Me.dtlclientdesc.HyperLink = Nothing
        Me.dtlclientdesc.Left = 2.1875!
        Me.dtlclientdesc.Name = "dtlclientdesc"
        Me.dtlclientdesc.Style = ""
        Me.dtlclientdesc.Text = "dtlclientdesc"
        Me.dtlclientdesc.Top = 1.375!
        Me.dtlclientdesc.Visible = False
        Me.dtlclientdesc.Width = 0.8125!
        '
        'dtldiv
        '
        Me.dtldiv.DataField = "dtldiv"
        Me.dtldiv.Height = 0.1875!
        Me.dtldiv.HyperLink = Nothing
        Me.dtldiv.Left = 3.125!
        Me.dtldiv.Name = "dtldiv"
        Me.dtldiv.Style = ""
        Me.dtldiv.Text = "dtldiv"
        Me.dtldiv.Top = 1.375!
        Me.dtldiv.Visible = False
        Me.dtldiv.Width = 0.5!
        '
        'dtldivdesc
        '
        Me.dtldivdesc.DataField = "dtldivdesc"
        Me.dtldivdesc.Height = 0.1875!
        Me.dtldivdesc.HyperLink = Nothing
        Me.dtldivdesc.Left = 3.75!
        Me.dtldivdesc.Name = "dtldivdesc"
        Me.dtldivdesc.Style = ""
        Me.dtldivdesc.Text = "dtldivdesc"
        Me.dtldivdesc.Top = 1.375!
        Me.dtldivdesc.Visible = False
        Me.dtldivdesc.Width = 0.75!
        '
        'dtlprd
        '
        Me.dtlprd.DataField = "dtlprd"
        Me.dtlprd.Height = 0.1875!
        Me.dtlprd.HyperLink = Nothing
        Me.dtlprd.Left = 4.625!
        Me.dtlprd.Name = "dtlprd"
        Me.dtlprd.Style = ""
        Me.dtlprd.Text = "dtlprd"
        Me.dtlprd.Top = 1.375!
        Me.dtlprd.Visible = False
        Me.dtlprd.Width = 0.5!
        '
        'dtlprddesc
        '
        Me.dtlprddesc.DataField = "dtlprddesc"
        Me.dtlprddesc.Height = 0.1875!
        Me.dtlprddesc.HyperLink = Nothing
        Me.dtlprddesc.Left = 5.4375!
        Me.dtlprddesc.Name = "dtlprddesc"
        Me.dtlprddesc.Style = ""
        Me.dtlprddesc.Text = "dtlprddesc"
        Me.dtlprddesc.Top = 1.375!
        Me.dtlprddesc.Visible = False
        Me.dtlprddesc.Width = 0.8125!
        '
        'dtljob
        '
        Me.dtljob.DataField = "dtljob"
        Me.dtljob.Height = 0.1875!
        Me.dtljob.HyperLink = Nothing
        Me.dtljob.Left = 0.125!
        Me.dtljob.Name = "dtljob"
        Me.dtljob.Style = ""
        Me.dtljob.Text = ""
        Me.dtljob.Top = 1.625!
        Me.dtljob.Visible = False
        Me.dtljob.Width = 0.5!
        '
        'dtljobdesc
        '
        Me.dtljobdesc.DataField = "dtljobdesc"
        Me.dtljobdesc.Height = 0.1875!
        Me.dtljobdesc.HyperLink = Nothing
        Me.dtljobdesc.Left = 0.8125!
        Me.dtljobdesc.Name = "dtljobdesc"
        Me.dtljobdesc.Style = ""
        Me.dtljobdesc.Text = "dtljobdesc"
        Me.dtljobdesc.Top = 1.625!
        Me.dtljobdesc.Visible = False
        Me.dtljobdesc.Width = 0.8125!
        '
        'dtlcomp
        '
        Me.dtlcomp.DataField = "dtlcomp"
        Me.dtlcomp.Height = 0.1875!
        Me.dtlcomp.HyperLink = Nothing
        Me.dtlcomp.Left = 1.875!
        Me.dtlcomp.Name = "dtlcomp"
        Me.dtlcomp.Style = ""
        Me.dtlcomp.Text = ""
        Me.dtlcomp.Top = 1.625!
        Me.dtlcomp.Visible = False
        Me.dtlcomp.Width = 0.6875!
        '
        'dtlcompdesc
        '
        Me.dtlcompdesc.DataField = "dtlcompdesc"
        Me.dtlcompdesc.Height = 0.1875!
        Me.dtlcompdesc.HyperLink = Nothing
        Me.dtlcompdesc.Left = 2.75!
        Me.dtlcompdesc.Name = "dtlcompdesc"
        Me.dtlcompdesc.Style = ""
        Me.dtlcompdesc.Text = "dtlcompdesc"
        Me.dtlcompdesc.Top = 1.625!
        Me.dtlcompdesc.Visible = False
        Me.dtlcompdesc.Width = 1.0!
        '
        'dtltrfdesc
        '
        Me.dtltrfdesc.DataField = "dtltrfdesc"
        Me.dtltrfdesc.Height = 0.1875!
        Me.dtltrfdesc.HyperLink = Nothing
        Me.dtltrfdesc.Left = 3.875!
        Me.dtltrfdesc.Name = "dtltrfdesc"
        Me.dtltrfdesc.Style = ""
        Me.dtltrfdesc.Text = "dtltrfdesc"
        Me.dtltrfdesc.Top = 1.625!
        Me.dtltrfdesc.Visible = False
        Me.dtltrfdesc.Width = 1.0!
        '
        'grouping
        '
        Me.grouping.DataField = "grouping"
        Me.grouping.Height = 0.1979167!
        Me.grouping.HyperLink = Nothing
        Me.grouping.Left = 5.0625!
        Me.grouping.Name = "grouping"
        Me.grouping.Style = ""
        Me.grouping.Text = "grouping"
        Me.grouping.Top = 1.625!
        Me.grouping.Width = 1.0!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1})
        Me.PageFooter1.Height = 0.1041667!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.FormatString = "{RunDateTime:}"
        Me.ReportInfo1.Height = 0.125!
        Me.ReportInfo1.Left = 0.0!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-size: 6.25pt; ddo-char-set: 1"
        Me.ReportInfo1.SummaryGroup = "GroupHeader1"
        Me.ReportInfo1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.ReportInfo1.Top = 0.0!
        Me.ReportInfo1.Width = 2.0!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.ColumnGroupKeepTogether = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.MonthYear, Me.ClientCode, Me.DivisionCode, Me.ProductCode, Me.tbComponent, Me.tbJob, Me.status, Me.schComment, Me.SundayTxt, Me.MondayTxt, Me.TuesdayTxt, Me.WednesdayTxt, Me.ThursdayTxt, Me.FridayTxt, Me.SaturdayTxt, Me.lblClient, Me.lblProduct, Me.lblDivision, Me.lblSchComment, Me.lblJob, Me.lblComponent, Me.lblStatus, Me.TextBox1, Me.TextBox3, Me.TextBox4, Me.TextBox5})
        Me.GroupHeader1.Height = 1.270833!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'MonthYear
        '
        Me.MonthYear.CanShrink = True
        Me.MonthYear.Height = 0.2!
        Me.MonthYear.Left = 1.25!
        Me.MonthYear.Name = "MonthYear"
        Me.MonthYear.Style = "font-size: 12pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.MonthYear.Text = "Month Year"
        Me.MonthYear.Top = 0.75!
        Me.MonthYear.Width = 5.25!
        '
        'ClientCode
        '
        Me.ClientCode.CanShrink = True
        Me.ClientCode.Height = 0.1!
        Me.ClientCode.Left = 0.75!
        Me.ClientCode.Name = "ClientCode"
        Me.ClientCode.Style = "font-size: 9pt; white-space: inherit; ddo-char-set: 0"
        Me.ClientCode.Text = Nothing
        Me.ClientCode.Top = 0.0!
        Me.ClientCode.Width = 2.75!
        '
        'DivisionCode
        '
        Me.DivisionCode.CanShrink = True
        Me.DivisionCode.Height = 0.1!
        Me.DivisionCode.Left = 0.75!
        Me.DivisionCode.Name = "DivisionCode"
        Me.DivisionCode.Style = "font-size: 9pt; white-space: inherit; ddo-char-set: 0"
        Me.DivisionCode.Text = Nothing
        Me.DivisionCode.Top = 0.1!
        Me.DivisionCode.Width = 2.75!
        '
        'ProductCode
        '
        Me.ProductCode.CanShrink = True
        Me.ProductCode.Height = 0.1!
        Me.ProductCode.Left = 0.75!
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.Style = "font-size: 9pt; white-space: inherit; ddo-char-set: 0"
        Me.ProductCode.Text = Nothing
        Me.ProductCode.Top = 0.2!
        Me.ProductCode.Width = 2.75!
        '
        'tbComponent
        '
        Me.tbComponent.CanShrink = True
        Me.tbComponent.Height = 0.1!
        Me.tbComponent.Left = 4.3125!
        Me.tbComponent.Name = "tbComponent"
        Me.tbComponent.Style = "font-size: 9pt; white-space: inherit; ddo-char-set: 0"
        Me.tbComponent.Text = Nothing
        Me.tbComponent.Top = 0.1!
        Me.tbComponent.Width = 3.4375!
        '
        'tbJob
        '
        Me.tbJob.CanShrink = True
        Me.tbJob.Height = 0.1!
        Me.tbJob.Left = 4.3125!
        Me.tbJob.Name = "tbJob"
        Me.tbJob.Style = "font-size: 9pt; white-space: inherit; ddo-char-set: 0"
        Me.tbJob.Text = Nothing
        Me.tbJob.Top = 0.0!
        Me.tbJob.Width = 3.4375!
        '
        'status
        '
        Me.status.CanShrink = True
        Me.status.DataField = "dtltrfdesc"
        Me.status.Height = 0.1!
        Me.status.Left = 4.3125!
        Me.status.Name = "status"
        Me.status.Style = "font-size: 9pt; white-space: inherit; ddo-char-set: 0"
        Me.status.Text = Nothing
        Me.status.Top = 0.2!
        Me.status.Width = 3.4375!
        '
        'schComment
        '
        Me.schComment.CanShrink = True
        Me.schComment.Height = 0.1!
        Me.schComment.Left = 0.75!
        Me.schComment.Name = "schComment"
        Me.schComment.Style = "font-size: 9pt; white-space: inherit; ddo-char-set: 0"
        Me.schComment.Text = Nothing
        Me.schComment.Top = 0.3!
        Me.schComment.Width = 6.875!
        '
        'SundayTxt
        '
        Me.SundayTxt.CanShrink = True
        Me.SundayTxt.Height = 0.1979167!
        Me.SundayTxt.Left = 0.0!
        Me.SundayTxt.Name = "SundayTxt"
        Me.SundayTxt.Style = "background-color: LightGrey; font-size: 10pt; font-weight: bold; text-align: cent" & _
    "er"
        Me.SundayTxt.Text = "Sunday"
        Me.SundayTxt.Top = 1.0625!
        Me.SundayTxt.Width = 1.1!
        '
        'MondayTxt
        '
        Me.MondayTxt.CanShrink = True
        Me.MondayTxt.Height = 0.1979167!
        Me.MondayTxt.Left = 1.125!
        Me.MondayTxt.Name = "MondayTxt"
        Me.MondayTxt.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.MondayTxt.Text = "Monday"
        Me.MondayTxt.Top = 1.0625!
        Me.MondayTxt.Width = 1.1!
        '
        'TuesdayTxt
        '
        Me.TuesdayTxt.CanShrink = True
        Me.TuesdayTxt.Height = 0.1979167!
        Me.TuesdayTxt.Left = 2.1875!
        Me.TuesdayTxt.Name = "TuesdayTxt"
        Me.TuesdayTxt.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.TuesdayTxt.Text = "Tuesday"
        Me.TuesdayTxt.Top = 1.0625!
        Me.TuesdayTxt.Width = 1.1!
        '
        'WednesdayTxt
        '
        Me.WednesdayTxt.CanShrink = True
        Me.WednesdayTxt.Height = 0.1979167!
        Me.WednesdayTxt.Left = 3.3125!
        Me.WednesdayTxt.Name = "WednesdayTxt"
        Me.WednesdayTxt.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.WednesdayTxt.Text = "Wednesday"
        Me.WednesdayTxt.Top = 1.0625!
        Me.WednesdayTxt.Width = 1.1!
        '
        'ThursdayTxt
        '
        Me.ThursdayTxt.CanShrink = True
        Me.ThursdayTxt.Height = 0.1979167!
        Me.ThursdayTxt.Left = 4.375!
        Me.ThursdayTxt.Name = "ThursdayTxt"
        Me.ThursdayTxt.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.ThursdayTxt.Text = "Thursday"
        Me.ThursdayTxt.Top = 1.0625!
        Me.ThursdayTxt.Width = 1.2!
        '
        'FridayTxt
        '
        Me.FridayTxt.CanShrink = True
        Me.FridayTxt.Height = 0.1979167!
        Me.FridayTxt.Left = 5.5!
        Me.FridayTxt.Name = "FridayTxt"
        Me.FridayTxt.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.FridayTxt.Text = "Friday"
        Me.FridayTxt.Top = 1.0625!
        Me.FridayTxt.Width = 1.2!
        '
        'SaturdayTxt
        '
        Me.SaturdayTxt.CanShrink = True
        Me.SaturdayTxt.Height = 0.1979167!
        Me.SaturdayTxt.Left = 6.625!
        Me.SaturdayTxt.Name = "SaturdayTxt"
        Me.SaturdayTxt.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.SaturdayTxt.Text = "Saturday"
        Me.SaturdayTxt.Top = 1.0625!
        Me.SaturdayTxt.Width = 1.1!
        '
        'lblClient
        '
        Me.lblClient.CanShrink = True
        Me.lblClient.Height = 0.1!
        Me.lblClient.Left = 0.0!
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblClient.Text = "Client:"
        Me.lblClient.Top = 0.0!
        Me.lblClient.Width = 0.75!
        '
        'lblProduct
        '
        Me.lblProduct.CanShrink = True
        Me.lblProduct.Height = 0.1!
        Me.lblProduct.Left = 0.0!
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblProduct.Text = "Product:"
        Me.lblProduct.Top = 0.2!
        Me.lblProduct.Width = 0.75!
        '
        'lblDivision
        '
        Me.lblDivision.CanShrink = True
        Me.lblDivision.Height = 0.1!
        Me.lblDivision.Left = 0.0!
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblDivision.Text = "Division:"
        Me.lblDivision.Top = 0.1!
        Me.lblDivision.Width = 0.75!
        '
        'lblSchComment
        '
        Me.lblSchComment.CanShrink = True
        Me.lblSchComment.Height = 0.1!
        Me.lblSchComment.Left = 0.0!
        Me.lblSchComment.Name = "lblSchComment"
        Me.lblSchComment.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblSchComment.Text = "Comment:"
        Me.lblSchComment.Top = 0.3!
        Me.lblSchComment.Width = 0.75!
        '
        'lblJob
        '
        Me.lblJob.CanShrink = True
        Me.lblJob.Height = 0.1!
        Me.lblJob.Left = 3.5!
        Me.lblJob.Name = "lblJob"
        Me.lblJob.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblJob.Text = "Job:"
        Me.lblJob.Top = 0.0!
        Me.lblJob.Width = 0.8125!
        '
        'lblComponent
        '
        Me.lblComponent.CanShrink = True
        Me.lblComponent.Height = 0.1!
        Me.lblComponent.Left = 3.5!
        Me.lblComponent.Name = "lblComponent"
        Me.lblComponent.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblComponent.Text = "Component:"
        Me.lblComponent.Top = 0.1!
        Me.lblComponent.Width = 0.8125!
        '
        'lblStatus
        '
        Me.lblStatus.CanShrink = True
        Me.lblStatus.Height = 0.1!
        Me.lblStatus.Left = 3.5!
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblStatus.Text = "Status:"
        Me.lblStatus.Top = 0.2!
        Me.lblStatus.Width = 0.8125!
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.Height = 0.1979167!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "background-color: LightGrey; font-size: 10pt; font-weight: bold; text-align: cent" & _
    "er"
        Me.TextBox1.Text = "Sunday"
        Me.TextBox1.Top = 1.0625!
        Me.TextBox1.Width = 1.2!
        '
        'TextBox3
        '
        Me.TextBox3.CanShrink = True
        Me.TextBox3.Height = 0.1979167!
        Me.TextBox3.Left = 1.125!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.TextBox3.Text = "Monday"
        Me.TextBox3.Top = 1.0625!
        Me.TextBox3.Width = 1.1!
        '
        'TextBox4
        '
        Me.TextBox4.CanShrink = True
        Me.TextBox4.Height = 0.2!
        Me.TextBox4.Left = 2.1875!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.TextBox4.Text = "Tuesday"
        Me.TextBox4.Top = 1.0625!
        Me.TextBox4.Width = 1.2!
        '
        'TextBox5
        '
        Me.TextBox5.CanShrink = True
        Me.TextBox5.Height = 0.2!
        Me.TextBox5.Left = 3.3125!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "background-color: LightGrey; font-weight: bold; text-align: center"
        Me.TextBox5.Text = "Wednesday"
        Me.TextBox5.Top = 1.0625!
        Me.TextBox5.Width = 1.1!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanGrow = False
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.02083333!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'arptTaskCalendar
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.84375!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.TBTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sunday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Monday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tuesday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Wednesday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Thursday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Friday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Saturday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlmonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlyear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlclient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlclientdesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtldiv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtldivdesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlprd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlprddesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtljob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtljobdesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlcomp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtlcompdesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtltrfdesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbComponent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.schComment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SundayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MondayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TuesdayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WednesdayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThursdayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FridayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaturdayTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSchComment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComponent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Friend WithEvents Sunday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Monday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Tuesday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Wednesday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Thursday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Friday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Saturday As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents TBTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MonthYear As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ClientCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents DivisionCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ProductCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents tbComponent As DataDynamics.ActiveReports.TextBox
    Friend WithEvents tbJob As DataDynamics.ActiveReports.TextBox
    Friend WithEvents dtlmonth As DataDynamics.ActiveReports.Label
    Friend WithEvents dtlyear As DataDynamics.ActiveReports.Label
    Friend WithEvents dtlclient As DataDynamics.ActiveReports.Label
    Friend WithEvents dtlclientdesc As DataDynamics.ActiveReports.Label
    Friend WithEvents dtldiv As DataDynamics.ActiveReports.Label
    Friend WithEvents dtldivdesc As DataDynamics.ActiveReports.Label
    Friend WithEvents dtlprd As DataDynamics.ActiveReports.Label
    Friend WithEvents dtlprddesc As DataDynamics.ActiveReports.Label
    Friend WithEvents dtljob As DataDynamics.ActiveReports.Label
    Friend WithEvents dtljobdesc As DataDynamics.ActiveReports.Label
    Friend WithEvents dtlcomp As DataDynamics.ActiveReports.Label
    Friend WithEvents dtlcompdesc As DataDynamics.ActiveReports.Label
    Friend WithEvents status As DataDynamics.ActiveReports.TextBox
    Friend WithEvents schComment As DataDynamics.ActiveReports.TextBox
    Friend WithEvents dtltrfdesc As DataDynamics.ActiveReports.Label
    Friend WithEvents grouping As DataDynamics.ActiveReports.Label
    Friend WithEvents SundayTxt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MondayTxt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TuesdayTxt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents WednesdayTxt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ThursdayTxt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FridayTxt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SaturdayTxt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDivision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblSchComment As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblJob As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblComponent As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblStatus As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
End Class
