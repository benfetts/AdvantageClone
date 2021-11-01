<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class sum_rep_by_client
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(sum_rep_by_client))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.lblDueDate = New DataDynamics.ActiveReports.Label()
        Me.lblType = New DataDynamics.ActiveReports.Label()
        Me.lblStatus = New DataDynamics.ActiveReports.Label()
        Me.lblRef = New DataDynamics.ActiveReports.Label()
        Me.lblSdate = New DataDynamics.ActiveReports.Label()
        Me.lblEst = New DataDynamics.ActiveReports.Label()
        Me.lblestaprv = New DataDynamics.ActiveReports.Label()
        Me.lblNT = New DataDynamics.ActiveReports.Label()
        Me.lblND = New DataDynamics.ActiveReports.Label()
        Me.lblae = New DataDynamics.ActiveReports.Label()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtJob1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtComponent1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtDue_Date1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtComponentNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtType = New DataDynamics.ActiveReports.TextBox()
        Me.txtType_desc = New DataDynamics.ActiveReports.TextBox()
        Me.txtStatus = New DataDynamics.ActiveReports.TextBox()
        Me.txtRef = New DataDynamics.ActiveReports.TextBox()
        Me.txtSdate = New DataDynamics.ActiveReports.TextBox()
        Me.txtComm = New DataDynamics.ActiveReports.TextBox()
        Me.txtEst = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstAprv = New DataDynamics.ActiveReports.TextBox()
        Me.txtNTask = New DataDynamics.ActiveReports.TextBox()
        Me.txtND = New DataDynamics.ActiveReports.TextBox()
        Me.txtNComm = New DataDynamics.ActiveReports.TextBox()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobQty = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtAccount_Executive1 = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.lbluser = New DataDynamics.ActiveReports.Label()
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.lbldiv = New DataDynamics.ActiveReports.Label()
        Me.lblprod = New DataDynamics.ActiveReports.Label()
        Me.txtClient1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtDivision1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtProduct1 = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.txtCDP = New DataDynamics.ActiveReports.TextBox()
        Me.txtProductCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtDivisionCode = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.sum_rep_by_clientDS1 = New ActiveReportsAssembly.arptOpenJobsDS()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblestaprv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblND, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblae, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJob1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDue_Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponentNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtType_desc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstAprv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtND, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNComm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccount_Executive1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbldiv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblprod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClient1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivision1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCDP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivisionCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sum_rep_by_clientDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.Line2})
        Me.PageHeader1.Height = 0.5833333!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.Height = 0.5625!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 14.25pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox1.Text = "Project Summary Report"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 10.9375!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.5625!
        Me.Line2.Width = 11.0625!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 11.0625!
        Me.Line2.Y1 = 0.5625!
        Me.Line2.Y2 = 0.5625!
        '
        'lblDueDate
        '
        Me.lblDueDate.Height = 0.1875!
        Me.lblDueDate.HyperLink = Nothing
        Me.lblDueDate.Left = 5.875!
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblDueDate.Text = "Due Date"
        Me.lblDueDate.Top = 0.25!
        Me.lblDueDate.Width = 0.75!
        '
        'lblType
        '
        Me.lblType.Height = 0.1875!
        Me.lblType.HyperLink = Nothing
        Me.lblType.Left = 2.5!
        Me.lblType.Name = "lblType"
        Me.lblType.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblType.Text = "Job Type"
        Me.lblType.Top = 0.25!
        Me.lblType.Width = 1.125!
        '
        'lblStatus
        '
        Me.lblStatus.Height = 0.1875!
        Me.lblStatus.HyperLink = Nothing
        Me.lblStatus.Left = 4.125!
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblStatus.Text = "Status"
        Me.lblStatus.Top = 0.25!
        Me.lblStatus.Width = 0.5!
        '
        'lblRef
        '
        Me.lblRef.Height = 0.3125!
        Me.lblRef.HyperLink = Nothing
        Me.lblRef.Left = 5.0625!
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblRef.Text = "Client Reference"
        Me.lblRef.Top = 0.125!
        Me.lblRef.Width = 0.6875!
        '
        'lblSdate
        '
        Me.lblSdate.Height = 0.1875!
        Me.lblSdate.HyperLink = Nothing
        Me.lblSdate.Left = 5.875!
        Me.lblSdate.Name = "lblSdate"
        Me.lblSdate.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblSdate.Text = "Start Date"
        Me.lblSdate.Top = 0.0!
        Me.lblSdate.Width = 0.6875!
        '
        'lblEst
        '
        Me.lblEst.Height = 0.1875!
        Me.lblEst.HyperLink = Nothing
        Me.lblEst.Left = 10.3125!
        Me.lblEst.Name = "lblEst"
        Me.lblEst.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblEst.Text = "Estimate"
        Me.lblEst.Top = 0.0!
        Me.lblEst.Width = 0.6875!
        '
        'lblestaprv
        '
        Me.lblestaprv.Height = 0.1875!
        Me.lblestaprv.HyperLink = Nothing
        Me.lblestaprv.Left = 10.3125!
        Me.lblestaprv.Name = "lblestaprv"
        Me.lblestaprv.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblestaprv.Text = "Approved"
        Me.lblestaprv.Top = 0.25!
        Me.lblestaprv.Width = 0.6875!
        '
        'lblNT
        '
        Me.lblNT.Height = 0.1875!
        Me.lblNT.HyperLink = Nothing
        Me.lblNT.Left = 6.8125!
        Me.lblNT.Name = "lblNT"
        Me.lblNT.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblNT.Text = "Next Task"
        Me.lblNT.Top = 0.0!
        Me.lblNT.Width = 0.75!
        '
        'lblND
        '
        Me.lblND.Height = 0.1875!
        Me.lblND.HyperLink = Nothing
        Me.lblND.Left = 6.8125!
        Me.lblND.Name = "lblND"
        Me.lblND.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblND.Text = "Due Date"
        Me.lblND.Top = 0.25!
        Me.lblND.Width = 0.75!
        '
        'lblae
        '
        Me.lblae.Height = 0.1875!
        Me.lblae.HyperLink = Nothing
        Me.lblae.Left = 0.0625!
        Me.lblae.Name = "lblae"
        Me.lblae.Style = "font-family: Arial; font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblae.Text = "Account Executive:"
        Me.lblae.Top = 0.0!
        Me.lblae.Width = 1.375!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtJob1, Me.txtComponent1, Me.txtDue_Date1, Me.txtComponentNumber, Me.txtType, Me.txtType_desc, Me.txtStatus, Me.txtRef, Me.txtSdate, Me.txtComm, Me.txtEst, Me.txtEstAprv, Me.txtNTask, Me.txtND, Me.txtNComm, Me.Line3, Me.txtJobNumber, Me.txtJobQty})
        Me.Detail1.Height = 1.03125!
        Me.Detail1.Name = "Detail1"
        '
        'txtJob1
        '
        Me.txtJob1.DataField = "JOB_DESC"
        Me.txtJob1.Height = 0.1875!
        Me.txtJob1.Left = 0.6875!
        Me.txtJob1.Name = "txtJob1"
        Me.txtJob1.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtJob1.Text = "txtJob1"
        Me.txtJob1.Top = 0.0!
        Me.txtJob1.Width = 10.25!
        '
        'txtComponent1
        '
        Me.txtComponent1.DataField = "JOB_COMP_DESC"
        Me.txtComponent1.Height = 0.1875!
        Me.txtComponent1.Left = 0.6875!
        Me.txtComponent1.Name = "txtComponent1"
        Me.txtComponent1.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtComponent1.Text = "txtComponent1"
        Me.txtComponent1.Top = 0.1875!
        Me.txtComponent1.Width = 10.25!
        '
        'txtDue_Date1
        '
        Me.txtDue_Date1.DataField = "Due Date"
        Me.txtDue_Date1.Height = 0.1875!
        Me.txtDue_Date1.Left = 5.875!
        Me.txtDue_Date1.Name = "txtDue_Date1"
        Me.txtDue_Date1.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtDue_Date1.Text = "txtDue_Date1"
        Me.txtDue_Date1.Top = 0.75!
        Me.txtDue_Date1.Width = 0.8125!
        '
        'txtComponentNumber
        '
        Me.txtComponentNumber.DataField = "JOB_COMPONENT_NBR"
        Me.txtComponentNumber.Height = 0.1875!
        Me.txtComponentNumber.Left = 0.0625!
        Me.txtComponentNumber.Name = "txtComponentNumber"
        Me.txtComponentNumber.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtComponentNumber.Text = "txtComponentNumber"
        Me.txtComponentNumber.Top = 0.1875!
        Me.txtComponentNumber.Width = 0.4375!
        '
        'txtType
        '
        Me.txtType.DataField = "JT_CODE"
        Me.txtType.Height = 0.1875!
        Me.txtType.Left = 2.5!
        Me.txtType.Name = "txtType"
        Me.txtType.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtType.Text = "type1"
        Me.txtType.Top = 0.5625!
        Me.txtType.Width = 0.6875!
        '
        'txtType_desc
        '
        Me.txtType_desc.DataField = "JT_DESC"
        Me.txtType_desc.Height = 0.1875!
        Me.txtType_desc.Left = 2.5!
        Me.txtType_desc.Name = "txtType_desc"
        Me.txtType_desc.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtType_desc.Text = "txtTypeDesc"
        Me.txtType_desc.Top = 0.75!
        Me.txtType_desc.Width = 1.5625!
        '
        'txtStatus
        '
        Me.txtStatus.DataField = "TRF_DESCRIPTION"
        Me.txtStatus.Height = 0.1875!
        Me.txtStatus.Left = 4.125!
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtStatus.Text = "status"
        Me.txtStatus.Top = 0.5625!
        Me.txtStatus.Width = 0.8125!
        '
        'txtRef
        '
        Me.txtRef.DataField = "JOB_CLI_REF"
        Me.txtRef.Height = 0.1875!
        Me.txtRef.Left = 5.0625!
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtRef.Text = "Reference"
        Me.txtRef.Top = 0.5625!
        Me.txtRef.Width = 0.6875!
        '
        'txtSdate
        '
        Me.txtSdate.DataField = "Start Date"
        Me.txtSdate.Height = 0.1875!
        Me.txtSdate.Left = 5.875!
        Me.txtSdate.Name = "txtSdate"
        Me.txtSdate.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtSdate.Text = Nothing
        Me.txtSdate.Top = 0.5625!
        Me.txtSdate.Width = 0.8125!
        '
        'txtComm
        '
        Me.txtComm.CanShrink = True
        Me.txtComm.DataField = "TRF_COMMENTS"
        Me.txtComm.Height = 0.1875!
        Me.txtComm.Left = 0.0625!
        Me.txtComm.Name = "txtComm"
        Me.txtComm.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtComm.Text = "TextBox1"
        Me.txtComm.Top = 0.375!
        Me.txtComm.Width = 10.875!
        '
        'txtEst
        '
        Me.txtEst.DataField = "ESTIMATE_NUMBER"
        Me.txtEst.Height = 0.1875!
        Me.txtEst.Left = 10.4375!
        Me.txtEst.Name = "txtEst"
        Me.txtEst.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtEst.Text = "est"
        Me.txtEst.Top = 0.5625!
        Me.txtEst.Width = 0.4375!
        '
        'txtEstAprv
        '
        Me.txtEstAprv.DataField = "EJobNum"
        Me.txtEstAprv.Height = 0.1875!
        Me.txtEstAprv.Left = 10.4375!
        Me.txtEstAprv.Name = "txtEstAprv"
        Me.txtEstAprv.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtEstAprv.Text = "estAppr"
        Me.txtEstAprv.Top = 0.75!
        Me.txtEstAprv.Width = 0.4375!
        '
        'txtNTask
        '
        Me.txtNTask.Height = 0.1875!
        Me.txtNTask.Left = 6.8125!
        Me.txtNTask.Name = "txtNTask"
        Me.txtNTask.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtNTask.Text = "TextBox1"
        Me.txtNTask.Top = 0.5625!
        Me.txtNTask.Width = 1.0625!
        '
        'txtND
        '
        Me.txtND.Height = 0.1875!
        Me.txtND.Left = 6.8125!
        Me.txtND.Name = "txtND"
        Me.txtND.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtND.Top = 0.75!
        Me.txtND.Width = 1.0625!
        '
        'txtNComm
        '
        Me.txtNComm.Height = 0.1875!
        Me.txtNComm.Left = 8.0!
        Me.txtNComm.Name = "txtNComm"
        Me.txtNComm.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtNComm.Text = "TextBox1"
        Me.txtNComm.Top = 0.75!
        Me.txtNComm.Width = 2.3125!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.0!
        Me.Line3.Width = 11.0!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 11.0625!
        Me.Line3.Y1 = 1.0!
        Me.Line3.Y2 = 1.0!
        '
        'txtJobNumber
        '
        Me.txtJobNumber.DataField = "JOB_NUMBER"
        Me.txtJobNumber.Height = 0.1875!
        Me.txtJobNumber.Left = 0.0625!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtJobNumber.Text = "txtJobNumber"
        Me.txtJobNumber.Top = 0.0!
        Me.txtJobNumber.Width = 0.5625!
        '
        'txtJobQty
        '
        Me.txtJobQty.CanShrink = True
        Me.txtJobQty.DataField = "JOB_QTY"
        Me.txtJobQty.Height = 0.1875!
        Me.txtJobQty.Left = 1.375!
        Me.txtJobQty.Name = "txtJobQty"
        Me.txtJobQty.OutputFormat = resources.GetString("txtJobQty.OutputFormat")
        Me.txtJobQty.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtJobQty.Text = "txtJobQty"
        Me.txtJobQty.Top = 0.5625!
        Me.txtJobQty.Width = 1.0!
        '
        'TextBox2
        '
        Me.TextBox2.CanShrink = True
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 1.375!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox2.Text = "Job Quantity"
        Me.TextBox2.Top = 0.25!
        Me.TextBox2.Width = 0.9375!
        '
        'txtAccount_Executive1
        '
        Me.txtAccount_Executive1.DataField = "Account Executive"
        Me.txtAccount_Executive1.Height = 0.1875!
        Me.txtAccount_Executive1.Left = 1.4375!
        Me.txtAccount_Executive1.Name = "txtAccount_Executive1"
        Me.txtAccount_Executive1.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtAccount_Executive1.Text = "txtAccount_Executive1"
        Me.txtAccount_Executive1.Top = 0.0!
        Me.txtAccount_Executive1.Width = 1.0!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1, Me.ReportInfo2, Me.lbluser})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1875!
        Me.ReportInfo1.Left = 5.875!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-size: 8.25pt; text-align: right"
        Me.ReportInfo1.Top = 0.0!
        Me.ReportInfo1.Width = 4.6875!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{RunDateTime:}"
        Me.ReportInfo2.Height = 0.1875!
        Me.ReportInfo2.Left = 0.0625!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 8.25pt"
        Me.ReportInfo2.Top = 0.0!
        Me.ReportInfo2.Width = 1.6875!
        '
        'lbluser
        '
        Me.lbluser.Height = 0.1875!
        Me.lbluser.HyperLink = Nothing
        Me.lbluser.Left = 1.75!
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Style = "font-size: 8.25pt"
        Me.lbluser.Tag = " "
        Me.lbluser.Text = " "
        Me.lbluser.Top = 0.0!
        Me.lbluser.Width = 1.0625!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.03125!
        Me.ReportHeader1.Name = "ReportHeader1"
        Me.ReportHeader1.Visible = False
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.25!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.Visible = False
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label8, Me.lbldiv, Me.lblprod, Me.txtClient1, Me.txtDivision1, Me.txtProduct1, Me.Line1, Me.txtCDP, Me.txtProductCode, Me.txtClientCode, Me.txtDivisionCode})
        Me.GroupHeader1.DataField = "CDP"
        Me.GroupHeader1.Height = 0.6458333!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label8
        '
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.0625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.Label8.Text = "Client:"
        Me.Label8.Top = 0.0!
        Me.Label8.Width = 0.6875!
        '
        'lbldiv
        '
        Me.lbldiv.Height = 0.1875!
        Me.lbldiv.HyperLink = Nothing
        Me.lbldiv.Left = 0.0625!
        Me.lbldiv.Name = "lbldiv"
        Me.lbldiv.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lbldiv.Text = "Division:"
        Me.lbldiv.Top = 0.1875!
        Me.lbldiv.Width = 0.6875!
        '
        'lblprod
        '
        Me.lblprod.Height = 0.1875!
        Me.lblprod.HyperLink = Nothing
        Me.lblprod.Left = 0.0625!
        Me.lblprod.Name = "lblprod"
        Me.lblprod.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.lblprod.Text = "Product:"
        Me.lblprod.Top = 0.375!
        Me.lblprod.Width = 0.6875!
        '
        'txtClient1
        '
        Me.txtClient1.DataField = "Client"
        Me.txtClient1.Height = 0.1875!
        Me.txtClient1.Left = 1.1875!
        Me.txtClient1.Name = "txtClient1"
        Me.txtClient1.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtClient1.Text = "txtClient1"
        Me.txtClient1.Top = 0.0!
        Me.txtClient1.Width = 5.8125!
        '
        'txtDivision1
        '
        Me.txtDivision1.DataField = "Division"
        Me.txtDivision1.Height = 0.1875!
        Me.txtDivision1.Left = 1.1875!
        Me.txtDivision1.Name = "txtDivision1"
        Me.txtDivision1.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtDivision1.Text = "txtDivision1"
        Me.txtDivision1.Top = 0.1875!
        Me.txtDivision1.Width = 6.4375!
        '
        'txtProduct1
        '
        Me.txtProduct1.DataField = "Product"
        Me.txtProduct1.Height = 0.1875!
        Me.txtProduct1.Left = 1.1875!
        Me.txtProduct1.Name = "txtProduct1"
        Me.txtProduct1.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtProduct1.Text = "txtProduct1"
        Me.txtProduct1.Top = 0.375!
        Me.txtProduct1.Width = 5.8125!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.625!
        Me.Line1.Width = 11.0625!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 11.0625!
        Me.Line1.Y1 = 0.625!
        Me.Line1.Y2 = 0.625!
        '
        'txtCDP
        '
        Me.txtCDP.DataField = "CDP"
        Me.txtCDP.Height = 0.1875!
        Me.txtCDP.Left = 7.3125!
        Me.txtCDP.Name = "txtCDP"
        Me.txtCDP.Style = "font-size: 9.75pt; ddo-char-set: 0"
        Me.txtCDP.Text = Nothing
        Me.txtCDP.Top = 0.0!
        Me.txtCDP.Visible = False
        Me.txtCDP.Width = 0.1875!
        '
        'txtProductCode
        '
        Me.txtProductCode.DataField = "PRD_CODE"
        Me.txtProductCode.Height = 0.1875!
        Me.txtProductCode.Left = 0.75!
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtProductCode.Text = "txtProductCode"
        Me.txtProductCode.Top = 0.375!
        Me.txtProductCode.Width = 0.4375!
        '
        'txtClientCode
        '
        Me.txtClientCode.DataField = "CL_CODE"
        Me.txtClientCode.Height = 0.1875!
        Me.txtClientCode.Left = 0.75!
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtClientCode.Text = "txtClientCode"
        Me.txtClientCode.Top = 0.0!
        Me.txtClientCode.Width = 0.4375!
        '
        'txtDivisionCode
        '
        Me.txtDivisionCode.DataField = "DIV_CODE"
        Me.txtDivisionCode.Height = 0.1875!
        Me.txtDivisionCode.Left = 0.75!
        Me.txtDivisionCode.Name = "txtDivisionCode"
        Me.txtDivisionCode.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtDivisionCode.Text = "txtDivisionCode"
        Me.txtDivisionCode.Top = 0.1875!
        Me.txtDivisionCode.Width = 0.4375!
        '
        'Label3
        '
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 8.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.Label3.Text = "Comments"
        Me.Label3.Top = 0.25!
        Me.Label3.Width = 2.0625!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'sum_rep_by_clientDS1
        '
        Me.sum_rep_by_clientDS1.DataSetName = "sum_rep_by_clientDS"
        Me.sum_rep_by_clientDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupHeader2
        '
        Me.GroupHeader2.BackColor = System.Drawing.Color.LightGray
        Me.GroupHeader2.CanShrink = True
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblDueDate, Me.lblType, Me.lblStatus, Me.lblRef, Me.lblSdate, Me.lblEst, Me.lblestaprv, Me.lblNT, Me.lblND, Me.Label3, Me.TextBox2})
        Me.GroupHeader2.Height = 0.4583333!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.1041667!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblae, Me.txtAccount_Executive1})
        Me.GroupHeader3.DataField = "Account Executive"
        Me.GroupHeader3.Height = 0.1666667!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Height = 0.0!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'sum_rep_by_client
        '
        Me.MasterReport = False
        Me.DataMember = "sp_sum_rep_by_client"
        Me.DataSource = Me.sum_rep_by_clientDS1
        Me.PageSettings.Margins.Bottom = 0.25!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.25!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 11.0625!
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
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblestaprv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblND, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblae, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJob1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponent1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDue_Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponentNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtType_desc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstAprv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtND, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNComm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccount_Executive1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbldiv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblprod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClient1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivision1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCDP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivisionCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sum_rep_by_clientDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblDueDate As DataDynamics.ActiveReports.Label
    Friend WithEvents lblae As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents lbldiv As DataDynamics.ActiveReports.Label
    Friend WithEvents lblprod As DataDynamics.ActiveReports.Label
    Friend WithEvents txtClient1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivision1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtJob1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComponent1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAccount_Executive1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDue_Date1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents sum_rep_by_clientDS1 As ActiveReportsAssembly.arptOpenJobsDS
    Friend WithEvents txtCDP As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClientCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivisionCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProductCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComponentNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lbluser As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblType As DataDynamics.ActiveReports.Label
    Friend WithEvents txtType As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtType_desc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblStatus As DataDynamics.ActiveReports.Label
    Friend WithEvents txtStatus As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblRef As DataDynamics.ActiveReports.Label
    Friend WithEvents txtRef As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblSdate As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSdate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComm As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblEst As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEst As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblestaprv As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEstAprv As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblNT As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNTask As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblND As DataDynamics.ActiveReports.Label
    Friend WithEvents txtND As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNComm As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtJobQty As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
End Class
