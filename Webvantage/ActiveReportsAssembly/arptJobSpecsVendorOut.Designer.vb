<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptJobSpecsVendorOut
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptJobSpecsVendorOut))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtVendor = New DataDynamics.ActiveReports.TextBox
        Me.txtAdSize = New DataDynamics.ActiveReports.TextBox
        Me.txtLocationofSign = New DataDynamics.ActiveReports.TextBox
        Me.txtOverallSize = New DataDynamics.ActiveReports.TextBox
        Me.txtCopyArea = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Line1 = New DataDynamics.ActiveReports.Line
        CType(Me.txtVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocationofSign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOverallSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCopyArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtVendor, Me.txtAdSize, Me.txtLocationofSign, Me.txtOverallSize, Me.txtCopyArea, Me.Line1})
        Me.Detail1.Height = 0.2708333!
        Me.Detail1.Name = "Detail1"
        '
        'txtVendor
        '
        Me.txtVendor.Border.BottomColor = System.Drawing.Color.Black
        Me.txtVendor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendor.Border.LeftColor = System.Drawing.Color.Black
        Me.txtVendor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendor.Border.RightColor = System.Drawing.Color.Black
        Me.txtVendor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendor.Border.TopColor = System.Drawing.Color.Black
        Me.txtVendor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendor.DataField = "Vendor"
        Me.txtVendor.Height = 0.1875!
        Me.txtVendor.Left = 0.0!
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9pt; "
        Me.txtVendor.Text = Nothing
        Me.txtVendor.Top = 0.0!
        Me.txtVendor.Width = 1.9375!
        '
        'txtAdSize
        '
        Me.txtAdSize.Border.BottomColor = System.Drawing.Color.Black
        Me.txtAdSize.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSize.Border.LeftColor = System.Drawing.Color.Black
        Me.txtAdSize.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSize.Border.RightColor = System.Drawing.Color.Black
        Me.txtAdSize.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSize.Border.TopColor = System.Drawing.Color.Black
        Me.txtAdSize.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSize.DataField = "AdSize"
        Me.txtAdSize.Height = 0.1875!
        Me.txtAdSize.Left = 2.0!
        Me.txtAdSize.Name = "txtAdSize"
        Me.txtAdSize.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtAdSize.Text = Nothing
        Me.txtAdSize.Top = 0.0!
        Me.txtAdSize.Width = 0.9375!
        '
        'txtLocationofSign
        '
        Me.txtLocationofSign.Border.BottomColor = System.Drawing.Color.Black
        Me.txtLocationofSign.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLocationofSign.Border.LeftColor = System.Drawing.Color.Black
        Me.txtLocationofSign.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLocationofSign.Border.RightColor = System.Drawing.Color.Black
        Me.txtLocationofSign.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLocationofSign.Border.TopColor = System.Drawing.Color.Black
        Me.txtLocationofSign.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLocationofSign.DataField = "Location_of_Sign"
        Me.txtLocationofSign.Height = 0.1875!
        Me.txtLocationofSign.Left = 3.0!
        Me.txtLocationofSign.Name = "txtLocationofSign"
        Me.txtLocationofSign.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtLocationofSign.Text = Nothing
        Me.txtLocationofSign.Top = 0.0!
        Me.txtLocationofSign.Width = 1.4375!
        '
        'txtOverallSize
        '
        Me.txtOverallSize.Border.BottomColor = System.Drawing.Color.Black
        Me.txtOverallSize.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOverallSize.Border.LeftColor = System.Drawing.Color.Black
        Me.txtOverallSize.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOverallSize.Border.RightColor = System.Drawing.Color.Black
        Me.txtOverallSize.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOverallSize.Border.TopColor = System.Drawing.Color.Black
        Me.txtOverallSize.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtOverallSize.DataField = "Overall_Size"
        Me.txtOverallSize.Height = 0.1875!
        Me.txtOverallSize.Left = 4.5!
        Me.txtOverallSize.Name = "txtOverallSize"
        Me.txtOverallSize.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtOverallSize.Text = Nothing
        Me.txtOverallSize.Top = 0.0!
        Me.txtOverallSize.Width = 1.375!
        '
        'txtCopyArea
        '
        Me.txtCopyArea.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCopyArea.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCopyArea.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCopyArea.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCopyArea.Border.RightColor = System.Drawing.Color.Black
        Me.txtCopyArea.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCopyArea.Border.TopColor = System.Drawing.Color.Black
        Me.txtCopyArea.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCopyArea.DataField = "Copy_Area"
        Me.txtCopyArea.Height = 0.1875!
        Me.txtCopyArea.Left = 5.9375!
        Me.txtCopyArea.Name = "txtCopyArea"
        Me.txtCopyArea.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtCopyArea.Text = Nothing
        Me.txtCopyArea.Top = 0.0!
        Me.txtCopyArea.Width = 1.4375!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Height = 0.1979167!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.Visible = False
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.2291667!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.Visible = False
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
        Me.Line1.Left = 0.0!
        Me.Line1.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.25!
        Me.Line1.Width = 7.4375!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0.25!
        Me.Line1.Y2 = 0.25!
        '
        'arptJobSpecsVendorOut
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
        CType(Me.txtVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocationofSign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOverallSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCopyArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtVendor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAdSize As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLocationofSign As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOverallSize As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCopyArea As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
End Class
