﻿Namespace FinanceAndAccounting.ClientPL

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class ClientProfitandLossDetailCostofBillingSubReport
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientProfitandLossDetailCostofBillingSubReport))
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.label15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.label16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label23 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BilledTotalCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line4 = New DevExpress.XtraReports.UI.XRLine()
            Me.OfficeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.line5 = New DevExpress.XtraReports.UI.XRLine()
            Me.label12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TypeHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.TotalGrossIncomeCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.line6 = New DevExpress.XtraReports.UI.XRLine()
            Me.label5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.EndPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.label14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TypeDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.label3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line3 = New DevExpress.XtraReports.UI.XRLine()
            Me.label22 = New DevExpress.XtraReports.UI.XRLabel()
            Me.SalesClassHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BilledCostOfSalesTotal = New DevExpress.XtraReports.UI.CalculatedField()
            Me.label19 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.label13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label21 = New DevExpress.XtraReports.UI.XRLabel()
            Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.BilledCostOfSalesTotalCurrent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.StartPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.TypeFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.line2 = New DevExpress.XtraReports.UI.XRLine()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'label15
            '
            Me.label15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductCode")})
            Me.label15.Dpi = 100.0!
            Me.label15.ForeColor = System.Drawing.Color.SteelBlue
            Me.label15.LocationFloat = New DevExpress.Utils.PointFloat(368.75!, 0!)
            Me.label15.Name = "label15"
            Me.label15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label15.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label15.StylePriority.UseForeColor = False
            Me.label15.Text = "label15"
            Me.label15.Visible = False
            '
            'label4
            '
            Me.label4.CanShrink = True
            Me.label4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledCostOfSalesTotalCurrent")})
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
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label1
            '
            Me.label1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TypeDescription")})
            Me.label1.Dpi = 100.0!
            Me.label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.label1.Name = "label1"
            Me.label1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label1.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
            Me.label1.StylePriority.UseFont = False
            Me.label1.Text = "label1"
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
            Me.label16.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0.00001589457!)
            Me.label16.Name = "label16"
            Me.label16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label16.SizeF = New System.Drawing.SizeF(750.0!, 49.99999!)
            Me.label16.StylePriority.UseForeColor = False
            Me.label16.StylePriority.UseTextAlignment = False
            Me.label16.Text = resources.GetString("label16.Text")
            Me.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.label16.Visible = False
            '
            'label6
            '
            Me.label6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledCostOfSalesTotal", "{0:n2}")})
            Me.label6.Dpi = 100.0!
            Me.label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label6.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 0!)
            Me.label6.Name = "label6"
            Me.label6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label6.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label6.StylePriority.UseFont = False
            Me.label6.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label6.Summary = XrSummary2
            Me.label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label23
            '
            Me.label23.Dpi = 100.0!
            Me.label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label23.ForeColor = System.Drawing.Color.SteelBlue
            Me.label23.LocationFloat = New DevExpress.Utils.PointFloat(641.67!, 0!)
            Me.label23.Name = "label23"
            Me.label23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label23.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label23.StylePriority.UseFont = False
            Me.label23.StylePriority.UseForeColor = False
            Me.label23.StylePriority.UseTextAlignment = False
            Me.label23.Text = "100%"
            Me.label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label23.Visible = False
            '
            'BilledTotalCurrent
            '
            Me.BilledTotalCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[BilledTotal],0)"
            Me.BilledTotalCurrent.Name = "BilledTotalCurrent"
            '
            'label18
            '
            Me.label18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label18.Dpi = 100.0!
            Me.label18.LocationFloat = New DevExpress.Utils.PointFloat(641.67!, 0!)
            Me.label18.Name = "label18"
            Me.label18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label18.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label18.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:0.00%}"
            XrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label18.Summary = XrSummary3
            Me.label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'line4
            '
            Me.line4.Dpi = 100.0!
            Me.line4.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 23.87505!)
            Me.line4.Name = "line4"
            Me.line4.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
            '
            'OfficeHeader
            '
            Me.OfficeHeader.Dpi = 100.0!
            Me.OfficeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("OfficeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.OfficeHeader.HeightF = 0!
            Me.OfficeHeader.Level = 3
            Me.OfficeHeader.Name = "OfficeHeader"
            '
            'label8
            '
            Me.label8.Dpi = 100.0!
            Me.label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label8.LocationFloat = New DevExpress.Utils.PointFloat(50.0!, 0!)
            Me.label8.Name = "label8"
            Me.label8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label8.SizeF = New System.Drawing.SizeF(41.66667!, 23.0!)
            Me.label8.StylePriority.UseFont = False
            Me.label8.StylePriority.UseTextAlignment = False
            Me.label8.Text = "Total "
            Me.label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'line1
            '
            Me.line1.Dpi = 100.0!
            Me.line1.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 23.0!)
            Me.line1.Name = "line1"
            Me.line1.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
            '
            'line5
            '
            Me.line5.Dpi = 100.0!
            Me.line5.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 26.87505!)
            Me.line5.Name = "line5"
            Me.line5.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
            '
            'label12
            '
            Me.label12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledCostOfSalesTotalCurrent")})
            Me.label12.Dpi = 100.0!
            Me.label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label12.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 0!)
            Me.label12.Name = "label12"
            Me.label12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label12.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label12.StylePriority.UseFont = False
            Me.label12.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label12.Summary = XrSummary4
            Me.label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TypeHeader
            '
            Me.TypeHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label1})
            Me.TypeHeader.Dpi = 100.0!
            Me.TypeHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Type", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.TypeHeader.HeightF = 23.0!
            Me.TypeHeader.Level = 1
            Me.TypeHeader.Name = "TypeHeader"
            '
            'TotalGrossIncomeCurrent
            '
            Me.TotalGrossIncomeCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[TotalGrossIncome],0)"
            Me.TotalGrossIncomeCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.TotalGrossIncomeCurrent.Name = "TotalGrossIncomeCurrent"
            '
            'line6
            '
            Me.line6.Dpi = 100.0!
            Me.line6.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 26.87505!)
            Me.line6.Name = "line6"
            Me.line6.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
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
            Me.label5.Text = "Cost Of Billing"
            '
            'label10
            '
            Me.label10.Dpi = 100.0!
            Me.label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label10.LocationFloat = New DevExpress.Utils.PointFloat(50.0!, 0!)
            Me.label10.Name = "label10"
            Me.label10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label10.SizeF = New System.Drawing.SizeF(184.375!, 23.0!)
            Me.label10.StylePriority.UseFont = False
            Me.label10.Text = "Total Cost Of Billing"
            '
            'EndPeriod
            '
            Me.EndPeriod.Name = "EndPeriod"
            Me.EndPeriod.Visible = False
            '
            'label14
            '
            Me.label14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionCode")})
            Me.label14.Dpi = 100.0!
            Me.label14.ForeColor = System.Drawing.Color.SteelBlue
            Me.label14.LocationFloat = New DevExpress.Utils.PointFloat(293.75!, 0!)
            Me.label14.Name = "label14"
            Me.label14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label14.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label14.StylePriority.UseForeColor = False
            Me.label14.Text = "label14"
            Me.label14.Visible = False
            '
            'TypeDescription
            '
            Me.TypeDescription.Expression = "IIf([Type]='G','General Ledger',IIf([Type]='M','Media',IIf([Type]='P','Production" &
    "','Other')))"
            Me.TypeDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.TypeDescription.Name = "TypeDescription"
            '
            'label11
            '
            Me.label11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledCostOfSalesTotal", "{0:n2}")})
            Me.label11.Dpi = 100.0!
            Me.label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label11.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 0!)
            Me.label11.Name = "label11"
            Me.label11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label11.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label11.StylePriority.UseFont = False
            Me.label11.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label11.Summary = XrSummary5
            Me.label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Detail
            '
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'label3
            '
            Me.label3.CanShrink = True
            Me.label3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledCostOfSalesTotal", "{0:n2}")})
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
            'label9
            '
            Me.label9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TypeDescription")})
            Me.label9.Dpi = 100.0!
            Me.label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label9.LocationFloat = New DevExpress.Utils.PointFloat(92.70834!, 0!)
            Me.label9.Name = "label9"
            Me.label9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label9.SizeF = New System.Drawing.SizeF(226.0417!, 23.0!)
            Me.label9.StylePriority.UseFont = False
            Me.label9.Text = "label9"
            '
            'ClientFooter
            '
            Me.ClientFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line5, Me.line6, Me.line3, Me.line4, Me.label23, Me.label22, Me.label10, Me.label12, Me.label11})
            Me.ClientFooter.Dpi = 100.0!
            Me.ClientFooter.HeightF = 35.0!
            Me.ClientFooter.Level = 2
            Me.ClientFooter.Name = "ClientFooter"
            '
            'line3
            '
            Me.line3.Dpi = 100.0!
            Me.line3.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 23.87505!)
            Me.line3.Name = "line3"
            Me.line3.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
            '
            'label22
            '
            Me.label22.Dpi = 100.0!
            Me.label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label22.ForeColor = System.Drawing.Color.SteelBlue
            Me.label22.LocationFloat = New DevExpress.Utils.PointFloat(439.58!, 0!)
            Me.label22.Name = "label22"
            Me.label22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label22.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label22.StylePriority.UseFont = False
            Me.label22.StylePriority.UseForeColor = False
            Me.label22.StylePriority.UseTextAlignment = False
            Me.label22.Text = "100%"
            Me.label22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.label22.Visible = False
            '
            'SalesClassHeader
            '
            Me.SalesClassHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label18, Me.label17, Me.label2, Me.label3, Me.label4})
            Me.SalesClassHeader.Dpi = 100.0!
            Me.SalesClassHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SalesClassCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.SalesClassHeader.HeightF = 23.0!
            Me.SalesClassHeader.Name = "SalesClassHeader"
            '
            'label17
            '
            Me.label17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label17.Dpi = 100.0!
            Me.label17.LocationFloat = New DevExpress.Utils.PointFloat(439.58!, 0!)
            Me.label17.Name = "label17"
            Me.label17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label17.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label17.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:0.00%}"
            XrSummary7.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label17.Summary = XrSummary7
            Me.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label2
            '
            Me.label2.CanShrink = True
            Me.label2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SalesClassDescription")})
            Me.label2.Dpi = 100.0!
            Me.label2.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
            Me.label2.Name = "label2"
            Me.label2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label2.SizeF = New System.Drawing.SizeF(293.75!, 23.0!)
            Me.label2.Text = "label2"
            Me.label2.WordWrap = False
            '
            'BilledCostOfSalesTotal
            '
            Me.BilledCostOfSalesTotal.Expression = "[BilledCostOfSales] + [GLCostOfSales] + [ManualCOS] + [CRClientCostOfSales] + [No" &
    "nbillableAPCostOfSales]"
            Me.BilledCostOfSalesTotal.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BilledCostOfSalesTotal.Name = "BilledCostOfSalesTotal"
            '
            'label19
            '
            Me.label19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label19.Dpi = 100.0!
            Me.label19.LocationFloat = New DevExpress.Utils.PointFloat(439.58!, 0!)
            Me.label19.Name = "label19"
            Me.label19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label19.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label19.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:0.00%}"
            XrSummary8.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label19.Summary = XrSummary8
            Me.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
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
            'ClientHeader
            '
            Me.ClientHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label20, Me.label15, Me.label14, Me.label13, Me.label5})
            Me.ClientHeader.Dpi = 100.0!
            Me.ClientHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ClientCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("DivisionCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ProductCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.ClientHeader.HeightF = 23.0!
            Me.ClientHeader.Level = 2
            Me.ClientHeader.Name = "ClientHeader"
            '
            'label13
            '
            Me.label13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label13.Dpi = 100.0!
            Me.label13.ForeColor = System.Drawing.Color.SteelBlue
            Me.label13.LocationFloat = New DevExpress.Utils.PointFloat(218.75!, 0!)
            Me.label13.Name = "label13"
            Me.label13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label13.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label13.StylePriority.UseForeColor = False
            Me.label13.Text = "label13"
            Me.label13.Visible = False
            '
            'label21
            '
            Me.label21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCode")})
            Me.label21.Dpi = 100.0!
            Me.label21.LocationFloat = New DevExpress.Utils.PointFloat(641.67!, 0!)
            Me.label21.Name = "label21"
            Me.label21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label21.SizeF = New System.Drawing.SizeF(75.0!, 23.0!)
            Me.label21.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0:0.00%}"
            XrSummary9.Func = DevExpress.XtraReports.UI.SummaryFunc.Custom
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label21.Summary = XrSummary9
            Me.label21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'label7
            '
            Me.label7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BilledCostOfSalesTotalCurrent")})
            Me.label7.Dpi = 100.0!
            Me.label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(339.58!, 0!)
            Me.label7.Name = "label7"
            Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.label7.SizeF = New System.Drawing.SizeF(97.92!, 23.0!)
            Me.label7.StylePriority.UseFont = False
            Me.label7.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.label7.Summary = XrSummary10
            Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'BilledCostOfSalesTotalCurrent
            '
            Me.BilledCostOfSalesTotalCurrent.Expression = "IIf([PostingPeriod]=[Parameters.EndPeriod],[BilledCostOfSales] + [GLCostOfSales] " &
    "+ [ManualCOS] + [CRClientCostOfSales] + [NonbillableAPCostOfSales],0)"
            Me.BilledCostOfSalesTotalCurrent.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
            Me.BilledCostOfSalesTotalCurrent.Name = "BilledCostOfSalesTotalCurrent"
            '
            'StartPeriod
            '
            Me.StartPeriod.Name = "StartPeriod"
            Me.StartPeriod.Visible = False
            '
            'TypeFooter
            '
            Me.TypeFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.line2, Me.line1, Me.label21, Me.label19, Me.label9, Me.label8, Me.label6, Me.label7})
            Me.TypeFooter.Dpi = 100.0!
            Me.TypeFooter.HeightF = 35.0!
            Me.TypeFooter.Level = 1
            Me.TypeFooter.Name = "TypeFooter"
            '
            'line2
            '
            Me.line2.Dpi = 100.0!
            Me.line2.LocationFloat = New DevExpress.Utils.PointFloat(541.67!, 22.99999!)
            Me.line2.Name = "line2"
            Me.line2.SizeF = New System.Drawing.SizeF(97.92!, 3.0!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)
            '
            'ClientProfitandLossDetailCostofBillingSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.SalesClassHeader, Me.TypeHeader, Me.TypeFooter, Me.ClientHeader, Me.ClientFooter, Me.OfficeHeader})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.BilledCostOfSalesTotal, Me.BilledCostOfSalesTotalCurrent, Me.BilledTotalCurrent, Me.TotalGrossIncomeCurrent, Me.TypeDescription})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.DisplayName = "01-Client PL Detail Report-2 Cost Of Billing Sub"
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.StartPeriod, Me.EndPeriod})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents label15 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents label16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label23 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BilledTotalCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label18 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents OfficeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents line5 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TypeHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents TotalGrossIncomeCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents line6 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents EndPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents label14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TypeDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents label3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents label22 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SalesClassHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BilledCostOfSalesTotal As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents label19 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ClientHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents label13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label21 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BilledCostOfSalesTotalCurrent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents StartPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents TypeFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents line2 As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
