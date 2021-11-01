<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptTimeSheetPrint 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptTimeSheetPrint))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.lblEmpCode = New DataDynamics.ActiveReports.Label()
        Me.lblDates = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtClient = New DataDynamics.ActiveReports.TextBox()
        Me.txtDivision = New DataDynamics.ActiveReports.TextBox()
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtJob = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobComp = New DataDynamics.ActiveReports.TextBox()
        Me.txtFuncCat = New DataDynamics.ActiveReports.TextBox()
        Me.txtDept = New DataDynamics.ActiveReports.TextBox()
        Me.txtHours = New DataDynamics.ActiveReports.TextBox()
        Me.lblComments = New DataDynamics.ActiveReports.Label()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.lblDateText = New DataDynamics.ActiveReports.Label()
        Me.lblDate = New DataDynamics.ActiveReports.Label()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.EmpSigPic = New DataDynamics.ActiveReports.Picture()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.LabelDate = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.lblGrandTotal = New DataDynamics.ActiveReports.Label()
        Me.txtGrandTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalHours = New DataDynamics.ActiveReports.TextBox()
        Me.lblTotal = New DataDynamics.ActiveReports.Label()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextboxClient = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxDivision = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxProduct = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxJob = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxJobComp = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxFuncCat = New DataDynamics.ActiveReports.TextBox()
        CType(Me.lblEmpCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFuncCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDateText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextboxClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxJobComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxFuncCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblEmpCode, Me.lblDates, Me.Line1, Me.Line3})
        Me.PageHeader1.Height = 0.3333333!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblEmpCode
        '
        Me.lblEmpCode.Height = 0.1875!
        Me.lblEmpCode.HyperLink = Nothing
        Me.lblEmpCode.Left = 0.0625!
        Me.lblEmpCode.Name = "lblEmpCode"
        Me.lblEmpCode.Style = "font-size: 12pt; font-weight: bold; ddo-char-set: 0"
        Me.lblEmpCode.Text = ""
        Me.lblEmpCode.Top = 0.0625!
        Me.lblEmpCode.Width = 3.8125!
        '
        'lblDates
        '
        Me.lblDates.Height = 0.1875!
        Me.lblDates.HyperLink = Nothing
        Me.lblDates.Left = 4.0625!
        Me.lblDates.Name = "lblDates"
        Me.lblDates.Style = "font-size: 12pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.lblDates.Text = ""
        Me.lblDates.Top = 0.0625!
        Me.lblDates.Width = 4.375!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 8.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 8.4375!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.0!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.3125!
        Me.Line3.Width = 8.375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 8.4375!
        Me.Line3.Y1 = 0.3125!
        Me.Line3.Y2 = 0.3125!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtComments, Me.txtClient, Me.txtDivision, Me.txtProduct, Me.txtJob, Me.txtJobComp, Me.txtFuncCat, Me.txtDept, Me.txtHours, Me.lblComments, Me.Line6})
        Me.Detail1.Height = 0.4791667!
        Me.Detail1.Name = "Detail1"
        '
        'txtComments
        '
        Me.txtComments.DataField = "COMMENTS"
        Me.txtComments.Height = 0.1875!
        Me.txtComments.Left = 1.0625!
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtComments.Text = "txtComments"
        Me.txtComments.Top = 0.1875!
        Me.txtComments.Width = 6.0625!
        '
        'txtClient
        '
        Me.txtClient.DataField = "CL_CODE"
        Me.txtClient.Height = 0.1875!
        Me.txtClient.Left = 0.0625!
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.txtClient.Text = "txtClient"
        Me.txtClient.Top = 0.0!
        Me.txtClient.Width = 0.5625!
        '
        'txtDivision
        '
        Me.txtDivision.DataField = "DIV_CODE"
        Me.txtDivision.Height = 0.1875!
        Me.txtDivision.Left = 0.6875!
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.txtDivision.Text = "txtDivision"
        Me.txtDivision.Top = 0.0!
        Me.txtDivision.Width = 0.625!
        '
        'txtProduct
        '
        Me.txtProduct.DataField = "PRD_CODE"
        Me.txtProduct.Height = 0.1875!
        Me.txtProduct.Left = 1.375!
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.txtProduct.Text = "txtProduct"
        Me.txtProduct.Top = 0.0!
        Me.txtProduct.Width = 0.5625!
        '
        'txtJob
        '
        Me.txtJob.DataField = "JOB_DESC"
        Me.txtJob.Height = 0.1875!
        Me.txtJob.Left = 2.0!
        Me.txtJob.Name = "txtJob"
        Me.txtJob.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.txtJob.Text = "txtJob"
        Me.txtJob.Top = 0.0!
        Me.txtJob.Width = 1.6875!
        '
        'txtJobComp
        '
        Me.txtJobComp.DataField = "JOB_COMP_DESC"
        Me.txtJobComp.Height = 0.1875!
        Me.txtJobComp.Left = 3.75!
        Me.txtJobComp.Name = "txtJobComp"
        Me.txtJobComp.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.txtJobComp.Text = "txtJobComp"
        Me.txtJobComp.Top = 0.0!
        Me.txtJobComp.Width = 2.375!
        '
        'txtFuncCat
        '
        Me.txtFuncCat.DataField = "FNC_CAT"
        Me.txtFuncCat.Height = 0.1875!
        Me.txtFuncCat.Left = 6.1875!
        Me.txtFuncCat.Name = "txtFuncCat"
        Me.txtFuncCat.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.txtFuncCat.Text = "txtFuncCat"
        Me.txtFuncCat.Top = 0.0!
        Me.txtFuncCat.Width = 1.0!
        '
        'txtDept
        '
        Me.txtDept.DataField = "DP_TM_CODE"
        Me.txtDept.Height = 0.1875!
        Me.txtDept.Left = 7.25!
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.txtDept.Text = "txtDept"
        Me.txtDept.Top = 0.0!
        Me.txtDept.Width = 0.5!
        '
        'txtHours
        '
        Me.txtHours.DataField = "EMP_HOURS"
        Me.txtHours.Height = 0.1875!
        Me.txtHours.Left = 7.8125!
        Me.txtHours.Name = "txtHours"
        Me.txtHours.OutputFormat = resources.GetString("txtHours.OutputFormat")
        Me.txtHours.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.txtHours.Text = "txtHours"
        Me.txtHours.Top = 0.0!
        Me.txtHours.Width = 0.6875!
        '
        'lblComments
        '
        Me.lblComments.Height = 0.1875!
        Me.lblComments.HyperLink = Nothing
        Me.lblComments.Left = 0.1875!
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.lblComments.Text = "Comments:  "
        Me.lblComments.Top = 0.1875!
        Me.lblComments.Width = 0.8125!
        '
        'Line6
        '
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 0.0625!
        Me.Line6.LineColor = System.Drawing.Color.Gray
        Me.Line6.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.4375!
        Me.Line6.Width = 8.375!
        Me.Line6.X1 = 0.0625!
        Me.Line6.X2 = 8.4375!
        Me.Line6.Y1 = 0.4375!
        Me.Line6.Y2 = 0.4375!
        '
        'Label6
        '
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 7.25!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.Label6.Text = "Dept"
        Me.Label6.Top = 0.1875!
        Me.Label6.Width = 0.5!
        '
        'Label8
        '
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 7.8125!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.Label8.Text = "Hours"
        Me.Label8.Top = 0.1875!
        Me.Label8.Width = 0.6875!
        '
        'lblDateText
        '
        Me.lblDateText.Height = 0.1875!
        Me.lblDateText.HyperLink = Nothing
        Me.lblDateText.Left = 0.0625!
        Me.lblDateText.Name = "lblDateText"
        Me.lblDateText.Style = "font-size: 9pt; font-weight: bold; text-decoration: underline; ddo-char-set: 0"
        Me.lblDateText.Text = "Date:"
        Me.lblDateText.Top = 0.0!
        Me.lblDateText.Width = 0.4375!
        '
        'lblDate
        '
        Me.lblDate.DataField = "EMP_DATE"
        Me.lblDate.Height = 0.1875!
        Me.lblDate.HyperLink = Nothing
        Me.lblDate.Left = 0.5!
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.lblDate.Text = ""
        Me.lblDate.Top = 0.0!
        Me.lblDate.Width = 1.1875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.2604167!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Height = 0.25!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.Visible = False
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label10, Me.Line2, Me.Line4, Me.Label11, Me.Label12, Me.EmpSigPic, Me.Label9, Me.LabelDate})
        Me.GroupFooter1.Height = 1.510417!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label10
        '
        Me.Label10.Height = 0.375!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.5!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.Label10.Text = "I have reviewed and approved this timesheet for accuracy and reasonableness."
        Me.Label10.Top = 0.0!
        Me.Label10.Width = 3.5!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.062!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.25!
        Me.Line2.Width = 3.5!
        Me.Line2.X1 = 0.062!
        Me.Line2.X2 = 3.562!
        Me.Line2.Y1 = 1.25!
        Me.Line2.Y2 = 1.25!
        '
        'Line4
        '
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 4.4995!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 1.25!
        Me.Line4.Width = 3.5!
        Me.Line4.X1 = 4.4995!
        Me.Line4.X2 = 7.9995!
        Me.Line4.Y1 = 1.25!
        Me.Line4.Y2 = 1.25!
        '
        'Label11
        '
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.062!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.Label11.Text = "Employee Signature / Date"
        Me.Label11.Top = 1.305!
        Me.Label11.Width = 1.8125!
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 4.4995!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.Label12.Text = "Supervisor Signature / Date"
        Me.Label12.Top = 1.31!
        Me.Label12.Width = 1.8125!
        '
        'EmpSigPic
        '
        Me.EmpSigPic.Height = 0.75!
        Me.EmpSigPic.HyperLink = Nothing
        Me.EmpSigPic.ImageData = Nothing
        Me.EmpSigPic.Left = 0.0614998!
        Me.EmpSigPic.Name = "EmpSigPic"
        Me.EmpSigPic.Top = 0.432!
        Me.EmpSigPic.Width = 2.75!
        '
        'Label9
        '
        Me.Label9.Height = 0.375!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0625!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.Label9.Text = "I certify that the time posted on the date(s) listed is accurate and complete."
        Me.Label9.Top = 0.0!
        Me.Label9.Width = 3.4375!
        '
        'LabelDate
        '
        Me.LabelDate.Height = 0.1875!
        Me.LabelDate.HyperLink = Nothing
        Me.LabelDate.Left = 2.8745!
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.LabelDate.Text = ""
        Me.LabelDate.Top = 0.995!
        Me.LabelDate.Width = 0.6870003!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Height = 0.1041667!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.Visible = False
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblGrandTotal, Me.txtGrandTotal})
        Me.GroupFooter2.Height = 0.28125!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.Height = 0.1875!
        Me.lblGrandTotal.HyperLink = Nothing
        Me.lblGrandTotal.Left = 5.0!
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.lblGrandTotal.Text = "lblGrandTotal"
        Me.lblGrandTotal.Top = 0.0625!
        Me.lblGrandTotal.Width = 2.75!
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.DataField = "EMP_HOURS"
        Me.txtGrandTotal.Height = 0.1875!
        Me.txtGrandTotal.Left = 7.8125!
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.OutputFormat = resources.GetString("txtGrandTotal.OutputFormat")
        Me.txtGrandTotal.Style = "font-size: 9pt; text-align: center; ddo-char-set: 0"
        Me.txtGrandTotal.SummaryGroup = "GroupHeader2"
        Me.txtGrandTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtGrandTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtGrandTotal.Text = "txtGrandTotal"
        Me.txtGrandTotal.Top = 0.0625!
        Me.txtGrandTotal.Width = 0.6875!
        '
        'txtTotalHours
        '
        Me.txtTotalHours.DataField = "EMP_HOURS"
        Me.txtTotalHours.Height = 0.1875!
        Me.txtTotalHours.Left = 7.8125!
        Me.txtTotalHours.Name = "txtTotalHours"
        Me.txtTotalHours.OutputFormat = resources.GetString("txtTotalHours.OutputFormat")
        Me.txtTotalHours.Style = "font-size: 9pt; text-align: center; ddo-char-set: 0"
        Me.txtTotalHours.SummaryGroup = "GroupHeader3"
        Me.txtTotalHours.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalHours.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTotalHours.Text = "txtTotalHours"
        Me.txtTotalHours.Top = 0.0!
        Me.txtTotalHours.Width = 0.6875!
        '
        'lblTotal
        '
        Me.lblTotal.Height = 0.1875!
        Me.lblTotal.HyperLink = Nothing
        Me.lblTotal.Left = 5.0!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.lblTotal.Text = "lblTotal"
        Me.lblTotal.Top = 0.0!
        Me.lblTotal.Width = 2.75!
        '
        'Line5
        '
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.125!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.25!
        Me.Line5.Width = 8.375!
        Me.Line5.X1 = 0.125!
        Me.Line5.X2 = 8.5!
        Me.Line5.Y1 = 0.25!
        Me.Line5.Y2 = 0.25!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblDateText, Me.lblDate, Me.Label6, Me.Label8, Me.TextboxClient, Me.TextBoxDivision, Me.TextBoxProduct, Me.TextBoxJob, Me.TextBoxJobComp, Me.TextBoxFuncCat})
        Me.GroupHeader3.DataField = "EMP_DATE"
        Me.GroupHeader3.Height = 0.387!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalHours, Me.lblTotal, Me.Line5})
        Me.GroupFooter3.Height = 0.2604167!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'TextboxClient
        '
        Me.TextboxClient.CanShrink = True
        Me.TextboxClient.Height = 0.2!
        Me.TextboxClient.Left = 0.0619998!
        Me.TextboxClient.Name = "TextboxClient"
        Me.TextboxClient.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.TextboxClient.Text = "Client"
        Me.TextboxClient.Top = 0.187!
        Me.TextboxClient.Width = 0.5620003!
        '
        'TextBoxDivision
        '
        Me.TextBoxDivision.CanShrink = True
        Me.TextBoxDivision.Height = 0.2!
        Me.TextBoxDivision.Left = 0.687!
        Me.TextBoxDivision.Name = "TextBoxDivision"
        Me.TextBoxDivision.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.TextBoxDivision.Text = "Division"
        Me.TextBoxDivision.Top = 0.187!
        Me.TextBoxDivision.Width = 0.625!
        '
        'TextBoxProduct
        '
        Me.TextBoxProduct.CanShrink = True
        Me.TextBoxProduct.Height = 0.2!
        Me.TextBoxProduct.Left = 1.375!
        Me.TextBoxProduct.Name = "TextBoxProduct"
        Me.TextBoxProduct.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.TextBoxProduct.Text = "Product"
        Me.TextBoxProduct.Top = 0.187!
        Me.TextBoxProduct.Width = 0.562!
        '
        'TextBoxJob
        '
        Me.TextBoxJob.CanShrink = True
        Me.TextBoxJob.Height = 0.2!
        Me.TextBoxJob.Left = 2.0!
        Me.TextBoxJob.Name = "TextBoxJob"
        Me.TextBoxJob.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.TextBoxJob.Text = "Job"
        Me.TextBoxJob.Top = 0.187!
        Me.TextBoxJob.Width = 1.687!
        '
        'TextBoxJobComp
        '
        Me.TextBoxJobComp.CanShrink = True
        Me.TextBoxJobComp.Height = 0.2!
        Me.TextBoxJobComp.Left = 3.75!
        Me.TextBoxJobComp.Name = "TextBoxJobComp"
        Me.TextBoxJobComp.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.TextBoxJobComp.Text = "Job Comp"
        Me.TextBoxJobComp.Top = 0.187!
        Me.TextBoxJobComp.Width = 2.375!
        '
        'TextBoxFuncCat
        '
        Me.TextBoxFuncCat.CanShrink = True
        Me.TextBoxFuncCat.Height = 0.2!
        Me.TextBoxFuncCat.Left = 6.187!
        Me.TextBoxFuncCat.Name = "TextBoxFuncCat"
        Me.TextBoxFuncCat.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 0"
        Me.TextBoxFuncCat.Text = "Func/Cat"
        Me.TextBoxFuncCat.Top = 0.187!
        Me.TextBoxFuncCat.Width = 0.9999998!
        '
        'arptTimeSheetPrint
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.1!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.1!
        Me.PageSettings.MirrorMargins = True
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 8.5!
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
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.lblEmpCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFuncCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDateText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextboxClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxJobComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxFuncCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents lblEmpCode As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDates As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDateText As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDate As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJob As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobComp As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFuncCat As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDept As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHours As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtTotalHours As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblGrandTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents txtGrandTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblComments As DataDynamics.ActiveReports.Label
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Private WithEvents EmpSigPic As DataDynamics.ActiveReports.Picture
    Private WithEvents LabelDate As DataDynamics.ActiveReports.Label
    Private WithEvents TextboxClient As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxDivision As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxProduct As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxJob As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxJobComp As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxFuncCat As DataDynamics.ActiveReports.TextBox
End Class
