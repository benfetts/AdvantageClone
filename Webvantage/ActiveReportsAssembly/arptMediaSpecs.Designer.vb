<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptMediaSpecs
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptMediaSpecs))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtLblDesc = New DataDynamics.ActiveReports.TextBox
        Me.txtData = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.txtVendorLbl = New DataDynamics.ActiveReports.TextBox
        Me.txtVendor = New DataDynamics.ActiveReports.TextBox
        Me.txtVendorName = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.txtAdSizeLbl = New DataDynamics.ActiveReports.TextBox
        Me.txtAdSize = New DataDynamics.ActiveReports.TextBox
        Me.txtAdSizeDesc = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Line3 = New DataDynamics.ActiveReports.Line
        CType(Me.txtLblDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorLbl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdSizeLbl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdSizeDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtLblDesc, Me.txtData})
        Me.Detail1.Height = 0.21875!
        Me.Detail1.KeepTogether = True
        Me.Detail1.Name = "Detail1"
        '
        'txtLblDesc
        '
        Me.txtLblDesc.Border.BottomColor = System.Drawing.Color.Black
        Me.txtLblDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLblDesc.Border.LeftColor = System.Drawing.Color.Black
        Me.txtLblDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLblDesc.Border.RightColor = System.Drawing.Color.Black
        Me.txtLblDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLblDesc.Border.TopColor = System.Drawing.Color.Black
        Me.txtLblDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtLblDesc.DataField = "LABEL_DESC"
        Me.txtLblDesc.Height = 0.1875!
        Me.txtLblDesc.Left = 0.375!
        Me.txtLblDesc.Name = "txtLblDesc"
        Me.txtLblDesc.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; "
        Me.txtLblDesc.Text = Nothing
        Me.txtLblDesc.Top = 0.0!
        Me.txtLblDesc.Width = 1.125!
        '
        'txtData
        '
        Me.txtData.Border.BottomColor = System.Drawing.Color.Black
        Me.txtData.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtData.Border.LeftColor = System.Drawing.Color.Black
        Me.txtData.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtData.Border.RightColor = System.Drawing.Color.Black
        Me.txtData.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtData.Border.TopColor = System.Drawing.Color.Black
        Me.txtData.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtData.DataField = "DATA"
        Me.txtData.Height = 0.1875!
        Me.txtData.Left = 1.5!
        Me.txtData.Name = "txtData"
        Me.txtData.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtData.Text = Nothing
        Me.txtData.Top = 0.0!
        Me.txtData.Width = 5.9375!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtVendorLbl, Me.txtVendor, Me.txtVendorName, Me.Line3})
        Me.GroupHeader1.DataField = "VN_CODE"
        Me.GroupHeader1.Height = 0.2083333!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtVendorLbl
        '
        Me.txtVendorLbl.Border.BottomColor = System.Drawing.Color.Black
        Me.txtVendorLbl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendorLbl.Border.LeftColor = System.Drawing.Color.Black
        Me.txtVendorLbl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendorLbl.Border.RightColor = System.Drawing.Color.Black
        Me.txtVendorLbl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendorLbl.Border.TopColor = System.Drawing.Color.Black
        Me.txtVendorLbl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendorLbl.Height = 0.1875!
        Me.txtVendorLbl.Left = 0.0!
        Me.txtVendorLbl.Name = "txtVendorLbl"
        Me.txtVendorLbl.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.txtVendorLbl.Text = "Vendor:"
        Me.txtVendorLbl.Top = 0.0!
        Me.txtVendorLbl.Width = 0.5!
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
        Me.txtVendor.DataField = "VN_CODE"
        Me.txtVendor.Height = 0.1875!
        Me.txtVendor.Left = 0.5!
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtVendor.Text = Nothing
        Me.txtVendor.Top = 0.0!
        Me.txtVendor.Width = 6.875!
        '
        'txtVendorName
        '
        Me.txtVendorName.Border.BottomColor = System.Drawing.Color.Black
        Me.txtVendorName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendorName.Border.LeftColor = System.Drawing.Color.Black
        Me.txtVendorName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendorName.Border.RightColor = System.Drawing.Color.Black
        Me.txtVendorName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendorName.Border.TopColor = System.Drawing.Color.Black
        Me.txtVendorName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtVendorName.DataField = "VN_NAME"
        Me.txtVendorName.Height = 0.1875!
        Me.txtVendorName.Left = 7.3125!
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Style = ""
        Me.txtVendorName.Text = Nothing
        Me.txtVendorName.Top = 0.0!
        Me.txtVendorName.Visible = False
        Me.txtVendorName.Width = 0.125!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
        Me.GroupFooter1.Height = 0.02083333!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.Visible = False
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAdSizeLbl, Me.txtAdSize, Me.txtAdSizeDesc})
        Me.GroupHeader2.DataField = "AD_SIZE"
        Me.GroupHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader2.Height = 0.1979167!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'txtAdSizeLbl
        '
        Me.txtAdSizeLbl.Border.BottomColor = System.Drawing.Color.Black
        Me.txtAdSizeLbl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSizeLbl.Border.LeftColor = System.Drawing.Color.Black
        Me.txtAdSizeLbl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSizeLbl.Border.RightColor = System.Drawing.Color.Black
        Me.txtAdSizeLbl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSizeLbl.Border.TopColor = System.Drawing.Color.Black
        Me.txtAdSizeLbl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSizeLbl.Height = 0.1875!
        Me.txtAdSizeLbl.Left = 0.25!
        Me.txtAdSizeLbl.Name = "txtAdSizeLbl"
        Me.txtAdSizeLbl.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.txtAdSizeLbl.Text = "Ad Size:"
        Me.txtAdSizeLbl.Top = 0.0!
        Me.txtAdSizeLbl.Width = 0.5625!
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
        Me.txtAdSize.DataField = "AD_SIZE"
        Me.txtAdSize.Height = 0.1875!
        Me.txtAdSize.Left = 0.8125!
        Me.txtAdSize.Name = "txtAdSize"
        Me.txtAdSize.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtAdSize.Text = Nothing
        Me.txtAdSize.Top = 0.0!
        Me.txtAdSize.Width = 6.4375!
        '
        'txtAdSizeDesc
        '
        Me.txtAdSizeDesc.Border.BottomColor = System.Drawing.Color.Black
        Me.txtAdSizeDesc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSizeDesc.Border.LeftColor = System.Drawing.Color.Black
        Me.txtAdSizeDesc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSizeDesc.Border.RightColor = System.Drawing.Color.Black
        Me.txtAdSizeDesc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSizeDesc.Border.TopColor = System.Drawing.Color.Black
        Me.txtAdSizeDesc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAdSizeDesc.DataField = "SIZE_DESC"
        Me.txtAdSizeDesc.Height = 0.1875!
        Me.txtAdSizeDesc.Left = 7.3125!
        Me.txtAdSizeDesc.Name = "txtAdSizeDesc"
        Me.txtAdSizeDesc.Style = ""
        Me.txtAdSizeDesc.Text = Nothing
        Me.txtAdSizeDesc.Top = 0.0!
        Me.txtAdSizeDesc.Visible = False
        Me.txtAdSizeDesc.Width = 0.125!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1})
        Me.GroupFooter2.Height = 0.02083333!
        Me.GroupFooter2.Name = "GroupFooter2"
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
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 7.375!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.0!
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
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0!
        Me.Line2.Width = 7.4375!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 7.4375!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.0!
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
        Me.Line3.Left = 0.0!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.1875!
        Me.Line3.Width = 7.375!
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 7.375!
        Me.Line3.Y1 = 0.1875!
        Me.Line3.Y2 = 0.1875!
        '
        'arptMediaSpecs
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
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.txtLblDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorLbl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdSizeLbl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdSizeDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtVendorLbl As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVendor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVendorName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLblDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtData As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAdSizeLbl As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAdSize As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAdSizeDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
End Class
