<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEstimatingTap
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEstimatingTap))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddress1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTitle = New DataDynamics.ActiveReports.TextBox()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.txtLineTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtQty = New DataDynamics.ActiveReports.TextBox()
        Me.txtAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtRate = New DataDynamics.ActiveReports.TextBox()
        Me.txtContingency = New DataDynamics.ActiveReports.TextBox()
        Me.txtMarkupAmt = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtIO = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUCont = New DataDynamics.ActiveReports.TextBox()
        Me.txtExtAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtFunctionType = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.txtTerms = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxableText = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.txtEstNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuoteNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisionNumber = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox21 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox27 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox28 = New DataDynamics.ActiveReports.TextBox()
        Me.quote = New DataDynamics.ActiveReports.TextBox()
        Me.est = New DataDynamics.ActiveReports.TextBox()
        Me.estcomp = New DataDynamics.ActiveReports.TextBox()
        Me.rev = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobCompDesc = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.txtTax = New DataDynamics.ActiveReports.TextBox()
        Me.txtCommission = New DataDynamics.ActiveReports.TextBox()
        Me.txtSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtContTotal2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtAuthorizedBy = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.txtTotalGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtContGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtMarkupAmtGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUContGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
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
        Me.txtAddressInfo = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.txtclient = New DataDynamics.ActiveReports.TextBox()
        Me.txtDivision = New DataDynamics.ActiveReports.TextBox()
        Me.txtProduct = New DataDynamics.ActiveReports.TextBox()
        Me.txtJob = New DataDynamics.ActiveReports.TextBox()
        Me.txtComp = New DataDynamics.ActiveReports.TextBox()
        Me.txtCampaignComments = New DataDynamics.ActiveReports.TextBox()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.SubReport3 = New DataDynamics.ActiveReports.SubReport()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.txtEstDefaultComment = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox39 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox40 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox41 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox42 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox43 = New DataDynamics.ActiveReports.TextBox()
        Me.EmpSigPic = New DataDynamics.ActiveReports.Picture()
        Me.txtClientApprovalText = New DataDynamics.ActiveReports.TextBox()
        Me.txtPreparedBy = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox35 = New DataDynamics.ActiveReports.TextBox()
        Me.txtApprovedBy = New DataDynamics.ActiveReports.TextBox()
        Me.txtDate = New DataDynamics.ActiveReports.TextBox()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.Line12 = New DataDynamics.ActiveReports.Line()
        Me.Line13 = New DataDynamics.ActiveReports.Line()
        Me.AuthDate = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader()
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader7 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox32 = New DataDynamics.ActiveReports.TextBox()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter7 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox34 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxAmt = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox36 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox37 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox38 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxlabel = New DataDynamics.ActiveReports.TextBox()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLineTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContingency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarkupAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExtAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFunctionType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxableText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisionNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.quote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.est, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.estcomp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContTotal2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAuthorizedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUContGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.txtAddressInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtclient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCampaignComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstDefaultComment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientApprovalText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPreparedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApprovedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxlabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.txtName, Me.txtAddress1, Me.txtTitle, Me.Line4, Me.Line5})
        Me.PageHeader1.Height = 2.03125!
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
        Me.txtName.Left = 0.062!
        Me.txtName.Name = "txtName"
        Me.txtName.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0"
        Me.txtName.Text = Nothing
        Me.txtName.Top = 1.562!
        Me.txtName.Width = 7.375!
        '
        'txtAddress1
        '
        Me.txtAddress1.CanShrink = True
        Me.txtAddress1.Height = 0.0625!
        Me.txtAddress1.Left = 0.062!
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAddress1.Text = Nothing
        Me.txtAddress1.Top = 1.6245!
        Me.txtAddress1.Width = 7.375!
        '
        'txtTitle
        '
        Me.txtTitle.CanGrow = False
        Me.txtTitle.Height = 0.25!
        Me.txtTitle.Left = 0.062!
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Style = "font-size: 12pt; font-weight: bold; text-align: center; vertical-align: top; ddo-" & _
    "char-set: 0"
        Me.txtTitle.Text = "Campaign Estimate"
        Me.txtTitle.Top = 1.75!
        Me.txtTitle.Width = 7.375!
        '
        'Line4
        '
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 0.06150001!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 1.9995!
        Me.Line4.Width = 7.375!
        Me.Line4.X1 = 0.06150001!
        Me.Line4.X2 = 7.4365!
        Me.Line4.Y1 = 1.9995!
        Me.Line4.Y2 = 1.9995!
        '
        'Line5
        '
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.062!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 1.75!
        Me.Line5.Width = 7.375!
        Me.Line5.X1 = 0.062!
        Me.Line5.X2 = 7.437!
        Me.Line5.Y1 = 1.75!
        Me.Line5.Y2 = 1.75!
        '
        'ReportInfo1
        '
        Me.ReportInfo1.CanShrink = True
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.125!
        Me.ReportInfo1.Left = 5.125!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-family: Arial; font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.ReportInfo1.SummaryGroup = "GroupHeader3"
        Me.ReportInfo1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.ReportInfo1.Top = 0.812!
        Me.ReportInfo1.Width = 1.1875!
        '
        'txtLineTotal
        '
        Me.txtLineTotal.CanShrink = True
        Me.txtLineTotal.DataField = "LINE_TOTAL"
        Me.txtLineTotal.Height = 0.1875!
        Me.txtLineTotal.Left = 5.4375!
        Me.txtLineTotal.Name = "txtLineTotal"
        Me.txtLineTotal.Text = Nothing
        Me.txtLineTotal.Top = 0.6875!
        Me.txtLineTotal.Visible = False
        Me.txtLineTotal.Width = 0.125!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtQty, Me.txtAmount, Me.txtRate, Me.txtContingency, Me.txtMarkupAmt, Me.txtTaxAmount, Me.txtTaxCode, Me.txtLineTotal, Me.txtIO, Me.txtMUCont, Me.txtExtAmount, Me.txtFunctionType, Me.TextBox3, Me.TextBox19})
        Me.Detail1.Height = 0.3958333!
        Me.Detail1.Name = "Detail1"
        '
        'txtQty
        '
        Me.txtQty.CanShrink = True
        Me.txtQty.DataField = "EST_REV_QUANTITY"
        Me.txtQty.Height = 0.1875!
        Me.txtQty.Left = 5.625!
        Me.txtQty.Name = "txtQty"
        Me.txtQty.OutputFormat = resources.GetString("txtQty.OutputFormat")
        Me.txtQty.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtQty.Text = Nothing
        Me.txtQty.Top = 0.6875!
        Me.txtQty.Visible = False
        Me.txtQty.Width = 0.125!
        '
        'txtAmount
        '
        Me.txtAmount.CanShrink = True
        Me.txtAmount.DataField = "LINE_TOTAL"
        Me.txtAmount.Height = 0.1875!
        Me.txtAmount.Left = 4.062!
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OutputFormat = resources.GetString("txtAmount.OutputFormat")
        Me.txtAmount.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtAmount.Text = Nothing
        Me.txtAmount.Top = 0.5!
        Me.txtAmount.Visible = False
        Me.txtAmount.Width = 0.06299973!
        '
        'txtRate
        '
        Me.txtRate.CanShrink = True
        Me.txtRate.DataField = "EST_REV_RATE"
        Me.txtRate.Height = 0.1875!
        Me.txtRate.Left = 5.8125!
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRate.Text = Nothing
        Me.txtRate.Top = 0.6875!
        Me.txtRate.Visible = False
        Me.txtRate.Width = 0.125!
        '
        'txtContingency
        '
        Me.txtContingency.CanShrink = True
        Me.txtContingency.DataField = "EXT_CONTINGENCY"
        Me.txtContingency.Height = 0.1875!
        Me.txtContingency.Left = 5.3125!
        Me.txtContingency.Name = "txtContingency"
        Me.txtContingency.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContingency.Text = Nothing
        Me.txtContingency.Top = 0.6875!
        Me.txtContingency.Visible = False
        Me.txtContingency.Width = 0.125!
        '
        'txtMarkupAmt
        '
        Me.txtMarkupAmt.CanShrink = True
        Me.txtMarkupAmt.DataField = "EXT_MARKUP_AMT"
        Me.txtMarkupAmt.Height = 0.125!
        Me.txtMarkupAmt.Left = 6.0625!
        Me.txtMarkupAmt.Name = "txtMarkupAmt"
        Me.txtMarkupAmt.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMarkupAmt.Text = Nothing
        Me.txtMarkupAmt.Top = 0.75!
        Me.txtMarkupAmt.Visible = False
        Me.txtMarkupAmt.Width = 0.0625!
        '
        'txtTaxAmount
        '
        Me.txtTaxAmount.CanShrink = True
        Me.txtTaxAmount.DataField = "TAX"
        Me.txtTaxAmount.Height = 0.1875!
        Me.txtTaxAmount.Left = 6.375!
        Me.txtTaxAmount.Name = "txtTaxAmount"
        Me.txtTaxAmount.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTaxAmount.Text = Nothing
        Me.txtTaxAmount.Top = 0.6875!
        Me.txtTaxAmount.Visible = False
        Me.txtTaxAmount.Width = 0.125!
        '
        'txtTaxCode
        '
        Me.txtTaxCode.CanShrink = True
        Me.txtTaxCode.DataField = "TAX_CODE"
        Me.txtTaxCode.Height = 0.0625!
        Me.txtTaxCode.Left = 6.5625!
        Me.txtTaxCode.Name = "txtTaxCode"
        Me.txtTaxCode.Text = Nothing
        Me.txtTaxCode.Top = 0.75!
        Me.txtTaxCode.Visible = False
        Me.txtTaxCode.Width = 0.125!
        '
        'txtIO
        '
        Me.txtIO.CanShrink = True
        Me.txtIO.DataField = "INOUT"
        Me.txtIO.Height = 0.0625!
        Me.txtIO.Left = 6.75!
        Me.txtIO.Name = "txtIO"
        Me.txtIO.Text = Nothing
        Me.txtIO.Top = 0.75!
        Me.txtIO.Visible = False
        Me.txtIO.Width = 0.125!
        '
        'txtMUCont
        '
        Me.txtMUCont.CanShrink = True
        Me.txtMUCont.DataField = "EXT_MU_CONT"
        Me.txtMUCont.Height = 0.1875!
        Me.txtMUCont.Left = 6.1875!
        Me.txtMUCont.Name = "txtMUCont"
        Me.txtMUCont.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUCont.Text = Nothing
        Me.txtMUCont.Top = 0.6875!
        Me.txtMUCont.Visible = False
        Me.txtMUCont.Width = 0.125!
        '
        'txtExtAmount
        '
        Me.txtExtAmount.CanShrink = True
        Me.txtExtAmount.DataField = "EST_REV_EXT_AMT"
        Me.txtExtAmount.Height = 0.1875!
        Me.txtExtAmount.Left = 6.375!
        Me.txtExtAmount.Name = "txtExtAmount"
        Me.txtExtAmount.OutputFormat = resources.GetString("txtExtAmount.OutputFormat")
        Me.txtExtAmount.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtExtAmount.Text = Nothing
        Me.txtExtAmount.Top = 0.0!
        Me.txtExtAmount.Width = 1.0!
        '
        'txtFunctionType
        '
        Me.txtFunctionType.CanShrink = True
        Me.txtFunctionType.DataField = "EST_FNC_TYPE"
        Me.txtFunctionType.Height = 0.0625!
        Me.txtFunctionType.Left = 4.937!
        Me.txtFunctionType.Name = "txtFunctionType"
        Me.txtFunctionType.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtFunctionType.Text = Nothing
        Me.txtFunctionType.Top = 0.7500001!
        Me.txtFunctionType.Visible = False
        Me.txtFunctionType.Width = 0.25!
        '
        'TextBox3
        '
        Me.TextBox3.CanShrink = True
        Me.TextBox3.DataField = "FNC_DESCRIPTION"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 0.25!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 4.312!
        '
        'TextBox19
        '
        Me.TextBox19.CanShrink = True
        Me.TextBox19.DataField = "EST_FNC_COMMENT"
        Me.TextBox19.Height = 0.1875!
        Me.TextBox19.Left = 0.437!
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.TextBox19.Text = Nothing
        Me.TextBox19.Top = 0.187!
        Me.TextBox19.Width = 5.875!
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
        Me.txtTaxableText.Width = 7.375!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtEstNumber, Me.txtEstCompNumber, Me.txtQuoteNumber, Me.txtRevisionNumber, Me.TextBox20, Me.TextBox21, Me.TextBox27, Me.TextBox28, Me.quote, Me.est, Me.estcomp, Me.rev, Me.txtJobNumber, Me.txtJobCompNumber, Me.txtJobDesc, Me.txtJobCompDesc, Me.TextBox6, Me.TextBox11})
        Me.GroupHeader1.DataField = "JOBCOMP"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader1.Height = 0.2708332!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtEstNumber
        '
        Me.txtEstNumber.CanShrink = True
        Me.txtEstNumber.DataField = "ESTIMATE_NUMBER"
        Me.txtEstNumber.Height = 0.1875!
        Me.txtEstNumber.Left = 0.0625!
        Me.txtEstNumber.Name = "txtEstNumber"
        Me.txtEstNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstNumber.Text = Nothing
        Me.txtEstNumber.Top = 2.0625!
        Me.txtEstNumber.Visible = False
        Me.txtEstNumber.Width = 0.125!
        '
        'txtEstCompNumber
        '
        Me.txtEstCompNumber.CanShrink = True
        Me.txtEstCompNumber.DataField = "EST_COMPONENT_NBR"
        Me.txtEstCompNumber.Height = 0.1875!
        Me.txtEstCompNumber.Left = 0.25!
        Me.txtEstCompNumber.Name = "txtEstCompNumber"
        Me.txtEstCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstCompNumber.Text = Nothing
        Me.txtEstCompNumber.Top = 2.0625!
        Me.txtEstCompNumber.Visible = False
        Me.txtEstCompNumber.Width = 0.125!
        '
        'txtQuoteNumber
        '
        Me.txtQuoteNumber.CanShrink = True
        Me.txtQuoteNumber.DataField = "EST_QUOTE_NBR"
        Me.txtQuoteNumber.Height = 0.1875!
        Me.txtQuoteNumber.Left = 0.4375!
        Me.txtQuoteNumber.Name = "txtQuoteNumber"
        Me.txtQuoteNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtQuoteNumber.Text = Nothing
        Me.txtQuoteNumber.Top = 2.0625!
        Me.txtQuoteNumber.Visible = False
        Me.txtQuoteNumber.Width = 0.125!
        '
        'txtRevisionNumber
        '
        Me.txtRevisionNumber.CanShrink = True
        Me.txtRevisionNumber.DataField = "EST_REV_NBR"
        Me.txtRevisionNumber.Height = 0.1875!
        Me.txtRevisionNumber.Left = 0.625!
        Me.txtRevisionNumber.Name = "txtRevisionNumber"
        Me.txtRevisionNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtRevisionNumber.Text = Nothing
        Me.txtRevisionNumber.Top = 2.0625!
        Me.txtRevisionNumber.Visible = False
        Me.txtRevisionNumber.Width = 0.125!
        '
        'TextBox20
        '
        Me.TextBox20.CanShrink = True
        Me.TextBox20.Height = 0.1875!
        Me.TextBox20.Left = 0.06200004!
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox20.Text = "Job:"
        Me.TextBox20.Top = 0.062!
        Me.TextBox20.Width = 0.438!
        '
        'TextBox21
        '
        Me.TextBox21.CanShrink = True
        Me.TextBox21.Height = 0.1875!
        Me.TextBox21.Left = 3.75!
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox21.Text = "Component:"
        Me.TextBox21.Top = 0.06200001!
        Me.TextBox21.Width = 0.8125!
        '
        'TextBox27
        '
        Me.TextBox27.CanShrink = True
        Me.TextBox27.DataField = "JOB_NUMBER"
        Me.TextBox27.Height = 0.1875!
        Me.TextBox27.Left = 0.562!
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox27.Text = Nothing
        Me.TextBox27.Top = 0.062!
        Me.TextBox27.Width = 0.5!
        '
        'TextBox28
        '
        Me.TextBox28.CanShrink = True
        Me.TextBox28.DataField = "JOB_COMPONENT_NBR"
        Me.TextBox28.Height = 0.1875!
        Me.TextBox28.Left = 4.625!
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox28.Text = Nothing
        Me.TextBox28.Top = 0.06200001!
        Me.TextBox28.Width = 0.5!
        '
        'quote
        '
        Me.quote.CanShrink = True
        Me.quote.DataField = "EST_QUOTE_NBR"
        Me.quote.Height = 0.1875!
        Me.quote.Left = 6.687!
        Me.quote.Name = "quote"
        Me.quote.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.quote.Text = Nothing
        Me.quote.Top = 2.062!
        Me.quote.Visible = False
        Me.quote.Width = 0.125!
        '
        'est
        '
        Me.est.CanShrink = True
        Me.est.DataField = "ESTIMATE_NUMBER"
        Me.est.Height = 0.1875!
        Me.est.Left = 6.312!
        Me.est.Name = "est"
        Me.est.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.est.Text = Nothing
        Me.est.Top = 2.062!
        Me.est.Visible = False
        Me.est.Width = 0.125!
        '
        'estcomp
        '
        Me.estcomp.CanShrink = True
        Me.estcomp.DataField = "EST_COMPONENT_NBR"
        Me.estcomp.Height = 0.1875!
        Me.estcomp.Left = 6.4995!
        Me.estcomp.Name = "estcomp"
        Me.estcomp.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.estcomp.Text = Nothing
        Me.estcomp.Top = 2.062!
        Me.estcomp.Visible = False
        Me.estcomp.Width = 0.125!
        '
        'rev
        '
        Me.rev.CanShrink = True
        Me.rev.DataField = "EST_REV_NBR"
        Me.rev.Height = 0.1875!
        Me.rev.Left = 6.8745!
        Me.rev.Name = "rev"
        Me.rev.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.rev.Text = Nothing
        Me.rev.Top = 2.062!
        Me.rev.Visible = False
        Me.rev.Width = 0.125!
        '
        'txtJobNumber
        '
        Me.txtJobNumber.CanShrink = True
        Me.txtJobNumber.DataField = "JOB_NUMBER"
        Me.txtJobNumber.Height = 0.1875!
        Me.txtJobNumber.Left = 7.1245!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobNumber.Text = Nothing
        Me.txtJobNumber.Top = 2.062!
        Me.txtJobNumber.Width = 0.125!
        '
        'txtJobCompNumber
        '
        Me.txtJobCompNumber.CanShrink = True
        Me.txtJobCompNumber.DataField = "JOB_COMPONENT_NBR"
        Me.txtJobCompNumber.Height = 0.1875!
        Me.txtJobCompNumber.Left = 7.312!
        Me.txtJobCompNumber.Name = "txtJobCompNumber"
        Me.txtJobCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobCompNumber.Text = Nothing
        Me.txtJobCompNumber.Top = 2.062!
        Me.txtJobCompNumber.Width = 0.125!
        '
        'txtJobDesc
        '
        Me.txtJobDesc.CanShrink = True
        Me.txtJobDesc.DataField = "JOB_DESC"
        Me.txtJobDesc.Height = 0.1875!
        Me.txtJobDesc.Left = 1.062!
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtJobDesc.Text = Nothing
        Me.txtJobDesc.Top = 0.062!
        Me.txtJobDesc.Width = 2.25!
        '
        'txtJobCompDesc
        '
        Me.txtJobCompDesc.CanShrink = True
        Me.txtJobCompDesc.DataField = "JOB_COMP_DESC"
        Me.txtJobCompDesc.Height = 0.1875!
        Me.txtJobCompDesc.Left = 5.125!
        Me.txtJobCompDesc.Name = "txtJobCompDesc"
        Me.txtJobCompDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtJobCompDesc.Text = Nothing
        Me.txtJobCompDesc.Top = 0.06200001!
        Me.txtJobCompDesc.Width = 2.25!
        '
        'TextBox6
        '
        Me.TextBox6.CanShrink = True
        Me.TextBox6.DataField = "EST_REV_EXT_AMT"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 6.375!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.TextBox6.SummaryGroup = "GroupHeader1"
        Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.062!
        Me.TextBox6.Visible = False
        Me.TextBox6.Width = 1.0!
        '
        'TextBox11
        '
        Me.TextBox11.CanShrink = True
        Me.TextBox11.DataField = "EXT_MARKUP_AMT"
        Me.TextBox11.Height = 0.125!
        Me.TextBox11.Left = 6.687!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox11.SummaryGroup = "GroupHeader1"
        Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.375!
        Me.TextBox11.Visible = False
        Me.TextBox11.Width = 0.0625!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line3})
        Me.GroupFooter1.Height = 0.03125!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.062!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.0!
        Me.Line3.Width = 7.313!
        Me.Line3.X1 = 0.062!
        Me.Line3.X2 = 7.375!
        Me.Line3.Y1 = 0.0!
        Me.Line3.Y2 = 0.0!
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
        'txtAuthorizedBy
        '
        Me.txtAuthorizedBy.Height = 0.1875!
        Me.txtAuthorizedBy.Left = 0.062!
        Me.txtAuthorizedBy.Name = "txtAuthorizedBy"
        Me.txtAuthorizedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtAuthorizedBy.Text = "Total Estimated Campaign Costs"
        Me.txtAuthorizedBy.Top = 0.06200001!
        Me.txtAuthorizedBy.Width = 3.3125!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.CanShrink = True
        Me.GroupHeader2.DataField = "ESTCOMPQUOTE"
        Me.GroupHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader2.Height = 0.0!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.Visible = False
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalGrouping, Me.txtTotalLabel, Me.txtContGrouping, Me.txtTaxGrouping, Me.txtMarkupAmtGrouping, Me.TextBox7, Me.txtMUContGrouping, Me.TextBox2, Me.Line1})
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        Me.GroupFooter2.Visible = False
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
        Me.txtTotalLabel.Left = 0.0625!
        Me.txtTotalLabel.Name = "txtTotalLabel"
        Me.txtTotalLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalLabel.Text = "Total Estimated Internal Fees"
        Me.txtTotalLabel.Top = 0.0!
        Me.txtTotalLabel.Width = 3.3125!
        '
        'txtContGrouping
        '
        Me.txtContGrouping.CanShrink = True
        Me.txtContGrouping.DataField = "EXT_CONTINGENCY"
        Me.txtContGrouping.Height = 0.1875!
        Me.txtContGrouping.Left = 2.4375!
        Me.txtContGrouping.Name = "txtContGrouping"
        Me.txtContGrouping.OutputFormat = resources.GetString("txtContGrouping.OutputFormat")
        Me.txtContGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContGrouping.SummaryGroup = "GroupHeader2"
        Me.txtContGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtContGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtContGrouping.Text = Nothing
        Me.txtContGrouping.Top = 0.375!
        Me.txtContGrouping.Visible = False
        Me.txtContGrouping.Width = 0.125!
        '
        'txtTaxGrouping
        '
        Me.txtTaxGrouping.DataField = "TAX"
        Me.txtTaxGrouping.Height = 0.1875!
        Me.txtTaxGrouping.Left = 2.25!
        Me.txtTaxGrouping.Name = "txtTaxGrouping"
        Me.txtTaxGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTaxGrouping.SummaryGroup = "GroupHeader2"
        Me.txtTaxGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTaxGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTaxGrouping.Text = Nothing
        Me.txtTaxGrouping.Top = 0.375!
        Me.txtTaxGrouping.Visible = False
        Me.txtTaxGrouping.Width = 0.125!
        '
        'txtMarkupAmtGrouping
        '
        Me.txtMarkupAmtGrouping.DataField = "EXT_MARKUP_AMT"
        Me.txtMarkupAmtGrouping.Height = 0.1875!
        Me.txtMarkupAmtGrouping.Left = 2.0625!
        Me.txtMarkupAmtGrouping.Name = "txtMarkupAmtGrouping"
        Me.txtMarkupAmtGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMarkupAmtGrouping.SummaryGroup = "GroupHeader2"
        Me.txtMarkupAmtGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMarkupAmtGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMarkupAmtGrouping.Text = Nothing
        Me.txtMarkupAmtGrouping.Top = 0.375!
        Me.txtMarkupAmtGrouping.Visible = False
        Me.txtMarkupAmtGrouping.Width = 0.125!
        '
        'TextBox7
        '
        Me.TextBox7.CanShrink = True
        Me.TextBox7.DataField = "EST_REV_QUANTITY"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 2.8125!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.375!
        Me.TextBox7.Visible = False
        Me.TextBox7.Width = 0.0625!
        '
        'txtMUContGrouping
        '
        Me.txtMUContGrouping.CanShrink = True
        Me.txtMUContGrouping.DataField = "EXT_MU_CONT"
        Me.txtMUContGrouping.Height = 0.1875!
        Me.txtMUContGrouping.Left = 2.625!
        Me.txtMUContGrouping.Name = "txtMUContGrouping"
        Me.txtMUContGrouping.OutputFormat = resources.GetString("txtMUContGrouping.OutputFormat")
        Me.txtMUContGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUContGrouping.SummaryGroup = "GroupHeader2"
        Me.txtMUContGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMUContGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMUContGrouping.Text = Nothing
        Me.txtMUContGrouping.Top = 0.375!
        Me.txtMUContGrouping.Visible = False
        Me.txtMUContGrouping.Width = 0.125!
        '
        'TextBox2
        '
        Me.TextBox2.CanShrink = True
        Me.TextBox2.DataField = "EST_REV_QUANTITY"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 5.25!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.TextBox2.SummaryGroup = "GroupHeader7"
        Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 1.0!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 5.0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 2.375!
        Me.Line1.X1 = 5.0!
        Me.Line1.X2 = 7.375!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.0!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.CanShrink = True
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtPhone, Me.txtCityStateZip, Me.txtFedID, Me.txtAddress2, Me.txtFax, Me.txtEmail, Me.txtCDPContact, Me.txtCCAddress, Me.txtCCState, Me.txtCCZip, Me.txtCCAddress2, Me.txtCCCity, Me.txtAddressInfo, Me.TextBox9, Me.TextBox14, Me.TextBox15, Me.TextBox17, Me.TextBox18, Me.TextBox10, Me.ReportInfo1, Me.SubReport1, Me.txtclient, Me.txtDivision, Me.txtProduct, Me.txtJob, Me.txtComp, Me.txtCampaignComments, Me.Line6, Me.SubReport3})
        Me.GroupHeader3.DataField = "CMPQUOTE"
        Me.GroupHeader3.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader3.Height = 1.21825!
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
        Me.txtPhone.Top = 1.562!
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
        Me.txtCityStateZip.Top = 1.562!
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
        Me.txtFedID.Top = 1.562!
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
        Me.txtAddress2.Top = 1.687!
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
        Me.txtFax.Top = 1.562!
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
        Me.txtEmail.Top = 1.562!
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
        Me.txtCDPContact.Top = 1.562!
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
        Me.txtCCAddress.Top = 1.562!
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
        Me.txtCCState.Top = 1.687!
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
        Me.txtCCZip.Top = 1.687!
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
        Me.txtCCAddress2.Top = 1.687!
        Me.txtCCAddress2.Visible = False
        Me.txtCCAddress2.Width = 0.1875!
        '
        'txtCCCity
        '
        Me.txtCCCity.CanShrink = True
        Me.txtCCCity.DataField = "CONT_CITY"
        Me.txtCCCity.Height = 0.0625!
        Me.txtCCCity.Left = 6.812!
        Me.txtCCCity.Name = "txtCCCity"
        Me.txtCCCity.Style = "font-size: 9pt"
        Me.txtCCCity.Text = Nothing
        Me.txtCCCity.Top = 1.687!
        Me.txtCCCity.Visible = False
        Me.txtCCCity.Width = 0.1875!
        '
        'txtAddressInfo
        '
        Me.txtAddressInfo.CanShrink = True
        Me.txtAddressInfo.Height = 0.0625!
        Me.txtAddressInfo.Left = 0.06250048!
        Me.txtAddressInfo.Name = "txtAddressInfo"
        Me.txtAddressInfo.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAddressInfo.Text = Nothing
        Me.txtAddressInfo.Top = 1.437!
        Me.txtAddressInfo.Visible = False
        Me.txtAddressInfo.Width = 7.375!
        '
        'TextBox9
        '
        Me.TextBox9.CanShrink = True
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 3.75!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox9.Text = "Date:"
        Me.TextBox9.Top = 2.25!
        Me.TextBox9.Visible = False
        Me.TextBox9.Width = 0.5625!
        '
        'TextBox14
        '
        Me.TextBox14.CanShrink = True
        Me.TextBox14.Height = 0.1875!
        Me.TextBox14.Left = 3.75!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox14.Text = "Account Manager:"
        Me.TextBox14.Top = 1.875!
        Me.TextBox14.Visible = False
        Me.TextBox14.Width = 1.25!
        '
        'TextBox15
        '
        Me.TextBox15.CanShrink = True
        Me.TextBox15.Height = 0.1875!
        Me.TextBox15.Left = 3.75!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.TextBox15.Text = "Campaign:"
        Me.TextBox15.Top = 2.063!
        Me.TextBox15.Visible = False
        Me.TextBox15.Width = 0.6875!
        '
        'TextBox17
        '
        Me.TextBox17.CanShrink = True
        Me.TextBox17.DataField = "AE"
        Me.TextBox17.Height = 0.1875!
        Me.TextBox17.Left = 5.0!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox17.Text = Nothing
        Me.TextBox17.Top = 1.875!
        Me.TextBox17.Visible = False
        Me.TextBox17.Width = 2.375!
        '
        'TextBox18
        '
        Me.TextBox18.CanShrink = True
        Me.TextBox18.DataField = "CMP_NAME"
        Me.TextBox18.Height = 0.1875!
        Me.TextBox18.Left = 5.0!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox18.Text = Nothing
        Me.TextBox18.Top = 2.063!
        Me.TextBox18.Visible = False
        Me.TextBox18.Width = 2.375!
        '
        'TextBox10
        '
        Me.TextBox10.CanShrink = True
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 5.0!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 2.25!
        Me.TextBox10.Visible = False
        Me.TextBox10.Width = 2.375!
        '
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.7500001!
        Me.SubReport1.Left = 0.062!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = "SubReport1"
        Me.SubReport1.Top = 0.062!
        Me.SubReport1.Width = 3.313!
        '
        'txtclient
        '
        Me.txtclient.DataField = "CL_CODE"
        Me.txtclient.Height = 0.1875!
        Me.txtclient.Left = 3.0!
        Me.txtclient.Name = "txtclient"
        Me.txtclient.Text = Nothing
        Me.txtclient.Top = 1.562!
        Me.txtclient.Visible = False
        Me.txtclient.Width = 0.125!
        '
        'txtDivision
        '
        Me.txtDivision.DataField = "DIV_CODE"
        Me.txtDivision.Height = 0.1875!
        Me.txtDivision.Left = 3.187!
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.Text = Nothing
        Me.txtDivision.Top = 1.562!
        Me.txtDivision.Visible = False
        Me.txtDivision.Width = 0.125!
        '
        'txtProduct
        '
        Me.txtProduct.DataField = "PRD_CODE"
        Me.txtProduct.Height = 0.1875!
        Me.txtProduct.Left = 3.375!
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Text = Nothing
        Me.txtProduct.Top = 1.562!
        Me.txtProduct.Visible = False
        Me.txtProduct.Width = 0.125!
        '
        'txtJob
        '
        Me.txtJob.CanShrink = True
        Me.txtJob.DataField = "JOB_NUMBER"
        Me.txtJob.Height = 0.1875!
        Me.txtJob.Left = 3.562!
        Me.txtJob.Name = "txtJob"
        Me.txtJob.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtJob.Text = Nothing
        Me.txtJob.Top = 1.562!
        Me.txtJob.Visible = False
        Me.txtJob.Width = 0.125!
        '
        'txtComp
        '
        Me.txtComp.CanShrink = True
        Me.txtComp.DataField = "JOB_COMPONENT_NBR"
        Me.txtComp.Height = 0.1875!
        Me.txtComp.Left = 3.75!
        Me.txtComp.Name = "txtComp"
        Me.txtComp.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtComp.Text = Nothing
        Me.txtComp.Top = 1.562!
        Me.txtComp.Visible = False
        Me.txtComp.Width = 0.1250002!
        '
        'txtCampaignComments
        '
        Me.txtCampaignComments.CanShrink = True
        Me.txtCampaignComments.DataField = "CMP_COMMENTS"
        Me.txtCampaignComments.Height = 0.06300002!
        Me.txtCampaignComments.Left = 0.06200049!
        Me.txtCampaignComments.Name = "txtCampaignComments"
        Me.txtCampaignComments.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 0"
        Me.txtCampaignComments.Text = Nothing
        Me.txtCampaignComments.Top = 1.062!
        Me.txtCampaignComments.Width = 7.375!
        '
        'Line6
        '
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 0.06200048!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 1.187!
        Me.Line6.Width = 7.375!
        Me.Line6.X1 = 0.06200048!
        Me.Line6.X2 = 7.437!
        Me.Line6.Y1 = 1.187!
        Me.Line6.Y2 = 1.187!
        '
        'SubReport3
        '
        Me.SubReport3.CloseBorder = False
        Me.SubReport3.Height = 0.6880001!
        Me.SubReport3.Left = 3.875!
        Me.SubReport3.Name = "SubReport3"
        Me.SubReport3.Report = Nothing
        Me.SubReport3.ReportName = "SubReport3"
        Me.SubReport3.Top = 0.062!
        Me.SubReport3.Width = 3.313!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.CanShrink = True
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAuthorizedBy, Me.txtEstDefaultComment, Me.TextBox5, Me.TextBox39, Me.TextBox40, Me.TextBox41, Me.TextBox42, Me.TextBox43, Me.EmpSigPic, Me.txtClientApprovalText, Me.txtPreparedBy, Me.TextBox35, Me.txtApprovedBy, Me.txtDate, Me.Line10, Me.Line11, Me.Line12, Me.Line13, Me.AuthDate})
        Me.GroupFooter3.Height = 1.937501!
        Me.GroupFooter3.Name = "GroupFooter3"
        Me.GroupFooter3.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'txtEstDefaultComment
        '
        Me.txtEstDefaultComment.CanShrink = True
        Me.txtEstDefaultComment.Height = 0.1875!
        Me.txtEstDefaultComment.Left = 0.062!
        Me.txtEstDefaultComment.Name = "txtEstDefaultComment"
        Me.txtEstDefaultComment.Style = "font-size: 8.25pt; ddo-char-set: 0"
        Me.txtEstDefaultComment.Text = Nothing
        Me.txtEstDefaultComment.Top = 0.3744999!
        Me.txtEstDefaultComment.Width = 7.375!
        '
        'TextBox5
        '
        Me.TextBox5.CanShrink = True
        Me.TextBox5.DataField = "EST_REV_EXT_AMT"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 6.3745!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.TextBox5.SummaryGroup = "GroupHeader3"
        Me.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.06200001!
        Me.TextBox5.Width = 1.0!
        '
        'TextBox39
        '
        Me.TextBox39.CanShrink = True
        Me.TextBox39.DataField = "EXT_CONTINGENCY"
        Me.TextBox39.Height = 0.1875!
        Me.TextBox39.Left = 4.3125!
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.OutputFormat = resources.GetString("TextBox39.OutputFormat")
        Me.TextBox39.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox39.SummaryGroup = "GroupHeader3"
        Me.TextBox39.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox39.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox39.Text = Nothing
        Me.TextBox39.Top = 2.125!
        Me.TextBox39.Visible = False
        Me.TextBox39.Width = 0.125!
        '
        'TextBox40
        '
        Me.TextBox40.DataField = "TAX"
        Me.TextBox40.Height = 0.1875!
        Me.TextBox40.Left = 4.125!
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox40.SummaryGroup = "GroupHeader3"
        Me.TextBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox40.Text = Nothing
        Me.TextBox40.Top = 2.125!
        Me.TextBox40.Visible = False
        Me.TextBox40.Width = 0.125!
        '
        'TextBox41
        '
        Me.TextBox41.DataField = "EXT_MARKUP_AMT"
        Me.TextBox41.Height = 0.1875!
        Me.TextBox41.Left = 3.937!
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox41.SummaryGroup = "GroupHeader3"
        Me.TextBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox41.Text = Nothing
        Me.TextBox41.Top = 2.125!
        Me.TextBox41.Visible = False
        Me.TextBox41.Width = 0.125!
        '
        'TextBox42
        '
        Me.TextBox42.CanShrink = True
        Me.TextBox42.DataField = "EST_REV_QUANTITY"
        Me.TextBox42.Height = 0.1875!
        Me.TextBox42.Left = 4.6875!
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.OutputFormat = resources.GetString("TextBox42.OutputFormat")
        Me.TextBox42.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox42.Text = Nothing
        Me.TextBox42.Top = 2.125!
        Me.TextBox42.Visible = False
        Me.TextBox42.Width = 0.0625!
        '
        'TextBox43
        '
        Me.TextBox43.CanShrink = True
        Me.TextBox43.DataField = "EXT_MU_CONT"
        Me.TextBox43.Height = 0.1875!
        Me.TextBox43.Left = 4.5!
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.OutputFormat = resources.GetString("TextBox43.OutputFormat")
        Me.TextBox43.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox43.SummaryGroup = "GroupHeader3"
        Me.TextBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox43.Text = Nothing
        Me.TextBox43.Top = 2.125!
        Me.TextBox43.Visible = False
        Me.TextBox43.Width = 0.125!
        '
        'EmpSigPic
        '
        Me.EmpSigPic.Height = 0.75!
        Me.EmpSigPic.HyperLink = Nothing
        Me.EmpSigPic.ImageData = Nothing
        Me.EmpSigPic.Left = 1.062!
        Me.EmpSigPic.Name = "EmpSigPic"
        Me.EmpSigPic.Top = 0.687!
        Me.EmpSigPic.Width = 2.75!
        '
        'txtClientApprovalText
        '
        Me.txtClientApprovalText.Height = 0.1875!
        Me.txtClientApprovalText.Left = 3.812!
        Me.txtClientApprovalText.Name = "txtClientApprovalText"
        Me.txtClientApprovalText.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtClientApprovalText.Text = "Client Approval"
        Me.txtClientApprovalText.Top = 1.1245!
        Me.txtClientApprovalText.Width = 1.0!
        '
        'txtPreparedBy
        '
        Me.txtPreparedBy.Height = 0.1875!
        Me.txtPreparedBy.Left = 0.562!
        Me.txtPreparedBy.Name = "txtPreparedBy"
        Me.txtPreparedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtPreparedBy.Text = "Date:"
        Me.txtPreparedBy.Top = 1.687!
        Me.txtPreparedBy.Width = 0.4375!
        '
        'TextBox35
        '
        Me.TextBox35.Height = 0.6875!
        Me.TextBox35.Left = 0.06200004!
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Style = "font-size: 9pt; font-weight: bold; text-align: right; vertical-align: bottom; ddo" & _
    "-char-set: 0"
        Me.TextBox35.Text = "Agency Authorization:"
        Me.TextBox35.Top = 0.812!
        Me.TextBox35.Width = 0.9375!
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.Height = 0.1875!
        Me.txtApprovedBy.Left = 3.937!
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtApprovedBy.Text = "Approved By:"
        Me.txtApprovedBy.Top = 1.312!
        Me.txtApprovedBy.Width = 0.875!
        '
        'txtDate
        '
        Me.txtDate.Height = 0.1875!
        Me.txtDate.Left = 4.312!
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtDate.Text = "Date:"
        Me.txtDate.Top = 1.687!
        Me.txtDate.Width = 0.5!
        '
        'Line10
        '
        Me.Line10.Height = 0.0!
        Me.Line10.Left = 1.062!
        Me.Line10.LineWeight = 2.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 1.8745!
        Me.Line10.Width = 2.75!
        Me.Line10.X1 = 1.062!
        Me.Line10.X2 = 3.812!
        Me.Line10.Y1 = 1.8745!
        Me.Line10.Y2 = 1.8745!
        '
        'Line11
        '
        Me.Line11.Height = 0.0!
        Me.Line11.Left = 1.062!
        Me.Line11.LineWeight = 2.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 1.4995!
        Me.Line11.Width = 2.75!
        Me.Line11.X1 = 1.062!
        Me.Line11.X2 = 3.812!
        Me.Line11.Y1 = 1.4995!
        Me.Line11.Y2 = 1.4995!
        '
        'Line12
        '
        Me.Line12.Height = 0.0!
        Me.Line12.Left = 4.8745!
        Me.Line12.LineWeight = 2.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 1.4995!
        Me.Line12.Width = 2.5625!
        Me.Line12.X1 = 4.8745!
        Me.Line12.X2 = 7.437!
        Me.Line12.Y1 = 1.4995!
        Me.Line12.Y2 = 1.4995!
        '
        'Line13
        '
        Me.Line13.Height = 0.0!
        Me.Line13.Left = 4.8745!
        Me.Line13.LineWeight = 2.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 1.8745!
        Me.Line13.Width = 2.5625!
        Me.Line13.X1 = 4.8745!
        Me.Line13.X2 = 7.437!
        Me.Line13.Y1 = 1.8745!
        Me.Line13.Y2 = 1.8745!
        '
        'AuthDate
        '
        Me.AuthDate.Height = 0.1875!
        Me.AuthDate.Left = 1.1245!
        Me.AuthDate.Name = "AuthDate"
        Me.AuthDate.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.AuthDate.Text = Nothing
        Me.AuthDate.Top = 1.6245!
        Me.AuthDate.Width = 1.1875!
        '
        'GroupHeader4
        '
        Me.GroupHeader4.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader4.Height = 0.0!
        Me.GroupHeader4.Name = "GroupHeader4"
        '
        'GroupFooter4
        '
        Me.GroupFooter4.Height = 0.0!
        Me.GroupFooter4.KeepTogether = True
        Me.GroupFooter4.Name = "GroupFooter4"
        '
        'GroupHeader5
        '
        Me.GroupHeader5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReport2, Me.TextBox12, Me.Line9})
        Me.GroupHeader5.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader5.Height = 0.28075!
        Me.GroupHeader5.Name = "GroupHeader5"
        Me.GroupHeader5.Visible = False
        '
        'SubReport2
        '
        Me.SubReport2.CloseBorder = False
        Me.SubReport2.Height = 0.1880001!
        Me.SubReport2.Left = 0.062!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.ReportName = ""
        Me.SubReport2.Top = 0.0!
        Me.SubReport2.Width = 7.375!
        '
        'TextBox12
        '
        Me.TextBox12.CanShrink = True
        Me.TextBox12.DataField = "CMPQUOTE"
        Me.TextBox12.Height = 0.1875!
        Me.TextBox12.Left = 7.187!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0.687!
        Me.TextBox12.Visible = False
        Me.TextBox12.Width = 0.125!
        '
        'Line9
        '
        Me.Line9.Height = 0.0!
        Me.Line9.Left = 0.062!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.25!
        Me.Line9.Width = 7.375!
        Me.Line9.X1 = 0.062!
        Me.Line9.X2 = 7.437!
        Me.Line9.Y1 = 0.25!
        Me.Line9.Y2 = 0.25!
        '
        'GroupFooter5
        '
        Me.GroupFooter5.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTax, Me.txtCommission, Me.txtSubTotal, Me.txtContTotal2, Me.txtContTotal, Me.txtMUContTotal})
        Me.GroupFooter5.Height = 0.0!
        Me.GroupFooter5.Name = "GroupFooter5"
        '
        'GroupHeader7
        '
        Me.GroupHeader7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox32, Me.Line8})
        Me.GroupHeader7.Height = 0.2083334!
        Me.GroupHeader7.Name = "GroupHeader7"
        '
        'TextBox32
        '
        Me.TextBox32.CanShrink = True
        Me.TextBox32.Height = 0.1875!
        Me.TextBox32.Left = 6.375!
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox32.Text = "Amount"
        Me.TextBox32.Top = 0.0!
        Me.TextBox32.Width = 1.0!
        '
        'Line8
        '
        Me.Line8.Height = 0.0!
        Me.Line8.Left = 6.375!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.187!
        Me.Line8.Width = 1.0!
        Me.Line8.X1 = 6.375!
        Me.Line8.X2 = 7.375!
        Me.Line8.Y1 = 0.187!
        Me.Line8.Y2 = 0.187!
        '
        'GroupFooter7
        '
        Me.GroupFooter7.CanShrink = True
        Me.GroupFooter7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox4, Me.TextBox34, Me.TextBox8, Me.txtTaxAmt, Me.TextBox36, Me.TextBox37, Me.TextBox38, Me.TextBox1, Me.txtTaxlabel, Me.Line2, Me.Line7})
        Me.GroupFooter7.Height = 0.4895835!
        Me.GroupFooter7.Name = "GroupFooter7"
        '
        'TextBox4
        '
        Me.TextBox4.CanShrink = True
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 2.625!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox4.Text = "SubTotal:"
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 3.3125!
        '
        'TextBox34
        '
        Me.TextBox34.CanShrink = True
        Me.TextBox34.DataField = "EST_REV_EXT_AMT"
        Me.TextBox34.Height = 0.1875!
        Me.TextBox34.Left = 6.375!
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.OutputFormat = resources.GetString("TextBox34.OutputFormat")
        Me.TextBox34.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.TextBox34.SummaryGroup = "GroupHeader7"
        Me.TextBox34.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox34.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox34.Text = Nothing
        Me.TextBox34.Top = 0.0!
        Me.TextBox34.Width = 1.0!
        '
        'TextBox8
        '
        Me.TextBox8.CanShrink = True
        Me.TextBox8.DataField = "EXT_CONTINGENCY"
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 2.4995!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox8.SummaryGroup = "GroupHeader7"
        Me.TextBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.7500001!
        Me.TextBox8.Visible = False
        Me.TextBox8.Width = 0.125!
        '
        'txtTaxAmt
        '
        Me.txtTaxAmt.CanShrink = True
        Me.txtTaxAmt.DataField = "TAX"
        Me.txtTaxAmt.Height = 0.1875!
        Me.txtTaxAmt.Left = 6.375!
        Me.txtTaxAmt.Name = "txtTaxAmt"
        Me.txtTaxAmt.OutputFormat = resources.GetString("txtTaxAmt.OutputFormat")
        Me.txtTaxAmt.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTaxAmt.SummaryGroup = "GroupHeader7"
        Me.txtTaxAmt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTaxAmt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTaxAmt.Text = Nothing
        Me.txtTaxAmt.Top = 0.25!
        Me.txtTaxAmt.Width = 1.0!
        '
        'TextBox36
        '
        Me.TextBox36.DataField = "EXT_MARKUP_AMT"
        Me.TextBox36.Height = 0.1875!
        Me.TextBox36.Left = 2.1245!
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox36.SummaryGroup = "GroupHeader7"
        Me.TextBox36.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox36.Text = Nothing
        Me.TextBox36.Top = 0.7500001!
        Me.TextBox36.Visible = False
        Me.TextBox36.Width = 0.125!
        '
        'TextBox37
        '
        Me.TextBox37.CanShrink = True
        Me.TextBox37.DataField = "EST_REV_QUANTITY"
        Me.TextBox37.Height = 0.1875!
        Me.TextBox37.Left = 2.8745!
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.OutputFormat = resources.GetString("TextBox37.OutputFormat")
        Me.TextBox37.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox37.Text = Nothing
        Me.TextBox37.Top = 0.7500001!
        Me.TextBox37.Visible = False
        Me.TextBox37.Width = 0.0625!
        '
        'TextBox38
        '
        Me.TextBox38.CanShrink = True
        Me.TextBox38.DataField = "EXT_MU_CONT"
        Me.TextBox38.Height = 0.1875!
        Me.TextBox38.Left = 2.687!
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.OutputFormat = resources.GetString("TextBox38.OutputFormat")
        Me.TextBox38.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.TextBox38.SummaryGroup = "GroupHeader7"
        Me.TextBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox38.Text = Nothing
        Me.TextBox38.Top = 0.7500001!
        Me.TextBox38.Visible = False
        Me.TextBox38.Width = 0.125!
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.DataField = "EST_REV_QUANTITY"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 3.187!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.TextBox1.SummaryGroup = "GroupHeader7"
        Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.8750001!
        Me.TextBox1.Visible = False
        Me.TextBox1.Width = 1.0!
        '
        'txtTaxlabel
        '
        Me.txtTaxlabel.CanShrink = True
        Me.txtTaxlabel.Height = 0.1875!
        Me.txtTaxlabel.Left = 2.625!
        Me.txtTaxlabel.Name = "txtTaxlabel"
        Me.txtTaxlabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTaxlabel.Text = "Tax:"
        Me.txtTaxlabel.Top = 0.25!
        Me.txtTaxlabel.Width = 3.3125!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 5.25!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.187!
        Me.Line2.Width = 2.125!
        Me.Line2.X1 = 5.25!
        Me.Line2.X2 = 7.375!
        Me.Line2.Y1 = 0.187!
        Me.Line2.Y2 = 0.187!
        '
        'Line7
        '
        Me.Line7.Height = 0.0!
        Me.Line7.Left = 5.25!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.437!
        Me.Line7.Width = 2.125!
        Me.Line7.X1 = 5.25!
        Me.Line7.X2 = 7.375!
        Me.Line7.Y1 = 0.437!
        Me.Line7.Y2 = 0.437!
        '
        'arptEstimatingTap
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
        Me.Sections.Add(Me.GroupHeader7)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter7)
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
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLineTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContingency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarkupAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExtAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFunctionType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTerms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxableText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisionNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.quote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.est, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.estcomp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContTotal2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAuthorizedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUContGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.txtAddressInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtclient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCampaignComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstDefaultComment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientApprovalText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPreparedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApprovedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxlabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents txtName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddress1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtQty As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAuthorizedBy As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtFunctionType As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtTotalGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTerms As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSubTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCommission As DataDynamics.ActiveReports.TextBox
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
    Friend WithEvents txtIO As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMUCont As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMUContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtMUContGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader5 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader7 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter7 As DataDynamics.ActiveReports.GroupFooter
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
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents txtAddressInfo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuoteNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisionNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox18 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox20 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox21 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox27 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox28 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox32 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox34 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtEstDefaultComment As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Private WithEvents Line5 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtTaxAmt As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox36 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox37 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox38 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox39 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox40 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox41 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox42 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox43 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line6 As DataDynamics.ActiveReports.Line
    Private WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Private WithEvents txtclient As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtDivision As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtProduct As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtJob As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtComp As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtCampaignComments As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtExtAmount As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line8 As DataDynamics.ActiveReports.Line
    Private WithEvents txtTaxlabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Private WithEvents quote As DataDynamics.ActiveReports.TextBox
    Private WithEvents est As DataDynamics.ActiveReports.TextBox
    Private WithEvents estcomp As DataDynamics.ActiveReports.TextBox
    Private WithEvents rev As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtJobCompNumber As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtJobDesc As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtJobCompDesc As DataDynamics.ActiveReports.TextBox
    Private WithEvents EmpSigPic As DataDynamics.ActiveReports.Picture
    Private WithEvents txtClientApprovalText As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtPreparedBy As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox35 As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtApprovedBy As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtDate As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line10 As DataDynamics.ActiveReports.Line
    Private WithEvents Line11 As DataDynamics.ActiveReports.Line
    Private WithEvents Line12 As DataDynamics.ActiveReports.Line
    Private WithEvents Line13 As DataDynamics.ActiveReports.Line
    Private WithEvents AuthDate As DataDynamics.ActiveReports.TextBox
    Private WithEvents SubReport2 As DataDynamics.ActiveReports.SubReport
    Private WithEvents Line7 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line3 As DataDynamics.ActiveReports.Line
    Private WithEvents Line9 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox19 As DataDynamics.ActiveReports.TextBox
    Private WithEvents SubReport3 As DataDynamics.ActiveReports.SubReport
End Class
