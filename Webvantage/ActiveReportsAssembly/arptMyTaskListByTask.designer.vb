<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptMyTaskListByTask
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptMyTaskListByTask))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.MyTaskList = New DataDynamics.ActiveReports.Label
        Me.Job = New DataDynamics.ActiveReports.Label
        Me.CompDesc = New DataDynamics.ActiveReports.Label
        Me.Emp = New DataDynamics.ActiveReports.Label
        Me.DueDate = New DataDynamics.ActiveReports.Label
        Me.Comments = New DataDynamics.ActiveReports.Label
        Me.Hours = New DataDynamics.ActiveReports.Label
        Me.Complete = New DataDynamics.ActiveReports.Label
        Me.Client = New DataDynamics.ActiveReports.Label
        Me.Division = New DataDynamics.ActiveReports.Label
        Me.Product = New DataDynamics.ActiveReports.Label
        Me.TimeDue = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtJobNum1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCompNum1 = New DataDynamics.ActiveReports.TextBox
        Me.txtEmp_Assign1 = New DataDynamics.ActiveReports.TextBox
        Me.txtRev_Due_Date1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCompleted_Date1 = New DataDynamics.ActiveReports.TextBox
        Me.txtComments1 = New DataDynamics.ActiveReports.TextBox
        Me.txtHoursAllowed1 = New DataDynamics.ActiveReports.TextBox
        Me.txtJobDesc1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCompDesc1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCName1 = New DataDynamics.ActiveReports.TextBox
        Me.txtDName1 = New DataDynamics.ActiveReports.TextBox
        Me.txtPName1 = New DataDynamics.ActiveReports.TextBox
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtTimeDue = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.lbluser = New DataDynamics.ActiveReports.Label
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.txtRev_Due_Date2 = New DataDynamics.ActiveReports.TextBox
        Me.txtTask1 = New DataDynamics.ActiveReports.TextBox
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.txtsumHours2 = New DataDynamics.ActiveReports.TextBox
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.ArptTaskDS1 = New ActiveReportsAssembly.arptTaskDS
        Me.sumHours = New DataDynamics.ActiveReports.Field
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.MyTaskList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Job, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Emp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Comments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Hours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Complete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Client, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Division, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Product, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNum1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompNum1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmp_Assign1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRev_Due_Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompleted_Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHoursAllowed1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompDesc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimeDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRev_Due_Date2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsumHours2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArptTaskDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.MyTaskList})
        Me.PageHeader1.Height = 0.3020833!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'MyTaskList
        '
        Me.MyTaskList.Border.BottomColor = System.Drawing.Color.Black
        Me.MyTaskList.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MyTaskList.Border.LeftColor = System.Drawing.Color.Black
        Me.MyTaskList.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MyTaskList.Border.RightColor = System.Drawing.Color.Black
        Me.MyTaskList.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MyTaskList.Border.TopColor = System.Drawing.Color.Black
        Me.MyTaskList.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MyTaskList.Height = 0.25!
        Me.MyTaskList.HyperLink = Nothing
        Me.MyTaskList.Left = 0.0625!
        Me.MyTaskList.Name = "MyTaskList"
        Me.MyTaskList.Style = "font-weight: bold; font-size: 14.25pt; "
        Me.MyTaskList.Text = "Task List"
        Me.MyTaskList.Top = 0.0!
        Me.MyTaskList.Width = 8.875!
        '
        'Job
        '
        Me.Job.Border.BottomColor = System.Drawing.Color.Black
        Me.Job.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Job.Border.LeftColor = System.Drawing.Color.Black
        Me.Job.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Job.Border.RightColor = System.Drawing.Color.Black
        Me.Job.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Job.Border.TopColor = System.Drawing.Color.Black
        Me.Job.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Job.Height = 0.1875!
        Me.Job.HyperLink = Nothing
        Me.Job.Left = 3.25!
        Me.Job.Name = "Job"
        Me.Job.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Job.Text = "Job"
        Me.Job.Top = 0.0!
        Me.Job.Width = 0.625!
        '
        'CompDesc
        '
        Me.CompDesc.Border.BottomColor = System.Drawing.Color.Black
        Me.CompDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompDesc.Border.LeftColor = System.Drawing.Color.Black
        Me.CompDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompDesc.Border.RightColor = System.Drawing.Color.Black
        Me.CompDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompDesc.Border.TopColor = System.Drawing.Color.Black
        Me.CompDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CompDesc.Height = 0.1875!
        Me.CompDesc.HyperLink = Nothing
        Me.CompDesc.Left = 4.25!
        Me.CompDesc.Name = "CompDesc"
        Me.CompDesc.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.CompDesc.Text = "Comp Desc"
        Me.CompDesc.Top = 0.0!
        Me.CompDesc.Width = 1.0!
        '
        'Emp
        '
        Me.Emp.Border.BottomColor = System.Drawing.Color.Black
        Me.Emp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Emp.Border.LeftColor = System.Drawing.Color.Black
        Me.Emp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Emp.Border.RightColor = System.Drawing.Color.Black
        Me.Emp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Emp.Border.TopColor = System.Drawing.Color.Black
        Me.Emp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Emp.Height = 0.1875!
        Me.Emp.HyperLink = Nothing
        Me.Emp.Left = 5.25!
        Me.Emp.Name = "Emp"
        Me.Emp.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Emp.Text = "Employee"
        Me.Emp.Top = 0.0!
        Me.Emp.Width = 0.6875!
        '
        'DueDate
        '
        Me.DueDate.Border.BottomColor = System.Drawing.Color.Black
        Me.DueDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DueDate.Border.LeftColor = System.Drawing.Color.Black
        Me.DueDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DueDate.Border.RightColor = System.Drawing.Color.Black
        Me.DueDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DueDate.Border.TopColor = System.Drawing.Color.Black
        Me.DueDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.DueDate.Height = 0.1875!
        Me.DueDate.HyperLink = Nothing
        Me.DueDate.Left = 6.1875!
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.DueDate.Text = "Due Date"
        Me.DueDate.Top = 0.0!
        Me.DueDate.Width = 0.625!
        '
        'Comments
        '
        Me.Comments.Border.BottomColor = System.Drawing.Color.Black
        Me.Comments.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Comments.Border.LeftColor = System.Drawing.Color.Black
        Me.Comments.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Comments.Border.RightColor = System.Drawing.Color.Black
        Me.Comments.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Comments.Border.TopColor = System.Drawing.Color.Black
        Me.Comments.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Comments.Height = 0.1875!
        Me.Comments.HyperLink = Nothing
        Me.Comments.Left = 8.5!
        Me.Comments.Name = "Comments"
        Me.Comments.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Comments.Text = "Comments"
        Me.Comments.Top = 0.0!
        Me.Comments.Width = 0.9375!
        '
        'Hours
        '
        Me.Hours.Border.BottomColor = System.Drawing.Color.Black
        Me.Hours.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Hours.Border.LeftColor = System.Drawing.Color.Black
        Me.Hours.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Hours.Border.RightColor = System.Drawing.Color.Black
        Me.Hours.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Hours.Border.TopColor = System.Drawing.Color.Black
        Me.Hours.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Hours.Height = 0.1875!
        Me.Hours.HyperLink = Nothing
        Me.Hours.Left = 9.875!
        Me.Hours.Name = "Hours"
        Me.Hours.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Hours.Text = "Hours"
        Me.Hours.Top = 0.0!
        Me.Hours.Width = 0.5!
        '
        'Complete
        '
        Me.Complete.Border.BottomColor = System.Drawing.Color.Black
        Me.Complete.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Complete.Border.LeftColor = System.Drawing.Color.Black
        Me.Complete.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Complete.Border.RightColor = System.Drawing.Color.Black
        Me.Complete.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Complete.Border.TopColor = System.Drawing.Color.Black
        Me.Complete.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Complete.Height = 0.1875!
        Me.Complete.HyperLink = Nothing
        Me.Complete.Left = 7.5!
        Me.Complete.Name = "Complete"
        Me.Complete.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Complete.Text = "Completed"
        Me.Complete.Top = 0.0!
        Me.Complete.Width = 0.75!
        '
        'Client
        '
        Me.Client.Border.BottomColor = System.Drawing.Color.Black
        Me.Client.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Client.Border.LeftColor = System.Drawing.Color.Black
        Me.Client.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Client.Border.RightColor = System.Drawing.Color.Black
        Me.Client.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Client.Border.TopColor = System.Drawing.Color.Black
        Me.Client.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Client.Height = 0.1875!
        Me.Client.HyperLink = Nothing
        Me.Client.Left = 0.0!
        Me.Client.Name = "Client"
        Me.Client.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Client.Text = "Client"
        Me.Client.Top = 0.0!
        Me.Client.Width = 1.3125!
        '
        'Division
        '
        Me.Division.Border.BottomColor = System.Drawing.Color.Black
        Me.Division.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Division.Border.LeftColor = System.Drawing.Color.Black
        Me.Division.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Division.Border.RightColor = System.Drawing.Color.Black
        Me.Division.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Division.Border.TopColor = System.Drawing.Color.Black
        Me.Division.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Division.Height = 0.1875!
        Me.Division.HyperLink = Nothing
        Me.Division.Left = 1.25!
        Me.Division.Name = "Division"
        Me.Division.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Division.Text = "Division"
        Me.Division.Top = 0.0!
        Me.Division.Width = 1.1875!
        '
        'Product
        '
        Me.Product.Border.BottomColor = System.Drawing.Color.Black
        Me.Product.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Product.Border.LeftColor = System.Drawing.Color.Black
        Me.Product.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Product.Border.RightColor = System.Drawing.Color.Black
        Me.Product.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Product.Border.TopColor = System.Drawing.Color.Black
        Me.Product.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Product.Height = 0.1875!
        Me.Product.HyperLink = Nothing
        Me.Product.Left = 2.375!
        Me.Product.Name = "Product"
        Me.Product.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Product.Text = "Product"
        Me.Product.Top = 0.0!
        Me.Product.Width = 1.125!
        '
        'TimeDue
        '
        Me.TimeDue.Border.BottomColor = System.Drawing.Color.Black
        Me.TimeDue.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TimeDue.Border.LeftColor = System.Drawing.Color.Black
        Me.TimeDue.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TimeDue.Border.RightColor = System.Drawing.Color.Black
        Me.TimeDue.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TimeDue.Border.TopColor = System.Drawing.Color.Black
        Me.TimeDue.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TimeDue.Height = 0.1875!
        Me.TimeDue.HyperLink = Nothing
        Me.TimeDue.Left = 6.75!
        Me.TimeDue.Name = "TimeDue"
        Me.TimeDue.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.TimeDue.Text = "Time Due"
        Me.TimeDue.Top = 0.0!
        Me.TimeDue.Width = 0.6875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtJobNum1, Me.txtCompNum1, Me.txtEmp_Assign1, Me.txtRev_Due_Date1, Me.txtCompleted_Date1, Me.txtComments1, Me.txtHoursAllowed1, Me.txtJobDesc1, Me.txtCompDesc1, Me.txtCName1, Me.txtDName1, Me.txtPName1, Me.Line2, Me.Label1, Me.txtTimeDue})
        Me.Detail1.Height = 0.2!
        Me.Detail1.Name = "Detail1"
        '
        'txtJobNum1
        '
        Me.txtJobNum1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobNum1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobNum1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobNum1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobNum1.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobNum1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobNum1.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobNum1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobNum1.DataField = "JobNum"
        Me.txtJobNum1.Height = 0.1875!
        Me.txtJobNum1.Left = 3.3125!
        Me.txtJobNum1.Name = "txtJobNum1"
        Me.txtJobNum1.Style = "font-size: 8.25pt; "
        Me.txtJobNum1.Text = "txtJobNum1"
        Me.txtJobNum1.Top = 0.0!
        Me.txtJobNum1.Width = 0.9!
        '
        'txtCompNum1
        '
        Me.txtCompNum1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCompNum1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompNum1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCompNum1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompNum1.Border.RightColor = System.Drawing.Color.Black
        Me.txtCompNum1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompNum1.Border.TopColor = System.Drawing.Color.Black
        Me.txtCompNum1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompNum1.DataField = "CompNum"
        Me.txtCompNum1.Height = 0.1875!
        Me.txtCompNum1.Left = 4.25!
        Me.txtCompNum1.Name = "txtCompNum1"
        Me.txtCompNum1.Style = "font-size: 8.25pt; "
        Me.txtCompNum1.Text = "txtCompNum1"
        Me.txtCompNum1.Top = 0.0!
        Me.txtCompNum1.Width = 0.9!
        '
        'txtEmp_Assign1
        '
        Me.txtEmp_Assign1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtEmp_Assign1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEmp_Assign1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtEmp_Assign1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEmp_Assign1.Border.RightColor = System.Drawing.Color.Black
        Me.txtEmp_Assign1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEmp_Assign1.Border.TopColor = System.Drawing.Color.Black
        Me.txtEmp_Assign1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEmp_Assign1.DataField = "Emp"
        Me.txtEmp_Assign1.Height = 0.1875!
        Me.txtEmp_Assign1.Left = 5.25!
        Me.txtEmp_Assign1.Name = "txtEmp_Assign1"
        Me.txtEmp_Assign1.Style = "font-size: 8.25pt; "
        Me.txtEmp_Assign1.Text = "Employee Assigned"
        Me.txtEmp_Assign1.Top = 0.0!
        Me.txtEmp_Assign1.Width = 0.8125!
        '
        'txtRev_Due_Date1
        '
        Me.txtRev_Due_Date1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtRev_Due_Date1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtRev_Due_Date1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtRev_Due_Date1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtRev_Due_Date1.Border.RightColor = System.Drawing.Color.Black
        Me.txtRev_Due_Date1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtRev_Due_Date1.Border.TopColor = System.Drawing.Color.Black
        Me.txtRev_Due_Date1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtRev_Due_Date1.DataField = "Rev Due Date"
        Me.txtRev_Due_Date1.Height = 0.1875!
        Me.txtRev_Due_Date1.Left = 6.125!
        Me.txtRev_Due_Date1.Name = "txtRev_Due_Date1"
        Me.txtRev_Due_Date1.Style = "text-align: right; font-size: 8.25pt; "
        Me.txtRev_Due_Date1.Text = "txtRev_Due_Date1"
        Me.txtRev_Due_Date1.Top = 0.0!
        Me.txtRev_Due_Date1.Width = 0.6875!
        '
        'txtCompleted_Date1
        '
        Me.txtCompleted_Date1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCompleted_Date1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompleted_Date1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCompleted_Date1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompleted_Date1.Border.RightColor = System.Drawing.Color.Black
        Me.txtCompleted_Date1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompleted_Date1.Border.TopColor = System.Drawing.Color.Black
        Me.txtCompleted_Date1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompleted_Date1.DataField = "Completed Date"
        Me.txtCompleted_Date1.Height = 0.1875!
        Me.txtCompleted_Date1.Left = 7.5625!
        Me.txtCompleted_Date1.Name = "txtCompleted_Date1"
        Me.txtCompleted_Date1.Style = "font-size: 8.25pt; "
        Me.txtCompleted_Date1.Text = "txtCompleted_Date1"
        Me.txtCompleted_Date1.Top = 0.0!
        Me.txtCompleted_Date1.Width = 0.8125!
        '
        'txtComments1
        '
        Me.txtComments1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtComments1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComments1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtComments1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComments1.Border.RightColor = System.Drawing.Color.Black
        Me.txtComments1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComments1.Border.TopColor = System.Drawing.Color.Black
        Me.txtComments1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtComments1.DataField = "Comments"
        Me.txtComments1.Height = 0.1875!
        Me.txtComments1.Left = 8.4375!
        Me.txtComments1.Name = "txtComments1"
        Me.txtComments1.Style = "font-size: 8.25pt; "
        Me.txtComments1.Text = "txtComments1"
        Me.txtComments1.Top = 0.0!
        Me.txtComments1.Width = 1.5!
        '
        'txtHoursAllowed1
        '
        Me.txtHoursAllowed1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtHoursAllowed1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHoursAllowed1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtHoursAllowed1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHoursAllowed1.Border.RightColor = System.Drawing.Color.Black
        Me.txtHoursAllowed1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHoursAllowed1.Border.TopColor = System.Drawing.Color.Black
        Me.txtHoursAllowed1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHoursAllowed1.DataField = "HoursAllowed"
        Me.txtHoursAllowed1.Height = 0.1875!
        Me.txtHoursAllowed1.Left = 9.9375!
        Me.txtHoursAllowed1.Name = "txtHoursAllowed1"
        Me.txtHoursAllowed1.Style = "text-align: right; font-size: 8.25pt; "
        Me.txtHoursAllowed1.Text = "txtHoursAllowed1"
        Me.txtHoursAllowed1.Top = 0.0!
        Me.txtHoursAllowed1.Width = 0.5!
        '
        'txtJobDesc1
        '
        Me.txtJobDesc1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJobDesc1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDesc1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJobDesc1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDesc1.Border.RightColor = System.Drawing.Color.Black
        Me.txtJobDesc1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDesc1.Border.TopColor = System.Drawing.Color.Black
        Me.txtJobDesc1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJobDesc1.DataField = "JobDesc"
        Me.txtJobDesc1.Height = 0.1875!
        Me.txtJobDesc1.Left = 0.0625!
        Me.txtJobDesc1.Name = "txtJobDesc1"
        Me.txtJobDesc1.Style = ""
        Me.txtJobDesc1.Text = "txtJobDesc1"
        Me.txtJobDesc1.Top = 0.3125!
        Me.txtJobDesc1.Visible = False
        Me.txtJobDesc1.Width = 0.1875!
        '
        'txtCompDesc1
        '
        Me.txtCompDesc1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCompDesc1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompDesc1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCompDesc1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompDesc1.Border.RightColor = System.Drawing.Color.Black
        Me.txtCompDesc1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompDesc1.Border.TopColor = System.Drawing.Color.Black
        Me.txtCompDesc1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCompDesc1.DataField = "CompDesc"
        Me.txtCompDesc1.Height = 0.1875!
        Me.txtCompDesc1.Left = 0.3125!
        Me.txtCompDesc1.Name = "txtCompDesc1"
        Me.txtCompDesc1.Style = ""
        Me.txtCompDesc1.Text = "txtCompDesc1"
        Me.txtCompDesc1.Top = 0.3125!
        Me.txtCompDesc1.Visible = False
        Me.txtCompDesc1.Width = 0.1875!
        '
        'txtCName1
        '
        Me.txtCName1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCName1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCName1.Border.RightColor = System.Drawing.Color.Black
        Me.txtCName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCName1.Border.TopColor = System.Drawing.Color.Black
        Me.txtCName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCName1.DataField = "CName"
        Me.txtCName1.Height = 0.1875!
        Me.txtCName1.Left = 0.0625!
        Me.txtCName1.Name = "txtCName1"
        Me.txtCName1.Style = "font-size: 8.25pt; "
        Me.txtCName1.Text = "txtCName1"
        Me.txtCName1.Top = 0.0!
        Me.txtCName1.Width = 1.1!
        '
        'txtDName1
        '
        Me.txtDName1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDName1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDName1.Border.RightColor = System.Drawing.Color.Black
        Me.txtDName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDName1.Border.TopColor = System.Drawing.Color.Black
        Me.txtDName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDName1.DataField = "DName"
        Me.txtDName1.Height = 0.1875!
        Me.txtDName1.Left = 1.25!
        Me.txtDName1.Name = "txtDName1"
        Me.txtDName1.Style = "font-size: 8.25pt; "
        Me.txtDName1.Text = "txtDName1"
        Me.txtDName1.Top = 0.0!
        Me.txtDName1.Width = 1.1!
        '
        'txtPName1
        '
        Me.txtPName1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPName1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPName1.Border.RightColor = System.Drawing.Color.Black
        Me.txtPName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPName1.Border.TopColor = System.Drawing.Color.Black
        Me.txtPName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPName1.DataField = "PName"
        Me.txtPName1.Height = 0.1875!
        Me.txtPName1.Left = 2.4375!
        Me.txtPName1.Name = "txtPName1"
        Me.txtPName1.Style = "font-size: 8.25pt; "
        Me.txtPName1.Text = "txtPName1"
        Me.txtPName1.Top = 0.0!
        Me.txtPName1.Width = 0.8125!
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
        Me.Line2.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.1875!
        Me.Line2.Width = 10.375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 10.4375!
        Me.Line2.Y1 = 0.1875!
        Me.Line2.Y2 = 0.1875!
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
        Me.Label1.DataField = "TEMP_COMP"
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 7.375!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = ""
        Me.Label1.Text = ""
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 0.125!
        '
        'txtTimeDue
        '
        Me.txtTimeDue.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTimeDue.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTimeDue.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTimeDue.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTimeDue.Border.RightColor = System.Drawing.Color.Black
        Me.txtTimeDue.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTimeDue.Border.TopColor = System.Drawing.Color.Black
        Me.txtTimeDue.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTimeDue.DataField = "DueTime"
        Me.txtTimeDue.Height = 0.1875!
        Me.txtTimeDue.Left = 6.8125!
        Me.txtTimeDue.Name = "txtTimeDue"
        Me.txtTimeDue.Style = "font-size: 8.25pt; "
        Me.txtTimeDue.Text = "txtTimeDue"
        Me.txtTimeDue.Top = 0.0!
        Me.txtTimeDue.Width = 0.5!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1, Me.lbluser, Me.ReportInfo2})
        Me.PageFooter1.Height = 0.2604167!
        Me.PageFooter1.Name = "PageFooter1"
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
        Me.ReportInfo1.Height = 0.1979167!
        Me.ReportInfo1.Left = 9.4375!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ReportInfo1.Top = 0.0625!
        Me.ReportInfo1.Width = 1.0!
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
        Me.lbluser.Left = 1.6875!
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Style = "font-size: 8pt; "
        Me.lbluser.Tag = " "
        Me.lbluser.Text = " "
        Me.lbluser.Top = 0.0!
        Me.lbluser.Width = 1.0625!
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
        Me.ReportInfo2.Left = 0.0!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 8pt; "
        Me.ReportInfo2.Top = 0.0!
        Me.ReportInfo2.Width = 1.6875!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
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
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtRev_Due_Date2, Me.txtTask1, Me.Line1})
        Me.GroupHeader1.DataField = "Task"
        Me.GroupHeader1.Height = 0.28125!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtRev_Due_Date2
        '
        Me.txtRev_Due_Date2.Border.BottomColor = System.Drawing.Color.Black
        Me.txtRev_Due_Date2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtRev_Due_Date2.Border.LeftColor = System.Drawing.Color.Black
        Me.txtRev_Due_Date2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtRev_Due_Date2.Border.RightColor = System.Drawing.Color.Black
        Me.txtRev_Due_Date2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtRev_Due_Date2.Border.TopColor = System.Drawing.Color.Black
        Me.txtRev_Due_Date2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtRev_Due_Date2.DataField = "Rev Due Date"
        Me.txtRev_Due_Date2.Height = 0.1875!
        Me.txtRev_Due_Date2.Left = 0.0625!
        Me.txtRev_Due_Date2.Name = "txtRev_Due_Date2"
        Me.txtRev_Due_Date2.Style = ""
        Me.txtRev_Due_Date2.Text = "txtRev_Due_Date2"
        Me.txtRev_Due_Date2.Top = 0.375!
        Me.txtRev_Due_Date2.Visible = False
        Me.txtRev_Due_Date2.Width = 0.25!
        '
        'txtTask1
        '
        Me.txtTask1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTask1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTask1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTask1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTask1.Border.RightColor = System.Drawing.Color.Black
        Me.txtTask1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTask1.Border.TopColor = System.Drawing.Color.Black
        Me.txtTask1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTask1.DataField = "Task"
        Me.txtTask1.Height = 0.1875!
        Me.txtTask1.Left = 0.0625!
        Me.txtTask1.Name = "txtTask1"
        Me.txtTask1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtTask1.Text = "txtTask1"
        Me.txtTask1.Top = 0.0625!
        Me.txtTask1.Width = 10.375!
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
        Me.Line1.Top = 0.3125!
        Me.Line1.Width = 10.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 10.4375!
        Me.Line1.Y1 = 0.3125!
        Me.Line1.Y2 = 0.3125!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label11, Me.txtsumHours2, Me.Line3})
        Me.GroupFooter1.Height = 0.2708333!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 7.375!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label11.Text = "Total Hours:"
        Me.Label11.Top = 0.0!
        Me.Label11.Width = 1.9375!
        '
        'txtsumHours2
        '
        Me.txtsumHours2.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsumHours2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours2.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsumHours2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours2.Border.RightColor = System.Drawing.Color.Black
        Me.txtsumHours2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours2.Border.TopColor = System.Drawing.Color.Black
        Me.txtsumHours2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours2.DataField = "HoursAllowed"
        Me.txtsumHours2.Height = 0.2!
        Me.txtsumHours2.Left = 9.4375!
        Me.txtsumHours2.Name = "txtsumHours2"
        Me.txtsumHours2.OutputFormat = resources.GetString("txtsumHours2.OutputFormat")
        Me.txtsumHours2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.txtsumHours2.SummaryGroup = "GroupHeader1"
        Me.txtsumHours2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsumHours2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsumHours2.Text = "txtsumHours2"
        Me.txtsumHours2.Top = 0.0!
        Me.txtsumHours2.Width = 1.0!
        '
        'Line3
        '
        Me.Line3.Border.BottomColor = System.Drawing.Color.Black
        Me.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.LeftColor = System.Drawing.Color.Black
        Me.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.RightColor = System.Drawing.Color.Black
        Me.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.TopColor = System.Drawing.Color.Black
        Me.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.25!
        Me.Line3.Width = 10.375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 10.4375!
        Me.Line3.Y1 = 0.25!
        Me.Line3.Y2 = 0.25!
        '
        'ArptTaskDS1
        '
        Me.ArptTaskDS1.DataSetName = "arptTaskDS"
        Me.ArptTaskDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'sumHours
        '
        Me.sumHours.DefaultValue = Nothing
        Me.sumHours.FieldType = DataDynamics.ActiveReports.FieldTypeEnum.[Double]
        Me.sumHours.Formula = Nothing
        Me.sumHours.Name = "sumHours"
        Me.sumHours.Tag = Nothing
        '
        'GroupHeader2
        '
        Me.GroupHeader2.BackColor = System.Drawing.Color.LightGray
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Client, Me.CompDesc, Me.Emp, Me.DueDate, Me.Comments, Me.Hours, Me.Complete, Me.Job, Me.Division, Me.Product, Me.TimeDue})
        Me.GroupHeader2.Height = 0.1979167!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        Me.GroupFooter2.Visible = False
        '
        'arptMyTaskListByTask
        '
        Me.MasterReport = False
        Me.CalculatedFields.Add(Me.sumHours)
        Me.DataMember = "usp_wv_rpt_TaskList"
        Me.DataSource = Me.ArptTaskDS1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.5!
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
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.MyTaskList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Job, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Emp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Comments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Hours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Complete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Client, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Division, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Product, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNum1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompNum1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmp_Assign1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRev_Due_Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompleted_Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHoursAllowed1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompDesc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimeDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRev_Due_Date2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsumHours2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArptTaskDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Friend WithEvents Job As DataDynamics.ActiveReports.Label
    Friend WithEvents CompDesc As DataDynamics.ActiveReports.Label
    Friend WithEvents Emp As DataDynamics.ActiveReports.Label
    Friend WithEvents DueDate As DataDynamics.ActiveReports.Label
    Friend WithEvents Comments As DataDynamics.ActiveReports.Label
    Friend WithEvents Hours As DataDynamics.ActiveReports.Label
    Friend WithEvents Complete As DataDynamics.ActiveReports.Label
    Friend WithEvents Client As DataDynamics.ActiveReports.Label
    Friend WithEvents Division As DataDynamics.ActiveReports.Label
    Friend WithEvents Product As DataDynamics.ActiveReports.Label
    Friend WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Friend WithEvents txtJobNum1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompNum1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEmp_Assign1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRev_Due_Date1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompleted_Date1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComments1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHoursAllowed1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDesc1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompDesc1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents MyTaskList As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtRev_Due_Date2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtsumHours2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ArptTaskDS1 As ActiveReportsAssembly.arptTaskDS
    Friend WithEvents sumHours As DataDynamics.ActiveReports.Field
    Friend WithEvents txtTask1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents lbluser As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTimeDue As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TimeDue As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
End Class
