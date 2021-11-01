<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptJobTemplate002
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptJobTemplate002))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtAgencyName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAgencyInfo = New DataDynamics.ActiveReports.TextBox()
        Me.txtReportTitle = New DataDynamics.ActiveReports.TextBox()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.level = New DataDynamics.ActiveReports.Label()
        Me.fontsize = New DataDynamics.ActiveReports.Label()
        Me.fontstyle = New DataDynamics.ActiveReports.Label()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.txtClientApprovalText = New DataDynamics.ActiveReports.TextBox()
        Me.TextboxDateClient = New DataDynamics.ActiveReports.TextBox()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.TextBoxAgencyApproval = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxDateAgency = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.ArptJobTemplateDS1 = New ActiveReportsAssembly.arptJobTemplateDS()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBoxDateLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxJobLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxClientLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxAELabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxDescriptionLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxDate = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxJob = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxClient = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxAE = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxDescription = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.srTrafficSchedule = New DataDynamics.ActiveReports.SubReport()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBoxSchedule = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBoxBudget = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxAgencyFeesLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxExpensesLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxAgencyFees = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxExpenses = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.level, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fontsize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fontstyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientApprovalText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextboxDateClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxAgencyApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxDateAgency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArptJobTemplateDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxJobLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxClientLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxAELabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxDescriptionLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxAgencyFeesLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExpensesLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxAgencyFees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.txtAgencyName, Me.txtAgencyInfo, Me.txtReportTitle})
        Me.PageHeader1.Height = 1.854165!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 1.5!
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.0625!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopRight
        Me.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.Picture1.Top = 0.0!
        Me.Picture1.Width = 7.45!
        '
        'txtAgencyName
        '
        Me.txtAgencyName.CanShrink = True
        Me.txtAgencyName.Height = 0.0625!
        Me.txtAgencyName.Left = 0.062!
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtAgencyName.Text = "txtAgencyName"
        Me.txtAgencyName.Top = 2.625!
        Me.txtAgencyName.Visible = False
        Me.txtAgencyName.Width = 7.375!
        '
        'txtAgencyInfo
        '
        Me.txtAgencyInfo.CanShrink = True
        Me.txtAgencyInfo.Height = 0.0625!
        Me.txtAgencyInfo.Left = 0.062!
        Me.txtAgencyInfo.Name = "txtAgencyInfo"
        Me.txtAgencyInfo.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtAgencyInfo.Text = "txtAgencyInfo"
        Me.txtAgencyInfo.Top = 2.687!
        Me.txtAgencyInfo.Visible = False
        Me.txtAgencyInfo.Width = 7.375!
        '
        'txtReportTitle
        '
        Me.txtReportTitle.CanShrink = True
        Me.txtReportTitle.Height = 0.25!
        Me.txtReportTitle.Left = 0.062!
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.Style = "font-size: 14.25pt; font-weight: bold; vertical-align: middle; ddo-char-set: 0"
        Me.txtReportTitle.Text = "Report Title"
        Me.txtReportTitle.Top = 1.562!
        Me.txtReportTitle.Width = 7.375!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.level, Me.fontsize, Me.fontstyle})
        Me.Detail1.Height = 0.25125!
        Me.Detail1.KeepTogether = True
        Me.Detail1.Name = "Detail1"
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.DataField = "Desc"
        Me.TextBox1.Height = 0.062!
        Me.TextBox1.Left = 0.062!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 7.1875!
        '
        'TextBox2
        '
        Me.TextBox2.CanShrink = True
        Me.TextBox2.DataField = "Desc"
        Me.TextBox2.Height = 0.06299999!
        Me.TextBox2.Left = 0.324!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Text = "TextBox2"
        Me.TextBox2.Top = 0.062!
        Me.TextBox2.Width = 6.9375!
        '
        'TextBox3
        '
        Me.TextBox3.CanShrink = True
        Me.TextBox3.DataField = "Desc"
        Me.TextBox3.Height = 0.06299999!
        Me.TextBox3.Left = 0.637!
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
        Me.TextBox4.Left = 0.824!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Text = "TextBox4"
        Me.TextBox4.Top = 0.187!
        Me.TextBox4.Width = 6.4375!
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
        Me.level.Top = 0.8130001!
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
        Me.fontsize.Top = 0.7505001!
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
        Me.fontstyle.Top = 0.7505001!
        Me.fontstyle.Visible = False
        Me.fontstyle.Width = 1.0!
        '
        'PageFooter1
        '
        Me.PageFooter1.CanShrink = True
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtClientApprovalText
        '
        Me.txtClientApprovalText.Height = 0.1875!
        Me.txtClientApprovalText.Left = 0.062!
        Me.txtClientApprovalText.Name = "txtClientApprovalText"
        Me.txtClientApprovalText.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtClientApprovalText.Text = "Client Approval:"
        Me.txtClientApprovalText.Top = 0.125!
        Me.txtClientApprovalText.Width = 1.125!
        '
        'TextboxDateClient
        '
        Me.TextboxDateClient.Height = 0.1875!
        Me.TextboxDateClient.Left = 4.062!
        Me.TextboxDateClient.Name = "TextboxDateClient"
        Me.TextboxDateClient.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextboxDateClient.Text = "Date:"
        Me.TextboxDateClient.Top = 0.125!
        Me.TextboxDateClient.Width = 0.5!
        '
        'Line6
        '
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 1.25!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.313!
        Me.Line6.Width = 2.5625!
        Me.Line6.X1 = 1.25!
        Me.Line6.X2 = 3.8125!
        Me.Line6.Y1 = 0.313!
        Me.Line6.Y2 = 0.313!
        '
        'Line7
        '
        Me.Line7.Height = 0.0!
        Me.Line7.Left = 4.625!
        Me.Line7.LineWeight = 2.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.313!
        Me.Line7.Width = 2.687!
        Me.Line7.X1 = 4.625!
        Me.Line7.X2 = 7.312!
        Me.Line7.Y1 = 0.313!
        Me.Line7.Y2 = 0.313!
        '
        'TextBoxAgencyApproval
        '
        Me.TextBoxAgencyApproval.Height = 0.1875!
        Me.TextBoxAgencyApproval.Left = 0.062!
        Me.TextBoxAgencyApproval.Name = "TextBoxAgencyApproval"
        Me.TextBoxAgencyApproval.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBoxAgencyApproval.Text = "Agency Approval:"
        Me.TextBoxAgencyApproval.Top = 0.3755!
        Me.TextBoxAgencyApproval.Width = 1.125!
        '
        'TextBoxDateAgency
        '
        Me.TextBoxDateAgency.Height = 0.1875!
        Me.TextBoxDateAgency.Left = 4.062!
        Me.TextBoxDateAgency.Name = "TextBoxDateAgency"
        Me.TextBoxDateAgency.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBoxDateAgency.Text = "Date:"
        Me.TextBoxDateAgency.Top = 0.375!
        Me.TextBoxDateAgency.Width = 0.5!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 1.25!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.563!
        Me.Line1.Width = 2.5625!
        Me.Line1.X1 = 1.25!
        Me.Line1.X2 = 3.8125!
        Me.Line1.Y1 = 0.563!
        Me.Line1.Y2 = 0.563!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 4.625!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.562!
        Me.Line2.Width = 2.687!
        Me.Line2.X1 = 4.625!
        Me.Line2.X2 = 7.312!
        Me.Line2.Y1 = 0.562!
        Me.Line2.Y2 = 0.562!
        '
        'ArptJobTemplateDS1
        '
        Me.ArptJobTemplateDS1.DataSetName = "arptJobTemplateDS"
        Me.ArptJobTemplateDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBoxDateLabel, Me.TextBoxJobLabel, Me.TextBoxClientLabel, Me.TextBoxAELabel, Me.TextBoxDescriptionLabel, Me.TextBoxDate, Me.TextBoxJob, Me.TextBoxClient, Me.TextBoxAE, Me.TextBoxDescription})
        Me.GroupHeader1.Height = 0.7078333!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'TextBoxDateLabel
        '
        Me.TextBoxDateLabel.Height = 0.2!
        Me.TextBoxDateLabel.Left = 0.062!
        Me.TextBoxDateLabel.Name = "TextBoxDateLabel"
        Me.TextBoxDateLabel.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBoxDateLabel.Text = "DATE:"
        Me.TextBoxDateLabel.Top = 0.00000001117587!
        Me.TextBoxDateLabel.Width = 0.5!
        '
        'TextBoxJobLabel
        '
        Me.TextBoxJobLabel.Height = 0.2!
        Me.TextBoxJobLabel.Left = 0.06199996!
        Me.TextBoxJobLabel.Name = "TextBoxJobLabel"
        Me.TextBoxJobLabel.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBoxJobLabel.Text = "JOB#:"
        Me.TextBoxJobLabel.Top = 0.188!
        Me.TextBoxJobLabel.Width = 0.5!
        '
        'TextBoxClientLabel
        '
        Me.TextBoxClientLabel.Height = 0.2!
        Me.TextBoxClientLabel.Left = 4.187!
        Me.TextBoxClientLabel.Name = "TextBoxClientLabel"
        Me.TextBoxClientLabel.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBoxClientLabel.Text = "CLIENT:"
        Me.TextBoxClientLabel.Top = 0.0!
        Me.TextBoxClientLabel.Width = 0.5629997!
        '
        'TextBoxAELabel
        '
        Me.TextBoxAELabel.Height = 0.2!
        Me.TextBoxAELabel.Left = 4.187!
        Me.TextBoxAELabel.Name = "TextBoxAELabel"
        Me.TextBoxAELabel.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBoxAELabel.Text = "AE:"
        Me.TextBoxAELabel.Top = 0.188!
        Me.TextBoxAELabel.Width = 0.5629997!
        '
        'TextBoxDescriptionLabel
        '
        Me.TextBoxDescriptionLabel.Height = 0.2!
        Me.TextBoxDescriptionLabel.Left = 0.06199996!
        Me.TextBoxDescriptionLabel.Name = "TextBoxDescriptionLabel"
        Me.TextBoxDescriptionLabel.Style = "font-size: 12pt; font-weight: bold; vertical-align: middle; ddo-char-set: 0"
        Me.TextBoxDescriptionLabel.Text = "DESCRIPTION:"
        Me.TextBoxDescriptionLabel.Top = 0.5!
        Me.TextBoxDescriptionLabel.Width = 1.25!
        '
        'TextBoxDate
        '
        Me.TextBoxDate.Height = 0.2!
        Me.TextBoxDate.Left = 0.6249999!
        Me.TextBoxDate.Name = "TextBoxDate"
        Me.TextBoxDate.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.TextBoxDate.Text = Nothing
        Me.TextBoxDate.Top = 0.0!
        Me.TextBoxDate.Width = 2.0!
        '
        'TextBoxJob
        '
        Me.TextBoxJob.Height = 0.2!
        Me.TextBoxJob.Left = 0.6249999!
        Me.TextBoxJob.Name = "TextBoxJob"
        Me.TextBoxJob.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.TextBoxJob.Text = Nothing
        Me.TextBoxJob.Top = 0.188!
        Me.TextBoxJob.Width = 2.0!
        '
        'TextBoxClient
        '
        Me.TextBoxClient.Height = 0.2!
        Me.TextBoxClient.Left = 4.812!
        Me.TextBoxClient.Name = "TextBoxClient"
        Me.TextBoxClient.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.TextBoxClient.Text = Nothing
        Me.TextBoxClient.Top = 0.0!
        Me.TextBoxClient.Width = 2.625!
        '
        'TextBoxAE
        '
        Me.TextBoxAE.Height = 0.2!
        Me.TextBoxAE.Left = 4.812!
        Me.TextBoxAE.Name = "TextBoxAE"
        Me.TextBoxAE.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.TextBoxAE.Text = Nothing
        Me.TextBoxAE.Top = 0.188!
        Me.TextBoxAE.Width = 2.625!
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Height = 0.2!
        Me.TextBoxDescription.Left = 1.375!
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.Style = "font-size: 9pt; font-weight: normal; vertical-align: middle; ddo-char-set: 0"
        Me.TextBoxDescription.Text = Nothing
        Me.TextBoxDescription.Top = 0.5!
        Me.TextBoxDescription.Width = 6.062!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'srTrafficSchedule
        '
        Me.srTrafficSchedule.CloseBorder = False
        Me.srTrafficSchedule.Height = 1.375!
        Me.srTrafficSchedule.Left = 0.062!
        Me.srTrafficSchedule.Name = "srTrafficSchedule"
        Me.srTrafficSchedule.Report = Nothing
        Me.srTrafficSchedule.ReportName = "SubReport1"
        Me.srTrafficSchedule.Top = 0.312!
        Me.srTrafficSchedule.Width = 7.4375!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.CanShrink = True
        Me.GroupHeader3.Height = 0.0!
        Me.GroupHeader3.Name = "GroupHeader3"
        Me.GroupHeader3.Visible = False
        '
        'GroupFooter3
        '
        Me.GroupFooter3.CanShrink = True
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBoxSchedule, Me.srTrafficSchedule})
        Me.GroupFooter3.Height = 1.65625!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'TextBoxSchedule
        '
        Me.TextBoxSchedule.Height = 0.2!
        Me.TextBoxSchedule.Left = 0.062!
        Me.TextBoxSchedule.Name = "TextBoxSchedule"
        Me.TextBoxSchedule.Style = "font-size: 12pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBoxSchedule.Text = "SCHEDULE:"
        Me.TextBoxSchedule.Top = 0.062!
        Me.TextBoxSchedule.Width = 1.25!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Height = 0.0!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.Visible = False
        '
        'GroupFooter2
        '
        Me.GroupFooter2.CanShrink = True
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBoxBudget, Me.TextBoxAgencyFeesLabel, Me.TextBoxExpensesLabel, Me.TextBoxAgencyFees, Me.TextBoxExpenses})
        Me.GroupFooter2.Height = 0.7187498!
        Me.GroupFooter2.KeepTogether = True
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'TextBoxBudget
        '
        Me.TextBoxBudget.Height = 0.2!
        Me.TextBoxBudget.Left = 0.062!
        Me.TextBoxBudget.Name = "TextBoxBudget"
        Me.TextBoxBudget.Style = "font-size: 12pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBoxBudget.Text = "BUDGET:"
        Me.TextBoxBudget.Top = 0.062!
        Me.TextBoxBudget.Width = 1.0!
        '
        'TextBoxAgencyFeesLabel
        '
        Me.TextBoxAgencyFeesLabel.Height = 0.2!
        Me.TextBoxAgencyFeesLabel.Left = 0.5!
        Me.TextBoxAgencyFeesLabel.Name = "TextBoxAgencyFeesLabel"
        Me.TextBoxAgencyFeesLabel.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBoxAgencyFeesLabel.Text = "Agency Fees:"
        Me.TextBoxAgencyFeesLabel.Top = 0.312!
        Me.TextBoxAgencyFeesLabel.Width = 1.0!
        '
        'TextBoxExpensesLabel
        '
        Me.TextBoxExpensesLabel.Height = 0.2!
        Me.TextBoxExpensesLabel.Left = 0.5!
        Me.TextBoxExpensesLabel.Name = "TextBoxExpensesLabel"
        Me.TextBoxExpensesLabel.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBoxExpensesLabel.Text = "Expenses:"
        Me.TextBoxExpensesLabel.Top = 0.499!
        Me.TextBoxExpensesLabel.Width = 1.0!
        '
        'TextBoxAgencyFees
        '
        Me.TextBoxAgencyFees.Height = 0.2!
        Me.TextBoxAgencyFees.Left = 1.562!
        Me.TextBoxAgencyFees.Name = "TextBoxAgencyFees"
        Me.TextBoxAgencyFees.OutputFormat = resources.GetString("TextBoxAgencyFees.OutputFormat")
        Me.TextBoxAgencyFees.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.TextBoxAgencyFees.Text = Nothing
        Me.TextBoxAgencyFees.Top = 0.312!
        Me.TextBoxAgencyFees.Width = 2.0!
        '
        'TextBoxExpenses
        '
        Me.TextBoxExpenses.Height = 0.2!
        Me.TextBoxExpenses.Left = 1.562!
        Me.TextBoxExpenses.Name = "TextBoxExpenses"
        Me.TextBoxExpenses.OutputFormat = resources.GetString("TextBoxExpenses.OutputFormat")
        Me.TextBoxExpenses.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.TextBoxExpenses.Text = Nothing
        Me.TextBoxExpenses.Top = 0.499!
        Me.TextBoxExpenses.Width = 2.0!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.CanShrink = True
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtClientApprovalText, Me.TextboxDateClient, Me.Line6, Me.Line7, Me.TextBoxAgencyApproval, Me.TextBoxDateAgency, Me.Line1, Me.Line2})
        Me.ReportFooter1.Height = 0.6770833!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.PrintAtBottom = True
        '
        'arptJobTemplate002
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.2!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReportTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.level, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fontsize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fontstyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientApprovalText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextboxDateClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxAgencyApproval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxDateAgency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArptJobTemplateDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxJobLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxClientLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxAELabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxDescriptionLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxAgencyFeesLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExpensesLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxAgencyFees, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ArptJobTemplateDS1 As ActiveReportsAssembly.arptJobTemplateDS
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents srTrafficSchedule As DataDynamics.ActiveReports.SubReport
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents txtAgencyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAgencyInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents TextBoxDateLabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxJobLabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxClientLabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxAELabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxDescriptionLabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxDate As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxJob As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxClient As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxAE As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxDescription As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxSchedule As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxBudget As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtClientApprovalText As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextboxDateClient As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line6 As DataDynamics.ActiveReports.Line
    Private WithEvents Line7 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBoxAgencyApproval As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxDateAgency As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBoxAgencyFeesLabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxExpensesLabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxAgencyFees As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxExpenses As DataDynamics.ActiveReports.TextBox
    Private WithEvents level As DataDynamics.ActiveReports.Label
    Private WithEvents fontsize As DataDynamics.ActiveReports.Label
    Private WithEvents fontstyle As DataDynamics.ActiveReports.Label
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Private WithEvents txtReportTitle As DataDynamics.ActiveReports.TextBox
    Private WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Private WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
End Class
