<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptClientARStatement005
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptClientARStatement005))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.PrtAddr1 = New DataDynamics.ActiveReports.Label()
        Me.PrtAddr2 = New DataDynamics.ActiveReports.Label()
        Me.AgencyAddress2 = New DataDynamics.ActiveReports.Label()
        Me.AgencyAddress1 = New DataDynamics.ActiveReports.Label()
        Me.PrtCity = New DataDynamics.ActiveReports.Label()
        Me.AgencyCity = New DataDynamics.ActiveReports.Label()
        Me.PrtState = New DataDynamics.ActiveReports.Label()
        Me.AgencyState = New DataDynamics.ActiveReports.Label()
        Me.PrtZip = New DataDynamics.ActiveReports.Label()
        Me.AgencyZip = New DataDynamics.ActiveReports.Label()
        Me.AgencyFax = New DataDynamics.ActiveReports.Label()
        Me.AgencyEmail = New DataDynamics.ActiveReports.Label()
        Me.PrtPhone = New DataDynamics.ActiveReports.Label()
        Me.AgencyPhone = New DataDynamics.ActiveReports.Label()
        Me.PrtFax = New DataDynamics.ActiveReports.Label()
        Me.PrtEmail = New DataDynamics.ActiveReports.Label()
        Me.AgencyName = New DataDynamics.ActiveReports.TextBox()
        Me.AgencyInfo = New DataDynamics.ActiveReports.TextBox()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.LogoPath = New DataDynamics.ActiveReports.Label()
        Me.PrtName = New DataDynamics.ActiveReports.Label()
        Me.PrtHeader = New DataDynamics.ActiveReports.Label()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.OriginalAmount = New DataDynamics.ActiveReports.Label()
        Me.InvoiceNumber = New DataDynamics.ActiveReports.TextBox()
        Me.InvoiceDate = New DataDynamics.ActiveReports.TextBox()
        Me.Reference = New DataDynamics.ActiveReports.TextBox()
        Me.Description = New DataDynamics.ActiveReports.TextBox()
        Me.InvoiceAmount = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.Footer = New DataDynamics.ActiveReports.Label()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.Label32 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.SCity = New DataDynamics.ActiveReports.Label()
        Me.SAddress1 = New DataDynamics.ActiveReports.Label()
        Me.SAddress2 = New DataDynamics.ActiveReports.Label()
        Me.SState = New DataDynamics.ActiveReports.Label()
        Me.AddressUse = New DataDynamics.ActiveReports.Label()
        Me.CCity = New DataDynamics.ActiveReports.Label()
        Me.SZip = New DataDynamics.ActiveReports.Label()
        Me.CState = New DataDynamics.ActiveReports.Label()
        Me.CZip = New DataDynamics.ActiveReports.Label()
        Me.CAddress1 = New DataDynamics.ActiveReports.Label()
        Me.CAddress2 = New DataDynamics.ActiveReports.Label()
        Me.LastName = New DataDynamics.ActiveReports.Label()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.ClientName = New DataDynamics.ActiveReports.TextBox()
        Me.FirstName = New DataDynamics.ActiveReports.TextBox()
        Me.Comments = New DataDynamics.ActiveReports.TextBox()
        Me.DateAR = New DataDynamics.ActiveReports.TextBox()
        Me.ContactCode = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label30 = New DataDynamics.ActiveReports.Label()
        Me.Total = New DataDynamics.ActiveReports.Label()
        Me.OnAccount = New DataDynamics.ActiveReports.Label()
        Me.OnAccountAmount = New DataDynamics.ActiveReports.Label()
        Me.LessPayments = New DataDynamics.ActiveReports.Label()
        Me.OnAcc = New DataDynamics.ActiveReports.Label()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.CommentsFooter = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.Label25 = New DataDynamics.ActiveReports.Label()
        Me.CurrentAR = New DataDynamics.ActiveReports.Label()
        Me.OverThirtyAR = New DataDynamics.ActiveReports.Label()
        Me.OverSixtyAR = New DataDynamics.ActiveReports.Label()
        Me.TotalAR = New DataDynamics.ActiveReports.Label()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter()
        Me.TextboxInvoiceComments = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        CType(Me.PrtAddr1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtAddr2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyAddress2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgencyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoPath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrtHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OriginalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Reference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Description, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Footer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAddress2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressUse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAddress2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LastName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Comments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnAccountAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LessPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommentsFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OverThirtyAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OverSixtyAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextboxInvoiceComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.PrtAddr1, Me.PrtAddr2, Me.AgencyAddress2, Me.AgencyAddress1, Me.PrtCity, Me.AgencyCity, Me.PrtState, Me.AgencyState, Me.PrtZip, Me.AgencyZip, Me.AgencyFax, Me.AgencyEmail, Me.PrtPhone, Me.AgencyPhone, Me.PrtFax, Me.PrtEmail, Me.AgencyName, Me.AgencyInfo, Me.Picture1, Me.LogoPath, Me.PrtName, Me.PrtHeader})
        Me.PageHeader1.Height = 1.802083!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.062!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.75!
        Me.Line2.Width = 7.375!
        Me.Line2.X1 = 0.062!
        Me.Line2.X2 = 7.437!
        Me.Line2.Y1 = 1.75!
        Me.Line2.Y2 = 1.75!
        '
        'PrtAddr1
        '
        Me.PrtAddr1.DataField = "PrtAddr1"
        Me.PrtAddr1.Height = 0.1875!
        Me.PrtAddr1.HyperLink = Nothing
        Me.PrtAddr1.Left = 6.062!
        Me.PrtAddr1.Name = "PrtAddr1"
        Me.PrtAddr1.Style = ""
        Me.PrtAddr1.Text = "PrtAddr1"
        Me.PrtAddr1.Top = 2.437!
        Me.PrtAddr1.Visible = False
        Me.PrtAddr1.Width = 0.125!
        '
        'PrtAddr2
        '
        Me.PrtAddr2.DataField = "PrtAddr2"
        Me.PrtAddr2.Height = 0.1875!
        Me.PrtAddr2.HyperLink = Nothing
        Me.PrtAddr2.Left = 6.2495!
        Me.PrtAddr2.Name = "PrtAddr2"
        Me.PrtAddr2.Style = ""
        Me.PrtAddr2.Text = "PrtAddr2"
        Me.PrtAddr2.Top = 2.437!
        Me.PrtAddr2.Visible = False
        Me.PrtAddr2.Width = 0.125!
        '
        'AgencyAddress2
        '
        Me.AgencyAddress2.DataField = "AgencyAddress2"
        Me.AgencyAddress2.Height = 0.1875!
        Me.AgencyAddress2.HyperLink = Nothing
        Me.AgencyAddress2.Left = 6.2495!
        Me.AgencyAddress2.Name = "AgencyAddress2"
        Me.AgencyAddress2.Style = ""
        Me.AgencyAddress2.Text = "AgencyAddress2"
        Me.AgencyAddress2.Top = 2.687!
        Me.AgencyAddress2.Visible = False
        Me.AgencyAddress2.Width = 0.125!
        '
        'AgencyAddress1
        '
        Me.AgencyAddress1.DataField = "AgencyAddress1"
        Me.AgencyAddress1.Height = 0.1875!
        Me.AgencyAddress1.HyperLink = Nothing
        Me.AgencyAddress1.Left = 6.062!
        Me.AgencyAddress1.Name = "AgencyAddress1"
        Me.AgencyAddress1.Style = ""
        Me.AgencyAddress1.Text = "AgencyAddress1"
        Me.AgencyAddress1.Top = 2.687!
        Me.AgencyAddress1.Visible = False
        Me.AgencyAddress1.Width = 0.125!
        '
        'PrtCity
        '
        Me.PrtCity.DataField = "PrtCity"
        Me.PrtCity.Height = 0.1875!
        Me.PrtCity.HyperLink = Nothing
        Me.PrtCity.Left = 6.437!
        Me.PrtCity.Name = "PrtCity"
        Me.PrtCity.Style = ""
        Me.PrtCity.Text = "PrtCity"
        Me.PrtCity.Top = 2.437!
        Me.PrtCity.Visible = False
        Me.PrtCity.Width = 0.125!
        '
        'AgencyCity
        '
        Me.AgencyCity.DataField = "AgencyCity"
        Me.AgencyCity.Height = 0.1875!
        Me.AgencyCity.HyperLink = Nothing
        Me.AgencyCity.Left = 6.437!
        Me.AgencyCity.Name = "AgencyCity"
        Me.AgencyCity.Style = ""
        Me.AgencyCity.Text = "AgencyCity"
        Me.AgencyCity.Top = 2.687!
        Me.AgencyCity.Visible = False
        Me.AgencyCity.Width = 0.125!
        '
        'PrtState
        '
        Me.PrtState.DataField = "PrtState"
        Me.PrtState.Height = 0.1875!
        Me.PrtState.HyperLink = Nothing
        Me.PrtState.Left = 6.6245!
        Me.PrtState.Name = "PrtState"
        Me.PrtState.Style = ""
        Me.PrtState.Text = "PrtState"
        Me.PrtState.Top = 2.437!
        Me.PrtState.Visible = False
        Me.PrtState.Width = 0.125!
        '
        'AgencyState
        '
        Me.AgencyState.DataField = "AgencyState"
        Me.AgencyState.Height = 0.1875!
        Me.AgencyState.HyperLink = Nothing
        Me.AgencyState.Left = 6.6245!
        Me.AgencyState.Name = "AgencyState"
        Me.AgencyState.Style = ""
        Me.AgencyState.Text = "AgencyState"
        Me.AgencyState.Top = 2.687!
        Me.AgencyState.Visible = False
        Me.AgencyState.Width = 0.125!
        '
        'PrtZip
        '
        Me.PrtZip.DataField = "PrtZip"
        Me.PrtZip.Height = 0.1875!
        Me.PrtZip.HyperLink = Nothing
        Me.PrtZip.Left = 6.812!
        Me.PrtZip.Name = "PrtZip"
        Me.PrtZip.Style = ""
        Me.PrtZip.Text = "PrtZip"
        Me.PrtZip.Top = 2.437!
        Me.PrtZip.Visible = False
        Me.PrtZip.Width = 0.125!
        '
        'AgencyZip
        '
        Me.AgencyZip.DataField = "AgencyZip"
        Me.AgencyZip.Height = 0.1875!
        Me.AgencyZip.HyperLink = Nothing
        Me.AgencyZip.Left = 6.812!
        Me.AgencyZip.Name = "AgencyZip"
        Me.AgencyZip.Style = ""
        Me.AgencyZip.Text = "AgencyZip"
        Me.AgencyZip.Top = 2.687!
        Me.AgencyZip.Visible = False
        Me.AgencyZip.Width = 0.125!
        '
        'AgencyFax
        '
        Me.AgencyFax.DataField = "AgencyFax"
        Me.AgencyFax.Height = 0.1875!
        Me.AgencyFax.HyperLink = Nothing
        Me.AgencyFax.Left = 7.187!
        Me.AgencyFax.Name = "AgencyFax"
        Me.AgencyFax.Style = ""
        Me.AgencyFax.Text = "AgencyFax"
        Me.AgencyFax.Top = 2.687!
        Me.AgencyFax.Visible = False
        Me.AgencyFax.Width = 0.125!
        '
        'AgencyEmail
        '
        Me.AgencyEmail.DataField = "AgencyEmail"
        Me.AgencyEmail.Height = 0.1875!
        Me.AgencyEmail.HyperLink = Nothing
        Me.AgencyEmail.Left = 7.3745!
        Me.AgencyEmail.Name = "AgencyEmail"
        Me.AgencyEmail.Style = ""
        Me.AgencyEmail.Text = "AgencyEmail"
        Me.AgencyEmail.Top = 2.687!
        Me.AgencyEmail.Visible = False
        Me.AgencyEmail.Width = 0.125!
        '
        'PrtPhone
        '
        Me.PrtPhone.DataField = "PrtPhone"
        Me.PrtPhone.Height = 0.1875!
        Me.PrtPhone.HyperLink = Nothing
        Me.PrtPhone.Left = 6.9995!
        Me.PrtPhone.Name = "PrtPhone"
        Me.PrtPhone.Style = ""
        Me.PrtPhone.Text = "PrtPhone"
        Me.PrtPhone.Top = 2.437!
        Me.PrtPhone.Visible = False
        Me.PrtPhone.Width = 0.125!
        '
        'AgencyPhone
        '
        Me.AgencyPhone.DataField = "AgencyPhone"
        Me.AgencyPhone.Height = 0.1875!
        Me.AgencyPhone.HyperLink = Nothing
        Me.AgencyPhone.Left = 6.9995!
        Me.AgencyPhone.Name = "AgencyPhone"
        Me.AgencyPhone.Style = ""
        Me.AgencyPhone.Text = "AgencyPhone"
        Me.AgencyPhone.Top = 2.687!
        Me.AgencyPhone.Visible = False
        Me.AgencyPhone.Width = 0.125!
        '
        'PrtFax
        '
        Me.PrtFax.DataField = "PrtFax"
        Me.PrtFax.Height = 0.1875!
        Me.PrtFax.HyperLink = Nothing
        Me.PrtFax.Left = 7.187!
        Me.PrtFax.Name = "PrtFax"
        Me.PrtFax.Style = ""
        Me.PrtFax.Text = "PrtFax"
        Me.PrtFax.Top = 2.437!
        Me.PrtFax.Visible = False
        Me.PrtFax.Width = 0.125!
        '
        'PrtEmail
        '
        Me.PrtEmail.DataField = "PrtEmail"
        Me.PrtEmail.Height = 0.1875!
        Me.PrtEmail.HyperLink = Nothing
        Me.PrtEmail.Left = 7.3745!
        Me.PrtEmail.Name = "PrtEmail"
        Me.PrtEmail.Style = ""
        Me.PrtEmail.Text = "PrtEmail"
        Me.PrtEmail.Top = 2.437!
        Me.PrtEmail.Visible = False
        Me.PrtEmail.Width = 0.125!
        '
        'AgencyName
        '
        Me.AgencyName.CanShrink = True
        Me.AgencyName.DataField = "AgencyName"
        Me.AgencyName.Height = 0.1875!
        Me.AgencyName.Left = 0.062!
        Me.AgencyName.Name = "AgencyName"
        Me.AgencyName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.AgencyName.Text = "AgencyName"
        Me.AgencyName.Top = 2.187!
        Me.AgencyName.Width = 7.4375!
        '
        'AgencyInfo
        '
        Me.AgencyInfo.CanShrink = True
        Me.AgencyInfo.DataField = "AgencyInfo"
        Me.AgencyInfo.Height = 0.187!
        Me.AgencyInfo.Left = 0.062!
        Me.AgencyInfo.Name = "AgencyInfo"
        Me.AgencyInfo.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.AgencyInfo.Text = "AgencyInfo"
        Me.AgencyInfo.Top = 1.5!
        Me.AgencyInfo.Width = 7.4375!
        '
        'Picture1
        '
        Me.Picture1.Height = 1.5!
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.0625!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft
        Me.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.Picture1.Top = 0!
        Me.Picture1.Width = 7.45!
        '
        'LogoPath
        '
        Me.LogoPath.DataField = "LogoPath"
        Me.LogoPath.Height = 0.1875!
        Me.LogoPath.HyperLink = Nothing
        Me.LogoPath.Left = 7.312!
        Me.LogoPath.Name = "LogoPath"
        Me.LogoPath.Style = ""
        Me.LogoPath.Text = "LogoPath"
        Me.LogoPath.Top = 2.937!
        Me.LogoPath.Visible = False
        Me.LogoPath.Width = 0.125!
        '
        'PrtName
        '
        Me.PrtName.DataField = "PrtName"
        Me.PrtName.Height = 0.1875!
        Me.PrtName.HyperLink = Nothing
        Me.PrtName.Left = 5.9995!
        Me.PrtName.Name = "PrtName"
        Me.PrtName.Style = ""
        Me.PrtName.Text = "PrtAddr1"
        Me.PrtName.Top = 2.937!
        Me.PrtName.Visible = False
        Me.PrtName.Width = 0.125!
        '
        'PrtHeader
        '
        Me.PrtHeader.DataField = "PrtHeader"
        Me.PrtHeader.Height = 0.1875!
        Me.PrtHeader.HyperLink = Nothing
        Me.PrtHeader.Left = 6.2495!
        Me.PrtHeader.Name = "PrtHeader"
        Me.PrtHeader.Style = ""
        Me.PrtHeader.Text = "PrtAddr1"
        Me.PrtHeader.Top = 2.937!
        Me.PrtHeader.Visible = False
        Me.PrtHeader.Width = 0.125!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.OriginalAmount, Me.InvoiceNumber, Me.InvoiceDate, Me.Reference, Me.Description, Me.InvoiceAmount, Me.TextboxInvoiceComments})
        Me.Detail1.Height = 0.3020833!
        Me.Detail1.Name = "Detail1"
        '
        'OriginalAmount
        '
        Me.OriginalAmount.DataField = "OriginalAmount"
        Me.OriginalAmount.Height = 0.1875!
        Me.OriginalAmount.HyperLink = Nothing
        Me.OriginalAmount.Left = 7.25!
        Me.OriginalAmount.Name = "OriginalAmount"
        Me.OriginalAmount.Style = ""
        Me.OriginalAmount.Text = "OriginalAmount"
        Me.OriginalAmount.Top = 0.0625!
        Me.OriginalAmount.Width = 0.125!
        '
        'InvoiceNumber
        '
        Me.InvoiceNumber.DataField = "InvoiceNumber"
        Me.InvoiceNumber.Height = 0.1875!
        Me.InvoiceNumber.Left = 0.0625!
        Me.InvoiceNumber.Name = "InvoiceNumber"
        Me.InvoiceNumber.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.InvoiceNumber.Text = "InvoiceNumber"
        Me.InvoiceNumber.Top = 0.0625!
        Me.InvoiceNumber.Width = 0.9995!
        '
        'InvoiceDate
        '
        Me.InvoiceDate.DataField = "InvoiceDate"
        Me.InvoiceDate.Height = 0.1875!
        Me.InvoiceDate.Left = 1.0625!
        Me.InvoiceDate.Name = "InvoiceDate"
        Me.InvoiceDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.InvoiceDate.Text = "InvoiceDate"
        Me.InvoiceDate.Top = 0.0625!
        Me.InvoiceDate.Width = 0.875!
        '
        'Reference
        '
        Me.Reference.DataField = "ProductCode"
        Me.Reference.Height = 0.1875!
        Me.Reference.Left = 2.0625!
        Me.Reference.Name = "Reference"
        Me.Reference.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.Reference.Text = "Reference"
        Me.Reference.Top = 0.0625!
        Me.Reference.Width = 0.875!
        '
        'Description
        '
        Me.Description.DataField = "Description"
        Me.Description.Height = 0.1875!
        Me.Description.Left = 3.0625!
        Me.Description.Name = "Description"
        Me.Description.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.Description.Text = "Description"
        Me.Description.Top = 0.0625!
        Me.Description.Width = 2.9375!
        '
        'InvoiceAmount
        '
        Me.InvoiceAmount.DataField = "InvoiceAmount"
        Me.InvoiceAmount.Height = 0.1875!
        Me.InvoiceAmount.Left = 6.0625!
        Me.InvoiceAmount.Name = "InvoiceAmount"
        Me.InvoiceAmount.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.InvoiceAmount.Text = "InvoiceAmount"
        Me.InvoiceAmount.Top = 0.0625!
        Me.InvoiceAmount.Width = 1.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.CanShrink = True
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Footer, Me.ReportInfo1, Me.Label32})
        Me.PageFooter1.Height = 0.8125!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Footer
        '
        Me.Footer.DataField = "Footer"
        Me.Footer.Height = 0.44!
        Me.Footer.HyperLink = Nothing
        Me.Footer.Left = 0.0625!
        Me.Footer.Name = "Footer"
        Me.Footer.Style = "font-size: 8.25pt; text-align: center; ddo-char-set: 0"
        Me.Footer.Text = ""
        Me.Footer.Top = 0.3125!
        Me.Footer.Width = 7.375!
        '
        'ReportInfo1
        '
        Me.ReportInfo1.DataField = "FormatString=Page{PageNumber} of {PageCount} SummaryGroup=ghProducts SummaryRunni" &
    "ng = Group"
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1979167!
        Me.ReportInfo1.Left = 6.4375!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-size: 8.25pt; text-align: right; ddo-char-set: 0"
        Me.ReportInfo1.SummaryGroup = "GroupHeader1"
        Me.ReportInfo1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.ReportInfo1.Top = 0.0625!
        Me.ReportInfo1.Width = 1.0!
        '
        'Label32
        '
        Me.Label32.Height = 0.1875!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 0.0625!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.Label32.Text = "*Indicates partial payment"
        Me.Label32.Top = 0.0625!
        Me.Label32.Width = 1.6875!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.Label5, Me.SCity, Me.SAddress1, Me.SAddress2, Me.SState, Me.AddressUse, Me.CCity, Me.SZip, Me.CState, Me.CZip, Me.CAddress1, Me.CAddress2, Me.LastName, Me.Line6, Me.Label2, Me.ClientName, Me.FirstName, Me.Comments, Me.DateAR, Me.ContactCode, Me.Label3})
        Me.GroupHeader1.DataField = "GROUPING_KEY"
        Me.GroupHeader1.Height = 1.65625!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label4
        '
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.062!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9pt; text-align: right"
        Me.Label4.Text = "To:"
        Me.Label4.Top = 0.312!
        Me.Label4.Width = 0.5625!
        '
        'Label5
        '
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.062!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9pt; text-align: right"
        Me.Label5.Text = "Attn:"
        Me.Label5.Top = 0.937!
        Me.Label5.Width = 0.5625!
        '
        'SCity
        '
        Me.SCity.DataField = "SCity"
        Me.SCity.Height = 0.1875!
        Me.SCity.HyperLink = Nothing
        Me.SCity.Left = 6.812!
        Me.SCity.Name = "SCity"
        Me.SCity.Style = ""
        Me.SCity.Text = "SCity"
        Me.SCity.Top = 1.937!
        Me.SCity.Visible = False
        Me.SCity.Width = 0.125!
        '
        'SAddress1
        '
        Me.SAddress1.DataField = "SAddress1"
        Me.SAddress1.Height = 0.1875!
        Me.SAddress1.HyperLink = Nothing
        Me.SAddress1.Left = 6.437!
        Me.SAddress1.Name = "SAddress1"
        Me.SAddress1.Style = ""
        Me.SAddress1.Text = "SAddress1"
        Me.SAddress1.Top = 1.937!
        Me.SAddress1.Visible = False
        Me.SAddress1.Width = 0.125!
        '
        'SAddress2
        '
        Me.SAddress2.DataField = "SAddress2"
        Me.SAddress2.Height = 0.1875!
        Me.SAddress2.HyperLink = Nothing
        Me.SAddress2.Left = 6.6245!
        Me.SAddress2.Name = "SAddress2"
        Me.SAddress2.Style = ""
        Me.SAddress2.Text = "SAddress2"
        Me.SAddress2.Top = 1.937!
        Me.SAddress2.Visible = False
        Me.SAddress2.Width = 0.125!
        '
        'SState
        '
        Me.SState.DataField = "SState"
        Me.SState.Height = 0.1875!
        Me.SState.HyperLink = Nothing
        Me.SState.Left = 6.9995!
        Me.SState.Name = "SState"
        Me.SState.Style = ""
        Me.SState.Text = "SState"
        Me.SState.Top = 1.937!
        Me.SState.Visible = False
        Me.SState.Width = 0.125!
        '
        'AddressUse
        '
        Me.AddressUse.DataField = "AddressUse"
        Me.AddressUse.Height = 0.1875!
        Me.AddressUse.HyperLink = Nothing
        Me.AddressUse.Left = 7.187!
        Me.AddressUse.Name = "AddressUse"
        Me.AddressUse.Style = ""
        Me.AddressUse.Text = "AddressUse"
        Me.AddressUse.Top = 2.437!
        Me.AddressUse.Visible = False
        Me.AddressUse.Width = 0.125!
        '
        'CCity
        '
        Me.CCity.DataField = "CCity"
        Me.CCity.Height = 0.1875!
        Me.CCity.HyperLink = Nothing
        Me.CCity.Left = 6.812!
        Me.CCity.Name = "CCity"
        Me.CCity.Style = ""
        Me.CCity.Text = "CCity"
        Me.CCity.Top = 2.187!
        Me.CCity.Visible = False
        Me.CCity.Width = 0.125!
        '
        'SZip
        '
        Me.SZip.DataField = "SZip"
        Me.SZip.Height = 0.1875!
        Me.SZip.HyperLink = Nothing
        Me.SZip.Left = 7.187!
        Me.SZip.Name = "SZip"
        Me.SZip.Style = ""
        Me.SZip.Text = "SZip"
        Me.SZip.Top = 1.937!
        Me.SZip.Visible = False
        Me.SZip.Width = 0.125!
        '
        'CState
        '
        Me.CState.DataField = "CState"
        Me.CState.Height = 0.1875!
        Me.CState.HyperLink = Nothing
        Me.CState.Left = 6.9995!
        Me.CState.Name = "CState"
        Me.CState.Style = ""
        Me.CState.Text = "CState"
        Me.CState.Top = 2.187!
        Me.CState.Visible = False
        Me.CState.Width = 0.125!
        '
        'CZip
        '
        Me.CZip.DataField = "CZip"
        Me.CZip.Height = 0.1875!
        Me.CZip.HyperLink = Nothing
        Me.CZip.Left = 7.187!
        Me.CZip.Name = "CZip"
        Me.CZip.Style = ""
        Me.CZip.Text = "CZip"
        Me.CZip.Top = 2.187!
        Me.CZip.Visible = False
        Me.CZip.Width = 0.125!
        '
        'CAddress1
        '
        Me.CAddress1.DataField = "CAddress1"
        Me.CAddress1.Height = 0.1875!
        Me.CAddress1.HyperLink = Nothing
        Me.CAddress1.Left = 6.437!
        Me.CAddress1.Name = "CAddress1"
        Me.CAddress1.Style = "white-space: nowrap"
        Me.CAddress1.Text = "CAddress1"
        Me.CAddress1.Top = 2.187!
        Me.CAddress1.Visible = False
        Me.CAddress1.Width = 0.125!
        '
        'CAddress2
        '
        Me.CAddress2.DataField = "CAddress2"
        Me.CAddress2.Height = 0.1875!
        Me.CAddress2.HyperLink = Nothing
        Me.CAddress2.Left = 6.6245!
        Me.CAddress2.Name = "CAddress2"
        Me.CAddress2.Style = ""
        Me.CAddress2.Text = "CAddress2"
        Me.CAddress2.Top = 2.187!
        Me.CAddress2.Visible = False
        Me.CAddress2.Width = 0.125!
        '
        'LastName
        '
        Me.LastName.DataField = "LastName"
        Me.LastName.Height = 0.1875!
        Me.LastName.HyperLink = Nothing
        Me.LastName.Left = 6.9995!
        Me.LastName.Name = "LastName"
        Me.LastName.Style = ""
        Me.LastName.Text = "LastName"
        Me.LastName.Top = 2.437!
        Me.LastName.Visible = False
        Me.LastName.Width = 0.125!
        '
        'Line6
        '
        Me.Line6.Height = 0!
        Me.Line6.Left = 0.06200048!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 1.5!
        Me.Line6.Width = 7.375!
        Me.Line6.X1 = 0.06200048!
        Me.Line6.X2 = 7.437!
        Me.Line6.Y1 = 1.5!
        Me.Line6.Y2 = 1.5!
        '
        'Label2
        '
        Me.Label2.Height = 0.1979167!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 5.562!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9pt; text-align: right"
        Me.Label2.Text = "Date:  "
        Me.Label2.Top = 0.312!
        Me.Label2.Width = 1.0!
        '
        'ClientName
        '
        Me.ClientName.CanShrink = True
        Me.ClientName.DataField = "ClientName"
        Me.ClientName.Height = 0.5625!
        Me.ClientName.Left = 0.687!
        Me.ClientName.Name = "ClientName"
        Me.ClientName.Style = "font-size: 9pt"
        Me.ClientName.Text = "ClientName"
        Me.ClientName.Top = 0.312!
        Me.ClientName.Width = 3.25!
        '
        'FirstName
        '
        Me.FirstName.DataField = "FirstName"
        Me.FirstName.Height = 0.1875!
        Me.FirstName.Left = 0.687!
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Style = "font-size: 9pt"
        Me.FirstName.Text = "FirstName"
        Me.FirstName.Top = 0.937!
        Me.FirstName.Width = 3.25!
        '
        'Comments
        '
        Me.Comments.CanShrink = True
        Me.Comments.DataField = "Comments"
        Me.Comments.Height = 0.0625!
        Me.Comments.Left = 0.06200048!
        Me.Comments.Name = "Comments"
        Me.Comments.Text = "Comments"
        Me.Comments.Top = 1.5625!
        Me.Comments.Width = 7.375!
        '
        'DateAR
        '
        Me.DateAR.Height = 0.1875!
        Me.DateAR.Left = 6.6245!
        Me.DateAR.Name = "DateAR"
        Me.DateAR.Style = "font-size: 9pt"
        Me.DateAR.Text = "Date"
        Me.DateAR.Top = 0.312!
        Me.DateAR.Width = 0.8125!
        '
        'ContactCode
        '
        Me.ContactCode.DataField = "ContactCode"
        Me.ContactCode.Height = 0.1875!
        Me.ContactCode.Left = 6.812!
        Me.ContactCode.Name = "ContactCode"
        Me.ContactCode.Text = "ContactCode"
        Me.ContactCode.Top = 2.437!
        Me.ContactCode.Visible = False
        Me.ContactCode.Width = 0.125!
        '
        'Label3
        '
        Me.Label3.Height = 0.25!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 4.375!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 12.75pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.Label3.Text = "Accounts Receivable Statement"
        Me.Label3.Top = 0!
        Me.Label3.Width = 3.0625!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label30, Me.Total, Me.OnAccount, Me.OnAccountAmount, Me.LessPayments, Me.OnAcc, Me.Shape1, Me.CommentsFooter})
        Me.GroupFooter1.Height = 0.8958333!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'Label30
        '
        Me.Label30.Height = 0.1875!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 4.375!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.Label30.Text = "Balance:"
        Me.Label30.Top = 0.375!
        Me.Label30.Width = 1.5!
        '
        'Total
        '
        Me.Total.Height = 0.1875!
        Me.Total.HyperLink = Nothing
        Me.Total.Left = 5.9375!
        Me.Total.Name = "Total"
        Me.Total.Style = "text-align: right"
        Me.Total.Text = "Total"
        Me.Total.Top = 0.375!
        Me.Total.Width = 1.25!
        '
        'OnAccount
        '
        Me.OnAccount.DataField = "OnAccount"
        Me.OnAccount.Height = 0.1875!
        Me.OnAccount.HyperLink = Nothing
        Me.OnAccount.Left = 0.125!
        Me.OnAccount.Name = "OnAccount"
        Me.OnAccount.Style = ""
        Me.OnAccount.Text = "OnAccount"
        Me.OnAccount.Top = 0.0625!
        Me.OnAccount.Visible = False
        Me.OnAccount.Width = 0.125!
        '
        'OnAccountAmount
        '
        Me.OnAccountAmount.DataField = "OnAccountAmount"
        Me.OnAccountAmount.Height = 0.1875!
        Me.OnAccountAmount.HyperLink = Nothing
        Me.OnAccountAmount.Left = 0.3125!
        Me.OnAccountAmount.Name = "OnAccountAmount"
        Me.OnAccountAmount.Style = ""
        Me.OnAccountAmount.Text = "OnAccountAmount"
        Me.OnAccountAmount.Top = 0.0625!
        Me.OnAccountAmount.Visible = False
        Me.OnAccountAmount.Width = 0.125!
        '
        'LessPayments
        '
        Me.LessPayments.Height = 0.1875!
        Me.LessPayments.HyperLink = Nothing
        Me.LessPayments.Left = 4.375!
        Me.LessPayments.Name = "LessPayments"
        Me.LessPayments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.LessPayments.Text = "LessPayments"
        Me.LessPayments.Top = 0.0625!
        Me.LessPayments.Width = 1.5!
        '
        'OnAcc
        '
        Me.OnAcc.Height = 0.1875!
        Me.OnAcc.HyperLink = Nothing
        Me.OnAcc.Left = 5.9375!
        Me.OnAcc.Name = "OnAcc"
        Me.OnAcc.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.OnAcc.Text = "OnAcc"
        Me.OnAcc.Top = 0.0625!
        Me.OnAcc.Width = 1.25!
        '
        'Shape1
        '
        Me.Shape1.Height = 0.3125!
        Me.Shape1.Left = 3.937!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.312!
        Me.Shape1.Width = 3.375!
        '
        'CommentsFooter
        '
        Me.CommentsFooter.CanShrink = True
        Me.CommentsFooter.DataField = "Comments"
        Me.CommentsFooter.Height = 0.0625!
        Me.CommentsFooter.Left = 0.0625!
        Me.CommentsFooter.Name = "CommentsFooter"
        Me.CommentsFooter.Text = "Comments"
        Me.CommentsFooter.Top = 0.75!
        Me.CommentsFooter.Width = 7.375!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.BackColor = System.Drawing.Color.LightGray
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label1})
        Me.GroupHeader2.Height = 0.3125!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.0625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-size: 9pt; font-weight: bold; text-decoration: underline; ddo-char-set: 0"
        Me.Label12.Text = "Invoice"
        Me.Label12.Top = 0.0625!
        Me.Label12.Width = 0.5625!
        '
        'Label13
        '
        Me.Label13.Height = 0.1875!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 1.0625!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-size: 9pt; font-weight: bold; text-decoration: underline; ddo-char-set: 0"
        Me.Label13.Text = "Date"
        Me.Label13.Top = 0.0625!
        Me.Label13.Width = 0.875!
        '
        'Label14
        '
        Me.Label14.Height = 0.1875!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 2.0625!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "font-size: 9pt; font-weight: bold; text-decoration: underline; ddo-char-set: 0"
        Me.Label14.Text = "Reference"
        Me.Label14.Top = 0.0625!
        Me.Label14.Width = 0.875!
        '
        'Label15
        '
        Me.Label15.Height = 0.1875!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 3.0625!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-size: 9pt; font-weight: bold; text-decoration: underline; ddo-char-set: 0"
        Me.Label15.Text = "Description"
        Me.Label15.Top = 0.0625!
        Me.Label15.Width = 3.5!
        '
        'Label16
        '
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 6.625!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" &
    " ddo-char-set: 0"
        Me.Label16.Text = "Total"
        Me.Label16.Top = 0.0625!
        Me.Label16.Width = 0.5625!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line3, Me.Label22, Me.Label23, Me.Label24, Me.Label25, Me.CurrentAR, Me.OverThirtyAR, Me.OverSixtyAR, Me.TotalAR, Me.Line4, Me.Line1})
        Me.GroupFooter2.Height = 0.875!
        Me.GroupFooter2.KeepTogether = True
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.1875!
        Me.Line3.Width = 7.375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 7.4375!
        Me.Line3.Y1 = 0.1875!
        Me.Line3.Y2 = 0.1875!
        '
        'Label22
        '
        Me.Label22.Height = 0.1979167!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 2.375!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" &
    " ddo-char-set: 0"
        Me.Label22.Text = "Current"
        Me.Label22.Top = 0.25!
        Me.Label22.Width = 1.0!
        '
        'Label23
        '
        Me.Label23.Height = 0.1979167!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 4.875!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" &
    " ddo-char-set: 0"
        Me.Label23.Text = "Over Sixty"
        Me.Label23.Top = 0.25!
        Me.Label23.Width = 1.0!
        '
        'Label24
        '
        Me.Label24.Height = 0.1979167!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 6.1875!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" &
    " ddo-char-set: 0"
        Me.Label24.Text = "Total"
        Me.Label24.Top = 0.25!
        Me.Label24.Width = 1.0!
        '
        'Label25
        '
        Me.Label25.Height = 0.1979167!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 3.625!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" &
    " ddo-char-set: 0"
        Me.Label25.Text = "Over Thirty"
        Me.Label25.Top = 0.25!
        Me.Label25.Width = 1.0!
        '
        'CurrentAR
        '
        Me.CurrentAR.DataField = "CurrentAR"
        Me.CurrentAR.Height = 0.1875!
        Me.CurrentAR.HyperLink = Nothing
        Me.CurrentAR.Left = 2.3125!
        Me.CurrentAR.Name = "CurrentAR"
        Me.CurrentAR.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.CurrentAR.Text = "CurrentAR"
        Me.CurrentAR.Top = 0.625!
        Me.CurrentAR.Width = 1.0625!
        '
        'OverThirtyAR
        '
        Me.OverThirtyAR.DataField = "OverThirtyAR"
        Me.OverThirtyAR.Height = 0.1875!
        Me.OverThirtyAR.HyperLink = Nothing
        Me.OverThirtyAR.Left = 3.5!
        Me.OverThirtyAR.Name = "OverThirtyAR"
        Me.OverThirtyAR.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.OverThirtyAR.Text = "OverThirtyAR"
        Me.OverThirtyAR.Top = 0.625!
        Me.OverThirtyAR.Width = 1.125!
        '
        'OverSixtyAR
        '
        Me.OverSixtyAR.DataField = "OverSixtyAR"
        Me.OverSixtyAR.Height = 0.1875!
        Me.OverSixtyAR.HyperLink = Nothing
        Me.OverSixtyAR.Left = 4.75!
        Me.OverSixtyAR.Name = "OverSixtyAR"
        Me.OverSixtyAR.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.OverSixtyAR.Text = "OverSixtyAR"
        Me.OverSixtyAR.Top = 0.625!
        Me.OverSixtyAR.Width = 1.125!
        '
        'TotalAR
        '
        Me.TotalAR.DataField = "TotalAR"
        Me.TotalAR.Height = 0.1875!
        Me.TotalAR.HyperLink = Nothing
        Me.TotalAR.Left = 6.0!
        Me.TotalAR.Name = "TotalAR"
        Me.TotalAR.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TotalAR.Text = "TotalAR"
        Me.TotalAR.Top = 0.625!
        Me.TotalAR.Width = 1.1875!
        '
        'Line4
        '
        Me.Line4.Height = 0!
        Me.Line4.Left = 0.0625!
        Me.Line4.LineWeight = 2.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.0625!
        Me.Line4.Width = 7.375!
        Me.Line4.X1 = 0.0625!
        Me.Line4.X2 = 7.4375!
        Me.Line4.Y1 = 0.0625!
        Me.Line4.Y2 = 0.0625!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.5625!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0.5625!
        Me.Line1.Y2 = 0.5625!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.CanShrink = True
        Me.ReportHeader1.Height = 0!
        Me.ReportHeader1.Name = "ReportHeader1"
        Me.ReportHeader1.Visible = False
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.Visible = False
        '
        'TextboxInvoiceComments
        '
        Me.TextboxInvoiceComments.CanShrink = True
        Me.TextboxInvoiceComments.DataField = "InvoiceComment"
        Me.TextboxInvoiceComments.Height = 0.188!
        Me.TextboxInvoiceComments.Left = 2.062!
        Me.TextboxInvoiceComments.Name = "TextboxInvoiceComments"
        Me.TextboxInvoiceComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextboxInvoiceComments.Text = "Invoice Comment"
        Me.TextboxInvoiceComments.Top = 0.062!
        Me.TextboxInvoiceComments.Visible = False
        Me.TextboxInvoiceComments.Width = 3.938!
        '
        'Label1
        '
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.063!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-size: 9pt; font-weight: bold; text-decoration: underline; ddo-char-set: 0"
        Me.Label1.Text = "Comment"
        Me.Label1.Top = 0.062!
        Me.Label1.Visible = False
        Me.Label1.Width = 3.937!
        '
        'arptClientARStatement005
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.25!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.25!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.PrtAddr1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtAddr2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyAddress2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyAddress1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgencyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoPath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrtHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OriginalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Reference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Description, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Footer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAddress1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAddress2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressUse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAddress1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAddress2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LastName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Comments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnAccountAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LessPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommentsFooter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OverThirtyAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OverSixtyAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextboxInvoiceComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label30 As DataDynamics.ActiveReports.Label
    Friend WithEvents Total As DataDynamics.ActiveReports.Label
    Friend WithEvents CurrentAR As DataDynamics.ActiveReports.Label
    Friend WithEvents OverThirtyAR As DataDynamics.ActiveReports.Label
    Friend WithEvents OverSixtyAR As DataDynamics.ActiveReports.Label
    Friend WithEvents TotalAR As DataDynamics.ActiveReports.Label
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label32 As DataDynamics.ActiveReports.Label
    Friend WithEvents SCity As DataDynamics.ActiveReports.Label
    Friend WithEvents SAddress1 As DataDynamics.ActiveReports.Label
    Friend WithEvents SAddress2 As DataDynamics.ActiveReports.Label
    Friend WithEvents SState As DataDynamics.ActiveReports.Label
    Friend WithEvents AddressUse As DataDynamics.ActiveReports.Label
    Friend WithEvents CCity As DataDynamics.ActiveReports.Label
    Friend WithEvents SZip As DataDynamics.ActiveReports.Label
    Friend WithEvents CState As DataDynamics.ActiveReports.Label
    Friend WithEvents CZip As DataDynamics.ActiveReports.Label
    Friend WithEvents CAddress1 As DataDynamics.ActiveReports.Label
    Friend WithEvents CAddress2 As DataDynamics.ActiveReports.Label
    Friend WithEvents LastName As DataDynamics.ActiveReports.Label
    Friend WithEvents OriginalAmount As DataDynamics.ActiveReports.Label
    Friend WithEvents OnAccount As DataDynamics.ActiveReports.Label
    Friend WithEvents OnAccountAmount As DataDynamics.ActiveReports.Label
    Friend WithEvents LessPayments As DataDynamics.ActiveReports.Label
    Friend WithEvents OnAcc As DataDynamics.ActiveReports.Label
    Friend WithEvents Footer As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents LogoPath As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents PrtAddr1 As DataDynamics.ActiveReports.Label
    Friend WithEvents PrtAddr2 As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyAddress2 As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyAddress1 As DataDynamics.ActiveReports.Label
    Friend WithEvents PrtCity As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyCity As DataDynamics.ActiveReports.Label
    Friend WithEvents PrtState As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyState As DataDynamics.ActiveReports.Label
    Friend WithEvents PrtZip As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyZip As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyFax As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyEmail As DataDynamics.ActiveReports.Label
    Friend WithEvents PrtPhone As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyPhone As DataDynamics.ActiveReports.Label
    Friend WithEvents PrtFax As DataDynamics.ActiveReports.Label
    Friend WithEvents PrtEmail As DataDynamics.ActiveReports.Label
    Friend WithEvents AgencyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents AgencyInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ClientName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FirstName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents InvoiceNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents InvoiceDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Reference As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Description As DataDynamics.ActiveReports.TextBox
    Friend WithEvents InvoiceAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Comments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents DateAR As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ContactCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents PrtName As DataDynamics.ActiveReports.Label
    Friend WithEvents PrtHeader As DataDynamics.ActiveReports.Label
    Friend WithEvents CommentsFooter As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents TextboxInvoiceComments As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
End Class
