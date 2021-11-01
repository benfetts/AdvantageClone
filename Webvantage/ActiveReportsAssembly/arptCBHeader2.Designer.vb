<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptCBHeader2 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptCBHeader2))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtOpened = New DataDynamics.ActiveReports.TextBox()
        Me.txtOpenedBy = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddress = New DataDynamics.ActiveReports.TextBox()
        Me.txtDue = New DataDynamics.ActiveReports.TextBox()
        Me.lblBudget = New DataDynamics.ActiveReports.TextBox()
        Me.lblOpenedBy = New DataDynamics.ActiveReports.TextBox()
        Me.lblDue = New DataDynamics.ActiveReports.TextBox()
        Me.lblRushChargesApproved = New DataDynamics.ActiveReports.TextBox()
        Me.lblApprEstReq = New DataDynamics.ActiveReports.TextBox()
        Me.lblOpened = New DataDynamics.ActiveReports.TextBox()
        Me.lblAddress = New DataDynamics.ActiveReports.TextBox()
        Me.txtBudget = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.txtOpened, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOpenedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOpenedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRushChargesApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblApprEstReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOpened, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Height = 0.003472222!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtOpened, Me.txtOpenedBy, Me.txtAddress, Me.txtDue, Me.lblBudget, Me.lblOpenedBy, Me.lblDue, Me.lblRushChargesApproved, Me.lblApprEstReq, Me.lblOpened, Me.lblAddress, Me.txtBudget})
        Me.Detail1.Height = 0.4131944!
        Me.Detail1.Name = "Detail1"
        '
        'txtOpened
        '
        Me.txtOpened.CanShrink = True
        Me.txtOpened.Height = 0.0625!
        Me.txtOpened.Left = 0.75!
        Me.txtOpened.Name = "txtOpened"
        Me.txtOpened.OutputFormat = resources.GetString("txtOpened.OutputFormat")
        Me.txtOpened.Style = "font-family: Arial; font-size: 8.25pt; font-weight: normal; text-align: left; ddo" & _
    "-char-set: 1"
        Me.txtOpened.Text = "txtOpened"
        Me.txtOpened.Top = 0.125!
        Me.txtOpened.Width = 0.9375!
        '
        'txtOpenedBy
        '
        Me.txtOpenedBy.CanShrink = True
        Me.txtOpenedBy.Height = 0.0625!
        Me.txtOpenedBy.Left = 0.75!
        Me.txtOpenedBy.Name = "txtOpenedBy"
        Me.txtOpenedBy.Style = "font-family: Arial; font-size: 8.25pt; font-weight: normal; text-align: left; ddo" & _
    "-char-set: 1"
        Me.txtOpenedBy.Text = "txtOpenedBy"
        Me.txtOpenedBy.Top = 0.0625!
        Me.txtOpenedBy.Width = 2.4375!
        '
        'txtAddress
        '
        Me.txtAddress.CanShrink = True
        Me.txtAddress.Height = 0.0625!
        Me.txtAddress.Left = 0.75!
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Style = "font-family: Arial; font-size: 8.25pt; font-weight: normal; text-align: left; ddo" & _
    "-char-set: 1"
        Me.txtAddress.Text = "txtAddress"
        Me.txtAddress.Top = 0.0!
        Me.txtAddress.Width = 2.4375!
        '
        'txtDue
        '
        Me.txtDue.Height = 0.0625!
        Me.txtDue.Left = 2.25!
        Me.txtDue.Name = "txtDue"
        Me.txtDue.OutputFormat = resources.GetString("txtDue.OutputFormat")
        Me.txtDue.Style = "font-size: 8.25pt; font-weight: normal; text-align: left"
        Me.txtDue.Text = "txtDue"
        Me.txtDue.Top = 0.125!
        Me.txtDue.Width = 0.9375!
        '
        'lblBudget
        '
        Me.lblBudget.CanShrink = True
        Me.lblBudget.Height = 0.0625!
        Me.lblBudget.Left = 0.0!
        Me.lblBudget.Name = "lblBudget"
        Me.lblBudget.OutputFormat = resources.GetString("lblBudget.OutputFormat")
        Me.lblBudget.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: left; ddo-c" & _
    "har-set: 1"
        Me.lblBudget.Text = "Budget:"
        Me.lblBudget.Top = 0.3125!
        Me.lblBudget.Width = 0.75!
        '
        'lblOpenedBy
        '
        Me.lblOpenedBy.CanShrink = True
        Me.lblOpenedBy.Height = 0.0625!
        Me.lblOpenedBy.Left = 0.0!
        Me.lblOpenedBy.Name = "lblOpenedBy"
        Me.lblOpenedBy.OutputFormat = resources.GetString("lblOpenedBy.OutputFormat")
        Me.lblOpenedBy.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: left; ddo-c" & _
    "har-set: 1"
        Me.lblOpenedBy.Text = "Opened by:"
        Me.lblOpenedBy.Top = 0.0625!
        Me.lblOpenedBy.Width = 0.75!
        '
        'lblDue
        '
        Me.lblDue.CanShrink = True
        Me.lblDue.Height = 0.0625!
        Me.lblDue.Left = 1.875!
        Me.lblDue.Name = "lblDue"
        Me.lblDue.OutputFormat = resources.GetString("lblDue.OutputFormat")
        Me.lblDue.Style = "font-size: 8.25pt; font-weight: bold; text-align: left"
        Me.lblDue.Text = "Due:"
        Me.lblDue.Top = 0.125!
        Me.lblDue.Width = 0.375!
        '
        'lblRushChargesApproved
        '
        Me.lblRushChargesApproved.CanShrink = True
        Me.lblRushChargesApproved.Height = 0.0625!
        Me.lblRushChargesApproved.Left = 0.75!
        Me.lblRushChargesApproved.Name = "lblRushChargesApproved"
        Me.lblRushChargesApproved.OutputFormat = resources.GetString("lblRushChargesApproved.OutputFormat")
        Me.lblRushChargesApproved.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: left; ddo-c" & _
    "har-set: 1"
        Me.lblRushChargesApproved.Text = "Rush Charges Approved"
        Me.lblRushChargesApproved.Top = 0.25!
        Me.lblRushChargesApproved.Width = 1.75!
        '
        'lblApprEstReq
        '
        Me.lblApprEstReq.CanShrink = True
        Me.lblApprEstReq.Height = 0.0625!
        Me.lblApprEstReq.Left = 0.75!
        Me.lblApprEstReq.Name = "lblApprEstReq"
        Me.lblApprEstReq.OutputFormat = resources.GetString("lblApprEstReq.OutputFormat")
        Me.lblApprEstReq.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: left; ddo-c" & _
    "har-set: 1"
        Me.lblApprEstReq.Text = "Approved Estimate Required"
        Me.lblApprEstReq.Top = 0.1875!
        Me.lblApprEstReq.Width = 1.8125!
        '
        'lblOpened
        '
        Me.lblOpened.CanShrink = True
        Me.lblOpened.Height = 0.0625!
        Me.lblOpened.Left = 0.0!
        Me.lblOpened.Name = "lblOpened"
        Me.lblOpened.OutputFormat = resources.GetString("lblOpened.OutputFormat")
        Me.lblOpened.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: left; ddo-c" & _
    "har-set: 1"
        Me.lblOpened.Text = "Opened:"
        Me.lblOpened.Top = 0.125!
        Me.lblOpened.Width = 0.75!
        '
        'lblAddress
        '
        Me.lblAddress.CanShrink = True
        Me.lblAddress.Height = 0.0625!
        Me.lblAddress.Left = 0.0!
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.OutputFormat = resources.GetString("lblAddress.OutputFormat")
        Me.lblAddress.Style = "font-family: Arial; font-size: 8.25pt; font-weight: bold; text-align: left; ddo-c" & _
    "har-set: 1"
        Me.lblAddress.Text = "Address:"
        Me.lblAddress.Top = 0.0!
        Me.lblAddress.Width = 0.75!
        '
        'txtBudget
        '
        Me.txtBudget.CanShrink = True
        Me.txtBudget.Height = 0.0625!
        Me.txtBudget.Left = 0.75!
        Me.txtBudget.Name = "txtBudget"
        Me.txtBudget.OutputFormat = resources.GetString("txtBudget.OutputFormat")
        Me.txtBudget.Style = "font-family: Arial; font-size: 8.25pt; font-weight: normal; text-align: left; ddo" & _
    "-char-set: 1"
        Me.txtBudget.Text = "txtBudget"
        Me.txtBudget.Top = 0.3125!
        Me.txtBudget.Width = 1.8125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'arptCBHeader2
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 3.46875!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtOpened, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOpenedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOpenedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRushChargesApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblApprEstReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOpened, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents txtOpened As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOpenedBy As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddress As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDue As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblBudget As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblOpenedBy As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDue As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblRushChargesApproved As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblApprEstReq As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblOpened As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAddress As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBudget As DataDynamics.ActiveReports.TextBox
End Class
