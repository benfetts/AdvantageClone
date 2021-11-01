﻿Namespace Invoices.NetCommissionTaxCurrent

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class GroupByInsideOutsideSubReport
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Designer
        'It can be modified using the Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GroupByInsideOutsideSubReport))
			Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
			Me.XrSubreportFunctionDetails = New DevExpress.XtraReports.UI.XRSubreport()
			Me.FormattingRuleBillingApprovalFunctionComment = New DevExpress.XtraReports.UI.FormattingRule()
			Me.FormattingRuleShowFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
			Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
			Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
			Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
			Me.XrLabelNetCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelCommissionCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelCurrentTotalCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelFunctionDescription = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelTaxCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.FormattingRuleFunctionTotals = New DevExpress.XtraReports.UI.FormattingRule()
			Me.FormattingRuleShowingFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
			Me.HoursAndQuantity = New DevExpress.XtraReports.UI.CalculatedField()
			Me.InsideOutsideFunctionCode = New DevExpress.XtraReports.UI.CalculatedField()
			Me.InsideOutsideFunction = New DevExpress.XtraReports.UI.CalculatedField()
			Me.ShowFunctionDetail = New DevExpress.XtraReports.Parameters.Parameter()
			Me.FormattingRuleShowEmployeeFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
			Me.FormattingRuleShowIncomeOnlyFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
			Me.FormattingRuleShowVendorFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
			Me.ShowEmployeeFunctionDetails = New DevExpress.XtraReports.Parameters.Parameter()
			Me.ShowIncomeOnlyFunctionDetails = New DevExpress.XtraReports.Parameters.Parameter()
			Me.ShowVendorFunctionDetails = New DevExpress.XtraReports.Parameters.Parameter()
			Me.HideFunctionTotals = New DevExpress.XtraReports.Parameters.Parameter()
			Me.ShowQuantity = New DevExpress.XtraReports.Parameters.Parameter()
			Me.ShowEmployeeHours = New DevExpress.XtraReports.Parameters.Parameter()
			Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
			Me.XrTableComments = New DevExpress.XtraReports.UI.XRTable()
			Me.XrTableRowBillingApprovalFunctionComment = New DevExpress.XtraReports.UI.XRTableRow()
			Me.XrTableCellBillingApprovalFunctionComment = New DevExpress.XtraReports.UI.XRTableCell()
			Me.XrTableRowBillingDetailComment = New DevExpress.XtraReports.UI.XRTableRow()
			Me.XrTableCellBillingDetailComment = New DevExpress.XtraReports.UI.XRTableCell()
			Me.FormattingRuleShowInvoiceComment = New DevExpress.XtraReports.UI.FormattingRule()
			Me.XrRichTextEstimateFunctionComment = New DevExpress.XtraReports.UI.XRRichText()
			Me.FormattingRuleEstimateFunctionComment = New DevExpress.XtraReports.UI.FormattingRule()
			Me.BillingApprovalFunctionComment = New DevExpress.XtraReports.Parameters.Parameter()
			Me.EstimateFunctionComment = New DevExpress.XtraReports.Parameters.Parameter()
			Me.InvoiceComment = New DevExpress.XtraReports.Parameters.Parameter()
			CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.XrTableComments, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.XrRichTextEstimateFunctionComment, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			'
			'Detail
			'
			Me.Detail.HeightF = 0!
			Me.Detail.Name = "Detail"
			Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'XrSubreportFunctionDetails
			'
			Me.XrSubreportFunctionDetails.CanShrink = True
			Me.XrSubreportFunctionDetails.LocationFloat = New DevExpress.Utils.PointFloat(0!, 17.00001!)
			Me.XrSubreportFunctionDetails.Name = "XrSubreportFunctionDetails"
			Me.XrSubreportFunctionDetails.ReportSource = New AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.FunctionDetailSubReport()
			Me.XrSubreportFunctionDetails.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
			'
			'FormattingRuleBillingApprovalFunctionComment
			'
			Me.FormattingRuleBillingApprovalFunctionComment.Condition = "[Parameters.BillingApprovalFunctionComment] == False"
			'
			'
			'
			Me.FormattingRuleBillingApprovalFunctionComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
			Me.FormattingRuleBillingApprovalFunctionComment.Name = "FormattingRuleBillingApprovalFunctionComment"
			'
			'FormattingRuleShowFunctionDetails
			'
			Me.FormattingRuleShowFunctionDetails.Condition = "[Parameters.ShowFunctionDetail] == True"
			'
			'
			'
			Me.FormattingRuleShowFunctionDetails.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
			Me.FormattingRuleShowFunctionDetails.Name = "FormattingRuleShowFunctionDetails"
			'
			'TopMargin
			'
			Me.TopMargin.HeightF = 0!
			Me.TopMargin.Name = "TopMargin"
			Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'BottomMargin
			'
			Me.BottomMargin.HeightF = 0!
			Me.BottomMargin.Name = "BottomMargin"
			Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'GroupHeader
			'
			Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreportFunctionDetails, Me.XrLabelNetCurrentAmount, Me.XrLabelCommissionCurrentAmount, Me.XrLabelCurrentTotalCurrentAmount, Me.XrLabelFunctionDescription, Me.XrLabelTaxCurrentAmount})
			Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InsideOutsideFunctionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
			Me.GroupHeader.HeightF = 34.0!
			Me.GroupHeader.Name = "GroupHeader"
			'
			'XrLabelNetCurrentAmount
			'
			Me.XrLabelNetCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount")})
			Me.XrLabelNetCurrentAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelNetCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(324.29!, 0!)
			Me.XrLabelNetCurrentAmount.Name = "XrLabelNetCurrentAmount"
			Me.XrLabelNetCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelNetCurrentAmount.StylePriority.UseFont = False
			Me.XrLabelNetCurrentAmount.StylePriority.UsePadding = False
			Me.XrLabelNetCurrentAmount.StylePriority.UseTextAlignment = False
			XrSummary1.FormatString = "{0:n2}"
			XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelNetCurrentAmount.Summary = XrSummary1
			Me.XrLabelNetCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabelCommissionCurrentAmount
			'
			Me.XrLabelCommissionCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CommissionAmount")})
			Me.XrLabelCommissionCurrentAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelCommissionCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(433.86!, 0!)
			Me.XrLabelCommissionCurrentAmount.Name = "XrLabelCommissionCurrentAmount"
			Me.XrLabelCommissionCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelCommissionCurrentAmount.StylePriority.UseFont = False
			Me.XrLabelCommissionCurrentAmount.StylePriority.UsePadding = False
			Me.XrLabelCommissionCurrentAmount.StylePriority.UseTextAlignment = False
			XrSummary2.FormatString = "{0:n2}"
			XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelCommissionCurrentAmount.Summary = XrSummary2
			Me.XrLabelCommissionCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabelCurrentTotalCurrentAmount
			'
			Me.XrLabelCurrentTotalCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
			Me.XrLabelCurrentTotalCurrentAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelCurrentTotalCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 0!)
			Me.XrLabelCurrentTotalCurrentAmount.Name = "XrLabelCurrentTotalCurrentAmount"
			Me.XrLabelCurrentTotalCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelCurrentTotalCurrentAmount.StylePriority.UseFont = False
			Me.XrLabelCurrentTotalCurrentAmount.StylePriority.UsePadding = False
			Me.XrLabelCurrentTotalCurrentAmount.StylePriority.UseTextAlignment = False
			XrSummary3.FormatString = "{0:n2}"
			XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelCurrentTotalCurrentAmount.Summary = XrSummary3
			Me.XrLabelCurrentTotalCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabelFunctionDescription
			'
			Me.XrLabelFunctionDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InsideOutsideFunction")})
			Me.XrLabelFunctionDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelFunctionDescription.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
			Me.XrLabelFunctionDescription.Name = "XrLabelFunctionDescription"
			Me.XrLabelFunctionDescription.SizeF = New System.Drawing.SizeF(324.29!, 17.0!)
			Me.XrLabelFunctionDescription.StylePriority.UseFont = False
			Me.XrLabelFunctionDescription.StylePriority.UsePadding = False
			'
			'XrLabelTaxCurrentAmount
			'
			Me.XrLabelTaxCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalTax", "{0:n2}")})
			Me.XrLabelTaxCurrentAmount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelTaxCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.43!, 0!)
			Me.XrLabelTaxCurrentAmount.Name = "XrLabelTaxCurrentAmount"
			Me.XrLabelTaxCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelTaxCurrentAmount.StylePriority.UseFont = False
			Me.XrLabelTaxCurrentAmount.StylePriority.UsePadding = False
			Me.XrLabelTaxCurrentAmount.StylePriority.UseTextAlignment = False
			XrSummary4.FormatString = "{0:n2}"
			XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelTaxCurrentAmount.Summary = XrSummary4
			Me.XrLabelTaxCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'FormattingRuleFunctionTotals
			'
			Me.FormattingRuleFunctionTotals.Condition = "[Parameters.HideFunctionTotals] == True"
			'
			'
			'
			Me.FormattingRuleFunctionTotals.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
			Me.FormattingRuleFunctionTotals.Name = "FormattingRuleFunctionTotals"
			'
			'FormattingRuleShowingFunctionDetails
			'
			Me.FormattingRuleShowingFunctionDetails.Condition = "[Parameters.ShowFunctionDetail] == True"
			'
			'
			'
			Me.FormattingRuleShowingFunctionDetails.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
			Me.FormattingRuleShowingFunctionDetails.Name = "FormattingRuleShowingFunctionDetails"
			'
			'HoursAndQuantity
			'
			Me.HoursAndQuantity.Expression = "Iif([FunctionType]='E', Iif([Parameters.ShowEmployeeHours],[Hours],NULL) ,Iif([Pa" &
	"rameters.ShowQuantity],[Quantity],NULL))"
			Me.HoursAndQuantity.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.HoursAndQuantity.Name = "HoursAndQuantity"
			'
			'InsideOutsideFunctionCode
			'
			Me.InsideOutsideFunctionCode.Expression = "Iif([FunctionType] = 'E', 1 ,  2)"
			Me.InsideOutsideFunctionCode.FieldType = DevExpress.XtraReports.UI.FieldType.Int16
			Me.InsideOutsideFunctionCode.Name = "InsideOutsideFunctionCode"
			'
			'InsideOutsideFunction
			'
			Me.InsideOutsideFunction.Expression = "Iif([FunctionType] = 'E', [InsideDescription] , [OutsideDescription])"
			Me.InsideOutsideFunction.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.InsideOutsideFunction.Name = "InsideOutsideFunction"
			'
			'ShowFunctionDetail
			'
			Me.ShowFunctionDetail.Name = "ShowFunctionDetail"
			Me.ShowFunctionDetail.Type = GetType(Boolean)
			Me.ShowFunctionDetail.ValueInfo = "False"
			Me.ShowFunctionDetail.Visible = False
			'
			'FormattingRuleShowEmployeeFunctionDetails
			'
			Me.FormattingRuleShowEmployeeFunctionDetails.Condition = "Iif([FunctionType] == 'E',  [Parameters.ShowFunctionDetail] == True And [Paramete" &
	"rs.ShowEmployeeFunctionDetails] == False, True)"
			'
			'
			'
			Me.FormattingRuleShowEmployeeFunctionDetails.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
			Me.FormattingRuleShowEmployeeFunctionDetails.Name = "FormattingRuleShowEmployeeFunctionDetails"
			'
			'FormattingRuleShowIncomeOnlyFunctionDetails
			'
			Me.FormattingRuleShowIncomeOnlyFunctionDetails.Condition = "Iif([FunctionType] == 'I',  [Parameters.ShowFunctionDetail] == True And [Paramete" &
	"rs.ShowIncomeOnlyFunctionDetails] == False, True)"
			'
			'
			'
			Me.FormattingRuleShowIncomeOnlyFunctionDetails.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
			Me.FormattingRuleShowIncomeOnlyFunctionDetails.Name = "FormattingRuleShowIncomeOnlyFunctionDetails"
			'
			'FormattingRuleShowVendorFunctionDetails
			'
			Me.FormattingRuleShowVendorFunctionDetails.Condition = "Iif([FunctionType] == 'V',  [Parameters.ShowFunctionDetail] == True And [Paramete" &
	"rs.ShowVendorFunctionDetails] == False, True)"
			'
			'
			'
			Me.FormattingRuleShowVendorFunctionDetails.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
			Me.FormattingRuleShowVendorFunctionDetails.Name = "FormattingRuleShowVendorFunctionDetails"
			'
			'ShowEmployeeFunctionDetails
			'
			Me.ShowEmployeeFunctionDetails.Name = "ShowEmployeeFunctionDetails"
			Me.ShowEmployeeFunctionDetails.Type = GetType(Boolean)
			Me.ShowEmployeeFunctionDetails.ValueInfo = "False"
			Me.ShowEmployeeFunctionDetails.Visible = False
			'
			'ShowIncomeOnlyFunctionDetails
			'
			Me.ShowIncomeOnlyFunctionDetails.Name = "ShowIncomeOnlyFunctionDetails"
			Me.ShowIncomeOnlyFunctionDetails.Type = GetType(Boolean)
			Me.ShowIncomeOnlyFunctionDetails.ValueInfo = "False"
			Me.ShowIncomeOnlyFunctionDetails.Visible = False
			'
			'ShowVendorFunctionDetails
			'
			Me.ShowVendorFunctionDetails.Name = "ShowVendorFunctionDetails"
			Me.ShowVendorFunctionDetails.Type = GetType(Boolean)
			Me.ShowVendorFunctionDetails.ValueInfo = "False"
			Me.ShowVendorFunctionDetails.Visible = False
			'
			'HideFunctionTotals
			'
			Me.HideFunctionTotals.Name = "HideFunctionTotals"
			Me.HideFunctionTotals.Type = GetType(Boolean)
			Me.HideFunctionTotals.ValueInfo = "False"
			Me.HideFunctionTotals.Visible = False
			'
			'ShowQuantity
			'
			Me.ShowQuantity.Name = "ShowQuantity"
			Me.ShowQuantity.Type = GetType(Boolean)
			Me.ShowQuantity.ValueInfo = "False"
			Me.ShowQuantity.Visible = False
			'
			'ShowEmployeeHours
			'
			Me.ShowEmployeeHours.Name = "ShowEmployeeHours"
			Me.ShowEmployeeHours.Type = GetType(Boolean)
			Me.ShowEmployeeHours.ValueInfo = "False"
			Me.ShowEmployeeHours.Visible = False
			'
			'BindingSource
			'
			Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)
			'
			'GroupFooter
			'
			Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableComments, Me.XrRichTextEstimateFunctionComment})
			Me.GroupFooter.HeightF = 51.00002!
			Me.GroupFooter.Name = "GroupFooter"
			'
			'XrTableComments
			'
			Me.XrTableComments.LocationFloat = New DevExpress.Utils.PointFloat(74.99987!, 0!)
			Me.XrTableComments.Name = "XrTableComments"
			Me.XrTableComments.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowBillingApprovalFunctionComment, Me.XrTableRowBillingDetailComment})
			Me.XrTableComments.SizeF = New System.Drawing.SizeF(249.2903!, 34.0!)
			'
			'XrTableRowBillingApprovalFunctionComment
			'
			Me.XrTableRowBillingApprovalFunctionComment.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellBillingApprovalFunctionComment})
			Me.XrTableRowBillingApprovalFunctionComment.FormattingRules.Add(Me.FormattingRuleBillingApprovalFunctionComment)
			Me.XrTableRowBillingApprovalFunctionComment.Name = "XrTableRowBillingApprovalFunctionComment"
			Me.XrTableRowBillingApprovalFunctionComment.Weight = 1.0R
			'
			'XrTableCellBillingApprovalFunctionComment
			'
			Me.XrTableCellBillingApprovalFunctionComment.CanShrink = True
			Me.XrTableCellBillingApprovalFunctionComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingApprovalFunctionComment")})
			Me.XrTableCellBillingApprovalFunctionComment.Multiline = True
			Me.XrTableCellBillingApprovalFunctionComment.Name = "XrTableCellBillingApprovalFunctionComment"
			Me.XrTableCellBillingApprovalFunctionComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
			Me.XrTableCellBillingApprovalFunctionComment.Weight = 1.0R
			'
			'XrTableRowBillingDetailComment
			'
			Me.XrTableRowBillingDetailComment.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellBillingDetailComment})
			Me.XrTableRowBillingDetailComment.FormattingRules.Add(Me.FormattingRuleShowInvoiceComment)
			Me.XrTableRowBillingDetailComment.Name = "XrTableRowBillingDetailComment"
			Me.XrTableRowBillingDetailComment.Weight = 1.0R
			'
			'XrTableCellBillingDetailComment
			'
			Me.XrTableCellBillingDetailComment.CanShrink = True
			Me.XrTableCellBillingDetailComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingDetailComment")})
			Me.XrTableCellBillingDetailComment.Multiline = True
			Me.XrTableCellBillingDetailComment.Name = "XrTableCellBillingDetailComment"
			Me.XrTableCellBillingDetailComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
			Me.XrTableCellBillingDetailComment.Weight = 1.0R
			'
			'FormattingRuleShowInvoiceComment
			'
			Me.FormattingRuleShowInvoiceComment.Condition = "[Parameters.InvoiceComment] == False"
			'
			'
			'
			Me.FormattingRuleShowInvoiceComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
			Me.FormattingRuleShowInvoiceComment.Name = "FormattingRuleShowInvoiceComment"
			'
			'XrRichTextEstimateFunctionComment
			'
			Me.XrRichTextEstimateFunctionComment.CanShrink = True
			Me.XrRichTextEstimateFunctionComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Html", Nothing, "EstimateFunctionComment")})
			Me.XrRichTextEstimateFunctionComment.Font = New System.Drawing.Font("Arial", 9.0!)
			Me.XrRichTextEstimateFunctionComment.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 34.00002!)
			Me.XrRichTextEstimateFunctionComment.Name = "XrRichTextEstimateFunctionComment"
			Me.XrRichTextEstimateFunctionComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
			Me.XrRichTextEstimateFunctionComment.SerializableRtfString = resources.GetString("XrRichTextEstimateFunctionComment.SerializableRtfString")
			Me.XrRichTextEstimateFunctionComment.SizeF = New System.Drawing.SizeF(249.29!, 17.0!)
			'
			'FormattingRuleEstimateFunctionComment
			'
			Me.FormattingRuleEstimateFunctionComment.Condition = "[Parameters.EstimateFunctionComment] == False"
			'
			'
			'
			Me.FormattingRuleEstimateFunctionComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
			Me.FormattingRuleEstimateFunctionComment.Name = "FormattingRuleEstimateFunctionComment"
			'
			'BillingApprovalFunctionComment
			'
			Me.BillingApprovalFunctionComment.Name = "BillingApprovalFunctionComment"
			Me.BillingApprovalFunctionComment.Type = GetType(Boolean)
			Me.BillingApprovalFunctionComment.ValueInfo = "False"
			Me.BillingApprovalFunctionComment.Visible = False
			'
			'EstimateFunctionComment
			'
			Me.EstimateFunctionComment.Name = "EstimateFunctionComment"
			Me.EstimateFunctionComment.Type = GetType(Boolean)
			Me.EstimateFunctionComment.ValueInfo = "False"
			Me.EstimateFunctionComment.Visible = False
			'
			'InvoiceComment
			'
			Me.InvoiceComment.Name = "InvoiceComment"
			Me.InvoiceComment.Type = GetType(Boolean)
			Me.InvoiceComment.ValueInfo = "False"
			Me.InvoiceComment.Visible = False
			'
			'GroupByInsideOutsideSubReport
			'
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.GroupFooter})
			Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.HoursAndQuantity, Me.InsideOutsideFunctionCode, Me.InsideOutsideFunction})
			Me.DataSource = Me.BindingSource
			Me.Font = New System.Drawing.Font("Arial", 9.0!)
			Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleShowInvoiceComment, Me.FormattingRuleBillingApprovalFunctionComment, Me.FormattingRuleEstimateFunctionComment, Me.FormattingRuleShowEmployeeFunctionDetails, Me.FormattingRuleShowVendorFunctionDetails, Me.FormattingRuleShowIncomeOnlyFunctionDetails, Me.FormattingRuleFunctionTotals, Me.FormattingRuleShowFunctionDetails, Me.FormattingRuleShowingFunctionDetails})
			Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 0)
			Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.InvoiceComment, Me.BillingApprovalFunctionComment, Me.EstimateFunctionComment, Me.ShowEmployeeFunctionDetails, Me.ShowIncomeOnlyFunctionDetails, Me.ShowVendorFunctionDetails, Me.ShowFunctionDetail, Me.HideFunctionTotals, Me.ShowQuantity, Me.ShowEmployeeHours})
			Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
			Me.Version = "14.2"
			CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.XrTableComments, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.XrRichTextEstimateFunctionComment, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelFunctionDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTaxCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents HoursAndQuantity As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InsideOutsideFunctionCode As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InsideOutsideFunction As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ShowFunctionDetail As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents HideFunctionTotals As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowQuantity As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowEmployeeHours As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents FormattingRuleShowFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleShowingFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleFunctionTotals As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents XrSubreportFunctionDetails As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrLabelCurrentTotalCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelNetCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCommissionCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents FormattingRuleShowEmployeeFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleShowVendorFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleShowIncomeOnlyFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents ShowEmployeeFunctionDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowIncomeOnlyFunctionDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowVendorFunctionDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BillingApprovalFunctionComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents EstimateFunctionComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents FormattingRuleEstimateFunctionComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleBillingApprovalFunctionComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleShowInvoiceComment As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents InvoiceComment As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrTableComments As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowBillingApprovalFunctionComment As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellBillingApprovalFunctionComment As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowBillingDetailComment As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellBillingDetailComment As DevExpress.XtraReports.UI.XRTableCell


        Friend WithEvents XrRichTextEstimateFunctionComment As DevExpress.XtraReports.UI.XRRichText
    End Class

End Namespace
