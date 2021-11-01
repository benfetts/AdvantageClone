<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class arptEstimating005
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arptEstimating005))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Picture1 = New DataDynamics.ActiveReports.Picture()
        Me.txtName = New DataDynamics.ActiveReports.TextBox()
        Me.txtAddress1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtTitle = New DataDynamics.ActiveReports.TextBox()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtDescriptionText = New DataDynamics.ActiveReports.TextBox()
        Me.txtOriginalAmt = New DataDynamics.ActiveReports.TextBox()
        Me.txtFunctionComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedAmt = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigContingency = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigMarkupAmt = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigTaxAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxCode = New DataDynamics.ActiveReports.TextBox()
        Me.txtActualHours = New DataDynamics.ActiveReports.TextBox()
        Me.txtSuppliedByNotes = New DataDynamics.ActiveReports.TextBox()
        Me.txtIO = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigMUCont = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedCont = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedMarkupAmt = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedTax = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedMUCont = New DataDynamics.ActiveReports.TextBox()
        Me.txtActualAmount = New DataDynamics.ActiveReports.TextBox()
        Me.txtActualMarkup = New DataDynamics.ActiveReports.TextBox()
        Me.txtActualTax = New DataDynamics.ActiveReports.TextBox()
        Me.txtActualTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtVariance = New DataDynamics.ActiveReports.TextBox()
        Me.txtOneRev = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxFunctionDescription = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.txtTerms = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxableText = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.txtQuoteDesc = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientRefLabel = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.txtSalesClassLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobCompNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuoteNumber = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstDescription = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstCompDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobCompDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtClientRef = New DataDynamics.ActiveReports.TextBox()
        Me.txtSalesClass = New DataDynamics.ActiveReports.TextBox()
        Me.txtAccExeLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtAccountExective = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstQuantityLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstQuantity = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.txtJobDueDate = New DataDynamics.ActiveReports.TextBox()
        Me.txtComponentComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtOriginalLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtQuoteComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisionComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtEstimateComments = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescription = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtVarianceText = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.txtCommissionLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtTaxLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtSubTotalLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtContLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtMUContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtOriginalTax = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigCommission = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigCont2Total = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedTaxAmt = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedCommission = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedCont2Total = New DataDynamics.ActiveReports.TextBox()
        Me.txtOriginalSubtotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedMUContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigMUContTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedTotalForEst = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigTotalForEst = New DataDynamics.ActiveReports.TextBox()
        Me.txtVarianceTotalEst = New DataDynamics.ActiveReports.TextBox()
        Me.txtVarianceTax = New DataDynamics.ActiveReports.TextBox()
        Me.txtVarianceCommission = New DataDynamics.ActiveReports.TextBox()
        Me.txtVarianceSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtVarianceCont2Total = New DataDynamics.ActiveReports.TextBox()
        Me.txtOneRevTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Line15 = New DataDynamics.ActiveReports.Line()
        Me.Line16 = New DataDynamics.ActiveReports.Line()
        Me.Line17 = New DataDynamics.ActiveReports.Line()
        Me.txtOriginalCPU = New DataDynamics.ActiveReports.TextBox()
        Me.txtOriginalCPM = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedCPU = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedCPM = New DataDynamics.ActiveReports.TextBox()
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
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.txtTotalLabel = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigContGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigTaxGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigMarkupAmtGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.txtRevisedMarkupAmtGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedTaxGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedContGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigTotalGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtRevisedTotalGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtActualMarkupGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtActualTaxGrouping = New DataDynamics.ActiveReports.TextBox()
        Me.txtVarianceGroupingTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
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
        Me.quote = New DataDynamics.ActiveReports.TextBox()
        Me.rev = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        Me.EmpSigPic = New DataDynamics.ActiveReports.Picture()
        Me.GroupHeader4 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter4 = New DataDynamics.ActiveReports.GroupFooter()
        Me.txtClientApproval2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtApprovedBy2 = New DataDynamics.ActiveReports.TextBox()
        Me.txtDate2 = New DataDynamics.ActiveReports.TextBox()
        Me.lineCA2 = New DataDynamics.ActiveReports.Line()
        Me.lineDate2 = New DataDynamics.ActiveReports.Line()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.Line12 = New DataDynamics.ActiveReports.Line()
        Me.Line13 = New DataDynamics.ActiveReports.Line()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.Line14 = New DataDynamics.ActiveReports.Line()
        Me.Line18 = New DataDynamics.ActiveReports.Line()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
        Me.Line19 = New DataDynamics.ActiveReports.Line()
        Me.Line20 = New DataDynamics.ActiveReports.Line()
        Me.GroupHeader5 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter5 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader6 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter6 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader7 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter7 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader8 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter8 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox21 = New DataDynamics.ActiveReports.TextBox()
        Me.Line23 = New DataDynamics.ActiveReports.Line()
        Me.GroupHeader9 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter9 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox22 = New DataDynamics.ActiveReports.TextBox()
        Me.Line21 = New DataDynamics.ActiveReports.Line()
        Me.Picture2 = New DataDynamics.ActiveReports.Picture()
        Me.TextBox23 = New DataDynamics.ActiveReports.TextBox()
        Me.Line22 = New DataDynamics.ActiveReports.Line()
        Me.TextBox24 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox25 = New DataDynamics.ActiveReports.TextBox()
        Me.Line32 = New DataDynamics.ActiveReports.Line()
        Me.Line33 = New DataDynamics.ActiveReports.Line()
        Me.TextBoxAuthDate = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxCampaign = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxCampaignName = New DataDynamics.ActiveReports.TextBox()
        Me.TextBoxCampaignId = New DataDynamics.ActiveReports.TextBox()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescriptionText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOriginalAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFunctionComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigContingency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigMarkupAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigTaxAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSuppliedByNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigMUCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedMarkupAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedMUCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualMarkup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVariance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOneRev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxFunctionDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxableText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientRefLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalesClassLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalesClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccExeLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountExective, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstQuantityLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJobDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComponentComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOriginalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuoteComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisionComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstimateComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVarianceText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommissionLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTaxLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMUContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOriginalTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigCont2Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedTaxAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedCont2Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOriginalSubtotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedMUContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigMUContTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedTotalForEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigTotalForEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVarianceTotalEst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVarianceTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVarianceCommission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVarianceSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVarianceCont2Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOneRevTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOriginalCPU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOriginalCPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedCPU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedCPM, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.txtTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigContGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigTaxGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedTaxGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedContGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigTotalGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRevisedTotalGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualMarkupGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualTaxGrouping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVarianceGroupingTotal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.quote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientApproval2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApprovedBy2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxAuthDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCampaign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCampaignName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCampaignId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Picture1, Me.txtName, Me.txtAddress1, Me.txtTitle, Me.Line3, Me.Line1})
        Me.PageHeader1.Height = 2.041667!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Picture1
        '
        Me.Picture1.Height = 1.5!
        Me.Picture1.ImageData = Nothing
        Me.Picture1.Left = 0.062!
        Me.Picture1.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.txtTitle.Left = 0.062!
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
        Me.Line3.Left = 0.062!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.75!
        Me.Line3.Width = 7.375001!
        Me.Line3.X1 = 0.062!
        Me.Line3.X2 = 7.437001!
        Me.Line3.Y1 = 1.75!
        Me.Line3.Y2 = 1.75!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.062!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 2.0!
        Me.Line1.Width = 7.375001!
        Me.Line1.X1 = 0.062!
        Me.Line1.X2 = 7.437001!
        Me.Line1.Y1 = 2.0!
        Me.Line1.Y2 = 2.0!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDescriptionText, Me.txtOriginalAmt, Me.txtFunctionComments, Me.txtRevisedAmt, Me.txtOrigContingency, Me.txtOrigMarkupAmt, Me.txtOrigTaxAmount, Me.txtTaxCode, Me.txtActualHours, Me.txtSuppliedByNotes, Me.txtIO, Me.txtOrigMUCont, Me.txtRevisedCont, Me.txtRevisedMarkupAmt, Me.txtRevisedTax, Me.txtRevisedMUCont, Me.txtActualAmount, Me.txtActualMarkup, Me.txtActualTax, Me.txtActualTotal, Me.txtVariance, Me.txtOneRev, Me.TextBoxFunctionDescription})
        Me.Detail1.Height = 0.3229167!
        Me.Detail1.Name = "Detail1"
        '
        'txtDescriptionText
        '
        Me.txtDescriptionText.CanShrink = True
        Me.txtDescriptionText.DataField = "FNC_DESCRIPTION"
        Me.txtDescriptionText.Height = 0.1875!
        Me.txtDescriptionText.Left = 0.06200001!
        Me.txtDescriptionText.Name = "txtDescriptionText"
        Me.txtDescriptionText.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtDescriptionText.Text = Nothing
        Me.txtDescriptionText.Top = 0.0!
        Me.txtDescriptionText.Width = 3.875!
        '
        'txtOriginalAmt
        '
        Me.txtOriginalAmt.CanShrink = True
        Me.txtOriginalAmt.DataField = "ORIGINAL_AMT"
        Me.txtOriginalAmt.Height = 0.1875!
        Me.txtOriginalAmt.Left = 4.062!
        Me.txtOriginalAmt.Name = "txtOriginalAmt"
        Me.txtOriginalAmt.OutputFormat = resources.GetString("txtOriginalAmt.OutputFormat")
        Me.txtOriginalAmt.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOriginalAmt.Text = Nothing
        Me.txtOriginalAmt.Top = 0.0!
        Me.txtOriginalAmt.Width = 1.0625!
        '
        'txtFunctionComments
        '
        Me.txtFunctionComments.CanShrink = True
        Me.txtFunctionComments.DataField = "EST_FNC_COMMENT"
        Me.txtFunctionComments.Height = 0.0625!
        Me.txtFunctionComments.Left = 0.3125!
        Me.txtFunctionComments.Name = "txtFunctionComments"
        Me.txtFunctionComments.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtFunctionComments.Text = Nothing
        Me.txtFunctionComments.Top = 0.1875!
        Me.txtFunctionComments.Width = 3.75!
        '
        'txtRevisedAmt
        '
        Me.txtRevisedAmt.CanShrink = True
        Me.txtRevisedAmt.DataField = "REVISED_AMT"
        Me.txtRevisedAmt.Height = 0.1875!
        Me.txtRevisedAmt.Left = 5.25!
        Me.txtRevisedAmt.Name = "txtRevisedAmt"
        Me.txtRevisedAmt.OutputFormat = resources.GetString("txtRevisedAmt.OutputFormat")
        Me.txtRevisedAmt.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedAmt.Text = Nothing
        Me.txtRevisedAmt.Top = 0.0!
        Me.txtRevisedAmt.Width = 1.062!
        '
        'txtOrigContingency
        '
        Me.txtOrigContingency.CanShrink = True
        Me.txtOrigContingency.DataField = "ORIGINAL_CONT"
        Me.txtOrigContingency.Height = 0.06200001!
        Me.txtOrigContingency.Left = 4.0!
        Me.txtOrigContingency.Name = "txtOrigContingency"
        Me.txtOrigContingency.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigContingency.Text = Nothing
        Me.txtOrigContingency.Top = 0.25!
        Me.txtOrigContingency.Visible = False
        Me.txtOrigContingency.Width = 0.187!
        '
        'txtOrigMarkupAmt
        '
        Me.txtOrigMarkupAmt.CanShrink = True
        Me.txtOrigMarkupAmt.DataField = "ORIGINAL_MARKUP_AMT"
        Me.txtOrigMarkupAmt.Height = 0.06200001!
        Me.txtOrigMarkupAmt.Left = 3.813!
        Me.txtOrigMarkupAmt.Name = "txtOrigMarkupAmt"
        Me.txtOrigMarkupAmt.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigMarkupAmt.Text = Nothing
        Me.txtOrigMarkupAmt.Top = 0.25!
        Me.txtOrigMarkupAmt.Visible = False
        Me.txtOrigMarkupAmt.Width = 0.187!
        '
        'txtOrigTaxAmount
        '
        Me.txtOrigTaxAmount.CanShrink = True
        Me.txtOrigTaxAmount.DataField = "ORIGINAL_TAX"
        Me.txtOrigTaxAmount.Height = 0.06200001!
        Me.txtOrigTaxAmount.Left = 4.375!
        Me.txtOrigTaxAmount.Name = "txtOrigTaxAmount"
        Me.txtOrigTaxAmount.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigTaxAmount.Text = Nothing
        Me.txtOrigTaxAmount.Top = 0.25!
        Me.txtOrigTaxAmount.Visible = False
        Me.txtOrigTaxAmount.Width = 0.1869998!
        '
        'txtTaxCode
        '
        Me.txtTaxCode.CanShrink = True
        Me.txtTaxCode.DataField = "TAX_CODE"
        Me.txtTaxCode.Height = 0.0625!
        Me.txtTaxCode.Left = 4.813!
        Me.txtTaxCode.Name = "txtTaxCode"
        Me.txtTaxCode.Text = Nothing
        Me.txtTaxCode.Top = 0.25!
        Me.txtTaxCode.Visible = False
        Me.txtTaxCode.Width = 0.1869998!
        '
        'txtActualHours
        '
        Me.txtActualHours.CanShrink = True
        Me.txtActualHours.DataField = "Actual_Hours"
        Me.txtActualHours.Height = 0.06200001!
        Me.txtActualHours.Left = 6.313!
        Me.txtActualHours.Name = "txtActualHours"
        Me.txtActualHours.Text = Nothing
        Me.txtActualHours.Top = 0.25!
        Me.txtActualHours.Visible = False
        Me.txtActualHours.Width = 0.1869998!
        '
        'txtSuppliedByNotes
        '
        Me.txtSuppliedByNotes.CanShrink = True
        Me.txtSuppliedByNotes.DataField = "EST_REV_SUP_BY_NTE"
        Me.txtSuppliedByNotes.Height = 0.0625!
        Me.txtSuppliedByNotes.Left = 0.3125!
        Me.txtSuppliedByNotes.Name = "txtSuppliedByNotes"
        Me.txtSuppliedByNotes.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtSuppliedByNotes.Text = Nothing
        Me.txtSuppliedByNotes.Top = 0.25!
        Me.txtSuppliedByNotes.Width = 3.75!
        '
        'txtIO
        '
        Me.txtIO.CanShrink = True
        Me.txtIO.DataField = "INOUT"
        Me.txtIO.Height = 0.0625!
        Me.txtIO.Left = 6.125!
        Me.txtIO.Name = "txtIO"
        Me.txtIO.Text = Nothing
        Me.txtIO.Top = 0.25!
        Me.txtIO.Visible = False
        Me.txtIO.Width = 0.1869998!
        '
        'txtOrigMUCont
        '
        Me.txtOrigMUCont.CanShrink = True
        Me.txtOrigMUCont.DataField = "ORIGINAL_MU_CONT"
        Me.txtOrigMUCont.Height = 0.06200001!
        Me.txtOrigMUCont.Left = 4.188!
        Me.txtOrigMUCont.Name = "txtOrigMUCont"
        Me.txtOrigMUCont.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigMUCont.Text = Nothing
        Me.txtOrigMUCont.Top = 0.25!
        Me.txtOrigMUCont.Visible = False
        Me.txtOrigMUCont.Width = 0.1869998!
        '
        'txtRevisedCont
        '
        Me.txtRevisedCont.CanShrink = True
        Me.txtRevisedCont.DataField = "REVISED_CONT"
        Me.txtRevisedCont.Height = 0.06200001!
        Me.txtRevisedCont.Left = 5.438001!
        Me.txtRevisedCont.Name = "txtRevisedCont"
        Me.txtRevisedCont.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedCont.Text = Nothing
        Me.txtRevisedCont.Top = 0.25!
        Me.txtRevisedCont.Visible = False
        Me.txtRevisedCont.Width = 0.1869998!
        '
        'txtRevisedMarkupAmt
        '
        Me.txtRevisedMarkupAmt.CanShrink = True
        Me.txtRevisedMarkupAmt.DataField = "REVISED_MARKUP_AMT"
        Me.txtRevisedMarkupAmt.Height = 0.06200001!
        Me.txtRevisedMarkupAmt.Left = 5.25!
        Me.txtRevisedMarkupAmt.Name = "txtRevisedMarkupAmt"
        Me.txtRevisedMarkupAmt.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedMarkupAmt.Text = Nothing
        Me.txtRevisedMarkupAmt.Top = 0.25!
        Me.txtRevisedMarkupAmt.Visible = False
        Me.txtRevisedMarkupAmt.Width = 0.1869998!
        '
        'txtRevisedTax
        '
        Me.txtRevisedTax.CanShrink = True
        Me.txtRevisedTax.DataField = "REVISED_TAX"
        Me.txtRevisedTax.Height = 0.06200001!
        Me.txtRevisedTax.Left = 5.813!
        Me.txtRevisedTax.Name = "txtRevisedTax"
        Me.txtRevisedTax.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedTax.Text = Nothing
        Me.txtRevisedTax.Top = 0.25!
        Me.txtRevisedTax.Visible = False
        Me.txtRevisedTax.Width = 0.1869998!
        '
        'txtRevisedMUCont
        '
        Me.txtRevisedMUCont.CanShrink = True
        Me.txtRevisedMUCont.DataField = "REVISED_MU_CONT"
        Me.txtRevisedMUCont.Height = 0.06200001!
        Me.txtRevisedMUCont.Left = 5.625!
        Me.txtRevisedMUCont.Name = "txtRevisedMUCont"
        Me.txtRevisedMUCont.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedMUCont.Text = Nothing
        Me.txtRevisedMUCont.Top = 0.25!
        Me.txtRevisedMUCont.Visible = False
        Me.txtRevisedMUCont.Width = 0.1869998!
        '
        'txtActualAmount
        '
        Me.txtActualAmount.CanShrink = True
        Me.txtActualAmount.DataField = "Actual_Amount"
        Me.txtActualAmount.Height = 0.06200001!
        Me.txtActualAmount.Left = 6.5!
        Me.txtActualAmount.Name = "txtActualAmount"
        Me.txtActualAmount.Text = Nothing
        Me.txtActualAmount.Top = 0.25!
        Me.txtActualAmount.Visible = False
        Me.txtActualAmount.Width = 0.1869998!
        '
        'txtActualMarkup
        '
        Me.txtActualMarkup.CanShrink = True
        Me.txtActualMarkup.DataField = "Actual_Markup"
        Me.txtActualMarkup.Height = 0.06200001!
        Me.txtActualMarkup.Left = 6.688!
        Me.txtActualMarkup.Name = "txtActualMarkup"
        Me.txtActualMarkup.Text = Nothing
        Me.txtActualMarkup.Top = 0.25!
        Me.txtActualMarkup.Visible = False
        Me.txtActualMarkup.Width = 0.1869998!
        '
        'txtActualTax
        '
        Me.txtActualTax.CanShrink = True
        Me.txtActualTax.DataField = "Actual_Tax"
        Me.txtActualTax.Height = 0.06200001!
        Me.txtActualTax.Left = 6.875!
        Me.txtActualTax.Name = "txtActualTax"
        Me.txtActualTax.Text = Nothing
        Me.txtActualTax.Top = 0.25!
        Me.txtActualTax.Visible = False
        Me.txtActualTax.Width = 0.1869998!
        '
        'txtActualTotal
        '
        Me.txtActualTotal.CanShrink = True
        Me.txtActualTotal.DataField = "Actual_Total"
        Me.txtActualTotal.Height = 0.06200001!
        Me.txtActualTotal.Left = 7.063!
        Me.txtActualTotal.Name = "txtActualTotal"
        Me.txtActualTotal.Text = Nothing
        Me.txtActualTotal.Top = 0.25!
        Me.txtActualTotal.Visible = False
        Me.txtActualTotal.Width = 0.1869998!
        '
        'txtVariance
        '
        Me.txtVariance.CanShrink = True
        Me.txtVariance.Height = 0.1875!
        Me.txtVariance.Left = 6.375!
        Me.txtVariance.Name = "txtVariance"
        Me.txtVariance.OutputFormat = resources.GetString("txtVariance.OutputFormat")
        Me.txtVariance.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtVariance.Text = Nothing
        Me.txtVariance.Top = 0.0!
        Me.txtVariance.Width = 0.9990001!
        '
        'txtOneRev
        '
        Me.txtOneRev.CanShrink = True
        Me.txtOneRev.DataField = "ONE_REVISION"
        Me.txtOneRev.Height = 0.062!
        Me.txtOneRev.Left = 7.25!
        Me.txtOneRev.Name = "txtOneRev"
        Me.txtOneRev.Text = Nothing
        Me.txtOneRev.Top = 0.25!
        Me.txtOneRev.Visible = False
        Me.txtOneRev.Width = 0.1869998!
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
        Me.TextBoxFunctionDescription.Width = 3.75!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTerms, Me.txtTaxableText})
        Me.PageFooter1.Height = 0.5416666!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtTerms
        '
        Me.txtTerms.CanShrink = True
        Me.txtTerms.Height = 0.3125!
        Me.txtTerms.Left = 0.062!
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
        Me.txtTaxableText.Left = 0.062!
        Me.txtTaxableText.Name = "txtTaxableText"
        Me.txtTaxableText.Style = "font-size: 9pt"
        Me.txtTaxableText.Text = Nothing
        Me.txtTaxableText.Top = 0.0!
        Me.txtTaxableText.Width = 4.0625!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanShrink = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line8, Me.txtQuoteDesc, Me.TextBox1, Me.TextBox2, Me.txtClientRefLabel, Me.TextBox5, Me.TextBox6, Me.txtSalesClassLabel, Me.txtEstNumber, Me.txtJobNumber, Me.txtEstCompNumber, Me.txtJobCompNumber, Me.txtQuoteNumber, Me.txtEstDescription, Me.txtEstCompDesc, Me.txtEstLabel, Me.txtJobDesc, Me.txtJobCompDesc, Me.txtClientRef, Me.txtSalesClass, Me.txtAccExeLabel, Me.txtAccountExective, Me.txtEstQuantityLabel, Me.txtEstQuantity, Me.TextBox10, Me.txtJobDueDate, Me.TextBoxCampaign, Me.TextBoxCampaignName, Me.TextBoxCampaignId})
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader1.Height = 1.072916!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Line8
        '
        Me.Line8.Height = 0.0!
        Me.Line8.Left = 0.062!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 1.062!
        Me.Line8.Width = 7.375!
        Me.Line8.X1 = 0.062!
        Me.Line8.X2 = 7.437!
        Me.Line8.Y1 = 1.062!
        Me.Line8.Y2 = 1.062!
        '
        'txtQuoteDesc
        '
        Me.txtQuoteDesc.CanShrink = True
        Me.txtQuoteDesc.DataField = "EST_QUOTE_DESC"
        Me.txtQuoteDesc.Height = 0.1875!
        Me.txtQuoteDesc.Left = 1.437!
        Me.txtQuoteDesc.Name = "txtQuoteDesc"
        Me.txtQuoteDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtQuoteDesc.Text = Nothing
        Me.txtQuoteDesc.Top = 0.437!
        Me.txtQuoteDesc.Width = 2.25!
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.062!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox1.Text = "Component:"
        Me.TextBox1.Top = 0.2495!
        Me.TextBox1.Width = 0.8125!
        '
        'TextBox2
        '
        Me.TextBox2.CanShrink = True
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 0.062!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox2.Text = "Quote:"
        Me.TextBox2.Top = 0.437!
        Me.TextBox2.Width = 0.8125!
        '
        'txtClientRefLabel
        '
        Me.txtClientRefLabel.CanShrink = True
        Me.txtClientRefLabel.Height = 0.1875!
        Me.txtClientRefLabel.Left = 3.7495!
        Me.txtClientRefLabel.Name = "txtClientRefLabel"
        Me.txtClientRefLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtClientRefLabel.Text = "Client Reference:"
        Me.txtClientRefLabel.Top = 0.437!
        Me.txtClientRefLabel.Width = 1.375!
        '
        'TextBox5
        '
        Me.TextBox5.CanShrink = True
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 3.7495!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox5.Text = "Component:"
        Me.TextBox5.Top = 0.2495!
        Me.TextBox5.Width = 0.8125!
        '
        'TextBox6
        '
        Me.TextBox6.CanShrink = True
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 3.7495!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox6.Text = "Job:"
        Me.TextBox6.Top = 0.06200004!
        Me.TextBox6.Width = 0.8125!
        '
        'txtSalesClassLabel
        '
        Me.txtSalesClassLabel.CanShrink = True
        Me.txtSalesClassLabel.Height = 0.1875!
        Me.txtSalesClassLabel.Left = 3.7495!
        Me.txtSalesClassLabel.Name = "txtSalesClassLabel"
        Me.txtSalesClassLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtSalesClassLabel.Text = "Sales Class:"
        Me.txtSalesClassLabel.Top = 0.6245!
        Me.txtSalesClassLabel.Width = 0.8125!
        '
        'txtEstNumber
        '
        Me.txtEstNumber.CanShrink = True
        Me.txtEstNumber.DataField = "ESTIMATE_NUMBER"
        Me.txtEstNumber.Height = 0.1875!
        Me.txtEstNumber.Left = 0.937!
        Me.txtEstNumber.Name = "txtEstNumber"
        Me.txtEstNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstNumber.Text = Nothing
        Me.txtEstNumber.Top = 0.06200004!
        Me.txtEstNumber.Width = 0.5!
        '
        'txtJobNumber
        '
        Me.txtJobNumber.CanShrink = True
        Me.txtJobNumber.DataField = "JOB_NUMBER"
        Me.txtJobNumber.Height = 0.1875!
        Me.txtJobNumber.Left = 4.6245!
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobNumber.Text = Nothing
        Me.txtJobNumber.Top = 0.06200004!
        Me.txtJobNumber.Width = 0.5!
        '
        'txtEstCompNumber
        '
        Me.txtEstCompNumber.CanShrink = True
        Me.txtEstCompNumber.DataField = "EST_COMPONENT_NBR"
        Me.txtEstCompNumber.Height = 0.1875!
        Me.txtEstCompNumber.Left = 0.937!
        Me.txtEstCompNumber.Name = "txtEstCompNumber"
        Me.txtEstCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtEstCompNumber.Text = Nothing
        Me.txtEstCompNumber.Top = 0.2495!
        Me.txtEstCompNumber.Width = 0.5!
        '
        'txtJobCompNumber
        '
        Me.txtJobCompNumber.CanShrink = True
        Me.txtJobCompNumber.DataField = "JOB_COMPONENT_NBR"
        Me.txtJobCompNumber.Height = 0.1875!
        Me.txtJobCompNumber.Left = 4.6245!
        Me.txtJobCompNumber.Name = "txtJobCompNumber"
        Me.txtJobCompNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtJobCompNumber.Text = Nothing
        Me.txtJobCompNumber.Top = 0.2495!
        Me.txtJobCompNumber.Width = 0.5!
        '
        'txtQuoteNumber
        '
        Me.txtQuoteNumber.CanShrink = True
        Me.txtQuoteNumber.DataField = "EST_QUOTE_NBR"
        Me.txtQuoteNumber.Height = 0.1875!
        Me.txtQuoteNumber.Left = 0.937!
        Me.txtQuoteNumber.Name = "txtQuoteNumber"
        Me.txtQuoteNumber.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.txtQuoteNumber.Text = Nothing
        Me.txtQuoteNumber.Top = 0.437!
        Me.txtQuoteNumber.Width = 0.5!
        '
        'txtEstDescription
        '
        Me.txtEstDescription.CanShrink = True
        Me.txtEstDescription.DataField = "EST_LOG_DESC"
        Me.txtEstDescription.Height = 0.1875!
        Me.txtEstDescription.Left = 1.437!
        Me.txtEstDescription.Name = "txtEstDescription"
        Me.txtEstDescription.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtEstDescription.Text = Nothing
        Me.txtEstDescription.Top = 0.06200004!
        Me.txtEstDescription.Width = 2.25!
        '
        'txtEstCompDesc
        '
        Me.txtEstCompDesc.CanShrink = True
        Me.txtEstCompDesc.DataField = "EST_COMP_DESC"
        Me.txtEstCompDesc.Height = 0.1875!
        Me.txtEstCompDesc.Left = 1.437!
        Me.txtEstCompDesc.Name = "txtEstCompDesc"
        Me.txtEstCompDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtEstCompDesc.Text = Nothing
        Me.txtEstCompDesc.Top = 0.2495!
        Me.txtEstCompDesc.Width = 2.25!
        '
        'txtEstLabel
        '
        Me.txtEstLabel.CanShrink = True
        Me.txtEstLabel.Height = 0.1875!
        Me.txtEstLabel.Left = 0.062!
        Me.txtEstLabel.Name = "txtEstLabel"
        Me.txtEstLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtEstLabel.Text = "Estimate:"
        Me.txtEstLabel.Top = 0.06200004!
        Me.txtEstLabel.Width = 0.8125!
        '
        'txtJobDesc
        '
        Me.txtJobDesc.CanShrink = True
        Me.txtJobDesc.DataField = "JOB_DESC"
        Me.txtJobDesc.Height = 0.1875!
        Me.txtJobDesc.Left = 5.1245!
        Me.txtJobDesc.Name = "txtJobDesc"
        Me.txtJobDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtJobDesc.Text = Nothing
        Me.txtJobDesc.Top = 0.06200004!
        Me.txtJobDesc.Width = 2.25!
        '
        'txtJobCompDesc
        '
        Me.txtJobCompDesc.CanShrink = True
        Me.txtJobCompDesc.DataField = "JOB_COMP_DESC"
        Me.txtJobCompDesc.Height = 0.1875!
        Me.txtJobCompDesc.Left = 5.1245!
        Me.txtJobCompDesc.Name = "txtJobCompDesc"
        Me.txtJobCompDesc.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtJobCompDesc.Text = Nothing
        Me.txtJobCompDesc.Top = 0.2495!
        Me.txtJobCompDesc.Width = 2.25!
        '
        'txtClientRef
        '
        Me.txtClientRef.CanShrink = True
        Me.txtClientRef.DataField = "JOB_CLI_REF"
        Me.txtClientRef.Height = 0.1875!
        Me.txtClientRef.Left = 5.1245!
        Me.txtClientRef.Name = "txtClientRef"
        Me.txtClientRef.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtClientRef.Text = Nothing
        Me.txtClientRef.Top = 0.437!
        Me.txtClientRef.Width = 2.25!
        '
        'txtSalesClass
        '
        Me.txtSalesClass.CanShrink = True
        Me.txtSalesClass.DataField = "SC_DESCRIPTION"
        Me.txtSalesClass.Height = 0.1875!
        Me.txtSalesClass.Left = 5.1245!
        Me.txtSalesClass.Name = "txtSalesClass"
        Me.txtSalesClass.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtSalesClass.Text = Nothing
        Me.txtSalesClass.Top = 0.6245!
        Me.txtSalesClass.Width = 2.25!
        '
        'txtAccExeLabel
        '
        Me.txtAccExeLabel.CanShrink = True
        Me.txtAccExeLabel.Height = 0.1875!
        Me.txtAccExeLabel.Left = 0.062!
        Me.txtAccExeLabel.Name = "txtAccExeLabel"
        Me.txtAccExeLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtAccExeLabel.Text = "Account Executive:"
        Me.txtAccExeLabel.Top = 0.625!
        Me.txtAccExeLabel.Width = 1.375!
        '
        'txtAccountExective
        '
        Me.txtAccountExective.CanShrink = True
        Me.txtAccountExective.DataField = "AE"
        Me.txtAccountExective.Height = 0.1875!
        Me.txtAccountExective.Left = 1.437!
        Me.txtAccountExective.Name = "txtAccountExective"
        Me.txtAccountExective.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtAccountExective.Text = Nothing
        Me.txtAccountExective.Top = 0.625!
        Me.txtAccountExective.Width = 2.25!
        '
        'txtEstQuantityLabel
        '
        Me.txtEstQuantityLabel.CanShrink = True
        Me.txtEstQuantityLabel.Height = 0.1875!
        Me.txtEstQuantityLabel.Left = 3.7495!
        Me.txtEstQuantityLabel.Name = "txtEstQuantityLabel"
        Me.txtEstQuantityLabel.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.txtEstQuantityLabel.Text = "Estimate Quantity:"
        Me.txtEstQuantityLabel.Top = 0.812!
        Me.txtEstQuantityLabel.Width = 1.375!
        '
        'txtEstQuantity
        '
        Me.txtEstQuantity.CanShrink = True
        Me.txtEstQuantity.DataField = "JOB_QTY"
        Me.txtEstQuantity.Height = 0.1875!
        Me.txtEstQuantity.Left = 5.1245!
        Me.txtEstQuantity.Name = "txtEstQuantity"
        Me.txtEstQuantity.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.txtEstQuantity.Text = Nothing
        Me.txtEstQuantity.Top = 0.812!
        Me.txtEstQuantity.Width = 2.25!
        '
        'TextBox10
        '
        Me.TextBox10.CanShrink = True
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 0.0625!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox10.Text = "Job Due Date:"
        Me.TextBox10.Top = 0.8125!
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
        Me.txtJobDueDate.Top = 0.8125!
        Me.txtJobDueDate.Width = 2.25!
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
        'txtOriginalLabel
        '
        Me.txtOriginalLabel.CanShrink = True
        Me.txtOriginalLabel.Height = 0.1875!
        Me.txtOriginalLabel.Left = 4.0625!
        Me.txtOriginalLabel.Name = "txtOriginalLabel"
        Me.txtOriginalLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" & _
    " ddo-char-set: 0"
        Me.txtOriginalLabel.Text = "Original Estimate"
        Me.txtOriginalLabel.Top = 0.0!
        Me.txtOriginalLabel.Width = 1.1245!
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
        'txtRevisedLabel
        '
        Me.txtRevisedLabel.CanShrink = True
        Me.txtRevisedLabel.Height = 0.1875!
        Me.txtRevisedLabel.Left = 5.25!
        Me.txtRevisedLabel.Name = "txtRevisedLabel"
        Me.txtRevisedLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" & _
    " ddo-char-set: 0"
        Me.txtRevisedLabel.Text = "Revised Estimate"
        Me.txtRevisedLabel.Top = 0.0!
        Me.txtRevisedLabel.Width = 1.1245!
        '
        'txtVarianceText
        '
        Me.txtVarianceText.CanShrink = True
        Me.txtVarianceText.Height = 0.1875!
        Me.txtVarianceText.Left = 6.4375!
        Me.txtVarianceText.Name = "txtVarianceText"
        Me.txtVarianceText.Style = "font-size: 9pt; font-weight: bold; text-align: right; text-decoration: underline;" & _
    " ddo-char-set: 0"
        Me.txtVarianceText.Text = "Variance"
        Me.txtVarianceText.Top = 0.0!
        Me.txtVarianceText.Width = 0.9369998!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox8, Me.txtCommissionLabel, Me.txtTaxLabel, Me.txtSubTotalLabel, Me.txtContLabel, Me.txtContTotal, Me.txtMUContTotal, Me.txtOriginalTax, Me.txtOrigCommission, Me.txtOrigCont2Total, Me.txtRevisedTaxAmt, Me.txtRevisedCommission, Me.txtRevisedCont2Total, Me.txtOriginalSubtotal, Me.txtRevisedSubTotal, Me.txtRevisedContTotal, Me.txtRevisedMUContTotal, Me.txtOrigContTotal, Me.txtOrigMUContTotal, Me.txtRevisedTotalForEst, Me.txtOrigTotalForEst, Me.txtVarianceTotalEst, Me.txtVarianceTax, Me.txtVarianceCommission, Me.txtVarianceSubTotal, Me.txtVarianceCont2Total, Me.txtOneRevTotal, Me.Line15, Me.Line16, Me.Line17, Me.txtOriginalCPU, Me.txtOriginalCPM, Me.txtRevisedCPU, Me.txtRevisedCPM})
        Me.GroupFooter1.Height = 1.520833!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 2.75!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBox8.Text = "Total For Estimate:"
        Me.TextBox8.Top = 0.875!
        Me.TextBox8.Width = 1.1875!
        '
        'txtCommissionLabel
        '
        Me.txtCommissionLabel.CanShrink = True
        Me.txtCommissionLabel.Height = 0.1875!
        Me.txtCommissionLabel.Left = 2.75!
        Me.txtCommissionLabel.Name = "txtCommissionLabel"
        Me.txtCommissionLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtCommissionLabel.Text = "Commission:"
        Me.txtCommissionLabel.Top = 0.4375!
        Me.txtCommissionLabel.Width = 1.1875!
        '
        'txtTaxLabel
        '
        Me.txtTaxLabel.CanShrink = True
        Me.txtTaxLabel.Height = 0.1875!
        Me.txtTaxLabel.Left = 2.75!
        Me.txtTaxLabel.Name = "txtTaxLabel"
        Me.txtTaxLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTaxLabel.Text = "Tax:"
        Me.txtTaxLabel.Top = 0.625!
        Me.txtTaxLabel.Width = 1.1875!
        '
        'txtSubTotalLabel
        '
        Me.txtSubTotalLabel.CanShrink = True
        Me.txtSubTotalLabel.Height = 0.1875!
        Me.txtSubTotalLabel.Left = 2.75!
        Me.txtSubTotalLabel.Name = "txtSubTotalLabel"
        Me.txtSubTotalLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtSubTotalLabel.Text = "Subtotal:"
        Me.txtSubTotalLabel.Top = 0.0!
        Me.txtSubTotalLabel.Width = 1.1875!
        '
        'txtContLabel
        '
        Me.txtContLabel.CanShrink = True
        Me.txtContLabel.Height = 0.1875!
        Me.txtContLabel.Left = 2.75!
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
        Me.txtContTotal.Left = 0.312!
        Me.txtContTotal.Name = "txtContTotal"
        Me.txtContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtContTotal.SummaryGroup = "GroupHeader1"
        Me.txtContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtContTotal.Text = Nothing
        Me.txtContTotal.Top = 0.5!
        Me.txtContTotal.Visible = False
        Me.txtContTotal.Width = 0.125!
        '
        'txtMUContTotal
        '
        Me.txtMUContTotal.CanShrink = True
        Me.txtMUContTotal.DataField = "EXT_MU_CONT"
        Me.txtMUContTotal.Height = 0.1875!
        Me.txtMUContTotal.Left = 0.125!
        Me.txtMUContTotal.Name = "txtMUContTotal"
        Me.txtMUContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtMUContTotal.SummaryGroup = "GroupHeader1"
        Me.txtMUContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMUContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMUContTotal.Text = Nothing
        Me.txtMUContTotal.Top = 0.5!
        Me.txtMUContTotal.Visible = False
        Me.txtMUContTotal.Width = 0.125!
        '
        'txtOriginalTax
        '
        Me.txtOriginalTax.CanShrink = True
        Me.txtOriginalTax.DataField = "ORIGINAL_TAX"
        Me.txtOriginalTax.Height = 0.1875!
        Me.txtOriginalTax.Left = 4.0!
        Me.txtOriginalTax.Name = "txtOriginalTax"
        Me.txtOriginalTax.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOriginalTax.SummaryGroup = "GroupHeader1"
        Me.txtOriginalTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOriginalTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOriginalTax.Text = Nothing
        Me.txtOriginalTax.Top = 0.625!
        Me.txtOriginalTax.Width = 1.125!
        '
        'txtOrigCommission
        '
        Me.txtOrigCommission.CanShrink = True
        Me.txtOrigCommission.DataField = "ORIGINAL_MARKUP_AMT"
        Me.txtOrigCommission.Height = 0.1875!
        Me.txtOrigCommission.Left = 4.0!
        Me.txtOrigCommission.Name = "txtOrigCommission"
        Me.txtOrigCommission.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigCommission.SummaryGroup = "GroupHeader1"
        Me.txtOrigCommission.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOrigCommission.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOrigCommission.Text = Nothing
        Me.txtOrigCommission.Top = 0.4375!
        Me.txtOrigCommission.Width = 1.125!
        '
        'txtOrigCont2Total
        '
        Me.txtOrigCont2Total.CanShrink = True
        Me.txtOrigCont2Total.DataField = "ORIGINAL_CONT"
        Me.txtOrigCont2Total.Height = 0.1875!
        Me.txtOrigCont2Total.Left = 4.0!
        Me.txtOrigCont2Total.Name = "txtOrigCont2Total"
        Me.txtOrigCont2Total.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigCont2Total.SummaryGroup = "GroupHeader1"
        Me.txtOrigCont2Total.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOrigCont2Total.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOrigCont2Total.Text = Nothing
        Me.txtOrigCont2Total.Top = 0.25!
        Me.txtOrigCont2Total.Visible = False
        Me.txtOrigCont2Total.Width = 1.125!
        '
        'txtRevisedTaxAmt
        '
        Me.txtRevisedTaxAmt.CanShrink = True
        Me.txtRevisedTaxAmt.DataField = "REVISED_TAX"
        Me.txtRevisedTaxAmt.Height = 0.1875!
        Me.txtRevisedTaxAmt.Left = 5.1875!
        Me.txtRevisedTaxAmt.Name = "txtRevisedTaxAmt"
        Me.txtRevisedTaxAmt.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedTaxAmt.SummaryGroup = "GroupHeader1"
        Me.txtRevisedTaxAmt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedTaxAmt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedTaxAmt.Text = Nothing
        Me.txtRevisedTaxAmt.Top = 0.625!
        Me.txtRevisedTaxAmt.Width = 1.125!
        '
        'txtRevisedCommission
        '
        Me.txtRevisedCommission.CanShrink = True
        Me.txtRevisedCommission.DataField = "REVISED_MARKUP_AMT"
        Me.txtRevisedCommission.Height = 0.1875!
        Me.txtRevisedCommission.Left = 5.1875!
        Me.txtRevisedCommission.Name = "txtRevisedCommission"
        Me.txtRevisedCommission.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedCommission.SummaryGroup = "GroupHeader1"
        Me.txtRevisedCommission.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedCommission.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedCommission.Text = Nothing
        Me.txtRevisedCommission.Top = 0.4375!
        Me.txtRevisedCommission.Width = 1.125!
        '
        'txtRevisedCont2Total
        '
        Me.txtRevisedCont2Total.CanShrink = True
        Me.txtRevisedCont2Total.DataField = "REVISED_CONT"
        Me.txtRevisedCont2Total.Height = 0.1875!
        Me.txtRevisedCont2Total.Left = 5.1875!
        Me.txtRevisedCont2Total.Name = "txtRevisedCont2Total"
        Me.txtRevisedCont2Total.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedCont2Total.SummaryGroup = "GroupHeader1"
        Me.txtRevisedCont2Total.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedCont2Total.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedCont2Total.Text = Nothing
        Me.txtRevisedCont2Total.Top = 0.25!
        Me.txtRevisedCont2Total.Visible = False
        Me.txtRevisedCont2Total.Width = 1.125!
        '
        'txtOriginalSubtotal
        '
        Me.txtOriginalSubtotal.CanShrink = True
        Me.txtOriginalSubtotal.DataField = "ORIGINAL_AMT"
        Me.txtOriginalSubtotal.Height = 0.1875!
        Me.txtOriginalSubtotal.Left = 4.0!
        Me.txtOriginalSubtotal.Name = "txtOriginalSubtotal"
        Me.txtOriginalSubtotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOriginalSubtotal.SummaryGroup = "GroupHeader1"
        Me.txtOriginalSubtotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOriginalSubtotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOriginalSubtotal.Text = Nothing
        Me.txtOriginalSubtotal.Top = 0.0!
        Me.txtOriginalSubtotal.Width = 1.124499!
        '
        'txtRevisedSubTotal
        '
        Me.txtRevisedSubTotal.CanShrink = True
        Me.txtRevisedSubTotal.DataField = "REVISED_AMT"
        Me.txtRevisedSubTotal.Height = 0.1875!
        Me.txtRevisedSubTotal.Left = 5.187!
        Me.txtRevisedSubTotal.Name = "txtRevisedSubTotal"
        Me.txtRevisedSubTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedSubTotal.SummaryGroup = "GroupHeader1"
        Me.txtRevisedSubTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedSubTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedSubTotal.Text = Nothing
        Me.txtRevisedSubTotal.Top = 0.0!
        Me.txtRevisedSubTotal.Width = 1.125!
        '
        'txtRevisedContTotal
        '
        Me.txtRevisedContTotal.CanShrink = True
        Me.txtRevisedContTotal.DataField = "REVISED_CONT"
        Me.txtRevisedContTotal.Height = 0.1875!
        Me.txtRevisedContTotal.Left = 0.313!
        Me.txtRevisedContTotal.Name = "txtRevisedContTotal"
        Me.txtRevisedContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedContTotal.SummaryGroup = "GroupHeader1"
        Me.txtRevisedContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedContTotal.Text = Nothing
        Me.txtRevisedContTotal.Top = 0.25!
        Me.txtRevisedContTotal.Visible = False
        Me.txtRevisedContTotal.Width = 0.125!
        '
        'txtRevisedMUContTotal
        '
        Me.txtRevisedMUContTotal.CanShrink = True
        Me.txtRevisedMUContTotal.DataField = "REVISED_MU_CONT"
        Me.txtRevisedMUContTotal.Height = 0.1875!
        Me.txtRevisedMUContTotal.Left = 0.125!
        Me.txtRevisedMUContTotal.Name = "txtRevisedMUContTotal"
        Me.txtRevisedMUContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedMUContTotal.SummaryGroup = "GroupHeader1"
        Me.txtRevisedMUContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedMUContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedMUContTotal.Text = Nothing
        Me.txtRevisedMUContTotal.Top = 0.25!
        Me.txtRevisedMUContTotal.Visible = False
        Me.txtRevisedMUContTotal.Width = 0.125!
        '
        'txtOrigContTotal
        '
        Me.txtOrigContTotal.CanShrink = True
        Me.txtOrigContTotal.DataField = "ORIGINAL_CONT"
        Me.txtOrigContTotal.Height = 0.1875!
        Me.txtOrigContTotal.Left = 0.312!
        Me.txtOrigContTotal.Name = "txtOrigContTotal"
        Me.txtOrigContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigContTotal.SummaryGroup = "GroupHeader1"
        Me.txtOrigContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOrigContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOrigContTotal.Text = Nothing
        Me.txtOrigContTotal.Top = 0.0!
        Me.txtOrigContTotal.Visible = False
        Me.txtOrigContTotal.Width = 0.125!
        '
        'txtOrigMUContTotal
        '
        Me.txtOrigMUContTotal.CanShrink = True
        Me.txtOrigMUContTotal.DataField = "ORIGINAL_MU_CONT"
        Me.txtOrigMUContTotal.Height = 0.1875!
        Me.txtOrigMUContTotal.Left = 0.125!
        Me.txtOrigMUContTotal.Name = "txtOrigMUContTotal"
        Me.txtOrigMUContTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigMUContTotal.SummaryGroup = "GroupHeader1"
        Me.txtOrigMUContTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOrigMUContTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOrigMUContTotal.Text = Nothing
        Me.txtOrigMUContTotal.Top = 0.0!
        Me.txtOrigMUContTotal.Visible = False
        Me.txtOrigMUContTotal.Width = 0.125!
        '
        'txtRevisedTotalForEst
        '
        Me.txtRevisedTotalForEst.Height = 0.1875!
        Me.txtRevisedTotalForEst.Left = 5.1875!
        Me.txtRevisedTotalForEst.Name = "txtRevisedTotalForEst"
        Me.txtRevisedTotalForEst.OutputFormat = resources.GetString("txtRevisedTotalForEst.OutputFormat")
        Me.txtRevisedTotalForEst.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtRevisedTotalForEst.Text = Nothing
        Me.txtRevisedTotalForEst.Top = 0.875!
        Me.txtRevisedTotalForEst.Width = 1.125499!
        '
        'txtOrigTotalForEst
        '
        Me.txtOrigTotalForEst.Height = 0.1875!
        Me.txtOrigTotalForEst.Left = 4.0!
        Me.txtOrigTotalForEst.Name = "txtOrigTotalForEst"
        Me.txtOrigTotalForEst.OutputFormat = resources.GetString("txtOrigTotalForEst.OutputFormat")
        Me.txtOrigTotalForEst.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtOrigTotalForEst.Text = Nothing
        Me.txtOrigTotalForEst.Top = 0.875!
        Me.txtOrigTotalForEst.Width = 1.124499!
        '
        'txtVarianceTotalEst
        '
        Me.txtVarianceTotalEst.Height = 0.1875!
        Me.txtVarianceTotalEst.Left = 6.375!
        Me.txtVarianceTotalEst.Name = "txtVarianceTotalEst"
        Me.txtVarianceTotalEst.OutputFormat = resources.GetString("txtVarianceTotalEst.OutputFormat")
        Me.txtVarianceTotalEst.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtVarianceTotalEst.Text = Nothing
        Me.txtVarianceTotalEst.Top = 0.875!
        Me.txtVarianceTotalEst.Width = 1.0!
        '
        'txtVarianceTax
        '
        Me.txtVarianceTax.CanShrink = True
        Me.txtVarianceTax.Height = 0.1875!
        Me.txtVarianceTax.Left = 6.375!
        Me.txtVarianceTax.Name = "txtVarianceTax"
        Me.txtVarianceTax.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtVarianceTax.SummaryGroup = "GroupHeader1"
        Me.txtVarianceTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtVarianceTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtVarianceTax.Text = Nothing
        Me.txtVarianceTax.Top = 0.625!
        Me.txtVarianceTax.Width = 1.0!
        '
        'txtVarianceCommission
        '
        Me.txtVarianceCommission.CanShrink = True
        Me.txtVarianceCommission.Height = 0.1875!
        Me.txtVarianceCommission.Left = 6.375!
        Me.txtVarianceCommission.Name = "txtVarianceCommission"
        Me.txtVarianceCommission.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtVarianceCommission.SummaryGroup = "GroupHeader1"
        Me.txtVarianceCommission.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtVarianceCommission.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtVarianceCommission.Text = Nothing
        Me.txtVarianceCommission.Top = 0.4375!
        Me.txtVarianceCommission.Width = 1.0!
        '
        'txtVarianceSubTotal
        '
        Me.txtVarianceSubTotal.CanShrink = True
        Me.txtVarianceSubTotal.Height = 0.1875!
        Me.txtVarianceSubTotal.Left = 6.375!
        Me.txtVarianceSubTotal.Name = "txtVarianceSubTotal"
        Me.txtVarianceSubTotal.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtVarianceSubTotal.SummaryGroup = "GroupHeader1"
        Me.txtVarianceSubTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtVarianceSubTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtVarianceSubTotal.Text = Nothing
        Me.txtVarianceSubTotal.Top = 0.0!
        Me.txtVarianceSubTotal.Width = 1.0!
        '
        'txtVarianceCont2Total
        '
        Me.txtVarianceCont2Total.CanShrink = True
        Me.txtVarianceCont2Total.Height = 0.1875!
        Me.txtVarianceCont2Total.Left = 6.375!
        Me.txtVarianceCont2Total.Name = "txtVarianceCont2Total"
        Me.txtVarianceCont2Total.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtVarianceCont2Total.SummaryGroup = "GroupHeader1"
        Me.txtVarianceCont2Total.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtVarianceCont2Total.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtVarianceCont2Total.Text = Nothing
        Me.txtVarianceCont2Total.Top = 0.25!
        Me.txtVarianceCont2Total.Width = 1.0!
        '
        'txtOneRevTotal
        '
        Me.txtOneRevTotal.CanShrink = True
        Me.txtOneRevTotal.DataField = "ONE_REVISION"
        Me.txtOneRevTotal.Height = 0.062!
        Me.txtOneRevTotal.Left = 2.312!
        Me.txtOneRevTotal.Name = "txtOneRevTotal"
        Me.txtOneRevTotal.Text = Nothing
        Me.txtOneRevTotal.Top = 0.062!
        Me.txtOneRevTotal.Visible = False
        Me.txtOneRevTotal.Width = 0.1869998!
        '
        'Line15
        '
        Me.Line15.Height = 0.0!
        Me.Line15.Left = 6.375!
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 0.0!
        Me.Line15.Visible = False
        Me.Line15.Width = 1.0!
        Me.Line15.X1 = 6.375!
        Me.Line15.X2 = 7.375!
        Me.Line15.Y1 = 0.0!
        Me.Line15.Y2 = 0.0!
        '
        'Line16
        '
        Me.Line16.Height = 0.0!
        Me.Line16.Left = 5.1875!
        Me.Line16.LineWeight = 1.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 0.0!
        Me.Line16.Visible = False
        Me.Line16.Width = 1.125!
        Me.Line16.X1 = 5.1875!
        Me.Line16.X2 = 6.3125!
        Me.Line16.Y1 = 0.0!
        Me.Line16.Y2 = 0.0!
        '
        'Line17
        '
        Me.Line17.Height = 0.0!
        Me.Line17.Left = 4.0!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 0.0!
        Me.Line17.Visible = False
        Me.Line17.Width = 1.125!
        Me.Line17.X1 = 4.0!
        Me.Line17.X2 = 5.125!
        Me.Line17.Y1 = 0.0!
        Me.Line17.Y2 = 0.0!
        '
        'txtOriginalCPU
        '
        Me.txtOriginalCPU.CanShrink = True
        Me.txtOriginalCPU.DataField = "ORIGINAL_CPU"
        Me.txtOriginalCPU.Height = 0.1875!
        Me.txtOriginalCPU.Left = 4.0!
        Me.txtOriginalCPU.Name = "txtOriginalCPU"
        Me.txtOriginalCPU.OutputFormat = resources.GetString("txtOriginalCPU.OutputFormat")
        Me.txtOriginalCPU.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOriginalCPU.Text = Nothing
        Me.txtOriginalCPU.Top = 1.125!
        Me.txtOriginalCPU.Width = 1.125!
        '
        'txtOriginalCPM
        '
        Me.txtOriginalCPM.CanShrink = True
        Me.txtOriginalCPM.DataField = "ORIGINAL_CPM"
        Me.txtOriginalCPM.Height = 0.1875!
        Me.txtOriginalCPM.Left = 4.0!
        Me.txtOriginalCPM.Name = "txtOriginalCPM"
        Me.txtOriginalCPM.OutputFormat = resources.GetString("txtOriginalCPM.OutputFormat")
        Me.txtOriginalCPM.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOriginalCPM.Text = Nothing
        Me.txtOriginalCPM.Top = 1.312!
        Me.txtOriginalCPM.Width = 1.125!
        '
        'txtRevisedCPU
        '
        Me.txtRevisedCPU.CanShrink = True
        Me.txtRevisedCPU.DataField = "REVISED_CPU"
        Me.txtRevisedCPU.Height = 0.1875!
        Me.txtRevisedCPU.Left = 5.187!
        Me.txtRevisedCPU.Name = "txtRevisedCPU"
        Me.txtRevisedCPU.OutputFormat = resources.GetString("txtRevisedCPU.OutputFormat")
        Me.txtRevisedCPU.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedCPU.Text = Nothing
        Me.txtRevisedCPU.Top = 1.125!
        Me.txtRevisedCPU.Width = 1.125!
        '
        'txtRevisedCPM
        '
        Me.txtRevisedCPM.CanShrink = True
        Me.txtRevisedCPM.DataField = "REVISED_CPM"
        Me.txtRevisedCPM.Height = 0.1875!
        Me.txtRevisedCPM.Left = 5.187!
        Me.txtRevisedCPM.Name = "txtRevisedCPM"
        Me.txtRevisedCPM.OutputFormat = resources.GetString("txtRevisedCPM.OutputFormat")
        Me.txtRevisedCPM.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedCPM.Text = Nothing
        Me.txtRevisedCPM.Top = 1.312!
        Me.txtRevisedCPM.Width = 1.125!
        '
        'AuthDate
        '
        Me.AuthDate.Height = 0.1875!
        Me.AuthDate.Left = 1.125!
        Me.AuthDate.Name = "AuthDate"
        Me.AuthDate.Style = "font-size: 9pt; font-weight: normal; text-align: left; ddo-char-set: 0"
        Me.AuthDate.Text = Nothing
        Me.AuthDate.Top = 0.9375!
        Me.AuthDate.Width = 1.0!
        '
        'txtClientApprovalText
        '
        Me.txtClientApprovalText.Height = 0.1875!
        Me.txtClientApprovalText.Left = 3.875!
        Me.txtClientApprovalText.Name = "txtClientApprovalText"
        Me.txtClientApprovalText.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtClientApprovalText.Text = "Client Approval"
        Me.txtClientApprovalText.Top = 0.4375!
        Me.txtClientApprovalText.Width = 1.0!
        '
        'txtPreparedBy
        '
        Me.txtPreparedBy.Height = 0.6875!
        Me.txtPreparedBy.Left = 0.0625!
        Me.txtPreparedBy.Name = "txtPreparedBy"
        Me.txtPreparedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; vertical-align: bottom; ddo" & _
    "-char-set: 0"
        Me.txtPreparedBy.Text = "Agency Authorization:"
        Me.txtPreparedBy.Top = 0.125!
        Me.txtPreparedBy.Width = 0.9375!
        '
        'txtAuthorizedBy
        '
        Me.txtAuthorizedBy.Height = 0.1875!
        Me.txtAuthorizedBy.Left = 0.5!
        Me.txtAuthorizedBy.Name = "txtAuthorizedBy"
        Me.txtAuthorizedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtAuthorizedBy.Text = "Date:"
        Me.txtAuthorizedBy.Top = 1.0!
        Me.txtAuthorizedBy.Width = 0.5!
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.Height = 0.1875!
        Me.txtApprovedBy.Left = 4.0!
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtApprovedBy.Text = "Approved By:"
        Me.txtApprovedBy.Top = 0.625!
        Me.txtApprovedBy.Width = 0.875!
        '
        'txtDate
        '
        Me.txtDate.Height = 0.1875!
        Me.txtDate.Left = 4.375!
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
        Me.Line4.Width = 2.625!
        Me.Line4.X1 = 1.0625!
        Me.Line4.X2 = 3.6875!
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
        Me.Line6.Left = 4.9375!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.8125!
        Me.Line6.Width = 2.5!
        Me.Line6.X1 = 4.9375!
        Me.Line6.X2 = 7.4375!
        Me.Line6.Y1 = 0.8125!
        Me.Line6.Y2 = 0.8125!
        '
        'Line7
        '
        Me.Line7.Height = 0.0!
        Me.Line7.Left = 4.9375!
        Me.Line7.LineWeight = 2.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 1.1875!
        Me.Line7.Width = 2.5!
        Me.Line7.X1 = 4.9375!
        Me.Line7.X2 = 7.4375!
        Me.Line7.Y1 = 1.1875!
        Me.Line7.Y2 = 1.1875!
        '
        'txtEstDefaultComment
        '
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
        Me.GroupHeader2.Height = 0.2604167!
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
        Me.txtFunctionType.Width = 4.4995!
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
        Me.txtFunctionHeading.Width = 4.4995!
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
        Me.txtInsideDesc.Width = 4.4995!
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
        Me.txtPhaseDesc.Width = 4.4995!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.CanShrink = True
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalLabel, Me.txtOrigContGrouping, Me.txtOrigTaxGrouping, Me.txtOrigMarkupAmtGrouping, Me.Line9, Me.txtRevisedMarkupAmtGrouping, Me.txtRevisedTaxGrouping, Me.txtRevisedContGrouping, Me.txtOrigTotalGrouping, Me.txtRevisedTotalGrouping, Me.txtActualMarkupGrouping, Me.txtActualTaxGrouping, Me.txtVarianceGroupingTotal, Me.Line10, Me.Line11})
        Me.GroupFooter2.Height = 0.25!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'txtTotalLabel
        '
        Me.txtTotalLabel.CanShrink = True
        Me.txtTotalLabel.Height = 0.1875!
        Me.txtTotalLabel.Left = 0.0625!
        Me.txtTotalLabel.Name = "txtTotalLabel"
        Me.txtTotalLabel.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtTotalLabel.Text = "Total:"
        Me.txtTotalLabel.Top = 0.0!
        Me.txtTotalLabel.Width = 3.875!
        '
        'txtOrigContGrouping
        '
        Me.txtOrigContGrouping.CanShrink = True
        Me.txtOrigContGrouping.DataField = "ORIGINAL_CONT"
        Me.txtOrigContGrouping.Height = 0.1875!
        Me.txtOrigContGrouping.Left = 0.5!
        Me.txtOrigContGrouping.Name = "txtOrigContGrouping"
        Me.txtOrigContGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigContGrouping.SummaryGroup = "GroupHeader2"
        Me.txtOrigContGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOrigContGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOrigContGrouping.Text = Nothing
        Me.txtOrigContGrouping.Top = 0.0!
        Me.txtOrigContGrouping.Visible = False
        Me.txtOrigContGrouping.Width = 0.187!
        '
        'txtOrigTaxGrouping
        '
        Me.txtOrigTaxGrouping.DataField = "ORIGINAL_TAX"
        Me.txtOrigTaxGrouping.Height = 0.1875!
        Me.txtOrigTaxGrouping.Left = 0.312!
        Me.txtOrigTaxGrouping.Name = "txtOrigTaxGrouping"
        Me.txtOrigTaxGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigTaxGrouping.SummaryGroup = "GroupHeader2"
        Me.txtOrigTaxGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOrigTaxGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOrigTaxGrouping.Text = Nothing
        Me.txtOrigTaxGrouping.Top = 0.0!
        Me.txtOrigTaxGrouping.Visible = False
        Me.txtOrigTaxGrouping.Width = 0.125!
        '
        'txtOrigMarkupAmtGrouping
        '
        Me.txtOrigMarkupAmtGrouping.DataField = "ORIGINAL_MARKUP_AMT"
        Me.txtOrigMarkupAmtGrouping.Height = 0.1875!
        Me.txtOrigMarkupAmtGrouping.Left = 0.125!
        Me.txtOrigMarkupAmtGrouping.Name = "txtOrigMarkupAmtGrouping"
        Me.txtOrigMarkupAmtGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtOrigMarkupAmtGrouping.SummaryGroup = "GroupHeader2"
        Me.txtOrigMarkupAmtGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOrigMarkupAmtGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOrigMarkupAmtGrouping.Text = Nothing
        Me.txtOrigMarkupAmtGrouping.Top = 0.0!
        Me.txtOrigMarkupAmtGrouping.Visible = False
        Me.txtOrigMarkupAmtGrouping.Width = 0.125!
        '
        'Line9
        '
        Me.Line9.Height = 0.0!
        Me.Line9.Left = 6.375!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.0!
        Me.Line9.Width = 0.9994998!
        Me.Line9.X1 = 6.375!
        Me.Line9.X2 = 7.3745!
        Me.Line9.Y1 = 0.0!
        Me.Line9.Y2 = 0.0!
        '
        'txtRevisedMarkupAmtGrouping
        '
        Me.txtRevisedMarkupAmtGrouping.DataField = "REVISED_MARKUP_AMT"
        Me.txtRevisedMarkupAmtGrouping.Height = 0.1875!
        Me.txtRevisedMarkupAmtGrouping.Left = 0.7500001!
        Me.txtRevisedMarkupAmtGrouping.Name = "txtRevisedMarkupAmtGrouping"
        Me.txtRevisedMarkupAmtGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedMarkupAmtGrouping.SummaryGroup = "GroupHeader2"
        Me.txtRevisedMarkupAmtGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedMarkupAmtGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedMarkupAmtGrouping.Text = Nothing
        Me.txtRevisedMarkupAmtGrouping.Top = 0.0!
        Me.txtRevisedMarkupAmtGrouping.Visible = False
        Me.txtRevisedMarkupAmtGrouping.Width = 0.125!
        '
        'txtRevisedTaxGrouping
        '
        Me.txtRevisedTaxGrouping.DataField = "REVISED_TAX"
        Me.txtRevisedTaxGrouping.Height = 0.1875!
        Me.txtRevisedTaxGrouping.Left = 0.937!
        Me.txtRevisedTaxGrouping.Name = "txtRevisedTaxGrouping"
        Me.txtRevisedTaxGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedTaxGrouping.SummaryGroup = "GroupHeader2"
        Me.txtRevisedTaxGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedTaxGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedTaxGrouping.Text = Nothing
        Me.txtRevisedTaxGrouping.Top = 0.0!
        Me.txtRevisedTaxGrouping.Visible = False
        Me.txtRevisedTaxGrouping.Width = 0.125!
        '
        'txtRevisedContGrouping
        '
        Me.txtRevisedContGrouping.CanShrink = True
        Me.txtRevisedContGrouping.DataField = "REVISED_CONT"
        Me.txtRevisedContGrouping.Height = 0.1875!
        Me.txtRevisedContGrouping.Left = 1.125!
        Me.txtRevisedContGrouping.Name = "txtRevisedContGrouping"
        Me.txtRevisedContGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtRevisedContGrouping.SummaryGroup = "GroupHeader2"
        Me.txtRevisedContGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedContGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedContGrouping.Text = Nothing
        Me.txtRevisedContGrouping.Top = 0.0!
        Me.txtRevisedContGrouping.Visible = False
        Me.txtRevisedContGrouping.Width = 0.1870001!
        '
        'txtOrigTotalGrouping
        '
        Me.txtOrigTotalGrouping.CanShrink = True
        Me.txtOrigTotalGrouping.DataField = "ORIGINAL_AMT"
        Me.txtOrigTotalGrouping.Height = 0.1875!
        Me.txtOrigTotalGrouping.Left = 4.0!
        Me.txtOrigTotalGrouping.Name = "txtOrigTotalGrouping"
        Me.txtOrigTotalGrouping.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtOrigTotalGrouping.SummaryGroup = "GroupHeader2"
        Me.txtOrigTotalGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtOrigTotalGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtOrigTotalGrouping.Text = Nothing
        Me.txtOrigTotalGrouping.Top = 0.0!
        Me.txtOrigTotalGrouping.Width = 1.1245!
        '
        'txtRevisedTotalGrouping
        '
        Me.txtRevisedTotalGrouping.CanShrink = True
        Me.txtRevisedTotalGrouping.DataField = "REVISED_AMT"
        Me.txtRevisedTotalGrouping.Height = 0.1875!
        Me.txtRevisedTotalGrouping.Left = 5.187!
        Me.txtRevisedTotalGrouping.Name = "txtRevisedTotalGrouping"
        Me.txtRevisedTotalGrouping.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtRevisedTotalGrouping.SummaryGroup = "GroupHeader2"
        Me.txtRevisedTotalGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtRevisedTotalGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtRevisedTotalGrouping.Text = Nothing
        Me.txtRevisedTotalGrouping.Top = 0.0!
        Me.txtRevisedTotalGrouping.Width = 1.125!
        '
        'txtActualMarkupGrouping
        '
        Me.txtActualMarkupGrouping.DataField = "Actual_Markup"
        Me.txtActualMarkupGrouping.Height = 0.1875!
        Me.txtActualMarkupGrouping.Left = 1.437!
        Me.txtActualMarkupGrouping.Name = "txtActualMarkupGrouping"
        Me.txtActualMarkupGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtActualMarkupGrouping.SummaryGroup = "GroupHeader2"
        Me.txtActualMarkupGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtActualMarkupGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtActualMarkupGrouping.Text = Nothing
        Me.txtActualMarkupGrouping.Top = 0.0!
        Me.txtActualMarkupGrouping.Visible = False
        Me.txtActualMarkupGrouping.Width = 0.125!
        '
        'txtActualTaxGrouping
        '
        Me.txtActualTaxGrouping.DataField = "Actual_Tax"
        Me.txtActualTaxGrouping.Height = 0.1875!
        Me.txtActualTaxGrouping.Left = 1.624!
        Me.txtActualTaxGrouping.Name = "txtActualTaxGrouping"
        Me.txtActualTaxGrouping.Style = "font-size: 9pt; text-align: right; ddo-char-set: 0"
        Me.txtActualTaxGrouping.SummaryGroup = "GroupHeader2"
        Me.txtActualTaxGrouping.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtActualTaxGrouping.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtActualTaxGrouping.Text = Nothing
        Me.txtActualTaxGrouping.Top = 0.0!
        Me.txtActualTaxGrouping.Visible = False
        Me.txtActualTaxGrouping.Width = 0.125!
        '
        'txtVarianceGroupingTotal
        '
        Me.txtVarianceGroupingTotal.CanShrink = True
        Me.txtVarianceGroupingTotal.Height = 0.1875!
        Me.txtVarianceGroupingTotal.Left = 6.375!
        Me.txtVarianceGroupingTotal.Name = "txtVarianceGroupingTotal"
        Me.txtVarianceGroupingTotal.Style = "font-size: 9pt; text-align: right; text-decoration: none; ddo-char-set: 0"
        Me.txtVarianceGroupingTotal.SummaryGroup = "GroupHeader2"
        Me.txtVarianceGroupingTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtVarianceGroupingTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtVarianceGroupingTotal.Text = Nothing
        Me.txtVarianceGroupingTotal.Top = 0.0!
        Me.txtVarianceGroupingTotal.Width = 0.9994993!
        '
        'Line10
        '
        Me.Line10.Height = 0.0!
        Me.Line10.Left = 5.1875!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.0!
        Me.Line10.Width = 1.125!
        Me.Line10.X1 = 5.1875!
        Me.Line10.X2 = 6.3125!
        Me.Line10.Y1 = 0.0!
        Me.Line10.Y2 = 0.0!
        '
        'Line11
        '
        Me.Line11.Height = 0.0!
        Me.Line11.Left = 4.0!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.0!
        Me.Line11.Width = 1.125!
        Me.Line11.X1 = 4.0!
        Me.Line11.X2 = 5.125!
        Me.Line11.Y1 = 0.0!
        Me.Line11.Y2 = 0.0!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReport1, Me.txtEst, Me.TextBox9, Me.txtEstimateHdr, Me.txtDates, Me.Line2, Me.txtPhone, Me.txtCityStateZip, Me.txtFedID, Me.txtAddress2, Me.txtFax, Me.txtEmail, Me.txtCDPContact, Me.txtCCAddress, Me.txtCCState, Me.txtCCZip, Me.txtCCAddress2, Me.txtCCCity, Me.estcomp, Me.est, Me.quote, Me.rev, Me.TextBox4, Me.ReportInfo1})
        Me.GroupHeader3.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader3.Height = 0.7291667!
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
        Me.txtEst.Left = 5.125!
        Me.txtEst.Name = "txtEst"
        Me.txtEst.Style = "font-family: Arial; font-size: 9pt; font-weight: normal; text-align: right; ddo-c" & _
    "har-set: 0"
        Me.txtEst.Text = "Estimate:"
        Me.txtEst.Top = 0.0625!
        Me.txtEst.Width = 1.0625!
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
        'TextBox4
        '
        Me.TextBox4.CanShrink = True
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 5.8125!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "font-family: Arial; font-size: 9pt; font-weight: normal; text-align: right; ddo-c" & _
    "har-set: 0"
        Me.TextBox4.Text = "Page:"
        Me.TextBox4.Top = 0.4375!
        Me.TextBox4.Width = 0.375!
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
        'GroupFooter3
        '
        Me.GroupFooter3.CanShrink = True
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.EmpSigPic, Me.txtClientApprovalText, Me.txtPreparedBy, Me.txtAuthorizedBy, Me.txtApprovedBy, Me.txtDate, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.AuthDate})
        Me.GroupFooter3.Height = 1.241667!
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
        Me.GroupFooter4.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtClientApproval2, Me.txtApprovedBy2, Me.txtDate2, Me.lineCA2, Me.lineDate2, Me.TextBox3, Me.TextBox7, Me.TextBox11, Me.Line12, Me.Line13, Me.TextBox12, Me.TextBox13, Me.TextBox14, Me.Line14, Me.Line18, Me.TextBox15, Me.TextBox16, Me.TextBox17, Me.Line19, Me.Line20})
        Me.GroupFooter4.Height = 1.479167!
        Me.GroupFooter4.KeepTogether = True
        Me.GroupFooter4.Name = "GroupFooter4"
        Me.GroupFooter4.Visible = False
        '
        'txtClientApproval2
        '
        Me.txtClientApproval2.Height = 0.1875!
        Me.txtClientApproval2.Left = 3.8125!
        Me.txtClientApproval2.Name = "txtClientApproval2"
        Me.txtClientApproval2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtClientApproval2.Text = "Client Approval"
        Me.txtClientApproval2.Top = 0.0625!
        Me.txtClientApproval2.Width = 1.0625!
        '
        'txtApprovedBy2
        '
        Me.txtApprovedBy2.Height = 0.1875!
        Me.txtApprovedBy2.Left = 4.0!
        Me.txtApprovedBy2.Name = "txtApprovedBy2"
        Me.txtApprovedBy2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtApprovedBy2.Text = "Approved By:"
        Me.txtApprovedBy2.Top = 0.25!
        Me.txtApprovedBy2.Width = 0.875!
        '
        'txtDate2
        '
        Me.txtDate2.Height = 0.1875!
        Me.txtDate2.Left = 4.0625!
        Me.txtDate2.Name = "txtDate2"
        Me.txtDate2.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.txtDate2.Text = "Date:"
        Me.txtDate2.Top = 0.5!
        Me.txtDate2.Width = 0.8125!
        '
        'lineCA2
        '
        Me.lineCA2.Height = 0.0!
        Me.lineCA2.Left = 4.9375!
        Me.lineCA2.LineWeight = 2.0!
        Me.lineCA2.Name = "lineCA2"
        Me.lineCA2.Top = 0.4375!
        Me.lineCA2.Width = 2.5!
        Me.lineCA2.X1 = 4.9375!
        Me.lineCA2.X2 = 7.4375!
        Me.lineCA2.Y1 = 0.4375!
        Me.lineCA2.Y2 = 0.4375!
        '
        'lineDate2
        '
        Me.lineDate2.Height = 0.0!
        Me.lineDate2.Left = 4.9375!
        Me.lineDate2.LineWeight = 2.0!
        Me.lineDate2.Name = "lineDate2"
        Me.lineDate2.Top = 0.6875!
        Me.lineDate2.Width = 2.5!
        Me.lineDate2.X1 = 4.9375!
        Me.lineDate2.X2 = 7.4375!
        Me.lineDate2.Y1 = 0.6875!
        Me.lineDate2.Y2 = 0.6875!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 3.8125!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox3.Text = "Client Approval"
        Me.TextBox3.Top = 0.8125!
        Me.TextBox3.Width = 1.0625!
        '
        'TextBox7
        '
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 4.0!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox7.Text = "Approved By:"
        Me.TextBox7.Top = 1.0!
        Me.TextBox7.Width = 0.875!
        '
        'TextBox11
        '
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 4.0625!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox11.Text = "Date:"
        Me.TextBox11.Top = 1.25!
        Me.TextBox11.Width = 0.8125!
        '
        'Line12
        '
        Me.Line12.Height = 0.0!
        Me.Line12.Left = 4.9375!
        Me.Line12.LineWeight = 2.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 1.1875!
        Me.Line12.Width = 2.5!
        Me.Line12.X1 = 4.9375!
        Me.Line12.X2 = 7.4375!
        Me.Line12.Y1 = 1.1875!
        Me.Line12.Y2 = 1.1875!
        '
        'Line13
        '
        Me.Line13.Height = 0.0!
        Me.Line13.Left = 4.9375!
        Me.Line13.LineWeight = 2.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 1.4375!
        Me.Line13.Width = 2.5!
        Me.Line13.X1 = 4.9375!
        Me.Line13.X2 = 7.4375!
        Me.Line13.Y1 = 1.4375!
        Me.Line13.Y2 = 1.4375!
        '
        'TextBox12
        '
        Me.TextBox12.Height = 0.1875!
        Me.TextBox12.Left = 0.0625!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox12.Text = "Client Approval"
        Me.TextBox12.Top = 0.0625!
        Me.TextBox12.Width = 1.0625!
        '
        'TextBox13
        '
        Me.TextBox13.Height = 0.1875!
        Me.TextBox13.Left = 0.25!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox13.Text = "Approved By:"
        Me.TextBox13.Top = 0.25!
        Me.TextBox13.Width = 0.875!
        '
        'TextBox14
        '
        Me.TextBox14.Height = 0.1875!
        Me.TextBox14.Left = 0.3125!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox14.Text = "Date:"
        Me.TextBox14.Top = 0.5!
        Me.TextBox14.Width = 0.8125!
        '
        'Line14
        '
        Me.Line14.Height = 0.0!
        Me.Line14.Left = 1.1875!
        Me.Line14.LineWeight = 2.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 0.4375!
        Me.Line14.Width = 2.5!
        Me.Line14.X1 = 1.1875!
        Me.Line14.X2 = 3.6875!
        Me.Line14.Y1 = 0.4375!
        Me.Line14.Y2 = 0.4375!
        '
        'Line18
        '
        Me.Line18.Height = 0.0!
        Me.Line18.Left = 1.1875!
        Me.Line18.LineWeight = 2.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 0.6875!
        Me.Line18.Width = 2.5!
        Me.Line18.X1 = 1.1875!
        Me.Line18.X2 = 3.6875!
        Me.Line18.Y1 = 0.6875!
        Me.Line18.Y2 = 0.6875!
        '
        'TextBox15
        '
        Me.TextBox15.Height = 0.1875!
        Me.TextBox15.Left = 0.0625!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox15.Text = "Client Approval"
        Me.TextBox15.Top = 0.8125!
        Me.TextBox15.Width = 1.0625!
        '
        'TextBox16
        '
        Me.TextBox16.Height = 0.1875!
        Me.TextBox16.Left = 0.25!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox16.Text = "Approved By:"
        Me.TextBox16.Top = 1.0!
        Me.TextBox16.Width = 0.875!
        '
        'TextBox17
        '
        Me.TextBox17.Height = 0.1875!
        Me.TextBox17.Left = 0.3125!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox17.Text = "Date:"
        Me.TextBox17.Top = 1.25!
        Me.TextBox17.Width = 0.8125!
        '
        'Line19
        '
        Me.Line19.Height = 0.0!
        Me.Line19.Left = 1.1875!
        Me.Line19.LineWeight = 2.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 1.1875!
        Me.Line19.Width = 2.5!
        Me.Line19.X1 = 1.1875!
        Me.Line19.X2 = 3.6875!
        Me.Line19.Y1 = 1.1875!
        Me.Line19.Y2 = 1.1875!
        '
        'Line20
        '
        Me.Line20.Height = 0.0!
        Me.Line20.Left = 1.1875!
        Me.Line20.LineWeight = 2.0!
        Me.Line20.Name = "Line20"
        Me.Line20.Top = 1.4375!
        Me.Line20.Width = 2.5!
        Me.Line20.X1 = 1.1875!
        Me.Line20.X2 = 3.6875!
        Me.Line20.Y1 = 1.4375!
        Me.Line20.Y2 = 1.4375!
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
        Me.GroupFooter5.Height = 0.2916667!
        Me.GroupFooter5.Name = "GroupFooter5"
        '
        'GroupHeader6
        '
        Me.GroupHeader6.CanShrink = True
        Me.GroupHeader6.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtEstimateComments, Me.txtQuoteComments, Me.txtRevisionComments, Me.txtComponentComments})
        Me.GroupHeader6.Height = 0.2916667!
        Me.GroupHeader6.Name = "GroupHeader6"
        '
        'GroupFooter6
        '
        Me.GroupFooter6.Height = 0.0!
        Me.GroupFooter6.Name = "GroupFooter6"
        '
        'GroupHeader7
        '
        Me.GroupHeader7.CanShrink = True
        Me.GroupHeader7.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtOriginalLabel, Me.txtDescription, Me.txtRevisedLabel, Me.txtVarianceText})
        Me.GroupHeader7.Height = 0.2083333!
        Me.GroupHeader7.Name = "GroupHeader7"
        Me.GroupHeader7.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'GroupFooter7
        '
        Me.GroupFooter7.Height = 0.0!
        Me.GroupFooter7.Name = "GroupFooter7"
        '
        'GroupHeader8
        '
        Me.GroupHeader8.Height = 0.0!
        Me.GroupHeader8.Name = "GroupHeader8"
        '
        'GroupFooter8
        '
        Me.GroupFooter8.CanShrink = True
        Me.GroupFooter8.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox21, Me.Line23})
        Me.GroupFooter8.Height = 0.2708333!
        Me.GroupFooter8.Name = "GroupFooter8"
        Me.GroupFooter8.Visible = False
        '
        'TextBox21
        '
        Me.TextBox21.Height = 0.1875!
        Me.TextBox21.Left = 3.812!
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox21.Text = "Purchase Order:"
        Me.TextBox21.Top = 0.062!
        Me.TextBox21.Width = 1.062!
        '
        'Line23
        '
        Me.Line23.Height = 0.0!
        Me.Line23.Left = 4.937!
        Me.Line23.LineWeight = 2.0!
        Me.Line23.Name = "Line23"
        Me.Line23.Top = 0.25!
        Me.Line23.Width = 2.499501!
        Me.Line23.X1 = 4.937!
        Me.Line23.X2 = 7.436501!
        Me.Line23.Y1 = 0.25!
        Me.Line23.Y2 = 0.25!
        '
        'GroupHeader9
        '
        Me.GroupHeader9.Height = 0.0!
        Me.GroupHeader9.Name = "GroupHeader9"
        '
        'GroupFooter9
        '
        Me.GroupFooter9.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox22, Me.Line21, Me.Picture2, Me.TextBox23, Me.Line22, Me.TextBox24, Me.TextBox25, Me.Line32, Me.Line33, Me.TextBoxAuthDate})
        Me.GroupFooter9.Height = 1.218751!
        Me.GroupFooter9.KeepTogether = True
        Me.GroupFooter9.Name = "GroupFooter9"
        Me.GroupFooter9.Visible = False
        '
        'TextBox22
        '
        Me.TextBox22.Height = 0.6875!
        Me.TextBox22.Left = 0.062!
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Style = "font-size: 9pt; font-weight: bold; text-align: right; vertical-align: bottom; ddo" & _
    "-char-set: 0"
        Me.TextBox22.Text = "Agency Authorization Signature"
        Me.TextBox22.Top = 0.125!
        Me.TextBox22.Width = 0.9375!
        '
        'Line21
        '
        Me.Line21.Height = 0.0!
        Me.Line21.Left = 1.062!
        Me.Line21.LineWeight = 2.0!
        Me.Line21.Name = "Line21"
        Me.Line21.Top = 0.812!
        Me.Line21.Width = 2.75!
        Me.Line21.X1 = 1.062!
        Me.Line21.X2 = 3.812!
        Me.Line21.Y1 = 0.812!
        Me.Line21.Y2 = 0.812!
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
        'TextBox23
        '
        Me.TextBox23.Height = 0.4380001!
        Me.TextBox23.Left = 4.0!
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 0"
        Me.TextBox23.Text = "Client Approval Signature"
        Me.TextBox23.Top = 0.375!
        Me.TextBox23.Width = 0.8750001!
        '
        'Line22
        '
        Me.Line22.Height = 0.0!
        Me.Line22.Left = 4.937!
        Me.Line22.LineWeight = 2.0!
        Me.Line22.Name = "Line22"
        Me.Line22.Top = 0.812!
        Me.Line22.Width = 2.5!
        Me.Line22.X1 = 4.937!
        Me.Line22.X2 = 7.437!
        Me.Line22.Y1 = 0.812!
        Me.Line22.Y2 = 0.812!
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
        Me.TextBox25.Left = 4.437!
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
        Me.Line33.Left = 4.937!
        Me.Line33.LineWeight = 2.0!
        Me.Line33.Name = "Line33"
        Me.Line33.Top = 1.187!
        Me.Line33.Width = 2.5005!
        Me.Line33.X1 = 4.937!
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
        Me.TextBoxAuthDate.Width = 1.0!
        '
        'TextBoxCampaign
        '
        Me.TextBoxCampaign.CanShrink = True
        Me.TextBoxCampaign.Height = 0.1875!
        Me.TextBoxCampaign.Left = 3.75!
        Me.TextBoxCampaign.Name = "TextBoxCampaign"
        Me.TextBoxCampaign.Style = "font-size: 9pt; font-weight: bold; text-align: left; ddo-char-set: 0"
        Me.TextBoxCampaign.Text = "Campaign:"
        Me.TextBoxCampaign.Top = 0.06200004!
        Me.TextBoxCampaign.Width = 1.375001!
        '
        'TextBoxCampaignName
        '
        Me.TextBoxCampaignName.CanShrink = True
        Me.TextBoxCampaignName.DataField = "CMP_NAME"
        Me.TextBoxCampaignName.Height = 0.1875!
        Me.TextBoxCampaignName.Left = 5.125!
        Me.TextBoxCampaignName.Name = "TextBoxCampaignName"
        Me.TextBoxCampaignName.Style = "font-size: 9pt; ddo-char-set: 0"
        Me.TextBoxCampaignName.Text = Nothing
        Me.TextBoxCampaignName.Top = 0.06200004!
        Me.TextBoxCampaignName.Width = 2.25!
        '
        'TextBoxCampaignId
        '
        Me.TextBoxCampaignId.CanShrink = True
        Me.TextBoxCampaignId.DataField = "CMP_IDENTIFIER"
        Me.TextBoxCampaignId.Height = 0.1875!
        Me.TextBoxCampaignId.Left = 7.25!
        Me.TextBoxCampaignId.Name = "TextBoxCampaignId"
        Me.TextBoxCampaignId.Style = "font-size: 9pt; text-align: left; ddo-char-set: 0"
        Me.TextBoxCampaignId.Text = Nothing
        Me.TextBoxCampaignId.Top = 1.749!
        Me.TextBoxCampaignId.Visible = False
        Me.TextBoxCampaignId.Width = 0.125!
        '
        'arptEstimating005
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
        CType(Me.txtDescriptionText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOriginalAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFunctionComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigContingency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigMarkupAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigTaxAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSuppliedByNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigMUCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedMarkupAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedMUCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualMarkup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVariance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOneRev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxFunctionDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTerms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxableText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientRefLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalesClassLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobCompDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalesClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccExeLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountExective, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstQuantityLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJobDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComponentComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOriginalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuoteComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisionComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstimateComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVarianceText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommissionLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTaxLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMUContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOriginalTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigCommission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigCont2Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedTaxAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedCommission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedCont2Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOriginalSubtotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedMUContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigMUContTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedTotalForEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigTotalForEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVarianceTotalEst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVarianceTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVarianceCommission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVarianceSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVarianceCont2Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOneRevTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOriginalCPU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOriginalCPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedCPU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedCPM, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.txtTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigContGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigTaxGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedMarkupAmtGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedTaxGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedContGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigTotalGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRevisedTotalGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualMarkupGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualTaxGrouping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVarianceGroupingTotal, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.quote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpSigPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientApproval2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApprovedBy2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxAuthDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCampaign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCampaignName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCampaignId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
    Friend WithEvents txtName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAddress1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTitle As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtComponentComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOriginalLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuoteComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisionComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstimateComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDescription As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtQuoteDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClientRefLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSalesClassLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtQuoteNumber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstDescription As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstCompDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtJobCompDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtClientRef As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSalesClass As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAccExeLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtAccountExective As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstQuantityLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstQuantity As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFunctionType As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFunctionHeading As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtInsideDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPhaseDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigContGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigTaxGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigMarkupAmtGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
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
    Friend WithEvents txtEstDefaultComment As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCommissionLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSubTotalLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMUContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTerms As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxableText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDescriptionText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOriginalAmt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFunctionComments As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedAmt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigContingency As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigMarkupAmt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigTaxAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTaxCode As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtActualHours As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSuppliedByNotes As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtIO As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigMUCont As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedCont As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedMarkupAmt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedTax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedMUCont As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtActualAmount As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtActualMarkup As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtActualTax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtActualTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedMarkupAmtGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedTaxGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedContGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigTotalGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedTotalGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOriginalTax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigCommission As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigCont2Total As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedTaxAmt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedCommission As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedCont2Total As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOriginalSubtotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedSubTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedMUContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigMUContTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRevisedTotalForEst As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOrigTotalForEst As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtActualMarkupGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtActualTaxGrouping As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVariance As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVarianceText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVarianceGroupingTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVarianceTotalEst As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVarianceTax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVarianceCommission As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVarianceSubTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVarianceCont2Total As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOneRevTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtOneRev As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line15 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line16 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line17 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader4 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter4 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtClientApproval2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtApprovedBy2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDate2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lineCA2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lineDate2 As DataDynamics.ActiveReports.Line
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
    Friend WithEvents quote As DataDynamics.ActiveReports.TextBox
    Friend WithEvents rev As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line12 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line13 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line14 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line18 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox16 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line19 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line20 As DataDynamics.ActiveReports.Line
    Private WithEvents GroupHeader8 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter8 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents TextBox21 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line23 As DataDynamics.ActiveReports.Line
    Private WithEvents txtOriginalCPU As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtOriginalCPM As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtRevisedCPU As DataDynamics.ActiveReports.TextBox
    Private WithEvents txtRevisedCPM As DataDynamics.ActiveReports.TextBox
    Private WithEvents GroupHeader9 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter9 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents TextBox22 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line21 As DataDynamics.ActiveReports.Line
    Private WithEvents Picture2 As DataDynamics.ActiveReports.Picture
    Private WithEvents TextBox23 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line22 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBoxFunctionDescription As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox24 As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBox25 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Line32 As DataDynamics.ActiveReports.Line
    Private WithEvents Line33 As DataDynamics.ActiveReports.Line
    Private WithEvents TextBoxAuthDate As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxCampaign As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxCampaignName As DataDynamics.ActiveReports.TextBox
    Private WithEvents TextBoxCampaignId As DataDynamics.ActiveReports.TextBox
End Class
