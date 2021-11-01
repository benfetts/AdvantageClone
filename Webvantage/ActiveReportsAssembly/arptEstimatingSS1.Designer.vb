<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEstimatingSS1
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEstimatingSS1))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddress1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtDates = New DataDynamics.ActiveReports.TextBox()
        Me.txtTitle = New DataDynamics.ActiveReports.TextBox()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.txtLineTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtDescriptionText = New DataDynamics.ActiveReports.TextBox()
        Me.txtQty = New DataDynamics.ActiveReports.TextBox()
        Me.txtAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtRate = New DataDynamics.ActiveReports.TextBox()
        Me.txtContingency = New DataDynamics.ActiveReports.TextBox()
        Me.txtMarkupAmt = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtIO = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUCont = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.txtTerms = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxableText = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtEstNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuoteNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisionNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtJAmount = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.txtFBDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtpiflabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtPIF = New DataDynamics.ActiveReports.TextBox()
        Me.txtPO = New DataDynamics.ActiveReports.TextBox()
        Me.txtPOLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtFB = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstimateHdr = New DataDynamics.ActiveReports.TextBox()
        Me.rev = New DataDynamics.ActiveReports.TextBox()
        Me.est = New DataDynamics.ActiveReports.TextBox()
        Me.estcomp = New DataDynamics.ActiveReports.TextBox()
        Me.quote = New DataDynamics.ActiveReports.TextBox()
        Me.txtComponentComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuoteComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisionComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstimateComments = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalForEst = New DataDynamics.ActiveReports.TextBox()
        Me.txtTax = New DataDynamics.ActiveReports.TextBox()
        Me.txtCommission = New DataDynamics.ActiveReports.TextBox()
        Me.txtSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtContTotal2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.txtBudgetTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtVariance = New DataDynamics.ActiveReports.TextBox()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.txtClientApprovalText = New DataDynamics.ActiveReports.TextBox()
        Me.txtPreparedBy = New DataDynamics.ActiveReports.TextBox()
        Me.txtAuthorizedBy = New DataDynamics.ActiveReports.TextBox()
        Me.txtApprovedBy = New DataDynamics.ActiveReports.TextBox()
        Me.txtDate = New DataDynamics.ActiveReports.TextBox()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.txtEstDefaultComment = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtFunctionType = New DataDynamics.ActiveReports.TextBox()
        Me.txtFunctionHeading = New DataDynamics.ActiveReports.TextBox()
        Me.txtInsideDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtPhaseDesc = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.txtTotalGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtContGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtMarkupAmtGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUContGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
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
        Me.txtClient = New DataDynamics.ActiveReports.TextBox()
        Me.txtAttnLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtAttnClient = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddressInfo = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.txtAttnProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtAccountContact = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.txtPhoneNumber = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.txtCampaign = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.txtBudget = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        Me.EmpSigPic = New DataDynamics.ActiveReports.Picture()
        Me.AuthDate = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader6 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter6 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader7 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtJobCompDesc = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter7 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLineTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescriptionText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContingency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarkupAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxableText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisionNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFBDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpiflabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPIF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstimateHdr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.est, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.estcomp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.quote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponentComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisionComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstimateComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalForEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContTotal2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBudgetTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVariance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientApprovalText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPreparedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAuthorizedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApprovedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstDefaultComment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFunctionType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFunctionHeading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsideDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhaseDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUContGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAttnLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAttnClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAttnProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCampaign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.txtName, Me.txtAddress1, Me.txtDates, Me.txtTitle, Me.ReportInfo1})
        Me.PageHeader1.Height = 1.53125!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 1.5!
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.0625!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Top = 0.0!
        Me.Picture1.Width = 7.375!
        '
        'txtName
        '
        Me.txtName.CanShrink = True
        Me.txtName.Height = 0.0625!
        Me.txtName.Left = 0.0625!
        Me.txtName.Name = "txtName"
        Me.txtName.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.txtName.Text = Nothing
        Me.txtName.Top = 1.5625!
        Me.txtName.Width = 7.375!
        '
        'txtAddress1
        '
        Me.txtAddress1.CanShrink = True
        Me.txtAddress1.Height = 0.0625!
        Me.txtAddress1.Left = 0.0625!
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAddress1.Text = Nothing
        Me.txtAddress1.Top = 1.625!
        Me.txtAddress1.Width = 7.375!
        '
        'txtDates
        '
        Me.txtDates.CanShrink = True
        Me.txtDates.Height = 0.1875!
        Me.txtDates.Left = 6.25!
        Me.txtDates.Name = "txtDates"
        Me.txtDates.Style = "font-family: Arial; font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtDates.Text = Nothing
        Me.txtDates.Top = 0.6875!
        Me.txtDates.Width = 1.1875!
        '
        'txtTitle
        '
        Me.txtTitle.CanGrow = False
        Me.txtTitle.Height = 0.25!
        Me.txtTitle.Left = 6.0!
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Style = "font-size: 14.25pt; font-weight: bold; text-align: right; vertical-align: top; dd" & _
    "o-char-set: 0"
        Me.txtTitle.Text = "Estimate"
        Me.txtTitle.Top = 0.4375!
        Me.txtTitle.Width = 1.4375!
        '
        'ReportInfo1
        '
        Me.ReportInfo1.CanShrink = True
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1875!
        Me.ReportInfo1.Left = 6.25!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-family: Arial; font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.ReportInfo1.Top = 0.875!
        Me.ReportInfo1.Width = 1.1875!
        '
        'txtLineTotal
        '
        Me.txtLineTotal.CanShrink = True
        Me.txtLineTotal.DataField = "LINE_TOTAL"
        Me.txtLineTotal.Height = 0.1875!
        Me.txtLineTotal.Left = 4.8125!
        Me.txtLineTotal.Name = "txtLineTotal"
        Me.txtLineTotal.Text = Nothing
        Me.txtLineTotal.Top = 0.375!
        Me.txtLineTotal.Visible = False
        Me.txtLineTotal.Width = 0.125!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDescriptionText, Me.txtQty, Me.txtAmount, Me.txtRate, Me.txtContingency, Me.txtMarkupAmt, Me.txtTaxAmount, Me.txtTaxCode, Me.txtLineTotal, Me.txtIO, Me.txtMUCont})
        Me.Detail1.Height = 0.1979167!
        Me.Detail1.Name = "Detail1"
        '
        'txtDescriptionText
        '
        Me.txtDescriptionText.CanShrink = True
        Me.txtDescriptionText.DataField = "FNC_DESCRIPTION"
        Me.txtDescriptionText.Height = 0.1875!
        Me.txtDescriptionText.Left = 0.0625!
        Me.txtDescriptionText.Name = "txtDescriptionText"
        Me.txtDescriptionText.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtDescriptionText.Text = Nothing
        Me.txtDescriptionText.Top = 0.0!
        Me.txtDescriptionText.Width = 4.625!
        '
        'txtQty
        '
        Me.txtQty.CanShrink = True
        Me.txtQty.DataField = "EST_REV_QUANTITY"
        Me.txtQty.Height = 0.1875!
        Me.txtQty.Left = 4.75!
        Me.txtQty.Name = "txtQty"
        Me.txtQty.OutputFormat = resources.GetString("txtQty.OutputFormat")
        Me.txtQty.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtQty.Text = Nothing
        Me.txtQty.Top = 0.0!
        Me.txtQty.Visible = False
        Me.txtQty.Width = 0.8125!
        '
        'txtAmount
        '
        Me.txtAmount.CanShrink = True
        Me.txtAmount.DataField = "LINE_TOTAL"
        Me.txtAmount.Height = 0.1875!
        Me.txtAmount.Left = 6.4375!
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OutputFormat = resources.GetString("txtAmount.OutputFormat")
        Me.txtAmount.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtAmount.Text = Nothing
        Me.txtAmount.Top = 0.0!
        Me.txtAmount.Width = 1.0!
        '
        'txtRate
        '
        Me.txtRate.CanShrink = True
        Me.txtRate.DataField = "EST_REV_RATE"
        Me.txtRate.Height = 0.1875!
        Me.txtRate.Left = 5.625!
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRate.Text = Nothing
        Me.txtRate.Top = 0.0!
        Me.txtRate.Visible = False
        Me.txtRate.Width = 0.6875!
        '
        'txtContingency
        '
        Me.txtContingency.CanShrink = True
        Me.txtContingency.DataField = "EXT_CONTINGENCY"
        Me.txtContingency.Height = 0.1875!
        Me.txtContingency.Left = 4.6875!
        Me.txtContingency.Name = "txtContingency"
        Me.txtContingency.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContingency.Text = Nothing
        Me.txtContingency.Top = 0.375!
        Me.txtContingency.Visible = False
        Me.txtContingency.Width = 0.125!
        '
        'txtMarkupAmt
        '
        Me.txtMarkupAmt.CanShrink = True
        Me.txtMarkupAmt.DataField = "EXT_MARKUP_AMT"
        Me.txtMarkupAmt.Height = 0.1875!
        Me.txtMarkupAmt.Left = 5.5625!
        Me.txtMarkupAmt.Name = "txtMarkupAmt"
        Me.txtMarkupAmt.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMarkupAmt.Text = Nothing
        Me.txtMarkupAmt.Top = 0.375!
        Me.txtMarkupAmt.Visible = False
        Me.txtMarkupAmt.Width = 0.125!
        '
        'txtTaxAmount
        '
        Me.txtTaxAmount.CanShrink = True
        Me.txtTaxAmount.DataField = "TAX"
        Me.txtTaxAmount.Height = 0.1875!
        Me.txtTaxAmount.Left = 6.3125!
        Me.txtTaxAmount.Name = "txtTaxAmount"
        Me.txtTaxAmount.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTaxAmount.Text = Nothing
        Me.txtTaxAmount.Top = 0.375!
        Me.txtTaxAmount.Visible = False
        Me.txtTaxAmount.Width = 0.125!
        '
        'txtTaxCode
        '
        Me.txtTaxCode.CanShrink = True
        Me.txtTaxCode.DataField = "TAX_CODE"
        Me.txtTaxCode.Height = 0.0625!
        Me.txtTaxCode.Left = 6.5!
        Me.txtTaxCode.Name = "txtTaxCode"
        Me.txtTaxCode.Text = Nothing
        Me.txtTaxCode.Top = 0.5!
        Me.txtTaxCode.Visible = False
        Me.txtTaxCode.Width = 0.125!
        '
        'txtIO
        '
        Me.txtIO.CanShrink = True
        Me.txtIO.DataField = "INOUT"
        Me.txtIO.Height = 0.0625!
        Me.txtIO.Left = 7.0!
        Me.txtIO.Name = "txtIO"
        Me.txtIO.Text = Nothing
        Me.txtIO.Top = 0.5!
        Me.txtIO.Visible = False
        Me.txtIO.Width = 0.125!
        '
        'txtMUCont
        '
        Me.txtMUCont.CanShrink = True
        Me.txtMUCont.DataField = "EXT_MU_CONT"
        Me.txtMUCont.Height = 0.1875!
        Me.txtMUCont.Left = 5.75!
        Me.txtMUCont.Name = "txtMUCont"
        Me.txtMUCont.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUCont.Text = Nothing
        Me.txtMUCont.Top = 0.375!
        Me.txtMUCont.Visible = False
        Me.txtMUCont.Width = 0.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTerms, Me.txtTaxableText})
        Me.PageFooter1.Height = 0.5104167!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtTerms
        '
        Me.txtTerms.CanShrink = True
        Me.txtTerms.Height = 0.3125!
        Me.txtTerms.Left = 0.0625!
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Style = "font-size: 9pt; text-align: center; vertical-align: middle"
        Me.txtTerms.Text = Nothing
        Me.txtTerms.Top = 0.1875!
        Me.txtTerms.Width = 7.375!
        '
        'txtTaxableText
        '
        Me.txtTaxableText.CanShrink = True
        Me.txtTaxableText.Height = 0.1875!
        Me.txtTaxableText.Left = 0.0625!
        Me.txtTaxableText.Name = "txtTaxableText"
        Me.txtTaxableText.Style = "font-size: 9pt"
        Me.txtTaxableText.Text = Nothing
        Me.txtTaxableText.Top = 0.0!
        Me.txtTaxableText.Width = 4.0625!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtEstNumber, Me.txtEstCompNumber, Me.txtQuoteNumber, Me.txtRevisionNumber, Me.txtJobDesc, Me.txtJAmount, Me.Line1, Me.Line8})
        Me.GroupHeader1.DataField = "JOBCOMP"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader1.Height = 0.2291667!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtEstNumber
        '
        Me.txtEstNumber.CanShrink = True
        Me.txtEstNumber.DataField = "ESTIMATE_NUMBER"
        Me.txtEstNumber.Height = 0.1875!
        Me.txtEstNumber.Left = 5.375!
        Me.txtEstNumber.Name = "txtEstNumber"
        Me.txtEstNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstNumber.Text = Nothing
        Me.txtEstNumber.Top = 0.9375!
        Me.txtEstNumber.Width = 0.125!
        '
        'txtEstCompNumber
        '
        Me.txtEstCompNumber.CanShrink = True
        Me.txtEstCompNumber.DataField = "EST_COMPONENT_NBR"
        Me.txtEstCompNumber.Height = 0.1875!
        Me.txtEstCompNumber.Left = 5.5625!
        Me.txtEstCompNumber.Name = "txtEstCompNumber"
        Me.txtEstCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstCompNumber.Text = Nothing
        Me.txtEstCompNumber.Top = 0.9375!
        Me.txtEstCompNumber.Width = 0.125!
        '
        'txtQuoteNumber
        '
        Me.txtQuoteNumber.CanShrink = True
        Me.txtQuoteNumber.DataField = "EST_QUOTE_NBR"
        Me.txtQuoteNumber.Height = 0.1875!
        Me.txtQuoteNumber.Left = 5.75!
        Me.txtQuoteNumber.Name = "txtQuoteNumber"
        Me.txtQuoteNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtQuoteNumber.Text = Nothing
        Me.txtQuoteNumber.Top = 0.9375!
        Me.txtQuoteNumber.Width = 0.125!
        '
        'txtRevisionNumber
        '
        Me.txtRevisionNumber.CanShrink = True
        Me.txtRevisionNumber.DataField = "EST_REV_NBR"
        Me.txtRevisionNumber.Height = 0.1875!
        Me.txtRevisionNumber.Left = 5.9375!
        Me.txtRevisionNumber.Name = "txtRevisionNumber"
        Me.txtRevisionNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtRevisionNumber.Text = Nothing
        Me.txtRevisionNumber.Top = 0.9375!
        Me.txtRevisionNumber.Width = 0.125!
        '
        'txtJobDesc
        '
        Me.txtJobDesc.CanShrink = True
        Me.txtJobDesc.DataField = "JOB_DESC"
        Me.txtJobDesc.Height = 0.1875!
        Me.txtJobDesc.Left = 0.0625!
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtJobDesc.Text = Nothing
        Me.txtJobDesc.Top = 0.0!
        Me.txtJobDesc.Width = 5.9375!
        '
        'txtJAmount
        '
        Me.txtJAmount.CanShrink = True
        Me.txtJAmount.DataField = "LINE_TOTAL"
        Me.txtJAmount.Height = 0.1875!
        Me.txtJAmount.Left = 6.4375!
        Me.txtJAmount.Name = "txtJAmount"
        Me.txtJAmount.OutputFormat = resources.GetString("txtJAmount.OutputFormat")
        Me.txtJAmount.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtJAmount.SummaryGroup = "GroupHeader1"
        Me.txtJAmount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtJAmount.Text = Nothing
        Me.txtJAmount.Top = 0.0!
        Me.txtJAmount.Width = 1.0!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.0!
        '
        'Line8
        '
        Me.Line8.Height = 0.0!
        Me.Line8.Left = 0.0625!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.1875!
        Me.Line8.Width = 7.375!
        Me.Line8.X1 = 0.0625!
        Me.Line8.X2 = 7.4375!
        Me.Line8.Y1 = 0.1875!
        Me.Line8.Y2 = 0.1875!
        '
        'txtFBDate
        '
        Me.txtFBDate.CanShrink = True
        Me.txtFBDate.DataField = "JOB_DUE_DATE"
        Me.txtFBDate.Height = 0.1875!
        Me.txtFBDate.Left = 1.125!
        Me.txtFBDate.Name = "txtFBDate"
        Me.txtFBDate.OutputFormat = resources.GetString("txtFBDate.OutputFormat")
        Me.txtFBDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtFBDate.Text = Nothing
        Me.txtFBDate.Top = 0.1875!
        Me.txtFBDate.Width = 1.3125!
        '
        'txtpiflabel
        '
        Me.txtpiflabel.CanShrink = True
        Me.txtpiflabel.Height = 0.1875!
        Me.txtpiflabel.Left = 0.0625!
        Me.txtpiflabel.Name = "txtpiflabel"
        Me.txtpiflabel.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.txtpiflabel.Text = "PIF:"
        Me.txtpiflabel.Top = 0.0!
        Me.txtpiflabel.Width = 0.3125!
        '
        'txtJobNumber
        '
        Me.txtJobNumber.CanShrink = True
        Me.txtJobNumber.DataField = "JOB_NUMBER"
        Me.txtJobNumber.Height = 0.1875!
        Me.txtJobNumber.Left = 5.875!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobNumber.Text = Nothing
        Me.txtJobNumber.Top = 0.625!
        Me.txtJobNumber.Width = 0.125!
        '
        'txtJobCompNumber
        '
        Me.txtJobCompNumber.CanShrink = True
        Me.txtJobCompNumber.DataField = "JOB_COMPONENT_NBR"
        Me.txtJobCompNumber.Height = 0.1875!
        Me.txtJobCompNumber.Left = 6.0625!
        Me.txtJobCompNumber.Name = "txtJobCompNumber"
        Me.txtJobCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobCompNumber.Text = Nothing
        Me.txtJobCompNumber.Top = 0.625!
        Me.txtJobCompNumber.Width = 0.125!
        '
        'txtPIF
        '
        Me.txtPIF.CanShrink = True
        Me.txtPIF.DataField = "JOB_VER_VALUE"
        Me.txtPIF.Height = 0.1875!
        Me.txtPIF.Left = 0.375!
        Me.txtPIF.Name = "txtPIF"
        Me.txtPIF.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtPIF.Text = Nothing
        Me.txtPIF.Top = 0.0!
        Me.txtPIF.Width = 1.0625!
        '
        'txtPO
        '
        Me.txtPO.CanShrink = True
        Me.txtPO.DataField = "JOB_CL_PO_NBR"
        Me.txtPO.Height = 0.1875!
        Me.txtPO.Left = 1.9375!
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtPO.Text = Nothing
        Me.txtPO.Top = 0.0!
        Me.txtPO.Width = 1.3125!
        '
        'txtPOLabel
        '
        Me.txtPOLabel.CanShrink = True
        Me.txtPOLabel.Height = 0.1875!
        Me.txtPOLabel.Left = 1.625!
        Me.txtPOLabel.Name = "txtPOLabel"
        Me.txtPOLabel.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.txtPOLabel.Text = "PO:"
        Me.txtPOLabel.Top = 0.0!
        Me.txtPOLabel.Width = 0.3125!
        '
        'txtFB
        '
        Me.txtFB.CanShrink = True
        Me.txtFB.Height = 0.1875!
        Me.txtFB.Left = 0.0625!
        Me.txtFB.Name = "txtFB"
        Me.txtFB.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.txtFB.Text = "Forecasted Bill"
        Me.txtFB.Top = 0.1875!
        Me.txtFB.Width = 0.9375!
        '
        'txtEstimateHdr
        '
        Me.txtEstimateHdr.CanShrink = True
        Me.txtEstimateHdr.Height = 0.1875!
        Me.txtEstimateHdr.Left = 5.0!
        Me.txtEstimateHdr.Name = "txtEstimateHdr"
        Me.txtEstimateHdr.Style = "font-family: Arial; font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtEstimateHdr.Text = Nothing
        Me.txtEstimateHdr.Top = 0.1875!
        Me.txtEstimateHdr.Width = 2.4375!
        '
        'rev
        '
        Me.rev.CanShrink = True
        Me.rev.DataField = "EST_REV_NBR"
        Me.rev.Height = 0.1875!
        Me.rev.Left = 5.625!
        Me.rev.Name = "rev"
        Me.rev.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.rev.Text = Nothing
        Me.rev.Top = 0.625!
        Me.rev.Visible = False
        Me.rev.Width = 0.125!
        '
        'est
        '
        Me.est.CanShrink = True
        Me.est.DataField = "ESTIMATE_NUMBER"
        Me.est.Height = 0.1875!
        Me.est.Left = 5.0625!
        Me.est.Name = "est"
        Me.est.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.est.Text = Nothing
        Me.est.Top = 0.625!
        Me.est.Visible = False
        Me.est.Width = 0.125!
        '
        'estcomp
        '
        Me.estcomp.CanShrink = True
        Me.estcomp.DataField = "EST_COMPONENT_NBR"
        Me.estcomp.Height = 0.1875!
        Me.estcomp.Left = 5.25!
        Me.estcomp.Name = "estcomp"
        Me.estcomp.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.estcomp.Text = Nothing
        Me.estcomp.Top = 0.625!
        Me.estcomp.Visible = False
        Me.estcomp.Width = 0.125!
        '
        'quote
        '
        Me.quote.CanShrink = True
        Me.quote.DataField = "EST_QUOTE_NBR"
        Me.quote.Height = 0.1875!
        Me.quote.Left = 5.4375!
        Me.quote.Name = "quote"
        Me.quote.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.quote.Text = Nothing
        Me.quote.Top = 0.625!
        Me.quote.Visible = False
        Me.quote.Width = 0.125!
        '
        'txtComponentComments
        '
        Me.txtComponentComments.CanShrink = True
        Me.txtComponentComments.DataField = "EST_COMP_COMMENT"
        Me.txtComponentComments.Height = 0.0625!
        Me.txtComponentComments.Left = 0.0625!
        Me.txtComponentComments.Name = "txtComponentComments"
        Me.txtComponentComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtComponentComments.Text = Nothing
        Me.txtComponentComments.Top = 1.0625!
        Me.txtComponentComments.Width = 7.3125!
        '
        'txtQuoteComments
        '
        Me.txtQuoteComments.CanShrink = True
        Me.txtQuoteComments.DataField = "EST_QTE_COMMENT"
        Me.txtQuoteComments.Height = 0.0625!
        Me.txtQuoteComments.Left = 0.0625!
        Me.txtQuoteComments.Name = "txtQuoteComments"
        Me.txtQuoteComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtQuoteComments.Text = Nothing
        Me.txtQuoteComments.Top = 1.125!
        Me.txtQuoteComments.Width = 7.3125!
        '
        'txtRevisionComments
        '
        Me.txtRevisionComments.CanShrink = True
        Me.txtRevisionComments.DataField = "EST_REV_COMMENT"
        Me.txtRevisionComments.Height = 0.0625!
        Me.txtRevisionComments.Left = 0.0625!
        Me.txtRevisionComments.Name = "txtRevisionComments"
        Me.txtRevisionComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtRevisionComments.Text = Nothing
        Me.txtRevisionComments.Top = 1.1875!
        Me.txtRevisionComments.Width = 7.3125!
        '
        'txtEstimateComments
        '
        Me.txtEstimateComments.CanShrink = True
        Me.txtEstimateComments.DataField = "EST_LOG_COMMENT"
        Me.txtEstimateComments.Height = 0.0625!
        Me.txtEstimateComments.Left = 0.0625!
        Me.txtEstimateComments.Name = "txtEstimateComments"
        Me.txtEstimateComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtEstimateComments.Text = Nothing
        Me.txtEstimateComments.Top = 1.0!
        Me.txtEstimateComments.Width = 7.3125!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 0.375!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox8.Text = "ESTIMATE"
        Me.TextBox8.Top = 0.125!
        Me.TextBox8.Width = 1.1875!
        '
        'txtTotalForEst
        '
        Me.txtTotalForEst.DataField = "LINE_TOTAL"
        Me.txtTotalForEst.Height = 0.1875!
        Me.txtTotalForEst.Left = 6.375!
        Me.txtTotalForEst.Name = "txtTotalForEst"
        Me.txtTotalForEst.OutputFormat = resources.GetString("txtTotalForEst.OutputFormat")
        Me.txtTotalForEst.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalForEst.SummaryGroup = "GroupHeader5"
        Me.txtTotalForEst.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalForEst.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTotalForEst.Text = Nothing
        Me.txtTotalForEst.Top = 0.125!
        Me.txtTotalForEst.Width = 1.0!
        '
        'txtTax
        '
        Me.txtTax.CanShrink = True
        Me.txtTax.DataField = "TAX"
        Me.txtTax.Height = 0.1875!
        Me.txtTax.Left = 6.25!
        Me.txtTax.Name = "txtTax"
        Me.txtTax.OutputFormat = resources.GetString("txtTax.OutputFormat")
        Me.txtTax.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTax.SummaryGroup = "GroupHeader1"
        Me.txtTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTax.Text = Nothing
        Me.txtTax.Top = 2.25!
        Me.txtTax.Visible = False
        Me.txtTax.Width = 1.0!
        '
        'txtCommission
        '
        Me.txtCommission.CanShrink = True
        Me.txtCommission.DataField = "EXT_MARKUP_AMT"
        Me.txtCommission.Height = 0.1875!
        Me.txtCommission.Left = 6.25!
        Me.txtCommission.Name = "txtCommission"
        Me.txtCommission.OutputFormat = resources.GetString("txtCommission.OutputFormat")
        Me.txtCommission.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtCommission.SummaryGroup = "GroupHeader1"
        Me.txtCommission.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtCommission.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtCommission.Text = Nothing
        Me.txtCommission.Top = 2.0!
        Me.txtCommission.Visible = False
        Me.txtCommission.Width = 1.0!
        '
        'txtSubTotal
        '
        Me.txtSubTotal.CanShrink = True
        Me.txtSubTotal.DataField = "EST_REV_EXT_AMT"
        Me.txtSubTotal.Height = 0.1875!
        Me.txtSubTotal.Left = 6.25!
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.OutputFormat = resources.GetString("txtSubTotal.OutputFormat")
        Me.txtSubTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtSubTotal.SummaryGroup = "GroupHeader1"
        Me.txtSubTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtSubTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtSubTotal.Text = Nothing
        Me.txtSubTotal.Top = 1.625!
        Me.txtSubTotal.Visible = False
        Me.txtSubTotal.Width = 1.0!
        '
        'txtContTotal2
        '
        Me.txtContTotal2.CanShrink = True
        Me.txtContTotal2.DataField = "EXT_CONTINGENCY"
        Me.txtContTotal2.Height = 0.1875!
        Me.txtContTotal2.Left = 6.25!
        Me.txtContTotal2.Name = "txtContTotal2"
        Me.txtContTotal2.OutputFormat = resources.GetString("txtContTotal2.OutputFormat")
        Me.txtContTotal2.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContTotal2.SummaryGroup = "GroupHeader1"
        Me.txtContTotal2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtContTotal2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtContTotal2.Text = Nothing
        Me.txtContTotal2.Top = 1.875!
        Me.txtContTotal2.Visible = False
        Me.txtContTotal2.Width = 1.0!
        '
        'txtContTotal
        '
        Me.txtContTotal.CanShrink = True
        Me.txtContTotal.DataField = "EXT_CONTINGENCY"
        Me.txtContTotal.Height = 0.1875!
        Me.txtContTotal.Left = 5.0!
        Me.txtContTotal.Name = "txtContTotal"
        Me.txtContTotal.OutputFormat = resources.GetString("txtContTotal.OutputFormat")
        Me.txtContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContTotal.SummaryGroup = "GroupHeader1"
        Me.txtContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtContTotal.Text = Nothing
        Me.txtContTotal.Top = 1.625!
        Me.txtContTotal.Visible = False
        Me.txtContTotal.Width = 0.125!
        '
        'txtMUContTotal
        '
        Me.txtMUContTotal.CanShrink = True
        Me.txtMUContTotal.DataField = "EXT_MU_CONT"
        Me.txtMUContTotal.Height = 0.1875!
        Me.txtMUContTotal.Left = 4.875!
        Me.txtMUContTotal.Name = "txtMUContTotal"
        Me.txtMUContTotal.OutputFormat = resources.GetString("txtMUContTotal.OutputFormat")
        Me.txtMUContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUContTotal.SummaryGroup = "GroupHeader1"
        Me.txtMUContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMUContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMUContTotal.Text = Nothing
        Me.txtMUContTotal.Top = 1.625!
        Me.txtMUContTotal.Visible = False
        Me.txtMUContTotal.Width = 0.125!
        '
        'TextBox5
        '
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 0.375!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox5.Text = "BUDGET"
        Me.TextBox5.Top = 0.5!
        Me.TextBox5.Width = 1.1875!
        '
        'TextBox6
        '
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 0.375!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox6.Text = "VARIANCE"
        Me.TextBox6.Top = 0.75!
        Me.TextBox6.Width = 1.1875!
        '
        'txtBudgetTotal
        '
        Me.txtBudgetTotal.DataField = "CMP_BILL_BUDGET"
        Me.txtBudgetTotal.Height = 0.1875!
        Me.txtBudgetTotal.Left = 6.375!
        Me.txtBudgetTotal.Name = "txtBudgetTotal"
        Me.txtBudgetTotal.OutputFormat = resources.GetString("txtBudgetTotal.OutputFormat")
        Me.txtBudgetTotal.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtBudgetTotal.Text = Nothing
        Me.txtBudgetTotal.Top = 0.5!
        Me.txtBudgetTotal.Width = 1.0!
        '
        'txtVariance
        '
        Me.txtVariance.Height = 0.1875!
        Me.txtVariance.Left = 6.375!
        Me.txtVariance.Name = "txtVariance"
        Me.txtVariance.OutputFormat = resources.GetString("txtVariance.OutputFormat")
        Me.txtVariance.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtVariance.Text = Nothing
        Me.txtVariance.Top = 0.75!
        Me.txtVariance.Width = 1.0!
        '
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.0625!
        Me.SubReport1.Left = 0.125!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = "SubReport1"
        Me.SubReport1.Top = 0.375!
        Me.SubReport1.Width = 7.25!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0625!
        Me.Line2.Width = 7.375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.4375!
        Me.Line2.Y1 = 0.0625!
        Me.Line2.Y2 = 0.0625!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.0!
        Me.Line3.Width = 7.375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 7.4375!
        Me.Line3.Y1 = 1.0!
        Me.Line3.Y2 = 1.0!
        '
        'Line9
        '
        Me.Line9.Height = 0.375!
        Me.Line9.Left = 0.0625!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.0625!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 0.0625!
        Me.Line9.X2 = 0.0625!
        Me.Line9.Y1 = 0.0625!
        Me.Line9.Y2 = 0.4375!
        '
        'Line10
        '
        Me.Line10.Height = 0.375!
        Me.Line10.Left = 7.4375!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.0625!
        Me.Line10.Width = 0.0!
        Me.Line10.X1 = 7.4375!
        Me.Line10.X2 = 7.4375!
        Me.Line10.Y1 = 0.0625!
        Me.Line10.Y2 = 0.4375!
        '
        'txtClientApprovalText
        '
        Me.txtClientApprovalText.Height = 0.3125!
        Me.txtClientApprovalText.Left = 0.0625!
        Me.txtClientApprovalText.Name = "txtClientApprovalText"
        Me.txtClientApprovalText.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtClientApprovalText.Text = "Saatchi & Saatchi X Account Contact:"
        Me.txtClientApprovalText.Top = 0.5!
        Me.txtClientApprovalText.Width = 1.25!
        '
        'txtPreparedBy
        '
        Me.txtPreparedBy.Height = 0.1875!
        Me.txtPreparedBy.Left = 5.0625!
        Me.txtPreparedBy.Name = "txtPreparedBy"
        Me.txtPreparedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtPreparedBy.Text = "Date:"
        Me.txtPreparedBy.Top = 0.875!
        Me.txtPreparedBy.Width = 0.4375!
        '
        'txtAuthorizedBy
        '
        Me.txtAuthorizedBy.Height = 0.1875!
        Me.txtAuthorizedBy.Left = 0.0625!
        Me.txtAuthorizedBy.Name = "txtAuthorizedBy"
        Me.txtAuthorizedBy.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtAuthorizedBy.Text = "Approvals:"
        Me.txtAuthorizedBy.Top = 0.25!
        Me.txtAuthorizedBy.Width = 0.9375!
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.Height = 0.1875!
        Me.txtApprovedBy.Left = 0.0625!
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtApprovedBy.Text = "P&G Marketing:"
        Me.txtApprovedBy.Top = 0.875!
        Me.txtApprovedBy.Width = 1.25!
        '
        'txtDate
        '
        Me.txtDate.Height = 0.1875!
        Me.txtDate.Left = 5.0625!
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtDate.Text = "Date:"
        Me.txtDate.Top = 0.625!
        Me.txtDate.Width = 0.4375!
        '
        'Line4
        '
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 1.4375!
        Me.Line4.LineWeight = 2.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 1.0625!
        Me.Line4.Width = 3.5!
        Me.Line4.X1 = 1.4375!
        Me.Line4.X2 = 4.9375!
        Me.Line4.Y1 = 1.0625!
        Me.Line4.Y2 = 1.0625!
        '
        'Line5
        '
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 1.4375!
        Me.Line5.LineWeight = 2.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.8125!
        Me.Line5.Width = 3.5!
        Me.Line5.X1 = 1.4375!
        Me.Line5.X2 = 4.9375!
        Me.Line5.Y1 = 0.8125!
        Me.Line5.Y2 = 0.8125!
        '
        'Line6
        '
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 5.5625!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.8125!
        Me.Line6.Width = 1.8125!
        Me.Line6.X1 = 5.5625!
        Me.Line6.X2 = 7.375!
        Me.Line6.Y1 = 0.8125!
        Me.Line6.Y2 = 0.8125!
        '
        'Line7
        '
        Me.Line7.Height = 0.0!
        Me.Line7.Left = 5.5625!
        Me.Line7.LineWeight = 2.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 1.0625!
        Me.Line7.Width = 1.8125!
        Me.Line7.X1 = 5.5625!
        Me.Line7.X2 = 7.375!
        Me.Line7.Y1 = 1.0625!
        Me.Line7.Y2 = 1.0625!
        '
        'txtEstDefaultComment
        '
        Me.txtEstDefaultComment.CanShrink = True
        Me.txtEstDefaultComment.Height = 0.1875!
        Me.txtEstDefaultComment.Left = 0.25!
        Me.txtEstDefaultComment.Name = "txtEstDefaultComment"
        Me.txtEstDefaultComment.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtEstDefaultComment.Text = Nothing
        Me.txtEstDefaultComment.Top = 0.0625!
        Me.txtEstDefaultComment.Width = 7.1875!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.CanShrink = True
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFunctionType, Me.txtFunctionHeading, Me.txtInsideDesc, Me.txtPhaseDesc})
        Me.GroupHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader2.Height = 0.0!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.Visible = False
        '
        'txtFunctionType
        '
        Me.txtFunctionType.CanShrink = True
        Me.txtFunctionType.DataField = "EST_FNC_TYPE"
        Me.txtFunctionType.Height = 0.0625!
        Me.txtFunctionType.Left = 0.25!
        Me.txtFunctionType.Name = "txtFunctionType"
        Me.txtFunctionType.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtFunctionType.Text = Nothing
        Me.txtFunctionType.Top = 0.0!
        Me.txtFunctionType.Width = 4.4375!
        '
        'txtFunctionHeading
        '
        Me.txtFunctionHeading.CanShrink = True
        Me.txtFunctionHeading.DataField = "FNC_HEADING_DESC"
        Me.txtFunctionHeading.Height = 0.0625!
        Me.txtFunctionHeading.Left = 0.25!
        Me.txtFunctionHeading.Name = "txtFunctionHeading"
        Me.txtFunctionHeading.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtFunctionHeading.Text = Nothing
        Me.txtFunctionHeading.Top = 0.0625!
        Me.txtFunctionHeading.Width = 4.4375!
        '
        'txtInsideDesc
        '
        Me.txtInsideDesc.CanShrink = True
        Me.txtInsideDesc.Height = 0.0625!
        Me.txtInsideDesc.Left = 0.25!
        Me.txtInsideDesc.Name = "txtInsideDesc"
        Me.txtInsideDesc.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtInsideDesc.Text = Nothing
        Me.txtInsideDesc.Top = 0.125!
        Me.txtInsideDesc.Width = 4.4375!
        '
        'txtPhaseDesc
        '
        Me.txtPhaseDesc.CanShrink = True
        Me.txtPhaseDesc.DataField = "EST_PHASE_DESC"
        Me.txtPhaseDesc.Height = 0.0625!
        Me.txtPhaseDesc.Left = 0.25!
        Me.txtPhaseDesc.Name = "txtPhaseDesc"
        Me.txtPhaseDesc.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtPhaseDesc.Text = Nothing
        Me.txtPhaseDesc.Top = 0.1875!
        Me.txtPhaseDesc.Width = 4.4375!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.CanShrink = True
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalGrouping, Me.txtTotalLabel, Me.txtContGrouping, Me.txtTaxGrouping, Me.txtMarkupAmtGrouping, Me.TextBox4, Me.TextBox7, Me.txtMUContGrouping})
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'txtTotalGrouping
        '
        Me.txtTotalGrouping.CanShrink = True
        Me.txtTotalGrouping.DataField = "EST_REV_EXT_AMT"
        Me.txtTotalGrouping.Height = 0.1875!
        Me.txtTotalGrouping.Left = 6.375!
        Me.txtTotalGrouping.Name = "txtTotalGrouping"
        Me.txtTotalGrouping.OutputFormat = resources.GetString("txtTotalGrouping.OutputFormat")
        Me.txtTotalGrouping.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtTotalGrouping.SummaryGroup = "GroupHeader2"
        Me.txtTotalGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTotalGrouping.Text = Nothing
        Me.txtTotalGrouping.Top = 0.0!
        Me.txtTotalGrouping.Width = 1.0!
        '
        'txtTotalLabel
        '
        Me.txtTotalLabel.CanShrink = True
        Me.txtTotalLabel.Height = 0.1875!
        Me.txtTotalLabel.Left = 3.0!
        Me.txtTotalLabel.Name = "txtTotalLabel"
        Me.txtTotalLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalLabel.Text = "Total:"
        Me.txtTotalLabel.Top = 0.0!
        Me.txtTotalLabel.Width = 3.3125!
        '
        'txtContGrouping
        '
        Me.txtContGrouping.CanShrink = True
        Me.txtContGrouping.DataField = "EXT_CONTINGENCY"
        Me.txtContGrouping.Height = 0.1875!
        Me.txtContGrouping.Left = 2.875!
        Me.txtContGrouping.Name = "txtContGrouping"
        Me.txtContGrouping.OutputFormat = resources.GetString("txtContGrouping.OutputFormat")
        Me.txtContGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContGrouping.SummaryGroup = "GroupHeader2"
        Me.txtContGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtContGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtContGrouping.Text = Nothing
        Me.txtContGrouping.Top = 0.0!
        Me.txtContGrouping.Visible = False
        Me.txtContGrouping.Width = 0.125!
        '
        'txtTaxGrouping
        '
        Me.txtTaxGrouping.DataField = "TAX"
        Me.txtTaxGrouping.Height = 0.1875!
        Me.txtTaxGrouping.Left = 2.625!
        Me.txtTaxGrouping.Name = "txtTaxGrouping"
        Me.txtTaxGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTaxGrouping.SummaryGroup = "GroupHeader2"
        Me.txtTaxGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTaxGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTaxGrouping.Text = Nothing
        Me.txtTaxGrouping.Top = 0.0!
        Me.txtTaxGrouping.Visible = False
        Me.txtTaxGrouping.Width = 0.125!
        '
        'txtMarkupAmtGrouping
        '
        Me.txtMarkupAmtGrouping.DataField = "EXT_MARKUP_AMT"
        Me.txtMarkupAmtGrouping.Height = 0.1875!
        Me.txtMarkupAmtGrouping.Left = 2.375!
        Me.txtMarkupAmtGrouping.Name = "txtMarkupAmtGrouping"
        Me.txtMarkupAmtGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMarkupAmtGrouping.SummaryGroup = "GroupHeader2"
        Me.txtMarkupAmtGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMarkupAmtGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMarkupAmtGrouping.Text = Nothing
        Me.txtMarkupAmtGrouping.Top = 0.0!
        Me.txtMarkupAmtGrouping.Visible = False
        Me.txtMarkupAmtGrouping.Width = 0.125!
        '
        'TextBox4
        '
        Me.TextBox4.CanShrink = True
        Me.TextBox4.DataField = "FNC_HEADING_DESC"
        Me.TextBox4.Height = 0.0625!
        Me.TextBox4.Left = 0.25!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 4.4375!
        '
        'TextBox7
        '
        Me.TextBox7.CanShrink = True
        Me.TextBox7.DataField = "EST_REV_QUANTITY"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 4.8125!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Visible = False
        Me.TextBox7.Width = 0.8125!
        '
        'txtMUContGrouping
        '
        Me.txtMUContGrouping.CanShrink = True
        Me.txtMUContGrouping.DataField = "EXT_MU_CONT"
        Me.txtMUContGrouping.Height = 0.1875!
        Me.txtMUContGrouping.Left = 3.0625!
        Me.txtMUContGrouping.Name = "txtMUContGrouping"
        Me.txtMUContGrouping.OutputFormat = resources.GetString("txtMUContGrouping.OutputFormat")
        Me.txtMUContGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUContGrouping.SummaryGroup = "GroupHeader2"
        Me.txtMUContGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMUContGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMUContGrouping.Text = Nothing
        Me.txtMUContGrouping.Top = 0.0!
        Me.txtMUContGrouping.Visible = False
        Me.txtMUContGrouping.Width = 0.125!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtPhone, Me.txtCityStateZip, Me.txtFedID, Me.txtAddress2, Me.txtFax, Me.txtEmail, Me.txtCDPContact, Me.txtCCAddress, Me.txtCCState, Me.txtCCZip, Me.txtCCAddress2, Me.txtCCCity, Me.txtClient, Me.txtAttnLabel, Me.txtProduct, Me.txtAttnClient, Me.txtAddressInfo, Me.TextBox9, Me.txtAttnProduct, Me.txtAccountContact, Me.TextBox10, Me.txtPhoneNumber})
        Me.GroupHeader3.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader3.Height = 0.9479167!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'txtPhone
        '
        Me.txtPhone.CanShrink = True
        Me.txtPhone.Height = 0.0625!
        Me.txtPhone.Left = 5.75!
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtPhone.Text = Nothing
        Me.txtPhone.Top = 1.625!
        Me.txtPhone.Visible = False
        Me.txtPhone.Width = 0.1875!
        '
        'txtCityStateZip
        '
        Me.txtCityStateZip.CanShrink = True
        Me.txtCityStateZip.Height = 0.0625!
        Me.txtCityStateZip.Left = 6.0!
        Me.txtCityStateZip.Name = "txtCityStateZip"
        Me.txtCityStateZip.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCityStateZip.Text = Nothing
        Me.txtCityStateZip.Top = 1.625!
        Me.txtCityStateZip.Visible = False
        Me.txtCityStateZip.Width = 0.1875!
        '
        'txtFedID
        '
        Me.txtFedID.CanShrink = True
        Me.txtFedID.Height = 0.0625!
        Me.txtFedID.Left = 6.6875!
        Me.txtFedID.Name = "txtFedID"
        Me.txtFedID.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtFedID.Text = Nothing
        Me.txtFedID.Top = 1.625!
        Me.txtFedID.Visible = False
        Me.txtFedID.Width = 0.125!
        '
        'txtAddress2
        '
        Me.txtAddress2.CanShrink = True
        Me.txtAddress2.Height = 0.0625!
        Me.txtAddress2.Left = 5.75!
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Style = "font-size: 9pt"
        Me.txtAddress2.Text = Nothing
        Me.txtAddress2.Top = 1.75!
        Me.txtAddress2.Visible = False
        Me.txtAddress2.Width = 0.1875!
        '
        'txtFax
        '
        Me.txtFax.CanShrink = True
        Me.txtFax.Height = 0.0625!
        Me.txtFax.Left = 6.25!
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Style = "font-size: 9pt"
        Me.txtFax.Text = Nothing
        Me.txtFax.Top = 1.625!
        Me.txtFax.Visible = False
        Me.txtFax.Width = 0.125!
        '
        'txtEmail
        '
        Me.txtEmail.CanShrink = True
        Me.txtEmail.Height = 0.0625!
        Me.txtEmail.Left = 6.5!
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Style = "font-size: 9pt"
        Me.txtEmail.Text = Nothing
        Me.txtEmail.Top = 1.625!
        Me.txtEmail.Visible = False
        Me.txtEmail.Width = 0.125!
        '
        'txtCDPContact
        '
        Me.txtCDPContact.DataField = "CONT_FML"
        Me.txtCDPContact.Height = 0.1875!
        Me.txtCDPContact.Left = 5.3125!
        Me.txtCDPContact.Name = "txtCDPContact"
        Me.txtCDPContact.Text = Nothing
        Me.txtCDPContact.Top = 1.625!
        Me.txtCDPContact.Visible = False
        Me.txtCDPContact.Width = 0.125!
        '
        'txtCCAddress
        '
        Me.txtCCAddress.CanShrink = True
        Me.txtCCAddress.DataField = "CONT_ADDRESS1"
        Me.txtCCAddress.Height = 0.0625!
        Me.txtCCAddress.Left = 6.875!
        Me.txtCCAddress.Name = "txtCCAddress"
        Me.txtCCAddress.Style = "font-size: 9pt"
        Me.txtCCAddress.Text = Nothing
        Me.txtCCAddress.Top = 1.625!
        Me.txtCCAddress.Visible = False
        Me.txtCCAddress.Width = 0.1875!
        '
        'txtCCState
        '
        Me.txtCCState.CanShrink = True
        Me.txtCCState.DataField = "CONT_STATE"
        Me.txtCCState.Height = 0.0625!
        Me.txtCCState.Left = 6.375!
        Me.txtCCState.Name = "txtCCState"
        Me.txtCCState.Style = "font-size: 9pt"
        Me.txtCCState.Text = Nothing
        Me.txtCCState.Top = 1.75!
        Me.txtCCState.Visible = False
        Me.txtCCState.Width = 0.1875!
        '
        'txtCCZip
        '
        Me.txtCCZip.CanShrink = True
        Me.txtCCZip.DataField = "CONT_ZIP"
        Me.txtCCZip.Height = 0.0625!
        Me.txtCCZip.Left = 6.625!
        Me.txtCCZip.Name = "txtCCZip"
        Me.txtCCZip.Style = "font-size: 9pt"
        Me.txtCCZip.Text = Nothing
        Me.txtCCZip.Top = 1.75!
        Me.txtCCZip.Visible = False
        Me.txtCCZip.Width = 0.1875!
        '
        'txtCCAddress2
        '
        Me.txtCCAddress2.CanShrink = True
        Me.txtCCAddress2.DataField = "CONT_ADDRESS2"
        Me.txtCCAddress2.Height = 0.0625!
        Me.txtCCAddress2.Left = 6.125!
        Me.txtCCAddress2.Name = "txtCCAddress2"
        Me.txtCCAddress2.Style = "font-size: 9pt"
        Me.txtCCAddress2.Text = Nothing
        Me.txtCCAddress2.Top = 1.75!
        Me.txtCCAddress2.Visible = False
        Me.txtCCAddress2.Width = 0.1875!
        '
        'txtCCCity
        '
        Me.txtCCCity.CanShrink = True
        Me.txtCCCity.DataField = "CONT_CITY"
        Me.txtCCCity.Height = 0.0625!
        Me.txtCCCity.Left = 6.875!
        Me.txtCCCity.Name = "txtCCCity"
        Me.txtCCCity.Style = "font-size: 9pt"
        Me.txtCCCity.Text = Nothing
        Me.txtCCCity.Top = 1.75!
        Me.txtCCCity.Visible = False
        Me.txtCCCity.Width = 0.1875!
        '
        'txtClient
        '
        Me.txtClient.CanShrink = True
        Me.txtClient.DataField = "CL_NAME"
        Me.txtClient.Height = 0.0625!
        Me.txtClient.Left = 0.0625!
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtClient.Text = Nothing
        Me.txtClient.Top = 0.0625!
        Me.txtClient.Width = 7.375!
        '
        'txtAttnLabel
        '
        Me.txtAttnLabel.CanShrink = True
        Me.txtAttnLabel.Height = 0.1875!
        Me.txtAttnLabel.Left = 0.0625!
        Me.txtAttnLabel.Name = "txtAttnLabel"
        Me.txtAttnLabel.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAttnLabel.Text = "Attn:"
        Me.txtAttnLabel.Top = 0.1875!
        Me.txtAttnLabel.Width = 0.3125!
        '
        'txtProduct
        '
        Me.txtProduct.CanShrink = True
        Me.txtProduct.DataField = "PRD_DESCRIPTION"
        Me.txtProduct.Height = 0.0625!
        Me.txtProduct.Left = 0.0625!
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtProduct.Text = Nothing
        Me.txtProduct.Top = 0.125!
        Me.txtProduct.Width = 7.375!
        '
        'txtAttnClient
        '
        Me.txtAttnClient.CanShrink = True
        Me.txtAttnClient.Height = 0.1875!
        Me.txtAttnClient.Left = 0.375!
        Me.txtAttnClient.Name = "txtAttnClient"
        Me.txtAttnClient.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAttnClient.Text = Nothing
        Me.txtAttnClient.Top = 0.1875!
        Me.txtAttnClient.Width = 7.0625!
        '
        'txtAddressInfo
        '
        Me.txtAddressInfo.CanShrink = True
        Me.txtAddressInfo.Height = 0.0625!
        Me.txtAddressInfo.Left = 0.0625!
        Me.txtAddressInfo.Name = "txtAddressInfo"
        Me.txtAddressInfo.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAddressInfo.Text = Nothing
        Me.txtAddressInfo.Top = 0.375!
        Me.txtAddressInfo.Width = 7.375!
        '
        'TextBox9
        '
        Me.TextBox9.CanShrink = True
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 0.0625!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox9.Text = "Attn:"
        Me.TextBox9.Top = 0.5!
        Me.TextBox9.Width = 0.3125!
        '
        'txtAttnProduct
        '
        Me.txtAttnProduct.CanShrink = True
        Me.txtAttnProduct.Height = 0.1875!
        Me.txtAttnProduct.Left = 0.375!
        Me.txtAttnProduct.Name = "txtAttnProduct"
        Me.txtAttnProduct.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAttnProduct.Text = Nothing
        Me.txtAttnProduct.Top = 0.5!
        Me.txtAttnProduct.Width = 7.0625!
        '
        'txtAccountContact
        '
        Me.txtAccountContact.CanShrink = True
        Me.txtAccountContact.Height = 0.1875!
        Me.txtAccountContact.Left = 1.0625!
        Me.txtAccountContact.Name = "txtAccountContact"
        Me.txtAccountContact.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAccountContact.Text = Nothing
        Me.txtAccountContact.Top = 0.75!
        Me.txtAccountContact.Width = 1.0!
        '
        'TextBox10
        '
        Me.TextBox10.CanShrink = True
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 0.0625!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox10.Text = "Account Contact:"
        Me.TextBox10.Top = 0.75!
        Me.TextBox10.Width = 1.0!
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.CanShrink = True
        Me.txtPhoneNumber.Height = 0.1875!
        Me.txtPhoneNumber.Left = 2.125!
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtPhoneNumber.Text = Nothing
        Me.txtPhoneNumber.Top = 0.75!
        Me.txtPhoneNumber.Width = 1.25!
        '
        'TextBox11
        '
        Me.TextBox11.CanShrink = True
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 0.0625!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox11.Text = "Campaign:"
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.6875!
        '
        'txtCampaign
        '
        Me.txtCampaign.CanShrink = True
        Me.txtCampaign.DataField = "CMP_NAME"
        Me.txtCampaign.Height = 0.1875!
        Me.txtCampaign.Left = 0.75!
        Me.txtCampaign.Name = "txtCampaign"
        Me.txtCampaign.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCampaign.Text = Nothing
        Me.txtCampaign.Top = 0.0!
        Me.txtCampaign.Width = 6.6875!
        '
        'TextBox12
        '
        Me.TextBox12.CanShrink = True
        Me.TextBox12.Height = 0.1875!
        Me.TextBox12.Left = 0.0625!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox12.Text = "Budget:"
        Me.TextBox12.Top = 0.1875!
        Me.TextBox12.Width = 0.5!
        '
        'txtBudget
        '
        Me.txtBudget.CanShrink = True
        Me.txtBudget.DataField = "CMP_BILL_BUDGET"
        Me.txtBudget.Height = 0.1875!
        Me.txtBudget.Left = 0.5625!
        Me.txtBudget.Name = "txtBudget"
        Me.txtBudget.OutputFormat = resources.GetString("txtBudget.OutputFormat")
        Me.txtBudget.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtBudget.Text = Nothing
        Me.txtBudget.Top = 0.1875!
        Me.txtBudget.Width = 6.875!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.CanShrink = True
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtEstDefaultComment})
        Me.GroupFooter3.Height = 0.2604167!
        Me.GroupFooter3.KeepTogether = True
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'GroupHeader4
        '
        Me.GroupHeader4.DataField = "CMPQUOTE"
        Me.GroupHeader4.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader4.Height = 0.0!
        Me.GroupHeader4.Name = "GroupHeader4"
        Me.GroupHeader4.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter4
        '
        Me.GroupFooter4.CanShrink = True
        Me.GroupFooter4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAuthorizedBy, Me.txtPreparedBy, Me.txtClientApprovalText, Me.txtApprovedBy, Me.txtDate, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.EmpSigPic, Me.AuthDate})
        Me.GroupFooter4.Height = 1.09375!
        Me.GroupFooter4.KeepTogether = True
        Me.GroupFooter4.Name = "GroupFooter4"
        Me.GroupFooter4.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'EmpSigPic
        '
        Me.EmpSigPic.Height = 0.75!
        Me.EmpSigPic.ImageData = Nothing
        Me.EmpSigPic.Left = 1.4375!
        Me.EmpSigPic.Name = "EmpSigPic"
        Me.EmpSigPic.Top = 0.0!
        Me.EmpSigPic.Width = 3.5!
        '
        'AuthDate
        '
        Me.AuthDate.Height = 0.1875!
        Me.AuthDate.Left = 5.6875!
        Me.AuthDate.Name = "AuthDate"
        Me.AuthDate.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.AuthDate.Text = Nothing
        Me.AuthDate.Top = 0.5625!
        Me.AuthDate.Width = 1.1875!
        '
        'GroupHeader5
        '
        Me.GroupHeader5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCampaign, Me.TextBox11, Me.txtBudget, Me.TextBox12})
        Me.GroupHeader5.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader5.Height = 0.3958333!
        Me.GroupHeader5.Name = "GroupHeader5"
        Me.GroupHeader5.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter5
        '
        Me.GroupFooter5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox8, Me.txtTotalForEst, Me.txtTax, Me.txtCommission, Me.txtSubTotal, Me.txtContTotal2, Me.txtContTotal, Me.txtMUContTotal, Me.TextBox5, Me.TextBox6, Me.txtBudgetTotal, Me.txtVariance, Me.SubReport1, Me.Line2, Me.Line3, Me.Line9, Me.Line10})
        Me.GroupFooter5.Height = 1.041667!
        Me.GroupFooter5.KeepTogether = True
        Me.GroupFooter5.Name = "GroupFooter5"
        '
        'GroupHeader6
        '
        Me.GroupHeader6.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtEstimateComments, Me.txtQuoteComments, Me.txtRevisionComments, Me.txtComponentComments, Me.txtPIF, Me.txtpiflabel, Me.txtFBDate, Me.txtPO, Me.txtPOLabel, Me.txtFB, Me.txtEstimateHdr, Me.quote, Me.est, Me.estcomp, Me.rev, Me.txtJobNumber, Me.txtJobCompNumber})
        Me.GroupHeader6.Height = 0.40625!
        Me.GroupHeader6.Name = "GroupHeader6"
        '
        'GroupFooter6
        '
        Me.GroupFooter6.CanShrink = True
        Me.GroupFooter6.Height = 0.0!
        Me.GroupFooter6.Name = "GroupFooter6"
        '
        'GroupHeader7
        '
        Me.GroupHeader7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtJobCompDesc})
        Me.GroupHeader7.Height = 0.21875!
        Me.GroupHeader7.Name = "GroupHeader7"
        '
        'txtJobCompDesc
        '
        Me.txtJobCompDesc.CanShrink = True
        Me.txtJobCompDesc.DataField = "JOB_COMP_DESC"
        Me.txtJobCompDesc.Height = 0.1875!
        Me.txtJobCompDesc.Left = 0.0625!
        Me.txtJobCompDesc.Name = "txtJobCompDesc"
        Me.txtJobCompDesc.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtJobCompDesc.Text = Nothing
        Me.txtJobCompDesc.Top = 0.0!
        Me.txtJobCompDesc.Width = 5.9375!
        '
        'GroupFooter7
        '
        Me.GroupFooter7.Height = 0.08333334!
        Me.GroupFooter7.Name = "GroupFooter7"
        '
        'arptEstimatingSS1
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.25!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader4)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.GroupHeader5)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader6)
        Me.Sections.Add(Me.GroupHeader7)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter7)
        Me.Sections.Add(Me.GroupFooter6)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter5)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter4)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black; ddo-char-set: 204", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddress1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLineTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescriptionText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContingency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarkupAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTerms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxableText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisionNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFBDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpiflabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPIF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstimateHdr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.est, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.estcomp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.quote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponentComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisionComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstimateComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalForEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContTotal2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBudgetTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVariance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientApprovalText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPreparedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAuthorizedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApprovedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstDefaultComment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFunctionType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFunctionHeading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsideDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhaseDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUContGrouping, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.txtClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAttnLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAttnClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAttnProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCampaign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents txtName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddress1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtDescriptionText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQty As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClientApprovalText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPreparedBy As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAuthorizedBy As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtApprovedBy As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalForEst As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtFunctionType As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtFunctionHeading As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtInsideDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstDefaultComment As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuoteComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisionComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTerms As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSubTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCommission As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComponentComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstimateComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContingency As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMarkupAmt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContTotal2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMarkupAmtGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLineTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxableText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPhaseDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtIO As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMUCont As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMUContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtMUContGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader5 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader6 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter6 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader7 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter7 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtEstimateHdr As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDates As DataDynamics.ActiveReports.TextBox
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
    Friend WithEvents estcomp As DataDynamics.ActiveReports.TextBox
    Friend WithEvents est As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents rev As DataDynamics.ActiveReports.TextBox
    Friend WithEvents quote As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAttnLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAttnClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddressInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAttnProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAccountContact As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCampaign As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBudget As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtFBDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtpiflabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuoteNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisionNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPIF As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPO As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPOLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFB As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBudgetTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVariance As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPhoneNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents EmpSigPic As DataDynamics.ActiveReports.Picture
    Friend WithEvents AuthDate As DataDynamics.ActiveReports.TextBox
End Class
