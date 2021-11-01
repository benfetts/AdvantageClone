<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptMyTaskList
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptMyTaskList))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.MyTaskList = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Task = New DataDynamics.ActiveReports.Label
        Me.Job = New DataDynamics.ActiveReports.Label
        Me.CompDesc = New DataDynamics.ActiveReports.Label
        Me.Emp = New DataDynamics.ActiveReports.Label
        Me.DueDate = New DataDynamics.ActiveReports.Label
        Me.Comments = New DataDynamics.ActiveReports.Label
        Me.Hours = New DataDynamics.ActiveReports.Label
        Me.Completed = New DataDynamics.ActiveReports.Label
        Me.TimeDue = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtTask1 = New DataDynamics.ActiveReports.TextBox
        Me.txtEmp_Assign1 = New DataDynamics.ActiveReports.TextBox
        Me.txtRev_Due_Date1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCompleted_Date1 = New DataDynamics.ActiveReports.TextBox
        Me.txtComments1 = New DataDynamics.ActiveReports.TextBox
        Me.txtHoursAllowed1 = New DataDynamics.ActiveReports.TextBox
        Me.txtJobDesc1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCompDesc1 = New DataDynamics.ActiveReports.TextBox
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.txtTimeDue = New DataDynamics.ActiveReports.TextBox
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.txtJobNum1 = New DataDynamics.ActiveReports.TextBox
        Me.txtCompNum1 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.lbluser = New DataDynamics.ActiveReports.Label
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.txtPName1 = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.txtsumHours1 = New DataDynamics.ActiveReports.TextBox
        Me.ArptTaskDS1 = New ActiveReportsAssembly.arptTaskDS
        Me.sumHours = New DataDynamics.ActiveReports.Field
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.txtCName1 = New DataDynamics.ActiveReports.TextBox
        Me.txtDName1 = New DataDynamics.ActiveReports.TextBox
        Me.txtClient = New DataDynamics.ActiveReports.TextBox
        Me.txtDivision = New DataDynamics.ActiveReports.TextBox
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox
        Me.txtClientCode = New DataDynamics.ActiveReports.TextBox
        Me.txtDivisionCode = New DataDynamics.ActiveReports.TextBox
        Me.txtProductCode = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.txtsumHours2 = New DataDynamics.ActiveReports.TextBox
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader
        Me.txtJobComp = New DataDynamics.ActiveReports.TextBox
        Me.txtJTComments = New DataDynamics.ActiveReports.TextBox
        Me.txtCommentJT = New DataDynamics.ActiveReports.TextBox
        Me.lblJobComp = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter
        Me.txtsumHours3 = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyTaskList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Task, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Job, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Emp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Comments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Hours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTask1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmp_Assign1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRev_Due_Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompleted_Date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHoursAllowed1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompDesc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimeDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNum1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompNum1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsumHours1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArptTaskDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivisionCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsumHours2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJTComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommentJT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJobComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsumHours3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox9, Me.MyTaskList, Me.Line1, Me.Task, Me.Job, Me.CompDesc, Me.Emp, Me.DueDate, Me.Comments, Me.Hours, Me.Completed, Me.TimeDue, Me.TextBox1})
        Me.PageHeader1.Height = 0.5!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'TextBox9
        '
        Me.TextBox9.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 0.0!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "background-color: LightGrey; "
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 0.3125!
        Me.TextBox9.Width = 10.5!
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
        Me.MyTaskList.Style = "ddo-char-set: 0; font-weight: bold; font-size: 14.25pt; "
        Me.MyTaskList.Text = "Task List"
        Me.MyTaskList.Top = 0.0!
        Me.MyTaskList.Width = 8.875!
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
        Me.Line1.Top = 0.25!
        Me.Line1.Width = 10.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 10.4375!
        Me.Line1.Y1 = 0.25!
        Me.Line1.Y2 = 0.25!
        '
        'Task
        '
        Me.Task.Border.BottomColor = System.Drawing.Color.Black
        Me.Task.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Task.Border.LeftColor = System.Drawing.Color.Black
        Me.Task.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Task.Border.RightColor = System.Drawing.Color.Black
        Me.Task.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Task.Border.TopColor = System.Drawing.Color.Black
        Me.Task.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Task.Height = 0.1875!
        Me.Task.HyperLink = Nothing
        Me.Task.Left = 0.375!
        Me.Task.Name = "Task"
        Me.Task.Style = "ddo-char-set: 0; font-weight: bold; background-color: LightGrey; font-size: 8.25p" & _
            "t; "
        Me.Task.Text = "Task"
        Me.Task.Top = 0.3125!
        Me.Task.Width = 3.25!
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
        Me.Job.Left = 0.0!
        Me.Job.Name = "Job"
        Me.Job.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Job.Text = "Job"
        Me.Job.Top = 0.5625!
        Me.Job.Visible = False
        Me.Job.Width = 1.9375!
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
        Me.CompDesc.Left = 2.0!
        Me.CompDesc.Name = "CompDesc"
        Me.CompDesc.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.CompDesc.Text = "Comp Desc"
        Me.CompDesc.Top = 0.5625!
        Me.CompDesc.Visible = False
        Me.CompDesc.Width = 1.9375!
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
        Me.Emp.Left = 3.25!
        Me.Emp.Name = "Emp"
        Me.Emp.Style = "ddo-char-set: 0; font-weight: bold; background-color: LightGrey; font-size: 8.25p" & _
            "t; "
        Me.Emp.Text = "Employee"
        Me.Emp.Top = 0.3125!
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
        Me.DueDate.Left = 4.5!
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Style = "ddo-char-set: 0; font-weight: bold; background-color: LightGrey; font-size: 8.25p" & _
            "t; "
        Me.DueDate.Text = "Due Date"
        Me.DueDate.Top = 0.3125!
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
        Me.Comments.Left = 7.3125!
        Me.Comments.Name = "Comments"
        Me.Comments.Style = "ddo-char-set: 0; font-weight: bold; background-color: LightGrey; font-size: 8.25p" & _
            "t; "
        Me.Comments.Text = "Task Comments"
        Me.Comments.Top = 0.3125!
        Me.Comments.Width = 2.4375!
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
        Me.Hours.Left = 9.625!
        Me.Hours.Name = "Hours"
        Me.Hours.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; background-color: LightGre" & _
            "y; font-size: 8.25pt; "
        Me.Hours.Text = "Hours"
        Me.Hours.Top = 0.3125!
        Me.Hours.Width = 0.75!
        '
        'Completed
        '
        Me.Completed.Border.BottomColor = System.Drawing.Color.Black
        Me.Completed.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Completed.Border.LeftColor = System.Drawing.Color.Black
        Me.Completed.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Completed.Border.RightColor = System.Drawing.Color.Black
        Me.Completed.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Completed.Border.TopColor = System.Drawing.Color.Black
        Me.Completed.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Completed.Height = 0.1875!
        Me.Completed.HyperLink = Nothing
        Me.Completed.Left = 6.4375!
        Me.Completed.Name = "Completed"
        Me.Completed.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; background-color: LightGre" & _
            "y; font-size: 8.25pt; "
        Me.Completed.Text = "Completed"
        Me.Completed.Top = 0.3125!
        Me.Completed.Width = 0.6875!
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
        Me.TimeDue.Left = 5.25!
        Me.TimeDue.Name = "TimeDue"
        Me.TimeDue.Style = "ddo-char-set: 0; font-weight: bold; background-color: LightGrey; font-size: 8.25p" & _
            "t; "
        Me.TimeDue.Text = "Time Due"
        Me.TimeDue.Top = 0.3125!
        Me.TimeDue.Width = 0.6875!
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
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "background-color: LightGrey; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.3125!
        Me.TextBox1.Width = 0.375!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTask1, Me.txtEmp_Assign1, Me.txtRev_Due_Date1, Me.txtCompleted_Date1, Me.txtComments1, Me.txtHoursAllowed1, Me.txtJobDesc1, Me.txtCompDesc1, Me.Line3, Me.Label3, Me.txtTimeDue})
        Me.Detail1.Height = 0.2!
        Me.Detail1.Name = "Detail1"
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
        Me.txtTask1.Left = 0.3125!
        Me.txtTask1.Name = "txtTask1"
        Me.txtTask1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtTask1.Text = "txtTask1"
        Me.txtTask1.Top = 0.0!
        Me.txtTask1.Width = 3.0!
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
        Me.txtEmp_Assign1.Left = 3.3125!
        Me.txtEmp_Assign1.Name = "txtEmp_Assign1"
        Me.txtEmp_Assign1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtEmp_Assign1.Text = "txtEmp_Assign1"
        Me.txtEmp_Assign1.Top = 0.0!
        Me.txtEmp_Assign1.Width = 1.125!
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
        Me.txtRev_Due_Date1.Left = 4.5!
        Me.txtRev_Due_Date1.Name = "txtRev_Due_Date1"
        Me.txtRev_Due_Date1.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
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
        Me.txtCompleted_Date1.Left = 6.4375!
        Me.txtCompleted_Date1.Name = "txtCompleted_Date1"
        Me.txtCompleted_Date1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.txtCompleted_Date1.Text = "txtCompleted_Date1"
        Me.txtCompleted_Date1.Top = 0.0!
        Me.txtCompleted_Date1.Width = 0.75!
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
        Me.txtComments1.Left = 7.25!
        Me.txtComments1.Name = "txtComments1"
        Me.txtComments1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtComments1.Text = "txtComments1"
        Me.txtComments1.Top = 0.0!
        Me.txtComments1.Width = 2.375!
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
        Me.txtHoursAllowed1.Left = 9.6875!
        Me.txtHoursAllowed1.Name = "txtHoursAllowed1"
        Me.txtHoursAllowed1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.txtHoursAllowed1.Text = "txtHoursAllowed1"
        Me.txtHoursAllowed1.Top = 0.0!
        Me.txtHoursAllowed1.Width = 0.75!
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
        Me.Line3.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.1875!
        Me.Line3.Width = 10.375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 10.4375!
        Me.Line3.Y1 = 0.1875!
        Me.Line3.Y2 = 0.1875!
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
        Me.Label3.DataField = "TEMP_COMP"
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 6.3125!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; "
        Me.Label3.Text = ""
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 0.15!
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
        Me.txtTimeDue.Left = 5.25!
        Me.txtTimeDue.Name = "txtTimeDue"
        Me.txtTimeDue.Style = "font-size: 8.25pt; "
        Me.txtTimeDue.Text = "txtTimeDue"
        Me.txtTimeDue.Top = 0.0!
        Me.txtTimeDue.Width = 1.125!
        '
        'Line4
        '
        Me.Line4.Border.BottomColor = System.Drawing.Color.Black
        Me.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.LeftColor = System.Drawing.Color.Black
        Me.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.RightColor = System.Drawing.Color.Black
        Me.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.TopColor = System.Drawing.Color.Black
        Me.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 0.0625!
        Me.Line4.LineColor = System.Drawing.Color.Gray
        Me.Line4.LineWeight = 6.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.0!
        Me.Line4.Visible = False
        Me.Line4.Width = 10.375!
        Me.Line4.X1 = 0.0625!
        Me.Line4.X2 = 10.4375!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.0!
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
        Me.txtJobNum1.CanShrink = True
        Me.txtJobNum1.DataField = "JobNum"
        Me.txtJobNum1.Height = 0.0625!
        Me.txtJobNum1.Left = 1.3125!
        Me.txtJobNum1.Name = "txtJobNum1"
        Me.txtJobNum1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtJobNum1.Text = Nothing
        Me.txtJobNum1.Top = 0.0!
        Me.txtJobNum1.Visible = False
        Me.txtJobNum1.Width = 1.75!
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
        Me.txtCompNum1.CanShrink = True
        Me.txtCompNum1.DataField = "CompNum"
        Me.txtCompNum1.Height = 0.0625!
        Me.txtCompNum1.Left = 3.0625!
        Me.txtCompNum1.Name = "txtCompNum1"
        Me.txtCompNum1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtCompNum1.Text = Nothing
        Me.txtCompNum1.Top = 0.0!
        Me.txtCompNum1.Visible = False
        Me.txtCompNum1.Width = 1.9375!
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
        Me.ReportInfo1.Height = 0.1875!
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
        Me.lbluser.Left = 1.75!
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Style = "font-size: 8pt; "
        Me.lbluser.Tag = " "
        Me.lbluser.Text = " "
        Me.lbluser.Top = 0.0625!
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
        Me.ReportInfo2.Left = 0.0625!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 8pt; "
        Me.ReportInfo2.Top = 0.0625!
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
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.Visible = False
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
        Me.txtPName1.CanShrink = True
        Me.txtPName1.DataField = "PName"
        Me.txtPName1.Height = 0.1875!
        Me.txtPName1.Left = 7.3125!
        Me.txtPName1.Name = "txtPName1"
        Me.txtPName1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtPName1.Text = "txtPName1"
        Me.txtPName1.Top = 0.0!
        Me.txtPName1.Width = 2.4375!
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
        Me.Label10.Left = 7.375!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label10.Text = " Total Product Hours:"
        Me.Label10.Top = 0.0!
        Me.Label10.Width = 1.9375!
        '
        'txtsumHours1
        '
        Me.txtsumHours1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsumHours1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsumHours1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours1.Border.RightColor = System.Drawing.Color.Black
        Me.txtsumHours1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours1.Border.TopColor = System.Drawing.Color.Black
        Me.txtsumHours1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours1.DataField = "HoursAllowed"
        Me.txtsumHours1.Height = 0.2!
        Me.txtsumHours1.Left = 9.4375!
        Me.txtsumHours1.Name = "txtsumHours1"
        Me.txtsumHours1.OutputFormat = resources.GetString("txtsumHours1.OutputFormat")
        Me.txtsumHours1.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.txtsumHours1.SummaryGroup = "GroupHeader1"
        Me.txtsumHours1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsumHours1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsumHours1.Text = "txtsumHours1"
        Me.txtsumHours1.Top = 0.0!
        Me.txtsumHours1.Width = 1.0!
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
        Me.sumHours.Formula = ""
        Me.sumHours.Name = "sumHours"
        Me.sumHours.Tag = Nothing
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Height = 0.0!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label10, Me.txtsumHours1})
        Me.GroupFooter2.Height = 0.21875!
        Me.GroupFooter2.Name = "GroupFooter2"
        Me.GroupFooter2.Visible = False
        '
        'GroupHeader1
        '
        Me.GroupHeader1.BackColor = System.Drawing.Color.LightGray
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCName1, Me.txtDName1, Me.txtClient, Me.txtDivision, Me.txtProduct, Me.txtPName1, Me.txtClientCode, Me.txtDivisionCode, Me.txtProductCode})
        Me.GroupHeader1.DataField = "CDP"
        Me.GroupHeader1.Height = 0.2083333!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.txtCName1.CanShrink = True
        Me.txtCName1.DataField = "CName"
        Me.txtCName1.Height = 0.1875!
        Me.txtCName1.Left = 1.0625!
        Me.txtCName1.Name = "txtCName1"
        Me.txtCName1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtCName1.Text = "txtCName1"
        Me.txtCName1.Top = 0.0!
        Me.txtCName1.Width = 2.4375!
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
        Me.txtDName1.CanShrink = True
        Me.txtDName1.DataField = "DName"
        Me.txtDName1.Height = 0.1875!
        Me.txtDName1.Left = 4.1875!
        Me.txtDName1.Name = "txtDName1"
        Me.txtDName1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtDName1.Text = "txtDName1"
        Me.txtDName1.Top = 0.0!
        Me.txtDName1.Width = 2.4375!
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
        Me.txtClient.CanShrink = True
        Me.txtClient.Height = 0.1875!
        Me.txtClient.Left = 0.5625!
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.txtClient.Text = "Client:"
        Me.txtClient.Top = 0.0!
        Me.txtClient.Width = 0.4375!
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
        Me.txtDivision.CanShrink = True
        Me.txtDivision.Height = 0.1875!
        Me.txtDivision.Left = 3.5625!
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.txtDivision.Text = "Division:"
        Me.txtDivision.Top = 0.0!
        Me.txtDivision.Width = 0.5625!
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
        Me.txtProduct.CanShrink = True
        Me.txtProduct.Height = 0.1875!
        Me.txtProduct.Left = 6.6875!
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.txtProduct.Text = "Product:"
        Me.txtProduct.Top = 0.0!
        Me.txtProduct.Width = 0.5625!
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
        Me.txtClientCode.CanShrink = True
        Me.txtClientCode.DataField = "CCode"
        Me.txtClientCode.Height = 0.1875!
        Me.txtClientCode.Left = 10.3125!
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Style = ""
        Me.txtClientCode.Text = Nothing
        Me.txtClientCode.Top = 0.0!
        Me.txtClientCode.Visible = False
        Me.txtClientCode.Width = 0.125!
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
        Me.txtDivisionCode.CanShrink = True
        Me.txtDivisionCode.DataField = "DCode"
        Me.txtDivisionCode.Height = 0.1875!
        Me.txtDivisionCode.Left = 10.3125!
        Me.txtDivisionCode.Name = "txtDivisionCode"
        Me.txtDivisionCode.Style = ""
        Me.txtDivisionCode.Text = Nothing
        Me.txtDivisionCode.Top = 0.1875!
        Me.txtDivisionCode.Visible = False
        Me.txtDivisionCode.Width = 0.125!
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
        Me.txtProductCode.CanShrink = True
        Me.txtProductCode.DataField = "PCode"
        Me.txtProductCode.Height = 0.1875!
        Me.txtProductCode.Left = 10.3125!
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Style = ""
        Me.txtProductCode.Text = Nothing
        Me.txtProductCode.Top = 0.375!
        Me.txtProductCode.Visible = False
        Me.txtProductCode.Width = 0.125!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.BackColor = System.Drawing.Color.SlateBlue
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtsumHours2, Me.Label11})
        Me.GroupFooter1.Height = 0.083!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.Visible = False
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
        Me.txtsumHours2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.txtsumHours2.SummaryGroup = "GroupHeader1"
        Me.txtsumHours2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsumHours2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsumHours2.Text = "txtsumHours2"
        Me.txtsumHours2.Top = 0.0!
        Me.txtsumHours2.Visible = False
        Me.txtsumHours2.Width = 1.0!
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
        Me.Label11.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.Label11.Text = "Total Client Hours:"
        Me.Label11.Top = 0.0!
        Me.Label11.Visible = False
        Me.Label11.Width = 1.9375!
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
        Me.Line2.Left = 0.0!
        Me.Line2.LineWeight = 4.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0625!
        Me.Line2.Width = 10.5!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 10.5!
        Me.Line2.Y1 = 0.0625!
        Me.Line2.Y2 = 0.0625!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.CanShrink = True
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtJobNum1, Me.txtCompNum1, Me.txtJobComp, Me.txtJTComments, Me.txtCommentJT, Me.lblJobComp, Me.TextBox2})
        Me.GroupHeader3.DataField = "JBNUM"
        Me.GroupHeader3.Height = 0.2833333!
        Me.GroupHeader3.KeepTogether = True
        Me.GroupHeader3.Name = "GroupHeader3"
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
        Me.txtJobComp.CanShrink = True
        Me.txtJobComp.Height = 0.0625!
        Me.txtJobComp.Left = 1.0625!
        Me.txtJobComp.Name = "txtJobComp"
        Me.txtJobComp.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtJobComp.Text = Nothing
        Me.txtJobComp.Top = 0.0625!
        Me.txtJobComp.Width = 9.0625!
        '
        'txtJTComments
        '
        Me.txtJTComments.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJTComments.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJTComments.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJTComments.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJTComments.Border.RightColor = System.Drawing.Color.Black
        Me.txtJTComments.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJTComments.Border.TopColor = System.Drawing.Color.Black
        Me.txtJTComments.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJTComments.CanShrink = True
        Me.txtJTComments.DataField = "JTComments"
        Me.txtJTComments.Height = 0.0625!
        Me.txtJTComments.Left = 1.0625!
        Me.txtJTComments.Name = "txtJTComments"
        Me.txtJTComments.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtJTComments.Text = Nothing
        Me.txtJTComments.Top = 0.125!
        Me.txtJTComments.Width = 9.0!
        '
        'txtCommentJT
        '
        Me.txtCommentJT.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCommentJT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCommentJT.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCommentJT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCommentJT.Border.RightColor = System.Drawing.Color.Black
        Me.txtCommentJT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCommentJT.Border.TopColor = System.Drawing.Color.Black
        Me.txtCommentJT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCommentJT.CanShrink = True
        Me.txtCommentJT.Height = 0.0625!
        Me.txtCommentJT.Left = 0.375!
        Me.txtCommentJT.Name = "txtCommentJT"
        Me.txtCommentJT.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.txtCommentJT.Text = Nothing
        Me.txtCommentJT.Top = 0.125!
        Me.txtCommentJT.Width = 0.625!
        '
        'lblJobComp
        '
        Me.lblJobComp.Border.BottomColor = System.Drawing.Color.Black
        Me.lblJobComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblJobComp.Border.LeftColor = System.Drawing.Color.Black
        Me.lblJobComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblJobComp.Border.RightColor = System.Drawing.Color.Black
        Me.lblJobComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblJobComp.Border.TopColor = System.Drawing.Color.Black
        Me.lblJobComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblJobComp.CanShrink = True
        Me.lblJobComp.Height = 0.0625!
        Me.lblJobComp.Left = 0.0625!
        Me.lblJobComp.Name = "lblJobComp"
        Me.lblJobComp.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.lblJobComp.Text = "Job/Component:"
        Me.lblJobComp.Top = 0.0625!
        Me.lblJobComp.Width = 1.0!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
        Me.GroupFooter3.Height = 0.08333334!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'txtsumHours3
        '
        Me.txtsumHours3.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsumHours3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours3.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsumHours3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours3.Border.RightColor = System.Drawing.Color.Black
        Me.txtsumHours3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours3.Border.TopColor = System.Drawing.Color.Black
        Me.txtsumHours3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsumHours3.DataField = "HoursAllowed"
        Me.txtsumHours3.Height = 0.2!
        Me.txtsumHours3.Left = 9.4375!
        Me.txtsumHours3.Name = "txtsumHours3"
        Me.txtsumHours3.OutputFormat = resources.GetString("txtsumHours3.OutputFormat")
        Me.txtsumHours3.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.txtsumHours3.SummaryGroup = "GroupHeader3"
        Me.txtsumHours3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsumHours3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsumHours3.Text = "txtsumHours3"
        Me.txtsumHours3.Top = 0.0!
        Me.txtsumHours3.Width = 1.0!
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
        Me.Label1.Left = 8.5!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label1.Text = " Total Hours:"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 0.8125!
        '
        'GroupHeader4
        '
        Me.GroupHeader4.BackColor = System.Drawing.Color.LightGray
        Me.GroupHeader4.Height = 0.1458333!
        Me.GroupHeader4.KeepTogether = True
        Me.GroupHeader4.Name = "GroupHeader4"
        Me.GroupHeader4.Visible = False
        '
        'GroupFooter4
        '
        Me.GroupFooter4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtsumHours3, Me.Line4, Me.Label1})
        Me.GroupFooter4.Height = 0.25!
        Me.GroupFooter4.Name = "GroupFooter4"
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
        Me.TextBox2.Height = 0.09!
        Me.TextBox2.Left = 0.625!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = ""
        Me.TextBox2.Top = 0.1875!
        Me.TextBox2.Width = 7.6875!
        '
        'arptMyTaskList
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
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.GroupHeader4)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter4)
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
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyTaskList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Task, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Job, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Emp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Comments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Hours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Completed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTask1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmp_Assign1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRev_Due_Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompleted_Date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHoursAllowed1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompDesc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimeDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNum1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompNum1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbluser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsumHours1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArptTaskDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivisionCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsumHours2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJTComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommentJT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJobComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsumHours3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents ArptTaskDS1 As ActiveReportsAssembly.arptTaskDS
    Friend WithEvents MyTaskList As DataDynamics.ActiveReports.Label
    Friend WithEvents Emp As DataDynamics.ActiveReports.Label
    Friend WithEvents DueDate As DataDynamics.ActiveReports.Label
    Friend WithEvents Comments As DataDynamics.ActiveReports.Label
    Friend WithEvents Hours As DataDynamics.ActiveReports.Label
    Friend WithEvents Task As DataDynamics.ActiveReports.Label
    Friend WithEvents Completed As DataDynamics.ActiveReports.Label
    Friend WithEvents txtPName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobNum1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompNum1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTask1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEmp_Assign1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRev_Due_Date1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompleted_Date1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComments1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHoursAllowed1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents sumHours As DataDynamics.ActiveReports.Field
    Friend WithEvents txtsumHours1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDesc1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCompDesc1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents lbluser As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtCName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDName1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtsumHours2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtJobComp As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Job As DataDynamics.ActiveReports.Label
    Friend WithEvents CompDesc As DataDynamics.ActiveReports.Label
    Friend WithEvents txtsumHours3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTimeDue As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TimeDue As DataDynamics.ActiveReports.Label
    Friend WithEvents txtJTComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtClientCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivisionCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProductCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCommentJT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblJobComp As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
End Class
