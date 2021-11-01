<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptJobTemplate 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(arptJobTemplate))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtAgencyName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAgencyInfo = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.lblItemType2 = New DataDynamics.ActiveReports.Label()
        Me.txtSDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtfieldDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtLong = New DataDynamics.ActiveReports.TextBox()
        Me.txtEditable = New DataDynamics.ActiveReports.TextBox()
        Me.txtItemCode = New DataDynamics.ActiveReports.TextBox()
        Me.lblRush = New DataDynamics.ActiveReports.Label()
        Me.txtfieldValue = New DataDynamics.ActiveReports.RichTextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.lblEmp = New DataDynamics.ActiveReports.Label()
        Me.ArptJobTemplateDS1 = New ActiveReportsAssembly.arptJobTemplateDS()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtShortDesc = New DataDynamics.ActiveReports.TextBox()
        Me.lblItemType = New DataDynamics.ActiveReports.Label()
        Me.lblSection_order = New DataDynamics.ActiveReports.Label()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.srTrafficSchedule = New DataDynamics.ActiveReports.SubReport()
        Me.lblMilestoneTitle = New DataDynamics.ActiveReports.TextBox()
        Me.lblTrafficSchedule = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.txtCW = New DataDynamics.ActiveReports.TextBox()
        Me.txtAC = New DataDynamics.ActiveReports.TextBox()
        Me.txtTM = New DataDynamics.ActiveReports.TextBox()
        Me.txtAD = New DataDynamics.ActiveReports.TextBox()
        Me.txtBM = New DataDynamics.ActiveReports.TextBox()
        Me.lblTrafficAssignments = New DataDynamics.ActiveReports.TextBox()
        Me.lblCW = New DataDynamics.ActiveReports.TextBox()
        Me.lblAC = New DataDynamics.ActiveReports.TextBox()
        Me.lblTM = New DataDynamics.ActiveReports.TextBox()
        Me.lblAD = New DataDynamics.ActiveReports.TextBox()
        Me.lblBM = New DataDynamics.ActiveReports.TextBox()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItemType2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfieldDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEditable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItemCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRush, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArptJobTemplateDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtShortDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItemType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSection_order, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMilestoneTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrafficSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrafficAssignments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.txtAgencyName, Me.txtAgencyInfo})
        Me.PageHeader1.Height = 1.708333!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.Picture1.Width = 7.45!
        '
        'txtAgencyName
        '
        Me.txtAgencyName.CanShrink = True
        Me.txtAgencyName.Height = 0.0625!
        Me.txtAgencyName.Left = 0.0625!
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtAgencyName.Text = "txtAgencyName"
        Me.txtAgencyName.Top = 1.5625!
        Me.txtAgencyName.Width = 7.375!
        '
        'txtAgencyInfo
        '
        Me.txtAgencyInfo.CanShrink = True
        Me.txtAgencyInfo.Height = 0.0625!
        Me.txtAgencyInfo.Left = 0.0625!
        Me.txtAgencyInfo.Name = "txtAgencyInfo"
        Me.txtAgencyInfo.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtAgencyInfo.Text = "txtAgencyInfo"
        Me.txtAgencyInfo.Top = 1.625!
        Me.txtAgencyInfo.Width = 7.375!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0!
        Me.Line1.Y2 = 0!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.25!
        Me.Line2.Width = 7.375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.4375!
        Me.Line2.Y1 = 0.25!
        Me.Line2.Y2 = 0.25!
        '
        'Label1
        '
        Me.Label1.Height = 0.25!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 14.25pt; font-weight: bold; vertical-align: middle; ddo-char-set: 0"
        Me.Label1.Text = "Report Title"
        Me.Label1.Top = 0!
        Me.Label1.Width = 7.375!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblItemType2, Me.txtSDesc, Me.txtfieldDesc, Me.txtLong, Me.txtEditable, Me.txtItemCode, Me.lblRush, Me.txtfieldValue})
        Me.Detail1.Height = 0.2304167!
        Me.Detail1.Name = "Detail1"
        '
        'lblItemType2
        '
        Me.lblItemType2.DataField = "ITEM_TYPE"
        Me.lblItemType2.Height = 0.1875!
        Me.lblItemType2.HyperLink = Nothing
        Me.lblItemType2.Left = 7.1875!
        Me.lblItemType2.Name = "lblItemType2"
        Me.lblItemType2.Style = ""
        Me.lblItemType2.Text = "lblItemType"
        Me.lblItemType2.Top = 0.25!
        Me.lblItemType2.Visible = False
        Me.lblItemType2.Width = 0.25!
        '
        'txtSDesc
        '
        Me.txtSDesc.CanShrink = True
        Me.txtSDesc.DataField = "SHORT_DESC"
        Me.txtSDesc.Height = 0.1875!
        Me.txtSDesc.Left = 0.0625!
        Me.txtSDesc.Name = "txtSDesc"
        Me.txtSDesc.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtSDesc.Text = "txtShortDesc"
        Me.txtSDesc.Top = 0!
        Me.txtSDesc.Width = 1.5!
        '
        'txtfieldDesc
        '
        Me.txtfieldDesc.CanShrink = True
        Me.txtfieldDesc.DataField = "FIELD_DESCRIPT"
        Me.txtfieldDesc.Height = 0.1979167!
        Me.txtfieldDesc.Left = 6.125!
        Me.txtfieldDesc.Name = "txtfieldDesc"
        Me.txtfieldDesc.Text = "txtfieldDesc"
        Me.txtfieldDesc.Top = 0.25!
        Me.txtfieldDesc.Visible = False
        Me.txtfieldDesc.Width = 1.0!
        '
        'txtLong
        '
        Me.txtLong.CanShrink = True
        Me.txtLong.DataField = "LONG_DESC"
        Me.txtLong.Height = 0.1875!
        Me.txtLong.Left = 0.25!
        Me.txtLong.Name = "txtLong"
        Me.txtLong.Text = "txtLong"
        Me.txtLong.Top = 0!
        Me.txtLong.Visible = False
        Me.txtLong.Width = 0.125!
        '
        'txtEditable
        '
        Me.txtEditable.CanShrink = True
        Me.txtEditable.DataField = "EDITABLE"
        Me.txtEditable.Height = 0.1875!
        Me.txtEditable.Left = 0.125!
        Me.txtEditable.Name = "txtEditable"
        Me.txtEditable.Text = "txtEditable"
        Me.txtEditable.Top = 0!
        Me.txtEditable.Visible = False
        Me.txtEditable.Width = 0.125!
        '
        'txtItemCode
        '
        Me.txtItemCode.CanShrink = True
        Me.txtItemCode.DataField = "ITEM_CODE"
        Me.txtItemCode.Height = 0.1875!
        Me.txtItemCode.Left = 0.375!
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Text = "txtItemCode"
        Me.txtItemCode.Top = 0!
        Me.txtItemCode.Visible = False
        Me.txtItemCode.Width = 0.125!
        '
        'lblRush
        '
        Me.lblRush.Height = 0.22!
        Me.lblRush.HyperLink = Nothing
        Me.lblRush.Left = 6.8125!
        Me.lblRush.Name = "lblRush"
        Me.lblRush.Style = "color: Red; font-size: 14pt; font-weight: bold"
        Me.lblRush.Text = "RUSH"
        Me.lblRush.Top = 0!
        Me.lblRush.Width = 0.625!
        '
        'txtfieldValue
        '
        Me.txtfieldValue.AutoReplaceFields = True
        Me.txtfieldValue.DataField = "FIELD_VALUE"
        Me.txtfieldValue.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtfieldValue.Height = 0.187!
        Me.txtfieldValue.Left = 1.625!
        Me.txtfieldValue.Name = "txtfieldValue"
        Me.txtfieldValue.RTF = resources.GetString("txtfieldValue.RTF")
        Me.txtfieldValue.Top = 0!
        Me.txtfieldValue.Width = 5.812!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1, Me.ReportInfo2, Me.lblEmp})
        Me.PageFooter1.Height = 0.1875!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1875!
        Me.ReportInfo1.Left = 4.5625!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-size: 9pt; text-align: right"
        Me.ReportInfo1.Top = 0!
        Me.ReportInfo1.Width = 2.875!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{RunDateTime:}"
        Me.ReportInfo2.Height = 0.1875!
        Me.ReportInfo2.Left = 0.0625!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 9pt"
        Me.ReportInfo2.Top = 0!
        Me.ReportInfo2.Visible = False
        Me.ReportInfo2.Width = 1.5625!
        '
        'lblEmp
        '
        Me.lblEmp.Height = 0.1875!
        Me.lblEmp.HyperLink = Nothing
        Me.lblEmp.Left = 1.625!
        Me.lblEmp.Name = "lblEmp"
        Me.lblEmp.Style = "font-size: 9pt"
        Me.lblEmp.Text = "lblEmp"
        Me.lblEmp.Top = 0!
        Me.lblEmp.Visible = False
        Me.lblEmp.Width = 2.9375!
        '
        'ArptJobTemplateDS1
        '
        Me.ArptJobTemplateDS1.DataSetName = "arptJobTemplateDS"
        Me.ArptJobTemplateDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Line2, Me.Line1})
        Me.GroupHeader1.Height = 0.3020833!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtShortDesc
        '
        Me.txtShortDesc.CanShrink = True
        Me.txtShortDesc.DataField = "SHORT_DESC"
        Me.txtShortDesc.Height = 0.1875!
        Me.txtShortDesc.Left = 0.0625!
        Me.txtShortDesc.Name = "txtShortDesc"
        Me.txtShortDesc.Style = "background-color: Gray; color: White; font-size: 9.75pt; font-style: italic; font" &
    "-weight: bold; vertical-align: middle; ddo-char-set: 0"
        Me.txtShortDesc.Text = "txtShortDesc"
        Me.txtShortDesc.Top = 0!
        Me.txtShortDesc.Width = 1.9375!
        '
        'lblItemType
        '
        Me.lblItemType.DataField = "ITEM_TYPE"
        Me.lblItemType.Height = 0.1875!
        Me.lblItemType.HyperLink = Nothing
        Me.lblItemType.Left = 7.1875!
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Style = ""
        Me.lblItemType.Text = "lblItemType"
        Me.lblItemType.Top = 0!
        Me.lblItemType.Visible = False
        Me.lblItemType.Width = 0.25!
        '
        'lblSection_order
        '
        Me.lblSection_order.DataField = "SECTION_ORDER"
        Me.lblSection_order.Height = 0.1875!
        Me.lblSection_order.HyperLink = Nothing
        Me.lblSection_order.Left = 7.0!
        Me.lblSection_order.Name = "lblSection_order"
        Me.lblSection_order.Style = ""
        Me.lblSection_order.Text = "lblSection_order"
        Me.lblSection_order.Top = 0!
        Me.lblSection_order.Visible = False
        Me.lblSection_order.Width = 0.1875!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 2.0!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.1875!
        Me.Line3.Width = 5.4375!
        Me.Line3.X1 = 2.0!
        Me.Line3.X2 = 7.4375!
        Me.Line3.Y1 = 0.1875!
        Me.Line3.Y2 = 0.1875!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line5, Me.srTrafficSchedule, Me.lblMilestoneTitle, Me.lblTrafficSchedule})
        Me.GroupFooter1.Height = 1.958333!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Line5
        '
        Me.Line5.Height = 0!
        Me.Line5.Left = 2.0!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.1875!
        Me.Line5.Width = 5.4375!
        Me.Line5.X1 = 2.0!
        Me.Line5.X2 = 7.4375!
        Me.Line5.Y1 = 0.1875!
        Me.Line5.Y2 = 0.1875!
        '
        'srTrafficSchedule
        '
        Me.srTrafficSchedule.CloseBorder = False
        Me.srTrafficSchedule.Height = 1.375!
        Me.srTrafficSchedule.Left = 0.0625!
        Me.srTrafficSchedule.Name = "srTrafficSchedule"
        Me.srTrafficSchedule.Report = Nothing
        Me.srTrafficSchedule.ReportName = "SubReport1"
        Me.srTrafficSchedule.Top = 0.5625!
        Me.srTrafficSchedule.Width = 7.4375!
        '
        'lblMilestoneTitle
        '
        Me.lblMilestoneTitle.CanShrink = True
        Me.lblMilestoneTitle.Height = 0.1875!
        Me.lblMilestoneTitle.Left = 2.375!
        Me.lblMilestoneTitle.Name = "lblMilestoneTitle"
        Me.lblMilestoneTitle.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.lblMilestoneTitle.Text = "lblMilestoneTitle"
        Me.lblMilestoneTitle.Top = 0.25!
        Me.lblMilestoneTitle.Width = 3.6875!
        '
        'lblTrafficSchedule
        '
        Me.lblTrafficSchedule.Height = 0.1875!
        Me.lblTrafficSchedule.Left = 0.0625!
        Me.lblTrafficSchedule.Name = "lblTrafficSchedule"
        Me.lblTrafficSchedule.Style = "background-color: Gray; color: White; font-style: italic; font-weight: bold; vert" &
    "ical-align: middle"
        Me.lblTrafficSchedule.Text = "lblTrafficSchedule"
        Me.lblTrafficSchedule.Top = 0!
        Me.lblTrafficSchedule.Width = 1.9375!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.CanShrink = True
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtShortDesc, Me.lblItemType, Me.lblSection_order, Me.Line3})
        Me.GroupHeader3.DataField = "SECTION_ORDER"
        Me.GroupHeader3.Height = 0.1875!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.CanShrink = True
        Me.GroupFooter3.Height = 0.1458333!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Height = 0!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.Visible = False
        '
        'GroupFooter2
        '
        Me.GroupFooter2.CanShrink = True
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line4, Me.txtCW, Me.txtAC, Me.txtTM, Me.txtAD, Me.txtBM, Me.lblTrafficAssignments, Me.lblCW, Me.lblAC, Me.lblTM, Me.lblAD, Me.lblBM})
        Me.GroupFooter2.Height = 1.677083!
        Me.GroupFooter2.KeepTogether = True
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Line4
        '
        Me.Line4.Height = 0!
        Me.Line4.Left = 2.0!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.1875!
        Me.Line4.Width = 5.4375!
        Me.Line4.X1 = 2.0!
        Me.Line4.X2 = 7.4375!
        Me.Line4.Y1 = 0.1875!
        Me.Line4.Y2 = 0.1875!
        '
        'txtCW
        '
        Me.txtCW.CanShrink = True
        Me.txtCW.Height = 0.1875!
        Me.txtCW.Left = 1.625!
        Me.txtCW.Name = "txtCW"
        Me.txtCW.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCW.Text = Nothing
        Me.txtCW.Top = 0.375!
        Me.txtCW.Width = 4.0!
        '
        'txtAC
        '
        Me.txtAC.CanShrink = True
        Me.txtAC.Height = 0.1875!
        Me.txtAC.Left = 1.625!
        Me.txtAC.Name = "txtAC"
        Me.txtAC.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAC.Text = Nothing
        Me.txtAC.Top = 0.625!
        Me.txtAC.Width = 4.0!
        '
        'txtTM
        '
        Me.txtTM.CanShrink = True
        Me.txtTM.Height = 0.1875!
        Me.txtTM.Left = 1.625!
        Me.txtTM.Name = "txtTM"
        Me.txtTM.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtTM.Text = Nothing
        Me.txtTM.Top = 0.875!
        Me.txtTM.Width = 4.0!
        '
        'txtAD
        '
        Me.txtAD.CanShrink = True
        Me.txtAD.Height = 0.1875!
        Me.txtAD.Left = 1.625!
        Me.txtAD.Name = "txtAD"
        Me.txtAD.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAD.Text = Nothing
        Me.txtAD.Top = 1.125!
        Me.txtAD.Width = 4.0!
        '
        'txtBM
        '
        Me.txtBM.CanShrink = True
        Me.txtBM.Height = 0.1875!
        Me.txtBM.Left = 1.625!
        Me.txtBM.Name = "txtBM"
        Me.txtBM.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtBM.Text = Nothing
        Me.txtBM.Top = 1.375!
        Me.txtBM.Width = 4.0!
        '
        'lblTrafficAssignments
        '
        Me.lblTrafficAssignments.Height = 0.1875!
        Me.lblTrafficAssignments.Left = 0.0625!
        Me.lblTrafficAssignments.Name = "lblTrafficAssignments"
        Me.lblTrafficAssignments.Style = "background-color: Gray; color: White; font-style: italic; font-weight: bold; vert" &
    "ical-align: middle"
        Me.lblTrafficAssignments.Text = "lblTrafficAssignments"
        Me.lblTrafficAssignments.Top = 0!
        Me.lblTrafficAssignments.Width = 1.9375!
        '
        'lblCW
        '
        Me.lblCW.CanShrink = True
        Me.lblCW.Height = 0.1875!
        Me.lblCW.Left = 0.0625!
        Me.lblCW.Name = "lblCW"
        Me.lblCW.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblCW.Text = Nothing
        Me.lblCW.Top = 0.375!
        Me.lblCW.Width = 1.5!
        '
        'lblAC
        '
        Me.lblAC.CanShrink = True
        Me.lblAC.Height = 0.1875!
        Me.lblAC.Left = 0.0625!
        Me.lblAC.Name = "lblAC"
        Me.lblAC.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblAC.Text = Nothing
        Me.lblAC.Top = 0.625!
        Me.lblAC.Width = 1.5!
        '
        'lblTM
        '
        Me.lblTM.CanShrink = True
        Me.lblTM.Height = 0.1875!
        Me.lblTM.Left = 0.0625!
        Me.lblTM.Name = "lblTM"
        Me.lblTM.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblTM.Text = Nothing
        Me.lblTM.Top = 0.875!
        Me.lblTM.Width = 1.5!
        '
        'lblAD
        '
        Me.lblAD.CanShrink = True
        Me.lblAD.Height = 0.1875!
        Me.lblAD.Left = 0.0625!
        Me.lblAD.Name = "lblAD"
        Me.lblAD.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblAD.Text = Nothing
        Me.lblAD.Top = 1.125!
        Me.lblAD.Width = 1.5!
        '
        'lblBM
        '
        Me.lblBM.CanShrink = True
        Me.lblBM.Height = 0.1875!
        Me.lblBM.Left = 0.0625!
        Me.lblBM.Name = "lblBM"
        Me.lblBM.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblBM.Text = Nothing
        Me.lblBM.Top = 1.375!
        Me.lblBM.Width = 1.5!
        '
        'arptJobTemplate
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItemType2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfieldDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEditable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItemCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRush, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArptJobTemplateDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtShortDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItemType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSection_order, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMilestoneTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrafficSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrafficAssignments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ArptJobTemplateDS1 As ActiveReportsAssembly.arptJobTemplateDS
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtShortDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblItemType2 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblItemType As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblSection_order As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtfieldDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents srTrafficSchedule As DataDynamics.ActiveReports.SubReport
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lblEmp As DataDynamics.ActiveReports.Label
    Friend WithEvents txtAgencyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAgencyInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMilestoneTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTrafficSchedule As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLong As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblRush As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEditable As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtItemCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtCW As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAC As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAD As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTrafficAssignments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCW As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAC As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAD As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblBM As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtfieldValue As DataDynamics.ActiveReports.RichTextBox
End Class
