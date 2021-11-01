<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptJobTrafficSchedulebyJobDueDate
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
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptJobTrafficSchedulebyJobDueDate))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtDueDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtEmployees = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaskComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtSEQ_NBR = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaskDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtMilestone = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientContacts = New DataDynamics.ActiveReports.TextBox()
        Me.TxtSpacer = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtPhase = New DataDynamics.ActiveReports.TextBox()
        Me.lblTask = New DataDynamics.ActiveReports.Label()
        Me.lblDueDate = New DataDynamics.ActiveReports.Label()
        Me.lblAssigned = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.txtAgencyInfo = New DataDynamics.ActiveReports.TextBox()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtAgencyName = New DataDynamics.ActiveReports.TextBox()
        Me.lblTitle = New DataDynamics.ActiveReports.Label()
        Me.lblAgency = New DataDynamics.ActiveReports.Label()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.txtClCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtDivCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtPrdCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientName = New DataDynamics.ActiveReports.TextBox()
        Me.txtDivisionName = New DataDynamics.ActiveReports.TextBox()
        Me.txtProductName = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtComponent = New DataDynamics.ActiveReports.TextBox()
        Me.txtStatus = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtStatusDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtCompDesc = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaskComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSEQ_NBR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaskDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMilestone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSpacer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAssigned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAgency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrdCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivisionName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatusDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDueDate, Me.txtEmployees, Me.txtTaskComments, Me.txtSEQ_NBR, Me.txtTaskDesc, Me.txtMilestone, Me.txtClientContacts, Me.TxtSpacer})
        Me.Detail1.Height = 0.3854166!
        Me.Detail1.Name = "Detail1"
        '
        'txtDueDate
        '
        Me.txtDueDate.CountNullValues = True
        Me.txtDueDate.DataField = "JOB_REVISED_DATE"
        Me.txtDueDate.Height = 0.1875!
        Me.txtDueDate.Left = 5.312!
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.OutputFormat = resources.GetString("txtDueDate.OutputFormat")
        Me.txtDueDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtDueDate.Text = "txtDueDate"
        Me.txtDueDate.Top = 0!
        Me.txtDueDate.Width = 0.8125!
        '
        'txtEmployees
        '
        Me.txtEmployees.DataField = "EMP_LNAME_LIST"
        Me.txtEmployees.Height = 0.1875!
        Me.txtEmployees.Left = 6.187!
        Me.txtEmployees.Name = "txtEmployees"
        Me.txtEmployees.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEmployees.Text = "txtEmployees"
        Me.txtEmployees.Top = 0!
        Me.txtEmployees.Width = 1.2505!
        '
        'txtTaskComments
        '
        Me.txtTaskComments.CanShrink = True
        Me.txtTaskComments.DataField = "FNC_COMMENTS"
        Me.txtTaskComments.Height = 0.1875!
        Me.txtTaskComments.Left = 2.312!
        Me.txtTaskComments.Name = "txtTaskComments"
        Me.txtTaskComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtTaskComments.Text = "txtTaskComments"
        Me.txtTaskComments.Top = 0!
        Me.txtTaskComments.Width = 2.938!
        '
        'txtSEQ_NBR
        '
        Me.txtSEQ_NBR.DataField = "SEQ_NBR"
        Me.txtSEQ_NBR.Height = 0.1875!
        Me.txtSEQ_NBR.Left = 7.3125!
        Me.txtSEQ_NBR.Name = "txtSEQ_NBR"
        Me.txtSEQ_NBR.Text = "txtSEQ_NBR"
        Me.txtSEQ_NBR.Top = 0.1875!
        Me.txtSEQ_NBR.Visible = False
        Me.txtSEQ_NBR.Width = 0.125!
        '
        'txtTaskDesc
        '
        Me.txtTaskDesc.CountNullValues = True
        Me.txtTaskDesc.DataField = "TASK_DESCRIPTION"
        Me.txtTaskDesc.Height = 0.1875!
        Me.txtTaskDesc.Left = 0.06200004!
        Me.txtTaskDesc.Name = "txtTaskDesc"
        Me.txtTaskDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtTaskDesc.Text = "txtTaskDesc"
        Me.txtTaskDesc.Top = 0!
        Me.txtTaskDesc.Width = 2.188!
        '
        'txtMilestone
        '
        Me.txtMilestone.DataField = "MILESTONE"
        Me.txtMilestone.Height = 0.1875!
        Me.txtMilestone.Left = 7.187!
        Me.txtMilestone.Name = "txtMilestone"
        Me.txtMilestone.Style = "text-align: center"
        Me.txtMilestone.Text = "txtMilestone"
        Me.txtMilestone.Top = 0.187!
        Me.txtMilestone.Visible = False
        Me.txtMilestone.Width = 0.1255002!
        '
        'txtClientContacts
        '
        Me.txtClientContacts.DataField = "CLIENT_LNAME_LIST"
        Me.txtClientContacts.Height = 0.1875!
        Me.txtClientContacts.Left = 7.062!
        Me.txtClientContacts.Name = "txtClientContacts"
        Me.txtClientContacts.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtClientContacts.Text = Nothing
        Me.txtClientContacts.Top = 0.187!
        Me.txtClientContacts.Visible = False
        Me.txtClientContacts.Width = 0.1254997!
        '
        'TxtSpacer
        '
        Me.TxtSpacer.Height = 0.115!
        Me.TxtSpacer.Left = 0.06200004!
        Me.TxtSpacer.Name = "TxtSpacer"
        Me.TxtSpacer.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TxtSpacer.Text = Nothing
        Me.TxtSpacer.Top = 0.187!
        Me.TxtSpacer.Width = 7.375!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtPhase})
        Me.GroupHeader1.DataField = "PHASE_ORDER_ID"
        Me.GroupHeader1.Height = 0.1979167!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtPhase
        '
        Me.txtPhase.DataField = "PHASE_DESC"
        Me.txtPhase.Height = 0.1875!
        Me.txtPhase.Left = 0.0625!
        Me.txtPhase.Name = "txtPhase"
        Me.txtPhase.Style = "background-color: LightGrey; font-size: 12pt; font-weight: bold; ddo-char-set: 0"
        Me.txtPhase.Text = "txtPhase"
        Me.txtPhase.Top = 0!
        Me.txtPhase.Width = 7.375!
        '
        'lblTask
        '
        Me.lblTask.Height = 0.1875!
        Me.lblTask.HyperLink = Nothing
        Me.lblTask.Left = 0.0625!
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.lblTask.Text = "Task"
        Me.lblTask.Top = 0.0625!
        Me.lblTask.Width = 2.1875!
        '
        'lblDueDate
        '
        Me.lblDueDate.Height = 0.1875!
        Me.lblDueDate.HyperLink = Nothing
        Me.lblDueDate.Left = 5.312!
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.lblDueDate.Text = "Due Date"
        Me.lblDueDate.Top = 0.062!
        Me.lblDueDate.Width = 0.8125!
        '
        'lblAssigned
        '
        Me.lblAssigned.Height = 0.1875!
        Me.lblAssigned.HyperLink = Nothing
        Me.lblAssigned.Left = 6.187!
        Me.lblAssigned.Name = "lblAssigned"
        Me.lblAssigned.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.lblAssigned.Text = "Resource"
        Me.lblAssigned.Top = 0.062!
        Me.lblAssigned.Width = 1.2505!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.3125!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0.3125!
        Me.Line1.Y2 = 0.3125!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.2291667!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.Visible = False
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAgencyInfo, Me.Picture1, Me.txtAgencyName})
        Me.PageHeader1.Height = 1.71875!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'txtAgencyInfo
        '
        Me.txtAgencyInfo.CanShrink = True
        Me.txtAgencyInfo.Height = 0.0625!
        Me.txtAgencyInfo.Left = 0.05!
        Me.txtAgencyInfo.Name = "txtAgencyInfo"
        Me.txtAgencyInfo.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtAgencyInfo.Text = "txtAgencyInfo"
        Me.txtAgencyInfo.Top = 1.625!
        Me.txtAgencyInfo.Width = 7.375!
        '
        'Picture1
        '
        Me.Picture1.Height = 1.5!
        Me.Picture1.HyperLink = Nothing
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.05!
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
        Me.txtAgencyName.Left = 0.05!
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtAgencyName.Text = "txtAgencyName"
        Me.txtAgencyName.Top = 1.5625!
        Me.txtAgencyName.Width = 7.375!
        '
        'lblTitle
        '
        Me.lblTitle.Height = 0.25!
        Me.lblTitle.HyperLink = Nothing
        Me.lblTitle.Left = 0.062!
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Style = "font-size: 12.25pt; font-weight: bold; ddo-char-set: 0"
        Me.lblTitle.Text = "Schedule Detail by Job"
        Me.lblTitle.Top = 0.06200004!
        Me.lblTitle.Width = 3.9375!
        '
        'lblAgency
        '
        Me.lblAgency.Height = 0.25!
        Me.lblAgency.HyperLink = Nothing
        Me.lblAgency.Left = 4.937!
        Me.lblAgency.Name = "lblAgency"
        Me.lblAgency.Style = "font-weight: bold; text-align: right"
        Me.lblAgency.Text = ""
        Me.lblAgency.Top = 0.06200004!
        Me.lblAgency.Width = 2.5!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.062!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.3744999!
        Me.Line2.Width = 7.375!
        Me.Line2.X1 = 0.062!
        Me.Line2.X2 = 7.437!
        Me.Line2.Y1 = 0.3744999!
        Me.Line2.Y2 = 0.3744999!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.062!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.6869999!
        Me.Line3.Width = 7.375!
        Me.Line3.X1 = 0.062!
        Me.Line3.X2 = 7.437!
        Me.Line3.Y1 = 0.6869999!
        Me.Line3.Y2 = 0.6869999!
        '
        'txtClCode
        '
        Me.txtClCode.Height = 0.0625!
        Me.txtClCode.Left = 0.062!
        Me.txtClCode.Name = "txtClCode"
        Me.txtClCode.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtClCode.Text = Nothing
        Me.txtClCode.Top = 0.4369999!
        Me.txtClCode.Width = 0.76!
        '
        'txtDivCode
        '
        Me.txtDivCode.Height = 0.0625!
        Me.txtDivCode.Left = 0.062!
        Me.txtDivCode.Name = "txtDivCode"
        Me.txtDivCode.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtDivCode.Text = Nothing
        Me.txtDivCode.Top = 0.4994999!
        Me.txtDivCode.Width = 0.76!
        '
        'txtPrdCode
        '
        Me.txtPrdCode.Height = 0.0625!
        Me.txtPrdCode.Left = 0.062!
        Me.txtPrdCode.Name = "txtPrdCode"
        Me.txtPrdCode.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtPrdCode.Text = Nothing
        Me.txtPrdCode.Top = 0.5619999!
        Me.txtPrdCode.Width = 0.76!
        '
        'txtClientName
        '
        Me.txtClientName.Height = 0.0625!
        Me.txtClientName.Left = 0.8850001!
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtClientName.Text = Nothing
        Me.txtClientName.Top = 0.437!
        Me.txtClientName.Width = 2.43!
        '
        'txtDivisionName
        '
        Me.txtDivisionName.Height = 0.0625!
        Me.txtDivisionName.Left = 0.8850001!
        Me.txtDivisionName.Name = "txtDivisionName"
        Me.txtDivisionName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtDivisionName.Text = Nothing
        Me.txtDivisionName.Top = 0.4995!
        Me.txtDivisionName.Width = 2.43!
        '
        'txtProductName
        '
        Me.txtProductName.Height = 0.0625!
        Me.txtProductName.Left = 0.8850001!
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtProductName.Text = Nothing
        Me.txtProductName.Top = 0.562!
        Me.txtProductName.Width = 2.43!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.0625!
        Me.TextBox2.Left = 3.3745!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox2.Text = "Job:"
        Me.TextBox2.Top = 0.4369999!
        Me.TextBox2.Width = 1.0!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.0625!
        Me.TextBox3.Left = 3.3745!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox3.Text = "Component:"
        Me.TextBox3.Top = 0.4994999!
        Me.TextBox3.Width = 1.0!
        '
        'TextBox4
        '
        Me.TextBox4.Height = 0.0625!
        Me.TextBox4.Left = 3.3745!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox4.Text = "Current Status:"
        Me.TextBox4.Top = 0.5619999!
        Me.TextBox4.Width = 1.0!
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Height = 0.0625!
        Me.txtJobNumber.Left = 4.437!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtJobNumber.Text = Nothing
        Me.txtJobNumber.Top = 0.4369999!
        Me.txtJobNumber.Width = 0.5625!
        '
        'txtComponent
        '
        Me.txtComponent.Height = 0.0625!
        Me.txtComponent.Left = 4.437!
        Me.txtComponent.Name = "txtComponent"
        Me.txtComponent.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtComponent.Text = Nothing
        Me.txtComponent.Top = 0.4994999!
        Me.txtComponent.Width = 0.5625!
        '
        'txtStatus
        '
        Me.txtStatus.Height = 0.0625!
        Me.txtStatus.Left = 4.437!
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtStatus.Text = Nothing
        Me.txtStatus.Top = 0.5619999!
        Me.txtStatus.Width = 0.5625!
        '
        'txtJobDesc
        '
        Me.txtJobDesc.Height = 0.0625!
        Me.txtJobDesc.Left = 5.062!
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtJobDesc.Text = Nothing
        Me.txtJobDesc.Top = 0.4369999!
        Me.txtJobDesc.Width = 2.375!
        '
        'txtStatusDesc
        '
        Me.txtStatusDesc.Height = 0.0625!
        Me.txtStatusDesc.Left = 5.062!
        Me.txtStatusDesc.Name = "txtStatusDesc"
        Me.txtStatusDesc.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtStatusDesc.Text = Nothing
        Me.txtStatusDesc.Top = 0.5619999!
        Me.txtStatusDesc.Width = 2.375!
        '
        'txtCompDesc
        '
        Me.txtCompDesc.Height = 0.0625!
        Me.txtCompDesc.Left = 5.062!
        Me.txtCompDesc.Name = "txtCompDesc"
        Me.txtCompDesc.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtCompDesc.Text = Nothing
        Me.txtCompDesc.Top = 0.4994999!
        Me.txtCompDesc.Width = 2.375!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line5, Me.ReportInfo1, Me.ReportInfo2})
        Me.PageFooter1.Height = 0.2604167!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Line5
        '
        Me.Line5.Height = 0!
        Me.Line5.Left = 0.0625!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0!
        Me.Line5.Width = 7.375!
        Me.Line5.X1 = 0.0625!
        Me.Line5.X2 = 7.4375!
        Me.Line5.Y1 = 0!
        Me.Line5.Y2 = 0!
        '
        'ReportInfo1
        '
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1979167!
        Me.ReportInfo1.Left = 6.4375!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = ""
        Me.ReportInfo1.Top = 0.0625!
        Me.ReportInfo1.Width = 1.0!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{RunDateTime:}"
        Me.ReportInfo2.Height = 0.1875!
        Me.ReportInfo2.Left = 0.0625!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = ""
        Me.ReportInfo2.Top = 0.0625!
        Me.ReportInfo2.Width = 1.1875!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTask, Me.lblDueDate, Me.lblAssigned, Me.Line1, Me.Label1})
        Me.GroupHeader2.Height = 0.3229167!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'Label1
        '
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.312!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.Label1.Text = "Description"
        Me.Label1.Top = 0.062!
        Me.Label1.Width = 2.938!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.2395833!
        Me.GroupFooter2.Name = "GroupFooter2"
        Me.GroupFooter2.Visible = False
        '
        'GroupHeader3
        '
        Me.GroupHeader3.CanShrink = True
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitle, Me.Line2, Me.lblAgency, Me.txtProductName, Me.Line3, Me.txtClCode, Me.txtDivCode, Me.txtPrdCode, Me.txtClientName, Me.txtDivisionName, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.txtJobNumber, Me.txtComponent, Me.txtStatus, Me.txtJobDesc, Me.txtStatusDesc, Me.txtCompDesc})
        Me.GroupHeader3.Height = 0.7187504!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Height = 0!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'arptJobTrafficSchedulebyJobDueDate
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
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black; ddo-char-set: 186", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaskComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSEQ_NBR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaskDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMilestone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientContacts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSpacer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAssigned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAgency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrdCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivisionName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatusDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents lblTask As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDueDate As DataDynamics.ActiveReports.Label
    Friend WithEvents lblAssigned As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtDueDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEmployees As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Friend WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    Friend WithEvents lblTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents lblAgency As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTaskComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtClCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPrdCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClientName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivisionName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProductName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComponent As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtStatus As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtStatusDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents txtPhase As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSEQ_NBR As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtAgencyInfo As DataDynamics.ActiveReports.TextBox
    Private WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Private WithEvents txtAgencyName As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents txtTaskDesc As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents txtMilestone As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtClientContacts As DataDynamics.ActiveReports.TextBox
    Private WithEvents TxtSpacer As DataDynamics.ActiveReports.TextBox
End Class
