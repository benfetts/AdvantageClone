Namespace FinanceAndAccounting.ClientPL

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class ClientProfitandLossDetailOfficeDirectExpensesSubReport
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientProfitandLossDetailOfficeDirectExpensesSubReport))
            Me.TypeDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.OfficeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DirectServiceCostCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.DirectExpenseTotal = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BilledCostOfSalesTotal = New DevExpress.XtraReports.UI.CalculatedField()
            Me.FunctionHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OfficeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EndPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.TotalGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.StartPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.DirectExpenseTotalCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BilledTotalCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BilledCostOfSalesTotalCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'TypeDescription
            '
            Me.TypeDescription.Expression = "IIf([Type]='G','General Ledger',IIf([Type]='M','Media',IIf([Type]='P','Production" &
    "','Other')))"
            Me.TypeDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.TypeDescription.Name = "TypeDescription"
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
            'label5
            '
            Me.label5.Dpi = 100.0!
            Me.label5.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(136.4583!, 23.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.Text = "Direct Expenses"
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
            'DirectServiceCostCurrent
            '
            Me.DirectServiceCostCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[DirectServiceCost],0)"
            Me.DirectServiceCostCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.DirectServiceCostCurrent.Name = "DirectServiceCostCurrent"
            '
            'DirectExpenseTotal
            '
            Me.DirectExpenseTotal.Expression = "[DirectExpense] + [GLDirectExpense] + [CRClientDirectExpense]"
            Me.DirectExpenseTotal.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.DirectExpenseTotal.Name = "DirectExpenseTotal"
            '
            'BilledCostOfSalesTotal
            '
            Me.BilledCostOfSalesTotal.Expression = "[BilledCostOfSales] + [GLCostOfSales] + [ManualCOS]"
            Me.BilledCostOfSalesTotal.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BilledCostOfSalesTotal.Name = "BilledCostOfSalesTotal"
            '
            'FunctionHeader
            '
            Me.FunctionHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label2, Me.label3, Me.label4})
            Me.FunctionHeader.Dpi = 100.0!
            Me.FunctionHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FunctionDescription", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.FunctionHeader.HeightF = 23.0!
            Me.FunctionHeader.Name = "FunctionHeader"
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
            'label3
            '
            Me.label3.CanShrink = True
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DirectExpenseTotal", "{0:n2}")})
            Me.label3.Dpi = 100.0!
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 0!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label3.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label3.Summary = XrSummary1
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label3.WordWrap = False
            '
            'label4
            '
            Me.label4.CanShrink = True
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DirectExpenseTotalCurrent")})
            Me.label4.Dpi = 100.0!
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 0!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label4.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label4.Summary = XrSummary2
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label4.WordWrap = False
            '
            'label12
            '
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DirectExpenseTotalCurrent")})
            Me.label12.Dpi = 100.0!
            Me.label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 3.0!)
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
            'label10
            '
            Me.label10.Dpi = 100.0!
            Me.label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(50.0!, 3.0!)
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(184.375!, 23.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.Text = "Total Direct Expenses:"
            '
            'OfficeFooter
            '
            Me.OfficeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label10, Me.label11, Me.label12, Me.label1, Me.label6, Me.line1, Me.line2})
            Me.OfficeFooter.Dpi = 100.0!
            Me.OfficeFooter.HeightF = 35.0!
            Me.OfficeFooter.Level = 1
            Me.OfficeFooter.Name = "OfficeFooter"
            '
            'label11
            '
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DirectExpenseTotal", "{0:n2}")})
            Me.label11.Dpi = 100.0!
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 3.0!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label11.Summary = XrSummary4
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label1
            '
            Me.label1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label1.Dpi = 100.0!
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(439.58!, 3.0!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.Scripts.OnSummaryGetResult = "OnSummaryGetResultCurrcDEPctGI"
            Me.label1.Scripts.OnSummaryReset = "OnSummaryResetCurrcDEPctGI"
            Me.label1.Scripts.OnSummaryRowChanged = "OnSummaryRowChangedCurrcDEPctGI"
            Me.label1.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label1.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:0.00%}"
            XrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label1.Summary = XrSummary5
            Me.label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label6.Dpi = 100.0!
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(641.67!, 3.0!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.Scripts.OnSummaryGetResult = "OnSummaryGetResultYTDcDEPctGI"
            Me.label6.Scripts.OnSummaryReset = "OnSummaryResetYTDcDEPctGI"
            Me.label6.Scripts.OnSummaryRowChanged = "OnSummaryRowChangedYTDcDEPctGI"
            Me.label6.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label6.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:0.00%}"
            XrSummary6.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label6.Summary = XrSummary6
            Me.label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line1
            '
            Me.line1.Dpi = 100.0!
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
            '
            'line2
            '
            Me.line2.Dpi = 100.0!
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 0!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
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
            Me.label16.Text = "Need to eliminate printing direct expense by function where both current and YTD " &
    "sum of direct expense total amounts are $0.00."
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label16.Visible = False
            '
            'EndPeriod
            '
            Me.EndPeriod.Name = "EndPeriod"
            Me.EndPeriod.Visible = False
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TotalGrossIncomeCurrent
            '
            Me.TotalGrossIncomeCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[TotalGrossIncome],0)"
            Me.TotalGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.TotalGrossIncomeCurrent.Name = "TotalGrossIncomeCurrent"
            '
            'StartPeriod
            '
            Me.StartPeriod.Name = "StartPeriod"
            Me.StartPeriod.Visible = False
            '
            'Detail
            '
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'DirectExpenseTotalCurrent
            '
            Me.DirectExpenseTotalCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[DirectExpense] + [GLDirectExpense] + " &
    "[CRClientDirectExpense],0)"
            Me.DirectExpenseTotalCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.DirectExpenseTotalCurrent.Name = "DirectExpenseTotalCurrent"
            '
            'BilledTotalCurrent
            '
            Me.BilledTotalCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[BilledTotal],0)"
            Me.BilledTotalCurrent.Name = "BilledTotalCurrent"
            '
            'BilledCostOfSalesTotalCurrent
            '
            Me.BilledCostOfSalesTotalCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[BilledCostOfSales] + [GLCostOfSales] " &
    "+ [ManualCOS],0)"
            Me.BilledCostOfSalesTotalCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BilledCostOfSalesTotalCurrent.Name = "BilledCostOfSalesTotalCurrent"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)
            '
            'ClientProfitandLossDetailOfficeDirectExpensesSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.FunctionHeader, Me.OfficeHeader, Me.OfficeFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.BilledTotalCurrent, Me.TypeDescription, Me.BilledCostOfSalesTotal, Me.BilledCostOfSalesTotalCurrent, Me.TotalGrossIncomeCurrent, Me.DirectServiceCostCurrent, Me.DirectExpenseTotal, Me.DirectExpenseTotalCurrent})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "01-Client PL Detail Report-4 Office Direct Exp Sub"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.StartPeriod, Me.EndPeriod})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.ScriptsSource = resources.GetString("$this.ScriptsSource")
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents TypeDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents OfficeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DirectServiceCostCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents DirectExpenseTotal As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BilledCostOfSalesTotal As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents FunctionHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OfficeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents EndPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents TotalGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents StartPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents DirectExpenseTotalCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BilledTotalCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BilledCostOfSalesTotalCurrent As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace
