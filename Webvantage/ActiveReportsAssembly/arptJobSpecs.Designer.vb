<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptJobSpecs 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptJobSpecs))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtAgencyName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAgencyInfo = New DataDynamics.ActiveReports.TextBox()
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.txtDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtVersion = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevision = New DataDynamics.ActiveReports.TextBox()
        Me.lblVersion = New DataDynamics.ActiveReports.Label()
        Me.lblRevision = New DataDynamics.ActiveReports.Label()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.lblClient = New DataDynamics.ActiveReports.Label()
        Me.lblDivision = New DataDynamics.ActiveReports.Label()
        Me.lblProduct = New DataDynamics.ActiveReports.Label()
        Me.lblJob = New DataDynamics.ActiveReports.Label()
        Me.lblComponent = New DataDynamics.ActiveReports.Label()
        Me.txtClient = New DataDynamics.ActiveReports.TextBox()
        Me.txtDivision = New DataDynamics.ActiveReports.TextBox()
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtJob = New DataDynamics.ActiveReports.TextBox()
        Me.txtComponent = New DataDynamics.ActiveReports.TextBox()
        Me.lblApproved = New DataDynamics.ActiveReports.Label()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtShortDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtData = New DataDynamics.ActiveReports.TextBox()
        Me.txtFieldName = New DataDynamics.ActiveReports.TextBox()
        Me.txtSeparator = New DataDynamics.ActiveReports.TextBox()
        Me.LineSep = New DataDynamics.ActiveReports.Line()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.ReportInfo2 = New DataDynamics.ActiveReports.ReportInfo()
        Me.lblBy = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtQuantityTitle = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuantity = New DataDynamics.ActiveReports.TextBox()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.srMediaSpecs = New DataDynamics.ActiveReports.SubReport()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.srVendor2 = New DataDynamics.ActiveReports.SubReport()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.txtLocationofSignCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtOverallSizeCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtCopyAreaCol = New DataDynamics.ActiveReports.TextBox()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.srVendor1 = New DataDynamics.ActiveReports.SubReport()
        Me.txtVendorTitle = New DataDynamics.ActiveReports.TextBox()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.txtVendorCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtColorCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtCloseDateCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtStatusCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtRegionCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtRunDateCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtExtDateCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtDensityCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtAdSizeCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtFilmCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtBleedSizeCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtTrimSizeCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtLiveAreaCol = New DataDynamics.ActiveReports.TextBox()
        Me.txtScreenCol = New DataDynamics.ActiveReports.TextBox()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtCategory = New DataDynamics.ActiveReports.TextBox()
        Me.txtCatID = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtReason = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRevision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtShortDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFieldName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSeparator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantityTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocationofSignCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOverallSizeCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCopyAreaCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendorCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColorCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCloseDateCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatusCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegionCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRunDateCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExtDateCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDensityCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdSizeCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilmCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBleedSizeCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTrimSizeCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLiveAreaCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScreenCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCatID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.txtAgencyName, Me.txtAgencyInfo})
        Me.PageHeader1.Height = 1.979167!
        Me.PageHeader1.Name = "PageHeader1"
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
        'txtAgencyName
        '
        Me.txtAgencyName.CanShrink = True
        Me.txtAgencyName.Height = 0.1875!
        Me.txtAgencyName.Left = 0.0625!
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtAgencyName.Text = "txtAgencyName"
        Me.txtAgencyName.Top = 1.5625!
        Me.txtAgencyName.Width = 7.375!
        '
        'txtAgencyInfo
        '
        Me.txtAgencyInfo.CanShrink = True
        Me.txtAgencyInfo.Height = 0.1875!
        Me.txtAgencyInfo.Left = 0.0625!
        Me.txtAgencyInfo.Name = "txtAgencyInfo"
        Me.txtAgencyInfo.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtAgencyInfo.Text = "txtAgencyInfo"
        Me.txtAgencyInfo.Top = 1.75!
        Me.txtAgencyInfo.Width = 7.375!
        '
        'lblReportTitle
        '
        Me.lblReportTitle.Height = 0.25!
        Me.lblReportTitle.HyperLink = Nothing
        Me.lblReportTitle.Left = 0.0625!
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Style = "font-size: 14.25pt; font-weight: bold; vertical-align: middle; ddo-char-set: 0"
        Me.lblReportTitle.Text = "Report Title"
        Me.lblReportTitle.Top = 0.0625!
        Me.lblReportTitle.Width = 7.3125!
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0625!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0.0625!
        Me.Line1.Y2 = 0.0625!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.3125!
        Me.Line2.Width = 7.375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.4375!
        Me.Line2.Y1 = 0.3125!
        Me.Line2.Y2 = 0.3125!
        '
        'txtDesc
        '
        Me.txtDesc.Height = 0.1875!
        Me.txtDesc.Left = 0.0625!
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Style = "font-size: 9pt; font-weight: bold"
        Me.txtDesc.Text = "txtDesc"
        Me.txtDesc.Top = 0.375!
        Me.txtDesc.Width = 4.625!
        '
        'txtVersion
        '
        Me.txtVersion.Height = 0.1875!
        Me.txtVersion.Left = 7.062!
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Style = "font-size: 9pt"
        Me.txtVersion.Text = "txtVersion"
        Me.txtVersion.Top = 0.375!
        Me.txtVersion.Width = 0.31!
        '
        'txtRevision
        '
        Me.txtRevision.Height = 0.1875!
        Me.txtRevision.Left = 7.062!
        Me.txtRevision.Name = "txtRevision"
        Me.txtRevision.Style = "font-size: 9pt"
        Me.txtRevision.Text = "txtRevision"
        Me.txtRevision.Top = 0.562!
        Me.txtRevision.Width = 0.25!
        '
        'lblVersion
        '
        Me.lblVersion.Height = 0.1875!
        Me.lblVersion.HyperLink = Nothing
        Me.lblVersion.Left = 6.5!
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblVersion.Text = "Version:"
        Me.lblVersion.Top = 0.375!
        Me.lblVersion.Width = 0.5625!
        '
        'lblRevision
        '
        Me.lblRevision.Height = 0.1875!
        Me.lblRevision.HyperLink = Nothing
        Me.lblRevision.Left = 6.437!
        Me.lblRevision.Name = "lblRevision"
        Me.lblRevision.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblRevision.Text = "Revision:"
        Me.lblRevision.Top = 0.562!
        Me.lblRevision.Width = 0.625!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0.062!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.812!
        Me.Line3.Width = 7.375!
        Me.Line3.X1 = 0.062!
        Me.Line3.X2 = 7.437!
        Me.Line3.Y1 = 0.812!
        Me.Line3.Y2 = 0.812!
        '
        'lblClient
        '
        Me.lblClient.Height = 0.1875!
        Me.lblClient.HyperLink = Nothing
        Me.lblClient.Left = 0.1245!
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblClient.Text = "Client:"
        Me.lblClient.Top = 0.937!
        Me.lblClient.Width = 0.75!
        '
        'lblDivision
        '
        Me.lblDivision.Height = 0.1875!
        Me.lblDivision.HyperLink = Nothing
        Me.lblDivision.Left = 0.1245!
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblDivision.Text = "Division:"
        Me.lblDivision.Top = 1.1245!
        Me.lblDivision.Width = 0.75!
        '
        'lblProduct
        '
        Me.lblProduct.Height = 0.1875!
        Me.lblProduct.HyperLink = Nothing
        Me.lblProduct.Left = 0.1245!
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblProduct.Text = "Product:"
        Me.lblProduct.Top = 1.312!
        Me.lblProduct.Width = 0.75!
        '
        'lblJob
        '
        Me.lblJob.Height = 0.1875!
        Me.lblJob.HyperLink = Nothing
        Me.lblJob.Left = 0.1245!
        Me.lblJob.Name = "lblJob"
        Me.lblJob.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblJob.Text = "Job:"
        Me.lblJob.Top = 1.4995!
        Me.lblJob.Width = 0.75!
        '
        'lblComponent
        '
        Me.lblComponent.Height = 0.1875!
        Me.lblComponent.HyperLink = Nothing
        Me.lblComponent.Left = 0.062!
        Me.lblComponent.Name = "lblComponent"
        Me.lblComponent.Style = "font-size: 9pt; font-weight: bold; text-align: right"
        Me.lblComponent.Text = "Component:"
        Me.lblComponent.Top = 1.687!
        Me.lblComponent.Width = 0.8125!
        '
        'txtClient
        '
        Me.txtClient.Height = 0.1875!
        Me.txtClient.Left = 0.937!
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Style = "font-size: 9pt"
        Me.txtClient.Text = "txtClient"
        Me.txtClient.Top = 0.937!
        Me.txtClient.Width = 6.4375!
        '
        'txtDivision
        '
        Me.txtDivision.Height = 0.1875!
        Me.txtDivision.Left = 0.937!
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Style = "font-size: 9pt"
        Me.txtDivision.Text = "txtDivision"
        Me.txtDivision.Top = 1.1245!
        Me.txtDivision.Width = 6.4375!
        '
        'txtProduct
        '
        Me.txtProduct.Height = 0.1875!
        Me.txtProduct.Left = 0.937!
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Style = "font-size: 9pt"
        Me.txtProduct.Text = "txtProduct"
        Me.txtProduct.Top = 1.312!
        Me.txtProduct.Width = 6.4375!
        '
        'txtJob
        '
        Me.txtJob.Height = 0.1875!
        Me.txtJob.Left = 0.937!
        Me.txtJob.Name = "txtJob"
        Me.txtJob.Style = "font-size: 9pt"
        Me.txtJob.Text = "txtJob"
        Me.txtJob.Top = 1.4995!
        Me.txtJob.Width = 6.4375!
        '
        'txtComponent
        '
        Me.txtComponent.Height = 0.1875!
        Me.txtComponent.Left = 0.937!
        Me.txtComponent.Name = "txtComponent"
        Me.txtComponent.Style = "font-size: 9pt"
        Me.txtComponent.Text = "txtComponent"
        Me.txtComponent.Top = 1.687!
        Me.txtComponent.Width = 6.4375!
        '
        'lblApproved
        '
        Me.lblApproved.Height = 0.1875!
        Me.lblApproved.HyperLink = Nothing
        Me.lblApproved.Left = 4.75!
        Me.lblApproved.Name = "lblApproved"
        Me.lblApproved.Style = "font-size: 9pt; font-weight: bold; text-align: center; vertical-align: middle; dd" &
    "o-char-set: 0"
        Me.lblApproved.Text = "Approved"
        Me.lblApproved.Top = 0.375!
        Me.lblApproved.Width = 0.75!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtShortDesc, Me.txtData, Me.txtFieldName, Me.txtSeparator, Me.LineSep})
        Me.Detail1.Height = 0.2416667!
        Me.Detail1.Name = "Detail1"
        '
        'txtShortDesc
        '
        Me.txtShortDesc.DataField = "SHORT_DESC"
        Me.txtShortDesc.Height = 0.1875!
        Me.txtShortDesc.Left = 0.0625!
        Me.txtShortDesc.Name = "txtShortDesc"
        Me.txtShortDesc.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtShortDesc.Text = "txtShortDesc"
        Me.txtShortDesc.Top = 0!
        Me.txtShortDesc.Width = 1.9375!
        '
        'txtData
        '
        Me.txtData.DataField = "FIELD_VALUE"
        Me.txtData.Height = 0.1875!
        Me.txtData.Left = 2.0!
        Me.txtData.Name = "txtData"
        Me.txtData.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtData.Text = "txtData"
        Me.txtData.Top = 0!
        Me.txtData.Width = 5.4375!
        '
        'txtFieldName
        '
        Me.txtFieldName.DataField = "FIELD_NAME"
        Me.txtFieldName.Height = 0.1875!
        Me.txtFieldName.Left = 7.0!
        Me.txtFieldName.Name = "txtFieldName"
        Me.txtFieldName.Text = "txtFieldName"
        Me.txtFieldName.Top = 0!
        Me.txtFieldName.Visible = False
        Me.txtFieldName.Width = 0.1875!
        '
        'txtSeparator
        '
        Me.txtSeparator.DataField = "SEPARATOR_LINE"
        Me.txtSeparator.Height = 0.2!
        Me.txtSeparator.Left = 7.25!
        Me.txtSeparator.Name = "txtSeparator"
        Me.txtSeparator.Text = "TextBox5"
        Me.txtSeparator.Top = 0!
        Me.txtSeparator.Visible = False
        Me.txtSeparator.Width = 0.2!
        '
        'LineSep
        '
        Me.LineSep.Height = 0!
        Me.LineSep.Left = 0.0625!
        Me.LineSep.LineWeight = 1.0!
        Me.LineSep.Name = "LineSep"
        Me.LineSep.Top = 0.22!
        Me.LineSep.Visible = False
        Me.LineSep.Width = 7.375!
        Me.LineSep.X1 = 0.0625!
        Me.LineSep.X2 = 7.4375!
        Me.LineSep.Y1 = 0.22!
        Me.LineSep.Y2 = 0.22!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1, Me.ReportInfo2, Me.lblBy})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1979167!
        Me.ReportInfo1.Left = 6.4375!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-size: 9pt"
        Me.ReportInfo1.Top = 0!
        Me.ReportInfo1.Width = 1.0!
        '
        'ReportInfo2
        '
        Me.ReportInfo2.FormatString = "{RunDateTime:}"
        Me.ReportInfo2.Height = 0.1875!
        Me.ReportInfo2.Left = 0.0625!
        Me.ReportInfo2.Name = "ReportInfo2"
        Me.ReportInfo2.Style = "font-size: 9pt; text-align: right"
        Me.ReportInfo2.Top = 0!
        Me.ReportInfo2.Visible = False
        Me.ReportInfo2.Width = 1.375!
        '
        'lblBy
        '
        Me.lblBy.Height = 0.1979167!
        Me.lblBy.HyperLink = Nothing
        Me.lblBy.Left = 1.4375!
        Me.lblBy.Name = "lblBy"
        Me.lblBy.Style = "font-size: 9pt"
        Me.lblBy.Text = "lblBy"
        Me.lblBy.Top = 0!
        Me.lblBy.Visible = False
        Me.lblBy.Width = 1.0!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtQuantityTitle, Me.txtQuantity, Me.Line4, Me.Line5})
        Me.GroupHeader1.Height = 0.5416667!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtQuantityTitle
        '
        Me.txtQuantityTitle.Height = 0.1979167!
        Me.txtQuantityTitle.Left = 0.0625!
        Me.txtQuantityTitle.Name = "txtQuantityTitle"
        Me.txtQuantityTitle.Style = "background-color: Gray; color: White; font-size: 9pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.txtQuantityTitle.Text = "Quantities"
        Me.txtQuantityTitle.Top = 0!
        Me.txtQuantityTitle.Width = 1.0!
        '
        'txtQuantity
        '
        Me.txtQuantity.Height = 0.1875!
        Me.txtQuantity.Left = 0.0625!
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.OutputFormat = resources.GetString("txtQuantity.OutputFormat")
        Me.txtQuantity.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtQuantity.Text = Nothing
        Me.txtQuantity.Top = 0.25!
        Me.txtQuantity.Width = 7.375!
        '
        'Line4
        '
        Me.Line4.Height = 0!
        Me.Line4.Left = 1.0625!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.1875!
        Me.Line4.Width = 6.375!
        Me.Line4.X1 = 1.0625!
        Me.Line4.X2 = 7.4375!
        Me.Line4.Y1 = 0.1875!
        Me.Line4.Y2 = 0.1875!
        '
        'Line5
        '
        Me.Line5.Height = 0!
        Me.Line5.Left = 0.0625!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.5!
        Me.Line5.Width = 7.375!
        Me.Line5.X1 = 0.0625!
        Me.Line5.X2 = 7.4375!
        Me.Line5.Y1 = 0.5!
        Me.Line5.Y2 = 0.5!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.srMediaSpecs, Me.TextBox4, Me.Line10})
        Me.GroupFooter1.Height = 1.270833!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'srMediaSpecs
        '
        Me.srMediaSpecs.CloseBorder = False
        Me.srMediaSpecs.Height = 1.0!
        Me.srMediaSpecs.Left = 0.0625!
        Me.srMediaSpecs.Name = "srMediaSpecs"
        Me.srMediaSpecs.Report = Nothing
        Me.srMediaSpecs.ReportName = ""
        Me.srMediaSpecs.Top = 0.25!
        Me.srMediaSpecs.Width = 7.4375!
        '
        'TextBox4
        '
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 0.0625!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "background-color: Gray; color: White; font-size: 9pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.TextBox4.Text = "Media Specifications"
        Me.TextBox4.Top = 0!
        Me.TextBox4.Width = 1.3125!
        '
        'Line10
        '
        Me.Line10.Height = 0!
        Me.Line10.Left = 1.375!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.1875!
        Me.Line10.Width = 6.0625!
        Me.Line10.X1 = 1.375!
        Me.Line10.X2 = 7.4375!
        Me.Line10.Y1 = 0.1875!
        Me.Line10.Y2 = 0.1875!
        '
        'srVendor2
        '
        Me.srVendor2.CloseBorder = False
        Me.srVendor2.Height = 1.0!
        Me.srVendor2.Left = 0.0625!
        Me.srVendor2.Name = "srVendor2"
        Me.srVendor2.Report = Nothing
        Me.srVendor2.ReportName = "SubReport2"
        Me.srVendor2.Top = 0.5625!
        Me.srVendor2.Width = 7.4375!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0625!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "background-color: Gray; color: White; font-size: 9pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.TextBox1.Text = "Media Information"
        Me.TextBox1.Top = 0!
        Me.TextBox1.Width = 1.125!
        '
        'Line7
        '
        Me.Line7.Height = 0!
        Me.Line7.Left = 1.0625!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.1875!
        Me.Line7.Width = 6.375!
        Me.Line7.X1 = 1.0625!
        Me.Line7.X2 = 7.4375!
        Me.Line7.Y1 = 0.1875!
        Me.Line7.Y2 = 0.1875!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 0.0625!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox2.Text = "Vendor"
        Me.TextBox2.Top = 0.25!
        Me.TextBox2.Width = 1.9375!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 2.0625!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox3.Text = "Ad Size"
        Me.TextBox3.Top = 0.25!
        Me.TextBox3.Width = 0.9375!
        '
        'txtLocationofSignCol
        '
        Me.txtLocationofSignCol.Height = 0.1875!
        Me.txtLocationofSignCol.Left = 3.0625!
        Me.txtLocationofSignCol.Name = "txtLocationofSignCol"
        Me.txtLocationofSignCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtLocationofSignCol.Text = "Location of Sign"
        Me.txtLocationofSignCol.Top = 0.25!
        Me.txtLocationofSignCol.Width = 1.4375!
        '
        'txtOverallSizeCol
        '
        Me.txtOverallSizeCol.Height = 0.1875!
        Me.txtOverallSizeCol.Left = 4.5625!
        Me.txtOverallSizeCol.Name = "txtOverallSizeCol"
        Me.txtOverallSizeCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtOverallSizeCol.Text = "Overall Size"
        Me.txtOverallSizeCol.Top = 0.25!
        Me.txtOverallSizeCol.Width = 1.375!
        '
        'txtCopyAreaCol
        '
        Me.txtCopyAreaCol.Height = 0.1875!
        Me.txtCopyAreaCol.Left = 6.0!
        Me.txtCopyAreaCol.Name = "txtCopyAreaCol"
        Me.txtCopyAreaCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtCopyAreaCol.Text = "Copy Area"
        Me.txtCopyAreaCol.Top = 0.25!
        Me.txtCopyAreaCol.Width = 1.4375!
        '
        'Line9
        '
        Me.Line9.Height = 0!
        Me.Line9.Left = 0.0625!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.5!
        Me.Line9.Width = 7.375!
        Me.Line9.X1 = 0.0625!
        Me.Line9.X2 = 7.4375!
        Me.Line9.Y1 = 0.5!
        Me.Line9.Y2 = 0.5!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Height = 0!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.Visible = False
        '
        'GroupFooter2
        '
        Me.GroupFooter2.CanShrink = True
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.srVendor2, Me.Line7, Me.TextBox2, Me.TextBox3, Me.txtLocationofSignCol, Me.txtOverallSizeCol, Me.txtCopyAreaCol, Me.Line9})
        Me.GroupFooter2.Height = 1.614583!
        Me.GroupFooter2.KeepTogether = True
        Me.GroupFooter2.Name = "GroupFooter2"
        Me.GroupFooter2.Visible = False
        '
        'srVendor1
        '
        Me.srVendor1.CloseBorder = False
        Me.srVendor1.Height = 1.0!
        Me.srVendor1.Left = 0.0625!
        Me.srVendor1.Name = "srVendor1"
        Me.srVendor1.Report = Nothing
        Me.srVendor1.ReportName = "SubReport1"
        Me.srVendor1.Top = 0.75!
        Me.srVendor1.Width = 7.4375!
        '
        'txtVendorTitle
        '
        Me.txtVendorTitle.Height = 0.1875!
        Me.txtVendorTitle.Left = 0.0625!
        Me.txtVendorTitle.Name = "txtVendorTitle"
        Me.txtVendorTitle.Style = "background-color: Gray; color: White; font-size: 9pt; font-weight: bold; ddo-char" &
    "-set: 0"
        Me.txtVendorTitle.Text = "Media Information"
        Me.txtVendorTitle.Top = 0!
        Me.txtVendorTitle.Width = 1.125!
        '
        'Line6
        '
        Me.Line6.Height = 0!
        Me.Line6.Left = 1.0625!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.1875!
        Me.Line6.Width = 6.375!
        Me.Line6.X1 = 1.0625!
        Me.Line6.X2 = 7.4375!
        Me.Line6.Y1 = 0.1875!
        Me.Line6.Y2 = 0.1875!
        '
        'txtVendorCol
        '
        Me.txtVendorCol.Height = 0.1875!
        Me.txtVendorCol.Left = 0.0625!
        Me.txtVendorCol.Name = "txtVendorCol"
        Me.txtVendorCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtVendorCol.Text = "Vendor"
        Me.txtVendorCol.Top = 0.25!
        Me.txtVendorCol.Width = 2.8125!
        '
        'txtColorCol
        '
        Me.txtColorCol.Height = 0.1875!
        Me.txtColorCol.Left = 3.75!
        Me.txtColorCol.Name = "txtColorCol"
        Me.txtColorCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtColorCol.Text = "Color"
        Me.txtColorCol.Top = 0.4375!
        Me.txtColorCol.Width = 0.6875!
        '
        'txtCloseDateCol
        '
        Me.txtCloseDateCol.Height = 0.1875!
        Me.txtCloseDateCol.Left = 2.9375!
        Me.txtCloseDateCol.Name = "txtCloseDateCol"
        Me.txtCloseDateCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtCloseDateCol.Text = "Close Date"
        Me.txtCloseDateCol.Top = 0.25!
        Me.txtCloseDateCol.Width = 0.75!
        '
        'txtStatusCol
        '
        Me.txtStatusCol.Height = 0.1875!
        Me.txtStatusCol.Left = 4.5!
        Me.txtStatusCol.Name = "txtStatusCol"
        Me.txtStatusCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtStatusCol.Text = "Status"
        Me.txtStatusCol.Top = 0.4375!
        Me.txtStatusCol.Width = 0.625!
        '
        'txtRegionCol
        '
        Me.txtRegionCol.Height = 0.1875!
        Me.txtRegionCol.Left = 5.1875!
        Me.txtRegionCol.Name = "txtRegionCol"
        Me.txtRegionCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtRegionCol.Text = "Region"
        Me.txtRegionCol.Top = 0.4375!
        Me.txtRegionCol.Width = 0.8125!
        '
        'txtRunDateCol
        '
        Me.txtRunDateCol.Height = 0.1875!
        Me.txtRunDateCol.Left = 3.75!
        Me.txtRunDateCol.Name = "txtRunDateCol"
        Me.txtRunDateCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtRunDateCol.Text = "Run Date"
        Me.txtRunDateCol.Top = 0.25!
        Me.txtRunDateCol.Width = 0.6875!
        '
        'txtExtDateCol
        '
        Me.txtExtDateCol.Height = 0.1875!
        Me.txtExtDateCol.Left = 4.5!
        Me.txtExtDateCol.Name = "txtExtDateCol"
        Me.txtExtDateCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtExtDateCol.Text = "Ext Date"
        Me.txtExtDateCol.Top = 0.25!
        Me.txtExtDateCol.Width = 0.625!
        '
        'txtDensityCol
        '
        Me.txtDensityCol.Height = 0.1875!
        Me.txtDensityCol.Left = 6.0625!
        Me.txtDensityCol.Name = "txtDensityCol"
        Me.txtDensityCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtDensityCol.Text = "Density"
        Me.txtDensityCol.Top = 0.4375!
        Me.txtDensityCol.Width = 0.75!
        '
        'txtAdSizeCol
        '
        Me.txtAdSizeCol.Height = 0.1875!
        Me.txtAdSizeCol.Left = 5.1875!
        Me.txtAdSizeCol.Name = "txtAdSizeCol"
        Me.txtAdSizeCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtAdSizeCol.Text = "Ad Size"
        Me.txtAdSizeCol.Top = 0.25!
        Me.txtAdSizeCol.Width = 2.25!
        '
        'txtFilmCol
        '
        Me.txtFilmCol.Height = 0.1875!
        Me.txtFilmCol.Left = 6.875!
        Me.txtFilmCol.Name = "txtFilmCol"
        Me.txtFilmCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtFilmCol.Text = "Film"
        Me.txtFilmCol.Top = 0.4375!
        Me.txtFilmCol.Width = 0.5625!
        '
        'txtBleedSizeCol
        '
        Me.txtBleedSizeCol.Height = 0.1875!
        Me.txtBleedSizeCol.Left = 0.0625!
        Me.txtBleedSizeCol.Name = "txtBleedSizeCol"
        Me.txtBleedSizeCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtBleedSizeCol.Text = "Bleed Size"
        Me.txtBleedSizeCol.Top = 0.4375!
        Me.txtBleedSizeCol.Width = 0.9375!
        '
        'txtTrimSizeCol
        '
        Me.txtTrimSizeCol.Height = 0.1875!
        Me.txtTrimSizeCol.Left = 1.0625!
        Me.txtTrimSizeCol.Name = "txtTrimSizeCol"
        Me.txtTrimSizeCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtTrimSizeCol.Text = "Trim Size"
        Me.txtTrimSizeCol.Top = 0.4375!
        Me.txtTrimSizeCol.Width = 0.9375!
        '
        'txtLiveAreaCol
        '
        Me.txtLiveAreaCol.Height = 0.1875!
        Me.txtLiveAreaCol.Left = 2.0625!
        Me.txtLiveAreaCol.Name = "txtLiveAreaCol"
        Me.txtLiveAreaCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtLiveAreaCol.Text = "Live Area"
        Me.txtLiveAreaCol.Top = 0.4375!
        Me.txtLiveAreaCol.Width = 0.8125!
        '
        'txtScreenCol
        '
        Me.txtScreenCol.Height = 0.1875!
        Me.txtScreenCol.Left = 2.9375!
        Me.txtScreenCol.Name = "txtScreenCol"
        Me.txtScreenCol.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtScreenCol.Text = "Screen"
        Me.txtScreenCol.Top = 0.4375!
        Me.txtScreenCol.Width = 0.75!
        '
        'Line8
        '
        Me.Line8.Height = 0!
        Me.Line8.Left = 0.0625!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.6875!
        Me.Line8.Width = 7.375!
        Me.Line8.X1 = 0.0625!
        Me.Line8.X2 = 7.4375!
        Me.Line8.Y1 = 0.6875!
        Me.Line8.Y2 = 0.6875!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Height = 0!
        Me.GroupHeader3.Name = "GroupHeader3"
        Me.GroupHeader3.Visible = False
        '
        'txtCategory
        '
        Me.txtCategory.DataField = "CATEGORY_DESC"
        Me.txtCategory.Height = 0.1875!
        Me.txtCategory.Left = 0.0625!
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Style = "background-color: Gray; color: White; font-size: 9.75pt; font-weight: bold; ddo-c" &
    "har-set: 0"
        Me.txtCategory.Text = "txtCategory"
        Me.txtCategory.Top = 0!
        Me.txtCategory.Width = 7.375!
        '
        'txtCatID
        '
        Me.txtCatID.DataField = "CATEGORY_ID"
        Me.txtCatID.Height = 0.1875!
        Me.txtCatID.Left = 7.25!
        Me.txtCatID.Name = "txtCatID"
        Me.txtCatID.Text = "txtCatID"
        Me.txtCatID.Top = 0!
        Me.txtCatID.Visible = False
        Me.txtCatID.Width = 0.1875!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.CanShrink = True
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtVendorTitle, Me.srVendor1, Me.Line6, Me.txtVendorCol, Me.txtColorCol, Me.txtCloseDateCol, Me.txtStatusCol, Me.txtRegionCol, Me.txtRunDateCol, Me.txtExtDateCol, Me.txtDensityCol, Me.txtAdSizeCol, Me.txtFilmCol, Me.txtBleedSizeCol, Me.txtTrimSizeCol, Me.txtLiveAreaCol, Me.txtScreenCol, Me.Line8})
        Me.GroupFooter3.Height = 1.802083!
        Me.GroupFooter3.KeepTogether = True
        Me.GroupFooter3.Name = "GroupFooter3"
        Me.GroupFooter3.Visible = False
        '
        'GroupHeader4
        '
        Me.GroupHeader4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCategory, Me.txtCatID})
        Me.GroupHeader4.DataField = "CATEGORY_ID"
        Me.GroupHeader4.Height = 0.1875!
        Me.GroupHeader4.Name = "GroupHeader4"
        '
        'GroupFooter4
        '
        Me.GroupFooter4.Height = 0!
        Me.GroupFooter4.Name = "GroupFooter4"
        '
        'GroupHeader5
        '
        Me.GroupHeader5.CanShrink = True
        Me.GroupHeader5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.txtDesc, Me.txtVersion, Me.txtRevision, Me.lblVersion, Me.lblRevision, Me.Line3, Me.lblClient, Me.lblDivision, Me.lblProduct, Me.lblJob, Me.lblComponent, Me.txtClient, Me.txtDivision, Me.txtProduct, Me.txtJob, Me.txtComponent, Me.lblApproved, Me.Line1, Me.Line2, Me.txtReason})
        Me.GroupHeader5.Height = 1.90625!
        Me.GroupHeader5.Name = "GroupHeader5"
        '
        'txtReason
        '
        Me.txtReason.CanShrink = True
        Me.txtReason.Height = 0.1875!
        Me.txtReason.Left = 0.062!
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Style = "font-size: 9pt; font-weight: bold"
        Me.txtReason.Text = Nothing
        Me.txtReason.Top = 0.562!
        Me.txtReason.Width = 4.625!
        '
        'GroupFooter5
        '
        Me.GroupFooter5.Height = 0!
        Me.GroupFooter5.Name = "GroupFooter5"
        '
        'arptJobSpecs
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.25!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.614583!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader5)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.GroupHeader4)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter4)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter5)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" &
            "l; font-size: 10pt; color: Black", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" &
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRevision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComponent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtShortDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFieldName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSeparator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantityTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocationofSignCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOverallSizeCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCopyAreaCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendorCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColorCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCloseDateCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatusCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegionCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRunDateCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExtDateCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDensityCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdSizeCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilmCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBleedSizeCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTrimSizeCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLiveAreaCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScreenCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCatID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblReportTitle As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVersion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblVersion As DataDynamics.ActiveReports.Label
    Friend WithEvents lblRevision As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblClient As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDivision As DataDynamics.ActiveReports.Label
    Friend WithEvents lblProduct As DataDynamics.ActiveReports.Label
    Friend WithEvents lblJob As DataDynamics.ActiveReports.Label
    Friend WithEvents lblComponent As DataDynamics.ActiveReports.Label
    Friend WithEvents txtClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDivision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJob As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComponent As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents ReportInfo2 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lblBy As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtQuantityTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuantity As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtShortDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtData As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblApproved As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFieldName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents srVendor2 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents srVendor1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents txtVendorTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtVendorCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtColorCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCloseDateCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtStatusCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRegionCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRunDateCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtExtDateCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDensityCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAdSizeCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFilmCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBleedSizeCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTrimSizeCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLiveAreaCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtScreenCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLocationofSignCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOverallSizeCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCopyAreaCol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtCategory As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCatID As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents srMediaSpecs As DataDynamics.ActiveReports.SubReport
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents txtAgencyName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAgencyInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader5 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtSeparator As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LineSep As DataDynamics.ActiveReports.Line
    Private WithEvents txtReason As DataDynamics.ActiveReports.TextBox
End Class
