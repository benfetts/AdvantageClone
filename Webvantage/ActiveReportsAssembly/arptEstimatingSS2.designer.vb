<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEstimatingSS2
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEstimatingSS2))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddress1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTitle = New DataDynamics.ActiveReports.TextBox()
        Me.txtDates = New DataDynamics.ActiveReports.TextBox()
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
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.txtTerms = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxableText = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtFBDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtpiflabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtPIF = New DataDynamics.ActiveReports.TextBox()
        Me.txtPO = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtFB = New DataDynamics.ActiveReports.TextBox()
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
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddressInfo = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.txtAttnProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtAccountContact = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.txtPhoneNumber = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.txtProjectDesc = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
        Me.txtfiscal = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstNumText = New DataDynamics.ActiveReports.TextBox()
        Me.txtJB = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
        Me.txtclcode = New DataDynamics.ActiveReports.TextBox()
        Me.txtdivcode = New DataDynamics.ActiveReports.TextBox()
        Me.txtprdcode = New DataDynamics.ActiveReports.TextBox()
        Me.txtestqtecomments = New DataDynamics.ActiveReports.TextBox()
        Me.txtestrevcomments = New DataDynamics.ActiveReports.TextBox()
        Me.txtProjectBudget = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.EmpSigPic = New DataDynamics.ActiveReports.Picture()
        Me.AuthDate = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
        Me.Line12 = New DataDynamics.ActiveReports.Line()
        Me.lineDate2 = New DataDynamics.ActiveReports.Line()
        Me.lineCA2 = New DataDynamics.ActiveReports.Line()
        Me.txtDate2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtApprovedBy2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientApproval2 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader6 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter6 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader7 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter7 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDates, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.txtFBDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpiflabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPIF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFB, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddressInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAttnProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProjectDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstNumText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtclcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdivcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtprdcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtestqtecomments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtestrevcomments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProjectBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApprovedBy2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientApproval2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.txtName, Me.txtAddress1, Me.txtTitle})
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
        'txtTitle
        '
        Me.txtTitle.CanGrow = False
        Me.txtTitle.Height = 0.25!
        Me.txtTitle.Left = 6.0!
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Style = "font-size: 14.25pt; font-weight: bold; text-align: left; vertical-align: top; ddo" & _
    "-char-set: 0"
        Me.txtTitle.Text = "Estimate"
        Me.txtTitle.Top = 0.625!
        Me.txtTitle.Width = 1.4375!
        '
        'txtDates
        '
        Me.txtDates.CanShrink = True
        Me.txtDates.Height = 0.1875!
        Me.txtDates.Left = 6.0625!
        Me.txtDates.Name = "txtDates"
        Me.txtDates.Style = "font-family: Arial; font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtDates.Text = Nothing
        Me.txtDates.Top = 0.0625!
        Me.txtDates.Width = 1.375!
        '
        'txtLineTotal
        '
        Me.txtLineTotal.CanShrink = True
        Me.txtLineTotal.DataField = "LINE_TOTAL"
        Me.txtLineTotal.Height = 0.1875!
        Me.txtLineTotal.Left = 4.8125!
        Me.txtLineTotal.Name = "txtLineTotal"
        Me.txtLineTotal.Text = Nothing
        Me.txtLineTotal.Top = 0.3125!
        Me.txtLineTotal.Visible = False
        Me.txtLineTotal.Width = 0.125!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDescriptionText, Me.txtQty, Me.txtAmount, Me.txtRate, Me.txtContingency, Me.txtMarkupAmt, Me.txtTaxAmount, Me.txtTaxCode, Me.txtLineTotal, Me.txtIO, Me.txtMUCont})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'txtDescriptionText
        '
        Me.txtDescriptionText.CanShrink = True
        Me.txtDescriptionText.DataField = "FNC_DESCRIPTION"
        Me.txtDescriptionText.Height = 0.1875!
        Me.txtDescriptionText.Left = 0.0625!
        Me.txtDescriptionText.Name = "txtDescriptionText"
        Me.txtDescriptionText.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
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
        Me.txtAmount.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: none; ddo-" & _
    "char-set: 0"
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
        Me.txtContingency.Top = 0.3125!
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
        Me.txtMarkupAmt.Top = 0.3125!
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
        Me.txtTaxAmount.Top = 0.3125!
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
        Me.txtTaxCode.Top = 0.4375!
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
        Me.txtIO.Top = 0.4375!
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
        Me.txtMUCont.Top = 0.3125!
        Me.txtMUCont.Visible = False
        Me.txtMUCont.Width = 0.125!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.062!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.25!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.062!
        Me.Line1.X2 = 7.437!
        Me.Line1.Y1 = 0.25!
        Me.Line1.Y2 = 0.25!
        '
        'Line8
        '
        Me.Line8.Height = 0.0!
        Me.Line8.Left = 0.0625!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.0!
        Me.Line8.Width = 7.375!
        Me.Line8.X1 = 0.0625!
        Me.Line8.X2 = 7.4375!
        Me.Line8.Y1 = 0.0!
        Me.Line8.Y2 = 0.0!
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
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtFBDate
        '
        Me.txtFBDate.CanShrink = True
        Me.txtFBDate.DataField = "JOB_DUE_DATE"
        Me.txtFBDate.Height = 0.1875!
        Me.txtFBDate.Left = 6.0625!
        Me.txtFBDate.Name = "txtFBDate"
        Me.txtFBDate.OutputFormat = resources.GetString("txtFBDate.OutputFormat")
        Me.txtFBDate.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtFBDate.Text = Nothing
        Me.txtFBDate.Top = 1.9375!
        Me.txtFBDate.Width = 1.375!
        '
        'txtpiflabel
        '
        Me.txtpiflabel.CanShrink = True
        Me.txtpiflabel.Height = 0.1875!
        Me.txtpiflabel.Left = 5.3125!
        Me.txtpiflabel.Name = "txtpiflabel"
        Me.txtpiflabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtpiflabel.Text = "PIF:"
        Me.txtpiflabel.Top = 1.0!
        Me.txtpiflabel.Width = 0.75!
        '
        'txtJobNumber
        '
        Me.txtJobNumber.CanShrink = True
        Me.txtJobNumber.DataField = "JOB_NUMBER"
        Me.txtJobNumber.Height = 0.1875!
        Me.txtJobNumber.Left = 3.5!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobNumber.Text = Nothing
        Me.txtJobNumber.Top = 2.75!
        Me.txtJobNumber.Width = 0.125!
        '
        'txtJobCompNumber
        '
        Me.txtJobCompNumber.CanShrink = True
        Me.txtJobCompNumber.DataField = "JOB_COMPONENT_NBR"
        Me.txtJobCompNumber.Height = 0.1875!
        Me.txtJobCompNumber.Left = 3.6875!
        Me.txtJobCompNumber.Name = "txtJobCompNumber"
        Me.txtJobCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobCompNumber.Text = Nothing
        Me.txtJobCompNumber.Top = 2.75!
        Me.txtJobCompNumber.Width = 0.125!
        '
        'txtPIF
        '
        Me.txtPIF.CanShrink = True
        Me.txtPIF.DataField = "JOB_VER_VALUE"
        Me.txtPIF.Height = 0.1875!
        Me.txtPIF.Left = 6.0625!
        Me.txtPIF.Name = "txtPIF"
        Me.txtPIF.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtPIF.Text = Nothing
        Me.txtPIF.Top = 1.0!
        Me.txtPIF.Width = 1.375!
        '
        'txtPO
        '
        Me.txtPO.CanShrink = True
        Me.txtPO.DataField = "JOB_CL_PO_NBR"
        Me.txtPO.Height = 0.1875!
        Me.txtPO.Left = 6.0625!
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtPO.Text = Nothing
        Me.txtPO.Top = 0.8125!
        Me.txtPO.Width = 1.375!
        '
        'txtJobDesc
        '
        Me.txtJobDesc.CanShrink = True
        Me.txtJobDesc.DataField = "JOB_DESC"
        Me.txtJobDesc.Height = 0.1875!
        Me.txtJobDesc.Left = 0.9375!
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.txtJobDesc.Text = Nothing
        Me.txtJobDesc.Top = 1.9375!
        Me.txtJobDesc.Width = 3.5!
        '
        'txtFB
        '
        Me.txtFB.CanShrink = True
        Me.txtFB.Height = 0.1875!
        Me.txtFB.Left = 4.75!
        Me.txtFB.Name = "txtFB"
        Me.txtFB.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtFB.Text = "Forecasted Bill Date:"
        Me.txtFB.Top = 1.9375!
        Me.txtFB.Width = 1.3125!
        '
        'rev
        '
        Me.rev.CanShrink = True
        Me.rev.DataField = "EST_REV_NBR"
        Me.rev.Height = 0.1875!
        Me.rev.Left = 3.3125!
        Me.rev.Name = "rev"
        Me.rev.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.rev.Text = Nothing
        Me.rev.Top = 2.75!
        Me.rev.Visible = False
        Me.rev.Width = 0.125!
        '
        'est
        '
        Me.est.CanShrink = True
        Me.est.DataField = "ESTIMATE_NUMBER"
        Me.est.Height = 0.1875!
        Me.est.Left = 2.75!
        Me.est.Name = "est"
        Me.est.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.est.Text = Nothing
        Me.est.Top = 2.75!
        Me.est.Visible = False
        Me.est.Width = 0.125!
        '
        'estcomp
        '
        Me.estcomp.CanShrink = True
        Me.estcomp.DataField = "EST_COMPONENT_NBR"
        Me.estcomp.Height = 0.1875!
        Me.estcomp.Left = 2.9375!
        Me.estcomp.Name = "estcomp"
        Me.estcomp.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.estcomp.Text = Nothing
        Me.estcomp.Top = 2.75!
        Me.estcomp.Visible = False
        Me.estcomp.Width = 0.125!
        '
        'quote
        '
        Me.quote.CanShrink = True
        Me.quote.DataField = "EST_QUOTE_NBR"
        Me.quote.Height = 0.1875!
        Me.quote.Left = 3.125!
        Me.quote.Name = "quote"
        Me.quote.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.quote.Text = Nothing
        Me.quote.Top = 2.75!
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
        Me.txtComponentComments.Top = 0.0625!
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
        Me.txtQuoteComments.Top = 0.125!
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
        Me.txtRevisionComments.Top = 0.1875!
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
        Me.txtEstimateComments.Top = 0.0!
        Me.txtEstimateComments.Width = 7.3125!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox8, Me.txtTotalForEst, Me.txtTax, Me.txtCommission, Me.txtSubTotal, Me.txtContTotal2, Me.txtContTotal, Me.txtMUContTotal, Me.Line8})
        Me.GroupFooter1.Height = 0.3125!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 0.0625!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox8.Text = "Total Estimate:"
        Me.TextBox8.Top = 0.0625!
        Me.TextBox8.Width = 1.1875!
        '
        'txtTotalForEst
        '
        Me.txtTotalForEst.DataField = "LINE_TOTAL"
        Me.txtTotalForEst.Height = 0.1875!
        Me.txtTotalForEst.Left = 6.4375!
        Me.txtTotalForEst.Name = "txtTotalForEst"
        Me.txtTotalForEst.OutputFormat = resources.GetString("txtTotalForEst.OutputFormat")
        Me.txtTotalForEst.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalForEst.SummaryGroup = "GroupHeader1"
        Me.txtTotalForEst.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalForEst.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTotalForEst.Text = Nothing
        Me.txtTotalForEst.Top = 0.0625!
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
        Me.txtPreparedBy.Left = 5.062!
        Me.txtPreparedBy.Name = "txtPreparedBy"
        Me.txtPreparedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtPreparedBy.Text = "Date:"
        Me.txtPreparedBy.Top = 1.0!
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
        Me.txtApprovedBy.Height = 0.312!
        Me.txtApprovedBy.Left = 0.0625!
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtApprovedBy.Text = "P&G Marketing Specialist:"
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
        Me.Line4.Left = 1.437!
        Me.Line4.LineWeight = 2.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 1.187!
        Me.Line4.Width = 3.5!
        Me.Line4.X1 = 1.437!
        Me.Line4.X2 = 4.937!
        Me.Line4.Y1 = 1.187!
        Me.Line4.Y2 = 1.187!
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
        Me.Line7.Left = 5.562!
        Me.Line7.LineWeight = 2.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 1.187!
        Me.Line7.Width = 1.8125!
        Me.Line7.X1 = 5.562!
        Me.Line7.X2 = 7.3745!
        Me.Line7.Y1 = 1.187!
        Me.Line7.Y2 = 1.187!
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
        Me.GroupHeader3.CanShrink = True
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtPhone, Me.txtCityStateZip, Me.txtFedID, Me.txtAddress2, Me.txtFax, Me.txtEmail, Me.txtCDPContact, Me.txtCCAddress, Me.txtCCState, Me.txtCCZip, Me.txtCCAddress2, Me.txtCCCity, Me.txtClient, Me.txtProduct, Me.txtAddressInfo, Me.TextBox9, Me.txtAttnProduct, Me.txtAccountContact, Me.TextBox11, Me.TextBox12, Me.TextBox10, Me.txtPhoneNumber, Me.TextBox1, Me.txtDates, Me.TextBox2, Me.TextBox3, Me.TextBox13, Me.TextBox14, Me.txtpiflabel, Me.txtPIF, Me.txtPO, Me.TextBox15, Me.txtFB, Me.txtFBDate, Me.txtJobDesc, Me.TextBox18, Me.txtfiscal, Me.est, Me.rev, Me.estcomp, Me.quote, Me.txtJobNumber, Me.txtJobCompNumber, Me.txtEstNumText, Me.txtJB, Me.TextBox20, Me.txtclcode, Me.txtdivcode, Me.txtprdcode, Me.txtProjectBudget, Me.TextBox6, Me.TextBox16})
        Me.GroupHeader3.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader3.Height = 2.322917!
        Me.GroupHeader3.Name = "GroupHeader3"
        Me.GroupHeader3.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'txtPhone
        '
        Me.txtPhone.CanShrink = True
        Me.txtPhone.Height = 0.0625!
        Me.txtPhone.Left = 5.6875!
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtPhone.Text = Nothing
        Me.txtPhone.Top = 2.8125!
        Me.txtPhone.Visible = False
        Me.txtPhone.Width = 0.1875!
        '
        'txtCityStateZip
        '
        Me.txtCityStateZip.CanShrink = True
        Me.txtCityStateZip.Height = 0.0625!
        Me.txtCityStateZip.Left = 5.9375!
        Me.txtCityStateZip.Name = "txtCityStateZip"
        Me.txtCityStateZip.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCityStateZip.Text = Nothing
        Me.txtCityStateZip.Top = 2.8125!
        Me.txtCityStateZip.Visible = False
        Me.txtCityStateZip.Width = 0.1875!
        '
        'txtFedID
        '
        Me.txtFedID.CanShrink = True
        Me.txtFedID.Height = 0.0625!
        Me.txtFedID.Left = 6.625!
        Me.txtFedID.Name = "txtFedID"
        Me.txtFedID.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtFedID.Text = Nothing
        Me.txtFedID.Top = 2.8125!
        Me.txtFedID.Visible = False
        Me.txtFedID.Width = 0.125!
        '
        'txtAddress2
        '
        Me.txtAddress2.CanShrink = True
        Me.txtAddress2.Height = 0.0625!
        Me.txtAddress2.Left = 5.6875!
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Style = "font-size: 9pt"
        Me.txtAddress2.Text = Nothing
        Me.txtAddress2.Top = 2.9375!
        Me.txtAddress2.Visible = False
        Me.txtAddress2.Width = 0.1875!
        '
        'txtFax
        '
        Me.txtFax.CanShrink = True
        Me.txtFax.Height = 0.0625!
        Me.txtFax.Left = 6.1875!
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Style = "font-size: 9pt"
        Me.txtFax.Text = Nothing
        Me.txtFax.Top = 2.8125!
        Me.txtFax.Visible = False
        Me.txtFax.Width = 0.125!
        '
        'txtEmail
        '
        Me.txtEmail.CanShrink = True
        Me.txtEmail.Height = 0.0625!
        Me.txtEmail.Left = 6.4375!
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Style = "font-size: 9pt"
        Me.txtEmail.Text = Nothing
        Me.txtEmail.Top = 2.8125!
        Me.txtEmail.Visible = False
        Me.txtEmail.Width = 0.125!
        '
        'txtCDPContact
        '
        Me.txtCDPContact.DataField = "CONT_FML"
        Me.txtCDPContact.Height = 0.1875!
        Me.txtCDPContact.Left = 5.25!
        Me.txtCDPContact.Name = "txtCDPContact"
        Me.txtCDPContact.Text = Nothing
        Me.txtCDPContact.Top = 2.8125!
        Me.txtCDPContact.Visible = False
        Me.txtCDPContact.Width = 0.125!
        '
        'txtCCAddress
        '
        Me.txtCCAddress.CanShrink = True
        Me.txtCCAddress.DataField = "CONT_ADDRESS1"
        Me.txtCCAddress.Height = 0.0625!
        Me.txtCCAddress.Left = 6.8125!
        Me.txtCCAddress.Name = "txtCCAddress"
        Me.txtCCAddress.Style = "font-size: 9pt"
        Me.txtCCAddress.Text = Nothing
        Me.txtCCAddress.Top = 2.8125!
        Me.txtCCAddress.Visible = False
        Me.txtCCAddress.Width = 0.1875!
        '
        'txtCCState
        '
        Me.txtCCState.CanShrink = True
        Me.txtCCState.DataField = "CONT_STATE"
        Me.txtCCState.Height = 0.0625!
        Me.txtCCState.Left = 6.3125!
        Me.txtCCState.Name = "txtCCState"
        Me.txtCCState.Style = "font-size: 9pt"
        Me.txtCCState.Text = Nothing
        Me.txtCCState.Top = 2.9375!
        Me.txtCCState.Visible = False
        Me.txtCCState.Width = 0.1875!
        '
        'txtCCZip
        '
        Me.txtCCZip.CanShrink = True
        Me.txtCCZip.DataField = "CONT_ZIP"
        Me.txtCCZip.Height = 0.0625!
        Me.txtCCZip.Left = 6.5625!
        Me.txtCCZip.Name = "txtCCZip"
        Me.txtCCZip.Style = "font-size: 9pt"
        Me.txtCCZip.Text = Nothing
        Me.txtCCZip.Top = 2.9375!
        Me.txtCCZip.Visible = False
        Me.txtCCZip.Width = 0.1875!
        '
        'txtCCAddress2
        '
        Me.txtCCAddress2.CanShrink = True
        Me.txtCCAddress2.DataField = "CONT_ADDRESS2"
        Me.txtCCAddress2.Height = 0.0625!
        Me.txtCCAddress2.Left = 6.0625!
        Me.txtCCAddress2.Name = "txtCCAddress2"
        Me.txtCCAddress2.Style = "font-size: 9pt"
        Me.txtCCAddress2.Text = Nothing
        Me.txtCCAddress2.Top = 2.9375!
        Me.txtCCAddress2.Visible = False
        Me.txtCCAddress2.Width = 0.1875!
        '
        'txtCCCity
        '
        Me.txtCCCity.CanShrink = True
        Me.txtCCCity.DataField = "CONT_CITY"
        Me.txtCCCity.Height = 0.0625!
        Me.txtCCCity.Left = 6.8125!
        Me.txtCCCity.Name = "txtCCCity"
        Me.txtCCCity.Style = "font-size: 9pt"
        Me.txtCCCity.Text = Nothing
        Me.txtCCCity.Top = 2.9375!
        Me.txtCCCity.Visible = False
        Me.txtCCCity.Width = 0.1875!
        '
        'txtClient
        '
        Me.txtClient.CanShrink = True
        Me.txtClient.DataField = "CL_NAME"
        Me.txtClient.Height = 0.1875!
        Me.txtClient.Left = 0.0625!
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtClient.Text = Nothing
        Me.txtClient.Top = 0.0625!
        Me.txtClient.Width = 4.375!
        '
        'txtProduct
        '
        Me.txtProduct.CanShrink = True
        Me.txtProduct.DataField = "PRD_DESCRIPTION"
        Me.txtProduct.Height = 0.1875!
        Me.txtProduct.Left = 0.0625!
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtProduct.Text = Nothing
        Me.txtProduct.Top = 0.25!
        Me.txtProduct.Width = 4.375!
        '
        'txtAddressInfo
        '
        Me.txtAddressInfo.CanShrink = True
        Me.txtAddressInfo.Height = 0.5625!
        Me.txtAddressInfo.Left = 0.0625!
        Me.txtAddressInfo.Name = "txtAddressInfo"
        Me.txtAddressInfo.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAddressInfo.Text = Nothing
        Me.txtAddressInfo.Top = 0.625!
        Me.txtAddressInfo.Width = 4.375!
        '
        'TextBox9
        '
        Me.TextBox9.CanShrink = True
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 0.0625!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox9.Text = "Attn:"
        Me.TextBox9.Top = 1.5!
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
        Me.txtAttnProduct.Top = 1.5!
        Me.txtAttnProduct.Width = 4.0625!
        '
        'txtAccountContact
        '
        Me.txtAccountContact.CanShrink = True
        Me.txtAccountContact.Height = 0.1875!
        Me.txtAccountContact.Left = 6.0625!
        Me.txtAccountContact.Name = "txtAccountContact"
        Me.txtAccountContact.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtAccountContact.Text = Nothing
        Me.txtAccountContact.Top = 1.3125!
        Me.txtAccountContact.Width = 1.375!
        '
        'TextBox11
        '
        Me.TextBox11.CanShrink = True
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 0.0625!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox11.Text = "Project Name:"
        Me.TextBox11.Top = 1.9375!
        Me.TextBox11.Width = 0.875!
        '
        'TextBox12
        '
        Me.TextBox12.CanShrink = True
        Me.TextBox12.Height = 0.1875!
        Me.TextBox12.Left = 0.0625!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox12.Text = "Project Budget:"
        Me.TextBox12.Top = 2.125!
        Me.TextBox12.Width = 1.0!
        '
        'TextBox10
        '
        Me.TextBox10.CanShrink = True
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 4.8125!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox10.Text = "Account Contact:"
        Me.TextBox10.Top = 1.3125!
        Me.TextBox10.Width = 1.25!
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.CanShrink = True
        Me.txtPhoneNumber.Height = 0.1875!
        Me.txtPhoneNumber.Left = 6.0625!
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtPhoneNumber.Text = Nothing
        Me.txtPhoneNumber.Top = 1.5!
        Me.txtPhoneNumber.Width = 1.375!
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 5.3125!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox1.Text = "Date:"
        Me.TextBox1.Top = 0.0625!
        Me.TextBox1.Width = 0.75!
        '
        'TextBox2
        '
        Me.TextBox2.CanShrink = True
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 5.3125!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox2.Text = "Estimate #:"
        Me.TextBox2.Top = 0.25!
        Me.TextBox2.Width = 0.75!
        '
        'TextBox3
        '
        Me.TextBox3.CanShrink = True
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 5.3125!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox3.Text = "Job #:"
        Me.TextBox3.Top = 0.4375!
        Me.TextBox3.Width = 0.75!
        '
        'TextBox13
        '
        Me.TextBox13.CanShrink = True
        Me.TextBox13.Height = 0.1875!
        Me.TextBox13.Left = 5.3125!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox13.Text = "Quote #:"
        Me.TextBox13.Top = 0.625!
        Me.TextBox13.Width = 0.75!
        '
        'TextBox14
        '
        Me.TextBox14.CanShrink = True
        Me.TextBox14.Height = 0.1875!
        Me.TextBox14.Left = 5.3125!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox14.Text = "Client PO:"
        Me.TextBox14.Top = 0.8125!
        Me.TextBox14.Width = 0.75!
        '
        'TextBox15
        '
        Me.TextBox15.CanShrink = True
        Me.TextBox15.Height = 0.1875!
        Me.TextBox15.Left = 5.3125!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox15.Text = "Phone:"
        Me.TextBox15.Top = 1.5!
        Me.TextBox15.Width = 0.75!
        '
        'txtProjectDesc
        '
        Me.txtProjectDesc.CanShrink = True
        Me.txtProjectDesc.Height = 0.1875!
        Me.txtProjectDesc.Left = 1.312!
        Me.txtProjectDesc.Name = "txtProjectDesc"
        Me.txtProjectDesc.OutputFormat = resources.GetString("txtProjectDesc.OutputFormat")
        Me.txtProjectDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtProjectDesc.Text = Nothing
        Me.txtProjectDesc.Top = 0.0!
        Me.txtProjectDesc.Width = 6.125!
        '
        'TextBox17
        '
        Me.TextBox17.CanShrink = True
        Me.TextBox17.Height = 0.1875!
        Me.TextBox17.Left = 0.062!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox17.Text = "Project Description:"
        Me.TextBox17.Top = 0.0!
        Me.TextBox17.Width = 1.25!
        '
        'TextBox18
        '
        Me.TextBox18.CanShrink = True
        Me.TextBox18.Height = 0.1875!
        Me.TextBox18.Left = 4.75!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox18.Text = "Fiscal Period:"
        Me.TextBox18.Top = 2.125!
        Me.TextBox18.Width = 1.3125!
        '
        'txtfiscal
        '
        Me.txtfiscal.CanShrink = True
        Me.txtfiscal.Height = 0.1875!
        Me.txtfiscal.Left = 6.0625!
        Me.txtfiscal.Name = "txtfiscal"
        Me.txtfiscal.OutputFormat = resources.GetString("txtfiscal.OutputFormat")
        Me.txtfiscal.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtfiscal.Text = Nothing
        Me.txtfiscal.Top = 2.125!
        Me.txtfiscal.Width = 1.375!
        '
        'txtEstNumText
        '
        Me.txtEstNumText.CanShrink = True
        Me.txtEstNumText.DataField = "ESTIMATE_NUMBER"
        Me.txtEstNumText.Height = 0.1875!
        Me.txtEstNumText.Left = 6.0625!
        Me.txtEstNumText.Name = "txtEstNumText"
        Me.txtEstNumText.Style = "font-family: Arial; font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstNumText.Text = Nothing
        Me.txtEstNumText.Top = 0.25!
        Me.txtEstNumText.Width = 1.375!
        '
        'txtJB
        '
        Me.txtJB.CanShrink = True
        Me.txtJB.Height = 0.1875!
        Me.txtJB.Left = 6.0625!
        Me.txtJB.Name = "txtJB"
        Me.txtJB.Style = "font-family: Arial; font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJB.Text = Nothing
        Me.txtJB.Top = 0.4375!
        Me.txtJB.Width = 1.375!
        '
        'TextBox20
        '
        Me.TextBox20.CanShrink = True
        Me.TextBox20.DataField = "EST_QUOTE_NBR"
        Me.TextBox20.Height = 0.1875!
        Me.TextBox20.Left = 6.0625!
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Style = "font-family: Arial; font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.TextBox20.Text = Nothing
        Me.TextBox20.Top = 0.625!
        Me.TextBox20.Width = 1.375!
        '
        'txtclcode
        '
        Me.txtclcode.CanShrink = True
        Me.txtclcode.DataField = "CL_CODE"
        Me.txtclcode.Height = 0.1875!
        Me.txtclcode.Left = 3.875!
        Me.txtclcode.Name = "txtclcode"
        Me.txtclcode.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtclcode.Text = Nothing
        Me.txtclcode.Top = 2.75!
        Me.txtclcode.Visible = False
        Me.txtclcode.Width = 0.125!
        '
        'txtdivcode
        '
        Me.txtdivcode.CanShrink = True
        Me.txtdivcode.DataField = "DIV_CODE"
        Me.txtdivcode.Height = 0.1875!
        Me.txtdivcode.Left = 4.0625!
        Me.txtdivcode.Name = "txtdivcode"
        Me.txtdivcode.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtdivcode.Text = Nothing
        Me.txtdivcode.Top = 2.75!
        Me.txtdivcode.Width = 0.125!
        '
        'txtprdcode
        '
        Me.txtprdcode.CanShrink = True
        Me.txtprdcode.DataField = "PRD_CODE"
        Me.txtprdcode.Height = 0.1875!
        Me.txtprdcode.Left = 4.25!
        Me.txtprdcode.Name = "txtprdcode"
        Me.txtprdcode.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtprdcode.Text = Nothing
        Me.txtprdcode.Top = 2.75!
        Me.txtprdcode.Width = 0.125!
        '
        'txtestqtecomments
        '
        Me.txtestqtecomments.CanShrink = True
        Me.txtestqtecomments.DataField = "EST_QTE_COMMENT"
        Me.txtestqtecomments.Height = 0.1875!
        Me.txtestqtecomments.Left = 0.875!
        Me.txtestqtecomments.Name = "txtestqtecomments"
        Me.txtestqtecomments.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtestqtecomments.Text = Nothing
        Me.txtestqtecomments.Top = 0.5!
        Me.txtestqtecomments.Visible = False
        Me.txtestqtecomments.Width = 0.125!
        '
        'txtestrevcomments
        '
        Me.txtestrevcomments.CanShrink = True
        Me.txtestrevcomments.DataField = "EST_REV_COMMENT"
        Me.txtestrevcomments.Height = 0.1875!
        Me.txtestrevcomments.Left = 1.125!
        Me.txtestrevcomments.Name = "txtestrevcomments"
        Me.txtestrevcomments.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtestrevcomments.Text = Nothing
        Me.txtestrevcomments.Top = 0.5!
        Me.txtestrevcomments.Visible = False
        Me.txtestrevcomments.Width = 0.125!
        '
        'txtProjectBudget
        '
        Me.txtProjectBudget.DataField = "JOB_COMP_BUDGET_AM"
        Me.txtProjectBudget.Height = 0.1875!
        Me.txtProjectBudget.Left = 1.0625!
        Me.txtProjectBudget.Name = "txtProjectBudget"
        Me.txtProjectBudget.OutputFormat = resources.GetString("txtProjectBudget.OutputFormat")
        Me.txtProjectBudget.Style = "font-size: 9pt"
        Me.txtProjectBudget.Text = Nothing
        Me.txtProjectBudget.Top = 2.125!
        Me.txtProjectBudget.Width = 3.375!
        '
        'TextBox6
        '
        Me.TextBox6.CanShrink = True
        Me.TextBox6.DataField = "JOB_COMP_DESC"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 1.25!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "font-size: 9pt; font-weight: normal; ddo-char-set: 0"
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 1.75!
        Me.TextBox6.Width = 3.1875!
        '
        'TextBox16
        '
        Me.TextBox16.CanShrink = True
        Me.TextBox16.Height = 0.1875!
        Me.TextBox16.Left = 0.0625!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox16.Text = "Component Name:"
        Me.TextBox16.Top = 1.75!
        Me.TextBox16.Width = 1.1875!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.CanShrink = True
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtClientApprovalText, Me.txtPreparedBy, Me.txtAuthorizedBy, Me.txtApprovedBy, Me.txtDate, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.EmpSigPic, Me.AuthDate, Me.TextBox5, Me.Line11, Me.TextBox19, Me.Line12})
        Me.GroupFooter3.Height = 1.46875!
        Me.GroupFooter3.KeepTogether = True
        Me.GroupFooter3.Name = "GroupFooter3"
        Me.GroupFooter3.NewPage = DataDynamics.ActiveReports.NewPage.After
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
        'TextBox5
        '
        Me.TextBox5.Height = 0.1870001!
        Me.TextBox5.Left = 0.062!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox5.Text = "P&G Manager:"
        Me.TextBox5.Top = 1.25!
        Me.TextBox5.Width = 1.2495!
        '
        'Line11
        '
        Me.Line11.Height = 0.0!
        Me.Line11.Left = 1.437!
        Me.Line11.LineWeight = 2.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 1.437!
        Me.Line11.Width = 3.5!
        Me.Line11.X1 = 1.437!
        Me.Line11.X2 = 4.937!
        Me.Line11.Y1 = 1.437!
        Me.Line11.Y2 = 1.437!
        '
        'TextBox19
        '
        Me.TextBox19.Height = 0.1875!
        Me.TextBox19.Left = 5.062!
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox19.Text = "Date:"
        Me.TextBox19.Top = 1.25!
        Me.TextBox19.Width = 0.4375!
        '
        'Line12
        '
        Me.Line12.Height = 0.0!
        Me.Line12.Left = 5.562!
        Me.Line12.LineWeight = 2.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 1.437!
        Me.Line12.Width = 1.8125!
        Me.Line12.X1 = 5.562!
        Me.Line12.X2 = 7.3745!
        Me.Line12.Y1 = 1.437!
        Me.Line12.Y2 = 1.437!
        '
        'lineDate2
        '
        Me.lineDate2.Height = 0.0!
        Me.lineDate2.Left = 4.875!
        Me.lineDate2.LineWeight = 2.0!
        Me.lineDate2.Name = "lineDate2"
        Me.lineDate2.Top = 0.6875!
        Me.lineDate2.Width = 2.5625!
        Me.lineDate2.X1 = 4.875!
        Me.lineDate2.X2 = 7.4375!
        Me.lineDate2.Y1 = 0.6875!
        Me.lineDate2.Y2 = 0.6875!
        '
        'lineCA2
        '
        Me.lineCA2.Height = 0.0!
        Me.lineCA2.Left = 4.875!
        Me.lineCA2.LineWeight = 2.0!
        Me.lineCA2.Name = "lineCA2"
        Me.lineCA2.Top = 0.4375!
        Me.lineCA2.Width = 2.5625!
        Me.lineCA2.X1 = 4.875!
        Me.lineCA2.X2 = 7.4375!
        Me.lineCA2.Y1 = 0.4375!
        Me.lineCA2.Y2 = 0.4375!
        '
        'txtDate2
        '
        Me.txtDate2.Height = 0.1875!
        Me.txtDate2.Left = 4.0!
        Me.txtDate2.Name = "txtDate2"
        Me.txtDate2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtDate2.Text = "Date:"
        Me.txtDate2.Top = 0.5!
        Me.txtDate2.Width = 0.8125!
        '
        'txtApprovedBy2
        '
        Me.txtApprovedBy2.Height = 0.1875!
        Me.txtApprovedBy2.Left = 3.9375!
        Me.txtApprovedBy2.Name = "txtApprovedBy2"
        Me.txtApprovedBy2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtApprovedBy2.Text = "Approved By:"
        Me.txtApprovedBy2.Top = 0.25!
        Me.txtApprovedBy2.Width = 0.875!
        '
        'txtClientApproval2
        '
        Me.txtClientApproval2.Height = 0.1875!
        Me.txtClientApproval2.Left = 3.75!
        Me.txtClientApproval2.Name = "txtClientApproval2"
        Me.txtClientApproval2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtClientApproval2.Text = "Client Approval"
        Me.txtClientApproval2.Top = 0.0625!
        Me.txtClientApproval2.Width = 1.0625!
        '
        'GroupHeader4
        '
        Me.GroupHeader4.DataField = "ESTCOMPQUOTE"
        Me.GroupHeader4.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader4.Height = 0.0!
        Me.GroupHeader4.Name = "GroupHeader4"
        Me.GroupHeader4.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter4
        '
        Me.GroupFooter4.CanShrink = True
        Me.GroupFooter4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtClientApproval2, Me.txtApprovedBy2, Me.txtDate2, Me.lineCA2, Me.lineDate2})
        Me.GroupFooter4.Height = 0.0!
        Me.GroupFooter4.KeepTogether = True
        Me.GroupFooter4.Name = "GroupFooter4"
        Me.GroupFooter4.Visible = False
        '
        'GroupHeader5
        '
        Me.GroupHeader5.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader5.Height = 0.0!
        Me.GroupHeader5.Name = "GroupHeader5"
        Me.GroupHeader5.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter5
        '
        Me.GroupFooter5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtEstDefaultComment})
        Me.GroupFooter5.Height = 0.3020833!
        Me.GroupFooter5.Name = "GroupFooter5"
        '
        'GroupHeader6
        '
        Me.GroupHeader6.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtEstimateComments, Me.txtQuoteComments, Me.txtRevisionComments, Me.txtComponentComments})
        Me.GroupHeader6.Height = 0.0!
        Me.GroupHeader6.Name = "GroupHeader6"
        Me.GroupHeader6.Visible = False
        '
        'GroupFooter6
        '
        Me.GroupFooter6.CanShrink = True
        Me.GroupFooter6.Height = 0.0!
        Me.GroupFooter6.Name = "GroupFooter6"
        '
        'GroupHeader7
        '
        Me.GroupHeader7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox17, Me.txtProjectDesc, Me.Line1, Me.txtestrevcomments, Me.txtestqtecomments})
        Me.GroupHeader7.Height = 0.28125!
        Me.GroupHeader7.Name = "GroupHeader7"
        '
        'GroupFooter7
        '
        Me.GroupFooter7.Height = 0.0!
        Me.GroupFooter7.Name = "GroupFooter7"
        '
        'arptEstimatingSS2
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
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDates, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.txtFBDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpiflabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPIF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFB, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAddressInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAttnProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProjectDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstNumText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtclcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdivcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtprdcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtestqtecomments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtestrevcomments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProjectBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApprovedBy2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientApproval2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtClientApproval2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtApprovedBy2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDate2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lineCA2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lineDate2 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader5 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader6 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter6 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader7 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter7 As DataDynamics.ActiveReports.GroupFooter
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
    Friend WithEvents rev As DataDynamics.ActiveReports.TextBox
    Friend WithEvents quote As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClient As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddressInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAttnProduct As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAccountContact As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtFBDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtpiflabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPIF As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPO As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFB As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPhoneNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProjectDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox18 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtfiscal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstNumText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJB As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox20 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtclcode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtdivcode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtprdcode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtestqtecomments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtestrevcomments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtProjectBudget As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox16 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents EmpSigPic As DataDynamics.ActiveReports.Picture
    Friend WithEvents AuthDate As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line11 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBox19 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line12 As DataDynamics.ActiveReports.Line
End Class
