<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptAlertAssignment
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
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptAlertAssignment))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtAlertState = New DataDynamics.ActiveReports.TextBox()
        Me.txtStartDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtDueDate = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtAlertState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAlertState, Me.txtStartDate, Me.txtDueDate})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'txtAlertState
        '
        Me.txtAlertState.CanShrink = True
        Me.txtAlertState.DataField = "ALERT_STATE_NAME"
        Me.txtAlertState.Height = 0.187!
        Me.txtAlertState.Left = 0.25!
        Me.txtAlertState.Name = "txtAlertState"
        Me.txtAlertState.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAlertState.Text = Nothing
        Me.txtAlertState.Top = 0!
        Me.txtAlertState.Width = 2.25!
        '
        'txtStartDate
        '
        Me.txtStartDate.CanShrink = True
        Me.txtStartDate.DataField = "DUE_DATE"
        Me.txtStartDate.Height = 0.187!
        Me.txtStartDate.Left = 2.562!
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtStartDate.Text = Nothing
        Me.txtStartDate.Top = 0!
        Me.txtStartDate.Width = 0.94!
        '
        'txtDueDate
        '
        Me.txtDueDate.CanShrink = True
        Me.txtDueDate.DataField = "DUE_DATE"
        Me.txtDueDate.Height = 0.187!
        Me.txtDueDate.Left = 3.562!
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtDueDate.Text = Nothing
        Me.txtDueDate.Top = 0!
        Me.txtDueDate.Width = 0.81!
        '
        'arptAlertAssignment
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.Detail1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtAlertState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents txtAlertState As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtStartDate As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtDueDate As DataDynamics.ActiveReports.TextBox
End Class
