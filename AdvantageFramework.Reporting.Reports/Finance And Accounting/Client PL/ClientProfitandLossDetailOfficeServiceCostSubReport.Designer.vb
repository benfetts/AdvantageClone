Namespace FinanceAndAccounting.ClientPL

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class ClientProfitandLossDetailOfficeServiceCostSubReport
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientProfitandLossDetailOfficeServiceCostSubReport))
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.BilledTotalCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DirectServiceCostCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.OfficeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.BilledCostOfSalesTotalCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.StartPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.OfficeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BilledCostOfSalesTotal = New DevExpress.XtraReports.UI.CalculatedField()
            Me.EndPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.TypeDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TotalGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.FunctionHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'label5
            '
            Me.label5.Dpi = 100.0!
            Me.label5.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(136.4583!, 23.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.Text = "Direct Service Cost"
            '
            'label4
            '
            Me.label4.CanShrink = True
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DirectServiceCostCurrent")})
            Me.label4.Dpi = 100.0!
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 0!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label4.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label4.Summary = XrSummary1
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label4.WordWrap = False
            '
            'Detail
            '
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BilledTotalCurrent
            '
            Me.BilledTotalCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[BilledTotal],0)"
            Me.BilledTotalCurrent.Name = "BilledTotalCurrent"
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label11
            '
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DirectServiceCost", "{0:n2}")})
            Me.label11.Dpi = 100.0!
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 3.000005!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label11.Summary = XrSummary2
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'DirectServiceCostCurrent
            '
            Me.DirectServiceCostCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[DirectServiceCost],0)"
            Me.DirectServiceCostCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.DirectServiceCostCurrent.Name = "DirectServiceCostCurrent"
            '
            'line2
            '
            Me.line2.Dpi = 100.0!
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 0!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
            '
            'OfficeFooter
            '
            Me.OfficeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label10, Me.label11, Me.label12, Me.label1, Me.label6, Me.line1, Me.line2})
            Me.OfficeFooter.Dpi = 100.0!
            Me.OfficeFooter.HeightF = 35.0!
            Me.OfficeFooter.Level = 1
            Me.OfficeFooter.Name = "OfficeFooter"
            '
            'label10
            '
            Me.label10.Dpi = 100.0!
            Me.label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(50.0!, 3.0!)
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(184.375!, 23.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.Text = "Total Direct Service Cost:"
            '
            'label12
            '
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DirectServiceCostCurrent")})
            Me.label12.Dpi = 100.0!
            Me.label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 3.000005!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary3
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label1
            '
            Me.label1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label1.Dpi = 100.0!
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(439.58!, 3.0!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.Scripts.OnSummaryGetResult = "OnSummaryGetResultCurrcDSCPctGI"
            Me.label1.Scripts.OnSummaryReset = "OnSummaryResetCurrcDSCPctGI"
            Me.label1.Scripts.OnSummaryRowChanged = "OnSummaryRowChangedCurrcDSCPctGI"
            Me.label1.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label1.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:0.00%}"
            XrSummary4.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label1.Summary = XrSummary4
            Me.label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label6.Dpi = 100.0!
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(641.67!, 3.0!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.Scripts.OnSummaryGetResult = "OnSummaryGetResultYTDcDSCPctGI"
            Me.label6.Scripts.OnSummaryReset = "OnSummaryResetYTDcDSCPctGI"
            Me.label6.Scripts.OnSummaryRowChanged = "OnSummaryRowChangedYTDcDSCPctGI"
            Me.label6.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label6.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:0.00%}"
            XrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label6.Summary = XrSummary5
            Me.label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line1
            '
            Me.line1.Dpi = 100.0!
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
            '
            'BilledCostOfSalesTotalCurrent
            '
            Me.BilledCostOfSalesTotalCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[BilledCostOfSales] + [GLCostOfSales] " &
    "+ [ManualCOS],0)"
            Me.BilledCostOfSalesTotalCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BilledCostOfSalesTotalCurrent.Name = "BilledCostOfSalesTotalCurrent"
            '
            'StartPeriod
            '
            Me.StartPeriod.Name = "StartPeriod"
            Me.StartPeriod.Visible = False
            '
            'OfficeHeader
            '
            Me.OfficeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label5, Me.label20})
            Me.OfficeHeader.Dpi = 100.0!
            Me.OfficeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OfficeHeader.HeightF = 23.0!
            Me.OfficeHeader.Level = 1
            Me.OfficeHeader.Name = "OfficeHeader"
            '
            'label20
            '
            Me.label20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OfficeCode")})
            Me.label20.Dpi = 100.0!
            Me.label20.ForeColor = System.Drawing.Color.SteelBlue
            Me.label20.LocationFloat = New DevExpress.Utils.PointFloat(143.75!, 0!)
            Me.label20.Name = "label20"
            Me.label20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label20.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label20.StylePriority.UseForeColor = False
            Me.label20.Text = "label20"
            Me.label20.Visible = False
            '
            'BilledCostOfSalesTotal
            '
            Me.BilledCostOfSalesTotal.Expression = "[BilledCostOfSales] + [GLCostOfSales] + [ManualCOS]"
            Me.BilledCostOfSalesTotal.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BilledCostOfSalesTotal.Name = "BilledCostOfSalesTotal"
            '
            'EndPeriod
            '
            Me.EndPeriod.Name = "EndPeriod"
            Me.EndPeriod.Visible = False
            '
            'TypeDescription
            '
            Me.TypeDescription.Expression = "IIf([Type]='G','General Ledger',IIf([Type]='M','Media',IIf([Type]='P','Production" &
    "','Other')))"
            Me.TypeDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.TypeDescription.Name = "TypeDescription"
            '
            'TopMargin
            '
            Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label16})
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 50.00001!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label16
            '
            Me.label16.Dpi = 100.0!
            Me.label16.ForeColor = System.Drawing.Color.SteelBlue
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(750.0!, 40.0!)
            Me.label16.StylePriority.UseForeColor = False
            Me.label16.StylePriority.UseTextAlignment = False
            Me.label16.Text = "Need to eliminate printing direct service cost by function where both current and" &
    " YTD sum of direct service cost amounts are $0.00."
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label16.Visible = False
            '
            'TotalGrossIncomeCurrent
            '
            Me.TotalGrossIncomeCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[TotalGrossIncome],0)"
            Me.TotalGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.TotalGrossIncomeCurrent.Name = "TotalGrossIncomeCurrent"
            '
            'label3
            '
            Me.label3.CanShrink = True
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DirectServiceCost", "{0:n2}")})
            Me.label3.Dpi = 100.0!
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 0!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label3.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label3.Summary = XrSummary6
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label3.WordWrap = False
            '
            'label2
            '
            Me.label2.CanShrink = True
            Me.label2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionDescription")})
            Me.label2.Dpi = 100.0!
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(293.75!, 23.0!)
            Me.label2.WordWrap = False
            '
            'FunctionHeader
            '
            Me.FunctionHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label2, Me.label3, Me.label4})
            Me.FunctionHeader.Dpi = 100.0!
            Me.FunctionHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.FunctionHeader.HeightF = 23.0!
            Me.FunctionHeader.Name = "FunctionHeader"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)
            '
            'ClientProfitandLossDetailOfficeServiceCostSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.FunctionHeader, Me.OfficeHeader, Me.OfficeFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.BilledCostOfSalesTotal, Me.BilledCostOfSalesTotalCurrent, Me.BilledTotalCurrent, Me.DirectServiceCostCurrent, Me.TotalGrossIncomeCurrent, Me.TypeDescription})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "01-Client PL Detail Report-3 Office Serv Cost Sub"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.StartPeriod, Me.EndPeriod})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.ScriptsSource = resources.GetString("$this.ScriptsSource")
            Me.Version = "16.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents BilledTotalCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DirectServiceCostCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents OfficeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents BilledCostOfSalesTotalCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents StartPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents OfficeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BilledCostOfSalesTotal As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents EndPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents TypeDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TotalGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents FunctionHeader As DevExpress.XtraReports.UI.GroupHeaderBand
    End Class

End Namespace
