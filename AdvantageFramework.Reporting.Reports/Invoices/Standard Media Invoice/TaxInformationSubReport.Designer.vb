Namespace Invoices.StandardMediaInvoice

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Public Class TaxInformationSubReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeaderInvoice = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.CalculatedField1 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField2 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CalculatedField3 = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'GroupHeaderInvoice
            '
            Me.GroupHeaderInvoice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
            Me.GroupHeaderInvoice.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("FullInvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("TaxLabel", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderInvoice.HeightF = 17.0!
            Me.GroupHeaderInvoice.Name = "GroupHeaderInvoice"
            '
            'XrTable1
            '
            Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrTable1.Name = "XrTable1"
            Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
            Me.XrTable1.SizeF = New System.Drawing.SizeF(595.2566!, 17.0!)
            '
            'XrTableRow1
            '
            Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell6, Me.XrTableCell7, Me.XrTableCell1, Me.XrTableCell8, Me.XrTableCell5, Me.XrTableCell9, Me.XrTableCell2, Me.XrTableCell10, Me.XrTableCell4, Me.XrTableCell3})
            Me.XrTableRow1.Name = "XrTableRow1"
            Me.XrTableRow1.Weight = 1.0R
            '
            'XrTableCell6
            '
            Me.XrTableCell6.CanShrink = True
            Me.XrTableCell6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxLabel")})
            Me.XrTableCell6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell6.Name = "XrTableCell6"
            Me.XrTableCell6.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell6.StylePriority.UseFont = False
            Me.XrTableCell6.StylePriority.UseTextAlignment = False
            Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            Me.XrTableCell6.Weight = 0.5R
            '
            'XrTableCell7
            '
            Me.XrTableCell7.CanShrink = True
            Me.XrTableCell7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxAmountColumn3")})
            Me.XrTableCell7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell7.Name = "XrTableCell7"
            Me.XrTableCell7.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell7.StylePriority.UseFont = False
            Me.XrTableCell7.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            XrSummary1.IgnoreNullValues = True
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCell7.Summary = XrSummary1
            Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            Me.XrTableCell7.Weight = 0.476872904935708R
            '
            'XrTableCell1
            '
            Me.XrTableCell1.CanShrink = True
            Me.XrTableCell1.Name = "XrTableCell1"
            Me.XrTableCell1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell1.Weight = 0.031096631963057543R
            '
            'XrTableCell8
            '
            Me.XrTableCell8.CanShrink = True
            Me.XrTableCell8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxAmountColumn4")})
            Me.XrTableCell8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell8.Name = "XrTableCell8"
            Me.XrTableCell8.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell8.StylePriority.UseFont = False
            Me.XrTableCell8.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.IgnoreNullValues = True
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCell8.Summary = XrSummary2
            Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            Me.XrTableCell8.Weight = 0.48296819496048476R
            '
            'XrTableCell5
            '
            Me.XrTableCell5.CanShrink = True
            Me.XrTableCell5.Name = "XrTableCell5"
            Me.XrTableCell5.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell5.Weight = 0.02101570834244193R
            '
            'XrTableCell9
            '
            Me.XrTableCell9.CanShrink = True
            Me.XrTableCell9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxAmountColumn5")})
            Me.XrTableCell9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell9.Name = "XrTableCell9"
            Me.XrTableCell9.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell9.StylePriority.UseFont = False
            Me.XrTableCell9.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:n2}"
            XrSummary3.IgnoreNullValues = True
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCell9.Summary = XrSummary3
            Me.XrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            Me.XrTableCell9.Weight = 0.47585607587613832R
            '
            'XrTableCell2
            '
            Me.XrTableCell2.CanShrink = True
            Me.XrTableCell2.Name = "XrTableCell2"
            Me.XrTableCell2.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell2.Weight = 0.028127904328695576R
            '
            'XrTableCell10
            '
            Me.XrTableCell10.CanShrink = True
            Me.XrTableCell10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxAmountColumn6")})
            Me.XrTableCell10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell10.Name = "XrTableCell10"
            Me.XrTableCell10.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell10.StylePriority.UseFont = False
            Me.XrTableCell10.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:n2}"
            XrSummary4.IgnoreNullValues = True
            XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCell10.Summary = XrSummary4
            Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            Me.XrTableCell10.Weight = 0.48296827186239194R
            '
            'XrTableCell4
            '
            Me.XrTableCell4.CanShrink = True
            Me.XrTableCell4.Name = "XrTableCell4"
            Me.XrTableCell4.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell4.Weight = 0.018126080728135985R
            '
            'XrTableCell3
            '
            Me.XrTableCell3.CanShrink = True
            Me.XrTableCell3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TaxAmountColumn7")})
            Me.XrTableCell3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell3.Name = "XrTableCell3"
            Me.XrTableCell3.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.XrTableCell3.StylePriority.UseFont = False
            Me.XrTableCell3.StylePriority.UseTextAlignment = False
            XrSummary5.FormatString = "{0:n2}"
            XrSummary5.IgnoreNullValues = True
            XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.XrTableCell3.Summary = XrSummary5
            Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
            Me.XrTableCell3.Weight = 0.48296822700294606R
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
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.MediaTaxInformation)
            '
            'TaxInformationSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeaderInvoice})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.CalculatedField1, Me.CalculatedField2, Me.CalculatedField3})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            Me.PageWidth = 600
            Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
		Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
		Friend WithEvents GroupHeaderInvoice As DevExpress.XtraReports.UI.GroupHeaderBand
		Friend WithEvents CalculatedField1 As DevExpress.XtraReports.UI.CalculatedField
		Friend WithEvents CalculatedField2 As DevExpress.XtraReports.UI.CalculatedField
		Friend WithEvents CalculatedField3 As DevExpress.XtraReports.UI.CalculatedField
		Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
		Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
		Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
		Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
		Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
	End Class

End Namespace
