Namespace Invoices.NetCommissionTaxCurrent

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
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleFunctionTotals = New DevExpress.XtraReports.UI.FormattingRule()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTaxCurrentAmount = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.XrLabelNetTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineNetTotalAmount = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelCurrentTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineCurrentTotalTotalAmount = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelTax = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTaxFunction = New DevExpress.XtraReports.UI.XRLabel()
            Me.FunctionDescription = New DevExpress.XtraReports.Parameters.Parameter()
            Me.XrLabelTaxAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLineTaxAmount = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLineCommissionTotalAmount = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelCommissionTotalAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.DivisionCode = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ProductCode = New DevExpress.XtraReports.Parameters.Parameter()
            Me.HideFunctionTotals = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowQuantity = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ShowEmployeeHours = New DevExpress.XtraReports.Parameters.Parameter()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount")})
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(326.4606!, 0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabel3.StylePriority.UsePadding = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel3.Summary = XrSummary1
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FormattingRuleFunctionTotals
            '
            Me.FormattingRuleFunctionTotals.Condition = "[Parameters.HideFunctionTotals] == True"
            Me.FormattingRuleFunctionTotals.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRuleFunctionTotals.Name = "FormattingRuleFunctionTotals"
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CommissionAmount")})
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(433.78!, 0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabel2.StylePriority.UsePadding = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel2.Summary = XrSummary2
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabel1.StylePriority.UsePadding = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabel1.Summary = XrSummary3
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelTaxCurrentAmount
            '
            Me.XrLabelTaxCurrentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalTax")})
            Me.XrLabelTaxCurrentAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.43!, 0!)
            Me.XrLabelTaxCurrentAmount.Name = "XrLabelTaxCurrentAmount"
            Me.XrLabelTaxCurrentAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTaxCurrentAmount.StylePriority.UsePadding = False
            Me.XrLabelTaxCurrentAmount.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTaxCurrentAmount.Summary = XrSummary4
            Me.XrLabelTaxCurrentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelItemDate
            '
            Me.XrLabelItemDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ItemDate", "{0:d}")})
            Me.XrLabelItemDate.LocationFloat = New DevExpress.Utils.PointFloat(261.8766!, 0!)
            Me.XrLabelItemDate.Name = "XrLabelItemDate"
            Me.XrLabelItemDate.SizeF = New System.Drawing.SizeF(64.58334!, 17.0!)
            Me.XrLabelItemDate.StylePriority.UsePadding = False
            Me.XrLabelItemDate.StylePriority.UseTextAlignment = False
            Me.XrLabelItemDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelItem
            '
            Me.XrLabelItem.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Item")})
            Me.XrLabelItem.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 0!)
            Me.XrLabelItem.Name = "XrLabelItem"
            Me.XrLabelItem.SizeF = New System.Drawing.SizeF(186.8766!, 17.0!)
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
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelNetTotalAmount, Me.XrLineNetTotalAmount, Me.XrLabelCurrentTotalAmount, Me.XrLineCurrentTotalTotalAmount, Me.XrLabelTax, Me.XrLabelTaxFunction, Me.XrLabelTaxAmount, Me.XrLineTaxAmount, Me.XrLineCommissionTotalAmount, Me.XrLabelCommissionTotalAmount})
            Me.GroupFooter.HeightF = 23.0!
            Me.GroupFooter.Name = "GroupFooter"
            '
            'XrLabelNetTotalAmount
            '
            Me.XrLabelNetTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NetAmount")})
            Me.XrLabelNetTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelNetTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(326.46!, 1.999998!)
            Me.XrLabelNetTotalAmount.Name = "XrLabelNetTotalAmount"
            Me.XrLabelNetTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 17.0!)
            Me.XrLabelNetTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelNetTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabelNetTotalAmount.Summary = XrSummary5
            Me.XrLabelNetTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineNetTotalAmount
            '
            Me.XrLineNetTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineNetTotalAmount.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLineNetTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(326.46!, 0!)
            Me.XrLineNetTotalAmount.Name = "XrLineNetTotalAmount"
            Me.XrLineNetTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLabelCurrentTotalAmount
            '
            Me.XrLabelCurrentTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.XrLabelCurrentTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelCurrentTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 2.0!)
            Me.XrLabelCurrentTotalAmount.Name = "XrLabelCurrentTotalAmount"
            Me.XrLabelCurrentTotalAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelCurrentTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelCurrentTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabelCurrentTotalAmount.Summary = XrSummary6
            Me.XrLabelCurrentTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineCurrentTotalTotalAmount
            '
            Me.XrLineCurrentTotalTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineCurrentTotalTotalAmount.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLineCurrentTotalTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(653.0!, 0!)
            Me.XrLineCurrentTotalTotalAmount.Name = "XrLineCurrentTotalTotalAmount"
            Me.XrLineCurrentTotalTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLabelTax
            '
            Me.XrLabelTax.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTax.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 2.0!)
            Me.XrLabelTax.Name = "XrLabelTax"
            Me.XrLabelTax.SizeF = New System.Drawing.SizeF(32.29166!, 17.0!)
            Me.XrLabelTax.StylePriority.UsePadding = False
            Me.XrLabelTax.Text = "Total"
            '
            'XrLabelTaxFunction
            '
            Me.XrLabelTaxFunction.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.FunctionDescription, "Text", "")})
            Me.XrLabelTaxFunction.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTaxFunction.LocationFloat = New DevExpress.Utils.PointFloat(107.2917!, 1.999998!)
            Me.XrLabelTaxFunction.Name = "XrLabelTaxFunction"
            Me.XrLabelTaxFunction.SizeF = New System.Drawing.SizeF(219.1683!, 17.0!)
            Me.XrLabelTaxFunction.StylePriority.UsePadding = False
            '
            'FunctionDescription
            '
            Me.FunctionDescription.Name = "FunctionDescription"
            Me.FunctionDescription.Visible = False
            '
            'XrLabelTaxAmount
            '
            Me.XrLabelTaxAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalTax")})
            Me.XrLabelTaxAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelTaxAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.43!, 2.0!)
            Me.XrLabelTaxAmount.Name = "XrLabelTaxAmount"
            Me.XrLabelTaxAmount.SizeF = New System.Drawing.SizeF(91.13934!, 17.0!)
            Me.XrLabelTaxAmount.StylePriority.UsePadding = False
            Me.XrLabelTaxAmount.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabelTaxAmount.Summary = XrSummary7
            Me.XrLabelTaxAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLineTaxAmount
            '
            Me.XrLineTaxAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineTaxAmount.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLineTaxAmount.LocationFloat = New DevExpress.Utils.PointFloat(543.43!, 0!)
            Me.XrLineTaxAmount.Name = "XrLineTaxAmount"
            Me.XrLineTaxAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLineCommissionTotalAmount
            '
            Me.XrLineCommissionTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLineCommissionTotalAmount.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.XrLineCommissionTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(433.78!, 0!)
            Me.XrLineCommissionTotalAmount.Name = "XrLineCommissionTotalAmount"
            Me.XrLineCommissionTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 2.0!)
            '
            'XrLabelCommissionTotalAmount
            '
            Me.XrLabelCommissionTotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CommissionAmount")})
            Me.XrLabelCommissionTotalAmount.FormattingRules.Add(Me.FormattingRuleFunctionTotals)
            Me.XrLabelCommissionTotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(433.78!, 1.999998!)
            Me.XrLabelCommissionTotalAmount.Name = "XrLabelCommissionTotalAmount"
            Me.XrLabelCommissionTotalAmount.SizeF = New System.Drawing.SizeF(91.14!, 17.0!)
            Me.XrLabelCommissionTotalAmount.StylePriority.UsePadding = False
            Me.XrLabelCommissionTotalAmount.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.XrLabelCommissionTotalAmount.Summary = XrSummary8
            Me.XrLabelCommissionTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            'XrControlStyle1
            '
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail)
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
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelComment, Me.XrLabelItem, Me.XrLabelItemDate, Me.XrLabelTaxCurrentAmount, Me.XrLabel1, Me.XrLabel2, Me.XrLabel3})
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
            Me.XrLabelComment.SizeF = New System.Drawing.SizeF(226.46!, 17.0!)
            Me.XrLabelComment.TextTrimming = System.Drawing.StringTrimming.None
            '
            'FunctionDetailSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupFooter, Me.GroupHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.HoursAndQuantity})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleFunctionTotals})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 0)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.FunctionType, Me.JobNumber, Me.ComponentNumber, Me.ClientCode, Me.DivisionCode, Me.ProductCode, Me.InvoiceNumber, Me.InvoiceSequenceNumber, Me.InvoiceType, Me.FunctionCodes, Me.HideFunctionTotals, Me.ShowQuantity, Me.ShowEmployeeHours, Me.FunctionDescription})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
		Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
		Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
		Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
		Friend WithEvents HoursAndQuantity As DevExpress.XtraReports.UI.CalculatedField
		Friend WithEvents FormattingRuleFunctionTotals As DevExpress.XtraReports.UI.FormattingRule
		Friend WithEvents ClientCode As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents InvoiceNumber As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents InvoiceSequenceNumber As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents InvoiceType As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents FunctionCodes As DevExpress.XtraReports.Parameters.Parameter
		Friend WithEvents XrLabelItem As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelItemDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTaxAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLabelTaxCurrentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineTaxAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLineCommissionTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelCommissionTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DivisionCode As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ProductCode As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLabelTax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelTaxFunction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents HideFunctionTotals As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowQuantity As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ShowEmployeeHours As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrLabelCurrentTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineCurrentTotalTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents FunctionDescription As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents XrLabelNetTotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLineNetTotalAmount As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents JobNumber As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ComponentNumber As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents FunctionType As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelComment As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
