<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptJobTrafficSchedule 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptJobTrafficSchedule))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtTask = New DataDynamics.ActiveReports.TextBox
        Me.txtDueDate = New DataDynamics.ActiveReports.TextBox
        Me.txtAssigned = New DataDynamics.ActiveReports.TextBox
        Me.lblMilestone = New DataDynamics.ActiveReports.Label
        Me.txtStartDate = New DataDynamics.ActiveReports.TextBox
        Me.txtFName = New DataDynamics.ActiveReports.TextBox
        Me.txtMName = New DataDynamics.ActiveReports.TextBox
        Me.txtLName = New DataDynamics.ActiveReports.TextBox
        Me.txtTimeDue = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblTask = New DataDynamics.ActiveReports.Label
        Me.lblDueDate = New DataDynamics.ActiveReports.Label
        Me.lblAssigned = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.txtStartDatelbl = New DataDynamics.ActiveReports.TextBox
        Me.lblTimeDue = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.lblAsterik = New DataDynamics.ActiveReports.Label
        Me.txtScheduleComments = New DataDynamics.ActiveReports.TextBox
        Me.txtComments = New DataDynamics.ActiveReports.TextBox
        CType(Me.txtTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAssigned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMilestone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimeDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAssigned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStartDatelbl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTimeDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAsterik, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScheduleComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTask, Me.txtDueDate, Me.txtAssigned, Me.lblMilestone, Me.txtStartDate, Me.txtFName, Me.txtMName, Me.txtLName, Me.txtTimeDue})
        Me.Detail1.Height = 0.2!
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
        Me.txtTask.CountNullValues = True
        Me.txtTask.DataField = "TASK_DESCRIPTION"
        Me.txtTask.Height = 0.1875!
        Me.txtTask.Left = 0.0625!
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtTask.Text = "txtTask"
        Me.txtTask.Top = 0.0!
        Me.txtTask.Width = 2.5!
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
        Me.txtDueDate.DataField = "JOB_REVISED_DATE"
        Me.txtDueDate.Height = 0.1875!
        Me.txtDueDate.Left = 3.375!
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; "
        Me.txtDueDate.Text = "txtDueDate"
        Me.txtDueDate.Top = 0.0!
        Me.txtDueDate.Width = 0.8125!
        '
        'txtAssigned
        '
        Me.txtAssigned.Border.BottomColor = System.Drawing.Color.Black
        Me.txtAssigned.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAssigned.Border.LeftColor = System.Drawing.Color.Black
        Me.txtAssigned.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAssigned.Border.RightColor = System.Drawing.Color.Black
        Me.txtAssigned.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAssigned.Border.TopColor = System.Drawing.Color.Black
        Me.txtAssigned.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAssigned.ClassName = "Heading1"
        Me.txtAssigned.DataField = "EMP_LNAME_LIST"
        Me.txtAssigned.Height = 0.1875!
        Me.txtAssigned.Left = 5.0!
        Me.txtAssigned.Name = "txtAssigned"
        Me.txtAssigned.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9pt; "
        Me.txtAssigned.Text = "txtAssigned"
        Me.txtAssigned.Top = 0.0!
        Me.txtAssigned.Width = 2.4375!
        '
        'lblMilestone
        '
        Me.lblMilestone.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMilestone.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMilestone.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMilestone.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMilestone.Border.RightColor = System.Drawing.Color.Black
        Me.lblMilestone.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMilestone.Border.TopColor = System.Drawing.Color.Black
        Me.lblMilestone.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMilestone.DataField = "MILESTONE"
        Me.lblMilestone.Height = 0.1875!
        Me.lblMilestone.HyperLink = Nothing
        Me.lblMilestone.Left = 7.125!
        Me.lblMilestone.Name = "lblMilestone"
        Me.lblMilestone.Style = ""
        Me.lblMilestone.Text = "lblMilestone"
        Me.lblMilestone.Top = 0.6875!
        Me.lblMilestone.Visible = False
        Me.lblMilestone.Width = 0.1875!
        '
        'txtStartDate
        '
        Me.txtStartDate.Border.BottomColor = System.Drawing.Color.Black
        Me.txtStartDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStartDate.Border.LeftColor = System.Drawing.Color.Black
        Me.txtStartDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStartDate.Border.RightColor = System.Drawing.Color.Black
        Me.txtStartDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStartDate.Border.TopColor = System.Drawing.Color.Black
        Me.txtStartDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStartDate.CanShrink = True
        Me.txtStartDate.DataField = "TASK_START_DATE"
        Me.txtStartDate.Height = 0.1875!
        Me.txtStartDate.Left = 2.5625!
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtStartDate.Text = "txtStartDate"
        Me.txtStartDate.Top = 0.0!
        Me.txtStartDate.Width = 0.8125!
        '
        'txtFName
        '
        Me.txtFName.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFName.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFName.Border.RightColor = System.Drawing.Color.Black
        Me.txtFName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFName.Border.TopColor = System.Drawing.Color.Black
        Me.txtFName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFName.DataField = "EMP_FNAME"
        Me.txtFName.Height = 0.1875!
        Me.txtFName.Left = 6.625!
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Style = ""
        Me.txtFName.Text = "txtFName"
        Me.txtFName.Top = 0.6875!
        Me.txtFName.Visible = False
        Me.txtFName.Width = 0.125!
        '
        'txtMName
        '
        Me.txtMName.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMName.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMName.Border.RightColor = System.Drawing.Color.Black
        Me.txtMName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMName.Border.TopColor = System.Drawing.Color.Black
        Me.txtMName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMName.DataField = "EMP_MI"
        Me.txtMName.Height = 0.1875!
        Me.txtMName.Left = 6.75!
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Style = ""
        Me.txtMName.Text = "txtMName"
        Me.txtMName.Top = 0.6875!
        Me.txtMName.Visible = False
        Me.txtMName.Width = 0.125!
        '
        'txtLName
        '
        Me.txtLName.Border.BottomColor = System.Drawing.Color.Black
        Me.txtLName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLName.Border.LeftColor = System.Drawing.Color.Black
        Me.txtLName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLName.Border.RightColor = System.Drawing.Color.Black
        Me.txtLName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLName.Border.TopColor = System.Drawing.Color.Black
        Me.txtLName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLName.DataField = "EMP_LNAME"
        Me.txtLName.Height = 0.1875!
        Me.txtLName.Left = 6.9375!
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Style = ""
        Me.txtLName.Text = "txtLName"
        Me.txtLName.Top = 0.6875!
        Me.txtLName.Visible = False
        Me.txtLName.Width = 0.0625!
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
        Me.txtTimeDue.DataField = "REVISED_DUE_TIME"
        Me.txtTimeDue.Height = 0.1875!
        Me.txtTimeDue.Left = 4.1875!
        Me.txtTimeDue.Name = "txtTimeDue"
        Me.txtTimeDue.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtTimeDue.Text = Nothing
        Me.txtTimeDue.Top = 0.0!
        Me.txtTimeDue.Width = 0.8125!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTask, Me.lblDueDate, Me.lblAssigned, Me.Line1, Me.txtStartDatelbl, Me.lblTimeDue, Me.txtComments, Me.txtScheduleComments})
        Me.GroupHeader1.Height = 0.3958333!
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.lblTask.HyperLink = Nothing
        Me.lblTask.Left = 0.0625!
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.lblTask.Text = "Task"
        Me.lblTask.Top = 0.125!
        Me.lblTask.Width = 2.5!
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
        Me.lblDueDate.HyperLink = Nothing
        Me.lblDueDate.Left = 3.5!
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.lblDueDate.Text = "Due Date"
        Me.lblDueDate.Top = 0.125!
        Me.lblDueDate.Width = 0.6875!
        '
        'lblAssigned
        '
        Me.lblAssigned.Border.BottomColor = System.Drawing.Color.Black
        Me.lblAssigned.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAssigned.Border.LeftColor = System.Drawing.Color.Black
        Me.lblAssigned.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAssigned.Border.RightColor = System.Drawing.Color.Black
        Me.lblAssigned.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAssigned.Border.TopColor = System.Drawing.Color.Black
        Me.lblAssigned.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAssigned.Height = 0.1875!
        Me.lblAssigned.HyperLink = Nothing
        Me.lblAssigned.Left = 5.0!
        Me.lblAssigned.Name = "lblAssigned"
        Me.lblAssigned.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.lblAssigned.Text = "Assigned"
        Me.lblAssigned.Top = 0.125!
        Me.lblAssigned.Width = 2.4375!
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
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.375!
        Me.Line1.Width = 7.3125!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.375!
        Me.Line1.Y1 = 0.375!
        Me.Line1.Y2 = 0.375!
        '
        'txtStartDatelbl
        '
        Me.txtStartDatelbl.Border.BottomColor = System.Drawing.Color.Black
        Me.txtStartDatelbl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStartDatelbl.Border.LeftColor = System.Drawing.Color.Black
        Me.txtStartDatelbl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStartDatelbl.Border.RightColor = System.Drawing.Color.Black
        Me.txtStartDatelbl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStartDatelbl.Border.TopColor = System.Drawing.Color.Black
        Me.txtStartDatelbl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtStartDatelbl.CanShrink = True
        Me.txtStartDatelbl.Height = 0.1875!
        Me.txtStartDatelbl.Left = 2.5625!
        Me.txtStartDatelbl.Name = "txtStartDatelbl"
        Me.txtStartDatelbl.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.txtStartDatelbl.Text = "Start Date"
        Me.txtStartDatelbl.Top = 0.125!
        Me.txtStartDatelbl.Width = 0.8125!
        '
        'lblTimeDue
        '
        Me.lblTimeDue.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTimeDue.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTimeDue.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTimeDue.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTimeDue.Border.RightColor = System.Drawing.Color.Black
        Me.lblTimeDue.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTimeDue.Border.TopColor = System.Drawing.Color.Black
        Me.lblTimeDue.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTimeDue.Height = 0.1875!
        Me.lblTimeDue.HyperLink = Nothing
        Me.lblTimeDue.Left = 4.1875!
        Me.lblTimeDue.Name = "lblTimeDue"
        Me.lblTimeDue.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9.75pt; "
        Me.lblTimeDue.Text = "Time Due"
        Me.lblTimeDue.Top = 0.125!
        Me.lblTimeDue.Width = 0.75!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblAsterik})
        Me.GroupFooter1.Height = 0.2291667!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'lblAsterik
        '
        Me.lblAsterik.Border.BottomColor = System.Drawing.Color.Black
        Me.lblAsterik.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAsterik.Border.LeftColor = System.Drawing.Color.Black
        Me.lblAsterik.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAsterik.Border.RightColor = System.Drawing.Color.Black
        Me.lblAsterik.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAsterik.Border.TopColor = System.Drawing.Color.Black
        Me.lblAsterik.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAsterik.Height = 0.1979167!
        Me.lblAsterik.HyperLink = Nothing
        Me.lblAsterik.Left = 0.0625!
        Me.lblAsterik.Name = "lblAsterik"
        Me.lblAsterik.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.lblAsterik.Text = "* = Milestone"
        Me.lblAsterik.Top = 0.0!
        Me.lblAsterik.Width = 1.0!
        '
        'txtScheduleComments
        '
        Me.txtScheduleComments.Border.BottomColor = System.Drawing.Color.Black
        Me.txtScheduleComments.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtScheduleComments.Border.LeftColor = System.Drawing.Color.Black
        Me.txtScheduleComments.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtScheduleComments.Border.RightColor = System.Drawing.Color.Black
        Me.txtScheduleComments.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtScheduleComments.Border.TopColor = System.Drawing.Color.Black
        Me.txtScheduleComments.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtScheduleComments.CanShrink = True
        Me.txtScheduleComments.DataField = "TRF_COMMENTS"
        Me.txtScheduleComments.Height = 0.0625!
        Me.txtScheduleComments.Left = 0.8125!
        Me.txtScheduleComments.Name = "txtScheduleComments"
        Me.txtScheduleComments.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtScheduleComments.Top = 0.0!
        Me.txtScheduleComments.Width = 6.625!
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
        Me.txtComments.Height = 0.0625!
        Me.txtComments.Left = 0.0625!
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.txtComments.Top = 0.0!
        Me.txtComments.Width = 0.75!
        '
        'arptJobTrafficSchedule
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.25!
        Me.PageSettings.Margins.Left = 0.25!
        Me.PageSettings.Margins.Right = 0.25!
        Me.PageSettings.Margins.Top = 0.25!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.txtTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAssigned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMilestone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimeDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAssigned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStartDatelbl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTimeDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAsterik, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScheduleComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents lblTask As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDueDate As DataDynamics.ActiveReports.Label
    Friend WithEvents lblAssigned As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtTask As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDueDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAssigned As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblMilestone As DataDynamics.ActiveReports.Label
    Friend WithEvents txtStartDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtStartDatelbl As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAsterik As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTimeDue As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTimeDue As DataDynamics.ActiveReports.Label
    Friend WithEvents txtScheduleComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComments As DataDynamics.ActiveReports.TextBox
End Class
