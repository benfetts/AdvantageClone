﻿Namespace Invoices.EstimatePriorCurrentTTD

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class GroupByInsideOutsideFunctionSubReport
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
			Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GroupByInsideOutsideFunctionSubReport))
			Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
			Me.XrSubreportFunctionDetails = New DevExpress.XtraReports.UI.XRSubreport()
			Me.FormattingRuleBillingApprovalFunctionComment = New DevExpress.XtraReports.UI.FormattingRule()
			Me.FormattingRuleShowFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
			Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
			Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
			Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
			Me.XrLabelEstimateCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelPriorCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelTTDCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelFunctionDescription = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelIsTaxable = New DevExpress.XtraReports.UI.XRLabel()
			Me.FormattingRuleShowingFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
			Me.FormattingRuleFunctionTotals = New DevExpress.XtraReports.UI.FormattingRule()
			Me.GroupHeaderInsideOutside = New DevExpress.XtraReports.UI.GroupHeaderBand()
			Me.XrLabelPriorTotalAmountHeader = New DevExpress.XtraReports.UI.XRLabel()
			Me.FormattingRuleFunctionTotalsHeader = New DevExpress.XtraReports.UI.FormattingRule()
			Me.XrLabelEstimateTotalAmountHeader = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelTTDTotalAmountHeader = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelTotalAmountHeader = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelFunctionType = New DevExpress.XtraReports.UI.XRLabel()
			Me.HoursAndQuantity = New DevExpress.XtraReports.UI.CalculatedField()
			Me.GroupFooterInsideOutside = New DevExpress.XtraReports.UI.GroupFooterBand()
			Me.XrLabelEstimateTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLabelPriorTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLineEstimateTotalAmount = New DevExpress.XtraReports.UI.XRLine()
			Me.XrLinePriorTotalAmount = New DevExpress.XtraReports.UI.XRLine()
			Me.XrLabelTTDTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLineTTDTotalAmount = New DevExpress.XtraReports.UI.XRLine()
			Me.XrLabelTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrLineTotalAmount = New DevExpress.XtraReports.UI.XRLine()
			Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
			Me.XrTableComments = New DevExpress.XtraReports.UI.XRTable()
			Me.XrTableRowBillingApprovalFunctionComment = New DevExpress.XtraReports.UI.XRTableRow()
			Me.XrTableCellBillingApprovalFunctionComment = New DevExpress.XtraReports.UI.XRTableCell()
			Me.XrTableRowBillingDetailComment = New DevExpress.XtraReports.UI.XRTableRow()
			Me.XrTableCellBillingDetailComment = New DevExpress.XtraReports.UI.XRTableCell()
			Me.FormattingRuleShowInvoiceComment = New DevExpress.XtraReports.UI.FormattingRule()
			Me.XrRichTextEstimateFunctionComment = New DevExpress.XtraReports.UI.XRRichText()
			Me.FormattingRuleEstimateFunctionComment = New DevExpress.XtraReports.UI.FormattingRule()
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
			Me.BillingApprovalFunctionComment = New DevExpress.XtraReports.Parameters.Parameter()
			Me.EstimateFunctionComment = New DevExpress.XtraReports.Parameters.Parameter()
			Me.InvoiceComment = New DevExpress.XtraReports.Parameters.Parameter()
			CType(Me.XrTableComments, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.XrRichTextEstimateFunctionComment, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
			Me.XrSubreportFunctionDetails.ReportSource = New AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.FunctionDetailSubReport()
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
			Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreportFunctionDetails, Me.XrLabelEstimateCurrentAmount, Me.XrLabelPriorCurrentAmount, Me.XrLabelTTDCurrentAmount, Me.XrLabelFunctionDescription, Me.XrLabelCurrentAmount, Me.XrLabelIsTaxable})
			Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("FunctionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("FunctionDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
			Me.GroupHeader.HeightF = 34.0!
			Me.GroupHeader.Name = "GroupHeader"
			'
			'XrLabelEstimateCurrentAmount
			'
			Me.XrLabelEstimateCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateNetAmount")})
			Me.XrLabelEstimateCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(324.29!, 0!)
			Me.XrLabelEstimateCurrentAmount.Name = "XrLabelEstimateCurrentAmount"
			Me.XrLabelEstimateCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelEstimateCurrentAmount.StylePriority.UsePadding = False
			Me.XrLabelEstimateCurrentAmount.StylePriority.UseTextAlignment = False
			XrSummary1.FormatString = "{0:n2}"
			XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
			XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelEstimateCurrentAmount.Summary = XrSummary1
			Me.XrLabelEstimateCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabelPriorCurrentAmount
			'
			Me.XrLabelPriorCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PriorNetAmount")})
			Me.XrLabelPriorCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(433.86!, 0!)
			Me.XrLabelPriorCurrentAmount.Name = "XrLabelPriorCurrentAmount"
			Me.XrLabelPriorCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelPriorCurrentAmount.StylePriority.UsePadding = False
			Me.XrLabelPriorCurrentAmount.StylePriority.UseTextAlignment = False
			XrSummary2.FormatString = "{0:n2}"
			XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
			XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelPriorCurrentAmount.Summary = XrSummary2
			Me.XrLabelPriorCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabelTTDCurrentAmount
			'
			Me.XrLabelTTDCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TTDNetAmount")})
			Me.XrLabelTTDCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 0.00001589457!)
			Me.XrLabelTTDCurrentAmount.Name = "XrLabelTTDCurrentAmount"
			Me.XrLabelTTDCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelTTDCurrentAmount.StylePriority.UsePadding = False
			Me.XrLabelTTDCurrentAmount.StylePriority.UseTextAlignment = False
			XrSummary3.FormatString = "{0:n2}"
			XrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
			XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelTTDCurrentAmount.Summary = XrSummary3
			Me.XrLabelTTDCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabelFunctionDescription
			'
			Me.XrLabelFunctionDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionDescription")})
			Me.XrLabelFunctionDescription.LocationFloat = New DevExpress.Utils.PointFloat(37.99998!, 0!)
			Me.XrLabelFunctionDescription.Name = "XrLabelFunctionDescription"
			Me.XrLabelFunctionDescription.SizeF = New System.Drawing.SizeF(286.29!, 17.0!)
			Me.XrLabelFunctionDescription.StylePriority.UsePadding = False
			Me.XrLabelFunctionDescription.Text = "XrLabelFunctionDescription"
			'
			'XrLabelCurrentAmount
			'
			Me.XrLabelCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount")})
			Me.XrLabelCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.43!, 0!)
			Me.XrLabelCurrentAmount.Name = "XrLabelCurrentAmount"
			Me.XrLabelCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelCurrentAmount.StylePriority.UsePadding = False
			Me.XrLabelCurrentAmount.StylePriority.UseTextAlignment = False
			XrSummary4.FormatString = "{0:n2}"
			XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelCurrentAmount.Summary = XrSummary4
			Me.XrLabelCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabelIsTaxable
			'
			Me.XrLabelIsTaxable.LocationFloat = New DevExpress.Utils.PointFloat(744.1393!, 0!)
			Me.XrLabelIsTaxable.Name = "XrLabelIsTaxable"
			Me.XrLabelIsTaxable.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100.0!)
			Me.XrLabelIsTaxable.SizeF = New System.Drawing.SizeF(5.780579!, 17.00001!)
			Me.XrLabelIsTaxable.StylePriority.UsePadding = False
			Me.XrLabelIsTaxable.StylePriority.UseTextAlignment = False
			Me.XrLabelIsTaxable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
			'FormattingRuleFunctionTotals
			'
			Me.FormattingRuleFunctionTotals.Condition = "[Parameters.HideFunctionTotals] == True"
			'
			'
			'
			Me.FormattingRuleFunctionTotals.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
			Me.FormattingRuleFunctionTotals.Name = "FormattingRuleFunctionTotals"
			'
			'GroupHeaderInsideOutside
			'
			Me.GroupHeaderInsideOutside.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelPriorTotalAmountHeader, Me.XrLabelEstimateTotalAmountHeader, Me.XrLabelTTDTotalAmountHeader, Me.XrLabelTotalAmountHeader, Me.XrLabelFunctionType})
			Me.GroupHeaderInsideOutside.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("InsideOutsideFunctionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
			Me.GroupHeaderInsideOutside.HeightF = 17.00002!
			Me.GroupHeaderInsideOutside.Level = 1
			Me.GroupHeaderInsideOutside.Name = "GroupHeaderInsideOutside"
			'
			'XrLabelPriorTotalAmountHeader
			'
			Me.XrLabelPriorTotalAmountHeader.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PriorNetAmount")})
			Me.XrLabelPriorTotalAmountHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelPriorTotalAmountHeader.FormattingRules.Add(Me.FormattingRuleFunctionTotalsHeader)
			Me.XrLabelPriorTotalAmountHeader.LocationFloat = New DevExpress.Utils.PointFloat(433.86!, 0.00001589457!)
			Me.XrLabelPriorTotalAmountHeader.Name = "XrLabelPriorTotalAmountHeader"
			Me.XrLabelPriorTotalAmountHeader.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelPriorTotalAmountHeader.StylePriority.UseFont = False
			Me.XrLabelPriorTotalAmountHeader.StylePriority.UsePadding = False
			Me.XrLabelPriorTotalAmountHeader.StylePriority.UseTextAlignment = False
			XrSummary5.FormatString = "{0:n2}"
			XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelPriorTotalAmountHeader.Summary = XrSummary5
			Me.XrLabelPriorTotalAmountHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			Me.XrLabelPriorTotalAmountHeader.Visible = False
			'
			'FormattingRuleFunctionTotalsHeader
			'
			Me.FormattingRuleFunctionTotalsHeader.Condition = "[Parameters.HideFunctionTotals] == True"
			'
			'
			'
			Me.FormattingRuleFunctionTotalsHeader.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
			Me.FormattingRuleFunctionTotalsHeader.Name = "FormattingRuleFunctionTotalsHeader"
			'
			'XrLabelEstimateTotalAmountHeader
			'
			Me.XrLabelEstimateTotalAmountHeader.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateNetAmount")})
			Me.XrLabelEstimateTotalAmountHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelEstimateTotalAmountHeader.FormattingRules.Add(Me.FormattingRuleFunctionTotalsHeader)
			Me.XrLabelEstimateTotalAmountHeader.LocationFloat = New DevExpress.Utils.PointFloat(324.29!, 0.00001589457!)
			Me.XrLabelEstimateTotalAmountHeader.Name = "XrLabelEstimateTotalAmountHeader"
			Me.XrLabelEstimateTotalAmountHeader.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelEstimateTotalAmountHeader.StylePriority.UseFont = False
			Me.XrLabelEstimateTotalAmountHeader.StylePriority.UsePadding = False
			Me.XrLabelEstimateTotalAmountHeader.StylePriority.UseTextAlignment = False
			XrSummary6.FormatString = "{0:n2}"
			XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelEstimateTotalAmountHeader.Summary = XrSummary6
			Me.XrLabelEstimateTotalAmountHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			Me.XrLabelEstimateTotalAmountHeader.Visible = False
			'
			'XrLabelTTDTotalAmountHeader
			'
			Me.XrLabelTTDTotalAmountHeader.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TTDNetAmount", "{0:n2}")})
			Me.XrLabelTTDTotalAmountHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelTTDTotalAmountHeader.FormattingRules.Add(Me.FormattingRuleFunctionTotalsHeader)
			Me.XrLabelTTDTotalAmountHeader.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 0!)
			Me.XrLabelTTDTotalAmountHeader.Name = "XrLabelTTDTotalAmountHeader"
			Me.XrLabelTTDTotalAmountHeader.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelTTDTotalAmountHeader.StylePriority.UseFont = False
			Me.XrLabelTTDTotalAmountHeader.StylePriority.UsePadding = False
			Me.XrLabelTTDTotalAmountHeader.StylePriority.UseTextAlignment = False
			XrSummary7.FormatString = "{0:n2}"
			XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelTTDTotalAmountHeader.Summary = XrSummary7
			Me.XrLabelTTDTotalAmountHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			Me.XrLabelTTDTotalAmountHeader.Visible = False
			'
			'XrLabelTotalAmountHeader
			'
			Me.XrLabelTotalAmountHeader.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount", "{0:n2}")})
			Me.XrLabelTotalAmountHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelTotalAmountHeader.FormattingRules.Add(Me.FormattingRuleFunctionTotalsHeader)
			Me.XrLabelTotalAmountHeader.LocationFloat = New DevExpress.Utils.PointFloat(543.43!, 0!)
			Me.XrLabelTotalAmountHeader.Name = "XrLabelTotalAmountHeader"
			Me.XrLabelTotalAmountHeader.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelTotalAmountHeader.StylePriority.UseFont = False
			Me.XrLabelTotalAmountHeader.StylePriority.UsePadding = False
			Me.XrLabelTotalAmountHeader.StylePriority.UseTextAlignment = False
			XrSummary8.FormatString = "{0:n2}"
			XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelTotalAmountHeader.Summary = XrSummary8
			Me.XrLabelTotalAmountHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			Me.XrLabelTotalAmountHeader.Visible = False
			'
			'XrLabelFunctionType
			'
			Me.XrLabelFunctionType.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "InsideOutsideFunction")})
			Me.XrLabelFunctionType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
			Me.XrLabelFunctionType.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
			Me.XrLabelFunctionType.Name = "XrLabelFunctionType"
			Me.XrLabelFunctionType.SizeF = New System.Drawing.SizeF(324.29!, 17.0!)
			Me.XrLabelFunctionType.StylePriority.UseFont = False
			Me.XrLabelFunctionType.StylePriority.UsePadding = False
			'
			'HoursAndQuantity
			'
			Me.HoursAndQuantity.Expression = "Iif([FunctionType]='E', Iif([Parameters.ShowEmployeeHours],[Hours],NULL) ,Iif([Pa" &
	"rameters.ShowQuantity],[Quantity],NULL))"
			Me.HoursAndQuantity.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.HoursAndQuantity.Name = "HoursAndQuantity"
			'
			'GroupFooterInsideOutside
			'
			Me.GroupFooterInsideOutside.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelEstimateTotalAmount, Me.XrLabelPriorTotalAmount, Me.XrLineEstimateTotalAmount, Me.XrLinePriorTotalAmount, Me.XrLabelTTDTotalAmount, Me.XrLineTTDTotalAmount, Me.XrLabelTotalAmount, Me.XrLineTotalAmount})
			Me.GroupFooterInsideOutside.HeightF = 21.0!
			Me.GroupFooterInsideOutside.Level = 1
			Me.GroupFooterInsideOutside.Name = "GroupFooterInsideOutside"
			'
			'XrLabelEstimateTotalAmount
			'
			Me.XrLabelEstimateTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateNetAmount")})
			Me.XrLabelEstimateTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
			Me.XrLabelEstimateTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(324.29!, 2.000014!)
			Me.XrLabelEstimateTotalAmount.Name = "XrLabelEstimateTotalAmount"
			Me.XrLabelEstimateTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelEstimateTotalAmount.StylePriority.UsePadding = False
			Me.XrLabelEstimateTotalAmount.StylePriority.UseTextAlignment = False
			XrSummary9.FormatString = "{0:n2}"
			XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelEstimateTotalAmount.Summary = XrSummary9
			Me.XrLabelEstimateTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLabelPriorTotalAmount
			'
			Me.XrLabelPriorTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PriorNetAmount")})
			Me.XrLabelPriorTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
			Me.XrLabelPriorTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(433.86!, 2.0!)
			Me.XrLabelPriorTotalAmount.Name = "XrLabelPriorTotalAmount"
			Me.XrLabelPriorTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelPriorTotalAmount.StylePriority.UsePadding = False
			Me.XrLabelPriorTotalAmount.StylePriority.UseTextAlignment = False
			XrSummary10.FormatString = "{0:n2}"
			XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelPriorTotalAmount.Summary = XrSummary10
			Me.XrLabelPriorTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLineEstimateTotalAmount
			'
			Me.XrLineEstimateTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
			Me.XrLineEstimateTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(324.29!, 0.0000140667!)
			Me.XrLineEstimateTotalAmount.Name = "XrLineEstimateTotalAmount"
			Me.XrLineEstimateTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
			'
			'XrLinePriorTotalAmount
			'
			Me.XrLinePriorTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
			Me.XrLinePriorTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(433.86!, 0!)
			Me.XrLinePriorTotalAmount.Name = "XrLinePriorTotalAmount"
			Me.XrLinePriorTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
			'
			'XrLabelTTDTotalAmount
			'
			Me.XrLabelTTDTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TTDNetAmount", "{0:n2}")})
			Me.XrLabelTTDTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
			Me.XrLabelTTDTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 1.999982!)
			Me.XrLabelTTDTotalAmount.Name = "XrLabelTTDTotalAmount"
			Me.XrLabelTTDTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelTTDTotalAmount.StylePriority.UsePadding = False
			Me.XrLabelTTDTotalAmount.StylePriority.UseTextAlignment = False
			XrSummary11.FormatString = "{0:n2}"
			XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelTTDTotalAmount.Summary = XrSummary11
			Me.XrLabelTTDTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLineTTDTotalAmount
			'
			Me.XrLineTTDTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
			Me.XrLineTTDTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 0!)
			Me.XrLineTTDTotalAmount.Name = "XrLineTTDTotalAmount"
			Me.XrLineTTDTotalAmount.SizeF = New System.Drawing.SizeF(91.1394!, 2.0!)
			'
			'XrLabelTotalAmount
			'
			Me.XrLabelTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount", "{0:n2}")})
			Me.XrLabelTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
			Me.XrLabelTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.43!, 2.000014!)
			Me.XrLabelTotalAmount.Name = "XrLabelTotalAmount"
			Me.XrLabelTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
			Me.XrLabelTotalAmount.StylePriority.UsePadding = False
			Me.XrLabelTotalAmount.StylePriority.UseTextAlignment = False
			XrSummary12.FormatString = "{0:n2}"
			XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.XrLabelTotalAmount.Summary = XrSummary12
			Me.XrLabelTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'XrLineTotalAmount
			'
			Me.XrLineTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
			Me.XrLineTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.43!, 0!)
			Me.XrLineTotalAmount.Name = "XrLineTotalAmount"
			Me.XrLineTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
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
			Me.XrTableComments.SizeF = New System.Drawing.SizeF(249.2902!, 34.0!)
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
			Me.XrRichTextEstimateFunctionComment.SizeF = New System.Drawing.SizeF(249.2899!, 17.0!)
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
			Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.EstimatePriorCurrentTTDInvoiceDetail)
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
			'GroupByInsideOutsideFunctionSubReport
			'
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.GroupHeaderInsideOutside, Me.GroupFooterInsideOutside, Me.GroupFooter})
			Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.HoursAndQuantity, Me.InsideOutsideFunctionCode, Me.InsideOutsideFunction})
			Me.DataSource = Me.BindingSource
			Me.Font = New System.Drawing.Font("Arial", 9.0!)
			Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleShowInvoiceComment, Me.FormattingRuleBillingApprovalFunctionComment, Me.FormattingRuleEstimateFunctionComment, Me.FormattingRuleShowEmployeeFunctionDetails, Me.FormattingRuleShowVendorFunctionDetails, Me.FormattingRuleShowIncomeOnlyFunctionDetails, Me.FormattingRuleFunctionTotals, Me.FormattingRuleShowFunctionDetails, Me.FormattingRuleShowingFunctionDetails, Me.FormattingRuleFunctionTotalsHeader})
			Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 0)
			Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.InvoiceComment, Me.BillingApprovalFunctionComment, Me.EstimateFunctionComment, Me.ShowEmployeeFunctionDetails, Me.ShowIncomeOnlyFunctionDetails, Me.ShowVendorFunctionDetails, Me.ShowFunctionDetail, Me.HideFunctionTotals, Me.ShowQuantity, Me.ShowEmployeeHours})
			Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
			Me.Version = "14.2"
			CType(Me.XrTableComments, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.XrRichTextEstimateFunctionComment, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelFunctionDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents GroupHeaderInsideOutside As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelFunctionType As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterInsideOutside As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents HoursAndQuantity As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InsideOutsideFunctionCode As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents InsideOutsideFunction As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabelCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelTotalAmountHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ShowFunctionDetail As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents HideFunctionTotals As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowQuantity As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowEmployeeHours As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents FormattingRuleShowFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleShowingFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleFunctionTotals As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleFunctionTotalsHeader As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents XrSubreportFunctionDetails As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrLabelTTDTotalAmountHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTTDTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTTDCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineTTDTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelEstimateCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelPriorCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelPriorTotalAmountHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelEstimateTotalAmountHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelEstimateTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelPriorTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineEstimateTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLinePriorTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents FormattingRuleShowEmployeeFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleShowVendorFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRuleShowIncomeOnlyFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents ShowEmployeeFunctionDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowIncomeOnlyFunctionDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowVendorFunctionDetails As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLabelIsTaxable As DevExpress.XtraReports.UI.XRLabel
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
