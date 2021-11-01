<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptJobSpecsVendor
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptJobSpecsVendor))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtColor = New DataDynamics.ActiveReports.TextBox()
        Me.txtVendor = New DataDynamics.ActiveReports.TextBox()
        Me.txtCloseDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtStatus = New DataDynamics.ActiveReports.TextBox()
        Me.txtExtDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtDensity = New DataDynamics.ActiveReports.TextBox()
        Me.txtRunDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtRegion = New DataDynamics.ActiveReports.TextBox()
        Me.txtAdSize = New DataDynamics.ActiveReports.TextBox()
        Me.txtFilm = New DataDynamics.ActiveReports.TextBox()
        Me.txtBleedSize = New DataDynamics.ActiveReports.TextBox()
        Me.txtTrimSize = New DataDynamics.ActiveReports.TextBox()
        Me.txtLiveArea = New DataDynamics.ActiveReports.TextBox()
        Me.txtScreen = New DataDynamics.ActiveReports.TextBox()
        Me.txtShippingComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtSpecialInstructions = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.txtShippingCommentsCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtSpecialInstructionsCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtVendorName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAdSizeDesc = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCloseDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExtDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDensity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRunDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBleedSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTrimSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLiveArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtShippingComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSpecialInstructions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtShippingCommentsCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSpecialInstructionsCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdSizeDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtColor, Me.txtVendor, Me.txtCloseDate, Me.txtStatus, Me.txtExtDate, Me.txtDensity, Me.txtRunDate, Me.txtRegion, Me.txtAdSize, Me.txtFilm, Me.txtBleedSize, Me.txtTrimSize, Me.txtLiveArea, Me.txtScreen, Me.txtShippingComments, Me.txtSpecialInstructions, Me.Line1, Me.txtShippingCommentsCol, Me.txtSpecialInstructionsCol, Me.txtVendorName, Me.txtAdSizeDesc})
        Me.Detail1.Height = 0.8958333!
        Me.Detail1.KeepTogether = True
        Me.Detail1.Name = "Detail1"
        '
        'txtColor
        '
        Me.txtColor.DataField = "Color"
        Me.txtColor.Height = 0.1875!
        Me.txtColor.Left = 3.6875!
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.txtColor.Text = Nothing
        Me.txtColor.Top = 0.1875!
        Me.txtColor.Width = 0.6875!
        '
        'txtVendor
        '
        Me.txtVendor.DataField = "Vendor"
        Me.txtVendor.Height = 0.1875!
        Me.txtVendor.Left = 0.0!
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.txtVendor.Text = Nothing
        Me.txtVendor.Top = 0.0!
        Me.txtVendor.Width = 2.8125!
        '
        'txtCloseDate
        '
        Me.txtCloseDate.DataField = "Close_Date"
        Me.txtCloseDate.Height = 0.1875!
        Me.txtCloseDate.Left = 2.875!
        Me.txtCloseDate.Name = "txtCloseDate"
        Me.txtCloseDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCloseDate.Text = Nothing
        Me.txtCloseDate.Top = 0.0!
        Me.txtCloseDate.Width = 0.75!
        '
        'txtStatus
        '
        Me.txtStatus.DataField = "Status"
        Me.txtStatus.Height = 0.1875!
        Me.txtStatus.Left = 4.4375!
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtStatus.Text = Nothing
        Me.txtStatus.Top = 0.1875!
        Me.txtStatus.Width = 0.625!
        '
        'txtExtDate
        '
        Me.txtExtDate.DataField = "Ext_Date"
        Me.txtExtDate.Height = 0.1875!
        Me.txtExtDate.Left = 4.4375!
        Me.txtExtDate.Name = "txtExtDate"
        Me.txtExtDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtExtDate.Text = Nothing
        Me.txtExtDate.Top = 0.0!
        Me.txtExtDate.Width = 0.6875005!
        '
        'txtDensity
        '
        Me.txtDensity.DataField = "Density"
        Me.txtDensity.Height = 0.1875!
        Me.txtDensity.Left = 6.0!
        Me.txtDensity.Name = "txtDensity"
        Me.txtDensity.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtDensity.Text = Nothing
        Me.txtDensity.Top = 0.1875!
        Me.txtDensity.Width = 0.75!
        '
        'txtRunDate
        '
        Me.txtRunDate.DataField = "Run_Date"
        Me.txtRunDate.Height = 0.1875!
        Me.txtRunDate.Left = 3.6875!
        Me.txtRunDate.Name = "txtRunDate"
        Me.txtRunDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtRunDate.Text = Nothing
        Me.txtRunDate.Top = 0.0!
        Me.txtRunDate.Width = 0.6875!
        '
        'txtRegion
        '
        Me.txtRegion.DataField = "Region"
        Me.txtRegion.Height = 0.1875!
        Me.txtRegion.Left = 5.125!
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtRegion.Text = Nothing
        Me.txtRegion.Top = 0.1875!
        Me.txtRegion.Width = 0.8125!
        '
        'txtAdSize
        '
        Me.txtAdSize.DataField = "AdSize"
        Me.txtAdSize.Height = 0.1875!
        Me.txtAdSize.Left = 5.125!
        Me.txtAdSize.Name = "txtAdSize"
        Me.txtAdSize.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAdSize.Text = Nothing
        Me.txtAdSize.Top = 0.0!
        Me.txtAdSize.Width = 2.3125!
        '
        'txtFilm
        '
        Me.txtFilm.DataField = "Film"
        Me.txtFilm.Height = 0.1875!
        Me.txtFilm.Left = 6.8125!
        Me.txtFilm.Name = "txtFilm"
        Me.txtFilm.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtFilm.Text = Nothing
        Me.txtFilm.Top = 0.1875!
        Me.txtFilm.Width = 0.625!
        '
        'txtBleedSize
        '
        Me.txtBleedSize.DataField = "Bleed_Size"
        Me.txtBleedSize.Height = 0.1875!
        Me.txtBleedSize.Left = 0.0!
        Me.txtBleedSize.Name = "txtBleedSize"
        Me.txtBleedSize.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtBleedSize.Text = Nothing
        Me.txtBleedSize.Top = 0.1875!
        Me.txtBleedSize.Width = 0.9375!
        '
        'txtTrimSize
        '
        Me.txtTrimSize.DataField = "Trim_Size"
        Me.txtTrimSize.Height = 0.1875!
        Me.txtTrimSize.Left = 1.0!
        Me.txtTrimSize.Name = "txtTrimSize"
        Me.txtTrimSize.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtTrimSize.Text = Nothing
        Me.txtTrimSize.Top = 0.1875!
        Me.txtTrimSize.Width = 1.0!
        '
        'txtLiveArea
        '
        Me.txtLiveArea.DataField = "Live_Area"
        Me.txtLiveArea.Height = 0.1875!
        Me.txtLiveArea.Left = 2.0625!
        Me.txtLiveArea.Name = "txtLiveArea"
        Me.txtLiveArea.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtLiveArea.Text = Nothing
        Me.txtLiveArea.Top = 0.1875!
        Me.txtLiveArea.Width = 0.75!
        '
        'txtScreen
        '
        Me.txtScreen.DataField = "Screen"
        Me.txtScreen.Height = 0.1875!
        Me.txtScreen.Left = 2.875!
        Me.txtScreen.Name = "txtScreen"
        Me.txtScreen.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtScreen.Text = Nothing
        Me.txtScreen.Top = 0.1875!
        Me.txtScreen.Width = 0.75!
        '
        'txtShippingComments
        '
        Me.txtShippingComments.DataField = "Shipping_Comments"
        Me.txtShippingComments.Height = 0.1875!
        Me.txtShippingComments.Left = 1.3125!
        Me.txtShippingComments.Name = "txtShippingComments"
        Me.txtShippingComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtShippingComments.Text = Nothing
        Me.txtShippingComments.Top = 0.4375!
        Me.txtShippingComments.Width = 6.125!
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.DataField = "Special_Instructions"
        Me.txtSpecialInstructions.Height = 0.1875!
        Me.txtSpecialInstructions.Left = 1.3125!
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtSpecialInstructions.Text = Nothing
        Me.txtSpecialInstructions.Top = 0.625!
        Me.txtSpecialInstructions.Width = 6.125!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.875!
        Me.Line1.Width = 7.4375!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0.875!
        Me.Line1.Y2 = 0.875!
        '
        'txtShippingCommentsCol
        '
        Me.txtShippingCommentsCol.Height = 0.1875!
        Me.txtShippingCommentsCol.Left = 0.0!
        Me.txtShippingCommentsCol.Name = "txtShippingCommentsCol"
        Me.txtShippingCommentsCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtShippingCommentsCol.Text = "Shipping Comments:"
        Me.txtShippingCommentsCol.Top = 0.4375!
        Me.txtShippingCommentsCol.Width = 1.3125!
        '
        'txtSpecialInstructionsCol
        '
        Me.txtSpecialInstructionsCol.Height = 0.1875!
        Me.txtSpecialInstructionsCol.Left = 0.0!
        Me.txtSpecialInstructionsCol.Name = "txtSpecialInstructionsCol"
        Me.txtSpecialInstructionsCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtSpecialInstructionsCol.Text = "Special Instructions:"
        Me.txtSpecialInstructionsCol.Top = 0.625!
        Me.txtSpecialInstructionsCol.Width = 1.3125!
        '
        'txtVendorName
        '
        Me.txtVendorName.DataField = "Publication_Name"
        Me.txtVendorName.Height = 0.1875!
        Me.txtVendorName.Left = 2.625!
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Text = Nothing
        Me.txtVendorName.Top = 0.0!
        Me.txtVendorName.Visible = False
        Me.txtVendorName.Width = 0.1875!
        '
        'txtAdSizeDesc
        '
        Me.txtAdSizeDesc.DataField = "Size_Desc"
        Me.txtAdSizeDesc.Height = 0.1875!
        Me.txtAdSizeDesc.Left = 7.25!
        Me.txtAdSizeDesc.Name = "txtAdSizeDesc"
        Me.txtAdSizeDesc.Text = Nothing
        Me.txtAdSizeDesc.Top = 0.0!
        Me.txtAdSizeDesc.Visible = False
        Me.txtAdSizeDesc.Width = 0.1875!
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
        'arptJobSpecsVendor
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
        CType(Me.txtColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCloseDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExtDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDensity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRunDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBleedSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTrimSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLiveArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtShippingComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSpecialInstructions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtShippingCommentsCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSpecialInstructionsCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdSizeDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtColor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVendor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCloseDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtStatus As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtExtDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDensity As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRunDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRegion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAdSize As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFilm As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBleedSize As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTrimSize As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLiveArea As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtScreen As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtShippingComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSpecialInstructions As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtShippingCommentsCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSpecialInstructionsCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVendorName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAdSizeDesc As DataDynamics.ActiveReports.TextBox
End Class
