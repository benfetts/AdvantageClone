Namespace FinanceAndAccounting.ClientPL

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport
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
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BudgetVarianceGrossIncomeCurrentReverseSign = New DevExpress.XtraReports.UI.CalculatedField()
            Me.OfficeLabel = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BudgetVarianceGrossIncomeReverseSign = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BudgetVarianceGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label27 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EndPeriodYear = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.StartPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.SalesClassHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivProdCodes = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.PostPeriodYear = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.OfficeLabelFooter = New DevExpress.XtraReports.UI.CalculatedField()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EndPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.BudgetGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TotalGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label36 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'label12
            '
            Me.label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(238.5417!, 9.499995!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(136.4567!, 18.00001!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            Me.label12.Text = "Group Totals:"
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BudgetVarianceGrossIncomeCurrentReverseSign
            '
            Me.BudgetVarianceGrossIncomeCurrentReverseSign.Expression = "IIf([PostingPeriod] == [Parameters.EndPeriod],[BudgetVarianceGrossIncome],0) * -1" &
    ""
            Me.BudgetVarianceGrossIncomeCurrentReverseSign.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BudgetVarianceGrossIncomeCurrentReverseSign.Name = "BudgetVarianceGrossIncomeCurrentReverseSign"
            '
            'OfficeLabel
            '
            Me.OfficeLabel.Expression = "IIf(IsNullOrEmpty([OfficeDescription]),'All Offices',[OfficeDescription])"
            Me.OfficeLabel.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.OfficeLabel.Name = "OfficeLabel"
            '
            'BudgetVarianceGrossIncomeReverseSign
            '
            Me.BudgetVarianceGrossIncomeReverseSign.Expression = "[BudgetVarianceGrossIncome]*-1"
            Me.BudgetVarianceGrossIncomeReverseSign.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BudgetVarianceGrossIncomeReverseSign.Name = "BudgetVarianceGrossIncomeReverseSign"
            '
            'BudgetVarianceGrossIncomeCurrent
            '
            Me.BudgetVarianceGrossIncomeCurrent.Expression = "IIf([PostingPeriod] == [Parameters.EndPeriod],[BudgetVarianceGrossIncome],0)"
            Me.BudgetVarianceGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BudgetVarianceGrossIncomeCurrent.Name = "BudgetVarianceGrossIncomeCurrent"
            '
            'label27
            '
            Me.label27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BudgetGrossIncomeCurrent", "{0:n2}")})
            Me.label27.LocationFloat = New DevExpress.Utils.PointFloat(487.5001!, 0!)
            Me.label27.Name = "label27"
            Me.label27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label27.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label27.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label27.Summary = XrSummary1
            Me.label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'EndPeriodYear
            '
            Me.EndPeriodYear.Expression = "Substring([Parameters.EndPeriod],0,4)"
            Me.EndPeriodYear.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.EndPeriodYear.Name = "EndPeriodYear"
            '
            'label7
            '
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(22.50013!, 0!)
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(352.4983!, 18.0!)
            Me.label7.Text = "label7"
            '
            'StartPeriod
            '
            Me.StartPeriod.Description = "Start Period"
            Me.StartPeriod.Name = "StartPeriod"
            Me.StartPeriod.Visible = False
            '
            'Detail
            '
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.Detail.Visible = False
            '
            'label10
            '
            Me.label10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BudgetVarianceGrossIncomeReverseSign", "{0:n2}")})
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(898.9584!, 0!)
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label10.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label10.Summary = XrSummary2
            Me.label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label17
            '
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent", "{0:n2}")})
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(387.5001!, 0!)
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label17.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label17.Summary = XrSummary3
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'SalesClassHeader
            '
            Me.SalesClassHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label7, Me.label10, Me.label8, Me.label9, Me.label36, Me.label27, Me.label17})
            Me.SalesClassHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SalesClassCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.SalesClassHeader.HeightF = 18.0!
            Me.SalesClassHeader.Name = "SalesClassHeader"
            '
            'label11
            '
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BudgetVarianceGrossIncomeReverseSign", "{0:n2}")})
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(898.9584!, 9.499995!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label11.Summary = XrSummary7
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ClientDivProdCodes
            '
            Me.ClientDivProdCodes.Expression = "[ClientCode] +IIf(Not IsNull([DivisionCode]), '-'+[DivisionCode],Null)+IIf(Not Is" &
    "Null([ProductCode]),'-'+[ProductCode],Null)"
            Me.ClientDivProdCodes.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ClientDivProdCodes.Name = "ClientDivProdCodes"
            '
            'label2
            '
            Me.label2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent", "{0:n2}")})
            Me.label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(387.5002!, 9.499995!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label2.StylePriority.UseFont = False
            Me.label2.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label2.Summary = XrSummary8
            Me.label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BudgetVarianceGrossIncomeCurrentReverseSign", "{0:n2}")})
            Me.label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(587.5002!, 9.499995!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label4.StylePriority.UseFont = False
            Me.label4.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label4.Summary = XrSummary9
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 1.666673!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label1
            '
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(171.875!, 23.0!)
            Me.label1.Text = "Group Totals"
            '
            'label3
            '
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BudgetGrossIncomeCurrent", "{0:n2}")})
            Me.label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(487.5002!, 9.499995!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label3.StylePriority.UseFont = False
            Me.label3.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label3.Summary = XrSummary10
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label9
            '
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BudgetGrossIncome", "{0:n2}")})
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(798.9584!, 0!)
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label9.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label9.Summary = XrSummary5
            Me.label9.Text = "label9"
            Me.label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label5
            '
            Me.label5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BudgetGrossIncome", "{0:n2}")})
            Me.label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(798.9584!, 9.499995!)
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label5.StylePriority.UseFont = False
            Me.label5.StylePriority.UseTextAlignment = False
            XrSummary11.FormatString = "{0:n2}"
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label5.Summary = XrSummary11
            Me.label5.Text = "label9"
            Me.label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome", "{0:n2}")})
            Me.label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(698.9585!, 9.499995!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.StylePriority.UseTextAlignment = False
            XrSummary12.FormatString = "{0:n2}"
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label6.Summary = XrSummary12
            Me.label6.Text = "label8"
            Me.label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label12, Me.label2, Me.label3, Me.label4, Me.label5, Me.label6, Me.label11})
            Me.ReportFooter.HeightF = 27.5!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PostPeriodYear
            '
            Me.PostPeriodYear.Expression = "Substring([PostingPeriod],0,4)"
            Me.PostPeriodYear.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.PostPeriodYear.Name = "PostPeriodYear"
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'OfficeLabelFooter
            '
            Me.OfficeLabelFooter.Expression = "IIf(IsNullOrEmpty([OfficeDescription]),'Total All Offices',Concat('Total for Offi" &
    "ce: ',[OfficeDescription]))"
            Me.OfficeLabelFooter.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.OfficeLabelFooter.Name = "OfficeLabelFooter"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label1})
            Me.ReportHeader.HeightF = 23.0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'label8
            '
            Me.label8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome", "{0:n2}")})
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(698.9584!, 0!)
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label8.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label8.Summary = XrSummary4
            Me.label8.Text = "label8"
            Me.label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'EndPeriod
            '
            Me.EndPeriod.Description = "End Period"
            Me.EndPeriod.Name = "EndPeriod"
            Me.EndPeriod.Visible = False
            '
            'BudgetGrossIncomeCurrent
            '
            Me.BudgetGrossIncomeCurrent.Expression = "IIf([PostingPeriod] == [Parameters.EndPeriod],[BudgetGrossIncome],0)"
            Me.BudgetGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BudgetGrossIncomeCurrent.Name = "BudgetGrossIncomeCurrent"
            '
            'TotalGrossIncomeCurrent
            '
            Me.TotalGrossIncomeCurrent.Expression = "IIf([PostingPeriod] == [Parameters.EndPeriod],[TotalGrossIncome],0)"
            Me.TotalGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.TotalGrossIncomeCurrent.Name = "TotalGrossIncomeCurrent"
            '
            'label36
            '
            Me.label36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BudgetVarianceGrossIncomeCurrentReverseSign", "{0:n2}")})
            Me.label36.LocationFloat = New DevExpress.Utils.PointFloat(587.5001!, 0!)
            Me.label36.Name = "label36"
            Me.label36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label36.SizeF = New System.Drawing.SizeF(100.0!, 18.0!)
            Me.label36.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:n2}"
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label36.Summary = XrSummary6
            Me.label36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.ClientPL)
            '
            'GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter, Me.SalesClassHeader, Me.ReportHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ClientDivProdCodes, Me.BudgetVarianceGrossIncomeReverseSign, Me.OfficeLabel, Me.OfficeLabelFooter, Me.PostPeriodYear, Me.EndPeriodYear, Me.TotalGrossIncomeCurrent, Me.BudgetGrossIncomeCurrent, Me.BudgetVarianceGrossIncomeCurrent, Me.BudgetVarianceGrossIncomeCurrentReverseSign})
            Me.ComponentStorage.Add(Me.BindingSource)
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "26-Gross Income by Client-SC (CurrentYTD-Bud) Sub"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 2)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.StartPeriod, Me.EndPeriod})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.ScriptsSource = "'001 Revised to fix current 5/25/16"
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents SubBand1 As DevExpress.XtraReports.UI.SubBand
        Friend WithEvents SubBand2 As DevExpress.XtraReports.UI.SubBand
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BudgetVarianceGrossIncomeCurrentReverseSign As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents OfficeLabel As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BudgetVarianceGrossIncomeReverseSign As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BudgetVarianceGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label27 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents EndPeriodYear As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents StartPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SalesClassHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label36 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivProdCodes As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents PostPeriodYear As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents OfficeLabelFooter As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents EndPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents BudgetGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TotalGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace
