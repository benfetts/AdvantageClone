<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEstHeaderTap2
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEstHeaderTap2))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox9, Me.TextBox14, Me.TextBox15, Me.TextBox17, Me.TextBox18, Me.TextBox10})
        Me.Detail1.Height = 1.4375!
        Me.Detail1.Name = "Detail1"
        '
        'TextBox9
        '
        Me.TextBox9.CanShrink = True
        Me.TextBox9.Height = 0.187!
        Me.TextBox9.Left = 0.0!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox9.Text = "Date:"
        Me.TextBox9.Top = 0.375!
        Me.TextBox9.Width = 0.5625!
        '
        'TextBox14
        '
        Me.TextBox14.CanShrink = True
        Me.TextBox14.Height = 0.187!
        Me.TextBox14.Left = 0.0!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox14.Text = "Account Manager:"
        Me.TextBox14.Top = 0.00000002980232!
        Me.TextBox14.Width = 1.25!
        '
        'TextBox15
        '
        Me.TextBox15.CanShrink = True
        Me.TextBox15.Height = 0.188!
        Me.TextBox15.Left = 0.0!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox15.Text = "Campaign:"
        Me.TextBox15.Top = 0.187!
        Me.TextBox15.Width = 0.6875!
        '
        'TextBox17
        '
        Me.TextBox17.CanShrink = True
        Me.TextBox17.Height = 0.187!
        Me.TextBox17.Left = 1.25!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox17.Text = Nothing
        Me.TextBox17.Top = 0.0!
        Me.TextBox17.Width = 2.187!
        '
        'TextBox18
        '
        Me.TextBox18.CanShrink = True
        Me.TextBox18.Height = 0.188!
        Me.TextBox18.Left = 1.25!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox18.Text = Nothing
        Me.TextBox18.Top = 0.187!
        Me.TextBox18.Width = 2.187!
        '
        'TextBox10
        '
        Me.TextBox10.CanShrink = True
        Me.TextBox10.Height = 0.187!
        Me.TextBox10.Left = 1.25!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.375!
        Me.TextBox10.Width = 2.187!
        '
        'arptEstHeaderTap
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 3.479167!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.Detail1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox18 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
End Class
