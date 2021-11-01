<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptCompletedTask 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptCompletedTask))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.rptTitle = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtTask = New DataDynamics.ActiveReports.TextBox
        Me.txtDueDate = New DataDynamics.ActiveReports.TextBox
        Me.txtCompleted = New DataDynamics.ActiveReports.TextBox
        Me.txtEarlyLate = New DataDynamics.ActiveReports.TextBox
        Me.txtTaskComments = New DataDynamics.ActiveReports.TextBox
        Me.txtJobDueDate = New DataDynamics.ActiveReports.TextBox
        Me.txtJobRevDate = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblClient = New DataDynamics.ActiveReports.TextBox
        Me.lblDivision = New DataDynamics.ActiveReports.TextBox
        Me.lblProduct = New DataDynamics.ActiveReports.TextBox
        Me.txtClient = New DataDynamics.ActiveReports.TextBox
        Me.txtDivision = New DataDynamics.ActiveReports.TextBox
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.txtJobComp = New DataDynamics.ActiveReports.TextBox
        Me.txtComments = New DataDynamics.ActiveReports.TextBox
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox
        Me.txtJobDesc = New DataDynamics.ActiveReports.TextBox
        Me.txtJobCompNumber = New DataDynamics.ActiveReports.TextBox
        Me.txtJobCompDesc = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblTask = New DataDynamics.ActiveReports.TextBox
        Me.lblDueDate = New DataDynamics.ActiveReports.TextBox
        Me.lblCompleted = New DataDynamics.ActiveReports.TextBox
        Me.lblEarly = New DataDynamics.ActiveReports.TextBox
        Me.lblLate = New DataDynamics.ActiveReports.TextBox
        Me.lblTaskComments = New DataDynamics.ActiveReports.TextBox
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo
        Me.lbluser = New DataDynamics.ActiveReports.Label
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        CType(Me.rptTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompleted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEarlyLate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaskComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobRevDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCompleted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEarly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTaskComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'rptTitle
        '
        Me.rptTitle.Border.BottomColor = System.Drawing.Color.Black
        Me.rptTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rptTitle.Border.LeftColor = System.Drawing.Color.Black
        Me.rptTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rptTitle.Border.RightColor = System.Drawing.Color.Black
        Me.rptTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rptTitle.Border.TopColor = System.Drawing.Color.Black
        Me.rptTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rptTitle.Height = 0.25!
        Me.rptTitle.HyperLink = Nothing
        Me.rptTitle.Left = 0.0625!
        Me.rptTitle.Name = "rptTitle"
        Me.rptTitle.Style = "ddo-char-set: 0; font-weight: bold; font-size: 14.25pt; "
        Me.rptTitle.Text = "Completed Task Report"
        Me.rptTitle.Top = 0.0!
        Me.rptTitle.Width = 8.875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTask, Me.txtDueDate, Me.txtCompleted, Me.txtEarlyLate, Me.txtTaskComments, Me.txtJobDueDate, Me.txtJobRevDate})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'txtTask
        '
        Me.txtTask.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTask.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTask.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTask.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTask.Border.RightColor = System.Drawing.Color.Black
        Me.txtTask.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTask.Border.TopColor = System.Drawing.Color.Black
        Me.txtTask.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTask.DataField = "FunctionDesc"
        Me.txtTask.Height = 0.1875!
        Me.txtTask.Left = 0.25!
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtTask.Text = Nothing
        Me.txtTask.Top = 0.0!
        Me.txtTask.Width = 2.5625!
        '
        'txtDueDate
        '
        Me.txtDueDate.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDueDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDueDate.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDueDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDueDate.Border.RightColor = System.Drawing.Color.Black
        Me.txtDueDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDueDate.Border.TopColor = System.Drawing.Color.Black
        Me.txtDueDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDueDate.Height = 0.1875!
        Me.txtDueDate.Left = 2.875!
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDueDate.Text = Nothing
        Me.txtDueDate.Top = 0.0!
        Me.txtDueDate.Width = 1.0625!
        '
        'txtCompleted
        '
        Me.txtCompleted.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCompleted.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompleted.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCompleted.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompleted.Border.RightColor = System.Drawing.Color.Black
        Me.txtCompleted.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompleted.Border.TopColor = System.Drawing.Color.Black
        Me.txtCompleted.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompleted.DataField = "TaskJobCompDate"
        Me.txtCompleted.Height = 0.1875!
        Me.txtCompleted.Left = 4.0!
        Me.txtCompleted.Name = "txtCompleted"
        Me.txtCompleted.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtCompleted.Text = Nothing
        Me.txtCompleted.Top = 0.0!
        Me.txtCompleted.Width = 1.0625!
        '
        'txtEarlyLate
        '
        Me.txtEarlyLate.Border.BottomColor = System.Drawing.Color.Black
        Me.txtEarlyLate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEarlyLate.Border.LeftColor = System.Drawing.Color.Black
        Me.txtEarlyLate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEarlyLate.Border.RightColor = System.Drawing.Color.Black
        Me.txtEarlyLate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEarlyLate.Border.TopColor = System.Drawing.Color.Black
        Me.txtEarlyLate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEarlyLate.Height = 0.1875!
        Me.txtEarlyLate.Left = 5.125!
        Me.txtEarlyLate.Name = "txtEarlyLate"
        Me.txtEarlyLate.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtEarlyLate.Text = Nothing
        Me.txtEarlyLate.Top = 0.0!
        Me.txtEarlyLate.Width = 1.0625!
        '
        'txtTaskComments
        '
        Me.txtTaskComments.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTaskComments.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTaskComments.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTaskComments.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTaskComments.Border.RightColor = System.Drawing.Color.Black
        Me.txtTaskComments.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTaskComments.Border.TopColor = System.Drawing.Color.Black
        Me.txtTaskComments.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTaskComments.DataField = "TaskComment"
        Me.txtTaskComments.Height = 0.1875!
        Me.txtTaskComments.Left = 6.3125!
        Me.txtTaskComments.Name = "txtTaskComments"
        Me.txtTaskComments.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtTaskComments.Text = Nothing
        Me.txtTaskComments.Top = 0.0!
        Me.txtTaskComments.Width = 3.75!
        '
        'txtJobDueDate
        '
        Me.txtJobDueDate.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobDueDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDueDate.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobDueDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDueDate.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobDueDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDueDate.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobDueDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDueDate.DataField = "TaskJobDueDate"
        Me.txtJobDueDate.Height = 0.1875!
        Me.txtJobDueDate.Left = 10.3125!
        Me.txtJobDueDate.Name = "txtJobDueDate"
        Me.txtJobDueDate.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtJobDueDate.Text = Nothing
        Me.txtJobDueDate.Top = 0.0!
        Me.txtJobDueDate.Visible = False
        Me.txtJobDueDate.Width = 0.125!
        '
        'txtJobRevDate
        '
        Me.txtJobRevDate.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobRevDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobRevDate.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobRevDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobRevDate.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobRevDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobRevDate.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobRevDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobRevDate.DataField = "TaskJobRevDate"
        Me.txtJobRevDate.Height = 0.1875!
        Me.txtJobRevDate.Left = 10.125!
        Me.txtJobRevDate.Name = "txtJobRevDate"
        Me.txtJobRevDate.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtJobRevDate.Text = Nothing
        Me.txtJobRevDate.Top = 0.0!
        Me.txtJobRevDate.Visible = False
        Me.txtJobRevDate.Width = 0.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo2, Me.lbluser, Me.ReportInfo1})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.BackColor = System.Drawing.Color.LightGray
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblClient, Me.lblDivision, Me.lblProduct, Me.txtClient, Me.txtDivision, Me.txtProduct})
        Me.GroupHeader1.DataField = "CDP"
        Me.GroupHeader1.Height = 0.1979167!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblClient
        '
        Me.lblClient.Border.BottomColor = System.Drawing.Color.Black
        Me.lblClient.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblClient.Border.LeftColor = System.Drawing.Color.Black
        Me.lblClient.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblClient.Border.RightColor = System.Drawing.Color.Black
        Me.lblClient.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblClient.Border.TopColor = System.Drawing.Color.Black
        Me.lblClient.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblClient.Height = 0.1875!
        Me.lblClient.Left = 0.0625!
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblClient.Text = "Client:"
        Me.lblClient.Top = 0.0!
        Me.lblClient.Width = 0.5!
        '
        'lblDivision
        '
        Me.lblDivision.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDivision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDivision.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDivision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDivision.Border.RightColor = System.Drawing.Color.Black
        Me.lblDivision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDivision.Border.TopColor = System.Drawing.Color.Black
        Me.lblDivision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDivision.Height = 0.1875!
        Me.lblDivision.Left = 3.1875!
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblDivision.Text = "Division:"
        Me.lblDivision.Top = 0.0!
        Me.lblDivision.Width = 0.5625!
        '
        'lblProduct
        '
        Me.lblProduct.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProduct.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProduct.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProduct.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProduct.Border.RightColor = System.Drawing.Color.Black
        Me.lblProduct.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProduct.Border.TopColor = System.Drawing.Color.Black
        Me.lblProduct.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProduct.Height = 0.1875!
        Me.lblProduct.Left = 6.375!
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblProduct.Text = "Product:"
        Me.lblProduct.Top = 0.0!
        Me.lblProduct.Width = 0.5625!
        '
        'txtClient
        '
        Me.txtClient.Border.BottomColor = System.Drawing.Color.Black
        Me.txtClient.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClient.Border.LeftColor = System.Drawing.Color.Black
        Me.txtClient.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClient.Border.RightColor = System.Drawing.Color.Black
        Me.txtClient.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClient.Border.TopColor = System.Drawing.Color.Black
        Me.txtClient.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtClient.DataField = "Client"
        Me.txtClient.Height = 0.1875!
        Me.txtClient.Left = 0.5625!
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtClient.Text = Nothing
        Me.txtClient.Top = 0.0!
        Me.txtClient.Width = 2.5625!
        '
        'txtDivision
        '
        Me.txtDivision.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDivision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivision.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDivision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivision.Border.RightColor = System.Drawing.Color.Black
        Me.txtDivision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivision.Border.TopColor = System.Drawing.Color.Black
        Me.txtDivision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDivision.DataField = "Division"
        Me.txtDivision.Height = 0.1875!
        Me.txtDivision.Left = 3.75!
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDivision.Text = Nothing
        Me.txtDivision.Top = 0.0!
        Me.txtDivision.Width = 2.5625!
        '
        'txtProduct
        '
        Me.txtProduct.Border.BottomColor = System.Drawing.Color.Black
        Me.txtProduct.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProduct.Border.LeftColor = System.Drawing.Color.Black
        Me.txtProduct.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProduct.Border.RightColor = System.Drawing.Color.Black
        Me.txtProduct.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProduct.Border.TopColor = System.Drawing.Color.Black
        Me.txtProduct.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtProduct.DataField = "Product"
        Me.txtProduct.Height = 0.1875!
        Me.txtProduct.Left = 6.9375!
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtProduct.Text = Nothing
        Me.txtProduct.Top = 0.0!
        Me.txtProduct.Width = 2.5625!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'GroupHeader2
        '
        Me.GroupHeader2.CanShrink = True
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.txtJobComp, Me.txtComments, Me.txtJobNumber, Me.txtJobDesc, Me.txtJobCompNumber, Me.txtJobCompDesc})
        Me.GroupHeader2.DataField = "JOBCOMP"
        Me.GroupHeader2.Height = 0.3958333!
        Me.GroupHeader2.Name = "GroupHeader2"
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
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0625!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.TextBox1.Text = "Job/Component:"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.0625!
        '
        'txtJobComp
        '
        Me.txtJobComp.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobComp.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobComp.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobComp.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobComp.Height = 0.1875!
        Me.txtJobComp.Left = 1.125!
        Me.txtJobComp.Name = "txtJobComp"
        Me.txtJobComp.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtJobComp.Text = Nothing
        Me.txtJobComp.Top = 0.0!
        Me.txtJobComp.Width = 7.875!
        '
        'txtComments
        '
        Me.txtComments.Border.BottomColor = System.Drawing.Color.Black
        Me.txtComments.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComments.Border.LeftColor = System.Drawing.Color.Black
        Me.txtComments.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComments.Border.RightColor = System.Drawing.Color.Black
        Me.txtComments.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComments.Border.TopColor = System.Drawing.Color.Black
        Me.txtComments.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComments.CanShrink = True
        Me.txtComments.DataField = "Traffic Comments"
        Me.txtComments.Height = 0.1875!
        Me.txtComments.Left = 1.125!
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtComments.Text = Nothing
        Me.txtComments.Top = 0.1875!
        Me.txtComments.Width = 7.875!
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
        Me.txtJobNumber.DataField = "Job Number"
        Me.txtJobNumber.Height = 0.1875!
        Me.txtJobNumber.Left = 9.125!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtJobNumber.Text = Nothing
        Me.txtJobNumber.Top = 0.0!
        Me.txtJobNumber.Visible = False
        Me.txtJobNumber.Width = 0.125!
        '
        'txtJobDesc
        '
        Me.txtJobDesc.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDesc.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDesc.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDesc.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDesc.DataField = "Job"
        Me.txtJobDesc.Height = 0.1875!
        Me.txtJobDesc.Left = 9.3125!
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtJobDesc.Text = Nothing
        Me.txtJobDesc.Top = 0.0!
        Me.txtJobDesc.Visible = False
        Me.txtJobDesc.Width = 0.125!
        '
        'txtJobCompNumber
        '
        Me.txtJobCompNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobCompNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobCompNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobCompNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobCompNumber.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobCompNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobCompNumber.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobCompNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobCompNumber.DataField = "Comp Number"
        Me.txtJobCompNumber.Height = 0.1875!
        Me.txtJobCompNumber.Left = 9.5!
        Me.txtJobCompNumber.Name = "txtJobCompNumber"
        Me.txtJobCompNumber.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtJobCompNumber.Text = Nothing
        Me.txtJobCompNumber.Top = 0.0!
        Me.txtJobCompNumber.Visible = False
        Me.txtJobCompNumber.Width = 0.125!
        '
        'txtJobCompDesc
        '
        Me.txtJobCompDesc.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobCompDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobCompDesc.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobCompDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobCompDesc.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobCompDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobCompDesc.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobCompDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobCompDesc.DataField = "Component"
        Me.txtJobCompDesc.Height = 0.1875!
        Me.txtJobCompDesc.Left = 9.6875!
        Me.txtJobCompDesc.Name = "txtJobCompDesc"
        Me.txtJobCompDesc.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtJobCompDesc.Text = Nothing
        Me.txtJobCompDesc.Top = 0.0!
        Me.txtJobCompDesc.Visible = False
        Me.txtJobCompDesc.Width = 0.125!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTask, Me.lblDueDate, Me.lblCompleted, Me.lblEarly, Me.lblLate, Me.lblTaskComments, Me.Line1})
        Me.GroupHeader3.Height = 0.3958333!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'lblTask
        '
        Me.lblTask.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTask.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTask.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTask.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTask.Border.RightColor = System.Drawing.Color.Black
        Me.lblTask.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTask.Border.TopColor = System.Drawing.Color.Black
        Me.lblTask.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTask.Height = 0.1875!
        Me.lblTask.Left = 0.25!
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblTask.Text = "Task"
        Me.lblTask.Top = 0.1875!
        Me.lblTask.Width = 2.5625!
        '
        'lblDueDate
        '
        Me.lblDueDate.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDueDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDueDate.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDueDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDueDate.Border.RightColor = System.Drawing.Color.Black
        Me.lblDueDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDueDate.Border.TopColor = System.Drawing.Color.Black
        Me.lblDueDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDueDate.Height = 0.1875!
        Me.lblDueDate.Left = 2.875!
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblDueDate.Text = "Due Date"
        Me.lblDueDate.Top = 0.1875!
        Me.lblDueDate.Width = 1.0625!
        '
        'lblCompleted
        '
        Me.lblCompleted.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCompleted.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCompleted.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCompleted.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCompleted.Border.RightColor = System.Drawing.Color.Black
        Me.lblCompleted.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCompleted.Border.TopColor = System.Drawing.Color.Black
        Me.lblCompleted.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCompleted.Height = 0.1875!
        Me.lblCompleted.Left = 4.0!
        Me.lblCompleted.Name = "lblCompleted"
        Me.lblCompleted.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblCompleted.Text = "Completed"
        Me.lblCompleted.Top = 0.1875!
        Me.lblCompleted.Width = 1.0625!
        '
        'lblEarly
        '
        Me.lblEarly.Border.BottomColor = System.Drawing.Color.Black
        Me.lblEarly.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEarly.Border.LeftColor = System.Drawing.Color.Black
        Me.lblEarly.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEarly.Border.RightColor = System.Drawing.Color.Black
        Me.lblEarly.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEarly.Border.TopColor = System.Drawing.Color.Black
        Me.lblEarly.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEarly.Height = 0.1875!
        Me.lblEarly.Left = 5.125!
        Me.lblEarly.Name = "lblEarly"
        Me.lblEarly.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblEarly.Text = "Early (-)"
        Me.lblEarly.Top = 0.0!
        Me.lblEarly.Width = 1.0625!
        '
        'lblLate
        '
        Me.lblLate.Border.BottomColor = System.Drawing.Color.Black
        Me.lblLate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblLate.Border.LeftColor = System.Drawing.Color.Black
        Me.lblLate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblLate.Border.RightColor = System.Drawing.Color.Black
        Me.lblLate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblLate.Border.TopColor = System.Drawing.Color.Black
        Me.lblLate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblLate.Height = 0.1875!
        Me.lblLate.Left = 5.125!
        Me.lblLate.Name = "lblLate"
        Me.lblLate.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblLate.Text = "Late (+)"
        Me.lblLate.Top = 0.1875!
        Me.lblLate.Width = 1.0625!
        '
        'lblTaskComments
        '
        Me.lblTaskComments.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTaskComments.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTaskComments.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTaskComments.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTaskComments.Border.RightColor = System.Drawing.Color.Black
        Me.lblTaskComments.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTaskComments.Border.TopColor = System.Drawing.Color.Black
        Me.lblTaskComments.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTaskComments.Height = 0.1875!
        Me.lblTaskComments.Left = 6.3125!
        Me.lblTaskComments.Name = "lblTaskComments"
        Me.lblTaskComments.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.lblTaskComments.Text = "Task Comments"
        Me.lblTaskComments.Top = 0.1875!
        Me.lblTaskComments.Width = 3.75!
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
        Me.Line1.Left = 0.25!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.375!
        Me.Line1.Width = 10.1875!
        Me.Line1.X1 = 0.25!
        Me.Line1.X2 = 10.4375!
        Me.Line1.Y1 = 0.375!
        Me.Line1.Y2 = 0.375!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Height = 0.07291666!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.rptTitle, Me.Line2})
        Me.ReportHeader1.Height = 0.2916667!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
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
        Me.Line2.Top = 0.25!
        Me.Line2.Width = 10.375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 10.4375!
        Me.Line2.Y1 = 0.25!
        Me.Line2.Y2 = 0.25!
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
        Me.ReportInfo2.Left = 0.0625!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 8pt; "
        Me.ReportInfo2.Top = 0.0625!
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
        Me.lbluser.Top = 0.0625!
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
        Me.ReportInfo1.Left = 9.4375!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ReportInfo1.Top = 0.0625!
        Me.ReportInfo1.Width = 1.0!
        '
        'arptCompletedTask
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.MirrorMargins = True
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.5!
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
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.rptTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompleted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEarlyLate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaskComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobRevDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCompleted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEarly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTaskComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents rptTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents lblClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDivision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobComp As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblTask As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDueDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCompleted As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblEarly As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblLate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTaskComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTask As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDueDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompleted As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEarlyLate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaskComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDueDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobRevDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lbluser As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
End Class 
