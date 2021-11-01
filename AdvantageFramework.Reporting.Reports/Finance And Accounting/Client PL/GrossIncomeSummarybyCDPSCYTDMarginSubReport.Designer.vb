Namespace FinanceAndAccounting.ClientPL

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class GrossIncomeSummarybyCDPSCYTDMarginSubReport
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
            Me.SalesClassHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.TotalGrossIncomeBillPct = New DevExpress.XtraReports.UI.CalculatedField()
            Me.SalesClassFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label32 = New DevExpress.XtraReports.UI.XRLabel()
            Me.MarginPct = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRuleShowAllGroups = New DevExpress.XtraReports.UI.FormattingRule()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.TotalGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TGI = New DevExpress.XtraReports.UI.CalculatedField()
            Me.YTDMarginPct = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TNP2 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line8 = New DevExpress.XtraReports.UI.XRLine()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'SalesClassHeader
            '
            Me.SalesClassHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SalesClassDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.SalesClassHeader.HeightF = 0.0!
            Me.SalesClassHeader.Name = "SalesClassHeader"
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 0.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TotalGrossIncomeBillPct
            '
            Me.TotalGrossIncomeBillPct.Expression = "IIf(([TotalGrossIncome] <= 0 or [BilledTotal] = 0),0,[TotalGrossIncome] / [Billed" & _
        "Total])"
            Me.TotalGrossIncomeBillPct.FieldType = DevExpress.XtraReports.UI.FieldType.Float
            Me.TotalGrossIncomeBillPct.Name = "TotalGrossIncomeBillPct"
            '
            'SalesClassFooter
            '
            Me.SalesClassFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label6, Me.label32, Me.MarginPct})
            Me.SalesClassFooter.HeightF = 23.0!
            Me.SalesClassFooter.Name = "SalesClassFooter"
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(52.08!, 0.0!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(247.9166!, 23.0!)
            Me.label6.Text = "label6"
            '
            'label32
            '
            Me.label32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label32.LocationFloat = New DevExpress.Utils.PointFloat(547.916!, 0.0!)
            Me.label32.Name = "label32"
            Me.label32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label32.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label32.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label32.Summary = XrSummary1
            Me.label32.Text = "label32"
            Me.label32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'MarginPct
            '
            Me.MarginPct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.MarginPct.LocationFloat = New DevExpress.Utils.PointFloat(648.9579!, 0.0!)
            Me.MarginPct.Name = "MarginPct"
            Me.MarginPct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.MarginPct.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.MarginPct.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:0.00%}"
            XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.MarginPct.Summary = XrSummary2
            Me.MarginPct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'FormattingRuleShowAllGroups
            '
            Me.FormattingRuleShowAllGroups.Condition = "[DataSource.CurrentRowIndex] = [DataSource.RowCount] - 1"
            '
            '
            '
            Me.FormattingRuleShowAllGroups.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.FormattingRuleShowAllGroups.Name = "FormattingRuleShowAllGroups"
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TotalGrossIncomeCurrent
            '
            Me.TotalGrossIncomeCurrent.Expression = "Iif([PostingPeriod] =[Parameters.EndPeriod],[TotalGrossIncome]  ,0 )"
            Me.TotalGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.Float
            Me.TotalGrossIncomeCurrent.Name = "TotalGrossIncomeCurrent"
            '
            'Detail
            '
            Me.Detail.HeightF = 0.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TGI
            '
            Me.TGI.Expression = "IIf([].Sum([TotalGrossIncome]) = 0, 0, [].Sum([TotalIncome]) / [].Sum([TotalGross" & _
        "Income]))"
            Me.TGI.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.TGI.Name = "TGI"
            '
            'YTDMarginPct
            '
            Me.YTDMarginPct.Expression = "IIf([].Sum([BilledTotal]) = 0, 0, [].Sum([TotalGrossIncome]) / [].Sum([BilledTota" & _
        "l]))"
            Me.YTDMarginPct.Name = "YTDMarginPct"
            '
            'TNP2
            '
            Me.TNP2.Expression = "IIf([].Sum([BilledTotal]) = 0, 0, [].Sum([IncomeLessOverhead]) / [].Sum([BilledTo" & _
        "tal]))"
            Me.TNP2.Name = "TNP2"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.ClientPL)
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line8, Me.XrLabel1})
            Me.ReportHeader.HeightF = 46.70833!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.label19, Me.label18})
            Me.ReportFooter.HeightF = 23.0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'XrLabel1
            '
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 22.91667!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(247.9166!, 23.0!)
            Me.XrLabel1.Text = "Group Totals"
            '
            'XrLabel3
            '
            Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "YTDMarginPct", "{0:0.00%}")})
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(648.9579!, 0.0!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:0.00%}"
            XrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            Me.XrLabel3.Summary = XrSummary3
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'label19
            '
            Me.label19.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(297.9162!, 0.0!)
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(215.625!, 23.0!)
            Me.label19.StylePriority.UseFont = False
            Me.label19.StylePriority.UseTextAlignment = False
            Me.label19.Text = "Group Totals:"
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'label18
            '
            Me.label18.CanGrow = False
            Me.label18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(547.916!, 0.0!)
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label18.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label18.Summary = XrSummary4
            Me.label18.Text = "label18"
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            '
            'line8
            '
            Me.line8.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Me.line8.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.line8.Name = "line8"
            Me.line8.SizeF = New System.Drawing.SizeF(750.0!, 12.5!)
            '
            'GrossIncomeSummarybyCDPSCYTDMarginSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.SalesClassHeader, Me.SalesClassFooter, Me.ReportHeader, Me.ReportFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.TGI, Me.YTDMarginPct, Me.TNP2, Me.TotalGrossIncomeCurrent, Me.TotalGrossIncomeBillPct})
            Me.ComponentStorage.Add(Me.BindingSource)
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "16-Gross Income Summary by CDP-SC (YTD-Margin%)"
            Me.FilterString = "[TotalGrossIncome] <> 0.00m"
            Me.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRuleShowAllGroups})
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.PageWidth = 750
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents SalesClassHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents TotalGrossIncomeBillPct As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents SalesClassFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label32 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents TotalGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TGI As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents YTDMarginPct As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TNP2 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents MarginPct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FormattingRuleShowAllGroups As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line8 As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
