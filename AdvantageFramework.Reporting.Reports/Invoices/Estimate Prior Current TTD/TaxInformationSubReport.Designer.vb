Namespace Invoices.EstimatePriorCurrentTTD

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class TaxInformationSubReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeaderInvoice = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelEstimateCityTaxData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelPriorCityTaxData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelTTDCityTaxData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCityTax = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCityTaxData = New DevExpress.XtraReports.UI.XRLabel()
            Me.CalculatedField1 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField2 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField3 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.HeightF = 0.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 0.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeaderInvoice
            '
            Me.GroupHeaderInvoice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelEstimateCityTaxData, Me.XrLabelPriorCityTaxData, Me.XrLabelTTDCityTaxData, Me.XrLabelCityTax, Me.XrLabelCityTaxData})
            Me.GroupHeaderInvoice.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FullInvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("TaxLabel", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderInvoice.HeightF = 17.0!
            Me.GroupHeaderInvoice.Name = "GroupHeaderInvoice"
            '
            'XrLabelEstimateCityTaxData
            '
            Me.XrLabelEstimateCityTaxData.CanGrow = False
            Me.XrLabelEstimateCityTaxData.CanShrink = True
            Me.XrLabelEstimateCityTaxData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EstimateTaxAmount")})
            Me.XrLabelEstimateCityTaxData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelEstimateCityTaxData.LocationFloat = New DevExpress.Utils.PointFloat(239.15!, 0.0!)
            Me.XrLabelEstimateCityTaxData.Name = "XrLabelEstimateCityTaxData"
            Me.XrLabelEstimateCityTaxData.SizeF = New System.Drawing.SizeF(91.14!, 17.0!)
            Me.XrLabelEstimateCityTaxData.StylePriority.UseFont = False
            Me.XrLabelEstimateCityTaxData.StylePriority.UsePadding = False
            Me.XrLabelEstimateCityTaxData.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelEstimateCityTaxData.Summary = XrSummary1
            Me.XrLabelEstimateCityTaxData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelPriorCityTaxData
            '
            Me.XrLabelPriorCityTaxData.CanGrow = False
            Me.XrLabelPriorCityTaxData.CanShrink = True
            Me.XrLabelPriorCityTaxData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PriorTaxAmount")})
            Me.XrLabelPriorCityTaxData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelPriorCityTaxData.LocationFloat = New DevExpress.Utils.PointFloat(348.72!, 0.0!)
            Me.XrLabelPriorCityTaxData.Name = "XrLabelPriorCityTaxData"
            Me.XrLabelPriorCityTaxData.SizeF = New System.Drawing.SizeF(91.14!, 17.0!)
            Me.XrLabelPriorCityTaxData.StylePriority.UseFont = False
            Me.XrLabelPriorCityTaxData.StylePriority.UsePadding = False
            Me.XrLabelPriorCityTaxData.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelPriorCityTaxData.Summary = XrSummary2
            Me.XrLabelPriorCityTaxData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelTTDCityTaxData
            '
            Me.XrLabelTTDCityTaxData.CanGrow = False
            Me.XrLabelTTDCityTaxData.CanShrink = True
            Me.XrLabelTTDCityTaxData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TTDTaxAmount")})
            Me.XrLabelTTDCityTaxData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelTTDCityTaxData.LocationFloat = New DevExpress.Utils.PointFloat(567.86!, 0.0!)
            Me.XrLabelTTDCityTaxData.Name = "XrLabelTTDCityTaxData"
            Me.XrLabelTTDCityTaxData.SizeF = New System.Drawing.SizeF(91.14!, 17.0!)
            Me.XrLabelTTDCityTaxData.StylePriority.UseFont = False
            Me.XrLabelTTDCityTaxData.StylePriority.UsePadding = False
            Me.XrLabelTTDCityTaxData.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelTTDCityTaxData.Summary = XrSummary3
            Me.XrLabelTTDCityTaxData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabelCityTax
            '
            Me.XrLabelCityTax.BackColor = System.Drawing.Color.Transparent
            Me.XrLabelCityTax.BorderColor = System.Drawing.Color.Black
            Me.XrLabelCityTax.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelCityTax.BorderWidth = 1.0!
            Me.XrLabelCityTax.CanGrow = False
            Me.XrLabelCityTax.CanShrink = True
            Me.XrLabelCityTax.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxLabel")})
            Me.XrLabelCityTax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelCityTax.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCityTax.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLabelCityTax.Name = "XrLabelCityTax"
            Me.XrLabelCityTax.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabelCityTax.SizeF = New System.Drawing.SizeF(129.3348!, 17.0!)
            Me.XrLabelCityTax.StylePriority.UseTextAlignment = False
            Me.XrLabelCityTax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelCityTaxData
            '
            Me.XrLabelCityTaxData.CanGrow = False
            Me.XrLabelCityTaxData.CanShrink = True
            Me.XrLabelCityTaxData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxAmount")})
            Me.XrLabelCityTaxData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabelCityTaxData.LocationFloat = New DevExpress.Utils.PointFloat(458.29!, 0.0!)
            Me.XrLabelCityTaxData.Name = "XrLabelCityTaxData"
            Me.XrLabelCityTaxData.SizeF = New System.Drawing.SizeF(91.14!, 17.0!)
            Me.XrLabelCityTaxData.StylePriority.UseFont = False
            Me.XrLabelCityTaxData.StylePriority.UsePadding = False
            Me.XrLabelCityTaxData.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrLabelCityTaxData.Summary = XrSummary4
            Me.XrLabelCityTaxData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'CalculatedField1
            '
            Me.CalculatedField1.DataMember = "aaa"
            Me.CalculatedField1.Expression = "[].Sum([CityTax])"
            Me.CalculatedField1.Name = "CalculatedField1"
            '
            'CalculatedField2
            '
            Me.CalculatedField2.DataMember = "aaa"
            Me.CalculatedField2.Expression = "[].Sum([CountyTax])"
            Me.CalculatedField2.Name = "CalculatedField2"
            '
            'CalculatedField3
            '
            Me.CalculatedField3.DataMember = "aaa"
            Me.CalculatedField3.Expression = "[].Sum([StateTax])"
            Me.CalculatedField3.Name = "CalculatedField3"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.TaxInformation)
            '
            'TaxInformationSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeaderInvoice})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.CalculatedField1, Me.CalculatedField2, Me.CalculatedField3})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.PageWidth = 659
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents GroupHeaderInvoice As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelCityTax As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCityTaxData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CalculatedField1 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField2 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CalculatedField3 As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrLabelTTDCityTaxData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelEstimateCityTaxData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelPriorCityTaxData As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
