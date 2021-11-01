<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptJobTrafficSchedule002
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptJobTrafficSchedule002))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtDay = New DataDynamics.ActiveReports.TextBox()
        Me.txtDueDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescription = New DataDynamics.ActiveReports.TextBox()
        Me.lblMilestone = New DataDynamics.ActiveReports.Label()
        Me.txtFName = New DataDynamics.ActiveReports.TextBox()
        Me.txtMName = New DataDynamics.ActiveReports.TextBox()
        Me.txtLName = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.lblTask = New DataDynamics.ActiveReports.Label()
        Me.lblDueDate = New DataDynamics.ActiveReports.Label()
        Me.lblAssigned = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.txtStartDatelbl = New DataDynamics.ActiveReports.TextBox()
        Me.lblTimeDue = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.lblAsterik = New DataDynamics.ActiveReports.Label()
        CType(Me.txtDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMilestone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAssigned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStartDatelbl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTimeDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAsterik, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDay, Me.txtDueDate, Me.txtDescription, Me.lblMilestone, Me.txtFName, Me.txtMName, Me.txtLName})
        Me.Detail1.Height = 0.2208334!
        Me.Detail1.Name = "Detail1"
        '
        'txtDay
        '
        Me.txtDay.CanShrink = True
        Me.txtDay.CountNullValues = True
        Me.txtDay.Height = 0.1875!
        Me.txtDay.Left = 0.0625!
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtDay.Text = "txtDay"
        Me.txtDay.Top = 0.0!
        Me.txtDay.Width = 0.4995!
        '
        'txtDueDate
        '
        Me.txtDueDate.CanShrink = True
        Me.txtDueDate.DataField = "JOB_REVISED_DATE"
        Me.txtDueDate.Height = 0.1875!
        Me.txtDueDate.Left = 0.625!
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtDueDate.Text = "txtDueDate"
        Me.txtDueDate.Top = 0.0!
        Me.txtDueDate.Width = 0.6875!
        '
        'txtDescription
        '
        Me.txtDescription.CanShrink = True
        Me.txtDescription.ClassName = "Heading1"
        Me.txtDescription.DataField = "TASK_DESCRIPTION"
        Me.txtDescription.Height = 0.1875!
        Me.txtDescription.Left = 1.5!
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.txtDescription.Text = "txtDescription"
        Me.txtDescription.Top = 0.0!
        Me.txtDescription.Width = 5.187!
        '
        'lblMilestone
        '
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
        'txtFName
        '
        Me.txtFName.DataField = "EMP_FNAME"
        Me.txtFName.Height = 0.1875!
        Me.txtFName.Left = 6.625!
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Text = "txtFName"
        Me.txtFName.Top = 0.6875!
        Me.txtFName.Visible = False
        Me.txtFName.Width = 0.125!
        '
        'txtMName
        '
        Me.txtMName.DataField = "EMP_MI"
        Me.txtMName.Height = 0.1875!
        Me.txtMName.Left = 6.75!
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Text = "txtMName"
        Me.txtMName.Top = 0.6875!
        Me.txtMName.Visible = False
        Me.txtMName.Width = 0.125!
        '
        'txtLName
        '
        Me.txtLName.DataField = "EMP_LNAME"
        Me.txtLName.Height = 0.1875!
        Me.txtLName.Left = 6.9375!
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Text = "txtLName"
        Me.txtLName.Top = 0.6875!
        Me.txtLName.Visible = False
        Me.txtLName.Width = 0.0625!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTask, Me.lblDueDate, Me.lblAssigned, Me.Line1, Me.txtStartDatelbl, Me.lblTimeDue})
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.Visible = False
        '
        'lblTask
        '
        Me.lblTask.Height = 0.1875!
        Me.lblTask.HyperLink = Nothing
        Me.lblTask.Left = 0.0625!
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.lblTask.Text = "Task"
        Me.lblTask.Top = 0.125!
        Me.lblTask.Width = 2.5!
        '
        'lblDueDate
        '
        Me.lblDueDate.Height = 0.1875!
        Me.lblDueDate.HyperLink = Nothing
        Me.lblDueDate.Left = 3.5!
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.lblDueDate.Text = "Due Date"
        Me.lblDueDate.Top = 0.125!
        Me.lblDueDate.Width = 0.6875!
        '
        'lblAssigned
        '
        Me.lblAssigned.Height = 0.1875!
        Me.lblAssigned.HyperLink = Nothing
        Me.lblAssigned.Left = 5.0!
        Me.lblAssigned.Name = "lblAssigned"
        Me.lblAssigned.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.lblAssigned.Text = "Assigned"
        Me.lblAssigned.Top = 0.125!
        Me.lblAssigned.Width = 2.4375!
        '
        'Line1
        '
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
        Me.txtStartDatelbl.CanShrink = True
        Me.txtStartDatelbl.Height = 0.1875!
        Me.txtStartDatelbl.Left = 2.5625!
        Me.txtStartDatelbl.Name = "txtStartDatelbl"
        Me.txtStartDatelbl.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.txtStartDatelbl.Text = "Start Date"
        Me.txtStartDatelbl.Top = 0.125!
        Me.txtStartDatelbl.Width = 0.8125!
        '
        'lblTimeDue
        '
        Me.lblTimeDue.Height = 0.1875!
        Me.lblTimeDue.HyperLink = Nothing
        Me.lblTimeDue.Left = 4.1875!
        Me.lblTimeDue.Name = "lblTimeDue"
        Me.lblTimeDue.Style = "font-size: 9.75pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.lblTimeDue.Text = "Time Due"
        Me.lblTimeDue.Top = 0.125!
        Me.lblTimeDue.Width = 0.75!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblAsterik})
        Me.GroupFooter1.Height = 0.2291667!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.Visible = False
        '
        'lblAsterik
        '
        Me.lblAsterik.Height = 0.1979167!
        Me.lblAsterik.HyperLink = Nothing
        Me.lblAsterik.Left = 0.0625!
        Me.lblAsterik.Name = "lblAsterik"
        Me.lblAsterik.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.lblAsterik.Text = "* = Milestone"
        Me.lblAsterik.Top = 0.0!
        Me.lblAsterik.Width = 1.0!
        '
        'arptJobTrafficSchedule002
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
                    "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMilestone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAssigned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStartDatelbl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTimeDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAsterik, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents lblTask As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDueDate As DataDynamics.ActiveReports.Label
    Friend WithEvents lblAssigned As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtDay As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDueDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblMilestone As DataDynamics.ActiveReports.Label
    Friend WithEvents txtStartDatelbl As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAsterik As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTimeDue As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDescription As DataDynamics.ActiveReports.TextBox
End Class
