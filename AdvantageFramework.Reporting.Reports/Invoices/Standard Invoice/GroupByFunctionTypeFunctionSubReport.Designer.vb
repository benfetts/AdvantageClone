Namespace Invoices.StandardInvoice

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Public Class GroupByFunctionTypeFunctionSubReport
		Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GroupByFunctionTypeFunctionSubReport))
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrSubreportFunctionDetails = New DevExpress.XtraReports.UI.XRSubreport()
            Me.FormattingRuleBillingApprovalFunctionComment = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleShowFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleFunctionTotals = New DevExpress.XtraReports.UI.FormattingRule()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelIsTaxable = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelQuantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelFunctionDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleQuantityAndHours = New DevExpress.XtraReports.UI.FormattingRule()
            Me.FormattingRuleShowingFunctionDetails = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupHeaderFunctionType = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelTotalAmountHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleFunctionTotalsHeader = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabelTotalHoursAndQuantityHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelFunctionType = New DevExpress.XtraReports.UI.XRLabel()
            Me.FunctionTypeDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.HoursAndQuantity = New DevExpress.XtraReports.UI.CalculatedField()
            Me.GroupFooterFunctionType = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabelTotalHoursAndQuantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineTotalHoursAndQuantity = New DevExpress.XtraReports.UI.XRLine()
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
            Me.XrSubreportFunctionDetails.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 17.00001!)
            Me.XrSubreportFunctionDetails.Name = "XrSubreportFunctionDetails"
            Me.XrSubreportFunctionDetails.ReportSource = New AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.FunctionDetailSubReport()
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
            'FormattingRuleFunctionTotals
            '
            Me.FormattingRuleFunctionTotals.Condition = "[Parameters.HideFunctionTotals] == True"
            '
            '
            '
            Me.FormattingRuleFunctionTotals.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleFunctionTotals.Name = "FormattingRuleFunctionTotals"
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
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreportFunctionDetails, Me.XrLabelIsTaxable, Me.XrLabelQuantity, Me.XrLabelFunctionDescription, Me.XrLabelCurrentAmount})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("FunctionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("FunctionDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 34.00001!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrLabelIsTaxable
            '
            Me.XrLabelIsTaxable.LocationFloat = New DevExpress.Utils.PointFloat(744.2195!, 0!)
            Me.XrLabelIsTaxable.Name = "XrLabelIsTaxable"
            Me.XrLabelIsTaxable.Padding = New DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100.0!)
            Me.XrLabelIsTaxable.SizeF = New System.Drawing.SizeF(5.780579!, 17.00001!)
            Me.XrLabelIsTaxable.StylePriority.UsePadding = False
            Me.XrLabelIsTaxable.StylePriority.UseTextAlignment = False
            Me.XrLabelIsTaxable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelQuantity
            '
            Me.XrLabelQuantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAndQuantity")})
            Me.XrLabelQuantity.LocationFloat = New DevExpress.Utils.PointFloat(570.5!, 0!)
            Me.XrLabelQuantity.Name = "XrLabelQuantity"
            Me.XrLabelQuantity.SizeF = New System.Drawing.SizeF(71.0!, 17.0!)
            Me.XrLabelQuantity.StylePriority.UsePadding = False
            Me.XrLabelQuantity.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelQuantity.Summary = XrSummary1
            Me.XrLabelQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelFunctionDescription
            '
            Me.XrLabelFunctionDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionDescription")})
            Me.XrLabelFunctionDescription.LocationFloat = New DevExpress.Utils.PointFloat(37.99998!, 0!)
            Me.XrLabelFunctionDescription.Name = "XrLabelFunctionDescription"
            Me.XrLabelFunctionDescription.SizeF = New System.Drawing.SizeF(532.5!, 17.0!)
            Me.XrLabelFunctionDescription.StylePriority.UsePadding = False
            Me.XrLabelFunctionDescription.Text = "XrLabelFunctionDescription"
            '
            'XrLabelCurrentAmount
            '
            Me.XrLabelCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount")})
            Me.XrLabelCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.08!, 0!)
            Me.XrLabelCurrentAmount.Name = "XrLabelCurrentAmount"
            Me.XrLabelCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelCurrentAmount.StylePriority.UsePadding = False
            Me.XrLabelCurrentAmount.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelCurrentAmount.Summary = XrSummary2
            Me.XrLabelCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FormattingRuleQuantityAndHours
            '
            Me.FormattingRuleQuantityAndHours.Condition = "[Parameters.ShowQuantity]=False And [Parameters.ShowEmployeeHours]=False"
            '
            '
            '
            Me.FormattingRuleQuantityAndHours.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleQuantityAndHours.Name = "FormattingRuleQuantityAndHours"
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
            'GroupHeaderFunctionType
            '
            Me.GroupHeaderFunctionType.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTotalAmountHeader, Me.XrLabelTotalHoursAndQuantityHeader, Me.XrLabelFunctionType})
            Me.GroupHeaderFunctionType.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionType", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderFunctionType.HeightF = 17.00002!
            Me.GroupHeaderFunctionType.Level = 1
            Me.GroupHeaderFunctionType.Name = "GroupHeaderFunctionType"
            '
            'XrLabelTotalAmountHeader
            '
            Me.XrLabelTotalAmountHeader.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount", "{0:n2}")})
            Me.XrLabelTotalAmountHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalAmountHeader.FormattingRules.Add(Me.FormattingRuleFunctionTotalsHeader)
            Me.XrLabelTotalAmountHeader.LocationFloat = New DevExpress.Utils.PointFloat(653.08!, 0!)
            Me.XrLabelTotalAmountHeader.Name = "XrLabelTotalAmountHeader"
            Me.XrLabelTotalAmountHeader.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTotalAmountHeader.StylePriority.UseFont = False
            Me.XrLabelTotalAmountHeader.StylePriority.UsePadding = False
            Me.XrLabelTotalAmountHeader.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTotalAmountHeader.Summary = XrSummary3
            Me.XrLabelTotalAmountHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelTotalAmountHeader.Visible = False
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
            'XrLabelTotalHoursAndQuantityHeader
            '
            Me.XrLabelTotalHoursAndQuantityHeader.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAndQuantity")})
            Me.XrLabelTotalHoursAndQuantityHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTotalHoursAndQuantityHeader.FormattingRules.Add(Me.FormattingRuleFunctionTotalsHeader)
            Me.XrLabelTotalHoursAndQuantityHeader.FormattingRules.Add(Me.FormattingRuleQuantityAndHours)
            Me.XrLabelTotalHoursAndQuantityHeader.LocationFloat = New DevExpress.Utils.PointFloat(570.5001!, 0!)
            Me.XrLabelTotalHoursAndQuantityHeader.Name = "XrLabelTotalHoursAndQuantityHeader"
            Me.XrLabelTotalHoursAndQuantityHeader.SizeF = New System.Drawing.SizeF(71.0!, 17.0!)
            Me.XrLabelTotalHoursAndQuantityHeader.StylePriority.UseFont = False
            Me.XrLabelTotalHoursAndQuantityHeader.StylePriority.UsePadding = False
            Me.XrLabelTotalHoursAndQuantityHeader.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTotalHoursAndQuantityHeader.Summary = XrSummary4
            Me.XrLabelTotalHoursAndQuantityHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelTotalHoursAndQuantityHeader.Visible = False
            '
            'XrLabelFunctionType
            '
            Me.XrLabelFunctionType.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionTypeDescription")})
            Me.XrLabelFunctionType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelFunctionType.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabelFunctionType.Name = "XrLabelFunctionType"
            Me.XrLabelFunctionType.SizeF = New System.Drawing.SizeF(570.5001!, 17.0!)
            Me.XrLabelFunctionType.StylePriority.UseFont = False
            Me.XrLabelFunctionType.StylePriority.UsePadding = False
            '
            'FunctionTypeDescription
            '
            Me.FunctionTypeDescription.Expression = "Iif([FunctionType] = 'E', 'Employee Time' , Iif([FunctionType] = 'I', 'Income Onl" &
    "y' , 'Vendor') )"
            Me.FunctionTypeDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.FunctionTypeDescription.Name = "FunctionTypeDescription"
            '
            'HoursAndQuantity
            '
            Me.HoursAndQuantity.Expression = "Iif([FunctionType]='E', Iif([Parameters.ShowEmployeeHours],[Hours],NULL) ,Iif([Pa" &
    "rameters.ShowQuantity],[Quantity],NULL))"
            Me.HoursAndQuantity.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.HoursAndQuantity.Name = "HoursAndQuantity"
            '
            'GroupFooterFunctionType
            '
            Me.GroupFooterFunctionType.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTotalHoursAndQuantity, Me.XrLabelTotalAmount, Me.XrLineTotalHoursAndQuantity, Me.XrLineTotalAmount})
            Me.GroupFooterFunctionType.HeightF = 21.0!
            Me.GroupFooterFunctionType.Level = 1
            Me.GroupFooterFunctionType.Name = "GroupFooterFunctionType"
            '
            'XrLabelTotalHoursAndQuantity
            '
            Me.XrLabelTotalHoursAndQuantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAndQuantity")})
            Me.XrLabelTotalHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTotalHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleQuantityAndHours)
            Me.XrLabelTotalHoursAndQuantity.LocationFloat = New DevExpress.Utils.PointFloat(570.4999!, 2.083333!)
            Me.XrLabelTotalHoursAndQuantity.Name = "XrLabelTotalHoursAndQuantity"
            Me.XrLabelTotalHoursAndQuantity.SizeF = New System.Drawing.SizeF(71.0!, 17.0!)
            Me.XrLabelTotalHoursAndQuantity.StylePriority.UsePadding = False
            Me.XrLabelTotalHoursAndQuantity.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTotalHoursAndQuantity.Summary = XrSummary5
            Me.XrLabelTotalHoursAndQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelTotalAmount
            '
            Me.XrLabelTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount", "{0:n2}")})
            Me.XrLabelTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.08!, 2.083333!)
            Me.XrLabelTotalAmount.Name = "XrLabelTotalAmount"
            Me.XrLabelTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTotalAmount.Summary = XrSummary6
            Me.XrLabelTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineTotalHoursAndQuantity
            '
            Me.XrLineTotalHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineTotalHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleQuantityAndHours)
            Me.XrLineTotalHoursAndQuantity.LocationFloat = New DevExpress.Utils.PointFloat(570.4999!, 0!)
            Me.XrLineTotalHoursAndQuantity.Name = "XrLineTotalHoursAndQuantity"
            Me.XrLineTotalHoursAndQuantity.SizeF = New System.Drawing.SizeF(71.00006!, 2.083333!)
            '
            'XrLineTotalAmount
            '
            Me.XrLineTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0801!, 0!)
            Me.XrLineTotalAmount.Name = "XrLineTotalAmount"
            Me.XrLineTotalAmount.SizeF = New System.Drawing.SizeF(91.1394!, 2.083333!)
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableComments, Me.XrRichTextEstimateFunctionComment})
            Me.GroupFooter.HeightF = 51.00002!
            Me.GroupFooter.Name = "GroupFooter"
            '
            'XrTableComments
            '
            Me.XrTableComments.LocationFloat = New DevExpress.Utils.PointFloat(74.99994!, 0!)
            Me.XrTableComments.Name = "XrTableComments"
            Me.XrTableComments.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowBillingApprovalFunctionComment, Me.XrTableRowBillingDetailComment})
            Me.XrTableComments.SizeF = New System.Drawing.SizeF(495.5002!, 34.0!)
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
            Me.XrRichTextEstimateFunctionComment.SizeF = New System.Drawing.SizeF(495.4999!, 17.0!)
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
            'GroupByFunctionTypeFunctionSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.GroupHeaderFunctionType, Me.GroupFooterFunctionType, Me.GroupFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.HoursAndQuantity, Me.FunctionTypeDescription})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleShowInvoiceComment, Me.FormattingRuleBillingApprovalFunctionComment, Me.FormattingRuleEstimateFunctionComment, Me.FormattingRuleShowEmployeeFunctionDetails, Me.FormattingRuleShowVendorFunctionDetails, Me.FormattingRuleShowIncomeOnlyFunctionDetails, Me.FormattingRuleQuantityAndHours, Me.FormattingRuleFunctionTotals, Me.FormattingRuleShowFunctionDetails, Me.FormattingRuleShowingFunctionDetails, Me.FormattingRuleFunctionTotalsHeader})
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
		Friend WithEvents XrLabelQuantity As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLabelFunctionDescription As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLabelCurrentAmount As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
		Friend WithEvents GroupHeaderFunctionType As DevExpress.XtraReports.UI.GroupHeaderBand
		Friend WithEvents XrLabelFunctionType As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents FunctionTypeDescription As DevExpress.XtraReports.UI.CalculatedField
		Friend WithEvents GroupFooterFunctionType As DevExpress.XtraReports.UI.GroupFooterBand
		Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
		Friend WithEvents HoursAndQuantity As DevExpress.XtraReports.UI.CalculatedField
		Friend WithEvents XrLabelTotalHoursAndQuantity As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLabelTotalAmount As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLineTotalHoursAndQuantity As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLineTotalAmount As DevExpress.XtraReports.UI.XRLine
		Friend WithEvents XrLabelTotalAmountHeader As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrLabelTotalHoursAndQuantityHeader As DevExpress.XtraReports.UI.XRLabel
		Friend WithEvents XrSubreportFunctionDetails As DevExpress.XtraReports.UI.XRSubreport
		Friend WithEvents ShowFunctionDetail As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents HideFunctionTotals As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents ShowQuantity As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents ShowEmployeeHours As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents FormattingRuleShowFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
		Friend WithEvents FormattingRuleShowingFunctionDetails As DevExpress.XtraReports.UI.FormattingRule
		Friend WithEvents FormattingRuleFunctionTotals As DevExpress.XtraReports.UI.FormattingRule
		Friend WithEvents FormattingRuleQuantityAndHours As DevExpress.XtraReports.UI.FormattingRule
		Friend WithEvents FormattingRuleFunctionTotalsHeader As DevExpress.XtraReports.UI.FormattingRule
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
