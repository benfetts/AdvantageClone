Namespace Invoices.CurrentTTD

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class FunctionDetailSubReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabelRate = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleShowRate = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabelHoursAndQuantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleQuantityAndHours = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabelCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleFunctionTotals = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabelItemDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelItem = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.HoursAndQuantity = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ClientCode = New DevExpress.XtraReports.Parameters.Parameter()
            Me.InvoiceNumber = New DevExpress.XtraReports.Parameters.Parameter()
            Me.InvoiceSequenceNumber = New DevExpress.XtraReports.Parameters.Parameter()
            Me.InvoiceType = New DevExpress.XtraReports.Parameters.Parameter()
            Me.FunctionCodes = New DevExpress.XtraReports.Parameters.Parameter()
            Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLabelTTDTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.TTDTotalAmount = New DevExpress.XtraReports.Parameters.Parameter()
            Me.XrLineTTDTotalAmount = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTotalFunction = New DevExpress.XtraReports.UI.XRLabel()
            Me.FunctionDescription = New DevExpress.XtraReports.Parameters.Parameter()
            Me.XrLabelTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineTotalAmount = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineTotalHoursAndQuantity = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelTotalHoursAndQuantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.DivisionCode = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ProductCode = New DevExpress.XtraReports.Parameters.Parameter()
            Me.HideFunctionTotals = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowQuantity = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowEmployeeHours = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ShowRate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.JobNumber = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ComponentNumber = New DevExpress.XtraReports.Parameters.Parameter()
            Me.FunctionType = New DevExpress.XtraReports.Parameters.Parameter()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelComment = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Item", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ItemDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.StylePriority.UsePadding = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelRate
            '
            Me.XrLabelRate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Rate", "{0:#.00##}")})
            Me.XrLabelRate.LocationFloat = New DevExpress.Utils.PointFloat(374.43!, 0!)
            Me.XrLabelRate.Name = "XrLabelRate"
            Me.XrLabelRate.SizeF = New System.Drawing.SizeF(71.0!, 17.0!)
            Me.XrLabelRate.StylePriority.UsePadding = False
            Me.XrLabelRate.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            Me.XrLabelRate.Summary = XrSummary1
            Me.XrLabelRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.XrLabelRate.TextFormatString = "{0:n2}"
            '
            'FormattingRuleShowRate
            '
            Me.FormattingRuleShowRate.Condition = "[Parameters.ShowRate] == False"
            Me.FormattingRuleShowRate.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleShowRate.Name = "FormattingRuleShowRate"
            '
            'XrLabelHoursAndQuantity
            '
            Me.XrLabelHoursAndQuantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAndQuantity")})
            Me.XrLabelHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleQuantityAndHours)
            Me.XrLabelHoursAndQuantity.LocationFloat = New DevExpress.Utils.PointFloat(458.93!, 0!)
            Me.XrLabelHoursAndQuantity.Name = "XrLabelHoursAndQuantity"
            Me.XrLabelHoursAndQuantity.SizeF = New System.Drawing.SizeF(71.0!, 17.0!)
            Me.XrLabelHoursAndQuantity.StylePriority.UsePadding = False
            Me.XrLabelHoursAndQuantity.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelHoursAndQuantity.Summary = XrSummary2
            Me.XrLabelHoursAndQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FormattingRuleQuantityAndHours
            '
            Me.FormattingRuleQuantityAndHours.Condition = "[Parameters.ShowQuantity]=False And [Parameters.ShowEmployeeHours]=False"
            Me.FormattingRuleQuantityAndHours.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleQuantityAndHours.Name = "FormattingRuleQuantityAndHours"
            '
            'XrLabelCurrentAmount
            '
            Me.XrLabelCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount")})
            Me.XrLabelCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(541.5101!, 0!)
            Me.XrLabelCurrentAmount.Name = "XrLabelCurrentAmount"
            Me.XrLabelCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelCurrentAmount.StylePriority.UsePadding = False
            Me.XrLabelCurrentAmount.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelCurrentAmount.Summary = XrSummary3
            Me.XrLabelCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FormattingRuleFunctionTotals
            '
            Me.FormattingRuleFunctionTotals.Condition = "[Parameters.HideFunctionTotals] == True"
            Me.FormattingRuleFunctionTotals.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleFunctionTotals.Name = "FormattingRuleFunctionTotals"
            '
            'XrLabelItemDate
            '
            Me.XrLabelItemDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ItemDate", "{0:d}")})
            Me.XrLabelItemDate.LocationFloat = New DevExpress.Utils.PointFloat(274.0!, 0!)
            Me.XrLabelItemDate.Name = "XrLabelItemDate"
            Me.XrLabelItemDate.SizeF = New System.Drawing.SizeF(100.43!, 17.0!)
            Me.XrLabelItemDate.StylePriority.UsePadding = False
            Me.XrLabelItemDate.StylePriority.UseTextAlignment = False
            Me.XrLabelItemDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelItem
            '
            Me.XrLabelItem.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Item")})
            Me.XrLabelItem.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 0!)
            Me.XrLabelItem.Name = "XrLabelItem"
            Me.XrLabelItem.SizeF = New System.Drawing.SizeF(199.0!, 17.0!)
            Me.XrLabelItem.StylePriority.UsePadding = False
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
            'HoursAndQuantity
            '
            Me.HoursAndQuantity.Expression = "Iif([Parameters.FunctionType]='E', Iif([Parameters.ShowEmployeeHours],[Hours],0) " &
    ",Iif([Parameters.ShowQuantity],[Quantity],0))"
            Me.HoursAndQuantity.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.HoursAndQuantity.Name = "HoursAndQuantity"
            '
            'ClientCode
            '
            Me.ClientCode.Name = "ClientCode"
            Me.ClientCode.Visible = False
            '
            'InvoiceNumber
            '
            Me.InvoiceNumber.Name = "InvoiceNumber"
            Me.InvoiceNumber.Type = GetType(Integer)
            Me.InvoiceNumber.ValueInfo = "0"
            Me.InvoiceNumber.Visible = False
            '
            'InvoiceSequenceNumber
            '
            Me.InvoiceSequenceNumber.Name = "InvoiceSequenceNumber"
            Me.InvoiceSequenceNumber.Type = GetType(Short)
            Me.InvoiceSequenceNumber.ValueInfo = "0"
            Me.InvoiceSequenceNumber.Visible = False
            '
            'InvoiceType
            '
            Me.InvoiceType.Name = "InvoiceType"
            Me.InvoiceType.Visible = False
            '
            'FunctionCodes
            '
            Me.FunctionCodes.Name = "FunctionCodes"
            Me.FunctionCodes.Visible = False
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTTDTotalAmount, Me.XrLineTTDTotalAmount, Me.XrLabelTotal, Me.XrLabelTotalFunction, Me.XrLabelTotalAmount, Me.XrLineTotalAmount, Me.XrLineTotalHoursAndQuantity, Me.XrLabelTotalHoursAndQuantity})
            Me.GroupFooter.HeightF = 23.0!
            Me.GroupFooter.Name = "GroupFooter"
            '
            'XrLabelTTDTotalAmount
            '
            Me.XrLabelTTDTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.TTDTotalAmount, "Text", "")})
            Me.XrLabelTTDTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTTDTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 2.0!)
            Me.XrLabelTTDTotalAmount.Name = "XrLabelTTDTotalAmount"
            Me.XrLabelTTDTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTTDTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelTTDTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            Me.XrLabelTTDTotalAmount.Summary = XrSummary4
            Me.XrLabelTTDTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TTDTotalAmount
            '
            Me.TTDTotalAmount.Name = "TTDTotalAmount"
            Me.TTDTotalAmount.Type = GetType(Double)
            Me.TTDTotalAmount.ValueInfo = "0"
            Me.TTDTotalAmount.Visible = False
            '
            'XrLineTTDTotalAmount
            '
            Me.XrLineTTDTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineTTDTotalAmount.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLineTTDTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 0!)
            Me.XrLineTTDTotalAmount.Name = "XrLineTTDTotalAmount"
            Me.XrLineTTDTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLabelTotal
            '
            Me.XrLabelTotal.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTotal.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 2.0!)
            Me.XrLabelTotal.Name = "XrLabelTotal"
            Me.XrLabelTotal.SizeF = New System.Drawing.SizeF(32.29166!, 17.0!)
            Me.XrLabelTotal.StylePriority.UsePadding = False
            Me.XrLabelTotal.Text = "Total"
            '
            'XrLabelTotalFunction
            '
            Me.XrLabelTotalFunction.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.FunctionDescription, "Text", "")})
            Me.XrLabelTotalFunction.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTotalFunction.LocationFloat = New DevExpress.Utils.PointFloat(107.2917!, 1.999998!)
            Me.XrLabelTotalFunction.Name = "XrLabelTotalFunction"
            Me.XrLabelTotalFunction.SizeF = New System.Drawing.SizeF(351.6384!, 17.0!)
            Me.XrLabelTotalFunction.StylePriority.UsePadding = False
            '
            'FunctionDescription
            '
            Me.FunctionDescription.Name = "FunctionDescription"
            Me.FunctionDescription.Visible = False
            '
            'XrLabelTotalAmount
            '
            Me.XrLabelTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount")})
            Me.XrLabelTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(541.51!, 2.0!)
            Me.XrLabelTotalAmount.Name = "XrLabelTotalAmount"
            Me.XrLabelTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabelTotalAmount.Summary = XrSummary5
            Me.XrLabelTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineTotalAmount
            '
            Me.XrLineTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineTotalAmount.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLineTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(541.5101!, 0!)
            Me.XrLineTotalAmount.Name = "XrLineTotalAmount"
            Me.XrLineTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLineTotalHoursAndQuantity
            '
            Me.XrLineTotalHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineTotalHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleQuantityAndHours)
            Me.XrLineTotalHoursAndQuantity.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLineTotalHoursAndQuantity.LocationFloat = New DevExpress.Utils.PointFloat(458.93!, 0!)
            Me.XrLineTotalHoursAndQuantity.Name = "XrLineTotalHoursAndQuantity"
            Me.XrLineTotalHoursAndQuantity.SizeF = New System.Drawing.SizeF(71.0!, 2.0!)
            '
            'XrLabelTotalHoursAndQuantity
            '
            Me.XrLabelTotalHoursAndQuantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "HoursAndQuantity")})
            Me.XrLabelTotalHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTotalHoursAndQuantity.FormattingRules.Add(Me.FormattingRuleQuantityAndHours)
            Me.XrLabelTotalHoursAndQuantity.LocationFloat = New DevExpress.Utils.PointFloat(458.93!, 2.0!)
            Me.XrLabelTotalHoursAndQuantity.Name = "XrLabelTotalHoursAndQuantity"
            Me.XrLabelTotalHoursAndQuantity.SizeF = New System.Drawing.SizeF(71.0!, 17.0!)
            Me.XrLabelTotalHoursAndQuantity.StylePriority.UsePadding = False
            Me.XrLabelTotalHoursAndQuantity.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabelTotalHoursAndQuantity.Summary = XrSummary6
            Me.XrLabelTotalHoursAndQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'DivisionCode
            '
            Me.DivisionCode.Name = "DivisionCode"
            Me.DivisionCode.Visible = False
            '
            'ProductCode
            '
            Me.ProductCode.Name = "ProductCode"
            Me.ProductCode.Visible = False
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
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail)
            '
            'ShowRate
            '
            Me.ShowRate.Name = "ShowRate"
            Me.ShowRate.Type = GetType(Boolean)
            Me.ShowRate.ValueInfo = "False"
            Me.ShowRate.Visible = False
            '
            'JobNumber
            '
            Me.JobNumber.Name = "JobNumber"
            Me.JobNumber.Type = GetType(Integer)
            Me.JobNumber.ValueInfo = "0"
            Me.JobNumber.Visible = False
            '
            'ComponentNumber
            '
            Me.ComponentNumber.Name = "ComponentNumber"
            Me.ComponentNumber.Type = GetType(Short)
            Me.ComponentNumber.ValueInfo = "0"
            Me.ComponentNumber.Visible = False
            '
            'FunctionType
            '
            Me.FunctionType.Name = "FunctionType"
            Me.FunctionType.Visible = False
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelComment, Me.XrLabelItem, Me.XrLabelItemDate, Me.XrLabelCurrentAmount, Me.XrLabelHoursAndQuantity, Me.XrLabelRate})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Item", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ItemDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("Rate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("HoursAndQuantity", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("Comment", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 36.0!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrLabelComment
            '
            Me.XrLabelComment.CanShrink = True
            Me.XrLabelComment.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 18.0!)
            Me.XrLabelComment.Multiline = True
            Me.XrLabelComment.Name = "XrLabelComment"
            Me.XrLabelComment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrLabelComment.SizeF = New System.Drawing.SizeF(274.43!, 17.0!)
            Me.XrLabelComment.TextTrimming = System.Drawing.StringTrimming.None
            '
            'FunctionDetailSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupFooter, Me.GroupHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.HoursAndQuantity})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleQuantityAndHours, Me.FormattingRuleFunctionTotals, Me.FormattingRuleShowRate})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 0)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.FunctionType, Me.JobNumber, Me.ComponentNumber, Me.ClientCode, Me.DivisionCode, Me.ProductCode, Me.InvoiceNumber, Me.InvoiceSequenceNumber, Me.InvoiceType, Me.FunctionCodes, Me.HideFunctionTotals, Me.ShowQuantity, Me.ShowEmployeeHours, Me.TTDTotalAmount, Me.FunctionDescription, Me.ShowRate})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
		Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
		Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
		Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
		Friend WithEvents FormattingRuleQuantityAndHours As DevExpress.XtraReports.UI.FormattingRule
		Friend WithEvents HoursAndQuantity As DevExpress.XtraReports.UI.CalculatedField
		Friend WithEvents FormattingRuleFunctionTotals As DevExpress.XtraReports.UI.FormattingRule
		Friend WithEvents ClientCode As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents InvoiceNumber As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents InvoiceSequenceNumber As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents InvoiceType As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents FunctionCodes As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents XrLabelItem As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelItemDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabelTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLineTotalHoursAndQuantity As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelTotalHoursAndQuantity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DivisionCode As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ProductCode As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLabelHoursAndQuantity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTotalFunction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents HideFunctionTotals As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowQuantity As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowEmployeeHours As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents TTDTotalAmount As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLabelTTDTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineTTDTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents FunctionDescription As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLabelRate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FormattingRuleShowRate As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents ShowRate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents JobNumber As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ComponentNumber As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents FunctionType As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelComment As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
