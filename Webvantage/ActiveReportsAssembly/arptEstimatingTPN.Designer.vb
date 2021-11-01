<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEstimatingTPN
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEstimatingTPN))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddress1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTitle = New DataDynamics.ActiveReports.TextBox()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.txtEstLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientRefLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.txtSalesClassLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuoteNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisionNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstDescription = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstCompDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuoteDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobCompDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientRef = New DataDynamics.ActiveReports.TextBox()
        Me.txtSalesClass = New DataDynamics.ActiveReports.TextBox()
        Me.txtAccExeLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtAccountExective = New DataDynamics.ActiveReports.TextBox()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.txtEstQuantityLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstQuantity = New DataDynamics.ActiveReports.TextBox()
        Me.txtCPULabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtCPU = New DataDynamics.ActiveReports.TextBox()
        Me.TxtCPMLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtCPM = New DataDynamics.ActiveReports.TextBox()
        Me.txtLineTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtDescriptionText = New DataDynamics.ActiveReports.TextBox()
        Me.txtQty = New DataDynamics.ActiveReports.TextBox()
        Me.txtAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtFunctionComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxable = New DataDynamics.ActiveReports.TextBox()
        Me.txtCommissionable = New DataDynamics.ActiveReports.TextBox()
        Me.txtRate = New DataDynamics.ActiveReports.TextBox()
        Me.txtContingency = New DataDynamics.ActiveReports.TextBox()
        Me.txtMarkupAmt = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtSuppliedByNotes = New DataDynamics.ActiveReports.TextBox()
        Me.txtIO = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUCont = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxFunctionDescription = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.txtTerms = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxableText = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDueDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtCompanyLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtCompany = New DataDynamics.ActiveReports.TextBox()
        Me.txtBusinessLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtBusiness = New DataDynamics.ActiveReports.TextBox()
        Me.txtComponentComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtQtyHrs = New DataDynamics.ActiveReports.TextBox()
        Me.txtAmountText = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuoteComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisionComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstimateComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescription = New DataDynamics.ActiveReports.TextBox()
        Me.txtRateLabel = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalForEst = New DataDynamics.ActiveReports.TextBox()
        Me.txtCommissionLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtTax = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtCommission = New DataDynamics.ActiveReports.TextBox()
        Me.txtSubTotalLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtContTotal2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtContLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.AuthDate = New DataDynamics.ActiveReports.TextBox()
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
        Me.txtGroupTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtGroupingTax = New DataDynamics.ActiveReports.TextBox()
        Me.txtCGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUCGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.txtTotalGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtContGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtMarkupAmtGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUContGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.txtEst = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstimateHdr = New DataDynamics.ActiveReports.TextBox()
        Me.txtDates = New DataDynamics.ActiveReports.TextBox()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
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
        Me.estcomp = New DataDynamics.ActiveReports.TextBox()
        Me.est = New DataDynamics.ActiveReports.TextBox()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.rev = New DataDynamics.ActiveReports.TextBox()
        Me.quote = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.EmpSigPic = New DataDynamics.ActiveReports.Picture()
        Me.lineDate2 = New DataDynamics.ActiveReports.Line()
        Me.lineCA2 = New DataDynamics.ActiveReports.Line()
        Me.txtDate2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtApprovedBy2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientApproval2 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line12 = New DataDynamics.ActiveReports.Line()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
        Me.Line13 = New DataDynamics.ActiveReports.Line()
        Me.Line14 = New DataDynamics.ActiveReports.Line()
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
        Me.Line15 = New DataDynamics.ActiveReports.Line()
        Me.Line16 = New DataDynamics.ActiveReports.Line()
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader6 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter6 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader7 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter7 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox21 = New DataDynamics.ActiveReports.TextBox()
        Me.Line17 = New DataDynamics.ActiveReports.Line()
        Me.GroupHeader8 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter8 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader9 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter9 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox46 = New DataDynamics.ActiveReports.TextBox()
        Me.Line28 = New DataDynamics.ActiveReports.Line()
        Me.Picture2 = New DataDynamics.ActiveReports.Picture()
        Me.TextBox47 = New DataDynamics.ActiveReports.TextBox()
        Me.Line29 = New DataDynamics.ActiveReports.Line()
        Me.TextBox24 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox25 = New DataDynamics.ActiveReports.TextBox()
        Me.Line32 = New DataDynamics.ActiveReports.Line()
        Me.Line33 = New DataDynamics.ActiveReports.Line()
        Me.TextBoxAuthDate = New DataDynamics.ActiveReports.TextBox()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientRefLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalesClassLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisionNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalesClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccExeLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountExective, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstQuantityLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCPULabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCPU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCPMLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLineTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescriptionText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFunctionComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommissionable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContingency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarkupAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSuppliedByNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxFunctionDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxableText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBusinessLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBusiness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponentComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQtyHrs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmountText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisionComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstimateComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalForEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommissionLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContTotal2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.txtGroupTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroupingTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUCGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUContGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstimateHdr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDates, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.estcomp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.est, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.quote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApprovedBy2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientApproval2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxAuthDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.txtName, Me.txtAddress1, Me.txtTitle, Me.Line3, Me.Line1})
        Me.PageHeader1.Height = 2.052083!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 1.5!
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.0625!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.Top = 0.0!
        Me.Picture1.Width = 7.45!
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
        Me.txtTitle.Height = 0.25!
        Me.txtTitle.Left = 0.0625!
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Style = "font-size: 12pt; font-weight: bold; text-align: center; vertical-align: middle; d" & _
    "do-char-set: 0"
        Me.txtTitle.Text = "Estimate"
        Me.txtTitle.Top = 1.75!
        Me.txtTitle.Width = 7.375!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.75!
        Me.Line3.Width = 7.375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 7.4375!
        Me.Line3.Y1 = 1.75!
        Me.Line3.Y2 = 1.75!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 2.0!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.4375!
        Me.Line1.Y1 = 2.0!
        Me.Line1.Y2 = 2.0!
        '
        'txtEstLabel
        '
        Me.txtEstLabel.CanShrink = True
        Me.txtEstLabel.Height = 0.1875!
        Me.txtEstLabel.Left = 0.0625!
        Me.txtEstLabel.Name = "txtEstLabel"
        Me.txtEstLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtEstLabel.Text = "Estimate:"
        Me.txtEstLabel.Top = 0.0625!
        Me.txtEstLabel.Width = 0.8125!
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0625!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox1.Text = "Component:"
        Me.TextBox1.Top = 0.25!
        Me.TextBox1.Width = 0.8125!
        '
        'TextBox2
        '
        Me.TextBox2.CanShrink = True
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 0.0625!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox2.Text = "Quote:"
        Me.TextBox2.Top = 0.4375!
        Me.TextBox2.Width = 0.8125!
        '
        'TextBox3
        '
        Me.TextBox3.CanShrink = True
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 0.0625!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox3.Text = "Revision:"
        Me.TextBox3.Top = 0.625!
        Me.TextBox3.Width = 0.8125!
        '
        'txtClientRefLabel
        '
        Me.txtClientRefLabel.CanShrink = True
        Me.txtClientRefLabel.Height = 0.1875!
        Me.txtClientRefLabel.Left = 3.75!
        Me.txtClientRefLabel.Name = "txtClientRefLabel"
        Me.txtClientRefLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtClientRefLabel.Text = "Client Reference:"
        Me.txtClientRefLabel.Top = 0.4375!
        Me.txtClientRefLabel.Width = 1.375!
        '
        'TextBox5
        '
        Me.TextBox5.CanShrink = True
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 3.75!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox5.Text = "Component:"
        Me.TextBox5.Top = 0.25!
        Me.TextBox5.Width = 0.8125!
        '
        'TextBox6
        '
        Me.TextBox6.CanShrink = True
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 3.75!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox6.Text = "Job:"
        Me.TextBox6.Top = 0.0625!
        Me.TextBox6.Width = 0.8125!
        '
        'txtSalesClassLabel
        '
        Me.txtSalesClassLabel.CanShrink = True
        Me.txtSalesClassLabel.Height = 0.1875!
        Me.txtSalesClassLabel.Left = 3.75!
        Me.txtSalesClassLabel.Name = "txtSalesClassLabel"
        Me.txtSalesClassLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtSalesClassLabel.Text = "Sales Class:"
        Me.txtSalesClassLabel.Top = 1.0!
        Me.txtSalesClassLabel.Width = 0.8125!
        '
        'txtEstNumber
        '
        Me.txtEstNumber.CanShrink = True
        Me.txtEstNumber.DataField = "ESTIMATE_NUMBER"
        Me.txtEstNumber.Height = 0.1875!
        Me.txtEstNumber.Left = 0.9375!
        Me.txtEstNumber.Name = "txtEstNumber"
        Me.txtEstNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstNumber.Text = Nothing
        Me.txtEstNumber.Top = 0.0625!
        Me.txtEstNumber.Width = 0.5!
        '
        'txtJobNumber
        '
        Me.txtJobNumber.CanShrink = True
        Me.txtJobNumber.DataField = "JOB_NUMBER"
        Me.txtJobNumber.Height = 0.1875!
        Me.txtJobNumber.Left = 4.625!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobNumber.Text = Nothing
        Me.txtJobNumber.Top = 0.0625!
        Me.txtJobNumber.Width = 0.5!
        '
        'txtEstCompNumber
        '
        Me.txtEstCompNumber.CanShrink = True
        Me.txtEstCompNumber.DataField = "EST_COMPONENT_NBR"
        Me.txtEstCompNumber.Height = 0.1875!
        Me.txtEstCompNumber.Left = 0.9375!
        Me.txtEstCompNumber.Name = "txtEstCompNumber"
        Me.txtEstCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstCompNumber.Text = Nothing
        Me.txtEstCompNumber.Top = 0.25!
        Me.txtEstCompNumber.Width = 0.5!
        '
        'txtJobCompNumber
        '
        Me.txtJobCompNumber.CanShrink = True
        Me.txtJobCompNumber.DataField = "JOB_COMPONENT_NBR"
        Me.txtJobCompNumber.Height = 0.1875!
        Me.txtJobCompNumber.Left = 4.625!
        Me.txtJobCompNumber.Name = "txtJobCompNumber"
        Me.txtJobCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobCompNumber.Text = Nothing
        Me.txtJobCompNumber.Top = 0.25!
        Me.txtJobCompNumber.Width = 0.5!
        '
        'txtQuoteNumber
        '
        Me.txtQuoteNumber.CanShrink = True
        Me.txtQuoteNumber.DataField = "EST_QUOTE_NBR"
        Me.txtQuoteNumber.Height = 0.1875!
        Me.txtQuoteNumber.Left = 0.9375!
        Me.txtQuoteNumber.Name = "txtQuoteNumber"
        Me.txtQuoteNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtQuoteNumber.Text = Nothing
        Me.txtQuoteNumber.Top = 0.4375!
        Me.txtQuoteNumber.Width = 0.5!
        '
        'txtRevisionNumber
        '
        Me.txtRevisionNumber.CanShrink = True
        Me.txtRevisionNumber.DataField = "EST_REV_NBR"
        Me.txtRevisionNumber.Height = 0.1875!
        Me.txtRevisionNumber.Left = 0.9375!
        Me.txtRevisionNumber.Name = "txtRevisionNumber"
        Me.txtRevisionNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtRevisionNumber.Text = Nothing
        Me.txtRevisionNumber.Top = 0.625!
        Me.txtRevisionNumber.Width = 0.5!
        '
        'txtEstDescription
        '
        Me.txtEstDescription.CanShrink = True
        Me.txtEstDescription.DataField = "EST_LOG_DESC"
        Me.txtEstDescription.Height = 0.1875!
        Me.txtEstDescription.Left = 1.4375!
        Me.txtEstDescription.Name = "txtEstDescription"
        Me.txtEstDescription.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtEstDescription.Text = Nothing
        Me.txtEstDescription.Top = 0.0625!
        Me.txtEstDescription.Width = 2.25!
        '
        'txtEstCompDesc
        '
        Me.txtEstCompDesc.CanShrink = True
        Me.txtEstCompDesc.DataField = "EST_COMP_DESC"
        Me.txtEstCompDesc.Height = 0.1875!
        Me.txtEstCompDesc.Left = 1.4375!
        Me.txtEstCompDesc.Name = "txtEstCompDesc"
        Me.txtEstCompDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtEstCompDesc.Text = Nothing
        Me.txtEstCompDesc.Top = 0.25!
        Me.txtEstCompDesc.Width = 2.25!
        '
        'txtQuoteDesc
        '
        Me.txtQuoteDesc.CanShrink = True
        Me.txtQuoteDesc.DataField = "EST_QUOTE_DESC"
        Me.txtQuoteDesc.Height = 0.1875!
        Me.txtQuoteDesc.Left = 1.4375!
        Me.txtQuoteDesc.Name = "txtQuoteDesc"
        Me.txtQuoteDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtQuoteDesc.Text = Nothing
        Me.txtQuoteDesc.Top = 0.4375!
        Me.txtQuoteDesc.Width = 2.25!
        '
        'txtJobDesc
        '
        Me.txtJobDesc.CanShrink = True
        Me.txtJobDesc.DataField = "JOB_DESC"
        Me.txtJobDesc.Height = 0.1875!
        Me.txtJobDesc.Left = 5.125!
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtJobDesc.Text = Nothing
        Me.txtJobDesc.Top = 0.0625!
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
        Me.txtJobCompDesc.Top = 0.25!
        Me.txtJobCompDesc.Width = 2.25!
        '
        'txtClientRef
        '
        Me.txtClientRef.CanShrink = True
        Me.txtClientRef.DataField = "JOB_CLI_REF"
        Me.txtClientRef.Height = 0.1875!
        Me.txtClientRef.Left = 5.125!
        Me.txtClientRef.Name = "txtClientRef"
        Me.txtClientRef.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtClientRef.Text = Nothing
        Me.txtClientRef.Top = 0.4375!
        Me.txtClientRef.Width = 2.25!
        '
        'txtSalesClass
        '
        Me.txtSalesClass.CanShrink = True
        Me.txtSalesClass.DataField = "SC_DESCRIPTION"
        Me.txtSalesClass.Height = 0.1875!
        Me.txtSalesClass.Left = 5.125!
        Me.txtSalesClass.Name = "txtSalesClass"
        Me.txtSalesClass.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtSalesClass.Text = Nothing
        Me.txtSalesClass.Top = 1.0!
        Me.txtSalesClass.Width = 2.25!
        '
        'txtAccExeLabel
        '
        Me.txtAccExeLabel.CanShrink = True
        Me.txtAccExeLabel.Height = 0.1875!
        Me.txtAccExeLabel.Left = 0.0625!
        Me.txtAccExeLabel.Name = "txtAccExeLabel"
        Me.txtAccExeLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtAccExeLabel.Text = "Account Executive:"
        Me.txtAccExeLabel.Top = 0.8125!
        Me.txtAccExeLabel.Width = 1.375!
        '
        'txtAccountExective
        '
        Me.txtAccountExective.CanShrink = True
        Me.txtAccountExective.DataField = "AE"
        Me.txtAccountExective.Height = 0.1875!
        Me.txtAccountExective.Left = 1.4375!
        Me.txtAccountExective.Name = "txtAccountExective"
        Me.txtAccountExective.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAccountExective.Text = Nothing
        Me.txtAccountExective.Top = 0.8125!
        Me.txtAccountExective.Width = 2.25!
        '
        'Line8
        '
        Me.Line8.Height = 0.0!
        Me.Line8.Left = -0.00000003352761!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 1.812!
        Me.Line8.Width = 7.375!
        Me.Line8.X1 = -0.00000003352761!
        Me.Line8.X2 = 7.375!
        Me.Line8.Y1 = 1.812!
        Me.Line8.Y2 = 1.812!
        '
        'txtEstQuantityLabel
        '
        Me.txtEstQuantityLabel.CanShrink = True
        Me.txtEstQuantityLabel.Height = 0.1875!
        Me.txtEstQuantityLabel.Left = 3.75!
        Me.txtEstQuantityLabel.Name = "txtEstQuantityLabel"
        Me.txtEstQuantityLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtEstQuantityLabel.Text = "Estimate Quantity:"
        Me.txtEstQuantityLabel.Top = 1.1875!
        Me.txtEstQuantityLabel.Width = 1.375!
        '
        'txtEstQuantity
        '
        Me.txtEstQuantity.CanShrink = True
        Me.txtEstQuantity.DataField = "JOB_QTY"
        Me.txtEstQuantity.Height = 0.1875!
        Me.txtEstQuantity.Left = 5.125!
        Me.txtEstQuantity.Name = "txtEstQuantity"
        Me.txtEstQuantity.OutputFormat = resources.GetString("txtEstQuantity.OutputFormat")
        Me.txtEstQuantity.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtEstQuantity.Text = Nothing
        Me.txtEstQuantity.Top = 1.1875!
        Me.txtEstQuantity.Width = 2.25!
        '
        'txtCPULabel
        '
        Me.txtCPULabel.CanShrink = True
        Me.txtCPULabel.Height = 0.1875!
        Me.txtCPULabel.Left = 3.75!
        Me.txtCPULabel.Name = "txtCPULabel"
        Me.txtCPULabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtCPULabel.Text = "Cost Per Unit:"
        Me.txtCPULabel.Top = 1.3745!
        Me.txtCPULabel.Width = 1.375!
        '
        'txtCPU
        '
        Me.txtCPU.CanShrink = True
        Me.txtCPU.DataField = "CPU"
        Me.txtCPU.Height = 0.1875!
        Me.txtCPU.Left = 5.125!
        Me.txtCPU.Name = "txtCPU"
        Me.txtCPU.OutputFormat = resources.GetString("txtCPU.OutputFormat")
        Me.txtCPU.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCPU.Text = Nothing
        Me.txtCPU.Top = 1.375!
        Me.txtCPU.Width = 2.25!
        '
        'TxtCPMLabel
        '
        Me.TxtCPMLabel.CanShrink = True
        Me.TxtCPMLabel.Height = 0.1875!
        Me.TxtCPMLabel.Left = 3.75!
        Me.TxtCPMLabel.Name = "TxtCPMLabel"
        Me.TxtCPMLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TxtCPMLabel.Text = "Cost Per Thousand:"
        Me.TxtCPMLabel.Top = 1.562!
        Me.TxtCPMLabel.Width = 1.375!
        '
        'txtCPM
        '
        Me.txtCPM.CanShrink = True
        Me.txtCPM.DataField = "CPM"
        Me.txtCPM.Height = 0.1875!
        Me.txtCPM.Left = 5.125!
        Me.txtCPM.Name = "txtCPM"
        Me.txtCPM.OutputFormat = resources.GetString("txtCPM.OutputFormat")
        Me.txtCPM.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCPM.Text = Nothing
        Me.txtCPM.Top = 1.562!
        Me.txtCPM.Width = 2.25!
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
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDescriptionText, Me.txtQty, Me.txtAmount, Me.txtFunctionComments, Me.txtTaxable, Me.txtCommissionable, Me.txtRate, Me.txtContingency, Me.txtMarkupAmt, Me.txtTaxAmount, Me.txtTaxCode, Me.txtLineTotal, Me.txtSuppliedByNotes, Me.txtIO, Me.txtMUCont, Me.TextBoxFunctionDescription})
        Me.Detail1.Height = 0.3125!
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
        Me.txtQty.Width = 0.8125!
        '
        'txtAmount
        '
        Me.txtAmount.CanShrink = True
        Me.txtAmount.DataField = "EST_REV_EXT_AMT"
        Me.txtAmount.Height = 0.1875!
        Me.txtAmount.Left = 6.375!
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OutputFormat = resources.GetString("txtAmount.OutputFormat")
        Me.txtAmount.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtAmount.Text = Nothing
        Me.txtAmount.Top = 0.0!
        Me.txtAmount.Width = 1.0!
        '
        'txtFunctionComments
        '
        Me.txtFunctionComments.CanShrink = True
        Me.txtFunctionComments.DataField = "EST_FNC_COMMENT"
        Me.txtFunctionComments.Height = 0.0625!
        Me.txtFunctionComments.Left = 0.375!
        Me.txtFunctionComments.Name = "txtFunctionComments"
        Me.txtFunctionComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtFunctionComments.Text = Nothing
        Me.txtFunctionComments.Top = 0.1875!
        Me.txtFunctionComments.Width = 6.25!
        '
        'txtTaxable
        '
        Me.txtTaxable.CanShrink = True
        Me.txtTaxable.Height = 0.1875!
        Me.txtTaxable.Left = 7.375!
        Me.txtTaxable.Name = "txtTaxable"
        Me.txtTaxable.Text = "*"
        Me.txtTaxable.Top = 0.0!
        Me.txtTaxable.Visible = False
        Me.txtTaxable.Width = 0.0625!
        '
        'txtCommissionable
        '
        Me.txtCommissionable.CanShrink = True
        Me.txtCommissionable.Height = 0.1875!
        Me.txtCommissionable.Left = 7.4375!
        Me.txtCommissionable.Name = "txtCommissionable"
        Me.txtCommissionable.Text = "^"
        Me.txtCommissionable.Top = 0.0!
        Me.txtCommissionable.Width = 0.0625!
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
        'txtSuppliedByNotes
        '
        Me.txtSuppliedByNotes.CanShrink = True
        Me.txtSuppliedByNotes.DataField = "EST_REV_SUP_BY_NTE"
        Me.txtSuppliedByNotes.Height = 0.0625!
        Me.txtSuppliedByNotes.Left = 0.375!
        Me.txtSuppliedByNotes.Name = "txtSuppliedByNotes"
        Me.txtSuppliedByNotes.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtSuppliedByNotes.Text = Nothing
        Me.txtSuppliedByNotes.Top = 0.25!
        Me.txtSuppliedByNotes.Width = 6.25!
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
        'TextBoxFunctionDescription
        '
        Me.TextBoxFunctionDescription.CanShrink = True
        Me.TextBoxFunctionDescription.DataField = "FNC_DESCRIPTION"
        Me.TextBoxFunctionDescription.Height = 0.1875!
        Me.TextBoxFunctionDescription.Left = 0.187!
        Me.TextBoxFunctionDescription.Name = "TextBoxFunctionDescription"
        Me.TextBoxFunctionDescription.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBoxFunctionDescription.Text = Nothing
        Me.TextBoxFunctionDescription.Top = 0.0!
        Me.TextBoxFunctionDescription.Width = 4.5!
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
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line8, Me.txtQuoteDesc, Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.txtClientRefLabel, Me.TextBox5, Me.TextBox6, Me.txtSalesClassLabel, Me.txtEstNumber, Me.txtJobNumber, Me.txtEstCompNumber, Me.txtJobCompNumber, Me.txtQuoteNumber, Me.txtRevisionNumber, Me.txtEstDescription, Me.txtEstCompDesc, Me.txtEstLabel, Me.txtJobDesc, Me.txtJobCompDesc, Me.txtClientRef, Me.txtSalesClass, Me.txtAccExeLabel, Me.txtAccountExective, Me.txtEstQuantityLabel, Me.txtEstQuantity, Me.txtCPULabel, Me.txtCPU, Me.TxtCPMLabel, Me.txtCPM, Me.TextBox10, Me.txtJobDueDate, Me.txtCompanyLabel, Me.txtCompany, Me.txtBusinessLabel, Me.txtBusiness})
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader1.Height = 1.84375!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'TextBox10
        '
        Me.TextBox10.CanShrink = True
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 0.0625!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox10.Text = "Job Due Date:"
        Me.TextBox10.Top = 1.0!
        Me.TextBox10.Width = 1.375!
        '
        'txtJobDueDate
        '
        Me.txtJobDueDate.CanShrink = True
        Me.txtJobDueDate.DataField = "JOB_DUE_DATE"
        Me.txtJobDueDate.Height = 0.1875!
        Me.txtJobDueDate.Left = 1.4375!
        Me.txtJobDueDate.Name = "txtJobDueDate"
        Me.txtJobDueDate.OutputFormat = resources.GetString("txtJobDueDate.OutputFormat")
        Me.txtJobDueDate.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtJobDueDate.Text = Nothing
        Me.txtJobDueDate.Top = 1.0!
        Me.txtJobDueDate.Width = 2.25!
        '
        'txtCompanyLabel
        '
        Me.txtCompanyLabel.CanShrink = True
        Me.txtCompanyLabel.Height = 0.1875!
        Me.txtCompanyLabel.Left = 3.75!
        Me.txtCompanyLabel.Name = "txtCompanyLabel"
        Me.txtCompanyLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtCompanyLabel.Top = 0.625!
        Me.txtCompanyLabel.Width = 1.375!
        '
        'txtCompany
        '
        Me.txtCompany.CanShrink = True
        Me.txtCompany.Height = 0.1875!
        Me.txtCompany.Left = 5.125!
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.OutputFormat = resources.GetString("txtCompany.OutputFormat")
        Me.txtCompany.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtCompany.Text = Nothing
        Me.txtCompany.Top = 0.625!
        Me.txtCompany.Width = 2.25!
        '
        'txtBusinessLabel
        '
        Me.txtBusinessLabel.CanShrink = True
        Me.txtBusinessLabel.Height = 0.1875!
        Me.txtBusinessLabel.Left = 3.75!
        Me.txtBusinessLabel.Name = "txtBusinessLabel"
        Me.txtBusinessLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtBusinessLabel.Top = 0.812!
        Me.txtBusinessLabel.Width = 1.375!
        '
        'txtBusiness
        '
        Me.txtBusiness.CanShrink = True
        Me.txtBusiness.Height = 0.1875!
        Me.txtBusiness.Left = 5.125!
        Me.txtBusiness.Name = "txtBusiness"
        Me.txtBusiness.OutputFormat = resources.GetString("txtBusiness.OutputFormat")
        Me.txtBusiness.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtBusiness.Text = Nothing
        Me.txtBusiness.Top = 0.8119999!
        Me.txtBusiness.Width = 2.25!
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
        'txtQtyHrs
        '
        Me.txtQtyHrs.CanShrink = True
        Me.txtQtyHrs.Height = 0.1875!
        Me.txtQtyHrs.Left = 4.75!
        Me.txtQtyHrs.Name = "txtQtyHrs"
        Me.txtQtyHrs.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" & _
    " ddo-char-set: 0"
        Me.txtQtyHrs.Text = "Qty/Hrs"
        Me.txtQtyHrs.Top = 0.0!
        Me.txtQtyHrs.Width = 0.8125!
        '
        'txtAmountText
        '
        Me.txtAmountText.CanShrink = True
        Me.txtAmountText.Height = 0.1875!
        Me.txtAmountText.Left = 6.4375!
        Me.txtAmountText.Name = "txtAmountText"
        Me.txtAmountText.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" & _
    " ddo-char-set: 0"
        Me.txtAmountText.Text = "Amount"
        Me.txtAmountText.Top = 0.0!
        Me.txtAmountText.Width = 0.9375!
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
        'txtDescription
        '
        Me.txtDescription.CanShrink = True
        Me.txtDescription.Height = 0.1875!
        Me.txtDescription.Left = 0.0625!
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Style = "font-size: 9pt; font-weight: bold; text-align: left; text-decoration: underline; " & _
    "ddo-char-set: 0"
        Me.txtDescription.Text = "Description"
        Me.txtDescription.Top = 0.0!
        Me.txtDescription.Width = 0.8125!
        '
        'txtRateLabel
        '
        Me.txtRateLabel.CanShrink = True
        Me.txtRateLabel.Height = 0.1875!
        Me.txtRateLabel.Left = 5.8125!
        Me.txtRateLabel.Name = "txtRateLabel"
        Me.txtRateLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" & _
    " ddo-char-set: 0"
        Me.txtRateLabel.Text = "Rate"
        Me.txtRateLabel.Top = 0.0!
        Me.txtRateLabel.Width = 0.4375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox8, Me.txtTotalForEst, Me.txtCommissionLabel, Me.txtTax, Me.txtTaxLabel, Me.txtCommission, Me.txtSubTotalLabel, Me.txtSubTotal, Me.txtContTotal2, Me.txtContLabel, Me.txtContTotal, Me.txtMUContTotal, Me.Line11})
        Me.GroupFooter1.Height = 1.072917!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 5.125!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox8.Text = "Total For Estimate:"
        Me.TextBox8.Top = 0.875!
        Me.TextBox8.Width = 1.1875!
        '
        'txtTotalForEst
        '
        Me.txtTotalForEst.Height = 0.1875!
        Me.txtTotalForEst.Left = 6.375!
        Me.txtTotalForEst.Name = "txtTotalForEst"
        Me.txtTotalForEst.OutputFormat = resources.GetString("txtTotalForEst.OutputFormat")
        Me.txtTotalForEst.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalForEst.Text = Nothing
        Me.txtTotalForEst.Top = 0.875!
        Me.txtTotalForEst.Width = 1.0!
        '
        'txtCommissionLabel
        '
        Me.txtCommissionLabel.CanShrink = True
        Me.txtCommissionLabel.Height = 0.1875!
        Me.txtCommissionLabel.Left = 5.125!
        Me.txtCommissionLabel.Name = "txtCommissionLabel"
        Me.txtCommissionLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtCommissionLabel.Text = "Commission:"
        Me.txtCommissionLabel.Top = 0.4375!
        Me.txtCommissionLabel.Width = 1.1875!
        '
        'txtTax
        '
        Me.txtTax.CanShrink = True
        Me.txtTax.DataField = "TAX"
        Me.txtTax.Height = 0.1875!
        Me.txtTax.Left = 6.375!
        Me.txtTax.Name = "txtTax"
        Me.txtTax.OutputFormat = resources.GetString("txtTax.OutputFormat")
        Me.txtTax.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtTax.SummaryGroup = "GroupHeader1"
        Me.txtTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTax.Text = Nothing
        Me.txtTax.Top = 0.625!
        Me.txtTax.Width = 1.0!
        '
        'txtTaxLabel
        '
        Me.txtTaxLabel.CanShrink = True
        Me.txtTaxLabel.Height = 0.1875!
        Me.txtTaxLabel.Left = 5.125!
        Me.txtTaxLabel.Name = "txtTaxLabel"
        Me.txtTaxLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTaxLabel.Text = "Tax:"
        Me.txtTaxLabel.Top = 0.625!
        Me.txtTaxLabel.Width = 1.1875!
        '
        'txtCommission
        '
        Me.txtCommission.CanShrink = True
        Me.txtCommission.DataField = "EXT_MARKUP_AMT"
        Me.txtCommission.Height = 0.1875!
        Me.txtCommission.Left = 6.375!
        Me.txtCommission.Name = "txtCommission"
        Me.txtCommission.OutputFormat = resources.GetString("txtCommission.OutputFormat")
        Me.txtCommission.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtCommission.SummaryGroup = "GroupHeader1"
        Me.txtCommission.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtCommission.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtCommission.Text = Nothing
        Me.txtCommission.Top = 0.4375!
        Me.txtCommission.Width = 1.0!
        '
        'txtSubTotalLabel
        '
        Me.txtSubTotalLabel.CanShrink = True
        Me.txtSubTotalLabel.Height = 0.1875!
        Me.txtSubTotalLabel.Left = 5.125!
        Me.txtSubTotalLabel.Name = "txtSubTotalLabel"
        Me.txtSubTotalLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtSubTotalLabel.Text = "Subtotal:"
        Me.txtSubTotalLabel.Top = 0.0!
        Me.txtSubTotalLabel.Width = 1.1875!
        '
        'txtSubTotal
        '
        Me.txtSubTotal.CanShrink = True
        Me.txtSubTotal.DataField = "EST_REV_EXT_AMT"
        Me.txtSubTotal.Height = 0.1875!
        Me.txtSubTotal.Left = 6.375!
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.OutputFormat = resources.GetString("txtSubTotal.OutputFormat")
        Me.txtSubTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtSubTotal.SummaryGroup = "GroupHeader1"
        Me.txtSubTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtSubTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtSubTotal.Text = Nothing
        Me.txtSubTotal.Top = 0.0!
        Me.txtSubTotal.Width = 1.0!
        '
        'txtContTotal2
        '
        Me.txtContTotal2.CanShrink = True
        Me.txtContTotal2.DataField = "EXT_CONTINGENCY"
        Me.txtContTotal2.Height = 0.1875!
        Me.txtContTotal2.Left = 6.375!
        Me.txtContTotal2.Name = "txtContTotal2"
        Me.txtContTotal2.OutputFormat = resources.GetString("txtContTotal2.OutputFormat")
        Me.txtContTotal2.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContTotal2.SummaryGroup = "GroupHeader1"
        Me.txtContTotal2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtContTotal2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtContTotal2.Text = Nothing
        Me.txtContTotal2.Top = 0.25!
        Me.txtContTotal2.Visible = False
        Me.txtContTotal2.Width = 1.0!
        '
        'txtContLabel
        '
        Me.txtContLabel.CanShrink = True
        Me.txtContLabel.Height = 0.1875!
        Me.txtContLabel.Left = 5.125!
        Me.txtContLabel.Name = "txtContLabel"
        Me.txtContLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtContLabel.Text = "Contingency:"
        Me.txtContLabel.Top = 0.25!
        Me.txtContLabel.Width = 1.1875!
        '
        'txtContTotal
        '
        Me.txtContTotal.CanShrink = True
        Me.txtContTotal.DataField = "EXT_CONTINGENCY"
        Me.txtContTotal.Height = 0.1875!
        Me.txtContTotal.Left = 5.125!
        Me.txtContTotal.Name = "txtContTotal"
        Me.txtContTotal.OutputFormat = resources.GetString("txtContTotal.OutputFormat")
        Me.txtContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContTotal.SummaryGroup = "GroupHeader1"
        Me.txtContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtContTotal.Text = Nothing
        Me.txtContTotal.Top = 0.0!
        Me.txtContTotal.Visible = False
        Me.txtContTotal.Width = 0.125!
        '
        'txtMUContTotal
        '
        Me.txtMUContTotal.CanShrink = True
        Me.txtMUContTotal.DataField = "EXT_MU_CONT"
        Me.txtMUContTotal.Height = 0.1875!
        Me.txtMUContTotal.Left = 5.0!
        Me.txtMUContTotal.Name = "txtMUContTotal"
        Me.txtMUContTotal.OutputFormat = resources.GetString("txtMUContTotal.OutputFormat")
        Me.txtMUContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUContTotal.SummaryGroup = "GroupHeader1"
        Me.txtMUContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMUContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMUContTotal.Text = Nothing
        Me.txtMUContTotal.Top = 0.0!
        Me.txtMUContTotal.Visible = False
        Me.txtMUContTotal.Width = 0.125!
        '
        'Line11
        '
        Me.Line11.Height = 0.0!
        Me.Line11.Left = 6.375!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.0!
        Me.Line11.Visible = False
        Me.Line11.Width = 1.0!
        Me.Line11.X1 = 6.375!
        Me.Line11.X2 = 7.375!
        Me.Line11.Y1 = 0.0!
        Me.Line11.Y2 = 0.0!
        '
        'AuthDate
        '
        Me.AuthDate.Height = 0.1875!
        Me.AuthDate.Left = 1.125!
        Me.AuthDate.Name = "AuthDate"
        Me.AuthDate.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.AuthDate.Text = Nothing
        Me.AuthDate.Top = 0.9375!
        Me.AuthDate.Width = 1.1875!
        '
        'txtClientApprovalText
        '
        Me.txtClientApprovalText.Height = 0.1875!
        Me.txtClientApprovalText.Left = 3.8125!
        Me.txtClientApprovalText.Name = "txtClientApprovalText"
        Me.txtClientApprovalText.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtClientApprovalText.Text = "Client Approval"
        Me.txtClientApprovalText.Top = 0.4375!
        Me.txtClientApprovalText.Width = 1.0!
        '
        'txtPreparedBy
        '
        Me.txtPreparedBy.Height = 0.1875!
        Me.txtPreparedBy.Left = 0.5625!
        Me.txtPreparedBy.Name = "txtPreparedBy"
        Me.txtPreparedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtPreparedBy.Text = "Date:"
        Me.txtPreparedBy.Top = 1.0!
        Me.txtPreparedBy.Width = 0.4375!
        '
        'txtAuthorizedBy
        '
        Me.txtAuthorizedBy.Height = 0.6875!
        Me.txtAuthorizedBy.Left = 0.0625!
        Me.txtAuthorizedBy.Name = "txtAuthorizedBy"
        Me.txtAuthorizedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; vertical-align: bottom; ddo" & _
    "-char-set: 0"
        Me.txtAuthorizedBy.Text = "Agency Authorization:"
        Me.txtAuthorizedBy.Top = 0.125!
        Me.txtAuthorizedBy.Width = 0.9375!
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.Height = 0.1875!
        Me.txtApprovedBy.Left = 3.9375!
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtApprovedBy.Text = "Approved By:"
        Me.txtApprovedBy.Top = 0.625!
        Me.txtApprovedBy.Width = 0.875!
        '
        'txtDate
        '
        Me.txtDate.Height = 0.1875!
        Me.txtDate.Left = 4.3125!
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtDate.Text = "Date:"
        Me.txtDate.Top = 1.0!
        Me.txtDate.Width = 0.5!
        '
        'Line4
        '
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 1.0625!
        Me.Line4.LineWeight = 2.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 1.1875!
        Me.Line4.Width = 2.75!
        Me.Line4.X1 = 1.0625!
        Me.Line4.X2 = 3.8125!
        Me.Line4.Y1 = 1.1875!
        Me.Line4.Y2 = 1.1875!
        '
        'Line5
        '
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 1.0625!
        Me.Line5.LineWeight = 2.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.8125!
        Me.Line5.Width = 2.75!
        Me.Line5.X1 = 1.0625!
        Me.Line5.X2 = 3.8125!
        Me.Line5.Y1 = 0.8125!
        Me.Line5.Y2 = 0.8125!
        '
        'Line6
        '
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 4.875!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.8125!
        Me.Line6.Width = 2.5625!
        Me.Line6.X1 = 4.875!
        Me.Line6.X2 = 7.4375!
        Me.Line6.Y1 = 0.8125!
        Me.Line6.Y2 = 0.8125!
        '
        'Line7
        '
        Me.Line7.Height = 0.0!
        Me.Line7.Left = 4.875!
        Me.Line7.LineWeight = 2.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 1.1875!
        Me.Line7.Width = 2.5625!
        Me.Line7.X1 = 4.875!
        Me.Line7.X2 = 7.4375!
        Me.Line7.Y1 = 1.1875!
        Me.Line7.Y2 = 1.1875!
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
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFunctionType, Me.txtFunctionHeading, Me.txtInsideDesc, Me.txtPhaseDesc, Me.txtGroupTotal, Me.txtMUGrouping, Me.txtGroupingTax, Me.txtCGrouping, Me.txtMUCGrouping})
        Me.GroupHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader2.Height = 0.2395833!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'txtFunctionType
        '
        Me.txtFunctionType.CanShrink = True
        Me.txtFunctionType.DataField = "EST_FNC_TYPE"
        Me.txtFunctionType.Height = 0.0625!
        Me.txtFunctionType.Left = 0.06200001!
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
        Me.txtFunctionHeading.Left = 0.06200001!
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
        Me.txtInsideDesc.Left = 0.06200001!
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
        Me.txtPhaseDesc.Left = 0.06200001!
        Me.txtPhaseDesc.Name = "txtPhaseDesc"
        Me.txtPhaseDesc.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtPhaseDesc.Text = Nothing
        Me.txtPhaseDesc.Top = 0.1875!
        Me.txtPhaseDesc.Width = 4.4375!
        '
        'txtGroupTotal
        '
        Me.txtGroupTotal.CanShrink = True
        Me.txtGroupTotal.DataField = "EST_REV_EXT_AMT"
        Me.txtGroupTotal.Height = 0.1875!
        Me.txtGroupTotal.Left = 6.375!
        Me.txtGroupTotal.Name = "txtGroupTotal"
        Me.txtGroupTotal.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtGroupTotal.Text = Nothing
        Me.txtGroupTotal.Top = 0.0!
        Me.txtGroupTotal.Width = 1.0!
        '
        'txtMUGrouping
        '
        Me.txtMUGrouping.DataField = "EXT_MARKUP_AMT"
        Me.txtMUGrouping.Height = 0.1875!
        Me.txtMUGrouping.Left = 6.5!
        Me.txtMUGrouping.Name = "txtMUGrouping"
        Me.txtMUGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUGrouping.Text = Nothing
        Me.txtMUGrouping.Top = 0.375!
        Me.txtMUGrouping.Visible = False
        Me.txtMUGrouping.Width = 0.125!
        '
        'txtGroupingTax
        '
        Me.txtGroupingTax.DataField = "TAX"
        Me.txtGroupingTax.Height = 0.1875!
        Me.txtGroupingTax.Left = 6.75!
        Me.txtGroupingTax.Name = "txtGroupingTax"
        Me.txtGroupingTax.OutputFormat = resources.GetString("txtGroupingTax.OutputFormat")
        Me.txtGroupingTax.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtGroupingTax.Text = Nothing
        Me.txtGroupingTax.Top = 0.375!
        Me.txtGroupingTax.Visible = False
        Me.txtGroupingTax.Width = 0.125!
        '
        'txtCGrouping
        '
        Me.txtCGrouping.CanShrink = True
        Me.txtCGrouping.DataField = "EXT_CONTINGENCY"
        Me.txtCGrouping.Height = 0.1875!
        Me.txtCGrouping.Left = 7.0!
        Me.txtCGrouping.Name = "txtCGrouping"
        Me.txtCGrouping.OutputFormat = resources.GetString("txtCGrouping.OutputFormat")
        Me.txtCGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtCGrouping.Text = Nothing
        Me.txtCGrouping.Top = 0.375!
        Me.txtCGrouping.Visible = False
        Me.txtCGrouping.Width = 0.125!
        '
        'txtMUCGrouping
        '
        Me.txtMUCGrouping.CanShrink = True
        Me.txtMUCGrouping.DataField = "EXT_MU_CONT"
        Me.txtMUCGrouping.Height = 0.1875!
        Me.txtMUCGrouping.Left = 7.1875!
        Me.txtMUCGrouping.Name = "txtMUCGrouping"
        Me.txtMUCGrouping.OutputFormat = resources.GetString("txtMUCGrouping.OutputFormat")
        Me.txtMUCGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUCGrouping.Text = Nothing
        Me.txtMUCGrouping.Top = 0.375!
        Me.txtMUCGrouping.Visible = False
        Me.txtMUCGrouping.Width = 0.125!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.CanShrink = True
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalGrouping, Me.txtTotalLabel, Me.txtContGrouping, Me.txtTaxGrouping, Me.txtMarkupAmtGrouping, Me.Line9, Me.TextBox4, Me.TextBox7, Me.txtMUContGrouping})
        Me.GroupFooter2.Height = 0.21875!
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
        'Line9
        '
        Me.Line9.Height = 0.0!
        Me.Line9.Left = 6.375!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.0!
        Me.Line9.Width = 1.0!
        Me.Line9.X1 = 6.375!
        Me.Line9.X2 = 7.375!
        Me.Line9.Y1 = 0.0!
        Me.Line9.Y2 = 0.0!
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
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReport1, Me.txtEst, Me.TextBox9, Me.txtEstimateHdr, Me.txtDates, Me.Line2, Me.txtPhone, Me.txtCityStateZip, Me.txtFedID, Me.txtAddress2, Me.txtFax, Me.txtEmail, Me.txtCDPContact, Me.txtCCAddress, Me.txtCCState, Me.txtCCZip, Me.txtCCAddress2, Me.txtCCCity, Me.estcomp, Me.est, Me.ReportInfo1, Me.TextBox11, Me.rev, Me.quote})
        Me.GroupHeader3.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader3.Height = 0.7395833!
        Me.GroupHeader3.Name = "GroupHeader3"
        Me.GroupHeader3.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.5625!
        Me.SubReport1.Left = 0.0625!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = "SubReport1"
        Me.SubReport1.Top = 0.0625!
        Me.SubReport1.Width = 3.4375!
        '
        'txtEst
        '
        Me.txtEst.CanShrink = True
        Me.txtEst.Height = 0.1875!
        Me.txtEst.Left = 4.0!
        Me.txtEst.Name = "txtEst"
        Me.txtEst.Style = "font-family: Arial; font-size: 9pt; font-weight: normal; text-align: right; ddo-c" & _
    "har-set: 0"
        Me.txtEst.Text = "Estimate:"
        Me.txtEst.Top = 0.0625!
        Me.txtEst.Width = 2.1875!
        '
        'TextBox9
        '
        Me.TextBox9.CanShrink = True
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 5.8125!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "font-family: Arial; font-size: 9pt; font-weight: normal; text-align: right; ddo-c" & _
    "har-set: 0"
        Me.TextBox9.Text = "Date:"
        Me.TextBox9.Top = 0.25!
        Me.TextBox9.Width = 0.375!
        '
        'txtEstimateHdr
        '
        Me.txtEstimateHdr.CanShrink = True
        Me.txtEstimateHdr.Height = 0.1875!
        Me.txtEstimateHdr.Left = 6.25!
        Me.txtEstimateHdr.Name = "txtEstimateHdr"
        Me.txtEstimateHdr.Style = "font-family: Arial; font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtEstimateHdr.Text = Nothing
        Me.txtEstimateHdr.Top = 0.0625!
        Me.txtEstimateHdr.Width = 1.1875!
        '
        'txtDates
        '
        Me.txtDates.CanShrink = True
        Me.txtDates.Height = 0.1875!
        Me.txtDates.Left = 6.25!
        Me.txtDates.Name = "txtDates"
        Me.txtDates.Style = "font-family: Arial; font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtDates.Text = Nothing
        Me.txtDates.Top = 0.25!
        Me.txtDates.Width = 1.1875!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.6875!
        Me.Line2.Width = 7.375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.4375!
        Me.Line2.Y1 = 0.6875!
        Me.Line2.Y2 = 0.6875!
        '
        'txtPhone
        '
        Me.txtPhone.CanShrink = True
        Me.txtPhone.Height = 0.0625!
        Me.txtPhone.Left = 5.75!
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtPhone.Text = Nothing
        Me.txtPhone.Top = 0.75!
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
        Me.txtCityStateZip.Top = 0.75!
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
        Me.txtFedID.Top = 0.75!
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
        Me.txtAddress2.Top = 0.875!
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
        Me.txtFax.Top = 0.75!
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
        Me.txtEmail.Top = 0.75!
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
        Me.txtCDPContact.Top = 0.75!
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
        Me.txtCCAddress.Top = 0.75!
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
        Me.txtCCState.Top = 0.875!
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
        Me.txtCCZip.Top = 0.875!
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
        Me.txtCCAddress2.Top = 0.875!
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
        Me.txtCCCity.Top = 0.875!
        Me.txtCCCity.Visible = False
        Me.txtCCCity.Width = 0.1875!
        '
        'estcomp
        '
        Me.estcomp.CanShrink = True
        Me.estcomp.DataField = "EST_COMPONENT_NBR"
        Me.estcomp.Height = 0.1875!
        Me.estcomp.Left = 0.25!
        Me.estcomp.Name = "estcomp"
        Me.estcomp.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.estcomp.Text = Nothing
        Me.estcomp.Top = 0.75!
        Me.estcomp.Visible = False
        Me.estcomp.Width = 0.125!
        '
        'est
        '
        Me.est.CanShrink = True
        Me.est.DataField = "ESTIMATE_NUMBER"
        Me.est.Height = 0.1875!
        Me.est.Left = 0.0625!
        Me.est.Name = "est"
        Me.est.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.est.Text = Nothing
        Me.est.Top = 0.75!
        Me.est.Visible = False
        Me.est.Width = 0.125!
        '
        'ReportInfo1
        '
        Me.ReportInfo1.CanShrink = True
        Me.ReportInfo1.FormatString = "Page {PageNumber} of {PageCount}"
        Me.ReportInfo1.Height = 0.1875!
        Me.ReportInfo1.Left = 6.25!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "font-family: Arial; font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.ReportInfo1.SummaryGroup = "GroupHeader3"
        Me.ReportInfo1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.ReportInfo1.Top = 0.4375!
        Me.ReportInfo1.Width = 1.1875!
        '
        'TextBox11
        '
        Me.TextBox11.CanShrink = True
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 5.8125!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "font-family: Arial; font-size: 9pt; font-weight: normal; text-align: right; ddo-c" & _
    "har-set: 0"
        Me.TextBox11.Text = "Page:"
        Me.TextBox11.Top = 0.4375!
        Me.TextBox11.Width = 0.375!
        '
        'rev
        '
        Me.rev.CanShrink = True
        Me.rev.DataField = "EST_REV_NBR"
        Me.rev.Height = 0.1875!
        Me.rev.Left = 0.625!
        Me.rev.Name = "rev"
        Me.rev.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.rev.Text = Nothing
        Me.rev.Top = 0.75!
        Me.rev.Visible = False
        Me.rev.Width = 0.125!
        '
        'quote
        '
        Me.quote.CanShrink = True
        Me.quote.DataField = "EST_QUOTE_NBR"
        Me.quote.Height = 0.1875!
        Me.quote.Left = 0.4375!
        Me.quote.Name = "quote"
        Me.quote.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.quote.Text = Nothing
        Me.quote.Top = 0.75!
        Me.quote.Visible = False
        Me.quote.Width = 0.125!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.CanShrink = True
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.EmpSigPic, Me.txtClientApprovalText, Me.txtPreparedBy, Me.txtAuthorizedBy, Me.txtApprovedBy, Me.txtDate, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.AuthDate})
        Me.GroupFooter3.Height = 1.26875!
        Me.GroupFooter3.KeepTogether = True
        Me.GroupFooter3.Name = "GroupFooter3"
        Me.GroupFooter3.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'EmpSigPic
        '
        Me.EmpSigPic.Height = 0.75!
        Me.EmpSigPic.ImageData = Nothing
        Me.EmpSigPic.Left = 1.0625!
        Me.EmpSigPic.Name = "EmpSigPic"
        Me.EmpSigPic.Top = 0.0!
        Me.EmpSigPic.Width = 2.75!
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
        Me.GroupFooter4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtClientApproval2, Me.txtApprovedBy2, Me.txtDate2, Me.lineCA2, Me.lineDate2, Me.TextBox12, Me.TextBox13, Me.TextBox14, Me.Line10, Me.Line12, Me.TextBox15, Me.TextBox16, Me.TextBox17, Me.Line13, Me.Line14, Me.TextBox18, Me.TextBox19, Me.TextBox20, Me.Line15, Me.Line16})
        Me.GroupFooter4.Height = 1.479167!
        Me.GroupFooter4.KeepTogether = True
        Me.GroupFooter4.Name = "GroupFooter4"
        Me.GroupFooter4.Visible = False
        '
        'TextBox12
        '
        Me.TextBox12.Height = 0.1875!
        Me.TextBox12.Left = 3.75!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox12.Text = "Client Approval"
        Me.TextBox12.Top = 0.8125!
        Me.TextBox12.Width = 1.0625!
        '
        'TextBox13
        '
        Me.TextBox13.Height = 0.1875!
        Me.TextBox13.Left = 3.9375!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox13.Text = "Approved By:"
        Me.TextBox13.Top = 1.0!
        Me.TextBox13.Width = 0.875!
        '
        'TextBox14
        '
        Me.TextBox14.Height = 0.1875!
        Me.TextBox14.Left = 4.0!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox14.Text = "Date:"
        Me.TextBox14.Top = 1.25!
        Me.TextBox14.Width = 0.8125!
        '
        'Line10
        '
        Me.Line10.Height = 0.0!
        Me.Line10.Left = 4.875!
        Me.Line10.LineWeight = 2.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 1.1875!
        Me.Line10.Width = 2.5625!
        Me.Line10.X1 = 4.875!
        Me.Line10.X2 = 7.4375!
        Me.Line10.Y1 = 1.1875!
        Me.Line10.Y2 = 1.1875!
        '
        'Line12
        '
        Me.Line12.Height = 0.0!
        Me.Line12.Left = 4.875!
        Me.Line12.LineWeight = 2.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 1.4375!
        Me.Line12.Width = 2.5625!
        Me.Line12.X1 = 4.875!
        Me.Line12.X2 = 7.4375!
        Me.Line12.Y1 = 1.4375!
        Me.Line12.Y2 = 1.4375!
        '
        'TextBox15
        '
        Me.TextBox15.Height = 0.1875!
        Me.TextBox15.Left = 0.0!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox15.Text = "Client Approval"
        Me.TextBox15.Top = 0.0625!
        Me.TextBox15.Width = 1.0625!
        '
        'TextBox16
        '
        Me.TextBox16.Height = 0.1875!
        Me.TextBox16.Left = 0.1875!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox16.Text = "Approved By:"
        Me.TextBox16.Top = 0.25!
        Me.TextBox16.Width = 0.875!
        '
        'TextBox17
        '
        Me.TextBox17.Height = 0.1875!
        Me.TextBox17.Left = 0.25!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox17.Text = "Date:"
        Me.TextBox17.Top = 0.5!
        Me.TextBox17.Width = 0.8125!
        '
        'Line13
        '
        Me.Line13.Height = 0.0!
        Me.Line13.Left = 1.125!
        Me.Line13.LineWeight = 2.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 0.4375!
        Me.Line13.Width = 2.5625!
        Me.Line13.X1 = 1.125!
        Me.Line13.X2 = 3.6875!
        Me.Line13.Y1 = 0.4375!
        Me.Line13.Y2 = 0.4375!
        '
        'Line14
        '
        Me.Line14.Height = 0.0!
        Me.Line14.Left = 1.125!
        Me.Line14.LineWeight = 2.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 0.6875!
        Me.Line14.Width = 2.5625!
        Me.Line14.X1 = 1.125!
        Me.Line14.X2 = 3.6875!
        Me.Line14.Y1 = 0.6875!
        Me.Line14.Y2 = 0.6875!
        '
        'TextBox18
        '
        Me.TextBox18.Height = 0.1875!
        Me.TextBox18.Left = 0.0!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox18.Text = "Client Approval"
        Me.TextBox18.Top = 0.8125!
        Me.TextBox18.Width = 1.0625!
        '
        'TextBox19
        '
        Me.TextBox19.Height = 0.1875!
        Me.TextBox19.Left = 0.1875!
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox19.Text = "Approved By:"
        Me.TextBox19.Top = 1.0!
        Me.TextBox19.Width = 0.875!
        '
        'TextBox20
        '
        Me.TextBox20.Height = 0.1875!
        Me.TextBox20.Left = 0.25!
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox20.Text = "Date:"
        Me.TextBox20.Top = 1.25!
        Me.TextBox20.Width = 0.8125!
        '
        'Line15
        '
        Me.Line15.Height = 0.0!
        Me.Line15.Left = 1.125!
        Me.Line15.LineWeight = 2.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 1.1875!
        Me.Line15.Width = 2.5625!
        Me.Line15.X1 = 1.125!
        Me.Line15.X2 = 3.6875!
        Me.Line15.Y1 = 1.1875!
        Me.Line15.Y2 = 1.1875!
        '
        'Line16
        '
        Me.Line16.Height = 0.0!
        Me.Line16.Left = 1.125!
        Me.Line16.LineWeight = 2.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 1.4375!
        Me.Line16.Width = 2.5625!
        Me.Line16.X1 = 1.125!
        Me.Line16.X2 = 3.6875!
        Me.Line16.Y1 = 1.4375!
        Me.Line16.Y2 = 1.4375!
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
        Me.GroupHeader6.Height = 0.2916667!
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
        Me.GroupHeader7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtQtyHrs, Me.txtDescription, Me.txtRateLabel, Me.txtAmountText})
        Me.GroupHeader7.Height = 0.2083333!
        Me.GroupHeader7.Name = "GroupHeader7"
        Me.GroupHeader7.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter7
        '
        Me.GroupFooter7.CanShrink = True
        Me.GroupFooter7.Height = 0.0!
        Me.GroupFooter7.Name = "GroupFooter7"
        '
        'TextBox21
        '
        Me.TextBox21.Height = 0.1875!
        Me.TextBox21.Left = 3.75!
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox21.Text = "Purchase Order:"
        Me.TextBox21.Top = 0.062!
        Me.TextBox21.Width = 1.062!
        '
        'Line17
        '
        Me.Line17.Height = 0.0!
        Me.Line17.Left = 4.875!
        Me.Line17.LineWeight = 2.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 0.25!
        Me.Line17.Width = 2.5625!
        Me.Line17.X1 = 4.875!
        Me.Line17.X2 = 7.4375!
        Me.Line17.Y1 = 0.25!
        Me.Line17.Y2 = 0.25!
        '
        'GroupHeader8
        '
        Me.GroupHeader8.Height = 0.0!
        Me.GroupHeader8.Name = "GroupHeader8"
        '
        'GroupFooter8
        '
        Me.GroupFooter8.CanShrink = True
        Me.GroupFooter8.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox21, Me.Line17})
        Me.GroupFooter8.Height = 0.28125!
        Me.GroupFooter8.Name = "GroupFooter8"
        Me.GroupFooter8.Visible = False
        '
        'GroupHeader9
        '
        Me.GroupHeader9.Height = 0.0!
        Me.GroupHeader9.Name = "GroupHeader9"
        '
        'GroupFooter9
        '
        Me.GroupFooter9.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox46, Me.Line28, Me.Picture2, Me.TextBox47, Me.Line29, Me.TextBox24, Me.TextBox25, Me.Line32, Me.Line33, Me.TextBoxAuthDate})
        Me.GroupFooter9.Height = 1.208334!
        Me.GroupFooter9.KeepTogether = True
        Me.GroupFooter9.Name = "GroupFooter9"
        Me.GroupFooter9.Visible = False
        '
        'TextBox46
        '
        Me.TextBox46.Height = 0.6875!
        Me.TextBox46.Left = 0.062!
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.Style = "font-size: 9pt; font-weight: bold; text-align: right; vertical-align: bottom; ddo" & _
    "-char-set: 0"
        Me.TextBox46.Text = "Agency Authorization Signature"
        Me.TextBox46.Top = 0.125!
        Me.TextBox46.Width = 0.9375!
        '
        'Line28
        '
        Me.Line28.Height = 0.0!
        Me.Line28.Left = 1.062!
        Me.Line28.LineWeight = 2.0!
        Me.Line28.Name = "Line28"
        Me.Line28.Top = 0.812!
        Me.Line28.Width = 2.75!
        Me.Line28.X1 = 1.062!
        Me.Line28.X2 = 3.812!
        Me.Line28.Y1 = 0.812!
        Me.Line28.Y2 = 0.812!
        '
        'Picture2
        '
        Me.Picture2.Height = 0.75!
        Me.Picture2.HyperLink = Nothing
        Me.Picture2.ImageData = Nothing
        Me.Picture2.Left = 1.062!
        Me.Picture2.Name = "Picture2"
        Me.Picture2.Top = 0.0!
        Me.Picture2.Width = 2.75!
        '
        'TextBox47
        '
        Me.TextBox47.Height = 0.4380001!
        Me.TextBox47.Left = 3.875!
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox47.Text = "Client Approval Signature"
        Me.TextBox47.Top = 0.375!
        Me.TextBox47.Width = 0.937!
        '
        'Line29
        '
        Me.Line29.Height = 0.0!
        Me.Line29.Left = 4.875!
        Me.Line29.LineWeight = 2.0!
        Me.Line29.Name = "Line29"
        Me.Line29.Top = 0.812!
        Me.Line29.Width = 2.562!
        Me.Line29.X1 = 4.875!
        Me.Line29.X2 = 7.437!
        Me.Line29.Y1 = 0.812!
        Me.Line29.Y2 = 0.812!
        '
        'TextBox24
        '
        Me.TextBox24.Height = 0.1875!
        Me.TextBox24.Left = 0.562!
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox24.Text = "Date:"
        Me.TextBox24.Top = 1.0!
        Me.TextBox24.Width = 0.4375!
        '
        'TextBox25
        '
        Me.TextBox25.Height = 0.1875!
        Me.TextBox25.Left = 4.375!
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox25.Text = "Date:"
        Me.TextBox25.Top = 1.0!
        Me.TextBox25.Width = 0.4375!
        '
        'Line32
        '
        Me.Line32.Height = 0.0!
        Me.Line32.Left = 1.062!
        Me.Line32.LineWeight = 2.0!
        Me.Line32.Name = "Line32"
        Me.Line32.Top = 1.187!
        Me.Line32.Width = 2.75!
        Me.Line32.X1 = 1.062!
        Me.Line32.X2 = 3.812!
        Me.Line32.Y1 = 1.187!
        Me.Line32.Y2 = 1.187!
        '
        'Line33
        '
        Me.Line33.Height = 0.0!
        Me.Line33.Left = 4.875!
        Me.Line33.LineWeight = 2.0!
        Me.Line33.Name = "Line33"
        Me.Line33.Top = 1.187!
        Me.Line33.Width = 2.5625!
        Me.Line33.X1 = 4.875!
        Me.Line33.X2 = 7.4375!
        Me.Line33.Y1 = 1.187!
        Me.Line33.Y2 = 1.187!
        '
        'TextBoxAuthDate
        '
        Me.TextBoxAuthDate.Height = 0.1875!
        Me.TextBoxAuthDate.Left = 1.125!
        Me.TextBoxAuthDate.Name = "TextBoxAuthDate"
        Me.TextBoxAuthDate.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.TextBoxAuthDate.Text = Nothing
        Me.TextBoxAuthDate.Top = 0.937!
        Me.TextBoxAuthDate.Width = 1.187!
        '
        'arptEstimatingTPN
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader4)
        Me.Sections.Add(Me.GroupHeader8)
        Me.Sections.Add(Me.GroupHeader9)
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
        Me.Sections.Add(Me.GroupFooter9)
        Me.Sections.Add(Me.GroupFooter8)
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
        CType(Me.txtEstLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientRefLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalesClassLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisionNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalesClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccExeLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountExective, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstQuantityLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCPULabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCPU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCPMLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLineTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescriptionText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFunctionComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommissionable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContingency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarkupAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSuppliedByNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxFunctionDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTerms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxableText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBusinessLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBusiness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponentComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQtyHrs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmountText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisionComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstimateComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalForEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommissionLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContTotal2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AuthDate, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.txtGroupTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroupingTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUCGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUContGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstimateHdr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDates, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.estcomp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.est, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.quote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApprovedBy2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientApproval2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxAuthDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents txtName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddress1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtEstLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClientRefLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSalesClassLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuoteNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisionNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstDescription As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstCompDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuoteDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClientRef As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSalesClass As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtDescription As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQtyHrs As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtDescriptionText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQty As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAmountText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents AuthDate As DataDynamics.ActiveReports.TextBox
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
    Friend WithEvents txtAccExeLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAccountExective As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtFunctionType As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtFunctionHeading As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtInsideDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstDefaultComment As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFunctionComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuoteComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisionComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTerms As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSubTotalLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSubTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxable As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstQuantityLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstQuantity As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCommissionable As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCommissionLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCommission As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtComponentComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstimateComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContingency As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRateLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMarkupAmt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContTotal2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMarkupAmtGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCPULabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCPU As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtLineTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxableText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCPMLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCPM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSuppliedByNotes As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPhaseDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtIO As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtContLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMUCont As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMUContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtMUContGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtClientApproval2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtApprovedBy2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDate2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lineCA2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lineDate2 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader5 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter5 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents EmpSigPic As DataDynamics.ActiveReports.Picture
    Friend WithEvents GroupHeader6 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter6 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents GroupHeader7 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter7 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDueDate As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents txtEst As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstimateHdr As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDates As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
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
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents rev As DataDynamics.ActiveReports.TextBox
    Friend WithEvents quote As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line12 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox16 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line13 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line14 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox18 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox19 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox20 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line15 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line16 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBox21 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line17 As DataDynamics.ActiveReports.Line
    Private WithEvents GroupHeader8 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter8 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents txtGroupTotal As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtMUGrouping As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtGroupingTax As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtCGrouping As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtMUCGrouping As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtCompanyLabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtCompany As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtBusinessLabel As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtBusiness As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader9 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter9 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents TextBox46 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line28 As DataDynamics.ActiveReports.Line
    Private WithEvents Picture2 As DataDynamics.ActiveReports.Picture
    Private WithEvents TextBox47 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line29 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBoxFunctionDescription As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox24 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox25 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line32 As DataDynamics.ActiveReports.Line
    Private WithEvents Line33 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBoxAuthDate As DataDynamics.ActiveReports.TextBox
End Class
