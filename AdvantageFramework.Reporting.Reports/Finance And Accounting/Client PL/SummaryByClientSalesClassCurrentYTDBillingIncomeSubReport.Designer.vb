Namespace FinanceAndAccounting.ClientPL

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport
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
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport))
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivProdCodes = New DevExpress.XtraReports.UI.CalculatedField()
            Me.SalesClassHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EndPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.StartPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.OfficeDescriptionLabel = New DevExpress.XtraReports.UI.CalculatedField()
            Me.TotalGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.OfficeFooterLabel = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BilledTotalCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'label4
            '
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label4.LocationFloat = New DevExpress.Utils.PointFloat(573.9583!, 10.00001!)
            Me.label4.Name = "label4"
            Me.label4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label4.Scripts.OnSummaryGetResult = "OnSummaryGetResultrsCurrPct"
            Me.label4.Scripts.OnSummaryReset = "OnSummaryResetrsCurrPct"
            Me.label4.Scripts.OnSummaryRowChanged = "OnSummaryRowChangedrsCurrPct"
            Me.label4.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label4.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:0.00%}"
            XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label4.Summary = XrSummary1
            Me.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label5
            '
            Me.label5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label5.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 10.00001!)
            Me.label5.Name = "label5"
            Me.label5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label5.Scripts.OnSummaryGetResult = "OnSummaryGetResultrsPct"
            Me.label5.Scripts.OnSummaryReset = "OnSummaryResetrsPct"
            Me.label5.Scripts.OnSummaryRowChanged = "OnSummaryRowChangedrsPct"
            Me.label5.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label5.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:0.00%}"
            XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label5.Summary = XrSummary2
            Me.label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ClientDivProdCodes
            '
            Me.ClientDivProdCodes.Expression = "[ClientCode] +IIf(Not IsNull([DivisionCode]), '-'+[DivisionCode],Null)+IIf(Not Is" &
    "Null([ProductCode]),'-'+[ProductCode],Null)"
            Me.ClientDivProdCodes.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ClientDivProdCodes.Name = "ClientDivProdCodes"
            '
            'SalesClassHeader
            '
            Me.SalesClassHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label15, Me.label16, Me.label17, Me.label14, Me.label13, Me.label12, Me.label11})
            Me.SalesClassHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SalesClassCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.SalesClassHeader.HeightF = 23.0!
            Me.SalesClassHeader.Name = "SalesClassHeader"
            '
            'label15
            '
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledTotal")})
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(700.0!, 0!)
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label15.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label15.Summary = XrSummary3
            Me.label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label16
            '
            Me.label16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 0!)
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label16.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label16.Summary = XrSummary4
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label17
            '
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(900.0!, 0!)
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.Scripts.OnSummaryGetResult = "OnSummaryGetResultscsPct"
            Me.label17.Scripts.OnSummaryReset = "OnSummaryResetscsPct"
            Me.label17.Scripts.OnSummaryRowChanged = "OnSummaryRowChangedscsPct"
            Me.label17.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label17.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:0.00%}"
            XrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label17.Summary = XrSummary5
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(573.9583!, 0!)
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.Scripts.OnSummaryGetResult = "OnSummaryGetResultscsCurrPct"
            Me.label14.Scripts.OnSummaryReset = "OnSummaryResetscsCurrPct"
            Me.label14.Scripts.OnSummaryRowChanged = "OnSummaryRowChangedscsCurrPct"
            Me.label14.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label14.StylePriority.UseTextAlignment = False
            XrSummary6.FormatString = "{0:0.00%}"
            XrSummary6.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label14.Summary = XrSummary6
            Me.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label13
            '
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent")})
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(473.9583!, 0!)
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label13.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label13.Summary = XrSummary7
            Me.label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label12
            '
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledTotalCurrent")})
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(373.9583!, 0!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary8
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label11
            '
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(324.9999!, 23.0!)
            Me.label11.Text = "label11"
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
            'label3
            '
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncomeCurrent")})
            Me.label3.LocationFloat = New DevExpress.Utils.PointFloat(473.9583!, 10.00001!)
            Me.label3.Name = "label3"
            Me.label3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label3.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label3.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label3.Summary = XrSummary9
            Me.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Detail
            '
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label1
            '
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
            Me.label1.Text = "Group Totals"
            '
            'EndPeriod
            '
            Me.EndPeriod.Name = "EndPeriod"
            Me.EndPeriod.Visible = False
            '
            'label8
            '
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(99.99991!, 10.00001!)
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(250.0!, 23.0!)
            Me.label8.StylePriority.UseTextAlignment = False
            Me.label8.Text = "Group Totals: "
            Me.label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'StartPeriod
            '
            Me.StartPeriod.Name = "StartPeriod"
            Me.StartPeriod.Visible = False
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalGrossIncome")})
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 10.00001!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label6.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label6.Summary = XrSummary10
            Me.label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label1})
            Me.ReportHeader.HeightF = 23.0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label8, Me.label2, Me.label3, Me.label4, Me.label5, Me.label6, Me.label7})
            Me.ReportFooter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ReportFooter.HeightF = 36.45833!
            Me.ReportFooter.Name = "ReportFooter"
            Me.ReportFooter.StylePriority.UseFont = False
            '
            'label2
            '
            Me.label2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledTotalCurrent")})
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(373.9583!, 10.00001!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label2.StylePriority.UseTextAlignment = False
            XrSummary11.FormatString = "{0:n2}"
            XrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label2.Summary = XrSummary11
            Me.label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label7
            '
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledTotal")})
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(699.9999!, 10.00001!)
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
            Me.label7.StylePriority.UseTextAlignment = False
            XrSummary12.FormatString = "{0:n2}"
            XrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.label7.Summary = XrSummary12
            Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'OfficeDescriptionLabel
            '
            Me.OfficeDescriptionLabel.Expression = "IIf(IsNullOrEmpty([OfficeCode]),'All Offices',Concat('Office: ',[OfficeDescriptio" &
    "n]))"
            Me.OfficeDescriptionLabel.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.OfficeDescriptionLabel.Name = "OfficeDescriptionLabel"
            '
            'TotalGrossIncomeCurrent
            '
            Me.TotalGrossIncomeCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[TotalGrossIncome],0)"
            Me.TotalGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.TotalGrossIncomeCurrent.Name = "TotalGrossIncomeCurrent"
            '
            'OfficeFooterLabel
            '
            Me.OfficeFooterLabel.Expression = "IIf(IsNullOrEmpty([OfficeCode]),'Total All Offices:',Concat('Total For Office: '," &
    "[OfficeDescription]))"
            Me.OfficeFooterLabel.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.OfficeFooterLabel.Name = "OfficeFooterLabel"
            '
            'BilledTotalCurrent
            '
            Me.BilledTotalCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[BilledTotal],0)"
            Me.BilledTotalCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BilledTotalCurrent.Name = "BilledTotalCurrent"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.ClientPL)
            '
            'SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter, Me.SalesClassHeader, Me.ReportHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.BilledTotalCurrent, Me.TotalGrossIncomeCurrent, Me.OfficeDescriptionLabel, Me.OfficeFooterLabel, Me.ClientDivProdCodes})
            Me.ComponentStorage.Add(Me.BindingSource)
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "29-Summary by Client-SC CurrentYTD Billing-Inc Sub"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 0)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.StartPeriod, Me.EndPeriod})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.ScriptsSource = resources.GetString("$this.ScriptsSource")
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientDivProdCodes As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents SalesClassHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents EndPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents StartPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents OfficeDescriptionLabel As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TotalGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents OfficeFooterLabel As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BilledTotalCurrent As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace
