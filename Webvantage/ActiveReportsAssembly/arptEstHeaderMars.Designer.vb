<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEstHeaderMars
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEstHeaderMars))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtAddressInfo = New DataDynamics.ActiveReports.TextBox()
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtContact = New DataDynamics.ActiveReports.TextBox()
        Me.txtClient = New DataDynamics.ActiveReports.TextBox()
        Me.txtDivision = New DataDynamics.ActiveReports.TextBox()
        Me.txtPhone = New DataDynamics.ActiveReports.TextBox()
        Me.txtCityStateZip = New DataDynamics.ActiveReports.TextBox()
        Me.txtFedID = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddress2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtFax = New DataDynamics.ActiveReports.TextBox()
        Me.txtEmail = New DataDynamics.ActiveReports.TextBox()
        Me.txtCDPContact = New DataDynamics.ActiveReports.TextBox()
        Me.txtCCAddress = New DataDynamics.ActiveReports.TextBox()
        Me.txtCCState = New DataDynamics.ActiveReports.TextBox()
        Me.txtCCZip = New DataDynamics.ActiveReports.TextBox()
        Me.txtCCAddress2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtCCCity = New DataDynamics.ActiveReports.TextBox()
        Me.txtCountry = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtAddressInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCityStateZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFedID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCDPContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCCAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCCState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCCZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCCAddress2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCCCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCountry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAddressInfo, Me.txtProduct, Me.txtContact, Me.txtClient, Me.txtDivision, Me.txtPhone, Me.txtCityStateZip, Me.txtFedID, Me.txtAddress2, Me.txtFax, Me.txtEmail, Me.txtCDPContact, Me.txtCCAddress, Me.txtCCState, Me.txtCCZip, Me.txtCCAddress2, Me.txtCCCity, Me.txtCountry})
        Me.Detail1.Height = 1.4375!
        Me.Detail1.Name = "Detail1"
        '
        'txtAddressInfo
        '
        Me.txtAddressInfo.CanShrink = True
        Me.txtAddressInfo.Height = 0.375!
        Me.txtAddressInfo.Left = 0.0!
        Me.txtAddressInfo.Name = "txtAddressInfo"
        Me.txtAddressInfo.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAddressInfo.Text = Nothing
        Me.txtAddressInfo.Top = 0.312!
        Me.txtAddressInfo.Width = 2.9375!
        '
        'txtProduct
        '
        Me.txtProduct.CanShrink = True
        Me.txtProduct.DataField = "PRD_DESCRIPTION"
        Me.txtProduct.Height = 0.0625!
        Me.txtProduct.Left = 0.0!
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtProduct.Text = Nothing
        Me.txtProduct.Top = 0.249!
        Me.txtProduct.Width = 2.9375!
        '
        'txtContact
        '
        Me.txtContact.CanShrink = True
        Me.txtContact.Height = 0.125!
        Me.txtContact.Left = 0.0!
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtContact.Text = Nothing
        Me.txtContact.Top = 0.0!
        Me.txtContact.Width = 2.9375!
        '
        'txtClient
        '
        Me.txtClient.CanShrink = True
        Me.txtClient.DataField = "CL_NAME"
        Me.txtClient.Height = 0.0625!
        Me.txtClient.Left = 0.0!
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtClient.Text = Nothing
        Me.txtClient.Top = 0.124!
        Me.txtClient.Width = 2.9375!
        '
        'txtDivision
        '
        Me.txtDivision.CanShrink = True
        Me.txtDivision.DataField = "DIV_NAME"
        Me.txtDivision.Height = 0.0625!
        Me.txtDivision.Left = 0.0!
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtDivision.Text = Nothing
        Me.txtDivision.Top = 0.1865!
        Me.txtDivision.Width = 2.9375!
        '
        'txtPhone
        '
        Me.txtPhone.CanShrink = True
        Me.txtPhone.Height = 0.0625!
        Me.txtPhone.Left = 0.8745!
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtPhone.Text = Nothing
        Me.txtPhone.Top = 0.812!
        Me.txtPhone.Visible = False
        Me.txtPhone.Width = 0.1875!
        '
        'txtCityStateZip
        '
        Me.txtCityStateZip.CanShrink = True
        Me.txtCityStateZip.Height = 0.0625!
        Me.txtCityStateZip.Left = 1.1245!
        Me.txtCityStateZip.Name = "txtCityStateZip"
        Me.txtCityStateZip.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCityStateZip.Text = Nothing
        Me.txtCityStateZip.Top = 0.812!
        Me.txtCityStateZip.Visible = False
        Me.txtCityStateZip.Width = 0.1875!
        '
        'txtFedID
        '
        Me.txtFedID.CanShrink = True
        Me.txtFedID.Height = 0.0625!
        Me.txtFedID.Left = 1.8125!
        Me.txtFedID.Name = "txtFedID"
        Me.txtFedID.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtFedID.Text = Nothing
        Me.txtFedID.Top = 0.812!
        Me.txtFedID.Visible = False
        Me.txtFedID.Width = 0.125!
        '
        'txtAddress2
        '
        Me.txtAddress2.CanShrink = True
        Me.txtAddress2.Height = 0.0625!
        Me.txtAddress2.Left = 0.8745!
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Style = "font-size: 9pt"
        Me.txtAddress2.Text = Nothing
        Me.txtAddress2.Top = 0.937!
        Me.txtAddress2.Visible = False
        Me.txtAddress2.Width = 0.1875!
        '
        'txtFax
        '
        Me.txtFax.CanShrink = True
        Me.txtFax.Height = 0.0625!
        Me.txtFax.Left = 1.3745!
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Style = "font-size: 9pt"
        Me.txtFax.Text = Nothing
        Me.txtFax.Top = 0.8120001!
        Me.txtFax.Visible = False
        Me.txtFax.Width = 0.125!
        '
        'txtEmail
        '
        Me.txtEmail.CanShrink = True
        Me.txtEmail.Height = 0.0625!
        Me.txtEmail.Left = 1.625!
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Style = "font-size: 9pt"
        Me.txtEmail.Text = Nothing
        Me.txtEmail.Top = 0.812!
        Me.txtEmail.Visible = False
        Me.txtEmail.Width = 0.125!
        '
        'txtCDPContact
        '
        Me.txtCDPContact.DataField = "CONT_FML"
        Me.txtCDPContact.Height = 0.1875!
        Me.txtCDPContact.Left = 0.437!
        Me.txtCDPContact.Name = "txtCDPContact"
        Me.txtCDPContact.Text = Nothing
        Me.txtCDPContact.Top = 0.812!
        Me.txtCDPContact.Visible = False
        Me.txtCDPContact.Width = 0.125!
        '
        'txtCCAddress
        '
        Me.txtCCAddress.CanShrink = True
        Me.txtCCAddress.DataField = "CONT_ADDRESS1"
        Me.txtCCAddress.Height = 0.0625!
        Me.txtCCAddress.Left = 2.0!
        Me.txtCCAddress.Name = "txtCCAddress"
        Me.txtCCAddress.Style = "font-size: 9pt"
        Me.txtCCAddress.Text = Nothing
        Me.txtCCAddress.Top = 0.812!
        Me.txtCCAddress.Visible = False
        Me.txtCCAddress.Width = 0.1875!
        '
        'txtCCState
        '
        Me.txtCCState.CanShrink = True
        Me.txtCCState.DataField = "CONT_STATE"
        Me.txtCCState.Height = 0.0625!
        Me.txtCCState.Left = 1.5!
        Me.txtCCState.Name = "txtCCState"
        Me.txtCCState.Style = "font-size: 9pt"
        Me.txtCCState.Text = Nothing
        Me.txtCCState.Top = 0.937!
        Me.txtCCState.Visible = False
        Me.txtCCState.Width = 0.1875!
        '
        'txtCCZip
        '
        Me.txtCCZip.CanShrink = True
        Me.txtCCZip.DataField = "CONT_ZIP"
        Me.txtCCZip.Height = 0.0625!
        Me.txtCCZip.Left = 1.75!
        Me.txtCCZip.Name = "txtCCZip"
        Me.txtCCZip.Style = "font-size: 9pt"
        Me.txtCCZip.Text = Nothing
        Me.txtCCZip.Top = 0.937!
        Me.txtCCZip.Visible = False
        Me.txtCCZip.Width = 0.1875!
        '
        'txtCCAddress2
        '
        Me.txtCCAddress2.CanShrink = True
        Me.txtCCAddress2.DataField = "CONT_ADDRESS2"
        Me.txtCCAddress2.Height = 0.0625!
        Me.txtCCAddress2.Left = 1.2495!
        Me.txtCCAddress2.Name = "txtCCAddress2"
        Me.txtCCAddress2.Style = "font-size: 9pt"
        Me.txtCCAddress2.Text = Nothing
        Me.txtCCAddress2.Top = 0.937!
        Me.txtCCAddress2.Visible = False
        Me.txtCCAddress2.Width = 0.1875!
        '
        'txtCCCity
        '
        Me.txtCCCity.CanShrink = True
        Me.txtCCCity.DataField = "CONT_CITY"
        Me.txtCCCity.Height = 0.0625!
        Me.txtCCCity.Left = 2.0!
        Me.txtCCCity.Name = "txtCCCity"
        Me.txtCCCity.Style = "font-size: 9pt"
        Me.txtCCCity.Text = Nothing
        Me.txtCCCity.Top = 0.937!
        Me.txtCCCity.Visible = False
        Me.txtCCCity.Width = 0.1875!
        '
        'txtCountry
        '
        Me.txtCountry.CanShrink = True
        Me.txtCountry.DataField = "CONT_COUNTRY"
        Me.txtCountry.Height = 0.0625!
        Me.txtCountry.Left = 2.25!
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Style = "font-size: 9pt"
        Me.txtCountry.Text = Nothing
        Me.txtCountry.Top = 0.9370002!
        Me.txtCountry.Visible = False
        Me.txtCountry.Width = 0.1875!
        '
        'arptEstHeaderMars
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 3.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.Detail1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txtAddressInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCityStateZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFedID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddress2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCDPContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCCAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCCState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCCZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCCAddress2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCCCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCountry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents txtAddressInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContact As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPhone As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCityStateZip As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFedID As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddress2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEmail As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCDPContact As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCCAddress As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCCState As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCCZip As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCCAddress2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCCCity As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtCountry As DataDynamics.ActiveReports.TextBox
End Class
